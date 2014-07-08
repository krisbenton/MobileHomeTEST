<%@ Page Language="vb" Title="TCG Mobile Home Rater" AutoEventWireup="false" CodeBehind="LloydsApplication.aspx.vb" Inherits="MobileHomeRater.quote" MasterPageFile="../IntPage.Master" %>

<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolderMenu" runat="server">
   <!--Menu Bar-->
                    
                    <table cellpadding="0" cellspacing="0">
                            <tr align="left">
                                <td>
                                 <button style="-webkit-appearance: none; top: 0px; left: 0px; width:100px; height:30px; border: 1px solid #808080; " onclick="redirect(); return false;" >New Quote</button>  
                                 <button  style="-webkit-appearance: none; top: 0px; left: -15px; width:100px; height:30px; border: 1px solid #808080;" onclick="redirect2(); return false;">Find Quote</button>  
                                 
                                </td>
                            </tr>
                    </table>
                    <!--Menu Bar-->
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server" >

</asp:Content>