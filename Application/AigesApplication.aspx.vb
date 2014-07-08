﻿Imports System.Data.SqlClient
Imports DevExpress.Web.ASPxEditors
Public Class AigesApplication
    Inherits System.Web.UI.Page
    Dim com As New Common
    Dim quoteID As String

    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        ApplyValidationSummarySettings()
        If Not IsPostBack Then
            ASPxEdit.ValidateEditorsInContainer(Me)
            overridebtn.Visible = False
            ' Dim test As String = mySession.CurrentUser.UWUser.ToString
            If mySession.CurrentUser.UWUser.ToString = "False" Then
                findimport.Visible = False
                'adminpage.Visible = False
                'adminpage.Width = "0"
                findimport.Width = "0"
            Else
                findimport.Visible = True
                findimport.Attributes.Add("onClick", "redirect3(); return false;")
                'adminpage.Visible = True

            End If
            txtZip.Attributes.Add("onKeyUp", "return zipcodeKeyDown1();")
            txtDiffAppZip.Attributes.Add("onKeyUp", "return zipcodeKeyDown();")
            'txtaddzip.Attributes.Add("onKeyUp", "return zipcodeKeyDown2();")
            txtLien1Zip.Attributes.Add("onKeyUp", "return zipcodeKeyDown3();")
            txtLien2Zip.Attributes.Add("onKeyUp", "return zipcodeKeyDown4();")
            txttitleZip.Attributes.Add("onKeyUp", "return zipcodeKeyDown6();")
            If Request.QueryString("quoteID") <> "" Then '  quoteID is not empty

                quoteID = Request.QueryString("quoteID")
                'for testing
                'quoteID = "64"
                '------------------
                txtQuoteID.Text = Request.QueryString("quoteID")
                loadData(quoteID)
            End If


            Dim val As String = AppStatuslbl.Text
            If val = "ELIGIBLE" Then
                AppStatuslbl.ForeColor = Drawing.Color.Green
                overridebtn.Visible = False
            End If
            If val = "INELIGIBLE" Then
                AppStatuslbl.ForeColor = Drawing.Color.Red
                overridebtn.Visible = False
            End If
            If val = "Submit to UW – Contact The Colonial Group at 1-800-628-3762." Then
                AppStatuslbl.ForeColor = Drawing.Color.Blue
                If mySession.CurrentUser.UWUser.ToString() = "True" Then
                    overridebtn.Visible = True
                Else
                    overridebtn.Visible = False
                End If
            End If




        End If
    End Sub
    Protected Sub loadData(ByVal quoteID As String)
        ddPriorInsurance.SelectedItem = ddPriorInsurance.Items.FindByText("None")
        Dim ds As System.Data.DataSet
        ds = com.runQueryDS("EXEC sp_AegisQuoteAppData '" & quoteID & "'", "ColonialMHConnectionString")
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
            '   lblPackage.Text = "Lloyds  " & ds.Tables(0).Rows(0).Item("ARRateType").ToString()
            lblCarrier.Text = "Aegis"
            lblProgram.Text = ds.Tables(0).Rows(0).Item("ARRateType").ToString()
           
            lblTerm.Text = ds.Tables(0).Rows(0).Item("term").ToString()
            lblEffDates.Text = ds.Tables(0).Rows(0).Item("effdaterange").ToString()
            'txtSpouseName.Text = ds.Tables(0).Rows(0).Item("SpouseName").ToString()
            'txtSpouseSSN.Text = ds.Tables(0).Rows(0).Item("SpouseSSN").ToString()
            'txtSpouseDOB.Text = ds.Tables(0).Rows(0).Item("SpouseDOB").ToString()
            'additional insured
            ' addlInsuredcheck.SelectedValue = ds.Tables(0).Rows(0).Item("AddInsured").ToString()
            'txtAddInsured.Text = ds.Tables(0).Rows(0).Item("AddInsuredName").ToString()
            'txtAddAddress.Text = ds.Tables(0).Rows(0).Item("AddInsuredAddress").ToString()
            'txtaddcity.Text = ds.Tables(0).Rows(0).Item("AddInsuredCity").ToString()
            'txtaddstate.Text = ds.Tables(0).Rows(0).Item("AddInsuredState").ToString()
            'txtaddzip.Text = ds.Tables(0).Rows(0).Item("AddInsuredZip").ToString()
            'txtaddcounty.Text = ds.Tables(0).Rows(0).Item("AddInsuredCounty").ToString()

            'txtAddInsured.Text = ds.Tables(0).Rows(0).Item("AddInsured").ToString()

            txtAgentName.Text = ds.Tables(0).Rows(0).Item("qagentName").ToString()
            txtQuoteID.Text = ds.Tables(0).Rows(0).Item("qquoteID").ToString()

            lblQuoteNumber.Text = ds.Tables(0).Rows(0).Item("qquoteID").ToString()
            OVreasontxt.Text = ds.Tables(0).Rows(0).Item("override").ToString()
            txtAddress.Text = ds.Tables(0).Rows(0).Item("mailAddress").ToString()
            txtCity.Text = ds.Tables(0).Rows(0).Item("mailCity").ToString()
            txtState.Text = ds.Tables(0).Rows(0).Item("mailState").ToString()
            txtZip.Text = ds.Tables(0).Rows(0).Item("mailzip").ToString()
            txtCounty.Text = ds.Tables(0).Rows(0).Item("mailCounty").ToString()
            'txtMunTaxCode.Text = ds.Tables(0).Rows(0).Item("MunTaxCode").ToString()
            'txtDistToFire.Text = ds.Tables(0).Rows(0).Item("DistToFire").ToString()
            'txtDistToFireDept.Text = ds.Tables(0).Rows(0).Item("DistToFireDept").ToString()
            'txtFireDeptName.Text = ds.Tables(0).Rows(0).Item("FireDeptName").ToString()
            txtDistToGulf.Text = ds.Tables(0).Rows(0).Item("distToCoast").ToString()
            txtDescMHYear.Text = ds.Tables(0).Rows(0).Item("MHYear").ToString()
            txtDescMHManf.Text = ds.Tables(0).Rows(0).Item("MHmanf").ToString()
            txtDescMHLength.Text = ds.Tables(0).Rows(0).Item("MHLength").ToString()
            txtDescMHWidth.Text = ds.Tables(0).Rows(0).Item("MHWidth").ToString()
            txtDescMHCurDate2.Text = Date.Now.ToString("MM/dd/yyyy") 'ds.Tables(0).Rows(0).Item("DescMHCurDate").ToString()
            ddUsage.SelectedItem = ddUsage.Items.FindByText(ds.Tables(0).Rows(0).Item("usage").ToString())
            If ds.Tables(0).Rows(0).Item("Homeage").ToString() >= 0 And ds.Tables(0).Rows(0).Item("Homeage").ToString() < 6 Then
                ddMHAge.SelectedItem = ddMHAge.Items.FindByText("1-5 Yrs")
            ElseIf ds.Tables(0).Rows(0).Item("Homeage").ToString() > 5 And ds.Tables(0).Rows(0).Item("Homeage").ToString() < 16 Then
                ddMHAge.SelectedItem = ddMHAge.Items.FindByText("6-15 Yrs")
            ElseIf ds.Tables(0).Rows(0).Item("Homeage").ToString() > 15 Then
                ddMHAge.SelectedItem = ddMHAge.Items.FindByText("16 Yrs & Older")
            End If
            ddParkStatus.SelectedItem = ddParkStatus.Items.FindByText(ds.Tables(0).Rows(0).Item("isMHInPark").ToString())
            ddUnitType.SelectedItem = ddUnitType.Items.FindByText(ds.Tables(0).Rows(0).Item("homeType").ToString())
            ddlossHist.SelectedItem = ddlossHist.Items.FindByText(ds.Tables(0).Rows(0).Item("priorLoss").ToString())
            'dd_ARIng1.SelectedValue = ds.Tables(0).Rows(0).Item("suppHeating").ToString()
            'dd_ARIng1.SelectedItem = dd_ARIng1.Items.FindByText(ds.Tables(0).Rows(0).Item("suppHeating").ToString())
            'dd_ARIng12.SelectedItem = dd_ARIng12.Items.FindByText(ds.Tables(0).Rows(0).Item("priorLoss").ToString()) 'ds.Tables(0).Rows(0).Item("priorLoss").ToString()
            'dd_ARIng8.SelectedItem = dd_ARIng8.Items.FindByText(ds.Tables(0).Rows(0).Item("suppHeating").ToString()) 'ds.Tables(0).Rows(0).Item("suppHeating").ToString()


            If ds.Tables(0).Rows(0).Item("ApplicationID").ToString() > "" Then


                txtName.Text = ds.Tables(0).Rows(0).Item("Name").ToString()
                txtDOB.Text = ds.Tables(0).Rows(0).Item("DOB").ToString()
                'txtDiffAppAddr.Text = ds.Tables(0).Rows(0).Item("Address").ToString()
                'txtDiffAppCity.Text = ds.Tables(0).Rows(0).Item("City").ToString()
                'txtDiffAppState.Text = ds.Tables(0).Rows(0).Item("State").ToString()
                'txtDiffAppZip.Text = ds.Tables(0).Rows(0).Item("Zip").ToString()
                'txtDiffAppCounty.Text = ds.Tables(0).Rows(0).Item("County").ToString()
                txtPhone2.Text = ds.Tables(0).Rows(0).Item("Phone").ToString()
                txtOcc.Text = ds.Tables(0).Rows(0).Item("Occ").ToString()
                txtSSN2.Text = ds.Tables(0).Rows(0).Item("SSN").ToString()
                txtSpouseName.Text = ds.Tables(0).Rows(0).Item("COName").ToString()
                txtSpouseDOB.Text = ds.Tables(0).Rows(0).Item("CODOB").ToString()
                CoPhone.Text = ds.Tables(0).Rows(0).Item("COPhone").ToString()
                txtSpouseSSN.Text = ds.Tables(0).Rows(0).Item("COSSN").ToString()
                txtemployer.Text = ds.Tables(0).Rows(0).Item("Employer").ToString()
                txtemployedyears.Text = ds.Tables(0).Rows(0).Item("Employeryrs").ToString()
                txttitlename.Text = ds.Tables(0).Rows(0).Item("AddInsuredName").ToString()
                txttitleaddress.Text = ds.Tables(0).Rows(0).Item("AddInsuredAddress").ToString()
                txttitlecity.Text = ds.Tables(0).Rows(0).Item("AddInsuredCity").ToString()
                txttitlestate.Text = ds.Tables(0).Rows(0).Item("AddInsuredState").ToString()
                txttitleZip.Text = ds.Tables(0).Rows(0).Item("AddInsuredZip").ToString()
                txtAgentName.Text = ds.Tables(0).Rows(0).Item("AgentName").ToString()
                txtAddress.Text = ds.Tables(0).Rows(0).Item("DiffAppAddr").ToString()
                txtCity.Text = ds.Tables(0).Rows(0).Item("DiffAppCity").ToString()
                txtState.Text = ds.Tables(0).Rows(0).Item("DiffAppState").ToString()
                txtZip.Text = ds.Tables(0).Rows(0).Item("DiffAppZip").ToString()
                txtCounty.Text = ds.Tables(0).Rows(0).Item("DiffAppCounty").ToString()
                txtDistToFire.Text = ds.Tables(0).Rows(0).Item("DistToFire").ToString()
                txtDistToFireDept.Text = ds.Tables(0).Rows(0).Item("DistToFireDept").ToString()
                txtDistToGulf.Text = ds.Tables(0).Rows(0).Item("DistToGulf").ToString()
                txtDescMHYear.Text = ds.Tables(0).Rows(0).Item("DescMHYear").ToString()
                txtDescMHManf.Text = ds.Tables(0).Rows(0).Item("DescMHManf").ToString()
                txtDescMHLength.Text = ds.Tables(0).Rows(0).Item("DescMHLength").ToString()
                txtDescMHWidth.Text = ds.Tables(0).Rows(0).Item("DescMHWidth").ToString()
                txtDescMHSerial.Text = ds.Tables(0).Rows(0).Item("DescMHSerial").ToString()
                txtDescMHPurDate2.Text = ds.Tables(0).Rows(0).Item("DescMHPurDate").ToString()
                txtDescMHPurPrice2.Text = ds.Tables(0).Rows(0).Item("DescMHPurPrice").ToString()
                txtDescMHCurDate2.Text = ds.Tables(0).Rows(0).Item("DescMHCurDate").ToString()
                txtDescMHAttStruc.Text = ds.Tables(0).Rows(0).Item("DescMHAttStruc").ToString()
                txtDescMHAttStrucAge.Text = ds.Tables(0).Rows(0).Item("DescMHAttStrucAge").ToString()
                txtDescMHAttStrucSize.Text = ds.Tables(0).Rows(0).Item("DescMHAttStrucSize").ToString()
                txtDescMHAttStrucCurVal2.Text = ds.Tables(0).Rows(0).Item("DescMHAttStrucCurVal").ToString()
                txtDescMHUnAttStruc.Text = ds.Tables(0).Rows(0).Item("DescMHUnAttStruc").ToString()
                txtDescMHUnAttStrucAge.Text = ds.Tables(0).Rows(0).Item("DescMHUnAttStrucAge").ToString()
                txtDescMHUnAttStrucSize.Text = ds.Tables(0).Rows(0).Item("DescMHUnAttStrucSize").ToString()
                txtDescMHUnAttStrucCurVal2.Text = ds.Tables(0).Rows(0).Item("DescMHUnAttStrucCurVal").ToString()
                lblProgram.Text = ds.Tables(0).Rows(0).Item("Program").ToString()
                ddUsage.SelectedItem = ddUsage.Items.FindByText(ds.Tables(0).Rows(0).Item("Usage").ToString())
                txtProtection.text = ds.Tables(0).Rows(0).Item("Protection").ToString()
                txtInsage.text = ds.Tables(0).Rows(0).Item("InsAge").ToString()
                ddMHAge.SelectedItem = ddMHAge.Items.FindByText(ds.Tables(0).Rows(0).Item("MHAge").ToString())
                ddlossHist.SelectedItem = ddlossHist.Items.FindByText(ds.Tables(0).Rows(0).Item("LossHist").ToString())
                ddParkStatus.SelectedItem = ddParkStatus.Items.FindByText(ds.Tables(0).Rows(0).Item("ParkStatus").ToString())
                txtNumOfSpaces.Text = ds.Tables(0).Rows(0).Item("NumOfSpaces").ToString()
                ddUnitType.SelectedItem = ddUnitType.Items.FindByText(ds.Tables(0).Rows(0).Item("UnitType").ToString())
                txtSatDish.text = ds.Tables(0).Rows(0).Item("SatDish").ToString()
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
                If ds.Tables(0).Rows(0).Item("PriorInsurance").ToString() = "" Then
                    ddPriorInsurance.SelectedItem = ddPriorInsurance.Items.FindByText("None")
                Else

                    ddPriorInsurance.SelectedItem = ddPriorInsurance.Items.FindByText(ds.Tables(0).Rows(0).Item("PriorInsurance").ToString())
                End If

                txtPriorCompany.Text = ds.Tables(0).Rows(0).Item("PriorCompany").ToString()
                txtLoss1Date.Text = ds.Tables(0).Rows(0).Item("Loss1Date").ToString()
                ddLoss1Type.SelectedValue = ds.Tables(0).Rows(0).Item("Loss1Type").ToString()
                txtLoss1Description.Text = ds.Tables(0).Rows(0).Item("Loss1Description").ToString()
                txtLoss1AmtPaid.Text = ds.Tables(0).Rows(0).Item("Loss1AmtPaid").ToString()
                ddLoss1Status.SelectedValue = ds.Tables(0).Rows(0).Item("Loss1Status").ToString()
                txtLoss2Date.Text = ds.Tables(0).Rows(0).Item("Loss2Date").ToString()
                ddLoss2Type.SelectedValue = ds.Tables(0).Rows(0).Item("Loss2Type").ToString()
                txtLoss2Description.Text = ds.Tables(0).Rows(0).Item("Loss2Description").ToString()
                txtLoss2AmtPaid.Text = ds.Tables(0).Rows(0).Item("Loss2AmtPaid").ToString()
                ddLoss2Status.SelectedValue = ds.Tables(0).Rows(0).Item("Loss2Status").ToString()
                txtLoss3Date.Text = ds.Tables(0).Rows(0).Item("Loss3Date").ToString()
                ddLoss3Type.SelectedValue = ds.Tables(0).Rows(0).Item("Loss3Type").ToString()
                txtLoss3Description.Text = ds.Tables(0).Rows(0).Item("Loss3Description").ToString()
                txtLoss3AmtPaid.Text = ds.Tables(0).Rows(0).Item("Loss3AmtPaid").ToString()
                ddLoss3Status.SelectedValue = ds.Tables(0).Rows(0).Item("Loss3Status").ToString()
                dd_ARIng1.SelectedItem = dd_ARIng1.Items.FindByText(ds.Tables(0).Rows(0).Item("ARIng1").ToString())
                dd_ARIng2.SelectedItem = dd_ARIng2.Items.FindByText(ds.Tables(0).Rows(0).Item("ARIng2").ToString())
                dd_ARIng3.SelectedItem = dd_ARIng3.Items.FindByText(ds.Tables(0).Rows(0).Item("ARIng3").ToString())
                dd_ARIng4.SelectedItem = dd_ARIng4.Items.FindByText(ds.Tables(0).Rows(0).Item("ARIng4").ToString())
                dd_ARIng5.SelectedItem = dd_ARIng5.Items.FindByText(ds.Tables(0).Rows(0).Item("ARIng5").ToString())
                dd_ARIng6.SelectedItem = dd_ARIng6.Items.FindByText(ds.Tables(0).Rows(0).Item("ARIng6").ToString())
                dd_ARIng7.SelectedItem = dd_ARIng7.Items.FindByText(ds.Tables(0).Rows(0).Item("ARIng7").ToString())
                dd_ARIng8.SelectedItem = dd_ARIng8.Items.FindByText(ds.Tables(0).Rows(0).Item("ARIng8").ToString())
                dd_ARIng9.SelectedItem = dd_ARIng9.Items.FindByText(ds.Tables(0).Rows(0).Item("ARIng9").ToString())
                dd_ARIng10.SelectedItem = dd_ARIng10.Items.FindByText(ds.Tables(0).Rows(0).Item("ARIng10").ToString())
                dd_ARIng11.SelectedItem = dd_ARIng11.Items.FindByText(ds.Tables(0).Rows(0).Item("ARIng11").ToString())
                dd_ARIng12.SelectedItem = dd_ARIng12.Items.FindByText(ds.Tables(0).Rows(0).Item("ARIng12").ToString())
                dd_ARIng13.SelectedItem = dd_ARIng13.Items.FindByText(ds.Tables(0).Rows(0).Item("ARIng13").ToString())
                dd_ARIng14.SelectedItem = dd_ARIng14.Items.FindByText(ds.Tables(0).Rows(0).Item("ARIng14").ToString())
                dd_ARIng15.SelectedItem = dd_ARIng15.Items.FindByText(ds.Tables(0).Rows(0).Item("ARIng15").ToString())
                dd_ARIng16.SelectedItem = dd_ARIng16.Items.FindByText(ds.Tables(0).Rows(0).Item("ARIng16").ToString())
                dd_ARIng17.SelectedItem = dd_ARIng17.Items.FindByText(ds.Tables(0).Rows(0).Item("ARIng17").ToString())
                dd_ARIng18.SelectedItem = dd_ARIng18.Items.FindByText(ds.Tables(0).Rows(0).Item("ARIng18").ToString())
                dd_ARIng19.SelectedItem = dd_ARIng19.Items.FindByText(ds.Tables(0).Rows(0).Item("ARIng19").ToString())
                dd_ARIng20.SelectedItem = dd_ARIng20.Items.FindByText(ds.Tables(0).Rows(0).Item("ARIng20").ToString())
                dd_ARIng21.SelectedItem = dd_ARIng21.Items.FindByText(ds.Tables(0).Rows(0).Item("ARIng21").ToString())
                dd_ARIng22.SelectedItem = dd_ARIng22.Items.FindByText(ds.Tables(0).Rows(0).Item("ARIng22").ToString())
                dd_ARIng23.SelectedItem = dd_ARIng23.Items.FindByText(ds.Tables(0).Rows(0).Item("ARIng23").ToString())
                dd_ARIng24.SelectedItem = dd_ARIng24.Items.FindByText(ds.Tables(0).Rows(0).Item("ARIng24").ToString())
                dd_ARIng25.SelectedItem = dd_ARIng25.Items.FindByText(ds.Tables(0).Rows(0).Item("ARIng25").ToString())
                dd_ARIng26.SelectedItem = dd_ARIng26.Items.FindByText(ds.Tables(0).Rows(0).Item("ARIng26").ToString())
                txtlandvalue.Text = ds.Tables(0).Rows(0).Item("LandPrice").ToString()
                txtinsurableInterest.Text = ds.Tables(0).Rows(0).Item("deededinterest").ToString()
                'dddistOptionInsured.SelectedValue = ds.Tables(0).Rows(0).Item("distOptionInsured").ToString()
                'dddistOptionAgent.SelectedValue = ds.Tables(0).Rows(0).Item("distOptionAgent").ToString()
                'ddPaymentOpt.SelectedValue = ds.Tables(0).Rows(0).Item("PaymentOpt").ToString()
                txtParkName.Text = ds.Tables(0).Rows(0).Item("ParkName").ToString()
                txtprioryears.Text = ds.Tables(0).Rows(0).Item("PriorInsYears").ToString()
                txtmodel.Text = ds.Tables(0).Rows(0).Item("DescModel").ToString()
                ARIng19a.Text = ds.Tables(0).Rows(0).Item("ARIng19a").ToString()
                ARIng21a.Text = ds.Tables(0).Rows(0).Item("ARIng21a").ToString()
                ARIng21b.SelectedItem = ARIng21b.Items.FindByText(ds.Tables(0).Rows(0).Item("ARIng21b").ToString())
                ARIng24a.SelectedItem = ARIng24a.Items.FindByText(ds.Tables(0).Rows(0).Item("ARIng24a").ToString())
                ARIng24b.SelectedItem = ARIng24b.Items.FindByText(ds.Tables(0).Rows(0).Item("ARIng24b").ToString())
                txtRenterName.Text = ds.Tables(0).Rows(0).Item("RentalName").ToString()
                PriorExp.Text = ds.Tables(0).Rows(0).Item("PriorInsExp").ToString()
                billLienholder.SelectedItem = billLienholder.Items.FindByText(ds.Tables(0).Rows(0).Item("BillLienHold").ToString())

            End If
            'load defaults from quote.

            If ds.Tables(0).Rows(0).Item("skirting").ToString() = "Brick" Or ds.Tables(0).Rows(0).Item("skirting").ToString() = "Block" Then
                dd_ARIng5.SelectedItem = dd_ARIng5.Items.FindByText("Yes")
                dd_ARIng6.SelectedItem = dd_ARIng6.Items.FindByText("Yes")
            Else
                dd_ARIng5.SelectedItem = dd_ARIng5.Items.FindByText("No")

            End If
            If ds.Tables(0).Rows(0).Item("skirting").ToString() = "None" Then
                dd_ARIng6.SelectedItem = dd_ARIng6.Items.FindByText("No")
            Else
                dd_ARIng6.SelectedItem = dd_ARIng6.Items.FindByText("Yes")
                dd_ARIng7.SelectedItem = dd_ARIng7.Items.FindByText("Yes")
            End If
            If ds.Tables(0).Rows(0).Item("suppHeatingType").ToString() = "Kerosene Heater" Then
                dd_ARIng10.SelectedItem = dd_ARIng10.Items.FindByText("Yes")
            End If
            If ds.Tables(0).Rows(0).Item("lapseInCoverage").ToString() = "Yes" Then
                dd_ARIng20.SelectedItem = dd_ARIng20.Items.FindByText("Yes")
            End If
            If ds.Tables(0).Rows(0).Item("suppHeating").ToString() = "Yes" Then
                dd_ARIng21.SelectedItem = dd_ARIng21.Items.FindByText("Yes")
                ARIng21a.Text = ds.Tables(0).Rows(0).Item("suppHeatingType").ToString()
            End If
            txtProtection.Text = ds.Tables(0).Rows(0).Item("protClass").ToString()
            txtInsage.Text = ds.Tables(0).Rows(0).Item("appage").ToString()
            txtSatDish.Text = ds.Tables(0).Rows(0).Item("Sat").ToString()
            getTerritory1(txtDiffAppCounty.Text)
            getTerritory2(txtCounty.Text)

            'lblTerritory.Text = "    " & ds.Tables(0).Rows(0).Item("Territory").ToString()
            LoadLosses()

            validateme()


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
    Protected Sub validateme()
        ApplyValidationSummarySettings()
        Dim UWstr As String
        Dim val As String

        val = "ELIGIBLE"
        UWstr = "<table> <tbody>"
        If ddPriorInsurance.SelectedItem.Text = "No" Then
            UWstr += "<tr align=left><td>Submit to UW – Contact The Colonial Group at 1-800-628-3762.</td><td>Prior Insurance is No</td></tr> "
            If val = "ELIGIBLE" Then
                val = "Submit to UW"
            End If

        End If

        If dd_ARIng6.SelectedItem.Text = "No" Then
            UWstr += "<tr align=left><td>Submit to UW – Contact The Colonial Group at 1-800-628-3762.</td><td>6.  Is the home on an enclosed foundation?</td></tr> "

            If val = "ELIGIBLE" Then
                val = "Submit to UW"
            End If
        End If
        If dd_ARIng7.SelectedItem.Text = "No" Then
            UWstr += "<tr align=left><td>Submit to UW – Contact The Colonial Group at 1-800-628-3762.</td><td>7.  Is the home skirted?</td></tr> "

            If val = "ELIGIBLE" Then
                val = "Submit to UW"
            End If
        End If
        If dd_ARIng8.SelectedItem.Text = "No" Then
            UWstr += "<tr align=left><td>Ineligible</td><td>8.  Is the manufactured home tied down?</td></tr> "

            If val = "ELIGIBLE" Then
                val = "INELIGIBLE"
            End If
        End If

        If dd_ARIng9.SelectedItem.Text = "No" Then
            UWstr += "<tr align=left><td>Ineligible</td><td>9.  Is the applicant the deeded owner?</td></tr> "

            If val = "ELIGIBLE" Then
                val = "INELIGIBLE"
            End If
        End If

        If dd_ARIng10.SelectedItem.Text = "Yes" Then
            UWstr += "<tr align=left><td>Ineligible</td><td>10.  Is there a portable Kerosene heater in the manufactured home, attached structured, unattached structure, or on the premises?</td></tr> "

            If val = "ELIGIBLE" Then
                val = "INELIGIBLE"
            End If
        End If

        If dd_ARIng11.SelectedItem.Text = "Yes" Then
            UWstr += "<tr align=left><td>Ineligible</td><td>11.  Is the manufactured home without utilities?</td></tr> "

            If val = "ELIGIBLE" Then
                val = "INELIGIBLE"
            End If
        End If
        If dd_ARIng12.SelectedItem.Text = "Yes" Then
            UWstr += "<tr align=left><td>Ineligible</td><td>12.  Does the manufactured home or any attached structure have any damage that has not been repaired?</td></tr> "

            If val = "ELIGIBLE" Then
                val = "INELIGIBLE"
            End If
        End If
        If dd_ARIng13.SelectedItem.Text = "Yes" Then
            UWstr += "<tr align=left><td>Ineligible</td><td>13.  Is there business conducted in the manufactured home, attached/unattached structures or on the premises?</td></tr> "

            If val = "ELIGIBLE" Then
                val = "INELIGIBLE"
            End If
        End If
        If dd_ARIng14.SelectedItem.Text = "Yes" Then
            UWstr += "<tr align=left><td>Ineligible</td><td>14.  Has the applicant had any fire, theft, liability loss/claim, more than one (1) other loss/claim or have an open/unresolved claim with a previous carrier at any location in the past three (3) years?</td></tr> "

            If val = "ELIGIBLE" Then
                val = "INELIGIBLE"
            End If
        End If

        If dd_ARIng15.SelectedItem.Text = "Yes" Then
            UWstr += "<tr align=left><td>Ineligible</td><td>15.  Is the manufactured home vacant or unoccupied?</td></tr> "

            If val = "ELIGIBLE" Then
                val = "INELIGIBLE"
            End If
        End If


        If dd_ARIng16.SelectedItem.Text = "Yes" Then
            UWstr += "<tr align=left><td>Ineligible</td><td>16.  Is the manufactured home under construction or renovation?</td></tr> "

            If val = "ELIGIBLE" Then
                val = "INELIGIBLE"
            End If
        End If

        If dd_ARIng17.SelectedItem.Text = "Yes" Then
            UWstr += "<tr align=left><td>Ineligible</td><td>17.  Has the manufactured home been condemned?</td></tr> "

            If val = "ELIGIBLE" Then
                val = "INELIGIBLE"
            End If
        End If
        If dd_ARIng18.SelectedItem.Text = "Yes" Then
            UWstr += "<tr align=left><td>Ineligible</td><td>18.  Is the manufactured home used for student housing?</td></tr> "

            If val = "ELIGIBLE" Then
                val = "INELIGIBLE"
            End If
        End If

        If dd_ARIng19.SelectedItem.Text = "Yes" Then
            UWstr += "<tr align=left><td>Submit to UW – Contact The Colonial Group at 1-800-628-3762.</td><td>19.  Has the applicant been canceled or non renewed?</td></tr> "

            If val = "ELIGIBLE" Then
                val = "Submit to UW"
            End If
        End If
        If dd_ARIng20.SelectedItem.Text = "Yes" Then
            UWstr += "<tr align=left><td>Submit to UW – Contact The Colonial Group at 1-800-628-3762.</td><td>20.  Has the applicant failed to carry insurance for any period of time?</td></tr> "

            If val = "ELIGIBLE" Then
                val = "Submit to UW"
            End If
        End If
        If dd_ARIng21.SelectedItem.Text = "Yes" Then
            UWstr += "<tr align=left><td>Submit to UW – Contact The Colonial Group at 1-800-628-3762.</td><td>21.  Is there a supplemental heat source in the manufactured home, attached/unattached structure or anywhere on the premises?  If it is a wood, coal, pellet, etc. stove, an Aegis woodstove report must be completed and submitted for approval.</td></tr> "

            If val = "ELIGIBLE" Then
                val = "Submit to UW"
            End If
        End If

        If dd_ARIng21.SelectedItem.Text = "Yes" Then
            ARIng21a.ValidationSettings.RequiredField.IsRequired = True
            ARIng21a.ValidationSettings.RequiredField.ErrorText = "Supplemental heating: 21a.  If yes, what type?"
            ARIng21a.ValidationSettings.SetFocusOnError = True
            ARIng21b.ValidationSettings.RequiredField.IsRequired = True
            ARIng21b.ValidationSettings.RequiredField.ErrorText = "Supplemental heating: 21b.  If yes, what type?"
            ARIng21b.ValidationSettings.SetFocusOnError = True
            If ARIng21b.SelectedItem.Text = "Yes" Then
                UWstr += "<tr align=left><td>Ineligible</td><td>21b. is it the only means of heat?</td></tr> "

                If val = "ELIGIBLE" Then
                    val = "INELIGIBLE"
                End If
            End If
        Else
            ARIng21a.ValidationSettings.RequiredField.IsRequired = False
            ARIng21b.ValidationSettings.RequiredField.IsRequired = False
        End If

        If dd_ARIng23.SelectedItem.Text = "Yes" Then
            UWstr += "<tr align=left><td>Submit to UW – Contact The Colonial Group at 1-800-628-3762.</td><td>23.  Are there any unusual property exposures?</td></tr> "

            If val = "ELIGIBLE" Then
                val = "Submit to UW"
            End If
        End If

        If dd_ARIng24.SelectedItem.Text = "Yes" Then
            ARIng24a.ValidationSettings.RequiredField.IsRequired = True
            ARIng24a.ValidationSettings.RequiredField.ErrorText = "Supplemental heating: 21a.  If yes, what type?"
            ARIng24a.ValidationSettings.SetFocusOnError = True
            ARIng24b.ValidationSettings.RequiredField.IsRequired = True
            ARIng24b.ValidationSettings.RequiredField.ErrorText = "Supplemental heating: 21a.  If yes, what type?"
            ARIng24b.ValidationSettings.SetFocusOnError = True
            UWstr += "<tr align=left><td>Submit to UW</td><td>24.  Is there a swimming pool on the premises?</td></tr> "

            If val = "ELIGIBLE" Then
                val = "Submit to UW"
            End If
        Else
            ARIng24a.ValidationSettings.RequiredField.IsRequired = False
            ARIng24b.ValidationSettings.RequiredField.IsRequired = False
        End If






        ' ApplyValidationSummarySettings()

        dd_ARIng1.ValidationSettings.RequiredField.IsRequired = True
        dd_ARIng1.ValidationSettings.RequiredField.ErrorText = "1.  Is the home located on land owned by the insured?"
        dd_ARIng1.ValidationSettings.SetFocusOnError = True
        dd_ARIng1.ValidationSettings.ErrorDisplayMode = ErrorDisplayMode.None


        dd_ARIng2.ValidationSettings.RequiredField.IsRequired = True
        dd_ARIng2.ValidationSettings.RequiredField.ErrorText = "2.  Does the purchase price include land?"
        dd_ARIng2.ValidationSettings.SetFocusOnError = True
        dd_ARIng2.ValidationSettings.ErrorDisplayMode = ErrorDisplayMode.None

        dd_ARIng3.ValidationSettings.RequiredField.IsRequired = True
        dd_ARIng3.ValidationSettings.RequiredField.ErrorText = "3.  Does the home have vinyl or hardboard siding?"
        dd_ARIng3.ValidationSettings.SetFocusOnError = True
        dd_ARIng3.ValidationSettings.ErrorDisplayMode = ErrorDisplayMode.None

        dd_ARIng4.ValidationSettings.RequiredField.IsRequired = True
        dd_ARIng4.ValidationSettings.RequiredField.ErrorText = "4.  Does the home have a composition roof?"
        dd_ARIng4.ValidationSettings.SetFocusOnError = True
        dd_ARIng4.ValidationSettings.ErrorDisplayMode = ErrorDisplayMode.None

        dd_ARIng5.ValidationSettings.RequiredField.IsRequired = True
        dd_ARIng5.ValidationSettings.RequiredField.ErrorText = "5.  Is the home on a permanent foundation?"
        dd_ARIng5.ValidationSettings.SetFocusOnError = True
        dd_ARIng5.ValidationSettings.ErrorDisplayMode = ErrorDisplayMode.None

        dd_ARIng6.ValidationSettings.RequiredField.IsRequired = True
        dd_ARIng6.ValidationSettings.RequiredField.ErrorText = "6.  Is the home on an enclosed foundation?"
        dd_ARIng6.ValidationSettings.SetFocusOnError = True
        dd_ARIng6.ValidationSettings.ErrorDisplayMode = ErrorDisplayMode.None

        dd_ARIng7.ValidationSettings.RequiredField.IsRequired = True
        dd_ARIng7.ValidationSettings.RequiredField.ErrorText = "7.  Is the home skirted?"
        dd_ARIng7.ValidationSettings.SetFocusOnError = True
        dd_ARIng7.ValidationSettings.ErrorDisplayMode = ErrorDisplayMode.None

        dd_ARIng8.ValidationSettings.RequiredField.IsRequired = True
        dd_ARIng8.ValidationSettings.RequiredField.ErrorText = "8.  Is the manufactured home tied down?"
        dd_ARIng8.ValidationSettings.SetFocusOnError = True
        dd_ARIng8.ValidationSettings.ErrorDisplayMode = ErrorDisplayMode.None

        dd_ARIng9.ValidationSettings.RequiredField.IsRequired = True
        dd_ARIng9.ValidationSettings.RequiredField.ErrorText = "9.  Is the applicant the deeded owner?"
        dd_ARIng9.ValidationSettings.SetFocusOnError = True
        dd_ARIng9.ValidationSettings.ErrorDisplayMode = ErrorDisplayMode.None

        dd_ARIng10.ValidationSettings.RequiredField.IsRequired = True
        dd_ARIng10.ValidationSettings.RequiredField.ErrorText = "10.  Is there a portable Kerosene heater in the manufactured home, attached structured, unattached structure, or on the premises?"
        dd_ARIng10.ValidationSettings.SetFocusOnError = True
        dd_ARIng10.ValidationSettings.ErrorDisplayMode = ErrorDisplayMode.None

        dd_ARIng11.ValidationSettings.RequiredField.IsRequired = True
        dd_ARIng11.ValidationSettings.RequiredField.ErrorText = "11.  Is the manufactured home without utilities?"
        dd_ARIng11.ValidationSettings.SetFocusOnError = True
        dd_ARIng11.ValidationSettings.ErrorDisplayMode = ErrorDisplayMode.None

        dd_ARIng12.ValidationSettings.RequiredField.IsRequired = True
        dd_ARIng12.ValidationSettings.RequiredField.ErrorText = "12.  Does the manufactured home or any attached structure have any damage that has not been repaired?"
        dd_ARIng12.ValidationSettings.SetFocusOnError = True
        dd_ARIng12.ValidationSettings.ErrorDisplayMode = ErrorDisplayMode.None

        dd_ARIng13.ValidationSettings.RequiredField.IsRequired = True
        dd_ARIng13.ValidationSettings.RequiredField.ErrorText = "13.  Is there business conducted in the manufactured home, attached/unattached structures or on the premises?"
        dd_ARIng13.ValidationSettings.SetFocusOnError = True
        dd_ARIng13.ValidationSettings.ErrorDisplayMode = ErrorDisplayMode.None

        dd_ARIng14.ValidationSettings.RequiredField.IsRequired = True
        dd_ARIng14.ValidationSettings.RequiredField.ErrorText = "14.  Has the applicant had any fire, theft, liability loss/claim, more than one (1) other loss/claim or have an open/unresolved claim with a previous carrier at any location in the past three (3) years?"
        dd_ARIng14.ValidationSettings.SetFocusOnError = True
        dd_ARIng14.ValidationSettings.ErrorDisplayMode = ErrorDisplayMode.None

        dd_ARIng15.ValidationSettings.RequiredField.IsRequired = True
        dd_ARIng15.ValidationSettings.RequiredField.ErrorText = "15.  Is the manufactured home vacant or unoccupied?"
        dd_ARIng15.ValidationSettings.SetFocusOnError = True
        dd_ARIng15.ValidationSettings.ErrorDisplayMode = ErrorDisplayMode.None

        dd_ARIng16.ValidationSettings.RequiredField.IsRequired = True
        dd_ARIng16.ValidationSettings.RequiredField.ErrorText = "16.  Is the manufactured home under construction or renovation?"
        dd_ARIng16.ValidationSettings.SetFocusOnError = True
        dd_ARIng16.ValidationSettings.ErrorDisplayMode = ErrorDisplayMode.None

        dd_ARIng17.ValidationSettings.RequiredField.IsRequired = True
        dd_ARIng17.ValidationSettings.RequiredField.ErrorText = "17.  Has the manufactured home been condemned?"
        dd_ARIng17.ValidationSettings.SetFocusOnError = True
        dd_ARIng17.ValidationSettings.ErrorDisplayMode = ErrorDisplayMode.None

        dd_ARIng18.ValidationSettings.RequiredField.IsRequired = True
        dd_ARIng18.ValidationSettings.RequiredField.ErrorText = "18.  Is the manufactured home used for student housing?"
        dd_ARIng18.ValidationSettings.SetFocusOnError = True
        dd_ARIng18.ValidationSettings.ErrorDisplayMode = ErrorDisplayMode.None

        dd_ARIng19.ValidationSettings.RequiredField.IsRequired = True
        dd_ARIng19.ValidationSettings.RequiredField.ErrorText = "19.  Has the applicant been canceled or non renewed?"
        dd_ARIng19.ValidationSettings.SetFocusOnError = True
        dd_ARIng19.ValidationSettings.ErrorDisplayMode = ErrorDisplayMode.None

        dd_ARIng20.ValidationSettings.RequiredField.IsRequired = True
        dd_ARIng20.ValidationSettings.RequiredField.ErrorText = "20.  Has the applicant failed to carry insurance for any period of time?"
        dd_ARIng20.ValidationSettings.SetFocusOnError = True
        dd_ARIng20.ValidationSettings.ErrorDisplayMode = ErrorDisplayMode.None

        dd_ARIng21.ValidationSettings.RequiredField.IsRequired = True
        dd_ARIng21.ValidationSettings.RequiredField.ErrorText = "21.  Is there a supplemental heat source in the manufactured home, attached/unattached structure or anywhere on the premises?  If it is a wood, coal, pellet, etc. stove, an Aegis woodstove report must be completed and submitted for approval."
        dd_ARIng21.ValidationSettings.SetFocusOnError = True
        dd_ARIng21.ValidationSettings.ErrorDisplayMode = ErrorDisplayMode.None

        dd_ARIng22.ValidationSettings.RequiredField.IsRequired = True
        dd_ARIng22.ValidationSettings.RequiredField.ErrorText = "22.  Does the applicant own or board any animal that has caused injury or bitten?  If yes, the exclusion on the application must be signed for eligibility."
        dd_ARIng22.ValidationSettings.SetFocusOnError = True
        dd_ARIng22.ValidationSettings.ErrorDisplayMode = ErrorDisplayMode.None


        dd_ARIng23.ValidationSettings.RequiredField.IsRequired = True
        dd_ARIng23.ValidationSettings.RequiredField.ErrorText = "23.  Are there any unusual property exposures?"
        dd_ARIng23.ValidationSettings.SetFocusOnError = True
        dd_ARIng23.ValidationSettings.ErrorDisplayMode = ErrorDisplayMode.None

        dd_ARIng24.ValidationSettings.RequiredField.IsRequired = True
        dd_ARIng24.ValidationSettings.RequiredField.ErrorText = "24.  Is there a swimming pool on the premises?"
        dd_ARIng24.ValidationSettings.SetFocusOnError = True
        dd_ARIng24.ValidationSettings.ErrorDisplayMode = ErrorDisplayMode.None

        dd_ARIng25.ValidationSettings.RequiredField.IsRequired = True
        dd_ARIng25.ValidationSettings.RequiredField.ErrorText = "25.  Are there any hazardous liability exposures?  If yes, must be written without liability coverage."
        dd_ARIng25.ValidationSettings.SetFocusOnError = True
        dd_ARIng25.ValidationSettings.ErrorDisplayMode = ErrorDisplayMode.None


        ddPriorInsurance.ValidationSettings.RequiredField.IsRequired = True
        ddPriorInsurance.ValidationSettings.RequiredField.ErrorText = "Prior Insurance Must be Answered"
        ddPriorInsurance.ValidationSettings.SetFocusOnError = True
        If ddPriorInsurance.SelectedItem.Text = "Yes" Then
            PriorExp.ValidationSettings.RequiredField.IsRequired = True
            PriorExp.ValidationSettings.RequiredField.ErrorText = "Must have Expiration Date on Prior Insurance"
            PriorExp.ValidationSettings.SetFocusOnError = True
            priorInsurance.Style.Item("display") = ""

            txtPriorCompany.ValidationSettings.RequiredField.IsRequired = True
            txtPriorCompany.ValidationSettings.RequiredField.ErrorText = "Must have Name on Prior Insurance"
            txtPriorCompany.ValidationSettings.SetFocusOnError = True
        ElseIf ddPriorInsurance.SelectedItem.Text = "None" Then
            ddPriorInsurance.IsValid = False
        Else
            PriorExp.ValidationSettings.RequiredField.IsRequired = False
            'PriorExp.ValidationSettings.RequiredField.ErrorText = "Must have Expiration Date on Prior Insurance"
            'PriorExp.ValidationSettings.SetFocusOnError = True
            priorInsurance.Style.Item("display") = "none"

            txtPriorCompany.ValidationSettings.RequiredField.IsRequired = False
            'txtPriorCompany.ValidationSettings.RequiredField.ErrorText = "Must have Expiration Date on Prior Insurance"
            'txtPriorCompany.ValidationSettings.SetFocusOnError = True

        End If
        ddUnitType.ValidationSettings.RequiredField.IsRequired = True
        ddUnitType.ValidationSettings.RequiredField.ErrorText = "Unit Type Must Be Answered"
        ddUnitType.ValidationSettings.SetFocusOnError = True

        ddParkStatus.ValidationSettings.RequiredField.IsRequired = True
        ddParkStatus.ValidationSettings.RequiredField.ErrorText = "Unit In Park Must Be Answered"
        ddParkStatus.ValidationSettings.SetFocusOnError = True

        ddlossHist.ValidationSettings.RequiredField.IsRequired = True
        ddlossHist.ValidationSettings.RequiredField.ErrorText = "Loss History Must Be Answered"
        ddlossHist.ValidationSettings.SetFocusOnError = True



        ASPxEdit.ValidateEditorsInContainer(Me)
        ApplyValidationSummarySettings()
        UWstr += "</table> </tbody>"
        If val = "Submit to UW" Then
            val = "Submit to UW – Contact The Colonial Group at 1-800-628-3762."
        End If
        AppStatuslbl.Text = val
        If val = "ELIGIBLE" Then
            AppStatuslbl.ForeColor = Drawing.Color.Green
            overridebtn.Visible = False
        End If
        If val = "INELIGIBLE" Then
            AppStatuslbl.ForeColor = Drawing.Color.Red
            overridebtn.Visible = False
        End If
        If val = "Submit to UW – Contact The Colonial Group at 1-800-628-3762." Then
            AppStatuslbl.ForeColor = Drawing.Color.Blue
            If mySession.CurrentUser.UWUser.ToString() = "True" Then
                overridebtn.Visible = True
            Else
                overridebtn.Visible = False
            End If
        End If
        Label173.Text = UWstr


    End Sub
    Private Sub ApplyValidationSummarySettings()
        vsValidationSummary1.RenderMode = ValidationSummaryRenderMode.OrderedList
        vsValidationSummary1.ShowErrorAsLink = True
    End Sub
    Private Sub zipbtn1_Click(sender As Object, e As System.EventArgs) Handles zipbtn1.Click
        LoadZip(txtDiffAppZip.Text)
        txtDiffAppZip.Focus()

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
            getTerritory1(txtDiffAppCounty.Text)

        Catch ex As Exception
            'Error
            errortrap("Zip Error", "Load Zip", ex.Message)
        Finally
            conn.Close()
        End Try



    End Sub
    Private Sub getTerritory1(ByVal county As String)
        Dim dbConn As String = ConfigurationManager.ConnectionStrings("ColonialMHConnectionString").ConnectionString
        Dim conn As New SqlConnection(dbConn)
        Dim cmd As New SqlCommand("SELECT * from tblAegisTerritory where county = '" & county & "' ", conn)

        Try
            If conn.State = Data.ConnectionState.Closed Then conn.Open()
            Dim rs As SqlDataReader = cmd.ExecuteReader()
            Do While rs.Read
                txtTerritory1.Text = rs("territoryid").ToString()
                'txtDiffAppState.Text = rs("State").ToString()
                'txtDiffAppCounty.Text = rs("County").ToString()

            Loop

            rs.Close()


        Catch ex As Exception
            'Error
            errortrap("Territory1 Error", "Load Zip", ex.Message)
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
            getTerritory2(txtCounty.Text)
            rs.Close()


        Catch ex As Exception
            'Error
            errortrap("Zip2 Error", "Load Zip", ex.Message)
        Finally
            conn.Close()
        End Try



    End Sub
    Private Sub getTerritory2(ByVal county As String)
        Dim dbConn As String = ConfigurationManager.ConnectionStrings("ColonialMHConnectionString").ConnectionString
        Dim conn As New SqlConnection(dbConn)
        Dim cmd As New SqlCommand("SELECT * from tblAegisTerritory where county = '" & county & "' ", conn)

        Try
            If conn.State = Data.ConnectionState.Closed Then conn.Open()
            Dim rs As SqlDataReader = cmd.ExecuteReader()
            Do While rs.Read
                txtTerritory2.Text = rs("territoryid").ToString()
                'txtDiffAppState.Text = rs("State").ToString()
                'txtDiffAppCounty.Text = rs("County").ToString()

            Loop

            rs.Close()


        Catch ex As Exception
            'Error
            errortrap("Territory1 Error", "Load Zip", ex.Message)
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
            errortrap("Zip4 Error", "Load Zip", ex.Message)
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
            errortrap("Zip5 Error", "Load Zip", ex.Message)
        Finally
            conn.Close()
        End Try



    End Sub
    Private Sub zipbtn6_Click(sender As Object, e As System.EventArgs) Handles zipbtn6.Click
        LoadZip6(txttitleZip.Text)
        txttitleZip.Focus()

    End Sub
    Public Sub LoadZip6(ByVal currentZip As String)


        Dim dbConn As String = ConfigurationManager.ConnectionStrings("CommonDbConnectionString").ConnectionString
        Dim conn As New SqlConnection(dbConn)
        Dim cmd As New SqlCommand("SELECT szCity AS City, szCounty AS County, szState_cd AS State FROM [wrwpaqbx_admin].[tblZip] WHERE szZip = '" & currentZip & "' ", conn)

        Try
            If conn.State = Data.ConnectionState.Closed Then conn.Open()
            Dim rs As SqlDataReader = cmd.ExecuteReader()
            Do While rs.Read
                txttitlecity.Text = rs("City").ToString()
                txttitlestate.Text = rs("State").ToString()
                ' txtDiffAppCounty.Text = rs("County").ToString()

            Loop

            rs.Close()


        Catch ex As Exception
            'Error
            errortrap("Zip Error", "Load Zip", ex.Message)
        Finally
            conn.Close()
        End Try



    End Sub



    Public Sub backtoquote(sender As Object, e As EventArgs)
        save()
        quoteID = Request.QueryString("quoteID")
        Response.Redirect("/Quote/quote.aspx?quoteID=" & quoteID & "")


    End Sub
    Public Sub savebtn_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles savebtn.Click
        If Request.QueryString("ApplicationID") <> "" Or Session("beenSaved") = "True" Then
            save()
        Else 'New Application
            save()
        End If

    End Sub
    Protected Sub save()
        Dim spdb As String = ""
        If txtSpouseDOB.Text.Length > 2 Then
            spdb = txtSpouseDOB.Text.Replace("/", "").Substring(0, 2) & "/" & txtSpouseDOB.Text.Replace("/", "").Substring(2, 2) & "/" & txtSpouseDOB.Text.Replace("/", "").Substring(4, 4) 'txtSpouseDOB.Text

        End If
        ' spdb = "'" & txtSpouseDOB.Text.Replace("/", "").Substring(0, 2) & "/" & txtSpouseDOB.Text.Replace("/", "").Substring(2, 2) & "/" & txtSpouseDOB.Text.Replace("/", "").Substring(4, 4) & "'," 'txtSpouseDOB.Text
        Dim quoteID As String
        If Request.QueryString("quoteID") <> "" Then
            quoteID = Request.QueryString("quoteID")
        Else 'New Quote
            quoteID = Request.QueryString("quoteID")
        End If
        Dim ds As System.Data.DataSet = New Data.DataSet
        Dim Connection As String = System.Configuration.ConfigurationManager.ConnectionStrings("ColonialMHConnectionString").ConnectionString
        Dim dbConnection As System.Data.IDbConnection = New System.Data.SqlClient.SqlConnection(Connection)
        Dim cmd As New SqlCommand("sp_AegisAppSave", dbConnection)
        cmd.CommandType = CommandType.StoredProcedure
        cmd.Parameters.Add("@ApplicationID", SqlDbType.VarChar, 8000).Value = txtAppNumber.Text
        cmd.Parameters.Add("@QuoteID", SqlDbType.VarChar, 8000).Value = quoteID
        cmd.Parameters.Add("@Status", SqlDbType.VarChar, 8000).Value = AppStatuslbl.Text
        cmd.Parameters.Add("@Name", SqlDbType.VarChar, 8000).Value = txtName.Text
        cmd.Parameters.Add("@DOB", SqlDbType.VarChar, 8000).Value = txtDOB.Text
        cmd.Parameters.Add("@Address", SqlDbType.VarChar, 8000).Value = txtDiffAppAddr.Text
        cmd.Parameters.Add("@City", SqlDbType.VarChar, 8000).Value = txtDiffAppCity.Text
        cmd.Parameters.Add("@State", SqlDbType.VarChar, 8000).Value = txtDiffAppState.Text
        cmd.Parameters.Add("@Zip", SqlDbType.VarChar, 8000).Value = txtDiffAppZip.Text
        cmd.Parameters.Add("@County", SqlDbType.VarChar, 8000).Value = txtDiffAppCounty.Text
        cmd.Parameters.Add("@Phone", SqlDbType.VarChar, 8000).Value = txtPhone2.Text
        cmd.Parameters.Add("@Occ", SqlDbType.VarChar, 8000).Value = txtOcc.Text
        cmd.Parameters.Add("@SSN", SqlDbType.VarChar, 8000).Value = txtSSN2.Text
        cmd.Parameters.Add("@SpouseName", SqlDbType.VarChar, 8000).Value = txtSpouseName.Text
        cmd.Parameters.Add("@SpouseDOB", SqlDbType.VarChar, 8000).Value = spdb '"'" & txtSpouseDOB.Text.Replace("/", "").Substring(0, 2) & "/" & txtSpouseDOB.Text.Replace("/", "").Substring(2, 2) & "/" & txtSpouseDOB.Text.Replace("/", "").Substring(4, 4) & "'," 'txtSpouseDOB.Text
        cmd.Parameters.Add("@SpousePhone", SqlDbType.VarChar, 8000).Value = CoPhone.Text
        cmd.Parameters.Add("@SpouseSSN", SqlDbType.VarChar, 8000).Value = txtSpouseSSN.Text
        cmd.Parameters.Add("@Employer", SqlDbType.VarChar, 8000).Value = txtemployer.Text
        cmd.Parameters.Add("@Employeedyrs", SqlDbType.VarChar, 8000).Value = txtemployedyears.Text
        cmd.Parameters.Add("@addinsname", SqlDbType.VarChar, 8000).Value = txttitlename.Text
        cmd.Parameters.Add("@addinsaddress", SqlDbType.VarChar, 8000).Value = txttitleaddress.Text
        cmd.Parameters.Add("@addinscity", SqlDbType.VarChar, 8000).Value = txttitlecity.Text
        cmd.Parameters.Add("@addinsstate", SqlDbType.VarChar, 8000).Value = txttitlestate.Text
        cmd.Parameters.Add("@addinszip", SqlDbType.VarChar, 8000).Value = txttitleZip.Text
        cmd.Parameters.Add("@AgentName", SqlDbType.VarChar, 8000).Value = txtAgentName.Text
        cmd.Parameters.Add("@DiffAppAddr", SqlDbType.VarChar, 8000).Value = txtAddress.Text
        cmd.Parameters.Add("@DiffAppCity", SqlDbType.VarChar, 8000).Value = txtCity.Text
        cmd.Parameters.Add("@DiffAppState", SqlDbType.VarChar, 8000).Value = txtState.Text
        cmd.Parameters.Add("@DiffAppZip", SqlDbType.VarChar, 8000).Value = txtZip.Text
        cmd.Parameters.Add("@DiffAppCounty", SqlDbType.VarChar, 8000).Value = txtCounty.Text
        cmd.Parameters.Add("@DistToFire", SqlDbType.VarChar, 8000).Value = txtDistToFire.Text
        cmd.Parameters.Add("@DistToFireDept", SqlDbType.VarChar, 8000).Value = txtDistToFireDept.Text
        cmd.Parameters.Add("@DistToGulf", SqlDbType.VarChar, 8000).Value = txtDistToGulf.Text
        cmd.Parameters.Add("@DescMHYear", SqlDbType.VarChar, 8000).Value = txtDescMHYear.Text
        cmd.Parameters.Add("@DescMHManf", SqlDbType.VarChar, 8000).Value = txtDescMHManf.Text
        cmd.Parameters.Add("@DescMHLength", SqlDbType.VarChar, 8000).Value = txtDescMHLength.Text
        cmd.Parameters.Add("@DescMHWidth", SqlDbType.VarChar, 8000).Value = txtDescMHWidth.Text
        cmd.Parameters.Add("@DescMHSerial", SqlDbType.VarChar, 8000).Value = txtDescMHSerial.Text
        cmd.Parameters.Add("@DescMHPurDate", SqlDbType.VarChar, 8000).Value = txtDescMHPurDate2.Text
        cmd.Parameters.Add("@DescMHPurPrice", SqlDbType.VarChar, 8000).Value = txtDescMHPurPrice2.Text
        cmd.Parameters.Add("@DescMHCurDate", SqlDbType.VarChar, 8000).Value = txtDescMHCurDate2.Text
        cmd.Parameters.Add("@DescMHAttStruc", SqlDbType.VarChar, 8000).Value = txtDescMHAttStruc.Text
        cmd.Parameters.Add("@DescMHAttStrucAge", SqlDbType.VarChar, 8000).Value = txtDescMHAttStrucAge.Text
        cmd.Parameters.Add("@DescMHAttStrucSize", SqlDbType.VarChar, 8000).Value = txtDescMHAttStrucSize.Text
        cmd.Parameters.Add("@DescMHAttStrucCurVal", SqlDbType.VarChar, 8000).Value = txtDescMHAttStrucCurVal2.Text
        cmd.Parameters.Add("@DescMHUnAttStruc", SqlDbType.VarChar, 8000).Value = txtDescMHUnAttStruc.Text
        cmd.Parameters.Add("@DescMHUnAttStrucAge", SqlDbType.VarChar, 8000).Value = txtDescMHUnAttStrucAge.Text
        cmd.Parameters.Add("@DescMHUnAttStrucSize", SqlDbType.VarChar, 8000).Value = txtDescMHUnAttStrucSize.Text
        cmd.Parameters.Add("@DescMHUnAttStrucCurVal", SqlDbType.VarChar, 8000).Value = txtDescMHUnAttStrucCurVal2.Text
        cmd.Parameters.Add("@Program", SqlDbType.VarChar, 8000).Value = lblProgram.Text
        cmd.Parameters.Add("@Usage", SqlDbType.VarChar, 8000).Value = ddUsage.SelectedItem.Text
        cmd.Parameters.Add("@Protection", SqlDbType.VarChar, 8000).Value = txtProtection.Text
        cmd.Parameters.Add("@InsAge", SqlDbType.VarChar, 8000).Value = txtInsage.Text
        cmd.Parameters.Add("@MHAge", SqlDbType.VarChar, 8000).Value = ddMHAge.SelectedItem.Text
        cmd.Parameters.Add("@lossHist", SqlDbType.VarChar, 8000).Value = ddlossHist.SelectedItem.Text
        cmd.Parameters.Add("@ParkStatus", SqlDbType.VarChar, 8000).Value = ddParkStatus.SelectedItem.Text
        cmd.Parameters.Add("@NumOfSpaces", SqlDbType.VarChar, 8000).Value = txtNumOfSpaces.Text
        cmd.Parameters.Add("@UnitType", SqlDbType.VarChar, 8000).Value = ddUnitType.SelectedItem.Text
        cmd.Parameters.Add("@SatDish", SqlDbType.VarChar, 8000).Value = txtSatDish.Text
        cmd.Parameters.Add("@Lien1Name", SqlDbType.VarChar, 8000).Value = txtLien1Name.Text
        cmd.Parameters.Add("@Lien1Num", SqlDbType.VarChar, 8000).Value = txtLien1Num.Text
        cmd.Parameters.Add("@Lien1Addr", SqlDbType.VarChar, 8000).Value = txtLien1Addr.Text
        cmd.Parameters.Add("@Lien1City", SqlDbType.VarChar, 8000).Value = txtLien1City.Text
        cmd.Parameters.Add("@Lien1State", SqlDbType.VarChar, 8000).Value = txtLien1State.Text
        cmd.Parameters.Add("@Lien1Zip", SqlDbType.VarChar, 8000).Value = txtLien1Zip.Text
        cmd.Parameters.Add("@Lien2Name", SqlDbType.VarChar, 8000).Value = txtLien2Name.Text
        cmd.Parameters.Add("@Lien2Num", SqlDbType.VarChar, 8000).Value = txtLien2Num.Text
        cmd.Parameters.Add("@Lien2Addr", SqlDbType.VarChar, 8000).Value = txtLien2Addr.Text
        cmd.Parameters.Add("@Lien2City", SqlDbType.VarChar, 8000).Value = txtLien2City.Text
        cmd.Parameters.Add("@Lien2State", SqlDbType.VarChar, 8000).Value = txtLien2State.Text
        cmd.Parameters.Add("@Lien2Zip", SqlDbType.VarChar, 8000).Value = txtLien2Zip.Text
        cmd.Parameters.Add("@PriorInsurance", SqlDbType.VarChar, 8000).Value = ddPriorInsurance.SelectedItem.Text
        cmd.Parameters.Add("@PriorCompany", SqlDbType.VarChar, 8000).Value = txtPriorCompany.Text
        cmd.Parameters.Add("@Loss1Date", SqlDbType.VarChar, 8000).Value = txtLoss1Date.Text
        cmd.Parameters.Add("@Loss1Type", SqlDbType.VarChar, 8000).Value = ddLoss1Type.SelectedValue()
        cmd.Parameters.Add("@Loss1Description", SqlDbType.VarChar, 8000).Value = txtLoss1Description.Text
        cmd.Parameters.Add("@Loss1AmtPaid", SqlDbType.VarChar, 8000).Value = txtLoss1AmtPaid.Text
        cmd.Parameters.Add("@Loss1Status", SqlDbType.VarChar, 8000).Value = ddLoss1Status.SelectedValue()
        cmd.Parameters.Add("@Loss2Date", SqlDbType.VarChar, 8000).Value = txtLoss2Date.Text
        cmd.Parameters.Add("@Loss2Type", SqlDbType.VarChar, 8000).Value = ddLoss2Type.SelectedValue()
        cmd.Parameters.Add("@Loss2Description", SqlDbType.VarChar, 8000).Value = txtLoss2Description.Text
        cmd.Parameters.Add("@Loss2AmtPaid", SqlDbType.VarChar, 8000).Value = txtLoss2AmtPaid.Text
        cmd.Parameters.Add("@Loss2Status", SqlDbType.VarChar, 8000).Value = ddLoss2Status.SelectedValue()
        cmd.Parameters.Add("@Loss3Date", SqlDbType.VarChar, 8000).Value = txtLoss3Date.Text
        cmd.Parameters.Add("@Loss3Type", SqlDbType.VarChar, 8000).Value = ddLoss3Type.SelectedValue()
        cmd.Parameters.Add("@Loss3Description", SqlDbType.VarChar, 8000).Value = txtLoss3Description.Text
        cmd.Parameters.Add("@Loss3AmtPaid", SqlDbType.VarChar, 8000).Value = txtLoss3AmtPaid.Text
        cmd.Parameters.Add("@Loss3Status", SqlDbType.VarChar, 8000).Value = ddLoss3Status.SelectedValue()
        cmd.Parameters.Add("@ARIng1", SqlDbType.VarChar, 8000).Value = dd_ARIng1.SelectedItem.Text
        cmd.Parameters.Add("@ARIng2", SqlDbType.VarChar, 8000).Value = dd_ARIng2.SelectedItem.Text
        cmd.Parameters.Add("@ARIng3", SqlDbType.VarChar, 8000).Value = dd_ARIng3.SelectedItem.Text
        cmd.Parameters.Add("@ARIng4", SqlDbType.VarChar, 8000).Value = dd_ARIng4.SelectedItem.Text
        cmd.Parameters.Add("@ARIng5", SqlDbType.VarChar, 8000).Value = dd_ARIng5.SelectedItem.Text
        cmd.Parameters.Add("@ARIng6", SqlDbType.VarChar, 8000).Value = dd_ARIng6.SelectedItem.Text
        cmd.Parameters.Add("@ARIng7", SqlDbType.VarChar, 8000).Value = dd_ARIng7.SelectedItem.Text
        cmd.Parameters.Add("@ARIng8", SqlDbType.VarChar, 8000).Value = dd_ARIng8.SelectedItem.Text
        cmd.Parameters.Add("@ARIng9", SqlDbType.VarChar, 8000).Value = dd_ARIng9.SelectedItem.Text
        cmd.Parameters.Add("@ARIng10", SqlDbType.VarChar, 8000).Value = dd_ARIng10.SelectedItem.Text
        cmd.Parameters.Add("@ARIng11", SqlDbType.VarChar, 8000).Value = dd_ARIng11.SelectedItem.Text
        cmd.Parameters.Add("@ARIng12", SqlDbType.VarChar, 8000).Value = dd_ARIng12.SelectedItem.Text
        cmd.Parameters.Add("@ARIng13", SqlDbType.VarChar, 8000).Value = dd_ARIng13.SelectedItem.Text
        cmd.Parameters.Add("@ARIng14", SqlDbType.VarChar, 8000).Value = dd_ARIng14.SelectedItem.Text
        cmd.Parameters.Add("@ARIng15", SqlDbType.VarChar, 8000).Value = dd_ARIng15.SelectedItem.Text
        cmd.Parameters.Add("@ARIng16", SqlDbType.VarChar, 8000).Value = dd_ARIng16.SelectedItem.Text
        cmd.Parameters.Add("@ARIng17", SqlDbType.VarChar, 8000).Value = dd_ARIng17.SelectedItem.Text
        cmd.Parameters.Add("@ARIng18", SqlDbType.VarChar, 8000).Value = dd_ARIng18.SelectedItem.Text
        cmd.Parameters.Add("@ARIng19", SqlDbType.VarChar, 8000).Value = dd_ARIng19.SelectedItem.Text
        cmd.Parameters.Add("@ARIng20", SqlDbType.VarChar, 8000).Value = dd_ARIng20.SelectedItem.Text
        cmd.Parameters.Add("@ARIng21", SqlDbType.VarChar, 8000).Value = dd_ARIng21.SelectedItem.Text
        cmd.Parameters.Add("@ARIng22", SqlDbType.VarChar, 8000).Value = dd_ARIng22.SelectedItem.Text
        cmd.Parameters.Add("@ARIng23", SqlDbType.VarChar, 8000).Value = dd_ARIng23.SelectedItem.Text
        cmd.Parameters.Add("@ARIng24", SqlDbType.VarChar, 8000).Value = dd_ARIng24.SelectedItem.Text
        cmd.Parameters.Add("@ARIng25", SqlDbType.VarChar, 8000).Value = dd_ARIng25.SelectedItem.Text
        cmd.Parameters.Add("@ARIng26", SqlDbType.VarChar, 8000).Value = dd_ARIng26.SelectedItem.Text
        cmd.Parameters.Add("@LandPrice", SqlDbType.VarChar, 8000).Value = txtlandvalue.Text
        cmd.Parameters.Add("@DeedInt", SqlDbType.VarChar, 8000).Value = txtinsurableInterest.Text
        cmd.Parameters.Add("@distOptionInsured", SqlDbType.VarChar, 8000).Value = "" 'dddistOptionInsured.SelectedValue
        cmd.Parameters.Add("@distOptionAgent", SqlDbType.VarChar, 8000).Value = "" 'dddistOptionAgent.SelectedValue
        cmd.Parameters.Add("@PaymentOpt", SqlDbType.VarChar, 8000).Value = "" ' ddPaymentOpt.SelectedValue
        cmd.Parameters.Add("@ParkName", SqlDbType.VarChar, 8000).Value = txtParkName.Text
        cmd.Parameters.Add("@PriorInsYears", SqlDbType.VarChar, 8000).Value = txtprioryears.Text
        cmd.Parameters.Add("@DescModel", SqlDbType.VarChar, 8000).Value = txtmodel.Text
        cmd.Parameters.Add("@ARIng19a", SqlDbType.VarChar, 8000).Value = ARIng19a.Text
        cmd.Parameters.Add("@ARIng21a", SqlDbType.VarChar, 8000).Value = ARIng21a.Text
        cmd.Parameters.Add("@ARIng21b", SqlDbType.VarChar, 8000).Value = ARIng21b.SelectedItem.Text
        cmd.Parameters.Add("@ARIng24a", SqlDbType.VarChar, 8000).Value = ARIng24a.SelectedItem.Text
        cmd.Parameters.Add("@ARIng24b", SqlDbType.VarChar, 8000).Value = ARIng24b.SelectedItem.Text
        cmd.Parameters.Add("@RentalName", SqlDbType.VarChar, 8000).Value = txtRenterName.Text
        cmd.Parameters.Add("@BillLienHold", SqlDbType.VarChar, 8000).Value = billLienholder.SelectedItem.Text
        cmd.Parameters.Add("@PriorInsExp", SqlDbType.VarChar, 8000).Value = PriorExp.Text
        cmd.Parameters.Add("@Territory1", SqlDbType.VarChar, 8000).Value = txtTerritory1.Text
        cmd.Parameters.Add("@Territory2", SqlDbType.VarChar, 8000).Value = txtTerritory2.Text
        cmd.Parameters.Add("@override", SqlDbType.VarChar, 8000).Value = OVreasontxt.Text
        Try
            cmd.Connection.Open()
            ' intRowsAff = cmd.ExecuteNonQuery()

            Dim myCommand = New SqlDataAdapter(cmd)
            myCommand.Fill(ds, "tbl1")
            '  updateStatus("Application Saved")
            If txtAppNumber.Text = "NULL" Or txtAppNumber.Text = "" Then
                'ds = com.runQueryDS("SELECT TOP 1 ApplicationID FROM tblLloydApplication ORDER BY ApplicationID DESC", "ColonialMHConnectionString")
                If ds.Tables(0).Rows.Count > 0 Then
                    txtAppNumber.Text = ds.Tables(0).Rows(0).Item("ApplicationID").ToString()
                    labelapp.Text = ds.Tables(0).Rows(0).Item("ApplicationID").ToString()
                End If
            End If
        Catch ex As Exception
            Dim s As String = ""
            For Each param As SqlParameter In cmd.Parameters
                s += param.ParameterName & "="
                s += param.Value & ":  "

            Next
            errortrap("Aegis Save " & s, "Save Aegis Application", ex.Message)
            'updateStatus("Save Failed")
        End Try

    End Sub
    Protected Sub btnprior_Click(sender As Object, e As EventArgs) Handles btnprior.Click
        If ddPriorInsurance.SelectedItem.Text = "Yes" Then
            priorInsurance.Style.Item("display") = ""
            txtPriorCompany.Focus()

        ElseIf ddPriorInsurance.SelectedItem.Text = "No" Then
            priorInsurance.Style.Item("display") = "none"
            AppStatuslbl.Text = "Submit to UW – Contact The Colonial Group at 1-800-628-3762."
            AppStatuslbl.ForeColor = Drawing.Color.Blue
        ElseIf ddPriorInsurance.SelectedItem.Text = "None" Then
            ddPriorInsurance.IsValid = False
            ddPriorInsurance.ValidationSettings.ErrorText = "Must Choose Prior Insurance"
            priorInsurance.Style.Item("display") = "none"
        Else
            priorInsurance.Style.Item("display") = "none"
        End If
        Dim val As String = AppStatuslbl.Text
        If val = "ELIGIBLE" Then
            AppStatuslbl.ForeColor = Drawing.Color.Green
            overridebtn.Visible = False
        End If
        If val = "INELIGIBLE" Then
            AppStatuslbl.ForeColor = Drawing.Color.Red
            overridebtn.Visible = False
        End If
        If val = "Submit to UW – Contact The Colonial Group at 1-800-628-3762." Then
            AppStatuslbl.ForeColor = Drawing.Color.Blue
            If mySession.CurrentUser.UWUser.ToString() = "True" Then
                overridebtn.Visible = True
            Else
                overridebtn.Visible = False
            End If
        End If

    End Sub
    Public Sub btnLogout_Click(ByVal sender As Object, ByVal e As EventArgs)
        mySession.Clear()
        Server.Transfer("~/Login.aspx")

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
    Protected Sub printApp(ByVal sender As Object, ByVal e As EventArgs) Handles printBtn.Click
        validateme()

        '' ApplyValidationSummarySettings()

        'dd_ARIng1.ValidationSettings.RequiredField.IsRequired = True
        'dd_ARIng1.ValidationSettings.RequiredField.ErrorText = "Woodburning Stove or Fireplace"
        'dd_ARIng1.ValidationSettings.SetFocusOnError = True

        'dd_ARIng2.ValidationSettings.RequiredField.IsRequired = True
        'dd_ARIng2.ValidationSettings.RequiredField.ErrorText = "Business on Property?"
        'dd_ARIng2.ValidationSettings.SetFocusOnError = True

        'dd_ARIng3.ValidationSettings.RequiredField.IsRequired = True
        'dd_ARIng3.ValidationSettings.RequiredField.ErrorText = "Farming on Property?"
        'dd_ARIng3.ValidationSettings.SetFocusOnError = True

        'dd_ARIng4.ValidationSettings.RequiredField.IsRequired = True
        'dd_ARIng4.ValidationSettings.RequiredField.ErrorText = "Animals on Property?"
        'dd_ARIng4.ValidationSettings.SetFocusOnError = True

        'dd_ARIng5.ValidationSettings.RequiredField.IsRequired = True
        'dd_ARIng5.ValidationSettings.RequiredField.ErrorText = " Swimming Pool on Property?"
        'dd_ARIng5.ValidationSettings.SetFocusOnError = True

        'dd_ARIng6.ValidationSettings.RequiredField.IsRequired = True
        'dd_ARIng6.ValidationSettings.RequiredField.ErrorText = "Repo/Foreclosure in the past 24 months?"
        'dd_ARIng6.ValidationSettings.SetFocusOnError = True

        'dd_ARIng7.ValidationSettings.RequiredField.IsRequired = True
        'dd_ARIng7.ValidationSettings.RequiredField.ErrorText = "Bankruptcy in the past 24 months?"
        'dd_ARIng7.ValidationSettings.SetFocusOnError = True

        'dd_ARIng8.ValidationSettings.RequiredField.IsRequired = True
        'dd_ARIng8.ValidationSettings.RequiredField.ErrorText = "Claims in the past 36 months?"
        'dd_ARIng8.ValidationSettings.SetFocusOnError = True

        'dd_ARIng9.ValidationSettings.RequiredField.IsRequired = True
        'dd_ARIng9.ValidationSettings.RequiredField.ErrorText = "Unrepaired Damage?"
        'dd_ARIng9.ValidationSettings.SetFocusOnError = True

        'dd_ARIng10.ValidationSettings.RequiredField.IsRequired = True
        'dd_ARIng10.ValidationSettings.RequiredField.ErrorText = "Handrails Installed (3 or more steps)?"
        'dd_ARIng10.ValidationSettings.SetFocusOnError = True

        'dd_ARIng11.ValidationSettings.RequiredField.IsRequired = True
        'dd_ARIng11.ValidationSettings.RequiredField.ErrorText = "Mortgage Payment Currently Past Due?"
        'dd_ARIng11.ValidationSettings.SetFocusOnError = True

        'dd_ARIng12.ValidationSettings.RequiredField.IsRequired = True
        'dd_ARIng12.ValidationSettings.RequiredField.ErrorText = "Kerosene Heater?"
        'dd_ARIng12.ValidationSettings.SetFocusOnError = True

        'ddPriorInsurance.ValidationSettings.RequiredField.IsRequired = True
        'ddPriorInsurance.ValidationSettings.RequiredField.ErrorText = "Prior Insurance Must be Answered"
        'ddPriorInsurance.ValidationSettings.SetFocusOnError = True

        'ddUnitType.ValidationSettings.RequiredField.IsRequired = True
        'ddUnitType.ValidationSettings.RequiredField.ErrorText = "Unit Type Must Be Answered"
        'ddUnitType.ValidationSettings.SetFocusOnError = True

        'ddParkStatus.ValidationSettings.RequiredField.IsRequired = True
        'ddParkStatus.ValidationSettings.RequiredField.ErrorText = "Unit In Park Must Be Answered"
        'ddParkStatus.ValidationSettings.SetFocusOnError = True

        'ddlossHist.ValidationSettings.RequiredField.IsRequired = True
        'ddlossHist.ValidationSettings.RequiredField.ErrorText = "Loss History Must Be Answered"
        'ddlossHist.ValidationSettings.SetFocusOnError = True



        '  ASPxEdit.ValidateEditorsInContainer(Me)
        '  ApplyValidationSummarySettings()
        'ASPxPopupControl1.ShowOnPageLoad = False
        'ASPxPopupControl1.Enabled = False

        If Request.QueryString("ApplicationID") <> "" Or Session("beenSaved") = "True" Then
            save()
        Else 'New Quote
            save()
        End If
        Dim printme As Boolean = True
        If ASPxEdit.AreEditorsValid(Me) = True Then
            printme = True
        Else
            printme = False

        End If
        'If txtSSN2.IsValid.ToString = "True" And txtPhone2.IsValid.ToString = "True" And txtOcc.IsValid.ToString = "True" And txtSSN2.IsValid.ToString = "True" And txtAgentName.IsValid.ToString = "True" And txtDiffAppAddr.IsValid.ToString = "True" And txtDiffAppState.IsValid.ToString = "True" And ddUsage.IsValid.ToString = "True" And ddMHAge.IsValid.ToString = "True" _
        '    And ddlossHist.IsValid.ToString = "True" And ddParkStatus.IsValid.ToString = "True" _
        '    And ddUnitType.IsValid.ToString = "True" _
        '    And ddUnitType.IsValid.ToString = "True" _
        '    And dd_ARIng1.IsValid.ToString = "True" _
        '    And dd_ARIng2.IsValid.ToString = "True" _
        '    And dd_ARIng3.IsValid.ToString = "True" _
        '    And dd_ARIng4.IsValid.ToString = "True" _
        '    And dd_ARIng5.IsValid.ToString = "True" _
        '        And dd_ARIng6.IsValid.ToString = "True" _
        '         And dd_ARIng7.IsValid.ToString = "True" _
        '          And dd_ARIng8.IsValid.ToString = "True" _
        '          And dd_ARIng9.IsValid.ToString = "True" _
        '            And dd_ARIng10.IsValid.ToString = "True" _
        '             And dd_ARIng11.IsValid.ToString = "True" _
        '             And dd_ARIng12.IsValid.ToString = "True" _
        '             And txtAddress.IsValid.ToString = "True" Then
        '    printme = True
        'Else
        '    printme = False
        'End If


        If printme = False Then

        ElseIf AppStatuslbl.Text = "INELIGIBLE" Then
            overridebtn.Visible = False
            ASPxPopupControl1.Enabled = True
            'Label173.Text = UWstr
            ASPxPopupControl1.PopupElementID = "printBtn"
            ASPxPopupControl1.ShowOnPageLoad = True
        ElseIf AppStatuslbl.Text = "Submit to UW – Contact The Colonial Group at 1-800-628-3762." Then
            ASPxPopupControl1.Enabled = True
            'Label173.Text = UWstr
            ASPxPopupControl1.PopupElementID = "printBtn"
            ASPxPopupControl1.ShowOnPageLoad = True
            If mySession.CurrentUser.UWUser.ToString() = "True" Then
                overridebtn.Visible = True
            Else
                overridebtn.Visible = False
            End If
        Else




            If txtAppNumber.Text <> "" Then
                Common.AjaxOpenWindow(Me.Page, "AegisApplicationPrint.aspx?AppID=" & txtAppNumber.Text, Nothing)

            Else
                Try
                    Dim ds As System.Data.DataSet


                    If txtAppNumber.Text = "NULL" Or txtAppNumber.Text = "" Then
                        ds = com.runQueryDS("SELECT TOP 1 ApplicationID FROM tblAegisApplication where quoteid = " & txtQuoteID.Text & " ORDER BY ApplicationID DESC", "ColonialMHConnectionString")
                        If ds.Tables(0).Rows.Count > 0 Then
                            txtAppNumber.Text = ds.Tables(0).Rows(0).Item("ApplicationID").ToString()
                            labelapp.Text = ds.Tables(0).Rows(0).Item("ApplicationID").ToString()
                            Common.AjaxOpenWindow(Me.Page, "AegisApplicationPrint.aspx?AppID=" & ds.Tables(0).Rows(0).Item("ApplicationID").ToString(), Nothing)
                        End If
                    End If
                Catch ex As Exception
                    errortrap("Print Aegis Application", "Application ID " & txtAppNumber.Text, ex.Message)
                End Try

            End If

        End If


    End Sub
    Private Sub errortrap(ByVal sqlcomm As String, ByVal appsub As String, ByVal errormsg As String)
        Dim intRowsAff As Integer
        Dim Connection As String = System.Configuration.ConfigurationManager.ConnectionStrings("ColonialMHConnectionString").ConnectionString
        Dim dbConnection As System.Data.IDbConnection = New System.Data.SqlClient.SqlConnection(Connection)
        Dim cmd As New SqlCommand("sp_InsertError", dbConnection)
        cmd.CommandType = CommandType.StoredProcedure
        cmd.Parameters.Add("@code", SqlDbType.VarChar, 8000).Value = sqlcomm
        cmd.Parameters.Add("@Page", SqlDbType.VarChar, 50).Value = "Aegis Application"
        cmd.Parameters.Add("@sub", SqlDbType.VarChar, 50).Value = appsub
        cmd.Parameters.Add("@msg", SqlDbType.VarChar, 8000).Value = errormsg
        Try
            cmd.Connection.Open()
            intRowsAff = cmd.ExecuteNonQuery()
        Catch ex As Exception

        End Try


    End Sub


    Protected Sub OVprint_Click(sender As Object, e As EventArgs) Handles OVprint.Click
        If OVreasontxt.Text.Length > 2 Then
            'Save OverRide Reason:
            save()


            If txtAppNumber.Text <> "" Then
                Common.AjaxOpenWindow(Me.Page, "AegisApplicationPrint.aspx?AppID=" & txtAppNumber.Text, Nothing)

            Else
                Try
                    Dim ds As System.Data.DataSet


                    If txtAppNumber.Text = "NULL" Or txtAppNumber.Text = "" Then
                        ds = com.runQueryDS("SELECT TOP 1 ApplicationID FROM tblAegisApplication where quoteid = " & txtQuoteID.Text & " ORDER BY ApplicationID DESC", "ColonialMHConnectionString")
                        If ds.Tables(0).Rows.Count > 0 Then
                            txtAppNumber.Text = ds.Tables(0).Rows(0).Item("ApplicationID").ToString()
                            labelapp.Text = ds.Tables(0).Rows(0).Item("ApplicationID").ToString()
                            Common.AjaxOpenWindow(Me.Page, "AegisApplicationPrint.aspx?AppID=" & ds.Tables(0).Rows(0).Item("ApplicationID").ToString(), Nothing)
                        End If
                    End If
                Catch ex As Exception
                    errortrap("Print Aegis Application OverRide", "Application ID " & txtAppNumber.Text, ex.Message)
                End Try

            End If
        End If
    End Sub

End Class