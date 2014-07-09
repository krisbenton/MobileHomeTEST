﻿Imports System.Data.SqlClient
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
            '  Packagetype = Request.QueryString("PackageType")


            Dim ds1 As System.Data.DataSet
            Dim ds2 As System.Data.DataSet
            Dim ds3 As System.Data.DataSet
            Dim ds4 As System.Data.DataSet
            ds1 = Common.runQueryDS("SELECT * FROM tblQuotes q LEFT JOIN (SELECT DISTINCT AgencyID,AgencyCode,AgencyName,ssad1 AS AgentAddr1, Address2 AS AgentAddr2,City AS AgentCity,State AS AgentState,Zip AS AgentZip, agency.sscnt3 AS AgentPhone,AgentName FROM wrwpaqbx_ColonialWeb.wrwpaqbx_admin.vwAgents as agent left join [wrwpaqbx_ColonialWeb].[wrwpaqbx_admin].[Agency] as agency on agency.sssub = agent.AgencyCode)vwag ON q.agencyName = vwag.AgencyName and q.agentname = vwag.agentname WHERE QuoteID = '" & quoteID & "'")
           


            If ds1.Tables(0).Rows.Count > 0 Then
                If ds1.Tables(0).Rows(0).Item("state").ToString() = "FL" Then
                    ds2 = Common.runQueryDS("EXEC sp_getQuotePrintPrem '" & quoteID & "'")
                    ds3 = Common.runQueryDS("Select * from tblQuoteCalcs where QuoteID = '" & quoteID & "'")
                    ds4 = Common.runQueryDS("Select * from tblARQuotes where QuoteID = '" & quoteID & "'")
                    printQuote(ds1, ds2, ds3, ds4)
                Else
                    If ds1.Tables(0).Rows(0).Item("ARRateType").ToString() = "Aegis Standard" Or ds1.Tables(0).Rows(0).Item("ARRateType").ToString() = "Aegis Rental" Or ds1.Tables(0).Rows(0).Item("ARRateType").ToString() = "Aegis Vintage" Then
                        ' ds4 = Common.runQueryDS("Select * from tblAegisQuotes where QuoteID = '" & quoteID & "'")
                        ds4 = Common.runQueryDS("Select a.*,c.* from tblAegisQuotes as a inner join dbo.tblQuotes b on b.quoteID = a.QuoteID left join dbo.tblAegisTerritory as c on c.County = b.county where a.QuoteID = '" & quoteID & "'")
                        printAegisQuote(ds1, ds4)

                    ElseIf ds1.Tables(0).Rows(0).Item("ARRateType").ToString() = "AMSLIC Standard" Or ds1.Tables(0).Rows(0).Item("ARRateType").ToString() = "AMSLIC Rental" Then
                        ds4 = Common.runQueryDS("Select * from tblAmslicQuotes where QuoteID = '" & quoteID & "'")
                        printAmslicQuote(ds1, ds4)
                    ElseIf Left(ds1.Tables(0).Rows(0).Item("ARRateType").ToString(), 3) = "WMJ" Then
                        ds4 = Common.runQueryDS("Select * from tblWMJQuotes where QuoteID = '" & quoteID & "'")
                        printWMJQuote(ds1, ds4)
                    Else

                        ds4 = Common.runQueryDS("Select * from tblLloydsQuotes where QuoteID = '" & quoteID & "'")
                        printlloyQuote(ds1, ds4)
                    End If
                    'ds2 = Common.runQueryDS("EXEC sp_getQuotePrintPrem '" & quoteID & "'")
                    ' ds3 = Common.runQueryDS("Select * from tblQuoteCalcs where QuoteID = '" & quoteID & "'")
                    'ds4 = Common.runQueryDS("Select * from tblLloydsQuotes where QuoteID = '" & quoteID & "'")


                    'printlloyQuote(ds1, ds4)

                End If

            End If
            
            'ds2 = runQueryDS("SELECT * FROM tblARQuotes WHERE QuoteID = '" & quoteID & "'", "ColonialMHConnectionString")
            'If ds2.Tables(0).Rows.Count > 0 Then

            'End If
        End If
    End Sub
    Public Sub printQuote(ByVal ds As System.Data.DataSet, ByVal dsRate As System.Data.DataSet, ByVal ds3 As System.Data.DataSet, ByVal ds4 As System.Data.DataSet)
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

            Dim pdffield As TallComponents.PDF.Forms.Fields.Field
            pdffield = myPDFFields.Fields("QuoteNum")
            DirectCast(pdffield, TallComponents.PDF.Forms.Fields.TextField).Value = ds.Tables(0).Rows(0).Item("quoteID").ToString()

            pdffield = myPDFFields.Fields("QuoteTerm")
            DirectCast(pdffield, TallComponents.PDF.Forms.Fields.TextField).Value = ds.Tables(0).Rows(0).Item("term").ToString()


            pdffield = myPDFFields.Fields("QuoteNumdate")
            DirectCast(pdffield, TallComponents.PDF.Forms.Fields.TextField).Value = Date.Now.ToString("MM/dd/yyyy") 'ds.Tables(0).Rows(0).Item("quoteID").ToString()

            pdffield = myPDFFields.Fields("QuoteEffDate")
            DirectCast(pdffield, TallComponents.PDF.Forms.Fields.TextField).Value = ds.Tables(0).Rows(0).Item("effDate").ToString()

            pdffield = myPDFFields.Fields("QuoteCompany")
            DirectCast(pdffield, TallComponents.PDF.Forms.Fields.TextField).Value = "American Reliable " & ds.Tables(0).Rows(0).Item("ARRateType").ToString()



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
                        value = ds.Tables(0).Rows(0).Item("AgentPhone").ToString()
                        DirectCast(myPDFField, TallComponents.PDF.Forms.Fields.TextField).Value = "(800) 628- 3762" 'value
                        'Client Section
                    Case "ClientName"
                        value = UCase(ds.Tables(0).Rows(0).Item("applicantFirstName").ToString()) + " " + UCase(ds.Tables(0).Rows(0).Item("applicantLastName").ToString())
                        DirectCast(myPDFField, TallComponents.PDF.Forms.Fields.TextField).Value = value
                    Case "ClientAddr1"
                        value = UCase(ds.Tables(0).Rows(0).Item("propAddress").ToString())
                        DirectCast(myPDFField, TallComponents.PDF.Forms.Fields.TextField).Value = value
                    Case "ClientAddr2"
                        value = ""
                        DirectCast(myPDFField, TallComponents.PDF.Forms.Fields.TextField).Value = value
                    Case "ClientCSZ"
                        value = ds.Tables(0).Rows(0).Item("city").ToString() + " " + ds.Tables(0).Rows(0).Item("state").ToString() + " " + ds.Tables(0).Rows(0).Item("zip").ToString()
                        DirectCast(myPDFField, TallComponents.PDF.Forms.Fields.TextField).Value = UCase(value)
                    Case "ClientPhone"
                        value = ""
                        DirectCast(myPDFField, TallComponents.PDF.Forms.Fields.TextField).Value = value
                        'Sub Information
                    Case "SubName"
                        value = ds.Tables(0).Rows(0).Item("AgencyName").ToString()
                        DirectCast(myPDFField, TallComponents.PDF.Forms.Fields.TextField).Value = UCase(value)

                    Case "SubAddr1"
                        value = ds.Tables(0).Rows(0).Item("AgentAddr1").ToString()
                        DirectCast(myPDFField, TallComponents.PDF.Forms.Fields.TextField).Value = UCase(value)
                    Case "SubAddr2"
                        value = UCase(ds.Tables(0).Rows(0).Item("AgentAddr2").ToString())
                        DirectCast(myPDFField, TallComponents.PDF.Forms.Fields.TextField).Value = value
                    Case "SubCSZ"
                        value = ds.Tables(0).Rows(0).Item("AgentCity").ToString() & ", " & ds.Tables(0).Rows(0).Item("AgentState").ToString() & " " & ds.Tables(0).Rows(0).Item("AgentZip").ToString()
                        DirectCast(myPDFField, TallComponents.PDF.Forms.Fields.TextField).Value = UCase(value)
                    Case "SubPhone"
                        value = ds.Tables(0).Rows(0).Item("AgentPhone").ToString()
                        DirectCast(myPDFField, TallComponents.PDF.Forms.Fields.TextField).Value = UCase(value)


                        'Unit Information
                    Case "Year"
                        value = ds.Tables(0).Rows(0).Item("year").ToString()
                        DirectCast(myPDFField, TallComponents.PDF.Forms.Fields.TextField).Value = value
                    Case "Model"
                        value = ds.Tables(0).Rows(0).Item("homeType").ToString()
                        DirectCast(myPDFField, TallComponents.PDF.Forms.Fields.TextField).Value = UCase(value)
                    Case "Length"
                        value = ds.Tables(0).Rows(0).Item("length").ToString()
                        DirectCast(myPDFField, TallComponents.PDF.Forms.Fields.TextField).Value = value
                    Case "Value"
                        value = dsRate.Tables(0).Rows(0).Item("Dwellinglimit").ToString()
                        DirectCast(myPDFField, TallComponents.PDF.Forms.Fields.TextField).Value = value
                    Case "Make"
                        value = ds.Tables(0).Rows(0).Item("manf").ToString()
                        DirectCast(myPDFField, TallComponents.PDF.Forms.Fields.TextField).Value = UCase(value)
                    Case "RatingState"
                        value = ds.Tables(0).Rows(0).Item("state").ToString()
                        DirectCast(myPDFField, TallComponents.PDF.Forms.Fields.TextField).Value = UCase(value)
                    Case "Width"
                        value = ds.Tables(0).Rows(0).Item("width").ToString()
                        DirectCast(myPDFField, TallComponents.PDF.Forms.Fields.TextField).Value = value
                    Case "UseOfUnit"
                        value = ds.Tables(0).Rows(0).Item("homeUse").ToString()
                        DirectCast(myPDFField, TallComponents.PDF.Forms.Fields.TextField).Value = UCase(value)

                    Case "MobileHomeDesc"
                        value = "Mobile Home"
                        DirectCast(myPDFField, TallComponents.PDF.Forms.Fields.TextField).Value = value
                    Case "MHDwellLimit"
                        value = dsRate.Tables(0).Rows(0).Item("DwellingLimit").ToString()
                        DirectCast(myPDFField, TallComponents.PDF.Forms.Fields.TextField).Value = CInt(value)
                    Case "MHDwellPremium"
                        value = FormatCurrency(dsRate.Tables(0).Rows(0).Item("DwellingPrem").ToString())
                        DirectCast(myPDFField, TallComponents.PDF.Forms.Fields.TextField).Value = String.Format("{0:C0}", Math.Round(CDbl(value.Replace("$", ""))))

                    Case "MobileHomePersonalProp"
                        'value = "Personal Property"
                        value = "Contents"
                        DirectCast(myPDFField, TallComponents.PDF.Forms.Fields.TextField).Value = value
                    Case "MHPerPropLimit"
                        value = dsRate.Tables(0).Rows(0).Item("PerPropLimit").ToString()
                        DirectCast(myPDFField, TallComponents.PDF.Forms.Fields.TextField).Value = CInt(value)
                    Case "MHPerPropPremium"
                        If dsRate.Tables(0).Rows(0).Item("PerPropPrem") = "INCLUDED" Then
                            value = dsRate.Tables(0).Rows(0).Item("PerPropPrem").ToString()
                        Else
                            value = FormatCurrency(dsRate.Tables(0).Rows(0).Item("PerPropPrem").ToString())
                            value = String.Format("{0:C0}", Math.Round(CDbl(value.Replace("$", ""))))
                        End If

                        DirectCast(myPDFField, TallComponents.PDF.Forms.Fields.TextField).Value = value


                    Case "MHAddStrucDesc"
                        ' value = "Adjacent Structures"
                        value = "Other Structures"
                        DirectCast(myPDFField, TallComponents.PDF.Forms.Fields.TextField).Value = value
                    Case "MHAddStrucLimit"
                        value = dsRate.Tables(0).Rows(0).Item("AddStrucLimit").ToString()
                        DirectCast(myPDFField, TallComponents.PDF.Forms.Fields.TextField).Value = CInt(value)
                    Case "MHAddStrucPremium"
                        If dsRate.Tables(0).Rows(0).Item("AddStrucPrem").ToString() = "INCLUDED" Then
                            value = dsRate.Tables(0).Rows(0).Item("AddStrucPrem").ToString()
                        Else
                            value = FormatCurrency(dsRate.Tables(0).Rows(0).Item("AddStrucPrem").ToString())
                            value = String.Format("{0:C0}", Math.Round(CDbl(value.Replace("$", ""))))
                        End If
                        DirectCast(myPDFField, TallComponents.PDF.Forms.Fields.TextField).Value = value

                    Case "MHPerLiabDesc"
                        value = "Personal Liability"
                        DirectCast(myPDFField, TallComponents.PDF.Forms.Fields.TextField).Value = value.Replace("$", "")
                    Case "MHPerLiabLimit"
                        value = dsRate.Tables(0).Rows(0).Item("LiabLimit").ToString().Replace("$", "").Replace(",", "")
                        DirectCast(myPDFField, TallComponents.PDF.Forms.Fields.TextField).Value = value.Replace("$", "")
                    Case "MHPerLiabPremium"
                        value = FormatCurrency(dsRate.Tables(0).Rows(0).Item("LiabPrem").ToString())
                        DirectCast(myPDFField, TallComponents.PDF.Forms.Fields.TextField).Value = String.Format("{0:C0}", Math.Round(CDbl(value.Replace("$", ""))))

                        'Case "MHDedDesc"
                        '    value = "Deductible Change Option"
                        '    DirectCast(myPDFField, TallComponents.PDF.Forms.Fields.TextField).Value = value
                        'Case "MHDedPremium"
                        '    value = FormatCurrency(dsRate.Tables(0).Rows(0).Item("DedPrem").ToString())
                        '    DirectCast(myPDFField, TallComponents.PDF.Forms.Fields.TextField).Value = String.Format("{0:C0}", Math.Round(CDbl(value)))

                    Case "MHPropRepDesc"
                        value = dsRate.Tables(0).Rows(0).Item("PerPropRepPrem").ToString()
                        If value = "" Then
                            value = ""
                        Else
                            value = "Contents Replacement Cost"
                        End If
                        DirectCast(myPDFField, TallComponents.PDF.Forms.Fields.TextField).Value = value.Replace("$", "")
                    Case "MHPropRepPremium"
                        value = dsRate.Tables(0).Rows(0).Item("PerPropRepPrem").ToString()
                        If value = "" Then
                            value = ""
                        Else
                            value = FormatCurrency(dsRate.Tables(0).Rows(0).Item("PerPropRepPrem").ToString())
                            value = String.Format("{0:C0}", Math.Round(CDbl(value.Replace("$", ""))))
                        End If
                        DirectCast(myPDFField, TallComponents.PDF.Forms.Fields.TextField).Value = value.Replace("$", "")

                    Case "MHRepCostDesc"
                        value = dsRate.Tables(0).Rows(0).Item("MHRepPrem").ToString()
                        If value = "" Then
                            value = ""
                        Else
                            value = "Replacement Cost for Mobile Home"
                        End If
                        DirectCast(myPDFField, TallComponents.PDF.Forms.Fields.TextField).Value = value
                    Case "MHRepCostPremium"
                        value = dsRate.Tables(0).Rows(0).Item("MHRepPrem").ToString()
                        If value = "" Then
                            value = ""
                        Else
                            value = FormatCurrency(dsRate.Tables(0).Rows(0).Item("MHRepPrem").ToString())
                        End If
                        DirectCast(myPDFField, TallComponents.PDF.Forms.Fields.TextField).Value = value.Replace("$", "")

                    Case "MHFireDesc"
                        value = dsRate.Tables(0).Rows(0).Item("FirePrem").ToString()
                        If value = "" Then
                            value = ""
                        Else
                            value = "Fire Department Service Charge"
                        End If
                        DirectCast(myPDFField, TallComponents.PDF.Forms.Fields.TextField).Value = value.Replace("$", "")
                    Case "MHFireLimit"
                        value = dsRate.Tables(0).Rows(0).Item("FirePrem").ToString()
                        If value = "" Then
                            value = ""
                        Else
                            value = FormatCurrency(dsRate.Tables(0).Rows(0).Item("FireOpt").ToString())
                        End If
                        DirectCast(myPDFField, TallComponents.PDF.Forms.Fields.TextField).Value = value.Replace("$", "")
                    Case "MHFirePremium"
                        value = dsRate.Tables(0).Rows(0).Item("FirePrem").ToString()
                        If value = "" Then
                            value = ""
                        Else
                            value = FormatCurrency(dsRate.Tables(0).Rows(0).Item("FirePrem").ToString())
                        End If
                        DirectCast(myPDFField, TallComponents.PDF.Forms.Fields.TextField).Value = value.Replace("$", "")
                        '    'Radio
                    Case "MHRadioDesc"
                        value = dsRate.Tables(0).Rows(0).Item("RadioPrem").ToString()
                        If value = "" Then
                            value = ""
                        Else
                            value = "Radio & T.V. Charge"
                        End If
                        DirectCast(myPDFField, TallComponents.PDF.Forms.Fields.TextField).Value = value.Replace("$", "")
                    Case "MHRadioLimit"
                        value = dsRate.Tables(0).Rows(0).Item("RadioPrem").ToString()
                        If value = "" Then
                            value = ""
                        Else
                            value = FormatCurrency(dsRate.Tables(0).Rows(0).Item("RadioOpt").ToString())
                        End If

                        DirectCast(myPDFField, TallComponents.PDF.Forms.Fields.TextField).Value = value.Replace("$", "")

                    Case "MHRadioPremium"
                        value = dsRate.Tables(0).Rows(0).Item("RadioPrem").ToString()
                        If value = "" Then
                            value = ""
                        Else
                            value = FormatCurrency(dsRate.Tables(0).Rows(0).Item("RadioPrem").ToString())
                        End If
                        DirectCast(myPDFField, TallComponents.PDF.Forms.Fields.TextField).Value = value.Replace("$", "")
                    Case "MHMedPayDesc"
                        value = dsRate.Tables(0).Rows(0).Item("MedPayOpt").ToString()
                        If value = "" Then
                            value = ""
                        Else
                            value = "Medical Payments"
                        End If

                        DirectCast(myPDFField, TallComponents.PDF.Forms.Fields.TextField).Value = value.Replace("$", "")
                    Case "MHMedPayLimit"
                        value = dsRate.Tables(0).Rows(0).Item("MedPayOpt").ToString()
                        If value = "" Then
                            value = ""
                        Else
                            value = dsRate.Tables(0).Rows(0).Item("MedPayOpt").ToString()
                        End If
                        DirectCast(myPDFField, TallComponents.PDF.Forms.Fields.TextField).Value = "$" & value.Replace("$", "")

                        If dsRate.Tables(0).Rows(0).Item("MedPayOpt").ToString() = "$1000" Then
                            pdffield = myPDFFields.Fields("MHMedPayPremium")
                            DirectCast(pdffield, TallComponents.PDF.Forms.Fields.TextField).Value = "$5".Replace("$", "")


                        End If

                    Case "MHRepCostDesc"
                        value = dsRate.Tables(0).Rows(0).Item("MedMHRepPrem").ToString()
                        If value = "" Then
                            value = ""
                        Else
                            value = "Mobile Home Replacement Cost"
                        End If
                        DirectCast(myPDFField, TallComponents.PDF.Forms.Fields.TextField).Value = value.Replace("$", "")

                    Case "MHRepCostPrem"
                        value = dsRate.Tables(0).Rows(0).Item("MedMHRepPrem").ToString()
                        If value = "" Then
                            value = ""
                        Else
                            value = FormatCurrency(dsRate.Tables(0).Rows(0).Item("MedMHRepPrem").ToString())
                        End If
                        DirectCast(myPDFField, TallComponents.PDF.Forms.Fields.TextField).Value = value.Replace("$", "")
                        'Replacement Cost
                    Case "MHPropRepDesc"
                        value = dsRate.Tables(0).Rows(0).Item("MedRepPrem").ToString()
                        If value = "" Then
                            value = ""
                        Else
                            value = "Contents Replacement Cost"
                        End If
                        DirectCast(myPDFField, TallComponents.PDF.Forms.Fields.TextField).Value = value.Replace("$", "")

                    Case "MHPropRepPrem"
                        value = dsRate.Tables(0).Rows(0).Item("MedRepPrem").ToString()
                        If value = "" Then
                            value = ""
                        Else
                            value = FormatCurrency(dsRate.Tables(0).Rows(0).Item("MedMHRepPrem").ToString())
                        End If
                        DirectCast(myPDFField, TallComponents.PDF.Forms.Fields.TextField).Value = value.Replace("$", "")




                    Case "MHFeeDesc"
                        value = "Fees"
                        DirectCast(myPDFField, TallComponents.PDF.Forms.Fields.TextField).Value = value
                    Case "MHFeeAmount"
                        value = FormatCurrency(dsRate.Tables(0).Rows(0).Item("Fees").ToString())
                        DirectCast(myPDFField, TallComponents.PDF.Forms.Fields.TextField).Value = value

                        'Fire Department Service Charge

                End Select


            Next
            Dim PackTotal As Integer

            Select Case ds.Tables(0).Rows(0).Item("ARRateType").ToString()
                Case "Package"

                    pdffield = myPDFFields.Fields("MHDwellPremium")
                    DirectCast(pdffield, TallComponents.PDF.Forms.Fields.TextField).Value = CInt(ds3.Tables(0).Rows(0).Item("Packsub1").ToString()) '- CInt(ds3.Tables(0).Rows(0).Item("PackHur").ToString()) - CInt(ds3.Tables(0).Rows(0).Item("PackNonHur").ToString())
                    PackTotal += CInt(ds3.Tables(0).Rows(0).Item("Packsub1").ToString()) - CInt(ds3.Tables(0).Rows(0).Item("PackHur").ToString()) - CInt(ds3.Tables(0).Rows(0).Item("PackNonHur").ToString())

                    pdffield = myPDFFields.Fields("MHDedDesc")
                    DirectCast(pdffield, TallComponents.PDF.Forms.Fields.TextField).Value = "Deductible Change Option AOP"

                    pdffield = myPDFFields.Fields("MHDedLimit")
                    DirectCast(pdffield, TallComponents.PDF.Forms.Fields.TextField).Value = "$" & ds4.Tables(0).Rows(0).Item("ARPackageAOPOpt").ToString().Replace("$", "")
                    pdffield = myPDFFields.Fields("MHDedPremium")
                    DirectCast(pdffield, TallComponents.PDF.Forms.Fields.TextField).Value = "($" & CInt(ds3.Tables(0).Rows(0).Item("PackNonHur").ToString()) & ")"
                    ' PackTotal -= CInt(ds3.Tables(0).Rows(0).Item("PackNonHur").ToString())
                    pdffield = myPDFFields.Fields("MHPropRepDesc")
                    DirectCast(pdffield, TallComponents.PDF.Forms.Fields.TextField).Value = "Deductible Change Option Hurricane"

                    pdffield = myPDFFields.Fields("MHPropRepPremiumLimit")
                    DirectCast(pdffield, TallComponents.PDF.Forms.Fields.TextField).Value = ds4.Tables(0).Rows(0).Item("ARPackageHurDedOpt").ToString().Replace("$", "")
                    pdffield = myPDFFields.Fields("MHPropRepPremium")
                    DirectCast(pdffield, TallComponents.PDF.Forms.Fields.TextField).Value = "($" & CInt(ds3.Tables(0).Rows(0).Item("PackHur").ToString().Replace("$", "")) & ")"

                    pdffield = myPDFFields.Fields("Total Quoted Premium")
                    DirectCast(pdffield, TallComponents.PDF.Forms.Fields.TextField).Value = "$" & ds4.Tables(0).Rows(0).Item("ARPackageTotal").ToString().Replace("$", "")

                    If ds4.Tables(0).Rows(0).Item("ARPackagePerPropRepPrem").ToString() <> "$0.00" Then

                        pdffield = myPDFFields.Fields("MHContentsdesc")
                        DirectCast(pdffield, TallComponents.PDF.Forms.Fields.TextField).Value = "Contents Replacement Cost"

                        pdffield = myPDFFields.Fields("MHContentsPremium")
                        DirectCast(pdffield, TallComponents.PDF.Forms.Fields.TextField).Value = ds4.Tables(0).Rows(0).Item("ARPackagePerPropRepPrem").ToString().Replace("$", "")

                    End If

                    If ds4.Tables(0).Rows(0).Item("ARPackageAddResPrem").ToString() <> "$0.00" Then
                        pdffield = myPDFFields.Fields("MHAddResDesc")
                        DirectCast(pdffield, TallComponents.PDF.Forms.Fields.TextField).Value = "Additional Resident Cost"

                        pdffield = myPDFFields.Fields("MHAddResPremium")
                        DirectCast(pdffield, TallComponents.PDF.Forms.Fields.TextField).Value = ds4.Tables(0).Rows(0).Item("ARPackageAddResPrem").ToString().Replace("$", "")

                    End If
                    If ds4.Tables(0).Rows(0).Item("ARPackageWaterPrem").ToString() <> "$0.00" Then
                        pdffield = myPDFFields.Fields("MHWaterCraftDesc")
                        DirectCast(pdffield, TallComponents.PDF.Forms.Fields.TextField).Value = "WaterCraft Cost"

                        pdffield = myPDFFields.Fields("MHWaterCraftPremium")
                        DirectCast(pdffield, TallComponents.PDF.Forms.Fields.TextField).Value = ds4.Tables(0).Rows(0).Item("ARPackageWaterPrem").ToString().Replace("$", "")

                    End If
                    If ds4.Tables(0).Rows(0).Item("ARPackageVPerPropPrem").ToString().Replace("$", "") <> "0.00" Then
                        pdffield = myPDFFields.Fields("MHValPropDesc")
                        DirectCast(pdffield, TallComponents.PDF.Forms.Fields.TextField).Value = "Valuable Personal Property"

                        pdffield = myPDFFields.Fields("MHValPropPremium")
                        DirectCast(pdffield, TallComponents.PDF.Forms.Fields.TextField).Value = ds4.Tables(0).Rows(0).Item("ARPackageVPerPropPrem").ToString().Replace("$", "")

                    End If

                    If ds4.Tables(0).Rows(0).Item("ARPackageSecIntPrem").ToString() <> "$0.00" Then
                        pdffield = myPDFFields.Fields("MHSIPDesc")
                        DirectCast(pdffield, TallComponents.PDF.Forms.Fields.TextField).Value = "Secured Interest Protection"

                        pdffield = myPDFFields.Fields("MHSIPPremium")
                        DirectCast(pdffield, TallComponents.PDF.Forms.Fields.TextField).Value = ds4.Tables(0).Rows(0).Item("ARPackageSecIntPrem").ToString().Replace("$", "")

                    End If

                    If ds4.Tables(0).Rows(0).Item("ARPackageNatDisPrem").ToString() <> "$0.00" Then
                        pdffield = myPDFFields.Fields("MHNDDesc")
                        DirectCast(pdffield, TallComponents.PDF.Forms.Fields.TextField).Value = "Natural Disaster Protection"

                        pdffield = myPDFFields.Fields("MHNDPremium")
                        DirectCast(pdffield, TallComponents.PDF.Forms.Fields.TextField).Value = ds4.Tables(0).Rows(0).Item("ARPackageNatDisPrem").ToString().Replace("$", "")

                    End If



                    ' PackTotal -= CInt(ds3.Tables(0).Rows(0).Item("PackHur").ToString())
                Case "Standard"
                    pdffield = myPDFFields.Fields("MHDwellPremium")
                    DirectCast(pdffield, TallComponents.PDF.Forms.Fields.TextField).Value = CInt(ds3.Tables(0).Rows(0).Item("Standsub1").ToString().Replace("$", "")) ' - CInt(ds3.Tables(0).Rows(0).Item("StandHur").ToString()) - CInt(ds3.Tables(0).Rows(0).Item("StandNonHur").ToString())

                    pdffield = myPDFFields.Fields("MHDedDesc")
                    DirectCast(pdffield, TallComponents.PDF.Forms.Fields.TextField).Value = "Deductible Change Option AOP"

                    pdffield = myPDFFields.Fields("MHDedLimit")
                    DirectCast(pdffield, TallComponents.PDF.Forms.Fields.TextField).Value = "$" & ds4.Tables(0).Rows(0).Item("ARStandardAOPOpt").ToString().Replace("$", "")
                    pdffield = myPDFFields.Fields("MHDedPremium")
                    DirectCast(pdffield, TallComponents.PDF.Forms.Fields.TextField).Value = "($" & CInt(ds3.Tables(0).Rows(0).Item("StandNonHur").ToString().Replace("$", "")) & ")"

                    pdffield = myPDFFields.Fields("MHPropRepDesc")
                    DirectCast(pdffield, TallComponents.PDF.Forms.Fields.TextField).Value = "Deductible Change Option Hurricane"

                    pdffield = myPDFFields.Fields("MHPropRepPremiumLimit")
                    DirectCast(pdffield, TallComponents.PDF.Forms.Fields.TextField).Value = ds4.Tables(0).Rows(0).Item("ARStandardHurDedOpt").ToString()
                    pdffield = myPDFFields.Fields("MHPropRepPremium")
                    DirectCast(pdffield, TallComponents.PDF.Forms.Fields.TextField).Value = "($" & CInt(ds3.Tables(0).Rows(0).Item("StandHur").ToString().Replace("$", "")) & ")"

                    PackTotal += CInt(ds3.Tables(0).Rows(0).Item("Standsub1").ToString()) - CInt(ds3.Tables(0).Rows(0).Item("StandHur").ToString()) - CInt(ds3.Tables(0).Rows(0).Item("StandNonHur").ToString())
                    ' PackTotal -= CInt(ds3.Tables(0).Rows(0).Item("StandNonHur").ToString())
                    ' PackTotal -= CInt(ds3.Tables(0).Rows(0).Item("StandHur").ToString())


                    pdffield = myPDFFields.Fields("Total Quoted Premium")
                    DirectCast(pdffield, TallComponents.PDF.Forms.Fields.TextField).Value = "$" & ds4.Tables(0).Rows(0).Item("ARStandardTotal").ToString().Replace("$", "")

                    If ds4.Tables(0).Rows(0).Item("ARStandardPerPropRepPrem").ToString() <> "$0.00" Then

                        pdffield = myPDFFields.Fields("MHContentsdesc")
                        DirectCast(pdffield, TallComponents.PDF.Forms.Fields.TextField).Value = "Contents Replacement Cost"

                        pdffield = myPDFFields.Fields("MHContentsPremium")
                        DirectCast(pdffield, TallComponents.PDF.Forms.Fields.TextField).Value = ds4.Tables(0).Rows(0).Item("ARStandardPerPropRepPrem").ToString().Replace("$", "")

                    End If

                    If ds4.Tables(0).Rows(0).Item("ARStandardAddResPrem").ToString() <> "$0.00" Then
                        pdffield = myPDFFields.Fields("MHAddResDesc")
                        DirectCast(pdffield, TallComponents.PDF.Forms.Fields.TextField).Value = "Additional Resident Cost"

                        pdffield = myPDFFields.Fields("MHAddResPremium")
                        DirectCast(pdffield, TallComponents.PDF.Forms.Fields.TextField).Value = ds4.Tables(0).Rows(0).Item("ARStandardAddResPrem").ToString().Replace("$", "")

                    End If
                    If ds4.Tables(0).Rows(0).Item("ARStandardWaterPrem").ToString() <> "$0.00" Then
                        pdffield = myPDFFields.Fields("MHWaterCraftDesc")
                        DirectCast(pdffield, TallComponents.PDF.Forms.Fields.TextField).Value = "WaterCraft Cost"

                        pdffield = myPDFFields.Fields("MHWaterCraftPremium")
                        DirectCast(pdffield, TallComponents.PDF.Forms.Fields.TextField).Value = ds4.Tables(0).Rows(0).Item("ARStandardWaterPrem").ToString().Replace("$", "")

                    End If
                    If ds4.Tables(0).Rows(0).Item("ARStandardVPerPropPrem").ToString().Replace("$", "") <> "0.00" Then
                        pdffield = myPDFFields.Fields("MHValPropDesc")
                        DirectCast(pdffield, TallComponents.PDF.Forms.Fields.TextField).Value = "Valuable Personal Property"

                        pdffield = myPDFFields.Fields("MHValPropPremium")
                        DirectCast(pdffield, TallComponents.PDF.Forms.Fields.TextField).Value = ds4.Tables(0).Rows(0).Item("ARStandardVPerPropPrem").ToString().Replace("$", "")

                    End If

                    If ds4.Tables(0).Rows(0).Item("ARStandardSecIntPrem").ToString() <> "$0.00" Then
                        pdffield = myPDFFields.Fields("MHSIPDesc")
                        DirectCast(pdffield, TallComponents.PDF.Forms.Fields.TextField).Value = "Secured Interest Protection"

                        pdffield = myPDFFields.Fields("MHSIPPremium")
                        DirectCast(pdffield, TallComponents.PDF.Forms.Fields.TextField).Value = ds4.Tables(0).Rows(0).Item("ARStandardSecIntPrem").ToString().Replace("$", "")

                    End If

                    If ds4.Tables(0).Rows(0).Item("ARStandardNatDisPrem").ToString() <> "$0.00" Then
                        pdffield = myPDFFields.Fields("MHNDDesc")
                        DirectCast(pdffield, TallComponents.PDF.Forms.Fields.TextField).Value = "Natural Disaster Protection"

                        pdffield = myPDFFields.Fields("MHNDPremium")
                        DirectCast(pdffield, TallComponents.PDF.Forms.Fields.TextField).Value = ds4.Tables(0).Rows(0).Item("ARStandardNatDisPrem").ToString().Replace("$", "")

                    End If




                Case "Rental"
                    pdffield = myPDFFields.Fields("MHDwellPremium")
                    DirectCast(pdffield, TallComponents.PDF.Forms.Fields.TextField).Value = "$" & CInt(ds3.Tables(0).Rows(0).Item("Rentsub1").ToString()) ' - CInt(ds3.Tables(0).Rows(0).Item("RentHur").ToString()) - CInt(ds3.Tables(0).Rows(0).Item("RentNonHur").ToString())

                    pdffield = myPDFFields.Fields("MHDedDesc")
                    DirectCast(pdffield, TallComponents.PDF.Forms.Fields.TextField).Value = "Deductible Change Option AOP"

                    pdffield = myPDFFields.Fields("MHDedLimit")
                    DirectCast(pdffield, TallComponents.PDF.Forms.Fields.TextField).Value = "$" & ds4.Tables(0).Rows(0).Item("ARRentalAOPOpt").ToString().Replace("$", "")
                    pdffield = myPDFFields.Fields("MHDedPremium")
                    DirectCast(pdffield, TallComponents.PDF.Forms.Fields.TextField).Value = "($" & CInt(ds3.Tables(0).Rows(0).Item("RentNonHur").ToString().Replace("$", "")) & ")"

                    pdffield = myPDFFields.Fields("MHPropRepDesc")
                    DirectCast(pdffield, TallComponents.PDF.Forms.Fields.TextField).Value = "Deductible Change Option Hurricane"

                    pdffield = myPDFFields.Fields("MHPropRepPremiumLimit")
                    DirectCast(pdffield, TallComponents.PDF.Forms.Fields.TextField).Value = ds4.Tables(0).Rows(0).Item("ARRentalHurDedOpt").ToString()
                    pdffield = myPDFFields.Fields("MHPropRepPremium")
                    DirectCast(pdffield, TallComponents.PDF.Forms.Fields.TextField).Value = "($" & CInt(ds3.Tables(0).Rows(0).Item("RentHur").ToString().Replace("$", "")) & ")"
                    PackTotal += CInt(ds3.Tables(0).Rows(0).Item("Rentsub1").ToString()) - CInt(ds3.Tables(0).Rows(0).Item("RentHur").ToString()) - CInt(ds3.Tables(0).Rows(0).Item("RentNonHur").ToString())
                    ' PackTotal -= CInt(ds3.Tables(0).Rows(0).Item("RentNonHur").ToString())
                    ' PackTotal -= CInt(ds3.Tables(0).Rows(0).Item("RentHur").ToString())
                    pdffield = myPDFFields.Fields("Total Quoted Premium")
                    DirectCast(pdffield, TallComponents.PDF.Forms.Fields.TextField).Value = "$" & ds4.Tables(0).Rows(0).Item("ARRentalTotal").ToString().Replace("$", "")

                    If ds4.Tables(0).Rows(0).Item("ARRentalPerPropRepPrem").ToString() <> "$0.00" Then

                        pdffield = myPDFFields.Fields("MHContentsdesc")
                        DirectCast(pdffield, TallComponents.PDF.Forms.Fields.TextField).Value = "Contents Replacement Cost"

                        pdffield = myPDFFields.Fields("MHContentsPremium")
                        DirectCast(pdffield, TallComponents.PDF.Forms.Fields.TextField).Value = ds4.Tables(0).Rows(0).Item("ARRentalPerPropRepPrem").ToString().Replace("$", "")

                    End If
            End Select
            pdffield = myPDFFields.Fields("MHFeeDesc")
            DirectCast(pdffield, TallComponents.PDF.Forms.Fields.TextField).Value = "Package MGA Fee"
            pdffield = myPDFFields.Fields("MHFeeAmount")
            DirectCast(pdffield, TallComponents.PDF.Forms.Fields.TextField).Value = "$25"

            pdffield = myPDFFields.Fields("MHFeeDesc1")
            DirectCast(pdffield, TallComponents.PDF.Forms.Fields.TextField).Value = "Emergency Management Fee"
            pdffield = myPDFFields.Fields("MHFeeAmount1")
            DirectCast(pdffield, TallComponents.PDF.Forms.Fields.TextField).Value = "$2"

            pdffield = myPDFFields.Fields("MHFeeDesc2")
            DirectCast(pdffield, TallComponents.PDF.Forms.Fields.TextField).Value = "Citizens Emergency Assesment Fee"
            pdffield = myPDFFields.Fields("MHFeeAmount2")
            DirectCast(pdffield, TallComponents.PDF.Forms.Fields.TextField).Value = "$" & CInt(PackTotal * 0.01)
            pdffield = myPDFFields.Fields("MHFeeDesc3")
            DirectCast(pdffield, TallComponents.PDF.Forms.Fields.TextField).Value = "Florida Hurr CAT Fund Fee"
            pdffield = myPDFFields.Fields("MHFeeAmount3")
            DirectCast(pdffield, TallComponents.PDF.Forms.Fields.TextField).Value = "$" & CInt(PackTotal * 0.013)

            'Dim Quotetotal As Integer
            'Quotetotal += PackTotal
            'If IsNumeric(dsRate.Tables(0).Rows(0).Item("PerPropPrem").ToString()) Then
            '    Quotetotal += CInt(dsRate.Tables(0).Rows(0).Item("PerPropPrem").ToString())
            'End If
            'If IsNumeric(dsRate.Tables(0).Rows(0).Item("AddStrucPrem").ToString()) Then
            '    Quotetotal += CInt(dsRate.Tables(0).Rows(0).Item("AddStrucPrem").ToString())
            'End If
            'If IsNumeric(dsRate.Tables(0).Rows(0).Item("LiabPrem").ToString()) Then
            '    Quotetotal += CInt(dsRate.Tables(0).Rows(0).Item("LiabPrem").ToString())
            'End If
            'If IsNumeric(dsRate.Tables(0).Rows(0).Item("FirePrem").ToString()) Then
            '    Quotetotal += CInt(dsRate.Tables(0).Rows(0).Item("FirePrem").ToString())
            'End If
            'If IsNumeric(dsRate.Tables(0).Rows(0).Item("RadioPrem").ToString()) Then
            '    Quotetotal += CInt(dsRate.Tables(0).Rows(0).Item("RadioPrem").ToString())
            'End If





            'Quotetotal += CInt(PackTotal * 0.01)
            'Quotetotal += CInt(PackTotal * 0.013)
            'Quotetotal += 25
            'Quotetotal += 2

            'pdffield = myPDFFields.Fields("Total Quoted Premium")
            'DirectCast(pdffield, TallComponents.PDF.Forms.Fields.TextField).Value = Quotetotal


            For Each field As TallComponents.PDF.Forms.Fields.Field In myPDFFields.Fields
                For Each widget As Widget In field.Widgets
                    widget.Persistency = WidgetPersistency.Flatten
                Next
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
    Public Sub printlloyQuote(ByVal ds As Data.DataSet, ByVal ds4 As Data.DataSet)


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

            Dim pdffield As TallComponents.PDF.Forms.Fields.Field
            pdffield = myPDFFields.Fields("QuoteNum")
            DirectCast(pdffield, TallComponents.PDF.Forms.Fields.TextField).Value = ds.Tables(0).Rows(0).Item("quoteID").ToString()

            pdffield = myPDFFields.Fields("QuoteTerm")
            DirectCast(pdffield, TallComponents.PDF.Forms.Fields.TextField).Value = ds.Tables(0).Rows(0).Item("term").ToString()


            pdffield = myPDFFields.Fields("QuoteNumdate")
            DirectCast(pdffield, TallComponents.PDF.Forms.Fields.TextField).Value = Date.Now.ToString("MM/dd/yyyy") 'ds.Tables(0).Rows(0).Item("quoteID").ToString()

            pdffield = myPDFFields.Fields("QuoteEffDate")
            DirectCast(pdffield, TallComponents.PDF.Forms.Fields.TextField).Value = ds.Tables(0).Rows(0).Item("effDate").ToString()

            pdffield = myPDFFields.Fields("QuoteCompany")
            If ds.Tables(0).Rows(0).Item("ARRateType").ToString() = "SMH Package" Then
                DirectCast(pdffield, TallComponents.PDF.Forms.Fields.TextField).Value = "LLOYD'S Specialty MH – HO8" ' & ds.Tables(0).Rows(0).Item("ARRateType").ToString()

            Else
                DirectCast(pdffield, TallComponents.PDF.Forms.Fields.TextField).Value = "LLOYD'S " & ds.Tables(0).Rows(0).Item("ARRateType").ToString()

            End If
           


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
                        value = ds.Tables(0).Rows(0).Item("AgentPhone").ToString()
                        DirectCast(myPDFField, TallComponents.PDF.Forms.Fields.TextField).Value = "(800) 628- 3762" 'value
                        'Client Section
                    Case "ClientName"
                        value = UCase(ds.Tables(0).Rows(0).Item("applicantFirstName").ToString()) + " " + UCase(ds.Tables(0).Rows(0).Item("applicantLastName").ToString())
                        DirectCast(myPDFField, TallComponents.PDF.Forms.Fields.TextField).Value = value
                    Case "ClientAddr1"
                        value = UCase(ds.Tables(0).Rows(0).Item("propAddress").ToString())
                        DirectCast(myPDFField, TallComponents.PDF.Forms.Fields.TextField).Value = value
                    Case "ClientAddr2"
                        value = ""
                        DirectCast(myPDFField, TallComponents.PDF.Forms.Fields.TextField).Value = value
                    Case "ClientCSZ"
                        value = ds.Tables(0).Rows(0).Item("city").ToString() + " " + ds.Tables(0).Rows(0).Item("state").ToString() + " " + ds.Tables(0).Rows(0).Item("zip").ToString()
                        DirectCast(myPDFField, TallComponents.PDF.Forms.Fields.TextField).Value = UCase(value)
                    Case "ClientPhone"
                        value = ""
                        DirectCast(myPDFField, TallComponents.PDF.Forms.Fields.TextField).Value = value
                        'Sub Information
                    Case "SubName"
                        value = ds.Tables(0).Rows(0).Item("AgencyName").ToString()
                        DirectCast(myPDFField, TallComponents.PDF.Forms.Fields.TextField).Value = UCase(value) & "     " & ds.Tables(0).Rows(0).Item("AgencyCode").ToString()

                    Case "SubAddr1"
                        value = ds.Tables(0).Rows(0).Item("AgentAddr1").ToString()
                        DirectCast(myPDFField, TallComponents.PDF.Forms.Fields.TextField).Value = UCase(value)
                    Case "SubAddr2"
                        value = UCase(ds.Tables(0).Rows(0).Item("AgentAddr2").ToString())
                        DirectCast(myPDFField, TallComponents.PDF.Forms.Fields.TextField).Value = value
                    Case "SubCSZ"
                        value = ds.Tables(0).Rows(0).Item("AgentCity").ToString() & ", " & ds.Tables(0).Rows(0).Item("AgentState").ToString() & " " & ds.Tables(0).Rows(0).Item("AgentZip").ToString()
                        DirectCast(myPDFField, TallComponents.PDF.Forms.Fields.TextField).Value = UCase(value)
                    Case "SubPhone"
                        value = ds.Tables(0).Rows(0).Item("AgentPhone").ToString()
                        DirectCast(myPDFField, TallComponents.PDF.Forms.Fields.TextField).Value = UCase(value)


                        'Unit Information
                    Case "Year"
                        value = ds.Tables(0).Rows(0).Item("year").ToString()
                        DirectCast(myPDFField, TallComponents.PDF.Forms.Fields.TextField).Value = value
                    Case "Model"
                        value = ds.Tables(0).Rows(0).Item("homeType").ToString()
                        DirectCast(myPDFField, TallComponents.PDF.Forms.Fields.TextField).Value = UCase(value)
                    Case "Length"
                        value = ds.Tables(0).Rows(0).Item("length").ToString()
                        DirectCast(myPDFField, TallComponents.PDF.Forms.Fields.TextField).Value = value
                    Case "Value"
                        value = ds4.Tables(0).Rows(0).Item("PackDwel").ToString()
                        DirectCast(myPDFField, TallComponents.PDF.Forms.Fields.TextField).Value = value
                    Case "Make"
                        value = ds.Tables(0).Rows(0).Item("manf").ToString()
                        DirectCast(myPDFField, TallComponents.PDF.Forms.Fields.TextField).Value = UCase(value)
                    Case "RatingState"
                        value = ds.Tables(0).Rows(0).Item("state").ToString()
                        DirectCast(myPDFField, TallComponents.PDF.Forms.Fields.TextField).Value = UCase(value)
                    Case "Width"
                        value = ds.Tables(0).Rows(0).Item("width").ToString()
                        DirectCast(myPDFField, TallComponents.PDF.Forms.Fields.TextField).Value = value
                    Case "UseOfUnit"
                        value = ds.Tables(0).Rows(0).Item("homeUse").ToString()
                        DirectCast(myPDFField, TallComponents.PDF.Forms.Fields.TextField).Value = UCase(value)

                    Case "MobileHomeDesc"
                        value = "Mobile Home"
                        DirectCast(myPDFField, TallComponents.PDF.Forms.Fields.TextField).Value = value
                        'Case "MHDwellLimit"
                        '    value = ds2.Tables(0).Rows(0).Item("StandDwel").ToString()
                        '    DirectCast(myPDFField, TallComponents.PDF.Forms.Fields.TextField).Value = CInt(value)
                        'Case "MHDwellPremium"
                        '    value = FormatCurrency(dsRate.Tables(0).Rows(0).Item("DwellingPrem").ToString())
                        '    DirectCast(myPDFField, TallComponents.PDF.Forms.Fields.TextField).Value = String.Format("{0:C0}", Math.Round(CDbl(value.Replace("$", ""))))

                        'Case "MobileHomePersonalProp"
                        '    'value = "Personal Property"
                        '    value = "Contents"
                        '    DirectCast(myPDFField, TallComponents.PDF.Forms.Fields.TextField).Value = value
                        'Case "MHPerPropLimit"
                        '    value = dsRate.Tables(0).Rows(0).Item("PerPropLimit").ToString()
                        '    DirectCast(myPDFField, TallComponents.PDF.Forms.Fields.TextField).Value = CInt(value)
                        'Case "MHPerPropPremium"
                        '    If dsRate.Tables(0).Rows(0).Item("PerPropPrem") = "INCLUDED" Then
                        '        value = dsRate.Tables(0).Rows(0).Item("PerPropPrem").ToString()
                        '    Else
                        '        value = FormatCurrency(dsRate.Tables(0).Rows(0).Item("PerPropPrem").ToString())
                        '        value = String.Format("{0:C0}", Math.Round(CDbl(value.Replace("$", ""))))
                        '    End If

                        ' DirectCast(myPDFField, TallComponents.PDF.Forms.Fields.TextField).Value = value


                        'Case "MHAddStrucDesc"
                        '    ' value = "Adjacent Structures"
                        '    value = "Other Structures"
                        '    DirectCast(myPDFField, TallComponents.PDF.Forms.Fields.TextField).Value = value
                        'Case "MHAddStrucLimit"
                        '    value = dsrate.Tables(0).Rows(0).Item("AddStrucLimit").ToString()
                        '    DirectCast(myPDFField, TallComponents.PDF.Forms.Fields.TextField).Value = CInt(value)
                        'Case "MHAddStrucPremium"
                        '    If dsrate.Tables(0).Rows(0).Item("AddStrucPrem").ToString() = "INCLUDED" Then
                        '        value = dsrate.Tables(0).Rows(0).Item("AddStrucPrem").ToString()
                        '    Else
                        '        value = FormatCurrency(dsrate.Tables(0).Rows(0).Item("AddStrucPrem").ToString())
                        '        value = String.Format("{0:C0}", Math.Round(CDbl(value.Replace("$", ""))))
                        '    End If
                        '    DirectCast(myPDFField, TallComponents.PDF.Forms.Fields.TextField).Value = value

                        'Case "MHPerLiabDesc"
                        '    value = "Personal Liability"
                        '    DirectCast(myPDFField, TallComponents.PDF.Forms.Fields.TextField).Value = value.Replace("$", "")
                        '    'Case "MHPerLiabLimit"
                        '    value = dsrate.Tables(0).Rows(0).Item("LiabLimit").ToString()
                        '    DirectCast(myPDFField, TallComponents.PDF.Forms.Fields.TextField).Value = value.Replace("$", "")
                        'Case "MHPerLiabPremium"
                        '    value = FormatCurrency(dsrate.Tables(0).Rows(0).Item("LiabPrem").ToString())
                        '    DirectCast(myPDFField, TallComponents.PDF.Forms.Fields.TextField).Value = String.Format("{0:C0}", Math.Round(CDbl(value.Replace("$", ""))))

                        'Case "MHDedDesc"
                        '    value = "Deductible Change Option"
                        '    DirectCast(myPDFField, TallComponents.PDF.Forms.Fields.TextField).Value = value
                        'Case "MHDedPremium"
                        '    value = FormatCurrency(dsRate.Tables(0).Rows(0).Item("DedPrem").ToString())
                        '    DirectCast(myPDFField, TallComponents.PDF.Forms.Fields.TextField).Value = String.Format("{0:C0}", Math.Round(CDbl(value)))

                        'Case "MHPropRepDesc"
                        '    value = dsrate.Tables(0).Rows(0).Item("PerPropRepPrem").ToString()
                        '    If value = "" Then
                        '        value = ""
                        '    Else
                        '        value = "Contents Replacement Cost"
                        '    End If
                        '    DirectCast(myPDFField, TallComponents.PDF.Forms.Fields.TextField).Value = value.Replace("$", "")
                        'Case "MHPropRepPremium"
                        '    value = dsrate.Tables(0).Rows(0).Item("PerPropRepPrem").ToString()
                        '    If value = "" Then
                        '        value = ""
                        '    Else
                        '        value = FormatCurrency(dsrate.Tables(0).Rows(0).Item("PerPropRepPrem").ToString())
                        '        value = String.Format("{0:C0}", Math.Round(CDbl(value.Replace("$", ""))))
                        '    End If
                        '    DirectCast(myPDFField, TallComponents.PDF.Forms.Fields.TextField).Value = value.Replace("$", "")

                        'Case "MHRepCostDesc"
                        '    value = dsrate.Tables(0).Rows(0).Item("MHRepPrem").ToString()
                        '    If value = "" Then
                        '        value = ""
                        '    Else
                        '        value = "Replacement Cost for Mobile Home"
                        '    End If
                        '    DirectCast(myPDFField, TallComponents.PDF.Forms.Fields.TextField).Value = value
                        'Case "MHRepCostPremium"
                        '    value = dsrate.Tables(0).Rows(0).Item("MHRepPrem").ToString()
                        '    If value = "" Then
                        '        value = ""
                        '    Else
                        '        value = FormatCurrency(dsrate.Tables(0).Rows(0).Item("MHRepPrem").ToString())
                        '    End If
                        '    DirectCast(myPDFField, TallComponents.PDF.Forms.Fields.TextField).Value = value.Replace("$", "")

                        'Case "MHFireDesc"
                        '    value = dsrate.Tables(0).Rows(0).Item("FirePrem").ToString()
                        '    If value = "" Then
                        '        value = ""
                        '    Else
                        '        value = "Fire Department Service Charge"
                        '    End If
                        '    DirectCast(myPDFField, TallComponents.PDF.Forms.Fields.TextField).Value = value.Replace("$", "")
                        'Case "MHFireLimit"
                        '    value = dsrate.Tables(0).Rows(0).Item("FirePrem").ToString()
                        '    If value = "" Then
                        '        value = ""
                        '    Else
                        '        value = FormatCurrency(dsrate.Tables(0).Rows(0).Item("FireOpt").ToString())
                        '    End If
                        '    DirectCast(myPDFField, TallComponents.PDF.Forms.Fields.TextField).Value = value.Replace("$", "")
                        'Case "MHFirePremium"
                        '    value = dsrate.Tables(0).Rows(0).Item("FirePrem").ToString()
                        '    If value = "" Then
                        '        value = ""
                        '    Else
                        '        value = FormatCurrency(dsrate.Tables(0).Rows(0).Item("FirePrem").ToString())
                        '    End If
                        '    DirectCast(myPDFField, TallComponents.PDF.Forms.Fields.TextField).Value = value.Replace("$", "")
                        '    '    'Radio
                        'Case "MHRadioDesc"
                        '    value = dsrate.Tables(0).Rows(0).Item("RadioPrem").ToString()
                        '    If value = "" Then
                        '        value = ""
                        '    Else
                        '        value = "Radio & T.V. Charge"
                        '    End If
                        '    DirectCast(myPDFField, TallComponents.PDF.Forms.Fields.TextField).Value = value.Replace("$", "")
                        'Case "MHRadioLimit"
                        '    value = dsrate.Tables(0).Rows(0).Item("RadioPrem").ToString()
                        '    If value = "" Then
                        '        value = ""
                        '    Else
                        '        value = FormatCurrency(dsrate.Tables(0).Rows(0).Item("RadioOpt").ToString())
                        '    End If

                        '    DirectCast(myPDFField, TallComponents.PDF.Forms.Fields.TextField).Value = value.Replace("$", "")

                        'Case "MHRadioPremium"
                        '    value = dsrate.Tables(0).Rows(0).Item("RadioPrem").ToString()
                        '    If value = "" Then
                        '        value = ""
                        '    Else
                        '        value = FormatCurrency(dsrate.Tables(0).Rows(0).Item("RadioPrem").ToString())
                        '    End If
                        '    DirectCast(myPDFField, TallComponents.PDF.Forms.Fields.TextField).Value = value.Replace("$", "")
                        'Case "MHMedPayDesc"
                        '    value = dsrate.Tables(0).Rows(0).Item("MedPayOpt").ToString()
                        '    If value = "" Then
                        '        value = ""
                        '    Else
                        '        value = "Medical Payments"
                        '    End If

                        '    DirectCast(myPDFField, TallComponents.PDF.Forms.Fields.TextField).Value = value.Replace("$", "")
                        'Case "MHMedPayLimit"
                        '    value = dsrate.Tables(0).Rows(0).Item("MedPayOpt").ToString()
                        '    If value = "" Then
                        '        value = ""
                        '    Else
                        '        value = dsrate.Tables(0).Rows(0).Item("MedPayOpt").ToString()
                        '    End If
                        '    DirectCast(myPDFField, TallComponents.PDF.Forms.Fields.TextField).Value = "$" & value.Replace("$", "")

                        '    If dsrate.Tables(0).Rows(0).Item("MedPayOpt").ToString() = "$1000" Then
                        '        pdffield = myPDFFields.Fields("MHMedPayPremium")
                        '        DirectCast(pdffield, TallComponents.PDF.Forms.Fields.TextField).Value = "$5".Replace("$", "")


                        '    End If

                        'Case "MHRepCostDesc"
                        '    value = dsrate.Tables(0).Rows(0).Item("MedMHRepPrem").ToString()
                        '    If value = "" Then
                        '        value = ""
                        '    Else
                        '        value = "Mobile Home Replacement Cost"
                        '    End If
                        '    DirectCast(myPDFField, TallComponents.PDF.Forms.Fields.TextField).Value = value.Replace("$", "")

                        'Case "MHRepCostPrem"
                        '    value = dsrate.Tables(0).Rows(0).Item("MedMHRepPrem").ToString()
                        '    If value = "" Then
                        '        value = ""
                        '    Else
                        '        value = FormatCurrency(dsrate.Tables(0).Rows(0).Item("MedMHRepPrem").ToString())
                        '    End If
                        '    DirectCast(myPDFField, TallComponents.PDF.Forms.Fields.TextField).Value = value.Replace("$", "")
                        '    '    'Replacement Cost
                        'Case "MHPropRepDesc"
                        '    value = dsrate.Tables(0).Rows(0).Item("MedRepPrem").ToString()
                        '    If value = "" Then
                        '        value = ""
                        '    Else
                        '        value = "Contents Replacement Cost"
                        '    End If
                        '    DirectCast(myPDFField, TallComponents.PDF.Forms.Fields.TextField).Value = value.Replace("$", "")

                        'Case "MHPropRepPrem"
                        '    value = dsrate.Tables(0).Rows(0).Item("MedRepPrem").ToString()
                        '    If value = "" Then
                        '        value = ""
                        '    Else
                        '        value = FormatCurrency(dsrate.Tables(0).Rows(0).Item("MedMHRepPrem").ToString())
                        '    End If
                        '    DirectCast(myPDFField, TallComponents.PDF.Forms.Fields.TextField).Value = value.Replace("$", "")




                        'Case "MHFeeDesc"
                        '    value = "Fees"
                        '    DirectCast(myPDFField, TallComponents.PDF.Forms.Fields.TextField).Value = value
                        'Case "MHFeeAmount"
                        '    value = FormatCurrency(dsrate.Tables(0).Rows(0).Item("Fees").ToString())
                        '    DirectCast(myPDFField, TallComponents.PDF.Forms.Fields.TextField).Value = value

                        '    'Fire Department Service Charge

                End Select


            Next
            Dim PackTotal As Integer

            Select Case ds.Tables(0).Rows(0).Item("ARRateType").ToString()
                Case "Package"
                    pdffield = myPDFFields.Fields("MHAddResDesc")
                    DirectCast(pdffield, TallComponents.PDF.Forms.Fields.TextField).Value = "Loss of Use"

                    pdffield = myPDFFields.Fields("MHAddResLimit")
                    DirectCast(pdffield, TallComponents.PDF.Forms.Fields.TextField).Value = "600"
                    'pdffield = myPDFFields.Fields("MHDwellLimit")
                    'DirectCast(pdffield, TallComponents.PDF.Forms.Fields.TextField).Value = CInt(ds4.Tables(0).Rows(0).Item("PackDwel").ToString())

                    'pdffield = myPDFFields.Fields("MHPerPropLimit")
                    'DirectCast(pdffield, TallComponents.PDF.Forms.Fields.TextField).Value = CInt(ds4.Tables(0).Rows(0).Item("PackCont").ToString())


                    'pdffield = myPDFFields.Fields("MHDwellPremium")
                    'DirectCast(pdffield, TallComponents.PDF.Forms.Fields.TextField).Value = CInt(ds4.Tables(0).Rows(0).Item("Packprem").ToString()) '- CInt(ds3.Tables(0).Rows(0).Item("PackHur").ToString()) - CInt(ds3.Tables(0).Rows(0).Item("PackNonHur").ToString())
                    'PackTotal += CInt(ds4.Tables(0).Rows(0).Item("PackBasePrem").ToString()) ' - CInt(ds3.Tables(0).Rows(0).Item("PackHur").ToString()) - CInt(ds3.Tables(0).Rows(0).Item("PackNonHur").ToString())

                    'pdffield = myPDFFields.Fields("MHDedDesc")
                    'DirectCast(pdffield, TallComponents.PDF.Forms.Fields.TextField).Value = "Deductible Change Option AOP"

                    'pdffield = myPDFFields.Fields("MHDedLimit")
                    'DirectCast(pdffield, TallComponents.PDF.Forms.Fields.TextField).Value = "$" & ds4.Tables(0).Rows(0).Item("PackAOP").ToString().Replace("$", "")
                    'pdffield = myPDFFields.Fields("MHDedPremium")
                    'DirectCast(pdffield, TallComponents.PDF.Forms.Fields.TextField).Value = "($" & CInt(ds4.Tables(0).Rows(0).Item("PackAOPPrem").ToString()) & ")"
                    '' PackTotal -= CInt(ds3.Tables(0).Rows(0).Item("PackNonHur").ToString())
                    'pdffield = myPDFFields.Fields("MHPropRepDesc")
                    'DirectCast(pdffield, TallComponents.PDF.Forms.Fields.TextField).Value = "Wind Hail Deductible:"

                    'pdffield = myPDFFields.Fields("MHPropRepPremiumLimit")
                    'DirectCast(pdffield, TallComponents.PDF.Forms.Fields.TextField).Value = ds4.Tables(0).Rows(0).Item("PackWind").ToString().Replace("$", "")
                    ''pdffield = myPDFFields.Fields("MHPropRepPremium")
                    ''DirectCast(pdffield, TallComponents.PDF.Forms.Fields.TextField).Value = "($" & CInt(ds3.Tables(0).Rows(0).Item("PackHur").ToString().Replace("$", "")) & ")"

                    'pdffield = myPDFFields.Fields("Total Quoted Premium")
                    'DirectCast(pdffield, TallComponents.PDF.Forms.Fields.TextField).Value = "$" & ds4.Tables(0).Rows(0).Item("Packtotal").ToString().Replace("$", "")

                    'If ds4.Tables(0).Rows(0).Item("PackContReplacePrem").ToString() <> "$0.00" Then

                    '    pdffield = myPDFFields.Fields("MHContentsdesc")
                    '    DirectCast(pdffield, TallComponents.PDF.Forms.Fields.TextField).Value = "Contents Replacement Cost"

                    '    pdffield = myPDFFields.Fields("MHContentsPremium")
                    '    DirectCast(pdffield, TallComponents.PDF.Forms.Fields.TextField).Value = ds4.Tables(0).Rows(0).Item("PackContReplacePrem").ToString().Replace("$", "")

                    'End If
                    'pdffield = myPDFFields.Fields("MHFeeDesc")
                    'DirectCast(pdffield, TallComponents.PDF.Forms.Fields.TextField).Value = "Fee"
                    'pdffield = myPDFFields.Fields("MHFeeAmount")
                    'DirectCast(pdffield, TallComponents.PDF.Forms.Fields.TextField).Value = "$" & ds4.Tables(0).Rows(0).Item("PackFees").ToString().Replace("$", "")
                    'If ds.Tables(0).Rows(0).Item("homeUse").ToString() = "Seasonal" Then
                    '    pdffield = myPDFFields.Fields("MHFeeDesc1")
                    '    DirectCast(pdffield, TallComponents.PDF.Forms.Fields.TextField).Value = "Seasonal Fee"
                    '    pdffield = myPDFFields.Fields("MHFeeAmount1")
                    '    DirectCast(pdffield, TallComponents.PDF.Forms.Fields.TextField).Value = "$20"
                    'End If
                    'If ds4.Tables(0).Rows(0).Item("PackFees").ToString().Replace("$", "") = "Yes" Then
                    '    pdffield = myPDFFields.Fields("MHRepCostDesc")
                    '    DirectCast(pdffield, TallComponents.PDF.Forms.Fields.TextField).Value = "Replacement Cost for Mobile Home"
                    '    pdffield = myPDFFields.Fields("MHRepCostPremium")
                    '    DirectCast(pdffield, TallComponents.PDF.Forms.Fields.TextField).Value = "$" & ds4.Tables(0).Rows(0).Item("PackMHReplacePrem").ToString().Replace("$", "")

                    'End If
                    ''-----
                    'If ds4.Tables(0).Rows(0).Item("PackCont").ToString().Replace("$", "") = "0.00" Then
                    '    pdffield = myPDFFields.Fields("MobileHomePersonalProp")
                    '    DirectCast(pdffield, TallComponents.PDF.Forms.Fields.TextField).Value = "Contents"
                    '    pdffield = myPDFFields.Fields("MHPerPropLimit")
                    '    DirectCast(pdffield, TallComponents.PDF.Forms.Fields.TextField).Value = "$" & ds4.Tables(0).Rows(0).Item("PackCont").ToString().Replace("$", "")
                    '    pdffield = myPDFFields.Fields("MHPerPropPremium")
                    '    DirectCast(pdffield, TallComponents.PDF.Forms.Fields.TextField).Value = "$" & ds4.Tables(0).Rows(0).Item("PackContPrem").ToString().Replace("$", "")

                    'End If

                    'If ds4.Tables(0).Rows(0).Item("PackStruc").ToString().Replace("$", "") = "0.00" Then
                    '    pdffield = myPDFFields.Fields("MHAddStrucDesc")
                    '    DirectCast(pdffield, TallComponents.PDF.Forms.Fields.TextField).Value = "Other Structures"
                    '    pdffield = myPDFFields.Fields("MHAddStrucLimit")
                    '    DirectCast(pdffield, TallComponents.PDF.Forms.Fields.TextField).Value = "$" & ds4.Tables(0).Rows(0).Item("PackStruc").ToString().Replace("$", "")
                    '    pdffield = myPDFFields.Fields("MHAddStrucPremium")
                    '    DirectCast(pdffield, TallComponents.PDF.Forms.Fields.TextField).Value = "$" & ds4.Tables(0).Rows(0).Item("PackStrucPrem").ToString().Replace("$", "")

                    'End If
                    'If ds4.Tables(0).Rows(0).Item("PackPerLiab").ToString().Replace("$", "") = "0.00" Then
                    '    pdffield = myPDFFields.Fields(" MHPerLiabDesc")
                    '    DirectCast(pdffield, TallComponents.PDF.Forms.Fields.TextField).Value = "Personal Liability"
                    '    pdffield = myPDFFields.Fields("MHPerLiabLimit")
                    '    DirectCast(pdffield, TallComponents.PDF.Forms.Fields.TextField).Value = "$" & ds4.Tables(0).Rows(0).Item("PackPerLiab").ToString().Replace("$", "")
                    '    pdffield = myPDFFields.Fields("MHPerLiabPremium")
                    '    DirectCast(pdffield, TallComponents.PDF.Forms.Fields.TextField).Value = "$" & ds4.Tables(0).Rows(0).Item("PackPersLiabPrem").ToString().Replace("$", "")

                    'End If
                    'If ds4.Tables(0).Rows(0).Item("PackMedPay").ToString().Replace("$", "") > "0.00" Then
                    '    pdffield = myPDFFields.Fields("MHMedPayDesc")
                    '    DirectCast(pdffield, TallComponents.PDF.Forms.Fields.TextField).Value = "Medical Payments"
                    '    pdffield = myPDFFields.Fields("MHMedPayLimit")
                    '    DirectCast(pdffield, TallComponents.PDF.Forms.Fields.TextField).Value = "$" & ds4.Tables(0).Rows(0).Item("PackMedPay").ToString().Replace("$", "")
                    '    pdffield = myPDFFields.Fields("MHMedPayPremium")
                    '    DirectCast(pdffield, TallComponents.PDF.Forms.Fields.TextField).Value = "$" & ds4.Tables(0).Rows(0).Item("PackMedPrem").ToString().Replace("$", "")

                    'End If

                    pdffield = myPDFFields.Fields("MHDwellLimit")
                    DirectCast(pdffield, TallComponents.PDF.Forms.Fields.TextField).Value = CInt(ds4.Tables(0).Rows(0).Item("PackDwel").ToString())

                    'pdffield = myPDFFields.Fields("MHPerPropLimit")
                    'DirectCast(pdffield, TallComponents.PDF.Forms.Fields.TextField).Value = CInt(ds4.Tables(0).Rows(0).Item("PackCont").ToString())


                    pdffield = myPDFFields.Fields("MHDwellPremium")
                    DirectCast(pdffield, TallComponents.PDF.Forms.Fields.TextField).Value = CInt(ds4.Tables(0).Rows(0).Item("Packprem").ToString()) '- CInt(ds3.Tables(0).Rows(0).Item("PackHur").ToString()) - CInt(ds3.Tables(0).Rows(0).Item("PackNonHur").ToString())
                    ' PackardTotal += CInt(ds4.Tables(0).Rows(0).Item("PackBasePrem").ToString()) ' - CInt(ds3.Tables(0).Rows(0).Item("PackHur").ToString()) - CInt(ds3.Tables(0).Rows(0).Item("PackNonHur").ToString())
                    If CInt(ds4.Tables(0).Rows(0).Item("PackAOP").ToString().Replace("$", "")) > 500 Then
                        pdffield = myPDFFields.Fields("MHDedDesc")
                        DirectCast(pdffield, TallComponents.PDF.Forms.Fields.TextField).Value = "Deductible Change Option AOP"
                        pdffield = myPDFFields.Fields("MHDedPremium")
                        DirectCast(pdffield, TallComponents.PDF.Forms.Fields.TextField).Value = "($" & CInt(ds4.Tables(0).Rows(0).Item("PackAOPPrem").ToString()) & ")"
                    Else
                        pdffield = myPDFFields.Fields("MHDedDesc")
                        DirectCast(pdffield, TallComponents.PDF.Forms.Fields.TextField).Value = "AOP Deductible"
                    End If

                    'pdffield = myPDFFields.Fields("MHDedDesc")
                   ' DirectCast(pdffield, TallComponents.PDF.Forms.Fields.TextField).Value = "Deductible Change Option AOP"

                    pdffield = myPDFFields.Fields("MHDedLimit")
                    DirectCast(pdffield, TallComponents.PDF.Forms.Fields.TextField).Value = "$" & ds4.Tables(0).Rows(0).Item("PackAOP").ToString().Replace("$", "")
                   ' pdffield = myPDFFields.Fields("MHDedPremium")
                    'DirectCast(pdffield, TallComponents.PDF.Forms.Fields.TextField).Value = "($" & CInt(ds4.Tables(0).Rows(0).Item("PackAOPPrem").ToString()) & ")"
                    ' PackTotal -= CInt(ds3.Tables(0).Rows(0).Item("PackNonHur").ToString())
                    pdffield = myPDFFields.Fields("MHPropRepDesc")
                    DirectCast(pdffield, TallComponents.PDF.Forms.Fields.TextField).Value = "Wind Hail Deductible:"
                    If ds.Tables(0).Rows(0).Item("state").ToString() = "TN" Then
                        pdffield = myPDFFields.Fields("MHPropRepPremiumLimit")
                        DirectCast(pdffield, TallComponents.PDF.Forms.Fields.TextField).Value = "$500" 'ds4.Tables(0).Rows(0).Item("PackWind").ToString().Replace("$", "")
                    Else
                        pdffield = myPDFFields.Fields("MHPropRepPremiumLimit")
                        DirectCast(pdffield, TallComponents.PDF.Forms.Fields.TextField).Value = "$" & ds4.Tables(0).Rows(0).Item("PackWind").ToString().Replace("$", "")

                    End If
                   
                    'pdffield = myPDFFields.Fields("MHPropRepPremium")
                    'DirectCast(pdffield, TallComponents.PDF.Forms.Fields.TextField).Value = "($" & CInt(ds3.Tables(0).Rows(0).Item("PackHur").ToString().Replace("$", "")) & ")"

                    'Hurricane/Tropical Storm

                    pdffield = myPDFFields.Fields("MHRepCostDesc")
                    DirectCast(pdffield, TallComponents.PDF.Forms.Fields.TextField).Value = "Hurricane / Tropical Storm Deductible:"
                    If ds.Tables(0).Rows(0).Item("state").ToString() = "TN" Then

                        pdffield = myPDFFields.Fields("MHPropCostPremlimit")
                        DirectCast(pdffield, TallComponents.PDF.Forms.Fields.TextField).Value = "1000" 'ds4.Tables(0).Rows(0).Item("PackWind").ToString().Replace("$", "")
                    Else
                        pdffield = myPDFFields.Fields("MHPropCostPremlimit")
                        DirectCast(pdffield, TallComponents.PDF.Forms.Fields.TextField).Value = ds4.Tables(0).Rows(0).Item("PackWind").ToString().Replace("$", "")
                    End If
                   


                    pdffield = myPDFFields.Fields("Total Quoted Premium")
                    DirectCast(pdffield, TallComponents.PDF.Forms.Fields.TextField).Value = "$" & ds4.Tables(0).Rows(0).Item("Packtotal").ToString().Replace("$", "")

                    If ds4.Tables(0).Rows(0).Item("PackContReplacePrem").ToString().Replace("$", "") <> "0" Then

                        pdffield = myPDFFields.Fields("MHContentsdesc")
                        DirectCast(pdffield, TallComponents.PDF.Forms.Fields.TextField).Value = "Contents Replacement Cost"

                        pdffield = myPDFFields.Fields("MHContentsLimit")
                        DirectCast(pdffield, TallComponents.PDF.Forms.Fields.TextField).Value = ds4.Tables(0).Rows(0).Item("PackCont").ToString().Replace("$", "")

                        pdffield = myPDFFields.Fields("MHContentsPremium")
                        DirectCast(pdffield, TallComponents.PDF.Forms.Fields.TextField).Value = ds4.Tables(0).Rows(0).Item("PackContReplacePrem").ToString().Replace("$", "")

                    End If
                   ' pdffield = myPDFFields.Fields("MHFeeDesc")
                   ' DirectCast(pdffield, TallComponents.PDF.Forms.Fields.TextField).Value = "Fee"
                   ' pdffield = myPDFFields.Fields("MHFeeAmount")
                    'DirectCast(pdffield, TallComponents.PDF.Forms.Fields.TextField).Value = "$" & ds4.Tables(0).Rows(0).Item("PackFees").ToString().Replace("$", "")
                    If ds.Tables(0).Rows(0).Item("homeUse").ToString() = "Seasonal" Then
                        pdffield = myPDFFields.Fields("MHFeeDesc1")
                        DirectCast(pdffield, TallComponents.PDF.Forms.Fields.TextField).Value = "Seasonal Surcharge"
                        pdffield = myPDFFields.Fields("MHFeeAmount1")
                        DirectCast(pdffield, TallComponents.PDF.Forms.Fields.TextField).Value = "$20"
                        pdffield = myPDFFields.Fields("MHSIPDesc")
                        DirectCast(pdffield, TallComponents.PDF.Forms.Fields.TextField).Value = "Policy Fee"
                        pdffield = myPDFFields.Fields("MHSIPPremium")
                        DirectCast(pdffield, TallComponents.PDF.Forms.Fields.TextField).Value = "$" & ds4.Tables(0).Rows(0).Item("PackFees").ToString().Replace("$", "") - 20
                        If ds4.Tables(0).Rows(0).Item("PackCreditPerc").ToString().Replace("$", "") > "0" Then
                            pdffield = myPDFFields.Fields("MHFeeDesc2")
                            DirectCast(pdffield, TallComponents.PDF.Forms.Fields.TextField).Value = "Credit Percentage " & CDbl(ds4.Tables(0).Rows(0).Item("PackCreditPerc").ToString().Replace("$", "")) * 100 & " %"
                            pdffield = myPDFFields.Fields("MHFeeAmount2")
                            DirectCast(pdffield, TallComponents.PDF.Forms.Fields.TextField).Value = "($-" & ds4.Tables(0).Rows(0).Item("PackCreditamt").ToString().Replace("$", "") & ")"

                        End If
                    Else
                        pdffield = myPDFFields.Fields("MHSIPDesc")
                        DirectCast(pdffield, TallComponents.PDF.Forms.Fields.TextField).Value = " Policy Fee"
                        pdffield = myPDFFields.Fields("MHSIPPremium")
                        DirectCast(pdffield, TallComponents.PDF.Forms.Fields.TextField).Value = "$" & ds4.Tables(0).Rows(0).Item("PackFees").ToString().Replace("$", "")

                        If ds4.Tables(0).Rows(0).Item("PackCreditPerc").ToString().Replace("$", "") > "0" Then
                            pdffield = myPDFFields.Fields("MHFeeDesc2")
                            DirectCast(pdffield, TallComponents.PDF.Forms.Fields.TextField).Value = "Credit Percentage " & CDbl(ds4.Tables(0).Rows(0).Item("PackCreditPerc").ToString().Replace("$", "")) * 100 & " %"
                            pdffield = myPDFFields.Fields("MHFeeAmount2")
                            DirectCast(pdffield, TallComponents.PDF.Forms.Fields.TextField).Value = "($-" & ds4.Tables(0).Rows(0).Item("PackCreditamt").ToString().Replace("$", "") & ")"

                        End If

                    End If
                    If ds4.Tables(0).Rows(0).Item("PackMHReplace").ToString().Replace("$", "") = "Yes" Then
                        pdffield = myPDFFields.Fields("MHRadioDesc")
                        DirectCast(pdffield, TallComponents.PDF.Forms.Fields.TextField).Value = "Replacement Cost for Mobile Home"
                        pdffield = myPDFFields.Fields("MHRadioPremium")
                        DirectCast(pdffield, TallComponents.PDF.Forms.Fields.TextField).Value = "$" & ds4.Tables(0).Rows(0).Item("PackMHReplacePrem").ToString().Replace("$", "")

                    End If
                    'If ds4.Tables(0).Rows(0).Item("PackContPrem").ToString().Replace("$", "") > "0" Then
                    pdffield = myPDFFields.Fields("MobileHomePersonalProp")
                    DirectCast(pdffield, TallComponents.PDF.Forms.Fields.TextField).Value = "Contents"
                    pdffield = myPDFFields.Fields("MHPerPropLimit")
                    DirectCast(pdffield, TallComponents.PDF.Forms.Fields.TextField).Value = "$" & ds4.Tables(0).Rows(0).Item("PackCont").ToString().Replace("$", "")
                    pdffield = myPDFFields.Fields("MHPerPropPremium")
                    DirectCast(pdffield, TallComponents.PDF.Forms.Fields.TextField).Value = "$" & ds4.Tables(0).Rows(0).Item("PackContPrem").ToString().Replace("$", "")

                    ' End If

                    If ds4.Tables(0).Rows(0).Item("PackStruc").ToString().Replace("$", "") <> "0.00" Then
                        pdffield = myPDFFields.Fields("MHAddStrucDesc")
                        DirectCast(pdffield, TallComponents.PDF.Forms.Fields.TextField).Value = "Other Structures"
                        pdffield = myPDFFields.Fields("MHAddStrucLimit")
                        DirectCast(pdffield, TallComponents.PDF.Forms.Fields.TextField).Value = "$" & ds4.Tables(0).Rows(0).Item("PackStruc").ToString().Replace("$", "")
                        pdffield = myPDFFields.Fields("MHAddStrucPremium")
                        DirectCast(pdffield, TallComponents.PDF.Forms.Fields.TextField).Value = "$" & ds4.Tables(0).Rows(0).Item("PackStrucPrem").ToString().Replace("$", "")

                    End If
                    If ds4.Tables(0).Rows(0).Item("PackPerLiab").ToString().Replace("$", "") <> "0" Then
                        pdffield = myPDFFields.Fields("MHPerLiabDesc")
                        DirectCast(pdffield, TallComponents.PDF.Forms.Fields.TextField).Value = "Personal Liability"
                        pdffield = myPDFFields.Fields("MHPerLiabLimit")
                        DirectCast(pdffield, TallComponents.PDF.Forms.Fields.TextField).Value = "$" & ds4.Tables(0).Rows(0).Item("PackPerLiab").ToString().Replace("$", "").Replace(",", "")
                        pdffield = myPDFFields.Fields("MHPerLiabPremium")
                        DirectCast(pdffield, TallComponents.PDF.Forms.Fields.TextField).Value = "$" & ds4.Tables(0).Rows(0).Item("PackPersLiabPrem").ToString().Replace("$", "")

                    End If


                    If ds4.Tables(0).Rows(0).Item("PackFullRepair").ToString().Replace("$", "") = "Yes" Then
                        pdffield = myPDFFields.Fields("MHFireDesc")
                        DirectCast(pdffield, TallComponents.PDF.Forms.Fields.TextField).Value = "Full Repair"
                        'pdffield = myPDFFields.Fields("MHContentsLimit")
                        'DirectCast(pdffield, TallComponents.PDF.Forms.Fields.TextField).Value = "$" & ds4.Tables(0).Rows(0).Item("PackPerLiab").ToString().Replace("$", "")
                        pdffield = myPDFFields.Fields("MHFirePremium")
                        DirectCast(pdffield, TallComponents.PDF.Forms.Fields.TextField).Value = "$" & ds4.Tables(0).Rows(0).Item("PackFullRepairPrem").ToString().Replace("$", "")

                    End If


                    pdffield = myPDFFields.Fields("MHNDDesc")
                    DirectCast(pdffield, TallComponents.PDF.Forms.Fields.TextField).Value = "Tax"
                    pdffield = myPDFFields.Fields("MHNDPremium")
                    DirectCast(pdffield, TallComponents.PDF.Forms.Fields.TextField).Value = "$" & ds4.Tables(0).Rows(0).Item("PackTax").ToString().Replace("$", "")
                    If ds4.Tables(0).Rows(0).Item("PackMedPay").ToString().Replace("$", "") > "0.00" Then
                        pdffield = myPDFFields.Fields("MHMedPayDesc")
                        DirectCast(pdffield, TallComponents.PDF.Forms.Fields.TextField).Value = "Medical Payments"
                        pdffield = myPDFFields.Fields("MHMedPayLimit")
                        DirectCast(pdffield, TallComponents.PDF.Forms.Fields.TextField).Value = "$" & ds4.Tables(0).Rows(0).Item("PackMedPay").ToString().Replace("$", "")
                        pdffield = myPDFFields.Fields("MHMedPayPremium")
                        DirectCast(pdffield, TallComponents.PDF.Forms.Fields.TextField).Value = "$" & ds4.Tables(0).Rows(0).Item("PackMedPrem").ToString().Replace("$", "")

                    End If



                    ' PackTotal -= CInt(ds3.Tables(0).Rows(0).Item("PackHur").ToString())
                Case "Standard"
                    pdffield = myPDFFields.Fields("MHDwellLimit")
                    DirectCast(pdffield, TallComponents.PDF.Forms.Fields.TextField).Value = CInt(ds4.Tables(0).Rows(0).Item("StandDwel").ToString())

                    'pdffield = myPDFFields.Fields("MHPerPropLimit")
                    'DirectCast(pdffield, TallComponents.PDF.Forms.Fields.TextField).Value = CInt(ds4.Tables(0).Rows(0).Item("StandCont").ToString())


                    pdffield = myPDFFields.Fields("MHDwellPremium")
                    DirectCast(pdffield, TallComponents.PDF.Forms.Fields.TextField).Value = CInt(ds4.Tables(0).Rows(0).Item("Standprem").ToString()) '- CInt(ds3.Tables(0).Rows(0).Item("StandHur").ToString()) - CInt(ds3.Tables(0).Rows(0).Item("StandNonHur").ToString())
                    ' StandardTotal += CInt(ds4.Tables(0).Rows(0).Item("StandBasePrem").ToString()) ' - CInt(ds3.Tables(0).Rows(0).Item("StandHur").ToString()) - CInt(ds3.Tables(0).Rows(0).Item("StandNonHur").ToString())
                    If CInt(ds4.Tables(0).Rows(0).Item("StandAOP").ToString().Replace("$", "")) > 500 Then
                        pdffield = myPDFFields.Fields("MHDedDesc")
                        DirectCast(pdffield, TallComponents.PDF.Forms.Fields.TextField).Value = "Deductible Change Option AOP"
                        pdffield = myPDFFields.Fields("MHDedPremium")
                        DirectCast(pdffield, TallComponents.PDF.Forms.Fields.TextField).Value = "($" & CInt(ds4.Tables(0).Rows(0).Item("StandAOPPrem").ToString()) & ")"
                    Else
                        pdffield = myPDFFields.Fields("MHDedDesc")
                        DirectCast(pdffield, TallComponents.PDF.Forms.Fields.TextField).Value = "AOP Deductible"
                    End If
                

                    pdffield = myPDFFields.Fields("MHDedLimit")
                    DirectCast(pdffield, TallComponents.PDF.Forms.Fields.TextField).Value = "$" & ds4.Tables(0).Rows(0).Item("StandAOP").ToString().Replace("$", "")
                    
                    ' StandTotal -= CInt(ds3.Tables(0).Rows(0).Item("StandNonHur").ToString())


                    pdffield = myPDFFields.Fields("MHPropRepDesc")
                    DirectCast(pdffield, TallComponents.PDF.Forms.Fields.TextField).Value = "Wind Hail Deductible:"

                    pdffield = myPDFFields.Fields("MHPropRepPremiumLimit")
                    DirectCast(pdffield, TallComponents.PDF.Forms.Fields.TextField).Value = ds4.Tables(0).Rows(0).Item("StandWind").ToString().Replace("$", "")
                    'pdffield = myPDFFields.Fields("MHPropRepPremium")
                    'DirectCast(pdffield, TallComponents.PDF.Forms.Fields.TextField).Value = "($" & CInt(ds3.Tables(0).Rows(0).Item("StandHur").ToString().Replace("$", "")) & ")"

                    pdffield = myPDFFields.Fields("Total Quoted Premium")
                    DirectCast(pdffield, TallComponents.PDF.Forms.Fields.TextField).Value = "$" & ds4.Tables(0).Rows(0).Item("Standtotal").ToString().Replace("$", "")

                    If ds4.Tables(0).Rows(0).Item("StandContReplacePrem").ToString() <> "0" Then

                        pdffield = myPDFFields.Fields("MHContentsdesc")
                        DirectCast(pdffield, TallComponents.PDF.Forms.Fields.TextField).Value = "Contents Replacement Cost"

                        pdffield = myPDFFields.Fields("MHContentsPremium")
                        DirectCast(pdffield, TallComponents.PDF.Forms.Fields.TextField).Value = ds4.Tables(0).Rows(0).Item("StandContReplacePrem").ToString().Replace("$", "")

                    End If
                    If ds.Tables(0).Rows(0).Item("homeUse").ToString() = "Seasonal" Then
                        pdffield = myPDFFields.Fields("MHFeeDesc1")
                        DirectCast(pdffield, TallComponents.PDF.Forms.Fields.TextField).Value = "Seasonal Surcharge"
                        pdffield = myPDFFields.Fields("MHFeeAmount1")
                        DirectCast(pdffield, TallComponents.PDF.Forms.Fields.TextField).Value = "$20"
                        pdffield = myPDFFields.Fields("MHSIPDesc")
                        DirectCast(pdffield, TallComponents.PDF.Forms.Fields.TextField).Value = "Policy Fee"
                        pdffield = myPDFFields.Fields("MHSIPPremium")
                        DirectCast(pdffield, TallComponents.PDF.Forms.Fields.TextField).Value = "$" & ds4.Tables(0).Rows(0).Item("StandFees").ToString().Replace("$", "") - 20
                        If ds4.Tables(0).Rows(0).Item("StandCreditPerc").ToString().Replace("$", "") > "0" Then
                            pdffield = myPDFFields.Fields("MHFeeDesc2")
                            DirectCast(pdffield, TallComponents.PDF.Forms.Fields.TextField).Value = "Credit Percentage " & CDbl(ds4.Tables(0).Rows(0).Item("StandCreditPerc").ToString().Replace("$", "")) * 100 & " %"
                            pdffield = myPDFFields.Fields("MHFeeAmount2")
                            DirectCast(pdffield, TallComponents.PDF.Forms.Fields.TextField).Value = "($-" & ds4.Tables(0).Rows(0).Item("StandCreditamt").ToString().Replace("$", "") & ")"

                        End If
                    Else
                        pdffield = myPDFFields.Fields("MHSIPDesc")
                        DirectCast(pdffield, TallComponents.PDF.Forms.Fields.TextField).Value = " Policy Fee"
                        pdffield = myPDFFields.Fields("MHSIPPremium")
                        DirectCast(pdffield, TallComponents.PDF.Forms.Fields.TextField).Value = "$" & ds4.Tables(0).Rows(0).Item("StandFees").ToString().Replace("$", "")

                        If ds4.Tables(0).Rows(0).Item("StandCreditPerc").ToString().Replace("$", "") > "0" Then
                            pdffield = myPDFFields.Fields("MHFeeDesc2")
                            DirectCast(pdffield, TallComponents.PDF.Forms.Fields.TextField).Value = "Credit Percentage " & CDbl(ds4.Tables(0).Rows(0).Item("StandCreditPerc").ToString().Replace("$", "")) * 100 & " %"
                            pdffield = myPDFFields.Fields("MHFeeAmount2")
                            DirectCast(pdffield, TallComponents.PDF.Forms.Fields.TextField).Value = "($-" & ds4.Tables(0).Rows(0).Item("StandCreditamt").ToString().Replace("$", "") & ")"

                        End If

                    End If
                    If ds4.Tables(0).Rows(0).Item("StandMHReplace").ToString().Replace("$", "") = "Yes" Then
                        pdffield = myPDFFields.Fields("MHRepCostDesc")
                        DirectCast(pdffield, TallComponents.PDF.Forms.Fields.TextField).Value = "Replacement Cost for Mobile Home"
                        pdffield = myPDFFields.Fields("MHRepCostPremium")
                        DirectCast(pdffield, TallComponents.PDF.Forms.Fields.TextField).Value = "$" & ds4.Tables(0).Rows(0).Item("StandMHReplacePrem").ToString().Replace("$", "")

                    End If
                    If ds4.Tables(0).Rows(0).Item("StandContPrem").ToString().Replace("$", "") > "0" Then
                        pdffield = myPDFFields.Fields("MobileHomePersonalProp")
                        DirectCast(pdffield, TallComponents.PDF.Forms.Fields.TextField).Value = "Contents"
                        pdffield = myPDFFields.Fields("MHPerPropLimit")
                        DirectCast(pdffield, TallComponents.PDF.Forms.Fields.TextField).Value = "$" & ds4.Tables(0).Rows(0).Item("StandCont").ToString().Replace("$", "")
                        pdffield = myPDFFields.Fields("MHPerPropPremium")
                        DirectCast(pdffield, TallComponents.PDF.Forms.Fields.TextField).Value = "$" & ds4.Tables(0).Rows(0).Item("StandContPrem").ToString().Replace("$", "")

                    End If

                    If ds4.Tables(0).Rows(0).Item("StandStruc").ToString().Replace("$", "") <> "0.00" Then
                        pdffield = myPDFFields.Fields("MHAddStrucDesc")
                        DirectCast(pdffield, TallComponents.PDF.Forms.Fields.TextField).Value = "Other Structures"
                        pdffield = myPDFFields.Fields("MHAddStrucLimit")
                        DirectCast(pdffield, TallComponents.PDF.Forms.Fields.TextField).Value = "$" & ds4.Tables(0).Rows(0).Item("StandStruc").ToString().Replace("$", "")
                        pdffield = myPDFFields.Fields("MHAddStrucPremium")
                        DirectCast(pdffield, TallComponents.PDF.Forms.Fields.TextField).Value = "$" & ds4.Tables(0).Rows(0).Item("StandStrucPrem").ToString().Replace("$", "")

                    End If
                    If ds4.Tables(0).Rows(0).Item("StandPerLiab").ToString().Replace("$", "") <> "0" Then
                        pdffield = myPDFFields.Fields("MHPerLiabDesc")
                        DirectCast(pdffield, TallComponents.PDF.Forms.Fields.TextField).Value = "Personal Liability"
                        pdffield = myPDFFields.Fields("MHPerLiabLimit")
                        DirectCast(pdffield, TallComponents.PDF.Forms.Fields.TextField).Value = "$" & ds4.Tables(0).Rows(0).Item("StandPerLiab").ToString().Replace("$", "").Replace(",", "")
                        pdffield = myPDFFields.Fields("MHPerLiabPremium")
                        DirectCast(pdffield, TallComponents.PDF.Forms.Fields.TextField).Value = "$" & ds4.Tables(0).Rows(0).Item("StandPersLiabPrem").ToString().Replace("$", "")

                    End If


                    If ds4.Tables(0).Rows(0).Item("StandFullRepair").ToString().Replace("$", "") = "Yes" Then
                        pdffield = myPDFFields.Fields("MHFireDesc")
                        DirectCast(pdffield, TallComponents.PDF.Forms.Fields.TextField).Value = "Full Repair"
                        'pdffield = myPDFFields.Fields("MHContentsLimit")
                        'DirectCast(pdffield, TallComponents.PDF.Forms.Fields.TextField).Value = "$" & ds4.Tables(0).Rows(0).Item("StandPerLiab").ToString().Replace("$", "")
                        pdffield = myPDFFields.Fields("MHFirePremium")
                        DirectCast(pdffield, TallComponents.PDF.Forms.Fields.TextField).Value = "$" & ds4.Tables(0).Rows(0).Item("StandFullRepairPrem").ToString().Replace("$", "")

                    End If


                    pdffield = myPDFFields.Fields("MHNDDesc")
                    DirectCast(pdffield, TallComponents.PDF.Forms.Fields.TextField).Value = "Tax"
                    pdffield = myPDFFields.Fields("MHNDPremium")
                    DirectCast(pdffield, TallComponents.PDF.Forms.Fields.TextField).Value = "$" & ds4.Tables(0).Rows(0).Item("StandTax").ToString().Replace("$", "")
                    If ds4.Tables(0).Rows(0).Item("StandMedPay").ToString().Replace("$", "") > "0.00" Then
                        pdffield = myPDFFields.Fields("MHMedPayDesc")
                        DirectCast(pdffield, TallComponents.PDF.Forms.Fields.TextField).Value = "Medical Payments"
                        pdffield = myPDFFields.Fields("MHMedPayLimit")
                        DirectCast(pdffield, TallComponents.PDF.Forms.Fields.TextField).Value = "$" & ds4.Tables(0).Rows(0).Item("StandMedPay").ToString().Replace("$", "")
                        pdffield = myPDFFields.Fields("MHMedPayPremium")
                        DirectCast(pdffield, TallComponents.PDF.Forms.Fields.TextField).Value = "$" & ds4.Tables(0).Rows(0).Item("StandMedPrem").ToString().Replace("$", "")

                    End If
                Case "Rental"
                    pdffield = myPDFFields.Fields("MHDwellLimit")
                    DirectCast(pdffield, TallComponents.PDF.Forms.Fields.TextField).Value = CInt(ds4.Tables(0).Rows(0).Item("RentDwel").ToString())

                    'pdffield = myPDFFields.Fields("MHPerPropLimit")
                    'DirectCast(pdffield, TallComponents.PDF.Forms.Fields.TextField).Value = CInt(ds4.Tables(0).Rows(0).Item("RentCont").ToString())


                    pdffield = myPDFFields.Fields("MHDwellPremium")
                    DirectCast(pdffield, TallComponents.PDF.Forms.Fields.TextField).Value = CInt(ds4.Tables(0).Rows(0).Item("Rentprem").ToString()) '- CInt(ds3.Tables(0).Rows(0).Item("RentHur").ToString()) - CInt(ds3.Tables(0).Rows(0).Item("RentNonHur").ToString())
                    ' RentardTotal += CInt(ds4.Tables(0).Rows(0).Item("RentBasePrem").ToString()) ' - CInt(ds3.Tables(0).Rows(0).Item("RentHur").ToString()) - CInt(ds3.Tables(0).Rows(0).Item("RentNonHur").ToString())
                    If IsNumeric(ds4.Tables(0).Rows(0).Item("RentAOP").ToString().Replace("$", "")) Then

                        If CInt(ds4.Tables(0).Rows(0).Item("RentAOP").ToString().Replace("$", "")) > 500 Then
                            pdffield = myPDFFields.Fields("MHDedDesc")
                            DirectCast(pdffield, TallComponents.PDF.Forms.Fields.TextField).Value = "Deductible Change Option AOP"
                            pdffield = myPDFFields.Fields("MHDedPremium")
                            DirectCast(pdffield, TallComponents.PDF.Forms.Fields.TextField).Value = "($" & CInt(ds4.Tables(0).Rows(0).Item("RentAOPPrem").ToString()) & ")"
                            pdffield = myPDFFields.Fields("MHDedLimit")
                            DirectCast(pdffield, TallComponents.PDF.Forms.Fields.TextField).Value = "$" & ds4.Tables(0).Rows(0).Item("RentAOP").ToString().Replace("$", "")

                        Else
                            pdffield = myPDFFields.Fields("MHDedLimit")
                            DirectCast(pdffield, TallComponents.PDF.Forms.Fields.TextField).Value = "$" & ds4.Tables(0).Rows(0).Item("RentAOP").ToString().Replace("$", "")

                            pdffield = myPDFFields.Fields("MHDedDesc")
                            DirectCast(pdffield, TallComponents.PDF.Forms.Fields.TextField).Value = "AOP Deductible"
                        End If


                    End If
                   
                    ' RentTotal -= CInt(ds3.Tables(0).Rows(0).Item("RentNonHur").ToString())


                    pdffield = myPDFFields.Fields("MHPropRepDesc")
                    DirectCast(pdffield, TallComponents.PDF.Forms.Fields.TextField).Value = "Wind Hail Deductible:"

                    pdffield = myPDFFields.Fields("MHPropRepPremiumLimit")
                    DirectCast(pdffield, TallComponents.PDF.Forms.Fields.TextField).Value = ds4.Tables(0).Rows(0).Item("RentWind").ToString().Replace("$", "")
                    'pdffield = myPDFFields.Fields("MHPropRepPremium")
                    'DirectCast(pdffield, TallComponents.PDF.Forms.Fields.TextField).Value = "($" & CInt(ds3.Tables(0).Rows(0).Item("RentHur").ToString().Replace("$", "")) & ")"

                    pdffield = myPDFFields.Fields("Total Quoted Premium")
                    DirectCast(pdffield, TallComponents.PDF.Forms.Fields.TextField).Value = "$" & ds4.Tables(0).Rows(0).Item("Renttotal").ToString().Replace("$", "")

                    If ds4.Tables(0).Rows(0).Item("RentContReplacePrem").ToString().Replace("$", "") <> "0" Then

                        pdffield = myPDFFields.Fields("MHContentsdesc")
                        DirectCast(pdffield, TallComponents.PDF.Forms.Fields.TextField).Value = "Contents Replacement Cost"

                        pdffield = myPDFFields.Fields("MHContentsPremium")
                        DirectCast(pdffield, TallComponents.PDF.Forms.Fields.TextField).Value = ds4.Tables(0).Rows(0).Item("RentContReplacePrem").ToString().Replace("$", "")

                    End If
                    If ds.Tables(0).Rows(0).Item("homeUse").ToString() = "Seasonal" Then
                        pdffield = myPDFFields.Fields("MHFeeDesc1")
                        DirectCast(pdffield, TallComponents.PDF.Forms.Fields.TextField).Value = "Seasonal Surcharge"
                        pdffield = myPDFFields.Fields("MHFeeAmount1")
                        DirectCast(pdffield, TallComponents.PDF.Forms.Fields.TextField).Value = "$20"
                        pdffield = myPDFFields.Fields("MHSIPDesc")
                        DirectCast(pdffield, TallComponents.PDF.Forms.Fields.TextField).Value = "Policy Fee"
                        pdffield = myPDFFields.Fields("MHSIPPremium")
                        DirectCast(pdffield, TallComponents.PDF.Forms.Fields.TextField).Value = "$" & ds4.Tables(0).Rows(0).Item("RentFees").ToString().Replace("$", "") - 20
                        'If ds4.Tables(0).Rows(0).Item("RentCreditPerc").ToString().Replace("$", "") > "0" Then
                        '    pdffield = myPDFFields.Fields("MHFeeDesc2")
                        '    DirectCast(pdffield, TallComponents.PDF.Forms.Fields.TextField).Value = "Credit Percentage " & CDbl(ds4.Tables(0).Rows(0).Item("RentCreditPerc").ToString().Replace("$", "")) * 100 & " %"
                        '    pdffield = myPDFFields.Fields("MHFeeAmount2")
                        '    DirectCast(pdffield, TallComponents.PDF.Forms.Fields.TextField).Value = "($-" & ds4.Tables(0).Rows(0).Item("RentCreditamt").ToString().Replace("$", "") & ")"

                        'End If
                    Else
                        pdffield = myPDFFields.Fields("MHSIPDesc")
                        DirectCast(pdffield, TallComponents.PDF.Forms.Fields.TextField).Value = " Policy Fee"
                        pdffield = myPDFFields.Fields("MHSIPPremium")
                        DirectCast(pdffield, TallComponents.PDF.Forms.Fields.TextField).Value = "$" & ds4.Tables(0).Rows(0).Item("RentFees").ToString().Replace("$", "")

                        'If ds4.Tables(0).Rows(0).Item("RentCreditPerc").ToString().Replace("$", "") > "0" Then
                        '    pdffield = myPDFFields.Fields("MHFeeDesc2")
                        '    DirectCast(pdffield, TallComponents.PDF.Forms.Fields.TextField).Value = "Credit Percentage " & CDbl(ds4.Tables(0).Rows(0).Item("RentCreditPerc").ToString().Replace("$", "")) * 100 & " %"
                        '    pdffield = myPDFFields.Fields("MHFeeAmount2")
                        '    DirectCast(pdffield, TallComponents.PDF.Forms.Fields.TextField).Value = "($-" & ds4.Tables(0).Rows(0).Item("RentCreditamt").ToString().Replace("$", "") & ")"

                        'End If

                    End If
                    If ds4.Tables(0).Rows(0).Item("RentMHReplace").ToString().Replace("$", "") = "Yes" Then
                        pdffield = myPDFFields.Fields("MHRepCostDesc")
                        DirectCast(pdffield, TallComponents.PDF.Forms.Fields.TextField).Value = "Replacement Cost for Mobile Home"
                        pdffield = myPDFFields.Fields("MHRepCostPremium")
                        DirectCast(pdffield, TallComponents.PDF.Forms.Fields.TextField).Value = "$" & ds4.Tables(0).Rows(0).Item("RentMHReplacePrem").ToString().Replace("$", "")

                    End If
                    If ds4.Tables(0).Rows(0).Item("RentContPrem").ToString().Replace("$", "") > "0" Then
                        pdffield = myPDFFields.Fields("MobileHomePersonalProp")
                        DirectCast(pdffield, TallComponents.PDF.Forms.Fields.TextField).Value = "Contents"
                        pdffield = myPDFFields.Fields("MHPerPropLimit")
                        DirectCast(pdffield, TallComponents.PDF.Forms.Fields.TextField).Value = "$" & ds4.Tables(0).Rows(0).Item("RentCont").ToString().Replace("$", "")
                        pdffield = myPDFFields.Fields("MHPerPropPremium")
                        DirectCast(pdffield, TallComponents.PDF.Forms.Fields.TextField).Value = "$" & ds4.Tables(0).Rows(0).Item("RentContPrem").ToString().Replace("$", "")

                    End If

                    If ds4.Tables(0).Rows(0).Item("RentStruc").ToString().Replace("$", "") <> "0.00" Then
                        pdffield = myPDFFields.Fields("MHAddStrucDesc")
                        DirectCast(pdffield, TallComponents.PDF.Forms.Fields.TextField).Value = "Other Structures"
                        pdffield = myPDFFields.Fields("MHAddStrucLimit")
                        DirectCast(pdffield, TallComponents.PDF.Forms.Fields.TextField).Value = "$" & ds4.Tables(0).Rows(0).Item("RentStruc").ToString().Replace("$", "")
                        pdffield = myPDFFields.Fields("MHAddStrucPremium")
                        DirectCast(pdffield, TallComponents.PDF.Forms.Fields.TextField).Value = "$" & ds4.Tables(0).Rows(0).Item("RentStrucPrem").ToString().Replace("$", "")

                    End If
                    If ds4.Tables(0).Rows(0).Item("RentPerLiab").ToString().Replace("$", "") <> "" Then
                        If ds4.Tables(0).Rows(0).Item("RentPerLiab").ToString().Replace("$", "") <> "0" Then
                            pdffield = myPDFFields.Fields("MHPerLiabDesc")
                            DirectCast(pdffield, TallComponents.PDF.Forms.Fields.TextField).Value = "Premises Liability"
                            pdffield = myPDFFields.Fields("MHPerLiabLimit")
                            DirectCast(pdffield, TallComponents.PDF.Forms.Fields.TextField).Value = "$" & ds4.Tables(0).Rows(0).Item("RentPerLiab").ToString().Replace("$", "").Replace(",", "")
                            pdffield = myPDFFields.Fields("MHPerLiabPremium")
                            DirectCast(pdffield, TallComponents.PDF.Forms.Fields.TextField).Value = "$" & ds4.Tables(0).Rows(0).Item("RentPersLiabPrem").ToString().Replace("$", "")

                        End If
                    End If

                    If ds4.Tables(0).Rows(0).Item("RentFullRepair").ToString().Replace("$", "") = "Yes" Then
                        pdffield = myPDFFields.Fields("MHFireDesc")
                        DirectCast(pdffield, TallComponents.PDF.Forms.Fields.TextField).Value = "Full Repair"
                        'pdffield = myPDFFields.Fields("MHContentsLimit")
                        'DirectCast(pdffield, TallComponents.PDF.Forms.Fields.TextField).Value = "$" & ds4.Tables(0).Rows(0).Item("RentPerLiab").ToString().Replace("$", "")
                        pdffield = myPDFFields.Fields("MHFirePremium")
                        DirectCast(pdffield, TallComponents.PDF.Forms.Fields.TextField).Value = "$" & ds4.Tables(0).Rows(0).Item("RentFullRepairPrem").ToString().Replace("$", "")

                    End If


                    pdffield = myPDFFields.Fields("MHNDDesc")
                    DirectCast(pdffield, TallComponents.PDF.Forms.Fields.TextField).Value = "Tax"
                    pdffield = myPDFFields.Fields("MHNDPremium")
                    DirectCast(pdffield, TallComponents.PDF.Forms.Fields.TextField).Value = "$" & ds4.Tables(0).Rows(0).Item("RentTax").ToString().Replace("$", "")
                Case "SMH Package"
                    pdffield = myPDFFields.Fields("MHAddResDesc")
                    DirectCast(pdffield, TallComponents.PDF.Forms.Fields.TextField).Value = "Loss of Use"

                    pdffield = myPDFFields.Fields("MHAddResLimit")
                    DirectCast(pdffield, TallComponents.PDF.Forms.Fields.TextField).Value = "1000"

                    pdffield = myPDFFields.Fields("MHDwellLimit")
                    DirectCast(pdffield, TallComponents.PDF.Forms.Fields.TextField).Value = CInt(ds4.Tables(0).Rows(0).Item("SMHPackDwel").ToString())

                    'pdffield = myPDFFields.Fields("MHPerPropLimit")
                    'DirectCast(pdffield, TallComponents.PDF.Forms.Fields.TextField).Value = CInt(ds4.Tables(0).Rows(0).Item("SMHPackCont").ToString())


                    pdffield = myPDFFields.Fields("MHDwellPremium")
                    DirectCast(pdffield, TallComponents.PDF.Forms.Fields.TextField).Value = CInt(ds4.Tables(0).Rows(0).Item("SMHPackprem").ToString()) '- CInt(ds3.Tables(0).Rows(0).Item("SMHPackHur").ToString()) - CInt(ds3.Tables(0).Rows(0).Item("SMHPackNonHur").ToString())
                    ' PackardTotal += CInt(ds4.Tables(0).Rows(0).Item("SMHPackBasePrem").ToString()) ' - CInt(ds3.Tables(0).Rows(0).Item("SMHPackHur").ToString()) - CInt(ds3.Tables(0).Rows(0).Item("SMHPackNonHur").ToString())
                    If CInt(ds4.Tables(0).Rows(0).Item("SMHPackAOP").ToString().Replace("$", "")) > 1000 Then
                        pdffield = myPDFFields.Fields("MHDedDesc")
                        DirectCast(pdffield, TallComponents.PDF.Forms.Fields.TextField).Value = "AOP Deductible" '"Deductible Change Option AOP"
                        pdffield = myPDFFields.Fields("MHDedPremium")
                        DirectCast(pdffield, TallComponents.PDF.Forms.Fields.TextField).Value = "($" & CInt(ds4.Tables(0).Rows(0).Item("SMHPackAOPPrem").ToString()) & ")"
                    Else
                        pdffield = myPDFFields.Fields("MHDedDesc")
                        DirectCast(pdffield, TallComponents.PDF.Forms.Fields.TextField).Value = "AOP Deductible"
                        pdffield = myPDFFields.Fields("MHDedPremium")
                        DirectCast(pdffield, TallComponents.PDF.Forms.Fields.TextField).Value = CInt(ds4.Tables(0).Rows(0).Item("SMHPackAOPPrem").ToString())
                    End If


                    pdffield = myPDFFields.Fields("MHDedLimit")
                    DirectCast(pdffield, TallComponents.PDF.Forms.Fields.TextField).Value = "$" & ds4.Tables(0).Rows(0).Item("SMHPackAOP").ToString().Replace("$", "")

                    ' PackTotal -= CInt(ds3.Tables(0).Rows(0).Item("SMHPackNonHur").ToString())


                    pdffield = myPDFFields.Fields("MHPropRepDesc")
                    DirectCast(pdffield, TallComponents.PDF.Forms.Fields.TextField).Value = "Wind Hail Deductible:"

                    pdffield = myPDFFields.Fields("MHPropRepPremiumLimit")
                    DirectCast(pdffield, TallComponents.PDF.Forms.Fields.TextField).Value = ds4.Tables(0).Rows(0).Item("SMHPackWind").ToString().Replace("$", "")
                    'pdffield = myPDFFields.Fields("MHPropRepPremium")
                    'DirectCast(pdffield, TallComponents.PDF.Forms.Fields.TextField).Value = "($" & CInt(ds3.Tables(0).Rows(0).Item("SMHPackHur").ToString().Replace("$", "")) & ")"

                    'Hurricane/Tropical Storm

                    pdffield = myPDFFields.Fields("MHRepCostDesc")
                    DirectCast(pdffield, TallComponents.PDF.Forms.Fields.TextField).Value = "Hurricane / Tropical Storm Deductible:"

                    pdffield = myPDFFields.Fields("MHPropCostPremlimit")
                    DirectCast(pdffield, TallComponents.PDF.Forms.Fields.TextField).Value = ds4.Tables(0).Rows(0).Item("SMHPackWind").ToString().Replace("$", "")
                    'Enhancement coverage
                    If IsNumeric(ds4.Tables(0).Rows(0).Item("SMHPackFullRepair").ToString().Replace("$", "")) Then


                        pdffield = myPDFFields.Fields("MHRadioDesc")
                        DirectCast(pdffield, TallComponents.PDF.Forms.Fields.TextField).Value = "Enhancement Coverage"

                        pdffield = myPDFFields.Fields("MHRadioLimit")
                        DirectCast(pdffield, TallComponents.PDF.Forms.Fields.TextField).Value = CInt(ds4.Tables(0).Rows(0).Item("SMHPackFullRepair").ToString().Replace("$", ""))

                        pdffield = myPDFFields.Fields("MHRadioPremium")
                        DirectCast(pdffield, TallComponents.PDF.Forms.Fields.TextField).Value = ds4.Tables(0).Rows(0).Item("SMHPackFullRepairPrem").ToString().Replace("$", "")

                    End If



                    pdffield = myPDFFields.Fields("Total Quoted Premium")
                    DirectCast(pdffield, TallComponents.PDF.Forms.Fields.TextField).Value = "$" & ds4.Tables(0).Rows(0).Item("SMHPacktotal").ToString().Replace("$", "")

                    If ds4.Tables(0).Rows(0).Item("SMHPackContReplacePrem").ToString().Replace("$", "") <> "0" Then

                        pdffield = myPDFFields.Fields("MHContentsdesc")
                        DirectCast(pdffield, TallComponents.PDF.Forms.Fields.TextField).Value = "Contents Replacement Cost"

                        pdffield = myPDFFields.Fields("MHContentsLimit")
                        DirectCast(pdffield, TallComponents.PDF.Forms.Fields.TextField).Value = ds4.Tables(0).Rows(0).Item("SMHPackCont").ToString().Replace("$", "")

                        pdffield = myPDFFields.Fields("MHContentsPremium")
                        DirectCast(pdffield, TallComponents.PDF.Forms.Fields.TextField).Value = ds4.Tables(0).Rows(0).Item("SMHPackContReplacePrem").ToString().Replace("$", "")

                    End If
                    'commented out per email from vickie on 10/15/2013
                    'If ds.Tables(0).Rows(0).Item("homeUse").ToString() = "Seasonal" Then
                    '    pdffield = myPDFFields.Fields("MHFeeDesc1")
                    '    DirectCast(pdffield, TallComponents.PDF.Forms.Fields.TextField).Value = "Seasonal Surcharge"
                    '    pdffield = myPDFFields.Fields("MHFeeAmount1")
                    '    DirectCast(pdffield, TallComponents.PDF.Forms.Fields.TextField).Value = "$20"
                    '    pdffield = myPDFFields.Fields("MHSIPDesc")
                    '    DirectCast(pdffield, TallComponents.PDF.Forms.Fields.TextField).Value = "Policy Fee"
                    '    pdffield = myPDFFields.Fields("MHSIPPremium")
                    '    DirectCast(pdffield, TallComponents.PDF.Forms.Fields.TextField).Value = "$" & ds4.Tables(0).Rows(0).Item("SMHPackFees").ToString().Replace("$", "") - 20
                    If ds4.Tables(0).Rows(0).Item("SMHPackCreditPerc").ToString().Replace("$", "") > "0" Then
                        pdffield = myPDFFields.Fields("MHFeeDesc2")
                        DirectCast(pdffield, TallComponents.PDF.Forms.Fields.TextField).Value = "Credit Percentage " & CDbl(ds4.Tables(0).Rows(0).Item("SMHPackCreditPerc").ToString().Replace("$", "")) * 100 & " %"
                        pdffield = myPDFFields.Fields("MHFeeAmount2")
                        DirectCast(pdffield, TallComponents.PDF.Forms.Fields.TextField).Value = "($-" & ds4.Tables(0).Rows(0).Item("SMHPackCreditamt").ToString().Replace("$", "") & ")"

                    End If
                    If CInt(ds4.Tables(0).Rows(0).Item("SMHPackFees").ToString().Replace("$", "")) > 0 Then
                        pdffield = myPDFFields.Fields("MHFeeDesc1")
                        DirectCast(pdffield, TallComponents.PDF.Forms.Fields.TextField).Value = "Certification Fee"
                        pdffield = myPDFFields.Fields("MHFeeAmount1")
                        DirectCast(pdffield, TallComponents.PDF.Forms.Fields.TextField).Value = "$" & ds4.Tables(0).Rows(0).Item("SMHPackFees").ToString().Replace("$", "") & ""

                    End If
                    'Else
                    '    pdffield = myPDFFields.Fields("MHSIPDesc")
                    '    DirectCast(pdffield, TallComponents.PDF.Forms.Fields.TextField).Value = " Policy Fee"
                    '    pdffield = myPDFFields.Fields("MHSIPPremium")
                    '    DirectCast(pdffield, TallComponents.PDF.Forms.Fields.TextField).Value = "$" & ds4.Tables(0).Rows(0).Item("SMHPackFees").ToString().Replace("$", "")

                    '    If ds4.Tables(0).Rows(0).Item("SMHPackCreditPerc").ToString().Replace("$", "") > "0" Then
                    '        pdffield = myPDFFields.Fields("MHFeeDesc2")
                    '        DirectCast(pdffield, TallComponents.PDF.Forms.Fields.TextField).Value = "Credit Percentage " & CDbl(ds4.Tables(0).Rows(0).Item("SMHPackCreditPerc").ToString().Replace("$", "")) * 100 & " %"
                    '        pdffield = myPDFFields.Fields("MHFeeAmount2")
                    '        DirectCast(pdffield, TallComponents.PDF.Forms.Fields.TextField).Value = "($-" & ds4.Tables(0).Rows(0).Item("SMHPackCreditamt").ToString().Replace("$", "") & ")"

                    '    End If

                    'End If
                    If ds4.Tables(0).Rows(0).Item("SMHPackMHReplace").ToString().Replace("$", "") = "Yes" Then
                        pdffield = myPDFFields.Fields("MHFireDesc")
                        DirectCast(pdffield, TallComponents.PDF.Forms.Fields.TextField).Value = "Replacement Cost for Mobile Home"
                        pdffield = myPDFFields.Fields("MHFirePremium")
                        DirectCast(pdffield, TallComponents.PDF.Forms.Fields.TextField).Value = "$" & ds4.Tables(0).Rows(0).Item("SMHPackMHReplacePrem").ToString().Replace("$", "")

                    End If
                    'If ds4.Tables(0).Rows(0).Item("SMHPackContPrem").ToString().Replace("$", "") > "0" Then
                    pdffield = myPDFFields.Fields("MobileHomePersonalProp")
                    DirectCast(pdffield, TallComponents.PDF.Forms.Fields.TextField).Value = "Contents"
                    pdffield = myPDFFields.Fields("MHPerPropLimit")
                    DirectCast(pdffield, TallComponents.PDF.Forms.Fields.TextField).Value = "$" & ds4.Tables(0).Rows(0).Item("SMHPackCont").ToString().Replace("$", "")
                    pdffield = myPDFFields.Fields("MHPerPropPremium")
                    DirectCast(pdffield, TallComponents.PDF.Forms.Fields.TextField).Value = "$" & ds4.Tables(0).Rows(0).Item("SMHPackContPrem").ToString().Replace("$", "")

                    'End If

                    If ds4.Tables(0).Rows(0).Item("SMHPackStruc").ToString().Replace("$", "") <> "0.00" Then
                        pdffield = myPDFFields.Fields("MHAddStrucDesc")
                        DirectCast(pdffield, TallComponents.PDF.Forms.Fields.TextField).Value = "Other Structures"
                        pdffield = myPDFFields.Fields("MHAddStrucLimit")
                        DirectCast(pdffield, TallComponents.PDF.Forms.Fields.TextField).Value = "$" & ds4.Tables(0).Rows(0).Item("SMHPackStruc").ToString().Replace("$", "")
                        pdffield = myPDFFields.Fields("MHAddStrucPremium")
                        DirectCast(pdffield, TallComponents.PDF.Forms.Fields.TextField).Value = "$" & ds4.Tables(0).Rows(0).Item("SMHPackStrucPrem").ToString().Replace("$", "")

                    End If
                    If ds.Tables(0).Rows(0).Item("state").ToString() = "SC" Then
                        If ds4.Tables(0).Rows(0).Item("SMHPackPerLiab").ToString().Replace("$", "") <> "0" Then
                            pdffield = myPDFFields.Fields("MHPerLiabDesc")
                            DirectCast(pdffield, TallComponents.PDF.Forms.Fields.TextField).Value = "Personal Liability"
                            pdffield = myPDFFields.Fields("MHPerLiabLimit")
                            DirectCast(pdffield, TallComponents.PDF.Forms.Fields.TextField).Value = "$" & ds4.Tables(0).Rows(0).Item("SMHPackPerLiab").ToString().Replace("$", "").Replace(",", "")
                            pdffield = myPDFFields.Fields("MHPerLiabPremium")
                            DirectCast(pdffield, TallComponents.PDF.Forms.Fields.TextField).Value = "$" & ds4.Tables(0).Rows(0).Item("SMHPackPersLiabPrem").ToString().Replace("$", "")
                            If ds4.Tables(0).Rows(0).Item("SMHPackMedPay").ToString().Replace("$", "") > "0.00" Then
                                pdffield = myPDFFields.Fields("MHMedPayDesc")
                                DirectCast(pdffield, TallComponents.PDF.Forms.Fields.TextField).Value = "Medical Payments"
                                pdffield = myPDFFields.Fields("MHMedPayLimit")
                                DirectCast(pdffield, TallComponents.PDF.Forms.Fields.TextField).Value = "$" & ds4.Tables(0).Rows(0).Item("SMHPackMedPay").ToString().Replace("$", "")
                                pdffield = myPDFFields.Fields("MHMedPayPremium")
                                DirectCast(pdffield, TallComponents.PDF.Forms.Fields.TextField).Value = "$" & ds4.Tables(0).Rows(0).Item("SMHPackMedPrem").ToString().Replace("$", "")

                            End If
                        End If
                    Else
                        ' If ds4.Tables(0).Rows(0).Item("SMHPackPerLiabPrem").ToString().Replace("$", "") <> "0" Then
                        pdffield = myPDFFields.Fields("MHPerLiabDesc")
                        DirectCast(pdffield, TallComponents.PDF.Forms.Fields.TextField).Value = "Personal Liability"
                        pdffield = myPDFFields.Fields("MHPerLiabLimit")
                        DirectCast(pdffield, TallComponents.PDF.Forms.Fields.TextField).Value = "$" & ds4.Tables(0).Rows(0).Item("SMHPackPerLiab").ToString().Replace("$", "").Replace(",", "")
                        pdffield = myPDFFields.Fields("MHPerLiabPremium")
                        DirectCast(pdffield, TallComponents.PDF.Forms.Fields.TextField).Value = "$" & ds4.Tables(0).Rows(0).Item("SMHPackPersLiabPrem").ToString().Replace("$", "")
                        If ds4.Tables(0).Rows(0).Item("SMHPackMedPay").ToString().Replace("$", "") > "0.00" Then
                            pdffield = myPDFFields.Fields("MHMedPayDesc")
                            DirectCast(pdffield, TallComponents.PDF.Forms.Fields.TextField).Value = "Medical Payments"
                            pdffield = myPDFFields.Fields("MHMedPayLimit")
                            DirectCast(pdffield, TallComponents.PDF.Forms.Fields.TextField).Value = "$" & ds4.Tables(0).Rows(0).Item("SMHPackMedPay").ToString().Replace("$", "")
                            pdffield = myPDFFields.Fields("MHMedPayPremium")
                            DirectCast(pdffield, TallComponents.PDF.Forms.Fields.TextField).Value = "$" & ds4.Tables(0).Rows(0).Item("SMHPackMedPrem").ToString().Replace("$", "")

                        End If
                        'End If
                    End If
                    'If ds4.Tables(0).Rows(0).Item("SMHPackPerLiab").ToString().Replace("$", "") <> "0" Then
                    '    pdffield = myPDFFields.Fields("MHPerLiabDesc")
                    '    DirectCast(pdffield, TallComponents.PDF.Forms.Fields.TextField).Value = "Personal Liability"
                    '    pdffield = myPDFFields.Fields("MHPerLiabLimit")
                    '    DirectCast(pdffield, TallComponents.PDF.Forms.Fields.TextField).Value = "$" & ds4.Tables(0).Rows(0).Item("SMHPackPerLiab").ToString().Replace("$", "").Replace(",", "")
                    '    pdffield = myPDFFields.Fields("MHPerLiabPremium")
                    '    DirectCast(pdffield, TallComponents.PDF.Forms.Fields.TextField).Value = "$" & ds4.Tables(0).Rows(0).Item("SMHPackPersLiabPrem").ToString().Replace("$", "")
                    '    If ds4.Tables(0).Rows(0).Item("SMHPackMedPay").ToString().Replace("$", "") > "0.00" Then
                    '        pdffield = myPDFFields.Fields("MHMedPayDesc")
                    '        DirectCast(pdffield, TallComponents.PDF.Forms.Fields.TextField).Value = "Medical Payments"
                    '        pdffield = myPDFFields.Fields("MHMedPayLimit")
                    '        DirectCast(pdffield, TallComponents.PDF.Forms.Fields.TextField).Value = "$" & ds4.Tables(0).Rows(0).Item("SMHPackMedPay").ToString().Replace("$", "")
                    '        pdffield = myPDFFields.Fields("MHMedPayPremium")
                    '        DirectCast(pdffield, TallComponents.PDF.Forms.Fields.TextField).Value = "$" & ds4.Tables(0).Rows(0).Item("SMHPackMedPrem").ToString().Replace("$", "")

                    '    End If
                    'End If


                    If ds4.Tables(0).Rows(0).Item("SMHPackFullRepair").ToString().Replace("$", "") = "Yes" Then
                        pdffield = myPDFFields.Fields("MHRadioDesc")
                        DirectCast(pdffield, TallComponents.PDF.Forms.Fields.TextField).Value = "Full Repair"
                        'pdffield = myPDFFields.Fields("MHContentsLimit")
                        'DirectCast(pdffield, TallComponents.PDF.Forms.Fields.TextField).Value = "$" & ds4.Tables(0).Rows(0).Item("SMHPackPerLiab").ToString().Replace("$", "")
                        pdffield = myPDFFields.Fields("MHRadioPremium")
                        DirectCast(pdffield, TallComponents.PDF.Forms.Fields.TextField).Value = "$" & ds4.Tables(0).Rows(0).Item("SMHPackFullRepairPrem").ToString().Replace("$", "")

                    End If


                    pdffield = myPDFFields.Fields("MHNDDesc")
                    DirectCast(pdffield, TallComponents.PDF.Forms.Fields.TextField).Value = "Tax"
                    pdffield = myPDFFields.Fields("MHNDPremium")
                    DirectCast(pdffield, TallComponents.PDF.Forms.Fields.TextField).Value = "$" & ds4.Tables(0).Rows(0).Item("SMHPackTax").ToString().Replace("$", "")
                    If ds4.Tables(0).Rows(0).Item("SMHPackMedPay").ToString().Replace("$", "") > "0.00" Then
                        pdffield = myPDFFields.Fields("MHMedPayDesc")
                        DirectCast(pdffield, TallComponents.PDF.Forms.Fields.TextField).Value = "Medical Payments"
                        pdffield = myPDFFields.Fields("MHMedPayLimit")
                        DirectCast(pdffield, TallComponents.PDF.Forms.Fields.TextField).Value = "$" & ds4.Tables(0).Rows(0).Item("SMHPackMedPay").ToString().Replace("$", "")
                        pdffield = myPDFFields.Fields("MHMedPayPremium")
                        DirectCast(pdffield, TallComponents.PDF.Forms.Fields.TextField).Value = "$" & ds4.Tables(0).Rows(0).Item("SMHPackMedPrem").ToString().Replace("$", "")

                    End If

            End Select

            'Dim Quotetotal As Integer
            'Quotetotal += PackTotal
            'If IsNumeric(dsRate.Tables(0).Rows(0).Item("PerPropPrem").ToString()) Then
            '    Quotetotal += CInt(dsRate.Tables(0).Rows(0).Item("PerPropPrem").ToString())
            'End If
            'If IsNumeric(dsRate.Tables(0).Rows(0).Item("AddStrucPrem").ToString()) Then
            '    Quotetotal += CInt(dsRate.Tables(0).Rows(0).Item("AddStrucPrem").ToString())
            'End If
            'If IsNumeric(dsRate.Tables(0).Rows(0).Item("LiabPrem").ToString()) Then
            '    Quotetotal += CInt(dsRate.Tables(0).Rows(0).Item("LiabPrem").ToString())
            'End If
            'If IsNumeric(dsRate.Tables(0).Rows(0).Item("FirePrem").ToString()) Then
            '    Quotetotal += CInt(dsRate.Tables(0).Rows(0).Item("FirePrem").ToString())
            'End If
            'If IsNumeric(dsRate.Tables(0).Rows(0).Item("RadioPrem").ToString()) Then
            '    Quotetotal += CInt(dsRate.Tables(0).Rows(0).Item("RadioPrem").ToString())
            'End If





            'Quotetotal += CInt(PackTotal * 0.01)
            'Quotetotal += CInt(PackTotal * 0.013)
            'Quotetotal += 25
            'Quotetotal += 2

            'pdffield = myPDFFields.Fields("Total Quoted Premium")
            'DirectCast(pdffield, TallComponents.PDF.Forms.Fields.TextField).Value = Quotetotal


            For Each field As TallComponents.PDF.Forms.Fields.Field In myPDFFields.Fields
                For Each widget As Widget In field.Widgets
                    widget.Persistency = WidgetPersistency.Flatten
                Next
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
    Public Sub printAegisQuote(ByVal ds As Data.DataSet, ByVal ds4 As Data.DataSet)


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

            Dim pdffield As TallComponents.PDF.Forms.Fields.Field
            pdffield = myPDFFields.Fields("QuoteNum")
            DirectCast(pdffield, TallComponents.PDF.Forms.Fields.TextField).Value = ds.Tables(0).Rows(0).Item("quoteID").ToString()

            pdffield = myPDFFields.Fields("QuoteTerm")
            DirectCast(pdffield, TallComponents.PDF.Forms.Fields.TextField).Value = ds.Tables(0).Rows(0).Item("term").ToString()


            pdffield = myPDFFields.Fields("QuoteNumdate")
            DirectCast(pdffield, TallComponents.PDF.Forms.Fields.TextField).Value = Date.Now.ToString("MM/dd/yyyy") 'ds.Tables(0).Rows(0).Item("quoteID").ToString()

            pdffield = myPDFFields.Fields("QuoteEffDate")
            DirectCast(pdffield, TallComponents.PDF.Forms.Fields.TextField).Value = ds.Tables(0).Rows(0).Item("effDate").ToString()

            pdffield = myPDFFields.Fields("QuoteCompany")
            DirectCast(pdffield, TallComponents.PDF.Forms.Fields.TextField).Value = "" & ds.Tables(0).Rows(0).Item("ARRateType").ToString()



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
                        value = ds.Tables(0).Rows(0).Item("AgentPhone").ToString()
                        DirectCast(myPDFField, TallComponents.PDF.Forms.Fields.TextField).Value = "(800) 628- 3762" 'value
                        'Client Section
                    Case "ClientName"
                        value = UCase(ds.Tables(0).Rows(0).Item("applicantFirstName").ToString()) + " " + UCase(ds.Tables(0).Rows(0).Item("applicantLastName").ToString())
                        DirectCast(myPDFField, TallComponents.PDF.Forms.Fields.TextField).Value = value
                    Case "ClientAddr1"
                        value = UCase(ds.Tables(0).Rows(0).Item("propAddress").ToString())
                        DirectCast(myPDFField, TallComponents.PDF.Forms.Fields.TextField).Value = value
                    Case "ClientAddr2"
                        value = ""
                        DirectCast(myPDFField, TallComponents.PDF.Forms.Fields.TextField).Value = value
                    Case "ClientCSZ"
                        value = ds.Tables(0).Rows(0).Item("city").ToString() + " " + ds.Tables(0).Rows(0).Item("state").ToString() + " " + ds.Tables(0).Rows(0).Item("zip").ToString()
                        DirectCast(myPDFField, TallComponents.PDF.Forms.Fields.TextField).Value = UCase(value)
                    Case "ClientPhone"
                        value = ""
                        DirectCast(myPDFField, TallComponents.PDF.Forms.Fields.TextField).Value = value
                        'Sub Information
                    Case "SubName"
                        value = ds.Tables(0).Rows(0).Item("AgencyName").ToString()
                        DirectCast(myPDFField, TallComponents.PDF.Forms.Fields.TextField).Value = UCase(value) & "     " & ds.Tables(0).Rows(0).Item("AgencyCode").ToString()

                    Case "SubAddr1"
                        value = ds.Tables(0).Rows(0).Item("AgentAddr1").ToString()
                        DirectCast(myPDFField, TallComponents.PDF.Forms.Fields.TextField).Value = UCase(value)
                    Case "SubAddr2"
                        value = UCase(ds.Tables(0).Rows(0).Item("AgentAddr2").ToString())
                        DirectCast(myPDFField, TallComponents.PDF.Forms.Fields.TextField).Value = value
                    Case "SubCSZ"
                        value = ds.Tables(0).Rows(0).Item("AgentCity").ToString() & ", " & ds.Tables(0).Rows(0).Item("AgentState").ToString() & " " & ds.Tables(0).Rows(0).Item("AgentZip").ToString()
                        DirectCast(myPDFField, TallComponents.PDF.Forms.Fields.TextField).Value = UCase(value)
                    Case "SubPhone"
                        value = ds.Tables(0).Rows(0).Item("AgentPhone").ToString()
                        DirectCast(myPDFField, TallComponents.PDF.Forms.Fields.TextField).Value = UCase(value)


                        'Unit Information
                    Case "Year"
                        value = ds.Tables(0).Rows(0).Item("year").ToString()
                        DirectCast(myPDFField, TallComponents.PDF.Forms.Fields.TextField).Value = value
                    Case "Model"
                        value = ds.Tables(0).Rows(0).Item("homeType").ToString()
                        DirectCast(myPDFField, TallComponents.PDF.Forms.Fields.TextField).Value = UCase(value)
                    Case "Length"
                        value = ds.Tables(0).Rows(0).Item("length").ToString()
                        DirectCast(myPDFField, TallComponents.PDF.Forms.Fields.TextField).Value = value
                    Case "Value"
                        value = ds4.Tables(0).Rows(0).Item("PackDwel").ToString()
                        DirectCast(myPDFField, TallComponents.PDF.Forms.Fields.TextField).Value = value
                    Case "Make"
                        value = ds.Tables(0).Rows(0).Item("manf").ToString()
                        DirectCast(myPDFField, TallComponents.PDF.Forms.Fields.TextField).Value = UCase(value)
                    Case "RatingState"
                        value = ds.Tables(0).Rows(0).Item("state").ToString()
                        DirectCast(myPDFField, TallComponents.PDF.Forms.Fields.TextField).Value = UCase(value)
                    Case "Width"
                        value = ds.Tables(0).Rows(0).Item("width").ToString()
                        DirectCast(myPDFField, TallComponents.PDF.Forms.Fields.TextField).Value = value
                    Case "UseOfUnit"
                        value = ds.Tables(0).Rows(0).Item("homeUse").ToString()
                        DirectCast(myPDFField, TallComponents.PDF.Forms.Fields.TextField).Value = UCase(value)

                    Case "MobileHomeDesc"
                        value = "Mobile Home"
                        DirectCast(myPDFField, TallComponents.PDF.Forms.Fields.TextField).Value = value
                        'Case "MHDwellLimit"
                        '    value = ds2.Tables(0).Rows(0).Item("StandDwel").ToString()
                        '    DirectCast(myPDFField, TallComponents.PDF.Forms.Fields.TextField).Value = CInt(value)
                        'Case "MHDwellPremium"
                        '    value = FormatCurrency(dsRate.Tables(0).Rows(0).Item("DwellingPrem").ToString())
                        '    DirectCast(myPDFField, TallComponents.PDF.Forms.Fields.TextField).Value = String.Format("{0:C0}", Math.Round(CDbl(value.Replace("$", ""))))

                        'Case "MobileHomePersonalProp"
                        '    'value = "Personal Property"
                        '    value = "Contents"
                        '    DirectCast(myPDFField, TallComponents.PDF.Forms.Fields.TextField).Value = value
                        'Case "MHPerPropLimit"
                        '    value = dsRate.Tables(0).Rows(0).Item("PerPropLimit").ToString()
                        '    DirectCast(myPDFField, TallComponents.PDF.Forms.Fields.TextField).Value = CInt(value)
                        'Case "MHPerPropPremium"
                        '    If dsRate.Tables(0).Rows(0).Item("PerPropPrem") = "INCLUDED" Then
                        '        value = dsRate.Tables(0).Rows(0).Item("PerPropPrem").ToString()
                        '    Else
                        '        value = FormatCurrency(dsRate.Tables(0).Rows(0).Item("PerPropPrem").ToString())
                        '        value = String.Format("{0:C0}", Math.Round(CDbl(value.Replace("$", ""))))
                        '    End If

                        ' DirectCast(myPDFField, TallComponents.PDF.Forms.Fields.TextField).Value = value


                        'Case "MHAddStrucDesc"
                        '    ' value = "Adjacent Structures"
                        '    value = "Other Structures"
                        '    DirectCast(myPDFField, TallComponents.PDF.Forms.Fields.TextField).Value = value
                        'Case "MHAddStrucLimit"
                        '    value = dsrate.Tables(0).Rows(0).Item("AddStrucLimit").ToString()
                        '    DirectCast(myPDFField, TallComponents.PDF.Forms.Fields.TextField).Value = CInt(value)
                        'Case "MHAddStrucPremium"
                        '    If dsrate.Tables(0).Rows(0).Item("AddStrucPrem").ToString() = "INCLUDED" Then
                        '        value = dsrate.Tables(0).Rows(0).Item("AddStrucPrem").ToString()
                        '    Else
                        '        value = FormatCurrency(dsrate.Tables(0).Rows(0).Item("AddStrucPrem").ToString())
                        '        value = String.Format("{0:C0}", Math.Round(CDbl(value.Replace("$", ""))))
                        '    End If
                        '    DirectCast(myPDFField, TallComponents.PDF.Forms.Fields.TextField).Value = value

                        'Case "MHPerLiabDesc"
                        '    value = "Personal Liability"
                        '    DirectCast(myPDFField, TallComponents.PDF.Forms.Fields.TextField).Value = value.Replace("$", "")
                        '    'Case "MHPerLiabLimit"
                        '    value = dsrate.Tables(0).Rows(0).Item("LiabLimit").ToString()
                        '    DirectCast(myPDFField, TallComponents.PDF.Forms.Fields.TextField).Value = value.Replace("$", "")
                        'Case "MHPerLiabPremium"
                        '    value = FormatCurrency(dsrate.Tables(0).Rows(0).Item("LiabPrem").ToString())
                        '    DirectCast(myPDFField, TallComponents.PDF.Forms.Fields.TextField).Value = String.Format("{0:C0}", Math.Round(CDbl(value.Replace("$", ""))))

                        'Case "MHDedDesc"
                        '    value = "Deductible Change Option"
                        '    DirectCast(myPDFField, TallComponents.PDF.Forms.Fields.TextField).Value = value
                        'Case "MHDedPremium"
                        '    value = FormatCurrency(dsRate.Tables(0).Rows(0).Item("DedPrem").ToString())
                        '    DirectCast(myPDFField, TallComponents.PDF.Forms.Fields.TextField).Value = String.Format("{0:C0}", Math.Round(CDbl(value)))

                        'Case "MHPropRepDesc"
                        '    value = dsrate.Tables(0).Rows(0).Item("PerPropRepPrem").ToString()
                        '    If value = "" Then
                        '        value = ""
                        '    Else
                        '        value = "Contents Replacement Cost"
                        '    End If
                        '    DirectCast(myPDFField, TallComponents.PDF.Forms.Fields.TextField).Value = value.Replace("$", "")
                        'Case "MHPropRepPremium"
                        '    value = dsrate.Tables(0).Rows(0).Item("PerPropRepPrem").ToString()
                        '    If value = "" Then
                        '        value = ""
                        '    Else
                        '        value = FormatCurrency(dsrate.Tables(0).Rows(0).Item("PerPropRepPrem").ToString())
                        '        value = String.Format("{0:C0}", Math.Round(CDbl(value.Replace("$", ""))))
                        '    End If
                        '    DirectCast(myPDFField, TallComponents.PDF.Forms.Fields.TextField).Value = value.Replace("$", "")

                        'Case "MHRepCostDesc"
                        '    value = dsrate.Tables(0).Rows(0).Item("MHRepPrem").ToString()
                        '    If value = "" Then
                        '        value = ""
                        '    Else
                        '        value = "Replacement Cost for Mobile Home"
                        '    End If
                        '    DirectCast(myPDFField, TallComponents.PDF.Forms.Fields.TextField).Value = value
                        'Case "MHRepCostPremium"
                        '    value = dsrate.Tables(0).Rows(0).Item("MHRepPrem").ToString()
                        '    If value = "" Then
                        '        value = ""
                        '    Else
                        '        value = FormatCurrency(dsrate.Tables(0).Rows(0).Item("MHRepPrem").ToString())
                        '    End If
                        '    DirectCast(myPDFField, TallComponents.PDF.Forms.Fields.TextField).Value = value.Replace("$", "")

                        'Case "MHFireDesc"
                        '    value = dsrate.Tables(0).Rows(0).Item("FirePrem").ToString()
                        '    If value = "" Then
                        '        value = ""
                        '    Else
                        '        value = "Fire Department Service Charge"
                        '    End If
                        '    DirectCast(myPDFField, TallComponents.PDF.Forms.Fields.TextField).Value = value.Replace("$", "")
                        'Case "MHFireLimit"
                        '    value = dsrate.Tables(0).Rows(0).Item("FirePrem").ToString()
                        '    If value = "" Then
                        '        value = ""
                        '    Else
                        '        value = FormatCurrency(dsrate.Tables(0).Rows(0).Item("FireOpt").ToString())
                        '    End If
                        '    DirectCast(myPDFField, TallComponents.PDF.Forms.Fields.TextField).Value = value.Replace("$", "")
                        'Case "MHFirePremium"
                        '    value = dsrate.Tables(0).Rows(0).Item("FirePrem").ToString()
                        '    If value = "" Then
                        '        value = ""
                        '    Else
                        '        value = FormatCurrency(dsrate.Tables(0).Rows(0).Item("FirePrem").ToString())
                        '    End If
                        '    DirectCast(myPDFField, TallComponents.PDF.Forms.Fields.TextField).Value = value.Replace("$", "")
                        '    '    'Radio
                        'Case "MHRadioDesc"
                        '    value = dsrate.Tables(0).Rows(0).Item("RadioPrem").ToString()
                        '    If value = "" Then
                        '        value = ""
                        '    Else
                        '        value = "Radio & T.V. Charge"
                        '    End If
                        '    DirectCast(myPDFField, TallComponents.PDF.Forms.Fields.TextField).Value = value.Replace("$", "")
                        'Case "MHRadioLimit"
                        '    value = dsrate.Tables(0).Rows(0).Item("RadioPrem").ToString()
                        '    If value = "" Then
                        '        value = ""
                        '    Else
                        '        value = FormatCurrency(dsrate.Tables(0).Rows(0).Item("RadioOpt").ToString())
                        '    End If

                        '    DirectCast(myPDFField, TallComponents.PDF.Forms.Fields.TextField).Value = value.Replace("$", "")

                        'Case "MHRadioPremium"
                        '    value = dsrate.Tables(0).Rows(0).Item("RadioPrem").ToString()
                        '    If value = "" Then
                        '        value = ""
                        '    Else
                        '        value = FormatCurrency(dsrate.Tables(0).Rows(0).Item("RadioPrem").ToString())
                        '    End If
                        '    DirectCast(myPDFField, TallComponents.PDF.Forms.Fields.TextField).Value = value.Replace("$", "")
                        'Case "MHMedPayDesc"
                        '    value = dsrate.Tables(0).Rows(0).Item("MedPayOpt").ToString()
                        '    If value = "" Then
                        '        value = ""
                        '    Else
                        '        value = "Medical Payments"
                        '    End If

                        '    DirectCast(myPDFField, TallComponents.PDF.Forms.Fields.TextField).Value = value.Replace("$", "")
                        'Case "MHMedPayLimit"
                        '    value = dsrate.Tables(0).Rows(0).Item("MedPayOpt").ToString()
                        '    If value = "" Then
                        '        value = ""
                        '    Else
                        '        value = dsrate.Tables(0).Rows(0).Item("MedPayOpt").ToString()
                        '    End If
                        '    DirectCast(myPDFField, TallComponents.PDF.Forms.Fields.TextField).Value = "$" & value.Replace("$", "")

                        '    If dsrate.Tables(0).Rows(0).Item("MedPayOpt").ToString() = "$1000" Then
                        '        pdffield = myPDFFields.Fields("MHMedPayPremium")
                        '        DirectCast(pdffield, TallComponents.PDF.Forms.Fields.TextField).Value = "$5".Replace("$", "")


                        '    End If

                        'Case "MHRepCostDesc"
                        '    value = dsrate.Tables(0).Rows(0).Item("MedMHRepPrem").ToString()
                        '    If value = "" Then
                        '        value = ""
                        '    Else
                        '        value = "Mobile Home Replacement Cost"
                        '    End If
                        '    DirectCast(myPDFField, TallComponents.PDF.Forms.Fields.TextField).Value = value.Replace("$", "")

                        'Case "MHRepCostPrem"
                        '    value = dsrate.Tables(0).Rows(0).Item("MedMHRepPrem").ToString()
                        '    If value = "" Then
                        '        value = ""
                        '    Else
                        '        value = FormatCurrency(dsrate.Tables(0).Rows(0).Item("MedMHRepPrem").ToString())
                        '    End If
                        '    DirectCast(myPDFField, TallComponents.PDF.Forms.Fields.TextField).Value = value.Replace("$", "")
                        '    '    'Replacement Cost
                        'Case "MHPropRepDesc"
                        '    value = dsrate.Tables(0).Rows(0).Item("MedRepPrem").ToString()
                        '    If value = "" Then
                        '        value = ""
                        '    Else
                        '        value = "Contents Replacement Cost"
                        '    End If
                        '    DirectCast(myPDFField, TallComponents.PDF.Forms.Fields.TextField).Value = value.Replace("$", "")

                        'Case "MHPropRepPrem"
                        '    value = dsrate.Tables(0).Rows(0).Item("MedRepPrem").ToString()
                        '    If value = "" Then
                        '        value = ""
                        '    Else
                        '        value = FormatCurrency(dsrate.Tables(0).Rows(0).Item("MedMHRepPrem").ToString())
                        '    End If
                        '    DirectCast(myPDFField, TallComponents.PDF.Forms.Fields.TextField).Value = value.Replace("$", "")




                        'Case "MHFeeDesc"
                        '    value = "Fees"
                        '    DirectCast(myPDFField, TallComponents.PDF.Forms.Fields.TextField).Value = value
                        'Case "MHFeeAmount"
                        '    value = FormatCurrency(dsrate.Tables(0).Rows(0).Item("Fees").ToString())
                        '    DirectCast(myPDFField, TallComponents.PDF.Forms.Fields.TextField).Value = value

                        '    'Fire Department Service Charge

                End Select


            Next
            Dim PackTotal As Integer

            Select Case ds.Tables(0).Rows(0).Item("ARRateType").ToString()
                Case "Aegis Standard"




                    'pdffield = myPDFFields.Fields("MHAddResDesc")
                    'DirectCast(pdffield, TallComponents.PDF.Forms.Fields.TextField).Value = "Loss of Use"

                    'pdffield = myPDFFields.Fields("MHAddResLimit")
                    'DirectCast(pdffield, TallComponents.PDF.Forms.Fields.TextField).Value = "600"
                    'pdffield = myPDFFields.Fields("MHDwellLimit")
                    'DirectCast(pdffield, TallComponents.PDF.Forms.Fields.TextField).Value = CInt(ds4.Tables(0).Rows(0).Item("PackDwel").ToString())

                    'pdffield = myPDFFields.Fields("MHPerPropLimit")
                    'DirectCast(pdffield, TallComponents.PDF.Forms.Fields.TextField).Value = CInt(ds4.Tables(0).Rows(0).Item("PackCont").ToString())


                    'pdffield = myPDFFields.Fields("MHDwellPremium")
                    'DirectCast(pdffield, TallComponents.PDF.Forms.Fields.TextField).Value = CInt(ds4.Tables(0).Rows(0).Item("Packprem").ToString()) '- CInt(ds3.Tables(0).Rows(0).Item("PackHur").ToString()) - CInt(ds3.Tables(0).Rows(0).Item("PackNonHur").ToString())
                    'PackTotal += CInt(ds4.Tables(0).Rows(0).Item("PackBasePrem").ToString()) ' - CInt(ds3.Tables(0).Rows(0).Item("PackHur").ToString()) - CInt(ds3.Tables(0).Rows(0).Item("PackNonHur").ToString())

                    'pdffield = myPDFFields.Fields("MHDedDesc")
                    'DirectCast(pdffield, TallComponents.PDF.Forms.Fields.TextField).Value = "Deductible Change Option AOP"

                    'pdffield = myPDFFields.Fields("MHDedLimit")
                    'DirectCast(pdffield, TallComponents.PDF.Forms.Fields.TextField).Value = "$" & ds4.Tables(0).Rows(0).Item("PackAOP").ToString().Replace("$", "")
                    'pdffield = myPDFFields.Fields("MHDedPremium")
                    'DirectCast(pdffield, TallComponents.PDF.Forms.Fields.TextField).Value = "($" & CInt(ds4.Tables(0).Rows(0).Item("PackAOPPrem").ToString()) & ")"
                    '' PackTotal -= CInt(ds3.Tables(0).Rows(0).Item("PackNonHur").ToString())
                    'pdffield = myPDFFields.Fields("MHPropRepDesc")
                    'DirectCast(pdffield, TallComponents.PDF.Forms.Fields.TextField).Value = "Wind Hail Deductible:"

                    'pdffield = myPDFFields.Fields("MHPropRepPremiumLimit")
                    'DirectCast(pdffield, TallComponents.PDF.Forms.Fields.TextField).Value = ds4.Tables(0).Rows(0).Item("PackWind").ToString().Replace("$", "")
                    ''pdffield = myPDFFields.Fields("MHPropRepPremium")
                    ''DirectCast(pdffield, TallComponents.PDF.Forms.Fields.TextField).Value = "($" & CInt(ds3.Tables(0).Rows(0).Item("PackHur").ToString().Replace("$", "")) & ")"

                    'pdffield = myPDFFields.Fields("Total Quoted Premium")
                    'DirectCast(pdffield, TallComponents.PDF.Forms.Fields.TextField).Value = "$" & ds4.Tables(0).Rows(0).Item("Packtotal").ToString().Replace("$", "")

                    'If ds4.Tables(0).Rows(0).Item("PackContReplacePrem").ToString() <> "$0.00" Then

                    '    pdffield = myPDFFields.Fields("MHContentsdesc")
                    '    DirectCast(pdffield, TallComponents.PDF.Forms.Fields.TextField).Value = "Contents Replacement Cost"

                    '    pdffield = myPDFFields.Fields("MHContentsPremium")
                    '    DirectCast(pdffield, TallComponents.PDF.Forms.Fields.TextField).Value = ds4.Tables(0).Rows(0).Item("PackContReplacePrem").ToString().Replace("$", "")

                    'End If
                    'pdffield = myPDFFields.Fields("MHFeeDesc")
                    'DirectCast(pdffield, TallComponents.PDF.Forms.Fields.TextField).Value = "Fee"
                    'pdffield = myPDFFields.Fields("MHFeeAmount")
                    'DirectCast(pdffield, TallComponents.PDF.Forms.Fields.TextField).Value = "$" & ds4.Tables(0).Rows(0).Item("PackFees").ToString().Replace("$", "")
                    'If ds.Tables(0).Rows(0).Item("homeUse").ToString() = "Seasonal" Then
                    '    pdffield = myPDFFields.Fields("MHFeeDesc1")
                    '    DirectCast(pdffield, TallComponents.PDF.Forms.Fields.TextField).Value = "Seasonal Fee"
                    '    pdffield = myPDFFields.Fields("MHFeeAmount1")
                    '    DirectCast(pdffield, TallComponents.PDF.Forms.Fields.TextField).Value = "$20"
                    'End If
                    'If ds4.Tables(0).Rows(0).Item("PackFees").ToString().Replace("$", "") = "Yes" Then
                    '    pdffield = myPDFFields.Fields("MHRepCostDesc")
                    '    DirectCast(pdffield, TallComponents.PDF.Forms.Fields.TextField).Value = "Replacement Cost for Mobile Home"
                    '    pdffield = myPDFFields.Fields("MHRepCostPremium")
                    '    DirectCast(pdffield, TallComponents.PDF.Forms.Fields.TextField).Value = "$" & ds4.Tables(0).Rows(0).Item("PackMHReplacePrem").ToString().Replace("$", "")

                    'End If
                    ''-----
                    'If ds4.Tables(0).Rows(0).Item("PackCont").ToString().Replace("$", "") = "0.00" Then
                    '    pdffield = myPDFFields.Fields("MobileHomePersonalProp")
                    '    DirectCast(pdffield, TallComponents.PDF.Forms.Fields.TextField).Value = "Contents"
                    '    pdffield = myPDFFields.Fields("MHPerPropLimit")
                    '    DirectCast(pdffield, TallComponents.PDF.Forms.Fields.TextField).Value = "$" & ds4.Tables(0).Rows(0).Item("PackCont").ToString().Replace("$", "")
                    '    pdffield = myPDFFields.Fields("MHPerPropPremium")
                    '    DirectCast(pdffield, TallComponents.PDF.Forms.Fields.TextField).Value = "$" & ds4.Tables(0).Rows(0).Item("PackContPrem").ToString().Replace("$", "")

                    'End If

                    'If ds4.Tables(0).Rows(0).Item("PackStruc").ToString().Replace("$", "") = "0.00" Then
                    '    pdffield = myPDFFields.Fields("MHAddStrucDesc")
                    '    DirectCast(pdffield, TallComponents.PDF.Forms.Fields.TextField).Value = "Other Structures"
                    '    pdffield = myPDFFields.Fields("MHAddStrucLimit")
                    '    DirectCast(pdffield, TallComponents.PDF.Forms.Fields.TextField).Value = "$" & ds4.Tables(0).Rows(0).Item("PackStruc").ToString().Replace("$", "")
                    '    pdffield = myPDFFields.Fields("MHAddStrucPremium")
                    '    DirectCast(pdffield, TallComponents.PDF.Forms.Fields.TextField).Value = "$" & ds4.Tables(0).Rows(0).Item("PackStrucPrem").ToString().Replace("$", "")

                    'End If
                    'If ds4.Tables(0).Rows(0).Item("PackPerLiab").ToString().Replace("$", "") = "0.00" Then
                    '    pdffield = myPDFFields.Fields(" MHPerLiabDesc")
                    '    DirectCast(pdffield, TallComponents.PDF.Forms.Fields.TextField).Value = "Personal Liability"
                    '    pdffield = myPDFFields.Fields("MHPerLiabLimit")
                    '    DirectCast(pdffield, TallComponents.PDF.Forms.Fields.TextField).Value = "$" & ds4.Tables(0).Rows(0).Item("PackPerLiab").ToString().Replace("$", "")
                    '    pdffield = myPDFFields.Fields("MHPerLiabPremium")
                    '    DirectCast(pdffield, TallComponents.PDF.Forms.Fields.TextField).Value = "$" & ds4.Tables(0).Rows(0).Item("PackPersLiabPrem").ToString().Replace("$", "")

                    'End If
                    'If ds4.Tables(0).Rows(0).Item("PackMedPay").ToString().Replace("$", "") > "0.00" Then
                    '    pdffield = myPDFFields.Fields("MHMedPayDesc")
                    '    DirectCast(pdffield, TallComponents.PDF.Forms.Fields.TextField).Value = "Medical Payments"
                    '    pdffield = myPDFFields.Fields("MHMedPayLimit")
                    '    DirectCast(pdffield, TallComponents.PDF.Forms.Fields.TextField).Value = "$" & ds4.Tables(0).Rows(0).Item("PackMedPay").ToString().Replace("$", "")
                    '    pdffield = myPDFFields.Fields("MHMedPayPremium")
                    '    DirectCast(pdffield, TallComponents.PDF.Forms.Fields.TextField).Value = "$" & ds4.Tables(0).Rows(0).Item("PackMedPrem").ToString().Replace("$", "")

                    'End If

                    pdffield = myPDFFields.Fields("MHDwellLimit")
                    DirectCast(pdffield, TallComponents.PDF.Forms.Fields.TextField).Value = CInt(ds4.Tables(0).Rows(0).Item("PackDwel").ToString())

                    'pdffield = myPDFFields.Fields("MHPerPropLimit")
                    'DirectCast(pdffield, TallComponents.PDF.Forms.Fields.TextField).Value = CInt(ds4.Tables(0).Rows(0).Item("PackCont").ToString())


                    pdffield = myPDFFields.Fields("MHDwellPremium")
                    DirectCast(pdffield, TallComponents.PDF.Forms.Fields.TextField).Value = CInt(ds4.Tables(0).Rows(0).Item("Packprem").ToString()) '- CInt(ds3.Tables(0).Rows(0).Item("PackHur").ToString()) - CInt(ds3.Tables(0).Rows(0).Item("PackNonHur").ToString())
                    ' PackardTotal += CInt(ds4.Tables(0).Rows(0).Item("PackBasePrem").ToString()) ' - CInt(ds3.Tables(0).Rows(0).Item("PackHur").ToString()) - CInt(ds3.Tables(0).Rows(0).Item("PackNonHur").ToString())
                    If CInt(ds4.Tables(0).Rows(0).Item("PackAOP").ToString().Replace("$", "")) > 500 Then
                        pdffield = myPDFFields.Fields("MHDedDesc")
                        DirectCast(pdffield, TallComponents.PDF.Forms.Fields.TextField).Value = "Deductible Change Option AOP"
                        pdffield = myPDFFields.Fields("MHDedPremium")
                        DirectCast(pdffield, TallComponents.PDF.Forms.Fields.TextField).Value = "($" & CInt(ds4.Tables(0).Rows(0).Item("PackAOPPrem").ToString()) & ")"
                    Else
                        pdffield = myPDFFields.Fields("MHDedDesc")
                        DirectCast(pdffield, TallComponents.PDF.Forms.Fields.TextField).Value = "AOP Deductible"
                    End If


                    pdffield = myPDFFields.Fields("MHDedLimit")
                    DirectCast(pdffield, TallComponents.PDF.Forms.Fields.TextField).Value = "$" & ds4.Tables(0).Rows(0).Item("PackAOP").ToString().Replace("$", "")

                    ' PackTotal -= CInt(ds3.Tables(0).Rows(0).Item("PackNonHur").ToString())


                    'pdffield = myPDFFields.Fields("MHPropRepDesc")
                    'DirectCast(pdffield, TallComponents.PDF.Forms.Fields.TextField).Value = "Wind Hail Deductible:"

                    'pdffield = myPDFFields.Fields("MHPropRepPremiumLimit")
                    'DirectCast(pdffield, TallComponents.PDF.Forms.Fields.TextField).Value = ds4.Tables(0).Rows(0).Item("PackWind").ToString().Replace("$", "")
                    'pdffield = myPDFFields.Fields("MHPropRepPremium")
                    'DirectCast(pdffield, TallComponents.PDF.Forms.Fields.TextField).Value = "($" & CInt(ds3.Tables(0).Rows(0).Item("PackHur").ToString().Replace("$", "")) & ")"

                    'Hurricane/Tropical Storm

                    'pdffield = myPDFFields.Fields("MHRepCostDesc")
                    'DirectCast(pdffield, TallComponents.PDF.Forms.Fields.TextField).Value = "Hurricane / Tropical Storm Deductible:"

                    'pdffield = myPDFFields.Fields("MHPropCostPremlimit")
                    'DirectCast(pdffield, TallComponents.PDF.Forms.Fields.TextField).Value = ds4.Tables(0).Rows(0).Item("PackWind").ToString().Replace("$", "")


                    pdffield = myPDFFields.Fields("Total Quoted Premium")
                    DirectCast(pdffield, TallComponents.PDF.Forms.Fields.TextField).Value = "$" & ds4.Tables(0).Rows(0).Item("Packtotal").ToString().Replace("$", "")

                    If ds4.Tables(0).Rows(0).Item("PackContReplace").ToString().Replace("$", "") = "Yes" Then

                        pdffield = myPDFFields.Fields("MHContentsdesc")
                        DirectCast(pdffield, TallComponents.PDF.Forms.Fields.TextField).Value = "Contents Replacement Cost"

                        pdffield = myPDFFields.Fields("MHContentsLimit")
                        DirectCast(pdffield, TallComponents.PDF.Forms.Fields.TextField).Value = ds4.Tables(0).Rows(0).Item("PackCont").ToString().Replace("$", "")

                        pdffield = myPDFFields.Fields("MHContentsPremium")
                        DirectCast(pdffield, TallComponents.PDF.Forms.Fields.TextField).Value = ds4.Tables(0).Rows(0).Item("PackContReplacePrem").ToString().Replace("$", "")

                    End If
                    If ds.Tables(0).Rows(0).Item("suppHeating").ToString() = "Yes" Then
                        pdffield = myPDFFields.Fields("MHFeeDesc")
                        DirectCast(pdffield, TallComponents.PDF.Forms.Fields.TextField).Value = "Supplemental Heating Surcharge"
                        pdffield = myPDFFields.Fields("MHFeeAmount")
                        DirectCast(pdffield, TallComponents.PDF.Forms.Fields.TextField).Value = "$50"

                    End If
                    ''If ds.Tables(0).Rows(0).Item("homeUse").ToString() = "Seasonal" Then
                    ''    pdffield = myPDFFields.Fields("MHFeeDesc1")
                    ''    DirectCast(pdffield, TallComponents.PDF.Forms.Fields.TextField).Value = "Seasonal Surcharge"
                    ''    pdffield = myPDFFields.Fields("MHFeeAmount1")
                    ''    DirectCast(pdffield, TallComponents.PDF.Forms.Fields.TextField).Value = "$20"
                    ''    pdffield = myPDFFields.Fields("MHFeeDesc")
                    ''    DirectCast(pdffield, TallComponents.PDF.Forms.Fields.TextField).Value = "Supplemental Heating Surcharge"
                    ''    pdffield = myPDFFields.Fields("MHFeeAmount")
                    ''    DirectCast(pdffield, TallComponents.PDF.Forms.Fields.TextField).Value = "$" & ds4.Tables(0).Rows(0).Item("PackFees").ToString().Replace("$", "") - 20
                    ''    If ds4.Tables(0).Rows(0).Item("PackCreditPerc").ToString().Replace("$", "") > "0" Then
                    ''        pdffield = myPDFFields.Fields("MHFeeDesc2")
                    ''        DirectCast(pdffield, TallComponents.PDF.Forms.Fields.TextField).Value = "Credit Percentage " & CDbl(ds4.Tables(0).Rows(0).Item("PackCreditPerc").ToString().Replace("$", "")) * 100 & " %"
                    ''        pdffield = myPDFFields.Fields("MHFeeAmount2")
                    ''        DirectCast(pdffield, TallComponents.PDF.Forms.Fields.TextField).Value = "($-" & ds4.Tables(0).Rows(0).Item("PackCreditamt").ToString().Replace("$", "") & ")"

                    ''    End If
                    ''Else
                    ''    If IsNumeric(ds4.Tables(0).Rows(0).Item("PackFees").ToString().Replace("$", "")) Then
                    ''        If CInt(ds4.Tables(0).Rows(0).Item("PackFees").ToString().Replace("$", "")) > 0 Then
                    ''            pdffield = myPDFFields.Fields("MHFeeDesc")
                    ''            DirectCast(pdffield, TallComponents.PDF.Forms.Fields.TextField).Value = "Supplemental Heating Surcharge"
                    ''            pdffield = myPDFFields.Fields("MHFeeAmount")
                    ''            DirectCast(pdffield, TallComponents.PDF.Forms.Fields.TextField).Value = "$" & ds4.Tables(0).Rows(0).Item("PackFees").ToString().Replace("$", "")

                    ''        End If
                    ''    End If


                    ''    If ds4.Tables(0).Rows(0).Item("PackCreditamt").ToString().Replace("$", "") < "0" Then
                    ''        pdffield = myPDFFields.Fields("MHFeeDesc1")
                    ''        DirectCast(pdffield, TallComponents.PDF.Forms.Fields.TextField).Value = "No Lien Credit " '& CDbl(ds4.Tables(0).Rows(0).Item("PackCreditPerc").ToString().Replace("$", "")) * 100 & " %"
                    ''        pdffield = myPDFFields.Fields("MHFeeAmount1")
                    ''        DirectCast(pdffield, TallComponents.PDF.Forms.Fields.TextField).Value = "$" & ds4.Tables(0).Rows(0).Item("PackCreditamt").ToString().Replace("$", "")

                    ''    End If

                    ''End If

                    'Wind 

                    Select Case ds4.Tables(0).Rows(0).Item("territoryid").ToString()
                        Case "1"
                            If CInt(ds4.Tables(0).Rows(0).Item("PackDwel").ToString()) < 25000 Then
                                pdffield = myPDFFields.Fields("MHPropRepDesc")
                                DirectCast(pdffield, TallComponents.PDF.Forms.Fields.TextField).Value = "Named Storm Deductible"
                                pdffield = myPDFFields.Fields("MHPropRepPremiumLimit")
                                DirectCast(pdffield, TallComponents.PDF.Forms.Fields.TextField).Value = "2500"


                            End If
                            If CInt(ds4.Tables(0).Rows(0).Item("PackDwel").ToString()) > 24999 Then
                                pdffield = myPDFFields.Fields("MHPropRepDesc")
                                DirectCast(pdffield, TallComponents.PDF.Forms.Fields.TextField).Value = "Named Storm Deductible"
                                pdffield = myPDFFields.Fields("MHPropRepPremiumLimit")
                                DirectCast(pdffield, TallComponents.PDF.Forms.Fields.TextField).Value = "5000"
                                pdffield = myPDFFields.Fields("MHRepCostDesc")
                                DirectCast(pdffield, TallComponents.PDF.Forms.Fields.TextField).Value = "Wind\Hail\Tornado Deductible"
                                pdffield = myPDFFields.Fields("MHPropCostPremlimit")
                                DirectCast(pdffield, TallComponents.PDF.Forms.Fields.TextField).Value = "2000"

                        End If
                        Case "2"
                            If CInt(ds4.Tables(0).Rows(0).Item("PackDwel").ToString()) > 24999 Then
                                pdffield = myPDFFields.Fields("MHPropRepDesc")
                                DirectCast(pdffield, TallComponents.PDF.Forms.Fields.TextField).Value = "Named Storm Deductible"
                                pdffield = myPDFFields.Fields("MHPropRepPremiumLimit")
                                DirectCast(pdffield, TallComponents.PDF.Forms.Fields.TextField).Value = "5000"


                            End If
                        Case "3"
                            If CInt(ds4.Tables(0).Rows(0).Item("PackDwel").ToString()) > 24999 Then

                                pdffield = myPDFFields.Fields("MHRepCostDesc")
                                DirectCast(pdffield, TallComponents.PDF.Forms.Fields.TextField).Value = "Wind\Hail\Tornado Deductible"
                                pdffield = myPDFFields.Fields("MHPropCostPremlimit")
                                DirectCast(pdffield, TallComponents.PDF.Forms.Fields.TextField).Value = "1000"


                        End If
                        Case "4"

                        Case "5"
                            If CInt(ds4.Tables(0).Rows(0).Item("PackDwel").ToString()) > 24999 Then
                                pdffield = myPDFFields.Fields("MHPropRepDesc")
                                DirectCast(pdffield, TallComponents.PDF.Forms.Fields.TextField).Value = "Named Storm Deductible"
                                pdffield = myPDFFields.Fields("MHPropRepPremiumLimit")
                                DirectCast(pdffield, TallComponents.PDF.Forms.Fields.TextField).Value = "1500"
                                pdffield = myPDFFields.Fields("MHRepCostDesc")
                                DirectCast(pdffield, TallComponents.PDF.Forms.Fields.TextField).Value = "Wind\Hail\Tornado Deductible"
                                pdffield = myPDFFields.Fields("MHPropCostPremlimit")
                                DirectCast(pdffield, TallComponents.PDF.Forms.Fields.TextField).Value = "1000"
                       

                        End If
                        Case "6"
                            If CInt(ds4.Tables(0).Rows(0).Item("PackDwel").ToString()) > 24999 Then
                                pdffield = myPDFFields.Fields("MHPropRepDesc")
                                DirectCast(pdffield, TallComponents.PDF.Forms.Fields.TextField).Value = "Named Storm Deductible"
                                pdffield = myPDFFields.Fields("MHPropRepPremiumLimit")
                                DirectCast(pdffield, TallComponents.PDF.Forms.Fields.TextField).Value = "1500"
                                pdffield = myPDFFields.Fields("MHRepCostDesc")
                                DirectCast(pdffield, TallComponents.PDF.Forms.Fields.TextField).Value = "Wind\Hail\Tornado Deductible"
                                pdffield = myPDFFields.Fields("MHPropCostPremlimit")
                                DirectCast(pdffield, TallComponents.PDF.Forms.Fields.TextField).Value = "1500"



                    End If
                    End Select





                    'end wind





                    If ds4.Tables(0).Rows(0).Item("PackMHReplace").ToString().Replace("$", "") = "Yes" Then
                        pdffield = myPDFFields.Fields("MHFireDesc")
                        DirectCast(pdffield, TallComponents.PDF.Forms.Fields.TextField).Value = "Replacement Cost for Mobile Home"
                        pdffield = myPDFFields.Fields("MHFirePremium")
                        DirectCast(pdffield, TallComponents.PDF.Forms.Fields.TextField).Value = "$" & ds4.Tables(0).Rows(0).Item("PackMHReplacePrem").ToString().Replace("$", "")

                    End If
                    'If ds4.Tables(0).Rows(0).Item("PackContPrem").ToString().Replace("$", "") > "0" Then
                    pdffield = myPDFFields.Fields("MobileHomePersonalProp")
                    DirectCast(pdffield, TallComponents.PDF.Forms.Fields.TextField).Value = "Contents"
                    pdffield = myPDFFields.Fields("MHPerPropLimit")
                    DirectCast(pdffield, TallComponents.PDF.Forms.Fields.TextField).Value = "$" & ds4.Tables(0).Rows(0).Item("PackCont").ToString().Replace("$", "")
                    pdffield = myPDFFields.Fields("MHPerPropPremium")
                    DirectCast(pdffield, TallComponents.PDF.Forms.Fields.TextField).Value = "$" & ds4.Tables(0).Rows(0).Item("PackContPrem").ToString().Replace("$", "")

                    ' End If

                    If ds4.Tables(0).Rows(0).Item("PackStruc").ToString().Replace("$", "") <> "0.00" Then
                        pdffield = myPDFFields.Fields("MHAddStrucDesc")
                        DirectCast(pdffield, TallComponents.PDF.Forms.Fields.TextField).Value = "Other Structures"
                        pdffield = myPDFFields.Fields("MHAddStrucLimit")
                        DirectCast(pdffield, TallComponents.PDF.Forms.Fields.TextField).Value = "$" & ds4.Tables(0).Rows(0).Item("PackStruc").ToString().Replace("$", "")
                        pdffield = myPDFFields.Fields("MHAddStrucPremium")
                        DirectCast(pdffield, TallComponents.PDF.Forms.Fields.TextField).Value = "$" & ds4.Tables(0).Rows(0).Item("PackStrucPrem").ToString().Replace("$", "")

                    End If
                    If ds4.Tables(0).Rows(0).Item("PackPerLiab").ToString().Replace("$", "") <> "0" Then
                        pdffield = myPDFFields.Fields("MHPerLiabDesc")
                        DirectCast(pdffield, TallComponents.PDF.Forms.Fields.TextField).Value = "Personal Liability"
                        pdffield = myPDFFields.Fields("MHPerLiabLimit")
                        DirectCast(pdffield, TallComponents.PDF.Forms.Fields.TextField).Value = "$" & ds4.Tables(0).Rows(0).Item("PackPerLiab").ToString().Replace("$", "").Replace(",", "")
                        pdffield = myPDFFields.Fields("MHPerLiabPremium")
                        DirectCast(pdffield, TallComponents.PDF.Forms.Fields.TextField).Value = "$" & ds4.Tables(0).Rows(0).Item("PackPersLiabPrem").ToString().Replace("$", "")

                    End If


                    If ds4.Tables(0).Rows(0).Item("PackFullRepair").ToString().Replace("$", "") = "Yes" Then
                        pdffield = myPDFFields.Fields("MHFireDesc")
                        DirectCast(pdffield, TallComponents.PDF.Forms.Fields.TextField).Value = "Full Repair"
                        'pdffield = myPDFFields.Fields("MHContentsLimit")
                        'DirectCast(pdffield, TallComponents.PDF.Forms.Fields.TextField).Value = "$" & ds4.Tables(0).Rows(0).Item("PackPerLiab").ToString().Replace("$", "")
                        pdffield = myPDFFields.Fields("MHFirePremium")
                        DirectCast(pdffield, TallComponents.PDF.Forms.Fields.TextField).Value = "$" & ds4.Tables(0).Rows(0).Item("PackFullRepairPrem").ToString().Replace("$", "")

                    End If


                    pdffield = myPDFFields.Fields("MHNDDesc")
                    DirectCast(pdffield, TallComponents.PDF.Forms.Fields.TextField).Value = "Tax"
                    pdffield = myPDFFields.Fields("MHNDPremium")
                    DirectCast(pdffield, TallComponents.PDF.Forms.Fields.TextField).Value = "$" & ds4.Tables(0).Rows(0).Item("PackTax").ToString().Replace("$", "")
                    If ds4.Tables(0).Rows(0).Item("PackMedPay").ToString().Replace("$", "") > "0.00" Then
                        pdffield = myPDFFields.Fields("MHMedPayDesc")
                        DirectCast(pdffield, TallComponents.PDF.Forms.Fields.TextField).Value = "Medical Payments"
                        pdffield = myPDFFields.Fields("MHMedPayLimit")
                        DirectCast(pdffield, TallComponents.PDF.Forms.Fields.TextField).Value = "$" & ds4.Tables(0).Rows(0).Item("PackMedPay").ToString().Replace("$", "")
                        pdffield = myPDFFields.Fields("MHMedPayPremium")
                        DirectCast(pdffield, TallComponents.PDF.Forms.Fields.TextField).Value = "$" & ds4.Tables(0).Rows(0).Item("PackMedPrem").ToString().Replace("$", "")

                    End If


                    If ds4.Tables(0).Rows(0).Item("PackPPprem").ToString().Replace("$", "") <> "0.00" Then
                        pdffield = myPDFFields.Fields("MHWaterCraftDesc")
                        DirectCast(pdffield, TallComponents.PDF.Forms.Fields.TextField).Value = "Scheduled Personal Property"
                        pdffield = myPDFFields.Fields("MHWaterCraftLimit")
                        DirectCast(pdffield, TallComponents.PDF.Forms.Fields.TextField).Value = "$" & ds4.Tables(0).Rows(0).Item("PackPPlimit").ToString().Replace("$", "").Replace(",", "")
                        pdffield = myPDFFields.Fields("MHWaterCraftPremium")
                        DirectCast(pdffield, TallComponents.PDF.Forms.Fields.TextField).Value = "$" & ds4.Tables(0).Rows(0).Item("PackPPprem").ToString().Replace("$", "")

                    End If

                    'put options in.


                    If ds4.Tables(0).Rows(0).Item("PackAddliving").ToString().Replace("$", "") = "Yes" Then
                        pdffield = myPDFFields.Fields("MHRadioDesc")
                        DirectCast(pdffield, TallComponents.PDF.Forms.Fields.TextField).Value = "Additional Living Expense"
                        pdffield = myPDFFields.Fields("MHRadioPremium")
                        DirectCast(pdffield, TallComponents.PDF.Forms.Fields.TextField).Value = "$" & ds4.Tables(0).Rows(0).Item("PackAddlivingPrem").ToString().Replace("$", "")

                    End If
                    If ds4.Tables(0).Rows(0).Item("PackEarth").ToString().Replace("$", "") = "Yes" Then
                        pdffield = myPDFFields.Fields("MHAddResDesc")
                        DirectCast(pdffield, TallComponents.PDF.Forms.Fields.TextField).Value = "EarthQuake Coverage"
                        pdffield = myPDFFields.Fields("MHAddResPremium")
                        DirectCast(pdffield, TallComponents.PDF.Forms.Fields.TextField).Value = "$" & ds4.Tables(0).Rows(0).Item("PackEarthPrem").ToString().Replace("$", "")

                    End If
                    If ds4.Tables(0).Rows(0).Item("PackIce").ToString().Replace("$", "") = "Yes" Then
                        pdffield = myPDFFields.Fields("MHValPropDesc")
                        DirectCast(pdffield, TallComponents.PDF.Forms.Fields.TextField).Value = "Weight of Ice, Snow or Sleet Limitation"
                        pdffield = myPDFFields.Fields("MHValPropPremium")
                        DirectCast(pdffield, TallComponents.PDF.Forms.Fields.TextField).Value = "$" & ds4.Tables(0).Rows(0).Item("PackIcePrem").ToString().Replace("$", "")

                    End If
                    If ds4.Tables(0).Rows(0).Item("PackIceE").ToString().Replace("$", "") = "Yes" Then
                        pdffield = myPDFFields.Fields("MHValPropDesc")
                        DirectCast(pdffield, TallComponents.PDF.Forms.Fields.TextField).Value = "Weight of Ice, Snow or Sleet Deletion of Coverage"
                        pdffield = myPDFFields.Fields("MHValPropPremium")
                        DirectCast(pdffield, TallComponents.PDF.Forms.Fields.TextField).Value = "$" & ds4.Tables(0).Rows(0).Item("PackIceEPrem").ToString().Replace("$", "")

                    End If
                    If ds4.Tables(0).Rows(0).Item("PackTheft").ToString().Replace("$", "") = "Yes" Then
                        pdffield = myPDFFields.Fields("MHSIPDesc")
                        DirectCast(pdffield, TallComponents.PDF.Forms.Fields.TextField).Value = "Theft Exclusion"
                        pdffield = myPDFFields.Fields("MHSIPPremium")
                        DirectCast(pdffield, TallComponents.PDF.Forms.Fields.TextField).Value = "$" & ds4.Tables(0).Rows(0).Item("PackTheftPrem").ToString().Replace("$", "")

                    End If
                    If ds4.Tables(0).Rows(0).Item("PackWater").ToString().Replace("$", "") = "Yes" Then


                        If ds4.Tables(0).Rows(0).Item("PackAddliving").ToString().Replace("$", "") = "No" Then
                            pdffield = myPDFFields.Fields("MHRadioDesc")
                            DirectCast(pdffield, TallComponents.PDF.Forms.Fields.TextField).Value = "Water Damage"
                            pdffield = myPDFFields.Fields("MHRadioPremium")
                            DirectCast(pdffield, TallComponents.PDF.Forms.Fields.TextField).Value = "$" & ds4.Tables(0).Rows(0).Item("PackWaterPrem").ToString().Replace("$", "")


                        ElseIf ds4.Tables(0).Rows(0).Item("PackEarth").ToString().Replace("$", "") = "No" Then
                            pdffield = myPDFFields.Fields("MHAddResDesc")
                            DirectCast(pdffield, TallComponents.PDF.Forms.Fields.TextField).Value = "Water Damage"
                            pdffield = myPDFFields.Fields("MHAddResPremium")
                            DirectCast(pdffield, TallComponents.PDF.Forms.Fields.TextField).Value = "$" & ds4.Tables(0).Rows(0).Item("PackWaterPrem").ToString().Replace("$", "")

                        ElseIf ds4.Tables(0).Rows(0).Item("PackTheft").ToString().Replace("$", "") = "No" Then
                            pdffield = myPDFFields.Fields("MHSIPDesc")
                            DirectCast(pdffield, TallComponents.PDF.Forms.Fields.TextField).Value = "Water Damage"
                            pdffield = myPDFFields.Fields("MHSIPPremium")
                            DirectCast(pdffield, TallComponents.PDF.Forms.Fields.TextField).Value = "$" & ds4.Tables(0).Rows(0).Item("PackWaterPrem").ToString().Replace("$", "")



                        End If
                    End If

                    If ds4.Tables(0).Rows(0).Item("PackGolf").ToString().Replace("$", "") = "Yes" Then


                        If ds4.Tables(0).Rows(0).Item("PackAddliving").ToString().Replace("$", "") = "No" And ds4.Tables(0).Rows(0).Item("PackWater").ToString().Replace("$", "") = "No" Then
                            pdffield = myPDFFields.Fields("MHRadioDesc")
                            DirectCast(pdffield, TallComponents.PDF.Forms.Fields.TextField).Value = "Golf Cart Coverage"
                            pdffield = myPDFFields.Fields("MHRadioPremium")
                            DirectCast(pdffield, TallComponents.PDF.Forms.Fields.TextField).Value = "$" & ds4.Tables(0).Rows(0).Item("PackGolfPrem").ToString().Replace("$", "")


                        ElseIf ds4.Tables(0).Rows(0).Item("PackEarth").ToString().Replace("$", "") = "No" Then
                            pdffield = myPDFFields.Fields("MHAddResDesc")
                            DirectCast(pdffield, TallComponents.PDF.Forms.Fields.TextField).Value = "Golf Cart Coverage"
                            pdffield = myPDFFields.Fields("MHAddResPremium")
                            DirectCast(pdffield, TallComponents.PDF.Forms.Fields.TextField).Value = "$" & ds4.Tables(0).Rows(0).Item("PackGolfPrem").ToString().Replace("$", "")

                        ElseIf ds4.Tables(0).Rows(0).Item("PackTheft").ToString().Replace("$", "") = "No" Then
                            pdffield = myPDFFields.Fields("MHSIPDesc")
                            DirectCast(pdffield, TallComponents.PDF.Forms.Fields.TextField).Value = "Golf Cart Coverage"
                            pdffield = myPDFFields.Fields("MHSIPPremium")
                            DirectCast(pdffield, TallComponents.PDF.Forms.Fields.TextField).Value = "$" & ds4.Tables(0).Rows(0).Item("PackGolfPrem").ToString().Replace("$", "")

                        End If
                    End If

                    If ds4.Tables(0).Rows(0).Item("PackSwim").ToString().Replace("$", "") = "Yes" Then


                        If ds4.Tables(0).Rows(0).Item("PackAddliving").ToString().Replace("$", "") = "No" And ds4.Tables(0).Rows(0).Item("PackWater").ToString().Replace("$", "") = "No" Then
                            pdffield = myPDFFields.Fields("MHRadioDesc")
                            DirectCast(pdffield, TallComponents.PDF.Forms.Fields.TextField).Value = "Limited Swimming Pool or Spa Liability"
                            pdffield = myPDFFields.Fields("MHRadioPremium")
                            DirectCast(pdffield, TallComponents.PDF.Forms.Fields.TextField).Value = "$" & ds4.Tables(0).Rows(0).Item("PackSwimPrem").ToString().Replace("$", "")


                        ElseIf ds4.Tables(0).Rows(0).Item("PackEarth").ToString().Replace("$", "") = "No" Then
                            pdffield = myPDFFields.Fields("MHAddResDesc")
                            DirectCast(pdffield, TallComponents.PDF.Forms.Fields.TextField).Value = "Limited Swimming Pool or Spa Liability"
                            pdffield = myPDFFields.Fields("MHAddResPremium")
                            DirectCast(pdffield, TallComponents.PDF.Forms.Fields.TextField).Value = "$" & ds4.Tables(0).Rows(0).Item("PackSwimPrem").ToString().Replace("$", "")

                        ElseIf ds4.Tables(0).Rows(0).Item("PackTheft").ToString().Replace("$", "") = "No" Then
                            pdffield = myPDFFields.Fields("MHSIPDesc")
                            DirectCast(pdffield, TallComponents.PDF.Forms.Fields.TextField).Value = "Limited Swimming Pool or Spa Liability"
                            pdffield = myPDFFields.Fields("MHSIPPremium")
                            DirectCast(pdffield, TallComponents.PDF.Forms.Fields.TextField).Value = "$" & ds4.Tables(0).Rows(0).Item("PackSwimPrem").ToString().Replace("$", "")

                        End If
                    End If


                    ' PackTotal -= CInt(ds3.Tables(0).Rows(0).Item("PackHur").ToString())
                Case "Aegis Standard1"
                    pdffield = myPDFFields.Fields("MHDwellLimit")
                    DirectCast(pdffield, TallComponents.PDF.Forms.Fields.TextField).Value = CInt(ds4.Tables(0).Rows(0).Item("StandDwel").ToString())

                    'pdffield = myPDFFields.Fields("MHPerPropLimit")
                    'DirectCast(pdffield, TallComponents.PDF.Forms.Fields.TextField).Value = CInt(ds4.Tables(0).Rows(0).Item("StandCont").ToString())


                    pdffield = myPDFFields.Fields("MHDwellPremium")
                    DirectCast(pdffield, TallComponents.PDF.Forms.Fields.TextField).Value = CInt(ds4.Tables(0).Rows(0).Item("Standprem").ToString()) '- CInt(ds3.Tables(0).Rows(0).Item("StandHur").ToString()) - CInt(ds3.Tables(0).Rows(0).Item("StandNonHur").ToString())
                    ' StandardTotal += CInt(ds4.Tables(0).Rows(0).Item("StandBasePrem").ToString()) ' - CInt(ds3.Tables(0).Rows(0).Item("StandHur").ToString()) - CInt(ds3.Tables(0).Rows(0).Item("StandNonHur").ToString())
                    If CInt(ds4.Tables(0).Rows(0).Item("StandAOP").ToString().Replace("$", "")) > 500 Then
                        pdffield = myPDFFields.Fields("MHDedDesc")
                        DirectCast(pdffield, TallComponents.PDF.Forms.Fields.TextField).Value = "Deductible Change Option AOP"
                        pdffield = myPDFFields.Fields("MHDedPremium")
                        DirectCast(pdffield, TallComponents.PDF.Forms.Fields.TextField).Value = "($" & CInt(ds4.Tables(0).Rows(0).Item("StandAOPPrem").ToString()) & ")"
                    Else
                        pdffield = myPDFFields.Fields("MHDedDesc")
                        DirectCast(pdffield, TallComponents.PDF.Forms.Fields.TextField).Value = "AOP Deductible"
                    End If


                    pdffield = myPDFFields.Fields("MHDedLimit")
                    DirectCast(pdffield, TallComponents.PDF.Forms.Fields.TextField).Value = "$" & ds4.Tables(0).Rows(0).Item("StandAOP").ToString().Replace("$", "")

                    ' StandTotal -= CInt(ds3.Tables(0).Rows(0).Item("StandNonHur").ToString())


                    pdffield = myPDFFields.Fields("MHPropRepDesc")
                    DirectCast(pdffield, TallComponents.PDF.Forms.Fields.TextField).Value = "Wind Hail Deductible:"

                    pdffield = myPDFFields.Fields("MHPropRepPremiumLimit")
                    DirectCast(pdffield, TallComponents.PDF.Forms.Fields.TextField).Value = ds4.Tables(0).Rows(0).Item("StandWind").ToString().Replace("$", "")
                    'pdffield = myPDFFields.Fields("MHPropRepPremium")
                    'DirectCast(pdffield, TallComponents.PDF.Forms.Fields.TextField).Value = "($" & CInt(ds3.Tables(0).Rows(0).Item("StandHur").ToString().Replace("$", "")) & ")"

                    pdffield = myPDFFields.Fields("Total Quoted Premium")
                    DirectCast(pdffield, TallComponents.PDF.Forms.Fields.TextField).Value = "$" & ds4.Tables(0).Rows(0).Item("Standtotal").ToString().Replace("$", "")

                    If ds4.Tables(0).Rows(0).Item("StandContReplacePrem").ToString() <> "0" Then

                        pdffield = myPDFFields.Fields("MHContentsdesc")
                        DirectCast(pdffield, TallComponents.PDF.Forms.Fields.TextField).Value = "Contents Replacement Cost"

                        pdffield = myPDFFields.Fields("MHContentsPremium")
                        DirectCast(pdffield, TallComponents.PDF.Forms.Fields.TextField).Value = ds4.Tables(0).Rows(0).Item("StandContReplacePrem").ToString().Replace("$", "")

                    End If
                    If ds.Tables(0).Rows(0).Item("homeUse").ToString() = "Seasonal" Then
                        pdffield = myPDFFields.Fields("MHFeeDesc1")
                        DirectCast(pdffield, TallComponents.PDF.Forms.Fields.TextField).Value = "Seasonal Surcharge"
                        pdffield = myPDFFields.Fields("MHFeeAmount1")
                        DirectCast(pdffield, TallComponents.PDF.Forms.Fields.TextField).Value = "$20"
                        pdffield = myPDFFields.Fields("MHSIPDesc")
                        DirectCast(pdffield, TallComponents.PDF.Forms.Fields.TextField).Value = "Policy Fee"
                        pdffield = myPDFFields.Fields("MHSIPPremium")
                        DirectCast(pdffield, TallComponents.PDF.Forms.Fields.TextField).Value = "$" & ds4.Tables(0).Rows(0).Item("StandFees").ToString().Replace("$", "") - 20
                        If ds4.Tables(0).Rows(0).Item("StandCreditPerc").ToString().Replace("$", "") > "0" Then
                            pdffield = myPDFFields.Fields("MHFeeDesc2")
                            DirectCast(pdffield, TallComponents.PDF.Forms.Fields.TextField).Value = "Credit Percentage " & CDbl(ds4.Tables(0).Rows(0).Item("StandCreditPerc").ToString().Replace("$", "")) * 100 & " %"
                            pdffield = myPDFFields.Fields("MHFeeAmount2")
                            DirectCast(pdffield, TallComponents.PDF.Forms.Fields.TextField).Value = "($-" & ds4.Tables(0).Rows(0).Item("StandCreditamt").ToString().Replace("$", "") & ")"

                        End If
                    Else
                        pdffield = myPDFFields.Fields("MHSIPDesc")
                        DirectCast(pdffield, TallComponents.PDF.Forms.Fields.TextField).Value = " Policy Fee"
                        pdffield = myPDFFields.Fields("MHSIPPremium")
                        DirectCast(pdffield, TallComponents.PDF.Forms.Fields.TextField).Value = "$" & ds4.Tables(0).Rows(0).Item("StandFees").ToString().Replace("$", "")

                        If ds4.Tables(0).Rows(0).Item("StandCreditPerc").ToString().Replace("$", "") > "0" Then
                            pdffield = myPDFFields.Fields("MHFeeDesc2")
                            DirectCast(pdffield, TallComponents.PDF.Forms.Fields.TextField).Value = "Credit Percentage " & CDbl(ds4.Tables(0).Rows(0).Item("StandCreditPerc").ToString().Replace("$", "")) * 100 & " %"
                            pdffield = myPDFFields.Fields("MHFeeAmount2")
                            DirectCast(pdffield, TallComponents.PDF.Forms.Fields.TextField).Value = "($-" & ds4.Tables(0).Rows(0).Item("StandCreditamt").ToString().Replace("$", "") & ")"

                        End If

                    End If
                    If ds4.Tables(0).Rows(0).Item("StandMHReplace").ToString().Replace("$", "") = "Yes" Then
                        pdffield = myPDFFields.Fields("MHRepCostDesc")
                        DirectCast(pdffield, TallComponents.PDF.Forms.Fields.TextField).Value = "Replacement Cost for Mobile Home"
                        pdffield = myPDFFields.Fields("MHRepCostPremium")
                        DirectCast(pdffield, TallComponents.PDF.Forms.Fields.TextField).Value = "$" & ds4.Tables(0).Rows(0).Item("StandMHReplacePrem").ToString().Replace("$", "")

                    End If
                    If ds4.Tables(0).Rows(0).Item("StandContPrem").ToString().Replace("$", "") > "0" Then
                        pdffield = myPDFFields.Fields("MobileHomePersonalProp")
                        DirectCast(pdffield, TallComponents.PDF.Forms.Fields.TextField).Value = "Contents"
                        pdffield = myPDFFields.Fields("MHPerPropLimit")
                        DirectCast(pdffield, TallComponents.PDF.Forms.Fields.TextField).Value = "$" & ds4.Tables(0).Rows(0).Item("StandCont").ToString().Replace("$", "")
                        pdffield = myPDFFields.Fields("MHPerPropPremium")
                        DirectCast(pdffield, TallComponents.PDF.Forms.Fields.TextField).Value = "$" & ds4.Tables(0).Rows(0).Item("StandContPrem").ToString().Replace("$", "")

                    End If

                    If ds4.Tables(0).Rows(0).Item("StandStruc").ToString().Replace("$", "") <> "0.00" Then
                        pdffield = myPDFFields.Fields("MHAddStrucDesc")
                        DirectCast(pdffield, TallComponents.PDF.Forms.Fields.TextField).Value = "Other Structures"
                        pdffield = myPDFFields.Fields("MHAddStrucLimit")
                        DirectCast(pdffield, TallComponents.PDF.Forms.Fields.TextField).Value = "$" & ds4.Tables(0).Rows(0).Item("StandStruc").ToString().Replace("$", "")
                        pdffield = myPDFFields.Fields("MHAddStrucPremium")
                        DirectCast(pdffield, TallComponents.PDF.Forms.Fields.TextField).Value = "$" & ds4.Tables(0).Rows(0).Item("StandStrucPrem").ToString().Replace("$", "")

                    End If
                    If ds4.Tables(0).Rows(0).Item("StandPerLiab").ToString().Replace("$", "") <> "0" Then
                        pdffield = myPDFFields.Fields("MHPerLiabDesc")
                        DirectCast(pdffield, TallComponents.PDF.Forms.Fields.TextField).Value = "Personal Liability"
                        pdffield = myPDFFields.Fields("MHPerLiabLimit")
                        DirectCast(pdffield, TallComponents.PDF.Forms.Fields.TextField).Value = "$" & ds4.Tables(0).Rows(0).Item("StandPerLiab").ToString().Replace("$", "").Replace(",", "")
                        pdffield = myPDFFields.Fields("MHPerLiabPremium")
                        DirectCast(pdffield, TallComponents.PDF.Forms.Fields.TextField).Value = "$" & ds4.Tables(0).Rows(0).Item("StandPersLiabPrem").ToString().Replace("$", "")

                    End If


                    If ds4.Tables(0).Rows(0).Item("StandFullRepair").ToString().Replace("$", "") = "Yes" Then
                        pdffield = myPDFFields.Fields("MHFireDesc")
                        DirectCast(pdffield, TallComponents.PDF.Forms.Fields.TextField).Value = "Full Repair"
                        'pdffield = myPDFFields.Fields("MHContentsLimit")
                        'DirectCast(pdffield, TallComponents.PDF.Forms.Fields.TextField).Value = "$" & ds4.Tables(0).Rows(0).Item("StandPerLiab").ToString().Replace("$", "")
                        pdffield = myPDFFields.Fields("MHFirePremium")
                        DirectCast(pdffield, TallComponents.PDF.Forms.Fields.TextField).Value = "$" & ds4.Tables(0).Rows(0).Item("StandFullRepairPrem").ToString().Replace("$", "")

                    End If


                    pdffield = myPDFFields.Fields("MHNDDesc")
                    DirectCast(pdffield, TallComponents.PDF.Forms.Fields.TextField).Value = "Tax"
                    pdffield = myPDFFields.Fields("MHNDPremium")
                    DirectCast(pdffield, TallComponents.PDF.Forms.Fields.TextField).Value = "$" & ds4.Tables(0).Rows(0).Item("StandTax").ToString().Replace("$", "")
                    If ds4.Tables(0).Rows(0).Item("StandMedPay").ToString().Replace("$", "") > "0.00" Then
                        pdffield = myPDFFields.Fields("MHMedPayDesc")
                        DirectCast(pdffield, TallComponents.PDF.Forms.Fields.TextField).Value = "Medical Payments"
                        pdffield = myPDFFields.Fields("MHMedPayLimit")
                        DirectCast(pdffield, TallComponents.PDF.Forms.Fields.TextField).Value = "$" & ds4.Tables(0).Rows(0).Item("StandMedPay").ToString().Replace("$", "")
                        pdffield = myPDFFields.Fields("MHMedPayPremium")
                        DirectCast(pdffield, TallComponents.PDF.Forms.Fields.TextField).Value = "$" & ds4.Tables(0).Rows(0).Item("StandMedPrem").ToString().Replace("$", "")

                    End If
                Case "Aegis Rental"
                    pdffield = myPDFFields.Fields("MHDwellLimit")
                    DirectCast(pdffield, TallComponents.PDF.Forms.Fields.TextField).Value = CInt(ds4.Tables(0).Rows(0).Item("RentDwel").ToString())

                    'pdffield = myPDFFields.Fields("MHPerPropLimit")
                    'DirectCast(pdffield, TallComponents.PDF.Forms.Fields.TextField).Value = CInt(ds4.Tables(0).Rows(0).Item("RentCont").ToString())


                    pdffield = myPDFFields.Fields("MHDwellPremium")
                    DirectCast(pdffield, TallComponents.PDF.Forms.Fields.TextField).Value = CInt(ds4.Tables(0).Rows(0).Item("Rentprem").ToString()) '- CInt(ds3.Tables(0).Rows(0).Item("RentHur").ToString()) - CInt(ds3.Tables(0).Rows(0).Item("RentNonHur").ToString())
                    ' RentardTotal += CInt(ds4.Tables(0).Rows(0).Item("RentBasePrem").ToString()) ' - CInt(ds3.Tables(0).Rows(0).Item("RentHur").ToString()) - CInt(ds3.Tables(0).Rows(0).Item("RentNonHur").ToString())
                    If IsNumeric(ds4.Tables(0).Rows(0).Item("RentAOP").ToString().Replace("$", "")) Then

                        If CInt(ds4.Tables(0).Rows(0).Item("RentAOP").ToString().Replace("$", "")) > 500 Then
                            pdffield = myPDFFields.Fields("MHDedDesc")
                            DirectCast(pdffield, TallComponents.PDF.Forms.Fields.TextField).Value = "Deductible Change Option AOP"
                            pdffield = myPDFFields.Fields("MHDedPremium")
                            DirectCast(pdffield, TallComponents.PDF.Forms.Fields.TextField).Value = "($" & CInt(ds4.Tables(0).Rows(0).Item("RentAOPPrem").ToString()) & ")"
                            pdffield = myPDFFields.Fields("MHDedLimit")
                            DirectCast(pdffield, TallComponents.PDF.Forms.Fields.TextField).Value = "$" & ds4.Tables(0).Rows(0).Item("RentAOP").ToString().Replace("$", "")

                        Else
                            pdffield = myPDFFields.Fields("MHDedLimit")
                            DirectCast(pdffield, TallComponents.PDF.Forms.Fields.TextField).Value = "$" & ds4.Tables(0).Rows(0).Item("RentAOP").ToString().Replace("$", "")

                            pdffield = myPDFFields.Fields("MHDedDesc")
                            DirectCast(pdffield, TallComponents.PDF.Forms.Fields.TextField).Value = "AOP Deductible"
                        End If


                    End If

                    ' RentTotal -= CInt(ds3.Tables(0).Rows(0).Item("RentNonHur").ToString())


                    'pdffield = myPDFFields.Fields("MHPropRepDesc")
                    'DirectCast(pdffield, TallComponents.PDF.Forms.Fields.TextField).Value = "Wind Hail Deductible:"

                    pdffield = myPDFFields.Fields("MHPropRepPremiumLimit")
                    DirectCast(pdffield, TallComponents.PDF.Forms.Fields.TextField).Value = ds4.Tables(0).Rows(0).Item("RentWind").ToString().Replace("$", "")
                    'pdffield = myPDFFields.Fields("MHPropRepPremium")
                    'DirectCast(pdffield, TallComponents.PDF.Forms.Fields.TextField).Value = "($" & CInt(ds3.Tables(0).Rows(0).Item("RentHur").ToString().Replace("$", "")) & ")"

                    pdffield = myPDFFields.Fields("Total Quoted Premium")
                    DirectCast(pdffield, TallComponents.PDF.Forms.Fields.TextField).Value = "$" & ds4.Tables(0).Rows(0).Item("Renttotal").ToString().Replace("$", "")

                    'If ds4.Tables(0).Rows(0).Item("RentContReplacePrem").ToString() <> "0" Then

                    '    pdffield = myPDFFields.Fields("MHContentsdesc")
                    '    DirectCast(pdffield, TallComponents.PDF.Forms.Fields.TextField).Value = "Contents Replacement Cost"

                    '    pdffield = myPDFFields.Fields("MHContentsPremium")
                    '    DirectCast(pdffield, TallComponents.PDF.Forms.Fields.TextField).Value = ds4.Tables(0).Rows(0).Item("RentContReplacePrem").ToString().Replace("$", "")

                    'End If
                    If ds.Tables(0).Rows(0).Item("homeUse").ToString() = "Seasonal" Then
                        pdffield = myPDFFields.Fields("MHFeeDesc1")
                        DirectCast(pdffield, TallComponents.PDF.Forms.Fields.TextField).Value = "Seasonal Surcharge"
                        pdffield = myPDFFields.Fields("MHFeeAmount1")
                        DirectCast(pdffield, TallComponents.PDF.Forms.Fields.TextField).Value = "$20"
                        pdffield = myPDFFields.Fields("MHSIPDesc")
                        DirectCast(pdffield, TallComponents.PDF.Forms.Fields.TextField).Value = "Expense Constant"
                        pdffield = myPDFFields.Fields("MHSIPPremium")
                        DirectCast(pdffield, TallComponents.PDF.Forms.Fields.TextField).Value = "$" & ds4.Tables(0).Rows(0).Item("RentFees").ToString().Replace("$", "")
                        'If ds4.Tables(0).Rows(0).Item("RentCreditPerc").ToString().Replace("$", "") > "0" Then
                        '    pdffield = myPDFFields.Fields("MHFeeDesc2")
                        '    DirectCast(pdffield, TallComponents.PDF.Forms.Fields.TextField).Value = "Credit Percentage " & CDbl(ds4.Tables(0).Rows(0).Item("RentCreditPerc").ToString().Replace("$", "")) * 100 & " %"
                        '    pdffield = myPDFFields.Fields("MHFeeAmount2")
                        '    DirectCast(pdffield, TallComponents.PDF.Forms.Fields.TextField).Value = "($-" & ds4.Tables(0).Rows(0).Item("RentCreditamt").ToString().Replace("$", "") & ")"

                        'End If
                    Else
                        pdffield = myPDFFields.Fields("MHSIPDesc")
                        DirectCast(pdffield, TallComponents.PDF.Forms.Fields.TextField).Value = "Expense Constant"
                        pdffield = myPDFFields.Fields("MHSIPPremium")
                        DirectCast(pdffield, TallComponents.PDF.Forms.Fields.TextField).Value = "$" & ds4.Tables(0).Rows(0).Item("RentFees").ToString().Replace("$", "")

                        'If ds4.Tables(0).Rows(0).Item("RentCreditPerc").ToString().Replace("$", "") > "0" Then
                        '    pdffield = myPDFFields.Fields("MHFeeDesc2")
                        '    DirectCast(pdffield, TallComponents.PDF.Forms.Fields.TextField).Value = "Credit Percentage " & CDbl(ds4.Tables(0).Rows(0).Item("RentCreditPerc").ToString().Replace("$", "")) * 100 & " %"
                        '    pdffield = myPDFFields.Fields("MHFeeAmount2")
                        '    DirectCast(pdffield, TallComponents.PDF.Forms.Fields.TextField).Value = "($-" & ds4.Tables(0).Rows(0).Item("RentCreditamt").ToString().Replace("$", "") & ")"

                        'End If

                    End If
                    If ds4.Tables(0).Rows(0).Item("RentMHReplace").ToString().Replace("$", "") = "Yes" Then
                        pdffield = myPDFFields.Fields("MHRepCostDesc")
                        DirectCast(pdffield, TallComponents.PDF.Forms.Fields.TextField).Value = "Replacement Cost for Mobile Home"
                        pdffield = myPDFFields.Fields("MHRepCostPremium")
                        DirectCast(pdffield, TallComponents.PDF.Forms.Fields.TextField).Value = "$" & ds4.Tables(0).Rows(0).Item("RentMHReplacePrem").ToString().Replace("$", "")

                    End If
                    If ds4.Tables(0).Rows(0).Item("RentContPrem").ToString().Replace("$", "") > "0" Then
                        pdffield = myPDFFields.Fields("MobileHomePersonalProp")
                        DirectCast(pdffield, TallComponents.PDF.Forms.Fields.TextField).Value = "Contents"
                        pdffield = myPDFFields.Fields("MHPerPropLimit")
                        DirectCast(pdffield, TallComponents.PDF.Forms.Fields.TextField).Value = "$" & ds4.Tables(0).Rows(0).Item("RentCont").ToString().Replace("$", "")
                        pdffield = myPDFFields.Fields("MHPerPropPremium")
                        DirectCast(pdffield, TallComponents.PDF.Forms.Fields.TextField).Value = "$" & ds4.Tables(0).Rows(0).Item("RentContPrem").ToString().Replace("$", "")

                    End If
                    Dim test As String
                    test = ds4.Tables(0).Rows(0).Item("RentStruc").ToString().Replace("$", "")
                    If ds4.Tables(0).Rows(0).Item("RentStruc").ToString().Replace("$", "") <> "0.00" Then
                        pdffield = myPDFFields.Fields("MHAddStrucDesc")
                        DirectCast(pdffield, TallComponents.PDF.Forms.Fields.TextField).Value = "Other Structures"
                        pdffield = myPDFFields.Fields("MHAddStrucLimit")
                        DirectCast(pdffield, TallComponents.PDF.Forms.Fields.TextField).Value = "$" & ds4.Tables(0).Rows(0).Item("RentStruc").ToString().Replace("$", "")
                        pdffield = myPDFFields.Fields("MHAddStrucPremium")
                        DirectCast(pdffield, TallComponents.PDF.Forms.Fields.TextField).Value = "$" & ds4.Tables(0).Rows(0).Item("RentStrucPrem").ToString().Replace("$", "")

                    End If
                    If ds4.Tables(0).Rows(0).Item("RentPerLiab").ToString().Replace("$", "") <> "" Then
                        If ds4.Tables(0).Rows(0).Item("RentPerLiab").ToString().Replace("$", "") <> "0" Then
                            pdffield = myPDFFields.Fields("MHPerLiabDesc")
                            DirectCast(pdffield, TallComponents.PDF.Forms.Fields.TextField).Value = "Premises Liability"
                            pdffield = myPDFFields.Fields("MHPerLiabLimit")
                            DirectCast(pdffield, TallComponents.PDF.Forms.Fields.TextField).Value = "$" & ds4.Tables(0).Rows(0).Item("RentPerLiab").ToString().Replace("$", "").Replace(",", "")
                            pdffield = myPDFFields.Fields("MHPerLiabPremium")
                            DirectCast(pdffield, TallComponents.PDF.Forms.Fields.TextField).Value = "$" & ds4.Tables(0).Rows(0).Item("RentPersLiabPrem").ToString().Replace("$", "")

                        End If
                    End If

                    If ds4.Tables(0).Rows(0).Item("RentFullRepair").ToString().Replace("$", "") = "Yes" Then
                        pdffield = myPDFFields.Fields("MHFireDesc")
                        DirectCast(pdffield, TallComponents.PDF.Forms.Fields.TextField).Value = "Full Repair"
                        'pdffield = myPDFFields.Fields("MHContentsLimit")
                        'DirectCast(pdffield, TallComponents.PDF.Forms.Fields.TextField).Value = "$" & ds4.Tables(0).Rows(0).Item("RentPerLiab").ToString().Replace("$", "")
                        pdffield = myPDFFields.Fields("MHFirePremium")
                        DirectCast(pdffield, TallComponents.PDF.Forms.Fields.TextField).Value = "$" & ds4.Tables(0).Rows(0).Item("RentFullRepairPrem").ToString().Replace("$", "")

                    End If

                    If ds4.Tables(0).Rows(0).Item("RentMedPay").ToString().Replace("$", "") > "0.00" Then
                        pdffield = myPDFFields.Fields("MHMedPayDesc")
                        DirectCast(pdffield, TallComponents.PDF.Forms.Fields.TextField).Value = "Medical Payments"
                        pdffield = myPDFFields.Fields("MHMedPayLimit")
                        DirectCast(pdffield, TallComponents.PDF.Forms.Fields.TextField).Value = "$" & ds4.Tables(0).Rows(0).Item("RentMedPay").ToString().Replace("$", "")
                        'pdffield = myPDFFields.Fields("MHMedPayPremium")
                        'DirectCast(pdffield, TallComponents.PDF.Forms.Fields.TextField).Value = "$" & ds4.Tables(0).Rows(0).Item("RentMedPrem").ToString().Replace("$", "")

                    End If
                    'pdffield = myPDFFields.Fields("MHNDDesc")
                    'DirectCast(pdffield, TallComponents.PDF.Forms.Fields.TextField).Value = "Tax"
                    'pdffield = myPDFFields.Fields("MHNDPremium")
                    'DirectCast(pdffield, TallComponents.PDF.Forms.Fields.TextField).Value = "$" & ds4.Tables(0).Rows(0).Item("RentTax").ToString().Replace("$", "")

                Case "Aegis Vintage"
                    pdffield = myPDFFields.Fields("MHDwellLimit")
                    DirectCast(pdffield, TallComponents.PDF.Forms.Fields.TextField).Value = CInt(ds4.Tables(0).Rows(0).Item("VintDwell").ToString())

                    'pdffield = myPDFFields.Fields("MHPerPropLimit")
                    'DirectCast(pdffield, TallComponents.PDF.Forms.Fields.TextField).Value = CInt(ds4.Tables(0).Rows(0).Item("VintCont").ToString())


                    pdffield = myPDFFields.Fields("MHDwellPremium")
                    DirectCast(pdffield, TallComponents.PDF.Forms.Fields.TextField).Value = CInt(ds4.Tables(0).Rows(0).Item("VintBaseprem").ToString()) '- CInt(ds3.Tables(0).Rows(0).Item("VintHur").ToString()) - CInt(ds3.Tables(0).Rows(0).Item("VintNonHur").ToString())

                    pdffield = myPDFFields.Fields("MHDedDesc")
                    DirectCast(pdffield, TallComponents.PDF.Forms.Fields.TextField).Value = "AOP Deductible"
                    pdffield = myPDFFields.Fields("MHDedLimit")
                    DirectCast(pdffield, TallComponents.PDF.Forms.Fields.TextField).Value = "$500" ' & ds4.Tables(0).Rows(0).Item("VintAOP").ToString().Replace("$", "")

                    ' VintardTotal += CInt(ds4.Tables(0).Rows(0).Item("VintBasePrem").ToString()) ' - CInt(ds3.Tables(0).Rows(0).Item("VintHur").ToString()) - CInt(ds3.Tables(0).Rows(0).Item("VintNonHur").ToString())
                    'If IsNumeric(ds4.Tables(0).Rows(0).Item("VintAOP").ToString().Replace("$", "")) Then

                    '    If CInt(ds4.Tables(0).Rows(0).Item("VintAOP").ToString().Replace("$", "")) > 500 Then
                    '        pdffield = myPDFFields.Fields("MHDedDesc")
                    '        DirectCast(pdffield, TallComponents.PDF.Forms.Fields.TextField).Value = "Deductible Change Option AOP"
                    '        pdffield = myPDFFields.Fields("MHDedPremium")
                    '        DirectCast(pdffield, TallComponents.PDF.Forms.Fields.TextField).Value = "($" & CInt(ds4.Tables(0).Rows(0).Item("VintAOPPrem").ToString()) & ")"
                    '        pdffield = myPDFFields.Fields("MHDedLimit")
                    '        DirectCast(pdffield, TallComponents.PDF.Forms.Fields.TextField).Value = "$" & ds4.Tables(0).Rows(0).Item("VintAOP").ToString().Replace("$", "")

                    '    Else
                    '        pdffield = myPDFFields.Fields("MHDedLimit")
                    '        DirectCast(pdffield, TallComponents.PDF.Forms.Fields.TextField).Value = "$" & ds4.Tables(0).Rows(0).Item("VintAOP").ToString().Replace("$", "")

                    '        pdffield = myPDFFields.Fields("MHDedDesc")
                    '        DirectCast(pdffield, TallComponents.PDF.Forms.Fields.TextField).Value = "AOP Deductible"
                    '    End If


                    'End If



                    'pdffield = myPDFFields.Fields("MHPropRepPremiumLimit")
                    'DirectCast(pdffield, TallComponents.PDF.Forms.Fields.TextField).Value = ds4.Tables(0).Rows(0).Item("VintWind").ToString().Replace("$", "")
                    ''pdffield = myPDFFields.Fields("MHPropRepPremium")
                    ''DirectCast(pdffield, TallComponents.PDF.Forms.Fields.TextField).Value = "($" & CInt(ds3.Tables(0).Rows(0).Item("VintHur").ToString().Replace("$", "")) & ")"

                    pdffield = myPDFFields.Fields("Total Quoted Premium")
                    DirectCast(pdffield, TallComponents.PDF.Forms.Fields.TextField).Value = "$" & ds4.Tables(0).Rows(0).Item("Vinttotal").ToString().Replace("$", "")



                    'If ds4.Tables(0).Rows(0).Item("VintMHReplace").ToString().Replace("$", "") = "Yes" Then
                    '    pdffield = myPDFFields.Fields("MHRepCostDesc")
                    '    DirectCast(pdffield, TallComponents.PDF.Forms.Fields.TextField).Value = "Replacement Cost for Mobile Home"
                    '    pdffield = myPDFFields.Fields("MHRepCostPremium")
                    '    DirectCast(pdffield, TallComponents.PDF.Forms.Fields.TextField).Value = "$" & ds4.Tables(0).Rows(0).Item("VintMHReplacePrem").ToString().Replace("$", "")

                    'End If
                    If ds4.Tables(0).Rows(0).Item("VintContPrem").ToString().Replace("$", "") > "0" Then
                        pdffield = myPDFFields.Fields("MobileHomePersonalProp")
                        DirectCast(pdffield, TallComponents.PDF.Forms.Fields.TextField).Value = "Contents"
                        pdffield = myPDFFields.Fields("MHPerPropLimit")
                        DirectCast(pdffield, TallComponents.PDF.Forms.Fields.TextField).Value = "$" & ds4.Tables(0).Rows(0).Item("VintCont").ToString().Replace("$", "")
                        pdffield = myPDFFields.Fields("MHPerPropPremium")
                        DirectCast(pdffield, TallComponents.PDF.Forms.Fields.TextField).Value = "$" & ds4.Tables(0).Rows(0).Item("VintContPrem").ToString().Replace("$", "")

                    End If
                    Dim test As String
                    test = ds4.Tables(0).Rows(0).Item("VintStruc").ToString().Replace("$", "")
                    If ds4.Tables(0).Rows(0).Item("VintStruc").ToString().Replace("$", "") <> "0.00" Then
                        pdffield = myPDFFields.Fields("MHAddStrucDesc")
                        DirectCast(pdffield, TallComponents.PDF.Forms.Fields.TextField).Value = "Other Structures"
                        pdffield = myPDFFields.Fields("MHAddStrucLimit")
                        DirectCast(pdffield, TallComponents.PDF.Forms.Fields.TextField).Value = "$" & ds4.Tables(0).Rows(0).Item("VintStruc").ToString().Replace("$", "")
                        pdffield = myPDFFields.Fields("MHAddStrucPremium")
                        DirectCast(pdffield, TallComponents.PDF.Forms.Fields.TextField).Value = "$" & ds4.Tables(0).Rows(0).Item("VintStrucPrem").ToString().Replace("$", "")

                    End If
                    If ds4.Tables(0).Rows(0).Item("VintLiab").ToString().Replace("$", "") <> "" Then
                        If ds4.Tables(0).Rows(0).Item("VintLiab").ToString().Replace("$", "") <> "0" Then
                            pdffield = myPDFFields.Fields("MHPerLiabDesc")
                            DirectCast(pdffield, TallComponents.PDF.Forms.Fields.TextField).Value = "Premises Liability"
                            pdffield = myPDFFields.Fields("MHPerLiabLimit")
                            DirectCast(pdffield, TallComponents.PDF.Forms.Fields.TextField).Value = "$" & ds4.Tables(0).Rows(0).Item("VintLiab").ToString().Replace("$", "").Replace(",", "")
                            ' pdffield = myPDFFields.Fields("MHPerLiabPremium")
                            'DirectCast(pdffield, TallComponents.PDF.Forms.Fields.TextField).Value = "$" & ds4.Tables(0).Rows(0).Item("VintLiabPrem").ToString().Replace("$", "")

                        End If
                    End If

                    pdffield = myPDFFields.Fields("MHMedPayDesc")
                    DirectCast(pdffield, TallComponents.PDF.Forms.Fields.TextField).Value = "Medical Payments"
                    pdffield = myPDFFields.Fields("MHMedPayLimit")
                    DirectCast(pdffield, TallComponents.PDF.Forms.Fields.TextField).Value = "$500" ' & ds4.Tables(0).Rows(0).Item("VintMedPay").ToString().Replace("$", "")
                    '       

                    'If ds4.Tables(0).Rows(0).Item("VintMedPay").ToString().Replace("$", "") > "0.00" Then
                    '    pdffield = myPDFFields.Fields("MHMedPayDesc")
                    '    DirectCast(pdffield, TallComponents.PDF.Forms.Fields.TextField).Value = "Medical Payments"
                    '    pdffield = myPDFFields.Fields("MHMedPayLimit")
                    '    DirectCast(pdffield, TallComponents.PDF.Forms.Fields.TextField).Value = "$" & ds4.Tables(0).Rows(0).Item("VintMedPay").ToString().Replace("$", "")
                    '    'pdffield = myPDFFields.Fields("MHMedPayPremium")
                    '    'DirectCast(pdffield, TallComponents.PDF.Forms.Fields.TextField).Value = "$" & ds4.Tables(0).Rows(0).Item("VintMedPrem").ToString().Replace("$", "")

                    'End If






                Case "SMH Package"
                    pdffield = myPDFFields.Fields("MHAddResDesc")
                    DirectCast(pdffield, TallComponents.PDF.Forms.Fields.TextField).Value = "Loss of Use"

                    pdffield = myPDFFields.Fields("MHAddResLimit")
                    DirectCast(pdffield, TallComponents.PDF.Forms.Fields.TextField).Value = "1000"

                    pdffield = myPDFFields.Fields("MHDwellLimit")
                    DirectCast(pdffield, TallComponents.PDF.Forms.Fields.TextField).Value = CInt(ds4.Tables(0).Rows(0).Item("SMHPackDwel").ToString())

                    'pdffield = myPDFFields.Fields("MHPerPropLimit")
                    'DirectCast(pdffield, TallComponents.PDF.Forms.Fields.TextField).Value = CInt(ds4.Tables(0).Rows(0).Item("SMHPackCont").ToString())


                    pdffield = myPDFFields.Fields("MHDwellPremium")
                    DirectCast(pdffield, TallComponents.PDF.Forms.Fields.TextField).Value = CInt(ds4.Tables(0).Rows(0).Item("SMHPackprem").ToString()) '- CInt(ds3.Tables(0).Rows(0).Item("SMHPackHur").ToString()) - CInt(ds3.Tables(0).Rows(0).Item("SMHPackNonHur").ToString())
                    ' PackardTotal += CInt(ds4.Tables(0).Rows(0).Item("SMHPackBasePrem").ToString()) ' - CInt(ds3.Tables(0).Rows(0).Item("SMHPackHur").ToString()) - CInt(ds3.Tables(0).Rows(0).Item("SMHPackNonHur").ToString())
                    If CInt(ds4.Tables(0).Rows(0).Item("SMHPackAOP").ToString().Replace("$", "")) > 1000 Then
                        pdffield = myPDFFields.Fields("MHDedDesc")
                        DirectCast(pdffield, TallComponents.PDF.Forms.Fields.TextField).Value = "AOP Deductible" '"Deductible Change Option AOP"
                        pdffield = myPDFFields.Fields("MHDedPremium")
                        DirectCast(pdffield, TallComponents.PDF.Forms.Fields.TextField).Value = "($" & CInt(ds4.Tables(0).Rows(0).Item("SMHPackAOPPrem").ToString()) & ")"
                    Else
                        pdffield = myPDFFields.Fields("MHDedDesc")
                        DirectCast(pdffield, TallComponents.PDF.Forms.Fields.TextField).Value = "AOP Deductible"
                        pdffield = myPDFFields.Fields("MHDedPremium")
                        DirectCast(pdffield, TallComponents.PDF.Forms.Fields.TextField).Value = CInt(ds4.Tables(0).Rows(0).Item("SMHPackAOPPrem").ToString())
                    End If


                    pdffield = myPDFFields.Fields("MHDedLimit")
                    DirectCast(pdffield, TallComponents.PDF.Forms.Fields.TextField).Value = "$" & ds4.Tables(0).Rows(0).Item("SMHPackAOP").ToString().Replace("$", "")

                    ' PackTotal -= CInt(ds3.Tables(0).Rows(0).Item("SMHPackNonHur").ToString())


                    pdffield = myPDFFields.Fields("MHPropRepDesc")
                    DirectCast(pdffield, TallComponents.PDF.Forms.Fields.TextField).Value = "Wind Hail Deductible:"

                    pdffield = myPDFFields.Fields("MHPropRepPremiumLimit")
                    DirectCast(pdffield, TallComponents.PDF.Forms.Fields.TextField).Value = ds4.Tables(0).Rows(0).Item("SMHPackWind").ToString().Replace("$", "")
                    'pdffield = myPDFFields.Fields("MHPropRepPremium")
                    'DirectCast(pdffield, TallComponents.PDF.Forms.Fields.TextField).Value = "($" & CInt(ds3.Tables(0).Rows(0).Item("SMHPackHur").ToString().Replace("$", "")) & ")"

                    'Hurricane/Tropical Storm

                    pdffield = myPDFFields.Fields("MHRepCostDesc")
                    DirectCast(pdffield, TallComponents.PDF.Forms.Fields.TextField).Value = "Hurricane / Tropical Storm Deductible:"

                    pdffield = myPDFFields.Fields("MHPropCostPremlimit")
                    DirectCast(pdffield, TallComponents.PDF.Forms.Fields.TextField).Value = ds4.Tables(0).Rows(0).Item("SMHPackWind").ToString().Replace("$", "")
                    'Enhancement coverage
                    If IsNumeric(ds4.Tables(0).Rows(0).Item("SMHPackFullRepair").ToString().Replace("$", "")) Then


                        pdffield = myPDFFields.Fields("MHRadioDesc")
                        DirectCast(pdffield, TallComponents.PDF.Forms.Fields.TextField).Value = "Enhancement Coverage"

                        pdffield = myPDFFields.Fields("MHRadioLimit")
                        DirectCast(pdffield, TallComponents.PDF.Forms.Fields.TextField).Value = ds4.Tables(0).Rows(0).Item("SMHPackFullRepair").ToString().Replace("$", "")

                        pdffield = myPDFFields.Fields("MHRadioPremium")
                        DirectCast(pdffield, TallComponents.PDF.Forms.Fields.TextField).Value = ds4.Tables(0).Rows(0).Item("SMHPackFullRepairPrem").ToString().Replace("$", "")

                    End If



                    pdffield = myPDFFields.Fields("Total Quoted Premium")
                    DirectCast(pdffield, TallComponents.PDF.Forms.Fields.TextField).Value = "$" & ds4.Tables(0).Rows(0).Item("SMHPacktotal").ToString().Replace("$", "")

                    If ds4.Tables(0).Rows(0).Item("SMHPackContReplacePrem").ToString().Replace("$", "") <> "0" Then

                        pdffield = myPDFFields.Fields("MHContentsdesc")
                        DirectCast(pdffield, TallComponents.PDF.Forms.Fields.TextField).Value = "Contents Replacement Cost"

                        pdffield = myPDFFields.Fields("MHContentsLimit")
                        DirectCast(pdffield, TallComponents.PDF.Forms.Fields.TextField).Value = ds4.Tables(0).Rows(0).Item("SMHPackCont").ToString().Replace("$", "")

                        pdffield = myPDFFields.Fields("MHContentsPremium")
                        DirectCast(pdffield, TallComponents.PDF.Forms.Fields.TextField).Value = ds4.Tables(0).Rows(0).Item("SMHPackContReplacePrem").ToString().Replace("$", "")

                    End If
                    If ds.Tables(0).Rows(0).Item("homeUse").ToString() = "Seasonal" Then
                        pdffield = myPDFFields.Fields("MHFeeDesc1")
                        DirectCast(pdffield, TallComponents.PDF.Forms.Fields.TextField).Value = "Seasonal Surcharge"
                        pdffield = myPDFFields.Fields("MHFeeAmount1")
                        DirectCast(pdffield, TallComponents.PDF.Forms.Fields.TextField).Value = "$20"
                        pdffield = myPDFFields.Fields("MHSIPDesc")
                        DirectCast(pdffield, TallComponents.PDF.Forms.Fields.TextField).Value = "Policy Fee"
                        pdffield = myPDFFields.Fields("MHSIPPremium")
                        DirectCast(pdffield, TallComponents.PDF.Forms.Fields.TextField).Value = "$" & ds4.Tables(0).Rows(0).Item("SMHPackFees").ToString().Replace("$", "") - 20
                        If ds4.Tables(0).Rows(0).Item("SMHPackCreditPerc").ToString().Replace("$", "") > "0" Then
                            pdffield = myPDFFields.Fields("MHFeeDesc2")
                            DirectCast(pdffield, TallComponents.PDF.Forms.Fields.TextField).Value = "Credit Percentage " & CDbl(ds4.Tables(0).Rows(0).Item("SMHPackCreditPerc").ToString().Replace("$", "")) * 100 & " %"
                            pdffield = myPDFFields.Fields("MHFeeAmount2")
                            DirectCast(pdffield, TallComponents.PDF.Forms.Fields.TextField).Value = "($-" & ds4.Tables(0).Rows(0).Item("SMHPackCreditamt").ToString().Replace("$", "") & ")"

                        End If
                    Else
                        pdffield = myPDFFields.Fields("MHSIPDesc")
                        DirectCast(pdffield, TallComponents.PDF.Forms.Fields.TextField).Value = " Policy Fee"
                        pdffield = myPDFFields.Fields("MHSIPPremium")
                        DirectCast(pdffield, TallComponents.PDF.Forms.Fields.TextField).Value = "$" & ds4.Tables(0).Rows(0).Item("SMHPackFees").ToString().Replace("$", "")

                        If ds4.Tables(0).Rows(0).Item("SMHPackCreditPerc").ToString().Replace("$", "") > "0" Then
                            pdffield = myPDFFields.Fields("MHFeeDesc2")
                            DirectCast(pdffield, TallComponents.PDF.Forms.Fields.TextField).Value = "Credit Percentage " & CDbl(ds4.Tables(0).Rows(0).Item("SMHPackCreditPerc").ToString().Replace("$", "")) * 100 & " %"
                            pdffield = myPDFFields.Fields("MHFeeAmount2")
                            DirectCast(pdffield, TallComponents.PDF.Forms.Fields.TextField).Value = "($-" & ds4.Tables(0).Rows(0).Item("SMHPackCreditamt").ToString().Replace("$", "") & ")"

                        End If

                    End If
                    If ds4.Tables(0).Rows(0).Item("SMHPackMHReplace").ToString().Replace("$", "") = "Yes" Then
                        pdffield = myPDFFields.Fields("MHFireDesc")
                        DirectCast(pdffield, TallComponents.PDF.Forms.Fields.TextField).Value = "Replacement Cost for Mobile Home"
                        pdffield = myPDFFields.Fields("MHFirePremium")
                        DirectCast(pdffield, TallComponents.PDF.Forms.Fields.TextField).Value = "$" & ds4.Tables(0).Rows(0).Item("SMHPackMHReplacePrem").ToString().Replace("$", "")

                    End If
                    'If ds4.Tables(0).Rows(0).Item("SMHPackContPrem").ToString().Replace("$", "") > "0" Then
                    pdffield = myPDFFields.Fields("MobileHomePersonalProp")
                    DirectCast(pdffield, TallComponents.PDF.Forms.Fields.TextField).Value = "Contents"
                    pdffield = myPDFFields.Fields("MHPerPropLimit")
                    DirectCast(pdffield, TallComponents.PDF.Forms.Fields.TextField).Value = "$" & ds4.Tables(0).Rows(0).Item("SMHPackCont").ToString().Replace("$", "")
                    pdffield = myPDFFields.Fields("MHPerPropPremium")
                    DirectCast(pdffield, TallComponents.PDF.Forms.Fields.TextField).Value = "$" & ds4.Tables(0).Rows(0).Item("SMHPackContPrem").ToString().Replace("$", "")

                    'End If

                    If ds4.Tables(0).Rows(0).Item("SMHPackStruc").ToString().Replace("$", "") <> "0.00" Then
                        pdffield = myPDFFields.Fields("MHAddStrucDesc")
                        DirectCast(pdffield, TallComponents.PDF.Forms.Fields.TextField).Value = "Other Structures"
                        pdffield = myPDFFields.Fields("MHAddStrucLimit")
                        DirectCast(pdffield, TallComponents.PDF.Forms.Fields.TextField).Value = "$" & ds4.Tables(0).Rows(0).Item("SMHPackStruc").ToString().Replace("$", "")
                        pdffield = myPDFFields.Fields("MHAddStrucPremium")
                        DirectCast(pdffield, TallComponents.PDF.Forms.Fields.TextField).Value = "$" & ds4.Tables(0).Rows(0).Item("SMHPackStrucPrem").ToString().Replace("$", "")

                    End If
                    If ds4.Tables(0).Rows(0).Item("SMHPackPerLiab").ToString().Replace("$", "") <> "0" Then
                        pdffield = myPDFFields.Fields("MHPerLiabDesc")
                        DirectCast(pdffield, TallComponents.PDF.Forms.Fields.TextField).Value = "Personal Liability"
                        pdffield = myPDFFields.Fields("MHPerLiabLimit")
                        DirectCast(pdffield, TallComponents.PDF.Forms.Fields.TextField).Value = "$" & ds4.Tables(0).Rows(0).Item("SMHPackPerLiab").ToString().Replace("$", "").Replace(",", "")
                        pdffield = myPDFFields.Fields("MHPerLiabPremium")
                        DirectCast(pdffield, TallComponents.PDF.Forms.Fields.TextField).Value = "$" & ds4.Tables(0).Rows(0).Item("SMHPackPersLiabPrem").ToString().Replace("$", "")

                    End If


                    If ds4.Tables(0).Rows(0).Item("SMHPackFullRepair").ToString().Replace("$", "") = "Yes" Then
                        pdffield = myPDFFields.Fields("MHFireDesc")
                        DirectCast(pdffield, TallComponents.PDF.Forms.Fields.TextField).Value = "Full Repair"
                        'pdffield = myPDFFields.Fields("MHContentsLimit")
                        'DirectCast(pdffield, TallComponents.PDF.Forms.Fields.TextField).Value = "$" & ds4.Tables(0).Rows(0).Item("SMHPackPerLiab").ToString().Replace("$", "")
                        pdffield = myPDFFields.Fields("MHFirePremium")
                        DirectCast(pdffield, TallComponents.PDF.Forms.Fields.TextField).Value = "$" & ds4.Tables(0).Rows(0).Item("SMHPackFullRepairPrem").ToString().Replace("$", "")

                    End If


                    pdffield = myPDFFields.Fields("MHNDDesc")
                    DirectCast(pdffield, TallComponents.PDF.Forms.Fields.TextField).Value = "Tax"
                    pdffield = myPDFFields.Fields("MHNDPremium")
                    DirectCast(pdffield, TallComponents.PDF.Forms.Fields.TextField).Value = "$" & ds4.Tables(0).Rows(0).Item("SMHPackTax").ToString().Replace("$", "")
                    If ds4.Tables(0).Rows(0).Item("SMHPackMedPay").ToString().Replace("$", "") > "0.00" Then
                        pdffield = myPDFFields.Fields("MHMedPayDesc")
                        DirectCast(pdffield, TallComponents.PDF.Forms.Fields.TextField).Value = "Medical Payments"
                        pdffield = myPDFFields.Fields("MHMedPayLimit")
                        DirectCast(pdffield, TallComponents.PDF.Forms.Fields.TextField).Value = "$" & ds4.Tables(0).Rows(0).Item("SMHPackMedPay").ToString().Replace("$", "")
                        pdffield = myPDFFields.Fields("MHMedPayPremium")
                        DirectCast(pdffield, TallComponents.PDF.Forms.Fields.TextField).Value = "$" & ds4.Tables(0).Rows(0).Item("SMHPackMedPrem").ToString().Replace("$", "")

                    End If
                    pdffield = myPDFFields.Fields("MHFeeDesc")
                    DirectCast(pdffield, TallComponents.PDF.Forms.Fields.TextField).Value = "Expense Constant"
                    pdffield = myPDFFields.Fields("MHFeeAmount")
                    DirectCast(pdffield, TallComponents.PDF.Forms.Fields.TextField).Value = "$45"

            End Select
           
            'Dim Quotetotal As Integer
            'Quotetotal += PackTotal
            'If IsNumeric(dsRate.Tables(0).Rows(0).Item("PerPropPrem").ToString()) Then
            '    Quotetotal += CInt(dsRate.Tables(0).Rows(0).Item("PerPropPrem").ToString())
            'End If
            'If IsNumeric(dsRate.Tables(0).Rows(0).Item("AddStrucPrem").ToString()) Then
            '    Quotetotal += CInt(dsRate.Tables(0).Rows(0).Item("AddStrucPrem").ToString())
            'End If
            'If IsNumeric(dsRate.Tables(0).Rows(0).Item("LiabPrem").ToString()) Then
            '    Quotetotal += CInt(dsRate.Tables(0).Rows(0).Item("LiabPrem").ToString())
            'End If
            'If IsNumeric(dsRate.Tables(0).Rows(0).Item("FirePrem").ToString()) Then
            '    Quotetotal += CInt(dsRate.Tables(0).Rows(0).Item("FirePrem").ToString())
            'End If
            'If IsNumeric(dsRate.Tables(0).Rows(0).Item("RadioPrem").ToString()) Then
            '    Quotetotal += CInt(dsRate.Tables(0).Rows(0).Item("RadioPrem").ToString())
            'End If





            'Quotetotal += CInt(PackTotal * 0.01)
            'Quotetotal += CInt(PackTotal * 0.013)
            'Quotetotal += 25
            'Quotetotal += 2

            'pdffield = myPDFFields.Fields("Total Quoted Premium")
            'DirectCast(pdffield, TallComponents.PDF.Forms.Fields.TextField).Value = Quotetotal


            For Each field As TallComponents.PDF.Forms.Fields.Field In myPDFFields.Fields
                For Each widget As Widget In field.Widgets
                    widget.Persistency = WidgetPersistency.Flatten
                Next
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
    Public Sub printWMJQuote(ByVal ds As Data.DataSet, ByVal ds4 As Data.DataSet)
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

            Dim pdffield As TallComponents.PDF.Forms.Fields.Field
            pdffield = myPDFFields.Fields("QuoteNum")
            DirectCast(pdffield, TallComponents.PDF.Forms.Fields.TextField).Value = ds.Tables(0).Rows(0).Item("quoteID").ToString()

            pdffield = myPDFFields.Fields("QuoteTerm")
            DirectCast(pdffield, TallComponents.PDF.Forms.Fields.TextField).Value = ds.Tables(0).Rows(0).Item("term").ToString()


            pdffield = myPDFFields.Fields("QuoteNumdate")
            DirectCast(pdffield, TallComponents.PDF.Forms.Fields.TextField).Value = Date.Now.ToString("MM/dd/yyyy") 'ds.Tables(0).Rows(0).Item("quoteID").ToString()

            pdffield = myPDFFields.Fields("QuoteEffDate")
            DirectCast(pdffield, TallComponents.PDF.Forms.Fields.TextField).Value = ds.Tables(0).Rows(0).Item("effDate").ToString()

            pdffield = myPDFFields.Fields("QuoteCompany")
            DirectCast(pdffield, TallComponents.PDF.Forms.Fields.TextField).Value = "" & ds.Tables(0).Rows(0).Item("ARRateType").ToString()



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
                        value = ds.Tables(0).Rows(0).Item("AgentPhone").ToString()
                        DirectCast(myPDFField, TallComponents.PDF.Forms.Fields.TextField).Value = "(800) 628- 3762" 'value
                        'Client Section
                    Case "ClientName"
                        value = UCase(ds.Tables(0).Rows(0).Item("applicantFirstName").ToString()) + " " + UCase(ds.Tables(0).Rows(0).Item("applicantLastName").ToString())
                        DirectCast(myPDFField, TallComponents.PDF.Forms.Fields.TextField).Value = value
                    Case "ClientAddr1"
                        value = UCase(ds.Tables(0).Rows(0).Item("propAddress").ToString())
                        DirectCast(myPDFField, TallComponents.PDF.Forms.Fields.TextField).Value = value
                    Case "ClientAddr2"
                        value = ""
                        DirectCast(myPDFField, TallComponents.PDF.Forms.Fields.TextField).Value = value
                    Case "ClientCSZ"
                        value = ds.Tables(0).Rows(0).Item("city").ToString() + " " + ds.Tables(0).Rows(0).Item("state").ToString() + " " + ds.Tables(0).Rows(0).Item("zip").ToString()
                        DirectCast(myPDFField, TallComponents.PDF.Forms.Fields.TextField).Value = UCase(value)
                    Case "ClientPhone"
                        value = ""
                        DirectCast(myPDFField, TallComponents.PDF.Forms.Fields.TextField).Value = value
                        'Sub Information
                    Case "SubName"
                        value = ds.Tables(0).Rows(0).Item("AgencyName").ToString()
                        DirectCast(myPDFField, TallComponents.PDF.Forms.Fields.TextField).Value = UCase(value) & "     " & ds.Tables(0).Rows(0).Item("AgencyCode").ToString()

                    Case "SubAddr1"
                        value = ds.Tables(0).Rows(0).Item("AgentAddr1").ToString()
                        DirectCast(myPDFField, TallComponents.PDF.Forms.Fields.TextField).Value = UCase(value)
                    Case "SubAddr2"
                        value = UCase(ds.Tables(0).Rows(0).Item("AgentAddr2").ToString())
                        DirectCast(myPDFField, TallComponents.PDF.Forms.Fields.TextField).Value = value
                    Case "SubCSZ"
                        value = ds.Tables(0).Rows(0).Item("AgentCity").ToString() & ", " & ds.Tables(0).Rows(0).Item("AgentState").ToString() & " " & ds.Tables(0).Rows(0).Item("AgentZip").ToString()
                        DirectCast(myPDFField, TallComponents.PDF.Forms.Fields.TextField).Value = UCase(value)
                    Case "SubPhone"
                        value = ds.Tables(0).Rows(0).Item("AgentPhone").ToString()
                        DirectCast(myPDFField, TallComponents.PDF.Forms.Fields.TextField).Value = UCase(value)


                        'Unit Information
                    Case "Year"
                        value = ds.Tables(0).Rows(0).Item("year").ToString()
                        DirectCast(myPDFField, TallComponents.PDF.Forms.Fields.TextField).Value = value
                    Case "Model"
                        value = ds.Tables(0).Rows(0).Item("homeType").ToString()
                        DirectCast(myPDFField, TallComponents.PDF.Forms.Fields.TextField).Value = UCase(value)
                    Case "Length"
                        value = ds.Tables(0).Rows(0).Item("length").ToString()
                        DirectCast(myPDFField, TallComponents.PDF.Forms.Fields.TextField).Value = value
                    Case "Value"
                        value = ds4.Tables(0).Rows(0).Item("PackDwel").ToString()
                        DirectCast(myPDFField, TallComponents.PDF.Forms.Fields.TextField).Value = value
                    Case "Make"
                        value = ds.Tables(0).Rows(0).Item("manf").ToString()
                        DirectCast(myPDFField, TallComponents.PDF.Forms.Fields.TextField).Value = UCase(value)
                    Case "RatingState"
                        value = ds.Tables(0).Rows(0).Item("state").ToString()
                        DirectCast(myPDFField, TallComponents.PDF.Forms.Fields.TextField).Value = UCase(value)
                    Case "Width"
                        value = ds.Tables(0).Rows(0).Item("width").ToString()
                        DirectCast(myPDFField, TallComponents.PDF.Forms.Fields.TextField).Value = value
                    Case "UseOfUnit"
                        value = ds.Tables(0).Rows(0).Item("homeUse").ToString()
                        DirectCast(myPDFField, TallComponents.PDF.Forms.Fields.TextField).Value = UCase(value)

                    Case "MobileHomeDesc"
                        value = "Mobile Home"
                        DirectCast(myPDFField, TallComponents.PDF.Forms.Fields.TextField).Value = value






                End Select


            Next
            Dim PackTotal As Integer

            Select Case Left(ds.Tables(0).Rows(0).Item("ARRateType").ToString(), 3)
                Case "WMJ"


                    pdffield = myPDFFields.Fields("MHDwellLimit")
                    DirectCast(pdffield, TallComponents.PDF.Forms.Fields.TextField).Value = CInt(ds4.Tables(0).Rows(0).Item("PackDwel").ToString())

                    'pdffield = myPDFFields.Fields("MHPerPropLimit")
                    'DirectCast(pdffield, TallComponents.PDF.Forms.Fields.TextField).Value = CInt(ds4.Tables(0).Rows(0).Item("PackCont").ToString())


                    pdffield = myPDFFields.Fields("MHDwellPremium")
                    DirectCast(pdffield, TallComponents.PDF.Forms.Fields.TextField).Value = CInt(ds4.Tables(0).Rows(0).Item("Packprem").ToString()) '- CInt(ds3.Tables(0).Rows(0).Item("PackHur").ToString()) - CInt(ds3.Tables(0).Rows(0).Item("PackNonHur").ToString())
                    ' PackardTotal += CInt(ds4.Tables(0).Rows(0).Item("PackBasePrem").ToString()) ' - CInt(ds3.Tables(0).Rows(0).Item("PackHur").ToString()) - CInt(ds3.Tables(0).Rows(0).Item("PackNonHur").ToString())
                    If CInt(ds4.Tables(0).Rows(0).Item("PackAOP").ToString().Replace("$", "")) > 500 Then
                        pdffield = myPDFFields.Fields("MHDedDesc")
                        DirectCast(pdffield, TallComponents.PDF.Forms.Fields.TextField).Value = "Deductible Change Option AOP"
                        pdffield = myPDFFields.Fields("MHDedPremium")
                        DirectCast(pdffield, TallComponents.PDF.Forms.Fields.TextField).Value = "($" & CInt(ds4.Tables(0).Rows(0).Item("PackAOPPrem").ToString()) & ")"
                    Else
                        pdffield = myPDFFields.Fields("MHDedDesc")
                        DirectCast(pdffield, TallComponents.PDF.Forms.Fields.TextField).Value = "AOP Deductible"
                    End If


                    pdffield = myPDFFields.Fields("MHDedLimit")
                    DirectCast(pdffield, TallComponents.PDF.Forms.Fields.TextField).Value = "$" & ds4.Tables(0).Rows(0).Item("PackAOP").ToString().Replace("$", "")



                    pdffield = myPDFFields.Fields("Total Quoted Premium")
                    DirectCast(pdffield, TallComponents.PDF.Forms.Fields.TextField).Value = "$" & ds4.Tables(0).Rows(0).Item("Packtotal").ToString().Replace("$", "")

                    If ds4.Tables(0).Rows(0).Item("PackContReplace").ToString().Replace("$", "") = "Yes" Then

                        pdffield = myPDFFields.Fields("MHContentsdesc")
                        DirectCast(pdffield, TallComponents.PDF.Forms.Fields.TextField).Value = "Contents Replacement Cost"

                        pdffield = myPDFFields.Fields("MHContentsLimit")
                        DirectCast(pdffield, TallComponents.PDF.Forms.Fields.TextField).Value = ds4.Tables(0).Rows(0).Item("PackCont").ToString().Replace("$", "")

                        pdffield = myPDFFields.Fields("MHContentsPremium")
                        DirectCast(pdffield, TallComponents.PDF.Forms.Fields.TextField).Value = ds4.Tables(0).Rows(0).Item("PackContReplacePrem").ToString().Replace("$", "")

                    End If
                    'If ds.Tables(0).Rows(0).Item("homeUse").ToString() = "Seasonal" Then
                    '    pdffield = myPDFFields.Fields("MHFeeDesc1")
                    '    DirectCast(pdffield, TallComponents.PDF.Forms.Fields.TextField).Value = "Seasonal Surcharge"
                    '    pdffield = myPDFFields.Fields("MHFeeAmount1")
                    '    DirectCast(pdffield, TallComponents.PDF.Forms.Fields.TextField).Value = "$20"
                    '    pdffield = myPDFFields.Fields("MHFeeDesc")
                    '    DirectCast(pdffield, TallComponents.PDF.Forms.Fields.TextField).Value = "Supplemental Heating Surcharge"
                    '    pdffield = myPDFFields.Fields("MHFeeAmount")
                    '    DirectCast(pdffield, TallComponents.PDF.Forms.Fields.TextField).Value = "$" & ds4.Tables(0).Rows(0).Item("PackFees").ToString().Replace("$", "") - 20
                    '    If ds4.Tables(0).Rows(0).Item("PackCreditPerc").ToString().Replace("$", "") > "0" Then
                    '        pdffield = myPDFFields.Fields("MHFeeDesc2")
                    '        DirectCast(pdffield, TallComponents.PDF.Forms.Fields.TextField).Value = "Credit Percentage " & CDbl(ds4.Tables(0).Rows(0).Item("PackCreditPerc").ToString().Replace("$", "")) * 100 & " %"
                    '        pdffield = myPDFFields.Fields("MHFeeAmount2")
                    '        DirectCast(pdffield, TallComponents.PDF.Forms.Fields.TextField).Value = "($-" & ds4.Tables(0).Rows(0).Item("PackCreditamt").ToString().Replace("$", "") & ")"

                    '    End If
                    'Else
                    '    If IsNumeric(ds4.Tables(0).Rows(0).Item("PackFees").ToString().Replace("$", "")) Then
                    '        If CInt(ds4.Tables(0).Rows(0).Item("PackFees").ToString().Replace("$", "")) > 0 Then
                    '            pdffield = myPDFFields.Fields("MHFeeDesc")
                    '            DirectCast(pdffield, TallComponents.PDF.Forms.Fields.TextField).Value = "Supplemental Heating Surcharge"
                    '            pdffield = myPDFFields.Fields("MHFeeAmount")
                    '            DirectCast(pdffield, TallComponents.PDF.Forms.Fields.TextField).Value = "$" & ds4.Tables(0).Rows(0).Item("PackFees").ToString().Replace("$", "")

                    '        End If
                    '    End If


                    '    If ds4.Tables(0).Rows(0).Item("PackCreditamt").ToString().Replace("$", "") < "0" Then
                    '        pdffield = myPDFFields.Fields("MHFeeDesc1")
                    '        DirectCast(pdffield, TallComponents.PDF.Forms.Fields.TextField).Value = "No Lien Credit " '& CDbl(ds4.Tables(0).Rows(0).Item("PackCreditPerc").ToString().Replace("$", "")) * 100 & " %"
                    '        pdffield = myPDFFields.Fields("MHFeeAmount1")
                    '        DirectCast(pdffield, TallComponents.PDF.Forms.Fields.TextField).Value = "$" & ds4.Tables(0).Rows(0).Item("PackCreditamt").ToString().Replace("$", "")

                    '    End If

                    'End If
                    'If ds4.Tables(0).Rows(0).Item("PackMHReplace").ToString().Replace("$", "") = "Yes" Then
                    '    pdffield = myPDFFields.Fields("MHFireDesc")
                    '    DirectCast(pdffield, TallComponents.PDF.Forms.Fields.TextField).Value = "Replacement Cost for Mobile Home"
                    '    pdffield = myPDFFields.Fields("MHFirePremium")
                    '    DirectCast(pdffield, TallComponents.PDF.Forms.Fields.TextField).Value = "$" & ds4.Tables(0).Rows(0).Item("PackMHReplacePrem").ToString().Replace("$", "")

                    'End If
                    'If ds4.Tables(0).Rows(0).Item("PackContPrem").ToString().Replace("$", "") > "0" Then
                    pdffield = myPDFFields.Fields("MobileHomePersonalProp")
                    DirectCast(pdffield, TallComponents.PDF.Forms.Fields.TextField).Value = "Contents"
                    pdffield = myPDFFields.Fields("MHPerPropLimit")
                    DirectCast(pdffield, TallComponents.PDF.Forms.Fields.TextField).Value = "$" & ds4.Tables(0).Rows(0).Item("PackCont").ToString().Replace("$", "")
                    pdffield = myPDFFields.Fields("MHPerPropPremium")
                    DirectCast(pdffield, TallComponents.PDF.Forms.Fields.TextField).Value = "$" & ds4.Tables(0).Rows(0).Item("PackContPrem").ToString().Replace("$", "")

                    ' End If

                    If ds4.Tables(0).Rows(0).Item("PackStruc").ToString().Replace("$", "") <> "0.00" Then
                        pdffield = myPDFFields.Fields("MHAddStrucDesc")
                        DirectCast(pdffield, TallComponents.PDF.Forms.Fields.TextField).Value = "Other Structures"
                        pdffield = myPDFFields.Fields("MHAddStrucLimit")
                        DirectCast(pdffield, TallComponents.PDF.Forms.Fields.TextField).Value = "$" & ds4.Tables(0).Rows(0).Item("PackStruc").ToString().Replace("$", "")
                        pdffield = myPDFFields.Fields("MHAddStrucPremium")
                        DirectCast(pdffield, TallComponents.PDF.Forms.Fields.TextField).Value = "$" & ds4.Tables(0).Rows(0).Item("PackStrucPrem").ToString().Replace("$", "")

                    End If
                    If ds4.Tables(0).Rows(0).Item("PackPerLiab").ToString().Replace("$", "") <> "0" Then
                        pdffield = myPDFFields.Fields("MHPerLiabDesc")
                        DirectCast(pdffield, TallComponents.PDF.Forms.Fields.TextField).Value = "Personal Liability"
                        pdffield = myPDFFields.Fields("MHPerLiabLimit")
                        DirectCast(pdffield, TallComponents.PDF.Forms.Fields.TextField).Value = "$" & ds4.Tables(0).Rows(0).Item("PackPerLiab").ToString().Replace("$", "").Replace(",", "")
                        pdffield = myPDFFields.Fields("MHPerLiabPremium")
                        DirectCast(pdffield, TallComponents.PDF.Forms.Fields.TextField).Value = "$" & ds4.Tables(0).Rows(0).Item("PackPersLiabPrem").ToString().Replace("$", "")

                    End If


                    If ds4.Tables(0).Rows(0).Item("PackFullRepair").ToString().Replace("$", "") = "Yes" Then
                        pdffield = myPDFFields.Fields("MHFireDesc")
                        DirectCast(pdffield, TallComponents.PDF.Forms.Fields.TextField).Value = "Full Repair"
                        'pdffield = myPDFFields.Fields("MHContentsLimit")
                        'DirectCast(pdffield, TallComponents.PDF.Forms.Fields.TextField).Value = "$" & ds4.Tables(0).Rows(0).Item("PackPerLiab").ToString().Replace("$", "")
                        pdffield = myPDFFields.Fields("MHFirePremium")
                        DirectCast(pdffield, TallComponents.PDF.Forms.Fields.TextField).Value = "$" & ds4.Tables(0).Rows(0).Item("PackFullRepairPrem").ToString().Replace("$", "")

                    End If


                    pdffield = myPDFFields.Fields("MHNDDesc")
                    DirectCast(pdffield, TallComponents.PDF.Forms.Fields.TextField).Value = "Tax"
                    pdffield = myPDFFields.Fields("MHNDPremium")
                    DirectCast(pdffield, TallComponents.PDF.Forms.Fields.TextField).Value = "$" & ds4.Tables(0).Rows(0).Item("PackTax").ToString().Replace("$", "")
                    If ds4.Tables(0).Rows(0).Item("PackMedPay").ToString().Replace("$", "") > "0.00" Then
                        pdffield = myPDFFields.Fields("MHMedPayDesc")
                        DirectCast(pdffield, TallComponents.PDF.Forms.Fields.TextField).Value = "Medical Payments"
                        pdffield = myPDFFields.Fields("MHMedPayLimit")
                        DirectCast(pdffield, TallComponents.PDF.Forms.Fields.TextField).Value = "$" & ds4.Tables(0).Rows(0).Item("PackMedPay").ToString().Replace("$", "")
                        pdffield = myPDFFields.Fields("MHMedPayPremium")
                        DirectCast(pdffield, TallComponents.PDF.Forms.Fields.TextField).Value = "$" & ds4.Tables(0).Rows(0).Item("PackMedPrem").ToString().Replace("$", "")

                    End If


                    If ds4.Tables(0).Rows(0).Item("PackPPprem").ToString().Replace("$", "") <> "0.00" Then
                        pdffield = myPDFFields.Fields("MHWaterCraftDesc")
                        DirectCast(pdffield, TallComponents.PDF.Forms.Fields.TextField).Value = "Scheduled Personal Property"
                        pdffield = myPDFFields.Fields("MHWaterCraftLimit")
                        DirectCast(pdffield, TallComponents.PDF.Forms.Fields.TextField).Value = "$" & ds4.Tables(0).Rows(0).Item("PackPPlimit").ToString().Replace("$", "").Replace(",", "")
                        pdffield = myPDFFields.Fields("MHWaterCraftPremium")
                        DirectCast(pdffield, TallComponents.PDF.Forms.Fields.TextField).Value = "$" & ds4.Tables(0).Rows(0).Item("PackPPprem").ToString().Replace("$", "")

                    End If







            End Select



            For Each field As TallComponents.PDF.Forms.Fields.Field In myPDFFields.Fields
                For Each widget As Widget In field.Widgets
                    widget.Persistency = WidgetPersistency.Flatten
                Next
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
    Public Sub printAmslicQuote(ByVal ds As Data.DataSet, ByVal ds4 As Data.DataSet)


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

            Dim pdffield As TallComponents.PDF.Forms.Fields.Field
            pdffield = myPDFFields.Fields("QuoteNum")
            DirectCast(pdffield, TallComponents.PDF.Forms.Fields.TextField).Value = ds.Tables(0).Rows(0).Item("quoteID").ToString()

            pdffield = myPDFFields.Fields("QuoteTerm")
            DirectCast(pdffield, TallComponents.PDF.Forms.Fields.TextField).Value = ds.Tables(0).Rows(0).Item("term").ToString()


            pdffield = myPDFFields.Fields("QuoteNumdate")
            DirectCast(pdffield, TallComponents.PDF.Forms.Fields.TextField).Value = Date.Now.ToString("MM/dd/yyyy") 'ds.Tables(0).Rows(0).Item("quoteID").ToString()

            pdffield = myPDFFields.Fields("QuoteEffDate")
            DirectCast(pdffield, TallComponents.PDF.Forms.Fields.TextField).Value = ds.Tables(0).Rows(0).Item("effDate").ToString()

            pdffield = myPDFFields.Fields("QuoteCompany")
            DirectCast(pdffield, TallComponents.PDF.Forms.Fields.TextField).Value = "" & ds.Tables(0).Rows(0).Item("ARRateType").ToString()



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
                        value = ds.Tables(0).Rows(0).Item("AgentPhone").ToString()
                        DirectCast(myPDFField, TallComponents.PDF.Forms.Fields.TextField).Value = "(800) 628- 3762" 'value
                        'Client Section
                    Case "ClientName"
                        value = UCase(ds.Tables(0).Rows(0).Item("applicantFirstName").ToString()) + " " + UCase(ds.Tables(0).Rows(0).Item("applicantLastName").ToString())
                        DirectCast(myPDFField, TallComponents.PDF.Forms.Fields.TextField).Value = value
                    Case "ClientAddr1"
                        value = UCase(ds.Tables(0).Rows(0).Item("propAddress").ToString())
                        DirectCast(myPDFField, TallComponents.PDF.Forms.Fields.TextField).Value = value
                    Case "ClientAddr2"
                        value = ""
                        DirectCast(myPDFField, TallComponents.PDF.Forms.Fields.TextField).Value = value
                    Case "ClientCSZ"
                        value = ds.Tables(0).Rows(0).Item("city").ToString() + " " + ds.Tables(0).Rows(0).Item("state").ToString() + " " + ds.Tables(0).Rows(0).Item("zip").ToString()
                        DirectCast(myPDFField, TallComponents.PDF.Forms.Fields.TextField).Value = UCase(value)
                    Case "ClientPhone"
                        value = ""
                        DirectCast(myPDFField, TallComponents.PDF.Forms.Fields.TextField).Value = value
                        'Sub Information
                    Case "SubName"
                        value = ds.Tables(0).Rows(0).Item("AgencyName").ToString()
                        DirectCast(myPDFField, TallComponents.PDF.Forms.Fields.TextField).Value = UCase(value) & "     " & ds.Tables(0).Rows(0).Item("AgencyCode").ToString()

                    Case "SubAddr1"
                        value = ds.Tables(0).Rows(0).Item("AgentAddr1").ToString()
                        DirectCast(myPDFField, TallComponents.PDF.Forms.Fields.TextField).Value = UCase(value)
                    Case "SubAddr2"
                        value = UCase(ds.Tables(0).Rows(0).Item("AgentAddr2").ToString())
                        DirectCast(myPDFField, TallComponents.PDF.Forms.Fields.TextField).Value = value
                    Case "SubCSZ"
                        value = ds.Tables(0).Rows(0).Item("AgentCity").ToString() & ", " & ds.Tables(0).Rows(0).Item("AgentState").ToString() & " " & ds.Tables(0).Rows(0).Item("AgentZip").ToString()
                        DirectCast(myPDFField, TallComponents.PDF.Forms.Fields.TextField).Value = UCase(value)
                    Case "SubPhone"
                        value = ds.Tables(0).Rows(0).Item("AgentPhone").ToString()
                        DirectCast(myPDFField, TallComponents.PDF.Forms.Fields.TextField).Value = UCase(value)


                        'Unit Information
                    Case "Year"
                        value = ds.Tables(0).Rows(0).Item("year").ToString()
                        DirectCast(myPDFField, TallComponents.PDF.Forms.Fields.TextField).Value = value
                    Case "Model"
                        value = ds.Tables(0).Rows(0).Item("homeType").ToString()
                        DirectCast(myPDFField, TallComponents.PDF.Forms.Fields.TextField).Value = UCase(value)
                    Case "Length"
                        value = ds.Tables(0).Rows(0).Item("length").ToString()
                        DirectCast(myPDFField, TallComponents.PDF.Forms.Fields.TextField).Value = value
                    Case "Value"
                        value = ds4.Tables(0).Rows(0).Item("PackDwel").ToString()
                        DirectCast(myPDFField, TallComponents.PDF.Forms.Fields.TextField).Value = value
                    Case "Make"
                        value = ds.Tables(0).Rows(0).Item("manf").ToString()
                        DirectCast(myPDFField, TallComponents.PDF.Forms.Fields.TextField).Value = UCase(value)
                    Case "RatingState"
                        value = ds.Tables(0).Rows(0).Item("state").ToString()
                        DirectCast(myPDFField, TallComponents.PDF.Forms.Fields.TextField).Value = UCase(value)
                    Case "Width"
                        value = ds.Tables(0).Rows(0).Item("width").ToString()
                        DirectCast(myPDFField, TallComponents.PDF.Forms.Fields.TextField).Value = value
                    Case "UseOfUnit"
                        value = ds.Tables(0).Rows(0).Item("homeUse").ToString()
                        DirectCast(myPDFField, TallComponents.PDF.Forms.Fields.TextField).Value = UCase(value)

                    Case "MobileHomeDesc"
                        value = "Mobile Home"
                        DirectCast(myPDFField, TallComponents.PDF.Forms.Fields.TextField).Value = value
                        'Case "MHDwellLimit"
                        '    value = ds2.Tables(0).Rows(0).Item("StandDwel").ToString()
                        '    DirectCast(myPDFField, TallComponents.PDF.Forms.Fields.TextField).Value = CInt(value)
                        'Case "MHDwellPremium"
                        '    value = FormatCurrency(dsRate.Tables(0).Rows(0).Item("DwellingPrem").ToString())
                        '    DirectCast(myPDFField, TallComponents.PDF.Forms.Fields.TextField).Value = String.Format("{0:C0}", Math.Round(CDbl(value.Replace("$", ""))))

                        'Case "MobileHomePersonalProp"
                        '    'value = "Personal Property"
                        '    value = "Contents"
                        '    DirectCast(myPDFField, TallComponents.PDF.Forms.Fields.TextField).Value = value
                        'Case "MHPerPropLimit"
                        '    value = dsRate.Tables(0).Rows(0).Item("PerPropLimit").ToString()
                        '    DirectCast(myPDFField, TallComponents.PDF.Forms.Fields.TextField).Value = CInt(value)
                        'Case "MHPerPropPremium"
                        '    If dsRate.Tables(0).Rows(0).Item("PerPropPrem") = "INCLUDED" Then
                        '        value = dsRate.Tables(0).Rows(0).Item("PerPropPrem").ToString()
                        '    Else
                        '        value = FormatCurrency(dsRate.Tables(0).Rows(0).Item("PerPropPrem").ToString())
                        '        value = String.Format("{0:C0}", Math.Round(CDbl(value.Replace("$", ""))))
                        '    End If

                        ' DirectCast(myPDFField, TallComponents.PDF.Forms.Fields.TextField).Value = value


                        'Case "MHAddStrucDesc"
                        '    ' value = "Adjacent Structures"
                        '    value = "Other Structures"
                        '    DirectCast(myPDFField, TallComponents.PDF.Forms.Fields.TextField).Value = value
                        'Case "MHAddStrucLimit"
                        '    value = dsrate.Tables(0).Rows(0).Item("AddStrucLimit").ToString()
                        '    DirectCast(myPDFField, TallComponents.PDF.Forms.Fields.TextField).Value = CInt(value)
                        'Case "MHAddStrucPremium"
                        '    If dsrate.Tables(0).Rows(0).Item("AddStrucPrem").ToString() = "INCLUDED" Then
                        '        value = dsrate.Tables(0).Rows(0).Item("AddStrucPrem").ToString()
                        '    Else
                        '        value = FormatCurrency(dsrate.Tables(0).Rows(0).Item("AddStrucPrem").ToString())
                        '        value = String.Format("{0:C0}", Math.Round(CDbl(value.Replace("$", ""))))
                        '    End If
                        '    DirectCast(myPDFField, TallComponents.PDF.Forms.Fields.TextField).Value = value

                        'Case "MHPerLiabDesc"
                        '    value = "Personal Liability"
                        '    DirectCast(myPDFField, TallComponents.PDF.Forms.Fields.TextField).Value = value.Replace("$", "")
                        '    'Case "MHPerLiabLimit"
                        '    value = dsrate.Tables(0).Rows(0).Item("LiabLimit").ToString()
                        '    DirectCast(myPDFField, TallComponents.PDF.Forms.Fields.TextField).Value = value.Replace("$", "")
                        'Case "MHPerLiabPremium"
                        '    value = FormatCurrency(dsrate.Tables(0).Rows(0).Item("LiabPrem").ToString())
                        '    DirectCast(myPDFField, TallComponents.PDF.Forms.Fields.TextField).Value = String.Format("{0:C0}", Math.Round(CDbl(value.Replace("$", ""))))

                        'Case "MHDedDesc"
                        '    value = "Deductible Change Option"
                        '    DirectCast(myPDFField, TallComponents.PDF.Forms.Fields.TextField).Value = value
                        'Case "MHDedPremium"
                        '    value = FormatCurrency(dsRate.Tables(0).Rows(0).Item("DedPrem").ToString())
                        '    DirectCast(myPDFField, TallComponents.PDF.Forms.Fields.TextField).Value = String.Format("{0:C0}", Math.Round(CDbl(value)))

                        'Case "MHPropRepDesc"
                        '    value = dsrate.Tables(0).Rows(0).Item("PerPropRepPrem").ToString()
                        '    If value = "" Then
                        '        value = ""
                        '    Else
                        '        value = "Contents Replacement Cost"
                        '    End If
                        '    DirectCast(myPDFField, TallComponents.PDF.Forms.Fields.TextField).Value = value.Replace("$", "")
                        'Case "MHPropRepPremium"
                        '    value = dsrate.Tables(0).Rows(0).Item("PerPropRepPrem").ToString()
                        '    If value = "" Then
                        '        value = ""
                        '    Else
                        '        value = FormatCurrency(dsrate.Tables(0).Rows(0).Item("PerPropRepPrem").ToString())
                        '        value = String.Format("{0:C0}", Math.Round(CDbl(value.Replace("$", ""))))
                        '    End If
                        '    DirectCast(myPDFField, TallComponents.PDF.Forms.Fields.TextField).Value = value.Replace("$", "")

                        'Case "MHRepCostDesc"
                        '    value = dsrate.Tables(0).Rows(0).Item("MHRepPrem").ToString()
                        '    If value = "" Then
                        '        value = ""
                        '    Else
                        '        value = "Replacement Cost for Mobile Home"
                        '    End If
                        '    DirectCast(myPDFField, TallComponents.PDF.Forms.Fields.TextField).Value = value
                        'Case "MHRepCostPremium"
                        '    value = dsrate.Tables(0).Rows(0).Item("MHRepPrem").ToString()
                        '    If value = "" Then
                        '        value = ""
                        '    Else
                        '        value = FormatCurrency(dsrate.Tables(0).Rows(0).Item("MHRepPrem").ToString())
                        '    End If
                        '    DirectCast(myPDFField, TallComponents.PDF.Forms.Fields.TextField).Value = value.Replace("$", "")

                        'Case "MHFireDesc"
                        '    value = dsrate.Tables(0).Rows(0).Item("FirePrem").ToString()
                        '    If value = "" Then
                        '        value = ""
                        '    Else
                        '        value = "Fire Department Service Charge"
                        '    End If
                        '    DirectCast(myPDFField, TallComponents.PDF.Forms.Fields.TextField).Value = value.Replace("$", "")
                        'Case "MHFireLimit"
                        '    value = dsrate.Tables(0).Rows(0).Item("FirePrem").ToString()
                        '    If value = "" Then
                        '        value = ""
                        '    Else
                        '        value = FormatCurrency(dsrate.Tables(0).Rows(0).Item("FireOpt").ToString())
                        '    End If
                        '    DirectCast(myPDFField, TallComponents.PDF.Forms.Fields.TextField).Value = value.Replace("$", "")
                        'Case "MHFirePremium"
                        '    value = dsrate.Tables(0).Rows(0).Item("FirePrem").ToString()
                        '    If value = "" Then
                        '        value = ""
                        '    Else
                        '        value = FormatCurrency(dsrate.Tables(0).Rows(0).Item("FirePrem").ToString())
                        '    End If
                        '    DirectCast(myPDFField, TallComponents.PDF.Forms.Fields.TextField).Value = value.Replace("$", "")
                        '    '    'Radio
                        'Case "MHRadioDesc"
                        '    value = dsrate.Tables(0).Rows(0).Item("RadioPrem").ToString()
                        '    If value = "" Then
                        '        value = ""
                        '    Else
                        '        value = "Radio & T.V. Charge"
                        '    End If
                        '    DirectCast(myPDFField, TallComponents.PDF.Forms.Fields.TextField).Value = value.Replace("$", "")
                        'Case "MHRadioLimit"
                        '    value = dsrate.Tables(0).Rows(0).Item("RadioPrem").ToString()
                        '    If value = "" Then
                        '        value = ""
                        '    Else
                        '        value = FormatCurrency(dsrate.Tables(0).Rows(0).Item("RadioOpt").ToString())
                        '    End If

                        '    DirectCast(myPDFField, TallComponents.PDF.Forms.Fields.TextField).Value = value.Replace("$", "")

                        'Case "MHRadioPremium"
                        '    value = dsrate.Tables(0).Rows(0).Item("RadioPrem").ToString()
                        '    If value = "" Then
                        '        value = ""
                        '    Else
                        '        value = FormatCurrency(dsrate.Tables(0).Rows(0).Item("RadioPrem").ToString())
                        '    End If
                        '    DirectCast(myPDFField, TallComponents.PDF.Forms.Fields.TextField).Value = value.Replace("$", "")
                        'Case "MHMedPayDesc"
                        '    value = dsrate.Tables(0).Rows(0).Item("MedPayOpt").ToString()
                        '    If value = "" Then
                        '        value = ""
                        '    Else
                        '        value = "Medical Payments"
                        '    End If

                        '    DirectCast(myPDFField, TallComponents.PDF.Forms.Fields.TextField).Value = value.Replace("$", "")
                        'Case "MHMedPayLimit"
                        '    value = dsrate.Tables(0).Rows(0).Item("MedPayOpt").ToString()
                        '    If value = "" Then
                        '        value = ""
                        '    Else
                        '        value = dsrate.Tables(0).Rows(0).Item("MedPayOpt").ToString()
                        '    End If
                        '    DirectCast(myPDFField, TallComponents.PDF.Forms.Fields.TextField).Value = "$" & value.Replace("$", "")

                        '    If dsrate.Tables(0).Rows(0).Item("MedPayOpt").ToString() = "$1000" Then
                        '        pdffield = myPDFFields.Fields("MHMedPayPremium")
                        '        DirectCast(pdffield, TallComponents.PDF.Forms.Fields.TextField).Value = "$5".Replace("$", "")


                        '    End If

                        'Case "MHRepCostDesc"
                        '    value = dsrate.Tables(0).Rows(0).Item("MedMHRepPrem").ToString()
                        '    If value = "" Then
                        '        value = ""
                        '    Else
                        '        value = "Mobile Home Replacement Cost"
                        '    End If
                        '    DirectCast(myPDFField, TallComponents.PDF.Forms.Fields.TextField).Value = value.Replace("$", "")

                        'Case "MHRepCostPrem"
                        '    value = dsrate.Tables(0).Rows(0).Item("MedMHRepPrem").ToString()
                        '    If value = "" Then
                        '        value = ""
                        '    Else
                        '        value = FormatCurrency(dsrate.Tables(0).Rows(0).Item("MedMHRepPrem").ToString())
                        '    End If
                        '    DirectCast(myPDFField, TallComponents.PDF.Forms.Fields.TextField).Value = value.Replace("$", "")
                        '    '    'Replacement Cost
                        'Case "MHPropRepDesc"
                        '    value = dsrate.Tables(0).Rows(0).Item("MedRepPrem").ToString()
                        '    If value = "" Then
                        '        value = ""
                        '    Else
                        '        value = "Contents Replacement Cost"
                        '    End If
                        '    DirectCast(myPDFField, TallComponents.PDF.Forms.Fields.TextField).Value = value.Replace("$", "")

                        'Case "MHPropRepPrem"
                        '    value = dsrate.Tables(0).Rows(0).Item("MedRepPrem").ToString()
                        '    If value = "" Then
                        '        value = ""
                        '    Else
                        '        value = FormatCurrency(dsrate.Tables(0).Rows(0).Item("MedMHRepPrem").ToString())
                        '    End If
                        '    DirectCast(myPDFField, TallComponents.PDF.Forms.Fields.TextField).Value = value.Replace("$", "")




                        'Case "MHFeeDesc"
                        '    value = "Fees"
                        '    DirectCast(myPDFField, TallComponents.PDF.Forms.Fields.TextField).Value = value
                        'Case "MHFeeAmount"
                        '    value = FormatCurrency(dsrate.Tables(0).Rows(0).Item("Fees").ToString())
                        '    DirectCast(myPDFField, TallComponents.PDF.Forms.Fields.TextField).Value = value

                        '    'Fire Department Service Charge

                End Select


            Next
            Dim PackTotal As Integer

            Select Case ds.Tables(0).Rows(0).Item("ARRateType").ToString()
                Case "AMSLIC Standard"
                    'pdffield = myPDFFields.Fields("MHAddResDesc")
                    'DirectCast(pdffield, TallComponents.PDF.Forms.Fields.TextField).Value = "Loss of Use"

                    'pdffield = myPDFFields.Fields("MHAddResLimit")
                    'DirectCast(pdffield, TallComponents.PDF.Forms.Fields.TextField).Value = "600"
                    'pdffield = myPDFFields.Fields("MHDwellLimit")
                    'DirectCast(pdffield, TallComponents.PDF.Forms.Fields.TextField).Value = CInt(ds4.Tables(0).Rows(0).Item("PackDwel").ToString())

                    'pdffield = myPDFFields.Fields("MHPerPropLimit")
                    'DirectCast(pdffield, TallComponents.PDF.Forms.Fields.TextField).Value = CInt(ds4.Tables(0).Rows(0).Item("PackCont").ToString())


                    'pdffield = myPDFFields.Fields("MHDwellPremium")
                    'DirectCast(pdffield, TallComponents.PDF.Forms.Fields.TextField).Value = CInt(ds4.Tables(0).Rows(0).Item("Packprem").ToString()) '- CInt(ds3.Tables(0).Rows(0).Item("PackHur").ToString()) - CInt(ds3.Tables(0).Rows(0).Item("PackNonHur").ToString())
                    'PackTotal += CInt(ds4.Tables(0).Rows(0).Item("PackBasePrem").ToString()) ' - CInt(ds3.Tables(0).Rows(0).Item("PackHur").ToString()) - CInt(ds3.Tables(0).Rows(0).Item("PackNonHur").ToString())

                    'pdffield = myPDFFields.Fields("MHDedDesc")
                    'DirectCast(pdffield, TallComponents.PDF.Forms.Fields.TextField).Value = "Deductible Change Option AOP"

                    'pdffield = myPDFFields.Fields("MHDedLimit")
                    'DirectCast(pdffield, TallComponents.PDF.Forms.Fields.TextField).Value = "$" & ds4.Tables(0).Rows(0).Item("PackAOP").ToString().Replace("$", "")
                    'pdffield = myPDFFields.Fields("MHDedPremium")
                    'DirectCast(pdffield, TallComponents.PDF.Forms.Fields.TextField).Value = "($" & CInt(ds4.Tables(0).Rows(0).Item("PackAOPPrem").ToString()) & ")"
                    '' PackTotal -= CInt(ds3.Tables(0).Rows(0).Item("PackNonHur").ToString())
                    'pdffield = myPDFFields.Fields("MHPropRepDesc")
                    'DirectCast(pdffield, TallComponents.PDF.Forms.Fields.TextField).Value = "Wind Hail Deductible:"

                    'pdffield = myPDFFields.Fields("MHPropRepPremiumLimit")
                    'DirectCast(pdffield, TallComponents.PDF.Forms.Fields.TextField).Value = ds4.Tables(0).Rows(0).Item("PackWind").ToString().Replace("$", "")
                    ''pdffield = myPDFFields.Fields("MHPropRepPremium")
                    ''DirectCast(pdffield, TallComponents.PDF.Forms.Fields.TextField).Value = "($" & CInt(ds3.Tables(0).Rows(0).Item("PackHur").ToString().Replace("$", "")) & ")"

                    'pdffield = myPDFFields.Fields("Total Quoted Premium")
                    'DirectCast(pdffield, TallComponents.PDF.Forms.Fields.TextField).Value = "$" & ds4.Tables(0).Rows(0).Item("Packtotal").ToString().Replace("$", "")

                    'If ds4.Tables(0).Rows(0).Item("PackContReplacePrem").ToString() <> "$0.00" Then

                    '    pdffield = myPDFFields.Fields("MHContentsdesc")
                    '    DirectCast(pdffield, TallComponents.PDF.Forms.Fields.TextField).Value = "Contents Replacement Cost"

                    '    pdffield = myPDFFields.Fields("MHContentsPremium")
                    '    DirectCast(pdffield, TallComponents.PDF.Forms.Fields.TextField).Value = ds4.Tables(0).Rows(0).Item("PackContReplacePrem").ToString().Replace("$", "")

                    'End If
                    'pdffield = myPDFFields.Fields("MHFeeDesc")
                    'DirectCast(pdffield, TallComponents.PDF.Forms.Fields.TextField).Value = "Fee"
                    'pdffield = myPDFFields.Fields("MHFeeAmount")
                    'DirectCast(pdffield, TallComponents.PDF.Forms.Fields.TextField).Value = "$" & ds4.Tables(0).Rows(0).Item("PackFees").ToString().Replace("$", "")
                    'If ds.Tables(0).Rows(0).Item("homeUse").ToString() = "Seasonal" Then
                    '    pdffield = myPDFFields.Fields("MHFeeDesc1")
                    '    DirectCast(pdffield, TallComponents.PDF.Forms.Fields.TextField).Value = "Seasonal Fee"
                    '    pdffield = myPDFFields.Fields("MHFeeAmount1")
                    '    DirectCast(pdffield, TallComponents.PDF.Forms.Fields.TextField).Value = "$20"
                    'End If
                    'If ds4.Tables(0).Rows(0).Item("PackFees").ToString().Replace("$", "") = "Yes" Then
                    '    pdffield = myPDFFields.Fields("MHRepCostDesc")
                    '    DirectCast(pdffield, TallComponents.PDF.Forms.Fields.TextField).Value = "Replacement Cost for Mobile Home"
                    '    pdffield = myPDFFields.Fields("MHRepCostPremium")
                    '    DirectCast(pdffield, TallComponents.PDF.Forms.Fields.TextField).Value = "$" & ds4.Tables(0).Rows(0).Item("PackMHReplacePrem").ToString().Replace("$", "")

                    'End If
                    ''-----
                    'If ds4.Tables(0).Rows(0).Item("PackCont").ToString().Replace("$", "") = "0.00" Then
                    '    pdffield = myPDFFields.Fields("MobileHomePersonalProp")
                    '    DirectCast(pdffield, TallComponents.PDF.Forms.Fields.TextField).Value = "Contents"
                    '    pdffield = myPDFFields.Fields("MHPerPropLimit")
                    '    DirectCast(pdffield, TallComponents.PDF.Forms.Fields.TextField).Value = "$" & ds4.Tables(0).Rows(0).Item("PackCont").ToString().Replace("$", "")
                    '    pdffield = myPDFFields.Fields("MHPerPropPremium")
                    '    DirectCast(pdffield, TallComponents.PDF.Forms.Fields.TextField).Value = "$" & ds4.Tables(0).Rows(0).Item("PackContPrem").ToString().Replace("$", "")

                    'End If

                    'If ds4.Tables(0).Rows(0).Item("PackStruc").ToString().Replace("$", "") = "0.00" Then
                    '    pdffield = myPDFFields.Fields("MHAddStrucDesc")
                    '    DirectCast(pdffield, TallComponents.PDF.Forms.Fields.TextField).Value = "Other Structures"
                    '    pdffield = myPDFFields.Fields("MHAddStrucLimit")
                    '    DirectCast(pdffield, TallComponents.PDF.Forms.Fields.TextField).Value = "$" & ds4.Tables(0).Rows(0).Item("PackStruc").ToString().Replace("$", "")
                    '    pdffield = myPDFFields.Fields("MHAddStrucPremium")
                    '    DirectCast(pdffield, TallComponents.PDF.Forms.Fields.TextField).Value = "$" & ds4.Tables(0).Rows(0).Item("PackStrucPrem").ToString().Replace("$", "")

                    'End If
                    'If ds4.Tables(0).Rows(0).Item("PackPerLiab").ToString().Replace("$", "") = "0.00" Then
                    '    pdffield = myPDFFields.Fields(" MHPerLiabDesc")
                    '    DirectCast(pdffield, TallComponents.PDF.Forms.Fields.TextField).Value = "Personal Liability"
                    '    pdffield = myPDFFields.Fields("MHPerLiabLimit")
                    '    DirectCast(pdffield, TallComponents.PDF.Forms.Fields.TextField).Value = "$" & ds4.Tables(0).Rows(0).Item("PackPerLiab").ToString().Replace("$", "")
                    '    pdffield = myPDFFields.Fields("MHPerLiabPremium")
                    '    DirectCast(pdffield, TallComponents.PDF.Forms.Fields.TextField).Value = "$" & ds4.Tables(0).Rows(0).Item("PackPersLiabPrem").ToString().Replace("$", "")

                    'End If
                    'If ds4.Tables(0).Rows(0).Item("PackMedPay").ToString().Replace("$", "") > "0.00" Then
                    '    pdffield = myPDFFields.Fields("MHMedPayDesc")
                    '    DirectCast(pdffield, TallComponents.PDF.Forms.Fields.TextField).Value = "Medical Payments"
                    '    pdffield = myPDFFields.Fields("MHMedPayLimit")
                    '    DirectCast(pdffield, TallComponents.PDF.Forms.Fields.TextField).Value = "$" & ds4.Tables(0).Rows(0).Item("PackMedPay").ToString().Replace("$", "")
                    '    pdffield = myPDFFields.Fields("MHMedPayPremium")
                    '    DirectCast(pdffield, TallComponents.PDF.Forms.Fields.TextField).Value = "$" & ds4.Tables(0).Rows(0).Item("PackMedPrem").ToString().Replace("$", "")

                    'End If

                    pdffield = myPDFFields.Fields("MHDwellLimit")
                    DirectCast(pdffield, TallComponents.PDF.Forms.Fields.TextField).Value = CInt(ds4.Tables(0).Rows(0).Item("PackDwel").ToString())

                    'pdffield = myPDFFields.Fields("MHPerPropLimit")
                    'DirectCast(pdffield, TallComponents.PDF.Forms.Fields.TextField).Value = CInt(ds4.Tables(0).Rows(0).Item("PackCont").ToString())


                    pdffield = myPDFFields.Fields("MHDwellPremium")
                    DirectCast(pdffield, TallComponents.PDF.Forms.Fields.TextField).Value = CInt(ds4.Tables(0).Rows(0).Item("Packprem").ToString()) '- CInt(ds3.Tables(0).Rows(0).Item("PackHur").ToString()) - CInt(ds3.Tables(0).Rows(0).Item("PackNonHur").ToString())
                    ' PackardTotal += CInt(ds4.Tables(0).Rows(0).Item("PackBasePrem").ToString()) ' - CInt(ds3.Tables(0).Rows(0).Item("PackHur").ToString()) - CInt(ds3.Tables(0).Rows(0).Item("PackNonHur").ToString())
                    If CInt(ds4.Tables(0).Rows(0).Item("PackAOP").ToString().Replace("$", "")) > 500 Then
                        pdffield = myPDFFields.Fields("MHDedDesc")
                        DirectCast(pdffield, TallComponents.PDF.Forms.Fields.TextField).Value = "Deductible Change Option AOP"
                        pdffield = myPDFFields.Fields("MHDedPremium")
                        DirectCast(pdffield, TallComponents.PDF.Forms.Fields.TextField).Value = "($" & CInt(ds4.Tables(0).Rows(0).Item("PackAOPPrem").ToString()) & ")"
                    Else
                        pdffield = myPDFFields.Fields("MHDedDesc")
                        DirectCast(pdffield, TallComponents.PDF.Forms.Fields.TextField).Value = "AOP Deductible"
                    End If


                    pdffield = myPDFFields.Fields("MHDedLimit")
                    DirectCast(pdffield, TallComponents.PDF.Forms.Fields.TextField).Value = "$" & ds4.Tables(0).Rows(0).Item("PackAOP").ToString().Replace("$", "")

                    ' PackTotal -= CInt(ds3.Tables(0).Rows(0).Item("PackNonHur").ToString())


                    pdffield = myPDFFields.Fields("MHPropRepDesc")
                    DirectCast(pdffield, TallComponents.PDF.Forms.Fields.TextField).Value = "Wind Hail Deductible:"

                    pdffield = myPDFFields.Fields("MHPropRepPremiumLimit")
                    DirectCast(pdffield, TallComponents.PDF.Forms.Fields.TextField).Value = CStr(CInt(ds4.Tables(0).Rows(0).Item("PackWind").ToString().Replace("$", "")).ToString("C0"))
                    'pdffield = myPDFFields.Fields("MHPropRepPremium")
                    'DirectCast(pdffield, TallComponents.PDF.Forms.Fields.TextField).Value = "($" & CInt(ds4.Tables(0).Rows(0).Item("PackWind").ToString().Replace("$", "")) & ")"

                    ' Hurricane/Tropical Storm

                    pdffield = myPDFFields.Fields("MHRepCostDesc")
                    DirectCast(pdffield, TallComponents.PDF.Forms.Fields.TextField).Value = "Hurricane / Tropical Storm Deductible:"

                    pdffield = myPDFFields.Fields("MHPropCostPremlimit")
                    DirectCast(pdffield, TallComponents.PDF.Forms.Fields.TextField).Value = ds4.Tables(0).Rows(0).Item("PackWind").ToString().Replace("$", "")


                    pdffield = myPDFFields.Fields("Total Quoted Premium")
                    DirectCast(pdffield, TallComponents.PDF.Forms.Fields.TextField).Value = "$" & ds4.Tables(0).Rows(0).Item("Packtotal").ToString().Replace("$", "")

                    If ds4.Tables(0).Rows(0).Item("PackContReplace").ToString().Replace("$", "") = "Yes" Then

                        pdffield = myPDFFields.Fields("MHContentsdesc")
                        DirectCast(pdffield, TallComponents.PDF.Forms.Fields.TextField).Value = "Contents Replacement Cost"

                        pdffield = myPDFFields.Fields("MHContentsLimit")
                        DirectCast(pdffield, TallComponents.PDF.Forms.Fields.TextField).Value = ds4.Tables(0).Rows(0).Item("PackCont").ToString().Replace("$", "")

                        pdffield = myPDFFields.Fields("MHContentsPremium")
                        DirectCast(pdffield, TallComponents.PDF.Forms.Fields.TextField).Value = ds4.Tables(0).Rows(0).Item("PackContReplacePrem").ToString().Replace("$", "")

                    End If
                    If ds.Tables(0).Rows(0).Item("homeUse").ToString() = "Seasonal" Then
                        pdffield = myPDFFields.Fields("MHFeeDesc1")
                        DirectCast(pdffield, TallComponents.PDF.Forms.Fields.TextField).Value = "Supplemental Heating Surcharge"  ' was "Policy Fee" changed per vickie 2/26/2014 '"Seasonal Surcharge"
                        pdffield = myPDFFields.Fields("MHFeeAmount1")
                        DirectCast(pdffield, TallComponents.PDF.Forms.Fields.TextField).Value = "$20"
                        pdffield = myPDFFields.Fields("MHFeeDesc")
                        DirectCast(pdffield, TallComponents.PDF.Forms.Fields.TextField).Value = "Policy Fee" ' was Supplemental Heating Surcharge --changed per vicke 2/26/2014
                        pdffield = myPDFFields.Fields("MHFeeAmount")
                        DirectCast(pdffield, TallComponents.PDF.Forms.Fields.TextField).Value = "$" & ds4.Tables(0).Rows(0).Item("PackFees").ToString().Replace("$", "") - 20
                        If ds4.Tables(0).Rows(0).Item("PackCreditPerc").ToString().Replace("$", "") > "0" Then
                            pdffield = myPDFFields.Fields("MHFeeDesc2")
                            DirectCast(pdffield, TallComponents.PDF.Forms.Fields.TextField).Value = "Credit Percentage " & CDbl(ds4.Tables(0).Rows(0).Item("PackCreditPerc").ToString().Replace("$", "")) * 100 & " %"
                            pdffield = myPDFFields.Fields("MHFeeAmount2")
                            DirectCast(pdffield, TallComponents.PDF.Forms.Fields.TextField).Value = "($-" & ds4.Tables(0).Rows(0).Item("PackCreditamt").ToString().Replace("$", "") & ")"

                        End If
                    Else
                        If IsNumeric(ds4.Tables(0).Rows(0).Item("PackFees").ToString().Replace("$", "")) Then
                            If CInt(ds4.Tables(0).Rows(0).Item("PackFees").ToString().Replace("$", "")) > 0 Then
                                pdffield = myPDFFields.Fields("MHFeeDesc")
                                DirectCast(pdffield, TallComponents.PDF.Forms.Fields.TextField).Value = "Fees"
                                pdffield = myPDFFields.Fields("MHFeeAmount")
                                DirectCast(pdffield, TallComponents.PDF.Forms.Fields.TextField).Value = "$" & ds4.Tables(0).Rows(0).Item("PackFees").ToString().Replace("$", "")

                            End If
                        End If


                        If ds4.Tables(0).Rows(0).Item("PackCreditamt").ToString().Replace("$", "") < "0" Then
                            pdffield = myPDFFields.Fields("MHFeeDesc1")
                            DirectCast(pdffield, TallComponents.PDF.Forms.Fields.TextField).Value = "No Lien Credit " '& CDbl(ds4.Tables(0).Rows(0).Item("PackCreditPerc").ToString().Replace("$", "")) * 100 & " %"
                            pdffield = myPDFFields.Fields("MHFeeAmount1")
                            DirectCast(pdffield, TallComponents.PDF.Forms.Fields.TextField).Value = "$" & ds4.Tables(0).Rows(0).Item("PackCreditamt").ToString().Replace("$", "")

                        End If

                    End If
                    If ds4.Tables(0).Rows(0).Item("PackMHReplace").ToString().Replace("$", "") = "Yes" Then
                        pdffield = myPDFFields.Fields("MHFireDesc")
                        DirectCast(pdffield, TallComponents.PDF.Forms.Fields.TextField).Value = "Replacement Cost for Mobile Home"
                        pdffield = myPDFFields.Fields("MHFirePremium")
                        DirectCast(pdffield, TallComponents.PDF.Forms.Fields.TextField).Value = "$" & ds4.Tables(0).Rows(0).Item("PackMHReplacePrem").ToString().Replace("$", "")

                    End If
                    'If ds4.Tables(0).Rows(0).Item("PackContPrem").ToString().Replace("$", "") > "0" Then
                    pdffield = myPDFFields.Fields("MobileHomePersonalProp")
                    DirectCast(pdffield, TallComponents.PDF.Forms.Fields.TextField).Value = "Contents"
                    pdffield = myPDFFields.Fields("MHPerPropLimit")
                    DirectCast(pdffield, TallComponents.PDF.Forms.Fields.TextField).Value = "$" & ds4.Tables(0).Rows(0).Item("PackCont").ToString().Replace("$", "")
                    pdffield = myPDFFields.Fields("MHPerPropPremium")
                    DirectCast(pdffield, TallComponents.PDF.Forms.Fields.TextField).Value = "$" & ds4.Tables(0).Rows(0).Item("PackContPrem").ToString().Replace("$", "")

                    ' End If

                    If ds4.Tables(0).Rows(0).Item("PackStruc").ToString().Replace("$", "") <> "0.00" Then
                        pdffield = myPDFFields.Fields("MHAddStrucDesc")
                        DirectCast(pdffield, TallComponents.PDF.Forms.Fields.TextField).Value = "Other Structures"
                        pdffield = myPDFFields.Fields("MHAddStrucLimit")
                        DirectCast(pdffield, TallComponents.PDF.Forms.Fields.TextField).Value = "$" & ds4.Tables(0).Rows(0).Item("PackStruc").ToString().Replace("$", "")
                        pdffield = myPDFFields.Fields("MHAddStrucPremium")
                        DirectCast(pdffield, TallComponents.PDF.Forms.Fields.TextField).Value = "$" & ds4.Tables(0).Rows(0).Item("PackStrucPrem").ToString().Replace("$", "")

                    End If
                    If ds4.Tables(0).Rows(0).Item("PackPerLiab").ToString().Replace("$", "") <> "0" Then
                        pdffield = myPDFFields.Fields("MHPerLiabDesc")
                        DirectCast(pdffield, TallComponents.PDF.Forms.Fields.TextField).Value = "Personal Liability"
                        pdffield = myPDFFields.Fields("MHPerLiabLimit")
                        DirectCast(pdffield, TallComponents.PDF.Forms.Fields.TextField).Value = "$" & ds4.Tables(0).Rows(0).Item("PackPerLiab").ToString().Replace("$", "").Replace(",", "")
                        pdffield = myPDFFields.Fields("MHPerLiabPremium")
                        DirectCast(pdffield, TallComponents.PDF.Forms.Fields.TextField).Value = "$" & ds4.Tables(0).Rows(0).Item("PackPersLiabPrem").ToString().Replace("$", "")

                    End If


                    If ds4.Tables(0).Rows(0).Item("PackFullRepair").ToString().Replace("$", "") = "Yes" Then
                        pdffield = myPDFFields.Fields("MHFireDesc")
                        DirectCast(pdffield, TallComponents.PDF.Forms.Fields.TextField).Value = "Full Repair"
                        'pdffield = myPDFFields.Fields("MHContentsLimit")
                        'DirectCast(pdffield, TallComponents.PDF.Forms.Fields.TextField).Value = "$" & ds4.Tables(0).Rows(0).Item("PackPerLiab").ToString().Replace("$", "")
                        pdffield = myPDFFields.Fields("MHFirePremium")
                        DirectCast(pdffield, TallComponents.PDF.Forms.Fields.TextField).Value = "$" & ds4.Tables(0).Rows(0).Item("PackFullRepairPrem").ToString().Replace("$", "")

                    End If


                    pdffield = myPDFFields.Fields("MHNDDesc")
                    DirectCast(pdffield, TallComponents.PDF.Forms.Fields.TextField).Value = "Tax"
                    pdffield = myPDFFields.Fields("MHNDPremium")
                    DirectCast(pdffield, TallComponents.PDF.Forms.Fields.TextField).Value = "$" & ds4.Tables(0).Rows(0).Item("PackTax").ToString().Replace("$", "")
                    If ds4.Tables(0).Rows(0).Item("PackMedPay").ToString().Replace("$", "") > "0.00" Then
                        pdffield = myPDFFields.Fields("MHMedPayDesc")
                        DirectCast(pdffield, TallComponents.PDF.Forms.Fields.TextField).Value = "Medical Payments"
                        pdffield = myPDFFields.Fields("MHMedPayLimit")
                        DirectCast(pdffield, TallComponents.PDF.Forms.Fields.TextField).Value = "$" & ds4.Tables(0).Rows(0).Item("PackMedPay").ToString().Replace("$", "")
                        pdffield = myPDFFields.Fields("MHMedPayPremium")
                        DirectCast(pdffield, TallComponents.PDF.Forms.Fields.TextField).Value = "$" & ds4.Tables(0).Rows(0).Item("PackMedPrem").ToString().Replace("$", "")

                    End If


                    'If ds4.Tables(0).Rows(0).Item("PackPPprem").ToString().Replace("$", "") <> "0.00" Then
                    '    pdffield = myPDFFields.Fields("MHWaterCraftDesc")
                    '    DirectCast(pdffield, TallComponents.PDF.Forms.Fields.TextField).Value = "Scheduled Personal Property"
                    '    pdffield = myPDFFields.Fields("MHWaterCraftLimit")
                    '    DirectCast(pdffield, TallComponents.PDF.Forms.Fields.TextField).Value = "$" & ds4.Tables(0).Rows(0).Item("PackPPlimit").ToString().Replace("$", "").Replace(",", "")
                    '    pdffield = myPDFFields.Fields("MHWaterCraftPremium")
                    '    DirectCast(pdffield, TallComponents.PDF.Forms.Fields.TextField).Value = "$" & ds4.Tables(0).Rows(0).Item("PackPPprem").ToString().Replace("$", "")

                    'End If





                    ' PackTotal -= CInt(ds3.Tables(0).Rows(0).Item("PackHur").ToString())
                Case "Aegis Standard1"
                    pdffield = myPDFFields.Fields("MHDwellLimit")
                    DirectCast(pdffield, TallComponents.PDF.Forms.Fields.TextField).Value = CInt(ds4.Tables(0).Rows(0).Item("StandDwel").ToString())

                    'pdffield = myPDFFields.Fields("MHPerPropLimit")
                    'DirectCast(pdffield, TallComponents.PDF.Forms.Fields.TextField).Value = CInt(ds4.Tables(0).Rows(0).Item("StandCont").ToString())


                    pdffield = myPDFFields.Fields("MHDwellPremium")
                    DirectCast(pdffield, TallComponents.PDF.Forms.Fields.TextField).Value = CInt(ds4.Tables(0).Rows(0).Item("Standprem").ToString()) '- CInt(ds3.Tables(0).Rows(0).Item("StandHur").ToString()) - CInt(ds3.Tables(0).Rows(0).Item("StandNonHur").ToString())
                    ' StandardTotal += CInt(ds4.Tables(0).Rows(0).Item("StandBasePrem").ToString()) ' - CInt(ds3.Tables(0).Rows(0).Item("StandHur").ToString()) - CInt(ds3.Tables(0).Rows(0).Item("StandNonHur").ToString())
                    If CInt(ds4.Tables(0).Rows(0).Item("StandAOP").ToString().Replace("$", "")) > 500 Then
                        pdffield = myPDFFields.Fields("MHDedDesc")
                        DirectCast(pdffield, TallComponents.PDF.Forms.Fields.TextField).Value = "Deductible Change Option AOP"
                        pdffield = myPDFFields.Fields("MHDedPremium")
                        DirectCast(pdffield, TallComponents.PDF.Forms.Fields.TextField).Value = "($" & CInt(ds4.Tables(0).Rows(0).Item("StandAOPPrem").ToString()) & ")"
                    Else
                        pdffield = myPDFFields.Fields("MHDedDesc")
                        DirectCast(pdffield, TallComponents.PDF.Forms.Fields.TextField).Value = "AOP Deductible"
                    End If


                    pdffield = myPDFFields.Fields("MHDedLimit")
                    DirectCast(pdffield, TallComponents.PDF.Forms.Fields.TextField).Value = "$" & ds4.Tables(0).Rows(0).Item("StandAOP").ToString().Replace("$", "")

                    ' StandTotal -= CInt(ds3.Tables(0).Rows(0).Item("StandNonHur").ToString())


                    pdffield = myPDFFields.Fields("MHPropRepDesc")
                    DirectCast(pdffield, TallComponents.PDF.Forms.Fields.TextField).Value = "Wind Hail Deductible:"

                    pdffield = myPDFFields.Fields("MHPropRepPremiumLimit")
                    DirectCast(pdffield, TallComponents.PDF.Forms.Fields.TextField).Value = ds4.Tables(0).Rows(0).Item("StandWind").ToString().Replace("$", "")
                    'pdffield = myPDFFields.Fields("MHPropRepPremium")
                    'DirectCast(pdffield, TallComponents.PDF.Forms.Fields.TextField).Value = "($" & CInt(ds3.Tables(0).Rows(0).Item("StandHur").ToString().Replace("$", "")) & ")"

                    pdffield = myPDFFields.Fields("Total Quoted Premium")
                    DirectCast(pdffield, TallComponents.PDF.Forms.Fields.TextField).Value = "$" & ds4.Tables(0).Rows(0).Item("Standtotal").ToString().Replace("$", "")

                    If ds4.Tables(0).Rows(0).Item("StandContReplacePrem").ToString() <> "0" Then

                        pdffield = myPDFFields.Fields("MHContentsdesc")
                        DirectCast(pdffield, TallComponents.PDF.Forms.Fields.TextField).Value = "Contents Replacement Cost"

                        pdffield = myPDFFields.Fields("MHContentsPremium")
                        DirectCast(pdffield, TallComponents.PDF.Forms.Fields.TextField).Value = ds4.Tables(0).Rows(0).Item("StandContReplacePrem").ToString().Replace("$", "")

                    End If
                    If ds.Tables(0).Rows(0).Item("homeUse").ToString() = "Seasonal" Then
                        pdffield = myPDFFields.Fields("MHFeeDesc1")
                        DirectCast(pdffield, TallComponents.PDF.Forms.Fields.TextField).Value = "Seasonal Surcharge"
                        pdffield = myPDFFields.Fields("MHFeeAmount1")
                        DirectCast(pdffield, TallComponents.PDF.Forms.Fields.TextField).Value = "$20"
                        pdffield = myPDFFields.Fields("MHSIPDesc")
                        DirectCast(pdffield, TallComponents.PDF.Forms.Fields.TextField).Value = "Policy Fee"
                        pdffield = myPDFFields.Fields("MHSIPPremium")
                        DirectCast(pdffield, TallComponents.PDF.Forms.Fields.TextField).Value = "$" & ds4.Tables(0).Rows(0).Item("StandFees").ToString().Replace("$", "") - 20
                        If ds4.Tables(0).Rows(0).Item("StandCreditPerc").ToString().Replace("$", "") > "0" Then
                            pdffield = myPDFFields.Fields("MHFeeDesc2")
                            DirectCast(pdffield, TallComponents.PDF.Forms.Fields.TextField).Value = "Credit Percentage " & CDbl(ds4.Tables(0).Rows(0).Item("StandCreditPerc").ToString().Replace("$", "")) * 100 & " %"
                            pdffield = myPDFFields.Fields("MHFeeAmount2")
                            DirectCast(pdffield, TallComponents.PDF.Forms.Fields.TextField).Value = "($-" & ds4.Tables(0).Rows(0).Item("StandCreditamt").ToString().Replace("$", "") & ")"

                        End If
                    Else
                        pdffield = myPDFFields.Fields("MHSIPDesc")
                        DirectCast(pdffield, TallComponents.PDF.Forms.Fields.TextField).Value = " Policy Fee"
                        pdffield = myPDFFields.Fields("MHSIPPremium")
                        DirectCast(pdffield, TallComponents.PDF.Forms.Fields.TextField).Value = "$" & ds4.Tables(0).Rows(0).Item("StandFees").ToString().Replace("$", "")

                        If ds4.Tables(0).Rows(0).Item("StandCreditPerc").ToString().Replace("$", "") > "0" Then
                            pdffield = myPDFFields.Fields("MHFeeDesc2")
                            DirectCast(pdffield, TallComponents.PDF.Forms.Fields.TextField).Value = "Credit Percentage " & CDbl(ds4.Tables(0).Rows(0).Item("StandCreditPerc").ToString().Replace("$", "")) * 100 & " %"
                            pdffield = myPDFFields.Fields("MHFeeAmount2")
                            DirectCast(pdffield, TallComponents.PDF.Forms.Fields.TextField).Value = "($-" & ds4.Tables(0).Rows(0).Item("StandCreditamt").ToString().Replace("$", "") & ")"

                        End If

                    End If
                    If ds4.Tables(0).Rows(0).Item("StandMHReplace").ToString().Replace("$", "") = "Yes" Then
                        pdffield = myPDFFields.Fields("MHRepCostDesc")
                        DirectCast(pdffield, TallComponents.PDF.Forms.Fields.TextField).Value = "Replacement Cost for Mobile Home"
                        pdffield = myPDFFields.Fields("MHRepCostPremium")
                        DirectCast(pdffield, TallComponents.PDF.Forms.Fields.TextField).Value = "$" & ds4.Tables(0).Rows(0).Item("StandMHReplacePrem").ToString().Replace("$", "")

                    End If
                    If ds4.Tables(0).Rows(0).Item("StandContPrem").ToString().Replace("$", "") > "0" Then
                        pdffield = myPDFFields.Fields("MobileHomePersonalProp")
                        DirectCast(pdffield, TallComponents.PDF.Forms.Fields.TextField).Value = "Contents"
                        pdffield = myPDFFields.Fields("MHPerPropLimit")
                        DirectCast(pdffield, TallComponents.PDF.Forms.Fields.TextField).Value = "$" & ds4.Tables(0).Rows(0).Item("StandCont").ToString().Replace("$", "")
                        pdffield = myPDFFields.Fields("MHPerPropPremium")
                        DirectCast(pdffield, TallComponents.PDF.Forms.Fields.TextField).Value = "$" & ds4.Tables(0).Rows(0).Item("StandContPrem").ToString().Replace("$", "")

                    End If

                    If ds4.Tables(0).Rows(0).Item("StandStruc").ToString().Replace("$", "") <> "0.00" Then
                        pdffield = myPDFFields.Fields("MHAddStrucDesc")
                        DirectCast(pdffield, TallComponents.PDF.Forms.Fields.TextField).Value = "Other Structures"
                        pdffield = myPDFFields.Fields("MHAddStrucLimit")
                        DirectCast(pdffield, TallComponents.PDF.Forms.Fields.TextField).Value = "$" & ds4.Tables(0).Rows(0).Item("StandStruc").ToString().Replace("$", "")
                        pdffield = myPDFFields.Fields("MHAddStrucPremium")
                        DirectCast(pdffield, TallComponents.PDF.Forms.Fields.TextField).Value = "$" & ds4.Tables(0).Rows(0).Item("StandStrucPrem").ToString().Replace("$", "")

                    End If
                    If ds4.Tables(0).Rows(0).Item("StandPerLiab").ToString().Replace("$", "") <> "0" Then
                        pdffield = myPDFFields.Fields("MHPerLiabDesc")
                        DirectCast(pdffield, TallComponents.PDF.Forms.Fields.TextField).Value = "Personal Liability"
                        pdffield = myPDFFields.Fields("MHPerLiabLimit")
                        DirectCast(pdffield, TallComponents.PDF.Forms.Fields.TextField).Value = "$" & ds4.Tables(0).Rows(0).Item("StandPerLiab").ToString().Replace("$", "").Replace(",", "")
                        pdffield = myPDFFields.Fields("MHPerLiabPremium")
                        DirectCast(pdffield, TallComponents.PDF.Forms.Fields.TextField).Value = "$" & ds4.Tables(0).Rows(0).Item("StandPersLiabPrem").ToString().Replace("$", "")

                    End If


                    If ds4.Tables(0).Rows(0).Item("StandFullRepair").ToString().Replace("$", "") = "Yes" Then
                        pdffield = myPDFFields.Fields("MHFireDesc")
                        DirectCast(pdffield, TallComponents.PDF.Forms.Fields.TextField).Value = "Full Repair"
                        'pdffield = myPDFFields.Fields("MHContentsLimit")
                        'DirectCast(pdffield, TallComponents.PDF.Forms.Fields.TextField).Value = "$" & ds4.Tables(0).Rows(0).Item("StandPerLiab").ToString().Replace("$", "")
                        pdffield = myPDFFields.Fields("MHFirePremium")
                        DirectCast(pdffield, TallComponents.PDF.Forms.Fields.TextField).Value = "$" & ds4.Tables(0).Rows(0).Item("StandFullRepairPrem").ToString().Replace("$", "")

                    End If


                    pdffield = myPDFFields.Fields("MHNDDesc")
                    DirectCast(pdffield, TallComponents.PDF.Forms.Fields.TextField).Value = "Tax"
                    pdffield = myPDFFields.Fields("MHNDPremium")
                    DirectCast(pdffield, TallComponents.PDF.Forms.Fields.TextField).Value = "$" & ds4.Tables(0).Rows(0).Item("StandTax").ToString().Replace("$", "")
                    If ds4.Tables(0).Rows(0).Item("StandMedPay").ToString().Replace("$", "") > "0.00" Then
                        pdffield = myPDFFields.Fields("MHMedPayDesc")
                        DirectCast(pdffield, TallComponents.PDF.Forms.Fields.TextField).Value = "Medical Payments"
                        pdffield = myPDFFields.Fields("MHMedPayLimit")
                        DirectCast(pdffield, TallComponents.PDF.Forms.Fields.TextField).Value = "$" & ds4.Tables(0).Rows(0).Item("StandMedPay").ToString().Replace("$", "")
                        pdffield = myPDFFields.Fields("MHMedPayPremium")
                        DirectCast(pdffield, TallComponents.PDF.Forms.Fields.TextField).Value = "$" & ds4.Tables(0).Rows(0).Item("StandMedPrem").ToString().Replace("$", "")

                    End If
                Case "AMSLIC Rental"
                    pdffield = myPDFFields.Fields("MHDwellLimit")
                    DirectCast(pdffield, TallComponents.PDF.Forms.Fields.TextField).Value = CInt(ds4.Tables(0).Rows(0).Item("RentDwel").ToString())

                    'pdffield = myPDFFields.Fields("MHPerPropLimit")
                    'DirectCast(pdffield, TallComponents.PDF.Forms.Fields.TextField).Value = CInt(ds4.Tables(0).Rows(0).Item("RentCont").ToString())


                    pdffield = myPDFFields.Fields("MHDwellPremium")
                    DirectCast(pdffield, TallComponents.PDF.Forms.Fields.TextField).Value = CInt(ds4.Tables(0).Rows(0).Item("Rentprem").ToString()) '- CInt(ds3.Tables(0).Rows(0).Item("RentHur").ToString()) - CInt(ds3.Tables(0).Rows(0).Item("RentNonHur").ToString())
                    ' RentardTotal += CInt(ds4.Tables(0).Rows(0).Item("RentBasePrem").ToString()) ' - CInt(ds3.Tables(0).Rows(0).Item("RentHur").ToString()) - CInt(ds3.Tables(0).Rows(0).Item("RentNonHur").ToString())
                    If IsNumeric(ds4.Tables(0).Rows(0).Item("RentAOP").ToString().Replace("$", "")) Then

                        If CInt(ds4.Tables(0).Rows(0).Item("RentAOP").ToString().Replace("$", "")) > 500 Then
                            pdffield = myPDFFields.Fields("MHDedDesc")
                            DirectCast(pdffield, TallComponents.PDF.Forms.Fields.TextField).Value = "Deductible Change Option AOP"
                            pdffield = myPDFFields.Fields("MHDedPremium")
                            DirectCast(pdffield, TallComponents.PDF.Forms.Fields.TextField).Value = "($" & CInt(ds4.Tables(0).Rows(0).Item("RentAOPPrem").ToString()) & ")"
                            pdffield = myPDFFields.Fields("MHDedLimit")
                            DirectCast(pdffield, TallComponents.PDF.Forms.Fields.TextField).Value = "$" & ds4.Tables(0).Rows(0).Item("RentAOP").ToString().Replace("$", "")

                        Else
                            pdffield = myPDFFields.Fields("MHDedLimit")
                            DirectCast(pdffield, TallComponents.PDF.Forms.Fields.TextField).Value = "$" & ds4.Tables(0).Rows(0).Item("RentAOP").ToString().Replace("$", "")

                            pdffield = myPDFFields.Fields("MHDedDesc")
                            DirectCast(pdffield, TallComponents.PDF.Forms.Fields.TextField).Value = "AOP Deductible"
                        End If


                    End If

                    ' RentTotal -= CInt(ds3.Tables(0).Rows(0).Item("RentNonHur").ToString())


                    'pdffield = myPDFFields.Fields("MHPropRepDesc")
                    'DirectCast(pdffield, TallComponents.PDF.Forms.Fields.TextField).Value = "Wind Hail Deductible:"

                    pdffield = myPDFFields.Fields("MHPropRepPremiumLimit")
                    DirectCast(pdffield, TallComponents.PDF.Forms.Fields.TextField).Value = ds4.Tables(0).Rows(0).Item("RentWind").ToString().Replace("$", "")
                    'pdffield = myPDFFields.Fields("MHPropRepPremium")
                    'DirectCast(pdffield, TallComponents.PDF.Forms.Fields.TextField).Value = "($" & CInt(ds3.Tables(0).Rows(0).Item("RentHur").ToString().Replace("$", "")) & ")"

                    pdffield = myPDFFields.Fields("Total Quoted Premium")
                    DirectCast(pdffield, TallComponents.PDF.Forms.Fields.TextField).Value = "$" & ds4.Tables(0).Rows(0).Item("Renttotal").ToString().Replace("$", "")

                    'If ds4.Tables(0).Rows(0).Item("RentContReplacePrem").ToString() <> "0" Then

                    '    pdffield = myPDFFields.Fields("MHContentsdesc")
                    '    DirectCast(pdffield, TallComponents.PDF.Forms.Fields.TextField).Value = "Contents Replacement Cost"

                    '    pdffield = myPDFFields.Fields("MHContentsPremium")
                    '    DirectCast(pdffield, TallComponents.PDF.Forms.Fields.TextField).Value = ds4.Tables(0).Rows(0).Item("RentContReplacePrem").ToString().Replace("$", "")

                    'End If
                    If ds.Tables(0).Rows(0).Item("homeUse").ToString() = "Seasonal" Then
                        pdffield = myPDFFields.Fields("MHFeeDesc1")
                        DirectCast(pdffield, TallComponents.PDF.Forms.Fields.TextField).Value = "Seasonal Surcharge"
                        pdffield = myPDFFields.Fields("MHFeeAmount1")
                        DirectCast(pdffield, TallComponents.PDF.Forms.Fields.TextField).Value = "$20"
                        pdffield = myPDFFields.Fields("MHSIPDesc")
                        DirectCast(pdffield, TallComponents.PDF.Forms.Fields.TextField).Value = "Expense Constant"
                        pdffield = myPDFFields.Fields("MHSIPPremium")
                        DirectCast(pdffield, TallComponents.PDF.Forms.Fields.TextField).Value = "$" & ds4.Tables(0).Rows(0).Item("RentFees").ToString().Replace("$", "")
                        'If ds4.Tables(0).Rows(0).Item("RentCreditPerc").ToString().Replace("$", "") > "0" Then
                        '    pdffield = myPDFFields.Fields("MHFeeDesc2")
                        '    DirectCast(pdffield, TallComponents.PDF.Forms.Fields.TextField).Value = "Credit Percentage " & CDbl(ds4.Tables(0).Rows(0).Item("RentCreditPerc").ToString().Replace("$", "")) * 100 & " %"
                        '    pdffield = myPDFFields.Fields("MHFeeAmount2")
                        '    DirectCast(pdffield, TallComponents.PDF.Forms.Fields.TextField).Value = "($-" & ds4.Tables(0).Rows(0).Item("RentCreditamt").ToString().Replace("$", "") & ")"

                        'End If
                    Else
                        pdffield = myPDFFields.Fields("MHSIPDesc")
                        DirectCast(pdffield, TallComponents.PDF.Forms.Fields.TextField).Value = "Expense Constant"
                        pdffield = myPDFFields.Fields("MHSIPPremium")
                        DirectCast(pdffield, TallComponents.PDF.Forms.Fields.TextField).Value = "$" & ds4.Tables(0).Rows(0).Item("RentFees").ToString().Replace("$", "")

                        'If ds4.Tables(0).Rows(0).Item("RentCreditPerc").ToString().Replace("$", "") > "0" Then
                        '    pdffield = myPDFFields.Fields("MHFeeDesc2")
                        '    DirectCast(pdffield, TallComponents.PDF.Forms.Fields.TextField).Value = "Credit Percentage " & CDbl(ds4.Tables(0).Rows(0).Item("RentCreditPerc").ToString().Replace("$", "")) * 100 & " %"
                        '    pdffield = myPDFFields.Fields("MHFeeAmount2")
                        '    DirectCast(pdffield, TallComponents.PDF.Forms.Fields.TextField).Value = "($-" & ds4.Tables(0).Rows(0).Item("RentCreditamt").ToString().Replace("$", "") & ")"

                        'End If

                    End If
                    If ds4.Tables(0).Rows(0).Item("RentMHReplace").ToString().Replace("$", "") = "Yes" Then
                        pdffield = myPDFFields.Fields("MHRepCostDesc")
                        DirectCast(pdffield, TallComponents.PDF.Forms.Fields.TextField).Value = "Replacement Cost for Mobile Home"
                        pdffield = myPDFFields.Fields("MHRepCostPremium")
                        DirectCast(pdffield, TallComponents.PDF.Forms.Fields.TextField).Value = "$" & ds4.Tables(0).Rows(0).Item("RentMHReplacePrem").ToString().Replace("$", "")

                    End If
                    If ds4.Tables(0).Rows(0).Item("RentContPrem").ToString().Replace("$", "") > "0" Then
                        pdffield = myPDFFields.Fields("MobileHomePersonalProp")
                        DirectCast(pdffield, TallComponents.PDF.Forms.Fields.TextField).Value = "Contents"
                        pdffield = myPDFFields.Fields("MHPerPropLimit")
                        DirectCast(pdffield, TallComponents.PDF.Forms.Fields.TextField).Value = "$" & ds4.Tables(0).Rows(0).Item("RentCont").ToString().Replace("$", "")
                        pdffield = myPDFFields.Fields("MHPerPropPremium")
                        DirectCast(pdffield, TallComponents.PDF.Forms.Fields.TextField).Value = "$" & ds4.Tables(0).Rows(0).Item("RentContPrem").ToString().Replace("$", "")

                    End If
                    Dim test As String
                    test = ds4.Tables(0).Rows(0).Item("RentStruc").ToString().Replace("$", "")
                    If ds4.Tables(0).Rows(0).Item("RentStruc").ToString().Replace("$", "") <> "0.00" Then
                        pdffield = myPDFFields.Fields("MHAddStrucDesc")
                        DirectCast(pdffield, TallComponents.PDF.Forms.Fields.TextField).Value = "Other Structures"
                        pdffield = myPDFFields.Fields("MHAddStrucLimit")
                        DirectCast(pdffield, TallComponents.PDF.Forms.Fields.TextField).Value = "$" & ds4.Tables(0).Rows(0).Item("RentStruc").ToString().Replace("$", "")
                        pdffield = myPDFFields.Fields("MHAddStrucPremium")
                        DirectCast(pdffield, TallComponents.PDF.Forms.Fields.TextField).Value = "$" & ds4.Tables(0).Rows(0).Item("RentStrucPrem").ToString().Replace("$", "")

                    End If
                    If ds4.Tables(0).Rows(0).Item("RentPerLiab").ToString().Replace("$", "") <> "" Then
                        If ds4.Tables(0).Rows(0).Item("RentPerLiab").ToString().Replace("$", "") <> "0" Then
                            pdffield = myPDFFields.Fields("MHPerLiabDesc")
                            DirectCast(pdffield, TallComponents.PDF.Forms.Fields.TextField).Value = "Premises Liability"
                            pdffield = myPDFFields.Fields("MHPerLiabLimit")
                            DirectCast(pdffield, TallComponents.PDF.Forms.Fields.TextField).Value = "$" & ds4.Tables(0).Rows(0).Item("RentPerLiab").ToString().Replace("$", "").Replace(",", "")
                            pdffield = myPDFFields.Fields("MHPerLiabPremium")
                            DirectCast(pdffield, TallComponents.PDF.Forms.Fields.TextField).Value = "$" & ds4.Tables(0).Rows(0).Item("RentPersLiabPrem").ToString().Replace("$", "")

                        End If
                    End If

                    If ds4.Tables(0).Rows(0).Item("RentFullRepair").ToString().Replace("$", "") = "Yes" Then
                        pdffield = myPDFFields.Fields("MHFireDesc")
                        DirectCast(pdffield, TallComponents.PDF.Forms.Fields.TextField).Value = "Full Repair"
                        'pdffield = myPDFFields.Fields("MHContentsLimit")
                        'DirectCast(pdffield, TallComponents.PDF.Forms.Fields.TextField).Value = "$" & ds4.Tables(0).Rows(0).Item("RentPerLiab").ToString().Replace("$", "")
                        pdffield = myPDFFields.Fields("MHFirePremium")
                        DirectCast(pdffield, TallComponents.PDF.Forms.Fields.TextField).Value = "$" & ds4.Tables(0).Rows(0).Item("RentFullRepairPrem").ToString().Replace("$", "")

                    End If

                    If ds4.Tables(0).Rows(0).Item("RentMedPay").ToString().Replace("$", "") > "0.00" Then
                        pdffield = myPDFFields.Fields("MHMedPayDesc")
                        DirectCast(pdffield, TallComponents.PDF.Forms.Fields.TextField).Value = "Medical Payments"
                        pdffield = myPDFFields.Fields("MHMedPayLimit")
                        DirectCast(pdffield, TallComponents.PDF.Forms.Fields.TextField).Value = "$" & ds4.Tables(0).Rows(0).Item("RentMedPay").ToString().Replace("$", "")
                        'pdffield = myPDFFields.Fields("MHMedPayPremium")
                        'DirectCast(pdffield, TallComponents.PDF.Forms.Fields.TextField).Value = "$" & ds4.Tables(0).Rows(0).Item("RentMedPrem").ToString().Replace("$", "")

                    End If
                    'pdffield = myPDFFields.Fields("MHNDDesc")
                    'DirectCast(pdffield, TallComponents.PDF.Forms.Fields.TextField).Value = "Tax"
                    'pdffield = myPDFFields.Fields("MHNDPremium")
                    'DirectCast(pdffield, TallComponents.PDF.Forms.Fields.TextField).Value = "$" & ds4.Tables(0).Rows(0).Item("RentTax").ToString().Replace("$", "")
                Case "SMH Package"
                    pdffield = myPDFFields.Fields("MHAddResDesc")
                    DirectCast(pdffield, TallComponents.PDF.Forms.Fields.TextField).Value = "Loss of Use"

                    pdffield = myPDFFields.Fields("MHAddResLimit")
                    DirectCast(pdffield, TallComponents.PDF.Forms.Fields.TextField).Value = "1000"

                    pdffield = myPDFFields.Fields("MHDwellLimit")
                    DirectCast(pdffield, TallComponents.PDF.Forms.Fields.TextField).Value = CInt(ds4.Tables(0).Rows(0).Item("SMHPackDwel").ToString())

                    'pdffield = myPDFFields.Fields("MHPerPropLimit")
                    'DirectCast(pdffield, TallComponents.PDF.Forms.Fields.TextField).Value = CInt(ds4.Tables(0).Rows(0).Item("SMHPackCont").ToString())


                    pdffield = myPDFFields.Fields("MHDwellPremium")
                    DirectCast(pdffield, TallComponents.PDF.Forms.Fields.TextField).Value = CInt(ds4.Tables(0).Rows(0).Item("SMHPackprem").ToString()) '- CInt(ds3.Tables(0).Rows(0).Item("SMHPackHur").ToString()) - CInt(ds3.Tables(0).Rows(0).Item("SMHPackNonHur").ToString())
                    ' PackardTotal += CInt(ds4.Tables(0).Rows(0).Item("SMHPackBasePrem").ToString()) ' - CInt(ds3.Tables(0).Rows(0).Item("SMHPackHur").ToString()) - CInt(ds3.Tables(0).Rows(0).Item("SMHPackNonHur").ToString())
                    If CInt(ds4.Tables(0).Rows(0).Item("SMHPackAOP").ToString().Replace("$", "")) > 1000 Then
                        pdffield = myPDFFields.Fields("MHDedDesc")
                        DirectCast(pdffield, TallComponents.PDF.Forms.Fields.TextField).Value = "AOP Deductible" '"Deductible Change Option AOP"
                        pdffield = myPDFFields.Fields("MHDedPremium")
                        DirectCast(pdffield, TallComponents.PDF.Forms.Fields.TextField).Value = "($" & CInt(ds4.Tables(0).Rows(0).Item("SMHPackAOPPrem").ToString()) & ")"
                    Else
                        pdffield = myPDFFields.Fields("MHDedDesc")
                        DirectCast(pdffield, TallComponents.PDF.Forms.Fields.TextField).Value = "AOP Deductible"
                        pdffield = myPDFFields.Fields("MHDedPremium")
                        DirectCast(pdffield, TallComponents.PDF.Forms.Fields.TextField).Value = CInt(ds4.Tables(0).Rows(0).Item("SMHPackAOPPrem").ToString())
                    End If


                    pdffield = myPDFFields.Fields("MHDedLimit")
                    DirectCast(pdffield, TallComponents.PDF.Forms.Fields.TextField).Value = "$" & ds4.Tables(0).Rows(0).Item("SMHPackAOP").ToString().Replace("$", "")

                    ' PackTotal -= CInt(ds3.Tables(0).Rows(0).Item("SMHPackNonHur").ToString())


                    pdffield = myPDFFields.Fields("MHPropRepDesc")
                    DirectCast(pdffield, TallComponents.PDF.Forms.Fields.TextField).Value = "Wind Hail Deductible:"

                    pdffield = myPDFFields.Fields("MHPropRepPremiumLimit")
                    DirectCast(pdffield, TallComponents.PDF.Forms.Fields.TextField).Value = ds4.Tables(0).Rows(0).Item("SMHPackWind").ToString().Replace("$", "")
                    'pdffield = myPDFFields.Fields("MHPropRepPremium")
                    'DirectCast(pdffield, TallComponents.PDF.Forms.Fields.TextField).Value = "($" & CInt(ds3.Tables(0).Rows(0).Item("SMHPackHur").ToString().Replace("$", "")) & ")"

                    'Hurricane/Tropical Storm

                    pdffield = myPDFFields.Fields("MHRepCostDesc")
                    DirectCast(pdffield, TallComponents.PDF.Forms.Fields.TextField).Value = "Hurricane / Tropical Storm Deductible:"

                    pdffield = myPDFFields.Fields("MHPropCostPremlimit")
                    DirectCast(pdffield, TallComponents.PDF.Forms.Fields.TextField).Value = ds4.Tables(0).Rows(0).Item("SMHPackWind").ToString().Replace("$", "")
                    'Enhancement coverage
                    If IsNumeric(ds4.Tables(0).Rows(0).Item("SMHPackFullRepair").ToString().Replace("$", "")) Then


                        pdffield = myPDFFields.Fields("MHRadioDesc")
                        DirectCast(pdffield, TallComponents.PDF.Forms.Fields.TextField).Value = "Enhancement Coverage"

                        pdffield = myPDFFields.Fields("MHRadioLimit")
                        DirectCast(pdffield, TallComponents.PDF.Forms.Fields.TextField).Value = ds4.Tables(0).Rows(0).Item("SMHPackFullRepair").ToString().Replace("$", "")

                        pdffield = myPDFFields.Fields("MHRadioPremium")
                        DirectCast(pdffield, TallComponents.PDF.Forms.Fields.TextField).Value = ds4.Tables(0).Rows(0).Item("SMHPackFullRepairPrem").ToString().Replace("$", "")

                    End If



                    pdffield = myPDFFields.Fields("Total Quoted Premium")
                    DirectCast(pdffield, TallComponents.PDF.Forms.Fields.TextField).Value = "$" & ds4.Tables(0).Rows(0).Item("SMHPacktotal").ToString().Replace("$", "")

                    If ds4.Tables(0).Rows(0).Item("SMHPackContReplacePrem").ToString().Replace("$", "") <> "0" Then

                        pdffield = myPDFFields.Fields("MHContentsdesc")
                        DirectCast(pdffield, TallComponents.PDF.Forms.Fields.TextField).Value = "Contents Replacement Cost"

                        pdffield = myPDFFields.Fields("MHContentsLimit")
                        DirectCast(pdffield, TallComponents.PDF.Forms.Fields.TextField).Value = ds4.Tables(0).Rows(0).Item("SMHPackCont").ToString().Replace("$", "")

                        pdffield = myPDFFields.Fields("MHContentsPremium")
                        DirectCast(pdffield, TallComponents.PDF.Forms.Fields.TextField).Value = ds4.Tables(0).Rows(0).Item("SMHPackContReplacePrem").ToString().Replace("$", "")

                    End If
                    If ds.Tables(0).Rows(0).Item("homeUse").ToString() = "Seasonal" Then
                        pdffield = myPDFFields.Fields("MHFeeDesc1")
                        DirectCast(pdffield, TallComponents.PDF.Forms.Fields.TextField).Value = "Seasonal Surcharge"
                        pdffield = myPDFFields.Fields("MHFeeAmount1")
                        DirectCast(pdffield, TallComponents.PDF.Forms.Fields.TextField).Value = "$20"
                        pdffield = myPDFFields.Fields("MHSIPDesc")
                        DirectCast(pdffield, TallComponents.PDF.Forms.Fields.TextField).Value = "Policy Fee"
                        pdffield = myPDFFields.Fields("MHSIPPremium")
                        DirectCast(pdffield, TallComponents.PDF.Forms.Fields.TextField).Value = "$" & ds4.Tables(0).Rows(0).Item("SMHPackFees").ToString().Replace("$", "") - 20
                        If ds4.Tables(0).Rows(0).Item("SMHPackCreditPerc").ToString().Replace("$", "") > "0" Then
                            pdffield = myPDFFields.Fields("MHFeeDesc2")
                            DirectCast(pdffield, TallComponents.PDF.Forms.Fields.TextField).Value = "Credit Percentage " & CDbl(ds4.Tables(0).Rows(0).Item("SMHPackCreditPerc").ToString().Replace("$", "")) * 100 & " %"
                            pdffield = myPDFFields.Fields("MHFeeAmount2")
                            DirectCast(pdffield, TallComponents.PDF.Forms.Fields.TextField).Value = "($-" & ds4.Tables(0).Rows(0).Item("SMHPackCreditamt").ToString().Replace("$", "") & ")"

                        End If
                    Else
                        pdffield = myPDFFields.Fields("MHSIPDesc")
                        DirectCast(pdffield, TallComponents.PDF.Forms.Fields.TextField).Value = " Policy Fee"
                        pdffield = myPDFFields.Fields("MHSIPPremium")
                        DirectCast(pdffield, TallComponents.PDF.Forms.Fields.TextField).Value = "$" & ds4.Tables(0).Rows(0).Item("SMHPackFees").ToString().Replace("$", "")

                        If ds4.Tables(0).Rows(0).Item("SMHPackCreditPerc").ToString().Replace("$", "") > "0" Then
                            pdffield = myPDFFields.Fields("MHFeeDesc2")
                            DirectCast(pdffield, TallComponents.PDF.Forms.Fields.TextField).Value = "Credit Percentage " & CDbl(ds4.Tables(0).Rows(0).Item("SMHPackCreditPerc").ToString().Replace("$", "")) * 100 & " %"
                            pdffield = myPDFFields.Fields("MHFeeAmount2")
                            DirectCast(pdffield, TallComponents.PDF.Forms.Fields.TextField).Value = "($-" & ds4.Tables(0).Rows(0).Item("SMHPackCreditamt").ToString().Replace("$", "") & ")"

                        End If

                    End If
                    If ds4.Tables(0).Rows(0).Item("SMHPackMHReplace").ToString().Replace("$", "") = "Yes" Then
                        pdffield = myPDFFields.Fields("MHFireDesc")
                        DirectCast(pdffield, TallComponents.PDF.Forms.Fields.TextField).Value = "Replacement Cost for Mobile Home"
                        pdffield = myPDFFields.Fields("MHFirePremium")
                        DirectCast(pdffield, TallComponents.PDF.Forms.Fields.TextField).Value = "$" & ds4.Tables(0).Rows(0).Item("SMHPackMHReplacePrem").ToString().Replace("$", "")

                    End If
                    'If ds4.Tables(0).Rows(0).Item("SMHPackContPrem").ToString().Replace("$", "") > "0" Then
                    pdffield = myPDFFields.Fields("MobileHomePersonalProp")
                    DirectCast(pdffield, TallComponents.PDF.Forms.Fields.TextField).Value = "Contents"
                    pdffield = myPDFFields.Fields("MHPerPropLimit")
                    DirectCast(pdffield, TallComponents.PDF.Forms.Fields.TextField).Value = "$" & ds4.Tables(0).Rows(0).Item("SMHPackCont").ToString().Replace("$", "")
                    pdffield = myPDFFields.Fields("MHPerPropPremium")
                    DirectCast(pdffield, TallComponents.PDF.Forms.Fields.TextField).Value = "$" & ds4.Tables(0).Rows(0).Item("SMHPackContPrem").ToString().Replace("$", "")

                    'End If

                    If ds4.Tables(0).Rows(0).Item("SMHPackStruc").ToString().Replace("$", "") <> "0.00" Then
                        pdffield = myPDFFields.Fields("MHAddStrucDesc")
                        DirectCast(pdffield, TallComponents.PDF.Forms.Fields.TextField).Value = "Other Structures"
                        pdffield = myPDFFields.Fields("MHAddStrucLimit")
                        DirectCast(pdffield, TallComponents.PDF.Forms.Fields.TextField).Value = "$" & ds4.Tables(0).Rows(0).Item("SMHPackStruc").ToString().Replace("$", "")
                        pdffield = myPDFFields.Fields("MHAddStrucPremium")
                        DirectCast(pdffield, TallComponents.PDF.Forms.Fields.TextField).Value = "$" & ds4.Tables(0).Rows(0).Item("SMHPackStrucPrem").ToString().Replace("$", "")

                    End If
                    If ds4.Tables(0).Rows(0).Item("SMHPackPerLiab").ToString().Replace("$", "") <> "0" Then
                        pdffield = myPDFFields.Fields("MHPerLiabDesc")
                        DirectCast(pdffield, TallComponents.PDF.Forms.Fields.TextField).Value = "Personal Liability"
                        pdffield = myPDFFields.Fields("MHPerLiabLimit")
                        DirectCast(pdffield, TallComponents.PDF.Forms.Fields.TextField).Value = "$" & ds4.Tables(0).Rows(0).Item("SMHPackPerLiab").ToString().Replace("$", "").Replace(",", "")
                        pdffield = myPDFFields.Fields("MHPerLiabPremium")
                        DirectCast(pdffield, TallComponents.PDF.Forms.Fields.TextField).Value = "$" & ds4.Tables(0).Rows(0).Item("SMHPackPersLiabPrem").ToString().Replace("$", "")

                    End If


                    If ds4.Tables(0).Rows(0).Item("SMHPackFullRepair").ToString().Replace("$", "") = "Yes" Then
                        pdffield = myPDFFields.Fields("MHFireDesc")
                        DirectCast(pdffield, TallComponents.PDF.Forms.Fields.TextField).Value = "Full Repair"
                        'pdffield = myPDFFields.Fields("MHContentsLimit")
                        'DirectCast(pdffield, TallComponents.PDF.Forms.Fields.TextField).Value = "$" & ds4.Tables(0).Rows(0).Item("SMHPackPerLiab").ToString().Replace("$", "")
                        pdffield = myPDFFields.Fields("MHFirePremium")
                        DirectCast(pdffield, TallComponents.PDF.Forms.Fields.TextField).Value = "$" & ds4.Tables(0).Rows(0).Item("SMHPackFullRepairPrem").ToString().Replace("$", "")

                    End If


                    pdffield = myPDFFields.Fields("MHNDDesc")
                    DirectCast(pdffield, TallComponents.PDF.Forms.Fields.TextField).Value = "Tax"
                    pdffield = myPDFFields.Fields("MHNDPremium")
                    DirectCast(pdffield, TallComponents.PDF.Forms.Fields.TextField).Value = "$" & ds4.Tables(0).Rows(0).Item("SMHPackTax").ToString().Replace("$", "")
                    If ds4.Tables(0).Rows(0).Item("SMHPackMedPay").ToString().Replace("$", "") > "0.00" Then
                        pdffield = myPDFFields.Fields("MHMedPayDesc")
                        DirectCast(pdffield, TallComponents.PDF.Forms.Fields.TextField).Value = "Medical Payments"
                        pdffield = myPDFFields.Fields("MHMedPayLimit")
                        DirectCast(pdffield, TallComponents.PDF.Forms.Fields.TextField).Value = "$" & ds4.Tables(0).Rows(0).Item("SMHPackMedPay").ToString().Replace("$", "")
                        pdffield = myPDFFields.Fields("MHMedPayPremium")
                        DirectCast(pdffield, TallComponents.PDF.Forms.Fields.TextField).Value = "$" & ds4.Tables(0).Rows(0).Item("SMHPackMedPrem").ToString().Replace("$", "")

                    End If
                    pdffield = myPDFFields.Fields("MHFeeDesc")
                    DirectCast(pdffield, TallComponents.PDF.Forms.Fields.TextField).Value = "Expense Constant"
                    pdffield = myPDFFields.Fields("MHFeeAmount")
                    DirectCast(pdffield, TallComponents.PDF.Forms.Fields.TextField).Value = "$45"

            End Select

            'Dim Quotetotal As Integer
            'Quotetotal += PackTotal
            'If IsNumeric(dsRate.Tables(0).Rows(0).Item("PerPropPrem").ToString()) Then
            '    Quotetotal += CInt(dsRate.Tables(0).Rows(0).Item("PerPropPrem").ToString())
            'End If
            'If IsNumeric(dsRate.Tables(0).Rows(0).Item("AddStrucPrem").ToString()) Then
            '    Quotetotal += CInt(dsRate.Tables(0).Rows(0).Item("AddStrucPrem").ToString())
            'End If
            'If IsNumeric(dsRate.Tables(0).Rows(0).Item("LiabPrem").ToString()) Then
            '    Quotetotal += CInt(dsRate.Tables(0).Rows(0).Item("LiabPrem").ToString())
            'End If
            'If IsNumeric(dsRate.Tables(0).Rows(0).Item("FirePrem").ToString()) Then
            '    Quotetotal += CInt(dsRate.Tables(0).Rows(0).Item("FirePrem").ToString())
            'End If
            'If IsNumeric(dsRate.Tables(0).Rows(0).Item("RadioPrem").ToString()) Then
            '    Quotetotal += CInt(dsRate.Tables(0).Rows(0).Item("RadioPrem").ToString())
            'End If





            'Quotetotal += CInt(PackTotal * 0.01)
            'Quotetotal += CInt(PackTotal * 0.013)
            'Quotetotal += 25
            'Quotetotal += 2

            'pdffield = myPDFFields.Fields("Total Quoted Premium")
            'DirectCast(pdffield, TallComponents.PDF.Forms.Fields.TextField).Value = Quotetotal


            For Each field As TallComponents.PDF.Forms.Fields.Field In myPDFFields.Fields
                For Each widget As Widget In field.Widgets
                    widget.Persistency = WidgetPersistency.Flatten
                Next
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