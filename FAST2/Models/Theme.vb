Imports MaterialDesignThemes.Wpf

Namespace Models
    Public Class AppTheme
        Shared ReadOnly paletteHelper = New PaletteHelper()
        Shared ReadOnly appTheme As ITheme = paletteHelper.GetTheme

        'Switches base theme between light and dark
        Public Shared Sub SwitchBase(isDark)
            If isDark Then
                appTheme.SetBaseTheme(Theme.Dark)
            Else
                appTheme.SetBaseTheme(Theme.Light)
            End If
            paletteHelper.SetTheme(appTheme)

            My.Settings.isDark = isDark
            My.Settings.Save()
        End Sub

        'Changes palette primary colour
        Public Shared Sub ApplyPrimary(colour)
            appTheme.SetPrimaryColor(ColorConverter.ConvertFromString(colour))
            paletteHelper.SetTheme(appTheme)
        End Sub

        'Changes palette accent colour
        Public Shared Sub ApplyAccent(colour)
            appTheme.SetSecondaryColor(ColorConverter.ConvertFromString(colour))
            paletteHelper.SetTheme(appTheme)
        End Sub

        Public Shared Sub ApplyTheme()
            ApplyPrimary(My.Settings.primaryColour)
            ApplyAccent(My.Settings.accentColour)
            SwitchBase(My.Settings.isDark)
        End Sub
    End Class
End NameSpace