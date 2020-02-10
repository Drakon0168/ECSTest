using Unity.Burst;
using Unity.Collections;
using Unity.Entities;
using Unity.Jobs;
using Unity.Mathematics;
using Unity.Transforms;
using static Unity.Mathematics.math;

public class PlayerMovement : JobComponentSystem
{
    [BurstCompile]
    struct PlayerMovementJob : IJobForEach<Velocity2D, Acceleration2D, MovementComponent>
    {
        public float deltaTime;

        public void Execute(ref Velocity2D velocity, ref Acceleration2D acceleration, [ReadOnly] ref MovementComponent movement)
        {
            
        }
    }
    
    protected override JobHandle OnUpdate(JobHandle inputDependencies)
    {
        var job = new PlayerMovementJob();
        job.deltaTime = Time.DeltaTime;

        return job.Schedule(this, inputDependencies);
    }
}