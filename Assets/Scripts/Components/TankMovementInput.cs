using UnityEngine;
using Zenject;

namespace GameSample.Core
{
    public sealed class TankMovementInput : MonoBehaviour
    {
        [SerializeField] private string mInputActionName = default;

        [Range(0f, 1f)]
        [SerializeField] private float mRotationPriority = 0.5f;

        //NavMesh is not well suited for driving a tank, but this is normal, because we do not need enemies to be controlled in the precise way

        [Inject] private IPlayer mPlayer = default;
        [Inject] private IInputManager mInputManager = default;
        [Inject] private ITankMovementAgent mVehicleAgent = default;

        private void Update()
        {
            var input = mInputManager.InputSource(mPlayer.Index);
            var (rotationThrottle, linearThrottle) = input.Action(mInputActionName).Value.Deconstruct();

            var angularControlWeight = mRotationPriority *Mathf.Abs(rotationThrottle) /
                Mathf.Lerp(Mathf.Abs(linearThrottle), Mathf.Abs(rotationThrottle), mRotationPriority);

            var deltaTrackThrottle = rotationThrottle * angularControlWeight;
            var linearThrottleOffset = (1f - Mathf.Abs(deltaTrackThrottle)) * linearThrottle;

            var leftTrackSpeed = linearThrottleOffset + deltaTrackThrottle;
            var rightTrackSpeed = linearThrottleOffset - deltaTrackThrottle;

            mVehicleAgent.Move(leftTrackSpeed, rightTrackSpeed);
        }
    }
}
