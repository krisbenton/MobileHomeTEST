Imports System.Data.SqlClient
Imports System.IO

Imports TallComponents.PDF.JavaScript
Imports TallComponents.PDF.Annotations.Widgets
Imports TallComponents.PDF.Forms.Fields
Public Class WMJApplicationPrint
    Inherits System.Web.UI.Page

    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        Dim AppID As String
        Dim quoteid As String
        If Request.QueryString("AppID") <> "" Then
            AppID = Request.QueryString("AppID")
            Dim ds1 As System.Data.DataSet
            Dim ds2 As System.Data.DataSet
            Dim ds3 As System.Data.DataSet

            ds1 = Common.runQueryDS("SELECT * FROM tblWMJApplication WHERE ApplicationID = '" & AppID & "'")
            If ds1.Tables(0).Rows.Count > 0 Then
                quoteid = ds1.Tables(0).Rows(0).Item("quoteID").ToString()
                ds2 = Common.runQueryDS("select * from dbo.tblWMJQuotes as a inner join dbo.tblQuotes as b on b.QuoteID = a.Quoteid where a.quoteid ='" & quoteid & "'")
                ds3 = Common.runQueryDS("SELECT * FROM tblQuotes q LEFT JOIN (SELECT DISTINCT AgencyID,AgencyCode,AgencyName,Address1 AS AgentAddr1, Address2 AS AgentAddr2,City AS AgentCity,State AS AgentState,Zip AS AgentZip, Phone AS AgentPhone,Fax,agentname FROM wrwpaqbx_ColonialWeb.wrwpaqbx_admin.vwAgents)vwag ON q.agencyName = vwag.AgencyName and q.agentname = vwag.agentname WHERE QuoteID = '" & quoteid & "'")
                PrintApplication(ds1, ds2, ds3)
            End If


        End If
    End Sub
    Public Sub PrintApplication(ByVal ds As System.Data.DataSet, ByVal ds2 As System.Data.DataSet, ByVal ds3 As System.Data.DataSet)

        Dim myFileStream As FileStream
        Dim mySourcePDF As TallComponents.PDF.Document
        Dim myOutputPDF As TallComponents.PDF.Document
        Dim myPDFFields As New TallComponents.PDF.Document
        Dim strPDFFieldName As String = ""
        Dim value As String
        Try
            myOutputPDF = New TallComponents.PDF.Document

            myFileStream = New FileStream(Me.MapPath("~\ApplicationPages\") & "PDF\WMJApplication.pdf", FileMode.Open, FileAccess.Read)
            'Dim form As New TallComponents.PDF.Document(myFileStream)
            mySourcePDF = New TallComponents.PDF.Document(myFileStream)
            myPDFFields.Pages.AddRange(mySourcePDF.Pages.CloneToArray())
            '  Dim form As New TallComponents.PDF.Document(myFileStream)

            myFileStream.Close()
            mySourcePDF = Nothing
            'add per vickie 3/12/2013
            If ds.Tables(0).Rows(0).Item("State").ToString() = "NC" Then


                myFileStream = New FileStream(Me.MapPath("~\ApplicationPages\") & "PDF\Wmpaddon.pdf", FileMode.Open, FileAccess.Read)
                'Dim form As New TallComponents.PDF.Document(myFileStream)
                mySourcePDF = New TallComponents.PDF.Document(myFileStream)
                myPDFFields.Pages.AddRange(mySourcePDF.Pages.CloneToArray())
                '  Dim form As New TallComponents.PDF.Document(myFileStream)
                myFileStream.Close()
                mySourcePDF = Nothing
            End If
            ''''testing get fields''''''
            'Dim fields As String = ""
            'For Each myPDFField As TallComponents.PDF.Forms.Fields.Field In myPDFFields.Fields
            '    strPDFFieldName = myPDFField.FullName
            '    fields += strPDFFieldName & "~"
            'Next
            'If fields.Length > 0 Then
            '    fields += "******"

            'End If
            '''end testing
            ''' 











            'Dim Policytext As New TallComponents.PDF.Forms.Fields.TextField("Policy")
            ''TryCast(form.Fields("Policy"), TextField).Value = "Testing"
            'Dim pdffield As TallComponents.PDF.Forms.Fields.Field
            Dim efdate As Date = ds3.Tables(0).Rows(0).Item("effDate").ToString()
            Dim enddat As Date = efdate.AddYears(1)

            Dim pdffield As TallComponents.PDF.Forms.Fields.Field

            'pdffield = myPDFFields.Fields("POLICY PERIOD")
            'DirectCast(pdffield, TallComponents.PDF.Forms.Fields.TextField).Value = efdate

            'pdffield = myPDFFields.Fields("TO")
            'DirectCast(pdffield, TallComponents.PDF.Forms.Fields.TextField).Value = enddat
            '========================================================

            pdffield = myPDFFields.Fields("POLICY PERIOD")
            DirectCast(pdffield, TallComponents.PDF.Forms.Fields.TextField).Value = efdate
            pdffield = myPDFFields.Fields("TO")
            DirectCast(pdffield, TallComponents.PDF.Forms.Fields.TextField).Value = enddat
            pdffield = myPDFFields.Fields("NAMED INSURED  MAILING ADDRESS")
            Dim insured As String
            insured = UCase(ds.Tables(0).Rows(0).Item("Name").ToString())
            If UCase(ds.Tables(0).Rows(0).Item("COName").ToString()) <> "" Then

                insured = insured & " / " & UCase(ds.Tables(0).Rows(0).Item("COName").ToString())

            End If
            DirectCast(pdffield, TallComponents.PDF.Forms.Fields.TextField).Value = insured 'UCase(ds.Tables(0).Rows(0).Item("Name").ToString())
            Dim agent As String = ""
            agent = "              " & UCase(ds3.Tables(0).Rows(0).Item("AgencyID").ToString()) & UCase(ds3.Tables(0).Rows(0).Item("AgencyCode").ToString())
            agent += vbCrLf & "              " & UCase(ds3.Tables(0).Rows(0).Item("AgencyName").ToString())
            agent += vbCrLf & "              " & UCase(ds3.Tables(0).Rows(0).Item("AgentAddr2").ToString())
            agent += vbCrLf & "              " & UCase(ds3.Tables(0).Rows(0).Item("AgentCity").ToString()) & ", " & UCase(ds3.Tables(0).Rows(0).Item("AgentState").ToString()) & "  " & UCase(ds3.Tables(0).Rows(0).Item("AgentZip").ToString()) & vbTab
            agent += vbCrLf & "              " & UCase(ds3.Tables(0).Rows(0).Item("AgentPhone").ToString())


            pdffield = myPDFFields.Fields("AGENCY NAMENO")
            DirectCast(pdffield, TallComponents.PDF.Forms.Fields.TextField).Value = agent 'ds.Tables(0).Rows(0).Item("AgencyCode").ToString()
            pdffield = myPDFFields.Fields("Applicants Social Security Number")
            DirectCast(pdffield, TallComponents.PDF.Forms.Fields.TextField).Value = UCase("XXX-XX-" & ds.Tables(0).Rows(0).Item("SSN").ToString().Substring(5, 4)) 'UCase(ds.Tables(0).Rows(0).Item("SSN").ToString())
            pdffield = myPDFFields.Fields("Applicants Date of Birth")
            DirectCast(pdffield, TallComponents.PDF.Forms.Fields.TextField).Value = UCase(ds.Tables(0).Rows(0).Item("DOB").ToString())
            If ds.Tables(0).Rows(0).Item("COSSN").ToString().Length > 4 Then
                pdffield = myPDFFields.Fields("CoApplicants Social Security Number")
                DirectCast(pdffield, TallComponents.PDF.Forms.Fields.TextField).Value = UCase("XXX-XX-" & ds.Tables(0).Rows(0).Item("COSSN").ToString().Substring(5, 4)) 'UCase(ds.Tables(0).Rows(0).Item("COSSN").ToString())

            End If
           pdffield = myPDFFields.Fields("CoApplicants Date of Birth")
            DirectCast(pdffield, TallComponents.PDF.Forms.Fields.TextField).Value = UCase(ds.Tables(0).Rows(0).Item("CODOB").ToString())
            pdffield = myPDFFields.Fields("Applicant  CoApplicants Occupations")
            DirectCast(pdffield, TallComponents.PDF.Forms.Fields.TextField).Value = UCase(ds.Tables(0).Rows(0).Item("Occ").ToString()) & " / " & UCase(ds.Tables(0).Rows(0).Item("cooccupation").ToString())

            Dim diffadd As String = ""

            diffadd = "              " & UCase(ds.Tables(0).Rows(0).Item("Address").ToString())
            ' diffadd += vbCrLf & "              " & UCase(ds.Tables(0).Rows(0).Item("City").ToString()) & ", " & UCase(ds.Tables(0).Rows(0).Item("State").ToString()) & "  " & UCase(ds.Tables(0).Rows(0).Item("Zip").ToString()) & vbTab & "  " & UCase(ds.Tables(0).Rows(0).Item("County").ToString())



            pdffield = myPDFFields.Fields("Described Location if other than above")
            DirectCast(pdffield, TallComponents.PDF.Forms.Fields.TextField).Value = diffadd
            Dim addition
            Dim addition2 As String
            addition = UCase(ds.Tables(0).Rows(0).Item("Lien1Name").ToString())
            addition += vbCrLf & UCase(ds.Tables(0).Rows(0).Item("Lien1Num").ToString())
            addition += vbCrLf & UCase(ds.Tables(0).Rows(0).Item("Lien1Addr").ToString())
            addition += vbCrLf & UCase(ds.Tables(0).Rows(0).Item("Lien1City").ToString()) & ", " & UCase(ds.Tables(0).Rows(0).Item("Lien1State").ToString()) & "  " & UCase(ds.Tables(0).Rows(0).Item("Lien1Zip").ToString())

            addition2 = UCase(ds.Tables(0).Rows(0).Item("Lien2Name").ToString())
            addition2 += vbCrLf & UCase(ds.Tables(0).Rows(0).Item("Lien2Num").ToString())
            addition2 += vbCrLf & UCase(ds.Tables(0).Rows(0).Item("Lien2Addr").ToString())
            addition2 += vbCrLf & UCase(ds.Tables(0).Rows(0).Item("Lien2City").ToString()) & ", " & UCase(ds.Tables(0).Rows(0).Item("Lien2State").ToString()) & "  " & UCase(ds.Tables(0).Rows(0).Item("Lien2Zip").ToString())

            pdffield = myPDFFields.Fields("MORTGAGEE")
            DirectCast(pdffield, TallComponents.PDF.Forms.Fields.TextField).Value = addition
            pdffield = myPDFFields.Fields("MORTGAGEE2")
            DirectCast(pdffield, TallComponents.PDF.Forms.Fields.TextField).Value = addition2
            '''Quote data
            pdffield = myPDFFields.Fields("CoverageRow1")
            DirectCast(pdffield, TallComponents.PDF.Forms.Fields.TextField).Value = UCase("Content Replacement") 'ds.Tables(0).Rows(0).Item("Data").ToString()
            pdffield = myPDFFields.Fields("PremiumRow1")
            DirectCast(pdffield, TallComponents.PDF.Forms.Fields.TextField).Value = ds2.Tables(0).Rows(0).Item("PackContPrem").ToString().Replace("$", "").Replace(",", "")
            pdffield = myPDFFields.Fields("CoverageRow2")
            DirectCast(pdffield, TallComponents.PDF.Forms.Fields.TextField).Value = UCase("Lienholders Single Interest") 'ds.Tables(0).Rows(0).Item("Data").ToString()
            pdffield = myPDFFields.Fields("PremiumRow2")
            DirectCast(pdffield, TallComponents.PDF.Forms.Fields.TextField).Value = ds2.Tables(0).Rows(0).Item("PackSPIprem").ToString().Replace("$", "").Replace(",", "")
            pdffield = myPDFFields.Fields("CoverageRow3")
            DirectCast(pdffield, TallComponents.PDF.Forms.Fields.TextField).Value = UCase("Additional Residence Liability") 'ds.Tables(0).Rows(0).Item("Data").ToString()
            pdffield = myPDFFields.Fields("PremiumRow3")
            DirectCast(pdffield, TallComponents.PDF.Forms.Fields.TextField).Value = ds2.Tables(0).Rows(0).Item("PackAddlResLiabPrem").ToString().Replace("$", "").Replace(",", "")
            pdffield = myPDFFields.Fields("CoverageRow4")
            DirectCast(pdffield, TallComponents.PDF.Forms.Fields.TextField).Value = UCase("Valuable Personal Property") 'ds.Tables(0).Rows(0).Item("Data").ToString()
            pdffield = myPDFFields.Fields("PremiumRow4")
            DirectCast(pdffield, TallComponents.PDF.Forms.Fields.TextField).Value = ds2.Tables(0).Rows(0).Item("PackPPprem").ToString().Replace("$", "").Replace(",", "")
            pdffield = myPDFFields.Fields("CoverageRow5")
            DirectCast(pdffield, TallComponents.PDF.Forms.Fields.TextField).Value = UCase("Credits") 'ds.Tables(0).Rows(0).Item("Data").ToString()
            pdffield = myPDFFields.Fields("PremiumRow5")
            If IsNumeric(ds2.Tables(0).Rows(0).Item("PackSmokecredit").ToString().Replace("$", "")) Then
                DirectCast(pdffield, TallComponents.PDF.Forms.Fields.TextField).Value = "(" & CDec(ds2.Tables(0).Rows(0).Item("PackCreditamt").ToString().Replace("$", "")) + CDec(ds2.Tables(0).Rows(0).Item("PackSmokecredit").ToString().Replace("$", "")) & ")"
            Else
                DirectCast(pdffield, TallComponents.PDF.Forms.Fields.TextField).Value = "(" & ds2.Tables(0).Rows(0).Item("PackCreditamt").ToString().Replace("$", "") & ")"
            End If



            pdffield = myPDFFields.Fields("PROTECTION CLASS")
            DirectCast(pdffield, TallComponents.PDF.Forms.Fields.TextField).Value = ds.Tables(0).Rows(0).Item("Protection").ToString()

            'pdffield = myPDFFields.Fields("SEASONAL Questions Below Must Be Answered")
            'DirectCast(pdffield, TallComponents.PDF.Forms.Fields.TextField).Value = ds.Tables(0).Rows(0).Item("Data").ToString()
            pdffield = myPDFFields.Fields("Residence")
            DirectCast(pdffield, TallComponents.PDF.Forms.Fields.TextField).Value = ds2.Tables(0).Rows(0).Item("PackDwel").ToString().Replace("$", "").Replace(",", "")
            pdffield = myPDFFields.Fields("OtherStructures")
            DirectCast(pdffield, TallComponents.PDF.Forms.Fields.TextField).Value = ds2.Tables(0).Rows(0).Item("PackStruc").ToString().Replace("$", "").Replace(",", "")
            pdffield = myPDFFields.Fields("PersonalProperty")
            DirectCast(pdffield, TallComponents.PDF.Forms.Fields.TextField).Value = ds2.Tables(0).Rows(0).Item("PackCont").ToString().Replace("$", "").Replace(",", "")
            pdffield = myPDFFields.Fields("ALE_LossRent")
            DirectCast(pdffield, TallComponents.PDF.Forms.Fields.TextField).Value = CInt(ds2.Tables(0).Rows(0).Item("PackDwel").ToString()) * 0.1
            pdffield = myPDFFields.Fields("Liability")
            DirectCast(pdffield, TallComponents.PDF.Forms.Fields.TextField).Value = ds2.Tables(0).Rows(0).Item("PackLiab").ToString().Replace("$", "").Replace(",", "")
            pdffield = myPDFFields.Fields("MedPay")
            DirectCast(pdffield, TallComponents.PDF.Forms.Fields.TextField).Value = ds2.Tables(0).Rows(0).Item("PackMedPay").ToString().Replace("$", "").Replace(",", "")
            pdffield = myPDFFields.Fields("AOP")
            DirectCast(pdffield, TallComponents.PDF.Forms.Fields.TextField).Value = ds2.Tables(0).Rows(0).Item("PackAOP").ToString().Replace("$", "").Replace(",", "")
            pdffield = myPDFFields.Fields("WindHail")
            DirectCast(pdffield, TallComponents.PDF.Forms.Fields.TextField).Value = ds2.Tables(0).Rows(0).Item("PackAOP").ToString().Replace("$", "").Replace(",", "")
            pdffield = myPDFFields.Fields("PremnoOpt")
            DirectCast(pdffield, TallComponents.PDF.Forms.Fields.TextField).Value = ds2.Tables(0).Rows(0).Item("PackBasePrem").ToString().Replace("$", "").Replace(",", "")
            pdffield = myPDFFields.Fields("TotalPrem")
            DirectCast(pdffield, TallComponents.PDF.Forms.Fields.TextField).Value = ds2.Tables(0).Rows(0).Item("Packtotal").ToString().Replace("$", "").Replace(",", "")

            '==========================end quote========================


            pdffield = myPDFFields.Fields("mfgyear")
            DirectCast(pdffield, TallComponents.PDF.Forms.Fields.TextField).Value = ds.Tables(0).Rows(0).Item("DescMHYear").ToString()
            pdffield = myPDFFields.Fields("mhlength")
            DirectCast(pdffield, TallComponents.PDF.Forms.Fields.TextField).Value = ds.Tables(0).Rows(0).Item("DescMHLength").ToString()
            pdffield = myPDFFields.Fields("Is the home ever rented")
            DirectCast(pdffield, TallComponents.PDF.Forms.Fields.TextField).Value = ds.Tables(0).Rows(0).Item("ARing20").ToString()
            pdffield = myPDFFields.Fields("Is it within 5 road miles of a fire dept")
            DirectCast(pdffield, TallComponents.PDF.Forms.Fields.TextField).Value = ds.Tables(0).Rows(0).Item("ARing21").ToString()
            pdffield = myPDFFields.Fields("Is it within 500 feet and sight of two full time residences")
            DirectCast(pdffield, TallComponents.PDF.Forms.Fields.TextField).Value = ds.Tables(0).Rows(0).Item("ARing22").ToString()
            pdffield = myPDFFields.Fields("where it enters the residence while unoccupied")
            DirectCast(pdffield, TallComponents.PDF.Forms.Fields.TextField).Value = ds.Tables(0).Rows(0).Item("ARing23").ToString()
            pdffield = myPDFFields.Fields("Is the home entered by the insured or his representative at least once every 30 days")
            DirectCast(pdffield, TallComponents.PDF.Forms.Fields.TextField).Value = ds.Tables(0).Rows(0).Item("ARing24").ToString()
            pdffield = myPDFFields.Fields("NameAddressStreetMail")
            DirectCast(pdffield, TallComponents.PDF.Forms.Fields.TextField).Value = UCase(ds.Tables(0).Rows(0).Item("DiffAppAddr").ToString())
            pdffield = myPDFFields.Fields("NameAddresscityzipMail")
            DirectCast(pdffield, TallComponents.PDF.Forms.Fields.TextField).Value = UCase(ds.Tables(0).Rows(0).Item("DiffAppCity").ToString()) & ", " & UCase(ds.Tables(0).Rows(0).Item("DiffAppState").ToString()) & "  " & ds.Tables(0).Rows(0).Item("DiffAppZip").ToString() & "     " & UCase(ds.Tables(0).Rows(0).Item("DiffAppCounty").ToString())

            pdffield = myPDFFields.Fields("locationcounty")
            DirectCast(pdffield, TallComponents.PDF.Forms.Fields.TextField).Value = UCase(ds.Tables(0).Rows(0).Item("County").ToString())
            pdffield = myPDFFields.Fields("locationstate")
            DirectCast(pdffield, TallComponents.PDF.Forms.Fields.TextField).Value = UCase(ds.Tables(0).Rows(0).Item("State").ToString())
            pdffield = myPDFFields.Fields("locationzip")
            DirectCast(pdffield, TallComponents.PDF.Forms.Fields.TextField).Value = ds.Tables(0).Rows(0).Item("Zip").ToString()
            pdffield = myPDFFields.Fields("mfg")
            DirectCast(pdffield, TallComponents.PDF.Forms.Fields.TextField).Value = UCase(ds.Tables(0).Rows(0).Item("DescMHManf").ToString())
            pdffield = myPDFFields.Fields("mfgmodel")
            DirectCast(pdffield, TallComponents.PDF.Forms.Fields.TextField).Value = UCase(ds.Tables(0).Rows(0).Item("DescModel").ToString())
            pdffield = myPDFFields.Fields("mhwidth")
            DirectCast(pdffield, TallComponents.PDF.Forms.Fields.TextField).Value = UCase(ds.Tables(0).Rows(0).Item("DescMHWidth").ToString())
            pdffield = myPDFFields.Fields("mhseiralNumber")
            DirectCast(pdffield, TallComponents.PDF.Forms.Fields.TextField).Value = UCase(ds.Tables(0).Rows(0).Item("DescMHSerial").ToString())
            pdffield = myPDFFields.Fields("What is the applicants employers")
            DirectCast(pdffield, TallComponents.PDF.Forms.Fields.TextField).Value = UCase(ds.Tables(0).Rows(0).Item("Employer").ToString())
            pdffield = myPDFFields.Fields("Is the home on continuous masonry foundation")
            DirectCast(pdffield, TallComponents.PDF.Forms.Fields.TextField).Value = UCase(ds.Tables(0).Rows(0).Item("foundation").ToString())
            pdffield = myPDFFields.Fields("is the skirting vinyl or brick")
            DirectCast(pdffield, TallComponents.PDF.Forms.Fields.TextField).Value = UCase(ds.Tables(0).Rows(0).Item("skirting").ToString())
            pdffield = myPDFFields.Fields("Describe any room additions size")
            DirectCast(pdffield, TallComponents.PDF.Forms.Fields.TextField).Value = UCase(ds.Tables(0).Rows(0).Item("DescMHAttStruc").ToString())
            pdffield = myPDFFields.Fields("use")
            DirectCast(pdffield, TallComponents.PDF.Forms.Fields.TextField).Value = UCase(ds.Tables(0).Rows(0).Item("Usage").ToString())
            ''pdffield = myPDFFields.Fields("professional built")
            ''DirectCast(pdffield, TallComponents.PDF.Forms.Fields.TextField).Value = ds.Tables(0).Rows(0).Item("Data").ToString()
            If ds.Tables(0).Rows(0).Item("DescMHAttStruc").ToString() = "" Then
                pdffield = myPDFFields.Fields("Photos are required  None")
                DirectCast(pdffield, TallComponents.PDF.Forms.Fields.TextField).Value = "X" 'ds.Tables(0).Rows(0).Item("Data").ToString()
            End If

            pdffield = myPDFFields.Fields("Describe any other buildings on the premises size")
            DirectCast(pdffield, TallComponents.PDF.Forms.Fields.TextField).Value = ds.Tables(0).Rows(0).Item("DescMHUnAttStruc").ToString()
            ' ''pdffield = myPDFFields.Fields("use_2")
            ' ''DirectCast(pdffield, TallComponents.PDF.Forms.Fields.TextField).Value = ds.Tables(0).Rows(0).Item("Data").ToString()
            If ds.Tables(0).Rows(0).Item("DescMHUnAttStruc").ToString() = "" Then
                pdffield = myPDFFields.Fields("None")
                DirectCast(pdffield, TallComponents.PDF.Forms.Fields.TextField).Value = "X" 'ds.Tables(0).Rows(0).Item("Data").ToString()
            End If

            pdffield = myPDFFields.Fields("If there is a qualifying pool on the premises is it above ground or below ground")
            DirectCast(pdffield, TallComponents.PDF.Forms.Fields.TextField).Value = ds.Tables(0).Rows(0).Item("pool").ToString()
            pdffield = myPDFFields.Fields("Describe any loss history for the past 5 years  Date of loss")
            DirectCast(pdffield, TallComponents.PDF.Forms.Fields.TextField).Value = ds.Tables(0).Rows(0).Item("Loss1Date").ToString()
            pdffield = myPDFFields.Fields("Type of loss")
            DirectCast(pdffield, TallComponents.PDF.Forms.Fields.TextField).Value = UCase(ds.Tables(0).Rows(0).Item("Loss1Type").ToString())
            pdffield = myPDFFields.Fields("Amount")
            DirectCast(pdffield, TallComponents.PDF.Forms.Fields.TextField).Value = ds.Tables(0).Rows(0).Item("Loss1AmtPaid").ToString()
            If ds.Tables(0).Rows(0).Item("Loss1Type").ToString() = "" Then
                pdffield = myPDFFields.Fields("None_2")
                DirectCast(pdffield, TallComponents.PDF.Forms.Fields.TextField).Value = "X"
            End If

            ''pdffield = myPDFFields.Fields("declineno")
            ''DirectCast(pdffield, TallComponents.PDF.Forms.Fields.TextField).Value = ds.Tables(0).Rows(0).Item("Data").ToString()
            ''pdffield = myPDFFields.Fields("declineyes")
            ''DirectCast(pdffield, TallComponents.PDF.Forms.Fields.TextField).Value = ds.Tables(0).Rows(0).Item("Data").ToString()
            ''pdffield = myPDFFields.Fields("Explain")
            ''DirectCast(pdffield, TallComponents.PDF.Forms.Fields.TextField).Value = ds.Tables(0).Rows(0).Item("Data").ToString()
            pdffield = myPDFFields.Fields("Give policy numbers of other prior policies with our company")
            DirectCast(pdffield, TallComponents.PDF.Forms.Fields.TextField).Value = UCase(ds.Tables(0).Rows(0).Item("otherpolicy").ToString())
            If ds.Tables(0).Rows(0).Item("otherexp").ToString().Length = 8 Then
                pdffield = myPDFFields.Fields("Date expired or cancelled")
                DirectCast(pdffield, TallComponents.PDF.Forms.Fields.TextField).Value = ds.Tables(0).Rows(0).Item("otherexp").ToString().Substring(0, 2) & "/" & ds.Tables(0).Rows(0).Item("otherexp").ToString().Substring(2, 2) & "/" & ds.Tables(0).Rows(0).Item("otherexp").ToString().Substring(4, 4)
            Else
                pdffield = myPDFFields.Fields("Date expired or cancelled")
                DirectCast(pdffield, TallComponents.PDF.Forms.Fields.TextField).Value = ds.Tables(0).Rows(0).Item("otherexp").ToString()
            End If
            'pdffield = myPDFFields.Fields("Date expired or cancelled")
            'DirectCast(pdffield, TallComponents.PDF.Forms.Fields.TextField).Value = ds.Tables(0).Rows(0).Item("otherexp").ToString()
            pdffield = myPDFFields.Fields("10  Previous carrier and policy number")
            DirectCast(pdffield, TallComponents.PDF.Forms.Fields.TextField).Value = UCase(ds.Tables(0).Rows(0).Item("PriorCompany").ToString()) & " / " & UCase(ds.Tables(0).Rows(0).Item("prevpolicy").ToString())

            If ds.Tables(0).Rows(0).Item("PriorInsExp").ToString().Length = 8 Then
                pdffield = myPDFFields.Fields("Date expired or cancelled_2")
                DirectCast(pdffield, TallComponents.PDF.Forms.Fields.TextField).Value = ds.Tables(0).Rows(0).Item("PriorInsExp").ToString().Substring(0, 2) & "/" & ds.Tables(0).Rows(0).Item("PriorInsExp").ToString().Substring(2, 2) & "/" & ds.Tables(0).Rows(0).Item("PriorInsExp").ToString().Substring(4, 4)
            Else
                pdffield = myPDFFields.Fields("Date expired or cancelled_2")
                DirectCast(pdffield, TallComponents.PDF.Forms.Fields.TextField).Value = ds.Tables(0).Rows(0).Item("PriorInsExp").ToString()
            End If
            'pdffield = myPDFFields.Fields("Date expired or cancelled_2")
            'DirectCast(pdffield, TallComponents.PDF.Forms.Fields.TextField).Value = ds.Tables(0).Rows(0).Item("PriorInsExp").ToString()
            pdffield = myPDFFields.Fields("ML3")
            DirectCast(pdffield, TallComponents.PDF.Forms.Fields.CheckBoxField).CheckBoxValue = CheckState.On
            If ds3.Tables(0).Rows(0).Item("homeUse").ToString() = "Seasonal" Then

                pdffield = myPDFFields.Fields("SEASONAL Questions Below Must Be Answered")
                DirectCast(pdffield, TallComponents.PDF.Forms.Fields.CheckBoxField).CheckBoxValue = CheckState.On
            Else
                pdffield = myPDFFields.Fields("PRIMARY")
                DirectCast(pdffield, TallComponents.PDF.Forms.Fields.CheckBoxField).CheckBoxValue = CheckState.On
            End If


            If ds.Tables(0).Rows(0).Item("ARing1").ToString() = "Yes" Then
                pdffield = myPDFFields.Fields("ARing1yes")
                DirectCast(pdffield, TallComponents.PDF.Forms.Fields.CheckBoxField).CheckBoxValue = CheckState.On
                pdffield = myPDFFields.Fields("ARing1no")
                DirectCast(pdffield, TallComponents.PDF.Forms.Fields.CheckBoxField).CheckBoxValue = CheckState.Off

            Else
                pdffield = myPDFFields.Fields("ARing1yes")
                DirectCast(pdffield, TallComponents.PDF.Forms.Fields.CheckBoxField).CheckBoxValue = CheckState.Off
                pdffield = myPDFFields.Fields("ARing1no")
                DirectCast(pdffield, TallComponents.PDF.Forms.Fields.CheckBoxField).CheckBoxValue = CheckState.On
            End If

            If ds.Tables(0).Rows(0).Item("ARing2").ToString() = "Yes" Then
                pdffield = myPDFFields.Fields("ARing2yes")
                DirectCast(pdffield, TallComponents.PDF.Forms.Fields.CheckBoxField).CheckBoxValue = CheckState.On
                pdffield = myPDFFields.Fields("ARing2no")
                DirectCast(pdffield, TallComponents.PDF.Forms.Fields.CheckBoxField).CheckBoxValue = CheckState.Off

            Else
                pdffield = myPDFFields.Fields("ARing2yes")
                DirectCast(pdffield, TallComponents.PDF.Forms.Fields.CheckBoxField).CheckBoxValue = CheckState.Off
                pdffield = myPDFFields.Fields("ARing2no")
                DirectCast(pdffield, TallComponents.PDF.Forms.Fields.CheckBoxField).CheckBoxValue = CheckState.On
            End If

            If ds.Tables(0).Rows(0).Item("ARing3").ToString() = "Yes" Then
                pdffield = myPDFFields.Fields("ARing3yes")
                DirectCast(pdffield, TallComponents.PDF.Forms.Fields.CheckBoxField).CheckBoxValue = CheckState.On
                pdffield = myPDFFields.Fields("ARing3no")
                DirectCast(pdffield, TallComponents.PDF.Forms.Fields.CheckBoxField).CheckBoxValue = CheckState.Off

            Else
                pdffield = myPDFFields.Fields("ARing3yes")
                DirectCast(pdffield, TallComponents.PDF.Forms.Fields.CheckBoxField).CheckBoxValue = CheckState.Off
                pdffield = myPDFFields.Fields("ARing3no")
                DirectCast(pdffield, TallComponents.PDF.Forms.Fields.CheckBoxField).CheckBoxValue = CheckState.On
            End If

            If ds.Tables(0).Rows(0).Item("ARing4").ToString() = "Yes" Then
                pdffield = myPDFFields.Fields("ARing4yes")
                DirectCast(pdffield, TallComponents.PDF.Forms.Fields.CheckBoxField).CheckBoxValue = CheckState.On
                pdffield = myPDFFields.Fields("ARing4no")
                DirectCast(pdffield, TallComponents.PDF.Forms.Fields.CheckBoxField).CheckBoxValue = CheckState.Off

            Else
                pdffield = myPDFFields.Fields("ARing4yes")
                DirectCast(pdffield, TallComponents.PDF.Forms.Fields.CheckBoxField).CheckBoxValue = CheckState.Off
                pdffield = myPDFFields.Fields("ARing4no")
                DirectCast(pdffield, TallComponents.PDF.Forms.Fields.CheckBoxField).CheckBoxValue = CheckState.On
            End If

            If ds.Tables(0).Rows(0).Item("ARing5").ToString() = "Yes" Then
                pdffield = myPDFFields.Fields("ARing5yes")
                DirectCast(pdffield, TallComponents.PDF.Forms.Fields.CheckBoxField).CheckBoxValue = CheckState.On
                pdffield = myPDFFields.Fields("ARing5no")
                DirectCast(pdffield, TallComponents.PDF.Forms.Fields.CheckBoxField).CheckBoxValue = CheckState.Off

            Else
                pdffield = myPDFFields.Fields("ARing5yes")
                DirectCast(pdffield, TallComponents.PDF.Forms.Fields.CheckBoxField).CheckBoxValue = CheckState.Off
                pdffield = myPDFFields.Fields("ARing5no")
                DirectCast(pdffield, TallComponents.PDF.Forms.Fields.CheckBoxField).CheckBoxValue = CheckState.On
            End If

            If ds.Tables(0).Rows(0).Item("ARing6").ToString() = "Yes" Then
                pdffield = myPDFFields.Fields("ARing6yes")
                DirectCast(pdffield, TallComponents.PDF.Forms.Fields.CheckBoxField).CheckBoxValue = CheckState.On
                pdffield = myPDFFields.Fields("ARing6no")
                DirectCast(pdffield, TallComponents.PDF.Forms.Fields.CheckBoxField).CheckBoxValue = CheckState.Off

            Else
                pdffield = myPDFFields.Fields("ARing6yes")
                DirectCast(pdffield, TallComponents.PDF.Forms.Fields.CheckBoxField).CheckBoxValue = CheckState.Off
                pdffield = myPDFFields.Fields("ARing6no")
                DirectCast(pdffield, TallComponents.PDF.Forms.Fields.CheckBoxField).CheckBoxValue = CheckState.On
            End If

            If ds.Tables(0).Rows(0).Item("ARing7").ToString() = "Yes" Then
                pdffield = myPDFFields.Fields("ARing7yes")
                DirectCast(pdffield, TallComponents.PDF.Forms.Fields.CheckBoxField).CheckBoxValue = CheckState.On
                pdffield = myPDFFields.Fields("ARing7no")
                DirectCast(pdffield, TallComponents.PDF.Forms.Fields.CheckBoxField).CheckBoxValue = CheckState.Off

            Else
                pdffield = myPDFFields.Fields("ARing7yes")
                DirectCast(pdffield, TallComponents.PDF.Forms.Fields.CheckBoxField).CheckBoxValue = CheckState.Off
                pdffield = myPDFFields.Fields("ARing7no")
                DirectCast(pdffield, TallComponents.PDF.Forms.Fields.CheckBoxField).CheckBoxValue = CheckState.On
            End If

            If ds.Tables(0).Rows(0).Item("ARing8").ToString() = "Yes" Then
                pdffield = myPDFFields.Fields("ARing8yes")
                DirectCast(pdffield, TallComponents.PDF.Forms.Fields.CheckBoxField).CheckBoxValue = CheckState.On
                pdffield = myPDFFields.Fields("ARing8no")
                DirectCast(pdffield, TallComponents.PDF.Forms.Fields.CheckBoxField).CheckBoxValue = CheckState.Off

            Else
                pdffield = myPDFFields.Fields("ARing8yes")
                DirectCast(pdffield, TallComponents.PDF.Forms.Fields.CheckBoxField).CheckBoxValue = CheckState.Off
                pdffield = myPDFFields.Fields("ARing8no")
                DirectCast(pdffield, TallComponents.PDF.Forms.Fields.CheckBoxField).CheckBoxValue = CheckState.On
            End If

            If ds.Tables(0).Rows(0).Item("ARing9").ToString() = "Yes" Then
                pdffield = myPDFFields.Fields("ARing9yes")
                DirectCast(pdffield, TallComponents.PDF.Forms.Fields.CheckBoxField).CheckBoxValue = CheckState.On
                pdffield = myPDFFields.Fields("ARing9no")
                DirectCast(pdffield, TallComponents.PDF.Forms.Fields.CheckBoxField).CheckBoxValue = CheckState.Off

            Else
                pdffield = myPDFFields.Fields("ARing9yes")
                DirectCast(pdffield, TallComponents.PDF.Forms.Fields.CheckBoxField).CheckBoxValue = CheckState.Off
                pdffield = myPDFFields.Fields("ARing9no")
                DirectCast(pdffield, TallComponents.PDF.Forms.Fields.CheckBoxField).CheckBoxValue = CheckState.On
            End If

            If ds.Tables(0).Rows(0).Item("ARing10").ToString() = "Yes" Then
                pdffield = myPDFFields.Fields("ARing10yes")
                DirectCast(pdffield, TallComponents.PDF.Forms.Fields.CheckBoxField).CheckBoxValue = CheckState.On
                pdffield = myPDFFields.Fields("ARing10no")
                DirectCast(pdffield, TallComponents.PDF.Forms.Fields.CheckBoxField).CheckBoxValue = CheckState.Off

            Else
                pdffield = myPDFFields.Fields("ARing10yes")
                DirectCast(pdffield, TallComponents.PDF.Forms.Fields.CheckBoxField).CheckBoxValue = CheckState.Off
                pdffield = myPDFFields.Fields("ARing10no")
                DirectCast(pdffield, TallComponents.PDF.Forms.Fields.CheckBoxField).CheckBoxValue = CheckState.On
            End If

            If ds.Tables(0).Rows(0).Item("ARing11").ToString() = "Yes" Then
                pdffield = myPDFFields.Fields("ARing11yes")
                DirectCast(pdffield, TallComponents.PDF.Forms.Fields.CheckBoxField).CheckBoxValue = CheckState.On
                pdffield = myPDFFields.Fields("ARing11no")
                DirectCast(pdffield, TallComponents.PDF.Forms.Fields.CheckBoxField).CheckBoxValue = CheckState.Off

            Else
                pdffield = myPDFFields.Fields("ARing11yes")
                DirectCast(pdffield, TallComponents.PDF.Forms.Fields.CheckBoxField).CheckBoxValue = CheckState.Off
                pdffield = myPDFFields.Fields("ARing11no")
                DirectCast(pdffield, TallComponents.PDF.Forms.Fields.CheckBoxField).CheckBoxValue = CheckState.On
            End If

            If ds.Tables(0).Rows(0).Item("ARing12").ToString() = "Yes" Then
                pdffield = myPDFFields.Fields("ARing12yes")
                DirectCast(pdffield, TallComponents.PDF.Forms.Fields.CheckBoxField).CheckBoxValue = CheckState.On
                pdffield = myPDFFields.Fields("ARing12no")
                DirectCast(pdffield, TallComponents.PDF.Forms.Fields.CheckBoxField).CheckBoxValue = CheckState.Off

            Else
                pdffield = myPDFFields.Fields("ARing12yes")
                DirectCast(pdffield, TallComponents.PDF.Forms.Fields.CheckBoxField).CheckBoxValue = CheckState.Off
                pdffield = myPDFFields.Fields("ARing12no")
                DirectCast(pdffield, TallComponents.PDF.Forms.Fields.CheckBoxField).CheckBoxValue = CheckState.On
            End If

            If ds.Tables(0).Rows(0).Item("ARing13").ToString() = "Yes" Then
                pdffield = myPDFFields.Fields("ARing13yes")
                DirectCast(pdffield, TallComponents.PDF.Forms.Fields.CheckBoxField).CheckBoxValue = CheckState.On
                pdffield = myPDFFields.Fields("ARing13no")
                DirectCast(pdffield, TallComponents.PDF.Forms.Fields.CheckBoxField).CheckBoxValue = CheckState.Off

            Else
                pdffield = myPDFFields.Fields("ARing13yes")
                DirectCast(pdffield, TallComponents.PDF.Forms.Fields.CheckBoxField).CheckBoxValue = CheckState.Off
                pdffield = myPDFFields.Fields("ARing13no")
                DirectCast(pdffield, TallComponents.PDF.Forms.Fields.CheckBoxField).CheckBoxValue = CheckState.On
            End If

            If ds.Tables(0).Rows(0).Item("ARing14").ToString() = "Yes" Then
                pdffield = myPDFFields.Fields("ARing14yes")
                DirectCast(pdffield, TallComponents.PDF.Forms.Fields.CheckBoxField).CheckBoxValue = CheckState.On
                pdffield = myPDFFields.Fields("ARing14no")
                DirectCast(pdffield, TallComponents.PDF.Forms.Fields.CheckBoxField).CheckBoxValue = CheckState.Off

            Else
                pdffield = myPDFFields.Fields("ARing14yes")
                DirectCast(pdffield, TallComponents.PDF.Forms.Fields.CheckBoxField).CheckBoxValue = CheckState.Off
                pdffield = myPDFFields.Fields("ARing14no")
                DirectCast(pdffield, TallComponents.PDF.Forms.Fields.CheckBoxField).CheckBoxValue = CheckState.On
            End If

            If ds.Tables(0).Rows(0).Item("ARing15").ToString() = "Yes" Then
                pdffield = myPDFFields.Fields("ARing15yes")
                DirectCast(pdffield, TallComponents.PDF.Forms.Fields.CheckBoxField).CheckBoxValue = CheckState.On
                pdffield = myPDFFields.Fields("ARing15no")
                DirectCast(pdffield, TallComponents.PDF.Forms.Fields.CheckBoxField).CheckBoxValue = CheckState.Off

            Else
                pdffield = myPDFFields.Fields("ARing15yes")
                DirectCast(pdffield, TallComponents.PDF.Forms.Fields.CheckBoxField).CheckBoxValue = CheckState.Off
                pdffield = myPDFFields.Fields("ARing15no")
                DirectCast(pdffield, TallComponents.PDF.Forms.Fields.CheckBoxField).CheckBoxValue = CheckState.On
            End If

            If ds.Tables(0).Rows(0).Item("ARing16").ToString() = "Yes" Then
                pdffield = myPDFFields.Fields("ARing16yes")
                DirectCast(pdffield, TallComponents.PDF.Forms.Fields.CheckBoxField).CheckBoxValue = CheckState.On
                pdffield = myPDFFields.Fields("ARing16no")
                DirectCast(pdffield, TallComponents.PDF.Forms.Fields.CheckBoxField).CheckBoxValue = CheckState.Off

            Else
                pdffield = myPDFFields.Fields("ARing16yes")
                DirectCast(pdffield, TallComponents.PDF.Forms.Fields.CheckBoxField).CheckBoxValue = CheckState.Off
                pdffield = myPDFFields.Fields("ARing16no")
                DirectCast(pdffield, TallComponents.PDF.Forms.Fields.CheckBoxField).CheckBoxValue = CheckState.On
            End If

            If ds.Tables(0).Rows(0).Item("ARing17").ToString() = "Yes" Then
                pdffield = myPDFFields.Fields("ARing17yes")
                DirectCast(pdffield, TallComponents.PDF.Forms.Fields.CheckBoxField).CheckBoxValue = CheckState.On
                pdffield = myPDFFields.Fields("ARing17no")
                DirectCast(pdffield, TallComponents.PDF.Forms.Fields.CheckBoxField).CheckBoxValue = CheckState.Off

            Else
                pdffield = myPDFFields.Fields("ARing17yes")
                DirectCast(pdffield, TallComponents.PDF.Forms.Fields.CheckBoxField).CheckBoxValue = CheckState.Off
                pdffield = myPDFFields.Fields("ARing17no")
                DirectCast(pdffield, TallComponents.PDF.Forms.Fields.CheckBoxField).CheckBoxValue = CheckState.On
            End If

            If ds.Tables(0).Rows(0).Item("ARing18").ToString() = "Yes" Then
                pdffield = myPDFFields.Fields("ARing18yes")
                DirectCast(pdffield, TallComponents.PDF.Forms.Fields.CheckBoxField).CheckBoxValue = CheckState.On
                pdffield = myPDFFields.Fields("ARing18no")
                DirectCast(pdffield, TallComponents.PDF.Forms.Fields.CheckBoxField).CheckBoxValue = CheckState.Off

            Else
                pdffield = myPDFFields.Fields("ARing18yes")
                DirectCast(pdffield, TallComponents.PDF.Forms.Fields.CheckBoxField).CheckBoxValue = CheckState.Off
                pdffield = myPDFFields.Fields("ARing18no")
                DirectCast(pdffield, TallComponents.PDF.Forms.Fields.CheckBoxField).CheckBoxValue = CheckState.On
            End If

            If ds.Tables(0).Rows(0).Item("ARing19").ToString() = "Yes" Then
                pdffield = myPDFFields.Fields("ARing19yes")
                DirectCast(pdffield, TallComponents.PDF.Forms.Fields.CheckBoxField).CheckBoxValue = CheckState.On
                pdffield = myPDFFields.Fields("ARing19no")
                DirectCast(pdffield, TallComponents.PDF.Forms.Fields.CheckBoxField).CheckBoxValue = CheckState.Off

            Else
                pdffield = myPDFFields.Fields("ARing19yes")
                DirectCast(pdffield, TallComponents.PDF.Forms.Fields.CheckBoxField).CheckBoxValue = CheckState.Off
                pdffield = myPDFFields.Fields("ARing19no")
                DirectCast(pdffield, TallComponents.PDF.Forms.Fields.CheckBoxField).CheckBoxValue = CheckState.On
            End If

            'If ds.Tables(0).Rows(0).Item("fulltimestatus").ToString() = "Yes" Then
            pdffield = myPDFFields.Fields("fulltimeyes")
            'DirectCast(pdffield, TallComponents.PDF.Forms.Fields.CheckBoxField).CheckBoxValue = CheckState.On

            DirectCast(pdffield, TallComponents.PDF.Forms.Fields.TextField).Value = ds.Tables(0).Rows(0).Item("fulltimestatus").ToString()
            ' Else
            '    pdffield = myPDFFields.Fields("fulltimeyes")
            '    DirectCast(pdffield, TallComponents.PDF.Forms.Fields.CheckBoxField).CheckBoxValue = CheckState.Off

            'End If


            If ds.Tables(0).Rows(0).Item("ARing25").ToString() = "Yes" Then
                pdffield = myPDFFields.Fields("declineyes")
                DirectCast(pdffield, TallComponents.PDF.Forms.Fields.CheckBoxField).CheckBoxValue = CheckState.On
                pdffield = myPDFFields.Fields("declineno")
                DirectCast(pdffield, TallComponents.PDF.Forms.Fields.CheckBoxField).CheckBoxValue = CheckState.Off
                pdffield = myPDFFields.Fields("Explain")
                DirectCast(pdffield, TallComponents.PDF.Forms.Fields.TextField).Value = UCase(ds.Tables(0).Rows(0).Item("ARIng25a").ToString())
            Else
                pdffield = myPDFFields.Fields("declineyes")
                DirectCast(pdffield, TallComponents.PDF.Forms.Fields.CheckBoxField).CheckBoxValue = CheckState.Off
                pdffield = myPDFFields.Fields("declineno")
                DirectCast(pdffield, TallComponents.PDF.Forms.Fields.CheckBoxField).CheckBoxValue = CheckState.On
            End If


            pdffield = myPDFFields.Fields("professional built")
            DirectCast(pdffield, TallComponents.PDF.Forms.Fields.TextField).Value = ds.Tables(0).Rows(0).Item("profbuilt").ToString()


            'pdffield = myPDFFields.Fields("fulltimeyes")
            'DirectCast(pdffield, TallComponents.PDF.Forms.Fields.TextField).Value = ds.Tables(0).Rows(0).Item("fulltimestatus").ToString()




            '========================================================


            'pdffield = myPDFFields.Fields("Special")
            'DirectCast(pdffield, TallComponents.PDF.Forms.Fields.TextField).Value = UCase(ds1.Tables(0).Rows(0).Item("Name").ToString())
            'pdffield = myPDFFields.Fields("allpurposerental")
            'DirectCast(pdffield, TallComponents.PDF.Forms.Fields.TextField).Value = UCase(ds1.Tables(0).Rows(0).Item("Name").ToString())
            'pdffield = myPDFFields.Fields("SUSPENSE")
            'DirectCast(pdffield, TallComponents.PDF.Forms.Fields.TextField).Value = UCase(ds1.Tables(0).Rows(0).Item("Name").ToString())
            'pdffield = myPDFFields.Fields("POLICY")
            'DirectCast(pdffield, TallComponents.PDF.Forms.Fields.TextField).Value = UCase(ds1.Tables(0).Rows(0).Item("Name").ToString())
            ''pdffield = myPDFFields.Fields("subagent")
            ''DirectCast(pdffield, TallComponents.PDF.Forms.Fields.TextField).Value = UCase(ds3.Tables(0).Rows(0).Item("AgencyCode").ToString())
            ''pdffield = myPDFFields.Fields("NAME")
            ''DirectCast(pdffield, TallComponents.PDF.Forms.Fields.TextField).Value = UCase(ds1.Tables(0).Rows(0).Item("Name").ToString())
            ''pdffield = myPDFFields.Fields("socialsecurity")
            ''DirectCast(pdffield, TallComponents.PDF.Forms.Fields.TextField).Value = UCase(ds1.Tables(0).Rows(0).Item("SSN").ToString())
            ''pdffield = myPDFFields.Fields("homephone")
            ''DirectCast(pdffield, TallComponents.PDF.Forms.Fields.TextField).Value = UCase(ds1.Tables(0).Rows(0).Item("Phone").ToString())
            ''pdffield = myPDFFields.Fields("mailingaddress")
            ''DirectCast(pdffield, TallComponents.PDF.Forms.Fields.TextField).Value = UCase(ds1.Tables(0).Rows(0).Item("DiffAppAddr").ToString())
            ''pdffield = myPDFFields.Fields("Locationaddress")
            ''DirectCast(pdffield, TallComponents.PDF.Forms.Fields.TextField).Value = UCase(ds1.Tables(0).Rows(0).Item("Address").ToString())
            ''pdffield = myPDFFields.Fields("ParkName")
            ''DirectCast(pdffield, TallComponents.PDF.Forms.Fields.TextField).Value = UCase(ds1.Tables(0).Rows(0).Item("ParkName").ToString())
            ''pdffield = myPDFFields.Fields("dob")
            ''DirectCast(pdffield, TallComponents.PDF.Forms.Fields.TextField).Value = UCase(ds1.Tables(0).Rows(0).Item("DOB").ToString())
            ''pdffield = myPDFFields.Fields("OCCUPATION")
            ''DirectCast(pdffield, TallComponents.PDF.Forms.Fields.TextField).Value = UCase(ds1.Tables(0).Rows(0).Item("Occ").ToString())
            ''pdffield = myPDFFields.Fields("EMPLOYER")
            ''DirectCast(pdffield, TallComponents.PDF.Forms.Fields.TextField).Value = UCase(ds1.Tables(0).Rows(0).Item("Employer").ToString())
            ''pdffield = myPDFFields.Fields("namelienholder")
            ''DirectCast(pdffield, TallComponents.PDF.Forms.Fields.TextField).Value = UCase(ds1.Tables(0).Rows(0).Item("Lien1Name").ToString())
            ''pdffield = myPDFFields.Fields("ACCOUNT NUMBER")
            ''DirectCast(pdffield, TallComponents.PDF.Forms.Fields.TextField).Value = UCase(ds1.Tables(0).Rows(0).Item("Lien1Num").ToString())
            ''pdffield = myPDFFields.Fields("MAILING ADDRESS")
            ''DirectCast(pdffield, TallComponents.PDF.Forms.Fields.TextField).Value = UCase(ds1.Tables(0).Rows(0).Item("Lien1Addr").ToString())
            ''pdffield = myPDFFields.Fields("CITY")
            ''DirectCast(pdffield, TallComponents.PDF.Forms.Fields.TextField).Value = UCase(ds1.Tables(0).Rows(0).Item("Lien1City").ToString())
            ''pdffield = myPDFFields.Fields("STATE")
            ''DirectCast(pdffield, TallComponents.PDF.Forms.Fields.TextField).Value = UCase(ds1.Tables(0).Rows(0).Item("Lien1State").ToString())
            ''pdffield = myPDFFields.Fields("ZIP")
            ''DirectCast(pdffield, TallComponents.PDF.Forms.Fields.TextField).Value = UCase(ds1.Tables(0).Rows(0).Item("Lien1Zip").ToString())
            ''Dim addition As String = ""
            ''If ds1.Tables(0).Rows(0).Item("Lien2Name").ToString().Length > 0 Then
            ''    pdffield = myPDFFields.Fields("Check box if additional Lienholder is indicated in Remarks section on reverse side")
            ''    DirectCast(pdffield, TallComponents.PDF.Forms.Fields.CheckBoxField).CheckBoxValue = CheckState.On
            ''    addition = "Second Lien:  " & UCase(ds1.Tables(0).Rows(0).Item("Lien2Name").ToString())
            ''    addition += vbCrLf & "              " & UCase(ds1.Tables(0).Rows(0).Item("Lien2Num").ToString())
            ''    addition += vbCrLf & "              " & UCase(ds1.Tables(0).Rows(0).Item("Lien2Addr").ToString())
            ''    addition += vbCrLf & "              " & UCase(ds1.Tables(0).Rows(0).Item("Lien2City").ToString()) & ", " & UCase(ds1.Tables(0).Rows(0).Item("Lien2State").ToString()) & "  " & UCase(ds1.Tables(0).Rows(0).Item("Lien1Zip").ToString()) & vbTab

            ''Else
            ''    pdffield = myPDFFields.Fields("Check box if additional Lienholder is indicated in Remarks section on reverse side")
            ''    DirectCast(pdffield, TallComponents.PDF.Forms.Fields.CheckBoxField).CheckBoxValue = CheckState.Off

            ''End If
            ''If ds1.Tables(0).Rows(0).Item("AddInsuredName").ToString().Length > 0 Then
            ''    pdffield = myPDFFields.Fields("applicantremarksbox")
            ''    DirectCast(pdffield, TallComponents.PDF.Forms.Fields.CheckBoxField).CheckBoxValue = CheckState.On
            ''    addition += vbCrLf & "Additional Insured:   " & UCase(ds1.Tables(0).Rows(0).Item("AddInsuredName").ToString())
            ''    addition += vbCrLf & "                      " & UCase(ds1.Tables(0).Rows(0).Item("AddInsuredAddress").ToString())
            ''    addition += vbCrLf & "                      " & UCase(ds1.Tables(0).Rows(0).Item("AddInsuredCity").ToString()) & ",  " & UCase(ds1.Tables(0).Rows(0).Item("AddInsuredState").ToString()) & "  " & UCase(ds1.Tables(0).Rows(0).Item("AddInsuredZip").ToString())


            ''Else
            ''    pdffield = myPDFFields.Fields("applicantremarksbox")
            ''    DirectCast(pdffield, TallComponents.PDF.Forms.Fields.CheckBoxField).CheckBoxValue = CheckState.Off

            ''End If

            ''pdffield = myPDFFields.Fields("additionalapplicants")
            ''DirectCast(pdffield, TallComponents.PDF.Forms.Fields.TextField).Value = addition


            ' ''Need this data
            ''pdffield = myPDFFields.Fields("effectivedateto")
            ''DirectCast(pdffield, TallComponents.PDF.Forms.Fields.TextField).Value = enddat 'UCase(ds1.Tables(0).Rows(0).Item("Name").ToString())
            ''pdffield = myPDFFields.Fields("numbermonths")
            ''DirectCast(pdffield, TallComponents.PDF.Forms.Fields.TextField).Value = "12" 'UCase(ds1.Tables(0).Rows(0).Item("PriorInsYears").ToString())

            ''If UCase(ds1.Tables(0).Rows(0).Item("PriorInsurance").ToString()) = "NO" Then

            ''    pdffield = myPDFFields.Fields("PREVIOUS CARRIER")
            ''    DirectCast(pdffield, TallComponents.PDF.Forms.Fields.TextField).Value = "None" 'UCase(ds1.Tables(0).Rows(0).Item("PriorCompany").ToString())
            ''ElseIf UCase(ds1.Tables(0).Rows(0).Item("PriorInsurance").ToString()) = "YES" Then

            ''    pdffield = myPDFFields.Fields("PREVIOUS CARRIER")
            ''    DirectCast(pdffield, TallComponents.PDF.Forms.Fields.TextField).Value = UCase(ds1.Tables(0).Rows(0).Item("PriorCompany").ToString())
            ''ElseIf UCase(ds1.Tables(0).Rows(0).Item("PriorInsurance").ToString()) = "NEW PURCHASE" Then

            ''    pdffield = myPDFFields.Fields("PREVIOUS CARRIER")
            ''    DirectCast(pdffield, TallComponents.PDF.Forms.Fields.TextField).Value = "New Purchase"
            ''End If


            ''pdffield = myPDFFields.Fields("YEAR")
            ''DirectCast(pdffield, TallComponents.PDF.Forms.Fields.TextField).Value = UCase(ds1.Tables(0).Rows(0).Item("DescMHYear").ToString())

            ''If UCase(ds1.Tables(0).Rows(0).Item("DescModel").ToString()) <> "" Or UCase(ds1.Tables(0).Rows(0).Item("DescMHManf").ToString()) <> "" Then
            ''    pdffield = myPDFFields.Fields("MAKEMODEL")
            ''    DirectCast(pdffield, TallComponents.PDF.Forms.Fields.TextField).Value = UCase(ds1.Tables(0).Rows(0).Item("DescMHManf").ToString()) & " / " & UCase(ds1.Tables(0).Rows(0).Item("DescModel").ToString())
            ''End If
            ' ''pdffield = myPDFFields.Fields("MAKEMODEL")
            ' ''DirectCast(pdffield, TallComponents.PDF.Forms.Fields.TextField).Value = UCase(ds1.Tables(0).Rows(0).Item("DescModel").ToString())
            ''pdffield = myPDFFields.Fields("serialnumber")
            ''DirectCast(pdffield, TallComponents.PDF.Forms.Fields.TextField).Value = UCase(ds1.Tables(0).Rows(0).Item("DescMHSerial").ToString())
            ''pdffield = myPDFFields.Fields("LENGTH")
            ''DirectCast(pdffield, TallComponents.PDF.Forms.Fields.TextField).Value = UCase(ds1.Tables(0).Rows(0).Item("DescMHLength").ToString())
            ''pdffield = myPDFFields.Fields("WIDTH")
            ''DirectCast(pdffield, TallComponents.PDF.Forms.Fields.TextField).Value = UCase(ds1.Tables(0).Rows(0).Item("DescMHWidth").ToString())
            ''pdffield = myPDFFields.Fields("datepurchased")
            ''DirectCast(pdffield, TallComponents.PDF.Forms.Fields.TextField).Value = UCase(ds1.Tables(0).Rows(0).Item("DescMHPurDate").ToString()).Substring(0, 2) & "/" & UCase(ds1.Tables(0).Rows(0).Item("DescMHPurDate").ToString()).Substring(2, 2) & "/" & UCase(ds1.Tables(0).Rows(0).Item("DescMHPurDate").ToString()).Substring(4, 4)
            ''pdffield = myPDFFields.Fields("PURCHASE PRICE")
            ''DirectCast(pdffield, TallComponents.PDF.Forms.Fields.TextField).Value = CInt(ds1.Tables(0).Rows(0).Item("DescMHPurPrice").ToString().Replace("$", "")).ToString("C0")
            ' ''attached structures
            ''pdffield = myPDFFields.Fields("stucture1")
            ''DirectCast(pdffield, TallComponents.PDF.Forms.Fields.TextField).Value = UCase(ds1.Tables(0).Rows(0).Item("DescMHAttStruc").ToString())
            ''pdffield = myPDFFields.Fields("fill79")
            ''DirectCast(pdffield, TallComponents.PDF.Forms.Fields.TextField).Value = UCase(ds1.Tables(0).Rows(0).Item("DescMHAttStrucCurVal").ToString())
            ''pdffield = myPDFFields.Fields("structure2")
            ''DirectCast(pdffield, TallComponents.PDF.Forms.Fields.TextField).Value = UCase(ds1.Tables(0).Rows(0).Item("DescMHUnAttStruc").ToString())
            ''pdffield = myPDFFields.Fields("fill81")
            ''DirectCast(pdffield, TallComponents.PDF.Forms.Fields.TextField).Value = UCase(ds1.Tables(0).Rows(0).Item("DescMHUnAttStrucCurVal").ToString())
            'pdffield = myPDFFields.Fields("structure3")
            'DirectCast(pdffield, TallComponents.PDF.Forms.Fields.TextField).Value = UCase(ds1.Tables(0).Rows(0).Item("Name").ToString())
            'pdffield = myPDFFields.Fields("fill83")
            'DirectCast(pdffield, TallComponents.PDF.Forms.Fields.TextField).Value = UCase(ds1.Tables(0).Rows(0).Item("Name").ToString())


            'Quote Data:
            'pdffield = myPDFFields.Fields("mobilecomp")
            'DirectCast(pdffield, TallComponents.PDF.Forms.Fields.TextField).Value = UCase(ds1.Tables(0).Rows(0).Item("Name").ToString())
            'pdffield = myPDFFields.Fields("mobileperils")
            'DirectCast(pdffield, TallComponents.PDF.Forms.Fields.TextField).Value = UCase(ds1.Tables(0).Rows(0).Item("Name").ToString())
            ''Select Case UCase(ds2.Tables(0).Rows(0).Item("ARRateType").ToString())
            ''    Case UCase("AMSLIC Standard")

            ''        pdffield = myPDFFields.Fields("mobilecompperils")
            ''        DirectCast(pdffield, TallComponents.PDF.Forms.Fields.TextField).Value = CInt(ds2.Tables(0).Rows(0).Item("PackDwel").ToString()).ToString("C0")
            ''        pdffield = myPDFFields.Fields("fill84")
            ''        DirectCast(pdffield, TallComponents.PDF.Forms.Fields.TextField).Value = CInt(ds2.Tables(0).Rows(0).Item("PackBasePrem").ToString().Replace("$", "")).ToString("C2").Replace("$", "")
            ''        pdffield = myPDFFields.Fields("structurescompperils")
            ''        DirectCast(pdffield, TallComponents.PDF.Forms.Fields.TextField).Value = CInt(ds2.Tables(0).Rows(0).Item("PackStruc").ToString()).ToString("C0")
            ''        pdffield = myPDFFields.Fields("fill85")
            ''        DirectCast(pdffield, TallComponents.PDF.Forms.Fields.TextField).Value = UCase(ds2.Tables(0).Rows(0).Item("PackStrucPrem").ToString())
            ''        'pdffield = myPDFFields.Fields("andcompperils")
            ''        'DirectCast(pdffield, TallComponents.PDF.Forms.Fields.TextField).Value = UCase(ds1.Tables(0).Rows(0).Item("Name").ToString())
            ''        'pdffield = myPDFFields.Fields("fill86")
            ''        'DirectCast(pdffield, TallComponents.PDF.Forms.Fields.TextField).Value = UCase(ds1.Tables(0).Rows(0).Item("Name").ToString())
            ''        pdffield = myPDFFields.Fields("personalcompperils")
            ''        DirectCast(pdffield, TallComponents.PDF.Forms.Fields.TextField).Value = CInt(ds2.Tables(0).Rows(0).Item("PackCont").ToString()).ToString("C0")
            ''        pdffield = myPDFFields.Fields("fill87")
            ''        DirectCast(pdffield, TallComponents.PDF.Forms.Fields.TextField).Value = UCase(ds2.Tables(0).Rows(0).Item("PackContPrem").ToString())
            ''        pdffield = myPDFFields.Fields("personalliability")
            ''        DirectCast(pdffield, TallComponents.PDF.Forms.Fields.TextField).Value = UCase(ds2.Tables(0).Rows(0).Item("PackLiab").ToString())
            ''        pdffield = myPDFFields.Fields("fill88")
            ''        DirectCast(pdffield, TallComponents.PDF.Forms.Fields.TextField).Value = UCase(ds2.Tables(0).Rows(0).Item("PackPersLiabPrem").ToString())
            ''        pdffield = myPDFFields.Fields("surchargesrow1")
            ''        DirectCast(pdffield, TallComponents.PDF.Forms.Fields.TextField).Value = "Fees" 'UCase(ds1.Tables(0).Rows(0).Item("Name").ToString())
            ''        pdffield = myPDFFields.Fields("fill99")
            ''        DirectCast(pdffield, TallComponents.PDF.Forms.Fields.TextField).Value = UCase(ds2.Tables(0).Rows(0).Item("PackFees").ToString().Replace("$", ""))
            ''        pdffield = myPDFFields.Fields("medicalpayments")
            ''        DirectCast(pdffield, TallComponents.PDF.Forms.Fields.TextField).Value = ds2.Tables(0).Rows(0).Item("PackMedPay").ToString()

            ''        pdffield = myPDFFields.Fields("fill89")
            ''        DirectCast(pdffield, TallComponents.PDF.Forms.Fields.TextField).Value = ds2.Tables(0).Rows(0).Item("PackMedPrem").ToString().Replace("$", "")
            ''        pdffield = myPDFFields.Fields("fill109")
            ''        DirectCast(pdffield, TallComponents.PDF.Forms.Fields.TextField).Value = ds2.Tables(0).Rows(0).Item("Packtotal").ToString().Replace("$", "")
            ''        pdffield = myPDFFields.Fields("Special")
            ''        DirectCast(pdffield, TallComponents.PDF.Forms.Fields.CheckBoxField).CheckBoxValue = CheckState.On
            ''        pdffield = myPDFFields.Fields("allpurposerental")
            ''        DirectCast(pdffield, TallComponents.PDF.Forms.Fields.CheckBoxField).CheckBoxValue = CheckState.Off
            ''        Dim test As String
            ''        test = ds2.Tables(0).Rows(0).Item("PackContReplace").ToString()
            ''        If UCase(ds2.Tables(0).Rows(0).Item("PackContReplace").ToString()) = "YES" Then

            ''            pdffield = myPDFFields.Fields("optionalrow1")
            ''            DirectCast(pdffield, TallComponents.PDF.Forms.Fields.TextField).Value = "Content Replacement" 'UCase(ds1.Tables(0).Rows(0).Item("Name").ToString())
            ''            pdffield = myPDFFields.Fields("fill93")
            ''            DirectCast(pdffield, TallComponents.PDF.Forms.Fields.TextField).Value = UCase(ds2.Tables(0).Rows(0).Item("PackContReplacePrem").ToString().Replace("$", ""))

            ''        End If
            ''        test = ds2.Tables(0).Rows(0).Item("PackFullRepair").ToString()
            ''        If UCase(ds2.Tables(0).Rows(0).Item("PackFullRepair").ToString()) = "YES" Then

            ''            pdffield = myPDFFields.Fields("optionalrow2")
            ''            DirectCast(pdffield, TallComponents.PDF.Forms.Fields.TextField).Value = "Full Repair" 'UCase(ds1.Tables(0).Rows(0).Item("Name").ToString())
            ''            pdffield = myPDFFields.Fields("fill_94")
            ''            DirectCast(pdffield, TallComponents.PDF.Forms.Fields.TextField).Value = UCase(ds2.Tables(0).Rows(0).Item("PackFullRepairPrem").ToString().Replace("$", ""))
            ''        End If

            ''        pdffield = myPDFFields.Fields("miscellaneousfeesrow2")
            ''        DirectCast(pdffield, TallComponents.PDF.Forms.Fields.TextField).Value = "Taxes " 'UCase(ds1.Tables(0).Rows(0).Item("Name").ToString())
            ''        pdffield = myPDFFields.Fields("fill106")
            ''        DirectCast(pdffield, TallComponents.PDF.Forms.Fields.TextField).Value = UCase(ds2.Tables(0).Rows(0).Item("PackTax").ToString().Replace("$", ""))
            ''        'pdffield = myPDFFields.Fields("optionalrow3")
            ''        'DirectCast(pdffield, TallComponents.PDF.Forms.Fields.TextField).Value = UCase(ds1.Tables(0).Rows(0).Item("Name").ToString())
            ''        'pdffield = myPDFFields.Fields("fill95")
            ''        'DirectCast(pdffield, TallComponents.PDF.Forms.Fields.TextField).Value = UCase(ds1.Tables(0).Rows(0).Item("Name").ToString())
            ''        'pdffield = myPDFFields.Fields("optionalrow4")
            ''        'DirectCast(pdffield, TallComponents.PDF.Forms.Fields.TextField).Value = UCase(ds1.Tables(0).Rows(0).Item("Name").ToString())
            ''        'pdffield = myPDFFields.Fields("fill96")
            ''        'DirectCast(pdffield, TallComponents.PDF.Forms.Fields.TextField).Value = UCase(ds1.Tables(0).Rows(0).Item("Name").ToString())
            ''        'pdffield = myPDFFields.Fields("optionalrow5")
            ''        'DirectCast(pdffield, TallComponents.PDF.Forms.Fields.TextField).Value = UCase(ds1.Tables(0).Rows(0).Item("Name").ToString())
            ''        'pdffield = myPDFFields.Fields("fill97")
            ''        'DirectCast(pdffield, TallComponents.PDF.Forms.Fields.TextField).Value = UCase(ds1.Tables(0).Rows(0).Item("Name").ToString())

            ''        pdffield = myPDFFields.Fields("deduction1")
            ''        DirectCast(pdffield, TallComponents.PDF.Forms.Fields.TextField).Value = UCase(ds2.Tables(0).Rows(0).Item("PackAOP").ToString().Replace("$", ""))
            ''        pdffield = myPDFFields.Fields("deduction2")
            ''        DirectCast(pdffield, TallComponents.PDF.Forms.Fields.TextField).Value = "1000 W/H  " & vbCrLf & UCase(ds2.Tables(0).Rows(0).Item("PackWind").ToString().Replace("$", "")) & " H/TS"

            ''    Case UCase("AMSLIC Rental")
            ''        pdffield = myPDFFields.Fields("Special")
            ''        DirectCast(pdffield, TallComponents.PDF.Forms.Fields.CheckBoxField).CheckBoxValue = CheckState.Off
            ''        pdffield = myPDFFields.Fields("allpurposerental")
            ''        DirectCast(pdffield, TallComponents.PDF.Forms.Fields.CheckBoxField).CheckBoxValue = CheckState.On

            ''        pdffield = myPDFFields.Fields("mobilecompperils")
            ''        DirectCast(pdffield, TallComponents.PDF.Forms.Fields.TextField).Value = CInt(ds2.Tables(0).Rows(0).Item("RentDwel").ToString()).ToString("C0")
            ''        pdffield = myPDFFields.Fields("fill84")
            ''        DirectCast(pdffield, TallComponents.PDF.Forms.Fields.TextField).Value = CInt(ds2.Tables(0).Rows(0).Item("RentBasePrem").ToString().Replace("$", "")).ToString("C2").Replace("$", "")
            ''        pdffield = myPDFFields.Fields("structurescompperils")
            ''        DirectCast(pdffield, TallComponents.PDF.Forms.Fields.TextField).Value = CInt(ds2.Tables(0).Rows(0).Item("RentStruc").ToString()).ToString("C0")
            ''        pdffield = myPDFFields.Fields("fill85")
            ''        DirectCast(pdffield, TallComponents.PDF.Forms.Fields.TextField).Value = UCase(ds2.Tables(0).Rows(0).Item("RentStrucPrem").ToString())
            ''        'pdffield = myPDFFields.Fields("andcompperils")
            ''        'DirectCast(pdffield, TallComponents.PDF.Forms.Fields.TextField).Value = UCase(ds1.Tables(0).Rows(0).Item("Name").ToString())
            ''        'pdffield = myPDFFields.Fields("fill86")
            ''        'DirectCast(pdffield, TallComponents.PDF.Forms.Fields.TextField).Value = UCase(ds1.Tables(0).Rows(0).Item("Name").ToString())
            ''        pdffield = myPDFFields.Fields("personalcompperils")
            ''        DirectCast(pdffield, TallComponents.PDF.Forms.Fields.TextField).Value = CInt(ds2.Tables(0).Rows(0).Item("RentCont").ToString()).ToString("C0")
            ''        pdffield = myPDFFields.Fields("fill87")
            ''        DirectCast(pdffield, TallComponents.PDF.Forms.Fields.TextField).Value = UCase(ds2.Tables(0).Rows(0).Item("RentContPrem").ToString())
            ''        pdffield = myPDFFields.Fields("personalliability")
            ''        DirectCast(pdffield, TallComponents.PDF.Forms.Fields.TextField).Value = UCase(ds2.Tables(0).Rows(0).Item("RentLiab").ToString())
            ''        pdffield = myPDFFields.Fields("fill88")
            ''        DirectCast(pdffield, TallComponents.PDF.Forms.Fields.TextField).Value = UCase(ds2.Tables(0).Rows(0).Item("RentPersLiabPrem").ToString())
            ''        pdffield = myPDFFields.Fields("surchargesrow1")
            ''        DirectCast(pdffield, TallComponents.PDF.Forms.Fields.TextField).Value = "Fees" 'UCase(ds1.Tables(0).Rows(0).Item("Name").ToString())
            ''        pdffield = myPDFFields.Fields("fill99")
            ''        DirectCast(pdffield, TallComponents.PDF.Forms.Fields.TextField).Value = UCase(ds2.Tables(0).Rows(0).Item("RentFees").ToString().Replace("$", ""))
            ''        pdffield = myPDFFields.Fields("medicalpayments")
            ''        DirectCast(pdffield, TallComponents.PDF.Forms.Fields.TextField).Value = ds2.Tables(0).Rows(0).Item("RentMedPay").ToString()

            ''        pdffield = myPDFFields.Fields("fill89")
            ''        DirectCast(pdffield, TallComponents.PDF.Forms.Fields.TextField).Value = ds2.Tables(0).Rows(0).Item("RentMedPrem").ToString().Replace("$", "")
            ''        pdffield = myPDFFields.Fields("fill109")
            ''        DirectCast(pdffield, TallComponents.PDF.Forms.Fields.TextField).Value = ds2.Tables(0).Rows(0).Item("Renttotal").ToString().Replace("$", "")

            ''        Dim test As String
            ''        test = ds2.Tables(0).Rows(0).Item("RentContReplace").ToString()
            ''        If UCase(ds2.Tables(0).Rows(0).Item("RentContReplace").ToString()) = "YES" Then

            ''            pdffield = myPDFFields.Fields("optionalrow1")
            ''            DirectCast(pdffield, TallComponents.PDF.Forms.Fields.TextField).Value = "Content Replacement" 'UCase(ds1.Tables(0).Rows(0).Item("Name").ToString())
            ''            pdffield = myPDFFields.Fields("fill93")
            ''            DirectCast(pdffield, TallComponents.PDF.Forms.Fields.TextField).Value = UCase(ds2.Tables(0).Rows(0).Item("RentContReplacePrem").ToString().Replace("$", ""))

            ''        End If
            ''        test = ds2.Tables(0).Rows(0).Item("RentFullRepair").ToString()
            ''        If UCase(ds2.Tables(0).Rows(0).Item("RentFullRepair").ToString()) = "YES" Then

            ''            pdffield = myPDFFields.Fields("optionalrow2")
            ''            DirectCast(pdffield, TallComponents.PDF.Forms.Fields.TextField).Value = "Full Repair" 'UCase(ds1.Tables(0).Rows(0).Item("Name").ToString())
            ''            pdffield = myPDFFields.Fields("fill_94")
            ''            DirectCast(pdffield, TallComponents.PDF.Forms.Fields.TextField).Value = UCase(ds2.Tables(0).Rows(0).Item("RentFullRepairPrem").ToString().Replace("$", ""))
            ''        End If

            ''        pdffield = myPDFFields.Fields("miscellaneousfeesrow2")
            ''        DirectCast(pdffield, TallComponents.PDF.Forms.Fields.TextField).Value = "Taxes " 'UCase(ds1.Tables(0).Rows(0).Item("Name").ToString())
            ''        pdffield = myPDFFields.Fields("fill106")
            ''        DirectCast(pdffield, TallComponents.PDF.Forms.Fields.TextField).Value = UCase(ds2.Tables(0).Rows(0).Item("RentTax").ToString().Replace("$", ""))
            ''        'pdffield = myPDFFields.Fields("optionalrow3")
            ''        'DirectCast(pdffield, TallComponents.PDF.Forms.Fields.TextField).Value = UCase(ds1.Tables(0).Rows(0).Item("Name").ToString())
            ''        'pdffield = myPDFFields.Fields("fill95")
            ''        'DirectCast(pdffield, TallComponents.PDF.Forms.Fields.TextField).Value = UCase(ds1.Tables(0).Rows(0).Item("Name").ToString())
            ''        'pdffield = myPDFFields.Fields("optionalrow4")
            ''        'DirectCast(pdffield, TallComponents.PDF.Forms.Fields.TextField).Value = UCase(ds1.Tables(0).Rows(0).Item("Name").ToString())
            ''        'pdffield = myPDFFields.Fields("fill96")
            ''        'DirectCast(pdffield, TallComponents.PDF.Forms.Fields.TextField).Value = UCase(ds1.Tables(0).Rows(0).Item("Name").ToString())
            ''        'pdffield = myPDFFields.Fields("optionalrow5")
            ''        'DirectCast(pdffield, TallComponents.PDF.Forms.Fields.TextField).Value = UCase(ds1.Tables(0).Rows(0).Item("Name").ToString())
            ''        'pdffield = myPDFFields.Fields("fill97")
            ''        'DirectCast(pdffield, TallComponents.PDF.Forms.Fields.TextField).Value = UCase(ds1.Tables(0).Rows(0).Item("Name").ToString())

            ''        pdffield = myPDFFields.Fields("deduction1")
            ''        DirectCast(pdffield, TallComponents.PDF.Forms.Fields.TextField).Value = UCase(ds2.Tables(0).Rows(0).Item("RentAOP").ToString().Replace("$", ""))
            ''        pdffield = myPDFFields.Fields("deduction2")
            ''        DirectCast(pdffield, TallComponents.PDF.Forms.Fields.TextField).Value = "1000 W/H  " & vbCrLf & UCase(ds2.Tables(0).Rows(0).Item("RentWind").ToString().Replace("$", "")) & " H/TS"


            ''End Select





            ' ''pdffield = myPDFFields.Fields("stucturecomp")
            ' ''DirectCast(pdffield, TallComponents.PDF.Forms.Fields.TextField).Value = UCase(ds1.Tables(0).Rows(0).Item("Name").ToString())
            ' ''pdffield = myPDFFields.Fields("stucturesperils")
            ' ''DirectCast(pdffield, TallComponents.PDF.Forms.Fields.TextField).Value = UCase(ds1.Tables(0).Rows(0).Item("Name").ToString())


            ' ''pdffield = myPDFFields.Fields("andcomp")
            ' ''DirectCast(pdffield, TallComponents.PDF.Forms.Fields.TextField).Value = UCase(ds1.Tables(0).Rows(0).Item("Name").ToString())
            ' ''pdffield = myPDFFields.Fields("andperils")
            ' ''DirectCast(pdffield, TallComponents.PDF.Forms.Fields.TextField).Value = UCase(ds1.Tables(0).Rows(0).Item("Name").ToString())
            ' ''pdffield = myPDFFields.Fields("andcompperils")
            ' ''DirectCast(pdffield, TallComponents.PDF.Forms.Fields.TextField).Value = UCase(ds1.Tables(0).Rows(0).Item("Name").ToString())
            ' ''pdffield = myPDFFields.Fields("fill86")
            ' ''DirectCast(pdffield, TallComponents.PDF.Forms.Fields.TextField).Value = UCase(ds1.Tables(0).Rows(0).Item("Name").ToString())
            ' ''pdffield = myPDFFields.Fields("pesonalcomp")
            ' ''DirectCast(pdffield, TallComponents.PDF.Forms.Fields.TextField).Value = UCase(ds1.Tables(0).Rows(0).Item("Name").ToString())
            ' ''pdffield = myPDFFields.Fields("personalperils")
            ' ''DirectCast(pdffield, TallComponents.PDF.Forms.Fields.TextField).Value = UCase(ds1.Tables(0).Rows(0).Item("Name").ToString())


            ' ''pdffield = myPDFFields.Fields("liability")
            ' ''DirectCast(pdffield, TallComponents.PDF.Forms.Fields.TextField).Value = UCase(ds1.Tables(0).Rows(0).Item("Name").ToString())
            ' ''pdffield = myPDFFields.Fields("fill91")
            ' ''DirectCast(pdffield, TallComponents.PDF.Forms.Fields.TextField).Value = UCase(ds1.Tables(0).Rows(0).Item("Name").ToString())
            ' ''pdffield = myPDFFields.Fields("optionalcoverages")
            ' ''DirectCast(pdffield, TallComponents.PDF.Forms.Fields.TextField).Value = UCase(ds1.Tables(0).Rows(0).Item("Name").ToString())
            ' ''pdffield = myPDFFields.Fields("fill92")
            ' ''DirectCast(pdffield, TallComponents.PDF.Forms.Fields.TextField).Value = UCase(ds1.Tables(0).Rows(0).Item("Name").ToString())

            ' ''pdffield = myPDFFields.Fields("surcharges")
            ' ''DirectCast(pdffield, TallComponents.PDF.Forms.Fields.TextField).Value = UCase(ds1.Tables(0).Rows(0).Item("Name").ToString())
            ' ''pdffield = myPDFFields.Fields("fill98")
            ' ''DirectCast(pdffield, TallComponents.PDF.Forms.Fields.TextField).Value = UCase(ds1.Tables(0).Rows(0).Item("Name").ToString())
            ' ''pdffield = myPDFFields.Fields("surchargesrow1")
            ' ''DirectCast(pdffield, TallComponents.PDF.Forms.Fields.TextField).Value = UCase(ds1.Tables(0).Rows(0).Item("Name").ToString())
            ' ''pdffield = myPDFFields.Fields("fill99")
            ' ''DirectCast(pdffield, TallComponents.PDF.Forms.Fields.TextField).Value = UCase(ds1.Tables(0).Rows(0).Item("Name").ToString())
            ' ''pdffield = myPDFFields.Fields("credits")
            ' ''DirectCast(pdffield, TallComponents.PDF.Forms.Fields.TextField).Value = UCase(ds1.Tables(0).Rows(0).Item("Name").ToString())
            ' ''pdffield = myPDFFields.Fields("fill101")
            ' ''DirectCast(pdffield, TallComponents.PDF.Forms.Fields.TextField).Value = UCase(ds1.Tables(0).Rows(0).Item("Name").ToString())
            ' ''pdffield = myPDFFields.Fields("creditsrow1")
            ' ''DirectCast(pdffield, TallComponents.PDF.Forms.Fields.TextField).Value = UCase(ds1.Tables(0).Rows(0).Item("Name").ToString())
            ' ''pdffield = myPDFFields.Fields("fill102")
            ' ''DirectCast(pdffield, TallComponents.PDF.Forms.Fields.TextField).Value = UCase(ds1.Tables(0).Rows(0).Item("Name").ToString())
            ' ''pdffield = myPDFFields.Fields("creditsvalue")
            ' ''DirectCast(pdffield, TallComponents.PDF.Forms.Fields.TextField).Value = UCase(ds1.Tables(0).Rows(0).Item("Name").ToString())
            ' ''pdffield = myPDFFields.Fields("fill103")
            ' ''DirectCast(pdffield, TallComponents.PDF.Forms.Fields.TextField).Value = UCase(ds1.Tables(0).Rows(0).Item("Name").ToString())
            ' ''pdffield = myPDFFields.Fields("fees")
            ' ''DirectCast(pdffield, TallComponents.PDF.Forms.Fields.TextField).Value = UCase(ds1.Tables(0).Rows(0).Item("Name").ToString())
            ' ''pdffield = myPDFFields.Fields("fill104")
            ' ''DirectCast(pdffield, TallComponents.PDF.Forms.Fields.TextField).Value = UCase(ds1.Tables(0).Rows(0).Item("Name").ToString())
            ' ''pdffield = myPDFFields.Fields("miscellaneousfeesbill")
            ' ''DirectCast(pdffield, TallComponents.PDF.Forms.Fields.TextField).Value = UCase(ds1.Tables(0).Rows(0).Item("Name").ToString())
            ' ''pdffield = myPDFFields.Fields("fill105")
            ' ''DirectCast(pdffield, TallComponents.PDF.Forms.Fields.TextField).Value = UCase(ds1.Tables(0).Rows(0).Item("Name").ToString())
            ' ''pdffield = myPDFFields.Fields("miscellaneousfeesrow2")
            ' ''DirectCast(pdffield, TallComponents.PDF.Forms.Fields.TextField).Value = UCase(ds1.Tables(0).Rows(0).Item("Name").ToString())
            ' ''pdffield = myPDFFields.Fields("fill106")
            ' ''DirectCast(pdffield, TallComponents.PDF.Forms.Fields.TextField).Value = UCase(ds1.Tables(0).Rows(0).Item("Name").ToString())
            ' ''pdffield = myPDFFields.Fields("fill109")
            ' ''DirectCast(pdffield, TallComponents.PDF.Forms.Fields.TextField).Value = UCase(ds1.Tables(0).Rows(0).Item("Name").ToString())

            ' ''pdffield = myPDFFields.Fields("ownersliabilty")
            ' ''DirectCast(pdffield, TallComponents.PDF.Forms.Fields.TextField).Value = UCase(ds1.Tables(0).Rows(0).Item("Name").ToString())
            ' ''pdffield = myPDFFields.Fields("fill90")
            ' ''DirectCast(pdffield, TallComponents.PDF.Forms.Fields.TextField).Value = UCase(ds1.Tables(0).Rows(0).Item("Name").ToString())

            ' ''Check or radio boxes
            ''pdffield = myPDFFields.Fields("nsured lived in a mobile home")
            ''DirectCast(pdffield, TallComponents.PDF.Forms.Fields.TextField).Value = UCase(ds1.Tables(0).Rows(0).Item("livedyears").ToString())


            ''If ds1.Tables(0).Rows(0).Item("ARing1").ToString() = "Yes" Then
            ''    pdffield = myPDFFields.Fields("skirtedyes")
            ''    DirectCast(pdffield, TallComponents.PDF.Forms.Fields.CheckBoxField).CheckBoxValue = CheckState.On
            ''    pdffield = myPDFFields.Fields("skirtedno")
            ''    DirectCast(pdffield, TallComponents.PDF.Forms.Fields.CheckBoxField).CheckBoxValue = CheckState.Off

            ''Else
            ''    pdffield = myPDFFields.Fields("skirtedyes")
            ''    DirectCast(pdffield, TallComponents.PDF.Forms.Fields.CheckBoxField).CheckBoxValue = CheckState.Off
            ''    pdffield = myPDFFields.Fields("skirtedno")
            ''    DirectCast(pdffield, TallComponents.PDF.Forms.Fields.CheckBoxField).CheckBoxValue = CheckState.On
            ''End If
            ''If ds1.Tables(0).Rows(0).Item("ARing2").ToString() = "Yes" Then
            ''    pdffield = myPDFFields.Fields("woodstoveyes")
            ''    DirectCast(pdffield, TallComponents.PDF.Forms.Fields.CheckBoxField).CheckBoxValue = CheckState.On
            ''    pdffield = myPDFFields.Fields("woodstoveno")
            ''    DirectCast(pdffield, TallComponents.PDF.Forms.Fields.CheckBoxField).CheckBoxValue = CheckState.Off

            ''Else
            ''    pdffield = myPDFFields.Fields("woodstoveyes")
            ''    DirectCast(pdffield, TallComponents.PDF.Forms.Fields.CheckBoxField).CheckBoxValue = CheckState.Off
            ''    pdffield = myPDFFields.Fields("woodstoveno")
            ''    DirectCast(pdffield, TallComponents.PDF.Forms.Fields.CheckBoxField).CheckBoxValue = CheckState.On
            ''End If
            ''If ds1.Tables(0).Rows(0).Item("ARing3").ToString() = "Yes" Then
            ''    pdffield = myPDFFields.Fields("tiedownyes")
            ''    DirectCast(pdffield, TallComponents.PDF.Forms.Fields.CheckBoxField).CheckBoxValue = CheckState.On
            ''    pdffield = myPDFFields.Fields("tiedownno")
            ''    DirectCast(pdffield, TallComponents.PDF.Forms.Fields.CheckBoxField).CheckBoxValue = CheckState.Off

            ''Else
            ''    pdffield = myPDFFields.Fields("tiedownyes")
            ''    DirectCast(pdffield, TallComponents.PDF.Forms.Fields.CheckBoxField).CheckBoxValue = CheckState.Off
            ''    pdffield = myPDFFields.Fields("tiedownno")
            ''    DirectCast(pdffield, TallComponents.PDF.Forms.Fields.CheckBoxField).CheckBoxValue = CheckState.On
            ''End If
            ''If ds1.Tables(0).Rows(0).Item("ARing4").ToString() = "Yes" Then
            ''    pdffield = myPDFFields.Fields("sidingyes")
            ''    DirectCast(pdffield, TallComponents.PDF.Forms.Fields.CheckBoxField).CheckBoxValue = CheckState.On
            ''    pdffield = myPDFFields.Fields("sidingno")
            ''    DirectCast(pdffield, TallComponents.PDF.Forms.Fields.CheckBoxField).CheckBoxValue = CheckState.Off

            ''Else
            ''    pdffield = myPDFFields.Fields("sidingyes")
            ''    DirectCast(pdffield, TallComponents.PDF.Forms.Fields.CheckBoxField).CheckBoxValue = CheckState.Off
            ''    pdffield = myPDFFields.Fields("sidingno")
            ''    DirectCast(pdffield, TallComponents.PDF.Forms.Fields.CheckBoxField).CheckBoxValue = CheckState.On
            ''End If

            ''If ds1.Tables(0).Rows(0).Item("burglaralarm").ToString() = "True" Then
            ''    pdffield = myPDFFields.Fields("Burg")
            ''    DirectCast(pdffield, TallComponents.PDF.Forms.Fields.CheckBoxField).CheckBoxValue = CheckState.On
            ''Else
            ''    pdffield = myPDFFields.Fields("Burg")
            ''    DirectCast(pdffield, TallComponents.PDF.Forms.Fields.CheckBoxField).CheckBoxValue = CheckState.Off
            ''End If
            ''If ds1.Tables(0).Rows(0).Item("deadbolt").ToString() = "True" Then
            ''    pdffield = myPDFFields.Fields("Deadbolt")
            ''    DirectCast(pdffield, TallComponents.PDF.Forms.Fields.CheckBoxField).CheckBoxValue = CheckState.On
            ''Else
            ''    pdffield = myPDFFields.Fields("Deadbolt")
            ''    DirectCast(pdffield, TallComponents.PDF.Forms.Fields.CheckBoxField).CheckBoxValue = CheckState.Off
            ''End If
            ''If ds1.Tables(0).Rows(0).Item("smokedetector").ToString() = "True" Then
            ''    pdffield = myPDFFields.Fields("Smoke")
            ''    DirectCast(pdffield, TallComponents.PDF.Forms.Fields.CheckBoxField).CheckBoxValue = CheckState.On
            ''Else
            ''    pdffield = myPDFFields.Fields("Smoke")
            ''    DirectCast(pdffield, TallComponents.PDF.Forms.Fields.CheckBoxField).CheckBoxValue = CheckState.Off
            ''End If
            ''If ds1.Tables(0).Rows(0).Item("fireext").ToString() = "True" Then
            ''    pdffield = myPDFFields.Fields("Extinguisher")
            ''    DirectCast(pdffield, TallComponents.PDF.Forms.Fields.CheckBoxField).CheckBoxValue = CheckState.On
            ''Else
            ''    pdffield = myPDFFields.Fields("Extinguisher")
            ''    DirectCast(pdffield, TallComponents.PDF.Forms.Fields.CheckBoxField).CheckBoxValue = CheckState.Off
            ''End If

            ''If ds1.Tables(0).Rows(0).Item("ARing6").ToString() = "Yes" Then
            ''    pdffield = myPDFFields.Fields("claimyes")
            ''    DirectCast(pdffield, TallComponents.PDF.Forms.Fields.CheckBoxField).CheckBoxValue = CheckState.On
            ''    pdffield = myPDFFields.Fields("claimno")
            ''    DirectCast(pdffield, TallComponents.PDF.Forms.Fields.CheckBoxField).CheckBoxValue = CheckState.Off

            ''Else
            ''    pdffield = myPDFFields.Fields("claimyes")
            ''    DirectCast(pdffield, TallComponents.PDF.Forms.Fields.CheckBoxField).CheckBoxValue = CheckState.Off
            ''    pdffield = myPDFFields.Fields("claimno")
            ''    DirectCast(pdffield, TallComponents.PDF.Forms.Fields.CheckBoxField).CheckBoxValue = CheckState.On
            ''End If


            ''If ds1.Tables(0).Rows(0).Item("ARing7").ToString() = "Yes" Then
            ''    pdffield = myPDFFields.Fields("livestockyes")
            ''    DirectCast(pdffield, TallComponents.PDF.Forms.Fields.CheckBoxField).CheckBoxValue = CheckState.On
            ''    pdffield = myPDFFields.Fields("livestockno")
            ''    DirectCast(pdffield, TallComponents.PDF.Forms.Fields.CheckBoxField).CheckBoxValue = CheckState.Off

            ''Else
            ''    pdffield = myPDFFields.Fields("livestockyes")
            ''    DirectCast(pdffield, TallComponents.PDF.Forms.Fields.CheckBoxField).CheckBoxValue = CheckState.Off
            ''    pdffield = myPDFFields.Fields("livestockno")
            ''    DirectCast(pdffield, TallComponents.PDF.Forms.Fields.CheckBoxField).CheckBoxValue = CheckState.On
            ''End If

            ''If ds1.Tables(0).Rows(0).Item("ARing8").ToString() = "Yes" Then
            ''    pdffield = myPDFFields.Fields("nonrenewedyes")
            ''    DirectCast(pdffield, TallComponents.PDF.Forms.Fields.CheckBoxField).CheckBoxValue = CheckState.On
            ''    pdffield = myPDFFields.Fields("nonrenewedno")
            ''    DirectCast(pdffield, TallComponents.PDF.Forms.Fields.CheckBoxField).CheckBoxValue = CheckState.Off

            ''Else
            ''    pdffield = myPDFFields.Fields("nonrenewedyes")
            ''    DirectCast(pdffield, TallComponents.PDF.Forms.Fields.CheckBoxField).CheckBoxValue = CheckState.Off
            ''    pdffield = myPDFFields.Fields("nonrenewedno")
            ''    DirectCast(pdffield, TallComponents.PDF.Forms.Fields.CheckBoxField).CheckBoxValue = CheckState.On
            ''End If

            ''If ds1.Tables(0).Rows(0).Item("ARing10").ToString() = "Yes" Then
            ''    pdffield = myPDFFields.Fields("isolatedyes")
            ''    DirectCast(pdffield, TallComponents.PDF.Forms.Fields.CheckBoxField).CheckBoxValue = CheckState.On
            ''    pdffield = myPDFFields.Fields("isolatedno")
            ''    DirectCast(pdffield, TallComponents.PDF.Forms.Fields.CheckBoxField).CheckBoxValue = CheckState.Off

            ''Else
            ''    pdffield = myPDFFields.Fields("isolatedyes")
            ''    DirectCast(pdffield, TallComponents.PDF.Forms.Fields.CheckBoxField).CheckBoxValue = CheckState.Off
            ''    pdffield = myPDFFields.Fields("isolatedno")
            ''    DirectCast(pdffield, TallComponents.PDF.Forms.Fields.CheckBoxField).CheckBoxValue = CheckState.On
            ''End If
            ''If ds1.Tables(0).Rows(0).Item("ARing9").ToString() = "Yes" Then
            ''    pdffield = myPDFFields.Fields("floodyes")
            ''    DirectCast(pdffield, TallComponents.PDF.Forms.Fields.CheckBoxField).CheckBoxValue = CheckState.On
            ''    pdffield = myPDFFields.Fields("floodno")
            ''    DirectCast(pdffield, TallComponents.PDF.Forms.Fields.CheckBoxField).CheckBoxValue = CheckState.Off

            ''Else
            ''    pdffield = myPDFFields.Fields("floodyes")
            ''    DirectCast(pdffield, TallComponents.PDF.Forms.Fields.CheckBoxField).CheckBoxValue = CheckState.Off
            ''    pdffield = myPDFFields.Fields("floodno")
            ''    DirectCast(pdffield, TallComponents.PDF.Forms.Fields.CheckBoxField).CheckBoxValue = CheckState.On
            ''End If
            ''If ds1.Tables(0).Rows(0).Item("ARing11").ToString() = "Yes" Then
            ''    pdffield = myPDFFields.Fields("lessthan1000yes")
            ''    DirectCast(pdffield, TallComponents.PDF.Forms.Fields.CheckBoxField).CheckBoxValue = CheckState.On
            ''    pdffield = myPDFFields.Fields("lessthan1000no")
            ''    DirectCast(pdffield, TallComponents.PDF.Forms.Fields.CheckBoxField).CheckBoxValue = CheckState.Off

            ''Else
            ''    pdffield = myPDFFields.Fields("lessthan1000yes")
            ''    DirectCast(pdffield, TallComponents.PDF.Forms.Fields.CheckBoxField).CheckBoxValue = CheckState.Off
            ''    pdffield = myPDFFields.Fields("lessthan1000no")
            ''    DirectCast(pdffield, TallComponents.PDF.Forms.Fields.CheckBoxField).CheckBoxValue = CheckState.On
            ''End If

            ''If ds1.Tables(0).Rows(0).Item("ARing12").ToString() = "Yes" Then
            ''    pdffield = myPDFFields.Fields("poolyes")
            ''    DirectCast(pdffield, TallComponents.PDF.Forms.Fields.CheckBoxField).CheckBoxValue = CheckState.On
            ''    pdffield = myPDFFields.Fields("poolno")
            ''    DirectCast(pdffield, TallComponents.PDF.Forms.Fields.CheckBoxField).CheckBoxValue = CheckState.Off

            ''Else
            ''    pdffield = myPDFFields.Fields("poolyes")
            ''    DirectCast(pdffield, TallComponents.PDF.Forms.Fields.CheckBoxField).CheckBoxValue = CheckState.Off
            ''    pdffield = myPDFFields.Fields("poolno")
            ''    DirectCast(pdffield, TallComponents.PDF.Forms.Fields.CheckBoxField).CheckBoxValue = CheckState.On
            ''End If

            ''If ds1.Tables(0).Rows(0).Item("ARing13").ToString() = "Yes" Then
            ''    pdffield = myPDFFields.Fields("handrailsyes")
            ''    DirectCast(pdffield, TallComponents.PDF.Forms.Fields.CheckBoxField).CheckBoxValue = CheckState.On
            ''    pdffield = myPDFFields.Fields("handrailsno")
            ''    DirectCast(pdffield, TallComponents.PDF.Forms.Fields.CheckBoxField).CheckBoxValue = CheckState.Off

            ''Else
            ''    pdffield = myPDFFields.Fields("handrailsyes")
            ''    DirectCast(pdffield, TallComponents.PDF.Forms.Fields.CheckBoxField).CheckBoxValue = CheckState.Off
            ''    pdffield = myPDFFields.Fields("handrailsno")
            ''    DirectCast(pdffield, TallComponents.PDF.Forms.Fields.CheckBoxField).CheckBoxValue = CheckState.On
            ''End If

            ''If ds1.Tables(0).Rows(0).Item("ARing14").ToString() = "Yes" Then
            ''    pdffield = myPDFFields.Fields("urethaneyes")
            ''    DirectCast(pdffield, TallComponents.PDF.Forms.Fields.CheckBoxField).CheckBoxValue = CheckState.On
            ''    pdffield = myPDFFields.Fields("urethaneno")
            ''    DirectCast(pdffield, TallComponents.PDF.Forms.Fields.CheckBoxField).CheckBoxValue = CheckState.Off

            ''Else
            ''    pdffield = myPDFFields.Fields("urethaneyes")
            ''    DirectCast(pdffield, TallComponents.PDF.Forms.Fields.CheckBoxField).CheckBoxValue = CheckState.Off
            ''    pdffield = myPDFFields.Fields("urethaneno")
            ''    DirectCast(pdffield, TallComponents.PDF.Forms.Fields.CheckBoxField).CheckBoxValue = CheckState.On
            ''End If

            ''Select Case ds1.Tables(0).Rows(0).Item("Usage").ToString()
            ''    Case "Owner"
            ''        pdffield = myPDFFields.Fields("principleresident")
            ''        DirectCast(pdffield, TallComponents.PDF.Forms.Fields.CheckBoxField).CheckBoxValue = CheckState.On
            ''        pdffield = myPDFFields.Fields("seasonalresident")
            ''        DirectCast(pdffield, TallComponents.PDF.Forms.Fields.CheckBoxField).CheckBoxValue = CheckState.Off
            ''        pdffield = myPDFFields.Fields("Rental")
            ''        DirectCast(pdffield, TallComponents.PDF.Forms.Fields.CheckBoxField).CheckBoxValue = CheckState.Off
            ''        pdffield = myPDFFields.Fields("Vacant")
            ''        DirectCast(pdffield, TallComponents.PDF.Forms.Fields.CheckBoxField).CheckBoxValue = CheckState.Off
            ''        pdffield = myPDFFields.Fields("commercial")
            ''        DirectCast(pdffield, TallComponents.PDF.Forms.Fields.CheckBoxField).CheckBoxValue = CheckState.Off
            ''    Case "Seasonal"
            ''        pdffield = myPDFFields.Fields("principleresident")
            ''        DirectCast(pdffield, TallComponents.PDF.Forms.Fields.CheckBoxField).CheckBoxValue = CheckState.Off
            ''        pdffield = myPDFFields.Fields("seasonalresident")
            ''        DirectCast(pdffield, TallComponents.PDF.Forms.Fields.CheckBoxField).CheckBoxValue = CheckState.On
            ''        pdffield = myPDFFields.Fields("Rental")
            ''        DirectCast(pdffield, TallComponents.PDF.Forms.Fields.CheckBoxField).CheckBoxValue = CheckState.Off
            ''        pdffield = myPDFFields.Fields("Vacant")
            ''        DirectCast(pdffield, TallComponents.PDF.Forms.Fields.CheckBoxField).CheckBoxValue = CheckState.Off
            ''        pdffield = myPDFFields.Fields("commercial")
            ''        DirectCast(pdffield, TallComponents.PDF.Forms.Fields.CheckBoxField).CheckBoxValue = CheckState.Off
            ''    Case "Rental"
            ''        pdffield = myPDFFields.Fields("principleresident")
            ''        DirectCast(pdffield, TallComponents.PDF.Forms.Fields.CheckBoxField).CheckBoxValue = CheckState.Off
            ''        pdffield = myPDFFields.Fields("seasonalresident")
            ''        DirectCast(pdffield, TallComponents.PDF.Forms.Fields.CheckBoxField).CheckBoxValue = CheckState.Off
            ''        pdffield = myPDFFields.Fields("Rental")
            ''        DirectCast(pdffield, TallComponents.PDF.Forms.Fields.CheckBoxField).CheckBoxValue = CheckState.On
            ''        pdffield = myPDFFields.Fields("Vacant")
            ''        DirectCast(pdffield, TallComponents.PDF.Forms.Fields.CheckBoxField).CheckBoxValue = CheckState.Off
            ''        pdffield = myPDFFields.Fields("commercial")
            ''        DirectCast(pdffield, TallComponents.PDF.Forms.Fields.CheckBoxField).CheckBoxValue = CheckState.Off
            ''    Case Else

            ''        pdffield = myPDFFields.Fields("principleresident")
            ''        DirectCast(pdffield, TallComponents.PDF.Forms.Fields.CheckBoxField).CheckBoxValue = CheckState.On
            ''        pdffield = myPDFFields.Fields("seasonalresident")
            ''        DirectCast(pdffield, TallComponents.PDF.Forms.Fields.CheckBoxField).CheckBoxValue = CheckState.Off
            ''        pdffield = myPDFFields.Fields("Rental")
            ''        DirectCast(pdffield, TallComponents.PDF.Forms.Fields.CheckBoxField).CheckBoxValue = CheckState.Off
            ''        pdffield = myPDFFields.Fields("Vacant")
            ''        DirectCast(pdffield, TallComponents.PDF.Forms.Fields.CheckBoxField).CheckBoxValue = CheckState.Off
            ''        pdffield = myPDFFields.Fields("commercial")
            ''        DirectCast(pdffield, TallComponents.PDF.Forms.Fields.CheckBoxField).CheckBoxValue = CheckState.Off
            ''End Select


            ' ''GOLF CART

            ' ''pdffield = myPDFFields.Fields("golfcartcable")
            ' ''DirectCast(pdffield, TallComponents.PDF.Forms.Fields.TextField).Value = UCase(ds1.Tables(0).Rows(0).Item("Name").ToString())
            ' ''pdffield = myPDFFields.Fields("fill100")
            ' ''DirectCast(pdffield, TallComponents.PDF.Forms.Fields.TextField).Value = UCase(ds1.Tables(0).Rows(0).Item("Name").ToString())

            ''pdffield = myPDFFields.Fields("golfcart")
            ''DirectCast(pdffield, TallComponents.PDF.Forms.Fields.TextField).Value = UCase(ds1.Tables(0).Rows(0).Item("golfcart").ToString())
            ''pdffield = myPDFFields.Fields("cartserial")
            ''DirectCast(pdffield, TallComponents.PDF.Forms.Fields.TextField).Value = UCase(ds1.Tables(0).Rows(0).Item("golfcartserial").ToString())
            ''pdffield = myPDFFields.Fields("cartvalue")
            ''DirectCast(pdffield, TallComponents.PDF.Forms.Fields.TextField).Value = UCase(ds1.Tables(0).Rows(0).Item("golfcartvalue").ToString())

            ' ''agency bill or direct bill?

            ' ''pdffield = myPDFFields.Fields("agencybill")
            ' ''DirectCast(pdffield, TallComponents.PDF.Forms.Fields.TextField).Value = UCase(ds1.Tables(0).Rows(0).Item("Name").ToString())
            ' ''pdffield = myPDFFields.Fields("directbill")
            ' ''DirectCast(pdffield, TallComponents.PDF.Forms.Fields.TextField).Value = UCase(ds1.Tables(0).Rows(0).Item("Name").ToString())
            ' ''pdffield = myPDFFields.Fields("amountenclosed")
            ' ''DirectCast(pdffield, TallComponents.PDF.Forms.Fields.TextField).Value = UCase(ds1.Tables(0).Rows(0).Item("Name").ToString())
            ' ''pdffield = myPDFFields.Fields("applicant")
            ' ''DirectCast(pdffield, TallComponents.PDF.Forms.Fields.TextField).Value = UCase(ds1.Tables(0).Rows(0).Item("Name").ToString())
            ' ''pdffield = myPDFFields.Fields("lienholder")
            ' ''DirectCast(pdffield, TallComponents.PDF.Forms.Fields.TextField).Value = UCase(ds1.Tables(0).Rows(0).Item("Name").ToString())


            ''pdffield = myPDFFields.Fields("territoryratechart")
            ''DirectCast(pdffield, TallComponents.PDF.Forms.Fields.TextField).Value = UCase(ds1.Tables(0).Rows(0).Item("Territory1").ToString())
            ''pdffield = myPDFFields.Fields("protectionclass")
            ''DirectCast(pdffield, TallComponents.PDF.Forms.Fields.TextField).Value = UCase(ds1.Tables(0).Rows(0).Item("Protection").ToString())

            ''pdffield = myPDFFields.Fields("distfromhydrant")
            ''DirectCast(pdffield, TallComponents.PDF.Forms.Fields.TextField).Value = UCase(ds1.Tables(0).Rows(0).Item("DistToFire").ToString())
            ''pdffield = myPDFFields.Fields("distfromfiredept")
            ''DirectCast(pdffield, TallComponents.PDF.Forms.Fields.TextField).Value = UCase(ds1.Tables(0).Rows(0).Item("DistToFireDept").ToString())

            ''If ds1.Tables(0).Rows(0).Item("ctylimits").ToString() = "Yes" Then
            ''    pdffield = myPDFFields.Fields("mobilecitylimitsyes")
            ''    DirectCast(pdffield, TallComponents.PDF.Forms.Fields.CheckBoxField).CheckBoxValue = CheckState.On
            ''    pdffield = myPDFFields.Fields("mobilecitylimitsno")
            ''    DirectCast(pdffield, TallComponents.PDF.Forms.Fields.CheckBoxField).CheckBoxValue = CheckState.Off

            ''Else
            ''    pdffield = myPDFFields.Fields("mobilecitylimitsyes")
            ''    DirectCast(pdffield, TallComponents.PDF.Forms.Fields.CheckBoxField).CheckBoxValue = CheckState.Off
            ''    pdffield = myPDFFields.Fields("mobilecitylimitsno")
            ''    DirectCast(pdffield, TallComponents.PDF.Forms.Fields.CheckBoxField).CheckBoxValue = CheckState.On
            ''End If

            ''If ds1.Tables(0).Rows(0).Item("ParkStatus").ToString() = "Yes" Then
            ''    pdffield = myPDFFields.Fields("mobilehomeparkyes")
            ''    DirectCast(pdffield, TallComponents.PDF.Forms.Fields.CheckBoxField).CheckBoxValue = CheckState.On
            ''    pdffield = myPDFFields.Fields("mobilehomeparkno")
            ''    DirectCast(pdffield, TallComponents.PDF.Forms.Fields.CheckBoxField).CheckBoxValue = CheckState.Off

            ''Else
            ''    pdffield = myPDFFields.Fields("mobilehomeparkyes")
            ''    DirectCast(pdffield, TallComponents.PDF.Forms.Fields.CheckBoxField).CheckBoxValue = CheckState.Off
            ''    pdffield = myPDFFields.Fields("mobilehomeparkno")
            ''    DirectCast(pdffield, TallComponents.PDF.Forms.Fields.CheckBoxField).CheckBoxValue = CheckState.On
            ''End If

            ''pdffield = myPDFFields.Fields("numberoccupiedspaces")
            ''DirectCast(pdffield, TallComponents.PDF.Forms.Fields.TextField).Value = UCase(ds1.Tables(0).Rows(0).Item("NumOfSpaces").ToString())

            ' ''Check boxes
            ''If ds1.Tables(0).Rows(0).Item("pavedstreet").ToString() = "Yes" Then
            ''    pdffield = myPDFFields.Fields("pavedstreets")
            ''    DirectCast(pdffield, TallComponents.PDF.Forms.Fields.CheckBoxField).CheckBoxValue = CheckState.On


            ''Else
            ''    pdffield = myPDFFields.Fields("pavedstreets")
            ''    DirectCast(pdffield, TallComponents.PDF.Forms.Fields.CheckBoxField).CheckBoxValue = CheckState.Off

            ''End If
            ''If ds1.Tables(0).Rows(0).Item("lightedstreet").ToString() = "Yes" Then
            ''    pdffield = myPDFFields.Fields("lightedstreets")
            ''    DirectCast(pdffield, TallComponents.PDF.Forms.Fields.CheckBoxField).CheckBoxValue = CheckState.On


            ''Else
            ''    pdffield = myPDFFields.Fields("lightedstreets")
            ''    DirectCast(pdffield, TallComponents.PDF.Forms.Fields.CheckBoxField).CheckBoxValue = CheckState.Off

            ''End If
            ''If ds1.Tables(0).Rows(0).Item("resmanager").ToString() = "Yes" Then
            ''    pdffield = myPDFFields.Fields("fulltimemanager")
            ''    DirectCast(pdffield, TallComponents.PDF.Forms.Fields.CheckBoxField).CheckBoxValue = CheckState.On


            ''Else
            ''    pdffield = myPDFFields.Fields("fulltimemanager")
            ''    DirectCast(pdffield, TallComponents.PDF.Forms.Fields.CheckBoxField).CheckBoxValue = CheckState.Off

            ''End If

            ''If ds1.Tables(0).Rows(0).Item("fencedpark").ToString() = "Yes" Then
            ''    pdffield = myPDFFields.Fields("fencedyes")
            ''    DirectCast(pdffield, TallComponents.PDF.Forms.Fields.CheckBoxField).CheckBoxValue = CheckState.On
            ''    pdffield = myPDFFields.Fields("fencedno")
            ''    DirectCast(pdffield, TallComponents.PDF.Forms.Fields.CheckBoxField).CheckBoxValue = CheckState.Off

            ''Else
            ''    pdffield = myPDFFields.Fields("fencedyes")
            ''    DirectCast(pdffield, TallComponents.PDF.Forms.Fields.CheckBoxField).CheckBoxValue = CheckState.Off
            ''    pdffield = myPDFFields.Fields("fencedno")
            ''    DirectCast(pdffield, TallComponents.PDF.Forms.Fields.CheckBoxField).CheckBoxValue = CheckState.On
            ''End If

            ''If ds1.Tables(0).Rows(0).Item("privateproperty").ToString() = "Yes" Then
            ''    pdffield = myPDFFields.Fields("privateyes")
            ''    DirectCast(pdffield, TallComponents.PDF.Forms.Fields.CheckBoxField).CheckBoxValue = CheckState.On
            ''    pdffield = myPDFFields.Fields("privateno")
            ''    DirectCast(pdffield, TallComponents.PDF.Forms.Fields.CheckBoxField).CheckBoxValue = CheckState.Off

            ''Else
            ''    pdffield = myPDFFields.Fields("privateyes")
            ''    DirectCast(pdffield, TallComponents.PDF.Forms.Fields.CheckBoxField).CheckBoxValue = CheckState.Off
            ''    pdffield = myPDFFields.Fields("privateno")
            ''    DirectCast(pdffield, TallComponents.PDF.Forms.Fields.CheckBoxField).CheckBoxValue = CheckState.On
            ''End If

            ''If ds1.Tables(0).Rows(0).Item("mhlot").ToString() = "Yes" Then
            ''    pdffield = myPDFFields.Fields("mobilelotyes")
            ''    DirectCast(pdffield, TallComponents.PDF.Forms.Fields.CheckBoxField).CheckBoxValue = CheckState.On
            ''    pdffield = myPDFFields.Fields("moblielotno")
            ''    DirectCast(pdffield, TallComponents.PDF.Forms.Fields.CheckBoxField).CheckBoxValue = CheckState.Off

            ''Else
            ''    pdffield = myPDFFields.Fields("mobilelotyes")
            ''    DirectCast(pdffield, TallComponents.PDF.Forms.Fields.CheckBoxField).CheckBoxValue = CheckState.Off
            ''    pdffield = myPDFFields.Fields("moblielotno")
            ''    DirectCast(pdffield, TallComponents.PDF.Forms.Fields.CheckBoxField).CheckBoxValue = CheckState.On
            ''End If


            ''pdffield = myPDFFields.Fields("numberacres")
            ''DirectCast(pdffield, TallComponents.PDF.Forms.Fields.TextField).Value = UCase(ds1.Tables(0).Rows(0).Item("Acres").ToString())



            ''pdffield = myPDFFields.Fields("workphone")
            ''DirectCast(pdffield, TallComponents.PDF.Forms.Fields.TextField).Value = UCase(ds1.Tables(0).Rows(0).Item("worknumber").ToString())

            ''pdffield = myPDFFields.Fields("mailingaddresscity")
            ''DirectCast(pdffield, TallComponents.PDF.Forms.Fields.TextField).Value = UCase(ds1.Tables(0).Rows(0).Item("DiffAppCity").ToString())
            ''pdffield = myPDFFields.Fields("mailingaddresscounty")
            ''DirectCast(pdffield, TallComponents.PDF.Forms.Fields.TextField).Value = UCase(ds1.Tables(0).Rows(0).Item("DiffAppCounty").ToString())
            ''pdffield = myPDFFields.Fields("mailingaddressstate")
            ''DirectCast(pdffield, TallComponents.PDF.Forms.Fields.TextField).Value = UCase(ds1.Tables(0).Rows(0).Item("DiffAppState").ToString())
            ''pdffield = myPDFFields.Fields("mailingaddresszip")
            ''DirectCast(pdffield, TallComponents.PDF.Forms.Fields.TextField).Value = UCase(ds1.Tables(0).Rows(0).Item("DiffAppZip").ToString())
            ''pdffield = myPDFFields.Fields("Locationaddresscity")
            ''DirectCast(pdffield, TallComponents.PDF.Forms.Fields.TextField).Value = UCase(ds1.Tables(0).Rows(0).Item("City").ToString())
            ''pdffield = myPDFFields.Fields("Locationaddresscounty")
            ''DirectCast(pdffield, TallComponents.PDF.Forms.Fields.TextField).Value = UCase(ds1.Tables(0).Rows(0).Item("County").ToString())
            ''pdffield = myPDFFields.Fields("Locationaddressstate")
            ''DirectCast(pdffield, TallComponents.PDF.Forms.Fields.TextField).Value = UCase(ds1.Tables(0).Rows(0).Item("State").ToString())
            ''pdffield = myPDFFields.Fields("Locationaddresszip")
            ''DirectCast(pdffield, TallComponents.PDF.Forms.Fields.TextField).Value = UCase(ds1.Tables(0).Rows(0).Item("Zip").ToString())
            ''pdffield = myPDFFields.Fields("effectivedate")
            ''DirectCast(pdffield, TallComponents.PDF.Forms.Fields.TextField).Value = efdate 'UCase(ds3.Tables(0).Rows(0).Item("EffDate").ToString())
            ' ''pdffield = myPDFFields.Fields("suspense2")
            ' ''DirectCast(pdffield, TallComponents.PDF.Forms.Fields.TextField).Value = UCase(ds1.Tables(0).Rows(0).Item("Name").ToString())
            ' ''pdffield = myPDFFields.Fields("policy2")
            ' ''DirectCast(pdffield, TallComponents.PDF.Forms.Fields.TextField).Value = UCase(ds1.Tables(0).Rows(0).Item("Name").ToString())
            ''pdffield = myPDFFields.Fields("dateofloss")
            ''DirectCast(pdffield, TallComponents.PDF.Forms.Fields.TextField).Value = UCase(ds1.Tables(0).Rows(0).Item("Loss1Date").ToString())
            ''pdffield = myPDFFields.Fields("ofloss")
            ''DirectCast(pdffield, TallComponents.PDF.Forms.Fields.TextField).Value = UCase(ds1.Tables(0).Rows(0).Item("Loss1Type").ToString())
            ''pdffield = myPDFFields.Fields("paid")
            ''DirectCast(pdffield, TallComponents.PDF.Forms.Fields.TextField).Value = UCase(ds1.Tables(0).Rows(0).Item("Loss1AmtPaid").ToString())
            ''pdffield = myPDFFields.Fields("dateofloss2")
            ''DirectCast(pdffield, TallComponents.PDF.Forms.Fields.TextField).Value = UCase(ds1.Tables(0).Rows(0).Item("Loss2Date").ToString())
            ''pdffield = myPDFFields.Fields("ofloss2")
            ''DirectCast(pdffield, TallComponents.PDF.Forms.Fields.TextField).Value = UCase(ds1.Tables(0).Rows(0).Item("Loss2Type").ToString())
            ''pdffield = myPDFFields.Fields("paid2")
            ''DirectCast(pdffield, TallComponents.PDF.Forms.Fields.TextField).Value = UCase(ds1.Tables(0).Rows(0).Item("Loss2AmtPaid").ToString())
            ''pdffield = myPDFFields.Fields("describeanimals")
            ''DirectCast(pdffield, TallComponents.PDF.Forms.Fields.TextField).Value = UCase(ds1.Tables(0).Rows(0).Item("AnimalType").ToString())
            ''pdffield = myPDFFields.Fields("dogbreed")
            ''DirectCast(pdffield, TallComponents.PDF.Forms.Fields.TextField).Value = UCase(ds1.Tables(0).Rows(0).Item("DogBreed").ToString())
            ''pdffield = myPDFFields.Fields("nameofcompany")
            ''DirectCast(pdffield, TallComponents.PDF.Forms.Fields.TextField).Value = UCase(ds1.Tables(0).Rows(0).Item("PriorCompany").ToString())
            ' ''pdffield = myPDFFields.Fields("reason")
            ' ''DirectCast(pdffield, TallComponents.PDF.Forms.Fields.TextField).Value = UCase(ds1.Tables(0).Rows(0).Item("Name").ToString())
            ' ''pdffield = myPDFFields.Fields("otherremarks")
            ' ''DirectCast(pdffield, TallComponents.PDF.Forms.Fields.TextField).Value = UCase(ds1.Tables(0).Rows(0).Item("Name").ToString())
            ' ''pdffield = myPDFFields.Fields("otherremarks2")
            ' ''DirectCast(pdffield, TallComponents.PDF.Forms.Fields.TextField).Value = UCase(ds1.Tables(0).Rows(0).Item("Name").ToString())
            ' ''pdffield = myPDFFields.Fields("fencearoundpool")
            ' ''DirectCast(pdffield, TallComponents.PDF.Forms.Fields.TextField).Value = UCase(ds1.Tables(0).Rows(0).Item("Name").ToString())
            ' ''pdffield = myPDFFields.Fields("height")
            ' ''DirectCast(pdffield, TallComponents.PDF.Forms.Fields.TextField).Value = UCase(ds1.Tables(0).Rows(0).Item("Name").ToString())
            ' ''pdffield = myPDFFields.Fields("selfclosingyes")
            ' ''DirectCast(pdffield, TallComponents.PDF.Forms.Fields.TextField).Value = UCase(ds1.Tables(0).Rows(0).Item("Name").ToString())
            ' ''pdffield = myPDFFields.Fields("selfclosingno")
            ' ''DirectCast(pdffield, TallComponents.PDF.Forms.Fields.TextField).Value = UCase(ds1.Tables(0).Rows(0).Item("Name").ToString())
            ' ''pdffield = myPDFFields.Fields("abovegroundyes")
            ' ''DirectCast(pdffield, TallComponents.PDF.Forms.Fields.TextField).Value = UCase(ds1.Tables(0).Rows(0).Item("Name").ToString())
            ' ''pdffield = myPDFFields.Fields("abovegroundno")
            ' ''DirectCast(pdffield, TallComponents.PDF.Forms.Fields.TextField).Value = UCase(ds1.Tables(0).Rows(0).Item("Name").ToString())
            ' ''pdffield = myPDFFields.Fields("feetyes")
            ' ''DirectCast(pdffield, TallComponents.PDF.Forms.Fields.TextField).Value = UCase(ds1.Tables(0).Rows(0).Item("Name").ToString())
            ' ''pdffield = myPDFFields.Fields("feetno")
            ' ''DirectCast(pdffield, TallComponents.PDF.Forms.Fields.TextField).Value = UCase(ds1.Tables(0).Rows(0).Item("Name").ToString())
            ' ''pdffield = myPDFFields.Fields("valuepool")
            ' ''DirectCast(pdffield, TallComponents.PDF.Forms.Fields.TextField).Value = UCase(ds1.Tables(0).Rows(0).Item("Name").ToString())
            ' '' '' ''pdffield = myPDFFields.Fields("additionalapplicants")
            ' '' '' ''DirectCast(pdffield, TallComponents.PDF.Forms.Fields.TextField).Value = UCase(ds1.Tables(0).Rows(0).Item("Name").ToString())
            ' '' '' ''pdffield = myPDFFields.Fields("subagentname")
            ' '' '' ''DirectCast(pdffield, TallComponents.PDF.Forms.Fields.TextField).Value = UCase(ds1.Tables(0).Rows(0).Item("Name").ToString())
            ' '' '' ''pdffield = myPDFFields.Fields("subagentdate")
            ' '' '' ''DirectCast(pdffield, TallComponents.PDF.Forms.Fields.TextField).Value = UCase(ds1.Tables(0).Rows(0).Item("Name").ToString())
            ' '' '' ''pdffield = myPDFFields.Fields("applicantsignature")
            ' '' '' ''DirectCast(pdffield, TallComponents.PDF.Forms.Fields.TextField).Value = UCase(ds1.Tables(0).Rows(0).Item("Name").ToString())
            ''pdffield = myPDFFields.Fields("dateinstalled")
            ''DirectCast(pdffield, TallComponents.PDF.Forms.Fields.TextField).Value = UCase(ds1.Tables(0).Rows(0).Item("stdateinstalled").ToString())
            ''pdffield = myPDFFields.Fields("installedby")
            ''DirectCast(pdffield, TallComponents.PDF.Forms.Fields.TextField).Value = UCase(ds1.Tables(0).Rows(0).Item("stinstallby").ToString())
            ''pdffield = myPDFFields.Fields("purchasecost")
            ''DirectCast(pdffield, TallComponents.PDF.Forms.Fields.TextField).Value = UCase(ds1.Tables(0).Rows(0).Item("stcost").ToString())
            ''pdffield = myPDFFields.Fields("makename")
            ''DirectCast(pdffield, TallComponents.PDF.Forms.Fields.TextField).Value = UCase(ds1.Tables(0).Rows(0).Item("stmake").ToString())
            ' ''pdffield = myPDFFields.Fields("IS WOODSTOVE EQUIPPED WITH A HEAT RECLAIMING DEVICE")
            ' ''DirectCast(pdffield, TallComponents.PDF.Forms.Fields.TextField).Value = UCase(ds1.Tables(0).Rows(0).Item("streclaim").ToString())
            ''Dim rpdffield As TallComponents.PDF.Forms.Fields.RadioButtonField
            ''If ds1.Tables(0).Rows(0).Item("streclaim").ToString() = "Yes" Then
            ''    rpdffield = myPDFFields.Fields("IS WOODSTOVE EQUIPPED WITH A HEAT RECLAIMING DEVICE")
            ''    DirectCast(rpdffield, TallComponents.PDF.Forms.Fields.RadioButtonField).RadioButtonValue = rpdffield.Options(0)

            ''ElseIf ds1.Tables(0).Rows(0).Item("streclaim").ToString() = "No" Then
            ''    rpdffield = myPDFFields.Fields("IS WOODSTOVE EQUIPPED WITH A HEAT RECLAIMING DEVICE")
            ''    DirectCast(rpdffield, TallComponents.PDF.Forms.Fields.RadioButtonField).RadioButtonValue = rpdffield.Options(1)

            ''End If
            ''Select Case ds1.Tables(0).Rows(0).Item("sttype").ToString()
            ''    Case "Radiant"
            ''        pdffield = myPDFFields.Fields("Radiant")
            ''        DirectCast(pdffield, TallComponents.PDF.Forms.Fields.CheckBoxField).CheckBoxValue = CheckState.On
            ''        pdffield = myPDFFields.Fields("C")
            ''        DirectCast(pdffield, TallComponents.PDF.Forms.Fields.CheckBoxField).CheckBoxValue = CheckState.Off
            ''        pdffield = myPDFFields.Fields("Jacketed")
            ''        DirectCast(pdffield, TallComponents.PDF.Forms.Fields.CheckBoxField).CheckBoxValue = CheckState.Off

            ''    Case "Jacketed"
            ''        pdffield = myPDFFields.Fields("Radiant")
            ''        DirectCast(pdffield, TallComponents.PDF.Forms.Fields.CheckBoxField).CheckBoxValue = CheckState.Off
            ''        pdffield = myPDFFields.Fields("C")
            ''        DirectCast(pdffield, TallComponents.PDF.Forms.Fields.CheckBoxField).CheckBoxValue = CheckState.Off
            ''        pdffield = myPDFFields.Fields("Jacketed")
            ''        DirectCast(pdffield, TallComponents.PDF.Forms.Fields.CheckBoxField).CheckBoxValue = CheckState.On
            ''    Case "Circulating"
            ''        pdffield = myPDFFields.Fields("Radiant")
            ''        DirectCast(pdffield, TallComponents.PDF.Forms.Fields.CheckBoxField).CheckBoxValue = CheckState.Off
            ''        pdffield = myPDFFields.Fields("C")
            ''        DirectCast(pdffield, TallComponents.PDF.Forms.Fields.CheckBoxField).CheckBoxValue = CheckState.On
            ''        pdffield = myPDFFields.Fields("Jacketed")
            ''        DirectCast(pdffield, TallComponents.PDF.Forms.Fields.CheckBoxField).CheckBoxValue = CheckState.Off
            ''    Case Else

            ''        pdffield = myPDFFields.Fields("Radiant")
            ''        DirectCast(pdffield, TallComponents.PDF.Forms.Fields.CheckBoxField).CheckBoxValue = CheckState.Off
            ''        pdffield = myPDFFields.Fields("C")
            ''        DirectCast(pdffield, TallComponents.PDF.Forms.Fields.CheckBoxField).CheckBoxValue = CheckState.Off
            ''        pdffield = myPDFFields.Fields("Jacketed")
            ''        DirectCast(pdffield, TallComponents.PDF.Forms.Fields.CheckBoxField).CheckBoxValue = CheckState.Off
            ''End Select

            ''Select Case ds1.Tables(0).Rows(0).Item("stuse").ToString()
            ''    Case "Primary Heat"
            ''        pdffield = myPDFFields.Fields("primaryheat")
            ''        DirectCast(pdffield, TallComponents.PDF.Forms.Fields.CheckBoxField).CheckBoxValue = CheckState.On
            ''        pdffield = myPDFFields.Fields("auxiliaryheat")
            ''        DirectCast(pdffield, TallComponents.PDF.Forms.Fields.CheckBoxField).CheckBoxValue = CheckState.Off
            ''        pdffield = myPDFFields.Fields("cooking")
            ''        DirectCast(pdffield, TallComponents.PDF.Forms.Fields.CheckBoxField).CheckBoxValue = CheckState.Off
            ''        pdffield = myPDFFields.Fields("other")
            ''        DirectCast(pdffield, TallComponents.PDF.Forms.Fields.CheckBoxField).CheckBoxValue = CheckState.Off

            ''    Case "Auxiliary Heat"
            ''        pdffield = myPDFFields.Fields("primaryheat")
            ''        DirectCast(pdffield, TallComponents.PDF.Forms.Fields.CheckBoxField).CheckBoxValue = CheckState.Off
            ''        pdffield = myPDFFields.Fields("auxiliaryheat")
            ''        DirectCast(pdffield, TallComponents.PDF.Forms.Fields.CheckBoxField).CheckBoxValue = CheckState.On
            ''        pdffield = myPDFFields.Fields("cooking")
            ''        DirectCast(pdffield, TallComponents.PDF.Forms.Fields.CheckBoxField).CheckBoxValue = CheckState.Off
            ''        pdffield = myPDFFields.Fields("other")
            ''        DirectCast(pdffield, TallComponents.PDF.Forms.Fields.CheckBoxField).CheckBoxValue = CheckState.Off
            ''    Case "Cooking"
            ''        pdffield = myPDFFields.Fields("primaryheat")
            ''        DirectCast(pdffield, TallComponents.PDF.Forms.Fields.CheckBoxField).CheckBoxValue = CheckState.Off
            ''        pdffield = myPDFFields.Fields("auxiliaryheat")
            ''        DirectCast(pdffield, TallComponents.PDF.Forms.Fields.CheckBoxField).CheckBoxValue = CheckState.Off
            ''        pdffield = myPDFFields.Fields("cooking")
            ''        DirectCast(pdffield, TallComponents.PDF.Forms.Fields.CheckBoxField).CheckBoxValue = CheckState.On
            ''        pdffield = myPDFFields.Fields("other")
            ''        DirectCast(pdffield, TallComponents.PDF.Forms.Fields.CheckBoxField).CheckBoxValue = CheckState.Off
            ''    Case "Other"

            ''        pdffield = myPDFFields.Fields("primaryheat")
            ''        DirectCast(pdffield, TallComponents.PDF.Forms.Fields.CheckBoxField).CheckBoxValue = CheckState.Off
            ''        pdffield = myPDFFields.Fields("auxiliaryheat")
            ''        DirectCast(pdffield, TallComponents.PDF.Forms.Fields.CheckBoxField).CheckBoxValue = CheckState.Off
            ''        pdffield = myPDFFields.Fields("cooking")
            ''        DirectCast(pdffield, TallComponents.PDF.Forms.Fields.CheckBoxField).CheckBoxValue = CheckState.Off
            ''        pdffield = myPDFFields.Fields("other")
            ''        DirectCast(pdffield, TallComponents.PDF.Forms.Fields.CheckBoxField).CheckBoxValue = CheckState.On
            ''        'pdffield = myPDFFields.Fields("specify")
            ''        'DirectCast(pdffield, TallComponents.PDF.Forms.Fields.TextField).Value = UCase(ds1.Tables(0).Rows(0).Item("Name").ToString())
            ''    Case Else

            ''        pdffield = myPDFFields.Fields("primaryheat")
            ''        DirectCast(pdffield, TallComponents.PDF.Forms.Fields.CheckBoxField).CheckBoxValue = CheckState.Off
            ''        pdffield = myPDFFields.Fields("auxiliaryheat")
            ''        DirectCast(pdffield, TallComponents.PDF.Forms.Fields.CheckBoxField).CheckBoxValue = CheckState.Off
            ''        pdffield = myPDFFields.Fields("cooking")
            ''        DirectCast(pdffield, TallComponents.PDF.Forms.Fields.CheckBoxField).CheckBoxValue = CheckState.Off
            ''        pdffield = myPDFFields.Fields("other")
            ''        DirectCast(pdffield, TallComponents.PDF.Forms.Fields.CheckBoxField).CheckBoxValue = CheckState.Off
            ''End Select




            ''pdffield = myPDFFields.Fields("typeoffuel")
            ''DirectCast(pdffield, TallComponents.PDF.Forms.Fields.TextField).Value = UCase(ds1.Tables(0).Rows(0).Item("stfuel").ToString())

            ''pdffield = myPDFFields.Fields("howoftencleaned")
            ''DirectCast(pdffield, TallComponents.PDF.Forms.Fields.TextField).Value = UCase(ds1.Tables(0).Rows(0).Item("stclean").ToString())
            ''pdffield = myPDFFields.Fields("lastcleaned")
            ''DirectCast(pdffield, TallComponents.PDF.Forms.Fields.TextField).Value = UCase(ds1.Tables(0).Rows(0).Item("stlastclean").ToString())
            ''pdffield = myPDFFields.Fields("bywhom")
            ''DirectCast(pdffield, TallComponents.PDF.Forms.Fields.TextField).Value = UCase(ds1.Tables(0).Rows(0).Item("stcleanby").ToString())
            ''pdffield = myPDFFields.Fields("installationinformation")
            ''DirectCast(pdffield, TallComponents.PDF.Forms.Fields.TextField).Value = UCase(ds1.Tables(0).Rows(0).Item("stlocation").ToString())

            ''If ds1.Tables(0).Rows(0).Item("stsmokedet").ToString() = "Yes" Then
            ''    pdffield = myPDFFields.Fields("smokedetectoryes")
            ''    DirectCast(pdffield, TallComponents.PDF.Forms.Fields.CheckBoxField).CheckBoxValue = CheckState.On
            ''    pdffield = myPDFFields.Fields("IS THERE A SMOKE DETECTOR IN THIS ROOM")
            ''    DirectCast(pdffield, TallComponents.PDF.Forms.Fields.CheckBoxField).CheckBoxValue = CheckState.Off

            ''Else
            ''    pdffield = myPDFFields.Fields("smokedetectoryes")
            ''    DirectCast(pdffield, TallComponents.PDF.Forms.Fields.CheckBoxField).CheckBoxValue = CheckState.Off
            ''    pdffield = myPDFFields.Fields("IS THERE A SMOKE DETECTOR IN THIS ROOM")
            ''    DirectCast(pdffield, TallComponents.PDF.Forms.Fields.CheckBoxField).CheckBoxValue = CheckState.On
            ''End If

            ''If ds1.Tables(0).Rows(0).Item("stfloorprot").ToString() = "Asbestos Millboard Covered with Metal" Then
            ''    pdffield = myPDFFields.Fields("asbestosmillboard")
            ''    DirectCast(pdffield, TallComponents.PDF.Forms.Fields.CheckBoxField).CheckBoxValue = CheckState.On

            ''ElseIf ds1.Tables(0).Rows(0).Item("stfloorprot").ToString() = "Metal" Then
            ''    pdffield = myPDFFields.Fields("Metal")
            ''    DirectCast(pdffield, TallComponents.PDF.Forms.Fields.CheckBoxField).CheckBoxValue = CheckState.On
            ''ElseIf ds1.Tables(0).Rows(0).Item("stfloorprot").ToString() = "Stone/Brick" Then
            ''    pdffield = myPDFFields.Fields("Stone")
            ''    DirectCast(pdffield, TallComponents.PDF.Forms.Fields.CheckBoxField).CheckBoxValue = CheckState.On
            ''Else
            ''    pdffield = myPDFFields.Fields("otherfloor")
            ''    DirectCast(pdffield, TallComponents.PDF.Forms.Fields.CheckBoxField).CheckBoxValue = CheckState.On
            ''    pdffield = myPDFFields.Fields("floorothertext")
            ''    DirectCast(pdffield, TallComponents.PDF.Forms.Fields.TextField).Value = UCase(ds1.Tables(0).Rows(0).Item("stfloorprot").ToString())
            ''End If

            ''If ds1.Tables(0).Rows(0).Item("stwallprot").ToString() = "Asbestos Millboard Covered with Metal" Then
            ''    pdffield = myPDFFields.Fields("wallasbestosmillboard")
            ''    DirectCast(pdffield, TallComponents.PDF.Forms.Fields.CheckBoxField).CheckBoxValue = CheckState.On

            ''ElseIf ds1.Tables(0).Rows(0).Item("stwallprot").ToString() = "Metal" Then
            ''    pdffield = myPDFFields.Fields("metalwall")
            ''    DirectCast(pdffield, TallComponents.PDF.Forms.Fields.CheckBoxField).CheckBoxValue = CheckState.On

            ''ElseIf ds1.Tables(0).Rows(0).Item("stwallprot").ToString() = "Asbestos Millboard" Then
            ''    pdffield = myPDFFields.Fields("asbestosmillboardwall")
            ''    DirectCast(pdffield, TallComponents.PDF.Forms.Fields.CheckBoxField).CheckBoxValue = CheckState.On
            ''Else
            ''    pdffield = myPDFFields.Fields("otherwall")
            ''    DirectCast(pdffield, TallComponents.PDF.Forms.Fields.CheckBoxField).CheckBoxValue = CheckState.On
            ''    pdffield = myPDFFields.Fields("wallprotection")
            ''    DirectCast(pdffield, TallComponents.PDF.Forms.Fields.TextField).Value = UCase(ds1.Tables(0).Rows(0).Item("stwallprot").ToString())
            ''End If

            ''If ds1.Tables(0).Rows(0).Item("stwallnone").ToString() = "Yes" Then
            ''    pdffield = myPDFFields.Fields("noneyes")
            ''    DirectCast(pdffield, TallComponents.PDF.Forms.Fields.CheckBoxField).CheckBoxValue = CheckState.On
            ''    pdffield = myPDFFields.Fields("noneno")
            ''    DirectCast(pdffield, TallComponents.PDF.Forms.Fields.CheckBoxField).CheckBoxValue = CheckState.Off

            ''Else
            ''    pdffield = myPDFFields.Fields("noneyes")
            ''    DirectCast(pdffield, TallComponents.PDF.Forms.Fields.CheckBoxField).CheckBoxValue = CheckState.Off
            ''    pdffield = myPDFFields.Fields("noneno")
            ''    DirectCast(pdffield, TallComponents.PDF.Forms.Fields.CheckBoxField).CheckBoxValue = CheckState.On
            ''End If


            ''If ds1.Tables(0).Rows(0).Item("stchimneytype").ToString() = "Factory Chimney" Then
            ''    pdffield = myPDFFields.Fields("factorychimney")
            ''    DirectCast(pdffield, TallComponents.PDF.Forms.Fields.CheckBoxField).CheckBoxValue = CheckState.On

            ''ElseIf ds1.Tables(0).Rows(0).Item("stchimneytype").ToString() = "Masonry" Then
            ''    pdffield = myPDFFields.Fields("masonry")
            ''    DirectCast(pdffield, TallComponents.PDF.Forms.Fields.CheckBoxField).CheckBoxValue = CheckState.On

            ''Else
            ''    pdffield = myPDFFields.Fields("otherchimney")
            ''    DirectCast(pdffield, TallComponents.PDF.Forms.Fields.CheckBoxField).CheckBoxValue = CheckState.On
            ''    pdffield = myPDFFields.Fields("chimneytype")
            ''    DirectCast(pdffield, TallComponents.PDF.Forms.Fields.TextField).Value = UCase(ds1.Tables(0).Rows(0).Item("stchimneytype").ToString())
            ''End If




            ''pdffield = myPDFFields.Fields("spacebetween")
            ''DirectCast(pdffield, TallComponents.PDF.Forms.Fields.TextField).Value = UCase(ds1.Tables(0).Rows(0).Item("stairprot").ToString())
            ' ''pdffield = myPDFFields.Fields("nearestwall")
            ' ''DirectCast(pdffield, TallComponents.PDF.Forms.Fields.TextField).Value = UCase(ds1.Tables(0).Rows(0).Item("Name").ToString())
            ' ''pdffield = myPDFFields.Fields("rearunit")
            ' ''DirectCast(pdffield, TallComponents.PDF.Forms.Fields.TextField).Value = UCase(ds1.Tables(0).Rows(0).Item("Name").ToString())
            ' ''pdffield = myPDFFields.Fields("topstove")
            ' ''DirectCast(pdffield, TallComponents.PDF.Forms.Fields.TextField).Value = UCase(ds1.Tables(0).Rows(0).Item("Name").ToString())
            ''pdffield = myPDFFields.Fields("sideinches")
            ''DirectCast(pdffield, TallComponents.PDF.Forms.Fields.TextField).Value = UCase(ds1.Tables(0).Rows(0).Item("st1").ToString())
            ''pdffield = myPDFFields.Fields("rearinches")
            ''DirectCast(pdffield, TallComponents.PDF.Forms.Fields.TextField).Value = UCase(ds1.Tables(0).Rows(0).Item("st2").ToString())
            ''pdffield = myPDFFields.Fields("topinches")
            ''DirectCast(pdffield, TallComponents.PDF.Forms.Fields.TextField).Value = UCase(ds1.Tables(0).Rows(0).Item("st3").ToString())
            ''pdffield = myPDFFields.Fields("bottominches")
            ''DirectCast(pdffield, TallComponents.PDF.Forms.Fields.TextField).Value = UCase(ds1.Tables(0).Rows(0).Item("st4").ToString())
            ' ''pdffield = myPDFFields.Fields("bottomunit")
            ' ''DirectCast(pdffield, TallComponents.PDF.Forms.Fields.TextField).Value = UCase(ds1.Tables(0).Rows(0).Item("Name").ToString())
            ''pdffield = myPDFFields.Fields("frontinches")
            ''DirectCast(pdffield, TallComponents.PDF.Forms.Fields.TextField).Value = UCase(ds1.Tables(0).Rows(0).Item("st5").ToString())
            ' ''pdffield = myPDFFields.Fields("pipeused")
            ' ''DirectCast(pdffield, TallComponents.PDF.Forms.Fields.TextField).Value = UCase(ds1.Tables(0).Rows(0).Item("Name").ToString())
            ''pdffield = myPDFFields.Fields("pipeinches")
            ''DirectCast(pdffield, TallComponents.PDF.Forms.Fields.TextField).Value = UCase(ds1.Tables(0).Rows(0).Item("st6").ToString())
            ''pdffield = myPDFFields.Fields("thimbleinches")
            ''DirectCast(pdffield, TallComponents.PDF.Forms.Fields.TextField).Value = UCase(ds1.Tables(0).Rows(0).Item("st7").ToString())
            ' ''pdffield = myPDFFields.Fields("sizethimble")
            ' ''DirectCast(pdffield, TallComponents.PDF.Forms.Fields.TextField).Value = UCase(ds1.Tables(0).Rows(0).Item("Name").ToString())

            ''If ds1.Tables(0).Rows(0).Item("stcomply").ToString() = "Yes" Then
            ''    pdffield = myPDFFields.Fields("standardsyes")
            ''    DirectCast(pdffield, TallComponents.PDF.Forms.Fields.CheckBoxField).CheckBoxValue = CheckState.On
            ''    pdffield = myPDFFields.Fields("standardsno")
            ''    DirectCast(pdffield, TallComponents.PDF.Forms.Fields.CheckBoxField).CheckBoxValue = CheckState.Off

            ''Else
            ''    pdffield = myPDFFields.Fields("standardsyes")
            ''    DirectCast(pdffield, TallComponents.PDF.Forms.Fields.CheckBoxField).CheckBoxValue = CheckState.Off
            ''    pdffield = myPDFFields.Fields("standardsno")
            ''    DirectCast(pdffield, TallComponents.PDF.Forms.Fields.CheckBoxField).CheckBoxValue = CheckState.On
            ''End If


            ''pdffield = myPDFFields.Fields("REMARKS")
            ''DirectCast(pdffield, TallComponents.PDF.Forms.Fields.TextField).Value = UCase(ds1.Tables(0).Rows(0).Item("stremarks").ToString())



            ''pdffield = myPDFFields.Fields("howmany")
            ''DirectCast(pdffield, TallComponents.PDF.Forms.Fields.TextField).Value = UCase(ds1.Tables(0).Rows(0).Item("animalcount").ToString())
            ''pdffield = myPDFFields.Fields("petorguard")
            ''DirectCast(pdffield, TallComponents.PDF.Forms.Fields.TextField).Value = UCase(ds1.Tables(0).Rows(0).Item("animaltype").ToString())

            For Each field As TallComponents.PDF.Forms.Fields.Field In myPDFFields.Fields
                For Each widget As Widget In field.Widgets
                    widget.Persistency = WidgetPersistency.Flatten
                Next
            Next
            myOutputPDF.Pages.AddRange(myPDFFields.Pages.CloneToArray)


            Response.ContentType = "application/pdf"
            'form.Write(New BinaryWriter(Response.OutputStream))

            myOutputPDF.Write(New BinaryWriter(Response.OutputStream))
            myFileStream.Close()



        Catch ex As Exception

        End Try






    End Sub
End Class