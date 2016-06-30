using System.Diagnostics.CodeAnalysis;
using System.Globalization;
using System.Xml;
using AlomoEngine;
using AlomoEngine.Core.Interfaces;
using AlomoEngine.Xml;
using AlomoEngine.Xml.DataTypes;

namespace ForcesOfCorruptionEnvironment.Objects.GameConstants.Behaviour
{
    [SuppressMessage("ReSharper", "InconsistentNaming")]
    public class AbilityEffectData : XmlTagCategory
    {
        public AbilityEffectData(IAlomoXmlFile file) : base(file) {}

        public double Telekinesis_Hover_Height { get; set; }
        public double Telekinesis_Transition_Time { get; set; }
        public double Telekinesis_Wobble_Cycle_Time { get; set; }
        public double Telekinesis_Wobble_Fade_Time { get; set; }
        public double Telekinesis_Max_Wobble_Angle { get; set; }
        public double Telekinesis_Max_Bob_Height { get; set; }
        public double Earthquake_Transition_Time { get; set; }
        public double Earthquake_Shake_Speed { get; set; }
        public EngineFloatTupel Earthquake_Shake_Magnitude { get; set; }

        public string Sabotage_Particle_Effect { get; set; }
        public string Hack_Super_Weapon_Particle_Effect { get; set; }
        public EngineStringTupel Hack_Super_Weapon_Required_Type { get; set; }

        public int Hack_Super_Weapon_Cost { get; set; }

        public override XmlElement Serialize()
        {
            var node = File.RootNode;
            node.SetValueOfLastTagOfName(nameof(Telekinesis_Hover_Height), Telekinesis_Hover_Height.ToString(CultureInfo.InvariantCulture));
            node.SetValueOfLastTagOfName(nameof(Telekinesis_Transition_Time), Telekinesis_Transition_Time.ToString(CultureInfo.InvariantCulture));
            node.SetValueOfLastTagOfName(nameof(Telekinesis_Wobble_Cycle_Time), Telekinesis_Wobble_Cycle_Time.ToString(CultureInfo.InvariantCulture));
            node.SetValueOfLastTagOfName(nameof(Telekinesis_Wobble_Fade_Time), Telekinesis_Wobble_Fade_Time.ToString(CultureInfo.InvariantCulture));
            node.SetValueOfLastTagOfName(nameof(Telekinesis_Max_Wobble_Angle), Telekinesis_Max_Wobble_Angle.ToString(CultureInfo.InvariantCulture));
            node.SetValueOfLastTagOfName(nameof(Telekinesis_Max_Bob_Height), Telekinesis_Max_Bob_Height.ToString(CultureInfo.InvariantCulture));
            node.SetValueOfLastTagOfName(nameof(Earthquake_Transition_Time), Earthquake_Transition_Time.ToString(CultureInfo.InvariantCulture));
            node.SetValueOfLastTagOfName(nameof(Earthquake_Shake_Speed), Earthquake_Shake_Speed.ToString(CultureInfo.InvariantCulture));
            node.SetValueOfLastTagOfName(nameof(Earthquake_Shake_Magnitude), Earthquake_Shake_Magnitude.ToString());
            node.SetValueOfLastTagOfName(nameof(Sabotage_Particle_Effect), Sabotage_Particle_Effect);
            node.SetValueOfLastTagOfName(nameof(Hack_Super_Weapon_Particle_Effect), Hack_Super_Weapon_Particle_Effect);
            node.SetValueOfLastTagOfName(nameof(Hack_Super_Weapon_Required_Type), Hack_Super_Weapon_Required_Type.ToString());
            node.SetValueOfLastTagOfName(nameof(Hack_Super_Weapon_Cost), Hack_Super_Weapon_Cost.ToString());
            return node;
        }

        public override void Deserialize(XmlElement node)
        {
            Telekinesis_Hover_Height = node.GetValueOfLastTagOfName(nameof(Telekinesis_Hover_Height)).ToEngineFloat();
            Telekinesis_Transition_Time = node.GetValueOfLastTagOfName(nameof(Telekinesis_Transition_Time)).ToEngineFloat();
            Telekinesis_Wobble_Cycle_Time = node.GetValueOfLastTagOfName(nameof(Telekinesis_Wobble_Cycle_Time)).ToEngineFloat();
            Telekinesis_Wobble_Fade_Time = node.GetValueOfLastTagOfName(nameof(Telekinesis_Wobble_Fade_Time)).ToEngineFloat();
            Telekinesis_Max_Wobble_Angle = node.GetValueOfLastTagOfName(nameof(Telekinesis_Max_Wobble_Angle)).ToEngineFloat();
            Telekinesis_Max_Bob_Height = node.GetValueOfLastTagOfName(nameof(Telekinesis_Max_Bob_Height)).ToEngineFloat();
            Earthquake_Transition_Time = node.GetValueOfLastTagOfName(nameof(Earthquake_Transition_Time)).ToEngineFloat();
            Earthquake_Shake_Speed = node.GetValueOfLastTagOfName(nameof(Earthquake_Shake_Speed)).ToEngineFloat();
            Earthquake_Shake_Magnitude = EngineFloatTupel.CreateFromString(node.GetValueOfLastTagOfName(nameof(Earthquake_Shake_Magnitude)));
            Sabotage_Particle_Effect = node.GetValueOfLastTagOfName(nameof(Sabotage_Particle_Effect));
            Hack_Super_Weapon_Particle_Effect = node.GetValueOfLastTagOfName(nameof(Hack_Super_Weapon_Particle_Effect));
            Hack_Super_Weapon_Required_Type = EngineStringTupel.CreateFromString(node.GetValueOfLastTagOfName(nameof(Earthquake_Shake_Speed)));
            Hack_Super_Weapon_Cost = node.GetValueOfLastTagOfName(nameof(Hack_Super_Weapon_Cost)).ToInteger();
        }
    }
}
