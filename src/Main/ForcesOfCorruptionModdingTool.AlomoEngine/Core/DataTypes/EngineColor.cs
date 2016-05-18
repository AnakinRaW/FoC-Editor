using System;
using System.ComponentModel;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Windows.Media;
using ForcesOfCorruptionModdingTool.AlomoEngine.Annotations;
using ForcesOfCorruptionModdingTool.AlomoEngine.Core.EventArgs;

namespace ForcesOfCorruptionModdingTool.AlomoEngine.Core.DataTypes
{
    public class EngineColor : INotifyPropertyChanged
    {
        public EngineColor(byte r, byte g, byte b) : this(r, g, b, byte.MaxValue) { }

        public EngineColor(byte r, byte g, byte b, byte a)
        {
            Red = r;
            Green = g;
            Blue = b;
            Alpha = a;
        }

        private byte _alpha;
        private byte _blue;
        private byte _green;
        private byte _red;

        public event EventHandler<ColorChangedEventArgs> ColorChanged;

        public byte Alpha
        {
            get { return _alpha; }
            set
            {
                if (value == _alpha)
                    return;
                _alpha = value;
                OnPropertyChanged();
                OnColorChanged(new ColorChangedEventArgs(ColorChangedEventArgs.ColorComponent.Alpha, value));
            }
        }

        public byte Blue
        {
            get { return _blue; }
            set
            {
                if (value == _blue)
                    return;
                _blue = value;
                OnPropertyChanged();
                OnColorChanged(new ColorChangedEventArgs(ColorChangedEventArgs.ColorComponent.Blue, value));
            }
        }

        public Color Color { get; private set; }

        public byte Green
        {
            get { return _green; }
            set
            {
                if (value == _green)
                    return;
                _green = value;
                OnPropertyChanged();
                OnColorChanged(new ColorChangedEventArgs(ColorChangedEventArgs.ColorComponent.Green, value));
            }
        }

        public byte Red
        {
            get { return _red; }
            set
            {
                if (value == _red)
                    return;
                _red = value;
                OnPropertyChanged();
                OnColorChanged(new ColorChangedEventArgs(ColorChangedEventArgs.ColorComponent.Red, value));
            }
        }

        public event PropertyChangedEventHandler PropertyChanged;

        public static EngineColor CreateColorFromString(string s)
        {
            var list = s.Split(',').ToList();
            if (list.Count == 0 || list[0] == s)
                list = s.Split(' ').ToList();
            if (list.Count == 0 || list[0] == s)
                list = s.Split('|').ToList();
            if (list.Count < 3)
                throw new FormatException();

            var r = byte.Parse(list[0]);
            var g = byte.Parse(list[1]);
            var b = byte.Parse(list[2]);

            if (list.Count == 3)
                return new EngineColor(r, g, b);
            var a = byte.Parse(list[3]);
            return new EngineColor(r,g,b,a);
        }

        public string ToString(EngineSparators separator, bool showAlpha = true)
        {
            string result;

            switch (separator)
            {
                case EngineSparators.Comma:
                    result = $"{Red}, {Green}, {Blue},";
                    break;
                case EngineSparators.Space:
                    result = $"{Red} {Green} {Blue}";
                    break;
                case EngineSparators.VerticalLine:
                    result = $"{Red} | {Green} | {Blue} |";
                    break;
                default:
                    throw new ArgumentOutOfRangeException(nameof(separator), separator, null);
            }
            if (showAlpha)
                result += $" {Alpha}";
            else
                if (separator != EngineSparators.Space)
                    result = result.Remove(result.Length - 1);
            return result;
        }

        public string ToString(bool showAlpha)
        {
            return ToString(EngineSparators.Comma, showAlpha);
        }

        public override string ToString()
        {
            return ToString(EngineSparators.Comma);
        }

        protected virtual void OnColorChanged(ColorChangedEventArgs e)
        {
            Color = Color.FromArgb(Alpha, Red, Green, Blue);
            ColorChanged?.Invoke(this, e);
        }

        [NotifyPropertyChangedInvocator]
        protected virtual void OnPropertyChanged([CallerMemberName] string propertyName = null)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }
    }
}