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
    //public struct ElementsModification
    //{
    //    public ModifyOperation operation;
    //    public ElementData data;
    //    public ElementData originalData;

    //    public static ElementsModification Add(ElementData data)
    //    {
    //        ElementsModification result = new ElementsModification();
    //        result.operation = ModifyOperation.Add;
    //        result.data = data;
    //        return result;
    //    }

    //    public static ElementsModification Delete(ElementData data)
    //    {
    //        ElementsModification result = new ElementsModification();
    //        result.operation = ModifyOperation.Delete;
    //        result.data = data;
    //        return result;
    //    }

    //    public static ElementsModification Update(ElementData data, ElementData originalData)
    //    {
    //        ElementsModification result = new ElementsModification();
    //        result.operation = ModifyOperation.Update;
    //        result.data = data;
    //        result.originalData = originalData;
    //        return result;
    //    }
    //}

    public class ElementsViewModel : ViewModelBase
    {
        private Model.Model? m_model;
        //private ObservableCollection<ElementData>? m_brickCategories;
        //private ElementData? m_selectedItem;
        private bool m_isItemSelected;
        private bool m_isDataDirty;
        //private List<ElementsModification>? m_modifications;

        public ElementsViewModel(Model.Model? model)
        {
            this.Initialize(model);
        }

        private void Initialize(Model.Model? model)
        {
            m_model = model;
            //    RefreshElements();

            //    m_modifications = new List<ElementsModification>();

            //    // Initialize commands
            //    this.AddElementCommand = new Commands.AddElement(this);
            //    this.EditElementCommand = new Commands.EditElement(this);
            //    this.DeleteElementCommand = new Commands.EditElement(this);
        }

        //#region Command Properties

        ///// <summary>
        ///// Add a new Element.
        ///// </summary>
        //public ICommand? AddElementCommand { get; set; }

        ///// <summary>
        ///// Edit selected Element.
        ///// </summary>
        //public ICommand? EditElementCommand { get; set; }

        ///// <summary>
        ///// Delete selected Element.
        ///// </summary>
        //public ICommand? DeleteElementCommand { get; set; }

        //#endregion

        //public void AddElement(ElementData data)
        //{
        //    if (Elements != null)
        //    {
        //        Elements.Add(data);
        //    }
        //    m_modifications?.Add(ElementsModification.Add(data));
        //    IsDataDirty = true;
        //}

        //public void ChangeElement(ElementData data, ElementData originalData)
        //{
        //    if (Elements != null)
        //    {
        //        var index = Elements.IndexOf(originalData);
        //        if (index != -1)
        //        {
        //            Elements[index] = data;
        //        }
        //    }
        //    m_modifications?.Add(ElementsModification.Update(data, originalData));
        //    IsDataDirty = true;
        //}

        //public void DeleteElement(ElementData data)
        //{
        //    if (Elements != null)
        //    {
        //        Elements.Remove(data);
        //    }
        //    m_modifications?.Add(ElementsModification.Delete(data));
        //    IsDataDirty = true;
        //}

        //private void RefreshElements()
        //{
        //    m_model?.RefreshElements();
        //    Elements = m_model?.Elements;
        //}
        //public void ResetElements()
        //{
        //    m_modifications?.Clear();
        //    RefreshElements();
        //    IsDataDirty = false;
        //}

        //public void SaveElements()
        //{
        //    m_model?.SaveModifications(m_modifications);
        //    IsDataDirty = false;
        //}

        //public ObservableCollection<ElementData>? Elements
        //{
        //    get 
        //    { 
        //        return m_brickCategories;
        //    }

        //    set
        //    {
        //        m_brickCategories = value;
        //        base.RaisePropertyChangedEvent("Elements");
        //    }
        //}

        //public Model.Model? Model
        //{
        //    get { return m_model; }
        //    set { m_model = value; base.RaisePropertyChangedEvent("Model"); }
        //}
        //public ElementData? SelectedItem
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
