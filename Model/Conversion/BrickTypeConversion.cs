using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LegoBricks.Model.Conversion
{
    public class BrickTypeConversion
    {
        static public BrickTypeData ConvertRowToData(DataRow row)
        {
            var data = new BrickTypeData();
            data.id = row.Field<Int32>(0);
            String? name = row.Field<String>(1);
            data.name = (name != null) ? name : "";
            return data;
        }

    }
}
