using System.Collections.Generic;
using System.Linq;


namespace ForcesOfCorruptionModdingTool.EditorCore.Extensions
{
    public static class EnumerableExtensions
    {
        public static IEnumerable<T> Add<T>(this IEnumerable<T> list, T value)
        {
            if (list == null)
                list = new List<T>();
            var newList = list.ToList();
            newList.Add(value);
            return new List<T>(newList);
        }

        public static IEnumerable<T> Delete<T>(this IEnumerable<T> list, T value)
        {
            var l = new List<T>(list);
            l.Remove(value);
            return l;
        }

    }
}
