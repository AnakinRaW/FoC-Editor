using System;
using System.IO;
using System.Linq;

namespace ForcesOfCorruptionModdingTool.AlomoEngine.Core.DataTypes
{
    public class HardPointTextureAssociation
    {

        public HardPointTextureAssociation(HardPointType type, string imageName)
        {
            Type = type;
            ImageName = imageName;
        }

        public HardPointType Type { get; set; }

        public string ImageName { get; set; }

        public static HardPointTextureAssociation CreateFromString(string s)
        {
            s = s.Trim();
            var list = s.Split(',').ToList();
            list = list.Select(st => st.Trim()).ToList();
            if (list.Count != 2)
                throw new InvalidDataException();

            HardPointType type;

            if (Enum.TryParse(list[0], true, out type))
                return new HardPointTextureAssociation(type, list[1]);
            throw new InvalidDataException();
        }

        public override string ToString()
        {
            return $"{Type}, {ImageName}";
        }
    }
}
