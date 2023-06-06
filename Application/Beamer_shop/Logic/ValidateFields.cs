using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Logic
{
    public static class ValidateFields
    {
        public static bool IsValid(object obj)
        {
            if (obj is null)
                throw new ArgumentNullException(nameof(obj));

            foreach (var propertyInfo in obj.GetType().GetProperties())
            {
                var value = propertyInfo.GetValue(obj);

                if (value is string stringValue && string.IsNullOrEmpty(stringValue))
                {
                    return false;
                }

                if (value is int intValue && intValue <= 0)
                {
                    return false;
                }

                if (value is double doubleValue && doubleValue <= 0)
                {
                    return false;
                }

                if (value is decimal decimalValue && decimalValue <= 0)
                {
                    return false;
                }

                if (value is DateTime dateTimeValue)
                {
                    if (!DateTime.TryParseExact(dateTimeValue.ToString("yyyy-MM-dd"), "yyyy-MM-dd", CultureInfo.InvariantCulture, DateTimeStyles.None, out _))
                    {
                        return false;
                    }
                }

            }

            return true;
        }
    }
}
