using System.Diagnostics.CodeAnalysis;
using System.Xml;
using AlomoEngine;
using AlomoEngine.Core.Interfaces;

namespace ForcesOfCorruptionEnvironment.Objects.GameConstants.GUI
{
    [SuppressMessage("ReSharper", "InconsistentNaming")]
    public class GuiGameConstantsData : XmlTagCategory
    {
        public GuiGameConstantsData(IAlomoXmlFile file) : base(file) {}

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
            

            return File.RootNode;
        }

        public override void Deserialize(XmlElement node)
        {
            EncyclopediaConstants = new EncyclopediaConstants(File);
            EncyclopediaConstants.Deserialize(node);

            CommandBarGuiData = new CommandBarGuiData(File);
            CommandBarGuiData.Deserialize(node);

            FowData = new FowData(File);
            FowData.Deserialize(node);

            GameCreditsData = new GameCreditsData(File);
            GameCreditsData.Deserialize(node);

            GameTypographyData = new GameTypographyData(File);
            GameTypographyData.Deserialize(node);

            LocalizationData = new LocalizationData(File);
            LocalizationData.Deserialize(node);

            GeneralGuiData = new GeneralGuiData(File);
            GeneralGuiData.Deserialize(node);
        }
    }
}
