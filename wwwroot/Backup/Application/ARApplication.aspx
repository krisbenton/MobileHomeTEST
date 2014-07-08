<%@ Page Language="vb" AutoEventWireup="false" CodeBehind="ARApplication.aspx.vb"
    MasterPageFile="../IntPage.Master" Inherits="MobileHomeRater.ARApplication" Title="American Reliable Application" EnableEventValidation="false" EnableSessionState="true"  EnableViewState="true"%>

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

        //General Informaiton Rules
        function parkStatus() {

            var e = document.getElementById('<%= ddParkStatus.ClientID %>');
            var parkStatus = e.options[e.selectedIndex].text;
            if (parkStatus == "Yes") {
                document.getElementById('park1').style.display = 'none';
                document.getElementById('park2').style.display = '';
            }
            else {
                document.getElementById('park1').style.display = '';
                document.getElementById('park2').style.display = 'none';

            }

        } //End Park Status
        function supHeating() {

            var e = document.getElementById('<%=ddSupHeating.ClientID%>');
            var parkStatus = e.options[e.selectedIndex].text;
            if (parkStatus == "Other") {
                document.getElementById('supHeatOtherRow').style.display = '';
            }
            else {
                document.getElementById('supHeatOtherRow').style.display = 'none';

            }
        } //End supHeating
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
        function AnimalType() {
            var e = document.getElementById('<%=ddAnimal.ClientID%>');
            var parkStatus = e.options[e.selectedIndex].text;
            if (parkStatus == "Yes") {
                document.getElementById('animal').style.display = '';
            }
            else {
                document.getElementById('animal').style.display = 'none';

            }
        } // End AnimalType

        //Redirect sections
        function redirect() {
            window.location.href = "/Quote/quote.aspx";
        }
        function redirect2() {
            window.location.href = "/Quote/findQuote.aspx";
        }
        function UpdateDOB() {

            var currentText;
            currentText = document.getElementById('<%=txtDOB.ClientID%>').value;

            if (currentText.length == 7) {

                document.getElementById('<%=txtDOB.ClientID%>').value = currentText.substring(0, 2) + '/' + currentText.substring(2, 4) + '/' + currentText.substring(4, 8);

            } //end if
        }
        function UpdateSpouseDOB() {

            var currentText;
            currentText = document.getElementById('<%=txtSpouseDOB.ClientID%>').value;

            if (currentText.length == 7) {

                document.getElementById('<%=txtSpouseDOB.ClientID%>').value = currentText.substring(0, 2) + '/' + currentText.substring(2, 4) + '/' + currentText.substring(4, 8);

            } //end if
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
                                    <asp:TextBox ID="txtName" runat="server" Text=""></asp:TextBox>
                                </td>
                                <td align="right">
                                    <asp:Label ID="Label6" runat="server" Text="DOB:" CssClass="AR_Application"></asp:Label>
                                </td>
                                <td>
                                    <asp:TextBox ID="txtDOB" runat="server" Text=""></asp:TextBox>
                                </td>
                            </tr>
                            
                            <tr>
                                <td align="right">
                                    <asp:Label ID="Label12" runat="server" Text="Phone No:" CssClass="AR_Application"></asp:Label>
                                </td>
                                <td>
                                    <asp:TextBox ID="txtPhone" runat="server" Text=""></asp:TextBox>
                                </td>
                                <td align="right">
                                    <asp:Label ID="Label13" runat="server" Text="Occupation:" CssClass="AR_Application"></asp:Label>
                                </td>
                                <td>
                                    <asp:TextBox ID="txtOcc" runat="server" Text=""></asp:TextBox>
                                </td>
                                <td align="right">
                                    <asp:Label ID="Label14" runat="server" Text="Social Security#:" CssClass="AR_Application"></asp:Label>
                                </td>
                                <td>
                                    <asp:TextBox ID="txtSSN" runat="server" Text=""></asp:TextBox>
                                </td>
                            </tr>
                            <tr>
                                <td align="right">
                                    <asp:Label ID="Label15" runat="server" Text="Spouse Name:" CssClass="AR_Application"></asp:Label>
                                </td>
                                <td>
                                    <asp:TextBox ID="txtSpouseName" runat="server" Text=""></asp:TextBox>
                                </td>
                                <td align="right">
                                    <asp:Label ID="Label16" runat="server" Text="Spouse SSN:" CssClass="AR_Application"></asp:Label>
                                </td>
                                <td>
                                    <asp:TextBox ID="txtSpouseSSN" runat="server" Text=""></asp:TextBox>
                                </td>
                                <td align="right">
                                    <asp:Label ID="Label17" runat="server" Text="DOB:" CssClass="AR_Application"></asp:Label>
                                </td>
                                <td>
                                    <asp:TextBox ID="txtSpouseDOB" runat="server" Text=""></asp:TextBox>
                                </td>
                            </tr>
                            <tr>
                                <td align="right">
                                    <asp:Label ID="Label18" runat="server" Text="Add'l Insured:" CssClass="AR_Application"></asp:Label>
                                </td>
                                <td>
                                    <asp:TextBox ID="txtAddInsured" runat="server" Text=""></asp:TextBox>
                                </td>
                            </tr>
                            <tr>
                                <td align="right">
                                    <asp:Label ID="Label35" runat="server" Text="Agent Name:" CssClass="AR_Application"></asp:Label>
                                </td>
                                <td>
                                    <asp:TextBox ID="txtAgentName" runat="server" Text=""></asp:TextBox>
                                </td>
                            </tr>
                            <tr>
                                <td align="right">
                                    <asp:Label ID="Label19" runat="server" Text="Park Name:" CssClass="AR_Application"></asp:Label>
                                </td>
                                <td>
                                    <asp:TextBox ID="txtParkName" runat="server" Text=""></asp:TextBox>
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
                                    <asp:TextBox ID="txtDiffAppAddr" Width="100%" runat="server" Text=""></asp:TextBox>
                                </td>
                            </tr>
                            <tr align="left">
                                <td align="right">
                                    <asp:Label ID="Label21" runat="server" Text="City:" CssClass="AR_Application"></asp:Label>
                                </td>
                                <td>
                                    <asp:TextBox ID="txtDiffAppCity" runat="server" Text=""></asp:TextBox>
                                </td>
                                <td align="right">
                                    <asp:Label ID="Label22" runat="server" Text="State:" CssClass="AR_Application"></asp:Label>
                                </td>
                                <td>
                                    <asp:TextBox ID="txtDiffAppState" runat="server" Width="25px" Text=""></asp:TextBox>
                                </td>
                                <td align="right">
                                    <asp:Label ID="Label23" runat="server" Text="Zip:" CssClass="AR_Application"></asp:Label>
                                </td>
                                <td>
                                    <asp:TextBox ID="txtDiffAppZip" runat="server" Width="50px" Text=""></asp:TextBox>
                                </td>
                                <td align="right">
                                    <asp:Label ID="Label24" runat="server" Text="County:" CssClass="AR_Application"></asp:Label>
                                </td>
                                <td>
                                    <asp:TextBox ID="txtDiffAppCounty" runat="server" Text=""></asp:TextBox>
                                </td>
                                </tr>
                                <tr><td>
                                </td></tr>
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
                                    <asp:TextBox ID="txtAddress" Width="100%" runat="server" Text=""  ></asp:TextBox>
                                </td>
                            </tr>
                            <tr>
                                <td align="right">
                                    <asp:Label ID="Label8" runat="server" Text="City:" CssClass="AR_Application"></asp:Label>
                                </td>
                                <td>
                                    <asp:TextBox ID="txtCity" runat="server" Text=""></asp:TextBox>
                                </td>
                                <td align="right">
                                    <asp:Label ID="Label9" runat="server" Text="State:" CssClass="AR_Application"></asp:Label>
                                </td>
                                <td>
                                    <asp:TextBox ID="txtState" runat="server" Width="25px" Text=""></asp:TextBox>
                                </td>
                                <td align="right">
                                    <asp:Label ID="Label10" runat="server" Text="Zip:" CssClass="AR_Application"></asp:Label>
                                </td>
                                <td>
                                    <asp:TextBox ID="txtZip" runat="server" Width="50px" Text=""></asp:TextBox>
                                </td>
                                <td align="right">
                                    <asp:Label ID="Label11" runat="server" Text="County:" CssClass="AR_Application"></asp:Label>
                                </td>
                                <td>
                                    <asp:TextBox ID="txtCounty" runat="server" Text=""></asp:TextBox>
                                </td>
                            </tr>
                            <tr>
                                <td colspan="2" align="right">
                                    <asp:Label ID="Label26" runat="server" Text="Municipal Tax Code:" CssClass="AR_Application"></asp:Label>
                                </td>
                                <td>
                                    <asp:TextBox ID="txtMunTaxCode" runat="server" Text=""></asp:TextBox>
                                </td>
                                <hr />
                            </tr>
                            <tr>
                                <td colspan="2" align="right">
                                    <asp:Label ID="Label27" runat="server" Text="Distance of unit to fire hydrant:" CssClass="AR_Application"></asp:Label>
                                </td>
                                <td>
                                    <asp:TextBox ID="txtDistToFire" runat="server" Text=""></asp:TextBox>
                                </td>
                            </tr>
                            <tr>
                                <td colspan="2" align="right">
                                    <asp:Label ID="Label28" runat="server" Text="Distance of unit to responding Fire Dept. :" CssClass="AR_Application"></asp:Label>
                                </td>
                                <td>
                                    <asp:TextBox ID="txtDistToFireDept" runat="server" Text=""></asp:TextBox>
                                    <ajaxTK:TextBoxWatermarkExtender ID="TextBoxWatermarkExtender5" runat="server" Enabled="True"
                                        TargetControlID="txtdistToFireDept" WatermarkCssClass="WatermarkCssClass" WatermarkText="Feet" />
                                </td>
                            </tr>
                            <tr>
                                <td colspan="2" align="right">
                                    <asp:Label ID="Label29" runat="server" Text="Name of Fire Department:" CssClass="AR_Application"></asp:Label>
                                </td>
                                <td>
                                    <asp:TextBox ID="txtFireDeptName" runat="server" Text=""></asp:TextBox>
                                </td>
                            </tr>
                            <tr>
                                <td colspan="2" align="right">
                                    <asp:Label ID="Label30" runat="server" Text="Is mobile home located inside of city limits?" CssClass="AR_Application"></asp:Label>
                                </td>
                                <td align="left">
                                    <asp:DropDownList runat="Server" ID="dd_ctylimits">
                                        <asp:ListItem></asp:ListItem>
                                        <asp:ListItem>No</asp:ListItem>
                                        <asp:ListItem>Yes</asp:ListItem>
                                    </asp:DropDownList>
                                </td>
                            </tr>
                            <tr>
                                <td colspan="2" align="right">
                                    <asp:Label ID="Label31" runat="server" Text="Is mobile home in a FWUA eligible area?" CssClass="AR_Application"></asp:Label>
                                </td>
                                <td align="left">
                                    <asp:DropDownList runat="server" ID="dd_fwua">
                                        <asp:ListItem></asp:ListItem>
                                        <asp:ListItem>No</asp:ListItem>
                                        <asp:ListItem>Yes</asp:ListItem>
                                    </asp:DropDownList>
                                </td>
                            </tr>
                            <tr>
                                <td colspan="2" align="right">
                                    <asp:Label ID="Label32" runat="server" Text="Distance from Gulf or Atlantic Coastal Water" CssClass="AR_Application"></asp:Label>
                                </td>
                                <td align="left">
                                    <asp:TextBox ID="txtDistToGulf" Width="75px" runat="server" Text=""></asp:TextBox>
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
                                <td colspan="2" align="left">
                                    <span class="style3">Description of Mobile Additions</span>
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
                                    <asp:TextBox ID="txtDescMHManf" runat="server" Width="" Text=""></asp:TextBox>
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
                                    <asp:TextBox ID="txtDescMHSerial" runat="server" Width="" Text=""></asp:TextBox>
                                </td>
                                <td align="right">
                                    <asp:Label ID="Label39" runat="server" Text="Purchase Date:" CssClass="AR_Application"></asp:Label>
                                </td>
                                <td align="left">
                                    <asp:TextBox ID="txtDescMHPurDate" runat="server" Width="" Text=""></asp:TextBox>
                                </td>
                                <td align="right">
                                    <asp:Label ID="Label40" runat="server" Text="Purchase Price:" CssClass="AR_Application"></asp:Label>
                                </td>
                                <td align="left">
                                    <asp:TextBox ID="txtDescMHPurPrice" runat="server" Width="" Text=""></asp:TextBox>
                                </td>
                                <td align="right">
                                    <asp:Label ID="Label41" runat="server" Text="Current Date:" CssClass="AR_Application"></asp:Label>
                                </td>
                                <td align="left">
                                    <asp:TextBox ID="txtDescMHCurDate" runat="server" Width="" Text=""></asp:TextBox>
                                </td>
                            </tr>
                            <tr>
                                <td align="right">
                                    <asp:Label ID="Label42" runat="server" Text="Describe Additions/<br/>Attached Structures:" CssClass="AR_Application"></asp:Label>
                                </td>
                                <td align="left">
                                    <asp:TextBox ID="txtDescMHAttStruc" runat="server" Width="200px" Text=""></asp:TextBox>
                                </td>
                                <td align="right">
                                    <asp:Label ID="Label43" runat="server" Text="Age:" CssClass="AR_Application"></asp:Label>
                                </td>
                                <td align="left">
                                    <asp:TextBox ID="txtDescMHAttStrucAge" runat="server" Width="75px" Text=""></asp:TextBox>
                                </td>
                                <td align="right">
                                    <asp:Label ID="Label44" runat="server" Text="Size:" CssClass="AR_Application"></asp:Label>
                                </td>
                                <td align="left">
                                    <asp:TextBox ID="txtDescMHAttStrucSize" runat="server" Width="75px" Text=""></asp:TextBox>
                                </td>
                                <td align="right">
                                    <asp:Label ID="Label45" runat="server" Text="Current Value:" CssClass="AR_Application"></asp:Label>
                                </td>
                                <td align="left">
                                    <asp:TextBox ID="txtDescMHAttStrucCurVal" runat="server" Width="" Text=""></asp:TextBox>
                                </td>
                            </tr>
                            <tr>
                                <td align="right">
                                    <asp:Label ID="Label46" runat="server" Text="Describe Unattached<br/> Structures:" CssClass="AR_Application"></asp:Label>
                                </td>
                                <td align="left">
                                    <asp:TextBox ID="txtDescMHUnAttStruc" runat="server" Width="200px" Text=""></asp:TextBox>
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
                                    <asp:TextBox ID="txtDescMHUnAttStrucCurVal" runat="server" Width="" Text=""></asp:TextBox>
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
                                    <asp:Label ID="lblTerritory" runat="server" Text=""></asp:Label>
                                </td>
                            </tr>
                            <tr align="left">
                                <td align="right">
                                    <asp:Label ID="Label51" runat="server" Text="Program:" CssClass="AR_Application"></asp:Label>
                                </td>
                                <td>
                                    <asp:dropdownlist runat="server" ID="ddProgram" RepeatDirection="Horizontal"  CssClass="AR_Application">
                                        <asp:ListItem>Package</asp:ListItem>
                                        <asp:ListItem>Standard</asp:ListItem>
                                        <asp:ListItem>Rental</asp:ListItem>
                                    </asp:dropdownlist>
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
                                </td>
                            </tr>
                            <tr align="left">
                                <td align="right">
                                    <asp:Label ID="Label53" runat="server" Text="ANSI/ASCE 7/88:"  CssClass="AR_Application"></asp:Label>
                                </td>
                                <td>
                                    <asp:dropdownlist runat="server" ID="ddProt" RepeatDirection="Horizontal"  CssClass="AR_Application">
                                        <asp:ListItem>Protected</asp:ListItem>
                                        <asp:ListItem>Unprotected</asp:ListItem>
                                    </asp:dropdownlist>
                                </td>
                            </tr>
                            <tr align="left">
                                <td align="right">
                                    <asp:Label ID="Label54" runat="server" Text="Age of Insured:" CssClass="AR_Application"></asp:Label>
                                </td>
                                <td>
                                    <asp:TextBox ID="txtInsAge" runat="server" Text=""></asp:TextBox>
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
                                </td>
                            </tr>
                            <tr align="left">
                                <td align="right">
                                    <asp:Label ID="Label56" runat="server" Text="Loss History:" CssClass="AR_Application"></asp:Label>
                                    <br />
                                    <small>Claim Free for
                                        <br />
                                        at least one year?</small>
                                </td>
                                <td>
                                    <asp:DropDownList ID="ddlossHist" runat="server" TabIndex="19">
                                        <asp:ListItem></asp:ListItem>
                                        <asp:ListItem>Yes</asp:ListItem>
                                        <asp:ListItem>No</asp:ListItem>
                                    </asp:DropDownList>
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
                                </td>
                            </tr>
                            <tr id="park1" style="display: none">
                                <td align="right">
                                    <asp:Label ID="Label58" runat="server" Text="If no, # of Acres:" CssClass="AR_Application"></asp:Label>
                                </td>
                                <td>
                                    <asp:TextBox ID="txtAcres" runat="server" Text=""></asp:TextBox>
                                </td>
                            </tr>
                            <tr id="park2" style="display: none">
                                <td align="right">
                                    <asp:Label ID="Label59" runat="server" Text="If Yes, # of Spaces:" CssClass="AR_Application"></asp:Label>
                                </td>
                                <td>
                                    <asp:TextBox ID="txtNumOfSpaces" runat="server" Text=""></asp:TextBox>
                                </td>
                                <td align="right">
                                    <asp:Label ID="Label60" runat="server" Text="% of Adult:" CssClass="AR_Application"></asp:Label>
                                </td>
                                <td>
                                    <asp:TextBox ID="txtPerOfAdults" runat="server" Text=""></asp:TextBox>
                                </td>
                                <td align="right">
                                    <asp:Label ID="Label61" runat="server" Text="Resident Manager?:" CssClass="AR_Application"></asp:Label>
                                    <small>In a Park?</small>
                                </td>
                                <td>
                                    <asp:DropDownList ID="ddResManger" runat="server" TabIndex="19">
                                        <asp:ListItem></asp:ListItem>
                                        <asp:ListItem>Yes</asp:ListItem>
                                        <asp:ListItem>No</asp:ListItem>
                                    </asp:DropDownList>
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
                                </td>
                            </tr>
                            <tr align="left">
                                <td align="right">
                                    <asp:Label ID="Label63" runat="server" Text="Front: Number of Steps:" CssClass="AR_Application"></asp:Label>
                                </td>
                                <td>
                                    <asp:TextBox ID="txtNumOfFrontSteps" runat="server" Text=""></asp:TextBox>
                                </td>
                                <td align="right">
                                    <asp:Label ID="Label64" runat="server" Text="Rear: Number of Steps:" CssClass="AR_Application"></asp:Label>
                                </td>
                                <td>
                                    <asp:TextBox ID="txtNumOfRearSteps" runat="server" Text=""></asp:TextBox>
                                </td>
                            </tr>
                            <tr align="left">
                                <td align="right">
                                    <asp:Label ID="Label65" runat="server" Text="Supplemental Heating:" CssClass="AR_Application"></asp:Label>
                                </td>
                                <td>
                                    <asp:DropDownList ID="ddSupHeating" runat="server" TabIndex="19">
                                        <asp:ListItem>None</asp:ListItem>
                                        <asp:ListItem>Fireplace</asp:ListItem>
                                        <asp:ListItem>Woodburning Stove</asp:ListItem>
                                        <asp:ListItem>Other</asp:ListItem>
                                    </asp:DropDownList>
                                    <div id="supHeatOtherRow" style="display: none">
                                        <asp:Label ID="Label66" runat="server" Text="Other:" CssClass="AR_Application"></asp:Label>
                                        &nbsp;
                                        <asp:TextBox id="txtSupHeatOther" runat="server" Text=""></asp:TextBox>
                                        <br />
                                        <asp:Label ID="Label67" runat="server" Text="Is the unit factory installed?:" CssClass="AR_Application"></asp:Label>
                                        <asp:DropDownList ID="ddSupHeatingFacInst" runat="server" TabIndex="19">
                                            <asp:ListItem></asp:ListItem>
                                            <asp:ListItem>Yes</asp:ListItem>
                                            <asp:ListItem>No</asp:ListItem>
                                        </asp:DropDownList>
                                    </div>
                                </td>
                            </tr>
                            <tr align="left">
                                <td align="right">
                                    <asp:Label ID="Label68" runat="server" Text="Satellite Dish System:" CssClass="AR_Application"></asp:Label>
                                </td>
                                <td>
                                    <asp:DropDownList ID="ddSatDish" runat="server" TabIndex="19">
                                        <asp:ListItem></asp:ListItem>
                                        <asp:ListItem>Yes</asp:ListItem>
                                        <asp:ListItem>No</asp:ListItem>
                                    </asp:DropDownList>
                                </td>
                            </tr>
                            <tr align="left">
                                <td align="right">
                                    <asp:Label ID="Label71" runat="server" Text="Animals on Premises:" CssClass="AR_Application"></asp:Label>
                                </td>
                                <td>
                                    <asp:DropDownList ID="ddAnimal" runat="server" TabIndex="19">
                                        <asp:ListItem></asp:ListItem>
                                        <asp:ListItem>Yes</asp:ListItem>
                                        <asp:ListItem>No</asp:ListItem>
                                    </asp:DropDownList>
                                    <div id="animal" style="display: none">
                                        <asp:Label ID="Label72" runat="server" Text="Type of Animal:" CssClass="AR_Application"></asp:Label>
                                        &nbsp;
                                        <asp:TextBox ID="txtAnimalType" runat="server" Text=""></asp:TextBox>
                                        <asp:Label ID="Label73" runat="server" Text="Breed of Dog:" CssClass="AR_Application"></asp:Label>
                                        &nbsp;
                                        <asp:TextBox ID="txtDogBreed" runat="server" Text=""></asp:TextBox>
                                    </div>
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
                            <tr align="left" style="border: 1px solid">
                                <td align="right">
                                    <asp:Label ID="Label74" runat="server" Text="Name:" CssClass="AR_Application"></asp:Label>
                                </td>
                                <td>
                                    <asp:TextBox ID="txtLien1Name" runat="server" Text=""></asp:TextBox>
                                </td>
                                <hr />
                            </tr>
                            <tr>
                                <td align="right">
                                    <asp:Label ID="Label75" runat="server" Text="Loan #:" CssClass="AR_Application"></asp:Label>
                                </td>
                                <td>
                                    <asp:TextBox ID="txtLien1Num" runat="server" Text=""></asp:TextBox>
                                </td>
                            </tr>
                            <tr>
                                <td align="right">
                                    <asp:Label ID="Label76" runat="server" Text="Address:" CssClass="AR_Application"></asp:Label>
                                </td>
                                <td colspan="3">
                                    <asp:TextBox ID="txtLien1Addr" Width="100%" runat="server" Text=""></asp:TextBox>
                                </td>
                            </tr>
                            <tr>
                                <td align="right">
                                    <asp:Label ID="Label77" runat="server" Text="City:" CssClass="AR_Application"></asp:Label>
                                </td>
                                <td>
                                    <asp:TextBox ID="txtLien1City" runat="server" Text=""></asp:TextBox>
                                </td>
                                <td align="right">
                                    <asp:Label ID="Label78" runat="server" Text="State:" CssClass="AR_Application"></asp:Label>
                                </td>
                                <td>
                                    <asp:TextBox ID="txtLien1State" runat="server" Width="25px" Text=""></asp:TextBox>
                                </td>
                                <td align="right">
                                    <asp:Label ID="Label79" runat="server" Text="Zip:" CssClass="AR_Application"></asp:Label>
                                </td>
                                <td>
                                    <asp:TextBox ID="txtLien1Zip" runat="server" Width="50px" Text=""></asp:TextBox>
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
                                    <asp:TextBox ID="txtLien2Name" runat="server" Text=""></asp:TextBox>
                                </td>
                            </tr>
                            <tr>
                                <td align="right">
                                    <asp:Label ID="Label81" runat="server" Text="Loan #:" CssClass="AR_Application"></asp:Label>
                                </td>
                                <td>
                                    <asp:TextBox ID="txtLien2Num" runat="server" Text=""></asp:TextBox>
                                </td>
                            </tr>
                            <tr>
                                <td align="right">
                                    <asp:Label ID="Label82" runat="server" Text="Address:" CssClass="AR_Application"></asp:Label>
                                </td>
                                <td colspan="3">
                                    <asp:TextBox ID="txtLien2Addr" Width="100%" runat="server" Text=""></asp:TextBox>
                                </td>
                            </tr>
                            <tr>
                                <td align="right">
                                    <asp:Label ID="Label83" runat="server" Text="City:" CssClass="AR_Application"></asp:Label>
                                </td>
                                <td>
                                    <asp:TextBox ID="txtLien2City" runat="server" Text=""></asp:TextBox>
                                </td>
                                <td align="right">
                                    <asp:Label ID="Label84" runat="server" Text="State:" CssClass="AR_Application"></asp:Label>
                                </td>
                                <td>
                                    <asp:TextBox ID="txtLien2State" runat="server" Width="25px" Text=""></asp:TextBox>
                                </td>
                                <td align="right">
                                    <asp:Label ID="Label85" runat="server" Text="Zip:" CssClass="AR_Application"></asp:Label>
                                </td>
                                <td>
                                    <asp:TextBox ID="txtLien2Zip" runat="server" Width="50px" Text=""></asp:TextBox>
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
                                    <div id="priorInsurance" style="display: none">
                                        <asp:Label ID="Label70" runat="server" Text="Prior Company & Years of Insurance:" CssClass="AR_Application"></asp:Label>
                                        &nbsp;
                                        <asp:TextBox ID="txtPriorCompany" runat="server" Text=""></asp:TextBox>
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
                                    <asp:TextBox ID="txtLoss1Description" runat="server" Casing="UPPER" Columns="20"
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
                                    <asp:TextBox ID="txtLoss2Description" runat="server" Casing="UPPER" Columns="20"
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
                                    <asp:TextBox ID="txtLoss3Description" runat="server" Casing="UPPER" Columns="20"
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
                    <table title="Unacceptable Risks">
                        <tbody>
                            <tr style="border-bottom: 1px; border-bottom-color: Black">
                                <td colspan="2" align="left">
                                    <span class="style3">Unacceptable Risks</span>
                                </td>
                                <hr />
                            </tr>
                            <tr align="left">
                                <td align="left">
                                    <asp:Label ID="Label87" runat="server" Text="1. Has the applicant had a total fire loss in the past 5 years?" CssClass="AR_Application"></asp:Label>
                                </td>
                                <td>
                                    <asp:DropDownList ID="dd_ARIng1" runat="server" TabIndex="19">
                                        <asp:ListItem></asp:ListItem>
                                        <asp:ListItem>Yes</asp:ListItem>
                                        <asp:ListItem>No</asp:ListItem>
                                    </asp:DropDownList>
                                </td>
                            </tr>
                            <tr align="left">
                                <td align="left">
                                    <asp:Label ID="Label88" runat="server" Text="2. Is the home NOT fully skirted?" CssClass="AR_Application"></asp:Label>
                                </td>
                                <td>
                                    <asp:DropDownList ID="dd_ARIng2" runat="server" TabIndex="19">
                                        <asp:ListItem></asp:ListItem>
                                        <asp:ListItem>Yes</asp:ListItem>
                                        <asp:ListItem>No</asp:ListItem>
                                    </asp:DropDownList>
                                </td>
                            </tr>
                            <tr align="left">
                                <td align="left">
                                    <asp:Label ID="Label86" runat="server" Text="3. Has the applicant been convicted of arson, fraud or a felony?" CssClass="AR_Application"></asp:Label>
                                </td>
                                <td>
                                    <asp:DropDownList ID="dd_ARIng3" runat="server" TabIndex="19">
                                        <asp:ListItem></asp:ListItem>
                                        <asp:ListItem>Yes</asp:ListItem>
                                        <asp:ListItem>No</asp:ListItem>
                                    </asp:DropDownList>
                                </td>
                            </tr>
                            <tr align="left">
                                <td align="left">
                                    <asp:Label ID="Label89" runat="server" Text="4. Is the home custom built, homemade, substantially modified or joined together?" CssClass="AR_Application"></asp:Label>
                                </td>
                                <td>
                                    <asp:DropDownList ID="dd_ARIng4" runat="server" TabIndex="19">
                                        <asp:ListItem></asp:ListItem>
                                        <asp:ListItem>Yes</asp:ListItem>
                                        <asp:ListItem>No</asp:ListItem>
                                    </asp:DropDownList>
                                </td>
                            </tr>
                            <tr align="left">
                                <td align="left">
                                    <asp:Label ID="Label90" runat="server" Text="5. Is the home without permanently installed water, electricity, and sewage utility services?" CssClass="AR_Application"></asp:Label>
                                </td>
                                <td>
                                    <asp:DropDownList ID="dd_ARIng5" runat="server" TabIndex="19">
                                        <asp:ListItem></asp:ListItem>
                                        <asp:ListItem>Yes</asp:ListItem>
                                        <asp:ListItem>No</asp:ListItem>
                                    </asp:DropDownList>
                                </td>
                            </tr>
                            <tr align="left">
                                <td align="left">
                                    <asp:Label ID="Label91" runat="server" Text="6. Does the home have existing structural damage or has it been salvaged?" CssClass="AR_Application"></asp:Label>
                                </td>
                                <td>
                                    <asp:DropDownList ID="dd_ARIng6" runat="server" TabIndex="19">
                                        <asp:ListItem></asp:ListItem>
                                        <asp:ListItem>Yes</asp:ListItem>
                                        <asp:ListItem>No</asp:ListItem>
                                    </asp:DropDownList>
                                </td>
                            </tr>
                            <tr align="left">
                                <td align="left">
                                    <asp:Label ID="Label93" runat="server" Text="7. Is the home under construction or major renovation?" CssClass="AR_Application"></asp:Label>
                                </td>
                                <td>
                                    <asp:DropDownList ID="dd_ARIng7" runat="server" TabIndex="19">
                                        <asp:ListItem></asp:ListItem>
                                        <asp:ListItem>Yes</asp:ListItem>
                                        <asp:ListItem>No</asp:ListItem>
                                    </asp:DropDownList>
                                </td>
                            </tr>
                            <tr align="left">
                                <td align="left">
                                    <asp:Label ID="Label94" runat="server" Text="8. Is the home vacant?" CssClass="AR_Application"></asp:Label>
                                </td>
                                <td>
                                    <asp:DropDownList ID="dd_ARIng8" runat="server" TabIndex="19">
                                        <asp:ListItem></asp:ListItem>
                                        <asp:ListItem>Yes</asp:ListItem>
                                        <asp:ListItem>No</asp:ListItem>
                                    </asp:DropDownList>
                                </td>
                            </tr>
                            <tr align="left">
                                <td align="left">
                                    <asp:Label ID="Label95" runat="server" Text="9. Is the home isolated and not easily accessible to public roadways?" CssClass="AR_Application"></asp:Label>
                                </td>
                                <td>
                                    <asp:DropDownList ID="dd_ARIng9" runat="server" TabIndex="19">
                                        <asp:ListItem></asp:ListItem>
                                        <asp:ListItem>Yes</asp:ListItem>
                                        <asp:ListItem>No</asp:ListItem>
                                    </asp:DropDownList>
                                </td>
                            </tr>
                            <tr align="left">
                                <td align="left">
                                    <asp:Label ID="Label96" runat="server" Text="10. Does the home have a kerosene heater, portable space heater, heat reclaiming device, homemade heating devices, or any potentially hazardous supplemental heating device?" CssClass="AR_Application"></asp:Label>
                                </td>
                                <td>
                                    <asp:DropDownList ID="dd_ARIng10" runat="server" TabIndex="19">
                                        <asp:ListItem></asp:ListItem>
                                        <asp:ListItem>Yes</asp:ListItem>
                                        <asp:ListItem>No</asp:ListItem>
                                    </asp:DropDownList>
                                </td>
                            </tr>
                            <tr align="left">
                                <td align="left">
                                    <asp:Label ID="Label97" runat="server" Text="11. Does the home have a wood, coal or pellet burning device that is used as the primary source of heat?" CssClass="AR_Application"></asp:Label>
                                </td>
                                <td>
                                    <asp:DropDownList ID="dd_ARIng11" runat="server" TabIndex="19">
                                        <asp:ListItem></asp:ListItem>
                                        <asp:ListItem>Yes</asp:ListItem>
                                        <asp:ListItem>No</asp:ListItem>
                                    </asp:DropDownList>
                                </td>
                            </tr>
                            <tr align="left">
                                <td align="left">
                                    <asp:Label ID="Label98" runat="server" Text="12. Does the home have a fireplace that was not installed by the manufacturer or a licensed contractor?" CssClass="AR_Application"></asp:Label>
                                </td>
                                <td>
                                    <asp:DropDownList ID="dd_ARIng12" runat="server" TabIndex="19">
                                        <asp:ListItem></asp:ListItem>
                                        <asp:ListItem>Yes</asp:ListItem>
                                        <asp:ListItem>No</asp:ListItem>
                                    </asp:DropDownList>
                                </td>
                            </tr>
                            <tr align="left">
                                <td align="left">
                                    <asp:Label ID="Label99" runat="server" Text="13. Does the home have fuses or Polybutelene pipes?" CssClass="AR_Application"></asp:Label>
                                </td>
                                <td>
                                    <asp:DropDownList ID="dd_ARIng13" runat="server" TabIndex="19">
                                        <asp:ListItem></asp:ListItem>
                                        <asp:ListItem>Yes</asp:ListItem>
                                        <asp:ListItem>No</asp:ListItem>
                                    </asp:DropDownList>
                                </td>
                            </tr>
                            <tr align="left">
                                <td align="left">
                                    <asp:Label ID="Label100" runat="server" Text="14. Does the home have an open foundation or is it built on stilts, posts or piers?" CssClass="AR_Application"></asp:Label>
                                </td>
                                <td>
                                    <asp:DropDownList ID="dd_ARIng14" runat="server" TabIndex="19">
                                        <asp:ListItem></asp:ListItem>
                                        <asp:ListItem>Yes</asp:ListItem>
                                        <asp:ListItem>No</asp:ListItem>
                                    </asp:DropDownList>
                                </td>
                            </tr>
                            <tr align="left">
                                <td align="left">
                                    <asp:Label ID="Label101" runat="server" Text="15. Is the home or any structure used to store flammables or explosive materials?" CssClass="AR_Application"></asp:Label>
                                </td>
                                <td>
                                    <asp:DropDownList ID="dd_ARIng15" runat="server" TabIndex="19">
                                        <asp:ListItem></asp:ListItem>
                                        <asp:ListItem>Yes</asp:ListItem>
                                        <asp:ListItem>No</asp:ListItem>
                                    </asp:DropDownList>
                                </td>
                            </tr>
                            <tr align="left">
                                <td align="left">
                                    <asp:Label ID="Label102" runat="server" Text="16. Is the home located in an area subject to floods, mudslides or forest fires?" CssClass="AR_Application"></asp:Label>
                                </td>
                                <td>
                                    <asp:DropDownList ID="dd_ARIng16" runat="server" TabIndex="19">
                                        <asp:ListItem></asp:ListItem>
                                        <asp:ListItem>Yes</asp:ListItem>
                                        <asp:ListItem>No</asp:ListItem>
                                    </asp:DropDownList>
                                </td>
                            </tr>
                            <tr align="left">
                                <td align="left">
                                    <asp:Label ID="Label103" runat="server" Text="17. Is the home located on an island, key, peninsula or within 1,500 feet from any river or body of saltwater?" CssClass="AR_Application"></asp:Label>
                                </td>
                                <td>
                                    <asp:DropDownList ID="dd_ARIng17" runat="server" TabIndex="19">
                                        <asp:ListItem></asp:ListItem>
                                        <asp:ListItem>Yes</asp:ListItem>
                                        <asp:ListItem>No</asp:ListItem>
                                    </asp:DropDownList>
                                </td>
                            </tr>
                            <tr align="left">
                                <td align="left">
                                    <asp:Label ID="Label104" runat="server" Text="18. Is the brush clearance less than 350 ft. from the home?" CssClass="AR_Application"></asp:Label>
                                </td>
                                <td>
                                    <asp:DropDownList ID="dd_ARIng18" runat="server" TabIndex="19">
                                        <asp:ListItem></asp:ListItem>
                                        <asp:ListItem>Yes</asp:ListItem>
                                        <asp:ListItem>No</asp:ListItem>
                                    </asp:DropDownList>
                                </td>
                            </tr>
                            <tr align="left">
                                <td align="left">
                                    <asp:Label ID="Label105" runat="server" Text="19. Does the home have more than 2 lien holders?" CssClass="AR_Application"></asp:Label>
                                </td>
                                <td>
                                    <asp:DropDownList ID="dd_ARIng19" runat="server" TabIndex="19">
                                        <asp:ListItem></asp:ListItem>
                                        <asp:ListItem>Yes</asp:ListItem>
                                        <asp:ListItem>No</asp:ListItem>
                                    </asp:DropDownList>
                                </td>
                            </tr>
                            <tr align="left">
                                <td align="left">
                                    <asp:Label ID="Label106" runat="server" Text="20. Is there any business, childcare, homecare, lodging, or farming activities conducted on the premises?" CssClass="AR_Application"></asp:Label>
                                </td>
                                <td>
                                    <asp:DropDownList ID="dd_ARIng20" runat="server" TabIndex="19">
                                        <asp:ListItem></asp:ListItem>
                                        <asp:ListItem>Yes</asp:ListItem>
                                        <asp:ListItem>No</asp:ListItem>
                                    </asp:DropDownList>
                                </td>
                            </tr>
                            <tr align="left">
                                <td align="left">
                                    <asp:Label ID="Label107" runat="server" Text="21. Are there any unattached adjacent structures not incidental to the use of the home as a dwelling including" CssClass="AR_Application"></asp:Label>
                                </td>
                                <td>
                                    <asp:DropDownList ID="dd_ARIng21" runat="server" TabIndex="19">
                                        <asp:ListItem></asp:ListItem>
                                        <asp:ListItem>Yes</asp:ListItem>
                                        <asp:ListItem>No</asp:ListItem>
                                    </asp:DropDownList>
                                </td>
                            </tr>
                            <tr align="left">
                                <td align="left">
                                    <asp:Label ID="Label108" runat="server" Text="22. Is the awning made of cloth or canvas?" CssClass="AR_Application"></asp:Label>
                                </td>
                                <td>
                                    <asp:DropDownList ID="dd_ARIng22" runat="server" TabIndex="19">
                                        <asp:ListItem></asp:ListItem>
                                        <asp:ListItem>Yes</asp:ListItem>
                                        <asp:ListItem>No</asp:ListItem>
                                    </asp:DropDownList>
                                </td>
                            </tr>
                            <tr align="left">
                                <td align="left">
                                    <asp:Label ID="Label109" runat="server" Text="23. Are activities being conducted on the premises, such as woodworking, cabinet making, auto repair, chemical processing or is the home attached to a tavern or restaurant?" CssClass="AR_Application"></asp:Label>
                                </td>
                                <td>
                                    <asp:DropDownList ID="dd_ARIng23" runat="server" TabIndex="19">
                                        <asp:ListItem></asp:ListItem>
                                        <asp:ListItem>Yes</asp:ListItem>
                                        <asp:ListItem>No</asp:ListItem>
                                    </asp:DropDownList>
                                </td>
                            </tr>
                            <tr align="left">
                                <td align="left">
                                    <asp:Label ID="Label110" runat="server" Text="24. Is there a trampoline on the premises?" CssClass="AR_Application"></asp:Label>
                                </td>
                                <td>
                                    <asp:DropDownList ID="dd_ARIng24" runat="server" TabIndex="19">
                                        <asp:ListItem></asp:ListItem>
                                        <asp:ListItem>Yes</asp:ListItem>
                                        <asp:ListItem>No</asp:ListItem>
                                    </asp:DropDownList>
                                </td>
                            </tr>
                            <tr align="left">
                                <td align="left">
                                    <asp:Label ID="Label111" runat="server" Text="25. Is there a swimming pool or jacuzzi on the premises that does not have a four-foot fence with a self-locking gate or a swimming pool</br> that has a diving board or slide? (If yes, the risk may be written if NO liability coverage is purchased.) If the pool is properly fenced and has no diving board or slide, <br/>the policy may be written with a $50,000 maximum liability limit." CssClass="AR_Application"></asp:Label>
                                </td>
                                <td>
                                    <asp:DropDownList ID="dd_ARIng25" runat="server" TabIndex="19">
                                        <asp:ListItem></asp:ListItem>
                                        <asp:ListItem>Yes</asp:ListItem>
                                        <asp:ListItem>No</asp:ListItem>
                                    </asp:DropDownList>
                                </td>
                            </tr>
                            <tr align="left">
                                <td align="left">
                                    <asp:Label ID="Label112" runat="server" Text="26. Is there a dock, pier or boathouse on the premises? (If yes, the risk may be written if NO liability coverage is purchased.)" CssClass="AR_Application"></asp:Label>
                                </td>
                                <td>
                                    <asp:DropDownList ID="dd_ARIng26" runat="server" TabIndex="19">
                                        <asp:ListItem></asp:ListItem>
                                        <asp:ListItem>Yes</asp:ListItem>
                                        <asp:ListItem>No</asp:ListItem>
                                    </asp:DropDownList>
                                </td>
                            </tr>
                            <tr align="left">
                                <td align="left">
                                    <asp:Label ID="Label113" runat="server" Text="27. Is the home without permanently installed steps at all entrances? (If yes, the risk may be written if NO liability coverage is purchased.)" CssClass="AR_Application"></asp:Label>
                                </td>
                                <td>
                                    <asp:DropDownList ID="dd_ARIng27" runat="server" TabIndex="19">
                                        <asp:ListItem></asp:ListItem>
                                        <asp:ListItem>Yes</asp:ListItem>
                                        <asp:ListItem>No</asp:ListItem>
                                    </asp:DropDownList>
                                </td>
                            </tr>
                            <tr align="left">
                                <td align="left">
                                    <asp:Label ID="Label114" runat="server" Text="28. Does the applicant own, keep, or shelter any of the following breeds: This includes but is not limited to Akitas, Chows, Dobermans, Great Danes, Pit Bulls, Rottweilers, Wolfs or <br/> Wolf Hybrids, any mix of these breeds, any animal with a previous bite history or any exotic (snakes, monkeys, etc.) animals?" CssClass="AR_Application"></asp:Label>
                                </td>
                                <td>
                                    <asp:DropDownList ID="dd_ARIng28" runat="server" TabIndex="19">
                                        <asp:ListItem></asp:ListItem>
                                        <asp:ListItem>Yes</asp:ListItem>
                                        <asp:ListItem>No</asp:ListItem>
                                    </asp:DropDownList>
                                </td>
                            </tr>
                            <tr align="left">
                                <td align="left">
                                    <asp:Label ID="Label115" runat="server" Text="29. Has the applicant had any loss (property damage or liability) in the past 5 years? If yes, give date of loss, describe the loss and the amount paid to repair the damage." CssClass="AR_Application"></asp:Label>
                                </td>
                                <td>
                                    <asp:DropDownList ID="dd_ARIng29" runat="server" TabIndex="19">
                                        <asp:ListItem></asp:ListItem>
                                        <asp:ListItem>Yes</asp:ListItem>
                                        <asp:ListItem>No</asp:ListItem>
                                    </asp:DropDownList>
                                </td>
                            </tr>
                            <tr align="left">
                                <td align="left">
                                    <asp:Label ID="Label116" runat="server" Text="30. Has the applicant had a mobile home/dwelling policy cancelled or non-renewed for underwriting reasons (except age of unit) during the past 5 years?" CssClass="AR_Application"></asp:Label>
                                </td>
                                <td>
                                    <asp:DropDownList ID="dd_ARIng30" runat="server" TabIndex="19">
                                        <asp:ListItem></asp:ListItem>
                                        <asp:ListItem>Yes</asp:ListItem>
                                        <asp:ListItem>No</asp:ListItem>
                                    </asp:DropDownList>
                                </td>
                            </tr>
                            <tr align="left">
                                <td align="left">
                                    <asp:Label ID="Label117" runat="server" Text="31. Has the applicant had a foreclosure, repossession, or filed for bankrupcty in the past 5 years?" CssClass="AR_Application"></asp:Label>
                                </td>
                                <td>
                                    <asp:DropDownList ID="dd_ARIng31" runat="server" TabIndex="19">
                                        <asp:ListItem></asp:ListItem>
                                        <asp:ListItem>Yes</asp:ListItem>
                                        <asp:ListItem>No</asp:ListItem>
                                    </asp:DropDownList>
                                </td>
                            </tr>
                            <tr align="left">
                                <td align="left">
                                    <asp:Label ID="Label118" runat="server" Text="32. Has the applicant had multiple bad debts or been delinquent in mortgage payments in the past year?" CssClass="AR_Application"></asp:Label>
                                </td>
                                <td>
                                    <asp:DropDownList ID="dd_ARIng32" runat="server" TabIndex="19">
                                        <asp:ListItem></asp:ListItem>
                                        <asp:ListItem>Yes</asp:ListItem>
                                        <asp:ListItem>No</asp:ListItem>
                                    </asp:DropDownList>
                                </td>
                            </tr>
                            <tr align="left">
                                <td align="left">
                                    <asp:Label ID="Label119" runat="server" Text="33. Is the applicant unemployed? (Retirees with guaranteed income and disabled persons with a consistent income are considered employed.)" CssClass="AR_Application"></asp:Label>
                                </td>
                                <td>
                                    <asp:DropDownList ID="dd_ARIng33" runat="server" TabIndex="19">
                                        <asp:ListItem></asp:ListItem>
                                        <asp:ListItem>Yes</asp:ListItem>
                                        <asp:ListItem>No</asp:ListItem>
                                    </asp:DropDownList>
                                </td>
                            </tr>
                            <tr align="left">
                                <td align="left">
                                    <asp:Label ID="Label120" runat="server" Text="34. Has the applicant had a lapse in insurance coverage? (Not applicable to new purchases)" CssClass="AR_Application"></asp:Label>
                                </td>
                                <td>
                                    <asp:DropDownList ID="dd_ARIng34" runat="server" TabIndex="19">
                                        <asp:ListItem></asp:ListItem>
                                        <asp:ListItem>Yes</asp:ListItem>
                                        <asp:ListItem>No</asp:ListItem>
                                    </asp:DropDownList>
                                </td>
                            </tr>
                            <tr align="left">
                                <td align="left">
                                    <asp:Label ID="Label121" runat="server" Text="35. Does the home have 3 or more steps on any exit without a handrail? Photos must be included." CssClass="AR_Application"></asp:Label>
                                </td>
                                <td>
                                    <asp:DropDownList ID="dd_ARIng35" runat="server" TabIndex="19">
                                        <asp:ListItem></asp:ListItem>
                                        <asp:ListItem>Yes</asp:ListItem>
                                        <asp:ListItem>No</asp:ListItem>
                                    </asp:DropDownList>
                                </td>
                            </tr>
                            <tr align="left">
                                <td align="left">
                                    <asp:Label ID="Label122" runat="server" Text="36. Does the home have attached or unattached structures (other than porches, decks, awnings, skirting or carports) that are not factory or non-contractor built? Any addition<br/> must have been inspected for compliance to local codes or been completed for at least 3 years. Photos must be included." CssClass="AR_Application"></asp:Label>
                                </td>
                                <td>
                                    <asp:DropDownList ID="dd_ARIng36" runat="server" TabIndex="19">
                                        <asp:ListItem></asp:ListItem>
                                        <asp:ListItem>Yes</asp:ListItem>
                                        <asp:ListItem>No</asp:ListItem>
                                    </asp:DropDownList>
                                </td>
                            </tr>
                            <tr align="left">
                                <td align="left">
                                    <asp:Label ID="Label123" runat="server" Text="37. Does the home have a wood, coal, or pellet burning device? Woodstove Inspection Report must be included." CssClass="AR_Application"></asp:Label>
                                </td>
                                <td>
                                    <asp:DropDownList ID="dd_ARIng37" runat="server" TabIndex="19">
                                        <asp:ListItem></asp:ListItem>
                                        <asp:ListItem>Yes</asp:ListItem>
                                        <asp:ListItem>No</asp:ListItem>
                                    </asp:DropDownList>
                                </td>
                            </tr>
                            <tr align="left">
                                <td align="left">
                                    <asp:Label ID="Label124" runat="server" Text="38. Does the home have more than two unrelated owners?" CssClass="AR_Application"></asp:Label>
                                </td>
                                <td>
                                    <asp:DropDownList ID="dd_ARIng38" runat="server" TabIndex="19">
                                        <asp:ListItem></asp:ListItem>
                                        <asp:ListItem>Yes</asp:ListItem>
                                        <asp:ListItem>No</asp:ListItem>
                                    </asp:DropDownList>
                                </td>
                            </tr>
                            <tr align="left">
                                <td align="left">
                                    <asp:Label ID="Label125" runat="server" Text="39. Is the home located in a Special Flood Hazard Area or within 1,500 feet of a lake, pond or creek?" CssClass="AR_Application"></asp:Label>
                                </td>
                                <td>
                                    <asp:DropDownList ID="dd_ARIng39" runat="server" TabIndex="19">
                                        <asp:ListItem></asp:ListItem>
                                        <asp:ListItem>Yes</asp:ListItem>
                                        <asp:ListItem>No</asp:ListItem>
                                    </asp:DropDownList>
                                </td>
                            </tr>
                            <tr align="left">
                                <td align="left">
                                    <asp:Label ID="Label126" runat="server" Text="40. Is the home a corporate risk or is property sold on a land contract?" CssClass="AR_Application"></asp:Label>
                                </td>
                                <td>
                                    <asp:DropDownList ID="dd_ARIng40" runat="server" TabIndex="19">
                                        <asp:ListItem></asp:ListItem>
                                        <asp:ListItem>Yes</asp:ListItem>
                                        <asp:ListItem>No</asp:ListItem>
                                    </asp:DropDownList>
                                </td>
                            </tr>
                            <tr align="left">
                                <td align="left">
                                    <asp:Label ID="Label127" runat="server" Text="41. Are there any horses, livestock or farm animals on the premises?" CssClass="AR_Application"></asp:Label>
                                </td>
                                <td>
                                    <asp:DropDownList ID="dd_ARIng41" runat="server" TabIndex="19">
                                        <asp:ListItem></asp:ListItem>
                                        <asp:ListItem>Yes</asp:ListItem>
                                        <asp:ListItem>No</asp:ListItem>
                                    </asp:DropDownList>
                                </td>
                            </tr>
                            <tr align="left">
                                <td align="left">
                                    <asp:Label ID="Label128" runat="server" Text="42. Does the premises have 5 or more acres?" CssClass="AR_Application"></asp:Label>
                                </td>
                                <td>
                                    <asp:DropDownList ID="dd_ARIng42" runat="server" TabIndex="19">
                                        <asp:ListItem></asp:ListItem>
                                        <asp:ListItem>Yes</asp:ListItem>
                                        <asp:ListItem>No</asp:ListItem>
                                    </asp:DropDownList>
                                </td>
                            </tr>
                            <tr align="left">
                                <td align="left">
                                    <asp:Label ID="Label129" runat="server" Text="43. Does the value of the personal effects exceed $15,000 and is 75% of the value of the mobile home? (Submit with Personal Effects Inventory.)" CssClass="AR_Application"></asp:Label>
                                </td>
                                <td>
                                    <asp:DropDownList ID="dd_ARIng43" runat="server" TabIndex="19">
                                        <asp:ListItem></asp:ListItem>
                                        <asp:ListItem>Yes</asp:ListItem>
                                        <asp:ListItem>No</asp:ListItem>
                                    </asp:DropDownList>
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
                                     <asp:Label ID="Label135" runat="server" Text="Status" CssClass="AR_Application"></asp:Label> &nbsp;
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
