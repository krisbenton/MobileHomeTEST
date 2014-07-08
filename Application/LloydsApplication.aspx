﻿<%@ Page Language="vb" Title="TCG Mobile Home Rater" AutoEventWireup="false" CodeBehind="LloydsApplication.aspx.vb"
    Inherits="MobileHomeRater.LloydsApplication" MasterPageFile="../IntPage.Master" %>

<%@ Register Assembly="DevExpress.Web.v13.1, Version=13.1.8.0, Culture=neutral, PublicKeyToken=b88d1754d700e49a"
    Namespace="DevExpress.Web.ASPxCallback" TagPrefix="dx" %>

<%@ Register Assembly="DevExpress.Web.v13.1, Version=13.1.8.0, Culture=neutral, PublicKeyToken=b88d1754d700e49a"
    Namespace="DevExpress.Web.ASPxCallbackPanel" TagPrefix="dx" %>

<%@ Register Assembly="DevExpress.Web.v13.1, Version=13.1.8.0, Culture=neutral, PublicKeyToken=b88d1754d700e49a"
    Namespace="DevExpress.Web.ASPxLoadingPanel" TagPrefix="dx" %>

<%@ Register Assembly="DevExpress.Web.v13.1, Version=13.1.8.0, Culture=neutral, PublicKeyToken=b88d1754d700e49a"
    Namespace="DevExpress.Web.ASPxEditors" TagPrefix="dx" %>
<%@ Register Assembly="DevExpress.Web.v13.1, Version=13.1.8.0, Culture=neutral, PublicKeyToken=b88d1754d700e49a"
    Namespace="DevExpress.Web.ASPxPopupControl" TagPrefix="dx" %>
<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolderMenu" runat="server">
    <script type="text/javascript">
        //Check Fiance Option
//        function PremFinanceCheck() {
//            
//                        //if (currentText = document.getElementById('<%=txtDiffAppState.ClientID%>').value == "SC")
//            try {
//                
//                if (txtDiffAppState.GetValue() == 'SC') {

//                    var e = document.getElementById('<%=ddPaymentOpt.ClientID%>');
//                    var FinanceOption = e.options[e.selectedIndex].text;
//                    if (FinanceOption == "Premium Finance" && document.getElementById('<%=lblProgram.ClientID%>').innerText.toUpperCase().indexOf('AEG') < 0) {
//                        document.getElementById('FinanceDetails').style.display = '';

//                    }
//                    else {
//                        document.getElementById('FinanceDetails').style.display = 'none';
//                        if (FinanceOption == "Premium Finance" && document.getElementById('<%=lblProgram.ClientID%>').innerText.toUpperCase().indexOf('AEG') >= 0) {
//                            alert('Premium Financing not available for selected program.');
//                            e.selectedIndex=0;
//                        }

//                    }
//                }
//            }
//            catch (err) {
//                if (document.getElementById('<%=txtState.ClientID%>').value == "SC" && document.getElementById('<%=lblProgram.ClientID%>').innerText.toUpperCase().indexOf('AEG') < 0) {

//                    var e = document.getElementById('<%=ddPaymentOpt.ClientID%>');
//                    var FinanceOption = e.options[e.selectedIndex].text;
//                    if (FinanceOption == "Premium Finance") {
//                        document.getElementById('FinanceDetails').style.display = '';

//                    }
//                    else {
//                        document.getElementById('FinanceDetails').style.display = 'none';
//                        if (FinanceOption == "Premium Finance" && document.getElementById('<%=lblProgram.ClientID%>').innerText.toUpperCase().indexOf('AEG') >= 0) {
//                            alert('Premium Financing not available for selected program.');
//                            e.selectedIndex = 0;
//                        }
//                    }
//                }
//                

