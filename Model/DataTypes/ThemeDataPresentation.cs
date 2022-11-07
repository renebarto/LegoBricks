using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LegoBricks
{
    public struct ThemeDataPresentation
    {
        public ThemeData data;
        public String parentThemeDescription;

        public ThemeDataPresentation(ThemeData data, String parentThemeDescription)
        {
            this.data = data;
            this.parentThemeDescription = parentThemeDescription;
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

        public String ParentThemeDescription
        {
            get { return parentThemeDescription; }
        }
    };

}
