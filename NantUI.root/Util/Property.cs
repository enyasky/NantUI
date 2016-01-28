using System;
using System.Configuration;

namespace NantUI.Util
{
    public class Property : IEquatable<Property>
    {
        public string Name { get; private set; }
        public string Value { get; private set; }

        public Property(string name, string value)
        {
            if (!ValidateName(name))
                throw new InvalidOperationException("Invalid Nant property name.");

            Name = name;
            Value = value;
        }

        public bool Equals(Property other)
        {
            return other.Name == Name;
        }

        public override string ToString()
        {
            return string.Format("{0}={1}", Name, Value);
        }

        private static RegexStringValidator propertyValidator = new RegexStringValidator(@"^[a-zA-Z_][a-zA-Z0-9\.\-_]*[a-zA-Z0-9_]$");
        public static bool ValidateName(string propertyName)
        {
            try
            {
                propertyValidator.Validate(propertyName);
                return true;
            }
            catch { }

            return false;
        }
    }
}
