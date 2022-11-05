using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LegoBricks
{
    public struct BrickCategoryData
    {
        public Int32 id;
        public String name;

        public BrickCategoryData(Int32 id, String name)
        {
            this.id = id;
            this.name = name;
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
        public bool Equals(BrickCategoryData other)
        {
            return Equals(other, this);
        }

        public override bool Equals(object? obj)
        {
            if (obj == null || GetType() != obj.GetType())
            {
                return false;
            }

            var objectToCompareWith = (BrickCategoryData)obj;

            return
                objectToCompareWith.id == id &&
                objectToCompareWith.name == name;
        }

        public override int GetHashCode()
        {
            var calculation = id + name.GetHashCode();
            return calculation.GetHashCode();
        }
    };

}
