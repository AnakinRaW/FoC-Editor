using System.IO;
using System.Linq;

namespace ForcesOfCorruptionEnvironment.DataTypes.AssociationTypes
{
    public class LanguageTextureAssociation
    {

        public LanguageTextureAssociation(string lanauge, string texture)
        {
            Lanauge = lanauge;
            Texture = texture;
        }

        public string Lanauge { get; set; }

        public string Texture { get; set; }

        public static LanguageTextureAssociation CreateFromString(string s)
        {
            s = s.Trim();
            var list = s.Split(',').ToList();
            list = list.Select(st => st.Trim()).ToList();
            if (list.Count != 2)
                throw new InvalidDataException();

            return new LanguageTextureAssociation(list[0], list[1]);
        }

        public override string ToString()
        {
            return $"{Lanauge}, {Texture}";
        }
    }
}
