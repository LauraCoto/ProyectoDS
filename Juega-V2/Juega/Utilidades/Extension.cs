using System;
using System.Collections.Generic;
using System.Linq;
using System.Text.RegularExpressions;
using System.Web;

namespace Juega.Utilidades
{
    public static class Extension
    {
        public static long _ToLong(this object value)
        {
            return Convert.ToInt64(value._NullValue(0));
        }

        public static int _ToInt(this object value)
        {
            return Convert.ToInt32(value._NullValue(0));
        }

        public static bool _ToBoolean(this object value)
        {
            return Convert.ToBoolean(value._NullValue(false));
        }

        public static string _ToString(this object value)
        {
            return Convert.ToString(value._NullValue(""));
        }

        public static string _ToSafeString(this object value)
        {
            return Convert.ToString(value._NullValue(""));
        }

        public static double _ToDouble(this object value)
        {
            return Convert.ToDouble(value._NullValue(0));
        }

        public static DateTime _ToDateTime(this object value)
        {
            return Convert.ToDateTime(value);
        }

        public static decimal _ToDecimal(this object value)
        {
            return Convert.ToDecimal(value._NullValue(0));
        }

        public static string _DefaultStringValue(this object value)
        {
            return _IsNullOrEmpty(value) ? "" : value.ToString();
        }

        public static object _NullValue(this object value, object replaceValue)
        {
            return _IsNullOrEmpty(value) ? replaceValue : value;
        }


        public static bool _IsValid(this object value)
        {
            if (_IsNullOrEmpty(value))
                return false;

            return true;
        }

        public static bool _IsNullOrEmpty(this object value)
        {
            if (value == null)
                return true;

            if (value == DBNull.Value)
                return true;

            if (Convert.IsDBNull(value))
                return true;


            if (string.IsNullOrEmpty(value.ToString()) || string.IsNullOrWhiteSpace(value.ToString()))
            {
                var st = typeof(string);
                if (value.GetType() == st)
                    return true;

            }

            return false;
        }

        public static bool _IsNumber(this object value)
        {
            try
            {
                var strvalue = value._ToSafeString();
                var regex = new Regex(@"^[-+]?[0-9]*\.?[0-9]+$");
                return regex.IsMatch(strvalue);
            }
            catch (Exception ex)
            { 
                return false;
            }
        }



    }
}