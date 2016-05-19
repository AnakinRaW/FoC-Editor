using System.ComponentModel;
using System.Diagnostics.CodeAnalysis;
using System.Globalization;
using System.Xml;
using ForcesOfCorruptionModdingTool.AlomoEngine.Core;
using ForcesOfCorruptionModdingTool.AlomoEngine.Core.DataTypes;
using ForcesOfCorruptionModdingTool.AlomoEngine.Interfaces;
using ForcesOfCorruptionModdingTool.AlomoEngine.XmlEngine;

namespace ForcesOfCorruptionModdingTool.AlomoEngine.EngineObjects.GameConstants.Behaviour
{
    [SuppressMessage("ReSharper", "InconsistentNaming")]
    public class GalacticEconomyData : EngineObject
    {
        public GalacticEconomyData(IGameXmlFile parent) : base(parent) {}

        public bool Pay_As_You_Go { get; set; }

        public EngineFloatTupel Political_Income_Curve { get; set; }

        public EngineFloatTupel Progressive_Taxation { get; set; }

        public double Income_Redistribution { get; set; }

        [Description("No player can ever accumulate more than this number of credits times the number of planets he controls.")]
        public int Credit_Cap_Per_Planet { get; set; }

        [Description("In tactical multiplayer games, the team with the lower total credit income will share a 'bonus' amount of credits every tick based on the difference in total credit income between the two teams times this percentage multiplier")]
        public double Multiplayer_Losing_Team_Bonus_Credit_Percentage { get; set; }

        public int Fiscal_Cycle_Time_In_Secs { get; set; }

        public int Medium_Coin_Stack_Size { get; set; }

        public int Large_Coin_Stack_Size { get; set; }

        public double Black_Market_Income_Mult_Min { get; set; }

        public double Black_Market_Income_Mult_Max { get; set; }

        public int Num_Structures_For_Medium_Planet_Name { get; set; }

        public int Num_Structures_For_Large_Planet_Name { get; set; }

        public int MaximumPoliticalControl { get; set; }

        public int MaximumStarbaseLevel { get; set; }

        public int MaximumGroundbaseLevel { get; set; }

        public int MaximumSpecialStructures { get; set; }

        public int MaximumSpecialStructuresLand { get; set; }

        public int MaximumSpecialStructuresSpace { get; set; }

        public double MaximumFleetMovementDistance { get; set; }

        public double TradeRouteMovementFactor { get; set; }

        public double Production_Speed_Mod_Base_Vs_Tech_0 { get; set; }
        public double Production_Speed_Mod_Base_Vs_Tech_1 { get; set; }
        public double Production_Speed_Mod_Base_Vs_Tech_2 { get; set; }
        public double Production_Speed_Mod_Base_Vs_Tech_3 { get; set; }
        public double Production_Speed_Mod_Base_Vs_Tech_4 { get; set; }

