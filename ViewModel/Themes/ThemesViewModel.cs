using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;
using System.Xml.Linq;

namespace LegoBricks.ViewModel
{
    public class ThemesViewModel : ViewModelBase
    {
        private Model.Model? m_model;
        private ObservableCollection<ThemeDataPresentation>? m_sets;
        private ThemeDataPresentation? m_selectedItem;
        private bool m_isItemSelected;
        private bool m_isDataDirty;
        private List<Modification<ThemeDataPresentation>>? m_modifications;
        private string m_imagePath;

        public ThemesViewModel(Model.Model? model)
        {
            this.Initialize(model);
            m_imagePath = "";
            this.PropertyChanged += OnPropertyChanged;
        }

        private void OnPropertyChanged(object? sender, System.ComponentModel.PropertyChangedEventArgs e)
        {
            switch (e.PropertyName)
            {
                case "SelectedItem":
                    if (SelectedItem != null)
                    {
                        ThemeImagePath = Helpers.GetAbsolutePath(String.Format("media/themes/{0}.png", ((ThemeDataPresentation)SelectedItem).Id));
                    }
                    else
                    {
                        ThemeImagePath = "";
                    }
                    break;
                default:
                    break;
            }
        }


        private void Initialize(Model.Model? model)
        {
            m_model = model;
            RefreshThemes();

            m_modifications = new List<Modification<ThemeDataPresentation>>();
        }

        public void AddTheme(ThemeDataPresentation data)
        {
            if (Themes != null)
            {
                Themes.Add(data);
                m_modifications?.Add(Modification<ThemeDataPresentation>.Add(data));
                IsDataDirty = true;
            }
        }

        public void ChangeTheme(ThemeDataPresentation data, ThemeDataPresentation originalData)
        {
            if ((Themes != null) && (m_model != null))
            {
                var index = m_model.FindTheme(originalData.Id);
                if (index != -1)
                {
                    Themes[index] = new ThemeDataPresentation(data.data, m_model.GetThemeDescription(data.ParentID));
                }
                m_modifications?.Add(Modification<ThemeDataPresentation>.Update(data, originalData));
                IsDataDirty = true;
            }
        }

        public void DeleteTheme(ThemeDataPresentation data)
        {
            if ((Themes != null) && (m_model != null))
            {
                Themes.Remove(new ThemeDataPresentation(data.data, m_model.GetThemeDescription(data.ParentID)));
                m_modifications?.Add(Modification<ThemeDataPresentation>.Delete(data));
                IsDataDirty = true;
            }
        }

        private void RefreshThemes()
        {
            m_model?.RefreshThemes();
            Themes = m_model?.Themes;
        }
        public void ResetThemes()
        {
            m_modifications?.Clear();
            RefreshThemes();
            IsDataDirty = false;
        }

        public void SaveThemes()
        {
            m_model?.SaveModifications(m_modifications);
            m_modifications?.Clear();
            RefreshThemes();
            IsDataDirty = false;
        }

        public string ThemeImagePath
        {
            get
            {
                return m_imagePath;
            }
            set { m_imagePath = value; base.RaisePropertyChangedEvent("ThemeImagePath"); }
        }

        public ObservableCollection<ThemeDataPresentation>? Themes
        {
            get
            {
                return m_sets;
            }

            set
            {
                m_sets = value;
                base.RaisePropertyChangedEvent("Themes");
            }
        }

        public Model.Model? Model
        {
            get { return m_model; }
            set { m_model = value; base.RaisePropertyChangedEvent("Model"); }
        }
        public ThemeDataPresentation? SelectedItem
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
