<%@ Page Language="vb" Title="TCG Mobile Home Rater" AutoEventWireup="false" CodeBehind="LloydsApplication.aspx.vb" Inherits="MobileHomeRater.LloydsApplication" MasterPageFile="../IntPage.Master" %>
<%@ Register assembly="DevExpress.Web.v13.1, Version=13.1.8.0, Culture=neutral, PublicKeyToken=b88d1754d700e49a" namespace="DevExpress.Web.ASPxEditors" tagprefix="dx" %>

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

        } //End CheckEligiblity
        //Add Additional Insured
        

        //General Informaiton Rules
     
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
                
                <button  style="-webkit-appearance: none; top: 0px; left: -15px; width: 150px; height: 30px;
                    border: 1px solid #808080;" onclick="redirect3(); return false;">
                    Find Imported Quote
                </button>
                 <asp:Button ID="backquote" runat="server" OnClick="backtoquote" Style="-webkit-appearance: none;
                    top: 0px; left: -15px; width: 100px; height: 30px; border: 1px solid #808080;"
                    Text="Back to Quote" CausesValidation="false" />
                
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
    <table align="left" style="width: 100%; border: 1" bgcolor="white" title="">
        <tbody>
            <tr style="border: 1px Black solid;">
                <td align="left">
                    <table align="left" style="width: 40%; border: 1" bgcolor="white" title="Applicant
                    Information">
                        <tbody>
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
                                    <asp:TextBox style="text-transform:uppercase"  ID="txtName" runat="server" Text=""></asp:TextBox >
                                    <asp:RequiredFieldValidator ID="RequiredFieldValidator11" ControlToValidate="txtname"
                                            runat="server" Text="* Req Field"></asp:RequiredFieldValidator>
                                           
                                </td>
                                <td align="right">
                                    <asp:Label ID="Label6" runat="server" Text="DOB:" CssClass="AR_Application"></asp:Label>
                                </td>
                                <td>
                                    <asp:TextBox ID="txtDOB" runat="server" Text=""></asp:TextBox>
                                    <asp:RequiredFieldValidator ID="RequiredFieldValidator1" ControlToValidate="txtDOB"
                                            runat="server" Text="* Req Field"></asp:RequiredFieldValidator>
                                </td>
                            </tr>
                            <tr>
                                <td align="right">
                                    <asp:Label ID="Label12" runat="server" Text="Phone No:" CssClass="AR_Application"></asp:Label>
                                </td>
                                <td>
                                    
                                     
                                     <dx:ASPxTextBox ID="txtPhone2" runat="server" Width="130" >
                                    <MaskSettings Mask="(999) 000-0000" IncludeLiterals="None" />
                                    <ValidationSettings SetFocusOnError="false" ErrorDisplayMode="Text">
                                        <RequiredField IsRequired="True" ErrorText="* Req Field" />
                                    </ValidationSettings>
                                      </dx:ASPxTextBox>
                                </td>
                               
                                <td align="right">
                                    <asp:Label ID="Label13" runat="server" Text="Occupation:" CssClass="AR_Application"></asp:Label>
                                </td>
                                <td>
                                    <asp:TextBox ID="txtOcc" runat="server" Text=""></asp:TextBox>
                                    <asp:RequiredFieldValidator ID="RequiredFieldValidator3" ControlToValidate="txtOcc"
                                            runat="server" Text="* Req Field"></asp:RequiredFieldValidator>
                                </td>
                                <td align="right">
                                    <asp:Label ID="Label14" runat="server" Text="Social Security#:" CssClass="AR_Application"></asp:Label>
                                </td>
                                <td>
                                    
                                    <dx:ASPxTextBox ID="txtSSN2" runat="server" Width="130" >
                                    <ValidationSettings SetFocusOnError="false" ErrorDisplayMode="Text">
                                        <RequiredField IsRequired="True" ErrorText="* Req Field" />
                                    </ValidationSettings>
                                    <MaskSettings Mask="000-00-0000" IncludeLiterals="None" />

                                    </dx:ASPxTextBox>
                                   
                                </td>
                            </tr>
                            
                             <tr>
                                <td align="right">
                                    <asp:Label ID="Label35" runat="server" Text="Agent Name:" CssClass="AR_Application"></asp:Label>
                                </td>
                                <td>
                                    <asp:TextBox style="text-transform:uppercase" ID="txtAgentName" runat="server" Text=""></asp:TextBox>
                                     <asp:RequiredFieldValidator ID="RequiredFieldValidator6" ControlToValidate="txtAgentName"
                                            runat="server" Text="* Req Field"></asp:RequiredFieldValidator>
                                </td>
                            </tr>
                            <tr>
                                <td align="right">
                                    <asp:Label ID="Label19" runat="server" Text="Park Name:" CssClass="AR_Application"></asp:Label>
                                </td>
                                <td>
                                    <asp:TextBox style="text-transform:uppercase" ID="txtParkName" runat="server" Text=""></asp:TextBox>
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
                                    <asp:TextBox style="text-transform:uppercase" ID="txtDiffAppAddr" Width="100%" runat="server" Text=""></asp:TextBox>
                                    
                                </td>
                                 <asp:RequiredFieldValidator ID="RequiredFieldValidator7" ControlToValidate="txtDiffAppAddr"
                                            runat="server" Text="* Req Field"></asp:RequiredFieldValidator>
                            </tr>
                            <tr align="left">
                            <td align="right">
                                    <asp:Label ID="Label23" runat="server" Text="Zip:" CssClass="AR_Application"></asp:Label>
                                </td>
                                <td>
                                    <asp:TextBox ID="txtDiffAppZip" runat="server" Width="50px" Text=""></asp:TextBox>
                                    <asp:Button ID="zipbtn1" Text="getZip" runat="server" CausesValidation="false" Style="display: none" />
                                </td>
                                 <asp:RequiredFieldValidator ID="RequiredFieldValidator10" ControlToValidate="txtdiffAppZip"
                                            runat="server" Text="* Req Field"></asp:RequiredFieldValidator>
                                <td align="right">
                                    <asp:Label ID="Label21" runat="server" Text="City:" CssClass="AR_Application"></asp:Label>
                                </td>
                                <td>
                                    <asp:TextBox style="text-transform:uppercase" ID="txtDiffAppCity" runat="server" Text="" ></asp:TextBox>
                                    </td>
                                <asp:RequiredFieldValidator ID="RequiredFieldValidator8" ControlToValidate="txtDiffAppCity"
                                            runat="server" Text="* Req Field"></asp:RequiredFieldValidator>
                                <td align="right">
                                    <asp:Label ID="Label22" runat="server" Text="State:" CssClass="AR_Application"></asp:Label>
                                </td>
                                <td>
                                    <asp:TextBox style="text-transform:uppercase" ID="txtDiffAppState" runat="server" Width="25px" Text=""></asp:TextBox>
                                     <asp:RequiredFieldValidator ID="RequiredFieldValidator9" ControlToValidate="txtdiffAppState"
                                            runat="server" Text="* Req Field"></asp:RequiredFieldValidator>
                                </td>
                                
                                <td align="right">
                                    <asp:Label ID="Label24" runat="server" Text="County:" CssClass="AR_Application"></asp:Label>
                                </td>

                                <td>
                                    <asp:TextBox style="text-transform:uppercase" ID="txtDiffAppCounty" runat="server" Text=""></asp:TextBox>
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
                                    <asp:CheckBox ID="DupLocation" runat="server" AutoPostBack="true" Text="Mailing Address Same as Location" OnCheckedChanged="DupLocation_CheckedChanged"/>
                                </td>
                            </tr>
                            <tr>
                                <td align="right">
                                    <asp:Label ID="Label7" runat="server" Text="Address:" CssClass="AR_Application"></asp:Label>
                                </td>
                                <td colspan="3">
                                    <asp:TextBox style="text-transform:uppercase" ID="txtAddress" Width="100%" runat="server" Text=""  ></asp:TextBox>
                                </td>
                            </tr>
                            <tr>
                            <td align="right">
                                    <asp:Label ID="Label10" runat="server" Text="Zip:" CssClass="AR_Application"></asp:Label>
                                </td>
                                <td>
                                    <asp:TextBox ID="txtZip" runat="server" Width="50px" Text=""></asp:TextBox>
                                    <asp:Button ID="zipbtn2" Text="getZip" runat="server" CausesValidation="false" Style="display: none" />
                                </td>
                                <td align="right">
                                    <asp:Label ID="Label8" runat="server" Text="City:" CssClass="AR_Application"></asp:Label>
                                </td>
                                <td>
                                    <asp:TextBox style="text-transform:uppercase" ID="txtCity" runat="server" Text=""></asp:TextBox>
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
                            </tr>
                            <tr>
                                <td colspan="2" align="right">
                                    <asp:Label ID="Label32" runat="server" Text="Distance from Gulf or Atlantic Coastal Water" CssClass="AR_Application"></asp:Label>
                                </td>
                                <td align="left">
                                    <asp:TextBox ID="txtDistToGulf" Width="105px" runat="server" Text="" ></asp:TextBox>
                                 <asp:RequiredFieldValidator ID="RequiredFieldValidator18" ControlToValidate="txtDistToGulf"
                                            runat="server" Text="* Req Field"></asp:RequiredFieldValidator></td>
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
                                    <asp:TextBox ID="txtDescMHYear" runat="server" Text=""></asp:TextBox>
                                </td>
                                <td align="right">
                                    <asp:Label ID="Label34" runat="server" Text="Manufacturer/<br/>Model:" CssClass="AR_Application"></asp:Label>
                                </td>
                                <td>
                                    <asp:TextBox style="text-transform:uppercase" ID="txtDescMHManf" runat="server" Width="" Text=""></asp:TextBox>
                                </td>
                                <td align="right">
                                    <asp:Label ID="Label36" runat="server" Text="Length:" CssClass="AR_Application"></asp:Label>
                                </td>
                                <td>
                                    <asp:TextBox ID="txtDescMHLength" runat="server" Width="50px" Text=""></asp:TextBox>
                                </td>
                                <td align="right">
                                    <asp:Label ID="Label37" runat="server" Text="Width:" CssClass="AR_Application"></asp:Label>
                                </td>
                                <td>
                                    <asp:TextBox ID="txtDescMHWidth" runat="server" Width="50px" Text=""></asp:TextBox>
                                </td>
                            </tr>
                            <tr>
                                <td align="right">
                                    <asp:Label ID="Label38" runat="server" Text="Serial Number:" CssClass="AR_Application"></asp:Label>
                                </td>
                                <td align="left">
                                    <asp:TextBox style="text-transform:uppercase" ID="txtDescMHSerial" runat="server" Width="" Text=""></asp:TextBox>
                                     <asp:RequiredFieldValidator ID="RequiredFieldValidator19" ControlToValidate="txtDescMHSerial"
                                            runat="server" Text="* Req Field"></asp:RequiredFieldValidator>
                                </td>
                                <td align="right">
                                    <asp:Label ID="Label39" runat="server" Text="Purchase Date:" CssClass="AR_Application"></asp:Label>
                                </td>
                                <td align="left">
                                   
                                       <dx:ASPxTextBox ID="txtDescMHPurDate2" runat="server" Width="130" >
                                    <MaskSettings Mask="00/00/0000" IncludeLiterals="None" />
                                    <ValidationSettings SetFocusOnError="false" >
                                        <RequiredField IsRequired="True" ErrorText="* Req Field" />
                                    </ValidationSettings>
                                    </dx:ASPxTextBox>
                                     <asp:RequiredFieldValidator ID="RequiredFieldValidator20" ControlToValidate="txtDescMHPurDate2"
                                            runat="server" Text="* Req Field"></asp:RequiredFieldValidator>
                                </td>
                                <td align="right">
                                    <asp:Label ID="Label40" runat="server" Text="Purchase Price:" CssClass="AR_Application"></asp:Label>
                                </td>
                                <td align="left">
                                   
                                       <dx:ASPxTextBox ID="txtDescMHPurPrice2" runat="server" Width="130" >
                                    <MaskSettings Mask="$<0..99999g>.<00..99>" IncludeLiterals="DecimalSymbol" />
                                    <ValidationSettings ErrorDisplayMode="ImageWithTooltip" />


                                    </dx:ASPxTextBox>
                                </td>
                                <td align="right">
                                    <asp:Label ID="Label41" runat="server" Text="Current Date:" CssClass="AR_Application"></asp:Label>
                                </td>
                                <td align="left">
                                    
                                    <dx:ASPxTextBox ID="txtDescMHCurDate2" runat="server" Width="130" >
                                    <MaskSettings Mask="00/00/0000" IncludeLiterals="None" />
                                    <ValidationSettings SetFocusOnError="false" ErrorDisplayMode="Text">
                                        <RequiredField IsRequired="True" ErrorText="* Req Field" />
                                    </ValidationSettings>

                                    </dx:ASPxTextBox>
                                </td>
                            </tr>
                            <tr>
                                <td align="right">
                                    <asp:Label ID="Label42" runat="server" Text="Describe Additions/<br/>Attached Structures:" CssClass="AR_Application"></asp:Label>
                                </td>
                                <td align="left">
                                    <asp:TextBox style="text-transform:uppercase" ID="txtDescMHAttStruc" runat="server" Width="200px" Text=""></asp:TextBox>
                                </td>
                                <td align="right">
                                    <asp:Label ID="Label43" runat="server" Text="Age:" CssClass="AR_Application"></asp:Label>
                                </td>
                                <td align="left">
                                    <asp:TextBox style="text-transform:uppercase" ID="txtDescMHAttStrucAge" runat="server" Width="75px" Text=""></asp:TextBox>
                                </td>
                                <td align="right">
                                    <asp:Label ID="Label44" runat="server" Text="Size:" CssClass="AR_Application"></asp:Label>
                                </td>
                                <td align="left">
                                    <asp:TextBox style="text-transform:uppercase" ID="txtDescMHAttStrucSize" runat="server" Width="75px" Text=""></asp:TextBox>
                                </td>
                                <td align="right">
                                    <asp:Label ID="Label45" runat="server" Text="Current Value:" CssClass="AR_Application"></asp:Label>
                                </td>
                                <td align="left">
                                   
                                    
                                       <dx:ASPxTextBox ID="txtDescMHAttStrucCurVal2" runat="server" Width="130" >
                                    <MaskSettings Mask="$<0..99999g>.<00..99>" IncludeLiterals="DecimalSymbol" />
                                    <ValidationSettings SetFocusOnError="false" ErrorDisplayMode="Text">
                                        <RequiredField IsRequired="True" ErrorText="* Req Field" />
                                    </ValidationSettings>


                                    </dx:ASPxTextBox>
                                </td>
                            </tr>
                            <tr>
                                <td align="right">
                                    <asp:Label ID="Label46" runat="server" Text="Describe Unattached<br/> Structures:" CssClass="AR_Application"></asp:Label>
                                </td>
                                <td align="left">
                                    <asp:TextBox style="text-transform:uppercase" ID="txtDescMHUnAttStruc" runat="server" Width="200px" Text=""></asp:TextBox>
                                </td>
                                <td align="right">
                                    <asp:Label ID="Label47" runat="server" Text="Age:" CssClass="AR_Application"></asp:Label>
                                </td>
                                <td align="left">
                                    <asp:TextBox ID="txtDescMHUnAttStrucAge" runat="server" Width="75px" Text=""></asp:TextBox>
                                </td>
                                <td align="right">
                                    <asp:Label ID="Label48" runat="server" Text="Size:" CssClass="AR_Application"></asp:Label>
                                </td>
                                <td align="left">
                                    <asp:TextBox ID="txtDescMHUnAttStrucSize" runat="server" Width="75px" Text=""></asp:TextBox>
                                </td>
                                <td align="right">
                                    <asp:Label ID="Label49" runat="server" Text="Current Value:" CssClass="AR_Application"></asp:Label>
                                </td>
                                <td align="left">
                                   
                                      <dx:ASPxTextBox ID="txtDescMHUnAttStrucCurVal2" runat="server" Width="130" >
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
                                    <asp:dropdownlist runat="server" ID="ddUsage" RepeatDirection="Horizontal"  CssClass="AR_Application">
                                        <asp:ListItem>Permanent</asp:ListItem>
                                        <asp:ListItem>Seasonal</asp:ListItem>
                                        <asp:ListItem>Rental</asp:ListItem>
                                        <asp:ListItem>Commercial</asp:ListItem>
                                        <asp:ListItem>Tenant</asp:ListItem>
                                    </asp:dropdownlist>
                                     <asp:RequiredFieldValidator ID="RequiredFieldValidator4" ControlToValidate="ddUsage"
                                            runat="server" Text="* Req Field"></asp:RequiredFieldValidator>
                                </td>
                            </tr>
                           
                            
                            <tr align="left">
                                <td align="right">
                                    <asp:Label ID="Label55" runat="server" Text="Age of Mobile Home:" CssClass="AR_Application"></asp:Label>
                                </td>
                                <td>
                                    <asp:dropdownlist runat="server" ID="ddMHAge" RepeatDirection="Horizontal"  CssClass="AR_Application">
                                        <asp:ListItem>1-5 Yrs</asp:ListItem>
                                        <asp:ListItem>6-15 Yrs</asp:ListItem>
                                        <asp:ListItem>16 Yrs & Older</asp:ListItem>
                                    </asp:dropdownlist>
                                     <asp:RequiredFieldValidator ID="RequiredFieldValidator23" ControlToValidate="ddMHAge"
                                            runat="server" Text="* Req Field"></asp:RequiredFieldValidator>
                                </td>
                            </tr>
                            <tr align="left">
                                <td align="right">
                                    <asp:Label ID="Label56" runat="server" Text="Loss History:" CssClass="AR_Application"></asp:Label>
                                    <br /><small>Claim Free for
                                        <br />at least one year?</small>
                                </td>
                                <td>
                                    <asp:DropDownList ID="ddlossHist" runat="server" TabIndex="19">
                                        <asp:ListItem></asp:ListItem>
                                        <asp:ListItem>Yes</asp:ListItem>
                                        <asp:ListItem>No</asp:ListItem>
                                    </asp:DropDownList>
                                     <asp:RequiredFieldValidator ID="RequiredFieldValidator24" ControlToValidate="ddlossHist"
                                            runat="server" Text="* Req Field"></asp:RequiredFieldValidator>
                                </td>
                            </tr>
                            <tr align="left">
                                <td align="right">
                                    <asp:Label ID="Label57" runat="server" Text="Park Status:" CssClass="AR_Application"></asp:Label>
                                    &nbsp;&nbsp;&nbsp;<small>In a Park?</small>
                                </td>
                                <td>
                                    <asp:DropDownList ID="ddParkStatus" runat="server" TabIndex="19">
                                        <asp:ListItem></asp:ListItem>
                                        <asp:ListItem>Yes</asp:ListItem>
                                        <asp:ListItem>No</asp:ListItem>
                                    </asp:DropDownList>
                                     <asp:RequiredFieldValidator ID="RequiredFieldValidator25" ControlToValidate="ddParkStatus"
                                            runat="server" Text="* Req Field"></asp:RequiredFieldValidator>
                                </td>
                            </tr>
                            
                            <tr align="left">
                                <td align="right">
                                    <asp:Label ID="Label62" runat="server" Text="Unit Type:" CssClass="AR_Application"></asp:Label>
                                </td>
                                <td>
                                    <asp:DropDownList ID="ddUnitType" runat="server" TabIndex="19">
                                        <asp:ListItem></asp:ListItem>
                                        <asp:ListItem>Singlewide</asp:ListItem>
                                        <asp:ListItem>Doublewide</asp:ListItem>
                                        <asp:ListItem>Other</asp:ListItem>
                                    </asp:DropDownList>
                                     <asp:RequiredFieldValidator ID="RequiredFieldValidator26" ControlToValidate="ddunitType"
                                            runat="server" Text="* Req Field"></asp:RequiredFieldValidator>
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
                                    <asp:TextBox style="text-transform:uppercase" ID="txtLien1Name" runat="server" Text=""></asp:TextBox>
                                </td>
                                <hr />
                            </tr>
                            <tr>
                                <td align="right">
                                    <asp:Label ID="Label75" runat="server" Text="Loan #:" CssClass="AR_Application"></asp:Label>
                                </td>
                                <td>
                                    <asp:TextBox style="text-transform:uppercase" ID="txtLien1Num" runat="server" Text=""></asp:TextBox>
                                </td>
                            </tr>
                            <tr>
                                <td align="right">
                                    <asp:Label ID="Label76" runat="server" Text="Address:" CssClass="AR_Application"></asp:Label>
                                </td>
                                <td colspan="3">
                                    <asp:TextBox style="text-transform:uppercase" ID="txtLien1Addr" Width="100%" runat="server" Text=""></asp:TextBox>
                                </td>
                            </tr>
                            <tr>
                             <td align="right">
                                    <asp:Label ID="Label79" runat="server" Text="Zip:" CssClass="AR_Application"></asp:Label>
                                </td>
                            <td align="left">
                                    <asp:TextBox ID="txtLien1Zip" runat="server" Width="50px" Text=""></asp:TextBox>
                                    <asp:Button ID="lienzip1" Text="getZip" runat="server" CausesValidation="false" Style="display: none" />
                                </td>
                                <td align="right">
                                    <asp:Label ID="Label77" runat="server" Text="City:" CssClass="AR_Application"></asp:Label>
                                </td>
                                <td>
                                    <asp:TextBox style="text-transform:uppercase" ID="txtLien1City" runat="server" Text=""></asp:TextBox>
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
                                    <asp:TextBox style="text-transform:uppercase" ID="txtLien2Name" runat="server" Text=""></asp:TextBox>
                                </td>
                            </tr>
                            <tr>
                                <td align="right">
                                    <asp:Label ID="Label81" runat="server" Text="Loan #:" CssClass="AR_Application"></asp:Label>
                                </td>
                                <td>
                                    <asp:TextBox style="text-transform:uppercase" ID="txtLien2Num" runat="server" Text=""></asp:TextBox>
                                </td>
                            </tr>
                            <tr>
                                <td align="right">
                                    <asp:Label ID="Label82" runat="server" Text="Address:" CssClass="AR_Application"></asp:Label>
                                </td>
                                <td colspan="3">
                                    <asp:TextBox style="text-transform:uppercase" ID="txtLien2Addr" Width="100%" runat="server" Text=""></asp:TextBox>
                                </td>
                            </tr>
                            <tr>
                             <td align="right">
                                    <asp:Label ID="Label85" runat="server" Text="Zip:" CssClass="AR_Application"></asp:Label>
                                </td>
                                <td align="left">
                                    <asp:TextBox ID="txtLien2Zip" runat="server" Width="50px" Text=""></asp:TextBox>
                                    <asp:Button ID="lienzip2" Text="getZip" runat="server" CausesValidation="false" Style="display: none" />
                                </td>
                                <td align="right">
                                    <asp:Label ID="Label83" runat="server" Text="City:" CssClass="AR_Application"></asp:Label>
                                </td>
                                <td>
                                    <asp:TextBox style="text-transform:uppercase" ID="txtLien2City" runat="server" Text=""></asp:TextBox>
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
                                <td>
                                    <asp:DropDownList ID="ddPriorInsurance" runat="server" TabIndex="19">
                                        <asp:ListItem></asp:ListItem>
                                        <asp:ListItem>Yes</asp:ListItem>
                                        <asp:ListItem>No</asp:ListItem>
                                        <asp:ListItem>New Purchase</asp:ListItem>
                                    </asp:DropDownList>
                                    <asp:RequiredFieldValidator ID="RequiredFieldValidator75" ControlToValidate="ddPriorInsurance"
                                            runat="server" Text="* Req Field"></asp:RequiredFieldValidator>
                                    <div id="priorInsurance" style="display: none">
                                        <asp:Label ID="Label70" runat="server" Text="Prior Company:" CssClass="AR_Application"></asp:Label>
                                        &nbsp;
                                        <asp:TextBox style="text-transform:uppercase" ID="txtPriorCompany" runat="server" Text=""></asp:TextBox>
                                        <asp:Label ID="Label1" runat="server" Text="Years of Insurance:" CssClass="AR_Application"></asp:Label>
                                        <asp:TextBox style="text-transform:uppercase" ID="txtprioryears" runat="server" Text=""></asp:TextBox>
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
                                        Width="80px" />
                                    <ajaxTK:TextBoxWatermarkExtender ID="TextBoxWatermarkExtender3" runat="server" Enabled="True"
                                        TargetControlID="txtLoss1Date" WatermarkCssClass="WatermarkCssClass" WatermarkText="mm/dd/yyyy" />
                                </td>
                                <td>
                                    <asp:DropDownList ID="ddLoss1Type" runat="server" TabIndex="10">
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
                                    <asp:TextBox style="text-transform:uppercase" ID="txtLoss1Description" runat="server" Casing="UPPER" Columns="20"
                                        FriendlyName="Loss 1 description" Rows="2" TextMode="MultiLine" />
                                </td>
                                <td>
                                    <asp:TextBox ID="txtLoss1AmtPaid" runat="server" Columns="8" FormatNamed="Currency"
                                        FormatNamedDecimals="0" FriendlyName="Loss 1 amt paid" Text="$0" />
                                </td>
                                <td>
                                    <asp:DropDownList ID="ddLoss1Status" runat="server" TabIndex="10">
                                        <asp:ListItem></asp:ListItem>
                                        <asp:ListItem>No</asp:ListItem>
                                        <asp:ListItem>Yes</asp:ListItem>
                                    </asp:DropDownList>
                                </td>
                            </tr>
                            <tr align="left">
                                <td>
                                    <asp:TextBox ID="txtLoss2Date" runat="server" DataFieldName="Loss2Date" FriendlyName="Loss 1 date"
                                        Width="80px" />
                                    <ajaxTK:TextBoxWatermarkExtender ID="TextBoxWatermarkExtender9" runat="server" Enabled="True"
                                        TargetControlID="txtLoss2Date" WatermarkCssClass="WatermarkCssClass" WatermarkText="mm/dd/yyyy" />
                                </td>
                                <td>
                                    <asp:DropDownList ID="ddLoss2Type" runat="server" TabIndex="10">
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
                                    <asp:TextBox style="text-transform:uppercase" ID="txtLoss2Description" runat="server" Casing="UPPER" Columns="20"
                                        FriendlyName="Loss 1 description" Rows="2" TextMode="MultiLine" />
                                </td>
                                <td>
                                    <asp:TextBox ID="txtLoss2AmtPaid" runat="server" Columns="8" FormatNamed="Currency"
                                        FormatNamedDecimals="0" FriendlyName="Loss 1 amt paid" Text="$0" />
                                </td>
                                <td>
                                    <asp:DropDownList ID="ddLoss2Status" runat="server" TabIndex="10">
                                        <asp:ListItem></asp:ListItem>
                                        <asp:ListItem>No</asp:ListItem>
                                        <asp:ListItem>Yes</asp:ListItem>
                                    </asp:DropDownList>
                                </td>
                            </tr>
                            <tr align="left">
                                <td>
                                    <asp:TextBox ID="txtLoss3Date" runat="server" DataFieldName="Loss3Date" FriendlyName="Loss 1 date"
                                        Width="80px" />
                                    <ajaxTK:TextBoxWatermarkExtender ID="TextBoxWatermarkExtender11" runat="server" Enabled="True"
                                        TargetControlID="txtLoss3Date" WatermarkCssClass="WatermarkCssClass" WatermarkText="mm/dd/yyyy" />
                                </td>
                                <td>
                                    <asp:DropDownList ID="ddLoss3Type" runat="server" TabIndex="10">
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
                                    <asp:TextBox style="text-transform:uppercase" ID="txtLoss3Description" runat="server" Casing="UPPER" Columns="20"
                                        FriendlyName="Loss 1 description" Rows="2" TextMode="MultiLine" />
                                </td>
                                <td>
                                    <asp:TextBox ID="txtLoss3AmtPaid" runat="server" Columns="8" FormatNamed="Currency"
                                        FormatNamedDecimals="0" FriendlyName="Loss 1 amt paid" Text="$0" />
                                </td>
                                <td>
                                    <asp:DropDownList ID="ddLoss3Status" runat="server" TabIndex="10">
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
                                    <asp:DropDownList ID="dd_ARIng1" runat="server" TabIndex="19">
                                        <asp:ListItem></asp:ListItem>
                                        <asp:ListItem>Yes</asp:ListItem>
                                        <asp:ListItem>No</asp:ListItem>
                                    </asp:DropDownList>
                                    <asp:RequiredFieldValidator ID="RequiredFieldValidator32" ControlToValidate="dd_ARIng1"
                                            runat="server" Text="* Req Field"></asp:RequiredFieldValidator>
                                </td>
                                <td align="left">
                                    <asp:Label ID="Label87" runat="server" Text="1. Woodburning Stove or Fireplace?" CssClass="AR_Application"></asp:Label>
                                </td>
                               
                            </tr>
                            <tr align="left">
                            <td>
                                    <asp:DropDownList ID="dd_ARIng2" runat="server" TabIndex="19">
                                        <asp:ListItem></asp:ListItem>
                                        <asp:ListItem>Yes</asp:ListItem>
                                        <asp:ListItem>No</asp:ListItem>
                                    </asp:DropDownList>
                                     <asp:RequiredFieldValidator ID="RequiredFieldValidator33" ControlToValidate="dd_ARIng2"
                                            runat="server" Text="* Req Field"></asp:RequiredFieldValidator>
                                </td>
                                <td align="left">
                                    <asp:Label ID="Label88" runat="server" Text="2. Business on Property?" CssClass="AR_Application"></asp:Label>
                                </td>
                                
                            </tr>
                            <tr align="left">
                             <td>
                                    <asp:DropDownList ID="dd_ARIng3" runat="server" TabIndex="19">
                                        <asp:ListItem></asp:ListItem>
                                        <asp:ListItem>Yes</asp:ListItem>
                                        <asp:ListItem>No</asp:ListItem>
                                    </asp:DropDownList>
                                     <asp:RequiredFieldValidator ID="RequiredFieldValidator34" ControlToValidate="dd_ARIng3"
                                            runat="server" Text="* Req Field"></asp:RequiredFieldValidator>
                                </td>
                                <td align="left">
                                    <asp:Label ID="Label86" runat="server" Text="3. Farming on Property?" CssClass="AR_Application"></asp:Label>
                                </td>
                               
                            </tr>
                            <tr align="left">
                            <td>
                                    <asp:DropDownList ID="dd_ARIng4" runat="server" TabIndex="19">
                                        <asp:ListItem></asp:ListItem>
                                        <asp:ListItem>Yes</asp:ListItem>
                                        <asp:ListItem>No</asp:ListItem>
                                    </asp:DropDownList>
                                     <asp:RequiredFieldValidator ID="RequiredFieldValidator35" ControlToValidate="dd_ARIng4"
                                            runat="server" Text="* Req Field"></asp:RequiredFieldValidator>
                                </td>
                                <td align="left">
                                    <asp:Label ID="Label89" runat="server" Text="4. Animals on Property?" CssClass="AR_Application"></asp:Label>
                                </td>
                                
                            </tr>
                            <tr align="left">
                            <td>
                                    <asp:DropDownList ID="dd_ARIng5" runat="server" TabIndex="19">
                                        <asp:ListItem></asp:ListItem>
                                        <asp:ListItem>Yes</asp:ListItem>
                                        <asp:ListItem>No</asp:ListItem>
                                    </asp:DropDownList>
                                     <asp:RequiredFieldValidator ID="RequiredFieldValidator36" ControlToValidate="dd_ARIng5"
                                            runat="server" Text="* Req Field"></asp:RequiredFieldValidator>
                                </td>
                                <td align="left">
                                    <asp:Label ID="Label90" runat="server" Text="5. Swimming Pool on Property?" CssClass="AR_Application"></asp:Label>
                                </td>
                                
                            </tr>
                            <tr align="left">
                             <td>
                                    <asp:DropDownList ID="dd_ARIng6" runat="server" TabIndex="19">
                                        <asp:ListItem></asp:ListItem>
                                        <asp:ListItem>Yes</asp:ListItem>
                                        <asp:ListItem>No</asp:ListItem>
                                    </asp:DropDownList>
                                     <asp:RequiredFieldValidator ID="RequiredFieldValidator37" ControlToValidate="dd_ARIng6"
                                            runat="server" Text="* Req Field"></asp:RequiredFieldValidator>
                                </td>
                                <td align="left">
                                    <asp:Label ID="Label91" runat="server" Text="6. Repo/Foreclosure in the past 24 months?" CssClass="AR_Application"></asp:Label>
                                </td>
                               
                            </tr>
                            <tr align="left">
                            <td>
                                    <asp:DropDownList ID="dd_ARIng7" runat="server" TabIndex="19">
                                        <asp:ListItem></asp:ListItem>
                                        <asp:ListItem>Yes</asp:ListItem>
                                        <asp:ListItem>No</asp:ListItem>
                                    </asp:DropDownList>
                                     <asp:RequiredFieldValidator ID="RequiredFieldValidator38" ControlToValidate="dd_ARIng7"
                                            runat="server" Text="* Req Field"></asp:RequiredFieldValidator>
                                </td>
                                <td align="left">
                                    <asp:Label ID="Label93" runat="server" Text="7. Bankruptcy in the past 24 months?" CssClass="AR_Application"></asp:Label>
                                </td>
                                
                            </tr>
                            <tr align="left">
                             <td>
                                    <asp:DropDownList ID="dd_ARIng8" runat="server" TabIndex="19">
                                        <asp:ListItem></asp:ListItem>
                                        <asp:ListItem>Yes</asp:ListItem>
                                        <asp:ListItem>No</asp:ListItem>
                                    </asp:DropDownList>
                                     <asp:RequiredFieldValidator ID="RequiredFieldValidator39" ControlToValidate="dd_ARIng8"
                                            runat="server" Text="* Req Field"></asp:RequiredFieldValidator>
                                </td>
                                <td align="left">
                                    <asp:Label ID="Label94" runat="server" Text="8. Claims in the past 36 months?" CssClass="AR_Application"></asp:Label>
                                </td>
                               
                            </tr>
                            <tr align="left">
                            <td>
                                    <asp:DropDownList ID="dd_ARIng9" runat="server" TabIndex="19">
                                        <asp:ListItem></asp:ListItem>
                                        <asp:ListItem>Yes</asp:ListItem>
                                        <asp:ListItem>No</asp:ListItem>
                                    </asp:DropDownList>
                                     <asp:RequiredFieldValidator ID="RequiredFieldValidator40" ControlToValidate="dd_ARIng9"
                                            runat="server" Text="* Req Field"></asp:RequiredFieldValidator>
                                </td>
                                <td align="left">
                                  <asp:Label ID="Label95" runat="server" Text="9. Unrepaired Damage?" CssClass="AR_Application"></asp:Label>
                                </td>
                                
                            </tr>
                            <tr align="left">
                             <td>
                                    <asp:DropDownList ID="dd_ARIng10" runat="server" TabIndex="19">
                                        <asp:ListItem></asp:ListItem>
                                        <asp:ListItem>Yes</asp:ListItem>
                                        <asp:ListItem>No</asp:ListItem>
                                    </asp:DropDownList>
                                     <asp:RequiredFieldValidator ID="RequiredFieldValidator41" ControlToValidate="dd_ARIng10"
                                            runat="server" Text="* Req Field"></asp:RequiredFieldValidator>
                                </td>
                                <td align="left">
                                    <asp:Label ID="Label96" runat="server" Text="10. Handrails Installed (3 or more steps)?" CssClass="AR_Application"></asp:Label>
                                </td>
                               
                            </tr>
                            <tr align="left">
                            <td>
                                    <asp:DropDownList ID="dd_ARIng11" runat="server" TabIndex="19">
                                        <asp:ListItem></asp:ListItem>
                                        <asp:ListItem>Yes</asp:ListItem>
                                        <asp:ListItem>No</asp:ListItem>
                                    </asp:DropDownList>
                                     <asp:RequiredFieldValidator ID="RequiredFieldValidator42" ControlToValidate="dd_ARIng11"
                                            runat="server" Text="* Req Field"></asp:RequiredFieldValidator>
                                </td>
                                <td align="left">
                                    <asp:Label ID="Label97" runat="server" Text="11. Mortgage Payment Currently Past Due?" CssClass="AR_Application"></asp:Label>
                                </td>
                                
                            </tr>
                            <tr align="left">
                            <td>
                                    <asp:DropDownList ID="dd_ARIng12" runat="server" TabIndex="19">
                                        <asp:ListItem></asp:ListItem>
                                        <asp:ListItem>Yes</asp:ListItem>
                                        <asp:ListItem>No</asp:ListItem>
                                    </asp:DropDownList>
                                     <asp:RequiredFieldValidator ID="RequiredFieldValidator43" ControlToValidate="dd_ARIng12"
                                            runat="server" Text="* Req Field"></asp:RequiredFieldValidator>
                                </td>
                                <td align="left">
                                    <asp:Label ID="Label98" runat="server" Text="12. Kerosend Heater?" CssClass="AR_Application"></asp:Label>
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
                                    <asp:Label ID="Label92" runat="server" Text="How would you like to receive the poicy?" CssClass="AR_Application"></asp:Label>
                                    <br />
                                    <asp:Label ID="Label130" runat="server" Text="Please select Preferred options"></asp:Label>
                                </td>
                            </tr>
                            <tr>
                                <td align="left">
                                    <asp:Label ID="Label131" runat="server" Text="Insured" CssClass="AR_Application"></asp:Label>
                                </td>
                                <td>
                                    <asp:DropDownList ID="dddistOptionInsured" runat="server" TabIndex="19">
                                        <asp:ListItem></asp:ListItem>
                                        <asp:ListItem></asp:ListItem>
                                        <asp:ListItem>Receive via email</asp:ListItem>
                                        <asp:ListItem>Receive via mail</asp:ListItem>
                                    </asp:DropDownList>
                                </td>
                            </tr>
                            <tr>
                                <td align="left">
                                    <asp:Label ID="Label132" runat="server" Text="Agent" CssClass="AR_Application"></asp:Label>
                                </td>
                                <td>
                                    <asp:DropDownList ID="dddistOptionAgent" runat="server" TabIndex="19">
                                        <asp:ListItem></asp:ListItem>
                                        <asp:ListItem></asp:ListItem>
                                        <asp:ListItem>Recieve via email</asp:ListItem>
                                        <asp:ListItem>Recieve via mail</asp:ListItem>
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
                                <td colspan=2>
                                    <asp:DropDownList ID="ddPaymentOpt" runat="server" TabIndex="19">
                                        <asp:ListItem></asp:ListItem>
                                        <asp:ListItem></asp:ListItem>
                                        <asp:ListItem>In Full</asp:ListItem>
                                        <asp:ListItem Value="Premium Finance">Premium Finance</asp:ListItem>
                                    </asp:DropDownList>
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
                                         style="font-size: larger; font-weight: 700; color: Green"></asp:Label>
                                </td>
                                <hr />
                            </tr>
                        </tbody>
                    </table>
                </td>
            </tr>
            <tr>
                <td>
                    <asp:Button runat="server" ID="printBtn" Text="Print Application" OnClick="printApp" />
                    <asp:Label ID="labelapp" runat="server" Text="Label" Visible="false"></asp:Label>
                </td>
            </tr>
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