        public override XmlElement Serialize()
        {
            var node = Parent.RootNode;
            node.SetValueOfLastTagOfName(nameof(Pay_As_You_Go), Pay_As_You_Go.ToString());
            node.SetValueOfLastTagOfName(nameof(Political_Income_Curve), Political_Income_Curve.ToString());
            node.SetValueOfLastTagOfName(nameof(Progressive_Taxation), Progressive_Taxation.ToString());
            node.SetValueOfLastTagOfName(nameof(Income_Redistribution), Income_Redistribution.ToString(CultureInfo.InvariantCulture));
            node.SetValueOfLastTagOfName(nameof(Credit_Cap_Per_Planet), Credit_Cap_Per_Planet.ToString());
            node.SetValueOfLastTagOfName(nameof(Multiplayer_Losing_Team_Bonus_Credit_Percentage), Multiplayer_Losing_Team_Bonus_Credit_Percentage.ToString(CultureInfo.InvariantCulture));
            node.SetValueOfLastTagOfName(nameof(Fiscal_Cycle_Time_In_Secs), Fiscal_Cycle_Time_In_Secs.ToString());
            node.SetValueOfLastTagOfName(nameof(Medium_Coin_Stack_Size), Medium_Coin_Stack_Size.ToString());
            node.SetValueOfLastTagOfName(nameof(Large_Coin_Stack_Size), Large_Coin_Stack_Size.ToString());
            node.SetValueOfLastTagOfName(nameof(Black_Market_Income_Mult_Min), Black_Market_Income_Mult_Min.ToString(CultureInfo.InvariantCulture));
            node.SetValueOfLastTagOfName(nameof(Black_Market_Income_Mult_Min), Black_Market_Income_Mult_Min.ToString(CultureInfo.InvariantCulture));
            node.SetValueOfLastTagOfName(nameof(Black_Market_Income_Mult_Max), Black_Market_Income_Mult_Max.ToString(CultureInfo.InvariantCulture));
            node.SetValueOfLastTagOfName(nameof(Num_Structures_For_Medium_Planet_Name), Num_Structures_For_Medium_Planet_Name.ToString());
            node.SetValueOfLastTagOfName(nameof(Num_Structures_For_Large_Planet_Name), Num_Structures_For_Large_Planet_Name.ToString());

            node.SetValueOfLastTagOfName(nameof(MaximumPoliticalControl), MaximumPoliticalControl.ToString());
            node.SetValueOfLastTagOfName(nameof(MaximumStarbaseLevel), MaximumStarbaseLevel.ToString());
            node.SetValueOfLastTagOfName(nameof(MaximumGroundbaseLevel), MaximumGroundbaseLevel.ToString());
            node.SetValueOfLastTagOfName(nameof(MaximumSpecialStructures), MaximumSpecialStructures.ToString());
            node.SetValueOfLastTagOfName(nameof(MaximumSpecialStructuresLand), MaximumSpecialStructuresLand.ToString());
            node.SetValueOfLastTagOfName(nameof(MaximumSpecialStructuresSpace), MaximumSpecialStructuresSpace.ToString());
            node.SetValueOfLastTagOfName(nameof(MaximumFleetMovementDistance), MaximumFleetMovementDistance.ToString(CultureInfo.InvariantCulture));
            node.SetValueOfLastTagOfName(nameof(TradeRouteMovementFactor), TradeRouteMovementFactor.ToString(CultureInfo.InvariantCulture));

            node.SetValueOfLastTagOfName(nameof(Production_Speed_Mod_Base_Vs_Tech_0), Production_Speed_Mod_Base_Vs_Tech_0.ToString(CultureInfo.InvariantCulture));
            node.SetValueOfLastTagOfName(nameof(Production_Speed_Mod_Base_Vs_Tech_1), Production_Speed_Mod_Base_Vs_Tech_1.ToString(CultureInfo.InvariantCulture));
            node.SetValueOfLastTagOfName(nameof(Production_Speed_Mod_Base_Vs_Tech_2), Production_Speed_Mod_Base_Vs_Tech_2.ToString(CultureInfo.InvariantCulture));
            node.SetValueOfLastTagOfName(nameof(Production_Speed_Mod_Base_Vs_Tech_3), Production_Speed_Mod_Base_Vs_Tech_3.ToString(CultureInfo.InvariantCulture));
            node.SetValueOfLastTagOfName(nameof(Production_Speed_Mod_Base_Vs_Tech_4), Production_Speed_Mod_Base_Vs_Tech_4.ToString(CultureInfo.InvariantCulture));
            return node;
        }

