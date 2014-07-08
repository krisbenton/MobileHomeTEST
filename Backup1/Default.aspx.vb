Public Class [Default]
    Inherits System.Web.UI.Page

    Public Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        If (mySession.CurrentSub.ID Is Nothing) OrElse (mySession.CurrentSub.ID.Trim.Length = 0) Then
            Response.Redirect("~/Login.aspx", True)
        End If
        'Check if User or Agent is allowed to use application
      

        If Not Me.IsPostBack Then

            Dim test As String = mySession.CurrentUser.UWUser.ToString
            If mySession.CurrentUser.UWUser.ToString = "False" Then
                findimport.Visible = False
                adminpage.Visible = False
                adminpage.Width = "0"
                findimport.Width = "0"
            Else
                findimport.Visible = True
                findimport.Attributes.Add("onClick", "redirectFind2(); return false;")
                adminpage.Visible = True

            End If
            If mySession.CurrentUser.AdminUser.ToString = "True" Then
                adminpage.Visible = True

            End If

        End If

    End Sub
    Public Sub btnLogout_Click(ByVal sender As Object, ByVal e As EventArgs)
        mySession.Clear()
        Server.Transfer("~/Login.aspx")

    End Sub
    
    Public Sub adminpage_Click(sender As Object, e As System.EventArgs)
        Response.Redirect("~/Admin/Administrator.aspx")

    End Sub
End Class