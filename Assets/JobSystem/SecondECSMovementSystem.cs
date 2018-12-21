using System.Collections;
using UnityEngine;
using Unity.Entities;
using Unity.Jobs;
using Unity.Mathematics;
using Unity.Transforms;

namespace TEST
{
    public class SecondECSMovementSystem : JobComponentSystem
    {
        [ComputeJobOptimization]
        struct MovementJob : IJobProcessComponentData<Position, Rotation, MoveSpeed>
        {
            public float topBound;
            public float bottomBound;
            public float deltatime;

            public void Execute(ref Position position, ref Rotation rotation, ref MoveSpeed speed)
            {
                float3 value = position.Value;
                value += deltatime * speed.Value * math.forward(rotation.Value);

                if (value.z < bottomBound)
                    value.z = topBound;

                position.Value = value;
            }
        }

        protected override JobHandle OnUpdate(JobHandle inputDeps)
        {
            MovementJob moveJob = new MovementJob
            {
                topBound = SecondECSGameManagerJobSystem.ins.TopBound,
                bottomBound = SecondECSGameManagerJobSystem.ins.BottonBound,
                deltatime = Time.deltaTime,
            };

            JobHandle moveHandle = moveJob.Schedule(this, inputDeps);

            return moveHandle;
        }
    }
}
