using LegoBricks.Model;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Controls;
using System.Windows.Input;
using System.Xml.Linq;

namespace LegoBricks.ViewModel
{
    public class ThemeEditViewModel : ViewModelBase
    {
        private bool m_checkExisting;
        private Model.Model? m_model;
        private string? m_id;
        private string? m_name;
        private string? m_parentID;
        private ObservableCollection<ThemeDataEditPresentation> m_themesSourceComboBox;

        public ThemeEditViewModel(Model.Model? model, bool checkExisting)
        {
            m_model = model;
            m_checkExisting = checkExisting;
            m_themesSourceComboBox = new ObservableCollection<ThemeDataEditPresentation>();
            if ((m_model != null) && (m_model.Themes != null))
            {
                foreach (var themeData in m_model.Themes)
                {
                    m_themesSourceComboBox.Add(new ThemeDataEditPresentation(themeData.data, ThemeItem(themeData.data)));
                }
                m_themesSourceComboBox.Add(new ThemeDataEditPresentation(new ThemeData(), "-"));
            }
            ThemeParentID = m_themesSourceComboBox[0].ThemeDescription;
        }

        private string ThemeItem(ThemeData data)
        {
            return data.Id.ToString() + "-" + data.Name;
        }
        public String ThemeID
        {
            get { return m_id ?? ""; }
            set { m_id = value; base.RaisePropertyChangedEvent("ThemeID"); }
        }
        public String ThemeName
        {
            get { return m_name ?? ""; }
            set { m_name = value; base.RaisePropertyChangedEvent("ThemeName"); }
        }
        public String ThemeParentID
        {
            get { return m_parentID ?? ""; }
            set
            {
                if ((m_model != null) && (m_model.Themes != null))
                {
                    if (String.IsNullOrEmpty(value))
                    {
                        m_parentID = "";
                    }
                    else
                    {
                        var parts = value.Split("-");
                        if (parts.Length == 1)
                        {
                            int id;
                            if (Int32.TryParse(parts[0], out id))
                            {
                                var index = m_model.FindTheme(id);
                                if (index != -1)
                                {
                                    var themeData = m_model.Themes[index].data;
                                    m_parentID = ThemeItem(themeData);
                                }
                            }
                            else
                            {
                                int index = 0;
                                foreach (ThemeDataPresentation themeData in m_model.Themes)
                                {
                                    if (themeData.Name.Contains(parts[0], StringComparison.InvariantCultureIgnoreCase))
                                    {
                                        m_parentID = ThemeItem(themeData.data);
                                        break;
                                    }
                                    index++;
                                }
                            }
                        }
                        else if (parts.Length == 2)
                        {
                            try
                            {
                                int id = Int32.Parse(parts[0]);
                                var index = m_model.FindTheme(id);
                                if (index != -1)
                                {
                                    var themeData = m_model.Themes[index];
                                    m_parentID = ThemeItem(themeData.data);
                                }
                            }
                            catch (Exception /*e*/)
                            {
                                m_parentID = "-";
                            }
                        }
                        else
                            return;
                    }
                }
                base.RaisePropertyChangedEvent("ThemeParentID");
            }
        }
        public ObservableCollection<ThemeDataEditPresentation> ThemesSource
        {
            get { return m_themesSourceComboBox; }
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
