Imports System
Imports System.Collections.ObjectModel
Imports System.Linq

Namespace CustomEditSettingExample
	Friend Class TaskViewModel
		Private _List As ObservableCollection(Of Task)
		Public ReadOnly Property List() As ObservableCollection(Of Task)
			Get
				If _List Is Nothing Then
					_List = New ObservableCollection(Of Task)()
					For i As Integer = 0 To 99
						_List.Add(New Task() With {
							.Name = "Task" & i,
							.Date = Date.Now.AddDays((New Random(i)).Next(1, 31))
						})
					Next i
				End If
				Return _List
			End Get
		End Property

		Public Class Task
			Public Property Name() As String
			Public Property [Date]() As Date
		End Class
	End Class
End Namespace