        public override void Deserialize(XmlElement node)
        {
            Pay_As_You_Go = node.GetValueOfLastTagOfName(nameof(Pay_As_You_Go)).ToEngineBoolean();
            Political_Income_Curve = EngineFloatTupel.CreateFromString(node.GetValueOfLastTagOfName(nameof(Political_Income_Curve)));
            Progressive_Taxation = EngineFloatTupel.CreateFromString(node.GetValueOfLastTagOfName(nameof(Progressive_Taxation)));
            Income_Redistribution = node.GetValueOfLastTagOfName(nameof(Income_Redistribution)).ToEngineFloat();

            Credit_Cap_Per_Planet = node.GetValueOfLastTagOfName(nameof(Credit_Cap_Per_Planet)).ToInteger();

            Multiplayer_Losing_Team_Bonus_Credit_Percentage =
                node.GetValueOfLastTagOfName(nameof(Multiplayer_Losing_Team_Bonus_Credit_Percentage)).ToEngineFloat();


            Fiscal_Cycle_Time_In_Secs = node.GetValueOfLastTagOfName(nameof(Fiscal_Cycle_Time_In_Secs)).ToInteger();
            Medium_Coin_Stack_Size = node.GetValueOfLastTagOfName(nameof(Medium_Coin_Stack_Size)).ToInteger();
            Large_Coin_Stack_Size = node.GetValueOfLastTagOfName(nameof(Large_Coin_Stack_Size)).ToInteger();
            Black_Market_Income_Mult_Min =
                node.GetValueOfLastTagOfName(nameof(Black_Market_Income_Mult_Min)).ToEngineFloat();
            Black_Market_Income_Mult_Max =
                node.GetValueOfLastTagOfName(nameof(Black_Market_Income_Mult_Max)).ToEngineFloat();

            Num_Structures_For_Medium_Planet_Name = node.GetValueOfLastTagOfName(nameof(Num_Structures_For_Medium_Planet_Name)).ToInteger();
            Num_Structures_For_Large_Planet_Name = node.GetValueOfLastTagOfName(nameof(Num_Structures_For_Large_Planet_Name)).ToInteger();

            MaximumPoliticalControl = node.GetValueOfLastTagOfName(nameof(MaximumPoliticalControl)).ToInteger();
            MaximumStarbaseLevel = node.GetValueOfLastTagOfName(nameof(MaximumStarbaseLevel)).ToInteger();
            MaximumGroundbaseLevel = node.GetValueOfLastTagOfName(nameof(MaximumGroundbaseLevel)).ToInteger();
            MaximumSpecialStructures = node.GetValueOfLastTagOfName(nameof(MaximumSpecialStructures)).ToInteger();
            MaximumSpecialStructuresLand = node.GetValueOfLastTagOfName(nameof(MaximumSpecialStructuresLand)).ToInteger();
            MaximumSpecialStructuresSpace = node.GetValueOfLastTagOfName(nameof(MaximumSpecialStructuresSpace)).ToInteger();
            MaximumFleetMovementDistance = node.GetValueOfLastTagOfName(nameof(MaximumFleetMovementDistance)).ToEngineFloat();
            TradeRouteMovementFactor = node.GetValueOfLastTagOfName(nameof(TradeRouteMovementFactor)).ToEngineFloat();

            Production_Speed_Mod_Base_Vs_Tech_0 = node.GetValueOfLastTagOfName(nameof(Production_Speed_Mod_Base_Vs_Tech_0)).ToEngineFloat();
            Production_Speed_Mod_Base_Vs_Tech_1 = node.GetValueOfLastTagOfName(nameof(Production_Speed_Mod_Base_Vs_Tech_1)).ToEngineFloat();
            Production_Speed_Mod_Base_Vs_Tech_2 = node.GetValueOfLastTagOfName(nameof(Production_Speed_Mod_Base_Vs_Tech_2)).ToEngineFloat();
            Production_Speed_Mod_Base_Vs_Tech_3 = node.GetValueOfLastTagOfName(nameof(Production_Speed_Mod_Base_Vs_Tech_3)).ToEngineFloat();
            Production_Speed_Mod_Base_Vs_Tech_4 = node.GetValueOfLastTagOfName(nameof(Production_Speed_Mod_Base_Vs_Tech_4)).ToEngineFloat();
        }
    }
}
