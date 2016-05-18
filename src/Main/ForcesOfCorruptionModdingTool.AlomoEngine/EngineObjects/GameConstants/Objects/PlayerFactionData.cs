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
    public class PlayerFactionData : EngineObject
    {
        public PlayerFactionData(IGameXmlFile parent) : base(parent) {}

        public bool Use_Neutral_UI_Color { get; set; }

        public EngineColor Neutral_UI_Color { get; set; }

        public double Default_Defense_Adjust { get; set; }

        public double Production_Speed_Factor { get; set; }

        public EngineColor Player_Color { get; set; }

        public EngineColor Enemy_Color { get; set; }

        public bool AIUsesFogOfWarGalactic { get; set; }

        public bool AIUsesFogOfWarSpace { get; set; }

        public bool AIUsesFogOfWarLand { get; set; }

        public bool SetupPhaseEnabled { get; set; }

        public bool ShowUnitAIPlanAttachment { get; set; }

        public double AITechLevelProductionTimeWeight { get; set; }

        public string Good_Side_Name { get; set; }
        public string Evil_Side_Name { get; set; }
        public string Corrupt_Side_Name { get; set; }
        public string Good_Side_Leader_Name { get; set; }
        public string Evil_Side_Leader_Name { get; set; }
        public string Corrupt_Side_Leader_Name { get; set; }

        public override XmlElement Serialize()
        {
            var node = Parent.RootNode;
            node.SetValueOfLastTagOfName(nameof(Use_Neutral_UI_Color), Use_Neutral_UI_Color.ToString());
            node.SetValueOfLastTagOfName(nameof(Neutral_UI_Color), Neutral_UI_Color.ToString());
            node.SetValueOfLastTagOfName(nameof(Default_Defense_Adjust), Default_Defense_Adjust.ToString(CultureInfo.InvariantCulture));
            node.SetValueOfLastTagOfName(nameof(Production_Speed_Factor), Production_Speed_Factor.ToString(CultureInfo.InvariantCulture));
            node.SetValueOfLastTagOfName(nameof(Player_Color), Player_Color.ToString());
            node.SetValueOfLastTagOfName(nameof(Enemy_Color), Enemy_Color.ToString());

            node.SetValueOfLastTagOfName(nameof(AIUsesFogOfWarGalactic), AIUsesFogOfWarGalactic.ToString());
            node.SetValueOfLastTagOfName(nameof(AIUsesFogOfWarSpace), AIUsesFogOfWarSpace.ToString());
            node.SetValueOfLastTagOfName(nameof(AIUsesFogOfWarLand), AIUsesFogOfWarLand.ToString());
            node.SetValueOfLastTagOfName(nameof(SetupPhaseEnabled), SetupPhaseEnabled.ToString());
            node.SetValueOfLastTagOfName(nameof(ShowUnitAIPlanAttachment), ShowUnitAIPlanAttachment.ToString());
            node.SetValueOfLastTagOfName(nameof(AITechLevelProductionTimeWeight), AITechLevelProductionTimeWeight.ToString(CultureInfo.InvariantCulture));
            node.SetValueOfLastTagOfName(nameof(Good_Side_Name), Good_Side_Name);
            node.SetValueOfLastTagOfName(nameof(Evil_Side_Name), Evil_Side_Name);
            node.SetValueOfLastTagOfName(nameof(Corrupt_Side_Name), Corrupt_Side_Name);
            node.SetValueOfLastTagOfName(nameof(Good_Side_Leader_Name), Good_Side_Leader_Name);
            node.SetValueOfLastTagOfName(nameof(Evil_Side_Leader_Name), Evil_Side_Leader_Name);
            node.SetValueOfLastTagOfName(nameof(Corrupt_Side_Leader_Name), Corrupt_Side_Leader_Name);
            return node;
        }

        public override void Deserialize(XmlElement node)
        {
            Use_Neutral_UI_Color =
               node.GetValueOfLastTagOfName(nameof(Use_Neutral_UI_Color)).ToEngineBoolean();
            Neutral_UI_Color = EngineColor.CreateColorFromString(node.GetValueOfLastTagOfName(nameof(Neutral_UI_Color)));
            Default_Defense_Adjust =
               node.GetValueOfLastTagOfName(nameof(Default_Defense_Adjust)).ToEngineFloat();
            Production_Speed_Factor =
               node.GetValueOfLastTagOfName(nameof(Production_Speed_Factor)).ToEngineFloat();
            Player_Color = EngineColor.CreateColorFromString(node.GetValueOfLastTagOfName(nameof(Player_Color)));
            Enemy_Color = EngineColor.CreateColorFromString(node.GetValueOfLastTagOfName(nameof(Enemy_Color)));

            AIUsesFogOfWarGalactic = node.GetValueOfLastTagOfName(nameof(AIUsesFogOfWarGalactic)).ToEngineBoolean();
            AIUsesFogOfWarSpace = node.GetValueOfLastTagOfName(nameof(AIUsesFogOfWarSpace)).ToEngineBoolean();
            AIUsesFogOfWarLand = node.GetValueOfLastTagOfName(nameof(AIUsesFogOfWarLand)).ToEngineBoolean();
            SetupPhaseEnabled = node.GetValueOfLastTagOfName(nameof(SetupPhaseEnabled)).ToEngineBoolean();
            ShowUnitAIPlanAttachment = node.GetValueOfLastTagOfName(nameof(ShowUnitAIPlanAttachment)).ToEngineBoolean();
            AITechLevelProductionTimeWeight = node.GetValueOfLastTagOfName(nameof(AITechLevelProductionTimeWeight)).ToEngineFloat();
        }
    }
}
