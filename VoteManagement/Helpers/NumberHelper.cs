using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace VoteManagement.Helpers
{
    public class NumberHelper
    {
        public NumberHelper() { }

        public string NumberDisplayWithComma(decimal _number)
        {
            if (_number - Convert.ToInt64(_number) > 0)
                if (_number > 0 && _number < 1)
                    return ("0" + _number.ToString("#,###.##"));
                else
                    return _number.ToString("#,###.##");
            else
                return _number.ToString("#,###");
        }
        public string NumberDisplayWithoutComma(decimal _number)
        {
            if (_number - Convert.ToInt64(_number) > 0)
                if (_number > 0 && _number < 1)
                    return ("0" + _number.ToString("###.##"));
                else
                    return _number.ToString("###.##");
            else
                return _number.ToString("###");
        }

        public string NumberDisplayWithoutComma(string _number)
        {
            return _number.Replace(",", string.Empty);
        }

        public decimal Max(decimal _number1, decimal _number2)
        {
            return (_number1 >= _number2) ? _number1 : _number1;
        }
        public decimal Max(decimal _number1, decimal _number2, decimal _number3)
        {
            decimal max2 = this.Max(_number1, _number2);
            return (max2 >= _number3) ? max2 : _number3;
        }
        public decimal Round(decimal _number, int _decimal)
        {
            return Math.Round(_number, _decimal, MidpointRounding.AwayFromZero);
        }
        public decimal LamTronDonVi(decimal _number, int _donvi)
        {
            return this.Round(_number / _donvi, 0) * _donvi;
        }
        public string ToString(decimal number)
        {
            string s = number.ToString("#");
            string[] so = new string[] { "không", "một", "hai", "ba", "bốn", "năm", "sáu", "bảy", "tám", "chín" };
            string[] hang = new string[] { "", "nghìn", "triệu", "tỷ" };
            int i, j, donvi, chuc, tram;
            string str = " ";
            bool booAm = false;
            decimal decS = 0;
            //Tung addnew
            try
            {
                decS = Convert.ToDecimal(s.ToString());
            }
            catch
            {
            }
            if (decS < 0)
            {
                decS = -decS;
                s = decS.ToString();
                booAm = true;
            }
            i = s.Length;
            if (i == 0)
                str = so[0] + str;
            else
            {
                j = 0;
                while (i > 0)
                {
                    donvi = Convert.ToInt32(s.Substring(i - 1, 1));
                    i--;
                    if (i > 0)
                        chuc = Convert.ToInt32(s.Substring(i - 1, 1));
                    else
                        chuc = -1;
                    i--;
                    if (i > 0)
                        tram = Convert.ToInt32(s.Substring(i - 1, 1));
                    else
                        tram = -1;
                    i--;
                    if ((donvi > 0) || (chuc > 0) || (tram > 0) || (j == 3))
                        str = hang[j] + " " + str;
                    j++;
                    if (j > 3) j = 1;
                    if ((donvi == 1) && (chuc > 1))
                        str = "một " + str;
                    else
                    {
                        if ((donvi == 5) && (chuc > 0))
                            str = "lăm " + str;
                        else if (donvi > 0)
                            str = so[donvi] + " " + str;
                    }
                    if (chuc < 0)
                        break;
                    else
                    {
                        if ((chuc == 0) && (donvi > 0)) str = "lẻ " + str;
                        if (chuc == 1) str = "mười " + str;
                        if (chuc > 1) str = so[chuc] + " mươi " + str;
                    }
                    if (tram < 0) break;
                    else
                    {
                        if ((tram > 0) || (chuc > 0) || (donvi > 0)) str = so[tram] + " trăm " + str;
                    }
                    //str = " " + str;
                }
            }
            if (booAm) str = "Âm " + str;
            return str + "đồng chẵn";
        }
        public string ToString(double number)
        {
            string s = number.ToString("#");
            string[] so = new string[] { "không", "một", "hai", "ba", "bốn", "năm", "sáu", "bảy", "tám", "chín" };
            string[] hang = new string[] { "", "nghìn", "triệu", "tỷ" };
            int i, j, donvi, chuc, tram;
            string str = " ";
            bool booAm = false;
            double decS = 0;
            //Tung addnew
            try
            {
                decS = Convert.ToDouble(s.ToString());
            }
            catch
            {
            }
            if (decS < 0)
            {
                decS = -decS;
                s = decS.ToString();
                booAm = true;
            }
            i = s.Length;
            if (i == 0)
                str = so[0] + str;
            else
            {
                j = 0;
                while (i > 0)
                {
                    donvi = Convert.ToInt32(s.Substring(i - 1, 1));
                    i--;
                    if (i > 0)
                        chuc = Convert.ToInt32(s.Substring(i - 1, 1));
                    else
                        chuc = -1;
                    i--;
                    if (i > 0)
                        tram = Convert.ToInt32(s.Substring(i - 1, 1));
                    else
                        tram = -1;
                    i--;
                    if ((donvi > 0) || (chuc > 0) || (tram > 0) || (j == 3))
                        str = hang[j] + " " + str;
                    j++;
                    if (j > 3) j = 1;
                    if ((donvi == 1) && (chuc > 1))
                        str = "một " + str;
                    else
                    {
                        if ((donvi == 5) && (chuc > 0))
                            str = "lăm " + str;
                        else if (donvi > 0)
                            str = so[donvi] + " " + str;
                    }
                    if (chuc < 0)
                        break;
                    else
                    {
                        if ((chuc == 0) && (donvi > 0)) str = "lẻ " + str;
                        if (chuc == 1) str = "mười " + str;
                        if (chuc > 1) str = so[chuc] + " mươi " + str;
                    }
                    if (tram < 0) break;
                    else
                    {
                        if ((tram > 0) || (chuc > 0) || (donvi > 0)) str = so[tram] + " trăm " + str;
                    }
                    //str = " " + str;
                }
            }
            if (booAm) str = "Âm " + str;
            return str + "đồng chẵn";
        }
        public string ConvertToRomanNumber(int _number)
        {
            string strNumber = "";

            while (_number >= 1000) { strNumber += "M"; _number -= 1000; }
            if (_number >= 900) { strNumber += "CM"; _number -= 900; }
            if (_number >= 500) { strNumber += "D"; _number -= 500; }
            if (_number >= 400) { strNumber += "CD"; _number -= 400; }
            while (_number >= 100) { strNumber += "C"; _number -= 100; }
            if (_number >= 90) { strNumber += "XC"; _number -= 90; }
            if (_number >= 50) { strNumber += "L"; _number -= 50; }
            if (_number >= 40) { strNumber += "XL"; _number -= 40; }
            while (_number >= 10) { strNumber += "X"; _number -= 10; }
            if (_number >= 9) { strNumber += "IX"; _number -= 9; }
            if (_number >= 5) { strNumber += "V"; _number -= 5; }
            if (_number >= 4) { strNumber += "IV"; _number -= 4; }
            while (_number >= 1) { strNumber += "I"; _number -= 1; }

            strNumber = (strNumber.Equals("")) ? "N/A" : strNumber;

            return strNumber;
        }
    }
}