﻿Imports System.Windows
Imports System.Windows.Controls
Imports AutoUpdaterDotNET
Imports FAST2.Models

Class Settings
    'Switches base theme between light and dark when control is switched 
    Private Sub IBaseThemeButton_Click(sender As Object, e As RoutedEventArgs) Handles IBaseThemeToggle.Click
        AppTheme.SwitchBase(IBaseThemeToggle.IsChecked)
        MainWindow.Instance.IWindowCloseButton.Background = FindResource("MaterialDesignPaper")
    End Sub

    Private Shared Sub PrimaryColour_Click(sender As Button, e As RoutedEventArgs) Handles IYellowP.Click, IAmberP.Click, IDeepOrangeP.Click, ILightBlueP.Click, ITealP.Click, ICyanP.Click, IPinkP.Click, IGreenP.Click, IDeepPurpleP.Click, IIndigoP.Click, ILightGreenP.Click, IBlueP.Click, ILimeP.Click, IRedP.Click, IOrangeP.Click, IPurpleP.Click, IBlueGreyP.Click, IGreyP.Click
        Dim colour As String = sender.Background.ToString

        AppTheme.ApplyPrimary(colour)
        My.Settings.primaryColour = colour
        My.Settings.Save()
    End Sub

    Private Shared Sub AccentColour_Click(sender As Button, e As RoutedEventArgs) Handles IYellowA.Click, IAmberA.Click, IDeepOrangeA.Click, ILightBlueA.Click, ITealA.Click, ICyanA.Click, IPinkA.Click, IGreenA.Click, IDeepPurpleA.Click, IIndigoA.Click, ILightGreenA.Click, IBlueA.Click, ILimeA.Click, IRedA.Click, IOrangeA.Click, IPurpleA.Click
        Dim colour As String = sender.Background.ToString

        AppTheme.ApplyAccent(colour)
        My.Settings.accentColour = colour
        My.Settings.Save()
    End Sub

    Private Sub IClearSettings_Click(sender As Object, e As RoutedEventArgs) Handles IClearSettings.Click
        IResetDialog.IsOpen = True
    End Sub

    Private Sub IResetButton_Click(sender As Object, e As RoutedEventArgs) Handles IResetButton.Click
        My.Settings.clearSettings = true
        Forms.Application.Restart()
        Windows.Application.Current.Shutdown()
    End Sub

    Private Sub Settings_Initialized(sender As Object, e As EventArgs) Handles Me.Initialized
        'IExcludeServerFolder.IsChecked = My.Settings.excludeServerFolder
        IBaseThemeToggle.IsChecked = My.Settings.isDark
        IModUpdatesOnLaunch.IsChecked = My.Settings.checkForModUpdates
        IAppUpdatesOnLaunch.IsChecked = My.Settings.checkForAppUpdates
        ISteamApiKeyBox.Text = My.Settings.steamApiKey
        UpdateLocalModFolders()
    End Sub

    Private Sub INewLocalFolder_Click(sender As Object, e As RoutedEventArgs) Handles INewLocalFolder.Click
        My.Settings.localModFolders.Add(MainWindow.SelectFolder())
        UpdateLocalModFolders()
    End Sub

    Private Sub IRemoveLocalFolders_Click(sender As Object, e As RoutedEventArgs) Handles IRemoveLocalFolders.Click
        For Each folder In ILocalModFolders.SelectedItems
            My.Settings.localModFolders.Remove(folder)
        Next
        UpdateLocalModFolders()
    End Sub
    Private Sub IModUpdatesOnLaunch_Checked(sender As Object, e As RoutedEventArgs) Handles IModUpdatesOnLaunch.Click
        My.Settings.checkForModUpdates = IModUpdatesOnLaunch.IsChecked
        My.Settings.Save()
    End Sub
    Private Sub IAppUpdatesOnLaunch_Checked(sender As Object, e As RoutedEventArgs) Handles IAppUpdatesOnLaunch.Click
        My.Settings.checkForAppUpdates = IAppUpdatesOnLaunch.IsChecked
        My.Settings.Save()
    End Sub

    Private Sub UpdateLocalModFolders()
        ILocalModFolders.Items.Clear()

        If My.Settings.localModFolders.Count > 0
            For Each folder in My.Settings.localModFolders
                ILocalModFolders.Items.Add(folder)
            Next
        End If
    End Sub

    Private Sub IUpdateApp_Click(sender As Object, e As RoutedEventArgs) Handles IUpdateApp.Click
        AutoUpdater.ReportErrors = True
        AutoUpdater.Start("https://deploy.kestrelstudios.co.uk/updates/FAST2.xml")
    End Sub

    Private Sub ISteamApiKeyBox_TextChanged(sender As Object, e As TextChangedEventArgs) Handles ISteamApiKeyBox.TextChanged
        My.Settings.steamApiKey = ISteamApiKeyBox.Text
        My.Settings.Save()
    End Sub

    Private Sub Settings_Loaded(sender As Object, e As RoutedEventArgs) Handles Me.Loaded
        ISteamApiKeyBox.Text = My.Settings.steamApiKey
    End Sub
End Class
