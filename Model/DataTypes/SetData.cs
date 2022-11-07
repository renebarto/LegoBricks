using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LegoBricks
{
    public struct SetData
    {
        public String id;
        public String name;
        public Int32 partCount;
        public Int32 themeID;
        public Int32 year;

        public SetData(String id, String name, Int32 partCount, Int32 themeID, Int32 year)
        {
            this.id = id;
            this.name = name;
            this.partCount = partCount;
            this.themeID = themeID;
            this.year = year;
        }

        public String Id
        {
            get { return id; }
            set { id = value; }
        }
        public String Name
        {
            get { return name; }
            set { name = value; }
        }
        public Int32 PartCount
        {
            get { return partCount; }
            set { partCount = value; }
        }
        public Int32 ThemeID
        {
            get { return themeID; }
            set { themeID = value; }
        }
        public Int32 Year
        {
            get { return year; }
            set { year = value; }
        }

        public bool Equals(SetData other)
        {
            return Equals(other, this);
        }

        public override bool Equals(object? obj)
        {
            if (obj == null || GetType() != obj.GetType())
            {
                return false;
            }

            var objectToCompareWith = (SetData)obj;

            return
                objectToCompareWith.id == id &&
                objectToCompareWith.name == name &&
                objectToCompareWith.partCount == partCount &&
                objectToCompareWith.themeID == themeID &&
                objectToCompareWith.year == year;
        }

        public override int GetHashCode()
        {
            var calculation = id + name.GetHashCode() + partCount + themeID + year;
            return calculation.GetHashCode();
        }
    };

}
