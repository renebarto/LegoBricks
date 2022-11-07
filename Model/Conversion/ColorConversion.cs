using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LegoBricks.Model.Conversion
{
    public class ColorConversion
    {
        static public ColorData ConvertRowToData(DataRow row)
        {
            var data = new ColorData();
            data.id = row.Field<Int32>(0);
            String? value = row.Field<String>(1);
            data.name = value ?? "";
            value = row.Field<String>(2);
            data.rgb = value ?? "";
            data.transparent = (row.Field<sbyte>(3) == 1);
            return data;
        }

    }
}
