using System;
using IrrKlang;
using ambient.audio.players;

namespace ambient.audio.irrklang
{
    public class IrrklangMusicPlayer : IMusicPlayer
    {
        private ISound internalSound;
        private IrrklangSoundFactory soundFactory;

        public IrrklangMusicPlayer(IrrklangSoundFactory soundFactory)
        {
            this.soundFactory = soundFactory;
        }

        public void Dispose()
        {
            internalSound.Dispose();
        }

        public TimeSpan TotalTime
        {
            get { return TimeSpan.FromMilliseconds(internalSound.PlayLength); }
        }

        public TimeSpan CurrentTime
        {
            get { return TimeSpan.FromMilliseconds(internalSound.PlayPosition); }
            set { internalSound.PlayPosition = Convert.ToUInt32(value.TotalMilliseconds); }
        }

        public bool HasEnded
        {
            get { return internalSound.Finished; }
        }

        public bool IsLooping
        {
            get { return internalSound.Looped; }
            set { internalSound.Looped = value; }
        }

        public float Volume
        {
            get { return internalSound.Volume; }
            set { internalSound.Volume = value; }
        }

        public float Pan
        {
            get { return internalSound.Pan; }
            set { internalSound.Pan = value; }
        }

        public PlaybackState PlaybackState
        {
            get { return GetPlaybackState(); }
        }

        public void Play()
        {
            if(internalSound.Paused)
            { internalSound.Paused = false; }
        }

        public void Pause()
        { internalSound.Paused = true; }

        public void Stop()
        {
            internalSound.Paused = true;
            internalSound.PlayPosition = 0;
        }

        public void LoadFile(string filePath)
        {
            if(internalSound != null)
            {
                internalSound.Stop();
                internalSound.Dispose();
            }
            internalSound = soundFactory.GetSoundForFile(filePath);
        }

        private PlaybackState GetPlaybackState()
        {
            if (internalSound != null)
            {
                if (internalSound.Paused) { return PlaybackState.Paused; }
                if (internalSound.Finished) { return PlaybackState.Stopped; }
                return PlaybackState.Playing;
            }
            return PlaybackState.Idle;
        }
    }
}
