using IrrKlang;
using ambient.audio.players;

namespace ambient.audio.irrklang
{
    public class IrrklangSoundPlayer : ISoundPlayer
    {
        private ISound internalSound;
        private IrrklangSoundFactory soundFactory;

        public IrrklangSoundPlayer(IrrklangSoundFactory soundFactory)
        {
            this.soundFactory = soundFactory;
        }

        public void Dispose()
        {
            internalSound.Dispose();
        }

        public PlaybackState PlaybackState
        {
            get { return GetPlaybackState(); }
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

        public void Play()
        {
            if(internalSound.Paused)
            { internalSound.Paused = false; }
        }

        public void Stop()
        {
            internalSound.PlayPosition = 0;
            internalSound.Paused = true;
        }

        public void LoadFile(string filePath)
        {
            if (internalSound != null)
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