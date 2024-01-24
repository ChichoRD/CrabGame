using System.Collections.Generic;
using WaveSystem.Wave.Event;

namespace WaveSystem.Wave
{
    public interface IWave
    {
        IEnumerable<IWaveEvent> GetWaveEvents();
    }
}