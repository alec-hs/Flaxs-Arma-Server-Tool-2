Imports Microsoft.AppCenter
Imports Microsoft.AppCenter.Analytics
Imports Microsoft.AppCenter.Crashes


Class Application

    ' Application-level events, such as Startup, Exit, and DispatcherUnhandledException
    ' can be handled in this file.

    'APP SECRET MUST BE REMOVED BEFORE COMMITING ONLY ADD IN PROD BUILD
    Protected Overrides Sub OnStartup(ByVal e As StartupEventArgs)
        MyBase.OnStartup(e)
        AppCenter.LogLevel = LogLevel.Verbose
        'AppCenter.Start(INSERT_APP_SECRET, GetType(Analytics), GetType(Crashes))
    End Sub
End Class
