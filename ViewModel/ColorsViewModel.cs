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
    //public struct ColorsModification
    //{
    //    public ModifyOperation operation;
    //    public ColorData data;
    //    public ColorData originalData;

    //    public static ColorsModification Add(ColorData data)
    //    {
    //        ColorsModification result = new ColorsModification();
    //        result.operation = ModifyOperation.Add;
    //        result.data = data;
    //        return result;
    //    }

    //    public static ColorsModification Delete(ColorData data)
    //    {
    //        ColorsModification result = new ColorsModification();
    //        result.operation = ModifyOperation.Delete;
    //        result.data = data;
    //        return result;
    //    }

    //    public static ColorsModification Update(ColorData data, ColorData originalData)
    //    {
    //        ColorsModification result = new ColorsModification();
    //        result.operation = ModifyOperation.Update;
    //        result.data = data;
    //        result.originalData = originalData;
    //        return result;
    //    }
    //}

    public class ColorsViewModel : ViewModelBase
    {
        private Model.Model? m_model;
        //private ObservableCollection<ColorData>? m_brickCategories;
        //private ColorData? m_selectedItem;
        private bool m_isItemSelected;
        private bool m_isDataDirty;
        //private List<ColorsModification>? m_modifications;

        public ColorsViewModel(Model.Model? model)
        {
            this.Initialize(model);
        }

        private void Initialize(Model.Model? model)
        {
            m_model = model;
            //    RefreshColors();

            //    m_modifications = new List<ColorsModification>();

            //    // Initialize commands
            //    this.AddColorCommand = new Commands.AddColor(this);
            //    this.EditColorCommand = new Commands.EditColor(this);
            //    this.DeleteColorCommand = new Commands.EditColor(this);
        }

        //#region Command Properties

        ///// <summary>
        ///// Add a new Color.
        ///// </summary>
        //public ICommand? AddColorCommand { get; set; }

        ///// <summary>
        ///// Edit selected Color.
        ///// </summary>
        //public ICommand? EditColorCommand { get; set; }

        ///// <summary>
        ///// Delete selected Color.
        ///// </summary>
        //public ICommand? DeleteColorCommand { get; set; }

        //#endregion

        //public void AddColor(ColorData data)
        //{
        //    if (Colors != null)
        //    {
        //        Colors.Add(data);
        //    }
        //    m_modifications?.Add(ColorsModification.Add(data));
        //    IsDataDirty = true;
        //}

        //public void ChangeColor(ColorData data, ColorData originalData)
        //{
        //    if (Colors != null)
        //    {
        //        var index = Colors.IndexOf(originalData);
        //        if (index != -1)
        //        {
        //            Colors[index] = data;
        //        }
        //    }
        //    m_modifications?.Add(ColorsModification.Update(data, originalData));
        //    IsDataDirty = true;
        //}

        //public void DeleteColor(ColorData data)
        //{
        //    if (Colors != null)
        //    {
        //        Colors.Remove(data);
        //    }
        //    m_modifications?.Add(ColorsModification.Delete(data));
        //    IsDataDirty = true;
        //}

        //private void RefreshColors()
        //{
        //    m_model?.RefreshColors();
        //    Colors = m_model?.Colors;
        //}
        //public void ResetColors()
        //{
        //    m_modifications?.Clear();
        //    RefreshColors();
        //    IsDataDirty = false;
        //}

        //public void SaveColors()
        //{
        //    m_model?.SaveModifications(m_modifications);
        //    IsDataDirty = false;
        //}

        //public ObservableCollection<ColorData>? Colors
        //{
        //    get 
        //    { 
        //        return m_brickCategories;
        //    }

        //    set
        //    {
        //        m_brickCategories = value;
        //        base.RaisePropertyChangedEvent("Colors");
        //    }
        //}

        //public Model.Model? Model
        //{
        //    get { return m_model; }
        //    set { m_model = value; base.RaisePropertyChangedEvent("Model"); }
        //}
        //public ColorData? SelectedItem
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
