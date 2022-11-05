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
    //public struct ThemesModification
    //{
    //    public ModifyOperation operation;
    //    public ThemeData data;
    //    public ThemeData originalData;

    //    public static ThemesModification Add(ThemeData data)
    //    {
    //        ThemesModification result = new ThemesModification();
    //        result.operation = ModifyOperation.Add;
    //        result.data = data;
    //        return result;
    //    }

    //    public static ThemesModification Delete(ThemeData data)
    //    {
    //        ThemesModification result = new ThemesModification();
    //        result.operation = ModifyOperation.Delete;
    //        result.data = data;
    //        return result;
    //    }

    //    public static ThemesModification Update(ThemeData data, ThemeData originalData)
    //    {
    //        ThemesModification result = new ThemesModification();
    //        result.operation = ModifyOperation.Update;
    //        result.data = data;
    //        result.originalData = originalData;
    //        return result;
    //    }
    //}

    public class ThemesViewModel : ViewModelBase
    {
        private Model.Model? m_model;
        //private ObservableCollection<ThemeData>? m_brickCategories;
        //private ThemeData? m_selectedItem;
        private bool m_isItemSelected;
        private bool m_isDataDirty;
        //private List<ThemesModification>? m_modifications;

        public ThemesViewModel(Model.Model? model)
        {
            this.Initialize(model);
        }

        private void Initialize(Model.Model? model)
        {
            m_model = model;
            //RefreshThemes();

            //m_modifications = new List<ThemesModification>();

            // Initialize commands
            //this.AddThemeCommand = new Commands.AddTheme(this);
            //this.EditThemeCommand = new Commands.EditTheme(this);
            //this.DeleteThemeCommand = new Commands.EditTheme(this);
        }

        //#region Command Properties

        ///// <summary>
        ///// Add a new Theme.
        ///// </summary>
        //public ICommand? AddThemeCommand { get; set; }

        ///// <summary>
        ///// Edit selected Theme.
        ///// </summary>
        //public ICommand? EditThemeCommand { get; set; }

        ///// <summary>
        ///// Delete selected Theme.
        ///// </summary>
        //public ICommand? DeleteThemeCommand { get; set; }

        //#endregion

        //public void AddTheme(ThemeData data)
        //{
        //    if (Themes != null)
        //    {
        //        Themes.Add(data);
        //    }
        //    m_modifications?.Add(ThemesModification.Add(data));
        //    IsDataDirty = true;
        //}

        //public void ChangeTheme(ThemeData data, ThemeData originalData)
        //{
        //    if (Themes != null)
        //    {
        //        var index = Themes.IndexOf(originalData);
        //        if (index != -1)
        //        {
        //            Themes[index] = data;
        //        }
        //    }
        //    m_modifications?.Add(ThemesModification.Update(data, originalData));
        //    IsDataDirty = true;
        //}

        //public void DeleteTheme(ThemeData data)
        //{
        //    if (Themes != null)
        //    {
        //        Themes.Remove(data);
        //    }
        //    m_modifications?.Add(ThemesModification.Delete(data));
        //    IsDataDirty = true;
        //}

        //private void RefreshThemes()
        //{
        //    m_model?.RefreshThemes();
        //    Themes = m_model?.Themes;
        //}
        //public void ResetThemes()
        //{
        //    m_modifications?.Clear();
        //    RefreshThemes();
        //    IsDataDirty = false;
        //}

        //public void SaveThemes()
        //{
        //    m_model?.SaveModifications(m_modifications);
        //    IsDataDirty = false;
        //}

        //public ObservableCollection<ThemeData>? Themes
        //{
        //    get 
        //    { 
        //        return m_brickCategories;
        //    }

        //    set
        //    {
        //        m_brickCategories = value;
        //        base.RaisePropertyChangedEvent("Themes");
        //    }
        //}

        //public Model.Model? Model
        //{
        //    get { return m_model; }
        //    set { m_model = value; base.RaisePropertyChangedEvent("Model"); }
        //}
        //public ThemeData? SelectedItem
        //{
        //    get { return m_selectedItem; }
        //    set { m_selectedItem = value; IsItemSelected = (m_selectedItem != null); } 
        //}

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
