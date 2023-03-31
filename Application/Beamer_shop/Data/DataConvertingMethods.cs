using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Data
{
    public class DataConvertingMethods
    {
        public static T ConvertDataRowToObject<T>(DataRow row) where T : new()
        {
            //set object without having to use constructor
            var obj = new T();

            //get properties of object so we can compare with datarow columns
            var properties = obj.GetType().GetProperties();
            foreach (var prop in properties)
            {
                //check if dr and prop share same name
                if (row.Table.Columns.Contains(prop.Name))
                {
                    //get value of row member
                    var value = row[prop.Name];
                    //if val not null, check datatype and set the value of prop. Null stays null (dto must accept null)
                    if (value != DBNull.Value)
                    {
                        if (prop.PropertyType == typeof(int))
                        {
                            prop.SetValue(obj, Convert.ToInt32(value));
                        }
                        else if (prop.PropertyType == typeof(string))
                        {
                            prop.SetValue(obj, Convert.ToString(value));
                        }
                    }
                }
            }

            //return datarow converted to object
            return obj;
        }


    }
}
