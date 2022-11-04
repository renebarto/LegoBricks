using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LegoBricks.Model.Conversion
{
    public class BrickCategoryConversion
    {
        static public BrickCategoryData ConvertRowToData(DataRow row)
        {
            var data = new BrickCategoryData();
            data.id = row.Field<Int32>(0);
            String? name = row.Field<String>(1);
            data.name = (name != null) ? name : "";
            return data;
        }

    }
}
