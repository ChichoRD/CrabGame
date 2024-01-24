using System.Collections.Generic;
using UnityEngine;
using WaveSystem.Wave.Event;

namespace WaveSystem.Wave
{
    [CreateAssetMenu(fileName = "Wave", menuName = "Wave System/Wave", order = 0)]
    internal class Wave : ScriptableObject, IWave
    {
        [SerializeField]
        private WaveEvent[] _waveEvents;

        public IEnumerable<IWaveEvent> GetWaveEvents() => _waveEvents;
    }
}