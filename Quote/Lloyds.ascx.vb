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
      
        If dd_pl_AR2.SelectedValue() > "$0" Then
            dd_mp_AR2.SelectedValue = "$500"
        ElseIf dd_pl_AR2.SelectedValue() = "$0" Then
            dd_mp_AR2.SelectedValue = "$0"
        Else
            dd_mp_AR2.SelectedValue = "$0"
        End If

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
            aiges_mh_prog3_Options.Style.Add("display", "block")
            Table2.Style.Add("display", "block")
            lblaiges_ShowOptions3.InnerText = "- Show Options"
        Else
            aiges_mh_prog3_Options.Style.Add("display", "none")
            Table2.Style.Add("display", "none")
            lblaiges_ShowOptions3.InnerText = "+ Show Options"
        End If





        If Not IsPostBack Then
            lblchange.Visible = False
            'standcramtlbl.Text = 0
            'standperclbl.Text = 0
            ' dd_pl_AR1.SelectedValue = "$25,000"
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

            dd_pl_08.SelectedValue = "$25,000"
            dd_aop_08.SelectedValue = "$1000"
            'Aegis.  Hide everthing till later:
            'aiges_mh_prog2.Visible = False
            'aiges_mh_prog2_Options.Visible = False
            'aiges_mh_prog3.Visible = False
            'aiges_mh_prog3_Options.Visible = False


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
                aiges_mh_prog3_Options.Style.Add("display", "block")
                Table2.Style.Add("display", "block")
                lblaiges_ShowOptions3.InnerText = "- Show Options"
            Else
                aiges_mh_prog3_Options.Style.Add("display", "none")
                Table2.Style.Add("display", "none")
                lblaiges_ShowOptions3.InnerText = "+ Show Options"
            End If
            dd_sip_AR1.Enabled = True
            dd_mhr_AR1.Enabled = True
            PPError.Visible = False

        End If



        'Added for SC Fiancing
        DownPaymentPercentRB.Attributes.Add("onChange", "return FinanceOptionChange();")
        FinanceLengthRB.Attributes.Add("onChange", "return FinanceOptionChange();")

    End Sub
    Public Sub loadpremdata(ByVal value As String, ByVal state As String, ByVal type As String, ByVal mfg As String, ByVal year As String, ByVal county As String, ByVal Quoteid As String, ByVal Usage As String, ByVal dist As String, ByVal prot As String, ByVal lien As String, ByVal subheat As String, ByVal dob As String, ByVal skirt As String, ByVal subnum As String)
        MHValuelbl.Text = value
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
        'If state = "DE" Then
        '    SC_MH_08.Visible = False
        '    SC08_mh_prog_Options.Visible = False
        '    SC08OptionRow.Visible = False
        '    aiges_mh_prog2.Visible = False
        '    aiges_mh_prog2_Options.Visible = False
        '    aiges_mh_prog3.Visible = False
        '    aiges_mh_prog3_Options.Visible = False
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
        '                aiges_mh_prog3_Options.Visible = False
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

        If Quoteid <> "" Then
            LoadLloydsPremiums(Quoteid, value, state, type, mfg, year, county, Usage, dist, prot, lien, subheat, dob)
        Else

            ProgramChoice()
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
            If lbl_Aegis_Rent.Text = "True" Or lbl_Aegis_Stand.Text = "True" Then
                aiges_mh_prog2.Visible = False
                aiges_mh_prog2_Options.Visible = False
                aiges_mh_prog3.Visible = False
                aiges_mh_prog3_Options.Visible = False
                loadAegisPP()
                'LoadAegisData()
                calcAegis()
            Else
                aiges_mh_prog2.Visible = False
                aiges_mh_prog2_Options.Visible = False
                aiges_mh_prog3.Visible = False
                aiges_mh_prog3_Options.Visible = False
            End If
            If lbl_Lloyds_Pack.Text = "True" Or lbl_Lloyds_Rent.Text = "True" Or lbl_Lloyds_Stand.Text = "True" Then
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
                End If
            End If



        End If





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
            errortrap("Save Before Lloyds Print", "printbtn_Click", ex.Message)
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
        If Left(rateTypelbl.Text, 5) = "Aegis" Then
            url = "~/Application/AigesApplication.aspx?quoteID=" & quoteID & ""
            Me.Page.GetType.InvokeMember("AegisRedirect", System.Reflection.BindingFlags.InvokeMethod, Nothing, Me.Page, New Object() {quoteID})
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
    Public Sub LoadLloydsPremiums(ByVal quoteID As String, ByVal value As String, ByVal state As String, ByVal type As String, ByVal mfg As String, ByVal year As String, ByVal county As String, ByVal Usage As String, ByVal dist As String, ByVal prot As String, ByVal lien As String, ByVal subheat As String, ByVal dob As String)
        LloydsQuote = quoteID
        LloydsState = state
        Dim dsFin As System.Data.DataSet
        'Load Financing
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
            'Dim lbl As New Label()
            'lbl.Text = "<script language='javascript'> FinanceOptionChange();" & "<" & "/script>"
            'Page.Controls.Add(lbl)

        End If 'End of Load Financing
        calcSCFinancing()

        mhquoteID = quoteID
        MHValuelbl.Text = value
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
        If lbl_Aegis_Rent.Text = "True" Or lbl_Aegis_Stand.Text = "True" Then
            aiges_mh_prog2.Visible = False
            aiges_mh_prog2_Options.Visible = False
            aiges_mh_prog3.Visible = False
            aiges_mh_prog3_Options.Visible = False
            loadAegisPP()
            LoadAegisData()
            ' calcAegis()
        Else
            aiges_mh_prog2.Visible = False
            aiges_mh_prog2_Options.Visible = False
            aiges_mh_prog3.Visible = False
            aiges_mh_prog3_Options.Visible = False
        End If

        If lbl_Lloyds_Pack.Text = "True" Or lbl_Lloyds_Rent.Text = "True" Or lbl_Lloyds_Stand.Text = "True" Or lbl_Lloyds_SMH.Text = "True" Then


            Try


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
                    dd_mp_AR2.SelectedValue = ds.Tables("tbl1").Rows(0).Item("StandMedPay").ToString
                    ar_baseprem2.Text = "$" & ds.Tables("tbl1").Rows(0).Item("StandBasePrem").ToString.Replace("$", "")

                    If ds.Tables("tbl1").Rows(0).Item("StandAOP").ToString = "$500" Or ds.Tables("tbl1").Rows(0).Item("StandAOP").ToString = "$1000" Then
                        dd_aop_AR2.SelectedValue = ds.Tables("tbl1").Rows(0).Item("StandAOP").ToString
                    Else
                        dd_aop_AR2.SelectedValue = "$500"
                    End If


                    If ds.Tables("tbl1").Rows(0).Item("StandPerLiab").ToString = "$25,000" Or ds.Tables("tbl1").Rows(0).Item("StandPerLiab").ToString = "$50,000" Or ds.Tables("tbl1").Rows(0).Item("StandPerLiab").ToString = "$100,000" Then
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
                    SC08_perLiab.Text = ds.Tables("tbl1").Rows(0).Item("SMHPackLiab").ToString
                    SC08_medpay.Text = ds.Tables("tbl1").Rows(0).Item("SMHPackMedPay").ToString
                    SC08_baseprem.Text = "$" & ds.Tables("tbl1").Rows(0).Item("SMHPackBasePrem").ToString.Replace("$", "")


                    If ds.Tables("tbl1").Rows(0).Item("SMHPackAOP").ToString = "$500" Or ds.Tables("tbl1").Rows(0).Item("SMHPackAOP").ToString = "$1000" Or ds.Tables("tbl1").Rows(0).Item("SMHPackAOP").ToString = "$2500" Then
                        dd_aop_08.SelectedValue = ds.Tables("tbl1").Rows(0).Item("SMHPackAOP").ToString
                    End If
                    dd_hurded_08.Text = ds.Tables("tbl1").Rows(0).Item("SMHPackWind").ToString

                    If ds.Tables("tbl1").Rows(0).Item("SMHPackPerLiab").ToString = "$25,000" Or ds.Tables("tbl1").Rows(0).Item("SMHPackPerLiab").ToString = "$50,000" Or ds.Tables("tbl1").Rows(0).Item("SMHPackPerLiab").ToString = "$100,000" Then
                        dd_pl_08.SelectedValue = ds.Tables("tbl1").Rows(0).Item("SMHPackPerLiab").ToString
                    End If
                    If ds.Tables("tbl1").Rows(0).Item("SMHPackContReplace").ToString = "Yes" Or ds.Tables("tbl1").Rows(0).Item("SMHPackContReplace").ToString = "No" Then
                        dd_rep_08.SelectedValue = ds.Tables("tbl1").Rows(0).Item("SMHPackContReplace").ToString
                    End If
                    If ds.Tables("tbl1").Rows(0).Item("SMHPackFullRepair").ToString = "Yes" Or ds.Tables("tbl1").Rows(0).Item("SMHPackFullRepair").ToString = "No" Then
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
                        ElseIf ds.Tables(0).Rows(0).Item("ARRateType").ToString() = "Aegis Standard" Or ds.Tables(0).Rows(0).Item("ARRateType").ToString() = "Aegis Rental" Then

                            If lbl_Aegis_Rent.Text = "False" And lbl_Aegis_Stand.Text = "False" Then

                                rateTypelbl.Text = "" 'ds.Tables(0).Rows(0).Item("ARRateType").ToString()
                            Else
                                rateTypelbl.Text = ds.Tables(0).Rows(0).Item("ARRateType").ToString()
                                LoadAegisData()
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
                Calc()
            Catch ex As Exception
                errortrap("LoadLloydsPremiums", "Get Loyds Calc data", ex.Message)
            End Try
        End If
        'Show hide button
        If LloydsState = "SC" And Not rateTypelbl.Text.ToString.ToUpper.Contains("AEG") Then
            SCPremFinbtn.Visible = True
            calcSCFinancing()
        Else
            SCPremFinbtn.Visible = False
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


        mhvalue = MHValuelbl.Text
        mhcounty = mhcountylbl.Text
        mhstate = mhstatelbl.Text
        mhmfg = mhmfglbl.Text
        mhtype = mhtypelbl.Text
        mhyear = mhyearlbl.Text
        lblchange.Text = ""
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
        cmd.Parameters.Add("@RentLiabPer", SqlDbType.VarChar, 8000).Value = dd_pl_AR3.SelectedValue().Replace("$", "").Replace(",", "")
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
            errortrap("Geting Calculation data", "Calculation CALC", ex.Message)
        End Try

    End Sub
    Public Sub savePrem(ByVal quoteID As String)
        If quoteID <> "" Then
            If rateTypelbl.Text = "Aegis Standard" Or rateTypelbl.Text = "Aegis Rental" Then
                SaveAegis(quoteID)
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
                    errortrap("Saving Lloyds Data", "Save Prem", ex.Message)
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

        If mhtype = "Doublewide" Then
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
        dd_hurded_AR1.Text = "$" & ds.Tables("tbl1").Rows(0).Item("Tstorm").ToString()
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

        If Date.Now.Year - mhyearlbl.Text < 15 Then
            CreditsPercentage += 0.1
        End If
        For Each s As String In mfg
            If UCase(s) = UCase(mhmfglbl.Text) Then
                CreditsPercentage += 0.1
            End If
        Next


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
        AR1_Debug.Text += "<tr align=left><td>SUB TOTAL 2</td><td> $" & CInt(packtotal) & " </td></tr> "
        AR1_Debug.Text += "<tr align=left><td>Personal Liability</td><td> $" & CInt(ds.Tables("tbl1").Rows(0).Item("PackLiabPerRate").ToString()) & " </td></tr> "
        packtotal += CInt(ds.Tables("tbl1").Rows(0).Item("PackLiabPerRate").ToString())
        packopt += CInt(ds.Tables("tbl1").Rows(0).Item("PackLiabPerRate").ToString())
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
        AR1_Debug.Text += "<tr align=left><td>Taxes</td><td> $" & CDbl(CInt(packtotal) * CDec(ds.Tables("tbl1").Rows(0).Item("taxamt").ToString())) & " </td></tr> "
        ar_tax1.Text = "$" & CDbl(CInt(packtotal) * CDec(ds.Tables("tbl1").Rows(0).Item("taxamt").ToString()))
        packtotal += CInt(packtotal) * CDec(ds.Tables("tbl1").Rows(0).Item("taxamt").ToString())

        AR1_Debug.Text += "<tr align=left><td>Total Prem</td><td> $" & CDbl(packtotal) & " </td></tr> "








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
                dd_mhr_AR2.Enabled = False
                dd_mhr_AR3.Enabled = False
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
                dd_mhr_AR2.Enabled = False
                dd_mhr_AR3.Enabled = False
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
        If dd_aop_AR2.SelectedValue <> "$500" And dd_aop_AR2.SelectedValue <> "" Then
            dd_aop_AR2_Amount.Text = "($75)"
            AR2_Debug.Text += "<tr align=left><td>AOP</td><td> $ -75 </td></tr> "
            standtotal -= 75
            standopt -= 75
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
        AR3_Debug.Text += "<tr align=left><td>Taxes</td><td> $" & CDbl(CInt(renttotal) * CDec(ds.Tables("tbl1").Rows(0).Item("taxamt").ToString())) & " </td></tr> "
        ar_tax3.Text = "$" & CDbl((renttotal) * CDec(ds.Tables("tbl1").Rows(0).Item("taxamt").ToString()))
        renttotal += CInt(renttotal) * CDec(ds.Tables("tbl1").Rows(0).Item("taxamt").ToString())

        AR3_Debug.Text += "<tr align=left><td>Total Prem</td><td> " & renttotal.ToString("C2") & " </td></tr> "
        'ar_options2.Text = CInt(CInt(rentas) + CInt(rentcon) + CInt(rentaop) + CInt(ds.Tables("tbl1").Rows(0).Item("rentLiabPerRate").ToString()) + CInt(ds.Tables("tbl1").Rows(0).Item("rentContRepRate").ToString()) + CInt(ds.Tables("tbl1").Rows(0).Item("rentFullRepRate").ToString()) + CInt(ds.Tables("tbl1").Rows(0).Item("rentMHRepRate").ToString()))





        AR1_Debug.Text += "</tbody></table>"
        AR2_Debug.Text += "</tbody></table>"
        AR3_Debug.Text += "</tbody></table>"




        ar_total1.Text = String.Format("{0:C}", CInt(ar_baseprem1.Text) + CInt(ar_options1.Text) + CDbl(ar_fees1.Text) + CDbl(ar_tax1.Text))
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
            errortrap("Save Before Lloyds Print", "printbtn_Click", ex.Message)
        End Try
        Dim ds As System.Data.DataSet
        ds = runQueryDS("EXEC sp_SetQuoteRateType '" & quoteIDlbl.Text & "', 'Package'", "ColonialMHConnectionString")
        'Check Financing options
        ds = runQueryDS("SELECT ARRateType, state  FROM tblQuotes WHERE quoteID ='" & quoteIDlbl.Text & "'", "ColonialMHConnectionString")
        If ds.Tables(0).Rows.Count > 0 Then
            If ds.Tables(0).Rows(0).Item("state") = "SC" And Not rateTypelbl.Text.ToString.ToUpper.Contains("AEG") Then
                SCPremFinbtn.Visible = True
                calcSCFinancing()
                '  SCFinancingUpdatePanel.Update()
            Else
                SCPremFinbtn.Visible = False
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
            errortrap("Save Before Lloyds Print", "printbtn_Click", ex.Message)
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
                SCPremFinbtn.Visible = True
                calcSCFinancing()
                ' SCFinancingUpdatePanel.Update()
            Else
                SCPremFinbtn.Visible = False
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
            errortrap("Save Before Lloyds Print", "printbtn_Click", ex.Message)
        End Try
        'Set Selected to AR1 in database
        Dim ds As System.Data.DataSet
        ds = runQueryDS("EXEC sp_SetQuoteRateType '" & quoteIDlbl.Text & "', 'Rental'", "ColonialMHConnectionString")
        'Check Financing options
        ds = runQueryDS("SELECT ARRateType, state  FROM tblQuotes WHERE quoteID ='" & quoteIDlbl.Text & "'", "ColonialMHConnectionString")
        If ds.Tables(0).Rows.Count > 0 Then
            If ds.Tables(0).Rows(0).Item("state") = "SC" And Not rateTypelbl.Text.ToString.ToUpper.Contains("AEG") Then
                SCPremFinbtn.Visible = True
                calcSCFinancing()
                ' SCFinancingUpdatePanel.Update()
            Else
                SCPremFinbtn.Visible = False
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

        If IsNumeric(mhvalue) Then
            If txt_unattstr_08.Text = "0.00" Then
                txt_unattstr_08.Text = CInt(mhvalue) * 0.1
            End If
            If txt_pp_08.Text = "0.00" Then
                txt_pp_08.Text = CInt(mhvalue) * 0.25
            End If

        End If
        If IsNumeric(mhvalue) Then
            If CInt(txt_pp_08.Text) > (CInt(mhvalue) * 0.4) Then
                txt_pp_08.Text = (CInt(mhvalue) * 0.4)
            End If
            If CInt(txt_unattstr_08.Text) > (CInt(mhvalue) * 0.1) Then
                txt_unattstr_08.Text = CInt(mhvalue) * 0.1
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
            errortrap("Geting Calculation data SMH", "Calculation SMH08", ex.Message)
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
        


        SC08_Debug.Text += "<tr align=left><td>Package Premium </td><td> $" & CInt(smhprem) & " </td></tr> "
        SC08_Debug.Text += "<tr align=left><td>Other Structures </td><td> $" & CInt(ds.Tables("tbl1").Rows(0).Item("AsStrucPrem").ToString().Replace("$", "")) & " </td></tr> "
        SC08_Debug.Text += "<tr align=left><td>Contents </td><td> $" & CInt(ds.Tables("tbl1").Rows(0).Item("ContPrem").ToString().Replace("$", "")) & " </td></tr> "
        SC08_Debug.Text += "<tr align=left><td>Addl Living Expense</td><td> $" & CInt("0") & " </td></tr> "
        txt_unattstr_08_Amount.Text = Math.Ceiling(CDbl(ds.Tables("tbl1").Rows(0).Item("AsStrucPrem").ToString().Replace("$", "")))
        txt_pp_08_Amount.Text = Math.Ceiling(CDbl(ds.Tables("tbl1").Rows(0).Item("ContPrem").ToString().Replace("$", "")))
        smhtotal = CInt(smhprem) + Math.Ceiling(CDbl(ds.Tables("tbl1").Rows(0).Item("AsStrucPrem").ToString().Replace("$", ""))) + Math.Ceiling(CDbl(ds.Tables("tbl1").Rows(0).Item("ContPrem").ToString().Replace("$", "")))
        smhopt += Math.Ceiling(CDbl(ds.Tables("tbl1").Rows(0).Item("AsStrucPrem").ToString().Replace("$", ""))) + Math.Ceiling(CDbl(ds.Tables("tbl1").Rows(0).Item("ContPrem").ToString().Replace("$", "")))

        SMHpackpremlbl.Text = CInt(smhtotal)
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
                SCPremFinbtn.Visible = True
                calcSCFinancing()
                'SCFinancingUpdatePanel.Update()
            Else
                SCPremFinbtn.Visible = False
            End If
        End If


        premiumBtnTable.Attributes.Add("style", "display:block")
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

                dd_mp_aiges1.SelectedValue = "$500"


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
                'If IsNumeric(txt_pp_aiges2.Text) Then
                '    contents = txt_pp_aiges2.Text
                'Else
                '    contents = 0
                'End If
                liability = dd_pl_aiges2.SelectedValue
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
                            aiges_mh_prog3_Options.Visible = False
                            AegisStandCalc(ds)
                            'check for personal property

                        Case "Rental"
                            If supheatlbl.Text = "Yes" Then
                                aiges_mh_prog3.Visible = False
                                aiges_mh_prog3_Options.Visible = False
                            Else

