using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Data;

namespace LegoBricks.Model
{
    public class Model : IDisposable
    {
        private Database? m_database;
        private DataTable? m_brickCategoriesDataTable;
        private ObservableCollection<BrickCategoryData>? m_brickCategories;
        private bool disposedValue;

        public Model(Database database)
        {
            m_database = database;
            m_database.Open();
            RefreshBrickCategories();
        }

        public void OnPropertyChanged(string? propertyName)
        {

        }

        public ObservableCollection<BrickCategoryData>? BrickCategories
        {
            get
            {
                return m_brickCategories;
            }
            private set
            {
                m_brickCategories = value;
            }
        }

        public void RefreshBrickCategories()
        {
            m_database?.RefreshBrickCategories();
            m_brickCategoriesDataTable = m_database?.GetBrickCategories("BrickCategories");
            m_brickCategories = new ObservableCollection<BrickCategoryData>();
            if (m_brickCategoriesDataTable != null)
            {
                foreach (DataRow row in m_brickCategoriesDataTable.Rows)
                {
                    var data = Conversion.BrickCategoryConversion.ConvertRowToData(row);
                    m_brickCategories.Add(data);
                }
            }
        }

        public int FindBrickCategory(int id)
        {
            int index = 0;
            if (BrickCategories == null)
                return -1;
            foreach (BrickCategoryData data in BrickCategories)
            {
                if (data.id == id)
                    return index;
                ++index;
            }
            return -1;
        }

        public void SaveModifications(List<Modification<BrickCategoryData>>? modifications)
        {
            if (modifications == null)
                return;
            foreach (Modification<BrickCategoryData> modification in modifications)
            {
                switch (modification.operation)
                {
                    case ModifyOperation.Add:
                        m_database?.AddToTable(modification.data);
                        break;
                    case ModifyOperation.Delete:
                        m_database?.DeleteFromTable(modification.data);
                        break;
                    case ModifyOperation.Update:
                        m_database?.UpdateTable(modification.data, modification.originalData.id);
                        break;
                }
            }
        }

        protected virtual void Dispose(bool disposing)
        {
            if (!disposedValue)
            {
                if (disposing)
                {
                    m_database?.Close();
                    // TODO: dispose managed state (managed objects)
                }

                // TODO: free unmanaged resources (unmanaged objects) and override finalizer
                // TODO: set large fields to null
                m_database = null;
                disposedValue = true;
            }
        }

        // // TODO: override finalizer only if 'Dispose(bool disposing)' has code to free unmanaged resources
        // ~Model()
        // {
        //     // Do not change this code. Put cleanup code in 'Dispose(bool disposing)' method
        //     Dispose(disposing: false);
        // }

        public void Dispose()
        {
            // Do not change this code. Put cleanup code in 'Dispose(bool disposing)' method
            Dispose(disposing: true);
            GC.SuppressFinalize(this);
        }
    }
}
