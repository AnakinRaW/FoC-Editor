using System;
using System.Diagnostics.CodeAnalysis;
using System.Globalization;
using System.Xml;
using AlomoEngine.Core.Interfaces;
using AlomoEngine.Xml;
using AlomoEngine.Xml.DataTypes;
using AlomoEngine.Xml.DataTypes.Enums;
using AlomoEngine.Xml.Layout;
using ForcesOfCorruptionEnvironment.DataTypes.Enums;

namespace ForcesOfCorruptionEnvironment.Objects.GameConstants.Engine
{
    [SuppressMessage("ReSharper", "InconsistentNaming")]
    public class MultiplayerData : AbstractXmlTagCategory
    {
        public MultiplayerData(IAlomoXmlFile file) : base(file) {}

        public int Min_Skirmish_Credits { get; set; }
        public int Max_Skirmish_Credits { get; set; }
        public int MP_Default_Credits { get; set; }
        public int MP_Default_Start_Tech_Level { get; set; }
        public int MP_Default_Max_Tech_Level { get; set; }

        public GameconstantsMultiplayerAutoResolveValues MP_Default_Allow_Auto_Resolve { get; set; }
        public int MP_Default_Game_Timer { get; set; }
        public int MP_Default_Win_Condition { get; set; }
        public int MP_Default_Win_Condition_Int_Param { get; set; }
        public double MP_Default_Win_Condition_Float_Param { get; set; }

        public bool MP_Default_Allow_Heroes { get; set; }
        public bool MP_Default_Allow_SuperWeapons { get; set; }
        public bool MP_Default_Pre_Built_Base { get; set; }
        public bool MP_Default_Allow_Random_Events { get; set; }
        public bool MP_Default_Free_Starting_Units { get; set; }
        public SkirmishWinConditions MP_Default_Land_Tactical_Win_Condition { get; set; }
        public SkirmishWinConditions MP_Default_Space_Tactical_Win_Condition { get; set; }

        public EngineColor MP_Color_Blue { get; set; }
        public EngineColor MP_Color_Red { get; set; }
        public EngineColor MP_Color_Green { get; set; }
        public EngineColor MP_Color_Orange { get; set; }
        public EngineColor MP_Color_Cyan { get; set; }
        public EngineColor MP_Color_Purple { get; set; }
        public EngineColor MP_Color_Yellow { get; set; }
        public EngineColor MP_Color_Gray { get; set; }
        public EngineColor MP_Color_Eight { get; set; }

        public EngineStringTupel Quickmatch_Map_Exclusion_List { get; set; }

        public override XmlElement Serialize()
        {
            var node = File.RootNode;
            node.SetValueOfLastTagOfName(nameof(Min_Skirmish_Credits), Min_Skirmish_Credits.ToString());
            node.SetValueOfLastTagOfName(nameof(Max_Skirmish_Credits), Max_Skirmish_Credits.ToString());
            node.SetValueOfLastTagOfName(nameof(MP_Default_Credits), MP_Default_Credits.ToString());
            node.SetValueOfLastTagOfName(nameof(MP_Default_Start_Tech_Level), MP_Default_Start_Tech_Level.ToString());
            node.SetValueOfLastTagOfName(nameof(MP_Default_Max_Tech_Level), MP_Default_Max_Tech_Level.ToString());
            node.SetValueOfLastTagOfName(nameof(MP_Default_Allow_Auto_Resolve), ((int) MP_Default_Allow_Auto_Resolve).ToString());
            node.SetValueOfLastTagOfName(nameof(MP_Default_Game_Timer), MP_Default_Game_Timer.ToString());
            node.SetValueOfLastTagOfName(nameof(MP_Default_Win_Condition), MP_Default_Win_Condition.ToString());
            node.SetValueOfLastTagOfName(nameof(MP_Default_Win_Condition_Int_Param), MP_Default_Win_Condition_Int_Param.ToString());
            node.SetValueOfLastTagOfName(nameof(MP_Default_Win_Condition_Float_Param), MP_Default_Win_Condition_Float_Param.ToString(CultureInfo.InvariantCulture));
            node.SetValueOfLastTagOfName(nameof(MP_Default_Allow_Heroes), MP_Default_Allow_Heroes.ToString());
            node.SetValueOfLastTagOfName(nameof(MP_Default_Allow_SuperWeapons), MP_Default_Allow_SuperWeapons.ToString());
            node.SetValueOfLastTagOfName(nameof(MP_Default_Pre_Built_Base), MP_Default_Pre_Built_Base.ToString());
            node.SetValueOfLastTagOfName(nameof(MP_Default_Allow_Random_Events), MP_Default_Allow_Random_Events.ToString());
            node.SetValueOfLastTagOfName(nameof(MP_Default_Free_Starting_Units), MP_Default_Free_Starting_Units.ToString());
            node.SetValueOfLastTagOfName(nameof(MP_Default_Land_Tactical_Win_Condition), MP_Default_Land_Tactical_Win_Condition.ToString());
            node.SetValueOfLastTagOfName(nameof(MP_Default_Space_Tactical_Win_Condition), MP_Default_Space_Tactical_Win_Condition.ToString());

            node.SetValueOfLastTagOfName(nameof(MP_Color_Blue), MP_Color_Blue.ToString(false));
            node.SetValueOfLastTagOfName(nameof(MP_Color_Red), MP_Color_Red.ToString(false));
            node.SetValueOfLastTagOfName(nameof(MP_Color_Green), MP_Color_Green.ToString(false));
            node.SetValueOfLastTagOfName(nameof(MP_Color_Orange), MP_Color_Orange.ToString(false));
            node.SetValueOfLastTagOfName(nameof(MP_Color_Cyan), MP_Color_Cyan.ToString(false));
            node.SetValueOfLastTagOfName(nameof(MP_Color_Purple), MP_Color_Purple.ToString(false));
            node.SetValueOfLastTagOfName(nameof(MP_Color_Yellow), MP_Color_Yellow.ToString(false));
            node.SetValueOfLastTagOfName(nameof(MP_Color_Gray), MP_Color_Gray.ToString(false));
            node.SetValueOfLastTagOfName(nameof(MP_Color_Eight), MP_Color_Eight.ToString(false));

            node.SetValueOfLastTagOfName(nameof(Quickmatch_Map_Exclusion_List), Quickmatch_Map_Exclusion_List.ToString(EngineSparators.Comma, true));
            return node;
        }

