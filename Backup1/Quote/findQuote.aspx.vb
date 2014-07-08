Imports System.Data.SqlClient
Public Class findQuote
    Inherits System.Web.UI.Page
    Dim dm As New Common
    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        If Not Page.IsPostBack Then
            findimport.Attributes.Add("onClick", "redirect3(0); return false;")
            Dim test As String = mySession.CurrentUser.UWUser.ToString
            If mySession.CurrentUser.UWUser.ToString = "False" Then
                findimport.Visible = False

                findimport.Width = "0"
            End If
            If mySession.CurrentUser.AdminUser.ToString = "True" Then
                findimport.Visible = True


            End If
            txtQuoteID.Attributes.Add("onKeyUp", "return search(event);")
            txtLastName.Attributes.Add("onKeyUp", "return search(event);")
            loadDefault()
        End If
        
    End Sub
    Public Sub btnLogout_Click(ByVal sender As Object, ByVal e As EventArgs)
        mySession.Clear()
        Server.Transfer("~/Login.aspx")

    End Sub
    Public Sub Clear_Click() Handles clearbtn.Click
        Response.Redirect("findQuote.aspx")
    End Sub
    Public Sub loadDefault()
        Dim quoteID, LastName, tsql As String
        tsql = ""


        quoteID = txtQuoteID.Text
        LastName = txtLastName.Text
        Dim agency As String
        agency = mySession.CurrentUser.AgencyName
        'If mySession.CurrentUser.AdminUser.ToString = "True" Then
        '    tsql = "SELECT quoteID, applicantFirstName + ' ' + applicantLastName AS applicantName, CONVERT(VARCHAR,effDate,101) AS effDate, CASE WHEN ARImportID!='' THEN 'Yes' ELSE 'No' END AS Imported FROM tblQuotes where ARImportID = 0 ORDER BY quoteID DESC"

        'Else
        '    tsql = "SELECT quoteID, applicantFirstName + ' ' + applicantLastName AS applicantName, CONVERT(VARCHAR,effDate,101) AS effDate, CASE WHEN ARImportID!='' THEN 'Yes' ELSE 'No' END AS Imported FROM tblQuotes where ARImportID = 0 and agencyName = '" & agency & "' ORDER BY quoteID DESC"

        'End If


        'Try
        '    ds = dm.runQueryDS(tsql, "ColonialMHConnectionString")
        '    RadGrid1.DataSource = ds
        '    RadGrid1.DataBind()
        '    RadGrid1.Visible = True
        'Catch ex As Exception

        'End Try

        Dim Connection As String = System.Configuration.ConfigurationManager.ConnectionStrings("ColonialMHConnectionString").ConnectionString
        Dim dbConnection As System.Data.IDbConnection = New System.Data.SqlClient.SqlConnection(Connection)
        Dim cmd As New SqlCommand("sp_find_Quote", dbConnection)
        cmd.CommandType = CommandType.StoredProcedure
        cmd.Parameters.Add("@QuoteID", SqlDbType.VarChar, 8000).Value = ""
        cmd.Parameters.Add("@LastName", SqlDbType.VarChar, 8000).Value = ""
        cmd.Parameters.Add("@Type", SqlDbType.VarChar, 8000).Value = ""
        cmd.Parameters.Add("@Status", SqlDbType.VarChar, 8000).Value = ""
        cmd.Parameters.Add("@RiskState", SqlDbType.VarChar, 8000).Value = ""
        cmd.Parameters.Add("@AgentID", SqlDbType.VarChar, 8000).Value = ""
        cmd.Parameters.Add("@CreateDate", SqlDbType.VarChar, 8000).Value = ""
        cmd.Parameters.Add("@Program", SqlDbType.VarChar, 8000).Value = ""
        cmd.Parameters.Add("@User", SqlDbType.VarChar, 8000).Value = ""
        If mySession.CurrentUser.AdminUser.ToString = "True" Then
            'cmd.CommandText = "SELECT quoteID, applicantFirstName + ' ' + applicantLastName AS applicantName, CONVERT(VARCHAR,effDate,101) AS effDate FROM tblQuotes where ARImportID = 0 ORDER BY quoteID DESC"
            cmd.Parameters.Add("@AgencyName", SqlDbType.VarChar, 8000).Value = ""
        Else
            ' cmd.CommandText = "SELECT quoteID, applicantFirstName + ' ' + applicantLastName AS applicantName, CONVERT(VARCHAR,effDate,101) AS effDate FROM tblQuotes where ARImportID = 0 and agencyName = '" & agency & "' ORDER BY quoteID DESC"
            cmd.Parameters.Add("@AgencyName", SqlDbType.VarChar, 8000).Value = agency
        End If
        ' Dim ds As Data.DataSet = New Data.DataSet
        Try
            Dim ds As Data.DataSet = New Data.DataSet

            cmd.Connection.Open()
            ' intRowsAff = cmd.ExecuteNonQuery()

            Dim myCommand = New SqlDataAdapter(cmd)
            myCommand.Fill(ds, "tbl1")
            RadGrid1.DataSource = ds
            RadGrid1.DataBind()
            RadGrid1.Visible = True

        Catch ex As Exception
            Dim s As String = ""
            For Each param As SqlParameter In cmd.Parameters
                s += param.ParameterName & "="
                s += param.Value & ":  "

            Next
            errortrap("Geting Data for Load of Find Quote " & s, "FindQuote Loading Defualt", ex.Message)
        End Try



    End Sub
    Private Sub RadGrid1_NeedDataSource(ByVal source As Object, ByVal e As Telerik.Web.UI.GridNeedDataSourceEventArgs) Handles RadGrid1.NeedDataSource
        Dim agency As String
        agency = mySession.CurrentUser.AgencyName
        'Dim cn As New SqlClient.SqlConnection(System.Configuration.ConfigurationManager.ConnectionStrings("ColonialMHConnectionString").ConnectionString)
        'Dim cmd As New SqlClient.SqlCommand
        'cmd.CommandType = CommandType.Text
        'If mySession.CurrentUser.AdminUser.ToString = "True" Then
        '    cmd.CommandText = "SELECT quoteID, applicantFirstName + ' ' + applicantLastName AS applicantName, CONVERT(VARCHAR,effDate,101) AS effDate FROM tblQuotes where ARImportID = 0 ORDER BY quoteID DESC"

        'Else
        '    cmd.CommandText = "SELECT quoteID, applicantFirstName + ' ' + applicantLastName AS applicantName, CONVERT(VARCHAR,effDate,101) AS effDate FROM tblQuotes where ARImportID = 0 and agencyName = '" & agency & "' ORDER BY quoteID DESC"

        'End If
        ''cmd.CommandText = "SELECT quoteID, applicantFirstName + ' ' + applicantLastName AS applicantName, CONVERT(VARCHAR,effDate,101) AS effDate FROM tblQuotes where agencyName = '" & agency & "' ORDER BY quoteID DESC"
        'cmd.Connection = cn
        'If cmd.Connection.State = ConnectionState.Closed Then cmd.Connection.Open()
        'Dim rs As SqlClient.SqlDataReader = cmd.ExecuteReader
        'Me.RadGrid1.DataSource = rs

        Dim Connection As String = System.Configuration.ConfigurationManager.ConnectionStrings("ColonialMHConnectionString").ConnectionString
        Dim dbConnection As System.Data.IDbConnection = New System.Data.SqlClient.SqlConnection(Connection)
        Dim cmd As New SqlCommand("sp_find_Quote", dbConnection)
        cmd.CommandType = CommandType.StoredProcedure
        cmd.Parameters.Add("@QuoteID", SqlDbType.VarChar, 8000).Value = ""
        cmd.Parameters.Add("@LastName", SqlDbType.VarChar, 8000).Value = ""
        cmd.Parameters.Add("@Type", SqlDbType.VarChar, 8000).Value = ""
        cmd.Parameters.Add("@Status", SqlDbType.VarChar, 8000).Value = ""
        cmd.Parameters.Add("@RiskState", SqlDbType.VarChar, 8000).Value = ""
        cmd.Parameters.Add("@AgentID", SqlDbType.VarChar, 8000).Value = ""
        cmd.Parameters.Add("@CreateDate", SqlDbType.VarChar, 8000).Value = ""
        cmd.Parameters.Add("@Program", SqlDbType.VarChar, 8000).Value = ""
        cmd.Parameters.Add("@user", SqlDbType.VarChar, 8000).Value = ""
        'cmd.Parameters.Add("@AgencyName", SqlDbType.VarChar, 8000).Value = ""
        If mySession.CurrentUser.AdminUser.ToString = "True" Then
            'cmd.CommandText = "SELECT quoteID, applicantFirstName + ' ' + applicantLastName AS applicantName, CONVERT(VARCHAR,effDate,101) AS effDate FROM tblQuotes where ARImportID = 0 ORDER BY quoteID DESC"
            cmd.Parameters.Add("@AgencyName", SqlDbType.VarChar, 8000).Value = ""
        Else
            ' cmd.CommandText = "SELECT quoteID, applicantFirstName + ' ' + applicantLastName AS applicantName, CONVERT(VARCHAR,effDate,101) AS effDate FROM tblQuotes where ARImportID = 0 and agencyName = '" & agency & "' ORDER BY quoteID DESC"
            cmd.Parameters.Add("@AgencyName", SqlDbType.VarChar, 8000).Value = agency
        End If

        Try
            Dim ds As Data.DataSet = New Data.DataSet

            cmd.Connection.Open()
            ' intRowsAff = cmd.ExecuteNonQuery()

            Dim myCommand = New SqlDataAdapter(cmd)
            myCommand.Fill(ds, "tbl1")
            RadGrid1.DataSource = ds
            'RadGrid1.DataBind()
            RadGrid1.Visible = True

        Catch ex As Exception
            Dim s As String = ""
            For Each param As SqlParameter In cmd.Parameters
                s += param.ParameterName & "="
                s += param.Value & ":  "

            Next
            errortrap("Geting Data for Load of Find Quote " & s, "FindQuote", ex.Message)
        End Try




    End Sub
    Public Sub Search_Click() Handles searchbtn.Click
        Dim agency As String
        agency = mySession.CurrentUser.AgencyName
        'Dim quoteID, LastName, tsql As String
        'tsql = ""
        'Dim ds As System.Data.DataSet

        'quoteID = txtQuoteID.Text
        'LastName = txtLastName.Text
        'If mySession.CurrentUser.AdminUser.ToString = "True" Then
        '    If quoteID <> "" Then
        '        tsql = "SELECT quoteID, applicantFirstName + ' ' + applicantLastName AS applicantName,CONVERT(VARCHAR,effDate,101) AS effDate  FROM tblQuotes WHERE quoteID = '" & quoteID & "' and ARImportID = 0 "
        '    End If
        '    If LastName <> "" Then
        '        tsql = "SELECT quoteID, applicantFirstName + ' ' + applicantLastName AS applicantName,CONVERT(VARCHAR,effDate,101) AS effDate  FROM tblQuotes WHERE applicantLastName LIKE '%" & LastName & "%'  and ARImportID = 0 "
        '    End If
        'Else
        '    If quoteID <> "" Then
        '        tsql = "SELECT quoteID, applicantFirstName + ' ' + applicantLastName AS applicantName,CONVERT(VARCHAR,effDate,101) AS effDate  FROM tblQuotes WHERE quoteID = '" & quoteID & "' and ARImportID = 0 and agencyName = '" & agency & "'"
        '    End If
        '    If LastName <> "" Then
        '        tsql = "SELECT quoteID, applicantFirstName + ' ' + applicantLastName AS applicantName,CONVERT(VARCHAR,effDate,101) AS effDate  FROM tblQuotes WHERE applicantLastName LIKE '%" & LastName & "%'  and ARImportID = 0 and agencyName = '" & agency & "'"
        '    End If
        'End If

        'Try
        '    ds = dm.runQueryDS(tsql, "ColonialMHConnectionString")
        '    RadGrid1.DataSource = ds
        '    RadGrid1.DataBind()
        '    RadGrid1.Visible = True
        'Catch ex As Exception

        'End Try
        Dim Connection As String = System.Configuration.ConfigurationManager.ConnectionStrings("ColonialMHConnectionString").ConnectionString
        Dim dbConnection As System.Data.IDbConnection = New System.Data.SqlClient.SqlConnection(Connection)
        Dim cmd As New SqlCommand("sp_find_Quote", dbConnection)
        cmd.CommandType = CommandType.StoredProcedure
        cmd.Parameters.Add("@QuoteID", SqlDbType.VarChar, 8000).Value = txtQuoteID.Text
        cmd.Parameters.Add("@LastName", SqlDbType.VarChar, 8000).Value = txtLastName.Text
        cmd.Parameters.Add("@Type", SqlDbType.VarChar, 8000).Value = typedd.SelectedValue
        cmd.Parameters.Add("@Status", SqlDbType.VarChar, 8000).Value = statusdd.SelectedValue
        cmd.Parameters.Add("@RiskState", SqlDbType.VarChar, 8000).Value = txtstate.Text
        cmd.Parameters.Add("@AgentID", SqlDbType.VarChar, 8000).Value = txtagentid.Text
        cmd.Parameters.Add("@CreateDate", SqlDbType.VarChar, 8000).Value = txtdate.Text
        cmd.Parameters.Add("@Program", SqlDbType.VarChar, 8000).Value = programdd.SelectedValue
        cmd.Parameters.Add("@user", SqlDbType.VarChar, 8000).Value = txtuser.Text
        'cmd.Parameters.Add("@AgencyName", SqlDbType.VarChar, 8000).Value = ""
        If mySession.CurrentUser.AdminUser.ToString = "True" Then
            'cmd.CommandText = "SELECT quoteID, applicantFirstName + ' ' + applicantLastName AS applicantName, CONVERT(VARCHAR,effDate,101) AS effDate FROM tblQuotes where ARImportID = 0 ORDER BY quoteID DESC"
            cmd.Parameters.Add("@AgencyName", SqlDbType.VarChar, 8000).Value = ""
        Else
            ' cmd.CommandText = "SELECT quoteID, applicantFirstName + ' ' + applicantLastName AS applicantName, CONVERT(VARCHAR,effDate,101) AS effDate FROM tblQuotes where ARImportID = 0 and agencyName = '" & agency & "' ORDER BY quoteID DESC"
            cmd.Parameters.Add("@AgencyName", SqlDbType.VarChar, 8000).Value = agency
        End If

        Try
            Dim ds As Data.DataSet = New Data.DataSet

            cmd.Connection.Open()
            ' intRowsAff = cmd.ExecuteNonQuery()

            Dim myCommand = New SqlDataAdapter(cmd)
            myCommand.Fill(ds, "tbl1")
            RadGrid1.DataSource = ds
            RadGrid1.DataBind()
            RadGrid1.Visible = True

        Catch ex As Exception
            Dim s As String = ""
            For Each param As SqlParameter In cmd.Parameters
                s += param.ParameterName & "="
                s += param.Value & ":  "

            Next
            errortrap("Geting Data for Load of Find Quote " & s, "FindQuote", ex.Message)
        End Try



    End Sub
    Private Sub RadGrid_ItemCommand(ByVal source As Object, ByVal e As Telerik.Web.UI.GridCommandEventArgs) Handles RadGrid1.ItemCommand
        Select Case e.CommandName

            Case "Select"
                Dim quoteID As String
                quoteID = CType(e.Item, Telerik.Web.UI.GridDataItem)("quoteID").Text
                Response.Redirect("quote.aspx?quoteID=" & quoteID & "")




        End Select
    End Sub
    Private Sub errortrap(ByVal sqlcomm As String, ByVal appsub As String, ByVal errormsg As String)
        Dim intRowsAff As Integer
        Dim Connection As String = System.Configuration.ConfigurationManager.ConnectionStrings("ColonialMHConnectionString").ConnectionString
        Dim dbConnection As System.Data.IDbConnection = New System.Data.SqlClient.SqlConnection(Connection)
        Dim cmd As New SqlCommand("sp_InsertError", dbConnection)
        cmd.CommandType = CommandType.StoredProcedure
        cmd.Parameters.Add("@code", SqlDbType.VarChar, 8000).Value = sqlcomm
        cmd.Parameters.Add("@Page", SqlDbType.VarChar, 50).Value = "Find Quote"
        cmd.Parameters.Add("@sub", SqlDbType.VarChar, 50).Value = appsub
        cmd.Parameters.Add("@msg", SqlDbType.VarChar, 8000).Value = errormsg
        Try
            cmd.Connection.Open()
            intRowsAff = cmd.ExecuteNonQuery()
        Catch ex As Exception

        End Try


    End Sub

    Protected Sub btnNewquote_Click(sender As Object, e As EventArgs) Handles btnNewquote.Click
        Response.Redirect("Quote.aspx")
    End Sub
End Class