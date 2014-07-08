Imports System.Data.SqlClient
Imports System.IO

Imports TallComponents.PDF.JavaScript
Imports TallComponents.PDF.Annotations.Widgets
Imports TallComponents.PDF.Forms.Fields
Public Class ApplicationPrintLloyd
    Inherits System.Web.UI.Page

    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        Dim AppID As String
        Dim quoteid As String

        If Request.QueryString("AppID") <> "" Then
            AppID = Request.QueryString("AppID")
            Dim ds1 As System.Data.DataSet
            Dim ds2 As System.Data.DataSet
            Dim ds3 As System.Data.DataSet
            Dim ds4 As System.Data.DataSet
            ' ds1 = Common.runQueryDS("SELECT * FROM tblQuotes q LEFT JOIN (SELECT DISTINCT AgencyID,AgencyCode,AgencyName,Address1 AS AgentAddr1, Address2 AS AgentAddr2,City AS AgentCity,State AS AgentState,Zip AS AgentZip, Phone AS AgentPhone FROM wrwpaqbx_ColonialWeb.wrwpaqbx_admin.vwAgents WHERE Phone <>'')vwag ON q.agencyName = vwag.AgencyName WHERE QuoteID = '" & quoteID & "'")
            ds1 = Common.runQueryDS("EXEC sp_GetLloydApplicationPrint '" & AppID & "'")
            If ds1.Tables(0).Rows.Count > 0 Then
                quoteid = ds1.Tables(0).Rows(0).Item("quoteID").ToString()
                'ds2 = Common.runQueryDS("EXEC sp_getQuotePrintPrem '" & quoteid & "'")
                'ds3 = Common.runQueryDS("Select * from tblQuoteCalcs where QuoteID = '" & quoteid & "'")
                ds4 = Common.runQueryDS("Select a.*,b.ARRateType,b.homeUse from tblLloydsQuotes as a Left Join tblQuotes as b on b.quoteID = a.quoteid where a.QuoteID = '" & quoteid & "'")
                PrintApplication(ds1, ds4)

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

            myFileStream = New FileStream(Me.MapPath("~\ApplicationPages\") & "PDF\LLOYDSApplication.pdf", FileMode.Open, FileAccess.Read)
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
            pdffield = myPDFFields.Fields("InsuredName")
            DirectCast(pdffield, TallComponents.PDF.Forms.Fields.TextField).Value = ds.Tables(0).Rows(0).Item("Name").ToString()
            pdffield = myPDFFields.Fields("InsuredAddress")
            DirectCast(pdffield, TallComponents.PDF.Forms.Fields.TextField).Value = ds.Tables(0).Rows(0).Item("mailAddress").ToString()
            pdffield = myPDFFields.Fields("InsuredAddress2")
            DirectCast(pdffield, TallComponents.PDF.Forms.Fields.TextField).Value = ds.Tables(0).Rows(0).Item("AddInsuredCity").ToString() & "  " & ds.Tables(0).Rows(0).Item("AddInsuredState").ToString() & ",  " & ds.Tables(0).Rows(0).Item("mailZip").ToString()
            pdffield = myPDFFields.Fields("LOCATION ADDRESS")
            DirectCast(pdffield, TallComponents.PDF.Forms.Fields.TextField).Value = ds.Tables(0).Rows(0).Item("propAddress").ToString() & "  " & ds.Tables(0).Rows(0).Item("City").ToString() & "  " & ds.Tables(0).Rows(0).Item("State").ToString() & ",  " & ds.Tables(0).Rows(0).Item("Zip").ToString()
            pdffield = myPDFFields.Fields("ProducerName")
            DirectCast(pdffield, TallComponents.PDF.Forms.Fields.TextField).Value = ds.Tables(0).Rows(0).Item("AgencyName").ToString()
            pdffield = myPDFFields.Fields("ProducerAddress")
            DirectCast(pdffield, TallComponents.PDF.Forms.Fields.TextField).Value = ds.Tables(0).Rows(0).Item("AgentAddr1").ToString()
            pdffield = myPDFFields.Fields("ProducerAddress2")
            DirectCast(pdffield, TallComponents.PDF.Forms.Fields.TextField).Value = ds.Tables(0).Rows(0).Item("AgentCity").ToString() & "  " & ds.Tables(0).Rows(0).Item("AgentState").ToString() & ",  " & ds.Tables(0).Rows(0).Item("AgentZip").ToString()
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
            pdffield = myPDFFields.Fields("DistToCoast")
            DirectCast(pdffield, TallComponents.PDF.Forms.Fields.TextField).Value = ds.Tables(0).Rows(0).Item("DistToGulf").ToString()
            pdffield = myPDFFields.Fields("FoundationType")
            DirectCast(pdffield, TallComponents.PDF.Forms.Fields.TextField).Value = ds.Tables(0).Rows(0).Item("skirting").ToString()
            pdffield = myPDFFields.Fields("InPark")
            DirectCast(pdffield, TallComponents.PDF.Forms.Fields.TextField).Value = ds.Tables(0).Rows(0).Item("ParkStatus").ToString()

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

                Case "Standard"
                    pdffield = myPDFFields.Fields("MHLimit")
                    DirectCast(pdffield, TallComponents.PDF.Forms.Fields.TextField).Value = "$" & ds4.Tables(0).Rows(0).Item("StandDwel").ToString().Replace("$", "")
                    pdffield = myPDFFields.Fields("MHPremium")
                    DirectCast(pdffield, TallComponents.PDF.Forms.Fields.TextField).Value = "$" & ds4.Tables(0).Rows(0).Item("Standprem").ToString().Replace("$", "")
                    pdffield = myPDFFields.Fields("MHAddStructLimit")
                    DirectCast(pdffield, TallComponents.PDF.Forms.Fields.TextField).Value = "$" & ds4.Tables(0).Rows(0).Item("StandStruc").ToString().Replace("$", "")
                    pdffield = myPDFFields.Fields("MHAddSTructPremium")
                    DirectCast(pdffield, TallComponents.PDF.Forms.Fields.TextField).Value = "$" & ds4.Tables(0).Rows(0).Item("StandStrucPrem").ToString().Replace("$", "")
                    pdffield = myPDFFields.Fields("MHPersonalLimit")
                    DirectCast(pdffield, TallComponents.PDF.Forms.Fields.TextField).Value = "$" & ds4.Tables(0).Rows(0).Item("StandCont").ToString().Replace("$", "")
                    pdffield = myPDFFields.Fields("MHPersonalPrem")
                    DirectCast(pdffield, TallComponents.PDF.Forms.Fields.TextField).Value = "$" & ds4.Tables(0).Rows(0).Item("StandContPrem").ToString().Replace("$", "")
                    pdffield = myPDFFields.Fields("MHLiabilityLimit")
                    DirectCast(pdffield, TallComponents.PDF.Forms.Fields.TextField).Value = "$" & ds4.Tables(0).Rows(0).Item("StandLiab").ToString().Replace("$", "")
                    pdffield = myPDFFields.Fields("MHLiabilityPrem")
                    DirectCast(pdffield, TallComponents.PDF.Forms.Fields.TextField).Value = "$" & ds4.Tables(0).Rows(0).Item("StandPersLiabPrem").ToString().Replace("$", "")
                    pdffield = myPDFFields.Fields("MHMedLimit")
                    DirectCast(pdffield, TallComponents.PDF.Forms.Fields.TextField).Value = "$" & ds4.Tables(0).Rows(0).Item("StandMedPay").ToString().Replace("$", "")
                    If ds4.Tables(0).Rows(0).Item("StandMedPrem").ToString().Replace("$", "") > "0.00" Then
                        pdffield = myPDFFields.Fields("MHMedPrem")
                        DirectCast(pdffield, TallComponents.PDF.Forms.Fields.TextField).Value = "$" & ds4.Tables(0).Rows(0).Item("StandMedPrem").ToString().Replace("$", "")

                    End If
                    pdffield = myPDFFields.Fields("TotalPrem")
                    DirectCast(pdffield, TallComponents.PDF.Forms.Fields.TextField).Value = "$" & ds4.Tables(0).Rows(0).Item("Standtotal").ToString().Replace("$", "")

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

                    'Lien
                    pdffield = myPDFFields.Fields("Lien1Name")
                    DirectCast(pdffield, TallComponents.PDF.Forms.Fields.TextField).Value = ds.Tables(0).Rows(0).Item("Lien1Name").ToString()
                    pdffield = myPDFFields.Fields("Lien1Account")
                    DirectCast(pdffield, TallComponents.PDF.Forms.Fields.TextField).Value = ds.Tables(0).Rows(0).Item("Lien1Num").ToString()
                    pdffield = myPDFFields.Fields("Lien1Address")
                    DirectCast(pdffield, TallComponents.PDF.Forms.Fields.TextField).Value = ds.Tables(0).Rows(0).Item("Lien1Addr").ToString() & "  " & ds.Tables(0).Rows(0).Item("Lien1City").ToString() & "  " & ds.Tables(0).Rows(0).Item("Lien1State").ToString() & ",  " & ds.Tables(0).Rows(0).Item("Lien1Zip").ToString()
                  
                    pdffield = myPDFFields.Fields("Lien2Name")
                    DirectCast(pdffield, TallComponents.PDF.Forms.Fields.TextField).Value = ds.Tables(0).Rows(0).Item("Lien2Name").ToString()
                    pdffield = myPDFFields.Fields("Lien2Account")
                    DirectCast(pdffield, TallComponents.PDF.Forms.Fields.TextField).Value = ds.Tables(0).Rows(0).Item("Lien2Num").ToString()
                    pdffield = myPDFFields.Fields("Lien3Address")
                    DirectCast(pdffield, TallComponents.PDF.Forms.Fields.TextField).Value = ds.Tables(0).Rows(0).Item("Lien2Addr").ToString() & "  " & ds.Tables(0).Rows(0).Item("Lien2City").ToString() & "  " & ds.Tables(0).Rows(0).Item("Lien2State").ToString() & ",  " & ds.Tables(0).Rows(0).Item("Lien2Zip").ToString()


                Case "Rental"

                Case "Vacant"

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
End Class