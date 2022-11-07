using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;
using System.Windows.Media;
using System.Xml.Linq;

namespace LegoBricks.ViewModel
{
    public class ColorsViewModel : ViewModelBase
    {
        private Model.Model? m_model;
        private ObservableCollection<ColorData>? m_colors;
        private ColorData? m_selectedItem;
        private bool m_isItemSelected;
        private bool m_isDataDirty;
        private List<Modification<ColorData>>? m_modifications;
        private string m_opaqueImagePath;
        private string m_transparentImagePath;
        private string m_noImagePath;
        private string m_imagePath;
        private Color m_colorImageBackground;

        public ColorsViewModel(Model.Model? model)
        {
            this.Initialize(model);
            m_opaqueImagePath = Helpers.GetAbsolutePath("media/3065-opaque.png");
            m_transparentImagePath = Helpers.GetAbsolutePath("media/3065-trans.png");
            m_noImagePath = Helpers.GetAbsolutePath("media/NotAvailable.jpg");
            m_imagePath = m_noImagePath;
            m_colorImageBackground = Color.FromArgb(0, 0, 0, 0);

            this.PropertyChanged += OnPropertyChanged;
        }

        private void OnPropertyChanged(object? sender, System.ComponentModel.PropertyChangedEventArgs e)
        {
            switch (e.PropertyName)
            {
                case "SelectedItem":
                    if (SelectedItem != null)
                    {
                        ColorImagePath = ((ColorData)SelectedItem).transparent ? m_transparentImagePath : m_opaqueImagePath;

                        var data = (ColorData)SelectedItem;
                        Color colorRGB = (Color)ColorConverter.ConvertFromString("#FF" + data.rgb);
                        ColorImageBackground = colorRGB;
                    }
                    else
                    {
                        ColorImagePath = m_opaqueImagePath;
                        ColorImageBackground = Color.FromArgb(0, 0, 0, 0);
                    }
                    break;
                default:
                    break;
            }
        }

        private void Initialize(Model.Model? model)
        {
            m_model = model;
            RefreshColors();

            m_modifications = new List<Modification<ColorData>>();
        }

        public void AddColor(ColorData data)
        {
            if (Colors != null)
            {
                Colors.Add(data);
                m_modifications?.Add(Modification<ColorData>.Add(data));
                IsDataDirty = true;
            }
        }

        public void ChangeColor(ColorData data, ColorData originalData)
        {
            if (Colors != null)
            {
                var index = Colors.IndexOf(originalData);
                if (index != -1)
                {
                    Colors[index] = data;
                }
                m_modifications?.Add(Modification<ColorData>.Update(data, originalData));
                IsDataDirty = true;
            }
        }

        public void DeleteColor(ColorData data)
        {
            if (Colors != null)
            {
                Colors.Remove(data);
                m_modifications?.Add(Modification<ColorData>.Delete(data));
                IsDataDirty = true;
            }
        }

        private void RefreshColors()
        {
            m_model?.RefreshColors();
            Colors = m_model?.Colors;
        }
        public void ResetColors()
        {
            m_modifications?.Clear();
            RefreshColors();
            IsDataDirty = false;
        }

        public void SaveColors()
        {
            m_model?.SaveModifications(m_modifications);
            m_modifications?.Clear();
            RefreshColors();
            IsDataDirty = false;
        }

        public Color ColorImageBackground
        {
            get
            {
                return m_colorImageBackground;
            }
            set { m_colorImageBackground = value;  base.RaisePropertyChangedEvent("ColorImageBackground"); }
        }

        public string ColorImagePath
        {
            get
            {
                return m_imagePath;
            }
            set { m_imagePath = value; base.RaisePropertyChangedEvent("ColorImagePath"); }
        }

        public ObservableCollection<ColorData>? Colors
        {
            get
            {
                return m_colors;
            }

            set
            {
                m_colors = value;
                base.RaisePropertyChangedEvent("Colors");
            }
        }

        public Model.Model? Model
        {
            get { return m_model; }
            set { m_model = value; base.RaisePropertyChangedEvent("Model"); }
        }
        public ColorData? SelectedItem
        {
            get { return m_selectedItem; }
            set { m_selectedItem = value; IsItemSelected = (m_selectedItem != null); base.RaisePropertyChangedEvent("SelectedItem"); }
        }

        public bool IsItemSelected
        {
            get { return m_isItemSelected; }
            set { m_isItemSelected = value; base.RaisePropertyChangedEvent("IsItemSelected"); }
        }

        public bool IsDataDirty
        {
            get { return m_isDataDirty; }
            set { m_isDataDirty = value; base.RaisePropertyChangedEvent("IsDataDirty"); }
        }

    }
}
