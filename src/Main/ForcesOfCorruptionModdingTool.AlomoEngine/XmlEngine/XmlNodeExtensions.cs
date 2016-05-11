using System.Xml;

namespace ForcesOfCorruptionModdingTool.AlomoEngine.XmlEngine
{
    public static class XmlNodeExtensions
    {
        public static string GetCommentsInElementRange(this XmlNode node, string fromElementName, string toElementName)
        {
            var comment = string.Empty;
            var reached = false;
            foreach (XmlNode child in node.ChildNodes)
            {
                if (fromElementName != null &&  child.Name != nameof(fromElementName) && !reached)
                    continue;
                reached = true;
                if (child.NodeType == XmlNodeType.Comment)
                    comment += child.InnerText;
                if (child.Name == nameof(toElementName))
                    break;
            }
            return comment;
        }
    }
}
