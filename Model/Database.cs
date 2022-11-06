using System;
using System.Configuration;
using System.Data;
using MySql.Data.MySqlClient;

namespace LegoBricks.Model
{
    public class Database
    {
        public MySql.Data.MySqlClient.MySqlConnection? Connection { get; private set; }
        public DataTable? BrickCategoriesTable { get; private set; }
        public DataTable? BrickTypesTable { get; private set; }

        public void Open()
        {
            Connection = new MySql.Data.MySqlClient.MySqlConnection(ConfigurationManager.ConnectionStrings["ConnectionString"].ConnectionString);
            Connection.Open();
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
                    var brickTypeID = row.Field<Int32>(BrickTypesTable.Columns[0].ColumnName);
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
                    var brickCategoryID = row.Field<Int32>(BrickCategoriesTable.Columns[0].ColumnName);
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
    }
}
