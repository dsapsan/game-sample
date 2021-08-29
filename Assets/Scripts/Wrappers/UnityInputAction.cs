using System;
using UnityEngine;
using UnityEngine.InputSystem;

namespace GameSample.Core
{
    public sealed class UnityInputAction : IInputAction, IDisposable
    {
        private InputAction mInputAction;

        public bool Active { get; private set; }
        public bool Triggered => mInputAction != null && mInputAction.triggered;
        public Vector2 Value => mInputAction == null ? Vector2.zero : mInputAction.ReadValue<Vector2>();

        public UnityInputAction(InputAction inputAction)
        {
            mInputAction = inputAction;

            if (inputAction != null)
            {
                mInputAction.started += OnStarted;
                mInputAction.canceled += OnCanceled;
            }
        }

        private void OnStarted(InputAction.CallbackContext obj)
        {
            Active = true;
        }

        private void OnCanceled(InputAction.CallbackContext obj)
        {
            Active = false;
        }

        public void Dispose()
        {
            Active = false;

            if (mInputAction != null)
            {
                mInputAction = null;
                mInputAction.started -= OnStarted;
                mInputAction.canceled -= OnCanceled;
            }
        }
    }
}
