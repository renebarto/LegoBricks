using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LegoBricks.Model.Conversion
{
    public class ThemeConversion
    {
        static public ThemeData ConvertRowToData(DataRow row)
        {
            var data = new ThemeData();
            data.id = row.Field<Int32>(0);
            var value = row.Field<String>(1);
            data.name = value ?? "";
            if (Convert.IsDBNull(row.ItemArray[2]))
                data.parentID = null;
            else
                data.parentID = row.Field<Int32>(2);
            return data;
        }

    }
}
