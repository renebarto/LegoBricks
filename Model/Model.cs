using LegoBricks;
using Microsoft.VisualBasic;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

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
            m_brickCategoriesDataTable = m_database.GetBrickCategories("BrickCategories");
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

        public void UpdateBrickCategories(ObservableCollection<BrickCategoryData>? brickCategories)
        {

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
