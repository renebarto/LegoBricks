using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LegoBricks.Model
{
    public class Database
    {
        public MySql.Data.MySqlClient.MySqlConnection? Connection { get; private set; }
        public DataTable? BrickCategoriesTable { get; private set; }

        public void Open()
        {
            Connection = new MySql.Data.MySqlClient.MySqlConnection(ConfigurationManager.ConnectionStrings["ConnectionString"].ConnectionString);
            Connection.Open();
            RefreshBrickCategories("BrickCategories");
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

        #region brick_categories

        public DataTable? GetBrickCategories(string bindingName)
        {
            MySql.Data.MySqlClient.MySqlCommand command = new MySql.Data.MySqlClient.MySqlCommand("SELECT * FROM brick_categories;", Connection);
            MySql.Data.MySqlClient.MySqlDataAdapter adapter = new MySql.Data.MySqlClient.MySqlDataAdapter(command);
            DataSet dataSet = new DataSet();
            adapter.Fill(dataSet, bindingName);
            return (dataSet.Tables.Count == 1) ? dataSet.Tables[0] : null;
        }

        public void RefreshBrickCategories(string bindingName)
        {
            BrickCategoriesTable = GetBrickCategories(bindingName);
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

        #endregion
    }
}
