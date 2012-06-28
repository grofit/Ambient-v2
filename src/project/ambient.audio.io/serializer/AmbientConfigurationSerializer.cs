using System;
using System.Xml.Linq;
using ambient.audio.models;

namespace ambient.audio.io.serializer
{
    public class AmbientConfigurationSerializer : IXmlSerializer<AmbientConfiguration>
    {
        private const string ElementSelector = "SoundConfiguration";
        private const string PlayerTypeIdentifierSelector = "PlayerTypeIdentifier";
        private const string RowPositionSelector = "RowPosition";
        private const string ColumnPositionSelector = "ColumnPosition";
        private const string FilenameSelector = "Filename";
        private const string VolumeSelector = "Volume";
        private const string IsLoopingSelector = "isLooping";

        public AmbientConfiguration FromXml(XElement element)
        {
            var configuration = new AmbientConfiguration();
            configuration.RowPosition = Convert.ToInt32(element.Attribute(RowPositionSelector).Value);
            configuration.ColumnPosition = Convert.ToInt32(element.Attribute(ColumnPositionSelector).Value);
            configuration.Filename = element.Attribute(FilenameSelector).Value;
            configuration.Volume = Convert.ToInt32(element.Attribute(VolumeSelector).Value);
            configuration.isLooping = Convert.ToBoolean(element.Attribute(IsLoopingSelector).Value);
            return configuration;
        }

        public XElement ToXml(AmbientConfiguration model)
        {
            var xmlElement = new XElement(ElementSelector);
            xmlElement.Add(new XAttribute(PlayerTypeIdentifierSelector, model.PlayerTypeIdentifier));
            xmlElement.Add(new XAttribute(RowPositionSelector, model.RowPosition.ToString()));
            xmlElement.Add(new XAttribute(ColumnPositionSelector, model.ColumnPosition.ToString()));
            xmlElement.Add(new XAttribute(VolumeSelector, model.Volume.ToString()));
            xmlElement.Add(new XAttribute(FilenameSelector, model.Filename));
            xmlElement.Add(new XAttribute(IsLoopingSelector, model.isLooping.ToString()));
            return xmlElement;
        }
    }
}