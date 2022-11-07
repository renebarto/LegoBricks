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
    public class BrickTypesViewModel : ViewModelBase
    {
        private Model.Model? m_model;
        private ObservableCollection<BrickTypeData>? m_BrickTypes;
        private BrickTypeData? m_selectedItem;
        private bool m_isItemSelected;
        private bool m_isDataDirty;
        private List<Modification<BrickTypeData>>? m_modifications;

        public BrickTypesViewModel(Model.Model? model)
        {
            this.Initialize(model);
        }

        private void Initialize(Model.Model? model)
        {
            m_model = model;
            RefreshBrickTypes();

            m_modifications = new List<Modification<BrickTypeData>>();
        }

        public void AddBrickType(BrickTypeData data)
        {
            if (BrickTypes != null)
            {
                BrickTypes.Add(data);
                m_modifications?.Add(Modification<BrickTypeData>.Add(data));
                IsDataDirty = true;
            }
        }

        public void ChangeBrickType(BrickTypeData data, BrickTypeData originalData)
        {
            if (BrickTypes != null)
            {
                var index = BrickTypes.IndexOf(originalData);
                if (index != -1)
                {
                    BrickTypes[index] = data;
                }
                m_modifications?.Add(Modification<BrickTypeData>.Update(data, originalData));
                IsDataDirty = true;
            }
        }

        public void DeleteBrickType(BrickTypeData data)
        {
            if (BrickTypes != null)
            {
                BrickTypes.Remove(data);
                m_modifications?.Add(Modification<BrickTypeData>.Delete(data));
                IsDataDirty = true;
            }
        }

        private void RefreshBrickTypes()
        {
            m_model?.RefreshBrickTypes();
            BrickTypes = m_model?.BrickTypes;
        }
        public void ResetBrickTypes()
        {
            m_modifications?.Clear();
            RefreshBrickTypes();
            IsDataDirty = false;
        }

        public void SaveBrickTypes()
        {
            m_model?.SaveModifications(m_modifications);
            m_modifications?.Clear();
            RefreshBrickTypes();
            IsDataDirty = false;
        }

        public ObservableCollection<BrickTypeData>? BrickTypes
        {
            get
            {
                return m_BrickTypes;
            }

            set
            {
                m_BrickTypes = value;
                base.RaisePropertyChangedEvent("BrickTypes");
            }
        }

        public Model.Model? Model
        {
            get { return m_model; }
            set { m_model = value; base.RaisePropertyChangedEvent("Model"); }
        }
        public BrickTypeData? SelectedItem
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
