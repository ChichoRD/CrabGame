using UnityEngine;

namespace WaveSystem.Wave.Event.Entity
{
    public abstract class EntityFlyweightSettings : ScriptableObject
    {
        public abstract IEntity Create();
    }
}