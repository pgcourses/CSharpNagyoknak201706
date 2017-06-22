using System;

namespace _06Attributum
{
    /// <summary>
    /// Reflection segítségével ellenőrizzük, hogy az osztály 
    /// validációs attributumainak megfelel-e a kapott példány
    /// </summary>
    public class ValidationManager
    {
        public static bool Validate(object model)
        {
            var t = model.GetType();

            foreach (var propInfo in t.GetProperties())
            {
                foreach (var attrib in propInfo.GetCustomAttributes(true))
                {
                    if (attrib is IValidatorAttribute) //Csak akkor van dolgunk, ha az attributumnak van ilyen felülete
                    {
                        var value = t.GetProperty(propInfo.Name).GetValue(model);
                        var a = (IValidatorAttribute)attrib; //if-en belül vagyuink, ilyet tudunk
                        if (!a.IsValid(value)) //ellenőrzés
                        {
                            return false;
                        }
                    }
                } 
            }
            return true;
        }
    }
}