//                
//            }
//


        //        }


        function PremFinanceCheck() {
            try {

                if (txtDiffAppState.GetValue() == 'SC' || txtDiffAppState.GetValue() == 'NC' || txtDiffAppState.GetValue() == 'VA' || txtDiffAppState.GetValue() == 'GA') {

                    var e = document.getElementById('<%=ddPaymentOpt.ClientID%>');
                    var FinanceOption = e.options[e.selectedIndex].text;
                    if (FinanceOption == "Premium Finance" && document.getElementById('<%=lblProgram.ClientID%>').innerText.toUpperCase().indexOf('AEG') < 0) {
                        document.getElementById('FinanceDetails').style.display = '';

                    }
                    else {
                        document.getElementById('FinanceDetails').style.display = 'none';
                        if (FinanceOption == "Premium Finance" && document.getElementById('<%=lblProgram.ClientID%>').innerText.toUpperCase().indexOf('AEG') >= 0) {
                            alert('Premium Financing not available for selected program.');
                            e.selectedIndex = 0;
                        }

                    }
                }
                if (txtDiffAppState.GetValue() == 'DE') {
                    var e = document.getElementById('<%=ddPaymentOpt.ClientID%>');
                    var FinanceOption = e.options[e.selectedIndex].text;
                    if (FinanceOption == "Premium Finance" && document.getElementById('<%=lblProgram.ClientID%>').innerText.toUpperCase().indexOf('AEG') < 0) {
                        //show prime rate finance option
                        document.getElementById('PrimeRateFinanceDetails').style.display = '';

                    } //end if
                    else {
                        //hide prime rate finance options 
                        document.getElementById('PrimeRateFinanceDetails').style.display = 'none';
                    }

                }
            }
            catch (err) {
                if ((document.getElementById('<%=txtState.ClientID%>').value == "SC" || document.getElementById('<%=txtState.ClientID%>').value == "NC" || document.getElementById('<%=txtState.ClientID%>').value == "VA" || document.getElementById('<%=txtState.ClientID%>').value == "GA") && document.getElementById('<%=lblProgram.ClientID%>').innerText.toUpperCase().indexOf('AEG') < 0) {

                    var e = document.getElementById('<%=ddPaymentOpt.ClientID%>');
                    var FinanceOption = e.options[e.selectedIndex].text;
                    if (FinanceOption == "Premium Finance") {
                        document.getElementById('FinanceDetails').style.display = '';

                    }
                    else {
                        document.getElementById('FinanceDetails').style.display = 'none';
                        if (FinanceOption == "Premium Finance" && document.getElementById('<%=lblProgram.ClientID%>').innerText.toUpperCase().indexOf('AEG') >= 0) {
                            alert('Premium Financing not available for selected program.');
                            e.selectedIndex = 0;
                        }
                    }
                }



            }
        }




        function ShowAllFinance() {
            document.getElementById('FinanceDetails').style.display = '';

        }
        //Premium Finance Changed
        function FinanceOptionChange() {

            document.getElementById('<%=financebtn2.ClientID%>').click();

        }
        //Prime Rate Finance Changed
        function PrimeRateFinanceOptionChange() {

            document.getElementById('<%=PrimeRateFinanceBtn.ClientID%>').click();

        }
        //Check Eligiblity
        function CheckEligiblity(controlName) {

            var e = document.getElementById(controlName);
            var parkStatus = e.options[e.selectedIndex].text;



            if (parkStatus == "Yes") {
                alert('Risk is Ineligible');
                document.getElementById('<%= AppStatuslbl.ClientID %>').innerText = "Ineligible";
                document.getElementById('<%= AppStatuslbl.ClientID %>').style.color = "Red";
                document.getElementById('<%= printBtn.ClientID %>').style.display = "none";


            }
            else {
                document.getElementById('<%= AppStatuslbl.ClientID %>').innerText = "Eligible";
                document.getElementById('<%= AppStatuslbl.ClientID %>').style.color = "Green";
                document.getElementById('<%= printBtn.ClientID %>').style.display = "";
            }
            document.getElementById('<%=btnvalidate.ClientID%>').click();
        } //End CheckEligiblity
        function CheckEligiblity2(controlName) {

            var e = document.getElementById(controlName);
            var parkStatus = e.options[e.selectedIndex].text;



            if (parkStatus == "Yes") {
                alert('Application Must be submitted to UW');
                document.getElementById('<%= AppStatuslbl.ClientID %>').innerText = "Must Submit to UW";
                document.getElementById('<%= AppStatuslbl.ClientID %>').style.color = "Red";
                document.getElementById('<%= printBtn.ClientID %>').style.display = "none";


            }
            else {
                document.getElementById('<%= AppStatuslbl.ClientID %>').innerText = "Eligible";
                document.getElementById('<%= AppStatuslbl.ClientID %>').style.color = "Green";
                document.getElementById('<%= printBtn.ClientID %>').style.display = "";
            }
            document.getElementById('<%=btnvalidate.ClientID%>').click();
        } //End CheckEligiblity
        function CheckEligiblity3(controlName) {

            var e = document.getElementById(controlName);
            var parkStatus = e.options[e.selectedIndex].text;



            if (parkStatus == "No") {
                alert('Risk is Ineligible');
                document.getElementById('<%= AppStatuslbl.ClientID %>').innerText = "Ineligible";
                document.getElementById('<%= AppStatuslbl.ClientID %>').style.color = "Red";
                document.getElementById('<%= printBtn.ClientID %>').style.display = "none";


            }
            else {
                document.getElementById('<%= AppStatuslbl.ClientID %>').innerText = "Eligible";
                document.getElementById('<%= AppStatuslbl.ClientID %>').style.color = "Green";
                document.getElementById('<%= printBtn.ClientID %>').style.display = "";
            }
            document.getElementById('<%=btnvalidate.ClientID%>').click();
        }
        function CheckEligiblity4(controlName) {

            var e = document.getElementById(controlName);
            var parkStatus = e.options[e.selectedIndex].text;



            if (parkStatus == "No") {
                alert('Submit to UW');
                document.getElementById('<%= AppStatuslbl.ClientID %>').innerText = "Ineligible";
                document.getElementById('<%= AppStatuslbl.ClientID %>').style.color = "Red";
                document.getElementById('<%= printBtn.ClientID %>').style.display = "none";


            }
            else {
                document.getElementById('<%= AppStatuslbl.ClientID %>').innerText = "Eligible";
                document.getElementById('<%= AppStatuslbl.ClientID %>').style.color = "Green";
                document.getElementById('<%= printBtn.ClientID %>').style.display = "";
            }
            document.getElementById('<%=btnvalidate.ClientID%>').click();
        } //End CheckEligiblity
        //Add Additional Insured


        //General Informaiton Rules
        function PriorIns2(s, e) {

            document.getElementById('<%=btnprior.ClientID%>').click();

        }
        function PriorIns() {
            var e = document.getElementById('<%=ddPriorInsurance.ClientID%>');
            var parkStatus = e.options[e.selectedIndex].text;
            if (parkStatus == "Yes") {
                document.getElementById('priorInsurance').style.display = '';
            }
            else {
                document.getElementById('priorInsurance').style.display = 'none';

            }
        } // End PriorIns


        //Redirect sections
        function redirect() {
            window.location.href = "/Quote/quote.aspx";
        }
        function redirect2() {
            window.location.href = "/Quote/findQuote.aspx";
        }
        function redirect3() {
            window.location.href = "/Quote/findImportQuote.aspx";
        }


        function UpdateDOB() {

            var currentText;
            currentText = document.getElementById('<%=txtDOB.ClientID%>').value;

            if (currentText.length == 7) {

                document.getElementById('<%=txtDOB.ClientID%>').value = currentText.substring(0, 2) + '/' + currentText.substring(2, 4) + '/' + currentText.substring(4, 8);

            } //end if
        }

        //location address
        function zipcodeKeyDown() {
            if (document.getElementById('<%=txtDiffAppZip.ClientID%>').value.length == 5) {
                document.getElementById('<%=txtDiffAppZip.ClientID%>').value = document.getElementById('<%=txtDiffAppZip.ClientID%>').value;
                document.getElementById('<%=zipbtn1.ClientID%>').click();
            }
            document.getElementById('<%=txtDiffAppZip.ClientID%>').value = document.getElementById('<%=txtDiffAppZip.ClientID%>').value;
        }
        //mailing address
        function zipcodeKeyDown1() {
            if (document.getElementById('<%=txtZip.ClientID%>').value.length == 5) {
                document.getElementById('<%=txtZip.ClientID%>').value = document.getElementById('<%=txtZip.ClientID%>').value;
                document.getElementById('<%=zipbtn2.ClientID%>').click();
            }
            document.getElementById('<%=txtZip.ClientID%>').value = document.getElementById('<%=txtZip.ClientID%>').value;
        }

        function zipcodeKeyDown3() {
            if (document.getElementById('<%=txtLien1Zip.ClientID%>').value.length == 5) {
                document.getElementById('<%=txtLien1Zip.ClientID%>').value = document.getElementById('<%=txtLien1Zip.ClientID%>').value;
                document.getElementById('<%=lienzip1.ClientID%>').click();
            }
            document.getElementById('<%=txtLien1Zip.ClientID%>').value = document.getElementById('<%=txtLien1Zip.ClientID%>').value;
        }
        function zipcodeKeyDown4() {
            if (document.getElementById('<%=txtLien2Zip.ClientID%>').value.length == 5) {
                document.getElementById('<%=txtLien2Zip.ClientID%>').value = document.getElementById('<%=txtLien2Zip.ClientID%>').value;
                document.getElementById('<%=lienzip2.ClientID%>').click();
            }
            document.getElementById('<%=txtLien2Zip.ClientID%>').value = document.getElementById('<%=txtLien2Zip.ClientID%>').value;
        }
        function ValidateCheck(s) {
        //commented out per vickie
            //var test = s.uniqueID.toString();
           // var splitted = test.split("$")[2];
           // document.getElementById('<%=lblfocus.ClientID%>').value = splitted;
           // document.getElementById('<%=btnvalidate.ClientID%>').click();
           // alert(test);
            
            //alert(splitted);
           // s.focus()
           // var mytext = document.getElementById(splitted);
            // mytext.focus(); 
          
//            if (splitted == "dd_ARIng2") {
//                document.getElementById('<%=dd_ARIng2.ClientID%>').focus();
//            }
            //alert(splitted); 
        }
    </script>
    <!--Menu Bar-->
    <table cellpadding="0" cellspacing="0">
        <tr align="left">
            <td>
                <button style="-webkit-appearance: none; top: 0px; left: 0px; width: 100px; height: 30px;
                    border: 1px solid #808080;" onclick="redirect(); return false;">
                    New Quote
                </button>
                <asp:Button ID="savebtn" runat="server" OnClick="savebtn_Click" Style="-webkit-appearance: none;
                    top: 0px; left: -15px; width: 100px; height: 30px; border: 1px solid #808080;"
                    Text="Save" />
                <button style="-webkit-appearance: none; top: 0px; left: -15px; width: 100px; height: 30px;
                    border: 1px solid #808080;" onclick="redirect2(); return false;">
                    Find Quote
                </button>
                <%-- <button  style="-webkit-appearance: none; top: 0px; left: -15px; width: 150px; height: 30px;
                    border: 1px solid #808080;" onclick="redirect3(); return false;">
                    Find Imported Quote
                </button>--%>
                <asp:Button ID="findimport" runat="server" Style="top: 0px; left: -15px; width: 150px;
                    height: 30px; border: 1px solid #808080;" Text="Find Imported Quote" />
                <asp:Button ID="backquote" runat="server" OnClick="backtoquote" Style="-webkit-appearance: none;
                    top: 0px; left: -15px; width: 100px; height: 30px; border: 1px solid #808080;"
                    Text="Back to Quote" CausesValidation="false" />
                <asp:Button ID="btnLogout" runat="server" Style="top: 0px; left: -15px; width: 100px;
                    height: 30px; border: 1px solid #808080;" Text="Logout" OnClick="btnLogout_Click"
                    CausesValidation="true" />
            </td>
        </tr>
    </table>
    <!--Menu Bar-->
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <ajaxTK:ToolkitScriptManager ID="sc2" runat="server" EnablePartialRendering="true">
    </ajaxTK:ToolkitScriptManager>
    <asp:HiddenField ID="hidfield" runat="server" />
    <%--<table align="left" style="height: 225px; width: 100%" bgcolor="white" title="Header Table">
        <tbody>
            <tr align="left">
                <td>
                    <asp:Label ID="Label1" runat="server" Style="font-family: Tahoma; font-size: 25pt;
                        text-align: left; width: auto;" Text="American Reliable <br/> Insurance Company"></asp:Label>
                    <br />
                    <asp:Label ID="Label2" runat="server" Style="font-family: Tahoma; font-size: 15pt;
                        text-align: left; width: auto;" Text="Mobile Home Application"></asp:Label>
                </td>
                <td align="right">
                    <asp:Label ID="Label3" runat="server" Style="font-family: Tahoma; font-weight: bold;
                        font-size: 15pt; text-align: left; width: auto;" Text="BROKERING AGENT’S REGISTER NO."></asp:Label>
                    <asp:Label ID="brokReg" runat="server" Text="_________"></asp:Label>
                    <br />
                    <asp:Label ID="Label4" runat="server" Style="text-align: left; font-family: Tahoma;
                        font-weight: bold; font-size: 15pt; text-align: left; width: auto;" Text="BROKERING AGENT’S APPLICATION"></asp:Label>
                </td>
            </tr>
            <tr>
                <td>
                </td>
            </tr>
        </tbody>
    </table>--%>
    <hr />
    <table border="5" width="100%" bordercolor="Black" style="background-color: White">
        <tr border="5">
            <td>
                <asp:Label ID="Label2" runat="server" Text="Quote #" Font-Size="Large"></asp:Label>
            </td>
            <td>
                <asp:Label ID="Label3" runat="server" Text="Program" Font-Size="Large"></asp:Label>
            </td>
            <td>
                <asp:Label ID="Label4" runat="server" Text="Carrier" Font-Size="Large"></asp:Label>
            </td>
            <td>
                <asp:Label ID="Label18" runat="server" Text="Term" Font-Size="Large"></asp:Label>
            </td>
            <td>
                <asp:Label ID="Label25" runat="server" Text="Effective Dates" Font-Size="Large"></asp:Label>
            </td>
        </tr>
        <tr border="5">
            <td>
                <asp:Label ID="lblQuoteNumber" runat="server" Text="Quote #" Font-Size="Large"></asp:Label>
            </td>
            <td>
                <asp:Label ID="lblProgram" runat="server" Text="Program" Font-Size="Large"></asp:Label>
            </td>
            <td>
                <asp:Label ID="lblCarrier" runat="server" Text="Carrier" Font-Size="Large"></asp:Label>
            </td>
            <td>
                <asp:Label ID="lblTerm" runat="server" Text="Term" Font-Size="Large"></asp:Label>
            </td>
            <td>
                <asp:Label ID="lblEffDates" runat="server" Text="Effective Dates" Font-Size="Large"></asp:Label>
            </td>
        </tr>
    </table>
    <table align="left" style="width: 100%; border: 1" bgcolor="white" title="">
        <tbody>
            <tr style="border: 1px Black solid;">
                <td align="left">
                    <table align="left" style="width: 40%; border: 1" bgcolor="white" title="Applicant
                    Information">
                        <tbody>
                            <%-- <tr style="border-bottom: 1px; border-bottom-color: Black">
                                <td colspan="2" align="left">
                                   <asp:Label ID="lblPackage" runat="server" Text="" CssClass="AR_Application"  style="font-size: x-large; font-weight: 700; color: Green"></asp:Label>
                                  </td>
                           </tr>--%>
                            <tr style="border-bottom: 1px; border-bottom-color: Black">
                                <td colspan="2" align="left">
                                    <span class="style3">Applicant Information</span>
                                    <asp:TextBox ID="txtAppNumber" runat="server" Text="NULL" Style="display: none"></asp:TextBox>
                                    <asp:TextBox ID="txtQuoteID" runat="server" Text="NULL" Style="display: none"></asp:TextBox>
                                </td>
                                <hr />
                            </tr>
                            <tr align="left" style="border: 1px solid">
                                <td align="right">
                                    <asp:Label ID="Label5" runat="server" Text="Name:" CssClass="AR_Application"></asp:Label>
                                </td>
                                <td>
                                    <dx:ASPxTextBox ID="txtName" runat="server" Width="200px" CssFilePath="../Styles/Site.css"
                                        TabIndex="1">
                                        <ValidationSettings>
                                            <RequiredField IsRequired="True" ErrorText="Name is required" />
                                            <RegularExpression ValidationExpression=".{4,}" ErrorText="Name should contain at least four letters" />
                                        </ValidationSettings>
                                    </dx:ASPxTextBox>
                                    <%--  <asp:TextBox style="text-transform:uppercase"  ID="txtName" runat="server" 
                                        Text="" TabIndex="1"></asp:TextBox >
                                    <asp:RequiredFieldValidator ID="RequiredFieldValidator11" ControlToValidate="txtname"
                                            runat="server" Text="* Req Field"></asp:RequiredFieldValidator>--%>
                                </td>
                                <td align="right">
                                    <asp:Label ID="Label6" runat="server" Text="DOB:" CssClass="AR_Application"></asp:Label>
                                </td>
                                <td>
                                    <dx:ASPxTextBox ID="txtDOB" runat="server" Width="200px" CssFilePath="../Styles/Site.css"
                                        TabIndex="2">
                                        <ValidationSettings>
                                            <RequiredField IsRequired="True" ErrorText="DOB is required" />
                                            <RegularExpression ValidationExpression="^((((0[13578])|(1[02]))[\/]?(([0-2][0-9])|(3[01])))|(((0[469])|(11))[\/]?(([0-2][0-9])|(30)))|(02[\/]?[0-2][0-9]))[\/]?\d{4}$"
                                                ErrorText="DOB is Wrong Format" />
                                        </ValidationSettings>
                                    </dx:ASPxTextBox>
                                    <%--  <asp:TextBox ID="txtDOB" runat="server" Text="" TabIndex="2"></asp:TextBox>
                                    <asp:RequiredFieldValidator ID="RequiredFieldValidator1" ControlToValidate="txtDOB"
                                            runat="server" Text="* Req Field"></asp:RequiredFieldValidator>--%>
                                </td>
                            </tr>
                            <tr>
                                <td align="right">
                                    <asp:Label ID="Label12" runat="server" Text="Phone No:" CssClass="AR_Application"></asp:Label>
                                </td>
                                <td>
                                    <dx:ASPxTextBox ID="txtPhone2" runat="server" Width="130" TabIndex="3">
                                        <MaskSettings Mask="(999) 000-0000" IncludeLiterals="None" />
                                        <ValidationSettings SetFocusOnError="false" ErrorDisplayMode="Text">
                                            <RequiredField IsRequired="True" ErrorText="Phone Number Required" />
                                        </ValidationSettings>
                                    </dx:ASPxTextBox>
                                </td>
                                <td align="right">
                                    <asp:Label ID="Label13" runat="server" Text="Occupation:" CssClass="AR_Application"></asp:Label>
                                </td>
                                <td>
                                    <dx:ASPxTextBox ID="txtOcc" runat="server" Width="200px" CssFilePath="../Styles/Site.css"
                                        TabIndex="4">
                                        <ValidationSettings>
                                            <RequiredField IsRequired="True" ErrorText="Occupation is required" />
                                            <RegularExpression ValidationExpression=".{2,}" ErrorText="Occupation should contain at least two letters" />
                                        </ValidationSettings>
                                    </dx:ASPxTextBox>
                                    <%--<asp:TextBox ID="txtOcc" runat="server" Text="" 
                                        style="text-transform:uppercase" TabIndex="4"></asp:TextBox>
                                    <asp:RequiredFieldValidator ID="RequiredFieldValidator3" ControlToValidate="txtOcc"
                                            runat="server" Text="* Req Field"></asp:RequiredFieldValidator>--%>
                                </td>
                                <td align="right">
                                    <asp:Label ID="Label14" runat="server" Text="Social Security#:" CssClass="AR_Application"></asp:Label>
                                </td>
                                <td>
                                    <dx:ASPxTextBox ID="txtSSN2" runat="server" Width="130" TabIndex="5">
                                        <ValidationSettings SetFocusOnError="true">
                                            <RequiredField IsRequired="True" ErrorText="Social Security Is Required" />
                                            <RegularExpression ValidationExpression="^((\d{3}-?\d{2}-?\d{4})|(X{3}-?X{2}-?X{4}))$"
                                                ErrorText="Social Security Format" />
                                        </ValidationSettings>
                                        <MaskSettings Mask="999-99-9999" IncludeLiterals="None" />
                                    </dx:ASPxTextBox>
                                </td>
                            </tr>
                            <tr>
                                <td align="right">
                                    <asp:Label ID="Label15" runat="server" Text="Co-Applicant Name:" CssClass="AR_Application"></asp:Label>
                                </td>
                                <td>
                                    <asp:TextBox Style="text-transform: uppercase" ID="txtSpouseName" runat="server"
                                        Text="" TabIndex="6"></asp:TextBox>
                                </td>
                                <td align="right">
                                    <asp:Label ID="Label16" runat="server" Text="Co-Applicant SSN:" CssClass="AR_Application"></asp:Label>
                                </td>
                                <td>
                                    <dx:ASPxTextBox ID="txtSpouseSSN" runat="server" Width="130" TabIndex="7">
                                        <MaskSettings Mask="000-00-0000" IncludeLiterals="None" />
                                    </dx:ASPxTextBox>
                                </td>
                                <td align="right">
                                    <asp:Label ID="Label17" runat="server" Text=" Co-Applicant DOB:" CssClass="AR_Application"></asp:Label>
                                </td>
                                <td>
                                    <dx:ASPxTextBox ID="txtSpouseDOB" runat="server" Width="130" TabIndex="8">
                                        <MaskSettings Mask="00/00/0000" IncludeLiterals="None" />
                                    </dx:ASPxTextBox>
                                </td>
                            </tr>
                            <tr>
                                <td align="right">
                                    <asp:Label ID="Label35" runat="server" Text="Agent Name:" CssClass="AR_Application"></asp:Label>
                                </td>
                                <td>
                                    <dx:ASPxTextBox ID="txtAgentName" runat="server" Width="200px" CssFilePath="../Styles/Site.css"
                                        TabIndex="9">
                                        <ValidationSettings>
                                            <RequiredField IsRequired="True" ErrorText="Agent Name is required" />
                                            <RegularExpression ValidationExpression=".{2,}" ErrorText="Agent Name should contain at least two letters" />
                                        </ValidationSettings>
                                    </dx:ASPxTextBox>
                                    <%-- <asp:TextBox style="text-transform:uppercase" ID="txtAgentName" runat="server" 
                                        Text="" TabIndex="9"></asp:TextBox>
                                     <asp:RequiredFieldValidator ID="RequiredFieldValidator6" ControlToValidate="txtAgentName"
                                            runat="server" Text="* Req Field"></asp:RequiredFieldValidator>--%>
                                </td>
                            </tr>
                            <tr>
                                <td align="right">
                                    <asp:Label ID="Label19" runat="server" Text="Park Name:" CssClass="AR_Application"></asp:Label>
                                </td>
                                <td>
                                    <asp:TextBox Style="text-transform: uppercase" ID="txtParkName" runat="server" Text=""
                                        TabIndex="10"></asp:TextBox>
                                </td>
                            </tr>
                            <tr>
                                <td>
                                    <br />
                                </td>
                                <td>
                                    &nbsp;
                                </td>
                            </tr>
                            <tr style="border-bottom: 1px; border-bottom-color: Black">
                                <td colspan="2" align="left">
                                    <span class="style3">Location</span>
                                </td>
                            </tr>
                            <%--<tr>
                                <td colspan="5" align="left">
                                    <asp:Label ID="Label25" runat="server" Text="Address if different than above"></asp:Label>
                                </td>
                            </tr>--%>
                            <tr>
                                <td align="right">
                                    <asp:Label ID="Label20" runat="server" Text="Address:" CssClass="AR_Application"></asp:Label>
                                </td>
                                <td colspan="3">
                                    <dx:ASPxTextBox ID="txtDiffAppAddr" runat="server" CssFilePath="../Styles/Site.css"
                                        TabIndex="11" Width="100%">
                                        <ValidationSettings>
                                            <RequiredField IsRequired="True" ErrorText="Address is required" />
                                            <RegularExpression ValidationExpression=".{4,}" ErrorText="Address should contain at least 4 letters" />
                                        </ValidationSettings>
                                    </dx:ASPxTextBox>
                                    <%--<asp:TextBox style="text-transform:uppercase" ID="txtDiffAppAddr" Width="100%" 
                                        runat="server" Text="" TabIndex="11"></asp:TextBox>--%>
                                </td>
                                <asp:RequiredFieldValidator ID="RequiredFieldValidator7" ControlToValidate="txtDiffAppAddr"
                                    runat="server" Text="* Req Field"></asp:RequiredFieldValidator>
                            </tr>
                            <tr align="left">
                                <td align="right">
                                    <asp:Label ID="Label23" runat="server" Text="Zip:" CssClass="AR_Application"></asp:Label>
                                </td>
                                <td>
                                    <asp:TextBox ID="txtDiffAppZip" runat="server" Width="50px" Text="" TabIndex="12"></asp:TextBox>
                                    <asp:Button ID="zipbtn1" Text="getZip" runat="server" CausesValidation="false" Style="display: none" />
                                </td>
                                <asp:RequiredFieldValidator ID="RequiredFieldValidator10" ControlToValidate="txtdiffAppZip"
                                    runat="server" Text="* Req Field"></asp:RequiredFieldValidator>
                                <td align="right">
                                    <asp:Label ID="Label21" runat="server" Text="City:" CssClass="AR_Application"></asp:Label>
                                </td>
                                <td>
                                    <asp:TextBox Style="text-transform: uppercase" ID="txtDiffAppCity" runat="server"
                                        Text="" TabIndex="13"></asp:TextBox>
                                </td>
                                <asp:RequiredFieldValidator ID="RequiredFieldValidator8" ControlToValidate="txtDiffAppCity"
                                    runat="server" Text="* Req Field"></asp:RequiredFieldValidator>
                                <td align="right">
                                    <asp:Label ID="Label22" runat="server" Text="States:" CssClass="AR_Application"></asp:Label>
                                </td>
                                <td>
                                    <dx:ASPxTextBox ID="txtDiffAppState" ClientInstanceName="txtDiffAppState" runat="server" CssFilePath="../Styles/Site.css"
                                        TabIndex="11" Width="100%">
                                        <ValidationSettings>
                                            <RequiredField IsRequired="True" ErrorText="State is required" />
                                            <RegularExpression ValidationExpression=".{2,}" ErrorText="State should contain at least 2 letters" />
                                        </ValidationSettings>
                                    </dx:ASPxTextBox>
                                    <%-- <asp:TextBox style="text-transform:uppercase" ID="txtDiffAppState" runat="server" Width="25px" Text=""></asp:TextBox>
                                     <asp:RequiredFieldValidator ID="RequiredFieldValidator9" ControlToValidate="txtdiffAppState"
                                            runat="server" Text="* Req Field"></asp:RequiredFieldValidator>--%>
                                </td>
                                <td align="right">
                                    <asp:Label ID="Label24" runat="server" Text="County:" CssClass="AR_Application"></asp:Label>
                                </td>
                                <td>
                                    <asp:TextBox Style="text-transform: uppercase" ID="txtDiffAppCounty" runat="server"
                                        Text=""></asp:TextBox>
                                </td>
                                <asp:RequiredFieldValidator ID="RequiredFieldValidator12" ControlToValidate="txtDiffAppCounty"
                                    runat="server" Text="* Req Field"></asp:RequiredFieldValidator>
                            </tr>
                            <tr>
                                <td>
                                </td>
                            </tr>
                            <tr style="border-bottom: 1px; border-bottom-color: Black">
                                <td colspan="2" align="left">
                                    <span class="style3">Mailing Address</span>
                                </td>
                                <td colspan="2">
                                    <asp:CheckBox ID="DupLocation" runat="server" AutoPostBack="true" Text="Mailing Address Same as Location"
                                        OnCheckedChanged="DupLocation_CheckedChanged" TabIndex="11" />
                                </td>
                            </tr>
                            <tr>
                                <td align="right">
                                    <asp:Label ID="Label7" runat="server" Text="Address:" CssClass="AR_Application"></asp:Label>
                                </td>
                                <td colspan="3">
                                    <dx:ASPxTextBox ID="txtAddress" runat="server" CssFilePath="../Styles/Site.css" TabIndex="11"
                                        Width="100%">
                                        <ValidationSettings>
                                            <RequiredField IsRequired="True" ErrorText="Address is required" />
                                            <RegularExpression ValidationExpression=".{4,}" ErrorText="Address should contain at least 4 letters" />
                                        </ValidationSettings>
                                    </dx:ASPxTextBox>
                                    <%--<asp:TextBox style="text-transform:uppercase" ID="txtAddress" Width="100%" 
                                        runat="server" Text="" TabIndex="15"  ></asp:TextBox>--%>
                                </td>
                            </tr>
                            <tr>
                                <td align="right">
                                    <asp:Label ID="Label10" runat="server" Text="Zip:" CssClass="AR_Application"></asp:Label>
                                </td>
                                <td>
                                    <asp:TextBox ID="txtZip" runat="server" Width="50px" Text="" TabIndex="16"></asp:TextBox>
                                    <asp:Button ID="zipbtn2" Text="getZip" runat="server" CausesValidation="false" Style="display: none" />
                                </td>
                                <td align="right">
                                    <asp:Label ID="Label8" runat="server" Text="City:" CssClass="AR_Application"></asp:Label>
                                </td>
                                <td>
                                    <asp:TextBox Style="text-transform: uppercase" ID="txtCity" runat="server" Text=""
                                        TabIndex="17"></asp:TextBox>
                                </td>
                                <td align="right">
                                    <asp:Label ID="Label9" runat="server" Text="State:" CssClass="AR_Application"></asp:Label>
                                </td>
                                <td>
                                    <asp:TextBox Style="text-transform: uppercase" ID="txtState" runat="server" Width="25px"
                                        Text=""></asp:TextBox>
                                </td>
                                <td align="right">
                                    <asp:Label ID="Label11" runat="server" Text="County:" CssClass="AR_Application"></asp:Label>
                                </td>
                                <td>
                                    <asp:TextBox Style="text-transform: uppercase" ID="txtCounty" runat="server" Text=""></asp:TextBox>
                                </td>
                            </tr>
                            <tr>
                                <td colspan="2" align="right">
                                    <asp:Label ID="Label32" runat="server" Text="Distance from Gulf or Atlantic Coastal Water"
                                        CssClass="AR_Application"></asp:Label>
                                </td>
                                <td align="left" colspan="2">
                                    <dx:ASPxTextBox ID="txtDistToGulf" runat="server" CssFilePath="../Styles/Site.css"
                                        TabIndex="18" Width="100%">
                                        <ValidationSettings>
                                            <RequiredField IsRequired="True" ErrorText="Distance From Coast is required" />
                                            <RegularExpression ValidationExpression=".{2,}" ErrorText="Distance should contain at least 2 letters" />
                                        </ValidationSettings>
                                    </dx:ASPxTextBox>
                                    <%--<asp:TextBox ID="txtDistToGulf" Width="105px" runat="server" Text="" 
                                        TabIndex="18" ></asp:TextBox>
                                 <asp:RequiredFieldValidator ID="RequiredFieldValidator18" ControlToValidate="txtDistToGulf"
                                            runat="server" Text="* Req Field"></asp:RequiredFieldValidator></td>--%>
                            </tr>
                        </tbody>
                    </table>
                </td>
            </tr>
            <tr>
                <td>
                    <table title="Description of Mobile Additions">
                        <tbody>
                            <tr style="border-bottom: 1px; border-bottom-color: Black">
                                <td colspan="3" align="left">
                                    <span class="style3">Description of Mobile Home, Additions & Unattached Structures</span>
                                </td>
                                <hr />
                            </tr>
                            <tr align="left">
                                <td align="right">
                                    <asp:Label ID="Label33" runat="server" Text="Year:" CssClass="AR_Application"></asp:Label>
                                </td>
                                <td>
                                    <asp:TextBox ID="txtDescMHYear" runat="server" Text="" TabIndex="19"></asp:TextBox>
                                </td>
                                <td align="right">
                                    <asp:Label ID="Label34" runat="server" Text="Manufacturer/<br/>Model:" CssClass="AR_Application"></asp:Label>
                                </td>
                                <td>
                                    <asp:TextBox Style="text-transform: uppercase" ID="txtDescMHManf" runat="server"
                                        Width="" Text="" TabIndex="20"></asp:TextBox>
                                </td>
                                <td align="right">
                                    <asp:Label ID="Label36" runat="server" Text="Length:" CssClass="AR_Application"></asp:Label>
                                </td>
                                <td>
                                    <asp:TextBox ID="txtDescMHLength" runat="server" Width="50px" Text="" TabIndex="21"></asp:TextBox>
                                </td>
                                <td align="right">
                                    <asp:Label ID="Label37" runat="server" Text="Width:" CssClass="AR_Application"></asp:Label>
                                </td>
                                <td>
                                    <asp:TextBox ID="txtDescMHWidth" runat="server" Width="50px" Text="" TabIndex="22"></asp:TextBox>
                                </td>
                            </tr>
                            <tr>
                                <td align="right">
                                    <asp:Label ID="Label38" runat="server" Text="Serial Number:" CssClass="AR_Application"></asp:Label>
                                </td>
                                <td align="left">
                                    <dx:ASPxTextBox ID="txtDescMHSerial" runat="server" CssFilePath="../Styles/Site.css"
                                        TabIndex="23" Width="100%">
                                        <ValidationSettings>
                                            <RequiredField IsRequired="True" ErrorText="Serial Number is required" />
                                            <RegularExpression ValidationExpression=".{2,}" ErrorText="Serial should contain at least 2 letters" />
                                        </ValidationSettings>
                                    </dx:ASPxTextBox>
                                    <%--<asp:TextBox style="text-transform:uppercase" ID="txtDescMHSerial" 
                                        runat="server" Width="" Text="" TabIndex="23"></asp:TextBox>
                                     <asp:RequiredFieldValidator ID="RequiredFieldValidator19" ControlToValidate="txtDescMHSerial"
                                            runat="server" Text="* Req Field"></asp:RequiredFieldValidator>--%>
                                </td>
                                <td align="right">
                                    <asp:Label ID="Label39" runat="server" Text="Purchase Date:" CssClass="AR_Application"></asp:Label>
                                </td>
                                <td align="left">
                                    <dx:ASPxTextBox ID="txtDescMHPurDate2" runat="server" Width="130" TabIndex="24">
                                        <MaskSettings Mask="99/99/9999" IncludeLiterals="None" />
                                        <ValidationSettings SetFocusOnError="True">
                                            <RequiredField IsRequired="True" ErrorText="Purchase Date Required" />
                                            <RegularExpression ValidationExpression="^((((0[13578])|(1[02]))[\/]?(([0-2][0-9])|(3[01])))|(((0[469])|(11))[\/]?(([0-2][0-9])|(30)))|(02[\/]?[0-2][0-9]))[\/]?\d{4}$"
                                                ErrorText="Purchase Date is Wrong Format" />
                                        </ValidationSettings>
                                    </dx:ASPxTextBox>
                                </td>
                                <td align="right">
                                    <asp:Label ID="Label40" runat="server" Text="Purchase Price:" CssClass="AR_Application"></asp:Label>
                                </td>
                                <td align="left">
                                    <dx:ASPxTextBox ID="txtDescMHPurPrice2" runat="server" Width="130" TabIndex="25">
                                        <MaskSettings Mask="$<0..999999g>.<00..99>" IncludeLiterals="DecimalSymbol" />
                                        <ValidationSettings SetFocusOnError="true" ErrorDisplayMode="ImageWithTooltip">
                                            <RequiredField IsRequired="True" ErrorText="Purchased Price is Required" />
                                        </ValidationSettings>
                                    </dx:ASPxTextBox>
                                </td>
                                <td align="right">
                                    <asp:Label ID="Label41" runat="server" Text="Current Date:" CssClass="AR_Application"></asp:Label>
                                </td>
                                <td align="left">
                                    <dx:ASPxTextBox ID="txtDescMHCurDate2" runat="server" Width="130">
                                        <MaskSettings Mask="00/00/0000" IncludeLiterals="None" />
                                        <ValidationSettings SetFocusOnError="false" ErrorDisplayMode="Text">
                                            <RequiredField IsRequired="True" ErrorText="Current Date Required" />
                                        </ValidationSettings>
                                    </dx:ASPxTextBox>
                                </td>
                            </tr>
                            <tr>
                                <td align="right">
                                    <asp:Label ID="Label42" runat="server" Text="Describe Additions/<br/>Attached Structures:"
                                        CssClass="AR_Application"></asp:Label>
                                </td>
                                <td align="left">
                                    <asp:TextBox Style="text-transform: uppercase" ID="txtDescMHAttStruc" runat="server"
                                        Width="200px" Text="" TabIndex="26"></asp:TextBox>
                                </td>
                                <td align="right">
                                    <asp:Label ID="Label43" runat="server" Text="Age:" CssClass="AR_Application"></asp:Label>
                                </td>
                                <td align="left">
                                    <asp:TextBox Style="text-transform: uppercase" ID="txtDescMHAttStrucAge" runat="server"
                                        Width="75px" Text="" TabIndex="27"></asp:TextBox>
                                </td>
                                <td align="right">
                                    <asp:Label ID="Label44" runat="server" Text="Size:" CssClass="AR_Application"></asp:Label>
                                </td>
                                <td align="left">
                                    <asp:TextBox Style="text-transform: uppercase" ID="txtDescMHAttStrucSize" runat="server"
                                        Width="75px" Text="" TabIndex="28"></asp:TextBox>
                                </td>
                                <td align="right">
                                    <asp:Label ID="Label45" runat="server" Text="Current Value:" CssClass="AR_Application"></asp:Label>
                                </td>
                                <td align="left">
                                    <dx:ASPxTextBox ID="txtDescMHAttStrucCurVal2" runat="server" Width="130" TabIndex="29">
                                        <MaskSettings Mask="$<0..99999g>.<00..99>" IncludeLiterals="DecimalSymbol" />
                                        <ValidationSettings SetFocusOnError="false" ErrorDisplayMode="Text">
                                            <RequiredField IsRequired="True" ErrorText="Current Value Required" />
                                        </ValidationSettings>
                                    </dx:ASPxTextBox>
                                </td>
                            </tr>
                            <tr>
                                <td align="right">
                                    <asp:Label ID="Label46" runat="server" Text="Describe Unattached<br/> Structures:"
                                        CssClass="AR_Application"></asp:Label>
                                </td>
                                <td align="left">
                                    <asp:TextBox Style="text-transform: uppercase" ID="txtDescMHUnAttStruc" runat="server"
                                        Width="200px" Text="" TabIndex="30"></asp:TextBox>
                                </td>
                                <td align="right">
                                    <asp:Label ID="Label47" runat="server" Text="Age:" CssClass="AR_Application"></asp:Label>
                                </td>
                                <td align="left">
                                    <asp:TextBox ID="txtDescMHUnAttStrucAge" runat="server" Width="75px" Text="" TabIndex="31"></asp:TextBox>
                                </td>
                                <td align="right">
                                    <asp:Label ID="Label48" runat="server" Text="Size:" CssClass="AR_Application"></asp:Label>
                                </td>
                                <td align="left">
                                    <asp:TextBox ID="txtDescMHUnAttStrucSize" runat="server" Width="75px" Text="" TabIndex="32"></asp:TextBox>
                                </td>
                                <td align="right">
                                    <asp:Label ID="Label49" runat="server" Text="Current Value:" CssClass="AR_Application"></asp:Label>
                                </td>
                                <td align="left">
                                    <dx:ASPxTextBox ID="txtDescMHUnAttStrucCurVal2" runat="server" Width="130" TabIndex="33">
                                        <MaskSettings Mask="$<0..99999g>.<00..99>" IncludeLiterals="DecimalSymbol" />
                                        <ValidationSettings SetFocusOnError="false" ErrorDisplayMode="Text">
                                            <RequiredField IsRequired="True" ErrorText="* Req Field" />
                                        </ValidationSettings>
                                    </dx:ASPxTextBox>
                                </td>
                            </tr>
                        </tbody>
                    </table>
                </td>
            </tr>
            <tr>
                <td>
                    <table title="General Information">
                        <tbody>
                            <tr style="border-bottom: 1px; border-bottom-color: Black">
                                <td colspan="2" align="left">
                                    <span class="style3">General Information</span>
                                </td>
                                <hr />
                            </tr>
                            <tr align="left">
                                <td align="right">
                                    <asp:Label ID="Label50" runat="server" Text="Territory:" CssClass="AR_Application"></asp:Label>
                                </td>
                                <td>
                                    <asp:Label ID="lblTerritory" runat="server" Text="" CssClass="AR_Application"></asp:Label>
                                </td>
                            </tr>
                            <tr align="left">
                                <td align="right">
                                    <asp:Label ID="Label52" runat="server" Text="Usage:" CssClass="AR_Application"></asp:Label>
                                </td>
                                <td>
                                    <dx:ASPxComboBox ID="ddUsage" runat="server" ValueType="System.String" DropDownStyle="DropDown"
                                        TabIndex="34">
                                        <Items>
                                            <dx:ListEditItem Text="Owner" Value="Owner" />
                                            <dx:ListEditItem Text="Seasonal" Value="Seasonal" />
                                            <dx:ListEditItem Text="Rental" Value="Rental" />
                                            <dx:ListEditItem Text="Tenant" Value="Tenant" />
                                            <dx:ListEditItem Text="Vacant" Value="Vacant" />
                                        </Items>
                                    </dx:ASPxComboBox>
                                    <%--<asp:dropdownlist runat="server" ID="ddUsage" RepeatDirection="Horizontal"  
                                        CssClass="AR_Application" TabIndex="34">
                                        <asp:ListItem>Owner</asp:ListItem>
                                            <asp:ListItem>Seasonal</asp:ListItem>
                                            <asp:ListItem>Rental</asp:ListItem>
                                            <asp:ListItem>Tenant</asp:ListItem>
                                            <asp:ListItem>Vacant</asp:ListItem>
                                    </asp:dropdownlist>
                                     <asp:RequiredFieldValidator ID="RequiredFieldValidator4" ControlToValidate="ddUsage"
                                            runat="server" Text="* Req Field"></asp:RequiredFieldValidator>--%>
                                </td>
                            </tr>
                            <tr align="left">
                                <td align="right">
                                    <asp:Label ID="Label55" runat="server" Text="Age of Mobile Home:" CssClass="AR_Application"></asp:Label>
                                </td>
                                <td>
                                    <dx:ASPxComboBox ID="ddMHAge" runat="server" ValueType="System.String" DropDownStyle="DropDown"
                                        TabIndex="35">
                                        <Items>
                                            <dx:ListEditItem Text="1-5 Yrs" Value="1-5 Yrs" />
                                            <dx:ListEditItem Text="6-15 Yrs" Value="6-15 Yrs" />
                                            <dx:ListEditItem Text="16 Yrs & Older" Value="16 Yrs & Older" />
                                        </Items>
                                    </dx:ASPxComboBox>
                                    <%-- <asp:dropdownlist runat="server" ID="ddMHAge" RepeatDirection="Horizontal"  
                                        CssClass="AR_Application" TabIndex="35">
                                        <asp:ListItem>1-5 Yrs</asp:ListItem>
                                        <asp:ListItem>6-15 Yrs</asp:ListItem>
                                        <asp:ListItem>16 Yrs & Older</asp:ListItem>
                                    </asp:dropdownlist>
                                     <asp:RequiredFieldValidator ID="RequiredFieldValidator23" ControlToValidate="ddMHAge"
                                            runat="server" Text="* Req Field"></asp:RequiredFieldValidator>--%>
                                </td>
                            </tr>
                            <tr align="left">
                                <td align="right">
                                    <asp:Label ID="Label56" runat="server" Text="Loss History:" CssClass="AR_Application"></asp:Label>
                                </td>
                                <td>
                                    <dx:ASPxComboBox ID="ddlossHist" runat="server" ValueType="System.String" DropDownStyle="DropDown"
                                        TabIndex="36">
                                        <Items>
                                            <dx:ListEditItem Text="" Value="" />
                                            <dx:ListEditItem Text="Yes" Value="Yes" />
                                            <dx:ListEditItem Text="No" Value="No" />
                                        </Items>
                                    </dx:ASPxComboBox>
                                    <%--<asp:DropDownList ID="ddlossHist" runat="server" TabIndex="36">
                                        <asp:ListItem></asp:ListItem>
                                        <asp:ListItem>Yes</asp:ListItem>
                                        <asp:ListItem>No</asp:ListItem>
                                    </asp:DropDownList>
                                     <asp:RequiredFieldValidator ID="RequiredFieldValidator24" ControlToValidate="ddlossHist"
                                            runat="server" Text="* Req Field"></asp:RequiredFieldValidator>--%>
                                </td>
                            </tr>
                            <tr align="left">
                                <td align="right">
                                    <asp:Label ID="Label57" runat="server" Text="Park Status:" CssClass="AR_Application"></asp:Label>
                                    &nbsp;&nbsp;&nbsp;<small>In a Park?</small>
                                </td>
                                <td>
                                    <dx:ASPxComboBox ID="ddParkStatus" runat="server" ValueType="System.String" DropDownStyle="DropDown"
                                        TabIndex="37">
                                        <Items>
                                            <dx:ListEditItem Text="" Value="" />
                                            <dx:ListEditItem Text="Yes" Value="Yes" />
                                            <dx:ListEditItem Text="No" Value="No" />
                                        </Items>
                                    </dx:ASPxComboBox>
                                    <%--  <asp:DropDownList ID="ddParkStatus" runat="server" TabIndex="37">
                                        <asp:ListItem></asp:ListItem>
                                        <asp:ListItem>Yes</asp:ListItem>
                                        <asp:ListItem>No</asp:ListItem>
                                    </asp:DropDownList>
                                     <asp:RequiredFieldValidator ID="RequiredFieldValidator25" ControlToValidate="ddParkStatus"
                                            runat="server" Text="* Req Field"></asp:RequiredFieldValidator>--%>
                                </td>
                            </tr>
                            <tr align="left">
                                <td align="right">
                                    <asp:Label ID="Label62" runat="server" Text="Unit Type:" CssClass="AR_Application"></asp:Label>
                                </td>
                                <td>
                                    <dx:ASPxComboBox ID="ddUnitType" runat="server" ValueType="System.String" DropDownStyle="DropDown"
                                        TabIndex="38">
                                        <Items>
                                            <dx:ListEditItem Text="" Value="" />
                                            <dx:ListEditItem Text="Singlewide" Value="Singlewide" />
                                            <dx:ListEditItem Text="Doublewide" Value="Doublewide" />
                                            <dx:ListEditItem Text="Other" Value="Other" />
                                        </Items>
                                    </dx:ASPxComboBox>
                                    <%-- <asp:DropDownList ID="ddUnitType" runat="server" TabIndex="38">
                                        <asp:ListItem></asp:ListItem>
                                        <asp:ListItem>Singlewide</asp:ListItem>
                                        <asp:ListItem>Doublewide</asp:ListItem>
                                        <asp:ListItem>Other</asp:ListItem>
                                    </asp:DropDownList>
                                     <asp:RequiredFieldValidator ID="RequiredFieldValidator26" ControlToValidate="ddunitType"
                                            runat="server" Text="* Req Field"></asp:RequiredFieldValidator>--%>
                                </td>
                            </tr>
                        </tbody>
                    </table>
                </td>
            </tr>
            <tr>
                <td>
                    <table title="LienHolder">
                        <tbody>
                            <tr>
                                <td colspan="2" align="left">
                                    <span class="style3">Lienholder</span>
                                </td>
                                <hr />
                            </tr>
                            <tr align="left" style="border: 1px solid">
                                <td align="right">
                                    <asp:Label ID="Label74" runat="server" Text="Name:" CssClass="AR_Application"></asp:Label>
                                </td>
                                <td>
                                    <asp:TextBox Style="text-transform: uppercase" ID="txtLien1Name" runat="server" Text=""
                                        TabIndex="39"></asp:TextBox>
                                </td>
                                <hr />
                            </tr>
                            <tr>
                                <td align="right">
                                    <asp:Label ID="Label75" runat="server" Text="Loan #:" CssClass="AR_Application"></asp:Label>
                                </td>
                                <td>
                                    <asp:TextBox Style="text-transform: uppercase" ID="txtLien1Num" runat="server" Text=""
                                        TabIndex="40"></asp:TextBox>
                                </td>
                            </tr>
                            <tr>
                                <td align="right">
                                    <asp:Label ID="Label76" runat="server" Text="Address:" CssClass="AR_Application"></asp:Label>
                                </td>
                                <td colspan="3">
                                    <asp:TextBox Style="text-transform: uppercase" ID="txtLien1Addr" Width="100%" runat="server"
                                        Text="" TabIndex="41"></asp:TextBox>
                                </td>
                            </tr>
                            <tr>
                                <td align="right">
                                    <asp:Label ID="Label79" runat="server" Text="Zip:" CssClass="AR_Application"></asp:Label>
                                </td>
                                <td align="left">
                                    <asp:TextBox ID="txtLien1Zip" runat="server" Width="50px" Text="" TabIndex="42"></asp:TextBox>
                                    <asp:Button ID="lienzip1" Text="getZip" runat="server" CausesValidation="false" Style="display: none" />
                                </td>
                                <td align="right">
                                    <asp:Label ID="Label77" runat="server" Text="City:" CssClass="AR_Application"></asp:Label>
                                </td>
                                <td>
                                    <asp:TextBox Style="text-transform: uppercase" ID="txtLien1City" runat="server" Text=""
                                        TabIndex="43"></asp:TextBox>
                                </td>
                                <td align="right">
                                    <asp:Label ID="Label78" runat="server" Text="State:" CssClass="AR_Application"></asp:Label>
                                </td>
                                <td>
                                    <asp:TextBox Style="text-transform: uppercase" ID="txtLien1State" runat="server"
                                        Width="25px" Text=""></asp:TextBox>
                                </td>
                            </tr>
                            <tr>
                                <td>
                                    <br />
                                </td>
                            </tr>
                            <tr align="left" style="border: 1px solid">
                                <td align="right">
                                    <asp:Label ID="Label80" runat="server" Text="Name:" CssClass="AR_Application"></asp:Label>
                                </td>
                                <td>
                                    <asp:TextBox Style="text-transform: uppercase" ID="txtLien2Name" runat="server" Text=""
                                        TabIndex="44"></asp:TextBox>
                                </td>
                            </tr>
                            <tr>
                                <td align="right">
                                    <asp:Label ID="Label81" runat="server" Text="Loan #:" CssClass="AR_Application"></asp:Label>
                                </td>
                                <td>
                                    <asp:TextBox Style="text-transform: uppercase" ID="txtLien2Num" runat="server" Text=""
                                        TabIndex="45"></asp:TextBox>
                                </td>
                            </tr>
                            <tr>
                                <td align="right">
                                    <asp:Label ID="Label82" runat="server" Text="Address:" CssClass="AR_Application"></asp:Label>
                                </td>
                                <td colspan="3">
                                    <asp:TextBox Style="text-transform: uppercase" ID="txtLien2Addr" Width="100%" runat="server"
                                        Text="" TabIndex="46"></asp:TextBox>
                                </td>
                            </tr>
                            <tr>
                                <td align="right">
                                    <asp:Label ID="Label85" runat="server" Text="Zip:" CssClass="AR_Application"></asp:Label>
                                </td>
                                <td align="left">
                                    <asp:TextBox ID="txtLien2Zip" runat="server" Width="50px" Text="" TabIndex="47"></asp:TextBox>
                                    <asp:Button ID="lienzip2" Text="getZip" runat="server" CausesValidation="false" Style="display: none" />
                                </td>
                                <td align="right">
                                    <asp:Label ID="Label83" runat="server" Text="City:" CssClass="AR_Application"></asp:Label>
                                </td>
                                <td>
                                    <asp:TextBox Style="text-transform: uppercase" ID="txtLien2City" runat="server" Text=""
                                        TabIndex="48"></asp:TextBox>
                                </td>
                                <td align="right">
                                    <asp:Label ID="Label84" runat="server" Text="State:" CssClass="AR_Application"></asp:Label>
                                </td>
                                <td>
                                    <asp:TextBox Style="text-transform: uppercase" ID="txtLien2State" runat="server"
                                        Width="25px" Text=""></asp:TextBox>
                                </td>
                            </tr>
                        </tbody>
                    </table>
                </td>
            </tr>
            <tr>
                <td>
                    <table title="Loss Information">
                        <tbody>
                            <tr style="border-bottom: 1px; border-bottom-color: Black">
                                <td colspan="2" align="left">
                                    <span class="style3">Loss Information</span>
                                </td>
                                <hr />
                            </tr>
                            <tr align="left">
                                <td align="right">
                                    <asp:Label ID="Label69" runat="server" Text="Prior Insurance:" CssClass="AR_Application"></asp:Label>
                                </td>
                                <td>
                                    <dx:ASPxComboBox ID="ddPriorInsurance" runat="server" ValueType="System.String" DropDownStyle="DropDownList"
                                        TabIndex="49">
                                        <Items>
                                            <dx:ListEditItem Text="" Value="" />
                                            <dx:ListEditItem Text="Yes" Value="Yes" />
                                            <dx:ListEditItem Text="No" Value="No" />
                                            <dx:ListEditItem Text="New Purchase" Value="New Purchase" />
                                        </Items>
                                        <ClientSideEvents SelectedIndexChanged="PriorIns2" />
                                    </dx:ASPxComboBox>
                                    <%--  <asp:DropDownList ID="ddPriorInsurance" runat="server" TabIndex="49">
                                        <asp:ListItem></asp:ListItem>
                                        <asp:ListItem>Yes</asp:ListItem>
                                        <asp:ListItem>No</asp:ListItem>
                                        <asp:ListItem>New Purchase</asp:ListItem>
                                    </asp:DropDownList>
                                    <asp:RequiredFieldValidator ID="RequiredFieldValidator75" ControlToValidate="ddPriorInsurance"
                                            runat="server" Text="* Req Field"></asp:RequiredFieldValidator>--%>
                                    <div runat="server" id="priorInsurance" style="display: none">
                                        <asp:Label ID="Label70" runat="server" Text="Prior Company:" CssClass="AR_Application"
                                            TabIndex="50"></asp:Label>
                                        &nbsp;
                                        <asp:TextBox Style="text-transform: uppercase" ID="txtPriorCompany" runat="server"
                                            Text="" TabIndex="51"></asp:TextBox>
                                        <asp:Label ID="Label1" runat="server" Text="Years of Insurance:" CssClass="AR_Application"></asp:Label>
                                        <asp:TextBox Style="text-transform: uppercase" ID="txtprioryears" runat="server"
                                            Text="" TabIndex="52"></asp:TextBox>
                                    </div>
                                </td>
                            </tr>
                            <tr align="left">
                                <td>
                                    <asp:Label ID="lblLossDateCaption" runat="server" Text="Date of Loss" CssClass="AR_Application" />
                                </td>
                                <td>
                                    <asp:Label ID="lblLossTypeCaption" runat="server" Text="Loss Type" CssClass="AR_Application" />
                                </td>
                                <td>
                                    <asp:Label ID="lblLossDescriptionCaption" runat="server" Text="Loss Description"
                                        CssClass="AR_Application" />
                                </td>
                                <td>
                                    <asp:Label ID="lblLossAmtPaidCaption" runat="server" Text="Amt Paid" CssClass="AR_Application" />
                                </td>
                                <td>
                                    <asp:Label ID="lblLossStatusCaption" runat="server" Text="Damages Repaired?" CssClass="AR_Application" />
                                </td>
                            </tr>
                            <tr align="left">
                                <td>
                                    <asp:TextBox ID="txtLoss1Date" runat="server" DataFieldName="Loss1Date" FriendlyName="Loss 1 date"
                                        Width="80px" TabIndex="55" />
                                    <ajaxTK:TextBoxWatermarkExtender ID="TextBoxWatermarkExtender3" runat="server" Enabled="True"
                                        TargetControlID="txtLoss1Date" WatermarkCssClass="WatermarkCssClass" WatermarkText="mm/dd/yyyy" />
                                </td>
                                <td>
                                    <asp:DropDownList ID="ddLoss1Type" runat="server" TabIndex="56">
                                        <asp:ListItem></asp:ListItem>
                                        <asp:ListItem>FIRE</asp:ListItem>
                                        <asp:ListItem>WATER</asp:ListItem>
                                        <asp:ListItem>WIND</asp:ListItem>
                                        <asp:ListItem>THEFT</asp:ListItem>
                                        <asp:ListItem>VMM</asp:ListItem>
                                        <asp:ListItem>LIABILITY</asp:ListItem>
                                        <asp:ListItem>OTHER</asp:ListItem>
                                    </asp:DropDownList>
                                </td>
                                <td>
                                    <asp:TextBox Style="text-transform: uppercase" ID="txtLoss1Description" runat="server"
                                        Casing="UPPER" Columns="20" FriendlyName="Loss 1 description" Rows="2" TextMode="MultiLine"
                                        TabIndex="57" />
                                </td>
                                <td>
                                    <asp:TextBox ID="txtLoss1AmtPaid" runat="server" Columns="8" FormatNamed="Currency"
                                        FormatNamedDecimals="0" FriendlyName="Loss 1 amt paid" Text="$0" TabIndex="58"
                                        Height="22px" />
                                </td>
                                <td>
                                    <asp:DropDownList ID="ddLoss1Status" runat="server" TabIndex="59">
                                        <asp:ListItem></asp:ListItem>
                                        <asp:ListItem>No</asp:ListItem>
                                        <asp:ListItem>Yes</asp:ListItem>
                                    </asp:DropDownList>
                                </td>
                            </tr>
                            <tr align="left">
                                <td>
                                    <asp:TextBox ID="txtLoss2Date" runat="server" DataFieldName="Loss2Date" FriendlyName="Loss 1 date"
                                        Width="80px" TabIndex="60" />
                                    <ajaxTK:TextBoxWatermarkExtender ID="TextBoxWatermarkExtender9" runat="server" Enabled="True"
                                        TargetControlID="txtLoss2Date" WatermarkCssClass="WatermarkCssClass" WatermarkText="mm/dd/yyyy" />
                                </td>
                                <td>
                                    <asp:DropDownList ID="ddLoss2Type" runat="server" TabIndex="61">
                                        <asp:ListItem></asp:ListItem>
                                        <asp:ListItem>FIRE</asp:ListItem>
                                        <asp:ListItem>WATER</asp:ListItem>
                                        <asp:ListItem>WIND</asp:ListItem>
                                        <asp:ListItem>THEFT</asp:ListItem>
                                        <asp:ListItem>VMM</asp:ListItem>
                                        <asp:ListItem>LIABILITY</asp:ListItem>
                                        <asp:ListItem>OTHER</asp:ListItem>
                                    </asp:DropDownList>
                                </td>
                                <td>
                                    <asp:TextBox Style="text-transform: uppercase" ID="txtLoss2Description" runat="server"
                                        Casing="UPPER" Columns="20" FriendlyName="Loss 1 description" Rows="2" TextMode="MultiLine"
                                        TabIndex="62" />
                                </td>
                                <td>
                                    <asp:TextBox ID="txtLoss2AmtPaid" runat="server" Columns="8" FormatNamed="Currency"
                                        FormatNamedDecimals="0" FriendlyName="Loss 1 amt paid" Text="$0" TabIndex="63" />
                                </td>
                                <td>
                                    <asp:DropDownList ID="ddLoss2Status" runat="server" TabIndex="64">
                                        <asp:ListItem></asp:ListItem>
                                        <asp:ListItem>No</asp:ListItem>
                                        <asp:ListItem>Yes</asp:ListItem>
                                    </asp:DropDownList>
                                </td>
                            </tr>
                            <tr align="left">
                                <td>
                                    <asp:TextBox ID="txtLoss3Date" runat="server" DataFieldName="Loss3Date" FriendlyName="Loss 1 date"
                                        Width="80px" TabIndex="65" />
                                    <ajaxTK:TextBoxWatermarkExtender ID="TextBoxWatermarkExtender11" runat="server" Enabled="True"
                                        TargetControlID="txtLoss3Date" WatermarkCssClass="WatermarkCssClass" WatermarkText="mm/dd/yyyy" />
                                </td>
                                <td>
                                    <asp:DropDownList ID="ddLoss3Type" runat="server" TabIndex="66">
                                        <asp:ListItem></asp:ListItem>
                                        <asp:ListItem>FIRE</asp:ListItem>
                                        <asp:ListItem>WATER</asp:ListItem>
                                        <asp:ListItem>WIND</asp:ListItem>
                                        <asp:ListItem>THEFT</asp:ListItem>
                                        <asp:ListItem>VMM</asp:ListItem>
                                        <asp:ListItem>LIABILITY</asp:ListItem>
                                        <asp:ListItem>OTHER</asp:ListItem>
                                    </asp:DropDownList>
                                </td>
                                <td>
                                    <asp:TextBox Style="text-transform: uppercase" ID="txtLoss3Description" runat="server"
                                        Casing="UPPER" Columns="20" FriendlyName="Loss 1 description" Rows="2" TextMode="MultiLine"
                                        TabIndex="67" />
                                </td>
                                <td>
                                    <asp:TextBox ID="txtLoss3AmtPaid" runat="server" Columns="8" FormatNamed="Currency"
                                        FormatNamedDecimals="0" FriendlyName="Loss 1 amt paid" Text="$0" TabIndex="68" />
                                </td>
                                <td>
                                    <asp:DropDownList ID="ddLoss3Status" runat="server" TabIndex="69">
                                        <asp:ListItem></asp:ListItem>
                                        <asp:ListItem>No</asp:ListItem>
                                        <asp:ListItem>Yes</asp:ListItem>
                                    </asp:DropDownList>
                                </td>
                            </tr>
                        </tbody>
                    </table>
                </td>
            </tr>
            <tr>
                <td>
                    <table title="Underwriting Questions">
                        <tbody>
                            <tr style="border-bottom: 1px; border-bottom-color: Black">
                                <td colspan="2" align="left">
                                    <span class="style3">Underwriting Questions</span>
                                </td>
                                <hr />
                            </tr>
                            <tr align="left">
                                <td class="style4">
                                    <dx:ASPxComboBox ID="dd_ARIng1" runat="server" ValueType="System.String" Width="50"
                                        DropDownStyle="DropDown" TabIndex="70" ClientInstanceName="dd_ARIng1">
                                        <%--<Items>
                                            <dx:ListEditItem Text="None" Value="None" />
                                            <dx:ListEditItem Text="Woodstove" Value="Woodstove" />
                                            <dx:ListEditItem Text="Fireplace" Value="Fireplace" />
                                            <dx:ListEditItem Text="Both" Value="Both" />
                                        </Items>--%>
                                        <Items>
                                         <dx:ListEditItem Text="" Value= "" />
                                         <dx:ListEditItem Text="Yes" Value= "Yes" />
                                         <dx:ListEditItem Text="No" Value= "No" />
                                         </Items>
                                        <ClientSideEvents SelectedIndexChanged="function(s, e) { ValidateCheck(s); }" />
                                    </dx:ASPxComboBox>
                                    <%-- <asp:DropDownList ID="dd_ARIng1" runat="server" TabIndex="70">
                                        <asp:ListItem></asp:ListItem>
                                        <asp:ListItem>Yes</asp:ListItem>
                                        <asp:ListItem>No</asp:ListItem>
                                    </asp:DropDownList>
                                    <asp:RequiredFieldValidator ID="RequiredFieldValidator32" ControlToValidate="dd_ARIng1"
                                            runat="server" Text="* Req Field"></asp:RequiredFieldValidator>
                                </td>--%>
                                    <td align="left" class="style4">
                                        <asp:Label ID="Label87" runat="server" Text="1. Woodburning Stove or Fireplace?"
                                            CssClass="AR_Application"></asp:Label>
                                    </td>
                            </tr>
                            <tr align="left">
                                <td>
                                    <dx:ASPxComboBox ID="dd_ARIng2" runat="server" ValueType="System.String" Width="50"
                                        DropDownStyle="DropDown" TabIndex="71">
                                        <Items>
                                            <dx:ListEditItem Text="" Value="" />
                                            <dx:ListEditItem Text="Yes" Value="Yes" />
                                            <dx:ListEditItem Text="No" Value="No" />
                                        </Items>
                                         <ClientSideEvents SelectedIndexChanged="function(s, e) { ValidateCheck(s); }" />
                                    </dx:ASPxComboBox>
                                    <%--<asp:DropDownList ID="dd_ARIng2" runat="server" TabIndex="71">
                                        <asp:ListItem></asp:ListItem>
                                        <asp:ListItem>Yes</asp:ListItem>
                                        <asp:ListItem>No</asp:ListItem>
                                    </asp:DropDownList>
                                     <asp:RequiredFieldValidator ID="RequiredFieldValidator33" ControlToValidate="dd_ARIng2"
                                            runat="server" Text="* Req Field"></asp:RequiredFieldValidator>--%>
                                </td>
                                <td align="left">
                                    <asp:Label ID="Label88" runat="server" Text="2. Business on Property?" CssClass="AR_Application"></asp:Label>
                                </td>
                            </tr>
                            <tr align="left">
                                <td>
                                    <dx:ASPxComboBox ID="dd_ARIng3" runat="server" ValueType="System.String" Width="50"
                                        DropDownStyle="DropDown" TabIndex="72">
                                        <Items>
                                            <dx:ListEditItem Text="" Value="" />
                                            <dx:ListEditItem Text="Yes" Value="Yes" />
                                            <dx:ListEditItem Text="No" Value="No" />
                                        </Items>
                                         <ClientSideEvents SelectedIndexChanged="function(s, e) { ValidateCheck(s); }" />
                                    </dx:ASPxComboBox>
                                    <%-- <asp:DropDownList ID="dd_ARIng3" runat="server" TabIndex="72">
                                        <asp:ListItem></asp:ListItem>
                                        <asp:ListItem>Yes</asp:ListItem>
                                        <asp:ListItem>No</asp:ListItem>
                                    </asp:DropDownList>
                                     <asp:RequiredFieldValidator ID="RequiredFieldValidator34" ControlToValidate="dd_ARIng3"
                                            runat="server" Text="* Req Field"></asp:RequiredFieldValidator>--%>
                                </td>
                                <td align="left">
                                    <asp:Label ID="Label86" runat="server" Text="3. Farming on Property?" CssClass="AR_Application"></asp:Label>
                                </td>
                            </tr>
                            <tr align="left">
                                <td>
                                    <dx:ASPxComboBox ID="dd_ARIng4" runat="server" ValueType="System.String" Width="50"
                                        DropDownStyle="DropDown" TabIndex="73">
                                        <Items>
                                            <dx:ListEditItem Text="" Value="" />
                                            <dx:ListEditItem Text="Yes" Value="Yes" />
                                            <dx:ListEditItem Text="No" Value="No" />
                                        </Items>
                                         <ClientSideEvents SelectedIndexChanged="function(s, e) { ValidateCheck(s); }" />
                                    </dx:ASPxComboBox>
                                    <%-- <asp:DropDownList ID="dd_ARIng4" runat="server" TabIndex="73">
                                        <asp:ListItem></asp:ListItem>
                                        <asp:ListItem>Yes</asp:ListItem>
                                        <asp:ListItem>No</asp:ListItem>
                                    </asp:DropDownList>
                                     <asp:RequiredFieldValidator ID="RequiredFieldValidator35" ControlToValidate="dd_ARIng4"
                                            runat="server" Text="* Req Field"></asp:RequiredFieldValidator>--%>
                                </td>
                                <td align="left">
                                    <asp:Label ID="Label89" runat="server" Text="4. Animals on Property?" CssClass="AR_Application"></asp:Label>
                                </td>
                            </tr>
                            <tr align="left">
                                <td>
                                    <dx:ASPxComboBox ID="dd_ARIng5" runat="server" ValueType="System.String" Width="50"
                                        DropDownStyle="DropDown" TabIndex="74">
                                        <Items>
                                            <dx:ListEditItem Text="" Value="" />
                                            <dx:ListEditItem Text="Yes" Value="Yes" />
                                            <dx:ListEditItem Text="No" Value="No" />
                                        </Items>
                                         <ClientSideEvents SelectedIndexChanged="function(s, e) { ValidateCheck(s); }" />
                                    </dx:ASPxComboBox>
                                    <%-- <asp:DropDownList ID="dd_ARIng5" runat="server" TabIndex="74">
                                        <asp:ListItem></asp:ListItem>
                                        <asp:ListItem>Yes</asp:ListItem>
                                        <asp:ListItem>No</asp:ListItem>
                                    </asp:DropDownList>
                                     <asp:RequiredFieldValidator ID="RequiredFieldValidator36" ControlToValidate="dd_ARIng5"
                                            runat="server" Text="* Req Field"></asp:RequiredFieldValidator>--%>
                                </td>
                                <td align="left">
                                    <asp:Label ID="Label90" runat="server" Text="5. Swimming Pool on Property?" CssClass="AR_Application"></asp:Label>
                                </td>
                            </tr>
                            <tr align="left">
                                <td>
                                    <dx:ASPxComboBox ID="dd_ARIng6" runat="server" ValueType="System.String" Width="50"
                                        DropDownStyle="DropDown" TabIndex="75">
                                        <Items>
                                            <dx:ListEditItem Text="" Value="" />
                                            <dx:ListEditItem Text="Yes" Value="Yes" />
                                            <dx:ListEditItem Text="No" Value="No" />
                                        </Items>
                                         <ClientSideEvents SelectedIndexChanged="function(s, e) { ValidateCheck(s); }" />
                                    </dx:ASPxComboBox>
                                    <%--   <asp:DropDownList ID="dd_ARIng6" runat="server" TabIndex="75">
                                        <asp:ListItem></asp:ListItem>
                                        <asp:ListItem>Yes</asp:ListItem>
                                        <asp:ListItem>No</asp:ListItem>
                                    </asp:DropDownList>
                                     <asp:RequiredFieldValidator ID="RequiredFieldValidator37" ControlToValidate="dd_ARIng6"
                                            runat="server" Text="* Req Field"></asp:RequiredFieldValidator>--%>
                                </td>
                                <td align="left">
                                    <asp:Label ID="Label91" runat="server" Text="6. Repo/Foreclosure in the past 24 months?"
                                        CssClass="AR_Application"></asp:Label>
                                </td>
                            </tr>
                            <tr align="left">
                                <td>
                                    <dx:ASPxComboBox ID="dd_ARIng7" runat="server" ValueType="System.String" Width="50"
                                        DropDownStyle="DropDown" TabIndex="76">
                                        <Items>
                                            <dx:ListEditItem Text="" Value="" />
                                            <dx:ListEditItem Text="Yes" Value="Yes" />
                                            <dx:ListEditItem Text="No" Value="No" />
                                        </Items>
                                         <ClientSideEvents SelectedIndexChanged="function(s, e) { ValidateCheck(s); }" />
                                    </dx:ASPxComboBox>
                                    <%-- <asp:DropDownList ID="dd_ARIng7" runat="server" TabIndex="76">
                                        <asp:ListItem></asp:ListItem>
                                        <asp:ListItem>Yes</asp:ListItem>
                                        <asp:ListItem>No</asp:ListItem>
                                    </asp:DropDownList>
                                     <asp:RequiredFieldValidator ID="RequiredFieldValidator38" ControlToValidate="dd_ARIng7"
                                            runat="server" Text="* Req Field"></asp:RequiredFieldValidator>--%>
                                </td>
                                <td align="left">
                                    <asp:Label ID="Label93" runat="server" Text="7. Bankruptcy in the past 24 months?"
                                        CssClass="AR_Application"></asp:Label>
                                </td>
                            </tr>
                            <tr align="left">
                                <td>
                                    <dx:ASPxComboBox ID="dd_ARIng8" runat="server" ValueType="System.String" Width="50"
                                        DropDownStyle="DropDown" TabIndex="77">
                                        <Items>
                                            <dx:ListEditItem Text="" Value="" />
                                            <dx:ListEditItem Text="Yes" Value="Yes" />
                                            <dx:ListEditItem Text="No" Value="No" />
                                        </Items>
                                         <ClientSideEvents SelectedIndexChanged="function(s, e) { ValidateCheck(s); }" />
                                    </dx:ASPxComboBox>
                                    <%--<asp:DropDownList ID="dd_ARIng8" runat="server" TabIndex="77">
                                        <asp:ListItem></asp:ListItem>
                                        <asp:ListItem>Yes</asp:ListItem>
                                        <asp:ListItem>No</asp:ListItem>
                                    </asp:DropDownList>
                                     <asp:RequiredFieldValidator ID="RequiredFieldValidator39" ControlToValidate="dd_ARIng8"
                                            runat="server" Text="* Req Field"></asp:RequiredFieldValidator>--%>
                                </td>
                                <td align="left">
                                    <asp:Label ID="Label94" runat="server" Text="8. Claims in the past 36 months?" CssClass="AR_Application"></asp:Label>
                                </td>
                            </tr>
                            <tr align="left">
                                <td>
                                    <dx:ASPxComboBox ID="dd_ARIng9" runat="server" ValueType="System.String" Width="50"
                                        DropDownStyle="DropDown" TabIndex="78">
                                        <Items>
                                            <dx:ListEditItem Text="" Value="" />
                                            <dx:ListEditItem Text="Yes" Value="Yes" />
                                            <dx:ListEditItem Text="No" Value="No" />
                                        </Items>
                                         <ClientSideEvents SelectedIndexChanged="function(s, e) { ValidateCheck(s); }" />
                                    </dx:ASPxComboBox>
                                    <%-- <asp:DropDownList ID="dd_ARIng9" runat="server" TabIndex="78">
                                        <asp:ListItem></asp:ListItem>
                                        <asp:ListItem>Yes</asp:ListItem>
                                        <asp:ListItem>No</asp:ListItem>
                                    </asp:DropDownList>
                                     <asp:RequiredFieldValidator ID="RequiredFieldValidator40" ControlToValidate="dd_ARIng9"
                                            runat="server" Text="* Req Field"></asp:RequiredFieldValidator>--%>
                                </td>
                                <td align="left">
                                    <asp:Label ID="Label95" runat="server" Text="9. Unrepaired Damage?" CssClass="AR_Application"></asp:Label>
                                </td>
                            </tr>
                            <tr align="left">
                                <td>
                                    <dx:ASPxComboBox ID="dd_ARIng10" runat="server" ValueType="System.String" Width="50"
                                        DropDownStyle="DropDown" TabIndex="79">
                                        <Items>
                                            <dx:ListEditItem Text="" Value="" />
                                            <dx:ListEditItem Text="Yes" Value="Yes" />
                                            <dx:ListEditItem Text="No" Value="No" />
                                            <dx:ListEditItem Text="<3" Value="<3" />
                                        </Items>
                                         <ClientSideEvents SelectedIndexChanged="function(s, e) { ValidateCheck(s); }" />
                                    </dx:ASPxComboBox>
                                    <%--<asp:DropDownList ID="dd_ARIng10" runat="server" TabIndex="79">
                                        <asp:ListItem></asp:ListItem>
                                        <asp:ListItem>Yes</asp:ListItem>
                                        <asp:ListItem>No</asp:ListItem>
                                        <asp:ListItem><3</asp:ListItem>
                                    </asp:DropDownList>
                                     <asp:RequiredFieldValidator ID="RequiredFieldValidator41" ControlToValidate="dd_ARIng10"
                                            runat="server" Text="* Req Field"></asp:RequiredFieldValidator>--%>
                                </td>
                                <td align="left">
                                    <asp:Label ID="Label96" runat="server" Text="10. Handrails Installed (3 or more steps)?"
                                        CssClass="AR_Application"></asp:Label>
                                </td>
                            </tr>
                            <tr align="left">
                                <td>
                                    <dx:ASPxComboBox ID="dd_ARIng11" runat="server" ValueType="System.String" Width="50"
                                        DropDownStyle="DropDown" TabIndex="80">
                                        <Items>
                                            <dx:ListEditItem Text="" Value="" />
                                            <dx:ListEditItem Text="Yes" Value="Yes" />
                                            <dx:ListEditItem Text="No" Value="No" />
                                        </Items>
                                         <ClientSideEvents SelectedIndexChanged="function(s, e) { ValidateCheck(s); }" />
                                    </dx:ASPxComboBox>
                                    <%-- <asp:DropDownList ID="dd_ARIng11" runat="server" TabIndex="80">
                                        <asp:ListItem></asp:ListItem>
                                        <asp:ListItem>Yes</asp:ListItem>
                                        <asp:ListItem>No</asp:ListItem>
                                    </asp:DropDownList>
                                     <asp:RequiredFieldValidator ID="RequiredFieldValidator42" ControlToValidate="dd_ARIng11"
                                            runat="server" Text="* Req Field"></asp:RequiredFieldValidator>--%>
                                </td>
                                <td align="left">
                                    <asp:Label ID="Label97" runat="server" Text="11. Mortgage Payment Currently Past Due?"
                                        CssClass="AR_Application"></asp:Label>
                                </td>
                            </tr>
                            <tr align="left">
                                <td>
                                    <dx:ASPxComboBox ID="dd_ARIng12" runat="server" ValueType="System.String" Width="50"
                                        DropDownStyle="DropDown" TabIndex="81">
                                        <Items>
                                            <dx:ListEditItem Text="" Value="" />
                                            <dx:ListEditItem Text="Yes" Value="Yes" />
                                            <dx:ListEditItem Text="No" Value="No" />
                                        </Items>
                                         <ClientSideEvents SelectedIndexChanged="function(s, e) { ValidateCheck(s); }" />
                                    </dx:ASPxComboBox>
                                    <%-- <asp:DropDownList ID="dd_ARIng12" runat="server" TabIndex="81">
                                        <asp:ListItem></asp:ListItem>
                                        <asp:ListItem>Yes</asp:ListItem>
                                        <asp:ListItem>No</asp:ListItem>
                                    </asp:DropDownList>
                                     <asp:RequiredFieldValidator ID="RequiredFieldValidator43" ControlToValidate="dd_ARIng12"
                                            runat="server" Text="* Req Field"></asp:RequiredFieldValidator>--%>
                                </td>
                                <td align="left">
                                    <asp:Label ID="Label98" runat="server" Text="12. Kerosene Heater?" CssClass="AR_Application"></asp:Label>
                                </td>
                            </tr>
                        </tbody>
                    </table>
                </td>
            </tr>
            <tr>
                <td>
                    <table title="Policy Distribution">
                        <tbody>
                            <tr style="border-bottom: 1px; border-bottom-color: Black">
                                <td colspan="2" align="left">
                                    <span class="style3">Policy Distribution</span>
                                </td>
                                <hr />
                            </tr>
                            <tr align="left">
                                <td align="left">
                                    <asp:Label ID="Label92" runat="server" Text="How would you like to receive the poicy?"
                                        CssClass="AR_Application"></asp:Label>
                                    <br />
                                    <asp:Label ID="Label130" runat="server" Text="Please select Preferred options"></asp:Label>
                                </td>
                            </tr>
                            <tr>
                                <td align="left">
                                    <asp:Label ID="Label131" runat="server" Text="Insured" CssClass="AR_Application"></asp:Label>
                                </td>
                                <td>
                                    <asp:DropDownList ID="dddistOptionInsured" runat="server" TabIndex="82">
                                        <%-- <asp:ListItem></asp:ListItem>
                                        <asp:ListItem></asp:ListItem>
                                        <asp:ListItem>Receive via email</asp:ListItem>--%>
                                        <asp:ListItem>Receive via mail</asp:ListItem>
                                    </asp:DropDownList>
                                </td>
                            </tr>
                            <tr>
                                <td align="left">
                                    <asp:Label ID="Label132" runat="server" Text="Agent" CssClass="AR_Application"></asp:Label>
                                </td>
                                <td>
                                    <asp:DropDownList ID="dddistOptionAgent" runat="server" TabIndex="83">
                                        <%-- <asp:ListItem></asp:ListItem>
                                        <asp:ListItem></asp:ListItem>
                                        <asp:ListItem>Recieve via email</asp:ListItem>--%>
                                        <asp:ListItem>Receive via mail</asp:ListItem>
                                    </asp:DropDownList>
                                </td>
                            </tr>
                        </tbody>
                    </table>
                </td>
            </tr>
            <tr>
                <td>
                    <table title="Payment">
                        <tbody>
                            <tr style="border-bottom: 1px; border-bottom-color: Black">
                                <td colspan="2" align="left">
                                    <span class="style3">Payment</span>
                                </td>
                                <hr />
                            </tr>
                            <tr>
                                <td colspan="2">
                                    <asp:DropDownList ID="ddPaymentOpt" runat="server" TabIndex="84">
                                        <asp:ListItem></asp:ListItem>
                                        <asp:ListItem></asp:ListItem>
                                        <asp:ListItem>In Full</asp:ListItem>
                                        <asp:ListItem Value="Premium Finance">Premium Finance</asp:ListItem>
                                    </asp:DropDownList>
                                    <asp:Button ID="Button1" Text="getZip" runat="server" CausesValidation="false"
                                        Style="display: none" />
                                         <asp:Button ID="PrimeRatefinancebtn2" Text="CalcPrimeRateFinanceASP" runat="server" CausesValidation="false"
                                        Style="display: none" />
                                        <dx:ASPxButton runat="server" ID="PrimeRateFinanceBtn" ClientInstanceName="PRBtn" Text="CalcPrimeRateFinanceDEVEXP" ClientVisible="False">
                                            <ClientSideEvents Click="function(s, e) {Callback.PerformCallback();LoadingPanel.Show();}" />
                                        </dx:ASPxButton>
                                       <dx:ASPxLoadingPanel ID="PrimeRateLoadingPanel" runat="server" ClientInstanceName="LoadingPanel" Modal="True" Text="Contacting Prime Rate...">
                                        </dx:ASPxLoadingPanel>
                                       <dx:ASPxCallback ID="ASPxCallback1PrimeRate" runat="server" ClientInstanceName="Callback">
                                            <ClientSideEvents  CallbackComplete="function(s, e) { LoadingPanel.Hide(); }" />
                                        </dx:ASPxCallback>
                                    <asp:Button ID="financebtn2" Text="getZip" runat="server" CausesValidation="false"
                                        Style="display: none" />
                                    <asp:Label ID="financelbl" runat="server" ClientIDMode="Static"></asp:Label>
                                </td>
                            </tr>
                            <tr>
                                <td>
                                    <table id="FinanceDetails" style="display: none">
                                        <tbody>
                                            <tr>
                                                <td>
                                                    <asp:UpdatePanel ID="updateFinancePanel1" runat="server" UpdateMode="Conditional">
                                                        <ContentTemplate>
                                                            <!--FINANCE TABLE-->
                                                            <table>
                                                                <tbody>
                                                                    <tr>
                                                                        <td>
                                                                            <table>
                                                                                <tbody>
                                                                                    <tr>
                                                                                        <td>
                                                                                            <asp:Label ID="Label26" runat="server" Text="Payment Plan:" Font-Bold="True"></asp:Label>
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
                                                                                            <asp:Label ID="Label114" runat="server" Text="Annual Premium: " CssClass="AR_Application"></asp:Label>&nbsp;
                                                                                        </td>
                                                                                        <td align="right">
                                                                                            <asp:Label ID="lblAnnualPremiumLLOYD" runat="server" Casing="Normal" CssClass="AR_Application"
                                                                                                DataFieldName="AnnualPremiumLLOYDS" />
                                                                                        </td>
                                                                                    </tr>
                                                                                    <tr>
                                                                                        <td>
                                                                                            <asp:Label ID="Label115" runat="server" Text="Down Payment: " CssClass="AR_Application"></asp:Label>
                                                                                        </td>
                                                                                        <td align="right">
                                                                                            <asp:Label ID="lblDownPaymentLLOYD" runat="server" Casing="Normal" CssClass="AR_Application"
                                                                                                DataFieldName="DownPaymentLLOYDS" />
                                                                                        </td>
                                                                                    </tr>
                                                                                    <tr>
                                                                                        <td>
                                                                                            <asp:Label ID="Label116" runat="server" Text="Amount Financed: " CssClass="AR_Application"></asp:Label>
                                                                                        </td>
                                                                                        <td align="right">
                                                                                            <asp:Label ID="lblAmountFinancedLLOYD" runat="server" Casing="Normal" CssClass="AR_Application"
                                                                                                DataFieldName="AmountFinancedLLOYDS" />
                                                                                        </td>
                                                                                    </tr>
                                                                                    <tr>
                                                                                        <td>
                                                                                            <asp:Label ID="Label117" runat="server" Text="Finance Charge: " CssClass="AR_Application"></asp:Label>
                                                                                        </td>
                                                                                        <td align="right">
                                                                                            <asp:Label ID="lblFinanceChargeLLOYD" runat="server" Casing="Normal" CssClass="AR_Application"
                                                                                                DataFieldName="FinanceChargeLLOYDS" />
                                                                                        </td>
                                                                                    </tr>
                                                                                    <tr>
                                                                                        <td>
                                                                                            <asp:Label ID="Label27" runat="server" Text="Total of Payments: " CssClass="AR_Application"></asp:Label>
                                                                                        </td>
                                                                                        <td align="right">
                                                                                            <asp:Label ID="lblTotalOfPayments" runat="server" CssClass="AR_Application" DataFieldName="TotalOfPayments">
                                                                                            </asp:Label>
                                                                                        </td>
                                                                                    </tr>
                                                                                    <tr>
                                                                                        <td>
                                                                                            <asp:Label ID="Label28" runat="server" Text="Monthly Payment: " CssClass="AR_Application"></asp:Label>
                                                                                        </td>
                                                                                        <td align="right">
                                                                                            <asp:Label ID="lblMonthlyPayment" runat="server" CssClass="AR_Application" DataFieldName="MonthlyPayment">
                                                                                            </asp:Label>
                                                                                        </td>
                                                                                    </tr>
                                                                                    <tr>
                                                                                        <td>
                                                                                            <asp:Label ID="Label29" runat="server" Text="Annual % Rate:" CssClass="AR_Application"></asp:Label>
                                                                                        </td>
                                                                                        <td align="right">
                                                                                            <asp:Label ID="lblAnnualRate" runat="server" DataFieldName="AnnualRate" CssClass="AR_Application">
                                                                                            </asp:Label>
                                                                                        </td>
                                                                                    </tr>
                                                                                </tbody>
                                                                            </table>
                                                                        </td>
                                                                    </tr>
                                                                </tbody>
                                                            </table>
                                                            <!--END FINANCE TABLE-->
                                                        </ContentTemplate>
                                                        <Triggers>
                                                            <asp:AsyncPostBackTrigger ControlID="financebtn2" EventName="Click" />
                                                        </Triggers>
                                                    </asp:UpdatePanel>
                                                </td>
                                            </tr>
                                        </tbody>
                                    </table>
                                     <table id="PrimeRateFinanceDetails" style="display: none">
                                        <tbody>
                                            <tr>
                                                <td>
                                                    <asp:UpdatePanel ID="PrimeRateUpdatePanel" runat="server" UpdateMode="Conditional">
                                                        <ContentTemplate>
                                                            <!--FINANCE TABLE-->
                                                            <table>
                                                                <tbody>
                                                                    <tr>
                                                                        <td>
                                                                            <table>
                                                                                <tbody>
                                                                                     <tr>
                                                                                        <td>
                                                                                            <asp:Label ID="Label31" runat="server" Text="Prime Rate financing options:" Font-Bold="True"></asp:Label>
                                                                                        </td>
                                                                                    </tr>
                                                                                    <tr>
                                                                                        <td>
                                                                                            <asp:Label ID="Label30" runat="server" Text="Payment Plan:" Font-Bold="True"></asp:Label>
                                                                                        </td>
                                                                                    </tr>
                                                                                    <tr>
                                                                                        <td>
                                                                                            <asp:RadioButtonList ID="PrimeRateDP" runat="Server" ClientIDMode="Static">
                                                                                                <asp:ListItem Text="25% Down" Value="25% Down"></asp:ListItem>
                                                                                                <asp:ListItem Text="40% Down" Value="40% Down"></asp:ListItem>
                                                                                                <asp:ListItem Text="50% Down" Value="50% Down"></asp:ListItem>
                                                                                            </asp:RadioButtonList>
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
                                                                                            <asp:Label ID="PrimeRateFinanceInfo" runat="server" Text="" CssClass="AR_Application"></asp:Label>&nbsp;
                                                                                        </td>
                                                                                        
                                                                                </tbody>
                                                                            </table>
                                                                        </td>
                                                                    </tr>
                                                                </tbody>
                                                            </table>
                                                            <!--END FINANCE TABLE-->
                                                        </ContentTemplate>
                                                        <Triggers>
                                                            <asp:AsyncPostBackTrigger ControlID="financebtn2" EventName="Click" />
                                                        </Triggers>
                                                    </asp:UpdatePanel>
                                                </td>
                                            </tr>
                                        </tbody>
                                    </table>
                                </td>
                            </tr>
                        </tbody>
                    </table>
                </td>
            </tr>
            <tr>
                <td>
                    <table title="Status">
                        <tbody>
                            <tr style="border-bottom: 1px; border-bottom-color: Black">
                                <td colspan="2" align="left">
                                    <asp:Label ID="Label135" runat="server" Text="Status" CssClass="AR_Application"></asp:Label>
                                    &nbsp;
                                    <asp:Label ID="AppStatuslbl" runat="server" Text="Eligible" Style="font-size: x-large;
                                        font-weight: 700"></asp:Label>
                                </td>
                                <td>
                                    <asp:Button ID="overridebtn" runat="server" Text="OverRide" Visible="false"/>
                                    <dx:ASPxPopupControl ID="ASPxPopupControl2" runat="server" PopupElementID="overridebtn" AllowDragging="True" HeaderText = "OverRide Submit to UW reason:"
                                                                          MaxWidth="800px" MaxHeight="1800px" MinHeight="150px" MinWidth="150px" ShowFooter="True" Width="250px" Height="130px" CloseAction="CloseButton" >
                                        <ContentCollection>
                                            <dx:PopupControlContentControl ID="PopupControlContentControl2" runat="server" SupportsDisabledAttribute="True">
                                            <table width="100%">
                                            <tr>
                                            <td>
                                                <asp:TextBox ID="OVreasontxt" runat="server" TextMode="MultiLine" Height="100%" Width="100%"></asp:TextBox>
                                            </td>
                                            </tr>
                                            <tr><td>
                                                <asp:Button ID="OVprint" runat="server" Text="Print App" />
                                            </td></tr>
                                            </table>
                                            </dx:PopupControlContentControl>
                                        </ContentCollection>
                                    </dx:ASPxPopupControl>
                                </td>
                                <hr />
                            </tr>
                        </tbody>
                    </table>
                </td>
            </tr>
            <tr>
                <td>
                    <asp:Button runat="server" ID="printBtn" Text="Print Application" OnClick="printApp"
                        TabIndex="90" />
                    <dx:ASPxPopupControl ID="ASPxPopupControl1" runat="server" Width="423px" HeaderText="Status">
                        <ContentCollection>
                            <dx:PopupControlContentControl ID="PopupControlContentControl1" runat="server" SupportsDisabledAttribute="True">
                                <asp:Label ID="Label173" runat="server" Text="Label"></asp:Label>
                            </dx:PopupControlContentControl>
                        </ContentCollection>
                    </dx:ASPxPopupControl>
                    <div style="display: none">
                        <asp:Button ID="btnvalidate" runat="server" Text="Button" Width="0" />
                        <asp:Label ID="labelapp" runat="server" Text="Label" Visible="false"></asp:Label>
                        <asp:Button ID="btnprior" runat="server" Text="Button" Width="0" />
                        <asp:Label ID="lbllapse" runat="server" Text="" Visible="false"></asp:Label>
                    </div>
                    <div style="float: left; margin-left: 2%" id="summaryContainer">
                        <dx:ASPxValidationSummary ID="vsValidationSummary1" runat="server" RenderMode="BulletedList"
                            Width="250px" ClientInstanceName="validationSummary" ShowErrorsInEditors="True">
                        </dx:ASPxValidationSummary>
                    </div>
                </td>
            </tr>
            <%--<asp:Label ID="lblfocus" runat="server" Text=""  Style="display: none"></asp:Label>--%>
            <asp:HiddenField id="lblfocus" runat="server" value="" />
        </tbody>
    </table>
    <hr />
    <br />
</asp:Content>
<asp:Content ID="Content3" runat="server" ContentPlaceHolderID="head">
    <style type="text/css">
        .style3
        {
            font-size: small;
            font-weight: bold;
            color: Gray;
        }
    </style>
</asp:Content>
