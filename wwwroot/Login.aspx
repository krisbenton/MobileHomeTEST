<%@ Page Language="vb" AutoEventWireup="false" CodeBehind="Login.aspx.vb" MasterPageFile="Site.Master" title="Mobile Home Rater"  Inherits="MobileHomeRater.WebForm1" %>


<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    &nbsp;
    <asp:Panel ID="Panel1" runat="server" DefaultButton="btnLogin">
      
       
        <table cellpadding="0" cellspacing="2">
            <tr>
                <td colspan="3">
                    <asp:Label ID="Label3" Font-Size="X-Large" runat="server" SkinID="PageTitle" Text="Login Page" />
                </td>
            </tr>
            <tr>
                <td>
                    &nbsp;
                </td>
                <td>
                    &nbsp;
                </td>
                <td>
                    &nbsp;
                </td>
            </tr>
            <tr>
                <td>
                    <br />
                </td>
            </tr>
            <tr>
                <td>
                    <asp:Label ID="Label1" runat="server" SkinID="PageSubTitle" Text="User ID" />
                </td>
                <td>
                    &nbsp;
                </td>
                <td>
                    <asp:TextBox ID="txtUserID" runat="server" Width="100px" />
                </td>
            </tr>
            <tr>
                <td>
                    <asp:Label ID="Label2" runat="server" Text="Password" SkinID="PageSubTitle" />
                </td>
                <td>
                    &nbsp;
                </td>
                <td>
                    <asp:TextBox ID="txtPassword" runat="server" TextMode="Password" Width="100px" />
                </td>
            </tr>
            <tr>
                <td>
                    &nbsp;
                </td>
                <td>
                    &nbsp;
                </td>
                <td>
                    &nbsp;
                </td>
            </tr>
            <tr>
                <td>
                    <div id="Zone1">
                        <asp:Button ID="btnLogin" runat="server" Text="Login" />
                    </div>
                </td>
                <td>
                    &nbsp;
                </td>
                <td>
                    <asp:Label ID="lblLoginStatus" runat="server" ForeColor="Red" />
                </td>
            </tr>
        </table>
    </asp:Panel>
</asp:Content>

