using System;
using System.Configuration;
using System.Data;
using MySql.Data.MySqlClient;

namespace LegoBricks.Model
{
    public class Database
    {
        public MySql.Data.MySqlClient.MySqlConnection? Connection { get; private set; }
        public DataTable? ColorsTable { get; private set; }
        public DataTable? SetsTable { get; private set; }
        public DataTable? ThemesTable { get; private set; }
        public DataTable? BrickCategoriesTable { get; private set; }
        public DataTable? BrickTypesTable { get; private set; }

        public void Open()
        {
            Connection = new MySql.Data.MySqlClient.MySqlConnection(ConfigurationManager.ConnectionStrings["ConnectionString"].ConnectionString);
            Connection.Open();
            RefreshColors();
            RefreshSets();
            RefreshThemes();
            RefreshBrickCategories();
            RefreshBrickTypes();
        }

        public void Close()
        {
            Connection?.Close();
            Connection = null;
        }

        public bool IsOpen()
        {
            return Connection != null;
        }

        #region colors

        public DataTable? GetColors(string bindingName)
        {
            MySqlCommand command = new MySqlCommand("SELECT * FROM colors;", Connection);
            MySqlDataAdapter adapter = new MySqlDataAdapter(command);
            DataSet dataSet = new DataSet();
            adapter.Fill(dataSet, bindingName);
            return (dataSet.Tables.Count == 1) ? dataSet.Tables[0] : null;
        }

        public void RefreshColors()
        {
            ColorsTable = GetColors("Colors");
        }

        public int FindColor(int id)
        {
            if (ColorsTable != null)
            {
                var index = 0;
                foreach (DataRow row in ColorsTable.Rows)
                {
                    var colorID = row.Field<Int32>(0);
                    if (colorID == id)
                        return index;
                    index++;
                }
            }
            return -1;
        }

        public void UpdateTable(ColorData data, Int32 originalID)
        {
            string query = "UPDATE colors SET id=@id,name=@name,rgb=@RGB,transparent=@transparent WHERE id=@origID";
            MySqlCommand cmd = new MySqlCommand();
            cmd.CommandText = query;
            cmd.Parameters.AddWithValue("@origID", originalID);
            cmd.Parameters.AddWithValue("@id", data.id);
            cmd.Parameters.AddWithValue("@name", data.name);
            cmd.Parameters.AddWithValue("@rgb", data.rgb);
            cmd.Parameters.AddWithValue("@transparent", data.transparent ? 1 : 0);
            cmd.Connection = Connection;
            cmd.ExecuteNonQuery();
        }

        public void AddToTable(ColorData data)
        {
            string query = "INSERT INTO colors (id,name,rgb,transparent) VALUES (@id,@name,@RGB,@transparent)";
            MySqlCommand cmd = new MySqlCommand();
            cmd.CommandText = query;
            cmd.Parameters.AddWithValue("@id", data.id);
            cmd.Parameters.AddWithValue("@name", data.name);
            cmd.Parameters.AddWithValue("@rgb", data.rgb);
            cmd.Parameters.AddWithValue("@transparent", data.transparent ? 1 : 0);
            cmd.Connection = Connection;
            cmd.ExecuteNonQuery();
        }

        public void DeleteFromTable(ColorData data)
        {
            string query = "DELETE FROM colors WHERE @id=id";
            MySqlCommand cmd = new MySqlCommand();
            cmd.CommandText = query;
            cmd.Parameters.AddWithValue("@id", data.id);
            cmd.Connection = Connection;
            cmd.ExecuteNonQuery();
        }

        #endregion

        #region sets

        public DataTable? GetSets(string bindingName)
        {
            MySqlCommand command = new MySqlCommand("SELECT * FROM sets;", Connection);
            MySqlDataAdapter adapter = new MySqlDataAdapter(command);
            DataSet dataSet = new DataSet();
            adapter.Fill(dataSet, bindingName);
            return (dataSet.Tables.Count == 1) ? dataSet.Tables[0] : null;
        }

        public void RefreshSets()
        {
            SetsTable = GetSets("Sets");
        }

        public int FindSet(int id)
        {
            if (SetsTable != null)
            {
                var index = 0;
                foreach (DataRow row in SetsTable.Rows)
                {
                    var setID = row.Field<Int32>(0);
                    if (setID == id)
                        return index;
                    index++;
                }
            }
            return -1;
        }

