Public Class [Default]
    Inherits System.Web.UI.Page

    Public Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        If (mySession.CurrentSub.ID Is Nothing) OrElse (mySession.CurrentSub.ID.Trim.Length = 0) Then
            Response.Redirect("~/Login.aspx", True)
        End If
        If Not Me.IsPostBack Then
            findimport.Attributes.Add("onClick", "redirectFind2(); return false;")
            Dim test As String = mySession.CurrentUser.UWUser.ToString
            If mySession.CurrentUser.UWUser.ToString = "False" Then
                findimport.Visible = False

                findimport.Width = "0"
            End If
            If mySession.CurrentUser.AdminUser.ToString = "True" Then
                findimport.Visible = True


            End If

        End If

    End Sub
    Public Sub btnLogout_Click(ByVal sender As Object, ByVal e As EventArgs)
        mySession.Clear()
        Server.Transfer("~/Login.aspx")

    End Sub
    
End Class