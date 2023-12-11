Imports System.ComponentModel
Imports System.Configuration

Namespace My

  ''' <summary>
  '''     My.Settings Events
  ''' </summary>
  Partial Friend NotInheritable Class MySettings

#Region "Private Methods"

    ''' <summary>
    '''     The PropertyChanged event is raised after a Setting's value is changed.
    ''' </summary>
    ''' <param name="sender">
    ''' </param>
    ''' <param name="e">
    ''' </param>
    Private Sub MySettings_PropertyChanged(sender As Object, e As PropertyChangedEventArgs) Handles Me.PropertyChanged

    End Sub

    ''' <summary>
    '''     The SettingChanging event is raised before a Setting's value is changed.
    ''' </summary>
    ''' <param name="sender">
    ''' </param>
    ''' <param name="e">
    ''' </param>
    Private Sub MySettings_SettingChanging(sender As Object, e As SettingChangingEventArgs) Handles Me.SettingChanging

    End Sub

    ''' <summary>
    '''     The SettingsLoaded event is raised after the Setting values are loaded.
    ''' </summary>
    ''' <param name="sender">
    ''' </param>
    ''' <param name="e">
    ''' </param>
    Private Sub MySettings_SettingsLoaded(sender As Object, e As SettingsLoadedEventArgs) Handles Me.SettingsLoaded

    End Sub

    ''' <summary>
    '''     The SettingsSaving event is raised before the Setting values are saved.
    ''' </summary>
    ''' <param name="sender">
    ''' </param>
    ''' <param name="e">
    ''' </param>
    Private Sub MySettings_SettingsSaving(sender As Object, e As CancelEventArgs) Handles Me.SettingsSaving

    End Sub

#End Region

  End Class

End Namespace