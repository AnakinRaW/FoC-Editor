using System;
using System.Globalization;
using System.Linq;

namespace ForcesOfCorruptionModdingTool.AlomoEngine.Core.DataTypes
{
    public class EngineFloatTupel
    {
        public EngineFloatTupel(int size)
        {
            if (size <= 0)
                throw new ArgumentOutOfRangeException();
            Size = size;
            Data = new double[size];
        }

        public EngineFloatTupel(int size, params double[] elements) : this(size)
        {
            if (elements.Length != size)
                throw new ArgumentOutOfRangeException();
            Data = elements;
        }

        public double[] Data { get; }

        public int Size { get; }

        public static EngineFloatTupel CreateFromString(string s)
        {
            s = s.Trim();
            var list = s.Split(',').ToList();
            if (list.Count == 0 || list[0] == s)
                list = s.Split(' ').ToList();
            if (list.Count == 0 || list[0] == s)
                list = s.Split('|').ToList();
            if (list.Count <= 0 || list[0] == s)
                throw new FormatException();

            return new EngineFloatTupel(list.Count, list.Select(value => value.ToEngineFloat()).ToArray());
        }

        public override string ToString()
        {
            return ToString(EngineSparators.Comma);
        }

        public string ToString(EngineSparators separator)
        {
            var doubleArray = Data.Select(value => value.ToString(CultureInfo.InvariantCulture)).ToList();

            switch (separator)
            {
                case EngineSparators.Comma:
                    return string.Join(",", doubleArray);
                case EngineSparators.Space:
                    return string.Join(" ", doubleArray);
                case EngineSparators.VerticalLine:
                    return string.Join("|", doubleArray);
                default:
                    throw new ArgumentOutOfRangeException(nameof(separator), separator, null);
            }
        }

    }
}