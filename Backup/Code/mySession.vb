Imports Microsoft.VisualBasic

Public Class mySession

   Public Const CookieName As String = "c2bFTPInsLogin"

   Public Enum enumSessionVariableNames
      CallingUrl
   End Enum

   Shared Function myCookie() As HttpCookie
      Static RetVal As HttpCookie
      If RetVal Is Nothing Then
         RetVal = HttpContext.Current.Request.Cookies.Get(CookieName)
      End If

      Return RetVal
   End Function

   Shared Sub AddVariable(ByVal Variable As enumSessionVariableNames, ByVal Value As Object)
      HttpContext.Current.Session(Variable.ToString) = Value
   End Sub

   Shared Sub AddVariable(ByVal VariableName As String, ByVal Value As Object)
      HttpContext.Current.Session(VariableName) = Value
   End Sub

   Shared Function GetVariable(ByVal Variable As enumSessionVariableNames) As Object
      Dim value As Object = HttpContext.Current.Session(Variable.ToString)
      If value Is Nothing Then
         Return String.Empty
      Else
         Return value
      End If
   End Function

   Shared Function GetVariable(ByVal VariableName As String) As Object
      Dim value As Object = HttpContext.Current.Session(VariableName)
      If value Is Nothing Then
         Return String.Empty
      Else
         Return value
      End If
   End Function

   Shared Sub Clear()
      mySession.CurrentUser = Nothing
      mySession.CurrentSub = Nothing

      Dim myCookie As HttpCookie = mySession.myCookie

      If myCookie IsNot Nothing Then
         'overwrite cookie with past expiration date
         Dim newCookie As HttpCookie = New HttpCookie(CookieName)
         newCookie.Expires = Date.Now.AddDays(-1)
         HttpContext.Current.Response.Cookies.Add(newCookie)
      End If

      HttpContext.Current.Session.Clear()
      HttpContext.Current.Response.Flush()

   End Sub

    Shared Property CurrentUser() As Common.UserData
        Get
            Dim value As Common.UserData = CType(HttpContext.Current.Session("CurrentUser"), Common.UserData)
            Return value
        End Get
        Set(ByVal value As Common.UserData)
            HttpContext.Current.Session("CurrentUser") = value
        End Set
    End Property

    Shared Property CurrentSub() As Common.UserData
        Get
            Dim value As Common.UserData = CType(HttpContext.Current.Session("CurrentSub"), Common.UserData)
            Return value
        End Get
        Set(ByVal value As Common.UserData)
            HttpContext.Current.Session("CurrentSub") = value
        End Set
    End Property

   Shared Property ProgramName() As String
      Get
         Dim value As String = HttpContext.Current.Session("ProgramName")
         If value Is Nothing Then
            Return String.Empty
         Else
            Return value
         End If
      End Get
      Set(ByVal value As String)
         HttpContext.Current.Session("ProgramName") = value
      End Set
   End Property

   Shared Property CoverageType() As String
      Get
         Dim value As String = HttpContext.Current.Session("CoverageType")
         If value Is Nothing Then
            Return String.Empty
         Else
            Return value
         End If
      End Get
      Set(ByVal value As String)
         HttpContext.Current.Session("CoverageType") = value
      End Set
   End Property

   Shared Property QueryDate() As Date
      Get
         Dim value As String = HttpContext.Current.Session("QueryDate")
         If (value Is Nothing) OrElse (Not IsDate(value)) Then
            Return Date.Today
         Else
            Return CDate(value)
         End If
      End Get
      Set(ByVal value As Date)
         HttpContext.Current.Session("QueryDate") = value
      End Set
   End Property

   Shared Property QuoteID() As Integer
      Get
         Dim value As String = HttpContext.Current.Session("QuoteID")
         If (value Is Nothing) OrElse (Not IsNumeric(value)) Then
            Return 0
         Else
            Return CInt(value)
         End If
      End Get
      Set(ByVal value As Integer)
         HttpContext.Current.Session("QuoteID") = value
      End Set
   End Property

   Shared Property UploadFileName() As String
      Get
         Dim value As String = HttpContext.Current.Session("UploadFileName")
         If value Is Nothing Then
            Return String.Empty
         Else
            Return value
         End If
      End Get
      Set(ByVal value As String)
         HttpContext.Current.Session("UploadFileName") = value
      End Set
   End Property

    'Shared Property RequiredControlBackColor() As Drawing.Color
    '   Get
    '      Dim value As String = HttpContext.Current.Session("RequiredControlBackColor")
    '      If value Is Nothing Then
    '         Return myConfig.GetColorSetting(myConfig.enumColorConfigSettings.RequiredControlBackColor)
    '      Else
    '         Try
    '            Return Drawing.Color.FromName(value)
    '         Catch ex As Exception
    '            Return Drawing.Color.White
    '         End Try
    '      End If
    '   End Get
    '   Set(ByVal value As Drawing.Color)
    '      HttpContext.Current.Session("RequiredControlBackColor") = value.ToString
    '   End Set
    'End Property
End Class
