﻿Public NotInheritable Class SplashForm

  'TODO: This form can easily be Set as the splash screen for the application by going to the "Application" Tab
  '  of the Project Designer ("Properties" under the "Project" menu).

#Region "Private Methods"

  Private Sub SplashForm_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
    'Set up the dialog text at runtime according to the application's assembly information.

    'TODO: Customize the application's assembly information in the "Application" pane of the project
    '  properties dialog (under the "Project" menu).

    'Format the version information using the text Set into the Version control at design time as the
    '  formatting string.  This allows for effective localization if desired.
    '  Build and revision information could be included by using the following code and changing the
    '  Version control's designtime text to "Version {0}.{1:00}.{2}.{3}" or something similar.  See
    '  String.Format() in Help for more information.
    '
    '    Version.Text = System.String.Format(Version.Text, My.Application.Info.Version.Major, My.Application.Info.Version.Minor, My.Application.Info.Version.Build, My.Application.Info.Version.Revision)

    Version.Text = String.Format(Version.Text, My.Application.Info.Version.Major, My.Application.Info.Version.Minor)

    'Copyright info
    Copyright.Text = My.Application.Info.Copyright
  End Sub

#End Region

End Class