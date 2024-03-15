using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using ClosedXML.Excel;

namespace VoteManagement.Helpers
{
    public class ClosedXMLExportExcelHelper
    {
        public ClosedXMLExportExcelHelper() { }
        private List<string> _parameterList = new List<string>();
        private List<string> _rangeList = new List<string>();
        private List<string[]> _criteriaList = new List<string[]>();
        public string Parameter
        {
            set
            {
                _parameterList.Add(value);
            }
        }
        public string[] Criteria
        {
            set
            {
                _criteriaList.Add(value);
            }
        }
        public string RangeParameter
        {
            set
            {
                _rangeList.Add(value);
            }
        }
        public string RangeFormular(ClosedXML.Excel.IXLWorksheet _worksheet, int _column, int _row)
        {
            return (_worksheet.Column(_column).ColumnLetter() + _row);
        }
        public string RangeFormular(ClosedXML.Excel.IXLWorksheet _worksheet, int _firstColumn, int _firstRow, int _lastColumn, int _lastRow)
        {
            return (this.RangeFormular(_worksheet, _firstColumn, _firstRow) + ":" + this.RangeFormular(_worksheet, _lastColumn, _lastRow));
        }
        public string RangeFormular(ClosedXML.Excel.XLWorkbook _workbook, int _worksheet, int _column, int _row)
        {
            ClosedXML.Excel.IXLWorksheet worksheet = _workbook.Worksheets.ElementAt(_worksheet);
            return ("'" + worksheet.Name + "'!" + this.RangeFormular(worksheet, _column, _row));
        }
        public string RangeFormular(ClosedXML.Excel.XLWorkbook _workbook, int _worksheet, int _firstColumn, int _firstRow, int _lastColumn, int _lastRow)
        {
            ClosedXML.Excel.IXLWorksheet worksheet = _workbook.Worksheets.ElementAt(_worksheet);
            return ("'" + worksheet.Name + "'!" + this.RangeFormular(worksheet, _firstColumn, _firstRow) + ":" + this.RangeFormular(worksheet, _lastColumn, _lastRow));
        }

        public string SumFormular
        {
            get
            {
                string formular = "=";
                if (_rangeList.Count() > 0)
                    for (int r = 0; r < _rangeList.Count(); r++)
                        formular += (r == 0) ? ("SUM(" + _rangeList.ElementAt(r) + ") ") : (" + SUM(" + _rangeList.ElementAt(r) + ") ");
                if (_parameterList.Count() > 0)
                {
                    formular += "SUM(";
                    for (int c = 0; c < _parameterList.Count(); c++)
                        formular += (c == 0) ? _parameterList.ElementAt(c) : (", " + _parameterList.ElementAt(c));
                    formular += ") ";
                }

                return formular;
            }
        }
        public string SumIfsFormular
        {
            get
            {
                string formular = "=";
                if (_rangeList.Count() > 0 && _criteriaList.Count() > 0)
                    for (int r = 0; r < _rangeList.Count(); r++)
                    {
                        if (r != 0)
                            formular += " + ";
                        formular += ("SUMIFS(" + _rangeList.ElementAt(r));
                        for (int cr = 0; cr < _criteriaList.Count(); cr++)
                            formular += (", " + _criteriaList.ElementAt(cr)[0] + ", " + _criteriaList.ElementAt(cr)[1]);
                        formular += ") ";
                    }
                return formular;
            }
        }
        public string SubtractionFormular
        {
            get
            {
                string formular = "=";
                for (int c = 0; c < _parameterList.Count(); c++)
                    formular += (c == 0) ? _parameterList.ElementAt(c) : (" - " + _parameterList.ElementAt(c));
                return formular;
            }
        }
        public string MultiplicationFormular
        {
            get
            {
                string formular = "=";
                if (_parameterList.Count() > 0)
                {
                    formular += "(";
                    for (int c = 0; c < _parameterList.Count(); c++)
                        formular += (c == 0) ? _parameterList.ElementAt(c) : ("* " + _parameterList.ElementAt(c));
                    formular += ") ";
                }
                return formular;
            }
        }

        public string Round(string _formular, int _round)
        {
            return ("=ROUND(" + _formular + ", " + _round + ")");
        }

        public void Superscript(IXLCell _cell)
        {
            if (_cell.Value.ToString().Equals("m2"))
                _cell.CreateRichText().Substring(1).VerticalAlignment = XLFontVerticalTextAlignmentValues.Superscript;
            if (_cell.Value.ToString().Equals("m3"))
                _cell.CreateRichText().Substring(1).VerticalAlignment = XLFontVerticalTextAlignmentValues.Superscript;
            if (_cell.Value.ToString().Equals("m2 XD"))
                _cell.CreateRichText().Substring(1, 1).VerticalAlignment = XLFontVerticalTextAlignmentValues.Superscript;
            if (_cell.Value.ToString().Equals("m2 ốp"))
                _cell.CreateRichText().Substring(1, 1).VerticalAlignment = XLFontVerticalTextAlignmentValues.Superscript;
        }
        public string[] ArrayAlphabet
        {
            get
            {
                string[] array = new string[27];
                array[0] = "";
                array[1] = "A";
                array[2] = "B";
                array[3] = "C";
                array[4] = "D";
                array[5] = "E";
                array[6] = "F";
                array[7] = "G";
                array[8] = "H";
                array[9] = "I";
                array[10] = "J";
                array[11] = "K";
                array[12] = "L";
                array[13] = "M";
                array[14] = "N";
                array[15] = "O";
                array[16] = "P";
                array[17] = "Q";
                array[18] = "R";
                array[19] = "S";
                array[20] = "T";
                array[21] = "U";
                array[22] = "V";
                array[23] = "W";
                array[24] = "X";
                array[25] = "Y";
                array[26] = "Z";
                return array;
            }
        }
        public string ExcelColumn(double _indexNumber)
        {
            if (_indexNumber <= 0)
                return "";
            else if (_indexNumber <= 26)
                return this.ArrayAlphabet[Convert.ToInt32(_indexNumber)];
            else
            {
                int power = 0;
                double number = 0;

                while (number < _indexNumber)
                {
                    power++;
                    number = (number + Math.Pow(26, power));
                }

                string[] arrayLetter = new string[power];
                _indexNumber -= 26;

                int index = 0;
                for (int p = (power - 1); p >= 0; p--)
                {
                    int indexLetter = Convert.ToInt32(Math.Floor(_indexNumber / Math.Pow(26, p)));
                    double mod = _indexNumber % Math.Pow(26, p);

                    if (mod > 0)
                    {
                        if (indexLetter == 0)
                            arrayLetter[index] = this.ArrayAlphabet[indexLetter + 1];
                        else
                            arrayLetter[index] = (p == 1) ? this.ArrayAlphabet[indexLetter + 1] : this.ArrayAlphabet[indexLetter];
                    }
                    else if (indexLetter == 0 || indexLetter == 26)
                        arrayLetter[index] = this.ArrayAlphabet[26];
                    else if (indexLetter == 1)
                        arrayLetter[index] = this.ArrayAlphabet[indexLetter];
                    else
                        arrayLetter[index] = this.ArrayAlphabet[indexLetter - 1];

                    _indexNumber = _indexNumber - (indexLetter * Math.Pow(26, p));
                    index++;
                }

                string column = "";
                foreach (string letter in arrayLetter)
                    column += letter;

                return column;
            }
        }
        public double SetAutomaticallyHeightRow(string _text, decimal _maxRowText)
        {
            return Convert.ToDouble(Math.Ceiling(Convert.ToDecimal(_text.Length) / _maxRowText) * 15);
        }
    }
}