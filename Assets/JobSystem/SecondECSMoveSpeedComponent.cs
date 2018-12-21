using System;
using Unity.Entities;

namespace TEST
{
    [Serializable]
    public struct MoveSpeed : IComponentData
    {
        public float Value;
    }

    public class SecondECSMoveSpeedComponent : ComponentDataWrapper<MoveSpeed> { }
}
