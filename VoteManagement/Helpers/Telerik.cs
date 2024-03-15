using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI.WebControls;
using Telerik.Web.UI;

namespace VoteManagement.Helpers
{
    public class Telerik
    {
        public Telerik() { }
        public void SetSequenceNumberColumn(RadGrid _radgrid, GridItemEventArgs _e, string _sequenceNumberColumnName)
        {
            if (_e.Item is GridDataItem)
            {
                int rowCounter = new int();
                rowCounter = _radgrid.MasterTableView.PageSize * _radgrid.MasterTableView.CurrentPageIndex;
                Label lbl = _e.Item.FindControl(_sequenceNumberColumnName) as Label;
                lbl.Text = (_e.Item.ItemIndex + 1 + rowCounter).ToString();
            }
        }
        public void RadGridFilterTextbox(GridItemEventArgs e, string _filtername, string _content)
        {
            if (e.Item is GridFilteringItem)
            {
                GridFilteringItem item = (GridFilteringItem)e.Item;
                TextBox fltName = item[_filtername].Controls[0] as TextBox;
                fltName.Attributes.Add("Placeholder", _content);
                fltName.ToolTip = _content;
                fltName.Font.Italic = true;
                fltName.Width = Unit.Percentage(100);
            }
        }
    }
}