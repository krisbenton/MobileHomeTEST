Imports System.Data.SqlClient
Public Class Lloyds
    Inherits System.Web.UI.UserControl
    Public mhvalue As String
    Public mhstate As String
    Public mhtype As String
    Public mhmfg As String
    Public mhyear As String
    Public mhcounty As String
    Public mhquoteID As String
    Public LloydsState As String
    Public LloydsQuote As String



    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
      
        'If dd_pl_AR2.SelectedValue() > "$0" Then
        '    dd_mp_AR2.SelectedValue = "$500"
        'ElseIf dd_pl_AR2.SelectedValue() = "$0" Then
        '    dd_mp_AR2.SelectedValue = "$0"
        'Else
        '    dd_mp_AR2.SelectedValue = "$0"
        'End If

        If dd_pl_AR3.SelectedValue() > "" Then
            dd_mp_AR3.SelectedValue = "$500"
        ElseIf dd_pl_AR3.SelectedValue() = "" Then
            dd_mp_AR3.SelectedValue = ""
        Else
            dd_mp_AR3.SelectedValue = ""
        End If
        If lblaiges_ShowOptions2_hidden.Value = "- Show Options" Then
            aiges_mh_prog2_Options.Style.Add("display", "block")
            Table1.Style.Add("display", "block")
            lblaiges_ShowOptions2.InnerText = "- Show Options"
        Else
            aiges_mh_prog2_Options.Style.Add("display", "none")
            Table1.Style.Add("display", "none")
            lblaiges_ShowOptions2.InnerText = "+ Show Options"
        End If

        'on every postback
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

        'Special MH

        If lblSMHShowOptions4_hidden.Value = "- Show Options" Then
            SC08_mh_prog_Options.Style.Add("display", "block")
            SC08OptionRow.Style.Add("display", "block")
            lblSMHShowOptions4.InnerText = "- Show Options"
        Else
            SC08_mh_prog_Options.Style.Add("display", "none")
            SC08OptionRow.Style.Add("display", "none")
            lblSMHShowOptions4.InnerText = "+ Show Options"
        End If
        'Aegis 
        'standard
        If lblaiges_ShowOptions2_hidden.Value = "- Show Options" Then
            aiges_mh_prog2_Options.Style.Add("display", "block")
            Table1.Style.Add("display", "block")
            lblaiges_ShowOptions2.InnerText = "- Show Options"
        Else
            aiges_mh_prog2_Options.Style.Add("display", "none")
            Table1.Style.Add("display", "none")
            lblaiges_ShowOptions2.InnerText = "+ Show Options"
        End If
        'rental
        If lblaiges_ShowOptions3_hidden.Value = "- Show Options" Then
            aiges_mh_prog3_Options1.Style.Add("display", "block")
            Table2.Style.Add("display", "block")
            lblaiges_ShowOptions3.InnerText = "- Show Options"
        Else
            aiges_mh_prog3_Options1.Style.Add("display", "none")
            Table2.Style.Add("display", "none")
            lblaiges_ShowOptions3.InnerText = "+ Show Options"
        End If
        'vintage
        If lblAegisvint_ShowOptionssc1_hidden.Value = "- Show Options" Then
            Aegisvint_mh_progsc1_Options.Style.Add("display", "block")
            Aegisvint_sc1_table.Style.Add("display", "block")
            lblAegisvint_ShowOptionssc1.InnerText = "- Show Options"
        Else
            Aegisvint_mh_progsc1_Options.Style.Add("display", "none")
            Aegisvint_sc1_table.Style.Add("display", "none")
            lblAegisvint_ShowOptionssc1.InnerText = "+ Show Options"
        End If


        'AMSLIC 
        'standard
        If lblamslicShowOptions2_hidden.Value = "- Show Options" Then
            amslic_mh_prog_Options.Style.Add("display", "block")
            amslicOptionRow.Style.Add("display", "block")
            lblamslicShowOptions.InnerText = "- Show Options"
        Else
            amslic_mh_prog_Options.Style.Add("display", "none")
            amslicOptionRow.Style.Add("display", "none")
            lblamslicShowOptions.InnerText = "+ Show Options"
        End If
        'rental
        If lblamslicShowOptionsRent_hidden.Value = "- Show Options" Then
            amslic_mh_progRent_Options.Style.Add("display", "block")
            amslicOptionRowRent.Style.Add("display", "block")
            lblamslicShowOptionsRent.InnerText = "- Show Options"
        Else
            amslic_mh_progRent_Options.Style.Add("display", "none")
            amslicOptionRowRent.Style.Add("display", "none")
            lblamslicShowOptionsRent.InnerText = "+ Show Options"
        End If
        'WMJ
        If lblwmj_ShowOptions2_hidden.Value = "- Show Options" Then
            wmj_mh_prog2_Options.Style.Add("display", "block")
            Table3.Style.Add("display", "block")
            lblwmj_ShowOptions2.InnerText = "- Show Options"
        Else
            wmj_mh_prog2_Options.Style.Add("display", "none")
            Table3.Style.Add("display", "none")
            lblwmj_ShowOptions2.InnerText = "+ Show Options"
        End If
        'wmj nc



        If lblwmj_ShowOptionsnc1_hidden.Value = "- Show Options" Then
            wmj_mh_prognc1_Options.Style.Add("display", "block")
            WMJ_nc1_table.Style.Add("display", "block")
            lblwmj_ShowOptions2.InnerText = "- Show Options"
        Else
            wmj_mh_prognc1_Options.Style.Add("display", "none")
            WMJ_nc1_table.Style.Add("display", "none")
            lblwmj_ShowOptionsnc1.InnerText = "+ Show Options"
        End If
        If lblwmj_ShowOptionsnc2_hidden.Value = "- Show Options" Then
            wmj_mh_prognc2_Options.Style.Add("display", "block")
            WMJ_nc2_table.Style.Add("display", "block")
            lblwmj_ShowOptions2.InnerText = "- Show Options"
        Else
            wmj_mh_prognc2_Options.Style.Add("display", "none")
            WMJ_nc2_table.Style.Add("display", "none")
            lblwmj_ShowOptionsnc2.InnerText = "+ Show Options"
        End If
        If lblwmj_ShowOptionsnc3_hidden.Value = "- Show Options" Then
            wmj_mh_prognc3_Options.Style.Add("display", "block")
            WMJ_nc3_table.Style.Add("display", "block")
            lblwmj_ShowOptions2.InnerText = "- Show Options"
        Else
            wmj_mh_prognc3_Options.Style.Add("display", "none")
            WMJ_nc3_table.Style.Add("display", "none")
            lblwmj_ShowOptionsnc3.InnerText = "+ Show Options"
        End If



        If Not IsPostBack Then
            lblchange.Visible = False
            'standcramtlbl.Text = 0
            'standperclbl.Text = 0
            ' dd_pl_AR1.SelectedValue = "$25,000"
            dd_aop_aiges1.SelectedValue = "$500"
            dd_mp_aiges1.SelectedValue = "$500"
            dd_aop_AR1.Attributes.Add("onChange", "return AR_UpdateOptions();")

            dd_hurded_AR1.Attributes.Add("onChange", "return AR_UpdateOptions();")
            dd_pl_AR1.Attributes.Add("onChange", "return AR_UpdateOptions();")
            dd_mp_AR1.Attributes.Add("onChange", "return AR_UpdateOptions();")
            txt_unattstr_AR1.Attributes.Add("onChange", "return AR_UpdateOptions();")
            txt_pp_AR1.Attributes.Add("onChange", "return AR_UpdateOptions();")
            dd_mhr_AR1.Attributes.Add("onChange", "return AR_UpdateOptions();")
            ' dd_rep_AR1.Attributes.Add("onChange", "return AR_UpdateOptions();")
            dd_mhr_AR1.Attributes.Add("onChange", "return UpdateFR();")
            'txt_addlimrad_AR1.Attributes.Add("onChange", "return AR_UpdateOptions();")
            'txt_addlimfir_AR1.Attributes.Add("onChange", "return AR_UpdateOptions();")
            dd_sip_AR1.Attributes.Add("onChange", "return UpdateFR();")
            dd_PackagePerProp_aiges.Attributes.Add("onChange", "return UpdatePP();")

            'dd_ndp_AR1.Attributes.Add("onChange", "return AR_UpdateOptions();")
            'dd_addresOpt_ar1.Attributes.Add("onChange", "return AR_UpdateOptions();")
            'dd_addresliab_ar1.Attributes.Add("onChange", "return AR_UpdateOptions();")
            'dd_addresMP_ar1.Attributes.Add("onChange", "return AR_UpdateOptions();")

            ' dd_pl_08.SelectedValue = "$25,000"
            'dd_aop_08.SelectedValue = "$1000"
            'Aegis.  Hide everthing till later:
            'aiges_mh_prog2.Visible = False
            'aiges_mh_prog2_Options.Visible = False
            'aiges_mh_prog3.Visible = False
            'aiges_mh_prog3_Options1.Visible = False


            'dd_waterCraftliab_AR1.Attributes.Add("onChange", "return AR_UpdateOptions();")
            'dd_waterCraftMedpay_AR1.Attributes.Add("onChange", "return AR_UpdateOptions();")

            'dd_waterCraft_AR1.Attributes.Add("onChange", "return AR_UpdateOptions();")

            'dd_PackagePerProp_AR1.Attributes.Add("onChange", "return AR_UpdateOptions();")


            'Default Attributes Package
            dd_aop_AR2.Attributes.Add("onChange", "return AR_UpdateOptions();")
            dd_hurded_AR2.Attributes.Add("onChange", "return AR_UpdateOptions();")
            dd_pl_AR2.Attributes.Add("onChange", "return AR_UpdateOptions();")
            dd_mp_AR2.Attributes.Add("onChange", "return AR_UpdateOptions();")
            txt_unattstr_AR2.Attributes.Add("onChange", "return AR_UpdateOptions();")
            txt_pp_AR2.Attributes.Add("onChange", "return AR_UpdateOptions();")
            dd_mhr_AR2.Attributes.Add("onChange", "return AR_UpdateOptions();")
            'dd_rep_AR2.Attributes.Add("onChange", "return AR_UpdateOptions();")
            'txt_addlimrad_AR2.Attributes.Add("onChange", "return AR_UpdateOptions();")
            'txt_addlimfir_AR2.Attributes.Add("onChange", "return AR_UpdateOptions();")
            dd_sip_AR2.Attributes.Add("onChange", "return AR_UpdateOptions();")
            'dd_ndp_AR2.Attributes.Add("onChange", "return AR_UpdateOptions();")
            'dd_addresOpt_ar2.Attributes.Add("onChange", "return AR_UpdateOptions();")
            'dd_addresliab_ar2.Attributes.Add("onChange", "return AR_UpdateOptions();")
            'dd_addresMP_ar2.Attributes.Add("onChange", "return AR_UpdateOptions();")
            'dd_waterCraft_ar2.Attributes.Add("onChange", "return AR_UpdateOptions();")
            'dd_waterCraftliab_ar2.Attributes.Add("onChange", "return AR_UpdateOptions();")
            'dd_waterCraftMedpay_ar2.Attributes.Add("onChange", "return AR_UpdateOptions();")
            'dd_PackagePerProp_ar2.Attributes.Add("onChange", "return AR_UpdateOptions();")

            'Default Rental Attributes Package
            dd_aop_AR3.Attributes.Add("onChange", "return AR_UpdateOptions();")
            dd_hurded_AR3.Attributes.Add("onChange", "return AR_UpdateOptions();")
            dd_pl_AR3.Attributes.Add("onChange", "return AR_UpdateOptions();")
            dd_mp_AR3.Attributes.Add("onChange", "return AR_UpdateOptions();")
            txt_unattstr_AR3.Attributes.Add("onChange", "return AR_UpdateOptions();")
            txt_pp_AR3.Attributes.Add("onChange", "return AR_UpdateOptions();")
            'txt_addlimrad_AR3.Attributes.Add("onChange", "return AR_UpdateOptions();")
            'txt_addlimfir_AR3.Attributes.Add("onChange", "return AR_UpdateOptions();")
            'dd_sip_AR3.Attributes.Add("onChange", "return AR_UpdateOptions();")
            'dd_ndp_AR3.Attributes.Add("onChange", "return AR_UpdateOptions();")

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

            'Special MH

            If lblSMHShowOptions4_hidden.Value = "- Show Options" Then
                SC08_mh_prog_Options.Style.Add("display", "block")
                SC08OptionRow.Style.Add("display", "block")
                lblSMHShowOptions4.InnerText = "- Show Options"
            Else
                SC08_mh_prog_Options.Style.Add("display", "none")
                SC08OptionRow.Style.Add("display", "none")
                lblSMHShowOptions4.InnerText = "+ Show Options"
            End If
            'Aegis 
            'standard
            If lblaiges_ShowOptions2_hidden.Value = "- Show Options" Then
                aiges_mh_prog2_Options.Style.Add("display", "block")
                Table1.Style.Add("display", "block")
                lblaiges_ShowOptions2.InnerText = "- Show Options"
            Else
                aiges_mh_prog2_Options.Style.Add("display", "none")
                Table1.Style.Add("display", "none")
                lblaiges_ShowOptions2.InnerText = "+ Show Options"
            End If
            'rental
            If lblaiges_ShowOptions3_hidden.Value = "- Show Options" Then
                aiges_mh_prog3_Options1.Style.Add("display", "block")
                Table2.Style.Add("display", "block")
                lblaiges_ShowOptions3.InnerText = "- Show Options"
            Else
                aiges_mh_prog3_Options1.Style.Add("display", "none")
                Table2.Style.Add("display", "none")
                lblaiges_ShowOptions3.InnerText = "+ Show Options"
            End If
            'dd_sip_AR1.Enabled = True
            'dd_mhr_AR1.Enabled = True
            PPError.Visible = False

        End If

        tstormRent.Visible = True
        amslicmhcontentrent.Visible = False
        amslicmhreplacerent.Visible = False


        'Added for SC Fiancing
        DownPaymentPercentRB.Attributes.Add("onChange", "return FinanceOptionChange();")
        FinanceLengthRB.Attributes.Add("onChange", "return FinanceOptionChange();")

    End Sub
    Public Sub loadpremdata(ByVal value As String, ByVal state As String, ByVal type As String, ByVal mfg As String, ByVal year As String, ByVal county As String, ByVal Quoteid As String, ByVal Usage As String, ByVal dist As String, ByVal prot As String, ByVal lien As String, ByVal subheat As String, ByVal dob As String, ByVal skirt As String, ByVal subnum As String, ByVal lapse As String, ByVal city As String, ByVal effdate As String, ByVal aegisterr As String)
        MHValuelbl.Text = value.Replace(",", "")
        mhstatelbl.Text = state
        mhtypelbl.Text = type
        mhmfglbl.Text = RTrim(mfg)
        mhyearlbl.Text = year
        mhcountylbl.Text = county
        quoteIDlbl.Text = Quoteid
        mhusagelbl.Text = Usage
        mhdistlbl.Text = dist
        protection.Text = prot
        lienlbl.Text = lien
        supheatlbl.Text = subheat
        lbldob.Text = dob
        lblskirt.Text = skirt
        mhvalue = value
        mhstate = state
        mhtype = type
        mhmfg = mfg
        mhyear = year
        mhcounty = county
        lblSub.Text = subnum
        lapselbl.Text = lapse
        citylbl.Text = city
        lbleffdate.Text = effdate
        aegisterritorylbl.Text = aegisterr


        'If state = "DE" Then
        '    SC_MH_08.Visible = False
        '    SC08_mh_prog_Options.Visible = False
        '    SC08OptionRow.Visible = False
        '    aiges_mh_prog2.Visible = False
        '    aiges_mh_prog2_Options.Visible = False
        '    aiges_mh_prog3.Visible = False
        '    aiges_mh_prog3_Options1.Visible = False
        '    ar_mh_prog1.Visible = False
        '    ar_mh_prog1_Options.Visible = False
        '    tstorm1.Visible = False
        '    tstorm2.Visible = False
        '    tstorm3.Visible = False
        '    ar_mh_prog1.Visible = False
        '    ar_mh_prog1_Options.Visible = False
        '    tstorm1.Visible = False
        '    tstorm2.Visible = False
        '    tstorm3.Visible = False
        '    If mhusagelbl.Text = "Rental" Then
        '        ar_mh_prog2.Visible = False
        '        ar_mh_prog2_Options.Visible = False
        '        ar_mh_prog3.Visible = True
        '        ar_mh_prog3_Options.Visible = True

        '    End If
        '    If mhusagelbl.Text = "Owner" Or mhusagelbl.Text = "Seasonal" Then
        '        ar_mh_prog2.Visible = True
        '        ar_mh_prog2_Options.Visible = True
        '        ar_mh_prog3.Visible = False
        '        ar_mh_prog3_Options.Visible = False

        '    End If

        'Else
        '    tstorm1.Visible = True
        '    tstorm2.Visible = True
        '    tstorm3.Visible = True
        '    If mhusagelbl.Text = "Rental" Then
        '        ar_mh_prog1.Visible = False
        '        ar_mh_prog1_Options.Visible = False
        '        ar_mh_prog2.Visible = False
        '        ar_mh_prog2_Options.Visible = False
        '        ar_mh_prog3.Visible = True
        '        ar_mh_prog3_Options.Visible = True

        '    End If
        '    If mhusagelbl.Text = "Owner" Or mhusagelbl.Text = "Seasonal" Then
        '        ar_mh_prog1.Visible = True
        '        ar_mh_prog1_Options.Visible = True

        '        ar_mh_prog2.Visible = True
        '        ar_mh_prog2_Options.Visible = True
        '        ar_mh_prog3.Visible = False
        '        ar_mh_prog3_Options.Visible = False

        '    End If
        '    If state = "SC" Then
        '        ar_mh_prog2.Visible = False
        '        ar_mh_prog2_Options.Visible = True
        '        If CInt(mhvalue) > 129999 And CInt(mhvalue) < 150000 Then

        '            If mhusagelbl.Text = "Owner" Or mhusagelbl.Text = "Seasonal" Then
        '                If mhtype = "Doublewide" Or mhtype = "Modular" Then
        '                    'if HO8 then make visible and call load data or calculation
        '                    SC_MH_08.Visible = True
        '                    SC08_mh_prog_Options.Visible = True
        '                    SC08OptionRow.Visible = True
        '                    calcSH08()
        '                Else
        '                    SC_MH_08.Visible = False
        '                    SC08_mh_prog_Options.Visible = False
        '                    SC08OptionRow.Visible = False
        '                End If

        '            Else
        '                SC_MH_08.Visible = False
        '                SC08_mh_prog_Options.Visible = False
        '                SC08OptionRow.Visible = False
        '            End If
        '        ElseIf CInt(mhvalue) > 115000 Then



        '            ar_mh_prog1.Visible = False
        '            ar_mh_prog1_Options.Visible = False

        '            ar_mh_prog2.Visible = False
        '            ar_mh_prog2_Options.Visible = False

        '            txt_unattstr_AR1.Text = "500"
        '            txt_pp_AR1.Text = CInt(mhvalue * 0.3)
        '            dd_pl_AR1.SelectedValue = "$25,000"


        '            'If Quoteid <> "" Then
        '            '    LoadSH08(Quoteid, value, state, type, mfg, year, county, Usage, dist)
        '            'Else
        '        ElseIf CInt(mhvalue) < 125001 Then

        '            'Aegis
        '            If mhcountylbl.Text = "HAMPTON" Then
        '                aiges_mh_prog2.Visible = False
        '                aiges_mh_prog2_Options.Visible = False
        '                aiges_mh_prog3.Visible = False
        '                aiges_mh_prog3_Options1.Visible = False
        '            Else
        '                loadAegisPP()
        '                calcAegis()
        '            End If

        '            'End If
        '        End If
        '    End If
        '    End If
        'If mhusagelbl.Text = "Rental" Then
        '    ar_mh_prog2.Visible = False
        '    ar_mh_prog2_Options.Visible = False
        '    ar_mh_prog3.Visible = True
        '    ar_mh_prog3_Options.Visible = True

        'End If
        'If mhusagelbl.Text = "Owner" Or mhusagelbl.Text = "Seasonal" Then
        '    ar_mh_prog2.Visible = True
        '    ar_mh_prog2_Options.Visible = True
        '    ar_mh_prog3.Visible = False
        '    ar_mh_prog3_Options.Visible = False

        'End If
        mhvaluechanged.Text = "True"
        If Quoteid <> "" Then

            LoadLloydsPremiums(Quoteid, value, state, type, mfg, year, county, Usage, dist, prot, lien, subheat, dob, subnum, lapse, city, effdate, aegisterr)
        Else
            dd_aop_aiges1.SelectedValue = "$500"
            ProgramChoice()
            If lbl_Lloyds_SMH.Text = "True" Then
                dd_pl_08.SelectedValue = "$25,000"
                SC_MH_08.Visible = True
                SC08_mh_prog_Options.Visible = True
                SC08OptionRow.Visible = True
                calcSH08()
            Else
                SC_MH_08.Visible = False
                SC08_mh_prog_Options.Visible = False
                SC08OptionRow.Visible = False

            End If
            If CInt(MHValuelbl.Text) <= 25000 And lbl_Aegis_Stand.Text = "True" Then
                If mhusagelbl.Text = "Rental" Then
                    dd_pl_Aegisvintsc1.Items.Clear()
                    dd_pl_Aegisvintsc1.Items.Add("$0")
                    dd_pl_Aegisvintsc1.Items.Add("$25,000")
                    dd_mp_Aegisvintsc1.Items.Clear()
                    dd_mp_Aegisvintsc1.Items.Add("$0")
                    dd_mp_Aegisvintsc1.Items.Add("$500")
                    Label163.Text = "Premises Liability:   "
                Else
                    Label163.Text = "Personal Liability:  "
                    dd_pl_Aegisvintsc1.Items.Clear()

                    dd_pl_Aegisvintsc1.Items.Add("$25,000")
                    dd_mp_Aegisvintsc1.Items.Clear()

                    dd_mp_Aegisvintsc1.Items.Add("$500")
                End If
                AegisCalcVint()
                Aegisvint_mh_progsc1.Visible = True
                Aegisvint_mh_progsc1_Options.Visible = True
            Else
                Aegisvint_mh_progsc1.Visible = False
                Aegisvint_mh_progsc1_Options.Visible = False
            End If

            If lbl_Aegis_Rent.Text = "True" Or lbl_Aegis_Stand.Text = "True" Then

                aiges_mh_prog2.Visible = False
                aiges_mh_prog2_Options.Visible = False
                aiges_mh_prog3.Visible = False
                aiges_mh_prog3_Options1.Visible = False
                loadAegisPP()
                'LoadAegisData()
                If CDate(effdate) >= CDate("04/15/2014") Then
                    aegis_addliving.Visible = True
                    aegis_earthquake.Visible = False
                    aegis_icelimit.Visible = True
                    aegis_icedelete.Visible = True
                    ' aegis_theft.Visible = True
                    aegis_water.Visible = True
                    aegis_waterexlusion.Visible = True
                    aegis_golf.Visible = True
                    aegis_animal.Visible = True
                    aegis_pool.Visible = True
                Else
                    aegis_addliving.Visible = False
                    aegis_earthquake.Visible = False
                    aegis_icelimit.Visible = False
                    aegis_icedelete.Visible = False
                    ' aegis_theft.Visible = False
                    aegis_water.Visible = False
                    aegis_waterexlusion.Visible = False
                    aegis_golf.Visible = False
                    aegis_animal.Visible = False
                    aegis_pool.Visible = False
                End If
                calcAegis()
            Else
                aiges_mh_prog2.Visible = False
                aiges_mh_prog2_Options.Visible = False
                aiges_mh_prog3.Visible = False
                aiges_mh_prog3_Options1.Visible = False
            End If
            If lbl_Lloyds_Pack.Text = "True" Or lbl_Lloyds_Rent.Text = "True" Or lbl_Lloyds_Stand.Text = "True" Then
                'put in some defaults
                If mhstatelbl.Text <> "DE" Then

                    If txt_unattstr_AR2.Text = "$0.00" Or txt_unattstr_AR2.Text = "$0" Then
                        txt_unattstr_AR2.Text = "$500"

                    End If
                    If txt_pp_AR2.Text = "$0.00" Or txt_pp_AR2.Text = "$0" Then
                        txt_pp_AR2.Text = CInt(CInt(MHValuelbl.Text) * 0.3)

                    End If
                    If dd_pl_AR2.SelectedValue = "$0" Then
                        dd_pl_AR2.SelectedValue = "$25,000"

                    End If
                    dd_mp_AR2.SelectedValue = "$500"
                    If mhstatelbl.Text = "NC" Then
                        If txt_unattstr_AR2.Text = "$0.00" Or txt_unattstr_AR2.Text = "$0" Then
                            txt_unattstr_AR2.Text = "$500"

                        End If
                        If txt_pp_AR2.Text = "$0.00" Or txt_pp_AR2.Text = "$0" Then
                            txt_pp_AR2.Text = CInt(CInt(MHValuelbl.Text) * 0.03)

                        End If
                        If dd_pl_AR2.SelectedValue = "$0" Then
                            dd_pl_AR2.SelectedValue = "$25,000"

                        End If
                        dd_mp_AR2.SelectedValue = "$500"
                    End If

                End If
                Calc()
                If lbl_Lloyds_Pack.Text = "True" Then
                    ar_mh_prog1.Visible = True
                    ar_mh_prog1_Options.Visible = True

                End If
                If lbl_Lloyds_Stand.Text = "True" Then
                    ar_mh_prog2.Visible = True
                    ar_mh_prog2_Options.Visible = True

                End If
                If lbl_Lloyds_Rent.Text = "True" Then
                    ar_mh_prog3.Visible = True
                    ar_mh_prog3_Options.Visible = True
                Else
                    ar_mh_prog3.Visible = False
                    ar_mh_prog3_Options.Visible = False
                End If
            End If

            If lbl_Amslic_Rent.Text = "True" Or lbl_Amslic_Stand.Text = "True" Then

                amslic_mh_progRent.Visible = True
                amslicOptionRowRent.Visible = True
                amslic_mh_prog.Visible = True
                amslicOptionRow.Visible = True
                ' Load_Amslic()

                Amslic_Calc()
            Else
                amslic_mh_progRent.Visible = False
                amslicOptionRowRent.Visible = False
                amslic_mh_prog.Visible = False
                amslicOptionRow.Visible = False

            End If
            If lbl_WMJ_Pack.Text = "True" Then


                loadWMJPP()
                WMJPPtotals()
                calcWMJ()
                wmj_mh_prog2.Visible = True
                wmj_mh_prog2_Options.Visible = True
            Else
                wmj_mh_prog2.Visible = False
                wmj_mh_prog2_Options.Visible = False
            End If

            If lbl_WMJ_PackNC.Text = "True" Then
                loadWMJPPnc1()
                WMJPPtotalsnc1()
                'LoadWMJData()
                ' calcWMJNC()
                'wmj_mh_prognc1.Visible = True
                'wmj_mh_prognc1_Options.Visible = True

                loadWMJPPnc2()
                WMJPPtotalsnc2()
                'LoadWMJData()
                ' calcWMJNC()
                'wmj_mh_prognc2.Visible = True
                'wmj_mh_prognc2_Options.Visible = True

                loadWMJPPnc3()
                WMJPPtotalsnc3()
                'LoadWMJData()
                calcWMJNC()
                'wmj_mh_prognc3.Visible = True
                'wmj_mh_prognc3_Options.Visible = True
            Else
                wmj_mh_prognc1.Visible = False
                wmj_mh_prognc1_Options.Visible = False
                wmj_mh_prognc2.Visible = False
                wmj_mh_prognc2_Options.Visible = False
                wmj_mh_prognc3.Visible = False
                wmj_mh_prognc3_Options.Visible = False

            End If

        End If

        'If lbl_WMJ_Pack.Text = "True" Then


        '    loadWMJPP()
        '    WMJPPtotals()
        '    calcWMJ()
        '    wmj_mh_prog2.Visible = True
        '    wmj_mh_prog2_Options.Visible = True
        'Else
        '    wmj_mh_prog2.Visible = False
        '    wmj_mh_prog2_Options.Visible = False
        'End If


    End Sub
    Public Sub printbtn_Click(ByVal sender As Object, ByVal e As EventArgs)
        'If Request.QueryString("quoteID") <> "" Or Session("beenSaved") = "True" Then
        '    ' updateQuote(Request.QueryString("quoteID"))
        'Else 'New Quote
        '    ' save()
        'End If
        'Dim pack As String
        'pack = rateTypelbl.Text
        Try


            If quoteIDlbl.Text <> "" Then
                Me.Page.GetType.InvokeMember("updateQuote", System.Reflection.BindingFlags.InvokeMethod, Nothing, Me.Page, New Object() {quoteIDlbl.Text})
            Else
                Me.Page.GetType.InvokeMember("save", System.Reflection.BindingFlags.InvokeMethod, Nothing, Me.Page, New Object() {""})

            End If
            Me.Page.GetType.InvokeMember("LloydPrintQuote", System.Reflection.BindingFlags.InvokeMethod, Nothing, Me.Page, New Object() {quoteIDlbl.Text})
        Catch ex As Exception
            errortrap("Save Before Lloyds Print " & quoteIDlbl.Text, "printbtn_Click", ex.Message)
        End Try
        'Common.AjaxOpenWindow(Me.Page, "quotePrint.aspx?quoteID=" & lblquoteNumber.Text & "", Nothing)
    End Sub
    Protected Sub btnBeforeApp_Click(sender As Object, e As EventArgs) Handles btnBeforeApp.Click
        Try


            If quoteIDlbl.Text <> "" Then
                Me.Page.GetType.InvokeMember("updateQuote", System.Reflection.BindingFlags.InvokeMethod, Nothing, Me.Page, New Object() {quoteIDlbl.Text})
            Else
                Me.Page.GetType.InvokeMember("save", System.Reflection.BindingFlags.InvokeMethod, Nothing, Me.Page, New Object() {})

            End If

            'Server.Transfer("/Application/ARApplication.aspx?quoteID=" & quoteIDlbl.Text & "", True)
            'Response.RedirectPermanent("/Application/ARApplication.aspx?quoteID=" & quoteID & "")
        Catch ex As Exception
            '    errortrap("Redirecting", "Save and Open Application", ex.Message)
            errortrap("Redirection To Application", "btnBeforeApp  Saving Data", ex.Message)
        End Try
        Dim quoteID As String
        'Dim lbl As New Label()
        'lbl.Text = "<script language='javascript'>ARPremTotalRedirect();" & "<" & "/script>"
        'Page.Controls.Add(lbl)
        quoteID = quoteIDlbl.Text

        ' HttpContext.Current.Response.Redirect("/Application/ARApplication.aspx?quoteID=" & quoteID & "")
        'Response.Redirect("/Application/ARApplication.aspx?quoteID=" & quoteID & "", False)
        Dim url As String
        If Left(rateTypelbl.Text, 13) = "Aegis Vintage" Then
            url = "~/Application/VintageAigesApplication.aspx?quoteID=" & quoteID & ""
            Me.Page.GetType.InvokeMember("AegisVintageRedirect", System.Reflection.BindingFlags.InvokeMethod, Nothing, Me.Page, New Object() {quoteID})

        ElseIf Left(rateTypelbl.Text, 5) = "Aegis" Then
            url = "~/Application/AigesApplication.aspx?quoteID=" & quoteID & ""
            Me.Page.GetType.InvokeMember("AegisRedirect", System.Reflection.BindingFlags.InvokeMethod, Nothing, Me.Page, New Object() {quoteID})
        ElseIf Left(rateTypelbl.Text, 5) = "AMSLI" Then
            url = "~/Application/AMSLICApllication.aspx?quoteID=" & quoteID & ""
            Me.Page.GetType.InvokeMember("AMSLICRedirect", System.Reflection.BindingFlags.InvokeMethod, Nothing, Me.Page, New Object() {quoteID})
        ElseIf Left(rateTypelbl.Text, 3) = "WMJ" Then
            url = "~/Application/WMJApplication.aspx?quoteID=" & quoteID & ""
            Me.Page.GetType.InvokeMember("WMJRedirect", System.Reflection.BindingFlags.InvokeMethod, Nothing, Me.Page, New Object() {quoteID})
        Else

            url = "~/Application/LloydsApplication.aspx?quoteID=" & quoteID & ""
            Me.Page.GetType.InvokeMember("LloydRedirect", System.Reflection.BindingFlags.InvokeMethod, Nothing, Me.Page, New Object() {quoteID})
        End If
        'Dim url As String = "~/Application/LloydsApplication.aspx?quoteID=" & quoteID & ""
        'Dim redirectURL As String = Page.ResolveClientUrl(url)
        'Dim scrpt As String = "window.location = '" & redirectURL & "';"
        'ScriptManager.RegisterStartupScript(Me.Parent, GetType(Page), "RedirectTo", scrpt, True)

        ' Common.AjaxOpenWindow(Me.Page, "/Application/ARApplication.aspx?quoteID=" & quoteID & "", Nothing)
    End Sub
    Public Sub LoadLloydsPremiums(ByVal quoteID As String, ByVal value As String, ByVal state As String, ByVal type As String, ByVal mfg As String, ByVal year As String, ByVal county As String, ByVal Usage As String, ByVal dist As String, ByVal prot As String, ByVal lien As String, ByVal subheat As String, ByVal dob As String, ByVal subnum As String, ByVal lapse As String, ByVal city As String, ByVal effDate As String, ByVal aegisterr As String)
        LloydsQuote = quoteID
        LloydsState = state
        lblSub.Text = subnum
        lapselbl.Text = lapse
        citylbl.Text = city
        lbleffdate.Text = effDate
        aegisterritorylbl.Text = aegisterr
        Dim dsFin As System.Data.DataSet
        'Load Financing
        Try
            dsFin = Common.runQueryDS("SELECT * FROM tblColonialFinancing WHERE quoteID = '" & quoteID & "'")

            If dsFin.Tables(0).Rows.Count > 0 Then
                Dim length As String = dsFin.Tables(0).Rows(0).Item("length").ToString
                If length = 3 Then
                    FinanceLengthRB.SelectedValue = "3 Months"
                ElseIf length = 6 Then
                    FinanceLengthRB.SelectedValue = "6 Months"
                ElseIf length = 8 Then
                    FinanceLengthRB.SelectedValue = "8 Months"
                End If

                Dim dp As String = dsFin.Tables(0).Rows(0).Item("downPayment").ToString
                If dp = 25 Then
                    DownPaymentPercentRB.SelectedValue = "25% Down"
                ElseIf dp = 40 Then
                    DownPaymentPercentRB.SelectedValue = "40% Down"
                ElseIf dp = 50 Then
                    DownPaymentPercentRB.SelectedValue = "50% Down"
                End If

                'Load General Financing Options 
                If length = 3 Then
                    PremiumFinanceLen.SelectedItem.Value = "3 Months"
                ElseIf length = 6 Then
                    PremiumFinanceLen.SelectedItem.Value = "6 Months"
                ElseIf length = 8 Then
                    PremiumFinanceLen.SelectedItem.Value = "8 Months"
                End If
                If dp = 25 Then
                    PremiumFinanceDP.SelectedItem.Value = "25% Down"
                ElseIf dp = 40 Then
                    PremiumFinanceDP.SelectedItem.Value = "40% Down"
                ElseIf dp = 50 Then
                    PremiumFinanceDP.SelectedItem.Value = "50% Down"
                End If
                'End Load General Financing Options 
                'Dim lbl As New Label()
                'lbl.Text = "<script language='javascript'> FinanceOptionChange();" & "<" & "/script>"
                'Page.Controls.Add(lbl)

            End If 'End of Load Financing
        Catch ex As Exception

        End Try
        calcSCFinancing()

        mhquoteID = quoteID
        MHValuelbl.Text = value.Replace(",", "")
        mhstatelbl.Text = state
        mhtypelbl.Text = type
        mhmfglbl.Text = mfg
        mhyearlbl.Text = year
        mhcountylbl.Text = county
        quoteIDlbl.Text = quoteID
        mhusagelbl.Text = Usage
        mhdistlbl.Text = dist
        lienlbl.Text = lien
        supheatlbl.Text = subheat
        lbldob.Text = dob
        protection.Text = prot
        ProgramChoice()

        ' mhvaluechanged.Text = "False"
        If mhvaluechanged.Text = "" Or mhvaluechanged.Text = "False" Then


            Dim def As System.Data.DataSet
            def = Common.runQueryDS("SELECT * FROM tblQuotes WHERE quoteID = '" & quoteID & "'")
            If def.Tables(0).Rows.Count > 0 Then
                Dim test As String
                test = def.Tables(0).Rows(0).Item("coverageAmt").ToString.Replace("$", "").Replace(",", "")
                If MHValuelbl.Text <> def.Tables(0).Rows(0).Item("coverageAmt").ToString.Replace("$", "").Replace(",", "") Then

                    mhvaluechanged.Text = "True"
                Else
                    mhvaluechanged.Text = "False"

                End If
            End If
        End If

        'If lbl_Lloyds_SMH.Text = "True" Then

        '    SC_MH_08.Visible = True
        '    SC08_mh_prog_Options.Visible = True
        '    SC08OptionRow.Visible = True
        '    calcSH08()
        'Else
        '    SC_MH_08.Visible = False
        '    SC08_mh_prog_Options.Visible = False
        '    SC08OptionRow.Visible = False

        'End If
        If CInt(MHValuelbl.Text) <= 25000 And lbl_Aegis_Stand.Text = "True" Then
            If mhusagelbl.Text = "Rental" Then
                dd_pl_Aegisvintsc1.Items.Clear()
                dd_pl_Aegisvintsc1.Items.Add("$0")
                dd_pl_Aegisvintsc1.Items.Add("$25,000")
                dd_mp_Aegisvintsc1.Items.Clear()
                dd_mp_Aegisvintsc1.Items.Add("$0")
                dd_mp_Aegisvintsc1.Items.Add("$500")
                Label163.Text = "Premises Liability:   "
            Else
                Label163.Text = "Personal Liability:  "
                dd_pl_Aegisvintsc1.Items.Clear()

                dd_pl_Aegisvintsc1.Items.Add("$25,000")
                dd_mp_Aegisvintsc1.Items.Clear()

                dd_mp_Aegisvintsc1.Items.Add("$500")
            End If
            AegisCalcVint()
            Aegisvint_mh_progsc1.Visible = True
            Aegisvint_mh_progsc1_Options.Visible = True
        Else
            Aegisvint_mh_progsc1.Visible = False
            Aegisvint_mh_progsc1_Options.Visible = False
        End If

        If lbl_Aegis_Rent.Text = "True" Or lbl_Aegis_Stand.Text = "True" Then

            'dd_aop_aiges1.SelectedValue = "$500"
            aiges_mh_prog2.Visible = False
            aiges_mh_prog2_Options.Visible = False
            aiges_mh_prog3.Visible = False
            aiges_mh_prog3_Options1.Visible = False
            loadAegisPP()
            If CDate(effDate) >= CDate("04/15/2014") Then
                aegis_addliving.Visible = True
                aegis_earthquake.Visible = False
                aegis_icelimit.Visible = True
                aegis_icedelete.Visible = True
                ' aegis_theft.Visible = True
                aegis_water.Visible = True
                aegis_waterexlusion.Visible = True
                aegis_golf.Visible = True
                aegis_animal.Visible = True
                aegis_pool.Visible = True
            Else
                aegis_addliving.Visible = False
                aegis_earthquake.Visible = False
                aegis_icelimit.Visible = False
                aegis_icedelete.Visible = False
                'aegis_theft.Visible = False
                aegis_water.Visible = False
                aegis_waterexlusion.Visible = False
                aegis_golf.Visible = False
                aegis_animal.Visible = False
                aegis_pool.Visible = False
            End If
            LoadAegisData()
            ' calcAegis()
        Else
            aiges_mh_prog2.Visible = False
            aiges_mh_prog2_Options.Visible = False
            aiges_mh_prog3.Visible = False
            aiges_mh_prog3_Options1.Visible = False
        End If
        'amslic_mh_progRent.Visible = False
        'amslicOptionRowRent.Visible = False
        'amslic_mh_prog.Visible = False
        'amslicOptionRow.Visible = False

        If lbl_Amslic_Rent.Text = "True" Or lbl_Amslic_Stand.Text = "True" Then
            amslic_mh_progRent.Visible = True
            amslicOptionRowRent.Visible = True
            amslic_mh_prog.Visible = True
            amslicOptionRow.Visible = True
            Load_Amslic()

            Amslic_Calc()
        Else
            amslic_mh_progRent.Visible = False
            amslicOptionRowRent.Visible = False
            amslic_mh_prog.Visible = False
            amslicOptionRow.Visible = False

        End If
        If lbl_Lloyds_Pack.Text = "True" Or lbl_Lloyds_Rent.Text = "True" Or lbl_Lloyds_Stand.Text = "True" Or lbl_Lloyds_SMH.Text = "True" Then


            Try
                dd_pl_08.SelectedValue = "$25,000"
                dd_mp_08.SelectedValue = "$500"

                Dim Connection As String = System.Configuration.ConfigurationManager.ConnectionStrings("ColonialMHConnectionString").ConnectionString
                Dim dbConnection As System.Data.IDbConnection = New System.Data.SqlClient.SqlConnection(Connection)
                Dim cmd As New SqlCommand("sp_GetLloydQuoteData", dbConnection)
                cmd.CommandType = CommandType.StoredProcedure
                cmd.Parameters.Add("@QuoteID", SqlDbType.VarChar, 8000).Value = mhquoteID
                Dim ds As Data.DataSet = New Data.DataSet

                cmd.Connection.Open()
                ' intRowsAff = cmd.ExecuteNonQuery()

                Dim myCommand = New SqlDataAdapter(cmd)
                myCommand.Fill(ds, "tbl1")
                If ds.Tables("tbl1").Rows.Count > 0 Then


                    ar_dwell1.Text = ds.Tables("tbl1").Rows(0).Item("PackDwel").ToString
                    ar_unattStr1.Text = ds.Tables("tbl1").Rows(0).Item("PackStruc").ToString
                    ar_perEff1.Text = ds.Tables("tbl1").Rows(0).Item("PackCont").ToString
                    ar_perLiab1.Text = ds.Tables("tbl1").Rows(0).Item("PackLiab").ToString
                    ar_medpay1.Text = ds.Tables("tbl1").Rows(0).Item("PackMedPay").ToString
                    ar_baseprem1.Text = "$" & ds.Tables("tbl1").Rows(0).Item("PackBasePrem").ToString.Replace("$", "")
                    If ds.Tables("tbl1").Rows(0).Item("PackAOP").ToString = "$500" Or ds.Tables("tbl1").Rows(0).Item("PackAOP").ToString = "$1000" Then
                        dd_aop_AR1.SelectedValue = ds.Tables("tbl1").Rows(0).Item("PackAOP").ToString
                    Else
                        dd_aop_AR1.SelectedValue = "$500"
                    End If

                    dd_hurded_AR1.Text = ds.Tables("tbl1").Rows(0).Item("PackWind").ToString
                    If ds.Tables("tbl1").Rows(0).Item("PackPerLiab").ToString = "$25,000" Or ds.Tables("tbl1").Rows(0).Item("PackPerLiab").ToString = "$50,000" Or ds.Tables("tbl1").Rows(0).Item("PackPerLiab").ToString = "$100,000" Then
                        dd_pl_AR1.SelectedValue = ds.Tables("tbl1").Rows(0).Item("PackPerLiab").ToString
                    End If
                    If ds.Tables("tbl1").Rows(0).Item("PackMHReplace").ToString = "Yes" Or ds.Tables("tbl1").Rows(0).Item("PackMHReplace").ToString = "No" Then
                        dd_mhr_AR1.SelectedValue = ds.Tables("tbl1").Rows(0).Item("PackMHReplace").ToString
                    End If

                    If ds.Tables("tbl1").Rows(0).Item("PackContReplace").ToString = "Yes" Or ds.Tables("tbl1").Rows(0).Item("PackContReplace").ToString = "No" Then
                        dd_rep_AR1.SelectedValue = ds.Tables("tbl1").Rows(0).Item("PackContReplace").ToString
                    End If
                    If ds.Tables("tbl1").Rows(0).Item("PackFullRepair").ToString = "Yes" Or ds.Tables("tbl1").Rows(0).Item("PackFullRepair").ToString = "No" Then
                        dd_sip_AR1.SelectedValue = ds.Tables("tbl1").Rows(0).Item("PackFullRepair").ToString
                    End If
                    'Pull in Attached Structures and Contents
                    txt_unattstr_AR1.Text = ds.Tables("tbl1").Rows(0).Item("PackStruc").ToString
                    txt_pp_AR1.Text = ds.Tables("tbl1").Rows(0).Item("PackCont").ToString
                    txt_unattstr_AR2.Text = ds.Tables("tbl1").Rows(0).Item("StandStruc").ToString
                    txt_pp_AR2.Text = ds.Tables("tbl1").Rows(0).Item("StandCont").ToString
                    txt_unattstr_AR3.Text = ds.Tables("tbl1").Rows(0).Item("RentStruc").ToString
                    txt_pp_AR3.Text = ds.Tables("tbl1").Rows(0).Item("RentCont").ToString

                    '--------------------------------------------
                    dd_aop_AR1_Amount.Text = ds.Tables("tbl1").Rows(0).Item("PackAOPPrem").ToString
                    dd_pl_AR1_Amount.Text = ds.Tables("tbl1").Rows(0).Item("PackPersLiabPrem").ToString
                    dd_med_AR1_amt.Text = ds.Tables("tbl1").Rows(0).Item("PackMedPrem").ToString
                    txt_unattstr_AR1_Amount.Text = ds.Tables("tbl1").Rows(0).Item("PackStrucPrem").ToString
                    txt_pp_AR1_Amount.Text = ds.Tables("tbl1").Rows(0).Item("PackContPrem").ToString
                    dd_mhr_AR1_Amount.Text = ds.Tables("tbl1").Rows(0).Item("PackMHReplacePrem").ToString
                    dd_rep_AR1_Amount.Text = ds.Tables("tbl1").Rows(0).Item("PackContReplacePrem").ToString
                    dd_sip_AR1_Amount.Text = ds.Tables("tbl1").Rows(0).Item("PackFullRepairPrem").ToString
                    If IsNumeric(ds.Tables("tbl1").Rows(0).Item("PackTax").ToString.Replace("$", "")) Then
                        ar_tax1.Text = CDbl(ds.Tables("tbl1").Rows(0).Item("PackTax").ToString.Replace("$", ""))
                    End If

                    ar_fees1.Text = ds.Tables("tbl1").Rows(0).Item("PackFees").ToString
                    ar_total1.Text = ds.Tables("tbl1").Rows(0).Item("Packtotal").ToString
                    ar_dwell2.Text = ds.Tables("tbl1").Rows(0).Item("StandDwel").ToString
                    ar_unattStr2.Text = ds.Tables("tbl1").Rows(0).Item("StandStruc").ToString
                    txt_unattstr_AR2.Text = ds.Tables("tbl1").Rows(0).Item("StandStruc").ToString
                    ar_perEff2.Text = ds.Tables("tbl1").Rows(0).Item("StandCont").ToString
                    txt_pp_AR2.Text = ds.Tables("tbl1").Rows(0).Item("StandCont").ToString
                    ar_perLiab2.Text = ds.Tables("tbl1").Rows(0).Item("StandLiab").ToString
                    ar_medpay2.Text = ds.Tables("tbl1").Rows(0).Item("StandMedPay").ToString

                    ''dd_mp_AR1.Items.FindByValue(ds.Tables("tbl1").Rows(0).Item("PackMedPay").ToString).Selected = True
                    'If ds.Tables("tbl1").Rows(0).Item("PackMedPay").ToString = "$500" Or ds.Tables("tbl1").Rows(0).Item("PackMedPay").ToString = "$1000" Then
                    '    dd_mp_AR1.SelectedValue = ds.Tables("tbl1").Rows(0).Item("PackMedPay").ToString
                    'End If
                    '  dd_mp_AR1.SelectedValue = ds.Tables("tbl1").Rows(0).Item("PackMedPay").ToString
                    If ds.Tables("tbl1").Rows(0).Item("PackMedPay").ToString = "$500" Or ds.Tables("tbl1").Rows(0).Item("PackMedPay").ToString = "$1000" Then
                        dd_mp_AR1.SelectedValue = ds.Tables("tbl1").Rows(0).Item("PackMedPay").ToString
                        'Else
                        '    dd_mp_AR1.SelectedValue = ""
                    End If

                    ar_medpay1.Text = ds.Tables("tbl1").Rows(0).Item("PackMedPay").ToString
                    Dim test As String
                    test = ds.Tables("tbl1").Rows(0).Item("StandMedPay").ToString

                    If ds.Tables("tbl1").Rows(0).Item("StandMedPay").ToString = "$500" Or ds.Tables("tbl1").Rows(0).Item("StandMedPay").ToString = "$0" Then
                        dd_mp_AR2.SelectedValue = ds.Tables("tbl1").Rows(0).Item("StandMedPay").ToString
                    Else
                        dd_mp_AR2.SelectedValue = "$0"
                    End If
                    'dd_mp_AR2.SelectedValue = ds.Tables("tbl1").Rows(0).Item("StandMedPay").ToString
                    ar_baseprem2.Text = "$" & ds.Tables("tbl1").Rows(0).Item("StandBasePrem").ToString.Replace("$", "")

                    If ds.Tables("tbl1").Rows(0).Item("StandAOP").ToString = "$500" Or ds.Tables("tbl1").Rows(0).Item("StandAOP").ToString = "$1000" Then
                        dd_aop_AR2.SelectedValue = ds.Tables("tbl1").Rows(0).Item("StandAOP").ToString
                    Else
                        dd_aop_AR2.SelectedValue = "$500"
                    End If

                    test = ds.Tables("tbl1").Rows(0).Item("StandPerLiab").ToString
                    If ds.Tables("tbl1").Rows(0).Item("StandPerLiab").ToString = "$25,000" Or ds.Tables("tbl1").Rows(0).Item("StandPerLiab").ToString = "$50,000" Or ds.Tables("tbl1").Rows(0).Item("StandPerLiab").ToString = "$100,000" Or ds.Tables("tbl1").Rows(0).Item("StandPerLiab").ToString = "$300,000" Then
                        dd_pl_AR2.SelectedValue = ds.Tables("tbl1").Rows(0).Item("StandPerLiab").ToString
                    End If
                    If ds.Tables("tbl1").Rows(0).Item("StandMHReplace").ToString = "Yes" Or ds.Tables("tbl1").Rows(0).Item("StandMHReplace").ToString = "No" Then
                        dd_mhr_AR2.SelectedValue = ds.Tables("tbl1").Rows(0).Item("StandMHReplace").ToString
                    End If

                    If ds.Tables("tbl1").Rows(0).Item("StandContReplace").ToString = "Yes" Or ds.Tables("tbl1").Rows(0).Item("StandContReplace").ToString = "No" Then
                        dd_rep_AR2.SelectedValue = ds.Tables("tbl1").Rows(0).Item("StandContReplace").ToString
                    End If
                    If ds.Tables("tbl1").Rows(0).Item("StandFullRepair").ToString = "Yes" Or ds.Tables("tbl1").Rows(0).Item("StandFullRepair").ToString = "No" Then
                        dd_sip_AR2.SelectedValue = ds.Tables("tbl1").Rows(0).Item("StandFullRepair").ToString
                    End If


                    dd_hurded_AR2.Text = ds.Tables("tbl1").Rows(0).Item("StandWind").ToString
                    dd_thur_Ar2.Text = ds.Tables("tbl1").Rows(0).Item("StandWind").ToString



                    dd_aop_AR2_Amount.Text = ds.Tables("tbl1").Rows(0).Item("StandAOPPrem").ToString
                    dd_pl_AR2_Amount.Text = ds.Tables("tbl1").Rows(0).Item("StandPersLiabPrem").ToString
                    dd_med_AR2_amt.Text = ds.Tables("tbl1").Rows(0).Item("StandMedPrem").ToString
                    txt_unattstr_AR2_Amount.Text = ds.Tables("tbl1").Rows(0).Item("StandStrucPrem").ToString
                    txt_pp_AR2_Amount.Text = ds.Tables("tbl1").Rows(0).Item("StandContPrem").ToString
                    dd_mhr_AR2_Amount.Text = ds.Tables("tbl1").Rows(0).Item("StandMHReplacePrem").ToString
                    dd_rep_AR2_Amount.Text = ds.Tables("tbl1").Rows(0).Item("StandContReplacePrem").ToString
                    dd_sip_AR2_Amount.Text = ds.Tables("tbl1").Rows(0).Item("StandFullRepairPrem").ToString
                    If IsNumeric(ds.Tables("tbl1").Rows(0).Item("StandTax").ToString.Replace("$", "")) Then
                        ar_tax2.Text = CDbl(ds.Tables("tbl1").Rows(0).Item("StandTax").ToString.Replace("$", ""))
                    End If

                    ar_fees2.Text = ds.Tables("tbl1").Rows(0).Item("StandFees").ToString
                    ar_total2.Text = ds.Tables("tbl1").Rows(0).Item("Standtotal").ToString
                    ar_dwell3.Text = ds.Tables("tbl1").Rows(0).Item("RentDwel").ToString
                    ar_unattStr3.Text = ds.Tables("tbl1").Rows(0).Item("RentStruc").ToString
                    ar_perEff3.Text = ds.Tables("tbl1").Rows(0).Item("RentCont").ToString
                    ar_perLiab3.Text = ds.Tables("tbl1").Rows(0).Item("RentLiab").ToString
                    ar_medpay3.Text = ds.Tables("tbl1").Rows(0).Item("RentMedPay").ToString
                    ar_baseprem3.Text = "$" & ds.Tables("tbl1").Rows(0).Item("RentBasePrem").ToString.Replace("$", "")
                    If ds.Tables("tbl1").Rows(0).Item("RentAOP").ToString = "" Then
                        dd_aop_AR3.SelectedValue = "$500"
                    Else
                        dd_aop_AR3.SelectedValue = ds.Tables("tbl1").Rows(0).Item("RentAOP").ToString
                    End If
                    ' dd_aop_AR3.SelectedValue = ds.Tables("tbl1").Rows(0).Item("RentAOP").ToString
                    dd_hurded_AR3.Text = ds.Tables("tbl1").Rows(0).Item("RentWind").ToString

                    If ds.Tables("tbl1").Rows(0).Item("RentPerLiab").ToString = "$25,000" Or ds.Tables("tbl1").Rows(0).Item("RentPerLiab").ToString = "$50,000" Or ds.Tables("tbl1").Rows(0).Item("RentPerLiab").ToString = "$100,000" Then
                        dd_pl_AR3.SelectedValue = ds.Tables("tbl1").Rows(0).Item("RentPerLiab").ToString
                    End If
                    If ds.Tables("tbl1").Rows(0).Item("RentMHReplace").ToString = "Yes" Or ds.Tables("tbl1").Rows(0).Item("RentMHReplace").ToString = "No" Then
                        dd_mhr_AR3.SelectedValue = ds.Tables("tbl1").Rows(0).Item("RentMHReplace").ToString
                    End If

                    If ds.Tables("tbl1").Rows(0).Item("RentContReplace").ToString = "Yes" Or ds.Tables("tbl1").Rows(0).Item("RentContReplace").ToString = "No" Then
                        dd_rep_AR3.SelectedValue = ds.Tables("tbl1").Rows(0).Item("RentContReplace").ToString
                    End If
                    If ds.Tables("tbl1").Rows(0).Item("RentFullRepair").ToString = "Yes" Or ds.Tables("tbl1").Rows(0).Item("RentFullRepair").ToString = "No" Then
                        dd_sip_AR3.SelectedValue = ds.Tables("tbl1").Rows(0).Item("RentFullRepair").ToString
                    End If







                    dd_aop_AR3_Amount.Text = ds.Tables("tbl1").Rows(0).Item("RentAOPPrem").ToString
                    dd_pl_AR3_Amount.Text = ds.Tables("tbl1").Rows(0).Item("RentPersLiabPrem").ToString
                    dd_med_AR3_amt.Text = ds.Tables("tbl1").Rows(0).Item("RentMedPrem").ToString
                    txt_unattstr_AR3_Amount.Text = ds.Tables("tbl1").Rows(0).Item("RentStrucPrem").ToString
                    txt_pp_AR3_Amount.Text = ds.Tables("tbl1").Rows(0).Item("RentContPrem").ToString
                    dd_rep_AR3_Amount.Text = ds.Tables("tbl1").Rows(0).Item("RentMHReplacePrem").ToString
                    dd_rep_AR3_Amount.Text = ds.Tables("tbl1").Rows(0).Item("RentContReplacePrem").ToString
                    dd_sip_AR3_Amount.Text = ds.Tables("tbl1").Rows(0).Item("RentFullRepairPrem").ToString
                    If IsNumeric(ds.Tables("tbl1").Rows(0).Item("RentTax").ToString.Replace("$", "")) Then
                        ar_tax3.Text = CDbl(ds.Tables("tbl1").Rows(0).Item("RentTax").ToString.Replace("$", ""))
                    End If

                    ar_fees3.Text = ds.Tables("tbl1").Rows(0).Item("RentFees").ToString
                    ar_total3.Text = ds.Tables("tbl1").Rows(0).Item("Renttotal").ToString

                    'SMH
                    SC08_dwell.Text = ds.Tables("tbl1").Rows(0).Item("SMHPackDwel").ToString
                    SC08_unattStr.Text = ds.Tables("tbl1").Rows(0).Item("SMHPackStruc").ToString
                    SC08_perEff.Text = ds.Tables("tbl1").Rows(0).Item("SMHPackCont").ToString
                    txt_pp_08.Text = ds.Tables("tbl1").Rows(0).Item("SMHPackCont").ToString
                    SC08_perLiab.Text = ds.Tables("tbl1").Rows(0).Item("SMHPackLiab").ToString
                    SC08_medpay.Text = ds.Tables("tbl1").Rows(0).Item("SMHPackMedPay").ToString
                    SC08_baseprem.Text = "$" & ds.Tables("tbl1").Rows(0).Item("SMHPackBasePrem").ToString.Replace("$", "")


                    If ds.Tables("tbl1").Rows(0).Item("SMHPackAOP").ToString = "$500" Or ds.Tables("tbl1").Rows(0).Item("SMHPackAOP").ToString = "$1000" Or ds.Tables("tbl1").Rows(0).Item("SMHPackAOP").ToString = "$2500" Then
                        dd_aop_08.SelectedValue = ds.Tables("tbl1").Rows(0).Item("SMHPackAOP").ToString
                    End If
                    dd_hurded_08.Text = ds.Tables("tbl1").Rows(0).Item("SMHPackWind").ToString

                    If ds.Tables("tbl1").Rows(0).Item("SMHPackPerLiab").ToString = "$25,000" Or ds.Tables("tbl1").Rows(0).Item("SMHPackPerLiab").ToString = "$50,000" Or ds.Tables("tbl1").Rows(0).Item("SMHPackPerLiab").ToString = "$100,000" Or ds.Tables("tbl1").Rows(0).Item("SMHPackPerLiab").ToString = "$300,000" Then
                        dd_pl_08.SelectedValue = ds.Tables("tbl1").Rows(0).Item("SMHPackPerLiab").ToString
                    End If
                    If ds.Tables("tbl1").Rows(0).Item("SMHPackContReplace").ToString = "Yes" Or ds.Tables("tbl1").Rows(0).Item("SMHPackContReplace").ToString = "No" Then
                        dd_rep_08.SelectedValue = ds.Tables("tbl1").Rows(0).Item("SMHPackContReplace").ToString
                    End If
                    If ds.Tables("tbl1").Rows(0).Item("SMHPackContReplace").ToString = "Yes" Or ds.Tables("tbl1").Rows(0).Item("SMHPackContReplace").ToString = "No" Then
                        dd_sip_08.SelectedValue = ds.Tables("tbl1").Rows(0).Item("SMHPackFullRepair").ToString
                    End If



                    ' dd_mhr_08.SelectedValue = ds.Tables("tbl1").Rows(0).Item("SMHPackMHReplace").ToString


                    dd_aop_08_Amount.Text = ds.Tables("tbl1").Rows(0).Item("SMHPackAOPPrem").ToString
                    dd_pl_08_Amount.Text = ds.Tables("tbl1").Rows(0).Item("SMHPackPersLiabPrem").ToString
                    dd_med_08_amt.Text = ds.Tables("tbl1").Rows(0).Item("SMHPackMedPrem").ToString
                    txt_unattstr_08_Amount.Text = ds.Tables("tbl1").Rows(0).Item("SMHPackStrucPrem").ToString
                    txt_pp_08_Amount.Text = ds.Tables("tbl1").Rows(0).Item("SMHPackContPrem").ToString
                    ' dd_mhr_08_Amount.Text = ds.Tables("tbl1").Rows(0).Item("SMHPackMHReplacePrem").ToString
                    dd_rep_08_Amount.Text = ds.Tables("tbl1").Rows(0).Item("SMHPackContReplacePrem").ToString
                    dd_sip_08_Amount.Text = ds.Tables("tbl1").Rows(0).Item("SMHPackFullRepairPrem").ToString
                    If IsNumeric(ds.Tables("tbl1").Rows(0).Item("SMHPackTax").ToString.Replace("$", "")) Then
                        SC08_tax.Text = CDbl(ds.Tables("tbl1").Rows(0).Item("SMHPackTax").ToString.Replace("$", ""))
                    End If

                    SC08_fees.Text = ds.Tables("tbl1").Rows(0).Item("SMHPackFees").ToString
                    SC08_total.Text = ds.Tables("tbl1").Rows(0).Item("SMHPacktotal").ToString



                    'END SMH




                    If ds.Tables(0).Rows(0).Item("ARRateType").ToString() <> "" Then
                        HiddenFieldSelected.Value = ds.Tables(0).Rows(0).Item("ARRateType").ToString()
                        If ds.Tables(0).Rows(0).Item("ARRateType").ToString() = "SMH Package" Then
                            rateTypelbl.Text = "Lloyds Specialty MH – HO8"
                        ElseIf ds.Tables(0).Rows(0).Item("ARRateType").ToString() = "Aegis Standard" Or ds.Tables(0).Rows(0).Item("ARRateType").ToString() = "Aegis Rental" Or ds.Tables(0).Rows(0).Item("ARRateType").ToString() = "Aegis Vintage" Then

                            If lbl_Aegis_Rent.Text = "False" And lbl_Aegis_Stand.Text = "False" Then

                                rateTypelbl.Text = "" 'ds.Tables(0).Rows(0).Item("ARRateType").ToString()
                            Else
                                rateTypelbl.Text = ds.Tables(0).Rows(0).Item("ARRateType").ToString()
                                LoadAegisData()
                            End If

                        ElseIf ds.Tables(0).Rows(0).Item("ARRateType").ToString() = "AMSLIC Standard" Or ds.Tables(0).Rows(0).Item("ARRateType").ToString() = "AMSLIC Rental" Then
                            If lbl_Amslic_Rent.Text = "False" And lbl_Amslic_Stand.Text = "False" Then

                                rateTypelbl.Text = "" 'ds.Tables(0).Rows(0).Item("ARRateType").ToString()
                            Else
                                rateTypelbl.Text = ds.Tables(0).Rows(0).Item("ARRateType").ToString()
                                Load_Amslic()
                            End If
                        ElseIf Left(ds.Tables(0).Rows(0).Item("ARRateType").ToString(), 3) = "WMJ" Then
                            If lbl_WMJ_Pack.Text = "False" Then

                                rateTypelbl.Text = "" 'ds.Tables(0).Rows(0).Item("ARRateType").ToString()
                            Else
                                rateTypelbl.Text = ds.Tables(0).Rows(0).Item("ARRateType").ToString()

                            End If
                            If lbl_WMJ_PackNC.Text = "False" Then

                                rateTypelbl.Text = "" 'ds.Tables(0).Rows(0).Item("ARRateType").ToString()
                            Else
                                rateTypelbl.Text = ds.Tables(0).Rows(0).Item("ARRateType").ToString()

                            End If
                        Else

                            rateTypelbl.Text = "Lloyds " & ds.Tables(0).Rows(0).Item("ARRateType").ToString()

                        End If
                        ' rateTypelbl.Text = "Lloyds " & ds.Tables(0).Rows(0).Item("ARRateType").ToString()
                        rateTypelbl.Font.Bold = True
                        rateTypelbl.ForeColor = Drawing.Color.Green

                        premiumBtnTable.Attributes.Add("style", "display:block")
                    End If
                End If
                'If state = "SC" Then
                '    If Usage = "Seasonal" Or Usage = "Owner" Then
                '        If mhtype = "Doublewide" Or mhtype = "Modular" Then
                '            'if HO8 then make visible and call load data or calculation

                '            SC_MH_08.Visible = True
                '            SC08_mh_prog_Options.Visible = True
                '            SC08OptionRow.Visible = True
                '            calcSH08()
                '        Else
                '            SC_MH_08.Visible = False
                '            SC08_mh_prog_Options.Visible = False
                '            SC08OptionRow.Visible = False

                '        End If
                '    Else
                '        SC_MH_08.Visible = False
                '        SC08_mh_prog_Options.Visible = False
                '        SC08OptionRow.Visible = False
                '    End If
                'End If
                If lbl_Lloyds_SMH.Text = "True" Then
                    SC_MH_08.Visible = True
                    SC08_mh_prog_Options.Visible = True
                    SC08OptionRow.Visible = True
                    calcSH08()
                Else
                    SC_MH_08.Visible = False
                    SC08_mh_prog_Options.Visible = False
                    SC08OptionRow.Visible = False

                End If
                If lbl_Lloyds_Rent.Text = "True" Then
                    ar_mh_prog3.Visible = True
                    ar_mh_prog3_Options.Visible = True
                Else
                    ar_mh_prog3.Visible = False
                    ar_mh_prog3_Options.Visible = False
                End If
                Calc()
            Catch ex As Exception
                errortrap("LoadLloydsPremiums " & mhquoteID, "Get Loyds Calc data", ex.Message)
            End Try
        End If
        'Show hide button
        'If LloydsState = "SC" And Not rateTypelbl.Text.ToString.ToUpper.Contains("AEG") Then
        '    SCPremFinbtn.Visible = True
        '    calcSCFinancing()
        'ElseIf LloydsState = "GA" Or LloydsState = "TN" Or LloydsState = "NC" Then
        '    premFinbtn.Visible = True
        'Else
        '    SCPremFinbtn.Visible = False
        'End If
        premCalcbtn.Visible = True

        If lbl_WMJ_Pack.Text = "True" Then

            wmj_mh_prog2.Visible = True
            wmj_mh_prog2_Options.Visible = True
            loadWMJPP()
            WMJPPtotals()
            LoadWMJData()
            ' calcWMJ()

        Else
            wmj_mh_prog2.Visible = False
            wmj_mh_prog2_Options.Visible = False
        End If

        If lbl_WMJ_PackNC.Text = "True" Then
            loadWMJPPnc1()
            WMJPPtotalsnc1()
            'LoadWMJData()
            'calcWMJNC()
            'wmj_mh_prognc1.Visible = True
            'wmj_mh_prognc1_Options.Visible = True

            loadWMJPPnc2()
            WMJPPtotalsnc2()
            'LoadWMJData()
            'calcWMJNC()
            'wmj_mh_prognc2.Visible = True
            'wmj_mh_prognc2_Options.Visible = True

            loadWMJPPnc3()
            WMJPPtotalsnc3()
            LoadWMJData()
            'calcWMJNC()
            'wmj_mh_prognc3.Visible = True
            'wmj_mh_prognc3_Options.Visible = True
        Else
            wmj_mh_prognc1.Visible = False
            wmj_mh_prognc1_Options.Visible = False
            wmj_mh_prognc2.Visible = False
            wmj_mh_prognc2_Options.Visible = False
            wmj_mh_prognc3.Visible = False
            wmj_mh_prognc3_Options.Visible = False

        End If

    End Sub

    Public Sub Calc()

        If dd_mhr_AR1.SelectedValue = "Yes" Then
            dd_sip_AR1.SelectedValue = "No"
            dd_sip_AR1.Enabled = False
        Else
            dd_sip_AR1.Enabled = True

        End If
        If dd_sip_AR1.SelectedValue = "Yes" Then
            dd_mhr_AR1.SelectedValue = "No"
            dd_mhr_AR1.Enabled = False
        Else
            dd_mhr_AR1.Enabled = True

        End If
        'If mhstatelbl.Text = "SC" Then
        'If mhstatelbl.Text <> "DE" Then

        '    If txt_unattstr_AR2.Text = "$0.00" Or txt_unattstr_AR2.Text = "$0" Then
        '        txt_unattstr_AR2.Text = "$500"

        '    End If
        '    If txt_pp_AR2.Text = "$0.00" Or txt_pp_AR2.Text = "$0" Then
        '        txt_pp_AR2.Text = CInt(CInt(MHValuelbl.Text) * 0.3)

        '    End If
        '    If dd_pl_AR2.SelectedValue = "$0" Then
        '        dd_pl_AR2.SelectedValue = "$25,000"

        '    End If
        '    dd_mp_AR2.SelectedValue = "$500"
        '    'If mhstatelbl.Text = "NC" Then
        '    '    If txt_unattstr_AR2.Text = "$0.00" Or txt_unattstr_AR2.Text = "$0" Then
        '    '        txt_unattstr_AR2.Text = "$500"

        '    '    End If
        '    '    If txt_pp_AR2.Text = "$0.00" Or txt_pp_AR2.Text = "$0" Then
        '    '        txt_pp_AR2.Text = CInt(CInt(MHValuelbl.Text) * 0.03)

        '    '    End If
        '    '    If dd_pl_AR2.SelectedValue = "$0" Then
        '    '        dd_pl_AR2.SelectedValue = "$25,000"

        '    '    End If
        '    '    dd_mp_AR2.SelectedValue = "$500"
        '    'End If

        'End If
        If mhstatelbl.Text = "DE" Then
            If Date.Now.Year - mhyearlbl.Text > 10 Then
                dd_mhr_AR1.Enabled = False
                dd_mhr_AR1.SelectedValue = "No"
                dd_mhr_AR2.Enabled = False
                dd_mhr_AR2.SelectedValue = "No"
                dd_mhr_AR3.Enabled = False
                dd_mhr_AR3.SelectedValue = "No"
            Else
                dd_mhr_AR1.Enabled = True
                dd_mhr_AR2.Enabled = True
                dd_mhr_AR3.Enabled = True
            End If
            If mhdistlbl.Text = "Less than 0.5 miles" Or mhdistlbl.Text = "0.5 – 5 miles" Then
                dd_hurded_AR2.Text = "$1500"
            Else
                dd_hurded_AR2.Text = "$1000"

            End If
        Else
            If mhdistlbl.Text = "Less than 0.5 miles" Or mhdistlbl.Text = "0.5 – 5 miles" Then
                dd_hurded_AR3.Text = "$1500"
            Else
                dd_hurded_AR3.Text = "$1000"

            End If
            If Date.Now.Year - mhyearlbl.Text >= 10 Then
                dd_mhr_AR1.Enabled = False
                dd_mhr_AR1.SelectedValue = "No"
                dd_mhr_AR2.Enabled = False
                dd_mhr_AR2.SelectedValue = "No"
                dd_mhr_AR3.Enabled = False
                dd_mhr_AR3.SelectedValue = "No"
            Else
                dd_mhr_AR1.Enabled = True
                dd_mhr_AR2.Enabled = True
                dd_mhr_AR3.Enabled = True
            End If
        End If

        mhvalue = MHValuelbl.Text
        mhcounty = mhcountylbl.Text
        mhstate = mhstatelbl.Text
        mhmfg = mhmfglbl.Text
        mhtype = mhtypelbl.Text
        mhyear = mhyearlbl.Text
        lblchange.Text = ""
        If mhvaluechanged.Text = "True" Then
            If mhstatelbl.Text <> "DE" Then


                txt_unattstr_AR2.Text = "$500"



                txt_pp_AR2.Text = CInt(CInt(MHValuelbl.Text) * 0.3)



                dd_pl_AR2.SelectedValue = "$25,000"

                dd_mp_AR2.SelectedValue = "$500"
            End If

        End If
        If IsNumeric(txt_unattstr_AR1.Text.Replace("$", "")) Then
            If CInt(txt_unattstr_AR1.Text.Replace("$", "")) < 500 Then

                txt_unattstr_AR1.Text = "500"
                lblchange.Text += "Increase Structures is less than $500.  Changed To $500:  "
                lblchange.Visible = True
            End If
        End If
        If IsNumeric(txt_pp_AR1.Text.Replace("$", "")) Then
            If CInt(txt_pp_AR1.Text.Replace("$", "")) < CInt(mhvalue * 0.3) Then
                txt_pp_AR1.Text = CInt(mhvalue * 0.3)
                lblchange.Text += "Increase Contents is less than $" & CInt(mhvalue * 0.3) & ".  Changed To $" & CInt(mhvalue * 0.3)
                lblchange.Visible = True
            End If
        End If
        Dim intRowsAff As Integer
        Dim Connection As String = System.Configuration.ConfigurationManager.ConnectionStrings("ColonialMHConnectionString").ConnectionString
        Dim dbConnection As System.Data.IDbConnection = New System.Data.SqlClient.SqlConnection(Connection)
        Dim cmd As New SqlCommand("sp_getLloydRates", dbConnection)
        cmd.CommandType = CommandType.StoredProcedure
        cmd.Parameters.Add("@MHvalue", SqlDbType.VarChar, 8000).Value = mhvalue
        cmd.Parameters.Add("@PackASvalue", SqlDbType.VarChar, 8000).Value = txt_unattstr_AR1.Text.Replace("$", "").Replace(",", "")
        cmd.Parameters.Add("@StandASvalue", SqlDbType.VarChar, 8000).Value = txt_unattstr_AR2.Text.Replace("$", "").Replace(",", "")
        cmd.Parameters.Add("@RentASvalue", SqlDbType.VarChar, 8000).Value = txt_unattstr_AR3.Text.Replace("$", "").Replace(",", "")
        cmd.Parameters.Add("@VacantASvalue", SqlDbType.VarChar, 8000).Value = txt_unattstr_AR1.Text.Replace("$", "").Replace(",", "")
        cmd.Parameters.Add("@PackPSvalue", SqlDbType.VarChar, 8000).Value = txt_pp_AR1.Text.Replace("$", "").Replace(",", "")
        cmd.Parameters.Add("@StandPSvalue", SqlDbType.VarChar, 8000).Value = txt_pp_AR2.Text.Replace("$", "").Replace(",", "")
        cmd.Parameters.Add("@RentPSvalue", SqlDbType.VarChar, 8000).Value = txt_pp_AR3.Text.Replace("$", "").Replace(",", "")
        cmd.Parameters.Add("@VacantPSvalue", SqlDbType.VarChar, 8000).Value = txt_pp_AR1.Text.Replace("$", "").Replace(",", "")
        cmd.Parameters.Add("@PropType", SqlDbType.VarChar, 8000).Value = mhtype
        cmd.Parameters.Add("@PackAOP", SqlDbType.VarChar, 8000).Value = dd_aop_AR1.SelectedValue().Replace("$", "").Replace(",", "")
        cmd.Parameters.Add("@StandAOP", SqlDbType.VarChar, 8000).Value = dd_aop_AR2.SelectedValue().Replace("$", "").Replace(",", "")
        cmd.Parameters.Add("@RentAOP", SqlDbType.VarChar, 8000).Value = dd_aop_AR3.SelectedValue().Replace("$", "").Replace(",", "")
        cmd.Parameters.Add("@VacantAOP", SqlDbType.VarChar, 8000).Value = dd_aop_AR1.SelectedValue().Replace("$", "").Replace(",", "")
        cmd.Parameters.Add("@PackWind", SqlDbType.VarChar, 8000).Value = dd_hurded_AR1.Text.Replace("$", "").Replace(",", "")
        cmd.Parameters.Add("@StandWind", SqlDbType.VarChar, 8000).Value = dd_hurded_AR2.Text.Replace("$", "").Replace(",", "")
        cmd.Parameters.Add("@RentWind", SqlDbType.VarChar, 8000).Value = dd_hurded_AR3.Text.Replace("$", "").Replace(",", "")
        cmd.Parameters.Add("@VacantWind", SqlDbType.VarChar, 8000).Value = dd_hurded_AR1.Text.Replace("$", "").Replace(",", "")
        cmd.Parameters.Add("@PackLiabPer", SqlDbType.VarChar, 8000).Value = dd_pl_AR1.SelectedValue().Replace("$", "").Replace(",", "")
        cmd.Parameters.Add("@StandLiabPer", SqlDbType.VarChar, 8000).Value = dd_pl_AR2.SelectedValue().Replace("$", "").Replace(",", "")
        If dd_pl_AR3.SelectedValue().Replace("$", "").Replace(",", "") = "" Then
            cmd.Parameters.Add("@RentLiabPer", SqlDbType.VarChar, 8000).Value = "0.00" 'dd_pl_AR3.SelectedValue().Replace("$", "").Replace(",", "")
        Else
            cmd.Parameters.Add("@RentLiabPer", SqlDbType.VarChar, 8000).Value = dd_pl_AR3.SelectedValue().Replace("$", "").Replace(",", "")
        End If

        cmd.Parameters.Add("@VacantLiabPer", SqlDbType.VarChar, 8000).Value = dd_pl_AR1.SelectedValue().Replace("$", "").Replace(",", "")
        cmd.Parameters.Add("@LiabMed", SqlDbType.VarChar, 8000).Value = dd_mp_AR1.SelectedValue().Replace("$", "").Replace(",", "")
        cmd.Parameters.Add("@packContRep", SqlDbType.VarChar, 8000).Value = dd_rep_AR1.SelectedValue()
        cmd.Parameters.Add("@standContRep", SqlDbType.VarChar, 8000).Value = dd_rep_AR2.SelectedValue()
        cmd.Parameters.Add("@rentContRep", SqlDbType.VarChar, 8000).Value = dd_rep_AR3.SelectedValue()
        cmd.Parameters.Add("@vacantContRep", SqlDbType.VarChar, 8000).Value = "" '
        cmd.Parameters.Add("@PackFullRep", SqlDbType.VarChar, 8000).Value = dd_sip_AR1.SelectedValue()
        cmd.Parameters.Add("@StandFullRep", SqlDbType.VarChar, 8000).Value = dd_sip_AR2.SelectedValue()
        cmd.Parameters.Add("@RentFullRep", SqlDbType.VarChar, 8000).Value = dd_sip_AR3.SelectedValue()
        cmd.Parameters.Add("@VacantFullRep", SqlDbType.VarChar, 8000).Value = "" '
        cmd.Parameters.Add("@PackMHRep", SqlDbType.VarChar, 8000).Value = dd_mhr_AR1.SelectedValue()
        cmd.Parameters.Add("@StandMHRep", SqlDbType.VarChar, 8000).Value = dd_mhr_AR2.SelectedValue()
        cmd.Parameters.Add("@RentMHRep", SqlDbType.VarChar, 8000).Value = dd_mhr_AR3.SelectedValue()
        cmd.Parameters.Add("@VacantMHRep", SqlDbType.VarChar, 8000).Value = "" '
        cmd.Parameters.Add("@MHYear", SqlDbType.VarChar, 8000).Value = mhyear
        cmd.Parameters.Add("@MHMFG", SqlDbType.VarChar, 8000).Value = mhmfg
        cmd.Parameters.Add("@State", SqlDbType.VarChar, 8000).Value = mhstate
        cmd.Parameters.Add("@county", SqlDbType.VarChar, 8000).Value = mhcounty
        cmd.Parameters.Add("@dist", SqlDbType.VarChar, 8000).Value = mhdistlbl.Text
        cmd.Parameters.Add("@effDate", SqlDbType.VarChar, 8000).Value = lbleffdate.Text

        Try
            Dim ds As Data.DataSet = New Data.DataSet

            cmd.Connection.Open()
            ' intRowsAff = cmd.ExecuteNonQuery()

            Dim myCommand = New SqlDataAdapter(cmd)
            myCommand.Fill(ds, "tbl1")
            If ds.Tables("tbl1").Rows.Count > 0 Then
                Lloydcalc(ds)
            End If

        Catch ex As Exception
            Dim s As String = ""
            For Each param As SqlParameter In cmd.Parameters
                s += param.ParameterName & "="
                s += param.Value & ":  "

            Next
            errortrap("Geting Calculation data " & s, "Calculation CALC", ex.Message)
        End Try

    End Sub
    Public Sub savePrem(ByVal quoteID As String)
        If quoteID <> "" Then
            If rateTypelbl.Text = "Aegis Standard" Or rateTypelbl.Text = "Aegis Rental" Or rateTypelbl.Text = "Aegis Vintage" Then
                SaveAegis(quoteID)
            ElseIf rateTypelbl.Text = "AMSLIC Standard" Or rateTypelbl.Text = "AMSLIC Rental" Then
                Amslic_save(quoteID)
            ElseIf Left(rateTypelbl.Text, 3) = "WMJ" Then
                SaveWMJ(quoteID)
            Else
                quoteIDlbl.Text = quoteID
                Dim value As String = ""
                Dim Connection As String = System.Configuration.ConfigurationManager.ConnectionStrings("ColonialMHConnectionString").ConnectionString
                Dim dbConnection As System.Data.IDbConnection = New System.Data.SqlClient.SqlConnection(Connection)
                Dim cmd As New SqlCommand("sp_LloydQuoteSave", dbConnection)
                cmd.CommandType = CommandType.StoredProcedure
                cmd.Parameters.Add("@QuoteID", SqlDbType.VarChar, 8000).Value = quoteID
                cmd.Parameters.Add("@PackDwel", SqlDbType.VarChar, 8000).Value = ar_dwell1.Text
                cmd.Parameters.Add("@PackStruc", SqlDbType.VarChar, 8000).Value = ar_unattStr1.Text
                cmd.Parameters.Add("@PackCont", SqlDbType.VarChar, 8000).Value = ar_perEff1.Text
                cmd.Parameters.Add("@PackLiab", SqlDbType.VarChar, 8000).Value = ar_perLiab1.Text
                cmd.Parameters.Add("@PackMedPay", SqlDbType.VarChar, 8000).Value = ar_medpay1.Text
                cmd.Parameters.Add("@PackBasePrem", SqlDbType.VarChar, 8000).Value = ar_baseprem1.Text
                cmd.Parameters.Add("@PackAOP", SqlDbType.VarChar, 8000).Value = dd_aop_AR1.SelectedValue()
                cmd.Parameters.Add("@PackWind", SqlDbType.VarChar, 8000).Value = dd_hurded_AR1.Text
                cmd.Parameters.Add("@PackPerLiab", SqlDbType.VarChar, 8000).Value = dd_pl_AR1.SelectedValue()
                cmd.Parameters.Add("@PackMHReplace", SqlDbType.VarChar, 8000).Value = dd_mhr_AR1.SelectedValue()
                cmd.Parameters.Add("@PackContReplace", SqlDbType.VarChar, 8000).Value = dd_rep_AR1.SelectedValue()
                cmd.Parameters.Add("@PackFullRepair", SqlDbType.VarChar, 8000).Value = dd_sip_AR1.SelectedValue()
                cmd.Parameters.Add("@PackAOPPrem", SqlDbType.VarChar, 8000).Value = dd_aop_AR1_Amount.Text
                cmd.Parameters.Add("@PackPersLiabPrem", SqlDbType.VarChar, 8000).Value = dd_pl_AR1_Amount.Text
                cmd.Parameters.Add("@PackMedPrem", SqlDbType.VarChar, 8000).Value = dd_med_AR1_amt.Text
                cmd.Parameters.Add("@PackStrucPrem", SqlDbType.VarChar, 8000).Value = txt_unattstr_AR1_Amount.Text
                cmd.Parameters.Add("@PackContPrem", SqlDbType.VarChar, 8000).Value = txt_pp_AR1_Amount.Text
                cmd.Parameters.Add("@PackMHReplacePrem", SqlDbType.VarChar, 8000).Value = dd_mhr_AR1_Amount.Text
                cmd.Parameters.Add("@PackContReplacePrem", SqlDbType.VarChar, 8000).Value = dd_rep_AR1_Amount.Text
                cmd.Parameters.Add("@PackFullRepairPrem", SqlDbType.VarChar, 8000).Value = dd_sip_AR1_Amount.Text
                cmd.Parameters.Add("@PackTax", SqlDbType.VarChar, 8000).Value = ar_tax1.Text
                cmd.Parameters.Add("@PackFees", SqlDbType.VarChar, 8000).Value = ar_fees1.Text
                cmd.Parameters.Add("@Packtotal", SqlDbType.VarChar, 8000).Value = ar_total1.Text
                cmd.Parameters.Add("@StandDwel", SqlDbType.VarChar, 8000).Value = ar_dwell2.Text
                cmd.Parameters.Add("@StandStruc", SqlDbType.VarChar, 8000).Value = ar_unattStr2.Text
                cmd.Parameters.Add("@StandCont", SqlDbType.VarChar, 8000).Value = ar_perEff2.Text
                cmd.Parameters.Add("@StandLiab", SqlDbType.VarChar, 8000).Value = ar_perLiab2.Text
                cmd.Parameters.Add("@StandMedPay", SqlDbType.VarChar, 8000).Value = ar_medpay2.Text
                cmd.Parameters.Add("@StandBasePrem", SqlDbType.VarChar, 8000).Value = ar_baseprem2.Text
                cmd.Parameters.Add("@StandAOP", SqlDbType.VarChar, 8000).Value = dd_aop_AR2.SelectedValue()
                cmd.Parameters.Add("@StandWind", SqlDbType.VarChar, 8000).Value = dd_hurded_AR2.Text
                cmd.Parameters.Add("@StandPerLiab", SqlDbType.VarChar, 8000).Value = dd_pl_AR2.SelectedValue()
                cmd.Parameters.Add("@StandMHReplace", SqlDbType.VarChar, 8000).Value = dd_mhr_AR2.SelectedValue()
                cmd.Parameters.Add("@StandContReplace", SqlDbType.VarChar, 8000).Value = dd_rep_AR2.SelectedValue()
                cmd.Parameters.Add("@StandFullRepair", SqlDbType.VarChar, 8000).Value = dd_sip_AR2.SelectedValue()
                cmd.Parameters.Add("@StandAOPPrem", SqlDbType.VarChar, 8000).Value = dd_aop_AR2_Amount.Text
                cmd.Parameters.Add("@StandPersLiabPrem", SqlDbType.VarChar, 8000).Value = dd_pl_AR2_Amount.Text
                cmd.Parameters.Add("@StandMedPrem", SqlDbType.VarChar, 8000).Value = dd_med_AR2_amt.Text
                cmd.Parameters.Add("@StandStrucPrem", SqlDbType.VarChar, 8000).Value = txt_unattstr_AR2_Amount.Text
                cmd.Parameters.Add("@StandContPrem", SqlDbType.VarChar, 8000).Value = txt_pp_AR2_Amount.Text
                cmd.Parameters.Add("@StandMHReplacePrem", SqlDbType.VarChar, 8000).Value = dd_mhr_AR2_Amount.Text
                cmd.Parameters.Add("@StandContReplacePrem", SqlDbType.VarChar, 8000).Value = dd_rep_AR2_Amount.Text
                cmd.Parameters.Add("@StandFullRepairPrem", SqlDbType.VarChar, 8000).Value = dd_sip_AR2_Amount.Text
                cmd.Parameters.Add("@StandTax", SqlDbType.VarChar, 8000).Value = ar_tax2.Text
                cmd.Parameters.Add("@StandFees", SqlDbType.VarChar, 8000).Value = ar_fees2.Text
                cmd.Parameters.Add("@Standtotal", SqlDbType.VarChar, 8000).Value = ar_total2.Text
                cmd.Parameters.Add("@RentDwel", SqlDbType.VarChar, 8000).Value = ar_dwell3.Text
                cmd.Parameters.Add("@RentStruc", SqlDbType.VarChar, 8000).Value = ar_unattStr3.Text
                cmd.Parameters.Add("@RentCont", SqlDbType.VarChar, 8000).Value = ar_perEff3.Text
                cmd.Parameters.Add("@RentLiab", SqlDbType.VarChar, 8000).Value = ar_perLiab3.Text
                cmd.Parameters.Add("@RentMedPay", SqlDbType.VarChar, 8000).Value = ar_medpay3.Text
                cmd.Parameters.Add("@RentBasePrem", SqlDbType.VarChar, 8000).Value = ar_baseprem3.Text
                cmd.Parameters.Add("@RentAOP", SqlDbType.VarChar, 8000).Value = dd_aop_AR3.SelectedValue()
                cmd.Parameters.Add("@RentWind", SqlDbType.VarChar, 8000).Value = dd_hurded_AR3.Text
                cmd.Parameters.Add("@RentPerLiab", SqlDbType.VarChar, 8000).Value = dd_pl_AR3.SelectedValue()
                cmd.Parameters.Add("@RentMHReplace", SqlDbType.VarChar, 8000).Value = dd_mhr_AR3.SelectedValue()
                cmd.Parameters.Add("@RentContReplace", SqlDbType.VarChar, 8000).Value = dd_rep_AR3.SelectedValue()
                cmd.Parameters.Add("@RentFullRepair", SqlDbType.VarChar, 8000).Value = dd_sip_AR3.SelectedValue()
                cmd.Parameters.Add("@RentAOPPrem", SqlDbType.VarChar, 8000).Value = dd_aop_AR3_Amount.Text
                cmd.Parameters.Add("@RentPersLiabPrem", SqlDbType.VarChar, 8000).Value = dd_pl_AR3_Amount.Text
                cmd.Parameters.Add("@RentMedPrem", SqlDbType.VarChar, 8000).Value = dd_med_AR3_amt.Text
                cmd.Parameters.Add("@RentStrucPrem", SqlDbType.VarChar, 8000).Value = txt_unattstr_AR3_Amount.Text
                cmd.Parameters.Add("@RentContPrem", SqlDbType.VarChar, 8000).Value = txt_pp_AR3_Amount.Text
                cmd.Parameters.Add("@RentMHReplacePrem", SqlDbType.VarChar, 8000).Value = dd_mhr_AR3_Amount.Text
                cmd.Parameters.Add("@RentContReplacePrem", SqlDbType.VarChar, 8000).Value = dd_rep_AR3_Amount.Text
                cmd.Parameters.Add("@RentFullRepairPrem", SqlDbType.VarChar, 8000).Value = dd_sip_AR3_Amount.Text
                cmd.Parameters.Add("@RentTax", SqlDbType.VarChar, 8000).Value = ar_tax3.Text
                cmd.Parameters.Add("@RentFees", SqlDbType.VarChar, 8000).Value = ar_fees3.Text
                cmd.Parameters.Add("@Renttotal", SqlDbType.VarChar, 8000).Value = ar_total3.Text
                cmd.Parameters.Add("@VacantDwel", SqlDbType.VarChar, 8000).Value = value
                cmd.Parameters.Add("@VacantStruc", SqlDbType.VarChar, 8000).Value = value
                cmd.Parameters.Add("@VacantCont", SqlDbType.VarChar, 8000).Value = value
                cmd.Parameters.Add("@VacantLiab", SqlDbType.VarChar, 8000).Value = value
                cmd.Parameters.Add("@VacantMedPay", SqlDbType.VarChar, 8000).Value = value
                cmd.Parameters.Add("@VacantBasePrem", SqlDbType.VarChar, 8000).Value = value
                cmd.Parameters.Add("@VacantAOP", SqlDbType.VarChar, 8000).Value = value
                cmd.Parameters.Add("@VacantWind", SqlDbType.VarChar, 8000).Value = value
                cmd.Parameters.Add("@VacantPerLiab", SqlDbType.VarChar, 8000).Value = value
                cmd.Parameters.Add("@VacantMHReplace", SqlDbType.VarChar, 8000).Value = value
                cmd.Parameters.Add("@VacantContReplace", SqlDbType.VarChar, 8000).Value = value
                cmd.Parameters.Add("@VacantFullRepair", SqlDbType.VarChar, 8000).Value = value
                cmd.Parameters.Add("@VacantAOPPrem", SqlDbType.VarChar, 8000).Value = value
                cmd.Parameters.Add("@VacantPersLiabPrem", SqlDbType.VarChar, 8000).Value = value
                cmd.Parameters.Add("@VacantMedPrem", SqlDbType.VarChar, 8000).Value = value
                cmd.Parameters.Add("@VacantStrucPrem", SqlDbType.VarChar, 8000).Value = value
                cmd.Parameters.Add("@VacantContPrem", SqlDbType.VarChar, 8000).Value = value
                cmd.Parameters.Add("@VacantMHReplacePrem", SqlDbType.VarChar, 8000).Value = value
                cmd.Parameters.Add("@VacantContReplacePrem", SqlDbType.VarChar, 8000).Value = value
                cmd.Parameters.Add("@VacantFullRepairPrem", SqlDbType.VarChar, 8000).Value = value
                cmd.Parameters.Add("@VacantTax", SqlDbType.VarChar, 8000).Value = value
                cmd.Parameters.Add("@VacantFees", SqlDbType.VarChar, 8000).Value = value
                cmd.Parameters.Add("@Vacanttotal", SqlDbType.VarChar, 8000).Value = value
                cmd.Parameters.Add("@PackCreditPerc", SqlDbType.VarChar, 8000).Value = packperclbl.Text
                cmd.Parameters.Add("@PackCreditamt", SqlDbType.VarChar, 8000).Value = packcramtlbl.Text
                cmd.Parameters.Add("@StandCreditPerc", SqlDbType.VarChar, 8000).Value = standperclbl.Text
                cmd.Parameters.Add("@StandCreditamt", SqlDbType.VarChar, 8000).Value = standcramtlbl.Text
                cmd.Parameters.Add("@RentCreditPerc", SqlDbType.VarChar, 8000).Value = rentperclbl.Text
                cmd.Parameters.Add("@RentCreditamt", SqlDbType.VarChar, 8000).Value = rentcramtlbl.Text
                cmd.Parameters.Add("@VacantCreditPerc", SqlDbType.VarChar, 8000).Value = value
                cmd.Parameters.Add("@VacantCreditamt", SqlDbType.VarChar, 8000).Value = value
                cmd.Parameters.Add("@Packprem", SqlDbType.VarChar, 8000).Value = packpremlbl.Text
                cmd.Parameters.Add("@Standprem", SqlDbType.VarChar, 8000).Value = standpremlbl.Text
                cmd.Parameters.Add("@Rentprem", SqlDbType.VarChar, 8000).Value = rentpremlbl.Text
                cmd.Parameters.Add("@Vacantprem", SqlDbType.VarChar, 8000).Value = vacantpremlbl.Text
                cmd.Parameters.Add("@SMHPackDwel", SqlDbType.VarChar, 8000).Value = SC08_dwell.Text
                cmd.Parameters.Add("@SMHPackStruc", SqlDbType.VarChar, 8000).Value = SC08_unattStr.Text
                cmd.Parameters.Add("@SMHPackCont", SqlDbType.VarChar, 8000).Value = SC08_perEff.Text
                cmd.Parameters.Add("@SMHPackLiab", SqlDbType.VarChar, 8000).Value = SC08_perLiab.Text
                cmd.Parameters.Add("@SMHPackMedPay", SqlDbType.VarChar, 8000).Value = SC08_medpay.Text
                cmd.Parameters.Add("@SMHPackBasePrem", SqlDbType.VarChar, 8000).Value = SC08_baseprem.Text
                cmd.Parameters.Add("@SMHPackAOP", SqlDbType.VarChar, 8000).Value = dd_aop_08.SelectedValue()
                cmd.Parameters.Add("@SMHPackWind", SqlDbType.VarChar, 8000).Value = dd_hurded_08.Text
                cmd.Parameters.Add("@SMHPackPerLiab", SqlDbType.VarChar, 8000).Value = dd_pl_08.SelectedValue()
                cmd.Parameters.Add("@SMHPackMHReplace", SqlDbType.VarChar, 8000).Value = "" 'dd_mhr_08.SelectedValue()
                cmd.Parameters.Add("@SMHPackContReplace", SqlDbType.VarChar, 8000).Value = dd_rep_08.SelectedValue()
                cmd.Parameters.Add("@SMHPackFullRepair", SqlDbType.VarChar, 8000).Value = dd_sip_08.SelectedValue()
                cmd.Parameters.Add("@SMHPackAOPPrem", SqlDbType.VarChar, 8000).Value = dd_aop_08_Amount.Text
                cmd.Parameters.Add("@SMHPackPersLiabPrem", SqlDbType.VarChar, 8000).Value = dd_pl_08_Amount.Text
                cmd.Parameters.Add("@SMHPackMedPrem", SqlDbType.VarChar, 8000).Value = dd_med_08_amt.Text
                cmd.Parameters.Add("@SMHPackStrucPrem", SqlDbType.VarChar, 8000).Value = txt_unattstr_08_Amount.Text
                cmd.Parameters.Add("@SMHPackContPrem", SqlDbType.VarChar, 8000).Value = txt_pp_08_Amount.Text
                cmd.Parameters.Add("@SMHPackMHReplacePrem", SqlDbType.VarChar, 8000).Value = "" 'dd_mhr_08_Amount.Text
                cmd.Parameters.Add("@SMHPackContReplacePrem", SqlDbType.VarChar, 8000).Value = dd_rep_08_Amount.Text
                cmd.Parameters.Add("@SMHPackFullRepairPrem", SqlDbType.VarChar, 8000).Value = dd_sip_08_Amount.Text
                cmd.Parameters.Add("@SMHPackTax", SqlDbType.VarChar, 8000).Value = SC08_tax.Text
                cmd.Parameters.Add("@SMHPackFees", SqlDbType.VarChar, 8000).Value = SC08_fees.Text
                cmd.Parameters.Add("@SMHPacktotal", SqlDbType.VarChar, 8000).Value = SC08_total.Text
                cmd.Parameters.Add("@SMHPackCreditPerc", SqlDbType.VarChar, 8000).Value = SMHpackperclbl.Text
                cmd.Parameters.Add("@SMHPackCreditamt", SqlDbType.VarChar, 8000).Value = SMHpackcramtlbl.Text
                If IsNumeric(SMHpackpremlbl.Text) Then


                    If CInt(SMHpackpremlbl.Text) < 300 Then
                        cmd.Parameters.Add("@SMHPackprem", SqlDbType.VarChar, 8000).Value = "300"
                    Else
                        cmd.Parameters.Add("@SMHPackprem", SqlDbType.VarChar, 8000).Value = SMHpackpremlbl.Text
                    End If
                Else

                    cmd.Parameters.Add("@SMHPackprem", SqlDbType.VarChar, 8000).Value = "300"
                End If

                Try
                    Dim ds As Data.DataSet = New Data.DataSet

                    cmd.Connection.Open()
                    ' intRowsAff = cmd.ExecuteNonQuery()

                    Dim myCommand = New SqlDataAdapter(cmd)
                    myCommand.Fill(ds, "tbl1")
                Catch ex As Exception
                    Dim s As String = ""
                    For Each param As SqlParameter In cmd.Parameters
                        s += param.ParameterName & "="
                        s += param.Value & ":  "

                    Next
                    errortrap("Saving Lloyds Data " & s, "Save Prem", ex.Message)
                End Try



            End If


        End If
    End Sub
    Protected Sub Lloydcalc(ByVal ds As Data.DataSet)
        Dim packageprem As String
        Dim standardprem As String
        Dim rentalprem As String
        Dim Packas As String
        Dim standas As String
        Dim rentas As String
        Dim Packcon As String
        Dim Standcon As String
        Dim Rentcon As String

        Dim packtotal As Decimal
        Dim standtotal As Decimal
        Dim renttotal As Decimal

        Dim mfg As New List(Of String)
        mfg.Add(UCase("Brigadier"))
        mfg.Add(UCase("Brilliant"))
        mfg.Add(UCase("Commodore"))
        mfg.Add(UCase("Craftsman"))
        mfg.Add(UCase("Crestline"))
        mfg.Add(UCase("Fisher"))
        mfg.Add(UCase("Friendship"))
        mfg.Add(UCase("Gold Medal"))
        mfg.Add(UCase("Heartland"))
        mfg.Add(UCase("Homes of Merit"))
        mfg.Add(UCase("Horton Homes"))
        mfg.Add(UCase("Imperial"))
        mfg.Add(UCase("Mansion"))
        mfg.Add(UCase("Marshfield"))
        mfg.Add(UCase("Mascot"))
        mfg.Add(UCase("Masterpiece"))
        mfg.Add(UCase("Norris"))
        mfg.Add(UCase("Palm Harbor"))
        mfg.Add(UCase("R-Anell"))
        mfg.Add(UCase("Schult"))
        mfg.Add(UCase("Skyline"))
        mfg.Add(UCase("Southern Energy"))
        mfg.Add(UCase("Sterling"))
        mfg.Add(UCase("Titan"))
        mfg.Add(UCase("Virginia"))
        mfg.Add(UCase("Modular"))


        ar_dwell1.Text = "$" & mhvalue.Replace("$", "")
        ar_dwell2.Text = "$" & mhvalue.Replace("$", "")
        ar_dwell3.Text = "$" & mhvalue.Replace("$", "")
        ar_unattStr1.Text = "$" & txt_unattstr_AR1.Text.Replace("$", "")
        ar_unattStr2.Text = "$" & txt_unattstr_AR2.Text.Replace("$", "")
        ar_unattStr3.Text = "$" & txt_unattstr_AR3.Text.Replace("$", "")
        ar_perEff1.Text = "$" & txt_pp_AR1.Text.Replace("$", "")
        ar_perEff2.Text = "$" & txt_pp_AR2.Text.Replace("$", "")
        ar_perEff3.Text = "$" & txt_pp_AR3.Text.Replace("$", "")
        ar_perLiab1.Text = "$" & dd_pl_AR1.SelectedValue().Replace("$", "")
        ar_perLiab2.Text = "$" & dd_pl_AR2.SelectedValue().Replace("$", "")
        ar_perLiab3.Text = "$" & dd_pl_AR3.SelectedValue().Replace("$", "")
        ar_medpay1.Text = "$" & dd_mp_AR1.SelectedValue().Replace("$", "")
        ar_medpay2.Text = "$" & dd_mp_AR2.SelectedValue().Replace("$", "")
        ar_medpay3.Text = "$" & dd_mp_AR3.SelectedValue().Replace("$", "")

        If ar_unattStr3.Text = "$" Then
            ar_unattStr3.Text = "$0"
        End If
        If ar_perEff3.Text = "$" Then
            ar_perEff3.Text = "$0"
        End If
        If ar_perLiab3.Text = "$" Then
            ar_perLiab3.Text = "$0"
        End If
        If ar_medpay3.Text = "$" Then
            ar_medpay3.Text = "$0"
        End If

        If mhtype = "Doublewide" Or mhtype = "Modular" Then
            ar_baseprem1.Text = "$" & ds.Tables("tbl1").Rows(0).Item("PackRateDW").ToString().Replace("$", "")
            ar_baseprem2.Text = "$" & ds.Tables("tbl1").Rows(0).Item("StandarRateDW").ToString().Replace("$", "")

            txt_unattstr_AR1_Amount.Text = "$" & ds.Tables("tbl1").Rows(0).Item("PackASRateDW").ToString().Replace("$", "")
            txt_unattstr_AR2_Amount.Text = "$" & ds.Tables("tbl1").Rows(0).Item("StandASRateDW").ToString().Replace("$", "")
            txt_unattstr_AR3_Amount.Text = "$" & ds.Tables("tbl1").Rows(0).Item("RentASRateDW").ToString().Replace("$", "")
            txt_pp_AR1_Amount.Text = "$" & ds.Tables("tbl1").Rows(0).Item("PackPERateDW").ToString().Replace("$", "")
            txt_pp_AR2_Amount.Text = "$" & ds.Tables("tbl1").Rows(0).Item("StandPERateDW").ToString().Replace("$", "")
            txt_pp_AR3_Amount.Text = "$" & ds.Tables("tbl1").Rows(0).Item("RentPERateDW").ToString().Replace("$", "")

            packageprem = "$" & ds.Tables("tbl1").Rows(0).Item("PackRateDW").ToString().Replace("$", "")
            standardprem = "$" & ds.Tables("tbl1").Rows(0).Item("StandarRateDW").ToString().Replace("$", "")
            'rentalprem = ds.Tables("tbl1").Rows(0).Item("RentRateDW").ToString()
            Packas = ds.Tables("tbl1").Rows(0).Item("PackASRateDW").ToString()
            standas = ds.Tables("tbl1").Rows(0).Item("StandASRateDW").ToString()
            rentas = ds.Tables("tbl1").Rows(0).Item("RentASRateDW").ToString()
            Packcon = ds.Tables("tbl1").Rows(0).Item("PackPERateDW").ToString()
            Standcon = ds.Tables("tbl1").Rows(0).Item("StandPERateDW").ToString()
            Rentcon = ds.Tables("tbl1").Rows(0).Item("RentPERateDW").ToString()

        ElseIf mhtype = "Singlewide" Then
            ar_baseprem1.Text = "$" & ds.Tables("tbl1").Rows(0).Item("PackRateSW").ToString().Replace("$", "")
            ar_baseprem2.Text = "$" & ds.Tables("tbl1").Rows(0).Item("StandarRateSW").ToString().Replace("$", "")
            txt_unattstr_AR1_Amount.Text = "$" & ds.Tables("tbl1").Rows(0).Item("PackASRateSW").ToString().Replace("$", "")
            txt_unattstr_AR2_Amount.Text = "$" & ds.Tables("tbl1").Rows(0).Item("StandASRateSW").ToString().Replace("$", "")
            txt_unattstr_AR3_Amount.Text = "$" & ds.Tables("tbl1").Rows(0).Item("RentASRateSW").ToString().Replace("$", "")
            txt_pp_AR1_Amount.Text = "$" & ds.Tables("tbl1").Rows(0).Item("PackPERateSW").ToString().Replace("$", "")
            If txt_pp_AR1_Amount.Text = "$-0.001" Then
                txt_pp_AR1_Amount.Text = "$0"
            End If
            txt_pp_AR2_Amount.Text = "$" & ds.Tables("tbl1").Rows(0).Item("StandPERateSW").ToString().Replace("$", "")
            txt_pp_AR3_Amount.Text = "$" & ds.Tables("tbl1").Rows(0).Item("RentPERateSW").ToString().Replace("$", "")

            packageprem = ds.Tables("tbl1").Rows(0).Item("PackRateSW").ToString()
            standardprem = ds.Tables("tbl1").Rows(0).Item("StandarRateSW").ToString()
            'rentalprem = ds.Tables("tbl1").Rows(0).Item("RentRateSW").ToString()
            Packas = ds.Tables("tbl1").Rows(0).Item("PackASRateSW").ToString()
            standas = ds.Tables("tbl1").Rows(0).Item("StandASRateSW").ToString()
            rentas = ds.Tables("tbl1").Rows(0).Item("RentASRateSW").ToString()
            Packcon = ds.Tables("tbl1").Rows(0).Item("PackPERateSW").ToString()
            Standcon = ds.Tables("tbl1").Rows(0).Item("StandPERateSW").ToString()
            Rentcon = ds.Tables("tbl1").Rows(0).Item("RentPERateSW").ToString()
        End If
        ar_baseprem3.Text = "$" & ds.Tables("tbl1").Rows(0).Item("Rental").ToString().Replace("$", "")
        rentalprem = ds.Tables("tbl1").Rows(0).Item("Rental").ToString()

        'Med Pay Additions
        dd_med_AR1_amt.Text = "0.00"





        dd_mhr_AR1_Amount.Text = "$" & ds.Tables("tbl1").Rows(0).Item("PackMHRepRate").ToString()
        dd_mhr_AR2_Amount.Text = "$" & ds.Tables("tbl1").Rows(0).Item("StandMHRepRate").ToString()
        dd_mhr_AR3_Amount.Text = "$" & ds.Tables("tbl1").Rows(0).Item("RentMHRepRate").ToString()
        'dd_mhr_AR3_Amount.Text = ds.Tables("tbl1").Rows("PackLiabPerRate").ToString()
        dd_rep_AR1_Amount.Text = "$" & ds.Tables("tbl1").Rows(0).Item("PackContRepRate").ToString()
        dd_rep_AR2_Amount.Text = "$" & ds.Tables("tbl1").Rows(0).Item("StandContRepRate").ToString()
        dd_rep_AR3_Amount.Text = "$" & ds.Tables("tbl1").Rows(0).Item("RentContRepRate").ToString()
        'dd_rep_AR3_Amount.Text = ds.Tables("tbl1").Rows("RentContRepRate").ToString()





        dd_pl_AR1_Amount.Text = "$" & ds.Tables("tbl1").Rows(0).Item("PackLiabPerRate").ToString()
        dd_pl_AR2_Amount.Text = "$" & ds.Tables("tbl1").Rows(0).Item("StandLiabPerRate").ToString()
        dd_pl_AR3_Amount.Text = "$" & ds.Tables("tbl1").Rows(0).Item("RentLiabPerRate").ToString()
        dd_sip_AR1_Amount.Text = "$" & ds.Tables("tbl1").Rows(0).Item("PackFullRepRate").ToString()
        dd_sip_AR2_Amount.Text = "$" & ds.Tables("tbl1").Rows(0).Item("StandFullRepRate").ToString()
        dd_sip_AR3_Amount.Text = "$" & ds.Tables("tbl1").Rows(0).Item("RentFullRepRate").ToString()
        'dd_sip_AR3_Amount.Text = ds.Tables("tbl1").Rows("RentLiabPerRate").ToString()

        ar_fees1.Text = ds.Tables("tbl1").Rows(0).Item("PackFee").ToString()
        ar_fees2.Text = ds.Tables("tbl1").Rows(0).Item("StandFee").ToString()
        ar_fees3.Text = ds.Tables("tbl1").Rows(0).Item("RentFee").ToString()



        AR1_Debug.Text = ""
        AR2_Debug.Text = ""
        AR3_Debug.Text = ""
        AR1_Debug.Text = "<table> <tbody>"
        AR2_Debug.Text = "<table> <tbody>"
        AR3_Debug.Text = "<table> <tbody>"

        'Package 
        Dim packfee As Integer
        Dim packopt As Integer

        'wind and hail
        If mhstatelbl.Text = "TN" Then
            dd_hurded_AR1.Text = "$500"
        Else
            dd_hurded_AR1.Text = "$" & ds.Tables("tbl1").Rows(0).Item("Tstorm").ToString()
            dd_hurded_AR2.Text = "$" & ds.Tables("tbl1").Rows(0).Item("Tstorm").ToString
            dd_thur_Ar2.Text = "$" & ds.Tables("tbl1").Rows(0).Item("Tstorm").ToString
        End If
        'dd_hurded_AR1.Text = "$" & ds.Tables("tbl1").Rows(0).Item("Tstorm").ToString()
        'troupical storm
        dd_thur_ar1.Text = "$" & ds.Tables("tbl1").Rows(0).Item("Tstorm").ToString()
        'loss of use" " & _
        If IsNumeric(dd_hurded_AR1.Text.Replace("$", "")) And IsNumeric(dd_aop_AR1.SelectedValue.Replace("$", "")) Then
            If CInt(dd_hurded_AR1.Text.Replace("$", "")) < CInt(dd_aop_AR1.SelectedValue.Replace("$", "")) Then
                dd_hurded_AR1.Text = dd_aop_AR1.SelectedValue.Replace("$", "")
            End If
        End If

        If IsNumeric(dd_thur_ar1.Text.Replace("$", "")) And IsNumeric(dd_aop_AR1.SelectedValue.Replace("$", "")) Then
            If CInt(dd_thur_ar1.Text.Replace("$", "")) < CInt(dd_aop_AR1.SelectedValue.Replace("$", "")) Then
                dd_thur_ar1.Text = dd_aop_AR1.SelectedValue.Replace("$", "")
            End If
        End If


        txtlossofuse.Text = "$600"

        AR1_Debug.Text += "<tr align=left><td>Package Premium </td><td> $" & CInt(packageprem) & " </td></tr> "
        packpremlbl.Text = CInt(packageprem)
        AR1_Debug.Text += "<tr align=left><td>Other Structures </td><td> $" & CInt("0") & " </td></tr> "
        AR1_Debug.Text += "<tr align=left><td>Contents </td><td> $" & CInt("0") & " </td></tr> "
        AR1_Debug.Text += "<tr align=left><td>Addl Living Expense</td><td> $" & CInt("0") & " </td></tr> "
        packtotal = CInt(packageprem) '+ CInt(Packas) + CInt(Packcon) + CInt("0")
        AR1_Debug.Text += "<tr align=left><td>Sub Premium</td><td> $" & CInt(packtotal) & " </td></tr> "
        Dim CreditsPercentage As Decimal
        'Add credit stuff to label
        CreditsPercentage = 0

        If Date.Now.Year - mhyearlbl.Text <= 15 Then
            CreditsPercentage += 0.1
        End If
        For Each s As String In mfg
            If UCase(s) = UCase(mhmfglbl.Text) Then
                CreditsPercentage += 0.1
            End If
        Next
        If mhstatelbl.Text = "TN" Then
            CreditsPercentage = 0
        End If

        packperclbl.Text = CreditsPercentage
        packcramtlbl.Text = Math.Round((packtotal * CreditsPercentage), 0, MidpointRounding.AwayFromZero)

        AR1_Debug.Text += "<tr align=left><td> Credits %</td><td> " & CreditsPercentage * 100 & "% </td></tr> "
        AR1_Debug.Text += "<tr align=left><td> Credits Value</td><td>-" & Math.Round((packtotal * CreditsPercentage), 0, MidpointRounding.AwayFromZero) & " </td></tr> "
        packtotal -= Math.Round((packtotal * CreditsPercentage), 0, MidpointRounding.AwayFromZero)
        AR1_Debug.Text += "<tr align=left><td>Base Premium</td><td> $" & CInt(packtotal) & " </td></tr> "
        ar_baseprem1.Text = "$" & CInt(packtotal)
        'If dd_aop_AR1.SelectedValue <> "$500" Then
        '    AR1_Debug.Text += "<tr align=left><td>AOP/td><td> $ -75 </td></tr> "
        '    packtotal -= 75
        'End If

        If dd_aop_AR1.SelectedValue = "$500" Then
            dd_aop_AR1_Amount.Text = "$0"
            AR1_Debug.Text += "<tr align=left><td>AOP</td><td> $ 0 </td></tr> "
            packtotal -= 0
            packopt -= 0
        Else
            dd_aop_AR1_Amount.Text = "($75)"
            AR1_Debug.Text += "<tr align=left><td>AOP</td><td> $ -75 </td></tr> "
            packtotal -= 75
            packopt -= 75
            'dd_hurded_AR1.Text = "$1000"
            'dd_thur_ar1.Text = "$1000"
        End If
        If CInt(packtotal) < 300 Then
            packtotal = 300
            ar_baseprem1.Text = "$" & CInt(packtotal)
        End If
        AR1_Debug.Text += "<tr align=left><td>SUB TOTAL 2</td><td> $" & CInt(packtotal) & " </td></tr> "
        If ds.Tables("tbl1").Rows(0).Item("PackLiabPerRate").ToString() = "" Then
            AR1_Debug.Text += "<tr align=left><td>Personal Liability</td><td> $0.00 </td></tr> "
            packtotal += 0
            packopt += 0
        Else
            AR1_Debug.Text += "<tr align=left><td>Personal Liability</td><td> $" & CInt(ds.Tables("tbl1").Rows(0).Item("PackLiabPerRate").ToString()) & " </td></tr> "
            packtotal += CInt(ds.Tables("tbl1").Rows(0).Item("PackLiabPerRate").ToString())
            packopt += CInt(ds.Tables("tbl1").Rows(0).Item("PackLiabPerRate").ToString())
        End If


        Dim packAop As Integer
        If ar_medpay1.Text = "$1000" Then
            AR1_Debug.Text += "<tr align=left><td>Medical Payment</td><td> $ 6  </td></tr> "
            packtotal += 6
            packAop += 6
            packopt += 6
            dd_med_AR1_amt.Text = "$6"
        Else
            AR1_Debug.Text += "<tr align=left><td>Medical Payment</td><td> $ 0  </td></tr> "
            dd_med_AR1_amt.Text = "$0"
            packAop += 0
        End If
        AR1_Debug.Text += "<tr align=left><td>SUB TOTAL 3</td><td> $" & CInt(packtotal) & " </td></tr> "

        AR1_Debug.Text += "<tr align=left><td>Contents Replacement</td><td> $" & CInt(ds.Tables("tbl1").Rows(0).Item("PackContRepRate").ToString()) & " </td></tr> "
        AR1_Debug.Text += "<tr align=left><td>Full Repair</td><td> $" & CInt(ds.Tables("tbl1").Rows(0).Item("PackFullRepRate").ToString()) & " </td></tr> "
        AR1_Debug.Text += "<tr align=left><td>MH Replacement Cost</td><td> $" & CInt(ds.Tables("tbl1").Rows(0).Item("PackMHRepRate").ToString()) & " </td></tr> "
        If CInt(Packas) > 0 Then
            AR1_Debug.Text += "<tr align=left><td>Increased Other Structures </td><td> $" & CInt(Packas) & " </td></tr> "
            packtotal += CInt(Packas)
            packopt += CInt(Packas)
        End If
        If CInt(Packcon) > 0 Then
            AR1_Debug.Text += "<tr align=left><td>Increased Contents </td><td> $" & CInt(Packcon) & " </td></tr> "
            packtotal += CInt(Packcon)
            packopt += CInt(Packcon)
        End If

        packtotal += CInt(ds.Tables("tbl1").Rows(0).Item("PackContRepRate").ToString())
        packtotal += CInt(ds.Tables("tbl1").Rows(0).Item("PackFullRepRate").ToString())
        packtotal += CInt(ds.Tables("tbl1").Rows(0).Item("PackMHRepRate").ToString())


        packopt += CInt(ds.Tables("tbl1").Rows(0).Item("PackContRepRate").ToString())
        packopt += CInt(ds.Tables("tbl1").Rows(0).Item("PackFullRepRate").ToString())
        packopt += CInt(ds.Tables("tbl1").Rows(0).Item("PackMHRepRate").ToString())
        ar_options1.Text = "$" & CInt(packopt)
        If mhstatelbl.Text = "NC" Then
            If mhusagelbl.Text = "Seasonal" Then

                AR1_Debug.Text += "<tr align=left><td>Seasonal Surcharge</td><td> $ 20 </td></tr> "
                packtotal += 20
                packfee += 20
            End If
            ' packfee += CInt(ds.Tables("tbl1").Rows(0).Item("PackFee").ToString())

            AR1_Debug.Text += "<tr align=left><td>SUB TOTAL 4</td><td> $" & CInt(packtotal) & " </td></tr> "
            'taxes
            AR1_Debug.Text += "<tr align=left><td>Taxes</td><td> " & CDbl(CInt(packtotal) * CDec(ds.Tables("tbl1").Rows(0).Item("taxamt").ToString())).ToString("C2") & " </td></tr> "
            ar_tax1.Text = "" & CDbl(CInt(packtotal) * CDec(ds.Tables("tbl1").Rows(0).Item("taxamt").ToString())).ToString("C2")
            packtotal += CInt(packtotal) * CDec(ds.Tables("tbl1").Rows(0).Item("taxamt").ToString())

            AR1_Debug.Text += "<tr align=left><td>Policy Fee</td><td> $" & CInt(ds.Tables("tbl1").Rows(0).Item("PackFee").ToString()) & " </td></tr> "
            packtotal += CInt(ds.Tables("tbl1").Rows(0).Item("PackFee").ToString())
            packfee += CInt(ds.Tables("tbl1").Rows(0).Item("PackFee").ToString())
            ar_fees1.Text = "$" & CInt(packfee)
            AR1_Debug.Text += "<tr align=left><td>SUB TOTAL 5</td><td> " & packtotal.ToString("C2") & " </td></tr> "
            'taxes:




            AR1_Debug.Text += "<tr align=left><td>Total Prem</td><td> " & CDbl(packtotal).ToString("C2") & " </td></tr> "




        Else

            AR1_Debug.Text += "<tr align=left><td>SUB TOTAL 4</td><td> $" & CInt(packtotal) & " </td></tr> "

            AR1_Debug.Text += "<tr align=left><td>Policy Fee</td><td> $" & CInt(ds.Tables("tbl1").Rows(0).Item("PackFee").ToString()) & " </td></tr> "
            packtotal += CInt(ds.Tables("tbl1").Rows(0).Item("PackFee").ToString())
            packfee += CInt(ds.Tables("tbl1").Rows(0).Item("PackFee").ToString())
            If mhusagelbl.Text = "Seasonal" Then

                AR1_Debug.Text += "<tr align=left><td>Seasonal Surcharge</td><td> $ 20 </td></tr> "
                packtotal += 20
                packfee += 20
            End If
            ar_fees1.Text = "$" & CInt(packfee)
            AR1_Debug.Text += "<tr align=left><td>SUB TOTAL 5</td><td> $" & packtotal & " </td></tr> "
            'taxes:
            AR1_Debug.Text += "<tr align=left><td>Taxes</td><td> " & CDbl(CInt(packtotal) * CDec(ds.Tables("tbl1").Rows(0).Item("taxamt").ToString())).ToString("C2") & " </td></tr> "
            ar_tax1.Text = "" & CDbl(CInt(packtotal) * CDec(ds.Tables("tbl1").Rows(0).Item("taxamt").ToString())).ToString("C2")
            packtotal += CInt(packtotal) * CDec(ds.Tables("tbl1").Rows(0).Item("taxamt").ToString())

            If packtotal < 300 Then

                AR1_Debug.Text += "<tr align=left><td>Total Prem (Min)</td><td> " & CDbl(300).ToString("C2") & " </td></tr> "

            Else
                AR1_Debug.Text += "<tr align=left><td>Total Prem</td><td> " & CDbl(packtotal).ToString("C2") & " </td></tr> "

            End If





        End If






        'Standard 
        Dim standopt As Integer
        Dim standfee As Integer


        AR2_Debug.Text += "<tr align=left><td>Stand Premium </td><td> $" & CInt(standardprem) & " </td></tr> "
        standpremlbl.Text = CInt(standardprem)
        AR2_Debug.Text += "<tr align=left><td>Other Structures </td><td> $" & CInt(standas) & " </td></tr> "
        AR2_Debug.Text += "<tr align=left><td>Contents </td><td> $" & CInt(Standcon) & " </td></tr> "
        AR2_Debug.Text += "<tr align=left><td>Addl Living Expense</td><td> $" & CInt("0") & " </td></tr> "
        standtotal = CInt(standardprem) + CInt(standas) + CInt(Standcon) + CInt("0")
        AR2_Debug.Text += "<tr align=left><td>Sub Premium</td><td> $" & CInt(standtotal) & " </td></tr> "


        If mhstatelbl.Text = "DE" Then
            If Date.Now.Year - mhyearlbl.Text > 10 Then
                dd_mhr_AR1.Enabled = False
                dd_mhr_AR1.SelectedValue = "No"
                dd_mhr_AR2.Enabled = False
                dd_mhr_AR2.SelectedValue = "No"
                dd_mhr_AR3.Enabled = False
                dd_mhr_AR3.SelectedValue = "No"
            Else
                dd_mhr_AR1.Enabled = True
                dd_mhr_AR2.Enabled = True
                dd_mhr_AR3.Enabled = True
            End If
            If mhdistlbl.Text = "Less than 0.5 miles" Or mhdistlbl.Text = "0.5 – 5 miles" Then
                dd_hurded_AR2.Text = "$1500"
            Else
                dd_hurded_AR2.Text = "$1000"

            End If
        Else
            If mhdistlbl.Text = "Less than 0.5 miles" Or mhdistlbl.Text = "0.5 – 5 miles" Then
                dd_hurded_AR3.Text = "$1500"
            Else
                dd_hurded_AR3.Text = "$1000"

            End If
            If Date.Now.Year - mhyearlbl.Text >= 10 Then
                dd_mhr_AR1.Enabled = False
                dd_mhr_AR1.SelectedValue = "No"
                dd_mhr_AR2.Enabled = False
                dd_mhr_AR2.SelectedValue = "No"
                dd_mhr_AR3.Enabled = False
                dd_mhr_AR3.SelectedValue = "No"
            Else
                dd_mhr_AR1.Enabled = True
                dd_mhr_AR2.Enabled = True
                dd_mhr_AR3.Enabled = True
            End If
        End If
        'credits 
        CreditsPercentage = 0.0
        If Date.Now.Year - mhyearlbl.Text < 15 Then
            CreditsPercentage += 0.1
        End If
        For Each s As String In mfg
            If UCase(s) = UCase(mhmfglbl.Text) Then
                CreditsPercentage += 0.1
            End If
        Next
        If mhstatelbl.Text = "DE" Then
            If CreditsPercentage >= 0.2 Then
                CreditsPercentage = 0.15
            End If
        End If
        standperclbl.Text = CreditsPercentage

        'If Date.Now.Year - mhyearlbl.Text > 15 Then
        '    dd_mhr_AR1.Enabled = False
        '    dd_mhr_AR2.Enabled = False
        '    dd_mhr_AR3.Enabled = False
        'Else
        '    dd_mhr_AR1.Enabled = True
        '    dd_mhr_AR2.Enabled = True
        '    dd_mhr_AR3.Enabled = True
        'End If
        standcramtlbl.Text = Math.Round((standtotal * CreditsPercentage), 0, MidpointRounding.AwayFromZero)
        AR2_Debug.Text += "<tr align=left><td> Credits %</td><td> " & CreditsPercentage * 100 & "% </td></tr> "
        AR2_Debug.Text += "<tr align=left><td> Credits Value</td><td>-" & Math.Round((standtotal * CreditsPercentage), 0, MidpointRounding.AwayFromZero) & " </td></tr> "
        standtotal -= Math.Round((standtotal * CreditsPercentage), 0, MidpointRounding.AwayFromZero)
        AR2_Debug.Text += "<tr align=left><td>Base Premium</td><td> $" & CInt(standtotal) & " </td></tr> "
        ar_baseprem2.Text = "$" & CInt(standtotal)
        If dd_aop_AR2.SelectedValue <> "$500" Then
            dd_aop_AR2_Amount.Text = "($75)"
            AR2_Debug.Text += "<tr align=left><td>AOP</td><td> $ -75 </td></tr> "
            standtotal -= 75
            standopt -= 75
        Else
            dd_aop_AR2_Amount.Text = "$0"
            AR2_Debug.Text += "<tr align=left><td>AOP</td><td> $ 0.00 </td></tr> "
            standtotal -= 0
            standopt -= 0
        End If

        AR2_Debug.Text += "<tr align=left><td>SUB TOTAL 2</td><td> $" & CInt(standtotal) & " </td></tr> "
        AR2_Debug.Text += "<tr align=left><td>Personal Liability</td><td> $" & CInt(ds.Tables("tbl1").Rows(0).Item("StandLiabPerRate").ToString()) & " </td></tr> "
        standtotal += CInt(ds.Tables("tbl1").Rows(0).Item("StandLiabPerRate").ToString())
        standopt += CInt(ds.Tables("tbl1").Rows(0).Item("StandLiabPerRate").ToString())
        Dim StandAop As Integer

        If dd_mp_AR2.Text <> "$500" And dd_mp_AR2.Text <> "$0" Then
            AR2_Debug.Text += "<tr align=left><td>Medical Payment</td><td> $ 6 </td></tr> "
            dd_med_AR2_amt.Text = "$6"
            standtotal += 6
            StandAop += 6
            standopt += 6
        Else
            dd_med_AR2_amt.Text = "$0"
            AR2_Debug.Text += "<tr align=left><td>Medical Payment</td><td> $ 0  </td></tr> "
            StandAop += 0
        End If
        AR2_Debug.Text += "<tr align=left><td>SUB TOTAL 3</td><td> $" & CInt(standtotal) & " </td></tr> "

        AR2_Debug.Text += "<tr align=left><td>Contents Replacement</td><td> $" & CInt(ds.Tables("tbl1").Rows(0).Item("StandContRepRate").ToString()) & " </td></tr> "
        AR2_Debug.Text += "<tr align=left><td>Full Repair</td><td> $" & CInt(ds.Tables("tbl1").Rows(0).Item("StandFullRepRate").ToString()) & " </td></tr> "
        AR2_Debug.Text += "<tr align=left><td>MH Replacemtne Cost</td><td> $" & CInt(ds.Tables("tbl1").Rows(0).Item("StandMHRepRate").ToString()) & " </td></tr> "
        standtotal += CInt(ds.Tables("tbl1").Rows(0).Item("StandContRepRate").ToString())
        standtotal += CInt(ds.Tables("tbl1").Rows(0).Item("StandFullRepRate").ToString())
        standtotal += CInt(ds.Tables("tbl1").Rows(0).Item("StandMHRepRate").ToString())
        standopt += CInt(ds.Tables("tbl1").Rows(0).Item("StandContRepRate").ToString())
        standopt += CInt(ds.Tables("tbl1").Rows(0).Item("StandFullRepRate").ToString())
        standopt += CInt(ds.Tables("tbl1").Rows(0).Item("StandMHRepRate").ToString())
        ar_options2.Text = "$" & CInt(standopt)
        AR2_Debug.Text += "<tr align=left><td>SUB TOTAL 4</td><td> $" & CInt(standtotal) & " </td></tr> "

        AR2_Debug.Text += "<tr align=left><td>Policy Fee</td><td> $" & CInt(ds.Tables("tbl1").Rows(0).Item("StandFee").ToString()) & " </td></tr> "
        standtotal += CInt(ds.Tables("tbl1").Rows(0).Item("StandFee").ToString())
        standfee += CInt(ds.Tables("tbl1").Rows(0).Item("StandFee").ToString())
        If mhusagelbl.Text = "Seasonal" Then

            AR2_Debug.Text += "<tr align=left><td>Seasonal Surcharge</td><td> $ 20 </td></tr> "
            standtotal += 20
            standfee += 20
        End If
        ar_fees2.Text = "$" & CInt(standfee)
        AR2_Debug.Text += "<tr align=left><td>SUB TOTAL 5</td><td> $" & standtotal & " </td></tr> "
        'taxes:
        AR2_Debug.Text += "<tr align=left><td>Taxes</td><td> $" & CDbl(CInt(standtotal) * CDec(ds.Tables("tbl1").Rows(0).Item("taxamt").ToString())) & " </td></tr> "
        ar_tax2.Text = "$" & CDbl(CInt(standtotal) * CDec(ds.Tables("tbl1").Rows(0).Item("taxamt").ToString()))
        standtotal += CInt(standtotal) * CDec(ds.Tables("tbl1").Rows(0).Item("taxamt").ToString())

        AR2_Debug.Text += "<tr align=left><td>Total Prem</td><td> $" & standtotal & " </td></tr> "
        'ar_options2.Text = CInt(CInt(standas) + CInt(Standcon) + CInt(Standaop) + CInt(ds.Tables("tbl1").Rows(0).Item("StandLiabPerRate").ToString()) + CInt(ds.Tables("tbl1").Rows(0).Item("StandContRepRate").ToString()) + CInt(ds.Tables("tbl1").Rows(0).Item("StandFullRepRate").ToString()) + CInt(ds.Tables("tbl1").Rows(0).Item("StandMHRepRate").ToString()))

        'Rent 
        Dim rentopt As Integer
        Dim rentfee As Integer

        dd_hurded_AR3.Text = ds.Tables("tbl1").Rows(0).Item("Tstorm").ToString()
        'troupical storm
        dd_thur_ar3.Text = ds.Tables("tbl1").Rows(0).Item("Tstorm").ToString()

        AR3_Debug.Text += "<tr align=left><td>Rent Premium </td><td> $" & CInt(rentalprem) & " </td></tr> "
        rentpremlbl.Text = CInt(rentalprem)
        AR3_Debug.Text += "<tr align=left><td>Other Structures </td><td> $" & CInt(rentas) & " </td></tr> "
        AR3_Debug.Text += "<tr align=left><td>Contents </td><td> $" & CInt(Rentcon) & " </td></tr> "
        AR3_Debug.Text += "<tr align=left><td>Addl Living Expense</td><td> $" & CInt("0") & " </td></tr> "
        renttotal = CInt(rentalprem) + CInt(rentas) + CInt(Rentcon) + CInt("0")
        AR3_Debug.Text += "<tr align=left><td>Sub Premium</td><td> $" & CInt(renttotal) & " </td></tr> "
        If mhstatelbl.Text = "DE" Then
            If mhdistlbl.Text = "Less than 0.5 miles" Or mhdistlbl.Text = "0.5 – 5 miles" Then
                dd_hurded_AR3.Text = "$1500"
            Else
                dd_hurded_AR3.Text = "$1000"

            End If
        ElseIf mhstatelbl.Text = "SC" Then
            dd_hurded_AR3.Text = "$" & ds.Tables("tbl1").Rows(0).Item("Tstorm").ToString()
            'troupical storm
            dd_thur_ar3.Text = "$" & ds.Tables("tbl1").Rows(0).Item("Tstorm").ToString()

        ElseIf mhstatelbl.Text = "NC" Then
        Else


            If mhdistlbl.Text = "Less than 0.5 miles" Or mhdistlbl.Text = "0.5 – 5 miles" Then
                dd_hurded_AR3.Text = "$1500"
            Else
                dd_hurded_AR3.Text = "$1000"

            End If
        End If

        CreditsPercentage = 0.0
        If Date.Now.Year - mhyearlbl.Text < 15 Then
            CreditsPercentage += 0.1
        End If
        For Each s As String In mfg
            If UCase(s) = UCase(mhmfglbl.Text) Then
                CreditsPercentage += 0.1
            End If
        Next
        If mhstatelbl.Text = "DE" Then
            If CreditsPercentage >= 0.2 Then
                CreditsPercentage = 0.15
            End If
        End If
        If mhstatelbl.Text = "TN" Then
            CreditsPercentage = 0
        End If
        rentperclbl.Text = CreditsPercentage
        'If Date.Now.Year - mhyearlbl.Text > 10 Then
        '    dd_mhr_AR1.Enabled = False
        '    dd_mhr_AR2.Enabled = False
        '    dd_mhr_AR3.Enabled = False
        'Else
        '    dd_mhr_AR1.Enabled = True
        '    dd_mhr_AR2.Enabled = True
        '    dd_mhr_AR3.Enabled = True
        'End If
        'rentcramtlbl.Text = Math.Round((renttotal * CreditsPercentage), 0, MidpointRounding.AwayFromZero)
        'AR3_Debug.Text += "<tr align=left><td> Credits %</td><td> " & CreditsPercentage * 100 & "% </td></tr> "
        'AR3_Debug.Text += "<tr align=left><td> Credits Value</td><td>-" & Math.Round((renttotal * CreditsPercentage), 0, MidpointRounding.AwayFromZero) & " </td></tr> "
        'renttotal -= Math.Round((renttotal * CreditsPercentage), 0, MidpointRounding.AwayFromZero)
        AR3_Debug.Text += "<tr align=left><td>Base Premium</td><td> $" & CInt(renttotal) & " </td></tr> "
        ar_baseprem3.Text = "$" & CInt(renttotal)
        If dd_aop_AR3.SelectedValue <> "$500" And dd_aop_AR3.SelectedValue <> "" Then
            dd_aop_AR3_Amount.Text = "($75)"
            AR3_Debug.Text += "<tr align=left><td>AOP</td><td> $ -75 </td></tr> "
            renttotal -= 75
            rentopt -= 75
        End If

        AR3_Debug.Text += "<tr align=left><td>SUB TOTAL 2</td><td> $" & CInt(renttotal) & " </td></tr> "
        AR3_Debug.Text += "<tr align=left><td>Personal Liability</td><td> $" & CInt(ds.Tables("tbl1").Rows(0).Item("rentLiabPerRate").ToString()) & " </td></tr> "
        renttotal += CInt(ds.Tables("tbl1").Rows(0).Item("rentLiabPerRate").ToString())
        rentopt += CInt(ds.Tables("tbl1").Rows(0).Item("rentLiabPerRate").ToString())
        Dim rentAop As Integer

        'If dd_mp_AR3.Text <> "$500" And dd_mp_AR3.Text <> "" Then
        '    AR3_Debug.Text += "<tr align=left><td>Medical Payment</td><td> $ 6  </td></tr> "
        '    renttotal += 6
        '    rentAop += 6
        '    rentopt += 6
        'Else
        '    AR3_Debug.Text += "<tr align=left><td>Medical Payment</td><td> $ 0  </td></tr> "
        '    rentAop += 0
        'End If
        AR3_Debug.Text += "<tr align=left><td>SUB TOTAL 3</td><td> $" & CInt(renttotal) & " </td></tr> "

        AR3_Debug.Text += "<tr align=left><td>Contents Replacement</td><td> $" & CInt(ds.Tables("tbl1").Rows(0).Item("rentContRepRate").ToString()) & " </td></tr> "
        AR3_Debug.Text += "<tr align=left><td>Full Repair</td><td> $" & CInt(ds.Tables("tbl1").Rows(0).Item("rentFullRepRate").ToString()) & " </td></tr> "
        AR3_Debug.Text += "<tr align=left><td>MH Replacement Cost</td><td> $" & CInt(ds.Tables("tbl1").Rows(0).Item("rentMHRepRate").ToString()) & " </td></tr> "
        renttotal += CInt(ds.Tables("tbl1").Rows(0).Item("rentContRepRate").ToString())
        renttotal += CInt(ds.Tables("tbl1").Rows(0).Item("rentFullRepRate").ToString())
        renttotal += CInt(ds.Tables("tbl1").Rows(0).Item("rentMHRepRate").ToString())
        rentopt += CInt(ds.Tables("tbl1").Rows(0).Item("rentContRepRate").ToString())
        rentopt += CInt(ds.Tables("tbl1").Rows(0).Item("rentFullRepRate").ToString())
        rentopt += CInt(ds.Tables("tbl1").Rows(0).Item("rentMHRepRate").ToString())
        ar_options3.Text = "$" & CInt(rentopt)
        AR3_Debug.Text += "<tr align=left><td>SUB TOTAL 4</td><td> $" & CInt(renttotal) & " </td></tr> "


        If mhstatelbl.Text = "NC" Then
            'taxes:
            AR3_Debug.Text += "<tr align=left><td>Taxes</td><td> " & CDbl(CInt(renttotal) * CDec(ds.Tables("tbl1").Rows(0).Item("taxamt").ToString())).ToString("C2") & " </td></tr> "
            ar_tax3.Text = "" & CDbl((renttotal) * CDec(ds.Tables("tbl1").Rows(0).Item("taxamt").ToString())).ToString("C2")
            renttotal += CInt(renttotal) * CDec(ds.Tables("tbl1").Rows(0).Item("taxamt").ToString())

            AR3_Debug.Text += "<tr align=left><td>Policy Fee</td><td> $" & CInt(ds.Tables("tbl1").Rows(0).Item("rentFee").ToString()) & " </td></tr> "
            renttotal += CInt(ds.Tables("tbl1").Rows(0).Item("rentFee").ToString())
            rentfee += CInt(ds.Tables("tbl1").Rows(0).Item("rentFee").ToString())
            If mhusagelbl.Text = "Seasonal" Then

                AR3_Debug.Text += "<tr align=left><td>Policy Fee</td><td> $ 20 </td></tr> "
                renttotal += 20
                rentfee += 20
            End If
            ar_fees3.Text = "$" & CInt(rentfee)
            AR3_Debug.Text += "<tr align=left><td>SUB TOTAL 5</td><td> " & renttotal.ToString("C2") & " </td></tr> "

            AR3_Debug.Text += "<tr align=left><td>Total Prem</td><td> " & renttotal.ToString("C2") & " </td></tr> "

        Else

            AR3_Debug.Text += "<tr align=left><td>Policy Fee</td><td> $" & CInt(ds.Tables("tbl1").Rows(0).Item("rentFee").ToString()) & " </td></tr> "
            renttotal += CInt(ds.Tables("tbl1").Rows(0).Item("rentFee").ToString())
            rentfee += CInt(ds.Tables("tbl1").Rows(0).Item("rentFee").ToString())
            If mhusagelbl.Text = "Seasonal" Then

                AR3_Debug.Text += "<tr align=left><td>Policy Fee</td><td> $ 20 </td></tr> "
                renttotal += 20
                rentfee += 20
            End If
            ar_fees3.Text = "$" & CInt(rentfee)
            AR3_Debug.Text += "<tr align=left><td>SUB TOTAL 5</td><td> $" & renttotal & " </td></tr> "
            'taxes:
            AR3_Debug.Text += "<tr align=left><td>Taxes</td><td> " & CDbl(CInt(renttotal) * CDec(ds.Tables("tbl1").Rows(0).Item("taxamt").ToString())).ToString("C2") & " </td></tr> "
            ar_tax3.Text = "" & CDbl((renttotal) * CDec(ds.Tables("tbl1").Rows(0).Item("taxamt").ToString())).ToString("C2")
            renttotal += CInt(renttotal) * CDec(ds.Tables("tbl1").Rows(0).Item("taxamt").ToString())

            AR3_Debug.Text += "<tr align=left><td>Total Prem</td><td> " & renttotal.ToString("C2") & " </td></tr> "
        End If


        'ar_options2.Text = CInt(CInt(rentas) + CInt(rentcon) + CInt(rentaop) + CInt(ds.Tables("tbl1").Rows(0).Item("rentLiabPerRate").ToString()) + CInt(ds.Tables("tbl1").Rows(0).Item("rentContRepRate").ToString()) + CInt(ds.Tables("tbl1").Rows(0).Item("rentFullRepRate").ToString()) + CInt(ds.Tables("tbl1").Rows(0).Item("rentMHRepRate").ToString()))





        AR1_Debug.Text += "</tbody></table>"
        AR2_Debug.Text += "</tbody></table>"
        AR3_Debug.Text += "</tbody></table>"




        ar_total1.Text = String.Format("{0:C}", CInt(ar_baseprem1.Text) + CInt(ar_options1.Text) + CDbl(ar_fees1.Text) + CDbl(ar_tax1.Text))
        If CInt(ar_total1.Text) < 300 Then
            ar_total1.Text = packtotal.ToString("C2")

        End If
        ar_total2.Text = String.Format("{0:C}", CInt(ar_baseprem2.Text) + CInt(ar_options2.Text) + CDbl(ar_fees2.Text) + CDbl(ar_tax2.Text))
        ar_total3.Text = String.Format("{0:C}", CInt(ar_baseprem3.Text) + CInt(ar_options3.Text) + CDbl(ar_fees3.Text) + CDbl(ar_tax3.Text))
        AR_PremiumUpdatePanel.Update()

    End Sub
    Public Sub ar_premiumbtnClick(ByVal sender As Object, ByVal e As System.EventArgs) Handles ar1_updateOptions.Click
        AR1_Debug.Text = ""
        AR2_Debug.Text = ""
        AR3_Debug.Text = ""

        Calc()
        Me.AR_PremiumUpdatePanel.Update()
        'If dd_PackagePerProp_AR1.SelectedValue = "No" Then
        '    packagePerPropValue.Text = "0.00"
        '    dd_PackagePerProp_AR1_Amount.Text = "0.00"
        'End If
        'calcAR()

        ''Set Visiblity on hidden fields
        'ARSetFields()
        'showARSections()
        'AR_PremiumUpdatePanel.Update()
        ''Dim lbl As New Label()
        ''lbl.Text = "<script language='javascript'>  ARCalcTotals();  " & "<" & "/script>"
        ''Page.Controls.Add(lbl)

        ''Dim lbl As New Label()
        ''lbl.Text = "<script language='javascript'> ARIsLienHolder(); ARsupHeating(); ARHideShowQuestions(); ARCalcTotals(); OnhomeUseDDSelectedIndexChange(); ARHideShowQuestions();ARShowStandardMedPay();" & "<" & "/script>"
        ''Page.Controls.Add(lbl)
        'If dd_PackagePerProp_AR1.SelectedValue = "Yes" Then
        '    trvalPPl.Style.Item("display") = ""
        'Else
        '    trvalPPl.Style.Item("display") = "none"

        'End If
        'If liendd.SelectedValue = "Yes" Then
        '    trmhAROpt1_2.Style.Item("display") = ""
        '    trmhAROpt1_2_d.Style.Item("display") = ""
        '    trmhAROpt1.Style.Item("display") = ""
        '    trmhAROpt1_d.Style.Item("display") = ""
        'End If
        'If dd_addresOpt_ar1.Text <> "" Then
        '    AR_AddResOpt1_ar1.Style.Item("display") = ""
        '    AR_AddResOpt2_ar1.Style.Item("display") = ""

        'End If
        'If dd_waterCraft_AR1.Text <> "" Then
        '    AR_WaterCraftOpt1_ar1.Style.Item("display") = ""
        '    AR_WaterCraftOpt2_ar1.Style.Item("display") = ""
        'End If
        'If supheatdd.SelectedValue = "Yes" Then
        '    trheating.Style.Item("display") = ""
        'End If
        'If Request.QueryString("quoteID") <> "" Or Session("beenSaved") = "True" Then
        '    updateQuote(Request.QueryString("quoteID"))
        'Else 'New Quote
        '    save()
        'End If

    End Sub
    Public Sub ar_premiumbtnClick2(ByVal sender As Object, ByVal e As System.EventArgs) Handles ar2_updateOptions.Click
        AR1_Debug.Text = ""
        AR2_Debug.Text = ""
        AR3_Debug.Text = ""
        Calc()
        '  ASPxPopupControl1.ShowOnPageLoad = True
        Me.AR_PremiumUpdatePanel.Update()

        '  loadpremdata(mhvalue, mhstate, mhtype, mhmfg, mhyear, mhcounty, mhquoteID)

        'calcAR()

        ''Set Visiblity on hidden fields
        'ARSetFields()
        'showARSections()
        'AR_PremiumUpdatePanel.Update()
        ''Dim lbl As New Label()
        ''lbl.Text = "<script language='javascript'>  ARCalcTotals();  " & "<" & "/script>"
        ''Page.Controls.Add(lbl)

        'If dd_PackagePerProp_ar2.SelectedValue = "Yes" Then
        '    vpplAR2.Style.Item("display") = ""
        'Else
        '    vpplAR2.Style.Item("display") = "none"

        'End If
        'If liendd.SelectedValue = "Yes" Then
        '    trmhAROpt2_2.Style.Item("display") = ""
        '    trmhAROpt2_2_d.Style.Item("display") = ""
        '    trmhAROpt2.Style.Item("display") = ""
        '    trmhAROpt2_d.Style.Item("display") = ""
        'End If
        'If dd_addresOpt_ar2.Text <> "" Then
        '    AR_AddResOpt1_ar2.Style.Item("display") = ""
        '    AR_AddResOpt2_ar2.Style.Item("display") = ""

        'End If
        'If dd_waterCraft_ar2.Text <> "" Then
        '    AR_WaterCraftOpt1_ar2.Style.Item("display") = ""
        '    AR_WaterCraftOpt2_ar2.Style.Item("display") = ""
        'End If
        'If supheatdd.SelectedValue = "Yes" Then
        '    trheating2.Style.Item("display") = ""
        'End If


        'If Request.QueryString("quoteID") <> "" Or Session("beenSaved") = "True" Then
        '    updateQuote(Request.QueryString("quoteID"))
        'Else 'New Quote
        '    save()
        'End If
    End Sub
    Public Sub ar_premiumbtnClick3(ByVal sender As Object, ByVal e As System.EventArgs) Handles ar3_updateOptions.Click
        'AR1_Debug.Text = ""
        'AR2_Debug.Text = ""
        'AR3_Debug.Text = ""
        Calc()
        Me.AR_PremiumUpdatePanel.Update()
        ''Set Visiblity on hidden fields
        'ARSetFields()
        'showARSections()
        'AR_PremiumUpdatePanel.Update()
        ''Dim lbl As New Label()
        ''lbl.Text = "<script language='javascript'>  ARCalcTotals();  " & "<" & "/script>"
        ''Page.Controls.Add(lbl)
        'If Request.QueryString("quoteID") <> "" Or Session("beenSaved") = "True" Then
        '    updateQuote(Request.QueryString("quoteID"))
        'Else 'New Quote
        '    save()
        'End If
    End Sub
    Public Sub selectAR1btn_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles selectAR1btn.Click
        HiddenFieldSelected.Value = "Package"
        rateTypelbl.Text = "Lloyds Package"
        rateTypelbl.Font.Bold = True
        rateTypelbl.ForeColor = Drawing.Color.Green
        'Show hide button



        'Set Selected to AR1 in database
        Try

            If quoteIDlbl.Text <> "" Then
                Me.Page.GetType.InvokeMember("updateQuote", System.Reflection.BindingFlags.InvokeMethod, Nothing, Me.Page, New Object() {quoteIDlbl.Text})
            Else
                Me.Page.GetType.InvokeMember("save", System.Reflection.BindingFlags.InvokeMethod, Nothing, Me.Page, New Object() {})

            End If
        Catch ex As Exception
            errortrap("Select Lloyds Package " & mhquoteID, "selectAR1btn_Click", ex.Message)
        End Try
        Dim ds As System.Data.DataSet
        ds = runQueryDS("EXEC sp_SetQuoteRateType '" & quoteIDlbl.Text & "', 'Package'", "ColonialMHConnectionString")
        'Check Financing options
        ds = runQueryDS("SELECT ARRateType, state  FROM tblQuotes WHERE quoteID ='" & quoteIDlbl.Text & "'", "ColonialMHConnectionString")
        If ds.Tables(0).Rows.Count > 0 Then
            If ds.Tables(0).Rows(0).Item("state") = "SC" And Not rateTypelbl.Text.ToString.ToUpper.Contains("AEG") Then
                'SCPremFinbtn.Visible = True
                'calcSCFinancing()
                '  SCFinancingUpdatePanel.Update()
            Else
                'SCPremFinbtn.Visible = False
            End If
        End If
        premiumBtnTable.Attributes.Add("style", "display:block")
    End Sub
    Public Sub selectAR2btn_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles selectAR2btn.Click
        Try

            If quoteIDlbl.Text <> "" Then
                Me.Page.GetType.InvokeMember("updateQuote", System.Reflection.BindingFlags.InvokeMethod, Nothing, Me.Page, New Object() {quoteIDlbl.Text})
            Else
                Me.Page.GetType.InvokeMember("save", System.Reflection.BindingFlags.InvokeMethod, Nothing, Me.Page, New Object() {})

            End If
        Catch ex As Exception
            errortrap("Select Lloyds Standard", "selectAR2btn_Click", ex.Message)
        End Try
        HiddenFieldSelected.Value = "Standard"
        rateTypelbl.Text = "Lloyds Standard"
        rateTypelbl.Font.Bold = True
        rateTypelbl.ForeColor = Drawing.Color.Green

        'Set Selected to AR1 in database
        Dim ds As System.Data.DataSet
        ds = runQueryDS("EXEC sp_SetQuoteRateType '" & quoteIDlbl.Text & "', 'Standard'", "ColonialMHConnectionString")
        'Check Financing options
        ds = runQueryDS("SELECT ARRateType, state  FROM tblQuotes WHERE quoteID ='" & quoteIDlbl.Text & "'", "ColonialMHConnectionString")
        If ds.Tables(0).Rows.Count > 0 Then
            If ds.Tables(0).Rows(0).Item("state") = "SC" And Not rateTypelbl.Text.ToString.ToUpper.Contains("AEG") Then
                'SCPremFinbtn.Visible = True
                'calcSCFinancing()
                ' SCFinancingUpdatePanel.Update()
            Else
                'SCPremFinbtn.Visible = False
            End If
        End If
        premiumBtnTable.Attributes.Add("style", "display:block")
    End Sub
    Public Sub selectAR3btn_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles selectAR3btn.Click
        HiddenFieldSelected.Value = "Rental"
        rateTypelbl.Text = "Lloyds Rental"
        rateTypelbl.Font.Bold = True
        rateTypelbl.ForeColor = Drawing.Color.Green

        Try

            If quoteIDlbl.Text <> "" Then
                Me.Page.GetType.InvokeMember("updateQuote", System.Reflection.BindingFlags.InvokeMethod, Nothing, Me.Page, New Object() {quoteIDlbl.Text})
            Else
                Me.Page.GetType.InvokeMember("save", System.Reflection.BindingFlags.InvokeMethod, Nothing, Me.Page, New Object() {})

            End If
        Catch ex As Exception
            errortrap("Select Lloyds Rental ", "selectAR3btn_Click", ex.Message)
        End Try
        'Set Selected to AR1 in database
        Dim ds As System.Data.DataSet
        ds = runQueryDS("EXEC sp_SetQuoteRateType '" & quoteIDlbl.Text & "', 'Rental'", "ColonialMHConnectionString")
        'Check Financing options
        ds = runQueryDS("SELECT ARRateType, state  FROM tblQuotes WHERE quoteID ='" & quoteIDlbl.Text & "'", "ColonialMHConnectionString")
        If ds.Tables(0).Rows.Count > 0 Then
            If ds.Tables(0).Rows(0).Item("state") = "SC" And Not rateTypelbl.Text.ToString.ToUpper.Contains("AEG") Then
                'SCPremFinbtn.Visible = True
                calcSCFinancing()
                ' SCFinancingUpdatePanel.Update()
            Else
                'SCPremFinbtn.Visible = False
            End If
        End If
        premiumBtnTable.Attributes.Add("style", "display:block")
    End Sub

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

    Private Sub dd_aop_AR2_TextChanged(sender As Object, e As System.EventArgs) Handles dd_aop_AR2.TextChanged
        ar2_updateOptions.Attributes.Add("style", "")

    End Sub
    Public Sub calcSH08()

        mhvalue = MHValuelbl.Text
        mhcounty = mhcountylbl.Text
        mhstate = mhstatelbl.Text
        mhmfg = mhmfglbl.Text
        mhtype = mhtypelbl.Text
        mhyear = mhyearlbl.Text
        If mhvaluechanged.Text = "True" Then
            dd_pl_08.SelectedValue = "$25,000"
            dd_mp_08.SelectedValue = "$500"
        End If
        If IsNumeric(mhvalue) Then
            If txt_unattstr_08.Text = "0.00" Then
                txt_unattstr_08.Text = Math.Round(CInt(mhvalue) * 0.1)
            End If
            If txt_pp_08.Text = "0.00" Then
                txt_pp_08.Text = Math.Round(CInt(mhvalue) * 0.25)
            End If

        End If
        If dd_pl_08.SelectedValue = "$0" Then
            dd_mp_08.SelectedValue = "$0"
        Else
            dd_mp_08.SelectedValue = "$1000"

        End If
        lblcontentmax.Visible = False
        If IsNumeric(mhvalue) Then
            'changed from 0.4 to 0.25 11/12/2013 cts
            If CInt(txt_pp_08.Text) < (CInt(mhvalue) * 0.25) Then
                txt_pp_08.Text = Math.Round((CInt(mhvalue) * 0.25))
            End If
            If CInt(txt_unattstr_08.Text) > (CInt(mhvalue) * 0.1) Then
                txt_unattstr_08.Text = Math.Round(CInt(mhvalue) * 0.1)
            End If
            If CInt(txt_pp_08.Text) > (CInt(mhvalue) * 0.4) Then
                txt_pp_08.Text = Math.Round((CInt(mhvalue) * 0.4))
                lblcontentmax.Visible = True

            End If
        End If



        Dim Connection As String = System.Configuration.ConfigurationManager.ConnectionStrings("ColonialMHConnectionString").ConnectionString
        Dim dbConnection As System.Data.IDbConnection = New System.Data.SqlClient.SqlConnection(Connection)
        Dim cmd As New SqlCommand("sp_getLloydRatesSMH", dbConnection)
        cmd.CommandType = CommandType.StoredProcedure
        cmd.Parameters.Add("@MHvalue", SqlDbType.VarChar, 8000).Value = mhvalue
        cmd.Parameters.Add("@AStruc", SqlDbType.VarChar, 8000).Value = txt_unattstr_08.Text.Replace("$", "").Replace(",", "")
        cmd.Parameters.Add("@Content", SqlDbType.VarChar, 8000).Value = txt_pp_08.Text.Replace("$", "").Replace(",", "")
        cmd.Parameters.Add("@AOP", SqlDbType.VarChar, 8000).Value = dd_aop_08.SelectedValue().Replace("$", "").Replace(",", "")
        cmd.Parameters.Add("@Medpay", SqlDbType.VarChar, 8000).Value = dd_mp_08.SelectedValue().Replace("$", "").Replace(",", "")
        cmd.Parameters.Add("@ContentRepl", SqlDbType.VarChar, 8000).Value = dd_rep_08.SelectedValue().Replace("$", "").Replace(",", "")
        cmd.Parameters.Add("@Enhance", SqlDbType.VarChar, 8000).Value = dd_sip_08.SelectedValue().Replace("$", "").Replace(",", "")
        cmd.Parameters.Add("@Dist", SqlDbType.VarChar, 8000).Value = mhdistlbl.Text
        cmd.Parameters.Add("@prot", SqlDbType.VarChar, 8000).Value = protection.Text 'need to get this from the quote
        cmd.Parameters.Add("@mhyear", SqlDbType.VarChar, 8000).Value = mhyearlbl.Text
        cmd.Parameters.Add("@PerLiab", SqlDbType.VarChar, 8000).Value = dd_pl_08.SelectedValue().Replace("$", "").Replace(",", "")
        cmd.Parameters.Add("@state", SqlDbType.VarChar, 8000).Value = mhstatelbl.Text 'dd_pl_08.SelectedValue().Replace("$", "").Replace(",", "")
        cmd.Parameters.Add("@effDate", SqlDbType.VarChar, 8000).Value = lbleffdate.Text
        cmd.Parameters.Add("@Qtype", SqlDbType.VarChar, 8000).Value = "New" 'lbleffdate.Text
        Try
            Dim ds As Data.DataSet = New Data.DataSet

            cmd.Connection.Open()
            ' intRowsAff = cmd.ExecuteNonQuery()

            Dim myCommand = New SqlDataAdapter(cmd)
            myCommand.Fill(ds, "tbl1")
            If ds.Tables("tbl1").Rows.Count > 0 Then
                LloydcalcSH08(ds)
            End If
            Me.AR_PremiumUpdatePanel.Update()
        Catch ex As Exception
            Dim s As String = ""
            For Each param As SqlParameter In cmd.Parameters
                s += param.ParameterName & "="
                s += param.Value & ":  "

            Next
            errortrap("Geting Calculation data SMH " & s, "Calculation SMH08", ex.Message)
        End Try

    End Sub
    Protected Sub LloydcalcSH08(ByVal ds As DataSet)
        Dim smhprem As String
        Dim smhas As String
        Dim smhcon As String
        Dim smhopt As Integer = 0
        Dim smhtotal As Decimal
        SC08_Debug.Text = "<table> <tbody>"
        SC08_dwell.Text = "$" & mhvalue.Replace("$", "")
        SC08_unattStr.Text = "$" & txt_unattstr_08.Text.Replace("$", "")
        SC08_perEff.Text = "$" & txt_pp_08.Text.Replace("$", "")
        SC08_perLiab.Text = "$" & dd_pl_08.Text.Replace("$", "")
        SC08_medpay.Text = "$" & dd_mp_08.Text.Replace("$", "")

        ' SC08_baseprem.Text = "$" & ds.Tables("tbl1").Rows(0).Item("Prem").ToString().Replace("$", "")
        smhprem = ds.Tables("tbl1").Rows(0).Item("Prem").ToString().Replace("$", "")

        If dd_aop_08.Text = "$2500" Then
            dd_hurded_08.Text = "$2500"
        Else
            dd_hurded_08.Text = "$1250"
        End If

        txtlossofuse08.Text = "$1000"

        If mhstatelbl.Text = "NC" Or mhstatelbl.Text = "VA" Or mhstatelbl.Text = "GA" Then
            If mhdistlbl.Text = "2-10 miles" Then
                dd_hurded_08.Text = "$2500"
            ElseIf mhdistlbl.Text = "10-20 miles" Then
                dd_hurded_08.Text = "$1500"
            ElseIf mhdistlbl.Text = "20-50 miles" Then
                dd_hurded_08.Text = "$1250"
            ElseIf mhdistlbl.Text = "50+ miles" Then
                dd_hurded_08.Text = "$1250"

            End If

        End If
        If CInt(dd_aop_08.SelectedValue) > CInt(dd_hurded_08.Text) Then
            dd_hurded_08.Text = dd_aop_08.SelectedValue
        End If

        SC08_Debug.Text += "<tr align=left><td>Package Premium </td><td> $" & CInt(smhprem) & " </td></tr> "
        SMHpackpremlbl.Text = CInt(smhprem)
        SC08_Debug.Text += "<tr align=left><td>Other Structures </td><td> $" & CInt(ds.Tables("tbl1").Rows(0).Item("AsStrucPrem").ToString().Replace("$", "")) & " </td></tr> "
        SC08_Debug.Text += "<tr align=left><td>Contents </td><td> $" & CInt(ds.Tables("tbl1").Rows(0).Item("ContPrem").ToString().Replace("$", "")) & " </td></tr> "
        SC08_Debug.Text += "<tr align=left><td>Addl Living Expense</td><td> $" & CInt("0") & " </td></tr> "
        txt_unattstr_08_Amount.Text = Math.Ceiling(CDbl(ds.Tables("tbl1").Rows(0).Item("AsStrucPrem").ToString().Replace("$", "")))
        txt_pp_08_Amount.Text = Math.Ceiling(CDbl(ds.Tables("tbl1").Rows(0).Item("ContPrem").ToString().Replace("$", "")))
        smhtotal = CInt(smhprem) + Math.Ceiling(CDbl(ds.Tables("tbl1").Rows(0).Item("AsStrucPrem").ToString().Replace("$", ""))) + Math.Ceiling(CDbl(ds.Tables("tbl1").Rows(0).Item("ContPrem").ToString().Replace("$", "")))
        smhopt += Math.Ceiling(CDbl(ds.Tables("tbl1").Rows(0).Item("AsStrucPrem").ToString().Replace("$", ""))) + Math.Ceiling(CDbl(ds.Tables("tbl1").Rows(0).Item("ContPrem").ToString().Replace("$", "")))

        'SMHpackpremlbl.Text = CInt(smhtotal)
        SC08_Debug.Text += "<tr align=left><td>Sub Premium</td><td> $" & CInt(smhtotal) & " </td></tr> "
        Dim CreditsPercentage As Decimal
        'Add credit stuff to label
        CreditsPercentage = ds.Tables("tbl1").Rows(0).Item("Credit").ToString().Replace("$", "")
        SMHpackperclbl.Text = CreditsPercentage
        SC08_Debug.Text += "<tr align=left><td> Credits %</td><td> " & CreditsPercentage * 100 & "% </td></tr> "
        SC08_Debug.Text += "<tr align=left><td> Credits Value</td><td>-" & Math.Round((smhtotal * CreditsPercentage), 0, MidpointRounding.AwayFromZero) & " </td></tr> "
        SMHpackcramtlbl.Text = Math.Round((smhtotal * CreditsPercentage), 0, MidpointRounding.AwayFromZero)
        smhtotal -= Math.Round((smhtotal * CreditsPercentage), 0, MidpointRounding.AwayFromZero)
        If CInt(smhtotal) < 300 Then
            smhtotal = 300
            SC08_Debug.Text += "<tr align=left><td>Base Premium Minimum</td><td> $" & CInt(smhtotal) & " </td></tr> "
        Else
            SC08_Debug.Text += "<tr align=left><td>Base Premium</td><td> $" & CInt(smhtotal) & " </td></tr> "
        End If
        SC08_baseprem.Text = "$" & CInt(smhtotal)
        SC08_Debug.Text += "<tr align=left><td>Base Premium</td><td> $" & CInt(smhtotal) & " </td></tr> "
        SC08_Debug.Text += "<tr align=left><td>AOP</td><td> $" & ds.Tables("tbl1").Rows(0).Item("AOP").ToString().Replace("$", "") & " </td></tr> "
        dd_aop_08_Amount.Text = ds.Tables("tbl1").Rows(0).Item("AOP").ToString().Replace("$", "")
        smhtotal += CInt(ds.Tables("tbl1").Rows(0).Item("AOP").ToString().Replace("$", ""))
        SC08_Debug.Text += "<tr align=left><td>SUB TOTAL 2</td><td> $" & CInt(smhtotal) & " </td></tr> "
        SC08_Debug.Text += "<tr align=left><td>Personal Liability</td><td> $" & CInt(ds.Tables("tbl1").Rows(0).Item("Liab").ToString()) & " </td></tr> "
        dd_pl_08_Amount.Text = CInt(ds.Tables("tbl1").Rows(0).Item("Liab").ToString())
        smhtotal += CInt(ds.Tables("tbl1").Rows(0).Item("Liab").ToString())
        SC08_Debug.Text += "<tr align=left><td>Medical Payment</td><td> $ 0  </td></tr> "
        SC08_Debug.Text += "<tr align=left><td>SUB TOTAL 3</td><td> $" & CInt(smhtotal) & " </td></tr> "

        SC08_Debug.Text += "<tr align=left><td>Contents Replacement</td><td> $" & CInt(ds.Tables("tbl1").Rows(0).Item("ContRep").ToString()) & " </td></tr> "
        dd_rep_08_Amount.Text = CInt(ds.Tables("tbl1").Rows(0).Item("ContRep").ToString())

        smhtotal += CInt(ds.Tables("tbl1").Rows(0).Item("ContRep").ToString())
        SC08_Debug.Text += "<tr align=left><td>Enhancement Coverage</td><td> $" & CInt(ds.Tables("tbl1").Rows(0).Item("Enhance").ToString()) & " </td></tr> "
        smhtotal += CInt(ds.Tables("tbl1").Rows(0).Item("Enhance").ToString())
        dd_sip_08_Amount.Text = CInt(ds.Tables("tbl1").Rows(0).Item("Enhance").ToString())
        SC08_Debug.Text += "<tr align=left><td>SUB TOTAL 4</td><td> $" & CInt(smhtotal) & " </td></tr> "
        SC08_fees.Text = "$" & CInt(ds.Tables("tbl1").Rows(0).Item("Fee").ToString())
        SC08_Debug.Text += "<tr align=left><td>Policy Fee</td><td> $" & CInt(ds.Tables("tbl1").Rows(0).Item("Fee").ToString()) & " </td></tr> "
        smhtotal += CInt(ds.Tables("tbl1").Rows(0).Item("Fee").ToString())

        SC08_Debug.Text += "<tr align=left><td>SUB TOTAL 5</td><td> $" & smhtotal & " </td></tr> "
        SC08_Debug.Text += "<tr align=left><td>Taxes</td><td> $" & CDbl(CInt(smhtotal) * CDec(ds.Tables("tbl1").Rows(0).Item("TaxAmt").ToString())) & " </td></tr> "
        SC08_tax.Text = "$" & CDbl(CInt(smhtotal) * CDec(ds.Tables("tbl1").Rows(0).Item("TaxAmt").ToString()))
        smhtotal += CDbl(CInt(smhtotal) * CDec(ds.Tables("tbl1").Rows(0).Item("TaxAmt").ToString()))
        SC08_Debug.Text += "<tr align=left><td>Total Prem</td><td> $" & CDbl(smhtotal) & " </td></tr> "
        SC08_options.Text = "$" & CInt(ds.Tables("tbl1").Rows(0).Item("AOP").ToString().Replace("$", "")) + CInt(ds.Tables("tbl1").Rows(0).Item("Liab").ToString()) + CInt(ds.Tables("tbl1").Rows(0).Item("ContRep").ToString()) + CInt(ds.Tables("tbl1").Rows(0).Item("Enhance").ToString())
        SC08_total.Text = String.Format("{0:C}", CInt(SC08_baseprem.Text) + CInt(SC08_options.Text) + CDbl(SC08_fees.Text) + CDbl(SC08_tax.Text))

        SC08_Debug.Text += "</tbody></table>"
        Me.AR_PremiumUpdatePanel.Update()







    End Sub
    Protected Sub Amslic_Calc()
        Dim Connection As String = System.Configuration.ConfigurationManager.ConnectionStrings("ColonialMHConnectionString").ConnectionString
        Dim dbConnection As System.Data.IDbConnection = New System.Data.SqlClient.SqlConnection(Connection)
        Dim cmd As New SqlCommand("sp_getAmslicRates", dbConnection)
        cmd.CommandType = CommandType.StoredProcedure
        cmd.Parameters.Add("@MHvalue", SqlDbType.VarChar, 8000).Value = MHValuelbl.Text
        cmd.Parameters.Add("@OtherStruc", SqlDbType.VarChar, 8000).Value = txt_unattstr_amslic.Text.Replace("$", "").Replace(",", "")
        cmd.Parameters.Add("@RentOtherstruc", SqlDbType.VarChar, 8000).Value = "" ' txt_unattstr_amslicRent.Text.Replace("$", "").Replace(",", "")
        cmd.Parameters.Add("@Contents", SqlDbType.VarChar, 8000).Value = txt_pp_amslic.Text.Replace("$", "").Replace(",", "")
        cmd.Parameters.Add("@RentContents", SqlDbType.VarChar, 8000).Value = "" 'txt_pp_amslicRent.Text.Replace("$", "").Replace(",", "")
        cmd.Parameters.Add("@LossofUse", SqlDbType.VarChar, 8000).Value = "" 'txt_pp_AR1.Text.Replace("$", "").Replace(",", "")
        cmd.Parameters.Add("@liability", SqlDbType.VarChar, 8000).Value = dd_pl_amslic.Text.Replace("$", "").Replace(",", "")
        cmd.Parameters.Add("@premLiab", SqlDbType.VarChar, 8000).Value = dd_pl_amslicRent.Text.Replace("$", "").Replace(",", "")
        cmd.Parameters.Add("@medpay", SqlDbType.VarChar, 8000).Value = dd_mp_amslic.Text.Replace("$", "").Replace(",", "")
        cmd.Parameters.Add("@FullRepair", SqlDbType.VarChar, 8000).Value = dd_sip_amslic2.SelectedValue()
        cmd.Parameters.Add("@ContentRep", SqlDbType.VarChar, 8000).Value = dd_rep_amslic.SelectedValue().Replace("$", "").Replace(",", "")
        cmd.Parameters.Add("@County", SqlDbType.VarChar, 8000).Value = mhcountylbl.Text.Replace("$", "").Replace(",", "")
        cmd.Parameters.Add("@Prot", SqlDbType.VarChar, 8000).Value = protection.Text.Replace("$", "").Replace(",", "")
        cmd.Parameters.Add("@type", SqlDbType.VarChar, 8000).Value = mhtypelbl.Text.Replace("$", "").Replace(",", "")
        cmd.Parameters.Add("@usage", SqlDbType.VarChar, 8000).Value = mhusagelbl.Text.Replace("$", "").Replace(",", "")
        cmd.Parameters.Add("@State", SqlDbType.VarChar, 8000).Value = mhstatelbl.Text.Replace("$", "").Replace(",", "")

        Try
            Dim ds As Data.DataSet = New Data.DataSet

            cmd.Connection.Open()
            ' intRowsAff = cmd.ExecuteNonQuery()

            Dim myCommand = New SqlDataAdapter(cmd)
            myCommand.Fill(ds, "tbl1")
            If ds.Tables("tbl1").Rows.Count > 0 Then
                Amslic_display(ds)
            Else

                amslic_mh_prog.Visible = False
                amslicOptionRow.Visible = False
                amslic_mh_progRent.Visible = False
                amslicOptionRowRent.Visible = False
            End If

        Catch ex As Exception
            Dim s As String = ""
            For Each param As SqlParameter In cmd.Parameters
                s += param.ParameterName & "="
                s += param.Value & ":  "

            Next
            errortrap("Geting AMSLIC Calculation data " & s, "AMSLIC Calculation CALC", ex.Message)
        End Try



    End Sub
    Protected Sub Amslic_display(ByVal ds As Data.DataSet)
        Dim standardprem As String
        Dim standtot As Decimal
        Dim standopt As Integer
        Dim standfee As Integer
        'Amslic Standard:
        If mhusagelbl.Text = "Owner" Or mhusagelbl.Text = "Seasonal" Then

            amslic_mh_prog.Visible = True
            amslicOptionRow.Visible = True
            amslic_Debug.Text = "<table> <tbody>"
            amslic_dwell.Text = "$" & MHValuelbl.Text.Replace("$", "")
            amslic_unattStr.Text = "$" & txt_unattstr_amslic.Text.Replace("$", "")
            amslic_perEff.Text = "$" & txt_pp_amslic.Text.Replace("$", "")
            amslic_perLiab.Text = "$" & dd_pl_amslic.Text.Replace("$", "")
            amslic_medpay.Text = "$" & dd_mp_amslic.Text.Replace("$", "")

            standardprem = ds.Tables("tbl1").Rows(0).Item("Prem").ToString().Replace("$", "")
            Amslicpackpremlbl.Text = standardprem
            If dd_windded_amslic.Text.Replace("$", "") < CInt(MHValuelbl.Text.Replace("$", "") * 0.02) Then
                dd_windded_amslic.Text = "$" & CInt(MHValuelbl.Text.Replace("$", "") * 0.02)
                dd_hurded_amslic.Text = "$" & CInt(MHValuelbl.Text.Replace("$", "") * 0.02)

            End If
            standtot = CInt(standardprem)
            amslic_Debug.Text += "<tr align=left><td>Package Premium </td><td> $" & CInt(standardprem) & " </td></tr> "
            amslic_baseprem.Text = standardprem

            If dd_sip_amslic2.SelectedValue() = "Yes" Then
                amslic_Debug.Text += "<tr align=left><td>Full Repair </td><td> $" & ds.Tables("tbl1").Rows(0).Item("FullRepair").ToString().Replace("$", "") & " </td></tr> "
                standtot += CInt(ds.Tables("tbl1").Rows(0).Item("FullRepair").ToString().Replace("$", ""))
                standopt += CInt(ds.Tables("tbl1").Rows(0).Item("FullRepair").ToString().Replace("$", ""))
                dd_sip_amslic2_Amount.Text = CInt(ds.Tables("tbl1").Rows(0).Item("FullRepair").ToString().Replace("$", "")).ToString("C2")
            Else
                dd_sip_amslic2_Amount.Text = "0.00"
            End If

            'If dd_mhr_amslic.SelectedValue() = "Yes" Then
            '    amslic_Debug.Text += "<tr align=left><td>Replacement Cost </td><td> $" & ds.Tables("tbl1").Rows(0).Item("RePlacement").ToString().Replace("$", "") & " </td></tr> "
            '    standtot += CInt(ds.Tables("tbl1").Rows(0).Item("RePlacement").ToString().Replace("$", ""))
            '    standopt += CInt(ds.Tables("tbl1").Rows(0).Item("RePlacement").ToString().Replace("$", ""))
            '    dd_mhr_amslic_Amount.Text = CInt(ds.Tables("tbl1").Rows(0).Item("RePlacement").ToString().Replace("$", "")).ToString("C2")
            'Else
            '    dd_mhr_amslic_Amount.Text = "0.00"
            'End If

            If dd_rep_amslic.SelectedValue() = "Yes" Then
                amslic_Debug.Text += "<tr align=left><td>Content Replacement Cost </td><td> $" & ds.Tables("tbl1").Rows(0).Item("RePlacement").ToString().Replace("$", "") & " </td></tr> "
                standtot += CInt(ds.Tables("tbl1").Rows(0).Item("RePlacement").ToString().Replace("$", ""))
                standopt += CInt(ds.Tables("tbl1").Rows(0).Item("RePlacement").ToString().Replace("$", ""))
                dd_rep_amslic_Amount.Text = CInt(ds.Tables("tbl1").Rows(0).Item("RePlacement").ToString().Replace("$", "")).ToString("C2")
            Else
                dd_rep_amslic_Amount.Text = "0.00"
            End If
            If CDec(txt_unattstr_amslic.Text) > CDec(ds.Tables("tbl1").Rows(0).Item("OStructure").ToString().Replace("$", "")) Then

                txt_unattstr_amslic_Amount.Text = ((CDec(txt_unattstr_amslic.Text) - CDec(ds.Tables("tbl1").Rows(0).Item("OStructure").ToString().Replace("$", ""))) / 100) * CDec(ds.Tables("tbl1").Rows(0).Item("OStrucAddRate").ToString().Replace("$", "")).ToString("C2")
                amslic_Debug.Text += "<tr align=left><td>Addition Structure Cost </td><td> $" & ((CDec(txt_unattstr_amslic.Text) - CDec(ds.Tables("tbl1").Rows(0).Item("OStructure").ToString().Replace("$", ""))) / 100) * CDec(ds.Tables("tbl1").Rows(0).Item("OStrucAddRate").ToString().Replace("$", "")) & " </td></tr> "
                standtot += ((CDec(txt_unattstr_amslic.Text) - CDec(ds.Tables("tbl1").Rows(0).Item("OStructure").ToString().Replace("$", ""))) / 100) * CDec(ds.Tables("tbl1").Rows(0).Item("OStrucAddRate").ToString().Replace("$", ""))
                standopt += ((CDec(txt_unattstr_amslic.Text) - CDec(ds.Tables("tbl1").Rows(0).Item("OStructure").ToString().Replace("$", ""))) / 100) * CDec(ds.Tables("tbl1").Rows(0).Item("OStrucAddRate").ToString().Replace("$", ""))
            Else
                txt_unattstr_amslic.Text = ds.Tables("tbl1").Rows(0).Item("OStructure").ToString().Replace("$", "")
                txt_unattstr_amslic_Amount.Text = "0.00"
            End If

            If CDec(txt_pp_amslic.Text) > CDec(ds.Tables("tbl1").Rows(0).Item("Contents").ToString().Replace("$", "")) Then

                txt_pp_amslic_Amount.Text = ((CDec(txt_pp_amslic.Text) - CDec(ds.Tables("tbl1").Rows(0).Item("Contents").ToString().Replace("$", ""))) / 100) * CDec(ds.Tables("tbl1").Rows(0).Item("ContentAddRate").ToString().Replace("$", "")).ToString("C2")
                amslic_Debug.Text += "<tr align=left><td>Addition Contents Cost </td><td> $" & ((CDec(txt_pp_amslic.Text) - CDec(ds.Tables("tbl1").Rows(0).Item("Contents").ToString().Replace("$", ""))) / 100) * CDec(ds.Tables("tbl1").Rows(0).Item("ContentAddRate").ToString().Replace("$", "")) & " </td></tr> "
                standtot += ((CDec(txt_pp_amslic.Text) - CDec(ds.Tables("tbl1").Rows(0).Item("Contents").ToString().Replace("$", ""))) / 100) * CDec(ds.Tables("tbl1").Rows(0).Item("ContentAddRate").ToString().Replace("$", ""))
                standopt += ((CDec(txt_pp_amslic.Text) - CDec(ds.Tables("tbl1").Rows(0).Item("Contents").ToString().Replace("$", ""))) / 100) * CDec(ds.Tables("tbl1").Rows(0).Item("ContentAddRate").ToString().Replace("$", ""))
            Else
                txt_pp_amslic.Text = ds.Tables("tbl1").Rows(0).Item("Contents").ToString().Replace("$", "")
                txt_pp_amslic_Amount.Text = "0.00"
            End If
            amslic_Debug.Text += "<tr align=left><td>SUB TOTAL 2</td><td> $" & CInt(standtot) & " </td></tr> "
            If mhusagelbl.Text = "Seasonal" Then
                amslic_Debug.Text += "<tr align=left><td>Seasonal Charge</td><td> $" & CInt(ds.Tables("tbl1").Rows(0).Item("SeasonFee").ToString().Replace("$", "")) & " </td></tr> "
                standtot += CInt(ds.Tables("tbl1").Rows(0).Item("SeasonFee").ToString().Replace("$", ""))
                standfee += CInt(ds.Tables("tbl1").Rows(0).Item("SeasonFee").ToString().Replace("$", ""))
            End If
            amslic_Debug.Text += "<tr align=left><td>Policy Fee</td><td> $" & CInt(ds.Tables("tbl1").Rows(0).Item("PolicyFee").ToString().Replace("$", "")) & " </td></tr> "
            standfee += CInt(ds.Tables("tbl1").Rows(0).Item("PolicyFee").ToString().Replace("$", "")).ToString("C2")
            standtot += CInt(ds.Tables("tbl1").Rows(0).Item("PolicyFee").ToString().Replace("$", "")).ToString("C2")
            amslic_Debug.Text += "<tr align=left><td>SUB TOTAL 3</td><td> $" & CInt(standtot).ToString("C2") & " </td></tr> "
            amslic_Debug.Text += "<tr align=left><td>Taxes</td><td> $" & CDec(CInt(standtot) * 0.06).ToString("C2") & " </td></tr> "
            amslic_tax.Text = CDec(CInt(standtot) * 0.06).ToString("C2")
            standtot += CDec(CInt(standtot) * 0.06)
            amslic_Debug.Text += "<tr align=left><td>TOTAL Premium</td><td> $" & CDec(standtot).ToString("C2") & " </td></tr> "
            amslic_options.Text = standopt.ToString("C2")
            amslic_fees.Text = standfee.ToString("C2")
            amslic_total.Text = standtot.ToString("C2")
            amslic_Debug.Text += "</tbody></table>"
            If amslic_total.Text = "0.00" Then

                amslic_mh_prog.Visible = False
                amslicOptionRow.Visible = False
            End If
            Me.AR_PremiumUpdatePanel.Update()
        Else
            amslic_mh_prog.Visible = False
            amslicOptionRow.Visible = False
        End If

        If mhusagelbl.Text = "Rental" Then
            amslic_mh_progRent.Visible = True
            amslicOptionRowRent.Visible = True

            amslicRent_Debug.Text = "<table> <tbody>"
            amslic_dwell3.Text = "$" & MHValuelbl.Text.Replace("$", "")
            amslic_unattStrRent.Text = "$" & txt_unattstr_amslic.Text.Replace("$", "")
            amslic_perEffRent.Text = "$" & txt_pp_amslic.Text.Replace("$", "")
            amslic_perLiabRent.Text = "$" & dd_pl_amslic.Text.Replace("$", "")
            amslic_medpayRent.Text = "$" & dd_mp_amslic.Text.Replace("$", "")

            standardprem = ds.Tables("tbl1").Rows(0).Item("Prem").ToString().Replace("$", "")
            Amslicrentpremlbl.Text = standardprem
            dd_thur_amslicRent.Text = "$1000"
            If dd_thur_amslicRent.Text.Replace("$", "") < CInt(MHValuelbl.Text.Replace("$", "") * 0.02) Then
                dd_thur_amslicRent.Text = "$" & CInt(MHValuelbl.Text.Replace("$", "") * 0.02)


            End If
            dd_hurded_amslicRent.Text = "$1000" ' & CInt(MHValuelbl.Text.Replace("$", "") * 0.02)
            standtot = CInt(standardprem)
            amslicRent_Debug.Text += "<tr align=left><td>Package Premium </td><td> $" & CInt(standardprem) & " </td></tr> "
            amslic_basepremRent.Text = standardprem

            'If dd_sip_amslicRent.SelectedValue() = "Yes" Then
            '    amslicRent_Debug.Text += "<tr align=left><td>Full Repair </td><td> $" & ds.Tables("tbl1").Rows(0).Item("FullRepair").ToString().Replace("$", "") & " </td></tr> "
            '    standtot += CInt(ds.Tables("tbl1").Rows(0).Item("FullRepair").ToString().Replace("$", ""))
            '    standopt += CInt(ds.Tables("tbl1").Rows(0).Item("FullRepair").ToString().Replace("$", ""))
            '    dd_sip_amslicRent_Amount.Text = CInt(ds.Tables("tbl1").Rows(0).Item("FullRepair").ToString().Replace("$", "")).ToString("C2")
            'Else
            '    dd_sip_amslicRent_Amount.Text = "0.00"
            'End If
            If dd_pl_amslicRent.SelectedItem.Text <> "" Then
                amslicRent_Debug.Text += "<tr align=left><td>Premise Liability </td><td> $" & ds.Tables("tbl1").Rows(0).Item("PremisLiab").ToString().Replace("$", "") & " </td></tr> "
                standtot += CInt(ds.Tables("tbl1").Rows(0).Item("PremisLiab").ToString().Replace("$", ""))
                standopt += CInt(ds.Tables("tbl1").Rows(0).Item("PremisLiab").ToString().Replace("$", ""))
                dd_pl_amslicRent_Amount.Text = CInt(ds.Tables("tbl1").Rows(0).Item("PremisLiab").ToString().Replace("$", "")).ToString("C2")
            End If
            'If dd_mhr_amslic.SelectedValue() = "Yes" Then
            '    amslic_Debug.Text += "<tr align=left><td>Replacement Cost </td><td> $" & ds.Tables("tbl1").Rows(0).Item("RePlacement").ToString().Replace("$", "") & " </td></tr> "
            '    standtot += CInt(ds.Tables("tbl1").Rows(0).Item("RePlacement").ToString().Replace("$", ""))
            '    standopt += CInt(ds.Tables("tbl1").Rows(0).Item("RePlacement").ToString().Replace("$", ""))
            '    dd_mhr_amslic_Amount.Text = CInt(ds.Tables("tbl1").Rows(0).Item("RePlacement").ToString().Replace("$", "")).ToString("C2")
            'Else
            '    dd_mhr_amslic_Amount.Text = "0.00"
            'End If

            If dd_rep_amslicRent.SelectedValue() = "Yes" Then
                amslicRent_Debug.Text += "<tr align=left><td>Content Replacement Cost </td><td> $" & ds.Tables("tbl1").Rows(0).Item("RePlacement").ToString().Replace("$", "") & " </td></tr> "
                standtot += CInt(ds.Tables("tbl1").Rows(0).Item("RePlacement").ToString().Replace("$", ""))
                standopt += CInt(ds.Tables("tbl1").Rows(0).Item("RePlacement").ToString().Replace("$", ""))
                dd_rep_amslicRent_Amount.Text = CInt(ds.Tables("tbl1").Rows(0).Item("RePlacement").ToString().Replace("$", "")).ToString("C2")
            Else
                dd_rep_amslicRent_Amount.Text = "0.00"
            End If
            'If CDec(txt_unattstr_amslicRent.Text) > CDec(ds.Tables("tbl1").Rows(0).Item("OStructure").ToString().Replace("$", "")) Then

            '    txt_unattstr_amslicRent_Amount.Text = ((CDec(txt_unattstr_amslic.Text) - CDec(ds.Tables("tbl1").Rows(0).Item("OStructure").ToString().Replace("$", ""))) / 100) * CDec(ds.Tables("tbl1").Rows(0).Item("OStrucAddRate").ToString().Replace("$", "")).ToString("C2")
            '    amslicRent_Debug.Text += "<tr align=left><td>Addition Structure Cost </td><td> $" & ((CDec(txt_unattstr_amslic.Text) - CDec(ds.Tables("tbl1").Rows(0).Item("OStructure").ToString().Replace("$", ""))) / 100) * CDec(ds.Tables("tbl1").Rows(0).Item("OStrucAddRate").ToString().Replace("$", "")) & " </td></tr> "
            '    standtot += ((CDec(txt_unattstr_amslicRent.Text) - CDec(ds.Tables("tbl1").Rows(0).Item("OStructure").ToString().Replace("$", ""))) / 100) * CDec(ds.Tables("tbl1").Rows(0).Item("OStrucAddRate").ToString().Replace("$", ""))
            '    standopt += ((CDec(txt_unattstr_amslicRent.Text) - CDec(ds.Tables("tbl1").Rows(0).Item("OStructure").ToString().Replace("$", ""))) / 100) * CDec(ds.Tables("tbl1").Rows(0).Item("OStrucAddRate").ToString().Replace("$", ""))
            'Else
            '    txt_unattstr_amslicRent.Text = ds.Tables("tbl1").Rows(0).Item("OStructure").ToString().Replace("$", "")
            '    txt_unattstr_amslicRent_Amount.Text = "0.00"
            'End If

            'If CDec(txt_pp_amslicRent.Text) > CDec(ds.Tables("tbl1").Rows(0).Item("Contents").ToString().Replace("$", "")) Then

            '    txt_pp_amslicRent_Amount.Text = ((CDec(txt_pp_amslicRent.Text) - CDec(ds.Tables("tbl1").Rows(0).Item("Contents").ToString().Replace("$", ""))) / 100) * CDec(ds.Tables("tbl1").Rows(0).Item("ContentAddRate").ToString().Replace("$", "")).ToString("C2")
            '    amslicRent_Debug.Text += "<tr align=left><td>Addition Contents Cost </td><td> $" & ((CDec(txt_pp_amslic.Text) - CDec(ds.Tables("tbl1").Rows(0).Item("Contents").ToString().Replace("$", ""))) / 100) * CDec(ds.Tables("tbl1").Rows(0).Item("ContentAddRate").ToString().Replace("$", "")) & " </td></tr> "
            '    standtot += ((CDec(txt_pp_amslicRent.Text) - CDec(ds.Tables("tbl1").Rows(0).Item("Contents").ToString().Replace("$", ""))) / 100) * CDec(ds.Tables("tbl1").Rows(0).Item("ContentAddRate").ToString().Replace("$", ""))
            '    standopt += ((CDec(txt_pp_amslicRent.Text) - CDec(ds.Tables("tbl1").Rows(0).Item("Contents").ToString().Replace("$", ""))) / 100) * CDec(ds.Tables("tbl1").Rows(0).Item("ContentAddRate").ToString().Replace("$", ""))
            'Else
            '    txt_pp_amslicRent.Text = ds.Tables("tbl1").Rows(0).Item("Contents").ToString().Replace("$", "")
            '    txt_pp_amslicRent_Amount.Text = "0.00"
            'End If
            amslicRent_Debug.Text += "<tr align=left><td>SUB TOTAL 2</td><td> $" & CInt(standtot) & " </td></tr> "

            amslicRent_Debug.Text += "<tr align=left><td>Policy Fee</td><td> $" & CInt(ds.Tables("tbl1").Rows(0).Item("PolicyFee").ToString().Replace("$", "")) & " </td></tr> "
            standfee += CInt(ds.Tables("tbl1").Rows(0).Item("PolicyFee").ToString().Replace("$", "")).ToString("C2")
            standtot += CInt(ds.Tables("tbl1").Rows(0).Item("PolicyFee").ToString().Replace("$", "")).ToString("C2")
            amslicRent_Debug.Text += "<tr align=left><td>SUB TOTAL 3</td><td> " & CInt(standtot).ToString("C2") & " </td></tr> "
            amslicRent_Debug.Text += "<tr align=left><td>Taxes</td><td> " & CDec(CInt(standtot) * 0.06).ToString("C2") & " </td></tr> "
            amslic_taxRent.Text = CDec(CInt(standtot) * 0.06).ToString("C2")
            standtot += CDec(CInt(standtot) * 0.06)
            amslicRent_Debug.Text += "<tr align=left><td>TOTAL Premium</td><td> " & CDec(standtot).ToString("C2") & " </td></tr> "
            amslic_optionsRent.Text = standopt.ToString("C2")
            amslic_feesRent.Text = standfee.ToString("C2")
            amslic_totalRent.Text = standtot.ToString("C2")
            amslicRent_Debug.Text += "</tbody></table>"
            If amslic_totalRent.Text = "0.00" Then

                amslic_mh_progRent.Visible = False
                amslicOptionRowRent.Visible = False
            End If
            Me.AR_PremiumUpdatePanel.Update()




        Else
            amslic_mh_progRent.Visible = False
            amslicOptionRowRent.Visible = False


        End If

        'Amslic Rental:

    End Sub
    Private Sub errortrap(ByVal sqlcomm As String, ByVal appsub As String, ByVal errormsg As String)
        Dim intRowsAff As Integer
        Dim Connection As String = System.Configuration.ConfigurationManager.ConnectionStrings("ColonialMHConnectionString").ConnectionString
        Dim dbConnection As System.Data.IDbConnection = New System.Data.SqlClient.SqlConnection(Connection)
        Dim cmd As New SqlCommand("sp_InsertError", dbConnection)
        cmd.CommandType = CommandType.StoredProcedure
        cmd.Parameters.Add("@code", SqlDbType.VarChar, 8000).Value = sqlcomm
        cmd.Parameters.Add("@Page", SqlDbType.VarChar, 50).Value = "Lloyd Quote"
        cmd.Parameters.Add("@sub", SqlDbType.VarChar, 50).Value = appsub
        cmd.Parameters.Add("@msg", SqlDbType.VarChar, 8000).Value = errormsg
        Try
            cmd.Connection.Open()
            intRowsAff = cmd.ExecuteNonQuery()
        Catch ex As Exception

        End Try


    End Sub

    Protected Sub SC08_premiumbtnClick3(sender As Object, e As EventArgs) Handles SC08_updateOptions.Click
        SC08_Debug.Text = ""
        mhvaluechanged.Text = "False"
        calcSH08()
        Me.AR_PremiumUpdatePanel.Update()
    End Sub

    Protected Sub select08btn_Click(sender As Object, e As EventArgs) Handles select08btn.Click
        HiddenFieldSelected.Value = "SMH Package"
        rateTypelbl.Text = "Lloyds SMH Package – HO8"
        rateTypelbl.Font.Bold = True
        rateTypelbl.ForeColor = Drawing.Color.Green


        'Set Selected to AR1 in database  Not saving right now...
        Try

            If quoteIDlbl.Text <> "" Then
                Me.Page.GetType.InvokeMember("updateQuote", System.Reflection.BindingFlags.InvokeMethod, Nothing, Me.Page, New Object() {quoteIDlbl.Text})
            Else
                Me.Page.GetType.InvokeMember("save", System.Reflection.BindingFlags.InvokeMethod, Nothing, Me.Page, New Object() {})

            End If
        Catch ex As Exception
            errortrap("UPDATE Lloyds SMH", "SELECTED SMH", ex.Message)
        End Try
        Dim ds As System.Data.DataSet
        ds = runQueryDS("EXEC sp_SetQuoteRateType '" & quoteIDlbl.Text & "', 'SMH Package'", "ColonialMHConnectionString")
        'Check Financing options
        ds = runQueryDS("SELECT ARRateType, state  FROM tblQuotes WHERE quoteID ='" & quoteIDlbl.Text & "'", "ColonialMHConnectionString")
        If ds.Tables(0).Rows.Count > 0 Then
            If ds.Tables(0).Rows(0).Item("state") = "SC" And Not rateTypelbl.Text.ToString.ToUpper.Contains("AEG") Then
                'SCPremFinbtn.Visible = True
                calcSCFinancing()
                'SCFinancingUpdatePanel.Update()
            Else
                'SCPremFinbtn.Visible = False
            End If
        End If


        premiumBtnTable.Attributes.Add("style", "display:block")
    End Sub
    Public Sub calcWMJ()

        mhvalue = MHValuelbl.Text
        mhcounty = mhcountylbl.Text
        mhstate = mhstatelbl.Text
        mhmfg = mhmfglbl.Text
        mhtype = mhtypelbl.Text
        mhyear = mhyearlbl.Text

        If CInt(mhvalue) < 125001 Then


            Dim otherstructures As String
            Dim contents As String
            Dim liability As String
            Dim aop As String
            Dim prg As String
            Dim display As String
            Dim prt As String = "0"
            If protection.Text = "" Then
                prt = "0"
            Else
                prt = protection.Text
            End If
            Dim age As Integer = 0
            If IsDate(lbldob.Text) Then
                age = DateDiff(DateInterval.Year, CDate(lbldob.Text), Date.Now)
                Dim dif As TimeSpan = Date.Now.Subtract(CDate(lbldob.Text))
                age = (dif.TotalDays / 365.25).ToString()
                age = (dif.Days / 365.25).ToString()

                age = Math.Round((DateDiff(DateInterval.Day, CDate(lbldob.Text), Date.Now) / 365))
                If CDate(lbldob.Text).AddYears(age) > Date.Now Then
                    age = age - 1
                End If

            ElseIf lbldob.Text.Length = 8 Then
                Dim dtedob As Date
                dtedob = CDate(lbldob.Text.Substring(0, 2) & "/" & lbldob.Text.Substring(2, 2) & "/" & lbldob.Text.Substring(4, 4))
                age = DateDiff(DateInterval.Year, dtedob, Date.Now)
                If CDate(dtedob).AddYears(age) > Date.Now Then
                    age = age - 1
                End If
                'Dim yr As Integer
                'yr = Date.Now.Year
                'age = yr - CInt(Right(lbldob.Text, 4))

            Else

                age = 0

            End If
            otherstructures = 0
            contents = 0
            liability = 0
            aop = 0
            prg = "Rental"
            If mhusagelbl.Text = "Owner" Or mhusagelbl.Text = "Seasonal" Then
                If mhusagelbl.Text = "Owner" Then
                    prg = "Standard"
                Else
                    prg = "Seasonal"
                End If

                aop = dd_aop_wmj1.SelectedValue
                If IsNumeric(txt_unattstr_wmj1.Text) Then
                    If CInt(txt_unattstr_wmj1.Text) <> (MHValuelbl.Text * 0.1) And txt_unattstr_wmj1.Text <> "0.00" Then
                        otherstructures = txt_unattstr_wmj1.Text
                    Else
                        txt_unattstr_wmj1.Text = (MHValuelbl.Text * 0.01)
                        otherstructures = txt_unattstr_wmj1.Text
                    End If

                Else
                    otherstructures = "0"
                End If
                If IsNumeric(txt_pp_wmj1.Text) Then
                    If dd_rep_wmj1.SelectedValue = "Yes" Then
                        If (CInt(txt_pp_wmj1.Text) <> (MHValuelbl.Text * 0.7)) And txt_pp_wmj1.Text <> "0.00" Then
                            If (CInt(txt_pp_wmj1.Text) < (MHValuelbl.Text * 0.7)) Then
                                txt_pp_wmj1.Text = (MHValuelbl.Text * 0.7)
                                contents = txt_pp_wmj1.Text
                            Else
                                contents = txt_pp_wmj1.Text
                            End If

                        Else
                            txt_pp_wmj1.Text = (MHValuelbl.Text * 0.7)
                            contents = txt_pp_wmj1.Text
                        End If
                    Else

                        If (CInt(txt_pp_wmj1.Text) <> (MHValuelbl.Text * 0.5)) And txt_pp_wmj1.Text <> "0.00" Then
                            contents = txt_pp_wmj1.Text
                        Else
                            txt_pp_wmj1.Text = (MHValuelbl.Text * 0.5)
                            contents = txt_pp_wmj1.Text
                        End If
                    End If


                Else
                    contents = 0
                End If
                If mhvaluechanged.Text = "True" Then
                    txt_unattstr_wmj1.Text = (MHValuelbl.Text * 0.1)
                    otherstructures = txt_unattstr_wmj1.Text
                    txt_pp_wmj1.Text = (MHValuelbl.Text * 0.5)
                    contents = txt_pp_wmj1.Text

                End If

                liability = dd_pl_wmj1.SelectedValue

                display = "Standard"

                dd_mp_wmj1.SelectedValue = "$500"



            End If


            Dim Connection As String = System.Configuration.ConfigurationManager.ConnectionStrings("ColonialMHConnectionString").ConnectionString
            Dim dbConnection As System.Data.IDbConnection = New System.Data.SqlClient.SqlConnection(Connection)
            Dim cmd As New SqlCommand("sp_GetWMJRates", dbConnection)
            cmd.CommandType = CommandType.StoredProcedure
            cmd.Parameters.Add("@mhValue", SqlDbType.VarChar, 8000).Value = CInt(mhvalue)
            cmd.Parameters.Add("@mhYear", SqlDbType.VarChar, 8000).Value = CInt(mhyear)
            cmd.Parameters.Add("@prot", SqlDbType.VarChar, 8000).Value = CInt(prt)
            cmd.Parameters.Add("@oStruc", SqlDbType.VarChar, 8000).Value = CInt(otherstructures.Replace("$", "").Replace(",", ""))
            cmd.Parameters.Add("@cont", SqlDbType.VarChar, 8000).Value = CInt(contents.Replace("$", "").Replace(",", ""))
            cmd.Parameters.Add("@age", SqlDbType.VarChar, 8000).Value = age '"49"  'Need to get this from quote screen
            cmd.Parameters.Add("@liability", SqlDbType.VarChar, 8000).Value = CInt(liability.Replace("$", "").Replace(",", ""))
            cmd.Parameters.Add("@AOP", SqlDbType.VarChar, 8000).Value = CInt(aop.Replace("$", "").Replace(",", ""))
            cmd.Parameters.Add("@county", SqlDbType.VarChar, 8000).Value = mhcounty
            cmd.Parameters.Add("@type", SqlDbType.VarChar, 8000).Value = prg


            Try
                Dim ds As Data.DataSet = New Data.DataSet

                cmd.Connection.Open()
                ' intRowsAff = cmd.ExecuteNonQuery()

                Dim myCommand = New SqlDataAdapter(cmd)
                myCommand.Fill(ds, "tbl1")
                If ds.Tables("tbl1").Rows.Count > 0 Then
                    Select Case display
                        Case "Standard"
                            wmj_mh_prog2.Visible = True

                            wmj_mh_prog2_Options.Visible = True

                            WMJStandCalc(ds)
                            'check for personal property


                    End Select
                Else
                    'Hide WMJ 
                    wmj_mh_prog2.Visible = False
                    wmj_mh_prog2_Options.Visible = False
                    AR_PremiumUpdatePanel.Update()

                End If

            Catch ex As Exception
                Dim s As String = ""
                For Each param As SqlParameter In cmd.Parameters
                    s += param.ParameterName & "="
                    s += param.Value & ":  "

                Next
                errortrap("Geting Calculation data " & s, "Calculation WMJ", ex.Message)
            End Try
        End If
    End Sub
    Public Sub calcWMJNC()

        mhvalue = MHValuelbl.Text
        mhcounty = mhcountylbl.Text
        mhstate = mhstatelbl.Text
        mhmfg = mhmfglbl.Text
        mhtype = mhtypelbl.Text
        mhyear = mhyearlbl.Text

        Dim Connection As String = System.Configuration.ConfigurationManager.ConnectionStrings("ColonialMHConnectionString").ConnectionString
        Dim dbConnection As System.Data.IDbConnection = New System.Data.SqlClient.SqlConnection(Connection)
        Dim cmd As New SqlCommand("sp_wmjgetRatesNC", dbConnection)
        cmd.CommandType = CommandType.StoredProcedure
        cmd.Parameters.Add("@mhValue", SqlDbType.VarChar, 8000).Value = CInt(mhvalue)

        Try
            Dim ds As Data.DataSet = New Data.DataSet

            cmd.Connection.Open()
            ' intRowsAff = cmd.ExecuteNonQuery()

            Dim myCommand = New SqlDataAdapter(cmd)
            myCommand.Fill(ds, "tbl1")
            If ds.Tables("tbl1").Rows.Count > 0 Then


                WMJStandCalcNC(ds)

            Else
                'Hide WMJ 
                wmj_mh_prog2.Visible = False
                wmj_mh_prog2_Options.Visible = False

            End If

        Catch ex As Exception
            Dim s As String = ""
            For Each param As SqlParameter In cmd.Parameters
                s += param.ParameterName & "="
                s += param.Value & ":  "

            Next
            errortrap("Geting Calculation data " & s, "Calculation WMJ NC", ex.Message)
        End Try

    End Sub
    Public Sub calcAegis()

        mhvalue = MHValuelbl.Text
        mhcounty = mhcountylbl.Text
        mhstate = mhstatelbl.Text
        mhmfg = mhmfglbl.Text
        mhtype = mhtypelbl.Text
        mhyear = mhyearlbl.Text

        If CInt(mhvalue) < 125001 Then


            Dim otherstructures As String
            Dim contents As String
            Dim liability As String
            Dim aop As String
            Dim prg As String
            Dim display As String
            Dim prt As String = "0"
            If protection.Text = "" Then
                prt = "0"
            Else
                prt = protection.Text
            End If
            Dim age As Integer = 0
            If IsDate(lbldob.Text) Then
                age = DateDiff(DateInterval.Year, CDate(lbldob.Text), Date.Now)
                Dim dif As TimeSpan = Date.Now.Subtract(CDate(lbldob.Text))
                age = (dif.TotalDays / 365.25).ToString()
                age = (dif.Days / 365.25).ToString()

                age = Math.Round((DateDiff(DateInterval.Day, CDate(lbldob.Text), Date.Now) / 365))
                If CDate(lbldob.Text).AddYears(age) > Date.Now Then
                    age = age - 1
                End If

            ElseIf lbldob.Text.Length = 8 Then
                Dim dtedob As Date
                dtedob = CDate(lbldob.Text.Substring(0, 2) & "/" & lbldob.Text.Substring(2, 2) & "/" & lbldob.Text.Substring(4, 4))
                age = DateDiff(DateInterval.Year, dtedob, Date.Now)
                If CDate(dtedob).AddYears(age) > Date.Now Then
                    age = age - 1
                End If
                'Dim yr As Integer
                'yr = Date.Now.Year
                'age = yr - CInt(Right(lbldob.Text, 4))

            Else

                age = 0

            End If

            If mhusagelbl.Text = "Owner" Or mhusagelbl.Text = "Seasonal" Then
                If mhusagelbl.Text = "Owner" Then
                    prg = "Standard"
                Else
                    prg = "Seasonal"
                End If

                aop = dd_aop_aiges1.SelectedValue
                If IsNumeric(txt_unattstr_aiges1.Text) Then
                    otherstructures = txt_unattstr_aiges1.Text
                Else
                    otherstructures = "0"
                End If
                If IsNumeric(txt_pp_aiges1.Text) Then
                    contents = txt_pp_aiges1.Text
                Else
                    contents = 0
                End If

                liability = dd_pl_aiges1.SelectedValue

                display = "Standard"

                'dd_mp_aiges1.SelectedValue = "$500"


            Else
                'rental
                display = "Rental"
                prg = "Standard"
                aop = dd_aop_aiges2.SelectedValue
                If IsNumeric(txt_unattstr_aiges2.Text) Then
                    otherstructures = txt_unattstr_aiges2.Text
                Else
                    otherstructures = "0"
                End If
                If IsNumeric(dd_aegiscontentsrental.Text) Then
                    If CInt(dd_aegiscontentsrental.Text) > 5000 Then
                        dd_aegiscontentsrental.Text = 5000
                    End If
                    contents = dd_aegiscontentsrental.Text
                Else

                    contents = 0
                End If
                'If IsNumeric(txt_pp_aiges2.Text) Then
                '    contents = txt_pp_aiges2.Text
                'Else
                '    contents = 0
                'End If
                liability = dd_pl_aiges2.SelectedValue
                If liability = "" Then
                    liability = "0"
                End If
                'contents = 0
            End If


            Dim Connection As String = System.Configuration.ConfigurationManager.ConnectionStrings("ColonialMHConnectionString").ConnectionString
            Dim dbConnection As System.Data.IDbConnection = New System.Data.SqlClient.SqlConnection(Connection)
            Dim cmd As New SqlCommand("sp_GetAegisRates", dbConnection)
            cmd.CommandType = CommandType.StoredProcedure
            cmd.Parameters.Add("@mhValue", SqlDbType.VarChar, 8000).Value = CInt(mhvalue)
            cmd.Parameters.Add("@mhYear", SqlDbType.VarChar, 8000).Value = CInt(mhyear)
            cmd.Parameters.Add("@prot", SqlDbType.VarChar, 8000).Value = CInt(prt)
            cmd.Parameters.Add("@oStruc", SqlDbType.VarChar, 8000).Value = CInt(otherstructures.Replace("$", "").Replace(",", ""))
            cmd.Parameters.Add("@cont", SqlDbType.VarChar, 8000).Value = CInt(contents.Replace("$", "").Replace(",", ""))
            cmd.Parameters.Add("@age", SqlDbType.VarChar, 8000).Value = age '"49"  'Need to get this from quote screen
            cmd.Parameters.Add("@liability", SqlDbType.VarChar, 8000).Value = CInt(liability.Replace("$", "").Replace(",", ""))
            cmd.Parameters.Add("@AOP", SqlDbType.VarChar, 8000).Value = CInt(aop.Replace("$", "").Replace(",", ""))
            cmd.Parameters.Add("@county", SqlDbType.VarChar, 8000).Value = mhcounty
            cmd.Parameters.Add("@type", SqlDbType.VarChar, 8000).Value = prg
            cmd.Parameters.Add("@effdate", SqlDbType.VarChar, 8000).Value = lbleffdate.Text
            cmd.Parameters.Add("@territory", SqlDbType.VarChar, 8000).Value = aegisterritorylbl.Text

            Try
                Dim ds As Data.DataSet = New Data.DataSet

                cmd.Connection.Open()
                ' intRowsAff = cmd.ExecuteNonQuery()

                Dim myCommand = New SqlDataAdapter(cmd)
                myCommand.Fill(ds, "tbl1")
                If ds.Tables("tbl1").Rows.Count > 0 Then
                    Select Case display
                        Case "Standard"
                            aiges_mh_prog2.Visible = True
                            aiges_mh_prog2_Options.Visible = True
                            aiges_mh_prog3.Visible = False
                            aiges_mh_prog3_Options1.Visible = False
                            If CDate(lbleffdate.Text) >= CDate("04/15/2014") Then
                                AegisStandCalcNew(ds)
                            Else
                                AegisStandCalc(ds)
                            End If
                            ' AegisStandCalc(ds)
                            'check for personal property

                        Case "Rental"
                            If supheatlbl.Text = "Yes" Then
                                aiges_mh_prog3.Visible = False
                                aiges_mh_prog3_Options1.Visible = False
                            Else

                                aiges_mh_prog2.Visible = False
                                aiges_mh_prog2_Options.Visible = False
                                aiges_mh_prog3.Visible = True
                                aiges_mh_prog3_Options1.Visible = True
                                If lblaiges_ShowOptions3_hidden.Value = "- Show Options" Then
                                    aiges_mh_prog3_Options1.Style.Add("display", "block")
                                    Table2.Style.Add("display", "block")
                                    lblaiges_ShowOptions3.InnerText = "- Show Options"
                                Else
                                    aiges_mh_prog3_Options1.Style.Add("display", "none")
                                    Table2.Style.Add("display", "none")
                                    lblaiges_ShowOptions3.InnerText = "+ Show Options"
                                End If
                                ' aiges_mh_prog3_Options1.Visible = False
                                If CDate(lbleffdate.Text) >= CDate("04/15/2014") Then
                                    AegisRentCalcNew(ds)
                                Else
                                    AegisRentCalc(ds)
                                End If
                                ' AegisRentCalc(ds)
                            End If
                    End Select
                Else
                    'Hide aegis 
                    aiges_mh_prog2.Visible = False
                    aiges_mh_prog2_Options.Visible = False
                    aiges_mh_prog3.Visible = False
                    aiges_mh_prog3_Options1.Visible = False
                End If

            Catch ex As Exception
                Dim s As String = ""
                For Each param As SqlParameter In cmd.Parameters
                    s += param.ParameterName & "="
                    s += param.Value & ":  "

                Next
                errortrap("Geting Calculation data " & s, "Calculation Aegis", ex.Message)
            End Try
        End If
    End Sub
    Public Sub AegisCalcVint()
        mhvalue = MHValuelbl.Text
        mhcounty = mhcountylbl.Text
        mhstate = mhstatelbl.Text
        mhmfg = mhmfglbl.Text
        mhtype = mhtypelbl.Text
        mhyear = mhyearlbl.Text

        If CInt(mhvalue) < 125001 Then


            Dim otherstructures As String
            Dim contents As String
            Dim liability As String
            Dim aop As String
            Dim prg As String
            Dim display As String
            Dim prt As String = "0"
            If protection.Text = "" Then
                prt = "0"
            Else
                prt = protection.Text
            End If
            Dim age As Integer = 0
            If IsDate(lbldob.Text) Then
                age = DateDiff(DateInterval.Year, CDate(lbldob.Text), Date.Now)
                Dim dif As TimeSpan = Date.Now.Subtract(CDate(lbldob.Text))
                age = (dif.TotalDays / 365.25).ToString()
                age = (dif.Days / 365.25).ToString()

                age = Math.Round((DateDiff(DateInterval.Day, CDate(lbldob.Text), Date.Now) / 365))
                If CDate(lbldob.Text).AddYears(age) > Date.Now Then
                    age = age - 1
                End If

            ElseIf lbldob.Text.Length = 8 Then
                Dim dtedob As Date
                dtedob = CDate(lbldob.Text.Substring(0, 2) & "/" & lbldob.Text.Substring(2, 2) & "/" & lbldob.Text.Substring(4, 4))
                age = DateDiff(DateInterval.Year, dtedob, Date.Now)
                If CDate(dtedob).AddYears(age) > Date.Now Then
                    age = age - 1
                End If
                'Dim yr As Integer
                'yr = Date.Now.Year
                'age = yr - CInt(Right(lbldob.Text, 4))

            Else

                age = 0

            End If

            If mhusagelbl.Text = "Owner" Or mhusagelbl.Text = "Seasonal" Then
                If mhusagelbl.Text = "Owner" Then
                    prg = "Standard"
                Else
                    prg = "Seasonal"
                End If

                aop = "0" 'dd_aop_aiges1.SelectedValue
                If IsNumeric(txt_unattstr_Aegisvintsc1.Text) Then
                    If CInt(txt_unattstr_Aegisvintsc1.Text) > (CInt(MHValuelbl.Text) * 0.05) Then
                        txt_unattstr_Aegisvintsc1.Text = (CInt(MHValuelbl.Text) * 0.05)
                    End If
                    otherstructures = txt_unattstr_Aegisvintsc1.Text
                Else
                    otherstructures = "0"
                End If
                If IsNumeric(txt_pp_Aegisvintsc1.Text) Then
                    If CInt(txt_pp_Aegisvintsc1.Text) > (CInt(MHValuelbl.Text) * 0.3) Then
                        If CInt(txt_pp_Aegisvintsc1.Text) > 5000 Then
                            txt_pp_Aegisvintsc1.Text = "5000"
                        Else
                            txt_pp_Aegisvintsc1.Text = (CInt(MHValuelbl.Text) * 0.3)

                        End If

                    End If
                    contents = txt_pp_Aegisvintsc1.Text
                Else
                    contents = 0
                End If

                liability = dd_pl_Aegisvintsc1.SelectedValue

                display = "Standard"

                ' dd_mp_aiges1.SelectedValue = "$500"


            Else
                'rental
                display = "Rental"
                prg = "Standard"
                aop = "500" 'dd_aop_aiges2.SelectedValue
                'If IsNumeric(txt_unattstr_Aegisvintsc1.Text) Then
                '    otherstructures = txt_unattstr_Aegisvintsc1.Text
                'Else
                '    otherstructures = "0"
                'End If
                If IsNumeric(txt_unattstr_Aegisvintsc1.Text) Then
                    If CInt(txt_unattstr_Aegisvintsc1.Text) > (CInt(MHValuelbl.Text) * 0.05) Then
                        txt_unattstr_Aegisvintsc1.Text = (CInt(MHValuelbl.Text) * 0.05)
                    End If
                    otherstructures = txt_unattstr_Aegisvintsc1.Text
                Else
                    otherstructures = "0"
                End If
                If IsNumeric(txt_pp_Aegisvintsc1.Text) Then
                    If CInt(txt_pp_Aegisvintsc1.Text) > (CInt(MHValuelbl.Text) * 0.3) Or CInt(txt_pp_Aegisvintsc1.Text) > 5000 Then
                        If CInt(txt_pp_Aegisvintsc1.Text) > 5000 Then
                            txt_pp_Aegisvintsc1.Text = "5000"
                        Else
                            txt_pp_Aegisvintsc1.Text = (CInt(MHValuelbl.Text) * 0.3)

                        End If

                    End If
                    contents = txt_pp_Aegisvintsc1.Text
                Else
                    contents = 0
                End If

                'If IsNumeric(txt_pp_aiges2.Text) Then
                '    contents = txt_pp_aiges2.Text
                'Else
                '    contents = 0
                'End If
                liability = dd_pl_Aegisvintsc1.SelectedValue
                If liability = "" Then
                    liability = "0"
                End If
                contents = 0
            End If


            Dim Connection As String = System.Configuration.ConfigurationManager.ConnectionStrings("ColonialMHConnectionString").ConnectionString
            Dim dbConnection As System.Data.IDbConnection = New System.Data.SqlClient.SqlConnection(Connection)
            Dim cmd As New SqlCommand("sp_GetAegisRates", dbConnection)
            cmd.CommandType = CommandType.StoredProcedure
            cmd.Parameters.Add("@mhValue", SqlDbType.VarChar, 8000).Value = CInt(mhvalue)
            cmd.Parameters.Add("@mhYear", SqlDbType.VarChar, 8000).Value = CInt(mhyear)
            cmd.Parameters.Add("@prot", SqlDbType.VarChar, 8000).Value = CInt(prt)
            cmd.Parameters.Add("@oStruc", SqlDbType.VarChar, 8000).Value = CInt(otherstructures.Replace("$", "").Replace(",", ""))
            cmd.Parameters.Add("@cont", SqlDbType.VarChar, 8000).Value = CInt(contents.Replace("$", "").Replace(",", ""))
            cmd.Parameters.Add("@age", SqlDbType.VarChar, 8000).Value = age '"49"  'Need to get this from quote screen
            cmd.Parameters.Add("@liability", SqlDbType.VarChar, 8000).Value = CInt(liability.Replace("$", "").Replace(",", ""))
            cmd.Parameters.Add("@AOP", SqlDbType.VarChar, 8000).Value = CInt(aop.Replace("$", "").Replace(",", ""))
            cmd.Parameters.Add("@county", SqlDbType.VarChar, 8000).Value = mhcounty
            cmd.Parameters.Add("@type", SqlDbType.VarChar, 8000).Value = prg
            cmd.Parameters.Add("@effdate", SqlDbType.VarChar, 8000).Value = lbleffdate.Text
            cmd.Parameters.Add("@territory", SqlDbType.VarChar, 8000).Value = aegisterritorylbl.Text

            Try
                Dim ds As Data.DataSet = New Data.DataSet

                cmd.Connection.Open()
                ' intRowsAff = cmd.ExecuteNonQuery()

                Dim myCommand = New SqlDataAdapter(cmd)
                myCommand.Fill(ds, "tbl1")
                If ds.Tables("tbl1").Rows.Count > 0 Then
                    Select Case display
                        Case "Standard"
                            aiges_mh_prog2.Visible = True
                            aiges_mh_prog2_Options.Visible = True
                            aiges_mh_prog3.Visible = False
                            aiges_mh_prog3_Options1.Visible = False
                            AegisVintageCalc(ds)
                            'If CDate(lbleffdate.Text) >= CDate("04/15/2014") Then
                            '    AegisStandCalcNew(ds)
                            'Else
                            '    AegisStandCalc(ds)
                            'End If
                            ' AegisStandCalc(ds)
                            'check for personal property

                        Case "Rental"
                            AegisVintageCalc(ds)
                            'If supheatlbl.Text = "Yes" Then
                            '    aiges_mh_prog3.Visible = False
                            '    aiges_mh_prog3_Options1.Visible = False
                            'Else

                            '    aiges_mh_prog2.Visible = False
                            '    aiges_mh_prog2_Options.Visible = False
                            '    aiges_mh_prog3.Visible = True
                            '    aiges_mh_prog3_Options1.Visible = True
                            '    If lblaiges_ShowOptions3_hidden.Value = "- Show Options" Then
                            '        aiges_mh_prog3_Options1.Style.Add("display", "block")
                            '        Table2.Style.Add("display", "block")
                            '        lblaiges_ShowOptions3.InnerText = "- Show Options"
                            '    Else
                            '        aiges_mh_prog3_Options1.Style.Add("display", "none")
                            '        Table2.Style.Add("display", "none")
                            '        lblaiges_ShowOptions3.InnerText = "+ Show Options"
                            '    End If
                            '    aiges_mh_prog3_Options1.Visible = False
                            '    If CDate(lbleffdate.Text) >= CDate("04/15/2014") Then
                            '        AegisRentCalcNew(ds)
                            '    Else
                            '        AegisRentCalc(ds)
                            '    End If
                            '    AegisRentCalc(ds)
                            'End If
                    End Select
                Else
                    'Hide aegis 
                    aiges_mh_prog2.Visible = False
                    aiges_mh_prog2_Options.Visible = False
                    aiges_mh_prog3.Visible = False
                    aiges_mh_prog3_Options1.Visible = False
                End If

            Catch ex As Exception
                Dim s As String = ""
                For Each param As SqlParameter In cmd.Parameters
                    s += param.ParameterName & "="
                    s += param.Value & ":  "

                Next
                errortrap("Geting Calculation data " & s, "Calculation Aegis Vintage", ex.Message)
            End Try
        End If
    End Sub
    Public Sub AegisVintageCalc(ByVal ds As DataSet)
        Dim smhprem As String
        Dim aegisopt As String

        Dim smhtotal As Decimal


       
        Aegisvint_medpaysc1.Text = "$500" 'dd_mp_aiges1.SelectedValue()

        If dd_pl_aiges1.SelectedValue() = "$0" Then



            dd_pl_aiges1.SelectedValue() = "$" & CInt(ds.Tables("tbl1").Rows(0).Item("LiabilityLimit").ToString().Replace("$", "")).ToString("N0")

        End If
        Aegisvint_perLiabsc1.Text = dd_pl_Aegisvintsc1.SelectedValue
        Select Case ds.Tables("tbl1").Rows(0).Item("territory").ToString()
            Case "1"
                If CInt(MHValuelbl.Text) <= 24999 Then
                    dd_hurded_Aegisvintsc1.Text = "2500"
                    dd_wind_Aegisvintsc1.Text = "2000"
                    AegisvintWind.Visible = True
                    aegisvintageWindhur1.Visible = True
                Else
                    AegisvintWind.Visible = False
                End If
                If CInt(MHValuelbl.Text) >= 25000 Then
                    dd_hurded_Aegisvintsc1.Text = "5000"
                    dd_wind_Aegisvintsc1.Text = "2000"
                    AegisvintWind.Visible = True
                    aegisvintageWindhur1.Visible = True
                Else
                    'aegiswind2.Visible = False
                    'aegisWindhur2.Visible = False
                End If
            Case "2"
                ' If CInt(MHValuelbl.Text) > 24999 Then
                dd_hurded_Aegisvintsc1.Text = "5000"
                dd_wind_Aegisvintsc1.Text = "1000"
                AegisvintWind.Visible = False
                aegisvintageWindhur1.Visible = True
                ' Else
                'aegiswind2.Visible = False
                'aegisWindhur2.Visible = False


                ' End If
            Case "3"
                ' If CInt(MHValuelbl.Text) > 24999 Then
                dd_hurded_Aegisvintsc1.Text = "5000"
                dd_wind_Aegisvintsc1.Text = "1000"
                AegisvintWind.Visible = False
                aegisvintageWindhur1.Visible = True
                ' Else
                'aegiswind2.Visible = False
                'aegisWindhur2.Visible = False

                ' End If
            Case "4"
                AegisvintWind.Visible = False
                aegisvintageWindhur1.Visible = False
            Case "5"
                ' If CInt(MHValuelbl.Text) > 24999 Then
                dd_hurded_Aegisvintsc1.Text = "1500"
                dd_wind_Aegisvintsc1.Text = "1000"
                AegisvintWind.Visible = True
                aegisvintageWindhur1.Visible = True
                'Else
                'aegiswind2.Visible = False
                'aegisWindhur2.Visible = False


                ' End If
            Case "6"
                ' If CInt(MHValuelbl.Text) > 24999 Then
                dd_hurded_Aegisvintsc1.Text = "1500"
                dd_wind_Aegisvintsc1.Text = "1500"
                AegisvintWind.Visible = True
                aegisvintageWindhur1.Visible = True
                ' Else
                'aegiswind2.Visible = False
                'aegisWindhur2.Visible = False


                ' End If
        End Select


        If mhusagelbl.Text = "Rental" Then


            Aegisvintsc1_Debug.Text = "<table> <tbody>"
            Aegisvintsc1_Debug.Text = "<table> <tbody>"
            Aegisvint_dwellsc1.Text = "$" & mhvalue.Replace("$", "")
            Aegisvint_unattStrsc1.Text = "$" & txt_unattstr_Aegisvintsc1.Text.Replace("$", "")
            Aegisvint_perEffsc1.Text = "$" & txt_pp_Aegisvintsc1.Text.Replace("$", "")
            Aegisvint_perLiabsc1.Text = "$" & dd_pl_Aegisvintsc1.SelectedValue().Replace("$", "")
            Aegisvint_medpaysc1.Text = "$" & Aegisvint_medpaysc1.Text.Replace("$", "")


            smhprem = ds.Tables("tbl1").Rows(0).Item("RentPrem").ToString().Replace("$", "")

            If dd_pl_Aegisvintsc1.SelectedValue = "$25,000" Then
                dd_mp_Aegisvintsc1.SelectedValue = "$500"
            Else

                dd_mp_Aegisvintsc1.SelectedValue = "$0"
            End If




            Aegisvintsc1_Debug.Text += "<tr align=left><td>Package Premium </td><td> $" & CInt(smhprem) & " </td></tr> "
            aegispackvintpremlbl.Text = CInt(smhprem)
            Aegisvintsc1_Debug.Text += "<tr align=left><td>Other Structures </td><td> $" & CInt(ds.Tables("tbl1").Rows(0).Item("RentASstruc").ToString().Replace("$", "")) & " </td></tr> "
            txt_unattstr_Aegisvintsc1_Amount.Text = CInt(ds.Tables("tbl1").Rows(0).Item("RentASstruc").ToString().Replace("$", ""))


            Aegisvintsc1_Debug.Text += "<tr align=left><td>Addl Living Expense</td><td> $" & CInt("0") & " </td></tr> "

            smhtotal = CInt(smhprem) + CInt(ds.Tables("tbl1").Rows(0).Item("RentASstruc").ToString().Replace("$", ""))
            Aegisvintsc1_Debug.Text += "<tr align=left><td>Sub Premium</td><td> $" & CInt(smhtotal) & " </td></tr> "

            Aegisvint_basepremsc1.Text = "$" & CInt(smhtotal)
            Aegisvintsc1_Debug.Text += "<tr align=left><td>Base Premium</td><td> $" & CInt(smhtotal) & " </td></tr> "

            Aegisvintsc1_Debug.Text += "<tr align=left><td>Landlord Liability</td><td> $" & CInt(ds.Tables("tbl1").Rows(0).Item("rentLiability").ToString()) & " </td></tr> "
            dd_pl_Aegisvintsc1_Amount.Text = CInt(ds.Tables("tbl1").Rows(0).Item("rentLiability").ToString())
            aegisopt += CInt(ds.Tables("tbl1").Rows(0).Item("rentLiability").ToString())
            smhtotal += CInt(ds.Tables("tbl1").Rows(0).Item("rentLiability").ToString())

            Aegisvintsc1_Debug.Text += "<tr align=left><td>Medical Payment</td><td> $ 0  </td></tr> "

            Dim aegiscredit As Decimal

            Aegisvintsc1_Debug.Text += "<tr align=left><td>SUB TOTAL 2</td><td> $" & CInt(smhtotal) & " </td></tr> "



            Aegisvintsc1_Debug.Text += "<tr align=left><td>SUB TOTAL 3</td><td> $" & CInt(smhtotal) & " </td></tr> "




            Aegisvintsc1_Debug.Text += "<tr align=left><td>SUB TOTAL 4</td><td> $" & smhtotal & " </td></tr> "


            Aegisvintsc1_Debug.Text += "<tr align=left><td>SUB TOTAL 5</td><td> $" & smhtotal & " </td></tr> "



            'aiges_options3.Text = aegisopt.ToString("C2")
            Aegisvintsc1_Debug.Text += "<tr align=left><td>Total Prem</td><td> " & smhtotal.ToString("C2") & " </td></tr> "

            If smhtotal < 100 Then
                Aegisvintsc1_Debug.Text += "<tr align=left><td>Minimum Prem</td><td> $100 </td></tr> "
                Aegisvint_totalsc1.Text = "$100"
            Else
                Aegisvint_totalsc1.Text = smhtotal.ToString("C2")
            End If

            Aegisvintsc1_Debug.Text += "</tbody></table>"
        Else
            If IsNumeric(txt_unattstr_Aegisvintsc1.Text) And txt_unattstr_Aegisvintsc1.Text <> "0.00" Then
                If CInt(ds.Tables("tbl1").Rows(0).Item("UAStructure").ToString().Replace("$", "")) > CInt(txt_unattstr_Aegisvintsc1.Text) Then
                    txt_unattstr_Aegisvintsc1.Text = ds.Tables("tbl1").Rows(0).Item("UAStructure").ToString().Replace("$", "")
                End If
            Else
                txt_unattstr_Aegisvintsc1.Text = ds.Tables("tbl1").Rows(0).Item("UAStructure").ToString().Replace("$", "")

            End If
            If IsNumeric(txt_pp_Aegisvintsc1.Text) And txt_pp_Aegisvintsc1.Text <> "0.00" Then
                If CInt(ds.Tables("tbl1").Rows(0).Item("PPlimit").ToString().Replace("$", "")) > CInt(txt_pp_Aegisvintsc1.Text) Then
                    txt_pp_Aegisvintsc1.Text = ds.Tables("tbl1").Rows(0).Item("PPlimit").ToString().Replace("$", "")
                End If
            Else
                txt_pp_Aegisvintsc1.Text = ds.Tables("tbl1").Rows(0).Item("PPlimit").ToString().Replace("$", "")
            End If
            Aegisvintsc1_Debug.Text = "<table> <tbody>"
            Aegisvint_dwellsc1.Text = "$" & mhvalue.Replace("$", "")
            Aegisvint_unattStrsc1.Text = "$" & txt_unattstr_Aegisvintsc1.Text.Replace("$", "")
            Aegisvint_perEffsc1.Text = "$" & txt_pp_Aegisvintsc1.Text.Replace("$", "")
            Aegisvint_perLiabsc1.Text = "$" & dd_pl_Aegisvintsc1.SelectedValue().Replace("$", "")
            Aegisvint_medpaysc1.Text = "$" & Aegisvint_medpaysc1.Text.Replace("$", "")


            smhprem = "$" & ds.Tables("tbl1").Rows(0).Item("Prem").ToString().Replace("$", "")


            Aegisvintsc1_Debug.Text += "<tr align=left><td>Package Premium </td><td> $" & CInt(smhprem) & " </td></tr> "
            aegispackpremlbl.Text = CInt(smhprem)
            ''added

            Select Case ds.Tables("tbl1").Rows(0).Item("territory").ToString()
                Case "1"
                    smhprem = smhprem * 1.0
                    Aegisvintsc1_Debug.Text += "<tr align=left><td>Territory Factor 1.00 </td><td> $" & CInt(smhprem) & " </td></tr> "
                Case "2"
                    smhprem = smhprem * 1.09
                    Aegisvintsc1_Debug.Text += "<tr align=left><td>Territory Factor 1.09 </td><td> $" & CInt(smhprem) & " </td></tr> "
                Case "3"
                    smhprem = smhprem * 0.66
                    Aegisvintsc1_Debug.Text += "<tr align=left><td>Territory Factor .66 </td><td> $" & CInt(smhprem) & " </td></tr> "
                Case "4"
                    smhprem = smhprem * 0.61
                    Aegisvintsc1_Debug.Text += "<tr align=left><td>Territory Factor .61 </td><td> $" & CInt(smhprem) & " </td></tr> "
                Case "5"
                    smhprem = smhprem * 1.09
                    Aegisvintsc1_Debug.Text += "<tr align=left><td>Territory Factor 1.09 </td><td> $" & CInt(smhprem) & " </td></tr> "
                Case "6"
                    smhprem = smhprem * 0.66
                    Aegisvintsc1_Debug.Text += "<tr align=left><td>Territory Factor .66 </td><td> $" & CInt(smhprem) & " </td></tr> "

            End Select
            Dim age As Integer
            Dim agefactor As Decimal
            age = Date.Now.Year - CInt(mhyearlbl.Text)
            If age >= 0 And age <= 10 Then
                agefactor = 0.9
                Aegisvintsc1_Debug.Text += "<tr align=left><td>MH Age Factor 0.9 </td><td> $" & CInt(smhprem) * agefactor & " </td></tr> "
                smhprem = CInt(smhprem) * agefactor
            End If
            If age >= 11 And age <= 25 Then
                agefactor = 1.0
                Aegisvintsc1_Debug.Text += "<tr align=left><td>MH Age Factor 1.0 </td><td> $" & CInt(smhprem) * agefactor & " </td></tr> "
                smhprem = CInt(smhprem) * agefactor
            End If
            If age >= 36 Then
                agefactor = 1.11
                Aegisvintsc1_Debug.Text += "<tr align=left><td>MH Age Factor 1.11 </td><td> $" & CInt(smhprem) * agefactor & " </td></tr> "
                smhprem = CInt(smhprem) * agefactor
            End If
            'If age = 2 Or age = 3 Then
            '    agefactor = 0.9
            'End If
            'Aegisvintsc1_Debug.Text += "<tr align=left><td>MH Age Factor </td><td> $" & agefactor & " </td></tr> "
            'smhprem = CInt(smhprem) * agefactor
            Dim protfactor As Decimal
            If CInt(protection.Text) > 0 And CInt(protection.Text) < 10 Then
                protfactor = 1.0
                Aegisvintsc1_Debug.Text += "<tr align=left><td>Protection Class Factor 1.0 </td><td> $" & CInt(smhprem) * protfactor & " </td></tr> "
                smhprem = CInt(smhprem) * protfactor
            Else
                protfactor = 1.11
                Aegisvintsc1_Debug.Text += "<tr align=left><td>Protection Class Factor 1.11 </td><td> $" & CInt(smhprem) * protfactor & " </td></tr> "
                smhprem = CInt(smhprem) * protfactor
            End If

            Dim appage As Integer
            Dim dob As String
            If lbldob.Text.Length = 8 Then
                dob = lbldob.Text.Substring(0, 2) & "/" & lbldob.Text.Substring(2, 2) & "/" & lbldob.Text.Substring(4, 4)
            Else
                dob = lbldob.Text
            End If
            appage = DateDiff(DateInterval.Year, CDate(dob), Date.Now)
            If appage < 50 Then
                Aegisvintsc1_Debug.Text += "<tr align=left><td>Age of Insured Factor 1.27 </td><td> $" & CInt(smhprem) * 1.27 & "  </td></tr> "
                smhprem = CInt(smhprem) * 1.27
            Else
                Aegisvintsc1_Debug.Text += "<tr align=left><td>Age of Insured Factor 1.0 </td><td>  $" & CInt(smhprem) * 1 & " </td></tr> "
                smhprem = CInt(smhprem) * 1

            End If

            Aegisvintsc1_Debug.Text += "<tr align=left><td>Adjusted Base Rate </td><td> $" & CInt(smhprem) & " </td></tr> "
            aegispackvintpremlbl.Text = CInt(smhprem)
            Dim liabprem As Integer
            Select Case dd_pl_aiges1.SelectedValue
                Case "$25,000"
                    liabprem = 20
                Case "$50,000"
                    liabprem = 30
                Case "$100,000"
                    liabprem = 50
                Case "$300,000"
                    liabprem = 75
            End Select
            Aegisvintsc1_Debug.Text += "<tr align=left><td>Personal Liability </td><td> $" & liabprem & " </td></tr> "
            dd_pl_Aegisvintsc1_Amount.Text = liabprem
            smhprem += liabprem
            Aegisvintsc1_Debug.Text += "<tr align=left><td>Base Rate </td><td> $" & CInt(smhprem) & " </td></tr> "
            Aegisvint_basepremsc1.Text = "$" & CInt(smhprem)



            ''end

            Aegisvintsc1_Debug.Text += "<tr align=left><td>Base Rate </td><td> $" & CInt(smhprem) & " </td></tr> "
            Aegisvint_basepremsc1.Text = "$" & CInt(smhprem)



            Aegisvintsc1_Debug.Text += "<tr align=left><td>Other Structures </td><td> $" & CInt(ds.Tables("tbl1").Rows(0).Item("OtherStructure").ToString().Replace("$", "")) & " </td></tr> "
            txt_unattstr_aiges2_Amount.Text = CInt(ds.Tables("tbl1").Rows(0).Item("OtherStructure").ToString().Replace("$", ""))
            aegisopt += CInt(ds.Tables("tbl1").Rows(0).Item("OtherStructure").ToString().Replace("$", ""))
            Aegisvintsc1_Debug.Text += "<tr align=left><td>Contents </td><td> $" & CInt(ds.Tables("tbl1").Rows(0).Item("Contents").ToString().Replace("$", "")) & " </td></tr> "
            'txt_pp_aiges2_Amount.Text = CInt(ds.Tables("tbl1").Rows(0).Item("Contents").ToString().Replace("$", ""))
            aegisopt += CInt(ds.Tables("tbl1").Rows(0).Item("Contents").ToString().Replace("$", ""))
            Aegisvintsc1_Debug.Text += "<tr align=left><td>Addl Living Expense</td><td> $" & CInt("0") & " </td></tr> "
            txt_unattstr_Aegisvintsc1_Amount.Text = Math.Ceiling(CDbl(ds.Tables("tbl1").Rows(0).Item("OtherStructure").ToString().Replace("$", "")))
            txt_pp_Aegisvintsc1_Amount.Text = Math.Ceiling(CDbl(ds.Tables("tbl1").Rows(0).Item("Contents").ToString().Replace("$", "")))
            smhtotal = CInt(smhprem) + Math.Ceiling(CDbl(ds.Tables("tbl1").Rows(0).Item("OtherStructure").ToString().Replace("$", ""))) + Math.Ceiling(CDbl(ds.Tables("tbl1").Rows(0).Item("Contents").ToString().Replace("$", "")))
            Aegisvintsc1_Debug.Text += "<tr align=left><td>Sub Premium</td><td> $" & CInt(smhtotal) & " </td></tr> "

            Aegisvintsc1_Debug.Text += "<tr align=left><td>Medical Payment</td><td> $ 0  </td></tr> "
            aegispackperclbl.Text = "0"
            aegispackcramtlbl.Text = "0"
            Dim aegiscredit As Decimal



            Aegisvintsc1_Debug.Text += "<tr align=left><td>SUB TOTAL 4</td><td> $" & smhtotal & " </td></tr> "
            Aegisvint_totalsc1.Text = smhtotal.ToString("C2")


            Aegisvintsc1_Debug.Text += "<tr align=left><td>SUB TOTAL 5</td><td> $" & smhtotal & " </td></tr> "

            aiges_fees2.Text = "$0"


            aiges_options2.Text = "$" & aegisopt
            Aegisvintsc1_Debug.Text += "<tr align=left><td>Total Prem</td><td> $" & CDbl(smhtotal) & " </td></tr> "
            Aegisvint_totalsc1.Text = smhtotal.ToString("C2")
            Aegisvintsc1_Debug.Text += "</tbody></table>"

        End If

        AR_PremiumUpdatePanel.Update()



    End Sub


    Public Sub AegisRentCalcNew(ByVal ds As DataSet)
        Dim smhprem As String
        Dim smhas As String
        Dim smhcon As String
        Dim aegisopt As Integer = 0


        Dim smhtotal As Decimal




        'if first run or now value, then fill in fields
        If IsNumeric(txt_unattstr_aiges2.Text) And txt_unattstr_aiges2.Text <> "0.00" Then
        Else
            txt_unattstr_aiges2.Text = ds.Tables("tbl1").Rows(0).Item("RentASstruc").ToString().Replace("$", "")

        End If
        'If IsNumeric(dd_aegiscontentsrental.Text) And dd_aegiscontentsrental.Text <> "0.00" Then
        'Else
        '    dd_aegiscontentsrental.Text = ds.Tables("tbl1").Rows(0).Item("RentCont").ToString().Replace("$", "")

        'End If

        'commented out per vickie 06/27/2014  CTS
        'If ds.Tables("tbl1").Rows(0).Item("territory").ToString() = "5" Then
        '    aegiswind2.Visible = True
        'Else
        '    aegiswind2.Visible = False

        'End If
        'If ds.Tables("tbl1").Rows(0).Item("territory").ToString() = "6" Then
        '    aegiswind2.Visible = True
        'Else
        '    aegiswind2.Visible = False

        'End If
        aegiswind2.Visible = True
        If CInt(dd_pl_aiges2.SelectedValue.Replace("$", "").Replace(",", "")) > 0 Then

            dd_mp_aiges2.SelectedValue = "$500"
        End If
        aiges_unattStr3.Text = "$" & txt_unattstr_aiges2.Text
        ' dd_pl_aiges2.SelectedValue() = "$" & CInt(ds.Tables("tbl1").Rows(0).Item("LiabilityLimit").ToString().Replace("$", "")).ToString("N0")
        Select Case ds.Tables("tbl1").Rows(0).Item("territory").ToString()
            Case "1"
                If CInt(MHValuelbl.Text) <= 24999 Then
                    dd_hurded_aiges2.Text = "2500"
                    aegishurrcanded2.Text = "2000"
                    aegisWindhur2.Visible = True
                    aegiswind2.Visible = True

                    'dd_hurded_aiges2.Text = "2500"
                    'aegiswind2.Visible = True
                    'Else
                    '    aegiswind2.Visible = False

                ElseIf CInt(MHValuelbl.Text) >= 25000 Then
                    dd_hurded_aiges2.Text = "5000"
                    aegishurrcanded2.Text = "2000"
                    aegisWindhur2.Visible = True
                    aegiswind2.Visible = True
                Else
                    'aegiswind2.Visible = False
                    'aegisWindhur2.Visible = False
                End If
            Case "2"
                ' If CInt(MHValuelbl.Text) > 24999 Then
                dd_hurded_aiges2.Text = "5000"
                aegishurrcanded2.Text = "1000"
                aegisWindhur2.Visible = True
                aegiswind2.Visible = False
                ' Else
                'aegiswind2.Visible = False
                'aegisWindhur2.Visible = False


                ' End If
            Case "3"
                ' If CInt(MHValuelbl.Text) > 24999 Then
                dd_hurded_aiges2.Text = "5000"
                aegishurrcanded2.Text = "1000"
                aegisWindhur2.Visible = True
                aegiswind2.Visible = False
                ' Else
                'aegiswind2.Visible = False
                'aegisWindhur2.Visible = False

                ' End If
            Case "4"
                aegiswind2.Visible = False
                aegisWindhur2.Visible = False
            Case "5"
                '  If CInt(MHValuelbl.Text) > 24999 Then
                dd_hurded_aiges2.Text = "1500"
                aegishurrcanded2.Text = "1000"
                aegisWindhur2.Visible = True
                aegiswind2.Visible = True
                ' Else
                'aegiswind2.Visible = False
                'aegisWindhur2.Visible = False


                'End If
            Case "6"
                ' If CInt(MHValuelbl.Text) > 24999 Then
                dd_hurded_aiges2.Text = "1500"
                aegishurrcanded2.Text = "1500"
                aegisWindhur2.Visible = True
                aegiswind2.Visible = True
                '  Else
                'aegiswind2.Visible = False
                'aegisWindhur2.Visible = False


                ' End If
        End Select

        aiges2_Debug.Text = "<table> <tbody>"
        aiges_dwell3.Text = "$" & mhvalue.Replace("$", "")
        aiges_unattStr3.Text = "$" & txt_unattstr_aiges2.Text.Replace("$", "")
        aiges_perEff3.Text = "$0.00"
        aiges_perLiab3.Text = "$" & dd_pl_aiges2.SelectedValue().Replace("$", "")
        aiges_medpay3.Text = "$" & dd_mp_aiges2.Text.Replace("$", "")


        smhprem = "$" & ds.Tables("tbl1").Rows(0).Item("RentPrem").ToString().Replace("$", "")

        If ds.Tables("tbl1").Rows(0).Item("territory").ToString().Replace("$", "") = "5" Or ds.Tables("tbl1").Rows(0).Item("territory").ToString().Replace("$", "") = "6" Then
            aegiswind2.Style.Add("display", "block")
            dd_hurded_aiges2.Text = "1500"
        Else
            aegiswind2.Style.Remove("display")

        End If




        aiges2_Debug.Text += "<tr align=left><td>Package Premium </td><td> $" & CInt(smhprem) & " </td></tr> "
        aegisrentpremlbl.Text = CInt(smhprem)
        aiges2_Debug.Text += "<tr align=left><td>Other Structures </td><td> $" & CInt(ds.Tables("tbl1").Rows(0).Item("RentASstruc").ToString().Replace("$", "")) & " </td></tr> "
        aiges2_Debug.Text += "<tr align=left><td>Contents </td><td> $" & CInt(ds.Tables("tbl1").Rows(0).Item("RentCont").ToString().Replace("$", "")) & " </td></tr> "
        txt_unattstr_aiges2_Amount.Text = CInt(ds.Tables("tbl1").Rows(0).Item("RentASstruc").ToString().Replace("$", ""))
        Label155.Text = CInt(ds.Tables("tbl1").Rows(0).Item("RentCont").ToString().Replace("$", ""))
        ' aegisopt += CInt(ds.Tables("tbl1").Rows(0).Item("RentASstruc").ToString().Replace("$", ""))
        'aegisopt += CInt(ds.Tables("tbl1").Rows(0).Item("RentCont").ToString().Replace("$", ""))

        aiges2_Debug.Text += "<tr align=left><td>Addl Living Expense</td><td> $" & CInt("0") & " </td></tr> "
        'txt_unattstr_aiges2_Amount.Text = CInt(ds.Tables("tbl1").Rows(0).Item("OtherStructure").ToString().Replace("$", ""))

        smhtotal = CInt(smhprem) + CInt(ds.Tables("tbl1").Rows(0).Item("RentASstruc").ToString().Replace("$", ""))
        smhtotal += CInt(ds.Tables("tbl1").Rows(0).Item("RentCont").ToString().Replace("$", ""))
        aiges2_Debug.Text += "<tr align=left><td>Sub Premium</td><td> $" & CInt(smhtotal) & " </td></tr> "

        aiges_baseprem3.Text = "$" & CInt(smhtotal)
        aiges2_Debug.Text += "<tr align=left><td>Base Premium</td><td> $" & CInt(smhtotal) & " </td></tr> "

        aiges2_Debug.Text += "<tr align=left><td>Landlord Liability</td><td> $" & CInt(ds.Tables("tbl1").Rows(0).Item("rentLiability").ToString()) & " </td></tr> "
        dd_pl_aiges2_Amount.Text = CInt(ds.Tables("tbl1").Rows(0).Item("rentLiability").ToString())
        aegisopt += CInt(ds.Tables("tbl1").Rows(0).Item("rentLiability").ToString())
        smhtotal += CInt(ds.Tables("tbl1").Rows(0).Item("rentLiability").ToString())

        aiges2_Debug.Text += "<tr align=left><td>Medical Payment</td><td> $ 0  </td></tr> "
        aegisrentperclbl.Text = "0"
        aegisrentcramtlbl.Text = "0"
        Dim aegiscredit As Decimal

        aiges2_Debug.Text += "<tr align=left><td>SUB TOTAL 2</td><td> $" & CInt(smhtotal) & " </td></tr> "
        'If dd_aop_aiges2.SelectedValue = "$500" Then
        '    aiges2_Debug.Text += "<tr align=left><td>AOP</td><td> $0 </td></tr> "
        '    dd_aop_aiges2_Amount.Text = "0.00"

        'Else
        '    aiges2_Debug.Text += "<tr align=left><td>AOP</td><td> ( $" & CInt(smhtotal * 0.05) & " )</td></tr> "

        '    dd_aop_aiges2_Amount.Text = "(" & CInt(smhtotal * 0.05) & ")"
        '    aegisopt -= CInt(smhtotal * 0.05)
        '    smhtotal -= CInt(smhtotal * 0.05)


        'End If


        aiges2_Debug.Text += "<tr align=left><td>SUB TOTAL 3</td><td> $" & CInt(smhtotal) & " </td></tr> "




        aiges2_Debug.Text += "<tr align=left><td>SUB TOTAL 4</td><td> $" & smhtotal & " </td></tr> "

        'removed per Vickie 5/6/2014
        'aiges_fees3.Text = "$" & "45"
        'aiges2_Debug.Text += "<tr align=left><td>Expense Constant</td><td> $45 </td></tr> "
        'smhtotal += 45


        aiges2_Debug.Text += "<tr align=left><td>SUB TOTAL 5</td><td> $" & smhtotal & " </td></tr> "

        If lienlbl.Text = "No" Then
            aiges2_Debug.Text += "<tr align=left><td>No Lien</td><td> ($15) </td></tr> "
            smhtotal -= 15
        End If

        aiges_options3.Text = aegisopt.ToString("C2")
        aiges2_Debug.Text += "<tr align=left><td>Total Prem</td><td> " & smhtotal.ToString("C2") & " </td></tr> "

        If smhtotal < 100 Then
            aiges2_Debug.Text += "<tr align=left><td>Minimum Prem</td><td> $100 </td></tr> "
            aiges_total3.Text = "$100"
        Else
            aiges_total3.Text = smhtotal.ToString("C2")
        End If

        aiges2_Debug.Text += "</tbody></table>"
        AR_PremiumUpdatePanel.Update()





    End Sub
    Public Sub AegisRentCalc(ByVal ds As DataSet)
        Dim smhprem As String
        Dim smhas As String
        Dim smhcon As String
        Dim aegisopt As Integer = 0

        Dim smhtotal As Decimal




        'if first run or now value, then fill in fields
        If IsNumeric(txt_unattstr_aiges2.Text) And txt_unattstr_aiges2.Text <> "0.00" Then
        Else
            txt_unattstr_aiges2.Text = ds.Tables("tbl1").Rows(0).Item("RentASstruc").ToString().Replace("$", "")

        End If

        If ds.Tables("tbl1").Rows(0).Item("territory").ToString() = "5" Then
            aegiswind2.Visible = True
        Else
            aegiswind2.Visible = False

        End If
        If ds.Tables("tbl1").Rows(0).Item("territory").ToString() = "6" Then
            aegiswind2.Visible = True
        Else
            aegiswind2.Visible = False

        End If

        If CInt(dd_pl_aiges2.SelectedValue.Replace("$", "").Replace(",", "")) > 0 Then

            dd_mp_aiges2.SelectedValue = "$500"
        End If
        aiges_unattStr3.Text = "$" & txt_unattstr_aiges2.Text
        ' dd_pl_aiges2.SelectedValue() = "$" & CInt(ds.Tables("tbl1").Rows(0).Item("LiabilityLimit").ToString().Replace("$", "")).ToString("N0")


        aiges2_Debug.Text = "<table> <tbody>"
        aiges_dwell3.Text = "$" & mhvalue.Replace("$", "")
        aiges_unattStr3.Text = "$" & txt_unattstr_aiges2.Text.Replace("$", "")
        aiges_perEff3.Text = "$0.00"
        aiges_perLiab3.Text = "$" & dd_pl_aiges2.SelectedValue().Replace("$", "")
        aiges_medpay3.Text = "$" & dd_mp_aiges2.Text.Replace("$", "")


        smhprem = "$" & ds.Tables("tbl1").Rows(0).Item("RentPrem").ToString().Replace("$", "")

        If ds.Tables("tbl1").Rows(0).Item("territory").ToString().Replace("$", "") = "5" Or ds.Tables("tbl1").Rows(0).Item("territory").ToString().Replace("$", "") = "6" Then
            aegiswind2.Style.Add("display", "block")
            dd_hurded_aiges2.Text = "1500"
        Else
            aegiswind2.Style.Remove("display")

        End If




        aiges2_Debug.Text += "<tr align=left><td>Package Premium </td><td> $" & CInt(smhprem) & " </td></tr> "
        aegisrentpremlbl.Text = CInt(smhprem)
        aiges2_Debug.Text += "<tr align=left><td>Other Structures </td><td> $" & CInt(ds.Tables("tbl1").Rows(0).Item("RentASstruc").ToString().Replace("$", "")) & " </td></tr> "
        txt_unattstr_aiges2_Amount.Text = CInt(ds.Tables("tbl1").Rows(0).Item("RentASstruc").ToString().Replace("$", ""))
        ' aegisopt += CInt(ds.Tables("tbl1").Rows(0).Item("RentASstruc").ToString().Replace("$", ""))


        aiges2_Debug.Text += "<tr align=left><td>Addl Living Expense</td><td> $" & CInt("0") & " </td></tr> "
        'txt_unattstr_aiges2_Amount.Text = CInt(ds.Tables("tbl1").Rows(0).Item("OtherStructure").ToString().Replace("$", ""))

        smhtotal = CInt(smhprem) + CInt(ds.Tables("tbl1").Rows(0).Item("RentASstruc").ToString().Replace("$", ""))
        aiges2_Debug.Text += "<tr align=left><td>Sub Premium</td><td> $" & CInt(smhtotal) & " </td></tr> "

        aiges_baseprem3.Text = "$" & CInt(smhtotal)
        aiges2_Debug.Text += "<tr align=left><td>Base Premium</td><td> $" & CInt(smhtotal) & " </td></tr> "

        aiges2_Debug.Text += "<tr align=left><td>Landlord Liability</td><td> $" & CInt(ds.Tables("tbl1").Rows(0).Item("rentLiability").ToString()) & " </td></tr> "
        dd_pl_aiges2_Amount.Text = CInt(ds.Tables("tbl1").Rows(0).Item("rentLiability").ToString())
        aegisopt += CInt(ds.Tables("tbl1").Rows(0).Item("rentLiability").ToString())
        smhtotal += CInt(ds.Tables("tbl1").Rows(0).Item("rentLiability").ToString())

        aiges2_Debug.Text += "<tr align=left><td>Medical Payment</td><td> $ 0  </td></tr> "
        aegisrentperclbl.Text = "0"
        aegisrentcramtlbl.Text = "0"
        Dim aegiscredit As Decimal

        aiges2_Debug.Text += "<tr align=left><td>SUB TOTAL 2</td><td> $" & CInt(smhtotal) & " </td></tr> "
        'If dd_aop_aiges2.SelectedValue = "$500" Then
        '    aiges2_Debug.Text += "<tr align=left><td>AOP</td><td> $0 </td></tr> "
        '    dd_aop_aiges2_Amount.Text = "0.00"

        'Else
        '    aiges2_Debug.Text += "<tr align=left><td>AOP</td><td> ( $" & CInt(smhtotal * 0.05) & " )</td></tr> "

        '    dd_aop_aiges2_Amount.Text = "(" & CInt(smhtotal * 0.05) & ")"
        '    aegisopt -= CInt(smhtotal * 0.05)
        '    smhtotal -= CInt(smhtotal * 0.05)


        'End If


        aiges2_Debug.Text += "<tr align=left><td>SUB TOTAL 3</td><td> $" & CInt(smhtotal) & " </td></tr> "




        aiges2_Debug.Text += "<tr align=left><td>SUB TOTAL 4</td><td> $" & smhtotal & " </td></tr> "

        'removed per vickie 5/6/2014
        'aiges_fees3.Text = "$" & "45"
        'aiges2_Debug.Text += "<tr align=left><td>Expense Constant</td><td> $45 </td></tr> "
        'smhtotal += 45


        aiges2_Debug.Text += "<tr align=left><td>SUB TOTAL 5</td><td> $" & smhtotal & " </td></tr> "

        'If lienlbl.Text = "No" Then
        '    aiges2_Debug.Text += "<tr align=left><td>No Lien</td><td> ($15) </td></tr> "
        '    smhtotal -= 15
        'End If

        aiges_options3.Text = aegisopt.ToString("C2")
        aiges2_Debug.Text += "<tr align=left><td>Total Prem</td><td> " & smhtotal.ToString("C2") & " </td></tr> "

        If smhtotal < 100 Then
            aiges2_Debug.Text += "<tr align=left><td>Minimum Prem</td><td> $100 </td></tr> "
            aiges_total3.Text = "$100"
        Else
            aiges_total3.Text = smhtotal.ToString("C2")
        End If

        aiges2_Debug.Text += "</tbody></table>"
        AR_PremiumUpdatePanel.Update()





    End Sub
    Public Sub AegisStandCalcNew(ByVal ds As DataSet)
        Dim smhprem As String
        Dim aegisopt As String

        Dim smhtotal As Decimal


        If IsNumeric(txt_unattstr_aiges1.Text) And txt_unattstr_aiges1.Text <> "0.00" Then
            If CInt(ds.Tables("tbl1").Rows(0).Item("UAStructure").ToString().Replace("$", "")) > CInt(txt_unattstr_aiges1.Text) Then
                txt_unattstr_aiges1.Text = ds.Tables("tbl1").Rows(0).Item("UAStructure").ToString().Replace("$", "")
            End If
        Else
            txt_unattstr_aiges1.Text = ds.Tables("tbl1").Rows(0).Item("UAStructure").ToString().Replace("$", "")

        End If
        If IsNumeric(txt_pp_aiges1.Text) And txt_pp_aiges1.Text <> "0.00" Then
            If CInt(ds.Tables("tbl1").Rows(0).Item("PPlimit").ToString().Replace("$", "")) > CInt(txt_pp_aiges1.Text) Then
                txt_pp_aiges1.Text = ds.Tables("tbl1").Rows(0).Item("PPlimit").ToString().Replace("$", "")
            End If
        Else
            txt_pp_aiges1.Text = ds.Tables("tbl1").Rows(0).Item("PPlimit").ToString().Replace("$", "")
        End If
        aiges_medpay2.Text = dd_mp_aiges1.SelectedValue()

        If dd_pl_aiges1.SelectedValue() = "$0" Then



            dd_pl_aiges1.SelectedValue() = "$" & CInt(ds.Tables("tbl1").Rows(0).Item("LiabilityLimit").ToString().Replace("$", "")).ToString("N0")

        End If

        Select Case ds.Tables("tbl1").Rows(0).Item("territory").ToString()
            Case "1"
                If CInt(MHValuelbl.Text) <= 24999 Then
                    dd_hurded_aiges1.Text = "2500"
                    aegishurrcanded.Text = "2000"
                    aegisWind.Visible = True
                    aegisWindhur.Visible = True
                    'Else
                    '    aegisWind.Visible = False
                    'End If
                ElseIf CInt(MHValuelbl.Text) >= 25000 Then
                    dd_hurded_aiges1.Text = "5000"
                    aegishurrcanded.Text = "2000"
                    aegisWindhur.Visible = True
                    aegisWind.Visible = True
                Else
                    aegisWind.Visible = False
                    aegisWindhur.Visible = False
                End If
            Case "2"
                dd_hurded_aiges1.Text = "5000"
                aegishurrcanded.Text = "1000"
                aegisWindhur.Visible = True
                aegisWind.Visible = False

                'If CInt(MHValuelbl.Text) > 24999 Then
                '    dd_hurded_aiges1.Text = "5000"
                '    aegishurrcanded.Text = "1000"
                '    aegisWindhur.Visible = True
                '    aegisWind.Visible = False
                'Else
                '    aegisWind.Visible = False
                '    aegisWindhur.Visible = False


                'End If
            Case "3"
                dd_hurded_aiges1.Text = "5000"
                aegishurrcanded.Text = "1000"
                aegisWindhur.Visible = True
                aegisWind.Visible = False

                'If CInt(MHValuelbl.Text) > 24999 Then
                '    dd_hurded_aiges1.Text = "5000"
                '    aegishurrcanded.Text = "1000"
                '    aegisWindhur.Visible = True
                '    aegisWind.Visible = False
                'Else
                '    aegisWind.Visible = False
                '    aegisWindhur.Visible = False

                'End If
            Case "4"
                aegisWind.Visible = False
                aegisWindhur.Visible = False
            Case "5"
                dd_hurded_aiges1.Text = "1500"
                aegishurrcanded.Text = "1000"
                aegisWindhur.Visible = True
                aegisWind.Visible = True

                'If CInt(MHValuelbl.Text) > 24999 Then
                '    dd_hurded_aiges1.Text = "1500"
                '    aegishurrcanded.Text = "1000"
                '    aegisWindhur.Visible = True
                '    aegisWind.Visible = True
                'Else
                '    aegisWind.Visible = False
                '    aegisWindhur.Visible = False
                'End If
            Case "6"
                dd_hurded_aiges1.Text = "1500"
                aegishurrcanded.Text = "1500"
                aegisWindhur.Visible = True
                aegisWind.Visible = True

                'If CInt(MHValuelbl.Text) > 24999 Then
                '    dd_hurded_aiges1.Text = "1500"
                '    aegishurrcanded.Text = "1500"
                '    aegisWindhur.Visible = True
                '    aegisWind.Visible = True
                'Else
                '    aegisWind.Visible = False
                '    aegisWindhur.Visible = False


                'End If
        End Select


       
       

       


      

       
        ''If ds.Tables("tbl1").Rows(0).Item("territory").ToString() = "5" Then
        ''    aegisWind.Visible = True
        ''Else
        ''    aegisWind.Visible = False

        ''End If
        ''If ds.Tables("tbl1").Rows(0).Item("territory").ToString() = "6" Then
        ''    aegisWind.Visible = True
        ''Else
        ''    aegisWind.Visible = False

        ''End If


        aiges_Debug.Text = "<table> <tbody>"
        aiges_dwell2.Text = "$" & mhvalue.Replace("$", "")
        aiges_unattStr2.Text = "$" & txt_unattstr_aiges1.Text.Replace("$", "")
        aiges_perEff2.Text = "$" & txt_pp_aiges1.Text.Replace("$", "")
        aiges_perLiab2.Text = "$" & dd_pl_aiges1.SelectedValue().Replace("$", "")
        aiges_medpay2.Text = "$" & aiges_medpay2.Text.Replace("$", "")


        smhprem = "$" & ds.Tables("tbl1").Rows(0).Item("Prem").ToString().Replace("$", "")

        If ds.Tables("tbl1").Rows(0).Item("territory").ToString().Replace("$", "") = "5" Or ds.Tables("tbl1").Rows(0).Item("territory").ToString().Replace("$", "") = "6" Then
            aegisWind.Style.Add("display", "block")
            dd_hurded_aiges1.Text = "1500"
        Else
            aegisWind.Style.Remove("display")

        End If
        'If dd_aop_08.Text = "2500" Then
        '    dd_hurded_08.Text = "$2500"
        'Else
        '    dd_hurded_08.Text = "$1250"
        'End If

        'txtlossofuse08.Text = "$1000"



        aiges_Debug.Text += "<tr align=left><td>Package Premium </td><td> $" & CInt(smhprem) & " </td></tr> "
        '   aegispackpremlbl.Text = CInt(smhprem)
        Select Case ds.Tables("tbl1").Rows(0).Item("territory").ToString()
            Case "1"
                smhprem = smhprem * 1.0
                aiges_Debug.Text += "<tr align=left><td>Territory Factor 1.00 </td><td> $" & CInt(smhprem) & " </td></tr> "
            Case "2"
                smhprem = smhprem * 1.09
                aiges_Debug.Text += "<tr align=left><td>Territory Factor 1.09 </td><td> $" & CInt(smhprem) & " </td></tr> "
            Case "3"
                smhprem = smhprem * 0.66
                aiges_Debug.Text += "<tr align=left><td>Territory Factor .66 </td><td> $" & CInt(smhprem) & " </td></tr> "
            Case "4"
                smhprem = smhprem * 0.61
                aiges_Debug.Text += "<tr align=left><td>Territory Factor .61 </td><td> $" & CInt(smhprem) & " </td></tr> "
            Case "5"
                smhprem = smhprem * 1.09
                aiges_Debug.Text += "<tr align=left><td>Territory Factor 1.09 </td><td> $" & CInt(smhprem) & " </td></tr> "
            Case "6"
                smhprem = smhprem * 0.66
                aiges_Debug.Text += "<tr align=left><td>Territory Factor .66 </td><td> $" & CInt(smhprem) & " </td></tr> "

        End Select
        Dim age As Integer
        Dim agefactor As Decimal
        age = Date.Now.Year - CInt(mhyearlbl.Text)
        If age >= 0 And age <= 10 Then
            agefactor = 0.9
            aiges_Debug.Text += "<tr align=left><td>MH Age Factor 0.9 </td><td> $" & CInt(smhprem) * agefactor & " </td></tr> "
            smhprem = CInt(smhprem) * agefactor
        End If
        If age >= 11 And age <= 25 Then
            agefactor = 1.0
            aiges_Debug.Text += "<tr align=left><td>MH Age Factor 1.0 </td><td> $" & CInt(smhprem) * agefactor & " </td></tr> "
            smhprem = CInt(smhprem) * agefactor
        End If
        If age >= 36 Then
            agefactor = 1.11
            aiges_Debug.Text += "<tr align=left><td>MH Age Factor 1.11 </td><td> $" & CInt(smhprem) * agefactor & " </td></tr> "
            smhprem = CInt(smhprem) * agefactor
        End If
        'If age = 2 Or age = 3 Then
        '    agefactor = 0.9
        'End If
        'aiges_Debug.Text += "<tr align=left><td>MH Age Factor </td><td> $" & agefactor & " </td></tr> "
        'smhprem = CInt(smhprem) * agefactor
        Dim protfactor As Decimal
        If CInt(protection.Text) > 0 And CInt(protection.Text) < 10 Then
            protfactor = 1.0
            aiges_Debug.Text += "<tr align=left><td>Protection Class Factor 1.0 </td><td> $" & CInt(smhprem) * protfactor & " </td></tr> "
            smhprem = CInt(smhprem) * protfactor
        Else
            protfactor = 1.11
            aiges_Debug.Text += "<tr align=left><td>Protection Class Factor 1.11 </td><td> $" & CInt(smhprem) * protfactor & " </td></tr> "
            smhprem = CInt(smhprem) * protfactor
        End If

        Dim appage As Integer
        Dim dob As String
        If lbldob.Text.Length = 8 Then
            dob = lbldob.Text.Substring(0, 2) & "/" & lbldob.Text.Substring(2, 2) & "/" & lbldob.Text.Substring(4, 4)
        Else
            dob = lbldob.Text
        End If
        appage = DateDiff(DateInterval.Year, CDate(dob), Date.Now)
        If appage < 50 Then
            aiges_Debug.Text += "<tr align=left><td>Age of Insured Factor 1.27 </td><td> $" & CInt(smhprem) * 1.27 & "  </td></tr> "
            smhprem = CInt(smhprem) * 1.27
        Else
            aiges_Debug.Text += "<tr align=left><td>Age of Insured Factor 1.0 </td><td>  $" & CInt(smhprem) * 1 & " </td></tr> "
            smhprem = CInt(smhprem) * 1

        End If

        aiges_Debug.Text += "<tr align=left><td>Adjusted Base Rate </td><td> $" & CInt(smhprem) & " </td></tr> "
        aegispackpremlbl.Text = CInt(smhprem)
        Dim liabprem As Integer
        Select Case dd_pl_aiges1.SelectedValue
            Case "$25,000"
                liabprem = 20
            Case "$50,000"
                liabprem = 30
            Case "$100,000"
                liabprem = 50
            Case "$300,000"
                liabprem = 75
        End Select
        aiges_Debug.Text += "<tr align=left><td>Personal Liability </td><td> $" & liabprem & " </td></tr> "
        dd_pl_aiges1_Amount.Text = liabprem
        smhprem += liabprem
        aiges_Debug.Text += "<tr align=left><td>Base Rate </td><td> $" & CInt(smhprem) & " </td></tr> "
        aiges_baseprem2.Text = "$" & CInt(smhprem)

        Dim aopprem As Integer = 0
        Select Case dd_aop_aiges1.SelectedValue
            Case "$250"
                aopprem += smhprem * 0.05
                aiges_Debug.Text += "<tr align=left><td>Deductible Option </td><td> $" & CInt(aopprem) & " </td></tr> "
            Case "$1000"
                aopprem -= smhprem * 0.05
                aiges_Debug.Text += "<tr align=left><td>Deductible Option </td><td> ($" & CInt(aopprem) & " )</td></tr> "
            Case "$2500"
                aopprem -= smhprem * 0.1
                aiges_Debug.Text += "<tr align=left><td>Deductible Option </td><td> ($" & CInt(aopprem) & ") </td></tr> "
        End Select
        dd_aop_aiges1_Amount.Text = aopprem
        smhprem += aopprem

        aiges_Debug.Text += "<tr align=left><td>Other Structures </td><td> $" & CInt(ds.Tables("tbl1").Rows(0).Item("OtherStructure").ToString().Replace("$", "")) & " </td></tr> "
        txt_unattstr_aiges2_Amount.Text = CInt(ds.Tables("tbl1").Rows(0).Item("OtherStructure").ToString().Replace("$", ""))
        aegisopt += CInt(ds.Tables("tbl1").Rows(0).Item("OtherStructure").ToString().Replace("$", ""))
        aiges_Debug.Text += "<tr align=left><td>Contents </td><td> $" & CInt(ds.Tables("tbl1").Rows(0).Item("Contents").ToString().Replace("$", "")) & " </td></tr> "
        'txt_pp_aiges2_Amount.Text = CInt(ds.Tables("tbl1").Rows(0).Item("Contents").ToString().Replace("$", ""))
        aegisopt += CInt(ds.Tables("tbl1").Rows(0).Item("Contents").ToString().Replace("$", ""))
        aiges_Debug.Text += "<tr align=left><td>Addl Living Expense</td><td> $" & CInt("0") & " </td></tr> "
        txt_unattstr_aiges1_Amount.Text = Math.Ceiling(CDbl(ds.Tables("tbl1").Rows(0).Item("OtherStructure").ToString().Replace("$", "")))
        txt_pp_aiges1_Amount.Text = Math.Ceiling(CDbl(ds.Tables("tbl1").Rows(0).Item("Contents").ToString().Replace("$", "")))
        smhtotal = CInt(smhprem) + Math.Ceiling(CDbl(ds.Tables("tbl1").Rows(0).Item("OtherStructure").ToString().Replace("$", ""))) + Math.Ceiling(CDbl(ds.Tables("tbl1").Rows(0).Item("Contents").ToString().Replace("$", "")))
        aiges_Debug.Text += "<tr align=left><td>Sub Premium</td><td> $" & CInt(smhtotal) & " </td></tr> "
        'Dim CreditsPercentage As Decimal
        ''Add credit stuff to label
        'CreditsPercentage = ds.Tables("tbl1").Rows(0).Item("Credit").ToString().Replace("$", "")
        'aiges_Debug.Text += "<tr align=left><td> Credits %</td><td> " & CreditsPercentage * 100 & "% </td></tr> "
        'aiges_Debug.Text += "<tr align=left><td> Credits Value</td><td>-" & Math.Round((smhtotal * CreditsPercentage), 0, MidpointRounding.AwayFromZero) & " </td></tr> "
        'smhtotal -= Math.Round((smhtotal * CreditsPercentage), 0, MidpointRounding.AwayFromZero)

        ' aiges_Debug.Text += "<tr align=left><td>Base Premium</td><td> $" & CInt(smhtotal) & " </td></tr> "
        'aegispackpremlbl.Text = CInt(smhtotal)
        'aiges_Debug.Text += "<tr align=left><td>Personal Liability</td><td> $" & CInt(ds.Tables("tbl1").Rows(0).Item("Liability").ToString()) & " </td></tr> "
        'dd_pl_aiges1_Amount.Text = CInt(ds.Tables("tbl1").Rows(0).Item("Liability").ToString())
        'smhtotal += CInt(ds.Tables("tbl1").Rows(0).Item("Liability").ToString())
        Select Case dd_mp_aiges1.SelectedValue
            Case "$1000"
                aiges_Debug.Text += "<tr align=left><td>Medical Payment</td><td> $ 5  </td></tr> "
                aegisopt += 5
                smhprem += 5
                dd_med_aiges1_amt.Text = "5"
            Case "$2000"
                aiges_Debug.Text += "<tr align=left><td>Medical Payment</td><td> $ 15  </td></tr> "
                aegisopt += 15
                smhprem += 15
                dd_med_aiges1_amt.Text = "15"
            Case "$2500"
                aiges_Debug.Text += "<tr align=left><td>Medical Payment</td><td> $ 20  </td></tr> "
                aegisopt += 20
                smhprem += 20
                dd_med_aiges1_amt.Text = "20"
            Case "$5000"
                aiges_Debug.Text += "<tr align=left><td>Medical Payment</td><td> $ 45  </td></tr> "
                aegisopt += 45
                smhprem += 45
                dd_med_aiges1_amt.Text = "45"


            Case Else
                aiges_Debug.Text += "<tr align=left><td>Medical Payment</td><td> $ 0  </td></tr> "

        End Select

        aegispackperclbl.Text = "0"
        aegispackcramtlbl.Text = "0"
        Dim aegiscredit As Decimal

        'aiges_Debug.Text += "<tr align=left><td>SUB TOTAL 2</td><td> $" & CInt(smhtotal) & " </td></tr> "
        'If dd_aop_aiges1.SelectedValue = "$500" Then
        '    aiges_Debug.Text += "<tr align=left><td>AOP</td><td> $0 </td></tr> "
        '    dd_aop_aiges2_Amount.Text = "0.00"
        '    'dd_aop_08_Amount.Text = ds.Tables("tbl1").Rows(0).Item("AOP").ToString().Replace("$", "")
        '    ' smhtotal += CInt(ds.Tables("tbl1").Rows(0).Item("AOP").ToString().Replace("$", ""))
        'Else
        '    aiges_Debug.Text += "<tr align=left><td>AOP</td><td> ( $" & CInt(smhtotal * 0.05) & " )</td></tr> "
        '    'dd_aop_08_Amount.Text = ds.Tables("tbl1").Rows(0).Item("AOP").ToString().Replace("$", "")
        '    dd_aop_aiges1_Amount.Text = "(" & CInt(smhtotal * 0.05) & ")"
        '    smhtotal -= CInt(smhtotal * 0.05)
        '    aegisopt -= CInt(smhtotal * 0.05)
        '    'aegiscredit += CInt(smhtotal * 0.05)
        'End If


        '' aiges_Debug.Text += "<tr align=left><td>SUB TOTAL 3</td><td> $" & CInt(smhtotal) & " </td></tr> "
        If dd_rep_aiges1.SelectedValue = "Yes" Then
            Dim contrep As String
            contrep = CInt((CInt(txt_pp_aiges1.Text) / 100) * 0.25)
            If CInt(contrep) < 30 Then
                contrep = 30
            End If
            aiges_Debug.Text += "<tr align=left><td>Contents Replacement</td><td> $" & contrep & " </td></tr> "
            dd_rep_aiges1_Amount.Text = CInt(contrep)
            aegisopt += CInt(contrep)
            smhtotal += CInt(contrep)
        End If
        ' Dim age As Integer = 0
        If IsNumeric(mhyearlbl.Text) Then
            age = Now.Year - CInt(mhyearlbl.Text)
        End If
        If age > 15 Then
            dd_sip_aiges1.Enabled = False
            dd_sip_aiges1.SelectedValue = "No"
        Else
            dd_sip_aiges1.Enabled = True

        End If
        If dd_sip_aiges1.SelectedValue = "Yes" Then
            If age < 16 Then
                aiges_Debug.Text += "<tr align=left><td>Full Repair</td><td> $20 </td></tr> "
                aegisopt += 20
                smhtotal += 20
                dd_sip_aiges1_Amount.Text = "20"
            Else
                dd_sip_aiges1_Amount.Text = "0.00"
            End If


        End If



        If dd_living.SelectedValue = "Yes" Then
            aiges_Debug.Text += "<tr align=left><td>Additional Living Expense</td><td> $20 </td></tr> "
            aegisopt += 20
            smhtotal += 20
            dd_living_amt.Text = "20"
        Else
            dd_living_amt.Text = "0.00"

        End If

        'If dd_earthquake.SelectedValue = "Yes" Then
        '    aiges_Debug.Text += "<tr align=left><td>Earthquake Coverage</td><td> $" & (CInt(MHValuelbl.Text) / 1000) * 2 & "</td></tr> "
        '    aegisopt += (CInt(MHValuelbl.Text) / 1000) * 2
        '    smhtotal += (CInt(MHValuelbl.Text) / 1000) * 2
        '    dd_earthquake_amt.Text = (CInt(MHValuelbl.Text) / 1000) * 2
        'Else
        '    dd_earthquake_amt.Text = "0.00"

        'End If
        If mhusagelbl.Text = "Seasonal" Then

            aegis_icedelete.Visible = True
            If dd_icedelete.SelectedValue = "Yes" Then
                aiges_Debug.Text += "<tr align=left><td>Weight of Ice, Snow or Sleet Limitation(Deletion)</td><td>( $10 )</td></tr> "
                aegisopt -= 10
                smhtotal -= 10
                dd_icedelete_amt.Text = "-10"
            Else
                dd_icedelete_amt.Text = "0.00"

            End If
            aegis_icelimit.Visible = False
            'If dd_icelimit.SelectedValue = "Yes" Then
            '    aiges_Debug.Text += "<tr align=left><td>Weight of Ice, Snow or Sleet Limitation</td><td>( $5 )</td></tr> "
            '    aegisopt -= 5
            '    smhtotal -= 5
            '    dd_icelimit_amt.Text = "-5"
            'Else
            '    dd_icelimit_amt.Text = "0.00"

            'End If

            'If dd_icedelete.SelectedValue = "Yes" Then
            '    aiges_Debug.Text += "<tr align=left><td>Weight of Ice, Snow or Sleet Limitation(Deletion)</td><td>( $10 )</td></tr> "
            '    aegisopt -= 10
            '    smhtotal -= 10
            '    dd_icedelete_amt.Text = "-10"
            'Else
            '    dd_icedelete_amt.Text = "0.00"

            'End If
        ElseIf mhusagelbl.Text = "Owner" Then
            aegis_icelimit.Visible = True
            If dd_icelimit.SelectedValue = "Yes" Then
                aiges_Debug.Text += "<tr align=left><td>Weight of Ice, Snow or Sleet Limitation</td><td>( $5 )</td></tr> "
                aegisopt -= 5
                smhtotal -= 5
                dd_icelimit_amt.Text = "-5"
            Else
                dd_icelimit_amt.Text = "0.00"

            End If
            aegis_icedelete.Visible = False
        ElseIf mhusagelbl.Text = "Seasonal" Then
            aegis_icedelete.Visible = True
            If dd_icedelete.SelectedValue = "Yes" Then
                aiges_Debug.Text += "<tr align=left><td>Weight of Ice, Snow or Sleet Limitation(Deletion)</td><td>( $10 )</td></tr> "
                aegisopt -= 10
                smhtotal -= 10
                dd_icedelete_amt.Text = "-10"
            Else
                dd_icedelete_amt.Text = "0.00"

            End If
            aegis_icelimit.Visible = False
        Else

            aegis_icelimit.Visible = False
            aegis_icedelete.Visible = False
        End If
        'If dd_theft.SelectedValue = "Yes" Then
        '    aiges_Debug.Text += "<tr align=left><td>Theft Exclusion: </td><td> ($10) </td></tr> "
        '    aegisopt -= 10
        '    smhtotal -= 10
        '    dd_theft_amt.Text = "-10"
        'Else
        '    dd_theft_amt.Text = "0.00"

        'End If

        If dd_water.SelectedValue = "Yes" Then
            aiges_Debug.Text += "<tr align=left><td>Water Damage Limitation: </td><td>( $5 )</td></tr> "
            aegisopt -= 5
            smhtotal -= 5
            dd_water_amt.Text = "-5"
        Else
            dd_water_amt.Text = "0.00"

        End If
        If dd_water.SelectedValue = "Yes" Then
            dd_waterexlusion.SelectedValue = "No"
        End If
        If dd_waterexlusion.SelectedValue = "Yes" Then
            dd_water.SelectedValue = "No"
        End If
        If dd_waterexlusion.SelectedValue = "Yes" Then
            aiges_Debug.Text += "<tr align=left><td>Water Damage Exclusion: </td><td> ($20) </td></tr> "
            aegisopt -= 20
            smhtotal -= 20
            dd_waterexlusion_amt.Text = "-20"
        Else
            dd_waterexlusion_amt.Text = "0.00"

        End If
        If dd_golf.SelectedValue = "Yes" Then
            aiges_Debug.Text += "<tr align=left><td>Golf Cart Coverage: </td><td> $50 </td></tr> "
            aegisopt += 50
            smhtotal += 50
            dd_golf_amt.Text = "50"
        Else
            dd_golf_amt.Text = "0.00"

        End If
        If dd_animal.SelectedValue = "Yes" Then


            Select Case dd_pl_aiges1.SelectedValue
                Case "$25,000"
                    aiges_Debug.Text += "<tr align=left><td>Animal Injury Liability Exclusion: </td><td> $1 </td></tr> "
                    aegisopt += 1
                    smhtotal += 1
                    dd_animal_amt.Text = "1"
                Case "$50,000"
                    aiges_Debug.Text += "<tr align=left><td>Animal Injury Liability Exclusion: </td><td> $2 </td></tr> "
                    aegisopt += 2
                    smhtotal += 2
                    dd_animal_amt.Text = "2"
                Case "$100,000"
                    aiges_Debug.Text += "<tr align=left><td>Animal Injury Liability Exclusion: </td><td> $3 </td></tr> "
                    aegisopt += 3
                    smhtotal += 3
                    dd_animal_amt.Text = "3"
                Case "$300,000"
                    aiges_Debug.Text += "<tr align=left><td>Animal Injury Liability Exclusion: </td><td> $4 </td></tr> "
                    aegisopt += 4
                    smhtotal += 4
                    dd_animal_amt.Text = "4"
                Case Else
                    dd_animal_amt.Text = "0.00"
            End Select
        End If
        If dd_pool.SelectedValue = "Yes" Then
            aiges_Debug.Text += "<tr align=left><td>Limited Swimming Pool or Spa: </td><td> $20 </td></tr> "
            aegisopt += 20
            smhtotal += 20
            dd_pool_amt.Text = "20"
        Else
            dd_pool_amt.Text = "0.00"

        End If

        aiges_Debug.Text += "<tr align=left><td>Scheduled Personal Property:</td><td> $" & dd_PackagePerProp_AR1_Amount.Text & " </td></tr> "
        smhtotal += CDec(dd_PackagePerProp_AR1_Amount.Text)
        aegisopt += CDec(dd_PackagePerProp_AR1_Amount.Text)
        'aiges_fees2.Text = "$" & CInt(ds.Tables("tbl1").Rows(0).Item("Fee").ToString())
        'aiges_Debug.Text += "<tr align=left><td>Policy Fee</td><td> $" & CInt(ds.Tables("tbl1").Rows(0).Item("Fee").ToString()) & " </td></tr> "
        'smhtotal += CInt(ds.Tables("tbl1").Rows(0).Item("Fee").ToString())

        aiges_Debug.Text += "<tr align=left><td>SUB TOTAL 4</td><td> $" & smhtotal & " </td></tr> "
        aiges_total2.Text = smhtotal.ToString("C2")



        'If lienlbl.Text = "No" Then
        '    aiges_Debug.Text += "<tr align=left><td>No Lien</td><td> ($15) </td></tr> "
        '    aegispackcramtlbl.Text = "($15)"
        '    smhtotal -= 15
        'End If
        aiges_Debug.Text += "<tr align=left><td>SUB TOTAL 5</td><td> $" & smhtotal & " </td></tr> "
        ' '' ''If DropDownList1.SelectedValue() = "Yes" Then
        ' '' ''    aegissatprem.Text = "5"
        ' '' ''    aegisopt += 5
        ' '' ''Else
        ' '' ''    aegissatprem.Text = "0.00"
        ' '' ''End If
        If IsNumeric(txt_Sat_value.Text) Then
            If CInt(txt_Sat_value.Text) > 0 Then
                Dim sat As Integer
                sat = (CInt(txt_Sat_value.Text) / 100) * 5
                If sat < 5 Then
                    sat = 5

                End If
                aiges_Debug.Text += "<tr align=left><td>Antenna/ Satalite Dish:</td><td> $" & sat & " </td></tr> "
                aegissatprem.Text = sat
                aegisopt += sat
                smhtotal += sat
            End If

        End If
        aiges_fees2.Text = "$0"

        'Commented out per Vickie 1/08/2014
        If supheatlbl.Text = "Yes" Then
            aiges_Debug.Text += "<tr align=left><td>Supplemental Heating</td><td> $50 </td></tr> "
            smhtotal += 50
            aiges_fees2.Text = "$50"
            'If (smhtotal * 0.1) < 30 Then
            '    aiges_Debug.Text += "<tr align=left><td>Supplemental Heating</td><td> $30 </td></tr> "
            '    smhtotal += 30
            '    aiges_fees2.Text = "$30"
            'Else
            '    aiges_Debug.Text += "<tr align=left><td>Supplemental Heating</td><td> $" & CInt(smhtotal * 0.1) & "</td></tr> "
            '    aiges_fees2.Text = "$" & CInt(smhtotal * 0.1)
            '    smhtotal += CInt(smhtotal * 0.1)

            'End If
        End If
        aiges_options2.Text = "$" & aegisopt
        aiges_Debug.Text += "<tr align=left><td>Total Prem</td><td> $" & CDbl(smhtotal) & " </td></tr> "
        'aiges_options2.Text = CInt(ds.Tables("tbl1").Rows(0).Item("AOP").ToString().Replace("$", "")) + CInt(ds.Tables("tbl1").Rows(0).Item("Liab").ToString()) + CInt(ds.Tables("tbl1").Rows(0).Item("ContRep").ToString()) + CInt(ds.Tables("tbl1").Rows(0).Item("Enhance").ToString())
        'aiges_total2.Text = String.Format("{0:C}", CInt(SC08_baseprem.Text) + CInt(SC08_options.Text) + CDbl(SC08_fees.Text) + CDbl(SC08_tax.Text))
        aiges_total2.Text = smhtotal.ToString("C2")
        aiges_Debug.Text += "</tbody></table>"
        AR_PremiumUpdatePanel.Update()



    End Sub
    Public Sub AegisStandCalc(ByVal ds As DataSet)

        Dim smhprem As String
        Dim smhas As String
        Dim smhcon As String
        Dim aegisopt As String

        Dim smhtotal As Decimal




        'if first run or now value, then fill in fields
        If IsNumeric(txt_unattstr_aiges1.Text) And txt_unattstr_aiges1.Text <> "0.00" Then
            If CInt(ds.Tables("tbl1").Rows(0).Item("UAStructure").ToString().Replace("$", "")) > CInt(txt_unattstr_aiges1.Text) Then
                txt_unattstr_aiges1.Text = ds.Tables("tbl1").Rows(0).Item("UAStructure").ToString().Replace("$", "")
            End If
        Else
            txt_unattstr_aiges1.Text = ds.Tables("tbl1").Rows(0).Item("UAStructure").ToString().Replace("$", "")

        End If
        If IsNumeric(txt_pp_aiges1.Text) And txt_pp_aiges1.Text <> "0.00" Then
            If CInt(ds.Tables("tbl1").Rows(0).Item("PPlimit").ToString().Replace("$", "")) > CInt(txt_pp_aiges1.Text) Then
                txt_pp_aiges1.Text = ds.Tables("tbl1").Rows(0).Item("PPlimit").ToString().Replace("$", "")
            End If
        Else
            txt_pp_aiges1.Text = ds.Tables("tbl1").Rows(0).Item("PPlimit").ToString().Replace("$", "")
        End If
        aiges_medpay2.Text = dd_mp_aiges1.SelectedValue()

        If dd_pl_aiges1.SelectedValue() = "$0" Then



            dd_pl_aiges1.SelectedValue() = "$" & CInt(ds.Tables("tbl1").Rows(0).Item("LiabilityLimit").ToString().Replace("$", "")).ToString("N0")

        End If

        If ds.Tables("tbl1").Rows(0).Item("territory").ToString() = "5" Then
            aegisWind.Visible = True
        Else
            aegisWind.Visible = False

        End If
        If ds.Tables("tbl1").Rows(0).Item("territory").ToString() = "6" Then
            aegisWind.Visible = True
        Else
            aegisWind.Visible = False

        End If


        aiges_Debug.Text = "<table> <tbody>"
        aiges_dwell2.Text = "$" & mhvalue.Replace("$", "")
        aiges_unattStr2.Text = "$" & txt_unattstr_aiges1.Text.Replace("$", "")
        aiges_perEff2.Text = "$" & txt_pp_aiges1.Text.Replace("$", "")
        aiges_perLiab2.Text = "$" & dd_pl_aiges1.SelectedValue().Replace("$", "")
        aiges_medpay2.Text = "$" & aiges_medpay2.Text.Replace("$", "")


        smhprem = "$" & ds.Tables("tbl1").Rows(0).Item("Prem").ToString().Replace("$", "")

        If ds.Tables("tbl1").Rows(0).Item("territory").ToString().Replace("$", "") = "5" Or ds.Tables("tbl1").Rows(0).Item("territory").ToString().Replace("$", "") = "6" Then
            aegisWind.Style.Add("display", "block")
            dd_hurded_aiges1.Text = "1500"
        Else
            aegisWind.Style.Remove("display")

        End If
        'If dd_aop_08.Text = "2500" Then
        '    dd_hurded_08.Text = "$2500"
        'Else
        '    dd_hurded_08.Text = "$1250"
        'End If

        'txtlossofuse08.Text = "$1000"



        aiges_Debug.Text += "<tr align=left><td>Package Premium </td><td> $" & CInt(smhprem) & " </td></tr> "
        aegispackpremlbl.Text = CInt(smhprem)
        aiges_Debug.Text += "<tr align=left><td>Other Structures </td><td> $" & CInt(ds.Tables("tbl1").Rows(0).Item("OtherStructure").ToString().Replace("$", "")) & " </td></tr> "
        txt_unattstr_aiges2_Amount.Text = CInt(ds.Tables("tbl1").Rows(0).Item("OtherStructure").ToString().Replace("$", ""))
        aegisopt += CInt(ds.Tables("tbl1").Rows(0).Item("OtherStructure").ToString().Replace("$", ""))
        aiges_Debug.Text += "<tr align=left><td>Contents </td><td> $" & CInt(ds.Tables("tbl1").Rows(0).Item("Contents").ToString().Replace("$", "")) & " </td></tr> "
        'txt_pp_aiges2_Amount.Text = CInt(ds.Tables("tbl1").Rows(0).Item("Contents").ToString().Replace("$", ""))
        aegisopt += CInt(ds.Tables("tbl1").Rows(0).Item("Contents").ToString().Replace("$", ""))
        aiges_Debug.Text += "<tr align=left><td>Addl Living Expense</td><td> $" & CInt("0") & " </td></tr> "
        txt_unattstr_aiges1_Amount.Text = Math.Ceiling(CDbl(ds.Tables("tbl1").Rows(0).Item("OtherStructure").ToString().Replace("$", "")))
        txt_pp_aiges1_Amount.Text = Math.Ceiling(CDbl(ds.Tables("tbl1").Rows(0).Item("Contents").ToString().Replace("$", "")))
        smhtotal = CInt(smhprem) + Math.Ceiling(CDbl(ds.Tables("tbl1").Rows(0).Item("OtherStructure").ToString().Replace("$", ""))) + Math.Ceiling(CDbl(ds.Tables("tbl1").Rows(0).Item("Contents").ToString().Replace("$", "")))
        aiges_Debug.Text += "<tr align=left><td>Sub Premium</td><td> $" & CInt(smhtotal) & " </td></tr> "
        'Dim CreditsPercentage As Decimal
        ''Add credit stuff to label
        'CreditsPercentage = ds.Tables("tbl1").Rows(0).Item("Credit").ToString().Replace("$", "")
        'aiges_Debug.Text += "<tr align=left><td> Credits %</td><td> " & CreditsPercentage * 100 & "% </td></tr> "
        'aiges_Debug.Text += "<tr align=left><td> Credits Value</td><td>-" & Math.Round((smhtotal * CreditsPercentage), 0, MidpointRounding.AwayFromZero) & " </td></tr> "
        'smhtotal -= Math.Round((smhtotal * CreditsPercentage), 0, MidpointRounding.AwayFromZero)
        aiges_baseprem2.Text = "$" & CInt(smhtotal)
        aiges_Debug.Text += "<tr align=left><td>Base Premium</td><td> $" & CInt(smhtotal) & " </td></tr> "
        'aegispackpremlbl.Text = CInt(smhtotal)
        aiges_Debug.Text += "<tr align=left><td>Personal Liability</td><td> $" & CInt(ds.Tables("tbl1").Rows(0).Item("Liability").ToString()) & " </td></tr> "
        dd_pl_aiges1_Amount.Text = CInt(ds.Tables("tbl1").Rows(0).Item("Liability").ToString())
        smhtotal += CInt(ds.Tables("tbl1").Rows(0).Item("Liability").ToString())

        aiges_Debug.Text += "<tr align=left><td>Medical Payment</td><td> $ 0  </td></tr> "
        aegispackperclbl.Text = "0"
        aegispackcramtlbl.Text = "0"
        Dim aegiscredit As Decimal

        aiges_Debug.Text += "<tr align=left><td>SUB TOTAL 2</td><td> $" & CInt(smhtotal) & " </td></tr> "
        If dd_aop_aiges1.SelectedValue = "$500" Then
            aiges_Debug.Text += "<tr align=left><td>AOP</td><td> $0 </td></tr> "
            dd_aop_aiges2_Amount.Text = "0.00"
            'dd_aop_08_Amount.Text = ds.Tables("tbl1").Rows(0).Item("AOP").ToString().Replace("$", "")
            ' smhtotal += CInt(ds.Tables("tbl1").Rows(0).Item("AOP").ToString().Replace("$", ""))
        Else
            aiges_Debug.Text += "<tr align=left><td>AOP</td><td> ( $" & CInt(smhtotal * 0.05) & " )</td></tr> "
            'dd_aop_08_Amount.Text = ds.Tables("tbl1").Rows(0).Item("AOP").ToString().Replace("$", "")
            dd_aop_aiges1_Amount.Text = "(" & CInt(smhtotal * 0.05) & ")"
            smhtotal -= CInt(smhtotal * 0.05)
            aegisopt -= CInt(smhtotal * 0.05)
            'aegiscredit += CInt(smhtotal * 0.05)
        End If


        aiges_Debug.Text += "<tr align=left><td>SUB TOTAL 3</td><td> $" & CInt(smhtotal) & " </td></tr> "
        If dd_rep_aiges1.SelectedValue = "Yes" Then
            Dim contrep As String
            contrep = CInt((CInt(txt_pp_aiges1.Text) / 100) * 0.25)
            If CInt(contrep) < 30 Then
                contrep = 30
            End If
            aiges_Debug.Text += "<tr align=left><td>Contents Replacement</td><td> $" & contrep & " </td></tr> "
            dd_rep_aiges1_Amount.Text = CInt(contrep)
            aegisopt += CInt(contrep)
            smhtotal += CInt(contrep)
        End If
        Dim age As Integer = 0
        If IsNumeric(mhyearlbl.Text) Then
            age = Now.Year - CInt(mhyearlbl.Text)
        End If
        If age > 15 Then
            dd_sip_aiges1.Enabled = False
            dd_sip_aiges1.SelectedValue = "No"
        Else
            dd_sip_aiges1.Enabled = True

        End If
        If dd_sip_aiges1.SelectedValue = "Yes" Then
            If age < 16 Then
                aiges_Debug.Text += "<tr align=left><td>Full Repair</td><td> $10 </td></tr> "
                aegisopt += 10
                smhtotal += 10
                dd_sip_aiges1_Amount.Text = "10"
            Else
                dd_sip_aiges1_Amount.Text = "0.00"
            End If


        End If
        aiges_Debug.Text += "<tr align=left><td>Scheduled Personal Property:</td><td> $" & dd_PackagePerProp_AR1_Amount.Text & " </td></tr> "
        smhtotal += CDec(dd_PackagePerProp_AR1_Amount.Text)
        aegisopt += CDec(dd_PackagePerProp_AR1_Amount.Text)
        'aiges_fees2.Text = "$" & CInt(ds.Tables("tbl1").Rows(0).Item("Fee").ToString())
        'aiges_Debug.Text += "<tr align=left><td>Policy Fee</td><td> $" & CInt(ds.Tables("tbl1").Rows(0).Item("Fee").ToString()) & " </td></tr> "
        'smhtotal += CInt(ds.Tables("tbl1").Rows(0).Item("Fee").ToString())

        aiges_Debug.Text += "<tr align=left><td>SUB TOTAL 4</td><td> $" & smhtotal & " </td></tr> "
        aiges_total2.Text = smhtotal.ToString("C2")



        If lienlbl.Text = "No" Then
            aiges_Debug.Text += "<tr align=left><td>No Lien</td><td> ($15) </td></tr> "
            aegispackcramtlbl.Text = "($15)"
            smhtotal -= 15
        End If
        aiges_Debug.Text += "<tr align=left><td>SUB TOTAL 5</td><td> $" & smhtotal & " </td></tr> "
        ' '' ''If DropDownList1.SelectedValue() = "Yes" Then
        ' '' ''    aegissatprem.Text = "5"
        ' '' ''    aegisopt += 5
        ' '' ''Else
        ' '' ''    aegissatprem.Text = "0.00"
        ' '' ''End If
        If IsNumeric(txt_Sat_value.Text) Then
            If CInt(txt_Sat_value.Text) > 0 Then
                Dim sat As Integer
                sat = (CInt(txt_Sat_value.Text) / 100) * 5
                If sat < 5 Then
                    sat = 5

                End If
                aiges_Debug.Text += "<tr align=left><td>Antenna/ Satalite Dish:</td><td> $" & sat & " </td></tr> "
                aegissatprem.Text = sat
                aegisopt += sat
                smhtotal += sat
            End If

        End If
        aiges_fees2.Text = "$0"

        'Commented out per Vickie 1/08/2014
        ''If supheatlbl.Text = "Yes" Then
        ''    If (smhtotal * 0.1) < 30 Then
        ''        aiges_Debug.Text += "<tr align=left><td>Supplemental Heating</td><td> $30 </td></tr> "
        ''        smhtotal += 30
        ''        aiges_fees2.Text = "$30"
        ''    Else
        ''        aiges_Debug.Text += "<tr align=left><td>Supplemental Heating</td><td> $" & CInt(smhtotal * 0.1) & "</td></tr> "
        ''        aiges_fees2.Text = "$" & CInt(smhtotal * 0.1)
        ''        smhtotal += CInt(smhtotal * 0.1)

        ''    End If
        ''End If
        aiges_options2.Text = "$" & aegisopt
        aiges_Debug.Text += "<tr align=left><td>Total Prem</td><td> $" & CDbl(smhtotal) & " </td></tr> "
        'aiges_options2.Text = CInt(ds.Tables("tbl1").Rows(0).Item("AOP").ToString().Replace("$", "")) + CInt(ds.Tables("tbl1").Rows(0).Item("Liab").ToString()) + CInt(ds.Tables("tbl1").Rows(0).Item("ContRep").ToString()) + CInt(ds.Tables("tbl1").Rows(0).Item("Enhance").ToString())
        'aiges_total2.Text = String.Format("{0:C}", CInt(SC08_baseprem.Text) + CInt(SC08_options.Text) + CDbl(SC08_fees.Text) + CDbl(SC08_tax.Text))
        aiges_total2.Text = smhtotal.ToString("C2")
        aiges_Debug.Text += "</tbody></table>"
        AR_PremiumUpdatePanel.Update()


    End Sub
    Protected Sub aiges_premiumbtnClick2(sender As Object, e As EventArgs) Handles aiges1_updateOptions.Click
        loadAegisPP()
        calcAegis()

    End Sub

    Protected Sub aiges_premiumbtnClick3(sender As Object, e As EventArgs) Handles aiges2_updateOptions.Click
        calcAegis()
    End Sub

    Protected Sub selectaiges1btn_Click(sender As Object, e As EventArgs) Handles selectaiges_2btn.Click
        HiddenFieldSelected.Value = "Aegis Standard"
        rateTypelbl.Text = "Aegis Standard"
        rateTypelbl.Font.Bold = True
        rateTypelbl.ForeColor = Drawing.Color.Green


        'Set Selected to AR1 in database  Not saving right now...
        Try

            If quoteIDlbl.Text <> "" Then
                Me.Page.GetType.InvokeMember("updateQuote", System.Reflection.BindingFlags.InvokeMethod, Nothing, Me.Page, New Object() {quoteIDlbl.Text})
            Else
                Me.Page.GetType.InvokeMember("save", System.Reflection.BindingFlags.InvokeMethod, Nothing, Me.Page, New Object() {})

            End If
        Catch ex As Exception
            errortrap("UPDATE Aegis Package", "SELECTED Aegis", ex.Message)
        End Try
        Dim ds As System.Data.DataSet
        ds = runQueryDS("EXEC sp_SetQuoteRateType '" & quoteIDlbl.Text & "', 'Aegis Standard'", "ColonialMHConnectionString")
        'Check Financing options
        ds = runQueryDS("SELECT ARRateType, state  FROM tblQuotes WHERE quoteID ='" & quoteIDlbl.Text & "'", "ColonialMHConnectionString")
        If ds.Tables(0).Rows.Count > 0 Then
            If ds.Tables(0).Rows(0).Item("state") = "SC" And Not rateTypelbl.Text.ToString.ToUpper.Contains("AEG") Then
                'SCPremFinbtn.Visible = True
                'calcSCFinancing()
            Else
                'SCPremFinbtn.Visible = False
            End If
        End If
        premiumBtnTable.Attributes.Add("style", "display:block")
    End Sub

    Protected Sub selectaiges2btn_Click(sender As Object, e As EventArgs) Handles selectaiges2btn.Click
        HiddenFieldSelected.Value = "Aegis Rental"
        rateTypelbl.Text = "Aegis Rental"
        rateTypelbl.Font.Bold = True
        rateTypelbl.ForeColor = Drawing.Color.Green


        'Set Selected to AR1 in database  Not saving right now...
        Try

            If quoteIDlbl.Text <> "" Then
                Me.Page.GetType.InvokeMember("updateQuote", System.Reflection.BindingFlags.InvokeMethod, Nothing, Me.Page, New Object() {quoteIDlbl.Text})
            Else
                Me.Page.GetType.InvokeMember("save", System.Reflection.BindingFlags.InvokeMethod, Nothing, Me.Page, New Object() {})

            End If
        Catch ex As Exception
            errortrap("UPDATE Aegis Package", "SELECTED Aegis", ex.Message)
        End Try
        Dim ds As System.Data.DataSet
        ds = runQueryDS("EXEC sp_SetQuoteRateType '" & quoteIDlbl.Text & "', 'Aegis Rental'", "ColonialMHConnectionString")
        'Check Financing options
        ds = runQueryDS("SELECT ARRateType, state  FROM tblQuotes WHERE quoteID ='" & quoteIDlbl.Text & "'", "ColonialMHConnectionString")
        If ds.Tables(0).Rows.Count > 0 Then
            If ds.Tables(0).Rows(0).Item("state") = "SC" And Not rateTypelbl.Text.ToString.ToUpper.Contains("AEG") Then
                'SCPremFinbtn.Visible = True
                'calcSCFinancing()
            Else
                'SCPremFinbtn.Visible = False
            End If
        End If
        premiumBtnTable.Attributes.Add("style", "display:block")
    End Sub

    Protected Sub btnAddPPL_Click(sender As Object, e As EventArgs) Handles btnAddPPL.Click

        'add personal property
        If IsNumeric(txtvaluePPL.Text) Then
            If CDbl(txtvaluePPL.Text) > 2500.0 Then
                PPError.Visible = True
                PPError.Text = "Property Value cannot Exceed $2500"
                PPError.ForeColor = Drawing.Color.Red
            Else
                If CDbl(packagePerPropValue.Text) + CDbl(txtvaluePPL.Text) > 5000.0 Then
                    PPError.Visible = True
                    PPError.Text = "Property Total Value cannot Exceed $5000"
                    PPError.ForeColor = Drawing.Color.Red
                Else
                    PPError.Visible = False

                    Dim Connection As String = System.Configuration.ConfigurationManager.ConnectionStrings("ColonialMHConnectionString").ConnectionString
                    Dim dbConnection As System.Data.IDbConnection = New System.Data.SqlClient.SqlConnection(Connection)
                    Dim cmd As New SqlCommand("sp_AegisPPInsert", dbConnection)
                    cmd.CommandType = CommandType.StoredProcedure
                    cmd.Parameters.Add("@Category", SqlDbType.VarChar, 8000).Value = ppcatcmbo.SelectedItem.ToString
                    cmd.Parameters.Add("@Description", SqlDbType.VarChar, 8000).Value = txtPPLDescription.Text
                    cmd.Parameters.Add("@qty", SqlDbType.VarChar, 8000).Value = txtQuantityPPl.Text
                    cmd.Parameters.Add("@value", SqlDbType.VarChar, 8000).Value = txtvaluePPL.Text
                    cmd.Parameters.Add("@QuoteID", SqlDbType.VarChar, 8000).Value = quoteIDlbl.Text
                    cmd.Parameters.Add("@territory", SqlDbType.VarChar, 8000).Value = mhcountylbl.Text



                    Try
                        Dim ds As Data.DataSet = New Data.DataSet

                        cmd.Connection.Open()
                        ' intRowsAff = cmd.ExecuteNonQuery()

                        Dim myCommand = New SqlDataAdapter(cmd)
                        myCommand.Fill(ds, "tbl1")
                        If ds.Tables("tbl1").Rows.Count > 0 Then
                            ppcatcmbo.Text = ""
                            txtPPLDescription.Text = ""
                            txtQuantityPPl.Text = ""
                            txtvaluePPL.Text = ""
                            AegisPPGrid.DataSource = ds.Tables("tbl1")
                            AegisPPGrid.DataBind()
                            AegisPPtotals()

                        End If

                    Catch ex As Exception
                        Dim s As String = ""
                        For Each param As SqlParameter In cmd.Parameters
                            s += param.ParameterName & "="
                            s += param.Value & ":  "

                        Next
                        errortrap("Adding PPL for Aegis data " & s, "Calculation AddPPL", ex.Message)
                    End Try

                End If

            End If

        End If


    End Sub
    Public Sub loadAegisPP()
        Dim Connection As String = System.Configuration.ConfigurationManager.ConnectionStrings("ColonialMHConnectionString").ConnectionString
        Dim dbConnection As System.Data.IDbConnection = New System.Data.SqlClient.SqlConnection(Connection)
        Dim cmd As New SqlCommand("sp_GetAegisPP", dbConnection)
        cmd.CommandType = CommandType.StoredProcedure

        cmd.Parameters.Add("@QuoteID", SqlDbType.VarChar, 8000).Value = quoteIDlbl.Text




        Try
            Dim ds As Data.DataSet = New Data.DataSet

            cmd.Connection.Open()
            ' intRowsAff = cmd.ExecuteNonQuery()

            Dim myCommand = New SqlDataAdapter(cmd)
            myCommand.Fill(ds, "tbl1")
            If ds.Tables("tbl1").Rows.Count > 0 Then

                AegisPPGrid.DataSource = ds.Tables("tbl1")
                AegisPPGrid.DataBind()
                AegisPPtotals()

            Else
                ' AegisPPGrid.DataSource = vbNull.ToString
                AegisPPGrid.DataSource = ""
                packagePerPropValue.Text = "0.00"
                dd_PackagePerProp_AR1_Amount.Text = "0.00"
                AegisPPtotals()
            End If

        Catch ex As Exception
            Dim s As String = ""
            For Each param As SqlParameter In cmd.Parameters
                s += param.ParameterName & "="
                s += param.Value & ":  "

            Next
            errortrap("Geting Aegis PP data " & s, "Grid", ex.Message)
        End Try

    End Sub
    Public Sub loadWMJPP()
        Dim Connection As String = System.Configuration.ConfigurationManager.ConnectionStrings("ColonialMHConnectionString").ConnectionString
        Dim dbConnection As System.Data.IDbConnection = New System.Data.SqlClient.SqlConnection(Connection)
        Dim cmd As New SqlCommand("sp_GetWMJPP", dbConnection)
        cmd.CommandType = CommandType.StoredProcedure

        cmd.Parameters.Add("@QuoteID", SqlDbType.VarChar, 8000).Value = quoteIDlbl.Text




        Try
            Dim ds As Data.DataSet = New Data.DataSet

            cmd.Connection.Open()
            ' intRowsAff = cmd.ExecuteNonQuery()

            Dim myCommand = New SqlDataAdapter(cmd)
            myCommand.Fill(ds, "tbl1")
            If ds.Tables("tbl1").Rows.Count > 0 Then

                WMJPPGrid.DataSource = ds.Tables("tbl1")
                WMJPPGrid.DataBind()
                WMJPPtotals()

            Else
                ' WMJPPGrid.DataSource = vbNull.ToString
                WMJPPGrid.DataSource = ""
                packagePerPropValue.Text = "0.00"
                dd_PackagePerProp_AR1_Amount.Text = "0.00"
                WMJPPtotals()
            End If

        Catch ex As Exception
            Dim s As String = ""
            For Each param As SqlParameter In cmd.Parameters
                s += param.ParameterName & "="
                s += param.Value & ":  "

            Next
            errortrap("Geting WMJ PP data " & s, "Grid", ex.Message)
        End Try

    End Sub
    Public Sub AegisPPtotals()
        Dim Connection As String = System.Configuration.ConfigurationManager.ConnectionStrings("ColonialMHConnectionString").ConnectionString
        Dim dbConnection As System.Data.IDbConnection = New System.Data.SqlClient.SqlConnection(Connection)
        Dim cmd As New SqlCommand("sp_GetAegisPPtotals", dbConnection)
        cmd.CommandType = CommandType.StoredProcedure

        cmd.Parameters.Add("@QuoteID", SqlDbType.VarChar, 8000).Value = quoteIDlbl.Text




        Try
            Dim ds As Data.DataSet = New Data.DataSet

            cmd.Connection.Open()
            ' intRowsAff = cmd.ExecuteNonQuery()

            Dim myCommand = New SqlDataAdapter(cmd)
            myCommand.Fill(ds, "tbl1")
            If ds.Tables("tbl1").Rows.Count > 0 Then

                ' AegisPPGrid.DataSource = ds.Tables("tbl1")
                If ds.Tables("tbl1").Rows(0).Item("Totalvalue").ToString() = "0" Then
                    packagePerPropValue.Text = "0.00"
                    dd_PackagePerProp_AR1_Amount.Text = "0.00"
                Else

                    packagePerPropValue.Text = ds.Tables("tbl1").Rows(0).Item("Totalvalue").ToString()
                    dd_PackagePerProp_AR1_Amount.Text = Math.Round((CDec(ds.Tables("tbl1").Rows(0).Item("PPRate").ToString()) * 1), 0, MidpointRounding.AwayFromZero)
                End If

                calcAegis()
            Else
                AegisPPGrid.DataSource = vbNull
                packagePerPropValue.Text = "0.00"
                dd_PackagePerProp_AR1_Amount.Text = "0.00"
                calcAegis()
            End If

        Catch ex As Exception
            Dim s As String = ""
            For Each param As SqlParameter In cmd.Parameters
                s += param.ParameterName & "="
                s += param.Value & ":  "

            Next
            errortrap("Geting Aegis data " & s, "Totals", ex.Message)
        End Try



    End Sub
    Public Sub WMJPPtotals()
        Dim Connection As String = System.Configuration.ConfigurationManager.ConnectionStrings("ColonialMHConnectionString").ConnectionString
        Dim dbConnection As System.Data.IDbConnection = New System.Data.SqlClient.SqlConnection(Connection)
        Dim cmd As New SqlCommand("sp_GetWMJPPtotals", dbConnection)
        cmd.CommandType = CommandType.StoredProcedure

        cmd.Parameters.Add("@QuoteID", SqlDbType.VarChar, 8000).Value = quoteIDlbl.Text




        Try
            Dim ds As Data.DataSet = New Data.DataSet

            cmd.Connection.Open()
            ' intRowsAff = cmd.ExecuteNonQuery()

            Dim myCommand = New SqlDataAdapter(cmd)
            myCommand.Fill(ds, "tbl1")
            If ds.Tables("tbl1").Rows.Count > 0 Then

                ' WMJPPGrid.DataSource = ds.Tables("tbl1")
                If ds.Tables("tbl1").Rows(0).Item("Totalvalue").ToString() = "0" Then
                    wmjppvalue.Text = "0.00"
                    wmjppprem.Text = "0.00"
                Else

                    wmjppvalue.Text = ds.Tables("tbl1").Rows(0).Item("Totalvalue").ToString()
                    wmjppprem.Text = Math.Round((CDec(ds.Tables("tbl1").Rows(0).Item("PPRate").ToString()) * 1), 0, MidpointRounding.AwayFromZero)
                End If

                calcWMJ()
            Else
                WMJPPGrid.DataSource = vbNull
                wmjppvalue.Text = "0.00"
                wmjppprem.Text = "0.00"
                calcWMJ()
            End If

        Catch ex As Exception
            Dim s As String = ""
            For Each param As SqlParameter In cmd.Parameters
                s += param.ParameterName & "="
                s += param.Value & ":  "

            Next
            errortrap("Geting WMJ data " & s, "Totals", ex.Message)
        End Try



    End Sub
    Public Sub SaveAegis(ByVal quoteID As String)
        If quoteID <> "" Then
            quoteIDlbl.Text = quoteID
            Dim value As String = ""
            Dim Connection As String = System.Configuration.ConfigurationManager.ConnectionStrings("ColonialMHConnectionString").ConnectionString
            Dim dbConnection As System.Data.IDbConnection = New System.Data.SqlClient.SqlConnection(Connection)
            Dim cmd As New SqlCommand("sp_AegisQuoteSave", dbConnection)
            cmd.CommandType = CommandType.StoredProcedure
            cmd.Parameters.Add("@QuoteID", SqlDbType.VarChar, 8000).Value = quoteID
            cmd.Parameters.Add("@PackDwel", SqlDbType.VarChar, 8000).Value = aiges_dwell2.Text
            cmd.Parameters.Add("@PackStruc", SqlDbType.VarChar, 8000).Value = aiges_unattStr2.Text
            cmd.Parameters.Add("@PackCont", SqlDbType.VarChar, 8000).Value = aiges_perEff2.Text
            cmd.Parameters.Add("@PackLiab", SqlDbType.VarChar, 8000).Value = aiges_perLiab2.Text
            cmd.Parameters.Add("@PackMedPay", SqlDbType.VarChar, 8000).Value = aiges_medpay2.Text
            cmd.Parameters.Add("@PackBasePrem", SqlDbType.VarChar, 8000).Value = aiges_baseprem2.Text
            cmd.Parameters.Add("@PackAOP", SqlDbType.VarChar, 8000).Value = dd_aop_aiges1.SelectedValue()
            cmd.Parameters.Add("@PackWind", SqlDbType.VarChar, 8000).Value = dd_hurded_aiges1.Text
            cmd.Parameters.Add("@PackPerLiab", SqlDbType.VarChar, 8000).Value = dd_pl_aiges1.SelectedValue()
            cmd.Parameters.Add("@PackMHReplace", SqlDbType.VarChar, 8000).Value = ""
            cmd.Parameters.Add("@PackContReplace", SqlDbType.VarChar, 8000).Value = dd_rep_aiges1.SelectedValue()
            cmd.Parameters.Add("@PackFullRepair", SqlDbType.VarChar, 8000).Value = dd_sip_aiges1.SelectedValue()
            cmd.Parameters.Add("@PackAOPPrem", SqlDbType.VarChar, 8000).Value = dd_aop_aiges1_Amount.Text
            cmd.Parameters.Add("@PackPersLiabPrem", SqlDbType.VarChar, 8000).Value = dd_pl_aiges1_Amount.Text
            cmd.Parameters.Add("@PackMedPrem", SqlDbType.VarChar, 8000).Value = dd_med_aiges1_amt.Text
            cmd.Parameters.Add("@PackStrucPrem", SqlDbType.VarChar, 8000).Value = txt_unattstr_aiges1_Amount.Text
            cmd.Parameters.Add("@PackContPrem", SqlDbType.VarChar, 8000).Value = txt_pp_aiges1_Amount.Text
            cmd.Parameters.Add("@PackMHReplacePrem", SqlDbType.VarChar, 8000).Value = "" 'dd_mhr_AR1_Amount.Text
            cmd.Parameters.Add("@PackContReplacePrem", SqlDbType.VarChar, 8000).Value = dd_rep_aiges1_Amount.Text
            cmd.Parameters.Add("@PackFullRepairPrem", SqlDbType.VarChar, 8000).Value = dd_sip_aiges1_Amount.Text
            cmd.Parameters.Add("@PackTax", SqlDbType.VarChar, 8000).Value = aiges_tax2.Text
            cmd.Parameters.Add("@PackFees", SqlDbType.VarChar, 8000).Value = aiges_fees2.Text
            cmd.Parameters.Add("@Packtotal", SqlDbType.VarChar, 8000).Value = aiges_total2.Text

            cmd.Parameters.Add("@RentDwel", SqlDbType.VarChar, 8000).Value = aiges_dwell3.Text
            cmd.Parameters.Add("@RentStruc", SqlDbType.VarChar, 8000).Value = txt_unattstr_aiges2.Text
            cmd.Parameters.Add("@RentCont", SqlDbType.VarChar, 8000).Value = aiges_perEff3.Text
            cmd.Parameters.Add("@RentLiab", SqlDbType.VarChar, 8000).Value = aiges_perLiab3.Text
            cmd.Parameters.Add("@RentMedPay", SqlDbType.VarChar, 8000).Value = aiges_medpay3.Text
            cmd.Parameters.Add("@RentBasePrem", SqlDbType.VarChar, 8000).Value = aiges_baseprem3.Text
            cmd.Parameters.Add("@RentAOP", SqlDbType.VarChar, 8000).Value = dd_aop_aiges2.SelectedValue()
            cmd.Parameters.Add("@RentWind", SqlDbType.VarChar, 8000).Value = "" 'dd_hurded_aiges2.Text
            cmd.Parameters.Add("@RentPerLiab", SqlDbType.VarChar, 8000).Value = dd_pl_aiges2.SelectedValue()
            cmd.Parameters.Add("@RentMHReplace", SqlDbType.VarChar, 8000).Value = "" 'dd_mhr_aiges2.SelectedValue()
            cmd.Parameters.Add("@RentContReplace", SqlDbType.VarChar, 8000).Value = "" ' dd_rep_aiges2.SelectedValue()
            cmd.Parameters.Add("@RentFullRepair", SqlDbType.VarChar, 8000).Value = "" 'dd_sip_aiges2.SelectedValue()
            cmd.Parameters.Add("@RentAOPPrem", SqlDbType.VarChar, 8000).Value = dd_aop_aiges2_Amount.Text
            cmd.Parameters.Add("@RentPersLiabPrem", SqlDbType.VarChar, 8000).Value = dd_pl_aiges2_Amount.Text
            cmd.Parameters.Add("@RentMedPrem", SqlDbType.VarChar, 8000).Value = dd_med_aiges2_amt.Text
            cmd.Parameters.Add("@RentStrucPrem", SqlDbType.VarChar, 8000).Value = txt_unattstr_aiges2_Amount.Text
            cmd.Parameters.Add("@RentContPrem", SqlDbType.VarChar, 8000).Value = "" 'txt_pp_aiges2_Amount.Text
            cmd.Parameters.Add("@RentMHReplacePrem", SqlDbType.VarChar, 8000).Value = "" 'dd_mhr_aiges2_Amount.Text
            cmd.Parameters.Add("@RentContReplacePrem", SqlDbType.VarChar, 8000).Value = "" 'dd_rep_aiges2_Amount.Text
            cmd.Parameters.Add("@RentFullRepairPrem", SqlDbType.VarChar, 8000).Value = "" 'dd_sip_aiges2_Amount.Text
            cmd.Parameters.Add("@RentTax", SqlDbType.VarChar, 8000).Value = aiges_tax3.Text
            cmd.Parameters.Add("@RentFees", SqlDbType.VarChar, 8000).Value = "0" '"45"
            cmd.Parameters.Add("@Renttotal", SqlDbType.VarChar, 8000).Value = aiges_total3.Text

            cmd.Parameters.Add("@PackCreditPerc", SqlDbType.VarChar, 8000).Value = aegispackperclbl.Text
            cmd.Parameters.Add("@PackCreditamt", SqlDbType.VarChar, 8000).Value = aegispackcramtlbl.Text
            cmd.Parameters.Add("@RentCreditPerc", SqlDbType.VarChar, 8000).Value = aegisrentperclbl.Text
            cmd.Parameters.Add("@RentCreditamt", SqlDbType.VarChar, 8000).Value = aegisrentcramtlbl.Text
            cmd.Parameters.Add("@Packprem", SqlDbType.VarChar, 8000).Value = aegispackpremlbl.Text
            cmd.Parameters.Add("@Rentprem", SqlDbType.VarChar, 8000).Value = aegisrentpremlbl.Text

            cmd.Parameters.Add("@PackPPLimit", SqlDbType.VarChar, 8000).Value = packagePerPropValue.Text
            cmd.Parameters.Add("@PackPPPrem", SqlDbType.VarChar, 8000).Value = dd_PackagePerProp_AR1_Amount.Text
            cmd.Parameters.Add("@PackSatPrem", SqlDbType.VarChar, 8000).Value = aegissatprem.Text
            cmd.Parameters.Add("@PackAddLiving", SqlDbType.VarChar, 8000).Value = dd_living.SelectedValue
            cmd.Parameters.Add("@PackAddLivingPrem", SqlDbType.VarChar, 8000).Value = dd_living_amt.Text
            cmd.Parameters.Add("@PackEarth", SqlDbType.VarChar, 8000).Value = dd_earthquake.SelectedValue
            cmd.Parameters.Add("@PackEarthPrem", SqlDbType.VarChar, 8000).Value = dd_earthquake_amt.Text
            cmd.Parameters.Add("@PackIce", SqlDbType.VarChar, 8000).Value = dd_icelimit.SelectedValue
            cmd.Parameters.Add("@PackIcePrem", SqlDbType.VarChar, 8000).Value = dd_icelimit_amt.Text
            cmd.Parameters.Add("@PackIceE", SqlDbType.VarChar, 8000).Value = dd_icedelete.SelectedValue
            cmd.Parameters.Add("@PackIceEPrem", SqlDbType.VarChar, 8000).Value = dd_icedelete_amt.Text
            cmd.Parameters.Add("@PackTheft", SqlDbType.VarChar, 8000).Value = "" ' dd_theft.SelectedValue
            cmd.Parameters.Add("@PackTheftPrem", SqlDbType.VarChar, 8000).Value = "" 'dd_theft_amt.Text
            cmd.Parameters.Add("@PackWater", SqlDbType.VarChar, 8000).Value = dd_water.SelectedValue
            cmd.Parameters.Add("@PackWaterPrem", SqlDbType.VarChar, 8000).Value = dd_water_amt.Text
            cmd.Parameters.Add("@PackGolf", SqlDbType.VarChar, 8000).Value = dd_golf.SelectedValue
            cmd.Parameters.Add("@PackGolfPrem", SqlDbType.VarChar, 8000).Value = dd_golf_amt.Text
            cmd.Parameters.Add("@PackSwim", SqlDbType.VarChar, 8000).Value = dd_pool.SelectedValue
            cmd.Parameters.Add("@PackSwimPrem", SqlDbType.VarChar, 8000).Value = dd_pool_amt.Text
            '            cmd.Parameters.Add("@RentAddLiving", SqlDbType.VarChar, 8000).Value =
            '            cmd.Parameters.Add("@RentAddLivingPrem", SqlDbType.VarChar, 8000).Value =
            '            cmd.Parameters.Add("@RentEarth", SqlDbType.VarChar, 8000).Value = 
            '            cmd.Parameters.Add("@RentEarthPrem", SqlDbType.VarChar, 8000).Value = 
            cmd.Parameters.Add("@RentIce", SqlDbType.VarChar, 8000).Value = dd_icedeleterent.SelectedValue
            cmd.Parameters.Add("@RentIcePrem", SqlDbType.VarChar, 8000).Value = dd_icedeletrent_amt.Text
            cmd.Parameters.Add("@RentIceE", SqlDbType.VarChar, 8000).Value = ""
            cmd.Parameters.Add("@RentIceEPrem", SqlDbType.VarChar, 8000).Value = ""
            cmd.Parameters.Add("@RentTheft", SqlDbType.VarChar, 8000).Value = ""
            cmd.Parameters.Add("@RentTheftPrem", SqlDbType.VarChar, 8000).Value = ""
            cmd.Parameters.Add("@RentWater", SqlDbType.VarChar, 8000).Value = ""
            cmd.Parameters.Add("@RentWaterPrem", SqlDbType.VarChar, 8000).Value = ""
            cmd.Parameters.Add("@RentGolf", SqlDbType.VarChar, 8000).Value = ""
            cmd.Parameters.Add("@RentGolfPrem", SqlDbType.VarChar, 8000).Value = ""
            cmd.Parameters.Add("@RentSwim", SqlDbType.VarChar, 8000).Value = ""
            cmd.Parameters.Add("@RentSwimPrem", SqlDbType.VarChar, 8000).Value = ""


            cmd.Parameters.Add("@Vintdwell", SqlDbType.VarChar, 8000).Value = Aegisvint_dwellsc1.Text
            cmd.Parameters.Add("@Vintstruc", SqlDbType.VarChar, 8000).Value = Aegisvint_unattStrsc1.Text
            cmd.Parameters.Add("@Vintcont", SqlDbType.VarChar, 8000).Value = Aegisvint_perEffsc1.Text
            cmd.Parameters.Add("@VintLiab", SqlDbType.VarChar, 8000).Value = Aegisvint_perLiabsc1.Text
            cmd.Parameters.Add("@VintBasePrem", SqlDbType.VarChar, 8000).Value = Aegisvint_basepremsc1.Text
            cmd.Parameters.Add("@VintstrucPrem", SqlDbType.VarChar, 8000).Value = txt_unattstr_Aegisvintsc1_Amount.Text
            cmd.Parameters.Add("@VintcontPrem", SqlDbType.VarChar, 8000).Value = txt_pp_Aegisvintsc1_Amount.Text
            cmd.Parameters.Add("@VintTotal", SqlDbType.VarChar, 8000).Value = Aegisvint_totalsc1.Text

            If dd_animal.SelectedValue = "Yes" Then
                cmd.Parameters.Add("@PackAnimal", SqlDbType.VarChar, 8000).Value = dd_animal.SelectedValue
                cmd.Parameters.Add("@PackAnimalLimit", SqlDbType.VarChar, 8000).Value = dd_pl_aiges1.SelectedValue
                cmd.Parameters.Add("@PackAnimanPrem", SqlDbType.VarChar, 8000).Value = dd_animal_amt.Text

            Else
                cmd.Parameters.Add("@PackAnimal", SqlDbType.VarChar, 8000).Value = dd_animal.SelectedValue
                cmd.Parameters.Add("@PackAnimalLimit", SqlDbType.VarChar, 8000).Value = "0" 'dd_pl_aiges1.SelectedValue
                cmd.Parameters.Add("@PackAnimanPrem", SqlDbType.VarChar, 8000).Value = "0" 'dd_animal_amt.Text


            End If



            Try
                Dim ds As Data.DataSet = New Data.DataSet

                cmd.Connection.Open()
                ' intRowsAff = cmd.ExecuteNonQuery()

                Dim myCommand = New SqlDataAdapter(cmd)
                myCommand.Fill(ds, "tbl1")
            Catch ex As Exception
                Dim s As String = ""
                For Each param As SqlParameter In cmd.Parameters
                    s += param.ParameterName & "="
                    s += param.Value & ":  "

                Next
                errortrap("Saving Aegis Data " & s, "Save Prem", ex.Message)
            End Try
        End If

    End Sub
    Public Sub LoadWMJData()
        Dim Connection As String = System.Configuration.ConfigurationManager.ConnectionStrings("ColonialMHConnectionString").ConnectionString
        Dim dbConnection As System.Data.IDbConnection = New System.Data.SqlClient.SqlConnection(Connection)
        Dim cmd As New SqlCommand("sp_GetWMJQuoteData", dbConnection)
        cmd.CommandType = CommandType.StoredProcedure
        cmd.Parameters.Add("@QuoteID", SqlDbType.VarChar, 8000).Value = mhquoteID
        Dim ds As Data.DataSet = New Data.DataSet

        cmd.Connection.Open()
        ' intRowsAff = cmd.ExecuteNonQuery()

        Dim myCommand = New SqlDataAdapter(cmd)
        myCommand.Fill(ds, "tbl1")
        If ds.Tables("tbl1").Rows.Count > 0 Then
            rateTypelbl.Text = ds.Tables(0).Rows(0).Item("ARRateType").ToString()
            rateTypelbl.Font.Bold = True
            rateTypelbl.ForeColor = Drawing.Color.Green

            premiumBtnTable.Attributes.Add("style", "display:block")
            If ds.Tables("tbl1").Rows(0).Item("ARRateType").ToString = "WMJ Standard" Then
                wmj_dwell2.Text = ds.Tables("tbl1").Rows(0).Item("PackDwel").ToString
                wmj_unattStr2.Text = ds.Tables("tbl1").Rows(0).Item("PackStruc").ToString
                wmj_perEff2.Text = ds.Tables("tbl1").Rows(0).Item("PackCont").ToString
                wmj_perLiab2.Text = ds.Tables("tbl1").Rows(0).Item("PackLiab").ToString
                wmj_medpay2.Text = ds.Tables("tbl1").Rows(0).Item("PackMedPay").ToString
                wmj_baseprem2.Text = "$" & ds.Tables("tbl1").Rows(0).Item("PackBasePrem").ToString.Replace("$", "")
                dd_aop_wmj1.SelectedValue = ds.Tables("tbl1").Rows(0).Item("PackAOP").ToString
                dd_pl_wmj1.SelectedValue = ds.Tables("tbl1").Rows(0).Item("PackPerLiab").ToString
                dd_rep_wmj1.SelectedValue = ds.Tables("tbl1").Rows(0).Item("PackContReplace").ToString
                'dd_sip_wmj1.SelectedValue = ds.Tables("tbl1").Rows(0).Item("PackFullRepair").ToString
                dd_aop_wmj1_Amount.Text = ds.Tables("tbl1").Rows(0).Item("PackAOPPrem").ToString
                dd_pl_wmj1_Amount.Text = ds.Tables("tbl1").Rows(0).Item("PackPersLiabPrem").ToString
                dd_med_wmj1_amt.Text = ds.Tables("tbl1").Rows(0).Item("PackMedPrem").ToString
                txt_unattstr_wmj1_Amount.Text = ds.Tables("tbl1").Rows(0).Item("PackStrucPrem").ToString
                'txt_pp_wmjnc3_Amount.Text
                'dd_rep_wmjnc3_Amount.Text
                'dd_sip_wmjnc3_Amount.Text
                wmj_tax2.Text = "$" & CDbl(ds.Tables("tbl1").Rows(0).Item("PackTax").ToString.Replace("$", ""))
                wmj_fees2.Text = ds.Tables("tbl1").Rows(0).Item("PackFees").ToString
                wmj_total2.Text = ds.Tables("tbl1").Rows(0).Item("Packtotal").ToString
                'WMJpackperclblnc3.Text
                'WMJpackcramtlblnc3.Text
                'WMJpackpremlblnc3.Text
                'wmjppvalue_nc3.Text
                'wmjppprem_nc3.Text
                'spi_cbo_nc3.SelectedValue
                'spi_nc3_amount.Text
                'dd_addresOpt_wmjnc3.SelectedValue
                'dd_addresOpt_wmjnc3_Amount.Text
                'dd_addresliab_wmjnc3.SelectedValue
                'addres_liab_wmjnc3_amount.Text
                If ds.Tables("tbl1").Rows(0).Item("PackSmokedet").ToString <> "" Then
                    dd_smoke_wmj1.SelectedValue = ds.Tables("tbl1").Rows(0).Item("PackSmokedet").ToString
                    dd_smoke_wmj1_amount.Text = ds.Tables("tbl1").Rows(0).Item("PackSmokecredit").ToString
                End If

                calcWMJ()

            ElseIf ds.Tables("tbl1").Rows(0).Item("ARRateType").ToString = "WMJ Standard Replacement Cost" Then
                wmj_dwellnc1.Text = ds.Tables("tbl1").Rows(0).Item("PackDwel").ToString
                wmj_unattStrnc1.Text = ds.Tables("tbl1").Rows(0).Item("PackStruc").ToString
                wmj_perEffnc1.Text = ds.Tables("tbl1").Rows(0).Item("PackCont").ToString
                wmj_perLiabnc1.Text = ds.Tables("tbl1").Rows(0).Item("PackLiab").ToString
                wmj_medpaync1.Text = ds.Tables("tbl1").Rows(0).Item("PackMedPay").ToString
                wmj_basepremnc1.Text = "$" & ds.Tables("tbl1").Rows(0).Item("PackBasePrem").ToString.Replace("$", "")
                dd_aop_wmjnc1.SelectedValue = ds.Tables("tbl1").Rows(0).Item("PackAOP").ToString
                dd_pl_wmjnc1.SelectedValue = ds.Tables("tbl1").Rows(0).Item("PackPerLiab").ToString
                dd_rep_wmjnc1.SelectedValue = ds.Tables("tbl1").Rows(0).Item("PackContReplace").ToString
                'dd_sip_wmjnc1.SelectedValue = ds.Tables("tbl1").Rows(0).Item("PackFullRepair").ToString
                dd_aop_wmjnc1_Amount.Text = ds.Tables("tbl1").Rows(0).Item("PackAOPPrem").ToString
                dd_pl_wmjnc1_Amount.Text = ds.Tables("tbl1").Rows(0).Item("PackPersLiabPrem").ToString
                dd_med_wmjnc1_amt.Text = ds.Tables("tbl1").Rows(0).Item("PackMedPrem").ToString
                txt_unattstr_wmjnc1_Amount.Text = ds.Tables("tbl1").Rows(0).Item("PackStrucPrem").ToString
                'txt_pp_wmjnc1_Amount.Text
                'dd_rep_wmjnc1_Amount.Text
                'dd_sip_wmjnc1_Amount.Text
                wmj_taxnc1.Text = "$" & CDbl(ds.Tables("tbl1").Rows(0).Item("PackTax").ToString.Replace("$", ""))
                wmj_feesnc1.Text = ds.Tables("tbl1").Rows(0).Item("PackFees").ToString
                wmj_totalnc1.Text = ds.Tables("tbl1").Rows(0).Item("Packtotal").ToString
                'WMJpackperclblnc1.Text
                'WMJpackcramtlblnc1.Text
                'WMJpackpremlblnc1.Text
                'wmjppvalue_nc1.Text
                'wmjppprem_nc1.Text
                'spi_cbo_nc1.SelectedValue
                'spi_nc1_amount.Text
                'dd_addresOpt_wmjnc1.SelectedValue
                'dd_addresOpt_wmjnc1_Amount.Text
                'dd_addresliab_wmjnc1.SelectedValue
                'addres_liab_wmjnc1_amount.Text
                calcWMJNC()
            ElseIf ds.Tables("tbl1").Rows(0).Item("ARRateType").ToString = "WMJ Standard ACV" Then
                wmj_dwellnc2.Text = ds.Tables("tbl1").Rows(0).Item("PackDwel").ToString
                wmj_unattStrnc2.Text = ds.Tables("tbl1").Rows(0).Item("PackStruc").ToString
                wmj_perEffnc2.Text = ds.Tables("tbl1").Rows(0).Item("PackCont").ToString
                wmj_perLiabnc2.Text = ds.Tables("tbl1").Rows(0).Item("PackLiab").ToString
                wmj_medpaync2.Text = ds.Tables("tbl1").Rows(0).Item("PackMedPay").ToString
                wmj_basepremnc2.Text = "$" & ds.Tables("tbl1").Rows(0).Item("PackBasePrem").ToString.Replace("$", "")
                dd_aop_wmjnc2.SelectedValue = ds.Tables("tbl1").Rows(0).Item("PackAOP").ToString
                dd_pl_wmjnc2.SelectedValue = ds.Tables("tbl1").Rows(0).Item("PackPerLiab").ToString
                dd_rep_wmjnc2.SelectedValue = ds.Tables("tbl1").Rows(0).Item("PackContReplace").ToString
                ' dd_sip_wmjnc2.SelectedValue = ds.Tables("tbl1").Rows(0).Item("PackFullRepair").ToString
                dd_aop_wmjnc2_Amount.Text = ds.Tables("tbl1").Rows(0).Item("PackAOPPrem").ToString
                dd_pl_wmjnc2_Amount.Text = ds.Tables("tbl1").Rows(0).Item("PackPersLiabPrem").ToString
                dd_med_wmjnc2_amt.Text = ds.Tables("tbl1").Rows(0).Item("PackMedPrem").ToString
                txt_unattstr_wmjnc2_Amount.Text = ds.Tables("tbl1").Rows(0).Item("PackStrucPrem").ToString
                'txt_pp_wmjnc2_Amount.Text
                'dd_rep_wmjnc2_Amount.Text
                'dd_sip_wmjnc2_Amount.Text
                wmj_taxnc2.Text = "$" & CDbl(ds.Tables("tbl1").Rows(0).Item("PackTax").ToString.Replace("$", ""))
                wmj_feesnc2.Text = ds.Tables("tbl1").Rows(0).Item("PackFees").ToString
                wmj_totalnc2.Text = ds.Tables("tbl1").Rows(0).Item("Packtotal").ToString
                'WMJpackperclblnc2.Text
                'WMJpackcramtlblnc2.Text
                'WMJpackpremlblnc2.Text
                'wmjppvalue_nc2.Text
                'wmjppprem_nc2.Text
                'spi_cbo_nc2.SelectedValue
                'spi_nc2_amount.Text
                'dd_addresOpt_wmjnc2.SelectedValue
                'dd_addresOpt_wmjnc2_Amount.Text
                'dd_addresliab_wmjnc2.SelectedValue
                'addres_liab_wmjnc2_amount.Text
                calcWMJNC()
            ElseIf ds.Tables("tbl1").Rows(0).Item("ARRateType").ToString = "WMJ Preferred" Then

                wmj_dwellnc3.Text = ds.Tables("tbl1").Rows(0).Item("PackDwel").ToString
                wmj_unattStrnc3.Text = ds.Tables("tbl1").Rows(0).Item("PackStruc").ToString
                wmj_perEffnc3.Text = ds.Tables("tbl1").Rows(0).Item("PackCont").ToString
                wmj_perLiabnc3.Text = ds.Tables("tbl1").Rows(0).Item("PackLiab").ToString
                wmj_medpaync3.Text = ds.Tables("tbl1").Rows(0).Item("PackMedPay").ToString
                wmj_basepremnc3.Text = "$" & ds.Tables("tbl1").Rows(0).Item("PackBasePrem").ToString.Replace("$", "")
                dd_aop_wmjnc3.SelectedValue = ds.Tables("tbl1").Rows(0).Item("PackAOP").ToString
                dd_pl_wmjnc3.SelectedValue = ds.Tables("tbl1").Rows(0).Item("PackPerLiab").ToString
                dd_rep_wmjnc3.SelectedValue = ds.Tables("tbl1").Rows(0).Item("PackContReplace").ToString
                ' dd_sip_wmj3.SelectedValue = ds.Tables("tbl1").Rows(0).Item("PackFullRepair").ToString
                dd_aop_wmjnc3_Amount.Text = ds.Tables("tbl1").Rows(0).Item("PackAOPPrem").ToString
                dd_pl_wmjnc3_Amount.Text = ds.Tables("tbl1").Rows(0).Item("PackPersLiabPrem").ToString
                dd_med_wmjnc3_amt.Text = ds.Tables("tbl1").Rows(0).Item("PackMedPrem").ToString
                txt_unattstr_wmjnc3_Amount.Text = ds.Tables("tbl1").Rows(0).Item("PackStrucPrem").ToString
                'txt_pp_wmjnc3_Amount.Text
                'dd_rep_wmjnc3_Amount.Text
                'dd_sip_wmjnc3_Amount.Text
                wmj_taxnc3.Text = "$" & CDbl(ds.Tables("tbl1").Rows(0).Item("PackTax").ToString.Replace("$", ""))
                wmj_feesnc3.Text = ds.Tables("tbl1").Rows(0).Item("PackFees").ToString
                wmj_totalnc3.Text = ds.Tables("tbl1").Rows(0).Item("Packtotal").ToString
                'WMJpackperclblnc3.Text
                'WMJpackcramtlblnc3.Text
                'WMJpackpremlblnc3.Text
                'wmjppvalue_nc3.Text
                'wmjppprem_nc3.Text
                'spi_cbo_nc3.SelectedValue
                'spi_nc3_amount.Text
                'dd_addresOpt_wmjnc3.SelectedValue
                'dd_addresOpt_wmjnc3_Amount.Text
                'dd_addresliab_wmjnc3.SelectedValue
                'addres_liab_wmjnc3_amount.Text
                calcWMJNC()


            End If

        Else
            If lbl_WMJ_Pack.Text = "True" Then
                calcWMJ()
            End If
            If lbl_WMJ_PackNC.Text = "True" Then
                calcWMJNC()
            End If




        End If


    End Sub
    Public Sub LoadAegisData()

        Dim Connection As String = System.Configuration.ConfigurationManager.ConnectionStrings("ColonialMHConnectionString").ConnectionString
        Dim dbConnection As System.Data.IDbConnection = New System.Data.SqlClient.SqlConnection(Connection)
        Dim cmd As New SqlCommand("sp_GetAegisQuoteData", dbConnection)
        cmd.CommandType = CommandType.StoredProcedure
        cmd.Parameters.Add("@QuoteID", SqlDbType.VarChar, 8000).Value = mhquoteID
        Dim ds As Data.DataSet = New Data.DataSet

        cmd.Connection.Open()
        ' intRowsAff = cmd.ExecuteNonQuery()

        Dim myCommand = New SqlDataAdapter(cmd)
        myCommand.Fill(ds, "tbl1")
        If ds.Tables("tbl1").Rows.Count > 0 Then


            aiges_dwell2.Text = ds.Tables("tbl1").Rows(0).Item("PackDwel").ToString
            txt_unattstr_aiges1.Text = ds.Tables("tbl1").Rows(0).Item("PackStruc").ToString
            txt_pp_aiges1.Text = ds.Tables("tbl1").Rows(0).Item("PackCont").ToString
            aiges_perLiab2.Text = ds.Tables("tbl1").Rows(0).Item("PackLiab").ToString
            aiges_medpay2.Text = ds.Tables("tbl1").Rows(0).Item("PackMedPay").ToString
            aiges_baseprem2.Text = "$" & ds.Tables("tbl1").Rows(0).Item("PackBasePrem").ToString.Replace("$", "")
            dd_aop_aiges1.SelectedValue = ds.Tables("tbl1").Rows(0).Item("PackAOP").ToString
            dd_hurded_aiges1.Text = ds.Tables("tbl1").Rows(0).Item("PackWind").ToString
            dd_pl_aiges1.SelectedValue = ds.Tables("tbl1").Rows(0).Item("PackPerLiab").ToString
            'dd_mhr_aiges1.SelectedValue = ds.Tables("tbl1").Rows(0).Item("PackMHReplace").ToString
            dd_rep_aiges1.SelectedValue = ds.Tables("tbl1").Rows(0).Item("PackContReplace").ToString
            dd_sip_aiges1.SelectedValue = ds.Tables("tbl1").Rows(0).Item("PackFullRepair").ToString
            dd_aop_aiges1_Amount.Text = ds.Tables("tbl1").Rows(0).Item("PackAOPPrem").ToString
            dd_pl_aiges1_Amount.Text = ds.Tables("tbl1").Rows(0).Item("PackPersLiabPrem").ToString
            dd_med_aiges1_amt.Text = ds.Tables("tbl1").Rows(0).Item("PackMedPrem").ToString
            txt_unattstr_AR1_Amount.Text = ds.Tables("tbl1").Rows(0).Item("PackStrucPrem").ToString
            txt_pp_aiges1_Amount.Text = ds.Tables("tbl1").Rows(0).Item("PackContPrem").ToString
            'dd_mhr_aiges1_Amount.Text = ds.Tables("tbl1").Rows(0).Item("PackMHReplacePrem").ToString
            dd_rep_aiges1_Amount.Text = ds.Tables("tbl1").Rows(0).Item("PackContReplacePrem").ToString
            dd_sip_aiges1_Amount.Text = ds.Tables("tbl1").Rows(0).Item("PackFullRepairPrem").ToString
            If IsNumeric(ds.Tables("tbl1").Rows(0).Item("PackTax").ToString.Replace("$", "")) Then
                aiges_tax2.Text = "$" & CDbl(ds.Tables("tbl1").Rows(0).Item("PackTax").ToString.Replace("$", ""))
            End If

            aiges_fees2.Text = ds.Tables("tbl1").Rows(0).Item("PackFees").ToString
            aiges_total2.Text = ds.Tables("tbl1").Rows(0).Item("Packtotal").ToString

            aiges_dwell3.Text = ds.Tables("tbl1").Rows(0).Item("RentDwel").ToString
            txt_unattstr_aiges2.Text = ds.Tables("tbl1").Rows(0).Item("RentStruc").ToString
            aiges_perEff3.Text = ds.Tables("tbl1").Rows(0).Item("RentCont").ToString
            aiges_perLiab3.Text = ds.Tables("tbl1").Rows(0).Item("RentLiab").ToString
            aiges_medpay3.Text = ds.Tables("tbl1").Rows(0).Item("RentMedPay").ToString
            aiges_baseprem3.Text = "$" & ds.Tables("tbl1").Rows(0).Item("RentBasePrem").ToString.Replace("$", "")
            If ds.Tables("tbl1").Rows(0).Item("RentAOP").ToString = "" Then
                dd_aop_aiges2.SelectedValue = "$500"
            Else
                dd_aop_aiges2.SelectedValue = ds.Tables("tbl1").Rows(0).Item("RentAOP").ToString
            End If
            ' dd_aop_AR3.SelectedValue = ds.Tables("tbl1").Rows(0).Item("RentAOP").ToString
            'dd_hurded_aiges2.Text = ds.Tables("tbl1").Rows(0).Item("RentWind").ToString
            If ds.Tables("tbl1").Rows(0).Item("RentPerLiab").ToString = "" Then

            Else
                dd_pl_aiges2.SelectedValue = ds.Tables("tbl1").Rows(0).Item("RentPerLiab").ToString

            End If

            'dd_mhr_aiges2.SelectedValue = ds.Tables("tbl1").Rows(0).Item("RentMHReplace").ToString
            'dd_rep_aiges2.SelectedValue = ds.Tables("tbl1").Rows(0).Item("RentContReplace").ToString
            'dd_sip_aiges2.SelectedValue = ds.Tables("tbl1").Rows(0).Item("RentFullRepair").ToString
            dd_aop_aiges2_Amount.Text = ds.Tables("tbl1").Rows(0).Item("RentAOPPrem").ToString
            dd_pl_aiges2_Amount.Text = ds.Tables("tbl1").Rows(0).Item("RentPersLiabPrem").ToString
            dd_med_aiges2_amt.Text = ds.Tables("tbl1").Rows(0).Item("RentMedPrem").ToString
            txt_unattstr_aiges2_Amount.Text = ds.Tables("tbl1").Rows(0).Item("RentStrucPrem").ToString
            'txt_pp_aiges2_Amount.Text = ds.Tables("tbl1").Rows(0).Item("RentContPrem").ToString
            'dd_rep_aiges2_Amount.Text = ds.Tables("tbl1").Rows(0).Item("RentMHReplacePrem").ToString
            'dd_rep_aiges2_Amount.Text = ds.Tables("tbl1").Rows(0).Item("RentContReplacePrem").ToString
            'dd_sip_aiges2_Amount.Text = ds.Tables("tbl1").Rows(0).Item("RentFullRepairPrem").ToString
            'If IsNumeric(ds.Tables("tbl1").Rows(0).Item("RentTax").ToString.Replace("$", "")) Then
            '    aiges_tax3.Text = CDbl(ds.Tables("tbl1").Rows(0).Item("RentTax").ToString.Replace("$", ""))
            'End If

            aiges_fees3.Text = ds.Tables("tbl1").Rows(0).Item("RentFees").ToString
            aiges_total3.Text = ds.Tables("tbl1").Rows(0).Item("Renttotal").ToString

            If ds.Tables("tbl1").Rows(0).Item("PackAddliving").ToString() = "" Then

            Else
                dd_living.SelectedValue = ds.Tables("tbl1").Rows(0).Item("PackAddliving").ToString()
                dd_living_amt.Text = ds.Tables("tbl1").Rows(0).Item("PackAddlivingPrem").ToString()
            End If
            If ds.Tables("tbl1").Rows(0).Item("PackEarth").ToString() = "" Then

            Else
                dd_earthquake.SelectedValue = ds.Tables("tbl1").Rows(0).Item("PackEarth").ToString()
                dd_earthquake_amt.Text = ds.Tables("tbl1").Rows(0).Item("PackEarthPrem").ToString()
            End If
            If ds.Tables("tbl1").Rows(0).Item("PackIce").ToString() = "" Then

            Else
                dd_icelimit.SelectedValue = ds.Tables("tbl1").Rows(0).Item("PackIce").ToString()
                dd_icelimit_amt.Text = ds.Tables("tbl1").Rows(0).Item("PackIcePrem").ToString()
            End If

            If ds.Tables("tbl1").Rows(0).Item("PackIceE").ToString() = "" Then

            Else
                dd_icedelete.SelectedValue = ds.Tables("tbl1").Rows(0).Item("PackIceE").ToString()
                dd_icedelete_amt.Text = ds.Tables("tbl1").Rows(0).Item("PackIceEPrem").ToString()
            End If
            If ds.Tables("tbl1").Rows(0).Item("PackTheft").ToString() = "" Then

            Else
                'dd_theft.SelectedValue = ds.Tables("tbl1").Rows(0).Item("PackTheft").ToString()
                'dd_theft_amt.Text = ds.Tables("tbl1").Rows(0).Item("PackTheftPrem").ToString()
            End If

            If ds.Tables("tbl1").Rows(0).Item("PackWater").ToString() = "" Then

            Else
                dd_water.SelectedValue = ds.Tables("tbl1").Rows(0).Item("PackWater").ToString()
                dd_water_amt.Text = ds.Tables("tbl1").Rows(0).Item("PackWaterPrem").ToString()
            End If

            If ds.Tables("tbl1").Rows(0).Item("PackGolf").ToString() = "" Then

            Else
                dd_golf.SelectedValue = ds.Tables("tbl1").Rows(0).Item("PackGolf").ToString()
                dd_golf_amt.Text = ds.Tables("tbl1").Rows(0).Item("PackGolfPrem").ToString()
            End If
            If ds.Tables("tbl1").Rows(0).Item("PackSwim").ToString() = "" Then

            Else
                dd_pool.SelectedValue = ds.Tables("tbl1").Rows(0).Item("PackSwim").ToString()
                dd_pool_amt.Text = ds.Tables("tbl1").Rows(0).Item("PackSwimPrem").ToString()
            End If

            calcAegis()




        End If



    End Sub

    Private Sub AegisPPGrid_RowDeleting(sender As Object, e As DevExpress.Web.Data.ASPxDataDeletingEventArgs) Handles AegisPPGrid.RowDeleting
        Dim i As Integer = AegisPPGrid.FindVisibleIndexByKeyValue(e.Keys(AegisPPGrid.KeyFieldName))
        '  Dim c As Control = ASPxGridView1.FindDetailRowTemplateControl(i, "ASPxGridView2")
        i = AegisPPGrid.GetRowValues(AegisPPGrid.FocusedRowIndex, "aegisppID")
        e.Cancel = True
        Dim Connection As String = System.Configuration.ConfigurationManager.ConnectionStrings("ColonialMHConnectionString").ConnectionString
        Dim dbConnection As System.Data.IDbConnection = New System.Data.SqlClient.SqlConnection(Connection)
        Dim cmd As New SqlCommand("sp_AegisDeletePP", dbConnection)
        cmd.CommandType = CommandType.StoredProcedure
        cmd.Parameters.Add("@PPID", SqlDbType.VarChar, 8000).Value = i

        Try
            Dim ds As Data.DataSet = New Data.DataSet

            cmd.Connection.Open()
            ' intRowsAff = cmd.ExecuteNonQuery()

            Dim myCommand = New SqlDataAdapter(cmd)
            myCommand.Fill(ds, "tbl1")
        Catch ex As Exception
            Dim s As String = ""
            For Each param As SqlParameter In cmd.Parameters
                s += param.ParameterName & "="
                s += param.Value & ":  "

            Next
            errortrap("deleting pp Aegis Data " & s, "Save Prem", ex.Message)
        End Try
        loadAegisPP()

    End Sub

    Public Sub btn_Click(sender As Object, e As System.EventArgs) Handles btn.Click
        If dd_sip_AR1.SelectedValue = "No" And dd_mhr_AR1.SelectedValue = "No" Then
            dd_sip_AR1.Enabled = True
            dd_mhr_AR1.Enabled = True
        Else
            If dd_mhr_AR1.SelectedValue = "Yes" Then
                dd_sip_AR1.SelectedValue = "No"
                dd_sip_AR1.Enabled = False
            Else
                dd_sip_AR1.Enabled = True

            End If
            If dd_sip_AR1.SelectedValue = "Yes" Then
                dd_mhr_AR1.SelectedValue = "No"
                dd_mhr_AR1.Enabled = False
            Else
                dd_mhr_AR1.Enabled = True

            End If
        End If
        If Date.Now.Year - mhyearlbl.Text >= 10 Then
            dd_mhr_AR1.SelectedValue = "No"
            dd_mhr_AR1.Enabled = False
            dd_mhr_AR2.SelectedValue = "No"
            dd_mhr_AR2.Enabled = False
            dd_mhr_AR3.SelectedValue = "No"
            dd_mhr_AR3.Enabled = False
        Else
            dd_mhr_AR1.Enabled = True
            dd_mhr_AR2.Enabled = True
            dd_mhr_AR3.Enabled = True
        End If

    End Sub
    Public Sub replacechange()
        'If dd_rep_AR1.SelectedValue = "Yes" Then
        '    dd_sip_AR1.SelectedValue = "No"
        '    dd_sip_AR1.Enabled = False

        'End If
    End Sub

    Private Sub btnpp_Click(sender As Object, e As System.EventArgs) Handles btnpp.Click
        If dd_PackagePerProp_aiges.SelectedValue = "No" Then
            'Delete all Property for this Quote

            Dim Connection As String = System.Configuration.ConfigurationManager.ConnectionStrings("ColonialMHConnectionString").ConnectionString
            Dim dbConnection As System.Data.IDbConnection = New System.Data.SqlClient.SqlConnection(Connection)
            Dim cmd As New SqlCommand("sp_DeleteAegisPP", dbConnection)
            cmd.CommandType = CommandType.StoredProcedure
            cmd.Parameters.Add("@QuoteID", SqlDbType.VarChar, 8000).Value = quoteIDlbl.Text

            Try
                Dim ds As Data.DataSet = New Data.DataSet

                cmd.Connection.Open()
                ' intRowsAff = cmd.ExecuteNonQuery()

                Dim myCommand = New SqlDataAdapter(cmd)
                myCommand.Fill(ds, "tbl1")
            Catch ex As Exception
                Dim s As String = ""
                For Each param As SqlParameter In cmd.Parameters
                    s += param.ParameterName & "="
                    s += param.Value & ":  "

                Next
                errortrap("Deleteing Aegis Data " & s, "Delete PP data all", ex.Message)
            End Try

            loadAegisPP()
            packagePerPropValue.Text = "0.00"
            dd_PackagePerProp_AR1_Amount.Text = "0.00"
            AR_PremiumUpdatePanel.Update()
        End If
    End Sub
    Public Sub ProgramChoice()

        If mhstatelbl.Text = "DE" Then
            lbl_Lloyds_SMH.Text = "False"
            lbl_Aegis_Rent.Text = "False"
            lbl_Aegis_Stand.Text = "False"
            lbl_Amslic_Rent.Text = "False"
            lbl_Amslic_Stand.Text = "False"
            SC_MH_08.Visible = False
            SC08_mh_prog_Options.Visible = False
            SC08OptionRow.Visible = False
            aiges_mh_prog2.Visible = False
            aiges_mh_prog2_Options.Visible = False
            aiges_mh_prog3.Visible = False
            aiges_mh_prog3_Options1.Visible = False
            ar_mh_prog1.Visible = False
            ar_mh_prog1_Options.Visible = False
            wmj_mh_prognc1.Visible = False
            wmj_mh_prognc1_Options.Visible = False
            wmj_mh_prognc2.Visible = False
            wmj_mh_prognc2_Options.Visible = False
            wmj_mh_prognc3.Visible = False
            wmj_mh_prognc3_Options.Visible = False
            tstorm1.Visible = False
            tstorm2.Visible = False
            tstorm3.Visible = False
            If mhusagelbl.Text = "Rental" Then
                ar_mh_prog2.Visible = False
                ar_mh_prog2_Options.Visible = False
                ar_mh_prog3.Visible = True
                ar_mh_prog3_Options.Visible = True
                lbl_Lloyds_Rent.Text = "True"
                lbl_Lloyds_Stand.Text = "False"
                lbl_Lloyds_Pack.Text = "False"

            End If
            If mhusagelbl.Text = "Owner" Or mhusagelbl.Text = "Seasonal" Then
                ar_mh_prog2.Visible = True
                ar_mh_prog2_Options.Visible = True
                ar_mh_prog3.Visible = False
                ar_mh_prog3_Options.Visible = False
                lbl_Lloyds_Rent.Text = "False"
                lbl_Lloyds_Stand.Text = "True"
            End If

        Else
            ar_mh_prog2.Visible = False
            ar_mh_prog2_Options.Visible = False
            tstorm1.Visible = True
            tstorm2.Visible = True
            tstorm3.Visible = True
            If mhusagelbl.Text = "Rental" Then
                lbl_Amslic_Rent.Text = "True"
                lbl_Lloyds_Rent.Text = "True"
                lbl_Lloyds_Stand.Text = "False"
                lbl_Lloyds_Pack.Text = "False"
                lbl_Lloyds_SMH.Text = "False"
                lbl_Aegis_Rent.Text = "False"
                lbl_Aegis_Stand.Text = "False"
                ar_mh_prog1.Visible = False
                ar_mh_prog1_Options.Visible = False
                ar_mh_prog2.Visible = False
                ar_mh_prog2_Options.Visible = False
                ar_mh_prog3.Visible = True
                ar_mh_prog3_Options.Visible = True
                SC_MH_08.Visible = False
                SC08_mh_prog_Options.Visible = False
                SC08OptionRow.Visible = False
                wmj_mh_prognc1.Visible = False
                wmj_mh_prognc1_Options.Visible = False
                wmj_mh_prognc2.Visible = False
                wmj_mh_prognc2_Options.Visible = False
                wmj_mh_prognc3.Visible = False
                wmj_mh_prognc3_Options.Visible = False
            End If
            If mhusagelbl.Text = "Owner" Or mhusagelbl.Text = "Seasonal" Then
                lbl_Lloyds_Rent.Text = "False"
                lbl_Lloyds_Stand.Text = "False"
                lbl_Lloyds_Pack.Text = "True"
                lbl_Lloyds_SMH.Text = "True"
                lbl_Aegis_Rent.Text = "False"
                lbl_Aegis_Stand.Text = "False"
                ar_mh_prog1.Visible = True
                ar_mh_prog1_Options.Visible = True

                ar_mh_prog2.Visible = False
                ar_mh_prog2_Options.Visible = False
                ar_mh_prog3.Visible = False
                ar_mh_prog3_Options.Visible = False

            End If
            If mhstatelbl.Text = "SC" Then
                lbl_Amslic_Stand.Text = "True"
                If UCase(mhusagelbl.Text) = UCase("SEASONAL") Then
                    SC_MH_08.Visible = True
                    SC08_mh_prog_Options.Visible = True
                    SC08OptionRow.Visible = True
                    lbl_Lloyds_SMH.Text = "True"
                End If
                lbl_Lloyds_Stand.Text = "False"
                ar_mh_prog2.Visible = False
                ar_mh_prog2_Options.Visible = False
                If CInt(mhvalue) > 129999 Then

                    If mhusagelbl.Text = "Owner" Or mhusagelbl.Text = "Seasonal" Then
                        If mhtypelbl.Text = "Doublewide" Or mhtypelbl.Text = "Modular" Then
                            'if HO8 then make visible and call load data or calculation
                            SC_MH_08.Visible = True
                            SC08_mh_prog_Options.Visible = True
                            SC08OptionRow.Visible = True
                            'calcSH08()
                            lbl_Lloyds_SMH.Text = "True"
                        Else
                            SC_MH_08.Visible = False
                            SC08_mh_prog_Options.Visible = False
                            SC08OptionRow.Visible = False
                            lbl_Lloyds_SMH.Text = "False"
                        End If

                    Else
                        lbl_Lloyds_SMH.Text = "False"
                        SC_MH_08.Visible = False
                        SC08_mh_prog_Options.Visible = False
                        SC08OptionRow.Visible = False
                    End If
                ElseIf CInt(mhvalue) > 115000 Then

                    lbl_Lloyds_Stand.Text = "False"
                    lbl_Lloyds_Pack.Text = "False"
                    ar_mh_prog1.Visible = False
                    ar_mh_prog1_Options.Visible = False

                    ar_mh_prog2.Visible = False
                    ar_mh_prog2_Options.Visible = False

                    txt_unattstr_AR1.Text = "500"
                    txt_pp_AR1.Text = CInt(mhvalue * 0.3)
                    dd_pl_AR1.SelectedValue = "$25,000"


                ElseIf CInt(mhvalue) < 125001 Then


                    'Aegis
                    lbl_Aegis_Rent.Text = "True"
                    lbl_Aegis_Stand.Text = "True"

                    ' ''If UCase(mhcountylbl.Text) = UCase("HAMPTON") Then
                    ' ''    aiges_mh_prog2.Visible = False
                    ' ''    aiges_mh_prog2_Options.Visible = False
                    ' ''    aiges_mh_prog3.Visible = False
                    ' ''    aiges_mh_prog3_Options1.Visible = False
                    ' ''    lbl_Aegis_Rent.Text = "False"
                    ' ''    lbl_Aegis_Stand.Text = "False"

                    ' ''End If

                    ' ''If UCase(mhcountylbl.Text) = UCase("Beaufort") Then
                    ' ''    aiges_mh_prog2.Visible = False
                    ' ''    aiges_mh_prog2_Options.Visible = False
                    ' ''    aiges_mh_prog3.Visible = False
                    ' ''    aiges_mh_prog3_Options1.Visible = False
                    ' ''    lbl_Aegis_Rent.Text = "False"
                    ' ''    lbl_Aegis_Stand.Text = "False"

                    ' ''End If

                    ' ''If UCase(mhcountylbl.Text) = UCase("Berkeley") Then
                    ' ''    aiges_mh_prog2.Visible = False
                    ' ''    aiges_mh_prog2_Options.Visible = False
                    ' ''    aiges_mh_prog3.Visible = False
                    ' ''    aiges_mh_prog3_Options1.Visible = False
                    ' ''    lbl_Aegis_Rent.Text = "False"
                    ' ''    lbl_Aegis_Stand.Text = "False"

                    ' ''End If
                    ' ''If UCase(mhcountylbl.Text) = UCase("berkley") Then
                    ' ''    aiges_mh_prog2.Visible = False
                    ' ''    aiges_mh_prog2_Options.Visible = False
                    ' ''    aiges_mh_prog3.Visible = False
                    ' ''    aiges_mh_prog3_Options1.Visible = False
                    ' ''    lbl_Aegis_Rent.Text = "False"
                    ' ''    lbl_Aegis_Stand.Text = "False"

                    ' ''End If
                    '' ''put in per vickie 1/12/2014

                    ' ''If lblSub.Text = "1550" And UCase(mhcountylbl.Text) = UCase("Berkeley") Then

                    ' ''    aiges_mh_prog2.Visible = False
                    ' ''    aiges_mh_prog2_Options.Visible = False
                    ' ''    aiges_mh_prog3.Visible = False
                    ' ''    aiges_mh_prog3_Options1.Visible = False
                    ' ''    If mhusagelbl.Text = "Rental" Then
                    ' ''        lbl_Aegis_Rent.Text = "True"
                    ' ''    Else

                    ' ''        lbl_Aegis_Stand.Text = "True"
                    ' ''    End If


                    ' ''End If
                    ' ''If lblSub.Text = "1550" And UCase(mhcountylbl.Text) = UCase("berkley") Then

                    ' ''    aiges_mh_prog2.Visible = False
                    ' ''    aiges_mh_prog2_Options.Visible = False
                    ' ''    aiges_mh_prog3.Visible = False
                    ' ''    aiges_mh_prog3_Options1.Visible = False
                    ' ''    If mhusagelbl.Text = "Rental" Then
                    ' ''        lbl_Aegis_Rent.Text = "True"
                    ' ''    Else

                    ' ''        lbl_Aegis_Stand.Text = "True"
                    ' ''    End If


                    ' ''End If

                    ' ''If UCase(mhcountylbl.Text) = UCase("Calhoun") Then
                    ' ''    aiges_mh_prog2.Visible = False
                    ' ''    aiges_mh_prog2_Options.Visible = False
                    ' ''    aiges_mh_prog3.Visible = False
                    ' ''    aiges_mh_prog3_Options1.Visible = False
                    ' ''    lbl_Aegis_Rent.Text = "False"
                    ' ''    lbl_Aegis_Stand.Text = "False"

                    ' ''End If

                    ' ''If UCase(mhcountylbl.Text) = UCase("Charleston") Then
                    ' ''    aiges_mh_prog2.Visible = False
                    ' ''    aiges_mh_prog2_Options.Visible = False
                    ' ''    aiges_mh_prog3.Visible = False
                    ' ''    aiges_mh_prog3_Options1.Visible = False
                    ' ''    lbl_Aegis_Rent.Text = "False"
                    ' ''    lbl_Aegis_Stand.Text = "False"

                    ' ''End If

                    ' ''If UCase(mhcountylbl.Text) = UCase("Clarendon") Then
                    ' ''    aiges_mh_prog2.Visible = False
                    ' ''    aiges_mh_prog2_Options.Visible = False
                    ' ''    aiges_mh_prog3.Visible = False
                    ' ''    aiges_mh_prog3_Options1.Visible = False
                    ' ''    lbl_Aegis_Rent.Text = "False"
                    ' ''    lbl_Aegis_Stand.Text = "False"

                    ' ''End If

                    ' ''If UCase(mhcountylbl.Text) = UCase("Colleton") Then
                    ' ''    aiges_mh_prog2.Visible = False
                    ' ''    aiges_mh_prog2_Options.Visible = False
                    ' ''    aiges_mh_prog3.Visible = False
                    ' ''    aiges_mh_prog3_Options1.Visible = False
                    ' ''    lbl_Aegis_Rent.Text = "False"
                    ' ''    lbl_Aegis_Stand.Text = "False"

                    ' ''End If

                    ' ''If UCase(mhcountylbl.Text) = UCase("Darlington") Then
                    ' ''    aiges_mh_prog2.Visible = False
                    ' ''    aiges_mh_prog2_Options.Visible = False
                    ' ''    aiges_mh_prog3.Visible = False
                    ' ''    aiges_mh_prog3_Options1.Visible = False
                    ' ''    lbl_Aegis_Rent.Text = "False"
                    ' ''    lbl_Aegis_Stand.Text = "False"

                    ' ''End If

                    ' ''If UCase(mhcountylbl.Text) = UCase("Dorchester") Then
                    ' ''    aiges_mh_prog2.Visible = False
                    ' ''    aiges_mh_prog2_Options.Visible = False
                    ' ''    aiges_mh_prog3.Visible = False
                    ' ''    aiges_mh_prog3_Options1.Visible = False
                    ' ''    lbl_Aegis_Rent.Text = "False"
                    ' ''    lbl_Aegis_Stand.Text = "False"

                    ' ''End If

                    ' ''If UCase(mhcountylbl.Text) = UCase("Florence") Then
                    ' ''    aiges_mh_prog2.Visible = False
                    ' ''    aiges_mh_prog2_Options.Visible = False
                    ' ''    aiges_mh_prog3.Visible = False
                    ' ''    aiges_mh_prog3_Options1.Visible = False
                    ' ''    lbl_Aegis_Rent.Text = "False"
                    ' ''    lbl_Aegis_Stand.Text = "False"

                    ' ''End If

                    ' ''If UCase(mhcountylbl.Text) = UCase("Georgetown") Then
                    ' ''    aiges_mh_prog2.Visible = False
                    ' ''    aiges_mh_prog2_Options.Visible = False
                    ' ''    aiges_mh_prog3.Visible = False
                    ' ''    aiges_mh_prog3_Options1.Visible = False
                    ' ''    lbl_Aegis_Rent.Text = "False"
                    ' ''    lbl_Aegis_Stand.Text = "False"

                    ' ''End If

                    ' ''If UCase(mhcountylbl.Text) = UCase("Horry") Then
                    ' ''    aiges_mh_prog2.Visible = False
                    ' ''    aiges_mh_prog2_Options.Visible = False
                    ' ''    aiges_mh_prog3.Visible = False
                    ' ''    aiges_mh_prog3_Options1.Visible = False
                    ' ''    lbl_Aegis_Rent.Text = "False"
                    ' ''    lbl_Aegis_Stand.Text = "False"

                    ' ''End If

                    ' ''If UCase(mhcountylbl.Text) = UCase("Jasper") Then
                    ' ''    aiges_mh_prog2.Visible = False
                    ' ''    aiges_mh_prog2_Options.Visible = False
                    ' ''    aiges_mh_prog3.Visible = False
                    ' ''    aiges_mh_prog3_Options1.Visible = False
                    ' ''    lbl_Aegis_Rent.Text = "False"
                    ' ''    lbl_Aegis_Stand.Text = "False"

                    ' ''End If

                    ' ''If UCase(mhcountylbl.Text) = UCase("Lancaster") Then
                    ' ''    aiges_mh_prog2.Visible = False
                    ' ''    aiges_mh_prog2_Options.Visible = False
                    ' ''    aiges_mh_prog3.Visible = False
                    ' ''    aiges_mh_prog3_Options1.Visible = False
                    ' ''    lbl_Aegis_Rent.Text = "False"
                    ' ''    lbl_Aegis_Stand.Text = "False"

                    ' ''End If

                    ' ''If UCase(mhcountylbl.Text) = UCase("Marion") Then
                    ' ''    aiges_mh_prog2.Visible = False
                    ' ''    aiges_mh_prog2_Options.Visible = False
                    ' ''    aiges_mh_prog3.Visible = False
                    ' ''    aiges_mh_prog3_Options1.Visible = False
                    ' ''    lbl_Aegis_Rent.Text = "False"
                    ' ''    lbl_Aegis_Stand.Text = "False"

                    ' ''End If

                    If UCase(mhcountylbl.Text) = UCase("Orangeburg") Then
                        aiges_mh_prog2.Visible = True
                        aiges_mh_prog2_Options.Visible = True
                        aiges_mh_prog3.Visible = True
                        aiges_mh_prog3_Options1.Visible = True
                        lbl_Aegis_Rent.Text = "True"
                        lbl_Aegis_Stand.Text = "True"

                    End If

                    ' ''If UCase(mhcountylbl.Text) = UCase("Sumter") Then
                    ' ''    aiges_mh_prog2.Visible = False
                    ' ''    aiges_mh_prog2_Options.Visible = False
                    ' ''    aiges_mh_prog3.Visible = False
                    ' ''    aiges_mh_prog3_Options1.Visible = False
                    ' ''    lbl_Aegis_Rent.Text = "False"
                    ' ''    lbl_Aegis_Stand.Text = "False"

                    ' ''End If

                    ' ''If UCase(mhcountylbl.Text) = UCase("Williamsburg") Then
                    ' ''    aiges_mh_prog2.Visible = False
                    ' ''    aiges_mh_prog2_Options.Visible = False
                    ' ''    aiges_mh_prog3.Visible = False
                    ' ''    aiges_mh_prog3_Options1.Visible = False
                    ' ''    lbl_Aegis_Rent.Text = "False"
                    ' ''    lbl_Aegis_Stand.Text = "False"

                    ' ''End If
                    '' ''open up per vickie 1/12/2014

                    ' ''If lblSub.Text = "1526" And UCase(mhcountylbl.Text) = UCase("Williamsburg") Then
                    ' ''    aiges_mh_prog2.Visible = False
                    ' ''    aiges_mh_prog2_Options.Visible = False
                    ' ''    aiges_mh_prog3.Visible = False
                    ' ''    aiges_mh_prog3_Options1.Visible = False
                    ' ''    If mhusagelbl.Text = "Rental" Then
                    ' ''        lbl_Aegis_Rent.Text = "True"
                    ' ''    Else

                    ' ''        lbl_Aegis_Stand.Text = "True"
                    ' ''    End If


                    ' ''End If


                    If UCase(mhcountylbl.Text) = UCase("Berkeley") Then
                        lbl_Lloyds_Pack.Text = "False"
                        lbl_Lloyds_Rent.Text = "False"
                        lbl_Lloyds_Stand.Text = "False"
                        lbl_Lloyds_SMH.Text = "False"

                    End If
                    ' ''If UCase(mhcountylbl.Text) = UCase("berkley") Then
                    ' ''    lbl_Lloyds_Pack.Text = "False"
                    ' ''    lbl_Lloyds_Rent.Text = "False"
                    ' ''    lbl_Lloyds_Stand.Text = "False"
                    ' ''    lbl_Lloyds_SMH.Text = "False"

                    ' ''End If
                    ' ''If UCase(mhcountylbl.Text) = UCase("Williamsburg") Then
                    ' ''    lbl_Lloyds_Pack.Text = "False"
                    ' ''    lbl_Lloyds_Rent.Text = "False"
                    ' ''    lbl_Lloyds_Stand.Text = "False"
                    ' ''    lbl_Lloyds_SMH.Text = "False"

                    ' ''End If




                    'End If



                    If UCase(mhcountylbl.Text) = UCase("Beaufort") Then
                        If lblSub.Text = "0561" Then
                            If mhusagelbl.Text = "Rental" Then
                                lbl_Aegis_Rent.Text = "True"
                            Else

                                lbl_Aegis_Stand.Text = "True"
                            End If

                        Else
                            aiges_mh_prog2.Visible = False
                            aiges_mh_prog2_Options.Visible = False
                            aiges_mh_prog3.Visible = False
                            aiges_mh_prog3_Options1.Visible = False
                            lbl_Aegis_Rent.Text = "False"
                            lbl_Aegis_Stand.Text = "False"
                        End If
                    End If
                    If UCase(mhcountylbl.Text) = UCase("Berkeley") Then
                        'Put in per Vicke 06/25/2014 CTS
                        If mhusagelbl.Text = "Rental" Then
                            lbl_Aegis_Rent.Text = "True"
                        Else

                            lbl_Aegis_Stand.Text = "True"
                        End If

                        'commented out per Vickie 06/25/2014 CTS
                        'If lblSub.Text = "1550" Then
                        '    If mhusagelbl.Text = "Rental" Then
                        '        lbl_Aegis_Rent.Text = "True"
                        '    Else

                        '        lbl_Aegis_Stand.Text = "True"
                        '    End If

                        'Else
                        '    aiges_mh_prog2.Visible = False
                        '    aiges_mh_prog2_Options.Visible = False
                        '    aiges_mh_prog3.Visible = False
                        '    aiges_mh_prog3_Options1.Visible = False
                        '    lbl_Aegis_Rent.Text = "False"
                        '    lbl_Aegis_Stand.Text = "False"
                        'End If
                    End If

                    If UCase(mhcountylbl.Text) = UCase("Colleton") Then
                        If lblSub.Text = "1545" Then
                            If mhusagelbl.Text = "Rental" Then
                                lbl_Aegis_Rent.Text = "True"
                            Else

                                lbl_Aegis_Stand.Text = "True"
                            End If

                        Else
                            aiges_mh_prog2.Visible = False
                            aiges_mh_prog2_Options.Visible = False
                            aiges_mh_prog3.Visible = False
                            aiges_mh_prog3_Options1.Visible = False
                            lbl_Aegis_Rent.Text = "False"
                            lbl_Aegis_Stand.Text = "False"
                        End If
                    End If

                    If UCase(mhcountylbl.Text) = UCase("Florence") Then
                        If lblSub.Text = "1441" Then
                            If mhusagelbl.Text = "Rental" Then
                                lbl_Aegis_Rent.Text = "True"
                            Else

                                lbl_Aegis_Stand.Text = "True"
                            End If

                        Else
                            aiges_mh_prog2.Visible = False
                            aiges_mh_prog2_Options.Visible = False
                            aiges_mh_prog3.Visible = False
                            aiges_mh_prog3_Options1.Visible = False
                            lbl_Aegis_Rent.Text = "False"
                            lbl_Aegis_Stand.Text = "False"
                        End If
                    End If

                    If UCase(mhcountylbl.Text) = UCase("Georgetown") Then
                        If lblSub.Text = "0079" Then
                            If mhusagelbl.Text = "Rental" Then
                                lbl_Aegis_Rent.Text = "True"
                            Else

                                lbl_Aegis_Stand.Text = "True"
                            End If

                        Else
                            aiges_mh_prog2.Visible = False
                            aiges_mh_prog2_Options.Visible = False
                            aiges_mh_prog3.Visible = False
                            aiges_mh_prog3_Options1.Visible = False
                            lbl_Aegis_Rent.Text = "False"
                            lbl_Aegis_Stand.Text = "False"
                        End If
                    End If

                    If UCase(mhcountylbl.Text) = UCase("Jasper") Then
                        If lblSub.Text = "6905" Then
                            If mhusagelbl.Text = "Rental" Then
                                lbl_Aegis_Rent.Text = "True"
                            Else

                                lbl_Aegis_Stand.Text = "True"
                            End If

                        Else
                            aiges_mh_prog2.Visible = False
                            aiges_mh_prog2_Options.Visible = False
                            aiges_mh_prog3.Visible = False
                            aiges_mh_prog3_Options1.Visible = False
                            lbl_Aegis_Rent.Text = "False"
                            lbl_Aegis_Stand.Text = "False"
                        End If
                    End If

                    If UCase(mhcountylbl.Text) = UCase("Orangeburg") Then
                        If lblSub.Text = "3916" Then
                            If mhusagelbl.Text = "Rental" Then
                                lbl_Aegis_Rent.Text = "True"
                            Else

                                lbl_Aegis_Stand.Text = "True"
                            End If

                        Else
                            aiges_mh_prog2.Visible = False
                            aiges_mh_prog2_Options.Visible = False
                            aiges_mh_prog3.Visible = False
                            aiges_mh_prog3_Options1.Visible = False
                            lbl_Aegis_Rent.Text = "False"
                            lbl_Aegis_Stand.Text = "False"
                        End If
                    End If
                    If UCase(mhcountylbl.Text) = UCase("Orangeburg") Then
                        If lblSub.Text = "6912" Or lblSub.Text = "3916" Then
                            If mhusagelbl.Text = "Rental" Then
                                lbl_Aegis_Rent.Text = "True"
                            Else

                                lbl_Aegis_Stand.Text = "True"
                            End If
                            aiges_mh_prog2.Visible = True
                            aiges_mh_prog2_Options.Visible = True
                            aiges_mh_prog3.Visible = False
                            aiges_mh_prog3_Options1.Visible = False
                            lbl_Aegis_Rent.Text = "False"
                            lbl_Aegis_Stand.Text = "True"
                        Else
                            aiges_mh_prog2.Visible = False
                            aiges_mh_prog2_Options.Visible = False
                            aiges_mh_prog3.Visible = False
                            aiges_mh_prog3_Options1.Visible = False
                            lbl_Aegis_Rent.Text = "False"
                            lbl_Aegis_Stand.Text = "False"
                        End If
                    End If

                    If UCase(mhcountylbl.Text) = UCase("Williamsburg") Then
                        If lblSub.Text = "1526" Then
                            If mhusagelbl.Text = "Rental" Then
                                lbl_Aegis_Rent.Text = "True"
                            Else

                                lbl_Aegis_Stand.Text = "True"
                            End If

                        Else
                            aiges_mh_prog2.Visible = False
                            aiges_mh_prog2_Options.Visible = False
                            aiges_mh_prog3.Visible = False
                            aiges_mh_prog3_Options1.Visible = False
                            lbl_Aegis_Rent.Text = "False"
                            lbl_Aegis_Stand.Text = "False"
                        End If
                    End If


                End If
            End If

            End If

        If mhtypelbl.Text = "Doublewide" Or mhtypelbl.Text = "Modular" Then

        Else
            SC_MH_08.Visible = False
            SC08_mh_prog_Options.Visible = False
            SC08OptionRow.Visible = False
            lbl_Lloyds_SMH.Text = "False"
        End If
        'Would like to get this part to the database:
        If UCase(mhcountylbl.Text) = UCase("Beaufort") Then
            lbl_Lloyds_SMH.Text = "False"
        End If
        If UCase(mhcountylbl.Text) = UCase("Charleston") Then
            lbl_Lloyds_SMH.Text = "False"
        End If
        If UCase(mhcountylbl.Text) = UCase("Colleton") Then
            lbl_Lloyds_SMH.Text = "False"
        End If
        If UCase(mhcountylbl.Text) = UCase("Georgetown") Then
            lbl_Lloyds_SMH.Text = "False"
        End If
        If UCase(mhcountylbl.Text) = UCase("Horry") Then
            lbl_Lloyds_SMH.Text = "False"
        End If
        If UCase(mhcountylbl.Text) = UCase("Jasper") Then
            lbl_Lloyds_SMH.Text = "False"
        End If

        'Added per vickie 4/20/2014
        If UCase(mhcountylbl.Text) = UCase("Brunswick") Then
            lbl_Lloyds_SMH.Text = "False"
        End If
        If UCase(mhcountylbl.Text) = UCase("New Hanover") Then
            lbl_Lloyds_SMH.Text = "False"
        End If
        If UCase(mhcountylbl.Text) = UCase("Pender") Then
            lbl_Lloyds_SMH.Text = "False"
        End If
        If UCase(mhcountylbl.Text) = UCase("Onslow") Then
            lbl_Lloyds_SMH.Text = "False"
        End If
        If UCase(mhcountylbl.Text) = UCase("Carteret") Then
            lbl_Lloyds_SMH.Text = "False"
        End If
        If UCase(mhcountylbl.Text) = UCase("Craven") Then
            lbl_Lloyds_SMH.Text = "False"
        End If
        If UCase(mhcountylbl.Text) = UCase("Pamlico") Then
            lbl_Lloyds_SMH.Text = "False"
        End If
        If UCase(mhcountylbl.Text) = UCase("Hyde") Then
            lbl_Lloyds_SMH.Text = "False"
        End If
        If UCase(mhcountylbl.Text) = UCase("Dare") Then
            lbl_Lloyds_SMH.Text = "False"
        End If
        If UCase(mhcountylbl.Text) = UCase("Tyrrell") Then
            lbl_Lloyds_SMH.Text = "False"
        End If
        If UCase(mhcountylbl.Text) = UCase("Washington") Then
            lbl_Lloyds_SMH.Text = "False"
        End If
        If UCase(mhcountylbl.Text) = UCase("Bertie") Then
            lbl_Lloyds_SMH.Text = "False"
        End If
        If UCase(mhcountylbl.Text) = UCase("Hertford") Then
            lbl_Lloyds_SMH.Text = "False"
        End If
        If UCase(mhcountylbl.Text) = UCase("Chowan") Then
            lbl_Lloyds_SMH.Text = "False"
        End If
        If UCase(mhcountylbl.Text) = UCase("Perquimans") Then
            lbl_Lloyds_SMH.Text = "False"
        End If
        If UCase(mhcountylbl.Text) = UCase("Pasquotank") Then
            lbl_Lloyds_SMH.Text = "False"
        End If
        If UCase(mhcountylbl.Text) = UCase("Camden") Then
            lbl_Lloyds_SMH.Text = "False"
        End If
        If UCase(mhcountylbl.Text) = UCase("Currituck") Then
            lbl_Lloyds_SMH.Text = "False"
        End If





        Dim agencyNum As String = mySession.CurrentUser.AccountNumber.ToString()
        agencyNum = agencyNum.Substring(0, 4)
        If agencyNum = "6921" And UCase(mhcountylbl.Text) = UCase("Berkeley") Then
            lbl_Lloyds_Pack.Text = "False"
            lbl_Lloyds_Rent.Text = "False"
            lbl_Lloyds_Stand.Text = "False"
            lbl_Lloyds_SMH.Text = "False"
        End If

        If lblSub.Text = "6921" And UCase(mhcountylbl.Text) = UCase("Colleton") Then
            lbl_Lloyds_Pack.Text = "False"
            lbl_Lloyds_Rent.Text = "False"
            lbl_Lloyds_Stand.Text = "False"
            lbl_Lloyds_SMH.Text = "False"
        End If

        If lblSub.Text = "6921" And UCase(mhcountylbl.Text) = UCase("Berkeley") Then
            lbl_Lloyds_Pack.Text = "False"
            lbl_Lloyds_Rent.Text = "False"
            lbl_Lloyds_Stand.Text = "False"
            lbl_Lloyds_SMH.Text = "False"
        End If

        If agencyNum = "6921" And UCase(mhcountylbl.Text) = UCase("Colleton") Then
            lbl_Lloyds_Pack.Text = "False"
            lbl_Lloyds_Rent.Text = "False"
            lbl_Lloyds_Stand.Text = "False"
            lbl_Lloyds_SMH.Text = "False"
        End If

        If agencyNum = "1721" And UCase(mhcountylbl.Text) = UCase("Berkeley") Then
            lbl_Lloyds_Pack.Text = "False"
            lbl_Lloyds_Rent.Text = "False"
            lbl_Lloyds_Stand.Text = "False"
            lbl_Lloyds_SMH.Text = "False"
        End If

        If lblSub.Text = "1721" And UCase(mhcountylbl.Text) = UCase("Berkeley") Then
            lbl_Lloyds_Pack.Text = "False"
            lbl_Lloyds_Rent.Text = "False"
            lbl_Lloyds_Stand.Text = "False"
            lbl_Lloyds_SMH.Text = "False"
        End If

        'open up for this company per vickie 1/12/2014

        If lblSub.Text = "1550" And UCase(mhcountylbl.Text) = UCase("Berkeley") Then
            If mhusagelbl.Text = "Owner" Or mhusagelbl.Text = "Seasonal" Then
                lbl_Lloyds_Pack.Text = "True"
                lbl_Lloyds_Rent.Text = "False"
                lbl_Lloyds_Stand.Text = "True"
                lbl_Lloyds_SMH.Text = "False"
                If mhstatelbl.Text = "SC" Then
                    lbl_Lloyds_Pack.Text = "False"

                    If mhtypelbl.Text = "Doublewide" Or mhtypelbl.Text = "Modular" Then
                        'if HO8 then make visible and call load data or calculation

                        lbl_Lloyds_SMH.Text = "True"
                    Else

                        lbl_Lloyds_SMH.Text = "False"
                    End If
                End If

            End If
            If mhusagelbl.Text = "Rental" Then
                lbl_Lloyds_Pack.Text = "False"
                lbl_Lloyds_Rent.Text = "True"
                lbl_Lloyds_Stand.Text = "False"
                lbl_Lloyds_SMH.Text = "False"

            End If
            If CInt(mhvalue) > 115000 Then
                lbl_Lloyds_Stand.Text = "False"
                lbl_Lloyds_Pack.Text = "False"
            End If

            'lbl_Lloyds_Pack.Text = "True"
            'lbl_Lloyds_Rent.Text = "True"
            'lbl_Lloyds_Stand.Text = "True"
            'lbl_Lloyds_SMH.Text = "True"
        End If
        'open up per vickie 1/12/2014

        If lblSub.Text = "1526" And UCase(mhcountylbl.Text) = UCase("Williamsburg") Then
            If mhusagelbl.Text = "Owner" Or mhusagelbl.Text = "Seasonal" Then
                lbl_Lloyds_Pack.Text = "True"
                lbl_Lloyds_Rent.Text = "False"
                lbl_Lloyds_Stand.Text = "True"
                lbl_Lloyds_SMH.Text = "False"
                If mhstatelbl.Text = "SC" Then
                    lbl_Lloyds_Pack.Text = "False"
                    If mhtypelbl.Text = "Doublewide" Or mhtypelbl.Text = "Modular" Then
                        'if HO8 then make visible and call load data or calculation

                        lbl_Lloyds_SMH.Text = "True"
                    Else

                        lbl_Lloyds_SMH.Text = "False"
                    End If
                End If

            End If
            If mhusagelbl.Text = "Rental" Then
                lbl_Lloyds_Pack.Text = "False"
                lbl_Lloyds_Rent.Text = "True"
                lbl_Lloyds_Stand.Text = "False"
                lbl_Lloyds_SMH.Text = "False"

            End If
            'lbl_Lloyds_Pack.Text = "True"
            'lbl_Lloyds_Rent.Text = "True"
            'lbl_Lloyds_Stand.Text = "True"
            'lbl_Lloyds_SMH.Text = "True"
        End If


        If lblskirt.Text = "None" Then
            lbl_Aegis_Rent.Text = "False"
            lbl_Aegis_Stand.Text = "False"
            lbl_Lloyds_SMH.Text = "False"
        End If
        If lbl_Lloyds_Pack.Text = "True" Then
            ar_mh_prog1.Visible = True
            ar_mh_prog1_Options.Visible = True
        Else
            ar_mh_prog1.Visible = False
            ar_mh_prog1_Options.Visible = False

        End If
        If lbl_Lloyds_Stand.Text = "True" Then
            ar_mh_prog2.Visible = True
            ar_mh_prog2_Options.Visible = True
        Else
            ar_mh_prog2.Visible = False
            ar_mh_prog2_Options.Visible = False
        End If
        If lbl_Lloyds_Rent.Text = "True" Then
            ar_mh_prog3.Visible = True
            ar_mh_prog3_Options.Visible = True
        Else
            ar_mh_prog3.Visible = False
            ar_mh_prog3_Options.Visible = False
        End If
        If lbl_Lloyds_SMH.Text = "True" Then
            SC_MH_08.Visible = True
            SC08_mh_prog_Options.Visible = True
            SC08OptionRow.Visible = True
        Else
            SC_MH_08.Visible = False
            SC08_mh_prog_Options.Visible = False
            SC08OptionRow.Visible = False
        End If
        If lbl_Aegis_Rent.Text = "False" And lbl_Aegis_Stand.Text = "False" And lbl_Lloyds_Pack.Text = "False" And lbl_Lloyds_Rent.Text = "False" And lbl_Lloyds_SMH.Text = "False" And lbl_Lloyds_Stand.Text = "False" Then
            '   AR_PremiumUpdatePanel.Visible = False
        End If
        If UCase(mhusagelbl.Text) = UCase("Tenant") Then
            lbl_Lloyds_Pack.Text = "False"
            lbl_Lloyds_Rent.Text = "False"
            lbl_Lloyds_Stand.Text = "False"
            lbl_Lloyds_SMH.Text = "False"
            lbl_Aegis_Rent.Text = "False"
            lbl_Aegis_Stand.Text = "False"
            lbl_Lloyds_SMH.Text = "False"
            lbl_Aegis_Rent.Text = "False"
            lbl_Aegis_Stand.Text = "False"
            ar_mh_prog3.Visible = False
            ar_mh_prog3_Options.Visible = False
        End If
        If mhdistlbl.Text = "Less than 2 miles" Then
            lbl_Lloyds_Pack.Text = "False"
            lbl_Lloyds_Rent.Text = "False"
            lbl_Lloyds_Stand.Text = "False"
            lbl_Lloyds_SMH.Text = "False"
            lbl_Aegis_Rent.Text = "False"
            lbl_Aegis_Stand.Text = "False"
            lbl_Lloyds_SMH.Text = "False"
            lbl_Aegis_Rent.Text = "False"
            lbl_Aegis_Stand.Text = "False"
            ar_mh_prog2.Visible = False
            ar_mh_prog2_Options.Visible = False
            ar_mh_prog3.Visible = False
            ar_mh_prog3_Options.Visible = False
            lbl_Lloyds_Pack.Text = "False"
            lbl_Lloyds_Rent.Text = "False"
            lbl_Lloyds_Stand.Text = "False"
            lbl_Lloyds_SMH.Text = "False"
            lbl_Amslic_Stand.Text = "True"

            lbl_Lloyds_SMH.Text = "False"
            lbl_Aegis_Rent.Text = "False"
            lbl_Aegis_Stand.Text = "False"
            lbl_Amslic_Rent.Text = "False"
            '  lbl_Amslic_Stand.Text = "False"
            SC_MH_08.Visible = False
            SC08_mh_prog_Options.Visible = False
            SC08OptionRow.Visible = False
            aiges_mh_prog2.Visible = False
            aiges_mh_prog2_Options.Visible = False
            aiges_mh_prog3.Visible = False
            aiges_mh_prog3_Options1.Visible = False
            ar_mh_prog1.Visible = False
            ar_mh_prog1_Options.Visible = False
            tstorm1.Visible = False
            tstorm2.Visible = False
            tstorm3.Visible = False
            If mhusagelbl.Text = "Rental" Then
                ar_mh_prog2.Visible = False
                ar_mh_prog2_Options.Visible = False
                ar_mh_prog3.Visible = True
                ar_mh_prog3_Options.Visible = True
                lbl_Lloyds_Rent.Text = "False"
                lbl_Lloyds_Stand.Text = "False"
                lbl_Lloyds_Pack.Text = "False"

            End If
        End If

        If mhstatelbl.Text = "TN" Then
            lbl_Lloyds_SMH.Text = "False"
            SC_MH_08.Visible = False
            SC08_mh_prog_Options.Visible = False
            SC08OptionRow.Visible = False
        End If

        'WMJ

        'restricted counties for NC
        Dim ctyNC As New List(Of String)
        ctyNC.Add(UCase("Beaufort"))
        ctyNC.Add(UCase("Bladen"))
        ctyNC.Add(UCase("Brunswick"))
        ctyNC.Add(UCase("Camden"))
        ctyNC.Add(UCase("Carteret"))
        ctyNC.Add(UCase("Chowan"))
        ctyNC.Add(UCase("Columbus"))
        ctyNC.Add(UCase("Craven"))
        ctyNC.Add(UCase("Cumberland"))
        ctyNC.Add(UCase("Currituck"))
        ctyNC.Add(UCase("Dare"))
        ctyNC.Add(UCase("Duplin"))
        ctyNC.Add(UCase("Edgecombe"))
        ctyNC.Add(UCase("Gates"))
        ctyNC.Add(UCase("Greene"))
        ctyNC.Add(UCase("Halifax"))
        ctyNC.Add(UCase("Hertford"))
        ctyNC.Add(UCase("Hyde"))
        ctyNC.Add(UCase("Johnston"))
        ctyNC.Add(UCase("Jones"))
        ctyNC.Add(UCase("Lenoir"))
        ctyNC.Add(UCase("Martin"))
        ctyNC.Add(UCase("Nash"))
        ctyNC.Add(UCase("New Hanover"))
        ctyNC.Add(UCase("Northampton"))
        ctyNC.Add(UCase("Onslow"))
        ctyNC.Add(UCase("Pamlico"))
        ctyNC.Add(UCase("Pasquotank"))
        ctyNC.Add(UCase("Pender"))
        ctyNC.Add(UCase("Perquimans"))
        ctyNC.Add(UCase("Pitt"))
        ctyNC.Add(UCase("Robeson"))
        ctyNC.Add(UCase("Sampson"))
        ctyNC.Add(UCase("Tyrrell"))
        ctyNC.Add(UCase("Washington"))
        ctyNC.Add(UCase("Wayne"))
        ctyNC.Add(UCase("Wilson"))

        'Restricted counties for VA
        Dim ctyVA As New List(Of String)
        ctyVA.Add(UCase("Accomack"))
        ' ctyVA.Add(UCase("Bland"))
        'ctyVA.Add(UCase("Buchanan"))
        'ctyVA.Add(UCase("Dickenson"))
        'ctyVA.Add(UCase("Lee"))
        ctyVA.Add(UCase("Northampton"))
        'ctyVA.Add(UCase("Russell"))
        ' ctyVA.Add(UCase("Scott"))
        'ctyVA.Add(UCase("Tazewell"))
        'ctyVA.Add(UCase("Wise and York"))
        ctyVA.Add(UCase("Island of Chincoteague"))
        ctyVA.Add(UCase("Chesapeake"))
        ctyVA.Add(UCase("Hampton"))
        ctyVA.Add(UCase("Newport News"))
        ctyVA.Add(UCase("Norfolk"))
        ctyVA.Add(UCase("Norton"))
        ctyVA.Add(UCase("Poquoson"))
        ctyVA.Add(UCase("Portsmouth"))
        ctyVA.Add(UCase("Virginia Beach"))
        ctyVA.Add(UCase("Gloucester"))
        ctyVA.Add(UCase("King George"))
        ctyVA.Add(UCase("Lancaster"))
        ctyVA.Add(UCase("Mathews"))
        ctyVA.Add(UCase("Middlesex"))
        ctyVA.Add(UCase("Northumberland"))
        ctyVA.Add(UCase("Spotsylvania"))
        ctyVA.Add(UCase("Stafford"))

        ctyVA.Add(UCase("Accomack"))
        ctyVA.Add(UCase("Isle of Wight"))
        ctyVA.Add(UCase("Northampton"))
        ctyVA.Add(UCase("Southampton"))
        ctyVA.Add(UCase("York"))
        'ctyVA.Add(UCase("Bland"))
        'ctyVA.Add(UCase("Buchanan"))
        'ctyVA.Add(UCase("Dickenson"))
        'ctyVA.Add(UCase("Lee"))
        'ctyVA.Add(UCase("Russell"))
        'ctyVA.Add(UCase("Scott"))
        ctyVA.Add(UCase("Smyth"))
        'ctyVA.Add(UCase("Tazewell"))
        ctyVA.Add(UCase("Washington"))
        'ctyVA.Add(UCase("Wise"))
        ctyVA.Add(UCase("Island of Chincoteague"))
        ctyVA.Add(UCase("Petersburg City"))

        'Restricted cities for WMJ VA
        Dim townVA As New List(Of String)
        townVA.Add(UCase("Fredericksburg"))
        townVA.Add(UCase("Chesapeake"))
        townVA.Add(UCase("Hampton"))
        townVA.Add(UCase("Newport News"))
        townVA.Add(UCase("Norfolk"))
        townVA.Add(UCase("Poquoson"))
        townVA.Add(UCase("Portsmouth"))
        townVA.Add(UCase("Suffolk"))
        townVA.Add(UCase("Virginia Beach"))
        townVA.Add(UCase("Bristol"))
        townVA.Add(UCase("Norton"))
        townVA.Add(UCase("Petersburg"))
        townVA.Add(UCase("Richmond"))
        townVA.Add(UCase("Fredericksbrg"))
        townVA.Add(UCase("Virginia bch"))

        'Agents allowed to quote
        Dim agentVA As New List(Of String)
        agentVA.Add("7318")
        agentVA.Add("1326")
        agentVA.Add("7307")
        agentVA.Add("7305")
        agentVA.Add("7320")
        agentVA.Add("7308")
        agentVA.Add("7309")
        agentVA.Add("6901")
        agentVA.Add("6934")




        wmj_mh_prog2.Visible = False
        wmj_mh_prog2_Options.Visible = False
        wmj_mh_prognc1.Visible = False
        wmj_mh_prognc1_Options.Visible = False
        wmj_mh_prognc2.Visible = False
        wmj_mh_prognc2_Options.Visible = False
        wmj_mh_prognc3.Visible = False
        wmj_mh_prognc3_Options.Visible = False
        If mhstatelbl.Text = "VA" Then
            If CInt(MHValuelbl.Text) < 125001 Then


                If mhtypelbl.Text = "Doublewide" Or mhtypelbl.Text = "Modular" Then
                    If mhusagelbl.Text = "Owner" Or mhusagelbl.Text = "Seasonal" Then
                        If lapselbl.Text = "No" Then
                            Dim restrictva As Boolean = False
                            'check for restricted counties
                            For Each sa As String In ctyVA
                                If UCase(sa) = UCase(mhcountylbl.Text) Then
                                    restrictva = True
                                End If
                            Next
                            'check for restricted cities
                            For Each sa As String In townVA
                                If UCase(sa) = UCase(citylbl.Text) Then
                                    restrictva = True
                                End If
                            Next

                            'this overides the above county and city checks for agents that are allowed to quote
                            For Each sa As String In agentVA
                                If UCase(sa) = UCase(lblSub.Text) Then

                                    If UCase(mhcountylbl.Text) = UCase("Bland") Then
                                        restrictva = False
                                    ElseIf UCase(mhcountylbl.Text) = UCase("Buchanan") Then
                                        restrictva = False
                                    ElseIf UCase(mhcountylbl.Text) = UCase("Dickenson") Then
                                        restrictva = False
                                    ElseIf UCase(mhcountylbl.Text) = UCase("Lee") Then
                                        restrictva = False
                                    ElseIf UCase(mhcountylbl.Text) = UCase("Russell") Then
                                        restrictva = False
                                    ElseIf UCase(mhcountylbl.Text) = UCase("Scott") Then
                                        restrictva = False
                                    ElseIf UCase(mhcountylbl.Text) = UCase("Tazewell") Then
                                        restrictva = False
                                    ElseIf UCase(mhcountylbl.Text) = UCase("Wise") Then
                                        restrictva = False

                                    End If
                                    If UCase(citylbl.Text) = UCase("Norton") Then
                                        restrictva = False
                                    ElseIf UCase(citylbl.Text) = UCase("Bristol") Then

                                        restrictva = False
                                    End If

                                    'restrictva = True
                                End If
                            Next
                            'make sure the MH is with in age limit
                            Dim age As Integer
                            If IsNumeric(mhyearlbl.Text) Then
                                age = Now.Year - CInt(mhyearlbl.Text)
                            End If

                            If age > 20 Then

                                restrictva = True
                            End If

                            If restrictva = False Then
                                lbl_WMJ_Pack.Text = "True"
                            Else
                                lbl_WMJ_Pack.Text = "False"
                            End If

                        Else
                            lbl_WMJ_Pack.Text = "False"
                        End If


                    Else
                        lbl_WMJ_Pack.Text = "False"
                    End If
                Else

                    lbl_WMJ_Pack.Text = "False"
                End If
            Else
                lbl_WMJ_Pack.Text = "False"
            End If

        Else
            lbl_WMJ_Pack.Text = "False"
        End If

        If mhstatelbl.Text = "NC" Then
            If CInt(MHValuelbl.Text) < 125001 And CInt(MHValuelbl.Text) >= 30000 Then
                If mhtypelbl.Text = "Doublewide" Or mhtypelbl.Text = "Modular" Then
                    If mhusagelbl.Text = "Owner" Or mhusagelbl.Text = "Seasonal" Then
                        If lapselbl.Text = "No" Then
                            Dim restrict As Boolean = False
                            For Each s As String In ctyNC
                                If UCase(s) = UCase(mhcountylbl.Text) Then
                                    restrict = True
                                End If
                            Next

                            'make sure the mh is of age
                            Dim age As Integer
                            If IsNumeric(mhyearlbl.Text) Then
                                age = Now.Year - CInt(mhyearlbl.Text)
                            End If

                            If age > 20 Then

                                restrict = True
                            End If

                            If restrict = False Then
                                lbl_WMJ_PackNC.Text = "True"
                            Else
                                lbl_WMJ_PackNC.Text = "False"
                            End If

                        Else
                            lbl_WMJ_PackNC.Text = "False"
                        End If

                    Else
                        lbl_WMJ_PackNC.Text = "False"
                    End If
                Else

                    lbl_WMJ_PackNC.Text = "False"
                End If
            Else
                lbl_WMJ_PackNC.Text = "False"
            End If

        Else
            lbl_WMJ_PackNC.Text = "False"
        End If
        If protection.Text = "10" Then
            lbl_WMJ_Pack.Text = "False"
            lbl_WMJ_PackNC.Text = "False"
        End If
        'Temp  Only allow UW to test WMJ
        'Dim open As String
        'If mySession.CurrentUser.AccountNumber.ToString = "0030000" Then ' lblSub.Text = "0300" Then

        'Else

        '    If mySession.CurrentUser.UWUser.ToString = "False" Then

        '        lbl_WMJ_Pack.Text = "False"
        '        lbl_WMJ_PackNC.Text = "False"


        '    End If
        'End If


        'if Vacant no one shows up

        If mhusagelbl.Text = "Vacant" Then
            lbl_Lloyds_Pack.Text = "False"
            lbl_Lloyds_Rent.Text = "False"
            lbl_Lloyds_Stand.Text = "False"
            lbl_Lloyds_SMH.Text = "False"
            lbl_Aegis_Rent.Text = "False"
            lbl_Aegis_Stand.Text = "False"
            lbl_Lloyds_SMH.Text = "False"
            lbl_Aegis_Rent.Text = "False"
            lbl_Aegis_Stand.Text = "False"
            ar_mh_prog2.Visible = False
            ar_mh_prog2_Options.Visible = False
            ar_mh_prog3.Visible = False
            ar_mh_prog3_Options.Visible = False
            lbl_Lloyds_Pack.Text = "False"
            lbl_Lloyds_Rent.Text = "False"
            lbl_Lloyds_Stand.Text = "False"
            lbl_Lloyds_SMH.Text = "False"
            lbl_Amslic_Stand.Text = "True"

            lbl_Lloyds_SMH.Text = "False"
            lbl_Aegis_Rent.Text = "False"
            lbl_Aegis_Stand.Text = "False"
            lbl_Amslic_Rent.Text = "False"
            SC_MH_08.Visible = False
            SC08_mh_prog_Options.Visible = False
            SC08OptionRow.Visible = False
            aiges_mh_prog2.Visible = False
            aiges_mh_prog2_Options.Visible = False
            aiges_mh_prog3.Visible = False
            aiges_mh_prog3_Options1.Visible = False
            ar_mh_prog1.Visible = False
            ar_mh_prog1_Options.Visible = False
            tstorm1.Visible = False
            tstorm2.Visible = False
            tstorm3.Visible = False
            lbl_WMJ_Pack.Text = "False"
        End If
    End Sub
    Protected Sub financebtn2_Click(ByVal sender As Object, ByVal e As EventArgs) Handles financebtn2.Click
        Dim ds As System.Data.DataSet
        ds = runQueryDS("SELECT ARRateType, state  FROM tblQuotes WHERE quoteID ='" & quoteIDlbl.Text & "'", "ColonialMHConnectionString")
        If ds.Tables(0).Rows.Count > 0 Then
            LloydsState = ds.Tables(0).Rows(0).Item("state")
        End If
        Dim downPayment, Length, quoteID As String
        quoteID = quoteIDlbl.Text
        downPayment = DownPaymentPercentRB.SelectedValue.ToString
        Length = FinanceLengthRB.SelectedValue.ToString

        If downPayment = "" Or Length = "" Or LloydsState.ToUpper <> "SC" Then
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


        ds = runQueryDS("EXEC sp_GetLloydsFinanceData '" & quoteID & "','" & downPayment & "','" & Length & "'", "ColonialMHConnectionString")
        If ds.Tables(0).Rows.Count > 0 Then
            Dim test As String
            test = ds.Tables(0).Rows(0).Item("MonthlyPayments").ToString()
            test = ds.Tables(0).Rows(0).Item("AmountFinanced").ToString()
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

        ' SCFinancingUpdatePanel.Update()
        ' ModalPopupExtender4.Show()


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
        Dim ds As System.Data.DataSet
        ds = runQueryDS("SELECT ARRateType, state  FROM tblQuotes WHERE quoteID ='" & quoteIDlbl.Text & "'", "ColonialMHConnectionString")
        If ds.Tables(0).Rows.Count > 0 Then
           LloydsState = ds.Tables(0).Rows(0).Item("state") 
        End If
        Dim downPayment, Length, quoteID As String
        quoteID = LloydsQuote
        If quoteID Is Nothing Then
            quoteID = quoteIDlbl.Text
        End If
        downPayment = DownPaymentPercentRB.SelectedValue.ToString
        Length = FinanceLengthRB.SelectedValue.ToString

        If downPayment = "" Or Length = "" Or LloydsState.ToUpper <> "SC" Then
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


        ds = runQueryDS("EXEC sp_GetLloydsFinanceData '" & quoteID & "','" & downPayment & "','" & Length & "'", "ColonialMHConnectionString")
        Try
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


        Catch ex As Exception

        End Try

        'financelbl.Text = "<script language='javascript'> alert('hello'); " & "<" & "/script>"

        ' SCFinancingUpdatePanel.Update()



    End Sub

    Protected Sub selectamslicbtn_Click(sender As Object, e As EventArgs) Handles selectamslicbtn.Click
        HiddenFieldSelected.Value = "AMSLIC Standard"
        rateTypelbl.Text = "AMSLIC Standard"
        rateTypelbl.Font.Bold = True
        rateTypelbl.ForeColor = Drawing.Color.Green


        'Set Selected to AR1 in database  Not saving right now...
        Try

            If quoteIDlbl.Text <> "" Then
                Me.Page.GetType.InvokeMember("updateQuote", System.Reflection.BindingFlags.InvokeMethod, Nothing, Me.Page, New Object() {quoteIDlbl.Text})
            Else
                Me.Page.GetType.InvokeMember("save", System.Reflection.BindingFlags.InvokeMethod, Nothing, Me.Page, New Object() {})

            End If
        Catch ex As Exception
            errortrap("UPDATE AMSLIC Package", "SELECTED AMSLIC Standard", ex.Message)
        End Try
        Dim ds As System.Data.DataSet
        ds = runQueryDS("EXEC sp_SetQuoteRateType '" & quoteIDlbl.Text & "', 'AMSLIC Standard'", "ColonialMHConnectionString")
        'Check Financing options
        ds = runQueryDS("SELECT ARRateType, state  FROM tblQuotes WHERE quoteID ='" & quoteIDlbl.Text & "'", "ColonialMHConnectionString")
        If ds.Tables(0).Rows.Count > 0 Then
            If ds.Tables(0).Rows(0).Item("state") = "SC" And Not rateTypelbl.Text.ToString.ToUpper.Contains("AEG") Then
                'SCPremFinbtn.Visible = True
                'calcSCFinancing()
            Else
                'SCPremFinbtn.Visible = False
            End If
        End If
        premiumBtnTable.Attributes.Add("style", "display:block")
    End Sub

    Protected Sub selectamslicRentbtn_Click(sender As Object, e As EventArgs) Handles selectamslicRentbtn.Click
        HiddenFieldSelected.Value = "AMSLIC Rental"
        rateTypelbl.Text = "AMSLIC Rental"
        rateTypelbl.Font.Bold = True
        rateTypelbl.ForeColor = Drawing.Color.Green


        'Set Selected to AR1 in database  Not saving right now...
        Try

            If quoteIDlbl.Text <> "" Then
                Me.Page.GetType.InvokeMember("updateQuote", System.Reflection.BindingFlags.InvokeMethod, Nothing, Me.Page, New Object() {quoteIDlbl.Text})
            Else
                Me.Page.GetType.InvokeMember("save", System.Reflection.BindingFlags.InvokeMethod, Nothing, Me.Page, New Object() {})

            End If
        Catch ex As Exception
            errortrap("UPDATE AMSLIC Rental", "SELECTED AMSLIC Rental", ex.Message)
        End Try
        Dim ds As System.Data.DataSet
        ds = runQueryDS("EXEC sp_SetQuoteRateType '" & quoteIDlbl.Text & "', 'AMSLIC Rental'", "ColonialMHConnectionString")
        'Check Financing options
        ds = runQueryDS("SELECT ARRateType, state  FROM tblQuotes WHERE quoteID ='" & quoteIDlbl.Text & "'", "ColonialMHConnectionString")
        If ds.Tables(0).Rows.Count > 0 Then
            If ds.Tables(0).Rows(0).Item("state") = "SC" And Not rateTypelbl.Text.ToString.ToUpper.Contains("AEG") Then
                'SCPremFinbtn.Visible = True
                'calcSCFinancing()
            Else
                'SCPremFinbtn.Visible = False
            End If
        End If
        premiumBtnTable.Attributes.Add("style", "display:block")
    End Sub
    Protected Sub Load_Amslic()
        Dim Connection As String = System.Configuration.ConfigurationManager.ConnectionStrings("ColonialMHConnectionString").ConnectionString
        Dim dbConnection As System.Data.IDbConnection = New System.Data.SqlClient.SqlConnection(Connection)
        Dim cmd As New SqlCommand("sp_GetAmslicQuoteData", dbConnection)
        cmd.CommandType = CommandType.StoredProcedure
        cmd.Parameters.Add("@QuoteID", SqlDbType.VarChar, 8000).Value = mhquoteID
        Dim ds As Data.DataSet = New Data.DataSet

        cmd.Connection.Open()
        ' intRowsAff = cmd.ExecuteNonQuery()

        Dim myCommand = New SqlDataAdapter(cmd)
        myCommand.Fill(ds, "tbl1")
        If ds.Tables("tbl1").Rows.Count > 0 Then


            amslic_dwell.Text = ds.Tables("tbl1").Rows(0).Item("PackDwel").ToString
            amslic_unattStr.Text = ds.Tables("tbl1").Rows(0).Item("PackStruc").ToString
            amslic_perEff.Text = ds.Tables("tbl1").Rows(0).Item("PackCont").ToString
            amslic_perLiab.Text = ds.Tables("tbl1").Rows(0).Item("PackLiab").ToString
            amslic_medpay.Text = ds.Tables("tbl1").Rows(0).Item("PackMedPay").ToString
            amslic_baseprem.Text = "$" & ds.Tables("tbl1").Rows(0).Item("PackBasePrem").ToString.Replace("$", "")
            dd_aop_amslic.SelectedValue = ds.Tables("tbl1").Rows(0).Item("PackAOP").ToString
            dd_hurded_amslic.Text = ds.Tables("tbl1").Rows(0).Item("PackWind").ToString
            dd_pl_amslic.SelectedValue = ds.Tables("tbl1").Rows(0).Item("PackPerLiab").ToString
            'dd_mhr_amslic.SelectedValue = ds.Tables("tbl1").Rows(0).Item("PackMHReplace").ToString
            dd_rep_amslic.SelectedValue = ds.Tables("tbl1").Rows(0).Item("PackContReplace").ToString
            dd_sip_amslic2.SelectedValue = ds.Tables("tbl1").Rows(0).Item("PackFullRepair").ToString
            dd_aop_amslic_Amount.Text = ds.Tables("tbl1").Rows(0).Item("PackAOPPrem").ToString
            dd_pl_amslic_Amount.Text = ds.Tables("tbl1").Rows(0).Item("PackPersLiabPrem").ToString
            dd_med_amslic_amt.Text = ds.Tables("tbl1").Rows(0).Item("PackMedPrem").ToString
            txt_unattstr_amslic_Amount.Text = ds.Tables("tbl1").Rows(0).Item("PackStrucPrem").ToString
            txt_pp_amslic_Amount.Text = ds.Tables("tbl1").Rows(0).Item("PackContPrem").ToString
            'dd_mhr_amslic_Amount.Text = ds.Tables("tbl1").Rows(0).Item("PackMHReplacePrem").ToString
            dd_rep_amslic_Amount.Text = ds.Tables("tbl1").Rows(0).Item("PackContReplacePrem").ToString
            dd_sip_amslic2_Amount.Text = ds.Tables("tbl1").Rows(0).Item("PackFullRepairPrem").ToString
            If IsNumeric(ds.Tables("tbl1").Rows(0).Item("PackTax").ToString.Replace("$", "")) Then
                amslic_tax.Text = "$" & CDbl(ds.Tables("tbl1").Rows(0).Item("PackTax").ToString.Replace("$", ""))
            End If

            amslic_fees.Text = ds.Tables("tbl1").Rows(0).Item("PackFees").ToString
            amslic_total.Text = ds.Tables("tbl1").Rows(0).Item("Packtotal").ToString

            amslic_dwell3.Text = ds.Tables("tbl1").Rows(0).Item("RentDwel").ToString
            amslic_unattStrRent.Text = ds.Tables("tbl1").Rows(0).Item("RentStruc").ToString
            amslic_perEffRent.Text = ds.Tables("tbl1").Rows(0).Item("RentCont").ToString
            amslic_perLiabRent.Text = ds.Tables("tbl1").Rows(0).Item("RentLiab").ToString
            amslic_medpayRent.Text = ds.Tables("tbl1").Rows(0).Item("RentMedPay").ToString
            amslic_basepremRent.Text = "$" & ds.Tables("tbl1").Rows(0).Item("RentBasePrem").ToString.Replace("$", "")
            If ds.Tables("tbl1").Rows(0).Item("RentAOP").ToString = "" Then
                dd_aop_amslicRent.SelectedValue = "$500"
            Else
                dd_aop_amslicRent.SelectedValue = ds.Tables("tbl1").Rows(0).Item("RentAOP").ToString
            End If
            ' dd_aop_AR3.SelectedValue = ds.Tables("tbl1").Rows(0).Item("RentAOP").ToString
            'dd_hurded_aiges2.Text = ds.Tables("tbl1").Rows(0).Item("RentWind").ToString
            If ds.Tables("tbl1").Rows(0).Item("RentPerLiab").ToString = "" Then

            Else
                dd_pl_amslicRent.SelectedValue = ds.Tables("tbl1").Rows(0).Item("RentPerLiab").ToString

            End If

            'dd_mhr_aiges2.SelectedValue = ds.Tables("tbl1").Rows(0).Item("RentMHReplace").ToString
            'dd_rep_aiges2.SelectedValue = ds.Tables("tbl1").Rows(0).Item("RentContReplace").ToString
            'dd_sip_aiges2.SelectedValue = ds.Tables("tbl1").Rows(0).Item("RentFullRepair").ToString
            dd_aop_amslicRent_Amount.Text = ds.Tables("tbl1").Rows(0).Item("RentAOPPrem").ToString
            dd_pl_amslicRent_Amount.Text = ds.Tables("tbl1").Rows(0).Item("RentPersLiabPrem").ToString
            dd_med_amslicRent_amt.Text = ds.Tables("tbl1").Rows(0).Item("RentMedPrem").ToString
            'txt_unattstr_amslicRent_Amount.Text = ds.Tables("tbl1").Rows(0).Item("RentStrucPrem").ToString
            'txt_pp_aiges2_Amount.Text = ds.Tables("tbl1").Rows(0).Item("RentContPrem").ToString
            'dd_rep_aiges2_Amount.Text = ds.Tables("tbl1").Rows(0).Item("RentMHReplacePrem").ToString
            'dd_rep_aiges2_Amount.Text = ds.Tables("tbl1").Rows(0).Item("RentContReplacePrem").ToString
            'dd_sip_aiges2_Amount.Text = ds.Tables("tbl1").Rows(0).Item("RentFullRepairPrem").ToString
            If IsNumeric(ds.Tables("tbl1").Rows(0).Item("RentTax").ToString.Replace("$", "")) Then
                amslic_taxRent.Text = CDbl(ds.Tables("tbl1").Rows(0).Item("RentTax").ToString.Replace("$", ""))
            End If

            amslic_feesRent.Text = ds.Tables("tbl1").Rows(0).Item("RentFees").ToString
            amslic_totalRent.Text = ds.Tables("tbl1").Rows(0).Item("Renttotal").ToString

            Amslic_Calc()





        End If
    End Sub

    Protected Sub Amslic_save(ByVal quoteID As String)

        If quoteID <> "" Then
            quoteIDlbl.Text = quoteID
            Dim value As String = ""
            Dim Connection As String = System.Configuration.ConfigurationManager.ConnectionStrings("ColonialMHConnectionString").ConnectionString
            Dim dbConnection As System.Data.IDbConnection = New System.Data.SqlClient.SqlConnection(Connection)
            Dim cmd As New SqlCommand("sp_AmslicQuoteSave", dbConnection)
            cmd.CommandType = CommandType.StoredProcedure
            cmd.Parameters.Add("@QuoteID", SqlDbType.VarChar, 8000).Value = quoteID
            cmd.Parameters.Add("@PackDwel", SqlDbType.VarChar, 8000).Value = amslic_dwell.Text
            cmd.Parameters.Add("@PackStruc", SqlDbType.VarChar, 8000).Value = amslic_unattStr.Text
            cmd.Parameters.Add("@PackCont", SqlDbType.VarChar, 8000).Value = amslic_perEff.Text
            cmd.Parameters.Add("@PackLiab", SqlDbType.VarChar, 8000).Value = amslic_perLiab.Text
            cmd.Parameters.Add("@PackMedPay", SqlDbType.VarChar, 8000).Value = amslic_medpay.Text
            cmd.Parameters.Add("@PackBasePrem", SqlDbType.VarChar, 8000).Value = amslic_baseprem.Text
            cmd.Parameters.Add("@PackAOP", SqlDbType.VarChar, 8000).Value = dd_aop_amslic.SelectedValue()
            cmd.Parameters.Add("@PackWind", SqlDbType.VarChar, 8000).Value = dd_hurded_amslic.Text
            cmd.Parameters.Add("@PackPerLiab", SqlDbType.VarChar, 8000).Value = dd_pl_amslic.SelectedValue()
            cmd.Parameters.Add("@PackMHReplace", SqlDbType.VarChar, 8000).Value = "" ' dd_mhr_amslic.SelectedValue()
            cmd.Parameters.Add("@PackContReplace", SqlDbType.VarChar, 8000).Value = dd_rep_amslic.SelectedValue()
            cmd.Parameters.Add("@PackFullRepair", SqlDbType.VarChar, 8000).Value = dd_sip_amslic2.SelectedValue()
            cmd.Parameters.Add("@PackAOPPrem", SqlDbType.VarChar, 8000).Value = dd_aop_amslic_Amount.Text
            cmd.Parameters.Add("@PackPersLiabPrem", SqlDbType.VarChar, 8000).Value = dd_pl_amslic_Amount.Text
            cmd.Parameters.Add("@PackMedPrem", SqlDbType.VarChar, 8000).Value = dd_med_amslic_amt.Text
            cmd.Parameters.Add("@PackStrucPrem", SqlDbType.VarChar, 8000).Value = txt_unattstr_amslic_Amount.Text
            cmd.Parameters.Add("@PackContPrem", SqlDbType.VarChar, 8000).Value = txt_pp_amslic_Amount.Text
            cmd.Parameters.Add("@PackMHReplacePrem", SqlDbType.VarChar, 8000).Value = "" 'dd_mhr_amslic_Amount.Text
            cmd.Parameters.Add("@PackContReplacePrem", SqlDbType.VarChar, 8000).Value = dd_rep_amslic_Amount.Text
            cmd.Parameters.Add("@PackFullRepairPrem", SqlDbType.VarChar, 8000).Value = dd_sip_amslic2_Amount.Text
            cmd.Parameters.Add("@PackTax", SqlDbType.VarChar, 8000).Value = amslic_tax.Text
            cmd.Parameters.Add("@PackFees", SqlDbType.VarChar, 8000).Value = amslic_fees.Text
            cmd.Parameters.Add("@Packtotal", SqlDbType.VarChar, 8000).Value = amslic_total.Text

            cmd.Parameters.Add("@RentDwel", SqlDbType.VarChar, 8000).Value = amslic_dwell3.Text
            cmd.Parameters.Add("@RentStruc", SqlDbType.VarChar, 8000).Value = amslic_unattStrRent.Text
            cmd.Parameters.Add("@RentCont", SqlDbType.VarChar, 8000).Value = amslic_perEffRent.Text
            cmd.Parameters.Add("@RentLiab", SqlDbType.VarChar, 8000).Value = amslic_perLiabRent.Text
            cmd.Parameters.Add("@RentMedPay", SqlDbType.VarChar, 8000).Value = amslic_medpayRent.Text
            cmd.Parameters.Add("@RentBasePrem", SqlDbType.VarChar, 8000).Value = amslic_basepremRent.Text
            cmd.Parameters.Add("@RentAOP", SqlDbType.VarChar, 8000).Value = dd_aop_amslicRent.SelectedValue()
            cmd.Parameters.Add("@RentWind", SqlDbType.VarChar, 8000).Value = dd_thur_amslicRent.Text 'dd_hurded_aiges2.Text
            cmd.Parameters.Add("@RentPerLiab", SqlDbType.VarChar, 8000).Value = dd_pl_amslicRent.SelectedValue()
            cmd.Parameters.Add("@RentMHReplace", SqlDbType.VarChar, 8000).Value = "" 'dd_mhr_aiges2.SelectedValue()
            cmd.Parameters.Add("@RentContReplace", SqlDbType.VarChar, 8000).Value = "" ' dd_rep_aiges2.SelectedValue()
            cmd.Parameters.Add("@RentFullRepair", SqlDbType.VarChar, 8000).Value = "" 'dd_sip_amslicRent.SelectedItem.Text '"" 'dd_sip_aiges2.SelectedValue()
            cmd.Parameters.Add("@RentAOPPrem", SqlDbType.VarChar, 8000).Value = dd_aop_amslicRent_Amount.Text
            cmd.Parameters.Add("@RentPersLiabPrem", SqlDbType.VarChar, 8000).Value = dd_pl_amslicRent_Amount.Text
            cmd.Parameters.Add("@RentMedPrem", SqlDbType.VarChar, 8000).Value = dd_med_amslicRent_amt.Text
            cmd.Parameters.Add("@RentStrucPrem", SqlDbType.VarChar, 8000).Value = "" 'txt_unattstr_amslicRent_Amount.Text
            cmd.Parameters.Add("@RentContPrem", SqlDbType.VarChar, 8000).Value = "" 'txt_pp_aiges2_Amount.Text
            cmd.Parameters.Add("@RentMHReplacePrem", SqlDbType.VarChar, 8000).Value = "" 'dd_mhr_aiges2_Amount.Text
            cmd.Parameters.Add("@RentContReplacePrem", SqlDbType.VarChar, 8000).Value = "" 'dd_rep_aiges2_Amount.Text
            cmd.Parameters.Add("@RentFullRepairPrem", SqlDbType.VarChar, 8000).Value = "" 'dd_sip_amslicRent_Amount.Text '"" 'dd_sip_aiges2_Amount.Text
            cmd.Parameters.Add("@RentTax", SqlDbType.VarChar, 8000).Value = amslic_taxRent.Text
            cmd.Parameters.Add("@RentFees", SqlDbType.VarChar, 8000).Value = amslic_feesRent.Text
            cmd.Parameters.Add("@Renttotal", SqlDbType.VarChar, 8000).Value = amslic_totalRent.Text

            cmd.Parameters.Add("@PackCreditPerc", SqlDbType.VarChar, 8000).Value = "0" 'aegispackperclbl.Text
            cmd.Parameters.Add("@PackCreditamt", SqlDbType.VarChar, 8000).Value = "0" 'aegispackcramtlbl.Text
            cmd.Parameters.Add("@RentCreditPerc", SqlDbType.VarChar, 8000).Value = "0" 'aegisrentperclbl.Text
            cmd.Parameters.Add("@RentCreditamt", SqlDbType.VarChar, 8000).Value = "0" 'aegisrentcramtlbl.Text
            cmd.Parameters.Add("@Packprem", SqlDbType.VarChar, 8000).Value = Amslicpackpremlbl.Text
            cmd.Parameters.Add("@Rentprem", SqlDbType.VarChar, 8000).Value = Amslicrentpremlbl.Text

            cmd.Parameters.Add("@PackPPLimit", SqlDbType.VarChar, 8000).Value = "0" 'packagePerPropValue.Text
            cmd.Parameters.Add("@PackPPPrem", SqlDbType.VarChar, 8000).Value = "0" 'dd_PackagePerProp_AR1_Amount.Text
            cmd.Parameters.Add("@PackSatPrem", SqlDbType.VarChar, 8000).Value = "0" 'aegissatprem.Text
            Try
                Dim ds As Data.DataSet = New Data.DataSet

                cmd.Connection.Open()
                ' intRowsAff = cmd.ExecuteNonQuery()

                Dim myCommand = New SqlDataAdapter(cmd)
                myCommand.Fill(ds, "tbl1")
            Catch ex As Exception
                Dim s As String = ""
                For Each param As SqlParameter In cmd.Parameters
                    s += param.ParameterName & "="
                    s += param.Value & ":  "

                Next
                errortrap("Saving Amslic Data " & s, "Save Prem", ex.Message)
            End Try
        End If

    End Sub

    Protected Sub amslic_premiumbtnClick(sender As Object, e As EventArgs) Handles amslic_updateOptions.Click
        Amslic_Calc()
    End Sub

    Protected Sub amslic_premiumbtnClickRent(sender As Object, e As EventArgs) Handles amslicRent_updateOptions.Click
        Amslic_Calc()
    End Sub
    Public Sub WMJStandCalc(ByVal ds As DataSet)

        Dim smhprem As String
        Dim smhas As String
        Dim smhcon As String
        Dim WMJopt As String

        Dim smhtotal As Decimal




        'if first run or now value, then fill in fields
        If IsNumeric(txt_unattstr_WMJ1.Text) And txt_unattstr_WMJ1.Text <> "0.00" Then
            If CInt(txt_unattstr_wmj1.Text) > CInt(MHValuelbl.Text * 0.1) Then
                'txt_unattstr_wmj1_Amount.Text = ds.Tables("tbl1").Rows(0).Item("Astructurerate").ToString().Replace("$", "") * (txt_unattstr_wmj1.Text / 100)
                txt_unattstr_wmj1_Amount.Text = ds.Tables("tbl1").Rows(0).Item("OtherStruc").ToString().Replace("$", "") '* (txt_unattstr_wmj1.Text / 100)
            Else
                txt_unattstr_wmj1_Amount.Text = "0.00"
            End If

        End If
            If IsNumeric(txt_pp_wmj1.Text) And txt_pp_wmj1.Text <> "0.00" Then
            If CInt(txt_pp_wmj1.Text) > CInt(MHValuelbl.Text * 0.5) Then
                txt_pp_wmj1_Amount.Text = CInt(ds.Tables("tbl1").Rows(0).Item("Contents").ToString().Replace("$", "")) ' * (txt_pp_wmj1.Text / 100)
                ' txt_pp_wmj1_Amount.Text = ds.Tables("tbl1").Rows(0).Item("PProperty").ToString().Replace("$", "") * (txt_pp_wmj1.Text / 100)
            Else
                txt_pp_wmj1_Amount.Text = "0.00"
            End If

        End If
            wmj_medpay2.Text = dd_mp_wmj1.SelectedValue()
        wmj_perEff2.Text = "$" & txt_pp_wmj1.Text.Replace("$", "")
        wmjlossofuse.Text = CInt(MHValuelbl.Text * 0.2)


            'If dd_pl_WMJ1.SelectedValue() = "$0" Then



            '    dd_pl_WMJ1.SelectedValue() = "$" & CInt(ds.Tables("tbl1").Rows(0).Item("LiabilityLimit").ToString().Replace("$", "")).ToString("N0")

            'End If

            'If ds.Tables("tbl1").Rows(0).Item("territory").ToString() = "5" Then
            '    WMJWind.Visible = True
            'Else
            '    WMJWind.Visible = False

            'End If
            'If ds.Tables("tbl1").Rows(0).Item("territory").ToString() = "6" Then
            '    WMJWind.Visible = True
            'Else
            '    WMJWind.Visible = False

            'End If


            wmj_Debug.Text = "<table> <tbody>"
            wmj_dwell2.Text = "$" & mhvalue.Replace("$", "")
            wmj_unattStr2.Text = "$" & txt_unattstr_wmj1.Text.Replace("$", "")
            wmj_perEff2.Text = "$" & txt_pp_wmj1.Text.Replace("$", "")
            wmj_perLiab2.Text = "$" & dd_pl_wmj1.SelectedValue().Replace("$", "")
            wmj_medpay2.Text = "$" & wmj_medpay2.Text.Replace("$", "")


            smhprem = "$" & ds.Tables("tbl1").Rows(0).Item("Prem").ToString().Replace("$", "")

            'If ds.Tables("tbl1").Rows(0).Item("territory").ToString().Replace("$", "") = "5" Or ds.Tables("tbl1").Rows(0).Item("territory").ToString().Replace("$", "") = "6" Then
            '    WMJWind.Style.Add("display", "block")
            '    dd_hurded_WMJ1.Text = "1500"
            'Else
            '    WMJWind.Style.Remove("display")

            'End If
            'If dd_aop_08.Text = "2500" Then
            '    dd_hurded_08.Text = "$2500"
            'Else
            '    dd_hurded_08.Text = "$1250"
            'End If

            'txtlossofuse08.Text = "$1000"



            wmj_Debug.Text += "<tr align=left><td>Package Premium </td><td> $" & CInt(smhprem) & " </td></tr> "
            WMJpackpremlbl.Text = CInt(smhprem)
        If CInt(txt_unattstr_wmj1.Text) > CInt(MHValuelbl.Text * 0.1) Then
            wmj_Debug.Text += "<tr align=left><td>Other Structures </td><td> $" & CInt(txt_unattstr_wmj1.Text = ds.Tables("tbl1").Rows(0).Item("Astructurerate").ToString().Replace("$", "") * (txt_unattstr_wmj1.Text / 100)) & " </td></tr> "
            '' txt_unattstr_wmj1_Amount.Text = CInt(ds.Tables("tbl1").Rows(0).Item("OtherStructure").ToString().Replace("$", ""))
            WMJopt += CInt(txt_unattstr_wmj1.Text = ds.Tables("tbl1").Rows(0).Item("Astructurerate").ToString().Replace("$", "") * (txt_unattstr_wmj1.Text / 100))
            wmj_unattStr2.Text = "$" & txt_unattstr_wmj1.Text.Replace("$", "")
        Else
            wmj_Debug.Text += "<tr align=left><td>Other Structures </td><td> $0.00 </td></tr> "
            '' txt_unattstr_wmj1_Amount.Text = CInt(ds.Tables("tbl1").Rows(0).Item("OtherStructure").ToString().Replace("$", ""))
            wmj_unattStr2.Text = "$" & txt_unattstr_wmj1.Text.Replace("$", "")
            WMJopt += 0
        End If

        If CInt(txt_pp_wmj1.Text) > CInt(MHValuelbl.Text * 0.5) Then
            'wmj_Debug.Text += "<tr align=left><td>Contents </td><td> $" & CInt(ds.Tables("tbl1").Rows(0).Item("PProperty").ToString().Replace("$", "") * (txt_pp_wmj1.Text / 100)) & " </td></tr> "
            wmj_Debug.Text += "<tr align=left><td>Contents </td><td> $" & CInt(ds.Tables("tbl1").Rows(0).Item("Contents").ToString().Replace("$", "")) & " </td></tr> "

            WMJopt += CInt(ds.Tables("tbl1").Rows(0).Item("Contents").ToString().Replace("$", "")) '* (txt_pp_wmj1.Text / 100))
            wmj_perEff2.Text = "$" & txt_pp_wmj1.Text.Replace("$", "")
        Else
            wmj_Debug.Text += "<tr align=left><td>Contents </td><td> $0.00 </td></tr> "
            wmj_perEff2.Text = "$" & txt_pp_wmj1.Text.Replace("$", "")
            WMJopt += 0
        End If
            'wmj_Debug.Text += "<tr align=left><td>Other Structures </td><td> $" & CInt(txt_unattstr_wmj1.Text = ds.Tables("tbl1").Rows(0).Item("Astructurerate").ToString().Replace("$", "") * (txt_unattstr_wmj1.Text / 100)) & " </td></tr> "
            ' '' txt_unattstr_wmj1_Amount.Text = CInt(ds.Tables("tbl1").Rows(0).Item("OtherStructure").ToString().Replace("$", ""))
            'WMJopt += CInt(txt_unattstr_wmj1.Text = ds.Tables("tbl1").Rows(0).Item("Astructurerate").ToString().Replace("$", "") * (txt_unattstr_wmj1.Text / 100))
        'wmj_Debug.Text += "<tr align=left><td>Contents </td><td> $" & CInt(ds.Tables("tbl1").Rows(0).Item("PProperty").ToString().Replace("$", "") * (txt_pp_wmj1.Text / 100)) & " </td></tr> "
        ''txt_pp_WMJ2_Amount.Text = CInt(ds.Tables("tbl1").Rows(0).Item("Contents").ToString().Replace("$", ""))
        'WMJopt += CInt(ds.Tables("tbl1").Rows(0).Item("PProperty").ToString().Replace("$", "") * (txt_pp_wmj1.Text / 100))
        'wmj_Debug.Text += "<tr align=left><td>Addl Living Expense</td><td> $" & CInt("0") & " </td></tr> "
            'txt_unattstr_WMJ1_Amount.Text = Math.Ceiling(CDbl(ds.Tables("tbl1").Rows(0).Item("OtherStructure").ToString().Replace("$", "")))
            'txt_pp_WMJ1_Amount.Text = Math.Ceiling(CDbl(ds.Tables("tbl1").Rows(0).Item("Contents").ToString().Replace("$", "")))


        ' smhtotal = CInt(smhprem) + Math.Ceiling(CDbl(ds.Tables("tbl1").Rows(0).Item("Astructurerate").ToString().Replace("$", "") * (txt_unattstr_wmj1.Text / 100))) + Math.Ceiling(CDbl(ds.Tables("tbl1").Rows(0).Item("PProperty").ToString().Replace("$", "") * (txt_pp_wmj1.Text / 100)))
        smhtotal = CInt(smhprem) + CInt(txt_unattstr_wmj1_Amount.Text) + CInt(txt_pp_wmj1_Amount.Text)
        If dd_smoke_wmj1.SelectedValue = "Yes" Then

            wmj_Debug.Text += "<tr align=left><td>Smoke Detector Credit: </td><td>($" & CInt(CInt(smhprem) * 0.02) & " ) </td></tr> "
            WMJopt -= CInt(CInt(smhprem) * 0.02)
            dd_smoke_wmj1_amount.Text = "(" & CInt(CInt(smhprem) * 0.02) & ")"
            lblsmokecreditwmj.Text = CInt(CInt(smhprem) * 0.02)
            smhtotal -= CInt(CInt(smhprem) * 0.02)
            lblsmokeprecwmj.Text = ".02"
        Else
            lblsmokecreditwmj.Text = ""
            lblsmokeprecwmj.Text = ""
            dd_smoke_wmj1_amount.Text = "$0.00"
        End If
        wmj_Debug.Text += "<tr align=left><td>Sub Premium</td><td> $" & CInt(smhtotal) & " </td></tr> "
            'Dim CreditsPercentage As Decimal
            ''Add credit stuff to label
            'CreditsPercentage = ds.Tables("tbl1").Rows(0).Item("Credit").ToString().Replace("$", "")
            'WMJ_Debug.Text += "<tr align=left><td> Credits %</td><td> " & CreditsPercentage * 100 & "% </td></tr> "
            'WMJ_Debug.Text += "<tr align=left><td> Credits Value</td><td>-" & Math.Round((smhtotal * CreditsPercentage), 0, MidpointRounding.AwayFromZero) & " </td></tr> "
            'smhtotal -= Math.Round((smhtotal * CreditsPercentage), 0, MidpointRounding.AwayFromZero)
        ' wmj_baseprem2.Text = "$" & CInt(smhtotal)
        wmj_baseprem2.Text = "$" & CInt(smhprem)
            wmj_Debug.Text += "<tr align=left><td>Base Premium</td><td> $" & CInt(smhtotal) & " </td></tr> "
            'WMJpackpremlbl.Text = CInt(smhtotal)
            If dd_pl_wmj1.SelectedItem.Text = "$50,000" Then
                wmj_Debug.Text += "<tr align=left><td>Personal Liability</td><td> $0.00  </td></tr> "
                dd_pl_wmj1_Amount.Text = CInt("0.00")

            ElseIf dd_pl_wmj1.SelectedItem.Text = "$100,000" Then
            wmj_Debug.Text += "<tr align=left><td>Personal Liability</td><td> $11.00  </td></tr> "
            dd_pl_wmj1_Amount.Text = CInt("11.00")
            smhtotal += CInt("11.00")
            ElseIf dd_pl_wmj1.SelectedItem.Text = "$300,000" Then
            wmj_Debug.Text += "<tr align=left><td>Personal Liability</td><td> $32.00  </td></tr> "
            dd_pl_wmj1_Amount.Text = CInt("32.00")
            smhtotal += CInt("32.00")
            End If

       
            wmj_Debug.Text += "<tr align=left><td>Medical Payment</td><td> $ 0  </td></tr> "
            WMJpackperclbl.Text = "0"
            WMJpackcramtlbl.Text = "0"
            Dim WMJcredit As Decimal

            wmj_Debug.Text += "<tr align=left><td>SUB TOTAL 2</td><td> $" & CInt(smhtotal) & " </td></tr> "
        If dd_aop_wmj1.SelectedValue = "$500" Then
            wmj_Debug.Text += "<tr align=left><td>AOP</td><td> $0 </td></tr> "
            dd_aop_wmj1_Amount.Text = "0.00"
            'dd_aop_08_Amount.Text = ds.Tables("tbl1").Rows(0).Item("AOP").ToString().Replace("$", "")
            ' smhtotal += CInt(ds.Tables("tbl1").Rows(0).Item("AOP").ToString().Replace("$", ""))
        Else
            wmj_Debug.Text += "<tr align=left><td>AOP</td><td> ( $" & CInt(smhtotal * 0.07) & " )</td></tr> "
            'dd_aop_08_Amount.Text = ds.Tables("tbl1").Rows(0).Item("AOP").ToString().Replace("$", "")
            dd_aop_wmj1_Amount.Text = "(" & Math.Round((smhprem * 0.07), 0, MidpointRounding.AwayFromZero) & ")"
            smhtotal -= CInt(dd_aop_wmj1_Amount.Text.Replace("(", "").Replace(")", "")) 'CInt(smhtotal * 0.07)
            WMJopt -= CInt(dd_aop_wmj1_Amount.Text.Replace("(", "").Replace(")", "")) 'CInt(smhtotal * 0.07)
            WMJcredit += CInt(dd_aop_wmj1_Amount.Text.Replace("(", "").Replace(")", "")) 'CInt(smhtotal * 0.07)
        End If


            wmj_Debug.Text += "<tr align=left><td>SUB TOTAL 3</td><td> $" & CInt(smhtotal) & " </td></tr> "
            If dd_rep_wmj1.SelectedValue = "Yes" Then
                Dim contrep As String
            ' contrep = CInt((CInt(txt_pp_wmj1.Text) / 100) * 0.25)
            contrep = Math.Ceiling(smhtotal * 0.05)
            If contrep < 25 Then
                contrep = 25
            End If
                wmj_Debug.Text += "<tr align=left><td>Contents Replacement</td><td> $" & contrep & " </td></tr> "
                dd_rep_wmj1_Amount.Text = CInt(contrep)
                WMJopt += CInt(contrep)
                smhtotal += CInt(contrep)
            End If
            Dim age As Integer = 0
            If IsNumeric(mhyearlbl.Text) Then
                age = Now.Year - CInt(mhyearlbl.Text)
            End If
        '    If age > 15 Then
        '        dd_sip_wmj1.Enabled = False
        '        dd_sip_wmj1.SelectedValue = "No"
        '    Else
        '        dd_sip_wmj1.Enabled = True

        '    End If
        '    If dd_sip_wmj1.SelectedValue = "Yes" Then
        '        If age < 16 Then
        '            wmj_Debug.Text += "<tr align=left><td>Full Repair</td><td> $10 </td></tr> "
        '            WMJopt += 10
        '            smhtotal += 10
        '            dd_sip_wmj1_Amount.Text = "10"
        '        Else
        '            dd_sip_wmj1_Amount.Text = "0.00"
        '        End If


        'End If
        If spi_cbo.SelectedValue = "Yes" Then
            wmj_Debug.Text += "<tr align=left><td>Secured Party's Interest</td><td> $10 </td></tr> "
            WMJopt += 10
            smhtotal += 10
            spi_amount.Text = "10"
        Else
            spi_amount.Text = "0.00"

        End If
            wmj_Debug.Text += "<tr align=left><td>Scheduled Personal Property:</td><td> $" & dd_PackagePerProp_AR1_Amount.Text & " </td></tr> "
            smhtotal += CDec(dd_PackagePerProp_AR1_Amount.Text)
            WMJopt += CDec(dd_PackagePerProp_AR1_Amount.Text)
            'WMJ_fees2.Text = "$" & CInt(ds.Tables("tbl1").Rows(0).Item("Fee").ToString())
            'WMJ_Debug.Text += "<tr align=left><td>Policy Fee</td><td> $" & CInt(ds.Tables("tbl1").Rows(0).Item("Fee").ToString()) & " </td></tr> "
            'smhtotal += CInt(ds.Tables("tbl1").Rows(0).Item("Fee").ToString())


        If dd_addresOpt_ar1.SelectedValue = "1 Family" Then
            If dd_addresliab_wmj.SelectedValue = "$50,000" Then
                addres_liab_amount.Text = "6"
                WMJopt += 6
                smhtotal += 6
                wmj_Debug.Text += "<tr align=left><td>Additional Residence Premises Liability</td><td> $6.00  </td></tr> "
            End If
            If dd_addresliab_wmj.SelectedValue = "$100,000" Then
                addres_liab_amount.Text = "11"
                WMJopt += 11
                smhtotal += 11
                wmj_Debug.Text += "<tr align=left><td>Additional Residence Premises Liability</td><td> $11.00  </td></tr> "
            End If
            If dd_addresliab_wmj.SelectedValue = "$300,000" Then
                addres_liab_amount.Text = "33"
                WMJopt += 33
                smhtotal += 33
                wmj_Debug.Text += "<tr align=left><td>Additional Residence Premises Liability</td><td> $33.00  </td></tr> "
            End If

        End If
        If dd_addresOpt_ar1.SelectedValue = "2 Family" Then
            If dd_addresliab_wmj.SelectedValue = "$50,000" Then
                addres_liab_amount.Text = "11"
                WMJopt += 11
                smhtotal += 11
                wmj_Debug.Text += "<tr align=left><td>Additional Residence Premises Liability</td><td> $11.00  </td></tr> "
            End If
            If dd_addresliab_wmj.SelectedValue = "$100,000" Then
                addres_liab_amount.Text = "22"
                WMJopt += 22
                smhtotal += 22
                wmj_Debug.Text += "<tr align=left><td>Additional Residence Premises Liability</td><td> $22.00  </td></tr> "
            End If
            If dd_addresliab_wmj.SelectedValue = "$300,000" Then
                addres_liab_amount.Text = "66"
                WMJopt += 66
                smhtotal += 66
                wmj_Debug.Text += "<tr align=left><td>Additional Residence Premises Liability</td><td> $66.00  </td></tr> "
            End If

        End If


            wmj_Debug.Text += "<tr align=left><td>SUB TOTAL 4</td><td> $" & smhtotal & " </td></tr> "
            wmj_total2.Text = smhtotal.ToString("C2")



        'If lienlbl.Text = "No" Then
        '    wmj_Debug.Text += "<tr align=left><td>No Lien</td><td> ($15) </td></tr> "
        '    WMJpackcramtlbl.Text = "($15)"
        '    smhtotal -= 15
        'End If
            wmj_Debug.Text += "<tr align=left><td>SUB TOTAL 5</td><td> $" & smhtotal & " </td></tr> "
            ' '' ''If DropDownList1.SelectedValue() = "Yes" Then
            ' '' ''    WMJsatprem.Text = "5"
            ' '' ''    WMJopt += 5
            ' '' ''Else
            ' '' ''    WMJsatprem.Text = "0.00"
            ' '' ''End If
        'If IsNumeric(txt_Sat_value.Text) Then
        '    If CInt(txt_Sat_value.Text) > 0 Then
        '        Dim sat As Integer
        '        sat = (CInt(txt_Sat_value.Text) / 100) * 5
        '        If sat < 5 Then
        '            sat = 5

        '        End If
        '        wmj_Debug.Text += "<tr align=left><td>Antenna/ Satalite Dish:</td><td> $" & sat & " </td></tr> "
        '        wmjsatprem.Text = sat
        '        WMJopt += sat
        '        smhtotal += sat
        '    End If

        'End If
            wmj_fees2.Text = "$0"
        'If supheatlbl.Text = "Yes" Then
        '    If (smhtotal * 0.1) < 30 Then
        '        wmj_Debug.Text += "<tr align=left><td>Supplemental Heating</td><td> $30 </td></tr> "
        '        smhtotal += 30
        '        wmj_fees2.Text = "$30"
        '    Else
        '        wmj_Debug.Text += "<tr align=left><td>Supplemental Heating</td><td> $" & CInt(smhtotal * 0.1) & "</td></tr> "
        '        wmj_fees2.Text = "$" & CInt(smhtotal * 0.1)
        '        smhtotal += CInt(smhtotal * 0.1)

        '    End If
        'End If
            wmj_options2.Text = "$" & WMJopt
            wmj_Debug.Text += "<tr align=left><td>Total Prem</td><td> $" & CDbl(smhtotal) & " </td></tr> "
            'WMJ_options2.Text = CInt(ds.Tables("tbl1").Rows(0).Item("AOP").ToString().Replace("$", "")) + CInt(ds.Tables("tbl1").Rows(0).Item("Liab").ToString()) + CInt(ds.Tables("tbl1").Rows(0).Item("ContRep").ToString()) + CInt(ds.Tables("tbl1").Rows(0).Item("Enhance").ToString())
            'WMJ_total2.Text = String.Format("{0:C}", CInt(SC08_baseprem.Text) + CInt(SC08_options.Text) + CDbl(SC08_fees.Text) + CDbl(SC08_tax.Text))
            wmj_total2.Text = smhtotal.ToString("C2")
            wmj_Debug.Text += "</tbody></table>"
        'Dim showwmj As String
        'showwmj = ds.Tables("tbl1").Rows(0).Item("Prem").ToString().Replace("$", "")
        'If showwmj = "" Then
        '    wmj_mh_prog2.Visible = False
        '    wmj_mh_prog2_Options.Visible = False
        'End If


            AR_PremiumUpdatePanel.Update()


    End Sub
    Protected Sub WMJ_premiumbtnClick2(sender As Object, e As EventArgs) Handles wmj1_updateOptions.Click, wmj1_updateOptions.Click
        loadWMJPP()
        calcWMJ()

    End Sub

    Protected Sub selectwmj1btn_Click(sender As Object, e As EventArgs) Handles selectwmj_2btn.Click
        HiddenFieldSelected.Value = "WMJ Standard"
        rateTypelbl.Text = "WMJ Standard"
        rateTypelbl.Font.Bold = True
        rateTypelbl.ForeColor = Drawing.Color.Green


        'Set Selected to AR1 in database  Not saving right now...
        Try

            If quoteIDlbl.Text <> "" Then
                Me.Page.GetType.InvokeMember("updateQuote", System.Reflection.BindingFlags.InvokeMethod, Nothing, Me.Page, New Object() {quoteIDlbl.Text})
            Else
                Me.Page.GetType.InvokeMember("save", System.Reflection.BindingFlags.InvokeMethod, Nothing, Me.Page, New Object() {})

            End If
        Catch ex As Exception
            errortrap("UPDATE WMJ Standard", "SELECTED WMJ Standard", ex.Message)
        End Try
        Dim ds As System.Data.DataSet
        ds = runQueryDS("EXEC sp_SetQuoteRateType '" & quoteIDlbl.Text & "', 'WMJ Standard'", "ColonialMHConnectionString")
        'Check Financing options
        ds = runQueryDS("SELECT ARRateType, state  FROM tblQuotes WHERE quoteID ='" & quoteIDlbl.Text & "'", "ColonialMHConnectionString")
        'If ds.Tables(0).Rows.Count > 0 Then
        '    If ds.Tables(0).Rows(0).Item("state") = "SC" And Not rateTypelbl.Text.ToString.ToUpper.Contains("AEG") Then
        '        SCPremFinbtn.Visible = True
        '        calcSCFinancing()
        '    Else
        '        SCPremFinbtn.Visible = False
        '    End If
        'End If
        premiumBtnTable.Attributes.Add("style", "display:block")
    End Sub

    Protected Sub btnAddPPLwmj_Click(sender As Object, e As EventArgs) Handles btnAddPPLwmj.Click
        If IsNumeric(txtvaluePPLwmj.Text) Then
            If CDbl(txtvaluePPLwmj.Text) > 2000.0 Then
                PPError.Visible = True
                PPError.Text = "Property Value cannot Exceed $2000"
                PPError.ForeColor = Drawing.Color.Red
            Else
                If CDbl(wmjppvalue.Text) + CDbl(txtvaluePPLwmj.Text) > 10000.0 Then
                    PPError.Visible = True
                    PPError.Text = "Property Total Value cannot Exceed $10,000"
                    PPError.ForeColor = Drawing.Color.Red
                Else
                    PPError.Visible = False

                    Dim Connection As String = System.Configuration.ConfigurationManager.ConnectionStrings("ColonialMHConnectionString").ConnectionString
                    Dim dbConnection As System.Data.IDbConnection = New System.Data.SqlClient.SqlConnection(Connection)
                    Dim cmd As New SqlCommand("sp_WMJPPInsert", dbConnection)
                    cmd.CommandType = CommandType.StoredProcedure
                    cmd.Parameters.Add("@Category", SqlDbType.VarChar, 8000).Value = wmjppcatcmbo.SelectedItem.ToString
                    cmd.Parameters.Add("@Description", SqlDbType.VarChar, 8000).Value = txtPPLDescriptionwmj.Text
                    cmd.Parameters.Add("@qty", SqlDbType.VarChar, 8000).Value = txtQuantityPPlwmj.Text
                    cmd.Parameters.Add("@value", SqlDbType.VarChar, 8000).Value = txtvaluePPLwmj.Text
                    cmd.Parameters.Add("@QuoteID", SqlDbType.VarChar, 8000).Value = quoteIDlbl.Text
                    cmd.Parameters.Add("@territory", SqlDbType.VarChar, 8000).Value = protection.Text



                    Try
                        Dim ds As Data.DataSet = New Data.DataSet

                        cmd.Connection.Open()
                        ' intRowsAff = cmd.ExecuteNonQuery()

                        Dim myCommand = New SqlDataAdapter(cmd)
                        myCommand.Fill(ds, "tbl1")
                        If ds.Tables("tbl1").Rows.Count > 0 Then
                            wmjppcatcmbo.Text = ""
                            txtPPLDescriptionwmj.Text = ""
                            txtQuantityPPlwmj.Text = ""
                            txtvaluePPLwmj.Text = ""
                            wmjPPGrid.DataSource = ds.Tables("tbl1")
                            wmjPPGrid.DataBind()
                            WMJPPtotals()

                        End If

                    Catch ex As Exception
                        Dim s As String = ""
                        For Each param As SqlParameter In cmd.Parameters
                            s += param.ParameterName & "="
                            s += param.Value & ":  "

                        Next
                        errortrap("Adding PPL for WMJ data " & s, "Calculation AddPPL", ex.Message)
                    End Try

                End If

            End If

        End If

    End Sub
    Public Sub SaveWMJ(ByVal quoteID As String)


            quoteIDlbl.Text = quoteID
            Dim value As String = ""
            Dim Connection As String = System.Configuration.ConfigurationManager.ConnectionStrings("ColonialMHConnectionString").ConnectionString
            Dim dbConnection As System.Data.IDbConnection = New System.Data.SqlClient.SqlConnection(Connection)
            Dim cmd As New SqlCommand("sp_wmjQuoteSave", dbConnection)
            cmd.CommandType = CommandType.StoredProcedure
        If rateTypelbl.Text = "WMJ Standard" Then


            cmd.Parameters.Add("@QuoteID", SqlDbType.VarChar, 8000).Value = quoteID
            cmd.Parameters.Add("@PackDwel", SqlDbType.VarChar, 8000).Value = wmj_dwell2.Text
            cmd.Parameters.Add("@PackStruc", SqlDbType.VarChar, 8000).Value = wmj_unattStr2.Text
            cmd.Parameters.Add("@PackCont", SqlDbType.VarChar, 8000).Value = wmj_perEff2.Text
            cmd.Parameters.Add("@PackLiab", SqlDbType.VarChar, 8000).Value = wmj_perLiab2.Text
            cmd.Parameters.Add("@PackMedPay", SqlDbType.VarChar, 8000).Value = wmj_medpay2.Text
            cmd.Parameters.Add("@PackBasePrem", SqlDbType.VarChar, 8000).Value = wmj_baseprem2.Text
            cmd.Parameters.Add("@PackAOP", SqlDbType.VarChar, 8000).Value = dd_aop_wmj1.SelectedValue()
            cmd.Parameters.Add("@PackWind", SqlDbType.VarChar, 8000).Value = "0.00" 'dd_hurded_wmj1.Text
            cmd.Parameters.Add("@PackPerLiab", SqlDbType.VarChar, 8000).Value = dd_pl_wmj1.SelectedValue()
            cmd.Parameters.Add("@PackMHReplace", SqlDbType.VarChar, 8000).Value = ""
            cmd.Parameters.Add("@PackContReplace", SqlDbType.VarChar, 8000).Value = dd_rep_wmj1.SelectedValue()
            cmd.Parameters.Add("@PackFullRepair", SqlDbType.VarChar, 8000).Value = "" 'dd_sip_wmj1.SelectedValue()
            cmd.Parameters.Add("@PackAOPPrem", SqlDbType.VarChar, 8000).Value = dd_aop_wmj1_Amount.Text
            cmd.Parameters.Add("@PackPersLiabPrem", SqlDbType.VarChar, 8000).Value = dd_pl_wmj1_Amount.Text
            cmd.Parameters.Add("@PackMedPrem", SqlDbType.VarChar, 8000).Value = dd_med_wmj1_amt.Text
            cmd.Parameters.Add("@PackStrucPrem", SqlDbType.VarChar, 8000).Value = txt_unattstr_wmj1_Amount.Text
            cmd.Parameters.Add("@PackContPrem", SqlDbType.VarChar, 8000).Value = txt_pp_wmj1_Amount.Text
            cmd.Parameters.Add("@PackMHReplacePrem", SqlDbType.VarChar, 8000).Value = "" 'dd_mhr_AR1_Amount.Text
            cmd.Parameters.Add("@PackContReplacePrem", SqlDbType.VarChar, 8000).Value = dd_rep_wmj1_Amount.Text
            cmd.Parameters.Add("@PackFullRepairPrem", SqlDbType.VarChar, 8000).Value = "" 'dd_sip_wmj1_Amount.Text
            cmd.Parameters.Add("@PackTax", SqlDbType.VarChar, 8000).Value = wmj_tax2.Text
            cmd.Parameters.Add("@PackFees", SqlDbType.VarChar, 8000).Value = wmj_fees2.Text
            cmd.Parameters.Add("@Packtotal", SqlDbType.VarChar, 8000).Value = wmj_total2.Text

            cmd.Parameters.Add("@PackCreditPerc", SqlDbType.VarChar, 8000).Value = WMJpackperclbl.Text
            cmd.Parameters.Add("@PackCreditamt", SqlDbType.VarChar, 8000).Value = WMJpackcramtlbl.Text
            cmd.Parameters.Add("@Packprem", SqlDbType.VarChar, 8000).Value = WMJpackpremlbl.Text


            cmd.Parameters.Add("@PackPPLimit", SqlDbType.VarChar, 8000).Value = packagePerPropValue.Text
            cmd.Parameters.Add("@PackPPPrem", SqlDbType.VarChar, 8000).Value = dd_PackagePerProp_AR1_Amount.Text
            cmd.Parameters.Add("@PackSPI", SqlDbType.VarChar, 8000).Value = spi_cbo.SelectedValue
            cmd.Parameters.Add("@PackSPIPrem", SqlDbType.VarChar, 8000).Value = spi_amount.Text


            cmd.Parameters.Add("@PackAddlRes", SqlDbType.VarChar, 8000).Value = dd_addresOpt_ar1.SelectedValue
            cmd.Parameters.Add("@PackAddlResPrem", SqlDbType.VarChar, 8000).Value = dd_addresOpt_ar1_Amount.Text
            cmd.Parameters.Add("@PackAddlResLiab", SqlDbType.VarChar, 8000).Value = dd_addresliab_wmj.SelectedValue
            cmd.Parameters.Add("@PackAddlResLiabPrem", SqlDbType.VarChar, 8000).Value = addres_liab_amount.Text

            cmd.Parameters.Add("@PackSmokeDet", SqlDbType.VarChar, 8000).Value = dd_smoke_wmj1.SelectedValue
            cmd.Parameters.Add("@PackSmokeCredit", SqlDbType.VarChar, 8000).Value = dd_smoke_wmj1_amount.Text
            cmd.Parameters.Add("@PackSmokeCreditperc", SqlDbType.VarChar, 8000).Value = lblsmokeprecwmj.Text



        ElseIf rateTypelbl.Text = "WMJ Standard Replacement Cost" Then
            cmd.Parameters.Add("@QuoteID", SqlDbType.VarChar, 8000).Value = quoteID
            cmd.Parameters.Add("@PackDwel", SqlDbType.VarChar, 8000).Value = wmj_dwellnc1.Text
            cmd.Parameters.Add("@PackStruc", SqlDbType.VarChar, 8000).Value = wmj_unattStrnc1.Text
            cmd.Parameters.Add("@PackCont", SqlDbType.VarChar, 8000).Value = wmj_perEffnc1.Text
            cmd.Parameters.Add("@PackLiab", SqlDbType.VarChar, 8000).Value = wmj_perLiabnc1.Text
            cmd.Parameters.Add("@PackMedPay", SqlDbType.VarChar, 8000).Value = wmj_medpaync1.Text
            cmd.Parameters.Add("@PackBasePrem", SqlDbType.VarChar, 8000).Value = wmj_basepremnc1.Text
            cmd.Parameters.Add("@PackAOP", SqlDbType.VarChar, 8000).Value = dd_aop_wmjnc1.SelectedValue()
            cmd.Parameters.Add("@PackWind", SqlDbType.VarChar, 8000).Value = "0.00" 'dd_hurded_wmj1.Text
            cmd.Parameters.Add("@PackPerLiab", SqlDbType.VarChar, 8000).Value = dd_pl_wmjnc1.SelectedValue()
            cmd.Parameters.Add("@PackMHReplace", SqlDbType.VarChar, 8000).Value = ""
            cmd.Parameters.Add("@PackContReplace", SqlDbType.VarChar, 8000).Value = dd_rep_wmjnc1.SelectedValue()
            cmd.Parameters.Add("@PackFullRepair", SqlDbType.VarChar, 8000).Value = "" 'dd_sip_wmjnc1.SelectedValue()
            cmd.Parameters.Add("@PackAOPPrem", SqlDbType.VarChar, 8000).Value = dd_aop_wmjnc1_Amount.Text
            cmd.Parameters.Add("@PackPersLiabPrem", SqlDbType.VarChar, 8000).Value = dd_pl_wmjnc1_Amount.Text
            cmd.Parameters.Add("@PackMedPrem", SqlDbType.VarChar, 8000).Value = dd_med_wmjnc1_amt.Text
            cmd.Parameters.Add("@PackStrucPrem", SqlDbType.VarChar, 8000).Value = txt_unattstr_wmjnc1_Amount.Text
            cmd.Parameters.Add("@PackContPrem", SqlDbType.VarChar, 8000).Value = txt_pp_wmjnc1_Amount.Text
            cmd.Parameters.Add("@PackMHReplacePrem", SqlDbType.VarChar, 8000).Value = "" 'dd_mhr_AR1_Amount.Text
            cmd.Parameters.Add("@PackContReplacePrem", SqlDbType.VarChar, 8000).Value = dd_rep_wmjnc1_Amount.Text
            cmd.Parameters.Add("@PackFullRepairPrem", SqlDbType.VarChar, 8000).Value = "" 'dd_sip_wmjnc1_Amount.Text
            cmd.Parameters.Add("@PackTax", SqlDbType.VarChar, 8000).Value = wmj_taxnc1.Text
            cmd.Parameters.Add("@PackFees", SqlDbType.VarChar, 8000).Value = wmj_feesnc1.Text
            cmd.Parameters.Add("@Packtotal", SqlDbType.VarChar, 8000).Value = wmj_totalnc1.Text
            cmd.Parameters.Add("@PackCreditPerc", SqlDbType.VarChar, 8000).Value = WMJpackperclblnc1.Text
            cmd.Parameters.Add("@PackCreditamt", SqlDbType.VarChar, 8000).Value = WMJpackcramtlblnc1.Text
            cmd.Parameters.Add("@Packprem", SqlDbType.VarChar, 8000).Value = WMJpackpremlblnc1.Text
            cmd.Parameters.Add("@PackPPLimit", SqlDbType.VarChar, 8000).Value = wmjppvalue_nc1.Text
            cmd.Parameters.Add("@PackPPPrem", SqlDbType.VarChar, 8000).Value = wmjppprem_nc1.Text
            cmd.Parameters.Add("@PackSPI", SqlDbType.VarChar, 8000).Value = spi_cbo_nc1.SelectedValue
            cmd.Parameters.Add("@PackSPIPrem", SqlDbType.VarChar, 8000).Value = spi_nc1_amount.Text
            cmd.Parameters.Add("@PackAddlRes", SqlDbType.VarChar, 8000).Value = dd_addresOpt_wmjnc1.SelectedValue
            cmd.Parameters.Add("@PackAddlResPrem", SqlDbType.VarChar, 8000).Value = dd_addresOpt_wmjnc1_Amount.Text
            cmd.Parameters.Add("@PackAddlResLiab", SqlDbType.VarChar, 8000).Value = dd_addresliab_wmjnc1.SelectedValue
            cmd.Parameters.Add("@PackAddlResLiabPrem", SqlDbType.VarChar, 8000).Value = addres_liab_wmjnc1_amount.Text

            cmd.Parameters.Add("@PackSmokeDet", SqlDbType.VarChar, 8000).Value = "" 'dd_smoke_wmj1.SelectedValue
            cmd.Parameters.Add("@PackSmokeCredit", SqlDbType.VarChar, 8000).Value = "" 'dd_smoke_wmj1_amount.Text
            cmd.Parameters.Add("@PackSmokeCreditperc", SqlDbType.VarChar, 8000).Value = "" 'lblsmokeprecwmj.Text

        ElseIf rateTypelbl.Text = "WMJ Standard ACV" Then
            cmd.Parameters.Add("@QuoteID", SqlDbType.VarChar, 8000).Value = quoteID
            cmd.Parameters.Add("@PackDwel", SqlDbType.VarChar, 8000).Value = wmj_dwellnc2.Text
            cmd.Parameters.Add("@PackStruc", SqlDbType.VarChar, 8000).Value = wmj_unattStrnc2.Text
            cmd.Parameters.Add("@PackCont", SqlDbType.VarChar, 8000).Value = wmj_perEffnc2.Text
            cmd.Parameters.Add("@PackLiab", SqlDbType.VarChar, 8000).Value = wmj_perLiabnc2.Text
            cmd.Parameters.Add("@PackMedPay", SqlDbType.VarChar, 8000).Value = wmj_medpaync2.Text
            cmd.Parameters.Add("@PackBasePrem", SqlDbType.VarChar, 8000).Value = wmj_basepremnc2.Text
            cmd.Parameters.Add("@PackAOP", SqlDbType.VarChar, 8000).Value = dd_aop_wmjnc2.SelectedValue()
            cmd.Parameters.Add("@PackWind", SqlDbType.VarChar, 8000).Value = "0.00" 'dd_hurded_wmj1.Text
            cmd.Parameters.Add("@PackPerLiab", SqlDbType.VarChar, 8000).Value = dd_pl_wmjnc2.SelectedValue()
            cmd.Parameters.Add("@PackMHReplace", SqlDbType.VarChar, 8000).Value = ""
            cmd.Parameters.Add("@PackContReplace", SqlDbType.VarChar, 8000).Value = dd_rep_wmjnc2.SelectedValue()
            cmd.Parameters.Add("@PackFullRepair", SqlDbType.VarChar, 8000).Value = "" 'dd_sip_wmjnc2.SelectedValue()
            cmd.Parameters.Add("@PackAOPPrem", SqlDbType.VarChar, 8000).Value = dd_aop_wmjnc2_Amount.Text
            cmd.Parameters.Add("@PackPersLiabPrem", SqlDbType.VarChar, 8000).Value = dd_pl_wmjnc2_Amount.Text
            cmd.Parameters.Add("@PackMedPrem", SqlDbType.VarChar, 8000).Value = dd_med_wmjnc2_amt.Text
            cmd.Parameters.Add("@PackStrucPrem", SqlDbType.VarChar, 8000).Value = txt_unattstr_wmjnc2_Amount.Text
            cmd.Parameters.Add("@PackContPrem", SqlDbType.VarChar, 8000).Value = txt_pp_wmjnc2_Amount.Text
            cmd.Parameters.Add("@PackMHReplacePrem", SqlDbType.VarChar, 8000).Value = "" 'dd_mhr_AR1_Amount.Text
            cmd.Parameters.Add("@PackContReplacePrem", SqlDbType.VarChar, 8000).Value = dd_rep_wmjnc2_Amount.Text
            cmd.Parameters.Add("@PackFullRepairPrem", SqlDbType.VarChar, 8000).Value = "" 'dd_sip_wmjnc2_Amount.Text
            cmd.Parameters.Add("@PackTax", SqlDbType.VarChar, 8000).Value = wmj_taxnc2.Text
            cmd.Parameters.Add("@PackFees", SqlDbType.VarChar, 8000).Value = wmj_feesnc2.Text
            cmd.Parameters.Add("@Packtotal", SqlDbType.VarChar, 8000).Value = wmj_totalnc2.Text

            cmd.Parameters.Add("@PackCreditPerc", SqlDbType.VarChar, 8000).Value = WMJpackperclblnc2.Text
            cmd.Parameters.Add("@PackCreditamt", SqlDbType.VarChar, 8000).Value = WMJpackcramtlblnc2.Text
            cmd.Parameters.Add("@Packprem", SqlDbType.VarChar, 8000).Value = WMJpackpremlblnc2.Text


            cmd.Parameters.Add("@PackPPLimit", SqlDbType.VarChar, 8000).Value = wmjppvalue_nc2.Text
            cmd.Parameters.Add("@PackPPPrem", SqlDbType.VarChar, 8000).Value = wmjppprem_nc2.Text
            cmd.Parameters.Add("@PackSPI", SqlDbType.VarChar, 8000).Value = spi_cbo_nc2.SelectedValue
            cmd.Parameters.Add("@PackSPIPrem", SqlDbType.VarChar, 8000).Value = spi_nc2_amount.Text


            cmd.Parameters.Add("@PackAddlRes", SqlDbType.VarChar, 8000).Value = dd_addresOpt_wmjnc2.SelectedValue
            cmd.Parameters.Add("@PackAddlResPrem", SqlDbType.VarChar, 8000).Value = dd_addresOpt_wmjnc2_Amount.Text
            cmd.Parameters.Add("@PackAddlResLiab", SqlDbType.VarChar, 8000).Value = dd_addresliab_wmjnc2.SelectedValue
            cmd.Parameters.Add("@PackAddlResLiabPrem", SqlDbType.VarChar, 8000).Value = addres_liab_wmjnc2_amount.Text

            cmd.Parameters.Add("@PackSmokeDet", SqlDbType.VarChar, 8000).Value = "" 'dd_smoke_wmj1.SelectedValue
            cmd.Parameters.Add("@PackSmokeCredit", SqlDbType.VarChar, 8000).Value = "" 'dd_smoke_wmj1_amount.Text
            cmd.Parameters.Add("@PackSmokeCreditperc", SqlDbType.VarChar, 8000).Value = "" 'lblsmokeprecwmj.Text

        ElseIf rateTypelbl.Text = "WMJ Preferred" Then
            cmd.Parameters.Add("@QuoteID", SqlDbType.VarChar, 8000).Value = quoteID
            cmd.Parameters.Add("@PackDwel", SqlDbType.VarChar, 8000).Value = wmj_dwellnc3.Text
            cmd.Parameters.Add("@PackStruc", SqlDbType.VarChar, 8000).Value = wmj_unattStrnc3.Text
            cmd.Parameters.Add("@PackCont", SqlDbType.VarChar, 8000).Value = wmj_perEffnc3.Text
            cmd.Parameters.Add("@PackLiab", SqlDbType.VarChar, 8000).Value = wmj_perLiabnc3.Text
            cmd.Parameters.Add("@PackMedPay", SqlDbType.VarChar, 8000).Value = wmj_medpaync3.Text
            cmd.Parameters.Add("@PackBasePrem", SqlDbType.VarChar, 8000).Value = wmj_basepremnc3.Text
            cmd.Parameters.Add("@PackAOP", SqlDbType.VarChar, 8000).Value = dd_aop_wmjnc3.SelectedValue()
            cmd.Parameters.Add("@PackWind", SqlDbType.VarChar, 8000).Value = "0.00" 'dd_hurded_wmj1.Text
            cmd.Parameters.Add("@PackPerLiab", SqlDbType.VarChar, 8000).Value = dd_pl_wmjnc3.SelectedValue()
            cmd.Parameters.Add("@PackMHReplace", SqlDbType.VarChar, 8000).Value = ""
            cmd.Parameters.Add("@PackContReplace", SqlDbType.VarChar, 8000).Value = dd_rep_wmjnc3.SelectedValue()
            cmd.Parameters.Add("@PackFullRepair", SqlDbType.VarChar, 8000).Value = "" 'dd_sip_wmj3.SelectedValue()
            cmd.Parameters.Add("@PackAOPPrem", SqlDbType.VarChar, 8000).Value = dd_aop_wmjnc3_Amount.Text
            cmd.Parameters.Add("@PackPersLiabPrem", SqlDbType.VarChar, 8000).Value = dd_pl_wmjnc3_Amount.Text
            cmd.Parameters.Add("@PackMedPrem", SqlDbType.VarChar, 8000).Value = dd_med_wmjnc3_amt.Text
            cmd.Parameters.Add("@PackStrucPrem", SqlDbType.VarChar, 8000).Value = txt_unattstr_wmjnc3_Amount.Text
            cmd.Parameters.Add("@PackContPrem", SqlDbType.VarChar, 8000).Value = txt_pp_wmjnc3_Amount.Text
            cmd.Parameters.Add("@PackMHReplacePrem", SqlDbType.VarChar, 8000).Value = "" 'dd_mhr_AR1_Amount.Text
            cmd.Parameters.Add("@PackContReplacePrem", SqlDbType.VarChar, 8000).Value = dd_rep_wmjnc3_Amount.Text
            cmd.Parameters.Add("@PackFullRepairPrem", SqlDbType.VarChar, 8000).Value = "" 'dd_sip_wmjnc3_Amount.Text
            cmd.Parameters.Add("@PackTax", SqlDbType.VarChar, 8000).Value = wmj_taxnc3.Text
            cmd.Parameters.Add("@PackFees", SqlDbType.VarChar, 8000).Value = wmj_feesnc3.Text
            cmd.Parameters.Add("@Packtotal", SqlDbType.VarChar, 8000).Value = wmj_totalnc3.Text

            cmd.Parameters.Add("@PackCreditPerc", SqlDbType.VarChar, 8000).Value = WMJpackperclblnc3.Text
            cmd.Parameters.Add("@PackCreditamt", SqlDbType.VarChar, 8000).Value = WMJpackcramtlblnc3.Text
            cmd.Parameters.Add("@Packprem", SqlDbType.VarChar, 8000).Value = WMJpackpremlblnc3.Text


            cmd.Parameters.Add("@PackPPLimit", SqlDbType.VarChar, 8000).Value = wmjppvalue_nc3.Text
            cmd.Parameters.Add("@PackPPPrem", SqlDbType.VarChar, 8000).Value = wmjppprem_nc3.Text
            cmd.Parameters.Add("@PackSPI", SqlDbType.VarChar, 8000).Value = spi_cbo_nc3.SelectedValue
            cmd.Parameters.Add("@PackSPIPrem", SqlDbType.VarChar, 8000).Value = spi_nc3_amount.Text


            cmd.Parameters.Add("@PackAddlRes", SqlDbType.VarChar, 8000).Value = dd_addresOpt_wmjnc3.SelectedValue
            cmd.Parameters.Add("@PackAddlResPrem", SqlDbType.VarChar, 8000).Value = dd_addresOpt_wmjnc3_Amount.Text
            cmd.Parameters.Add("@PackAddlResLiab", SqlDbType.VarChar, 8000).Value = dd_addresliab_wmjnc3.SelectedValue
            cmd.Parameters.Add("@PackAddlResLiabPrem", SqlDbType.VarChar, 8000).Value = addres_liab_wmjnc3_amount.Text

            cmd.Parameters.Add("@PackSmokeDet", SqlDbType.VarChar, 8000).Value = "" 'dd_smoke_wmj1.SelectedValue
            cmd.Parameters.Add("@PackSmokeCredit", SqlDbType.VarChar, 8000).Value = "" 'dd_smoke_wmj1_amount.Text
            cmd.Parameters.Add("@PackSmokeCreditperc", SqlDbType.VarChar, 8000).Value = "" 'lblsmokeprecwmj.Text
        End If

            Try
                Dim ds As Data.DataSet = New Data.DataSet

                cmd.Connection.Open()
                ' intRowsAff = cmd.ExecuteNonQuery()

                Dim myCommand = New SqlDataAdapter(cmd)
                myCommand.Fill(ds, "tbl1")
            Catch ex As Exception
                Dim s As String = ""
                For Each param As SqlParameter In cmd.Parameters
                    s += param.ParameterName & "="
                    s += param.Value & ":  "

                Next
                errortrap("Saving wmj Data " & s, "Save Prem", ex.Message)
            End Try



    End Sub

    Private Sub wmjPPGrid_RowDeleting(sender As Object, e As DevExpress.Web.Data.ASPxDataDeletingEventArgs) Handles wmjPPGrid.RowDeleting
        Dim i As Integer = AegisPPGrid.FindVisibleIndexByKeyValue(e.Keys(AegisPPGrid.KeyFieldName))
        '  Dim c As Control = ASPxGridView1.FindDetailRowTemplateControl(i, "ASPxGridView2")
        i = wmjPPGrid.GetRowValues(wmjPPGrid.FocusedRowIndex, "WMJppID")
        e.Cancel = True
        Dim Connection As String = System.Configuration.ConfigurationManager.ConnectionStrings("ColonialMHConnectionString").ConnectionString
        Dim dbConnection As System.Data.IDbConnection = New System.Data.SqlClient.SqlConnection(Connection)
        Dim cmd As New SqlCommand("sp_wmjDeletePP", dbConnection)
        cmd.CommandType = CommandType.StoredProcedure
        cmd.Parameters.Add("@PPID", SqlDbType.VarChar, 8000).Value = i

        Try
            Dim ds As Data.DataSet = New Data.DataSet

            cmd.Connection.Open()
            ' intRowsAff = cmd.ExecuteNonQuery()

            Dim myCommand = New SqlDataAdapter(cmd)
            myCommand.Fill(ds, "tbl1")
        Catch ex As Exception
            Dim s As String = ""
            For Each param As SqlParameter In cmd.Parameters
                s += param.ParameterName & "="
                s += param.Value & ":  "

            Next
            errortrap("deleting pp wmj Data " & s, "Save Prem", ex.Message)
        End Try
        loadWMJPP()
    End Sub
    Public Sub printFinbtn_Click(ByVal sender As Object, ByVal e As EventArgs) 'Handles premFinbtn.Click
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
                DetailString = fin.CalcFinancingOnly(quoteIDlbl.Text, Nothing)
                financeInfo.Text = DetailString
                financeupdatePanel.Update()
                ModalPopupExtender3.Show()
            End If
        End If
    End Sub
    Public Sub updatePrimeRateDownPayment(ByVal sender As Object, ByVal e As EventArgs) Handles FinUpBtn.Click
        Dim DetailString As String
        Dim fin As New Finance
        primeRateDPDD.SelectedValue.ToString()
        DetailString = fin.CalcFinancingOnly(quoteIDlbl.Text, primeRateDPDD.SelectedValue.ToString)
                financeInfo.Text = DetailString
                financeupdatePanel.Update()
                ModalPopupExtender3.Show()
    End Sub
    Public Sub WMJStandCalcNC(ByVal ds As DataSet)

        Dim smhpremnc1 As String
        Dim smhasnc1 As String
        Dim smhconnc1 As String
        Dim WMJoptnc1 As String

        Dim smhtotalnc1 As Decimal

        If mhvaluechanged.Text = "True" Then
            txt_unattstr_wmjnc1.Text = CInt(MHValuelbl.Text * 0.1)
            txt_pp_wmjnc1.Text = CInt(MHValuelbl.Text * 0.5)
            txt_unattstr_wmjnc2.Text = CInt(MHValuelbl.Text * 0.1)
            txt_pp_wmjnc2.Text = CInt(MHValuelbl.Text * 0.5)
            txt_unattstr_wmjnc3.Text = CInt(MHValuelbl.Text * 0.1)
            txt_pp_wmjnc3.Text = CInt(MHValuelbl.Text * 0.5)


        End If

        If UCase(mhcountylbl.Text) = UCase("Franklin") Or UCase(mhcountylbl.Text) = UCase("Granville") Or UCase(mhcountylbl.Text) = UCase("Harnett") Or UCase(mhcountylbl.Text) = UCase("Hoke") Or UCase(mhcountylbl.Text) = UCase("Richmond") Or UCase(mhcountylbl.Text) = UCase("Scotland") Or UCase(mhcountylbl.Text) = UCase("Vance") Or UCase(mhcountylbl.Text) = UCase("Wake") Or UCase(mhcountylbl.Text) = UCase("Warren") Then
            dd_aop_wmjnc1.SelectedIndex = 0
            dd_aop_wmjnc1.Items.Clear()
            dd_aop_wmjnc1.Items.Add("$1000")

            dd_aop_wmjnc2.SelectedIndex = 0
            dd_aop_wmjnc2.Items.Clear()
            dd_aop_wmjnc2.Items.Add("$1000")

        End If
        ' '' ''if first run or now value, then fill in fields
        '' ''If IsNumeric(txt_unattstr_wmjnc1.Text) And txt_unattstr_wmjnc1.Text <> "0.00" Then
        '' ''    If CInt(txt_unattstr_wmjnc1.Text) > CInt(MHValuelbl.Text * 0.1) Then
        '' ''        ' txt_unattstr_wmjnc1_Amount.Text = ds.Tables("tbl1").Rows(0).Item("Astructurerate").ToString().Replace("$", "") * (txt_unattstr_wmj1.Text / 100)
        '' ''        txt_unattstr_wmjnc1_Amount.Text = ((CInt(txt_unattstr_wmjnc1.Text) - CInt(MHValuelbl.Text * 0.1)) / 1000) * 2
        '' ''        WMJoptnc1 += txt_unattstr_wmjnc1_Amount.Text
        '' ''    Else
        '' ''        txt_unattstr_wmjnc1_Amount.Text = "0.00"
        '' ''    End If
        '' ''Else
        '' ''    txt_unattstr_wmjnc1.Text = CInt(MHValuelbl.Text * 0.1)
        '' ''End If
        '' ''If IsNumeric(txt_pp_wmjnc1.Text) And txt_pp_wmjnc1.Text <> "0.00" Then
        '' ''    If CInt(txt_pp_wmjnc1.Text) > CInt(MHValuelbl.Text * 0.5) Then
        '' ''        'txt_pp_wmjnc1_Amount.Text = ds.Tables("tbl1").Rows(0).Item("PProperty").ToString().Replace("$", "") * (txt_pp_wmj1.Text / 100)
        '' ''        'txt_pp_wmjnc1_Amount.Text = CInt(MHValuelbl.Text * 0.5)
        '' ''        txt_pp_wmjnc1_Amount.Text = ((CInt(txt_pp_wmjnc1.Text) - CInt(MHValuelbl.Text * 0.5)) / 1000) * 2
        '' ''        WMJoptnc1 += txt_pp_wmjnc1_Amount.Text
        '' ''    Else
        '' ''        txt_pp_wmjnc1_Amount.Text = "0.00"
        '' ''    End If

        '' ''End If
        dd_mp_wmjnc1.SelectedValue = "$1000"
        wmj_medpaync1.Text = dd_mp_wmjnc1.SelectedValue()

        wmjlossofusenc1.Text = CInt(MHValuelbl.Text * 0.1)


        wmjnc1_Debug.Text = "<table> <tbody>"
        wmj_dwellnc1.Text = "$" & mhvalue.Replace("$", "")
        wmj_unattStrnc1.Text = "$" & txt_unattstr_wmjnc1.Text.Replace("$", "")
        wmj_perEffnc1.Text = "$" & txt_pp_wmjnc1.Text.Replace("$", "")
        wmj_perLiabnc1.Text = "$" & dd_pl_wmjnc1.SelectedValue().Replace("$", "")
        wmj_medpaync1.Text = "$" & wmj_medpaync1.Text.Replace("$", "")

        If Date.Now.Year - mhyearlbl.Text <= 5 Then
            If protection.Text <= 8 Then
                smhpremnc1 = "$" & ds.Tables("tbl1").Rows(0).Item("SML200Less5UP").ToString().Replace("$", "")
            ElseIf protection.Text > 8 And protection.Text <= 9 Then

                smhpremnc1 = "$" & ds.Tables("tbl1").Rows(0).Item("SML200Less5P").ToString().Replace("$", "")

            End If
        ElseIf Date.Now.Year - mhyearlbl.Text <= 15 Then

            If protection.Text <= 8 Then
                smhpremnc1 = "$" & ds.Tables("tbl1").Rows(0).Item("SML200Less20UP").ToString().Replace("$", "")
            ElseIf protection.Text > 8 And protection.Text <= 9 Then

                smhpremnc1 = "$" & ds.Tables("tbl1").Rows(0).Item("SML200Less20P").ToString().Replace("$", "")

            End If
        ElseIf Date.Now.Year - mhyearlbl.Text <= 20 And mhtypelbl.Text = "Doublewide" Then

            If protection.Text <= 8 Then
                smhpremnc1 = "$" & ds.Tables("tbl1").Rows(0).Item("SML200Less20UP").ToString().Replace("$", "")
            ElseIf protection.Text > 8 And protection.Text <= 9 Then

                smhpremnc1 = "$" & ds.Tables("tbl1").Rows(0).Item("SML200Less20P").ToString().Replace("$", "")

            End If

        End If



        wmjnc1_Debug.Text += "<tr align=left><td>Package Premium </td><td> $" & CInt(smhpremnc1) & " </td></tr> "
        WMJpackpremlblnc1.Text = CInt(smhpremnc1)

        'if first run or now value, then fill in fields
        If IsNumeric(txt_unattstr_wmjnc1.Text) And txt_unattstr_wmjnc1.Text <> "0.00" Then
            If CInt(txt_unattstr_wmjnc1.Text) > CInt(MHValuelbl.Text * 0.1) Then
                ' txt_unattstr_wmjnc1_Amount.Text = ds.Tables("tbl1").Rows(0).Item("Astructurerate").ToString().Replace("$", "") * (txt_unattstr_wmj1.Text / 100)
                'txt_unattstr_wmjnc1_Amount.Text = CInt(MHValuelbl.Text * 0.1)
                txt_unattstr_wmjnc1_Amount.Text = ((CInt(txt_unattstr_wmjnc1.Text) - CInt(MHValuelbl.Text * 0.1)) / 1000) * 4
                WMJoptnc1 += txt_unattstr_wmjnc1_Amount.Text
                wmjnc1_Debug.Text += "<tr align=left><td>Other Structures </td><td> $" & txt_unattstr_wmjnc1_Amount.Text & " </td></tr> "
            Else

                txt_unattstr_wmjnc1_Amount.Text = "0.00"
                wmjnc1_Debug.Text += "<tr align=left><td>Other Structures </td><td> $0.00 </td></tr> "
            End If
        Else
            txt_unattstr_wmjnc1.Text = CInt(MHValuelbl.Text * 0.1)

        End If
        If dd_rep_wmjnc1.SelectedValue = "Yes" Then
            Dim contrepnc1 As String
            If CInt(txt_pp_wmjnc1.Text) > CInt(MHValuelbl.Text * 0.7) Then
                'txt_pp_wmjnc1_Amount.Text = ds.Tables("tbl1").Rows(0).Item("PProperty").ToString().Replace("$", "") * (txt_pp_wmj1.Text / 100)
                'txt_pp_wmjnc1_Amount.Text = CInt(MHValuelbl.Text * 0.5)
                txt_pp_wmjnc1_Amount.Text = ((CInt(txt_pp_wmjnc1.Text) - CInt(MHValuelbl.Text * 0.5)) / 1000) * 5
                WMJoptnc1 += CInt(txt_pp_wmjnc1_Amount.Text)
                wmjnc1_Debug.Text += "<tr align=left><td>Contents </td><td> $" & txt_pp_wmjnc1_Amount.Text & " </td></tr> "
            Else
                txt_pp_wmjnc1.Text = CInt(MHValuelbl.Text * 0.7)
                txt_pp_wmjnc1_Amount.Text = ((CInt(txt_pp_wmjnc1.Text) - CInt(MHValuelbl.Text * 0.5)) / 1000) * 5
                WMJoptnc1 += CInt(txt_pp_wmjnc1_Amount.Text)
                wmjnc1_Debug.Text += "<tr align=left><td>Contents </td><td> $" & txt_pp_wmjnc1_Amount.Text & " </td></tr> "


            End If
        Else
            If IsNumeric(txt_pp_wmjnc1.Text) And txt_pp_wmjnc1.Text <> "0.00" Then
                If CInt(txt_pp_wmjnc1.Text) > CInt(MHValuelbl.Text * 0.5) Then
                    'txt_pp_wmjnc1_Amount.Text = ds.Tables("tbl1").Rows(0).Item("PProperty").ToString().Replace("$", "") * (txt_pp_wmj1.Text / 100)
                    'txt_pp_wmjnc1_Amount.Text = CInt(MHValuelbl.Text * 0.5)
                    txt_pp_wmjnc1_Amount.Text = ((CInt(txt_pp_wmjnc1.Text) - CInt(MHValuelbl.Text * 0.5)) / 1000) * 5
                    WMJoptnc1 += txt_pp_wmjnc1_Amount.Text
                    wmjnc1_Debug.Text += "<tr align=left><td>Contents </td><td> $" & txt_pp_wmjnc1_Amount.Text & " </td></tr> "
                Else
                    txt_pp_wmjnc1_Amount.Text = "0.00"
                    wmjnc1_Debug.Text += "<tr align=left><td>Other Structures </td><td> $0.00 </td></tr> "
                End If
            Else
                txt_pp_wmjnc1.Text = CInt(MHValuelbl.Text * 0.5)
            End If
        End If

        wmj_perEffnc1.Text = "$" & txt_pp_wmjnc1.Text.Replace("$", "")

        '' '' ''If CInt(txt_unattstr_wmjnc1.Text) > CInt(MHValuelbl.Text * 0.01) Then
        '' '' ''    WMJoptnc1 += CInt(CInt(txt_unattstr_wmjnc1.Text) - CInt(MHValuelbl.Text * 0.01) / 1000) * 4
        '' '' ''    wmjnc1_Debug.Text += "<tr align=left><td>Other Structures </td><td> $" & CInt(CInt(txt_unattstr_wmjnc1.Text) - CInt(MHValuelbl.Text * 0.01) / 1000) * 4 & " </td></tr> "
        '' '' ''    txt_unattstr_wmjnc1_Amount.Text = CInt(CInt(txt_unattstr_wmjnc1.Text) - CInt(MHValuelbl.Text * 0.01) / 1000) * 4
        '' '' ''    '' txt_unattstr_wmj1_Amount.Text = CInt(ds.Tables("tbl1").Rows(0).Item("OtherStructure").ToString().Replace("$", ""))
        '' '' ''    ''WMJopt += CInt(txt_unattstr_wmj1.Text = ds.Tables("tbl1").Rows(0).Item("Astructurerate").ToString().Replace("$", "") * (txt_unattstr_wmj1.Text / 100))
        '' '' ''Else
        '' '' ''    wmjnc1_Debug.Text += "<tr align=left><td>Other Structures </td><td> $0.00 </td></tr> "
        '' '' ''    '' txt_unattstr_wmj1_Amount.Text = CInt(ds.Tables("tbl1").Rows(0).Item("OtherStructure").ToString().Replace("$", ""))
        '' '' ''    WMJoptnc1 += 0
        '' '' ''    txt_unattstr_wmjnc1_Amount.Text = "0.00"
        '' '' ''End If

        '' '' ''If CInt(txt_pp_wmj1.Text) > CInt(MHValuelbl.Text * 0.05) Then
        '' '' ''    WMJoptnc1 += CInt(CInt(txt_pp_wmj1.Text) - CInt(MHValuelbl.Text * 0.05) / 1000) * 5
        '' '' ''    wmjnc1_Debug.Text += "<tr align=left><td>Contents </td><td> $" & CInt(CInt(txt_pp_wmj1.Text) - CInt(MHValuelbl.Text * 0.05) / 1000) * 5 & " </td></tr> "
        '' '' ''    txt_pp_wmjnc1_Amount.Text = CInt(CInt(txt_pp_wmj1.Text) - CInt(MHValuelbl.Text * 0.05) / 1000) * 5
        '' '' ''    'WMJopt += CInt(ds.Tables("tbl1").Rows(0).Item("PProperty").ToString().Replace("$", "") * (txt_pp_wmj1.Text / 100))
        '' '' ''Else
        '' '' ''    wmjnc1_Debug.Text += "<tr align=left><td>Contents </td><td> $0.00 </td></tr> "
        '' '' ''    txt_pp_wmjnc1_Amount.Text = "0.00"
        '' '' ''    WMJoptnc1 += 0
        '' '' ''End If
        'wmj_Debug.Text += "<tr align=left><td>Other Structures </td><td> $" & CInt(txt_unattstr_wmj1.Text = ds.Tables("tbl1").Rows(0).Item("Astructurerate").ToString().Replace("$", "") * (txt_unattstr_wmj1.Text / 100)) & " </td></tr> "
        ' '' txt_unattstr_wmj1_Amount.Text = CInt(ds.Tables("tbl1").Rows(0).Item("OtherStructure").ToString().Replace("$", ""))
        'WMJopt += CInt(txt_unattstr_wmj1.Text = ds.Tables("tbl1").Rows(0).Item("Astructurerate").ToString().Replace("$", "") * (txt_unattstr_wmj1.Text / 100))
        'wmj_Debug.Text += "<tr align=left><td>Contents </td><td> $" & CInt(ds.Tables("tbl1").Rows(0).Item("PProperty").ToString().Replace("$", "") * (txt_pp_wmj1.Text / 100)) & " </td></tr> "
        ''txt_pp_WMJ2_Amount.Text = CInt(ds.Tables("tbl1").Rows(0).Item("Contents").ToString().Replace("$", ""))
        'WMJopt += CInt(ds.Tables("tbl1").Rows(0).Item("PProperty").ToString().Replace("$", "") * (txt_pp_wmj1.Text / 100))
        'wmj_Debug.Text += "<tr align=left><td>Addl Living Expense</td><td> $" & CInt("0") & " </td></tr> "
        'txt_unattstr_WMJ1_Amount.Text = Math.Ceiling(CDbl(ds.Tables("tbl1").Rows(0).Item("OtherStructure").ToString().Replace("$", "")))
        'txt_pp_WMJ1_Amount.Text = Math.Ceiling(CDbl(ds.Tables("tbl1").Rows(0).Item("Contents").ToString().Replace("$", "")))


        ' smhtotal = CInt(smhprem) + Math.Ceiling(CDbl(ds.Tables("tbl1").Rows(0).Item("Astructurerate").ToString().Replace("$", "") * (txt_unattstr_wmj1.Text / 100))) + Math.Ceiling(CDbl(ds.Tables("tbl1").Rows(0).Item("PProperty").ToString().Replace("$", "") * (txt_pp_wmj1.Text / 100)))
        smhtotalnc1 = CInt(smhpremnc1) + CInt(txt_unattstr_wmjnc1_Amount.Text) + CInt(txt_pp_wmjnc1_Amount.Text)
        wmjnc1_Debug.Text += "<tr align=left><td>Sub Premium</td><td> $" & CInt(smhtotalnc1) & " </td></tr> "

        'Dim CreditsPercentage As Decimal
        ''Add credit stuff to label
        'CreditsPercentage = ds.Tables("tbl1").Rows(0).Item("Credit").ToString().Replace("$", "")
        'WMJ_Debug.Text += "<tr align=left><td> Credits %</td><td> " & CreditsPercentage * 100 & "% </td></tr> "
        'WMJ_Debug.Text += "<tr align=left><td> Credits Value</td><td>-" & Math.Round((smhtotal * CreditsPercentage), 0, MidpointRounding.AwayFromZero) & " </td></tr> "
        'smhtotal -= RouMath.nd((smhtotal * CreditsPercentage), 0, MidpointRounding.AwayFromZero)
        If dd_aop_wmjnc1.SelectedValue = "$1000" Then
            Dim CreditsPercentage As Decimal
            CreditsPercentage = 0.096
            wmjnc1_Debug.Text += "<tr align=left><td> Credits %</td><td> " & CreditsPercentage * 100 & "% </td></tr> "
            wmjnc1_Debug.Text += "<tr align=left><td> Credits Value</td><td>-" & Math.Round((smhpremnc1 * CreditsPercentage), 0, MidpointRounding.AwayFromZero) & " </td></tr> "
            smhtotalnc1 -= Math.Round((smhpremnc1 * CreditsPercentage), 0, MidpointRounding.AwayFromZero)
            WMJpackperclblnc1.Text = "0.096"
            WMJpackcramtlblnc1.Text = Math.Round((smhpremnc1 * CreditsPercentage), 0, MidpointRounding.AwayFromZero)
            dd_aop_wmjnc1_Amount.Text = "(" & Math.Round((smhpremnc1 * CreditsPercentage), 0, MidpointRounding.AwayFromZero) & ")"
        End If

        wmj_basepremnc1.Text = "$" & CInt(smhtotalnc1)
        wmjnc1_Debug.Text += "<tr align=left><td>Base Premium</td><td> $" & CInt(smhtotalnc1) & " </td></tr> "
        'WMJpackpremlbl.Text = CInt(smhtotal)
        If dd_pl_wmjnc1.SelectedItem.Text = "$50,000" Then
            wmjnc1_Debug.Text += "<tr align=left><td>Personal Liability</td><td> $0.00  </td></tr> "
            dd_pl_wmjnc1_Amount.Text = CInt("0.00")

        ElseIf dd_pl_wmjnc1.SelectedItem.Text = "$100,000" Then
            wmjnc1_Debug.Text += "<tr align=left><td>Personal Liability</td><td> $1.00  </td></tr> "
            dd_pl_wmjnc1_Amount.Text = CInt("1.00")
            smhtotalnc1 += CInt("1.00")
        ElseIf dd_pl_wmjnc1.SelectedItem.Text = "$300,000" Then
            wmjnc1_Debug.Text += "<tr align=left><td>Personal Liability</td><td> $5.00  </td></tr> "
            dd_pl_wmjnc1_Amount.Text = CInt("5.00")
            smhtotalnc1 += CInt("5.00")
        End If


        wmjnc1_Debug.Text += "<tr align=left><td>Medical Payment</td><td> $ 0  </td></tr> "
        WMJpackperclbl.Text = "0"
        WMJpackcramtlbl.Text = "0"
        Dim WMJcredit As Decimal

        wmjnc1_Debug.Text += "<tr align=left><td>SUB TOTAL 2</td><td> $" & CInt(smhtotalnc1) & " </td></tr> "
        'If dd_aop_wmj1.SelectedValue = "$500" Then
        '    wmj_Debug.Text += "<tr align=left><td>AOP</td><td> $0 </td></tr> "
        '    dd_aop_wmj1_Amount.Text = "0.00"
        '    'dd_aop_08_Amount.Text = ds.Tables("tbl1").Rows(0).Item("AOP").ToString().Replace("$", "")
        '    ' smhtotal += CInt(ds.Tables("tbl1").Rows(0).Item("AOP").ToString().Replace("$", ""))
        'Else
        '    wmj_Debug.Text += "<tr align=left><td>AOP</td><td> ( $" & CInt(smhtotal * 0.05) & " )</td></tr> "
        '    'dd_aop_08_Amount.Text = ds.Tables("tbl1").Rows(0).Item("AOP").ToString().Replace("$", "")
        '    dd_aop_wmj1_Amount.Text = "(" & CInt(smhtotal * 0.05) & ")"
        '    smhtotal -= CInt(smhtotal * 0.05)
        '    WMJopt -= CInt(smhtotal * 0.05)
        '    'WMJcredit += CInt(smhtotal * 0.05)
        'End If


        wmjnc1_Debug.Text += "<tr align=left><td>SUB TOTAL 3</td><td> $" & CInt(smhtotalnc1) & " </td></tr> "
        If dd_rep_wmjnc1.SelectedValue = "Yes" Then
            Dim contrepnc1 As String
            'If CInt(txt_pp_wmjnc1.Text) > CInt(MHValuelbl.Text * 0.7) Then
            '    'txt_pp_wmjnc1_Amount.Text = ds.Tables("tbl1").Rows(0).Item("PProperty").ToString().Replace("$", "") * (txt_pp_wmj1.Text / 100)
            '    'txt_pp_wmjnc1_Amount.Text = CInt(MHValuelbl.Text * 0.5)
            '    txt_pp_wmjnc1_Amount.Text = ((CInt(txt_pp_wmjnc1.Text) - CInt(MHValuelbl.Text * 0.5)) / 1000) * 5
            '    WMJoptnc1 += CInt(txt_pp_wmjnc1_Amount.Text)
            '    wmjnc1_Debug.Text += "<tr align=left><td>Contents </td><td> $" & txt_pp_wmjnc1_Amount.Text & " </td></tr> "
            'Else
            '    txt_pp_wmjnc1.Text = CInt(MHValuelbl.Text * 0.7)
            '    txt_pp_wmjnc1_Amount.Text = ((CInt(txt_pp_wmjnc1.Text) - CInt(MHValuelbl.Text * 0.5)) / 1000) * 5
            '    WMJoptnc1 += CInt(txt_pp_wmjnc1_Amount.Text)
            '    wmjnc1_Debug.Text += "<tr align=left><td>Contents </td><td> $" & txt_pp_wmjnc1_Amount.Text & " </td></tr> "


            'End If




            contrepnc1 = (CInt(smhpremnc1) + CInt(txt_pp_wmjnc1_Amount.Text)) * 0.05


            If contrepnc1 < 20 Then
                contrepnc1 = "20"
            Else
                contrepnc1 = CInt(contrepnc1)

            End If


            wmjnc1_Debug.Text += "<tr align=left><td>Contents Replacement</td><td> $" & contrepnc1 & " </td></tr> "
            dd_rep_wmjnc1_Amount.Text = CInt(contrepnc1)
            WMJoptnc1 += CInt(contrepnc1)
            smhtotalnc1 += CInt(contrepnc1)
        Else
            txt_pp_wmjnc1.Text = CInt(MHValuelbl.Text * 0.5)
            dd_rep_wmjnc1_Amount.Text = "0.00"
        End If
        Dim age As Integer = 0
        If IsNumeric(mhyearlbl.Text) Then
            age = Now.Year - CInt(mhyearlbl.Text)
        End If
        'If age > 15 Then
        '    dd_sip_wmjnc1.Enabled = False
        '    dd_sip_wmjnc1.SelectedValue = "No"
        'Else
        '    dd_sip_wmjnc1.Enabled = True

        'End If
        'If dd_sip_wmjnc1.SelectedValue = "Yes" Then
        '    If age < 16 Then
        '        wmjnc1_Debug.Text += "<tr align=left><td>Full Repair</td><td> $10 </td></tr> "
        '        WMJoptnc1 += 10
        '        smhtotalnc1 += 10
        '        dd_sip_wmjnc1_Amount.Text = "10"
        '    Else
        '        dd_sip_wmjnc1_Amount.Text = "0.00"
        '    End If


        'End If
        If spi_cbo_nc1.SelectedValue = "Yes" Then
            wmjnc1_Debug.Text += "<tr align=left><td>Secured Party's Interest</td><td> $10 </td></tr> "
            WMJoptnc1 += 10
            smhtotalnc1 += 10
            spi_nc1_amount.Text = "10"
        Else
            spi_nc1_amount.Text = "0.00"

        End If
        wmjnc1_Debug.Text += "<tr align=left><td>Scheduled Personal Property:</td><td> $" & wmjppprem_nc1.Text & " </td></tr> "
        smhtotalnc1 += CDec(wmjppprem_nc1.Text)
        WMJoptnc1 += CDec(wmjppprem_nc1.Text)
        'WMJ_fees2.Text = "$" & CInt(ds.Tables("tbl1").Rows(0).Item("Fee").ToString())
        'WMJ_Debug.Text += "<tr align=left><td>Policy Fee</td><td> $" & CInt(ds.Tables("tbl1").Rows(0).Item("Fee").ToString()) & " </td></tr> "
        'smhtotal += CInt(ds.Tables("tbl1").Rows(0).Item("Fee").ToString())


        If dd_addresOpt_wmjnc1.SelectedValue = "1 Family" Then
            If dd_addresliab_wmjnc1.SelectedValue = "$0" Then
                dd_addresliab_wmjnc1.SelectedValue = "$50,000"
            End If
            If dd_addresliab_wmjnc1.SelectedValue = "$50,000" Then
                addres_liab_wmjnc1_amount.Text = "8"
                WMJoptnc1 += 8
                smhtotalnc1 += 8
                wmjnc1_Debug.Text += "<tr align=left><td>Additional Residence Premises Liability</td><td> $8.00  </td></tr> "
            End If
            If dd_addresliab_wmjnc1.SelectedValue = "$100,000" Then
                addres_liab_wmjnc1_amount.Text = "9"
                WMJoptnc1 += 9
                smhtotalnc1 += 9
                wmjnc1_Debug.Text += "<tr align=left><td>Additional Residence Premises Liability</td><td> $9.00  </td></tr> "
            End If
            If dd_addresliab_wmjnc1.SelectedValue = "$300,000" Then
                addres_liab_wmjnc1_amount.Text = "11"
                WMJoptnc1 += 11
                smhtotalnc1 += 11
                wmjnc1_Debug.Text += "<tr align=left><td>Additional Residence Premises Liability</td><td> $11.00  </td></tr> "
            End If

        End If
        If dd_addresOpt_wmjnc1.SelectedValue = "2 Family" Then
            If dd_addresliab_wmjnc1.SelectedValue = "$0" Then
                dd_addresliab_wmjnc1.SelectedValue = "$50,000"
            End If
            If dd_addresliab_wmjnc1.SelectedValue = "$50,000" Then
                addres_liab_wmjnc1_amount.Text = "10"
                WMJoptnc1 += 10
                smhtotalnc1 += 10
                wmj_Debug.Text += "<tr align=left><td>Additional Residence Premises Liability</td><td> $10.00  </td></tr> "
            End If
            If dd_addresliab_wmjnc1.SelectedValue = "$100,000" Then
                addres_liab_wmjnc1_amount.Text = "11"
                WMJoptnc1 += 11
                smhtotalnc1 += 11
                wmjnc1_Debug.Text += "<tr align=left><td>Additional Residence Premises Liability</td><td> $11.00  </td></tr> "
            End If
            If dd_addresliab_wmjnc1.SelectedValue = "$300,000" Then
                addres_liab_wmjnc1_amount.Text = "13"
                WMJoptnc1 += 13
                smhtotalnc1 += 13
                wmjnc1_Debug.Text += "<tr align=left><td>Additional Residence Premises Liability</td><td> $13.00  </td></tr> "
            End If

        End If


        wmjnc1_Debug.Text += "<tr align=left><td>SUB TOTAL 4</td><td> $" & smhtotalnc1 & " </td></tr> "
        wmj_totalnc1.Text = smhtotalnc1.ToString("C2")



        'If lienlbl.Text = "No" Then
        '    wmj_Debug.Text += "<tr align=left><td>No Lien</td><td> ($15) </td></tr> "
        '    WMJpackcramtlbl.Text = "($15)"
        '    smhtotal -= 15
        'End If
        wmjnc1_Debug.Text += "<tr align=left><td>SUB TOTAL 5</td><td> $" & smhtotalnc1 & " </td></tr> "
        ' '' ''If DropDownList1.SelectedValue() = "Yes" Then
        ' '' ''    WMJsatprem.Text = "5"
        ' '' ''    WMJopt += 5
        ' '' ''Else
        ' '' ''    WMJsatprem.Text = "0.00"
        ' '' ''End If
        'If IsNumeric(txt_Sat_value.Text) Then
        '    If CInt(txt_Sat_value.Text) > 0 Then
        '        Dim sat As Integer
        '        sat = (CInt(txt_Sat_value.Text) / 100) * 5
        '        If sat < 5 Then
        '            sat = 5

        '        End If
        '        wmj_Debug.Text += "<tr align=left><td>Antenna/ Satalite Dish:</td><td> $" & sat & " </td></tr> "
        '        wmjsatprem.Text = sat
        '        WMJopt += sat
        '        smhtotal += sat
        '    End If

        'End If
        wmj_feesnc1.Text = "$0"
        'If supheatlbl.Text = "Yes" Then
        '    If (smhtotal * 0.1) < 30 Then
        '        wmj_Debug.Text += "<tr align=left><td>Supplemental Heating</td><td> $30 </td></tr> "
        '        smhtotal += 30
        '        wmj_fees2.Text = "$30"
        '    Else
        '        wmj_Debug.Text += "<tr align=left><td>Supplemental Heating</td><td> $" & CInt(smhtotal * 0.1) & "</td></tr> "
        '        wmj_fees2.Text = "$" & CInt(smhtotal * 0.1)
        '        smhtotal += CInt(smhtotal * 0.1)

        '    End If
        'End If
        wmj_optionsnc1.Text = "$" & WMJoptnc1
        wmjnc1_Debug.Text += "<tr align=left><td>Total Prem</td><td> $" & CDbl(smhtotalnc1) & " </td></tr> "
        'WMJ_options2.Text = CInt(ds.Tables("tbl1").Rows(0).Item("AOP").ToString().Replace("$", "")) + CInt(ds.Tables("tbl1").Rows(0).Item("Liab").ToString()) + CInt(ds.Tables("tbl1").Rows(0).Item("ContRep").ToString()) + CInt(ds.Tables("tbl1").Rows(0).Item("Enhance").ToString())
        'WMJ_total2.Text = String.Format("{0:C}", CInt(SC08_baseprem.Text) + CInt(SC08_options.Text) + CDbl(SC08_fees.Text) + CDbl(SC08_tax.Text))
        wmj_totalnc1.Text = smhtotalnc1.ToString("C2")
        wmjnc1_Debug.Text += "</tbody></table>"
        wmj_mh_prognc1.Visible = True
        wmj_mh_prognc1_Options.Visible = True

        ''========================NC 2==========================================


        Dim smhpremnc2 As String
        Dim smhasnc2 As String
        Dim smhconnc2 As String
        Dim WMJoptnc2 As String

        Dim smhtotalnc2 As Decimal





        dd_mp_wmjnc2.SelectedValue = "$1000"
        wmj_medpaync2.Text = dd_mp_wmjnc2.SelectedValue()

        wmjlossofusenc2.Text = CInt(MHValuelbl.Text * 0.1)


        wmjnc2_Debug.Text = "<table> <tbody>"
        wmj_dwellnc2.Text = "$" & mhvalue.Replace("$", "")
        wmj_unattStrnc2.Text = "$" & txt_unattstr_wmjnc2.Text.Replace("$", "")
        wmj_perEffnc2.Text = "$" & txt_pp_wmjnc2.Text.Replace("$", "")
        wmj_perLiabnc2.Text = "$" & dd_pl_wmjnc2.SelectedValue().Replace("$", "")
        wmj_medpaync2.Text = "$" & wmj_medpaync2.Text.Replace("$", "")

        If Date.Now.Year - mhyearlbl.Text <= 5 Then
            If protection.Text <= 8 Then
                smhpremnc2 = "$" & ds.Tables("tbl1").Rows(0).Item("SLess5UP").ToString().Replace("$", "")
            ElseIf protection.Text > 8 And protection.Text <= 9 Then

                smhpremnc2 = "$" & ds.Tables("tbl1").Rows(0).Item("SLess5P").ToString().Replace("$", "")

            End If
        ElseIf Date.Now.Year - mhyearlbl.Text > 5 Then

            If protection.Text <= 8 Then
                smhpremnc2 = "$" & ds.Tables("tbl1").Rows(0).Item("Smore5UP").ToString().Replace("$", "")
            ElseIf protection.Text > 8 And protection.Text <= 9 Then

                smhpremnc2 = "$" & ds.Tables("tbl1").Rows(0).Item("Smore5P").ToString().Replace("$", "")

            End If


        End If



        wmjnc2_Debug.Text += "<tr align=left><td>Package Premium </td><td> $" & CInt(smhpremnc2) & " </td></tr> "
        WMJpackpremlblnc2.Text = CInt(smhpremnc2)
        'if first run or now value, then fill in fields
        If IsNumeric(txt_unattstr_wmjnc2.Text) And txt_unattstr_wmjnc2.Text <> "0.00" Then
            If CInt(txt_unattstr_wmjnc2.Text) > CInt(MHValuelbl.Text * 0.1) Then
                ' txt_unattstr_wmjnc2_Amount.Text = ds.Tables("tbl1").Rows(0).Item("Astructurerate").ToString().Replace("$", "") * (txt_unattstr_wmj1.Text / 100)
                'txt_unattstr_wmjnc2_Amount.Text = CInt(MHValuelbl.Text * 0.1)
                txt_unattstr_wmjnc2_Amount.Text = ((CInt(txt_unattstr_wmjnc2.Text) - CInt(MHValuelbl.Text * 0.1)) / 1000) * 4
                WMJoptnc2 += txt_unattstr_wmjnc2_Amount.Text
                wmjnc2_Debug.Text += "<tr align=left><td>Other Structures </td><td> $" & txt_unattstr_wmjnc2_Amount.Text & " </td></tr> "
            Else

                txt_unattstr_wmjnc2_Amount.Text = "0.00"
                wmjnc2_Debug.Text += "<tr align=left><td>Other Structures </td><td> $0.00 </td></tr> "
            End If
        Else
            txt_unattstr_wmjnc2.Text = CInt(MHValuelbl.Text * 0.1)

        End If
        If IsNumeric(txt_pp_wmjnc2.Text) And txt_pp_wmjnc2.Text <> "0.00" Then
            If CInt(txt_pp_wmjnc2.Text) > CInt(MHValuelbl.Text * 0.5) Then
                'txt_pp_wmjnc2_Amount.Text = ds.Tables("tbl1").Rows(0).Item("PProperty").ToString().Replace("$", "") * (txt_pp_wmj1.Text / 100)
                'txt_pp_wmjnc2_Amount.Text = CInt(MHValuelbl.Text * 0.5)
                txt_pp_wmjnc2_Amount.Text = ((CInt(txt_pp_wmjnc2.Text) - CInt(MHValuelbl.Text * 0.5)) / 1000) * 5
                WMJoptnc2 += txt_pp_wmjnc2_Amount.Text
                wmjnc2_Debug.Text += "<tr align=left><td>Contents </td><td> $" & txt_pp_wmjnc2_Amount.Text & " </td></tr> "
            Else
                txt_pp_wmjnc2_Amount.Text = "0.00"
                wmjnc2_Debug.Text += "<tr align=left><td>Other Structures </td><td> $0.00 </td></tr> "
            End If
        Else
            txt_pp_wmjnc2.Text = CInt(MHValuelbl.Text * 0.5)
        End If
        ' '' ''If CInt(txt_unattstr_wmjnc2.Text) > CInt(MHValuelbl.Text * 0.01) Then
        ' '' ''    WMJoptnc2 += CInt(CInt(txt_unattstr_wmjnc2.Text) - CInt(MHValuelbl.Text * 0.01) / 1000) * 4
        ' '' ''    wmjnc2_Debug.Text += "<tr align=left><td>Other Structures </td><td> $" & CInt(CInt(txt_unattstr_wmjnc2.Text) - CInt(MHValuelbl.Text * 0.01) / 1000) * 4 & " </td></tr> "
        ' '' ''    txt_unattstr_wmjnc2_Amount.Text = CInt(CInt(txt_unattstr_wmjnc2.Text) - CInt(MHValuelbl.Text * 0.01) / 1000) * 4
        ' '' ''    '' txt_unattstr_wmj1_Amount.Text = CInt(ds.Tables("tbl1").Rows(0).Item("OtherStructure").ToString().Replace("$", ""))
        ' '' ''    ''WMJopt += CInt(txt_unattstr_wmj1.Text = ds.Tables("tbl1").Rows(0).Item("Astructurerate").ToString().Replace("$", "") * (txt_unattstr_wmj1.Text / 100))
        ' '' ''Else
        ' '' ''    wmjnc2_Debug.Text += "<tr align=left><td>Other Structures </td><td> $0.00 </td></tr> "
        ' '' ''    '' txt_unattstr_wmj1_Amount.Text = CInt(ds.Tables("tbl1").Rows(0).Item("OtherStructure").ToString().Replace("$", ""))
        ' '' ''    WMJoptnc2 += 0
        ' '' ''    txt_unattstr_wmjnc2_Amount.Text = "0.00"
        ' '' ''End If

        ' '' ''If CInt(txt_pp_wmj1.Text) > CInt(MHValuelbl.Text * 0.05) Then
        ' '' ''    WMJoptnc2 += CInt(CInt(txt_pp_wmj1.Text) - CInt(MHValuelbl.Text * 0.05) / 1000) * 5
        ' '' ''    wmjnc2_Debug.Text += "<tr align=left><td>Contents </td><td> $" & CInt(CInt(txt_pp_wmj1.Text) - CInt(MHValuelbl.Text * 0.05) / 1000) * 5 & " </td></tr> "
        ' '' ''    txt_pp_wmjnc2_Amount.Text = CInt(CInt(txt_pp_wmj1.Text) - CInt(MHValuelbl.Text * 0.05) / 1000) * 5
        ' '' ''    'WMJopt += CInt(ds.Tables("tbl1").Rows(0).Item("PProperty").ToString().Replace("$", "") * (txt_pp_wmj1.Text / 100))
        ' '' ''Else
        ' '' ''    wmjnc2_Debug.Text += "<tr align=left><td>Contents </td><td> $0.00 </td></tr> "
        ' '' ''    txt_pp_wmjnc2_Amount.Text = "0.00"
        ' '' ''    WMJoptnc2 += 0
        ' '' ''End If
        'wmj_Debug.Text += "<tr align=left><td>Other Structures </td><td> $" & CInt(txt_unattstr_wmj1.Text = ds.Tables("tbl1").Rows(0).Item("Astructurerate").ToString().Replace("$", "") * (txt_unattstr_wmj1.Text / 100)) & " </td></tr> "
        ' '' txt_unattstr_wmj1_Amount.Text = CInt(ds.Tables("tbl1").Rows(0).Item("OtherStructure").ToString().Replace("$", ""))
        'WMJopt += CInt(txt_unattstr_wmj1.Text = ds.Tables("tbl1").Rows(0).Item("Astructurerate").ToString().Replace("$", "") * (txt_unattstr_wmj1.Text / 100))
        'wmj_Debug.Text += "<tr align=left><td>Contents </td><td> $" & CInt(ds.Tables("tbl1").Rows(0).Item("PProperty").ToString().Replace("$", "") * (txt_pp_wmj1.Text / 100)) & " </td></tr> "
        ''txt_pp_WMJ2_Amount.Text = CInt(ds.Tables("tbl1").Rows(0).Item("Contents").ToString().Replace("$", ""))
        'WMJopt += CInt(ds.Tables("tbl1").Rows(0).Item("PProperty").ToString().Replace("$", "") * (txt_pp_wmj1.Text / 100))
        'wmj_Debug.Text += "<tr align=left><td>Addl Living Expense</td><td> $" & CInt("0") & " </td></tr> "
        'txt_unattstr_WMJ1_Amount.Text = Math.Ceiling(CDbl(ds.Tables("tbl1").Rows(0).Item("OtherStructure").ToString().Replace("$", "")))
        'txt_pp_WMJ1_Amount.Text = Math.Ceiling(CDbl(ds.Tables("tbl1").Rows(0).Item("Contents").ToString().Replace("$", "")))


        ' smhtotal = CInt(smhprem) + Math.Ceiling(CDbl(ds.Tables("tbl1").Rows(0).Item("Astructurerate").ToString().Replace("$", "") * (txt_unattstr_wmj1.Text / 100))) + Math.Ceiling(CDbl(ds.Tables("tbl1").Rows(0).Item("PProperty").ToString().Replace("$", "") * (txt_pp_wmj1.Text / 100)))
        smhtotalnc2 = CInt(smhpremnc2) + CInt(txt_unattstr_wmjnc2_Amount.Text) + CInt(txt_pp_wmjnc2_Amount.Text)
        wmjnc2_Debug.Text += "<tr align=left><td>Sub Premium</td><td> $" & CInt(smhtotalnc2) & " </td></tr> "
        'Dim CreditsPercentage As Decimal
        ''Add credit stuff to label
        'CreditsPercentage = ds.Tables("tbl1").Rows(0).Item("Credit").ToString().Replace("$", "")
        'WMJ_Debug.Text += "<tr align=left><td> Credits %</td><td> " & CreditsPercentage * 100 & "% </td></tr> "
        'WMJ_Debug.Text += "<tr align=left><td> Credits Value</td><td>-" & Math.Round((smhtotal * CreditsPercentage), 0, MidpointRounding.AwayFromZero) & " </td></tr> "
        'smhtotal -= Math.Round((smhtotal * CreditsPercentage), 0, MidpointRounding.AwayFromZero)
        If dd_aop_wmjnc2.SelectedValue = "$1000" Then
            Dim CreditsPercentage As Decimal
            CreditsPercentage = 0.096
            wmjnc2_Debug.Text += "<tr align=left><td> Credits %</td><td> " & CreditsPercentage * 100 & "% </td></tr> "
            wmjnc2_Debug.Text += "<tr align=left><td> Credits Value</td><td>-" & Math.Round((smhpremnc2 * CreditsPercentage), 0, MidpointRounding.AwayFromZero) & " </td></tr> "
            smhtotalnc2 -= Math.Round((smhpremnc2 * CreditsPercentage), 0, MidpointRounding.AwayFromZero)
            WMJpackperclblnc2.Text = "0.096"
            WMJpackcramtlblnc2.Text = Math.Round((smhpremnc2 * CreditsPercentage), 0, MidpointRounding.AwayFromZero)
            dd_aop_wmjnc2_Amount.Text = "(" & Math.Round((smhpremnc2 * CreditsPercentage), 0, MidpointRounding.AwayFromZero) & ")"
        End If
        wmj_basepremnc2.Text = "$" & CInt(smhtotalnc2)
        wmjnc2_Debug.Text += "<tr align=left><td>Base Premium</td><td> $" & CInt(smhtotalnc2) & " </td></tr> "
        'WMJpackpremlbl.Text = CInt(smhtotal)
        If dd_pl_wmjnc2.SelectedItem.Text = "$50,000" Then
            wmjnc2_Debug.Text += "<tr align=left><td>Personal Liability</td><td> $0.00  </td></tr> "
            dd_pl_wmjnc2_Amount.Text = CInt("0.00")

        ElseIf dd_pl_wmjnc2.SelectedItem.Text = "$100,000" Then
            wmjnc2_Debug.Text += "<tr align=left><td>Personal Liability</td><td> $1.00  </td></tr> "
            dd_pl_wmjnc2_Amount.Text = CInt("1.00")
            smhtotalnc2 += CInt("1.00")
        ElseIf dd_pl_wmjnc2.SelectedItem.Text = "$300,000" Then
            wmjnc2_Debug.Text += "<tr align=left><td>Personal Liability</td><td> $5.00  </td></tr> "
            dd_pl_wmjnc2_Amount.Text = CInt("5.00")
            smhtotalnc2 += CInt("5.00")
        End If


        wmjnc2_Debug.Text += "<tr align=left><td>Medical Payment</td><td> $ 0  </td></tr> "
        WMJpackperclbl.Text = "0"
        WMJpackcramtlbl.Text = "0"
        ' Dim WMJcredit As Decimal

        wmjnc2_Debug.Text += "<tr align=left><td>SUB TOTAL 2</td><td> $" & CInt(smhtotalnc2) & " </td></tr> "
        'If dd_aop_wmj1.SelectedValue = "$500" Then
        '    wmj_Debug.Text += "<tr align=left><td>AOP</td><td> $0 </td></tr> "
        '    dd_aop_wmj1_Amount.Text = "0.00"
        '    'dd_aop_08_Amount.Text = ds.Tables("tbl1").Rows(0).Item("AOP").ToString().Replace("$", "")
        '    ' smhtotal += CInt(ds.Tables("tbl1").Rows(0).Item("AOP").ToString().Replace("$", ""))
        'Else
        '    wmj_Debug.Text += "<tr align=left><td>AOP</td><td> ( $" & CInt(smhtotal * 0.05) & " )</td></tr> "
        '    'dd_aop_08_Amount.Text = ds.Tables("tbl1").Rows(0).Item("AOP").ToString().Replace("$", "")
        '    dd_aop_wmj1_Amount.Text = "(" & CInt(smhtotal * 0.05) & ")"
        '    smhtotal -= CInt(smhtotal * 0.05)
        '    WMJopt -= CInt(smhtotal * 0.05)
        '    'WMJcredit += CInt(smhtotal * 0.05)
        'End If


        wmjnc2_Debug.Text += "<tr align=left><td>SUB TOTAL 3</td><td> $" & CInt(smhtotalnc2) & " </td></tr> "
        If dd_rep_wmjnc2.SelectedValue = "Yes" Then
            Dim contrepnc2 As String
            If CInt(txt_pp_wmjnc2.Text) > CInt(MHValuelbl.Text * 0.7) Then
                'txt_pp_wmjnc2_Amount.Text = ds.Tables("tbl1").Rows(0).Item("PProperty").ToString().Replace("$", "") * (txt_pp_wmj1.Text / 100)
                'txt_pp_wmjnc2_Amount.Text = CInt(MHValuelbl.Text * 0.5)
                txt_pp_wmjnc2_Amount.Text = ((CInt(txt_pp_wmjnc2.Text) - CInt(MHValuelbl.Text * 0.5)) / 1000) * 5
                WMJoptnc2 += txt_pp_wmjnc2_Amount.Text
                wmjnc2_Debug.Text += "<tr align=left><td>Contents </td><td> $" & txt_pp_wmjnc2_Amount.Text & " </td></tr> "
            Else
                txt_pp_wmjnc2.Text = CInt(MHValuelbl.Text * 0.7)
                txt_pp_wmjnc2_Amount.Text = ((CInt(txt_pp_wmjnc2.Text) - CInt(MHValuelbl.Text * 0.5)) / 1000) * 5
                WMJoptnc2 += txt_pp_wmjnc2_Amount.Text
                wmjnc2_Debug.Text += "<tr align=left><td>Contents </td><td> $" & txt_pp_wmjnc2_Amount.Text & " </td></tr> "


            End If




            contrepnc2 = (CInt(smhpremnc2) + CInt(txt_pp_wmjnc2_Amount.Text)) * 0.05


            If contrepnc2 < 20 Then
                contrepnc2 = "20"
            Else
                contrepnc2 = CInt(contrepnc2)

            End If


            wmjnc2_Debug.Text += "<tr align=left><td>Contents Replacement</td><td> $" & contrepnc2 & " </td></tr> "
            dd_rep_wmjnc2_Amount.Text = CInt(contrepnc2)
            WMJoptnc2 += CInt(contrepnc2)
            smhtotalnc2 += CInt(contrepnc2)
        Else
            If txt_pp_wmjnc2.Text = CInt(MHValuelbl.Text * 0.7) Then
                txt_pp_wmjnc2.Text = CInt(MHValuelbl.Text * 0.5)

            End If
            dd_rep_wmjnc2_Amount.Text = "0.00"
        End If
        'Dim age As Integer = 0
        If IsNumeric(mhyearlbl.Text) Then
            age = Now.Year - CInt(mhyearlbl.Text)
        End If
        'If age > 15 Then
        '    dd_sip_wmjnc2.Enabled = False
        '    dd_sip_wmjnc2.SelectedValue = "No"
        'Else
        '    dd_sip_wmjnc2.Enabled = True

        'End If
        'If dd_sip_wmjnc2.SelectedValue = "Yes" Then
        '    If age < 16 Then
        '        wmjnc2_Debug.Text += "<tr align=left><td>Full Repair</td><td> $10 </td></tr> "
        '        WMJoptnc2 += 10
        '        smhtotalnc2 += 10
        '        dd_sip_wmjnc2_Amount.Text = "10"
        '    Else
        '        dd_sip_wmjnc2_Amount.Text = "0.00"
        '    End If


        'End If
        If spi_cbo_nc2.SelectedValue = "Yes" Then
            wmjnc2_Debug.Text += "<tr align=left><td>Secured Party's Interest</td><td> $10 </td></tr> "
            WMJoptnc2 += 10
            smhtotalnc2 += 10
            spi_nc2_amount.Text = "10"
        Else
            spi_nc2_amount.Text = "0.00"

        End If
        wmjnc2_Debug.Text += "<tr align=left><td>Scheduled Personal Property:</td><td> $" & wmjppprem_nc2.Text & " </td></tr> "
        smhtotalnc2 += CDec(wmjppprem_nc2.Text)
        WMJoptnc2 += CDec(wmjppprem_nc2.Text)
        'WMJ_fees2.Text = "$" & CInt(ds.Tables("tbl1").Rows(0).Item("Fee").ToString())
        'WMJ_Debug.Text += "<tr align=left><td>Policy Fee</td><td> $" & CInt(ds.Tables("tbl1").Rows(0).Item("Fee").ToString()) & " </td></tr> "
        'smhtotal += CInt(ds.Tables("tbl1").Rows(0).Item("Fee").ToString())


        If dd_addresOpt_wmjnc2.SelectedValue = "1 Family" Then
            If dd_addresliab_wmjnc2.SelectedValue = "$0" Then
                dd_addresliab_wmjnc2.SelectedValue = "$50,000"
            End If
            If dd_addresliab_wmjnc2.SelectedValue = "$50,000" Then
                addres_liab_wmjnc2_amount.Text = "8"
                WMJoptnc2 += 8
                smhtotalnc2 += 8
                wmjnc2_Debug.Text += "<tr align=left><td>Additional Residence Premises Liability</td><td> $8.00  </td></tr> "
            End If
            If dd_addresliab_wmjnc2.SelectedValue = "$100,000" Then
                addres_liab_wmjnc2_amount.Text = "9"
                WMJoptnc2 += 9
                smhtotalnc2 += 9
                wmjnc2_Debug.Text += "<tr align=left><td>Additional Residence Premises Liability</td><td> $9.00  </td></tr> "
            End If
            If dd_addresliab_wmjnc2.SelectedValue = "$300,000" Then
                addres_liab_wmjnc2_amount.Text = "11"
                WMJoptnc2 += 11
                smhtotalnc2 += 11
                wmjnc2_Debug.Text += "<tr align=left><td>Additional Residence Premises Liability</td><td> $11.00  </td></tr> "
            End If

        End If
        If dd_addresOpt_wmjnc2.SelectedValue = "2 Family" Then
            If dd_addresliab_wmjnc2.SelectedValue = "$0" Then
                dd_addresliab_wmjnc2.SelectedValue = "$50,000"
            End If
            If dd_addresliab_wmjnc2.SelectedValue = "$50,000" Then
                addres_liab_wmjnc2_amount.Text = "10"
                WMJoptnc2 += 10
                smhtotalnc2 += 10
                wmjnc2_Debug.Text += "<tr align=left><td>Additional Residence Premises Liability</td><td> $10.00  </td></tr> "
            End If
            If dd_addresliab_wmjnc2.SelectedValue = "$100,000" Then
                addres_liab_wmjnc2_amount.Text = "11"
                WMJoptnc2 += 11
                smhtotalnc2 += 11
                wmjnc2_Debug.Text += "<tr align=left><td>Additional Residence Premises Liability</td><td> $11.00  </td></tr> "
            End If
            If dd_addresliab_wmjnc2.SelectedValue = "$300,000" Then
                addres_liab_wmjnc2_amount.Text = "13"
                WMJoptnc2 += 13
                smhtotalnc2 += 13
                wmjnc2_Debug.Text += "<tr align=left><td>Additional Residence Premises Liability</td><td> $13.00  </td></tr> "
            End If

        End If


        wmjnc2_Debug.Text += "<tr align=left><td>SUB TOTAL 4</td><td> $" & smhtotalnc2 & " </td></tr> "
        wmj_totalnc2.Text = smhtotalnc2.ToString("C2")



        'If lienlbl.Text = "No" Then
        '    wmj_Debug.Text += "<tr align=left><td>No Lien</td><td> ($15) </td></tr> "
        '    WMJpackcramtlbl.Text = "($15)"
        '    smhtotal -= 15
        'End If
        wmjnc2_Debug.Text += "<tr align=left><td>SUB TOTAL 5</td><td> $" & smhtotalnc2 & " </td></tr> "
        ' '' ''If DropDownList1.SelectedValue() = "Yes" Then
        ' '' ''    WMJsatprem.Text = "5"
        ' '' ''    WMJopt += 5
        ' '' ''Else
        ' '' ''    WMJsatprem.Text = "0.00"
        ' '' ''End If
        'If IsNumeric(txt_Sat_value.Text) Then
        '    If CInt(txt_Sat_value.Text) > 0 Then
        '        Dim sat As Integer
        '        sat = (CInt(txt_Sat_value.Text) / 100) * 5
        '        If sat < 5 Then
        '            sat = 5

        '        End If
        '        wmj_Debug.Text += "<tr align=left><td>Antenna/ Satalite Dish:</td><td> $" & sat & " </td></tr> "
        '        wmjsatprem.Text = sat
        '        WMJopt += sat
        '        smhtotal += sat
        '    End If

        'End If
        wmj_feesnc2.Text = "$0"
        'If supheatlbl.Text = "Yes" Then
        '    If (smhtotal * 0.1) < 30 Then
        '        wmj_Debug.Text += "<tr align=left><td>Supplemental Heating</td><td> $30 </td></tr> "
        '        smhtotal += 30
        '        wmj_fees2.Text = "$30"
        '    Else
        '        wmj_Debug.Text += "<tr align=left><td>Supplemental Heating</td><td> $" & CInt(smhtotal * 0.1) & "</td></tr> "
        '        wmj_fees2.Text = "$" & CInt(smhtotal * 0.1)
        '        smhtotal += CInt(smhtotal * 0.1)

        '    End If
        'End If
        wmj_optionsnc2.Text = "$" & WMJoptnc2
        wmjnc2_Debug.Text += "<tr align=left><td>Total Prem</td><td> $" & CDbl(smhtotalnc2) & " </td></tr> "
        'WMJ_options2.Text = CInt(ds.Tables("tbl1").Rows(0).Item("AOP").ToString().Replace("$", "")) + CInt(ds.Tables("tbl1").Rows(0).Item("Liab").ToString()) + CInt(ds.Tables("tbl1").Rows(0).Item("ContRep").ToString()) + CInt(ds.Tables("tbl1").Rows(0).Item("Enhance").ToString())
        'WMJ_total2.Text = String.Format("{0:C}", CInt(SC08_baseprem.Text) + CInt(SC08_options.Text) + CDbl(SC08_fees.Text) + CDbl(SC08_tax.Text))
        wmj_totalnc2.Text = smhtotalnc2.ToString("C2")
        wmjnc2_Debug.Text += "</tbody></table>"







        wmj_mh_prognc2.Visible = True
        wmj_mh_prognc2_Options.Visible = True


        ''=========================End NC 2=====================================
        ''===========================NC 3=======================================
        If ds.Tables("tbl1").Rows(0).Item("PML200Less5P").ToString().Replace("$", "") = "" Or UCase(mhcountylbl.Text) = UCase("Franklin") Or UCase(mhcountylbl.Text) = UCase("Granville") Or UCase(mhcountylbl.Text) = UCase("Harnett") Or UCase(mhcountylbl.Text) = UCase("Hoke") Or UCase(mhcountylbl.Text) = UCase("Richmond") Or UCase(mhcountylbl.Text) = UCase("Scotland") Or UCase(mhcountylbl.Text) = UCase("Vance") Or UCase(mhcountylbl.Text) = UCase("Wake") Or UCase(mhcountylbl.Text) = UCase("Warren") Then
            wmj_mh_prognc3.Visible = False
            wmj_mh_prognc3_Options.Visible = False
        Else
            If mhmfglbl.Text = "Adrian" Or mhmfglbl.Text = "Commodore" Or mhmfglbl.Text = "Crestline" Or mhmfglbl.Text = "Friendship" Or mhmfglbl.Text = "Mansion" Or mhmfglbl.Text = "Mascot" Or mhmfglbl.Text = "Palm Harbor" Or mhmfglbl.Text = "R-Nell" Or mhmfglbl.Text = "Virginia" Then


                wmj_mh_prognc3.Visible = True
                wmj_mh_prognc3_Options.Visible = True
                Dim smhpremnc3 As String
                Dim smhasnc3 As String
                Dim smhconnc3 As String
                Dim WMJoptnc3 As String

                Dim smhtotalnc3 As Decimal



                dd_mp_wmjnc3.SelectedValue = "$1000"

                wmj_medpaync3.Text = dd_mp_wmjnc3.SelectedValue()

                wmjlossofusenc3.Text = CInt(MHValuelbl.Text * 0.1)


                wmjnc3_Debug.Text = "<table> <tbody>"
                wmj_dwellnc3.Text = "$" & mhvalue.Replace("$", "")
                wmj_unattStrnc3.Text = "$" & txt_unattstr_wmjnc3.Text.Replace("$", "")
                wmj_perEffnc3.Text = "$" & txt_pp_wmjnc3.Text.Replace("$", "")
                wmj_perLiabnc3.Text = "$" & dd_pl_wmjnc3.SelectedValue().Replace("$", "")
                wmj_medpaync3.Text = "$" & wmj_medpaync3.Text.Replace("$", "")

                If Date.Now.Year - mhyearlbl.Text <= 5 Then
                    If protection.Text <= 8 Then
                        smhpremnc3 = "$" & ds.Tables("tbl1").Rows(0).Item("PML200Less5UP").ToString().Replace("$", "")
                    ElseIf protection.Text > 8 And protection.Text <= 9 Then

                        smhpremnc3 = "$" & ds.Tables("tbl1").Rows(0).Item("PML200Less5P").ToString().Replace("$", "")

                    End If
                ElseIf Date.Now.Year - mhyearlbl.Text <= 11 Then

                    If protection.Text <= 8 Then
                        smhpremnc3 = "$" & ds.Tables("tbl1").Rows(0).Item("PML200More5UP").ToString().Replace("$", "")
                    ElseIf protection.Text > 8 And protection.Text <= 9 Then

                        smhpremnc3 = "$" & ds.Tables("tbl1").Rows(0).Item("PML200More5P").ToString().Replace("$", "")

                    End If

                Else
                    wmj_mh_prognc3.Visible = False
                    wmj_mh_prognc3_Options.Visible = False
                End If



                wmjnc3_Debug.Text += "<tr align=left><td>Package Premium </td><td> $" & CInt(smhpremnc3) & " </td></tr> "
                WMJpackpremlblnc3.Text = CInt(smhpremnc3)

                'if first run or now value, then fill in fields
                If IsNumeric(txt_unattstr_wmjnc3.Text) And txt_unattstr_wmjnc3.Text <> "0.00" Then
                    If CInt(txt_unattstr_wmjnc3.Text) > CInt(MHValuelbl.Text * 0.1) Then
                        ' txt_unattstr_wmjnc3_Amount.Text = ds.Tables("tbl1").Rows(0).Item("Astructurerate").ToString().Replace("$", "") * (txt_unattstr_wmj1.Text / 100)
                        txt_unattstr_wmjnc3_Amount.Text = ((CInt(txt_unattstr_wmjnc3.Text) - CInt(MHValuelbl.Text * 0.1)) / 1000) * 4
                        WMJoptnc3 += CInt(txt_unattstr_wmjnc3_Amount.Text)
                        wmjnc3_Debug.Text += "<tr align=left><td>Other Structures </td><td> $" & txt_unattstr_wmjnc3_Amount.Text & " </td></tr> "
                    Else
                        txt_unattstr_wmjnc3_Amount.Text = "0.00"
                        wmjnc3_Debug.Text += "<tr align=left><td>Other Structures </td><td> $0.00 </td></tr> "
                    End If
                Else
                    txt_unattstr_wmjnc3.Text = CInt(MHValuelbl.Text * 0.1)
                End If
                If IsNumeric(txt_pp_wmjnc3.Text) And txt_pp_wmjnc3.Text <> "0.00" Then
                    If CInt(txt_pp_wmjnc3.Text) > CInt(MHValuelbl.Text * 0.5) Then
                        'txt_pp_wmjnc3_Amount.Text = ds.Tables("tbl1").Rows(0).Item("PProperty").ToString().Replace("$", "") * (txt_pp_wmj1.Text / 100)
                        txt_pp_wmjnc3_Amount.Text = ((CInt(txt_pp_wmjnc3.Text) - CInt(MHValuelbl.Text * 0.5)) / 1000) * 5
                        WMJoptnc3 += CInt(txt_pp_wmjnc3_Amount.Text)
                        wmjnc3_Debug.Text += "<tr align=left><td>Contents </td><td> $" & txt_pp_wmjnc3_Amount.Text & " </td></tr> "
                    Else
                        txt_pp_wmjnc3_Amount.Text = "0.00"
                        wmjnc3_Debug.Text += "<tr align=left><td>Contents </td><td> $0.00 </td></tr> "
                    End If
                Else
                    txt_pp_wmjnc3.Text = CInt(MHValuelbl.Text * 0.5)
                End If

                ' ''If CInt(txt_unattstr_wmjnc3.Text) > CInt(MHValuelbl.Text * 0.01) Then
                ' ''    WMJoptnc3 += CInt(CInt(txt_unattstr_wmjnc3.Text) - CInt(MHValuelbl.Text * 0.01) / 1000) * 4
                ' ''    wmjnc3_Debug.Text += "<tr align=left><td>Other Structures </td><td> $" & CInt(CInt(txt_unattstr_wmjnc3.Text) - CInt(MHValuelbl.Text * 0.01) / 1000) * 4 & " </td></tr> "
                ' ''    txt_unattstr_wmjnc3_Amount.Text = CInt(CInt(txt_unattstr_wmjnc3.Text) - CInt(MHValuelbl.Text * 0.01) / 1000) * 4
                ' ''    '' txt_unattstr_wmj1_Amount.Text = CInt(ds.Tables("tbl1").Rows(0).Item("OtherStructure").ToString().Replace("$", ""))
                ' ''    ''WMJopt += CInt(txt_unattstr_wmj1.Text = ds.Tables("tbl1").Rows(0).Item("Astructurerate").ToString().Replace("$", "") * (txt_unattstr_wmj1.Text / 100))
                ' ''Else
                ' ''    wmjnc3_Debug.Text += "<tr align=left><td>Other Structures </td><td> $0.00 </td></tr> "
                ' ''    '' txt_unattstr_wmj1_Amount.Text = CInt(ds.Tables("tbl1").Rows(0).Item("OtherStructure").ToString().Replace("$", ""))
                ' ''    WMJoptnc3 += 0
                ' ''    txt_unattstr_wmjnc3_Amount.Text = "0.00"
                ' ''End If

                ' ''If CInt(txt_pp_wmj1.Text) > CInt(MHValuelbl.Text * 0.05) Then
                ' ''    WMJoptnc3 += CInt(CInt(txt_pp_wmj1.Text) - CInt(MHValuelbl.Text * 0.05) / 1000) * 5
                ' ''    wmjnc3_Debug.Text += "<tr align=left><td>Contents </td><td> $" & CInt(CInt(txt_pp_wmj1.Text) - CInt(MHValuelbl.Text * 0.05) / 1000) * 5 & " </td></tr> "
                ' ''    txt_pp_wmjnc3_Amount.Text = CInt(CInt(txt_pp_wmj1.Text) - CInt(MHValuelbl.Text * 0.05) / 1000) * 5
                ' ''    'WMJopt += CInt(ds.Tables("tbl1").Rows(0).Item("PProperty").ToString().Replace("$", "") * (txt_pp_wmj1.Text / 100))
                ' ''Else
                ' ''    wmjnc3_Debug.Text += "<tr align=left><td>Contents </td><td> $0.00 </td></tr> "
                ' ''    txt_pp_wmjnc3_Amount.Text = "0.00"
                ' ''    WMJoptnc3 += 0
                ' ''End If
                'wmj_Debug.Text += "<tr align=left><td>Other Structures </td><td> $" & CInt(txt_unattstr_wmj1.Text = ds.Tables("tbl1").Rows(0).Item("Astructurerate").ToString().Replace("$", "") * (txt_unattstr_wmj1.Text / 100)) & " </td></tr> "
                ' '' txt_unattstr_wmj1_Amount.Text = CInt(ds.Tables("tbl1").Rows(0).Item("OtherStructure").ToString().Replace("$", ""))
                'WMJopt += CInt(txt_unattstr_wmj1.Text = ds.Tables("tbl1").Rows(0).Item("Astructurerate").ToString().Replace("$", "") * (txt_unattstr_wmj1.Text / 100))
                'wmj_Debug.Text += "<tr align=left><td>Contents </td><td> $" & CInt(ds.Tables("tbl1").Rows(0).Item("PProperty").ToString().Replace("$", "") * (txt_pp_wmj1.Text / 100)) & " </td></tr> "
                ''txt_pp_WMJ2_Amount.Text = CInt(ds.Tables("tbl1").Rows(0).Item("Contents").ToString().Replace("$", ""))
                'WMJopt += CInt(ds.Tables("tbl1").Rows(0).Item("PProperty").ToString().Replace("$", "") * (txt_pp_wmj1.Text / 100))
                'wmj_Debug.Text += "<tr align=left><td>Addl Living Expense</td><td> $" & CInt("0") & " </td></tr> "
                'txt_unattstr_WMJ1_Amount.Text = Math.Ceiling(CDbl(ds.Tables("tbl1").Rows(0).Item("OtherStructure").ToString().Replace("$", "")))
                'txt_pp_WMJ1_Amount.Text = Math.Ceiling(CDbl(ds.Tables("tbl1").Rows(0).Item("Contents").ToString().Replace("$", "")))


                ' smhtotal = CInt(smhprem) + Math.Ceiling(CDbl(ds.Tables("tbl1").Rows(0).Item("Astructurerate").ToString().Replace("$", "") * (txt_unattstr_wmj1.Text / 100))) + Math.Ceiling(CDbl(ds.Tables("tbl1").Rows(0).Item("PProperty").ToString().Replace("$", "") * (txt_pp_wmj1.Text / 100)))
                smhtotalnc3 = CInt(smhpremnc3) + CInt(txt_unattstr_wmjnc3_Amount.Text) + CInt(txt_pp_wmjnc3_Amount.Text)
                wmjnc3_Debug.Text += "<tr align=left><td>Sub Premium</td><td> $" & CInt(smhtotalnc3) & " </td></tr> "
                'Dim CreditsPercentage As Decimal
                ''Add credit stuff to label
                'CreditsPercentage = ds.Tables("tbl1").Rows(0).Item("Credit").ToString().Replace("$", "")
                'WMJ_Debug.Text += "<tr align=left><td> Credits %</td><td> " & CreditsPercentage * 100 & "% </td></tr> "
                'WMJ_Debug.Text += "<tr align=left><td> Credits Value</td><td>-" & Math.Round((smhtotal * CreditsPercentage), 0, MidpointRounding.AwayFromZero) & " </td></tr> "
                'smhtotal -= Math.Round((smhtotal * CreditsPercentage), 0, MidpointRounding.AwayFromZero)
                If dd_aop_wmjnc3.SelectedValue = "$1000" Then
                    Dim CreditsPercentage As Decimal
                    CreditsPercentage = 0.096
                    wmjnc3_Debug.Text += "<tr align=left><td> Credits %</td><td> " & CreditsPercentage * 100 & "% </td></tr> "
                    wmjnc3_Debug.Text += "<tr align=left><td> Credits Value</td><td>-" & Math.Round((smhpremnc3 * CreditsPercentage), 0, MidpointRounding.AwayFromZero) & " </td></tr> "
                    smhtotalnc3 -= Math.Round((smhpremnc3 * CreditsPercentage), 0, MidpointRounding.AwayFromZero)
                    WMJpackperclblnc3.Text = "0.096"
                    WMJpackcramtlblnc3.Text = Math.Round((smhpremnc3 * CreditsPercentage), 0, MidpointRounding.AwayFromZero)
                    dd_aop_wmjnc3_Amount.Text = "(" & Math.Round((smhpremnc3 * CreditsPercentage), 0, MidpointRounding.AwayFromZero) & ")"
                End If
                wmj_basepremnc3.Text = "$" & CInt(smhtotalnc3)
                wmjnc3_Debug.Text += "<tr align=left><td>Base Premium</td><td> $" & CInt(smhtotalnc3) & " </td></tr> "
                'WMJpackpremlbl.Text = CInt(smhtotal)
                If dd_pl_wmjnc3.SelectedItem.Text = "$50,000" Then
                    wmjnc3_Debug.Text += "<tr align=left><td>Personal Liability</td><td> $0.00  </td></tr> "
                    dd_pl_wmjnc3_Amount.Text = CInt("0.00")

                ElseIf dd_pl_wmjnc3.SelectedItem.Text = "$100,000" Then
                    wmjnc3_Debug.Text += "<tr align=left><td>Personal Liability</td><td> $1.00  </td></tr> "
                    dd_pl_wmjnc3_Amount.Text = CInt("1.00")
                    smhtotalnc3 += CInt("1.00")
                ElseIf dd_pl_wmjnc3.SelectedItem.Text = "$300,000" Then
                    wmjnc3_Debug.Text += "<tr align=left><td>Personal Liability</td><td> $5.00  </td></tr> "
                    dd_pl_wmjnc3_Amount.Text = CInt("5.00")
                    smhtotalnc3 += CInt("5.00")
                End If


                wmjnc3_Debug.Text += "<tr align=left><td>Medical Payment</td><td> $ 0  </td></tr> "
                WMJpackperclbl.Text = "0"
                WMJpackcramtlbl.Text = "0"
                ' Dim WMJcredit As Decimal

                wmjnc3_Debug.Text += "<tr align=left><td>SUB TOTAL 2</td><td> $" & CInt(smhtotalnc3) & " </td></tr> "
                'If dd_aop_wmj1.SelectedValue = "$500" Then
                '    wmj_Debug.Text += "<tr align=left><td>AOP</td><td> $0 </td></tr> "
                '    dd_aop_wmj1_Amount.Text = "0.00"
                '    'dd_aop_08_Amount.Text = ds.Tables("tbl1").Rows(0).Item("AOP").ToString().Replace("$", "")
                '    ' smhtotal += CInt(ds.Tables("tbl1").Rows(0).Item("AOP").ToString().Replace("$", ""))
                'Else
                '    wmj_Debug.Text += "<tr align=left><td>AOP</td><td> ( $" & CInt(smhtotal * 0.05) & " )</td></tr> "
                '    'dd_aop_08_Amount.Text = ds.Tables("tbl1").Rows(0).Item("AOP").ToString().Replace("$", "")
                '    dd_aop_wmj1_Amount.Text = "(" & CInt(smhtotal * 0.05) & ")"
                '    smhtotal -= CInt(smhtotal * 0.05)
                '    WMJopt -= CInt(smhtotal * 0.05)
                '    'WMJcredit += CInt(smhtotal * 0.05)
                'End If


                wmjnc3_Debug.Text += "<tr align=left><td>SUB TOTAL 3</td><td> $" & CInt(smhtotalnc3) & " </td></tr> "
                If dd_rep_wmjnc3.SelectedValue = "Yes" Then
                    Dim contrepnc3 As String
                    If CInt(txt_pp_wmjnc3.Text) > CInt(MHValuelbl.Text * 0.7) Then
                        'txt_pp_wmjnc3_Amount.Text = ds.Tables("tbl1").Rows(0).Item("PProperty").ToString().Replace("$", "") * (txt_pp_wmj1.Text / 100)
                        'txt_pp_wmjnc3_Amount.Text = CInt(MHValuelbl.Text * 0.5)
                        txt_pp_wmjnc3_Amount.Text = ((CInt(txt_pp_wmjnc3.Text) - CInt(MHValuelbl.Text * 0.5)) / 1000) * 5
                        WMJoptnc3 += CInt(txt_pp_wmjnc3_Amount.Text)
                        wmjnc3_Debug.Text += "<tr align=left><td>Contents </td><td> $" & txt_pp_wmjnc3_Amount.Text & " </td></tr> "
                    Else
                        txt_pp_wmjnc3.Text = CInt(MHValuelbl.Text * 0.7)
                        txt_pp_wmjnc3_Amount.Text = ((CInt(txt_pp_wmjnc3.Text) - CInt(MHValuelbl.Text * 0.5)) / 1000) * 5
                        WMJoptnc3 += CInt(txt_pp_wmjnc3_Amount.Text)
                        wmjnc3_Debug.Text += "<tr align=left><td>Contents </td><td> $" & txt_pp_wmjnc3_Amount.Text & " </td></tr> "


                    End If




                    contrepnc3 = (CInt(smhpremnc3) + CInt(txt_pp_wmjnc3_Amount.Text)) * 0.05


                    If contrepnc3 < 20 Then
                        contrepnc3 = "20"
                    Else
                        contrepnc3 = CInt(contrepnc3)

                    End If


                    wmjnc3_Debug.Text += "<tr align=left><td>Contents Replacement</td><td> $" & contrepnc3 & " </td></tr> "
                    dd_rep_wmjnc3_Amount.Text = CInt(contrepnc3)
                    WMJoptnc3 += CInt(contrepnc3)
                    smhtotalnc3 += CInt(contrepnc3)
                Else
                    If txt_pp_wmjnc3.Text = CInt(MHValuelbl.Text * 0.7) Then
                        txt_pp_wmjnc3.Text = CInt(MHValuelbl.Text * 0.5)

                    End If
                    dd_rep_wmjnc3_Amount.Text = "0.00"
                End If
                'Dim age As Integer = 0
                If IsNumeric(mhyearlbl.Text) Then
                    age = Now.Year - CInt(mhyearlbl.Text)
                End If
                'If age > 15 Then
                '    dd_sip_wmj3.Enabled = False
                '    dd_sip_wmj3.SelectedValue = "No"
                'Else
                '    dd_sip_wmj3.Enabled = True

                'End If
                'If dd_sip_wmj3.SelectedValue = "Yes" Then
                '    If age < 16 Then
                '        wmjnc3_Debug.Text += "<tr align=left><td>Full Repair</td><td> $10 </td></tr> "
                '        WMJoptnc3 += 10
                '        smhtotalnc3 += 10
                '        dd_sip_wmjnc3_Amount.Text = "10"
                '    Else
                '        dd_sip_wmjnc3_Amount.Text = "0.00"
                '    End If


                'End If
                If spi_cbo_nc3.SelectedValue = "Yes" Then
                    wmjnc3_Debug.Text += "<tr align=left><td>Secured Party's Interest</td><td> $10 </td></tr> "
                    WMJoptnc3 += 10
                    smhtotalnc3 += 10
                    spi_nc3_amount.Text = "10"
                Else
                    spi_nc3_amount.Text = "0.00"

                End If
                wmjnc3_Debug.Text += "<tr align=left><td>Scheduled Personal Property:</td><td> $" & wmjppprem_nc3.Text & " </td></tr> "
                smhtotalnc3 += CDec(wmjppprem_nc3.Text)
                WMJoptnc3 += CDec(wmjppprem_nc3.Text)
                'WMJ_fees2.Text = "$" & CInt(ds.Tables("tbl1").Rows(0).Item("Fee").ToString())
                'WMJ_Debug.Text += "<tr align=left><td>Policy Fee</td><td> $" & CInt(ds.Tables("tbl1").Rows(0).Item("Fee").ToString()) & " </td></tr> "
                'smhtotal += CInt(ds.Tables("tbl1").Rows(0).Item("Fee").ToString())


                If dd_addresOpt_wmjnc3.SelectedValue = "1 Family" Then
                    If dd_addresliab_wmjnc3.SelectedValue = "$0" Then
                        dd_addresliab_wmjnc3.SelectedValue = "$50,000"
                    End If
                    If dd_addresliab_wmjnc3.SelectedValue = "$50,000" Then
                        addres_liab_wmjnc3_amount.Text = "8"
                        WMJoptnc3 += 8
                        smhtotalnc3 += 8
                        wmjnc3_Debug.Text += "<tr align=left><td>Additional Residence Premises Liability</td><td> $8.00  </td></tr> "
                    End If
                    If dd_addresliab_wmjnc3.SelectedValue = "$100,000" Then
                        addres_liab_wmjnc3_amount.Text = "9"
                        WMJoptnc3 += 9
                        smhtotalnc3 += 9
                        wmjnc3_Debug.Text += "<tr align=left><td>Additional Residence Premises Liability</td><td> $9.00  </td></tr> "
                    End If
                    If dd_addresliab_wmjnc3.SelectedValue = "$300,000" Then
                        addres_liab_wmjnc3_amount.Text = "11"
                        WMJoptnc3 += 11
                        smhtotalnc3 += 11
                        wmjnc3_Debug.Text += "<tr align=left><td>Additional Residence Premises Liability</td><td> $11.00  </td></tr> "
                    End If

                End If
                If dd_addresOpt_wmjnc3.SelectedValue = "2 Family" Then
                    If dd_addresliab_wmjnc3.SelectedValue = "$0" Then
                        dd_addresliab_wmjnc3.SelectedValue = "$50,000"
                    End If
                    If dd_addresliab_wmjnc3.SelectedValue = "$50,000" Then
                        addres_liab_wmjnc3_amount.Text = "10"
                        WMJoptnc3 += 10
                        smhtotalnc3 += 10
                        wmjnc3_Debug.Text += "<tr align=left><td>Additional Residence Premises Liability</td><td> $10.00  </td></tr> "
                    End If
                    If dd_addresliab_wmjnc3.SelectedValue = "$100,000" Then
                        addres_liab_wmjnc3_amount.Text = "11"
                        WMJoptnc3 += 11
                        smhtotalnc3 += 11
                        wmjnc3_Debug.Text += "<tr align=left><td>Additional Residence Premises Liability</td><td> $11.00  </td></tr> "
                    End If
                    If dd_addresliab_wmjnc3.SelectedValue = "$300,000" Then
                        addres_liab_wmjnc3_amount.Text = "13"
                        WMJoptnc3 += 13
                        smhtotalnc3 += 13
                        wmjnc3_Debug.Text += "<tr align=left><td>Additional Residence Premises Liability</td><td> $13.00  </td></tr> "
                    End If

                End If


                wmjnc3_Debug.Text += "<tr align=left><td>SUB TOTAL 4</td><td> $" & smhtotalnc3 & " </td></tr> "
                wmj_totalnc3.Text = smhtotalnc3.ToString("C2")



                'If lienlbl.Text = "No" Then
                '    wmj_Debug.Text += "<tr align=left><td>No Lien</td><td> ($15) </td></tr> "
                '    WMJpackcramtlbl.Text = "($15)"
                '    smhtotal -= 15
                'End If
                wmjnc3_Debug.Text += "<tr align=left><td>SUB TOTAL 5</td><td> $" & smhtotalnc3 & " </td></tr> "
                ' '' ''If DropDownList1.SelectedValue() = "Yes" Then
                ' '' ''    WMJsatprem.Text = "5"
                ' '' ''    WMJopt += 5
                ' '' ''Else
                ' '' ''    WMJsatprem.Text = "0.00"
                ' '' ''End If
                'If IsNumeric(txt_Sat_value.Text) Then
                '    If CInt(txt_Sat_value.Text) > 0 Then
                '        Dim sat As Integer
                '        sat = (CInt(txt_Sat_value.Text) / 100) * 5
                '        If sat < 5 Then
                '            sat = 5

                '        End If
                '        wmj_Debug.Text += "<tr align=left><td>Antenna/ Satalite Dish:</td><td> $" & sat & " </td></tr> "
                '        wmjsatprem.Text = sat
                '        WMJopt += sat
                '        smhtotal += sat
                '    End If

                'End If
                wmj_feesnc3.Text = "$0"
                'If supheatlbl.Text = "Yes" Then
                '    If (smhtotal * 0.1) < 30 Then
                '        wmj_Debug.Text += "<tr align=left><td>Supplemental Heating</td><td> $30 </td></tr> "
                '        smhtotal += 30
                '        wmj_fees2.Text = "$30"
                '    Else
                '        wmj_Debug.Text += "<tr align=left><td>Supplemental Heating</td><td> $" & CInt(smhtotal * 0.1) & "</td></tr> "
                '        wmj_fees2.Text = "$" & CInt(smhtotal * 0.1)
                '        smhtotal += CInt(smhtotal * 0.1)

                '    End If
                'End If
                wmj_optionsnc3.Text = "$" & WMJoptnc3
                wmjnc3_Debug.Text += "<tr align=left><td>Total Prem</td><td> $" & CDbl(smhtotalnc3) & " </td></tr> "
                'WMJ_options2.Text = CInt(ds.Tables("tbl1").Rows(0).Item("AOP").ToString().Replace("$", "")) + CInt(ds.Tables("tbl1").Rows(0).Item("Liab").ToString()) + CInt(ds.Tables("tbl1").Rows(0).Item("ContRep").ToString()) + CInt(ds.Tables("tbl1").Rows(0).Item("Enhance").ToString())
                'WMJ_total2.Text = String.Format("{0:C}", CInt(SC08_baseprem.Text) + CInt(SC08_options.Text) + CDbl(SC08_fees.Text) + CDbl(SC08_tax.Text))
                wmj_totalnc3.Text = smhtotalnc3.ToString("C2")
                wmjnc3_Debug.Text += "</tbody></table>"



            Else
                wmj_mh_prognc3.Visible = False
                wmj_mh_prognc3_Options.Visible = False

            End If


        End If

        ''=========================End NC 3=====================================



        AR_PremiumUpdatePanel.Update()


    End Sub

    Private Sub wmjPPGrid_nc1_RowDeleting(sender As Object, e As DevExpress.Web.Data.ASPxDataDeletingEventArgs) Handles wmjPPGrid_nc1.RowDeleting
        Dim i As Integer = wmjPPGrid_nc1.FindVisibleIndexByKeyValue(e.Keys(wmjPPGrid_nc1.KeyFieldName))
        '  Dim c As Control = ASPxGridView1.FindDetailRowTemplateControl(i, "ASPxGridView2")
        i = wmjPPGrid_nc1.GetRowValues(wmjPPGrid_nc1.FocusedRowIndex, "WMJppID")
        e.Cancel = True
        Dim Connection As String = System.Configuration.ConfigurationManager.ConnectionStrings("ColonialMHConnectionString").ConnectionString
        Dim dbConnection As System.Data.IDbConnection = New System.Data.SqlClient.SqlConnection(Connection)
        Dim cmd As New SqlCommand("sp_wmjDeletePP", dbConnection)
        cmd.CommandType = CommandType.StoredProcedure
        cmd.Parameters.Add("@PPID", SqlDbType.VarChar, 8000).Value = i

        Try
            Dim ds As Data.DataSet = New Data.DataSet

            cmd.Connection.Open()
            ' intRowsAff = cmd.ExecuteNonQuery()

            Dim myCommand = New SqlDataAdapter(cmd)
            myCommand.Fill(ds, "tbl1")
        Catch ex As Exception
            Dim s As String = ""
            For Each param As SqlParameter In cmd.Parameters
                s += param.ParameterName & "="
                s += param.Value & ":  "

            Next
            errortrap("deleting pp wmj Data " & s, "Save Prem", ex.Message)
        End Try
        loadWMJPP()
    End Sub

    Private Sub wmjPPGrid_nc2_RowDeleting(sender As Object, e As DevExpress.Web.Data.ASPxDataDeletingEventArgs) Handles wmjPPGrid_nc2.RowDeleting
        Dim i As Integer = wmjPPGrid_nc2.FindVisibleIndexByKeyValue(e.Keys(wmjPPGrid_nc2.KeyFieldName))
        '  Dim c As Control = ASPxGridView1.FindDetailRowTemplateControl(i, "ASPxGridView2")
        i = wmjPPGrid_nc2.GetRowValues(wmjPPGrid_nc2.FocusedRowIndex, "WMJppID")
        e.Cancel = True
        Dim Connection As String = System.Configuration.ConfigurationManager.ConnectionStrings("ColonialMHConnectionString").ConnectionString
        Dim dbConnection As System.Data.IDbConnection = New System.Data.SqlClient.SqlConnection(Connection)
        Dim cmd As New SqlCommand("sp_wmjDeletePP", dbConnection)
        cmd.CommandType = CommandType.StoredProcedure
        cmd.Parameters.Add("@PPID", SqlDbType.VarChar, 8000).Value = i

        Try
            Dim ds As Data.DataSet = New Data.DataSet

            cmd.Connection.Open()
            ' intRowsAff = cmd.ExecuteNonQuery()

            Dim myCommand = New SqlDataAdapter(cmd)
            myCommand.Fill(ds, "tbl1")
        Catch ex As Exception
            Dim s As String = ""
            For Each param As SqlParameter In cmd.Parameters
                s += param.ParameterName & "="
                s += param.Value & ":  "

            Next
            errortrap("deleting pp wmj Data " & s, "Save Prem", ex.Message)
        End Try
        loadWMJPP()
    End Sub

    Private Sub wmjPPGrid_nc3_RowDeleting(sender As Object, e As DevExpress.Web.Data.ASPxDataDeletingEventArgs) Handles wmjPPGrid_nc3.RowDeleting
        Dim i As Integer = wmjPPGrid_nc3.FindVisibleIndexByKeyValue(e.Keys(wmjPPGrid_nc3.KeyFieldName))
        '  Dim c As Control = ASPxGridView1.FindDetailRowTemplateControl(i, "ASPxGridView2")
        i = wmjPPGrid_nc3.GetRowValues(wmjPPGrid_nc3.FocusedRowIndex, "WMJppID")
        e.Cancel = True
        Dim Connection As String = System.Configuration.ConfigurationManager.ConnectionStrings("ColonialMHConnectionString").ConnectionString
        Dim dbConnection As System.Data.IDbConnection = New System.Data.SqlClient.SqlConnection(Connection)
        Dim cmd As New SqlCommand("sp_wmjDeletePP", dbConnection)
        cmd.CommandType = CommandType.StoredProcedure
        cmd.Parameters.Add("@PPID", SqlDbType.VarChar, 8000).Value = i

        Try
            Dim ds As Data.DataSet = New Data.DataSet

            cmd.Connection.Open()
            ' intRowsAff = cmd.ExecuteNonQuery()

            Dim myCommand = New SqlDataAdapter(cmd)
            myCommand.Fill(ds, "tbl1")
        Catch ex As Exception
            Dim s As String = ""
            For Each param As SqlParameter In cmd.Parameters
                s += param.ParameterName & "="
                s += param.Value & ":  "

            Next
            errortrap("deleting pp wmj Data " & s, "Save Prem", ex.Message)
        End Try
        loadWMJPP()
    End Sub

    Protected Sub selectwmj1btnnc1_Click(sender As Object, e As EventArgs) Handles selectwmj_nc1btn.Click
        HiddenFieldSelected.Value = "WMJ Standard Replacement Cost"
        rateTypelbl.Text = "WMJ Standard Replacement Cost"
        rateTypelbl.Font.Bold = True
        rateTypelbl.ForeColor = Drawing.Color.Green


        'Set Selected to AR1 in database  Not saving right now...
        Try

            If quoteIDlbl.Text <> "" Then
                Me.Page.GetType.InvokeMember("updateQuote", System.Reflection.BindingFlags.InvokeMethod, Nothing, Me.Page, New Object() {quoteIDlbl.Text})
            Else
                Me.Page.GetType.InvokeMember("save", System.Reflection.BindingFlags.InvokeMethod, Nothing, Me.Page, New Object() {})

            End If
        Catch ex As Exception
            errortrap("UPDATE WMJ Standard", "Selected WMJ Standard Replacement Cost", ex.Message)
        End Try
        Dim ds As System.Data.DataSet
        ds = runQueryDS("EXEC sp_SetQuoteRateType '" & quoteIDlbl.Text & "', 'WMJ Standard Replacement Cost'", "ColonialMHConnectionString")
        'Check Financing options
        ds = runQueryDS("SELECT ARRateType, state  FROM tblQuotes WHERE quoteID ='" & quoteIDlbl.Text & "'", "ColonialMHConnectionString")
        'If ds.Tables(0).Rows.Count > 0 Then
        '    If ds.Tables(0).Rows(0).Item("state") = "SC" And Not rateTypelbl.Text.ToString.ToUpper.Contains("AEG") Then
        '        SCPremFinbtn.Visible = True
        '        calcSCFinancing()
        '    Else
        '        SCPremFinbtn.Visible = False
        '    End If
        'End If
        premiumBtnTable.Attributes.Add("style", "display:block")
    End Sub

    Protected Sub selectwmj1btnnc2_Click(sender As Object, e As EventArgs) Handles selectwmj_nc2btn.Click
        HiddenFieldSelected.Value = "WMJ Standard ACV"
        rateTypelbl.Text = "WMJ Standard ACV"
        rateTypelbl.Font.Bold = True
        rateTypelbl.ForeColor = Drawing.Color.Green


        'Set Selected to AR1 in database  Not saving right now...
        Try

            If quoteIDlbl.Text <> "" Then
                Me.Page.GetType.InvokeMember("updateQuote", System.Reflection.BindingFlags.InvokeMethod, Nothing, Me.Page, New Object() {quoteIDlbl.Text})
            Else
                Me.Page.GetType.InvokeMember("save", System.Reflection.BindingFlags.InvokeMethod, Nothing, Me.Page, New Object() {})

        End If
        Catch ex As Exception
            errortrap("UPDATE WMJ Standard", "Selected WMJ Standard ACV", ex.Message)
        End Try
        Dim ds As System.Data.DataSet
        ds = runQueryDS("EXEC sp_SetQuoteRateType '" & quoteIDlbl.Text & "', 'WMJ Standard ACV'", "ColonialMHConnectionString")
        'Check Financing options
        ds = runQueryDS("SELECT ARRateType, state  FROM tblQuotes WHERE quoteID ='" & quoteIDlbl.Text & "'", "ColonialMHConnectionString")
        'If ds.Tables(0).Rows.Count > 0 Then
        '    If ds.Tables(0).Rows(0).Item("state") = "SC" And Not rateTypelbl.Text.ToString.ToUpper.Contains("AEG") Then
        '        SCPremFinbtn.Visible = True
        '        calcSCFinancing()
        '    Else
        '        SCPremFinbtn.Visible = False
        '    End If
        'End If
        premiumBtnTable.Attributes.Add("style", "display:block")
    End Sub

    Protected Sub selectwmj1btnnc3_Click(sender As Object, e As EventArgs) Handles selectwmj_nc3btn.Click
        HiddenFieldSelected.Value = "WMJ Preferred"
        rateTypelbl.Text = "WMJ Preferred"
        rateTypelbl.Font.Bold = True
        rateTypelbl.ForeColor = Drawing.Color.Green


        'Set Selected to AR1 in database  Not saving right now...
        Try

            If quoteIDlbl.Text <> "" Then
                Me.Page.GetType.InvokeMember("updateQuote", System.Reflection.BindingFlags.InvokeMethod, Nothing, Me.Page, New Object() {quoteIDlbl.Text})
            Else
                Me.Page.GetType.InvokeMember("save", System.Reflection.BindingFlags.InvokeMethod, Nothing, Me.Page, New Object() {})

            End If
        Catch ex As Exception
            errortrap("UPDATE WMJ Standard", "Selected WMJ Preferred", ex.Message)
        End Try
        Dim ds As System.Data.DataSet
        ds = runQueryDS("EXEC sp_SetQuoteRateType '" & quoteIDlbl.Text & "', 'WMJ Preferred'", "ColonialMHConnectionString")
        'Check Financing options
        ds = runQueryDS("SELECT ARRateType, state  FROM tblQuotes WHERE quoteID ='" & quoteIDlbl.Text & "'", "ColonialMHConnectionString")
        'If ds.Tables(0).Rows.Count > 0 Then
        '    If ds.Tables(0).Rows(0).Item("state") = "SC" And Not rateTypelbl.Text.ToString.ToUpper.Contains("AEG") Then
        '        SCPremFinbtn.Visible = True
        '        calcSCFinancing()
        '    Else
        '        SCPremFinbtn.Visible = False
        '    End If
        'End If
        premiumBtnTable.Attributes.Add("style", "display:block")
    End Sub

    Protected Sub btnAddPPLwmj_nc2_Click(sender As Object, e As EventArgs) Handles btnAddPPLwmj_nc2.Click
        If IsNumeric(txtvaluePPLwmj_nc2.Text) Then
            If CDbl(txtvaluePPLwmj_nc2.Text) > 2000.0 Then
                PPError.Visible = True
                PPError.Text = "Property Value cannot Exceed $2000"
                PPError.ForeColor = Drawing.Color.Red
            Else
                If CDbl(wmjppvalue_nc2.Text) + CDbl(txtvaluePPLwmj_nc2.Text) > 10000.0 Then
                    PPError.Visible = True
                    PPError.Text = "Property Total Value cannot Exceed $10,000"
                    PPError.ForeColor = Drawing.Color.Red
                Else
                    PPError.Visible = False

                    Dim Connection As String = System.Configuration.ConfigurationManager.ConnectionStrings("ColonialMHConnectionString").ConnectionString
                    Dim dbConnection As System.Data.IDbConnection = New System.Data.SqlClient.SqlConnection(Connection)
                    Dim cmd As New SqlCommand("sp_WMJPPInsert", dbConnection)
                    cmd.CommandType = CommandType.StoredProcedure
                    cmd.Parameters.Add("@Category", SqlDbType.VarChar, 8000).Value = wmjppcatcmbo_nc2.SelectedItem.ToString
                    cmd.Parameters.Add("@Description", SqlDbType.VarChar, 8000).Value = txtPPLDescriptionwmj_nc2.Text
                    cmd.Parameters.Add("@qty", SqlDbType.VarChar, 8000).Value = txtQuantityPPlwmj_nc2.Text
                    cmd.Parameters.Add("@value", SqlDbType.VarChar, 8000).Value = txtvaluePPLwmj_nc2.Text
                    cmd.Parameters.Add("@QuoteID", SqlDbType.VarChar, 8000).Value = quoteIDlbl.Text
                    cmd.Parameters.Add("@territory", SqlDbType.VarChar, 8000).Value = protection.Text



                    Try
                        Dim ds As Data.DataSet = New Data.DataSet

                        cmd.Connection.Open()
                        ' intRowsAff = cmd.ExecuteNonQuery()

                        Dim myCommand = New SqlDataAdapter(cmd)
                        myCommand.Fill(ds, "tbl1")
                        If ds.Tables("tbl1").Rows.Count > 0 Then
                            wmjppcatcmbo_nc2.Text = ""
                            txtPPLDescriptionwmj_nc2.Text = ""
                            txtQuantityPPlwmj_nc2.Text = ""
                            txtvaluePPLwmj_nc2.Text = ""
                            wmjPPGrid_nc2.DataSource = ds.Tables("tbl1")
                            wmjPPGrid_nc2.DataBind()
                            WMJPPtotalsnc2()

                        End If

                    Catch ex As Exception
                        Dim s As String = ""
                        For Each param As SqlParameter In cmd.Parameters
                            s += param.ParameterName & "="
                            s += param.Value & ":  "

                        Next
                        errortrap("Adding PPL for WMJ data " & s, "Calculation AddPPL", ex.Message)
                    End Try

                End If

            End If

        End If

    End Sub

    Protected Sub btnAddPPLwmj_nc3_Click(sender As Object, e As EventArgs) Handles btnAddPPLwmj_nc3.Click
        If IsNumeric(txtvaluePPLwmj_nc3.Text) Then
            If CDbl(txtvaluePPLwmj_nc3.Text) > 2000.0 Then
                PPError.Visible = True
                PPError.Text = "Property Value cannot Exceed $2000"
                PPError.ForeColor = Drawing.Color.Red
            Else
                If CDbl(wmjppvalue_nc3.Text) + CDbl(txtvaluePPLwmj_nc3.Text) > 10000.0 Then
                    PPError.Visible = True
                    PPError.Text = "Property Total Value cannot Exceed $10,000"
                    PPError.ForeColor = Drawing.Color.Red
                Else
                    PPError.Visible = False

                    Dim Connection As String = System.Configuration.ConfigurationManager.ConnectionStrings("ColonialMHConnectionString").ConnectionString
                    Dim dbConnection As System.Data.IDbConnection = New System.Data.SqlClient.SqlConnection(Connection)
                    Dim cmd As New SqlCommand("sp_WMJPPInsert", dbConnection)
                    cmd.CommandType = CommandType.StoredProcedure
                    cmd.Parameters.Add("@Category", SqlDbType.VarChar, 8000).Value = wmjppcatcmbo_nc3.SelectedItem.ToString
                    cmd.Parameters.Add("@Description", SqlDbType.VarChar, 8000).Value = txtPPLDescriptionwmj_nc3.Text
                    cmd.Parameters.Add("@qty", SqlDbType.VarChar, 8000).Value = txtQuantityPPlwmj_nc3.Text
                    cmd.Parameters.Add("@value", SqlDbType.VarChar, 8000).Value = txtvaluePPLwmj_nc3.Text
                    cmd.Parameters.Add("@QuoteID", SqlDbType.VarChar, 8000).Value = quoteIDlbl.Text
                    cmd.Parameters.Add("@territory", SqlDbType.VarChar, 8000).Value = protection.Text



                    Try
                        Dim ds As Data.DataSet = New Data.DataSet

                        cmd.Connection.Open()
                        ' intRowsAff = cmd.ExecuteNonQuery()

                        Dim myCommand = New SqlDataAdapter(cmd)
                        myCommand.Fill(ds, "tbl1")
                        If ds.Tables("tbl1").Rows.Count > 0 Then
                            wmjppcatcmbo_nc3.Text = ""
                            txtPPLDescriptionwmj_nc3.Text = ""
                            txtQuantityPPlwmj_nc3.Text = ""
                            txtvaluePPLwmj_nc3.Text = ""
                            wmjPPGrid_nc3.DataSource = ds.Tables("tbl1")
                            wmjPPGrid_nc3.DataBind()
                            WMJPPtotalsnc3()

                        End If

                    Catch ex As Exception
                        Dim s As String = ""
                        For Each param As SqlParameter In cmd.Parameters
                            s += param.ParameterName & "="
                            s += param.Value & ":  "

                        Next
                        errortrap("Adding PPL for WMJ data " & s, "Calculation AddPPL", ex.Message)
                    End Try

                End If

            End If

        End If

    End Sub

    Protected Sub btnAddPPLwmj_nc1_Click(sender As Object, e As EventArgs) Handles btnAddPPLwmj_nc1.Click
        If IsNumeric(txtvaluePPLwmj_nc1.Text) Then
            If CDbl(txtvaluePPLwmj_nc1.Text) > 2000.0 Then
                PPError.Visible = True
                PPError.Text = "Property Value cannot Exceed $2000"
                PPError.ForeColor = Drawing.Color.Red
            Else
                If CDbl(wmjppvalue_nc1.Text) + CDbl(txtvaluePPLwmj_nc1.Text) > 10000.0 Then
                    PPError.Visible = True
                    PPError.Text = "Property Total Value cannot Exceed $10,000"
                    PPError.ForeColor = Drawing.Color.Red
                Else
                    PPError.Visible = False

                    Dim Connection As String = System.Configuration.ConfigurationManager.ConnectionStrings("ColonialMHConnectionString").ConnectionString
                    Dim dbConnection As System.Data.IDbConnection = New System.Data.SqlClient.SqlConnection(Connection)
                    Dim cmd As New SqlCommand("sp_WMJPPInsert", dbConnection)
                    cmd.CommandType = CommandType.StoredProcedure
                    cmd.Parameters.Add("@Category", SqlDbType.VarChar, 8000).Value = wmjppcatcmbo_nc1.SelectedItem.ToString
                    cmd.Parameters.Add("@Description", SqlDbType.VarChar, 8000).Value = txtPPLDescriptionwmj_nc1.Text
                    cmd.Parameters.Add("@qty", SqlDbType.VarChar, 8000).Value = txtQuantityPPlwmj_nc1.Text
                    cmd.Parameters.Add("@value", SqlDbType.VarChar, 8000).Value = txtvaluePPLwmj_nc1.Text
                    cmd.Parameters.Add("@QuoteID", SqlDbType.VarChar, 8000).Value = quoteIDlbl.Text
                    cmd.Parameters.Add("@territory", SqlDbType.VarChar, 8000).Value = protection.Text



                    Try
                        Dim ds As Data.DataSet = New Data.DataSet

                        cmd.Connection.Open()
                        ' intRowsAff = cmd.ExecuteNonQuery()

                        Dim myCommand = New SqlDataAdapter(cmd)
                        myCommand.Fill(ds, "tbl1")
                        If ds.Tables("tbl1").Rows.Count > 0 Then
                            wmjppcatcmbo_nc1.Text = ""
                            txtPPLDescriptionwmj_nc1.Text = ""
                            txtQuantityPPlwmj_nc1.Text = ""
                            txtvaluePPLwmj_nc1.Text = ""
                            wmjPPGrid_nc1.DataSource = ds.Tables("tbl1")
                            wmjPPGrid_nc1.DataBind()
                            WMJPPtotalsnc1()

                        End If

                    Catch ex As Exception
                        Dim s As String = ""
                        For Each param As SqlParameter In cmd.Parameters
                            s += param.ParameterName & "="
                            s += param.Value & ":  "

                        Next
                        errortrap("Adding PPL for WMJ data " & s, "Calculation AddPPL", ex.Message)
                    End Try

                End If

            End If

        End If

    End Sub

    Protected Sub wmj_premiumbtnClick_nc1(sender As Object, e As EventArgs) Handles wmj1_updateOptions_nc1.Click
        loadWMJPPnc1()
        calcWMJNC()
    End Sub

    Protected Sub wmj_premiumbtnClick_nc2(sender As Object, e As EventArgs) Handles wmj1_updateOptions_nc2.Click
        loadWMJPPnc2()
        calcWMJNC()
    End Sub

    Protected Sub wmj_premiumbtnClick_nc3(sender As Object, e As EventArgs) Handles wmj1_updateOptions_nc3.Click
        loadWMJPPnc3()
      
        'txt_pp_wmjnc3.Text = CInt(MHValuelbl.Text * 0.5)
        calcWMJNC()
    End Sub
    Public Sub WMJPPtotalsnc2()
        Dim Connection As String = System.Configuration.ConfigurationManager.ConnectionStrings("ColonialMHConnectionString").ConnectionString
        Dim dbConnection As System.Data.IDbConnection = New System.Data.SqlClient.SqlConnection(Connection)
        Dim cmd As New SqlCommand("sp_GetWMJPPtotals", dbConnection)
        cmd.CommandType = CommandType.StoredProcedure

        cmd.Parameters.Add("@QuoteID", SqlDbType.VarChar, 8000).Value = quoteIDlbl.Text




        Try
            Dim ds As Data.DataSet = New Data.DataSet

            cmd.Connection.Open()
            ' intRowsAff = cmd.ExecuteNonQuery()

            Dim myCommand = New SqlDataAdapter(cmd)
            myCommand.Fill(ds, "tbl1")
            If ds.Tables("tbl1").Rows.Count > 0 Then

                ' WMJPPGrid.DataSource = ds.Tables("tbl1")
                If ds.Tables("tbl1").Rows(0).Item("Totalvalue").ToString() = "0" Then
                    wmjppvalue_nc2.Text = "0.00"
                    wmjppprem_nc2.Text = "0.00"
                Else

                    wmjppvalue_nc2.Text = ds.Tables("tbl1").Rows(0).Item("Totalvalue").ToString()
                    wmjppprem_nc2.Text = Math.Round((CDec(ds.Tables("tbl1").Rows(0).Item("PPRate").ToString()) * 1), 0, MidpointRounding.AwayFromZero)
                End If

                calcWMJNC()
            Else
                wmjPPGrid_nc2.DataSource = vbNull
                wmjppvalue_nc2.Text = "0.00"
                wmjppprem_nc2.Text = "0.00"
                calcWMJNC()
            End If

        Catch ex As Exception
            Dim s As String = ""
            For Each param As SqlParameter In cmd.Parameters
                s += param.ParameterName & "="
                s += param.Value & ":  "

            Next
            errortrap("Geting WMJ data " & s, "Totals2", ex.Message)
        End Try



    End Sub
    Public Sub WMJPPtotalsnc1()
        Dim Connection As String = System.Configuration.ConfigurationManager.ConnectionStrings("ColonialMHConnectionString").ConnectionString
        Dim dbConnection As System.Data.IDbConnection = New System.Data.SqlClient.SqlConnection(Connection)
        Dim cmd As New SqlCommand("sp_GetWMJPPtotals", dbConnection)
        cmd.CommandType = CommandType.StoredProcedure

        cmd.Parameters.Add("@QuoteID", SqlDbType.VarChar, 8000).Value = quoteIDlbl.Text




        Try
            Dim ds As Data.DataSet = New Data.DataSet

            cmd.Connection.Open()
            ' intRowsAff = cmd.ExecuteNonQuery()

            Dim myCommand = New SqlDataAdapter(cmd)
            myCommand.Fill(ds, "tbl1")
            If ds.Tables("tbl1").Rows.Count > 0 Then

                ' WMJPPGrid.DataSource = ds.Tables("tbl1")
                If ds.Tables("tbl1").Rows(0).Item("Totalvalue").ToString() = "0" Then
                    wmjppvalue_nc1.Text = "0.00"
                    wmjppprem_nc1.Text = "0.00"
                Else

                    wmjppvalue_nc1.Text = ds.Tables("tbl1").Rows(0).Item("Totalvalue").ToString()
                    wmjppprem_nc1.Text = Math.Round((CDec(ds.Tables("tbl1").Rows(0).Item("PPRate").ToString()) * 1), 0, MidpointRounding.AwayFromZero)
                End If

                calcWMJNC()
            Else
                wmjPPGrid_nc1.DataSource = vbNull
                wmjppvalue_nc1.Text = "0.00"
                wmjppprem_nc1.Text = "0.00"
                calcWMJNC()
            End If

        Catch ex As Exception
            Dim s As String = ""
            For Each param As SqlParameter In cmd.Parameters
                s += param.ParameterName & "="
                s += param.Value & ":  "

            Next
            errortrap("Geting WMJ data " & s, "Totals2", ex.Message)
        End Try



    End Sub
    Public Sub WMJPPtotalsnc3()
        Dim Connection As String = System.Configuration.ConfigurationManager.ConnectionStrings("ColonialMHConnectionString").ConnectionString
        Dim dbConnection As System.Data.IDbConnection = New System.Data.SqlClient.SqlConnection(Connection)
        Dim cmd As New SqlCommand("sp_GetWMJPPtotals", dbConnection)
        cmd.CommandType = CommandType.StoredProcedure

        cmd.Parameters.Add("@QuoteID", SqlDbType.VarChar, 8000).Value = quoteIDlbl.Text




        Try
            Dim ds As Data.DataSet = New Data.DataSet

            cmd.Connection.Open()
            ' intRowsAff = cmd.ExecuteNonQuery()

            Dim myCommand = New SqlDataAdapter(cmd)
            myCommand.Fill(ds, "tbl1")
            If ds.Tables("tbl1").Rows.Count > 0 Then

                ' WMJPPGrid.DataSource = ds.Tables("tbl1")
                If ds.Tables("tbl1").Rows(0).Item("Totalvalue").ToString() = "0" Then
                    wmjppvalue_nc3.Text = "0.00"
                    wmjppprem_nc3.Text = "0.00"
                Else

                    wmjppvalue_nc3.Text = ds.Tables("tbl1").Rows(0).Item("Totalvalue").ToString()
                    wmjppprem_nc3.Text = Math.Round((CDec(ds.Tables("tbl1").Rows(0).Item("PPRate").ToString()) * 1), 0, MidpointRounding.AwayFromZero)
                End If

                calcWMJNC()
            Else
                wmjPPGrid_nc3.DataSource = vbNull
                wmjppvalue_nc3.Text = "0.00"
                wmjppprem_nc3.Text = "0.00"
                calcWMJNC()
            End If

        Catch ex As Exception
            Dim s As String = ""
            For Each param As SqlParameter In cmd.Parameters
                s += param.ParameterName & "="
                s += param.Value & ":  "

            Next
            errortrap("Geting WMJ data " & s, "Totals2", ex.Message)
        End Try



    End Sub
    Public Sub loadWMJPPnc1()
        Dim Connection As String = System.Configuration.ConfigurationManager.ConnectionStrings("ColonialMHConnectionString").ConnectionString
        Dim dbConnection As System.Data.IDbConnection = New System.Data.SqlClient.SqlConnection(Connection)
        Dim cmd As New SqlCommand("sp_GetWMJPP", dbConnection)
        cmd.CommandType = CommandType.StoredProcedure

        cmd.Parameters.Add("@QuoteID", SqlDbType.VarChar, 8000).Value = quoteIDlbl.Text




        Try
            Dim ds As Data.DataSet = New Data.DataSet

            cmd.Connection.Open()
            ' intRowsAff = cmd.ExecuteNonQuery()

            Dim myCommand = New SqlDataAdapter(cmd)
            myCommand.Fill(ds, "tbl1")
            If ds.Tables("tbl1").Rows.Count > 0 Then

                wmjPPGrid_nc1.DataSource = ds.Tables("tbl1")
                wmjPPGrid_nc1.DataBind()
                WMJPPtotalsnc1()

            Else
                ' WMJPPGrid.DataSource = vbNull.ToString
                wmjPPGrid_nc1.DataSource = ""
                wmjppvalue_nc1.Text = "0.00"
                wmjppprem_nc1.Text = "0.00"
                WMJPPtotalsnc1()
            End If

        Catch ex As Exception
            Dim s As String = ""
            For Each param As SqlParameter In cmd.Parameters
                s += param.ParameterName & "="
                s += param.Value & ":  "

            Next
            errortrap("Geting WMJ PP data " & s, "Grid", ex.Message)
        End Try

    End Sub
    Public Sub loadWMJPPnc2()
        Dim Connection As String = System.Configuration.ConfigurationManager.ConnectionStrings("ColonialMHConnectionString").ConnectionString
        Dim dbConnection As System.Data.IDbConnection = New System.Data.SqlClient.SqlConnection(Connection)
        Dim cmd As New SqlCommand("sp_GetWMJPP", dbConnection)
        cmd.CommandType = CommandType.StoredProcedure

        cmd.Parameters.Add("@QuoteID", SqlDbType.VarChar, 8000).Value = quoteIDlbl.Text




        Try
            Dim ds As Data.DataSet = New Data.DataSet

            cmd.Connection.Open()
            ' intRowsAff = cmd.ExecuteNonQuery()

            Dim myCommand = New SqlDataAdapter(cmd)
            myCommand.Fill(ds, "tbl1")
            If ds.Tables("tbl1").Rows.Count > 0 Then

                wmjPPGrid_nc2.DataSource = ds.Tables("tbl1")
                wmjPPGrid_nc2.DataBind()
                WMJPPtotalsnc2()

            Else
                ' WMJPPGrid.DataSource = vbNull.ToString
                wmjPPGrid_nc2.DataSource = ""
                wmjppvalue_nc2.Text = "0.00"
                wmjppprem_nc2.Text = "0.00"
                WMJPPtotalsnc2()
            End If

        Catch ex As Exception
            Dim s As String = ""
            For Each param As SqlParameter In cmd.Parameters
                s += param.ParameterName & "="
                s += param.Value & ":  "

            Next
            errortrap("Geting WMJ PP data " & s, "Grid", ex.Message)
        End Try

    End Sub
    Public Sub loadWMJPPnc3()
        Dim Connection As String = System.Configuration.ConfigurationManager.ConnectionStrings("ColonialMHConnectionString").ConnectionString
        Dim dbConnection As System.Data.IDbConnection = New System.Data.SqlClient.SqlConnection(Connection)
        Dim cmd As New SqlCommand("sp_GetWMJPP", dbConnection)
        cmd.CommandType = CommandType.StoredProcedure

        cmd.Parameters.Add("@QuoteID", SqlDbType.VarChar, 8000).Value = quoteIDlbl.Text




        Try
            Dim ds As Data.DataSet = New Data.DataSet

            cmd.Connection.Open()
            ' intRowsAff = cmd.ExecuteNonQuery()

            Dim myCommand = New SqlDataAdapter(cmd)
            myCommand.Fill(ds, "tbl1")
            If ds.Tables("tbl1").Rows.Count > 0 Then

                wmjPPGrid_nc3.DataSource = ds.Tables("tbl1")
                wmjPPGrid_nc3.DataBind()
                WMJPPtotalsnc3()

            Else
                ' WMJPPGrid.DataSource = vbNull.ToString
                wmjPPGrid_nc3.DataSource = ""
                wmjppvalue_nc3.Text = "0.00"
                wmjppprem_nc3.Text = "0.00"
                WMJPPtotalsnc3()
            End If

        Catch ex As Exception
            Dim s As String = ""
            For Each param As SqlParameter In cmd.Parameters
                s += param.ParameterName & "="
                s += param.Value & ":  "

            Next
            errortrap("Geting WMJ PP data " & s, "Grid", ex.Message)
        End Try

    End Sub

    Protected Sub Aegisvint_premiumbtnClick_sc1(sender As Object, e As EventArgs) Handles Aegisvint1_updateOptions_sc1.Click
        AegisCalcVint()

    End Sub

    Protected Sub selectAegisvint1btnsc1_Click(sender As Object, e As EventArgs) Handles selectAegisvint_sc1btn.Click
        HiddenFieldSelected.Value = "Aegis Vintage"
        rateTypelbl.Text = "Aegis Vintage"
        rateTypelbl.Font.Bold = True
        rateTypelbl.ForeColor = Drawing.Color.Green


        'Set Selected to AR1 in database  Not saving right now...
        Try

            If quoteIDlbl.Text <> "" Then
                Me.Page.GetType.InvokeMember("updateQuote", System.Reflection.BindingFlags.InvokeMethod, Nothing, Me.Page, New Object() {quoteIDlbl.Text})
            Else
                Me.Page.GetType.InvokeMember("save", System.Reflection.BindingFlags.InvokeMethod, Nothing, Me.Page, New Object() {})

            End If
        Catch ex As Exception
            errortrap("UPDATE Aegis Vintage", "Selected Aegis Vintage", ex.Message)
        End Try
        Dim ds As System.Data.DataSet
        ds = runQueryDS("EXEC sp_SetQuoteRateType '" & quoteIDlbl.Text & "', 'Aegis Vintage'", "ColonialMHConnectionString")
        'Check Financing options
        ds = runQueryDS("SELECT ARRateType, state  FROM tblQuotes WHERE quoteID ='" & quoteIDlbl.Text & "'", "ColonialMHConnectionString")
      
        premiumBtnTable.Attributes.Add("style", "display:block")
    End Sub
    ''General Finance Section
    'Public Sub PremiumFinanceCalc_Click(ByVal sender As Object, ByVal e As EventArgs) Handles premiumFinanceCalcBtn.Click
    '    Dim state As String
    '    state = mhstatelbl.Text
    '    If mhstate = "NC" Or mhstate = "SC" Or mhstate = "VA" Then 'Colonial Premium Finance
    '        ColonialPremiumFinancing()
    '    Else 'Prime Rate
    '        PrimeRateFinancing()
    '    End If

    'End Sub
    Public Sub PremiumFinanceCalc_OptionsChanged(ByVal sender As Object, ByVal e As EventArgs) Handles PremiumFinanceDP.SelectedIndexChanged, PremiumFinanceLen.SelectedIndexChanged
        
        Dim state As String
        state = mhstatelbl.Text
        If state = "NC" Or state = "SC" Or state = "VA" Then 'Colonial Premium Finance
            If PremiumFinanceLen.SelectedIndex < 0 Then
                Exit Sub
            End If
            If PremiumFinanceDP.SelectedIndex < 0 Then
                Exit Sub
            End If
            ColonialPremiumFinancing()
        Else 'Prime Rate
            If PremiumFinanceDP.SelectedIndex < 0 Then
                Exit Sub
            End If
            PrimeRateFinancing()
            PremiumFinanceLen.Visible = False
        End If

    End Sub
    'Colonial Premium Finance
    Protected Sub ColonialPremiumFinancing()
        Dim ds As System.Data.DataSet
        ds = runQueryDS("SELECT ARRateType, state  FROM tblQuotes WHERE quoteID ='" & quoteIDlbl.Text & "'", "ColonialMHConnectionString")
        If ds.Tables(0).Rows.Count > 0 Then
            LloydsState = ds.Tables(0).Rows(0).Item("state")
        End If
        Dim downPayment, Length, quoteID As String
        quoteID = quoteIDlbl.Text
        downPayment = PremiumFinanceDP.SelectedItem.Value.ToString
        Length = PremiumFinanceLen.SelectedItem.Value.ToString
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


        ds = runQueryDS("EXEC sp_GetLloydsFinanceData '" & quoteID & "','" & downPayment & "','" & Length & "'", "ColonialMHConnectionString")
        If ds.Tables(0).Rows.Count > 0 Then
            Dim test As String
            test = ds.Tables(0).Rows(0).Item("MonthlyPayments").ToString()
            test = ds.Tables(0).Rows(0).Item("AmountFinanced").ToString()
            Dim wrk1 As Decimal = CDbl(ds.Tables(0).Rows(0).Item("MonthlyPayments")) / CDbl(ds.Tables(0).Rows(0).Item("AmountFinanced"))
            Dim wrk2 As Decimal = wrk1
            Dim APR As Decimal = GetAPR(wrk1, wrk2, Length)
            lblGeneralFinanceType.Text = "Colonial Financing"
            lblGeneralPremium.Text = FormatCurrency(ds.Tables(0).Rows(0).Item("PremTotal"))
            lblGeneralDownPayment.Text = FormatCurrency(ds.Tables(0).Rows(0).Item("DownPayment"))
            lblGeneralAmountFinanced.Text = FormatCurrency(ds.Tables(0).Rows(0).Item("AmountFinanced"))
            lblGeneralFinanceCharge.Text = FormatCurrency(ds.Tables(0).Rows(0).Item("FinanceCharge"))
            lblGeneralTotalOfPayments.Text = FormatCurrency(ds.Tables(0).Rows(0).Item("TotalOfPayments"))
            lblGeneralMonthlyPayment.Text = FormatCurrency(ds.Tables(0).Rows(0).Item("MonthlyPayments"))
            lblGeneralAPR.Text = CStr(APR) + "%"
        End If

    End Sub
    'Prime Rate Finance
    Protected Sub PrimeRateFinancing()
        Dim fin As New Finance
        Dim DetailString, downPayment As String
        downPayment = PremiumFinanceDP.SelectedItem.Value.ToString
        If Request.QueryString("quoteID") <> "" Then
            DetailString = fin.CalcFinancingOnlyXML(quoteIDlbl.Text, downPayment)
            If DetailString.Contains("xml") Then
                lblGeneralFinanceType.Text = "Prime Rate Financing"
                lblGeneralPremium.Text = FormatCurrency(DetailString.GetXMLElementValue("Total").ToString)
                lblGeneralDownPayment.Text = FormatCurrency(DetailString.GetXMLElementValue("DownPayment").ToString)
                lblGeneralAmountFinanced.Text = FormatCurrency(DetailString.GetXMLElementValue("AmountFinanced").ToString)
                lblGeneralFinanceCharge.Text = FormatCurrency(CDec(DetailString.GetXMLElementValue("FinanceCharge").ToString))
                lblGeneralTotalOfPayments.Text = DetailString.GetXMLElementValue("NumberOfPayments").ToString
                lblGeneralMonthlyPayment.Text = DetailString.GetXMLElementValue("Payment").ToString
                lblGeneralAPR.Text = DetailString.GetXMLElementValue("APR").ToString + "%"
            Else
                lblGeneralFinanceType.Text = DetailString
            End If

        End If
    End Sub
    'End General Finance Section

    
End Class