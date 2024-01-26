using UnityEngine;

namespace WaveSystem.Wave.Event
{
    internal abstract class WaveEvent : ScriptableObject, IWaveEvent
    {
        public abstract void Dispatch();
    }
}