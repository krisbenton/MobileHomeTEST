Imports System.Data.SqlClient
Imports System.IO

Imports TallComponents.PDF.JavaScript
Imports TallComponents.PDF.Annotations.Widgets
Imports TallComponents.PDF.Forms.Fields

Public Class quotePrintImport
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


            Dim ds1 As System.Data.DataSet
            Dim ds2 As System.Data.DataSet
            Dim ds3 As System.Data.DataSet
            Dim ds4 As System.Data.DataSet
            Dim ds5 As System.Data.DataSet
            ds1 = Common.runQueryDS("SELECT * FROM tblQuotes q LEFT JOIN (SELECT DISTINCT AgencyID,AgencyCode,AgencyName,ssad1 AS AgentAddr1, Address2 AS AgentAddr2,City AS AgentCity,State AS AgentState,Zip AS AgentZip, agency.sscnt3 AS AgentPhone FROM wrwpaqbx_ColonialWeb.wrwpaqbx_admin.vwAgents as agent left join [wrwpaqbx_ColonialWeb].[wrwpaqbx_admin].[Agency] as agency on agency.sssub = agent.AgencyCode)vwag ON q.agencyName = vwag.AgencyName WHERE QuoteID = '" & quoteID & "'")
            ds2 = Common.runQueryDS("EXEC sp_getQuotePrintPrem '" & quoteID & "'")
            ds3 = Common.runQueryDS("Select * from tblQuoteCalcs where QuoteID = '" & quoteID & "'")
            ds4 = Common.runQueryDS("Select * from tblARQuotes where QuoteID = '" & quoteID & "'")
            Dim AppID As String



            Try
                If ds1.Tables(0).Rows.Count > 0 Then
                    'get application info
                    AppID = ds1.Tables(0).Rows(0).Item("ARApplicationID").ToString()
                    ds5 = Common.runQueryDS("EXEC sp_GetApplicationPrint '" & AppID & "'")
                    'Cover Page
                    myFileStream = New FileStream(Me.MapPath("~\ApplicationPages\") & "PDF\FLPolicyQuoteCoverLetter.pdf", FileMode.Open, FileAccess.Read)
                    mySourcePDF = New TallComponents.PDF.Document(myFileStream)
                    myPDFFields.Pages.AddRange(mySourcePDF.Pages.CloneToArray())
                    myFileStream.Close()
                    mySourcePDF = Nothing
                    'Flood Letter
                    myFileStream = New FileStream(Me.MapPath("~\ApplicationPages\") & "PDF\FLFloodLetter.pdf", FileMode.Open, FileAccess.Read)
                    mySourcePDF = New TallComponents.PDF.Document(myFileStream)
                    myPDFFields.Pages.AddRange(mySourcePDF.Pages.CloneToArray())
                    myFileStream.Close()
                    mySourcePDF = Nothing
                    'Finance Contract
                    If System.IO.File.Exists(Me.MapPath("~\ApplicationPages/Finance/") & "FinanceContract_" & Request.QueryString("quoteID") & ".pdf") Then
                        myFileStream = New FileStream(Me.MapPath("~\ApplicationPages/Finance/") & "FinanceContract_" & Request.QueryString("quoteID") & ".pdf", FileMode.Open, FileAccess.Read)
                        mySourcePDF = New TallComponents.PDF.Document(myFileStream)
                        'mySourcePDF.Pages.RemoveAt(5)
                        myPDFFields.Pages.AddRange(mySourcePDF.Pages.CloneToArray())
                        myFileStream.Close()
                        mySourcePDF = Nothing
                    Else
                        'No Finance Contract Present. Continue
                    End If
                    'invoice
                    myFileStream = New FileStream(Me.MapPath("~\ApplicationPages\") & "PDF\INVOICE.pdf", FileMode.Open, FileAccess.Read)
                    mySourcePDF = New TallComponents.PDF.Document(myFileStream)
                    myPDFFields.Pages.AddRange(mySourcePDF.Pages.CloneToArray())
                    myFileStream.Close()
                    mySourcePDF = Nothing

                    'Premium Quote
                    myFileStream = New FileStream(Me.MapPath("~\ApplicationPages\") & "PDF\premiumQuote.pdf", FileMode.Open, FileAccess.Read)
                    mySourcePDF = New TallComponents.PDF.Document(myFileStream)
                    myPDFFields.Pages.AddRange(mySourcePDF.Pages.CloneToArray())
                    myFileStream.Close()
                    mySourcePDF = Nothing

                    printInvoice(ds1, ds2, ds3, ds4, myPDFFields.Fields, ds5)
                    printQuote(ds1, ds2, ds3, ds4, myPDFFields.Fields, ds5)
                    printFlood(ds1, ds2, ds3, ds4, myPDFFields.Fields, ds5)

                    myOutputPDF.Pages.AddRange(myPDFFields.Pages.CloneToArray)

                    Response.ContentType = "application/pdf"
                    myOutputPDF.Write(New BinaryWriter(Response.OutputStream))
                    myFileStream.Close()
                End If
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
    Public Sub printFlood(ByVal ds As System.Data.DataSet, ByVal dsRate As System.Data.DataSet, ByVal ds3 As System.Data.DataSet, ByVal ds4 As System.Data.DataSet, ByRef myPDFFields As TallComponents.PDF.Forms.Fields.FieldCollection, ByVal ds5 As System.Data.DataSet)
        Dim pdffield As TallComponents.PDF.Forms.Fields.Field
        Dim strPDFFieldName As String = ""
        pdffield = myPDFFields.Item("Name")
        DirectCast(pdffield, TallComponents.PDF.Forms.Fields.TextField).Value = UCase(LTrim(ds.Tables(0).Rows(0).Item("applicantFirstName").ToString()) + " " + ds.Tables(0).Rows(0).Item("applicantLastName").ToString())

        pdffield = myPDFFields.Item("SpouseName")
        DirectCast(pdffield, TallComponents.PDF.Forms.Fields.TextField).Value = UCase(ds5.Tables(0).Rows(0).Item("SpouseName").ToString())
        pdffield = myPDFFields.Item("Address1")
        DirectCast(pdffield, TallComponents.PDF.Forms.Fields.TextField).Value = ds5.Tables(0).Rows(0).Item("DiffAppAddr").ToString()
        pdffield = myPDFFields.Item("Address2")
        DirectCast(pdffield, TallComponents.PDF.Forms.Fields.TextField).Value = "" 'No Value
        pdffield = myPDFFields.Item("CSZ")
        DirectCast(pdffield, TallComponents.PDF.Forms.Fields.TextField).Value = UCase(ds5.Tables(0).Rows(0).Item("DiffAppCity").ToString()) + ", " + UCase(ds5.Tables(0).Rows(0).Item("DiffAppState").ToString()) + " " + UCase(ds5.Tables(0).Rows(0).Item("DiffAppZip").ToString()) 'UCase(ds.Tables(0).Rows(0).Item("city").ToString()) + " " + UCase(ds.Tables(0).Rows(0).Item("state").ToString()) + " " + UCase(ds.Tables(0).Rows(0).Item("zip").ToString())

        For Each field As TallComponents.PDF.Forms.Fields.Field In myPDFFields
            For Each widget As Widget In field.Widgets
                widget.Persistency = WidgetPersistency.Flatten
            Next
        Next
    End Sub
    Public Sub printQuote(ByVal ds As System.Data.DataSet, ByVal dsRate As System.Data.DataSet, ByVal ds3 As System.Data.DataSet, ByVal ds4 As System.Data.DataSet, ByRef myPDFFields As TallComponents.PDF.Forms.Fields.FieldCollection, ByVal ds5 As System.Data.DataSet)

        Dim value As String
        Dim BasePrem, Credits, DedCredit As Double
        BasePrem = 0.0
        Dim pdffield As TallComponents.PDF.Forms.Fields.Field
        Dim strPDFFieldName As String = ""

        pdffield = myPDFFields.Item("QuoteDate")
        DirectCast(pdffield, TallComponents.PDF.Forms.Fields.TextField).Value = Date.Now.ToString("MM/dd/yyyy") 'ds.Tables(0).Rows(0).Item("quoteID").ToString()

        pdffield = myPDFFields.Item("TermStart")
        DirectCast(pdffield, TallComponents.PDF.Forms.Fields.TextField).Value = CDate(ds.Tables(0).Rows(0).Item("effDate")).ToString("MM/dd/yyyy")

        Dim TermEnd As Date
        Dim MonthsToAdd As Integer
        MonthsToAdd = CInt(ds.Tables(0).Rows(0).Item("term"))
        TermEnd = CDate(ds.Tables(0).Rows(0).Item("effDate").ToString()).AddMonths(MonthsToAdd).ToString("MM/dd/yyyy")
        pdffield = myPDFFields.Item("TermEnd")
        DirectCast(pdffield, TallComponents.PDF.Forms.Fields.TextField).Value = TermEnd
        pdffield = myPDFFields.Item("Term")
        DirectCast(pdffield, TallComponents.PDF.Forms.Fields.TextField).Value = ds.Tables(0).Rows(0).Item("term").ToString()

        pdffield = myPDFFields.Item("Company")
        DirectCast(pdffield, TallComponents.PDF.Forms.Fields.TextField).Value = "American Reliable " & ds.Tables(0).Rows(0).Item("ARRateType").ToString()
        pdffield = myPDFFields.Item("CompanyLocation")
        DirectCast(pdffield, TallComponents.PDF.Forms.Fields.TextField).Value = ds.Tables(0).Rows(0).Item("propAddress").ToString()

        pdffield = myPDFFields.Item("LienName")
        DirectCast(pdffield, TallComponents.PDF.Forms.Fields.TextField).Value = ds5.Tables(0).Rows(0).Item("Lien1Name").ToString()
        pdffield = myPDFFields.Item("Loan")
        DirectCast(pdffield, TallComponents.PDF.Forms.Fields.TextField).Value = ds5.Tables(0).Rows(0).Item("Lien1Num").ToString()
        pdffield = myPDFFields.Item("LienAddr1")
        DirectCast(pdffield, TallComponents.PDF.Forms.Fields.TextField).Value = UCase(ds5.Tables(0).Rows(0).Item("Lien1Addr").ToString())
        pdffield = myPDFFields.Item("LienAddr2")
        DirectCast(pdffield, TallComponents.PDF.Forms.Fields.TextField).Value = UCase(ds5.Tables(0).Rows(0).Item("Lien1Addr2").ToString())
        pdffield = myPDFFields.Item("LienCityState")
        DirectCast(pdffield, TallComponents.PDF.Forms.Fields.TextField).Value = UCase(ds5.Tables(0).Rows(0).Item("Lien1City").ToString() & ", " & ds5.Tables(0).Rows(0).Item("Lien1State").ToString() & " " & ds5.Tables(0).Rows(0).Item("Lien1Zip").ToString())


        pdffield = myPDFFields.Item("MHDescription")
        DirectCast(pdffield, TallComponents.PDF.Forms.Fields.TextField).Value = UCase("Year: " & ds.Tables(0).Rows(0).Item("year").ToString() & " MFG: " & ds.Tables(0).Rows(0).Item("manf").ToString() & "  Length: " & ds.Tables(0).Rows(0).Item("length").ToString() & " Width: " & ds.Tables(0).Rows(0).Item("width").ToString() & " Serial: " & ds5.Tables(0).Rows(0).Item("DescMHSerial").ToString())


        pdffield = myPDFFields.Item("location")
        DirectCast(pdffield, TallComponents.PDF.Forms.Fields.TextField).Value = UCase(ds.Tables(0).Rows(0).Item("propAddress").ToString()) & ",  " & UCase(ds.Tables(0).Rows(0).Item("city").ToString()) + " " + UCase(ds.Tables(0).Rows(0).Item("state").ToString()) + " " + UCase(ds.Tables(0).Rows(0).Item("zip").ToString())


        For Each myPDFField As TallComponents.PDF.Forms.Fields.Field In myPDFFields
            strPDFFieldName = myPDFField.FullName
            Select Case strPDFFieldName


                'Client Section
                Case "InsuredName"
                    value = LTrim(ds.Tables(0).Rows(0).Item("applicantFirstName").ToString()) + " " + ds.Tables(0).Rows(0).Item("applicantLastName").ToString()
                    DirectCast(myPDFField, TallComponents.PDF.Forms.Fields.TextField).Value = UCase(value)
                Case "SpouseName"
                    'value = ds.Tables(0).Rows(0).Item("propAddress").ToString()
                    value = ds5.Tables(0).Rows(0).Item("SpouseName").ToString()
                    DirectCast(myPDFField, TallComponents.PDF.Forms.Fields.TextField).Value = UCase(value)
                Case "InsuredAddr1"
                    'value = ds.Tables(0).Rows(0).Item("propAddress").ToString()
                    value = ds5.Tables(0).Rows(0).Item("DiffAppAddr").ToString()
                    DirectCast(myPDFField, TallComponents.PDF.Forms.Fields.TextField).Value = UCase(value)
                Case "InsuredAddr2"
                    value = ""
                    DirectCast(myPDFField, TallComponents.PDF.Forms.Fields.TextField).Value = value
                Case "InsuredCityState"
                    value = UCase(ds5.Tables(0).Rows(0).Item("DiffAppCity").ToString() + ", " + ds5.Tables(0).Rows(0).Item("DiffAppState").ToString() + " " + ds5.Tables(0).Rows(0).Item("DiffAppZip").ToString())
                    DirectCast(myPDFField, TallComponents.PDF.Forms.Fields.TextField).Value = UCase(value)


                    'Premium Values
                Case "Home_Prem"
                    value = dsRate.Tables(0).Rows(0).Item("DwellingPrem").ToString()
                    Credits = CDbl(ds3.Tables(0).Rows(0).Item("CreditPerc").ToString())
                    DedCredit = CDbl(dsRate.Tables(0).Rows(0).Item("DedPrem").ToString())
                    BasePrem = CDbl(value.Replace("$", ""))
                    BasePrem = BasePrem - (BasePrem * Credits)
                    BasePrem = BasePrem + DedCredit
                    value = BasePrem
                    DirectCast(myPDFField, TallComponents.PDF.Forms.Fields.TextField).Value = String.Format("{0:N0}", value)
                Case "Other_Prem"
                    value = dsRate.Tables(0).Rows(0).Item("AddStrucPrem").ToString()
                    If value = "INCLUDED" Then
                        value = "$0.00"
                    End If
                    BasePrem += CDbl(value.Replace("$", ""))
                    DirectCast(myPDFField, TallComponents.PDF.Forms.Fields.TextField).Value = String.Format("{0:N0}", value)
                Case "Contents_Prem"
                    value = dsRate.Tables(0).Rows(0).Item("PerPropPrem").ToString()
                    If value = "INCLUDED" Then
                        value = "$0.00"
                    End If
                    BasePrem += CDbl(value.Replace("$", ""))
                    DirectCast(myPDFField, TallComponents.PDF.Forms.Fields.TextField).Value = String.Format("{0:N0}", value)
                Case "Liab_Prem"
                    value = dsRate.Tables(0).Rows(0).Item("LiabPrem").ToString()
                    DirectCast(myPDFField, TallComponents.PDF.Forms.Fields.TextField).Value = String.Format("{0:N0}", value)
                Case "Med_Prem"
                Case "Loss_Prem"

                    'Case "Base_Prem"
                    '    DirectCast(myPDFField, TallComponents.PDF.Forms.Fields.TextField).Value = String.Format("{0:C0}", Math.Round(CDbl(BasePrem))).Replace("$", "")



            End Select


        Next

        Select Case ds.Tables(0).Rows(0).Item("ARRateType").ToString()

            Case "Package"
                pdffield = myPDFFields.Item("TotalPrem")
                DirectCast(pdffield, TallComponents.PDF.Forms.Fields.TextField).Value = (CDbl(ds4.Tables(0).Rows(0).Item("ARPackageTotal").ToString()))
                pdffield = myPDFFields.Item("Options")
                DirectCast(pdffield, TallComponents.PDF.Forms.Fields.TextField).Value = String.Format("{0:C0}", Math.Round(CDbl(ds3.Tables(0).Rows(0).Item("PackOpt").ToString()))).Replace("$", "").Replace("$", "")
                pdffield = myPDFFields.Item("Fees")
                DirectCast(pdffield, TallComponents.PDF.Forms.Fields.TextField).Value = String.Format("{0:C}", (CDbl(ds4.Tables(0).Rows(0).Item("ARPackageFees").ToString()))).Replace("$", "").Replace("$", "")
                pdffield = myPDFFields.Item("Base_Prem")
                DirectCast(pdffield, TallComponents.PDF.Forms.Fields.TextField).Value = String.Format("{0:C0}", Math.Round(CDbl(ds4.Tables(0).Rows(0).Item("ARPackageBasePrem").ToString()))).Replace("$", "").Replace("$", "")

            Case "Standard"
                pdffield = myPDFFields.Item("TotalPrem")
                DirectCast(pdffield, TallComponents.PDF.Forms.Fields.TextField).Value = (CDbl(ds4.Tables(0).Rows(0).Item("ARStandardTotal").ToString()))
                pdffield = myPDFFields.Item("Options")
                DirectCast(pdffield, TallComponents.PDF.Forms.Fields.TextField).Value = String.Format("{0:C0}", Math.Round(CDbl(ds3.Tables(0).Rows(0).Item("StandOpt").ToString()))).Replace("$", "")
                pdffield = myPDFFields.Item("Fees")
                DirectCast(pdffield, TallComponents.PDF.Forms.Fields.TextField).Value = String.Format("{0:C}", (CDbl(ds4.Tables(0).Rows(0).Item("ARStandardFees").ToString()))).Replace("$", "")
                pdffield = myPDFFields.Item("Base_Prem")
                DirectCast(pdffield, TallComponents.PDF.Forms.Fields.TextField).Value = String.Format("{0:C0}", Math.Round(CDbl(ds4.Tables(0).Rows(0).Item("ARStandardBasePrem").ToString()))).Replace("$", "").Replace("$", "")

            Case "Rental"
                pdffield = myPDFFields.Item("TotalPrem")
                DirectCast(pdffield, TallComponents.PDF.Forms.Fields.TextField).Value = CDbl(ds4.Tables(0).Rows(0).Item("ARRentalTotal").ToString())
                pdffield = myPDFFields.Item("Options")
                DirectCast(pdffield, TallComponents.PDF.Forms.Fields.TextField).Value = CDbl(String.Format("{0:C0}", Math.Round(CDbl(ds3.Tables(0).Rows(0).Item("RentOpt").ToString()))).Replace("$", ""))
                pdffield = myPDFFields.Item("Fees")
                DirectCast(pdffield, TallComponents.PDF.Forms.Fields.TextField).Value = CDbl(String.Format("{0:C}", (CDbl(ds4.Tables(0).Rows(0).Item("ARRentalFees").ToString()))).Replace("$", ""))
                pdffield = myPDFFields.Item("Base_Prem")
                DirectCast(pdffield, TallComponents.PDF.Forms.Fields.TextField).Value = CDbl(String.Format("{0:C0}", Math.Round(CDbl(ds4.Tables(0).Rows(0).Item("ARRentalBasePrem").ToString()))).Replace("$", "").Replace("$", ""))

        End Select

        Dim MHLimit As String
        Dim MHPrem As String
        Dim Struclimit As String
        Dim StrucPrem As String
        Dim pplimet As String
        Dim ppprem As String
        Dim pllimit As String
        Dim plprem As String
        Dim medlimit As String
        Dim medprem As String
        Dim catfund As String
        Dim ceafund As String
        Dim subheat As String
        Dim totprem As String
        Dim PackTotal As Integer

        MHPrem = CInt(ds3.Tables(0).Rows(0).Item("Packsub1").ToString())
        MHLimit = CInt(dsRate.Tables(0).Rows(0).Item("DwellingLimit").ToString())
        pplimet = CInt(dsRate.Tables(0).Rows(0).Item("PerPropLimit").ToString())
        If IsNumeric(dsRate.Tables(0).Rows(0).Item("AddStrucLimit").ToString()) Then
            Struclimit = CInt(dsRate.Tables(0).Rows(0).Item("AddStrucLimit").ToString())
        Else
            Struclimit = dsRate.Tables(0).Rows(0).Item("AddStrucLimit").ToString()
        End If

        If IsNumeric(dsRate.Tables(0).Rows(0).Item("AddStrucPrem")) Then
            StrucPrem = CInt(dsRate.Tables(0).Rows(0).Item("AddStrucPrem").ToString())
        Else
            StrucPrem = dsRate.Tables(0).Rows(0).Item("AddStrucPrem").ToString()
        End If
        ' StrucPrem = CInt(ds2.Tables(0).Rows(0).Item("AddStrucPrem").ToString())
        If IsNumeric(dsRate.Tables(0).Rows(0).Item("LiabLimit").ToString()) Then
            pllimit = CInt(dsRate.Tables(0).Rows(0).Item("LiabLimit").ToString())
        Else
            pllimit = "0" 'dsRate.Tables(0).Rows(0).Item("LiabLimit").ToString()
        End If

        If IsNumeric(dsRate.Tables(0).Rows(0).Item("LiabPrem").ToString()) Then
            plprem = CInt(dsRate.Tables(0).Rows(0).Item("LiabPrem").ToString())
        Else
            plprem = dsRate.Tables(0).Rows(0).Item("LiabPrem").ToString()
        End If

        'medlimit = CInt(dsRate.Tables(0).Rows(0).Item("MedPayOpt").ToString())
        'If medlimit = "1000" Then
        '    medprem = "6"
        'Else
        '    medprem = "INCLUDED"
        'End If
        Select Case ds.Tables(0).Rows(0).Item("ARRateType").ToString()
            Case "Package"
                medlimit = CInt(ds4.Tables(0).Rows(0).Item("ARPackageMedPayOpt").ToString())
                If medlimit = "1000" Then
                    medprem = "5"
                Else
                    medprem = "INCLUDED"
                End If

                'catfund = ((CInt(ds3.Tables(0).Rows(0).Item("Packsub1").ToString()) - CInt(ds3.Tables(0).Rows(0).Item("PackHur").ToString()) - CInt(ds3.Tables(0).Rows(0).Item("PackNonHur").ToString()))) * 0.01
                If ds4.Tables(0).Rows(0).Item("ARPacakageSupHeatFee").ToString() <> "" Then
                    subheat = CInt(ds4.Tables(0).Rows(0).Item("ARPacakageSupHeatFee").ToString())
                Else
                    subheat = CInt("0.00")

                End If
                ' subheat = CInt(ds4.Tables(0).Rows(0).Item("ARPacakageSupHeatFee").ToString())
                If ds4.Tables(0).Rows(0).Item("ARPackageCEAFee").ToString() <> "" Then
                    ceafund = CInt(ds4.Tables(0).Rows(0).Item("ARPackageCEAFee").ToString())
                Else
                    ceafund = CInt("0.00")

                End If

                'ceafund = CInt(ds4.Tables(0).Rows(0).Item("ARPackageCEAFee").ToString())
                If ds4.Tables(0).Rows(0).Item("ARPackagePerPropPrem").ToString() <> "" Then
                    ppprem = CInt(ds4.Tables(0).Rows(0).Item("ARPackagePerPropPrem").ToString())
                Else
                    ppprem = CInt("0.00")

                End If
                ' ppprem = CInt(ds4.Tables(0).Rows(0).Item("ARPackagePerPropPrem").ToString())
                If ds4.Tables(0).Rows(0).Item("ARPackageTotal").ToString() <> "" Then
                    totprem = CInt(ds4.Tables(0).Rows(0).Item("ARPackageTotal").ToString())
                Else
                    totprem = CInt("0.00")

                End If
                ' totprem = ds4.Tables(0).Rows(0).Item("ARPackageTotal").ToString()
                PackTotal += CInt(ds3.Tables(0).Rows(0).Item("Packsub1").ToString()) - CInt(ds3.Tables(0).Rows(0).Item("PackHur").ToString()) - CInt(ds3.Tables(0).Rows(0).Item("PackNonHur").ToString())
                catfund = CInt(PackTotal * 0.013)

                pdffield = myPDFFields.Item("Deductible")
                DirectCast(pdffield, TallComponents.PDF.Forms.Fields.TextField).Value = UCase("AOP " & ds4.Tables(0).Rows(0).Item("ARPackageAOPOpt").ToString() & " Hurricane " & ds4.Tables(0).Rows(0).Item("ARPackageHurDedOpt").ToString())

            Case "Standard"
                medlimit = CInt(ds4.Tables(0).Rows(0).Item("ARStandardMedPayOpt").ToString())
                If medlimit = "1000" Then
                    medprem = "6"
                ElseIf medlimit = "500" Then
                    medprem = "5"
                Else

                    medprem = "INCLUDED"
                End If
                ' catfund = ((CInt(ds3.Tables(0).Rows(0).Item("Standsub1").ToString()) - CInt(ds3.Tables(0).Rows(0).Item("StandHur").ToString()) - CInt(ds3.Tables(0).Rows(0).Item("StandNonHur").ToString()))) * 0.01

                If ds4.Tables(0).Rows(0).Item("ARStandardSupHeatFee").ToString() <> "" Then
                    subheat = CInt(ds4.Tables(0).Rows(0).Item("ARStandardSupHeatFee").ToString())
                Else
                    subheat = CInt("0.00")

                End If

                If ds4.Tables(0).Rows(0).Item("ARStandardCEAFee").ToString() <> "" Then
                    ceafund = CInt(ds4.Tables(0).Rows(0).Item("ARStandardCEAFee").ToString())
                Else
                    ceafund = CInt("0.00")

                End If


                If ds4.Tables(0).Rows(0).Item("ARStandardPerPropPrem").ToString() <> "" Then
                    ppprem = CInt(ds4.Tables(0).Rows(0).Item("ARStandardPerPropPrem").ToString())
                Else
                    ppprem = CInt("0.00")

                End If

                If ds4.Tables(0).Rows(0).Item("ARStandardTotal").ToString() <> "" Then
                    totprem = CInt(ds4.Tables(0).Rows(0).Item("ARStandardTotal").ToString())
                Else
                    totprem = CInt("0.00")

                End If
                'subheat = CInt(ds4.Tables(0).Rows(0).Item("ARStandardSupHeatFee").ToString())
                'ceafund = CInt(ds4.Tables(0).Rows(0).Item("ARStandardCEAFee").ToString())
                'ppprem = CInt(ds4.Tables(0).Rows(0).Item("ARStandardPerPropPrem").ToString())
                'totprem = ds4.Tables(0).Rows(0).Item("ARStandardTotal").ToString()
                PackTotal += CInt(ds3.Tables(0).Rows(0).Item("Standsub1").ToString()) - CInt(ds3.Tables(0).Rows(0).Item("StandHur").ToString()) - CInt(ds3.Tables(0).Rows(0).Item("StandNonHur").ToString())
                catfund = CInt(PackTotal * 0.013)

                pdffield = myPDFFields.Item("Deductible")
                DirectCast(pdffield, TallComponents.PDF.Forms.Fields.TextField).Value = UCase("AOP " & ds4.Tables(0).Rows(0).Item("ARStandardAOPOpt").ToString() & " Hurricane " & ds4.Tables(0).Rows(0).Item("ARStandardHurDedOpt").ToString())



            Case "Rental"
                If IsNumeric(ds4.Tables(0).Rows(0).Item("ARRentalMedPayOpt").ToString()) Then
                    medlimit = CInt(ds4.Tables(0).Rows(0).Item("ARRentalMedPayOpt").ToString())
                Else
                    medlimit = "0" ' ds4.Tables(0).Rows(0).Item("ARRentalMedPayOpt").ToString()
                End If
                'medlimit = CInt(ds4.Tables(0).Rows(0).Item("ARRentalMedPayOpt").ToString())
                If medlimit = "1000" Then
                    medprem = "6"
                ElseIf medlimit = "500" Then
                    medprem = "5"
                Else

                    medprem = "INCLUDED"
                End If
                ' catfund = ((CInt(ds3.Tables(0).Rows(0).Item("Rentsub1").ToString()) - CInt(ds3.Tables(0).Rows(0).Item("RentHur").ToString()) - CInt(ds3.Tables(0).Rows(0).Item("RentNonHur").ToString()))) * 0.01
                If ds4.Tables(0).Rows(0).Item("ARRentalSupHeatFee").ToString() <> "" Then
                    subheat = CInt(ds4.Tables(0).Rows(0).Item("ARRentalSupHeatFee").ToString())
                Else
                    subheat = CInt("0.00")

                End If

                If ds4.Tables(0).Rows(0).Item("ARRentalCEAFee").ToString() <> "" Then
                    ceafund = CInt(ds4.Tables(0).Rows(0).Item("ARRentalCEAFee").ToString())
                Else
                    ceafund = CInt("0.00")

                End If


                If ds4.Tables(0).Rows(0).Item("ARRentalPerPropPrem").ToString() <> "" Then
                    ppprem = CInt(ds4.Tables(0).Rows(0).Item("ARRentalPerPropPrem").ToString())
                Else
                    ppprem = CInt("0.00")

                End If

                If ds4.Tables(0).Rows(0).Item("ARRentalTotal").ToString() <> "" Then
                    totprem = CInt(ds4.Tables(0).Rows(0).Item("ARRentalTotal").ToString())
                Else
                    totprem = CInt("0.00")

                End If


                'subheat = CInt(ds4.Tables(0).Rows(0).Item("ARRentalSupHeatFee").ToString())
                'ceafund = CInt(ds4.Tables(0).Rows(0).Item("ARRentalCEAFee").ToString())
                'ppprem = CInt(ds4.Tables(0).Rows(0).Item("ARRentalPerPropPrem").ToString())
                'totprem = ds4.Tables(0).Rows(0).Item("ARRentalTotal").ToString()
                PackTotal += CInt(ds3.Tables(0).Rows(0).Item("Rentsub1").ToString()) - CInt(ds3.Tables(0).Rows(0).Item("RentHur").ToString()) - CInt(ds3.Tables(0).Rows(0).Item("RentNonHur").ToString())
                catfund = CInt(PackTotal * 0.013)
                pdffield = myPDFFields.Item("Deductible")
                DirectCast(pdffield, TallComponents.PDF.Forms.Fields.TextField).Value = UCase("AOP " & ds4.Tables(0).Rows(0).Item("ARRentalAOPOpt").ToString() & " Hurricane " & ds4.Tables(0).Rows(0).Item("ARRentalHurDedOpt").ToString())

        End Select
        If dsRate.Tables(0).Rows.Count > 0 Then

            pdffield = myPDFFields.Item("Home_Prem")
            DirectCast(pdffield, TallComponents.PDF.Forms.Fields.TextField).Value = String.Format("{0:N0}", MHLimit).Replace("$", "") 'ds2.Tables(0).Rows(0).Item("DwellingLimit").ToString().Replace("$", "")

            'pdffield = myPDFFields.Item("Base_Prem")
            'DirectCast(pdffield, TallComponents.PDF.Forms.Fields.TextField).Value = MHPrem 'ds2.Tables(0).Rows(0).Item("DwellingPrem").ToString().Replace("$", "")

            pdffield = myPDFFields.Item("Other_Prem")
            DirectCast(pdffield, TallComponents.PDF.Forms.Fields.TextField).Value = String.Format("{0:N0}", Struclimit).Replace("$", "") 'ds2.Tables(0).Rows(0).Item("AddStrucLimit").ToString().Replace("$", "")

            'pdffield = myPDFFields.Item("fill_63")
            'DirectCast(pdffield, TallComponents.PDF.Forms.Fields.TextField).Value = StrucPrem 'ds2.Tables(0).Rows(0).Item("AddStrucPrem").ToString().Replace("$", "")

            pdffield = myPDFFields.Item("Contents_Prem")
            DirectCast(pdffield, TallComponents.PDF.Forms.Fields.TextField).Value = String.Format("{0:N0}", pplimet).Replace("$", "") 'ds2.Tables(0).Rows(0).Item("PerPropLimit").ToString().Replace("$", "")

            'pdffield = myPDFFields.Item("fill_64")
            'DirectCast(pdffield, TallComponents.PDF.Forms.Fields.TextField).Value = ppprem 'ds2.Tables(0).Rows(0).Item("PerPropPrem").ToString().Replace("$", "")

            pdffield = myPDFFields.Item("Liab_Prem")
            DirectCast(pdffield, TallComponents.PDF.Forms.Fields.TextField).Value = String.Format("{0:N0}", pllimit).Replace("$", "") 'ds2.Tables(0).Rows(0).Item("LiabLimit").ToString().Replace("$", "")

            'pdffield = myPDFFields.Item("fill_65")
            'DirectCast(pdffield, TallComponents.PDF.Forms.Fields.TextField).Value = plprem 'ds2.Tables(0).Rows(0).Item("LiabPrem").ToString().Replace("$", "")

            pdffield = myPDFFields.Item("Med_Prem")
            DirectCast(pdffield, TallComponents.PDF.Forms.Fields.TextField).Value = String.Format("{0:N0}", medlimit).Replace("$", "") 'ds2.Tables(0).Rows(0).Item("MedPayOpt").ToString().Replace("$", "")

            'pdffield = myPDFFields.Item("fill_66")
            'DirectCast(pdffield, TallComponents.PDF.Forms.Fields.TextField).Value = medprem 'ds2.Tables(0).Rows(0).Item("MedRepPrem").ToString().Replace("$", "")


            'pdffield = myPDFFields.Item("fill_67")
            'DirectCast(pdffield, TallComponents.PDF.Forms.Fields.TextField).Value = "(" & CInt(dsRate.Tables(0).Rows(0).Item("DedPrem").ToString().Replace("-", "")) & ")"

            'pdffield = myPDFFields.Item("fill_77")
            'DirectCast(pdffield, TallComponents.PDF.Forms.Fields.TextField).Value = CInt(ceafund)
            'pdffield = myPDFFields.Item("fill_78")
            'DirectCast(pdffield, TallComponents.PDF.Forms.Fields.TextField).Value = CInt(catfund)

            'pdffield = myPDFFields.Item("fill_81")
            'DirectCast(pdffield, TallComponents.PDF.Forms.Fields.TextField).Value = totprem
        End If

        pdffield = myPDFFields.Item("Loss_Prem")
        DirectCast(pdffield, TallComponents.PDF.Forms.Fields.TextField).Value = String.Format("{0:N0}", Math.Round(MHLimit * 0.2)).Replace("$", "")

        Dim Description As String = ""
        Select Case ds.Tables(0).Rows(0).Item("ARRateType").ToString()
            Case "Package"
                If dsRate.Tables(0).Rows(0).Item("PerPropRepPrem").ToString().Replace("$", "") > "0.00" Then
                    ' Description = "Personal Property Replacement Cost"
                    Description += "Contents Replacement Cost,  " & vbCrLf
                End If

                If dsRate.Tables(0).Rows(0).Item("MHRepPrem").ToString().Replace("$", "") > "0.00" Then
                    Description += "Replacement Cost for Mobile Home, " & vbCrLf
                End If
                If ds4.Tables(0).Rows(0).Item("ARPackageFireServPrem").ToString().Replace("$", "") > "0.00" Then
                    Description += "Fire Department Charge, " & vbCrLf
                End If
                If ds4.Tables(0).Rows(0).Item("ARPackageRadioprem").ToString().Replace("$", "") > "0.00" Then
                    Description += "Radio Prem:" & vbCrLf

                End If
            Case "Standard"
                If dsRate.Tables(0).Rows(0).Item("PerPropRepPrem").ToString().Replace("$", "") > "0.00" Then
                    ' Description = "Personal Property Replacement Cost"
                    Description += "Contents Replacement Cost,  " & vbCrLf
                End If

                If dsRate.Tables(0).Rows(0).Item("MHRepPrem").ToString().Replace("$", "") > "0.00" Then
                    Description += "Replacement Cost for Mobile Home, " & vbCrLf
                End If
                If ds4.Tables(0).Rows(0).Item("ARStandardFireServPrem").ToString().Replace("$", "") > "0.00" Then
                    Description += "Fire Department Charge, " & vbCrLf
                End If
                If ds4.Tables(0).Rows(0).Item("ARStandardRadioprem").ToString().Replace("$", "") > "0.00" Then
                    Description += "Radio Prem:" & vbCrLf

                End If
            Case "Rental"

                If dsRate.Tables(0).Rows(0).Item("PerPropRepPrem").ToString().Replace("$", "") > "0.00" Then
                    ' Description = "Personal Property Replacement Cost"
                    Description += "Contents Replacement Cost,  " & vbCrLf
                End If

                If dsRate.Tables(0).Rows(0).Item("MHRepPrem").ToString().Replace("$", "") > "0.00" Then
                    Description += "Replacement Cost for Mobile Home, " & vbCrLf
                End If
                If ds4.Tables(0).Rows(0).Item("ARRentalFireServPrem").ToString().Replace("$", "") > "0.00" Then
                    Description += "Fire Department Charge, " & vbCrLf
                End If
                If ds4.Tables(0).Rows(0).Item("ARRentalRadioprem").ToString().Replace("$", "") > "0.00" Then
                    Description += "Radio Prem:" & vbCrLf

                End If



        End Select


        pdffield = myPDFFields.Item("Options2")
        DirectCast(pdffield, TallComponents.PDF.Forms.Fields.TextField).Value = Description



        For Each field As TallComponents.PDF.Forms.Fields.Field In myPDFFields
            For Each widget As Widget In field.Widgets
                widget.Persistency = WidgetPersistency.Flatten
            Next
        Next






    End Sub
    Public Sub printInvoice(ByVal ds As System.Data.DataSet, ByVal dsRate As System.Data.DataSet, ByVal ds3 As System.Data.DataSet, ByVal ds4 As System.Data.DataSet, ByRef myPDFFields As TallComponents.PDF.Forms.Fields.FieldCollection, ByVal ds5 As System.Data.DataSet)
        Dim value As String

        Dim pdffield As TallComponents.PDF.Forms.Fields.Field
        Dim strPDFFieldName As String = ""

        pdffield = myPDFFields.Item("InvoiceDate")
        DirectCast(pdffield, TallComponents.PDF.Forms.Fields.TextField).Value = Date.Now.ToString("MM/dd/yyyy") 'ds.Tables(0).Rows(0).Item("quoteID").ToString()

        pdffield = myPDFFields.Item("TermStart")
        DirectCast(pdffield, TallComponents.PDF.Forms.Fields.TextField).Value = ds.Tables(0).Rows(0).Item("effDate").ToString()

        Dim TermEnd As Date
        Dim MonthsToAdd As Integer
        MonthsToAdd = CInt(ds.Tables(0).Rows(0).Item("term"))
        TermEnd = CDate(ds.Tables(0).Rows(0).Item("effDate").ToString()).AddMonths(MonthsToAdd)
        pdffield = myPDFFields.Item("TermEnd")
        DirectCast(pdffield, TallComponents.PDF.Forms.Fields.TextField).Value = TermEnd

        pdffield = myPDFFields.Item("DueDate")
        DirectCast(pdffield, TallComponents.PDF.Forms.Fields.TextField).Value = CDate(ds.Tables(0).Rows(0).Item("effDate").ToString())

        pdffield = myPDFFields.Item("Company")
        DirectCast(pdffield, TallComponents.PDF.Forms.Fields.TextField).Value = UCase("American Reliable " & ds.Tables(0).Rows(0).Item("ARRateType").ToString())
        pdffield = myPDFFields.Item("CompanyLocation")
        DirectCast(pdffield, TallComponents.PDF.Forms.Fields.TextField).Value = UCase(ds.Tables(0).Rows(0).Item("propAddress").ToString())
        pdffield = myPDFFields.Item("CompanyLocation2")
        DirectCast(pdffield, TallComponents.PDF.Forms.Fields.TextField).Value = UCase(ds.Tables(0).Rows(0).Item("city").ToString()) + ", " + UCase(ds.Tables(0).Rows(0).Item("state").ToString()) + " " + ds.Tables(0).Rows(0).Item("zip").ToString()

        pdffield = myPDFFields.Item("LienName")
        DirectCast(pdffield, TallComponents.PDF.Forms.Fields.TextField).Value = UCase(ds5.Tables(0).Rows(0).Item("Lien1Name").ToString())
        pdffield = myPDFFields.Item("Loan")
        DirectCast(pdffield, TallComponents.PDF.Forms.Fields.TextField).Value = UCase(ds5.Tables(0).Rows(0).Item("Lien1Num").ToString())
        pdffield = myPDFFields.Item("LienAddr1")
        DirectCast(pdffield, TallComponents.PDF.Forms.Fields.TextField).Value = UCase(ds5.Tables(0).Rows(0).Item("Lien1Addr").ToString())
        pdffield = myPDFFields.Item("LienAddr2")
        DirectCast(pdffield, TallComponents.PDF.Forms.Fields.TextField).Value = UCase(ds5.Tables(0).Rows(0).Item("Lien1Addr2").ToString())
        pdffield = myPDFFields.Item("LienCityState")
        DirectCast(pdffield, TallComponents.PDF.Forms.Fields.TextField).Value = UCase(ds5.Tables(0).Rows(0).Item("Lien1City").ToString()) & ", " & UCase(ds5.Tables(0).Rows(0).Item("Lien1State").ToString()) & " " & ds5.Tables(0).Rows(0).Item("Lien1Zip").ToString()






        For Each myPDFField As TallComponents.PDF.Forms.Fields.Field In myPDFFields
            strPDFFieldName = myPDFField.FullName
            Select Case strPDFFieldName


                'Client Section
                Case "InsuredName"
                    value = LTrim(ds.Tables(0).Rows(0).Item("applicantFirstName").ToString()) + " " + ds.Tables(0).Rows(0).Item("applicantLastName").ToString()
                    DirectCast(myPDFField, TallComponents.PDF.Forms.Fields.TextField).Value = UCase(value)
                Case "SpouseName"
                    'value = ds.Tables(0).Rows(0).Item("propAddress").ToString()
                    value = ds5.Tables(0).Rows(0).Item("SpouseName").ToString()
                    DirectCast(myPDFField, TallComponents.PDF.Forms.Fields.TextField).Value = UCase(value)
                Case "InsuredAddr1"
                    value = ds5.Tables(0).Rows(0).Item("DiffAppAddr").ToString()
                    DirectCast(myPDFField, TallComponents.PDF.Forms.Fields.TextField).Value = UCase(value)
                Case "InsuredAddr2"
                    value = ""
                    DirectCast(myPDFField, TallComponents.PDF.Forms.Fields.TextField).Value = value
                Case "InsuredCityState"
                    value = UCase(ds5.Tables(0).Rows(0).Item("DiffAppCity").ToString()) + ", " + UCase(ds5.Tables(0).Rows(0).Item("DiffAppState").ToString()) + " " + UCase(ds5.Tables(0).Rows(0).Item("DiffAppZip").ToString()) ' ds.Tables(0).Rows(0).Item("city").ToString() + " " + ds.Tables(0).Rows(0).Item("state").ToString() + " " + ds.Tables(0).Rows(0).Item("zip").ToString()
                    DirectCast(myPDFField, TallComponents.PDF.Forms.Fields.TextField).Value = value





            End Select


        Next

        Select Case ds.Tables(0).Rows(0).Item("ARRateType").ToString()
            Case "Package"
                pdffield = myPDFFields.Item("TotalDue")
                DirectCast(pdffield, TallComponents.PDF.Forms.Fields.TextField).Value = ds4.Tables(0).Rows(0).Item("ARPackageTotal").ToString()
                pdffield = myPDFFields.Item("FullPayment")
                DirectCast(pdffield, TallComponents.PDF.Forms.Fields.TextField).Value = ds4.Tables(0).Rows(0).Item("ARPackageTotal").ToString() 'String.Format("{0:C0}", Math.Round(CDbl(ds4.Tables(0).Rows(0).Item("ARPackageTotal").ToString()))).Replace("$", "")

            Case "Standard"
                pdffield = myPDFFields.Item("TotalDue")
                DirectCast(pdffield, TallComponents.PDF.Forms.Fields.TextField).Value = ds4.Tables(0).Rows(0).Item("ARStandardTotal").ToString()
                pdffield = myPDFFields.Item("FullPayment")
                DirectCast(pdffield, TallComponents.PDF.Forms.Fields.TextField).Value = ds4.Tables(0).Rows(0).Item("ARStandardTotal").ToString() 'String.Format("{0:C0}", Math.Round(CDbl(ds4.Tables(0).Rows(0).Item("ARStandardTotal").ToString()))).Replace("$", "")

            Case "Rental"
                pdffield = myPDFFields.Item("TotalDue")
                DirectCast(pdffield, TallComponents.PDF.Forms.Fields.TextField).Value = ds4.Tables(0).Rows(0).Item("ARRentalTotal").ToString()
                pdffield = myPDFFields.Item("FullPayment")
                DirectCast(pdffield, TallComponents.PDF.Forms.Fields.TextField).Value = ds4.Tables(0).Rows(0).Item("ARRentalTotal").ToString() 'String.Format("{0:C0}", Math.Round(CDbl(ds4.Tables(0).Rows(0).Item("ARRentalTotal").ToString()))).Replace("$", "")

        End Select
        For Each field As TallComponents.PDF.Forms.Fields.Field In myPDFFields
            For Each widget As Widget In field.Widgets
                widget.Persistency = WidgetPersistency.Flatten
            Next
        Next






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