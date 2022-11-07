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
    public class SetsViewModel : ViewModelBase
    {
        private Model.Model? m_model;
        private ObservableCollection<SetDataPresentation>? m_sets;
        private SetDataPresentation? m_selectedItem;
        private bool m_isItemSelected;
        private bool m_isDataDirty;
        private List<Modification<SetDataPresentation>>? m_modifications;
        private string m_imagePath;

        public SetsViewModel(Model.Model? model)
        {
            this.Initialize(model);
            m_imagePath = "";
            this.PropertyChanged += OnPropertyChanged;
        }

        private void OnPropertyChanged(object? sender, System.ComponentModel.PropertyChangedEventArgs e)
        {
            switch (e.PropertyName)
            {
                case "SelectedItem":
                    if (SelectedItem != null)
                    {
                        SetImagePath = Helpers.GetAbsolutePath(String.Format("media/sets/{0}.jpg", ((SetDataPresentation)SelectedItem).Id));
                    }
                    else
                    {
                        SetImagePath = "";
                    }
                    break;
                default:
                    break;
            }
        }


        private void Initialize(Model.Model? model)
        {
            m_model = model;
            RefreshSets();

            m_modifications = new List<Modification<SetDataPresentation>>();
        }

        public void AddSet(SetDataPresentation data)
        {
            if (Sets != null)
            {
                Sets.Add(data);
                m_modifications?.Add(Modification<SetDataPresentation>.Add(data));
                IsDataDirty = true;
            }
        }

        public void ChangeSet(SetDataPresentation data, SetDataPresentation originalData)
        {
            if ((Sets != null) && (m_model != null))
            {
                var index = m_model.FindSet(originalData.Id);
                if (index != -1)
                {
                    Sets[index] = new SetDataPresentation(data.data, m_model.GetThemeDescription(data.ThemeID));
                }
                m_modifications?.Add(Modification<SetDataPresentation>.Update(data, originalData));
                IsDataDirty = true;
            }
        }

        public void DeleteSet(SetDataPresentation data)
        {
            if ((Sets != null) && (m_model != null))
            {
                Sets.Remove(new SetDataPresentation(data.data, m_model.GetThemeDescription(data.ThemeID)));
                m_modifications?.Add(Modification<SetDataPresentation>.Delete(data));
                IsDataDirty = true;
            }
        }

        private void RefreshSets()
        {
            m_model?.RefreshSets();
            Sets = m_model?.Sets;
        }
        public void ResetSets()
        {
            m_modifications?.Clear();
            RefreshSets();
            IsDataDirty = false;
        }

        public void SaveSets()
        {
            m_model?.SaveModifications(m_modifications);
            m_modifications?.Clear();
            RefreshSets();
            IsDataDirty = false;
        }

        public string SetImagePath
        {
            get
            {
                return m_imagePath;
            }
            set { m_imagePath = value; base.RaisePropertyChangedEvent("SetImagePath"); }
        }

        public ObservableCollection<SetDataPresentation>? Sets
        {
            get
            {
                return m_sets;
            }

            set
            {
                m_sets = value;
                base.RaisePropertyChangedEvent("Sets");
            }
        }

        public Model.Model? Model
        {
            get { return m_model; }
            set { m_model = value; base.RaisePropertyChangedEvent("Model"); }
        }
        public SetDataPresentation? SelectedItem
        {
            get { return m_selectedItem; }
            set { m_selectedItem = value; IsItemSelected = (m_selectedItem != null); base.RaisePropertyChangedEvent("SelectedItem"); }
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
