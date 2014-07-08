﻿Imports System.Data.SqlClient
Imports DevExpress.Web.ASPxEditors


Public Class ARApplication
    Inherits System.Web.UI.Page
    Dim com As New Common
    Dim quoteID As String
    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load


        If Not IsPostBack Then
          
            If Request.QueryString("quoteID") <> "" Then '  quoteID is not empty

                quoteID = Request.QueryString("quoteID")
                'for testing
                'quoteID = "79"
                '------------------
                txtQuoteID.Text = Request.QueryString("quoteID")
                loadData(quoteID)

            End If
            findimport.Attributes.Add("onClick", "redirect3(); return false;")
            Dim test As String = mySession.CurrentUser.UWUser.ToString
            If mySession.CurrentUser.UWUser.ToString = "False" Then
                findimport.Visible = False

                findimport.Width = "0"
            End If
            If mySession.CurrentUser.AdminUser.ToString = "True" Then
                findimport.Visible = True


            End If
            txtDOB.Attributes.Add("onKeyPress", "return UpdateDOB();")
            txtSpouseDOB.Attributes.Add("onKeyPress", "return UpdateSpouseDOB();")
            ddParkStatus.Attributes.Add("onChange", "return parkStatus();")
            ddSupHeating.Attributes.Add("onChange", "return supHeating();")
            ddPriorInsurance.Attributes.Add("onChange", "return PriorIns();")
            ddAnimal.Attributes.Add("onChange", "return AnimalType();")
            addlInsuredcheck.Attributes.Add("onChange", "return AdditionalIns();")
            txtZip.Attributes.Add("onKeyUp", "return zipcodeKeyDown1();")
            txtDiffAppZip.Attributes.Add("onKeyUp", "return zipcodeKeyDown();")
            txtaddzip.Attributes.Add("onKeyUp", "return zipcodeKeyDown2();")
            txtLien1Zip.Attributes.Add("onKeyUp", "return zipcodeKeyDown3();")
            txtLien2Zip.Attributes.Add("onKeyUp", "return zipcodeKeyDown4();")
            ddPaymentOpt.Attributes.Add("onChange", "return HideFinanceOptions();")
            LoadEligiblityEvents()
            checkFinancing(quoteID)
            DupLocation.Checked = False



        End If

    End Sub
    Protected Sub loadData(ByVal quoteID As String)
        Dim ds As System.Data.DataSet
        ds = com.runQueryDS("EXEC GetQuoteApplicationData '" & quoteID & "'", "ColonialMHConnectionString")
        If ds.Tables(0).Rows.Count > 0 Then
            txtAppNumber.Text = ds.Tables(0).Rows(0).Item("applicationID").ToString()
            txtName.Text = ds.Tables(0).Rows(0).Item("ARName").ToString()
            txtDOB.Text = ds.Tables(0).Rows(0).Item("applicantDOB").ToString()
            txtDiffAppAddr.Text = ds.Tables(0).Rows(0).Item("propAddress").ToString()
            txtDiffAppCity.Text = ds.Tables(0).Rows(0).Item("propcity").ToString()
            txtDiffAppState.Text = ds.Tables(0).Rows(0).Item("propstate").ToString()
            txtDiffAppZip.Text = ds.Tables(0).Rows(0).Item("propzip").ToString()
            txtDiffAppCounty.Text = ds.Tables(0).Rows(0).Item("propcounty").ToString()
            txtPhone2.Text = ds.Tables(0).Rows(0).Item("Phone").ToString()
            txtOcc.Text = ds.Tables(0).Rows(0).Item("Occ").ToString()
            txtSSN2.Text = ds.Tables(0).Rows(0).Item("SSN").ToString()
            txtSpouseName.Text = ds.Tables(0).Rows(0).Item("SpouseName").ToString()
            txtSpouseSSN.Text = ds.Tables(0).Rows(0).Item("SpouseSSN").ToString()
            txtSpouseDOB.Text = ds.Tables(0).Rows(0).Item("SpouseDOB").ToString()
            'additional insured
            addlInsuredcheck.SelectedValue = ds.Tables(0).Rows(0).Item("AddInsured").ToString()
            txtAddInsured.Text = ds.Tables(0).Rows(0).Item("AddInsuredName").ToString()
            txtAddAddress.Text = ds.Tables(0).Rows(0).Item("AddInsuredAddress").ToString()
            txtaddcity.Text = ds.Tables(0).Rows(0).Item("AddInsuredCity").ToString()
            txtaddstate.Text = ds.Tables(0).Rows(0).Item("AddInsuredState").ToString()
            txtaddzip.Text = ds.Tables(0).Rows(0).Item("AddInsuredZip").ToString()
            txtaddcounty.Text = ds.Tables(0).Rows(0).Item("AddInsuredCounty").ToString()

            'txtAddInsured.Text = ds.Tables(0).Rows(0).Item("AddInsured").ToString()

            txtAgentName.Text = ds.Tables(0).Rows(0).Item("qagentName").ToString()
            txtQuoteID.Text = ds.Tables(0).Rows(0).Item("qquoteID").ToString()
            txtAddress.Text = ds.Tables(0).Rows(0).Item("DiffAppAddr").ToString()
            txtCity.Text = ds.Tables(0).Rows(0).Item("DiffAppCity").ToString()
            txtState.Text = ds.Tables(0).Rows(0).Item("DiffAppState").ToString()
            txtZip.Text = ds.Tables(0).Rows(0).Item("DiffAppzip").ToString()
            txtCounty.Text = ds.Tables(0).Rows(0).Item("DiffAppCounty").ToString()
            txtMunTaxCode.Text = ds.Tables(0).Rows(0).Item("MunTaxCode").ToString()
            txtDistToFire.Text = ds.Tables(0).Rows(0).Item("DistToFire").ToString()
            txtDistToFireDept.Text = ds.Tables(0).Rows(0).Item("DistToFireDept").ToString()
            txtFireDeptName.Text = ds.Tables(0).Rows(0).Item("FireDeptName").ToString()
            txtParkName.Text = ds.Tables(0).Rows(0).Item("ParkName").ToString()

            dd_ctylimits.SelectedValue = ds.Tables(0).Rows(0).Item("ctylimits").ToString()
            dd_fwua.SelectedValue = ds.Tables(0).Rows(0).Item("fwua").ToString()
            txtDistToGulf.Text = ds.Tables(0).Rows(0).Item("distToCoast").ToString()
            txtDescMHYear.Text = ds.Tables(0).Rows(0).Item("MHYear").ToString()
            txtDescMHManf.Text = ds.Tables(0).Rows(0).Item("MHmanf").ToString()
            txtDescMHLength.Text = ds.Tables(0).Rows(0).Item("MHLength").ToString()
            txtDescMHWidth.Text = ds.Tables(0).Rows(0).Item("MHWidth").ToString()
            txtDescMHSerial.Text = ds.Tables(0).Rows(0).Item("DescMHSerial").ToString()
            txtDescMHPurDate2.Text = ds.Tables(0).Rows(0).Item("DescMHPurDate").ToString()
            txtDescMHPurPrice2.Text = FormatCurrency(ds.Tables(0).Rows(0).Item("DescMHPurPrice").ToString())
            txtDescMHCurDate2.Text = Date.Now.ToString("MM/dd/yyyy") 'ds.Tables(0).Rows(0).Item("DescMHCurDate").ToString()
            txtDescMHAttStruc.Text = ds.Tables(0).Rows(0).Item("DescMHAttStruc").ToString()
            txtDescMHAttStrucAge.Text = ds.Tables(0).Rows(0).Item("DescMHAttStrucAge").ToString()
            txtDescMHAttStrucSize.Text = ds.Tables(0).Rows(0).Item("DescMHAttStrucSize").ToString()
            txtDescMHAttStrucCurVal2.Text = FormatCurrency(ds.Tables(0).Rows(0).Item("DescMHAttStrucCurVal").ToString())
            txtDescMHUnAttStruc.Text = ds.Tables(0).Rows(0).Item("DescMHUnAttStruc").ToString()
            txtDescMHUnAttStrucAge.Text = ds.Tables(0).Rows(0).Item("DescMHUnAttStrucAge").ToString()
            txtDescMHUnAttStrucSize.Text = ds.Tables(0).Rows(0).Item("DescMHUnAttStrucSize").ToString()
            txtDescMHUnAttStrucCurVal2.Text = FormatCurrency(ds.Tables(0).Rows(0).Item("DescMHUnAttStrucCurVal").ToString())
            ddProgram.SelectedValue = ds.Tables(0).Rows(0).Item("Program").ToString()
            ddUsage.SelectedValue = ds.Tables(0).Rows(0).Item("Usage").ToString()
            ddProt.SelectedValue = ds.Tables(0).Rows(0).Item("Protection").ToString()
            txtInsAge.Text = ds.Tables(0).Rows(0).Item("appage").ToString()
            txtLien1Addr2.Text = ds.Tables(0).Rows(0).Item("Lien1Addr2").ToString()
            txtLien2Addr2.Text = ds.Tables(0).Rows(0).Item("Lien2Addr2").ToString()
            If ds.Tables(0).Rows(0).Item("MHAge").ToString() <> "" Then
                ddMHAge.SelectedValue = ds.Tables(0).Rows(0).Item("MHAge").ToString()
            Else
                Dim mhage As String
                mhage = ds.Tables(0).Rows(0).Item("Homeage").ToString()
                If mhage > 0 And mhage < 6 Then
                    ddMHAge.SelectedValue = "1-5 Yrs"
                ElseIf mhage > 5 And mhage < 16 Then
                    ddMHAge.SelectedValue = "6-15 Yrs"
                ElseIf mhage > 15 Then
                    ddMHAge.SelectedValue = "16 Yrs & Older"

                End If

            End If
            ddlossHist.SelectedValue = ds.Tables(0).Rows(0).Item("MHLoss").ToString()
            ddParkStatus.SelectedValue = ds.Tables(0).Rows(0).Item("isMHinPark").ToString()
            ddUnitType.SelectedValue = ds.Tables(0).Rows(0).Item("homeType").ToString()
            txtAcres.Text = ds.Tables(0).Rows(0).Item("Acres").ToString()
            txtNumOfSpaces.Text = ds.Tables(0).Rows(0).Item("NumOfSpaces").ToString()
            txtPerOfAdults.Text = ds.Tables(0).Rows(0).Item("PerOfAdults").ToString()
            ddResManger.SelectedValue = ds.Tables(0).Rows(0).Item("ResManger").ToString()
            ' ddUnitType.SelectedValue = ds.Tables(0).Rows(0).Item("UnitType").ToString()
            txtNumOfFrontSteps.Text = ds.Tables(0).Rows(0).Item("NumOfFrontSteps").ToString()
            txtNumOfRearSteps.Text = ds.Tables(0).Rows(0).Item("NumOfRearSteps").ToString()
            'ddSupHeating.SelectedValue = ds.Tables(0).Rows(0).Item("suppHeating").ToString()
            ddSupHeating.SelectedItem.Value = ds.Tables(0).Rows(0).Item("suppHeating").ToString()
            ddSatDish.SelectedValue = ds.Tables(0).Rows(0).Item("SatDish").ToString()
            ddAnimal.SelectedValue = ds.Tables(0).Rows(0).Item("Animal").ToString()
            txtAnimalType.Text = ds.Tables(0).Rows(0).Item("AnimalType").ToString()
            txtDogBreed.Text = ds.Tables(0).Rows(0).Item("DogBreed").ToString()
            txtLien1Name.Text = ds.Tables(0).Rows(0).Item("Lien1Name").ToString()
            txtLien1Num.Text = ds.Tables(0).Rows(0).Item("Lien1Num").ToString()
            txtLien1Addr.Text = ds.Tables(0).Rows(0).Item("Lien1Addr").ToString()
            txtLien1City.Text = ds.Tables(0).Rows(0).Item("Lien1City").ToString()
            txtLien1State.Text = ds.Tables(0).Rows(0).Item("Lien1State").ToString()
            txtLien1Zip.Text = ds.Tables(0).Rows(0).Item("Lien1Zip").ToString()
            txtLien2Name.Text = ds.Tables(0).Rows(0).Item("Lien2Name").ToString()
            txtLien2Num.Text = ds.Tables(0).Rows(0).Item("Lien2Num").ToString()
            txtLien2Addr.Text = ds.Tables(0).Rows(0).Item("Lien2Addr").ToString()
            txtLien2City.Text = ds.Tables(0).Rows(0).Item("Lien2City").ToString()
            txtLien2State.Text = ds.Tables(0).Rows(0).Item("Lien2State").ToString()
            txtLien2Zip.Text = ds.Tables(0).Rows(0).Item("Lien2Zip").ToString()
            ddPriorInsurance.SelectedValue = ds.Tables(0).Rows(0).Item("PriorInsurance").ToString()
            txtPriorCompany.Text = ds.Tables(0).Rows(0).Item("PriorCompany").ToString()
            'txtLoss1Date.Text = ds.Tables(0).Rows(0).Item("Loss1Date").ToString()
            'ddLoss1Type.SelectedValue = ds.Tables(0).Rows(0).Item("Loss1Type").ToString()
            'txtLoss1Description.Text = ds.Tables(0).Rows(0).Item("Loss1Description").ToString()
            'txtLoss1AmtPaid.Text = ds.Tables(0).Rows(0).Item("Loss1AmtPaid").ToString()
            'ddLoss1Status.SelectedValue = ds.Tables(0).Rows(0).Item("Loss1Status").ToString()
            'txtLoss2Date.Text = ds.Tables(0).Rows(0).Item("Loss2Date").ToString()
            'ddLoss2Type.SelectedValue = ds.Tables(0).Rows(0).Item("Loss2Type").ToString()
            'txtLoss2Description.Text = ds.Tables(0).Rows(0).Item("Loss2Description").ToString()
            'txtLoss2AmtPaid.Text = ds.Tables(0).Rows(0).Item("Loss2AmtPaid").ToString()
            'ddLoss2Status.SelectedValue = ds.Tables(0).Rows(0).Item("Loss2Status").ToString()
            'txtLoss3Date.Text = ds.Tables(0).Rows(0).Item("Loss3Date").ToString()
            'ddLoss3Type.SelectedValue = ds.Tables(0).Rows(0).Item("Loss3Type").ToString()
            'txtLoss3Description.Text = ds.Tables(0).Rows(0).Item("Loss3Description").ToString()
            'txtLoss3AmtPaid.Text = ds.Tables(0).Rows(0).Item("Loss3AmtPaid").ToString()
            'ddLoss3Status.SelectedValue = ds.Tables(0).Rows(0).Item("Loss3Status").ToString()
            dd_ARIng1.SelectedValue = ds.Tables(0).Rows(0).Item("ARIng1").ToString()
            dd_ARIng2.SelectedValue = ds.Tables(0).Rows(0).Item("ARIng2").ToString()
            dd_ARIng3.SelectedValue = ds.Tables(0).Rows(0).Item("ARIng3").ToString()
            dd_ARIng4.SelectedValue = ds.Tables(0).Rows(0).Item("ARIng4").ToString()
            dd_ARIng5.SelectedValue = ds.Tables(0).Rows(0).Item("ARIng5").ToString()
            dd_ARIng6.SelectedValue = ds.Tables(0).Rows(0).Item("ARIng6").ToString()
            dd_ARIng7.SelectedValue = ds.Tables(0).Rows(0).Item("ARIng7").ToString()
            dd_ARIng8.SelectedValue = ds.Tables(0).Rows(0).Item("ARIng8").ToString()
            dd_ARIng9.SelectedValue = ds.Tables(0).Rows(0).Item("ARIng9").ToString()
            dd_ARIng10.SelectedValue = ds.Tables(0).Rows(0).Item("ARIng10").ToString()
            dd_ARIng11.SelectedValue = ds.Tables(0).Rows(0).Item("ARIng11").ToString()
            dd_ARIng12.SelectedValue = ds.Tables(0).Rows(0).Item("ARIng12").ToString()
            dd_ARIng13.SelectedValue = ds.Tables(0).Rows(0).Item("ARIng13").ToString()
            dd_ARIng14.SelectedValue = ds.Tables(0).Rows(0).Item("ARIng14").ToString()
            dd_ARIng15.SelectedValue = ds.Tables(0).Rows(0).Item("ARIng15").ToString()
            dd_ARIng16.SelectedValue = ds.Tables(0).Rows(0).Item("ARIng16").ToString()
            dd_ARIng17.SelectedValue = ds.Tables(0).Rows(0).Item("ARIng17").ToString()
            dd_ARIng18.SelectedValue = ds.Tables(0).Rows(0).Item("ARIng18").ToString()
            dd_ARIng19.SelectedValue = ds.Tables(0).Rows(0).Item("ARIng19").ToString()
            dd_ARIng20.SelectedValue = ds.Tables(0).Rows(0).Item("ARIng20").ToString()
            dd_ARIng21.SelectedValue = ds.Tables(0).Rows(0).Item("ARIng21").ToString()
            dd_ARIng22.SelectedValue = ds.Tables(0).Rows(0).Item("ARIng22").ToString()
            dd_ARIng23.SelectedValue = ds.Tables(0).Rows(0).Item("ARIng23").ToString()
            dd_ARIng24.SelectedValue = ds.Tables(0).Rows(0).Item("ARIng24").ToString()
            dd_ARIng25.SelectedValue = ds.Tables(0).Rows(0).Item("ARIng25").ToString()
            dd_ARIng26.SelectedValue = ds.Tables(0).Rows(0).Item("ARIng26").ToString()
            dd_ARIng27.SelectedValue = ds.Tables(0).Rows(0).Item("ARIng27").ToString()
            dd_ARIng28.SelectedValue = ds.Tables(0).Rows(0).Item("ARIng28").ToString()
            dd_ARIng29.SelectedValue = ds.Tables(0).Rows(0).Item("ARIng29").ToString()
            dd_ARIng30.SelectedValue = ds.Tables(0).Rows(0).Item("ARIng30").ToString()
            dd_ARIng31.SelectedValue = ds.Tables(0).Rows(0).Item("ARIng31").ToString()
            dd_ARIng32.SelectedValue = ds.Tables(0).Rows(0).Item("ARIng32").ToString()
            dd_ARIng33.SelectedValue = ds.Tables(0).Rows(0).Item("ARIng33").ToString()
            dd_ARIng34.SelectedValue = ds.Tables(0).Rows(0).Item("ARIng34").ToString()
            dd_ARIng35.SelectedValue = ds.Tables(0).Rows(0).Item("ARIng35").ToString()
            dd_ARIng36.SelectedValue = ds.Tables(0).Rows(0).Item("ARIng36").ToString()
            dd_ARIng37.SelectedValue = ds.Tables(0).Rows(0).Item("ARIng37").ToString()
            dd_ARIng38.SelectedValue = ds.Tables(0).Rows(0).Item("ARIng38").ToString()
            dd_ARIng39.SelectedValue = ds.Tables(0).Rows(0).Item("ARIng39").ToString()
            dd_ARIng40.SelectedValue = ds.Tables(0).Rows(0).Item("ARIng40").ToString()
            dd_ARIng41.SelectedValue = ds.Tables(0).Rows(0).Item("ARIng41").ToString()
            dd_ARIng42.SelectedValue = ds.Tables(0).Rows(0).Item("ARIng42").ToString()
            dd_ARIng43.SelectedValue = ds.Tables(0).Rows(0).Item("ARIng43").ToString()
            dddistOptionInsured.SelectedValue = ds.Tables(0).Rows(0).Item("distOptionInsured").ToString()
            dddistOptionAgent.SelectedValue = ds.Tables(0).Rows(0).Item("distOptionAgent").ToString()
            ddPaymentOpt.SelectedValue = ds.Tables(0).Rows(0).Item("PaymentOpt").ToString()
            txtprioryears.Text = ds.Tables(0).Rows(0).Item("PriorInsYears").ToString()
            lblTerritory.Text = "    " & ds.Tables(0).Rows(0).Item("Territory").ToString()
            LoadLosses()
            'Added to check for financing and update financing label

            If ds.Tables(0).Rows(0).Item("ImportID") = "0" Then
                printbtn1_Import.Visible = False
            Else
                printbtn1_Import.Visible = True
            End If

            'If ds.Tables(0).Rows(0).Item("ARApplicationID") <> "" Or ds.Tables(0).Rows(0).Item("ARApplicationID") <> "NULL" Then
            '    loadAppData(ds.Tables(0).Rows(0).Item("ARApplicationID").ToString)
            'Else

            'End If
        Else
            'no results
        End If
    End Sub
    Protected Sub LoadLosses()
        Dim ds As System.Data.DataSet
        ds = com.runQueryDS("EXEC sp_getLossesforApplication '" & quoteID & "'")
        If ds.Tables(0).Rows.Count > 0 Then
            txtLoss1Date.Text = ds.Tables(0).Rows(0).Item("Loss1Date").ToString()
            txtLoss1Description.Text = ds.Tables(0).Rows(0).Item("Loss1Description").ToString()
            txtLoss1AmtPaid.Text = ds.Tables(0).Rows(0).Item("Loss1AmtPaid").ToString()
            ddLoss1Status.SelectedValue = ds.Tables(0).Rows(0).Item("Loss1Status").ToString()
            ddLoss1Type.SelectedValue = ds.Tables(0).Rows(0).Item("Loss1Type").ToString()

            txtLoss2Date.Text = ds.Tables(0).Rows(0).Item("Loss2Date").ToString()
            txtLoss2Description.Text = ds.Tables(0).Rows(0).Item("Loss2Description").ToString()
            txtLoss2AmtPaid.Text = ds.Tables(0).Rows(0).Item("Loss2AmtPaid").ToString()
            ddLoss2Status.SelectedValue = ds.Tables(0).Rows(0).Item("Loss2Status").ToString()
            ddLoss2Type.SelectedValue = ds.Tables(0).Rows(0).Item("Loss2Type").ToString()

            txtLoss3Date.Text = ds.Tables(0).Rows(0).Item("Loss3Date").ToString()
            txtLoss3Description.Text = ds.Tables(0).Rows(0).Item("Loss3Description").ToString()
            txtLoss3AmtPaid.Text = ds.Tables(0).Rows(0).Item("Loss3AmtPaid").ToString()
            ddLoss3Status.SelectedValue = ds.Tables(0).Rows(0).Item("Loss3Status").ToString()
            ddLoss3Type.SelectedValue = ds.Tables(0).Rows(0).Item("Loss3Type").ToString()
        End If

    End Sub
    Protected Sub loadAppData(ByVal appID As String)
        Dim ds As System.Data.DataSet
        ds = com.runQueryDS("SELECT * FROM tblARApplication WHERE ApplicationID = '" & appID & "'")

        If ds.Tables(0).Rows.Count > 0 Then
            txtAppNumber.Text = ds.Tables(0).Rows(0).Item("applicationID")
            txtName.Text = ds.Tables(0).Rows(0).Item("Name")
            txtDOB.Text = ds.Tables(0).Rows(0).Item("DOB")
            txtAddress.Text = ds.Tables(0).Rows(0).Item("Address")
            txtCity.Text = ds.Tables(0).Rows(0).Item("City")
            txtState.Text = ds.Tables(0).Rows(0).Item("State")
            txtZip.Text = ds.Tables(0).Rows(0).Item("Zip")
            txtCounty.Text = ds.Tables(0).Rows(0).Item("County")
            txtPhone2.Text = ds.Tables(0).Rows(0).Item("Phone")
            txtOcc.Text = ds.Tables(0).Rows(0).Item("Occ")
            txtSSN2.Text = ds.Tables(0).Rows(0).Item("SSN")
            txtSpouseName.Text = ds.Tables(0).Rows(0).Item("SpouseName")
            txtSpouseSSN.Text = ds.Tables(0).Rows(0).Item("SpouseSSN")
            txtSpouseDOB.Text = ds.Tables(0).Rows(0).Item("SpouseDOB")
            txtAddInsured.Text = ds.Tables(0).Rows(0).Item("AddInsured")
            txtAgentName.Text = ds.Tables(0).Rows(0).Item("AgentName")
            txtDiffAppAddr.Text = ds.Tables(0).Rows(0).Item("DiffAppAddr")
            txtDiffAppCity.Text = ds.Tables(0).Rows(0).Item("DiffAppCity")
            txtDiffAppState.Text = ds.Tables(0).Rows(0).Item("DiffAppState")
            txtDiffAppZip.Text = ds.Tables(0).Rows(0).Item("DiffAppState")
            txtDiffAppCounty.Text = ds.Tables(0).Rows(0).Item("DiffAppCounty")
            txtMunTaxCode.Text = ds.Tables(0).Rows(0).Item("MunTaxCode")
            txtDistToFire.Text = ds.Tables(0).Rows(0).Item("DistToFire")
            txtDistToFireDept.Text = ds.Tables(0).Rows(0).Item("DistToFireDept")
            txtFireDeptName.Text = ds.Tables(0).Rows(0).Item("FireDeptName")
            dd_ctylimits.SelectedValue = ds.Tables(0).Rows(0).Item("ctylimits")
            dd_fwua.SelectedValue = ds.Tables(0).Rows(0).Item("fwua")
            txtDistToGulf.Text = ds.Tables(0).Rows(0).Item("DistToGulf")
            txtDescMHYear.Text = ds.Tables(0).Rows(0).Item("DescMHYear")
            txtDescMHManf.Text = ds.Tables(0).Rows(0).Item("DescMHManf")
            txtDescMHLength.Text = ds.Tables(0).Rows(0).Item("DescMHLength")
            txtDescMHWidth.Text = ds.Tables(0).Rows(0).Item("DescMHWidth")
            txtDescMHSerial.Text = ds.Tables(0).Rows(0).Item("DescMHSerial")
            txtDescMHPurDate2.Text = ds.Tables(0).Rows(0).Item("DescMHPurDate")
            txtDescMHPurPrice2.Text = ds.Tables(0).Rows(0).Item("DescMHPurPrice")
            txtDescMHCurDate2.Text = ds.Tables(0).Rows(0).Item("DescMHCurDate")
            txtDescMHAttStruc.Text = ds.Tables(0).Rows(0).Item("DescMHAttStruc")
            txtDescMHAttStrucAge.Text = ds.Tables(0).Rows(0).Item("DescMHAttStrucAge")
            txtDescMHAttStrucSize.Text = ds.Tables(0).Rows(0).Item("DescMHAttStrucSize")
            txtDescMHAttStrucCurVal2.Text = ds.Tables(0).Rows(0).Item("DescMHAttStrucCurVal")
            txtDescMHUnAttStruc.Text = ds.Tables(0).Rows(0).Item("DescMHUnAttStruc")
            txtDescMHUnAttStrucAge.Text = ds.Tables(0).Rows(0).Item("DescMHUnAttStrucAge")
            txtDescMHUnAttStrucSize.Text = ds.Tables(0).Rows(0).Item("DescMHUnAttStrucSize")
            txtDescMHUnAttStrucCurVal2.Text = ds.Tables(0).Rows(0).Item("DescMHUnAttStrucCurVal")
            ddProgram.SelectedValue = ds.Tables(0).Rows(0).Item("Program")
            ddUsage.SelectedValue = ds.Tables(0).Rows(0).Item("Usage")
            ddProt.SelectedValue = ds.Tables(0).Rows(0).Item("Protection")
            txtInsAge.Text = ds.Tables(0).Rows(0).Item("InsAge")
            ddMHAge.SelectedValue = ds.Tables(0).Rows(0).Item("MHAge")
            ddlossHist.SelectedValue = ds.Tables(0).Rows(0).Item("lossHist")
            ddParkStatus.SelectedValue = ds.Tables(0).Rows(0).Item("ParkStatus")
            txtAcres.Text = ds.Tables(0).Rows(0).Item("Acres")
            txtNumOfSpaces.Text = ds.Tables(0).Rows(0).Item("NumOfSpaces")
            txtPerOfAdults.Text = ds.Tables(0).Rows(0).Item("PerOfAdults")
            ddResManger.SelectedValue = ds.Tables(0).Rows(0).Item("ResManger")
            ddUnitType.SelectedValue = ds.Tables(0).Rows(0).Item("UnitType")
            txtNumOfFrontSteps.Text = ds.Tables(0).Rows(0).Item("NumOfFrontSteps")
            txtNumOfRearSteps.Text = ds.Tables(0).Rows(0).Item("NumOfRearSteps")
            'ddSupHeating.SelectedValue = ds.Tables(0).Rows(0).Item("SupHeating")
            'ddSupHeating.SelectedItem.Text =
            txtSupHeatOther.Text = ds.Tables(0).Rows(0).Item("SupHeatOther")
            ddSupHeatingFacInst.SelectedValue = ds.Tables(0).Rows(0).Item("SupHeatingFacInst")
            ddSatDish.SelectedValue = ds.Tables(0).Rows(0).Item("SatDish")
            ddAnimal.SelectedValue = ds.Tables(0).Rows(0).Item("Animal")
            txtAnimalType.Text = ds.Tables(0).Rows(0).Item("AnimalType")
            txtDogBreed.Text = ds.Tables(0).Rows(0).Item("DogBreed")
            txtLien1Name.Text = ds.Tables(0).Rows(0).Item("Lien1Name")
            txtLien1Num.Text = ds.Tables(0).Rows(0).Item("Lien1Num")
            txtLien1Addr.Text = ds.Tables(0).Rows(0).Item("Lien1Addr")
            txtLien1City.Text = ds.Tables(0).Rows(0).Item("Lien1City")
            txtLien1State.Text = ds.Tables(0).Rows(0).Item("Lien1State")
            txtLien1Zip.Text = ds.Tables(0).Rows(0).Item("Lien1Zip")
            txtLien2Name.Text = ds.Tables(0).Rows(0).Item("Lien2Name")
            txtLien2Num.Text = ds.Tables(0).Rows(0).Item("Lien2Num")
            txtLien2Addr.Text = ds.Tables(0).Rows(0).Item("Lien2Addr")
            txtLien2City.Text = ds.Tables(0).Rows(0).Item("Lien2City")
            txtLien2State.Text = ds.Tables(0).Rows(0).Item("Lien2State")
            txtLien2Zip.Text = ds.Tables(0).Rows(0).Item("Lien2Zip")
            ddPriorInsurance.SelectedValue = ds.Tables(0).Rows(0).Item("PriorInsurance")
            txtPriorCompany.Text = ds.Tables(0).Rows(0).Item("PriorCompany")
            txtLoss1Date.Text = ds.Tables(0).Rows(0).Item("Loss1Date")
            ddLoss1Type.SelectedValue = ds.Tables(0).Rows(0).Item("Loss1Type")
            txtLoss1Description.Text = ds.Tables(0).Rows(0).Item("Loss1Description")
            txtLoss1AmtPaid.Text = ds.Tables(0).Rows(0).Item("Loss1AmtPaid")
            ddLoss1Status.SelectedValue = ds.Tables(0).Rows(0).Item("Loss1Status")
            txtLoss2Date.Text = ds.Tables(0).Rows(0).Item("Loss2Date")
            ddLoss2Type.SelectedValue = ds.Tables(0).Rows(0).Item("Loss2Type")
            txtLoss2Description.Text = ds.Tables(0).Rows(0).Item("Loss2Description")
            txtLoss2AmtPaid.Text = ds.Tables(0).Rows(0).Item("Loss2AmtPaid")
            ddLoss2Status.SelectedValue = ds.Tables(0).Rows(0).Item("Loss2Status")
            txtLoss3Date.Text = ds.Tables(0).Rows(0).Item("Loss3Date")
            ddLoss3Type.SelectedValue = ds.Tables(0).Rows(0).Item("Loss3Type")
            txtLoss3Description.Text = ds.Tables(0).Rows(0).Item("Loss3Description")
            txtLoss3AmtPaid.Text = ds.Tables(0).Rows(0).Item("Loss3AmtPaid")
            ddLoss3Status.SelectedValue = ds.Tables(0).Rows(0).Item("Loss3Status")
            dd_ARIng1.SelectedValue = ds.Tables(0).Rows(0).Item("ARIng1")
            dd_ARIng2.SelectedValue = ds.Tables(0).Rows(0).Item("ARIng2")
            dd_ARIng3.SelectedValue = ds.Tables(0).Rows(0).Item("ARIng3")
            dd_ARIng4.SelectedValue = ds.Tables(0).Rows(0).Item("ARIng4")
            dd_ARIng5.SelectedValue = ds.Tables(0).Rows(0).Item("ARIng5")
            dd_ARIng6.SelectedValue = ds.Tables(0).Rows(0).Item("ARIng6")
            dd_ARIng7.SelectedValue = ds.Tables(0).Rows(0).Item("ARIng7")
            dd_ARIng8.SelectedValue = ds.Tables(0).Rows(0).Item("ARIng8")
            dd_ARIng9.SelectedValue = ds.Tables(0).Rows(0).Item("ARIng9")
            dd_ARIng10.SelectedValue = ds.Tables(0).Rows(0).Item("ARIng10")
            dd_ARIng11.SelectedValue = ds.Tables(0).Rows(0).Item("ARIng11")
            dd_ARIng12.SelectedValue = ds.Tables(0).Rows(0).Item("ARIng12")
            dd_ARIng13.SelectedValue = ds.Tables(0).Rows(0).Item("ARIng13")
            dd_ARIng14.SelectedValue = ds.Tables(0).Rows(0).Item("ARIng14")
            dd_ARIng15.SelectedValue = ds.Tables(0).Rows(0).Item("ARIng15")
            dd_ARIng16.SelectedValue = ds.Tables(0).Rows(0).Item("ARIng16")
            dd_ARIng17.SelectedValue = ds.Tables(0).Rows(0).Item("ARIng17")
            dd_ARIng18.SelectedValue = ds.Tables(0).Rows(0).Item("ARIng18")
            dd_ARIng19.SelectedValue = ds.Tables(0).Rows(0).Item("ARIng19")
            dd_ARIng20.SelectedValue = ds.Tables(0).Rows(0).Item("ARIng20")
            dd_ARIng21.SelectedValue = ds.Tables(0).Rows(0).Item("ARIng21")
            dd_ARIng22.SelectedValue = ds.Tables(0).Rows(0).Item("ARIng22")
            dd_ARIng23.SelectedValue = ds.Tables(0).Rows(0).Item("ARIng23")
            dd_ARIng24.SelectedValue = ds.Tables(0).Rows(0).Item("ARIng24")
            dd_ARIng25.SelectedValue = ds.Tables(0).Rows(0).Item("ARIng25")
            dd_ARIng26.SelectedValue = ds.Tables(0).Rows(0).Item("ARIng26")
            dd_ARIng27.SelectedValue = ds.Tables(0).Rows(0).Item("ARIng27")
            dd_ARIng28.SelectedValue = ds.Tables(0).Rows(0).Item("ARIng28")
            dd_ARIng29.SelectedValue = ds.Tables(0).Rows(0).Item("ARIng29")
            dd_ARIng30.SelectedValue = ds.Tables(0).Rows(0).Item("ARIng30")
            dd_ARIng31.SelectedValue = ds.Tables(0).Rows(0).Item("ARIng31")
            dd_ARIng32.SelectedValue = ds.Tables(0).Rows(0).Item("ARIng32")
            dd_ARIng33.SelectedValue = ds.Tables(0).Rows(0).Item("ARIng33")
            dd_ARIng34.SelectedValue = ds.Tables(0).Rows(0).Item("ARIng34")
            dd_ARIng35.SelectedValue = ds.Tables(0).Rows(0).Item("ARIng35")
            dd_ARIng36.SelectedValue = ds.Tables(0).Rows(0).Item("ARIng36")
            dd_ARIng37.SelectedValue = ds.Tables(0).Rows(0).Item("ARIng37")
            dd_ARIng38.SelectedValue = ds.Tables(0).Rows(0).Item("ARIng38")
            dd_ARIng39.SelectedValue = ds.Tables(0).Rows(0).Item("ARIng39")
            dd_ARIng40.SelectedValue = ds.Tables(0).Rows(0).Item("ARIng40")
            dd_ARIng41.SelectedValue = ds.Tables(0).Rows(0).Item("ARIng41")
            dd_ARIng42.SelectedValue = ds.Tables(0).Rows(0).Item("ARIng42")
            dd_ARIng43.SelectedValue = ds.Tables(0).Rows(0).Item("ARIng43")
            dddistOptionInsured.SelectedValue = ds.Tables(0).Rows(0).Item("distOptionInsured")
            dddistOptionAgent.SelectedValue = ds.Tables(0).Rows(0).Item("distOptionAgent")
            ddPaymentOpt.SelectedValue = ds.Tables(0).Rows(0).Item("PaymentOpt")

        End If
    End Sub
    Protected Sub LoadEligiblityEvents()
        dd_ARIng1.Attributes.Add("onChange", "return CheckEligiblity(this.id);")
        dd_ARIng2.Attributes.Add("onChange", "return CheckEligiblity(this.id);")
        dd_ARIng3.Attributes.Add("onChange", "return CheckEligiblity(this.id);")
        dd_ARIng4.Attributes.Add("onChange", "return CheckEligiblity(this.id);")
        dd_ARIng5.Attributes.Add("onChange", "return CheckEligiblity(this.id);")
        dd_ARIng6.Attributes.Add("onChange", "return CheckEligiblity(this.id);")
        dd_ARIng7.Attributes.Add("onChange", "return CheckEligiblity(this.id);")
        dd_ARIng8.Attributes.Add("onChange", "return CheckEligiblity(this.id);")
        dd_ARIng9.Attributes.Add("onChange", "return CheckEligiblity(this.id);")
        dd_ARIng10.Attributes.Add("onChange", "return CheckEligiblity(this.id);")
        dd_ARIng11.Attributes.Add("onChange", "return CheckEligiblity(this.id);")
        dd_ARIng12.Attributes.Add("onChange", "return CheckEligiblity(this.id);")
        dd_ARIng13.Attributes.Add("onChange", "return CheckEligiblity(this.id);")
        dd_ARIng14.Attributes.Add("onChange", "return CheckEligiblity(this.id);")
        dd_ARIng15.Attributes.Add("onChange", "return CheckEligiblity(this.id);")
        dd_ARIng16.Attributes.Add("onChange", "return CheckEligiblity(this.id);")
        dd_ARIng17.Attributes.Add("onChange", "return CheckEligiblity(this.id);")
        dd_ARIng18.Attributes.Add("onChange", "return CheckEligiblity(this.id);")
        dd_ARIng19.Attributes.Add("onChange", "return CheckEligiblity(this.id);")
        dd_ARIng20.Attributes.Add("onChange", "return CheckEligiblity(this.id);")
        dd_ARIng21.Attributes.Add("onChange", "return CheckEligiblity(this.id);")
        dd_ARIng22.Attributes.Add("onChange", "return CheckEligiblity(this.id);")
        dd_ARIng23.Attributes.Add("onChange", "return CheckEligiblity(this.id);")
        dd_ARIng24.Attributes.Add("onChange", "return CheckEligiblity(this.id);")
        dd_ARIng25.Attributes.Add("onChange", "return CheckEligiblity(this.id);")
        dd_ARIng26.Attributes.Add("onChange", "return CheckEligiblity(this.id);")
        dd_ARIng27.Attributes.Add("onChange", "return CheckEligiblity(this.id);")
        dd_ARIng28.Attributes.Add("onChange", "return CheckEligiblity(this.id);")
        dd_ARIng29.Attributes.Add("onChange", "return CheckEligiblity2(this.id);")
        dd_ARIng30.Attributes.Add("onChange", "return CheckEligiblity2(this.id);")
        dd_ARIng31.Attributes.Add("onChange", "return CheckEligiblity2(this.id);")
        dd_ARIng32.Attributes.Add("onChange", "return CheckEligiblity2(this.id);")
        dd_ARIng33.Attributes.Add("onChange", "return CheckEligiblity2(this.id);")
        dd_ARIng34.Attributes.Add("onChange", "return CheckEligiblity2(this.id);")
        dd_ARIng35.Attributes.Add("onChange", "return CheckEligiblity2(this.id);")
        dd_ARIng36.Attributes.Add("onChange", "return CheckEligiblity2(this.id);")
        dd_ARIng37.Attributes.Add("onChange", "return CheckEligiblity2(this.id);")
        dd_ARIng38.Attributes.Add("onChange", "return CheckEligiblity2(this.id);")
        dd_ARIng39.Attributes.Add("onChange", "return CheckEligiblity2(this.id);")
        dd_ARIng40.Attributes.Add("onChange", "return CheckEligiblity2(this.id);")
        dd_ARIng41.Attributes.Add("onChange", "return CheckEligiblity2(this.id);")
        dd_ARIng42.Attributes.Add("onChange", "return CheckEligiblity2(this.id);")
        dd_ARIng43.Attributes.Add("onChange", "return CheckEligiblity2(this.id);")



    End Sub
    Protected Sub printApp(ByVal sender As Object, ByVal e As EventArgs) Handles printBtn.Click
        If Request.QueryString("ApplicationID") <> "" Or Session("beenSaved") = "True" Then
            save()
        Else 'New Quote
            save()
        End If

        Common.AjaxOpenWindow(Me.Page, "ApplicationPrint.aspx?AppID=" & txtAppNumber.Text, Nothing)
    End Sub
    Public Sub premFinbtn_Click(ByVal sender As Object, ByVal e As EventArgs) Handles premFinbtn.Click
        If Request.QueryString("quoteID") <> "" Then
            save()
            Dim fin As New Finance
            If fin.CalcFinancing(Request.QueryString("quoteID")) Then
                lblFinance.Text = "Finance Contract Present"
                ddPaymentOpt.SelectedValue = "Premium Finance"

                Dim lbl As New Label()
                lbl.Text = "<script language='javascript'>  HideFinanceOptions();" & "<" & "/script>"
                Page.Controls.Add(lbl)

            Else
                Dim err As String
                err = "Error from financing service: " & fin.getErrorMessage
                Dim lbl As New Label()
                lbl.Text = "<script language='javascript'>  alert('" & err & "'); HideFinanceOptions();" & "<" & "/script>"
                Page.Controls.Add(lbl)
                lblFinance.Text = err
            End If
        End If
        
    End Sub
    'Protected Sub printFinance_Click(ByVal sender As Object, ByVal e As EventArgs)
    '    Try
    '        If Request.QueryString("quoteID") <> "" Then
    '            Common.AjaxOpenWindow(Me.Page, "/ApplicationPages/Finance/FinanceContract_" & Request.QueryString("quoteID") & ".pdf", Nothing)
    '        Else

    '        End If
    '    Catch ex As Exception

    '    End Try
    'End Sub
    Public Sub checkFinancing(ByVal quoteID As String)
        Try
            Dim ds As System.Data.DataSet
            ds = com.runQueryDS("SELECT * FROM tblFinancing WHERE quoteID = '" & quoteID & "'", "ColonialMHConnectionString")
            If ds.Tables(0).Rows.Count > 0 Then
                lblFinance.Text = "Finance Contract Present"

            Else
                lblFinance.Text = "No Finance Contract Present"

            End If
            Dim lbl As New Label()
            lbl.Text = "<script language='javascript'>  HideFinanceOptions();" & "<" & "/script>"
            Page.Controls.Add(lbl)
        Catch ex As Exception

        End Try

    End Sub
    Public Sub printbtnImport_Click(ByVal sender As Object, ByVal e As EventArgs) Handles printbtn1_Import.Click
        If Request.QueryString("quoteID") <> "" Or Session("beenSaved") = "True" Then
            save()
        Else 'New Quote
            save()
        End If
        Common.AjaxOpenWindow(Me.Page, "/Quote/quotePrintImport.aspx?quoteID=" & txtQuoteID.Text & "", Nothing)
    End Sub
    Public Sub savebtn_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles savebtn.Click
        If Request.QueryString("ApplicationID") <> "" Or Session("beenSaved") = "True" Then
            save()
        Else 'New Application
            save()
        End If

    End Sub
    Protected Sub save()
        Dim quoteID As String
        If Request.QueryString("quoteID") <> "" Then
            quoteID = Request.QueryString("quoteID")
        Else 'New Quote
            quoteID = Request.QueryString("quoteID")
        End If
        Dim ds As System.Data.DataSet

        Dim tsql As String
        tsql = "EXEC spUpdateARApplicationData  '" & txtAppNumber.Text & "', "
        'tsql += " '" & txtQuoteID.Text & "',"
        tsql += " '" & quoteID & "',"
        tsql += " '" & AppStatuslbl.Text & "',"
        tsql += " '" & txtName.Text & "',"
        tsql += " '" & txtDOB.Text & "',"
        tsql += " '" & txtDiffAppAddr.Text & "',"
        tsql += " '" & txtDiffAppCity.Text & "',"
        tsql += " '" & txtDiffAppState.Text & "',"
        tsql += " '" & txtDiffAppZip.Text & "',"
        tsql += " '" & txtDiffAppCounty.Text & "',"
        'tsql += " '" & txtAddress.Text & "',"
        'tsql += " '" & txtCity.Text & "',"
        'tsql += " '" & txtState.Text & "',"
        'tsql += " '" & txtZip.Text & "',"
        'tsql += " '" & txtCounty.Text & "',"
        tsql += " '" & txtPhone2.Text & "',"
        tsql += " '" & txtOcc.Text & "',"
        tsql += " '" & txtSSN2.Text & "',"
        tsql += " '" & txtSpouseName.Text & "',"
        tsql += " '" & txtSpouseSSN.Text & "',"
        tsql += " '" & txtSpouseDOB.Text & "',"
        tsql += " '" & addlInsuredcheck.SelectedValue & "',"
        tsql += " '" & txtAgentName.Text & "',"
        tsql += " '" & txtAddress.Text & "',"
        tsql += " '" & txtCity.Text & "',"
        tsql += " '" & txtState.Text & "',"
        tsql += " '" & txtZip.Text & "',"
        tsql += " '" & txtCounty.Text & "',"
        'tsql += " '" & txtDiffAppAddr.Text & "',"
        'tsql += " '" & txtDiffAppCity.Text & "',"
        'tsql += " '" & txtDiffAppState.Text & "',"
        'tsql += " '" & txtDiffAppZip.Text & "',"
        'tsql += " '" & txtDiffAppCounty.Text & "',"
        tsql += " '" & txtMunTaxCode.Text & "',"
        tsql += " '" & txtDistToFire.Text & "',"
        tsql += " '" & txtDistToFireDept.Text & "',"
        tsql += " '" & txtFireDeptName.Text & "',"
        tsql += " '" & dd_ctylimits.SelectedValue & "',"
        tsql += " '" & dd_fwua.SelectedValue & "',"
        tsql += " '" & txtDistToGulf.Text & "',"
        tsql += " '" & txtDescMHYear.Text & "',"
        tsql += " '" & txtDescMHManf.Text & "',"
        tsql += " '" & txtDescMHLength.Text & "',"
        tsql += " '" & txtDescMHWidth.Text & "',"
        tsql += " '" & txtDescMHSerial.Text & "',"
        tsql += " '" & txtDescMHPurDate2.Text & "',"
        tsql += " '" & txtDescMHPurPrice2.Text & "',"
        tsql += " '" & txtDescMHCurDate2.Text & "',"
        tsql += " '" & txtDescMHAttStruc.Text & "',"
        tsql += " '" & txtDescMHAttStrucAge.Text & "',"
        tsql += " '" & txtDescMHAttStrucSize.Text & "',"
        tsql += " '" & txtDescMHAttStrucCurVal2.Text & "',"
        tsql += " '" & txtDescMHUnAttStruc.Text & "',"
        tsql += " '" & txtDescMHUnAttStrucAge.Text & "',"
        tsql += " '" & txtDescMHUnAttStrucSize.Text & "',"
        tsql += " '" & txtDescMHUnAttStrucCurVal2.Text & "',"
        tsql += " '" & ddProgram.SelectedValue & "',"
        tsql += " '" & ddUsage.SelectedValue & "',"
        tsql += " '" & ddProt.SelectedValue & "',"
        tsql += " '" & txtInsAge.Text & "',"
        tsql += " '" & ddMHAge.SelectedValue & "',"
        tsql += " '" & ddlossHist.SelectedValue & "',"
        tsql += " '" & ddParkStatus.SelectedValue & "',"
        tsql += " '" & txtAcres.Text & "',"
        tsql += " '" & txtNumOfSpaces.Text & "',"
        tsql += " '" & txtPerOfAdults.Text & "',"
        tsql += " '" & ddResManger.SelectedValue & "',"
        tsql += " '" & ddUnitType.SelectedValue & "',"
        tsql += " '" & txtNumOfFrontSteps.Text & "',"
        tsql += " '" & txtNumOfRearSteps.Text & "',"
        ' tsql += " '" & ddSupHeating.SelectedValue & "',"
        tsql += " '" & ddSupHeating.SelectedItem.Text & "',"
        tsql += " '" & txtSupHeatOther.Text & "',"
        tsql += " '" & ddSupHeatingFacInst.SelectedValue & "',"
        tsql += " '" & ddSatDish.SelectedValue & "',"
        tsql += " '" & ddAnimal.SelectedValue & "',"
        tsql += " '" & txtAnimalType.Text & "',"
        tsql += " '" & txtDogBreed.Text & "',"
        tsql += " '" & txtLien1Name.Text & "',"
        tsql += " '" & txtLien1Num.Text & "',"
        tsql += " '" & txtLien1Addr.Text & "',"
        tsql += " '" & txtLien1City.Text & "',"
        tsql += " '" & txtLien1State.Text & "',"
        tsql += " '" & txtLien1Zip.Text & "',"
        tsql += " '" & txtLien2Name.Text & "',"
        tsql += " '" & txtLien2Num.Text & "',"
        tsql += " '" & txtLien2Addr.Text & "',"
        tsql += " '" & txtLien2City.Text & "',"
        tsql += " '" & txtLien2State.Text & "',"
        tsql += " '" & txtLien2Zip.Text & "',"
        tsql += " '" & ddPriorInsurance.SelectedValue & "',"
        tsql += " '" & txtPriorCompany.Text & "',"
        tsql += " '" & txtLoss1Date.Text & "',"
        tsql += " '" & ddLoss1Type.SelectedValue & "',"
        tsql += " '" & txtLoss1Description.Text & "',"
        tsql += " '" & txtLoss1AmtPaid.Text & "',"
        tsql += " '" & ddLoss1Status.SelectedValue & "',"
        tsql += " '" & txtLoss2Date.Text & "',"
        tsql += " '" & ddLoss2Type.SelectedValue & "',"
        tsql += " '" & txtLoss2Description.Text & "',"
        tsql += " '" & txtLoss2AmtPaid.Text & "',"
        tsql += " '" & ddLoss2Status.SelectedValue & "',"
        tsql += " '" & txtLoss3Date.Text & "',"
        tsql += " '" & ddLoss3Type.SelectedValue & "',"
        tsql += " '" & txtLoss3Description.Text & "',"
        tsql += " '" & txtLoss3AmtPaid.Text & "',"
        tsql += " '" & ddLoss3Status.SelectedValue & "',"
        tsql += " '" & dd_ARIng1.SelectedValue & "',"
        tsql += " '" & dd_ARIng2.SelectedValue & "',"
        tsql += " '" & dd_ARIng3.SelectedValue & "',"
        tsql += " '" & dd_ARIng4.SelectedValue & "',"
        tsql += " '" & dd_ARIng5.SelectedValue & "',"
        tsql += " '" & dd_ARIng6.SelectedValue & "',"
        tsql += " '" & dd_ARIng7.SelectedValue & "',"
        tsql += " '" & dd_ARIng8.SelectedValue & "',"
        tsql += " '" & dd_ARIng9.SelectedValue & "',"
        tsql += " '" & dd_ARIng10.SelectedValue & "',"
        tsql += " '" & dd_ARIng11.SelectedValue & "',"
        tsql += " '" & dd_ARIng12.SelectedValue & "',"
        tsql += " '" & dd_ARIng13.SelectedValue & "',"
        tsql += " '" & dd_ARIng14.SelectedValue & "',"
        tsql += " '" & dd_ARIng15.SelectedValue & "',"
        tsql += " '" & dd_ARIng16.SelectedValue & "',"
        tsql += " '" & dd_ARIng17.SelectedValue & "',"
        tsql += " '" & dd_ARIng18.SelectedValue & "',"
        tsql += " '" & dd_ARIng19.SelectedValue & "',"
        tsql += " '" & dd_ARIng20.SelectedValue & "',"
        tsql += " '" & dd_ARIng21.SelectedValue & "',"
        tsql += " '" & dd_ARIng22.SelectedValue & "',"
        tsql += " '" & dd_ARIng23.SelectedValue & "',"
        tsql += " '" & dd_ARIng24.SelectedValue & "',"
        tsql += " '" & dd_ARIng25.SelectedValue & "',"
        tsql += " '" & dd_ARIng26.SelectedValue & "',"
        tsql += " '" & dd_ARIng27.SelectedValue & "',"
        tsql += " '" & dd_ARIng28.SelectedValue & "',"
        tsql += " '" & dd_ARIng29.SelectedValue & "',"
        tsql += " '" & dd_ARIng30.SelectedValue & "',"
        tsql += " '" & dd_ARIng31.SelectedValue & "',"
        tsql += " '" & dd_ARIng32.SelectedValue & "',"
        tsql += " '" & dd_ARIng33.SelectedValue & "',"
        tsql += " '" & dd_ARIng34.SelectedValue & "',"
        tsql += " '" & dd_ARIng35.SelectedValue & "',"
        tsql += " '" & dd_ARIng36.SelectedValue & "',"
        tsql += " '" & dd_ARIng37.SelectedValue & "',"
        tsql += " '" & dd_ARIng38.SelectedValue & "',"
        tsql += " '" & dd_ARIng39.SelectedValue & "',"
        tsql += " '" & dd_ARIng40.SelectedValue & "',"
        tsql += " '" & dd_ARIng41.SelectedValue & "',"
        tsql += " '" & dd_ARIng42.SelectedValue & "',"
        tsql += " '" & dd_ARIng43.SelectedValue & "',"
        tsql += " '" & dddistOptionInsured.SelectedValue & "',"
        tsql += " '" & dddistOptionAgent.SelectedValue & "',"
        tsql += " '" & ddPaymentOpt.SelectedValue & "',"
        tsql += " '" & txtParkName.Text & "',"
        tsql += " '" & txtprioryears.Text & "',"
        tsql += " '" & txtAddInsured.Text & "',"
        tsql += " '" & txtAddAddress.Text & "',"
        tsql += " '" & txtaddcity.Text & "',"
        tsql += " '" & txtaddstate.Text & "',"
        tsql += " '" & txtaddzip.Text & "',"
        tsql += " '" & txtaddcounty.Text & "',"
        tsql += " '" & txtLien1Addr2.Text & "',"
        tsql += " '" & txtLien2Addr2.Text & "'"
        Try
            ds = com.runQueryDS(tsql, "ColonialMHConnectionString")
            updateStatus("Application Saved")
            If txtAppNumber.Text = "NULL" Or txtAppNumber.Text = "" Then
                ds = com.runQueryDS("SELECT TOP 1 ApplicationID FROM tblARApplication ORDER BY ApplicationID DESC", "ColonialMHConnectionString")
                If ds.Tables(0).Rows.Count > 0 Then
                    txtAppNumber.Text = ds.Tables(0).Rows(0).Item("ApplicationID").ToString()
                    labelapp.Text = ds.Tables(0).Rows(0).Item("ApplicationID").ToString()
                End If
            End If
        Catch ex As Exception
            updateStatus("Save Failed")
            errortrap(tsql, "save", ex.Message)
        End Try

    End Sub
    Protected Sub update()

    End Sub
    Private Sub MessageBox(ByVal str As String)
        Dim lbl As New Label()
        lbl.Text = "<script language='javascript'> window.alert('" & str & "');" & "<" & "/script>"
        Page.Controls.Add(lbl)

    End Sub
    Private Sub updateStatus(ByVal str As String)
        Dim lbl As New Label()
        lbl.Text = "<script language='javascript'> window.status ='" & str & "';" & "<" & "/script>"
        Page.Controls.Add(lbl)

    End Sub

    Sub DupLocation_CheckedChanged(sender As Object, e As EventArgs) Handles DupLocation.CheckedChanged
        If txtDiffAppAddr.Text = "" Or txtDiffAppCity.Text = "" Or txtDiffAppState.Text = "" Or txtDiffAppZip.Text = "" Or txtDiffAppCounty.Text = "" Then
            'alert("Please fill in the Location address information before checking this box.")
            ClientScript.RegisterClientScriptBlock(Me.[GetType](), "s", "window.alert('Please fill in the Location address information before checking this box.');", True)
        Else
            txtAddress.Text = txtDiffAppAddr.Text
            txtCity.Text = txtDiffAppCity.Text
            txtState.Text = txtDiffAppState.Text
            txtZip.Text = txtDiffAppZip.Text
            txtCounty.Text = txtDiffAppCounty.Text
        End If


    End Sub
    Public Sub backtoquote(sender As Object, e As EventArgs)

        quoteID = Request.QueryString("quoteID")
        Response.Redirect("/Quote/quote.aspx?quoteID=" & quoteID & "")


    End Sub


    Private Sub zipbtn1_Click(sender As Object, e As System.EventArgs) Handles zipbtn1.Click
        LoadZip(txtDiffAppZip.Text)
        txtDiffAppZip.Focus()
        Dim lbl As New Label()
        lbl.Text = "<script language='javascript'> document.getElementById('addlins1').style.display = ''; document.getElementById('addlins2').style.display = '';" & "<" & "/script>"
        Page.Controls.Add(lbl)
    End Sub
    Public Sub LoadZip(ByVal currentZip As String)


        Dim dbConn As String = ConfigurationManager.ConnectionStrings("CommonDbConnectionString").ConnectionString
        Dim conn As New SqlConnection(dbConn)
        Dim cmd As New SqlCommand("SELECT szCity AS City, szCounty AS County, szState_cd AS State FROM [wrwpaqbx_admin].[tblZip] WHERE szZip = '" & txtDiffAppZip.Text & "' ", conn)

        Try
            If conn.State = Data.ConnectionState.Closed Then conn.Open()
            Dim rs As SqlDataReader = cmd.ExecuteReader()
            Do While rs.Read
                txtDiffAppCity.Text = rs("City").ToString()
                txtDiffAppState.Text = rs("State").ToString()
                txtDiffAppCounty.Text = rs("County").ToString()

            Loop

            rs.Close()


        Catch ex As Exception
            errortrap("Getting Zip", "LoadZip", ex.Message)
            'Error
        Finally
            conn.Close()
        End Try



    End Sub

    Private Sub zipbtn2_Click(sender As Object, e As System.EventArgs) Handles zipbtn2.Click
        LoadZip2(txtZip.Text)
        txtZip.Focus()
        Dim lbl As New Label()
        lbl.Text = "<script language='javascript'> document.getElementById('addlins1').style.display = ''; document.getElementById('addlins2').style.display = '';" & "<" & "/script>"
        Page.Controls.Add(lbl)
    End Sub
    Public Sub LoadZip2(ByVal currentZip As String)


        Dim dbConn As String = ConfigurationManager.ConnectionStrings("CommonDbConnectionString").ConnectionString
        Dim conn As New SqlConnection(dbConn)
        Dim cmd As New SqlCommand("SELECT szCity AS City, szCounty AS County, szState_cd AS State FROM [wrwpaqbx_admin].[tblZip] WHERE szZip = '" & txtZip.Text & "' ", conn)

        Try
            If conn.State = Data.ConnectionState.Closed Then conn.Open()
            Dim rs As SqlDataReader = cmd.ExecuteReader()
            Do While rs.Read
                txtCity.Text = rs("City").ToString()
                txtState.Text = rs("State").ToString()
                txtCounty.Text = rs("County").ToString()

            Loop

            rs.Close()


        Catch ex As Exception
            'Error
            errortrap("Getting Zip", "LoadZip2", ex.Message)
        Finally
            conn.Close()
        End Try



    End Sub

    Private Sub zipbtn3_Click(sender As Object, e As System.EventArgs) Handles zipbtn3.Click
        LoadZip3(txtaddzip.Text)
        txtaddzip.Focus()
        Dim lbl As New Label()
        lbl.Text = "<script language='javascript'> document.getElementById('addlins1').style.display = ''; document.getElementById('addlins2').style.display = '';" & "<" & "/script>"
        Page.Controls.Add(lbl)

    End Sub
    Public Sub LoadZip3(ByVal currentZip As String)


        Dim dbConn As String = ConfigurationManager.ConnectionStrings("CommonDbConnectionString").ConnectionString
        Dim conn As New SqlConnection(dbConn)
        Dim cmd As New SqlCommand("SELECT szCity AS City, szCounty AS County, szState_cd AS State FROM [wrwpaqbx_admin].[tblZip] WHERE szZip = '" & txtaddzip.Text & "' ", conn)

        Try
            If conn.State = Data.ConnectionState.Closed Then conn.Open()
            Dim rs As SqlDataReader = cmd.ExecuteReader()
            Do While rs.Read
                txtaddcity.Text = rs("City").ToString()
                txtaddstate.Text = rs("State").ToString()
                txtaddcounty.Text = rs("County").ToString()

            Loop

            rs.Close()



        Catch ex As Exception
            'Error
            errortrap("Getting Zip", "LoadZip3", ex.Message)
        Finally
            conn.Close()
        End Try



    End Sub

    Private Sub lienzip1_Click(sender As Object, e As System.EventArgs) Handles lienzip1.Click
        LoadZip4(txtLien1Zip.Text)

        Dim lbl As New Label()
        lbl.Text = "<script language='javascript'> document.getElementById('addlins1').style.display = ''; document.getElementById('addlins2').style.display = '';" & "<" & "/script>"
        Page.Controls.Add(lbl)
        txtLien1Zip.Focus()
    End Sub
    Public Sub LoadZip4(ByVal currentZip As String)


        Dim dbConn As String = ConfigurationManager.ConnectionStrings("CommonDbConnectionString").ConnectionString
        Dim conn As New SqlConnection(dbConn)
        Dim cmd As New SqlCommand("SELECT szCity AS City, szCounty AS County, szState_cd AS State FROM [wrwpaqbx_admin].[tblZip] WHERE szZip = '" & txtLien1Zip.Text & "' ", conn)

        Try
            If conn.State = Data.ConnectionState.Closed Then conn.Open()
            Dim rs As SqlDataReader = cmd.ExecuteReader()
            Do While rs.Read
                txtLien1City.Text = rs("City").ToString()
                txtLien1State.Text = rs("State").ToString()
                ' txtLien1county.Text = rs("County").ToString()

            Loop

            rs.Close()



        Catch ex As Exception
            'Error
            errortrap("Getting Zip", "LoadZip4", ex.Message)
        Finally
            conn.Close()
        End Try



    End Sub

    Private Sub lienzip2_Click(sender As Object, e As System.EventArgs) Handles lienzip2.Click
        LoadZip5(txtLien2Zip.Text)

        Dim lbl As New Label()
        lbl.Text = "<script language='javascript'> document.getElementById('addlins1').style.display = ''; document.getElementById('addlins2').style.display = '';" & "<" & "/script>"
        Page.Controls.Add(lbl)
        txtLien2Zip.Focus()
    End Sub
    Public Sub LoadZip5(ByVal currentZip As String)


        Dim dbConn As String = ConfigurationManager.ConnectionStrings("CommonDbConnectionString").ConnectionString
        Dim conn As New SqlConnection(dbConn)
        Dim cmd As New SqlCommand("SELECT szCity AS City, szCounty AS County, szState_cd AS State FROM [wrwpaqbx_admin].[tblZip] WHERE szZip = '" & txtLien2Zip.Text & "' ", conn)

        Try
            If conn.State = Data.ConnectionState.Closed Then conn.Open()
            Dim rs As SqlDataReader = cmd.ExecuteReader()
            Do While rs.Read
                txtLien2City.Text = rs("City").ToString()
                txtLien2State.Text = rs("State").ToString()
                ' txtLien1county.Text = rs("County").ToString()

            Loop

            rs.Close()



        Catch ex As Exception
            'Error
            errortrap("Getting Zip", "LoadZip5", ex.Message)
        Finally
            conn.Close()
        End Try



    End Sub
    Private Sub errortrap(ByVal sqlcomm As String, ByVal appsub As String, ByVal errormsg As String)
        Dim intRowsAff As Integer
        Dim Connection As String = System.Configuration.ConfigurationManager.ConnectionStrings("ColonialMHConnectionString").ConnectionString
        Dim dbConnection As System.Data.IDbConnection = New System.Data.SqlClient.SqlConnection(Connection)
        Dim cmd As New SqlCommand("sp_InsertError", dbConnection)
        cmd.CommandType = CommandType.StoredProcedure
        cmd.Parameters.Add("@code", SqlDbType.VarChar, 8000).Value = sqlcomm
        cmd.Parameters.Add("@Page", SqlDbType.VarChar, 50).Value = "ARApplication"
        cmd.Parameters.Add("@sub", SqlDbType.VarChar, 50).Value = appsub
        cmd.Parameters.Add("@msg", SqlDbType.VarChar, 8000).Value = errormsg
        Try
            cmd.Connection.Open()
            intRowsAff = cmd.ExecuteNonQuery()
        Catch ex As Exception

        End Try
        'Dim queryString = Str()
        'Dim dbCommand As System.Data.IDbCommand = New System.Data.SqlClient.SqlCommand
        'dbCommand.CommandText = queryString
        'dbCommand.Connection = dbConnection
        'Dim dataAdapter As System.Data.IDbDataAdapter = New System.Data.SqlClient.SqlDataAdapter
        'dataAdapter.SelectCommand = dbCommand
        'Dim dataSet As System.Data.DataSet = New System.Data.DataSet
        'dataAdapter.Fill(dataSet)
        'Return dataSet

    End Sub


End Class