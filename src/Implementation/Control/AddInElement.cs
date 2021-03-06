using System.Xml.Linq;

namespace AddinX.Ribbon.Implementation.Control
{
    public abstract class AddInElement
    {
        protected internal string ElementName;

        protected internal abstract XElement ToXml(XNamespace ns);
    }
}