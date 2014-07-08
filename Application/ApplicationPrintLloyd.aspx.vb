Imports System.Data.SqlClient
Imports System.IO

Imports TallComponents.PDF.JavaScript
Imports TallComponents.PDF.Annotations.Widgets
Imports TallComponents.PDF.Forms.Fields
Public Class ApplicationPrintLloyd
    Inherits System.Web.UI.Page
    Dim Length As String

    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        Dim AppID As String
        Dim quoteid As String

        If Request.QueryString("AppID") <> "" Then
            AppID = Request.QueryString("AppID")
            Dim ds1 As System.Data.DataSet
            Dim ds2 As System.Data.DataSet
            Dim ds3 As System.Data.DataSet
            Dim ds4 As System.Data.DataSet
            Dim ds5 As System.Data.DataSet
            Dim ds6 As System.Data.DataSet
            ' ds1 = Common.runQueryDS("SELECT * FROM tblQuotes q LEFT JOIN (SELECT DISTINCT AgencyID,AgencyCode,AgencyName,Address1 AS AgentAddr1, Address2 AS AgentAddr2,City AS AgentCity,State AS AgentState,Zip AS AgentZip, Phone AS AgentPhone FROM wrwpaqbx_ColonialWeb.wrwpaqbx_admin.vwAgents WHERE Phone <>'')vwag ON q.agencyName = vwag.AgencyName WHERE QuoteID = '" & quoteID & "'")
            ds1 = Common.runQueryDS("EXEC sp_GetLloydApplicationPrint '" & AppID & "'")
            If ds1.Tables(0).Rows.Count > 0 Then
                If ds1.Tables(0).Rows(0).Item("quoteID").ToString() = "SC" Then
                    quoteid = ds1.Tables(0).Rows(0).Item("quoteID").ToString()
                    'ds2 = Common.runQueryDS("EXEC sp_getQuotePrintPrem '" & quoteid & "'")
                    'ds3 = Common.runQueryDS("Select * from tblQuoteCalcs where QuoteID = '" & quoteid & "'")
                    ds4 = Common.runQueryDS("Select a.*,b.ARRateType,b.homeUse from tblLloydsQuotes as a Left Join tblQuotes as b on b.quoteID = a.quoteid where a.QuoteID = '" & quoteid & "'")
                    ds5 = Common.runQueryDS("Select * FROM tblColonialFinancing WHERE quoteID = '" & quoteid & "'")
                    If ds5.Tables(0).Rows.Count > 0 Then
                        Dim test As String
                        test = quoteid
                        test = ds5.Tables(0).Rows(0).Item("downPayment").ToString
                        test = ds5.Tables(0).Rows(0).Item("length").ToString
                        ds6 = Common.runQueryDS("EXEC sp_GetLloydsFinanceData '" & quoteid & "', '" & ds5.Tables(0).Rows(0).Item("downPayment").ToString & "', '" & ds5.Tables(0).Rows(0).Item("length").ToString & "'")
                        Length = ds5.Tables(0).Rows(0).Item("length").ToString
                    End If
                    PrintApplicationSC(ds1, ds4, ds6, ds5)
                Else


                    quoteid = ds1.Tables(0).Rows(0).Item("quoteID").ToString()
                    'ds2 = Common.runQueryDS("EXEC sp_getQuotePrintPrem '" & quoteid & "'")
                    'ds3 = Common.runQueryDS("Select * from tblQuoteCalcs where QuoteID = '" & quoteid & "'")
                    ds4 = Common.runQueryDS("Select a.*,b.ARRateType,b.homeUse from tblLloydsQuotes as a Left Join tblQuotes as b on b.quoteID = a.quoteid where a.QuoteID = '" & quoteid & "'")
                    ds4 = Common.runQueryDS("Select a.*,b.ARRateType,b.homeUse from tblLloydsQuotes as a Left Join tblQuotes as b on b.quoteID = a.quoteid where a.QuoteID = '" & quoteid & "'")
                    ds5 = Common.runQueryDS("Select * FROM tblColonialFinancing WHERE quoteID = '" & quoteid & "'")
                    If ds5.Tables(0).Rows.Count > 0 Then
                        Dim test As String
                        test = quoteid
                        test = ds5.Tables(0).Rows(0).Item("downPayment").ToString
                        test = ds5.Tables(0).Rows(0).Item("length").ToString
                        ds6 = Common.runQueryDS("EXEC sp_GetLloydsFinanceData '" & quoteid & "', '" & ds5.Tables(0).Rows(0).Item("downPayment").ToString & "', '" & ds5.Tables(0).Rows(0).Item("length").ToString & "'")
                        Length = ds5.Tables(0).Rows(0).Item("length").ToString
                    End If
                    If ds1.Tables(0).Rows(0).Item("State").ToString() = "DE" Then
                        PrintApplication(ds1, ds4)
                        'ElseIf ds1.Tables(0).Rows(0).Item("State").ToString() = "SC" Then
                    Else

                        PrintApplicationSC(ds1, ds4, ds6, ds5)
                    End If

                End If
            End If


        End If
    End Sub
    Public Sub PrintApplication(ByVal ds As System.Data.DataSet, ByVal ds4 As System.Data.DataSet)


        Dim myFileStream As FileStream
        Dim mySourcePDF As TallComponents.PDF.Document
        Dim myOutputPDF As TallComponents.PDF.Document
        Dim myPDFFields As New TallComponents.PDF.Document
        Dim strPDFFieldName As String = ""
        Dim value As String

        Try
            myOutputPDF = New TallComponents.PDF.Document

            myFileStream = New FileStream(Me.MapPath("~\ApplicationPages\") & "PDF\LloydAppSL.pdf", FileMode.Open, FileAccess.Read)
            'Dim form As New TallComponents.PDF.Document(myFileStream)
            mySourcePDF = New TallComponents.PDF.Document(myFileStream)
            myPDFFields.Pages.AddRange(mySourcePDF.Pages.CloneToArray())
            '  Dim form As New TallComponents.PDF.Document(myFileStream)

            myFileStream.Close()
            mySourcePDF = Nothing


            Dim pdffield As TallComponents.PDF.Forms.Fields.Field
            pdffield = myPDFFields.Fields("EffectiveDate")
            DirectCast(pdffield, TallComponents.PDF.Forms.Fields.TextField).Value = ds.Tables(0).Rows(0).Item("effDate").ToString()
            pdffield = myPDFFields.Fields("EndEffectiveDate")
            DirectCast(pdffield, TallComponents.PDF.Forms.Fields.TextField).Value = ds.Tables(0).Rows(0).Item("ToMonth").ToString()
            pdffield = myPDFFields.Fields("SLEffective Date")
            DirectCast(pdffield, TallComponents.PDF.Forms.Fields.TextField).Value = ds.Tables(0).Rows(0).Item("effDate").ToString()
            pdffield = myPDFFields.Fields("SLExpiration Date")
            DirectCast(pdffield, TallComponents.PDF.Forms.Fields.TextField).Value = ds.Tables(0).Rows(0).Item("ToMonth").ToString()
            pdffield = myPDFFields.Fields("SURPLUS LINES INSURER NAME")
            DirectCast(pdffield, TallComponents.PDF.Forms.Fields.TextField).Value = " Lloyd’s London"
            pdffield = myPDFFields.Fields("NAIC")
            DirectCast(pdffield, TallComponents.PDF.Forms.Fields.TextField).Value = "AA1122000"
            pdffield = myPDFFields.Fields("SLDESCRIPTION OF COVERAGE")
            DirectCast(pdffield, TallComponents.PDF.Forms.Fields.TextField).Value = "Mobile Home"
            'Static fields for surplus
            pdffield = myPDFFields.Fields("Name  NAIC  of Insurer")
            DirectCast(pdffield, TallComponents.PDF.Forms.Fields.TextField).Value = "American Modern Home Insurance Co."
            pdffield = myPDFFields.Fields("Among the licensed insurers declining to insure this risk or declining to increase the amount of insurance on this risk")
            DirectCast(pdffield, TallComponents.PDF.Forms.Fields.TextField).Value = " #23469"
            pdffield = myPDFFields.Fields("Name  Telephone  of Contact")
            DirectCast(pdffield, TallComponents.PDF.Forms.Fields.TextField).Value = "Todd Hiott"
            pdffield = myPDFFields.Fields("undefined")
            DirectCast(pdffield, TallComponents.PDF.Forms.Fields.TextField).Value = "800.543.2644"
            pdffield = myPDFFields.Fields("Reason for Declining")
            DirectCast(pdffield, TallComponents.PDF.Forms.Fields.TextField).Value = "Company no longer accepting new business"

            pdffield = myPDFFields.Fields("Name  NAIC  of Insurer_2")
            DirectCast(pdffield, TallComponents.PDF.Forms.Fields.TextField).Value = " American Reliable Home Insurance Co.  "
            pdffield = myPDFFields.Fields("undefined_2")
            DirectCast(pdffield, TallComponents.PDF.Forms.Fields.TextField).Value = "#19615"
            pdffield = myPDFFields.Fields("Name  Telephone  of Contact_2")
            DirectCast(pdffield, TallComponents.PDF.Forms.Fields.TextField).Value = "Judy Larson"
            pdffield = myPDFFields.Fields("undefined_3")
            DirectCast(pdffield, TallComponents.PDF.Forms.Fields.TextField).Value = "800.535.1333"
            pdffield = myPDFFields.Fields("Reason for Declining_2")
            DirectCast(pdffield, TallComponents.PDF.Forms.Fields.TextField).Value = "Company no longer accepting new business"

            pdffield = myPDFFields.Fields("Name  NAIC  of Insurer_3")
            DirectCast(pdffield, TallComponents.PDF.Forms.Fields.TextField).Value = " Markel American Insurance Co."
            pdffield = myPDFFields.Fields("undefined_4")
            DirectCast(pdffield, TallComponents.PDF.Forms.Fields.TextField).Value = "#28932"
            pdffield = myPDFFields.Fields("Name  Telephone  of Contact_3")
            DirectCast(pdffield, TallComponents.PDF.Forms.Fields.TextField).Value = "Laura Foth"
            pdffield = myPDFFields.Fields("undefined_5")
            DirectCast(pdffield, TallComponents.PDF.Forms.Fields.TextField).Value = " 262.548.9880"
            pdffield = myPDFFields.Fields("Reason for Declining_3")
            DirectCast(pdffield, TallComponents.PDF.Forms.Fields.TextField).Value = "Company no longer accepting new business"

            pdffield = myPDFFields.Fields("Syndicates")
            DirectCast(pdffield, TallComponents.PDF.Forms.Fields.TextField).Value = "*Additional Lloyd’s Syndicates: AA1126510, AA1120054, AA1128003 and AA1128121"






            pdffield = myPDFFields.Fields("SLName")
            DirectCast(pdffield, TallComponents.PDF.Forms.Fields.TextField).Value = UCase(ds.Tables(0).Rows(0).Item("Name").ToString())
            pdffield = myPDFFields.Fields("SLAddress 1")
            DirectCast(pdffield, TallComponents.PDF.Forms.Fields.TextField).Value = UCase(ds.Tables(0).Rows(0).Item("mailAddress").ToString())
            pdffield = myPDFFields.Fields("SLAddress 2")
            DirectCast(pdffield, TallComponents.PDF.Forms.Fields.TextField).Value = UCase(ds.Tables(0).Rows(0).Item("AddInsuredCity").ToString() & ",  " & ds.Tables(0).Rows(0).Item("AddInsuredState").ToString() & "  " & ds.Tables(0).Rows(0).Item("mailZip").ToString())
            pdffield = myPDFFields.Fields("LOCATION OF RISK")
            DirectCast(pdffield, TallComponents.PDF.Forms.Fields.TextField).Value = UCase(ds.Tables(0).Rows(0).Item("propAddress").ToString() & "  " & ds.Tables(0).Rows(0).Item("City").ToString() & ", " & ds.Tables(0).Rows(0).Item("State").ToString() & "  " & ds.Tables(0).Rows(0).Item("propAppZip").ToString())

            pdffield = myPDFFields.Fields("ProducerNumber")
            DirectCast(pdffield, TallComponents.PDF.Forms.Fields.TextField).Value = ds.Tables(0).Rows(0).Item("AgencyCode").ToString()
            pdffield = myPDFFields.Fields("SLProperty")
            DirectCast(pdffield, TallComponents.PDF.Forms.Fields.TextField).Value = ds4.Tables(0).Rows(0).Item("PackDwel").ToString()
            If ds.Tables(0).Rows(0).Item("Lien1Num").ToString() <> "" Then
                pdffield = myPDFFields.Fields("Lien1Number")
                DirectCast(pdffield, TallComponents.PDF.Forms.Fields.TextField).Value = "Loan #  " & ds.Tables(0).Rows(0).Item("Lien1Num").ToString()
                'Lien
                pdffield = myPDFFields.Fields("Lien1Name")
                DirectCast(pdffield, TallComponents.PDF.Forms.Fields.TextField).Value = UCase(ds.Tables(0).Rows(0).Item("Lien1Name").ToString())
                'pdffield = myPDFFields.Fields("Lien1Account")
                'DirectCast(pdffield, TallComponents.PDF.Forms.Fields.TextField).Value = UCase(ds.Tables(0).Rows(0).Item("Lien1Num").ToString())
                pdffield = myPDFFields.Fields("Lien1Address")
                DirectCast(pdffield, TallComponents.PDF.Forms.Fields.TextField).Value = UCase(ds.Tables(0).Rows(0).Item("Lien1Addr").ToString() & vbCrLf & ds.Tables(0).Rows(0).Item("Lien1City").ToString() & ",  " & ds.Tables(0).Rows(0).Item("Lien1State").ToString() & "  " & ds.Tables(0).Rows(0).Item("Lien1Zip").ToString())

            End If
            If ds.Tables(0).Rows(0).Item("Lien2Num").ToString() <> "" Then
                pdffield = myPDFFields.Fields("Lien2Number")
                DirectCast(pdffield, TallComponents.PDF.Forms.Fields.TextField).Value = "Loan #  " & ds.Tables(0).Rows(0).Item("Lien2Num").ToString()
                pdffield = myPDFFields.Fields("Lien2Name")
                DirectCast(pdffield, TallComponents.PDF.Forms.Fields.TextField).Value = ds.Tables(0).Rows(0).Item("Lien2Name").ToString()
                'pdffield = myPDFFields.Fields("Lien2Account")
                'DirectCast(pdffield, TallComponents.PDF.Forms.Fields.TextField).Value = ds.Tables(0).Rows(0).Item("Lien2Num").ToString()
                pdffield = myPDFFields.Fields("Lien3Address")
                DirectCast(pdffield, TallComponents.PDF.Forms.Fields.TextField).Value = ds.Tables(0).Rows(0).Item("Lien2Addr").ToString() & vbCrLf & ds.Tables(0).Rows(0).Item("Lien2City").ToString() & ",  " & ds.Tables(0).Rows(0).Item("Lien2State").ToString() & "  " & ds.Tables(0).Rows(0).Item("Lien2Zip").ToString()

            End If

            pdffield = myPDFFields.Fields("InsuredName")
            DirectCast(pdffield, TallComponents.PDF.Forms.Fields.TextField).Value = UCase(ds.Tables(0).Rows(0).Item("Name").ToString())
            pdffield = myPDFFields.Fields("InsuredAddress")
            DirectCast(pdffield, TallComponents.PDF.Forms.Fields.TextField).Value = UCase(ds.Tables(0).Rows(0).Item("mailAddress").ToString())
            pdffield = myPDFFields.Fields("InsuredAddress2")
            DirectCast(pdffield, TallComponents.PDF.Forms.Fields.TextField).Value = UCase(ds.Tables(0).Rows(0).Item("AddInsuredCity").ToString() & ",  " & ds.Tables(0).Rows(0).Item("AddInsuredState").ToString() & "  " & ds.Tables(0).Rows(0).Item("mailZip").ToString())
            pdffield = myPDFFields.Fields("LOCATION ADDRESS")
            DirectCast(pdffield, TallComponents.PDF.Forms.Fields.TextField).Value = UCase(ds.Tables(0).Rows(0).Item("propAddress").ToString() & "  " & ds.Tables(0).Rows(0).Item("City").ToString() & ",  " & ds.Tables(0).Rows(0).Item("State").ToString() & "  " & ds.Tables(0).Rows(0).Item("propAppZip").ToString())
            pdffield = myPDFFields.Fields("ProducerName")
            DirectCast(pdffield, TallComponents.PDF.Forms.Fields.TextField).Value = ds.Tables(0).Rows(0).Item("AgencyName").ToString()
            If ds.Tables(0).Rows(0).Item("AgentAddr1").ToString() <> "" Then
                pdffield = myPDFFields.Fields("ProducerAddress")
                DirectCast(pdffield, TallComponents.PDF.Forms.Fields.TextField).Value = UCase(ds.Tables(0).Rows(0).Item("AgentAddr1").ToString())

            Else
                pdffield = myPDFFields.Fields("ProducerAddress")
                DirectCast(pdffield, TallComponents.PDF.Forms.Fields.TextField).Value = UCase(ds.Tables(0).Rows(0).Item("AgentAddr2").ToString())

            End If
            pdffield = myPDFFields.Fields("ProducerAddress2")
            DirectCast(pdffield, TallComponents.PDF.Forms.Fields.TextField).Value = UCase(ds.Tables(0).Rows(0).Item("AgentCity").ToString() & ",  " & ds.Tables(0).Rows(0).Item("AgentState").ToString() & "  " & ds.Tables(0).Rows(0).Item("AgentZip").ToString())
            pdffield = myPDFFields.Fields("YEARRow1")
            DirectCast(pdffield, TallComponents.PDF.Forms.Fields.TextField).Value = ds.Tables(0).Rows(0).Item("DescMHYear").ToString()
            pdffield = myPDFFields.Fields("MANUFACTURERRow1")
            DirectCast(pdffield, TallComponents.PDF.Forms.Fields.TextField).Value = ds.Tables(0).Rows(0).Item("DescMHManf").ToString()
            pdffield = myPDFFields.Fields("SERIAL NUMBERRow1")
            DirectCast(pdffield, TallComponents.PDF.Forms.Fields.TextField).Value = ds.Tables(0).Rows(0).Item("DescMHSerial").ToString()
            pdffield = myPDFFields.Fields("LENGTHWIDTHRow1")
            DirectCast(pdffield, TallComponents.PDF.Forms.Fields.TextField).Value = ds.Tables(0).Rows(0).Item("DescMHLength").ToString() & "/" & ds.Tables(0).Rows(0).Item("DescMHWidth").ToString()
            pdffield = myPDFFields.Fields("PURCHASE DATERow1")
            DirectCast(pdffield, TallComponents.PDF.Forms.Fields.TextField).Value = ds.Tables(0).Rows(0).Item("DescMHPurDate").ToString()
            pdffield = myPDFFields.Fields("PURCHASE PRICERow1")
            DirectCast(pdffield, TallComponents.PDF.Forms.Fields.TextField).Value = CInt(ds.Tables(0).Rows(0).Item("DescMHPurPrice").ToString())
            pdffield = myPDFFields.Fields("Occupancy")
            DirectCast(pdffield, TallComponents.PDF.Forms.Fields.TextField).Value = ds4.Tables(0).Rows(0).Item("homeUse").ToString()
            pdffield = myPDFFields.Fields("ProtectionClass")
            DirectCast(pdffield, TallComponents.PDF.Forms.Fields.TextField).Value = ds.Tables(0).Rows(0).Item("protClass").ToString()
            pdffield = myPDFFields.Fields("Territory")
            DirectCast(pdffield, TallComponents.PDF.Forms.Fields.TextField).Value = ds.Tables(0).Rows(0).Item("territory").ToString()
            Dim dist As String
            dist = ds.Tables(0).Rows(0).Item("DistToGulf").ToString()
            If dist = "Greater than 5 miles" Then
                dist = "5+ Miles"
            End If
            pdffield = myPDFFields.Fields("DistToCoast")
            DirectCast(pdffield, TallComponents.PDF.Forms.Fields.TextField).Value = dist 'ds.Tables(0).Rows(0).Item("DistToGulf").ToString()
            pdffield = myPDFFields.Fields("FoundationType")
            DirectCast(pdffield, TallComponents.PDF.Forms.Fields.TextField).Value = ds.Tables(0).Rows(0).Item("skirting").ToString()
            pdffield = myPDFFields.Fields("InPark")
            DirectCast(pdffield, TallComponents.PDF.Forms.Fields.TextField).Value = ds.Tables(0).Rows(0).Item("ParkStatus").ToString()
            'Hurrican for Delaware is standard $1500
            'pdffield = myPDFFields.Fields("Hurricane")
            'DirectCast(pdffield, TallComponents.PDF.Forms.Fields.TextField).Value = "$1500"


            'If ds.Tables(0).Rows(0).Item("ARIng1").ToString() = "None" Or ds.Tables(0).Rows(0).Item("ARIng1").ToString() = "No" Then
            '    pdffield = myPDFFields.Fields("FirePlace")
            '    DirectCast(pdffield, TallComponents.PDF.Forms.Fields.TextField).Value = "No"
            'Else
            '    pdffield = myPDFFields.Fields("FirePlace")
            '    DirectCast(pdffield, TallComponents.PDF.Forms.Fields.TextField).Value = "Yes"
            'End If

            pdffield = myPDFFields.Fields("FirePlace")
            DirectCast(pdffield, TallComponents.PDF.Forms.Fields.TextField).Value = ds.Tables(0).Rows(0).Item("ARIng1").ToString()

            pdffield = myPDFFields.Fields("Bussiness")
            DirectCast(pdffield, TallComponents.PDF.Forms.Fields.TextField).Value = ds.Tables(0).Rows(0).Item("ARIng2").ToString()
            pdffield = myPDFFields.Fields("Farming")
            DirectCast(pdffield, TallComponents.PDF.Forms.Fields.TextField).Value = ds.Tables(0).Rows(0).Item("ARIng3").ToString()
            pdffield = myPDFFields.Fields("Animals")
            DirectCast(pdffield, TallComponents.PDF.Forms.Fields.TextField).Value = ds.Tables(0).Rows(0).Item("ARIng4").ToString()
            pdffield = myPDFFields.Fields("Swimmingpool")
            DirectCast(pdffield, TallComponents.PDF.Forms.Fields.TextField).Value = ds.Tables(0).Rows(0).Item("ARIng5").ToString()
            pdffield = myPDFFields.Fields("Repo")
            DirectCast(pdffield, TallComponents.PDF.Forms.Fields.TextField).Value = ds.Tables(0).Rows(0).Item("ARIng6").ToString()
            pdffield = myPDFFields.Fields("Bankrupt")
            DirectCast(pdffield, TallComponents.PDF.Forms.Fields.TextField).Value = ds.Tables(0).Rows(0).Item("ARIng7").ToString()
            pdffield = myPDFFields.Fields("Claims")
            DirectCast(pdffield, TallComponents.PDF.Forms.Fields.TextField).Value = ds.Tables(0).Rows(0).Item("ARIng8").ToString()
            pdffield = myPDFFields.Fields("Urepaired")
            DirectCast(pdffield, TallComponents.PDF.Forms.Fields.TextField).Value = ds.Tables(0).Rows(0).Item("ARIng9").ToString()
            pdffield = myPDFFields.Fields("Rails")
            DirectCast(pdffield, TallComponents.PDF.Forms.Fields.TextField).Value = ds.Tables(0).Rows(0).Item("ARIng10").ToString()
            pdffield = myPDFFields.Fields("MpastDue")
            DirectCast(pdffield, TallComponents.PDF.Forms.Fields.TextField).Value = ds.Tables(0).Rows(0).Item("ARIng11").ToString()
            pdffield = myPDFFields.Fields("Heater")
            DirectCast(pdffield, TallComponents.PDF.Forms.Fields.TextField).Value = ds.Tables(0).Rows(0).Item("ARIng12").ToString()

            Select Case ds4.Tables(0).Rows(0).Item("ARRateType").ToString()
                Case "Package"
                    pdffield = myPDFFields.Fields("MHLimit")
                    DirectCast(pdffield, TallComponents.PDF.Forms.Fields.TextField).Value = "$" & ds4.Tables(0).Rows(0).Item("PackDwel").ToString().Replace("$", "").Replace(",", "")
                    pdffield = myPDFFields.Fields("MHPremium")
                    DirectCast(pdffield, TallComponents.PDF.Forms.Fields.TextField).Value = "$" & ds4.Tables(0).Rows(0).Item("Packprem").ToString().Replace("$", "").Replace(",", "")
                    pdffield = myPDFFields.Fields("MHAddStructLimit")
                    DirectCast(pdffield, TallComponents.PDF.Forms.Fields.TextField).Value = "$" & ds4.Tables(0).Rows(0).Item("PackStruc").ToString().Replace("$", "").Replace(",", "")
                    pdffield = myPDFFields.Fields("MHAddSTructPremium")
                    DirectCast(pdffield, TallComponents.PDF.Forms.Fields.TextField).Value = "$" & ds4.Tables(0).Rows(0).Item("PackStrucPrem").ToString().Replace("$", "").Replace(",", "")
                    pdffield = myPDFFields.Fields("MHPersonalLimit")
                    DirectCast(pdffield, TallComponents.PDF.Forms.Fields.TextField).Value = "$" & ds4.Tables(0).Rows(0).Item("PackCont").ToString().Replace("$", "").Replace(",", "")
                    pdffield = myPDFFields.Fields("MHPersonalPrem")
                    DirectCast(pdffield, TallComponents.PDF.Forms.Fields.TextField).Value = "$" & ds4.Tables(0).Rows(0).Item("PackContPrem").ToString().Replace("$", "").Replace(",", "")
                    pdffield = myPDFFields.Fields("MHLiabilityLimit")
                    DirectCast(pdffield, TallComponents.PDF.Forms.Fields.TextField).Value = "$" & ds4.Tables(0).Rows(0).Item("PackLiab").ToString().Replace("$", "").Replace(",", "")

                    pdffield = myPDFFields.Fields("MMDDYYYY Format")
                    DirectCast(pdffield, TallComponents.PDF.Forms.Fields.TextField).Value = "$" & ds4.Tables(0).Rows(0).Item("PackLiab").ToString().Replace("$", "").Replace(",", "")

                    pdffield = myPDFFields.Fields("MHLiabilityPrem")
                    DirectCast(pdffield, TallComponents.PDF.Forms.Fields.TextField).Value = "$" & ds4.Tables(0).Rows(0).Item("PackPersLiabPrem").ToString().Replace("$", "").Replace(",", "")
                    pdffield = myPDFFields.Fields("MHMedLimit")
                    DirectCast(pdffield, TallComponents.PDF.Forms.Fields.TextField).Value = "$" & ds4.Tables(0).Rows(0).Item("PackMedPay").ToString().Replace("$", "").Replace(",", "")
                    If ds4.Tables(0).Rows(0).Item("PackMedPrem").ToString().Replace("$", "") > "0.00" Then
                        pdffield = myPDFFields.Fields("MHMedPrem")
                        DirectCast(pdffield, TallComponents.PDF.Forms.Fields.TextField).Value = "$" & ds4.Tables(0).Rows(0).Item("PackMedPrem").ToString().Replace("$", "")

                    End If
                    pdffield = myPDFFields.Fields("TotalPrem")
                    DirectCast(pdffield, TallComponents.PDF.Forms.Fields.TextField).Value = "$" & ds4.Tables(0).Rows(0).Item("Packtotal").ToString().Replace("$", "").Replace(",", "")

                    If ds4.Tables(0).Rows(0).Item("PackContReplace").ToString().Replace("$", "") > "No" Then
                        pdffield = myPDFFields.Fields("Optional1")
                        DirectCast(pdffield, TallComponents.PDF.Forms.Fields.TextField).Value = "Content Replacement"
                        pdffield = myPDFFields.Fields("Opt1prem")
                        DirectCast(pdffield, TallComponents.PDF.Forms.Fields.TextField).Value = "$" & ds4.Tables(0).Rows(0).Item("PackContReplacePrem").ToString().Replace("$", "")

                    End If
                    If ds4.Tables(0).Rows(0).Item("PackMHReplace").ToString().Replace("$", "") > "No" Then
                        pdffield = myPDFFields.Fields("Optional2")
                        DirectCast(pdffield, TallComponents.PDF.Forms.Fields.TextField).Value = "Mobile Home Replacement"
                        pdffield = myPDFFields.Fields("Opt2prem")
                        DirectCast(pdffield, TallComponents.PDF.Forms.Fields.TextField).Value = "$" & ds4.Tables(0).Rows(0).Item("PackMHReplacePrem").ToString().Replace("$", "")

                    End If
                    If ds4.Tables(0).Rows(0).Item("PackFullRepair").ToString().Replace("$", "") > "No" Then
                        pdffield = myPDFFields.Fields("Optional3")
                        DirectCast(pdffield, TallComponents.PDF.Forms.Fields.TextField).Value = "Full Repair"
                        pdffield = myPDFFields.Fields("Opt3prem")
                        DirectCast(pdffield, TallComponents.PDF.Forms.Fields.TextField).Value = "$" & ds4.Tables(0).Rows(0).Item("PackFullRepairPrem").ToString().Replace("$", "")

                    End If

                    If ds4.Tables(0).Rows(0).Item("homeUse").ToString() = "Seasonal" Then

                        pdffield = myPDFFields.Fields("Surcharge")
                        DirectCast(pdffield, TallComponents.PDF.Forms.Fields.TextField).Value = "$20"
                        pdffield = myPDFFields.Fields("Surchargedesc")
                        DirectCast(pdffield, TallComponents.PDF.Forms.Fields.TextField).Value = "Seasonal Fee"
                        pdffield = myPDFFields.Fields("CertFee")
                        DirectCast(pdffield, TallComponents.PDF.Forms.Fields.TextField).Value = "$" & CInt(ds4.Tables(0).Rows(0).Item("PackFees").ToString().Replace("$", "")) - 20

                    Else
                        pdffield = myPDFFields.Fields("CertFee")
                        DirectCast(pdffield, TallComponents.PDF.Forms.Fields.TextField).Value = "$" & ds4.Tables(0).Rows(0).Item("PackFees").ToString().Replace("$", "")
                    End If
                    pdffield = myPDFFields.Fields("StateTax")
                    DirectCast(pdffield, TallComponents.PDF.Forms.Fields.TextField).Value = "$" & ds4.Tables(0).Rows(0).Item("PackTax").ToString().Replace("$", "")


                    'all other perils
                    pdffield = myPDFFields.Fields("OtherPeril")
                    DirectCast(pdffield, TallComponents.PDF.Forms.Fields.TextField).Value = "$" & ds4.Tables(0).Rows(0).Item("PackAOP").ToString().Replace("$", "")

                    pdffield = myPDFFields.Fields("WindHail")
                    DirectCast(pdffield, TallComponents.PDF.Forms.Fields.TextField).Value = "$" & ds4.Tables(0).Rows(0).Item("PackWind").ToString().Replace("$", "")
                    pdffield = myPDFFields.Fields("Hurricane")
                    DirectCast(pdffield, TallComponents.PDF.Forms.Fields.TextField).Value = "$" & ds4.Tables(0).Rows(0).Item("PackWind").ToString().Replace("$", "")


                    If ds4.Tables(0).Rows(0).Item("PackCreditamt").ToString().Replace("$", "") > "0" Or ds4.Tables(0).Rows(0).Item("PackAOPPrem").ToString().Replace("$", "").Replace("(", "").Replace(")", "") > "0" Then

                        pdffield = myPDFFields.Fields("MHCreditDesc")
                        DirectCast(pdffield, TallComponents.PDF.Forms.Fields.TextField).Value = "Credit(s)"
                        If ds4.Tables(0).Rows(0).Item("PackAOPPrem").ToString().Replace("$", "").Replace("(", "").Replace(")", "") > "0" Then
                            pdffield = myPDFFields.Fields("MHCredits")
                            DirectCast(pdffield, TallComponents.PDF.Forms.Fields.TextField).Value = "($-" & CInt(ds4.Tables(0).Rows(0).Item("PackAOPPrem").ToString().Replace("$", "").Replace("(", "").Replace(")", "")) + ds4.Tables(0).Rows(0).Item("PackCreditamt").ToString().Replace("$", "") & ")"

                        Else
                            pdffield = myPDFFields.Fields("MHCredits")
                            DirectCast(pdffield, TallComponents.PDF.Forms.Fields.TextField).Value = "($-" & ds4.Tables(0).Rows(0).Item("PackCreditamt").ToString().Replace("$", "") & ")"


                        End If

                    End If
                Case "Standard"
                    pdffield = myPDFFields.Fields("MHLimit")
                    DirectCast(pdffield, TallComponents.PDF.Forms.Fields.TextField).Value = "$" & ds4.Tables(0).Rows(0).Item("StandDwel").ToString().Replace("$", "").Replace(",", "")
                    pdffield = myPDFFields.Fields("MHPremium")
                    DirectCast(pdffield, TallComponents.PDF.Forms.Fields.TextField).Value = "$" & ds4.Tables(0).Rows(0).Item("Standprem").ToString().Replace("$", "").Replace(",", "")
                    pdffield = myPDFFields.Fields("MHAddStructLimit")
                    DirectCast(pdffield, TallComponents.PDF.Forms.Fields.TextField).Value = "$" & ds4.Tables(0).Rows(0).Item("StandStruc").ToString().Replace("$", "").Replace(",", "")
                    pdffield = myPDFFields.Fields("MHAddSTructPremium")
                    DirectCast(pdffield, TallComponents.PDF.Forms.Fields.TextField).Value = "$" & ds4.Tables(0).Rows(0).Item("StandStrucPrem").ToString().Replace("$", "").Replace(",", "")
                    pdffield = myPDFFields.Fields("MHPersonalLimit")
                    DirectCast(pdffield, TallComponents.PDF.Forms.Fields.TextField).Value = "$" & ds4.Tables(0).Rows(0).Item("StandCont").ToString().Replace("$", "").Replace(",", "")
                    pdffield = myPDFFields.Fields("MHPersonalPrem")
                    DirectCast(pdffield, TallComponents.PDF.Forms.Fields.TextField).Value = "$" & ds4.Tables(0).Rows(0).Item("StandContPrem").ToString().Replace("$", "").Replace(",", "")
                    pdffield = myPDFFields.Fields("MHLiabilityLimit")
                    DirectCast(pdffield, TallComponents.PDF.Forms.Fields.TextField).Value = "$" & ds4.Tables(0).Rows(0).Item("StandLiab").ToString().Replace("$", "").Replace(",", "")

                    pdffield = myPDFFields.Fields("MMDDYYYY Format")
                    DirectCast(pdffield, TallComponents.PDF.Forms.Fields.TextField).Value = "$" & ds4.Tables(0).Rows(0).Item("StandLiab").ToString().Replace("$", "").Replace(",", "")

                    pdffield = myPDFFields.Fields("MHLiabilityPrem")
                    DirectCast(pdffield, TallComponents.PDF.Forms.Fields.TextField).Value = "$" & ds4.Tables(0).Rows(0).Item("StandPersLiabPrem").ToString().Replace("$", "").Replace(",", "")
                    pdffield = myPDFFields.Fields("MHMedLimit")
                    DirectCast(pdffield, TallComponents.PDF.Forms.Fields.TextField).Value = "$" & ds4.Tables(0).Rows(0).Item("StandMedPay").ToString().Replace("$", "").Replace(",", "")
                    If ds4.Tables(0).Rows(0).Item("StandMedPrem").ToString().Replace("$", "") > "0.00" Then
                        pdffield = myPDFFields.Fields("MHMedPrem")
                        DirectCast(pdffield, TallComponents.PDF.Forms.Fields.TextField).Value = "$" & ds4.Tables(0).Rows(0).Item("StandMedPrem").ToString().Replace("$", "")

                    End If
                    pdffield = myPDFFields.Fields("TotalPrem")
                    DirectCast(pdffield, TallComponents.PDF.Forms.Fields.TextField).Value = "$" & ds4.Tables(0).Rows(0).Item("Standtotal").ToString().Replace("$", "").Replace(",", "")

                    If ds4.Tables(0).Rows(0).Item("StandContReplace").ToString().Replace("$", "") > "No" Then
                        pdffield = myPDFFields.Fields("Optional1")
                        DirectCast(pdffield, TallComponents.PDF.Forms.Fields.TextField).Value = "Content Replacement"
                        pdffield = myPDFFields.Fields("Opt1prem")
                        DirectCast(pdffield, TallComponents.PDF.Forms.Fields.TextField).Value = "$" & ds4.Tables(0).Rows(0).Item("StandContReplacePrem").ToString().Replace("$", "")

                    End If
                    If ds4.Tables(0).Rows(0).Item("StandMHReplace").ToString().Replace("$", "") > "No" Then
                        pdffield = myPDFFields.Fields("Optional2")
                        DirectCast(pdffield, TallComponents.PDF.Forms.Fields.TextField).Value = "Mobile Home Replacement"
                        pdffield = myPDFFields.Fields("Opt2prem")
                        DirectCast(pdffield, TallComponents.PDF.Forms.Fields.TextField).Value = "$" & ds4.Tables(0).Rows(0).Item("StandMHReplacePrem").ToString().Replace("$", "")

                    End If
                    If ds4.Tables(0).Rows(0).Item("StandFullRepair").ToString().Replace("$", "") > "No" Then
                        pdffield = myPDFFields.Fields("Optional3")
                        DirectCast(pdffield, TallComponents.PDF.Forms.Fields.TextField).Value = "Full Repair"
                        pdffield = myPDFFields.Fields("Opt3prem")
                        DirectCast(pdffield, TallComponents.PDF.Forms.Fields.TextField).Value = "$" & ds4.Tables(0).Rows(0).Item("StandFullRepairPrem").ToString().Replace("$", "")

                    End If

                    If ds4.Tables(0).Rows(0).Item("homeUse").ToString() = "Seasonal" Then

                        pdffield = myPDFFields.Fields("Surcharge")
                        DirectCast(pdffield, TallComponents.PDF.Forms.Fields.TextField).Value = "$20"
                        pdffield = myPDFFields.Fields("Surchargedesc")
                        DirectCast(pdffield, TallComponents.PDF.Forms.Fields.TextField).Value = "Seasonal Fee"
                        pdffield = myPDFFields.Fields("CertFee")
                        DirectCast(pdffield, TallComponents.PDF.Forms.Fields.TextField).Value = "$" & CInt(ds4.Tables(0).Rows(0).Item("StandFees").ToString().Replace("$", "")) - 20

                    Else
                        pdffield = myPDFFields.Fields("CertFee")
                        DirectCast(pdffield, TallComponents.PDF.Forms.Fields.TextField).Value = "$" & ds4.Tables(0).Rows(0).Item("StandFees").ToString().Replace("$", "")
                    End If
                    pdffield = myPDFFields.Fields("StateTax")
                    DirectCast(pdffield, TallComponents.PDF.Forms.Fields.TextField).Value = "$" & ds4.Tables(0).Rows(0).Item("StandTax").ToString().Replace("$", "")


                    'all other perils
                    pdffield = myPDFFields.Fields("OtherPeril")
                    DirectCast(pdffield, TallComponents.PDF.Forms.Fields.TextField).Value = "$" & ds4.Tables(0).Rows(0).Item("StandAOP").ToString().Replace("$", "")

                    pdffield = myPDFFields.Fields("WindHail")
                    DirectCast(pdffield, TallComponents.PDF.Forms.Fields.TextField).Value = "$" & ds4.Tables(0).Rows(0).Item("StandWind").ToString().Replace("$", "")
                    pdffield = myPDFFields.Fields("Hurricane")
                    DirectCast(pdffield, TallComponents.PDF.Forms.Fields.TextField).Value = "$" & ds4.Tables(0).Rows(0).Item("StandWind").ToString().Replace("$", "")


                    If ds4.Tables(0).Rows(0).Item("StandCreditamt").ToString().Replace("$", "") > "0" Or ds4.Tables(0).Rows(0).Item("StandAOPPrem").ToString().Replace("$", "").Replace("(", "").Replace(")", "") > "0" Then

                        pdffield = myPDFFields.Fields("MHCreditDesc")
                        DirectCast(pdffield, TallComponents.PDF.Forms.Fields.TextField).Value = "Credit(s)"
                        If ds4.Tables(0).Rows(0).Item("StandAOPPrem").ToString().Replace("$", "").Replace("(", "").Replace(")", "") > "0" Then
                            pdffield = myPDFFields.Fields("MHCredits")
                            DirectCast(pdffield, TallComponents.PDF.Forms.Fields.TextField).Value = "($-" & CInt(ds4.Tables(0).Rows(0).Item("StandAOPPrem").ToString().Replace("$", "").Replace("(", "").Replace(")", "")) + ds4.Tables(0).Rows(0).Item("StandCreditamt").ToString().Replace("$", "") & ")"

                        Else
                            pdffield = myPDFFields.Fields("MHCredits")
                            DirectCast(pdffield, TallComponents.PDF.Forms.Fields.TextField).Value = "($-" & ds4.Tables(0).Rows(0).Item("StandCreditamt").ToString().Replace("$", "") & ")"


                        End If

                    End If

                Case "Rental"
                    pdffield = myPDFFields.Fields("MHLimit")
                    DirectCast(pdffield, TallComponents.PDF.Forms.Fields.TextField).Value = "$" & ds4.Tables(0).Rows(0).Item("RentDwel").ToString().Replace("$", "").Replace(",", "")
                    pdffield = myPDFFields.Fields("MHPremium")
                    DirectCast(pdffield, TallComponents.PDF.Forms.Fields.TextField).Value = "$" & ds4.Tables(0).Rows(0).Item("Rentprem").ToString().Replace("$", "").Replace(",", "")
                    pdffield = myPDFFields.Fields("MHAddStructLimit")
                    DirectCast(pdffield, TallComponents.PDF.Forms.Fields.TextField).Value = "$" & ds4.Tables(0).Rows(0).Item("RentStruc").ToString().Replace("$", "").Replace(",", "")
                    pdffield = myPDFFields.Fields("MHAddSTructPremium")
                    DirectCast(pdffield, TallComponents.PDF.Forms.Fields.TextField).Value = "$" & ds4.Tables(0).Rows(0).Item("RentStrucPrem").ToString().Replace("$", "").Replace(",", "")
                    pdffield = myPDFFields.Fields("MHPersonalLimit")
                    DirectCast(pdffield, TallComponents.PDF.Forms.Fields.TextField).Value = "$" & ds4.Tables(0).Rows(0).Item("RentCont").ToString().Replace("$", "").Replace(",", "")
                    pdffield = myPDFFields.Fields("MHPersonalPrem")
                    DirectCast(pdffield, TallComponents.PDF.Forms.Fields.TextField).Value = "$" & ds4.Tables(0).Rows(0).Item("RentContPrem").ToString().Replace("$", "").Replace(",", "")
                    pdffield = myPDFFields.Fields("MHLiabilityLimit")
                    DirectCast(pdffield, TallComponents.PDF.Forms.Fields.TextField).Value = "$" & ds4.Tables(0).Rows(0).Item("RentLiab").ToString().Replace("$", "").Replace(",", "")

                    pdffield = myPDFFields.Fields("MMDDYYYY Format")
                    DirectCast(pdffield, TallComponents.PDF.Forms.Fields.TextField).Value = "$" & ds4.Tables(0).Rows(0).Item("RentLiab").ToString().Replace("$", "").Replace(",", "")

                    pdffield = myPDFFields.Fields("MHLiabilityPrem")
                    DirectCast(pdffield, TallComponents.PDF.Forms.Fields.TextField).Value = "$" & ds4.Tables(0).Rows(0).Item("RentPersLiabPrem").ToString().Replace("$", "").Replace(",", "")
                    pdffield = myPDFFields.Fields("MHMedLimit")
                    DirectCast(pdffield, TallComponents.PDF.Forms.Fields.TextField).Value = "$" & ds4.Tables(0).Rows(0).Item("RentMedPay").ToString().Replace("$", "")
                    If ds4.Tables(0).Rows(0).Item("RentMedPrem").ToString().Replace("$", "") > "0.00" Then
                        pdffield = myPDFFields.Fields("MHMedPrem")
                        DirectCast(pdffield, TallComponents.PDF.Forms.Fields.TextField).Value = "$" & ds4.Tables(0).Rows(0).Item("RentMedPrem").ToString().Replace("$", "")

                    End If
                    pdffield = myPDFFields.Fields("TotalPrem")
                    DirectCast(pdffield, TallComponents.PDF.Forms.Fields.TextField).Value = "$" & ds4.Tables(0).Rows(0).Item("Renttotal").ToString().Replace("$", "").Replace(",", "")

                    If ds4.Tables(0).Rows(0).Item("RentContReplace").ToString().Replace("$", "") > "No" Then
                        pdffield = myPDFFields.Fields("Optional1")
                        DirectCast(pdffield, TallComponents.PDF.Forms.Fields.TextField).Value = "Content Replacement"
                        pdffield = myPDFFields.Fields("Opt1prem")
                        DirectCast(pdffield, TallComponents.PDF.Forms.Fields.TextField).Value = "$" & ds4.Tables(0).Rows(0).Item("RentContReplacePrem").ToString().Replace("$", "")

                    End If
                    If ds4.Tables(0).Rows(0).Item("RentMHReplace").ToString().Replace("$", "") > "No" Then
                        pdffield = myPDFFields.Fields("Optional2")
                        DirectCast(pdffield, TallComponents.PDF.Forms.Fields.TextField).Value = "Mobile Home Replacement"
                        pdffield = myPDFFields.Fields("Opt2prem")
                        DirectCast(pdffield, TallComponents.PDF.Forms.Fields.TextField).Value = "$" & ds4.Tables(0).Rows(0).Item("RentMHReplacePrem").ToString().Replace("$", "")

                    End If
                    If ds4.Tables(0).Rows(0).Item("RentFullRepair").ToString().Replace("$", "") > "No" Then
                        pdffield = myPDFFields.Fields("Optional3")
                        DirectCast(pdffield, TallComponents.PDF.Forms.Fields.TextField).Value = "Full Repair"
                        pdffield = myPDFFields.Fields("Opt3prem")
                        DirectCast(pdffield, TallComponents.PDF.Forms.Fields.TextField).Value = "$" & ds4.Tables(0).Rows(0).Item("RentFullRepairPrem").ToString().Replace("$", "")

                    End If

                    If ds4.Tables(0).Rows(0).Item("homeUse").ToString() = "Seasonal" Then

                        pdffield = myPDFFields.Fields("Surcharge")
                        DirectCast(pdffield, TallComponents.PDF.Forms.Fields.TextField).Value = "$20"
                        pdffield = myPDFFields.Fields("Surchargedesc")
                        DirectCast(pdffield, TallComponents.PDF.Forms.Fields.TextField).Value = "Seasonal Fee"
                        pdffield = myPDFFields.Fields("CertFee")
                        DirectCast(pdffield, TallComponents.PDF.Forms.Fields.TextField).Value = "$" & CInt(ds4.Tables(0).Rows(0).Item("RentFees").ToString().Replace("$", "")) - 20

                    Else
                        pdffield = myPDFFields.Fields("CertFee")
                        DirectCast(pdffield, TallComponents.PDF.Forms.Fields.TextField).Value = "$" & ds4.Tables(0).Rows(0).Item("RentFees").ToString().Replace("$", "")
                    End If
                    pdffield = myPDFFields.Fields("StateTax")
                    DirectCast(pdffield, TallComponents.PDF.Forms.Fields.TextField).Value = "$" & ds4.Tables(0).Rows(0).Item("RentTax").ToString().Replace("$", "")


                    'all other perils
                    pdffield = myPDFFields.Fields("OtherPeril")
                    DirectCast(pdffield, TallComponents.PDF.Forms.Fields.TextField).Value = "$" & ds4.Tables(0).Rows(0).Item("RentAOP").ToString().Replace("$", "")

                    pdffield = myPDFFields.Fields("WindHail")
                    DirectCast(pdffield, TallComponents.PDF.Forms.Fields.TextField).Value = "$" & ds4.Tables(0).Rows(0).Item("RentWind").ToString().Replace("$", "")
                    pdffield = myPDFFields.Fields("Hurricane")
                    DirectCast(pdffield, TallComponents.PDF.Forms.Fields.TextField).Value = "$" & ds4.Tables(0).Rows(0).Item("RentWind").ToString().Replace("$", "")


                    If IsNumeric(ds4.Tables(0).Rows(0).Item("RentCreditamt").ToString().Replace("$", "")) Then


                        If ds4.Tables(0).Rows(0).Item("RentCreditamt").ToString().Replace("$", "") > "0" Or ds4.Tables(0).Rows(0).Item("RentAOPPrem").ToString().Replace("$", "").Replace("(", "").Replace(")", "") > "0" Then

                            pdffield = myPDFFields.Fields("MHCreditDesc")
                            DirectCast(pdffield, TallComponents.PDF.Forms.Fields.TextField).Value = "Credit(s)"
                            If ds4.Tables(0).Rows(0).Item("RentAOPPrem").ToString().Replace("$", "").Replace("(", "").Replace(")", "") > "0" Then
                                pdffield = myPDFFields.Fields("MHCredits")
                                DirectCast(pdffield, TallComponents.PDF.Forms.Fields.TextField).Value = "($-" & CInt(ds4.Tables(0).Rows(0).Item("RentAOPPrem").ToString().Replace("$", "").Replace("(", "").Replace(")", "")) + ds4.Tables(0).Rows(0).Item("RentCreditamt").ToString().Replace("$", "") & ")"

                            Else
                                pdffield = myPDFFields.Fields("MHCredits")
                                DirectCast(pdffield, TallComponents.PDF.Forms.Fields.TextField).Value = "($-" & ds4.Tables(0).Rows(0).Item("RentCreditamt").ToString().Replace("$", "") & ")"


                            End If

                        End If
                    End If
                Case "Vacant"
                Case "SMH Package"
                    pdffield = myPDFFields.Fields("MHLimit")
                    DirectCast(pdffield, TallComponents.PDF.Forms.Fields.TextField).Value = "$" & ds4.Tables(0).Rows(0).Item("SMHPackDwel").ToString().Replace("$", "").Replace(",", "")
                    pdffield = myPDFFields.Fields("MHPremium")
                    DirectCast(pdffield, TallComponents.PDF.Forms.Fields.TextField).Value = "$" & ds4.Tables(0).Rows(0).Item("SMHPackprem").ToString().Replace("$", "").Replace(",", "")
                    pdffield = myPDFFields.Fields("MHAddStructLimit")
                    DirectCast(pdffield, TallComponents.PDF.Forms.Fields.TextField).Value = "$" & ds4.Tables(0).Rows(0).Item("SMHPackStruc").ToString().Replace("$", "").Replace(",", "")
                    pdffield = myPDFFields.Fields("MHAddSTructPremium")
                    DirectCast(pdffield, TallComponents.PDF.Forms.Fields.TextField).Value = "$" & ds4.Tables(0).Rows(0).Item("SMHPackStrucPrem").ToString().Replace("$", "").Replace(",", "")
                    pdffield = myPDFFields.Fields("MHPersonalLimit")
                    DirectCast(pdffield, TallComponents.PDF.Forms.Fields.TextField).Value = "$" & ds4.Tables(0).Rows(0).Item("SMHPackCont").ToString().Replace("$", "").Replace(",", "")
                    pdffield = myPDFFields.Fields("MHPersonalPrem")
                    DirectCast(pdffield, TallComponents.PDF.Forms.Fields.TextField).Value = "$" & ds4.Tables(0).Rows(0).Item("SMHPackContPrem").ToString().Replace("$", "").Replace(",", "")
                    pdffield = myPDFFields.Fields("MHLiabilityLimit")
                    DirectCast(pdffield, TallComponents.PDF.Forms.Fields.TextField).Value = "$" & ds4.Tables(0).Rows(0).Item("SMHPackLiab").ToString().Replace("$", "").Replace(",", "")

                    pdffield = myPDFFields.Fields("MMDDYYYY Format")
                    DirectCast(pdffield, TallComponents.PDF.Forms.Fields.TextField).Value = "$" & ds4.Tables(0).Rows(0).Item("SMHPackLiab").ToString().Replace("$", "").Replace(",", "")

                    pdffield = myPDFFields.Fields("MHLiabilityPrem")
                    DirectCast(pdffield, TallComponents.PDF.Forms.Fields.TextField).Value = "$" & ds4.Tables(0).Rows(0).Item("SMHPackPersLiabPrem").ToString().Replace("$", "").Replace(",", "")
                    pdffield = myPDFFields.Fields("MHMedLimit")
                    DirectCast(pdffield, TallComponents.PDF.Forms.Fields.TextField).Value = "$" & ds4.Tables(0).Rows(0).Item("SMHPackMedPay").ToString().Replace("$", "").Replace(",", "")
                    If ds4.Tables(0).Rows(0).Item("SMHPackMedPrem").ToString().Replace("$", "") > "0.00" Then
                        pdffield = myPDFFields.Fields("MHMedPrem")
                        DirectCast(pdffield, TallComponents.PDF.Forms.Fields.TextField).Value = "$" & ds4.Tables(0).Rows(0).Item("SMHPackMedPrem").ToString().Replace("$", "")

                    End If
                    pdffield = myPDFFields.Fields("TotalPrem")
                    DirectCast(pdffield, TallComponents.PDF.Forms.Fields.TextField).Value = "$" & ds4.Tables(0).Rows(0).Item("SMHPacktotal").ToString().Replace("$", "").Replace(",", "")

                    If ds4.Tables(0).Rows(0).Item("SMHPackContReplace").ToString().Replace("$", "") > "No" Then
                        pdffield = myPDFFields.Fields("Optional1")
                        DirectCast(pdffield, TallComponents.PDF.Forms.Fields.TextField).Value = "Content Replacement"
                        pdffield = myPDFFields.Fields("Opt1prem")
                        DirectCast(pdffield, TallComponents.PDF.Forms.Fields.TextField).Value = "$" & ds4.Tables(0).Rows(0).Item("SMHPackContReplacePrem").ToString().Replace("$", "")

                    End If
                    If ds4.Tables(0).Rows(0).Item("SMHPackMHReplace").ToString().Replace("$", "") > "No" Then
                        pdffield = myPDFFields.Fields("Optional2")
                        DirectCast(pdffield, TallComponents.PDF.Forms.Fields.TextField).Value = "Mobile Home Replacement"
                        pdffield = myPDFFields.Fields("Opt2prem")
                        DirectCast(pdffield, TallComponents.PDF.Forms.Fields.TextField).Value = "$" & ds4.Tables(0).Rows(0).Item("SMHPackMHReplacePrem").ToString().Replace("$", "")

                    End If
                    If IsNumeric(ds4.Tables(0).Rows(0).Item("SMHPackFullRepair").ToString().Replace("$", "")) Then
                        pdffield = myPDFFields.Fields("Optional3")
                        DirectCast(pdffield, TallComponents.PDF.Forms.Fields.TextField).Value = "Enhancement Coverage:    $" & ds4.Tables(0).Rows(0).Item("SMHPackFullRepair").ToString().Replace("$", "")
                        pdffield = myPDFFields.Fields("Opt3prem")
                        DirectCast(pdffield, TallComponents.PDF.Forms.Fields.TextField).Value = "$" & ds4.Tables(0).Rows(0).Item("SMHPackFullRepairPrem").ToString().Replace("$", "")

                    End If

                    If ds4.Tables(0).Rows(0).Item("homeUse").ToString() = "Seasonal" Then

                        pdffield = myPDFFields.Fields("Surcharge")
                        DirectCast(pdffield, TallComponents.PDF.Forms.Fields.TextField).Value = "$20"
                        pdffield = myPDFFields.Fields("Surchargedesc")
                        DirectCast(pdffield, TallComponents.PDF.Forms.Fields.TextField).Value = "Seasonal Fee"
                        pdffield = myPDFFields.Fields("CertFee")
                        DirectCast(pdffield, TallComponents.PDF.Forms.Fields.TextField).Value = "$" & CInt(ds4.Tables(0).Rows(0).Item("SMHPackFees").ToString().Replace("$", "")) - 20

                    Else
                        pdffield = myPDFFields.Fields("CertFee")
                        DirectCast(pdffield, TallComponents.PDF.Forms.Fields.TextField).Value = "$" & ds4.Tables(0).Rows(0).Item("SMHPackFees").ToString().Replace("$", "")
                    End If
                    pdffield = myPDFFields.Fields("StateTax")
                    DirectCast(pdffield, TallComponents.PDF.Forms.Fields.TextField).Value = "$" & ds4.Tables(0).Rows(0).Item("SMHPackTax").ToString().Replace("$", "")


                    'all other perils
                    pdffield = myPDFFields.Fields("OtherPeril")
                    DirectCast(pdffield, TallComponents.PDF.Forms.Fields.TextField).Value = "$" & ds4.Tables(0).Rows(0).Item("SMHPackAOP").ToString().Replace("$", "")

                    pdffield = myPDFFields.Fields("WindHail")
                    DirectCast(pdffield, TallComponents.PDF.Forms.Fields.TextField).Value = "$" & ds4.Tables(0).Rows(0).Item("SMHPackWind").ToString().Replace("$", "")
                    pdffield = myPDFFields.Fields("Hurricane")
                    DirectCast(pdffield, TallComponents.PDF.Forms.Fields.TextField).Value = "$" & ds4.Tables(0).Rows(0).Item("SMHPackWind").ToString().Replace("$", "")


                    If ds4.Tables(0).Rows(0).Item("SMHPackCreditamt").ToString().Replace("$", "") > "0" Or ds4.Tables(0).Rows(0).Item("SMHPackAOPPrem").ToString().Replace("$", "").Replace("(", "").Replace(")", "") > "0" Then

                        pdffield = myPDFFields.Fields("MHCreditDesc")
                        DirectCast(pdffield, TallComponents.PDF.Forms.Fields.TextField).Value = "Credit(s)"
                        If ds4.Tables(0).Rows(0).Item("SMHPackAOPPrem").ToString().Replace("$", "").Replace("(", "").Replace(")", "") > "0" Then
                            pdffield = myPDFFields.Fields("MHCredits")
                            Dim Creditamt As Integer
                            If IsNumeric(CInt(ds4.Tables(0).Rows(0).Item("SMHPackAOPPrem").ToString().Replace("$", "").Replace("(", "").Replace(")", ""))) Or IsNumeric(ds4.Tables(0).Rows(0).Item("SMHPackCreditamt").ToString().Replace("$", "")) Then
                                Creditamt = CInt(ds4.Tables(0).Rows(0).Item("SMHPackAOPPrem").ToString().Replace("$", "").Replace("(", "").Replace(")", "")) + ds4.Tables(0).Rows(0).Item("SMHPackCreditamt").ToString().Replace("$", "")
                            Else
                                Creditamt = 0

                            End If

                            If Creditamt < 0 Then
                                DirectCast(pdffield, TallComponents.PDF.Forms.Fields.TextField).Value = "($" & Creditamt & ")"
                            Else
                                pdffield = myPDFFields.Fields("MHCreditDesc")
                                DirectCast(pdffield, TallComponents.PDF.Forms.Fields.TextField).Value = "Additional Cost(s)"
                                DirectCast(pdffield, TallComponents.PDF.Forms.Fields.TextField).Value = "$" & Creditamt & ""
                            End If
                            '  DirectCast(pdffield, TallComponents.PDF.Forms.Fields.TextField).Value = "($-" & CInt(ds4.Tables(0).Rows(0).Item("SMHPackAOPPrem").ToString().Replace("$", "").Replace("(", "").Replace(")", "")) + ds4.Tables(0).Rows(0).Item("SMHPackCreditamt").ToString().Replace("$", "") & ")"

                        Else
                            pdffield = myPDFFields.Fields("MHCredits")
                            DirectCast(pdffield, TallComponents.PDF.Forms.Fields.TextField).Value = "($-" & ds4.Tables(0).Rows(0).Item("SMHPackCreditamt").ToString().Replace("$", "") & ")"


                        End If

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




        Catch ex As Exception
            Stop
            Response.Write(ex.Message)
        Finally
            mySourcePDF = Nothing
            myOutputPDF = Nothing
            Response.End()
        End Try

    End Sub
    Public Sub PrintApplicationSC(ByVal ds As System.Data.DataSet, ByVal ds4 As System.Data.DataSet, ByVal ds6 As System.Data.DataSet, ByVal ds5 As System.Data.DataSet)


        Dim myFileStream As FileStream
        Dim mySourcePDF As TallComponents.PDF.Document
        Dim myOutputPDF As TallComponents.PDF.Document
        Dim myPDFFields As New TallComponents.PDF.Document
        Dim strPDFFieldName As String = ""
        Dim value As String

        Try
            myOutputPDF = New TallComponents.PDF.Document
            If ds.Tables(0).Rows(0).Item("State").ToString() = "SC" Then
                myFileStream = New FileStream(Me.MapPath("~\ApplicationPages\") & "PDF\LloydAppSC.pdf", FileMode.Open, FileAccess.Read)
            ElseIf ds.Tables(0).Rows(0).Item("State").ToString() = "NC" Then
                myFileStream = New FileStream(Me.MapPath("~\ApplicationPages\") & "PDF\LloydAppNC.pdf", FileMode.Open, FileAccess.Read)
            ElseIf ds.Tables(0).Rows(0).Item("State").ToString() = "GA" Then
                myFileStream = New FileStream(Me.MapPath("~\ApplicationPages\") & "PDF\LloydAppGA.pdf", FileMode.Open, FileAccess.Read)
            ElseIf ds.Tables(0).Rows(0).Item("State").ToString() = "VA" Then
                myFileStream = New FileStream(Me.MapPath("~\ApplicationPages\") & "PDF\LloydAppVA.pdf", FileMode.Open, FileAccess.Read)
            ElseIf ds.Tables(0).Rows(0).Item("State").ToString() = "TN" Then
                myFileStream = New FileStream(Me.MapPath("~\ApplicationPages\") & "PDF\LloydAppTN.pdf", FileMode.Open, FileAccess.Read)
            Else
                myFileStream = New FileStream(Me.MapPath("~\ApplicationPages\") & "PDF\LloydAppSC.pdf", FileMode.Open, FileAccess.Read)

            End If
            'myFileStream = New FileStream(Me.MapPath("~\ApplicationPages\") & "PDF\LloydAppSC.pdf", FileMode.Open, FileAccess.Read)
            'Dim form As New TallComponents.PDF.Document(myFileStream)
            mySourcePDF = New TallComponents.PDF.Document(myFileStream)
            myPDFFields.Pages.AddRange(mySourcePDF.Pages.CloneToArray())
            '  Dim form As New TallComponents.PDF.Document(myFileStream)
            myFileStream.Close()
            mySourcePDF = Nothing


            If ds.Tables(0).Rows(0).Item("PaymentType").ToString() <> "In Full" And ds.Tables(0).Rows(0).Item("State").ToString() <> "TN" And ds.Tables(0).Rows(0).Item("State").ToString() <> "GA" Then


                myFileStream = New FileStream(Me.MapPath("~\ApplicationPages\") & "PDF\ColonialFinanceAgreement.pdf", FileMode.Open, FileAccess.Read)
                'Dim form As New TallComponents.PDF.Document(myFileStream)
                mySourcePDF = New TallComponents.PDF.Document(myFileStream)
                myPDFFields.Pages.AddRange(mySourcePDF.Pages.CloneToArray())
                '  Dim form As New TallComponents.PDF.Document(myFileStream)
                myFileStream.Close()
                mySourcePDF = Nothing
            End If
            Dim pdffield As TallComponents.PDF.Forms.Fields.Field
            If ds.Tables(0).Rows(0).Item("PaymentType").ToString() <> "In Full" Then


                If ds5.Tables(0).Rows.Count > 0 Then


                    If ds6.Tables(0).Rows.Count > 0 Then
                        'Print Financing Page
                        Dim wrk1 As Decimal = CDbl(ds6.Tables(0).Rows(0).Item("MonthlyPayments")) / CDbl(ds6.Tables(0).Rows(0).Item("AmountFinanced"))
                        Dim wrk2 As Decimal = wrk1
                        Dim APR As Decimal = GetAPR(wrk1, wrk2, Length)
                        pdffield = myPDFFields.Fields("ApplicantNameFin")
                        DirectCast(pdffield, TallComponents.PDF.Forms.Fields.TextField).Value = ds6.Tables(0).Rows(0).Item("Name").ToString()
                        pdffield = myPDFFields.Fields("MailingAddressPFGFin")
                        DirectCast(pdffield, TallComponents.PDF.Forms.Fields.TextField).Value = ds6.Tables(0).Rows(0).Item("MailingAddress").ToString()
                        pdffield = myPDFFields.Fields("AgencyNameFin")
                        DirectCast(pdffield, TallComponents.PDF.Forms.Fields.TextField).Value = ds6.Tables(0).Rows(0).Item("agencyName").ToString()
                        pdffield = myPDFFields.Fields("AgencyAddress1Fin")
                        DirectCast(pdffield, TallComponents.PDF.Forms.Fields.TextField).Value = ""
                        pdffield = myPDFFields.Fields("AgencyAddressLocFin")
                        DirectCast(pdffield, TallComponents.PDF.Forms.Fields.TextField).Value = ""
                        pdffield = myPDFFields.Fields("EffectiveDateFin")
                        DirectCast(pdffield, TallComponents.PDF.Forms.Fields.TextField).Value = ds6.Tables(0).Rows(0).Item("EffectiveDate").ToString()
                        pdffield = myPDFFields.Fields("TermFin")
                        DirectCast(pdffield, TallComponents.PDF.Forms.Fields.TextField).Value = ds6.Tables(0).Rows(0).Item("term").ToString()
                        pdffield = myPDFFields.Fields("NEWFin")
                        DirectCast(pdffield, TallComponents.PDF.Forms.Fields.TextField).Value = "NEW"
                        pdffield = myPDFFields.Fields("CarrierPreferredNameFin")
                        DirectCast(pdffield, TallComponents.PDF.Forms.Fields.TextField).Value = "LLOYDS"
                        pdffield = myPDFFields.Fields("ColonialFin")
                        DirectCast(pdffield, TallComponents.PDF.Forms.Fields.TextField).Value = "C/0 THE COLONIAL GROUP"
                        pdffield = myPDFFields.Fields("TotalAmountFinanceFin")
                        DirectCast(pdffield, TallComponents.PDF.Forms.Fields.TextField).Value = FormatCurrency(ds6.Tables(0).Rows(0).Item("PremTotal").ToString())
                        pdffield = myPDFFields.Fields("CashDownPaymentFin")
                        DirectCast(pdffield, TallComponents.PDF.Forms.Fields.TextField).Value = FormatCurrency(ds6.Tables(0).Rows(0).Item("DownPayment").ToString())
                        pdffield = myPDFFields.Fields("AmountFinancedFin")
                        DirectCast(pdffield, TallComponents.PDF.Forms.Fields.TextField).Value = FormatCurrency(ds6.Tables(0).Rows(0).Item("AmountFinanced").ToString())
                        pdffield = myPDFFields.Fields("FinanceChargeFin")
                        DirectCast(pdffield, TallComponents.PDF.Forms.Fields.TextField).Value = FormatCurrency(ds6.Tables(0).Rows(0).Item("FinanceCharge").ToString())
                        pdffield = myPDFFields.Fields("TotalOfPaymentsFin")
                        DirectCast(pdffield, TallComponents.PDF.Forms.Fields.TextField).Value = FormatCurrency(ds6.Tables(0).Rows(0).Item("TotalOfPayments").ToString())
                        pdffield = myPDFFields.Fields("APRFin")
                        DirectCast(pdffield, TallComponents.PDF.Forms.Fields.TextField).Value = CStr(APR) & "%"
                        pdffield = myPDFFields.Fields("BrokerAccountNumberFin")
                        DirectCast(pdffield, TallComponents.PDF.Forms.Fields.TextField).Value = ds6.Tables(0).Rows(0).Item("AgentNumber").ToString()
                        pdffield = myPDFFields.Fields("AgencyStateFin")
                        DirectCast(pdffield, TallComponents.PDF.Forms.Fields.TextField).Value = ds6.Tables(0).Rows(0).Item("mailState").ToString()
                        pdffield = myPDFFields.Fields("NumPaymentsFin")
                        DirectCast(pdffield, TallComponents.PDF.Forms.Fields.TextField).Value = Length
                        pdffield = myPDFFields.Fields("PaymentAmountFin")
                        DirectCast(pdffield, TallComponents.PDF.Forms.Fields.TextField).Value = FormatCurrency(ds6.Tables(0).Rows(0).Item("MonthlyPayments"))
                        Dim duedate As Date
                        duedate = CDate(ds6.Tables(0).Rows(0).Item("EffectiveDate").ToString())
                        duedate = duedate.AddMonths(1)
                        pdffield = myPDFFields.Fields("PaymentDueDateFin")
                        DirectCast(pdffield, TallComponents.PDF.Forms.Fields.TextField).Value = duedate.ToString("MM/dd/yyyy") 'ds6.Tables(0).Rows(0).Item("EffectiveDate")


                    End If
                End If 'End Financing Page
            End If






            pdffield = myPDFFields.Fields("EffectiveDate")
            DirectCast(pdffield, TallComponents.PDF.Forms.Fields.TextField).Value = ds.Tables(0).Rows(0).Item("effDate").ToString()
            pdffield = myPDFFields.Fields("EndEffectiveDate")
            DirectCast(pdffield, TallComponents.PDF.Forms.Fields.TextField).Value = ds.Tables(0).Rows(0).Item("ToMonth").ToString()
            'pdffield = myPDFFields.Fields("SLEffective Date")
            'DirectCast(pdffield, TallComponents.PDF.Forms.Fields.TextField).Value = ds.Tables(0).Rows(0).Item("effDate").ToString()
            'pdffield = myPDFFields.Fields("SLExpiration Date")
            'DirectCast(pdffield, TallComponents.PDF.Forms.Fields.TextField).Value = ds.Tables(0).Rows(0).Item("ToMonth").ToString()
            'pdffield = myPDFFields.Fields("SURPLUS LINES INSURER NAME")
            'DirectCast(pdffield, TallComponents.PDF.Forms.Fields.TextField).Value = " Lloyd’s London"
            'pdffield = myPDFFields.Fields("NAIC")
            'DirectCast(pdffield, TallComponents.PDF.Forms.Fields.TextField).Value = "AA1122000"
            'pdffield = myPDFFields.Fields("SLDESCRIPTION OF COVERAGE")
            'DirectCast(pdffield, TallComponents.PDF.Forms.Fields.TextField).Value = "Mobile Home"
            ''Static fields for surplus
            'pdffield = myPDFFields.Fields("Name  NAIC  of Insurer")
            'DirectCast(pdffield, TallComponents.PDF.Forms.Fields.TextField).Value = "American Modern Home Insurance Co."
            'pdffield = myPDFFields.Fields("Among the licensed insurers declining to insure this risk or declining to increase the amount of insurance on this risk")
            'DirectCast(pdffield, TallComponents.PDF.Forms.Fields.TextField).Value = " #23469"
            'pdffield = myPDFFields.Fields("Name  Telephone  of Contact")
            'DirectCast(pdffield, TallComponents.PDF.Forms.Fields.TextField).Value = "Todd Hiott"
            'pdffield = myPDFFields.Fields("undefined")
            'DirectCast(pdffield, TallComponents.PDF.Forms.Fields.TextField).Value = "800.543.2644"
            'pdffield = myPDFFields.Fields("Reason for Declining")
            'DirectCast(pdffield, TallComponents.PDF.Forms.Fields.TextField).Value = "Company no longer accepting new business"

            'pdffield = myPDFFields.Fields("Name  NAIC  of Insurer_2")
            'DirectCast(pdffield, TallComponents.PDF.Forms.Fields.TextField).Value = " American Reliable Home Insurance Co.  "
            'pdffield = myPDFFields.Fields("undefined_2")
            'DirectCast(pdffield, TallComponents.PDF.Forms.Fields.TextField).Value = "#19615"
            'pdffield = myPDFFields.Fields("Name  Telephone  of Contact_2")
            'DirectCast(pdffield, TallComponents.PDF.Forms.Fields.TextField).Value = "Judy Larson"
            'pdffield = myPDFFields.Fields("undefined_3")
            'DirectCast(pdffield, TallComponents.PDF.Forms.Fields.TextField).Value = "800.535.1333"
            'pdffield = myPDFFields.Fields("Reason for Declining_2")
            'DirectCast(pdffield, TallComponents.PDF.Forms.Fields.TextField).Value = "Company no longer accepting new business"

            'pdffield = myPDFFields.Fields("Name  NAIC  of Insurer_3")
            'DirectCast(pdffield, TallComponents.PDF.Forms.Fields.TextField).Value = " Markel American Insurance Co."
            'pdffield = myPDFFields.Fields("undefined_4")
            'DirectCast(pdffield, TallComponents.PDF.Forms.Fields.TextField).Value = "#28932"
            'pdffield = myPDFFields.Fields("Name  Telephone  of Contact_3")
            'DirectCast(pdffield, TallComponents.PDF.Forms.Fields.TextField).Value = "Laura Foth"
            'pdffield = myPDFFields.Fields("undefined_5")
            'DirectCast(pdffield, TallComponents.PDF.Forms.Fields.TextField).Value = " 262.548.9880"
            'pdffield = myPDFFields.Fields("Reason for Declining_3")
            'DirectCast(pdffield, TallComponents.PDF.Forms.Fields.TextField).Value = "Company no longer accepting new business"

            'pdffield = myPDFFields.Fields("Syndicates")
            'DirectCast(pdffield, TallComponents.PDF.Forms.Fields.TextField).Value = "*Additional Lloyd’s Syndicates: AA1126510, AA1120054, AA1128003 and AA1128121"

            'pdffield = myPDFFields.Fields("SLName")
            'DirectCast(pdffield, TallComponents.PDF.Forms.Fields.TextField).Value = UCase(ds.Tables(0).Rows(0).Item("Name").ToString())
            'pdffield = myPDFFields.Fields("SLAddress 1")
            'DirectCast(pdffield, TallComponents.PDF.Forms.Fields.TextField).Value = UCase(ds.Tables(0).Rows(0).Item("mailAddress").ToString())
            'pdffield = myPDFFields.Fields("SLAddress 2")
            'DirectCast(pdffield, TallComponents.PDF.Forms.Fields.TextField).Value = UCase(ds.Tables(0).Rows(0).Item("AddInsuredCity").ToString() & ",  " & ds.Tables(0).Rows(0).Item("AddInsuredState").ToString() & "  " & ds.Tables(0).Rows(0).Item("mailZip").ToString())
            'pdffield = myPDFFields.Fields("LOCATION OF RISK")
            'DirectCast(pdffield, TallComponents.PDF.Forms.Fields.TextField).Value = UCase(ds.Tables(0).Rows(0).Item("propAddress").ToString() & "  " & ds.Tables(0).Rows(0).Item("City").ToString() & ", " & ds.Tables(0).Rows(0).Item("State").ToString() & "  " & ds.Tables(0).Rows(0).Item("propAppZip").ToString())
           

            pdffield = myPDFFields.Fields("ProducerNumber")
            DirectCast(pdffield, TallComponents.PDF.Forms.Fields.TextField).Value = ds.Tables(0).Rows(0).Item("AgencyCode").ToString()
            'pdffield = myPDFFields.Fields("SLProperty")
            'DirectCast(pdffield, TallComponents.PDF.Forms.Fields.TextField).Value = ds4.Tables(0).Rows(0).Item("PackDwel").ToString()
            If ds.Tables(0).Rows(0).Item("Lien1Num").ToString() <> "" Or ds.Tables(0).Rows(0).Item("Lien1Name").ToString() <> "" Then
                pdffield = myPDFFields.Fields("Lien1Number")
                DirectCast(pdffield, TallComponents.PDF.Forms.Fields.TextField).Value = "Loan #  " & ds.Tables(0).Rows(0).Item("Lien1Num").ToString()
                'Lien
                pdffield = myPDFFields.Fields("Lien1Name")
                DirectCast(pdffield, TallComponents.PDF.Forms.Fields.TextField).Value = UCase(ds.Tables(0).Rows(0).Item("Lien1Name").ToString())
                'pdffield = myPDFFields.Fields("Lien1Account")
                'DirectCast(pdffield, TallComponents.PDF.Forms.Fields.TextField).Value = UCase(ds.Tables(0).Rows(0).Item("Lien1Num").ToString())
                pdffield = myPDFFields.Fields("Lien1Address")
                DirectCast(pdffield, TallComponents.PDF.Forms.Fields.TextField).Value = UCase(ds.Tables(0).Rows(0).Item("Lien1Addr").ToString() & vbCrLf & ds.Tables(0).Rows(0).Item("Lien1City").ToString() & ",  " & ds.Tables(0).Rows(0).Item("Lien1State").ToString() & "  " & ds.Tables(0).Rows(0).Item("Lien1Zip").ToString())

            End If
            If ds.Tables(0).Rows(0).Item("Lien2Num").ToString() <> "" Then
                pdffield = myPDFFields.Fields("Lien2Number")
                DirectCast(pdffield, TallComponents.PDF.Forms.Fields.TextField).Value = "Loan #  " & ds.Tables(0).Rows(0).Item("Lien2Num").ToString()
                pdffield = myPDFFields.Fields("Lien2Name")
                DirectCast(pdffield, TallComponents.PDF.Forms.Fields.TextField).Value = ds.Tables(0).Rows(0).Item("Lien2Name").ToString()
                'pdffield = myPDFFields.Fields("Lien2Account")
                'DirectCast(pdffield, TallComponents.PDF.Forms.Fields.TextField).Value = ds.Tables(0).Rows(0).Item("Lien2Num").ToString()
                pdffield = myPDFFields.Fields("Lien3Address")
                DirectCast(pdffield, TallComponents.PDF.Forms.Fields.TextField).Value = ds.Tables(0).Rows(0).Item("Lien2Addr").ToString() & vbCrLf & ds.Tables(0).Rows(0).Item("Lien2City").ToString() & ",  " & ds.Tables(0).Rows(0).Item("Lien2State").ToString() & "  " & ds.Tables(0).Rows(0).Item("Lien2Zip").ToString()

            End If

            pdffield = myPDFFields.Fields("InsuredName")
            DirectCast(pdffield, TallComponents.PDF.Forms.Fields.TextField).Value = UCase(ds.Tables(0).Rows(0).Item("Name").ToString())
            pdffield = myPDFFields.Fields("InsuredAddress")
            DirectCast(pdffield, TallComponents.PDF.Forms.Fields.TextField).Value = UCase(ds.Tables(0).Rows(0).Item("mailAddress").ToString())
            pdffield = myPDFFields.Fields("InsuredAddress2")
            DirectCast(pdffield, TallComponents.PDF.Forms.Fields.TextField).Value = UCase(ds.Tables(0).Rows(0).Item("AddInsuredCity").ToString() & ",  " & ds.Tables(0).Rows(0).Item("AddInsuredState").ToString() & "  " & ds.Tables(0).Rows(0).Item("mailZip").ToString())
            pdffield = myPDFFields.Fields("LOCATION ADDRESS")
            DirectCast(pdffield, TallComponents.PDF.Forms.Fields.TextField).Value = UCase(ds.Tables(0).Rows(0).Item("propAddress").ToString() & "  " & ds.Tables(0).Rows(0).Item("City").ToString() & ",  " & ds.Tables(0).Rows(0).Item("State").ToString() & "  " & ds.Tables(0).Rows(0).Item("propAppZip").ToString())
            pdffield = myPDFFields.Fields("ProducerName")
            DirectCast(pdffield, TallComponents.PDF.Forms.Fields.TextField).Value = ds.Tables(0).Rows(0).Item("AgencyName").ToString()
            If ds.Tables(0).Rows(0).Item("AgentAddr1").ToString() <> "" Then
                pdffield = myPDFFields.Fields("ProducerAddress")
                DirectCast(pdffield, TallComponents.PDF.Forms.Fields.TextField).Value = UCase(ds.Tables(0).Rows(0).Item("AgentAddr1").ToString())

            Else
                pdffield = myPDFFields.Fields("ProducerAddress")
                DirectCast(pdffield, TallComponents.PDF.Forms.Fields.TextField).Value = UCase(ds.Tables(0).Rows(0).Item("AgentAddr2").ToString())

            End If
            pdffield = myPDFFields.Fields("ProducerAddress2")
            DirectCast(pdffield, TallComponents.PDF.Forms.Fields.TextField).Value = UCase(ds.Tables(0).Rows(0).Item("AgentCity").ToString() & ",  " & ds.Tables(0).Rows(0).Item("AgentState").ToString() & "  " & ds.Tables(0).Rows(0).Item("AgentZip").ToString())
            pdffield = myPDFFields.Fields("YEARRow1")
            DirectCast(pdffield, TallComponents.PDF.Forms.Fields.TextField).Value = ds.Tables(0).Rows(0).Item("DescMHYear").ToString()
            pdffield = myPDFFields.Fields("MANUFACTURERRow1")
            DirectCast(pdffield, TallComponents.PDF.Forms.Fields.TextField).Value = ds.Tables(0).Rows(0).Item("DescMHManf").ToString()
            pdffield = myPDFFields.Fields("SERIAL NUMBERRow1")
            DirectCast(pdffield, TallComponents.PDF.Forms.Fields.TextField).Value = ds.Tables(0).Rows(0).Item("DescMHSerial").ToString()
            pdffield = myPDFFields.Fields("LENGTHWIDTHRow1")
            DirectCast(pdffield, TallComponents.PDF.Forms.Fields.TextField).Value = ds.Tables(0).Rows(0).Item("DescMHLength").ToString() & "/" & ds.Tables(0).Rows(0).Item("DescMHWidth").ToString()
            pdffield = myPDFFields.Fields("PURCHASE DATERow1")
            DirectCast(pdffield, TallComponents.PDF.Forms.Fields.TextField).Value = ds.Tables(0).Rows(0).Item("DescMHPurDate").ToString()
            pdffield = myPDFFields.Fields("PURCHASE PRICERow1")
            DirectCast(pdffield, TallComponents.PDF.Forms.Fields.TextField).Value = CInt(ds.Tables(0).Rows(0).Item("DescMHPurPrice").ToString())
            pdffield = myPDFFields.Fields("Occupancy")
            DirectCast(pdffield, TallComponents.PDF.Forms.Fields.TextField).Value = ds4.Tables(0).Rows(0).Item("homeUse").ToString()
            pdffield = myPDFFields.Fields("ProtectionClass")
            DirectCast(pdffield, TallComponents.PDF.Forms.Fields.TextField).Value = ds.Tables(0).Rows(0).Item("protClass").ToString()
            pdffield = myPDFFields.Fields("Territory")
            DirectCast(pdffield, TallComponents.PDF.Forms.Fields.TextField).Value = ds.Tables(0).Rows(0).Item("territory").ToString()
            Dim dist As String
            dist = ds.Tables(0).Rows(0).Item("DistToGulf").ToString()
            If dist = "Greater than 5 miles" Then
                dist = "5+ Miles"
            End If
            pdffield = myPDFFields.Fields("DistToCoast")
            DirectCast(pdffield, TallComponents.PDF.Forms.Fields.TextField).Value = dist 'ds.Tables(0).Rows(0).Item("DistToGulf").ToString()
            pdffield = myPDFFields.Fields("FoundationType")
            DirectCast(pdffield, TallComponents.PDF.Forms.Fields.TextField).Value = ds.Tables(0).Rows(0).Item("skirting").ToString()
            pdffield = myPDFFields.Fields("InPark")
            DirectCast(pdffield, TallComponents.PDF.Forms.Fields.TextField).Value = ds.Tables(0).Rows(0).Item("ParkStatus").ToString()
            'Hurrican for Delaware is standard $1500
            'pdffield = myPDFFields.Fields("Hurricane")
            'DirectCast(pdffield, TallComponents.PDF.Forms.Fields.TextField).Value = "$1500"



            pdffield = myPDFFields.Fields("FirePlace")
            DirectCast(pdffield, TallComponents.PDF.Forms.Fields.TextField).Value = ds.Tables(0).Rows(0).Item("ARIng1").ToString()
            pdffield = myPDFFields.Fields("Bussiness")
            DirectCast(pdffield, TallComponents.PDF.Forms.Fields.TextField).Value = ds.Tables(0).Rows(0).Item("ARIng2").ToString()
            pdffield = myPDFFields.Fields("Farming")
            DirectCast(pdffield, TallComponents.PDF.Forms.Fields.TextField).Value = ds.Tables(0).Rows(0).Item("ARIng3").ToString()
            pdffield = myPDFFields.Fields("Animals")
            DirectCast(pdffield, TallComponents.PDF.Forms.Fields.TextField).Value = ds.Tables(0).Rows(0).Item("ARIng4").ToString()
            pdffield = myPDFFields.Fields("Swimmingpool")
            DirectCast(pdffield, TallComponents.PDF.Forms.Fields.TextField).Value = ds.Tables(0).Rows(0).Item("ARIng5").ToString()
            pdffield = myPDFFields.Fields("Repo")
            DirectCast(pdffield, TallComponents.PDF.Forms.Fields.TextField).Value = ds.Tables(0).Rows(0).Item("ARIng6").ToString()
            pdffield = myPDFFields.Fields("Bankrupt")
            DirectCast(pdffield, TallComponents.PDF.Forms.Fields.TextField).Value = ds.Tables(0).Rows(0).Item("ARIng7").ToString()
            pdffield = myPDFFields.Fields("Claims")
            DirectCast(pdffield, TallComponents.PDF.Forms.Fields.TextField).Value = ds.Tables(0).Rows(0).Item("ARIng8").ToString()
            pdffield = myPDFFields.Fields("Urepaired")
            DirectCast(pdffield, TallComponents.PDF.Forms.Fields.TextField).Value = ds.Tables(0).Rows(0).Item("ARIng9").ToString()
            pdffield = myPDFFields.Fields("Rails")
            DirectCast(pdffield, TallComponents.PDF.Forms.Fields.TextField).Value = ds.Tables(0).Rows(0).Item("ARIng10").ToString()
            pdffield = myPDFFields.Fields("MpastDue")
            DirectCast(pdffield, TallComponents.PDF.Forms.Fields.TextField).Value = ds.Tables(0).Rows(0).Item("ARIng11").ToString()
            pdffield = myPDFFields.Fields("Heater")
            DirectCast(pdffield, TallComponents.PDF.Forms.Fields.TextField).Value = ds.Tables(0).Rows(0).Item("ARIng12").ToString()

            Select Case ds4.Tables(0).Rows(0).Item("ARRateType").ToString()
                Case "Package"
                    pdffield = myPDFFields.Fields("policyText")
                    DirectCast(pdffield, TallComponents.PDF.Forms.Fields.TextField).Value = "Lloyds Package"
                    pdffield = myPDFFields.Fields("MHLimit")
                    DirectCast(pdffield, TallComponents.PDF.Forms.Fields.TextField).Value = "$" & ds4.Tables(0).Rows(0).Item("PackDwel").ToString().Replace("$", "").Replace(",", "")
                    pdffield = myPDFFields.Fields("MHPremium")
                    DirectCast(pdffield, TallComponents.PDF.Forms.Fields.TextField).Value = "$" & ds4.Tables(0).Rows(0).Item("Packprem").ToString().Replace("$", "").Replace(",", "")
                    pdffield = myPDFFields.Fields("MHAddStructLimit")
                    DirectCast(pdffield, TallComponents.PDF.Forms.Fields.TextField).Value = "$" & ds4.Tables(0).Rows(0).Item("PackStruc").ToString().Replace("$", "").Replace(",", "")
                    pdffield = myPDFFields.Fields("MHAddSTructPremium")
                    DirectCast(pdffield, TallComponents.PDF.Forms.Fields.TextField).Value = "$" & ds4.Tables(0).Rows(0).Item("PackStrucPrem").ToString().Replace("$", "").Replace(",", "")
                    pdffield = myPDFFields.Fields("MHPersonalLimit")
                    DirectCast(pdffield, TallComponents.PDF.Forms.Fields.TextField).Value = "$" & ds4.Tables(0).Rows(0).Item("PackCont").ToString().Replace("$", "").Replace(",", "")
                    pdffield = myPDFFields.Fields("MHPersonalPrem")
                    DirectCast(pdffield, TallComponents.PDF.Forms.Fields.TextField).Value = "$" & ds4.Tables(0).Rows(0).Item("PackContPrem").ToString().Replace("$", "").Replace(",", "")
                    pdffield = myPDFFields.Fields("MHLiabilityLimit")
                    DirectCast(pdffield, TallComponents.PDF.Forms.Fields.TextField).Value = "$" & ds4.Tables(0).Rows(0).Item("PackLiab").ToString().Replace("$", "").Replace(",", "")

                    'pdffield = myPDFFields.Fields("MMDDYYYY Format")
                    'DirectCast(pdffield, TallComponents.PDF.Forms.Fields.TextField).Value = "$" & ds4.Tables(0).Rows(0).Item("PackLiab").ToString().Replace("$", "").Replace(",", "")

                    pdffield = myPDFFields.Fields("MHLiabilityPrem")
                    DirectCast(pdffield, TallComponents.PDF.Forms.Fields.TextField).Value = "$" & ds4.Tables(0).Rows(0).Item("PackPersLiabPrem").ToString().Replace("$", "").Replace(",", "")
                    pdffield = myPDFFields.Fields("MHMedLimit")
                    DirectCast(pdffield, TallComponents.PDF.Forms.Fields.TextField).Value = "$" & ds4.Tables(0).Rows(0).Item("PackMedPay").ToString().Replace("$", "").Replace(",", "")
                    If ds4.Tables(0).Rows(0).Item("PackMedPrem").ToString().Replace("$", "") > "0.00" Then
                        pdffield = myPDFFields.Fields("MHMedPrem")
                        DirectCast(pdffield, TallComponents.PDF.Forms.Fields.TextField).Value = "$" & ds4.Tables(0).Rows(0).Item("PackMedPrem").ToString().Replace("$", "")

                    End If
                    pdffield = myPDFFields.Fields("TotalPrem")
                    DirectCast(pdffield, TallComponents.PDF.Forms.Fields.TextField).Value = "$" & ds4.Tables(0).Rows(0).Item("Packtotal").ToString().Replace("$", "").Replace(",", "")

                    If ds4.Tables(0).Rows(0).Item("PackContReplace").ToString().Replace("$", "") > "No" Then
                        pdffield = myPDFFields.Fields("Optional1")
                        DirectCast(pdffield, TallComponents.PDF.Forms.Fields.TextField).Value = "Content Replacement"
                        pdffield = myPDFFields.Fields("Opt1prem")
                        DirectCast(pdffield, TallComponents.PDF.Forms.Fields.TextField).Value = "$" & ds4.Tables(0).Rows(0).Item("PackContReplacePrem").ToString().Replace("$", "")

                    End If
                    If ds4.Tables(0).Rows(0).Item("PackMHReplace").ToString().Replace("$", "") > "No" Then
                        pdffield = myPDFFields.Fields("Optional2")
                        DirectCast(pdffield, TallComponents.PDF.Forms.Fields.TextField).Value = "Mobile Home Replacement"
                        pdffield = myPDFFields.Fields("Opt2prem")
                        DirectCast(pdffield, TallComponents.PDF.Forms.Fields.TextField).Value = "$" & ds4.Tables(0).Rows(0).Item("PackMHReplacePrem").ToString().Replace("$", "")

                    End If
                    If ds4.Tables(0).Rows(0).Item("PackFullRepair").ToString().Replace("$", "") > "No" Then
                        pdffield = myPDFFields.Fields("Optional3")
                        DirectCast(pdffield, TallComponents.PDF.Forms.Fields.TextField).Value = "Full Repair"
                        pdffield = myPDFFields.Fields("Opt3prem")
                        DirectCast(pdffield, TallComponents.PDF.Forms.Fields.TextField).Value = "$" & ds4.Tables(0).Rows(0).Item("PackFullRepairPrem").ToString().Replace("$", "")

                    End If

                    If ds4.Tables(0).Rows(0).Item("homeUse").ToString() = "Seasonal" Then

                        pdffield = myPDFFields.Fields("Surcharge")
                        DirectCast(pdffield, TallComponents.PDF.Forms.Fields.TextField).Value = "$20"
                        pdffield = myPDFFields.Fields("Surchargedesc")
                        DirectCast(pdffield, TallComponents.PDF.Forms.Fields.TextField).Value = "Seasonal Fee"
                        pdffield = myPDFFields.Fields("CertFee")
                        DirectCast(pdffield, TallComponents.PDF.Forms.Fields.TextField).Value = "$" & CInt(ds4.Tables(0).Rows(0).Item("PackFees").ToString().Replace("$", "")) - 20

                    Else
                        pdffield = myPDFFields.Fields("CertFee")
                        DirectCast(pdffield, TallComponents.PDF.Forms.Fields.TextField).Value = "$" & ds4.Tables(0).Rows(0).Item("PackFees").ToString().Replace("$", "")
                    End If
                    pdffield = myPDFFields.Fields("StateTax")
                    DirectCast(pdffield, TallComponents.PDF.Forms.Fields.TextField).Value = "$" & ds4.Tables(0).Rows(0).Item("PackTax").ToString().Replace("$", "")


                    'all other perils
                    pdffield = myPDFFields.Fields("OtherPeril")
                    DirectCast(pdffield, TallComponents.PDF.Forms.Fields.TextField).Value = "$" & ds4.Tables(0).Rows(0).Item("PackAOP").ToString().Replace("$", "")

                    pdffield = myPDFFields.Fields("WindHail")
                    DirectCast(pdffield, TallComponents.PDF.Forms.Fields.TextField).Value = "$" & ds4.Tables(0).Rows(0).Item("PackWind").ToString().Replace("$", "")
                    pdffield = myPDFFields.Fields("Hurricane")
                    DirectCast(pdffield, TallComponents.PDF.Forms.Fields.TextField).Value = "$" & ds4.Tables(0).Rows(0).Item("PackWind").ToString().Replace("$", "")


                    If ds4.Tables(0).Rows(0).Item("PackCreditamt").ToString().Replace("$", "") > "0" Or ds4.Tables(0).Rows(0).Item("PackAOPPrem").ToString().Replace("$", "").Replace("(", "").Replace(")", "") > "0" Then

                        pdffield = myPDFFields.Fields("MHCreditDesc")
                        DirectCast(pdffield, TallComponents.PDF.Forms.Fields.TextField).Value = "Credit(s)"
                        If ds4.Tables(0).Rows(0).Item("PackAOPPrem").ToString().Replace("$", "").Replace("(", "").Replace(")", "") > "0" Then
                            pdffield = myPDFFields.Fields("MHCredits")
                            DirectCast(pdffield, TallComponents.PDF.Forms.Fields.TextField).Value = "($-" & CInt(ds4.Tables(0).Rows(0).Item("PackAOPPrem").ToString().Replace("$", "").Replace("(", "").Replace(")", "")) + ds4.Tables(0).Rows(0).Item("PackCreditamt").ToString().Replace("$", "") & ")"

                        Else
                            pdffield = myPDFFields.Fields("MHCredits")
                            DirectCast(pdffield, TallComponents.PDF.Forms.Fields.TextField).Value = "($-" & ds4.Tables(0).Rows(0).Item("PackCreditamt").ToString().Replace("$", "") & ")"


                        End If

                    End If
                    'loss of use
                    pdffield = myPDFFields.Fields("MHLossofUseLimit")
                    DirectCast(pdffield, TallComponents.PDF.Forms.Fields.TextField).Value = "600"
                Case "Standard"
                    pdffield = myPDFFields.Fields("policyText")
                    DirectCast(pdffield, TallComponents.PDF.Forms.Fields.TextField).Value = "Lloyds Standard"
                    pdffield = myPDFFields.Fields("MHLimit")
                    DirectCast(pdffield, TallComponents.PDF.Forms.Fields.TextField).Value = "$" & ds4.Tables(0).Rows(0).Item("StandDwel").ToString().Replace("$", "").Replace(",", "")
                    pdffield = myPDFFields.Fields("MHPremium")
                    DirectCast(pdffield, TallComponents.PDF.Forms.Fields.TextField).Value = "$" & ds4.Tables(0).Rows(0).Item("Standprem").ToString().Replace("$", "").Replace(",", "")
                    pdffield = myPDFFields.Fields("MHAddStructLimit")
                    DirectCast(pdffield, TallComponents.PDF.Forms.Fields.TextField).Value = "$" & ds4.Tables(0).Rows(0).Item("StandStruc").ToString().Replace("$", "").Replace(",", "")
                    pdffield = myPDFFields.Fields("MHAddSTructPremium")
                    DirectCast(pdffield, TallComponents.PDF.Forms.Fields.TextField).Value = "$" & ds4.Tables(0).Rows(0).Item("StandStrucPrem").ToString().Replace("$", "").Replace(",", "")
                    pdffield = myPDFFields.Fields("MHPersonalLimit")
                    DirectCast(pdffield, TallComponents.PDF.Forms.Fields.TextField).Value = "$" & ds4.Tables(0).Rows(0).Item("StandCont").ToString().Replace("$", "").Replace(",", "")
                    pdffield = myPDFFields.Fields("MHPersonalPrem")
                    DirectCast(pdffield, TallComponents.PDF.Forms.Fields.TextField).Value = "$" & ds4.Tables(0).Rows(0).Item("StandContPrem").ToString().Replace("$", "").Replace(",", "")
                    pdffield = myPDFFields.Fields("MHLiabilityLimit")
                    DirectCast(pdffield, TallComponents.PDF.Forms.Fields.TextField).Value = "$" & ds4.Tables(0).Rows(0).Item("StandLiab").ToString().Replace("$", "").Replace(",", "")

                    'pdffield = myPDFFields.Fields("MMDDYYYY Format")
                    'DirectCast(pdffield, TallComponents.PDF.Forms.Fields.TextField).Value = "$" & ds4.Tables(0).Rows(0).Item("StandLiab").ToString().Replace("$", "").Replace(",", "")

                    pdffield = myPDFFields.Fields("MHLiabilityPrem")
                    DirectCast(pdffield, TallComponents.PDF.Forms.Fields.TextField).Value = "$" & ds4.Tables(0).Rows(0).Item("StandPersLiabPrem").ToString().Replace("$", "").Replace(",", "")
                    pdffield = myPDFFields.Fields("MHMedLimit")
                    DirectCast(pdffield, TallComponents.PDF.Forms.Fields.TextField).Value = "$" & ds4.Tables(0).Rows(0).Item("StandMedPay").ToString().Replace("$", "").Replace(",", "")
                    If ds4.Tables(0).Rows(0).Item("StandMedPrem").ToString().Replace("$", "") > "0.00" Then
                        pdffield = myPDFFields.Fields("MHMedPrem")
                        DirectCast(pdffield, TallComponents.PDF.Forms.Fields.TextField).Value = "$" & ds4.Tables(0).Rows(0).Item("StandMedPrem").ToString().Replace("$", "")

                    End If
                    pdffield = myPDFFields.Fields("TotalPrem")
                    DirectCast(pdffield, TallComponents.PDF.Forms.Fields.TextField).Value = "$" & ds4.Tables(0).Rows(0).Item("Standtotal").ToString().Replace("$", "").Replace(",", "")

                    If ds4.Tables(0).Rows(0).Item("StandContReplace").ToString().Replace("$", "") > "No" Then
                        pdffield = myPDFFields.Fields("Optional1")
                        DirectCast(pdffield, TallComponents.PDF.Forms.Fields.TextField).Value = "Content Replacement"
                        pdffield = myPDFFields.Fields("Opt1prem")
                        DirectCast(pdffield, TallComponents.PDF.Forms.Fields.TextField).Value = "$" & ds4.Tables(0).Rows(0).Item("StandContReplacePrem").ToString().Replace("$", "")

                    End If
                    If ds4.Tables(0).Rows(0).Item("StandMHReplace").ToString().Replace("$", "") > "No" Then
                        pdffield = myPDFFields.Fields("Optional2")
                        DirectCast(pdffield, TallComponents.PDF.Forms.Fields.TextField).Value = "Mobile Home Replacement"
                        pdffield = myPDFFields.Fields("Opt2prem")
                        DirectCast(pdffield, TallComponents.PDF.Forms.Fields.TextField).Value = "$" & ds4.Tables(0).Rows(0).Item("StandMHReplacePrem").ToString().Replace("$", "")

                    End If
                    If ds4.Tables(0).Rows(0).Item("StandFullRepair").ToString().Replace("$", "") > "No" Then
                        pdffield = myPDFFields.Fields("Optional3")
                        DirectCast(pdffield, TallComponents.PDF.Forms.Fields.TextField).Value = "Full Repair"
                        pdffield = myPDFFields.Fields("Opt3prem")
                        DirectCast(pdffield, TallComponents.PDF.Forms.Fields.TextField).Value = "$" & ds4.Tables(0).Rows(0).Item("StandFullRepairPrem").ToString().Replace("$", "")

                    End If

                    If ds4.Tables(0).Rows(0).Item("homeUse").ToString() = "Seasonal" Then

                        pdffield = myPDFFields.Fields("Surcharge")
                        DirectCast(pdffield, TallComponents.PDF.Forms.Fields.TextField).Value = "$20"
                        pdffield = myPDFFields.Fields("Surchargedesc")
                        DirectCast(pdffield, TallComponents.PDF.Forms.Fields.TextField).Value = "Seasonal Fee"
                        pdffield = myPDFFields.Fields("CertFee")
                        DirectCast(pdffield, TallComponents.PDF.Forms.Fields.TextField).Value = "$" & CInt(ds4.Tables(0).Rows(0).Item("StandFees").ToString().Replace("$", "")) - 20

                    Else
                        pdffield = myPDFFields.Fields("CertFee")
                        DirectCast(pdffield, TallComponents.PDF.Forms.Fields.TextField).Value = "$" & ds4.Tables(0).Rows(0).Item("StandFees").ToString().Replace("$", "")
                    End If
                    pdffield = myPDFFields.Fields("StateTax")
                    DirectCast(pdffield, TallComponents.PDF.Forms.Fields.TextField).Value = "$" & ds4.Tables(0).Rows(0).Item("StandTax").ToString().Replace("$", "")


                    'all other perils
                    pdffield = myPDFFields.Fields("OtherPeril")
                    DirectCast(pdffield, TallComponents.PDF.Forms.Fields.TextField).Value = "$" & ds4.Tables(0).Rows(0).Item("StandAOP").ToString().Replace("$", "")

                    pdffield = myPDFFields.Fields("WindHail")
                    DirectCast(pdffield, TallComponents.PDF.Forms.Fields.TextField).Value = "$" & ds4.Tables(0).Rows(0).Item("StandWind").ToString().Replace("$", "")
                    pdffield = myPDFFields.Fields("Hurricane")
                    DirectCast(pdffield, TallComponents.PDF.Forms.Fields.TextField).Value = "$" & ds4.Tables(0).Rows(0).Item("StandWind").ToString().Replace("$", "")


                    If ds4.Tables(0).Rows(0).Item("StandCreditamt").ToString().Replace("$", "") > "0" Or ds4.Tables(0).Rows(0).Item("StandAOPPrem").ToString().Replace("$", "").Replace("(", "").Replace(")", "") > "0" Then

                        pdffield = myPDFFields.Fields("MHCreditDesc")
                        DirectCast(pdffield, TallComponents.PDF.Forms.Fields.TextField).Value = "Credit(s)"
                        If ds4.Tables(0).Rows(0).Item("StandAOPPrem").ToString().Replace("$", "").Replace("(", "").Replace(")", "") > "0" Then
                            pdffield = myPDFFields.Fields("MHCredits")
                            DirectCast(pdffield, TallComponents.PDF.Forms.Fields.TextField).Value = "($-" & CInt(ds4.Tables(0).Rows(0).Item("StandAOPPrem").ToString().Replace("$", "").Replace("(", "").Replace(")", "")) + ds4.Tables(0).Rows(0).Item("StandCreditamt").ToString().Replace("$", "") & ")"

                        Else
                            pdffield = myPDFFields.Fields("MHCredits")
                            DirectCast(pdffield, TallComponents.PDF.Forms.Fields.TextField).Value = "($-" & ds4.Tables(0).Rows(0).Item("StandCreditamt").ToString().Replace("$", "") & ")"


                        End If

                    End If
                    'loss of use
                    pdffield = myPDFFields.Fields("MHLossofUseLimit")
                    DirectCast(pdffield, TallComponents.PDF.Forms.Fields.TextField).Value = "600"
                Case "Rental"
                    pdffield = myPDFFields.Fields("policyText")
                    DirectCast(pdffield, TallComponents.PDF.Forms.Fields.TextField).Value = "Lloyds Rental"
                    pdffield = myPDFFields.Fields("MHLimit")
                    DirectCast(pdffield, TallComponents.PDF.Forms.Fields.TextField).Value = "$" & ds4.Tables(0).Rows(0).Item("RentDwel").ToString().Replace("$", "").Replace(",", "")
                    pdffield = myPDFFields.Fields("MHPremium")
                    DirectCast(pdffield, TallComponents.PDF.Forms.Fields.TextField).Value = "$" & ds4.Tables(0).Rows(0).Item("Rentprem").ToString().Replace("$", "").Replace(",", "")
                    pdffield = myPDFFields.Fields("MHAddStructLimit")
                    DirectCast(pdffield, TallComponents.PDF.Forms.Fields.TextField).Value = "$" & ds4.Tables(0).Rows(0).Item("RentStruc").ToString().Replace("$", "").Replace(",", "")
                    pdffield = myPDFFields.Fields("MHAddSTructPremium")
                    DirectCast(pdffield, TallComponents.PDF.Forms.Fields.TextField).Value = "$" & ds4.Tables(0).Rows(0).Item("RentStrucPrem").ToString().Replace("$", "").Replace(",", "")
                    pdffield = myPDFFields.Fields("MHPersonalLimit")
                    DirectCast(pdffield, TallComponents.PDF.Forms.Fields.TextField).Value = "$" & ds4.Tables(0).Rows(0).Item("RentCont").ToString().Replace("$", "").Replace(",", "")
                    pdffield = myPDFFields.Fields("MHPersonalPrem")
                    DirectCast(pdffield, TallComponents.PDF.Forms.Fields.TextField).Value = "$" & ds4.Tables(0).Rows(0).Item("RentContPrem").ToString().Replace("$", "").Replace(",", "")
                    pdffield = myPDFFields.Fields("MHLiabilityLimit")
                    DirectCast(pdffield, TallComponents.PDF.Forms.Fields.TextField).Value = "$" & ds4.Tables(0).Rows(0).Item("RentLiab").ToString().Replace("$", "").Replace(",", "")

                    'pdffield = myPDFFields.Fields("MMDDYYYY Format")
                    'DirectCast(pdffield, TallComponents.PDF.Forms.Fields.TextField).Value = "$" & ds4.Tables(0).Rows(0).Item("RentLiab").ToString().Replace("$", "").Replace(",", "")

                    pdffield = myPDFFields.Fields("MHLiabilityPrem")
                    DirectCast(pdffield, TallComponents.PDF.Forms.Fields.TextField).Value = "$" & ds4.Tables(0).Rows(0).Item("RentPersLiabPrem").ToString().Replace("$", "").Replace(",", "")
                    pdffield = myPDFFields.Fields("MHMedLimit")
                    DirectCast(pdffield, TallComponents.PDF.Forms.Fields.TextField).Value = "$" & ds4.Tables(0).Rows(0).Item("RentMedPay").ToString().Replace("$", "")
                    If ds4.Tables(0).Rows(0).Item("RentMedPrem").ToString().Replace("$", "") > "0.00" Then
                        pdffield = myPDFFields.Fields("MHMedPrem")
                        DirectCast(pdffield, TallComponents.PDF.Forms.Fields.TextField).Value = "$" & ds4.Tables(0).Rows(0).Item("RentMedPrem").ToString().Replace("$", "")

                    End If
                    pdffield = myPDFFields.Fields("TotalPrem")
                    DirectCast(pdffield, TallComponents.PDF.Forms.Fields.TextField).Value = "$" & ds4.Tables(0).Rows(0).Item("Renttotal").ToString().Replace("$", "").Replace(",", "")

                    If ds4.Tables(0).Rows(0).Item("RentContReplace").ToString().Replace("$", "") > "No" Then
                        pdffield = myPDFFields.Fields("Optional1")
                        DirectCast(pdffield, TallComponents.PDF.Forms.Fields.TextField).Value = "Content Replacement"
                        pdffield = myPDFFields.Fields("Opt1prem")
                        DirectCast(pdffield, TallComponents.PDF.Forms.Fields.TextField).Value = "$" & ds4.Tables(0).Rows(0).Item("RentContReplacePrem").ToString().Replace("$", "")

                    End If
                    If ds4.Tables(0).Rows(0).Item("RentMHReplace").ToString().Replace("$", "") > "No" Then
                        pdffield = myPDFFields.Fields("Optional2")
                        DirectCast(pdffield, TallComponents.PDF.Forms.Fields.TextField).Value = "Mobile Home Replacement"
                        pdffield = myPDFFields.Fields("Opt2prem")
                        DirectCast(pdffield, TallComponents.PDF.Forms.Fields.TextField).Value = "$" & ds4.Tables(0).Rows(0).Item("RentMHReplacePrem").ToString().Replace("$", "")

                    End If
                    If ds4.Tables(0).Rows(0).Item("RentFullRepair").ToString().Replace("$", "") > "No" Then
                        pdffield = myPDFFields.Fields("Optional3")
                        DirectCast(pdffield, TallComponents.PDF.Forms.Fields.TextField).Value = "Full Repair"
                        pdffield = myPDFFields.Fields("Opt3prem")
                        DirectCast(pdffield, TallComponents.PDF.Forms.Fields.TextField).Value = "$" & ds4.Tables(0).Rows(0).Item("RentFullRepairPrem").ToString().Replace("$", "")

                    End If

                    If ds4.Tables(0).Rows(0).Item("homeUse").ToString() = "Seasonal" Then

                        pdffield = myPDFFields.Fields("Surcharge")
                        DirectCast(pdffield, TallComponents.PDF.Forms.Fields.TextField).Value = "$20"
                        pdffield = myPDFFields.Fields("Surchargedesc")
                        DirectCast(pdffield, TallComponents.PDF.Forms.Fields.TextField).Value = "Seasonal Fee"
                        pdffield = myPDFFields.Fields("CertFee")
                        DirectCast(pdffield, TallComponents.PDF.Forms.Fields.TextField).Value = "$" & CInt(ds4.Tables(0).Rows(0).Item("RentFees").ToString().Replace("$", "")) - 20

                    Else
                        pdffield = myPDFFields.Fields("CertFee")
                        DirectCast(pdffield, TallComponents.PDF.Forms.Fields.TextField).Value = "$" & ds4.Tables(0).Rows(0).Item("RentFees").ToString().Replace("$", "")
                    End If
                    pdffield = myPDFFields.Fields("StateTax")
                    DirectCast(pdffield, TallComponents.PDF.Forms.Fields.TextField).Value = "$" & ds4.Tables(0).Rows(0).Item("RentTax").ToString().Replace("$", "")


                    'all other perils
                    pdffield = myPDFFields.Fields("OtherPeril")
                    DirectCast(pdffield, TallComponents.PDF.Forms.Fields.TextField).Value = "$" & ds4.Tables(0).Rows(0).Item("RentAOP").ToString().Replace("$", "")

                    pdffield = myPDFFields.Fields("WindHail")
                    DirectCast(pdffield, TallComponents.PDF.Forms.Fields.TextField).Value = "$" & ds4.Tables(0).Rows(0).Item("RentWind").ToString().Replace("$", "")
                    pdffield = myPDFFields.Fields("Hurricane")
                    DirectCast(pdffield, TallComponents.PDF.Forms.Fields.TextField).Value = "$" & ds4.Tables(0).Rows(0).Item("RentWind").ToString().Replace("$", "")


                    Dim rentcredit As Integer
                    If ds4.Tables(0).Rows(0).Item("RentCreditamt").ToString().Replace("$", "") > "0" Or ds4.Tables(0).Rows(0).Item("RentAOPPrem").ToString().Replace("$", "").Replace("(", "").Replace(")", "") > "0" Then

                        pdffield = myPDFFields.Fields("MHCreditDesc")
                        DirectCast(pdffield, TallComponents.PDF.Forms.Fields.TextField).Value = "Credit(s)"
                        If ds4.Tables(0).Rows(0).Item("RentAOPPrem").ToString().Replace("$", "").Replace("(", "").Replace(")", "") > "0" Then
                            If ds4.Tables(0).Rows(0).Item("RentCreditamt").ToString().Replace("$", "") = "" Then
                                rentcredit = 0
                            Else
                                rentcredit = ds4.Tables(0).Rows(0).Item("RentCreditamt").ToString().Replace("$", "")
                            End If
                            pdffield = myPDFFields.Fields("MHCredits")
                            DirectCast(pdffield, TallComponents.PDF.Forms.Fields.TextField).Value = "($-" & CInt(ds4.Tables(0).Rows(0).Item("RentAOPPrem").ToString().Replace("$", "").Replace("(", "").Replace(")", "")) + rentcredit & ")"

                        Else
                            If ds4.Tables(0).Rows(0).Item("RentCreditamt").ToString().Replace("$", "") = "" Then
                                rentcredit = 0
                            Else
                                rentcredit = ds4.Tables(0).Rows(0).Item("RentCreditamt").ToString().Replace("$", "")
                            End If
                            pdffield = myPDFFields.Fields("MHCredits")
                            DirectCast(pdffield, TallComponents.PDF.Forms.Fields.TextField).Value = "($-" & rentcredit & ")"


                        End If

                    End If
                Case "Vacant"
                Case "SMH Package"
                    'loss of use
                    pdffield = myPDFFields.Fields("MHLossofUseLimit")
                    DirectCast(pdffield, TallComponents.PDF.Forms.Fields.TextField).Value = "600"

                    pdffield = myPDFFields.Fields("policyText")
                    DirectCast(pdffield, TallComponents.PDF.Forms.Fields.TextField).Value = "Lloyds SMH Package – HO8"
                    pdffield = myPDFFields.Fields("MHLimit")
                    DirectCast(pdffield, TallComponents.PDF.Forms.Fields.TextField).Value = "$" & ds4.Tables(0).Rows(0).Item("SMHPackDwel").ToString().Replace("$", "").Replace(",", "")
                    pdffield = myPDFFields.Fields("MHPremium")
                    DirectCast(pdffield, TallComponents.PDF.Forms.Fields.TextField).Value = "$" & ds4.Tables(0).Rows(0).Item("SMHPackprem").ToString().Replace("$", "").Replace(",", "")
                    pdffield = myPDFFields.Fields("MHAddStructLimit")
                    DirectCast(pdffield, TallComponents.PDF.Forms.Fields.TextField).Value = "$" & ds4.Tables(0).Rows(0).Item("SMHPackStruc").ToString().Replace("$", "").Replace(",", "")
                    pdffield = myPDFFields.Fields("MHAddSTructPremium")
                    DirectCast(pdffield, TallComponents.PDF.Forms.Fields.TextField).Value = "$" & ds4.Tables(0).Rows(0).Item("SMHPackStrucPrem").ToString().Replace("$", "").Replace(",", "")
                    pdffield = myPDFFields.Fields("MHPersonalLimit")
                    DirectCast(pdffield, TallComponents.PDF.Forms.Fields.TextField).Value = "$" & ds4.Tables(0).Rows(0).Item("SMHPackCont").ToString().Replace("$", "").Replace(",", "")
                    pdffield = myPDFFields.Fields("MHPersonalPrem")
                    DirectCast(pdffield, TallComponents.PDF.Forms.Fields.TextField).Value = "$" & ds4.Tables(0).Rows(0).Item("SMHPackContPrem").ToString().Replace("$", "").Replace(",", "")
                    pdffield = myPDFFields.Fields("MHLiabilityLimit")
                    DirectCast(pdffield, TallComponents.PDF.Forms.Fields.TextField).Value = "$" & ds4.Tables(0).Rows(0).Item("SMHPackLiab").ToString().Replace("$", "").Replace(",", "")


                    pdffield = myPDFFields.Fields("MHLossofUseLimit")
                    DirectCast(pdffield, TallComponents.PDF.Forms.Fields.TextField).Value = "1000"
                    'pdffield = myPDFFields.Fields("MMDDYYYY Format")
                    'DirectCast(pdffield, TallComponents.PDF.Forms.Fields.TextField).Value = "$" & ds4.Tables(0).Rows(0).Item("SMHPackLiab").ToString().Replace("$", "").Replace(",", "")

                    pdffield = myPDFFields.Fields("MHLiabilityPrem")
                    DirectCast(pdffield, TallComponents.PDF.Forms.Fields.TextField).Value = "$" & ds4.Tables(0).Rows(0).Item("SMHPackPersLiabPrem").ToString().Replace("$", "").Replace(",", "")
                    pdffield = myPDFFields.Fields("MHMedLimit")
                    DirectCast(pdffield, TallComponents.PDF.Forms.Fields.TextField).Value = "$" & ds4.Tables(0).Rows(0).Item("SMHPackMedPay").ToString().Replace("$", "").Replace(",", "")
                    If ds4.Tables(0).Rows(0).Item("SMHPackMedPrem").ToString().Replace("$", "") > "0.00" Then
                        pdffield = myPDFFields.Fields("MHMedPrem")
                        DirectCast(pdffield, TallComponents.PDF.Forms.Fields.TextField).Value = "$" & ds4.Tables(0).Rows(0).Item("SMHPackMedPrem").ToString().Replace("$", "")

                    End If
                    pdffield = myPDFFields.Fields("TotalPrem")
                    DirectCast(pdffield, TallComponents.PDF.Forms.Fields.TextField).Value = "$" & ds4.Tables(0).Rows(0).Item("SMHPacktotal").ToString().Replace("$", "").Replace(",", "")

                    If ds4.Tables(0).Rows(0).Item("SMHPackContReplace").ToString().Replace("$", "") > "No" Then
                        pdffield = myPDFFields.Fields("Optional1")
                        DirectCast(pdffield, TallComponents.PDF.Forms.Fields.TextField).Value = "Content Replacement"
                        pdffield = myPDFFields.Fields("Opt1prem")
                        DirectCast(pdffield, TallComponents.PDF.Forms.Fields.TextField).Value = "$" & ds4.Tables(0).Rows(0).Item("SMHPackContReplacePrem").ToString().Replace("$", "")

                    End If
                    If ds4.Tables(0).Rows(0).Item("SMHPackMHReplace").ToString().Replace("$", "") > "No" Then
                        pdffield = myPDFFields.Fields("Optional2")
                        DirectCast(pdffield, TallComponents.PDF.Forms.Fields.TextField).Value = "Mobile Home Replacement"
                        pdffield = myPDFFields.Fields("Opt2prem")
                        DirectCast(pdffield, TallComponents.PDF.Forms.Fields.TextField).Value = "$" & ds4.Tables(0).Rows(0).Item("SMHPackMHReplacePrem").ToString().Replace("$", "")

                    End If
                    If IsNumeric(ds4.Tables(0).Rows(0).Item("SMHPackFullRepair").ToString().Replace("$", "")) Then
                        pdffield = myPDFFields.Fields("Optional3")
                        DirectCast(pdffield, TallComponents.PDF.Forms.Fields.TextField).Value = "Enhancement Coverage:    $" & ds4.Tables(0).Rows(0).Item("SMHPackFullRepair").ToString().Replace("$", "")
                        pdffield = myPDFFields.Fields("Opt3prem")
                        DirectCast(pdffield, TallComponents.PDF.Forms.Fields.TextField).Value = "$" & ds4.Tables(0).Rows(0).Item("SMHPackFullRepairPrem").ToString().Replace("$", "")

                    End If

                    If ds4.Tables(0).Rows(0).Item("homeUse").ToString() = "Seasonal" Then

                        'pdffield = myPDFFields.Fields("Surcharge")
                        'DirectCast(pdffield, TallComponents.PDF.Forms.Fields.TextField).Value = "$20"
                        'pdffield = myPDFFields.Fields("Surchargedesc")
                        'DirectCast(pdffield, TallComponents.PDF.Forms.Fields.TextField).Value = "Seasonal Fee"
                        pdffield = myPDFFields.Fields("CertFee")
                        DirectCast(pdffield, TallComponents.PDF.Forms.Fields.TextField).Value = "$" & CInt(ds4.Tables(0).Rows(0).Item("SMHPackFees").ToString().Replace("$", ""))

                    Else
                        pdffield = myPDFFields.Fields("CertFee")
                        DirectCast(pdffield, TallComponents.PDF.Forms.Fields.TextField).Value = "$" & ds4.Tables(0).Rows(0).Item("SMHPackFees").ToString().Replace("$", "")
                    End If
                    pdffield = myPDFFields.Fields("StateTax")
                    DirectCast(pdffield, TallComponents.PDF.Forms.Fields.TextField).Value = "$" & ds4.Tables(0).Rows(0).Item("SMHPackTax").ToString().Replace("$", "")


                    'all other perils
                    pdffield = myPDFFields.Fields("OtherPeril")
                    DirectCast(pdffield, TallComponents.PDF.Forms.Fields.TextField).Value = "$" & ds4.Tables(0).Rows(0).Item("SMHPackAOP").ToString().Replace("$", "")

                    pdffield = myPDFFields.Fields("WindHail")
                    DirectCast(pdffield, TallComponents.PDF.Forms.Fields.TextField).Value = "$" & ds4.Tables(0).Rows(0).Item("SMHPackWind").ToString().Replace("$", "")
                    pdffield = myPDFFields.Fields("Hurricane")
                    DirectCast(pdffield, TallComponents.PDF.Forms.Fields.TextField).Value = "$" & ds4.Tables(0).Rows(0).Item("SMHPackWind").ToString().Replace("$", "")


                    If ds4.Tables(0).Rows(0).Item("SMHPackCreditamt").ToString().Replace("$", "") > "0" Or ds4.Tables(0).Rows(0).Item("SMHPackAOPPrem").ToString().Replace("$", "").Replace("(", "").Replace(")", "") > "0" Then

                        pdffield = myPDFFields.Fields("MHCreditDesc")
                        DirectCast(pdffield, TallComponents.PDF.Forms.Fields.TextField).Value = "Credit(s)"
                        If ds4.Tables(0).Rows(0).Item("SMHPackAOPPrem").ToString().Replace("$", "").Replace("(", "").Replace(")", "") > "0" Or ds4.Tables(0).Rows(0).Item("SMHPackAOPPrem").ToString().Replace("$", "").Replace("(", "").Replace(")", "") < "0" Then
                            pdffield = myPDFFields.Fields("MHCredits")
                            Dim Creditamt As Integer
                            If IsNumeric(ds4.Tables(0).Rows(0).Item("SMHPackAOPPrem").ToString().Replace("$", "").Replace("(", "").Replace(")", "")) Then

                                If IsNumeric(ds4.Tables(0).Rows(0).Item("SMHPackCreditamt").ToString().Replace("$", "")) Then
                                    If ds4.Tables(0).Rows(0).Item("SMHPackAOPPrem").ToString().Replace("$", "").Substring(1, 1) = "(" Then
                                        Creditamt = CInt(ds4.Tables(0).Rows(0).Item("SMHPackAOPPrem").ToString().Replace("$", "").Replace("(", "").Replace(")", "")) + ds4.Tables(0).Rows(0).Item("SMHPackCreditamt").ToString().Replace("$", "")

                                    Else
                                        Creditamt = CInt(ds4.Tables(0).Rows(0).Item("SMHPackAOPPrem").ToString().Replace("$", "").Replace("(", "").Replace(")", "")) - ds4.Tables(0).Rows(0).Item("SMHPackCreditamt").ToString().Replace("$", "")

                                    End If
                                    ' Creditamt = CInt(ds4.Tables(0).Rows(0).Item("SMHPackAOPPrem").ToString().Replace("$", "").Replace("(", "").Replace(")", "")) + ds4.Tables(0).Rows(0).Item("SMHPackCreditamt").ToString().Replace("$", "")
                                Else
                                    Creditamt = 0

                                End If
                            End If

                            If Creditamt < 0 Then
                                DirectCast(pdffield, TallComponents.PDF.Forms.Fields.TextField).Value = "($" & Creditamt & ")"
                            Else
                                pdffield = myPDFFields.Fields("MHCreditDesc")
                                DirectCast(pdffield, TallComponents.PDF.Forms.Fields.TextField).Value = "Additional Cost(s)"
                                DirectCast(pdffield, TallComponents.PDF.Forms.Fields.TextField).Value = "$" & Creditamt & ""
                            End If
                            '  DirectCast(pdffield, TallComponents.PDF.Forms.Fields.TextField).Value = "($-" & CInt(ds4.Tables(0).Rows(0).Item("SMHPackAOPPrem").ToString().Replace("$", "").Replace("(", "").Replace(")", "")) + ds4.Tables(0).Rows(0).Item("SMHPackCreditamt").ToString().Replace("$", "") & ")"

                        Else
                            pdffield = myPDFFields.Fields("MHCredits")
                            DirectCast(pdffield, TallComponents.PDF.Forms.Fields.TextField).Value = "($-" & ds4.Tables(0).Rows(0).Item("SMHPackCreditamt").ToString().Replace("$", "") & ")"


                        End If

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




        Catch ex As Exception
            Stop
            Response.Write(ex.Message)
        Finally
            mySourcePDF = Nothing
            myOutputPDF = Nothing
            Response.End()
        End Try

    End Sub
    Function GetAPR(ByVal wrk1 As Decimal, ByVal wrk2 As Decimal, ByVal term As Integer) As Decimal
        Dim diff As Decimal = 0.00000002
        Dim APR As Decimal
        Dim wrk3 As Decimal
        Dim wrk4 As Decimal

        While diff > 0.00000001
            wrk3 = wrk1 * (1 - (1 / (1 + wrk2) ^ term))
            wrk4 = wrk3 * 12 * 100
            diff = wrk2 - wrk3
            wrk2 = wrk3
            APR = Math.Round(wrk4, 2)
        End While

        Return APR
    End Function
End Class