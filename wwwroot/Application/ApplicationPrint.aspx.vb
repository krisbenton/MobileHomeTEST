Imports System.Data.SqlClient
Imports System.IO

Imports TallComponents.PDF.JavaScript
Imports TallComponents.PDF.Annotations.Widgets
Imports TallComponents.PDF.Forms.Fields
Public Class ApplicationPrint
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
            ds1 = Common.runQueryDS("EXEC sp_GetApplicationPrint '" & AppID & "'")
            If ds1.Tables(0).Rows.Count > 0 Then
                quoteid = ds1.Tables(0).Rows(0).Item("quoteID").ToString()
                ds2 = Common.runQueryDS("EXEC sp_getQuotePrintPrem '" & quoteid & "'")
                ds3 = Common.runQueryDS("Select * from tblQuoteCalcs where QuoteID = '" & quoteid & "'")
                ds4 = Common.runQueryDS("Select * from tblARQuotes where QuoteID = '" & quoteid & "'")
                PrintApplication(ds1, ds2, ds3, ds4)

            End If


        End If

    End Sub
    Public Sub PrintApplication(ByVal ds As System.Data.DataSet, ByVal ds2 As System.Data.DataSet, ByVal ds3 As System.Data.DataSet, ByVal ds4 As System.Data.DataSet)

        Dim myFileStream As FileStream
        Dim mySourcePDF As TallComponents.PDF.Document
        Dim myOutputPDF As TallComponents.PDF.Document
        Dim myPDFFields As New TallComponents.PDF.Document
        Dim strPDFFieldName As String = ""
        Dim value As String


        Try
            myOutputPDF = New TallComponents.PDF.Document

            myFileStream = New FileStream(Me.MapPath("~\ApplicationPages\") & "PDF\AraApp_Print.pdf", FileMode.Open, FileAccess.Read)
            'Dim form As New TallComponents.PDF.Document(myFileStream)
            mySourcePDF = New TallComponents.PDF.Document(myFileStream)
            myPDFFields.Pages.AddRange(mySourcePDF.Pages.CloneToArray())
            '  Dim form As New TallComponents.PDF.Document(myFileStream)

            myFileStream.Close()
            mySourcePDF = Nothing


            'Dim Policytext As New TallComponents.PDF.Forms.Fields.TextField("Policy")
            ''TryCast(form.Fields("Policy"), TextField).Value = "Testing"
            Dim pdffield As TallComponents.PDF.Forms.Fields.Field
            pdffield = myPDFFields.Fields("Name")
            DirectCast(pdffield, TallComponents.PDF.Forms.Fields.TextField).Value = ds.Tables(0).Rows(0).Item("Name").ToString()
            pdffield = myPDFFields.Fields("DOB")
            DirectCast(pdffield, TallComponents.PDF.Forms.Fields.TextField).Value = ds.Tables(0).Rows(0).Item("DOB").ToString()
            pdffield = myPDFFields.Fields("Address")
            DirectCast(pdffield, TallComponents.PDF.Forms.Fields.TextField).Value = ds.Tables(0).Rows(0).Item("Address").ToString()
            pdffield = myPDFFields.Fields("InsCity")
            DirectCast(pdffield, TallComponents.PDF.Forms.Fields.TextField).Value = ds.Tables(0).Rows(0).Item("City").ToString()
            pdffield = myPDFFields.Fields("InsState")
            DirectCast(pdffield, TallComponents.PDF.Forms.Fields.TextField).Value = ds.Tables(0).Rows(0).Item("State").ToString()
            pdffield = myPDFFields.Fields("InsZip")
            DirectCast(pdffield, TallComponents.PDF.Forms.Fields.TextField).Value = ds.Tables(0).Rows(0).Item("Zip").ToString()
            pdffield = myPDFFields.Fields("County")
            DirectCast(pdffield, TallComponents.PDF.Forms.Fields.TextField).Value = ds.Tables(0).Rows(0).Item("County").ToString()
            pdffield = myPDFFields.Fields("Phone No")
            DirectCast(pdffield, TallComponents.PDF.Forms.Fields.TextField).Value = ds.Tables(0).Rows(0).Item("Phone").ToString()
            pdffield = myPDFFields.Fields("Occupation")
            DirectCast(pdffield, TallComponents.PDF.Forms.Fields.TextField).Value = ds.Tables(0).Rows(0).Item("Occ").ToString()
            pdffield = myPDFFields.Fields("Social Security")
            DirectCast(pdffield, TallComponents.PDF.Forms.Fields.TextField).Value = ds.Tables(0).Rows(0).Item("SSN").ToString()
            pdffield = myPDFFields.Fields("Spouse Name")
            DirectCast(pdffield, TallComponents.PDF.Forms.Fields.TextField).Value = ds.Tables(0).Rows(0).Item("SpouseName").ToString()
            pdffield = myPDFFields.Fields("Spouse Social Security")
            DirectCast(pdffield, TallComponents.PDF.Forms.Fields.TextField).Value = ds.Tables(0).Rows(0).Item("SpouseSSN").ToString()
            pdffield = myPDFFields.Fields("DOB_2")
            DirectCast(pdffield, TallComponents.PDF.Forms.Fields.TextField).Value = ds.Tables(0).Rows(0).Item("SpouseDOB").ToString()
            pdffield = myPDFFields.Fields("Addl Insured")
            DirectCast(pdffield, TallComponents.PDF.Forms.Fields.TextField).Value = ds.Tables(0).Rows(0).Item("AddInsuredName").ToString()

            pdffield = myPDFFields.Fields("Address if different than above include county and zip")
            DirectCast(pdffield, TallComponents.PDF.Forms.Fields.TextField).Value = ds.Tables(0).Rows(0).Item("Address").ToString() & vbCrLf & ds.Tables(0).Rows(0).Item("City").ToString() & ", " & ds.Tables(0).Rows(0).Item("State").ToString() & "  " & ds.Tables(0).Rows(0).Item("Zip").ToString()


            pdffield = myPDFFields.Fields("Address_2")
            DirectCast(pdffield, TallComponents.PDF.Forms.Fields.TextField).Value = ds.Tables(0).Rows(0).Item("DiffAppAddr").ToString()
            pdffield = myPDFFields.Fields("SpouseCity")
            DirectCast(pdffield, TallComponents.PDF.Forms.Fields.TextField).Value = ds.Tables(0).Rows(0).Item("DiffAppCity").ToString()
            pdffield = myPDFFields.Fields("SpouseState")
            DirectCast(pdffield, TallComponents.PDF.Forms.Fields.TextField).Value = ds.Tables(0).Rows(0).Item("DiffAppState").ToString()
            pdffield = myPDFFields.Fields("SpouseZip")
            DirectCast(pdffield, TallComponents.PDF.Forms.Fields.TextField).Value = ds.Tables(0).Rows(0).Item("DiffAppZip").ToString()
            pdffield = myPDFFields.Fields("Name_2")
            DirectCast(pdffield, TallComponents.PDF.Forms.Fields.TextField).Value = ds.Tables(0).Rows(0).Item("Lien1Name").ToString()
            pdffield = myPDFFields.Fields("Loan")
            DirectCast(pdffield, TallComponents.PDF.Forms.Fields.TextField).Value = ds.Tables(0).Rows(0).Item("Lien1Num").ToString()
            pdffield = myPDFFields.Fields("Address_3")
            DirectCast(pdffield, TallComponents.PDF.Forms.Fields.TextField).Value = ds.Tables(0).Rows(0).Item("Lien1Addr").ToString()
            pdffield = myPDFFields.Fields("LienCity1")
            DirectCast(pdffield, TallComponents.PDF.Forms.Fields.TextField).Value = ds.Tables(0).Rows(0).Item("Lien1City").ToString()
            pdffield = myPDFFields.Fields("lienState1")
            DirectCast(pdffield, TallComponents.PDF.Forms.Fields.TextField).Value = ds.Tables(0).Rows(0).Item("Lien1State").ToString()
            pdffield = myPDFFields.Fields("LienZip1")
            DirectCast(pdffield, TallComponents.PDF.Forms.Fields.TextField).Value = ds.Tables(0).Rows(0).Item("Lien1Zip").ToString()
            pdffield = myPDFFields.Fields("Agent Name Agent")
            DirectCast(pdffield, TallComponents.PDF.Forms.Fields.TextField).Value = ds.Tables(0).Rows(0).Item("AgentName").ToString()
            pdffield = myPDFFields.Fields("Municipal Tax Code")
            DirectCast(pdffield, TallComponents.PDF.Forms.Fields.TextField).Value = ds.Tables(0).Rows(0).Item("MunTaxCode").ToString()
            pdffield = myPDFFields.Fields("feet")
            DirectCast(pdffield, TallComponents.PDF.Forms.Fields.TextField).Value = ds.Tables(0).Rows(0).Item("DistToFire").ToString()
            pdffield = myPDFFields.Fields("Distance of unit to responding Fire Dept")
            DirectCast(pdffield, TallComponents.PDF.Forms.Fields.TextField).Value = ds.Tables(0).Rows(0).Item("DistToFireDept").ToString()
            pdffield = myPDFFields.Fields("Name of Fire Dept")
            DirectCast(pdffield, TallComponents.PDF.Forms.Fields.TextField).Value = ds.Tables(0).Rows(0).Item("FireDeptName").ToString()
            pdffield = myPDFFields.Fields("Park Name")
            DirectCast(pdffield, TallComponents.PDF.Forms.Fields.TextField).Value = ds.Tables(0).Rows(0).Item("ParkName").ToString()
            'Lien 2
            pdffield = myPDFFields.Fields("Name_3")
            DirectCast(pdffield, TallComponents.PDF.Forms.Fields.TextField).Value = ds.Tables(0).Rows(0).Item("Lien2Name").ToString()
            pdffield = myPDFFields.Fields("Loan_2")
            DirectCast(pdffield, TallComponents.PDF.Forms.Fields.TextField).Value = ds.Tables(0).Rows(0).Item("Lien2Num").ToString()
            pdffield = myPDFFields.Fields("Address_4")
            DirectCast(pdffield, TallComponents.PDF.Forms.Fields.TextField).Value = ds.Tables(0).Rows(0).Item("Lien2Addr").ToString()
            pdffield = myPDFFields.Fields("LienCity2")
            DirectCast(pdffield, TallComponents.PDF.Forms.Fields.TextField).Value = ds.Tables(0).Rows(0).Item("Lien2City").ToString()
            pdffield = myPDFFields.Fields("LienState2")
            DirectCast(pdffield, TallComponents.PDF.Forms.Fields.TextField).Value = ds.Tables(0).Rows(0).Item("Lien2State").ToString()
            pdffield = myPDFFields.Fields("LienZip2")
            DirectCast(pdffield, TallComponents.PDF.Forms.Fields.TextField).Value = ds.Tables(0).Rows(0).Item("Lien2Zip").ToString()


            If ds.Tables(0).Rows(0).Item("ctylimits").ToString() = "Yes" Then
                pdffield = myPDFFields.Fields("undefined_2")
                DirectCast(pdffield, TallComponents.PDF.Forms.Fields.CheckBoxField).CheckBoxValue = CheckState.On
            ElseIf ds.Tables(0).Rows(0).Item("ctylimits").ToString() = "No" Then
                pdffield = myPDFFields.Fields("undefined_3")
                DirectCast(pdffield, TallComponents.PDF.Forms.Fields.CheckBoxField).CheckBoxValue = CheckState.On
            End If
            If ds.Tables(0).Rows(0).Item("fwua").ToString() = "Yes" Then
                pdffield = myPDFFields.Fields("undefined_4")
                DirectCast(pdffield, TallComponents.PDF.Forms.Fields.CheckBoxField).CheckBoxValue = CheckState.On
            ElseIf ds.Tables(0).Rows(0).Item("fwua").ToString() = "No" Then
                pdffield = myPDFFields.Fields("undefined_5")
                DirectCast(pdffield, TallComponents.PDF.Forms.Fields.CheckBoxField).CheckBoxValue = CheckState.On
            End If
            pdffield = myPDFFields.Fields("undefined_6")
            DirectCast(pdffield, TallComponents.PDF.Forms.Fields.TextField).Value = ds.Tables(0).Rows(0).Item("DistToGulf").ToString()
            pdffield = myPDFFields.Fields("Year")
            DirectCast(pdffield, TallComponents.PDF.Forms.Fields.TextField).Value = ds.Tables(0).Rows(0).Item("DescMHYear").ToString()

            pdffield = myPDFFields.Fields("ManufacturerModel")
            DirectCast(pdffield, TallComponents.PDF.Forms.Fields.TextField).Value = ds.Tables(0).Rows(0).Item("DescMHManf").ToString()
            pdffield = myPDFFields.Fields("Length")
            DirectCast(pdffield, TallComponents.PDF.Forms.Fields.TextField).Value = ds.Tables(0).Rows(0).Item("DescMHLength").ToString()
            pdffield = myPDFFields.Fields("Width")
            DirectCast(pdffield, TallComponents.PDF.Forms.Fields.TextField).Value = ds.Tables(0).Rows(0).Item("DescMHWidth").ToString()
            pdffield = myPDFFields.Fields("Serial Number")
            DirectCast(pdffield, TallComponents.PDF.Forms.Fields.TextField).Value = ds.Tables(0).Rows(0).Item("DescMHSerial").ToString()
            pdffield = myPDFFields.Fields("Purchase Date")
            DirectCast(pdffield, TallComponents.PDF.Forms.Fields.TextField).Value = ds.Tables(0).Rows(0).Item("DescMHPurDate").ToString()
            pdffield = myPDFFields.Fields("Describe AdditionsAttached Structures")
            DirectCast(pdffield, TallComponents.PDF.Forms.Fields.TextField).Value = ds.Tables(0).Rows(0).Item("DescMHAttStruc").ToString()
            pdffield = myPDFFields.Fields("Age")
            DirectCast(pdffield, TallComponents.PDF.Forms.Fields.TextField).Value = ds.Tables(0).Rows(0).Item("DescMHAttStrucAge").ToString()
            pdffield = myPDFFields.Fields("Size")
            DirectCast(pdffield, TallComponents.PDF.Forms.Fields.TextField).Value = ds.Tables(0).Rows(0).Item("DescMHAttStrucSize").ToString()
            pdffield = myPDFFields.Fields("fill_60")
            DirectCast(pdffield, TallComponents.PDF.Forms.Fields.TextField).Value = ds.Tables(0).Rows(0).Item("DescMHAttStrucCurVal").ToString()
            pdffield = myPDFFields.Fields("Describe Unattached Structures")
            DirectCast(pdffield, TallComponents.PDF.Forms.Fields.TextField).Value = ds.Tables(0).Rows(0).Item("DescMHUnAttStruc").ToString()
            pdffield = myPDFFields.Fields("Age_2")
            DirectCast(pdffield, TallComponents.PDF.Forms.Fields.TextField).Value = ds.Tables(0).Rows(0).Item("DescMHUnAttStrucAge").ToString()
            pdffield = myPDFFields.Fields("Size_2")
            DirectCast(pdffield, TallComponents.PDF.Forms.Fields.TextField).Value = ds.Tables(0).Rows(0).Item("DescMHUnAttStrucSize").ToString()
            pdffield = myPDFFields.Fields("fill_61")
            DirectCast(pdffield, TallComponents.PDF.Forms.Fields.TextField).Value = ds.Tables(0).Rows(0).Item("DescMHUnAttStrucCurVal").ToString()
            'Purchase Price
            pdffield = myPDFFields.Fields("purchasePrice")
            DirectCast(pdffield, TallComponents.PDF.Forms.Fields.TextField).Value = ds.Tables(0).Rows(0).Item("DescMHPurPrice").ToString()
            'Current Value
            pdffield = myPDFFields.Fields("Current Value")
            DirectCast(pdffield, TallComponents.PDF.Forms.Fields.TextField).Value = ds.Tables(0).Rows(0).Item("MHValue").ToString()

            Select Case ds.Tables(0).Rows(0).Item("Program").ToString()
                Case "Package"
                    pdffield = myPDFFields.Fields("Package")
                    DirectCast(pdffield, TallComponents.PDF.Forms.Fields.CheckBoxField).CheckBoxValue = CheckState.On
                Case "Rental"
                    pdffield = myPDFFields.Fields("Rental")
                    DirectCast(pdffield, TallComponents.PDF.Forms.Fields.CheckBoxField).CheckBoxValue = CheckState.On
                Case "Standard"
                    pdffield = myPDFFields.Fields("Standard")
                    DirectCast(pdffield, TallComponents.PDF.Forms.Fields.CheckBoxField).CheckBoxValue = CheckState.On
                Case "Commercial"
                    pdffield = myPDFFields.Fields("Commercial")
                    DirectCast(pdffield, TallComponents.PDF.Forms.Fields.CheckBoxField).CheckBoxValue = CheckState.On
                Case "Preferred"
                    pdffield = myPDFFields.Fields("Preferred")
                    DirectCast(pdffield, TallComponents.PDF.Forms.Fields.CheckBoxField).CheckBoxValue = CheckState.On
                Case "Tenant"
                    pdffield = myPDFFields.Fields("Tenant")
                    DirectCast(pdffield, TallComponents.PDF.Forms.Fields.CheckBoxField).CheckBoxValue = CheckState.On

            End Select
            Select Case ds.Tables(0).Rows(0).Item("Usage").ToString()
                Case "Permanent"
                    pdffield = myPDFFields.Fields("Permanent")
                    DirectCast(pdffield, TallComponents.PDF.Forms.Fields.CheckBoxField).CheckBoxValue = CheckState.On
                Case "Seasonal"
                    pdffield = myPDFFields.Fields("Seasonal")
                    DirectCast(pdffield, TallComponents.PDF.Forms.Fields.CheckBoxField).CheckBoxValue = CheckState.On
                Case "Rental"
                    pdffield = myPDFFields.Fields("Rental_2")
                    DirectCast(pdffield, TallComponents.PDF.Forms.Fields.CheckBoxField).CheckBoxValue = CheckState.On
                Case "Commercial"
                    pdffield = myPDFFields.Fields("Commercial_2")
                    DirectCast(pdffield, TallComponents.PDF.Forms.Fields.CheckBoxField).CheckBoxValue = CheckState.On
                Case "Tenant"
                    pdffield = myPDFFields.Fields("Tenant_2")
                    DirectCast(pdffield, TallComponents.PDF.Forms.Fields.CheckBoxField).CheckBoxValue = CheckState.On


            End Select
            'protected
            If ds.Tables(0).Rows(0).Item("Protection").ToString() = "Yes" Then
                pdffield = myPDFFields.Fields("undefined_9")
                DirectCast(pdffield, TallComponents.PDF.Forms.Fields.CheckBoxField).CheckBoxValue = CheckState.On
            Else
                pdffield = myPDFFields.Fields("undefined_10")
                DirectCast(pdffield, TallComponents.PDF.Forms.Fields.CheckBoxField).CheckBoxValue = CheckState.On
            End If
            pdffield = myPDFFields.Fields("undefined_11")
            DirectCast(pdffield, TallComponents.PDF.Forms.Fields.TextField).Value = ds.Tables(0).Rows(0).Item("InsAge").ToString()
            'age of mobile home
            Select Case ds.Tables(0).Rows(0).Item("MHAge").ToString()
                Case "1-5 Yrs"
                    pdffield = myPDFFields.Fields("1  5 Yrs")
                    DirectCast(pdffield, TallComponents.PDF.Forms.Fields.CheckBoxField).CheckBoxValue = CheckState.On

                Case "6-15 Yrs"
                    pdffield = myPDFFields.Fields("6  15 Yrs")
                    DirectCast(pdffield, TallComponents.PDF.Forms.Fields.CheckBoxField).CheckBoxValue = CheckState.On

                Case "16 Yrs & Older"
                    pdffield = myPDFFields.Fields("16 Yrs  Older")
                    DirectCast(pdffield, TallComponents.PDF.Forms.Fields.CheckBoxField).CheckBoxValue = CheckState.On

            End Select
            'Loss History
            Dim rpdffield As TallComponents.PDF.Forms.Fields.RadioButtonField
            If ds.Tables(0).Rows(0).Item("lossHist").ToString() = "Yes" Then
                rpdffield = myPDFFields.Fields("Claim Free for at least one year")
                DirectCast(rpdffield, TallComponents.PDF.Forms.Fields.RadioButtonField).RadioButtonValue = rpdffield.Options(0)

            ElseIf ds.Tables(0).Rows(0).Item("lossHist").ToString() = "No" Then
                rpdffield = myPDFFields.Fields("Claim Free for at least one year")
                DirectCast(rpdffield, TallComponents.PDF.Forms.Fields.RadioButtonField).RadioButtonValue = rpdffield.Options(1)

            End If
            'Park Status
            If ds.Tables(0).Rows(0).Item("ParkStatus").ToString() = "Yes" Then
                rpdffield = myPDFFields.Fields("PARK STATUS In a Park")
                DirectCast(rpdffield, TallComponents.PDF.Forms.Fields.RadioButtonField).RadioButtonValue = rpdffield.Options(0)
                pdffield = myPDFFields.Fields("If Yes  of Spaces")
                DirectCast(pdffield, TallComponents.PDF.Forms.Fields.TextField).Value = ds.Tables(0).Rows(0).Item("NumOfSpaces").ToString()
                pdffield = myPDFFields.Fields("of Adult")
                DirectCast(pdffield, TallComponents.PDF.Forms.Fields.TextField).Value = ds.Tables(0).Rows(0).Item("PerOfAdults").ToString()
                If ds.Tables(0).Rows(0).Item("ResManger").ToString() = "Yes" Then

                    pdffield = myPDFFields.Fields("ResManYes")
                    DirectCast(pdffield, TallComponents.PDF.Forms.Fields.CheckBoxField).CheckBoxValue = CheckState.On
                ElseIf ds.Tables(0).Rows(0).Item("ResManger").ToString() = "No" Then
                    pdffield = myPDFFields.Fields("ResManNo")
                    DirectCast(pdffield, TallComponents.PDF.Forms.Fields.CheckBoxField).CheckBoxValue = CheckState.On

                End If



            ElseIf ds.Tables(0).Rows(0).Item("ParkStatus").ToString() = "No" Then
                rpdffield = myPDFFields.Fields("PARK STATUS In a Park")
                DirectCast(rpdffield, TallComponents.PDF.Forms.Fields.RadioButtonField).RadioButtonValue = rpdffield.Options(1)
                pdffield = myPDFFields.Fields("If No  of Acres")
                DirectCast(pdffield, TallComponents.PDF.Forms.Fields.TextField).Value = ds.Tables(0).Rows(0).Item("Acres").ToString()
            End If

            'Unit Type
            Select Case ds.Tables(0).Rows(0).Item("UnitType").ToString()
                Case "Singlewide"
                    pdffield = myPDFFields.Fields("undefined_12")
                    DirectCast(pdffield, TallComponents.PDF.Forms.Fields.CheckBoxField).CheckBoxValue = CheckState.On
                Case "Doublewide"
                    pdffield = myPDFFields.Fields("undefined_13")
                    DirectCast(pdffield, TallComponents.PDF.Forms.Fields.CheckBoxField).CheckBoxValue = CheckState.On
                Case Else
                    pdffield = myPDFFields.Fields("UNIT TYPE Singlewide Doublewide Other")
                    DirectCast(pdffield, TallComponents.PDF.Forms.Fields.TextField).Value = ds.Tables(0).Rows(0).Item("UnitType").ToString()


            End Select
            'Front Steps
            If ds.Tables(0).Rows(0).Item("NumOfFrontSteps").ToString() > "" Then
                pdffield = myPDFFields.Fields("STEPS")
                DirectCast(pdffield, TallComponents.PDF.Forms.Fields.CheckBoxField).CheckBoxValue = CheckState.On
                pdffield = myPDFFields.Fields("Front Number of Steps")
                DirectCast(pdffield, TallComponents.PDF.Forms.Fields.TextField).Value = ds.Tables(0).Rows(0).Item("NumOfFrontSteps").ToString()
            End If
            'REar Steps
            If ds.Tables(0).Rows(0).Item("NumOfRearSteps").ToString() > "" Then
                pdffield = myPDFFields.Fields("undefined_15")
                DirectCast(pdffield, TallComponents.PDF.Forms.Fields.CheckBoxField).CheckBoxValue = CheckState.On
                pdffield = myPDFFields.Fields("Rear Number of Steps")
                DirectCast(pdffield, TallComponents.PDF.Forms.Fields.TextField).Value = ds.Tables(0).Rows(0).Item("NumOfRearSteps").ToString()
            End If
            'Supplemental Heating
            Select Case ds.Tables(0).Rows(0).Item("SupHeating").ToString()
                Case "None"
                    pdffield = myPDFFields.Fields("None")
                    DirectCast(pdffield, TallComponents.PDF.Forms.Fields.CheckBoxField).CheckBoxValue = CheckState.On
                Case "Woodburning Stove"
                    pdffield = myPDFFields.Fields("Woodburning Stove")
                    DirectCast(pdffield, TallComponents.PDF.Forms.Fields.CheckBoxField).CheckBoxValue = CheckState.On
                Case "Fireplace"
                    pdffield = myPDFFields.Fields("Fireplace")
                    DirectCast(pdffield, TallComponents.PDF.Forms.Fields.CheckBoxField).CheckBoxValue = CheckState.On
                Case Else
                    pdffield = myPDFFields.Fields("If No questionnaire and photos are required")
                    DirectCast(pdffield, TallComponents.PDF.Forms.Fields.CheckBoxField).CheckBoxValue = CheckState.On
                    pdffield = myPDFFields.Fields("Other")
                    DirectCast(pdffield, TallComponents.PDF.Forms.Fields.TextField).Value = ds.Tables(0).Rows(0).Item("SupHeatOther").ToString()



            End Select
            'Factory Installed
            If ds.Tables(0).Rows(0).Item("SupHeatingFacInst").ToString() = "Yes" Then
                rpdffield = myPDFFields.Fields("Is the unit factory installed")
                DirectCast(rpdffield, TallComponents.PDF.Forms.Fields.RadioButtonField).RadioButtonValue = rpdffield.Options(0)
            ElseIf ds.Tables(0).Rows(0).Item("SupHeatingFacInst").ToString() = "No" Then
                rpdffield = myPDFFields.Fields("Is the unit factory installed")
                DirectCast(rpdffield, TallComponents.PDF.Forms.Fields.RadioButtonField).RadioButtonValue = rpdffield.Options(1)

            End If
            'Satalite Dish

            If ds.Tables(0).Rows(0).Item("SatDish").ToString() = "Yes" Then

                pdffield = myPDFFields.Fields("Yes as Radio  TV Antenna Coverage")
                DirectCast(pdffield, TallComponents.PDF.Forms.Fields.CheckBoxField).CheckBoxValue = CheckState.On
            ElseIf ds.Tables(0).Rows(0).Item("SatDish").ToString() = "No" Then
                pdffield = myPDFFields.Fields("No_4")
                DirectCast(pdffield, TallComponents.PDF.Forms.Fields.CheckBoxField).CheckBoxValue = CheckState.On

            End If
            'ansi
            If ds4.Tables(0).Rows(0).Item("Ansi_Asce").ToString() = "Yes" Then

                pdffield = myPDFFields.Fields("undefined_7")
                DirectCast(pdffield, TallComponents.PDF.Forms.Fields.CheckBoxField).CheckBoxValue = CheckState.On
            Else
                pdffield = myPDFFields.Fields("undefined_8")
                DirectCast(pdffield, TallComponents.PDF.Forms.Fields.CheckBoxField).CheckBoxValue = CheckState.On

            End If
            'Prior Insurance

            If ds.Tables(0).Rows(0).Item("PriorInsurance").ToString() = "Yes" Then

                rpdffield = myPDFFields.Fields("PRIOR INSURANCE")
                DirectCast(rpdffield, TallComponents.PDF.Forms.Fields.RadioButtonField).RadioButtonValue = rpdffield.Options(0)
            ElseIf ds.Tables(0).Rows(0).Item("PriorInsurance").ToString() = "No" Then
                rpdffield = myPDFFields.Fields("PRIOR INSURANCE")
                DirectCast(rpdffield, TallComponents.PDF.Forms.Fields.RadioButtonField).RadioButtonValue = rpdffield.Options(1)
            ElseIf ds.Tables(0).Rows(0).Item("PriorInsurance").ToString() = "New Purchase" Then
                rpdffield = myPDFFields.Fields("PRIOR INSURANCE")
                DirectCast(rpdffield, TallComponents.PDF.Forms.Fields.RadioButtonField).RadioButtonValue = rpdffield.Options(2)
            End If

            'Prior Insurance Name and Years
            pdffield = myPDFFields.Fields("PRIOR COMPANY  YEARS OF INSURANCE 2")
            DirectCast(pdffield, TallComponents.PDF.Forms.Fields.TextField).Value = ds.Tables(0).Rows(0).Item("PriorCompany").ToString() & " For " & ds.Tables(0).Rows(0).Item("PriorInsYears").ToString() & " Years"
            'Protection Class
            pdffield = myPDFFields.Fields("Class")
            DirectCast(pdffield, TallComponents.PDF.Forms.Fields.TextField).Value = ds.Tables(0).Rows(0).Item("protClass").ToString()


            'Animals on Premises
            If ds.Tables(0).Rows(0).Item("Animal").ToString() = "Yes" Then
                rpdffield = myPDFFields.Fields("ANIMALS ON PREMISES")
                DirectCast(rpdffield, TallComponents.PDF.Forms.Fields.RadioButtonField).RadioButtonValue = rpdffield.Options(0)
            ElseIf ds.Tables(0).Rows(0).Item("Animal").ToString() = "No" Then
                rpdffield = myPDFFields.Fields("ANIMALS ON PREMISES")
                DirectCast(rpdffield, TallComponents.PDF.Forms.Fields.RadioButtonField).RadioButtonValue = rpdffield.Options(1)

            End If
            pdffield = myPDFFields.Fields("Type of Animal")
            DirectCast(pdffield, TallComponents.PDF.Forms.Fields.TextField).Value = ds.Tables(0).Rows(0).Item("AnimalType").ToString()
            pdffield = myPDFFields.Fields("Breed of Dog")
            DirectCast(pdffield, TallComponents.PDF.Forms.Fields.TextField).Value = ds.Tables(0).Rows(0).Item("DogBreed").ToString()
            'Territory
            pdffield = myPDFFields.Fields("TERRITORY")
            DirectCast(pdffield, TallComponents.PDF.Forms.Fields.TextField).Value = ds.Tables(0).Rows(0).Item("territory").ToString()
            'Park Name
            pdffield = myPDFFields.Fields("Park Name")
            DirectCast(pdffield, TallComponents.PDF.Forms.Fields.TextField).Value = ds.Tables(0).Rows(0).Item("ParkName").ToString()
            'Agent #
            pdffield = myPDFFields.Fields("AgentNum")
            DirectCast(pdffield, TallComponents.PDF.Forms.Fields.TextField).Value = ds.Tables(0).Rows(0).Item("AgencyCode").ToString()
            'Term From to date
            pdffield = myPDFFields.Fields("FromDate")
            DirectCast(pdffield, TallComponents.PDF.Forms.Fields.TextField).Value = ds.Tables(0).Rows(0).Item("effDate").ToString()
            pdffield = myPDFFields.Fields("ToDate")
            DirectCast(pdffield, TallComponents.PDF.Forms.Fields.TextField).Value = ds.Tables(0).Rows(0).Item("ToMonth").ToString()


            If ds.Tables(0).Rows(0).Item("ARIng1").ToString() = "Yes" Then

                pdffield = myPDFFields.Fields("ArIng1")
                DirectCast(pdffield, TallComponents.PDF.Forms.Fields.CheckBoxField).CheckBoxValue = CheckState.On
            ElseIf ds.Tables(0).Rows(0).Item("ARIng1").ToString() = "No" Then
                pdffield = myPDFFields.Fields("ArIng1-1")
                DirectCast(pdffield, TallComponents.PDF.Forms.Fields.CheckBoxField).CheckBoxValue = CheckState.On

            End If

            If ds.Tables(0).Rows(0).Item("ARIng2").ToString() = "Yes" Then

                pdffield = myPDFFields.Fields("ArIng2")
                DirectCast(pdffield, TallComponents.PDF.Forms.Fields.CheckBoxField).CheckBoxValue = CheckState.On
            ElseIf ds.Tables(0).Rows(0).Item("ARIng2").ToString() = "No" Then
                pdffield = myPDFFields.Fields("ArIng2-1")
                DirectCast(pdffield, TallComponents.PDF.Forms.Fields.CheckBoxField).CheckBoxValue = CheckState.On

            End If
            If ds.Tables(0).Rows(0).Item("ARIng3").ToString() = "Yes" Then

                pdffield = myPDFFields.Fields("ArIng3")
                DirectCast(pdffield, TallComponents.PDF.Forms.Fields.CheckBoxField).CheckBoxValue = CheckState.On
            ElseIf ds.Tables(0).Rows(0).Item("ARIng3").ToString() = "No" Then
                pdffield = myPDFFields.Fields("ArIng3-1")
                DirectCast(pdffield, TallComponents.PDF.Forms.Fields.CheckBoxField).CheckBoxValue = CheckState.On

            End If

            If ds.Tables(0).Rows(0).Item("ARIng4").ToString() = "Yes" Then

                pdffield = myPDFFields.Fields("ArIng4")
                DirectCast(pdffield, TallComponents.PDF.Forms.Fields.CheckBoxField).CheckBoxValue = CheckState.On
            ElseIf ds.Tables(0).Rows(0).Item("ARIng4").ToString() = "No" Then
                pdffield = myPDFFields.Fields("ArIng4-1")
                DirectCast(pdffield, TallComponents.PDF.Forms.Fields.CheckBoxField).CheckBoxValue = CheckState.On

            End If

            If ds.Tables(0).Rows(0).Item("ARIng5").ToString() = "Yes" Then

                pdffield = myPDFFields.Fields("ArIng5")
                DirectCast(pdffield, TallComponents.PDF.Forms.Fields.CheckBoxField).CheckBoxValue = CheckState.On
            ElseIf ds.Tables(0).Rows(0).Item("ARIng5").ToString() = "No" Then
                pdffield = myPDFFields.Fields("ArIng5-1")
                DirectCast(pdffield, TallComponents.PDF.Forms.Fields.CheckBoxField).CheckBoxValue = CheckState.On

            End If
            If ds.Tables(0).Rows(0).Item("ARIng6").ToString() = "Yes" Then

                pdffield = myPDFFields.Fields("ArIng6")
                DirectCast(pdffield, TallComponents.PDF.Forms.Fields.CheckBoxField).CheckBoxValue = CheckState.On
            ElseIf ds.Tables(0).Rows(0).Item("ARIng6").ToString() = "No" Then
                pdffield = myPDFFields.Fields("ArIng6-1")
                DirectCast(pdffield, TallComponents.PDF.Forms.Fields.CheckBoxField).CheckBoxValue = CheckState.On

            End If
            If ds.Tables(0).Rows(0).Item("ARIng7").ToString() = "Yes" Then

                pdffield = myPDFFields.Fields("ArIng7")
                DirectCast(pdffield, TallComponents.PDF.Forms.Fields.CheckBoxField).CheckBoxValue = CheckState.On
            ElseIf ds.Tables(0).Rows(0).Item("ARIng7").ToString() = "No" Then
                pdffield = myPDFFields.Fields("ArIng7-1")
                DirectCast(pdffield, TallComponents.PDF.Forms.Fields.CheckBoxField).CheckBoxValue = CheckState.On

            End If
            If ds.Tables(0).Rows(0).Item("ARIng8").ToString() = "Yes" Then

                pdffield = myPDFFields.Fields("ArIng8")
                DirectCast(pdffield, TallComponents.PDF.Forms.Fields.CheckBoxField).CheckBoxValue = CheckState.On
            ElseIf ds.Tables(0).Rows(0).Item("ARIng8").ToString() = "No" Then
                pdffield = myPDFFields.Fields("ArIng8-1")
                DirectCast(pdffield, TallComponents.PDF.Forms.Fields.CheckBoxField).CheckBoxValue = CheckState.On

            End If

            If ds.Tables(0).Rows(0).Item("ARIng9").ToString() = "Yes" Then

                pdffield = myPDFFields.Fields("ArIng9")
                DirectCast(pdffield, TallComponents.PDF.Forms.Fields.CheckBoxField).CheckBoxValue = CheckState.On
            ElseIf ds.Tables(0).Rows(0).Item("ARIng9").ToString() = "No" Then
                pdffield = myPDFFields.Fields("ArIng9-1")
                DirectCast(pdffield, TallComponents.PDF.Forms.Fields.CheckBoxField).CheckBoxValue = CheckState.On

            End If
            If ds.Tables(0).Rows(0).Item("ARIng10").ToString() = "Yes" Then

                pdffield = myPDFFields.Fields("ArIng10")
                DirectCast(pdffield, TallComponents.PDF.Forms.Fields.CheckBoxField).CheckBoxValue = CheckState.On
            ElseIf ds.Tables(0).Rows(0).Item("ARIng10").ToString() = "No" Then
                pdffield = myPDFFields.Fields("ArIng10-1")
                DirectCast(pdffield, TallComponents.PDF.Forms.Fields.CheckBoxField).CheckBoxValue = CheckState.On

            End If
            If ds.Tables(0).Rows(0).Item("ARIng11").ToString() = "Yes" Then

                pdffield = myPDFFields.Fields("ArIng11")
                DirectCast(pdffield, TallComponents.PDF.Forms.Fields.CheckBoxField).CheckBoxValue = CheckState.On
            ElseIf ds.Tables(0).Rows(0).Item("ARIng11").ToString() = "No" Then
                pdffield = myPDFFields.Fields("ArIng11-1")
                DirectCast(pdffield, TallComponents.PDF.Forms.Fields.CheckBoxField).CheckBoxValue = CheckState.On

            End If
            If ds.Tables(0).Rows(0).Item("ARIng12").ToString() = "Yes" Then

                pdffield = myPDFFields.Fields("ArIng12")
                DirectCast(pdffield, TallComponents.PDF.Forms.Fields.CheckBoxField).CheckBoxValue = CheckState.On
            ElseIf ds.Tables(0).Rows(0).Item("ARIng12").ToString() = "No" Then
                pdffield = myPDFFields.Fields("ArIng12-1")
                DirectCast(pdffield, TallComponents.PDF.Forms.Fields.CheckBoxField).CheckBoxValue = CheckState.On

            End If
            If ds.Tables(0).Rows(0).Item("ARIng13").ToString() = "Yes" Then

                pdffield = myPDFFields.Fields("ArIng13")
                DirectCast(pdffield, TallComponents.PDF.Forms.Fields.CheckBoxField).CheckBoxValue = CheckState.On
            ElseIf ds.Tables(0).Rows(0).Item("ARIng13").ToString() = "No" Then
                pdffield = myPDFFields.Fields("ArIng13-1")
                DirectCast(pdffield, TallComponents.PDF.Forms.Fields.CheckBoxField).CheckBoxValue = CheckState.On

            End If
            If ds.Tables(0).Rows(0).Item("ARIng14").ToString() = "Yes" Then

                pdffield = myPDFFields.Fields("ArIng14")
                DirectCast(pdffield, TallComponents.PDF.Forms.Fields.CheckBoxField).CheckBoxValue = CheckState.On
            ElseIf ds.Tables(0).Rows(0).Item("ARIng14").ToString() = "No" Then
                pdffield = myPDFFields.Fields("ArIng14-1")
                DirectCast(pdffield, TallComponents.PDF.Forms.Fields.CheckBoxField).CheckBoxValue = CheckState.On

            End If
            If ds.Tables(0).Rows(0).Item("ARIng15").ToString() = "Yes" Then

                pdffield = myPDFFields.Fields("ArIng15")
                DirectCast(pdffield, TallComponents.PDF.Forms.Fields.CheckBoxField).CheckBoxValue = CheckState.On
            ElseIf ds.Tables(0).Rows(0).Item("ARIng15").ToString() = "No" Then
                pdffield = myPDFFields.Fields("ArIng15-1")
                DirectCast(pdffield, TallComponents.PDF.Forms.Fields.CheckBoxField).CheckBoxValue = CheckState.On

            End If
            If ds.Tables(0).Rows(0).Item("ARIng16").ToString() = "Yes" Then

                pdffield = myPDFFields.Fields("ArIng16")
                DirectCast(pdffield, TallComponents.PDF.Forms.Fields.CheckBoxField).CheckBoxValue = CheckState.On
            ElseIf ds.Tables(0).Rows(0).Item("ARIng16").ToString() = "No" Then
                pdffield = myPDFFields.Fields("ArIng16-1")
                DirectCast(pdffield, TallComponents.PDF.Forms.Fields.CheckBoxField).CheckBoxValue = CheckState.On

            End If
            If ds.Tables(0).Rows(0).Item("ARIng17").ToString() = "Yes" Then

                pdffield = myPDFFields.Fields("ArIng17")
                DirectCast(pdffield, TallComponents.PDF.Forms.Fields.CheckBoxField).CheckBoxValue = CheckState.On
            ElseIf ds.Tables(0).Rows(0).Item("ARIng17").ToString() = "No" Then
                pdffield = myPDFFields.Fields("ArIng17-1")
                DirectCast(pdffield, TallComponents.PDF.Forms.Fields.CheckBoxField).CheckBoxValue = CheckState.On

            End If
            If ds.Tables(0).Rows(0).Item("ARIng18").ToString() = "Yes" Then

                pdffield = myPDFFields.Fields("ArIng18")
                DirectCast(pdffield, TallComponents.PDF.Forms.Fields.CheckBoxField).CheckBoxValue = CheckState.On
            ElseIf ds.Tables(0).Rows(0).Item("ARIng18").ToString() = "No" Then
                pdffield = myPDFFields.Fields("ArIng18-1")
                DirectCast(pdffield, TallComponents.PDF.Forms.Fields.CheckBoxField).CheckBoxValue = CheckState.On

            End If
            If ds.Tables(0).Rows(0).Item("ARIng19").ToString() = "Yes" Then

                pdffield = myPDFFields.Fields("ArIng19")
                DirectCast(pdffield, TallComponents.PDF.Forms.Fields.CheckBoxField).CheckBoxValue = CheckState.On
            ElseIf ds.Tables(0).Rows(0).Item("ARIng19").ToString() = "No" Then
                pdffield = myPDFFields.Fields("ArIng19-1")
                DirectCast(pdffield, TallComponents.PDF.Forms.Fields.CheckBoxField).CheckBoxValue = CheckState.On

            End If
            If ds.Tables(0).Rows(0).Item("ARIng20").ToString() = "Yes" Then

                pdffield = myPDFFields.Fields("ArIng20")
                DirectCast(pdffield, TallComponents.PDF.Forms.Fields.CheckBoxField).CheckBoxValue = CheckState.On
            ElseIf ds.Tables(0).Rows(0).Item("ARIng20").ToString() = "No" Then
                pdffield = myPDFFields.Fields("ArIng20-1")
                DirectCast(pdffield, TallComponents.PDF.Forms.Fields.CheckBoxField).CheckBoxValue = CheckState.On

            End If
            If ds.Tables(0).Rows(0).Item("ARIng21").ToString() = "Yes" Then

                pdffield = myPDFFields.Fields("ArIng21")
                DirectCast(pdffield, TallComponents.PDF.Forms.Fields.CheckBoxField).CheckBoxValue = CheckState.On
            ElseIf ds.Tables(0).Rows(0).Item("ARIng21").ToString() = "No" Then
                pdffield = myPDFFields.Fields("ArIng21-1")
                DirectCast(pdffield, TallComponents.PDF.Forms.Fields.CheckBoxField).CheckBoxValue = CheckState.On

            End If
            If ds.Tables(0).Rows(0).Item("ARIng22").ToString() = "Yes" Then

                pdffield = myPDFFields.Fields("ArIng22")
                DirectCast(pdffield, TallComponents.PDF.Forms.Fields.CheckBoxField).CheckBoxValue = CheckState.On
            ElseIf ds.Tables(0).Rows(0).Item("ARIng22").ToString() = "No" Then
                pdffield = myPDFFields.Fields("ArIng22-1")
                DirectCast(pdffield, TallComponents.PDF.Forms.Fields.CheckBoxField).CheckBoxValue = CheckState.On

            End If
            If ds.Tables(0).Rows(0).Item("ARIng23").ToString() = "Yes" Then

                pdffield = myPDFFields.Fields("ArIng23")
                DirectCast(pdffield, TallComponents.PDF.Forms.Fields.CheckBoxField).CheckBoxValue = CheckState.On
            ElseIf ds.Tables(0).Rows(0).Item("ARIng23").ToString() = "No" Then
                pdffield = myPDFFields.Fields("ArIng23-1")
                DirectCast(pdffield, TallComponents.PDF.Forms.Fields.CheckBoxField).CheckBoxValue = CheckState.On

            End If
            If ds.Tables(0).Rows(0).Item("ARIng24").ToString() = "Yes" Then

                pdffield = myPDFFields.Fields("ArIng24")
                DirectCast(pdffield, TallComponents.PDF.Forms.Fields.CheckBoxField).CheckBoxValue = CheckState.On
            ElseIf ds.Tables(0).Rows(0).Item("ARIng24").ToString() = "No" Then
                pdffield = myPDFFields.Fields("ArIng24-1")
                DirectCast(pdffield, TallComponents.PDF.Forms.Fields.CheckBoxField).CheckBoxValue = CheckState.On

            End If
            If ds.Tables(0).Rows(0).Item("ARIng25").ToString() = "Yes" Then

                pdffield = myPDFFields.Fields("ArIng25")
                DirectCast(pdffield, TallComponents.PDF.Forms.Fields.CheckBoxField).CheckBoxValue = CheckState.On
            ElseIf ds.Tables(0).Rows(0).Item("ARIng25").ToString() = "No" Then
                pdffield = myPDFFields.Fields("ArIng25-1")
                DirectCast(pdffield, TallComponents.PDF.Forms.Fields.CheckBoxField).CheckBoxValue = CheckState.On

            End If
            If ds.Tables(0).Rows(0).Item("ARIng26").ToString() = "Yes" Then

                pdffield = myPDFFields.Fields("ArIng26")
                DirectCast(pdffield, TallComponents.PDF.Forms.Fields.CheckBoxField).CheckBoxValue = CheckState.On
            ElseIf ds.Tables(0).Rows(0).Item("ARIng26").ToString() = "No" Then
                pdffield = myPDFFields.Fields("ArIng26-1")
                DirectCast(pdffield, TallComponents.PDF.Forms.Fields.CheckBoxField).CheckBoxValue = CheckState.On

            End If
            If ds.Tables(0).Rows(0).Item("ARIng27").ToString() = "Yes" Then

                pdffield = myPDFFields.Fields("ArIng27")
                DirectCast(pdffield, TallComponents.PDF.Forms.Fields.CheckBoxField).CheckBoxValue = CheckState.On
            ElseIf ds.Tables(0).Rows(0).Item("ARIng27").ToString() = "No" Then
                pdffield = myPDFFields.Fields("ArIng27-1")
                DirectCast(pdffield, TallComponents.PDF.Forms.Fields.CheckBoxField).CheckBoxValue = CheckState.On

            End If
            If ds.Tables(0).Rows(0).Item("ARIng28").ToString() = "Yes" Then

                pdffield = myPDFFields.Fields("ArIng28")
                DirectCast(pdffield, TallComponents.PDF.Forms.Fields.CheckBoxField).CheckBoxValue = CheckState.On
            ElseIf ds.Tables(0).Rows(0).Item("ARIng28").ToString() = "No" Then
                pdffield = myPDFFields.Fields("ArIng28-1")
                DirectCast(pdffield, TallComponents.PDF.Forms.Fields.CheckBoxField).CheckBoxValue = CheckState.On

            End If
            If ds.Tables(0).Rows(0).Item("ARIng29").ToString() = "Yes" Then

                pdffield = myPDFFields.Fields("ArIng29")
                DirectCast(pdffield, TallComponents.PDF.Forms.Fields.CheckBoxField).CheckBoxValue = CheckState.On
            ElseIf ds.Tables(0).Rows(0).Item("ARIng29").ToString() = "No" Then
                pdffield = myPDFFields.Fields("ArIng29-1")
                DirectCast(pdffield, TallComponents.PDF.Forms.Fields.CheckBoxField).CheckBoxValue = CheckState.On

            End If
            If ds.Tables(0).Rows(0).Item("ARIng30").ToString() = "Yes" Then

                pdffield = myPDFFields.Fields("ArIng30")
                DirectCast(pdffield, TallComponents.PDF.Forms.Fields.CheckBoxField).CheckBoxValue = CheckState.On
            ElseIf ds.Tables(0).Rows(0).Item("ARIng30").ToString() = "No" Then
                pdffield = myPDFFields.Fields("ArIng30-1")
                DirectCast(pdffield, TallComponents.PDF.Forms.Fields.CheckBoxField).CheckBoxValue = CheckState.On

            End If
            If ds.Tables(0).Rows(0).Item("ARIng31").ToString() = "Yes" Then

                pdffield = myPDFFields.Fields("ArIng31")
                DirectCast(pdffield, TallComponents.PDF.Forms.Fields.CheckBoxField).CheckBoxValue = CheckState.On
            ElseIf ds.Tables(0).Rows(0).Item("ARIng31").ToString() = "No" Then
                pdffield = myPDFFields.Fields("ArIng31-1")
                DirectCast(pdffield, TallComponents.PDF.Forms.Fields.CheckBoxField).CheckBoxValue = CheckState.On

            End If
            If ds.Tables(0).Rows(0).Item("ARIng32").ToString() = "Yes" Then

                pdffield = myPDFFields.Fields("ArIng32")
                DirectCast(pdffield, TallComponents.PDF.Forms.Fields.CheckBoxField).CheckBoxValue = CheckState.On
            ElseIf ds.Tables(0).Rows(0).Item("ARIng32").ToString() = "No" Then
                pdffield = myPDFFields.Fields("ArIng32-1")
                DirectCast(pdffield, TallComponents.PDF.Forms.Fields.CheckBoxField).CheckBoxValue = CheckState.On

            End If
            If ds.Tables(0).Rows(0).Item("ARIng33").ToString() = "Yes" Then

                pdffield = myPDFFields.Fields("ArIng33")
                DirectCast(pdffield, TallComponents.PDF.Forms.Fields.CheckBoxField).CheckBoxValue = CheckState.On
            ElseIf ds.Tables(0).Rows(0).Item("ARIng33").ToString() = "No" Then
                pdffield = myPDFFields.Fields("ArIng33-1")
                DirectCast(pdffield, TallComponents.PDF.Forms.Fields.CheckBoxField).CheckBoxValue = CheckState.On

            End If
            If ds.Tables(0).Rows(0).Item("ARIng34").ToString() = "Yes" Then

                pdffield = myPDFFields.Fields("ArIng34")
                DirectCast(pdffield, TallComponents.PDF.Forms.Fields.CheckBoxField).CheckBoxValue = CheckState.On
            ElseIf ds.Tables(0).Rows(0).Item("ARIng34").ToString() = "No" Then
                pdffield = myPDFFields.Fields("ArIng34-1")
                DirectCast(pdffield, TallComponents.PDF.Forms.Fields.CheckBoxField).CheckBoxValue = CheckState.On

            End If
            If ds.Tables(0).Rows(0).Item("ARIng35").ToString() = "Yes" Then

                pdffield = myPDFFields.Fields("ArIng35")
                DirectCast(pdffield, TallComponents.PDF.Forms.Fields.CheckBoxField).CheckBoxValue = CheckState.On
            ElseIf ds.Tables(0).Rows(0).Item("ARIng35").ToString() = "No" Then
                pdffield = myPDFFields.Fields("ArIng35-1")
                DirectCast(pdffield, TallComponents.PDF.Forms.Fields.CheckBoxField).CheckBoxValue = CheckState.On

            End If
            If ds.Tables(0).Rows(0).Item("ARIng36").ToString() = "Yes" Then

                pdffield = myPDFFields.Fields("ArIng36")
                DirectCast(pdffield, TallComponents.PDF.Forms.Fields.CheckBoxField).CheckBoxValue = CheckState.On
            ElseIf ds.Tables(0).Rows(0).Item("ARIng36").ToString() = "No" Then
                pdffield = myPDFFields.Fields("ArIng36-1")
                DirectCast(pdffield, TallComponents.PDF.Forms.Fields.CheckBoxField).CheckBoxValue = CheckState.On

            End If
            If ds.Tables(0).Rows(0).Item("ARIng37").ToString() = "Yes" Then

                pdffield = myPDFFields.Fields("ArIng37")
                DirectCast(pdffield, TallComponents.PDF.Forms.Fields.CheckBoxField).CheckBoxValue = CheckState.On
            ElseIf ds.Tables(0).Rows(0).Item("ARIng37").ToString() = "No" Then
                pdffield = myPDFFields.Fields("ArIng37-1")
                DirectCast(pdffield, TallComponents.PDF.Forms.Fields.CheckBoxField).CheckBoxValue = CheckState.On

            End If
            If ds.Tables(0).Rows(0).Item("ARIng38").ToString() = "Yes" Then

                pdffield = myPDFFields.Fields("ArIng38")
                DirectCast(pdffield, TallComponents.PDF.Forms.Fields.CheckBoxField).CheckBoxValue = CheckState.On
            ElseIf ds.Tables(0).Rows(0).Item("ARIng38").ToString() = "No" Then
                pdffield = myPDFFields.Fields("ArIng38-1")
                DirectCast(pdffield, TallComponents.PDF.Forms.Fields.CheckBoxField).CheckBoxValue = CheckState.On

            End If
            If ds.Tables(0).Rows(0).Item("ARIng39").ToString() = "Yes" Then

                pdffield = myPDFFields.Fields("ArIng39")
                DirectCast(pdffield, TallComponents.PDF.Forms.Fields.CheckBoxField).CheckBoxValue = CheckState.On
            ElseIf ds.Tables(0).Rows(0).Item("ARIng39").ToString() = "No" Then
                pdffield = myPDFFields.Fields("ArIng39-1")
                DirectCast(pdffield, TallComponents.PDF.Forms.Fields.CheckBoxField).CheckBoxValue = CheckState.On

            End If
            If ds.Tables(0).Rows(0).Item("ARIng40").ToString() = "Yes" Then

                pdffield = myPDFFields.Fields("ArIng40")
                DirectCast(pdffield, TallComponents.PDF.Forms.Fields.CheckBoxField).CheckBoxValue = CheckState.On
            ElseIf ds.Tables(0).Rows(0).Item("ARIng40").ToString() = "No" Then
                pdffield = myPDFFields.Fields("ArIng40-1")
                DirectCast(pdffield, TallComponents.PDF.Forms.Fields.CheckBoxField).CheckBoxValue = CheckState.On

            End If
            If ds.Tables(0).Rows(0).Item("ARIng41").ToString() = "Yes" Then

                pdffield = myPDFFields.Fields("ArIng41")
                DirectCast(pdffield, TallComponents.PDF.Forms.Fields.CheckBoxField).CheckBoxValue = CheckState.On
            ElseIf ds.Tables(0).Rows(0).Item("ARIng41").ToString() = "No" Then
                pdffield = myPDFFields.Fields("ArIng41-1")
                DirectCast(pdffield, TallComponents.PDF.Forms.Fields.CheckBoxField).CheckBoxValue = CheckState.On

            End If
            If ds.Tables(0).Rows(0).Item("ARIng42").ToString() = "Yes" Then

                pdffield = myPDFFields.Fields("ArIng42")
                DirectCast(pdffield, TallComponents.PDF.Forms.Fields.CheckBoxField).CheckBoxValue = CheckState.On
            ElseIf ds.Tables(0).Rows(0).Item("ARIng42").ToString() = "No" Then
                pdffield = myPDFFields.Fields("ArIng42-1")
                DirectCast(pdffield, TallComponents.PDF.Forms.Fields.CheckBoxField).CheckBoxValue = CheckState.On

            End If
            If ds.Tables(0).Rows(0).Item("ARIng43").ToString() = "Yes" Then

                pdffield = myPDFFields.Fields("ArIng43")
                DirectCast(pdffield, TallComponents.PDF.Forms.Fields.CheckBoxField).CheckBoxValue = CheckState.On
            ElseIf ds.Tables(0).Rows(0).Item("ARIng43").ToString() = "No" Then
                pdffield = myPDFFields.Fields("ArIng43-1")
                DirectCast(pdffield, TallComponents.PDF.Forms.Fields.CheckBoxField).CheckBoxValue = CheckState.On

            End If
            ' Load Quote Coverages:
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
            MHLimit = CInt(ds2.Tables(0).Rows(0).Item("DwellingLimit").ToString())
            pplimet = CInt(ds2.Tables(0).Rows(0).Item("PerPropLimit").ToString())
            If IsNumeric(ds2.Tables(0).Rows(0).Item("AddStrucLimit").ToString()) Then
                Struclimit = CInt(ds2.Tables(0).Rows(0).Item("AddStrucLimit").ToString())
            Else
                Struclimit = ds2.Tables(0).Rows(0).Item("AddStrucLimit").ToString()
            End If

            If IsNumeric(ds2.Tables(0).Rows(0).Item("AddStrucPrem")) Then
                StrucPrem = CInt(ds2.Tables(0).Rows(0).Item("AddStrucPrem").ToString())
            Else
                StrucPrem = ds2.Tables(0).Rows(0).Item("AddStrucPrem").ToString()
            End If
            ' StrucPrem = CInt(ds2.Tables(0).Rows(0).Item("AddStrucPrem").ToString())
            pllimit = CInt(ds2.Tables(0).Rows(0).Item("LiabLimit").ToString())
            If IsNumeric(ds2.Tables(0).Rows(0).Item("LiabPrem").ToString()) Then
                plprem = CInt(ds2.Tables(0).Rows(0).Item("LiabPrem").ToString())
            Else
                plprem = ds2.Tables(0).Rows(0).Item("LiabPrem").ToString()
            End If

            medlimit = CInt(ds2.Tables(0).Rows(0).Item("MedPayOpt").ToString())
            If medlimit = "1000" Then
                medprem = "5"
            Else
                medprem = "INCLUDED"
            End If
            Select Case ds.Tables(0).Rows(0).Item("program").ToString()
                Case "Package"
                   

                    'catfund = ((CInt(ds3.Tables(0).Rows(0).Item("Packsub1").ToString()) - CInt(ds3.Tables(0).Rows(0).Item("PackHur").ToString()) - CInt(ds3.Tables(0).Rows(0).Item("PackNonHur").ToString()))) * 0.01
                    If ds4.Tables(0).Rows(0).Item("ARPacakageSupHeatFee").ToString() <> "" Then
                        subheat = CInt(ds4.Tables(0).Rows(0).Item("ARPacakageSupHeatFee").ToString())
                    Else
                        subheat = CInt("0.00")

                    End If
                    ' subheat = CInt(ds4.Tables(0).Rows(0).Item("ARPacakageSupHeatFee").ToString())
                    If ds4.Tables(0).Rows(0).Item("ARPackageCEAFee").ToString() <> "" Then
                        ceafund = CDbl(ds4.Tables(0).Rows(0).Item("ARPackageCEAFee").ToString())
                    Else
                        ceafund = CDbl("0.00")

                    End If

                    'ceafund = CInt(ds4.Tables(0).Rows(0).Item("ARPackageCEAFee").ToString())
                    If ds4.Tables(0).Rows(0).Item("ARPackagePerPropPrem").ToString() <> "" Then
                        ppprem = CInt(ds4.Tables(0).Rows(0).Item("ARPackagePerPropPrem").ToString())
                    Else
                        ppprem = CInt("0.00")

                    End If
                    ' ppprem = CInt(ds4.Tables(0).Rows(0).Item("ARPackagePerPropPrem").ToString())
                    If ds4.Tables(0).Rows(0).Item("ARPackageTotal").ToString() <> "" Then
                        totprem = CDbl(ds4.Tables(0).Rows(0).Item("ARPackageTotal").ToString())
                    Else
                        totprem = CDbl("0.00")

                    End If
                    ' totprem = ds4.Tables(0).Rows(0).Item("ARPackageTotal").ToString()
                    PackTotal += CInt(ds3.Tables(0).Rows(0).Item("Packsub1").ToString()) - CInt(ds3.Tables(0).Rows(0).Item("PackHur").ToString()) - CInt(ds3.Tables(0).Rows(0).Item("PackNonHur").ToString())
                    catfund = CDbl((ceafund * 100) * 0.013)

                    pdffield = myPDFFields.Fields("Deductible")
                    DirectCast(pdffield, TallComponents.PDF.Forms.Fields.TextField).Value = "AOP " & ds4.Tables(0).Rows(0).Item("ARPackageAOPOpt").ToString() & " Hurricane " & ds4.Tables(0).Rows(0).Item("ARPackageHurDedOpt").ToString()

                Case "Standard"
                    ' catfund = ((CInt(ds3.Tables(0).Rows(0).Item("Standsub1").ToString()) - CInt(ds3.Tables(0).Rows(0).Item("StandHur").ToString()) - CInt(ds3.Tables(0).Rows(0).Item("StandNonHur").ToString()))) * 0.01

                    If ds4.Tables(0).Rows(0).Item("ARStandardSupHeatFee").ToString() <> "" Then
                        subheat = CInt(ds4.Tables(0).Rows(0).Item("ARStandardSupHeatFee").ToString())
                    Else
                        subheat = CInt("0.00")

                    End If

                    If ds4.Tables(0).Rows(0).Item("ARStandardCEAFee").ToString() <> "" Then
                        ceafund = CDbl(ds4.Tables(0).Rows(0).Item("ARStandardCEAFee").ToString())
                    Else
                        ceafund = CDbl("0.00")

                    End If


                    If ds4.Tables(0).Rows(0).Item("ARStandardPerPropPrem").ToString() <> "" Then
                        ppprem = CInt(ds4.Tables(0).Rows(0).Item("ARStandardPerPropPrem").ToString())
                    Else
                        ppprem = CInt("0.00")

                    End If

                    If ds4.Tables(0).Rows(0).Item("ARStandardTotal").ToString() <> "" Then
                        totprem = CDbl(ds4.Tables(0).Rows(0).Item("ARStandardTotal").ToString())
                    Else
                        totprem = CDbl("0.00")

                    End If
                    'subheat = CInt(ds4.Tables(0).Rows(0).Item("ARStandardSupHeatFee").ToString())
                    'ceafund = CInt(ds4.Tables(0).Rows(0).Item("ARStandardCEAFee").ToString())
                    'ppprem = CInt(ds4.Tables(0).Rows(0).Item("ARStandardPerPropPrem").ToString())
                    'totprem = ds4.Tables(0).Rows(0).Item("ARStandardTotal").ToString()
                    PackTotal += CInt(ds3.Tables(0).Rows(0).Item("Standsub1").ToString()) - CInt(ds3.Tables(0).Rows(0).Item("StandHur").ToString()) - CInt(ds3.Tables(0).Rows(0).Item("StandNonHur").ToString())
                    catfund = CDbl(PackTotal * 0.013)

                    pdffield = myPDFFields.Fields("Deductible")
                    DirectCast(pdffield, TallComponents.PDF.Forms.Fields.TextField).Value = "AOP " & ds4.Tables(0).Rows(0).Item("ARStandardAOPOpt").ToString() & " Hurricane " & ds4.Tables(0).Rows(0).Item("ARStandardHurDedOpt").ToString()



                Case "Rental"
                    ' catfund = ((CInt(ds3.Tables(0).Rows(0).Item("Rentsub1").ToString()) - CInt(ds3.Tables(0).Rows(0).Item("RentHur").ToString()) - CInt(ds3.Tables(0).Rows(0).Item("RentNonHur").ToString()))) * 0.01
                    If ds4.Tables(0).Rows(0).Item("ARRentalSupHeatFee").ToString() <> "" Then
                        subheat = CInt(ds4.Tables(0).Rows(0).Item("ARRentalSupHeatFee").ToString())
                    Else
                        subheat = CInt("0.00")

                    End If

                    If ds4.Tables(0).Rows(0).Item("ARRentalCEAFee").ToString() <> "" Then
                        ceafund = CDbl(ds4.Tables(0).Rows(0).Item("ARRentalCEAFee").ToString())
                    Else
                        ceafund = CDbl("0.00")

                    End If


                    If ds4.Tables(0).Rows(0).Item("ARRentalPerPropPrem").ToString() <> "" Then
                        ppprem = CInt(ds4.Tables(0).Rows(0).Item("ARRentalPerPropPrem").ToString())
                    Else
                        ppprem = CInt("0.00")

                    End If

                    If ds4.Tables(0).Rows(0).Item("ARRentalTotal").ToString() <> "" Then
                        totprem = CDbl(ds4.Tables(0).Rows(0).Item("ARRentalTotal").ToString())
                    Else
                        totprem = CDbl("0.00")

                    End If


                    'subheat = CInt(ds4.Tables(0).Rows(0).Item("ARRentalSupHeatFee").ToString())
                    'ceafund = CInt(ds4.Tables(0).Rows(0).Item("ARRentalCEAFee").ToString())
                    'ppprem = CInt(ds4.Tables(0).Rows(0).Item("ARRentalPerPropPrem").ToString())
                    'totprem = ds4.Tables(0).Rows(0).Item("ARRentalTotal").ToString()
                    PackTotal += CInt(ds3.Tables(0).Rows(0).Item("Rentsub1").ToString()) - CInt(ds3.Tables(0).Rows(0).Item("RentHur").ToString()) - CInt(ds3.Tables(0).Rows(0).Item("RentNonHur").ToString())
                    catfund = CDbl(PackTotal * 0.013)
                    pdffield = myPDFFields.Fields("Deductible")
                    DirectCast(pdffield, TallComponents.PDF.Forms.Fields.TextField).Value = "AOP " & ds4.Tables(0).Rows(0).Item("ARRentalAOPOpt").ToString() & " Hurricane " & ds4.Tables(0).Rows(0).Item("ARRentalHurDedOpt").ToString()

            End Select
            If ds2.Tables(0).Rows.Count > 0 Then

                pdffield = myPDFFields.Fields("fill_95")
                DirectCast(pdffield, TallComponents.PDF.Forms.Fields.TextField).Value = MHLimit 'ds2.Tables(0).Rows(0).Item("DwellingLimit").ToString().Replace("$", "")

                pdffield = myPDFFields.Fields("fill_62")
                DirectCast(pdffield, TallComponents.PDF.Forms.Fields.TextField).Value = MHPrem 'ds2.Tables(0).Rows(0).Item("DwellingPrem").ToString().Replace("$", "")

                pdffield = myPDFFields.Fields("fill_97")
                DirectCast(pdffield, TallComponents.PDF.Forms.Fields.TextField).Value = Struclimit 'ds2.Tables(0).Rows(0).Item("AddStrucLimit").ToString().Replace("$", "")

                pdffield = myPDFFields.Fields("fill_63")
                DirectCast(pdffield, TallComponents.PDF.Forms.Fields.TextField).Value = StrucPrem 'ds2.Tables(0).Rows(0).Item("AddStrucPrem").ToString().Replace("$", "")

                pdffield = myPDFFields.Fields("fill_99")
                DirectCast(pdffield, TallComponents.PDF.Forms.Fields.TextField).Value = pplimet 'ds2.Tables(0).Rows(0).Item("PerPropLimit").ToString().Replace("$", "")

                pdffield = myPDFFields.Fields("fill_64")
                DirectCast(pdffield, TallComponents.PDF.Forms.Fields.TextField).Value = ppprem 'ds2.Tables(0).Rows(0).Item("PerPropPrem").ToString().Replace("$", "")

                pdffield = myPDFFields.Fields("fill_101")
                DirectCast(pdffield, TallComponents.PDF.Forms.Fields.TextField).Value = pllimit 'ds2.Tables(0).Rows(0).Item("LiabLimit").ToString().Replace("$", "")

                pdffield = myPDFFields.Fields("fill_65")
                DirectCast(pdffield, TallComponents.PDF.Forms.Fields.TextField).Value = plprem 'ds2.Tables(0).Rows(0).Item("LiabPrem").ToString().Replace("$", "")

                pdffield = myPDFFields.Fields("fill_103")
                DirectCast(pdffield, TallComponents.PDF.Forms.Fields.TextField).Value = medlimit 'ds2.Tables(0).Rows(0).Item("MedPayOpt").ToString().Replace("$", "")

                pdffield = myPDFFields.Fields("fill_66")
                DirectCast(pdffield, TallComponents.PDF.Forms.Fields.TextField).Value = medprem 'ds2.Tables(0).Rows(0).Item("MedRepPrem").ToString().Replace("$", "")

               
                pdffield = myPDFFields.Fields("fill_67")
                DirectCast(pdffield, TallComponents.PDF.Forms.Fields.TextField).Value = "(" & CInt(ds2.Tables(0).Rows(0).Item("DedPrem").ToString().Replace("-", "")) & ")"

                pdffield = myPDFFields.Fields("fill_77")
                DirectCast(pdffield, TallComponents.PDF.Forms.Fields.TextField).Value = CDbl(ceafund)
                pdffield = myPDFFields.Fields("fill_78")
                DirectCast(pdffield, TallComponents.PDF.Forms.Fields.TextField).Value = CDbl(catfund)

                pdffield = myPDFFields.Fields("fill_81")
                DirectCast(pdffield, TallComponents.PDF.Forms.Fields.TextField).Value = totprem

                'DedPrem



                Dim I As Integer = 0
                Dim Description As String
                Dim moneys As String

               
                If ds2.Tables(0).Rows(0).Item("PerPropRepPrem").ToString() > "" Then
                    ' Description = "Personal Property Replacement Cost"
                    Description = "Contents Replacement Cost"
                    moneys = ds2.Tables(0).Rows(0).Item("PerPropRepPrem").ToString()
                    I += 1
                    If I = 1 Then
                        pdffield = myPDFFields.Fields("Optional CoveragesRow1")
                        DirectCast(pdffield, TallComponents.PDF.Forms.Fields.TextField).Value = Description
                        pdffield = myPDFFields.Fields("fill_69")
                        DirectCast(pdffield, TallComponents.PDF.Forms.Fields.TextField).Value = FormatCurrency(moneys).Replace("$", "")

                    ElseIf I = 2 Then
                        pdffield = myPDFFields.Fields("Optional CoveragesRow2")
                        DirectCast(pdffield, TallComponents.PDF.Forms.Fields.TextField).Value = Description
                        pdffield = myPDFFields.Fields("fill_70")
                        DirectCast(pdffield, TallComponents.PDF.Forms.Fields.TextField).Value = FormatCurrency(moneys).Replace("$", "")
                    ElseIf I = 3 Then
                        pdffield = myPDFFields.Fields("Optional CoveragesRow3")
                        DirectCast(pdffield, TallComponents.PDF.Forms.Fields.TextField).Value = Description
                        pdffield = myPDFFields.Fields("fill_71")
                        DirectCast(pdffield, TallComponents.PDF.Forms.Fields.TextField).Value = FormatCurrency(moneys).Replace("$", "")
                    ElseIf I = 4 Then
                        pdffield = myPDFFields.Fields("Optional CoveragesRow4")
                        DirectCast(pdffield, TallComponents.PDF.Forms.Fields.TextField).Value = Description
                        pdffield = myPDFFields.Fields("fill_72")
                        DirectCast(pdffield, TallComponents.PDF.Forms.Fields.TextField).Value = FormatCurrency(moneys).Replace("$", "")
                    ElseIf I = 5 Then
                        pdffield = myPDFFields.Fields("Optional CoveragesRow5")
                        DirectCast(pdffield, TallComponents.PDF.Forms.Fields.TextField).Value = Description
                        pdffield = myPDFFields.Fields("fill_73")
                        DirectCast(pdffield, TallComponents.PDF.Forms.Fields.TextField).Value = FormatCurrency(moneys).Replace("$", "")

                    End If
                End If

                If ds2.Tables(0).Rows(0).Item("MHRepPrem").ToString() > "" Then
                    Description = "Replacement Cost for Mobile Home"
                    moneys = ds2.Tables(0).Rows(0).Item("MHRepPrem").ToString()
                    I += 1
                    If I = 1 Then
                        pdffield = myPDFFields.Fields("Optional CoveragesRow1")
                        DirectCast(pdffield, TallComponents.PDF.Forms.Fields.TextField).Value = Description
                        pdffield = myPDFFields.Fields("fill_69")
                        DirectCast(pdffield, TallComponents.PDF.Forms.Fields.TextField).Value = FormatCurrency(moneys).Replace("$", "")

                    ElseIf I = 2 Then
                        pdffield = myPDFFields.Fields("Optional CoveragesRow2")
                        DirectCast(pdffield, TallComponents.PDF.Forms.Fields.TextField).Value = Description
                        pdffield = myPDFFields.Fields("fill_70")
                        DirectCast(pdffield, TallComponents.PDF.Forms.Fields.TextField).Value = FormatCurrency(moneys).Replace("$", "")
                    ElseIf I = 3 Then
                        pdffield = myPDFFields.Fields("Optional CoveragesRow3")
                        DirectCast(pdffield, TallComponents.PDF.Forms.Fields.TextField).Value = Description
                        pdffield = myPDFFields.Fields("fill_71")
                        DirectCast(pdffield, TallComponents.PDF.Forms.Fields.TextField).Value = FormatCurrency(moneys).Replace("$", "")
                    ElseIf I = 4 Then
                        pdffield = myPDFFields.Fields("Optional CoveragesRow4")
                        DirectCast(pdffield, TallComponents.PDF.Forms.Fields.TextField).Value = Description
                        pdffield = myPDFFields.Fields("fill_72")
                        DirectCast(pdffield, TallComponents.PDF.Forms.Fields.TextField).Value = FormatCurrency(moneys).Replace("$", "")
                    ElseIf I = 5 Then
                        pdffield = myPDFFields.Fields("Optional CoveragesRow5")
                        DirectCast(pdffield, TallComponents.PDF.Forms.Fields.TextField).Value = Description
                        pdffield = myPDFFields.Fields("fill_73")
                        DirectCast(pdffield, TallComponents.PDF.Forms.Fields.TextField).Value = FormatCurrency(moneys).Replace("$", "")

                    End If
                End If
               
                Dim moneycalc As String


                If ds2.Tables(0).Rows(0).Item("FirePrem").ToString() > "" Or ds2.Tables(0).Rows(0).Item("RadioPrem").ToString() > "" Then

                    If ds2.Tables(0).Rows(0).Item("FirePrem").ToString() > "" Then
                        Description = "Fire Department Charge: "
                        moneys = ds2.Tables(0).Rows(0).Item("FirePrem").ToString()
                        Description += moneys
                        moneycalc += CInt(moneys)

                    End If
                    If ds2.Tables(0).Rows(0).Item("FirePrem").ToString() > "" And ds2.Tables(0).Rows(0).Item("RadioPrem").ToString() > "" Then
                        Description += " \ "
                    End If
                    If ds2.Tables(0).Rows(0).Item("RadioPrem").ToString() > "" Then
                        Description += "Radio Prem: "
                        moneys = ds2.Tables(0).Rows(0).Item("FirePrem").ToString()
                        Description += moneys
                        moneycalc += CInt(moneys)
                    End If

                    I += 1
                    If I = 1 Then
                        pdffield = myPDFFields.Fields("Optional CoveragesRow1")
                        DirectCast(pdffield, TallComponents.PDF.Forms.Fields.TextField).Value = Description
                        pdffield = myPDFFields.Fields("fill_69")
                        DirectCast(pdffield, TallComponents.PDF.Forms.Fields.TextField).Value = FormatCurrency(moneycalc).Replace("$", "")

                    ElseIf I = 2 Then
                        pdffield = myPDFFields.Fields("Optional CoveragesRow2")
                        DirectCast(pdffield, TallComponents.PDF.Forms.Fields.TextField).Value = Description
                        pdffield = myPDFFields.Fields("fill_70")
                        DirectCast(pdffield, TallComponents.PDF.Forms.Fields.TextField).Value = FormatCurrency(moneycalc).Replace("$", "")
                    ElseIf I = 3 Then
                        pdffield = myPDFFields.Fields("Optional CoveragesRow3")
                        DirectCast(pdffield, TallComponents.PDF.Forms.Fields.TextField).Value = Description
                        pdffield = myPDFFields.Fields("fill_71")
                        DirectCast(pdffield, TallComponents.PDF.Forms.Fields.TextField).Value = FormatCurrency(moneycalc).Replace("$", "")
                    ElseIf I = 4 Then
                        pdffield = myPDFFields.Fields("Optional CoveragesRow4")
                        DirectCast(pdffield, TallComponents.PDF.Forms.Fields.TextField).Value = Description
                        pdffield = myPDFFields.Fields("fill_72")
                        DirectCast(pdffield, TallComponents.PDF.Forms.Fields.TextField).Value = FormatCurrency(moneycalc).Replace("$", "")
                    ElseIf I = 5 Then
                        pdffield = myPDFFields.Fields("Optional CoveragesRow5")
                        DirectCast(pdffield, TallComponents.PDF.Forms.Fields.TextField).Value = Description
                        pdffield = myPDFFields.Fields("fill_73")
                        DirectCast(pdffield, TallComponents.PDF.Forms.Fields.TextField).Value = FormatCurrency(moneycalc).Replace("$", "")

                    End If

                End If
                Dim moneycalcopt As String = 0.0
                Select Case ds.Tables(0).Rows(0).Item("program").ToString().Replace("$", "")


                    Case "Package"
                        If ds4.Tables(0).Rows(0).Item("ARPackageSecIntPrem").ToString().Replace("$", "") > "0.00" Or ds4.Tables(0).Rows(0).Item("ARPackageNatDisPrem").ToString().Replace("$", "") > "0.00" Then
                            If ds4.Tables(0).Rows(0).Item("ARPackageSecIntPrem").ToString().Replace("$", "") > "0.00" Then
                                Description = "Security Interest: "
                                moneys = ds4.Tables(0).Rows(0).Item("ARPackageSecIntPrem").ToString()
                                Description += moneys
                                moneycalcopt += CInt(moneys)

                            End If
                            If ds4.Tables(0).Rows(0).Item("ARPackageSecIntPrem").ToString().Replace("$", "") > "0.00" And ds4.Tables(0).Rows(0).Item("ARPackageNatDisPrem").ToString().Replace("$", "") > "0.00" Then
                                Description += " \ "
                            End If
                            If ds4.Tables(0).Rows(0).Item("ARPackageNatDisPrem").ToString().Replace("$", "") > "0.00" Then
                                Description += "Natural Disaster :"
                                moneys = ds4.Tables(0).Rows(0).Item("ARPackageNatDisPrem").ToString()
                                Description += moneys
                                moneycalcopt += CInt(moneys)
                            End If


                        End If
                        I += 1
                        If I = 1 Then
                            pdffield = myPDFFields.Fields("Optional CoveragesRow1")
                            DirectCast(pdffield, TallComponents.PDF.Forms.Fields.TextField).Value = Description
                            pdffield = myPDFFields.Fields("fill_69")
                            DirectCast(pdffield, TallComponents.PDF.Forms.Fields.TextField).Value = FormatCurrency(moneycalcopt).Replace("$", "")

                        ElseIf I = 2 Then
                            pdffield = myPDFFields.Fields("Optional CoveragesRow2")
                            DirectCast(pdffield, TallComponents.PDF.Forms.Fields.TextField).Value = Description
                            pdffield = myPDFFields.Fields("fill_70")
                            DirectCast(pdffield, TallComponents.PDF.Forms.Fields.TextField).Value = FormatCurrency(moneycalcopt).Replace("$", "")
                        ElseIf I = 3 Then
                            pdffield = myPDFFields.Fields("Optional CoveragesRow3")
                            DirectCast(pdffield, TallComponents.PDF.Forms.Fields.TextField).Value = Description
                            pdffield = myPDFFields.Fields("fill_71")
                            DirectCast(pdffield, TallComponents.PDF.Forms.Fields.TextField).Value = FormatCurrency(moneycalcopt).Replace("$", "")
                        ElseIf I = 4 Then
                            pdffield = myPDFFields.Fields("Optional CoveragesRow4")
                            DirectCast(pdffield, TallComponents.PDF.Forms.Fields.TextField).Value = Description
                            pdffield = myPDFFields.Fields("fill_72")
                            DirectCast(pdffield, TallComponents.PDF.Forms.Fields.TextField).Value = FormatCurrency(moneycalcopt).Replace("$", "")
                        ElseIf I = 5 Then
                            pdffield = myPDFFields.Fields("Optional CoveragesRow5")
                            DirectCast(pdffield, TallComponents.PDF.Forms.Fields.TextField).Value = Description
                            pdffield = myPDFFields.Fields("fill_73")
                            DirectCast(pdffield, TallComponents.PDF.Forms.Fields.TextField).Value = FormatCurrency(moneycalcopt).Replace("$", "")
                        ElseIf I = 6 Then
                            pdffield = myPDFFields.Fields("Optional CoveragesRow6")
                            DirectCast(pdffield, TallComponents.PDF.Forms.Fields.TextField).Value = Description
                            pdffield = myPDFFields.Fields("fill_76")
                            DirectCast(pdffield, TallComponents.PDF.Forms.Fields.TextField).Value = FormatCurrency(moneycalcopt).Replace("$", "")

                        End If
                        moneycalcopt = "0.00"
                        Description = ""
                        moneys = ""
                        If ds4.Tables(0).Rows(0).Item("ARPackageAddResPrem").ToString().Replace("$", "") > "0.00" Or ds4.Tables(0).Rows(0).Item("ARPackageWaterPrem").ToString().Replace("$", "") > "0.00" Then
                            If ds4.Tables(0).Rows(0).Item("ARPackageAddResPrem").ToString().Replace("$", "") > "0.00" Then
                                Description = "Additional Resident: "
                                moneys = ds4.Tables(0).Rows(0).Item("ARPackageAddResPrem").ToString()
                                Description += moneys
                                moneycalcopt += CInt(moneys)

                            End If
                            If ds4.Tables(0).Rows(0).Item("ARPackageAddResPrem").ToString().Replace("$", "") > "0.00" And ds4.Tables(0).Rows(0).Item("ARPackageWaterPrem").ToString().Replace("$", "") > "0.00" Then
                                Description += "\"
                            End If
                            If ds4.Tables(0).Rows(0).Item("ARPackageWaterPrem").ToString().Replace("$", "") > "0.00" Then
                                Description += "Watercraft:"
                                moneys = ds4.Tables(0).Rows(0).Item("ARPackageWaterPrem").ToString()
                                Description += moneys
                                moneycalcopt += CInt(moneys)
                            End If


                        End If
                        I += 1
                        If I = 1 Then
                            pdffield = myPDFFields.Fields("Optional CoveragesRow1")
                            DirectCast(pdffield, TallComponents.PDF.Forms.Fields.TextField).Value = Description
                            pdffield = myPDFFields.Fields("fill_69")
                            DirectCast(pdffield, TallComponents.PDF.Forms.Fields.TextField).Value = FormatCurrency(moneycalcopt).Replace("$", "")

                        ElseIf I = 2 Then
                            pdffield = myPDFFields.Fields("Optional CoveragesRow2")
                            DirectCast(pdffield, TallComponents.PDF.Forms.Fields.TextField).Value = Description
                            pdffield = myPDFFields.Fields("fill_70")
                            DirectCast(pdffield, TallComponents.PDF.Forms.Fields.TextField).Value = FormatCurrency(moneycalcopt).Replace("$", "")
                        ElseIf I = 3 Then
                            pdffield = myPDFFields.Fields("Optional CoveragesRow3")
                            DirectCast(pdffield, TallComponents.PDF.Forms.Fields.TextField).Value = Description
                            pdffield = myPDFFields.Fields("fill_71")
                            DirectCast(pdffield, TallComponents.PDF.Forms.Fields.TextField).Value = FormatCurrency(moneycalcopt).Replace("$", "")
                        ElseIf I = 4 Then
                            pdffield = myPDFFields.Fields("Optional CoveragesRow4")
                            DirectCast(pdffield, TallComponents.PDF.Forms.Fields.TextField).Value = Description
                            pdffield = myPDFFields.Fields("fill_72")
                            DirectCast(pdffield, TallComponents.PDF.Forms.Fields.TextField).Value = FormatCurrency(moneycalcopt).Replace("$", "")
                        ElseIf I = 5 Then
                            pdffield = myPDFFields.Fields("Optional CoveragesRow5")
                            DirectCast(pdffield, TallComponents.PDF.Forms.Fields.TextField).Value = Description
                            pdffield = myPDFFields.Fields("fill_73")
                            DirectCast(pdffield, TallComponents.PDF.Forms.Fields.TextField).Value = FormatCurrency(moneycalcopt).Replace("$", "")
                        ElseIf I = 6 Then
                            pdffield = myPDFFields.Fields("Optional CoveragesRow6")
                            DirectCast(pdffield, TallComponents.PDF.Forms.Fields.TextField).Value = Description
                            pdffield = myPDFFields.Fields("fill_76")
                            DirectCast(pdffield, TallComponents.PDF.Forms.Fields.TextField).Value = FormatCurrency(moneycalcopt).Replace("$", "")

                        End If

                        moneycalcopt = "0.00"
                        Description = ""
                        moneys = ""
                        If ds4.Tables(0).Rows(0).Item("ARPackageVPerPropPrem").ToString().Replace("$", "") > "0.00" Then
                            Description += "Valuable Personal Property:"
                            moneys = ds4.Tables(0).Rows(0).Item("ARPackageVPerPropPrem").ToString().Replace("$", "")
                            Description += moneys
                            moneycalcopt += CInt(moneys)
                        End If
                        I += 1
                        If I = 1 Then
                            pdffield = myPDFFields.Fields("Optional CoveragesRow1")
                            DirectCast(pdffield, TallComponents.PDF.Forms.Fields.TextField).Value = Description
                            pdffield = myPDFFields.Fields("fill_69")
                            DirectCast(pdffield, TallComponents.PDF.Forms.Fields.TextField).Value = FormatCurrency(moneycalcopt).Replace("$", "")

                        ElseIf I = 2 Then
                            pdffield = myPDFFields.Fields("Optional CoveragesRow2")
                            DirectCast(pdffield, TallComponents.PDF.Forms.Fields.TextField).Value = Description
                            pdffield = myPDFFields.Fields("fill_70")
                            DirectCast(pdffield, TallComponents.PDF.Forms.Fields.TextField).Value = FormatCurrency(moneycalcopt).Replace("$", "")
                        ElseIf I = 3 Then
                            pdffield = myPDFFields.Fields("Optional CoveragesRow3")
                            DirectCast(pdffield, TallComponents.PDF.Forms.Fields.TextField).Value = Description
                            pdffield = myPDFFields.Fields("fill_71")
                            DirectCast(pdffield, TallComponents.PDF.Forms.Fields.TextField).Value = FormatCurrency(moneycalcopt).Replace("$", "")
                        ElseIf I = 4 Then
                            pdffield = myPDFFields.Fields("Optional CoveragesRow4")
                            DirectCast(pdffield, TallComponents.PDF.Forms.Fields.TextField).Value = Description
                            pdffield = myPDFFields.Fields("fill_72")
                            DirectCast(pdffield, TallComponents.PDF.Forms.Fields.TextField).Value = FormatCurrency(moneycalcopt).Replace("$", "")
                        ElseIf I = 5 Then
                            pdffield = myPDFFields.Fields("Optional CoveragesRow5")
                            DirectCast(pdffield, TallComponents.PDF.Forms.Fields.TextField).Value = Description
                            pdffield = myPDFFields.Fields("fill_73")
                            DirectCast(pdffield, TallComponents.PDF.Forms.Fields.TextField).Value = FormatCurrency(moneycalcopt).Replace("$", "")
                        ElseIf I = 6 Then
                            pdffield = myPDFFields.Fields("Optional CoveragesRow6")
                            DirectCast(pdffield, TallComponents.PDF.Forms.Fields.TextField).Value = Description
                            pdffield = myPDFFields.Fields("fill_76")
                            DirectCast(pdffield, TallComponents.PDF.Forms.Fields.TextField).Value = FormatCurrency(moneycalcopt).Replace("$", "")

                        End If
                    Case "Standard"
                        If ds4.Tables(0).Rows(0).Item("ARStandardSecIntPrem").ToString().Replace("$", "") > "0.00" Or ds4.Tables(0).Rows(0).Item("ARStandardNatDisPrem").ToString().Replace("$", "") > "0.00" Then
                            If ds4.Tables(0).Rows(0).Item("ARStandardSecIntPrem").ToString().Replace("$", "") > "0.00" Then
                                Description = "Security Interest: "
                                moneys = ds4.Tables(0).Rows(0).Item("ARStandardSecIntPrem").ToString()
                                Description += moneys
                                moneycalcopt += CInt(moneys)

                            End If
                            If ds4.Tables(0).Rows(0).Item("ARStandardSecIntPrem").ToString().Replace("$", "") > "0.00" And ds4.Tables(0).Rows(0).Item("ARStandardNatDisPrem").ToString().Replace("$", "") > "0.00" Then
                                Description += "\"
                            End If
                            If ds4.Tables(0).Rows(0).Item("ARStandardNatDisPrem").ToString().Replace("$", "") > "0.00" Then
                                Description += "Natural Disaster :"
                                moneys = ds4.Tables(0).Rows(0).Item("ARStandardNatDisPrem").ToString()
                                Description += moneys
                                moneycalcopt += CInt(moneys)
                            End If


                        End If
                        I += 1
                        If I = 1 Then
                            pdffield = myPDFFields.Fields("Optional CoveragesRow1")
                            DirectCast(pdffield, TallComponents.PDF.Forms.Fields.TextField).Value = Description
                            pdffield = myPDFFields.Fields("fill_69")
                            DirectCast(pdffield, TallComponents.PDF.Forms.Fields.TextField).Value = FormatCurrency(moneycalcopt).Replace("$", "")

                        ElseIf I = 2 Then
                            pdffield = myPDFFields.Fields("Optional CoveragesRow2")
                            DirectCast(pdffield, TallComponents.PDF.Forms.Fields.TextField).Value = Description
                            pdffield = myPDFFields.Fields("fill_70")
                            DirectCast(pdffield, TallComponents.PDF.Forms.Fields.TextField).Value = FormatCurrency(moneycalcopt).Replace("$", "")
                        ElseIf I = 3 Then
                            pdffield = myPDFFields.Fields("Optional CoveragesRow3")
                            DirectCast(pdffield, TallComponents.PDF.Forms.Fields.TextField).Value = Description
                            pdffield = myPDFFields.Fields("fill_71")
                            DirectCast(pdffield, TallComponents.PDF.Forms.Fields.TextField).Value = FormatCurrency(moneycalcopt).Replace("$", "")
                        ElseIf I = 4 Then
                            pdffield = myPDFFields.Fields("Optional CoveragesRow4")
                            DirectCast(pdffield, TallComponents.PDF.Forms.Fields.TextField).Value = Description
                            pdffield = myPDFFields.Fields("fill_72")
                            DirectCast(pdffield, TallComponents.PDF.Forms.Fields.TextField).Value = FormatCurrency(moneycalcopt).Replace("$", "")
                        ElseIf I = 5 Then
                            pdffield = myPDFFields.Fields("Optional CoveragesRow5")
                            DirectCast(pdffield, TallComponents.PDF.Forms.Fields.TextField).Value = Description
                            pdffield = myPDFFields.Fields("fill_73")
                            DirectCast(pdffield, TallComponents.PDF.Forms.Fields.TextField).Value = FormatCurrency(moneycalcopt).Replace("$", "")
                        ElseIf I = 6 Then
                            pdffield = myPDFFields.Fields("Optional CoveragesRow6")
                            DirectCast(pdffield, TallComponents.PDF.Forms.Fields.TextField).Value = Description
                            pdffield = myPDFFields.Fields("fill_76")
                            DirectCast(pdffield, TallComponents.PDF.Forms.Fields.TextField).Value = FormatCurrency(moneycalcopt).Replace("$", "")

                        End If
                        moneycalcopt = "0.00"
                        Description = ""
                        moneys = ""
                        If ds4.Tables(0).Rows(0).Item("ARStandardAddResPrem").ToString().Replace("$", "") > "0.00" Or ds4.Tables(0).Rows(0).Item("ARStandardWaterPrem").ToString().Replace("$", "") > "0.00" Then
                            If ds4.Tables(0).Rows(0).Item("ARStandardAddResPrem").ToString().Replace("$", "") > "0.00" Then
                                Description = "Additional Resident: "
                                moneys = ds4.Tables(0).Rows(0).Item("ARStandardAddResPrem").ToString()
                                Description += moneys
                                moneycalcopt += CInt(moneys)

                            End If
                            If ds4.Tables(0).Rows(0).Item("ARStandardAddResPrem").ToString().Replace("$", "") > "0.00" And ds4.Tables(0).Rows(0).Item("ARStandardWaterPrem").ToString().Replace("$", "") > "0.00" Then
                                Description += "\"
                            End If
                            If ds4.Tables(0).Rows(0).Item("ARStandardWaterPrem").ToString().Replace("$", "") > "0.00" Then
                                Description += "Watercraft:"
                                moneys = ds4.Tables(0).Rows(0).Item("ARStandardWaterPrem").ToString()
                                Description += moneys
                                moneycalcopt += CInt(moneys)
                            End If


                        End If
                        I += 1
                        If I = 1 Then
                            pdffield = myPDFFields.Fields("Optional CoveragesRow1")
                            DirectCast(pdffield, TallComponents.PDF.Forms.Fields.TextField).Value = Description
                            pdffield = myPDFFields.Fields("fill_69")
                            DirectCast(pdffield, TallComponents.PDF.Forms.Fields.TextField).Value = FormatCurrency(moneycalcopt).Replace("$", "")

                        ElseIf I = 2 Then
                            pdffield = myPDFFields.Fields("Optional CoveragesRow2")
                            DirectCast(pdffield, TallComponents.PDF.Forms.Fields.TextField).Value = Description
                            pdffield = myPDFFields.Fields("fill_70")
                            DirectCast(pdffield, TallComponents.PDF.Forms.Fields.TextField).Value = FormatCurrency(moneycalcopt).Replace("$", "")
                        ElseIf I = 3 Then
                            pdffield = myPDFFields.Fields("Optional CoveragesRow3")
                            DirectCast(pdffield, TallComponents.PDF.Forms.Fields.TextField).Value = Description
                            pdffield = myPDFFields.Fields("fill_71")
                            DirectCast(pdffield, TallComponents.PDF.Forms.Fields.TextField).Value = FormatCurrency(moneycalcopt).Replace("$", "")
                        ElseIf I = 4 Then
                            pdffield = myPDFFields.Fields("Optional CoveragesRow4")
                            DirectCast(pdffield, TallComponents.PDF.Forms.Fields.TextField).Value = Description
                            pdffield = myPDFFields.Fields("fill_72")
                            DirectCast(pdffield, TallComponents.PDF.Forms.Fields.TextField).Value = FormatCurrency(moneycalcopt).Replace("$", "")
                        ElseIf I = 5 Then
                            pdffield = myPDFFields.Fields("Optional CoveragesRow5")
                            DirectCast(pdffield, TallComponents.PDF.Forms.Fields.TextField).Value = Description
                            pdffield = myPDFFields.Fields("fill_73")
                            DirectCast(pdffield, TallComponents.PDF.Forms.Fields.TextField).Value = FormatCurrency(moneycalcopt).Replace("$", "")
                        ElseIf I = 6 Then
                            pdffield = myPDFFields.Fields("Optional CoveragesRow6")
                            DirectCast(pdffield, TallComponents.PDF.Forms.Fields.TextField).Value = Description
                            pdffield = myPDFFields.Fields("fill_76")
                            DirectCast(pdffield, TallComponents.PDF.Forms.Fields.TextField).Value = FormatCurrency(moneycalcopt).Replace("$", "")

                        End If
                        moneycalcopt = "0.00"
                        Description = ""
                        moneys = ""

                        If ds4.Tables(0).Rows(0).Item("ARStandardVPerPropPrem").ToString().Replace("$", "") > "0.00" Then
                            Description += "Valuable Personal Property:"
                            moneys = ds4.Tables(0).Rows(0).Item("ARStandardVPerPropPrem").ToString()
                            Description += moneys
                            moneycalcopt += CInt(moneys)
                        End If
                        I += 1
                        If I = 1 Then
                            pdffield = myPDFFields.Fields("Optional CoveragesRow1")
                            DirectCast(pdffield, TallComponents.PDF.Forms.Fields.TextField).Value = Description
                            pdffield = myPDFFields.Fields("fill_69")
                            DirectCast(pdffield, TallComponents.PDF.Forms.Fields.TextField).Value = FormatCurrency(moneycalcopt).Replace("$", "")

                        ElseIf I = 2 Then
                            pdffield = myPDFFields.Fields("Optional CoveragesRow2")
                            DirectCast(pdffield, TallComponents.PDF.Forms.Fields.TextField).Value = Description
                            pdffield = myPDFFields.Fields("fill_70")
                            DirectCast(pdffield, TallComponents.PDF.Forms.Fields.TextField).Value = FormatCurrency(moneycalcopt).Replace("$", "")
                        ElseIf I = 3 Then
                            pdffield = myPDFFields.Fields("Optional CoveragesRow3")
                            DirectCast(pdffield, TallComponents.PDF.Forms.Fields.TextField).Value = Description
                            pdffield = myPDFFields.Fields("fill_71")
                            DirectCast(pdffield, TallComponents.PDF.Forms.Fields.TextField).Value = FormatCurrency(moneycalcopt).Replace("$", "")
                        ElseIf I = 4 Then
                            pdffield = myPDFFields.Fields("Optional CoveragesRow4")
                            DirectCast(pdffield, TallComponents.PDF.Forms.Fields.TextField).Value = Description
                            pdffield = myPDFFields.Fields("fill_72")
                            DirectCast(pdffield, TallComponents.PDF.Forms.Fields.TextField).Value = FormatCurrency(moneycalcopt).Replace("$", "")
                        ElseIf I = 5 Then
                            pdffield = myPDFFields.Fields("Optional CoveragesRow5")
                            DirectCast(pdffield, TallComponents.PDF.Forms.Fields.TextField).Value = Description
                            pdffield = myPDFFields.Fields("fill_73")
                            DirectCast(pdffield, TallComponents.PDF.Forms.Fields.TextField).Value = FormatCurrency(moneycalcopt).Replace("$", "")
                        ElseIf I = 6 Then
                            pdffield = myPDFFields.Fields("Optional CoveragesRow6")
                            DirectCast(pdffield, TallComponents.PDF.Forms.Fields.TextField).Value = Description
                            pdffield = myPDFFields.Fields("fill_76")
                            DirectCast(pdffield, TallComponents.PDF.Forms.Fields.TextField).Value = FormatCurrency(moneycalcopt).Replace("$", "")


                        End If


                    Case "Rental"
                        If ds4.Tables(0).Rows(0).Item("ARRentalSecIntPrem").ToString().Replace("$", "") > "0.00" Or ds4.Tables(0).Rows(0).Item("ARRentalNatDisPrem").ToString().Replace("$", "") > "0.00" Then
                            If ds4.Tables(0).Rows(0).Item("ARRentalSecIntPrem").ToString().Replace("$", "") > "0.00" Then
                                Description = "Security Interest: "
                                moneys = ds4.Tables(0).Rows(0).Item("ARRentalSecIntPrem").ToString()
                                Description += moneys
                                moneycalcopt += CInt(moneys)

                            End If
                            If ds4.Tables(0).Rows(0).Item("ARRentalSecIntPrem").ToString().Replace("$", "") > "0.00" And ds4.Tables(0).Rows(0).Item("ARRentalNatDisPrem").ToString().Replace("$", "") > "0.00" Then
                                Description += "\"
                            End If
                            If ds4.Tables(0).Rows(0).Item("ARRentalNatDisPrem").ToString().Replace("$", "") > "0.00" Then
                                Description += "Natural Disaster :"
                                moneys = ds4.Tables(0).Rows(0).Item("ARRentalNatDisPrem").ToString()
                                Description += moneys
                                moneycalcopt += CInt(moneys)
                            End If


                        End If
                        I += 1
                        If I = 1 Then
                            pdffield = myPDFFields.Fields("Optional CoveragesRow1")
                            DirectCast(pdffield, TallComponents.PDF.Forms.Fields.TextField).Value = Description
                            pdffield = myPDFFields.Fields("fill_69")
                            DirectCast(pdffield, TallComponents.PDF.Forms.Fields.TextField).Value = FormatCurrency(moneycalcopt).Replace("$", "")

                        ElseIf I = 2 Then
                            pdffield = myPDFFields.Fields("Optional CoveragesRow2")
                            DirectCast(pdffield, TallComponents.PDF.Forms.Fields.TextField).Value = Description
                            pdffield = myPDFFields.Fields("fill_70")
                            DirectCast(pdffield, TallComponents.PDF.Forms.Fields.TextField).Value = FormatCurrency(moneycalcopt).Replace("$", "")
                        ElseIf I = 3 Then
                            pdffield = myPDFFields.Fields("Optional CoveragesRow3")
                            DirectCast(pdffield, TallComponents.PDF.Forms.Fields.TextField).Value = Description
                            pdffield = myPDFFields.Fields("fill_71")
                            DirectCast(pdffield, TallComponents.PDF.Forms.Fields.TextField).Value = FormatCurrency(moneycalcopt).Replace("$", "")
                        ElseIf I = 4 Then
                            pdffield = myPDFFields.Fields("Optional CoveragesRow4")
                            DirectCast(pdffield, TallComponents.PDF.Forms.Fields.TextField).Value = Description
                            pdffield = myPDFFields.Fields("fill_72")
                            DirectCast(pdffield, TallComponents.PDF.Forms.Fields.TextField).Value = FormatCurrency(moneycalcopt).Replace("$", "")
                        ElseIf I = 5 Then
                            pdffield = myPDFFields.Fields("Optional CoveragesRow5")
                            DirectCast(pdffield, TallComponents.PDF.Forms.Fields.TextField).Value = Description
                            pdffield = myPDFFields.Fields("fill_73")
                            DirectCast(pdffield, TallComponents.PDF.Forms.Fields.TextField).Value = FormatCurrency(moneycalcopt).Replace("$", "")
                        ElseIf I = 6 Then
                            pdffield = myPDFFields.Fields("Optional CoveragesRow6")
                            DirectCast(pdffield, TallComponents.PDF.Forms.Fields.TextField).Value = Description
                            pdffield = myPDFFields.Fields("fill_76")
                            DirectCast(pdffield, TallComponents.PDF.Forms.Fields.TextField).Value = FormatCurrency(moneycalcopt).Replace("$", "")

                        End If
                        moneycalcopt = "0.00"
                        Description = ""
                        moneys = ""
                        If ds4.Tables(0).Rows(0).Item("ARRentalAddResPrem").ToString().Replace("$", "") > "0.00" Or ds4.Tables(0).Rows(0).Item("ARRentalWaterPrem").ToString().Replace("$", "") > "0.00" Then
                            If ds4.Tables(0).Rows(0).Item("ARRentalAddResPrem").ToString().Replace("$", "") > "0.00" Then
                                Description = "Additional Resident: "
                                moneys = ds4.Tables(0).Rows(0).Item("ARRentalAddResPrem").ToString()
                                Description += moneys
                                moneycalcopt += CInt(moneys)

                            End If
                            If ds4.Tables(0).Rows(0).Item("ARRentalAddResPrem").ToString().Replace("$", "") > "0.00" And ds4.Tables(0).Rows(0).Item("ARRentalWaterPrem").ToString().Replace("$", "") > "0.00" Then
                                Description += "\"
                            End If
                            If ds4.Tables(0).Rows(0).Item("ARRentalWaterPrem").ToString().Replace("$", "") > "0.00" Then
                                Description += "Watercraft:"
                                moneys = ds4.Tables(0).Rows(0).Item("ARRentalWaterPrem").ToString()
                                Description += moneys
                                moneycalcopt += CInt(moneys)
                            End If


                        End If
                        I += 1
                        If I = 1 Then
                            pdffield = myPDFFields.Fields("Optional CoveragesRow1")
                            DirectCast(pdffield, TallComponents.PDF.Forms.Fields.TextField).Value = Description
                            pdffield = myPDFFields.Fields("fill_69")
                            DirectCast(pdffield, TallComponents.PDF.Forms.Fields.TextField).Value = FormatCurrency(moneycalcopt).Replace("$", "")

                        ElseIf I = 2 Then
                            pdffield = myPDFFields.Fields("Optional CoveragesRow2")
                            DirectCast(pdffield, TallComponents.PDF.Forms.Fields.TextField).Value = Description
                            pdffield = myPDFFields.Fields("fill_70")
                            DirectCast(pdffield, TallComponents.PDF.Forms.Fields.TextField).Value = FormatCurrency(moneycalcopt).Replace("$", "")
                        ElseIf I = 3 Then
                            pdffield = myPDFFields.Fields("Optional CoveragesRow3")
                            DirectCast(pdffield, TallComponents.PDF.Forms.Fields.TextField).Value = Description
                            pdffield = myPDFFields.Fields("fill_71")
                            DirectCast(pdffield, TallComponents.PDF.Forms.Fields.TextField).Value = FormatCurrency(moneycalcopt).Replace("$", "")
                        ElseIf I = 4 Then
                            pdffield = myPDFFields.Fields("Optional CoveragesRow4")
                            DirectCast(pdffield, TallComponents.PDF.Forms.Fields.TextField).Value = Description
                            pdffield = myPDFFields.Fields("fill_72")
                            DirectCast(pdffield, TallComponents.PDF.Forms.Fields.TextField).Value = FormatCurrency(moneycalcopt).Replace("$", "")
                        ElseIf I = 5 Then
                            pdffield = myPDFFields.Fields("Optional CoveragesRow5")
                            DirectCast(pdffield, TallComponents.PDF.Forms.Fields.TextField).Value = Description
                            pdffield = myPDFFields.Fields("fill_73")
                            DirectCast(pdffield, TallComponents.PDF.Forms.Fields.TextField).Value = FormatCurrency(moneycalcopt).Replace("$", "")
                        ElseIf I = 6 Then
                            pdffield = myPDFFields.Fields("Optional CoveragesRow6")
                            DirectCast(pdffield, TallComponents.PDF.Forms.Fields.TextField).Value = Description
                            pdffield = myPDFFields.Fields("fill_76")
                            DirectCast(pdffield, TallComponents.PDF.Forms.Fields.TextField).Value = FormatCurrency(moneycalcopt).Replace("$", "")

                        End If
                        moneycalcopt = "0.00"
                        Description = ""
                        moneys = ""

                        If ds4.Tables(0).Rows(0).Item("ARRentalVPerPropPrem").ToString().Replace("$", "") > "0.00" Then
                            Description += "Valuable Personal Property:"
                            moneys = ds4.Tables(0).Rows(0).Item("ARRentalVPerPropPrem").ToString()
                            Description += moneys
                            moneycalcopt += CInt(moneys)
                        End If
                        I += 1
                        If I = 1 Then
                            pdffield = myPDFFields.Fields("Optional CoveragesRow1")
                            DirectCast(pdffield, TallComponents.PDF.Forms.Fields.TextField).Value = Description
                            pdffield = myPDFFields.Fields("fill_69")
                            DirectCast(pdffield, TallComponents.PDF.Forms.Fields.TextField).Value = FormatCurrency(moneycalcopt).Replace("$", "")

                        ElseIf I = 2 Then
                            pdffield = myPDFFields.Fields("Optional CoveragesRow2")
                            DirectCast(pdffield, TallComponents.PDF.Forms.Fields.TextField).Value = Description
                            pdffield = myPDFFields.Fields("fill_70")
                            DirectCast(pdffield, TallComponents.PDF.Forms.Fields.TextField).Value = FormatCurrency(moneycalcopt).Replace("$", "")
                        ElseIf I = 3 Then
                            pdffield = myPDFFields.Fields("Optional CoveragesRow3")
                            DirectCast(pdffield, TallComponents.PDF.Forms.Fields.TextField).Value = Description
                            pdffield = myPDFFields.Fields("fill_71")
                            DirectCast(pdffield, TallComponents.PDF.Forms.Fields.TextField).Value = FormatCurrency(moneycalcopt).Replace("$", "")
                        ElseIf I = 4 Then
                            pdffield = myPDFFields.Fields("Optional CoveragesRow4")
                            DirectCast(pdffield, TallComponents.PDF.Forms.Fields.TextField).Value = Description
                            pdffield = myPDFFields.Fields("fill_72")
                            DirectCast(pdffield, TallComponents.PDF.Forms.Fields.TextField).Value = FormatCurrency(moneycalcopt).Replace("$", "")
                        ElseIf I = 5 Then
                            pdffield = myPDFFields.Fields("Optional CoveragesRow5")
                            DirectCast(pdffield, TallComponents.PDF.Forms.Fields.TextField).Value = Description
                            pdffield = myPDFFields.Fields("fill_73")
                            DirectCast(pdffield, TallComponents.PDF.Forms.Fields.TextField).Value = FormatCurrency(moneycalcopt).Replace("$", "")
                        ElseIf I = 6 Then
                            pdffield = myPDFFields.Fields("Optional CoveragesRow6")
                            DirectCast(pdffield, TallComponents.PDF.Forms.Fields.TextField).Value = Description
                            pdffield = myPDFFields.Fields("fill_76")
                            DirectCast(pdffield, TallComponents.PDF.Forms.Fields.TextField).Value = FormatCurrency(moneycalcopt).Replace("$", "")

                        End If

                End Select


            End If


            'Make the PDF Flattened
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