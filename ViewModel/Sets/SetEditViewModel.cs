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
    public class SetEditViewModel : ViewModelBase
    {
        private bool m_checkExisting;
        private Model.Model? m_model;
        private string? m_id;
        private string? m_name;
        private string? m_partCount;
        private string? m_themeID;
        private string? m_year;
        private ObservableCollection<String> m_themesSourceComboBox;

        public SetEditViewModel(Model.Model? model, bool checkExisting)
        {
            m_model = model;
            m_checkExisting = checkExisting;
            m_themesSourceComboBox = new ObservableCollection<String>();
            if ((m_model != null) && (m_model.Themes != null))
            {
                foreach (var themeData in m_model.Themes)
                {
                    m_themesSourceComboBox.Add(ThemeItem(themeData.data));
                }
            }
            SetThemeID = m_themesSourceComboBox[0];
        }

        private string ThemeItem(ThemeData data)
        {
            return data.Id.ToString() + "-" + data.Name;
        }
        public String SetID
        {
            get { return m_id ?? ""; }
            set { m_id = value; base.RaisePropertyChangedEvent("SetID"); }
        }
        public String SetName
        {
            get { return m_name ?? ""; }
            set { m_name = value; base.RaisePropertyChangedEvent("SetName"); }
        }
        public String SetPartCount
        {
            get { return m_partCount ?? ""; }
            set { m_partCount = value; base.RaisePropertyChangedEvent("SetPartCount"); }
        }
        public String SetThemeID
        {
            get { return m_themeID ?? ""; }
            set
            {
                if ((m_model != null) && (m_model.Themes != null))
                {
                    if (String.IsNullOrEmpty(value))
                    {
                        m_themeID = "";
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
                                    m_themeID = ThemeItem(themeData);
                                }
                            }
                            else
                            {
                                int index = 0;
                                foreach (ThemeDataPresentation themeData in m_model.Themes)
                                {
                                    if (themeData.Name.Contains(parts[0], StringComparison.InvariantCultureIgnoreCase))
                                    {
                                        m_themeID = ThemeItem(themeData.data);
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
                                    m_themeID = ThemeItem(themeData.data);
                                }
                            }
                            catch (Exception /*e*/)
                            {
                            }
                        }
                        else
                            return;
                    }
                }
                base.RaisePropertyChangedEvent("SetThemeID");
            }
        }
        public String SetYear
        {
            get { return m_year ?? ""; }
            set { m_year = value; base.RaisePropertyChangedEvent("SetYear"); }
        }
        public ObservableCollection<String> ThemesSource
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
