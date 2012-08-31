using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Web.UI.WebControls;

namespace Dev3Lib.Web
{
    public class GridViewWrapper
    {
        private List<string> _visisbleColumns = new List<string>();
        private List<string> _hiddenColumns = new List<string>();
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

                if (_visisbleColumns.Count != 0)
                {
                    ShowColumns(e, _visisbleColumns);
                }
                if (_hiddenColumns.Count != 0)
                {
                    HideColumns(e, _hiddenColumns);
                }
            };
        }
        public string VisibleColumns
        {
            get
            {
                return string.Join(",", _visisbleColumns.ToArray());
            }
            set
            {
                if (!string.IsNullOrEmpty(value))
                    _visisbleColumns.AddRange(value.Split(','));
                else
                    this._visisbleColumns.Clear();
            }
        }
        public string HiddenColumns
        {
            get
            {
                return string.Join(",", _hiddenColumns.ToArray());
            }
            set
            {
                if (!string.IsNullOrEmpty(value))
                    _hiddenColumns.AddRange(value.Split(','));
                else
                    this._hiddenColumns.Clear();
            }
        }

        private void ShowColumns(GridViewRowEventArgs e, List<string> showColumnList)
        {
            for (int i = 0; i < e.Row.Cells.Count; i++)
            {
                e.Row.Cells[i].Visible = showColumnList.Contains(_originalColumns[i]);
            }
        }

        private void HideColumns(GridViewRowEventArgs e, List<string> hideColumnList)
        {
            for (int i = 0; i < e.Row.Cells.Count; i++)
            {
                e.Row.Cells[i].Visible = !hideColumnList.Contains(_originalColumns[i]);
            }
        }
    }
}
