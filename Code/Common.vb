Public Module Structures
    Public Structure NameValuePair
        Dim name As String
        Dim value As String

        Public Sub New(ByVal name As String, ByVal value As String)
            Me.name = name
            Me.value = value
        End Sub
    End Structure
End Module

Public Class Common
    Structure UserData
        Dim ID As String
        'Dim AgentCode As String
        Dim Email As String
        Dim AccountNumber As String
        Dim AgencyName As String
        Dim Address1 As String
        Dim Address2 As String
        Dim City As String
        Dim State As String
        Dim Zip As String
        Dim Phone As String
        Dim Fax As String
        Dim AgentName As String
        Dim AdminUser As Boolean
        Dim UWUser As Boolean
        Dim Accounting As Boolean
        Dim LockedOut As Boolean
        Dim Password As String
        Dim WebPassword As String



        ReadOnly Property AuditIdentifier() As String
            Get
                Return Me.ID
            End Get
        End Property
    End Structure

    'Message Box
    Shared Sub AjaxMsgBoxShow(ByVal Owner As Page, ByVal Message As String)
        Try
            Dim myScript As String

            myScript = "alert('" & Message & "');"

            ' use the script manager to attach a new local script to popup a message box
            ScriptManager.RegisterStartupScript(Owner, Owner.GetType(), "MyScript", myScript, True)

        Catch ex As Exception
            'Error
            Stop
        End Try
    End Sub
    'SQL function
    'SQL Helper Fucntion
    Shared Function runQueryDS(ByVal str As String)
        Dim Connection As String = System.Configuration.ConfigurationManager.ConnectionStrings("ColonialMHConnectionString").ConnectionString
        Dim dbConnection As System.Data.IDbConnection = New System.Data.SqlClient.SqlConnection(Connection)
        Dim queryString = str
        Dim dbCommand As System.Data.IDbCommand = New System.Data.SqlClient.SqlCommand
        dbCommand.CommandText = queryString
        dbCommand.Connection = dbConnection
        Dim dataAdapter As System.Data.IDbDataAdapter = New System.Data.SqlClient.SqlDataAdapter
        dataAdapter.SelectCommand = dbCommand
        Dim dataSet As System.Data.DataSet = New System.Data.DataSet
        dataAdapter.Fill(dataSet)
        Return dataSet
    End Function
    'SQL Helper Fucntion
    Function runQueryDS(ByVal str As String, ByVal connectionString As String)
        Dim Connection As String = System.Configuration.ConfigurationManager.ConnectionStrings(connectionString).ConnectionString
        Dim dbConnection As System.Data.IDbConnection = New System.Data.SqlClient.SqlConnection(Connection)
        Dim queryString = str
        Dim dbCommand As System.Data.IDbCommand = New System.Data.SqlClient.SqlCommand
        dbCommand.CommandText = queryString
        dbCommand.Connection = dbConnection
        Dim dataAdapter As System.Data.IDbDataAdapter = New System.Data.SqlClient.SqlDataAdapter
        dataAdapter.SelectCommand = dbCommand
        Dim dataSet As System.Data.DataSet = New System.Data.DataSet
        dataAdapter.Fill(dataSet)
        Return dataSet
    End Function
    'Shared Sub AjaxOpenWindow(ByVal Owner As Page, ByVal url As String, Optional ByVal height As Integer = 240, Optional ByVal width As Integer = 320, Optional ByVal scrollbars As Boolean = False, Optional ByVal addressbar As Boolean = False)
    Shared Sub AjaxOpenWindow(ByVal Owner As Page, ByVal url As String, ByVal windowArgs As String, Optional ByVal windowNum As Integer = 1)
        Try
            Dim myScript As String ', sScrollBars, sAddressBar As String

            'If scrollbars = True Then sScrollBars = "1" Else sScrollBars = "0"
            'If addressbar = True Then sAddressBar = "1" Else sAddressBar = "0"

            'myScript = "window.open('" & url & "','_blank', 'height=" & height & ",width=" & width & ",scrollbars=" & sScrollBars & ",location=" & sAddressBar & ",resizable=1');"
            If windowArgs Is Nothing OrElse windowArgs.Trim.Length = 0 Then
                'myScript = "window.open('" & url & "','_blank');"
                myScript = "myWindow" & windowNum & "=window.open('" & url & "','_blank');myWindow" & windowNum & ".focus();"
            Else
                myScript = "myWindow" & windowNum & "=window.open('" & url & "','_blank','" & windowArgs & "');myWindow" & windowNum & ".focus();"
            End If

            ' use the script manager to attach a new local script to popup a message box
            ScriptManager.RegisterStartupScript(Owner, Owner.GetType(), "MyScript" & windowNum, myScript, True)

        Catch ex As Exception

        End Try
    End Sub
End Class