        public override void Deserialize(XmlElement node)
        {
            Min_Skirmish_Credits = node.GetValueOfLastTagOfName(nameof(Min_Skirmish_Credits)).ToInteger();
            Max_Skirmish_Credits = node.GetValueOfLastTagOfName(nameof(Max_Skirmish_Credits)).ToInteger();
            MP_Default_Credits = node.GetValueOfLastTagOfName(nameof(MP_Default_Credits)).ToInteger();
            MP_Default_Start_Tech_Level = node.GetValueOfLastTagOfName(nameof(MP_Default_Start_Tech_Level)).ToInteger();
            MP_Default_Max_Tech_Level = node.GetValueOfLastTagOfName(nameof(MP_Default_Max_Tech_Level)).ToInteger();

            GameconstantsMultiplayerAutoResolveValues r;
            if (Enum.TryParse(node.GetValueOfLastTagOfName(nameof(MP_Default_Allow_Auto_Resolve)), true, out r))
                MP_Default_Allow_Auto_Resolve = r;
            MP_Default_Game_Timer = node.GetValueOfLastTagOfName(nameof(MP_Default_Game_Timer)).ToInteger();
            MP_Default_Win_Condition = node.GetValueOfLastTagOfName(nameof(MP_Default_Win_Condition)).ToInteger();
            MP_Default_Win_Condition_Int_Param = node.GetValueOfLastTagOfName(nameof(MP_Default_Win_Condition_Int_Param)).ToInteger();
            MP_Default_Win_Condition_Float_Param = node.GetValueOfLastTagOfName(nameof(MP_Default_Win_Condition_Float_Param)).ToEngineFloat();
            MP_Default_Allow_Heroes = node.GetValueOfLastTagOfName(nameof(MP_Default_Allow_Heroes)).ToEngineBoolean();
            MP_Default_Allow_SuperWeapons = node.GetValueOfLastTagOfName(nameof(MP_Default_Allow_SuperWeapons)).ToEngineBoolean();
            MP_Default_Pre_Built_Base = node.GetValueOfLastTagOfName(nameof(MP_Default_Pre_Built_Base)).ToEngineBoolean();
            MP_Default_Allow_Random_Events = node.GetValueOfLastTagOfName(nameof(MP_Default_Allow_Random_Events)).ToEngineBoolean();
            MP_Default_Free_Starting_Units = node.GetValueOfLastTagOfName(nameof(MP_Default_Free_Starting_Units)).ToEngineBoolean();

            SkirmishWinConditions v;
            if (Enum.TryParse(node.GetValueOfLastTagOfName(nameof(MP_Default_Land_Tactical_Win_Condition)), true, out v))
                MP_Default_Land_Tactical_Win_Condition = v;
            if (Enum.TryParse(node.GetValueOfLastTagOfName(nameof(MP_Default_Space_Tactical_Win_Condition)), true, out v))
                MP_Default_Space_Tactical_Win_Condition = v;

            MP_Color_Blue = EngineColor.CreateColorFromString(node.GetValueOfLastTagOfName(nameof(MP_Color_Blue)));
            MP_Color_Red = EngineColor.CreateColorFromString(node.GetValueOfLastTagOfName(nameof(MP_Color_Red)));
            MP_Color_Green = EngineColor.CreateColorFromString(node.GetValueOfLastTagOfName(nameof(MP_Color_Green)));
            MP_Color_Orange = EngineColor.CreateColorFromString(node.GetValueOfLastTagOfName(nameof(MP_Color_Orange)));
            MP_Color_Cyan = EngineColor.CreateColorFromString(node.GetValueOfLastTagOfName(nameof(MP_Color_Cyan)));
            MP_Color_Purple = EngineColor.CreateColorFromString(node.GetValueOfLastTagOfName(nameof(MP_Color_Purple)));
            MP_Color_Yellow = EngineColor.CreateColorFromString(node.GetValueOfLastTagOfName(nameof(MP_Color_Yellow)));
            MP_Color_Gray = EngineColor.CreateColorFromString(node.GetValueOfLastTagOfName(nameof(MP_Color_Gray)));
            MP_Color_Eight = EngineColor.CreateColorFromString(node.GetValueOfLastTagOfName(nameof(MP_Color_Eight)));

            Quickmatch_Map_Exclusion_List = EngineStringTupel.CreateFromString(node.GetValueOfLastTagOfName(nameof(Quickmatch_Map_Exclusion_List)));
        }
    }
}
