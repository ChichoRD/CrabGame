using UnityEngine;

namespace WaveSystem.Wave.Event.Entity
{
    public interface IEntity
    {
        EntityFlyweightSettings FlyweightSettings { get; }
        GameObject GameObject { get; }
    }
}