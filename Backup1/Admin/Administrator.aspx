<%@ Page Title="" Language="vb" AutoEventWireup="false" MasterPageFile="~/IntPage.Master" CodeBehind="Administrator.aspx.vb" Inherits="MobileHomeRater.Administrator" %>

<%@ Register Assembly="DevExpress.Web.v13.1, Version=13.1.8.0, Culture=neutral, PublicKeyToken=b88d1754d700e49a"
    Namespace="DevExpress.Web.ASPxTabControl" TagPrefix="dx" %>
<%@ Register assembly="DevExpress.Web.v13.1, Version=13.1.8.0, Culture=neutral, PublicKeyToken=b88d1754d700e49a" namespace="DevExpress.Web.ASPxClasses" tagprefix="dx" %>
<%@ Register assembly="DevExpress.Web.v13.1, Version=13.1.8.0, Culture=neutral, PublicKeyToken=b88d1754d700e49a" namespace="DevExpress.Web.ASPxGridView" tagprefix="dx" %>
<%@ Register assembly="DevExpress.Web.v13.1, Version=13.1.8.0, Culture=neutral, PublicKeyToken=b88d1754d700e49a" namespace="DevExpress.Web.ASPxEditors" tagprefix="dx" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="contentplaceholder2" runat="server">
</asp:Content>
<asp:Content ID="Content3" ContentPlaceHolderID="ContentPlaceHolderMenu" runat="server">
 <table cellpadding="0" cellspacing="0">
                        <tr align="left">
                            <td>
                                <button style="top: 0px; left: 0px; width:100px; height:30px; border: 1px solid #808080;" onclick="redirect(); return false;" >
                                    New Quote
                                </button>
                                <button  style="top: 0px; left: -15px; width:100px; height:30px; border: 1px solid #808080;" onclick="redirectFind(); return false;"  >
                                    Find Quote
                                </button>
                                <asp:button ID="findimport" runat="server" style="top: 0px; left: -15px; width:150px; height:30px; border: 1px solid #808080;" text="Find Imported Quote" />
                                <asp:Button ID="btnLogout" runat="server" style="top: 0px; left: -15px; width:100px; height:30px; border: 1px solid #808080;" Text="Logout" OnClick="btnLogout_Click" CausesValidation="true"  />
                            </td>
                        </tr>
    </table>
</asp:Content>
<asp:Content ID="Content4" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
   
    <dx:ASPxPageControl ID="Admin" runat="server" ActiveTabIndex="0" 
        EnableHierarchyRecreation="True">
      <TabPages>
      <dx:TabPage Text="Users">
     
       <ContentCollection>

        <dx:ContentControl id="ContentControl1" runat="server" SupportsDisabledAttribute="True">
            <dx:ASPxGridView ID="ASPxGridView1" runat="server">
            </dx:ASPxGridView>
         </dx:ContentControl>
       </ContentCollection>

     
      </dx:TabPage>
       <dx:TabPage Text="County">
      
      
       
      
      
      
      </dx:TabPage>
       <dx:TabPage Text="Agent">
      
      
       
      
      
      </dx:TabPage>
    

      
      </TabPages>

    </dx:ASPxPageControl>
</asp:Content>
