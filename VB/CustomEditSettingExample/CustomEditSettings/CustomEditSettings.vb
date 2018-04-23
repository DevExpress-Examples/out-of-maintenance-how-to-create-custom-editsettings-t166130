Imports DevExpress.Xpf.Editors
Imports DevExpress.Xpf.Editors.Helpers
Imports DevExpress.Xpf.Editors.Settings
Imports System
Imports System.Linq
Imports System.Windows.Media

Namespace CustomEditSettingExample
	Public Class CustomEditSettings
		Inherits TextEditSettings

		Private _EditFont As FontFamily
		Public Property EditFont() As FontFamily
			Get
				Return _EditFont
			End Get
			Set(ByVal value As FontFamily)
				If _EditFont IsNot value Then
					_EditFont = value
				End If
			End Set
		End Property

		Shared Sub New()
			EditorSettingsProvider.Default.RegisterUserEditor2(GetType(TextEdit), GetType(CustomEditSettings), Function(optimized)If(optimized, New InplaceBaseEdit(), DirectCast(New TextEdit(), IBaseEdit)), Function() New CustomEditSettings())
		End Sub

		Public Sub New()
		End Sub

		Protected Overrides Sub AssignToEditCore(ByVal edit As IBaseEdit)
			MyBase.AssignToEditCore(edit)
'INSTANT VB NOTE: The variable editor was renamed since Visual Basic does not handle local variables named the same as class members well:
			Dim editor_Renamed = TryCast(edit, InplaceBaseEdit)
			If editor_Renamed IsNot Nothing Then
				editor_Renamed.FontFamily = EditFont
			End If
		End Sub
	End Class
End Namespace
