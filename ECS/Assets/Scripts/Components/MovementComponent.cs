using Unity.Entities;
using Unity.Mathematics;

public struct MovementComponent : IComponentData
{
    float moveSpeed;
    float moveForce;
}