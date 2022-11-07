using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LegoBricks
{
    public struct SetDataPresentation
    {
        public SetData data;
        public String themeDescription;

        public SetDataPresentation(SetData data, String themeDescription)
        {
            this.data = data;
            this.themeDescription = themeDescription;
        }

        public String Id
        {
            get { return data.id; }
        }
        public String Name
        {
            get { return data.name; }
        }
        public Int32 PartCount
        {
            get { return data.partCount; }
        }
        public Int32 ThemeID
        {
            get { return data.themeID; }
        }
        public Int32 Year
        {
            get { return data.year; }
        }
        public String ThemeDescription
        {
            get { return themeDescription; }
        }
    };

}
