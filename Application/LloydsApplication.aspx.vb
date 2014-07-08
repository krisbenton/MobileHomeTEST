Imports System.Data.SqlClient
Imports DevExpress.Web.ASPxEditors
Public Class LloydsApplication
    Inherits System.Web.UI.Page
    Dim com As New Common
    Dim quoteID As String
    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
       
        ' ApplyValidationSummarySettings()
        If Not IsPostBack Then
            Dim user As String
            Try
                Response.Cache.SetCacheability(System.Web.HttpCacheability.NoCache)
                'Reset Form

                user = mySession.CurrentUser.AgencyName.ToString()
                
            Catch ex As Exception
                mySession.Clear()
                Server.Transfer("~/Login.aspx")
            End Try



            'findimport.Attributes.Add("onClick", "redirect3(); return false;")
            overridebtn.Visible = False
            Dim test As String = mySession.CurrentUser.UWUser.ToString
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
            'If mySession.CurrentUser.AdminUser.ToString = "True" Then
            '    adminpage.Visible = True

            'End If



            'If Not IsCallback Then
            '    ASPxEdit.ValidateEditorsInContainer(Me)

            'End If
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
            'Added for SC financing option.
            ddPaymentOpt.Attributes.Add("onChange", "return PremFinanceCheck();")
            dd_ARIng1.Attributes.Add("onChange", "return ValidateCheck();")
            dd_ARIng2.Attributes.Add("onChange", "return ValidateCheck();")
            dd_ARIng3.Attributes.Add("onChange", "return ValidateCheck();")
            dd_ARIng4.Attributes.Add("onChange", "return ValidateCheck();")
            dd_ARIng5.Attributes.Add("onChange", "return ValidateCheck();")
            dd_ARIng6.Attributes.Add("onChange", "return ValidateCheck();")
            dd_ARIng7.Attributes.Add("onChange", "return ValidateCheck();")
            dd_ARIng8.Attributes.Add("onChange", "return ValidateCheck();")
            dd_ARIng9.Attributes.Add("onChange", "return ValidateCheck();")
            dd_ARIng10.Attributes.Add("onChange", "return ValidateCheck();")
            dd_ARIng11.Attributes.Add("onChange", "return ValidateCheck();")
            dd_ARIng12.Attributes.Add("onChange", "return ValidateCheck();")



            DownPaymentPercentRB.Attributes.Add("onChange", "return FinanceOptionChange();")
            FinanceLengthRB.Attributes.Add("onChange", "return FinanceOptionChange();")


            'Add onchange for PrimeRateDP
            PrimeRateDP.Attributes.Add("onChange", "return PrimeRateFinanceOptionChange();")



            LoadEligiblityEvents()
            DupLocation.Checked = False
        End If
        Dim val As String = AppStatuslbl.Text
        If val = "ELIGIBLE" Then
            AppStatuslbl.ForeColor = Drawing.Color.Green
            printBtn.Visible = True
        End If
        If val = "INELIGIBLE" Then
            AppStatuslbl.ForeColor = Drawing.Color.Red
        End If
        If val = "Submit to UW" Then
            AppStatuslbl.Text = "Submit to UW – Contact The Colonial Group at 1-800-628-3762."
            AppStatuslbl.ForeColor = Drawing.Color.Blue
            printBtn.Visible = False
            If mySession.CurrentUser.UWUser.ToString() = "True" Then
                overridebtn.Visible = True
            Else
                overridebtn.Visible = False
            End If
        End If
        Dim lbl As New Label()
        lbl.Text = "<script language='javascript'> PremFinanceCheck();" & "<" & "/script>"
        Page.Controls.Add(lbl)
    End Sub
    Protected Sub loadData(ByVal quoteID As String)
        Dim ds, ds2 As System.Data.DataSet
        'Load Prime Rate
        ds2 = com.runQueryDS("SELECT * FROM dbo.vwFinancingInfo WHERE quoteID = '" & quoteID & "'", "ColonialMHConnectionString")
        If ds2.Tables(0).Rows.Count > 0 Then
            ddPaymentOpt.SelectedValue = "Premium Finance"
            Dim XML As String = ds2.Tables(0).Rows(0).Item("xmlData").ToString
            Dim DP As String = XML.GetXMLElementValue("PcDown").ToString
            If CDbl(DP.Substring(0, 2)) <= "25" Then
                PrimeRateDP.SelectedValue = "25% Down"
            ElseIf CDbl(DP.Substring(0, 2)) <= "40" Then
                PrimeRateDP.SelectedValue = "40% Down"
            ElseIf CDbl(DP.Substring(0, 2)) <= "50" Then
                PrimeRateDP.SelectedValue = "50% Down"
            End If
            Dim PrimeRateDS As System.Data.DataSet
            Dim DetailString As String = ""
            PrimeRateDS = com.runQueryDS("SELECT * FROM dbo.vwFinancingInfo WHERE quoteID = '" & Request.QueryString("quoteID") & "' ", "ColonialMHConnectionString")
            If PrimeRateDS.Tables(0).Rows.Count > 0 Then ' Show current Contract.

                DetailString = "<b> Finance Charge <b> &nbsp; " & FormatCurrency(CDec(PrimeRateDS.Tables(0).Rows(0).Item("APR").ToString)) & "<br/>"
                DetailString += "<b> Down Payment Amount <b> &nbsp; " & FormatCurrency(PrimeRateDS.Tables(0).Rows(0).Item("downPayment").ToString) & "<br/>"
                DetailString += "<b> Payment <b> &nbsp; " & PrimeRateDS.Tables(0).Rows(0).Item("Payment").ToString & "<br/>"
                DetailString += "<b> Number 0f Payments <b> &nbsp; " & PrimeRateDS.Tables(0).Rows(0).Item("NumberOfPayments").ToString & "<br/>"

            Else
                'Finance No Calculated
                DetailString = "There was an issue contacting Prime Rate. Please try again later."
            End If

            PrimeRateFinanceInfo.Text = DetailString
            PrimeRateUpdatePanel.Update()

            Dim lbl As New Label()
            lbl.Text = "<script language='javascript'>PremFinanceCheck();" & "<" & "/script>"
            Page.Controls.Add(lbl)
        End If

        'Load Financing
        ds = com.runQueryDS("SELECT * FROM tblColonialFinancing WHERE quoteID = '" & quoteID & "'", "ColonialMHConnectionString")

        If ds.Tables(0).Rows.Count > 0 Then
            ddPaymentOpt.SelectedValue = "Premium Finance"
            Dim length As String = ds.Tables(0).Rows(0).Item("length").ToString
            If length = 3 Then
                FinanceLengthRB.SelectedValue = "3 Months"
            ElseIf length = 6 Then
                FinanceLengthRB.SelectedValue = "6 Months"
            ElseIf length = 8 Then
                FinanceLengthRB.SelectedValue = "8 Months"
            End If

            Dim dp As String = ds.Tables(0).Rows(0).Item("downPayment").ToString
            If dp = 25 Then
                DownPaymentPercentRB.SelectedValue = "25% Down"
            ElseIf dp = 40 Then
                DownPaymentPercentRB.SelectedValue = "40% Down"
            ElseIf dp = 50 Then
                DownPaymentPercentRB.SelectedValue = "50% Down"

            End If
            Dim lbl As New Label()
            lbl.Text = "<script language='javascript'>PremFinanceCheck(); FinanceOptionChange();" & "<" & "/script>"
            Page.Controls.Add(lbl)

            calcSCFinancing()


        End If 'End of Load Financing
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
            '   lblPackage.Text = "Lloyds  " & ds.Tables(0).Rows(0).Item("ARRateType").ToString()
            lblCarrier.Text = "Lloyds"
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
            If ds.Tables(0).Rows(0).Item("Homeage").ToString() > 0 And ds.Tables(0).Rows(0).Item("Homeage").ToString() < 6 Then
                ddMHAge.SelectedItem = ddMHAge.Items.FindByText("1-5 Yrs")
            ElseIf ds.Tables(0).Rows(0).Item("Homeage").ToString() > 5 And ds.Tables(0).Rows(0).Item("Homeage").ToString() < 16 Then
                ddMHAge.SelectedItem = ddMHAge.Items.FindByText("6-15 Yrs")
            ElseIf ds.Tables(0).Rows(0).Item("Homeage").ToString() > 15 Then
                ddMHAge.SelectedItem = ddMHAge.Items.FindByText("16 Yrs & Older")
            Else
                ddMHAge.SelectedItem = ddMHAge.Items.FindByText("1-5 Yrs")

            End If
            ddParkStatus.SelectedItem = ddParkStatus.Items.FindByText(ds.Tables(0).Rows(0).Item("isMHInPark").ToString())
            ddUnitType.SelectedItem = ddUnitType.Items.FindByText(ds.Tables(0).Rows(0).Item("homeType").ToString())
            ddlossHist.SelectedItem = ddlossHist.Items.FindByText(ds.Tables(0).Rows(0).Item("priorLoss").ToString())
            'dd_ARIng1.SelectedValue = ds.Tables(0).Rows(0).Item("suppHeating").ToString()
            dd_ARIng1.SelectedItem = dd_ARIng1.Items.FindByText(ds.Tables(0).Rows(0).Item("suppHeating").ToString())
            dd_ARIng12.SelectedItem = dd_ARIng12.Items.FindByText(ds.Tables(0).Rows(0).Item("priorLoss").ToString()) 'ds.Tables(0).Rows(0).Item("priorLoss").ToString()
            dd_ARIng8.SelectedItem = dd_ARIng8.Items.FindByText(ds.Tables(0).Rows(0).Item("suppHeating").ToString()) 'ds.Tables(0).Rows(0).Item("suppHeating").ToString()
            lbllapse.Text = ds.Tables(0).Rows(0).Item("lapseInCoverage").ToString()

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
                Try
                    txtDescMHPurPrice2.Text = FormatCurrency(ds.Tables(0).Rows(0).Item("DescMHPurPrice").ToString())
                Catch ex As Exception
                    txtDescMHPurPrice2.Text = "$0.00"
                End Try

                txtDescMHAttStruc.Text = ds.Tables(0).Rows(0).Item("DescMHAttStruc").ToString()
                txtDescMHAttStrucAge.Text = ds.Tables(0).Rows(0).Item("DescMHAttStrucAge").ToString()
                txtDescMHAttStrucSize.Text = ds.Tables(0).Rows(0).Item("DescMHAttStrucSize").ToString()
                Try
                    txtDescMHAttStrucCurVal2.Text = FormatCurrency(ds.Tables(0).Rows(0).Item("DescMHAttStrucCurVal").ToString())
                Catch ex As Exception
                    txtDescMHAttStrucCurVal2.Text = "$0.00"
                End Try

                txtDescMHUnAttStruc.Text = ds.Tables(0).Rows(0).Item("DescMHUnAttStruc").ToString()
                txtDescMHUnAttStrucAge.Text = ds.Tables(0).Rows(0).Item("DescMHUnAttStrucAge").ToString()
                txtDescMHUnAttStrucSize.Text = ds.Tables(0).Rows(0).Item("DescMHUnAttStrucSize").ToString()
                Try
                    txtDescMHUnAttStrucCurVal2.Text = FormatCurrency(ds.Tables(0).Rows(0).Item("DescMHUnAttStrucCurVal").ToString())
                Catch ex As Exception
                    txtDescMHUnAttStrucCurVal2.Text = "$0.00"
                End Try

                ' ddProgram.SelectedValue = ds.Tables(0).Rows(0).Item("Program").ToString()
                ddUsage.SelectedItem = ddUsage.Items.FindByText(ds.Tables(0).Rows(0).Item("Usage").ToString())
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
                ddlossHist.SelectedItem = ddlossHist.Items.FindByText(ds.Tables(0).Rows(0).Item("MHLoss").ToString())
                ddParkStatus.SelectedItem = ddParkStatus.Items.FindByText(ds.Tables(0).Rows(0).Item("isMHinPark").ToString())
                ddUnitType.SelectedItem = ddUnitType.Items.FindByText(ds.Tables(0).Rows(0).Item("homeType").ToString())
                txtSpouseName.Text = ds.Tables(0).Rows(0).Item("SpouseName").ToString()
                txtSpouseSSN.Text = ds.Tables(0).Rows(0).Item("SpouseSSN").ToString()
                txtSpouseDOB.Text = ds.Tables(0).Rows(0).Item("SpouseDOB").ToString()
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
                ddPriorInsurance.SelectedItem = ddPriorInsurance.Items.FindByText(ds.Tables(0).Rows(0).Item("PriorInsurance").ToString())
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
                'dd_ARIng1.SelectedValue = ds.Tables(0).Rows(0).Item("ARIng1").ToString()
                'If ds.Tables(0).Rows(0).Item("ARIng1").ToString() = "Yes" Then
                '    dd_ARIng1.SelectedItem = dd_ARIng1.Items.FindByText("Woodstove")
                'ElseIf ds.Tables(0).Rows(0).Item("ARIng1").ToString() = "No" Then
                '    dd_ARIng1.SelectedItem = dd_ARIng1.Items.FindByText("None")
                'ElseIf ds.Tables(0).Rows(0).Item("ARIng1").ToString() = "" Then
                '    dd_ARIng1.SelectedItem = dd_ARIng1.Items.FindByText("None")
                'Else
                '    dd_ARIng1.SelectedItem = dd_ARIng1.Items.FindByText(ds.Tables(0).Rows(0).Item("ARIng1").ToString())
                'End If
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

                'dddistOptionInsured.SelectedValue = ds.Tables(0).Rows(0).Item("distOptionInsured").ToString()
                'dddistOptionAgent.SelectedValue = ds.Tables(0).Rows(0).Item("distOptionAgent").ToString()
                ddPaymentOpt.SelectedValue = ds.Tables(0).Rows(0).Item("PaymentType").ToString()
                txtprioryears.Text = ds.Tables(0).Rows(0).Item("PriorInsYears").ToString()


                'If ds.Tables(0).Rows(0).Item("PriorInsurance").ToString() = "Yes" Then
                '    priorInsurance.Style.Item("display") = ""
                'Else
                '    priorInsurance.Style.Item("display") = "none"
                'End If

            End If
            lblTerritory.Text = "    " & ds.Tables(0).Rows(0).Item("Territory").ToString()
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
    Protected Sub LoadEligiblityEvents()
        ' dd_ARIng1.Attributes.Add("onChange", "return CheckEligiblity2(this.id);")
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
        Try

            tsql = "EXEC sp_UpdateLloydApplication  '" & txtAppNumber.Text & "', "
            'tsql += " '" & txtQuoteID.Text & "',"
            tsql += " '" & quoteID & "',"
            tsql += " '" & AppStatuslbl.Text & "',"
            tsql += " '" & txtName.Text.Replace("'", "''") & "',"
            tsql += " '" & txtDOB.Text & "',"
            tsql += " '" & txtDiffAppAddr.Text.Replace("'", "''") & "',"
            tsql += " '" & txtDiffAppCity.Text.Replace("'", "''") & "',"
            tsql += " '" & txtDiffAppState.Text & "',"
            tsql += " '" & txtDiffAppZip.Text & "',"
            tsql += " '" & txtDiffAppCounty.Text & "',"
            'tsql += " '" & txtAddress.Text & "',"
            'tsql += " '" & txtCity.Text & "',"
            'tsql += " '" & txtState.Text & "',"
            'tsql += " '" & txtZip.Text & "',"
            'tsql += " '" & txtCounty.Text & "',"
            tsql += " '" & txtPhone2.Text & "',"
            tsql += " '" & txtOcc.Text.Replace("'", "''") & "',"
            tsql += " '" & txtSSN2.Text & "',"

            tsql += " '" & txtSpouseName.Text.Replace("'", "''") & "',"
            tsql += " '" & txtSpouseSSN.Text & "',"
            ' tsql += " '" & txtSpouseDOB.Text & "',"
            ' tsql += " cast(left('" & txtSpouseDOB.Text & "',2) + '/' + substring('" & txtSpouseDOB.Text & "',3,2) + '/' + right('" & txtSpouseDOB.Text & "',4) as datetime)  ,"
            If txtSpouseDOB.Text <> "" Then
                tsql += "'" & txtSpouseDOB.Text.Replace("/", "").Substring(0, 2) & "/" & txtSpouseDOB.Text.Replace("/", "").Substring(2, 2) & "/" & txtSpouseDOB.Text.Replace("/", "").Substring(4, 4) & "',"
            Else
                tsql += "'',"
            End If
            'tsql += "'" & txtSpouseDOB.Text.Substring(0, 2) & "/" & txtSpouseDOB.Text.Substring(2, 2) & "/" & txtSpouseDOB.Text.Substring(4, 4) & "',"
            tsql += " '" & txtAgentName.Text.Replace("'", "''") & "',"
            tsql += " '" & txtAddress.Text.Replace("'", "''") & "',"
            tsql += " '" & txtCity.Text.Replace("'", "''") & "',"
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
            tsql += " '" & txtDescMHManf.Text.Replace("'", "''") & "',"
            tsql += " '" & txtDescMHLength.Text & "',"
            tsql += " '" & txtDescMHWidth.Text & "',"
            tsql += " '" & txtDescMHSerial.Text.Replace("'", "''") & "',"
            If txtDescMHPurDate2.Text.Length < 9 And txtDescMHPurDate2.Text <> "" Then
                tsql += "'" & txtDescMHPurDate2.Text.Replace("/", "").Substring(0, 2) & "/" & txtDescMHPurDate2.Text.Replace("/", "").Substring(2, 2) & "/" & txtDescMHPurDate2.Text.Replace("/", "").Substring(4, 4) & "',"
            ElseIf txtDescMHPurDate2.Text.Length = 10 Then
                tsql += " '" & txtDescMHPurDate2.Text & "',"
            Else


                tsql += "'',"
            End If
            'tsql += " '" & txtDescMHPurDate2.Text & "',"
            tsql += " '" & txtDescMHPurPrice2.Text & "',"
            tsql += " '" & txtDescMHCurDate2.Text & "',"
            tsql += " '" & txtDescMHAttStruc.Text.Replace("'", "''") & "',"
            tsql += " '" & txtDescMHAttStrucAge.Text & "',"
            tsql += " '" & txtDescMHAttStrucSize.Text & "',"
            tsql += " '" & txtDescMHAttStrucCurVal2.Text & "',"
            tsql += " '" & txtDescMHUnAttStruc.Text & "',"
            tsql += " '" & txtDescMHUnAttStrucAge.Text & "',"
            tsql += " '" & txtDescMHUnAttStrucSize.Text & "',"
            tsql += " '" & txtDescMHUnAttStrucCurVal2.Text & "',"
            tsql += " '" & ddUsage.SelectedItem.Text & "',"
            tsql += " '" & ddMHAge.SelectedItem.Text & "',"
            tsql += " '" & ddlossHist.SelectedItem.Text & "',"
            tsql += " '" & ddParkStatus.SelectedItem.Text & "',"
            ' tsql += " '" & ddSupHeating.SelectedValue & "',"
            tsql += " '" & txtLien1Name.Text.Replace("'", "''") & "',"
            tsql += " '" & txtLien1Num.Text.Replace("'", "''") & "',"
            tsql += " '" & txtLien1Addr.Text.Replace("'", "''") & "',"
            tsql += " '" & txtLien1City.Text & "',"
            tsql += " '" & txtLien1State.Text & "',"
            tsql += " '" & txtLien1Zip.Text & "',"
            tsql += " '" & txtLien2Name.Text & "',"
            tsql += " '" & txtLien2Num.Text & "',"
            tsql += " '" & txtLien2Addr.Text & "',"
            tsql += " '" & txtLien2City.Text & "',"
            tsql += " '" & txtLien2State.Text & "',"
            tsql += " '" & txtLien2Zip.Text & "',"
            tsql += " '" & ddPriorInsurance.SelectedItem.Text & "',"
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
            tsql += " '" & dd_ARIng1.SelectedItem.Text & "',"
            tsql += " '" & dd_ARIng2.SelectedItem.Text & "',"
            tsql += " '" & dd_ARIng3.SelectedItem.Text & "',"
            tsql += " '" & dd_ARIng4.SelectedItem.Text & "',"
            tsql += " '" & dd_ARIng5.SelectedItem.Text & "',"
            tsql += " '" & dd_ARIng6.SelectedItem.Text & "',"
            tsql += " '" & dd_ARIng7.SelectedItem.Text & "',"
            tsql += " '" & dd_ARIng8.SelectedItem.Text & "',"
            tsql += " '" & dd_ARIng9.SelectedItem.Text & "',"
            tsql += " '" & dd_ARIng10.SelectedItem.Text & "',"
            tsql += " '" & dd_ARIng11.SelectedItem.Text & "',"
            tsql += " '" & dd_ARIng12.SelectedItem.Text & "',"

            tsql += " '" & txtParkName.Text & "',"
            tsql += " '" & txtprioryears.Text & "',"
            tsql += " '" & ddPaymentOpt.SelectedValue & "',"
            tsql += " '" & OVreasontxt.Text & "'"


            ds = com.runQueryDS(tsql, "ColonialMHConnectionString")
            updateStatus("Application Saved")
            If txtAppNumber.Text = "NULL" Or txtAppNumber.Text = "" Then
                ds = com.runQueryDS("SELECT TOP 1 ApplicationID FROM tblLloydApplication ORDER BY ApplicationID DESC", "ColonialMHConnectionString")
                If ds.Tables(0).Rows.Count > 0 Then
                    txtAppNumber.Text = ds.Tables(0).Rows(0).Item("ApplicationID").ToString()
                    labelapp.Text = ds.Tables(0).Rows(0).Item("ApplicationID").ToString()
                End If
            End If
        Catch ex As Exception
            errortrap(tsql, "Save Lloyd Application", ex.Message)
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
        validateme()

        ApplyValidationSummarySettings()

        dd_ARIng1.ValidationSettings.RequiredField.IsRequired = True
        dd_ARIng1.ValidationSettings.RequiredField.ErrorText = "Woodburning Stove or Fireplace"
        dd_ARIng1.ValidationSettings.SetFocusOnError = True

        dd_ARIng2.ValidationSettings.RequiredField.IsRequired = True
        dd_ARIng2.ValidationSettings.RequiredField.ErrorText = "Business on Property?"
        dd_ARIng2.ValidationSettings.SetFocusOnError = True

        dd_ARIng3.ValidationSettings.RequiredField.IsRequired = True
        dd_ARIng3.ValidationSettings.RequiredField.ErrorText = "Farming on Property?"
        dd_ARIng3.ValidationSettings.SetFocusOnError = True

        dd_ARIng4.ValidationSettings.RequiredField.IsRequired = True
        dd_ARIng4.ValidationSettings.RequiredField.ErrorText = "Animals on Property?"
        dd_ARIng4.ValidationSettings.SetFocusOnError = True

        dd_ARIng5.ValidationSettings.RequiredField.IsRequired = True
        dd_ARIng5.ValidationSettings.RequiredField.ErrorText = " Swimming Pool on Property?"
        dd_ARIng5.ValidationSettings.SetFocusOnError = True

        dd_ARIng6.ValidationSettings.RequiredField.IsRequired = True
        dd_ARIng6.ValidationSettings.RequiredField.ErrorText = "Repo/Foreclosure in the past 24 months?"
        dd_ARIng6.ValidationSettings.SetFocusOnError = True

        dd_ARIng7.ValidationSettings.RequiredField.IsRequired = True
        dd_ARIng7.ValidationSettings.RequiredField.ErrorText = "Bankruptcy in the past 24 months?"
        dd_ARIng7.ValidationSettings.SetFocusOnError = True

        dd_ARIng8.ValidationSettings.RequiredField.IsRequired = True
        dd_ARIng8.ValidationSettings.RequiredField.ErrorText = "Claims in the past 36 months?"
        dd_ARIng8.ValidationSettings.SetFocusOnError = True

        dd_ARIng9.ValidationSettings.RequiredField.IsRequired = True
        dd_ARIng9.ValidationSettings.RequiredField.ErrorText = "Unrepaired Damage?"
        dd_ARIng9.ValidationSettings.SetFocusOnError = True

        dd_ARIng10.ValidationSettings.RequiredField.IsRequired = True
        dd_ARIng10.ValidationSettings.RequiredField.ErrorText = "Handrails Installed (3 or more steps)?"
        dd_ARIng10.ValidationSettings.SetFocusOnError = True

        dd_ARIng11.ValidationSettings.RequiredField.IsRequired = True
        dd_ARIng11.ValidationSettings.RequiredField.ErrorText = "Mortgage Payment Currently Past Due?"
        dd_ARIng11.ValidationSettings.SetFocusOnError = True

        dd_ARIng12.ValidationSettings.RequiredField.IsRequired = True
        dd_ARIng12.ValidationSettings.RequiredField.ErrorText = "Kerosene Heater?"
        dd_ARIng12.ValidationSettings.SetFocusOnError = True

        ddPriorInsurance.ValidationSettings.RequiredField.IsRequired = True
        ddPriorInsurance.ValidationSettings.RequiredField.ErrorText = "Prior Insurance Must be Answered"
        ddPriorInsurance.ValidationSettings.SetFocusOnError = True

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
        'ASPxPopupControl1.ShowOnPageLoad = False
        'ASPxPopupControl1.Enabled = False

        If Request.QueryString("ApplicationID") <> "" Or Session("beenSaved") = "True" Then
            save()
        Else 'New Quote
            save()
        End If
        Dim printme As Boolean = True
      
        If txtSSN2.IsValid.ToString = "True" And txtPhone2.IsValid.ToString = "True" And txtOcc.IsValid.ToString = "True" And txtSSN2.IsValid.ToString = "True" And txtAgentName.IsValid.ToString = "True" And txtDiffAppAddr.IsValid.ToString = "True" And txtDiffAppState.IsValid.ToString = "True" And ddUsage.IsValid.ToString = "True" And ddMHAge.IsValid.ToString = "True" _
            And ddlossHist.IsValid.ToString = "True" And ddParkStatus.IsValid.ToString = "True" _
            And ddUnitType.IsValid.ToString = "True" _
            And ddUnitType.IsValid.ToString = "True" _
            And dd_ARIng1.IsValid.ToString = "True" _
            And dd_ARIng2.IsValid.ToString = "True" _
            And dd_ARIng3.IsValid.ToString = "True" _
            And dd_ARIng4.IsValid.ToString = "True" _
            And dd_ARIng5.IsValid.ToString = "True" _
                And dd_ARIng6.IsValid.ToString = "True" _
                 And dd_ARIng7.IsValid.ToString = "True" _
                  And dd_ARIng8.IsValid.ToString = "True" _
                  And dd_ARIng9.IsValid.ToString = "True" _
                    And dd_ARIng10.IsValid.ToString = "True" _
                     And dd_ARIng11.IsValid.ToString = "True" _
                     And dd_ARIng12.IsValid.ToString = "True" _
                     And txtAddress.IsValid.ToString = "True" Then
            printme = True
        Else
            printme = False
        End If


        If printme = False Then

        ElseIf AppStatuslbl.Text = "INELIGIBLE" Then
            ASPxPopupControl1.Enabled = True
            'Label173.Text = UWstr
            printBtn.Visible = False
            ASPxPopupControl1.PopupElementID = "printBtn"
            ASPxPopupControl1.ShowOnPageLoad = True
        ElseIf AppStatuslbl.Text = "Submit to UW" Then
            ASPxPopupControl1.Enabled = True
            'Label173.Text = UWstr
            printBtn.Visible = False
            ASPxPopupControl1.PopupElementID = "printBtn"
            ASPxPopupControl1.ShowOnPageLoad = True
            AppStatuslbl.Text = "Submit to UW – Contact The Colonial Group at 1-800-628-3762."
            AppStatuslbl.ForeColor = Drawing.Color.Blue
            If mySession.CurrentUser.UWUser.ToString() = "True" Then
                overridebtn.Visible = True
            Else
                overridebtn.Visible = False
            End If

        Else

            If txtAppNumber.Text <> "" Then
                Common.AjaxOpenWindow(Me.Page, "ApplicationPrintLloyd.aspx?AppID=" & txtAppNumber.Text, Nothing)

            Else
                Try
                    Dim ds As System.Data.DataSet


                    If txtAppNumber.Text = "NULL" Or txtAppNumber.Text = "" Then
                        ds = com.runQueryDS("SELECT TOP 1 ApplicationID FROM tblLloydApplication where quoteid = " & txtQuoteID.Text & " ORDER BY ApplicationID DESC", "ColonialMHConnectionString")
                        If ds.Tables(0).Rows.Count > 0 Then
                            txtAppNumber.Text = ds.Tables(0).Rows(0).Item("ApplicationID").ToString()
                            labelapp.Text = ds.Tables(0).Rows(0).Item("ApplicationID").ToString()
                            Common.AjaxOpenWindow(Me.Page, "ApplicationPrintLloyd.aspx?AppID=" & ds.Tables(0).Rows(0).Item("ApplicationID").ToString(), Nothing)
                        End If
                    End If
                Catch ex As Exception
                    errortrap("Print Application", "Application ID " & txtAppNumber.Text, ex.Message)
                End Try

            End If

        End If


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
            errortrap("Zip Error", "Load Zip", ex.Message)
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
            errortrap("Zip2 Error", "Load Zip", ex.Message)
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
    Private Sub errortrap(ByVal sqlcomm As String, ByVal appsub As String, ByVal errormsg As String)
        Dim intRowsAff As Integer
        Dim Connection As String = System.Configuration.ConfigurationManager.ConnectionStrings("ColonialMHConnectionString").ConnectionString
        Dim dbConnection As System.Data.IDbConnection = New System.Data.SqlClient.SqlConnection(Connection)
        Dim cmd As New SqlCommand("sp_InsertError", dbConnection)
        cmd.CommandType = CommandType.StoredProcedure
        cmd.Parameters.Add("@code", SqlDbType.VarChar, 8000).Value = sqlcomm
        cmd.Parameters.Add("@Page", SqlDbType.VarChar, 50).Value = "Lloyd Application"
        cmd.Parameters.Add("@sub", SqlDbType.VarChar, 50).Value = appsub
        cmd.Parameters.Add("@msg", SqlDbType.VarChar, 8000).Value = errormsg
        Try
            cmd.Connection.Open()
            intRowsAff = cmd.ExecuteNonQuery()
        Catch ex As Exception

        End Try


    End Sub
    Private Sub ApplyValidationSummarySettings()
        vsValidationSummary1.RenderMode = ValidationSummaryRenderMode.BulletedList
        vsValidationSummary1.ShowErrorAsLink = True
    End Sub

    Protected Sub btnvalidate_Click(sender As Object, e As EventArgs) Handles btnvalidate.Click
        Dim UWstr As String
        Dim val As String

        val = "ELIGIBLE"
        UWstr = "<table> <tbody>"
        If ddPriorInsurance.SelectedItem.Text = "No" Then
            UWstr += "<tr align=left><td>Submit to UW</td><td>Prior Insurance is No</td></tr> "
            If val = "ELIGIBLE" Then
                val = "Submit to UW"
            End If

        End If
        If dd_ARIng1.SelectedItem.Text = "Yes" Then
            UWstr += "<tr align=left><td>Submit to UW</td><td>Wood Stove FirePlace</td></tr> "

            If val = "ELIGIBLE" Then
                val = "Submit to UW"
            End If
        End If
        If dd_ARIng2.SelectedItem.Text = "Yes" Then
            UWstr += "<tr align=left><td>INELIGIBLE</td><td>Business on Property</td></tr> "

            val = "INELIGIBLE"
        End If
        If dd_ARIng3.SelectedItem.Text = "Yes" Then
            UWstr += "<tr align=left><td>INELIGIBLE</td><td>Farming on Property</td></tr> "
            val = "INELIGIBLE"

        End If

        'If dd_ARIng4.SelectedItem.Text = "Yes" Then
        '    UWstr += "<tr align=left><td>INELIGIBLE</td><td>Animals on Property</td></tr> "
        '    val = "INELIGIBLE"

        'End If
        'If dd_ARIng5.SelectedItem.Text = "Yes" Then
        '    UWstr += "<tr align=left><td>INELIGIBLE</td><td>Swimming Pool on Property</td></tr> "

        '    val = "INELIGIBLE"
        'End If
        If dd_ARIng6.SelectedItem.Text = "Yes" Then
            UWstr += "<tr align=left><td>INELIGIBLE</td><td>Repo/Foreclosure in the past 24 months</td></tr> "

            val = "INELIGIBLE"
        End If
        If dd_ARIng7.SelectedItem.Text = "Yes" Then
            UWstr += "<tr align=left><td>INELIGIBLE</td><td> Bankruptcy in the past 24 months</td></tr> "
            val = "INELIGIBLE"
        End If
        If dd_ARIng8.SelectedItem.Text = "Yes" Then
            UWstr += "<tr align=left><td>Submit to UW</td><td>Claims in the past 36 months</td></tr> "

            If val = "ELIGIBLE" Then
                val = "Submit to UW"
            End If
        End If
        If dd_ARIng9.SelectedItem.Text = "Yes" Then
            UWstr += "<tr align=left><td>INELIGIBLE</td><td>Unrepaired Damage</td></tr> "
            val = "INELIGIBLE"

        End If
        If dd_ARIng10.SelectedItem.Text = "No" Then
            UWstr += "<tr align=left><td>INELIGIBLE</td><td>Handrails Installed (3 or more steps)</td></tr> "

            val = "INELIGIBLE"
        End If
        If dd_ARIng11.SelectedItem.Text = "Yes" Then
            UWstr += "<tr align=left><td>INELIGIBLE</td><td>Mortgage Payment Currently Past Due</td></tr> "
            val = "INELIGIBLE"
        End If
        If dd_ARIng12.SelectedItem.Text = "Yes" Then
            UWstr += "<tr align=left><td>INELIGIBLE</td><td> Kerosene Heater</td></tr> "

            val = "INELIGIBLE"
        End If
        UWstr += "</table> </tbody>"
        AppStatuslbl.Text = val
        If val = "ELIGIBLE" Then
            overridebtn.Visible = False
            AppStatuslbl.ForeColor = Drawing.Color.Green
            printBtn.Visible = True
        End If
        If val = "INELIGIBLE" Then
            overridebtn.Visible = False
            AppStatuslbl.ForeColor = Drawing.Color.Red
            printBtn.Visible = False
        End If
        If val = "Submit to UW" Then
            AppStatuslbl.ForeColor = Drawing.Color.Blue
            printBtn.Visible = False
        End If
        Label173.Text = UWstr

        validateme()
        Dim cbfocus As String
        cbfocus = lblfocus.Value

        If cbfocus = "dd_ARIng1" Then
            dd_ARIng1.Focus()
        End If
        If cbfocus = "dd_ARIng2" Then
            dd_ARIng2.Focus()
        End If
        If cbfocus = "dd_ARIng3" Then
            dd_ARIng3.Focus()
        End If
        If cbfocus = "dd_ARIng24" Then
            dd_ARIng4.Focus()
        End If
        If cbfocus = "dd_ARIng5" Then
            dd_ARIng5.Focus()
        End If
        If cbfocus = "dd_ARIng6" Then
            dd_ARIng6.Focus()
        End If
        If cbfocus = "dd_ARIng7" Then
            dd_ARIng7.Focus()
        End If
        If cbfocus = "dd_ARIng8" Then
            dd_ARIng8.Focus()
        End If
        If cbfocus = "dd_ARIng9" Then
            dd_ARIng9.Focus()
        End If
        If cbfocus = "dd_ARIng10" Then
            dd_ARIng10.Focus()
        End If
        If cbfocus = "dd_ARIng11" Then
            dd_ARIng11.Focus()
        End If
        If cbfocus = "dd_ARIng12" Then
            dd_ARIng12.Focus()
        End If
    End Sub
    Protected Sub validateme()
        Dim UWstr As String
        Dim val As String

        Val = "ELIGIBLE"
        UWstr = "<table> <tbody>"


        If lbllapse.Text = "Yes" Then
            UWstr += "<tr align=left><td>Submit to UW</td><td>Lapse in Coverage is true</td></tr> "
            If val = "ELIGIBLE" Then
                val = "Submit to UW"
            End If

        End If

        If ddPriorInsurance.SelectedItem.Text = "No" Then
            UWstr += "<tr align=left><td>Submit to UW</td><td>Prior Insurance is No</td></tr> "
            If val = "ELIGIBLE" Then
                val = "Submit to UW"
            End If

        End If
        If dd_ARIng1.SelectedItem.Text = "Yes" Then
            UWstr += "<tr align=left><td>Submit to UW</td><td>Wood Stove FirePlace</td></tr> "

            If val = "ELIGIBLE" Then
                val = "Submit to UW"
            End If
        End If
        If dd_ARIng2.SelectedItem.Text = "Yes" Then
            UWstr += "<tr align=left><td>INELIGIBLE</td><td>Business on Property</td></tr> "

            Val = "INELIGIBLE"
        End If
        If dd_ARIng3.SelectedItem.Text = "Yes" Then
            UWstr += "<tr align=left><td>INELIGIBLE</td><td>Farming on Property</td></tr> "
            Val = "INELIGIBLE"

        End If

        'If dd_ARIng4.SelectedItem.Text = "Yes" Then
        '    UWstr += "<tr align=left><td>INELIGIBLE</td><td>Animals on Property</td></tr> "
        '    val = "INELIGIBLE"

        'End If
        'If dd_ARIng5.SelectedItem.Text = "Yes" Then
        '    UWstr += "<tr align=left><td>INELIGIBLE</td><td>Swimming Pool on Property</td></tr> "

        '    val = "INELIGIBLE"
        'End If
        If dd_ARIng6.SelectedItem.Text = "Yes" Then
            UWstr += "<tr align=left><td>INELIGIBLE</td><td>Repo/Foreclosure in the past 24 months</td></tr> "

            Val = "INELIGIBLE"
        End If
        If dd_ARIng7.SelectedItem.Text = "Yes" Then
            UWstr += "<tr align=left><td>INELIGIBLE</td><td> Bankruptcy in the past 24 months</td></tr> "
            Val = "INELIGIBLE"
        End If
        If dd_ARIng8.SelectedItem.Text = "Yes" Then
            UWstr += "<tr align=left><td>Submit to UW</td><td>Claims in the past 36 months</td></tr> "

            If val = "ELIGIBLE" Then
                val = "Submit to UW"
            End If
        End If
        If dd_ARIng9.SelectedItem.Text = "Yes" Then
            UWstr += "<tr align=left><td>INELIGIBLE</td><td>Unrepaired Damage</td></tr> "
            Val = "INELIGIBLE"

        End If
        If dd_ARIng10.SelectedItem.Text = "No" Then
            UWstr += "<tr align=left><td>INELIGIBLE</td><td>Handrails Installed (3 or more steps)</td></tr> "

            Val = "INELIGIBLE"
        End If
        If dd_ARIng11.SelectedItem.Text = "Yes" Then
            UWstr += "<tr align=left><td>INELIGIBLE</td><td>Mortgage Payment Currently Past Due</td></tr> "
            Val = "INELIGIBLE"
        End If
        If dd_ARIng12.SelectedItem.Text = "Yes" Then
            UWstr += "<tr align=left><td>INELIGIBLE</td><td> Kerosene Heater</td></tr> "

            Val = "INELIGIBLE"
        End If
        UWstr += "</table> </tbody>"
        AppStatuslbl.Text = val
        If val = "ELIGIBLE" Then
            overridebtn.Visible = False
            AppStatuslbl.ForeColor = Drawing.Color.Green
            printBtn.Visible = True
        End If
        If val = "INELIGIBLE" Then
            overridebtn.Visible = False
            AppStatuslbl.ForeColor = Drawing.Color.Red
        End If
        If val = "Submit to UW" Then
            printBtn.Visible = False
            AppStatuslbl.Text = "Submit to UW – Contact The Colonial Group at 1-800-628-3762."
            AppStatuslbl.ForeColor = Drawing.Color.Blue
            If mySession.CurrentUser.UWUser.ToString() = "True" Then
                overridebtn.Visible = True
            Else
                overridebtn.Visible = False
            End If
        End If
        Label173.Text = UWstr
    End Sub

    Protected Sub btnprior_Click(sender As Object, e As EventArgs) Handles btnprior.Click
        If ddPriorInsurance.SelectedItem.Text = "Yes" Then
            priorInsurance.Style.Item("display") = ""
            txtPriorCompany.Focus()

        ElseIf ddPriorInsurance.SelectedItem.Text = "No" Then
            priorInsurance.Style.Item("display") = "none"
            AppStatuslbl.Text = "Submit to UW – Contact The Colonial Group at 1-800-628-3762."
            AppStatuslbl.ForeColor = Drawing.Color.Blue
            printBtn.Visible = False
            If mySession.CurrentUser.UWUser.ToString() = "True" Then
                overridebtn.Visible = True
            Else
                overridebtn.Visible = False
            End If
        Else
            priorInsurance.Style.Item("display") = "none"
        End If
        Dim val As String = AppStatuslbl.Text
        If val = "ELIGIBLE" Then
            AppStatuslbl.ForeColor = Drawing.Color.Green
            printBtn.Visible = True
        End If
        If val = "INELIGIBLE" Then
            AppStatuslbl.ForeColor = Drawing.Color.Red
        End If
        If val = "Submit to UW" Then
            AppStatuslbl.Text = "Submit to UW – Contact The Colonial Group at 1-800-628-3762."
            AppStatuslbl.ForeColor = Drawing.Color.Blue
            printBtn.Visible = False
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
    Protected Sub financebtn2_Click(ByVal sender As Object, ByVal e As EventArgs) Handles financebtn2.Click
        Dim downPayment, Length, quoteID, state As String
        state = txtState.Text.ToUpper
        If state Is Nothing Or state = "" Then
            state = txtDiffAppState.Text.ToUpper
        End If
        quoteID = txtQuoteID.Text.ToString
        downPayment = DownPaymentPercentRB.SelectedValue.ToString
        Length = FinanceLengthRB.SelectedValue.ToString
        'Or state <> "SC"
        If downPayment = "" Or Length = "" Or state = "TN" Or state = "GA" Or lblProgram.Text.ToUpper.Contains("AEG") Then
            ddPaymentOpt.SelectedValue = ""
            Exit Sub
        End If
        If downPayment = "25% Down" Then
            downPayment = "25"
        ElseIf downPayment = "40% Down" Then
            downPayment = "40"
        ElseIf downPayment = "50% Down" Then
            downPayment = "50"
        End If

        If Length = "3 Months" Then
            Length = "3"
        ElseIf Length = "6 Months" Then
            Length = "6"
        ElseIf Length = "8 Months" Then
            Length = "8"
        End If

        Dim ds As System.Data.DataSet
        ds = com.runQueryDS("EXEC sp_GetLloydsFinanceData '" & quoteID & "','" & downPayment & "','" & Length & "'", "ColonialMHConnectionString")
        If ds.Tables(0).Rows.Count > 0 Then
            Dim wrk1 As Decimal = CDbl(ds.Tables(0).Rows(0).Item("MonthlyPayments")) / CDbl(ds.Tables(0).Rows(0).Item("AmountFinanced"))
            Dim wrk2 As Decimal = wrk1
            Dim APR As Decimal = GetAPR(wrk1, wrk2, Length)
            lblAnnualPremiumLLOYD.Text = FormatCurrency(ds.Tables(0).Rows(0).Item("PremTotal"))
            lblDownPaymentLLOYD.Text = FormatCurrency(ds.Tables(0).Rows(0).Item("DownPayment"))
            lblAmountFinancedLLOYD.Text = FormatCurrency(ds.Tables(0).Rows(0).Item("AmountFinanced"))
            lblFinanceChargeLLOYD.Text = FormatCurrency(ds.Tables(0).Rows(0).Item("FinanceCharge"))
            lblTotalOfPayments.Text = FormatCurrency(ds.Tables(0).Rows(0).Item("TotalOfPayments"))
            lblMonthlyPayment.Text = FormatCurrency(ds.Tables(0).Rows(0).Item("MonthlyPayments"))
            lblAnnualRate.Text = CStr(APR) + "%"
        End If


        'financelbl.Text = "<script language='javascript'> alert('hello'); " & "<" & "/script>"

        updateFinancePanel1.Update()


    End Sub
    Protected Sub PrimeRateFinanceBtn_Click(ByVal sender As Object, ByVal e As EventArgs) Handles PrimeRateFinanceBtn.Click
        Dim fin As New Finance
        Dim DetailString As String
        Dim FinanceCalculated As Boolean
        FinanceCalculated = fin.CalcFinancing(txtQuoteID.Text, PrimeRateDP.SelectedValue.ToString)
        If FinanceCalculated Then
            Dim ds As System.Data.DataSet
            ds = com.runQueryDS("SELECT * FROM dbo.vwFinancingInfo WHERE quoteID = '" & Request.QueryString("quoteID") & "' ", "ColonialMHConnectionString")
            If ds.Tables(0).Rows.Count > 0 Then ' Show current Contract.

                DetailString = "<b> Finance Charge <b> &nbsp; " & FormatCurrency(CDec(ds.Tables(0).Rows(0).Item("APR").ToString)) & "<br/>"
                DetailString += "<b> Down Payment Amount <b> &nbsp; " & FormatCurrency(ds.Tables(0).Rows(0).Item("downPayment").ToString) & "<br/>"
                DetailString += "<b> Payment <b> &nbsp; " & ds.Tables(0).Rows(0).Item("Payment").ToString & "<br/>"
                DetailString += "<b> Number 0f Payments <b> &nbsp; " & ds.Tables(0).Rows(0).Item("NumberOfPayments").ToString & "<br/>"

            Else
                'Finance No Calculated
                DetailString = "There was an issue contacting Prime Rate. Please try again later."
            End If

            PrimeRateFinanceInfo.Text = DetailString
            PrimeRateUpdatePanel.Update()

        End If
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
    Sub calcSCFinancing()
        Dim downPayment, Length, quoteID, state As String
        state = txtState.Text.ToUpper
        If state <> "" Then
            state = txtDiffAppState.Text.ToUpper
        End If
        quoteID = txtQuoteID.Text.ToString
        downPayment = DownPaymentPercentRB.SelectedValue.ToString
        Length = FinanceLengthRB.SelectedValue.ToString

        If downPayment = "" Or Length = "" Or state <> "SC" Then
            Exit Sub
        End If
        If downPayment = "25% Down" Then
            downPayment = "25"
        ElseIf downPayment = "40% Down" Then
            downPayment = "40"
        ElseIf downPayment = "50% Down" Then
            downPayment = "50"
        End If

        If Length = "3 Months" Then
            Length = "3"
        ElseIf Length = "6 Months" Then
            Length = "6"
        ElseIf Length = "8 Months" Then
            Length = "8"
        End If

        Dim ds As System.Data.DataSet
        ds = com.runQueryDS("EXEC sp_GetLloydsFinanceData '" & quoteID & "','" & downPayment & "','" & Length & "'", "ColonialMHConnectionString")
        If ds.Tables(0).Rows.Count > 0 Then
            Dim wrk1 As Decimal = CDbl(ds.Tables(0).Rows(0).Item("MonthlyPayments")) / CDbl(ds.Tables(0).Rows(0).Item("AmountFinanced"))
            Dim wrk2 As Decimal = wrk1
            Dim APR As Decimal = GetAPR(wrk1, wrk2, Length)
            lblAnnualPremiumLLOYD.Text = FormatCurrency(ds.Tables(0).Rows(0).Item("PremTotal"))
            lblDownPaymentLLOYD.Text = FormatCurrency(ds.Tables(0).Rows(0).Item("DownPayment"))
            lblAmountFinancedLLOYD.Text = FormatCurrency(ds.Tables(0).Rows(0).Item("AmountFinanced"))
            lblFinanceChargeLLOYD.Text = FormatCurrency(ds.Tables(0).Rows(0).Item("FinanceCharge"))
            lblTotalOfPayments.Text = FormatCurrency(ds.Tables(0).Rows(0).Item("TotalOfPayments"))
            lblMonthlyPayment.Text = FormatCurrency(ds.Tables(0).Rows(0).Item("MonthlyPayments"))
            lblAnnualRate.Text = CStr(APR) + "%"
        End If


        'financelbl.Text = "<script language='javascript'> alert('hello'); " & "<" & "/script>"

        updateFinancePanel1.Update()


    End Sub
    Protected Sub OVprint_Click(sender As Object, e As EventArgs) Handles OVprint.Click
        If OVreasontxt.Text.Length > 5 Then
            'Save OverRide Reason:
            save()


            If txtAppNumber.Text <> "" Then
                Common.AjaxOpenWindow(Me.Page, "ApplicationPrintLloyd.aspx?AppID=" & txtAppNumber.Text, Nothing)

            Else
                Try
                    Dim ds As System.Data.DataSet


                    If txtAppNumber.Text = "NULL" Or txtAppNumber.Text = "" Then
                        ds = com.runQueryDS("SELECT TOP 1 ApplicationID FROM tblLloydApplication where quoteid = " & txtQuoteID.Text & " ORDER BY ApplicationID DESC", "ColonialMHConnectionString")
                        If ds.Tables(0).Rows.Count > 0 Then
                            txtAppNumber.Text = ds.Tables(0).Rows(0).Item("ApplicationID").ToString()
                            labelapp.Text = ds.Tables(0).Rows(0).Item("ApplicationID").ToString()
                            Common.AjaxOpenWindow(Me.Page, "ApplicationPrintLloyd.aspx?AppID=" & txtAppNumber.Text, Nothing)
                        End If
                    End If
                Catch ex As Exception
                    errortrap("Print Application", "Application ID " & txtAppNumber.Text, ex.Message)
                End Try

            End If
            ASPxPopupControl2.ShowOnPageLoad = False

        End If
    End Sub

    Protected Sub ddMHAge_SelectedIndexChanged(sender As Object, e As EventArgs) Handles ddMHAge.SelectedIndexChanged

    End Sub
End Class