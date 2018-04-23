Imports Microsoft.VisualBasic
Imports System
Imports System.Collections.Generic
Imports System.ComponentModel
Imports System.Data
Imports System.Drawing

Imports System.Text
Imports System.Windows.Forms

Namespace KeepSelection
	Partial Public Class Form1
		Inherits Form
		Private helper As KeepSelectionHelper
		Private Function CreateTable(ByVal RowCount As Integer) As DataTable
			Dim tbl As New DataTable()
			tbl.Columns.Add("Name", GetType(String))
			tbl.Columns.Add("ID", GetType(Integer))
			tbl.Columns.Add("Number", GetType(Integer))
			tbl.Columns.Add("Date", GetType(DateTime))
			For i As Integer = 0 To RowCount - 1
				tbl.Rows.Add(New Object() { String.Format("Name{0}", i), i, 3 - i, DateTime.Now.AddDays(i) })
			Next i
			Return tbl

		End Function

		Public Sub New()
			InitializeComponent()
			gridControl1.DataSource = CreateTable(6)
			helper = New KeepSelectionHelper(gridView1)
		End Sub

		Private Sub Form1_Load(ByVal sender As Object, ByVal e As EventArgs) Handles MyBase.Load

		End Sub

		Private Sub simpleButton1_Click(ByVal sender As Object, ByVal e As EventArgs) Handles simpleButton1.Click
			gridView1.OptionsSelection.MultiSelectMode = DevExpress.XtraGrid.Views.Grid.GridMultiSelectMode.RowSelect
			helper.UpdateSelectionMode()
			gridView1.ClearSelection()
			gridView1.SelectRow(0)
			gridView1.SelectRow(2)
			gridView1.SelectRow(4)
		End Sub

        Private Sub checkButton1_CheckedChanged(ByVal sender As Object, ByVal e As EventArgs) Handles checkButton1.CheckedChanged
            If helper IsNot Nothing Then
                helper.KeepSelectedOnClick = checkButton1.Checked
            End If
        End Sub

		Private Sub simpleButton2_Click(ByVal sender As Object, ByVal e As EventArgs) Handles simpleButton2.Click
			gridView1.OptionsSelection.MultiSelectMode = DevExpress.XtraGrid.Views.Grid.GridMultiSelectMode.CellSelect
			helper.UpdateSelectionMode()
			gridView1.ClearSelection()
			gridView1.SelectCell(0, gridView1.VisibleColumns(0))
			gridView1.SelectCell(1, gridView1.VisibleColumns(1))
			gridView1.SelectCell(2, gridView1.VisibleColumns(2))
			gridView1.SelectCell(3, gridView1.VisibleColumns(3))
			gridView1.SelectCell(2, gridView1.VisibleColumns(0))
			gridView1.SelectCell(3, gridView1.VisibleColumns(1))
			gridView1.SelectCell(4, gridView1.VisibleColumns(2))
			gridView1.SelectCell(5, gridView1.VisibleColumns(3))



		End Sub

	End Class
End Namespace
