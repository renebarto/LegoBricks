using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LegoBricks.Model.Conversion
{
    public class SetConversion
    {
        static public SetData ConvertRowToData(DataRow row)
        {
            var data = new SetData();
            var value = row.Field<String>(0);
            data.id = value ?? "";
            value = row.Field<String>(1);
            data.name = value ?? "";
            data.partCount = row.Field<Int32>(2);
            data.themeID = row.Field<Int32>(3);
            data.year = row.Field<Int32>(4);
            return data;
        }

    }
}
