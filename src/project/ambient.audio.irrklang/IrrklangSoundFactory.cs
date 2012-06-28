using System.IO;
using IrrKlang;

namespace ambient.audio.irrklang
{
    public class IrrklangSoundFactory
    {
        public ISoundEngine soundEngine;

        public IrrklangSoundFactory(ISoundEngine soundEngine)
        {
            this.soundEngine = soundEngine;
        }

        public ISound GetSoundForFile(string filePath)
        {
            if (!File.Exists(filePath))
            { throw new FileNotFoundException("Unable to locate file", filePath); }

            return soundEngine.Play2D(filePath, false, true);
        }
    }
}