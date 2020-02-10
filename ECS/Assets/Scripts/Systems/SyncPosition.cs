using Unity.Burst;
using Unity.Collections;
using Unity.Entities;
using Unity.Jobs;
using Unity.Mathematics;
using Unity.Transforms;
using static Unity.Mathematics.math;

public class SyncPosition : JobComponentSystem
{
    [BurstCompile]
    struct SyncPositionJob : IJobForEach<Translation, Position2D>
    {
        public void Execute(ref Translation translation, [ReadOnly] ref Position2D position)
        {
            translation.Value = float3(position.value.x, translation.Value.y, position.value.y);
        }
    }
    
    protected override JobHandle OnUpdate(JobHandle inputDependencies)
    {
        var job = new SyncPositionJob();
        
        return job.Schedule(this, inputDependencies);
    }
}