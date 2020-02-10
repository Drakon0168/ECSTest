using Unity.Entities;
using Unity.Mathematics;
using UnityEngine;

[DisallowMultipleComponent]
[RequiresEntityConversion]
public class BallAuthor : MonoBehaviour, IConvertGameObjectToEntity
{
    public void Convert(Entity entity, EntityManager dstManager, GameObjectConversionSystem conversionSystem)
    {
        dstManager.AddComponent<Acceleration2D>(entity);
        dstManager.AddComponent<Velocity2D>(entity);
        dstManager.AddComponent<Position2D>(entity);
    }
}