        public void UpdateTable(SetData data, String originalID)
        {
            string query = "UPDATE sets SET id=@id,name=@name,part_count=@partCount,theme_id=@themeID,year=@year WHERE id=@origID";
            MySqlCommand cmd = new MySqlCommand();
            cmd.CommandText = query;
            cmd.Parameters.AddWithValue("@origID", originalID);
            cmd.Parameters.AddWithValue("@id", data.id);
            cmd.Parameters.AddWithValue("@name", data.name);
            cmd.Parameters.AddWithValue("@partCount", data.partCount);
            cmd.Parameters.AddWithValue("@themeID", data.themeID);
            cmd.Parameters.AddWithValue("@year", data.year);
            cmd.Connection = Connection;
            cmd.ExecuteNonQuery();
        }

        public void AddToTable(SetData data)
        {
            string query = "INSERT INTO sets (id,name,part_count,theme_id,year) VALUES (@id,@name,@partCount,@themeID,@year)";
            MySqlCommand cmd = new MySqlCommand();
            cmd.CommandText = query;
            cmd.Parameters.AddWithValue("@id", data.id);
            cmd.Parameters.AddWithValue("@name", data.name);
            cmd.Parameters.AddWithValue("@partCount", data.partCount);
            cmd.Parameters.AddWithValue("@themeID", data.themeID);
            cmd.Parameters.AddWithValue("@year", data.year);
            cmd.Connection = Connection;
            cmd.ExecuteNonQuery();
        }

        public void DeleteFromTable(SetData data)
        {
            string query = "DELETE FROM sets WHERE @id=id";
            MySqlCommand cmd = new MySqlCommand();
            cmd.CommandText = query;
            cmd.Parameters.AddWithValue("@id", data.id);
            cmd.Connection = Connection;
            cmd.ExecuteNonQuery();
        }

        #endregion

        #region themes

        public DataTable? GetThemes(string bindingName)
        {
            MySqlCommand command = new MySqlCommand("SELECT * FROM themes;", Connection);
            MySqlDataAdapter adapter = new MySqlDataAdapter(command);
            DataSet dataTheme = new DataSet();
            adapter.Fill(dataTheme, bindingName);
            return (dataTheme.Tables.Count == 1) ? dataTheme.Tables[0] : null;
        }

        public void RefreshThemes()
        {
            ThemesTable = GetThemes("Themes");
        }

        public int FindTheme(int id)
        {
            if (ThemesTable != null)
            {
                var index = 0;
                foreach (DataRow row in ThemesTable.Rows)
                {
                    var setID = row.Field<Int32>(0);
                    if (setID == id)
                        return index;
                    index++;
                }
            }
            return -1;
        }

        public void UpdateTable(ThemeData data, Int32 originalID)
        {
            string query = "UPDATE themes SET id=@id,name=@name,parent_id=@parentID WHERE id=@origID";
            MySqlCommand cmd = new MySqlCommand();
            cmd.CommandText = query;
            cmd.Parameters.AddWithValue("@origID", originalID);
            cmd.Parameters.AddWithValue("@id", data.id);
            cmd.Parameters.AddWithValue("@name", data.name);
            object parentID = DBNull.Value;
            if ((data.parentID != null) && (data.parentID != -1))
                parentID = data.parentID;
            cmd.Parameters.AddWithValue("@parentID", parentID);
            cmd.Connection = Connection;
            cmd.ExecuteNonQuery();
        }

        public void AddToTable(ThemeData data)
        {
            string query = "INSERT INTO themes (id,name,parent_id) VALUES (@id,@name,@parentID)";
            MySqlCommand cmd = new MySqlCommand();
            cmd.CommandText = query;
            cmd.Parameters.AddWithValue("@id", data.id);
            cmd.Parameters.AddWithValue("@name", data.name);
            object parentID = DBNull.Value;
            if ((data.parentID != null) && (data.parentID != -1))
                parentID = data.parentID;
            cmd.Parameters.AddWithValue("@parentID", parentID);
            cmd.Connection = Connection;
            cmd.ExecuteNonQuery();
        }

        public void DeleteFromTable(ThemeData data)
        {
            string query = "DELETE FROM themes WHERE @id=id";
            MySqlCommand cmd = new MySqlCommand();
            cmd.CommandText = query;
            cmd.Parameters.AddWithValue("@id", data.id);
            cmd.Connection = Connection;
            cmd.ExecuteNonQuery();
        }

        public string GetThemeName(Int32 id)
        {
            string query = "SELECT name FROM themes WHERE @id=id";
            MySqlCommand cmd = new MySqlCommand();
            cmd.CommandText = query;
            cmd.Parameters.AddWithValue("@id", id);
            cmd.Connection = Connection;
            MySqlDataAdapter adapter = new MySqlDataAdapter(cmd);
            DataTable table = new DataTable();
            adapter.Fill(table);
            string? name = null;
            if (table.Rows.Count == 1)
                name = (string?)table.Rows[0].Field<string>(0);
            return name ?? "";
        }

