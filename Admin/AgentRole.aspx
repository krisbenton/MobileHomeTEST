﻿<%@ Page Title="" Language="vb" AutoEventWireup="false" MasterPageFile="~/IntPage.Master" CodeBehind="AgentRole.aspx.vb" Inherits="MobileHomeRater.AgentRole" %>
<%@ Register assembly="DevExpress.Web.v13.1, Version=13.1.8.0, Culture=neutral, PublicKeyToken=b88d1754d700e49a" namespace="DevExpress.Web.ASPxRoundPanel" tagprefix="dx" %>
<%@ Register assembly="DevExpress.Web.v13.1, Version=13.1.8.0, Culture=neutral, PublicKeyToken=b88d1754d700e49a" namespace="DevExpress.Web.ASPxPanel" tagprefix="dx" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="contentplaceholder2" runat="server">
</asp:Content>
<asp:Content ID="Content3" ContentPlaceHolderID="ContentPlaceHolderMenu" runat="server">
   
</asp:Content>
<asp:Content ID="Content4" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
 <table cellpadding="0" cellspacing="0">
 <tr align="left">
 <td>
    <dx:ASPxRoundPanel ID="ASPxRoundPanel1" runat="server" Width="200px" HeaderText="State">
    </dx:ASPxRoundPanel>
    </td>
    <td>
     <dx:ASPxRoundPanel ID="ASPxRoundPanel2" runat="server" Width="200px" HeaderText="County">
    </dx:ASPxRoundPanel>
    </td>
    </tr>
    </table>
</asp:Content>
