﻿<%@ Page Language="vb" AutoEventWireup="false" CodeBehind="findQuote.aspx.vb" Inherits="MobileHomeRater.findQuote" MasterPageFile="../IntPage.Master" Title="Find Quote"  EnableEventValidation="true"%>

<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolderMenu" runat="server">
    <script type="text/javascript">
    function redirect(e) {
        
        if(e.keycode == 13) {
            search(e);
        } else {
            window.location.href = "/Quote/quote.aspx";
        }
    }
    function redirect2(e) {
        if (e.keycode == 13) 
            {
            search(e);
        } else{
             window.location.href = "/Quote/findQuote.aspx";
        }


     }
     function redirect3(e) {
         if (e.keycode == 13) {
             search(e);
         } else {
             window.location.href = "/Quote/findImportQuote.aspx";
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
                     <%--  <button  style="top: 0px; left: 0px; width:100px; height:30px; border: 1px solid #808080;" onclick="redirect(0); return false;" >New Quote</button>  --%>
                          <asp:Button ID="btnNewquote" runat="server" style="top: 0px; left: -15px; width:100px; height:30px; border: 1px solid #808080;" Text="New Quote" OnClick="btnNewquote_Click" CausesValidation="true"  />
                        <button  style="-webkit-appearance: none; top: 0px; left: -15px; width:100px; height:30px; border: 1px solid #808080;" onclick="redirect2(0); return false;">Find Quote</button>  
                        <asp:button ID="findimport" runat="server" CausesValidation="false"  style="-webkit-appearance: none; top: 0px; left: -15px; width:150px; height:30px; border: 1px solid #808080;" text="Find Imported Quote" />  
                        <asp:Button ID="btnLogout" runat="server" style="top: 0px; left: -15px; width:100px; height:30px; border: 1px solid #808080;" Text="Logout" OnClick="btnLogout_Click" CausesValidation="true"  />
                        
                    </td>
                </tr>
        </table>
        <!--Menu Bar-->
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server" >
<ajaxTK:ToolkitScriptManager id="sc2" runat="server" EnablePartialRendering="true"></ajaxTK:ToolkitScriptManager>
<asp:Panel id="pnlDefaultButton" runat="server" DefaultButton="searchbtn">
<table width="100%" cellpadding="0" cellspacing="0" style="table-layout:fixed;" bgcolor="white" >
<tbody>
<tr align="left">
<td>
<asp:Label ID="Label1" runat="server" Text="Find Quotes" CssClass="heading"></asp:Label>
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
            <table width="80%" cellpadding="0" cellspacing="0" style="table-layout:fixed;" bgcolor="white" >
                <tbody>                    
                    <tr>              
                        <td align="left">
                            <asp:Label ID="Label6" runat="server" CssClass="label" Text="Quote ID:" />
                        </td>
                        <td align="left" colspan="2">
                            <asp:TextBox ID="txtQuoteID" runat="server" TabIndex="0" ToolTip="Quote Number" 
                                Width="100px" />
                        </td>
                                </tr>
                                <tr>
                                    <td align="left">
                                        <asp:Label ID="lblb1" runat="server" CssClass="label" Text="Last Name" />
                                        </td><td align="left" colspan="2">
                                        <asp:TextBox ID="txtLastName" runat="server" TabIndex="0" ToolTip="Sub Number" 
                                            Width="100px" />

                                    </td>
                                </tr>
                                <tr>
                                    <td align="left">
                                        <asp:Label ID="Label2" runat="server" CssClass="label" Text="Type" />
                                        </td><td align="left" colspan="2">
                                         <asp:DropDownList ID="typedd" runat="server">
                                                <asp:ListItem></asp:ListItem>
                                                <asp:ListItem>Quote</asp:ListItem>
                                                <asp:ListItem>Application</asp:ListItem>
                                                
                                            </asp:DropDownList>

                                    </td>
                                </tr>
                                 <tr>
                                    <td align="left">
                                        <asp:Label ID="Label9" runat="server" CssClass="label" Text="Progam" />
                                        </td><td align="left" colspan="2">
                                         <asp:DropDownList ID="programdd" runat="server">
                                                <asp:ListItem></asp:ListItem>
                                                <asp:ListItem>American Reliable Package</asp:ListItem>
                                                <asp:ListItem>American Reliable Standard</asp:ListItem>
                                                 <asp:ListItem>American Reliable Rental</asp:ListItem>
                                                  <asp:ListItem>Lloyds Package</asp:ListItem>
                                                <asp:ListItem>Lloyds Standard</asp:ListItem>
                                                 <asp:ListItem>Lloyds Rental</asp:ListItem>
                                                 <asp:ListItem>Special H08</asp:ListItem>
                                                 <asp:ListItem>Aegis Standard</asp:ListItem>
                                                 <asp:ListItem>Aegis Rental</asp:ListItem>


                                            </asp:DropDownList>

                                    </td>
                                </tr>
                                <tr>
                                    <td align="left">
                                        <asp:Label ID="Label3" runat="server" CssClass="label" Text="Status" />
                                        </td><td align="left" colspan="2">
                                         <asp:DropDownList ID="statusdd" runat="server">
                                                <asp:ListItem></asp:ListItem>
                                                <asp:ListItem>Eligible</asp:ListItem>
                                                <asp:ListItem>Ineligible</asp:ListItem>
                                                 <asp:ListItem>Submit to UW</asp:ListItem>
                                            </asp:DropDownList>

                                    </td>
                                </tr>
                                <tr>
                                    <td align="left">
                                        <asp:Label ID="Label4" runat="server" CssClass="label" Text="Risk State" />
                                        </td><td align="left" colspan="2">
                                        <asp:TextBox ID="txtstate" runat="server" TabIndex="0" ToolTip="Risk State" 
                                            Width="100px" />

                                    </td>
                                </tr>
                                <tr>
                                    <td align="left">
                                        <asp:Label ID="Label5" runat="server" CssClass="label" Text="Agent ID" />
                                        </td><td align="left" colspan="2">
                                        <asp:TextBox ID="txtagentid" runat="server" TabIndex="0" ToolTip="Agent ID" 
                                            Width="100px" />

                                    </td>
                                </tr>
                                <tr>
                                    <td align="left">
                                        <asp:Label ID="Label7" runat="server" CssClass="label" Text="Effective Date" />
                                        </td><td align="left" colspan="2">
                                        <asp:TextBox ID="txtdate" runat="server" TabIndex="0" ToolTip="Create Date" 
                                            Width="100px" />

                                    </td>
                                </tr>
                                <tr>
                                    <td align="left">
                                        <asp:Label ID="Label8" runat="server" CssClass="label" Text="User" />
                                        </td><td align="left" colspan="2">
                                        <asp:TextBox ID="txtuser" runat="server" TabIndex="0" ToolTip="User" 
                                            Width="100px" Enabled="true" />

                                    </td>
                                </tr>
                </tbody>
            </table>
        </td>   
    </tr>
    <tr>
       <td colspan=1>
              <asp:Button ID="searchbtn" runat="server" OnClick="Search_Click" 
                  Text="Search" />
        </td>
        <td align="left">
            <asp:Button ID="clearbtn" runat="server" OnClick="Clear_Click" Text="Clear" />
        </td>
    </tr>
</tbody>
</table>
    </td>
    </tr>
    <tr>
        <td align="left" colspan="3">
            <telerik:RadGrid ID="RadGrid1" runat="server" AllowFilteringByColumn="False" 
                AllowPaging="True" AllowSorting="True" AutoGenerateColumns="False" 
                GridLines="None" Width="100%">
                <GroupingSettings CaseSensitive="False" />
                <MasterTableView CommandItemDisplay="None" DataKeyNames="quoteID" PageSize="12">
                    <RowIndicatorColumn Visible="False">
                        <HeaderStyle Width="20px" />
                    </RowIndicatorColumn>
                    <ExpandCollapseColumn Resizable="False" Visible="False">
                        <HeaderStyle Width="20px" />
                    </ExpandCollapseColumn>
                    <Columns>
                        <telerik:GridButtonColumn ButtonType="ImageButton" CommandName="Select" 
                            ImageUrl="~/Images/Go.png" Text="Select" UniqueName="btnSelect" />
                        <telerik:GridBoundColumn AutoPostBackOnFilter="true" DataField="quoteID" 
                            DataType="System.Int32" FilterControlWidth="40px" HeaderText="Quote #" 
                            ShowFilterIcon="False" SortExpression="quoteID" />
                             <telerik:GridBoundColumn AutoPostBackOnFilter="true" DataField="applicantName" 
                            HeaderText="Name" SortExpression="applicantName" UniqueName="applicantName" />
                        <telerik:GridBoundColumn AutoPostBackOnFilter="true" DataField="findtype" 
                            HeaderText="Type" SortExpression="findtype" UniqueName="findtype" />
                             <telerik:GridBoundColumn AutoPostBackOnFilter="true" DataField="findprogram" 
                            HeaderText="Program" SortExpression="findprogram" UniqueName="findprogram" />
                             <telerik:GridBoundColumn AutoPostBackOnFilter="true" DataField="findstatus" 
                            HeaderText="Status" SortExpression="findstatus" UniqueName="findstatus" />
                             <telerik:GridBoundColumn AutoPostBackOnFilter="true" DataField="riskstate" 
                            HeaderText="Risk State" SortExpression="riskstate" UniqueName="riskstate" />
                             <telerik:GridBoundColumn AutoPostBackOnFilter="true" DataField="findagentid" 
                            HeaderText="Agency" SortExpression="findagentid" UniqueName="findagentid" />
                            
                        <telerik:GridBoundColumn AutoPostBackOnFilter="true" DataField="effDate" 
                            HeaderText="Effective Date" SortExpression="effDate" UniqueName="effDate" />
                            <telerik:GridBoundColumn AutoPostBackOnFilter="true" DataField="Login" 
                            HeaderText="User" SortExpression="Login" UniqueName="Login" />
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
</asp:Panel>
</asp:Content>