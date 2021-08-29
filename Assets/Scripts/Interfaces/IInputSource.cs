namespace GameSample.Core
{
    public interface IInputSource
    {
        IInputAction Action(string name);
    }
}
