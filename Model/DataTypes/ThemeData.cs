using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LegoBricks
{
    public struct ThemeData
    {
        public Int32 id;
        public String name;
        public Int32? parentID;

        public ThemeData(Int32 id, String name, Int32? parentID)
        {
            this.id = id;
            this.name = name;
            this.parentID = parentID;
        }

        public Int32 Id
        {
            get { return id; }
            set { id = value; }
        }
        public String Name
        {
            get { return name; }
            set { name = value; }
        }
        public Int32? ParentID
        {
            get { return parentID; }
            set { parentID = value; }
        }

        public bool Equals(ThemeData other)
        {
            return Equals(other, this);
        }

        public override bool Equals(object? obj)
        {
            if (obj == null || GetType() != obj.GetType())
            {
                return false;
            }

            var objectToCompareWith = (ThemeData)obj;

            return
                objectToCompareWith.id == id &&
                objectToCompareWith.name == name &&
                objectToCompareWith.parentID == parentID;
        }

        public override int GetHashCode()
        {
            var calculation = id + name.GetHashCode() + parentID;
            return calculation.GetHashCode();
        }
    };

}
