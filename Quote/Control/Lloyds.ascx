<%@ Control Language="vb" AutoEventWireup="false" CodeBehind="Lloyds.ascx.vb" Inherits="MobileHomeRater.Lloyds" %>
<%@ Register Assembly="DevExpress.Web.v13.1, Version=13.1.8.0, Culture=neutral, PublicKeyToken=b88d1754d700e49a"
    Namespace="DevExpress.Web.ASPxGridView" TagPrefix="dx" %>
<%@ Register assembly="DevExpress.Web.v13.1, Version=13.1.8.0, Culture=neutral, PublicKeyToken=b88d1754d700e49a" namespace="DevExpress.Web.ASPxPopupControl" tagprefix="dx" %>
<%@ Register assembly="DevExpress.Web.v13.1, Version=13.1.8.0, Culture=neutral, PublicKeyToken=b88d1754d700e49a" namespace="DevExpress.Web.ASPxEditors" tagprefix="dx" %>
<%@ Register assembly="DevExpress.Web.v13.1, Version=13.1.8.0, Culture=neutral, PublicKeyToken=b88d1754d700e49a" namespace="DevExpress.Web.ASPxPanel" tagprefix="dx" %>
<%@ Register assembly="DevExpress.Web.v13.1, Version=13.1.8.0, Culture=neutral, PublicKeyToken=b88d1754d700e49a" namespace="DevExpress.Web.ASPxLoadingPanel" tagprefix="dx" %>
<%@ Register assembly="DevExpress.Web.v13.1, Version=13.1.8.0, Culture=neutral, PublicKeyToken=b88d1754d700e49a" namespace="DevExpress.Web.ASPxCallback" tagprefix="dx" %>

<%--<style type="text/css">
    .style1
    {
        width: 16px;
        height: 16px;
    }
</style>--%>

<script type="text/javascript">
    //Financing
    //New General Financing
    function ShowGeneralFinancing() {
        try {
       
        PremiumFinanceLen.SetVisible(false);
        
        if (document.getElementById('<%=mhstatelbl.ClientID%>').innerText == 'NC') {
            PremiumFinanceLen.SetVisible(true);
        }

        if (document.getElementById('<%=mhstatelbl.ClientID%>').innerText == 'SC') {
            PremiumFinanceLen.SetVisible(true);
        }
       
        if (document.getElementById('<%=mhstatelbl.ClientID%>').innerText == 'VA') {
            PremiumFinanceLen.SetVisible(true);
        }

            PremiumFinancingPopup.Show();
        }
        catch (e) {
        PremiumFinancingPopup.Show();
        }
       
    }


    //Premium Finance Clicked
    function FinanceOptionClick() {
        $find('SCFinanceModal').show();
    }
    //Premium Finance Changed
    function FinanceOptionChange() {
        try {
            document.getElementById('<%=financebtn2.ClientID%>').click();
        }
        catch (err) {

        }
        

    }
function AR_UpdateOptions() {
     
           
            document.getElementById('<%=ar1_updateOptions.ClientID%>').style.display = '';
            document.getElementById('<%=ar2_updateOptions.ClientID%>').style.display = '';
            document.getElementById('<%=ar3_updateOptions.ClientID%>').style.display = '';
           

//            var e = document.getElementById('<%=dd_rep_AR1.ClientID%>');
//            var currentSelection = e.options[e.selectedIndex].text;

//            if (currentSelection == "Yes") {
//                //Show
//                //first option section

//                document.getElementById('<%=dd_sip_AR1.ClientID%>').SelectedValue = "No";
//                document.getElementById('<%=dd_sip_AR1.ClientID%>').Enabled = "False";
//            }
//            else {

//                document.getElementById('<%=dd_sip_AR1.ClientID%>').Enabled = "True";
//            }



        }
        function UpdateFR() {
            document.getElementById('<%=btn.ClientID%>').click();
        }
        function UpdatePP() {
            document.getElementById('<%=btnpp.ClientID%>').click();
        }
        function enterToTab(e) {
            var intKey = window.Event ? e.which : e.KeyCode;


            if (intKey == 13)
                e.returnValue = false;
        }
        function openCalcDesc(section) {

            if (section == 1) {

                document.getElementById('<%=AR1_Debug.ClientID%>').style.display = '';
                document.getElementById('<%=AR2_Debug.ClientID%>').style.display = 'none';
                document.getElementById('<%=AR3_Debug.ClientID%>').style.display = 'none';

            }
            if (section == 2) {

                document.getElementById('<%=AR2_Debug.ClientID%>').style.display = '';
                document.getElementById('<%=AR1_Debug.ClientID%>').style.display = 'none';
                document.getElementById('<%=AR3_Debug.ClientID%>').style.display = 'none';

            }
            if (section == 3) {
                document.getElementById('<%=AR3_Debug.ClientID%>').style.display = '';
                document.getElementById('<%=AR1_Debug.ClientID%>').style.display = 'none';
                document.getElementById('<%=AR2_Debug.ClientID%>').style.display = 'none';

            }
            $find('PremCalcModal').show();
        } //End openAROptions

        function AROptionsShow(section) {
            if (section == 1) {
                if (document.getElementById('lblARShowOptions1').innerText == "+ Show Options") {

                    //document.getElementById('').style.display = '';
                    document.getElementById('<%= ar_mh_prog1_Options.ClientID %>').style.display = '';
                    document.getElementById('<%= AROptionRow1.ClientID %>').style.display = '';
                    document.getElementById('<%= lblARShowOptions1_hidden.ClientID %>').value = '- Show Options';
                    document.getElementById('lblARShowOptions1').innerText = "- Show Options";

                }
                else {
                    //document.getElementById('AROptionRow1').style.display = 'none';
                    document.getElementById('<%= ar_mh_prog1_Options.ClientID %>').style.display = 'none';
                    document.getElementById('<%= AROptionRow1.ClientID %>').style.display = 'none';
                    document.getElementById('<%= lblARShowOptions1_hidden.ClientID %>').value = '+ Show Options';
                    document.getElementById('lblARShowOptions1').innerText = "+ Show Options";

                }
            }
            if (section == 2) {

                if (document.getElementById('lblARShowOptions2').innerText == "+ Show Options") {
                    document.getElementById('<%= ar_mh_prog2_Options.ClientID %>').style.display = '';
                    document.getElementById('<%= AROptionRow2.ClientID %>').style.display = '';
                    document.getElementById('lblARShowOptions2').innerText = "- Show Options";
                    document.getElementById('<%= lblARShowOptions2_hidden.ClientID %>').value = '- Show Options';
                }
                else {

                    document.getElementById('<%= ar_mh_prog2_Options.ClientID %>').style.display = 'none';
                    document.getElementById('<%= AROptionRow2.ClientID %>').style.display = 'none';
                    document.getElementById('lblARShowOptions2').innerText = "+ Show Options";
                    document.getElementById('<%= lblARShowOptions2_hidden.ClientID %>').value = '+ Show Options';
                }
            }
            if (section == 3) {
                if (document.getElementById('lblARShowOptions3').innerText == "+ Show Options") {
                    document.getElementById('<%= ar_mh_prog3_Options.ClientID %>').style.display = '';
                    document.getElementById('<%= AROptionRow3.ClientID %>').style.display = '';
                    document.getElementById('lblARShowOptions3').innerText = "- Show Options";
                    document.getElementById('<%= lblARShowOptions3_hidden.ClientID %>').value = '- Show Options';

                }
                else {

                    document.getElementById('<%= ar_mh_prog3_Options.ClientID %>').style.display = 'none';
                    document.getElementById('<%= AROptionRow3.ClientID %>').style.display = 'none';
                    document.getElementById('lblARShowOptions3').innerText = "+ Show Options";
                    document.getElementById('<%= lblARShowOptions3_hidden.ClientID %>').value = '+ Show Options';
                }
            }
            if (section == 4) {
                if (document.getElementById('lblSMHShowOptions4').innerText == "+ Show Options") {

                    //document.getElementById('').style.display = '';
                    document.getElementById('<%= SC08_mh_prog_Options.ClientID %>').style.display = '';
                    document.getElementById('<%= SC08OptionRow.ClientID %>').style.display = '';
                    document.getElementById('<%= lblSMHShowOptions4_hidden.ClientID %>').value = '- Show Options';
                    document.getElementById('lblSMHShowOptions4').innerText = "- Show Options";

                }

                else {
                    //document.getElementById('AROptionRow1').style.display = 'none';
                    document.getElementById('<%= SC08_mh_prog_Options.ClientID %>').style.display = 'none';
                    document.getElementById('<%= SC08OptionRow.ClientID %>').style.display = 'none';
                    document.getElementById('<%= lblSMHShowOptions4_hidden.ClientID %>').value = '+ Show Options';
                    document.getElementById('lblSMHShowOptions4').innerText = "+ Show Options";

                }
            }
            if (section == 5) {

                if (document.getElementById('lblaiges_ShowOptions2').innerText == "+ Show Options") {
                    document.getElementById('<%= aiges_mh_prog2_Options.ClientID %>').style.display = '';
                    document.getElementById('<%= Table1.ClientID %>').style.display = '';
                    document.getElementById('lblaiges_ShowOptions2').innerText = "- Show Options";
                    document.getElementById('<%= lblaiges_ShowOptions2_hidden.ClientID %>').value = '- Show Options';
                }
                else {

                    document.getElementById('<%= aiges_mh_prog2_Options.ClientID %>').style.display = 'none';
                    document.getElementById('<%= Table1.ClientID %>').style.display = 'none';
                    document.getElementById('lblaiges_ShowOptions2').innerText = "+ Show Options";
                    document.getElementById('<%= lblaiges_ShowOptions2_hidden.ClientID %>').value = '+ Show Options';
                }
            }
            if (section == 6) {

                if (document.getElementById('lblaiges_ShowOptions3').innerText == "+ Show Options") {
                    document.getElementById('<%= aiges_mh_prog3_Options1.ClientID %>').style.display = '';
                    document.getElementById('<%= Table2.ClientID %>').style.display = '';
                    document.getElementById('lblaiges_ShowOptions3').innerText = "- Show Options";
                    document.getElementById('<%= lblaiges_ShowOptions3_hidden.ClientID %>').value = '- Show Options';
                }
                else {

                    document.getElementById('<%= aiges_mh_prog3_Options1.ClientID %>').style.display = 'none';
                    document.getElementById('<%= Table2.ClientID %>').style.display = 'none';
                    document.getElementById('lblaiges_ShowOptions3').innerText = "+ Show Options";
                    document.getElementById('<%= lblaiges_ShowOptions3_hidden.ClientID %>').value = '+ Show Options';
                }

            }
            if (section == 7) {

                if (document.getElementById('lblamslicShowOptions').innerText == "+ Show Options") {
                    document.getElementById('<%= amslic_mh_prog_Options.ClientID %>').style.display = '';
                    document.getElementById('<%= amslicOptionRow.ClientID %>').style.display = '';
                    document.getElementById('lblamslicShowOptions').innerText = "- Show Options";
                    document.getElementById('<%= lblamslicShowOptions2_hidden.ClientID %>').value = '- Show Options';
                }
                else {

                    document.getElementById('<%= amslic_mh_prog_Options.ClientID %>').style.display = 'none';
                    document.getElementById('<%= amslicOptionRow.ClientID %>').style.display = 'none';
                    document.getElementById('lblamslicShowOptions').innerText = "+ Show Options";
                    document.getElementById('<%= lblamslicShowOptions2_hidden.ClientID %>').value = '+ Show Options';
                }
            }
            if (section == 8) {

                if (document.getElementById('lblamslicShowOptionsRent').innerText == "+ Show Options") {
                    document.getElementById('<%= amslic_mh_progRent_Options.ClientID %>').style.display = '';
                    document.getElementById('<%= amslicOptionRowRent.ClientID %>').style.display = '';
                    document.getElementById('lblamslicShowOptionsRent').innerText = "- Show Options";
                    document.getElementById('<%= lblamslicShowOptionsRent_hidden.ClientID %>').value = '- Show Options';
                }
                else {

                    document.getElementById('<%= amslic_mh_progRent_Options.ClientID %>').style.display = 'none';
                    document.getElementById('<%= amslicOptionRowRent.ClientID %>').style.display = 'none';
                    document.getElementById('lblamslicShowOptionsRent').innerText = "+ Show Options";
                    document.getElementById('<%= lblamslicShowOptionsRent_hidden.ClientID %>').value = '+ Show Options';
                }
            }
            if (section == 9) {

                if (document.getElementById('lblwmj_ShowOptions2').innerText == "+ Show Options") {
                    document.getElementById('<%= wmj_mh_prog2_Options.ClientID %>').style.display = '';
                    document.getElementById('<%= Table3.ClientID %>').style.display = '';
                    document.getElementById('lblwmj_ShowOptions2').innerText = "- Show Options";
                    document.getElementById('<%= lblwmj_ShowOptions2_hidden.ClientID %>').value = '- Show Options';
                }
                else {

                    document.getElementById('<%= wmj_mh_prog2_Options.ClientID %>').style.display = 'none';
                    document.getElementById('<%= Table3.ClientID %>').style.display = 'none';
                    document.getElementById('lblwmj_ShowOptions2').innerText = "+ Show Options";
                    document.getElementById('<%= lblwmj_ShowOptions2_hidden.ClientID %>').value = '+ Show Options';
                }
            }
            if (section == 10) {

                if (document.getElementById('lblwmj_ShowOptionsnc1').innerText == "+ Show Options") {
                    document.getElementById('<%= wmj_mh_prognc1_Options.ClientID %>').style.display = '';
                    document.getElementById('<%= WMJ_nc1_table.ClientID %>').style.display = '';
                    document.getElementById('lblwmj_ShowOptionsnc1').innerText = "- Show Options";
                    document.getElementById('<%= lblwmj_ShowOptionsnc1_hidden.ClientID %>').value = '- Show Options';
                }
                else {

                    document.getElementById('<%= wmj_mh_prognc1_Options.ClientID %>').style.display = 'none';
                    document.getElementById('<%= WMJ_nc1_table.ClientID %>').style.display = 'none';
                    document.getElementById('lblwmj_ShowOptionsnc1').innerText = "+ Show Options";
                    document.getElementById('<%= lblwmj_ShowOptionsnc1_hidden.ClientID %>').value = '+ Show Options';
                }
            }
            if (section == 11) {

                if (document.getElementById('lblwmj_ShowOptionsnc2').innerText == "+ Show Options") {
                    document.getElementById('<%= wmj_mh_prognc2_Options.ClientID %>').style.display = '';
                    document.getElementById('<%= WMJ_nc2_table.ClientID %>').style.display = '';
                    document.getElementById('lblwmj_ShowOptionsnc2').innerText = "- Show Options";
                    document.getElementById('<%= lblwmj_ShowOptionsnc2_hidden.ClientID %>').value = '- Show Options';
                }
                else {

                    document.getElementById('<%= wmj_mh_prognc2_Options.ClientID %>').style.display = 'none';
                    document.getElementById('<%= WMJ_nc2_table.ClientID %>').style.display = 'none';
                    document.getElementById('lblwmj_ShowOptionsnc2').innerText = "+ Show Options";
                    document.getElementById('<%= lblwmj_ShowOptionsnc2_hidden.ClientID %>').value = '+ Show Options';
                }
            }
            if (section == 12) {

                if (document.getElementById('lblwmj_ShowOptionsnc3').innerText == "+ Show Options") {
                    document.getElementById('<%= wmj_mh_prognc3_Options.ClientID %>').style.display = '';
                    document.getElementById('<%= WMJ_nc3_table.ClientID %>').style.display = '';
                    document.getElementById('lblwmj_ShowOptionsnc3').innerText = "- Show Options";
                    document.getElementById('<%= lblwmj_ShowOptionsnc3_hidden.ClientID %>').value = '- Show Options';
                }
                else {

                    document.getElementById('<%= wmj_mh_prognc3_Options.ClientID %>').style.display = 'none';
                    document.getElementById('<%= WMJ_nc3_table.ClientID %>').style.display = 'none';
                    document.getElementById('lblwmj_ShowOptionsnc3').innerText = "+ Show Options";
                    document.getElementById('<%= lblwmj_ShowOptionsnc3_hidden.ClientID %>').value = '+ Show Options';
                }
            }
            if (section == 13) {
                if (document.getElementById('lblAegisvint_ShowOptionssc1').innerText == "+ Show Options") {
            
                    //document.getElementById('').style.display = '';
                    document.getElementById('<%= Aegisvint_mh_progsc1_Options.ClientID %>').style.display = '';
                    document.getElementById('<%= Aegisvint_sc1_table.ClientID %>').style.display = '';
                    document.getElementById('<%= lblAegisvint_ShowOptionssc1_hidden.ClientID %>').value = '- Show Options';
                    document.getElementById('lblAegisvint_ShowOptionssc1').innerText = "- Show Options";

                }
                else {
                    //document.getElementById('AROptionRow1').style.display = 'none';
                    document.getElementById('<%= Aegisvint_mh_progsc1_Options.ClientID %>').style.display = 'none';
                    document.getElementById('<%= Aegisvint_sc1_table.ClientID %>').style.display = 'none';
                    document.getElementById('<%= lblAegisvint_ShowOptionssc1_hidden.ClientID %>').value = '+ Show Options';
                    document.getElementById('lblAegisvint_ShowOptionssc1').innerText = "+ Show Options";

                }
            }
        }
</script>
   
<body onkeydown="enterToTab(event);" />
  
