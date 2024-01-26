using System;
using UnityEngine;
using WaveSystem.Wave.Event.Entity;

namespace WaveSystem.Wave.Entity
{
    [CreateAssetMenu(fileName = "EntityMultiWaveIssuer", menuName = "Wave System/Wave Issuer/Entity Multi Wave Issuer", order = 0)]
    internal class EntityMultiWaveIssuer : ScriptableObject, IWaveIssuer, IEntityQuotaRegister
    {
        [SerializeField]
        private EntityQuotaWaveIssuer[] _issuers = new EntityQuotaWaveIssuer[0];

        [SerializeField]
        private bool _loopWaves = false;

        [SerializeField]
        [Min(0)]
        private int _initialIssuerIndex = 0;
        private int _currentIssuerIndex = 0;

        public event Action<IWave> WaveIssued
        {
            add
            {
                foreach (var issuer in _issuers)
                    issuer.WaveIssued += value;
            }
            remove
            {
                foreach (var issuer in _issuers)
                    issuer.WaveIssued -= value;
            }
        }

        private void Awake()
        {
            WaveIssued += OnWaveIssued;

            _currentIssuerIndex = _initialIssuerIndex;
        }

        private void OnDestroy()
        {
            WaveIssued -= OnWaveIssued;
        }

        public void RegisterEntity(IEntity entity) => _issuers[_currentIssuerIndex].RegisterEntity(entity);

        private void OnWaveIssued(IWave obj) =>
            _currentIssuerIndex = _loopWaves
                                  ? (_currentIssuerIndex + 1) % _issuers.Length
                                  : Mathf.Min(_currentIssuerIndex + 1, _issuers.Length - 1);
    }
}