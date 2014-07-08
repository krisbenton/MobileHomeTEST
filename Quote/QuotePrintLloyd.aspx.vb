Imports System.Data.SqlClient
Imports System.IO

Imports TallComponents.PDF.JavaScript
Imports TallComponents.PDF.Annotations.Widgets
Imports TallComponents.PDF.Forms.Fields
Public Class QuotePrintLloyd
    Inherits System.Web.UI.Page

    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        Dim quoteID As String

        If Request.QueryString("quoteID") <> "" Then '  quoteID is not empty
            quoteID = Request.QueryString("quoteID")
            '  Packagetype = Request.QueryString("PackageType")


            Dim ds1 As System.Data.DataSet
            Dim ds2 As System.Data.DataSet
            Dim ds3 As System.Data.DataSet
            Dim ds4 As System.Data.DataSet
            ds1 = Common.runQueryDS("SELECT * FROM tblQuotes q LEFT JOIN (SELECT DISTINCT AgencyID,AgencyCode,AgencyName,ssad1 AS AgentAddr1, Address2 AS AgentAddr2,City AS AgentCity,State AS AgentState,Zip AS AgentZip, agency.sscnt3 AS AgentPhone FROM wrwpaqbx_ColonialWeb.wrwpaqbx_admin.vwAgents as agent left join [wrwpaqbx_ColonialWeb].[wrwpaqbx_admin].[Agency] as agency on agency.sssub = agent.AgencyCode)vwag ON q.agencyName = vwag.AgencyName WHERE QuoteID = '" & quoteID & "'")
            ds2 = Common.runQueryDS("EXEC sp_getQuotePrintPrem '" & quoteID & "'")
            ds3 = Common.runQueryDS("Select * from tblQuoteCalcs where QuoteID = '" & quoteID & "'")
            ds4 = Common.runQueryDS("Select * from tblARQuotes where QuoteID = '" & quoteID & "'")


            If ds1.Tables(0).Rows.Count > 0 Then
                ' printQuote(ds1, ds2, ds3, ds4)
            End If

            'ds2 = runQueryDS("SELECT * FROM tblARQuotes WHERE QuoteID = '" & quoteID & "'", "ColonialMHConnectionString")
            'If ds2.Tables(0).Rows.Count > 0 Then

            'End If
        End If
    End Sub

End Class