using System.IO;
using System.Linq;

namespace AlomoEngine.DataTypes.AssociationTypes
{
    public class BountyCategoryAwardAssociation
    {

        public BountyCategoryAwardAssociation(string category, int award)
        {
            Category = category;
            Award = award;
        }

        public string Category { get; set; }

        public int Award { get; set; }

        public static BountyCategoryAwardAssociation CreateFromString(string s)
        {
            s = s.Trim();
            var list = s.Split(',').ToList();
            list = list.Select(st => st.Trim()).ToList();
            if (list.Count != 2)
                throw new InvalidDataException();

            return new BountyCategoryAwardAssociation(list[0], list[1].ToInteger());
        }

        public override string ToString()
        {
            return $"{Category}, {Award}";
        }
    }
}
