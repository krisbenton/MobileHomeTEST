<%@ Page Language="vb" AutoEventWireup="false" CodeBehind="findImportQuote.aspx.vb"
    Inherits="MobileHomeRater.findImportQuote" MasterPageFile="../IntPage.Master"
    Title="Find Quote" EnableEventValidation="true" %>

<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolderMenu" runat="server">
    <script type="text/javascript">
        function redirect(e) {

            if (e.keycode == 13) {
                search(e);
            } else {
                window.location.href = "/Quote/quote.aspx";
            }
        }
        function redirect2(e) {
            if (e.keycode == 13) {
                search(e);
            } else {
                window.location.href = "/Quote/findQuote.aspx";
            }


        }
        function redirect3(e) {
            if (e.keycode == 13) {
                search(e);
            } else {
                window.location.href = "/Quote/findimportQuote.aspx";
            }


        }
        function search(e) {
            if (e.keycode == 13) {
                document.getElementById('<%=searchbtn.ClientID%>').click();
            }

        }
    </script>
    <!--Menu Bar-->
    <table cellpadding="0" cellspacing="0">
        <tr align="left">
            <td>
                <button style="-webkit-appearance: none; top: 0px; left: 0px; width: 100px; height: 30px;
                    border: 1px solid #808080;" onclick="redirect(event); return false;">
                    New Quote</button>
                <button style="-webkit-appearance: none; top: 0px; left: -15px; width: 100px; height: 30px;
                    border: 1px solid #808080;" onclick="redirect2(0); return false;">
                    Find Quote</button>
                <asp:button ID="findimport" runat="server" CausesValidation="false" style="-webkit-appearance: none; top: 0px; left: -15px; width: 150px; height: 30px;
                    border: 1px solid #808080;"  Text="Find Imported Quote" />
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
    <asp:Panel ID="pnlDefaultButton" runat="server" DefaultButton="searchbtn">
        <table width="100%" cellpadding="0" cellspacing="0" style="table-layout: fixed;"
            bgcolor="white">
            <tbody>
                <tr align="left">
                    <td>
                        <asp:Label ID="Label1" runat="server" Text="Imported Quotes" CssClass="heading"></asp:Label>
                    </td>
                </tr>
                <tr>
                    <td>
                        &nbsp;
                    </td>
                </tr>
                <tr>
                    <td>
                        &nbsp;
                    </td>
                </tr>
                <tr>
                    <td>
                        <table width="25%" cellpadding="0" cellspacing="0" style="table-layout: fixed;" bgcolor="white">
                            <tbody>
                                <tr>
                                                                
                                    <td align="left">
                                        <asp:Label ID="Label6" runat="server" Text="Quote ID:" CssClass="label" />
                                    </td>
                                    <td align="left"  colspan="2">
                                        <asp:TextBox ID="txtQuoteID" runat="server" ToolTip="Quote Number" Width="100px"
                                            TabIndex="0" />
                                    </td>
                                    <td align="left">
                                    </td>
                                     </tr>
                <tr>
                                    <td align="left">
                                        <asp:Label ID="Label2" runat="server" Text="Policy #:" CssClass="label" />
                                    </td>
                                    <td align="left" colspan="2">
                                        <asp:TextBox ID="txtPolicyID" runat="server" ToolTip="Policy Number" Width="100px"
                                            TabIndex="0" />
                                    </td>                                     
                                   
                                    <td align="left">
                                     &nbsp;
                                    </td>
                                     </tr>
                <tr>
                                    <td align="left">
                                        <asp:Label ID="lblb1" runat="server" Text="Last Name" CssClass="label" />
                                    </td>
                                    <td align="left"  colspan="2">
                                        <asp:TextBox ID="txtLastName" runat="server" ToolTip="Sub Number" Width="100px" TabIndex="0" />
                                    </td>
                                </tr>
                                <tr>
                                    <td colspan="2">
                                        <asp:Button ID="searchbtn" runat="server" Text="Search" OnClick="Search_Click" />
                                        </td><td>
                                        <asp:Button ID="clearbtn" runat="server" Text="Clear" OnClick="Clear_Click" />

                                    </td>
                                </tr>
                            </tbody>
                        </table>
                    </td>
                </tr>
            </tbody>
        </table>
    </asp:Panel>
    <table width="100%" cellpadding="0" cellspacing="0" style="table-layout: fixed;"
        bgcolor="white">
        <tbody>
            <tr>
                <td align="left" colspan="3">
                    <telerik:RadGrid ID="RadGrid1" runat="server" AllowPaging="True" AllowFilteringByColumn="false"
                        AllowSorting="True" AutoGenerateColumns="False" GridLines="None" Width="100%">
                        <GroupingSettings CaseSensitive="False" />
                        <MasterTableView CommandItemDisplay="None" DataKeyNames="quoteID" PageSize="12">
                            <RowIndicatorColumn Visible="False">
                                <HeaderStyle Width="20px" />
                            </RowIndicatorColumn>
                            <ExpandCollapseColumn Resizable="False" Visible="False">
                                <HeaderStyle Width="20px" />
                            </ExpandCollapseColumn>
                            <Columns>
                                <telerik:GridButtonColumn ButtonType="ImageButton" CommandName="Select" ImageUrl="~/Images/Go.png"
                                    Text="Select" UniqueName="btnSelect" />
                                <telerik:GridBoundColumn AutoPostBackOnFilter="true" CurrentFilterFunction="EqualTo"
                                    DataField="quoteID" DataType="System.Int32" FilterControlWidth="40px" HeaderText="Quote #"
                                    ShowFilterIcon="False" SortExpression="quoteID" UniqueName="quoteID" />
                                <telerik:GridBoundColumn AutoPostBackOnFilter="true" SortExpression="policyID" DataField="policyID"
                                    DataType="System.Int32" CurrentFilterFunction="EqualTo" FilterControlWidth="80px"
                                    HeaderText="Policy #" ShowFilterIcon="True" />
                                <telerik:GridBoundColumn AutoPostBackOnFilter="true" DataField="applicantName" HeaderText="Name"
                                    SortExpression="applicantName" UniqueName="applicantName" />
                                <telerik:GridBoundColumn AutoPostBackOnFilter="true" DataField="effDate" HeaderText="Date"
                                    SortExpression="effDate" UniqueName="effDate" />
                            </Columns>
                            <PagerStyle Mode="NextPrevNumericAndAdvanced" Position="TopAndBottom" />
                        </MasterTableView>
                    </telerik:RadGrid>
                </td>
                <td>
                    &nbsp;
                </td>
            </tr>
        </tbody>
    </table>
</asp:Content>
