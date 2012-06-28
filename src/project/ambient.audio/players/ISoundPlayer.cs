using System;

namespace ambient.audio.players
{
    public interface ISoundPlayer : IDisposable
    {
        PlaybackState PlaybackState { get; }
        float Volume { get; set; }
        float Pan { get; set; }

        void Play();
        void Stop();

        void LoadFile(string filePath);
    }
}
