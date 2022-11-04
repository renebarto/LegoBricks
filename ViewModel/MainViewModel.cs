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
    public class MainViewModel : ViewModelBase
    {
        private Model.Model? m_model;
        private BrickCategoryData? m_selectedItem;
        private bool m_isItemSelected;
        private bool m_isDataDirty;

        public MainViewModel(Model.Model model)
        {
            this.Initialize(model);
        }

        private void Initialize(Model.Model model)
        {
            m_model = model;

            // Initialize commands
            this.AddBrickCategoryCommand = new Commands.AddBrickCategory(this);
            this.EditBrickCategoryCommand = new Commands.EditBrickCategory(this);
            this.DeleteBrickCategoryCommand = new Commands.EditBrickCategory(this);
        }

        #region Command Properties

        /// <summary>
        /// Add a new BrickCategory.
        /// </summary>
        public ICommand? AddBrickCategoryCommand { get; set; }

        /// <summary>
        /// Edit selected BrickCategory.
        /// </summary>
        public ICommand? EditBrickCategoryCommand { get; set; }

        /// <summary>
        /// Delete selected BrickCategory.
        /// </summary>
        public ICommand? DeleteBrickCategoryCommand { get; set; }

        #endregion

        public void AddBrickCategory(BrickCategoryData data)
        {
            if (BrickCategories != null)
            {
                BrickCategories.Add(data);
            }
            IsDataDirty = true;
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
            }
            IsDataDirty = true;
        }

        public void DeleteBrickCategory(BrickCategoryData data)
        {
            if (BrickCategories != null)
            {
                BrickCategories.Remove(data);
            }
            IsDataDirty = true;
        }

        public void ResetBrickCategories()
        {
            IsDataDirty = false;
        }

        public void SaveBrickCategories()
        {
            IsDataDirty = false;
        }

        public ObservableCollection<BrickCategoryData>? BrickCategories
        {
            get 
            { 
                return (m_model != null) ? m_model.BrickCategories : null;
            }

            set
            {
                if (m_model != null)
                {
                    m_model.UpdateBrickCategories(value);
                }
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
