Imports Microsoft.VisualBasic
Imports System
Imports System.Collections.Generic
Imports System.Linq
Imports System.Text
Imports System.Windows
Imports System.Windows.Controls
Imports System.Windows.Data
Imports System.Windows.Documents
Imports System.Windows.Input
Imports System.Windows.Media
Imports System.Windows.Media.Imaging
Imports System.Windows.Navigation
Imports System.Windows.Shapes
Imports DevExpress.Xpf.Grid
Imports System.Collections.ObjectModel
Imports DevExpress.Data.Filtering.Helpers
Imports System.ComponentModel

Namespace DXSample
	Partial Public Class MainWindow
		Inherits Window
		Public Sub New()
			InitializeComponent()
			Dim list As New List(Of TestData)()
			For i As Integer = 0 To 19
				list.Add(New TestData(i) With {.ParentId = 2})
			Next i
			list(4).ParentId = -1
			list(5).ParentId = 4
			list(6).ParentId = 4
			list(7).ParentId = 4
			treeList.ItemsSource = list
		End Sub
	End Class

	Public Class TestData
		Private privateKeyId As Integer
		Public Property KeyId() As Integer
			Get
				Return privateKeyId
			End Get
			Set(ByVal value As Integer)
				privateKeyId = value
			End Set
		End Property
		Private privateParentId As Integer
		Public Property ParentId() As Integer
			Get
				Return privateParentId
			End Get
			Set(ByVal value As Integer)
				privateParentId = value
			End Set
		End Property
		Private privateNumber As Integer
		Public Property Number() As Integer
			Get
				Return privateNumber
			End Get
			Set(ByVal value As Integer)
				privateNumber = value
			End Set
		End Property
		Private privateText As String
		Public Property Text() As String
			Get
				Return privateText
			End Get
			Set(ByVal value As String)
				privateText = value
			End Set
		End Property
		Private privateBool As Boolean
		Public Property Bool() As Boolean
			Get
				Return privateBool
			End Get
			Set(ByVal value As Boolean)
				privateBool = value
			End Set
		End Property
		Public Sub New(ByVal i As Integer)
			Number = i
			KeyId = i
			Text = "Row" & i
			Bool = i Mod 3 <> 0
		End Sub
	End Class
End Namespace
