Imports System.Data.SqlClient
Public Class LloydsApplication
    Inherits System.Web.UI.Page
    Dim com As New Common
    Dim quoteID As String
    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        If Not IsPostBack Then
            If Request.QueryString("quoteID") <> "" Then '  quoteID is not empty

                quoteID = Request.QueryString("quoteID")
                'for testing
                'quoteID = "64"
                '------------------
                txtQuoteID.Text = Request.QueryString("quoteID")
                loadData(quoteID)
            End If
            txtDOB.Attributes.Add("onKeyPress", "return UpdateDOB();")
            ' txtSpouseDOB.Attributes.Add("onKeyPress", "return UpdateSpouseDOB();")
            ddParkStatus.Attributes.Add("onChange", "return parkStatus();")
            ' ddSupHeating.Attributes.Add("onChange", "return supHeating();")
            ddPriorInsurance.Attributes.Add("onChange", "return PriorIns();")
            ' ddAnimal.Attributes.Add("onChange", "return AnimalType();")
            'addlInsuredcheck.Attributes.Add("onChange", "return AdditionalIns();")
            txtZip.Attributes.Add("onKeyUp", "return zipcodeKeyDown1();")
            txtDiffAppZip.Attributes.Add("onKeyUp", "return zipcodeKeyDown();")
            'txtaddzip.Attributes.Add("onKeyUp", "return zipcodeKeyDown2();")
            txtLien1Zip.Attributes.Add("onKeyUp", "return zipcodeKeyDown3();")
            txtLien2Zip.Attributes.Add("onKeyUp", "return zipcodeKeyDown4();")
            LoadEligiblityEvents()
            DupLocation.Checked = False
        End If

    End Sub
    Protected Sub loadData(ByVal quoteID As String)
        Dim ds As System.Data.DataSet
        ds = com.runQueryDS("EXEC sp_LloydQuoteAppData '" & quoteID & "'", "ColonialMHConnectionString")
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

            If ds.Tables(0).Rows(0).Item("ApplicationID").ToString() > "" Then


                txtParkName.Text = ds.Tables(0).Rows(0).Item("ParkName").ToString()

                'dd_ctylimits.SelectedValue = ds.Tables(0).Rows(0).Item("ctylimits").ToString()
                'dd_fwua.SelectedValue = ds.Tables(0).Rows(0).Item("fwua").ToString()

                'txtDescMHYear.Text = ds.Tables(0).Rows(0).Item("MHYear").ToString()
                'txtDescMHManf.Text = ds.Tables(0).Rows(0).Item("MHmanf").ToString()
                'txtDescMHLength.Text = ds.Tables(0).Rows(0).Item("MHLength").ToString()
                'txtDescMHWidth.Text = ds.Tables(0).Rows(0).Item("MHWidth").ToString()
                txtDescMHSerial.Text = ds.Tables(0).Rows(0).Item("DescMHSerial").ToString()
                txtDescMHPurDate2.Text = ds.Tables(0).Rows(0).Item("DescMHPurDate").ToString()
                txtDescMHPurPrice2.Text = FormatCurrency(ds.Tables(0).Rows(0).Item("DescMHPurPrice").ToString())
                txtDescMHAttStruc.Text = ds.Tables(0).Rows(0).Item("DescMHAttStruc").ToString()
                txtDescMHAttStrucAge.Text = ds.Tables(0).Rows(0).Item("DescMHAttStrucAge").ToString()
                txtDescMHAttStrucSize.Text = ds.Tables(0).Rows(0).Item("DescMHAttStrucSize").ToString()
                txtDescMHAttStrucCurVal2.Text = FormatCurrency(ds.Tables(0).Rows(0).Item("DescMHAttStrucCurVal").ToString())
                txtDescMHUnAttStruc.Text = ds.Tables(0).Rows(0).Item("DescMHUnAttStruc").ToString()
                txtDescMHUnAttStrucAge.Text = ds.Tables(0).Rows(0).Item("DescMHUnAttStrucAge").ToString()
                txtDescMHUnAttStrucSize.Text = ds.Tables(0).Rows(0).Item("DescMHUnAttStrucSize").ToString()
                txtDescMHUnAttStrucCurVal2.Text = FormatCurrency(ds.Tables(0).Rows(0).Item("DescMHUnAttStrucCurVal").ToString())
                ' ddProgram.SelectedValue = ds.Tables(0).Rows(0).Item("Program").ToString()
                ddUsage.SelectedValue = ds.Tables(0).Rows(0).Item("Usage").ToString()
                '  ddProt.SelectedValue = ds.Tables(0).Rows(0).Item("Protection").ToString()
                ' txtInsAge.Text = ds.Tables(0).Rows(0).Item("appage").ToString()
                'If ds.Tables(0).Rows(0).Item("MHAge").ToString() <> "" Then
                '    ddMHAge.SelectedValue = ds.Tables(0).Rows(0).Item("MHAge").ToString()
                'Else
                '    Dim mhage As String
                '    mhage = ds.Tables(0).Rows(0).Item("Homeage").ToString()
                '    If mhage > 0 And mhage < 6 Then
                '        ddMHAge.SelectedValue = "1-5 Yrs"
                '    ElseIf mhage > 5 And mhage < 16 Then
                '        ddMHAge.SelectedValue = "6-15 Yrs"
                '    ElseIf mhage > 15 Then
                '        ddMHAge.SelectedValue = "16 Yrs & Older"

                '    End If

                'End If
                ddlossHist.SelectedValue = ds.Tables(0).Rows(0).Item("MHLoss").ToString()
                ddParkStatus.SelectedValue = ds.Tables(0).Rows(0).Item("isMHinPark").ToString()
                ddUnitType.SelectedValue = ds.Tables(0).Rows(0).Item("homeType").ToString()
                'txtAcres.Text = ds.Tables(0).Rows(0).Item("Acres").ToString()
                'txtNumOfSpaces.Text = ds.Tables(0).Rows(0).Item("NumOfSpaces").ToString()
                'txtPerOfAdults.Text = ds.Tables(0).Rows(0).Item("PerOfAdults").ToString()
                'ddResManger.SelectedValue = ds.Tables(0).Rows(0).Item("ResManger").ToString()
                '' ddUnitType.SelectedValue = ds.Tables(0).Rows(0).Item("UnitType").ToString()
                'txtNumOfFrontSteps.Text = ds.Tables(0).Rows(0).Item("NumOfFrontSteps").ToString()
                'txtNumOfRearSteps.Text = ds.Tables(0).Rows(0).Item("NumOfRearSteps").ToString()
                'ddSupHeating.SelectedValue = ds.Tables(0).Rows(0).Item("suppHeating").ToString()
                'ddSupHeating.SelectedItem.Value = ds.Tables(0).Rows(0).Item("suppHeating").ToString()
                'ddSatDish.SelectedValue = ds.Tables(0).Rows(0).Item("SatDish").ToString()
                'ddAnimal.SelectedValue = ds.Tables(0).Rows(0).Item("Animal").ToString()
                'txtAnimalType.Text = ds.Tables(0).Rows(0).Item("AnimalType").ToString()
                'txtDogBreed.Text = ds.Tables(0).Rows(0).Item("DogBreed").ToString()
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
                
                'dddistOptionInsured.SelectedValue = ds.Tables(0).Rows(0).Item("distOptionInsured").ToString()
                'dddistOptionAgent.SelectedValue = ds.Tables(0).Rows(0).Item("distOptionAgent").ToString()
                'ddPaymentOpt.SelectedValue = ds.Tables(0).Rows(0).Item("PaymentOpt").ToString()
                txtprioryears.Text = ds.Tables(0).Rows(0).Item("PriorInsYears").ToString()
            End If
            lblTerritory.Text = "    " & ds.Tables(0).Rows(0).Item("Territory").ToString()
            LoadLosses()



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
    Protected Sub LoadEligiblityEvents()
        dd_ARIng1.Attributes.Add("onChange", "return CheckEligiblity2(this.id);")
        dd_ARIng2.Attributes.Add("onChange", "return CheckEligiblity2(this.id);")
        dd_ARIng3.Attributes.Add("onChange", "return CheckEligiblity(this.id);")
        dd_ARIng4.Attributes.Add("onChange", "return CheckEligiblity2(this.id);")
        dd_ARIng5.Attributes.Add("onChange", "return CheckEligiblity2(this.id);")
        dd_ARIng6.Attributes.Add("onChange", "return CheckEligiblity(this.id);")
        dd_ARIng7.Attributes.Add("onChange", "return CheckEligiblity(this.id);")
        dd_ARIng8.Attributes.Add("onChange", "return CheckEligiblity2(this.id);")
        dd_ARIng9.Attributes.Add("onChange", "return CheckEligiblity(this.id);")
        dd_ARIng10.Attributes.Add("onChange", "return CheckEligiblity3(this.id);")
        dd_ARIng11.Attributes.Add("onChange", "return CheckEligiblity(this.id);")
        dd_ARIng12.Attributes.Add("onChange", "return CheckEligiblity(this.id);")
        'dd_ARIng13.Attributes.Add("onChange", "return CheckEligiblity(this.id);")
        'dd_ARIng14.Attributes.Add("onChange", "return CheckEligiblity(this.id);")
        'dd_ARIng15.Attributes.Add("onChange", "return CheckEligiblity(this.id);")
        'dd_ARIng16.Attributes.Add("onChange", "return CheckEligiblity(this.id);")
        'dd_ARIng17.Attributes.Add("onChange", "return CheckEligiblity(this.id);")
        'dd_ARIng18.Attributes.Add("onChange", "return CheckEligiblity(this.id);")
        'dd_ARIng19.Attributes.Add("onChange", "return CheckEligiblity(this.id);")
        'dd_ARIng20.Attributes.Add("onChange", "return CheckEligiblity(this.id);")
        'dd_ARIng21.Attributes.Add("onChange", "return CheckEligiblity(this.id);")
        'dd_ARIng22.Attributes.Add("onChange", "return CheckEligiblity(this.id);")
        'dd_ARIng23.Attributes.Add("onChange", "return CheckEligiblity(this.id);")
        'dd_ARIng24.Attributes.Add("onChange", "return CheckEligiblity(this.id);")
        'dd_ARIng25.Attributes.Add("onChange", "return CheckEligiblity(this.id);")
        'dd_ARIng26.Attributes.Add("onChange", "return CheckEligiblity(this.id);")
        'dd_ARIng27.Attributes.Add("onChange", "return CheckEligiblity(this.id);")
        'dd_ARIng28.Attributes.Add("onChange", "return CheckEligiblity(this.id);")
        'dd_ARIng29.Attributes.Add("onChange", "return CheckEligiblity2(this.id);")
        'dd_ARIng30.Attributes.Add("onChange", "return CheckEligiblity2(this.id);")
        'dd_ARIng31.Attributes.Add("onChange", "return CheckEligiblity2(this.id);")
        'dd_ARIng32.Attributes.Add("onChange", "return CheckEligiblity2(this.id);")
        'dd_ARIng33.Attributes.Add("onChange", "return CheckEligiblity2(this.id);")
        'dd_ARIng34.Attributes.Add("onChange", "return CheckEligiblity2(this.id);")
        'dd_ARIng35.Attributes.Add("onChange", "return CheckEligiblity2(this.id);")
        'dd_ARIng36.Attributes.Add("onChange", "return CheckEligiblity2(this.id);")
        'dd_ARIng37.Attributes.Add("onChange", "return CheckEligiblity2(this.id);")
        'dd_ARIng38.Attributes.Add("onChange", "return CheckEligiblity2(this.id);")
        'dd_ARIng39.Attributes.Add("onChange", "return CheckEligiblity2(this.id);")
        'dd_ARIng40.Attributes.Add("onChange", "return CheckEligiblity2(this.id);")
        'dd_ARIng41.Attributes.Add("onChange", "return CheckEligiblity2(this.id);")
        'dd_ARIng42.Attributes.Add("onChange", "return CheckEligiblity2(this.id);")
        'dd_ARIng43.Attributes.Add("onChange", "return CheckEligiblity2(this.id);")



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
        tsql = "EXEC sp_UpdateLloydApplication  '" & txtAppNumber.Text & "', "
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
        tsql += " '" & ddUsage.SelectedValue & "',"
        tsql += " '" & ddMHAge.SelectedValue & "',"
        tsql += " '" & ddlossHist.SelectedValue & "',"
        tsql += " '" & ddParkStatus.SelectedValue & "',"
        ' tsql += " '" & ddSupHeating.SelectedValue & "',"
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
        
        tsql += " '" & txtParkName.Text & "',"
        tsql += " '" & txtprioryears.Text & "'"

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
        End Try

    End Sub
    Private Sub updateStatus(ByVal str As String)
        Dim lbl As New Label()
        lbl.Text = "<script language='javascript'> window.status ='" & str & "';" & "<" & "/script>"
        Page.Controls.Add(lbl)

    End Sub
    Public Sub backtoquote(sender As Object, e As EventArgs)

        quoteID = Request.QueryString("quoteID")
        Response.Redirect("/Quote/quote.aspx?quoteID=" & quoteID & "")


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
        If Request.QueryString("ApplicationID") <> "" Or Session("beenSaved") = "True" Then
            save()
        Else 'New Quote
            save()
        End If

        Common.AjaxOpenWindow(Me.Page, "ApplicationPrintLloyd.aspx?AppID=" & txtAppNumber.Text, Nothing)
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


        Catch ex As Exception
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
        Finally
            conn.Close()
        End Try



    End Sub
End Class