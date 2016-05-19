using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text.RegularExpressions;
using ForcesOfCorruptionModdingTool.AlomoEngine.Core.DataTypes;

namespace ForcesOfCorruptionModdingTool.AlomoEngine.Core
{
    public static class StringExtensions
    {
        public static Stream ToStream(this string @this)
        {
            var stream = new MemoryStream();
            var writer = new StreamWriter(stream);
            writer.Write(@this);
            writer.Flush();
            stream.Position = 0;
            return stream;
        }

        public static List<string> ToEngineList(this string s)
        {
            s = s.Trim();
            s = Regex.Replace(s, @"\t|\n|\r", "");

            if (s.EndsWith(",") || s.EndsWith("|"))
                s = s.Remove(s.Length - 1);

            List<string> list;
            if (s.Contains(","))
                list = s.Split(',').ToList();
            else if (s.Contains("|"))
                list = s.Split('|').ToList();
            else
                list = s.Split(' ').ToList();

            return list.Select(val => val.Trim()).ToList();

        }

        public static List<KeyValuePair<string, string>> InGroupsOfTwo(this string s)
        {
            s = s.Trim();
            s = Regex.Replace(s, @"\t|\n|\r", "");
            if (s.EndsWith(","))
                s = s.Remove(s.Length - 1);
            var d = s.Split(',');
            d = d.Where((x, i) => i % 2 == 0)
                           .Zip(d.Where((x, i) => i % 2 == 1), (a, b) => a + "," + b)
                           .ToArray();
            return (from pair in d
                    select pair.Split(',').ToList()
                    into list1
                    where list1.Count == 2
                    select new KeyValuePair<string, string>(list1[0].Trim(), list1[1].Trim())).ToList();
        }
    }
}
