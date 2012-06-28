using System;

namespace ambient.audio.players
{
    public interface IMusicPlayer : ISoundPlayer
    {
        TimeSpan TotalTime { get;}
        TimeSpan CurrentTime { get; set; }
        bool HasEnded { get; }
        bool IsLooping { get; set; }
        
        void Pause();        
    }
}