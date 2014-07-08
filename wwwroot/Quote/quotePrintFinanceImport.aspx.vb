Imports System.Data.SqlClient
Imports System.IO

Imports TallComponents.PDF.JavaScript
Imports TallComponents.PDF.Annotations.Widgets
Imports TallComponents.PDF.Forms.Fields

Public Class quotePrintFinanceImport
    Inherits System.Web.UI.Page

    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load

        Dim quoteID As String
        Dim myFileStream As FileStream
        Dim mySourcePDF As TallComponents.PDF.Document
        Dim myOutputPDF As TallComponents.PDF.Document
        Dim myPDFFields As New TallComponents.PDF.Document




        myOutputPDF = New TallComponents.PDF.Document


        If Request.QueryString("quoteID") <> "" Then '  quoteID is not empty
            quoteID = Request.QueryString("quoteID")
            '  Packagetype = Request.QueryString("PackageType")


            Try
                
                    'Finance Contract
                    If System.IO.File.Exists(Me.MapPath("~\ApplicationPages/Finance/") & "FinanceContract_" & Request.QueryString("quoteID") & ".pdf") Then
                        myFileStream = New FileStream(Me.MapPath("~\ApplicationPages/Finance/") & "FinanceContract_" & Request.QueryString("quoteID") & ".pdf", FileMode.Open, FileAccess.Read)
                        mySourcePDF = New TallComponents.PDF.Document(myFileStream)
                    ' mySourcePDF.Pages.RemoveAt(5)
                        myPDFFields.Pages.AddRange(mySourcePDF.Pages.CloneToArray())
                        myFileStream.Close()
                        mySourcePDF = Nothing
                    Else
                        'No Finance Contract Present. Continue
                    End If
                   

                    myOutputPDF.Pages.AddRange(myPDFFields.Pages.CloneToArray)

                    Response.ContentType = "application/pdf"
                    myOutputPDF.Write(New BinaryWriter(Response.OutputStream))
                    myFileStream.Close()

            Catch exp As Exception
                Stop
                Response.Write(exp.Message)
            Finally

                Response.End()
            End Try
            'ds2 = runQueryDS("SELECT * FROM tblARQuotes WHERE QuoteID = '" & quoteID & "'", "ColonialMHConnectionString")
            'If ds2.Tables(0).Rows.Count > 0 Then

            'End If
        End If
    End Sub
   '*****************************************************
    'End PRINT
    '*****************************************************
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



End Class