﻿<%@ Control Language="vb" AutoEventWireup="false" CodeBehind="Lloyds.ascx.vb" Inherits="MobileHomeRater.Lloyds" %>
<%@ Register Assembly="DevExpress.Web.v13.1, Version=13.1.8.0, Culture=neutral, PublicKeyToken=b88d1754d700e49a"
    Namespace="DevExpress.Web.ASPxGridView" TagPrefix="dx" %>
<%@ Register assembly="DevExpress.Web.v13.1, Version=13.1.8.0, Culture=neutral, PublicKeyToken=b88d1754d700e49a" namespace="DevExpress.Web.ASPxPopupControl" tagprefix="dx" %>
<%@ Register assembly="DevExpress.Web.v13.1, Version=13.1.8.0, Culture=neutral, PublicKeyToken=b88d1754d700e49a" namespace="DevExpress.Web.ASPxEditors" tagprefix="dx" %>
<%@ Register assembly="DevExpress.Web.v13.1, Version=13.1.8.0, Culture=neutral, PublicKeyToken=b88d1754d700e49a" namespace="DevExpress.Web.ASPxPanel" tagprefix="dx" %>
<script type="text/javascript">
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
                    document.getElementById('<%= aiges_mh_prog3_Options.ClientID %>').style.display = '';
                    document.getElementById('<%= Table2.ClientID %>').style.display = '';
                    document.getElementById('lblaiges_ShowOptions3').innerText = "- Show Options";
                    document.getElementById('<%= lblaiges_ShowOptions3_hidden.ClientID %>').value = '- Show Options';
                }
                else {

                    document.getElementById('<%= aiges_mh_prog3_Options.ClientID %>').style.display = 'none';
                    document.getElementById('<%= Table2.ClientID %>').style.display = 'none';
                    document.getElementById('lblaiges_ShowOptions3').innerText = "+ Show Options";
                    document.getElementById('<%= lblaiges_ShowOptions3_hidden.ClientID %>').value = '+ Show Options';
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
                                               <%-- <td>
                                                    <asp:Button ID="premFinbtn" runat="server" OnClick="printFinbtn_Click" Text="Print Finance Contract" />
                                                </td>--%>
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
                                                <td align="center">
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
                                                <td align="center" style="border: 1px solid">
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
                                                <td align="center" style="border: 1px solid">
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
                                                <td align="center" style="border: 1px solid">
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
                                                <td align="center" style="border: 1px solid">
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
                                                                    &nbsp;
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
                                                <td align="center" style="border: 1px solid">
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
                                                                        <asp:ListItem>$500</asp:ListItem>
                                                                       <asp:ListItem>$1000</asp:ListItem>
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
                                                                        Casing="UPPER" ToolTip="Unattached Structure" Width="65" TabIndex="117" Enabled="false"/>
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
                                                                                                  <Columns>
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
                                                <td align="center" style="border: 1px solid">
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
                                            <tr id="aiges_mh_prog3_Options" runat="server" clientidmode="Static">
                                                <td colspan="13">
                                                    <table id="Table2" runat="server" width="auto" cellpadding="0" cellspacing="0"
                                                        clientidmode="Static" bgcolor="white" title="Lloyd Options">
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
                                                                    <asp:TextBox ID="TextBox1" runat="server" Text="1500" 
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
                                                                        Casing="UPPER" ToolTip="Unattached Structure" Width="65" TabIndex="128" />
                                                                        &nbsp;<asp:Label ID="txt_unattstr_aiges2_Amount" runat="server" Text="0.00" CssClass="label" />
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
                                            <tr id="AR_Ineligible" style="border: 1px solid black; display: none">
                                                <td align="center" style="border: 1px solid" colspan="12">
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
       <%-- <asp:Panel ID="PremiumCalcPanel" runat="server" CssClass="modalPopup" Width="100%" ViewStateMode="Disabled">
       
           <div style="padding: 5px">
                <div style="font-size: 10pt">
                    Premium Calculation Confirmation
                    <br />
                    <asp:Label ID="AR1_Debug" runat="server" ClientIDMode="static" Style="display: none"
                        text=""></asp:Label>
                    <asp:Label ID="AR2_Debugold" runat="server" ClientIDMode="Static" Style="display: none"
                        Text=""></asp:Label>
                    <asp:Label ID="AR3_Debugold" runat="server" ClientIDMode="Static" Style="display: none"
                        Text=""></asp:Label>
                    <br />
                    <asp:LinkButton ID="btnCloseCalc" runat="server" Text="Close" Font-Size="Medium" />
                    <%--<table width="auto" cellpadding="0" cellspacing="0" bgcolor="white">
                    <tbody>
                    <tr>
                        <td align="left">
                            <asp:Label ID="AR1_Debug" runat="server" ClientIDMode="Static" Text=""></asp:Label>
                        </td>
                         
                        <td align="left">
                            <asp:Label ID="AR2_Debug" runat="server" ClientIDMode="Static" Text=""></asp:Label>
                        </td>
                    </tr>
                    <tr>
                        <td>
                             <asp:LinkButton ID="btnCloseCalc" runat="server" Text="Close" Font-Size="Medium" />
                        </td>
                    </tr>
                    </tbody>
                    </table>--%>
                </div>
            </div>

            
                </asp:Panel>    
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
                 <asp:Label ID="lblskirt" runat="server" Text=""  Style="display: none"></asp:Label>