using System;

namespace _06Attributum
{
    public class CSharpDDMaxLengthAttribute : Attribute, IValidatorAttribute
    {
        public int MaxLength { get; set; }
        public string ErrorText { get; set; }

        public CSharpDDMaxLengthAttribute()
        { }
        public CSharpDDMaxLengthAttribute(int maxLength)
        {
            MaxLength = maxLength;
        }

        public bool IsValid(object value)
        {
            if (value is string)
            {
                var text = (string)value;
                return text.Length <= MaxLength;
            }
            return false;
        }
    }
}