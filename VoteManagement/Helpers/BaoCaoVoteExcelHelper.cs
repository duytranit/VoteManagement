using ClosedXML.Excel;
using System;
using System.Collections.Generic;
using System.Data.Entity.Core.Common.CommandTrees.ExpressionBuilder;
using System.IO;
using System.Linq;
using System.Security.Cryptography.Xml;
using System.Web;
using Telerik.Windows.Documents.Spreadsheet.Model.Filtering;

namespace VoteManagement.Helpers
{
    public class BaoCaoVoteExcelHelper
    {
        public BaoCaoVoteExcelHelper() { }
        private Helpers.ClosedXMLExportExcelHelper _hlpExcel = new Helpers.ClosedXMLExportExcelHelper();
        private Helpers.NumberHelper _hlpNumber = new NumberHelper();
        private int _column;

        public void ExportExcel(Models.Vote _vote)
        {
            using (XLWorkbook workbook = new XLWorkbook())
            {
                Models.Entities.Vote ettVote = new Models.Entities.Vote();
                _column = ettVote.MaxAnswerNumber(_vote.ID) + 2;

                IXLWorksheet worksheet = workbook.Worksheets.Add("Baocaobophieu");
                this.WriteWorkSheet(worksheet, _vote);

                //Export the Excel file.
                HttpContext.Current.Response.Clear();
                HttpContext.Current.Response.Buffer = true;
                HttpContext.Current.Response.Charset = "";
                HttpContext.Current.Response.ContentType = "application/vnd.openxmlformats-officedocument.spreadsheetml.sheet";
                HttpContext.Current.Response.AddHeader("content-disposition", "attachment;filename=BaoCaoBoPhieu.xls");
                using (MemoryStream MyMemoryStream = new MemoryStream())
                {
                    workbook.SaveAs(MyMemoryStream);
                    MyMemoryStream.WriteTo(HttpContext.Current.Response.OutputStream);
                    HttpContext.Current.Response.Flush();
                    HttpContext.Current.Response.End();
                }
            }
        }
        public void WriteWorkSheet(IXLWorksheet _worksheet, Models.Vote _vote)
        {
            // Chỉnh kích thước
            this.ChinhKichThuoc(_worksheet);
            // Dòng
            int row = 1;
            // Tiêu đề
            row = this.TieuDe(_worksheet, row, _vote.Name);
            row = this.WriteContent(_worksheet, row, _vote);
            this.Borderred(_worksheet, 4, row);
            // Footer
            _hlpExcel = new ClosedXMLExportExcelHelper();
            _hlpExcel.Parameter = _hlpExcel.RangeFormular(_worksheet, _column, row - 1);

            _worksheet.Cell(_hlpExcel.RangeFormular(_worksheet, _column, row + 1)).FormulaA1 = _hlpExcel.SumFormular;
        }
        private void Borderred(IXLWorksheet _worksheet, int _fromrow, int _torow)
        {
            for (int r = _fromrow; r <= _torow; r++)
            {
                for (int c = 1; c <= _column + 2; c++)
                {
                    string cell = _hlpExcel.RangeFormular(_worksheet, c, r);
                    _worksheet.Cell(cell).Style.Border.OutsideBorder = XLBorderStyleValues.Thin;
                }
            }
        }
        private void ChinhKichThuoc(IXLWorksheet _worksheet)
        {
            // Chỉnh font
            _worksheet.Style.Font.FontName = "Times New Roman";
            _worksheet.Style.Font.FontSize = 12;
            _worksheet.Style.Alignment.SetWrapText(true);
            _worksheet.Rows().Style.Alignment.SetVertical(XLAlignmentVerticalValues.Center);

            _worksheet.PageSetup.PageOrientation = XLPageOrientation.Landscape;
            _worksheet.PageSetup.SetPaperSize(XLPaperSize.A4Paper);
            _worksheet.PageSetup.Margins.SetTop(0.5);
            _worksheet.PageSetup.Margins.SetRight(0.5);
            _worksheet.PageSetup.Margins.SetBottom(0.5);
            _worksheet.PageSetup.Margins.SetLeft(0.5);
            _worksheet.PageSetup.Margins.SetHeader(0);
            _worksheet.PageSetup.Margins.SetFooter(0);
            _worksheet.PageSetup.SetCenterHorizontally(true);

            _worksheet.Column(2).Width = 50;
        }
        private int TieuDe(IXLWorksheet _worksheet, int _row, string _name)
        {
            // Tiêu đề
            // _row 1
            string cell = _hlpExcel.RangeFormular(_worksheet, 1, _row, _column + 2, _row);
            _worksheet.Range(cell).Style.Alignment.SetHorizontal(XLAlignmentHorizontalValues.Center);
            _worksheet.Range(cell).Style.Font.Bold = true;
            _worksheet.Range(cell).Merge().Value = "KẾT QUẢ BỎ PHIẾU";

            _row++;
            cell = _hlpExcel.RangeFormular(_worksheet, 1, _row, _column + 2, _row);
            _worksheet.Range(cell).Style.Alignment.SetHorizontal(XLAlignmentHorizontalValues.Center);
            _worksheet.Range(cell).Style.Font.Bold = true;
            _worksheet.Range(cell).Merge().Value = _name;

            _row++;


            // Header table
            _row ++;

            _worksheet.PageSetup.SetRowsToRepeatAtTop(_row, _row);

            _worksheet.Row(_row).Style.Font.Bold = true;
            _worksheet.Row(_row).Style.Alignment.SetHorizontal(XLAlignmentHorizontalValues.Center);

            _worksheet.Cell(_hlpExcel.RangeFormular(_worksheet, 1, _row)).Value = "STT";
            _worksheet.Range(_hlpExcel.RangeFormular(_worksheet, 2, _row)).Merge().Value = "NỘI DUNG";
            for (int i = 1; i <= _column; i++)
                _worksheet.Cell(_hlpExcel.RangeFormular(_worksheet, (i + 2), _row)).Value = "Lựa chọn " + i;

            return _row;
        }
        private int WriteContent(IXLWorksheet _worksheet, int _row, Models.Vote _vote)
        {
            int flag = 0;
            foreach (Models.Question question in _vote.Questions)
            {
                _row++;
                flag++;
                string cell = _hlpExcel.RangeFormular(_worksheet, 1, _row);
                _worksheet.Cell(cell).Style.Alignment.SetHorizontal(XLAlignmentHorizontalValues.Center);
                _worksheet.Cell(cell).Value = flag.ToString();

                cell = _hlpExcel.RangeFormular(_worksheet, 2, _row);
                _worksheet.Range(cell).Merge().Value = question.Content;

                int answerSum = question.Answers.Count();
                int answerFlag = 1;
                foreach (Models.Answer answer in question.Answers)
                {
                    int accAnswerSum = answer.AccounAnswers.Count();
                    cell = _hlpExcel.RangeFormular(_worksheet, 2 + answerFlag, _row);
                    _worksheet.Range(cell).Merge().Value = accAnswerSum + "/" + answerSum;
                    answerFlag++;
                }
            }
            return _row;
        }
    }
}