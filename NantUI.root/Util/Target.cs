using System;
using System.Xml;

namespace NantUI.Util
{
    public class Target : IEquatable<Target>, IComparable<Target>
    {
        public string Name { get; set; }
        public string Description { get; set; }

        public Target(XmlElement target)
        {
            if (target == null) throw new ArgumentNullException("target");

            try
            {
                foreach (XmlAttribute attr in target.Attributes)
                {
                    switch (attr.Name.ToLower())
                    {
                        case "name":
                            Name = attr.Value;
                            break;
                        case "description":
                            Description = attr.Value;
                            break;
                    }
                }
            }
            // ignore -- if we don't find these then we aren't worried about it anyway...
            catch { }
        }

        #region IEquatable<Target> Members

        public bool Equals(Target other)
        {
            return other.Name == Name;
        }

        #endregion

        #region IComparable<Target> Members

        public int CompareTo(Target other)
        {
            // order alphabetically by description
            return Description.CompareTo(other.Description);
        }

        #endregion
    }
}
