using System.Xml.Linq;
using ambient.audio.io.serializer;
using ambient.audio.models;

namespace ambient.audio.io.export
{
    public class PlaylistConfigurationExporter
    {
        private const string PlaylistConfigurationSelector = "PlaylistConfiguration";
        private const string PlayerConfigurationSelector = "PlayConfigurations";

        private IXmlSerializer<AmbientConfiguration> ambientConfigurationSerializer;
 
        public 

        public XDocument GenerateXml(IPlaylistConfiguration playlist)
        {
            var xmlDocument = new XDocument();
            var playlistElement = new XElement(PlaylistConfigurationSelector);

            var playerElements = new XElement(PlayerConfigurationSelector);
            foreach(var player in playlist.Players)
            {
                var serializedElement = 
                playerElements.Add(player.GenerateXml());
            }
            playlistElement.Add(playerElements);

            var quickSoundStatesElement = new XElement("QuickSoundStates");
            foreach (var quickSoundState in playlist.QuickSoundStates)
            { quickSoundStatesElement.Add(quickSoundState.GenerateXml()); }
            playlistElement.Add(quickSoundStatesElement);

            xmlDocument.Add(playlistElement);
            return xmlDocument;
        }
    }
}