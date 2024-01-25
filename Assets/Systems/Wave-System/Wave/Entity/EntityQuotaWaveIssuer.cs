using System;
using System.Collections.Generic;
using UnityEngine;
using WaveSystem.Wave.Event.Entity;

namespace WaveSystem.Wave.Entity
{
    [CreateAssetMenu(fileName = "EntityQuotaWaveIssuer", menuName = "Wave System/Wave Issuer/Entity Quota Wave Issuer", order = 0)]
    internal class EntityQuotaWaveIssuer : ScriptableObject, IWaveIssuer, IEntityQuotaRegister
    {
        [SerializeField]
        private EntityQuotaItem[] _quotaItems = new EntityQuotaItem[0];

        [SerializeField]
        private Wave _wave;

        private Dictionary<EntityFlyweightSettings, int> _totalQuota;
        private Dictionary<EntityFlyweightSettings, int> _currentQuota;

        public event Action<IWave> WaveIssued;

        private void Awake()
        {
            _quotaItems ??= new EntityQuotaItem[0];
            _totalQuota = GetQuota(_quotaItems);
            _currentQuota = new Dictionary<EntityFlyweightSettings, int>(_totalQuota);
        }

        public void RegisterEntity(IEntity entity)
        {
            if (_currentQuota.Count == 0)
                _currentQuota = new Dictionary<EntityFlyweightSettings, int>(_totalQuota);

            if (ReduceQuota(_currentQuota, entity, 1) <= 0)
                _currentQuota.Remove(entity.FlyweightSettings);

            if (_currentQuota.Count == 0)
                WaveIssued?.Invoke(_wave);
        }

        private static Dictionary<EntityFlyweightSettings, int> GetQuota(IEnumerable<EntityQuotaItem> quotaItems)
        {
            var quota = new Dictionary<EntityFlyweightSettings, int>();
            foreach (var quotaItem in quotaItems)
                if (!quota.TryAdd(quotaItem.Settings, quotaItem.Quota))
                    quota[quotaItem.Settings] += quotaItem.Quota;

            return quota;
        }

        private static int ReduceQuota(Dictionary<EntityFlyweightSettings, int> quota, IEntity entity, int amount)
        {
            int newQuota = -amount;
            if (quota.TryGetValue(entity.FlyweightSettings, out var quotaAmount))
            {
                newQuota += quotaAmount;
                quota[entity.FlyweightSettings] = newQuota;
            }

            return newQuota;
        }

        [Serializable]
        private struct EntityQuotaItem
        {
            [field: SerializeField]
            public EntityFlyweightSettings Settings { get; private set; }

            [field: SerializeField]
            public int Quota { get; private set; }

            public EntityQuotaItem(EntityFlyweightSettings settings, int quota)
            {
                Settings = settings;
                Quota = quota;
            }
        }
    }
}