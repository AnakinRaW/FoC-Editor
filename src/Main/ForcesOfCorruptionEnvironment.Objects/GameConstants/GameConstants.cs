using System;
using System.Xml;
using AlomoEngine;
using ForcesOfCorruptionEnvironment.Objects.GameConstants.Behaviour;
using ForcesOfCorruptionEnvironment.Objects.GameConstants.Engine;
using ForcesOfCorruptionEnvironment.Objects.GameConstants.GUI;
using ForcesOfCorruptionEnvironment.Objects.GameConstants.Objects;

namespace ForcesOfCorruptionEnvironment.Objects.GameConstants
{
    public sealed class GameConstants : AbstractAlomoXmlFile
    {
        public EngineGameConstantsData EngineGameConstantsData { get; set; }

        public BehaviourGameConstantsData BehaviourGameConstantsData { get; set; }

        public GuiGameConstantsData GuiGameConstantsData { get; set; }

        public GameObjectsConstantsData GameObjectsConstantsData { get; set; }

        public GameConstantsData GameConstantsData { get; set; }

        public override void Deserialize(XmlDocument document)
        {
            base.Deserialize(document);
            EngineGameConstantsData = new EngineGameConstantsData(this);
            EngineGameConstantsData.Deserialize(RootNode);

            BehaviourGameConstantsData = new BehaviourGameConstantsData(this);
            BehaviourGameConstantsData.Deserialize(RootNode);

            GuiGameConstantsData = new GuiGameConstantsData(this);
            GuiGameConstantsData.Deserialize(RootNode);

            GameConstantsData = new GameConstantsData(this);
            GameConstantsData.Deserialize(RootNode);

            GameObjectsConstantsData = new GameObjectsConstantsData(this);
            GameObjectsConstantsData.Deserialize(RootNode);           
        }

        public override void Deserialize(XmlElement node)
        {
            throw new NotImplementedException();
        }

        public override XmlElement Serialize()
        {
            RootNode = EngineGameConstantsData.Serialize();
            RootNode = BehaviourGameConstantsData.Serialize();
            RootNode = GameConstantsData.Serialize();
            RootNode = GameObjectsConstantsData.Serialize();
            RootNode = GuiGameConstantsData.Serialize();

            return RootNode;
        }
    }
}