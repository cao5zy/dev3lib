using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Web.UI.WebControls;

namespace Dev3Lib.Web
{
    public class GridViewWrapper
    {
        private List<int> _visisbleColumnOrders = new List<int>();
        private List<int> _hiddenColumnOrders = new List<int>();
        private List<string> _originalColumns = new List<string>();

        public GridViewWrapper(GridView gridView)
        {
            gridView.RowCreated += (s, e) =>
            {
                if (e.Row.RowType == DataControlRowType.Header)
                {
                    _originalColumns.AddRange((from TableCell n in e.Row.Cells
                                               select n.Text));
                }
                else if (e.Row.RowType == DataControlRowType.EmptyDataRow)
                    return;

                if (_visisbleColumnOrders.Count != 0)
                {
                    ShowColumns(e, _visisbleColumnOrders);
                }
                if (_hiddenColumnOrders.Count != 0)
                {
                    HideColumns(e, _hiddenColumnOrders);
                }
            };
        }
        public int[] VisibleColumnOrders
        {
            get
            {
                return _visisbleColumnOrders.ToArray();
            }
            set
            {
                _visisbleColumnOrders.Clear();
                if (value != null)
                    _visisbleColumnOrders.AddRange(value);
            }
        }
        public int[] HiddenColumns
        {
            get
            {
                return _hiddenColumnOrders.ToArray();
            }
            set
            {
                _hiddenColumnOrders.Clear();

                if (value != null)
                    _hiddenColumnOrders.AddRange(value);
            }
        }

        private void ShowColumns(GridViewRowEventArgs e, List<int> showColumnOrderList)
        {
            for (int i = 0; i < e.Row.Cells.Count; i++)
            {
                e.Row.Cells[i].Visible = showColumnOrderList.Contains(i);
            }
        }

        private void HideColumns(GridViewRowEventArgs e, List<int> hideColumnOrderList)
        {
            for (int i = 0; i < e.Row.Cells.Count; i++)
            {
                e.Row.Cells[i].Visible = !hideColumnOrderList.Contains(i);
            }
        }
    }
}
