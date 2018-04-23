using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;

using System.Text;
using System.Windows.Forms;

namespace KeepSelection
{
    public partial class Form1 : Form
    {
        KeepSelectionHelper helper;
        private  DataTable CreateTable(int RowCount)
        {
            DataTable tbl = new DataTable();
            tbl.Columns.Add("Name", typeof(string));
            tbl.Columns.Add("ID", typeof(int));
            tbl.Columns.Add("Number", typeof(int));
            tbl.Columns.Add("Date", typeof(DateTime));
            for (int i = 0; i < RowCount; i++)
                tbl.Rows.Add(new object[] { String.Format("Name{0}", i), i, 3 - i, DateTime.Now.AddDays(i) });
            return tbl;

        }

        public Form1()
        {
            InitializeComponent();
            gridControl1.DataSource = CreateTable(6);
            helper = new KeepSelectionHelper(gridView1);
        }

        private void Form1_Load(object sender, EventArgs e)
        {

        }

        private void simpleButton1_Click(object sender, EventArgs e)
        {
            gridView1.OptionsSelection.MultiSelectMode = DevExpress.XtraGrid.Views.Grid.GridMultiSelectMode.RowSelect;
            helper.UpdateSelectionMode();
            gridView1.ClearSelection();
            gridView1.SelectRow(0);
            gridView1.SelectRow(2);
            gridView1.SelectRow(4);
        }

        private void checkButton1_CheckedChanged(object sender, EventArgs e)
        {
            helper.KeepSelectedOnClick = checkButton1.Checked;
        }

        private void simpleButton2_Click(object sender, EventArgs e)
        {
            gridView1.OptionsSelection.MultiSelectMode = DevExpress.XtraGrid.Views.Grid.GridMultiSelectMode.CellSelect;
            helper.UpdateSelectionMode();
            gridView1.ClearSelection();
            gridView1.SelectCell(0, gridView1.VisibleColumns[0]);
            gridView1.SelectCell(1, gridView1.VisibleColumns[1]);
            gridView1.SelectCell(2, gridView1.VisibleColumns[2]);
            gridView1.SelectCell(3, gridView1.VisibleColumns[3]);
            gridView1.SelectCell(2, gridView1.VisibleColumns[0]);
            gridView1.SelectCell(3, gridView1.VisibleColumns[1]);
            gridView1.SelectCell(4, gridView1.VisibleColumns[2]);
            gridView1.SelectCell(5, gridView1.VisibleColumns[3]);



        }

    }
}
