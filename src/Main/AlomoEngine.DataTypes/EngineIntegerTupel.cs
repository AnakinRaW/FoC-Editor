using System;
using System.Globalization;
using System.Linq;
using AlomoEngine.Core;
using AlomoEngine.DataTypes.Enums;

namespace AlomoEngine.DataTypes
{
    public class EngineIntegerTupel
    {
        public EngineIntegerTupel(int size)
        {
            if (size <= 0)
                throw new ArgumentOutOfRangeException();
            Size = size;
            Data = new int[size];
        }

        public EngineIntegerTupel(int size, params int[] elements) : this(size)
        {
            if (elements.Length != size)
                throw new ArgumentOutOfRangeException();
            Data = elements;
        }

        public int[] Data { get; }

        public int Size { get; }

        public static EngineIntegerTupel CreateFromString(string s)
        {
            var list = s.ToEngineList();
            if (list.Count <= 0)
                throw new FormatException();

            return new EngineIntegerTupel(list.Count, list.Select(value => value.ToInteger()).ToArray());
        }

        public override string ToString()
        {
            return ToString(EngineSparators.Comma);
        }

        public string ToString(EngineSparators separator)
        {
            var intArray = Data.Select(value => value.ToString(CultureInfo.InvariantCulture)).ToList();

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

    }
}