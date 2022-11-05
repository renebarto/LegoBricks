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
    //public struct PartsModification
    //{
    //    public ModifyOperation operation;
    //    public PartData data;
    //    public PartData originalData;

    //    public static PartsModification Add(PartData data)
    //    {
    //        PartsModification result = new PartsModification();
    //        result.operation = ModifyOperation.Add;
    //        result.data = data;
    //        return result;
    //    }

    //    public static PartsModification Delete(PartData data)
    //    {
    //        PartsModification result = new PartsModification();
    //        result.operation = ModifyOperation.Delete;
    //        result.data = data;
    //        return result;
    //    }

    //    public static PartsModification Update(PartData data, PartData originalData)
    //    {
    //        PartsModification result = new PartsModification();
    //        result.operation = ModifyOperation.Update;
    //        result.data = data;
    //        result.originalData = originalData;
    //        return result;
    //    }
    //}

    public class PartsViewModel : ViewModelBase
    {
        private Model.Model? m_model;
        //private ObservableCollection<PartData>? m_brickCategories;
        //private PartData? m_selectedItem;
        private bool m_isItemSelected;
        private bool m_isDataDirty;
        //private List<PartsModification>? m_modifications;

        public PartsViewModel(Model.Model? model)
        {
            this.Initialize(model);
        }

        private void Initialize(Model.Model? model)
        {
            m_model = model;
            //    RefreshParts();

            //    m_modifications = new List<PartsModification>();

            //    // Initialize commands
            //    this.AddPartCommand = new Commands.AddPart(this);
            //    this.EditPartCommand = new Commands.EditPart(this);
            //    this.DeletePartCommand = new Commands.EditPart(this);
        }

        //#region Command Properties

        ///// <summary>
        ///// Add a new Part.
        ///// </summary>
        //public ICommand? AddPartCommand { get; set; }

        ///// <summary>
        ///// Edit selected Part.
        ///// </summary>
        //public ICommand? EditPartCommand { get; set; }

        ///// <summary>
        ///// Delete selected Part.
        ///// </summary>
        //public ICommand? DeletePartCommand { get; set; }

        //#endregion

        //public void AddPart(PartData data)
        //{
        //    if (Parts != null)
        //    {
        //        Parts.Add(data);
        //    }
        //    m_modifications?.Add(PartsModification.Add(data));
        //    IsDataDirty = true;
        //}

        //public void ChangePart(PartData data, PartData originalData)
        //{
        //    if (Parts != null)
        //    {
        //        var index = Parts.IndexOf(originalData);
        //        if (index != -1)
        //        {
        //            Parts[index] = data;
        //        }
        //    }
        //    m_modifications?.Add(PartsModification.Update(data, originalData));
        //    IsDataDirty = true;
        //}

        //public void DeletePart(PartData data)
        //{
        //    if (Parts != null)
        //    {
        //        Parts.Remove(data);
        //    }
        //    m_modifications?.Add(PartsModification.Delete(data));
        //    IsDataDirty = true;
        //}

        //private void RefreshParts()
        //{
        //    m_model?.RefreshParts();
        //    Parts = m_model?.Parts;
        //}
        //public void ResetParts()
        //{
        //    m_modifications?.Clear();
        //    RefreshParts();
        //    IsDataDirty = false;
        //}

        //public void SaveParts()
        //{
        //    m_model?.SaveModifications(m_modifications);
        //    IsDataDirty = false;
        //}

        //public ObservableCollection<PartData>? Parts
        //{
        //    get 
        //    { 
        //        return m_brickCategories;
        //    }

        //    set
        //    {
        //        m_brickCategories = value;
        //        base.RaisePropertyChangedEvent("Parts");
        //    }
        //}

        //public Model.Model? Model
        //{
        //    get { return m_model; }
        //    set { m_model = value; base.RaisePropertyChangedEvent("Model"); }
        //}
        //public PartData? SelectedItem
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
