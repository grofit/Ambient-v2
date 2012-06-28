using System;
using System.Xml.Linq;

namespace ambient.audio.playlist
{
    public static class PlaylistDataImporter
    {
        public static IPlaylistData GeneratePlaylist(XDocument xmlDocument)
        {
            var completeState = new PlaylistData();
            var rootElement = xmlDocument.Element("CompleteState");

            if(rootElement == null)
            { throw new Exception("Error parsing Xml, there is no root node"); }

            var soundStateNodes = rootElement.Elements("Players");
            foreach (var ambientStateNode in soundStateNodes.Elements("SoundState"))
            {
                var soundTypeAttribute = ambientStateNode.Attribute("PlayerTypeIdentifier");
                var soundState = PlayerTypeFactory.GetEntityForType(soundTypeAttribute.Value);
                soundState.PopulateFromXml(ambientStateNode);
                completeState.SoundStates.Add(soundState);
            }

            var quickSoundStateNodes = rootElement.Elements("QuickSoundStates");
            foreach (var quickSoundStateNode in quickSoundStateNodes.Elements("SoundState"))
            {
                var soundTypeAttribute = quickSoundStateNode.Attribute("PlayerTypeIdentifier");
                var soundState = PlayerTypeFactory.GetEntityForType(soundTypeAttribute.Value);
                soundState.PopulateFromXml(quickSoundStateNode);
                completeState.QuickSoundStates.Add(soundState);
            }

            return completeState;
        }
    }
}
