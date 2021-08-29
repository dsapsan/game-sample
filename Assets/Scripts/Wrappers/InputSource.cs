using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;
using Zenject;

namespace GameSample.Core
{
    [RequireComponent(typeof(PlayerInput))]
    public sealed class InputSource : MonoBehaviour, IInputSource, IPoolable<IMemoryPool>
    {
        public sealed class Factory : PlaceholderFactory<InputSource>
        {
        }

        private PlayerInput mPlayerInput;
        private Dictionary<string, UnityInputAction> mActions = new Dictionary<string, UnityInputAction>();

        private void Awake()
        {
            mPlayerInput = GetComponent<PlayerInput>();
            gameObject.SetActive(false);
        }

        private void OnDestroy()
        {
            Disconnect();
        }

        public IInputAction Action(string name)
        {
            if (!mActions.TryGetValue(name, out var container))
            {
                var action = mPlayerInput.actions.FindAction(name);

                //TODO Log only on debug
                if (action == null)
                    Debug.LogError($"Invalid action name : {name}");

                container = new UnityInputAction(action);
                mActions.Add(name, container);
            }

            return container;
        }

        public void OnSpawned(IMemoryPool pool)
        {
            gameObject.SetActive(true);
        }

        public void OnDespawned()
        {
            gameObject.SetActive(false);
            Disconnect();
        }

        private void Disconnect()
        {
            foreach (var action in mActions)
                action.Value.Dispose();
            mActions.Clear();
        }
    }
}
