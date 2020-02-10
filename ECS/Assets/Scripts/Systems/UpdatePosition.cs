using Unity.Burst;
using Unity.Collections;
using Unity.Entities;
using Unity.Jobs;
using Unity.Mathematics;
using Unity.Transforms;
using static Unity.Mathematics.math;

public class UpdatePosition : JobComponentSystem
{
    [BurstCompile]
    struct UpdatePositionJob : IJobForEach<Translation, Position2D, Velocity2D, Acceleration2D>
    {
        [ReadOnly]
        public float deltaTime;
        
        public void Execute(ref Translation translation, ref Position2D position, ref Velocity2D velocity, ref Acceleration2D acceleration)
        {
            velocity.value += acceleration.value * deltaTime;
            position.value += velocity.value * deltaTime;
            acceleration.value = float2(0, 0);
        }
    }
    
    protected override JobHandle OnUpdate(JobHandle inputDependencies)
    {
        var job = new UpdatePositionJob();
        job.deltaTime = Time.DeltaTime;
        
        return job.Schedule(this, inputDependencies);
    }
}