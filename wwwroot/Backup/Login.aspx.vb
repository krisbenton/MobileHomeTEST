Public Class WebForm1
    Inherits System.Web.UI.Page
    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        txtUserID.Focus()

        If Not Me.IsPostBack Then
            If Not Me.IsPostBack Then
                Dim userName As String = Request.QueryString("u")
                Dim password As String = Request.QueryString("p")

                If userName <> Nothing Then
                    Me.txtUserID.Text = userName
                    Me.txtPassword.Text = password
                    Login()
                End If

                Me.RecallUserCredentials()
                '
                'if Email is supplied in query string then show it in the Email field
                Dim QueryString As NameValueCollection = Request.QueryString
                Dim Values As String() = QueryString.GetValues("userID")
                If (Values IsNot Nothing) AndAlso (Values.Count <> 0) Then
                    Dim value As String = Values(0)
                    If (value IsNot Nothing) AndAlso (value.Trim.Length <> 0) Then
                        Me.txtUserID.Text = value
                    End If
                End If

                If Me.txtUserID.Text.Trim.Length = 0 Then
                    Me.txtUserID.Focus()
                End If

            End If

            'If Me.txtUserID.Text <> Nothing Then
            '    Login()
            'End If

            'Me.RecallUserCredentials()
            ''
            ''if Email is supplied in query string then show it in the Email field
            'Dim QueryString As NameValueCollection = Request.QueryString
            'Dim Values As String() = QueryString.GetValues("userID")
            'If (Values IsNot Nothing) AndAlso (Values.Count <> 0) Then
            '    Dim value As String = Values(0)
            '    If (value IsNot Nothing) AndAlso (value.Trim.Length <> 0) Then
            '        Me.txtUserID.Text = value
            '    End If
            'End If

            'If Me.txtUserID.Text.Trim.Length = 0 Then
            '    Me.txtUserID.Focus()
            'End If

        End If

        'Me.lblServer.Text = HttpContext.Current.Server.MachineName
    End Sub

    Private Sub RecallUserCredentials()
        If Request.Cookies.Get(mySession.CookieName & "userInfo") IsNot Nothing Then
            Dim value As String = Request.Cookies.Get(mySession.CookieName & "userInfo").Item("userID")
            If value IsNot Nothing Then
                Me.txtUserID.Text = Server.HtmlEncode(value)
                Me.txtPassword.Focus()
            End If
        End If
    End Sub

    Protected Sub btnLogin_Click(ByVal sender As Object, ByVal e As EventArgs) Handles btnLogin.Click
        Login()
    End Sub

    Private Sub Login()
        Me.Validate()
        If Me.IsValid() Then
            Me.ProcessLoginCredentials()
        Else
            Me.txtPassword.Focus()
        End If
    End Sub

    Private Sub ProcessLoginCredentials()
        
        Dim ds As System.Data.DataSet
        Try
            ds = runQueryDSlocal("EXEC wrwpaqbx_admin.procGetLoginCredentials '" & Me.txtUserID.Text.Trim & "','" & Me.txtPassword.Text.Trim & "'", "ColonialPLConnectionString")
            If ds.Tables(0).Rows.Count = 1 Then
                'login successful
                Dim myUserData As Common.UserData
                Dim XmlData As String = ds.Tables(0).Rows(0).Item("xmlData")

                'With myUserData
                '    .ID = Me.txtUserID.Text.Trim
                '    .AdminUser = ds.Tables(0).Rows(0).Item("AdminUser")
                '    'if admin, automatically make UW
                '    .UWUser = .AdminUser Or ds.Tables(0).Rows(0).Item("UWUser")
                '    .Accounting = ds.Tables(0).Rows(0).Item("Accounting")
                '    .Email = ds.Tables(0).Rows(0).Item("Email")
                '    .AccountNumber = ds.Tables(0).Rows(0).Item("AccountNumber")
                '    .AgencyName = ds.Tables(0).Rows(0).Item("AgencyName")
                '    .AgentName = ds.Tables(0).Rows(0).Item("AgentName")
                '    .Address1 = ds.Tables(0).Rows(0).Item("Address1")
                '    .Address2 = ds.Tables(0).Rows(0).Item("Address2")
                '    .City = ds.Tables(0).Rows(0).Item("City")
                '    .State = ds.Tables(0).Rows(0).Item("State")
                '    .Zip = ds.Tables(0).Rows(0).Item("Zip")
                '    .Phone = ds.Tables(0).Rows(0).Item("Phone")
                '    .Fax = ds.Tables(0).Rows(0).Item("Fax")
                '    .Password = Me.txtPassword.Text

                'End With
                With myUserData
                    .ID = Me.txtUserID.Text.Trim
                    .AdminUser = XmlData.GetXMLElementValue("AdminUser").ToBoolean
                    'if admin, automatically make UW
                    .UWUser = .AdminUser Or XmlData.GetXMLElementValue("UWUser").ToBoolean
                    .Accounting = XmlData.GetXMLElementValue("Accounting").ToBoolean
                    .Email = XmlData.GetXMLElementValue("Email")
                    .AccountNumber = XmlData.GetXMLElementValue("AccountNumber")
                    .AgencyName = XmlData.GetXMLElementValue("AgencyName")
                    .AgentName = XmlData.GetXMLElementValue("AgentName")
                    .Address1 = XmlData.GetXMLElementValue("Address1")
                    .Address2 = XmlData.GetXMLElementValue("Address2")
                    .City = XmlData.GetXMLElementValue("City")
                    .State = XmlData.GetXMLElementValue("State")
                    .Zip = XmlData.GetXMLElementValue("Zip")
                    .Phone = XmlData.GetXMLElementValue("Phone")
                    .Fax = XmlData.GetXMLElementValue("Fax")
                    .Password = Me.txtPassword.Text
                    ' If Not myRow.IsWebPasswordNull Then .WebPassword = myRow.WebPassword
                End With

                FormsAuthentication.SetAuthCookie(Me.txtUserID.Text.Trim, False)
                '
                'create CurrentUser session object variable
                mySession.CurrentUser = myUserData
                mySession.CurrentSub = mySession.CurrentUser
                mySession.UWUser = myUserData
                mySession.AdminUser = myUserData

                '
                ''Remember Me'
                Me.RememberMe()
                'transfer to program page
                Response.Redirect("Default.aspx")
            Else
                GoTo UseWeb

            End If
        Catch ex As Exception
            Common.AjaxMsgBoxShow(Me.Page, ex.Message)
            'Stop
        End Try


