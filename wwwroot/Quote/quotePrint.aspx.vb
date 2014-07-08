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
                printQuote(ds1, ds2, ds3, ds4)
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
                        value = ds.Tables(0).Rows(0).Item("valuation").ToString()
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
                        value = dsRate.Tables(0).Rows(0).Item("LiabLimit").ToString()
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