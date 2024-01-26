using UnityEngine;

namespace WaveSystem.Wave.Event.Entity
{
    internal class PrefabEntityFlyweightSettings : EntityFlyweightSettings
    {
        [SerializeField]
        private GameObject _prefab;

        public override IEntity Create() => new PrefabEntity(this, Instantiate(_prefab));

        private readonly struct PrefabEntity : IEntity
        {
            public EntityFlyweightSettings FlyweightSettings { get; }
            public GameObject GameObject { get; }

            public PrefabEntity(EntityFlyweightSettings flyweightSettings, GameObject gameObject)
            {
                FlyweightSettings = flyweightSettings;
                GameObject = gameObject;
            }
        }
    }
}