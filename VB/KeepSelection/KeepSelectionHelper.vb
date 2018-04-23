Imports Microsoft.VisualBasic
Imports System
Imports System.Collections.Generic
Imports System.Text
Imports DevExpress.XtraGrid.Views.Grid
Imports System.Windows.Forms
Imports DevExpress.XtraGrid.Views.Grid.ViewInfo
Imports DevExpress.Data
Imports DevExpress.XtraGrid
Imports DevExpress.XtraGrid.Views.Base
Imports DevExpress.XtraGrid.Columns

Namespace KeepSelection
	Friend Class KeepSelectionHelper
		Public KeepSelectedOnClick As Boolean
		Private View As GridView
		Private selectedRows() As Integer
		Private mode As GridMultiSelectMode
		Private SelectedCells() As GridCell

		Public Sub New(ByVal view As GridView)
			KeepSelectedOnClick = True
			Me.View = view
			AddHandler Me.View.ShownEditor, AddressOf ShownEditor
			AddHandler Me.View.MouseDown, AddressOf MouseDown
			mode = Me.View.OptionsSelection.MultiSelectMode
		End Sub
		Public Sub UpdateSelectionMode()
			mode = View.OptionsSelection.MultiSelectMode
		End Sub
		Private Sub ShownEditor(ByVal sender As Object, ByVal e As EventArgs)
			If (Not KeepSelectedOnClick) Then
				Return
			End If
            If mode = GridMultiSelectMode.RowSelect Then
                If selectedRows Is Nothing Then
                    Return
                End If
                For Each row As Integer In selectedRows
                    If row = View.FocusedRowHandle Then
                        For Each selectedRow As Integer In selectedRows
                            View.SelectRow(selectedRow)
                        Next selectedRow
                    End If
                Next row
                selectedRows = Nothing
            Else
                If SelectedCells Is Nothing Then
                    Return
                End If
                Dim selected As Boolean = False
                For Each cell As GridCell In SelectedCells
                    If (cell.RowHandle = View.FocusedRowHandle) AndAlso (cell.Column Is View.FocusedColumn) Then
                        selected = True
                    End If
                Next cell
                If selected Then
                    For Each selectedCell As GridCell In SelectedCells
                        View.SelectCell(selectedCell)
                    Next selectedCell
                End If
            End If

		End Sub
		Private Sub MouseDown(ByVal sender As Object, ByVal e As MouseEventArgs)
			If (Not KeepSelectedOnClick) Then
				Return
			End If
			Dim hi As GridHitInfo = View.CalcHitInfo(e.Location)
            If mode = GridMultiSelectMode.RowSelect Then
                selectedRows = View.GetSelectedRows()
                For Each row As Integer In selectedRows
                    If row = hi.RowHandle Then
                        Return
                    End If
                Next row
                selectedRows = Nothing
            Else
                SelectedCells = View.GetSelectedCells()
                For Each cell As GridCell In SelectedCells
                    If (cell.RowHandle = hi.RowHandle) AndAlso (cell.Column Is hi.Column) Then
                        Return
                    End If
                Next cell
                SelectedCells = Nothing
            End If
		End Sub
	End Class
End Namespace
