using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LegoBricks
{
    public struct ThemeDataEditPresentation
    {
        public ThemeData data;
        public String themeDescription;

        public ThemeDataEditPresentation(ThemeData data, String themeDescription)
        {
            this.data = data;
            this.themeDescription = themeDescription;
        }

        public Int32 Id
        {
            get { return data.id; }
        }
        public String Name
        {
            get { return data.name; }
        }
        public Int32? ParentID
        {
            get { return data.parentID; }
        }

        public String ThemeDescription
        {
            get { return themeDescription; }
        }
    };

}
