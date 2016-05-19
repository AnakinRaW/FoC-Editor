using System.Collections.Generic;
using System.Linq;

namespace ForcesOfCorruptionModdingTool.AlomoEngine.Core.DataTypes
{
    public class ShipNameTextFileList
    {

        public ShipNameTextFileList(List<KeyValuePair<string, string>> fileTable)
        {
            Table = fileTable;
        }

        public List<KeyValuePair<string, string>> Table { get; set; }

        public static ShipNameTextFileList CreateFromString(string s)
        {
            var i = s.InGroupsOfTwo();

            return new ShipNameTextFileList(i);
        }

        public override string ToString()
        {
            var result = string.Empty;
            foreach (var pair in Table)
                result = result + $"{pair.Key}, {pair.Value}, ";
            result = result.Remove(result.Length - 2, 2);
            return result;
        }

        public string ToString(bool forceNewLine)
        {
            if (!forceNewLine)
                return ToString();
            var result = Table.Aggregate("\r\n", (current, pair) => current + $"\t{pair.Key}, {pair.Value},\r\n");
            result = result.Remove(result.Length - 3,1);
            return result;
        }
    }
}
