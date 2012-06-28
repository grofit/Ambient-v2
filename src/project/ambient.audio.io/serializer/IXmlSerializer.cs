using System.Xml.Linq;

namespace ambient.audio.io.serializer
{
    public interface IXmlSerializer<T>
    {
        T FromXml(XElement xmlDocument);
        XElement ToXml(T model);
    }
}