namespace AlomoEngine.Core.Interfaces
{
    public interface IEngineObject : IXmlSerializable, IHasDescription
    {
        IAlomoXmlFile Parent { get; }
    }
}
