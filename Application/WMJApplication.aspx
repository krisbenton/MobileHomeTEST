<%@ Page Title="Windsor-Mount Joy Application" Language="vb" AutoEventWireup="false" MasterPageFile="~/IntPage.Master" CodeBehind="WMJApplication.aspx.vb" Inherits="MobileHomeRater.WMJApplication" %>
<%@ Register assembly="DevExpress.Web.v13.1, Version=13.1.8.0, Culture=neutral, PublicKeyToken=b88d1754d700e49a" namespace="DevExpress.Web.ASPxEditors" tagprefix="dx" %>

<%@ Register assembly="DevExpress.Web.v13.1, Version=13.1.8.0, Culture=neutral, PublicKeyToken=b88d1754d700e49a" namespace="DevExpress.Web.ASPxPopupControl" tagprefix="dx" %>


<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolderMenu" runat="server">
    <script type="text/javascript">
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
        function zipcodeKeyDown6() {
            if (document.getElementById('<%=txttitleZip.ClientID%>').value.length == 5) {
                document.getElementById('<%=txttitleZip.ClientID%>').value = document.getElementById('<%=txttitleZip.ClientID%>').value;
                document.getElementById('<%=zipbtn6.ClientID%>').click();
            }
            document.getElementById('<%=txttitleZip.ClientID%>').value = document.getElementById('<%=txttitleZip.ClientID%>').value;
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
                 <asp:button ID="findimport" runat="server" style="top: 0px; left: -15px; width:150px; height:30px; border: 1px solid #808080;" text="Find Imported Quote" />
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
    <td> <asp:Label ID="Label2" runat="server" Text="Quote #" Font-Size="Large"></asp:Label>
    </td>
       <td> <asp:Label ID="Label3" runat="server" Text="Program" Font-Size="Large"></asp:Label>
    </td>
       <td> <asp:Label ID="Label4" runat="server" Text="Carrier" Font-Size="Large"></asp:Label>
    </td>
    <td> <asp:Label ID="Label18" runat="server" Text="Term" Font-Size="Large"></asp:Label>
    </td>
     <td> <asp:Label ID="Label25" runat="server" Text="Effective Dates" Font-Size="Large"></asp:Label>
    </td>
    </tr>
     <tr border="5">
    <td> <asp:Label ID="lblQuoteNumber" runat="server" Text="Quote #" Font-Size="Large"></asp:Label>
    </td>
       <td> <asp:Label ID="lblProgram" runat="server" Text="Program" Font-Size="Large"></asp:Label>
    </td>
       <td> <asp:Label ID="lblCarrier" runat="server" Text="Carrier" Font-Size="Large"></asp:Label>
    </td>
    <td> <asp:Label ID="lblTerm" runat="server" Text="Term" Font-Size="Large"></asp:Label>
    </td>
     <td> <asp:Label ID="lblEffDates" runat="server" Text="Effective Dates" Font-Size="Large"></asp:Label>
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
                                    <asp:TextBox ID="txtAppNumber" runat="server" Text="NULL" style="display:none" ></asp:TextBox>
                                    <asp:TextBox ID="txtQuoteID" runat="server" Text="NULL" style="display:none" ></asp:TextBox>
                                </td>
                                <hr />
                            </tr>
                            <tr align="left" style="border: 1px solid">
                                <td align="right">
                                    <asp:Label ID="Label5" runat="server" Text="Name:" CssClass="AR_Application"></asp:Label>
                                </td>
                                <td>
                                <dx:ASPxTextBox ID="txtName" runat="server" Width="200px" CssFilePath="../Styles/Site.css" TabIndex="1" >
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
                                 <dx:ASPxTextBox ID="txtDOB" runat="server" Width="200px" CssFilePath="../Styles/Site.css" TabIndex="2" >
                                      <ValidationSettings>
                                    <RequiredField IsRequired="True" ErrorText="DOB is required" />
                                    <RegularExpression ValidationExpression="^((((0[13578])|(1[02]))[\/]?(([0-2][0-9])|(3[01])))|(((0[469])|(11))[\/]?(([0-2][0-9])|(30)))|(02[\/]?[0-2][0-9]))[\/]?\d{4}$" ErrorText="DOB is Wrong Format" />
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
                                    
                                     
                                     <dx:ASPxTextBox ID="txtPhone2" runat="server" Width="130" TabIndex="3" >
                                    <MaskSettings Mask="(999) 000-0000" IncludeLiterals="None"/>
                                    <ValidationSettings SetFocusOnError="false" ErrorDisplayMode="Text">
                                        <RequiredField IsRequired="True" ErrorText="Phone Number Required" />
                                    </ValidationSettings>
                                      </dx:ASPxTextBox>
                                </td>
                               
                                <td align="right">
                                    <asp:Label ID="Label13" runat="server" Text="Occupation:" CssClass="AR_Application"></asp:Label>
                                </td>
                                <td>
                                 <dx:ASPxTextBox ID="txtOcc" runat="server" Width="200px" CssFilePath="../Styles/Site.css" TabIndex="4" >
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
                                    
                                    <dx:ASPxTextBox ID="txtSSN2" runat="server" Width="130" TabIndex="5" >
                                     <ValidationSettings SetFocusOnError="true">
                                        <RequiredField IsRequired="True" ErrorText="Social Security Is Required" />
                                         <RegularExpression ValidationExpression="^((\d{3}-?\d{2}-?\d{4})|(X{3}-?X{2}-?X{4}))$" ErrorText="Social Security Format" />

                                    </ValidationSettings>
                                    <MaskSettings Mask="999-99-9999" IncludeLiterals="None" />

                                    </dx:ASPxTextBox>
                                   
                                </td>
                            </tr>
                            <tr>
                            <td align="right">
                                    <asp:Label ID="Label30" runat="server" Text="Employer:" CssClass="AR_Application"></asp:Label>
                                </td>
                                <td>
                                 <dx:ASPxTextBox ID="txtemployer" runat="server" Width="200px" CssFilePath="../Styles/Site.css" TabIndex="6" >
                                       <ValidationSettings>
                                        <RequiredField IsRequired="True" ErrorText="Employer is required" />
                                        <RegularExpression ValidationExpression=".{2,}" ErrorText="Employer should contain at least two letters" />
                                       </ValidationSettings>
                                    </dx:ASPxTextBox>
                                   
                                </td>
                                <td align="right">
                                    <asp:Label ID="Label31" runat="server" Text="Years Employeed:" CssClass="AR_Application"></asp:Label>
                                </td>
                                <td>
                                 <dx:ASPxTextBox ID="txtemployedyears" runat="server" Width="200px" CssFilePath="../Styles/Site.css" TabIndex="7" >
                                       <ValidationSettings>
                                        <RequiredField IsRequired="True" ErrorText="Employed is required" />
                                        <RegularExpression ValidationExpression=".{1,}" ErrorText="Employeed years should contain at least a number" />
                                       </ValidationSettings>
                                    </dx:ASPxTextBox>
                                   
                                </td>
                            </tr>
                             <tr>
                                <td align="right">
                                    <asp:Label ID="Label15" runat="server" Text="Co-Applicant Name:" CssClass="AR_Application"></asp:Label>
                                </td>
                                <td>
                                    <asp:TextBox style="text-transform:uppercase" ID="txtSpouseName" runat="server" 
                                        Text="" TabIndex="8"></asp:TextBox>
                                </td>
                                <td align="right">
                                    <asp:Label ID="Label16" runat="server" Text="Co-Applicant SSN:" CssClass="AR_Application"></asp:Label>
                                </td>
                                <td>
                                    
                                     <dx:ASPxTextBox ID="txtSpouseSSN" runat="server" Width="130" TabIndex="9" >

                                    <MaskSettings Mask="000-00-0000" IncludeLiterals="None" />

                                    </dx:ASPxTextBox>
                                </td>
                                <td align="right">
                                    <asp:Label ID="Label17" runat="server" Text=" Co-Applicant DOB:" CssClass="AR_Application"></asp:Label>
                                </td>
                                <td>
                                     <dx:ASPxTextBox ID="txtSpouseDOB" runat="server" Width="130" 
                                           TabIndex="10" >
                                    <MaskSettings Mask="00/00/0000" IncludeLiterals="None" />
                                    </dx:ASPxTextBox>
                                </td>
                                <td align="right">
                                    <asp:Label ID="Label26" runat="server" Text="Co-Phone No:" CssClass="AR_Application"></asp:Label>
                                </td>
                                <td>
                                    
                                     
                                     <dx:ASPxTextBox ID="CoPhone" runat="server" Width="130" TabIndex="11" >
                                    <MaskSettings Mask="(999) 000-0000" IncludeLiterals="None"/>
                                    <ValidationSettings SetFocusOnError="false" ErrorDisplayMode="Text">
                                        <RequiredField IsRequired="False" ErrorText="Phone Number Required" />
                                    </ValidationSettings>
                                      </dx:ASPxTextBox>
                                </td>
                                <td align="right">
                                    <asp:Label ID="Label50" runat="server" Text="Co-Occupation:" CssClass="AR_Application"></asp:Label>
                                </td>
                                <td>
                                 <dx:ASPxTextBox ID="txtCoOcc" runat="server" Width="200px" CssFilePath="../Styles/Site.css" TabIndex="4" >
                                       <ValidationSettings>
                                        <RequiredField IsRequired="false" ErrorText="Co-Occupation is required" />
                                        <RegularExpression ValidationExpression=".{2,}" ErrorText="Occupation should contain at least two letters" />
                                       </ValidationSettings>
                                    </dx:ASPxTextBox>
                                    <%--<asp:TextBox ID="txtOcc" runat="server" Text="" 
                                        style="text-transform:uppercase" TabIndex="4"></asp:TextBox>
                                    <asp:RequiredFieldValidator ID="RequiredFieldValidator3" ControlToValidate="txtOcc"
                                            runat="server" Text="* Req Field"></asp:RequiredFieldValidator>--%>
                                </td>
                            </tr>
                             <tr>
                                <td align="right">
                                    <asp:Label ID="Label35" runat="server" Text="Agent Name:" CssClass="AR_Application"></asp:Label>
                                </td>
                                <td>
                                     <dx:ASPxTextBox ID="txtAgentName" runat="server" Width="200px" CssFilePath="../Styles/Site.css" TabIndex="12" >
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
                                    <asp:TextBox style="text-transform:uppercase" ID="txtParkName" runat="server" 
                                        Text="" TabIndex="13"></asp:TextBox>
                                </td>
                            </tr>
                            <tr id="RentName">
                                <td align="right">
                                    <asp:Label ID="Label61" runat="server" Text="Tenant Name:" CssClass="AR_Application"></asp:Label>
                                </td>
                                <td>
                                    <asp:TextBox style="text-transform:uppercase" ID="txtRenterName" runat="server" 
                                        Text="" TabIndex="14"></asp:TextBox>
                                </td>
                            </tr>
                            <tr>
                                <td>
                                    <br />
                                </td>
                                <td>
                                    &nbsp;</td>
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
                                <dx:ASPxTextBox ID="txtDiffAppAddr" runat="server" CssFilePath="../Styles/Site.css" TabIndex="15" Width="100%">
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
                                    <asp:TextBox ID="txtDiffAppZip" runat="server" Width="50px" Text="" 
                                        TabIndex="16"></asp:TextBox>
                                    <asp:Button ID="zipbtn1" Text="getZip" runat="server" CausesValidation="false" Style="display: none" />
                                </td>
                                 <asp:RequiredFieldValidator ID="RequiredFieldValidator10" ControlToValidate="txtdiffAppZip"
                                            runat="server" Text="* Req Field"></asp:RequiredFieldValidator>
                                <td align="right">
                                    <asp:Label ID="Label21" runat="server" Text="City:" CssClass="AR_Application"></asp:Label>
                                </td>
                                <td>
                                    <asp:TextBox style="text-transform:uppercase" ID="txtDiffAppCity" 
                                        runat="server" Text="" TabIndex="17" ></asp:TextBox>
                                    </td>
                                <asp:RequiredFieldValidator ID="RequiredFieldValidator8" ControlToValidate="txtDiffAppCity"
                                            runat="server" Text="* Req Field"></asp:RequiredFieldValidator>
                                <td align="right">
                                    <asp:Label ID="Label22" runat="server" Text="State:" CssClass="AR_Application"></asp:Label>
                                </td>
                                <td>
                                    <dx:ASPxTextBox ID="txtDiffAppState" runat="server" CssFilePath="../Styles/Site.css" TabIndex="18" Width="100%">
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
                                    <asp:TextBox style="text-transform:uppercase" ID="txtDiffAppCounty" runat="server" Text=""></asp:TextBox>
                                </td>
                                 <asp:RequiredFieldValidator ID="RequiredFieldValidator12" ControlToValidate="txtDiffAppCounty"
                                            runat="server" Text="* Req Field"></asp:RequiredFieldValidator>
                                <td align="right">
                                    <asp:Label ID="Label27" runat="server" Text="Territory:" CssClass="AR_Application"></asp:Label>
                                </td>

                                <td>
                                    <asp:TextBox style="text-transform:uppercase" ID="txtTerritory1" runat="server" Text=""></asp:TextBox>
                                </td>
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
                                    <asp:CheckBox ID="DupLocation" runat="server" AutoPostBack="true" 
                                        Text="Mailing Address Same as Location" 
                                        OnCheckedChanged="DupLocation_CheckedChanged" TabIndex="19"/>
                                </td>
                            </tr>
                            <tr>
                                <td align="right">
                                    <asp:Label ID="Label7" runat="server" Text="Address:" CssClass="AR_Application"></asp:Label>
                                </td>
                                <td colspan="3">
                                 <dx:ASPxTextBox ID="txtAddress" runat="server" CssFilePath="../Styles/Site.css" TabIndex="20" Width="100%">
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
                                    <asp:TextBox ID="txtZip" runat="server" Width="50px" Text="" TabIndex="21"></asp:TextBox>
                                    <asp:Button ID="zipbtn2" Text="getZip" runat="server" CausesValidation="false" Style="display: none" />
                                </td>
                                <td align="right">
                                    <asp:Label ID="Label8" runat="server" Text="City:" CssClass="AR_Application"></asp:Label>
                                </td>
                                <td>
                                    <asp:TextBox style="text-transform:uppercase" ID="txtCity" runat="server" 
                                        Text="" TabIndex="22"></asp:TextBox>
                                </td>
                                <td align="right">
                                    <asp:Label ID="Label9" runat="server" Text="State:" CssClass="AR_Application"></asp:Label>
                                </td>
                                <td>
                                    <asp:TextBox style="text-transform:uppercase" ID="txtState" runat="server" Width="25px" Text=""></asp:TextBox>
                                </td>
                                
                                <td align="right">
                                    <asp:Label ID="Label11" runat="server" Text="County:" CssClass="AR_Application"></asp:Label>
                                </td>
                                <td>
                                    <asp:TextBox style="text-transform:uppercase" ID="txtCounty" runat="server" Text=""></asp:TextBox>
                                </td>
                                <td align="right">
                                    <asp:Label ID="Label28" runat="server" Text="Territory:" CssClass="AR_Application"></asp:Label>
                                </td>

                                <td>
                                    <asp:TextBox style="text-transform:uppercase" ID="txtTerritory2" runat="server" Text=""></asp:TextBox>
                                </td>
                            </tr>
                            <tr>
                                <td colspan="2" align="right">
                                    <asp:Label ID="Label32" runat="server" Text="Distance from Gulf or Atlantic Coastal Water" CssClass="AR_Application"></asp:Label>
                                </td>
                                <td align="left" colspan=2>
                                <dx:ASPxTextBox ID="txtDistToGulf" runat="server" CssFilePath="../Styles/Site.css" TabIndex="23" Width="100%">
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
                            <tr style="border-bottom: 1px; border-bottom-color: Black">
                                <td colspan="2" align="left">
                                    <span class="style3">Additional Insured</span>
                                </td>
                            </tr>
                            <tr>
                                <td align="right">
                                    <asp:Label ID="Label292" runat="server" Text="Name:" CssClass="AR_Application"></asp:Label>
                                </td>
                                <td colspan="3">
                                <dx:ASPxTextBox ID="txttitlename" runat="server" CssFilePath="../Styles/Site.css" TabIndex="24" Width="100%">
                                       <ValidationSettings>
                                        <RequiredField IsRequired="False" ErrorText="Name is required" />
                                        <RegularExpression ValidationExpression=".{4,}" ErrorText="Name should contain at least 4 letters" />
                                       </ValidationSettings>
                                    </dx:ASPxTextBox>
                                    <%--<asp:TextBox style="text-transform:uppercase" ID="txttitlename" Width="100%" 
                                        runat="server" Text="" TabIndex="11"></asp:TextBox>--%>
                                    
                                </td>
                                
                            </tr>
                            <tr>
                                <td align="right">
                                    <asp:Label ID="Label202" runat="server" Text="Address:" CssClass="AR_Application"></asp:Label>
                                </td>
                                <td colspan="3">
                                <dx:ASPxTextBox ID="txttitleaddress" runat="server" CssFilePath="../Styles/Site.css" TabIndex="25" Width="100%">
                                       <ValidationSettings>
                                        <RequiredField IsRequired="False" ErrorText="Address is required" />
                                        <RegularExpression ValidationExpression=".{4,}" ErrorText="Address should contain at least 4 letters" />
                                       </ValidationSettings>
                                    </dx:ASPxTextBox>
                                    <%--<asp:TextBox style="text-transform:uppercase" ID="txttitleaddress" Width="100%" 
                                        runat="server" Text="" TabIndex="11"></asp:TextBox>--%>
                                    
                                </td>
                                
                            </tr>
                            <tr align="left">
                            <td align="right">
                                    <asp:Label ID="Label232" runat="server" Text="Zip:" CssClass="AR_Application"></asp:Label>
                                </td>
                                <td>
                                    <asp:TextBox ID="txttitleZip" runat="server" Width="50px" Text="" 
                                        TabIndex="26"></asp:TextBox>
                                    <asp:Button ID="zipbtn6" Text="getZip" runat="server" CausesValidation="false" Style="display: none" />
                                </td>
                                 <td>
                                    <asp:Label ID="Label212" runat="server" Text="City:" CssClass="AR_Application"></asp:Label>
                                </td>
                                <td>
                                    <asp:TextBox style="text-transform:uppercase" ID="txttitlecity" 
                                        runat="server" Text="" TabIndex="27" ></asp:TextBox>
                                    </td>
                                
                                <td align="right">
                                    <asp:Label ID="Label222" runat="server" Text="State:" CssClass="AR_Application"></asp:Label>
                                </td>
                                <td>
                                    <dx:ASPxTextBox ID="txttitlestate" runat="server" CssFilePath="../Styles/Site.css" TabIndex="28" Width="100%">
                                       <ValidationSettings>
                                        <RequiredField IsRequired="false" ErrorText="State is required" />
                                        <RegularExpression ValidationExpression=".{2,}" ErrorText="State should contain at least 2 letters" />
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
                                    <asp:TextBox ID="txtDescMHYear" runat="server" Text="" TabIndex="29"></asp:TextBox>
                                </td>
                                <td align="right">
                                    <asp:Label ID="Label34" runat="server" Text="Manufacturer:" CssClass="AR_Application"></asp:Label>
                                </td>
                                <td>
                                    <asp:TextBox style="text-transform:uppercase" ID="txtDescMHManf" runat="server" 
                                        Width="" Text="" TabIndex="30"></asp:TextBox>
                                </td>
                                 <td align="right">
                                    <asp:Label ID="Label29" runat="server" Text="Model:" CssClass="AR_Application"></asp:Label>
                                </td>
                                <td>
                                    <asp:TextBox style="text-transform:uppercase" ID="txtmodel" runat="server" 
                                        Width="" Text="" TabIndex="31"></asp:TextBox>
                                </td>
                                <td align="right">
                                    <asp:Label ID="Label36" runat="server" Text="Length:" CssClass="AR_Application"></asp:Label>
                                </td>
                                <td>
                                    <asp:TextBox ID="txtDescMHLength" runat="server" Width="50px" Text="" 
                                        TabIndex="32"></asp:TextBox>
                                </td>
                                <td align="right">
                                    <asp:Label ID="Label37" runat="server" Text="Width:" CssClass="AR_Application"></asp:Label>
                                </td>
                                <td>
                                    <asp:TextBox ID="txtDescMHWidth" runat="server" Width="50px" Text="" 
                                        TabIndex="33"></asp:TextBox>
                                </td>
                            </tr>
                            <tr>
                                <td align="right">
                                    <asp:Label ID="Label38" runat="server" Text="Serial Number:" CssClass="AR_Application"></asp:Label>
                                </td>
                                <td align="left">
                                    <dx:ASPxTextBox ID="txtDescMHSerial" runat="server" CssFilePath="../Styles/Site.css" TabIndex="34" Width="100%">
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
                                   
                                       <dx:ASPxTextBox ID="txtDescMHPurDate2" runat="server" Width="130px" 
                                           TabIndex="35" >
                                    <MaskSettings Mask="99/99/9999" IncludeLiterals="None" />
                                    <ValidationSettings SetFocusOnError="True" >
                                        <RequiredField IsRequired="True" ErrorText="Purchase Date Required" />
                                        <RegularExpression ValidationExpression="^((((0[13578])|(1[02]))[\/]?(([0-2][0-9])|(3[01])))|(((0[469])|(11))[\/]?(([0-2][0-9])|(30)))|(02[\/]?[0-2][0-9]))[\/]?\d{4}$" ErrorText="Purchase Date is Wrong Format" />
                                    </ValidationSettings>
                                    </dx:ASPxTextBox>
                                    
                                </td>
                                <td align="right">
                                    <asp:Label ID="Label40" runat="server" Text="Purchase Price:" CssClass="AR_Application"></asp:Label>
                                </td>
                                <td align="left">
                                   
                                       <dx:ASPxTextBox ID="txtDescMHPurPrice2" runat="server" Width="130" 
                                           TabIndex="36" >
                                    <MaskSettings Mask="$<0..99999g>.<00..99>" IncludeLiterals="DecimalSymbol" />
                                    <ValidationSettings SetFocusOnError="true" ErrorDisplayMode="ImageWithTooltip">
                                    <RequiredField IsRequired="True" ErrorText="Purchased Price is Required" />
                                    </ValidationSettings>
                                    </dx:ASPxTextBox>
                                </td>
                                <td align="right">
                                    <asp:Label ID="Label41" runat="server" Text="Current Date:" CssClass="AR_Application"></asp:Label>
                                </td>
                                <td align="left">
                                    
                                    <dx:ASPxTextBox ID="txtDescMHCurDate2" runat="server" Width="130" >
                                    <MaskSettings Mask="00/00/0000" IncludeLiterals="None" />
                                    <ValidationSettings SetFocusOnError="false" ErrorDisplayMode="Text">
                                        <RequiredField IsRequired="True" ErrorText="Current Date Required" />
                                    </ValidationSettings>

                                    </dx:ASPxTextBox>
                                </td>
                            </tr>
                            <tr>
                                <td align="right">
                                    <asp:Label ID="Label42" runat="server" Text="Describe Additions/<br/>Attached Structures:" CssClass="AR_Application"></asp:Label>
                                </td>
                                <td align="left">
                                    <asp:TextBox style="text-transform:uppercase" ID="txtDescMHAttStruc" 
                                        runat="server" Width="200px" Text="" TabIndex="37"></asp:TextBox>
                                </td>
                                <td align="right">
                                    <asp:Label ID="Label43" runat="server" Text="Age:" CssClass="AR_Application"></asp:Label>
                                </td>
                                <td align="left">
                                    <asp:TextBox style="text-transform:uppercase" ID="txtDescMHAttStrucAge" 
                                        runat="server" Width="75px" Text="" TabIndex="38"></asp:TextBox>
                                </td>
                                <td align="right">
                                    <asp:Label ID="Label44" runat="server" Text="Size:" CssClass="AR_Application"></asp:Label>
                                </td>
                                <td align="left">
                                    <asp:TextBox style="text-transform:uppercase" ID="txtDescMHAttStrucSize" 
                                        runat="server" Width="75px" Text="" TabIndex="39"></asp:TextBox>
                                </td>
                                <td align="right">
                                    <asp:Label ID="Label45" runat="server" Text="Current Value:" CssClass="AR_Application"></asp:Label>
                                </td>
                                <td align="left">
                                   
                                    
                                       <dx:ASPxTextBox ID="txtDescMHAttStrucCurVal2" runat="server" Width="130" 
                                           TabIndex="40" >
                                    <MaskSettings Mask="$<0..99999g>.<00..99>" IncludeLiterals="DecimalSymbol" />
                                    <ValidationSettings SetFocusOnError="false" ErrorDisplayMode="Text">
                                        <RequiredField IsRequired="True" ErrorText="Current Value Required" />
                                    </ValidationSettings>


                                    </dx:ASPxTextBox>
                                </td>
                                <td align="right">
                                    <asp:Label ID="Label67" runat="server" Text="Professional built:" CssClass="AR_Application"></asp:Label>
                                </td>
                                <td>
                                 <dx:ASPxComboBox ID="ddprofbuilt" runat="server" ValueType="System.String" DropDownStyle="DropDown" TabIndex="45">
                                 <Items>
                                 <dx:ListEditItem Text="" Value= "" />
                                 <dx:ListEditItem Text="Yes" Value= "Yes" />
                                 <dx:ListEditItem Text="No" Value= "No" />
                                 </Items>
                               </dx:ASPxComboBox>
                               </td>
                            </tr>
                            <tr>
                                <td align="right">
                                    <asp:Label ID="Label46" runat="server" Text="Describe Unattached<br/> Structures:" CssClass="AR_Application"></asp:Label>
                                </td>
                                <td align="left">
                                    <asp:TextBox style="text-transform:uppercase" ID="txtDescMHUnAttStruc" 
                                        runat="server" Width="200px" Text="" TabIndex="41"></asp:TextBox>
                                </td>
                                <td align="right">
                                    <asp:Label ID="Label47" runat="server" Text="Age:" CssClass="AR_Application"></asp:Label>
                                </td>
                                <td align="left">
                                    <asp:TextBox ID="txtDescMHUnAttStrucAge" runat="server" Width="75px" Text="" 
                                        TabIndex="42"></asp:TextBox>
                                </td>
                                <td align="right">
                                    <asp:Label ID="Label48" runat="server" Text="Size:" CssClass="AR_Application"></asp:Label>
                                </td>
                                <td align="left">
                                    <asp:TextBox ID="txtDescMHUnAttStrucSize" runat="server" Width="75px" Text="" 
                                        TabIndex="43"></asp:TextBox>
                                </td>
                                <td align="right">
                                    <asp:Label ID="Label49" runat="server" Text="Current Value:" CssClass="AR_Application"></asp:Label>
                                </td>
                                <td align="left">
                                   
                                      <dx:ASPxTextBox ID="txtDescMHUnAttStrucCurVal2" runat="server" Width="130" 
                                          TabIndex="44" >
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
                                    <asp:Label ID="Label52" runat="server" Text="Usage:" CssClass="AR_Application"></asp:Label>
                                </td>
                                <td>
                                 <dx:ASPxComboBox ID="ddUsage" runat="server" ValueType="System.String" DropDownStyle="DropDown" TabIndex="45">
                                 <Items>
                                 <dx:ListEditItem Text="Owner" Value= "Owner" />
                                 <dx:ListEditItem Text="Seasonal" Value= "Seasonal" />
                                 <dx:ListEditItem Text="Rental" Value= "Rental" />
                                 <dx:ListEditItem Text="Tenant" Value= "Tenant" />
                                 <dx:ListEditItem Text="Vacant" Value= "Vacant" />
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
                                 <dx:ASPxComboBox ID="ddMHAge" runat="server" ValueType="System.String" DropDownStyle="DropDown" TabIndex="46">
                                 <Items>
                                 <dx:ListEditItem Text="1-5 Yrs" Value= "1-5 Yrs" />
                                 <dx:ListEditItem Text="6-15 Yrs" Value= "6-15 Yrs" />
                                 <dx:ListEditItem Text="16 Yrs & Older" Value= "16 Yrs & Older" />
                                 
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
                                <dx:ASPxComboBox ID="ddlossHist" runat="server" ValueType="System.String" DropDownStyle="DropDown" TabIndex="47">
                                 <Items>
                                 <dx:ListEditItem Text="" Value= "" />
                                 <dx:ListEditItem Text="Yes" Value= "Yes" />
                                 <dx:ListEditItem Text="No" Value= "No" />
                                 
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
                                    <asp:Label ID="Label57" runat="server" Text="Home Occupied by Insured Fulltime:" CssClass="AR_Application"></asp:Label>
                              
                                </td>
                                <td>
                                 <dx:ASPxComboBox ID="ddfulltimeStatus" runat="server" ValueType="System.String" DropDownStyle="DropDown" TabIndex="50">
                                 <Items>
                                 <dx:ListEditItem Text="" Value= "" />
                                 <dx:ListEditItem Text="Yes" Value= "Yes" />
                                 <dx:ListEditItem Text="No" Value= "No" />
                                 
                                 </Items>
                               </dx:ASPxComboBox>
                                    
                                </td>
                            </tr>
                            
                            
                          <tr align="left">
                                <td align="right">
                                    <asp:Label ID="Label51" runat="server" Text="Is Home on Continuous masonary foundation:" CssClass="AR_Application"></asp:Label>
                              
                                </td>
                                <td>
                                 <dx:ASPxComboBox ID="ddfoundation" runat="server" ValueType="System.String" DropDownStyle="DropDown" TabIndex="50">
                                 <Items>
                                 <dx:ListEditItem Text="" Value= "" />
                                 <dx:ListEditItem Text="Yes" Value= "Yes" />
                                 <dx:ListEditItem Text="No" Value= "No" />
                                 
                                 </Items>
                               </dx:ASPxComboBox>
                                    
                                </td>
                            </tr>
                            <tr align="left">
                                <td align="right">
                                    <asp:Label ID="Label53" runat="server" Text="Is skirting vinyl or brick?:" CssClass="AR_Application"></asp:Label>
                              
                                </td>
                                <td>
                                 <dx:ASPxComboBox ID="ddskirting" runat="server" ValueType="System.String" DropDownStyle="DropDown" TabIndex="50">
                                 <Items>
                                 <dx:ListEditItem Text="" Value= "" />
                                 <dx:ListEditItem Text="Vinyl" Value= "Vinyl" />
                                 <dx:ListEditItem Text="Brick" Value= "Brick" />
                                 
                                 </Items>
                               </dx:ASPxComboBox>
                                    
                                </td>
                            </tr>
                            <tr align="left">
                                <td align="right">
                                    <asp:Label ID="Label54" runat="server" Text="If qualifying pool:" CssClass="AR_Application"></asp:Label>
                              
                                </td>
                                <td>
                                 <dx:ASPxComboBox ID="ddpool" runat="server" ValueType="System.String" DropDownStyle="DropDown" TabIndex="50">
                                 <Items>
                                 <dx:ListEditItem Text="" Value= "" />
                                 <dx:ListEditItem Text="Above Ground" Value= "Above" />
                                 <dx:ListEditItem Text="Below Ground" Value= "Below" />
                                 
                                 </Items>
                               </dx:ASPxComboBox>
                                    
                                </td>
                            </tr>
                            <tr align="left">
                                <td align="right">
                                    <asp:Label ID="Label62" runat="server" Text="Unit Type:" CssClass="AR_Application"></asp:Label>
                                </td>
                                <td>
                                 <dx:ASPxComboBox ID="ddUnitType" runat="server" ValueType="System.String" DropDownStyle="DropDown" TabIndex="55">
                                 <Items>
                                 <dx:ListEditItem Text="" Value= "" />
                                 <dx:ListEditItem Text="Singlewide" Value= "Singlewide" />
                                 <dx:ListEditItem Text="Doublewide" Value= "Doublewide" />
                                  <dx:ListEditItem Text="Other" Value= "Other" />
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
                                    <asp:TextBox style="text-transform:uppercase" ID="txtLien1Name" runat="server" 
                                        Text="" TabIndex="56"></asp:TextBox>
                                </td>
                                <td>
                                 <asp:Label ID="Label64" runat="server" Text="Bill Lienholder at renewal:" CssClass="AR_Application"></asp:Label>
                                </td>
                                <td>
		                            <dx:ASPxComboBox ID="billLienholder" runat="server" ValueType="System.String" Width="50"  DropDownStyle="DropDown" TabIndex="57">
                                 <Items>
                                 <dx:ListEditItem Text="" Value= "" />
                                 <dx:ListEditItem Text="Yes" Value= "Yes" />
                                 <dx:ListEditItem Text="No" Value= "No" />
                                 </Items>
                                 </dx:ASPxComboBox>
                                 </td>
                                <hr />
                            </tr>
                            <tr>
                                <td align="right">
                                    <asp:Label ID="Label75" runat="server" Text="Loan #:" CssClass="AR_Application"></asp:Label>
                                </td>
                                <td>
                                    <asp:TextBox style="text-transform:uppercase" ID="txtLien1Num" runat="server" 
                                        Text="" TabIndex="58"></asp:TextBox>
                                </td>
                            </tr>
                            <tr>
                                <td align="right">
                                    <asp:Label ID="Label76" runat="server" Text="Address:" CssClass="AR_Application"></asp:Label>
                                </td>
                                <td colspan="3">
                                    <asp:TextBox style="text-transform:uppercase" ID="txtLien1Addr" Width="100%" 
                                        runat="server" Text="" TabIndex="59"></asp:TextBox>
                                </td>
                            </tr>
                            <tr>
                             <td align="right">
                                    <asp:Label ID="Label79" runat="server" Text="Zip:" CssClass="AR_Application"></asp:Label>
                                </td>
                            <td align="left">
                                    <asp:TextBox ID="txtLien1Zip" runat="server" Width="50px" Text="" TabIndex="60"></asp:TextBox>
                                    <asp:Button ID="lienzip1" Text="getZip" runat="server" CausesValidation="false" Style="display: none" />
                                </td>
                                <td align="right">
                                    <asp:Label ID="Label77" runat="server" Text="City:" CssClass="AR_Application"></asp:Label>
                                </td>
                                <td>
                                    <asp:TextBox style="text-transform:uppercase" ID="txtLien1City" runat="server" 
                                        Text="" TabIndex="61"></asp:TextBox>
                                </td>
                                <td align="right">
                                    <asp:Label ID="Label78" runat="server" Text="State:" CssClass="AR_Application"></asp:Label>
                                </td>
                                <td>
                                    <asp:TextBox style="text-transform:uppercase" ID="txtLien1State" runat="server" Width="25px" Text=""></asp:TextBox>
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
                                    <asp:TextBox style="text-transform:uppercase" ID="txtLien2Name" runat="server" 
                                        Text="" TabIndex="44"></asp:TextBox>
                                </td>
                            </tr>
                            <tr>
                                <td align="right">
                                    <asp:Label ID="Label81" runat="server" Text="Loan #:" CssClass="AR_Application"></asp:Label>
                                </td>
                                <td>
                                    <asp:TextBox style="text-transform:uppercase" ID="txtLien2Num" runat="server" 
                                        Text="" TabIndex="61"></asp:TextBox>
                                </td>
                            </tr>
                            <tr>
                                <td align="right">
                                    <asp:Label ID="Label82" runat="server" Text="Address:" CssClass="AR_Application"></asp:Label>
                                </td>
                                <td colspan="3">
                                    <asp:TextBox style="text-transform:uppercase" ID="txtLien2Addr" Width="100%" 
                                        runat="server" Text="" TabIndex="62"></asp:TextBox>
                                </td>
                            </tr>
                            <tr>
                             <td align="right">
                                    <asp:Label ID="Label85" runat="server" Text="Zip:" CssClass="AR_Application"></asp:Label>
                                </td>
                                <td align="left">
                                    <asp:TextBox ID="txtLien2Zip" runat="server" Width="50px" Text="" TabIndex="63"></asp:TextBox>
                                    <asp:Button ID="lienzip2" Text="getZip" runat="server" CausesValidation="false" Style="display: none" />
                                </td>
                                <td align="right">
                                    <asp:Label ID="Label83" runat="server" Text="City:" CssClass="AR_Application"></asp:Label>
                                </td>
                                <td>
                                    <asp:TextBox style="text-transform:uppercase" ID="txtLien2City" runat="server" 
                                        Text="" TabIndex="64"></asp:TextBox>
                                </td>
                                <td align="right">
                                    <asp:Label ID="Label84" runat="server" Text="State:" CssClass="AR_Application"></asp:Label>
                                </td>
                                <td>
                                    <asp:TextBox style="text-transform:uppercase" ID="txtLien2State" runat="server" Width="25px" Text=""></asp:TextBox>
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
                                <td align="left" colspan="5">
                                <dx:ASPxComboBox ID="ddPriorInsurance" runat="server" ValueType="System.String" DropDownStyle="DropDownList" TabIndex="65">
                                 <Items>
                                 <dx:ListEditItem Text="None" Value= "None" />
                                 <dx:ListEditItem Text="Yes" Value= "Yes" />
                                 <dx:ListEditItem Text="No" Value= "No" />
                                 <dx:ListEditItem Text="New Purchase" Value= "New Purchase" />
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
                                       </td></tr>
                                       <tr><td colspan="6">
                                    <div runat="server" id="priorInsurance" style="display: none" >
                                   <div style="text-align:left;">
                                        <asp:Label ID="Label70" runat="server" Text="Prior Company:" 
                                            CssClass="AR_Application" TabIndex="66"></asp:Label>
                                        &nbsp;
                                        
                                        <dx:ASPxTextBox CssFilePath="../Styles/Site.css" ID="txtPriorCompany" 
                                            runat="server" Text="" TabIndex="51"></dx:ASPxTextBox>
                                             </div>
                                             <div style="text-align:left;">
                                        <asp:Label ID="Label1" runat="server" Text="Years of Insurance:" CssClass="AR_Application"></asp:Label>
                                       
                                        <asp:TextBox style="text-transform:uppercase" ID="txtprioryears" runat="server" Text="" TabIndex="67" Width="10%"></asp:TextBox>
                                       </div>
                                       <div style="text-align:left;">
                                       
                                                <asp:Label ID="Label63" runat="server" Text="Expiration Date:" CssClass="AR_Application"></asp:Label>
                                  
                                            <dx:ASPxTextBox ID="PriorExp" runat="server" Width="70%" 
                                                   TabIndex="68" >
                                            <MaskSettings Mask="00/00/0000" IncludeLiterals="None" />
                                            </dx:ASPxTextBox>
                                    
                                        </div>
                                         <div style="text-align:left;">
                                       
                                                <asp:Label ID="Label58" runat="server" Text="Policy Number:" CssClass="AR_Application"></asp:Label>
                                  
                                            <dx:ASPxTextBox ID="PrevPolicyNumber" runat="server" Width="70%" 
                                                   TabIndex="68" >
                                            </dx:ASPxTextBox>
                                    
                                        </div>
                                    </div>
                                    
                                </td>
                            </tr>
                            <tr>
                             <td align="right" colspan="2">
                                    <asp:Label ID="Label65" runat="server" Text="Prior Policy numbers with our company:" CssClass="AR_Application"></asp:Label>
                                </td>
                                <td>  <asp:TextBox ID="otherPolicy" runat="server" 
                                        Width="100px" TabIndex="69" /></td>
                                         <td align="right">
                                    <asp:Label ID="Label66" runat="server" Text="Expiration Date:" CssClass="AR_Application"></asp:Label>
                                </td>
                                <td colspan="2"> <dx:ASPxTextBox ID="otherpolicyexp" runat="server" Width="100px" 
                                                   TabIndex="68" >
                                            <MaskSettings Mask="00/00/0000" IncludeLiterals="None" />
                                            </dx:ASPxTextBox></td>
                            </tr>
                            <tr align="left">
                                <td>
                                    <asp:Label ID="lblLossDateCaption" runat="server" Text="Date of Loss" CssClass="AR_Application" />
                                </td>
                                <td>
                                    <asp:Label ID="lblLossTypeCaption" runat="server" Text="Loss Type" CssClass="AR_Application" />
                                </td>
                                <td>
                                    <asp:Label ID="lblLossDescriptionCaption" runat="server" Text="Loss Description" CssClass="AR_Application" />
                                </td>
                                <td>
                                    <asp:Label ID="lblLossAmtPaidCaption" runat="server" Text="Amt Paid" CssClass="AR_Application" />
                                </td>
                                <td>
                                    <asp:Label ID="lblLossStatusCaption" runat="server" Text="Damages Repaired?"  CssClass="AR_Application"/>
                                </td>
                            </tr>
                            <tr align="left">
                                <td>
                                    <asp:TextBox ID="txtLoss1Date" runat="server" DataFieldName="Loss1Date" FriendlyName="Loss 1 date"
                                        Width="80px" TabIndex="69" />
                                    <ajaxTK:TextBoxWatermarkExtender ID="TextBoxWatermarkExtender3" runat="server" Enabled="True"
                                        TargetControlID="txtLoss1Date" WatermarkCssClass="WatermarkCssClass" WatermarkText="mm/dd/yyyy" />
                                </td>
                                <td>
                                    <asp:DropDownList ID="ddLoss1Type" runat="server" TabIndex="70">
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
                                    <asp:TextBox style="text-transform:uppercase" ID="txtLoss1Description" 
                                        runat="server" Casing="UPPER" Columns="20"
                                        FriendlyName="Loss 1 description" Rows="2" TextMode="MultiLine" 
                                        TabIndex="71" />
                                </td>
                                <td>
                                    <asp:TextBox ID="txtLoss1AmtPaid" runat="server" Columns="8" FormatNamed="Currency"
                                        FormatNamedDecimals="0" FriendlyName="Loss 1 amt paid" Text="$0" 
                                        TabIndex="72" Height="22px" />
                                </td>
                                <td>
                                    <asp:DropDownList ID="ddLoss1Status" runat="server" TabIndex="73">
                                        <asp:ListItem></asp:ListItem>
                                        <asp:ListItem>No</asp:ListItem>
                                        <asp:ListItem>Yes</asp:ListItem>
                                    </asp:DropDownList>
                                </td>
                            </tr>
                            <tr align="left">
                                <td>
                                    <asp:TextBox ID="txtLoss2Date" runat="server" DataFieldName="Loss2Date" FriendlyName="Loss 1 date"
                                        Width="80px" TabIndex="74" />
                                    <ajaxTK:TextBoxWatermarkExtender ID="TextBoxWatermarkExtender9" runat="server" Enabled="True"
                                        TargetControlID="txtLoss2Date" WatermarkCssClass="WatermarkCssClass" WatermarkText="mm/dd/yyyy" />
                                </td>
                                <td>
                                    <asp:DropDownList ID="ddLoss2Type" runat="server" TabIndex="75">
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
                                    <asp:TextBox style="text-transform:uppercase" ID="txtLoss2Description" 
                                        runat="server" Casing="UPPER" Columns="20"
                                        FriendlyName="Loss 1 description" Rows="2" TextMode="MultiLine" 
                                        TabIndex="76" />
                                </td>
                                <td>
                                    <asp:TextBox ID="txtLoss2AmtPaid" runat="server" Columns="8" FormatNamed="Currency"
                                        FormatNamedDecimals="0" FriendlyName="Loss 1 amt paid" Text="$0" 
                                        TabIndex="77" />
                                </td>
                                <td>
                                    <asp:DropDownList ID="ddLoss2Status" runat="server" TabIndex="78">
                                        <asp:ListItem></asp:ListItem>
                                        <asp:ListItem>No</asp:ListItem>
                                        <asp:ListItem>Yes</asp:ListItem>
                                    </asp:DropDownList>
                                </td>
                            </tr>
                            <tr align="left">
                                <td>
                                    <asp:TextBox ID="txtLoss3Date" runat="server" DataFieldName="Loss3Date" FriendlyName="Loss 1 date"
                                        Width="80px" TabIndex="79" />
                                    <ajaxTK:TextBoxWatermarkExtender ID="TextBoxWatermarkExtender11" runat="server" Enabled="True"
                                        TargetControlID="txtLoss3Date" WatermarkCssClass="WatermarkCssClass" WatermarkText="mm/dd/yyyy" />
                                </td>
                                <td>
                                    <asp:DropDownList ID="ddLoss3Type" runat="server" TabIndex="80">
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
                                    <asp:TextBox style="text-transform:uppercase" ID="txtLoss3Description" 
                                        runat="server" Casing="UPPER" Columns="20"
                                        FriendlyName="Loss 1 description" Rows="2" TextMode="MultiLine" 
                                        TabIndex="81" />
                                </td>
                                <td>
                                    <asp:TextBox ID="txtLoss3AmtPaid" runat="server" Columns="8" FormatNamed="Currency"
                                        FormatNamedDecimals="0" FriendlyName="Loss 1 amt paid" Text="$0" 
                                        TabIndex="82" />
                                </td>
                                <td>
                                    <asp:DropDownList ID="ddLoss3Status" runat="server" TabIndex="83">
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
 <td>
		<dx:ASPxComboBox ID="dd_ARIng1" runat="server" ValueType="System.String" Width="50"  DropDownStyle="DropDown" TabIndex="90">
     <Items>
     <dx:ListEditItem Text="" Value= "" />
     <dx:ListEditItem Text="Yes" Value= "Yes" />
     <dx:ListEditItem Text="No" Value= "No" />
     </Items>
     </dx:ASPxComboBox>
     </td>
    <td align="left">
        <asp:Label ID="Label88" runat="server" Text="1.   Is the home without utility service or not easily accessible from public roadways?" CssClass="AR_Application"></asp:Label>
    </td>
    
</tr>
<tr align="left">
 <td>
		<dx:ASPxComboBox ID="dd_ARIng2" runat="server" ValueType="System.String" Width="50"  DropDownStyle="DropDown" TabIndex="91">
     <Items>
     <dx:ListEditItem Text="" Value= "" />
     <dx:ListEditItem Text="Yes" Value= "Yes" />
     <dx:ListEditItem Text="No" Value= "No" />
     </Items>
     </dx:ASPxComboBox>
     </td>
    <td align="left">
        <asp:Label ID="Label89" runat="server" Text="2.  Is the home located in an area subject to flooding, mudslides, brush fires, or high crime? " CssClass="AR_Application"></asp:Label>
    </td>
    
</tr>
<tr align="left">
 <td>
		<dx:ASPxComboBox ID="dd_ARIng3" runat="server" ValueType="System.String" Width="50"  DropDownStyle="DropDown" TabIndex="92">
     <Items>
     <dx:ListEditItem Text="" Value= "" />
     <dx:ListEditItem Text="Yes" Value= "Yes" />
     <dx:ListEditItem Text="No" Value= "No" />
     </Items>
     </dx:ASPxComboBox>
     </td>
    <td align="left">
        <asp:Label ID="Label90" runat="server" Text="3.   Is the home vacant or unoccupied for more than 6 months? (Seasonal/secondary risks are acceptable)" CssClass="AR_Application"></asp:Label>
    </td>
    
</tr>
<tr align="left">
 <td>
		<dx:ASPxComboBox ID="dd_ARIng4" runat="server" ValueType="System.String" Width="50"  DropDownStyle="DropDown" TabIndex="93">
     <Items>
     <dx:ListEditItem Text="" Value= "" />
     <dx:ListEditItem Text="Yes" Value= "Yes" />
     <dx:ListEditItem Text="No" Value= "No" />
     </Items>
     </dx:ASPxComboBox>
     </td>
    <td align="left">
        <asp:Label ID="Label91" runat="server" Text="4.   Is the home two or more singlewides joined together? " CssClass="AR_Application"></asp:Label>
    </td>
    
</tr>
<tr align="left">
 <td>
		<dx:ASPxComboBox ID="dd_ARIng5" runat="server" ValueType="System.String" Width="50"  DropDownStyle="DropDown" TabIndex="94">
     <Items>
     <dx:ListEditItem Text="" Value= "" />
     <dx:ListEditItem Text="Yes" Value= "Yes" />
     <dx:ListEditItem Text="No" Value= "No" />
     </Items>
     </dx:ASPxComboBox>
     </td>
    <td align="left">
        <asp:Label ID="Label925" runat="server" Text="5.   Is the home used as rental? " CssClass="AR_Application"></asp:Label>
    </td>
    
</tr>
<tr align="left">
 <td>
		<dx:ASPxComboBox ID="dd_ARIng6" runat="server" ValueType="System.String" Width="50"  DropDownStyle="DropDown" TabIndex="95">
     <Items>
     <dx:ListEditItem Text="" Value= "" />
     <dx:ListEditItem Text="Yes" Value= "Yes" />
     <dx:ListEditItem Text="No" Value= "No" />
     </Items>
     </dx:ASPxComboBox>
     </td>
    <td align="left">
        <asp:Label ID="Label93" runat="server" Text="6.   Is the home under any construction or have any existing damage?" CssClass="AR_Application"></asp:Label>
    </td>
    
</tr>
<tr align="left">
 <td>
		<dx:ASPxComboBox ID="dd_ARIng7" runat="server" ValueType="System.String" Width="50"  DropDownStyle="DropDown" TabIndex="96">
     <Items>
     <dx:ListEditItem Text="" Value= "" />
     <dx:ListEditItem Text="Yes" Value= "Yes" />
     <dx:ListEditItem Text="No" Value= "No" />
     </Items>
     </dx:ASPxComboBox>
     </td>
    <td align="left">
        <asp:Label ID="Label94" runat="server" Text="7.   Are any commercial business, childcare, or farming activities conducted on the premises? " CssClass="AR_Application"></asp:Label>
    </td>
    
</tr>
<tr align="left">
 <td>
		<dx:ASPxComboBox ID="dd_ARIng8" runat="server" ValueType="System.String" Width="50"  DropDownStyle="DropDown" TabIndex="97">
     <Items>
     <dx:ListEditItem Text="" Value= "" />
     <dx:ListEditItem Text="Yes" Value= "Yes" />
     <dx:ListEditItem Text="No" Value= "No" />
     </Items>
     </dx:ASPxComboBox>
     </td>
    <td align="left">
        <asp:Label ID="Label95" runat="server" Text="8.  Is there a swimming pool*, trampoline or similar hazards located on the premises? " CssClass="AR_Application"></asp:Label>
    </td>
    
</tr>
<tr align="left">
 <td>
		<dx:ASPxComboBox ID="dd_ARIng9" runat="server" ValueType="System.String" Width="50"  DropDownStyle="DropDown" TabIndex="98">
     <Items>
     <dx:ListEditItem Text="" Value= "" />
     <dx:ListEditItem Text="Yes" Value= "Yes" />
     <dx:ListEditItem Text="No" Value= "No" />
     </Items>
     </dx:ASPxComboBox>
     </td>
    <td align="left">
        <asp:Label ID="Label96" runat="server" Text="9.   Are there any entrances to the home missing permanently installed steps? " CssClass="AR_Application"></asp:Label>
    </td>
    
</tr>
<tr align="left">
 <td>
		<dx:ASPxComboBox ID="dd_ARIng10" runat="server" ValueType="System.String" Width="50"  DropDownStyle="DropDown" TabIndex="99">
     <Items>
     <dx:ListEditItem Text="" Value= "" />
     <dx:ListEditItem Text="Yes" Value= "Yes" />
     <dx:ListEditItem Text="No" Value= "No" />
     </Items>
     </dx:ASPxComboBox>
     </td>
    <td align="left">
        <asp:Label ID="Label97" runat="server" Text="10.   Are there any areas on the premises with three or more steps lacking a handrail?  " CssClass="AR_Application"></asp:Label>
    </td>
    
</tr>
<tr align="left">
 <td>
		<dx:ASPxComboBox ID="dd_ARIng11" runat="server" ValueType="System.String" Width="50"  DropDownStyle="DropDown" TabIndex="100">
     <Items>
     <dx:ListEditItem Text="" Value= "" />
     <dx:ListEditItem Text="Yes" Value= "Yes" />
     <dx:ListEditItem Text="No" Value= "No" />
     </Items>
     </dx:ASPxComboBox>
     </td>
    <td align="left">
        <asp:Label ID="Label98" runat="server" Text="11.   Has any applicant had a foreclosure or repossession or filed bankruptcy in the past 5 years or behind in mortgage payments?" CssClass="AR_Application"></asp:Label>
    </td>
    
</tr>
<tr align="left">
 <td>
		<dx:ASPxComboBox ID="dd_ARIng12" runat="server" ValueType="System.String" Width="50"  DropDownStyle="DropDown" TabIndex="101">
     <Items>
     <dx:ListEditItem Text="" Value= "" />
     <dx:ListEditItem Text="Yes" Value= "Yes" />
     <dx:ListEditItem Text="No" Value= "No" />
     </Items>
     </dx:ASPxComboBox>
     </td>
    <td align="left">
        <asp:Label ID="Label99" runat="server" Text="12.   Has any applicant been convicted of arson or fraud? " CssClass="AR_Application"></asp:Label>
    </td>
    
</tr>
<tr align="left">
 <td>
		<dx:ASPxComboBox ID="dd_ARIng13" runat="server" ValueType="System.String" Width="50"  DropDownStyle="DropDown" TabIndex="102">
     <Items>
     <dx:ListEditItem Text="" Value= "" />
     <dx:ListEditItem Text="Yes" Value= "Yes" />
     <dx:ListEditItem Text="No" Value= "No" />
     </Items>
     </dx:ASPxComboBox>
     </td>
    <td align="left">
        <asp:Label ID="Label100" runat="server" Text="13.   Is the applicant unemployed (other than retired or disabled)? " CssClass="AR_Application"></asp:Label>
    </td>
    
</tr>
<tr align="left">
 <td>
		<dx:ASPxComboBox ID="dd_ARIng14" runat="server" ValueType="System.String" Width="50"  DropDownStyle="DropDown" TabIndex="103">
     <Items>
     <dx:ListEditItem Text="" Value= "" />
     <dx:ListEditItem Text="Yes" Value= "Yes" />
     <dx:ListEditItem Text="No" Value= "No" />
     </Items>
     </dx:ASPxComboBox>
     </td>
    <td align="left">
        <asp:Label ID="Label101" runat="server" Text="14.   Has any applicant had a fire, liability, theft loss or more than 2 losses of any type at any location during the past 5 years?" CssClass="AR_Application"></asp:Label>
    </td>
    
</tr>
<tr align="left">
 <td>
		<dx:ASPxComboBox ID="dd_ARIng15" runat="server" ValueType="System.String" Width="50"  DropDownStyle="DropDown" TabIndex="104">
     <Items>
     <dx:ListEditItem Text="" Value= "" />
     <dx:ListEditItem Text="Yes" Value= "Yes" />
     <dx:ListEditItem Text="No" Value= "No" />
     </Items>
     </dx:ASPxComboBox>
     </td>
    <td align="left">
        <asp:Label ID="Label102" runat="server" Text="15.   Does the home have wood, coal or pellet burning stoves, heaters or fireplaces used for supplemental heating that are not Factory installed?" CssClass="AR_Application"></asp:Label>
    </td>
    
</tr>
<tr align="left">
 <td>
		<dx:ASPxComboBox ID="dd_ARIng16" runat="server" ValueType="System.String" Width="50"  DropDownStyle="DropDown" TabIndex="105">
     <Items>
     <dx:ListEditItem Text="" Value= "" />
     <dx:ListEditItem Text="Yes" Value= "Yes" />
     <dx:ListEditItem Text="No" Value= "No" />
     </Items>
     </dx:ASPxComboBox>
     </td>
    <td align="left">
        <asp:Label ID="Label103" runat="server" Text="16.   Are there any kerosene heaters on the premises?" CssClass="AR_Application"></asp:Label>
    </td>
    
</tr>
<tr align="left">
 <td>
		<dx:ASPxComboBox ID="dd_ARIng17" runat="server" ValueType="System.String" Width="50"  DropDownStyle="DropDown" TabIndex="106">
     <Items>
     <dx:ListEditItem Text="" Value= "" />
     <dx:ListEditItem Text="Yes" Value= "Yes" />
     <dx:ListEditItem Text="No" Value= "No" />
     </Items>
     </dx:ASPxComboBox>
     </td>
    <td align="left">
        <asp:Label ID="Label104" runat="server" Text="17.  Does the insured own or care for any animal with a prior bite history or has shown aggressive behavior towards any person or animal?" CssClass="AR_Application"></asp:Label>
    </td>
    
</tr>
<tr align="left">
 <td>
		<dx:ASPxComboBox ID="dd_ARIng18" runat="server" ValueType="System.String" Width="50"  DropDownStyle="DropDown" TabIndex="107">
     <Items>
     <dx:ListEditItem Text="" Value= "" />
     <dx:ListEditItem Text="Yes" Value= "Yes" />
     <dx:ListEditItem Text="No" Value= "No" />
     </Items>
     </dx:ASPxComboBox>
     </td>
    <td align="left">
        <asp:Label ID="Label105" runat="server" Text="18.   Does the insured own or care for any mixed or pure bred dog containing one of the following breeds;  Doberman, German Shepherd, Pit Bull, Rottweiler, Husky, Malamute, Chow, or Akita? " CssClass="AR_Application"></asp:Label>
    </td>
    
</tr>
<tr align="left">
 <td>
		<dx:ASPxComboBox ID="dd_ARIng19" runat="server" ValueType="System.String" Width="50"  DropDownStyle="DropDown" TabIndex="108">
     <Items>
     <dx:ListEditItem Text="" Value= "" />
     <dx:ListEditItem Text="Yes" Value= "Yes" />
     <dx:ListEditItem Text="No" Value= "No" />
     </Items>
     </dx:ASPxComboBox>
     </td>
    <td align="left">
        <asp:Label ID="Label106" runat="server" Text="19.   Are there any horses or livestock on the premises? " CssClass="AR_Application"></asp:Label>
    </td>
    </tr>
    <tr align="left">
 <td>
		<dx:ASPxComboBox ID="dd_ARIng25" runat="server" ValueType="System.String" Width="50"  DropDownStyle="DropDown" TabIndex="115">
     <Items>
     <dx:ListEditItem Text="" Value= "" />
     <dx:ListEditItem Text="Yes" Value= "Yes" />
     <dx:ListEditItem Text="No" Value= "No" />
     </Items>
     </dx:ASPxComboBox>
     </td>
    <td align="left">
        <asp:Label ID="Label59" runat="server" Text="20.  Has any company ever declined, cancelled, or Non-renewed this risk in the past 5 years?" CssClass="AR_Application"></asp:Label>
    </td>
    
</tr>
<tr>
<td></td>
<td align="left">
    <asp:Label ID="Label60" runat="server" Text=" If yes, Explain?"></asp:Label>
    <dx:ASPxTextBox ID="ARIng25a" runat="server" Width="170px">
    </dx:ASPxTextBox>
</td>
</tr>
   <tr style="border-bottom: 1px; border-bottom-color: Black">
                                <td colspan="2" align="left">
                                    <span class="style3">IF HOME/MOBILE HOME IS SEASONAL COMPLETE THIS SECTION</span>
                                </td>
                                <hr />
                            </tr>
<tr align="left">
 <td>
		<dx:ASPxComboBox ID="dd_ARIng20" runat="server" ValueType="System.String" Width="50"  DropDownStyle="DropDown" TabIndex="109">
     <Items>
     <dx:ListEditItem Text="" Value= "" />
     <dx:ListEditItem Text="Yes" Value= "Yes" />
     <dx:ListEditItem Text="No" Value= "No" />
     </Items>
     </dx:ASPxComboBox>
     </td>
    <td align="left">
        <asp:Label ID="Label107" runat="server" Text="21.  Is the Home ever Rented?" CssClass="AR_Application"></asp:Label>
    </td>
    
</tr>
<tr align="left">
 <td>
		<dx:ASPxComboBox ID="dd_ARIng21" runat="server" ValueType="System.String" Width="50"  DropDownStyle="DropDown" TabIndex="110">
     <Items>
     <dx:ListEditItem Text="" Value= "" />
     <dx:ListEditItem Text="Yes" Value= "Yes" />
     <dx:ListEditItem Text="No" Value= "No" />
     </Items>
     </dx:ASPxComboBox>
     </td>
    <td align="left">
        <asp:Label  ID="Label108" runat="server" Text="22.  Is it within 5 road miles of fire department?" CssClass="AR_Application"></asp:Label>
    </td>
    
</tr>

<tr align="left">
 <td>
		<dx:ASPxComboBox ID="dd_ARIng22" runat="server" ValueType="System.String" Width="50"  DropDownStyle="DropDown" TabIndex="113">
     <Items>
     <dx:ListEditItem Text="" Value= "" />
     <dx:ListEditItem Text="Yes" Value= "Yes" />
     <dx:ListEditItem Text="No" Value= "No" />
     </Items>
     </dx:ASPxComboBox>
     </td>
    <td align="left">
        <asp:Label ID="Label109" runat="server" Text="23.  Is it within 500 feet and sight of two full time residients?" CssClass="AR_Application"></asp:Label>
    </td>
    
</tr>
<tr align="left">
 <td>
		<dx:ASPxComboBox ID="dd_ARIng23" runat="server" ValueType="System.String" Width="50"  DropDownStyle="DropDown" TabIndex="114">
     <Items>
     <dx:ListEditItem Text="" Value= "" />
     <dx:ListEditItem Text="Yes" Value= "Yes" />
     <dx:ListEditItem Text="No" Value= "No" />
     </Items>
     </dx:ASPxComboBox>
     </td>
    <td align="left">
        <asp:Label ID="Label110" runat="server" Text="24.  Is it winterized to prevent freezing or is heat maintained at a minimum of 55F and the main water supply shut off where it enters the residence while unoccupied?" CssClass="AR_Application"></asp:Label>
    </td>
    
</tr>
<tr align="left">
 <td>
		<dx:ASPxComboBox ID="dd_ARIng24" runat="server" ValueType="System.String" Width="50"  DropDownStyle="DropDown" TabIndex="115">
     <Items>
     <dx:ListEditItem Text="" Value= "" />
     <dx:ListEditItem Text="Yes" Value= "Yes" />
     <dx:ListEditItem Text="No" Value= "No" />
     </Items>
     </dx:ASPxComboBox>
     </td>
    <td align="left">
        <asp:Label ID="Label111" runat="server" Text="25.  Is the home entered by the insured or his representive at least once every 30 days?" CssClass="AR_Application"></asp:Label>
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
                                      <asp:Label ID="AppStatuslbl" runat="server" Text="Eligible" 
                                         style="font-size: x-large; font-weight: 700"></asp:Label>
                                </td>
                                <td>
                                    <dx:ASPxButton ID="overridebtn" runat="server" Text="OverRide" Visible="false" AutoPostBack="false" 
                                        style="height: 26px"/>
                                    <dx:ASPxPopupControl ID="ASPxPopupControl2" runat="server" PopupElementID="overridebtn" AllowDragging="True" HeaderText = "OverRide Submit to UW reason:"
                                                                          MaxWidth="800px" MaxHeight="1800px" MinHeight="150px" MinWidth="150px" ShowFooter="True" Width="250px" Height="130px" AutoUpdatePosition="true" PopupHorizontalAlign="Center" PopupVerticalAlign="WindowCenter" >
                                        <ContentCollection>
                                            <dx:PopupControlContentControl runat="server" SupportsDisabledAttribute="True">
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
                    <asp:Button runat="server" ID="printBtn" Text="Print Application" 
                        OnClick="printApp" TabIndex="130" />
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
                    </div>
                   
                    <div style="float: left; margin-left: 2%" id="summaryContainer">
        <dx:ASPxValidationSummary ID="vsValidationSummary1" runat="server" RenderMode="BulletedList"
            Width="250px" ClientInstanceName="validationSummary" ShowErrorsInEditors="True">
        </dx:ASPxValidationSummary> 
    </div>
                </td>
            </tr>
              <asp:Label ID="txtProtection" runat="server" Text=""  Style="display: none"></asp:Label>
    <asp:Label ID="txtInsage" runat="server" Text=""  Style="display: none"></asp:Label>
    <asp:Label ID="txtSatDish" runat="server" Text=""  Style="display: none"></asp:Label>
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
