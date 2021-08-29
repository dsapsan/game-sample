namespace GameSample.Core
{
    public interface ITankMovementAgent
    {
        void Move(float leftTrackThrottle, float rightTrackThrottle);
    }
}
