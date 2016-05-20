using System.Diagnostics.CodeAnalysis;
using System.Xml;
using AlomoEngine.Core.Interfaces;

namespace AlomoEngine.Objects.GameConstants.GUI
{
    [SuppressMessage("ReSharper", "InconsistentNaming")]
    public class GuiGameConstantsData : EngineObject
    {
        public GuiGameConstantsData(IGameXmlFile parent) : base(parent) {}

        public EncyclopediaConstants EncyclopediaConstants { get; set; }
        public CommandBarGuiData CommandBarGuiData { get; set; }
        public FowData FowData { get; set; }
        public GameCreditsData GameCreditsData { get; set; }
        public GameTypographyData GameTypographyData { get; set; }
        public LocalizationData LocalizationData { get; set; }
        public GeneralGuiData GeneralGuiData { get; set; }

        public override XmlElement Serialize()
        {
            CommandBarGuiData.Serialize();
            EncyclopediaConstants.Serialize();
            GameCreditsData.Serialize();
            FowData.Serialize();
            GameTypographyData.Serialize();
            LocalizationData.Serialize();
            GeneralGuiData.Serialize();
            

            return Parent.RootNode;
        }

        public override void Deserialize(XmlElement node)
        {
            EncyclopediaConstants = new EncyclopediaConstants(Parent);
            EncyclopediaConstants.Deserialize(node);

            CommandBarGuiData = new CommandBarGuiData(Parent);
            CommandBarGuiData.Deserialize(node);

            FowData = new FowData(Parent);
            FowData.Deserialize(node);

            GameCreditsData = new GameCreditsData(Parent);
            GameCreditsData.Deserialize(node);

            GameTypographyData = new GameTypographyData(Parent);
            GameTypographyData.Deserialize(node);

            LocalizationData = new LocalizationData(Parent);
            LocalizationData.Deserialize(node);

            GeneralGuiData = new GeneralGuiData(Parent);
            GeneralGuiData.Deserialize(node);
        }
    }
}
