namespace GameSample.Core
{
    public sealed class InputSourceStub : IInputSource
    {
        public static readonly InputSourceStub Instance = new InputSourceStub();

        public IInputAction Action(string name)
        {
            return InputActionStub.Instance;
        }
    }
}
