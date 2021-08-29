using System.Collections.Generic;
using Zenject;

namespace GameSample.Core
{
    public sealed class InputManager : MonoInstaller, IInputManager
    {
        [Inject] private InputSource.Factory mInputSourceFactory = default;

        private List<IInputSource> mInputSources = new List<IInputSource>();

        private void Awake()
        {
            mInputSources.Add(mInputSourceFactory.Create());
        }

        public IInputSource InputSource(int playerIndex)
        {
            return 0 <= playerIndex && playerIndex < mInputSources.Count
                ? mInputSources[playerIndex]
                : InputSourceStub.Instance;
        }
    }
}
