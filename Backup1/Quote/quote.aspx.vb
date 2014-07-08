﻿Imports System.Data.SqlClient
Imports System.IO
Imports DevExpress.Web.ASPxGridView
Imports TallComponents.PDF.JavaScript
Imports TallComponents.PDF.Annotations.Widgets
Imports TallComponents.PDF.Forms.Fields
Imports DevExpress.Web.ASPxPopupControl

Public Class quote
    Inherits System.Web.UI.Page
    Dim startup As Boolean = True
    Dim GLOBALCREDITPERCENTAGE As Double = 0.065
    Dim PackPrem As String
    Dim StandPrem As String
    Dim RentPrem As String
    Dim CreditPerc As String
    Dim Packsub1 As String
    Dim Standsub1 As String
    Dim Rentsub1 As String
    Dim PackNonHur As String
    Dim PackHur As String
    Dim StandNonHur As String
    Dim StandHur As String
    Dim RentNonHur As String
    Dim RentHur As String
    Dim PackOption As String
    Dim StandOpt As String
    Dim RentOpt As String
    Private dsar1 As DataSet = Nothing
    Private dsar2 As DataSet = Nothing
    Private totperpropar1 As Decimal = Nothing
    Private totperpropar2 As Decimal = Nothing



    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        If lblState.Text <> "FL" Then
            'Label166.Visible = False
            'ddansi.Visible = False
            'ddansi.Enabled = False
            Label166.Style.Item("display") = "none"
            ddansi.Style.Item("display") = "none"
        Else
            Label166.Style.Item("display") = ""
            ddansi.Style.Item("display") = ""
            'Label166.Visible = True
            'ddansi.Visible = True
            'ddansi.Enabled = True
            'transi.Style.Item("display") = ""
        End If
        If Not IsPostBack Then
            Try
                Response.Cache.SetCacheability(System.Web.HttpCacheability.NoCache)
                'Reset Form

                Dim test As String = mySession.CurrentUser.AgencyName.ToString()
                lblAgency.Text = test

                If mySession.CurrentUser.UWUser.ToString() = "True" Then
                    quotenote.Visible = True
                Else
                    quotenote.Visible = False
                End If
            Catch ex As Exception
                mySession.Clear()
                Server.Transfer("~/Login.aspx")
            End Try
          
            setAutoFill()

            Lloyds1.Visible = False
            ARFLtbl.Visible = False

            txtEffDate.Text = DateTime.Now.ToString("MM/dd/yyyy")
            txtZip.Text = ""
            cddlCity.Items.Clear()
            lblState.Text = ""
            txtCounty.Text = ""
            ' txtCounty.Attributes.Add("onChange", "return ValidateState();")
            txtZip.Attributes.Add("onKeyUp", "return zipcodeKeyDown();")
            txtSubNumber.Attributes.Add("onKeyUp", "return subKeyDown();")
            distToCoastDD.Attributes.Add("onChange", "return OndistToCoastDDSelectedIndexChange();")
            LlyodsLiabdd.Attributes.Add("onChange", "return OnLlyodsLiabddSelectedIndexChange();")
            LlyodsPremLiabdd.Attributes.Add("onChange", "return OnLlyodsPremLiabddSelectedIndexChange();")
            'txtDOB1.Attributes.Add("onKeyPress", "return UpdateDOB();")
            manfdd.Attributes.Add("onChange", "return calcValuation();")
            lblState.Attributes.Add("onChange", "return calcValuation();")
            txtWidth.Attributes.Add("onChange", "return calcValuation();")
            txtLength.Attributes.Add("onChange", "return calcValuation();")
            txtYear.Attributes.Add("onKeyUp", "return MHValidate();")
            txtYear.Attributes.Add("onChange", "return calcValuation();")
            homeusedd.Attributes.Add("onChange", "return OnhomeUseDDSelectedIndexChange();")
            ddlSub_main.Attributes.Add("onChange", "return OnddlSub_mainSelectedIndexChange();")
            txtAAS.Attributes.Add("onChange", "return calcLloydsAAS();")
            txtAPE.Attributes.Add("onChange", "return calcLloydsAPE();")
            mhparkdd.Attributes.Add("onChange", "return ARHideShowQuestions();")
            liendd.Attributes.Add("onChange", "return ARIsLienHolder();")
            supheatdd.Attributes.Add("onChange", "return ARsupHeating();")
            priorlosdd.Attributes.Add("onChange", "return ShowPriorLossbtn();")
            txtLoss1Date.Attributes.Add("onKeyPress", "return UpdatePL1();")
            txtLoss2Date.Attributes.Add("onKeyPress", "return UpdatePL2();")
            txtLoss3Date.Attributes.Add("onKeyPress", "return UpdatePL3();")
            skirtdd.Attributes.Add("onChange", "return ARSkirting();")
            txtEffDate.Attributes.Add("onChange", "return Datecheck();")

            dd_pl_AR1.Attributes.Add("onChange", "return AutoCalc();")

            '*********************************
            If (Not IsPostBack) AndAlso (Not IsCallback) Then
                dsar1 = New DataSet()
                totperpropar1 = New Decimal
                Dim detailTable As DataTable = New DataTable()
                detailTable.Columns.Add("ID", GetType(Integer))
                detailTable.Columns.Add("description", GetType(String))
                detailTable.Columns.Add("value", GetType(Decimal))
                detailTable.PrimaryKey = New DataColumn() {detailTable.Columns("ID")}
                Dim index As Integer = 0
                'For i As Integer = 0 To 19
                '    masterTable.Rows.Add(New Object() {i, "Master Row " & i.ToString()})
                '    For j As Integer = 0 To 4
                '        detailTable.Rows.Add(New Object() {index, i, "Detail Row " & j.ToString()})
                '        index += 1
                '    Next j
                'Next i
                dsar1.Tables.AddRange(New DataTable() {detailTable})
                Session("DataSet") = dsar1
                Session("PerPropAR1") = totperpropar1
                dsar2 = New DataSet()
                totperpropar2 = New Decimal
                Dim detailTable2 As DataTable = New DataTable()
                detailTable2.Columns.Add("ID", GetType(Integer))
                detailTable2.Columns.Add("description", GetType(String))
                detailTable2.Columns.Add("value", GetType(Decimal))
                detailTable2.PrimaryKey = New DataColumn() {detailTable2.Columns("ID")}

                dsar2.Tables.AddRange(New DataTable() {detailTable2})
                Session("DataSet2") = dsar2
                Session("PerPropAR2") = totperpropar2
            Else
                dsar1 = CType(Session("DataSet"), DataSet)
                dsar2 = CType(Session("DataSet"), DataSet)
            End If
            ASPxGridView1.DataSource = dsar1.Tables(0)
            ASPxGridView1.DataBind()
            ASPxGridView2.DataSource = dsar2.Tables(0)
            ASPxGridView2.DataBind()


            '********************************
            'AR Attributes
            AddAROptionsAttributes()
            AR_PremiumUpdatePanel.Update()



            Dim lbl As New Label()
            lbl.Text = "<script language='javascript'> hideDefaults();" & "<" & "/script>"
            Page.Controls.Add(lbl)
            loadManf()
            'Check if quote needs to be loaded
            If Request.QueryString("quoteID") <> "" Then '  quoteID is not empty
                LoadQuote(Request.QueryString("quoteID"))
                ' LoadCalcintoDB(Request.QueryString("quoteID"))
            End If
            If priorlosdd.SelectedValue = "Yes" Then
                modalShowbtn.Attributes.Add("style", "display:inline")

            Else
                modalShowbtn.Attributes.Add("style", "display:none")
            End If
            ASPxPopupControl1.Enabled = False
            ASPxPopupControl1.ShowOnPageLoad = False
            ASPxPopupControl5.Enabled = False
            ASPxPopupControl5.ShowOnPageLoad = False
        Else
            'AR1_Debug.Text = ""
            'AR2_Debug.Text = ""
            'AR3_Debug.Text = ""
        End If


    End Sub
    Public Sub AddAROptionsAttributes()
        'Default Attributes Package
        dd_aop_AR1.Attributes.Add("onChange", "return AR_UpdateOptions();")
        dd_hurded_AR1.Attributes.Add("onChange", "return AR_UpdateOptions();")
        dd_pl_AR1.Attributes.Add("onChange", "return AR_UpdateOptions();")
        dd_mp_AR1.Attributes.Add("onChange", "return AR_UpdateOptions();")
        txt_unattstr_AR1.Attributes.Add("onChange", "return AR_UpdateOptions();")
        txt_pp_AR1.Attributes.Add("onChange", "return AR_UpdateOptions();")
        dd_mhr_AR1.Attributes.Add("onChange", "return AR_UpdateOptions();")
        dd_rep_AR1.Attributes.Add("onChange", "return AR_UpdateOptions();")
        txt_addlimrad_AR1.Attributes.Add("onChange", "return AR_UpdateOptions();")
        txt_addlimfir_AR1.Attributes.Add("onChange", "return AR_UpdateOptions();")
        dd_sip_AR1.Attributes.Add("onChange", "return AR_UpdateOptions();")
        dd_ndp_AR1.Attributes.Add("onChange", "return AR_UpdateOptions();")
        dd_addresOpt_ar1.Attributes.Add("onChange", "return AR_UpdateOptions();")
        dd_addresliab_ar1.Attributes.Add("onChange", "return AR_UpdateOptions();")
        dd_addresMP_ar1.Attributes.Add("onChange", "return AR_UpdateOptions();")


        dd_waterCraftliab_AR1.Attributes.Add("onChange", "return AR_UpdateOptions();")
        dd_waterCraftMedpay_AR1.Attributes.Add("onChange", "return AR_UpdateOptions();")

        dd_waterCraft_AR1.Attributes.Add("onChange", "return AR_UpdateOptions();")

        dd_PackagePerProp_AR1.Attributes.Add("onChange", "return AR_UpdateOptions();")


        'Default Attributes Package
        dd_aop_AR2.Attributes.Add("onChange", "return AR_UpdateOptions();")
        dd_hurded_AR2.Attributes.Add("onChange", "return AR_UpdateOptions();")
        dd_pl_AR2.Attributes.Add("onChange", "return AR_UpdateOptions();")
        dd_mp_AR2.Attributes.Add("onChange", "return AR_UpdateOptions();")
        txt_unattstr_AR2.Attributes.Add("onChange", "return AR_UpdateOptions();")
        txt_pp_AR2.Attributes.Add("onChange", "return AR_UpdateOptions();")
        dd_mhr_AR2.Attributes.Add("onChange", "return AR_UpdateOptions();")
        dd_rep_AR2.Attributes.Add("onChange", "return AR_UpdateOptions();")
        txt_addlimrad_AR2.Attributes.Add("onChange", "return AR_UpdateOptions();")
        txt_addlimfir_AR2.Attributes.Add("onChange", "return AR_UpdateOptions();")
        dd_sip_AR2.Attributes.Add("onChange", "return AR_UpdateOptions();")
        dd_ndp_AR2.Attributes.Add("onChange", "return AR_UpdateOptions();")
        dd_addresOpt_ar2.Attributes.Add("onChange", "return AR_UpdateOptions();")
        dd_addresliab_ar2.Attributes.Add("onChange", "return AR_UpdateOptions();")
        dd_addresMP_ar2.Attributes.Add("onChange", "return AR_UpdateOptions();")
        dd_waterCraft_ar2.Attributes.Add("onChange", "return AR_UpdateOptions();")
        dd_waterCraftliab_ar2.Attributes.Add("onChange", "return AR_UpdateOptions();")
        dd_waterCraftMedpay_ar2.Attributes.Add("onChange", "return AR_UpdateOptions();")
        dd_PackagePerProp_ar2.Attributes.Add("onChange", "return AR_UpdateOptions();")

        'Default Rental Attributes Package
        dd_aop_AR3.Attributes.Add("onChange", "return AR_UpdateOptions();")
        dd_hurded_AR3.Attributes.Add("onChange", "return AR_UpdateOptions();")
        dd_pl_AR3.Attributes.Add("onChange", "return AR_UpdateOptions();")
        dd_mp_AR3.Attributes.Add("onChange", "return AR_UpdateOptions();")
        txt_unattstr_AR3.Attributes.Add("onChange", "return AR_UpdateOptions();")
        txt_pp_AR3.Attributes.Add("onChange", "return AR_UpdateOptions();")
        txt_addlimrad_AR3.Attributes.Add("onChange", "return AR_UpdateOptions();")
        txt_addlimfir_AR3.Attributes.Add("onChange", "return AR_UpdateOptions();")
        dd_sip_AR3.Attributes.Add("onChange", "return AR_UpdateOptions();")
        dd_ndp_AR3.Attributes.Add("onChange", "return AR_UpdateOptions();")
        


        'Other Attributes
        dd_pl_AR2.Attributes.Add("onChange", "return ARShowStandardMedPay();")
        dd_addresOpt_ar1.Attributes.Add("onChange", "return ARShowPackageMedPay();")
        dd_waterCraft_AR1.Attributes.Add("onChange", "return ARShowPackageWaterCraft();")
        dd_addresOpt_ar2.Attributes.Add("onChange", "return ARShowPackageMedPay2();")
        dd_waterCraft_ar2.Attributes.Add("onChange", "return ARShowPackageWaterCraft2();")
    End Sub
    Public Sub btnLogout_Click(ByVal sender As Object, ByVal e As EventArgs)
        mySession.Clear()
        Server.Transfer("~/Login.aspx")

    End Sub
    '****************************************************
    ' Load
    '****************************************************
    Public Sub loadManf()
        Dim ds As System.Data.DataSet
        ds = runQueryDS("SELECT ' ' AS Manfufacturers, ' ' AS perfered UNION SELECT * FROM dbo.[tblManf]", "ColonialMHConnectionString")
        If ds.Tables(0).Rows.Count > 0 Then
            manfdd.DataSource = ds.Tables(0)
            manfdd.DataValueField = "Manfufacturers"
            manfdd.SelectedIndex = 0
            manfdd.DataBind()
        Else
            'no rows.
        End If
    End Sub

    Public Sub LoadQuote(ByVal quoteID As String)
        Dim ds As System.Data.DataSet
        ds = Common.runQueryDS("SELECT * FROM tblQuotes q LEFT JOIN (SELECT DISTINCT AgencyID,AgencyCode,AgencyName,ssad1 AS AgentAddr1, Address2 AS AgentAddr2,City AS AgentCity,State AS AgentState,Zip AS AgentZip, agency.sscnt3 AS AgentPhone,AgentName FROM wrwpaqbx_ColonialWeb.wrwpaqbx_admin.vwAgents as agent left join [wrwpaqbx_ColonialWeb].[wrwpaqbx_admin].[Agency] as agency on agency.sssub = agent.AgencyCode)vwag ON q.agencyName = vwag.AgencyName and q.agentname = vwag.agentname WHERE QuoteID = '" & quoteID & "'")
        If ds.Tables(0).Rows.Count > 0 Then
            termdd.SelectedValue = ds.Tables(0).Rows(0).Item("term").ToString()
            lblAgency.Text = ds.Tables(0).Rows(0).Item("agencyName").ToString()
            txtSubNumber.Text = ds.Tables(0).Rows(0).Item("AgencyCode").ToString()
            txtAgConName.Text = ds.Tables(0).Rows(0).Item("agentName").ToString()
            txtConEmail.Text = ds.Tables(0).Rows(0).Item("agentEmail").ToString()

            txtAppFirstName.Text = ds.Tables(0).Rows(0).Item("applicantFirstName").ToString()
            txtAppLastName.Text = ds.Tables(0).Rows(0).Item("applicantLastName").ToString()
            txtAppEmail.Text = ds.Tables(0).Rows(0).Item("applicantEmail").ToString()
            Dim dbdate As DateTime
            Dim efdate As DateTime
            Try
                If IsDate(ds.Tables(0).Rows(0).Item("applicantDOB").ToString()) Then
                    dbdate = ds.Tables(0).Rows(0).Item("applicantDOB").ToString()
                End If
                If IsDate(ds.Tables(0).Rows(0).Item("effDate").ToString()) Then
                    ' originaldte.Text = efdate
                    efdate = ds.Tables(0).Rows(0).Item("effDate").ToString()
                End If

            Catch ex As Exception

            End Try
            txtEffDate.Text = efdate.ToString("MM/dd/yyyy")
            originaldte.Text = efdate.ToString("MM/dd/yyyy")
            txtDOB1.Text = dbdate.ToString("MM/dd/yyyy")
            txtAppAddr.Text = ds.Tables(0).Rows(0).Item("propAddress").ToString()
            txtZip.Text = ds.Tables(0).Rows(0).Item("zip").ToString()
            'Load Zip Data
            LoadZip(txtZip.Text)
            cddlCity.SelectedValue = ds.Tables(0).Rows(0).Item("city").ToString()
            updateZipPanel.Update()

            lblState.Text = ds.Tables(0).Rows(0).Item("state").ToString()
            If lblState.Text <> "FL" Then
                'Label166.Visible = False
                'ddansi.Visible = False
                'ddansi.Enabled = False
                Label166.Style.Item("display") = "none"
                ddansi.Style.Item("display") = "none"
            Else
                Label166.Style.Item("display") = ""
                ddansi.Style.Item("display") = ""
                'Label166.Visible = True
                'ddansi.Visible = True
                'ddansi.Enabled = True
                'transi.Style.Item("display") = ""
            End If
            txtCounty.Text = ds.Tables(0).Rows(0).Item("county").ToString()
            distToCoastDD.SelectedValue = ds.Tables(0).Rows(0).Item("distToCoast").ToString()
            homeusedd.SelectedValue = ds.Tables(0).Rows(0).Item("homeUse").ToString()
            typedd.SelectedValue = ds.Tables(0).Rows(0).Item("homeType").ToString()
            txtYear.Text = ds.Tables(0).Rows(0).Item("year").ToString()
            If ds.Tables(0).Rows(0).Item("Ansi_Asce").ToString() = "" Then
                If IsNumeric(txtYear.Text) Then
                    If CInt(txtYear.Text) >= 1995 Then
                        ddansi.SelectedValue = "Yes"
                        UpdatePanel2.Update()
                    End If
                End If
            Else
                ddansi.SelectedValue = ds.Tables(0).Rows(0).Item("Ansi_Asce").ToString()
            End If

            txtquotennotes.Text = ds.Tables(0).Rows(0).Item("notes").ToString()

          
            txtLength.Text = ds.Tables(0).Rows(0).Item("length").ToString()
            txtWidth.Text = ds.Tables(0).Rows(0).Item("width").ToString()
            manfdd.SelectedValue = ds.Tables(0).Rows(0).Item("manf").ToString()
            txtValuation.Text = ds.Tables(0).Rows(0).Item("valuation").ToString()
            protclassdd.SelectedValue = ds.Tables(0).Rows(0).Item("protClass").ToString()
            skirtdd.SelectedValue = ds.Tables(0).Rows(0).Item("skirting").ToString()
            liendd.SelectedValue = ds.Tables(0).Rows(0).Item("lienholder").ToString()
            lapsdd.SelectedValue = ds.Tables(0).Rows(0).Item("lapseInCoverage").ToString()
            supheatdd.SelectedValue = ds.Tables(0).Rows(0).Item("suppHeating").ToString()
            priorlosdd.SelectedValue = ds.Tables(0).Rows(0).Item("priorLoss").ToString()
            aopdd.SelectedValue = ds.Tables(0).Rows(0).Item("aopDed").ToString()
            txtcvgamt.Text = ds.Tables(0).Rows(0).Item("coverageAmt").ToString()
            distToCoastDD.SelectedValue = ds.Tables(0).Rows(0).Item("distToCoast").ToString()
            whtxt.Text = ds.Tables(0).Rows(0).Item("windHailDed").ToString()
            lblquoteNumber.Text = ds.Tables(0).Rows(0).Item("quoteID").ToString()
            mhparkdd.SelectedValue = ds.Tables(0).Rows(0).Item("isMHInPark").ToString()
            mhResMangdd.SelectedValue = ds.Tables(0).Rows(0).Item("parkMGR").ToString()
            mhSpacdd.SelectedValue = ds.Tables(0).Rows(0).Item("park100Spaces").ToString()
            mhlightdd.SelectedValue = ds.Tables(0).Rows(0).Item("parklightedStreet").ToString()
            mhInsAge.SelectedValue = ds.Tables(0).Rows(0).Item("insuredParkAgeOcc").ToString()
            rateTypelbl.Text = ds.Tables(0).Rows(0).Item("ARRateType").ToString()
            rateTypelbl.Font.Bold = True
            rateTypelbl.ForeColor = Drawing.Color.Green

            'calcLloyds()
            'LoadLloydsFees()
            'calcLloydsCredits()
            'calcLloydsTotals()

            supHeatTypedd.SelectedValue = ds.Tables(0).Rows(0).Item("suppHeatingType").ToString()
            
            LoadAROptions(quoteID)
            'load personal property

            loadperspropar1(quoteID)
            loadperspropar2(quoteID)



            LoadLoss(quoteID)
            ' LoadZip(txtZip.Text)



            If lblState.Text <> "FL" Then

                If homeusedd.SelectedValue = "Tenant" Or homeusedd.SelectedValue = "Vacant" Then
                    ASPxPopupControl1.HeaderText = "Ineligible"
                    ASPxPopupControl1.Enabled = True
                    Label173.Text = "Ineligible for the following reason(s):  Home use is " & homeusedd.SelectedValue
                    ASPxPopupControl1.PopupElementID = "prmbtn"
                    ASPxPopupControl1.ShowOnPageLoad = True
                    Lloyds1.Visible = False
                    ARFLtbl.Visible = False

                Else
                    If lblState.Text = "SC" Then
                        If CInt(txtValuation.Text) < 150001 Then
                            Lloyds1.LoadLloydsPremiums(quoteID, txtcvgamt.Text, lblState.Text, typedd.SelectedValue, manfdd.SelectedValue, txtYear.Text, txtCounty.Text, homeusedd.SelectedValue, ds.Tables(0).Rows(0).Item("distToCoast").ToString(), protclassdd.SelectedValue, liendd.SelectedValue, supheatdd.SelectedValue, txtDOB1.Text, txtSubNumber.Text, lapsdd.SelectedValue, cddlCity.SelectedValue, txtEffDate.Text, aegisterritorylbl.Text)
                            Lloyds1.Visible = True
                            ARFLtbl.Visible = False
                        Else
                            'need to put a pop up maybe?
                            MessageBox("Ineligible – Maximum Coverage A limit is $150,000")
                        End If
                    Else

                        Lloyds1.LoadLloydsPremiums(quoteID, txtcvgamt.Text, lblState.Text, typedd.SelectedValue, manfdd.SelectedValue, txtYear.Text, txtCounty.Text, homeusedd.SelectedValue, ds.Tables(0).Rows(0).Item("distToCoast").ToString(), protclassdd.SelectedValue, liendd.SelectedValue, supheatdd.SelectedValue, txtDOB1.Text, txtSubNumber.Text, lapsdd.SelectedValue, cddlCity.SelectedValue, txtEffDate.Text, aegisterritorylbl.Text)
                        Lloyds1.Visible = True
                        ARFLtbl.Visible = False
                    End If
                   
                End If

            Else
                calc()
            End If

                'LoadLloydsPremiums(ds.Tables(0).Rows(0).Item("quoteID"))

                distToCoastDD.SelectedValue = ds.Tables(0).Rows(0).Item("distToCoast")

                'If Rate type is already present show print options
                If ds.Tables(0).Rows(0).Item("ARRateType").ToString <> "" Then
                    premiumBtnTable.Attributes.Add("style", "display:block")
                End If

                If ds.Tables(0).Rows(0).Item("ARImportID") = "0" Then
                    printbtn1.Visible = True
                    premFinbtn.Visible = True
                Else
                    printbtn1.Visible = False
                    premFinbtn.Visible = False
                End If

                updateStatus("Quote loaded.")
            Else
                updateStatus("Quote load failed.")
            End If
    End Sub
    Public Sub LoadAROptions(ByVal quoteID As String)
        Dim ds As System.Data.DataSet
        ds = runQueryDS("SELECT * FROM tblARQuotes WHERE QuoteID = '" & quoteID & "'", "ColonialMHConnectionString")
        If ds.Tables(0).Rows.Count > 0 Then
            ar_dwell1.Text() = ds.Tables(0).Rows(0).Item("ARPackageDwelling")
            ar_unattStr1.Text() = ds.Tables(0).Rows(0).Item("ARPackageOthStruc")
            ar_perEff1.Text() = ds.Tables(0).Rows(0).Item("ARPackageContents")
            ar_perLiab1.Text() = ds.Tables(0).Rows(0).Item("ARPackageLiab")
            ar_medpay1.Text() = ds.Tables(0).Rows(0).Item("ARPackageMedPay")
            ar_baseprem1.Text() = ds.Tables(0).Rows(0).Item("ARPackageBasePrem")
            ar_options1.Text() = ds.Tables(0).Rows(0).Item("ARPackageOptions")
            ar_fees1.Text() = ds.Tables(0).Rows(0).Item("ARPackageFees")
            ar_tax1.Text() = ds.Tables(0).Rows(0).Item("ARPackageTax")
            ar_total1.Text() = CInt(ds.Tables(0).Rows(0).Item("ARPackageTotal"))
            dd_aop_AR1.SelectedValue = ds.Tables(0).Rows(0).Item("ARPackageAOPOpt")
            dd_hurded_AR1.SelectedValue = ds.Tables(0).Rows(0).Item("ARPackageHurDedOpt")
            dd_pl_AR1.SelectedValue = ds.Tables(0).Rows(0).Item("ARPackagePerLiabOpt")
            dd_mp_AR1.SelectedValue = ds.Tables(0).Rows(0).Item("ARPackageMedPayOpt")
            txt_unattstr_AR1.Text() = ds.Tables(0).Rows(0).Item("ARPackageOthStrucOpt")
            txt_pp_AR1.Text() = ds.Tables(0).Rows(0).Item("ARPackageContOpt")
            dd_mhr_AR1.SelectedValue = ds.Tables(0).Rows(0).Item("ARPackageMHRepOpt")
            dd_rep_AR1.SelectedValue = ds.Tables(0).Rows(0).Item("ARPackageContRepOpt")
            txt_addlimrad_AR1.Text() = ds.Tables(0).Rows(0).Item("ARPackageAddRadOpt")
            txt_addlimfir_AR1.Text() = ds.Tables(0).Rows(0).Item("ARPackageAddFireOpt")
            dd_sip_AR1.SelectedValue = ds.Tables(0).Rows(0).Item("ARPackageSIPOpt")
            dd_ndp_AR1.SelectedValue = ds.Tables(0).Rows(0).Item("ARPackageNDPOpt")
            dd_addresOpt_ar1.SelectedValue = ds.Tables(0).Rows(0).Item("ARPackageAddResOpt")
            dd_addresliab_ar1.SelectedValue = ds.Tables(0).Rows(0).Item("ARPackageAddResLiabOpt")
            dd_addresMP_ar1.SelectedValue = ds.Tables(0).Rows(0).Item("ARPackageAddResMedOpt")
            dd_waterCraft_AR1.SelectedValue = ds.Tables(0).Rows(0).Item("ARPackageWatOpt")
            dd_waterCraftliab_AR1.SelectedValue = ds.Tables(0).Rows(0).Item("ARPackageWatLiabOpt")
            dd_waterCraftMedpay_AR1.SelectedValue = ds.Tables(0).Rows(0).Item("ARPackageWatMedOpt")
            dd_PackagePerProp_AR1.SelectedValue = ds.Tables(0).Rows(0).Item("ARPackageValOpt")
            ar_dwell2.Text() = ds.Tables(0).Rows(0).Item("ARStandardDwelling")
            ar_unattStr2.Text() = ds.Tables(0).Rows(0).Item("ARStandardOthStruc")
            ar_perEff2.Text() = ds.Tables(0).Rows(0).Item("ARStandardContents")
            ar_perLiab2.Text() = ds.Tables(0).Rows(0).Item("ARStandardLiab")
            ar_medpay2.Text() = ds.Tables(0).Rows(0).Item("ARStandardMedPay")
            ar_baseprem2.Text() = ds.Tables(0).Rows(0).Item("ARStandardBasePrem")
            ar_options2.Text() = ds.Tables(0).Rows(0).Item("ARStandardOptions")
            ar_fees2.Text() = ds.Tables(0).Rows(0).Item("ARStandardFees")
            ar_tax2.Text() = ds.Tables(0).Rows(0).Item("ARStandardTax")
            ar_total2.Text() = ds.Tables(0).Rows(0).Item("ARStandardTotal")
            dd_aop_AR2.SelectedValue = ds.Tables(0).Rows(0).Item("ARStandardAOPOpt")
            dd_hurded_AR2.SelectedValue = ds.Tables(0).Rows(0).Item("ARStandardHurDedOpt")
            dd_pl_AR2.SelectedValue = ds.Tables(0).Rows(0).Item("ARStandardPerLiabOpt")
            dd_mp_AR2.SelectedValue = ds.Tables(0).Rows(0).Item("ARStandardMedPayOpt")
            txt_unattstr_AR2.Text() = ds.Tables(0).Rows(0).Item("ARStandardOthStrucOpt")
            txt_pp_AR2.Text() = ds.Tables(0).Rows(0).Item("ARStandardContOpt")
            dd_mhr_AR2.SelectedValue = ds.Tables(0).Rows(0).Item("ARStandardMHRepOpt")
            dd_rep_AR2.SelectedValue = ds.Tables(0).Rows(0).Item("ARStandardContRepOpt")
            txt_addlimrad_AR2.Text() = ds.Tables(0).Rows(0).Item("ARStandardAddRadOpt")
            txt_addlimfir_AR2.Text() = ds.Tables(0).Rows(0).Item("ARStandardAddFireOpt")
            dd_sip_AR2.SelectedValue = ds.Tables(0).Rows(0).Item("ARStandardSIPOpt")
            dd_ndp_AR2.SelectedValue = ds.Tables(0).Rows(0).Item("ARStandardNDPOpt")
            dd_addresOpt_ar2.SelectedValue = ds.Tables(0).Rows(0).Item("ARStandardAddResOpt")
            dd_addresliab_ar2.SelectedValue = ds.Tables(0).Rows(0).Item("ARStandardAddResLiabOpt")
            dd_addresMP_ar2.SelectedValue = ds.Tables(0).Rows(0).Item("ARStandardAddResMedOpt")
            dd_waterCraft_ar2.SelectedValue = ds.Tables(0).Rows(0).Item("ARStandardWatOpt")
            dd_waterCraftliab_ar2.SelectedValue = ds.Tables(0).Rows(0).Item("ARStandardWatLiabOpt")
            dd_waterCraftMedpay_ar2.SelectedValue = ds.Tables(0).Rows(0).Item("ARStandardWatMedOpt")
            dd_PackagePerProp_ar2.SelectedValue = ds.Tables(0).Rows(0).Item("ARStandardValOpt")
            ar_dwell3.Text() = ds.Tables(0).Rows(0).Item("ARRentalDwelling")
            ar_unattStr3.Text() = ds.Tables(0).Rows(0).Item("ARRentalOthStruc")
            ar_perEff3.Text() = ds.Tables(0).Rows(0).Item("ARRentalContents")
            ar_perLiab3.Text() = ds.Tables(0).Rows(0).Item("ARRentalLiab")
            ar_medpay3.Text() = ds.Tables(0).Rows(0).Item("ARRentalMedPay")
            ar_baseprem3.Text() = ds.Tables(0).Rows(0).Item("ARRentalBasePrem")
            ar_options3.Text() = ds.Tables(0).Rows(0).Item("ARRentalOptions")
            ar_fees3.Text() = ds.Tables(0).Rows(0).Item("ARRentalFees")
            ar_tax3.Text() = ds.Tables(0).Rows(0).Item("ARRentalTax")
            ar_total3.Text() = ds.Tables(0).Rows(0).Item("ARRentalTotal")
            dd_aop_AR3.SelectedValue = ds.Tables(0).Rows(0).Item("ARRentalAOPOpt")
            dd_hurded_AR3.SelectedValue = ds.Tables(0).Rows(0).Item("ARRentalHurDedOpt")
            dd_pl_AR3.SelectedValue = ds.Tables(0).Rows(0).Item("ARRentalPerLiabOpt")
            dd_mp_AR3.SelectedValue = ds.Tables(0).Rows(0).Item("ARRentalMedPayOpt")
            txt_unattstr_AR3.Text() = ds.Tables(0).Rows(0).Item("ARRentalOthStrucOpt")
            txt_pp_AR3.Text() = ds.Tables(0).Rows(0).Item("ARRentalContOpt")
            txt_addlimrad_AR3.Text() = ds.Tables(0).Rows(0).Item("ARRentalAddRadOpt")
            txt_addlimfir_AR3.Text() = ds.Tables(0).Rows(0).Item("ARRentalAddFireOpt")
            dd_sip_AR3.SelectedValue = ds.Tables(0).Rows(0).Item("ARRentalSIPOpt")
            dd_ndp_AR3.SelectedValue = ds.Tables(0).Rows(0).Item("ARRentalNDPOpt")
            ddansi.SelectedValue = ds.Tables(0).Rows(0).Item("Ansi_Asce").ToString()
            dd_PackagePerProp_AR1.SelectedValue = ds.Tables(0).Rows(0).Item("ARPackagePersProp").ToString()
            dd_PackagePerProp_ar2.SelectedValue = ds.Tables(0).Rows(0).Item("ARStandardPersProp").ToString()




        End If

    End Sub
    Public Sub LoadLloydsPremiums(ByVal quoteID As String)


        Dim ds As System.Data.DataSet
        ds = Common.runQueryDS("SELECT TOP 1 * FROM tblLloydsQuotes WHERE QuoteID = '" & quoteID & "'")
        If ds.Tables(0).Rows.Count > 0 Then
            'Load options
            For Each li As ListItem In optcbl.Items
                If li.Value = "PE Replacement Cost" Then
                    li.Selected = ds.Tables(0).Rows(0).Item("peRepCost")
                End If
                If li.Value = "Full Repair" Then
                    li.Selected = ds.Tables(0).Rows(0).Item("fullRep")
                End If
                If li.Value = "MH Replacement Cost (0 - 10 years)" Then
                    If CInt(txtYear.Text) < (Now.Year - 10) Then
                        li.Attributes.Add("style", "display:none")
                    End If

                    li.Selected = ds.Tables(0).Rows(0).Item("mhRep")
                End If

            Next
            txtAAS.Text = ds.Tables(0).Rows(0).Item("AAS").ToString
            txtAPE.Text = ds.Tables(0).Rows(0).Item("APE").ToString
            LlyodsLiabdd.SelectedValue = ds.Tables(0).Rows(0).Item("perliab").ToString
            LlyodsPremLiabdd.SelectedValue = ds.Tables(0).Rows(0).Item("premLiab").ToString
            Lloyds_Dwell.Text = ds.Tables(0).Rows(0).Item("dwelPrem").ToString
            Lloyds_PerLiab.Text = ds.Tables(0).Rows(0).Item("perPrem").ToString
            Lloyds_PremLiab.Text = ds.Tables(0).Rows(0).Item("premPrem").ToString
            Lloyds_PERep.Text = ds.Tables(0).Rows(0).Item("perepPrem").ToString
            Lloyds_FullRep.Text = ds.Tables(0).Rows(0).Item("fullRepPrem").ToString
            Lloyds_Total.Text = ds.Tables(0).Rows(0).Item("fullRepPrem").ToString
            Lloyds_MHRepCost.Text = ds.Tables(0).Rows(0).Item("mhRepPrem").ToString
            Lloyds_Total.Text = ds.Tables(0).Rows(0).Item("credits").ToString
            Dim lbl As New Label()
            lbl.Text = "<script language='javascript'> UpdateLloydsFeesOptionalCoverages(); OnLlyodsLiabddSelectedIndexChange(); OnLlyodsPremLiabddSelectedIndexChange();" & "<" & "/script>"
            Page.Controls.Add(lbl)

        Else
            txtAAS.Text = 0
            txtAPE.Text = 0
        End If
    End Sub
    '****************************************************
    ' End  Load
    '****************************************************
    '****************************************************
    ' Save
    '****************************************************
    Public Sub savebtn_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles savebtn.Click
        If Request.QueryString("quoteID") <> "" Or Session("beenSaved") = "True" Then
            updateQuote(Request.QueryString("quoteID"))
            If lblState.Text <> "FL" Then
                Lloyds1.savePrem(Request.QueryString("quoteID"))
            End If
        Else 'New Quote
            If lblquoteNumber.Text <> "" Then
                updateQuote(Request.QueryString("quoteID"))
                If lblState.Text <> "FL" Then
                    Lloyds1.savePrem(Request.QueryString("quoteID"))
                End If
            Else
                save()
            End If

        End If

    End Sub
    'Update Quote
    Public Sub updateQuote(ByVal quoteID As String)
        If distToCoastDD.SelectedValue.ToString = "2 – 5 miles" Or distToCoastDD.SelectedValue.ToString = "0.5 – 5 miles" Then
            whtxt.Text = "1500"
        Else
            whtxt.Text = "1000"
        End If

        Dim dob As String
        If txtDOB1.Text.Length = 8 Then
            dob = txtDOB1.Text.Substring(0, 2) & "/" & txtDOB1.Text.Substring(2, 2) & "/" & txtDOB1.Text.Substring(4, 4)
        Else
            dob = txtDOB1.Text
        End If
        If txtAgConName.Text <> "" And txtConEmail.Text <> "" Then


            Dim ds As System.Data.DataSet
            Dim tsql As String
            tsql = "UPDATE tblQuotes SET "
            tsql += "term =  '" & termdd.SelectedValue.ToString & "',"
            tsql += "agencyName =  '" & lblAgency.Text.Replace("'", "''") & "',"
            tsql += "agentName =  '" & txtAgConName.Text.Replace("'", "''") & "',"
            tsql += "agentEmail =  '" & txtConEmail.Text & "',"
            tsql += "effDate =  '" & txtEffDate.Text & "',"
            tsql += "applicantFirstName =  '" & txtAppFirstName.Text.Replace("'", "''") & "',"
            tsql += "applicantLastName =  '" & txtAppLastName.Text.Replace("'", "''") & "',"
            tsql += "applicantEmail =  '" & txtAppEmail.Text & "',"
            tsql += "applicantDOB = '" & dob & "'," 'cast(left('" & txtDOB1.Text.Replace("/", "") & "',2) + '/' + substring('" & txtDOB1.Text.Replace("/", "") & "',3,2) + '/' + right('" & txtDOB1.Text.Replace("/", "") & "',4) as datetime)  ,"
            tsql += "propAddress = '" & txtAppAddr.Text & "',"
            tsql += "zip =  '" & txtZip.Text & "',"
            tsql += "city = '" & cddlCity.SelectedValue.ToString & "',"
            tsql += "state =  '" & lblState.Text & "',"
            tsql += "county = '" & txtCounty.Text & "',"
            tsql += "distToCoast =  '" & distToCoastDD.SelectedValue.ToString & "',"
            tsql += "homeUse = '" & homeusedd.SelectedValue.ToString & "',"
            tsql += "homeType =  '" & typedd.SelectedValue.ToString & "',"
            tsql += "year =  '" & txtYear.Text & "',"
            tsql += "length =  '" & txtLength.Text & "',"
            tsql += "width =  '" & txtWidth.Text & "',"
            tsql += "manf =  '" & manfdd.SelectedValue.ToString & "',"
            tsql += "valuation =  '" & txtValuation.Text & "',"
            tsql += "protClass =  '" & protclassdd.SelectedValue.ToString & "',"
            tsql += "skirting =  '" & skirtdd.SelectedValue.ToString & "',"
            tsql += "lienholder =  '" & liendd.SelectedValue.ToString & "',"
            tsql += "suppHeating =  '" & supheatdd.SelectedValue.ToString & "',"
            tsql += "priorLoss =  '" & priorlosdd.SelectedValue.ToString & "',"

            tsql += "isMHInPark =  '" & mhparkdd.SelectedValue.ToString & "',"
            tsql += "parkMGR =  '" & mhResMangdd.SelectedValue.ToString & "',"
            tsql += "park100Spaces =  '" & mhSpacdd.SelectedValue.ToString & "',"
            tsql += "parklightedStreet =  '" & mhlightdd.SelectedValue.ToString & "',"
            tsql += "insuredParkAgeOcc =  '" & mhInsAge.SelectedValue.ToString & "',"

            tsql += "aopDed = '" & aopdd.SelectedValue.ToString.Replace("$", "") & "',"
            tsql += "coverageAmt =   '" & txtcvgamt.Text & "',"
            tsql += "lapseInCoverage =  '" & lapsdd.SelectedValue.ToString & "',"
            tsql += "windHailDed =  '" & whtxt.Text.ToString.Replace("$", "") & "',"
            tsql += "Ansi_Asce = '" & ddansi.SelectedValue.ToString & "',"
            tsql += "quoteStatus = 'Quote',"
            tsql += "dateUpdated =  getDate(), "
            tsql += "suppHeatingType = '" & supHeatTypedd.SelectedValue.ToString & "',"
            tsql += "notes = '" & txtquotennotes.Text.Replace("'", "''") & "'"
            tsql += " WHERE  quoteID = '" & quoteID & "'"
            Try
                ds = runQueryDS(tsql, "ColonialMHConnectionString")
                If Lloyds_Dwell.Text <> "0.00" Then
                    updateLloydsQuote(quoteID)
                End If

                If ar_dwell1.Text <> "0.00" Then
                    If ar_baseprem1.Text <> "0.00" Then
                        UpdateAR1Prem(quoteID)
                    End If
                    If ar_baseprem2.Text <> "0.00" Then
                        UpdateAR2Prem(quoteID)
                    End If
                    If ar_baseprem3.Text <> "0.00" Then
                        UpdateAR3Prem(quoteID)
                    End If
                End If
                SaveLoss(quoteID)
                If lblState.Text <> "FL" Then
                    Lloyds1.savePrem(lblquoteNumber.Text)
                Else
                    LoadCalcintoDB(lblquoteNumber.Text)
                End If
                updateStatus("Quote Updated")
            Catch ex As Exception
                updateStatus("Quote Update Failed")
                errortrap(tsql, "UpdateQuote", ex.Message)
            End Try
        Else
            ASPxPopupControl1.Enabled = True
            Label173.Text = "You Must select an agent as well as agent email."
            'ASPxPopupControl1.PopupElementID = "prmbtn"
            ASPxPopupControl1.PopupHorizontalAlign = DevExpress.Web.ASPxClasses.PopupHorizontalAlign.Center
            ASPxPopupControl1.ShowOnPageLoad = True
        End If
    End Sub
    'Update Lloyds Quote Premiums
    Public Sub updateLloydsQuote(ByVal quoteID As String)
        Dim peRep, fullRep, MHRep, ASPE As Boolean
        peRep = False
        fullRep = False
        MHRep = False
        ASPE = False
        For Each li As ListItem In optcbl.Items
            If li.Value = "PE Replacement Cost" And li.Selected Then
                peRep = True
                Lloyds_PERep.Text = PEREPCOST.Text
            End If
            If li.Value = "Full Repair" And li.Selected Then
                fullRep = True
                Lloyds_FullRep.Text = FULLREPAIR.Text
            End If
            If li.Value = "MH Replacement Cost (0 - 10 years)" And li.Selected Then
                MHRep = True
                Lloyds_MHRepCost.Text = MHREPCOST.Text
            End If

        Next
        Select Case LlyodsPremLiabdd.SelectedValue.ToString
            Case "$25,000"
                Lloyds_PremLiab.Text = PREMLIAB25.Text
            Case "$50,000"
                Lloyds_PremLiab.Text = PREMLIAB50.Text
            Case "$100,000"
                Lloyds_PremLiab.Text = PREMLIAB100.Text
        End Select

        Select Case LlyodsLiabdd.SelectedValue.ToString
            Case "$25,000"
                Lloyds_PerLiab.Text = PERLIAB25.Text
            Case "$50,000"
                Lloyds_PerLiab.Text = PERLIAB50.Text
            Case "$100,000"
                Lloyds_PerLiab.Text = PERLIAB100.Text
            Case "$300,000"
                Lloyds_PerLiab.Text = PERLIAB300.Text
        End Select

        If typedd.SelectedValue.ToString = "Singlewide" Then
            Lloyds_AAS.Text = (CDbl(txtAAS.Text) / 100) * CDbl(OPCOVPESINGLE.Text)
        Else
            Lloyds_AAS.Text = (CDbl(txtAAS.Text) / 100) * CDbl(OPCOVPEDOUBLE.Text)
        End If

        If typedd.SelectedValue.ToString = "Singlewide" Then
            Lloyds_APE.Text = (CDbl(txtAPE.Text) / 100) * CDbl(OPCOVPESINGLE.Text)
        Else
            Lloyds_APE.Text = (CDbl(txtAPE.Text) / 100) * CDbl(OPCOVPEDOUBLE.Text)
        End If

        Lloyds_Total.Text = FormatCurrency(CDbl(Lloyds_Dwell.Text) + CDbl(Lloyds_PerLiab.Text) + CDbl(Lloyds_PremLiab.Text) + CDbl(Lloyds_AAS.Text) + CDbl(Lloyds_APE.Text) + CDbl(Lloyds_PERep.Text) + CDbl(Lloyds_FullRep.Text) + CDbl(Lloyds_MHRepCost.Text))
        Dim ds As System.Data.DataSet
        Dim tsql As String
        tsql = "UPDATE tblLloydsQuotes SET "
        tsql += "peRepCost =  '" & peRep & "',"
        tsql += "fullRep =  '" & fullRep & "',"
        tsql += "mhRep =  '" & MHRep & "',"
        tsql += "AAS =  '" & txtAAS.Text & "',"
        tsql += "APE =  '" & txtAPE.Text & "',"
        tsql += "perLiab =  '" & LlyodsLiabdd.SelectedValue.ToString & "',"
        tsql += "premLiab =  '" & LlyodsPremLiabdd.SelectedValue.ToString & "',"
        tsql += "dwelPrem =  '" & Lloyds_Dwell.Text & "',"
        tsql += "perPrem =  '" & Lloyds_PerLiab.Text & "',"
        tsql += "premPrem =  '" & Lloyds_PremLiab.Text & "',"
        tsql += " perepPrem=  '" & Lloyds_PERep.Text & "',"
        tsql += "fullRepPrem =  '" & Lloyds_FullRep.Text & "',"
        tsql += "mhRepPrem =  '" & Lloyds_MHRepCost.Text & "',"
        tsql += "total =  '" & Lloyds_Total.Text & "',"
        tsql += "credits =  '" & Lloyds_Credits.Text & "',"
        tsql += "AASPrem =  '" & Lloyds_AAS.Text & "',"
        tsql += "APEPrem =  '" & Lloyds_APE.Text & "',"
        tsql += "dateUpdated =  getDate() "
        tsql += " WHERE  quoteID = '" & quoteID & "'"
        Try
            ds = runQueryDS(tsql, "ColonialMHConnectionString")
        Catch ex As Exception

        End Try
    End Sub
    'Save New Quote
    Public Sub save()
        If Request.QueryString("quoteID") <> "" Then
        Else
            If txtAgConName.Text <> "" And txtConEmail.Text <> "" Then



                Dim ds1 As System.Data.DataSet
                Dim tsql1 As String

                tsql1 = "Select * from tblQuotes where "
                'tsql1 += "convert(Varchar(10),applicantDOB,101) = '" & txtDOB1.Text & "'"
                tsql1 += "propAddress = '" & txtAppAddr.Text & "'"
                tsql1 += " and applicantLastName = '" & txtAppLastName.Text.Replace("'", "''") & "'"
                tsql1 += " and applicantFirstName = '" & txtAppFirstName.Text.Replace("'", "''") & "'"
                tsql1 += " and agentName = '" & txtAgConName.Text.Replace("'", "''") & "'"
                ds1 = runQueryDS(tsql1, "ColonialMHConnectionString")
                If ds1.Tables(0).Rows.Count > 0 Then
                    lblquoteNumber.Text = ds1.Tables(0).Rows(0).Item("quoteID").ToString
                    updateQuote(ds1.Tables(0).Rows(0).Item("quoteID").ToString)
                Else
                    Dim effdate As String
                    Dim efdate As Date
                    If IsDate(txtEffDate.Text) Then
                        efdate = CDate(txtEffDate.Text)
                        effdate = efdate.ToString("MM/dd/yyyy")

                    Else



                        If txtEffDate.Text.Length = 8 Then
                            effdate = txtEffDate.Text.Substring(0, 2) & "/" & txtEffDate.Text.Substring(2, 2) & "/" & txtEffDate.Text.Substring(4, 4)
                        Else
                            effdate = txtEffDate.Text
                        End If
                    End If

                    Dim dob As String
                    If txtDOB1.Text.Length = 8 Then
                        dob = txtDOB1.Text.Substring(0, 2) & "/" & txtDOB1.Text.Substring(2, 2) & "/" & txtDOB1.Text.Substring(4, 4)
                    Else
                        dob = txtDOB1.Text
                    End If

                    Dim ds As System.Data.DataSet
                    Dim tsql As String
                    tsql = "INSERT INTO tblQuotes VALUES( NULL, "
                    tsql += " '" & termdd.SelectedValue.ToString & "',"
                    tsql += " '" & lblAgency.Text.Replace("'", "''") & "',"
                    tsql += " '" & txtAgConName.Text.Replace("'", "''") & "',"
                    tsql += " '" & txtConEmail.Text & "',"
                    tsql += " '" & effdate & "',"

                    tsql += " '" & txtAppEmail.Text & "',"
                    'tsql += " '" & txtDOB1.Text & "',"
                    tsql += "'" & dob & "'," '" cast(left('" & txtDOB1.Text.Replace("/", "") & "',2) + '/' + substring('" & txtDOB1.Text.Replace("/", "") & "',3,2) + '/' + right('" & txtDOB1.Text.Replace("/", "") & "',4) as datetime)  ,"
                    tsql += " '" & txtAppAddr.Text & "',"
                    tsql += " '" & txtZip.Text & "',"
                    tsql += " '" & cddlCity.SelectedValue.ToString & "',"
                    tsql += " '" & lblState.Text & "',"
                    tsql += " '" & txtCounty.Text & "',"
                    tsql += " '" & distToCoastDD.SelectedValue.ToString & "',"
                    tsql += " '" & homeusedd.SelectedValue.ToString & "',"
                    tsql += " '" & typedd.SelectedValue.ToString & "',"
                    tsql += " '" & txtYear.Text & "',"
                    tsql += " '" & txtLength.Text & "',"
                    tsql += " '" & txtWidth.Text & "',"
                    tsql += " '" & manfdd.SelectedValue.ToString & "',"
                    tsql += " '" & txtValuation.Text & "',"
                    tsql += " '" & protclassdd.SelectedValue.ToString & "',"
                    tsql += " '" & skirtdd.SelectedValue.ToString & "',"
                    tsql += " '" & liendd.SelectedValue.ToString & "',"
                    tsql += " '" & supheatdd.SelectedValue.ToString & "',"
                    tsql += " '" & priorlosdd.SelectedValue.ToString & "',"
                    tsql += " '" & aopdd.SelectedValue.ToString & "',"
                    tsql += " '" & txtcvgamt.Text & "',"
                    tsql += "getDate(),getDate(),"
                    tsql += " '" & lapsdd.SelectedValue.ToString & "',"
                    tsql += " '" & whtxt.Text.ToString & "',"
                    tsql += " '" & txtAppFirstName.Text.Replace("'", "''") & "',"
                    tsql += " '" & txtAppLastName.Text.Replace("'", "''") & "',"
                    tsql += " '" & mhparkdd.SelectedValue.ToString & "',"
                    tsql += " '" & mhResMangdd.SelectedValue.ToString & "',"
                    tsql += " '" & mhSpacdd.SelectedValue.ToString & "',"
                    tsql += " '" & mhlightdd.SelectedValue.ToString & "',"
                    tsql += " '" & mhInsAge.SelectedValue.ToString & "', "
                    tsql += " ' ', "
                    tsql += " '" & rateTypelbl.Text.ToString & "', "
                    tsql += " '" & ddansi.SelectedValue.ToString & "',"
                    tsql += " '', " 'Import ID
                    tsql += " 'Quote'," 'status
                    tsql += " '" & supHeatTypedd.SelectedValue.ToString & "',"
                    tsql += " '" & txtquotennotes.Text.Replace("'", "''") & "',"
                    tsql += " '" & mySession.CurrentUser.ID.ToString & "'"
                    tsql += " )"
                    Try
                        ds = runQueryDS(tsql, "ColonialMHConnectionString")
                        ds = runQueryDS("SELECT TOP 1 quoteID FROM tblQuotes ORDER BY quoteID DESC", "ColonialMHConnectionString")
                        If ds.Tables(0).Rows.Count > 0 Then
                            lblquoteNumber.Text = ds.Tables(0).Rows(0).Item("quoteID").ToString
                            'Save Lloyds Rate Date
                            If Lloyds_Dwell.Text <> "0.00" Then
                                If saveLloydsPrem(ds.Tables(0).Rows(0).Item("quoteID").ToString) Then
                                    updateStatus("Save Completed")
                                    Session("beenSaved") = "True"
                                Else
                                    updateStatus("Save Failed")
                                End If
                            End If

                            If ar_dwell1.Text <> "0.00" Then
                                If saveARPrem(ds.Tables(0).Rows(0).Item("quoteID").ToString) Then
                                    updateStatus("Save Completed")

                                    Session("beenSaved") = "True"
                                Else
                                    updateStatus("Save Failed")
                                End If
                            End If
                            SaveLoss(ds.Tables(0).Rows(0).Item("quoteID").ToString)
                            'LoadCalcintoDB(ds.Tables(0).Rows(0).Item("quoteID").ToString)

                        End If
                        If lblState.Text <> "FL" Then
                            Lloyds1.savePrem(lblquoteNumber.Text)
                        Else
                            LoadCalcintoDB(ds.Tables(0).Rows(0).Item("quoteID").ToString)
                        End If

                    Catch ex As Exception
                        Stop
                        updateStatus("Save Failed")
                        errortrap(tsql, "Save", ex.Message)
                    End Try

                End If

            Else
                ASPxPopupControl1.Enabled = True
                Label173.Text = "You Must select an agent as well as agent email."
                'ASPxPopupControl1.PopupElementID = "prmbtn"
                ASPxPopupControl1.PopupHorizontalAlign = DevExpress.Web.ASPxClasses.PopupHorizontalAlign.Center
                ASPxPopupControl1.ShowOnPageLoad = True
            End If

        End If
    End Sub
    Public Sub LoadLoss(ByVal quoteID As String)
        Dim ds As System.Data.DataSet
        ds = runQueryDS("SELECT * FROM tblLoss WHERE quoteID = '" & quoteID & "'", "ColonialMHConnectionString")
        If ds.Tables(0).Rows.Count > 0 Then
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
        Else
            'no rows
        End If
    End Sub

    Public Sub SaveLoss(ByVal quoteID As String)
        Dim ds As System.Data.DataSet
        Dim tsql As String
        tsql = "EXEC spUpdateLossRecord "
        tsql += "'" & quoteID & "',"
        tsql += "'" & txtLoss1Date.Text & "',"
        tsql += "'" & ddLoss1Type.SelectedValue & "',"
        tsql += "'" & txtLoss1Description.Text & "',"
        tsql += "'" & txtLoss1AmtPaid.Text & "',"
        tsql += "'" & ddLoss1Status.SelectedValue & "',"
        tsql += "'" & txtLoss2Date.Text & "',"
        tsql += "'" & ddLoss2Type.SelectedValue & "',"
        tsql += "'" & txtLoss2Description.Text & "',"
        tsql += "'" & txtLoss2AmtPaid.Text & "',"
        tsql += "'" & ddLoss2Status.SelectedValue & "',"
        tsql += "'" & txtLoss3Date.Text & "',"
        tsql += "'" & ddLoss3Type.SelectedValue & "',"
        tsql += "'" & txtLoss3Description.Text & "',"
        tsql += "'" & txtLoss3AmtPaid.Text & "',"
        tsql += "'" & ddLoss3Status.SelectedValue & "'"


        ds = runQueryDS(tsql, "ColonialMHConnectionString")

    End Sub
    'Save New Lloyds Quote Premiums
    Public Function saveLloydsPrem(ByVal quoteID As String)
        Dim peRep, fullRep, MHRep, ASPE As Boolean
        peRep = False
        fullRep = False
        MHRep = False
        ASPE = False
        If Request.QueryString("quoteID") <> "" Then
        Else
            For Each li As ListItem In optcbl.Items
                If li.Value = "PE Replacement Cost" And li.Selected Then
                    peRep = True
                    Lloyds_PERep.Text = PEREPCOST.Text
                End If
                If li.Value = "Full Repair" And li.Selected Then
                    fullRep = True
                    Lloyds_FullRep.Text = FULLREPAIR.Text
                End If
                If li.Value = "MH Replacement Cost (0 - 10 years)" And li.Selected Then
                    MHRep = True
                    Lloyds_MHRepCost.Text = MHREPCOST.Text
                End If

            Next
            Select Case LlyodsPremLiabdd.SelectedValue.ToString
                Case "$25,000"
                    Lloyds_PremLiab.Text = PREMLIAB25.Text
                Case "$50,000"
                    Lloyds_PremLiab.Text = PREMLIAB50.Text
                Case "$100,000"
                    Lloyds_PremLiab.Text = PREMLIAB100.Text
            End Select

            Select Case LlyodsLiabdd.SelectedValue.ToString
                Case "$25,000"
                    Lloyds_PerLiab.Text = PERLIAB25.Text
                Case "$50,000"
                    Lloyds_PerLiab.Text = PERLIAB50.Text
                Case "$100,000"
                    Lloyds_PerLiab.Text = PERLIAB100.Text
                Case "$300,000"
                    Lloyds_PerLiab.Text = PERLIAB300.Text
            End Select
            Lloyds_Total.Text = CDbl(Lloyds_Dwell.Text) + CDbl(Lloyds_PerLiab.Text) + CDbl(Lloyds_PremLiab.Text) + CDbl(Lloyds_AAS.Text) + CDbl(Lloyds_APE.Text) + CDbl(Lloyds_PERep.Text) + CDbl(Lloyds_FullRep.Text) + CDbl(Lloyds_MHRepCost.Text)
            Dim ds As System.Data.DataSet
            Dim tsql As String
            tsql = "INSERT INTO tblLloydsQuotes VALUES(  "
            tsql += " '" & quoteID & "',"
            tsql += " '" & peRep & "',"
            tsql += " '" & fullRep & "',"
            tsql += " '" & MHRep & "',"
            tsql += " '" & ASPE & "',"
            tsql += " '" & LlyodsLiabdd.SelectedValue.ToString & "',"
            tsql += " '" & LlyodsPremLiabdd.SelectedValue.ToString & "',"
            tsql += " '" & Lloyds_Dwell.Text & "',"
            tsql += " '" & Lloyds_PerLiab.Text & "',"
            tsql += " '" & Lloyds_PremLiab.Text & "',"
            tsql += " '" & Lloyds_PERep.Text & "',"
            tsql += " '" & Lloyds_FullRep.Text & "',"
            tsql += " '" & Lloyds_MHRepCost.Text & "',"
            tsql += " '" & Lloyds_Total.Text & "',"
            tsql += "getDate(),getDate()), "
            tsql += " '" & Lloyds_Credits.Text & "'"
            tsql += " '" & txtAAS.Text & "'"
            tsql += " '" & txtAPE.Text & "'"
            tsql += " '" & Lloyds_AAS.Text & "'"
            tsql += " '" & Lloyds_APE.Text & "'"
            Try
                ds = runQueryDS(tsql, "ColonialMHConnectionString")
                Return True
            Catch ex As Exception
                Return False
            End Try
        End If
        Return False
    End Function
    'Save AR Preiums & Options
    Public Function saveARPrem(ByVal quoteID As String)
        Dim ds As System.Data.DataSet
        Dim tsql As String
        tsql = "INSERT INTO tblARQuotes VALUES( "
        tsql += " '" & quoteID & "',"
        tsql += " '" & ar_dwell1.Text & "',"
        tsql += " '" & ar_unattStr1.Text & "',"
        tsql += " '" & ar_perEff1.Text & "',"
        tsql += " '" & ar_perLiab1.Text & "',"
        tsql += " '" & ar_medpay1.Text & "',"
        tsql += " '" & ar_baseprem1.Text & "',"
        tsql += " '" & ar_options1.Text & "',"
        tsql += " '" & ar_fees1.Text & "',"
        tsql += " '" & ar_tax1.Text & "',"
        tsql += " '" & ar_total1.Text & "',"
        tsql += " '" & dd_aop_AR1.SelectedValue.ToString & "',"
        tsql += " '" & dd_hurded_AR1.SelectedValue.ToString & "',"
        tsql += " '" & dd_pl_AR1.SelectedValue.ToString & "',"
        tsql += " '" & dd_mp_AR1.SelectedValue.ToString & "',"
        tsql += " '" & txt_unattstr_AR1.Text & "',"
        tsql += " '" & txt_pp_AR1.Text & "',"
        tsql += " '" & dd_mhr_AR1.SelectedValue.ToString & "',"
        tsql += " '" & dd_rep_AR1.SelectedValue.ToString & "',"
        tsql += " '" & txt_addlimrad_AR1.Text & "',"
        tsql += " '" & txt_addlimfir_AR1.Text & "',"
        tsql += " '" & dd_sip_AR1.SelectedValue.ToString & "',"
        tsql += " '" & dd_ndp_AR1.SelectedValue.ToString & "',"
        tsql += " '" & dd_addresOpt_ar1.SelectedValue.ToString & "',"
        tsql += " '" & dd_addresliab_ar1.SelectedValue.ToString & "',"
        tsql += " '" & dd_addresMP_ar1.SelectedValue.ToString & "',"
        tsql += " '" & dd_waterCraft_AR1.SelectedValue.ToString & "',"
        tsql += " '" & dd_waterCraftliab_AR1.SelectedValue.ToString & "',"
        tsql += " '" & dd_waterCraftMedpay_AR1.SelectedValue.ToString & "',"
        tsql += " '" & dd_PackagePerProp_AR1.SelectedValue.ToString & "',"

        tsql += " '" & ar_dwell2.Text & "',"
        tsql += " '" & ar_unattStr2.Text & "',"
        tsql += " '" & ar_perEff2.Text & "',"
        tsql += " '" & ar_perLiab2.Text & "',"
        tsql += " '" & ar_medpay2.Text & "',"
        tsql += " '" & ar_baseprem2.Text & "',"
        tsql += " '" & ar_options2.Text & "',"
        tsql += " '" & ar_fees2.Text & "',"
        tsql += " '" & ar_tax2.Text & "',"
        tsql += " '" & ar_total2.Text & "',"
        tsql += " '" & dd_aop_AR2.SelectedValue.ToString & "',"
        tsql += " '" & dd_hurded_AR2.SelectedValue.ToString & "',"
        tsql += " '" & dd_pl_AR2.SelectedValue.ToString & "',"
        tsql += " '" & dd_mp_AR2.SelectedValue.ToString & "',"
        tsql += " '" & txt_unattstr_AR2.Text & "',"
        tsql += " '" & txt_pp_AR2.Text & "',"
        tsql += " '" & dd_mhr_AR2.SelectedValue.ToString & "',"
        tsql += " '" & dd_rep_AR2.SelectedValue.ToString & "',"
        tsql += " '" & txt_addlimrad_AR2.Text & "',"
        tsql += " '" & txt_addlimfir_AR2.Text & "',"
        tsql += " '" & dd_sip_AR2.SelectedValue.ToString & "',"
        tsql += " '" & dd_ndp_AR2.SelectedValue.ToString & "',"
        tsql += " '" & dd_addresOpt_ar2.SelectedValue.ToString & "',"
        tsql += " '" & dd_addresliab_ar2.SelectedValue.ToString & "',"
        tsql += " '" & dd_addresMP_ar2.SelectedValue.ToString & "',"
        tsql += " '" & dd_waterCraft_ar2.SelectedValue.ToString & "',"
        tsql += " '" & dd_waterCraftliab_ar2.SelectedValue.ToString & "',"
        tsql += " '" & dd_waterCraftMedpay_ar2.SelectedValue.ToString & "',"
        tsql += " '" & dd_PackagePerProp_ar2.SelectedValue.ToString & "',"

        tsql += " '" & ar_dwell3.Text & "',"
        tsql += " '" & ar_unattStr3.Text & "',"
        tsql += " '" & ar_perEff3.Text & "',"
        tsql += " '" & ar_perLiab3.Text & "',"
        tsql += " '" & ar_medpay3.Text & "',"
        tsql += " '" & ar_baseprem3.Text & "',"
        tsql += " '" & ar_options3.Text & "',"
        tsql += " '" & ar_fees3.Text & "',"
        tsql += " '" & ar_tax3.Text & "',"
        tsql += " '" & ar_total3.Text & "',"
        tsql += " '" & dd_aop_AR3.SelectedValue.ToString & "',"
        tsql += " '" & dd_hurded_AR3.SelectedValue.ToString & "',"
        tsql += " '" & dd_pl_AR3.SelectedValue.ToString & "',"
        tsql += " '" & dd_mp_AR3.SelectedValue.ToString & "',"
        tsql += " '" & txt_unattstr_AR3.Text & "',"
        tsql += " '" & txt_pp_AR3.Text & "',"

        tsql += " '" & txt_addlimrad_AR3.Text & "',"
        tsql += " '" & txt_addlimfir_AR3.Text & "',"
        tsql += " '" & dd_sip_AR3.SelectedValue.ToString & "',"
        tsql += " '" & dd_ndp_AR3.SelectedValue.ToString & "',"

        tsql += "getDate(),getDate(),"
        tsql += " '" & txt_dwell_AR1_Amount.Text & "',"
        tsql += " '" & txt_pp_AR1_Amount.Text & "',"
        tsql += " '" & txt_unattstr_AR1_Amount.Text & "',"
        tsql += " '" & dd_pl_AR1_Amount.Text & "',"
        tsql += " '" & txt_DedChange_AR1_Amount.Text & "',"
        tsql += " '" & dd_rep_AR1_Amount.Text & "',"
        tsql += " '" & dd_mhr_AR1_Amount.Text & "',"
        tsql += " '" & txt_addlimfir_AR1_Amount.Text & "',"

        tsql += " '" & txt_dwell_AR2_Amount.Text & "',"
        tsql += " '" & txt_pp_AR2_Amount.Text & "',"
        tsql += " '" & txt_unattstr_AR2_Amount.Text & "',"
        tsql += " '" & dd_pl_AR2_Amount.Text & "',"
        tsql += " '" & txt_DedChange_AR2_Amount.Text & "',"
        tsql += " '" & dd_rep_AR2_Amount.Text & "',"
        tsql += " '" & dd_mhr_AR2_Amount.Text & "',"
        tsql += " '" & txt_addlimfir_AR2_Amount.Text & "',"

        tsql += " '" & txt_dwell_AR3_Amount.Text & "',"
        tsql += " '0',"
        tsql += " '0',"
        tsql += " '0',"
        tsql += " '" & txt_DedChange_AR3_Amount.Text & "',"
        tsql += " '0',"
        tsql += " '0',"
        tsql += " '0',"

        tsql += " '" & txt_Credit_AR1_Amount.Text & "',"
        tsql += " '" & txt_Credit_AR2_Amount.Text & "',"
        tsql += " '" & txt_Credit_AR3_Amount.Text & "',"

        tsql += " '" & txt_addlimrad_AR1_Amount.Text & "'," 'Radio Package
        tsql += " '" & txt_addlimrad_AR2_Amount.Text & "'," 'Radio Standard

        tsql += " '" & supHeating_ar1_Amount.Text & "'," 'Sup Heat Package
        tsql += " '" & supHeating_ar2_Amount.Text & "'," 'Sup Heat Standard
        tsql += " '" & supHeating_ar3_Amount.Text & "'," 'Sup Heat Rental

        tsql += " '" & CEA_ar1_Amount.Text & "'," 'CEA Package
        tsql += " '" & CEA_ar2_Amount.Text & "'," 'CEA Standard
        tsql += " '" & CEA_ar3_Amount.Text & "'," 'CEA Rental
        tsql += " '" & SeasonalFee_ar2_Amount.Text & "'," 'Standard Seasonal Fee
        tsql += " '" & ddansi.SelectedValue.ToString & "'," 'Ansi_Asce
        tsql += " '" & dd_PackagePerProp_AR1.SelectedValue.ToString & "'," 'PackagePersonal Property
        tsql += " '" & dd_PackagePerProp_ar2.SelectedValue.ToString & "'," 'Standard Personal Property

        tsql += " '" & txt_addlimrad_AR1_Amount.Text & "',"
        tsql += " '" & txt_addlimrad_AR2_Amount.Text & "',"
        tsql += " '" & txt_addlimrad_AR3_Amount.Text & "',"
        tsql += " '" & txt_addlimfir_AR1_Amount.Text & "',"
        tsql += " '" & dd_sip_AR1_Amount.Text & "',"
        tsql += " '" & dd_ndp_AR1_Amount.Text & "',"
        tsql += " '" & dd_addresOpt_ar1_Amount.Text & "',"
        tsql += " '" & dd_waterCraft_AR1_Amount.Text & "',"
        tsql += " '" & dd_PackagePerProp_AR1_Amount.Text & "',"
        tsql += " '" & txt_addlimfir_AR2_Amount.Text & "',"
        tsql += " '" & dd_sip_AR2_Amount.Text & "',"
        tsql += " '" & dd_ndp_AR2_Amount.Text & "',"
        tsql += " '" & dd_addresOpt_ar2_Amount.Text & "',"
        tsql += " '" & dd_waterCraft_ar2_Amount.Text & "',"
        tsql += " '" & dd_PackagePerProp_ar2_Amount.Text & "',"
        tsql += " '" & txt_addlimfir_AR3_Amount.Text & "',"
        tsql += " '" & dd_sip_AR3_Amount.Text & "',"
        tsql += " '" & dd_ndp_AR3_Amount.Text & "'"


        tsql += " )"
        'Package Personal Property
        If dd_PackagePerProp_AR1.SelectedValue = "Yes" Then
            dsar1 = CType(Session("DataSet"), DataSet)

            If dsar1.Tables(0).Rows.Count > 0 Then
                For Each row As DataRow In dsar1.Tables(0).Rows
                    addPersProp(quoteID, "Package", row("description").ToString, row("value").ToString)
                Next


            Else
                'no rows.
            End If

        End If
        If dd_PackagePerProp_ar2.SelectedValue = "Yes" Then
            dsar2 = CType(Session("DataSet2"), DataSet)

            If dsar2.Tables(0).Rows.Count > 0 Then
                For Each row As DataRow In dsar2.Tables(0).Rows
                    addPersProp(quoteID, "Standard", row("description").ToString, row("value").ToString)
                Next


            Else
                'no rows.
            End If

        End If


        Try
            ds = runQueryDS(tsql, "ColonialMHConnectionString")
            Return True
        Catch ex As Exception
            errortrap(tsql, "SaveARPrem", ex.Message)
            Stop
            Return False
        End Try


    End Function

    'Save AR Preiums & Options

    'Package
    Public Sub UpdateAR1Prem(ByVal quoteID As String)
        Dim ds As System.Data.DataSet
        ds = runQueryDS("SELECT * FROM tblARQuotes WHERE  quoteID = '" & quoteID & "'", "ColonialMHConnectionString")
        If ds.Tables(0).Rows.Count <= 0 Then
            saveARPrem(quoteID)
            Exit Sub
        End If
        Dim tsql As String
        tsql = "UPDATE tblARQuotes SET "
        tsql += " ARPackageDwelling=  '" & ar_dwell1.Text() & "',"
        tsql += " ARPackageOthStruc=  '" & ar_unattStr1.Text() & "',"
        tsql += " ARPackageContents=  '" & ar_perEff1.Text() & "',"
        tsql += " ARPackageLiab=  '" & ar_perLiab1.Text() & "',"
        tsql += " ARPackageMedPay=  '" & ar_medpay1.Text() & "',"
        tsql += " ARPackageBasePrem=  '" & ar_baseprem1.Text() & "',"
        tsql += " ARPackageOptions=  '" & ar_options1.Text() & "',"
        tsql += " ARPackageFees=  '" & ar_fees1.Text() & "',"
        tsql += " ARPackageTax=  '" & ar_tax1.Text() & "',"
        tsql += " ARPackageTotal=  '" & ar_total1.Text() & "',"
        tsql += " ARPackageAOPOpt=  '" & dd_aop_AR1.SelectedValue.ToString & "',"
        tsql += " ARPackageHurDedOpt=  '" & dd_hurded_AR1.SelectedValue.ToString & "',"
        tsql += " ARPackagePerLiabOpt=  '" & dd_pl_AR1.SelectedValue.ToString & "',"
        tsql += " ARPackageMedPayOpt=  '" & dd_mp_AR1.SelectedValue.ToString & "',"
        tsql += " ARPackageOthStrucOpt=  '" & txt_unattstr_AR1.Text() & "',"
        tsql += " ARPackageContOpt =  '" & txt_pp_AR1.Text() & "',"
        tsql += " ARPackageMHRepOpt=  '" & dd_mhr_AR1.SelectedValue.ToString & "',"
        tsql += " ARPackageContRepOpt=  '" & dd_rep_AR1.SelectedValue.ToString & "',"
        tsql += " ARPackageAddRadOpt=  '" & txt_addlimrad_AR1.Text() & "',"
        tsql += " ARPackageAddFireOpt=  '" & txt_addlimfir_AR1.Text() & "',"
        tsql += " ARPackageSIPOpt=  '" & dd_sip_AR1.SelectedValue.ToString & "',"
        tsql += " ARPackageNDPOpt=  '" & dd_ndp_AR1.SelectedValue.ToString & "',"
        tsql += " ARPackageAddResOpt=  '" & dd_addresOpt_ar1.SelectedValue.ToString & "',"
        tsql += " ARPackageAddResLiabOpt=  '" & dd_addresliab_ar1.SelectedValue.ToString & "',"
        tsql += " ARPackageAddResMedOpt=  '" & dd_addresMP_ar1.SelectedValue.ToString & "',"
        tsql += " ARPackageWatOpt=  '" & dd_waterCraft_AR1.SelectedValue.ToString & "',"
        tsql += " ARPackageWatLiabOpt=  '" & dd_waterCraftliab_AR1.SelectedValue.ToString & "',"
        tsql += " ARPackageWatMedOpt=  '" & dd_waterCraftMedpay_AR1.SelectedValue.ToString & "',"

        tsql += " ARPackageDwellingPrem=  '" & txt_dwell_AR1_Amount.Text & "',"
        tsql += " ARPackagePerPropPrem=  '" & txt_pp_AR1_Amount.Text & "',"
        tsql += " ARPackageAddStrucPrem=  '" & txt_unattstr_AR1_Amount.Text & "',"
        tsql += " ARPackagePerLiabPrem=  '" & dd_pl_AR1_Amount.Text & "',"
        tsql += " ARPackageDedChangePrem=  '" & txt_DedChange_AR1_Amount.Text & "',"
        tsql += " ARPackagePerPropRepPrem=  '" & dd_rep_AR1_Amount.Text & "',"
        tsql += " ARPackageMHRepPrem=  '" & dd_mhr_AR1_Amount.Text & "',"
        tsql += " ARPackageFirePrem=  '" & txt_addlimfir_AR1_Amount.Text & "',"

        tsql += " ARPackageCredits=  '" & txt_Credit_AR1_Amount.Text & "',"
        tsql += " ARPackageAddRadPrem=  '" & txt_addlimrad_AR1_Amount.Text & "',"
        tsql += " ARPacakageSupHeatFee=  '" & supHeating_ar1_Amount.Text & "',"
        tsql += " ARPackageCEAFee=  '" & CEA_ar1_Amount.Text & "',"
        tsql += " Ansi_Asce= '" & ddansi.SelectedValue.ToString & "',"

        tsql += " ARPackageRadioprem= '" & txt_addlimrad_AR1_Amount.Text & "',"
        tsql += " ARPackageFireServPrem= '" & txt_addlimfir_AR1_Amount.Text & "',"
        tsql += " ARPackageSecIntPrem= '" & dd_sip_AR1_Amount.Text & "',"
        tsql += " ARPackageNatDisPrem= '" & dd_ndp_AR1_Amount.Text & "',"
        tsql += " ARPackageAddResPrem= '" & dd_addresOpt_ar1_Amount.Text & "',"
        tsql += " ARPackageWaterPrem= '" & dd_waterCraft_AR1_Amount.Text & "',"
        tsql += " ARPackageVPerPropPrem= '" & dd_PackagePerProp_AR1_Amount.Text & "',"

        tsql += " ARPackagePersProp= '" & dd_PackagePerProp_AR1.SelectedValue.ToString & "',"
        tsql += "dateUpdated =  getDate() "
        tsql += " WHERE  quoteID = '" & quoteID & "'"

        If dd_PackagePerProp_AR1.SelectedValue = "Yes" Then
            dsar1 = CType(Session("DataSet"), DataSet)
            Dim ds2 As System.Data.DataSet
            Dim tsql2 As String

            tsql2 = "Delete From tblARPersonProp where quoteID = '" & quoteID & "' and prem_type = 'Package' "

            ds2 = runQueryDS(tsql2, "ColonialMHConnectionString")
            If dsar1.Tables(0).Rows.Count > 0 Then
                For Each row As DataRow In dsar1.Tables(0).Rows
                    addPersProp(quoteID, "Package", row("description").ToString, row("value").ToString)
                Next


            Else
                'no rows.
            End If

        End If


        Try
            ds = runQueryDS(tsql, "ColonialMHConnectionString")
        Catch ex As Exception
            errortrap(tsql, "UpdateAR1Prem", ex.Message)
        End Try
    End Sub
    'Standard
    Public Sub UpdateAR2Prem(ByVal quoteID As String)
        Dim ds As System.Data.DataSet
        ds = runQueryDS("SELECT * FROM tblARQuotes WHERE  quoteID = '" & quoteID & "'", "ColonialMHConnectionString")
        If ds.Tables(0).Rows.Count <= 0 Then
            saveARPrem(quoteID)
            Exit Sub
        End If
        Dim tsql As String
        tsql = "UPDATE tblARQuotes SET "
        tsql += " ARStandardDwelling=  '" & ar_dwell2.Text() & "',"
        tsql += " ARStandardOthStruc=  '" & ar_unattStr2.Text() & "',"
        tsql += " ARStandardContents=  '" & ar_perEff2.Text() & "',"
        tsql += " ARStandardLiab=  '" & ar_perLiab2.Text() & "',"
        tsql += " ARStandardMedPay=  '" & ar_medpay2.Text() & "',"
        tsql += " ARStandardBasePrem=  '" & ar_baseprem2.Text() & "',"
        tsql += " ARStandardOptions=  '" & ar_options2.Text() & "',"
        tsql += " ARStandardFees=  '" & ar_fees2.Text() & "',"
        tsql += " ARStandardTax=  '" & ar_tax2.Text() & "',"
        tsql += " ARStandardTotal=  '" & ar_total2.Text() & "',"
        tsql += " ARStandardAOPOpt=  '" & dd_aop_AR2.SelectedValue.ToString & "',"
        tsql += " ARStandardHurDedOpt=  '" & dd_hurded_AR2.SelectedValue.ToString & "',"
        tsql += " ARStandardPerLiabOpt=  '" & dd_pl_AR2.SelectedValue.ToString & "',"
        tsql += " ARStandardMedPayOpt=  '" & dd_mp_AR2.SelectedValue.ToString & "',"
        tsql += " ARStandardOthStrucOpt=  '" & txt_unattstr_AR2.Text() & "',"
        tsql += " ARStandardContOpt =  '" & txt_pp_AR2.Text() & "',"
        tsql += " ARStandardMHRepOpt=  '" & dd_mhr_AR2.SelectedValue.ToString & "',"
        tsql += " ARStandardContRepOpt=  '" & dd_rep_AR2.SelectedValue.ToString & "',"
        tsql += " ARStandardAddRadOpt=  '" & txt_addlimrad_AR2.Text() & "',"
        tsql += " ARStandardAddFireOpt=  '" & txt_addlimfir_AR2.Text() & "',"
        tsql += " ARStandardSIPOpt=  '" & dd_sip_AR2.SelectedValue.ToString & "',"
        tsql += " ARStandardNDPOpt=  '" & dd_ndp_AR2.SelectedValue.ToString & "',"
        tsql += " ARStandardAddResOpt=  '" & dd_addresOpt_ar2.SelectedValue.ToString & "',"
        tsql += " ARStandardAddResLiabOpt=  '" & dd_addresliab_ar2.SelectedValue.ToString & "',"
        tsql += " ARStandardAddResMedOpt=  '" & dd_addresMP_ar2.SelectedValue.ToString & "',"
        tsql += " ARStandardWatOpt=  '" & dd_waterCraft_ar2.SelectedValue.ToString & "',"
        tsql += " ARStandardWatLiabOpt=  '" & dd_waterCraftliab_ar2.SelectedValue.ToString & "',"
        tsql += " ARStandardWatMedOpt=  '" & dd_waterCraftMedpay_ar2.SelectedValue.ToString & "',"
        tsql += " ARStandardValOpt=  '" & dd_PackagePerProp_ar2.SelectedValue.ToString & "',"

        tsql += " ARStandardDwellingPrem=  '" & txt_dwell_AR2_Amount.Text & "',"
        tsql += " ARStandardPerPropPrem=  '" & txt_pp_AR2_Amount.Text & "',"
        tsql += " ARStandardAddStrucPrem=  '" & txt_unattstr_AR2_Amount.Text & "',"
        tsql += " ARStandardPerLiabPrem=  '" & dd_pl_AR2_Amount.Text & "',"
        tsql += " ARStandardDedChangePrem=  '" & txt_DedChange_AR2_Amount.Text & "',"
        tsql += " ARStandardPerPropRepPrem=  '" & dd_rep_AR2_Amount.Text & "',"
        tsql += " ARStandardMHRepPrem=  '" & dd_mhr_AR2_Amount.Text & "',"
        tsql += " ARStandardFirePrem=  '" & txt_addlimfir_AR2_Amount.Text & "',"
        tsql += " ARStandardCredits=  '" & txt_Credit_AR2_Amount.Text & "',"
        tsql += " ARStandardAddRadPrem=  '" & txt_addlimrad_AR2_Amount.Text & "',"
        tsql += " ARStandardSupHeatFee=  '" & supHeating_ar2_Amount.Text & "',"
        tsql += " ARStandardCEAFee=  '" & CEA_ar2_Amount.Text & "',"
        tsql += " ARStandardSeasonalFee=  '" & SeasonalFee_ar2_Amount.Text & "',"
        tsql += " Ansi_Asce= '" & ddansi.SelectedValue.ToString & "',"

        tsql += " ARStandardRadioprem= '" & txt_addlimrad_AR2_Amount.Text & "',"
        tsql += " ARStandardFireServPrem= '" & txt_addlimfir_AR2_Amount.Text & "',"
        tsql += " ARStandardSecIntPrem= '" & dd_sip_AR2_Amount.Text & "',"
        tsql += " ARStandardNatDisPrem= '" & dd_ndp_AR2_Amount.Text & "',"
        tsql += " ARStandardAddResPrem= '" & dd_addresOpt_ar2_Amount.Text & "',"
        tsql += " ARStandardWaterPrem= '" & dd_waterCraft_ar2_Amount.Text & "',"
        tsql += " ARStandardVPerPropPrem= '" & dd_PackagePerProp_ar2_Amount.Text & "',"

        tsql += "dateUpdated =  getDate() "
        tsql += " WHERE  quoteID = '" & quoteID & "'"


        If dd_PackagePerProp_ar2.SelectedValue = "Yes" Then
            dsar2 = CType(Session("DataSet2"), DataSet)
            Dim ds2 As System.Data.DataSet
            Dim tsql2 As String

            tsql2 = "Delete From tblARPersonProp where quoteID = '" & quoteID & "' and prem_type = 'Standard'"

            ds2 = runQueryDS(tsql2, "ColonialMHConnectionString")
            If dsar2.Tables(0).Rows.Count > 0 Then
                For Each row As DataRow In dsar2.Tables(0).Rows
                    addPersProp(quoteID, "Standard", row("description").ToString, row("value").ToString)
                Next


            Else
                'no rows.
            End If

        End If
        Try
            ds = runQueryDS(tsql, "ColonialMHConnectionString")
        Catch ex As Exception
            errortrap(tsql, "UpdateAR2Prem", ex.Message)
        End Try
    End Sub
    'Rental
    Public Sub UpdateAR3Prem(ByVal quoteID As String)
        Dim ds As System.Data.DataSet
        ds = runQueryDS("SELECT * FROM tblARQuotes WHERE  quoteID = '" & quoteID & "'", "ColonialMHConnectionString")
        If ds.Tables(0).Rows.Count <= 0 Then
            saveARPrem(quoteID)
            Exit Sub
        End If
        Dim tsql As String
        tsql = "UPDATE tblARQuotes SET "
        tsql += " ARRentalDwelling=  '" & ar_dwell3.Text() & "',"
        tsql += " ARRentalOthStruc=  '" & ar_unattStr3.Text() & "',"
        tsql += " ARRentalContents=  '" & ar_perEff3.Text() & "',"
        tsql += " ARRentalLiab=  '" & ar_perLiab3.Text() & "',"
        tsql += " ARRentalMedPay=  '" & ar_medpay3.Text() & "',"
        tsql += " ARRentalBasePrem=  '" & ar_baseprem3.Text() & "',"
        tsql += " ARRentalOptions=  '" & ar_options3.Text() & "',"
        tsql += " ARRentalFees=  '" & ar_fees3.Text() & "',"
        tsql += " ARRentalTax=  '" & ar_tax3.Text() & "',"
        tsql += " ARRentalTotal=  '" & ar_total3.Text() & "',"
        tsql += " ARRentalAOPOpt=  '" & dd_aop_AR3.SelectedValue.ToString & "',"
        tsql += " ARRentalHurDedOpt=  '" & dd_hurded_AR3.SelectedValue.ToString & "',"
        tsql += " ARRentalPerLiabOpt=  '" & dd_pl_AR3.SelectedValue.ToString & "',"
        tsql += " ARRentalMedPayOpt=  '" & dd_mp_AR3.SelectedValue.ToString & "',"
        tsql += " ARRentalOthStrucOpt=  '" & txt_unattstr_AR3.Text() & "',"
        tsql += " ARRentalContOpt =  '" & txt_pp_AR3.Text() & "',"

        tsql += " ARRentalAddRadOpt=  '" & txt_addlimrad_AR3.Text() & "',"
        tsql += " ARRentalAddFireOpt=  '" & txt_addlimfir_AR3.Text() & "',"
        tsql += " ARRentalSIPOpt=  '" & dd_sip_AR3.SelectedValue.ToString & "',"
        tsql += " ARRentalNDPOpt=  '" & dd_ndp_AR3.SelectedValue.ToString & "',"

        tsql += " ARRentalDwellingPrem=  '" & txt_dwell_AR3_Amount.Text & "',"

        tsql += " ARRentalDedChangePrem=  '" & txt_DedChange_AR3_Amount.Text & "',"
        tsql += " ARRentalCredits=  '" & txt_Credit_AR3_Amount.Text & "',"
        tsql += " ARRentalSupHeatFee=  '" & supHeating_ar3_Amount.Text & "',"
        tsql += " ARRentalCEAFee=  '" & CEA_ar3_Amount.Text & "',"
        tsql += " Ansi_Asce= '" & ddansi.SelectedValue.ToString & "',"

        tsql += " ARRentalRadioprem=  '" & txt_addlimrad_AR3_Amount.Text & "',"
        tsql += " ARRentalFireServPrem=  '" & txt_addlimfir_AR3_Amount.Text & "',"
        tsql += " ARRentalSecIntPrem=  '" & dd_sip_AR3_Amount.Text & "',"
        tsql += " ARRentalNatDisPrem=  '" & dd_ndp_AR3_Amount.Text & "',"


        tsql += "dateUpdated =  getDate() "
        tsql += " WHERE  quoteID = '" & quoteID & "'"
        Try
            ds = runQueryDS(tsql, "ColonialMHConnectionString")
        Catch ex As Exception
            errortrap(tsql, "UpdateAR3Prem", ex.Message)
        End Try
    End Sub


    '****************************************************
    'End  Save
    '****************************************************


    Protected Sub MainMenu_ItemClick(ByVal sender As Object, ByVal e As Telerik.Web.UI.RadMenuEventArgs)
        Select Case e.Item.Value
            Case "New"
                Response.Redirect("/Quote/quote.aspx")
        End Select


    End Sub
    Public Sub calc_Clicked(ByVal sender As Object, ByVal e As System.EventArgs) Handles prmbtn.Click

        Try


            ASPxPopupControl1.ShowOnPageLoad = False
            ASPxPopupControl1.Enabled = False
            Dim value As Integer = 0
            If IsNumeric(txtcvgamt.Text) Then
                value = CInt(txtcvgamt.Text)

            End If
            Dim showlloyd As Boolean = False
            Dim UWStr As String
            If lblState.Text <> "FL" Then

                If lblState.Text = "DE" Then
                    If distToCoastDD.SelectedValue <> "Less than 0.5 miles" Then
                        If homeusedd.SelectedValue = "Tenant" Or homeusedd.SelectedValue = "Vacant" Then
                            showlloyd = False
                            ARFLtbl.Visible = False
                        Else
                            Lloyds1.loadpremdata(txtcvgamt.Text, lblState.Text, typedd.SelectedValue, manfdd.SelectedValue, txtYear.Text, txtCounty.Text, lblquoteNumber.Text, homeusedd.SelectedValue, distToCoastDD.SelectedValue, protclassdd.SelectedValue, liendd.SelectedValue, supheatdd.SelectedValue, txtDOB1.Text, skirtdd.SelectedValue, txtSubNumber.Text, lapsdd.SelectedValue, cddlCity.SelectedValue, txtEffDate.Text, aegisterritorylbl.Text)
                            'Lloyds1.Visible = True
                            showlloyd = True
                            ARFLtbl.Visible = False
                        End If

                    Else
                        ' Lloyds1.Visible = False
                        showlloyd = False
                        ARFLtbl.Visible = False
                    End If

                End If

                If lblState.Text = "SC" Or lblState.Text = "NC" Or lblState.Text = "GA" Or lblState.Text = "VA" Or lblState.Text = "TN" Then
                    If IsNumeric(txtcvgamt.Text) Then
                        If CInt(txtcvgamt.Text) > 150000 Then
                            ASPxPopupControl1.HeaderText = "Ineligible"
                            UWStr = "Ineligible – Maximum Coverage A limit is $150,000"

                        Else



                            'commented out for Vickie on 12/12/2013 to allow Amslic quoting
                            'If distToCoastDD.SelectedValue <> "Less than 2 miles" And distToCoastDD.SelectedValue <> "" Then
                            Lloyds1.loadpremdata(txtcvgamt.Text, lblState.Text, typedd.SelectedValue, manfdd.SelectedValue, txtYear.Text, txtCounty.Text, lblquoteNumber.Text, homeusedd.SelectedValue, distToCoastDD.SelectedValue, protclassdd.SelectedValue, liendd.SelectedValue, supheatdd.SelectedValue, txtDOB1.Text, skirtdd.SelectedValue, txtSubNumber.Text, lapsdd.SelectedValue, cddlCity.SelectedValue, txtEffDate.Text, aegisterritorylbl.Text)
                            'Lloyds1.Visible = True
                            showlloyd = True

                            '    ARFLtbl.Visible = False
                            'Else

                            '    UWStr = ""
                            '    UWStr += "Ineligible for the following reason(s) Distance to Coast =:  " & vbCrLf & distToCoastDD.SelectedValue()
                            '    ASPxPopupControl1.Enabled = True
                            '    Label173.Text = UWStr
                            '    ASPxPopupControl1.PopupElementID = "prmbtn"
                            '    ASPxPopupControl1.ShowOnPageLoad = True
                            '    ' Lloyds1.Visible = False
                            '    showlloyd = False
                            '    ARFLtbl.Visible = False
                            'End If
                        End If
                        Dim supHeatIngel As Boolean
                        If supheatdd.SelectedValue = "No" Or (supheatdd.SelectedValue = "Yes" And (supHeatTypedd.SelectedValue.ToString = " " Or supHeatTypedd.SelectedValue.ToString = "Woodstove installed by a licensed contractor" Or supHeatTypedd.SelectedValue.ToString = "Fireplace installed by the manufacturer or licensed contractor")) Then
                            supHeatIngel = True
                        Else
                            If supHeatTypedd.SelectedValue.ToString = "Woodstove installed by a licensed contractor" Or supHeatTypedd.SelectedValue.ToString = "Portable Space Heater" Or supHeatTypedd.SelectedValue.ToString = "Heat reclaiming device" Then
                                ASPxPopupControl1.HeaderText = "Submit Underwriter"
                                UWStr = "Please Submit to Underwriter for the following reason(s):  " & vbCrLf & supHeatTypedd.SelectedValue.ToString
                            Else
                                ASPxPopupControl1.HeaderText = "Ineligible"
                                UWStr = "Ineligible for the following reason(s):  " & vbCrLf & supHeatTypedd.SelectedValue.ToString
                            End If
                            supHeatIngel = False
                            showlloyd = False
                        End If
                        If homeusedd.SelectedValue = "Tenant" Or homeusedd.SelectedValue = "Vacant" Then
                            ASPxPopupControl1.HeaderText = "Ineligible"
                            UWStr = "Ineligible for the following reason(s):  Home use is " & homeusedd.SelectedValue
                            showlloyd = False
                        End If
                        If skirtdd.SelectedValue = "" Then
                            ASPxPopupControl1.HeaderText = "Ineligible"
                            UWStr = "Ineligible for the following reason(s):  Skirting = " & skirtdd.SelectedValue
                            showlloyd = False
                        End If
                        If lapsdd.SelectedValue = "Yes" Or lapsdd.SelectedValue = "" Then
                            ASPxPopupControl1.HeaderText = "Submit Underwriter"
                            UWStr = "Please Submit to Underwriter for the following reason(s):  " & vbCrLf & "Lapse in Coverage = Yes"
                            showlloyd = True
                        End If

                        If showlloyd = True Then

                            Lloyds1.Visible = True
                        Else
                            ASPxPopupControl1.Enabled = True
                            Label173.Text = UWStr
                            ASPxPopupControl1.PopupElementID = "prmbtn"
                            ASPxPopupControl1.ShowOnPageLoad = True
                            Lloyds1.Visible = False

                        End If
                    Else
                        Lloyds1.Visible = False
                        ARFLtbl.Visible = True
                        setARDefaults(value)
                        calc()
                    End If


                End If
                If showlloyd = True Then
                    Lloyds1.Visible = True
                Else
                    ASPxPopupControl1.Enabled = True
                    Label173.Text = UWStr
                    ASPxPopupControl1.PopupElementID = "prmbtn"
                    ASPxPopupControl1.ShowOnPageLoad = True
                    Lloyds1.Visible = False

                End If

            Else
                ARFLtbl.Visible = True
                setARDefaults(value)
                calc()
            End If
        Catch ex As Exception
            errortrap("Calculate Prem button " & lblquoteNumber.Text, "Prem calculating", ex.Message & " /// " & ex.Source.ToString & " ***** " & ex.Data.ToString & " ###### " & ex.InnerException.ToString & " @@@@ " & ex.StackTrace.ToString)
            ASPxPopupControl1.Enabled = True
            Label173.Text = "This has Caused an Error: " & ex.Message
            ASPxPopupControl1.PopupElementID = "prmbtn"
            ASPxPopupControl1.ShowOnPageLoad = True
        End Try
    End Sub
    Protected Sub calc()
        Try


            ASPxPopupControl1.ShowOnPageLoad = True
            ASPxPopupControl1.Enabled = True
            If distToCoastDD.SelectedValue = "2 – 5 miles" Or distToCoastDD.SelectedValue = "0.5 – 5 miles" Then
                whtxt.Text = "$1,500"
            Else
                whtxt.Text = "$1,000"
            End If
            Dim UWStr As String
            UWStr = ""
            If distToCoastDD.SelectedValue = "Less than 2 miles" Or distToCoastDD.SelectedValue = "Less than 0.5 miles" Then
                llydstbl.Attributes.Add("style", "display:none")
                ARFLtbl.Attributes.Add("style", "display:none")
                UWStr = UWStr = "Ineligible for the following reason(s):  " & vbCrLf & distToCoastDD.SelectedValue()

                Label173.Text = UWStr
                ASPxPopupControl1.PopupElementID = "prmbtn"
                ASPxPopupControl1.ShowOnPageLoad = True
            Else
                '***************************************************************
                'Lloyds Rates
                'This is where we show lloyds and hide the rest!
                If lblState.Text = "DE" Then
                    llydstbl.Attributes.Add("style", "display:block")
                    calcLloyds()
                    LoadLloydsFees()
                    calcLloydsCredits()
                    calcLloydsTotals()
                Else
                    llydstbl.Attributes.Add("style", "display:none")
                End If
                'End Lloyds Rates

                '***************************************************************
                'FL AR Rates
                Dim supHeatIngel, skirting, vacant As Boolean
                If supheatdd.SelectedValue = "No" Or (supheatdd.SelectedValue = "Yes" And (supHeatTypedd.SelectedValue.ToString = " " Or supHeatTypedd.SelectedValue.ToString = "Woodstove installed by a licensed contractor" Or supHeatTypedd.SelectedValue.ToString = "Fireplace installed by the manufacturer or licensed contractor")) Then
                    supHeatIngel = True
                Else
                    If supHeatTypedd.SelectedValue.ToString = "Woodstove installed by a licensed contractor" Or supHeatTypedd.SelectedValue.ToString = "Portable Space Heater" Or supHeatTypedd.SelectedValue.ToString = "Heat reclaiming device" Then
                        ASPxPopupControl1.HeaderText = "Submit Underwriter"
                        UWStr = "Please Submit to Underwriter for the following reason(s):  " & vbCrLf & supHeatTypedd.SelectedValue.ToString
                    Else
                        ASPxPopupControl1.HeaderText = "Ineligible"
                        UWStr = "Ineligible for the following reason(s):  " & vbCrLf & supHeatTypedd.SelectedValue.ToString
                    End If
                    supHeatIngel = False
                End If
                If skirtdd.SelectedValue.ToString = "None" Then
                    skirting = False
                Else
                    skirting = True
                End If
                If homeusedd.SelectedValue.ToString = "Vacant" Then
                    vacant = False
                Else
                    vacant = True
                End If

                If lblState.Text = "FL" And supHeatIngel And skirting And vacant Then
                    calcAR()
                    ARFLtbl.Attributes.Add("style", "display:block")
                    ARFLtbl.Visible = True
                Else
                    ASPxPopupControl1.Enabled = True
                    MessageBox(UWStr)
                    Label173.Text = UWStr
                    ASPxPopupControl1.PopupElementID = "prmbtn"
                    ASPxPopupControl1.ShowOnPageLoad = True
                    ''ASPxPopupControl1.ClientSideEvents.Init = "function(s, e) { s.ShowAtElementByID('popupanchor'); }"
                    'Dim pp As ASPxPopupControl = TryCast(Content.FindControl("ASPxPopupControl1"), ASPxPopupControl)
                    'pp.ShowOnPageLoad = True
                    ARFLtbl.Attributes.Add("style", "display:none")
                End If
                'End FL AR Rates
            End If

            Dim lbl As New Label()
            lbl.Text = "<script language='javascript'> ARIsLienHolder(); ARsupHeating(); ARHideShowQuestions(); ARCalcTotals(); OnhomeUseDDSelectedIndexChange(); ARHideShowQuestions();ARShowStandardMedPay();" & "<" & "/script>"
            Page.Controls.Add(lbl)
            SelectSub()
        Catch ex As Exception
            errortrap("Calculate " & lblquoteNumber.Text, "calculating", ex.Message & " @@@@ " & ex.StackTrace.ToString)
        End Try
    End Sub


    '****************************************************
    ' Premimum
    '****************************************************
    'AR
    '**************************************************
    'This sub will handle changes to the AR package options section
    Public Sub ar_premiumbtnClick(ByVal sender As Object, ByVal e As System.EventArgs) Handles ar1_updateOptions.Click
        'AR1_Debug.Text = ""
        'AR2_Debug.Text = ""
        'AR3_Debug.Text = ""

        If dd_PackagePerProp_AR1.SelectedValue = "No" Then
            packagePerPropValue.Text = "0.00"
            dd_PackagePerProp_AR1_Amount.Text = "0.00"
        End If
        ARFLtbl.Visible = True
        'setARDefaults(value)
        'calc()
        '' calcAR()
        calcAR()
        ARFLtbl.Attributes.Add("style", "display:block")
        ModalPopupExtender2.CancelControlID = "btnCloseCalc"
        ModalPopupExtender2.PopupControlID = "PremiumCalcPanel"
        ModalPopupExtender2.Enabled = "True"
        ModalPopupExtender2.TargetControlID = "btnClosePremCalc"

        ARFLtbl.Visible = True
        'Set Visiblity on hidden fields
        ARSetFields()
        showARSections()
        AR_PremiumUpdatePanel.Update()
        'Dim lbl As New Label()
        'lbl.Text = "<script language='javascript'>  ARCalcTotals();  " & "<" & "/script>"
        'Page.Controls.Add(lbl)

        'Dim lbl As New Label()
        'lbl.Text = "<script language='javascript'> ARIsLienHolder(); ARsupHeating(); ARHideShowQuestions(); ARCalcTotals(); OnhomeUseDDSelectedIndexChange(); ARHideShowQuestions();ARShowStandardMedPay();" & "<" & "/script>"
        'Page.Controls.Add(lbl)
        If dd_PackagePerProp_AR1.SelectedValue = "Yes" Then
            trvalPPl.Style.Item("display") = ""
        Else
            trvalPPl.Style.Item("display") = "none"

        End If
        If liendd.SelectedValue = "Yes" Then
            trmhAROpt1_2.Style.Item("display") = ""
            trmhAROpt1_2_d.Style.Item("display") = ""
            trmhAROpt1.Style.Item("display") = ""
            trmhAROpt1_d.Style.Item("display") = ""
        End If
        If dd_addresOpt_ar1.Text <> "" Then
            AR_AddResOpt1_ar1.Style.Item("display") = ""
            AR_AddResOpt2_ar1.Style.Item("display") = ""

        End If
        If dd_waterCraft_AR1.Text <> "" Then
            AR_WaterCraftOpt1_ar1.Style.Item("display") = ""
            AR_WaterCraftOpt2_ar1.Style.Item("display") = ""
        End If
        If supheatdd.SelectedValue = "Yes" Then
            trheating.Style.Item("display") = ""
        End If


        If Request.QueryString("quoteID") <> "" Or Session("beenSaved") = "True" Then
            updateQuote(Request.QueryString("quoteID"))
        Else 'New Quote
            save()
        End If

    End Sub
    Public Sub ar_premiumbtnClick2(ByVal sender As Object, ByVal e As System.EventArgs) Handles ar2_updateOptions.Click
        AR1_Debug.Text = ""
        AR2_Debug.Text = ""
        AR3_Debug.Text = ""
        calcAR()
        ARFLtbl.Attributes.Add("style", "display:block")
        ARFLtbl.Visible = True
        'Set Visiblity on hidden fields
        ARSetFields()
        showARSections()
        AR_PremiumUpdatePanel.Update()
        'Dim lbl As New Label()
        'lbl.Text = "<script language='javascript'>  ARCalcTotals();  " & "<" & "/script>"
        'Page.Controls.Add(lbl)

        If dd_PackagePerProp_ar2.SelectedValue = "Yes" Then
            vpplAR2.Style.Item("display") = ""
        Else
            vpplAR2.Style.Item("display") = "none"

        End If
        If liendd.SelectedValue = "Yes" Then
            trmhAROpt2_2.Style.Item("display") = ""
            trmhAROpt2_2_d.Style.Item("display") = ""
            trmhAROpt2.Style.Item("display") = ""
            trmhAROpt2_d.Style.Item("display") = ""
        End If
        If dd_addresOpt_ar2.Text <> "" Then
            AR_AddResOpt1_ar2.Style.Item("display") = ""
            AR_AddResOpt2_ar2.Style.Item("display") = ""

        End If
        If dd_waterCraft_ar2.Text <> "" Then
            AR_WaterCraftOpt1_ar2.Style.Item("display") = ""
            AR_WaterCraftOpt2_ar2.Style.Item("display") = ""
        End If
        If supheatdd.SelectedValue = "Yes" Then
            trheating2.Style.Item("display") = ""
        End If


        If Request.QueryString("quoteID") <> "" Or Session("beenSaved") = "True" Then
            updateQuote(Request.QueryString("quoteID"))
        Else 'New Quote
            save()
        End If
        AR_PremiumUpdatePanel.Update()
    End Sub
    Public Sub ar_premiumbtnClick3(ByVal sender As Object, ByVal e As System.EventArgs) Handles ar3_updateOptions.Click
        AR1_Debug.Text = ""
        AR2_Debug.Text = ""
        AR3_Debug.Text = ""
        calcAR()
        ARFLtbl.Attributes.Add("style", "display:block")
        ARFLtbl.Visible = True
        'Set Visiblity on hidden fields
        ARSetFields()
        showARSections()
        AR_PremiumUpdatePanel.Update()
        'Dim lbl As New Label()
        'lbl.Text = "<script language='javascript'>  ARCalcTotals();  " & "<" & "/script>"
        'Page.Controls.Add(lbl)
        If Request.QueryString("quoteID") <> "" Or Session("beenSaved") = "True" Then
            updateQuote(Request.QueryString("quoteID"))
        Else 'New Quote
            save()
        End If
        AR_PremiumUpdatePanel.Update()
    End Sub
    Public Sub selectAR1btn_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles selectAR1btn.Click
        HiddenFieldSelected.Value = "Package"
        rateTypelbl.Text = "Package"
        rateTypelbl.Font.Bold = True
        rateTypelbl.ForeColor = Drawing.Color.Green

        'Set Selected to AR1 in database
        Dim ds As System.Data.DataSet
        ds = runQueryDS("EXEC sp_SetQuoteRateType '" & lblquoteNumber.Text & "', 'Package'", "ColonialMHConnectionString")

        premiumBtnTable.Attributes.Add("style", "display:block")
    End Sub
    Public Sub selectAR2btn_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles selectAR2btn.Click
        HiddenFieldSelected.Value = "Standard"
        rateTypelbl.Text = "Standard"
        rateTypelbl.Font.Bold = True
        rateTypelbl.ForeColor = Drawing.Color.Green

        'Set Selected to AR1 in database
        Dim ds As System.Data.DataSet
        ds = runQueryDS("EXEC sp_SetQuoteRateType '" & lblquoteNumber.Text & "', 'Standard'", "ColonialMHConnectionString")

        premiumBtnTable.Attributes.Add("style", "display:block")
    End Sub
    Public Sub selectAR3btn_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles selectAR3btn.Click
        HiddenFieldSelected.Value = "Rental"
        rateTypelbl.Text = "Rental"
        rateTypelbl.Font.Bold = True
        rateTypelbl.ForeColor = Drawing.Color.Green

        'Set Selected to AR1 in database
        Dim ds As System.Data.DataSet
        ds = runQueryDS("EXEC sp_SetQuoteRateType '" & lblquoteNumber.Text & "', 'Rental'", "ColonialMHConnectionString")

        premiumBtnTable.Attributes.Add("style", "display:block")
    End Sub
    Public Sub calcAR()

        Dim territory As String
        Dim packagePremium, standardPremium, rentalPremium,
            packageOtherStructures, standardOtherStructures, rentalOtherStructures,
            packageContents, standardContents, rentalContents,
            CreditsPercentage,
            packageFee, standardFee, rentalFee,
            packageTotal, standardTotal, rentalTotal,
            packageMedFee, standardMedFee, rentalMedFee As Double
        Dim age As Integer = 0
        If IsNumeric(txtYear.Text) Then
            age = Now.Year - CInt(txtYear.Text)
        End If

        Dim protection As String = ""



        'Check county
        Dim ds As System.Data.DataSet
        ds = runQueryDS("SELECT territory FROM tblARTerritory WHERE UPPER(county) = UPPER('" & txtCounty.Text & "')", "ColonialMHConnectionString")
        If ds.Tables(0).Rows.Count > 0 Then
            territory = ds.Tables(0).Rows(0).Item("territory").ToString
        Else
            updateStatus("County not found")
            'no county mapping break
            Return
        End If
        'Get Coverage Values
        Dim value As Integer = 0
        If IsNumeric(txtcvgamt.Text) Then
            value = CInt(txtcvgamt.Text)
        End If

        'Set protection
        If protclassdd.SelectedValue > 8 Then
            protection = "unprotected"
        Else
            protection = "protected"
        End If


        If ar_dwell1.Text = "0.00" Then
            'set Program Defaults
            setARDefaults(value)
        End If


        '****************
        'BASE PREMIUMS
        '****************
        AR1_Debug.Text = ""
        AR2_Debug.Text = ""
        AR3_Debug.Text = ""
        AR1_Debug.Text = "<table> <tbody>"
        AR2_Debug.Text = "<table> <tbody>"
        AR3_Debug.Text = "<table> <tbody>"
        'Get Package Premiums
        ds = runQueryDS("EXEC sp_getARRates '" & territory & "','" & value & "','" & txt_unattstr_AR1.Text.Replace("$", "") & "','" & txt_pp_AR1.Text.Replace("$", "") & "'", "ColonialMHConnectionString")
        If ds.Tables(0).Rows.Count > 0 Then
            packagePremium = CInt(FormatCurrency(ds.Tables(0).Rows(0).Item("PackageRate").ToString))
            packageOtherStructures = CInt(FormatCurrency(ds.Tables(0).Rows(0).Item("PackageStructureRate").ToString))
            ''Changed per Vickie 06/18/2013
            'Dim packAnsi As Decimal
            'If ddansi.SelectedValue = "Yes" Then
            '    packAnsi = (packagePremium * 0.09)
            '    packagePremium = packagePremium - (packagePremium * 0.09)
            '    packageOtherStructures = packageOtherStructures - (packageOtherStructures * 0.09)

            'End If

            packageContents = CInt(FormatCurrency(ds.Tables(0).Rows(0).Item("PackagePersonalPropRate").ToString))
            txt_dwell_AR1_Amount.Text = packagePremium

            PackPrem = packagePremium
            ar_medpay1.Text = dd_mp_AR1.SelectedValue.ToString
            'If ddansi.SelectedValue = "Yes" Then
            '    AR1_Debug.Text += "<tr align=left><td> Package Dwelling Prem</td><td> " & packagePremium & " </td></tr> <tr align=left><td> ANSI/ASCE 7/88 Discount: </td><td> " & packAnsi & " </td></tr> <tr align=left><td> ANSI/ASCE 7/88 Base " & FormatCurrency(ds.Tables(0).Rows(0).Item("PackageRate").ToString) & " * 9% </td><td>  </td></tr> "
            'Else

            '    AR1_Debug.Text += "<tr align=left><td> Package Dwelling Prem</td><td> " & packagePremium & " </td></tr> "
            'End If

        Else
            'no rates found
        End If
        'Get Standard Premiums
        ds = runQueryDS("EXEC sp_getARRates '" & territory & "','" & value & "','" & txt_unattstr_AR2.Text.Replace("$", "") & "','" & txt_pp_AR2.Text.Replace("$", "") & "'", "ColonialMHConnectionString")
        If ds.Tables(0).Rows.Count > 0 Then

            standardPremium = CInt(FormatCurrency(ds.Tables(0).Rows(0).Item("StandardRate").ToString))
            standardOtherStructures = CInt(FormatCurrency(ds.Tables(0).Rows(0).Item("StandardStructureRate").ToString))
            standardContents = CInt(FormatCurrency(ds.Tables(0).Rows(0).Item("StandardPersonalPropRate").ToString))
            ''Change per vickie 06/18/2013
            'If ddansi.SelectedValue = "Yes" Then
            '    standardAnsi = (standardPremium * 0.09) + (standardOtherStructures * 0.09) + (standardContents * 0.09)
            '    AR2_Debug.Text += "<tr align=left><td> Standard Dwelling Prem</td><td> " & standardPremium & " </td></tr> <tr align=left><td> ANSI/ASCE 7/88 Discount: </td><td> " & standardAnsi & " </td></tr><tr align=left><td> ANSI/ASCE 7/88 Base + Structure + Contents  " & standardPremium + standardOtherStructures + standardContents & " * 9% </td><td>  </td></tr> "

            '    standardPremium = standardPremium - (standardPremium * 0.09)
            '    If standardOtherStructures > 0 Then
            '        standardOtherStructures = standardOtherStructures - (standardOtherStructures * 0.09)
            '    End If
            '    If standardContents > 0 Then
            '        standardContents = standardContents - (standardContents * 0.09)
            '    End If



            'Else
            '    AR2_Debug.Text += "<tr align=left><td> Standard Dwelling Prem</td><td> " & standardPremium & " </td></tr> "

            'End If
            txt_dwell_AR2_Amount.Text = standardPremium
            'Set Med Pay selected
            If dd_pl_AR2.SelectedValue.ToString = "$0" Then 'if liability is 0 then set Med pay to 0
                ar_medpay2.Text = "$0"
            Else
                ar_medpay2.Text = dd_mp_AR2.SelectedValue.ToString
            End If



            StandPrem = standardPremium
        Else
            'no rates found
        End If

        'Get Rental Premiums
        ds = runQueryDS("EXEC sp_getARRentalRates '" & territory & "','" & age & "','" & protection & "','" & value & "','" & txt_unattstr_AR3.Text.Replace("$", "") & "','" & txt_pp_AR3.Text.Replace("$", "") & "'", "ColonialMHConnectionString")
        If ds.Tables(0).Rows.Count > 0 Then
            rentalPremium = CInt(FormatCurrency(ds.Tables(0).Rows(0).Item("RentalRate").ToString))
            rentalOtherStructures = CInt(FormatCurrency(ds.Tables(0).Rows(0).Item("StructureRate").ToString))
            rentalContents = CInt(FormatCurrency(ds.Tables(0).Rows(0).Item("PersonalPropRate").ToString))
            ''removed per vickie 06/18/2013
            'Dim rentalAnsi As Decimal
            'If ddansi.SelectedValue = "Yes" Then
            '    rentalAnsi = (rentalPremium * 0.09) + (rentalOtherStructures * 0.09) + (rentalContents * 0.09)
            '    rentalPremium = rentalPremium - (rentalPremium * 0.09)
            '    rentalOtherStructures = rentalOtherStructures - (rentalOtherStructures * 0.09)
            '    rentalContents = rentalContents - (rentalContents * 0.09)

            '    AR3_Debug.Text += "<tr align=left><td> Rental Dwelling Prem</td><td> " & rentalPremium & " </td></tr>  <tr align=left><td> ANSI/ASCE 7/88 Discount: </td><td> " & rentalAnsi & " </td></tr> "
            'Else
            '    AR3_Debug.Text += "<tr align=left><td> Rental Dwelling Prem</td><td> " & rentalPremium & " </td></tr> "
            'End If
            txt_dwell_AR2_Amount.Text = rentalPremium

            RentPrem = rentalPremium
        Else
            'no rates found
        End If



        '**********************************************
        'SET VALUES
        packageTotal = packagePremium
        standardTotal = standardPremium
        rentalTotal = rentalPremium


        '**********************************************
        'CREDITS
        'get Credits
        CreditsPercentage = getCredits()
        CreditPerc = CreditsPercentage

        'Package
        AR1_Debug.Text += "<tr align=left><td> Hurricane & Non Hurricane Premium </td><td> $" & CInt(packagePremium) & " </td></tr> "
        AR1_Debug.Text += "<tr align=left><td> Credits %</td><td> " & CreditsPercentage * 100 & "% </td></tr> "
        AR1_Debug.Text += "<tr align=left><td> Credits Value</td><td>-" & Math.Round((packagePremium * CreditsPercentage), 0, MidpointRounding.AwayFromZero) & " </td></tr> "
        packageTotal = (packagePremium - Math.Round((packagePremium * CreditsPercentage), 0, MidpointRounding.AwayFromZero))

        'AR1_Debug.Text += "<tr align=left><td> Credits Value</td><td>-" & Math.Round((packagePremium * CreditsPercentage), 0, MidpointRounding.AwayFromZero) & " </td></tr> "
        'Dim MHage As Integer = 0
        'If IsNumeric(txtYear.Text) Then
        '    MHage = Now.Year - CInt(txtYear.Text.Substring(txtYear.Text.Length - 4, 4))
        'End If

        'If MHage >= 21 Then
        '    'Package
        '    packageTotal += CInt(CDbl(packagePremium) * 0.065)
        '    ' AR1_Debug.Text += "<tr align=left><td>MH AGE 21 YRS OLDER  </td><td>" & CInt((CDbl(packagePremium) * 0.065)) & " </td></tr> "
        '    AR1_Debug.Text += "<tr align=left><td> Credits Value + MH Age Prem (-" & Math.Round((packagePremium * CreditsPercentage), 0, MidpointRounding.AwayFromZero) & " + " & CInt((CDbl(packagePremium) * 0.065)) & ")  </td><td>-" & Math.Round((packagePremium * CreditsPercentage), 0, MidpointRounding.AwayFromZero) - CInt((CDbl(packagePremium) * 0.065)) & " </td></tr> "
        '    ''Standard NO MH AGE on Standar
        '    'standardTotal += (CDbl(standardPremium) * 0.065)
        '    'AR2_Debug.Text += "<tr align=left><td>MH AGE 21 YRS OLDER  </td><td>" & (CDbl(standardPremium) * 0.065) & " </td></tr> "
        'Else
        '    AR1_Debug.Text += "<tr align=left><td> Credits Value</td><td>-" & Math.Round((packagePremium * CreditsPercentage), 0, MidpointRounding.AwayFromZero) & " </td></tr> "

        'End If





        'Standard
        AR2_Debug.Text += "<tr align=left><td> Hurricane & Non Hurricane Premium </td><td> $" & CInt(standardPremium) & " </td></tr> "
        AR2_Debug.Text += "<tr align=left><td> Credits %</td><td> " & CreditsPercentage * 100 & "% </td></tr> "
        AR2_Debug.Text += "<tr align=left><td> Credits Value</td><td>-" & Math.Round((standardPremium * CreditsPercentage), 0, MidpointRounding.AwayFromZero) & " </td></tr> "
        standardTotal = (standardPremium - Math.Round((standardPremium * CreditsPercentage), 0, MidpointRounding.AwayFromZero))
        'NO Credits for Rental Package
        AR3_Debug.Text += "<tr align=left><td> Hurricane & Non Hurricane Premium </td><td> $" & CInt(rentalPremium) & " </td></tr> "
        '**********************************************
        AR1_Debug.Text += "<tr align=left><td>PACKAGE TOTAL </td><td>" & CInt(packageTotal) & " </td></tr> "
        AR2_Debug.Text += "<tr align=left><td>COVERAGE TOTAL </td><td>" & CInt(standardTotal) & " </td></tr> "
        AR3_Debug.Text += "<tr align=left><td>RENTAL TOTAL </td><td>" & CInt(rentalTotal) & " </td></tr> "

        '----------------------------
        'Package structure and contents

        '*/*/*/*/*/**/*/*/*/*/*/*/*/*/*/*/*/*/*/*/*/*/*/*/*/*/*/*/*/*/*/*/*

        If IsNumeric(txt_unattstr_AR1.Text) And IsNumeric(txtcvgamt.Text) Then


            If CDbl(txt_unattstr_AR1.Text) > (CDbl(txtcvgamt.Text) * 0.1) Then ' if other structures greater than default (10%) covered amount add.
                'packageTotal += packageContents
                ' ar_perEff1.Text = FormatCurrency(txt_pp_AR1.Text).ToString
                If (FormatCurrency(ar_unattStr1.Text) < FormatCurrency(txt_unattstr_AR1.Text)) Or (FormatCurrency(ar_unattStr1.Text) > (CDbl(txtcvgamt.Text) * 0.1)) Then
                    'If FormatCurrency(ar_unattStr1.Text) > (CDbl(txtcvgamt.Text) * 0.1) Then
                    'Dim attdiff As Integer = FormatCurrency(txt_unattstr_AR1.Text) - FormatCurrency(ar_unattStr1.Text)
                    Dim attdiff As Integer = FormatCurrency(txt_unattstr_AR1.Text) - (CDbl(txtcvgamt.Text) * 0.1)
                    ds = runQueryDS("EXEC sp_getARRates '" & territory & "','" & value & "','" & attdiff & "','" & txt_pp_AR1.Text.Replace("$", "") & "'", "ColonialMHConnectionString")
                    If ds.Tables(0).Rows.Count > 0 Then
                        'packagePremium = FormatCurrency(ds.Tables(0).Rows(0).Item("PackageRate").ToString)
                        packageOtherStructures = FormatCurrency(ds.Tables(0).Rows(0).Item("PackageStructureRate").ToString)
                        'packageContents = FormatCurrency(ds.Tables(0).Rows(0).Item("PackagePersonalPropRate").ToString)
                        'txt_dwell_AR1_Amount.Text = packagePremium
                        'AR1_Debug.Text += "<tr align=left><td> Package Dwelling Prem</td><td> " & packagePremium & " </td></tr> "
                        'PackPrem = packagePremium


                    Else
                        'no rates found
                    End If
                    txt_unattstr_AR1_Amount.Text = CInt(FormatCurrency(packageOtherStructures).ToString)

                    AR1_Debug.Text += "<tr align=left><td>Package Other Struc Prem  </td><td> " & packageOtherStructures & "  </td></tr> " '<tr align=left><td> ANSI/ASCE 7/88 Other Structure " & FormatCurrency(packageOtherStructures) & " * 9% = </td><td>-" & CInt((packageOtherStructures * 0.09)) & "</td><td>  </td></tr>"
                    'packageOtherStructures = packageOtherStructures - CInt(packageOtherStructures * 0.09)
                    packageTotal += packageOtherStructures
                    ar_unattStr1.Text = FormatCurrency(txt_unattstr_AR1.Text)
                    ' AR1_Debug.Text += "<tr align=left><td>Package Other Struc Prem  </td><td> " & packageOtherStructures & "  </td></tr>  "





                Else
                    If txt_unattstr_AR1_Amount.Text = "0.00" Then
                        ar_unattStr1.Text = FormatCurrency(txt_unattstr_AR1.Text)
                        AR1_Debug.Text += "<tr align=left><td>Package Other Struc Prem  </td><td> " & CInt(packageOtherStructures) & "  </td></tr>  "
                        packageTotal += packageOtherStructures
                        ar_unattStr1.Text = FormatCurrency(txt_unattstr_AR1.Text).ToString
                        If FormatCurrency(ar_unattStr1.Text) <> FormatCurrency((CDbl(txtcvgamt.Text) * 0.1)) Then
                            txt_unattstr_AR1_Amount.Text = CInt(FormatCurrency(packageOtherStructures).ToString)
                        End If
                    End If
                End If

                ' AR1_Debug.Text += "<tr align=left><td>Package Other Struc Prem   </td><td> 0.00  </td></tr>  "
            Else
                ar_unattStr1.Text = CInt(FormatCurrency(txt_unattstr_AR1.Text))
                'AR1_Debug.Text += "<tr align=left><td>Package Other Struc Prem  </td><td> " & packageOtherStructures & "  </td></tr>  "
                AR1_Debug.Text += "<tr align=left><td>Package Other Struc Prem   </td><td> 0.00  </td></tr>  "
                txt_unattstr_AR1_Amount.Text = "0.00"
                ar_unattStr1.Text = FormatCurrency(txt_unattstr_AR1.Text).ToString
                Dim test As String = FormatCurrency(Math.Round(CDbl(txtcvgamt.Text) * 0.1))
                If FormatCurrency(ar_unattStr1.Text) <> FormatCurrency(Math.Round(CDbl(txtcvgamt.Text) * 0.1)) Then
                    txt_unattstr_AR1_Amount.Text = FormatCurrency(packageOtherStructures).ToString
                End If

            End If
        End If
        'Person Content
        If IsNumeric(txt_pp_AR1.Text) And IsNumeric(txtcvgamt.Text) Then


            If CDbl(txt_pp_AR1.Text) > (CDbl(txtcvgamt.Text) * 0.4) Then ' if personal effects greater than default (40%) covered amount add.
                'packageTotal += packageOtherStructures

                If (FormatCurrency(ar_perEff1.Text) < FormatCurrency(txt_pp_AR1.Text)) Or (CDbl(txt_pp_AR1.Text) > (CDbl(txtcvgamt.Text) * 0.4)) Then
                    ' If FormatCurrency(ar_perEff1.Text) > (CDbl(txtcvgamt.Text) * 0.4) Then
                    'Dim ppdiff As Integer = CInt(txt_pp_AR1.Text) - CInt(ar_perEff1.Text)
                    Dim ppdiff As Integer = CInt(ar_perEff1.Text) - (CDbl(txtcvgamt.Text) * 0.4)
                    ds = runQueryDS("EXEC sp_getARRates '" & territory & "','" & value & "','" & txt_unattstr_AR1.Text.Replace("$", "") & "','" & ppdiff & "'", "ColonialMHConnectionString")
                    If ds.Tables(0).Rows.Count > 0 Then
                        'packagePremium = FormatCurrency(ds.Tables(0).Rows(0).Item("PackageRate").ToString)
                        ' packageOtherStructures = FormatCurrency(ds.Tables(0).Rows(0).Item("PackageStructureRate").ToString)
                        packageContents = CInt(FormatCurrency(ds.Tables(0).Rows(0).Item("PackagePersonalPropRate").ToString))
                        'txt_dwell_AR1_Amount.Text = packagePremium
                        'AR1_Debug.Text += "<tr align=left><td> Package Dwelling Prem</td><td> " & packagePremium & " </td></tr> "
                        'PackPrem = packagePremium


                    Else
                        'no rates found
                    End If
                    'If ddansi.SelectedValue = "Yes" Then
                    '    AR1_Debug.Text += "<tr align=left><td>Package Contents Prem  </td><td> " & packageContents.ToString() & "  </td></tr> <tr align=left><td> ANSI/ASCE 7/88 Other Contents " & FormatCurrency(packageContents) & " * 9% = -" & String.Format("{0:C}", (packageContents * 0.09)) & "</td><td>  </td></tr>"
                    '    packageContents = packageContents - CInt(packageContents * 0.09)
                    'Else
                    ' AR1_Debug.Text += "<tr align=left><td>Package Other Struc Prem  </td><td> " & packageOtherStructures & "  </td></tr>  "
                    AR1_Debug.Text += "<tr align=left><td>Package Contents Prem </td><td>" & CInt(packageContents.ToString()) & " </td></tr> "
                    'End If
                    ar_perEff1.Text = FormatCurrency(txt_pp_AR1.Text).ToString
                    txt_pp_AR1_Amount.Text = FormatCurrency(packageContents).ToString
                    'AR1_Debug.Text += "<tr align=left><td>Package Contents Prem </td><td>" & packageContents & " </td></tr> "
                Else
                    If txt_pp_AR1_Amount.Text = "0.00" Then
                        ar_perEff1.Text = FormatCurrency(txt_pp_AR1.Text).ToString
                        txt_pp_AR1_Amount.Text = FormatCurrency(packageContents).ToString
                        AR1_Debug.Text += "<tr align=left><td>Package Contents Prem </td><td>" & CInt(packageContents) & " </td></tr> "
                    End If
                End If

                packageTotal += packageContents
            Else
                AR1_Debug.Text += "<tr align=left><td>Package Contents Prem  </td><td> 0.00  </td></tr>  "
                ar_perEff1.Text = FormatCurrency(txt_pp_AR1.Text).ToString
                txt_pp_AR1_Amount.Text = "0.00"
                ' packageTotal += packageContents
            End If
        End If


        '/*/*/*/*/*/*/*/*/*/*/*/*/*/*/*/*/*/*/*/*/*/*/*/*/*/*/*/**/*/*/*/*/*




        AR1_Debug.Text += "<tr align=left><td>Base Total    </td><td>" & packageTotal & "</td></tr>"


        '----------------------------------




        'Package Ansi
        Dim packAnsi As Decimal
        If ddansi.SelectedValue = "Yes" Then
            packAnsi = CInt(CInt(packageTotal) * 0.09)

            ' packageOtherStructures = packageOtherStructures - (packageOtherStructures * 0.09)
            AR1_Debug.Text += "<tr align=left><td> ANSI/ASCE 7/88 Discount: </td><td> -" & CInt(packAnsi) & " </td></tr> <tr align=left><td> ANSI/ASCE 7/88 Base " & CInt(packageTotal) & " * 9% </td><td>  </td></tr>"
            packageTotal = CInt(packageTotal) - CInt(CInt(packageTotal) * 0.09)
        End If

        AR2_Debug.Text += "<tr align=left><td>Standard Other Struc Prem  </td><td> " & CInt(standardOtherStructures) & "  </td></tr>  "
        AR2_Debug.Text += "<tr align=left><td>Standard Contents Prem </td><td>" & CInt(standardContents) & " </td></tr> "
        standardTotal += CInt(standardContents)
        standardTotal += CInt(standardOtherStructures)
        AR2_Debug.Text += "<tr align=left><td>Base Total    </td><td>" & standardTotal & "</td></tr>"
        'Standard Ansi
        Dim standardAnsi As Decimal
        'moved from below
        ar_perEff2.Text = String.Format("{0:C0}", Math.Round(CDbl(txt_pp_AR2.Text)))
        txt_pp_AR2_Amount.Text = String.Format("{0:C0}", Math.Round(CDbl(standardContents)))
        ar_unattStr2.Text = String.Format("{0:C0}", Math.Round(CDbl(txt_unattstr_AR2.Text)))
        txt_unattstr_AR2_Amount.Text = String.Format("{0:C0}", Math.Round(CDbl(standardOtherStructures)))
        '*/*/*/*/*/*/*/*/*/*/*/*/*/*/*/**
        If ddansi.SelectedValue = "Yes" Then
            ' standardAnsi = CInt(CInt(standardTotal) * 0.09) + CInt(CInt(standardOtherStructures) * 0.09) + CInt(CInt(standardContents) * 0.09)
            standardAnsi = CInt(standardTotal) * 0.09

            AR2_Debug.Text += "<tr align=left><td> ANSI/ASCE 7/88 Discount: </td><td> -" & CInt(standardAnsi) & " </td></tr><tr align=left><td> ANSI/ASCE 7/88 Base + Structure + Contents  " & CInt(standardTotal) & " * 9% </td><td>  </td></tr> "

            standardPremium = standardPremium - (standardPremium * 0.09)
            'If standardOtherStructures > 0 Then
            '    standardOtherStructures = CInt(standardOtherStructures) - CInt(standardOtherStructures * 0.09)
            'End If
            'If standardContents > 0 Then
            '    standardContents = CInt(standardContents) - CInt(standardContents * 0.09)
            'End If
            standardTotal = CInt(standardTotal) - standardAnsi
        End If
        'Rental Ansi

        AR3_Debug.Text += "<tr align=left><td>Standard Other Struc Prem  </td><td> " & CInt(rentalOtherStructures) & "  </td></tr>  "
        AR3_Debug.Text += "<tr align=left><td>Standard Contents Prem </td><td>" & CInt(rentalContents) & " </td></tr> "
        rentalTotal += CInt(rentalOtherStructures)
        rentalTotal += CInt(rentalContents)
        AR3_Debug.Text += "<tr align=left><td>Base Total    </td><td>" & rentalTotal & "</td></tr>"
        Dim rentalAnsi As Decimal
        If ddansi.SelectedValue = "Yes" Then
            rentalAnsi = CInt(CInt(rentalTotal) * 0.09) '+ CInt(CInt(rentalOtherStructures) * 0.09) + CInt(CInt(rentalContents) * 0.09)

            ' rentalOtherStructures = CInt(rentalOtherStructures) - (CInt(rentalOtherStructures) * 0.09)
            ' rentalContents = CInt(rentalContents) - CInt(CInt(rentalContents) * 0.09)

            AR3_Debug.Text += "<tr align=left><td> ANSI/ASCE 7/88 Discount: </td><td> -" & CInt((rentalAnsi)) & " </td></tr> <tr align=left><td> ANSI/ASCE 7/88 Base + Structure + Contents  " & CInt(rentalTotal) & " * 9% </td><td>  </td></tr> "
            rentalTotal = CInt(rentalTotal) - CInt(CInt(rentalTotal) * 0.09)
        End If


        'Age Surcharge
        'Insured age
        'Dim MHage As Integer = 0
        'If IsNumeric(txtYear.Text) Then
        '    MHage = Now.Year - CInt(txtYear.Text.Substring(txtYear.Text.Length - 4, 4))
        'End If

        'If MHage >= 21 Then
        '    'Package
        '    packageTotal += CInt(CDbl(packagePremium) * 0.065)
        '    AR1_Debug.Text += "<tr align=left><td>MH AGE 21 YRS OLDER  </td><td>" & CInt((CDbl(packagePremium) * 0.065)) & " </td></tr> "
        '    ''Standard NO MH AGE on Standar
        '    'standardTotal += (CDbl(standardPremium) * 0.065)
        '    'AR2_Debug.Text += "<tr align=left><td>MH AGE 21 YRS OLDER  </td><td>" & (CDbl(standardPremium) * 0.065) & " </td></tr> "
        'End If

        Packsub1 = packageTotal
        Standsub1 = standardTotal
        Rentsub1 = rentalTotal



        AR1_Debug.Text += "<tr align=left><td>SUB TOTAL 1 </td><td> " & CInt(packageTotal) & " </td></tr>"

        AR2_Debug.Text += "<tr align=left><td>SUB TOTAL 1 </td><td> " & CInt(standardTotal) & " </td></tr>"

        AR3_Debug.Text += "<tr align=left><td>SUB TOTAL 1 </td><td> " & CInt(rentalTotal) & " </td></tr>"


        'Set Values for ded Calc
        ar_baseprem1.Text = CInt(packageTotal)
        ar_baseprem2.Text = CInt(standardTotal)
        ar_baseprem3.Text = CInt(rentalTotal)
        'Set deduction Options
        ARDedOptions()
        'Return Values
        packageTotal = CInt(ar_baseprem1.Text)
        standardTotal = CInt(ar_baseprem2.Text)
        rentalTotal = CInt(ar_baseprem3.Text)



        AR1_Debug.Text += "<tr align=left><td>SUB TOTAL 2</td><td>" & CInt(packageTotal) & " </td></tr> "
        AR2_Debug.Text += "<tr align=left><td>SUB TOTAL 2</td><td>" & CInt(standardTotal) & " </td></tr> "
        AR3_Debug.Text += "<tr align=left><td>SUB TOTAL 2</td><td>" & CInt(rentalTotal) & " </td></tr> "
        'Check or package defaults 



        ar_dwell1.Text = String.Format("{0:C0}", Math.Round(CDbl(value)))
        ar_baseprem1.Text = String.Format("{0:C0}", Math.Round(CDbl(packageTotal)))
        ar_tax1.Text = String.Format("{0:C0}", Math.Round(CDbl("0.00"))) 'No Tax for AR Florida


        'Set Standard Values
        'Contents
        'Person Content

        ar_dwell2.Text = String.Format("{0:C0}", Math.Round(CDbl(value)))
        ar_baseprem2.Text = String.Format("{0:C0}", Math.Round(CDbl(standardTotal)))
        ar_tax2.Text = String.Format("{0:C0}", Math.Round(CDbl("0.00"))) 'No Tax for AR Florida




        '****************Old COde*************************moved to above
        'ar_perEff2.Text = String.Format("{0:C0}", Math.Round(CDbl(txt_pp_AR2.Text)))
        'txt_pp_AR2_Amount.Text = String.Format("{0:C0}", Math.Round(CDbl(standardContents)))
        ''AR2_Debug.Text += "<tr align=left><td>Package Contents Prem </td><td>" & standardContents & " </td></tr> "
        '****************End old Code******************************
        'Other Structures


        '***********old code****************
        'ar_unattStr2.Text = String.Format("{0:C0}", Math.Round(CDbl(txt_unattstr_AR2.Text)))
        'txt_unattstr_AR2_Amount.Text = String.Format("{0:C0}", Math.Round(CDbl(standardOtherStructures)))
        'moved above to top
        'AR2_Debug.Text += "<tr align=left><td>Standard Other Struc Prem  </td><td> " & standardOtherStructures & "  </td></tr>  "
        'standardTotal = standardTotal + standardContents + standardOtherStructures
        'standardTotal = standardTotal - (standardTotal * CreditsPercentage)
        ar_dwell2.Text = String.Format("{0:C0}", Math.Round(CDbl(value)))
        ar_baseprem2.Text = String.Format("{0:C0}", Math.Round(CDbl(standardTotal)))
        ar_tax2.Text = String.Format("{0:C0}", Math.Round(CDbl("0.00"))) 'No Tax for AR Florida
        '************end old code*************
        'Set Rental Values
        ' rentalTotal = rentalPremium + rentalContents + rentalOtherStructures
        txt_pp_AR3_Amount.Text = String.Format("{0:C0}", Math.Round(CDbl(rentalContents)))
        txt_unattstr_AR3_Amount.Text = String.Format("{0:C0}", Math.Round(CDbl(rentalOtherStructures)))
        ar_dwell3.Text = String.Format("{0:C0}", Math.Round(CDbl(value)))
        ar_baseprem3.Text = String.Format("{0:C0}", Math.Round(CDbl(rentalTotal)))
        ar_tax3.Text = String.Format("{0:C0}", Math.Round(CDbl("0.00"))) 'No Tax for AR Florida
        '**********************************************




        'Set Options
        AROptions()
        '**********************************************
        'FEES
        'Put in Options totals
        AR1_Debug.Text += "<tr align=left><td>Personal Liability </td><td> $" & CInt(dd_pl_AR1_Amount.Text) & " </td></tr> "
        AR1_Debug.Text += "<tr align=left><td>Medical Payments </td><td> $" & CInt(dd_med_AR1_amt.Text) & " </td></tr> "
        AR1_Debug.Text += "<tr align=left><td>SUB TOTAL 3 </td><td> $" & packageTotal + CInt(dd_med_AR1_amt.Text) + CInt(dd_pl_AR1_Amount.Text) & " </td></tr> "
        packageTotal += CInt(dd_med_AR1_amt.Text)
        packageTotal += CInt(dd_pl_AR1_Amount.Text)

        AR2_Debug.Text += "<tr align=left><td>Personal Liability </td><td> $" & CInt(dd_pl_AR2_Amount.Text) & " </td></tr> "
        AR2_Debug.Text += "<tr align=left><td>Medical Payments </td><td> $" & CInt(dd_med_AR2_amt.Text) & " </td></tr> "
        AR2_Debug.Text += "<tr align=left><td>SUB TOTAL 3 </td><td> $" & standardTotal + CInt(dd_med_AR2_amt.Text) + CInt(dd_pl_AR2_Amount.Text) & " </td></tr> "
        standardTotal += CInt(dd_med_AR2_amt.Text)
        standardTotal += CInt(dd_pl_AR2_Amount.Text)

        AR3_Debug.Text += "<tr align=left><td>Personal Liability </td><td> $" & CInt(dd_pl_AR3_Amount.Text) & " </td></tr> "
        AR3_Debug.Text += "<tr align=left><td>Medical Payments </td><td> $" & CInt(dd_med_AR3_amt.Text) & " </td></tr> "
        AR3_Debug.Text += "<tr align=left><td>SUB TOTAL 3 </td><td> $" & rentalTotal + CInt(dd_med_AR3_amt.Text) + CInt(dd_pl_AR3_Amount.Text) & " </td></tr> "
        rentalTotal += CInt(dd_med_AR3_amt.Text)
        rentalTotal += CInt(dd_pl_AR3_Amount.Text)

        AR1_Debug.Text += "<tr align=left><td> Options </td><td> $" & CInt(ar_options1.Text) - CInt(dd_pl_AR1_Amount.Text) - CInt(dd_med_AR1_amt.Text) - CInt(txt_unattstr_AR1_Amount.Text) - CInt(txt_pp_AR1_Amount.Text) & " </td></tr> "
        AR2_Debug.Text += "<tr align=left><td> Options </td><td> $" & CInt(ar_options2.Text) - CInt(dd_pl_AR2_Amount.Text) - CInt(dd_med_AR2_amt.Text) - CInt(txt_unattstr_AR2_Amount.Text) - CInt(txt_pp_AR2_Amount.Text) & " </td></tr> "
        AR3_Debug.Text += "<tr align=left><td> Options </td><td> $" & CInt(ar_options3.Text) - CInt(dd_pl_AR3_Amount.Text) - CInt(dd_med_AR3_amt.Text) - CInt(txt_unattstr_AR3_Amount.Text) - CInt(txt_pp_AR3_Amount.Text) & " </td></tr> "
        'sub 3
        packageTotal += (CInt(ar_options1.Text) - CInt(dd_pl_AR1_Amount.Text) - CInt(dd_med_AR1_amt.Text) - CInt(txt_unattstr_AR1_Amount.Text) - CInt(txt_pp_AR1_Amount.Text))
        standardTotal += (CInt(ar_options2.Text) - CInt(dd_pl_AR2_Amount.Text) - CInt(dd_med_AR2_amt.Text) - CInt(txt_unattstr_AR2_Amount.Text) - CInt(txt_pp_AR2_Amount.Text))
        rentalTotal += (CInt(ar_options3.Text) - CInt(dd_pl_AR3_Amount.Text) - CInt(dd_med_AR3_amt.Text) - CInt(txt_unattstr_AR3_Amount.Text) - CInt(txt_pp_AR3_Amount.Text))
        'AR1_Debug.Text += "<tr align=left><td> SUB TOTAL 4 </td><td> $" & CInt(packageTotal) + (CInt(ar_options1.Text) + CInt(txt_unattstr_AR1_Amount.Text) + CInt(txt_pp_AR1_Amount.Text)) & " </td></tr> "
        AR1_Debug.Text += "<tr align=left><td> SUB TOTAL 4 </td><td> $" & CInt(packageTotal) & " </td></tr> "
        AR2_Debug.Text += "<tr align=left><td> SUB TOTAL 4 </td><td> $" & CInt(standardTotal) & " </td></tr> "
        AR3_Debug.Text += "<tr align=left><td> SUB TOTAL 4 </td><td> $" & CInt(rentalTotal) & " </td></tr> "

        'reset the values
        '  ar_baseprem1.Text = CInt(packageTotal) - (CInt(ar_options1.Text) - CInt(dd_pl_AR1_Amount.Text) - CInt(dd_med_AR1_amt.Text) - CInt(txt_unattstr_AR1_Amount.Text) - CInt(txt_pp_AR1_Amount.Text)) ' - ar_fees1.Text
        ar_baseprem1.Text = CInt(packageTotal) - CInt(ar_options1.Text)
        ar_baseprem2.Text = CInt(standardTotal) - CInt(ar_options2.Text)
        ar_baseprem3.Text = CInt(rentalTotal) - CInt(ar_options3.Text)

        'Package Medical Payment 
        'If dd_mp_AR1.SelectedValue.ToString = "$500" Then
        '    packageMedFee = 0

        'Else
        '    packageMedFee = 5
        'End If

        'AR1_Debug.Text += "<tr align=left><td>Package Med Fee  </td><td> " & packageMedFee & " </td></tr>  "
        ''Standard Medical Payment 
        'If dd_mp_AR2.SelectedValue.ToString = "$500" Then
        '    standardMedFee = 0
        'Else
        '    standardMedFee = 5
        'End If
        'AR2_Debug.Text += "<tr align=left><td>Standard Med Fee  </td><td> " & standardMedFee & " </td></tr>  "
        'Add MGA Fee
        packageFee += (25)
        standardFee += (25)
        rentalFee += (25)
        AR1_Debug.Text += "<tr align=left><td>Package MGA FEE  </td><td> 25</td></tr> "
        AR2_Debug.Text += "<tr align=left><td>Package MGA FEE  </td><td> 25</td></tr> "
        AR3_Debug.Text += "<tr align=left><td>Package MGA FEE  </td><td> 25</td></tr> "

        'Add Emergency Management Prep Surcharge
        packageFee += (2)
        standardFee += (2)
        rentalFee += (2)
        AR1_Debug.Text += "<tr align=left><td>Emergency Management FEE  </td><td> 2 </td></tr>  "
        AR2_Debug.Text += "<tr align=left><td>Emergency Management FEE  </td><td> 2 </td></tr>  "
        AR3_Debug.Text += "<tr align=left><td>Emergency Management FEE  </td><td> 2 </td></tr>  "
        'Citizens Emergency Assessment 
        'packageFee += ((CDbl(ar_baseprem1.Text) + CDbl(ar_options1.Text)) * 0.01)
        'CEA_ar1_Amount.Text = ((CDbl(ar_baseprem1.Text) + CDbl(ar_options1.Text)) * 0.01)
        packageFee += (packageTotal * 0.01)
        CEA_ar1_Amount.Text = (packageTotal * 0.01)

        'standardFee += ((CDbl(ar_baseprem2.Text) + CDbl(ar_options2.Text)) * 0.01)
        'CEA_ar2_Amount.Text = ((CDbl(ar_baseprem2.Text) + CDbl(ar_options2.Text)) * 0.01)

        standardFee += (standardTotal * 0.01)
        CEA_ar2_Amount.Text = (standardTotal * 0.01)



        'rentalFee += ((CDbl(ar_baseprem3.Text) + CDbl(ar_options3.Text)) * 0.01)
        'CEA_ar3_Amount.Text = ((CDbl(ar_baseprem3.Text) + CDbl(ar_options3.Text)) * 0.01)

        rentalFee += (rentalTotal * 0.01)
        CEA_ar3_Amount.Text = (rentalTotal * 0.01)
        'AR1_Debug.Text += "<tr align=left><td>Citizens Emergency Assessment FEE  </td><td> " & String.Format("{0:C}", ((CDbl(ar_baseprem1.Text) + CDbl(ar_options1.Text)) * 0.01)) & " </td></tr>  " '+ CDbl(ar_options1.Text)
        AR1_Debug.Text += "<tr align=left><td>Citizens Emergency Assessment FEE  </td><td> " & String.Format("{0:C}", (packageTotal * 0.01)) & " </td></tr>  " '+ CDbl(ar_options1.Text)
        AR2_Debug.Text += "<tr align=left><td>Citizens Emergency Assessment FEE  </td><td> " & String.Format("{0:C}", (standardTotal * 0.01)) & " </td></tr>  "
        AR3_Debug.Text += "<tr align=left><td>Citizens Emergency Assessment FEE  </td><td> " & String.Format("{0:C}", (rentalTotal * 0.01)) & " </td></tr>  "
        'Florida Hurr CAT Fund (1.3%)   
        'packageFee += ((CDbl(ar_baseprem1.Text) + CDbl(ar_options1.Text)) * 0.013)
        packageFee += (packageTotal * 0.013)
        'standardFee += ((CDbl(ar_baseprem2.Text) + CDbl(ar_options2.Text)) * 0.013)
        standardFee += (standardTotal * 0.013)
        'rentalFee += ((CDbl(ar_baseprem3.Text) + CDbl(ar_options3.Text)) * 0.013)
        rentalFee += (rentalTotal * 0.013)
        'AR1_Debug.Text += "<tr align=left><td>Florida Hurr CAT Fund FEE  </td><td> " & String.Format("{0:C}", ((CDbl(ar_baseprem1.Text) + CDbl(ar_options1.Text)) * 0.013)) & " </td></tr> " '+ CDbl(ar_options1.Text)
        AR1_Debug.Text += "<tr align=left><td>Florida Hurr CAT Fund FEE  </td><td> " & String.Format("{0:C}", (packageTotal * 0.013)) & " </td></tr> " '+ CDbl(ar_options1.Text)
        AR2_Debug.Text += "<tr align=left><td>Florida Hurr CAT Fund FEE  </td><td> " & String.Format("{0:C}", (standardTotal * 0.013)) & " </td></tr> " '+ CDbl(ar_options2.Text)
        AR3_Debug.Text += "<tr align=left><td>Florida Hurr CAT Fund FEE  </td><td> " & String.Format("{0:C}", (rentalTotal * 0.013)) & " </td></tr> " '+ CDbl(ar_options2.Text)


        'Set Fee Values
        ar_fees1.Text = String.Format("{0:C}", CDbl(packageFee))
        ar_fees2.Text = String.Format("{0:C}", CDbl(standardFee))
        ar_fees3.Text = String.Format("{0:C}", CDbl(rentalFee))
        '**********************************************
        packageTotal += packageFee
        standardTotal += standardFee
        rentalTotal += rentalFee
        'AR1_Debug.Text += "<tr align=left><td> TOTAL PREMIUM </td><td> $" & CInt(ar_baseprem1.Text) + CInt(ar_options1.Text) + CDbl(ar_fees1.Text) & " </td></tr> "
        AR1_Debug.Text += "<tr align=left><td> TOTAL PREMIUM </td><td> $" & FormatCurrency(packageTotal).Replace("$", "") & " </td></tr> "
        'AR2_Debug.Text += "<tr align=left><td> TOTAL PREMIUM </td><td> $" & CInt(ar_baseprem2.Text) + CInt(ar_options2.Text) + CDbl(ar_fees2.Text) & " </td></tr> "
        AR2_Debug.Text += "<tr align=left><td> TOTAL PREMIUM </td><td> $" & FormatCurrency(standardTotal).Replace("$", "") & " </td></tr> "
        'AR3_Debug.Text += "<tr align=left><td> TOTAL PREMIUM </td><td> $" & CDbl(ar_baseprem3.Text) + CInt(ar_options3.Text) + CDbl(ar_fees3.Text) & " </td></tr> "
        AR3_Debug.Text += "<tr align=left><td> TOTAL PREMIUM </td><td> $" & FormatCurrency(rentalTotal).Replace("$", "") & " </td></tr> "

        ''Set Final Values
        'ar_baseprem1.Text = String.Format("{0:C0}", Math.Round(CDbl(packageTotal)))
        'ar_baseprem2.Text = String.Format("{0:C0}", Math.Round(CDbl(standardTotal)))
        'ar_baseprem3.Text = String.Format("{0:C0}", Math.Round(CDbl(rentalTotal)))
        AR1_Debug.Text += "</tbody></table>"
        AR2_Debug.Text += "</tbody></table>"
        AR3_Debug.Text += "</tbody></table>"

        'Set Visiblity on hidden fields
        ARSetFields()
        'Dim packmed As Integer = 0
        'Dim standmed As Integer = 0
        'Dim rentmed As Integer = 0

        'If dd_mp_AR1.SelectedValue = "$1000" Then
        '    packmed = 5
        'End If
        'If dd_mp_AR2.SelectedValue = "$1000" Then
        '    standmed = 6
        'End If
        'If dd_mp_AR3.SelectedValue = "$1000" Then
        '    rentmed = 6
        'End If
        'update Totals
        ' Dim ar1total As String = String.Format("{0:C0}", Math.Round(CDbl(ar_baseprem1.Text) + CDbl(ar_options1.Text) + CDbl(ar_fees1.Text) + CDbl(ar_tax1.Text) + packmed.ToString()))

        ar_total1.Text = String.Format("{0:C}", CInt(ar_baseprem1.Text) + CInt(ar_options1.Text) + CDbl(ar_fees1.Text) + CInt(ar_tax1.Text))
        ar_total2.Text = String.Format("{0:C}", CInt(ar_baseprem2.Text) + CInt(ar_options2.Text) + CDbl(ar_fees2.Text) + CInt(ar_tax2.Text))
        ar_total3.Text = String.Format("{0:C}", CInt(ar_baseprem3.Text) + CInt(ar_options3.Text) + CDbl(ar_fees3.Text) + CInt(ar_tax3.Text))
        ' AR1_Debug.Text = Server.HtmlEncode(AR1_Debug.Text)



    End Sub
    Public Sub ARDedOptions()
        Dim ds As System.Data.DataSet
        Dim packageNonHur, packageHur, standardNonHur, standardHur, packageBase, standardBase, rentalBase, rentalNonHur, rentalHur As Double

        packageBase = ar_baseprem1.Text.Replace("$", "").Replace(",", "")
        standardBase = ar_baseprem2.Text.Replace("$", "").Replace(",", "")
        rentalBase = ar_baseprem3.Text.Replace("$", "").Replace(",", "")

        'Get package ded credits
        ds = runQueryDS("EXEC sp_getARDedOptions '" & dd_aop_AR1.SelectedValue.ToString & "','" & dd_hurded_AR1.SelectedValue.ToString & "','" & homeusedd.SelectedValue.ToString & "' ", "ColonialMHConnectionString")
        If ds.Tables(0).Rows.Count > 0 Then
            packageNonHur = CDbl(ds.Tables(0).Rows(0).Item("PackageRateNonHur").ToString)
            packageHur = CDbl(ds.Tables(0).Rows(0).Item("PackageRateHur").ToString)

        Else
            'no rates found
        End If
        'Get standard ded credits
        ds = runQueryDS("EXEC sp_getARDedOptions '" & dd_aop_AR2.SelectedValue.ToString & "','" & dd_hurded_AR2.SelectedValue.ToString & "','" & homeusedd.SelectedValue.ToString & "' ", "ColonialMHConnectionString")
        If ds.Tables(0).Rows.Count > 0 Then
            standardHur = CDbl(ds.Tables(0).Rows(0).Item("StandardRateHur").ToString)
            standardNonHur = CDbl(ds.Tables(0).Rows(0).Item("StandardRateNonHur").ToString)

        Else
            'no rates found
        End If
        'Get rental ded credits
        ds = runQueryDS("EXEC sp_getARDedOptions '" & dd_aop_AR3.SelectedValue.ToString & "','" & dd_hurded_AR3.SelectedValue.ToString & "','" & homeusedd.SelectedValue.ToString & "' ", "ColonialMHConnectionString")
        If ds.Tables(0).Rows.Count > 0 Then
            rentalHur = CDbl(ds.Tables(0).Rows(0).Item("RentalRateHur").ToString)
            rentalNonHur = CDbl(ds.Tables(0).Rows(0).Item("RentalRateNonHur").ToString)

        Else
            'no rates found
        End If

        'Calc & apply Package
        packageNonHur = Math.Round((packageBase * packageNonHur), 0, MidpointRounding.AwayFromZero)

        AR1_Debug.Text += "<tr align=left><td>Non Hurricane </td><td> -" & CInt(packageNonHur) & " </td></tr> "
        packageHur = Math.Round((packageBase * packageHur), 0, MidpointRounding.AwayFromZero)
        AR1_Debug.Text += "<tr align=left><td>Hurricane </td><td> - " & CInt(packageHur) & " </td></tr> "
        txt_DedChange_AR1_Amount.Text = CInt(packageHur + packageNonHur)
        packageBase = CInt(packageBase - packageNonHur)
        packageBase = CInt(packageBase - packageHur)

        PackNonHur = packageNonHur
        PackHur = packageHur

        'Calc & apply Standard
        Dim temp As Double
        standardNonHur = Math.Round((standardBase * standardNonHur), 0, MidpointRounding.AwayFromZero)

        AR2_Debug.Text += "<tr align=left><td>Non Hurricane </td><td> -" & CInt(standardNonHur) & " </td></tr> "
        standardHur = Math.Round((standardBase * standardHur), 0, MidpointRounding.AwayFromZero)
        temp = standardNonHur + standardHur
        SeasonalFee_ar2_Amount.Text = CInt(temp)
        AR2_Debug.Text += "<tr align=left><td>Hurricane </td><td> - " & CInt(standardHur) & " </td></tr> "
        txt_DedChange_AR2_Amount.Text = CInt(standardNonHur + standardHur)
        standardBase = CInt(standardBase - standardNonHur)
        standardBase = CInt(standardBase - standardHur)

        StandNonHur = standardNonHur
        StandHur = standardHur

        'Calc & apply Rental
        rentalNonHur = Math.Round((rentalBase * rentalNonHur), 0, MidpointRounding.AwayFromZero)
        AR3_Debug.Text += "<tr align=left><td>Non Hurricane </td><td> -" & CInt(rentalNonHur) & " </td></tr> "
        rentalHur = CInt(rentalBase * rentalHur)
        AR3_Debug.Text += "<tr align=left><td>Hurricane </td><td> - " & CInt(rentalHur) & " </td></tr> "
        txt_DedChange_AR3_Amount.Text = rentalNonHur + rentalHur
        rentalBase = CInt(rentalBase - rentalNonHur)
        rentalBase = CInt(rentalBase - rentalHur)

        RentHur = rentalHur
        RentNonHur = rentalNonHur

        'Set values to form
        ar_baseprem1.Text = packageBase
        ar_baseprem2.Text = standardBase
        ar_baseprem3.Text = rentalBase
    End Sub
    Public Sub AROptions()
        '***************************************************************
        totperpropar1 = CType(Session("PerPropAR1"), Decimal)
        totperpropar2 = CType(Session("PerPropAR2"), Decimal)
        Dim supHeat As String
        Dim ar1_fee, ar2_fee, ar3_fee As Double
        Dim packagePremium, standardPremium, rentalPremium As Double
        ar1_fee = 0.0
        ar2_fee = 0.0
        ar3_fee = 0.0
        packagePremium = CDbl(ar_baseprem1.Text)
        standardPremium = CDbl(ar_baseprem2.Text)
        rentalPremium = CDbl(ar_baseprem3.Text)
        Dim ds As System.Data.DataSet

        'calc Package options

        'Package
        Dim perLiab_ar1, SecureInterest_ar1, NaturalDisaster_ar1, MHReplCost_ar1, PersonalEffRepCost_ar1, AddlRadio_ar1, AddlFire_ar1,
            ar1_medPay, ar1_addResidents, ar1_addResidentsLiab, ar1_addResidentsMedPay,
            ar1_waterCraftType, ar1_waterCraftLiab, ar1_waterCraftMedPay, ar1_ValuablePerProp As String 'Package

        'Set Values
        perLiab_ar1 = dd_pl_AR1.SelectedValue.ToString()
        ar_perLiab1.Text = perLiab_ar1
        SecureInterest_ar1 = dd_sip_AR1.SelectedValue
        NaturalDisaster_ar1 = dd_ndp_AR1.SelectedValue
        MHReplCost_ar1 = dd_mhr_AR1.SelectedValue
        PersonalEffRepCost_ar1 = dd_rep_AR1.SelectedValue
        AddlRadio_ar1 = txt_addlimrad_AR1.Text
        AddlFire_ar1 = txt_addlimfir_AR1.Text
        supHeat = supheatdd.SelectedValue
        'second page
        ar1_medPay = dd_mp_AR1.SelectedValue

        ar1_addResidents = dd_addresOpt_ar1.SelectedValue
        ar1_addResidentsLiab = dd_addresliab_ar1.SelectedValue
        ar1_addResidentsMedPay = dd_addresMP_ar1.SelectedValue

        ar1_waterCraftType = dd_waterCraft_AR1.SelectedValue
        ar1_waterCraftLiab = dd_waterCraftliab_AR1.SelectedValue
        ar1_waterCraftMedPay = dd_waterCraftMedpay_AR1.SelectedValue

        ar1_ValuablePerProp = dd_PackagePerProp_AR1.SelectedValue

        'Check Personal Liab default values
        'If perLiab_ar1 = "$50,000" Then 'Default value is in base premium. Reset value to 0 to not calculate.
        '    perLiab_ar1 = ""
        'End If
        'Check med pay default values
        If ar1_medPay = "$500" Then 'Default value is in base premium. Reset value to 0 to not calculate.
            ar1_medPay = "0"
        Else
            ar1_medPay = "5"

        End If

        ds = runQueryDS("EXEC sp_getAROptions '" & perLiab_ar1 & "','" & SecureInterest_ar1 & _
                        "','" & NaturalDisaster_ar1 & "','" & MHReplCost_ar1 & _
                        "','" & PersonalEffRepCost_ar1 & "','" & AddlRadio_ar1 & "','" & AddlFire_ar1 & "','" & supHeat & _
                        "', '" & ar1_medPay & "','" & ar1_addResidents & "','" & ar1_addResidentsLiab & "','" & ar1_addResidentsMedPay & "','" & _
                        ar1_waterCraftType & "','" & ar1_waterCraftLiab & "','" & ar1_waterCraftMedPay & "','" & ar1_ValuablePerProp & "',0 ", "ColonialMHConnectionString")
        If ds.Tables(0).Rows.Count > 0 Then

            perLiab_ar1 = ds.Tables(0).Rows(0).Item("PackagePerLiab").ToString
            dd_pl_AR1_Amount.Text = "$" & CInt(perLiab_ar1).ToString

            SecureInterest_ar1 = ds.Tables(0).Rows(0).Item("PackageSecInt").ToString
            dd_sip_AR1_Amount.Text = "$" & CInt(SecureInterest_ar1).ToString()

            NaturalDisaster_ar1 = ds.Tables(0).Rows(0).Item("PackageND").ToString
            dd_ndp_AR1_Amount.Text = "$" & CInt(NaturalDisaster_ar1).ToString()

            MHReplCost_ar1 = ds.Tables(0).Rows(0).Item("PackageMHRep").ToString
            dd_mhr_AR1_Amount.Text = "$" & CInt(MHReplCost_ar1).ToString()

            PersonalEffRepCost_ar1 = ds.Tables(0).Rows(0).Item("PackagePerEffCost").ToString
            dd_rep_AR1_Amount.Text = "$" & CInt(CDbl(PersonalEffRepCost_ar1) * (CDbl(txt_pp_AR1.Text) / 100)).ToString()

            AddlRadio_ar1 = ds.Tables(0).Rows(0).Item("PackageAddlRadio").ToString
            txt_addlimrad_AR1_Amount.Text = "$" & CInt(AddlRadio_ar1).ToString()

            AddlFire_ar1 = ds.Tables(0).Rows(0).Item("PackageAddlFire").ToString
            txt_addlimfir_AR1_Amount.Text = "$" & CInt(AddlFire_ar1).ToString()

            ar1_addResidents = ds.Tables(0).Rows(0).Item("PackageAddResidence").ToString
            dd_addresOpt_ar1_Amount.Text = "$" & CInt(ar1_addResidents).ToString()

            ar1_waterCraftType = ds.Tables(0).Rows(0).Item("PackageWaterCraft").ToString
            dd_waterCraft_AR1_Amount.Text = "$" & CInt(ar1_waterCraftType).ToString()

            ar1_ValuablePerProp = ds.Tables(0).Rows(0).Item("PackageValuablePerProp").ToString
            ' dd_PackagePerProp_AR1_Amount.Text = FormatCurrency(CDbl(ar1_ValuablePerProp) * (CDbl(txt_pp_AR1.Text) / 100)).ToString()
            If totperpropar1 * CDec(ar1_ValuablePerProp / 100) > 15 Then
                dd_PackagePerProp_AR1_Amount.Text = "$" & CInt(totperpropar1 * CDec(ar1_ValuablePerProp / 100)).ToString()
            ElseIf totperpropar1 * CDec(ar1_ValuablePerProp / 100) > 0 Then
                dd_PackagePerProp_AR1_Amount.Text = "$" & CInt("15.00").ToString()
            End If
            ' dd_PackagePerProp_AR1_Amount.Text = FormatCurrency(totperpropar1 * CDec(ar1_ValuablePerProp / 100)).ToString()
            packagePerPropValue.Text = FormatCurrency(totperpropar1.ToString())

            supHeat = ds.Tables(0).Rows(0).Item("PackagesupHeat").ToString
            supHeating_ar1_Amount.Text = "$" & CInt(supHeat).ToString()



            dd_med_AR1_amt.Text = "$" & CInt(ar1_medPay).ToString()
        Else
            'no rates found
            perLiab_ar1 = "0.00"
            SecureInterest_ar1 = "0.00"
            NaturalDisaster_ar1 = "0.00"
            MHReplCost_ar1 = "0.00"
            PersonalEffRepCost_ar1 = "0.00"
            AddlRadio_ar1 = "0.00"
            AddlFire_ar1 = "0.00"
            supHeat = "0.00"
        End If
        ar1_fee += 0
        ar1_fee += CDbl(perLiab_ar1)
        ar1_fee += CDbl(txt_pp_AR1_Amount.Text)
        ar1_fee += CDbl(txt_unattstr_AR1_Amount.Text)
        ar1_fee += CDbl(MHReplCost_ar1) '  MH Rep Cost
        ar1_fee += CDbl(PersonalEffRepCost_ar1) * (CDbl(txt_pp_AR1.Text) / 100) 'Contents
        ar1_fee += CDbl(AddlRadio_ar1) '* (CDbl(txt_addlimrad_AR1.Text) / 100) 'Addl Radio
        ar1_fee += CDbl(AddlFire_ar1) '* (CDbl(txt_addlimfir_AR1.Text) / 100) 'Addl Fire
        ar1_fee += CDbl(SecureInterest_ar1) 'Secured Interest
        ar1_fee += CDbl(NaturalDisaster_ar1) 'Natural Disaster
        ar1_fee += CDbl(ar1_addResidents) ' Add Residents
        ar1_fee += CDbl(ar1_waterCraftType) ' Water Craft
        ' ar1_fee += CDbl(ar1_ValuablePerProp) * (CDbl(txt_pp_AR1.Text) / 100) 'Valuable Personnal Property
        ar1_fee += CDbl(dd_PackagePerProp_AR1_Amount.Text) 'New valuable personnal property
        ar1_fee += CDbl(supHeat) ' SupHeating
        ar1_fee += CDbl(ar1_medPay) 'MedPay
        ar_options1.Text = "$" & CInt(Math.Round((ar1_fee), 0, MidpointRounding.AwayFromZero))


        Dim perLiab_ar2, SecureInterest_ar2, NaturalDisaster_ar2, MHReplCost_ar2, PersonalEffRepCost_ar2, AddlRadio_ar2, AddlFire_ar2,
            ar2_medPay, ar2_addResidents, ar2_addResidentsLiab, ar2_addResidentsMedPay,
            ar2_waterCraftType, ar2_waterCraftLiab, ar2_waterCraftMedPay, ar2_ValuablePerProp As String 'Standard
        'Set Standard selected Values
        perLiab_ar2 = dd_pl_AR2.SelectedValue.ToString()
        ar_perLiab2.Text = perLiab_ar2
        SecureInterest_ar2 = dd_sip_AR2.SelectedValue
        NaturalDisaster_ar2 = dd_ndp_AR2.SelectedValue
        MHReplCost_ar2 = dd_mhr_AR2.SelectedValue
        PersonalEffRepCost_ar2 = dd_rep_AR2.SelectedValue
        AddlRadio_ar2 = txt_addlimrad_AR2.Text
        AddlFire_ar2 = txt_addlimfir_AR2.Text
        supHeat = supheatdd.SelectedValue
        'second page
        ar2_medPay = dd_mp_AR2.SelectedValue

        ar2_addResidents = dd_addresOpt_ar2.SelectedValue
        ar2_addResidentsLiab = dd_addresliab_ar2.SelectedValue
        ar2_addResidentsMedPay = dd_addresMP_ar2.SelectedValue

        ar2_waterCraftType = dd_waterCraft_ar2.SelectedValue
        ar2_waterCraftLiab = dd_waterCraftliab_ar2.SelectedValue
        ar2_waterCraftMedPay = dd_waterCraftMedpay_ar2.SelectedValue

        ar2_ValuablePerProp = dd_PackagePerProp_ar2.SelectedValue


        ds = runQueryDS("EXEC sp_getAROptions '" & perLiab_ar2 & "','" & SecureInterest_ar2 & _
                        "','" & NaturalDisaster_ar2 & "','" & MHReplCost_ar2 & _
                        "','" & PersonalEffRepCost_ar2 & "','" & AddlRadio_ar2 & "','" & AddlFire_ar2 & "','" & supHeat & _
                        "', '" & ar2_medPay & "','" & ar2_addResidents & "','" & ar2_addResidentsLiab & "','" & ar2_addResidentsMedPay & "','" & _
                        ar2_waterCraftType & "','" & ar2_waterCraftLiab & "','" & ar2_waterCraftMedPay & "','" & ar2_ValuablePerProp & "',0 ", "ColonialMHConnectionString")
        If ds.Tables(0).Rows.Count > 0 Then
            perLiab_ar2 = ds.Tables(0).Rows(0).Item("StandardPerLiab").ToString
            dd_pl_AR2_Amount.Text = "$" & CInt(perLiab_ar2).ToString

            SecureInterest_ar2 = ds.Tables(0).Rows(0).Item("StandardSecInt").ToString
            dd_sip_AR2_Amount.Text = "$" & CInt(SecureInterest_ar2).ToString()

            NaturalDisaster_ar2 = ds.Tables(0).Rows(0).Item("StandardND").ToString
            dd_ndp_AR2_Amount.Text = "$" & CInt(NaturalDisaster_ar2).ToString()

            MHReplCost_ar2 = ds.Tables(0).Rows(0).Item("StandardMHRep").ToString
            dd_mhr_AR2_Amount.Text = "$" & CInt(MHReplCost_ar2).ToString()

            PersonalEffRepCost_ar2 = ds.Tables(0).Rows(0).Item("StandardPerEffCost").ToString
            dd_rep_AR2_Amount.Text = "$" & CInt(String.Format("{0:C0}", Math.Round(CDbl(PersonalEffRepCost_ar2) * (CDbl(txt_pp_AR2.Text) / 100), 0, MidpointRounding.AwayFromZero).ToString()))

            AddlRadio_ar2 = ds.Tables(0).Rows(0).Item("StandardAddlRadio").ToString
            txt_addlimrad_AR2_Amount.Text = "$" & CInt(AddlRadio_ar2).ToString()

            AddlFire_ar2 = ds.Tables(0).Rows(0).Item("StandardAddlFire").ToString
            txt_addlimfir_AR2_Amount.Text = "$" & CInt(AddlFire_ar2).ToString()

            ar2_addResidents = ds.Tables(0).Rows(0).Item("StandardAddResidence").ToString
            dd_addresOpt_ar2_Amount.Text = "$" & CInt(ar2_addResidents).ToString()

            ar2_waterCraftType = ds.Tables(0).Rows(0).Item("StandardWaterCraft").ToString
            dd_waterCraft_ar2_Amount.Text = "$" & CInt(ar2_waterCraftType).ToString()

            ar2_ValuablePerProp = ds.Tables(0).Rows(0).Item("PackageValuablePerProp").ToString
            'dd_PackagePerProp_ar2_Amount.Text = FormatCurrency(ar2_ValuablePerProp).ToString()
            ' dd_PackagePerProp_ar2_Amount.Text = FormatCurrency(totperpropar2 * CDec(ar2_ValuablePerProp / 100)).ToString()
            If totperpropar2 * CDec(ar2_ValuablePerProp / 100) > 15 Then
                dd_PackagePerProp_ar2_Amount.Text = "$" & CInt(totperpropar2 * CDec(ar2_ValuablePerProp / 100)).ToString()
            ElseIf totperpropar2 * CDec(ar2_ValuablePerProp / 100) > 0 Then
                dd_PackagePerProp_ar2_Amount.Text = "$" & CInt("15.00").ToString()
            End If
            pp_property2.Text = FormatCurrency(totperpropar2.ToString())
            supHeat = ds.Tables(0).Rows(0).Item("StandardsupHeat").ToString
            supHeating_ar2_Amount.Text = "$" & CInt(supHeat).ToString()
            If perLiab_ar2 = "0" Then


                If ar2_medPay = "$500" Then 'Default value is in base premium. Reset value to 0 to not calculate.
                    ar2_medPay = "5"
                ElseIf ar2_medPay = "$1000" Then
                    ar2_medPay = "5"
                Else
                    ar2_medPay = "0"
                End If

            Else
                If ar2_medPay = "$1000" Then
                    ar2_medPay = "5"
                Else
                    ar2_medPay = "0"
                End If
                ' ar2_medPay = "0"

            End If
            dd_med_AR2_amt.Text = FormatCurrency(ar2_medPay).ToString()
        Else
            'no rates found
            perLiab_ar2 = "0.00"
            SecureInterest_ar2 = "0.00"
            NaturalDisaster_ar2 = "0.00"
            MHReplCost_ar2 = "0.00"
            PersonalEffRepCost_ar2 = "0.00"
            AddlRadio_ar2 = "0.00"
            AddlFire_ar2 = "0.00"
            ar2_addResidents = "0.00"
            supHeat = "0.00"
        End If

        ar2_fee += CDbl(perLiab_ar2)
        ar2_fee += CDbl(txt_pp_AR2_Amount.Text)
        ar2_fee += CDbl(txt_unattstr_AR2_Amount.Text)
        ar2_fee += CDbl(MHReplCost_ar2)
        ar2_fee += CDbl(PersonalEffRepCost_ar2) * (CDbl(txt_pp_AR2.Text) / 100) 'Contents
        ar2_fee += CDbl(AddlRadio_ar2) '* (CDbl(txt_addlimrad_AR2.Text) / 200) 'Addl Radio
        ar2_fee += CDbl(AddlFire_ar2) '* (CDbl(txt_addlimfir_AR2.Text) / 200) 'Addl Fire
        ar2_fee += CDbl(SecureInterest_ar2)
        ar2_fee += CDbl(NaturalDisaster_ar2)
        ar2_fee += CDbl(ar2_addResidents) ' Add Residents
        ar2_fee += CDbl(ar2_waterCraftType) ' Water Craft
        'ar2_fee += CDbl(ar2_ValuablePerProp) * (CDbl(txt_pp_AR2.Text) / 200) 'Valuable Personnal Property
        ar2_fee += CDbl(dd_PackagePerProp_ar2_Amount.Text) 'valuable personnal property
        ar2_fee += CDbl(supHeat)
        ar2_fee += CDbl(ar2_medPay)
        ar_options2.Text = CInt(Math.Round((ar2_fee), 0, MidpointRounding.AwayFromZero))


        Dim perLiab_ar3, SecureInterest_ar3, NaturalDisaster_ar3, MHReplCost_ar3, PersonalEffRepCost_ar3, AddlRadio_ar3, AddlFire_ar3,
            ar3_medPay, ar3_addResidents, ar3_addResidentsLiab, ar3_addResidentsMedPay,
            ar3_waterCraftType, ar3_waterCraftLiab, ar3_waterCraftMedPay, ar3_ValuablePerProp As String 'rental
        'Set rental selected Values
        perLiab_ar3 = dd_pl_AR3.SelectedValue.ToString()
        ar_unattStr3.Text = String.Format("{0:C0}", Math.Round(CDbl(txt_unattstr_AR3.Text)))
        ar_perEff3.Text = String.Format("{0:C0}", Math.Round(CDbl(txt_pp_AR3.Text)))
        ar_perLiab3.Text = perLiab_ar3
        SecureInterest_ar3 = dd_sip_AR3.SelectedValue
        NaturalDisaster_ar3 = dd_ndp_AR3.SelectedValue


        AddlRadio_ar3 = txt_addlimrad_AR3.Text
        AddlFire_ar3 = txt_addlimfir_AR3.Text
        supHeat = supheatdd.SelectedValue
        'second page
        ar3_medPay = dd_mp_AR3.SelectedValue
        ds = runQueryDS("EXEC sp_getAROptions '" & perLiab_ar3 & "','" & SecureInterest_ar3 & _
                        "','" & NaturalDisaster_ar3 & "','" & MHReplCost_ar3 & _
                        "','" & PersonalEffRepCost_ar3 & "','" & AddlRadio_ar3 & "','" & AddlFire_ar3 & "','" & supHeat & _
                        "', '" & ar3_medPay & "','" & ar3_addResidents & "','" & ar3_addResidentsLiab & "','" & ar3_addResidentsMedPay & "','" & _
                        ar3_waterCraftType & "','" & ar3_waterCraftLiab & "','" & ar3_waterCraftMedPay & "','" & ar3_ValuablePerProp & "', '" & perLiab_ar3 & "'", "ColonialMHConnectionString")
        If ds.Tables(0).Rows.Count > 0 Then
            perLiab_ar3 = ds.Tables(0).Rows(0).Item("RentalPerLiab").ToString
            dd_pl_AR3_Amount.Text = "$" & CInt(perLiab_ar3).ToString

            SecureInterest_ar3 = ds.Tables(0).Rows(0).Item("RentalSecInt").ToString
            dd_sip_AR3_Amount.Text = "$" & CInt(SecureInterest_ar3).ToString()

            NaturalDisaster_ar3 = ds.Tables(0).Rows(0).Item("RentalND").ToString
            dd_ndp_AR3_Amount.Text = "$" & CInt(NaturalDisaster_ar3).ToString()

            perLiab_ar3 = ds.Tables(0).Rows(0).Item("RentalLiab").ToString
            dd_pl_AR3_Amount.Text = "$" & CInt(perLiab_ar3).ToString()

            AddlRadio_ar3 = ds.Tables(0).Rows(0).Item("RentalAddlRadio").ToString
            txt_addlimrad_AR3_Amount.Text = "$" & CInt(AddlRadio_ar3).ToString()

            AddlFire_ar3 = ds.Tables(0).Rows(0).Item("RentalAddlFire").ToString
            txt_addlimfir_AR3_Amount.Text = "$" & CInt(AddlFire_ar3).ToString()

            supHeat = ds.Tables(0).Rows(0).Item("rentalsupHeat").ToString
            supHeating_ar3_Amount.Text = "$" & CInt(supHeat).ToString()
            If ar3_medPay = "$500" Then 'Default value is in base premium. Reset value to 0 to not calculate.
                ar3_medPay = "0"
            Else
                ar3_medPay = "5"

            End If
            dd_med_AR3_amt.Text = FormatCurrency(ar3_medPay).ToString()
        Else
            'no rates found
            perLiab_ar3 = "0.00"
            SecureInterest_ar3 = "0.00"
            NaturalDisaster_ar3 = "0.00"
            AddlRadio_ar3 = "0.00"
            AddlFire_ar3 = "0.00"
            supHeat = "0.00"
        End If

        ar3_fee += CDbl(perLiab_ar3)
        ar3_fee += CDbl(txt_pp_AR3_Amount.Text)
        ar3_fee += CDbl(txt_unattstr_AR3_Amount.Text)

        ar3_fee += CDbl(AddlRadio_ar3) '* (CDbl(txt_addlimrad_AR3.Text) / 300) 'Addl Radio
        ar3_fee += CDbl(AddlFire_ar3) '* (CDbl(txt_addlimfir_AR3.Text) / 300) 'Addl Fire
        ar3_fee += CDbl(SecureInterest_ar3)
        ar3_fee += CDbl(NaturalDisaster_ar3)
        ar3_fee += CDbl(supHeat)
        ar3_fee += CDbl(ar3_medPay)
        ar_options3.Text = CInt(Math.Round((ar3_fee), 0, MidpointRounding.AwayFromZero))

        PackOption = String.Format("{0:C0}", Math.Round(CDbl(ar1_fee)))
        StandOpt = String.Format("{0:C0}", Math.Round(CDbl(ar2_fee)))
        RentOpt = String.Format("{0:C0}", Math.Round(CDbl(ar3_fee)))

    End Sub
    Public Sub ARSetFields()
        'Package options
        If lblARShowOptions1_hidden.Value = "- Show Options" Then
            ar_mh_prog1_Options.Style.Add("display", "block")
            AROptionRow1.Style.Add("display", "block")
            lblARShowOptions1.InnerText = "- Show Options"
        Else
            ar_mh_prog1_Options.Style.Remove("display")
            ar_mh_prog1_Options.Style.Add("display", "none")
            AROptionRow1.Style.Add("display", "none")
            lblARShowOptions1.InnerText = "+ Show Options"
        End If
        'Standard Options
        If lblARShowOptions2_hidden.Value = "- Show Options" Then
            ar_mh_prog2_Options.Style.Add("display", "block")
            AROptionRow2.Style.Add("display", "block")
            lblARShowOptions2.InnerText = "- Show Options"
        Else
            ar_mh_prog2_Options.Style.Add("display", "none")
            AROptionRow2.Style.Add("display", "none")
            lblARShowOptions2.InnerText = "+ Show Options"
        End If

        'Rental Options
        If lblARShowOptions3_hidden.Value = "- Show Options" Then
            ar_mh_prog3_Options.Style.Add("display", "block")
            AROptionRow3.Style.Add("display", "block")
            lblARShowOptions3.InnerText = "- Show Options"
        Else
            ar_mh_prog3_Options.Style.Add("display", "none")
            AROptionRow3.Style.Add("display", "none")
            lblARShowOptions3.InnerText = "+ Show Options"
        End If

        'Show/hide AR 1 redisence options
        If AR_AddResOpt1_HIDDEN.Value = "visible" Then
            AR_AddResOpt1_ar1.Style.Add("display", "block")
            AR_AddResOpt2_ar1.Style.Add("display", "block")
        Else
            AR_AddResOpt1_ar1.Style.Add("display", "none")
            AR_AddResOpt2_ar1.Style.Add("display", "none")
        End If

        'Show/hide AR 1 watercraft options
        If AR_AddResOpt2_HIDDEN.Value = "visible" Then
            AR_WaterCraftOpt1_ar1.Style.Add("display", "block")
            AR_WaterCraftOpt2_ar1.Style.Add("display", "block")
        Else
            AR_WaterCraftOpt1_ar1.Style.Add("display", "none")
            AR_WaterCraftOpt2_ar1.Style.Add("display", "none")
        End If

        'Show/hide AR 2 redisence options
        If AR_AddResOpt1_ar2_HIDDEN.Value = "visible" Then
            AR_AddResOpt1_ar2.Style.Add("display", "block")
            AR_AddResOpt2_ar2.Style.Add("display", "block")
        Else
            AR_AddResOpt1_ar2.Style.Add("display", "none")
            AR_AddResOpt2_ar2.Style.Add("display", "none")
        End If

        'Show/hide AR 2 watercraft options
        If AR_AddResOpt2_ar2_HIDDEN.Value = "visible" Then
            AR_WaterCraftOpt1_ar2.Style.Add("display", "block")
            AR_WaterCraftOpt2_ar2.Style.Add("display", "block")
        Else
            AR_WaterCraftOpt1_ar2.Style.Add("display", "none")
            AR_WaterCraftOpt2_ar2.Style.Add("display", "none")
        End If


        'Hide update option buttons
        ar1_updateOptions.Style.Add("display", "none")
        ar2_updateOptions.Style.Add("display", "none")
        ar3_updateOptions.Style.Add("display", "none")
        showARSections()

    End Sub
    Public Sub showARSections()
        ar_mh_prog1.Style.Add("display", "none")
        ar_mh_prog1_Options.Style.Add("display", "none")
        ar_mh_prog2.Style.Add("display", "none")
        ar_mh_prog2_Options.Style.Add("display", "none")
        ar_mh_prog3.Style.Add("display", "none")
        ar_mh_prog3_Options.Style.Add("display", "none")
        If homeusedd.SelectedValue.ToString = "Owner" Then
            ar_mh_prog1.Style.Add("display", "")
            ar_mh_prog1_Options.Style.Add("display", "")
            ar_mh_prog2.Style.Add("display", "")
            ar_mh_prog2_Options.Style.Add("display", "")
        End If
        If homeusedd.SelectedValue.ToString = "Seasonal" Then
            ar_mh_prog2.Style.Add("display", "")
            ar_mh_prog2_Options.Style.Add("display", "")
        End If
        If homeusedd.SelectedValue.ToString = "Rental" Then
            ar_mh_prog3.Style.Add("display", "")
            ar_mh_prog3_Options.Style.Add("display", "")
        End If



    End Sub

    Protected Function getCredits()
        Dim CreditsPercentage As Double
        Dim credits As Integer = 0
        'Is home protected
        'Protection Class
        If protclassdd.SelectedValue >= 1 And protclassdd.SelectedValue <= 8 Then
            credits += 4
        End If
        'Mobile Home Park Credit (15 or more spaces)
        If mhparkdd.SelectedValue = "Yes" Then
            credits += 4
        End If
        'Age
        Dim age As Integer = 0
        If IsNumeric(txtYear.Text) Then
            age = Now.Year - CInt(txtYear.Text)
        End If

        If age <= 5 Then
            credits += 2
        End If
        If age <= 10 And age >= 6 Then
            credits += 1
        End If
        If age > 20 Then
            credits -= 1
        End If
        'Insured age
        If IsNumeric(txtDOB1.Text.Substring(txtDOB1.Text.Length - 4, 4)) Then
            Dim Insuredage As Integer = Now.Year - CInt(txtDOB1.Text.Substring(txtDOB1.Text.Length - 4, 4))
            If Insuredage >= 50 Then
                credits += 1
            End If
        End If

        'Dim Insuredage As Integer = Now.Year - CInt(txtDOB.Text.Substring(txtDOB.Text.Length - 4, 4))
        'If Insuredage >= 50 Then
        '    credits += 1
        'End If




        'get number of prior claims
        Dim numberOfClaims As Integer = 0
        If IsDate(txtLoss1Date.Text) = True And txtLoss1Date.Text <> "1/1/1900" Then
            numberOfClaims += 1
        End If
        If IsDate(txtLoss2Date.Text) = True And txtLoss2Date.Text <> "1/1/1900" Then
            numberOfClaims += 1
        End If
        If IsDate(txtLoss3Date.Text) = True And txtLoss3Date.Text <> "1/1/1900" Then
            numberOfClaims += 1
        End If
        If numberOfClaims = 0 Then
            credits += 1
        End If
        If credits > 7 Then
            credits = 7
        End If

        CreditsPercentage = credits * GLOBALCREDITPERCENTAGE
        Return CreditsPercentage
    End Function
    Protected Sub setARDefaults(ByVal value As Integer)
        '*******PACKAGE PROGRAM***************
        'Package other structures defaults to 10%
        txt_unattstr_AR1.Text = Math.Round(CDbl(value * 0.1))
        ar_unattStr1.Text = String.Format("{0:C0}", Math.Round(CDbl(value * 0.1)))

        'Package personal Property defaults to 40%
        txt_pp_AR1.Text = Math.Round(CDbl(value * 0.4))
        ar_perEff1.Text = String.Format("{0:C0}", Math.Round(CDbl(value * 0.4)))


        'Package personal liability defaults to 50,000
        dd_pl_AR1.SelectedValue = "$50,000"
        ar_perLiab1.Text = "$50,000"
        'Package Med Payments defaults to 500
        dd_mp_AR1.SelectedValue = "$500"
        ar_medpay1.Text = "$500"
        'Package AOP Ded defaults to 500
        dd_aop_AR1.SelectedValue = "$500"
        'Package Hurricane Ded defaults to 2%
        dd_hurded_AR1.SelectedValue = "2%"
        '*******END PACKAGE PROGRAM***************

        '*******STANDARD PROGRAM***************
        'Package AOP Ded defaults to 500
        dd_aop_AR2.SelectedValue = "$500"
        'Package Hurricane Ded defaults to 2%
        dd_hurded_AR2.SelectedValue = "2%"

        '*******END STANDARD PROGRAM***************

        '*******RENTAL PROGRAM***************
        'Package AOP Ded defaults to 500
        dd_aop_AR3.SelectedValue = "$500"
        'Package Hurricane Ded defaults to 2%
        dd_hurded_AR3.SelectedValue = "2%"
        '*******END RENTAL PROGRAM***************

    End Sub
    Protected Function packageOptionsAreAboveDefaults()

        Return False
    End Function

    'End AR
    '**************************************************

    'LLoyds
    '**************************************************
    Public Sub LoadLloydsFees()
        Dim ds As System.Data.DataSet
        Dim i As Integer
        Dim currentIndex, currentValue As String
        Dim WhereClause As String = " WHERE "
        WhereClause &= " state='" & lblState.Text & "' "
        Try
            ds = runQueryDS("SELECT * FROM dbo.tblLloydsOptions " & WhereClause & " ", "ColonialMHConnectionString")
            If ds.Tables(0).Rows.Count > 0 Then
                For i = 0 To ds.Tables(0).Rows.Count - 1
                    currentIndex = ds.Tables(0).Rows(i).Item("type").ToString
                    currentValue = ds.Tables(0).Rows(i).Item("rate").ToString
                    Select Case currentIndex
                        Case "OP_COV_AS_PE_SINGLE"
                            OPCOVPESINGLE.Text = FormatCurrency(CDbl(currentValue))
                        Case "OP_COV_AS_PE_DOUBLE"
                            OPCOVPEDOUBLE.Text = FormatCurrency(CDbl(currentValue))
                        Case "PE_REP_COST"
                            PEREPCOST.Text = FormatCurrency(CDbl(currentValue))

                        Case "FULL_REPAIR"
                            FULLREPAIR.Text = FormatCurrency(CDbl(currentValue))

                        Case "PER_LIAB_25000"
                            PERLIAB25.Text = FormatCurrency(CDbl(currentValue))

                        Case "PER_LIAB_50000"
                            PERLIAB50.Text = FormatCurrency(CDbl(currentValue))

                        Case "PER_LIAB_100000"
                            PERLIAB100.Text = FormatCurrency(CDbl(currentValue))

                        Case "PER_LIAB_300000"
                            PERLIAB300.Text = FormatCurrency(CDbl(currentValue))

                        Case "PREMISE_LIAB_25000"
                            PREMLIAB25.Text = FormatCurrency(CDbl(currentValue))

                        Case "PREMISE_LIAB_50000"
                            PREMLIAB50.Text = FormatCurrency(CDbl(currentValue))

                        Case "PREMISE_LIAB_100000"
                            PREMLIAB100.Text = FormatCurrency(CDbl(currentValue))

                        Case "DED_ALL_OTHER_PERIL"
                            DEDALLOTHER.Text = FormatCurrency(CDbl(currentValue))

                        Case "MH_REPLACE_COST"
                            MHREPCOST.Text = FormatCurrency(CDbl(currentValue))

                        Case "SEASONAL_SURCHARE"
                            SEASSUR.Text = FormatCurrency(CDbl(currentValue))



                    End Select



                Next
            Else
                'No results
            End If
        Catch ex As Exception

        End Try
    End Sub

    Public Sub calcLloyds()
        For Each li As ListItem In optcbl.Items
            If li.Value = "PE Replacement Cost" And li.Selected Then
                Lloyds_PERep.Text = PEREPCOST.Text
            End If
            If li.Value = "Full Repair" And li.Selected Then
                Lloyds_FullRep.Text = FULLREPAIR.Text
            End If
            If li.Value = "MH Replacement Cost (0 - 10 years)" And li.Selected Then
                Lloyds_MHRepCost.Text = MHREPCOST.Text
            End If
            If li.Value = "MH Replacement Cost (0 - 10 years)" Then
                If CInt(txtYear.Text) < (Now.Year - 10) Then
                    li.Attributes.Add("style", "display:none")
                End If
            End If


        Next
        Select Case LlyodsPremLiabdd.SelectedValue.ToString
            Case "$25,000"
                Lloyds_PremLiab.Text = PREMLIAB25.Text
            Case "$50,000"
                Lloyds_PremLiab.Text = PREMLIAB50.Text
            Case "$100,000"
                Lloyds_PremLiab.Text = PREMLIAB100.Text
        End Select

        Select Case LlyodsLiabdd.SelectedValue.ToString
            Case "$25,000"
                Lloyds_PerLiab.Text = PERLIAB25.Text
            Case "$50,000"
                Lloyds_PerLiab.Text = PERLIAB50.Text
            Case "$100,000"
                Lloyds_PerLiab.Text = PERLIAB100.Text
            Case "$300,000"
                Lloyds_PerLiab.Text = PERLIAB300.Text
        End Select
        Lloyds_Total.Text = CDbl(Lloyds_Dwell.Text) + CDbl(Lloyds_PerLiab.Text) + CDbl(Lloyds_PremLiab.Text) + CDbl(Lloyds_AAS.Text) + CDbl(Lloyds_APE.Text) + CDbl(Lloyds_PERep.Text) + CDbl(Lloyds_FullRep.Text) + CDbl(Lloyds_MHRepCost.Text)


        Dim ds As System.Data.DataSet
        Dim WhereClause As String = " WHERE "
        Dim homeUse As String = homeusedd.SelectedItem.Text.ToUpper
        Dim homeType As String = typedd.SelectedItem.Text.ToUpper
        Dim manf As String = manfdd.SelectedItem.Text.ToUpper
        Dim homeAge As Integer = Now.Year - CInt(txtYear.Text)
        Dim credits As Double
        Dim manfCredit, ageCredit As Boolean




        If homeUse = "OWNER" Or homeUse = "SEASONAL" Then
            If homeType = "SINGLEWIDE" Then
                WhereClause &= " type = 'OWNER OCCUPIED SEASONAL SW' AND state='" & lblState.Text & "' "
            Else ' Doublewide & Modular
                WhereClause &= " type = 'OWNER OCCUPIED SEASONAL DW' AND state='" & lblState.Text & "' "

            End If
        End If



        Try
            ds = runQueryDS("SELECT rate FROM dbo.tblLloydsRates " & WhereClause & " ", "ColonialMHConnectionString")
            If ds.Tables(0).Rows.Count > 0 Then
                Lloyds_Dwell.Text = FormatCurrency(CDbl(ds.Tables(0).Rows(0).Item("rate").ToString()) * (CDbl(txtcvgamt.Text) / 100))
                Lloyds_Dwell.Text = CInt(Lloyds_Dwell.Text)
            Else
                'No results
            End If
            'Get preferred Manf
            ds = runQueryDS("SELECT* FROM tblManf WHERE PrefManf = 'Y' AND UPPER(Manfufacturers) =  UPPER('" & manf & "')", "ColonialMHConnectionString")
            If ds.Tables(0).Rows.Count > 0 Then
                manfCredit = True
            Else
                manfCredit = False
            End If

            If homeAge <= 15 Then
                ageCredit = True
            Else
                ageCredit = False
            End If

            If ageCredit And manfCredit Then
                credits = (CDbl(Lloyds_Dwell.Text) * 0.15) * -1
            Else
                If ageCredit Then
                    credits = (CDbl(Lloyds_Dwell.Text) * 0.1) * -1
                Else
                    If manfCredit Then
                        credits = (CDbl(Lloyds_Dwell.Text) * 0.1) * -1
                    Else
                        credits = "0.00"
                    End If
                End If
            End If
            Lloyds_Credits.Text = FormatCurrency(credits)
        Catch ex As Exception

        End Try

    End Sub

    Public Sub calcLloydsTotals()
        Dim GrandTotal As Double = 0.0
        GrandTotal = (CDbl(Lloyds_Dwell.Text) - CDbl(Lloyds_Credits.Text)) + CDbl(Lloyds_PerLiab.Text) + CDbl(Lloyds_PremLiab.Text) + CDbl(Lloyds_APE.Text) + CDbl(Lloyds_APE.Text) + CDbl(Lloyds_PERep.Text) + CDbl(Lloyds_FullRep.Text) + CDbl(Lloyds_100Ded.Text) + CDbl(Lloyds_MHRepCost.Text)
        Lloyds_Total.Text = FormatCurrency(GrandTotal)
    End Sub
    Public Sub calcLloydsCredits()
        If aopdd.SelectedValue.ToString = "$1000" Then
            Lloyds_100Ded.Text = FormatCurrency("-75.00")
        Else
            Lloyds_100Ded.Text = FormatCurrency("0.00")
        End If

    End Sub

    'Save and transfer to Lloyds application Page
    Public Sub TransferToLloydsApp()
        'Savecalc
        If Request.QueryString("quoteID") <> "" Or Session("beenSaved") = "True" Then
            updateLloydsQuote(Request.QueryString("quoteID"))
        Else
            save()



        End If
        Response.Redirect("../Application/LloydsApplication.aspx?quoteID=" & lblquoteNumber.Text & "")
    End Sub
    'End Lloyds
    '**************************************************


    '****************************************************
    'End  Premimum
    '****************************************************

    Public Sub UpdateDistanceToCoast(ByVal state As String)
        distToCoastDD.SelectedIndex = 0
        distToCoastDD.Items.Clear()
        If state = "DE" Then
            distToCoastDD.Items.Add("")
            distToCoastDD.Items.Add("Less than 0.5 miles")
            distToCoastDD.Items.Add("0.5 – 5 miles")
            distToCoastDD.Items.Add("Greater than 5 miles")


        ElseIf state = "SC" Then

            distToCoastDD.Items.Add("")
            distToCoastDD.Items.Add("Less than 2 miles")
            distToCoastDD.Items.Add("2-10 miles")
            distToCoastDD.Items.Add("10-20 miles")
            distToCoastDD.Items.Add("20-50 miles")
            distToCoastDD.Items.Add("50+ miles")
        ElseIf state = "VA" Then

            distToCoastDD.Items.Add("")
            distToCoastDD.Items.Add("Less than 2 miles")
            distToCoastDD.Items.Add("2-10 miles")
            distToCoastDD.Items.Add("10-20 miles")
            distToCoastDD.Items.Add("20-50 miles")
            distToCoastDD.Items.Add("50+ miles")
        ElseIf state = "GA" Then

            distToCoastDD.Items.Add("")
            distToCoastDD.Items.Add("2-10 miles")
            distToCoastDD.Items.Add("10-20 miles")
            distToCoastDD.Items.Add("20-50 miles")
            distToCoastDD.Items.Add("50+ miles")
        ElseIf state = "NC" Then

            distToCoastDD.Items.Add("")
            distToCoastDD.Items.Add("Less than 2 miles")
            distToCoastDD.Items.Add("2-10 miles")
            distToCoastDD.Items.Add("10-20 miles")
            distToCoastDD.Items.Add("20-50 miles")
            distToCoastDD.Items.Add("50+ miles")
        ElseIf state = "TN" Then

            distToCoastDD.Items.Add("50+ miles")
        Else
            distToCoastDD.Items.Add("")
            distToCoastDD.Items.Add("Less than 2 miles")
            distToCoastDD.Items.Add("2 – 5 miles")
            distToCoastDD.Items.Add("5 – 15 miles")
            distToCoastDD.Items.Add("Greater than 15 miles")
        End If

    End Sub '
    'Calc Value 
    Public Sub CalcValuation_Click() Handles calcValue.Click
        Dim length, width, year, manf, state As String
        Dim statefct, makerFCT, rqsqrFCT, ageFCT, sqft As Double
        Dim ds, ds2, ds3, ds4 As System.Data.DataSet

        'set default value
        txtValuation.Text = "0"

        If lblState.Text = "" Then
            Exit Sub
        End If
        state = lblState.Text
        manf = manfdd.SelectedItem.Text
        If UCase(manf) = UCase("Legacy") Then
            manf = UCase("Fleetwood")
        End If
        If UCase(manf) = UCase("Deer Valley") Then
            manf = UCase("Palm Harbor")
        End If
        width = txtWidth.Text
        length = txtLength.Text
        year = txtYear.Text

        Try
            sqft = CInt(length) * CInt(width)

            'Calculate the age of the home
            Dim curDate As New Date()
            Dim homeAge As Integer
            homeAge = Date.Now.Year - CInt(year)
            If homeAge <= 0 Then
                homeAge = 1
            End If


            ds = runQueryDS("SELECT [isfct] FROM [iris2000].[tcg].[tbstates]  WHERE issta = '" & state & "'", "CommonIRISConnectionString")
            ds2 = runQueryDS("SELECT imfct FROM TbVrm WHERE imnme = '" & manf & "'", "CommonIRISConnectionString")
            ds3 = runQueryDS("SELECT TOP 1 iadpv FROM TbVr2 WHERE iaage >= '" & homeAge & "'", "CommonIRISConnectionString")
            ds4 = runQueryDS("SELECT ibdsq1,ibdsq FROM TbVr1 WHERE ibara >= '" & sqft & "'", "CommonIRISConnectionString")


            If ds.Tables(0).Rows.Count > 0 Then
                statefct = CDbl(ds.Tables(0).Rows(0).Item("isfct").ToString)
            End If
            If ds2.Tables(0).Rows.Count > 0 Then
                makerFCT = CDbl(ds2.Tables(0).Rows(0).Item("imfct").ToString)
            End If
            If ds3.Tables(0).Rows.Count > 0 Then
                ageFCT = CDbl(ds3.Tables(0).Rows(0).Item("iadpv").ToString)
            End If
            If ds4.Tables(0).Rows.Count > 0 Then
                If width > 16 Then
                    rqsqrFCT = CDbl(ds4.Tables(0).Rows(0).Item("ibdsq1").ToString)
                Else
                    rqsqrFCT = CDbl(ds4.Tables(0).Rows(0).Item("ibdsq").ToString)
                End If

            End If
            Dim firCalc, secondCalc, thirdCalc As Double
            firCalc = rqsqrFCT * statefct
            secondCalc = makerFCT * ageFCT
            thirdCalc = firCalc * secondCalc
            txtValuation.Text = thirdCalc * sqft * 0.9
            txtValuation.Text = FormatCurrency(txtValuation.Text)
            txtValuation.Text = txtValuation.Text.Replace("$", "")
            txtValuation.Text = txtValuation.Text.Substring(0, txtValuation.Text.IndexOf("."))

            If lblState.Text = "FL" Then
                If IsNumeric(txtYear.Text) Then
                    If CInt(txtYear.Text) >= 1995 Then
                        ddansi.SelectedValue = "Yes"
                        UpdatePanel2.Update()
                    Else
                        ddansi.SelectedValue = "No"
                        UpdatePanel2.Update()
                    End If
                End If
            End If
            txtcvgamt.Focus()
        Catch ex As Exception

        End Try






        updateValuationPanel.Update()

        txtValuation.Focus()

    End Sub
    '****************************************************
    ' Sub Lookup
    '****************************************************

    'Added txtSubNumber_TextChange 11-30-2012 for iddues #14
    Public Sub txtSubNumber_TextChange() Handles subBtn.Click
        If Me.txtSubNumber.Text.Length < 4 Then Exit Sub
        If Me.txtSubNumber.Text = "" Then Exit Sub

        Dim cn As New SqlClient.SqlConnection(System.Configuration.ConfigurationManager.ConnectionStrings("ColonialWebConnectionString").ConnectionString)
        Try
            Dim cmd As New SqlClient.SqlCommand
            cmd.Connection = cn
            cmd.CommandText = "SELECT * FROM vwAgents WHERE AgencyCode = '" & txtSubNumber.Text & "' and Active = 1 ORDER BY AgentID"

            If cmd.Connection.State = ConnectionState.Closed Then cmd.Connection.Open()
            ddlSub_main.Items.Clear()
            ddlSub_main.Items.Add("- Choose One -", Nothing)
            'ddlSub_main.Items.FindByText("- Choose One -").Index = 0
            'ddlSub_main.Items.Add(New ListItem("- Choose One -", "0"))

            Dim rs As SqlClient.SqlDataReader = cmd.ExecuteReader
            Do While rs.Read
                'ddlSub_main.Items.Add(New ListItem(rs("AgentID") & " - " & rs("AgentName") & " (" & rs("AgentEmail") & ")", rs("ID")))
                ddlSub_main.Items.Add(rs("AgentID") & " - " & rs("AgentName") & " (" & rs("AgentEmail") & ")", rs("ID").ToString())
                ' ddlSub_main.Items(rs("AgentID") & " - " & rs("AgentName") & " (" & rs("AgentEmail") & ")").Index = rs("ID").ToString()

            Loop
            rs.Close()
            If ddlSub_main.Items.Count > 0 Then
                ddlSub_main.SelectedIndex = 0
                Me.ddlSub_main.Visible = True
                Me.ddlSub_main.Focus()
                Me.ddlSub_main.SelectedItem = ddlSub_main.Items.FindByText("- Choose One -")
                txtsubNumber_results.Visible = False
            Else
                Me.ddlSub_main.Visible = False
                txtsubNumber_results.Visible = True
            End If
        Catch ex As Exception
            'Error
        Finally
            cn.Close()
        End Try

    End Sub
    'Added ddlSub_main_IndexChanged 11-30-2012 for iddues #14
    Public Sub ddlSub_main_IndexChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles ddlSub_main.SelectedIndexChanged
        SelectSub()
        txtAppFirstName.Focus()
    End Sub
    'Added btnUseSub2_Click 11-30-2012 for iddues #14
    Public Sub SelectSub()
        If ddlSub_main Is Nothing Then
        Else


            If ddlSub_main.SelectedItem.Value <> "0" Then 'And ddlSub_main.SelectedItem <> "New" Then
                Dim cn As New SqlClient.SqlConnection(System.Configuration.ConfigurationManager.ConnectionStrings("ColonialWebConnectionString").ConnectionString)
                Try
                    Dim cmd As New SqlClient.SqlCommand
                    cmd.Connection = cn
                    cmd.CommandText = "SELECT * FROM vwAgents WHERE ID = " & ddlSub_main.SelectedItem.Value 'ddlSub_main.SelectedValue
                    If cmd.Connection.State = ConnectionState.Closed Then cmd.Connection.Open()

                    Dim rs As SqlClient.SqlDataReader = cmd.ExecuteReader
                    Do While rs.Read
                        txtConEmail.Text = rs("AgentEmail")
                        txtAgConName.Text = rs("AgentName")
                        lblAgency.Text = rs("AgencyName")
                        lblAgency.Text.Replace("  ", "")

                    Loop
                    rs.Close()
                Catch ex As Exception

                End Try

                Me.ddlSub_main.Visible = False
                txtsubNumber_results.Visible = False
            Else

            End If
            SubUpdatepanel1.Update()
        End If

    End Sub
    '*****************************************************
    'END  Sub Lookup
    '*****************************************************
    '****************************************************
    ' Zip Code
    '****************************************************
    'Public Sub txtZip_ItemClick(ByVal sender As Object, ByVal e As EventArgs) Handles txtZip.TextChanged
    '    LoadZip(txtZip.Text)

    'End Sub
    Public Sub ZipLook_ItemClick(ByVal sender As Object, ByVal e As EventArgs) Handles zipbtn2.Click
        LoadZip(txtZip.Text)
        If lblState.Text <> "FL" Then
            'Label166.Visible = False
            'ddansi.Visible = False
            'ddansi.Enabled = False
            Label166.Style.Item("display") = "none"
            ddansi.Style.Item("display") = "none"
        Else
            Label166.Style.Item("display") = ""
            ddansi.Style.Item("display") = ""
            'Label166.Visible = True
            'ddansi.Visible = True
            'ddansi.Enabled = True
            'transi.Style.Item("display") = ""
        End If
        If lblState.Text = "SC" Then
            distToCoastDD.SelectedValue = ""
        End If
        If UCase(txtCounty.Text) = UCase("Horry") Then
            ASPxPopupControl5.Enabled = True

            ASPxPopupControl5.PopupHorizontalAlign = DevExpress.Web.ASPxClasses.PopupHorizontalAlign.Center
            ASPxPopupControl5.ShowOnPageLoad = True
        End If
        distToCoastDD.Focus()
        UpdatePanel1.Update()
        UpdatePanel2.Update()
        'txtZip.Focus()
        distToCoastDD.Focus()
    End Sub
    'This sub will query the database for zip codes.
    Public Sub LoadZip(ByVal currentZip As String)
        cddlCity.Items.Clear()
        lblState.Text = ""
        txtCounty.Text = ""

        Dim dbConn As String = ConfigurationManager.ConnectionStrings("CommonDbConnectionString").ConnectionString
        Dim conn As New SqlConnection(dbConn)
        Dim cmd As New SqlCommand("SELECT szCity AS City, szCounty AS County, szState_cd AS State FROM [wrwpaqbx_admin].[tblZip] WHERE szZip = '" & txtZip.Text & "' ", conn)

        Try
            If conn.State = Data.ConnectionState.Closed Then conn.Open()
            Dim rs As SqlDataReader = cmd.ExecuteReader()
            Do While rs.Read
                cddlCity.Items.Add(rs("City").ToString())
                lblState.Text = rs("State").ToString()
                txtCounty.Text = rs("County").ToString()
                UpdateDistanceToCoast(rs("State").ToString())
            Loop

            rs.Close()


        Catch ex As Exception
            'Error
        Finally
            conn.Close()
        End Try
        updateZipPanel.Update()

        DistToCoastUpdatepanel.Update()
        distToCoastDD.Focus()

    End Sub

    '*****************************************************
    'END  Zip Code
    '*****************************************************

    '*****************************************************
    'PRINT
    '*****************************************************
    Public Sub printbtn_Click(ByVal sender As Object, ByVal e As EventArgs)
        If Request.QueryString("quoteID") <> "" Or Session("beenSaved") = "True" Then
            updateQuote(Request.QueryString("quoteID"))
        Else 'New Quote
            save()
        End If
        Dim pack As String
        pack = rateTypelbl.Text

        Common.AjaxOpenWindow(Me.Page, "quotePrint.aspx?quoteID=" & lblquoteNumber.Text & "", Nothing)
    End Sub
    'This is for the new finance print button
    Public Sub printFinbtn_Click(ByVal sender As Object, ByVal e As EventArgs) Handles premFinbtn.Click
        Dim fin As New Finance
        Dim DetailString As String
        If Request.QueryString("quoteID") <> "" Then
            'save()

            'Dim str As String
            Dim ds As System.Data.DataSet
            ds = runQueryDS("SELECT * FROM dbo.vwFinancingInfo WHERE quoteID = '" & Request.QueryString("quoteID") & "' ", "ColonialMHConnectionString")
            If ds.Tables(0).Rows.Count > 0 Then ' Show current Contract.
                If fin.CalcFinancing(Request.QueryString("quoteID")) Then
                    Common.AjaxOpenWindow(Me.Page, "/Quote/quotePrintFinanceImport.aspx?quoteID=" & Request.QueryString("quoteID") & "", Nothing)
                Else

                End If
            Else 'New Quote Just show details.
                DetailString = fin.CalcFinancingOnly(lblquoteNumber.Text, primeRateDPDD.SelectedValue.ToString)
                financeInfo.Text = DetailString
                financeupdatePanel.Update()
                ModalPopupExtender3.Show()
            End If
        End If
    End Sub
    Public Sub updatePrimeRateDownPayment(ByVal sender As Object, ByVal e As EventArgs) 'Handles primeRateDPDD.SelectedIndexChanged
        Dim DetailString As String
        Dim fin As New Finance
        primeRateDPDD.SelectedValue.ToString()
        DetailString = fin.CalcFinancingOnly(lblquoteNumber.Text, primeRateDPDD.SelectedValue.ToString)
        financeInfo.Text = DetailString
        financeupdatePanel.Update()
        ModalPopupExtender3.Show()
    End Sub

    ''This is for the new finance print button
    'Public Sub printFinbtn_Click(ByVal sender As Object, ByVal e As EventArgs) Handles premFinbtn.Click
    '    If Request.QueryString("quoteID") <> "" Then
    '        Dim fin As New Finance
    '        If fin.CalcFinancing(Request.QueryString("quoteID")) Then
    '            Common.AjaxOpenWindow(Me.Page, "/Quote/quotePrintFinanceImport.aspx?quoteID=" & Request.QueryString("quoteID") & "", Nothing)
    '        Else

    '        End If
    '    End If
    'End Sub


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


    Private Sub LoadCalcintoDB(ByVal quoteID As String)

        Dim ds As System.Data.DataSet
        Dim tsql As String
        calcAR()

        tsql = "EXEC sp_updateQuoteCalc "
        tsql += "'" & quoteID.Replace("$", "").Replace(",", "") & "',"
        tsql += "'" & PackPrem.Replace("$", "").Replace(",", "") & "',"
        tsql += "'" & StandPrem.Replace("$", "").Replace(",", "") & "',"
        tsql += "'" & RentPrem.Replace("$", "").Replace(",", "") & "',"
        tsql += "'" & CreditPerc.Replace("$", "").Replace(",", "") & "',"
        tsql += "'" & Packsub1.Replace("$", "").Replace(",", "") & "',"
        tsql += "'" & Standsub1.Replace("$", "").Replace(",", "") & "',"
        tsql += "'" & Rentsub1.Replace("$", "").Replace(",", "") & "',"
        tsql += "'" & PackNonHur.Replace("$", "").Replace(",", "") & "',"
        tsql += "'" & PackHur.Replace("$", "").Replace(",", "") & "',"
        tsql += "'" & StandNonHur.Replace("$", "").Replace(",", "") & "',"
        tsql += "'" & StandHur.Replace("$", "").Replace(",", "") & "',"
        tsql += "'" & RentNonHur.Replace("$", "").Replace(",", "") & "',"
        tsql += "'" & RentHur.Replace("$", "").Replace(",", "") & "',"
        tsql += "'" & PackOption.Replace("$", "").Replace(",", "") & "',"
        tsql += "'" & StandOpt.Replace("$", "").Replace(",", "") & "',"
        tsql += "'" & RentOpt.Replace("$", "").Replace(",", "") & "'"


        ds = runQueryDS(tsql, "ColonialMHConnectionString")


    End Sub
    Private Sub addPersProp(ByVal quoteID As String, ByVal premtyp As String, ByVal desc As String, ByVal strvalue As String)

        Dim ds As System.Data.DataSet
        Dim tsql As String

        tsql = "Insert Into tblARPersonProp Values("
        tsql += "'" & quoteID.Replace("$", "") & "',"
        tsql += "'" & premtyp.Replace("$", "") & "',"
        tsql += "'" & desc.Replace("$", "") & "',"
        tsql += "'" & strvalue.Replace("$", "") & "')"

        Try
            ds = runQueryDS(tsql, "ColonialMHConnectionString")
        Catch ex As Exception
            errortrap(tsql, "AddpersProperty", ex.Message)
        End Try




    End Sub
    Private Sub loadperspropar1(ByVal quoteid As String)
        Dim ds1 As System.Data.DataSet

        ds1 = Common.runQueryDS("Select * from tblARPersonProp where prem_type = 'Package' and quoteID = '" & quoteid & "'")
        If ds1.Tables(0).Rows.Count > 0 Then
            dsar1 = CType(Session("DataSet"), DataSet)
            totperpropar1 = CType(Session("PerPropAR1"), Decimal)
            Dim dataTable As DataTable
            DataTable = dsar1.Tables(0)
            Dim totalvalue As Decimal
            Dim i As Integer = 0

            For Each rows As DataRow In ds1.Tables(0).Rows
                Dim row As DataRow = dataTable.NewRow()
                row("ID") = rows("id").ToString()
                row("description") = rows("pp_description").ToString()
                row("value") = rows("PP_amount").ToString()
                totalvalue += CDec(rows("PP_amount").ToString())
                dataTable.Rows.Add(row)
                i += 1
                row = Nothing

            Next

            ASPxGridView1.DataSource = dsar1.Tables(0)
            ASPxGridView1.DataBind()
            totperpropar1 += totalvalue
            Session("PerPropAR1") += totalvalue
            'Session("DataSet") = dataTable
        End If

    End Sub
    Private Sub loadperspropar2(ByVal quoteid As String)

        Dim ds2 As System.Data.DataSet

        ds2 = Common.runQueryDS("Select * from tblARPersonProp where prem_type = 'Standard' and quoteID = '" & quoteid & "'")
        If ds2.Tables(0).Rows.Count > 0 Then
            dsar2 = CType(Session("DataSet2"), DataSet)
            totperpropar2 = CType(Session("PerPropAR2"), Decimal)
            Dim dataTable As DataTable
            dataTable = dsar2.Tables(0)
            Dim totalvalue As Decimal
            Dim i As Integer = 0

            For Each rows As DataRow In ds2.Tables(0).Rows
                Dim row As DataRow = dataTable.NewRow()
                row("ID") = rows("id").ToString()
                row("description") = rows("pp_description").ToString()
                row("value") = rows("PP_amount").ToString()
                totalvalue += CDec(rows("PP_amount").ToString())
                dataTable.Rows.Add(row)
                i += 1
                row = Nothing

            Next

            ASPxGridView2.DataSource = dsar2.Tables(0)
            ASPxGridView2.DataBind()
            totperpropar2 += totalvalue
            Session("PerPropAR2") += totalvalue
            'Session("DataSet") = dataTable
        End If


    End Sub


    Protected Sub ASPxGridView2_BeforePerformDataSelect(ByVal sender As Object, ByVal e As EventArgs)
        dsar1 = CType(Session("DataSet"), DataSet)
        Dim detailTable As DataTable = dsar1.Tables(0)
        Dim dv As DataView = New DataView(detailTable)
        Dim detailGridView As ASPxGridView = CType(sender, ASPxGridView)
        ' dv.RowFilter = "MasterID = " & detailGridView.GetMasterRowKeyValue().ToString()
        ' detailGridView.DataSource = dv
    End Sub
    Protected Sub ASPxGridView1_RowUpdating(ByVal sender As Object, ByVal e As DevExpress.Web.Data.ASPxDataUpdatingEventArgs)
        dsar1 = CType(Session("DataSet"), DataSet)
        Dim gridView As ASPxGridView = CType(sender, ASPxGridView)
        Dim dataTable As DataTable
        If gridView.SettingsDetail.IsDetailGrid Then
            dataTable = dsar1.Tables(1)
        Else
            dataTable = dsar1.Tables(0)
        End If
        Dim row As DataRow = dataTable.Rows.Find(e.Keys(0))
        Dim enumerator As IDictionaryEnumerator = e.NewValues.GetEnumerator()
        enumerator.Reset()
        Do While enumerator.MoveNext()
            row(enumerator.Key.ToString()) = enumerator.Value
        Loop
        gridView.CancelEdit()
        e.Cancel = True
        ASPxGridView1.DataSource = dsar1
    End Sub
    Protected Sub ASPxGridView1_RowInserting(ByVal sender As Object, ByVal e As DevExpress.Web.Data.ASPxDataInsertingEventArgs)
        dsar1 = CType(Session("DataSet"), DataSet)
        totperpropar1 = CType(Session("PerPropAR1"), Decimal)
        Dim gridView As ASPxGridView = CType(sender, ASPxGridView)
        Dim dataTable As DataTable
        Dim totalvalue As Decimal
        dataTable = dsar1.Tables(0)
        Dim row As DataRow = dataTable.NewRow()
        e.NewValues("ID") = GetNewId()
        Dim enumerator As IDictionaryEnumerator = e.NewValues.GetEnumerator()
        enumerator.Reset()
        Do While enumerator.MoveNext()
            If enumerator.Key.ToString() <> "Count" Then
                row(enumerator.Key.ToString()) = enumerator.Value
            End If
            If enumerator.Key.ToString() = "value" Then
                totalvalue += enumerator.Value
            End If
        Loop
        gridView.CancelEdit()
        e.Cancel = True
        dataTable.Rows.Add(row)
        ASPxGridView1.DataSource = dsar1
        totperpropar1 += totalvalue
        Session("PerPropAR1") += totalvalue

    End Sub

    Protected Sub ASPxGridView1_RowDeleting(ByVal sender As Object, ByVal e As DevExpress.Web.Data.ASPxDataDeletingEventArgs)
        Dim i As Integer = ASPxGridView1.FindVisibleIndexByKeyValue(e.Keys(ASPxGridView1.KeyFieldName))
        '  Dim c As Control = ASPxGridView1.FindDetailRowTemplateControl(i, "ASPxGridView2")
        totperpropar1 = CType(Session("PerPropAR1"), Decimal)
        Dim enumerator As IDictionaryEnumerator = e.Values.GetEnumerator()
        enumerator.Reset()
        Do While enumerator.MoveNext()
            If enumerator.Key.ToString() = "value" Then
                totperpropar1 -= enumerator.Value
                Session("PerPropAR1") -= enumerator.Value
            End If

        Loop
        e.Cancel = True
        dsar1 = CType(Session("DataSet"), DataSet)
        dsar1.Tables(0).Rows.Remove(dsar1.Tables(0).Rows.Find(e.Keys(ASPxGridView1.KeyFieldName)))
        ASPxGridView1.DataSource = dsar1

    End Sub

    Private Function GetNewId() As Integer
        dsar1 = CType(Session("DataSet"), DataSet)
        Dim table As DataTable = dsar1.Tables(0)
        If table.Rows.Count = 0 Then
            Return 0
        End If
        Dim max As Integer = Convert.ToInt32(table.Rows(0)("ID"))
        For i As Integer = 1 To table.Rows.Count - 1
            If Convert.ToInt32(table.Rows(i)("ID")) > max Then
                max = Convert.ToInt32(table.Rows(i)("ID"))
            End If
        Next i
        Return max + 1
    End Function
    Protected Sub ASPxGridView2_RowInserting(ByVal sender As Object, ByVal e As DevExpress.Web.Data.ASPxDataInsertingEventArgs)
        dsar2 = CType(Session("DataSet2"), DataSet)
        totperpropar2 = CType(Session("PerPropAR2"), Decimal)
        Dim gridView As ASPxGridView = CType(sender, ASPxGridView)
        Dim dataTable2 As DataTable
        Dim totalvalue As Decimal
        dataTable2 = dsar2.Tables(0)
        Dim row As DataRow = dataTable2.NewRow()
        e.NewValues("ID") = GetNewId2()
        Dim enumerator As IDictionaryEnumerator = e.NewValues.GetEnumerator()
        enumerator.Reset()
        Do While enumerator.MoveNext()
            If enumerator.Key.ToString() <> "Count" Then
                row(enumerator.Key.ToString()) = enumerator.Value
            End If
            If enumerator.Key.ToString() = "value" Then
                totalvalue += enumerator.Value
            End If
        Loop
        gridView.CancelEdit()
        e.Cancel = True
        dataTable2.Rows.Add(row)
        ASPxGridView2.DataSource = dsar2
        totperpropar2 += totalvalue
        Session("PerPropAR2") += totalvalue

    End Sub

    Protected Sub ASPxGridView2_RowDeleting(ByVal sender As Object, ByVal e As DevExpress.Web.Data.ASPxDataDeletingEventArgs)
        Dim i As Integer = ASPxGridView2.FindVisibleIndexByKeyValue(e.Keys(ASPxGridView2.KeyFieldName))
        '  Dim c As Control = ASPxGridView1.FindDetailRowTemplateControl(i, "ASPxGridView2")
        totperpropar2 = CType(Session("PerPropAR2"), Decimal)
        Dim enumerator As IDictionaryEnumerator = e.Values.GetEnumerator()
        enumerator.Reset()
        Do While enumerator.MoveNext()
            If enumerator.Key.ToString() = "value" Then
                totperpropar1 -= enumerator.Value
                Session("PerPropAR2") -= enumerator.Value
            End If

        Loop
        e.Cancel = True
        dsar2 = CType(Session("DataSet2"), DataSet)
        dsar2.Tables(0).Rows.Remove(dsar2.Tables(0).Rows.Find(e.Keys(ASPxGridView2.KeyFieldName)))
        ASPxGridView2.DataSource = dsar2

    End Sub

    Private Function GetNewId2() As Integer
        dsar2 = CType(Session("DataSet2"), DataSet)
        Dim table As DataTable = dsar2.Tables(0)
        If table.Rows.Count = 0 Then
            Return 0
        End If
        Dim max As Integer = Convert.ToInt32(table.Rows(0)("ID"))
        For i As Integer = 1 To table.Rows.Count - 1
            If Convert.ToInt32(table.Rows(i)("ID")) > max Then
                max = Convert.ToInt32(table.Rows(i)("ID"))
            End If
        Next i
        Return max + 1
    End Function


    Private Sub printbtn1_Click(sender As Object, e As System.EventArgs) Handles printbtn1.Click
        If Request.QueryString("quoteID") <> "" Or Session("beenSaved") = "True" Then
            updateQuote(Request.QueryString("quoteID"))
        Else 'New Quote
            save()
        End If
        Dim pack As String
        pack = rateTypelbl.Text

        Common.AjaxOpenWindow(Me.Page, "quotePrint.aspx?quoteID=" & lblquoteNumber.Text & "", Nothing)
    End Sub
    Private Sub errortrap(ByVal sqlcomm As String, ByVal appsub As String, ByVal errormsg As String)
        Dim intRowsAff As Integer
        Dim Connection As String = System.Configuration.ConfigurationManager.ConnectionStrings("ColonialMHConnectionString").ConnectionString
        Dim dbConnection As System.Data.IDbConnection = New System.Data.SqlClient.SqlConnection(Connection)
        Dim cmd As New SqlCommand("sp_InsertError", dbConnection)
        cmd.CommandType = CommandType.StoredProcedure
        cmd.Parameters.Add("@code", SqlDbType.VarChar, 8000).Value = sqlcomm
        cmd.Parameters.Add("@Page", SqlDbType.VarChar, 50).Value = "Quote"
        cmd.Parameters.Add("@sub", SqlDbType.VarChar, 50).Value = appsub
        cmd.Parameters.Add("@msg", SqlDbType.VarChar, 8000).Value = errormsg
        Try
            cmd.Connection.Open()
            intRowsAff = cmd.ExecuteNonQuery()
        Catch ex As Exception

        End Try


    End Sub

    Protected Sub btnBeforeApp_Click(sender As Object, e As EventArgs) Handles btnBeforeApp.Click

        If txtAgConName.Text <> "" And txtConEmail.Text <> "" Then

            Try

                If Request.QueryString("quoteID") <> "" Or Session("beenSaved") = "True" Then
                    updateQuote(Request.QueryString("quoteID"))
                Else 'New Quote
                    save()
                End If


                ' Server.Transfer("/Application/ARApplication.aspx?quoteID=" & quoteID & "", True)
                'Response.RedirectPermanent("/Application/ARApplication.aspx?quoteID=" & quoteID & "")
            Catch ex As Exception
                errortrap("Redirecting", "Save and Open Application", ex.Message)
            End Try
            Dim quoteID As String
            Dim lbl As New Label()
            lbl.Text = "<script language='javascript'>ARPremTotalRedirect();" & "<" & "/script>"
            Page.Controls.Add(lbl)
            quoteID = lblquoteNumber.Text
            ' HttpContext.Current.Response.Redirect("/Application/ARApplication.aspx?quoteID=" & quoteID & "")
            'Response.Redirect("/Application/ARApplication.aspx?quoteID=" & quoteID & "", False)

            Dim url As String = "/Application/ARApplication.aspx?quoteID=" & quoteID & ""
            Dim redirectURL As String = Page.ResolveClientUrl(url)
            Dim scrpt As String = "window.location = '" & redirectURL & "';"
            ScriptManager.RegisterStartupScript(Me, GetType(Page), "RedirectTo", scrpt, True)

        Else
            ASPxPopupControl1.Enabled = True
            Label173.Text = "You Must select an agent as well as agent email."
            'ASPxPopupControl1.PopupElementID = "prmbtn"
            ASPxPopupControl1.PopupHorizontalAlign = DevExpress.Web.ASPxClasses.PopupHorizontalAlign.Center
            ASPxPopupControl1.ShowOnPageLoad = True
        End If


        ' Common.AjaxOpenWindow(Me.Page, "/Application/ARApplication.aspx?quoteID=" & quoteID & "", Nothing)
    End Sub
    Public Sub LloydRedirect(ByRef QuoteID As String)

        Dim url As String = "/Application/LloydsApplication.aspx?quoteID=" & QuoteID & ""
        Dim redirectURL As String = Page.ResolveClientUrl(url)
        Dim scrpt As String = "window.location = '" & redirectURL & "';"
        ScriptManager.RegisterStartupScript(Me, GetType(Page), "RedirectTo", scrpt, True)

    End Sub
    Public Sub AegisRedirect(ByRef QuoteID As String)

        Dim url As String = "/Application/AigesApplication.aspx?quoteID=" & QuoteID & ""
        Dim redirectURL As String = Page.ResolveClientUrl(url)
        Dim scrpt As String = "window.location = '" & redirectURL & "';"
        ScriptManager.RegisterStartupScript(Me, GetType(Page), "RedirectTo", scrpt, True)


    End Sub
    Public Sub AegisVintageRedirect(ByRef QuoteID As String)

        Dim url As String = "/Application/VintageAigesApplication.aspx?quoteID=" & QuoteID & ""
        Dim redirectURL As String = Page.ResolveClientUrl(url)
        Dim scrpt As String = "window.location = '" & redirectURL & "';"
        ScriptManager.RegisterStartupScript(Me, GetType(Page), "RedirectTo", scrpt, True)


    End Sub
    Public Sub AMSLICRedirect(ByRef QuoteID As String)

        Dim url As String = "/Application/AMSLICApllication.aspx?quoteID=" & QuoteID & ""
        Dim redirectURL As String = Page.ResolveClientUrl(url)
        Dim scrpt As String = "window.location = '" & redirectURL & "';"
        ScriptManager.RegisterStartupScript(Me, GetType(Page), "RedirectTo", scrpt, True)


    End Sub
    Public Sub WMJRedirect(ByRef QuoteID As String)

        Dim url As String = "/Application/WMJApplication.aspx?quoteID=" & QuoteID & ""
        Dim redirectURL As String = Page.ResolveClientUrl(url)
        Dim scrpt As String = "window.location = '" & redirectURL & "';"
        ScriptManager.RegisterStartupScript(Me, GetType(Page), "RedirectTo", scrpt, True)


    End Sub
    Public Sub LloydPrintQuote(ByVal QuoteID As String)

        If QuoteID <> "" Then

            updateQuote(QuoteID)
        Else

            save()

        End If
        Common.AjaxOpenWindow(Me.Page, "quotePrint.aspx?quoteID=" & lblquoteNumber.Text & "", Nothing)

    End Sub

    Protected Sub btndate_Click(sender As Object, e As EventArgs) Handles btndate.Click
        If IsNothing(mySession.CurrentUser.AgentName) Or mySession.CurrentUser.AgentName = "" Then
        Else

            If IsDate(txtEffDate.Text) Then
                Dim efdate As Date
                efdate = txtEffDate.Text
                If Date.Now > efdate Then
                    If IsDate(originaldte.Text) Then
                        Dim olddte As Date
                        olddte = originaldte.Text
                        If efdate <> olddte Then
                            txtEffDate.Text = olddte.ToString("MM/dd/yyyy")
                            MessageBox("Effective Date cannot be less than today’s Date.  Contact Underwriting for Assistance.")

                        End If

                    Else
                        txtEffDate.Text = DateTime.Now.ToString("MM/dd/yyyy")
                        MessageBox("Effective Date cannot be less than today’s Date.  Contact Underwriting for Assistance.")
                    End If

                End If

            End If

        End If
    End Sub
    Public ReadOnly Property lien1() As String
        Get
            Return Me.liendd.SelectedValue
        End Get
    End Property


    Private Sub btnloss_Click(sender As Object, e As System.EventArgs) Handles btnloss.Click
        If lblquoteNumber.Text <> "" Then


            Dim intRowsAff As Integer
            Dim Connection As String = System.Configuration.ConfigurationManager.ConnectionStrings("ColonialMHConnectionString").ConnectionString
            Dim dbConnection As System.Data.IDbConnection = New System.Data.SqlClient.SqlConnection(Connection)
            Dim cmd As New SqlCommand("sp_deletelosses", dbConnection)
            cmd.CommandType = CommandType.StoredProcedure
            cmd.Parameters.Add("@quoteID", SqlDbType.VarChar, 8000).Value = lblquoteNumber.Text

            Try
                cmd.Connection.Open()
                intRowsAff = cmd.ExecuteNonQuery()
            Catch ex As Exception
                errortrap("Deleteing losses", "Quote Number: " & lblquoteNumber.Text, ex.Message)
            End Try
        End If
    End Sub
    Private Sub setAutoFill()
        Try
            Dim AdminUser As Boolean = mySession.CurrentUser.AdminUser
            If AdminUser = False Then ' Hide lookup and auto fill agent information

                Dim user As String = mySession.CurrentUser.AccountNumber.ToString
                Dim cn As New SqlClient.SqlConnection(System.Configuration.ConfigurationManager.ConnectionStrings("ColonialWebConnectionString").ConnectionString)

                Dim cmd As New SqlClient.SqlCommand
                cmd.Connection = cn
                cmd.CommandText = "SELECT * FROM vwAgents WHERE AgentCode = " & user 'ddlSub_main.SelectedValue
                If cmd.Connection.State = ConnectionState.Closed Then cmd.Connection.Open()

                Dim rs As SqlClient.SqlDataReader = cmd.ExecuteReader
                Do While rs.Read
                    txtConEmail.Text = rs("AgentEmail")
                    txtAgConName.Text = rs("AgentName")
                    lblAgency.Text = rs("AgencyName")
                    lblAgency.Text.Replace("  ", "")
                    txtSubNumber.Text = rs("AgencyCode").ToString()
                Loop
                rs.Close()

                Me.ddlSub_main.Visible = False
                txtsubNumber_results.Visible = False
                txtSubNumber.Enabled = False
                SubUpdatepanel1.Update()
                'Dim ds As System.Data.DataSet
                'ds = Common.runQueryDS("SELECT * FROM Agents ag LEFT JOIN Agency agc ON ag.s2sub = agc.sssub WHERE s2sub + s2id = '" & user & "'")
                'If ds.Tables(0).Rows.Count > 0 Then
                '    'txtAgentName.Text = ds.Tables(0).Rows(0).Item("s2cnt").ToString
                '    txtAgConName.Text = ds.Tables(0).Rows(0).Item("s2cnt").ToString
                '    txtConEmail.Text = ds.Tables(0).Rows(0).Item("s2email").ToString
                '    'lblAgencyName.Text = ds.Tables(0).Rows(0).Item("ssnam").ToString
                '    'pnlSubNumber.Visible = False
                'End If

            Else 'show sub lookup

            End If

        Catch ex As Exception
            'Add exception code here
            errortrap("Autofill Agent Info", mySession.CurrentUser.AccountNumber.ToString, ex.Message)
        End Try
    End Sub

    Protected Sub SCWHYes_Click(sender As Object, e As EventArgs) Handles SCWHYes.Click

        aegisterritorylbl.Text = "4"
        ASPxPopupControl5.Enabled = False
        ASPxPopupControl5.ShowOnPageLoad = False
    End Sub

    Protected Sub SCWNo_Click(sender As Object, e As EventArgs) Handles SCWNo.Click
        aegisterritorylbl.Text = "1"
        ASPxPopupControl5.Enabled = False
        ASPxPopupControl5.ShowOnPageLoad = False
    End Sub
End Class