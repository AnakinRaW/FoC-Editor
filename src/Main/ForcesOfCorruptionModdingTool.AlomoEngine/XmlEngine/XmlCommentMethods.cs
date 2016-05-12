using System.Collections.Generic;
using System.Xml;

namespace ForcesOfCorruptionModdingTool.AlomoEngine.XmlEngine
{
    public static class XmlCommentMethods
    {
        public static string GetCommentsInElementRange(this XmlElement node, string fromElementName, string toElementName)
        {
            var comment = string.Empty;
            var reached = false;
            foreach (XmlNode child in node.ChildNodes)
            {
                if (fromElementName != null && child.Name != nameof(fromElementName) && !reached)
                    continue;
                reached = true;

                if (child.NodeType == XmlNodeType.Comment)
                    comment += child.InnerText;
                if (child.Name == nameof(toElementName))
                    break;
            }
            return comment;
        }

        public static string GetCommentOverElement(this XmlElement node, string name)
        {
            var list = new List<string>();
            var element = node.GetElementsByTagName(name).First();

            while (element.PreviousSibling?.NodeType == XmlNodeType.Comment)
            {
                list.Add(element.PreviousSibling?.InnerText);
                element = element.PreviousSibling;
            }
            list.Reverse();

            var comment = string.Join("\r\n", list);

            return comment;
        }

        public static string GetCommentsOverElements(this XmlElement node, string from, string to)
        {
            var element = node.GetElementsByTagName(from).First();
            var comment = string.Empty;
            while (element?.Name != to)
            {
                if (element?.NodeType != XmlNodeType.Comment)
                    comment += "@\r\n" + node.GetCommentOverElement(element?.Name);
                element = element?.NextSibling;
            }
            return comment;
        }
    }
}
