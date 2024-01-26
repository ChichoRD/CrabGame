using System;
using UnityEngine;
using WaveSystem.Wave.Event.Entity;

namespace WaveSystem.Wave.Event
{
    [CreateAssetMenu(fileName = "EntitySpawnWaveEvent", menuName = "Wave System/Wave Event/Entity/Entity Spawn Wave Event")]
    internal class EntitySpawnWaveEvent : WaveEvent
    {
        [SerializeField]
        private EntityFlyweightSettings[] _flyweightSettings;

        public virtual event Action<IEntity> EntityInstanced;

        public override void Dispatch()
        {
            foreach (var flyweightSetting in _flyweightSettings)
                EntityInstanced?.Invoke(flyweightSetting.Create());
        }
    }
}