using System.Collections.Generic;

namespace ambient.audio.models
{
    public interface IPlaylistConfiguration
    {
        IList<ISoundConfiguration> Players { get; }
        IList<ISoundConfiguration> QuickSoundStates { get; }
    }
}