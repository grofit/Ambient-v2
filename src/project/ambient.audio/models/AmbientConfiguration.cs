using System;
using System.Xml.Linq;

namespace ambient.audio.models
{
    public class AmbientConfiguration : ISoundConfiguration
    {
        public string PlayerTypeIdentifier
        {
            get { return GetType().ToString(); }
        }

        public int RowPosition { get; set; }
        public int ColumnPosition { get; set; }

        public string Filename { get; set; }
        public int Volume { get; set; }
        public bool isLooping { get; set; }
    }
}