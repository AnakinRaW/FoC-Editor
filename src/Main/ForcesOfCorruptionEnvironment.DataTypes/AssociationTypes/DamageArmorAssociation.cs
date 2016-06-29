using System.Globalization;
using System.IO;
using System.Linq;
using AlomoEngine.Xml.DataTypes;

namespace ForcesOfCorruptionEnvironment.DataTypes.AssociationTypes
{
    public class DamageArmorAssociation
    {

        public DamageArmorAssociation(string damage, string armor, double value)
        {
            Damage = damage;
            Armor = armor;
            Value = value;
        }

        public string Damage { get; set; }

        public string Armor { get; set; }

        public double Value { get; set; }

        public static DamageArmorAssociation CreateFromString(string s)
        {
            s = s.Trim();
            var list = s.Split(',').ToList();
            list = list.Select(st => st.Trim()).ToList();
            if (list.Count != 3)
                throw new InvalidDataException();

            var d = list[0];
            var a = list[1];
            var v = list[2].ToEngineFloat();

            return new DamageArmorAssociation(d,a,v);
        }

        public override string ToString()
        {
            return $"{Damage}, {Armor}, {Value.ToString(CultureInfo.InvariantCulture)}";
        }
    }
}
