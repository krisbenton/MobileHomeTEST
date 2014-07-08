Imports System.Data.SqlClient
Imports System.IO

Imports TallComponents.PDF.JavaScript
Imports TallComponents.PDF.Annotations.Widgets
Imports TallComponents.PDF.Forms.Fields
Public Class VintageAegisApplicationPrint
    Inherits System.Web.UI.Page

    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        Dim AppID As String
        Dim quoteid As String
        If Request.QueryString("AppID") <> "" Then
            AppID = Request.QueryString("AppID")
            Dim ds1 As System.Data.DataSet
            Dim ds2 As System.Data.DataSet
            Dim ds3 As System.Data.DataSet

            ds1 = Common.runQueryDS("SELECT * FROM tblAegisApplication WHERE ApplicationID = '" & AppID & "'")
            If ds1.Tables(0).Rows.Count > 0 Then
                quoteid = ds1.Tables(0).Rows(0).Item("quoteID").ToString()
                ds2 = Common.runQueryDS("select * from dbo.tblAegisQuotes as a inner join dbo.tblQuotes as b on b.QuoteID = a.Quoteid where a.quoteid ='" & quoteid & "'")
                ds3 = Common.runQueryDS("SELECT * FROM tblQuotes q LEFT JOIN (SELECT DISTINCT AgencyID,AgencyCode,AgencyName,Address1 AS AgentAddr1, Address2 AS AgentAddr2,City AS AgentCity,State AS AgentState,Zip AS AgentZip, Phone AS AgentPhone,Fax,agentname FROM wrwpaqbx_ColonialWeb.wrwpaqbx_admin.vwAgents)vwag ON q.agencyName = vwag.AgencyName and q.agentname = vwag.agentname WHERE QuoteID = '" & quoteid & "'")
                PrintApplication(ds1, ds2, ds3)
            End If


        End If
    End Sub
    Public Sub PrintApplication(ByVal ds1 As System.Data.DataSet, ByVal ds2 As System.Data.DataSet, ByVal ds3 As System.Data.DataSet)

        Dim myFileStream As FileStream
        Dim mySourcePDF As TallComponents.PDF.Document
        Dim myOutputPDF As TallComponents.PDF.Document
        Dim myPDFFields As New TallComponents.PDF.Document
        Dim strPDFFieldName As String = ""
        Dim value As String


        Try
            myOutputPDF = New TallComponents.PDF.Document

            myFileStream = New FileStream(Me.MapPath("~\ApplicationPages\") & "PDF\AegisVintage2014.pdf", FileMode.Open, FileAccess.Read)
            'Dim form As New TallComponents.PDF.Document(myFileStream)
            mySourcePDF = New TallComponents.PDF.Document(myFileStream)
            myPDFFields.Pages.AddRange(mySourcePDF.Pages.CloneToArray())
            '  Dim form As New TallComponents.PDF.Document(myFileStream)

            myFileStream.Close()
            mySourcePDF = Nothing


            'Dim Policytext As New TallComponents.PDF.Forms.Fields.TextField("Policy")
            ''TryCast(form.Fields("Policy"), TextField).Value = "Testing"
            Dim pdffield As TallComponents.PDF.Forms.Fields.Field
            Dim efdate As Date = ds2.Tables(0).Rows(0).Item("effDate").ToString()
            Dim enddat As Date = efdate.AddYears(1)
            pdffield = myPDFFields.Fields("REQUESTED EFFECTIVE DATE")
            DirectCast(pdffield, TallComponents.PDF.Forms.Fields.TextField).Value = efdate.ToString("MM/dd/yyyy") 'ds2.Tables(0).Rows(0).Item("effDate").ToString()

            pdffield = myPDFFields.Fields("REQUESTED EXPIRATION DATE")
            DirectCast(pdffield, TallComponents.PDF.Forms.Fields.TextField).Value = enddat.ToString("MM/dd/yyyy") 'ds2.Tables(0).Rows(0).Item("effDate").ToString()



            pdffield = myPDFFields.Fields("ApllicantsName")
            DirectCast(pdffield, TallComponents.PDF.Forms.Fields.TextField).Value = UCase(ds1.Tables(0).Rows(0).Item("Name").ToString())


            pdffield = myPDFFields.Fields("DOB")
            DirectCast(pdffield, TallComponents.PDF.Forms.Fields.TextField).Value = ds1.Tables(0).Rows(0).Item("DOB").ToString()

            pdffield = myPDFFields.Fields("AppSSnum")
            DirectCast(pdffield, TallComponents.PDF.Forms.Fields.TextField).Value = UCase("XXX-XX-" & ds1.Tables(0).Rows(0).Item("SSN").ToString().Substring(5, 4)) ' ds1.Tables(0).Rows(0).Item("SSN").ToString()

            pdffield = myPDFFields.Fields("Phone")
            DirectCast(pdffield, TallComponents.PDF.Forms.Fields.TextField).Value = ds1.Tables(0).Rows(0).Item("Phone").ToString()

            pdffield = myPDFFields.Fields("CoApllicantsName")
            DirectCast(pdffield, TallComponents.PDF.Forms.Fields.TextField).Value = UCase(ds1.Tables(0).Rows(0).Item("COName").ToString())

            pdffield = myPDFFields.Fields("CoDOB")
            DirectCast(pdffield, TallComponents.PDF.Forms.Fields.TextField).Value = ds1.Tables(0).Rows(0).Item("CODOB").ToString()
            If ds1.Tables(0).Rows(0).Item("COSSN").ToString() <> "" Then


                pdffield = myPDFFields.Fields("CoAppSSnum")
                DirectCast(pdffield, TallComponents.PDF.Forms.Fields.TextField).Value = UCase("XXX-XX-" & ds1.Tables(0).Rows(0).Item("COSSN").ToString().Substring(5, 4)) 'ds1.Tables(0).Rows(0).Item("COSSN").ToString()
            End If
            pdffield = myPDFFields.Fields("CoPhone")
            DirectCast(pdffield, TallComponents.PDF.Forms.Fields.TextField).Value = ds1.Tables(0).Rows(0).Item("COPhone").ToString()

            pdffield = myPDFFields.Fields("MAILING ADDRESS")
            DirectCast(pdffield, TallComponents.PDF.Forms.Fields.TextField).Value = UCase(ds1.Tables(0).Rows(0).Item("DiffAppAddr").ToString())

            pdffield = myPDFFields.Fields("MailCity")
            DirectCast(pdffield, TallComponents.PDF.Forms.Fields.TextField).Value = UCase(ds1.Tables(0).Rows(0).Item("DiffAppCity").ToString())

            pdffield = myPDFFields.Fields("MailState")
            DirectCast(pdffield, TallComponents.PDF.Forms.Fields.TextField).Value = UCase(ds1.Tables(0).Rows(0).Item("DiffAppState").ToString())

            pdffield = myPDFFields.Fields("MailZip")
            DirectCast(pdffield, TallComponents.PDF.Forms.Fields.TextField).Value = ds1.Tables(0).Rows(0).Item("DiffAppZip").ToString()

            pdffield = myPDFFields.Fields("MailCounty")
            DirectCast(pdffield, TallComponents.PDF.Forms.Fields.TextField).Value = UCase(ds1.Tables(0).Rows(0).Item("DiffAppCounty").ToString())

            pdffield = myPDFFields.Fields("LOCATION OF HOME IF DIFFERENT FROM MAILING ADDRESS")
            DirectCast(pdffield, TallComponents.PDF.Forms.Fields.TextField).Value = UCase(ds1.Tables(0).Rows(0).Item("Address").ToString()) & "     " & UCase(ds1.Tables(0).Rows(0).Item("City").ToString()) & ",   " & UCase(ds1.Tables(0).Rows(0).Item("State").ToString()) & "   " & UCase(ds1.Tables(0).Rows(0).Item("Zip").ToString())
            'pdffield = myPDFFields.Fields("city")
            'DirectCast(pdffield, TallComponents.PDF.Forms.Fields.TextField).Value = UCase(ds1.Tables(0).Rows(0).Item("City").ToString())

            'pdffield = myPDFFields.Fields("state")
            'DirectCast(pdffield, TallComponents.PDF.Forms.Fields.TextField).Value = UCase(ds1.Tables(0).Rows(0).Item("State").ToString())

            'pdffield = myPDFFields.Fields("zipcode")
            'DirectCast(pdffield, TallComponents.PDF.Forms.Fields.TextField).Value = ds1.Tables(0).Rows(0).Item("Zip").ToString()

            'pdffield = myPDFFields.Fields("county")
            'DirectCast(pdffield, TallComponents.PDF.Forms.Fields.TextField).Value = UCase(ds1.Tables(0).Rows(0).Item("County").ToString())

            pdffield = myPDFFields.Fields("ADDITIONAL INSUREDS NAME AND ADDRESS name on title but not living in the home")
            DirectCast(pdffield, TallComponents.PDF.Forms.Fields.TextField).Value = UCase(ds1.Tables(0).Rows(0).Item("AddInsuredName").ToString()) & "       " & UCase(ds1.Tables(0).Rows(0).Item("AddInsuredAddress").ToString()) & "    " & UCase(ds1.Tables(0).Rows(0).Item("AddInsuredCity").ToString()) & ",   " & UCase(ds1.Tables(0).Rows(0).Item("AddInsuredState").ToString()) & "    " & UCase(ds1.Tables(0).Rows(0).Item("AddInsuredState").ToString())

            'pdffield = myPDFFields.Fields("mailingaddressadd")
            'DirectCast(pdffield, TallComponents.PDF.Forms.Fields.TextField).Value = UCase(ds1.Tables(0).Rows(0).Item("AddInsuredAddress").ToString())

            'pdffield = myPDFFields.Fields("cityadd")
            'DirectCast(pdffield, TallComponents.PDF.Forms.Fields.TextField).Value = UCase(ds1.Tables(0).Rows(0).Item("AddInsuredCity").ToString())

            'pdffield = myPDFFields.Fields("stateadd")
            'DirectCast(pdffield, TallComponents.PDF.Forms.Fields.TextField).Value = UCase(ds1.Tables(0).Rows(0).Item("AddInsuredState").ToString())

            'pdffield = myPDFFields.Fields("zipcodeadd")
            'DirectCast(pdffield, TallComponents.PDF.Forms.Fields.TextField).Value = ds1.Tables(0).Rows(0).Item("AddInsuredZip").ToString()

            pdffield = myPDFFields.Fields("Lien")
            DirectCast(pdffield, TallComponents.PDF.Forms.Fields.TextField).Value = UCase(ds1.Tables(0).Rows(0).Item("Lien1Name").ToString())

            pdffield = myPDFFields.Fields("LienNumber")
            DirectCast(pdffield, TallComponents.PDF.Forms.Fields.TextField).Value = UCase(ds1.Tables(0).Rows(0).Item("Lien1Num").ToString())

            pdffield = myPDFFields.Fields("MORTGAGEES MAILING ADDRESS")
            DirectCast(pdffield, TallComponents.PDF.Forms.Fields.TextField).Value = UCase(ds1.Tables(0).Rows(0).Item("Lien1Addr").ToString()) & "    " & UCase(ds1.Tables(0).Rows(0).Item("Lien1City").ToString()) & ",     " & UCase(ds1.Tables(0).Rows(0).Item("Lien1state").ToString()) & "     " & ds1.Tables(0).Rows(0).Item("Lien1Zip").ToString()

            ''pdffield = myPDFFields.Fields("holdercity")
            ''DirectCast(pdffield, TallComponents.PDF.Forms.Fields.TextField).Value = UCase(ds1.Tables(0).Rows(0).Item("Lien1City").ToString())

            ''pdffield = myPDFFields.Fields("holderstate")
            ''DirectCast(pdffield, TallComponents.PDF.Forms.Fields.TextField).Value = UCase(ds1.Tables(0).Rows(0).Item("Lien1state").ToString())

            ''pdffield = myPDFFields.Fields("holderzipcode")
            ''DirectCast(pdffield, TallComponents.PDF.Forms.Fields.TextField).Value = ds1.Tables(0).Rows(0).Item("Lien1Zip").ToString()

            pdffield = myPDFFields.Fields("Tenant Name")
            DirectCast(pdffield, TallComponents.PDF.Forms.Fields.TextField).Value = UCase(ds1.Tables(0).Rows(0).Item("RentalName").ToString())

            pdffield = myPDFFields.Fields("Year")
            DirectCast(pdffield, TallComponents.PDF.Forms.Fields.TextField).Value = ds2.Tables(0).Rows(0).Item("year").ToString()

            'pdffield = myPDFFields.Fields("length")
            'DirectCast(pdffield, TallComponents.PDF.Forms.Fields.TextField).Value = ds2.Tables(0).Rows(0).Item("length").ToString()

            'pdffield = myPDFFields.Fields("width")
            'DirectCast(pdffield, TallComponents.PDF.Forms.Fields.TextField).Value = ds2.Tables(0).Rows(0).Item("width").ToString()

            pdffield = myPDFFields.Fields("Make")
            DirectCast(pdffield, TallComponents.PDF.Forms.Fields.TextField).Value = ds2.Tables(0).Rows(0).Item("manf").ToString()

            pdffield = myPDFFields.Fields("Model")
            DirectCast(pdffield, TallComponents.PDF.Forms.Fields.TextField).Value = UCase(ds1.Tables(0).Rows(0).Item("DescModel").ToString())

            If ds1.Tables(0).Rows(0).Item("DescMHPurDate").ToString().Length = 8 Then
                pdffield = myPDFFields.Fields("Purchase Date")
                DirectCast(pdffield, TallComponents.PDF.Forms.Fields.TextField).Value = ds1.Tables(0).Rows(0).Item("DescMHPurDate").ToString().Substring(0, 2) & "/" & ds1.Tables(0).Rows(0).Item("DescMHPurDate").ToString().Substring(2, 2) & "/" & ds1.Tables(0).Rows(0).Item("DescMHPurDate").ToString().Substring(4, 4)

            End If

            pdffield = myPDFFields.Fields("Purchase Price")
            DirectCast(pdffield, TallComponents.PDF.Forms.Fields.TextField).Value = ds1.Tables(0).Rows(0).Item("DescMHPurPrice").ToString()

            'pdffield = myPDFFields.Fields("valueofland")
            'DirectCast(pdffield, TallComponents.PDF.Forms.Fields.TextField).Value = ds1.Tables(0).Rows(0).Item("LandPrice").ToString()

            pdffield = myPDFFields.Fields("Feet from Fire Hydrant")
            DirectCast(pdffield, TallComponents.PDF.Forms.Fields.TextField).Value = ds1.Tables(0).Rows(0).Item("DistToFire").ToString()

            pdffield = myPDFFields.Fields("Miles from Fire Department")
            DirectCast(pdffield, TallComponents.PDF.Forms.Fields.TextField).Value = ds1.Tables(0).Rows(0).Item("DistToFireDept").ToString()

            pdffield = myPDFFields.Fields("Protection Class")
            DirectCast(pdffield, TallComponents.PDF.Forms.Fields.TextField).Value = ds1.Tables(0).Rows(0).Item("Protection").ToString()

            'pdffield = myPDFFields.Fields("inpark")
            'If ds1.Tables(0).Rows(0).Item("ParkStatus").ToString() = "Yes" Then
            '    DirectCast(pdffield, TallComponents.PDF.Forms.Fields.TextField).Value = "Yes"
            'Else
            '    DirectCast(pdffield, TallComponents.PDF.Forms.Fields.TextField).Value = "No"
            'End If
            'pdffield = myPDFFields.Fields("outpark")
            'If ds1.Tables(0).Rows(0).Item("ParkStatus").ToString() = "Yes" Then
            '    DirectCast(pdffield, TallComponents.PDF.Forms.Fields.TextField).Value = "No"
            'Else
            '    DirectCast(pdffield, TallComponents.PDF.Forms.Fields.TextField).Value = "Yes"
            'End If

            'pdffield = myPDFFields.Fields("outpark")
            'DirectCast(pdffield, TallComponents.PDF.Forms.Fields.TextField).Value = ds1.Tables(0).Rows(0).Item("ParkStatus").ToString()


            pdffield = myPDFFields.Fields("AgencyCode")
            DirectCast(pdffield, TallComponents.PDF.Forms.Fields.TextField).Value = ds3.Tables(0).Rows(0).Item("AgencyCode").ToString()


            'pdffield = myPDFFields.Fields("spaces")
            'DirectCast(pdffield, TallComponents.PDF.Forms.Fields.TextField).Value = ds1.Tables(0).Rows(0).Item("NumOfSpaces").ToString()

            pdffield = myPDFFields.Fields("Agency Name Agency Code")
            DirectCast(pdffield, TallComponents.PDF.Forms.Fields.TextField).Value = ds2.Tables(0).Rows(0).Item("agencyName").ToString()

            'pdffield = myPDFFields.Fields("previouscarrier")
            'DirectCast(pdffield, TallComponents.PDF.Forms.Fields.TextField).Value = UCase(ds1.Tables(0).Rows(0).Item("PriorCompany").ToString())

            'pdffield = myPDFFields.Fields("occupation")
            'DirectCast(pdffield, TallComponents.PDF.Forms.Fields.TextField).Value = UCase(ds1.Tables(0).Rows(0).Item("Occ").ToString())

            'pdffield = myPDFFields.Fields("employer")
            'DirectCast(pdffield, TallComponents.PDF.Forms.Fields.TextField).Value = UCase(ds1.Tables(0).Rows(0).Item("Employer").ToString())

            'pdffield = myPDFFields.Fields("yrsemployed")
            'DirectCast(pdffield, TallComponents.PDF.Forms.Fields.TextField).Value = ds1.Tables(0).Rows(0).Item("Employeryrs").ToString()

            'pdffield = myPDFFields.Fields("whattype")
            'DirectCast(pdffield, TallComponents.PDF.Forms.Fields.TextField).Value = ds1.Tables(0).Rows(0).Item("SupHeating").ToString()

            pdffield = myPDFFields.Fields("MailTerritory")
            DirectCast(pdffield, TallComponents.PDF.Forms.Fields.TextField).Value = ds1.Tables(0).Rows(0).Item("Territory1").ToString()

            'pdffield = myPDFFields.Fields("territory")
            'DirectCast(pdffield, TallComponents.PDF.Forms.Fields.TextField).Value = ds1.Tables(0).Rows(0).Item("Territory2").ToString()

            'If ds1.Tables(0).Rows(0).Item("PriorInsExp").ToString().Length = 8 Then
            '    pdffield = myPDFFields.Fields("exprdate")
            '    DirectCast(pdffield, TallComponents.PDF.Forms.Fields.TextField).Value = ds1.Tables(0).Rows(0).Item("PriorInsExp").ToString().Substring(0, 2) & "/" & ds1.Tables(0).Rows(0).Item("PriorInsExp").ToString().Substring(2, 2) & "/" & ds1.Tables(0).Rows(0).Item("PriorInsExp").ToString().Substring(4, 4)

            'End If

            pdffield = myPDFFields.Fields("Serial Number")
            DirectCast(pdffield, TallComponents.PDF.Forms.Fields.TextField).Value = ds1.Tables(0).Rows(0).Item("DescMHSerial").ToString()

            'pdffield = myPDFFields.Fields("insurableinterest")
            'DirectCast(pdffield, TallComponents.PDF.Forms.Fields.TextField).Value = ds1.Tables(0).Rows(0).Item("deededinterest").ToString()

            'pdffield = myPDFFields.Fields("why")
            'DirectCast(pdffield, TallComponents.PDF.Forms.Fields.TextField).Value = ds1.Tables(0).Rows(0).Item("ARIng19a").ToString()

            pdffield = myPDFFields.Fields("with original manufactured home room addition deck porch etc")
            DirectCast(pdffield, TallComponents.PDF.Forms.Fields.TextField).Value = ds1.Tables(0).Rows(0).Item("DescMHAttStruc").ToString() & "  " & ds1.Tables(0).Rows(0).Item("DescMHAttStrucSize").ToString() & "  $" & ds1.Tables(0).Rows(0).Item("DescMHAttStrucCurVal").ToString() & vbCrLf & ds1.Tables(0).Rows(0).Item("DescMHUnAttStruc").ToString() & "  " & ds1.Tables(0).Rows(0).Item("DescMHUnAttStrucSize").ToString() & "  $" & ds1.Tables(0).Rows(0).Item("DescMHUnAttStrucCurVal").ToString()

            'agent info
            pdffield = myPDFFields.Fields("AgentMailing Address")
            DirectCast(pdffield, TallComponents.PDF.Forms.Fields.TextField).Value = ds3.Tables(0).Rows(0).Item("AgentAddr2").ToString()
            pdffield = myPDFFields.Fields("City State Zip Code")
            DirectCast(pdffield, TallComponents.PDF.Forms.Fields.TextField).Value = ds3.Tables(0).Rows(0).Item("AgentCity").ToString() & "                      " & ds3.Tables(0).Rows(0).Item("AgentState").ToString() & "    " & ds3.Tables(0).Rows(0).Item("AgentZip").ToString()
            'pdffield = myPDFFields.Fields("agencystate")
            'DirectCast(pdffield, TallComponents.PDF.Forms.Fields.TextField).Value = ds3.Tables(0).Rows(0).Item("AgentState").ToString()
            'pdffield = myPDFFields.Fields("agencyzipcode")
            'DirectCast(pdffield, TallComponents.PDF.Forms.Fields.TextField).Value = ds3.Tables(0).Rows(0).Item("AgentZip").ToString()
            pdffield = myPDFFields.Fields("Telephone  Fax  EMail Address")
            DirectCast(pdffield, TallComponents.PDF.Forms.Fields.TextField).Value = ds3.Tables(0).Rows(0).Item("AgentPhone").ToString()
            pdffield = myPDFFields.Fields("AgentFax")
            DirectCast(pdffield, TallComponents.PDF.Forms.Fields.TextField).Value = ds3.Tables(0).Rows(0).Item("Fax").ToString()
            pdffield = myPDFFields.Fields("Agentemail")
            DirectCast(pdffield, TallComponents.PDF.Forms.Fields.TextField).Value = ds3.Tables(0).Rows(0).Item("agentEmail").ToString()



            Select Case ds1.Tables(0).Rows(0).Item("Usage").ToString()
                Case "Owner"
                    pdffield = myPDFFields.Fields("Owner Occupied")
                    DirectCast(pdffield, TallComponents.PDF.Forms.Fields.TextField).Value = "  X  "

                    'pdffield = myPDFFields.Fields("owneroccupied")
                    'DirectCast(pdffield, TallComponents.PDF.Forms.Fields.CheckBoxField).CheckBoxValue = CheckState.On
                    'pdffield = myPDFFields.Fields("seasonal")
                    'DirectCast(pdffield, TallComponents.PDF.Forms.Fields.CheckBoxField).CheckBoxValue = CheckState.Off
                    'pdffield = myPDFFields.Fields("tenant")
                    'DirectCast(pdffield, TallComponents.PDF.Forms.Fields.CheckBoxField).CheckBoxValue = CheckState.Off
                    'pdffield = myPDFFields.Fields("rental")
                    'DirectCast(pdffield, TallComponents.PDF.Forms.Fields.CheckBoxField).CheckBoxValue = CheckState.Off
                Case "Seasonal"
                    pdffield = myPDFFields.Fields("Seasonal")
                    DirectCast(pdffield, TallComponents.PDF.Forms.Fields.TextField).Value = "  X  "

                    'pdffield = myPDFFields.Fields("owneroccupied")
                    'DirectCast(pdffield, TallComponents.PDF.Forms.Fields.CheckBoxField).CheckBoxValue = CheckState.Off
                    'pdffield = myPDFFields.Fields("seasonal")
                    'DirectCast(pdffield, TallComponents.PDF.Forms.Fields.CheckBoxField).CheckBoxValue = CheckState.On
                    'pdffield = myPDFFields.Fields("tenant")
                    'DirectCast(pdffield, TallComponents.PDF.Forms.Fields.CheckBoxField).CheckBoxValue = CheckState.Off
                    'pdffield = myPDFFields.Fields("rental")
                    'DirectCast(pdffield, TallComponents.PDF.Forms.Fields.CheckBoxField).CheckBoxValue = CheckState.Off
                Case "Rental"
                    pdffield = myPDFFields.Fields("Rental")
                    DirectCast(pdffield, TallComponents.PDF.Forms.Fields.TextField).Value = "  X  "

                    '    pdffield = myPDFFields.Fields("owneroccupied")
                    '    DirectCast(pdffield, TallComponents.PDF.Forms.Fields.CheckBoxField).CheckBoxValue = CheckState.Off
                    '    pdffield = myPDFFields.Fields("seasonal")
                    '    DirectCast(pdffield, TallComponents.PDF.Forms.Fields.CheckBoxField).CheckBoxValue = CheckState.Off
                    '    pdffield = myPDFFields.Fields("tenant")
                    '    DirectCast(pdffield, TallComponents.PDF.Forms.Fields.CheckBoxField).CheckBoxValue = CheckState.Off
                    '    pdffield = myPDFFields.Fields("rental")
                    '    DirectCast(pdffield, TallComponents.PDF.Forms.Fields.CheckBoxField).CheckBoxValue = CheckState.On
                    'Case "Tenant"
                    '    pdffield = myPDFFields.Fields("owneroccupied")
                    '    DirectCast(pdffield, TallComponents.PDF.Forms.Fields.CheckBoxField).CheckBoxValue = CheckState.Off
                    '    pdffield = myPDFFields.Fields("seasonal")
                    '    DirectCast(pdffield, TallComponents.PDF.Forms.Fields.CheckBoxField).CheckBoxValue = CheckState.Off
                    '    pdffield = myPDFFields.Fields("tenant")
                    '    DirectCast(pdffield, TallComponents.PDF.Forms.Fields.CheckBoxField).CheckBoxValue = CheckState.On
                    '    pdffield = myPDFFields.Fields("rental")
                    '    DirectCast(pdffield, TallComponents.PDF.Forms.Fields.CheckBoxField).CheckBoxValue = CheckState.Off
                    'Case Else
                    '    pdffield = myPDFFields.Fields("owneroccupied")
                    '    DirectCast(pdffield, TallComponents.PDF.Forms.Fields.CheckBoxField).CheckBoxValue = CheckState.On
                    '    pdffield = myPDFFields.Fields("seasonal")
                    '    DirectCast(pdffield, TallComponents.PDF.Forms.Fields.CheckBoxField).CheckBoxValue = CheckState.Off
                    '    pdffield = myPDFFields.Fields("tenant")
                    '    DirectCast(pdffield, TallComponents.PDF.Forms.Fields.CheckBoxField).CheckBoxValue = CheckState.Off
                    '    pdffield = myPDFFields.Fields("rental")
                    '    DirectCast(pdffield, TallComponents.PDF.Forms.Fields.CheckBoxField).CheckBoxValue = CheckState.Off

            End Select

            'If ds1.Tables(0).Rows(0).Item("ARIng1").ToString() = "Yes" Then
            '    pdffield = myPDFFields.Fields("insuredyes")
            '    DirectCast(pdffield, TallComponents.PDF.Forms.Fields.CheckBoxField).CheckBoxValue = CheckState.On
            '    pdffield = myPDFFields.Fields("insuredno")
            '    DirectCast(pdffield, TallComponents.PDF.Forms.Fields.CheckBoxField).CheckBoxValue = CheckState.Off

            'Else
            '    pdffield = myPDFFields.Fields("insuredno")
            '    DirectCast(pdffield, TallComponents.PDF.Forms.Fields.CheckBoxField).CheckBoxValue = CheckState.On
            '    pdffield = myPDFFields.Fields("insuredyes")
            '    DirectCast(pdffield, TallComponents.PDF.Forms.Fields.CheckBoxField).CheckBoxValue = CheckState.Off
            'End If


            'If ds1.Tables(0).Rows(0).Item("BillLienHold").ToString() = "Yes" Then
            '    pdffield = myPDFFields.Fields("renewalyes")
            '    DirectCast(pdffield, TallComponents.PDF.Forms.Fields.CheckBoxField).CheckBoxValue = CheckState.On
            '    pdffield = myPDFFields.Fields("renewalno")
            '    DirectCast(pdffield, TallComponents.PDF.Forms.Fields.CheckBoxField).CheckBoxValue = CheckState.Off

            'Else
            '    pdffield = myPDFFields.Fields("renewalno")
            '    DirectCast(pdffield, TallComponents.PDF.Forms.Fields.CheckBoxField).CheckBoxValue = CheckState.On
            '    pdffield = myPDFFields.Fields("renewalyes")
            '    DirectCast(pdffield, TallComponents.PDF.Forms.Fields.CheckBoxField).CheckBoxValue = CheckState.Off
            'End If




            'If ds1.Tables(0).Rows(0).Item("ARIng2").ToString() = "Yes" Then
            '    pdffield = myPDFFields.Fields("includelandyes")
            '    DirectCast(pdffield, TallComponents.PDF.Forms.Fields.CheckBoxField).CheckBoxValue = CheckState.On
            '    pdffield = myPDFFields.Fields("includelandno")
            '    DirectCast(pdffield, TallComponents.PDF.Forms.Fields.CheckBoxField).CheckBoxValue = CheckState.Off

            'Else
            '    pdffield = myPDFFields.Fields("includelandno")
            '    DirectCast(pdffield, TallComponents.PDF.Forms.Fields.CheckBoxField).CheckBoxValue = CheckState.On
            '    pdffield = myPDFFields.Fields("includelandyes")
            '    DirectCast(pdffield, TallComponents.PDF.Forms.Fields.CheckBoxField).CheckBoxValue = CheckState.Off
            'End If

            'If ds1.Tables(0).Rows(0).Item("ARIng3").ToString() = "Yes" Then
            '    pdffield = myPDFFields.Fields("vinylhardboardyes")
            '    DirectCast(pdffield, TallComponents.PDF.Forms.Fields.CheckBoxField).CheckBoxValue = CheckState.On
            '    pdffield = myPDFFields.Fields("vinylhardboardno")
            '    DirectCast(pdffield, TallComponents.PDF.Forms.Fields.CheckBoxField).CheckBoxValue = CheckState.Off

            'Else
            '    pdffield = myPDFFields.Fields("vinylhardboardno")
            '    DirectCast(pdffield, TallComponents.PDF.Forms.Fields.CheckBoxField).CheckBoxValue = CheckState.On
            '    pdffield = myPDFFields.Fields("vinylhardboardyes")
            '    DirectCast(pdffield, TallComponents.PDF.Forms.Fields.CheckBoxField).CheckBoxValue = CheckState.Off
            'End If

            'If ds1.Tables(0).Rows(0).Item("ARIng4").ToString() = "Yes" Then
            '    pdffield = myPDFFields.Fields("comproofyes")
            '    DirectCast(pdffield, TallComponents.PDF.Forms.Fields.CheckBoxField).CheckBoxValue = CheckState.On
            '    pdffield = myPDFFields.Fields("comproofno")
            '    DirectCast(pdffield, TallComponents.PDF.Forms.Fields.CheckBoxField).CheckBoxValue = CheckState.Off

            'Else
            '    pdffield = myPDFFields.Fields("comproofno")
            '    DirectCast(pdffield, TallComponents.PDF.Forms.Fields.CheckBoxField).CheckBoxValue = CheckState.On
            '    pdffield = myPDFFields.Fields("comproofyes")
            '    DirectCast(pdffield, TallComponents.PDF.Forms.Fields.CheckBoxField).CheckBoxValue = CheckState.Off
            'End If

            'If ds1.Tables(0).Rows(0).Item("ARIng5").ToString() = "Yes" Then
            '    pdffield = myPDFFields.Fields("permanentfoundyes")
            '    DirectCast(pdffield, TallComponents.PDF.Forms.Fields.CheckBoxField).CheckBoxValue = CheckState.On
            '    pdffield = myPDFFields.Fields("permanentfoundno")
            '    DirectCast(pdffield, TallComponents.PDF.Forms.Fields.CheckBoxField).CheckBoxValue = CheckState.Off

            'Else
            '    pdffield = myPDFFields.Fields("permanentfoundno")
            '    DirectCast(pdffield, TallComponents.PDF.Forms.Fields.CheckBoxField).CheckBoxValue = CheckState.On
            '    pdffield = myPDFFields.Fields("permanentfoundyes")
            '    DirectCast(pdffield, TallComponents.PDF.Forms.Fields.CheckBoxField).CheckBoxValue = CheckState.Off
            'End If

            'If ds1.Tables(0).Rows(0).Item("ARIng6").ToString() = "Yes" Then
            '    pdffield = myPDFFields.Fields("enclosedfoundyes")
            '    DirectCast(pdffield, TallComponents.PDF.Forms.Fields.CheckBoxField).CheckBoxValue = CheckState.On
            '    pdffield = myPDFFields.Fields("enclosedfoundno")
            '    DirectCast(pdffield, TallComponents.PDF.Forms.Fields.CheckBoxField).CheckBoxValue = CheckState.Off

            'Else
            '    pdffield = myPDFFields.Fields("enclosedfoundno")
            '    DirectCast(pdffield, TallComponents.PDF.Forms.Fields.CheckBoxField).CheckBoxValue = CheckState.On
            '    pdffield = myPDFFields.Fields("enclosedfoundyes")
            '    DirectCast(pdffield, TallComponents.PDF.Forms.Fields.CheckBoxField).CheckBoxValue = CheckState.Off
            'End If

            'If ds1.Tables(0).Rows(0).Item("ARIng7").ToString() = "Yes" Then
            '    pdffield = myPDFFields.Fields("skirtedyes")
            '    DirectCast(pdffield, TallComponents.PDF.Forms.Fields.CheckBoxField).CheckBoxValue = CheckState.On
            '    pdffield = myPDFFields.Fields("skirtedno")
            '    DirectCast(pdffield, TallComponents.PDF.Forms.Fields.CheckBoxField).CheckBoxValue = CheckState.Off

            'Else
            '    pdffield = myPDFFields.Fields("skirtedno")
            '    DirectCast(pdffield, TallComponents.PDF.Forms.Fields.CheckBoxField).CheckBoxValue = CheckState.On
            '    pdffield = myPDFFields.Fields("skirtedyes")
            '    DirectCast(pdffield, TallComponents.PDF.Forms.Fields.CheckBoxField).CheckBoxValue = CheckState.Off
            'End If

            'If ds1.Tables(0).Rows(0).Item("ARIng8").ToString() = "Yes" Then
            '    pdffield = myPDFFields.Fields("tieddownyes")
            '    DirectCast(pdffield, TallComponents.PDF.Forms.Fields.CheckBoxField).CheckBoxValue = CheckState.On
            '    pdffield = myPDFFields.Fields("tieddownno")
            '    DirectCast(pdffield, TallComponents.PDF.Forms.Fields.CheckBoxField).CheckBoxValue = CheckState.Off

            'Else
            '    pdffield = myPDFFields.Fields("tieddownno")
            '    DirectCast(pdffield, TallComponents.PDF.Forms.Fields.CheckBoxField).CheckBoxValue = CheckState.On
            '    pdffield = myPDFFields.Fields("tieddownyes")
            '    DirectCast(pdffield, TallComponents.PDF.Forms.Fields.CheckBoxField).CheckBoxValue = CheckState.Off
            'End If

            'If ds1.Tables(0).Rows(0).Item("ARIng9").ToString() = "Yes" Then
            '    pdffield = myPDFFields.Fields("deedowneryes")
            '    DirectCast(pdffield, TallComponents.PDF.Forms.Fields.CheckBoxField).CheckBoxValue = CheckState.On
            '    pdffield = myPDFFields.Fields("deedownerno")
            '    DirectCast(pdffield, TallComponents.PDF.Forms.Fields.CheckBoxField).CheckBoxValue = CheckState.Off

            'Else
            '    pdffield = myPDFFields.Fields("deedownerno")
            '    DirectCast(pdffield, TallComponents.PDF.Forms.Fields.CheckBoxField).CheckBoxValue = CheckState.On
            '    pdffield = myPDFFields.Fields("deedowneryes")
            '    DirectCast(pdffield, TallComponents.PDF.Forms.Fields.CheckBoxField).CheckBoxValue = CheckState.Off
            'End If

            'If ds1.Tables(0).Rows(0).Item("ARIng10").ToString() = "Yes" Then
            '    pdffield = myPDFFields.Fields("keroseneyes")
            '    DirectCast(pdffield, TallComponents.PDF.Forms.Fields.CheckBoxField).CheckBoxValue = CheckState.On
            '    pdffield = myPDFFields.Fields("keroseneno")
            '    DirectCast(pdffield, TallComponents.PDF.Forms.Fields.CheckBoxField).CheckBoxValue = CheckState.Off

            'Else
            '    pdffield = myPDFFields.Fields("keroseneno")
            '    DirectCast(pdffield, TallComponents.PDF.Forms.Fields.CheckBoxField).CheckBoxValue = CheckState.On
            '    pdffield = myPDFFields.Fields("keroseneyes")
            '    DirectCast(pdffield, TallComponents.PDF.Forms.Fields.CheckBoxField).CheckBoxValue = CheckState.Off
            'End If

            'If ds1.Tables(0).Rows(0).Item("ARIng11").ToString() = "Yes" Then
            '    pdffield = myPDFFields.Fields("withoututilitiesyes")
            '    DirectCast(pdffield, TallComponents.PDF.Forms.Fields.CheckBoxField).CheckBoxValue = CheckState.On
            '    pdffield = myPDFFields.Fields("withoututilitiesno")
            '    DirectCast(pdffield, TallComponents.PDF.Forms.Fields.CheckBoxField).CheckBoxValue = CheckState.Off

            'Else
            '    pdffield = myPDFFields.Fields("withoututilitiesno")
            '    DirectCast(pdffield, TallComponents.PDF.Forms.Fields.CheckBoxField).CheckBoxValue = CheckState.On
            '    pdffield = myPDFFields.Fields("withoututilitiesyes")
            '    DirectCast(pdffield, TallComponents.PDF.Forms.Fields.CheckBoxField).CheckBoxValue = CheckState.Off
            'End If

            'If ds1.Tables(0).Rows(0).Item("ARIng13").ToString() = "Yes" Then
            '    pdffield = myPDFFields.Fields("businessyes")
            '    DirectCast(pdffield, TallComponents.PDF.Forms.Fields.CheckBoxField).CheckBoxValue = CheckState.On
            '    pdffield = myPDFFields.Fields("businessno")
            '    DirectCast(pdffield, TallComponents.PDF.Forms.Fields.CheckBoxField).CheckBoxValue = CheckState.Off

            'Else
            '    pdffield = myPDFFields.Fields("businessno")
            '    DirectCast(pdffield, TallComponents.PDF.Forms.Fields.CheckBoxField).CheckBoxValue = CheckState.On
            '    pdffield = myPDFFields.Fields("businessyes")
            '    DirectCast(pdffield, TallComponents.PDF.Forms.Fields.CheckBoxField).CheckBoxValue = CheckState.Off
            'End If

            'If ds1.Tables(0).Rows(0).Item("ARIng14").ToString() = "Yes" Then
            '    pdffield = myPDFFields.Fields("threeyearsyes")
            '    DirectCast(pdffield, TallComponents.PDF.Forms.Fields.CheckBoxField).CheckBoxValue = CheckState.On
            '    pdffield = myPDFFields.Fields("threeyearsno")
            '    DirectCast(pdffield, TallComponents.PDF.Forms.Fields.CheckBoxField).CheckBoxValue = CheckState.Off

            'Else
            '    pdffield = myPDFFields.Fields("threeyearsno")
            '    DirectCast(pdffield, TallComponents.PDF.Forms.Fields.CheckBoxField).CheckBoxValue = CheckState.On
            '    pdffield = myPDFFields.Fields("threeyearsyes")
            '    DirectCast(pdffield, TallComponents.PDF.Forms.Fields.CheckBoxField).CheckBoxValue = CheckState.Off
            'End If

            'If ds1.Tables(0).Rows(0).Item("ARIng15").ToString() = "Yes" Then
            '    pdffield = myPDFFields.Fields("vacantyes")
            '    DirectCast(pdffield, TallComponents.PDF.Forms.Fields.CheckBoxField).CheckBoxValue = CheckState.On
            '    pdffield = myPDFFields.Fields("vacantno")
            '    DirectCast(pdffield, TallComponents.PDF.Forms.Fields.CheckBoxField).CheckBoxValue = CheckState.Off

            'Else
            '    pdffield = myPDFFields.Fields("vacantno")
            '    DirectCast(pdffield, TallComponents.PDF.Forms.Fields.CheckBoxField).CheckBoxValue = CheckState.On
            '    pdffield = myPDFFields.Fields("vacantyes")
            '    DirectCast(pdffield, TallComponents.PDF.Forms.Fields.CheckBoxField).CheckBoxValue = CheckState.Off
            'End If

            'If ds1.Tables(0).Rows(0).Item("ARIng16").ToString() = "Yes" Then
            '    pdffield = myPDFFields.Fields("renovationyes")
            '    DirectCast(pdffield, TallComponents.PDF.Forms.Fields.CheckBoxField).CheckBoxValue = CheckState.On
            '    pdffield = myPDFFields.Fields("renovationno")
            '    DirectCast(pdffield, TallComponents.PDF.Forms.Fields.CheckBoxField).CheckBoxValue = CheckState.Off

            'Else
            '    pdffield = myPDFFields.Fields("renovationno")
            '    DirectCast(pdffield, TallComponents.PDF.Forms.Fields.CheckBoxField).CheckBoxValue = CheckState.On
            '    pdffield = myPDFFields.Fields("renovationyes")
            '    DirectCast(pdffield, TallComponents.PDF.Forms.Fields.CheckBoxField).CheckBoxValue = CheckState.Off
            'End If

            'If ds1.Tables(0).Rows(0).Item("ARIng17").ToString() = "Yes" Then
            '    pdffield = myPDFFields.Fields("condemnedyes")
            '    DirectCast(pdffield, TallComponents.PDF.Forms.Fields.CheckBoxField).CheckBoxValue = CheckState.On
            '    pdffield = myPDFFields.Fields("condemnedno")
            '    DirectCast(pdffield, TallComponents.PDF.Forms.Fields.CheckBoxField).CheckBoxValue = CheckState.Off

            'Else
            '    pdffield = myPDFFields.Fields("condemnedno")
            '    DirectCast(pdffield, TallComponents.PDF.Forms.Fields.CheckBoxField).CheckBoxValue = CheckState.On
            '    pdffield = myPDFFields.Fields("condemnedyes")
            '    DirectCast(pdffield, TallComponents.PDF.Forms.Fields.CheckBoxField).CheckBoxValue = CheckState.Off
            'End If

            'If ds1.Tables(0).Rows(0).Item("ARIng18").ToString() = "Yes" Then
            '    pdffield = myPDFFields.Fields("studentyes")
            '    DirectCast(pdffield, TallComponents.PDF.Forms.Fields.CheckBoxField).CheckBoxValue = CheckState.On
            '    pdffield = myPDFFields.Fields("studentno")
            '    DirectCast(pdffield, TallComponents.PDF.Forms.Fields.CheckBoxField).CheckBoxValue = CheckState.Off

            'Else
            '    pdffield = myPDFFields.Fields("studentno")
            '    DirectCast(pdffield, TallComponents.PDF.Forms.Fields.CheckBoxField).CheckBoxValue = CheckState.On
            '    pdffield = myPDFFields.Fields("studentyes")
            '    DirectCast(pdffield, TallComponents.PDF.Forms.Fields.CheckBoxField).CheckBoxValue = CheckState.Off
            'End If

            'If ds1.Tables(0).Rows(0).Item("ARIng19").ToString() = "Yes" Then
            '    pdffield = myPDFFields.Fields("cancelledyes")
            '    DirectCast(pdffield, TallComponents.PDF.Forms.Fields.CheckBoxField).CheckBoxValue = CheckState.On
            '    pdffield = myPDFFields.Fields("cancelledno")
            '    DirectCast(pdffield, TallComponents.PDF.Forms.Fields.CheckBoxField).CheckBoxValue = CheckState.Off

            'Else
            '    pdffield = myPDFFields.Fields("cancelledno")
            '    DirectCast(pdffield, TallComponents.PDF.Forms.Fields.CheckBoxField).CheckBoxValue = CheckState.On
            '    pdffield = myPDFFields.Fields("cancelledyes")
            '    DirectCast(pdffield, TallComponents.PDF.Forms.Fields.CheckBoxField).CheckBoxValue = CheckState.Off
            'End If

            'If ds1.Tables(0).Rows(0).Item("ARIng19a").ToString() = "Yes" Then
            '    pdffield = myPDFFields.Fields("failedyes")
            '    DirectCast(pdffield, TallComponents.PDF.Forms.Fields.CheckBoxField).CheckBoxValue = CheckState.On
            '    pdffield = myPDFFields.Fields("failedno")
            '    DirectCast(pdffield, TallComponents.PDF.Forms.Fields.CheckBoxField).CheckBoxValue = CheckState.Off

            'Else
            '    pdffield = myPDFFields.Fields("failedno")
            '    DirectCast(pdffield, TallComponents.PDF.Forms.Fields.CheckBoxField).CheckBoxValue = CheckState.On
            '    pdffield = myPDFFields.Fields("failedyes")
            '    DirectCast(pdffield, TallComponents.PDF.Forms.Fields.CheckBoxField).CheckBoxValue = CheckState.Off
            'End If

            'If ds1.Tables(0).Rows(0).Item("ARIng21").ToString() = "Yes" Then
            '    pdffield = myPDFFields.Fields("suppheatyes")
            '    DirectCast(pdffield, TallComponents.PDF.Forms.Fields.CheckBoxField).CheckBoxValue = CheckState.On
            '    pdffield = myPDFFields.Fields("suppheatno")
            '    DirectCast(pdffield, TallComponents.PDF.Forms.Fields.CheckBoxField).CheckBoxValue = CheckState.Off

            'Else
            '    pdffield = myPDFFields.Fields("suppheatno")
            '    DirectCast(pdffield, TallComponents.PDF.Forms.Fields.CheckBoxField).CheckBoxValue = CheckState.On
            '    pdffield = myPDFFields.Fields("suppheatyes")
            '    DirectCast(pdffield, TallComponents.PDF.Forms.Fields.CheckBoxField).CheckBoxValue = CheckState.Off
            'End If

            'If ds1.Tables(0).Rows(0).Item("ARIng21a").ToString() = "Yes" Then
            '    pdffield = myPDFFields.Fields("woodstoveyes")
            '    DirectCast(pdffield, TallComponents.PDF.Forms.Fields.CheckBoxField).CheckBoxValue = CheckState.On
            '    pdffield = myPDFFields.Fields("woodstoveno")
            '    DirectCast(pdffield, TallComponents.PDF.Forms.Fields.CheckBoxField).CheckBoxValue = CheckState.Off

            'Else
            '    pdffield = myPDFFields.Fields("woodstoveno")
            '    DirectCast(pdffield, TallComponents.PDF.Forms.Fields.CheckBoxField).CheckBoxValue = CheckState.On
            '    pdffield = myPDFFields.Fields("woodstoveyes")
            '    DirectCast(pdffield, TallComponents.PDF.Forms.Fields.CheckBoxField).CheckBoxValue = CheckState.Off
            'End If

            'If ds1.Tables(0).Rows(0).Item("ARIng22").ToString() = "Yes" Then
            '    pdffield = myPDFFields.Fields("animalyes")
            '    DirectCast(pdffield, TallComponents.PDF.Forms.Fields.CheckBoxField).CheckBoxValue = CheckState.On
            '    pdffield = myPDFFields.Fields("animalno")
            '    DirectCast(pdffield, TallComponents.PDF.Forms.Fields.CheckBoxField).CheckBoxValue = CheckState.Off

            'Else
            '    pdffield = myPDFFields.Fields("animalno")
            '    DirectCast(pdffield, TallComponents.PDF.Forms.Fields.CheckBoxField).CheckBoxValue = CheckState.On
            '    pdffield = myPDFFields.Fields("animalyes")
            '    DirectCast(pdffield, TallComponents.PDF.Forms.Fields.CheckBoxField).CheckBoxValue = CheckState.Off
            'End If

            'If ds1.Tables(0).Rows(0).Item("ARIng23").ToString() = "Yes" Then
            '    pdffield = myPDFFields.Fields("unusualyes")
            '    DirectCast(pdffield, TallComponents.PDF.Forms.Fields.CheckBoxField).CheckBoxValue = CheckState.On
            '    pdffield = myPDFFields.Fields("unusualno")
            '    DirectCast(pdffield, TallComponents.PDF.Forms.Fields.CheckBoxField).CheckBoxValue = CheckState.Off

            'Else
            '    pdffield = myPDFFields.Fields("unusualno")
            '    DirectCast(pdffield, TallComponents.PDF.Forms.Fields.CheckBoxField).CheckBoxValue = CheckState.On
            '    pdffield = myPDFFields.Fields("unusualyes")
            '    DirectCast(pdffield, TallComponents.PDF.Forms.Fields.CheckBoxField).CheckBoxValue = CheckState.Off
            'End If

            'If ds1.Tables(0).Rows(0).Item("ARIng24").ToString() = "Yes" Then
            '    pdffield = myPDFFields.Fields("poolyes")
            '    DirectCast(pdffield, TallComponents.PDF.Forms.Fields.CheckBoxField).CheckBoxValue = CheckState.On
            '    pdffield = myPDFFields.Fields("poolno")
            '    DirectCast(pdffield, TallComponents.PDF.Forms.Fields.CheckBoxField).CheckBoxValue = CheckState.Off

            'Else
            '    pdffield = myPDFFields.Fields("poolno")
            '    DirectCast(pdffield, TallComponents.PDF.Forms.Fields.CheckBoxField).CheckBoxValue = CheckState.On
            '    pdffield = myPDFFields.Fields("poolyes")
            '    DirectCast(pdffield, TallComponents.PDF.Forms.Fields.CheckBoxField).CheckBoxValue = CheckState.Off
            'End If

            'If ds1.Tables(0).Rows(0).Item("ARIng24a").ToString() = "Yes" Then
            '    pdffield = myPDFFields.Fields("fenceyes")
            '    DirectCast(pdffield, TallComponents.PDF.Forms.Fields.CheckBoxField).CheckBoxValue = CheckState.On
            '    pdffield = myPDFFields.Fields("fenceno")
            '    DirectCast(pdffield, TallComponents.PDF.Forms.Fields.CheckBoxField).CheckBoxValue = CheckState.Off

            'Else
            '    pdffield = myPDFFields.Fields("fenceno")
            '    DirectCast(pdffield, TallComponents.PDF.Forms.Fields.CheckBoxField).CheckBoxValue = CheckState.On
            '    pdffield = myPDFFields.Fields("fenceyes")
            '    DirectCast(pdffield, TallComponents.PDF.Forms.Fields.CheckBoxField).CheckBoxValue = CheckState.Off
            'End If

            'If ds1.Tables(0).Rows(0).Item("ARIng24b").ToString() = "Yes" Then
            '    pdffield = myPDFFields.Fields("slideyes")
            '    DirectCast(pdffield, TallComponents.PDF.Forms.Fields.CheckBoxField).CheckBoxValue = CheckState.On
            '    pdffield = myPDFFields.Fields("slideno")
            '    DirectCast(pdffield, TallComponents.PDF.Forms.Fields.CheckBoxField).CheckBoxValue = CheckState.Off

            'Else
            '    pdffield = myPDFFields.Fields("slideno")
            '    DirectCast(pdffield, TallComponents.PDF.Forms.Fields.CheckBoxField).CheckBoxValue = CheckState.On
            '    pdffield = myPDFFields.Fields("slideyes")
            '    DirectCast(pdffield, TallComponents.PDF.Forms.Fields.CheckBoxField).CheckBoxValue = CheckState.Off
            'End If

            'If ds1.Tables(0).Rows(0).Item("ARIng25").ToString() = "Yes" Then
            '    pdffield = myPDFFields.Fields("hazrdyes")
            '    DirectCast(pdffield, TallComponents.PDF.Forms.Fields.CheckBoxField).CheckBoxValue = CheckState.On
            '    pdffield = myPDFFields.Fields("hazardno")
            '    DirectCast(pdffield, TallComponents.PDF.Forms.Fields.CheckBoxField).CheckBoxValue = CheckState.Off

            'Else
            '    pdffield = myPDFFields.Fields("hazardno")
            '    DirectCast(pdffield, TallComponents.PDF.Forms.Fields.CheckBoxField).CheckBoxValue = CheckState.On
            '    pdffield = myPDFFields.Fields("hazrdyes")
            '    DirectCast(pdffield, TallComponents.PDF.Forms.Fields.CheckBoxField).CheckBoxValue = CheckState.Off
            'End If

            'If ds1.Tables(0).Rows(0).Item("ARIng26").ToString() = "Yes" Then
            '    pdffield = myPDFFields.Fields("brokenyes")
            '    DirectCast(pdffield, TallComponents.PDF.Forms.Fields.CheckBoxField).CheckBoxValue = CheckState.On
            '    pdffield = myPDFFields.Fields("brokenno")
            '    DirectCast(pdffield, TallComponents.PDF.Forms.Fields.CheckBoxField).CheckBoxValue = CheckState.Off

            'Else
            '    pdffield = myPDFFields.Fields("brokenno")
            '    DirectCast(pdffield, TallComponents.PDF.Forms.Fields.CheckBoxField).CheckBoxValue = CheckState.On
            '    pdffield = myPDFFields.Fields("brokenyes")
            '    DirectCast(pdffield, TallComponents.PDF.Forms.Fields.CheckBoxField).CheckBoxValue = CheckState.Off
            'End If
            If ds1.Tables(0).Rows(0).Item("BillLienHold").ToString() = "Yes" Then

                pdffield = myPDFFields.Fields("undefined")
                DirectCast(pdffield, TallComponents.PDF.Forms.Fields.TextField).Value = "  X  "

            Else
                pdffield = myPDFFields.Fields("undefined_2")
                DirectCast(pdffield, TallComponents.PDF.Forms.Fields.TextField).Value = "  X  "

            End If

            '*******************************QUOTE INFO********************************************************

            Select Case ds3.Tables(0).Rows(0).Item("ARRateType").ToString()
                Case "Aegis Vintage"
                    If ds1.Tables(0).Rows(0).Item("Usage").ToString() = "Rental" Then

                        pdffield = myPDFFields.Fields("MHLimit")
                        DirectCast(pdffield, TallComponents.PDF.Forms.Fields.TextField).Value = CInt(ds2.Tables(0).Rows(0).Item("VintDwell").ToString().Replace("$", "").Replace(",", "")).ToString("C2").Replace("$", "")

                        Dim homeprem As Integer
                        homeprem = CInt(ds2.Tables(0).Rows(0).Item("VintBasePrem").ToString().Replace("$", "").Replace(",", ""))
                        'homeprem += 45

                        pdffield = myPDFFields.Fields("MHPrem")
                        DirectCast(pdffield, TallComponents.PDF.Forms.Fields.TextField).Value = homeprem.ToString("C2").Replace("$", "")

                        'pdffield = myPDFFields.Fields("personallimit")
                        'DirectCast(pdffield, TallComponents.PDF.Forms.Fields.TextField).Value = CInt(ds2.Tables(0).Rows(0).Item("PackCont").ToString().Replace("$", "").Replace(",", "")).ToString("C2").Replace("$", "")

                        'pdffield = myPDFFields.Fields("personalpremium")
                        'DirectCast(pdffield, TallComponents.PDF.Forms.Fields.TextField).Value = CInt(ds2.Tables(0).Rows(0).Item("PackContPrem").ToString().Replace("$", "").Replace(",", "")).ToString("C2").Replace("$", "")


                        pdffield = myPDFFields.Fields("StrucLimit")
                        DirectCast(pdffield, TallComponents.PDF.Forms.Fields.TextField).Value = CInt(ds2.Tables(0).Rows(0).Item("VintStruc").ToString().Replace("$", "").Replace(",", "")).ToString("C2").Replace("$", "")

                        pdffield = myPDFFields.Fields("StrucPrem")
                        DirectCast(pdffield, TallComponents.PDF.Forms.Fields.TextField).Value = CInt(ds2.Tables(0).Rows(0).Item("VintStrucPrem").ToString().Replace("$", "").Replace(",", "")).ToString("C2").Replace("$", "")

                        pdffield = myPDFFields.Fields("RentPLiabLimit")
                        DirectCast(pdffield, TallComponents.PDF.Forms.Fields.TextField).Value = CInt(ds2.Tables(0).Rows(0).Item("VintLiab").ToString().Replace("$", "").Replace(",", "")).ToString("C2").Replace("$", "")

                        pdffield = myPDFFields.Fields("RPLiabPrem")
                        DirectCast(pdffield, TallComponents.PDF.Forms.Fields.TextField).Value = "0.00" 'CInt(ds2.Tables(0).Rows(0).Item("VintPersLiabPrem").ToString().Replace("$", "").Replace(",", "")).ToString("C2").Replace("$", "")
                        'If ds2.Tables(0).Rows(0).Item("RentMedPay").ToString().Replace("$", "") <> "" Then

                        '    pdffield = myPDFFields.Fields("medpaylimit")
                        '    DirectCast(pdffield, TallComponents.PDF.Forms.Fields.TextField).Value = CInt(ds2.Tables(0).Rows(0).Item("RentMedPay").ToString().Replace("$", "").Replace(",", "")).ToString("C2").Replace("$", "")

                        '    pdffield = myPDFFields.Fields("medpaylimit")
                        '    DirectCast(pdffield, TallComponents.PDF.Forms.Fields.TextField).Value = CInt(ds2.Tables(0).Rows(0).Item("RentMedPay").ToString().Replace("$", "").Replace(",", "")).ToString("C2").Replace("$", "")

                        '    pdffield = myPDFFields.Fields("medpaypremium")
                        '    DirectCast(pdffield, TallComponents.PDF.Forms.Fields.TextField).Value = CInt(ds2.Tables(0).Rows(0).Item("RentMedPrem").ToString().Replace("$", "").Replace(",", "")).ToString("C2").Replace("$", "")
                        'End If
                       

                        'pdffield = myPDFFields.Fields("AOPLimit")
                        'DirectCast(pdffield, TallComponents.PDF.Forms.Fields.TextField).Value = CInt(ds2.Tables(0).Rows(0).Item("RentAOP").ToString().Replace("$", "").Replace(",", "")).ToString("C2").Replace("$", "")

                        'pdffield = myPDFFields.Fields("AOPPrem")
                        'DirectCast(pdffield, TallComponents.PDF.Forms.Fields.TextField).Value = CInt(ds2.Tables(0).Rows(0).Item("RentAOPPrem").ToString().Replace("$", "").Replace(",", "")).ToString("C2").Replace("$", "")

                        pdffield = myPDFFields.Fields("TotalPrem")
                        DirectCast(pdffield, TallComponents.PDF.Forms.Fields.TextField).Value = CInt(ds2.Tables(0).Rows(0).Item("Vinttotal").ToString().Replace("$", "").Replace(",", "")).ToString("C2").Replace("$", "")
                        'If ds3.Tables(0).Rows(0).Item("lienholder").ToString() = "No" Then
                        '    pdffield = myPDFFields.Fields("nolienholderprem")
                        '    DirectCast(pdffield, TallComponents.PDF.Forms.Fields.TextField).Value = "(15)"

                        'End If


                    Else


                        pdffield = myPDFFields.Fields("MHLimit")
                        DirectCast(pdffield, TallComponents.PDF.Forms.Fields.TextField).Value = CInt(ds2.Tables(0).Rows(0).Item("VintDwell").ToString().Replace("$", "").Replace(",", "")).ToString("C2").Replace("$", "")

                        pdffield = myPDFFields.Fields("MHPrem")
                        DirectCast(pdffield, TallComponents.PDF.Forms.Fields.TextField).Value = CInt(ds2.Tables(0).Rows(0).Item("VintBasePrem").ToString().Replace("$", "").Replace(",", "")).ToString("C2").Replace("$", "")

                        pdffield = myPDFFields.Fields("PPLimit")
                        DirectCast(pdffield, TallComponents.PDF.Forms.Fields.TextField).Value = CInt(ds2.Tables(0).Rows(0).Item("Vintcont").ToString().Replace("$", "").Replace(",", "")).ToString("C2").Replace("$", "")

                        pdffield = myPDFFields.Fields("PPPrem")
                        DirectCast(pdffield, TallComponents.PDF.Forms.Fields.TextField).Value = CInt(ds2.Tables(0).Rows(0).Item("VintcontPrem").ToString().Replace("$", "").Replace(",", "")).ToString("C2").Replace("$", "")


                        pdffield = myPDFFields.Fields("StrucLimit")
                        DirectCast(pdffield, TallComponents.PDF.Forms.Fields.TextField).Value = CInt(ds2.Tables(0).Rows(0).Item("VintStruc").ToString().Replace("$", "").Replace(",", "")).ToString("C2").Replace("$", "")

                        pdffield = myPDFFields.Fields("StrucPrem")
                        DirectCast(pdffield, TallComponents.PDF.Forms.Fields.TextField).Value = CInt(ds2.Tables(0).Rows(0).Item("VintStrucPrem").ToString().Replace("$", "").Replace(",", "")).ToString("C2").Replace("$", "")

                        pdffield = myPDFFields.Fields("PLiabLimit")
                        DirectCast(pdffield, TallComponents.PDF.Forms.Fields.TextField).Value = CInt(ds2.Tables(0).Rows(0).Item("VintLiab").ToString().Replace("$", "").Replace(",", "")).ToString("C2").Replace("$", "")

                        pdffield = myPDFFields.Fields("PliabPrem")
                        DirectCast(pdffield, TallComponents.PDF.Forms.Fields.TextField).Value = "0.00" 'CInt(ds2.Tables(0).Rows(0).Item("PackPersLiabPrem").ToString().Replace("$", "").Replace(",", "")).ToString("C2").Replace("$", "")

                        ''pdffield = myPDFFields.Fields("medpaylimit")
                        ''DirectCast(pdffield, TallComponents.PDF.Forms.Fields.TextField).Value = CInt(ds2.Tables(0).Rows(0).Item("PackMedPay").ToString().Replace("$", "").Replace(",", "")).ToString("C2").Replace("$", "")

                        'pdffield = myPDFFields.Fields("medpaypremium")
                        'DirectCast(pdffield, TallComponents.PDF.Forms.Fields.TextField).Value = CInt(ds2.Tables(0).Rows(0).Item("PackMedPrem").ToString().Replace("$", "").Replace(",", "")).ToString("C2").Replace("$", "")

                        'If ds2.Tables(0).Rows(0).Item("PackFullRepair").ToString() = "Yes" Then
                        '    pdffield = myPDFFields.Fields("fullrepaircostprem")
                        '    DirectCast(pdffield, TallComponents.PDF.Forms.Fields.TextField).Value = CInt(ds2.Tables(0).Rows(0).Item("PackFullRepairPrem").ToString().Replace("$", "").Replace(",", "")).ToString("C2").Replace("$", "")

                        'End If
                        'If ds2.Tables(0).Rows(0).Item("PackContReplace").ToString() = "Yes" Then
                        '    pdffield = myPDFFields.Fields("replacecostpersonalprem")
                        '    DirectCast(pdffield, TallComponents.PDF.Forms.Fields.TextField).Value = CInt(ds2.Tables(0).Rows(0).Item("PackContReplacePrem").ToString().Replace("$", "").Replace(",", "")).ToString("C2").Replace("$", "")

                        'End If
                        'If ds2.Tables(0).Rows(0).Item("PackPPprem").ToString() = "0.00" Then
                        '    pdffield = myPDFFields.Fields("schedulepropertyprem")
                        '    DirectCast(pdffield, TallComponents.PDF.Forms.Fields.TextField).Value = CInt(ds2.Tables(0).Rows(0).Item("PackPPprem").ToString().Replace("$", "").Replace(",", "")).ToString("C2").Replace("$", "")

                        'End If
                        ''If ds3.Tables(0).Rows(0).Item("lienholder").ToString() = "No" Then
                        ''    pdffield = myPDFFields.Fields("nolienholderprem")
                        ''    DirectCast(pdffield, TallComponents.PDF.Forms.Fields.TextField).Value = CInt("15").ToString("C2").Replace("$", "")

                        ''End If

                        pdffield = myPDFFields.Fields("AOPLimit")
                        DirectCast(pdffield, TallComponents.PDF.Forms.Fields.TextField).Value = CInt(ds2.Tables(0).Rows(0).Item("PackAOP").ToString().Replace("$", "").Replace(",", "")).ToString("C2").Replace("$", "")

                        pdffield = myPDFFields.Fields("AOPPrem")
                        DirectCast(pdffield, TallComponents.PDF.Forms.Fields.TextField).Value = CInt(ds2.Tables(0).Rows(0).Item("PackAOPPrem").ToString().Replace("$", "").Replace(",", "")).ToString("C2").Replace("$", "")

                        pdffield = myPDFFields.Fields("TotalPrem")
                        DirectCast(pdffield, TallComponents.PDF.Forms.Fields.TextField).Value = CInt(ds2.Tables(0).Rows(0).Item("VintTotal").ToString().Replace("$", "").Replace(",", "")).ToString("C2").Replace("$", "")
                        'If ds3.Tables(0).Rows(0).Item("lienholder").ToString() = "No" Then
                        '    pdffield = myPDFFields.Fields("nolienholderprem")
                        '    DirectCast(pdffield, TallComponents.PDF.Forms.Fields.TextField).Value = "(15)"

                        'End If

                    End If
                Case "Aegis Rental"

                    pdffield = myPDFFields.Fields("homelimit")
                    DirectCast(pdffield, TallComponents.PDF.Forms.Fields.TextField).Value = CInt(ds2.Tables(0).Rows(0).Item("VintRentDwel").ToString().Replace("$", "").Replace(",", "")).ToString("C2").Replace("$", "")

                    Dim homeprem As Integer
                    homeprem = CInt(ds2.Tables(0).Rows(0).Item("VintRentprem").ToString().Replace("$", "").Replace(",", ""))
                    homeprem += 45

                    pdffield = myPDFFields.Fields("homepremium")
                    DirectCast(pdffield, TallComponents.PDF.Forms.Fields.TextField).Value = homeprem.ToString("C2").Replace("$", "")

                    'pdffield = myPDFFields.Fields("personallimit")
                    'DirectCast(pdffield, TallComponents.PDF.Forms.Fields.TextField).Value = CInt(ds2.Tables(0).Rows(0).Item("PackCont").ToString().Replace("$", "").Replace(",", "")).ToString("C2").Replace("$", "")

                    'pdffield = myPDFFields.Fields("personalpremium")
                    'DirectCast(pdffield, TallComponents.PDF.Forms.Fields.TextField).Value = CInt(ds2.Tables(0).Rows(0).Item("PackContPrem").ToString().Replace("$", "").Replace(",", "")).ToString("C2").Replace("$", "")


                    pdffield = myPDFFields.Fields("unattachedlimit")
                    DirectCast(pdffield, TallComponents.PDF.Forms.Fields.TextField).Value = CInt(ds2.Tables(0).Rows(0).Item("VintRentStruc").ToString().Replace("$", "").Replace(",", "")).ToString("C2").Replace("$", "")

                    pdffield = myPDFFields.Fields("unattachedpremium")
                    DirectCast(pdffield, TallComponents.PDF.Forms.Fields.TextField).Value = CInt(ds2.Tables(0).Rows(0).Item("VintRentStrucPrem").ToString().Replace("$", "").Replace(",", "")).ToString("C2").Replace("$", "")

                    pdffield = myPDFFields.Fields("liabilityrentlimit")
                    DirectCast(pdffield, TallComponents.PDF.Forms.Fields.TextField).Value = CInt(ds2.Tables(0).Rows(0).Item("VintRentLiab").ToString().Replace("$", "").Replace(",", "")).ToString("C2").Replace("$", "")

                    pdffield = myPDFFields.Fields("liabilityrentpremium")
                    DirectCast(pdffield, TallComponents.PDF.Forms.Fields.TextField).Value = CInt(ds2.Tables(0).Rows(0).Item("VintRentPersLiabPrem").ToString().Replace("$", "").Replace(",", "")).ToString("C2").Replace("$", "")
                    'If ds2.Tables(0).Rows(0).Item("RentMedPay").ToString().Replace("$", "") <> "" Then

                    '    pdffield = myPDFFields.Fields("medpaylimit")
                    '    DirectCast(pdffield, TallComponents.PDF.Forms.Fields.TextField).Value = CInt(ds2.Tables(0).Rows(0).Item("RentMedPay").ToString().Replace("$", "").Replace(",", "")).ToString("C2").Replace("$", "")

                    '    pdffield = myPDFFields.Fields("medpaylimit")
                    '    DirectCast(pdffield, TallComponents.PDF.Forms.Fields.TextField).Value = CInt(ds2.Tables(0).Rows(0).Item("RentMedPay").ToString().Replace("$", "").Replace(",", "")).ToString("C2").Replace("$", "")

                    '    pdffield = myPDFFields.Fields("medpaypremium")
                    '    DirectCast(pdffield, TallComponents.PDF.Forms.Fields.TextField).Value = CInt(ds2.Tables(0).Rows(0).Item("RentMedPrem").ToString().Replace("$", "").Replace(",", "")).ToString("C2").Replace("$", "")
                    'End If
                    'If ds2.Tables(0).Rows(0).Item("PackFullRepair").ToString() = "Yes" Then
                    '    pdffield = myPDFFields.Fields("fullrepaircostprem")
                    '    DirectCast(pdffield, TallComponents.PDF.Forms.Fields.TextField).Value = CInt(ds2.Tables(0).Rows(0).Item("PackFullRepairPrem").ToString().Replace("$", "").Replace(",", "")).ToString("C2").Replace("$", "")

                    'End If
                    'If ds2.Tables(0).Rows(0).Item("PackContReplace").ToString() = "Yes" Then
                    '    pdffield = myPDFFields.Fields("replacecostpersonalprem")
                    '    DirectCast(pdffield, TallComponents.PDF.Forms.Fields.TextField).Value = CInt(ds2.Tables(0).Rows(0).Item("PackContReplacePrem").ToString().Replace("$", "").Replace(",", "")).ToString("C2").Replace("$", "")

                    'End If
                    'If ds2.Tables(0).Rows(0).Item("PackPPprem").ToString() = "0.00" Then
                    '    pdffield = myPDFFields.Fields("schedulepropertyprem")
                    '    DirectCast(pdffield, TallComponents.PDF.Forms.Fields.TextField).Value = CInt(ds2.Tables(0).Rows(0).Item("PackPPprem").ToString().Replace("$", "").Replace(",", "")).ToString("C2").Replace("$", "")

                    'End If
                    'If ds3.Tables(0).Rows(0).Item("lienholder").ToString() = "No" Then
                    '    pdffield = myPDFFields.Fields("nolienholderprem")
                    '    DirectCast(pdffield, TallComponents.PDF.Forms.Fields.TextField).Value = CInt("15").ToString("C2").Replace("$", "")

                    'End If


                    'Need to put constant fee of $45?


                    pdffield = myPDFFields.Fields("allperillimit")
                    DirectCast(pdffield, TallComponents.PDF.Forms.Fields.TextField).Value = CInt(ds2.Tables(0).Rows(0).Item("RentAOP").ToString().Replace("$", "").Replace(",", "")).ToString("C2").Replace("$", "")

                    pdffield = myPDFFields.Fields("allperilprem")
                    DirectCast(pdffield, TallComponents.PDF.Forms.Fields.TextField).Value = CInt(ds2.Tables(0).Rows(0).Item("RentAOPPrem").ToString().Replace("$", "").Replace(",", "")).ToString("C2").Replace("$", "")

                    pdffield = myPDFFields.Fields("TotalPrem")
                    DirectCast(pdffield, TallComponents.PDF.Forms.Fields.TextField).Value = CInt(ds2.Tables(0).Rows(0).Item("Renttotal").ToString().Replace("$", "").Replace(",", "")).ToString("C2").Replace("$", "")
                    'If ds3.Tables(0).Rows(0).Item("lienholder").ToString() = "No" Then
                    '    pdffield = myPDFFields.Fields("nolienholderprem")
                    '    DirectCast(pdffield, TallComponents.PDF.Forms.Fields.TextField).Value = "(15)"

                    'End If



                Case "Aegis Tenant"

            End Select















            'pdffield = myPDFFields.Fields("DOB")
            'DirectCast(pdffield, TallComponents.PDF.Forms.Fields.TextField).Value = ds.Tables(0).Rows(0).Item("DOB").ToString()
            'pdffield = myPDFFields.Fields("Address")
            'DirectCast(pdffield, TallComponents.PDF.Forms.Fields.TextField).Value = ds.Tables(0).Rows(0).Item("Address").ToString()
            'pdffield = myPDFFields.Fields("InsCity")
            'DirectCast(pdffield, TallComponents.PDF.Forms.Fields.TextField).Value = ds.Tables(0).Rows(0).Item("City").ToString()
            'pdffield = myPDFFields.Fields("InsState")
            'DirectCast(pdffield, TallComponents.PDF.Forms.Fields.TextField).Value = ds.Tables(0).Rows(0).Item("State").ToString()
            'pdffield = myPDFFields.Fields("InsZip")
            'DirectCast(pdffield, TallComponents.PDF.Forms.Fields.TextField).Value = ds.Tables(0).Rows(0).Item("Zip").ToString()
            'pdffield = myPDFFields.Fields("County")
            'DirectCast(pdffield, TallComponents.PDF.Forms.Fields.TextField).Value = ds.Tables(0).Rows(0).Item("County").ToString()
            'pdffield = myPDFFields.Fields("Phone No")
            'DirectCast(pdffield, TallComponents.PDF.Forms.Fields.TextField).Value = ds.Tables(0).Rows(0).Item("Phone").ToString()
            'pdffield = myPDFFields.Fields("Occupation")
            'DirectCast(pdffield, TallComponents.PDF.Forms.Fields.TextField).Value = ds.Tables(0).Rows(0).Item("Occ").ToString()
            'pdffield = myPDFFields.Fields("Social Security")
            'DirectCast(pdffield, TallComponents.PDF.Forms.Fields.TextField).Value = ds.Tables(0).Rows(0).Item("SSN").ToString()
            'pdffield = myPDFFields.Fields("Spouse Name")
            'DirectCast(pdffield, TallComponents.PDF.Forms.Fields.TextField).Value = ds.Tables(0).Rows(0).Item("SpouseName").ToString()
            'pdffield = myPDFFields.Fields("Spouse Social Security")
            'DirectCast(pdffield, TallComponents.PDF.Forms.Fields.TextField).Value = ds.Tables(0).Rows(0).Item("SpouseSSN").ToString()
            'pdffield = myPDFFields.Fields("Addl Insured")
            'DirectCast(pdffield, TallComponents.PDF.Forms.Fields.TextField).Value = ds.Tables(0).Rows(0).Item("AddInsured").ToString()

            'pdffield = myPDFFields.Fields("Address_2")
            'DirectCast(pdffield, TallComponents.PDF.Forms.Fields.TextField).Value = ds.Tables(0).Rows(0).Item("DiffAppAddr").ToString()
            'pdffield = myPDFFields.Fields("SpouseCity")
            'DirectCast(pdffield, TallComponents.PDF.Forms.Fields.TextField).Value = ds.Tables(0).Rows(0).Item("DiffAppCity").ToString()
            'pdffield = myPDFFields.Fields("SpouseState")
            'DirectCast(pdffield, TallComponents.PDF.Forms.Fields.TextField).Value = ds.Tables(0).Rows(0).Item("DiffAppState").ToString()
            'pdffield = myPDFFields.Fields("SpouseZip")
            'DirectCast(pdffield, TallComponents.PDF.Forms.Fields.TextField).Value = ds.Tables(0).Rows(0).Item("DiffAppZip").ToString()
            'pdffield = myPDFFields.Fields("Name_2")
            'DirectCast(pdffield, TallComponents.PDF.Forms.Fields.TextField).Value = ds.Tables(0).Rows(0).Item("Lien1Name").ToString()
            'pdffield = myPDFFields.Fields("Loan")
            'DirectCast(pdffield, TallComponents.PDF.Forms.Fields.TextField).Value = ds.Tables(0).Rows(0).Item("Lien1Num").ToString()
            'pdffield = myPDFFields.Fields("Address_3")
            'DirectCast(pdffield, TallComponents.PDF.Forms.Fields.TextField).Value = ds.Tables(0).Rows(0).Item("Lien1Addr").ToString()
            'pdffield = myPDFFields.Fields("LienCity1")
            'DirectCast(pdffield, TallComponents.PDF.Forms.Fields.TextField).Value = ds.Tables(0).Rows(0).Item("Lien1City").ToString()
            'pdffield = myPDFFields.Fields("lienState1")
            'DirectCast(pdffield, TallComponents.PDF.Forms.Fields.TextField).Value = ds.Tables(0).Rows(0).Item("Lien1State").ToString()
            'pdffield = myPDFFields.Fields("LienZip1")
            'DirectCast(pdffield, TallComponents.PDF.Forms.Fields.TextField).Value = ds.Tables(0).Rows(0).Item("Lien1Zip").ToString()
            'pdffield = myPDFFields.Fields("Agent Name Agent")
            'DirectCast(pdffield, TallComponents.PDF.Forms.Fields.TextField).Value = ds.Tables(0).Rows(0).Item("AgentName").ToString()
            'pdffield = myPDFFields.Fields("Municipal Tax Code")
            'DirectCast(pdffield, TallComponents.PDF.Forms.Fields.TextField).Value = ds.Tables(0).Rows(0).Item("MunTaxCode").ToString()
            'pdffield = myPDFFields.Fields("feet")
            'DirectCast(pdffield, TallComponents.PDF.Forms.Fields.TextField).Value = ds.Tables(0).Rows(0).Item("DistToFire").ToString()
            'pdffield = myPDFFields.Fields("Distance of unit to responding Fire Dept")
            'DirectCast(pdffield, TallComponents.PDF.Forms.Fields.TextField).Value = ds.Tables(0).Rows(0).Item("DistToFireDept").ToString()
            'pdffield = myPDFFields.Fields("Name of Fire Dept")
            'DirectCast(pdffield, TallComponents.PDF.Forms.Fields.TextField).Value = ds.Tables(0).Rows(0).Item("FireDeptName").ToString()
            'pdffield = myPDFFields.Fields("Park Name")
            'DirectCast(pdffield, TallComponents.PDF.Forms.Fields.TextField).Value = ds.Tables(0).Rows(0).Item("ParkName").ToString()

            'If ds.Tables(0).Rows(0).Item("ctylimits").ToString() = "Yes" Then
            '    pdffield = myPDFFields.Fields("undefined_2")
            '    DirectCast(pdffield, TallComponents.PDF.Forms.Fields.CheckBoxField).CheckBoxValue = CheckState.On
            'ElseIf ds.Tables(0).Rows(0).Item("ctylimits").ToString() = "No" Then
            '    pdffield = myPDFFields.Fields("undefined_3")
            '    DirectCast(pdffield, TallComponents.PDF.Forms.Fields.CheckBoxField).CheckBoxValue = CheckState.On
            'End If
            'If ds.Tables(0).Rows(0).Item("fwua").ToString() = "Yes" Then
            '    pdffield = myPDFFields.Fields("undefined_4")
            '    DirectCast(pdffield, TallComponents.PDF.Forms.Fields.CheckBoxField).CheckBoxValue = CheckState.On
            'ElseIf ds.Tables(0).Rows(0).Item("fwua").ToString() = "No" Then
            '    pdffield = myPDFFields.Fields("undefined_5")
            '    DirectCast(pdffield, TallComponents.PDF.Forms.Fields.CheckBoxField).CheckBoxValue = CheckState.On
            'End If
            'pdffield = myPDFFields.Fields("undefined_6")
            'DirectCast(pdffield, TallComponents.PDF.Forms.Fields.TextField).Value = ds.Tables(0).Rows(0).Item("DistToGulf").ToString()
            'pdffield = myPDFFields.Fields("Year")
            'DirectCast(pdffield, TallComponents.PDF.Forms.Fields.TextField).Value = ds.Tables(0).Rows(0).Item("DescMHYear").ToString()

            'pdffield = myPDFFields.Fields("ManufacturerModel")
            'DirectCast(pdffield, TallComponents.PDF.Forms.Fields.TextField).Value = ds.Tables(0).Rows(0).Item("DescMHManf").ToString()
            'pdffield = myPDFFields.Fields("Length")
            'DirectCast(pdffield, TallComponents.PDF.Forms.Fields.TextField).Value = ds.Tables(0).Rows(0).Item("DescMHLength").ToString()
            'pdffield = myPDFFields.Fields("Width")
            'DirectCast(pdffield, TallComponents.PDF.Forms.Fields.TextField).Value = ds.Tables(0).Rows(0).Item("DescMHWidth").ToString()
            'pdffield = myPDFFields.Fields("Serial Number")
            'DirectCast(pdffield, TallComponents.PDF.Forms.Fields.TextField).Value = ds.Tables(0).Rows(0).Item("DescMHSerial").ToString()
            'pdffield = myPDFFields.Fields("Purchase Date")
            'DirectCast(pdffield, TallComponents.PDF.Forms.Fields.TextField).Value = ds.Tables(0).Rows(0).Item("DescMHPurDate").ToString()
            'pdffield = myPDFFields.Fields("Describe AdditionsAttached Structures")
            'DirectCast(pdffield, TallComponents.PDF.Forms.Fields.TextField).Value = ds.Tables(0).Rows(0).Item("DescMHAttStruc").ToString()
            'pdffield = myPDFFields.Fields("Age")
            'DirectCast(pdffield, TallComponents.PDF.Forms.Fields.TextField).Value = ds.Tables(0).Rows(0).Item("DescMHAttStrucAge").ToString()
            'pdffield = myPDFFields.Fields("Size")
            'DirectCast(pdffield, TallComponents.PDF.Forms.Fields.TextField).Value = ds.Tables(0).Rows(0).Item("DescMHAttStrucSize").ToString()
            'pdffield = myPDFFields.Fields("fill_60")
            'DirectCast(pdffield, TallComponents.PDF.Forms.Fields.TextField).Value = ds.Tables(0).Rows(0).Item("DescMHAttStrucCurVal").ToString()
            'pdffield = myPDFFields.Fields("Describe Unattached Structures")
            'DirectCast(pdffield, TallComponents.PDF.Forms.Fields.TextField).Value = ds.Tables(0).Rows(0).Item("DescMHUnAttStruc").ToString()
            'pdffield = myPDFFields.Fields("Age_2")
            'DirectCast(pdffield, TallComponents.PDF.Forms.Fields.TextField).Value = ds.Tables(0).Rows(0).Item("DescMHUnAttStrucAge").ToString()
            'pdffield = myPDFFields.Fields("Size_2")
            'DirectCast(pdffield, TallComponents.PDF.Forms.Fields.TextField).Value = ds.Tables(0).Rows(0).Item("DescMHUnAttStrucSize").ToString()
            'pdffield = myPDFFields.Fields("fill_61")
            'DirectCast(pdffield, TallComponents.PDF.Forms.Fields.TextField).Value = ds.Tables(0).Rows(0).Item("DescMHUnAttStrucCurVal").ToString()


            'Select Case ds.Tables(0).Rows(0).Item("Program").ToString()
            '    Case "Package"
            '        pdffield = myPDFFields.Fields("Package")
            '        DirectCast(pdffield, TallComponents.PDF.Forms.Fields.CheckBoxField).CheckBoxValue = CheckState.On
            '    Case "Rental"
            '        pdffield = myPDFFields.Fields("Rental")
            '        DirectCast(pdffield, TallComponents.PDF.Forms.Fields.CheckBoxField).CheckBoxValue = CheckState.On
            '    Case "Standard"
            '        pdffield = myPDFFields.Fields("Standard")
            '        DirectCast(pdffield, TallComponents.PDF.Forms.Fields.CheckBoxField).CheckBoxValue = CheckState.On
            '    Case "Commercial"
            '        pdffield = myPDFFields.Fields("Commercial")
            '        DirectCast(pdffield, TallComponents.PDF.Forms.Fields.CheckBoxField).CheckBoxValue = CheckState.On
            '    Case "Preferred"
            '        pdffield = myPDFFields.Fields("Preferred")
            '        DirectCast(pdffield, TallComponents.PDF.Forms.Fields.CheckBoxField).CheckBoxValue = CheckState.On
            '    Case "Tenant"
            '        pdffield = myPDFFields.Fields("Tenant")
            '        DirectCast(pdffield, TallComponents.PDF.Forms.Fields.CheckBoxField).CheckBoxValue = CheckState.On

            'End Select
            'Select Case ds.Tables(0).Rows(0).Item("Usage").ToString()
            '    Case "Permanent"
            '        pdffield = myPDFFields.Fields("Permanent")
            '        DirectCast(pdffield, TallComponents.PDF.Forms.Fields.CheckBoxField).CheckBoxValue = CheckState.On
            '    Case "Seasonal"
            '        pdffield = myPDFFields.Fields("Seasonal")
            '        DirectCast(pdffield, TallComponents.PDF.Forms.Fields.CheckBoxField).CheckBoxValue = CheckState.On
            '    Case "Rental"
            '        pdffield = myPDFFields.Fields("Rental_2")
            '        DirectCast(pdffield, TallComponents.PDF.Forms.Fields.CheckBoxField).CheckBoxValue = CheckState.On
            '    Case "Commercial"
            '        pdffield = myPDFFields.Fields("Commercial_2")
            '        DirectCast(pdffield, TallComponents.PDF.Forms.Fields.CheckBoxField).CheckBoxValue = CheckState.On
            '    Case "Tenant"
            '        pdffield = myPDFFields.Fields("Tenant_2")
            '        DirectCast(pdffield, TallComponents.PDF.Forms.Fields.CheckBoxField).CheckBoxValue = CheckState.On


            'End Select
            ''protected
            'If ds.Tables(0).Rows(0).Item("Protection").ToString() = "Protected" Then
            '    pdffield = myPDFFields.Fields("undefined_9")
            '    DirectCast(pdffield, TallComponents.PDF.Forms.Fields.CheckBoxField).CheckBoxValue = CheckState.On
            'ElseIf ds.Tables(0).Rows(0).Item("Protection").ToString() = "Protected" Then
            '    pdffield = myPDFFields.Fields("undefined_10")
            '    DirectCast(pdffield, TallComponents.PDF.Forms.Fields.CheckBoxField).CheckBoxValue = CheckState.On
            'End If
            'pdffield = myPDFFields.Fields("undefined_11")
            'DirectCast(pdffield, TallComponents.PDF.Forms.Fields.TextField).Value = ds.Tables(0).Rows(0).Item("InsAge").ToString()
            ''age of mobile home
            'Select Case ds.Tables(0).Rows(0).Item("MHAge").ToString()
            '    Case "1-5 Yrs"
            '        pdffield = myPDFFields.Fields("1  5 Yrs")
            '        DirectCast(pdffield, TallComponents.PDF.Forms.Fields.CheckBoxField).CheckBoxValue = CheckState.On

            '    Case "6-15 Yrs"
            '        pdffield = myPDFFields.Fields("6  15 Yrs")
            '        DirectCast(pdffield, TallComponents.PDF.Forms.Fields.CheckBoxField).CheckBoxValue = CheckState.On

            '    Case "16 Yrs & Older"
            '        pdffield = myPDFFields.Fields("16 Yrs  Older")
            '        DirectCast(pdffield, TallComponents.PDF.Forms.Fields.CheckBoxField).CheckBoxValue = CheckState.On

            'End Select
            ''Loss History
            'Dim rpdffield As TallComponents.PDF.Forms.Fields.RadioButtonField
            'If ds.Tables(0).Rows(0).Item("lossHist").ToString() = "Yes" Then
            '    rpdffield = myPDFFields.Fields("Claim Free for at least one year")
            '    DirectCast(rpdffield, TallComponents.PDF.Forms.Fields.RadioButtonField).RadioButtonValue = rpdffield.Options(0)

            'ElseIf ds.Tables(0).Rows(0).Item("lossHist").ToString() = "No" Then
            '    rpdffield = myPDFFields.Fields("Claim Free for at least one year")
            '    DirectCast(rpdffield, TallComponents.PDF.Forms.Fields.RadioButtonField).RadioButtonValue = rpdffield.Options(1)

            'End If


            ''pdffield = myPDFFields.Fields("Park Name")

            'If ds.Tables(0).Rows(0).Item("ARIng1").ToString() = "Yes" Then

            '    pdffield = myPDFFields.Fields("ArIng1")
            '    DirectCast(pdffield, TallComponents.PDF.Forms.Fields.CheckBoxField).CheckBoxValue = CheckState.On
            'ElseIf ds.Tables(0).Rows(0).Item("ARIng1").ToString() = "No" Then
            '    pdffield = myPDFFields.Fields("ArIng1-1")
            '    DirectCast(pdffield, TallComponents.PDF.Forms.Fields.CheckBoxField).CheckBoxValue = CheckState.On

            'End If

            'If ds.Tables(0).Rows(0).Item("ARIng2").ToString() = "Yes" Then

            '    pdffield = myPDFFields.Fields("ArIng2")
            '    DirectCast(pdffield, TallComponents.PDF.Forms.Fields.CheckBoxField).CheckBoxValue = CheckState.On
            'ElseIf ds.Tables(0).Rows(0).Item("ARIng2").ToString() = "No" Then
            '    pdffield = myPDFFields.Fields("ArIng2-1")
            '    DirectCast(pdffield, TallComponents.PDF.Forms.Fields.CheckBoxField).CheckBoxValue = CheckState.On

            'End If
            'If ds.Tables(0).Rows(0).Item("ARIng3").ToString() = "Yes" Then

            '    pdffield = myPDFFields.Fields("ArIng3")
            '    DirectCast(pdffield, TallComponents.PDF.Forms.Fields.CheckBoxField).CheckBoxValue = CheckState.On
            'ElseIf ds.Tables(0).Rows(0).Item("ARIng3").ToString() = "No" Then
            '    pdffield = myPDFFields.Fields("ArIng3-1")
            '    DirectCast(pdffield, TallComponents.PDF.Forms.Fields.CheckBoxField).CheckBoxValue = CheckState.On

            'End If

            'If ds.Tables(0).Rows(0).Item("ARIng4").ToString() = "Yes" Then

            '    pdffield = myPDFFields.Fields("ArIng4")
            '    DirectCast(pdffield, TallComponents.PDF.Forms.Fields.CheckBoxField).CheckBoxValue = CheckState.On
            'ElseIf ds.Tables(0).Rows(0).Item("ARIng4").ToString() = "No" Then
            '    pdffield = myPDFFields.Fields("ArIng4-1")
            '    DirectCast(pdffield, TallComponents.PDF.Forms.Fields.CheckBoxField).CheckBoxValue = CheckState.On

            'End If

            'If ds.Tables(0).Rows(0).Item("ARIng5").ToString() = "Yes" Then

            '    pdffield = myPDFFields.Fields("ArIng5")
            '    DirectCast(pdffield, TallComponents.PDF.Forms.Fields.CheckBoxField).CheckBoxValue = CheckState.On
            'ElseIf ds.Tables(0).Rows(0).Item("ARIng5").ToString() = "No" Then
            '    pdffield = myPDFFields.Fields("ArIng5-1")
            '    DirectCast(pdffield, TallComponents.PDF.Forms.Fields.CheckBoxField).CheckBoxValue = CheckState.On

            'End If
            'If ds.Tables(0).Rows(0).Item("ARIng6").ToString() = "Yes" Then

            '    pdffield = myPDFFields.Fields("ArIng6")
            '    DirectCast(pdffield, TallComponents.PDF.Forms.Fields.CheckBoxField).CheckBoxValue = CheckState.On
            'ElseIf ds.Tables(0).Rows(0).Item("ARIng6").ToString() = "No" Then
            '    pdffield = myPDFFields.Fields("ArIng6-1")
            '    DirectCast(pdffield, TallComponents.PDF.Forms.Fields.CheckBoxField).CheckBoxValue = CheckState.On

            'End If
            'If ds.Tables(0).Rows(0).Item("ARIng7").ToString() = "Yes" Then

            '    pdffield = myPDFFields.Fields("ArIng7")
            '    DirectCast(pdffield, TallComponents.PDF.Forms.Fields.CheckBoxField).CheckBoxValue = CheckState.On
            'ElseIf ds.Tables(0).Rows(0).Item("ARIng7").ToString() = "No" Then
            '    pdffield = myPDFFields.Fields("ArIng7-1")
            '    DirectCast(pdffield, TallComponents.PDF.Forms.Fields.CheckBoxField).CheckBoxValue = CheckState.On

            'End If
            'If ds.Tables(0).Rows(0).Item("ARIng8").ToString() = "Yes" Then

            '    pdffield = myPDFFields.Fields("ArIng8")
            '    DirectCast(pdffield, TallComponents.PDF.Forms.Fields.CheckBoxField).CheckBoxValue = CheckState.On
            'ElseIf ds.Tables(0).Rows(0).Item("ARIng8").ToString() = "No" Then
            '    pdffield = myPDFFields.Fields("ArIng8-1")
            '    DirectCast(pdffield, TallComponents.PDF.Forms.Fields.CheckBoxField).CheckBoxValue = CheckState.On

            'End If

            'If ds.Tables(0).Rows(0).Item("ARIng9").ToString() = "Yes" Then

            '    pdffield = myPDFFields.Fields("ArIng9")
            '    DirectCast(pdffield, TallComponents.PDF.Forms.Fields.CheckBoxField).CheckBoxValue = CheckState.On
            'ElseIf ds.Tables(0).Rows(0).Item("ARIng9").ToString() = "No" Then
            '    pdffield = myPDFFields.Fields("ArIng9-1")
            '    DirectCast(pdffield, TallComponents.PDF.Forms.Fields.CheckBoxField).CheckBoxValue = CheckState.On

            'End If
            'If ds.Tables(0).Rows(0).Item("ARIng10").ToString() = "Yes" Then

            '    pdffield = myPDFFields.Fields("ArIng10")
            '    DirectCast(pdffield, TallComponents.PDF.Forms.Fields.CheckBoxField).CheckBoxValue = CheckState.On
            'ElseIf ds.Tables(0).Rows(0).Item("ARIng10").ToString() = "No" Then
            '    pdffield = myPDFFields.Fields("ArIng10-1")
            '    DirectCast(pdffield, TallComponents.PDF.Forms.Fields.CheckBoxField).CheckBoxValue = CheckState.On

            'End If
            'If ds.Tables(0).Rows(0).Item("ARIng11").ToString() = "Yes" Then

            '    pdffield = myPDFFields.Fields("ArIng11")
            '    DirectCast(pdffield, TallComponents.PDF.Forms.Fields.CheckBoxField).CheckBoxValue = CheckState.On
            'ElseIf ds.Tables(0).Rows(0).Item("ARIng11").ToString() = "No" Then
            '    pdffield = myPDFFields.Fields("ArIng11-1")
            '    DirectCast(pdffield, TallComponents.PDF.Forms.Fields.CheckBoxField).CheckBoxValue = CheckState.On

            'End If
            'If ds.Tables(0).Rows(0).Item("ARIng12").ToString() = "Yes" Then

            '    pdffield = myPDFFields.Fields("ArIng12")
            '    DirectCast(pdffield, TallComponents.PDF.Forms.Fields.CheckBoxField).CheckBoxValue = CheckState.On
            'ElseIf ds.Tables(0).Rows(0).Item("ARIng12").ToString() = "No" Then
            '    pdffield = myPDFFields.Fields("ArIng12-1")
            '    DirectCast(pdffield, TallComponents.PDF.Forms.Fields.CheckBoxField).CheckBoxValue = CheckState.On

            'End If
            'If ds.Tables(0).Rows(0).Item("ARIng13").ToString() = "Yes" Then

            '    pdffield = myPDFFields.Fields("ArIng13")
            '    DirectCast(pdffield, TallComponents.PDF.Forms.Fields.CheckBoxField).CheckBoxValue = CheckState.On
            'ElseIf ds.Tables(0).Rows(0).Item("ARIng13").ToString() = "No" Then
            '    pdffield = myPDFFields.Fields("ArIng13-1")
            '    DirectCast(pdffield, TallComponents.PDF.Forms.Fields.CheckBoxField).CheckBoxValue = CheckState.On

            'End If
            'If ds.Tables(0).Rows(0).Item("ARIng14").ToString() = "Yes" Then

            '    pdffield = myPDFFields.Fields("ArIng14")
            '    DirectCast(pdffield, TallComponents.PDF.Forms.Fields.CheckBoxField).CheckBoxValue = CheckState.On
            'ElseIf ds.Tables(0).Rows(0).Item("ARIng14").ToString() = "No" Then
            '    pdffield = myPDFFields.Fields("ArIng14-1")
            '    DirectCast(pdffield, TallComponents.PDF.Forms.Fields.CheckBoxField).CheckBoxValue = CheckState.On

            'End If
            'If ds.Tables(0).Rows(0).Item("ARIng15").ToString() = "Yes" Then

            '    pdffield = myPDFFields.Fields("ArIng15")
            '    DirectCast(pdffield, TallComponents.PDF.Forms.Fields.CheckBoxField).CheckBoxValue = CheckState.On
            'ElseIf ds.Tables(0).Rows(0).Item("ARIng15").ToString() = "No" Then
            '    pdffield = myPDFFields.Fields("ArIng15-1")
            '    DirectCast(pdffield, TallComponents.PDF.Forms.Fields.CheckBoxField).CheckBoxValue = CheckState.On

            'End If
            'If ds.Tables(0).Rows(0).Item("ARIng16").ToString() = "Yes" Then

            '    pdffield = myPDFFields.Fields("ArIng16")
            '    DirectCast(pdffield, TallComponents.PDF.Forms.Fields.CheckBoxField).CheckBoxValue = CheckState.On
            'ElseIf ds.Tables(0).Rows(0).Item("ARIng16").ToString() = "No" Then
            '    pdffield = myPDFFields.Fields("ArIng16-1")
            '    DirectCast(pdffield, TallComponents.PDF.Forms.Fields.CheckBoxField).CheckBoxValue = CheckState.On

            'End If
            'If ds.Tables(0).Rows(0).Item("ARIng17").ToString() = "Yes" Then

            '    pdffield = myPDFFields.Fields("ArIng17")
            '    DirectCast(pdffield, TallComponents.PDF.Forms.Fields.CheckBoxField).CheckBoxValue = CheckState.On
            'ElseIf ds.Tables(0).Rows(0).Item("ARIng17").ToString() = "No" Then
            '    pdffield = myPDFFields.Fields("ArIng17-1")
            '    DirectCast(pdffield, TallComponents.PDF.Forms.Fields.CheckBoxField).CheckBoxValue = CheckState.On

            'End If
            'If ds.Tables(0).Rows(0).Item("ARIng18").ToString() = "Yes" Then

            '    pdffield = myPDFFields.Fields("ArIng18")
            '    DirectCast(pdffield, TallComponents.PDF.Forms.Fields.CheckBoxField).CheckBoxValue = CheckState.On
            'ElseIf ds.Tables(0).Rows(0).Item("ARIng18").ToString() = "No" Then
            '    pdffield = myPDFFields.Fields("ArIng18-1")
            '    DirectCast(pdffield, TallComponents.PDF.Forms.Fields.CheckBoxField).CheckBoxValue = CheckState.On

            'End If
            'If ds.Tables(0).Rows(0).Item("ARIng19").ToString() = "Yes" Then

            '    pdffield = myPDFFields.Fields("ArIng19")
            '    DirectCast(pdffield, TallComponents.PDF.Forms.Fields.CheckBoxField).CheckBoxValue = CheckState.On
            'ElseIf ds.Tables(0).Rows(0).Item("ARIng19").ToString() = "No" Then
            '    pdffield = myPDFFields.Fields("ArIng19-1")
            '    DirectCast(pdffield, TallComponents.PDF.Forms.Fields.CheckBoxField).CheckBoxValue = CheckState.On

            'End If
            'If ds.Tables(0).Rows(0).Item("ARIng20").ToString() = "Yes" Then

            '    pdffield = myPDFFields.Fields("ArIng20")
            '    DirectCast(pdffield, TallComponents.PDF.Forms.Fields.CheckBoxField).CheckBoxValue = CheckState.On
            'ElseIf ds.Tables(0).Rows(0).Item("ARIng20").ToString() = "No" Then
            '    pdffield = myPDFFields.Fields("ArIng20-1")
            '    DirectCast(pdffield, TallComponents.PDF.Forms.Fields.CheckBoxField).CheckBoxValue = CheckState.On

            'End If
            'If ds.Tables(0).Rows(0).Item("ARIng21").ToString() = "Yes" Then

            '    pdffield = myPDFFields.Fields("ArIng21")
            '    DirectCast(pdffield, TallComponents.PDF.Forms.Fields.CheckBoxField).CheckBoxValue = CheckState.On
            'ElseIf ds.Tables(0).Rows(0).Item("ARIng21").ToString() = "No" Then
            '    pdffield = myPDFFields.Fields("ArIng21-1")
            '    DirectCast(pdffield, TallComponents.PDF.Forms.Fields.CheckBoxField).CheckBoxValue = CheckState.On

            'End If
            'If ds.Tables(0).Rows(0).Item("ARIng22").ToString() = "Yes" Then

            '    pdffield = myPDFFields.Fields("ArIng22")
            '    DirectCast(pdffield, TallComponents.PDF.Forms.Fields.CheckBoxField).CheckBoxValue = CheckState.On
            'ElseIf ds.Tables(0).Rows(0).Item("ARIng22").ToString() = "No" Then
            '    pdffield = myPDFFields.Fields("ArIng22-1")
            '    DirectCast(pdffield, TallComponents.PDF.Forms.Fields.CheckBoxField).CheckBoxValue = CheckState.On

            'End If
            'If ds.Tables(0).Rows(0).Item("ARIng23").ToString() = "Yes" Then

            '    pdffield = myPDFFields.Fields("ArIng23")
            '    DirectCast(pdffield, TallComponents.PDF.Forms.Fields.CheckBoxField).CheckBoxValue = CheckState.On
            'ElseIf ds.Tables(0).Rows(0).Item("ARIng23").ToString() = "No" Then
            '    pdffield = myPDFFields.Fields("ArIng23-1")
            '    DirectCast(pdffield, TallComponents.PDF.Forms.Fields.CheckBoxField).CheckBoxValue = CheckState.On

            'End If
            'If ds.Tables(0).Rows(0).Item("ARIng24").ToString() = "Yes" Then

            '    pdffield = myPDFFields.Fields("ArIng24")
            '    DirectCast(pdffield, TallComponents.PDF.Forms.Fields.CheckBoxField).CheckBoxValue = CheckState.On
            'ElseIf ds.Tables(0).Rows(0).Item("ARIng24").ToString() = "No" Then
            '    pdffield = myPDFFields.Fields("ArIng24-1")
            '    DirectCast(pdffield, TallComponents.PDF.Forms.Fields.CheckBoxField).CheckBoxValue = CheckState.On

            'End If
            'If ds.Tables(0).Rows(0).Item("ARIng25").ToString() = "Yes" Then

            '    pdffield = myPDFFields.Fields("ArIng25")
            '    DirectCast(pdffield, TallComponents.PDF.Forms.Fields.CheckBoxField).CheckBoxValue = CheckState.On
            'ElseIf ds.Tables(0).Rows(0).Item("ARIng25").ToString() = "No" Then
            '    pdffield = myPDFFields.Fields("ArIng25-1")
            '    DirectCast(pdffield, TallComponents.PDF.Forms.Fields.CheckBoxField).CheckBoxValue = CheckState.On

            'End If
            'If ds.Tables(0).Rows(0).Item("ARIng26").ToString() = "Yes" Then

            '    pdffield = myPDFFields.Fields("ArIng26")
            '    DirectCast(pdffield, TallComponents.PDF.Forms.Fields.CheckBoxField).CheckBoxValue = CheckState.On
            'ElseIf ds.Tables(0).Rows(0).Item("ARIng26").ToString() = "No" Then
            '    pdffield = myPDFFields.Fields("ArIng26-1")
            '    DirectCast(pdffield, TallComponents.PDF.Forms.Fields.CheckBoxField).CheckBoxValue = CheckState.On

            'End If
            'If ds.Tables(0).Rows(0).Item("ARIng27").ToString() = "Yes" Then

            '    pdffield = myPDFFields.Fields("ArIng27")
            '    DirectCast(pdffield, TallComponents.PDF.Forms.Fields.CheckBoxField).CheckBoxValue = CheckState.On
            'ElseIf ds.Tables(0).Rows(0).Item("ARIng27").ToString() = "No" Then
            '    pdffield = myPDFFields.Fields("ArIng27-1")
            '    DirectCast(pdffield, TallComponents.PDF.Forms.Fields.CheckBoxField).CheckBoxValue = CheckState.On

            'End If
            'If ds.Tables(0).Rows(0).Item("ARIng28").ToString() = "Yes" Then

            '    pdffield = myPDFFields.Fields("ArIng28")
            '    DirectCast(pdffield, TallComponents.PDF.Forms.Fields.CheckBoxField).CheckBoxValue = CheckState.On
            'ElseIf ds.Tables(0).Rows(0).Item("ARIng28").ToString() = "No" Then
            '    pdffield = myPDFFields.Fields("ArIng28-1")
            '    DirectCast(pdffield, TallComponents.PDF.Forms.Fields.CheckBoxField).CheckBoxValue = CheckState.On

            'End If
            'If ds.Tables(0).Rows(0).Item("ARIng29").ToString() = "Yes" Then

            '    pdffield = myPDFFields.Fields("ArIng29")
            '    DirectCast(pdffield, TallComponents.PDF.Forms.Fields.CheckBoxField).CheckBoxValue = CheckState.On
            'ElseIf ds.Tables(0).Rows(0).Item("ARIng29").ToString() = "No" Then
            '    pdffield = myPDFFields.Fields("ArIng29-1")
            '    DirectCast(pdffield, TallComponents.PDF.Forms.Fields.CheckBoxField).CheckBoxValue = CheckState.On

            'End If
            'If ds.Tables(0).Rows(0).Item("ARIng30").ToString() = "Yes" Then

            '    pdffield = myPDFFields.Fields("ArIng30")
            '    DirectCast(pdffield, TallComponents.PDF.Forms.Fields.CheckBoxField).CheckBoxValue = CheckState.On
            'ElseIf ds.Tables(0).Rows(0).Item("ARIng30").ToString() = "No" Then
            '    pdffield = myPDFFields.Fields("ArIng30-1")
            '    DirectCast(pdffield, TallComponents.PDF.Forms.Fields.CheckBoxField).CheckBoxValue = CheckState.On

            'End If
            'If ds.Tables(0).Rows(0).Item("ARIng31").ToString() = "Yes" Then

            '    pdffield = myPDFFields.Fields("ArIng31")
            '    DirectCast(pdffield, TallComponents.PDF.Forms.Fields.CheckBoxField).CheckBoxValue = CheckState.On
            'ElseIf ds.Tables(0).Rows(0).Item("ARIng31").ToString() = "No" Then
            '    pdffield = myPDFFields.Fields("ArIng31-1")
            '    DirectCast(pdffield, TallComponents.PDF.Forms.Fields.CheckBoxField).CheckBoxValue = CheckState.On

            'End If
            'If ds.Tables(0).Rows(0).Item("ARIng32").ToString() = "Yes" Then

            '    pdffield = myPDFFields.Fields("ArIng32")
            '    DirectCast(pdffield, TallComponents.PDF.Forms.Fields.CheckBoxField).CheckBoxValue = CheckState.On
            'ElseIf ds.Tables(0).Rows(0).Item("ARIng32").ToString() = "No" Then
            '    pdffield = myPDFFields.Fields("ArIng32-1")
            '    DirectCast(pdffield, TallComponents.PDF.Forms.Fields.CheckBoxField).CheckBoxValue = CheckState.On

            'End If
            'If ds.Tables(0).Rows(0).Item("ARIng33").ToString() = "Yes" Then

            '    pdffield = myPDFFields.Fields("ArIng33")
            '    DirectCast(pdffield, TallComponents.PDF.Forms.Fields.CheckBoxField).CheckBoxValue = CheckState.On
            'ElseIf ds.Tables(0).Rows(0).Item("ARIng33").ToString() = "No" Then
            '    pdffield = myPDFFields.Fields("ArIng33-1")
            '    DirectCast(pdffield, TallComponents.PDF.Forms.Fields.CheckBoxField).CheckBoxValue = CheckState.On

            'End If
            'If ds.Tables(0).Rows(0).Item("ARIng34").ToString() = "Yes" Then

            '    pdffield = myPDFFields.Fields("ArIng34")
            '    DirectCast(pdffield, TallComponents.PDF.Forms.Fields.CheckBoxField).CheckBoxValue = CheckState.On
            'ElseIf ds.Tables(0).Rows(0).Item("ARIng34").ToString() = "No" Then
            '    pdffield = myPDFFields.Fields("ArIng34-1")
            '    DirectCast(pdffield, TallComponents.PDF.Forms.Fields.CheckBoxField).CheckBoxValue = CheckState.On

            'End If
            'If ds.Tables(0).Rows(0).Item("ARIng35").ToString() = "Yes" Then

            '    pdffield = myPDFFields.Fields("ArIng35")
            '    DirectCast(pdffield, TallComponents.PDF.Forms.Fields.CheckBoxField).CheckBoxValue = CheckState.On
            'ElseIf ds.Tables(0).Rows(0).Item("ARIng35").ToString() = "No" Then
            '    pdffield = myPDFFields.Fields("ArIng35-1")
            '    DirectCast(pdffield, TallComponents.PDF.Forms.Fields.CheckBoxField).CheckBoxValue = CheckState.On

            'End If
            'If ds.Tables(0).Rows(0).Item("ARIng36").ToString() = "Yes" Then

            '    pdffield = myPDFFields.Fields("ArIng36")
            '    DirectCast(pdffield, TallComponents.PDF.Forms.Fields.CheckBoxField).CheckBoxValue = CheckState.On
            'ElseIf ds.Tables(0).Rows(0).Item("ARIng36").ToString() = "No" Then
            '    pdffield = myPDFFields.Fields("ArIng36-1")
            '    DirectCast(pdffield, TallComponents.PDF.Forms.Fields.CheckBoxField).CheckBoxValue = CheckState.On

            'End If
            'If ds.Tables(0).Rows(0).Item("ARIng37").ToString() = "Yes" Then

            '    pdffield = myPDFFields.Fields("ArIng37")
            '    DirectCast(pdffield, TallComponents.PDF.Forms.Fields.CheckBoxField).CheckBoxValue = CheckState.On
            'ElseIf ds.Tables(0).Rows(0).Item("ARIng37").ToString() = "No" Then
            '    pdffield = myPDFFields.Fields("ArIng37-1")
            '    DirectCast(pdffield, TallComponents.PDF.Forms.Fields.CheckBoxField).CheckBoxValue = CheckState.On

            'End If
            'If ds.Tables(0).Rows(0).Item("ARIng38").ToString() = "Yes" Then

            '    pdffield = myPDFFields.Fields("ArIng38")
            '    DirectCast(pdffield, TallComponents.PDF.Forms.Fields.CheckBoxField).CheckBoxValue = CheckState.On
            'ElseIf ds.Tables(0).Rows(0).Item("ARIng38").ToString() = "No" Then
            '    pdffield = myPDFFields.Fields("ArIng38-1")
            '    DirectCast(pdffield, TallComponents.PDF.Forms.Fields.CheckBoxField).CheckBoxValue = CheckState.On

            'End If
            'If ds.Tables(0).Rows(0).Item("ARIng39").ToString() = "Yes" Then

            '    pdffield = myPDFFields.Fields("ArIng39")
            '    DirectCast(pdffield, TallComponents.PDF.Forms.Fields.CheckBoxField).CheckBoxValue = CheckState.On
            'ElseIf ds.Tables(0).Rows(0).Item("ARIng39").ToString() = "No" Then
            '    pdffield = myPDFFields.Fields("ArIng39-1")
            '    DirectCast(pdffield, TallComponents.PDF.Forms.Fields.CheckBoxField).CheckBoxValue = CheckState.On

            'End If
            'If ds.Tables(0).Rows(0).Item("ARIng40").ToString() = "Yes" Then

            '    pdffield = myPDFFields.Fields("ArIng40")
            '    DirectCast(pdffield, TallComponents.PDF.Forms.Fields.CheckBoxField).CheckBoxValue = CheckState.On
            'ElseIf ds.Tables(0).Rows(0).Item("ARIng40").ToString() = "No" Then
            '    pdffield = myPDFFields.Fields("ArIng40-1")
            '    DirectCast(pdffield, TallComponents.PDF.Forms.Fields.CheckBoxField).CheckBoxValue = CheckState.On

            'End If
            'If ds.Tables(0).Rows(0).Item("ARIng41").ToString() = "Yes" Then

            '    pdffield = myPDFFields.Fields("ArIng41")
            '    DirectCast(pdffield, TallComponents.PDF.Forms.Fields.CheckBoxField).CheckBoxValue = CheckState.On
            'ElseIf ds.Tables(0).Rows(0).Item("ARIng41").ToString() = "No" Then
            '    pdffield = myPDFFields.Fields("ArIng41-1")
            '    DirectCast(pdffield, TallComponents.PDF.Forms.Fields.CheckBoxField).CheckBoxValue = CheckState.On

            'End If
            'If ds.Tables(0).Rows(0).Item("ARIng42").ToString() = "Yes" Then

            '    pdffield = myPDFFields.Fields("ArIng42")
            '    DirectCast(pdffield, TallComponents.PDF.Forms.Fields.CheckBoxField).CheckBoxValue = CheckState.On
            'ElseIf ds.Tables(0).Rows(0).Item("ARIng42").ToString() = "No" Then
            '    pdffield = myPDFFields.Fields("ArIng42-1")
            '    DirectCast(pdffield, TallComponents.PDF.Forms.Fields.CheckBoxField).CheckBoxValue = CheckState.On

            'End If
            'If ds.Tables(0).Rows(0).Item("ARIng43").ToString() = "Yes" Then

            '    pdffield = myPDFFields.Fields("ArIng43")
            '    DirectCast(pdffield, TallComponents.PDF.Forms.Fields.CheckBoxField).CheckBoxValue = CheckState.On
            'ElseIf ds.Tables(0).Rows(0).Item("ARIng43").ToString() = "No" Then
            '    pdffield = myPDFFields.Fields("ArIng43-1")
            '    DirectCast(pdffield, TallComponents.PDF.Forms.Fields.CheckBoxField).CheckBoxValue = CheckState.On

            'End If
            ' ''Policytext.Value = "TESTING"
            ''Dim initialstxt As New TallComponents.PDF.Forms.Fields.TextField("Initials") ' = TryCast(form.Fields("Initials"), TextField)
            ''TryCast(form.Fields("Initials"), TextField).Value = "CTS"
            ' '' initialstxt.Value = "CTS"


            ''For Each myPDFField As TallComponents.PDF.Forms.Fields.Field In myPDFFields.Fields
            ''    strPDFFieldName = myPDFField.FullName

            ''    Select Case strPDFFieldName
            ''        Case "Name"
            ''            value = ds.Tables(0).Rows(0).Item("Name")
            ''            DirectCast(myPDFField, TallComponents.PDF.Forms.Fields.TextField).Value = value

            ''        Case "ArIng1"
            ''            If ds.Tables(0).Rows(0).Item("ArIng1").ToString() = "Yes" Then
            ''                DirectCast(myPDFField, TallComponents.PDF.Forms.Fields.CheckBoxField).CheckBoxValue = CheckState.On

            ''            End If

            ''        Case "ArIng1-1"
            ''            If ds.Tables(0).Rows(0).Item("ArIng1").ToString = "No" Then
            ''                DirectCast(myPDFField, TallComponents.PDF.Forms.Fields.CheckBoxField).CheckBoxValue = CheckState.On

            ''            End If



            ''    End Select
            ''Next
            'Make the PDF Flattened
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
            Stop
            Response.Write(ex.Message)
        Finally
            mySourcePDF = Nothing
            myOutputPDF = Nothing
            Response.End()
        End Try


    End Sub
End Class