<asp:UpdatePanel ID="AR_PremiumUpdatePanel" runat="server" UpdateMode="Conditional">
                                <ContentTemplate>
                                    <table id="premiumBtnTable" runat="server" style="display: none;" align="center">
                                        <tbody>
                                            <tr>
                                                <td>
                                                    <asp:Label ID="Label75" runat="server" Text="Selected Program: " CssClass="label" Font-Size="Large"></asp:Label>
                                                    &nbsp;
                                                    <asp:Label ID="rateTypelbl" runat="server" Text="" CssClass="label" Font-Size="Large" Font-Bold="true"></asp:Label>
                                                </td>
                                                <td>
                                                   
                                                    &nbsp;
                                                </td>
                                                <td>
                                                    <asp:Button ID="printbtn1" runat="server" OnClick="printbtn_Click" Text="Print Quote" />
                                                    
                                                </td>
                                                <td>
                                                    <asp:Button ID="SCPremFinbtn" runat="server" Visible="false"  OnClientClick="FinanceOptionClick(); return false;" Text="Calculate Financing Old" />
                                                    <%--Start Finance Popup--%>
                                                     <dx:ASPxPopupControl ID="SCFinancePop" runat="server" PopupElementID="SCPremFinbtn" AllowDragging="True" HeaderText = " Premium Finance Calculation"
                                                                          MaxWidth="800px" MaxHeight="1800px" MinHeight="150px" MinWidth="150px" ShowFooter="false" Width="550px" Height="330px" >
                                                                    <ContentCollection>
                                                                        <dx:PopupControlContentControl ID="PopupControlContentControl6" runat="server" SupportsDisabledAttribute="True">
                                                                        <asp:Panel ID="SCFinancingPopup" runat="server" CssClass="modalPopup" Width="100%" ClientIDMode="Static" Visible="false">
                                                                                    <ContentTemplate>
                                                                                           <div style="padding: 5px">
                                                                                                <div style="font-size: 10pt">
                                                                                                    <br />
                                                                                                    <!--FINANCE TABLE-->
                                                                                                    <table>
                                                                                                        <tbody>
                                                                                                            <tr>
                                                                                                                <td>
                                                                                                                    <table>
                                                                                                                        <tbody>
                                                                                                                            <tr>
                                                                                                                                <td>
                                                                                                                                    <asp:Label ID="Label27" runat="server" Text="Payment Plan!:" Font-Bold="True"></asp:Label>
                                                                                                                                </td>
                                                                                                                            </tr>
                                                                                                                            <tr>
                                                                                                                                <td>
                                                                                                                                    <asp:RadioButtonList ID="DownPaymentPercentRB" runat="Server" ClientIDMode="Static">
                                                                                                                                        <asp:ListItem Text="25% Down" Value="25% Down"></asp:ListItem>
                                                                                                                                        <asp:ListItem Text="40% Down" Value="40% Down"></asp:ListItem>
                                                                                                                                        <asp:ListItem Text="50% Down" Value="50% Down"></asp:ListItem>
                                                                                                                                    </asp:RadioButtonList>
                                                                                                                                </td>
                                                                                                                                <td>
                                                                                                                                </td>
                                                                                                                                <td>
                                                                                                                                </td>
                                                                                                                                <td>
                                                                                                                                </td>
                                                                                                                                <td>
                                                                                                                                </td>
                                                                                                                                <td>
                                                                                                                                    <asp:RadioButtonList ID="FinanceLengthRB" runat="Server" ClientIDMode="Static">
                                                                                                                                        <asp:ListItem Text="3 Months" Value="3 Months"></asp:ListItem>
                                                                                                                                        <asp:ListItem Text="6 Months" Value="6 Months"></asp:ListItem>
                                                                                                                                        <asp:ListItem Text="8 Months" Value="8 Months"></asp:ListItem>
                                                                                                                                    </asp:RadioButtonList>
                                                                                                                                </td>
                                                                                                                                <td>
                                                                                                                                </td>
                                                                                                                                <td>
                                                                                                                                </td>
                                                                                                                                <td>
                                                                                                                                </td>
                                                                                                                                <td>
                                                                                                                                </td>
                                                                                                                            </tr>
                                                                                                                        </tbody>
                                                                                                                    </table>
                                                                                                                </td>
                                                                                                                <td>
                                                                                                                    <table>
                                                                                                                        <tbody>
                                                                                                                            <tr>
                                                                                                                                <td>
                                                                                                                                    <asp:Label ID="Label174" runat="server" Text="Annual Premium: " CssClass="AR_Application"></asp:Label>&nbsp;
                                                                                                                                </td>
                                                                                                                                <td align="right">
                                                                                                                                    <asp:Label ID="lblAnnualPremiumLLOYD" runat="server" Casing="Normal" CssClass="AR_Application"
                                                                                                                                        DataFieldName="AnnualPremiumLLOYDS" />
                                                                                                                                </td>
                                                                                                                            </tr>
                                                                                                                            <tr>
                                                                                                                                <td>
                                                                                                                                    <asp:Label ID="Label175" runat="server" Text="Down Payment: " CssClass="AR_Application"></asp:Label>
                                                                                                                                </td>
                                                                                                                                <td align="right">
                                                                                                                                    <asp:Label ID="lblDownPaymentLLOYD" runat="server" Casing="Normal" CssClass="AR_Application"
                                                                                                                                        DataFieldName="DownPaymentLLOYDS" />
                                                                                                                                </td>
                                                                                                                            </tr>
                                                                                                                            <tr>
                                                                                                                                <td>
                                                                                                                                    <asp:Label ID="Label176" runat="server" Text="Amount Financed: " CssClass="AR_Application"></asp:Label>
                                                                                                                                </td>
                                                                                                                                <td align="right">
                                                                                                                                    <asp:Label ID="lblAmountFinancedLLOYD" runat="server" Casing="Normal" CssClass="AR_Application"
                                                                                                                                        DataFieldName="AmountFinancedLLOYDS" />
                                                                                                                                </td>
                                                                                                                            </tr>
                                                                                                                            <tr>
                                                                                                                                <td>
                                                                                                                                    <asp:Label ID="Label177" runat="server" Text="Finance Charge: " CssClass="AR_Application"></asp:Label>
                                                                                                                                </td>
                                                                                                                                <td align="right">
                                                                                                                                    <asp:Label ID="lblFinanceChargeLLOYD" runat="server" Casing="Normal" CssClass="AR_Application"
                                                                                                                                        DataFieldName="FinanceChargeLLOYDS" />
                                                                                                                                </td>
                                                                                                                            </tr>
                                                                                                                            <tr>
                                                                                                                                <td>
                                                                                                                                    <asp:Label ID="Label178" runat="server" Text="Total of Payments: " CssClass="AR_Application"></asp:Label>
                                                                                                                                </td>
                                                                                                                                <td align="right">
                                                                                                                                    <asp:Label ID="lblTotalOfPayments" runat="server" CssClass="AR_Application" DataFieldName="TotalOfPayments"></asp:Label>
                                                                                                                                </td>
                                                                                                                            </tr>
                                                                                                                            <tr>
                                                                                                                                <td>
                                                                                                                                    <asp:Label ID="Label179" runat="server" Text="Monthly Payment: " CssClass="AR_Application"></asp:Label>
                                                                                                                                </td>
                                                                                                                                <td align="right">
                                                                                                                                    <asp:Label ID="lblMonthlyPayment" runat="server" CssClass="AR_Application" DataFieldName="MonthlyPayment"></asp:Label>
                                                                                                                                </td>
                                                                                                                            </tr>
                                                                                                                            <tr>
                                                                                                                                <td>
                                                                                                                                    <asp:Label ID="Label180" runat="server" Text="Annual % Rate:" CssClass="AR_Application"></asp:Label>
                                                                                                                                </td>
                                                                                                                                <td align="right">
                                                                                                                                    <asp:Label ID="lblAnnualRate" runat="server" DataFieldName="AnnualRate" CssClass="AR_Application"></asp:Label>
                                                                                                                                </td>
                                                                                                                            </tr>
                                                                                                                        </tbody>
                                                                                                                    </table>
                                                                                                                </td>
                                                                                                            </tr>
                                                                                                        </tbody>
                                                                                                    </table>
                                                                                                    <!--END FINANCE TABLE-->
                               
                                                                                                </div>
                                                                                            </div>
                                                                                    </ContentTemplate>
                                                                                    <Triggers>
                                                                                        <asp:AsyncPostBackTrigger ControlID="financebtn2" EventName="Click" />
                                                                                    </Triggers>      
                     
                                                                               </asp:Panel>
                                                                        </dx:PopupControlContentControl>
                                                                    </ContentCollection>
                                                                </dx:ASPxPopupControl>
                                                  <%--  End Finance Popup--%>
                                        <asp:Button ID="Button4" Text="getZip" runat="server" Style="display: none" />
                                        <asp:Button ID="financebtn2" Text="getZip" runat="server" Style="display: none" />
                                                </td>
                                                <td>
                                                <dx:ASPxButton runat="server" ID="premCalcbtn" Text="Calculate Financing">
                                                <ClientSideEvents Click="function(s, e) { ShowGeneralFinancing(); }" />
                                                 </dx:ASPxButton>
                                                </td>
                                               
                                                <td>
                        <!--<asp:Button ID="premFinbtn" runat="server" OnClick="printFinbtn_Click" Text="Print Finance Contract" />-->
                        <dx:ASPxLoadingPanel ID="LoadingPanel" runat="server" ClientInstanceName="LoadingPanel" Modal="True">
                        </dx:ASPxLoadingPanel>
                        <dx:ASPxCallback ID="ASPxCallback1" runat="server" ClientInstanceName="Callback">
                            <ClientSideEvents CallbackComplete="function(s, e) { LoadingPanel.Hide(); }" />
                        </dx:ASPxCallback>
                        <asp:Panel ID="FinancePopup" runat="server" CssClass="modalPopup" Width="100%" ClientIDMode="Static">
                            <asp:UpdatePanel ID="financeupdatePanel" runat="server" UpdateMode="Conditional">
                                <ContentTemplate>
                                    <div style="padding: 5px">
                                        <div style="font-size: 10pt">
                                            Premium Finance Calculation
                                            <br />
                                            <asp:Label ID="financeInfo" runat="server" ClientIDMode="Static" Text=""></asp:Label>
                                            <br />
                                            <asp:RadioButtonList ID="primeRateDPDD" runat="Server" ClientIDMode="Static" OnTextChanged="updatePrimeRateDownPayment"
                            OnSelectedIndexChanged="updatePrimeRateDownPayment">
                            <asp:ListItem Text="25% Down" Value="25% Down"></asp:ListItem>
                            <asp:ListItem Text="40% Down" Value="40% Down"></asp:ListItem>
                            <asp:ListItem Text="50% Down" Value="50% Down"></asp:ListItem>
                        </asp:RadioButtonList>
                                        </div>
                                    </div>
                                </ContentTemplate>
                            </asp:UpdatePanel>
                            <center>
                             <dx:ASPxButton ID="FinUpBtn" runat="server" Text="Recalculate" AutoPostBack="False">
                                <ClientSideEvents Click="function(s, e) {Callback.PerformCallback();LoadingPanel.Show();}" />
                            </dx:ASPxButton>
                            <asp:Button ID="FinCloseBtn" runat="server" CausesValidation="false" Text="Close" />
                            </center>
                        </asp:Panel>
                        <!--Finance Details Modal Popup -->
                        <ajaxTK:ModalPopupExtender ID="ModalPopupExtender3" runat="server" BehaviorID="FinanceModalLloyds"
                            TargetControlID="Button3" BackgroundCssClass="modalBackground" CancelControlID="FinCloseBtn"
                            DropShadow="True" DynamicServicePath="" Enabled="True" PopupControlID="FinancePopup"
                            RepositionMode="RepositionOnWindowScroll" />
                        <asp:Button ID="Button3" runat="server" Style="display: none" CausesValidation="false"
                            Text="OK" />
                    </td>
                                                <td>
                                                <asp:Button ID="btnBeforeApp" runat="server"  CausesValidation="false" Text="Proceed to App" OnClick="btnBeforeApp_Click"/>
                                                     </td>
                                                <td>
                                                    <asp:HiddenField ID="HiddenFieldSelected" runat="server" Value="" ClientIDMode="Static"/>
                                                    <%--<input id="ar_mh_progbtn1" type="button" value="Proceed to App" onclick="openAROptions();" onclick="return ar_mh_progbtn1_onclick()" />--%>
                                                
                                                </td>
                                            </tr>
                                        </tbody>
                                    </table>
                                    <table width="100%" cellpadding="0" cellspacing="0" style="border: 1px solid black;"
                                        bgcolor="white" title="AR Amounts">
                                        <tbody>
                                            <tr id="ar_headerRow" style="border: 1px solid black" title="HeaderRow">
                                                <td align="center" width="251px">
                                                </td>
                                                <td align="center" style="border: 1px solid black; color: White; background-color: #4169E1;">
                                                    <asp:Label ID="Label67" runat="server" Text="Program" CssClass="label" />
                                                </td>
                                                <td align="center" style="border: 1px solid black; color: White; background-color: #4169E1;">
                                                    <asp:Label ID="Label81" runat="server" Text="Dwelling " CssClass="label" />
                                                </td>
                                                <td align="center" 
                                                    style="border: 1px solid black; color: White; background-color: #4169E1;" 
                                                    class="style3">
                                                    <asp:Label ID="Label85" runat="server" Text="Other <br/>Structures" CssClass="label" />
                                                </td>
                                                <td align="center" style="border: 1px solid black; color: White; background-color: #4169E1;">
                                                    <asp:Label ID="Label87" runat="server" Text="Contents" CssClass="label" />
                                                </td>
                                                <td align="center" style="border: 1px solid black; color: White; background-color: #4169E1;">
                                                    <asp:Label ID="Label83" runat="server" Text="Liability" CssClass="label" />
                                                </td>
                                                <td align="center" style="border: 1px solid black; color: White; background-color: #4169E1;">
                                                    <asp:Label ID="Label84" runat="server" Text="Med Pay" CssClass="label" />
                                                </td>
                                                <td align="center" style="border: 1px solid black; color: White; background-color: #4169E1;">
                                                    <asp:Label ID="Label89" runat="server" Text="Base Premium" CssClass="label" />
                                                </td>
                                                <td align="center" style="border: 1px solid black; color: White; background-color: #4169E1;">
                                                    <asp:Label ID="Label91" runat="server" Text="Options" CssClass="label" />
                                                </td>
                                                <td align="center" style="border: 1px solid black; color: White; background-color: #4169E1;">
                                                    <asp:Label ID="Label93" runat="server" Text="Fees" CssClass="label" />
                                                </td>
                                                <td align="center" style="border: 1px solid black; color: White; background-color: #4169E1;">
                                                    <asp:Label ID="Label107" runat="server" Text="Taxes" CssClass="label" />
                                                </td>
                                                <td align="center" style="border: 1px solid black; color: White; background-color: #4169E1;">
                                                    <asp:Label ID="Label102" runat="server" Text="Total" CssClass="labelTotal" />
                                                </td>
                                                <td align="center" style="border: 1px solid black; color: White; background-color: #4169E1;">
                                                </td>
                                            </tr>
                                            <tr id="ar_mh_prog1" runat="server" style="border: 1px solid black;">
                                                <td align="center" style="border: 1px solid" width="251px">
                                                    <label id="lblARShowOptions1" runat="server" style="color: Blue; cursor: pointer;"
                                                        onclick="AROptionsShow(1);" clientidmode="Static">
                                                        - Show Options</label>
                                                    <asp:HiddenField ID="lblARShowOptions1_hidden" runat="server" Value="+ Show Options" />
                                                </td>
                                                <td align="center" style="border: 1px solid">
                                                    <asp:Label ID="Label61" runat="server" Text="Lloyds Package" CssClass="labelCov" />
                                                </td>
                                                <td align="center" style="border: 1px solid">
                                                    <asp:Label ID="ar_dwell1" runat="server" Text="0.00" ClientIDMode="Static" CssClass="labelCov" />
                                                </td>
                                                <td align="center" style="border: 1px solid" class="style3">
                                                    <asp:Label ID="ar_unattStr1" runat="server" Text="0.00" ClientIDMode="Static" CssClass="labelCov" />
                                                </td>
                                                <td align="center" style="border: 1px solid">
                                                    <asp:Label ID="ar_perEff1" runat="server" Text="0.00" ClientIDMode="Static" CssClass="labelCov" />
                                                </td>
                                                <td align="center" style="border: 1px solid;">
                                                    <asp:Label ID="ar_perLiab1" runat="server" Text="0.00" ClientIDMode="Static" CssClass="labelCov" />
                                                </td>
                                                <td align="center" style="border: 1px solid">
                                                    <asp:Label ID="ar_medpay1" runat="server" Text="0.00" ClientIDMode="Static" CssClass="labelCov" />
                                                </td>
                                                <td align="center" style="border: 1px solid">
                                                    <asp:Label ID="ar_baseprem1" runat="server" Text="0.00" ClientIDMode="Static" CssClass="labelCov" />
                                                </td>
                                                <td align="center" style="border: 1px solid">
                                                    <asp:Label ID="ar_options1" runat="server" Text="0.00" ClientIDMode="Static" CssClass="labelCov" />
                                                </td>
                                                <td align="center" style="border: 1px solid">
                                                    <asp:Label ID="ar_fees1" runat="server" Text="0.00" ClientIDMode="Static" CssClass="labelCov" />
                                                </td>
                                                <td align="center" style="border: 1px solid">
                                                    <asp:Label ID="ar_tax1" runat="server" Text="0.00" ClientIDMode="Static" CssClass="labelCov" />
                                                </td>
                                                <td align="center" style="border: 1px solid">
                                                    <asp:Label ID="ar_total1" runat="server" Text="0.00" ClientIDMode="Static" CssClass="labelTotal" />
                                                </td>
                                                <td align="center" style="border: 1px solid">
                                                    <asp:Button ID="selectAR1btn" runat="server" OnClick="selectAR1btn_Click" Text="Select" />
                                                </td>
                                            </tr>
                                            <tr id="ar_mh_prog1_Options" runat="server" clientidmode="Static">
                                                <td colspan="13">
                                                    <table id="AROptionRow1" runat="server" width="auto" cellpadding="0" cellspacing="0"
                                                        clientidmode="Static" bgcolor="white" title="AR Options">
                                                        <tbody>
                                                            <tr>
                                                                <td align="left">
                                                                    <input id="btnShow" type="button" value="Open Calc Detail"  />
                                                                    <asp:Label ID="txt_dwell_AR1_Amount" runat="server" Text="0.00" CssClass="label" Style="display:none" />
                                                                    &nbsp;
                                                                    <asp:Label ID="txt_DedChange_AR1_Amount" runat="server" Text="0.00" CssClass="label" Style="display:none" />
                                                                    &nbsp;
                                                                    <asp:Label ID="txt_Credit_AR1_Amount" runat="server" Text="0.00" CssClass="label" Style="display:none" />
                                                                    &nbsp;
                                                                
                                                                 <dx:ASPxPopupControl ID="ASPxPopupControl3" runat="server" PopupElementID="btnShow" HeaderText="Package Calculations" PopupVerticalAlign="Below" PopupHorizontalAlign="LeftSides" AllowDragging="True"
                                                                          MaxWidth="800px" MaxHeight="1800px" MinHeight="150px" MinWidth="150px" ShowFooter="True" >
                                                                    <ContentCollection>
                                                                        <dx:PopupControlContentControl ID="PopupControlContentControl3" runat="server">
                                                                            <asp:Panel ID="Panel3" runat="server">
                                                                                <table border="0" cellpadding="4" cellspacing="0">
                                                                                    <tr>
                                                                                        <td valign="top">
                                                                                            
                                                                                            <asp:Label ID="AR1_Debug" runat="server" ClientIDMode="Static" Text=""></asp:Label>
                                                                                        </td>
                                                                                    </tr>
                                                                                  
                                                                                </table>
                                                                            </asp:Panel>
                                                                        </dx:PopupControlContentControl>
                                                                    </ContentCollection>

                                                                    </dx:ASPxPopupControl>
                                                                    </td>
                                                            </tr>
                                                            <tr>
                                                                <td align="left">
                                                                    <asp:Label ID="Label64" runat="server" Text="AOP Deductible" CssClass="label" />
                                                                </td>
                                                                <td align="left">
                                                                    <asp:DropDownList ID="dd_aop_AR1" runat="server" ClientIDMode="Static" 
                                                                        TabIndex="100">
                                                                        <asp:ListItem>$500</asp:ListItem>
                                                                        <asp:ListItem>$1000</asp:ListItem>
                                                                    </asp:DropDownList>
                                                                     &nbsp;
                                                                    <asp:Label ID="dd_aop_AR1_Amount" runat="server" Text="0.00" CssClass="label" />
                                                                    &nbsp;
                                                                </td>
                                                            </tr>
                                                            <tr>
                                                                <td align="left">
                                                                    <asp:Label ID="Label63" runat="server" Text="Wind/Hail Deductible" CssClass="label" />
                                                                </td>
                                                                <td align="left">
                                                                    <asp:textbox ID="dd_hurded_AR1" runat="server" Text="0.00" 
                                                                        AutoCompleteType="DisplayName" Enabled="false" TabIndex="101" />
                                                                                                                                      
                                                                </td>
                                                            </tr>
                                                            <tr id="tstorm1">
                                                                <td align="left">
                                                                    <asp:Label ID="Label6" runat="server" Text="Hurricane/Tropical Storm" CssClass="label" />
                                                                </td>
                                                                <td align="left">
                                                                    <asp:TextBox ID="dd_thur_ar1" runat="server" Text="0.00" 
                                                                        AutoCompleteType="DisplayName" Enabled="false" TabIndex="102" />
                                                                </td>
                                                            </tr>
                                                            <tr id="trlossofuse">
                                                                <td align="left">
                                                                    <asp:Label ID="Label8" runat="server" Text="Loss of Use" CssClass="label" />
                                                                </td>
                                                                <td align="left">
                                                                    <asp:TextBox ID="txtlossofuse" runat="server" Text="0.00" 
                                                                        AutoCompleteType="DisplayName" Enabled="false" TabIndex="103" />
                                                                </td>
                                                            </tr>
                                                            <tr>
                                                                <td>
                                                                    &nbsp;
                                                                </td>
                                                            </tr>
                                                            <tr>
                                                                <td align="left">
                                                                    <asp:Label ID="Label108" runat="server" Text="Personal Liability:  " CssClass="label" />
                                                                    &nbsp
                                                                </td>
                                                                <td align="left">
                                                                    <asp:DropDownList ID="dd_pl_AR1" runat="server" ClientIDMode="Static" 
                                                                        TabIndex="104">
                                                                        <asp:ListItem>$25,000</asp:ListItem>
                                                                        <asp:ListItem>$50,000</asp:ListItem>
                                                                        <asp:ListItem>$100,000</asp:ListItem>
                                                                       
                                                                    </asp:DropDownList>
                                                                    &nbsp;
                                                                    <asp:Label ID="dd_pl_AR1_Amount" runat="server" Text="0.00" CssClass="label" />
                                                                    &nbsp;
                                                                </td>
                                                            </tr>
                                                            <tr>
                                                                <td align="left" class="style2">
                                                                    <asp:Label ID="Label148" runat="server" Text="Medical payment:  " CssClass="label" />
                                                                    &nbsp
                                                                </td>
                                                                <td align="left" class="style2">
                                                                    <asp:DropDownList ID="dd_mp_AR1" runat="server" ClientIDMode="Static" 
                                                                        TabIndex="105">
                                                                        <asp:ListItem>$500</asp:ListItem>
                                                                        <asp:ListItem>$1000</asp:ListItem>
                                                                    </asp:DropDownList>
                                                                     &nbsp;
                                                                    <asp:Label ID="dd_med_AR1_amt" runat="server" Text="0.00" CssClass="label" />
                                                                    &nbsp;
                                                                </td>
                                                            </tr>
                                                            <tr>
                                                                <td>
                                                                    &nbsp;
                                                                </td>
                                                            </tr>
                                                            <tr>
                                                                <td align="left">
                                                                    <asp:Label ID="Label65" runat="server" Text="Increase Other Structures:  " CssClass="label" />
                                                                    &nbsp
                                                                </td>
                                                                <td align="left" style="margin-left: 40px">
                                                                    <asp:TextBox ID="txt_unattstr_AR1" runat="server" Text="0.00" AutoCompleteType="DisplayName"
                                                                        ClientIDMode="Static" Casing="UPPER" ToolTip="Add'l Other Structures" Width="65"
                                                                        TabIndex="106" />
                                                                    &nbsp;<asp:Label ID="txt_unattstr_AR1_Amount" runat="server" Text="0.00" CssClass="label" />
                                                                    &nbsp;
                                                                </td>
                                                            </tr>
                                                            <tr style="border: 1px solid;">
                                                                <td align="left">
                                                                    <asp:Label ID="Label104" runat="server" Text="Increase Contents:  " CssClass="label" />
                                                                    &nbsp
                                                                </td>
                                                                <td align="left">
                                                                    <asp:TextBox ID="txt_pp_AR1" runat="server" Text="0.00" AutoCompleteType="DisplayName"
                                                                        ClientIDMode="Static" Casing="UPPER" ToolTip="Personal Property" 
                                                                        Width="65" TabIndex="107" />
                                                                    &nbsp;
                                                                    <asp:Label ID="txt_pp_AR1_Amount" runat="server" Text="0.00" CssClass="label" />
                                                                    &nbsp;
                                                                </td>
                                                            </tr>
                                                            <tr>
                                                                <td>
                                                                    &nbsp;
                                                                </td>
                                                            </tr>
                                                            <tr>
                                                                <td align="left">
                                                                    <asp:Label ID="Label98" runat="server" Text="Mobile Home Replacement Cost:  " CssClass="label" />
                                                                    &nbsp
                                                                </td>
                                                                <td align="left">
                                                                    <asp:DropDownList ID="dd_mhr_AR1" runat="server" TabIndex="108" 
                                                                        ClientIDMode="Static">
                                                                        <asp:ListItem>No</asp:ListItem>
                                                                        <asp:ListItem>Yes</asp:ListItem>
                                                                    </asp:DropDownList>
                                                                    &nbsp;
                                                                    <asp:Label ID="dd_mhr_AR1_Amount" runat="server" Text="0.00" CssClass="label" />
                                                                    &nbsp;
                                                                </td>
                                                            </tr>
                                                            <tr>
                                                                <td align="left">
                                                                    <asp:Label ID="Label100" runat="server" Text="Contents Replacement Cost:  " CssClass="label" />
                                                                    &nbsp
                                                                </td>
                                                                <td align="left">
                                                                    <asp:DropDownList ID="dd_rep_AR1" runat="server" TabIndex="109" OnSelectedIndexChanged="replacechange" onchange="return AR_UpdateOptions();"
                                                                        ClientIDMode="Static">
                                                                        <asp:ListItem>No</asp:ListItem>
                                                                        <asp:ListItem>Yes</asp:ListItem>
                                                                    </asp:DropDownList>
                                                                    &nbsp;
                                                                    <asp:Label ID="dd_rep_AR1_Amount" runat="server" Text="0.00" CssClass="label" />
                                                                    &nbsp;
                                                                  
                                                                </td>
                                                            </tr>
                                                            
                                                            <tr>
                                                                <td id="trmhAROpt1_2" style="display: " align="left" clientidmode="Static">
                                                                    <asp:Label ID="Label92" runat="server" Text="Full Repair:  " CssClass="label" />
                                                                    &nbsp
                                                                </td>
                                                                <td id="trmhAROpt1_2_d" style="display: " align="left" clientidmode="Static">
                                                                    <asp:DropDownList ID="dd_sip_AR1" runat="server" TabIndex="110" 
                                                                        ClientIDMode="Static">
                                                                        <asp:ListItem>No</asp:ListItem>
                                                                        <asp:ListItem>Yes</asp:ListItem>
                                                                    </asp:DropDownList>
                                                                    &nbsp;
                                                                    <asp:Label ID="dd_sip_AR1_Amount" runat="server" Text="0.00" CssClass="label" />
                                                                    &nbsp;
                                                                </td>
                                                            </tr>
                                                                   
                                                            <tr>
                                                                <td align="left">
                                                                    <asp:Button ID="ar1_updateOptions" runat="server" CausesValidation="false"
                                                                        Text="Update Optional Coverages" OnClick="ar_premiumbtnClick" 
                                                                        TabIndex="11" />
                                                                </td>
                                                                <td>
                                                                    <asp:Label ID="lblchange" runat="server" style="color: Red" Text=""></asp:Label>
                                                                </td>
                                                            </tr>
                                                        </tbody>
                                                    </table>
                                                </td>
                                            </tr>
                                            <tr id="ar_mh_prog2" runat="server" style="border: 1px solid black;">
                                                <td align="center" style="border: 1px solid" width="251px">
                                                    <label id="lblARShowOptions2" runat="server" style="color: Blue; cursor: pointer;"
                                                        onclick="AROptionsShow(2);" clientidmode="Static">
                                                        - Show Options</label>
                                                    <asp:HiddenField ID="lblARShowOptions2_hidden" runat="server" Value="+ Show Options" />
                                                </td>
                                                <td align="center" style="border: 1px solid">
                                                    <asp:Label ID="Label82" runat="server" Text="Lloyds Standard" CssClass="labelCov" />
                                                </td>
                                                <td align="center" style="border: 1px solid">
                                                    <asp:Label ID="ar_dwell2" runat="server" Text="0.00" CssClass="labelCov" />
                                                </td>
                                                <td align="center" style="border: 1px solid" class="style3">
                                                    <asp:Label ID="ar_unattStr2" runat="server" Text="0.00" CssClass="labelCov" />
                                                </td>
                                                <td align="center" style="border: 1px solid">
                                                    <asp:Label ID="ar_perEff2" runat="server" Text="0.00" CssClass="labelCov" />
                                                </td>
                                                <td align="center" style="border: 1px solid;">
                                                    <asp:Label ID="ar_perLiab2" runat="server" Text="0.00" CssClass="labelCov" />
                                                </td>
                                                <td align="center" style="border: 1px solid">
                                                    <asp:Label ID="ar_medpay2" runat="server" Text="0.00" CssClass="labelCov" />
                                                </td>
                                                <td align="center" style="border: 1px solid">
                                                    <asp:Label ID="ar_baseprem2" runat="server" Text="0.00" CssClass="labelCov" />
                                                </td>
                                                <td align="center" style="border: 1px solid">
                                                    <asp:Label ID="ar_options2" runat="server" Text="0.00" CssClass="labelCov" />
                                                </td>
                                                <td align="center" style="border: 1px solid">
                                                    <asp:Label ID="ar_fees2" runat="server" Text="0.00" CssClass="labelCov" />
                                                </td>
                                                <td align="center" style="border: 1px solid">
                                                    <asp:Label ID="ar_tax2" runat="server" Text="0.00" CssClass="labelCov" />
                                                </td>
                                                <td align="center" style="border: 1px solid">
                                                    <asp:Label ID="ar_total2" runat="server" Text="0.00" CssClass="labelTotal" />
                                                </td>
                                                <td align="center" style="border: 1px solid">
                                                    <asp:Button ID="selectAR2btn" runat="server" OnClick="selectAR2btn_Click" Text="Select" />
                                                </td>
                                            </tr>
                                            <tr id="ar_mh_prog2_Options" runat="server" clientidmode="Static">
                                                <td colspan="13">
                                                    <table id="AROptionRow2" runat="server" width="auto" cellpadding="0" cellspacing="0"
                                                        clientidmode="Static" bgcolor="white" title="AR Options">
                                                        <tbody>
                                                            <tr>
                                                                <td align="left">
                                                                    <input id="Button1" type="button" value="Open Calc Detail"  />
                                                                    <asp:Label ID="txt_dwell_AR2_Amount" runat="server" Text="0.00" CssClass="label" Style="display:none" />
                                                                    &nbsp;
                                                                    <asp:Label ID="txt_DedChange_AR2_Amount" runat="server" Text="0.00" CssClass="label" Style="display:none" />
                                                                    <asp:Label ID="txt_Credit_AR2_Amount" runat="server" Text="0.00" CssClass="label" Style="display:none" />
                                                                    &nbsp;
                                                                    <dx:ASPxPopupControl ID="ASPxPopupControl1" runat="server" PopupElementID="Button1" HeaderText="Standard Calculations" PopupVerticalAlign="Below" PopupHorizontalAlign="LeftSides" AllowDragging="True"
                                                                          MaxWidth="800px" MaxHeight="1800px" MinHeight="150px" MinWidth="150px" ShowFooter="True" Width="250px" Height="130px" >
                                                                    <ContentCollection>
                                                                        <dx:PopupControlContentControl ID="PopupControlContentControl1" runat="server">
                                                                            <asp:Panel ID="Panel1" runat="server">
                                                                                <table border="0" cellpadding="4" cellspacing="0">
                                                                                    <tr>
                                                                                        <td valign="top">
                                                                                            
                                                                                            <asp:Label ID="AR2_Debug" runat="server" ClientIDMode="Static" Text=""></asp:Label>
                                                                                        </td>
                                                                                    </tr>
                                                                                  
                                                                                </table>
                                                                            </asp:Panel>
                                                                        </dx:PopupControlContentControl>
                                                                    </ContentCollection>

                                                                    </dx:ASPxPopupControl>
                                                                </td>
                                                            </tr>
                                                            <tr>
                                                                <td align="left">
                                                                    <asp:Label ID="Label90" runat="server" Text="AOP Deductible" CssClass="label" />
                                                                </td>
                                                                <td align="left">
                                                                    <asp:DropDownList ID="dd_aop_AR2" runat="server" TabIndex="112">
                                                                        <asp:ListItem>$500</asp:ListItem>
                                                                        <asp:ListItem>$1000</asp:ListItem>
                                                                    </asp:DropDownList>
                                                                     &nbsp;<asp:Label ID="dd_aop_AR2_Amount" runat="server" Text="0.00" CssClass="label" />
                                                                    &nbsp;
                                                                </td>
                                                            </tr>
                                                            <tr>
                                                                <td align="left">
                                                                    <asp:Label ID="Label94" runat="server" Text="Wind/Hail Deductible" CssClass="label" />
                                                                </td>
                                                                <td align="left">
                                                                    <asp:TextBox ID="dd_hurded_AR2" runat="server" Text="0.00" 
                                                                        AutoCompleteType="DisplayName" Enabled="false" TabIndex="113" />
                                                                </td>
                                                            </tr>
                                                             <tr id="tstorm2">
                                                                <td align="left">
                                                                    <asp:Label ID="Label5" runat="server" Text="Hurricane/Tropical Storm" CssClass="label" />
                                                                </td>
                                                                <td align="left">
                                                                    <asp:TextBox ID="dd_thur_Ar2" runat="server" Text="0.00" 
                                                                        AutoCompleteType="DisplayName" Enabled="false" TabIndex="114" />
                                                                </td>
                                                            </tr>
                                                            <tr>
                                                                <td>
                                                                    &nbsp;
                                                                </td>
                                                            </tr>
                                                            <tr>
                                                                <td align="left">
                                                                    <asp:Label ID="Label105" runat="server" Text="Personal Liability:  " CssClass="label" />
                                                                    &nbsp
                                                                </td>
                                                                <td align="left">
                                                                    <asp:DropDownList ID="dd_pl_AR2" runat="server" AutoPostBack="true" 
                                                                        TabIndex="115" >
                                                                        <asp:ListItem>$0</asp:ListItem>
                                                                        <asp:ListItem>$25,000</asp:ListItem>
                                                                        <asp:ListItem>$50,000</asp:ListItem>
                                                                        <asp:ListItem>$100,000</asp:ListItem>
                                                                        <asp:ListItem>$300,000</asp:ListItem>
                                                                    </asp:DropDownList>
                                                                    &nbsp;<asp:Label ID="dd_pl_AR2_Amount" runat="server" Text="0.00" CssClass="label" />
                                                                    &nbsp;
                                                                </td>
                                                            </tr>
                                                            <tr id="AR_StandardMedPay" style="display: " clientidmode="Static">
                                                                <td align="left">
                                                                    <asp:Label ID="Label149" runat="server" Text="Medical payment:  " CssClass="label" />
                                                                    &nbsp
                                                                </td>
                                                                <td align="left">
                                                                    <asp:DropDownList ID="dd_mp_AR2" runat="server"  clientidmode="Static" 
                                                                        TabIndex="116">
                                                                        <asp:ListItem>$0</asp:ListItem>
                                                                        <asp:ListItem>$500</asp:ListItem>
                                                                       
                                                                    </asp:DropDownList>
                                                                     &nbsp;
                                                                    <asp:Label ID="dd_med_AR2_amt" runat="server" Text="0.00" CssClass="label" />
                                                                    &nbsp;
                                                                </td>
                                                            </tr>
                                                            <tr>
                                                                <td>
                                                                    &nbsp;
                                                                </td>
                                                            </tr>
                                                            <tr>
                                                                <td align="left">
                                                                    <asp:Label ID="Label115" runat="server" Text="Other Structures:  " CssClass="label" />
                                                                    &nbsp
                                                                </td>
                                                                <td align="left">
                                                                    <asp:TextBox ID="txt_unattstr_AR2" runat="server" Text="0.00" AutoCompleteType="DisplayName"
                                                                        Casing="UPPER" ToolTip="Unattached Structure" Width="65" TabIndex="117" />
                                                                    &nbsp;<asp:Label ID="txt_unattstr_AR2_Amount" runat="server" Text="0.00" CssClass="label" />
                                                                    &nbsp;
                                                                </td>
                                                            </tr>
                                                            <tr>
                                                                <td align="left">
                                                                    <asp:Label ID="Label116" runat="server" Text="Contents:  " CssClass="label" />
                                                                    &nbsp
                                                                </td>
                                                                <td align="left">
                                                                    <asp:TextBox ID="txt_pp_AR2" runat="server" Text="0.00" AutoCompleteType="DisplayName"
                                                                        Casing="UPPER" ToolTip="Personal Property" Width="65" TabIndex="118" />
                                                                    &nbsp;<asp:Label ID="txt_pp_AR2_Amount" runat="server" Text="0.00" CssClass="label" />
                                                                    &nbsp;
                                                                </td>
                                                            </tr>
                                                            <tr>
                                                                <td align="left">
                                                                    <asp:Label ID="Label117" runat="server" Text="Mobile Home Replacement Cost:  " CssClass="label" />
                                                                    &nbsp
                                                                </td>
                                                                <td align="left">
                                                                    <asp:DropDownList ID="dd_mhr_AR2" runat="server" TabIndex="119">
                                                                        <asp:ListItem>No</asp:ListItem>
                                                                        <asp:ListItem>Yes</asp:ListItem>
                                                                    </asp:DropDownList>
                                                                    &nbsp;<asp:Label ID="dd_mhr_AR2_Amount" runat="server" Text="0.00" CssClass="label" />
                                                                    &nbsp;
                                                                </td>
                                                            </tr>
                                                           <tr>
                                                                <td align="left">
                                                                    <asp:Label ID="Label1" runat="server" Text="Contents Replacement Cost:  " CssClass="label" />
                                                                    &nbsp
                                                                </td>
                                                                <td align="left">
                                                                    <asp:DropDownList ID="dd_rep_AR2" runat="server" TabIndex="120" 
                                                                        ClientIDMode="Static">
                                                                        <asp:ListItem>No</asp:ListItem>
                                                                        <asp:ListItem>Yes</asp:ListItem>
                                                                    </asp:DropDownList>
                                                                    &nbsp;
                                                                    <asp:Label ID="dd_rep_AR2_Amount" runat="server" Text="0.00" CssClass="label" />
                                                                    &nbsp;
                                                                </td>
                                                            </tr>
                                                            <tr>
                                                                <td id="trmhAROpt2_2" align="left" clientidmode="Static">
                                                                    <asp:Label ID="Label135" runat="server" Text="Full Repair:  " CssClass="label" />
                                                                    &nbsp
                                                                </td>
                                                                <td id="trmhAROpt2_2_d" align="left" clientidmode="Static">
                                                                    <asp:DropDownList ID="dd_sip_AR2" runat="server" TabIndex="121">
                                                                        <asp:ListItem>No</asp:ListItem>
                                                                        <asp:ListItem>Yes</asp:ListItem>
                                                                    </asp:DropDownList>
                                                                    &nbsp;<asp:Label ID="dd_sip_AR2_Amount" runat="server" Text="0.00" CssClass="label" />
                                                                    &nbsp;
                                                                </td>
                                                            </tr>
                                                           
                                                            <tr>
                                                                <td align="left">
                                                                    <asp:Button ID="ar2_updateOptions" runat="server" Text="Update Optional Coverages"
                                                                        OnClick="ar_premiumbtnClick2" TabIndex="22" />
                                                                </td>
                                                            </tr>
                                                        </tbody>
                                                    </table>
                                                </td>
                                            </tr>
                                            <tr id="ar_mh_prog3" runat="server" style="border: 1px solid black;">
                                                <td align="center" style="border: 1px solid" width="251px">
                                                    <label id="lblARShowOptions3" runat="server" style="color: Blue; cursor: pointer;"
                                                        onclick="AROptionsShow(3);" clientidmode="Static">
                                                       - Show Options</label>
                                                    <asp:HiddenField ID="lblARShowOptions3_hidden" runat="server" Value="+ Show Options" />
                                                </td>
                                                <td align="center" style="border: 1px solid">
                                                    <asp:Label ID="Label86" runat="server" Text="Lloyd Rental" CssClass="labelCov" />
                                                </td>
                                                <td align="center" style="border: 1px solid">
                                                    <asp:Label ID="ar_dwell3" runat="server" Text="0.00" CssClass="labelCov" />
                                                </td>
                                                <td align="center" style="border: 1px solid" class="style3">
                                                    <asp:Label ID="ar_unattStr3" runat="server" Text="0.00" CssClass="labelCov" />
                                                </td>
                                                <td align="center" style="border: 1px solid">
                                                    <asp:Label ID="ar_perEff3" runat="server" Text="0.00" CssClass="labelCov" />
                                                </td>
                                                <td align="center" style="border: 1px solid;">
                                                    <asp:Label ID="ar_perLiab3" runat="server" Text="0.00" CssClass="labelCov" />
                                                </td>
                                                <td align="center" style="border: 1px solid">
                                                    <asp:Label ID="ar_medpay3" runat="server" Text="0.00" CssClass="labelCov" />
                                                </td>
                                                <td align="center" style="border: 1px solid">
                                                    <asp:Label ID="ar_baseprem3" runat="server" Text="0.00" CssClass="labelCov" />
                                                </td>
                                                <td align="center" style="border: 1px solid">
                                                    <asp:Label ID="ar_options3" runat="server" Text="0.00" CssClass="labelCov" />
                                                </td>
                                                <td align="center" style="border: 1px solid">
                                                    <asp:Label ID="ar_fees3" runat="server" Text="0.00" CssClass="labelCov" />
                                                </td>
                                                <td align="center" style="border: 1px solid">
                                                    <asp:Label ID="ar_tax3" runat="server" Text="0.00" CssClass="labelCov" />
                                                </td>
                                                <td align="center" style="border: 1px solid">
                                                    <asp:Label ID="ar_total3" runat="server" Text="0.00" CssClass="labelTotal" />
                                                </td>
                                                <td align="center" style="border: 1px solid">
                                                    <asp:Button ID="selectAR3btn" runat="server" OnClick="selectAR3btn_Click" Text="Select" />
                                                </td>
                                            </tr>
                                            <tr id="ar_mh_prog3_Options" runat="server" clientidmode="Static">
                                                <td colspan="13">
                                                    <table id="AROptionRow3" runat="server" width="auto" cellpadding="0" cellspacing="0"
                                                        clientidmode="Static" bgcolor="white" title="Lloyd Options">
                                                        <tbody>
                                                            <tr>
                                                                <td>
                                                                    <input id="Button2" type="button" value="Open Calc Detail" />
                                                                    <asp:Label ID="txt_dwell_AR3_Amount" runat="server" Text="0.00" CssClass="label" Style="display:none" />
                                                                    &nbsp;
                                                                    <asp:Label ID="txt_DedChange_AR3_Amount" runat="server" Text="0.00" CssClass="label" Style="display:none" />
                                                                    <asp:Label ID="txt_Credit_AR3_Amount" runat="server" Text="0.00" CssClass="label" Style="display:none" />
                                                                    &nbsp;
                                                                    <dx:ASPxPopupControl ID="ASPxPopupControl2" runat="server" PopupElementID="Button2" HeaderText="Rental Calculations" PopupVerticalAlign="Below" PopupHorizontalAlign="LeftSides" AllowDragging="True"
                                                                          MaxWidth="800px" MaxHeight="1800px" MinHeight="150px" MinWidth="150px" ShowFooter="True" >
                                                                    <ContentCollection>
                                                                        <dx:PopupControlContentControl ID="PopupControlContentControl2" runat="server">
                                                                            <asp:Panel ID="Panel2" runat="server">
                                                                                <table border="0" cellpadding="4" cellspacing="0">
                                                                                    <tr>
                                                                                        <td valign="top">
                                                                                            
                                                                                            <asp:Label ID="AR3_Debug" runat="server" ClientIDMode="Static" Text="No Data"></asp:Label>
                                                                                           
                                                                                        </td>
                                                                                    </tr>
                                                                                 
                                                                                </table>
                                                                            </asp:Panel>
                                                                        </dx:PopupControlContentControl>
                                                                    </ContentCollection>

                                                                    </dx:ASPxPopupControl>
                                                                </td>
                                                            </tr>
                                                            <tr>
                                                                <td align="left">
                                                                    <asp:Label ID="Label137" runat="server" Text="AOP Deductible" CssClass="label" />
                                                                </td>
                                                                <td align="left">
                                                                    <asp:DropDownList ID="dd_aop_AR3" runat="server" TabIndex="123">
                                                                        <asp:ListItem>$500</asp:ListItem>
                                                                        <asp:ListItem>$1000</asp:ListItem>
                                                                    </asp:DropDownList>
                                                                     &nbsp;<asp:Label ID="dd_aop_AR3_Amount" runat="server" Text="0.00" CssClass="label" />
                                                                    &nbsp;
                                                                </td>
                                                            </tr>
                                                            <tr>
                                                                <td align="left">
                                                                    <asp:Label ID="Label138" runat="server" Text="Wind/Hail Deductible" CssClass="label" />
                                                                </td>
                                                                <td align="left">
                                                                    <asp:TextBox ID="dd_hurded_AR3" runat="server" Text="0.00" 
                                                                        AutoCompleteType="DisplayName" Enabled="false" TabIndex="124" />
                                                                </td>
                                                            </tr>
                                                             <tr id="tstorm3">
                                                                <td align="left">
                                                                    <asp:Label ID="Label7" runat="server" Text="Hurricane/Tropical Storm" CssClass="label" />
                                                                </td>
                                                                <td align="left">
                                                                    <asp:TextBox ID="dd_thur_ar3" runat="server" Text="0.00" 
                                                                        AutoCompleteType="DisplayName" Enabled="false" TabIndex="125" />
                                                                </td>
                                                            </tr>
                                                            <tr>
                                                                <td align="left">
                                                                    <asp:Label ID="Label139" runat="server" Text="Owner Landlord Liability Protection:  "
                                                                        CssClass="label" />
                                                                    &nbsp
                                                                </td>
                                                                <td align="left">
                                                                    <asp:DropDownList ID="dd_pl_AR3" runat="server" TabIndex="126">
                                                                        <asp:ListItem></asp:ListItem>
                                                                        <asp:ListItem>$25,000</asp:ListItem>
                                                                        <asp:ListItem>$50,000</asp:ListItem>
                                                                        <asp:ListItem>$100,000</asp:ListItem>
                                                                       
                                                                    </asp:DropDownList>
                                                                     &nbsp;<asp:Label ID="dd_pl_AR3_Amount" runat="server" Text="0.00" CssClass="label" />
                                                                    &nbsp;
                                                                </td>
                                                            </tr>
                                                            <tr>
                                                                <td align="left">
                                                                    <asp:Label ID="Label150" runat="server" Text="Medical payment:  " CssClass="label" />
                                                                    &nbsp
                                                                </td>
                                                                <td align="left">
                                                                    <asp:DropDownList ID="dd_mp_AR3" runat="server" TabIndex="127">
                                                                        <asp:ListItem></asp:ListItem>
                                                                        <asp:ListItem>$500</asp:ListItem>
                                                                        
                                                                    </asp:DropDownList>
                                                                     &nbsp;<asp:Label ID="dd_med_AR3_amt" runat="server" Text="0.00" CssClass="label" />
                                                                    &nbsp;
                                                                </td>
                                                            </tr>
                                                            <tr>
                                                                <td align="left">
                                                                    <asp:Label ID="Label140" runat="server" Text="Other Structures:  " CssClass="label" />
                                                                    &nbsp
                                                                </td>
                                                                <td align="left">
                                                                    <asp:TextBox ID="txt_unattstr_AR3" runat="server" Text="0.00" AutoCompleteType="DisplayName"
                                                                        Casing="UPPER" ToolTip="Unattached Structure" Width="65" TabIndex="128" />
                                                                        &nbsp;<asp:Label ID="txt_unattstr_AR3_Amount" runat="server" Text="0.00" CssClass="label" />
                                                                    &nbsp;
                                                                </td>
                                                            </tr>
                                                            <tr>
                                                                <td align="left">
                                                                    <asp:Label ID="Label141" runat="server" Text="Contents:  " CssClass="label" />
                                                                    &nbsp
                                                                </td>
                                                                <td align="left">
                                                                    <asp:TextBox ID="txt_pp_AR3" runat="server" Text="0.00" AutoCompleteType="DisplayName"
                                                                        Casing="UPPER" ToolTip="Personal Property" Width="65" TabIndex="129" />
                                                                        &nbsp;<asp:Label ID="txt_pp_AR3_Amount" runat="server" Text="0.00" CssClass="label" />
                                                                    &nbsp;
                                                                </td>
                                                            </tr>
                                                            <tr>
                                                             <td align="left">
                                                                    <asp:Label ID="Label2" runat="server" Text="Mobile Home Replacement Cost:  " CssClass="label" />
                                                                    &nbsp
                                                                </td>
                                                                <td align="left">
                                                                    <asp:DropDownList ID="dd_mhr_AR3" runat="server" TabIndex="130">
                                                                        <asp:ListItem>No</asp:ListItem>
                                                                        <asp:ListItem>Yes</asp:ListItem>
                                                                    </asp:DropDownList>
                                                                    &nbsp;<asp:Label ID="dd_mhr_AR3_Amount" runat="server" Text="0.00" CssClass="label" />
                                                                    &nbsp;
                                                                </td>
                                                            </tr>
                                                           <tr>
                                                                <td align="left">
                                                                    <asp:Label ID="Label3" runat="server" Text="Contents Replacement Cost:  " CssClass="label" />
                                                                    &nbsp
                                                                </td>
                                                                <td align="left">
                                                                    <asp:DropDownList ID="dd_rep_AR3" runat="server" TabIndex="131" 
                                                                        ClientIDMode="Static">
                                                                        <asp:ListItem>No</asp:ListItem>
                                                                        <asp:ListItem>Yes</asp:ListItem>
                                                                    </asp:DropDownList>
                                                                    &nbsp;
                                                                    <asp:Label ID="dd_rep_AR3_Amount" runat="server" Text="0.00" CssClass="label" />
                                                                    &nbsp;
                                                                </td>
                                                            </tr>
                                                            <tr>
                                                                <td id="Td1" align="left" clientidmode="Static">
                                                                    <asp:Label ID="Label4" runat="server" Text="Full Repair:  " CssClass="label" />
                                                                    &nbsp
                                                                </td>
                                                                <td id="Td2" align="left" clientidmode="Static">
                                                                    <asp:DropDownList ID="dd_sip_AR3" runat="server" TabIndex="132">
                                                                        <asp:ListItem>No</asp:ListItem>
                                                                        <asp:ListItem>Yes</asp:ListItem>
                                                                    </asp:DropDownList>
                                                                    &nbsp;<asp:Label ID="dd_sip_AR3_Amount" runat="server" Text="0.00" CssClass="label" />
                                                                    &nbsp;
                                                                </td>
                                                            </tr>
                                                            <tr>
                                                                <td align="left">
                                                                    <asp:Button ID="ar3_updateOptions" runat="server" Text="Update Optional Coverages"
                                                                        OnClick="ar_premiumbtnClick3" TabIndex="33" />
                                                                </td>
                                                            </tr>
                                                        </tbody>
                                                    </table>
                                                </td>
                                            </tr>
                                            <%--Specialty SC only--%>
                                            <tr id="SC_MH_08" runat="server" style="border: 1px solid black;">
                                                <td align="center" style="border: 1px solid" width="251px">
                                                    <label id="lblSMHShowOptions4" runat="server" style="color: Blue; cursor: pointer;"
                                                        onclick="AROptionsShow(4);" clientidmode="Static">
                                                       - Show Options</label>
                                                    <asp:HiddenField ID="lblSMHShowOptions4_hidden" runat="server" Value="+ Show Options" />
                                                </td>
                                                <td align="center" style="border: 1px solid">
                                                    <asp:Label ID="Label10" runat="server" Text="Lloyds Specialty MH – HO8" CssClass="labelCov" />
                                                </td>
                                                <td align="center" style="border: 1px solid">
                                                    <asp:Label ID="SC08_dwell" runat="server" Text="0.00" CssClass="labelCov" />
                                                </td>
                                                <td align="center" style="border: 1px solid" class="style3">
                                                    <asp:Label ID="SC08_unattStr" runat="server" Text="0.00" CssClass="labelCov" />
                                                </td>
                                                <td align="center" style="border: 1px solid">
                                                    <asp:Label ID="SC08_perEff" runat="server" Text="0.00" CssClass="labelCov" />
                                                </td>
                                                <td align="center" style="border: 1px solid;">
                                                    <asp:Label ID="SC08_perLiab" runat="server" Text="0.00" CssClass="labelCov" />
                                                </td>
                                                <td align="center" style="border: 1px solid">
                                                    <asp:Label ID="SC08_medpay" runat="server" Text="0.00" CssClass="labelCov" />
                                                </td>
                                                <td align="center" style="border: 1px solid">
                                                    <asp:Label ID="SC08_baseprem" runat="server" Text="0.00" CssClass="labelCov" />
                                                </td>
                                                <td align="center" style="border: 1px solid">
                                                    <asp:Label ID="SC08_options" runat="server" Text="0.00" CssClass="labelCov" />
                                                </td>
                                                <td align="center" style="border: 1px solid">
                                                    <asp:Label ID="SC08_fees" runat="server" Text="0.00" CssClass="labelCov" />
                                                </td>
                                                <td align="center" style="border: 1px solid">
                                                    <asp:Label ID="SC08_tax" runat="server" Text="0.00" CssClass="labelCov" />
                                                </td>
                                                <td align="center" style="border: 1px solid">
                                                    <asp:Label ID="SC08_total" runat="server" Text="0.00" CssClass="labelTotal" />
                                                </td>
                                                <td align="center" style="border: 1px solid">
                                                    <asp:Button ID="select08btn" runat="server" OnClick="select08btn_Click" Text="Select" />
                                                </td>
                                            </tr>
                                            <tr id="SC08_mh_prog_Options" runat="server" clientidmode="Static">
                                                <td colspan="13">
                                                    <table id="SC08OptionRow" runat="server" width="auto" cellpadding="0" cellspacing="0"
                                                        clientidmode="Static" bgcolor="white" title="Specialty Options">
                                                        <tbody>
                                                            <tr>
                                                                <td>
                                                                    <input id="btnH08" type="button" value="Open Calc Detail" />
                                                                    <asp:Label ID="txt_dwell_08_Amount" runat="server" Text="0.00" CssClass="label" Style="display:none" />
                                                                       &nbsp;
                                                                     <asp:Label ID="txt_DedChange_08_Amount" runat="server" Text="0.00" CssClass="label" Style="display:none" />
                                                                    <asp:Label ID="txt_Credit_08_Amount" runat="server" Text="0.00" CssClass="label" Style="display:none" />
                                                                   &nbsp;
                                                                   <dx:ASPxPopupControl ID="ASPxPopupControl4" runat="server" HeaderText="Specialty Calculations" PopupElementID="btnH08" ShowFooter="True" PopupVerticalAlign="Below" PopupHorizontalAlign="LeftSides" AllowDragging="True"
                                                                          MaxWidth="800px" MaxHeight="1800px" MinHeight="150px" MinWidth="150px">

                                                                        <ContentCollection>
                                                                            <dx:PopupControlContentControl runat="server" ID="PopupControlContentControl4" >
                                                                              <asp:Panel ID="Panel4" runat="server">
                                                                                <table border="0" cellpadding="4" cellspacing="0">
                                                                                    <tr>
                                                                                        <td valign="top">
                                                                                            
                                                                                            <asp:Label ID="SC08_Debug" runat="server" ClientIDMode="Static" Text=""></asp:Label>
                                                                                        </td>
                                                                                    </tr>
                                                                                  
                                                                                </table>
                                                                            </asp:Panel>
                                                                            </dx:PopupControlContentControl>
                                                                        </ContentCollection>

                                                                    </dx:ASPxPopupControl>
                                                                   
                                                                   
                                                                </td>
                                                            </tr>
                                                            <tr>
                                                                <td align="left">
                                                                    <asp:Label ID="Label11" runat="server" Text="AOP Deductible" CssClass="label" />
                                                                </td>
                                                                <td align="left">
                                                                    <asp:DropDownList ID="dd_aop_08" runat="server" TabIndex="123">
                                                                        <asp:ListItem>$500</asp:ListItem>
                                                                        <asp:ListItem>$1000</asp:ListItem>
                                                                        <asp:ListItem>$2500</asp:ListItem>
                                                                    </asp:DropDownList>
                                                                     &nbsp;<asp:Label ID="dd_aop_08_Amount" runat="server" Text="0.00" CssClass="label" />
                                                                    &nbsp;
                                                                </td>
                                                            </tr>
                                                            <tr>
                                                                <td align="left">
                                                                    <asp:Label ID="Label12" runat="server" Text="Wind/Hail Deductible" CssClass="label" />
                                                                </td>
                                                                <td align="left">
                                                                    <asp:TextBox ID="dd_hurded_08" runat="server" Text="0.00" 
                                                                        AutoCompleteType="DisplayName" Enabled="false" TabIndex="124" />
                                                                </td>
                                                            </tr>
                                                            <tr id="trlossofuse08">
                                                                <td align="left">
                                                                    <asp:Label ID="Label13" runat="server" Text="Loss of Use" CssClass="label" />
                                                                </td>
                                                                <td align="left">
                                                                    <asp:TextBox ID="txtlossofuse08" runat="server" Text="0.00" 
                                                                        AutoCompleteType="DisplayName" Enabled="false" TabIndex="303" />
                                                                </td>
                                                            </tr>
                                                            <tr>
                                                                <td align="left">
                                                                    <asp:Label ID="Label14" runat="server" Text="Personal Liability Protection:  "
                                                                        CssClass="label" />
                                                                    &nbsp
                                                                </td>
                                                                <td align="left">
                                                                    <asp:DropDownList ID="dd_pl_08" runat="server" TabIndex="126">
                                                                    <asp:ListItem>$0</asp:ListItem>
                                                                        <asp:ListItem>$25,000</asp:ListItem>
                                                                        <asp:ListItem>$50,000</asp:ListItem>
                                                                        <asp:ListItem>$100,000</asp:ListItem>
                                                                       <asp:ListItem>$300,000</asp:ListItem>
                                                                    </asp:DropDownList>
                                                                     &nbsp;<asp:Label ID="dd_pl_08_Amount" runat="server" Text="0.00" CssClass="label" />
                                                                    &nbsp;
                                                                </td>
                                                            </tr>
                                                            <tr>
                                                                <td align="left">
                                                                    <asp:Label ID="Label15" runat="server" Text="Medical payment:  " CssClass="label" />
                                                                    &nbsp
                                                                </td>
                                                                <td align="left">
                                                                    <asp:DropDownList ID="dd_mp_08" runat="server" TabIndex="127">
                                                                    <asp:ListItem>$0</asp:ListItem>
                                                                     <asp:ListItem>$500</asp:ListItem>
                                                                       <asp:ListItem>$1000</asp:ListItem>
                                                                        </asp:DropDownList>
                                                                     &nbsp;<asp:Label ID="dd_med_08_amt" runat="server" Text="0.00" CssClass="label" />
                                                                    &nbsp;
                                                                </td>
                                                            </tr>
                                                            <tr>
                                                                <td align="left">
                                                                    <asp:Label ID="Label16" runat="server" Text="Other Structures:  " CssClass="label" />
                                                                    &nbsp
                                                                </td>
                                                                <td align="left">
                                                                    <asp:TextBox ID="txt_unattstr_08" runat="server" Text="0.00" AutoCompleteType="DisplayName"
                                                                        Casing="UPPER" ToolTip="Unattached Structure" Width="65" TabIndex="128" 
                                                                        Enabled="False" />
                                                                        &nbsp;<asp:Label ID="txt_unattstr_08_Amount" runat="server" Text="0.00" CssClass="label" />
                                                                    &nbsp;
                                                                </td>
                                                            </tr>
                                                            <tr>
                                                                <td align="left">
                                                                    <asp:Label ID="Label17" runat="server" Text="Contents:  " CssClass="label" />
                                                                    &nbsp
                                                                </td>
                                                                <td align="left">
                                                                    <asp:TextBox ID="txt_pp_08" runat="server" Text="0.00" AutoCompleteType="DisplayName"
                                                                        Casing="UPPER" ToolTip="Personal Property" Width="65" TabIndex="129" />
                                                                        &nbsp;<asp:Label ID="txt_pp_08_Amount" runat="server" Text="0.00" CssClass="label" />
                                                                    &nbsp;<asp:Label ID="lblcontentmax" runat="server" Text="(Max 40%)" CssClass="label" />
                                                                </td>
                                                            </tr>
                                                            
                                                           <tr>
                                                                <td align="left">
                                                                    <asp:Label ID="Label19" runat="server" Text="Contents Replacement Cost:  " CssClass="label" />
                                                                    &nbsp
                                                                </td>
                                                                <td align="left">
                                                                    <asp:DropDownList ID="dd_rep_08" runat="server" TabIndex="131" 
                                                                        ClientIDMode="Static">
                                                                        <asp:ListItem>No</asp:ListItem>
                                                                        <asp:ListItem>Yes</asp:ListItem>
                                                                    </asp:DropDownList>
                                                                    &nbsp;
                                                                    <asp:Label ID="dd_rep_08_Amount" runat="server" Text="0.00" CssClass="label" />
                                                                    &nbsp;
                                                                </td>
                                                            </tr>
                                                            <tr>
                                                                <td id="Td3" align="left" clientidmode="Static">
                                                                    <asp:Label ID="Label20" runat="server" Text="Enhancement Coverage  " CssClass="label" />
                                                                    &nbsp
                                                                </td>
                                                                <td id="Td4" align="left" clientidmode="Static">
                                                                    <asp:DropDownList ID="dd_sip_08" runat="server" TabIndex="132">
                                                                    <asp:ListItem></asp:ListItem>
                                                                        <asp:ListItem>$2,500</asp:ListItem>
                                                                        <asp:ListItem>$5,000</asp:ListItem>
                                                                    </asp:DropDownList>
                                                                    &nbsp;<asp:Label ID="dd_sip_08_Amount" runat="server" Text="0.00" CssClass="label" />
                                                                    &nbsp;
                                                                </td>
                                                            </tr>
                                                            <tr>
                                                                <td align="left">
                                                                    <asp:Button ID="SC08_updateOptions" runat="server" Text="Update Optional Coverages"
                                                                        OnClick="SC08_premiumbtnClick3" TabIndex="33" />
                                                                </td>
                                                            </tr>
                                                        </tbody>
                                                    </table>
                                                </td>
                                            </tr>
                                           <%-- AIGES START--%>
                                            <tr id="aiges_mh_prog2" runat="server" style="border: 1px solid black;">
                                                <td align="center" style="border: 1px solid" width="251px">
                                                    <label id="lblaiges_ShowOptions2" runat="server" style="color: Blue; cursor: pointer;"
                                                        onclick="AROptionsShow(5);" clientidmode="Static">
                                                        - Show Options</label>
                                                    <asp:HiddenField ID="lblaiges_ShowOptions2_hidden" runat="server" Value="+ Show Options" />
                                                </td>
                                                <td align="center" style="border: 1px solid">
                                                    <asp:Label ID="agPrgm" runat="server" Text="Aegis Standard" CssClass="labelCov" />
                                                </td>
                                                <td align="center" style="border: 1px solid">
                                                    <asp:Label ID="aiges_dwell2" runat="server" Text="0.00" CssClass="labelCov" />
                                                </td>
                                                <td align="center" style="border: 1px solid" class="style3">
                                                    <asp:Label ID="aiges_unattStr2" runat="server" Text="0.00" CssClass="labelCov" />
                                                </td>
                                                <td align="center" style="border: 1px solid">
                                                    <asp:Label ID="aiges_perEff2" runat="server" Text="0.00" CssClass="labelCov" />
                                                </td>
                                                <td align="center" style="border: 1px solid;">
                                                    <asp:Label ID="aiges_perLiab2" runat="server" Text="0.00" CssClass="labelCov" />
                                                </td>
                                                <td align="center" style="border: 1px solid">
                                                    <asp:Label ID="aiges_medpay2" runat="server" Text="0.00" CssClass="labelCov" />
                                                </td>
                                                <td align="center" style="border: 1px solid">
                                                    <asp:Label ID="aiges_baseprem2" runat="server" Text="0.00" CssClass="labelCov" />
                                                </td>
                                                <td align="center" style="border: 1px solid">
                                                    <asp:Label ID="aiges_options2" runat="server" Text="0.00" CssClass="labelCov" />
                                                </td>
                                                <td align="center" style="border: 1px solid">
                                                    <asp:Label ID="aiges_fees2" runat="server" Text="$0.00" CssClass="labelCov" />
                                                </td>
                                                <td align="center" style="border: 1px solid">
                                                    <asp:Label ID="aiges_tax2" runat="server" Text="0.00" CssClass="labelCov" />
                                                </td>
                                                <td align="center" style="border: 1px solid">
                                                    <asp:Label ID="aiges_total2" runat="server" Text="0.00" CssClass="labelTotal" />
                                                </td>
                                                <td align="center" style="border: 1px solid">
                                                    <asp:Button ID="selectaiges_2btn" runat="server" OnClick="selectaiges1btn_Click" Text="Select" />
                                                </td>
                                            </tr>
                                            <tr id="aiges_mh_prog2_Options" runat="server" clientidmode="Static">
                                                <td colspan="13">
                                                    <table id="Table1" runat="server" width="auto" cellpadding="0" cellspacing="0"
                                                        clientidmode="Static" bgcolor="white" title="AR Options">
                                                        <tbody>
                                                            <tr>
                                                                <td align="left">
                                                                    <input id="Button5" type="button" value="Open Calc Detail"  />
                                                                    <asp:Label ID="txt_dwell_aiges_Amount" runat="server" Text="0.00" CssClass="label" Style="display:none" />
                                                                    &nbsp;
                                                                    <asp:Label ID="txt_DedChange_aiges_Amount" runat="server" Text="0.00" CssClass="label" Style="display:none" />
                                                                    <asp:Label ID="txt_Credit_aiges_Amount" runat="server" Text="0.00" CssClass="label" Style="display:none" />
                                                                    &nbsp;
                                                                    <dx:ASPxPopupControl ID="ASPxPopupControl5" runat="server" PopupElementID="Button5" HeaderText="Standard Calculations" PopupVerticalAlign="Below" PopupHorizontalAlign="LeftSides" AllowDragging="True"
                                                                          MaxWidth="800px" MaxHeight="1800px" MinHeight="150px" MinWidth="150px" ShowFooter="True" Width="250px" Height="130px" >
                                                                    <ContentCollection>
                                                                        <dx:PopupControlContentControl ID="PopupControlContentControl5" runat="server">
                                                                            <asp:Panel ID="Panel6" runat="server">
                                                                                <table border="0" cellpadding="4" cellspacing="0">
                                                                                    <tr>
                                                                                        <td valign="top">
                                                                                            
                                                                                            <asp:Label ID="aiges_Debug" runat="server" ClientIDMode="Static" Text=""></asp:Label>
                                                                                        </td>
                                                                                    </tr>
                                                                                  
                                                                                </table>
                                                                            </asp:Panel>
                                                                        </dx:PopupControlContentControl>
                                                                    </ContentCollection>

                                                                    </dx:ASPxPopupControl>
                                                                </td>
                                                            </tr>
                                                            <tr>
                                                                <td align="left">
                                                                    <asp:Label ID="Label18" runat="server" Text="AOP Deductible" CssClass="label" />
                                                                </td>
                                                                <td align="left">
                                                                    <asp:DropDownList ID="dd_aop_aiges1" runat="server" TabIndex="112">
                                                                         <%--<asp:ListItem>$250</asp:ListItem>--%>
                                                                        <asp:ListItem>$500</asp:ListItem>
                                                                       <asp:ListItem>$1000</asp:ListItem>
                                                                        <asp:ListItem>$2500</asp:ListItem>
                                                                    </asp:DropDownList>
                                                                     &nbsp;<asp:Label ID="dd_aop_aiges1_Amount" runat="server" Text="0.00" CssClass="label" />
                                                                    &nbsp;
                                                                </td>
                                                            </tr>
                                                            <tr id="aegisWind" runat="server">
                                                                <td align="left">
                                                                    <asp:Label ID="Label21" runat="server" Text="Named Storm Deductible" CssClass="label" />
                                                                </td>
                                                                <td align="left">
                                                                    <asp:TextBox ID="dd_hurded_aiges1" runat="server" Text="0.00" 
                                                                        AutoCompleteType="DisplayName" Enabled="false" TabIndex="113" />
                                                                </td>
                                                            </tr>
                                                             <tr id="aegisWindhur" runat="server">
                                                                <td align="left">
                                                                    <asp:Label ID="Label159" runat="server" Text="Wind\Hail\Tornado Deductible" CssClass="label" />
                                                                </td>
                                                                <td align="left">
                                                                    <asp:TextBox ID="aegishurrcanded" runat="server" Text="0.00" 
                                                                        AutoCompleteType="DisplayName" Enabled="false" TabIndex="113" />
                                                                </td>
                                                            </tr>
                                                            <tr>
                                                                <td>
                                                                    &nbsp;
                                                                </td>
                                                            </tr>
                                                            <tr>
                                                                <td align="left">
                                                                    <asp:Label ID="Label23" runat="server" Text="Personal Liability:  " CssClass="label" />
                                                                    &nbsp
                                                                </td>
                                                                <td align="left">
                                                                    <asp:DropDownList ID="dd_pl_aiges1" runat="server" AutoPostBack="true" 
                                                                        TabIndex="115" >
                                                                        <%--<asp:ListItem>$0</asp:ListItem>--%>
                                                                        <asp:ListItem>$25,000</asp:ListItem>
                                                                        <asp:ListItem>$50,000</asp:ListItem>
                                                                        <asp:ListItem>$100,000</asp:ListItem>
                                                                         <asp:ListItem>$300,000</asp:ListItem>
                                                                       
                                                                    </asp:DropDownList>
                                                                    &nbsp;<asp:Label ID="dd_pl_aiges1_Amount" runat="server" Text="0.00" CssClass="label" />
                                                                    &nbsp;
                                                                </td>
                                                            </tr>
                                                            <tr id="aiges_StandardMedPay" style="display: " clientidmode="Static">
                                                                <td align="left">
                                                                    <asp:Label ID="Label24" runat="server" Text="Medical payment:  " CssClass="label" />
                                                                    &nbsp
                                                                </td>
                                                                <td align="left">
                                                                    <asp:DropDownList ID="dd_mp_aiges1" runat="server"  clientidmode="Static" 
                                                                        TabIndex="116">
                                                                        <asp:ListItem>$0</asp:ListItem>
                                                                        <asp:ListItem>$500</asp:ListItem>
                                                                        <asp:ListItem>$1000</asp:ListItem>
                                                                       <asp:ListItem>$2000</asp:ListItem>
                                                                       <asp:ListItem>$2500</asp:ListItem>
                                                                       <asp:ListItem>$5000</asp:ListItem>
                                                                    </asp:DropDownList>
                                                                     &nbsp;
                                                                    <asp:Label ID="dd_med_aiges1_amt" runat="server" Text="0.00" CssClass="label" />
                                                                    &nbsp;
                                                                </td>
                                                            </tr>
                                                            <tr>
                                                                <td>
                                                                    &nbsp;
                                                                </td>
                                                            </tr>
                                                            <tr>
                                                                <td align="left">
                                                                    <asp:Label ID="Label25" runat="server" Text="Other Structures:  " CssClass="label" />
                                                                    &nbsp
                                                                </td>
                                                                <td align="left">
                                                                    <asp:TextBox ID="txt_unattstr_aiges1" runat="server" Text="0.00" AutoCompleteType="DisplayName"
                                                                        Casing="UPPER" ToolTip="Unattached Structure" Width="65" TabIndex="117"/>
                                                                    &nbsp;<asp:Label ID="txt_unattstr_aiges1_Amount" runat="server" Text="0.00" CssClass="label" />
                                                                    &nbsp;
                                                                </td>
                                                            </tr>
                                                            <tr>
                                                                <td align="left">
                                                                    <asp:Label ID="Label26" runat="server" Text="Contents:  " CssClass="label" />
                                                                    &nbsp
                                                                </td>
                                                                <td align="left">
                                                                    <asp:TextBox ID="txt_pp_aiges1" runat="server" Text="0.00" AutoCompleteType="DisplayName"
                                                                        Casing="UPPER" ToolTip="Personal Property" Width="65" TabIndex="118" />
                                                                    &nbsp;<asp:Label ID="txt_pp_aiges1_Amount" runat="server" Text="0.00" CssClass="label" />
                                                                    &nbsp;
                                                                </td>
                                                            </tr>
                                                            
                                                           <tr>
                                                                <td align="left">
                                                                    <asp:Label ID="Label28" runat="server" Text="Contents Replacement Cost:  " CssClass="label" />
                                                                    &nbsp
                                                                </td>
                                                                <td align="left">
                                                                    <asp:DropDownList ID="dd_rep_aiges1" runat="server" TabIndex="120" 
                                                                        ClientIDMode="Static">
                                                                        <asp:ListItem>No</asp:ListItem>
                                                                        <asp:ListItem>Yes</asp:ListItem>
                                                                    </asp:DropDownList>
                                                                    &nbsp;
                                                                    <asp:Label ID="dd_rep_aiges1_Amount" runat="server" Text="0.00" CssClass="label" />
                                                                    &nbsp;
                                                                </td>
                                                            </tr>
                                                            <tr>
                                                                <td id="trmhaigesOpt2_2" align="left" clientidmode="Static">
                                                                    <asp:Label ID="Label29" runat="server" Text="Full Repair:  " CssClass="label" />
                                                                    &nbsp
                                                                </td>
                                                                <td id="trmhaigesOpt2_2_d" align="left" clientidmode="Static">
                                                                    <asp:DropDownList ID="dd_sip_aiges1" runat="server" TabIndex="121">
                                                                        <asp:ListItem>No</asp:ListItem>
                                                                        <asp:ListItem>Yes</asp:ListItem>
                                                                    </asp:DropDownList>
                                                                    &nbsp;<asp:Label ID="dd_sip_aiges1_Amount" runat="server" Text="0.00" CssClass="label" />
                                                                    &nbsp;
                                                                </td>
                                                            </tr>
                                                            <tr>
                                                                <td id="Td7" style="display:" align="left" clientidmode="Static">
                                                                    <asp:Label ID="Label9" runat="server" Text="Satelite Dish:  " CssClass="label" />
                                                                    &nbsp
                                                                </td>
                                                                <td id="Td8" style="display:" align="left" clientidmode="Static">
                                                                    <asp:TextBox ID="txt_Sat_value" runat="server" AutoCompleteType="DisplayName" 
                                                                        Casing="UPPER" TabIndex="118" Text="0.00" ToolTip="Personal Property" 
                                                                        Width="65" />
                                                                    &nbsp;
                                                                    <asp:Label ID="aegissatprem" runat="server" Text="0.00" CssClass="label" />
                                                                    &nbsp;
                                                                </td>
                                                            </tr>
                                                            <tr id="aegis_addliving" style="display: " clientidmode="Static">
                                                                <td align="left">
                                                                    <asp:Label ID="Label152" runat="server" Text="Increased Additional Living Expens:  " CssClass="label" />
                                                                    &nbsp
                                                                </td>
                                                                <td align="left">
                                                                    <asp:DropDownList ID="dd_living" runat="server"  clientidmode="Static" 
                                                                        TabIndex="116">
                                                                        <asp:ListItem>No</asp:ListItem>
                                                                        <asp:ListItem>Yes</asp:ListItem>
                                                                       
                                                                    </asp:DropDownList>
                                                                     &nbsp;
                                                                    <asp:Label ID="dd_living_amt" runat="server" Text="0.00" CssClass="label" />
                                                                    &nbsp;
                                                                </td>
                                                            </tr>
                                                            <tr id="aegis_earthquake" style="display: " clientidmode="Static">
                                                                <td align="left">
                                                                    <asp:Label ID="Label52" runat="server" Text="Earthquake Coverage:  " CssClass="label" />
                                                                    &nbsp
                                                                </td>
                                                                <td align="left">
                                                                    <asp:DropDownList ID="dd_earthquake" runat="server"  clientidmode="Static" 
                                                                        TabIndex="116">
                                                                        <asp:ListItem>No</asp:ListItem>
                                                                        <asp:ListItem>Yes</asp:ListItem>
                                                                       
                                                                    </asp:DropDownList>
                                                                     &nbsp;
                                                                    <asp:Label ID="dd_earthquake_amt" runat="server" Text="0.00" CssClass="label" />
                                                                    &nbsp;
                                                                </td>
                                                            </tr>
                                                            <tr id="aegis_icelimit" style="display: " clientidmode="Static">
                                                                <td align="left">
                                                                    <asp:Label ID="Label53" runat="server" Text="Weight of Ice, Snow or Sleet Limit:  " CssClass="label" />
                                                                    &nbsp
                                                                </td>
                                                                <td align="left">
                                                                    <asp:DropDownList ID="dd_icelimit" runat="server"  clientidmode="Static" 
                                                                        TabIndex="116">
                                                                        <asp:ListItem>No</asp:ListItem>
                                                                        <asp:ListItem>Yes</asp:ListItem>
                                                                       
                                                                    </asp:DropDownList>
                                                                     &nbsp;
                                                                    <asp:Label ID="dd_icelimit_amt" runat="server" Text="0.00" CssClass="label" />
                                                                    &nbsp;
                                                                </td>
                                                            </tr>
                                                            <tr id="aegis_icedelete" style="display: " clientidmode="Static">
                                                                <td align="left">
                                                                    <asp:Label ID="Label56" runat="server" Text="Weight of ice, Snow or Sleet (Deletion):  " CssClass="label" />
                                                                    &nbsp
                                                                </td>
                                                                <td align="left">
                                                                    <asp:DropDownList ID="dd_icedelete" runat="server"  clientidmode="Static" 
                                                                        TabIndex="116">
                                                                        <asp:ListItem>No</asp:ListItem>
                                                                        <asp:ListItem>Yes</asp:ListItem>
                                                                       
                                                                    </asp:DropDownList>
                                                                     &nbsp;
                                                                    <asp:Label ID="dd_icedelete_amt" runat="server" Text="0.00" CssClass="label" />
                                                                    &nbsp;
                                                                </td>
                                                            </tr>
                                                           <%-- <tr id="aegis_theft" style="display: " clientidmode="Static">
                                                                <td align="left">
                                                                    <asp:Label ID="Label113" runat="server" Text="Theft Exclusion:  " CssClass="label" />
                                                                    &nbsp
                                                                </td>
                                                                <td align="left">
                                                                    <asp:DropDownList ID="dd_theft" runat="server"  clientidmode="Static" 
                                                                        TabIndex="116">
                                                                        <asp:ListItem>No</asp:ListItem>
                                                                        <asp:ListItem>Yes</asp:ListItem>
                                                                       
                                                                    </asp:DropDownList>
                                                                     &nbsp;
                                                                    <asp:Label ID="dd_theft_amt" runat="server" Text="0.00" CssClass="label" />
                                                                    &nbsp;
                                                                </td>
                                                            </tr>--%>
                                                            <tr id="aegis_water" style="display: " clientidmode="Static">
                                                                <td align="left">
                                                                    <asp:Label ID="Label143" runat="server" Text="Water Damage Limitation:  " CssClass="label" />
                                                                    &nbsp
                                                                </td>
                                                                <td align="left">
                                                                    <asp:DropDownList ID="dd_water" runat="server"  clientidmode="Static" 
                                                                        TabIndex="116">
                                                                        <asp:ListItem>No</asp:ListItem>
                                                                        <asp:ListItem>Yes</asp:ListItem>
                                                                       
                                                                    </asp:DropDownList>
                                                                     &nbsp;
                                                                    <asp:Label ID="dd_water_amt" runat="server" Text="0.00" CssClass="label" />
                                                                    &nbsp;
                                                                </td>
                                                            </tr>
                                                            <tr id="aegis_waterexlusion" style="display: " clientidmode="Static">
                                                                <td align="left">
                                                                    <asp:Label ID="Label145" runat="server" Text="Water Damage Exclusion:  " CssClass="label" />
                                                                    &nbsp
                                                                </td>
                                                                <td align="left">
                                                                    <asp:DropDownList ID="dd_waterexlusion" runat="server"  clientidmode="Static" 
                                                                        TabIndex="116">
                                                                        <asp:ListItem>No</asp:ListItem>
                                                                        <asp:ListItem>Yes</asp:ListItem>
                                                                       
                                                                    </asp:DropDownList>
                                                                     &nbsp;
                                                                    <asp:Label ID="dd_waterexlusion_amt" runat="server" Text="0.00" CssClass="label" />
                                                                    &nbsp;
                                                                </td>
                                                            </tr>
                                                            <tr id="aegis_golf" style="display: " clientidmode="Static">
                                                                <td align="left">
                                                                    <asp:Label ID="Label146" runat="server" Text="Golf Cart Coverage:  " CssClass="label" ToolTip="If purchased, includes a maximum of $3,500 property coverage and $25,000 liability coverage.  See endorsement AS-9." />
                                                                    
                                                                    
                                                                    <dx:ASPxButton ID="ASPxButton1" runat="server" Width="10">
                                                                    <Image Url="../../images/Info.png"  >
                                                                         </Image>
                                                                    </dx:ASPxButton>
                                                                     <dx:ASPxPopupControl ID="ASPxPopupControl14" runat="server" PopupElementID="ASPxButton1" HeaderText="Golf Cart" PopupVerticalAlign="Below" PopupHorizontalAlign="LeftSides" AllowDragging="True"
                                                                          MaxWidth="800px" MaxHeight="1800px" MinHeight="150px" MinWidth="150px" ShowFooter="false" Width="250px" Height="130px" >
                                                                    <ContentCollection>
                                                                        <dx:PopupControlContentControl ID="PopupControlContentControl14" runat="server">
                                                                            <asp:Panel ID="Panel13" runat="server">
                                                                                <table border="0" cellpadding="4" cellspacing="0">
                                                                                    <tr>
                                                                                        <td valign="top">
                                                                                            
                                                                                            <asp:Label ID="Label113" runat="server" ClientIDMode="Static" Text="If purchased, includes a maximum of $3,500 property coverage and $25,000 liability coverage.  See endorsement AS-9."></asp:Label>
                                                                                        </td>
                                                                                    </tr>
                                                                                  
                                                                                </table>
                                                                            </asp:Panel>
                                                                        </dx:PopupControlContentControl>
                                                                    </ContentCollection>

                                                                    </dx:ASPxPopupControl>
                                                                </td>
                                                                <td align="left">
                                                                    <asp:DropDownList ID="dd_golf" runat="server"  clientidmode="Static" ToolTip="If purchased, includes a maximum of $3,500 property coverage and $25,000 liability coverage.  See endorsement AS-9." 
                                                                        TabIndex="116">
                                                                        <asp:ListItem>No</asp:ListItem>
                                                                        <asp:ListItem>Yes</asp:ListItem>
                                                                       
                                                                    </asp:DropDownList>
                                                                     &nbsp;
                                                                    <asp:Label ID="dd_golf_amt" runat="server" Text="0.00" CssClass="label" />
                                                                    &nbsp;
                                                                </td>
                                                            </tr>
                                                            <tr id="aegis_animal" style="display: " clientidmode="Static">
                                                                <td align="left">
                                                                    <asp:Label ID="Label151" runat="server" Text="Animal Injury Liability Exclusion:  " CssClass="label" />
                                                                    &nbsp
                                                                </td>
                                                                <td align="left">
                                                                    <asp:DropDownList ID="dd_animal" runat="server"  clientidmode="Static" 
                                                                        TabIndex="116">
                                                                        <asp:ListItem>No</asp:ListItem>
                                                                        <asp:ListItem>Yes</asp:ListItem>
                                                                        <%--<asp:ListItem>$0</asp:ListItem>
                                                                        <asp:ListItem>$25,000</asp:ListItem>
                                                                        <asp:ListItem>$50,000</asp:ListItem>
                                                                        <asp:ListItem>$100,000</asp:ListItem>
                                                                        <asp:ListItem>$300,000</asp:ListItem>--%>
                                                                     </asp:DropDownList>
                                                                     &nbsp;
                                                                    <asp:Label ID="dd_animal_amt" runat="server" Text="0.00" CssClass="label" />
                                                                    &nbsp;
                                                                </td>
                                                            </tr>
                                                            <tr id="aegis_pool" style="display: " clientidmode="Static">
                                                                <td align="left">
                                                                    <asp:Label ID="Label147" runat="server" Text="Limited Swimming Pool or Spa Liability:  " CssClass="label" />
                                                                    &nbsp
                                                                </td>
                                                                <td align="left">
                                                                    <asp:DropDownList ID="dd_pool" runat="server"  clientidmode="Static" 
                                                                        TabIndex="116">
                                                                        <asp:ListItem>No</asp:ListItem>
                                                                        <asp:ListItem>Yes</asp:ListItem>
                                                                       
                                                                    </asp:DropDownList>
                                                                     &nbsp;
                                                                    <asp:Label ID="dd_pool_amt" runat="server" Text="0.00" CssClass="label" />
                                                                    &nbsp;
                                                                </td>
                                                            </tr>
                                                            <tr>
                                                                <td align="left">
                                                                    <asp:Label ID="Label154" runat="server" Text="Valuable Personal Property:" CssClass="label" />
                                                                    &nbsp
                                                                </td>
                                                                <td align="left">
                                                                    <asp:DropDownList ID="dd_PackagePerProp_aiges" runat="server" TabIndex="19" ClientIDMode="Static">
                                                                        <asp:ListItem></asp:ListItem>
                                                                        <asp:ListItem>Yes</asp:ListItem>
                                                                        <asp:ListItem>No</asp:ListItem>
                                                                    </asp:DropDownList>
                                                                    &nbsp;
                                                                    <asp:Label ID="Label167" runat="server" Text="Value:" CssClass="label" />
                                                                    &nbsp;
                                                                    &nbsp;
                                                                    <asp:label ID="packagePerPropValue" runat="server" Text="0.00" Enabled="false" CssClass="label"  />
                                                                    &nbsp;
                                                                    &nbsp;
                                                                     &nbsp;
                                                                    &nbsp;
                                                                    <asp:Label ID="Label168" runat="server" Text="Premium" CssClass="label" />
                                                                    &nbsp;
                                                                    &nbsp;
                                                                    <asp:Label ID="dd_PackagePerProp_AR1_Amount" runat="server" Text="0.00" CssClass="label" />
                                                                    &nbsp;
                                                                </td>
                                                            </tr>
                                                                                                                        
                                                            <tr id="aigesPPl" style="display:">
                                                                <td align="left" colspan="2">
                                                                    <asp:Label ID="Label165" runat="server" Text="Valuable Personal Property list:" CssClass="label" />
                                                                    &nbsp
                                                                </td>
                                                                <td>
                                                                  
                                                             
                                                                    <asp:Button ID="btnshowPPL" runat="server" Text="Personal Property Break Down" />
                                                                  
                                                             
                                                              
                                                                    <dx:ASPxPopupControl ID="ASPxPopupControl7" runat="server"  PopupElementID="btnshowPPL" AllowDragging="True" HeaderText = "Scheduled Personal Property Details"
                                                                          MaxWidth="800px" MaxHeight="1800px" MinHeight="150px" MinWidth="150px" ShowFooter="True" Width="250px" Height="130px" >
                                                                   
                                                                        <ContentCollection>
                                                                            <dx:PopupControlContentControl runat="server" SupportsDisabledAttribute="True">
                                                                              <table>
                                                                                    <tr>
                                                                                    <td>
                                                                                    
                                                                                    
                                                                                  
                                                                                        <dx:ASPxPanel ID="ASPxPanel1" runat="server" >
                                                                                            <PanelCollection>
                                                                                                <dx:PanelContent ID="ppentry" runat="server" SupportsDisabledAttribute="True">
                                                                                                <table>
                                                                                                <tr>
                                                                                                <td>
                                                                                                    <asp:Label ID="Label169" runat="server" Text="Choose Category:"></asp:Label>
                                                                                                </td>
                                                                                                <td>
                                                                                                    <dx:ASPxComboBox ID="ppcatcmbo" runat="server" ValueType="System.String">
                                                                                                    <Items>
                                                                                                    <dx:ListEditItem Text="Antiques" Value= "Antiques" />
                                                                                                    <dx:ListEditItem Text="Cameras" Value= "Cameras" />
                                                                                                    <dx:ListEditItem Text="Coins" Value= "Coins" />
                                                                                                    <dx:ListEditItem Text="Fine Art" Value= "Fine Art" />
                                                                                                    <dx:ListEditItem Text="Furs" Value= "Furs" />
                                                                                                    <dx:ListEditItem Text="Gulf Equipment" Value= "Gulf Equipment" />
                                                                                                    <dx:ListEditItem Text="Guns" Value= "Guns" />
                                                                                                    <dx:ListEditItem Text="Jewelry" Value= "Jewelry" />
                                                                                                    <dx:ListEditItem Text="Musical Equipment" Value= "Musical Equipment" />
                                                                                                    <dx:ListEditItem Text="Stamps" Value= "Stamps" />
                                                                                                    <dx:ListEditItem Text="Other" Value= "Other" />
                                                                                                    </Items>
                                                                                                    </dx:ASPxComboBox>
                                                                                                </td>
                                                                                                </tr>
                                                                                                <tr>
                                                                                                <td>
                                                                                                <asp:Label ID="Label170" runat="server" Text="Description:"></asp:Label>
                                                                                                </td>
                                                                                                <td>
                                                                                                    <dx:ASPxTextBox ID="txtPPLDescription" runat="server" Width="170px">
                                                                                                    </dx:ASPxTextBox>
                                                                                                </td>
                                                                                                </tr>
                                                                                                 <tr>
                                                                                                <td>
                                                                                                <asp:Label ID="Label171" runat="server" Text="Quantity:"></asp:Label>
                                                                                                </td>
                                                                                                <td>
                                                                                                    <dx:ASPxTextBox ID="txtQuantityPPl" runat="server" Width="170px">
                                                                                                    </dx:ASPxTextBox>
                                                                                                </td>
                                                                                                </tr>
                                                                                                 <tr>
                                                                                                <td>
                                                                                                <asp:Label ID="Label172" runat="server" Text="Value:"></asp:Label>
                                                                                                </td>
                                                                                                <td>
                                                                                                    <dx:ASPxTextBox ID="txtvaluePPL" runat="server" Width="170px">
                                                                                                    </dx:ASPxTextBox>
                                                                                                </td>
                                                                                                </tr>
                                                                                                <tr>
                                                                                                <td colspan="2">
                                                                                                    <asp:Label ID="PPError" runat="server" Text="Error:"></asp:Label>
                                                                                                </td>
                                                                                                <td align="right">
                                                                                                    <asp:Button ID="btnAddPPL" runat="server" Text="Add" />
                                                                                                </td></tr>
                                                                                                </table>
                                                                                                </dx:PanelContent>
                                                                                            </PanelCollection>
                                                                                        </dx:ASPxPanel>

                                                                                          </td>
                                                                                          <td>
                                                                                           
                                                                                              <dx:ASPxGridView ID="AegisPPGrid" runat="server" AutoGenerateColumns="False" KeyFieldName="aegisppID" >
                                                                                                   <SettingsPager Visible="False">
                                                                                                    </SettingsPager>
                                                                                                    <SettingsEditing Mode="Inline" />
                                                                                                    <SettingsBehavior AllowFocusedRow="True" />
                                                                                                  <SettingsEditing Mode="Inline" /><SettingsBehavior AllowFocusedRow="True" /><Columns>
                                                                                                   <dx:GridViewCommandColumn VisibleIndex="0">
                                                                               
                                                                                                       <DeleteButton Visible="True">
                                                                                                        </DeleteButton>
                                                                                                    </dx:GridViewCommandColumn>
                                                                                                      <dx:GridViewDataTextColumn FieldName="aegisppID" Name="id" 
                                                                                                          ShowInCustomizationForm="True" Visible="False" VisibleIndex="6">
                                                                                                      </dx:GridViewDataTextColumn>
                                                                                                      <dx:GridViewDataTextColumn FieldName="QuoteID" Name="ppquoteid" 
                                                                                                          ShowInCustomizationForm="True" Visible="False" VisibleIndex="5">
                                                                                                      </dx:GridViewDataTextColumn>
                                                                                                      <dx:GridViewDataTextColumn Caption="Category" FieldName="CategoryPP" 
                                                                                                          Name="Catname" ShowInCustomizationForm="True" VisibleIndex="0">
                                                                                                      </dx:GridViewDataTextColumn>
                                                                                                      <dx:GridViewDataTextColumn Caption="Description" FieldName="DescriptionPP" 
                                                                                                          Name="ppdescription" ShowInCustomizationForm="True" VisibleIndex="1">
                                                                                                      </dx:GridViewDataTextColumn>
                                                                                                      <dx:GridViewDataTextColumn Caption="QTY" FieldName="QtyPP" Name="ppqty" 
                                                                                                          ShowInCustomizationForm="True" VisibleIndex="2">
                                                                                                      </dx:GridViewDataTextColumn>
                                                                                                      <dx:GridViewDataTextColumn Caption="Value" FieldName="ValuePP" Name="ppvalue" 
                                                                                                          ShowInCustomizationForm="True" VisibleIndex="3">
                                                                                                      </dx:GridViewDataTextColumn>
                                                                                                      <dx:GridViewDataTextColumn Caption="Total" FieldName="TotalPP" Name="pptotal" 
                                                                                                          ShowInCustomizationForm="True" VisibleIndex="4">
                                                                                                      </dx:GridViewDataTextColumn>
                                                                                                  </Columns>
                                                                                              </dx:ASPxGridView>
                                                                                              
                                                                                          </td>
                                                                                    </tr>
                                                                                    </table>
                                                                            </dx:PopupControlContentControl>
                                                                        </ContentCollection>
                                                                   
                                                                    </dx:ASPxPopupControl>
                                                                </td>
                                                            </tr>
                                                           
                                                            <tr>
                                                                <td align="left">
                                                                    <asp:Button ID="aiges1_updateOptions" runat="server" Text="Update Optional Coverages"
                                                                        OnClick="aiges_premiumbtnClick2" TabIndex="22" />
                                                                </td>
                                                            </tr>
                                                        </tbody>
                                                    </table>
                                                </td>
                                            </tr>
                                            <tr id="aiges_mh_prog3" runat="server" style="border: 1px solid black;">
                                                <td align="center" style="border: 1px solid" width="251px">
                                                    <label id="lblaiges_ShowOptions3" runat="server" style="color: Blue; cursor: pointer;"
                                                        onclick="AROptionsShow(6);" clientidmode="Static">
                                                       - Show Options</label>
                                                    <asp:HiddenField ID="lblaiges_ShowOptions3_hidden" runat="server" Value="+ Show Options" />
                                                </td>
                                                <td align="center" style="border: 1px solid">
                                                    <asp:Label ID="Label31" runat="server" Text="Aegis Rental" CssClass="labelCov" />
                                                </td>
                                                <td align="center" style="border: 1px solid">
                                                    <asp:Label ID="aiges_dwell3" runat="server" Text="0.00" CssClass="labelCov" />
                                                </td>
                                                <td align="center" style="border: 1px solid" class="style3">
                                                    <asp:Label ID="aiges_unattStr3" runat="server" Text="0.00" CssClass="labelCov" />
                                                </td>
                                                <td align="center" style="border: 1px solid">
                                                    <asp:Label ID="aiges_perEff3" runat="server" Text="0.00" CssClass="labelCov" />
                                                </td>
                                                <td align="center" style="border: 1px solid;">
                                                    <asp:Label ID="aiges_perLiab3" runat="server" Text="0.00" CssClass="labelCov" />
                                                </td>
                                                <td align="center" style="border: 1px solid">
                                                    <asp:Label ID="aiges_medpay3" runat="server" Text="0.00" CssClass="labelCov" />
                                                </td>
                                                <td align="center" style="border: 1px solid">
                                                    <asp:Label ID="aiges_baseprem3" runat="server" Text="0.00" CssClass="labelCov" />
                                                </td>
                                                <td align="center" style="border: 1px solid">
                                                    <asp:Label ID="aiges_options3" runat="server" Text="0.00" CssClass="labelCov" />
                                                </td>
                                                <td align="center" style="border: 1px solid">
                                                    <asp:Label ID="aiges_fees3" runat="server" Text="0.00" CssClass="labelCov" />
                                                </td>
                                                <td align="center" style="border: 1px solid">
                                                    <asp:Label ID="aiges_tax3" runat="server" Text="$0.00" CssClass="labelCov" />
                                                </td>
                                                <td align="center" style="border: 1px solid">
                                                    <asp:Label ID="aiges_total3" runat="server" Text="0.00" CssClass="labelTotal" />
                                                </td>
                                                <td align="center" style="border: 1px solid">
                                                    <asp:Button ID="selectaiges2btn" runat="server" OnClick="selectaiges2btn_Click" Text="Select" />
                                                </td>
                                            </tr>
                                            <tr id="aiges_mh_prog3_Options1" runat="server" clientidmode="Static">
                                                <td colspan="13">
                                                    <table id="Table2" runat="server" width="auto" cellpadding="0" cellspacing="0"
                                                        clientidmode="Static" bgcolor="white" title="Aegis Rental Options">
                                                        <tbody>
                                                            <tr>
                                                                <td>
                                                                    <input id="aegisRentalbtn" type="button" value="Open Calc Detail" />
                                                                    <asp:Label ID="txt_dwell_aiges2_Amount" runat="server" Text="0.00" CssClass="label" Style="display:none" />
                                                                    &nbsp;
                                                                    <asp:Label ID="txt_DedChange_aiges2_Amount" runat="server" Text="0.00" CssClass="label" Style="display:none" />
                                                                    <asp:Label ID="txt_Credit_aiges2_Amount" runat="server" Text="0.00" CssClass="label" Style="display:none" />
                                                                    &nbsp;
                                                                    <dx:ASPxPopupControl ID="ASPxPopupControl6" runat="server" PopupElementID="aegisRentalbtn" HeaderText="Rental Calculations" PopupVerticalAlign="Below" PopupHorizontalAlign="LeftSides" AllowDragging="True"
                                                                          MaxWidth="800px" MaxHeight="1800px" MinHeight="150px" MinWidth="150px" ShowFooter="True" >
                                                                    <ContentCollection>
                                                                        <dx:PopupControlContentControl ID="PopupControlContentControl7" runat="server">
                                                                            <asp:Panel ID="Panel5" runat="server">
                                                                                <table border="0" cellpadding="4" cellspacing="0">
                                                                                    <tr>
                                                                                        <td valign="top">
                                                                                            
                                                                                            <asp:Label ID="aiges2_Debug" runat="server" ClientIDMode="Static" Text=""></asp:Label>
                                                                                        </td>
                                                                                    </tr>
                                                                                  
                                                                                </table>
                                                                            </asp:Panel>
                                                                        </dx:PopupControlContentControl>
                                                                    </ContentCollection>

                                                                    </dx:ASPxPopupControl>
                                                                </td>
                                                            </tr>
                                                            <tr>
                                                                <td align="left">
                                                                    <asp:Label ID="Label32" runat="server" Text="AOP Deductible" CssClass="label" />
                                                                </td>
                                                                <td align="left">
                                                                    <asp:DropDownList ID="dd_aop_aiges2" runat="server" TabIndex="123">
                                                                        <asp:ListItem>$500</asp:ListItem>
                                                                        <asp:ListItem>$1000</asp:ListItem>
                                                                    </asp:DropDownList>
                                                                     &nbsp;<asp:Label ID="dd_aop_aiges2_Amount" runat="server" Text="0.00" CssClass="label" />
                                                                    &nbsp;
                                                                </td>
                                                            </tr>
                                                            <tr id="aegiswind2" runat="server">
                                                                <td align="left">
                                                                    <asp:Label ID="Label22" runat="server" Text="Named Storm Deductible" CssClass="label" />
                                                                </td>
                                                                <td align="left">
                                                                    <asp:TextBox ID="dd_hurded_aiges2" runat="server" Text="1500" 
                                                                        AutoCompleteType="DisplayName" Enabled="false" TabIndex="113" />
                                                                </td>
                                                            </tr>
                                                          <tr id="aegisWindhur2" runat="server">
                                                                <td align="left">
                                                                    <asp:Label ID="Label362" runat="server" Text="Wind\Hail\Tornado Deductible" CssClass="label" />
                                                                </td>
                                                                <td align="left">
                                                                    <asp:TextBox ID="aegishurrcanded2" runat="server" Text="0.00" 
                                                                        AutoCompleteType="DisplayName" Enabled="false" TabIndex="113" />
                                                                </td>
                                                            </tr>
                                                            <tr>
                                                                <td align="left">
                                                                    <asp:Label ID="Label35" runat="server" Text="Owner Landlord Liability Protection:  "
                                                                        CssClass="label" />
                                                                    &nbsp
                                                                </td>
                                                                <td align="left">
                                                                    <asp:DropDownList ID="dd_pl_aiges2" runat="server" TabIndex="126">
                                                                        <asp:ListItem>$0</asp:ListItem>
                                                                        <asp:ListItem>$25,000</asp:ListItem>
                                                                        <asp:ListItem>$50,000</asp:ListItem>
                                                                        <asp:ListItem>$100,000</asp:ListItem>
                                                                       <asp:ListItem>$300,000</asp:ListItem>
                                                                    </asp:DropDownList>
                                                                     &nbsp;<asp:Label ID="dd_pl_aiges2_Amount" runat="server" Text="0.00" CssClass="label" />
                                                                    &nbsp;
                                                                </td>
                                                            </tr>
                                                            <tr>
                                                                <td align="left">
                                                                    <asp:Label ID="Label36" runat="server" Text="Medical payment:  " CssClass="label" />
                                                                    &nbsp
                                                                </td>
                                                                <td align="left">
                                                                    <asp:DropDownList ID="dd_mp_aiges2" runat="server" TabIndex="127">
                                                                        <asp:ListItem></asp:ListItem>
                                                                        <asp:ListItem>$500</asp:ListItem>
                                                                        
                                                                    </asp:DropDownList>
                                                                     &nbsp;<asp:Label ID="dd_med_aiges2_amt" runat="server" Text="0.00" CssClass="label" />
                                                                    &nbsp;
                                                                </td>
                                                            </tr>
                                                            <tr>
                                                                <td align="left">
                                                                    <asp:Label ID="Label37" runat="server" Text="Other Structures:  " CssClass="label" />
                                                                    &nbsp
                                                                </td>
                                                                <td align="left">
                                                                    <asp:TextBox ID="txt_unattstr_aiges2" runat="server" Text="0.00" AutoCompleteType="DisplayName"
                                                                        Casing="UPPER" ToolTip="Unattached Structure" Width="65px" TabIndex="128" 
                                                                        Height="22px" />
                                                                        &nbsp;<asp:Label ID="txt_unattstr_aiges2_Amount" runat="server" Text="0.00" CssClass="label" />
                                                                    &nbsp;
                                                                </td>
                                                            </tr>
                                                            
                                                            <tr>
                                                                <td align="left">
                                                                    <asp:Label ID="Label153" runat="server" Text="Contents:  " CssClass="label" />
                                                                    &nbsp
                                                                </td>
                                                                <td align="left">
                                                                    <asp:TextBox ID="dd_aegiscontentsrental" runat="server" Text="0.00" AutoCompleteType="DisplayName"
                                                                        Casing="UPPER" ToolTip="Personal Property" Width="65" TabIndex="118" />
                                                                    &nbsp;<asp:Label ID="Label155" runat="server" Text="0.00" CssClass="label" />
                                                                    &nbsp;
                                                                </td>
                                                            </tr>
                                                            <tr id="aegis_animalreny" style="display: " clientidmode="Static">
                                                                <td align="left">
                                                                    <asp:Label ID="Label156" runat="server" Text="Animal Injury Liability Exclusion:  " CssClass="label" />
                                                                    &nbsp
                                                                </td>
                                                                <td align="left">
                                                                    <asp:DropDownList ID="dd_animalreny" runat="server"  clientidmode="Static" 
                                                                        TabIndex="116">
                                                                        <asp:ListItem>$0</asp:ListItem>
                                                                        <asp:ListItem>$25,000</asp:ListItem>
                                                                        <asp:ListItem>$50,000</asp:ListItem>
                                                                        <asp:ListItem>$100,000</asp:ListItem>
                                                                        <asp:ListItem>$300,000</asp:ListItem>
                                                                     </asp:DropDownList>
                                                                     &nbsp;
                                                                    <asp:Label ID="Label157" runat="server" Text="0.00" CssClass="label" />
                                                                    &nbsp;
                                                                </td>
                                                            </tr>
                                                            <tr id="aegis_icedeleterent" style="display: " clientidmode="Static">
                                                                <td align="left">
                                                                    <asp:Label ID="Label158" runat="server" Text="Weight of ice, Snow or Sleet (Deletion):  " CssClass="label" />
                                                                    &nbsp
                                                                </td>
                                                                <td align="left">
                                                                    <asp:DropDownList ID="dd_icedeleterent" runat="server"  clientidmode="Static" 
                                                                        TabIndex="116">
                                                                        <asp:ListItem>No</asp:ListItem>
                                                                        <asp:ListItem>Yes</asp:ListItem>
                                                                       
                                                                    </asp:DropDownList>
                                                                     &nbsp;
                                                                    <asp:Label ID="dd_icedeletrent_amt" runat="server" Text="0.00" CssClass="label" />
                                                                    &nbsp;
                                                                </td>
                                                            </tr>
                                                            <tr>
                                                                <td align="left">
                                                                    <asp:Button ID="aiges2_updateOptions" runat="server" Text="Update Optional Coverages"
                                                                        OnClick="aiges_premiumbtnClick3" TabIndex="33" />
                                                                </td>
                                                            </tr>
                                                        </tbody>
                                                    </table>
                                                </td>
                                            </tr>
          
                                            <%--AIGES END--%>
                                           <%-- AMSLIC START--%>
                                          <tr id="amslic_mh_prog" runat="server" style="border: 1px solid black;">
                                                
                                                    <td align="center" width="251px" style="border: 1px solid">
                                                        <label ID="lblamslicShowOptions" runat="server" clientidmode="Static" 
                                                            onclick="AROptionsShow(7);" style="color: Blue; cursor: pointer;">
                                                        - Show Options</label>
                                                        <asp:HiddenField ID="lblamslicShowOptions2_hidden" runat="server" 
                                                            Value="+ Show Options" />
                                                    </td>
                                                    <td align="center" style="border: 1px solid">
                                                        <asp:Label ID="Label30" runat="server" CssClass="labelCov" 
                                                            Text="AMSLIC Standard" />
                                                    </td>
                                                    <td align="center" style="border: 1px solid">
                                                        <asp:Label ID="amslic_dwell" runat="server" CssClass="labelCov" Text="0.00" />
                                                    </td>
                                                    <td align="center" class="style3" style="border: 1px solid">
                                                        <asp:Label ID="amslic_unattStr" runat="server" CssClass="labelCov" 
                                                            Text="0.00" />
                                                    </td>
                                                    <td align="center" style="border: 1px solid">
                                                        <asp:Label ID="amslic_perEff" runat="server" CssClass="labelCov" Text="0.00" />
                                                    </td>
                                                    <td align="center" style="border: 1px solid;">
                                                        <asp:Label ID="amslic_perLiab" runat="server" CssClass="labelCov" Text="0.00" />
                                                    </td>
                                                    <td align="center" style="border: 1px solid">
                                                        <asp:Label ID="amslic_medpay" runat="server" CssClass="labelCov" Text="0.00" />
                                                    </td>
                                                    <td align="center" style="border: 1px solid">
                                                        <asp:Label ID="amslic_baseprem" runat="server" CssClass="labelCov" 
                                                            Text="0.00" />
                                                    </td>
                                                    <td align="center" style="border: 1px solid">
                                                        <asp:Label ID="amslic_options" runat="server" CssClass="labelCov" Text="0.00" />
                                                    </td>
                                                    <td align="center" style="border: 1px solid">
                                                        <asp:Label ID="amslic_fees" runat="server" CssClass="labelCov" Text="0.00" />
                                                    </td>
                                                    <td align="center" style="border: 1px solid">
                                                        <asp:Label ID="amslic_tax" runat="server" CssClass="labelCov" Text="0.00" />
                                                    </td>
                                                    <td align="center" style="border: 1px solid">
                                                        <asp:Label ID="amslic_total" runat="server" CssClass="labelTotal" Text="0.00" />
                                                    </td>
                                                    <td align="center" style="border: 1px solid">
                                                        <asp:Button ID="selectamslicbtn" runat="server" OnClick="selectamslicbtn_Click" 
                                                            Text="Select" />
                                                    </td>
                                                </tr>
                                                <tr ID="amslic_mh_prog_Options" runat="server" clientidmode="Static">
                                                    <td colspan="13">
                                                        <table ID="amslicOptionRow" runat="server" bgcolor="white" cellpadding="0" 
                                                            cellspacing="0" clientidmode="Static" title="amslic Options" width="auto">
                                                            <tbody>
                                                                <tr>
                                                                    <td align="left">
                                                                        <input id="amslicshowcalc" type="button" value="Open Calc Detail"  />
                                                                        <asp:Label ID="txt_dwell_amslic_Amount" runat="server" CssClass="label" 
                                                                            Style="display:none" Text="0.00" />
                                                                        &nbsp;
                                                                        <asp:Label ID="txt_DedChange_amslic_Amount" runat="server" CssClass="label" 
                                                                            Style="display:none" Text="0.00" />
                                                                        <asp:Label ID="txt_Credit_amslic_Amount" runat="server" CssClass="label" 
                                                                            Style="display:none" Text="0.00" />
                                                                        &nbsp;
                                                                        <dx:ASPxPopupControl ID="ASPxPopupControl8" runat="server" AllowDragging="True" 
                                                                            HeaderText="Standard Calculations" Height="130px" MaxHeight="1800px" 
                                                                            MaxWidth="800px" MinHeight="150px" MinWidth="150px" PopupElementID="amslicshowcalc" 
                                                                            PopupHorizontalAlign="LeftSides" PopupVerticalAlign="Below" ShowFooter="True" 
                                                                            Width="250px">
                                                                            <ContentCollection>
                                                                                <dx:PopupControlContentControl ID="PopupControlContentControl8" runat="server">
                                                                                    <asp:Panel ID="Panel7" runat="server">
                                                                                        <table border="0" cellpadding="4" cellspacing="0">
                                                                                            <tr>
                                                                                                <td valign="top">
                                                                                                    <asp:Label ID="amslic_Debug" runat="server" ClientIDMode="Static" Text=""></asp:Label>
                                                                                                </td>
                                                                                            </tr>
                                                                                        </table>
                                                                                    </asp:Panel>
                                                                                </dx:PopupControlContentControl>
                                                                            </ContentCollection>
                                                                        </dx:ASPxPopupControl>
                                                                    </td>
                                                                </tr>
                                                                <tr>
                                                                    <td align="left">
                                                                        <asp:Label ID="Label33" runat="server" CssClass="label" Text="AOP Deductible" />
                                                                    </td>
                                                                    <td align="left">
                                                                        <asp:DropDownList ID="dd_aop_amslic" runat="server" TabIndex="112">
                                                                            <%--<asp:ListItem>$500</asp:ListItem>--%>
                                                                            <asp:ListItem>$1000</asp:ListItem>
                                                                        </asp:DropDownList>
                                                                        &nbsp;<asp:Label ID="dd_aop_amslic_Amount" runat="server" CssClass="label" 
                                                                            Text="0.00" />
                                                                        &nbsp;
                                                                    </td>
                                                                </tr>
                                                                <tr>
                                                                    <td align="left">
                                                                        <asp:Label ID="Label34" runat="server" CssClass="label" 
                                                                            Text="Windstorm/Hail Deductible:" />
                                                                    </td>
                                                                    <td align="left">
                                                                        <asp:TextBox ID="dd_windded_amslic" runat="server" 
                                                                            AutoCompleteType="DisplayName" Enabled="false" TabIndex="113" Text="$1000" />
                                                                    </td>
                                                                </tr>
                                                                 <tr>
                                                                    <td align="left">
                                                                        <asp:Label ID="Label38" runat="server" CssClass="label" 
                                                                            Text="Hurricane/Tropical Storm Deductible:" />
                                                                    </td>
                                                                    <td align="left">
                                                                        <asp:TextBox ID="dd_hurded_amslic" runat="server" 
                                                                            AutoCompleteType="DisplayName" Enabled="false" TabIndex="113" Text="$1000" />
                                                                    </td>
                                                                </tr>
                                                               <%-- <tr ID="Tr1">
                                                                    <td align="left">
                                                                        <asp:Label ID="Label38" runat="server" CssClass="label" 
                                                                            Text="Hurricane/Tropical Storm" />
                                                                    </td>
                                                                    <td align="left">
                                                                        <asp:TextBox ID="dd_thur_amslic" runat="server" AutoCompleteType="DisplayName" 
                                                                            Enabled="false" TabIndex="114" Text="0.00" />
                                                                    </td>
                                                                </tr>--%>
                                                                <tr>
                                                                    <td>
                                                                        &nbsp;
                                                                    </td>
                                                                </tr>
                                                                <tr>
                                                                    <td align="left">
                                                                        <asp:Label ID="Label39" runat="server" CssClass="label" 
                                                                            Text="Personal Liability:  " />
                                                                        &nbsp;
                                                                    </td>
                                                                    <td align="left">
                                                                        <asp:DropDownList ID="dd_pl_amslic" runat="server" AutoPostBack="true" 
                                                                            TabIndex="115">
                                                                            <%--<asp:ListItem>$0</asp:ListItem>--%>
                                                                           <%-- <asp:ListItem>$25,000</asp:ListItem>--%>
                                                                            <asp:ListItem>$50,000</asp:ListItem>
                                                                           <%-- <asp:ListItem>$100,000</asp:ListItem>--%>
                                                                            <%--<asp:ListItem>$300,000</asp:ListItem>--%>
                                                                        </asp:DropDownList>
                                                                        &nbsp;<asp:Label ID="dd_pl_amslic_Amount" runat="server" CssClass="label" 
                                                                            Text="0.00" />
                                                                        &nbsp;
                                                                    </td>
                                                                </tr>
                                                                <tr id="amslic_StandamslicdMedPay" clientidmode="Static" style="display: ">
                                                                    <td align="left">
                                                                        <asp:Label ID="Label40" runat="server" CssClass="label" 
                                                                            Text="Medical payment:  " />
                                                                        &nbsp;
                                                                    </td>
                                                                    <td align="left">
                                                                        <asp:DropDownList ID="dd_mp_amslic" runat="server" clientidmode="Static" 
                                                                            TabIndex="116">
                                                                           <%-- <asp:ListItem>$0</asp:ListItem>--%>
                                                                            <asp:ListItem>$500</asp:ListItem>
                                                                        </asp:DropDownList>
                                                                        &nbsp;
                                                                        <asp:Label ID="dd_med_amslic_amt" runat="server" CssClass="label" Text="0.00" />
                                                                        &nbsp;
                                                                    </td>
                                                                </tr>
                                                                <tr>
                                                                    <td>
                                                                        &nbsp;
                                                                    </td>
                                                                </tr>
                                                                <tr>
                                                                    <td align="left">
                                                                        <asp:Label ID="Label41" runat="server" CssClass="label" 
                                                                            Text="Other Structures:  " />
                                                                        &nbsp;
                                                                    </td>
                                                                    <td align="left">
                                                                        <asp:TextBox ID="txt_unattstr_amslic" runat="server" 
                                                                            AutoCompleteType="DisplayName" Casing="UPPER" TabIndex="117" Text="0.00" 
                                                                            ToolTip="Unattached Structure" Width="65" />
                                                                        &nbsp;<asp:Label ID="txt_unattstr_amslic_Amount" runat="server" CssClass="label" 
                                                                            Text="0.00" />
                                                                        &nbsp;
                                                                    </td>
                                                                </tr>
                                                                <tr>
                                                                    <td align="left">
                                                                        <asp:Label ID="Label42" runat="server" CssClass="label" Text="Contents:  " />
                                                                        &nbsp;
                                                                    </td>
                                                                    <td align="left">
                                                                        <asp:TextBox ID="txt_pp_amslic" runat="server" AutoCompleteType="DisplayName" 
                                                                            Casing="UPPER" TabIndex="118" Text="0.00" ToolTip="Personal Property" 
                                                                            Width="65" />
                                                                        &nbsp;<asp:Label ID="txt_pp_amslic_Amount" runat="server" CssClass="label" 
                                                                            Text="0.00" />
                                                                        &nbsp;
                                                                    </td>
                                                                </tr>
                                                                <%--<tr>
                                                                    <td align="left">
                                                                        <asp:Label ID="Label43" runat="server" CssClass="label" 
                                                                            Text="Mobile Home Replacement Cost:  " />
                                                                        &nbsp;
                                                                    </td>
                                                                    <td align="left">
                                                                        <asp:DropDownList ID="dd_mhr_amslic" runat="server" TabIndex="119">
                                                                            <asp:ListItem>No</asp:ListItem>
                                                                            <asp:ListItem>Yes</asp:ListItem>
                                                                        </asp:DropDownList>
                                                                        &nbsp;<asp:Label ID="dd_mhr_amslic_Amount" runat="server" CssClass="label" 
                                                                            Text="0.00" />
                                                                        &nbsp;
                                                                    </td>
                                                                </tr>--%>
                                                                <tr>
                                                                    <td align="left">
                                                                        <asp:Label ID="Label44" runat="server" CssClass="label" 
                                                                            Text="Contents Replacement Cost:  " />
                                                                        &nbsp;
                                                                    </td>
                                                                    <td align="left">
                                                                        <asp:DropDownList ID="dd_rep_amslic" runat="server" ClientIDMode="Static" 
                                                                            TabIndex="120">
                                                                            <asp:ListItem>No</asp:ListItem>
                                                                            <asp:ListItem>Yes</asp:ListItem>
                                                                        </asp:DropDownList>
                                                                        &nbsp;
                                                                        <asp:Label ID="dd_rep_amslic_Amount" runat="server" CssClass="label" 
                                                                            Text="0.00" />
                                                                        &nbsp;
                                                                    </td>
                                                                </tr>
                                                                <tr>
                                                                    <td id="trmhamslicOpt2_2" align="left" clientidmode="Static">
                                                                        <asp:Label ID="Label45" runat="server" CssClass="label" Text="Full Repair:  " />
                                                                        &nbsp;
                                                                    </td>
                                                                    <td id="trmhamslicOpt2_2_d" align="left" clientidmode="Static">
                                                                        <asp:DropDownList ID="dd_sip_amslic2" runat="server" TabIndex="121">
                                                                            <asp:ListItem>No</asp:ListItem>
                                                                            <asp:ListItem>Yes</asp:ListItem>
                                                                        </asp:DropDownList>
                                                                        &nbsp;<asp:Label ID="dd_sip_amslic2_Amount" runat="server" CssClass="label" 
                                                                            Text="0.00" />
                                                                        &nbsp;
                                                                    </td>
                                                                </tr>
                                                                <tr>
                                                                    <td align="left">
                                                                        <asp:Button ID="amslic_updateOptions" runat="server" 
                                                                            OnClick="amslic_premiumbtnClick" TabIndex="22" 
                                                                            Text="Update Optional Coverages" />
                                                                    </td>
                                                                </tr>
                                                            </tbody>
                                                        </table>
                                                    </td>
                                                </tr>
                                                <tr ID="amslic_mh_progRent" runat="server" style="border: 1px solid black;">
                                                    <td align="center" width="251px" style="border: 1px solid">
                                                        <label ID="lblamslicShowOptionsRent" runat="server" clientidmode="Static" 
                                                            onclick="AROptionsShow(8);" style="color: Blue; cursor: pointer;">
                                                        - Show Options</label>
                                                        <asp:HiddenField ID="lblamslicShowOptionsRent_hidden" runat="server" 
                                                            Value="+ Show Options" />
                                                    </td>
                                                    <td align="center" style="border: 1px solid">
                                                        <asp:Label ID="Label46" runat="server" CssClass="labelCov" 
                                                            Text="AMSLIC Rental" />
                                                    </td>
                                                    <td align="center" style="border: 1px solid">
                                                        <asp:Label ID="amslic_dwell3" runat="server" CssClass="labelCov" Text="0.00" />
                                                    </td>
                                                    <td align="center" class="style3" style="border: 1px solid">
                                                        <asp:Label ID="amslic_unattStrRent" runat="server" CssClass="labelCov" 
                                                            Text="0.00" />
                                                    </td>
                                                    <td align="center" style="border: 1px solid">
                                                        <asp:Label ID="amslic_perEffRent" runat="server" CssClass="labelCov" 
                                                            Text="0.00" />
                                                    </td>
                                                    <td align="center" style="border: 1px solid;">
                                                        <asp:Label ID="amslic_perLiabRent" runat="server" CssClass="labelCov" 
                                                            Text="0.00" />
                                                    </td>
                                                    <td align="center" style="border: 1px solid">
                                                        <asp:Label ID="amslic_medpayRent" runat="server" CssClass="labelCov" 
                                                            Text="0.00" />
                                                    </td>
                                                    <td align="center" style="border: 1px solid">
                                                        <asp:Label ID="amslic_basepremRent" runat="server" CssClass="labelCov" 
                                                            Text="0.00" />
                                                    </td>
                                                    <td align="center" style="border: 1px solid">
                                                        <asp:Label ID="amslic_optionsRent" runat="server" CssClass="labelCov" 
                                                            Text="0.00" />
                                                    </td>
                                                    <td align="center" style="border: 1px solid">
                                                        <asp:Label ID="amslic_feesRent" runat="server" CssClass="labelCov" 
                                                            Text="0.00" />
                                                    </td>
                                                    <td align="center" style="border: 1px solid">
                                                        <asp:Label ID="amslic_taxRent" runat="server" CssClass="labelCov" Text="0.00" />
                                                    </td>
                                                    <td align="center" style="border: 1px solid">
                                                        <asp:Label ID="amslic_totalRent" runat="server" CssClass="labelTotal" 
                                                            Text="0.00" />
                                                    </td>
                                                    <td align="center" style="border: 1px solid">
                                                        <asp:Button ID="selectamslicRentbtn" runat="server" 
                                                            OnClick="selectamslicRentbtn_Click" Text="Select" />
                                                    </td>
                                                </tr>
                                                <tr ID="amslic_mh_progRent_Options" runat="server" clientidmode="Static">
                                                    <td colspan="13">
                                                        <table ID="amslicOptionRowRent" runat="server" bgcolor="white" cellpadding="0" 
                                                            cellspacing="0" clientidmode="Static" title="AMSLIC Options" width="auto">
                                                            <tbody>
                                                                <tr>
                                                                    <td>
                                                                        <input id="Button6" type="button" value="Open Calc Detail" />
                                                                        <asp:Label ID="txt_dwell_amslicRent_Amount" runat="server" CssClass="label" 
                                                                            Style="display:none" Text="0.00" />
                                                                        &nbsp;
                                                                        <asp:Label ID="txt_DedChange_amslicRent_Amount" runat="server" CssClass="label" 
                                                                            Style="display:none" Text="0.00" />
                                                                        <asp:Label ID="txt_Credit_amslicRent_Amount" runat="server" CssClass="label" 
                                                                            Style="display:none" Text="0.00" />
                                                                        &nbsp;
                                                                        <dx:ASPxPopupControl ID="ASPxPopupControl9" runat="server" AllowDragging="True" 
                                                                            HeaderText="Rental Calculations" MaxHeight="1800px" MaxWidth="800px" 
                                                                            MinHeight="150px" MinWidth="150px" PopupElementID="Button6" 
                                                                            PopupHorizontalAlign="LeftSides" PopupVerticalAlign="Below" ShowFooter="True">
                                                                            <ContentCollection>
                                                                                <dx:PopupControlContentControl ID="PopupControlContentControl9" runat="server">
                                                                                    <asp:Panel ID="Panel8" runat="server">
                                                                                        <table border="0" cellpadding="4" cellspacing="0">
                                                                                            <tr>
                                                                                                <td valign="top">
                                                                                                    <asp:Label ID="amslicRent_Debug" runat="server" ClientIDMode="Static" 
                                                                                                        Text="No Data"></asp:Label>
                                                                                                </td>
                                                                                            </tr>
                                                                                        </table>
                                                                                    </asp:Panel>
                                                                                </dx:PopupControlContentControl>
                                                                            </ContentCollection>
                                                                        </dx:ASPxPopupControl>
                                                                    </td>
                                                                </tr>
                                                                <tr>
                                                                    <td align="left">
                                                                        <asp:Label ID="Label47" runat="server" CssClass="label" Text="AOP Deductible" />
                                                                    </td>
                                                                    <td align="left">
                                                                        <asp:DropDownList ID="dd_aop_amslicRent" runat="server" TabIndex="123">
                                                                            <%--<asp:ListItem>$500</asp:ListItem>--%>
                                                                            <asp:ListItem>$1000</asp:ListItem>
                                                                        </asp:DropDownList>
                                                                        &nbsp;<asp:Label ID="dd_aop_amslicRent_Amount" runat="server" CssClass="label" 
                                                                            Text="0.00" />
                                                                        &nbsp;
                                                                    </td>
                                                                </tr>
                                                                <tr>
                                                                    <td align="left">
                                                                        <asp:Label ID="Label48" runat="server" CssClass="label" 
                                                                            Text="Wind/Hail Deductible" />
                                                                    </td>
                                                                    <td align="left">
                                                                        <asp:TextBox ID="dd_hurded_amslicRent" runat="server" 
                                                                            AutoCompleteType="DisplayName" Enabled="false" TabIndex="124" Text="0.00" />
                                                                    </td>
                                                                </tr>
                                                                <tr id="tstormRent" runat="server">
                                                                    <td align="left">
                                                                        <asp:Label ID="Label49" runat="server" CssClass="label" 
                                                                            Text="Hurricane/Tropical Storm" />
                                                                    </td>
                                                                    <td align="left">
                                                                        <asp:TextBox ID="dd_thur_amslicRent" runat="server" 
                                                                            AutoCompleteType="DisplayName" Enabled="false" TabIndex="125" Text="0.00" />
                                                                    </td>
                                                                </tr>
                                                                <tr>
                                                                    <td align="left">
                                                                        <asp:Label ID="Label50" runat="server" CssClass="label" 
                                                                            Text="Owner Landlord Liability Protection:  " />
                                                                        &nbsp;
                                                                    </td>
                                                                    <td align="left">
                                                                        <asp:DropDownList ID="dd_pl_amslicRent" runat="server" TabIndex="126">
                                                                            <asp:ListItem></asp:ListItem>
                                                                            <%--<asp:ListItem>$25,000</asp:ListItem>--%>
                                                                            <asp:ListItem>$50,000</asp:ListItem>
                                                                            <%--<asp:ListItem>$100,000</asp:ListItem>--%>
                                                                        </asp:DropDownList>
                                                                        &nbsp;<asp:Label ID="dd_pl_amslicRent_Amount" runat="server" CssClass="label" 
                                                                            Text="0.00" />
                                                                        &nbsp;
                                                                    </td>
                                                                </tr>
                                                                <tr>
                                                                    <td align="left">
                                                                        <asp:Label ID="Label51" runat="server" CssClass="label" 
                                                                            Text="Medical payment:  " />
                                                                        &nbsp;
                                                                    </td>
                                                                    <td align="left">
                                                                        <asp:DropDownList ID="dd_mp_amslicRent" runat="server" TabIndex="127">
                                                                            <asp:ListItem></asp:ListItem>
                                                                            <asp:ListItem>$500</asp:ListItem>
                                                                        </asp:DropDownList>
                                                                        &nbsp;<asp:Label ID="dd_med_amslicRent_amt" runat="server" CssClass="label" 
                                                                            Text="0.00" />
                                                                        &nbsp;
                                                                    </td>
                                                                </tr>
                                                               <%-- <tr>
                                                                    <td align="left">
                                                                        <asp:Label ID="Label52" runat="server" CssClass="label" 
                                                                            Text="Other Structures:  " />
                                                                        &nbsp;
                                                                    </td>
                                                                    <td align="left">
                                                                        <asp:TextBox ID="txt_unattstr_amslicRent" runat="server" 
                                                                            AutoCompleteType="DisplayName" Casing="UPPER" TabIndex="128" Text="0.00" 
                                                                            ToolTip="Unattached Structure" Width="65" />
                                                                        &nbsp;<asp:Label ID="txt_unattstr_amslicRent_Amount" runat="server" CssClass="label" 
                                                                            Text="0.00" />
                                                                        &nbsp;
                                                                    </td>
                                                                </tr>--%>
                                                                <%--<tr>
                                                                    <td align="left">
                                                                        <asp:Label ID="Label53" runat="server" CssClass="label" Text="Contents:  " />
                                                                        &nbsp;
                                                                    </td>
                                                                    <td align="left">
                                                                        <asp:TextBox ID="txt_pp_amslicRent" runat="server" 
                                                                            AutoCompleteType="DisplayName" Casing="UPPER" TabIndex="129" Text="0.00" 
                                                                            ToolTip="Personal Property" Width="65" />
                                                                        &nbsp;<asp:Label ID="txt_pp_amslicRent_Amount" runat="server" CssClass="label" 
                                                                            Text="0.00" />
                                                                        &nbsp;
                                                                    </td>
                                                                </tr>--%>
                                                                <tr id="amslicmhreplacerent" runat="server">
                                                                    <td align="left">
                                                                        <asp:Label ID="Label54" runat="server" CssClass="label" 
                                                                            Text="Mobile Home Replacement Cost:  " />
                                                                        &nbsp;
                                                                    </td>
                                                                    <td align="left">
                                                                        <asp:DropDownList ID="dd_mhr_amslicRent" runat="server" TabIndex="130">
                                                                            <asp:ListItem>No</asp:ListItem>
                                                                            <asp:ListItem>Yes</asp:ListItem>
                                                                        </asp:DropDownList>
                                                                        &nbsp;<asp:Label ID="dd_mhr_amslicRent_Amount" runat="server" CssClass="label" 
                                                                            Text="0.00" />
                                                                        &nbsp;
                                                                    </td>
                                                                </tr>
                                                                <tr id="amslicmhcontentrent" runat="server">
                                                                    <td align="left">
                                                                        <asp:Label ID="Label55" runat="server" CssClass="label" 
                                                                            Text="Contents Replacement Cost:  " />
                                                                        &nbsp;
                                                                    </td>
                                                                    <td align="left">
                                                                        <asp:DropDownList ID="dd_rep_amslicRent" runat="server" ClientIDMode="Static" 
                                                                            TabIndex="131">
                                                                            <asp:ListItem>No</asp:ListItem>
                                                                            <asp:ListItem>Yes</asp:ListItem>
                                                                        </asp:DropDownList>
                                                                        &nbsp;
                                                                        <asp:Label ID="dd_rep_amslicRent_Amount" runat="server" CssClass="label" 
                                                                            Text="0.00" />
                                                                        &nbsp;
                                                                    </td>
                                                                </tr>
                                                               <%-- <tr>
                                                                    <td id="Td5" align="left" clientidmode="Static">
                                                                        <asp:Label ID="Label56" runat="server" CssClass="label" Text="Full Repair:  " />
                                                                        &nbsp;
                                                                    </td>
                                                                    <td id="Td6" align="left" clientidmode="Static">
                                                                        <asp:DropDownList ID="dd_sip_amslicRent" runat="server" TabIndex="132">
                                                                            <asp:ListItem>No</asp:ListItem>
                                                                            <asp:ListItem>Yes</asp:ListItem>
                                                                        </asp:DropDownList>
                                                                        &nbsp;<asp:Label ID="dd_sip_amslicRent_Amount" runat="server" CssClass="label" 
                                                                            Text="0.00" />
                                                                        &nbsp;
                                                                    </td>
                                                                </tr>--%>
                                                                <tr>
                                                                    <td align="left">
                                                                        <asp:Button ID="amslicRent_updateOptions" runat="server" 
                                                                            OnClick="amslic_premiumbtnClickRent" TabIndex="33" 
                                                                            Text="Update Optional Coverages" />
                                                                    </td>
                                                                </tr>
                                                            </tbody>
                                                        </table>
                                                    </td>
                                                </tr>
                                                <%--AMSLIC END--%>
                                                <%-- wmj START--%>
                                            <tr id="wmj_mh_prog2" runat="server" style="border: 1px solid black;">
                                                <td align="center" style="border: 1px solid" width="251px">
                                                    <label id="lblwmj_ShowOptions2" runat="server" style="color: Blue; cursor: pointer;"
                                                        onclick="AROptionsShow(9);" clientidmode="Static">
                                                        - Show Options</label>
                                                    <asp:HiddenField ID="lblwmj_ShowOptions2_hidden" runat="server" Value="+ Show Options" />
                                                </td>
                                                <td align="center" style="border: 1px solid">
                                                    <asp:Label ID="Label43" runat="server" Text="WMJ Standard" CssClass="labelCov" />
                                                </td>
                                                <td align="center" style="border: 1px solid">
                                                    <asp:Label ID="wmj_dwell2" runat="server" Text="0.00" CssClass="labelCov" />
                                                </td>
                                                <td align="center" style="border: 1px solid" class="style3">
                                                    <asp:Label ID="wmj_unattStr2" runat="server" Text="0.00" CssClass="labelCov" />
                                                </td>
                                                <td align="center" style="border: 1px solid">
                                                    <asp:Label ID="wmj_perEff2" runat="server" Text="0.00" CssClass="labelCov" />
                                                </td>
                                                <td align="center" style="border: 1px solid;">
                                                    <asp:Label ID="wmj_perLiab2" runat="server" Text="0.00" CssClass="labelCov" />
                                                </td>
                                                <td align="center" style="border: 1px solid">
                                                    <asp:Label ID="wmj_medpay2" runat="server" Text="0.00" CssClass="labelCov" />
                                                </td>
                                                <td align="center" style="border: 1px solid">
                                                    <asp:Label ID="wmj_baseprem2" runat="server" Text="0.00" CssClass="labelCov" />
                                                </td>
                                                <td align="center" style="border: 1px solid">
                                                    <asp:Label ID="wmj_options2" runat="server" Text="0.00" CssClass="labelCov" />
                                                </td>
                                                <td align="center" style="border: 1px solid">
                                                    <asp:Label ID="wmj_fees2" runat="server" Text="$0.00" CssClass="labelCov" />
                                                </td>
                                                <td align="center" style="border: 1px solid">
                                                    <asp:Label ID="wmj_tax2" runat="server" Text="0.00" CssClass="labelCov" />
                                                </td>
                                                <td align="center" style="border: 1px solid">
                                                    <asp:Label ID="wmj_total2" runat="server" Text="0.00" CssClass="labelTotal" />
                                                </td>
                                                <td align="center" style="border: 1px solid">
                                                    <asp:Button ID="selectwmj_2btn" runat="server" OnClick="selectwmj1btn_Click" Text="Select" />
                                                </td>
                                            </tr>
                                            <tr id="wmj_mh_prog2_Options" runat="server" clientidmode="Static">
                                                <td colspan="13">
                                                    <table id="Table3" runat="server" width="auto" cellpadding="0" cellspacing="0"
                                                        clientidmode="Static" bgcolor="white" title="AR Options">
                                                        <tbody>
                                                            <tr>
                                                                <td align="left">
                                                                    <input id="Button5" type="button" value="Open Calc Detail"  />
                                                                    <asp:Label ID="txt_dwell_wmj_Amount" runat="server" Text="0.00" CssClass="label" Style="display:none" />
                                                                    &nbsp;
                                                                    <asp:Label ID="txt_DedChange_wmj_Amount" runat="server" Text="0.00" CssClass="label" Style="display:none" />
                                                                    <asp:Label ID="txt_Credit_wmj_Amount" runat="server" Text="0.00" CssClass="label" Style="display:none" />
                                                                    &nbsp;
                                                                    <dx:ASPxPopupControl ID="ASPxPopupControl10" runat="server" PopupElementID="Button5" HeaderText="Standard Calculations" PopupVerticalAlign="Below" PopupHorizontalAlign="LeftSides" AllowDragging="True"
                                                                          MaxWidth="800px" MaxHeight="1800px" MinHeight="150px" MinWidth="150px" ShowFooter="True" Width="250px" Height="130px" >
                                                                    <ContentCollection>
                                                                        <dx:PopupControlContentControl ID="PopupControlContentControl10" runat="server">
                                                                            <asp:Panel ID="Panel9" runat="server">
                                                                                <table border="0" cellpadding="4" cellspacing="0">
                                                                                    <tr>
                                                                                        <td valign="top">
                                                                                            
                                                                                            <asp:Label ID="wmj_Debug" runat="server" ClientIDMode="Static" Text=""></asp:Label>
                                                                                        </td>
                                                                                    </tr>
                                                                                  
                                                                                </table>
                                                                            </asp:Panel>
                                                                        </dx:PopupControlContentControl>
                                                                    </ContentCollection>

                                                                    </dx:ASPxPopupControl>
                                                                </td>
                                                            </tr>
                                                            <tr>
                                                                <td align="left">
                                                                    <asp:Label ID="Label57" runat="server" Text="AOP Deductible" CssClass="label" />
                                                                </td>
                                                                <td align="left">
                                                                    <asp:DropDownList ID="dd_aop_wmj1" runat="server" TabIndex="112">
                                                                        <asp:ListItem>$500</asp:ListItem>
                                                                       <asp:ListItem>$1000</asp:ListItem>
                                                                    </asp:DropDownList>
                                                                     &nbsp;<asp:Label ID="dd_aop_wmj1_Amount" runat="server" Text="0.00" CssClass="label" />
                                                                    &nbsp;
                                                                </td>
                                                            </tr>
                                                            <%--<tr id="wmjWind" runat="server">
                                                                <td align="left">
                                                                    <asp:Label ID="Label58" runat="server" Text="Named Storm Deductible" CssClass="label" />
                                                                </td>
                                                                <td align="left">
                                                                    <asp:TextBox ID="dd_hurded_wmj1" runat="server" Text="0.00" 
                                                                        AutoCompleteType="DisplayName" Enabled="false" TabIndex="113" />
                                                                </td>
                                                            </tr>--%>
                                                            <tr id="tr1">
                                                                <td align="left">
                                                                    <asp:Label ID="Label97" runat="server" Text="Loss of Use" CssClass="label" />
                                                                </td>
                                                                <td align="left">
                                                                    <asp:TextBox ID="wmjlossofuse" runat="server" Text="0.00" 
                                                                        AutoCompleteType="DisplayName" Enabled="false" TabIndex="303" />
                                                                </td>
                                                            </tr>
                                                            <tr>
                                                                <td>
                                                                    &nbsp;
                                                                </td>
                                                            </tr>
                                                            <tr>
                                                                <td align="left">
                                                                    <asp:Label ID="Label59" runat="server" Text="Personal Liability:  " CssClass="label" />
                                                                    &nbsp
                                                                </td>
                                                                <td align="left">
                                                                    <asp:DropDownList ID="dd_pl_wmj1" runat="server" AutoPostBack="true" 
                                                                        TabIndex="115" >
                                                                        <%--<asp:ListItem>$0</asp:ListItem>--%>
                                                                    
                                                                        <asp:ListItem>$50,000</asp:ListItem>
                                                                        <asp:ListItem>$100,000</asp:ListItem>
                                                                       <asp:ListItem>$300,000</asp:ListItem>
                                                                    </asp:DropDownList>
                                                                    &nbsp;<asp:Label ID="dd_pl_wmj1_Amount" runat="server" Text="0.00" CssClass="label" />
                                                                    &nbsp;
                                                                </td>
                                                            </tr>
                                                            <tr id="wmj_StandardMedPay" style="display: " clientidmode="Static">
                                                                <td align="left">
                                                                    <asp:Label ID="Label60" runat="server" Text="Medical payment:  " CssClass="label" />
                                                                    &nbsp
                                                                </td>
                                                                <td align="left">
                                                                    <asp:DropDownList ID="dd_mp_wmj1" runat="server"  clientidmode="Static" 
                                                                        TabIndex="116">
                                                                        <asp:ListItem>$0</asp:ListItem>
                                                                        <asp:ListItem>$500</asp:ListItem>
                                                                       
                                                                    </asp:DropDownList>
                                                                     &nbsp;
                                                                    <asp:Label ID="dd_med_wmj1_amt" runat="server" Text="0.00" CssClass="label" />
                                                                    &nbsp;
                                                                </td>
                                                            </tr>
                                                             <tr style="border: 1px solid black">
                                                                <td align="left">
                                                                    <asp:Label ID="Label99" runat="server" Text="Additional Residence:" CssClass="label" />
                                                                    &nbsp
                                                                </td>
                                                                <td align="left">
                                                                    <asp:DropDownList ID="dd_addresOpt_ar1" runat="server" ClientIDMode="Static">
                                                                        <asp:ListItem></asp:ListItem>
                                                                        <%--<asp:ListItem>Premises Occupied by Insured</asp:ListItem>--%>
                                                                        <asp:ListItem>1 Family</asp:ListItem>
                                                                        <asp:ListItem>2 Family</asp:ListItem>
                                                                    </asp:DropDownList>
                                                                    &nbsp;
                                                                    <asp:Label ID="dd_addresOpt_ar1_Amount" runat="server" Text="0.00" CssClass="label" />
                                                                    &nbsp;
                                                                </td>
                                                            </tr>
                                                            <tr id="wmj_AddResOpt1_ar1" clientidmode="Static">
                                                                <td align="left">
                                                                   <%-- <asp:HiddenField ID="AR_AddResOpt1_HIDDEN" runat="server" />--%>
                                                                    <asp:Label ID="Label96" runat="server" Text="Additional Residence Liability" CssClass="label" />
                                                                    &nbsp
                                                                </td>
                                                                <td align="left">
                                                                    <asp:DropDownList ID="dd_addresliab_wmj" runat="server" ClientIDMode="Static">
                                                                        <asp:ListItem>$0</asp:ListItem>
                                                                        <asp:ListItem>$50,000</asp:ListItem>
                                                                        <asp:ListItem>$100,000</asp:ListItem>
                                                                        <asp:ListItem>$300,000</asp:ListItem>
                                                                    </asp:DropDownList>
                                                                      &nbsp;
                                                                    <asp:Label ID="addres_liab_amount" runat="server" Text="0.00" CssClass="label" />
                                                                    &nbsp;
                                                                </td>
                                                            </tr>
                                                            <tr>
                                                                <td>
                                                                    &nbsp;
                                                                </td>
                                                            </tr>
                                                            <tr>
                                                                <td align="left">
                                                                    <asp:Label ID="Label62" runat="server" Text="Other Structures:  " CssClass="label" />
                                                                    &nbsp
                                                                </td>
                                                                <td align="left">
                                                                    <asp:TextBox ID="txt_unattstr_wmj1" runat="server" Text="0.00" AutoCompleteType="DisplayName"
                                                                        Casing="UPPER" ToolTip="Unattached Structure" Width="65" TabIndex="117"/>
                                                                    &nbsp;<asp:Label ID="txt_unattstr_wmj1_Amount" runat="server" Text="0.00" CssClass="label" />
                                                                    &nbsp;
                                                                </td>
                                                            </tr>
                                                            <tr>
                                                                <td align="left">
                                                                    <asp:Label ID="Label66" runat="server" Text="Contents:  " CssClass="label" />
                                                                    &nbsp
                                                                </td>
                                                                <td align="left">
                                                                    <asp:TextBox ID="txt_pp_wmj1" runat="server" Text="0.00" AutoCompleteType="DisplayName"
                                                                        Casing="UPPER" ToolTip="Personal Property" Width="65" TabIndex="118" />
                                                                    &nbsp;<asp:Label ID="txt_pp_wmj1_Amount" runat="server" Text="0.00" CssClass="label" />
                                                                    &nbsp;
                                                                </td>
                                                            </tr>
                                                            
                                                           <tr>
                                                                <td align="left">
                                                                    <asp:Label ID="Label68" runat="server" Text="Contents Replacement Cost:  " CssClass="label" />
                                                                    &nbsp
                                                                </td>
                                                                <td align="left">
                                                                    <asp:DropDownList ID="dd_rep_wmj1" runat="server" TabIndex="120" 
                                                                        ClientIDMode="Static">
                                                                        <asp:ListItem>No</asp:ListItem>
                                                                        <asp:ListItem>Yes</asp:ListItem>
                                                                    </asp:DropDownList>
                                                                    &nbsp;
                                                                    <asp:Label ID="dd_rep_wmj1_Amount" runat="server" Text="0.00" CssClass="label" />
                                                                    &nbsp;
                                                                </td>
                                                            </tr>
                                                            <tr>
                                                                <td align="left">
                                                                    <asp:Label ID="Label69" runat="server" Text="Smoke Detectors:  " CssClass="label" />
                                                                    &nbsp
                                                                </td>
                                                                <td align="left">
                                                                    <asp:DropDownList ID="dd_smoke_wmj1" runat="server" TabIndex="120" 
                                                                        ClientIDMode="Static">
                                                                        <asp:ListItem>No</asp:ListItem>
                                                                        <asp:ListItem>Yes</asp:ListItem>
                                                                    </asp:DropDownList>
                                                                    &nbsp;
                                                                    <asp:Label ID="dd_smoke_wmj1_amount" runat="server" Text="0.00" CssClass="label" />
                                                                    &nbsp;
                                                                </td>
                                                            </tr>
                                                            <%--<tr>
                                                                <td id="trmhwmjOpt2_2" align="left" clientidmode="Static">
                                                                    <asp:Label ID="Label69" runat="server" Text="Full Repair:  " CssClass="label" />
                                                                    &nbsp
                                                                </td>
                                                                <td id="trmhwmjOpt2_2_d" align="left" clientidmode="Static">
                                                                    <asp:DropDownList ID="dd_sip_wmj1" runat="server" TabIndex="121">
                                                                        <asp:ListItem>No</asp:ListItem>
                                                                        <asp:ListItem>Yes</asp:ListItem>
                                                                    </asp:DropDownList>
                                                                    &nbsp;<asp:Label ID="dd_sip_wmj1_Amount" runat="server" Text="0.00" CssClass="label" />
                                                                    &nbsp;
                                                                </td>
                                                            </tr>--%>
                                                            <tr>
                                                                <td align="left">
                                                                    <asp:Label ID="Label70" runat="server" Text="Secured Party's Interest:  " CssClass="label" />
                                                                    &nbsp
                                                                </td>
                                                                <td align="left">
                                                                    <asp:DropDownList ID="spi_cbo" runat="server" TabIndex="120" 
                                                                        ClientIDMode="Static">
                                                                        <asp:ListItem>No</asp:ListItem>
                                                                        <asp:ListItem>Yes</asp:ListItem>
                                                                    </asp:DropDownList>
                                                                    &nbsp;
                                                                    <asp:Label ID="spi_amount" runat="server" Text="0.00" CssClass="label" />
                                                                    &nbsp;
                                                                </td>
                                                            </tr>
                                                            <tr>
                                                                <td align="left">
                                                                    <asp:Label ID="Label71" runat="server" Text="Valuable Personal Property:" CssClass="label" />
                                                                    &nbsp
                                                                </td>
                                                                <td align="left">
                                                                    <asp:DropDownList ID="dd_PackagePerProp_wmj" runat="server" TabIndex="19" ClientIDMode="Static">
                                                                        <asp:ListItem></asp:ListItem>
                                                                        <asp:ListItem>Yes</asp:ListItem>
                                                                        <asp:ListItem>No</asp:ListItem>
                                                                    </asp:DropDownList>
                                                                    &nbsp;
                                                                    <asp:Label ID="Label72" runat="server" Text="Value:" CssClass="label" />
                                                                    &nbsp;
                                                                    &nbsp;
                                                                    <asp:label ID="wmjppvalue" runat="server" Text="0.00" Enabled="false" CssClass="label"  />
                                                                    &nbsp;
                                                                    &nbsp;
                                                                     &nbsp;
                                                                    &nbsp;
                                                                    <asp:Label ID="Label74" runat="server" Text="Premium" CssClass="label" />
                                                                    &nbsp;
                                                                    &nbsp;
                                                                    <asp:Label ID="wmjppprem" runat="server" Text="0.00" CssClass="label" />
                                                                    &nbsp;
                                                                </td>
                                                            </tr>
                                                                                                                        
                                                            <tr id="wmjPPl" style="display:">
                                                                <td align="left" colspan="2">
                                                                    <asp:Label ID="Label77" runat="server" Text="Valuable Personal Property list:" CssClass="label" />
                                                                    &nbsp
                                                                </td>
                                                                <td>
                                                                  
                                                             
                                                                    <asp:Button ID="btnshowPPLwmj" runat="server" Text="Personal Property Break Down" />
                                                                  
                                                             
                                                              
                                                                    <dx:ASPxPopupControl ID="ASPxPopupControl11" runat="server"  PopupElementID="btnshowPPLwmj" AllowDragging="True" HeaderText = "Scheduled Personal Property Details"
                                                                          MaxWidth="800px" MaxHeight="1800px" MinHeight="150px" MinWidth="150px" ShowFooter="True" Width="250px" Height="130px" >
                                                                   
                                                                        <ContentCollection>
                                                                            <dx:PopupControlContentControl ID="PopupControlContentControl11" runat="server" SupportsDisabledAttribute="True">
                                                                              <table>
                                                                                    <tr>
                                                                                    <td>
                                                                                    
                                                                                    
                                                                                  
                                                                                        <dx:ASPxPanel ID="ASPxPanelwmj" runat="server" >
                                                                                            <PanelCollection>
                                                                                                <dx:PanelContent ID="wmjppentry" runat="server" SupportsDisabledAttribute="True">
                                                                                                <table>
                                                                                                <tr>
                                                                                                <td>
                                                                                                    <asp:Label ID="Label78" runat="server" Text="Choose Category:"></asp:Label>
                                                                                                </td>
                                                                                                <td>
                                                                                                    <dx:ASPxComboBox ID="wmjppcatcmbo" runat="server" ValueType="System.String">
                                                                                                    <Items>
                                                                                                    <dx:ListEditItem Text="Jewelry" Value= "Jewelry" />
                                                                                                    <dx:ListEditItem Text="Furs" Value= "Furs" />
                                                                                                    <dx:ListEditItem Text="Photography Equipment" Value= "Photography Equipment" />
                                                                                                    <dx:ListEditItem Text="Musical Instruments" Value= "Musical Instruments" />
                                                                                                    <dx:ListEditItem Text="Silverware" Value= "Silverware" />
                                                                                                    <dx:ListEditItem Text="Golfer's Equipment" Value= "Golf Equipment" />
                                                                                                    <dx:ListEditItem Text="Stamp Collections" Value= "Stamp Collections" />
                                                                                                    <dx:ListEditItem Text="Coin Collections" Value= "Coin Collections" />
                                                                                                    <dx:ListEditItem Text="Satellite Dishes" Value= "Satellite Dishes" />
                                                                                                    <dx:ListEditItem Text="Guns" Value= "Guns" />
                                                                                                    <dx:ListEditItem Text="Fine Art excl breakage" Value= "Fine Art excl breakage" />
                                                                                                     <dx:ListEditItem Text="Fine Art incl breakage" Value= "Fine Art incl breakage" />

                                                                                                    </Items>
                                                                                                    </dx:ASPxComboBox>
                                                                                                </td>
                                                                                                </tr>
                                                                                                <tr>
                                                                                                <td>
                                                                                                <asp:Label ID="Label79" runat="server" Text="Description:"></asp:Label>
                                                                                                </td>
                                                                                                <td>
                                                                                                    <dx:ASPxTextBox ID="txtPPLDescriptionwmj" runat="server" Width="170px">
                                                                                                    </dx:ASPxTextBox>
                                                                                                </td>
                                                                                                </tr>
                                                                                                 <tr>
                                                                                                <td>
                                                                                                <asp:Label ID="Label80" runat="server" Text="Quantity:"></asp:Label>
                                                                                                </td>
                                                                                                <td>
                                                                                                    <dx:ASPxTextBox ID="txtQuantityPPlwmj" runat="server" Width="170px">
                                                                                                    </dx:ASPxTextBox>
                                                                                                </td>
                                                                                                </tr>
                                                                                                 <tr>
                                                                                                <td>
                                                                                                <asp:Label ID="Label88" runat="server" Text="Value:"></asp:Label>
                                                                                                </td>
                                                                                                <td>
                                                                                                    <dx:ASPxTextBox ID="txtvaluePPLwmj" runat="server" Width="170px">
                                                                                                    </dx:ASPxTextBox>
                                                                                                </td>
                                                                                                </tr>
                                                                                                <tr>
                                                                                                <td colspan="2">
                                                                                                    <asp:Label ID="Label95" runat="server" Text="Error:"></asp:Label>
                                                                                                </td>
                                                                                                <td align="right">
                                                                                                    <asp:Button ID="btnAddPPLwmj" runat="server" Text="Add" />
                                                                                                </td></tr>
                                                                                                </table>
                                                                                                </dx:PanelContent>
                                                                                            </PanelCollection>
                                                                                        </dx:ASPxPanel>

                                                                                          </td>
                                                                                          <td>
                                                                                           
                                                                                              <dx:ASPxGridView ID="wmjPPGrid" runat="server" AutoGenerateColumns="False" KeyFieldName="WMJppID" >
                                                                                                   <SettingsPager Visible="False">
                                                                                                    </SettingsPager>
                                                                                                    <SettingsEditing Mode="Inline" />
                                                                                                    <SettingsBehavior AllowFocusedRow="True" />
                                                                                                  <SettingsEditing Mode="Inline" /><SettingsBehavior AllowFocusedRow="True" /><Columns>
                                                                                                   <dx:GridViewCommandColumn VisibleIndex="0">
                                                                               
                                                                                                       <DeleteButton Visible="True">
                                                                                                        </DeleteButton>
                                                                                                    </dx:GridViewCommandColumn>
                                                                                                      <dx:GridViewDataTextColumn FieldName="WMJppID" Name="id" 
                                                                                                          ShowInCustomizationForm="True" Visible="False" VisibleIndex="6">
                                                                                                      </dx:GridViewDataTextColumn>
                                                                                                      <dx:GridViewDataTextColumn FieldName="QuoteID" Name="ppquoteid" 
                                                                                                          ShowInCustomizationForm="True" Visible="False" VisibleIndex="5">
                                                                                                      </dx:GridViewDataTextColumn>
                                                                                                      <dx:GridViewDataTextColumn Caption="Category" FieldName="CategoryPP" 
                                                                                                          Name="Catname" ShowInCustomizationForm="True" VisibleIndex="0">
                                                                                                      </dx:GridViewDataTextColumn>
                                                                                                      <dx:GridViewDataTextColumn Caption="Description" FieldName="DescriptionPP" 
                                                                                                          Name="ppdescription" ShowInCustomizationForm="True" VisibleIndex="1">
                                                                                                      </dx:GridViewDataTextColumn>
                                                                                                      <dx:GridViewDataTextColumn Caption="QTY" FieldName="QtyPP" Name="ppqty" 
                                                                                                          ShowInCustomizationForm="True" VisibleIndex="2">
                                                                                                      </dx:GridViewDataTextColumn>
                                                                                                      <dx:GridViewDataTextColumn Caption="Value" FieldName="ValuePP" Name="ppvalue" 
                                                                                                          ShowInCustomizationForm="True" VisibleIndex="3">
                                                                                                      </dx:GridViewDataTextColumn>
                                                                                                      <dx:GridViewDataTextColumn Caption="Total" FieldName="TotalPP" Name="pptotal" 
                                                                                                          ShowInCustomizationForm="True" VisibleIndex="4">
                                                                                                      </dx:GridViewDataTextColumn>
                                                                                                  </Columns>
                                                                                              </dx:ASPxGridView>
                                                                                              
                                                                                          </td>
                                                                                    </tr>
                                                                                    </table>
                                                                            </dx:PopupControlContentControl>
                                                                        </ContentCollection>
                                                                   
                                                                    </dx:ASPxPopupControl>
                                                                </td>
                                                            </tr>
                                                           
                                                            <tr>
                                                                <td align="left">
                                                                    <asp:Button ID="wmj1_updateOptions" runat="server" Text="Update Optional Coverages"
                                                                        OnClick="wmj_premiumbtnClick2" TabIndex="22" />
                                                                </td>
                                                            </tr>
                                                        </tbody>
                                                    </table>
                                                </td>
                                            </tr>
                                          
                                          
          
                                            <%--wmj END--%>
                                           <%-- WMJ NC Start--%>
                                           <tr id="wmj_mh_prognc1" runat="server" style="border: 1px solid black;">
                                                <td align="center" style="border: 1px solid" width="251px">
                                                    <label id="lblwmj_ShowOptionsnc1" runat="server" style="color: Blue; cursor: pointer;"
                                                        onclick="AROptionsShow(10);" clientidmode="Static">
                                                        - Show Options</label>
                                                    <asp:HiddenField ID="lblwmj_ShowOptionsnc1_hidden" runat="server" Value="+ Show Options" />
                                                </td>
                                                <td align="center" style="border: 1px solid">
                                                    <asp:Label ID="Label58" runat="server" Text="WMJ Standard Replacement Cost" CssClass="labelCov" />
                                                </td>
                                                <td align="center" style="border: 1px solid">
                                                    <asp:Label ID="wmj_dwellnc1" runat="server" Text="0.00" CssClass="labelCov" />
                                                </td>
                                                <td align="center" style="border: 1px solid" class="style3">
                                                    <asp:Label ID="wmj_unattStrnc1" runat="server" Text="0.00" CssClass="labelCov" />
                                                </td>
                                                <td align="center" style="border: 1px solid">
                                                    <asp:Label ID="wmj_perEffnc1" runat="server" Text="0.00" CssClass="labelCov" />
                                                </td>
                                                <td align="center" style="border: 1px solid;">
                                                    <asp:Label ID="wmj_perLiabnc1" runat="server" Text="0.00" CssClass="labelCov" />
                                                </td>
                                                <td align="center" style="border: 1px solid">
                                                    <asp:Label ID="wmj_medpaync1" runat="server" Text="0.00" CssClass="labelCov" />
                                                </td>
                                                <td align="center" style="border: 1px solid">
                                                    <asp:Label ID="wmj_basepremnc1" runat="server" Text="0.00" CssClass="labelCov" />
                                                </td>
                                                <td align="center" style="border: 1px solid">
                                                    <asp:Label ID="wmj_optionsnc1" runat="server" Text="0.00" CssClass="labelCov" />
                                                </td>
                                                <td align="center" style="border: 1px solid">
                                                    <asp:Label ID="wmj_feesnc1" runat="server" Text="$0.00" CssClass="labelCov" />
                                                </td>
                                                <td align="center" style="border: 1px solid">
                                                    <asp:Label ID="wmj_taxnc1" runat="server" Text="0.00" CssClass="labelCov" />
                                                </td>
                                                <td align="center" style="border: 1px solid">
                                                    <asp:Label ID="wmj_totalnc1" runat="server" Text="0.00" CssClass="labelTotal" />
                                                </td>
                                                <td align="center" style="border: 1px solid">
                                                    <asp:Button ID="selectwmj_nc1btn" runat="server" OnClick="selectwmj1btnnc1_Click" Text="Select" />
                                                </td>
                                            </tr>
                                            <tr id="wmj_mh_prognc1_Options" runat="server" clientidmode="Static">
                                                <td colspan="13">
                                                    <table id="WMJ_nc1_table" runat="server" width="auto" cellpadding="0" cellspacing="0"
                                                        clientidmode="Static" bgcolor="white" title="AR Options">
                                                        <tbody>
                                                            <tr>
                                                                <td align="left">
                                                                    <input id="Button7" type="button" value="Open Calc Detail"  />
                                                                    <asp:Label ID="txt_dwell_wmjnc1_Amount" runat="server" Text="0.00" CssClass="label" Style="display:none" />
                                                                    &nbsp;
                                                                    <asp:Label ID="txt_DedChange_wmjnc1_Amount" runat="server" Text="0.00" CssClass="label" Style="display:none" />
                                                                    <asp:Label ID="txt_Credit_wmjnc1_Amount" runat="server" Text="0.00" CssClass="label" Style="display:none" />
                                                                    &nbsp;
                                                                    <dx:ASPxPopupControl ID="ASPxPopupControlnc1" runat="server" PopupElementID="Button7" HeaderText="Standard Calculations" PopupVerticalAlign="Below" PopupHorizontalAlign="LeftSides" AllowDragging="True"
                                                                          MaxWidth="800px" MaxHeight="1800px" MinHeight="150px" MinWidth="150px" ShowFooter="True" Width="250px" Height="130px" >
                                                                    <ContentCollection>
                                                                        <dx:PopupControlContentControl ID="PopupControlContentControlnc11" runat="server">
                                                                            <asp:Panel ID="Panel10" runat="server">
                                                                                <table border="0" cellpadding="4" cellspacing="0">
                                                                                    <tr>
                                                                                        <td valign="top">
                                                                                            
                                                                                            <asp:Label ID="wmjnc1_Debug" runat="server" ClientIDMode="Static" Text=""></asp:Label>
                                                                                        </td>
                                                                                    </tr>
                                                                                  
                                                                                </table>
                                                                            </asp:Panel>
                                                                        </dx:PopupControlContentControl>
                                                                    </ContentCollection>

                                                                    </dx:ASPxPopupControl>
                                                                </td>
                                                            </tr>
                                                            <tr>
                                                                <td align="left">
                                                                    <asp:Label ID="Label73" runat="server" Text="AOP Deductible" CssClass="label" />
                                                                </td>
                                                                <td align="left">
                                                                    <asp:DropDownList ID="dd_aop_wmjnc1" runat="server" TabIndex="112">
                                                                        <asp:ListItem>$500</asp:ListItem>
                                                                       <asp:ListItem>$1000</asp:ListItem>
                                                                    </asp:DropDownList>
                                                                     &nbsp;<asp:Label ID="dd_aop_wmjnc1_Amount" runat="server" Text="0.00" CssClass="label" />
                                                                    &nbsp;
                                                                </td>
                                                            </tr>
                                                            <%--<tr id="wmjWind" runat="server">
                                                                <td align="left">
                                                                    <asp:Label ID="Label58" runat="server" Text="Named Storm Deductible" CssClass="label" />
                                                                </td>
                                                                <td align="left">
                                                                    <asp:TextBox ID="dd_hurded_wmjnc1" runat="server" Text="0.00" 
                                                                        AutoCompleteType="DisplayName" Enabled="false" TabIndex="113" />
                                                                </td>
                                                            </tr>--%>
                                                            <tr id="tr2">
                                                                <td align="left">
                                                                    <asp:Label ID="Label76" runat="server" Text="Loss of Use" CssClass="label" />
                                                                </td>
                                                                <td align="left">
                                                                    <asp:TextBox ID="wmjlossofusenc1" runat="server" Text="0.00" 
                                                                        AutoCompleteType="DisplayName" Enabled="false" TabIndex="303" />
                                                                </td>
                                                            </tr>
                                                            <tr>
                                                                <td>
                                                                    &nbsp;
                                                                </td>
                                                            </tr>
                                                            <tr>
                                                                <td align="left">
                                                                    <asp:Label ID="Label101" runat="server" Text="Personal Liability:  " CssClass="label" />
                                                                    &nbsp
                                                                </td>
                                                                <td align="left">
                                                                    <asp:DropDownList ID="dd_pl_wmjnc1" runat="server" AutoPostBack="true" 
                                                                        TabIndex="115" >
                                                                        <%--<asp:ListItem>$0</asp:ListItem>--%>
                                                                    
                                                                        <asp:ListItem>$50,000</asp:ListItem>
                                                                        <asp:ListItem>$100,000</asp:ListItem>
                                                                       <asp:ListItem>$300,000</asp:ListItem>
                                                                    </asp:DropDownList>
                                                                    &nbsp;<asp:Label ID="dd_pl_wmjnc1_Amount" runat="server" Text="0.00" CssClass="label" />
                                                                    &nbsp;
                                                                </td>
                                                            </tr>
                                                            <tr id="Tr3" style="display: " clientidmode="Static">
                                                                <td align="left">
                                                                    <asp:Label ID="Label103" runat="server" Text="Medical payment:  " CssClass="label" />
                                                                    &nbsp
                                                                </td>
                                                                <td align="left">
                                                                    <asp:DropDownList ID="dd_mp_wmjnc1" runat="server"  clientidmode="Static" 
                                                                        TabIndex="116">
                                                                      <%--  <asp:ListItem>$0</asp:ListItem>
                                                                        <asp:ListItem>$500</asp:ListItem>--%>
                                                                       <asp:ListItem>$1000</asp:ListItem>
                                                                    </asp:DropDownList>
                                                                     &nbsp;
                                                                    <asp:Label ID="dd_med_wmjnc1_amt" runat="server" Text="0.00" CssClass="label" />
                                                                    &nbsp;
                                                                </td>
                                                            </tr>
                                                             <tr style="border: 1px solid black">
                                                                <td align="left">
                                                                    <asp:Label ID="Label106" runat="server" Text="Additional Residence:" CssClass="label" />
                                                                    &nbsp
                                                                </td>
                                                                <td align="left">
                                                                    <asp:DropDownList ID="dd_addresOpt_wmjnc1" runat="server" ClientIDMode="Static">
                                                                        <asp:ListItem></asp:ListItem>
                                                                      <%--  <asp:ListItem>Premises Occupied by Insured</asp:ListItem>--%>
                                                                        <asp:ListItem>1 Family</asp:ListItem>
                                                                        <asp:ListItem>2 Family</asp:ListItem>
                                                                    </asp:DropDownList>
                                                                    &nbsp;
                                                                    <asp:Label ID="dd_addresOpt_wmjnc1_Amount" runat="server" Text="0.00" CssClass="label" />
                                                                    &nbsp;
                                                                </td>
                                                            </tr>
                                                            <tr id="wmj_AddResOpt1_nc1" clientidmode="Static">
                                                                <td align="left">
                                                                   <%-- <asp:HiddenField ID="AR_AddResOpt1_HIDDEN" runat="server" />--%>
                                                                    <asp:Label ID="Label109" runat="server" Text="Additional Residence Liability" CssClass="label" />
                                                                    &nbsp
                                                                </td>
                                                                <td align="left">
                                                                    <asp:DropDownList ID="dd_addresliab_wmjnc1" runat="server" ClientIDMode="Static">
                                                                        <asp:ListItem>$0</asp:ListItem>
                                                                        <asp:ListItem>$50,000</asp:ListItem>
                                                                        <asp:ListItem>$100,000</asp:ListItem>
                                                                        <asp:ListItem>$300,000</asp:ListItem>
                                                                    </asp:DropDownList>
                                                                      &nbsp;
                                                                    <asp:Label ID="addres_liab_wmjnc1_amount" runat="server" Text="0.00" CssClass="label" />
                                                                    &nbsp;
                                                                </td>
                                                            </tr>
                                                            <tr>
                                                                <td>
                                                                    &nbsp;
                                                                </td>
                                                            </tr>
                                                            <tr>
                                                                <td align="left">
                                                                    <asp:Label ID="Label110" runat="server" Text="Other Structures:  " CssClass="label" />
                                                                    &nbsp
                                                                </td>
                                                                <td align="left">
                                                                    <asp:TextBox ID="txt_unattstr_wmjnc1" runat="server" Text="0.00" AutoCompleteType="DisplayName"
                                                                        Casing="UPPER" ToolTip="Unattached Structure" Width="65" TabIndex="117"/>
                                                                    &nbsp;<asp:Label ID="txt_unattstr_wmjnc1_Amount" runat="server" Text="0.00" CssClass="label" />
                                                                    &nbsp;
                                                                </td>
                                                            </tr>
                                                            <tr>
                                                                <td align="left">
                                                                    <asp:Label ID="Label111" runat="server" Text="Contents:  " CssClass="label" />
                                                                    &nbsp
                                                                </td>
                                                                <td align="left">
                                                                    <asp:TextBox ID="txt_pp_wmjnc1" runat="server" Text="0.00" AutoCompleteType="DisplayName"
                                                                        Casing="UPPER" ToolTip="Personal Property" Width="65" TabIndex="118" />
                                                                    &nbsp;<asp:Label ID="txt_pp_wmjnc1_Amount" runat="server" Text="0.00" CssClass="label" />
                                                                    &nbsp;
                                                                </td>
                                                            </tr>
                                                            
                                                           <tr>
                                                                <td align="left">
                                                                    <asp:Label ID="Label112" runat="server" Text="Contents Replacement Cost:  " CssClass="label" />
                                                                    &nbsp
                                                                </td>
                                                                <td align="left">
                                                                    <asp:DropDownList ID="dd_rep_wmjnc1" runat="server" TabIndex="120" 
                                                                        ClientIDMode="Static">
                                                                        <asp:ListItem>No</asp:ListItem>
                                                                        <asp:ListItem>Yes</asp:ListItem>
                                                                    </asp:DropDownList>
                                                                    &nbsp;
                                                                    <asp:Label ID="dd_rep_wmjnc1_Amount" runat="server" Text="0.00" CssClass="label" />
                                                                    &nbsp;
                                                                </td>
                                                            </tr>
                                                           <%-- <tr>
                                                                <td id="trmhwmjOpt2_nc1" align="left" clientidmode="Static">
                                                                    <asp:Label ID="Label113" runat="server" Text="Full Repair:  " CssClass="label" />
                                                                    &nbsp
                                                                </td>
                                                                <td id="trmhwmjOpt2_nc1_d" align="left" clientidmode="Static">
                                                                    <asp:DropDownList ID="dd_sip_wmjnc1" runat="server" TabIndex="121">
                                                                        <asp:ListItem>No</asp:ListItem>
                                                                        <asp:ListItem>Yes</asp:ListItem>
                                                                    </asp:DropDownList>
                                                                    &nbsp;<asp:Label ID="dd_sip_wmjnc1_Amount" runat="server" Text="0.00" CssClass="label" />
                                                                    &nbsp;
                                                                </td>
                                                            </tr>--%>
                                                            <tr>
                                                                <td align="left">
                                                                    <asp:Label ID="Label114" runat="server" Text="Lienholder's Single Interest:   " CssClass="label" />
                                                                    &nbsp
                                                                </td>
                                                                <td align="left">
                                                                    <asp:DropDownList ID="spi_cbo_nc1" runat="server" TabIndex="120" 
                                                                        ClientIDMode="Static">
                                                                        <asp:ListItem>No</asp:ListItem>
                                                                        <asp:ListItem>Yes</asp:ListItem>
                                                                    </asp:DropDownList>
                                                                    &nbsp;
                                                                    <asp:Label ID="spi_nc1_amount" runat="server" Text="0.00" CssClass="label" />
                                                                    &nbsp;
                                                                </td>
                                                            </tr>
                                                            <tr>
                                                                <td align="left">
                                                                    <asp:Label ID="Label118" runat="server" Text="Valuable Personal Property:" CssClass="label" />
                                                                    &nbsp
                                                                </td>
                                                                <td align="left">
                                                                    <asp:DropDownList ID="dd_PackagePerProp_wmjnc1" runat="server" TabIndex="19" ClientIDMode="Static">
                                                                        <asp:ListItem></asp:ListItem>
                                                                        <asp:ListItem>Yes</asp:ListItem>
                                                                        <asp:ListItem>No</asp:ListItem>
                                                                    </asp:DropDownList>
                                                                    &nbsp;
                                                                    <asp:Label ID="Label119" runat="server" Text="Value:" CssClass="label" />
                                                                    &nbsp;
                                                                    &nbsp;
                                                                    <asp:label ID="wmjppvalue_nc1" runat="server" Text="0.00" Enabled="false" CssClass="label"  />
                                                                    &nbsp;
                                                                    &nbsp;
                                                                     &nbsp;
                                                                    &nbsp;
                                                                    <asp:Label ID="Label120" runat="server" Text="Premium" CssClass="label" />
                                                                    &nbsp;
                                                                    &nbsp;
                                                                    <asp:Label ID="wmjppprem_nc1" runat="server" Text="0.00" CssClass="label" />
                                                                    &nbsp;
                                                                </td>
                                                            </tr>
                                                                                                                        
                                                            <tr id="Tr4" style="display:">
                                                                <td align="left" colspan="2">
                                                                    <asp:Label ID="Label121" runat="server" Text="Valuable Personal Property list:" CssClass="label" />
                                                                    &nbsp
                                                                </td>
                                                                <td>
                                                                  
                                                             
                                                                    <asp:Button ID="btnshowPPLwmj_nc1" runat="server" Text="Personal Property Break Down" />
                                                                  
                                                             
                                                              
                                                                    <dx:ASPxPopupControl ID="ASPxPopupControl12" runat="server"  PopupElementID="btnshowPPLwmj_nc1" AllowDragging="True" HeaderText = "Scheduled Personal Property Details"
                                                                          MaxWidth="800px" MaxHeight="1800px" MinHeight="150px" MinWidth="150px" ShowFooter="True" Width="250px" Height="130px" >
                                                                   
                                                                        <ContentCollection>
                                                                            <dx:PopupControlContentControl ID="PopupControlContentControl12" runat="server" SupportsDisabledAttribute="True">
                                                                              <table>
                                                                                    <tr>
                                                                                    <td>
                                                                                    
                                                                                    
                                                                                  
                                                                                        <dx:ASPxPanel ID="ASPxPanel2" runat="server" >
                                                                                            <PanelCollection>
                                                                                                <dx:PanelContent ID="wmjppentry_nc1" runat="server" SupportsDisabledAttribute="True">
                                                                                                <table>
                                                                                                <tr>
                                                                                                <td>
                                                                                                    <asp:Label ID="Label122" runat="server" Text="Choose Category:"></asp:Label>
                                                                                                </td>
                                                                                                <td>
                                                                                                    <dx:ASPxComboBox ID="wmjppcatcmbo_nc1" runat="server" ValueType="System.String">
                                                                                                    <Items>
                                                                                                    <dx:ListEditItem Text="Jewelry" Value= "Jewelry" />
                                                                                                    <dx:ListEditItem Text="Furs" Value= "Furs" />
                                                                                                    <dx:ListEditItem Text="Photography Equipment" Value= "Photography Equipment" />
                                                                                                    <dx:ListEditItem Text="Musical Instruments" Value= "Musical Instruments" />
                                                                                                    <dx:ListEditItem Text="Silverware" Value= "Silverware" />
                                                                                                    <dx:ListEditItem Text="Golfer's Equipment" Value= "Golf Equipment" />
                                                                                                    <dx:ListEditItem Text="Stamp Collections" Value= "Stamp Collections" />
                                                                                                    <dx:ListEditItem Text="Coin Collections" Value= "Coin Collections" />
                                                                                                    <dx:ListEditItem Text="Satellite Dishes" Value= "Satellite Dishes" />
                                                                                                    <dx:ListEditItem Text="Guns" Value= "Guns" />
                                                                                                    <dx:ListEditItem Text="Fine Art excl breakage" Value= "Fine Art excl breakage" />
                                                                                                     <dx:ListEditItem Text="Fine Art incl breakage" Value= "Fine Art incl breakage" />

                                                                                                    </Items>
                                                                                                    </dx:ASPxComboBox>
                                                                                                </td>
                                                                                                </tr>
                                                                                                <tr>
                                                                                                <td>
                                                                                                <asp:Label ID="Label123" runat="server" Text="Description:"></asp:Label>
                                                                                                </td>
                                                                                                <td>
                                                                                                    <dx:ASPxTextBox ID="txtPPLDescriptionwmj_nc1" runat="server" Width="170px">
                                                                                                    </dx:ASPxTextBox>
                                                                                                </td>
                                                                                                </tr>
                                                                                                 <tr>
                                                                                                <td>
                                                                                                <asp:Label ID="Label124" runat="server" Text="Quantity:"></asp:Label>
                                                                                                </td>
                                                                                                <td>
                                                                                                    <dx:ASPxTextBox ID="txtQuantityPPlwmj_nc1" runat="server" Width="170px">
                                                                                                    </dx:ASPxTextBox>
                                                                                                </td>
                                                                                                </tr>
                                                                                                 <tr>
                                                                                                <td>
                                                                                                <asp:Label ID="Label125" runat="server" Text="Value:"></asp:Label>
                                                                                                </td>
                                                                                                <td>
                                                                                                    <dx:ASPxTextBox ID="txtvaluePPLwmj_nc1" runat="server" Width="170px">
                                                                                                    </dx:ASPxTextBox>
                                                                                                </td>
                                                                                                </tr>
                                                                                                <tr>
                                                                                                <td colspan="2">
                                                                                                    <asp:Label ID="Label126" runat="server" Text="Error:"></asp:Label>
                                                                                                </td>
                                                                                                <td align="right">
                                                                                                    <asp:Button ID="btnAddPPLwmj_nc1" runat="server" Text="Add" />
                                                                                                </td></tr>
                                                                                                </table>
                                                                                                </dx:PanelContent>
                                                                                            </PanelCollection>
                                                                                        </dx:ASPxPanel>

                                                                                          </td>
                                                                                          <td>
                                                                                           
                                                                                              <dx:ASPxGridView ID="wmjPPGrid_nc1" runat="server" AutoGenerateColumns="False" KeyFieldName="WMJppID" >
                                                                                                   <SettingsPager Visible="False">
                                                                                                    </SettingsPager>
                                                                                                    <SettingsEditing Mode="Inline" />
                                                                                                    <SettingsBehavior AllowFocusedRow="True" />
                                                                                                  <SettingsEditing Mode="Inline" /><SettingsBehavior AllowFocusedRow="True" /><Columns>
                                                                                                   <dx:GridViewCommandColumn VisibleIndex="0">
                                                                               
                                                                                                       <DeleteButton Visible="True">
                                                                                                        </DeleteButton>
                                                                                                    </dx:GridViewCommandColumn>
                                                                                                      <dx:GridViewDataTextColumn FieldName="WMJppID" Name="id" 
                                                                                                          ShowInCustomizationForm="True" Visible="False" VisibleIndex="6">
                                                                                                      </dx:GridViewDataTextColumn>
                                                                                                      <dx:GridViewDataTextColumn FieldName="QuoteID" Name="ppquoteid" 
                                                                                                          ShowInCustomizationForm="True" Visible="False" VisibleIndex="5">
                                                                                                      </dx:GridViewDataTextColumn>
                                                                                                      <dx:GridViewDataTextColumn Caption="Category" FieldName="CategoryPP" 
                                                                                                          Name="Catname" ShowInCustomizationForm="True" VisibleIndex="0">
                                                                                                      </dx:GridViewDataTextColumn>
                                                                                                      <dx:GridViewDataTextColumn Caption="Description" FieldName="DescriptionPP" 
                                                                                                          Name="ppdescription" ShowInCustomizationForm="True" VisibleIndex="1">
                                                                                                      </dx:GridViewDataTextColumn>
                                                                                                      <dx:GridViewDataTextColumn Caption="QTY" FieldName="QtyPP" Name="ppqty" 
                                                                                                          ShowInCustomizationForm="True" VisibleIndex="2">
                                                                                                      </dx:GridViewDataTextColumn>
                                                                                                      <dx:GridViewDataTextColumn Caption="Value" FieldName="ValuePP" Name="ppvalue" 
                                                                                                          ShowInCustomizationForm="True" VisibleIndex="3">
                                                                                                      </dx:GridViewDataTextColumn>
                                                                                                      <dx:GridViewDataTextColumn Caption="Total" FieldName="TotalPP" Name="pptotal" 
                                                                                                          ShowInCustomizationForm="True" VisibleIndex="4">
                                                                                                      </dx:GridViewDataTextColumn>
                                                                                                  </Columns>
                                                                                              </dx:ASPxGridView>
                                                                                              
                                                                                          </td>
                                                                                    </tr>
                                                                                    </table>
                                                                            </dx:PopupControlContentControl>
                                                                        </ContentCollection>
                                                                   
                                                                    </dx:ASPxPopupControl>
                                                                </td>
                                                            </tr>
                                                           
                                                            <tr>
                                                                <td align="left">
                                                                    <asp:Button ID="wmj1_updateOptions_nc1" runat="server" Text="Update Optional Coverages"
                                                                        OnClick="wmj_premiumbtnClick_nc1" TabIndex="22" />
                                                                </td>
                                                            </tr>
                                                        </tbody>
                                                    </table>
                                                </td>
                                            </tr>
                                          <tr id="wmj_mh_prognc2" runat="server" style="border: 1px solid black;">
                                                <td align="center" style="border: 1px solid" width="251px">
                                                    <label id="lblwmj_ShowOptionsnc2" runat="server" style="color: Blue; cursor: pointer;"
                                                        onclick="AROptionsShow(11);" clientidmode="Static">
                                                        - Show Options</label>
                                                    <asp:HiddenField ID="lblwmj_ShowOptionsnc2_hidden" runat="server" Value="+ Show Options" />
                                                </td>
                                                <td align="center" style="border: 1px solid">
                                                    <asp:Label ID="Label127" runat="server" Text="WMJ Standard ACV" CssClass="labelCov" />
                                                </td>
                                                <td align="center" style="border: 1px solid">
                                                    <asp:Label ID="wmj_dwellnc2" runat="server" Text="0.00" CssClass="labelCov" />
                                                </td>
                                                <td align="center" style="border: 1px solid" class="style3">
                                                    <asp:Label ID="wmj_unattStrnc2" runat="server" Text="0.00" CssClass="labelCov" />
                                                </td>
                                                <td align="center" style="border: 1px solid">
                                                    <asp:Label ID="wmj_perEffnc2" runat="server" Text="0.00" CssClass="labelCov" />
                                                </td>
                                                <td align="center" style="border: 1px solid;">
                                                    <asp:Label ID="wmj_perLiabnc2" runat="server" Text="0.00" CssClass="labelCov" />
                                                </td>
                                                <td align="center" style="border: 1px solid">
                                                    <asp:Label ID="wmj_medpaync2" runat="server" Text="0.00" CssClass="labelCov" />
                                                </td>
                                                <td align="center" style="border: 1px solid">
                                                    <asp:Label ID="wmj_basepremnc2" runat="server" Text="0.00" CssClass="labelCov" />
                                                </td>
                                                <td align="center" style="border: 1px solid">
                                                    <asp:Label ID="wmj_optionsnc2" runat="server" Text="0.00" CssClass="labelCov" />
                                                </td>
                                                <td align="center" style="border: 1px solid">
                                                    <asp:Label ID="wmj_feesnc2" runat="server" Text="$0.00" CssClass="labelCov" />
                                                </td>
                                                <td align="center" style="border: 1px solid">
                                                    <asp:Label ID="wmj_taxnc2" runat="server" Text="0.00" CssClass="labelCov" />
                                                </td>
                                                <td align="center" style="border: 1px solid">
                                                    <asp:Label ID="wmj_totalnc2" runat="server" Text="0.00" CssClass="labelTotal" />
                                                </td>
                                                <td align="center" style="border: 1px solid">
                                                    <asp:Button ID="selectwmj_nc2btn" runat="server" OnClick="selectwmj1btnnc2_Click" Text="Select" />
                                                </td>
                                            </tr>
                                            <tr id="wmj_mh_prognc2_Options" runat="server" clientidmode="Static">
                                                <td colspan="13">
                                                    <table id="WMJ_nc2_table" runat="server" width="auto" cellpadding="0" cellspacing="0"
                                                        clientidmode="Static" bgcolor="white" title="AR Options">
                                                        <tbody>
                                                            <tr>
                                                                <td align="left">
                                                                    <input id="Button8" type="button" value="Open Calc Detail"  />
                                                                    <asp:Label ID="txt_dwell_wmjnc2_Amount" runat="server" Text="0.00" CssClass="label" Style="display:none" />
                                                                    &nbsp;
                                                                    <asp:Label ID="txt_DedChange_wmjnc2_Amount" runat="server" Text="0.00" CssClass="label" Style="display:none" />
                                                                    <asp:Label ID="txt_Credit_wmjnc2_Amount" runat="server" Text="0.00" CssClass="label" Style="display:none" />
                                                                    &nbsp;
                                                                    <dx:ASPxPopupControl ID="ASPxPopupControl13" runat="server" PopupElementID="Button8" HeaderText="Standard Calculations" PopupVerticalAlign="Below" PopupHorizontalAlign="LeftSides" AllowDragging="True"
                                                                          MaxWidth="800px" MaxHeight="1800px" MinHeight="150px" MinWidth="150px" ShowFooter="True" Width="250px" Height="130px" >
                                                                    <ContentCollection>
                                                                        <dx:PopupControlContentControl ID="PopupControlContentControl13" runat="server">
                                                                            <asp:Panel ID="Panel11" runat="server">
                                                                                <table border="0" cellpadding="4" cellspacing="0">
                                                                                    <tr>
                                                                                        <td valign="top">
                                                                                            
                                                                                            <asp:Label ID="wmjnc2_Debug" runat="server" ClientIDMode="Static" Text=""></asp:Label>
                                                                                        </td>
                                                                                    </tr>
                                                                                  
                                                                                </table>
                                                                            </asp:Panel>
                                                                        </dx:PopupControlContentControl>
                                                                    </ContentCollection>

                                                                    </dx:ASPxPopupControl>
                                                                </td>
                                                            </tr>
                                                            <tr>
                                                                <td align="left">
                                                                    <asp:Label ID="Label128" runat="server" Text="AOP Deductible" CssClass="label" />
                                                                </td>
                                                                <td align="left">
                                                                    <asp:DropDownList ID="dd_aop_wmjnc2" runat="server" TabIndex="112">
                                                                        <asp:ListItem>$500</asp:ListItem>
                                                                       <asp:ListItem>$1000</asp:ListItem>
                                                                    </asp:DropDownList>
                                                                     &nbsp;<asp:Label ID="dd_aop_wmjnc2_Amount" runat="server" Text="0.00" CssClass="label" />
                                                                    &nbsp;
                                                                </td>
                                                            </tr>
                                                            <%--<tr id="wmjWind" runat="server">
                                                                <td align="left">
                                                                    <asp:Label ID="Label58" runat="server" Text="Named Storm Deductible" CssClass="label" />
                                                                </td>
                                                                <td align="left">
                                                                    <asp:TextBox ID="dd_hurded_wmjnc2" runat="server" Text="0.00" 
                                                                        AutoCompleteType="DisplayName" Enabled="false" TabIndex="113" />
                                                                </td>
                                                            </tr>--%>
                                                            <tr id="tr5">
                                                                <td align="left">
                                                                    <asp:Label ID="Label129" runat="server" Text="Loss of Use" CssClass="label" />
                                                                </td>
                                                                <td align="left">
                                                                    <asp:TextBox ID="wmjlossofusenc2" runat="server" Text="0.00" 
                                                                        AutoCompleteType="DisplayName" Enabled="false" TabIndex="303" />
                                                                </td>
                                                            </tr>
                                                            <tr>
                                                                <td>
                                                                    &nbsp;
                                                                </td>
                                                            </tr>
                                                            <tr>
                                                                <td align="left">
                                                                    <asp:Label ID="Label130" runat="server" Text="Personal Liability:  " CssClass="label" />
                                                                    &nbsp
                                                                </td>
                                                                <td align="left">
                                                                    <asp:DropDownList ID="dd_pl_wmjnc2" runat="server" AutoPostBack="true" 
                                                                        TabIndex="115" >
                                                                        <%--<asp:ListItem>$0</asp:ListItem>--%>
                                                                    
                                                                        <asp:ListItem>$50,000</asp:ListItem>
                                                                        <asp:ListItem>$100,000</asp:ListItem>
                                                                       <asp:ListItem>$300,000</asp:ListItem>
                                                                    </asp:DropDownList>
                                                                    &nbsp;<asp:Label ID="dd_pl_wmjnc2_Amount" runat="server" Text="0.00" CssClass="label" />
                                                                    &nbsp;
                                                                </td>
                                                            </tr>
                                                            <tr id="Tr6" style="display: " clientidmode="Static">
                                                                <td align="left">
                                                                    <asp:Label ID="Label131" runat="server" Text="Medical payment:  " CssClass="label" />
                                                                    &nbsp
                                                                </td>
                                                                <td align="left">
                                                                    <asp:DropDownList ID="dd_mp_wmjnc2" runat="server"  clientidmode="Static" 
                                                                        TabIndex="116">
                                                                      <%--  <asp:ListItem>$0</asp:ListItem>
                                                                        <asp:ListItem>$500</asp:ListItem>--%>
                                                                       <asp:ListItem>$1000</asp:ListItem>
                                                                    </asp:DropDownList>
                                                                     &nbsp;
                                                                    <asp:Label ID="dd_med_wmjnc2_amt" runat="server" Text="0.00" CssClass="label" />
                                                                    &nbsp;
                                                                </td>
                                                            </tr>
                                                             <tr style="border: 1px solid black">
                                                                <td align="left">
                                                                    <asp:Label ID="Label132" runat="server" Text="Additional Residence:" CssClass="label" />
                                                                    &nbsp
                                                                </td>
                                                                <td align="left">
                                                                    <asp:DropDownList ID="dd_addresOpt_wmjnc2" runat="server" ClientIDMode="Static">
                                                                        <asp:ListItem></asp:ListItem>
                                                                        <%--<asp:ListItem>Premises Occupied by Insured</asp:ListItem>--%>
                                                                        <asp:ListItem>1 Family</asp:ListItem>
                                                                        <asp:ListItem>2 Family</asp:ListItem>
                                                                    </asp:DropDownList>
                                                                    &nbsp;
                                                                    <asp:Label ID="dd_addresOpt_wmjnc2_Amount" runat="server" Text="0.00" CssClass="label" />
                                                                    &nbsp;
                                                                </td>
                                                            </tr>
                                                            <tr id="wmj_AddResOpt1_nc2" clientidmode="Static">
                                                                <td align="left">
                                                                   <%-- <asp:HiddenField ID="AR_AddResOpt1_HIDDEN" runat="server" />--%>
                                                                    <asp:Label ID="Label133" runat="server" Text="Additional Residence Liability" CssClass="label" />
                                                                    &nbsp
                                                                </td>
                                                                <td align="left">
                                                                    <asp:DropDownList ID="dd_addresliab_wmjnc2" runat="server" ClientIDMode="Static">
                                                                        <asp:ListItem>$0</asp:ListItem>
                                                                        <asp:ListItem>$50,000</asp:ListItem>
                                                                        <asp:ListItem>$100,000</asp:ListItem>
                                                                        <asp:ListItem>$300,000</asp:ListItem>
                                                                    </asp:DropDownList>
                                                                      &nbsp;
                                                                    <asp:Label ID="addres_liab_wmjnc2_amount" runat="server" Text="0.00" CssClass="label" />
                                                                    &nbsp;
                                                                </td>
                                                            </tr>
                                                            <tr>
                                                                <td>
                                                                    &nbsp;
                                                                </td>
                                                            </tr>
                                                            <tr>
                                                                <td align="left">
                                                                    <asp:Label ID="Label134" runat="server" Text="Other Structures:  " CssClass="label" />
                                                                    &nbsp
                                                                </td>
                                                                <td align="left">
                                                                    <asp:TextBox ID="txt_unattstr_wmjnc2" runat="server" Text="0.00" AutoCompleteType="DisplayName"
                                                                        Casing="UPPER" ToolTip="Unattached Structure" Width="65" TabIndex="117"/>
                                                                    &nbsp;<asp:Label ID="txt_unattstr_wmjnc2_Amount" runat="server" Text="0.00" CssClass="label" />
                                                                    &nbsp;
                                                                </td>
                                                            </tr>
                                                            <tr>
                                                                <td align="left">
                                                                    <asp:Label ID="Label136" runat="server" Text="Contents:  " CssClass="label" />
                                                                    &nbsp
                                                                </td>
                                                                <td align="left">
                                                                    <asp:TextBox ID="txt_pp_wmjnc2" runat="server" Text="0.00" AutoCompleteType="DisplayName"
                                                                        Casing="UPPER" ToolTip="Personal Property" Width="65" TabIndex="118" />
                                                                    &nbsp;<asp:Label ID="txt_pp_wmjnc2_Amount" runat="server" Text="0.00" CssClass="label" />
                                                                    &nbsp;
                                                                </td>
                                                            </tr>
                                                            
                                                           <tr>
                                                                <td align="left">
                                                                    <asp:Label ID="Label142" runat="server" Text="Contents Replacement Cost:  " CssClass="label" />
                                                                    &nbsp
                                                                </td>
                                                                <td align="left">
                                                                    <asp:DropDownList ID="dd_rep_wmjnc2" runat="server" TabIndex="120" 
                                                                        ClientIDMode="Static">
                                                                        <asp:ListItem>No</asp:ListItem>
                                                                        <asp:ListItem>Yes</asp:ListItem>
                                                                    </asp:DropDownList>
                                                                    &nbsp;
                                                                    <asp:Label ID="dd_rep_wmjnc2_Amount" runat="server" Text="0.00" CssClass="label" />
                                                                    &nbsp;
                                                                </td>
                                                            </tr>
                                                            <%--<tr>
                                                                <td id="trmhwmjOpt2_nc2" align="left" clientidmode="Static">
                                                                    <asp:Label ID="Label143" runat="server" Text="Full Repair:  " CssClass="label" />
                                                                    &nbsp
                                                                </td>
                                                                <td id="trmhwmjOpt2_nc2_d" align="left" clientidmode="Static">
                                                                    <asp:DropDownList ID="dd_sip_wmjnc2" runat="server" TabIndex="121">
                                                                        <asp:ListItem>No</asp:ListItem>
                                                                        <asp:ListItem>Yes</asp:ListItem>
                                                                    </asp:DropDownList>
                                                                    &nbsp;<asp:Label ID="dd_sip_wmjnc2_Amount" runat="server" Text="0.00" CssClass="label" />
                                                                    &nbsp;
                                                                </td>
                                                            </tr>--%>
                                                            <tr>
                                                                <td align="left">
                                                                    <asp:Label ID="Label144" runat="server" Text="Lienholder's Single Interest:   " CssClass="label" />
                                                                    &nbsp
                                                                </td>
                                                                <td align="left">
                                                                    <asp:DropDownList ID="spi_cbo_nc2" runat="server" TabIndex="120" 
                                                                        ClientIDMode="Static">
                                                                        <asp:ListItem>No</asp:ListItem>
                                                                        <asp:ListItem>Yes</asp:ListItem>
                                                                    </asp:DropDownList>
                                                                    &nbsp;
                                                                    <asp:Label ID="spi_nc2_amount" runat="server" Text="0.00" CssClass="label" />
                                                                    &nbsp;
                                                                </td>
                                                            </tr>
                                                            <tr>
                                                                <td align="left">
                                                                    <asp:Label ID="Label711" runat="server" Text="Valuable Personal Property:" CssClass="label" />
                                                                    &nbsp
                                                                </td>
                                                                <td align="left">
                                                                    <asp:DropDownList ID="dd_PackagePerProp_wmjnc2" runat="server" TabIndex="19" ClientIDMode="Static">
                                                                        <asp:ListItem></asp:ListItem>
                                                                        <asp:ListItem>Yes</asp:ListItem>
                                                                        <asp:ListItem>No</asp:ListItem>
                                                                    </asp:DropDownList>
                                                                    &nbsp;
                                                                    <asp:Label ID="Label722" runat="server" Text="Value:" CssClass="label" />
                                                                    &nbsp;
                                                                    &nbsp;
                                                                    <asp:label ID="wmjppvalue_nc2" runat="server" Text="0.00" Enabled="false" CssClass="label"  />
                                                                    &nbsp;
                                                                    &nbsp;
                                                                     &nbsp;
                                                                    &nbsp;
                                                                    <asp:Label ID="Label742" runat="server" Text="Premium" CssClass="label" />
                                                                    &nbsp;
                                                                    &nbsp;
                                                                    <asp:Label ID="wmjppprem_nc2" runat="server" Text="0.00" CssClass="label" />
                                                                    &nbsp;
                                                                </td>
                                                            </tr>
                                                                                                                        
                                                            <tr id="wmjPPl2" style="display:">
                                                                <td align="left" colspan="2">
                                                                    <asp:Label ID="Label772" runat="server" Text="Valuable Personal Property list:" CssClass="label" />
                                                                    &nbsp
                                                                </td>
                                                                <td>
                                                                  
                                                             
                                                                    <asp:Button ID="btnshowPPLwmj_nc2" runat="server" Text="Personal Property Break Down" />
                                                                  
                                                             
                                                              
                                                                    <dx:ASPxPopupControl ID="ASPxPopupControlnc2" runat="server"  PopupElementID="btnshowPPLwmj_nc2" AllowDragging="True" HeaderText = "Scheduled Personal Property Details"
                                                                          MaxWidth="800px" MaxHeight="1800px" MinHeight="150px" MinWidth="150px" ShowFooter="True" Width="250px" Height="130px" >
                                                                   
                                                                        <ContentCollection>
                                                                            <dx:PopupControlContentControl ID="PopupControlContentControlnc2" runat="server" SupportsDisabledAttribute="True">
                                                                              <table>
                                                                                    <tr>
                                                                                    <td>
                                                                                    
                                                                                    
                                                                                  
                                                                                        <dx:ASPxPanel ID="ASPxPanelwmjnc2" runat="server" >
                                                                                            <PanelCollection>
                                                                                                <dx:PanelContent ID="wmjppentry_nc2" runat="server" SupportsDisabledAttribute="True">
                                                                                                <table>
                                                                                                <tr>
                                                                                                <td>
                                                                                                    <asp:Label ID="Label782" runat="server" Text="Choose Category:"></asp:Label>
                                                                                                </td>
                                                                                                <td>
                                                                                                    <dx:ASPxComboBox ID="wmjppcatcmbo_nc2" runat="server" ValueType="System.String">
                                                                                                    <Items>
                                                                                                    <dx:ListEditItem Text="Jewelry" Value= "Jewelry" />
                                                                                                    <dx:ListEditItem Text="Furs" Value= "Furs" />
                                                                                                    <dx:ListEditItem Text="Photography Equipment" Value= "Photography Equipment" />
                                                                                                    <dx:ListEditItem Text="Musical Instruments" Value= "Musical Instruments" />
                                                                                                    <dx:ListEditItem Text="Silverware" Value= "Silverware" />
                                                                                                    <dx:ListEditItem Text="Golfer's Equipment" Value= "Golf Equipment" />
                                                                                                    <dx:ListEditItem Text="Stamp Collections" Value= "Stamp Collections" />
                                                                                                    <dx:ListEditItem Text="Coin Collections" Value= "Coin Collections" />
                                                                                                    <dx:ListEditItem Text="Satellite Dishes" Value= "Satellite Dishes" />
                                                                                                    <dx:ListEditItem Text="Guns" Value= "Guns" />
                                                                                                    <dx:ListEditItem Text="Fine Art excl breakage" Value= "Fine Art excl breakage" />
                                                                                                     <dx:ListEditItem Text="Fine Art incl breakage" Value= "Fine Art incl breakage" />

                                                                                                    </Items>
                                                                                                    </dx:ASPxComboBox>
                                                                                                </td>
                                                                                                </tr>
                                                                                                <tr>
                                                                                                <td>
                                                                                                <asp:Label ID="Label792" runat="server" Text="Description:"></asp:Label>
                                                                                                </td>
                                                                                                <td>
                                                                                                    <dx:ASPxTextBox ID="txtPPLDescriptionwmj_nc2" runat="server" Width="170px">
                                                                                                    </dx:ASPxTextBox>
                                                                                                </td>
                                                                                                </tr>
                                                                                                 <tr>
                                                                                                <td>
                                                                                                <asp:Label ID="Label802" runat="server" Text="Quantity:"></asp:Label>
                                                                                                </td>
                                                                                                <td>
                                                                                                    <dx:ASPxTextBox ID="txtQuantityPPlwmj_nc2" runat="server" Width="170px">
                                                                                                    </dx:ASPxTextBox>
                                                                                                </td>
                                                                                                </tr>
                                                                                                 <tr>
                                                                                                <td>
                                                                                                <asp:Label ID="Label882" runat="server" Text="Value:"></asp:Label>
                                                                                                </td>
                                                                                                <td>
                                                                                                    <dx:ASPxTextBox ID="txtvaluePPLwmj_nc2" runat="server" Width="170px">
                                                                                                    </dx:ASPxTextBox>
                                                                                                </td>
                                                                                                </tr>
                                                                                                <tr>
                                                                                                <td colspan="2">
                                                                                                    <asp:Label ID="Label952" runat="server" Text="Error:"></asp:Label>
                                                                                                </td>
                                                                                                <td align="right">
                                                                                                    <asp:Button ID="btnAddPPLwmj_nc2" runat="server" Text="Add" />
                                                                                                </td></tr>
                                                                                                </table>
                                                                                                </dx:PanelContent>
                                                                                            </PanelCollection>
                                                                                        </dx:ASPxPanel>

                                                                                          </td>
                                                                                          <td>
                                                                                           
                                                                                              <dx:ASPxGridView ID="wmjPPGrid_nc2" runat="server" AutoGenerateColumns="False" KeyFieldName="WMJppID" >
                                                                                                   <SettingsPager Visible="False">
                                                                                                    </SettingsPager>
                                                                                                    <SettingsEditing Mode="Inline" />
                                                                                                    <SettingsBehavior AllowFocusedRow="True" />
                                                                                                  <SettingsEditing Mode="Inline" /><SettingsBehavior AllowFocusedRow="True" /><Columns>
                                                                                                   <dx:GridViewCommandColumn VisibleIndex="0">
                                                                               
                                                                                                       <DeleteButton Visible="True">
                                                                                                        </DeleteButton>
                                                                                                    </dx:GridViewCommandColumn>
                                                                                                      <dx:GridViewDataTextColumn FieldName="WMJppID" Name="id" 
                                                                                                          ShowInCustomizationForm="True" Visible="False" VisibleIndex="6">
                                                                                                      </dx:GridViewDataTextColumn>
                                                                                                      <dx:GridViewDataTextColumn FieldName="QuoteID" Name="ppquoteid" 
                                                                                                          ShowInCustomizationForm="True" Visible="False" VisibleIndex="5">
                                                                                                      </dx:GridViewDataTextColumn>
                                                                                                      <dx:GridViewDataTextColumn Caption="Category" FieldName="CategoryPP" 
                                                                                                          Name="Catname" ShowInCustomizationForm="True" VisibleIndex="0">
                                                                                                      </dx:GridViewDataTextColumn>
                                                                                                      <dx:GridViewDataTextColumn Caption="Description" FieldName="DescriptionPP" 
                                                                                                          Name="ppdescription" ShowInCustomizationForm="True" VisibleIndex="1">
                                                                                                      </dx:GridViewDataTextColumn>
                                                                                                      <dx:GridViewDataTextColumn Caption="QTY" FieldName="QtyPP" Name="ppqty" 
                                                                                                          ShowInCustomizationForm="True" VisibleIndex="2">
                                                                                                      </dx:GridViewDataTextColumn>
                                                                                                      <dx:GridViewDataTextColumn Caption="Value" FieldName="ValuePP" Name="ppvalue" 
                                                                                                          ShowInCustomizationForm="True" VisibleIndex="3">
                                                                                                      </dx:GridViewDataTextColumn>
                                                                                                      <dx:GridViewDataTextColumn Caption="Total" FieldName="TotalPP" Name="pptotal" 
                                                                                                          ShowInCustomizationForm="True" VisibleIndex="4">
                                                                                                      </dx:GridViewDataTextColumn>
                                                                                                  </Columns>
                                                                                              </dx:ASPxGridView>
                                                                                              
                                                                                          </td>
                                                                                    </tr>
                                                                                    </table>
                                                                            </dx:PopupControlContentControl>
                                                                        </ContentCollection>
                                                                   
                                                                    </dx:ASPxPopupControl>
                                                                </td>
                                                            </tr>
                                                           
                                                            <tr>
                                                                <td align="left">
                                                                    <asp:Button ID="wmj1_updateOptions_nc2" runat="server" Text="Update Optional Coverages"
                                                                        OnClick="wmj_premiumbtnClick_nc2" TabIndex="22" />
                                                                </td>
                                                            </tr>
                                                        </tbody>
                                                    </table>
                                                </td>
                                            </tr>
                                          <tr id="wmj_mh_prognc3" runat="server" style="border: 1px solid black;">
                                                <td align="center" style="border: 1px solid" width="251px">
                                                    <label id="lblwmj_ShowOptionsnc3" runat="server" style="color: Blue; cursor: pointer;"
                                                        onclick="AROptionsShow(12);" clientidmode="Static">
                                                        - Show Options</label>
                                                    <asp:HiddenField ID="lblwmj_ShowOptionsnc3_hidden" runat="server" Value="+ Show Options" />
                                                </td>
                                                <td align="center" style="border: 1px solid">
                                                    <asp:Label ID="Label433" runat="server" Text="WMJ Preferred" CssClass="labelCov" />
                                                </td>
                                                <td align="center" style="border: 1px solid">
                                                    <asp:Label ID="wmj_dwellnc3" runat="server" Text="0.00" CssClass="labelCov" />
                                                </td>
                                                <td align="center" style="border: 1px solid" class="style3">
                                                    <asp:Label ID="wmj_unattStrnc3" runat="server" Text="0.00" CssClass="labelCov" />
                                                </td>
                                                <td align="center" style="border: 1px solid">
                                                    <asp:Label ID="wmj_perEffnc3" runat="server" Text="0.00" CssClass="labelCov" />
                                                </td>
                                                <td align="center" style="border: 1px solid;">
                                                    <asp:Label ID="wmj_perLiabnc3" runat="server" Text="0.00" CssClass="labelCov" />
                                                </td>
                                                <td align="center" style="border: 1px solid">
                                                    <asp:Label ID="wmj_medpaync3" runat="server" Text="0.00" CssClass="labelCov" />
                                                </td>
                                                <td align="center" style="border: 1px solid">
                                                    <asp:Label ID="wmj_basepremnc3" runat="server" Text="0.00" CssClass="labelCov" />
                                                </td>
                                                <td align="center" style="border: 1px solid">
                                                    <asp:Label ID="wmj_optionsnc3" runat="server" Text="0.00" CssClass="labelCov" />
                                                </td>
                                                <td align="center" style="border: 1px solid">
                                                    <asp:Label ID="wmj_feesnc3" runat="server" Text="$0.00" CssClass="labelCov" />
                                                </td>
                                                <td align="center" style="border: 1px solid">
                                                    <asp:Label ID="wmj_taxnc3" runat="server" Text="0.00" CssClass="labelCov" />
                                                </td>
                                                <td align="center" style="border: 1px solid">
                                                    <asp:Label ID="wmj_totalnc3" runat="server" Text="0.00" CssClass="labelTotal" />
                                                </td>
                                                <td align="center" style="border: 1px solid">
                                                    <asp:Button ID="selectwmj_nc3btn" runat="server" OnClick="selectwmj1btnnc3_Click" Text="Select" />
                                                </td>
                                            </tr>
                                            <tr id="wmj_mh_prognc3_Options" runat="server" clientidmode="Static">
                                                <td colspan="13">
                                                    <table id="WMJ_nc3_table" runat="server" width="auto" cellpadding="0" cellspacing="0"
                                                        clientidmode="Static" bgcolor="white" title="AR Options">
                                                        <tbody>
                                                            <tr>
                                                                <td align="left">
                                                                    <input id="Button9" type="button" value="Open Calc Detail"  />
                                                                    <asp:Label ID="txt_dwell_wmjnc3_Amount" runat="server" Text="0.00" CssClass="label" Style="display:none" />
                                                                    &nbsp;
                                                                    <asp:Label ID="txt_DedChange_wmjnc3_Amount" runat="server" Text="0.00" CssClass="label" Style="display:none" />
                                                                    <asp:Label ID="txt_Credit_wmjnc3_Amount" runat="server" Text="0.00" CssClass="label" Style="display:none" />
                                                                    &nbsp;
                                                                    <dx:ASPxPopupControl ID="ASPxPopupControlnc3debug" runat="server" PopupElementID="Button9" HeaderText="Standard Calculations" PopupVerticalAlign="Below" PopupHorizontalAlign="LeftSides" AllowDragging="True"
                                                                          MaxWidth="800px" MaxHeight="1800px" MinHeight="150px" MinWidth="150px" ShowFooter="True" Width="250px" Height="130px" >
                                                                    <ContentCollection>
                                                                        <dx:PopupControlContentControl ID="PopupControlContentControlnc3" runat="server">
                                                                            <asp:Panel ID="Panel93" runat="server">
                                                                                <table border="0" cellpadding="4" cellspacing="0">
                                                                                    <tr>
                                                                                        <td valign="top">
                                                                                            
                                                                                            <asp:Label ID="wmjnc3_Debug" runat="server" ClientIDMode="Static" Text=""></asp:Label>
                                                                                        </td>
                                                                                    </tr>
                                                                                  
                                                                                </table>
                                                                            </asp:Panel>
                                                                        </dx:PopupControlContentControl>
                                                                    </ContentCollection>

                                                                    </dx:ASPxPopupControl>
                                                                </td>
                                                            </tr>
                                                            <tr>
                                                                <td align="left">
                                                                    <asp:Label ID="Label573" runat="server" Text="AOP Deductible" CssClass="label" />
                                                                </td>
                                                                <td align="left">
                                                                    <asp:DropDownList ID="dd_aop_wmjnc3" runat="server" TabIndex="112">
                                                                        <asp:ListItem>$500</asp:ListItem>
                                                                       <asp:ListItem>$1000</asp:ListItem>
                                                                    </asp:DropDownList>
                                                                     &nbsp;<asp:Label ID="dd_aop_wmjnc3_Amount" runat="server" Text="0.00" CssClass="label" />
                                                                    &nbsp;
                                                                </td>
                                                            </tr>
                                                            <%--<tr id="wmjWind" runat="server">
                                                                <td align="left">
                                                                    <asp:Label ID="Label58" runat="server" Text="Named Storm Deductible" CssClass="label" />
                                                                </td>
                                                                <td align="left">
                                                                    <asp:TextBox ID="dd_hurded_wmjnc3" runat="server" Text="0.00" 
                                                                        AutoCompleteType="DisplayName" Enabled="false" TabIndex="113" />
                                                                </td>
                                                            </tr>--%>
                                                            <tr id="tr1_nc3">
                                                                <td align="left">
                                                                    <asp:Label ID="Label973" runat="server" Text="Loss of Use" CssClass="label" />
                                                                </td>
                                                                <td align="left">
                                                                    <asp:TextBox ID="wmjlossofusenc3" runat="server" Text="0.00" 
                                                                        AutoCompleteType="DisplayName" Enabled="false" TabIndex="303" />
                                                                </td>
                                                            </tr>
                                                            <tr>
                                                                <td>
                                                                    &nbsp;
                                                                </td>
                                                            </tr>
                                                            <tr>
                                                                <td align="left">
                                                                    <asp:Label ID="Label593" runat="server" Text="Personal Liability:  " CssClass="label" />
                                                                    &nbsp
                                                                </td>
                                                                <td align="left">
                                                                    <asp:DropDownList ID="dd_pl_wmjnc3" runat="server" AutoPostBack="true" 
                                                                        TabIndex="115" >
                                                                        <%--<asp:ListItem>$0</asp:ListItem>--%>
                                                                    
                                                                        <asp:ListItem>$50,000</asp:ListItem>
                                                                        <asp:ListItem>$100,000</asp:ListItem>
                                                                       <asp:ListItem>$300,000</asp:ListItem>
                                                                    </asp:DropDownList>
                                                                    &nbsp;<asp:Label ID="dd_pl_wmjnc3_Amount" runat="server" Text="0.00" CssClass="label" />
                                                                    &nbsp;
                                                                </td>
                                                            </tr>
                                                            <tr id="wmj_StandardMedPaync3" style="display: " clientidmode="Static">
                                                                <td align="left">
                                                                    <asp:Label ID="Label603" runat="server" Text="Medical payment:  " CssClass="label" />
                                                                    &nbsp
                                                                </td>
                                                                <td align="left">
                                                                    <asp:DropDownList ID="dd_mp_wmjnc3" runat="server"  clientidmode="Static" 
                                                                        TabIndex="116">
                                                                        
                                                                        <asp:ListItem>$1000</asp:ListItem>
                                                                       
                                                                    </asp:DropDownList>
                                                                     &nbsp;
                                                                    <asp:Label ID="dd_med_wmjnc3_amt" runat="server" Text="0.00" CssClass="label" />
                                                                    &nbsp;
                                                                </td>
                                                            </tr>
                                                             <tr style="border: 1px solid black">
                                                                <td align="left">
                                                                    <asp:Label ID="Label993" runat="server" Text="Additional Residence:" CssClass="label" />
                                                                    &nbsp
                                                                </td>
                                                                <td align="left">
                                                                    <asp:DropDownList ID="dd_addresOpt_wmjnc3" runat="server" ClientIDMode="Static">
                                                                        <asp:ListItem></asp:ListItem>
                                                                        <%--<asp:ListItem>Premises Occupied by Insured</asp:ListItem>--%>
                                                                        <asp:ListItem>1 Family</asp:ListItem>
                                                                        <asp:ListItem>2 Family</asp:ListItem>
                                                                    </asp:DropDownList>
                                                                    &nbsp;
                                                                    <asp:Label ID="dd_addresOpt_wmjnc3_Amount" runat="server" Text="0.00" CssClass="label" />
                                                                    &nbsp;
                                                                </td>
                                                            </tr>
                                                            <tr id="wmj_AddResOpt1_nc3" clientidmode="Static">
                                                                <td align="left">
                                                                   <%-- <asp:HiddenField ID="AR_AddResOpt1_HIDDEN" runat="server" />--%>
                                                                    <asp:Label ID="Label963" runat="server" Text="Additional Residence Liability" CssClass="label" />
                                                                    &nbsp
                                                                </td>
                                                                <td align="left">
                                                                    <asp:DropDownList ID="dd_addresliab_wmjnc3" runat="server" ClientIDMode="Static">
                                                                        <asp:ListItem>$0</asp:ListItem>
                                                                        <asp:ListItem>$50,000</asp:ListItem>
                                                                        <asp:ListItem>$100,000</asp:ListItem>
                                                                        <asp:ListItem>$300,000</asp:ListItem>
                                                                    </asp:DropDownList>
                                                                      &nbsp;
                                                                    <asp:Label ID="addres_liab_wmjnc3_amount" runat="server" Text="0.00" CssClass="label" />
                                                                    &nbsp;
                                                                </td>
                                                            </tr>
                                                            <tr>
                                                                <td>
                                                                    &nbsp;
                                                                </td>
                                                            </tr>
                                                            <tr>
                                                                <td align="left">
                                                                    <asp:Label ID="Label623" runat="server" Text="Other Structures:  " CssClass="label" />
                                                                    &nbsp
                                                                </td>
                                                                <td align="left">
                                                                    <asp:TextBox ID="txt_unattstr_wmjnc3" runat="server" Text="0.00" AutoCompleteType="DisplayName"
                                                                        Casing="UPPER" ToolTip="Unattached Structure" Width="65" TabIndex="117"/>
                                                                    &nbsp;<asp:Label ID="txt_unattstr_wmjnc3_Amount" runat="server" Text="0.00" CssClass="label" />
                                                                    &nbsp;
                                                                </td>
                                                            </tr>
                                                            <tr>
                                                                <td align="left">
                                                                    <asp:Label ID="Label663" runat="server" Text="Contents:  " CssClass="label" />
                                                                    &nbsp
                                                                </td>
                                                                <td align="left">
                                                                    <asp:TextBox ID="txt_pp_wmjnc3" runat="server" Text="0.00" AutoCompleteType="DisplayName"
                                                                        Casing="UPPER" ToolTip="Personal Property" Width="65" TabIndex="118" />
                                                                    &nbsp;<asp:Label ID="txt_pp_wmjnc3_Amount" runat="server" Text="0.00" CssClass="label" />
                                                                    &nbsp;
                                                                </td>
                                                            </tr>
                                                            
                                                           <tr>
                                                                <td align="left">
                                                                    <asp:Label ID="Label683" runat="server" Text="Contents Replacement Cost:  " CssClass="label" />
                                                                    &nbsp
                                                                </td>
                                                                <td align="left">
                                                                    <asp:DropDownList ID="dd_rep_wmjnc3" runat="server" TabIndex="120" 
                                                                        ClientIDMode="Static">
                                                                        <asp:ListItem>No</asp:ListItem>
                                                                        <asp:ListItem>Yes</asp:ListItem>
                                                                    </asp:DropDownList>
                                                                    &nbsp;
                                                                    <asp:Label ID="dd_rep_wmjnc3_Amount" runat="server" Text="0.00" CssClass="label" />
                                                                    &nbsp;
                                                                </td>
                                                            </tr>
                                                           <%-- <tr>
                                                                <td id="trmhwmjOpt2_nc3" align="left" clientidmode="Static">
                                                                    <asp:Label ID="Label693" runat="server" Text="Full Repair:  " CssClass="label" />
                                                                    &nbsp
                                                                </td>
                                                                <td id="trmhwmjOpt2_nc3_d" align="left" clientidmode="Static">
                                                                    <asp:DropDownList ID="dd_sip_wmj3" runat="server" TabIndex="121">
                                                                        <asp:ListItem>No</asp:ListItem>
                                                                        <asp:ListItem>Yes</asp:ListItem>
                                                                    </asp:DropDownList>
                                                                    &nbsp;<asp:Label ID="dd_sip_wmjnc3_Amount" runat="server" Text="0.00" CssClass="label" />
                                                                    &nbsp;
                                                                </td>
                                                            </tr>--%>
                                                            <tr>
                                                                <td align="left">
                                                                    <asp:Label ID="Label703" runat="server" Text="Lienholder's Single Interest:   " CssClass="label" />
                                                                    &nbsp
                                                                </td>
                                                                <td align="left">
                                                                    <asp:DropDownList ID="spi_cbo_nc3" runat="server" TabIndex="120" 
                                                                        ClientIDMode="Static">
                                                                        <asp:ListItem>No</asp:ListItem>
                                                                        <asp:ListItem>Yes</asp:ListItem>
                                                                    </asp:DropDownList>
                                                                    &nbsp;
                                                                    <asp:Label ID="spi_nc3_amount" runat="server" Text="0.00" CssClass="label" />
                                                                    &nbsp;
                                                                </td>
                                                            </tr>
                                                            <tr>
                                                                <td align="left">
                                                                    <asp:Label ID="Label713" runat="server" Text="Valuable Personal Property:" CssClass="label" />
                                                                    &nbsp
                                                                </td>
                                                                <td align="left">
                                                                    <asp:DropDownList ID="dd_PackagePerProp_wmjnc3" runat="server" TabIndex="19" ClientIDMode="Static">
                                                                        <asp:ListItem></asp:ListItem>
                                                                        <asp:ListItem>Yes</asp:ListItem>
                                                                        <asp:ListItem>No</asp:ListItem>
                                                                    </asp:DropDownList>
                                                                    &nbsp;
                                                                    <asp:Label ID="Label723" runat="server" Text="Value:" CssClass="label" />
                                                                    &nbsp;
                                                                    &nbsp;
                                                                    <asp:label ID="wmjppvalue_nc3" runat="server" Text="0.00" Enabled="false" CssClass="label"  />
                                                                    &nbsp;
                                                                    &nbsp;
                                                                     &nbsp;
                                                                    &nbsp;
                                                                    <asp:Label ID="Label743" runat="server" Text="Premium" CssClass="label" />
                                                                    &nbsp;
                                                                    &nbsp;
                                                                    <asp:Label ID="wmjppprem_nc3" runat="server" Text="0.00" CssClass="label" />
                                                                    &nbsp;
                                                                </td>
                                                            </tr>
                                                                                                                        
                                                            <tr id="wmjPPl3" style="display:">
                                                                <td align="left" colspan="2">
                                                                    <asp:Label ID="Label773" runat="server" Text="Valuable Personal Property list:" CssClass="label" />
                                                                    &nbsp
                                                                </td>
                                                                <td>
                                                                  
                                                             
                                                                    <asp:Button ID="btnshowPPLwmj_nc3" runat="server" Text="Personal Property Break Down" />
                                                                  
                                                             
                                                              
                                                                    <dx:ASPxPopupControl ID="ASPxPopupControlnc3" runat="server"  PopupElementID="btnshowPPLwmj_nc3" AllowDragging="True" HeaderText = "Scheduled Personal Property Details"
                                                                          MaxWidth="800px" MaxHeight="1800px" MinHeight="150px" MinWidth="150px" ShowFooter="True" Width="250px" Height="130px" >
                                                                   
                                                                        <ContentCollection>
                                                                            <dx:PopupControlContentControl ID="PopupControlContentControl11nc" runat="server" SupportsDisabledAttribute="True">
                                                                              <table>
                                                                                    <tr>
                                                                                    <td>
                                                                                    
                                                                                    
                                                                                  
                                                                                        <dx:ASPxPanel ID="ASPxPanelwmjnc3" runat="server" >
                                                                                            <PanelCollection>
                                                                                                <dx:PanelContent ID="wmjppentry_nc3" runat="server" SupportsDisabledAttribute="True">
                                                                                                <table>
                                                                                                <tr>
                                                                                                <td>
                                                                                                    <asp:Label ID="Label783" runat="server" Text="Choose Category:"></asp:Label>
                                                                                                </td>
                                                                                                <td>
                                                                                                    <dx:ASPxComboBox ID="wmjppcatcmbo_nc3" runat="server" ValueType="System.String">
                                                                                                    <Items>
                                                                                                    <dx:ListEditItem Text="Jewelry" Value= "Jewelry" />
                                                                                                    <dx:ListEditItem Text="Furs" Value= "Furs" />
                                                                                                    <dx:ListEditItem Text="Photography Equipment" Value= "Photography Equipment" />
                                                                                                    <dx:ListEditItem Text="Musical Instruments" Value= "Musical Instruments" />
                                                                                                    <dx:ListEditItem Text="Silverware" Value= "Silverware" />
                                                                                                    <dx:ListEditItem Text="Golfer's Equipment" Value= "Golf Equipment" />
                                                                                                    <dx:ListEditItem Text="Stamp Collections" Value= "Stamp Collections" />
                                                                                                    <dx:ListEditItem Text="Coin Collections" Value= "Coin Collections" />
                                                                                                    <dx:ListEditItem Text="Satellite Dishes" Value= "Satellite Dishes" />
                                                                                                    <dx:ListEditItem Text="Guns" Value= "Guns" />
                                                                                                    <dx:ListEditItem Text="Fine Art excl breakage" Value= "Fine Art excl breakage" />
                                                                                                     <dx:ListEditItem Text="Fine Art incl breakage" Value= "Fine Art incl breakage" />

                                                                                                    </Items>
                                                                                                    </dx:ASPxComboBox>
                                                                                                </td>
                                                                                                </tr>
                                                                                                <tr>
                                                                                                <td>
                                                                                                <asp:Label ID="Label793" runat="server" Text="Description:"></asp:Label>
                                                                                                </td>
                                                                                                <td>
                                                                                                    <dx:ASPxTextBox ID="txtPPLDescriptionwmj_nc3" runat="server" Width="170px">
                                                                                                    </dx:ASPxTextBox>
                                                                                                </td>
                                                                                                </tr>
                                                                                                 <tr>
                                                                                                <td>
                                                                                                <asp:Label ID="Label803" runat="server" Text="Quantity:"></asp:Label>
                                                                                                </td>
                                                                                                <td>
                                                                                                    <dx:ASPxTextBox ID="txtQuantityPPlwmj_nc3" runat="server" Width="170px">
                                                                                                    </dx:ASPxTextBox>
                                                                                                </td>
                                                                                                </tr>
                                                                                                 <tr>
                                                                                                <td>
                                                                                                <asp:Label ID="Label883" runat="server" Text="Value:"></asp:Label>
                                                                                                </td>
                                                                                                <td>
                                                                                                    <dx:ASPxTextBox ID="txtvaluePPLwmj_nc3" runat="server" Width="170px">
                                                                                                    </dx:ASPxTextBox>
                                                                                                </td>
                                                                                                </tr>
                                                                                                <tr>
                                                                                                <td colspan="2">
                                                                                                    <asp:Label ID="Label953" runat="server" Text="Error:"></asp:Label>
                                                                                                </td>
                                                                                                <td align="right">
                                                                                                    <asp:Button ID="btnAddPPLwmj_nc3" runat="server" Text="Add" />
                                                                                                </td></tr>
                                                                                                </table>
                                                                                                </dx:PanelContent>
                                                                                            </PanelCollection>
                                                                                        </dx:ASPxPanel>

                                                                                          </td>
                                                                                          <td>
                                                                                           
                                                                                              <dx:ASPxGridView ID="wmjPPGrid_nc3" runat="server" AutoGenerateColumns="False" KeyFieldName="WMJppID" >
                                                                                                   <SettingsPager Visible="False">
                                                                                                    </SettingsPager>
                                                                                                    <SettingsEditing Mode="Inline" />
                                                                                                    <SettingsBehavior AllowFocusedRow="True" />
                                                                                                  <SettingsEditing Mode="Inline" /><SettingsBehavior AllowFocusedRow="True" /><Columns>
                                                                                                   <dx:GridViewCommandColumn VisibleIndex="0">
                                                                               
                                                                                                       <DeleteButton Visible="True">
                                                                                                        </DeleteButton>
                                                                                                    </dx:GridViewCommandColumn>
                                                                                                      <dx:GridViewDataTextColumn FieldName="WMJppID" Name="id" 
                                                                                                          ShowInCustomizationForm="True" Visible="False" VisibleIndex="6">
                                                                                                      </dx:GridViewDataTextColumn>
                                                                                                      <dx:GridViewDataTextColumn FieldName="QuoteID" Name="ppquoteid" 
                                                                                                          ShowInCustomizationForm="True" Visible="False" VisibleIndex="5">
                                                                                                      </dx:GridViewDataTextColumn>
                                                                                                      <dx:GridViewDataTextColumn Caption="Category" FieldName="CategoryPP" 
                                                                                                          Name="Catname" ShowInCustomizationForm="True" VisibleIndex="0">
                                                                                                      </dx:GridViewDataTextColumn>
                                                                                                      <dx:GridViewDataTextColumn Caption="Description" FieldName="DescriptionPP" 
                                                                                                          Name="ppdescription" ShowInCustomizationForm="True" VisibleIndex="1">
                                                                                                      </dx:GridViewDataTextColumn>
                                                                                                      <dx:GridViewDataTextColumn Caption="QTY" FieldName="QtyPP" Name="ppqty" 
                                                                                                          ShowInCustomizationForm="True" VisibleIndex="2">
                                                                                                      </dx:GridViewDataTextColumn>
                                                                                                      <dx:GridViewDataTextColumn Caption="Value" FieldName="ValuePP" Name="ppvalue" 
                                                                                                          ShowInCustomizationForm="True" VisibleIndex="3">
                                                                                                      </dx:GridViewDataTextColumn>
                                                                                                      <dx:GridViewDataTextColumn Caption="Total" FieldName="TotalPP" Name="pptotal" 
                                                                                                          ShowInCustomizationForm="True" VisibleIndex="4">
                                                                                                      </dx:GridViewDataTextColumn>
                                                                                                  </Columns>
                                                                                              </dx:ASPxGridView>
                                                                                              
                                                                                          </td>
                                                                                    </tr>
                                                                                    </table>
                                                                            </dx:PopupControlContentControl>
                                                                        </ContentCollection>
                                                                   
                                                                    </dx:ASPxPopupControl>
                                                                </td>
                                                            </tr>
                                                           
                                                            <tr>
                                                                <td align="left">
                                                                    <asp:Button ID="wmj1_updateOptions_nc3" runat="server" Text="Update Optional Coverages"
                                                                        OnClick="wmj_premiumbtnClick_nc3" TabIndex="22" />
                                                                </td>
                                                            </tr>
                                                        </tbody>
                                                    </table>
                                                </td>
                                            </tr>
                                          
                                          
                                          <%-- WMJ NC END--%>
                                         <%-- Aegis Vintage Start--%>
                                         <tr id="Aegisvint_mh_progsc1" runat="server" style="border: 1px solid black;">
                                                <td align="center" style="border: 1px solid" width="251px">
                                                    <label id="lblAegisvint_ShowOptionssc1" runat="server" style="color: Blue; cursor: pointer;"
                                                        onclick="AROptionsShow(13);" clientidmode="Static">
                                                        - Show Options</label>
                                                    <asp:HiddenField ID="lblAegisvint_ShowOptionssc1_hidden" runat="server" Value="+ Show Options" />
                                                </td>
                                                <td align="center" style="border: 1px solid">
                                                    <asp:Label ID="Label160" runat="server" Text="Aegis Vintage" CssClass="labelCov" />
                                                </td>
                                                <td align="center" style="border: 1px solid">
                                                    <asp:Label ID="Aegisvint_dwellsc1" runat="server" Text="0.00" CssClass="labelCov" />
                                                </td>
                                                <td align="center" style="border: 1px solid" class="style3">
                                                    <asp:Label ID="Aegisvint_unattStrsc1" runat="server" Text="0.00" CssClass="labelCov" />
                                                </td>
                                                <td align="center" style="border: 1px solid">
                                                    <asp:Label ID="Aegisvint_perEffsc1" runat="server" Text="0.00" CssClass="labelCov" />
                                                </td>
                                                <td align="center" style="border: 1px solid;">
                                                    <asp:Label ID="Aegisvint_perLiabsc1" runat="server" Text="0.00" CssClass="labelCov" />
                                                </td>
                                                <td align="center" style="border: 1px solid">
                                                    <asp:Label ID="Aegisvint_medpaysc1" runat="server" Text="0.00" CssClass="labelCov" />
                                                </td>
                                                <td align="center" style="border: 1px solid">
                                                    <asp:Label ID="Aegisvint_basepremsc1" runat="server" Text="0.00" CssClass="labelCov" />
                                                </td>
                                                <td align="center" style="border: 1px solid">
                                                    <asp:Label ID="Aegisvint_optionssc1" runat="server" Text="0.00" CssClass="labelCov" />
                                                </td>
                                                <td align="center" style="border: 1px solid">
                                                    <asp:Label ID="Aegisvint_feessc1" runat="server" Text="$0.00" CssClass="labelCov" />
                                                </td>
                                                <td align="center" style="border: 1px solid">
                                                    <asp:Label ID="Aegisvint_taxsc1" runat="server" Text="0.00" CssClass="labelCov" />
                                                </td>
                                                <td align="center" style="border: 1px solid">
                                                    <asp:Label ID="Aegisvint_totalsc1" runat="server" Text="0.00" CssClass="labelTotal" />
                                                </td>
                                                <td align="center" style="border: 1px solid">
                                                    <asp:Button ID="selectAegisvint_sc1btn" runat="server" OnClick="selectAegisvint1btnsc1_Click" Text="Select" />
                                                </td>
                                            </tr>
                                            <tr id="Aegisvint_mh_progsc1_Options" runat="server" clientidmode="Static">
                                                <td colspan="13">
                                                    <table id="Aegisvint_sc1_table" runat="server" width="auto" cellpadding="0" cellspacing="0"
                                                        clientidmode="Static" bgcolor="white" title="AR Options">
                                                        <tbody>
                                                            <tr>
                                                                <td align="left">
                                                                    <input id="Button10" type="button" value="Open Calc Detail"  />
                                                                    <asp:Label ID="txt_dwell_Aegisvintsc1_Amount" runat="server" Text="0.00" CssClass="label" Style="display:none" />
                                                                    &nbsp;
                                                                    <asp:Label ID="txt_DedChange_Aegisvintsc1_Amount" runat="server" Text="0.00" CssClass="label" Style="display:none" />
                                                                    <asp:Label ID="txt_Credit_Aegisvintsc1_Amount" runat="server" Text="0.00" CssClass="label" Style="display:none" />
                                                                    &nbsp;
                                                                    <dx:ASPxPopupControl ID="ASPxPopupControlsc1" runat="server" PopupElementID="Button10" HeaderText="Standard Calculations" PopupVerticalAlign="Below" PopupHorizontalAlign="LeftSides" AllowDragging="True"
                                                                          MaxWidth="800px" MaxHeight="1800px" MinHeight="150px" MinWidth="150px" ShowFooter="True" Width="250px" Height="130px" >
                                                                    <ContentCollection>
                                                                        <dx:PopupControlContentControl ID="PopupControlContentControlsc11" runat="server">
                                                                            <asp:Panel ID="Panel12" runat="server">
                                                                                <table border="0" cellpadding="4" cellspacing="0">
                                                                                    <tr>
                                                                                        <td valign="top">
                                                                                            
                                                                                            <asp:Label ID="Aegisvintsc1_Debug" runat="server" ClientIDMode="Static" Text=""></asp:Label>
                                                                                        </td>
                                                                                    </tr>
                                                                                  
                                                                                </table>
                                                                            </asp:Panel>
                                                                        </dx:PopupControlContentControl>
                                                                    </ContentCollection>

                                                                    </dx:ASPxPopupControl>
                                                                </td>
                                                            </tr>
                                                            <tr>
                                                                <td align="left">
                                                                    <asp:Label ID="Label161" runat="server" Text="AOP Deductible" CssClass="label" />
                                                                </td>
                                                                <td align="left">
                                                                    <asp:DropDownList ID="dd_aop_Aegisvintsc1" runat="server" TabIndex="112">
                                                                        <asp:ListItem>$500</asp:ListItem>
                                                                       <%--<asp:ListItem>$1000</asp:ListItem>--%>
                                                                    </asp:DropDownList>
                                                                     &nbsp;<asp:Label ID="dd_aop_Aegisvintsc1_Amount" runat="server" Text="0.00" CssClass="label" />
                                                                    &nbsp;
                                                                </td>
                                                            </tr>
                                                            <tr id="AegisvintWind" runat="server">
                                                                <td align="left">
                                                                    <asp:Label ID="Label958" runat="server" Text="Named Storm Deductible" CssClass="label" />
                                                                </td>
                                                                <td align="left">
                                                                    <asp:TextBox ID="dd_hurded_Aegisvintsc1" runat="server" Text="0.00" 
                                                                        AutoCompleteType="DisplayName" Enabled="false" TabIndex="113" />
                                                                </td>
                                                            </tr>
                                                            <tr id="aegisvintageWindhur1" runat="server">
                                                                <td align="left">
                                                                    <asp:Label ID="Label183" runat="server" Text="Wind\Hail\Tornado Deductible" CssClass="label" />
                                                                </td>
                                                                <td align="left">
                                                                    <asp:TextBox ID="dd_wind_Aegisvintsc1" runat="server" Text="0.00" 
                                                                        AutoCompleteType="DisplayName" Enabled="false" TabIndex="113" />
                                                                </td>
                                                            </tr>
                                                           
                                                            <tr>
                                                                <td>
                                                                    &nbsp;
                                                                </td>
                                                            </tr>
                                                            <tr>
                                                                <td align="left">
                                                                    <asp:Label ID="Label163" runat="server" Text="Personal Liability:  " CssClass="label" />
                                                                    &nbsp
                                                                </td>
                                                                <td align="left">
                                                                    <asp:DropDownList ID="dd_pl_Aegisvintsc1" runat="server" AutoPostBack="true" 
                                                                        TabIndex="115" >
                                                                        <%--<asp:ListItem>$0</asp:ListItem>--%>
                                                                    
                                                                        <asp:ListItem>$25,000</asp:ListItem>
                                                                       
                                                                    </asp:DropDownList>
                                                                    &nbsp;<asp:Label ID="dd_pl_Aegisvintsc1_Amount" runat="server" Text="0.00" CssClass="label" />
                                                                    &nbsp;
                                                                </td>
                                                            </tr>
                                                            <tr id="Tr8" style="display: " clientidmode="Static">
                                                                <td align="left">
                                                                    <asp:Label ID="Label364" runat="server" Text="Medical payment:  " CssClass="label" />
                                                                    &nbsp
                                                                </td>
                                                                <td align="left">
                                                                    <asp:DropDownList ID="dd_mp_Aegisvintsc1" runat="server"  clientidmode="Static" 
                                                                        TabIndex="116">
                                                                       <%-- <asp:ListItem>$0</asp:ListItem>--%>
                                                                        <asp:ListItem>$500</asp:ListItem>
                                                                      <%-- <asp:ListItem>$1000</asp:ListItem>--%>
                                                                    </asp:DropDownList>
                                                                     &nbsp;
                                                                    <asp:Label ID="dd_med_Aegisvintsc1_amt" runat="server" Text="0.00" CssClass="label" />
                                                                    &nbsp;
                                                                </td>
                                                            </tr>
                                                            
                                                            
                                                           <%-- <tr>
                                                                <td>
                                                                    &nbsp;
                                                                </td>
                                                            </tr>--%>
                                                            <tr>
                                                                <td align="left">
                                                                    <asp:Label ID="Label181" runat="server" Text="Other Structures:  " CssClass="label" />
                                                                    &nbsp
                                                                </td>
                                                                <td align="left">
                                                                    <asp:TextBox ID="txt_unattstr_Aegisvintsc1" runat="server" Text="0.00" AutoCompleteType="DisplayName"
                                                                        Casing="UPPER" ToolTip="Unattached Structure" Width="65" TabIndex="117"/>
                                                                    &nbsp;<asp:Label ID="txt_unattstr_Aegisvintsc1_Amount" runat="server" Text="0.00" CssClass="label" />
                                                                    &nbsp;
                                                                </td>
                                                            </tr>
                                                            <tr>
                                                                <td align="left">
                                                                    <asp:Label ID="Label182" runat="server" Text="Contents:  " CssClass="label" />
                                                                    &nbsp
                                                                </td>
                                                                <td align="left">
                                                                    <asp:TextBox ID="txt_pp_Aegisvintsc1" runat="server" Text="0.00" AutoCompleteType="DisplayName"
                                                                        Casing="UPPER" ToolTip="Personal Property" Width="65" TabIndex="118" />
                                                                    &nbsp;<asp:Label ID="txt_pp_Aegisvintsc1_Amount" runat="server" Text="0.00" CssClass="label" />
                                                                    &nbsp;
                                                                </td>
                                                            </tr>
                                                            
                                                          
                                                            <tr>
                                                                <td align="left">
                                                                    <asp:Button ID="Aegisvint1_updateOptions_sc1" runat="server" Text="Update Optional Coverages"
                                                                        OnClick="Aegisvint_premiumbtnClick_sc1" TabIndex="22" />
                                                                </td>
                                                            </tr>
                                                        </tbody>
                                                    </table>
                                                </td>
                                            </tr>

                                         <%--Aegis Vintage End--%>
                                                <tr id="AR_Ineligible" style="border: 1px solid black; display: none">
                                                    <td align="center" colspan="12" style="border: 1px solid">
                                                        <label id="AR_Errlbl" style="font-size: larger">
                                                        </label>
                                                    </td>
                                                </tr>
                                        
                                        </tbody>
                                    </table>
                                    <asp:Button ID="ar_premiumbtn" Text="CalcARPremium" runat="server" OnClick="ar_premiumbtnClick"
                                        Style="display: none" />
                                </ContentTemplate>
                                <Triggers>
                                    <asp:AsyncPostBackTrigger ControlID="ar_premiumbtn" EventName="Click" />
                                </Triggers>
                            </asp:UpdatePanel>
       
    <asp:Label ID="MHValuelbl" runat="server" Text=""  Style="display: none"></asp:Label>
    <asp:Label ID="mhstatelbl" runat="server" Text=""  Style="display: none"></asp:Label>
    <asp:Label ID="mhtypelbl" runat="server" Text=""  Style="display: none"></asp:Label>
    <asp:Label ID="mhmfglbl" runat="server" Text=""  Style="display: none"></asp:Label>
    <asp:Label ID="mhyearlbl" runat="server" Text=""  Style="display: none"></asp:Label>
    <asp:Label ID="mhcountylbl" runat="server" Text=""  Style="display: none"></asp:Label>
    <asp:Label ID="quoteIDlbl" runat="server" Text=""  Style="display: none"></asp:Label>
    <asp:Label ID="mhusagelbl" runat="server" Text=""  Style="display: none"></asp:Label>
    <asp:Label ID="mhdistlbl" runat="server" Text=""  Style="display: none"></asp:Label>
    <asp:Label ID="packperclbl" runat="server" Text=""  Style="display: none"></asp:Label>
    <asp:Label ID="packcramtlbl" runat="server" Text=""  Style="display: none"></asp:Label>
    <asp:Label ID="standperclbl" runat="server" Text=""  Style="display: none"></asp:Label>
    <asp:Label ID="standcramtlbl" runat="server" Text=""  Style="display: none"></asp:Label>
    <asp:Label ID="rentperclbl" runat="server" Text=""  Style="display: none"></asp:Label>
    <asp:Label ID="rentcramtlbl" runat="server" Text=""  Style="display: none"></asp:Label>
     <asp:Label ID="packpremlbl" runat="server" Text=""  Style="display: none"></asp:Label>
      <asp:Label ID="standpremlbl" runat="server" Text=""  Style="display: none"></asp:Label>
       <asp:Label ID="rentpremlbl" runat="server" Text=""  Style="display: none"></asp:Label>
        <asp:Label ID="vacantpremlbl" runat="server" Text=""  Style="display: none"></asp:Label>
        <asp:Label ID="protection" runat="server" Text=""  Style="display: none"></asp:Label>
        <asp:Label ID="lienlbl" runat="server" Text=""  Style="display: none"></asp:Label>
        <asp:Label ID="supheatlbl" runat="server" Text=""  Style="display: none"></asp:Label>
       <asp:Label ID="SMHpackperclbl" runat="server" Text=""  Style="display: none"></asp:Label>
       <asp:Label ID="aegisterritorylbl" runat="server" Text=""  Style="display: none"></asp:Label>
    <asp:Label ID="SMHpackcramtlbl" runat="server" Text=""  Style="display: none"></asp:Label>
     <asp:Label ID="SMHpackpremlbl" runat="server" Text=""  Style="display: none"></asp:Label>
      <asp:Label ID="territorylbl" runat="server" Text=""  Style="display: none"></asp:Label>

       <asp:Label ID="aegispackperclbl" runat="server" Text=""  Style="display: none"></asp:Label>
        <asp:Label ID="aegispackcramtlbl" runat="server" Text=""  Style="display: none"></asp:Label>
         <asp:Label ID="aegisrentperclbl" runat="server" Text=""  Style="display: none"></asp:Label>
          <asp:Label ID="aegisrentcramtlbl" runat="server" Text=""  Style="display: none"></asp:Label>
           <asp:Label ID="aegispackpremlbl" runat="server" Text=""  Style="display: none"></asp:Label>
            <asp:Label ID="aegisrentpremlbl" runat="server" Text=""  Style="display: none"></asp:Label>
             <asp:Label ID="lbldob" runat="server" Text=""  Style="display: none"></asp:Label>
               <asp:Button ID="btn" runat="server" Text="" Height="0px" Width="0px" Style="display: none"/>
                <asp:Button ID="btnpp" runat="server" Text="" Height="0px" Width="0px" Style="display: none"/>
                 <asp:Label ID="lbl_Lloyds_Pack" runat="server" Text=""  Style="display: none"></asp:Label>
                 <asp:Label ID="lbl_Lloyds_Stand" runat="server" Text=""  Style="display: none"></asp:Label>
                 <asp:Label ID="lbl_Lloyds_Rent" runat="server" Text=""  Style="display: none"></asp:Label>
                 <asp:Label ID="lbl_Lloyds_SMH" runat="server" Text=""  Style="display: none"></asp:Label>
                 <asp:Label ID="lbl_Aegis_Stand" runat="server" Text=""  Style="display: none"></asp:Label>
                 <asp:Label ID="lbl_Aegis_Rent" runat="server" Text=""  Style="display: none"></asp:Label>
                 <asp:Label ID="lbl_Amslic_Stand" runat="server" Text=""  Style="display: none"></asp:Label>
                 <asp:Label ID="lbl_Amslic_Rent" runat="server" Text=""  Style="display: none"></asp:Label>
                 <asp:Label ID="lblskirt" runat="server" Text=""  Style="display: none"></asp:Label>
                  <asp:Label ID="lblSub" runat="server" Text=""  Style="display: none"></asp:Label>
                  <asp:Label ID="Amslicrentpremlbl" runat="server" Text=""  Style="display: none"></asp:Label>
        <asp:Label ID="Amslicpackpremlbl" runat="server" Text=""  Style="display: none"></asp:Label>
        <asp:Label ID="WMJpackperclbl" runat="server" Text=""  Style="display: none"></asp:Label>
        <asp:Label ID="WMJpackcramtlbl" runat="server" Text=""  Style="display: none"></asp:Label>
           <asp:Label ID="WMJpackpremlbl" runat="server" Text=""  Style="display: none"></asp:Label>
           <asp:Label ID="lbl_WMJ_Pack" runat="server" Text=""  Style="display: none"></asp:Label>
           <asp:Label ID="lbl_WMJ_PackNC" runat="server" Text=""  Style="display: none"></asp:Label>
            <asp:Label ID="WMJpackpremlblnc1" runat="server" Text=""  Style="display: none"></asp:Label>
                 <asp:Label ID="WMJpackperclblnc1" runat="server" Text=""  Style="display: none"></asp:Label>
        <asp:Label ID="WMJpackcramtlblnc1" runat="server" Text=""  Style="display: none"></asp:Label>
       <asp:Label ID="WMJpackpremlblnc2" runat="server" Text=""  Style="display: none"></asp:Label>
                 <asp:Label ID="WMJpackperclblnc2" runat="server" Text=""  Style="display: none"></asp:Label>
        <asp:Label ID="WMJpackcramtlblnc2" runat="server" Text=""  Style="display: none"></asp:Label>
        <asp:Label ID="WMJpackpremlblnc3" runat="server" Text=""  Style="display: none"></asp:Label>
                 <asp:Label ID="WMJpackperclblnc3" runat="server" Text=""  Style="display: none"></asp:Label>
        <asp:Label ID="WMJpackcramtlblnc3" runat="server" Text=""  Style="display: none"></asp:Label>                                  
              <asp:Label ID="mhvaluechanged" runat="server" Text=""  Style="display: none"></asp:Label> 
              <asp:Label ID="lapselbl" runat="server" Text=""  Style="display: none"></asp:Label>      
               <asp:Label ID="citylbl" runat="server" Text=""  Style="display: none"></asp:Label>  
               <asp:Label ID="lblsmokecreditwmj" runat="server" Text=""  Style="display: none"></asp:Label>    
               <asp:Label ID="lblsmokeprecwmj" runat="server" Text=""  Style="display: none"></asp:Label>    
                <asp:Label ID="lbleffdate" runat="server" Text=""  Style="display: none"></asp:Label>   
                 <asp:Label ID="aegispackvintpremlbl" runat="server" Text=""  Style="display: none"></asp:Label> 
    <!--General Finance Popup-->
    <dx:ASPxPopupControl ID="PremiumFinancingPopup" ClientInstanceName="PremiumFinancingPopup"
    PopupHorizontalAlign="WindowCenter" PopupVerticalAlign="WindowCenter"
    MaxWidth="800px" MaxHeight="1800px" MinHeight="150px" MinWidth="150px" ShowFooter="false" Width="550px" Height="330px"
    runat="server" Modal="true" HeaderText="Premium Finance">
    <ContentCollection>
     <dx:PopupControlContentControl ID="PremiumFinancingPopupContentControl" runat="server">
                    <div>
 <table>
                            <tbody>
                                <tr>
                                    <td>
                                        <table>
                                            <tbody>
                                            <tr>
                                                    <td>
                                                        <asp:Label ID="Label166" runat="server" Text="Financing Company: " Font-Bold="True"></asp:Label>
                                                        </td></tr>
                                                        <tr><td>
                                                        <asp:Label ID="lblGeneralFinanceType" runat="server" Text="" Font-Bold="false"></asp:Label>
                                                    </td>
                                                    </tr>
                                                <tr>
                                                    <td>
                                                        <asp:Label ID="Label162" runat="server" Text="Payment Plan:" Font-Bold="True"></asp:Label>
                                                    </td>
                                                </tr>
                                                <tr>
                                                    <td>
                                                        <dx:ASPxRadioButtonList ID="PremiumFinanceDP" runat="Server" ClientInstanceName="PremiumFinanceDP">
                                                        <Items>
                                                        <dx:ListEditItem Value="25% Down" />
                                                        <dx:ListEditItem Value="40% Down" />
                                                        <dx:ListEditItem Value="50% Down" />
                                                        </Items>
                                                        <ClientSideEvents ValueChanged="function(s,e){PremiumFinancingPopup.PerformCallback();}" />
                                                        </dx:ASPxRadioButtonList>
                                                        
                                                    </td>
                                                    <td>
                                                    </td>
                                                    <td>
                                                    </td>
                                                    <td>
                                                    </td>
                                                    <td>
                                                    </td>
                                                    <td>
                                                    <dx:ASPxRadioButtonList ID="PremiumFinanceLen" runat="Server" ClientInstanceName="PremiumFinanceLen">
                                                        <Items>
                                                        <dx:ListEditItem Value="3 Months" />
                                                        <dx:ListEditItem Value="6 Months" />
                                                        <dx:ListEditItem Value="8 Months" />
                                                        </Items>
                                                        <ClientSideEvents ValueChanged="function(s,e){PremiumFinancingPopup.PerformCallback();}" />
                                                        </dx:ASPxRadioButtonList>
                                                        
                                                    </td>
                                                    <td>
                                                    </td>
                                                    <td>
                                                    </td>
                                                    <td>
                                                    </td>
                                                    <td>
                                                    </td>
                                                </tr>
                                            </tbody>
                                        </table>
                                    </td>
                                    <td>
                                        <table>
                                            <tbody>
                                                <tr>
                                                    <td>
                                                        <asp:Label ID="Label164" runat="server" Text="Annual Premium: " CssClass="AR_Application"></asp:Label>&nbsp;
                                                    </td>
                                                    <td align="right">
                                                        <asp:Label ID="lblGeneralPremium" runat="server" Casing="Normal" CssClass="AR_Application"/>
                                                    </td>
                                                </tr>
                                                <tr>
                                                    <td>
                                                        <asp:Label ID="Label173" runat="server" Text="Down Payment: " CssClass="AR_Application"></asp:Label>
                                                    </td>
                                                    <td align="right">
                                                        <asp:Label ID="lblGeneralDownPayment" runat="server" Casing="Normal" CssClass="AR_Application"/>
                                                    </td>
                                                </tr>
                                                <tr>
                                                    <td>
                                                        <asp:Label ID="Label184" runat="server" Text="Amount Financed: " CssClass="AR_Application"></asp:Label>
                                                    </td>
                                                    <td align="right">
                                                        <asp:Label ID="lblGeneralAmountFinanced" runat="server" Casing="Normal" CssClass="AR_Application"/>
                                                    </td>
                                                </tr>
                                                <tr>
                                                    <td>
                                                        <asp:Label ID="Label186" runat="server" Text="Finance Charge: " CssClass="AR_Application"></asp:Label>
                                                    </td>
                                                    <td align="right">
                                                        <asp:Label ID="lblGeneralFinanceCharge" runat="server" Casing="Normal" CssClass="AR_Application"/>
                                                    </td>
                                                </tr>
                                                <tr>
                                                    <td>
                                                        <asp:Label ID="Label188" runat="server" Text="Total of Payments: " CssClass="AR_Application"></asp:Label>
                                                    </td>
                                                    <td align="right">
                                                        <asp:Label ID="lblGeneralTotalOfPayments" runat="server" CssClass="AR_Application"></asp:Label>
                                                    </td>
                                                </tr>
                                                <tr>
                                                    <td>
                                                        <asp:Label ID="Label190" runat="server" Text="Monthly Payment: " CssClass="AR_Application"></asp:Label>
                                                    </td>
                                                    <td align="right">
                                                        <asp:Label ID="lblGeneralMonthlyPayment" runat="server" CssClass="AR_Application"></asp:Label>
                                                    </td>
                                                </tr>
                                                <tr>
                                                    <td>
                                                        <asp:Label ID="Label192" runat="server" Text="Annual % Rate:" CssClass="AR_Application"></asp:Label>
                                                    </td>
                                                    <td align="right">
                                                        <asp:Label ID="lblGeneralAPR" runat="server" DataFieldName="AnnualRate" CssClass="AR_Application"></asp:Label>
                                                    </td>
                                                </tr>
                                            </tbody>
                                        </table>
                                    </td>
                                </tr>
                            </tbody>
                        </table>
                    </div>
                <%--<dx:ASPxButton ID="premiumFinanceCalcBtn" runat="server" Text="Calculate New">
                    <ClientSideEvents Click="function(s,e){ PremiumFinancingPopup.PerformCallback();}" />
                </dx:ASPxButton>--%>
           
           
                        
            </dx:PopupControlContentControl>
    </ContentCollection>
    </dx:ASPxPopupControl>
    <!--General Finance Popup-->
