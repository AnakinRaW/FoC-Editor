using System.ComponentModel;
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
    public class GameObjectConstantData : EngineObject
    {
        public GameObjectConstantData(IGameXmlFile parent) : base(parent) {}

        public EngineStringTupel Unit_Command_Rankings_By_Category { get; set; }

        public double Space_Collidable_Grid_Cull_Size { get; set; }
        public double Space_Large_Ship_Grid_Cull_Size { get; set; }
        public double Land_Collidable_Grid_Cull_Size { get; set; }

        [Description("Subjective thresholds for unit health levels - used by game object type SFXEvent triggers")]
        public double Health_Low_Percent_Threshold { get; set; }

        [Description("Subjective thresholds for unit health levels - used by game object type SFXEvent triggers")]
        public double Health_Critical_Percent_Threshold { get; set; }

        public double Under_Construction_Damage_Multiplier { get; set; }

        public EngineFloatTupel Diminishing_Firepower { get; set; }

        public double Ion_Storm_Shield_Disable_Time { get; set; }
        public double Nebula_Ability_Disable_Time { get; set; }
        public double Force_Ability_Disable_Time { get; set; }
        public double Depleted_Shield_Disable_Time { get; set; }
        public double Depleted_Shield_Damage_Increment { get; set; }
        public double Depleted_Shield_Regen_Cap { get; set; }
        public EngineColor Nebula_Effect_Color { get; set; }
        public double Base_Shield_Speed_Modifier { get; set; }
        public double Base_Shield_Vulnerability_Modifier { get; set; }

        public double Planet_Reveal_Delay_Time { get; set; }
        public double Base_Shield_Delay_Time { get; set; }

        public EngineStringTupel Object_Visual_Status_Particle_Attach_Bone_Names { get; set; }

        public ShipNameTextFileList ShipNameTextFiles { get; set; }

        public int Indigenous_Spawn_Destruction_Reward { get; set; }
        public double Space_Guard_Range { get; set; }
        public double Land_Guard_Range { get; set; }

        public double Override_Death_Persistence_Duration { get; set; }


        public override XmlElement Serialize()

        {
            var node = Parent.RootNode;
            node.SetValueOfLastTagOfName(nameof(Unit_Command_Rankings_By_Category), Unit_Command_Rankings_By_Category.ToString());
            node.SetValueOfLastTagOfName(nameof(Space_Collidable_Grid_Cull_Size), Space_Collidable_Grid_Cull_Size.ToString(CultureInfo.InvariantCulture));
            node.SetValueOfLastTagOfName(nameof(Space_Large_Ship_Grid_Cull_Size), Space_Large_Ship_Grid_Cull_Size.ToString(CultureInfo.InvariantCulture));
            node.SetValueOfLastTagOfName(nameof(Land_Collidable_Grid_Cull_Size), Land_Collidable_Grid_Cull_Size.ToString(CultureInfo.InvariantCulture));

            node.SetValueOfLastTagOfName(nameof(Health_Low_Percent_Threshold), Health_Low_Percent_Threshold.ToString(CultureInfo.InvariantCulture));
            node.SetValueOfLastTagOfName(nameof(Health_Critical_Percent_Threshold), Health_Critical_Percent_Threshold.ToString(CultureInfo.InvariantCulture));

            node.SetValueOfLastTagOfName(nameof(Under_Construction_Damage_Multiplier), Under_Construction_Damage_Multiplier.ToString(CultureInfo.InvariantCulture));
            node.SetValueOfLastTagOfName(nameof(Diminishing_Firepower), Diminishing_Firepower.ToString());

            node.SetValueOfLastTagOfName(nameof(Ion_Storm_Shield_Disable_Time), Ion_Storm_Shield_Disable_Time.ToString(CultureInfo.InvariantCulture));
            node.SetValueOfLastTagOfName(nameof(Nebula_Ability_Disable_Time), Nebula_Ability_Disable_Time.ToString(CultureInfo.InvariantCulture));
            node.SetValueOfLastTagOfName(nameof(Force_Ability_Disable_Time), Force_Ability_Disable_Time.ToString(CultureInfo.InvariantCulture));
            node.SetValueOfLastTagOfName(nameof(Depleted_Shield_Disable_Time), Depleted_Shield_Disable_Time.ToString(CultureInfo.InvariantCulture));
            node.SetValueOfLastTagOfName(nameof(Depleted_Shield_Damage_Increment), Depleted_Shield_Damage_Increment.ToString(CultureInfo.InvariantCulture));
            node.SetValueOfLastTagOfName(nameof(Depleted_Shield_Regen_Cap), Depleted_Shield_Regen_Cap.ToString(CultureInfo.InvariantCulture));
            node.SetValueOfLastTagOfName(nameof(Nebula_Effect_Color), Nebula_Effect_Color.ToString());
            node.SetValueOfLastTagOfName(nameof(Base_Shield_Speed_Modifier), Base_Shield_Speed_Modifier.ToString(CultureInfo.InvariantCulture));
            node.SetValueOfLastTagOfName(nameof(Base_Shield_Vulnerability_Modifier), Base_Shield_Vulnerability_Modifier.ToString(CultureInfo.InvariantCulture));

            node.SetValueOfLastTagOfName(nameof(Planet_Reveal_Delay_Time), Planet_Reveal_Delay_Time.ToString(CultureInfo.InvariantCulture));
            node.SetValueOfLastTagOfName(nameof(Base_Shield_Delay_Time), Base_Shield_Delay_Time.ToString(CultureInfo.InvariantCulture));

            node.SetValueOfLastTagOfName(nameof(Object_Visual_Status_Particle_Attach_Bone_Names), Object_Visual_Status_Particle_Attach_Bone_Names.ToString());
            node.SetValueOfLastTagOfName(nameof(ShipNameTextFiles), ShipNameTextFiles.ToString(true));

            node.SetValueOfLastTagOfName(nameof(Indigenous_Spawn_Destruction_Reward), Indigenous_Spawn_Destruction_Reward.ToString());

            node.SetValueOfLastTagOfName(nameof(Space_Guard_Range), Space_Guard_Range.ToString(CultureInfo.InvariantCulture));
            node.SetValueOfLastTagOfName(nameof(Land_Guard_Range), Land_Guard_Range.ToString(CultureInfo.InvariantCulture));

            node.SetValueOfLastTagOfName(nameof(Override_Death_Persistence_Duration), Override_Death_Persistence_Duration.ToString(CultureInfo.InvariantCulture));

            return node;
        }

        public override void Deserialize(XmlElement node)
        {
            Unit_Command_Rankings_By_Category = EngineStringTupel.CreateFromString(node.GetValueOfLastTagOfName(nameof(Unit_Command_Rankings_By_Category)));
            Space_Collidable_Grid_Cull_Size =
                node.GetValueOfLastTagOfName(nameof(Space_Collidable_Grid_Cull_Size)).ToEngineFloat();
            Space_Large_Ship_Grid_Cull_Size =
                node.GetValueOfLastTagOfName(nameof(Space_Large_Ship_Grid_Cull_Size)).ToEngineFloat();
            Land_Collidable_Grid_Cull_Size =
                node.GetValueOfLastTagOfName(nameof(Land_Collidable_Grid_Cull_Size)).ToEngineFloat();

            Health_Low_Percent_Threshold =
                node.GetValueOfLastTagOfName(nameof(Health_Low_Percent_Threshold)).ToEngineFloat();
            Health_Critical_Percent_Threshold =
                node.GetValueOfLastTagOfName(nameof(Health_Critical_Percent_Threshold)).ToEngineFloat();
            Under_Construction_Damage_Multiplier =
                node.GetValueOfLastTagOfName(nameof(Under_Construction_Damage_Multiplier)).ToEngineFloat();

            Diminishing_Firepower = EngineFloatTupel.CreateFromString(node.GetValueOfLastTagOfName(nameof(Diminishing_Firepower)));

            Ion_Storm_Shield_Disable_Time =
                node.GetValueOfLastTagOfName(nameof(Ion_Storm_Shield_Disable_Time)).ToEngineFloat();
            Nebula_Ability_Disable_Time =
                node.GetValueOfLastTagOfName(nameof(Nebula_Ability_Disable_Time)).ToEngineFloat();
            Force_Ability_Disable_Time =
                node.GetValueOfLastTagOfName(nameof(Force_Ability_Disable_Time)).ToEngineFloat();
            Depleted_Shield_Disable_Time =
                node.GetValueOfLastTagOfName(nameof(Depleted_Shield_Disable_Time)).ToEngineFloat();
            Depleted_Shield_Damage_Increment =
                node.GetValueOfLastTagOfName(nameof(Depleted_Shield_Damage_Increment)).ToEngineFloat();
            Depleted_Shield_Regen_Cap =
                node.GetValueOfLastTagOfName(nameof(Depleted_Shield_Regen_Cap)).ToEngineFloat();
            Nebula_Effect_Color = EngineColor.CreateColorFromString(node.GetValueOfLastTagOfName(nameof(Nebula_Effect_Color)));
            Base_Shield_Speed_Modifier =
                node.GetValueOfLastTagOfName(nameof(Base_Shield_Speed_Modifier)).ToEngineFloat();
            Base_Shield_Vulnerability_Modifier =
                node.GetValueOfLastTagOfName(nameof(Base_Shield_Vulnerability_Modifier)).ToEngineFloat();

            Planet_Reveal_Delay_Time =
                node.GetValueOfLastTagOfName(nameof(Planet_Reveal_Delay_Time)).ToEngineFloat();
            Base_Shield_Delay_Time =
                node.GetValueOfLastTagOfName(nameof(Base_Shield_Delay_Time)).ToEngineFloat();

            Object_Visual_Status_Particle_Attach_Bone_Names = EngineStringTupel.CreateFromString(node.GetValueOfLastTagOfName(nameof(Object_Visual_Status_Particle_Attach_Bone_Names)));

            ShipNameTextFiles = ShipNameTextFileList.CreateFromString(node.GetValueOfLastTagOfName(nameof(ShipNameTextFiles)));

            Indigenous_Spawn_Destruction_Reward =
                node.GetValueOfLastTagOfName(nameof(Indigenous_Spawn_Destruction_Reward)).ToInteger();

            Space_Guard_Range =
                node.GetValueOfLastTagOfName(nameof(Space_Guard_Range)).ToEngineFloat();
            Space_Guard_Range =
                node.GetValueOfLastTagOfName(nameof(Space_Guard_Range)).ToEngineFloat();

            Override_Death_Persistence_Duration =
                node.GetValueOfLastTagOfName(nameof(Override_Death_Persistence_Duration)).ToEngineFloat();
        }
    }
}
