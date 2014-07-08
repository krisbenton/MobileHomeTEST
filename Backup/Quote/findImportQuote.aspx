<%@ Page Language="vb" AutoEventWireup="false" CodeBehind="findImportQuote.aspx.vb" Inherits="MobileHomeRater.findQuote" MasterPageFile="../IntPage.Master" Title="Find Quote"  EnableEventValidation="true"%>

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
                        <button style="-webkit-appearance: none; top: 0px; left: 0px; width:100px; height:30px; border: 1px solid #808080; " onclick="redirect(event); return false;" >New Quote</button>  
                        <button  style="-webkit-appearance: none; top: 0px; left: -15px; width:100px; height:30px; border: 1px solid #808080;" onclick="redirect2(); return false;">Find Quote</button>  
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
            <table width="25%" cellpadding="0" cellspacing="0" style="table-layout:fixed;" bgcolor="white" >
                <tbody>                    
                    <tr>
                        <td align="left">
                        </td>
                         <td align="left">
                            <asp:Label ID="Label6" runat="server" Text="Quote ID:"  CssClass="label"/>
                        </td>
                        <td align="left">
                                <asp:Textbox ID="txtQuoteID" runat="server" ToolTip="Sub Number" Width="100px" TabIndex="0" />
                        </td>
                    </tr>
                    <tr>
                    <td align="left">
                        </td>
                        <td colspan=2>
                        &nbsp;
                        </td>    
                    </tr>
                    <tr>
                    <td align="left">
                        </td>
                    <td colspan=2>
                    <center>OR</center>
                    </td>
    
                    </tr>
                     <tr>
                     <td align="left">
                        </td>
                        <td colspan=2>
                        &nbsp;
                        </td>    
                    </tr>
                    <tr>
                    <td align="left">
                        </td>
                         <td align="left">
                            <asp:Label ID="lblb1" runat="server" Text="Last Name"  CssClass="label"/>
                        </td>
                        <td align="left">
                                <asp:Textbox ID="txtLastName" runat="server" ToolTip="Sub Number" Width="100px" TabIndex="0" />
                        </td>
                    </tr>
                    <tr>
                    <td align="left">
                        </td>
                        <td colspan=2>
                        &nbsp;
                        </td>    
                    </tr>
                    <tr>

                        <td colspan="3">
                             <asp:Button ID="searchbtn" runat="server" Text="Search" OnClick="Search_Click" />
                        </td>
        
                    </tr>
       

                </tbody>
            </table>
        </td>   
    </tr>
    <tr>
       <td align="left">
              <telerik:RadGrid ID="RadGrid1" runat="server" AllowFilteringByColumn="True" AllowPaging="True"  AllowSorting="True" AutoGenerateColumns="False" GridLines="None" >
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
                                   <telerik:GridBoundColumn AutoPostBackOnFilter="true" 
                                        SortExpression="quoteID" DataField="quoteID" DataType="System.Int32" 
                                       FilterControlWidth="40px" HeaderText="Quote #" ShowFilterIcon="False" />
                                   <telerik:GridBoundColumn AutoPostBackOnFilter="true" 
                                        DataField="applicantName" HeaderText="Name" 
                                       SortExpression="applicantName" UniqueName="applicantName" />
                                        <telerik:GridBoundColumn AutoPostBackOnFilter="true" 
                                        DataField="effDate" HeaderText="Date" 
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
</asp:Panel>
</asp:Content>