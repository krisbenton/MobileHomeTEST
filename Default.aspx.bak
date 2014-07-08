<%@ Page Title="Home Page" Language="vb" MasterPageFile="IntPage.Master"  AutoEventWireup="true" CodeBehind="Default.aspx.vb" Inherits="MobileHomeRater.Default"  %>



<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolderMenu" runat="server">
<script type="text/javascript">
function redirect(){

    window.location.href = "/Quote/quote.aspx";

}
function redirectFind() {
    
    window.location.href = "/Quote/findQuote.aspx";
    

}
</script>
    <!--Menu Bar-->
                    
                    <table cellpadding="0" cellspacing="0">
                            <tr align="left">
                                <td>
                                 <button style="top: 0px; left: 0px; width:100px; height:30px; border: 1px solid #808080;" onclick="redirect(); return false;" >New Quote</button>  
                                 <button  style="top: 0px; left: -15px; width:100px; height:30px; border: 1px solid #808080;" onclick="redirectFind(); return false;"  >Find Quote</button>  
                                  <asp:Button ID="btnLogout" runat="server" style="top: 0px; left: -15px; width:100px; height:30px; border: 1px solid #808080;" Text="Logout" OnClick="btnLogout_Click" CausesValidation="true"  />
                                </td>
                            </tr>
                    </table>
                    <!--Menu Bar-->
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
</asp:Content>
