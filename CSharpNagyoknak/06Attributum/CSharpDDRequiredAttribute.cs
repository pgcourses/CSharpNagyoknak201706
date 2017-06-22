using System;

namespace _06Attributum
{
    public class CSharpDDRequiredAttribute : Attribute, IValidatorAttribute
    {
        public bool IsValid(object value)
        {
            if (value is string)
            {
                return !string.IsNullOrWhiteSpace((string)value);
            }
            return false;
        }
    }
}