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
    public class BrickCategoriesViewModel : ViewModelBase
    {
        private Model.Model? m_model;
        private ObservableCollection<BrickCategoryData>? m_brickCategories;
        private BrickCategoryData? m_selectedItem;
        private bool m_isItemSelected;
        private bool m_isDataDirty;
        private List<Modification<BrickCategoryData>>? m_modifications;

        public BrickCategoriesViewModel(Model.Model? model)
        {
            this.Initialize(model);
        }

        private void Initialize(Model.Model? model)
        {
            m_model = model;
            RefreshBrickCategories();

            m_modifications = new List<Modification<BrickCategoryData>>();
        }

        public void AddBrickCategory(BrickCategoryData data)
        {
            if (BrickCategories != null)
            {
                BrickCategories.Add(data);
                m_modifications?.Add(Modification<BrickCategoryData>.Add(data));
                IsDataDirty = true;
            }
        }

        public void ChangeBrickCategory(BrickCategoryData data, BrickCategoryData originalData)
        {
            if (BrickCategories != null)
            {
                var index = BrickCategories.IndexOf(originalData);
                if (index != -1)
                {
                    BrickCategories[index] = data;
                }
                m_modifications?.Add(Modification<BrickCategoryData>.Update(data, originalData));
                IsDataDirty = true;
            }
        }

        public void DeleteBrickCategory(BrickCategoryData data)
        {
            if (BrickCategories != null)
            {
                BrickCategories.Remove(data);
                m_modifications?.Add(Modification<BrickCategoryData>.Delete(data));
                IsDataDirty = true;
            }
        }

        private void RefreshBrickCategories()
        {
            m_model?.RefreshBrickCategories();
            BrickCategories = m_model?.BrickCategories;
        }
        public void ResetBrickCategories()
        {
            m_modifications?.Clear();
            RefreshBrickCategories();
            IsDataDirty = false;
        }

        public void SaveBrickCategories()
        {
            m_model?.SaveModifications(m_modifications);
            m_modifications?.Clear();
            RefreshBrickCategories();
            IsDataDirty = false;
        }

        public ObservableCollection<BrickCategoryData>? BrickCategories
        {
            get 
            { 
                return m_brickCategories;
            }

            set
            {
                m_brickCategories = value;
                base.RaisePropertyChangedEvent("BrickCategories");
            }
        }

        public Model.Model? Model
        {
            get { return m_model; }
            set { m_model = value; base.RaisePropertyChangedEvent("Model"); }
        }
        public BrickCategoryData? SelectedItem
        {
            get { return m_selectedItem; }
            set { m_selectedItem = value; IsItemSelected = (m_selectedItem != null); } 
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
