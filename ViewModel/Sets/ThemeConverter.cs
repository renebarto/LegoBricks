using System.Windows.Data;
using System;
using LegoBricks;
using LegoBricks.Model;

namespace LegoBricks.ViewModel
{
    public class ThemeConverter : IValueConverter
    {
        // Convert from parent_id to string
        public object Convert(object value, Type targetType, object parameter, System.Globalization.CultureInfo culture)
        {
            if (value == null)
                return "-";
            var theme = (ThemeData)value;
            if (theme.id == -1)
                return "-";
            return theme.id.ToString() + "-" + theme.name;
        }

        // Convert from string to parent_id
        public object ConvertBack(object value, Type targetType, object parameter, System.Globalization.CultureInfo culture)
        {
            ThemeData theme = new ThemeData();
            var text = (string)value;
            var parts = text.Split("-");
            if (parts.Length == 1)
            {
                int id;
                if (Int32.TryParse(parts[0], out id))
                {
                    theme.id = id;
                }
                else
                {
                    theme.name = parts[0];
                }
            }
            else if (parts.Length == 2)
            {
                try
                {
                    int id = Int32.Parse(parts[0]);
                    theme.id = id;
                    theme.name = parts[1];
                }
                catch (Exception /*e*/)
                {
                }
            }
            return theme;
        }

    }
}
