using System.Collections.Generic;

namespace ambient.audio.models
{
    public class PlaylistConfiguration : IPlaylistConfiguration
    {
        public IList<ISoundConfiguration> Players { get; private set; }
        public IList<ISoundConfiguration> QuickSoundStates { get; private set; }

        public PlaylistConfiguration()
        {
            Players = new List<ISoundConfiguration>();
            QuickSoundStates = new List<ISoundConfiguration>();
        }
    }
}