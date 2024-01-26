using System;

namespace WaveSystem.Wave
{
    public interface IWaveIssuer
    {
        event Action<IWave> WaveIssued;
    }
}