        #endregion

        #region brick_categories

        public DataTable? GetBrickCategories(string bindingName)
        {
            MySqlCommand command = new MySqlCommand("SELECT * FROM brick_categories;", Connection);
            MySqlDataAdapter adapter = new MySqlDataAdapter(command);
            DataSet dataSet = new DataSet();
            adapter.Fill(dataSet, bindingName);
            return (dataSet.Tables.Count == 1) ? dataSet.Tables[0] : null;
        }

        public void RefreshBrickCategories()
        {
            BrickCategoriesTable = GetBrickCategories("BrickCategories");
        }

        public int FindBrickCategory(int id)
        {
            if (BrickCategoriesTable != null)
            {
                var index = 0;
                foreach (DataRow row in BrickCategoriesTable.Rows)
                {
                    var brickCategoryID = row.Field<Int32>(0);
                    if (brickCategoryID == id)
                        return index;
                    index++;
                }
            }
            return -1;
        }

        public void UpdateTable(BrickCategoryData data, Int32 originalID)
        {
            string query = "UPDATE brick_categories SET id=@id,name=@name WHERE id=@originalID";
            MySqlCommand cmd = new MySqlCommand();
            cmd.CommandText = query;
            cmd.Parameters.AddWithValue("@id", data.id);
            cmd.Parameters.AddWithValue("@name", data.name);
            cmd.Parameters.AddWithValue("@originalID", originalID);
            cmd.Connection = Connection;
            cmd.ExecuteNonQuery();
        }

        public void AddToTable(BrickCategoryData data)
        {
            string query = "INSERT INTO brick_categories (id,name) VALUES (@id,@name)";
            MySqlCommand cmd = new MySqlCommand();
            cmd.CommandText = query;
            cmd.Parameters.AddWithValue("@id", data.id);
            cmd.Parameters.AddWithValue("@name", data.name);
            cmd.Connection = Connection;
            cmd.ExecuteNonQuery();
        }

        public void DeleteFromTable(BrickCategoryData data)
        {
            string query = "DELETE FROM brick_categories WHERE @id=id";
            MySqlCommand cmd = new MySqlCommand();
            cmd.CommandText = query;
            cmd.Parameters.AddWithValue("@id", data.id);
            cmd.Connection = Connection;
            cmd.ExecuteNonQuery();
        }

        #endregion

        #region brick_types

        public DataTable? GetBrickTypes(string bindingName)
        {
            MySqlCommand command = new MySqlCommand("SELECT * FROM brick_types;", Connection);
            MySqlDataAdapter adapter = new MySqlDataAdapter(command);
            DataSet dataSet = new DataSet();
            adapter.Fill(dataSet, bindingName);
            return (dataSet.Tables.Count == 1) ? dataSet.Tables[0] : null;
        }

        public void RefreshBrickTypes()
        {
            BrickTypesTable = GetBrickTypes("BrickTypes");
        }

        public int FindBrickType(int id)
        {
            if (BrickTypesTable != null)
            {
                var index = 0;
                foreach (DataRow row in BrickTypesTable.Rows)
                {
                    var brickTypeID = row.Field<Int32>(0);
                    if (brickTypeID == id)
                        return index;
                    index++;
                }
            }
            return -1;
        }

        public void UpdateTable(BrickTypeData data, Int32 originalID)
        {
            string query = "UPDATE brick_types SET id=@id,name=@name WHERE id=@originalID";
            MySqlCommand cmd = new MySqlCommand();
            cmd.CommandText = query;
            cmd.Parameters.AddWithValue("@id", data.id);
            cmd.Parameters.AddWithValue("@name", data.name);
            cmd.Parameters.AddWithValue("@originalID", originalID);
            cmd.Connection = Connection;
            cmd.ExecuteNonQuery();
        }

        public void AddToTable(BrickTypeData data)
        {
            string query = "INSERT INTO brick_types (id,name) VALUES (@id,@name)";
            MySqlCommand cmd = new MySqlCommand();
            cmd.CommandText = query;
            cmd.Parameters.AddWithValue("@id", data.id);
            cmd.Parameters.AddWithValue("@name", data.name);
            cmd.Connection = Connection;
            cmd.ExecuteNonQuery();
        }

        public void DeleteFromTable(BrickTypeData data)
        {
            string query = "DELETE FROM brick_types WHERE @id=id";
            MySqlCommand cmd = new MySqlCommand();
            cmd.CommandText = query;
            cmd.Parameters.AddWithValue("@id", data.id);
            cmd.Connection = Connection;
            cmd.ExecuteNonQuery();
        }

        #endregion
    }
}
