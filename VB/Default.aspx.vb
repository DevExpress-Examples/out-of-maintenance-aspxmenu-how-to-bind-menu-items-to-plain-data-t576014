Imports DevExpress.Web
Imports System
Imports System.Data

Partial Public Class _Default
	Inherits System.Web.UI.Page

	Protected Sub Page_Init(ByVal sender As Object, ByVal e As EventArgs)
		If Not IsPostBack Then
			Dim table As DataTable = GetDataTable()
			CreateMenuRecursively(table, Menu.Items, "0")
		End If
	End Sub

	Private Sub CreateMenuRecursively(ByVal table As DataTable, ByVal items As MenuItemCollection, ByVal parentID As String)
		For i As Integer = 0 To table.Rows.Count - 1
			If table.Rows(i)("ParentID").ToString() = parentID Then
				Dim item As New MenuItem(table.Rows(i)("Title").ToString(), table.Rows(i)("ID").ToString())
				items.Add(item)
				CreateMenuRecursively(table, item.Items, item.Name)
			End If
		Next i
	End Sub

	Private Function GetDataTable() As DataTable
		Dim dt As New DataTable()
		dt.Columns.Add("ID", GetType(Integer))
		dt.Columns.Add("Title", GetType(String))
		dt.Columns.Add("ParentID", GetType(Integer))

		dt.PrimaryKey = New DataColumn() { dt.Columns("ID") }

		dt.Rows.Add(1, "Node1", 0)
		dt.Rows.Add(2, "Node2", 0)
		dt.Rows.Add(3, "Node3", 0)
		dt.Rows.Add(4, "Node11", 1)
		dt.Rows.Add(5, "Node12", 1)
		dt.Rows.Add(6, "Node21", 2)
		dt.Rows.Add(7, "Node22", 2)
		dt.Rows.Add(8, "Node31", 3)
		dt.Rows.Add(9, "Node32", 3)
		dt.Rows.Add(10, "Node121", 5)

		Return dt
	End Function
End Class