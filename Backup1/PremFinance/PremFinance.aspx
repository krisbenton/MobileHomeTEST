<%@ Page Language="vb" Title="TCG Mobile Home Rater" AutoEventWireup="false" CodeBehind="PremFinance.aspx.vb" Inherits="MobileHomeRater.PremFinance" MasterPageFile="../IntPage.Master" EnableEventValidation="false"  EnableSessionState="true" EnableViewState="true" %>

<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolderMenu" runat="server">
    <script type="text/javascript">
       

    </script>
    <!--Menu Bar-->
    <table cellpadding="0" cellspacing="0">
        <tr align="left">
            <td>
                <button style="-webkit-appearance: none; top: 0px; left: 0px; width: 100px; height: 30px;
                    border: 1px solid #808080;" onclick="redirect(); return false;">
                    New Quote</button>
                <button style="-webkit-appearance: none; top: 0px; left: -15px; width: 100px; height: 30px;
                    border: 1px solid #808080;" onclick="redirect2(); return false;">
                    Find Quote</button>
               
            </td>
        </tr>
    </table>
    <!--Menu Bar-->
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <ajaxTK:ToolkitScriptManager ID="sc2" runat="server" EnablePartialRendering="true">
    </ajaxTK:ToolkitScriptManager>
  <div>
  <asp:TextBox ID="SampleDisplay" runat="server" TextMode="MultiLine" Width="100%" Height="500px"></asp:TextBox>
  
  
  
  </div>
</asp:Content>
<asp:Content ID="Content3" runat="server" contentplaceholderid="head">
    <style type="text/css">
        .style2
        {
            height: 22px;
        }
    </style>
</asp:Content>

