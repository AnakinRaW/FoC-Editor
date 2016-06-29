namespace AlomoEngine.Xml.DataTypes.EventArgs
{
    public class ColorChangedEventArgs : System.EventArgs
    {
        public ColorComponent Component { get; }
        public byte Value { get; }

        public enum ColorComponent
        {
            Alpha,
            Red,
            Green,
            Blue
        }

        public ColorChangedEventArgs(ColorComponent component, byte value)
        {
            Component = component;
            Value = value;
        }
    }
}