UseWeb:
        Dim cn As New SqlClient.SqlConnection(System.Configuration.ConfigurationManager.ConnectionStrings("ColonialWebConnectionString").ConnectionString)

        Try
            Dim cmd As New SqlClient.SqlCommand
            cmd.Connection = cn
            cmd.CommandText = "SELECT * FROM wrwpaqbx_admin.vwAgents WHERE AgentCode LIKE '" & Me.txtUserID.Text & "' AND AgentPassword LIKE '" & Me.txtPassword.Text & "'"
            If cmd.Connection.State = ConnectionState.Closed Then cmd.Connection.Open()

            Dim rs As SqlClient.SqlDataReader = cmd.ExecuteReader
            If rs.Read Then
                Dim myUserData As Common.UserData

                With myUserData
                    .ID = rs("ID")
                    .AdminUser = False
                    'if admin, automatically make UW
                    .UWUser = False
                    .Email = rs("AgentEmail")
                    .AccountNumber = rs("AgentCode")
                    .AgencyName = rs("AgencyName")
                    .AgentName = rs("AgentName")
                    .Address1 = rs("Address1")
                    .Address2 = rs("Address2")
                    .City = rs("City")
                    .State = rs("State")
                    .Zip = rs("Zip")
                    .Phone = rs("Phone")
                    .Fax = rs("Fax")
                    .WebPassword = rs("AgentPassword")
                End With
                '
                'create CurrentUser session object variable
                mySession.CurrentUser = myUserData
                mySession.CurrentSub = mySession.CurrentUser
            Else
                'login not successful
                Me.ShowStatus("Invalid Login.")
            End If
            rs.Close()
            '
            ''Remember Me'
            Me.RememberMe()
            'transfer to program page
            Response.Redirect("Default.aspx")

        Catch ex As Exception
            Common.AjaxMsgBoxShow(Me.Page, ex.Message)
            Stop
        Finally
            cn.Close()
        End Try
    End Sub

    'Private Sub ProcessLoginCredentials()
    '   Dim myTA As New CommonDataSetTableAdapters.GetLoginCredentialsTableAdapter
    '   Dim myTable As New CommonDataSet.GetLoginCredentialsDataTable

    '   Try
    '      myTA.Fill(dataTable:=myTable, UserID:=Me.txtUserID.Text.Trim, Password:=Me.txtPassword.Text.Trim)

    '      If myTable.Rows.Count = 1 Then
    '         Dim myRow As CommonDataSet.GetLoginCredentialsRow = myTable.Rows(0)

    '         If myRow.StatusCode = 0 Then
    '            'login not successful
    '            Me.ShowStatus(myRow.StatusText)
    '         Else
    '            'login successful
    '            Dim myUserData As DBSupport.UserData
    '            Dim XmlData As String = myRow.xmlData

    '            With myUserData
    '               .ID = Me.txtUserID.Text.Trim
    '               .AdminUser = XmlData.GetXMLElementValue("AdminUser").ToBoolean
    '               'if admin, automatically make UW
    '               .UWUser = .AdminUser Or XmlData.GetXMLElementValue("UWUser").ToBoolean
    '               .Email = XmlData.GetXMLElementValue("Email")
    '               .AccountNumber = XmlData.GetXMLElementValue("AccountNumber")
    '               .AgencyName = XmlData.GetXMLElementValue("AgencyName")
    '               .Address1 = XmlData.GetXMLElementValue("Address1")
    '               .Address2 = XmlData.GetXMLElementValue("Address2")
    '               .City = XmlData.GetXMLElementValue("City")
    '               .State = XmlData.GetXMLElementValue("State")
    '               .Zip = XmlData.GetXMLElementValue("Zip")
    '               .Phone = XmlData.GetXMLElementValue("Phone")
    '               .Fax = XmlData.GetXMLElementValue("Fax")
    '            End With
    '            '
    '            'create CurrentUser session object variable
    '            mySession.CurrentUser = myUserData
    '            mySession.CurrentSub = mySession.CurrentUser
    '            '
    '            ''Remember Me'
    '            Me.RememberMe()
    '            'transfer to program page
    '            Response.Redirect("ProgramPage.aspx")
    '         End If
    '      End If
    '   Catch ex As Exception
    '      Common.AjaxMsgBoxShow(Me.Page, ex.Message)
    '      ErrHandler.HandleError(ex)
    '   End Try
    'End Sub

    Private Sub RememberMe()
        'add cookie
        Dim myCookie As New HttpCookie(mySession.CookieName & "userInfo")
        myCookie.Values("userID") = Me.txtUserID.Text
        myCookie.Expires = DateTime.Now.AddDays(7)
        Response.Cookies.Add(myCookie)
    End Sub

    Private Sub ShowStatus(ByVal StatusText As String)
        Me.lblLoginStatus.Text = StatusText
    End Sub
    Function runQueryDSlocal(ByVal str As String, ByVal connectionString As String)
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

   
End Class

