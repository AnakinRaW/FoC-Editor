using System.Diagnostics.CodeAnalysis;
using System.Globalization;
using System.Xml;
using ForcesOfCorruptionModdingTool.AlomoEngine.Core;
using ForcesOfCorruptionModdingTool.AlomoEngine.Core.DataTypes;
using ForcesOfCorruptionModdingTool.AlomoEngine.Interfaces;
using ForcesOfCorruptionModdingTool.AlomoEngine.XmlEngine;

namespace ForcesOfCorruptionModdingTool.AlomoEngine.EngineObjects.GameConstants.Objects
{
    [SuppressMessage("ReSharper", "InconsistentNaming")]
    public class PlanetaryCorruptionConstants : EngineObject
    {
        public PlanetaryCorruptionConstants(IGameXmlFile parent) : base(parent) { }

        public string Corruption_Particle_Name { get; set; }

        public string Corruption_Particle_Line_Name { get; set; }

        public EngineFloatTupel Particle_Brightness_Per_Corruption_Level { get; set; }

        public EngineFloatTupel Particle_Scale_Per_Corruption_Level { get; set; }

        public EngineFloatTupel Particle_Energy_Per_Corruption_Level { get; set; }

        public double Corruption_Line_Radius { get; set; }

        public double Corruption_Line_Start_End_Offset { get; set; }

        public int Corruption_Line_Grow_Seconds { get; set; }

        public EngineColor Corruption_Path_Color { get; set; }

        public int Corruption_Path_Width { get; set; }

        public EngineIntegerTupel Corruption_Path_Offset { get; set; }
        
        public override XmlElement Serialize()
        {
            var node = Parent.RootNode;
            node.SetValueOfLastTagOfName(nameof(Corruption_Particle_Name), Corruption_Particle_Name);
            node.SetValueOfLastTagOfName(nameof(Corruption_Particle_Line_Name), Corruption_Particle_Line_Name);
            node.SetValueOfLastTagOfName(nameof(Particle_Brightness_Per_Corruption_Level), Particle_Brightness_Per_Corruption_Level.ToString());
            node.SetValueOfLastTagOfName(nameof(Particle_Scale_Per_Corruption_Level), Particle_Scale_Per_Corruption_Level.ToString());
            node.SetValueOfLastTagOfName(nameof(Particle_Energy_Per_Corruption_Level), Particle_Energy_Per_Corruption_Level.ToString());
            node.SetValueOfLastTagOfName(nameof(Corruption_Line_Radius), Corruption_Line_Radius.ToString(CultureInfo.InvariantCulture));
            node.SetValueOfLastTagOfName(nameof(Corruption_Line_Start_End_Offset), Corruption_Line_Start_End_Offset.ToString(CultureInfo.InvariantCulture));
            node.SetValueOfLastTagOfName(nameof(Corruption_Line_Grow_Seconds), Corruption_Line_Grow_Seconds.ToString());
            node.SetValueOfLastTagOfName(nameof(Corruption_Path_Color), Corruption_Path_Color.ToString());
            node.SetValueOfLastTagOfName(nameof(Corruption_Path_Width), Corruption_Path_Width.ToString());
            node.SetValueOfLastTagOfName(nameof(Corruption_Path_Offset), Corruption_Path_Offset.ToString());
            return node;
        }

        public override void Deserialize(XmlElement node)
        {
            Corruption_Particle_Name = node.GetValueOfLastTagOfName(nameof(Corruption_Particle_Name));
            Corruption_Particle_Line_Name = node.GetValueOfLastTagOfName(nameof(Corruption_Particle_Line_Name));
            Particle_Brightness_Per_Corruption_Level =
                EngineFloatTupel.CreateFromString(
                    node.GetValueOfLastTagOfName(nameof(Particle_Brightness_Per_Corruption_Level)));
            Particle_Scale_Per_Corruption_Level =
                EngineFloatTupel.CreateFromString(
                    node.GetValueOfLastTagOfName(nameof(Particle_Scale_Per_Corruption_Level)));
            Particle_Energy_Per_Corruption_Level =
                EngineFloatTupel.CreateFromString(
                    node.GetValueOfLastTagOfName(nameof(Particle_Energy_Per_Corruption_Level)));
            Corruption_Line_Radius = node.GetValueOfLastTagOfName(nameof(Corruption_Line_Radius)).ToEngineFloat();
            Corruption_Line_Start_End_Offset = node.GetValueOfLastTagOfName(nameof(Corruption_Line_Start_End_Offset)).ToEngineFloat();
            Corruption_Line_Grow_Seconds = node.GetValueOfLastTagOfName(nameof(Corruption_Line_Grow_Seconds)).ToInteger();
            Corruption_Path_Color = EngineColor.CreateColorFromString(node.GetValueOfLastTagOfName(nameof(Corruption_Path_Color)));
            Corruption_Path_Width = node.GetValueOfLastTagOfName(nameof(Corruption_Path_Width)).ToInteger();
            Corruption_Path_Offset = EngineIntegerTupel.CreateFromString(node.GetValueOfLastTagOfName(nameof(Corruption_Path_Offset)));
        }
    }
}
