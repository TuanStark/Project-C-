using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Cake_shop.Models.Common
{
    public class FormatNumber
    {
        public static string FormatNnumber(object value, int soDauPhay = 2)
        {
            bool isNumber = IsNumberric(value);
            decimal GT = 0;
            if (isNumber)
            {
                GT = Convert.ToDecimal(value);
            }
            string str = "";
            string thapPhan = "";
            for(int i = 0; i < soDauPhay; i++)
            {
                thapPhan += "#";
            }
            if(thapPhan.Length > 0) thapPhan ="." + thapPhan;
            string snumformat = string.Format("0:#,##0{0}", thapPhan);
            str = string.Format("{" + snumformat + "}", GT);
            str += " đ";

            return str;
        }

        public static bool IsNumberric(object value) 
        {
            return value is sbyte
                || value is byte
                || value is short
                || value is ushort
                || value is int
                || value is uint
                || value is long
                || value is ulong
                || value is float
                || value is double
                || value is decimal;

        }
    }
}