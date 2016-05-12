using System;
using System.Collections.Generic;
using System.Linq;
using System.Xml;

namespace ForcesOfCorruptionModdingTool.AlomoEngine.XmlEngine
{
    public static class XmlMethodes
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

        public static XmlNode Last(this XmlNodeList list)
        {
            var count = list.Count - 1;
            if (count < 0)
                throw new IndexOutOfRangeException();
            if (list.Item(count) == null)
                throw new ArgumentOutOfRangeException();
            return list.Item(count);
        }

        public static XmlElement CreatElement(string name, string value)
        {
            return null;
        }

        public static List<string> GetValuesByTagName(this XmlElement node, string name)
        {
            var elements = node.GetElementsByTagName(name);
            return (from XmlNode element in elements select element.InnerText).ToList();
        }

        public static void AddMultipleTagsFromValueList(this XmlElement node,string name ,List<string> list)
        {
            var xmlCount = node.GetElementsByTagName(name).Count;
            var listCount = list.Count;

            if (listCount == xmlCount)
            {
                var elements = node.GetElementsByTagName(name);
                for (var i = 0; i < xmlCount; ++i)
                    elements[i].InnerText = list[i];
            }
            else if (listCount > xmlCount)
            {
                var elements = node.GetElementsByTagName(name);
                var i = 0;
                for (; i < xmlCount; ++i)
                    elements[i].InnerText = list[i];

                for (; i < list.Count; i++)
                {
                    var el = node.OwnerDocument?.CreateElement(name);
                    if (el == null)
                        continue;
                    el.InnerText = list[i];
                    node.InsertAfter(el, node.GetElementsByTagName(name).Last());
                }
            }
            else if (listCount < xmlCount)
            {
                var elements = node.GetElementsByTagName(name);

                //Needs to create a dummy to know where to add tags again
                var dummy = node.OwnerDocument?.CreateElement(name);
                if (dummy == null)
                    throw new NullReferenceException();
                dummy.InnerText = string.Empty;
                node.InsertAfter(dummy, node.GetElementsByTagName(name).Last());

                for (var i = 0; i < xmlCount; ++i)
                    node.RemoveChild(elements[0]);

                for (var i = 0; i < listCount; i++)
                {
                    var el = node.OwnerDocument?.CreateElement(name);
                    if (el == null)
                        continue;
                    el.InnerText = list[i];
                    node.InsertBefore(el, node.GetElementsByTagName(name).Last());
                }

                //Destroy the dummy
                node.RemoveChild(dummy);
            }
        }
    }
}
