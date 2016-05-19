using System;
using System.Globalization;
using System.Linq;
using ForcesOfCorruptionModdingTool.AlomoEngine.Core.DataTypes.Enums;

namespace ForcesOfCorruptionModdingTool.AlomoEngine.Core.DataTypes
{
    public class EngineStringTupel
    {
        public EngineStringTupel(int size)
        {
            if (size <= 0)
                throw new ArgumentOutOfRangeException();
            Size = size;
            Data = new string[size];
        }

        public EngineStringTupel(int size, params string[] elements) : this(size)
        {
            if (elements.Length != size)
                throw new ArgumentOutOfRangeException();
            Data = elements;
        }

        public string[] Data { get; set; }

        public int Size { get; }

        public static EngineStringTupel CreateFromString(string s)
        {
            var list = s.ToEngineList();
            if (list.Count <= 0)
                throw new FormatException();

            return new EngineStringTupel(list.Count, list.ToArray());
        }

        public override string ToString()
        {
            return ToString(EngineSparators.Comma);
        }

        public string ToString(EngineSparators separator, bool forceNewLine = false)
        {
            var intArray = Data.Select(value => value.ToString(CultureInfo.InvariantCulture)).ToList();
            if (!forceNewLine)
            {
                switch (separator)
                {
                    case EngineSparators.Comma:
                        return string.Join(",", intArray);
                    case EngineSparators.Space:
                        return string.Join(" ", intArray);
                    case EngineSparators.VerticalLine:
                        return string.Join("|", intArray);
                    default:
                        throw new ArgumentOutOfRangeException(nameof(separator), separator, null);
                }
            }
            switch (separator)
            {
                case EngineSparators.Comma:
                    return string.Join(",\r\n", intArray);
                case EngineSparators.Space:
                    return string.Join(" \r\n", intArray);
                case EngineSparators.VerticalLine:
                    return string.Join("|\r\n", intArray);
                default:
                    throw new ArgumentOutOfRangeException(nameof(separator), separator, null);
            }
        }
    }
}