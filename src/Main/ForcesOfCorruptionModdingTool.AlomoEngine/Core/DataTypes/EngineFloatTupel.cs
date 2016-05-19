using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using ForcesOfCorruptionModdingTool.AlomoEngine.Core.DataTypes.Enums;

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
            var list = s.ToEngineList();
            if (list.Count <= 0)
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