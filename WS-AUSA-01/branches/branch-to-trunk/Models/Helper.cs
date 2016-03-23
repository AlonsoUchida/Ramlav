using System.Data;
using System.Collections.Generic;
using System.Reflection;
using System;
using System.Globalization;
public static class Helper
{
    /// <summary>
    /// Converts a DataTable to a list with generic objects
    /// </summary>
    /// <typeparam name="T">Generic object</typeparam>
    /// <param name="table">DataTable</param>
    /// <returns>List with generic objects</returns>
    public static List<T> DataTableToList<T>(this DataTable table) where T : class, new()
    {
        try
        {
            List<T> list = new List<T>();

            foreach (var row in table.AsEnumerable())
            {
                T obj = new T();

                foreach (var prop in obj.GetType().GetProperties())
                {
                    try
                    {
                        PropertyInfo propertyInfo = obj.GetType().GetProperty(prop.Name);
                        decimal  formatNumber;
                        CultureInfo ci = new CultureInfo("en-US");
                        if (row[prop.Name].GetType() == typeof(decimal))
                        {
                            formatNumber = (decimal) row[prop.Name];
                            propertyInfo.SetValue(obj, formatNumber.ToString("N", ci), null);
                        }
                        else
                            propertyInfo.SetValue(obj, Convert.ChangeType(row[prop.Name], propertyInfo.PropertyType), null);
                    }
                    catch
                    {
                        continue;
                    }
                }

                list.Add(obj);
            }

            return list;
        }
        catch
        {
            return null;
        }
    }
}