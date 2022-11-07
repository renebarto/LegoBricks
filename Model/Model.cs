using Google.Protobuf.WellKnownTypes;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Data;

namespace LegoBricks.Model
{
    public class Model : IDisposable
    {
        private Database? m_database;
        private DataTable? m_colorsDataTable;
        private ObservableCollection<ColorData>? m_colors;
        private DataTable? m_setsDataTable;
        private ObservableCollection<SetDataPresentation>? m_sets;
        private DataTable? m_themesDataTable;
        private ObservableCollection<ThemeDataPresentation>? m_themes;
        private DataTable? m_brickCategoriesDataTable;
        private ObservableCollection<BrickCategoryData>? m_brickCategories;
        private DataTable? m_brickTypesDataTable;
        private ObservableCollection<BrickTypeData>? m_brickTypes;
        private bool disposedValue;

        public Model(Database database)
        {
            m_database = database;
            m_database.Open();
            RefreshColors();
            RefreshSets();
            RefreshThemes();
            RefreshBrickCategories();
            RefreshBrickTypes();
        }

        public void OnPropertyChanged(string? propertyName)
        {

        }

        #region Colors

        public ObservableCollection<ColorData>? Colors
        {
            get
            {
                return m_colors;
            }
            private set
            {
                m_colors = value;
            }
        }

        public void RefreshColors()
        {
            m_database?.RefreshColors();
            m_colorsDataTable = m_database?.GetColors("Colors");
            m_colors = new ObservableCollection<ColorData>();
            if (m_colorsDataTable != null)
            {
                foreach (DataRow row in m_colorsDataTable.Rows)
                {
                    var data = Conversion.ColorConversion.ConvertRowToData(row);
                    m_colors.Add(data);
                }
            }
        }

        public int FindColor(int id)
        {
            int index = 0;
            if (Colors == null)
                return -1;
            foreach (ColorData data in Colors)
            {
                if (data.Id == id)
                    return index;
                ++index;
            }
            return -1;
        }

        public void SaveModifications(List<Modification<ColorData>>? modifications)
        {
            if (modifications == null)
                return;
            foreach (Modification<ColorData> modification in modifications)
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

        #endregion

        #region Sets

        public ObservableCollection<SetDataPresentation>? Sets
        {
            get
            {
                return m_sets;
            }
            private set
            {
                m_sets = value;
            }
        }

        public void RefreshSets()
        {
            m_database?.RefreshSets();
            m_setsDataTable = m_database?.GetSets("Sets");
            m_sets = new ObservableCollection<SetDataPresentation>();
            if (m_setsDataTable != null)
            {
                foreach (DataRow row in m_setsDataTable.Rows)
                {
                    var data = Conversion.SetConversion.ConvertRowToData(row);
                    var item = new SetDataPresentation(data, GetThemeDescription(data.ThemeID));
                    m_sets.Add(item);
                }
            }
        }

        public int FindSet(string id)
        {
            int index = 0;
            if (Sets == null)
                return -1;
            foreach (SetDataPresentation data in Sets)
            {
                if (data.Id == id)
                    return index;
                ++index;
            }
            return -1;
        }

        public void SaveModifications(List<Modification<SetDataPresentation>>? modifications)
        {
            if (modifications == null)
                return;
            foreach (Modification<SetDataPresentation> modification in modifications)
            {
                switch (modification.operation)
                {
                    case ModifyOperation.Add:
                        m_database?.AddToTable(modification.data.data);
                        break;
                    case ModifyOperation.Delete:
                        m_database?.DeleteFromTable(modification.data.data);
                        break;
                    case ModifyOperation.Update:
                        m_database?.UpdateTable(modification.data.data, modification.originalData.data.id);
                        break;
                }
            }
        }

        #endregion

        #region Themes

        public ObservableCollection<ThemeDataPresentation>? Themes
        {
            get
            {
                return m_themes;
            }
            private set
            {
                m_themes = value;
            }
        }

        public void RefreshThemes()
        {
            m_database?.RefreshThemes();
            m_themesDataTable = m_database?.GetThemes("Themes");
            m_themes = new ObservableCollection<ThemeDataPresentation>();
            if (m_themesDataTable != null)
            {
                foreach (DataRow row in m_themesDataTable.Rows)
                {
                    var data = Conversion.ThemeConversion.ConvertRowToData(row);
                    var item = new ThemeDataPresentation(data, GetThemeDescription(data.ParentID));
                    m_themes.Add(item);

                }
            }
        }

        public int FindTheme(Int32 id)
        {
            int index = 0;
            if (Themes == null)
                return -1;
            foreach (ThemeDataPresentation data in Themes)
            {
                if (data.Id == id)
                    return index;
                ++index;
            }
            return -1;
        }

        public String GetThemeName(int id)
        {
            if (Themes == null)
                return "-";
            var index = FindTheme(id);
            if (index != -1)
            {
                return Themes[index].Name;
            }
            return "-";
        }

        public String GetThemeDescription(int? id)
        {
            if ((Themes == null) || (id == null) || (m_database == null))
                return "-";
            var index = m_database.FindTheme(id.Value);
            if (index != -1)
            {
                return m_database.GetThemeName(id.Value) + " [" + id.ToString() + "]";
            }
            return "-";
        }

        public int ExtractThemeID(String item)
        {
            var parts = item.Split("-");
            int result;
            if (Int32.TryParse(parts[0], out result))
            {
                return result;
            }
            return -1;
        }

        public void SaveModifications(List<Modification<ThemeDataPresentation>>? modifications)
        {
            if (modifications == null)
                return;
            foreach (Modification<ThemeDataPresentation> modification in modifications)
            {
                switch (modification.operation)
                {
                    case ModifyOperation.Add:
                        m_database?.AddToTable(modification.data.data);
                        break;
                    case ModifyOperation.Delete:
                        m_database?.DeleteFromTable(modification.data.data);
                        break;
                    case ModifyOperation.Update:
                        m_database?.UpdateTable(modification.data.data, modification.originalData.data.id);
                        break;
                }
            }
        }

        #endregion

        #region Brick categories

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

        #endregion

        #region Brick types

        public ObservableCollection<BrickTypeData>? BrickTypes
        {
            get
            {
                return m_brickTypes;
            }
            private set
            {
                m_brickTypes = value;
            }
        }

        public void RefreshBrickTypes()
        {
            m_database?.RefreshBrickTypes();
            m_brickTypesDataTable = m_database?.GetBrickTypes("BrickTypes");
            m_brickTypes = new ObservableCollection<BrickTypeData>();
            if (m_brickTypesDataTable != null)
            {
                foreach (DataRow row in m_brickTypesDataTable.Rows)
                {
                    var data = Conversion.BrickTypeConversion.ConvertRowToData(row);
                    m_brickTypes.Add(data);
                }
            }
        }

        public int FindBrickType(int id)
        {
            int index = 0;
            if (BrickTypes == null)
                return -1;
            foreach (BrickTypeData data in BrickTypes)
            {
                if (data.id == id)
                    return index;
                ++index;
            }
            return -1;
        }

        public void SaveModifications(List<Modification<BrickTypeData>>? modifications)
        {
            if (modifications == null)
                return;
            foreach (Modification<BrickTypeData> modification in modifications)
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

        #endregion

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
                // TODO: theme large fields to null
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
