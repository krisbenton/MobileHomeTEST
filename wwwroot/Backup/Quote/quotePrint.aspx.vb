Imports System.Data.SqlClient
Imports System.IO

Imports TallComponents.PDF.JavaScript
Imports TallComponents.PDF.Annotations.Widgets
Imports TallComponents.PDF.Forms.Fields

Public Class quotePrint
    Inherits System.Web.UI.Page

    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        Dim quoteID As String
        If Request.QueryString("quoteID") <> "" Then '  quoteID is not empty
            quoteID = Request.QueryString("quoteID")

            Dim ds1 As System.Data.DataSet
            Dim ds2 As System.Data.DataSet
            ds1 = Common.runQueryDS("SELECT * FROM tblQuotes q LEFT JOIN (SELECT DISTINCT AgencyID,AgencyCode,AgencyName,Address1 AS AgentAddr1, Address2 AS AgentAddr2,City AS AgentCity,State AS AgentState,Zip AS AgentZip, Phone AS AgentPhone FROM wrwpaqbx_ColonialWeb.wrwpaqbx_admin.vwAgents WHERE Phone <>'')vwag ON q.agencyName = vwag.AgencyName WHERE QuoteID = '" & quoteID & "'")
            ds2 = Common.runQueryDS("EXEC sp_getQuotePrintPrem '" & quoteID & "'")
            If ds1.Tables(0).Rows.Count > 0 Then
                printQuote(ds1, ds2)
            End If
            'ds2 = runQueryDS("SELECT * FROM tblARQuotes WHERE QuoteID = '" & quoteID & "'", "ColonialMHConnectionString")
            'If ds2.Tables(0).Rows.Count > 0 Then

            'End If
        End If
    End Sub
    Public Sub printQuote(ByVal ds As System.Data.DataSet, ByVal dsRate As System.Data.DataSet)
        Dim myFileStream As FileStream
        Dim mySourcePDF As TallComponents.PDF.Document
        Dim myOutputPDF As TallComponents.PDF.Document
        Dim myPDFFields As New TallComponents.PDF.Document
        Dim strPDFFieldName As String = ""
        Dim value As String

        Try
            myOutputPDF = New TallComponents.PDF.Document

            myFileStream = New FileStream(Me.MapPath("~\ApplicationPages\") & "PDF\Quote.pdf", FileMode.Open, FileAccess.Read)
            mySourcePDF = New TallComponents.PDF.Document(myFileStream)
            myPDFFields.Pages.AddRange(mySourcePDF.Pages.CloneToArray())
            myFileStream.Close()
            mySourcePDF = Nothing

            For Each myPDFField As TallComponents.PDF.Forms.Fields.Field In myPDFFields.Fields
                strPDFFieldName = myPDFField.FullName
                Select Case strPDFFieldName
                    'Agent Section
                    Case "AgentName"
                        value = "THE COLONIAL GROUP" 'ds.Tables(0).Rows(0).Item("agentName")
                        DirectCast(myPDFField, TallComponents.PDF.Forms.Fields.TextField).Value = value
                    Case "AgentAddr"
                        value = "" 'ds.Tables(0).Rows(0).Item("AgentAddr1")
                        DirectCast(myPDFField, TallComponents.PDF.Forms.Fields.TextField).Value = value
                    Case "AgentAddr2"
                        value = "PO BOX 4907" 'ds.Tables(0).Rows(0).Item("AgentAddr2")
                        DirectCast(myPDFField, TallComponents.PDF.Forms.Fields.TextField).Value = value
                    Case "AgentCSZ"
                        value = "GREENSBORO, NC 27404-4907" 'ds.Tables(0).Rows(0).Item("AgentCity") + " " + ds.Tables(0).Rows(0).Item("AgentState") + " " + ds.Tables(0).Rows(0).Item("AgentZip")
                        DirectCast(myPDFField, TallComponents.PDF.Forms.Fields.TextField).Value = value
                    Case "AgentPhone"
                        value = ds.Tables(0).Rows(0).Item("AgentPhone")
                        DirectCast(myPDFField, TallComponents.PDF.Forms.Fields.TextField).Value = value
                        'Client Section
                    Case "ClientName"
                        value = ds.Tables(0).Rows(0).Item("applicantFirstName") + " " + ds.Tables(0).Rows(0).Item("applicantLastName")
                        DirectCast(myPDFField, TallComponents.PDF.Forms.Fields.TextField).Value = value
                    Case "ClientAddr"
                        value = ds.Tables(0).Rows(0).Item("propAddress")
                        DirectCast(myPDFField, TallComponents.PDF.Forms.Fields.TextField).Value = value
                    Case "ClientAddr2"
                        value = ""
                        DirectCast(myPDFField, TallComponents.PDF.Forms.Fields.TextField).Value = value
                    Case "ClientCSZ"
                        value = ds.Tables(0).Rows(0).Item("city") + " " + ds.Tables(0).Rows(0).Item("state") + " " + ds.Tables(0).Rows(0).Item("zip")
                        DirectCast(myPDFField, TallComponents.PDF.Forms.Fields.TextField).Value = value
                    Case "ClientPhone"
                        value = ""
                        DirectCast(myPDFField, TallComponents.PDF.Forms.Fields.TextField).Value = value
                        'Sub Information
                    Case "SubName"
                        value = ds.Tables(0).Rows(0).Item("AgencyCode")
                        DirectCast(myPDFField, TallComponents.PDF.Forms.Fields.TextField).Value = value
                        'Unit Information
                    Case "Year"
                        value = ds.Tables(0).Rows(0).Item("year")
                        DirectCast(myPDFField, TallComponents.PDF.Forms.Fields.TextField).Value = value
                    Case "Model"
                        value = ds.Tables(0).Rows(0).Item("homeType")
                        DirectCast(myPDFField, TallComponents.PDF.Forms.Fields.TextField).Value = value
                    Case "Length"
                        value = ds.Tables(0).Rows(0).Item("length")
                        DirectCast(myPDFField, TallComponents.PDF.Forms.Fields.TextField).Value = value
                    Case "Value"
                        value = ds.Tables(0).Rows(0).Item("valuation")
                        DirectCast(myPDFField, TallComponents.PDF.Forms.Fields.TextField).Value = value
                    Case "Make"
                        value = ds.Tables(0).Rows(0).Item("manf")
                        DirectCast(myPDFField, TallComponents.PDF.Forms.Fields.TextField).Value = value
                    Case "RatingState"
                        value = ds.Tables(0).Rows(0).Item("state")
                        DirectCast(myPDFField, TallComponents.PDF.Forms.Fields.TextField).Value = value
                    Case "Width"
                        value = ds.Tables(0).Rows(0).Item("width")
                        DirectCast(myPDFField, TallComponents.PDF.Forms.Fields.TextField).Value = value
                    Case "UseOfUnit"
                        value = ds.Tables(0).Rows(0).Item("homeUse")
                        DirectCast(myPDFField, TallComponents.PDF.Forms.Fields.TextField).Value = value

                    Case "MobileHomeDesc"
                        value = "Mobile Home"
                        DirectCast(myPDFField, TallComponents.PDF.Forms.Fields.TextField).Value = value
                    Case "MHDwellLimit"
                        value = dsRate.Tables(0).Rows(0).Item("DwellingLimit")
                        DirectCast(myPDFField, TallComponents.PDF.Forms.Fields.TextField).Value = value
                    Case "MHDwellPremium"
                        value = FormatCurrency(dsRate.Tables(0).Rows(0).Item("DwellingPrem"))
                        DirectCast(myPDFField, TallComponents.PDF.Forms.Fields.TextField).Value = String.Format("{0:C0}", Math.Round(CDbl(value)))

                    Case "MobileHomePersonalProp"
                        value = "Personal Property"
                        DirectCast(myPDFField, TallComponents.PDF.Forms.Fields.TextField).Value = value
                    Case "MHPerPropLimit"
                        value = dsRate.Tables(0).Rows(0).Item("PerPropLimit")
                        DirectCast(myPDFField, TallComponents.PDF.Forms.Fields.TextField).Value = value
                    Case "MHPerPropPremium"
                        If dsRate.Tables(0).Rows(0).Item("AddStrucPrem") = "INCLUDED" Then
                            value = dsRate.Tables(0).Rows(0).Item("PerPropPrem")
                        Else
                            value = FormatCurrency(dsRate.Tables(0).Rows(0).Item("PerPropPrem"))
                            value = String.Format("{0:C0}", Math.Round(CDbl(value)))
                        End If

                        DirectCast(myPDFField, TallComponents.PDF.Forms.Fields.TextField).Value = value


                    Case "MHAddStrucDesc"
                        value = "Adjacent Structures"
                        DirectCast(myPDFField, TallComponents.PDF.Forms.Fields.TextField).Value = value
                    Case "MHAddStrucLimit"
                        value = dsRate.Tables(0).Rows(0).Item("AddStrucLimit")
                        DirectCast(myPDFField, TallComponents.PDF.Forms.Fields.TextField).Value = value
                    Case "MHAddStrucPremium"
                        If dsRate.Tables(0).Rows(0).Item("AddStrucPrem") = "INCLUDED" Then
                            value = dsRate.Tables(0).Rows(0).Item("AddStrucPrem")
                        Else
                            value = FormatCurrency(dsRate.Tables(0).Rows(0).Item("AddStrucPrem"))
                        End If
                        DirectCast(myPDFField, TallComponents.PDF.Forms.Fields.TextField).Value = String.Format("{0:C0}", Math.Round(CDbl(value)))

                    Case "MHPerLiabDesc"
                        value = "Personal Liability"
                        DirectCast(myPDFField, TallComponents.PDF.Forms.Fields.TextField).Value = value
                    Case "MHPerLiabLimit"
                        value = dsRate.Tables(0).Rows(0).Item("LiabLimit")
                        DirectCast(myPDFField, TallComponents.PDF.Forms.Fields.TextField).Value = value
                    Case "MHPerLiabPremium"
                        value = FormatCurrency(dsRate.Tables(0).Rows(0).Item("LiabPrem"))
                        DirectCast(myPDFField, TallComponents.PDF.Forms.Fields.TextField).Value = String.Format("{0:C0}", Math.Round(CDbl(value)))

                    Case "MHDedDesc"
                        value = "Deductible Change Option"
                        DirectCast(myPDFField, TallComponents.PDF.Forms.Fields.TextField).Value = value
                    Case "MHDedPremium"
                        value = FormatCurrency(dsRate.Tables(0).Rows(0).Item("DedPrem"))
                        DirectCast(myPDFField, TallComponents.PDF.Forms.Fields.TextField).Value = String.Format("{0:C0}", Math.Round(CDbl(value)))

                    Case "MHPropRepDesc"
                        value = dsRate.Tables(0).Rows(0).Item("PerPropRepPrem").ToString
                        If value = "" Then
                            value = ""
                        Else
                            value = "Personal Property Replacement Cost"
                        End If
                        DirectCast(myPDFField, TallComponents.PDF.Forms.Fields.TextField).Value = value
                    Case "MHPropRepPremium"
                        value = dsRate.Tables(0).Rows(0).Item("PerPropRepPrem").ToString
                        If value = "" Then
                            value = ""
                        Else
                            value = FormatCurrency(dsRate.Tables(0).Rows(0).Item("PerPropRepPrem"))
                            value = String.Format("{0:C0}", Math.Round(CDbl(value)))
                        End If
                        DirectCast(myPDFField, TallComponents.PDF.Forms.Fields.TextField).Value = value

                    Case "MHRepCostDesc"
                        value = dsRate.Tables(0).Rows(0).Item("MHRepPrem")
                        If value = "" Then
                            value = ""
                        Else
                            value = "Replacement Cost for Mobile Home"
                        End If
                        DirectCast(myPDFField, TallComponents.PDF.Forms.Fields.TextField).Value = value
                    Case "MHRepCostPremium"
                        value = dsRate.Tables(0).Rows(0).Item("MHRepPrem").ToString
                        If value = "" Then
                            value = ""
                        Else
                            value = FormatCurrency(dsRate.Tables(0).Rows(0).Item("MHRepPrem"))
                        End If
                        DirectCast(myPDFField, TallComponents.PDF.Forms.Fields.TextField).Value = value

                    Case "MHFireDesc"
                        value = dsRate.Tables(0).Rows(0).Item("FirePrem")
                        If value = "" Then
                            value = ""
                        Else
                            value = "Fire Department Service Charge"
                        End If
                        DirectCast(myPDFField, TallComponents.PDF.Forms.Fields.TextField).Value = value
                    Case "MHFireLimit"
                        value = dsRate.Tables(0).Rows(0).Item("FirePrem")
                        If value = "" Then
                            value = ""
                        Else
                            value = FormatCurrency(dsRate.Tables(0).Rows(0).Item("FireOpt"))
                        End If
                        DirectCast(myPDFField, TallComponents.PDF.Forms.Fields.TextField).Value = value
                    Case "MHFirePremium"
                        value = dsRate.Tables(0).Rows(0).Item("FirePrem")
                        If value = "" Then
                            value = ""
                        Else
                            value = FormatCurrency(dsRate.Tables(0).Rows(0).Item("FirePrem"))
                        End If
                        DirectCast(myPDFField, TallComponents.PDF.Forms.Fields.TextField).Value = value
                        '    'Radio
                    Case "MHRadioDesc"
                        value = dsRate.Tables(0).Rows(0).Item("RadioPrem")
                        If value = "" Then
                            value = ""
                        Else
                            value = "Radio & T.V. Charge"
                        End If
                        DirectCast(myPDFField, TallComponents.PDF.Forms.Fields.TextField).Value = value
                    Case "MHRadioLimit"
                        value = dsRate.Tables(0).Rows(0).Item("RadioPrem")
                        If value = "" Then
                            value = ""
                        Else
                            value = FormatCurrency(dsRate.Tables(0).Rows(0).Item("RadioOpt"))
                        End If

                        DirectCast(myPDFField, TallComponents.PDF.Forms.Fields.TextField).Value = value

                    Case "MHRadioPremium"
                        value = dsRate.Tables(0).Rows(0).Item("RadioPrem")
                        If value = "" Then
                            value = ""
                        Else
                            value = FormatCurrency(dsRate.Tables(0).Rows(0).Item("RadioPrem"))
                        End If
                        DirectCast(myPDFField, TallComponents.PDF.Forms.Fields.TextField).Value = value
                    Case "MHMedPayDesc"
                        value = dsRate.Tables(0).Rows(0).Item("MedPayOpt")
                        If value = "" Then
                            value = ""
                        Else
                            value = "Medical Pay"
                        End If

                        DirectCast(myPDFField, TallComponents.PDF.Forms.Fields.TextField).Value = value
                    Case "MHMedPayLimit"
                        value = dsRate.Tables(0).Rows(0).Item("MedPayOpt")
                        If value = "" Then
                            value = ""
                        Else
                            value = dsRate.Tables(0).Rows(0).Item("MedPayOpt")
                        End If
                        DirectCast(myPDFField, TallComponents.PDF.Forms.Fields.TextField).Value = value


                    Case "MHRepCostDesc"
                        value = dsRate.Tables(0).Rows(0).Item("MedMHRepPrem")
                        If value = "" Then
                            value = ""
                        Else
                            value = "Mobile Home Replacement Cost"
                        End If
                        DirectCast(myPDFField, TallComponents.PDF.Forms.Fields.TextField).Value = value
                    
                    Case "MHRepCostPrem"
                        value = dsRate.Tables(0).Rows(0).Item("MedMHRepPrem")
                        If value = "" Then
                            value = ""
                        Else
                            value = FormatCurrency(dsRate.Tables(0).Rows(0).Item("MedMHRepPrem"))
                        End If
                        DirectCast(myPDFField, TallComponents.PDF.Forms.Fields.TextField).Value = value
                        'Replacement Cost
                    Case "MHPropRepDesc"
                        value = dsRate.Tables(0).Rows(0).Item("MedRepPrem")
                        If value = "" Then
                            value = ""
                        Else
                            value = "Contents Replacement Cost"
                        End If
                        DirectCast(myPDFField, TallComponents.PDF.Forms.Fields.TextField).Value = value

                    Case "MHPropRepPrem"
                        value = dsRate.Tables(0).Rows(0).Item("MedRepPrem")
                        If value = "" Then
                            value = ""
                        Else
                            value = FormatCurrency(dsRate.Tables(0).Rows(0).Item("MedMHRepPrem"))
                        End If
                        DirectCast(myPDFField, TallComponents.PDF.Forms.Fields.TextField).Value = value




                    Case "MHFeeDesc"
                        value = "Fees"
                        DirectCast(myPDFField, TallComponents.PDF.Forms.Fields.TextField).Value = value
                    Case "MHFeeAmount"
                        value = FormatCurrency(dsRate.Tables(0).Rows(0).Item("Fees"))
                        DirectCast(myPDFField, TallComponents.PDF.Forms.Fields.TextField).Value = value

                        'Fire Department Service Charge

                End Select


            Next
            myOutputPDF.Pages.AddRange(myPDFFields.Pages.CloneToArray)

            Response.ContentType = "application/pdf"
            myOutputPDF.Write(New BinaryWriter(Response.OutputStream))
            myFileStream.Close()


        Catch exp As Exception
            Stop
            Response.Write(exp.Message)
        Finally
            mySourcePDF = Nothing
            myOutputPDF = Nothing
            Response.End()
        End Try

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