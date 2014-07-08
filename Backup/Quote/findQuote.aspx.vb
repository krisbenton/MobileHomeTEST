Public Class findQuote
    Inherits System.Web.UI.Page
    Dim dm As New Common
    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        If Not Page.IsPostBack Then
            txtQuoteID.Attributes.Add("onKeyUp", "return search(event);")
            txtLastName.Attributes.Add("onKeyUp", "return search(event);")
            loadDefault()
        End If
        
    End Sub
    Public Sub btnLogout_Click(ByVal sender As Object, ByVal e As EventArgs)
        mySession.Clear()
        Server.Transfer("~/Login.aspx")

    End Sub
    Public Sub loadDefault()
        Dim quoteID, LastName, tsql As String
        tsql = ""
        Dim ds As System.Data.DataSet

        quoteID = txtQuoteID.Text
        LastName = txtLastName.Text


        tsql = "SELECT quoteID, applicantFirstName + ' ' + applicantLastName AS applicantName, CONVERT(VARCHAR,effDate,101) AS effDate, CASE WHEN ARImportID!='' THEN 'Yes' ELSE 'No' END AS Imported FROM tblQuotes ORDER BY quoteID DESC"


        Try
            ds = dm.runQueryDS(tsql, "ColonialMHConnectionString")
            RadGrid1.DataSource = ds
            RadGrid1.DataBind()
            RadGrid1.Visible = True
        Catch ex As Exception

        End Try
    End Sub
    Private Sub RadGrid1_NeedDataSource(ByVal source As Object, ByVal e As Telerik.Web.UI.GridNeedDataSourceEventArgs) Handles RadGrid1.NeedDataSource
        Dim cn As New SqlClient.SqlConnection(System.Configuration.ConfigurationManager.ConnectionStrings("ColonialMHConnectionString").ConnectionString)
        Dim cmd As New SqlClient.SqlCommand
        cmd.CommandType = CommandType.Text
        cmd.CommandText = "SELECT quoteID, applicantFirstName + ' ' + applicantLastName AS applicantName, CONVERT(VARCHAR,effDate,101) AS effDate FROM tblQuotes ORDER BY quoteID DESC"
        cmd.Connection = cn
        If cmd.Connection.State = ConnectionState.Closed Then cmd.Connection.Open()
        Dim rs As SqlClient.SqlDataReader = cmd.ExecuteReader
        Me.RadGrid1.DataSource = rs
    End Sub
    Public Sub Search_Click() Handles searchbtn.click
        Dim quoteID, LastName, tsql As String
        tsql = ""
        Dim ds As System.Data.DataSet

        quoteID = txtQuoteID.Text
        LastName = txtLastName.Text

        If quoteID <> "" Then
            tsql = "SELECT quoteID, applicantFirstName + ' ' + applicantLastName AS applicantName,CONVERT(VARCHAR,effDate,101) AS effDate  FROM tblQuotes WHERE quoteID = '" & quoteID & "'"
        End If
        If LastName <> "" Then
            tsql = "SELECT quoteID, applicantFirstName + ' ' + applicantLastName AS applicantName,CONVERT(VARCHAR,effDate,101) AS effDate  FROM tblQuotes WHERE applicantLastName LIKE '%" & LastName & "%'"
        End If
        Try
            ds = dm.runQueryDS(tsql, "ColonialMHConnectionString")
            RadGrid1.DataSource = ds
            RadGrid1.DataBind()
            RadGrid1.Visible = True
        Catch ex As Exception

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

End Class