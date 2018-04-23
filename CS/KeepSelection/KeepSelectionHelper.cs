using System;
using System.Collections.Generic;
using System.Text;
using DevExpress.XtraGrid.Views.Grid;
using System.Windows.Forms;
using DevExpress.XtraGrid.Views.Grid.ViewInfo;
using DevExpress.Data;
using DevExpress.XtraGrid;
using DevExpress.XtraGrid.Views.Base;
using DevExpress.XtraGrid.Columns;

namespace KeepSelection
{
    class KeepSelectionHelper
    {
        public bool KeepSelectedOnClick;
        GridView View;
        int[] selectedRows;
        GridMultiSelectMode mode;
        GridCell[] SelectedCells;

        public KeepSelectionHelper(GridView view)
        {
            KeepSelectedOnClick = true;
            View = view;
            View.ShownEditor += new EventHandler(ShownEditor);
            View.MouseDown+=new MouseEventHandler(MouseDown);
            mode = View.OptionsSelection.MultiSelectMode;
        }
        public void UpdateSelectionMode()
        {
            mode = View.OptionsSelection.MultiSelectMode;
        }
        private void ShownEditor(object sender, EventArgs e)
        {
            if (!KeepSelectedOnClick)
                return;
            if (mode == GridMultiSelectMode.RowSelect)
            {
                if (selectedRows == null)
                    return;
                foreach (int row in selectedRows)
                    if (row == View.FocusedRowHandle)
                        foreach (int selectedRow in selectedRows)
                        {
                            View.SelectRow(selectedRow);
                        }
                selectedRows = null;
            }
            else
            {
                if (SelectedCells == null)
                    return;
                bool selected = false;
                foreach (GridCell cell in SelectedCells)
                {
                    if ((cell.RowHandle == View.FocusedRowHandle) && (cell.Column == View.FocusedColumn))
                        selected = true;
                }
                if (selected)
                    foreach (GridCell selectedCell in SelectedCells)
                    {
                        View.SelectCell(selectedCell);
                    }
            }

        }
        private void MouseDown(object sender, MouseEventArgs e)
        {
            if (!KeepSelectedOnClick)
                return;
            GridHitInfo hi = View.CalcHitInfo(e.Location);
            if (mode == GridMultiSelectMode.RowSelect)
            {
                selectedRows = View.GetSelectedRows();
                foreach (int row in selectedRows)
                    if (row == hi.RowHandle)
                        return;
                selectedRows = null;
            }
            else
            {
                SelectedCells = View.GetSelectedCells();
                foreach (GridCell cell in SelectedCells)
                {
                    if ((cell.RowHandle == hi.RowHandle) && (cell.Column == hi.Column))
                        return;
                }
                SelectedCells = null;
            }
        }
    }
}
