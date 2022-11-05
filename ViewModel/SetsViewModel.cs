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
    //public struct SetsModification
    //{
    //    public ModifyOperation operation;
    //    public SetData data;
    //    public SetData originalData;

    //    public static SetsModification Add(SetData data)
    //    {
    //        SetsModification result = new SetsModification();
    //        result.operation = ModifyOperation.Add;
    //        result.data = data;
    //        return result;
    //    }

    //    public static SetsModification Delete(SetData data)
    //    {
    //        SetsModification result = new SetsModification();
    //        result.operation = ModifyOperation.Delete;
    //        result.data = data;
    //        return result;
    //    }

    //    public static SetsModification Update(SetData data, SetData originalData)
    //    {
    //        SetsModification result = new SetsModification();
    //        result.operation = ModifyOperation.Update;
    //        result.data = data;
    //        result.originalData = originalData;
    //        return result;
    //    }
    //}

    public class SetsViewModel : ViewModelBase
    {
        private Model.Model? m_model;
        //private ObservableCollection<SetData>? m_brickCategories;
        //private SetData? m_selectedItem;
        private bool m_isItemSelected;
        private bool m_isDataDirty;
        //private List<SetsModification>? m_modifications;

        public SetsViewModel(Model.Model? model)
        {
            this.Initialize(model);
        }

        private void Initialize(Model.Model? model)
        {
            m_model = model;
            //    RefreshSets();

            //    m_modifications = new List<SetsModification>();

            //    // Initialize commands
            //    this.AddSetCommand = new Commands.AddSet(this);
            //    this.EditSetCommand = new Commands.EditSet(this);
            //    this.DeleteSetCommand = new Commands.EditSet(this);
        }

        //#region Command Properties

        ///// <summary>
        ///// Add a new Set.
        ///// </summary>
        //public ICommand? AddSetCommand { get; set; }

        ///// <summary>
        ///// Edit selected Set.
        ///// </summary>
        //public ICommand? EditSetCommand { get; set; }

        ///// <summary>
        ///// Delete selected Set.
        ///// </summary>
        //public ICommand? DeleteSetCommand { get; set; }

        //#endregion

        //public void AddSet(SetData data)
        //{
        //    if (Sets != null)
        //    {
        //        Sets.Add(data);
        //    }
        //    m_modifications?.Add(SetsModification.Add(data));
        //    IsDataDirty = true;
        //}

        //public void ChangeSet(SetData data, SetData originalData)
        //{
        //    if (Sets != null)
        //    {
        //        var index = Sets.IndexOf(originalData);
        //        if (index != -1)
        //        {
        //            Sets[index] = data;
        //        }
        //    }
        //    m_modifications?.Add(SetsModification.Update(data, originalData));
        //    IsDataDirty = true;
        //}

        //public void DeleteSet(SetData data)
        //{
        //    if (Sets != null)
        //    {
        //        Sets.Remove(data);
        //    }
        //    m_modifications?.Add(SetsModification.Delete(data));
        //    IsDataDirty = true;
        //}

        //private void RefreshSets()
        //{
        //    m_model?.RefreshSets();
        //    Sets = m_model?.Sets;
        //}
        //public void ResetSets()
        //{
        //    m_modifications?.Clear();
        //    RefreshSets();
        //    IsDataDirty = false;
        //}

        //public void SaveSets()
        //{
        //    m_model?.SaveModifications(m_modifications);
        //    IsDataDirty = false;
        //}

        //public ObservableCollection<SetData>? Sets
        //{
        //    get 
        //    { 
        //        return m_brickCategories;
        //    }

        //    set
        //    {
        //        m_brickCategories = value;
        //        base.RaisePropertyChangedEvent("Sets");
        //    }
        //}

        //public Model.Model? Model
        //{
        //    get { return m_model; }
        //    set { m_model = value; base.RaisePropertyChangedEvent("Model"); }
        //}
        //public SetData? SelectedItem
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
