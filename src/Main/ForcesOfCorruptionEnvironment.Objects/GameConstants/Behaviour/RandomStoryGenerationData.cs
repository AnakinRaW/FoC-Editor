using System.Diagnostics.CodeAnalysis;
using System.Xml;
using AlomoEngine.Core.Interfaces;
using AlomoEngine.Core.Interfaces.FileLayout;
using AlomoEngine.Xml;
using AlomoEngine.Xml.DataTypes;
using AlomoEngine.Xml.Layout;

namespace ForcesOfCorruptionEnvironment.Objects.GameConstants.Behaviour
{
    [SuppressMessage("ReSharper", "InconsistentNaming")]
    public class RandomStoryGenerationData : AbstractXmlTagCategory
    {
        public RandomStoryGenerationData(IAlomoXmlFile file) : base(file) {}

        public EngineStringTupel Random_Story_Triggers { get; set; }

        public int Random_Story_Max_Triggers { get; set; }

        public string Random_Story_Rebel_Construction { get; set; }

        public string Random_Story_Empire_Construction { get; set; }

        public string Random_Story_Rebel_Destroy { get; set; }

        public string Random_Story_Empire_Destroy { get; set; }

        public EngineStringTupel Random_Story_Rewards { get; set; }

        public string Random_Story_Reward_Rebel_Buildable { get; set; }

        public string Random_Story_Reward_Empire_Buildable { get; set; }

        public string Random_Story_Reward_Rebel_Unit { get; set; }

        public string Random_Story_Reward_Empire_Unit { get; set; }

        public override XmlElement Serialize()
        {
            var node = File.RootNode;
            node.SetValueOfLastTagOfName(nameof(Random_Story_Triggers), Random_Story_Triggers.ToString());
            node.SetValueOfLastTagOfName(nameof(Random_Story_Rewards), Random_Story_Rewards.ToString());
            node.SetValueOfLastTagOfName(nameof(Random_Story_Max_Triggers), Random_Story_Max_Triggers.ToString());
            node.SetValueOfLastTagOfName(nameof(Random_Story_Rebel_Construction), Random_Story_Rebel_Construction);
            node.SetValueOfLastTagOfName(nameof(Random_Story_Empire_Construction), Random_Story_Empire_Construction);
            node.SetValueOfLastTagOfName(nameof(Random_Story_Rebel_Destroy), Random_Story_Rebel_Destroy);
            node.SetValueOfLastTagOfName(nameof(Random_Story_Empire_Destroy), Random_Story_Empire_Destroy);
            node.SetValueOfLastTagOfName(nameof(Random_Story_Reward_Rebel_Buildable), Random_Story_Reward_Rebel_Buildable);
            node.SetValueOfLastTagOfName(nameof(Random_Story_Reward_Empire_Buildable), Random_Story_Reward_Empire_Buildable);
            node.SetValueOfLastTagOfName(nameof(Random_Story_Reward_Rebel_Unit), Random_Story_Reward_Rebel_Unit);
            node.SetValueOfLastTagOfName(nameof(Random_Story_Reward_Empire_Unit), Random_Story_Reward_Empire_Unit);
            return node;
        }

        public override void Deserialize(XmlElement node)
        {
            Random_Story_Triggers = EngineStringTupel.CreateFromString(node.GetValueOfLastTagOfName(nameof(Random_Story_Triggers)));
            Random_Story_Rewards = EngineStringTupel.CreateFromString(node.GetValueOfLastTagOfName(nameof(Random_Story_Rewards)));
            Random_Story_Max_Triggers = node.GetValueOfLastTagOfName(nameof(Random_Story_Max_Triggers)).ToInteger();
            Random_Story_Rebel_Construction = node.GetValueOfLastTagOfName(nameof(Random_Story_Rebel_Construction));
            Random_Story_Empire_Construction = node.GetValueOfLastTagOfName(nameof(Random_Story_Empire_Construction));
            Random_Story_Rebel_Destroy = node.GetValueOfLastTagOfName(nameof(Random_Story_Rebel_Destroy));
            Random_Story_Empire_Destroy = node.GetValueOfLastTagOfName(nameof(Random_Story_Empire_Destroy));
            Random_Story_Reward_Rebel_Buildable = node.GetValueOfLastTagOfName(nameof(Random_Story_Reward_Rebel_Buildable));
            Random_Story_Reward_Empire_Buildable = node.GetValueOfLastTagOfName(nameof(Random_Story_Reward_Empire_Buildable));
            Random_Story_Reward_Rebel_Unit = node.GetValueOfLastTagOfName(nameof(Random_Story_Reward_Rebel_Unit));
            Random_Story_Reward_Empire_Unit = node.GetValueOfLastTagOfName(nameof(Random_Story_Reward_Empire_Unit));
        }
    }
}
