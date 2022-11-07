using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LegoBricks
{
    public struct ColorData
    {
        public Int32 id;
        public String name;
        public String rgb;
        public bool transparent;

        public ColorData(Int32 id, String name, String rgb, bool transparent)
        {
            this.id = id;
            this.name = name;
            this.rgb = rgb;
            this.transparent = transparent;
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
        public String RGB
        {
            get { return rgb; }
            set { rgb = value; }
        }
        public bool Transparent
        {
            get { return transparent; }
            set { transparent = value; }
        }

        public bool Equals(ColorData other)
        {
            return Equals(other, this);
        }

        public override bool Equals(object? obj)
        {
            if (obj == null || GetType() != obj.GetType())
            {
                return false;
            }

            var objectToCompareWith = (ColorData)obj;

            return
                objectToCompareWith.id == id &&
                objectToCompareWith.name == name &&
                objectToCompareWith.rgb == rgb &&
                objectToCompareWith.transparent == transparent;
        }

        public override int GetHashCode()
        {
            var calculation = id + name.GetHashCode() + rgb.GetHashCode() + (transparent ? 1 : 0);
            return calculation.GetHashCode();
        }
    };

}
