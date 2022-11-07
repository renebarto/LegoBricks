using LegoBricks.Model;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Controls;
using System.Windows.Media;
using System.Windows.Input;
using System.Xml.Linq;

namespace LegoBricks.ViewModel
{
    public class ColorEditViewModel : ViewModelBase
    {
        private bool m_checkExisting;
        private Model.Model? m_model;
        private string? m_id;
        private string? m_name;
        private string? m_rgb;
        private bool m_transparent;

        public ColorEditViewModel(Model.Model? model, bool checkExisting)
        {
            m_model = model;
            m_checkExisting = checkExisting;
        }

        public String ColorID
        {
            get { return m_id ?? ""; }
            set { m_id = value; base.RaisePropertyChangedEvent("ColorID"); }
        }
        public String ColorName
        {
            get { return m_name ?? ""; }
            set { m_name = value; base.RaisePropertyChangedEvent("ColorName"); }
        }
        public String ColorRGB
        {
            get { return m_rgb ?? ""; }
            set { m_rgb = value; base.RaisePropertyChangedEvent("ColorRGB"); }
        }
        public bool ColorTransparent
        {
            get { return m_transparent; }
            set { m_transparent = value; base.RaisePropertyChangedEvent("ColorTransparent"); }
        }

        public Brush ColorImageBackground
        {
            get 
            {
                try
                {
                    Color colorRGB = (Color)ColorConverter.ConvertFromString("#FF" + m_rgb);
                    return new SolidColorBrush(colorRGB);
                }
                catch { }
                return new SolidColorBrush(Color.FromRgb(0, 0, 0));
            }
            set { base.RaisePropertyChangedEvent("ColorImageBackground"); }
        }

        public bool CheckExisting
        {
            get { return m_checkExisting; }
        }
        public Model.Model? Model
        {
            get { return m_model; }
            set { m_model = value; base.RaisePropertyChangedEvent("Model"); }
        }
    }
}
