using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;

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
            List<string> list;
            if (s.Contains(","))
                list = s.Split(',').ToList();
            else if (s.Contains("|"))
                list = s.Split('|').ToList();
            else
                list = s.Split(' ').ToList();
            return list;
        }
    }
}
