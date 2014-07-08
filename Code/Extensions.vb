Imports System.Runtime.CompilerServices
Imports System.Xml
Module Extensions

#Region "String extensions"

    <Extension()> _
    Public Function PadRightTruncate(ByRef x As String, ByVal totalWidth As Integer) As String
        Return x.PadRightTruncate(totalWidth:=totalWidth, paddingChar:=" ")
    End Function

    <Extension()> _
    Public Function PadRightTruncate(ByRef x As String, ByVal totalWidth As Integer, ByVal paddingChar As Char) As String
        If x.Length = totalWidth Then
            Return x
        End If

        If x.Length > totalWidth Then
            Return x.Left(totalWidth)
        End If

        Return x.PadRight(totalWidth:=totalWidth, paddingChar:=paddingChar)
    End Function

    <Extension()> _
    Public Function PadLeftTruncate(ByRef x As String, ByVal totalWidth As Integer) As String
        Return x.PadLeftTruncate(totalWidth:=totalWidth, paddingChar:=" ")
    End Function

    <Extension()> _
    Public Function PadLeftTruncate(ByRef x As String, ByVal totalWidth As Integer, ByVal paddingChar As Char) As String
        If x.Length = totalWidth Then
            Return x
        End If

        If x.Length > totalWidth Then
            Return x.Left(totalWidth)
        End If

        Return x.PadLeft(totalWidth:=totalWidth, paddingChar:=paddingChar)
    End Function

    <Extension()> _
    Public Function IsValidEmail(ByVal x As String) As Boolean
        Return New RegularExpressions.Regex("\w+([-+.']\w+)*@\w+([-.]\w+)*\.\w+([-.]\w+)*").Match(x).Success
    End Function

    <Extension()> _
    Public Sub SetValues(ByRef x As String, ByVal Values As List(Of NameValuePair))
        For Each item In Values
            x.AddXMLElementWithInnerText(item.name, item.value)
        Next
    End Sub

  
    ''' <summary>
    ''' Populates the myControl control parameter with the corresponding element value from the XmlDocument's nodes collection
    ''' </summary>
    ''' <param name="x">XmlDocument object from which to retrieve values</param>
    ''' <param name="myControl">Control to populate</param>
    ''' <remarks>This does not update the control if there's no matching data element in the XmlDocument object</remarks>
    <Extension()> _
    Public Sub PopulateControl(ByVal x As String, ByRef myControl As Control)
        Dim XmlDoc As New XmlDocument

        Try
            XmlDoc.LoadXml(x)
        Catch ex As Exception
            Stop

            Exit Sub
        End Try


    End Sub

    ''' <summary>
    ''' Returns True if the string is equal to one of the values in the Values string parameter array
    ''' </summary>
    ''' <param name="x"></param>
    ''' <param name="Values"></param>
    ''' <returns></returns>
    ''' <remarks></remarks>
    <Extension()> _
    Public Function IsOneOf(ByVal x As String, ByVal ParamArray Values() As String) As Boolean
        For Each value As String In Values
            If x.Equals(value) Then
                Return True
            End If
        Next

        Return False
    End Function

    ''' <summary>
    ''' Returns this instance of System.String.  If this instance is Nothing then return parameter ValueIfNothing
    ''' </summary>
    ''' <param name="x">String value to return</param>
    ''' <param name="ValueIfNothing">Value to return if string is Nothing</param>
    ''' <returns></returns>
    ''' <remarks></remarks>
    <Extension()> _
    Public Function ToString(ByVal x As String, ByVal ValueIfNothing As String) As String
        If x Is Nothing Then
            x = ValueIfNothing
        End If

        Return x.ToString
    End Function

    ''' <summary>
    ''' Returns the string as a decimal value.  Returns DefaultReturnValue parameter value if string is not numeric
    ''' </summary>
    ''' <param name="x"></param>
    ''' <param name="DefaultReturnValue"></param>
    ''' <returns></returns>
    ''' <remarks></remarks>
    <Extension()> _
    Public Function ToDate(ByVal x As String, ByVal DefaultReturnValue As Date) As Date
        Try
            If IsDate(x) Then
                Return CDate(x)
            Else
                Return DefaultReturnValue
            End If
        Catch ex As Exception
            Return DefaultReturnValue
        End Try
    End Function

    ''' <summary>
    ''' Returns the string as a decimal value.  Returns 0 if string is not numeric
    ''' </summary>
    ''' <param name="x"></param>
    ''' <returns></returns>
    ''' <remarks></remarks>
    <Extension()> _
    Public Function ToDecimal(ByVal x As String) As Decimal
        Return x.ToDecimal(0)
    End Function

    ''' <summary>
    ''' Returns the string as a decimal value.  Returns DefaultReturnValue parameter value if string is not numeric
    ''' </summary>
    ''' <param name="x"></param>
    ''' <param name="DefaultReturnValue"></param>
    ''' <returns></returns>
    ''' <remarks></remarks>
    <Extension()> _
    Public Function ToDecimal(ByVal x As String, ByVal DefaultReturnValue As Decimal) As Decimal
        Try
            'remove trailing "%"
            If x.EndsWith("%") Then
                x = x.TrimEnd("%")
                x = x.ToDecimal / 100
            End If

            Return CDec(x)

        Catch ex As Exception
            Return DefaultReturnValue
        End Try
    End Function

    ''' <summary>
    ''' Returns the string as a boolean value.  Returns False if string is not boolean
    ''' </summary>
    ''' <param name="x"></param>
    ''' <returns></returns>
    ''' <remarks></remarks>
    <Extension()> _
    Public Function ToBoolean(ByVal x As String) As Boolean
        Try
            Return CBool(x)
        Catch ex As Exception
            If x Is Nothing Then
                Return False
            Else
                Select Case x.ToLower
                    Case "on", "yes"
                        Return True
                    Case Else
                        Return False
                End Select
            End If
        End Try
    End Function

    ''' <summary>
    ''' Converts a string like "15%" into its decimal equivalent .15
    ''' </summary>
    ''' <param name="x"></param>
    ''' <returns></returns>
    ''' <remarks></remarks>
    <Extension()> _
    Public Function ToPercent(ByVal x As String) As Decimal
        Try
            'remove leading and trailing spaces
            x = x.Trim
            'remove trailing % character
            x = x.TrimEnd("%")

            If IsNumeric(x) Then
                Return CDec(x) / 100
            Else
                Return 0
            End If
        Catch ex As Exception
            Return 0
        End Try
    End Function

    ''' <summary>
    ''' Returns the left-most Length characters of the string instance
    ''' </summary>
    ''' <param name="x"></param>
    ''' <param name="Length"></param>
    ''' <returns></returns>
    ''' <remarks></remarks>
    <Extension()> _
    Public Function Left(ByVal x As String, ByVal Length As Integer) As String
        If x Is Nothing Then Return String.Empty

        If x.Length <= Length Then
            Return x
        Else
            Return x.Substring(0, Length)
        End If
    End Function

    ''' <summary>
    ''' Returns the number of times the StringToCount parameter is found in this string
    ''' </summary>
    ''' <param name="x"></param>
    ''' <param name="StringToCount"></param>
    ''' <returns></returns>
    ''' <remarks></remarks>
    <Extension()> _
    Public Function CountInstancesOf(ByVal x As String, ByVal StringToCount As String) As Integer
        If x Is Nothing Then Return 0

        If (x.Length = 0) Or ((StringToCount Is Nothing) OrElse (StringToCount.Length = 0)) Then
            Return 0
        End If
        If Not x.Contains(StringToCount) Then
            Return 0
        End If

        Dim intLoop As Integer = 1
        Dim RetVal As Integer

        Do Until intLoop > x.Length
            If x.IndexOf(StringToCount, intLoop) = -1 Then
                intLoop = x.Length + 1
            Else
                RetVal += 1
                intLoop = x.IndexOf(StringToCount, intLoop) + StringToCount.Length
            End If
        Loop

        Return RetVal
    End Function

    ''' <summary>
    ''' Retrieves element/attribute value for DataName from the Xml string
    ''' </summary>
    ''' <param name="x"></param>
    ''' <param name="DataName"></param>
    ''' <returns></returns>
    ''' <remarks>If DataName contains a . then the portion of the name before the . is the Node name
    ''' and the portion after the . is the attribute name of the Node whose value is to be returned</remarks>
    <Extension()> _
    Public Function GetXMLDataValue(ByRef x As String, ByVal DataName As String) As String
        Dim myXmlDoc As New XmlDocument

        Try
            myXmlDoc.LoadXml(x)
            Return myXmlDoc.GetDataValue(DataName)
        Catch ex As Exception
            Return String.Empty
        End Try
    End Function

    <Extension()> _
    Public Function GetXMLElementAttributeValue(ByRef x As String, ByVal ElementName As String, ByVal AttributeName As String) As String
        Dim myXmlDoc As New XmlDocument

        Try
            myXmlDoc.LoadXml(x)
            Return myXmlDoc.GetElementAttributeValue(ElementName, AttributeName)
        Catch ex As Exception
            Return String.Empty
        End Try
    End Function

    <Extension()> _
    Public Function GetXMLElementValue(ByRef x As String, ByVal ElementName As String) As String
        Dim myXmlDoc As New XmlDocument

        Try
            myXmlDoc.LoadXml(x)
            Return myXmlDoc.GetElementValue(ElementName)
        Catch ex As Exception
            Return String.Empty
        End Try
    End Function

    <Extension()> _
    Public Function GetXMLElementValue(ByRef x As String, ByVal ElementNameList As List(Of String)) As String
        If x Is Nothing Then
            Return Nothing
        End If

        Dim myXmlDoc As New XmlDocument

        Try
            myXmlDoc.LoadXml(x)
            Return myXmlDoc.GetElementValue(ElementNameList)
        Catch ex As Exception
            Return String.Empty
        End Try
    End Function

    <Extension()> _
    Public Function GetTaxNodeValue(ByRef x As String, ByVal Name As String) As String
        Dim myXmlDoc As New XmlDocument

        Try
            myXmlDoc.LoadXml(x)
            '
            'first try /Taxes/Tax
            For Each myTaxNode As XmlNode In myXmlDoc.SelectNodes("/Taxes/Tax")
                If myTaxNode.Attributes("name").InnerText.Contains(Name) Then
                    Return myTaxNode.Attributes("value").InnerText
                End If
            Next
            '
            'if we're still here then try /Data/Taxes/Tax
            For Each myTaxNode As XmlNode In myXmlDoc.SelectNodes("/Data/Taxes/Tax")
                If myTaxNode.Attributes("name").InnerText.Contains(Name) Then
                    Return myTaxNode.Attributes("value").InnerText
                End If
            Next
            '
            'if we're still here then try /Data/Data/Taxes/Tax
            For Each myTaxNode As XmlNode In myXmlDoc.SelectNodes("/Data/Data/Taxes/Tax")
                If myTaxNode.Attributes("name").InnerText.Contains(Name) Then
                    Return myTaxNode.Attributes("value").InnerText
                End If
            Next

            Return String.Empty
        Catch ex As Exception
            Return String.Empty
        End Try
    End Function

    <Extension()> _
    Public Sub AddElementWithAttribute(ByRef x As String, ByVal ParentNodeName As String, ByVal ElementName As String, ByVal AttributeName As String, ByVal AttributeValue As String)
        Dim XmlDoc As New XmlDocument

        Try
            XmlDoc.LoadXml(x)
        Catch ex As Exception
            XmlDoc = New XmlDocument
        End Try

        XmlDoc.AddElementWithAttribute(ParentNodeName, ElementName, AttributeName, AttributeValue)

        x = XmlDoc.OuterXml
    End Sub

    <Extension()> _
    Public Sub AddXMLElementWithInnerText(ByRef x As String, ByVal ElementName As String, ByVal InnerText As String)
        x.AddXMLElementWithInnerText(Nothing, ElementName, InnerText)
    End Sub

    <Extension()> _
    Public Sub AddXMLElementWithInnerText(ByRef x As String, ByVal ParentNodeName As String, ByVal ElementName As String, ByVal InnerText As String)
        Dim XmlDoc As New XmlDocument

        Try
            XmlDoc.LoadXml(x)
        Catch ex As Exception
            XmlDoc = New XmlDocument
        End Try

        XmlDoc.AddElementWithInnerText(ParentNodeName, ElementName, InnerText)

        x = XmlDoc.OuterXml
    End Sub

    <Extension()> _
    Public Sub MergeXML(ByRef x As String, ByVal XML As String)
        Dim XmlDoc As New XmlDocument
        Dim XmlDocToImport As New XmlDocument

        Try
            XmlDoc.LoadXml(x)
        Catch ex As Exception
            XmlDoc = New XmlDocument
            XmlDoc.AppendChild(XmlDoc.CreateElement("Data"))
        End Try

        Try
            XmlDocToImport.LoadXml(XML)
        Catch ex As Exception
            x = XmlDoc.OuterXml
            Exit Sub
        End Try

        Dim newNode As XmlNode = XmlDoc.ImportNode(XmlDocToImport.FirstChild(), True)
        Dim oldNodeList As XmlNodeList = XmlDoc.DocumentElement.GetElementsByTagName(newNode.Name)

        Do Until oldNodeList.Count = 0
            XmlDoc.DocumentElement.RemoveChild(oldNodeList(0))
            oldNodeList = XmlDoc.DocumentElement.GetElementsByTagName(newNode.Name)
        Loop

        XmlDoc.DocumentElement.AppendChild(newNode)

        x = XmlDoc.OuterXml
    End Sub
#End Region

#Region "XmlDocument extensions"

    ''' <summary>
    ''' Populates the controls in the myControls control collection parameter with element values from the XmlDocument's nodes collection
    ''' </summary>
    ''' <param name="x">XmlDocument object from which to retrieve values</param>
    ''' <param name="myControls">Control collection to populate with values</param>
    ''' <remarks>This does not update any controls that have no matching data element in the XmlDocument object</remarks>
    <Extension()> _
    Public Sub PopulateControls(ByVal x As XmlDocument, ByRef myControls As ControlCollection)
        Dim value As String = String.Empty

        For Each myControl As Control In myControls
            If myControl.HasControls Then
                x.PopulateControls(myControl.Controls)
            End If


        Next
    End Sub

    ''' <summary>
    ''' Retrieves element/attribute value for DataName from the Xml document
    ''' </summary>
    ''' <param name="x"></param>
    ''' <param name="DataName"></param>
    ''' <returns></returns>
    ''' <remarks>If DataName contains a . then the portion of the name before the . is the Node name
    ''' and the portion after the . is the attribute name of the Node whose value is to be returned</remarks>
    <Extension()> _
    Public Function GetDataValue(ByRef x As XmlDocument, ByVal DataName As String) As String
        Do Until Not DataName.Contains(" ")
            DataName = DataName.Replace(" ", "")
        Loop

        Dim values As String() = DataName.Split(".".ToCharArray)
        If values.Length = 2 Then
            Return x.GetElementAttributeValue(values(0), values(1))
        Else
            Return x.GetElementValue(DataName)
        End If
    End Function

    <Extension()> _
    Public Function GetElementValue(ByRef x As XmlDocument, ByVal ElementName As String) As String
        Do Until Not ElementName.Contains(" ")
            ElementName = ElementName.Replace(" ", "")
        Loop

        Dim myNodeList As XmlNodeList = x.GetElementsByTagName(ElementName)

        If myNodeList.Count > 0 Then
            Return myNodeList.Item(0).InnerText
        Else
            Return String.Empty
        End If
    End Function

    <Extension()> _
    Public Function GetElementValue(ByRef x As XmlDocument, ByVal ElementNameList As List(Of String)) As String
        Dim RetVal As String = String.Empty

        For Each value As String In ElementNameList
            RetVal = x.GetElementValue(value)
            If RetVal.Trim.Length <> 0 Then
                Exit For
            End If
        Next

        Return RetVal
    End Function

    <Extension()> _
    Public Function GetElementAttributeValue(ByRef x As XmlDocument, ByVal ElementName As String, ByVal AttributeName As String) As String
        Do Until ElementName.IndexOf(" ") = -1
            ElementName = ElementName.Replace(" ", "")
        Loop

        Dim myNodeList As XmlNodeList = x.GetElementsByTagName(ElementName)

        If myNodeList.Count > 0 Then
            For Each myNode As XmlNode In myNodeList
                If myNode.Attributes.GetNamedItem(AttributeName) IsNot Nothing Then
                    Return myNode.Attributes.GetNamedItem(AttributeName).Value
                End If
            Next
            Return myNodeList.Item(0).InnerText
        Else
            Return String.Empty
        End If
    End Function

    <Extension()> _
    Public Function GetMandatoryFormsList(ByRef x As XmlDocument) As List(Of String)
        Return x.GetChildNodesInnerTextList("MandatoryForms")
    End Function

    <Extension()> _
    Public Function GetChildNodesInnerTextList(ByVal x As XmlDocument, ByVal ParentNodeName As String) As List(Of String)
        Dim RetVal As New List(Of String)
        Dim myFormsNode As XmlNode = x.GetElementsByTagName(ParentNodeName)(0)

        If myFormsNode IsNot Nothing Then
            For Each myNode As XmlNode In myFormsNode.ChildNodes
                RetVal.Add(myNode.InnerText)
            Next
        End If

        Return RetVal
    End Function
    ''' <summary>
    ''' Returns True if the XML document has a node with the specified name, returns False otherwise
    ''' </summary>
    ''' <param name="x">XmlDocument object to inspect</param>
    ''' <param name="ElementName">Name of Xml element to search for</param>
    ''' <returns></returns>
    ''' <remarks>Boolean</remarks>
    <Extension()> _
    Public Function HasElement(ByRef x As XmlDocument, ByVal ElementName As String) As Boolean
        Do Until ElementName.IndexOf(" ") = -1
            ElementName = ElementName.Replace(" ", "")
        Loop

        Dim myNodeList As XmlNodeList = x.GetElementsByTagName(ElementName)

        Return myNodeList.Count > 0
    End Function

    <Extension()> _
    Public Function CreateElementWithInnerText(ByRef x As XmlDocument, ByVal ElementName As String, ByVal InnerText As String) As XmlElement
        Do Until ElementName.IndexOf(" ") = -1
            ElementName = ElementName.Replace(" ", "")
        Loop

        Dim myXmlElement As XmlElement = x.CreateElement(ElementName)
        If (InnerText IsNot Nothing) AndAlso (InnerText.Length <> 0) Then
            myXmlElement.InnerText = InnerText
        End If

        Return myXmlElement
    End Function

    <Extension()> _
    Public Sub AddElementWithInnerText(ByRef x As XmlDocument, ByVal ElementName As String, ByVal InnerText As String)
        x.AddElementWithInnerText(Nothing, ElementName, InnerText)
    End Sub

    <Extension()> _
    Public Sub AddElementWithInnerText(ByRef x As XmlDocument, ByVal ElementName As String, ByVal InnerText As Integer)
        x.AddElementWithInnerText(Nothing, ElementName, InnerText.ToString)
    End Sub

    <Extension()> _
    Public Sub AddElementWithInnerText(ByRef x As XmlDocument, ByVal ParentNodeName As String, ByVal ElementName As String, ByVal InnerText As String)
        Dim myParentNode As XmlNode

        If x.DocumentElement Is Nothing Then
            x.AppendChild(x.CreateElement("Data"))
        End If

        If ParentNodeName Is Nothing Then
            myParentNode = x.DocumentElement
        Else
            If x.GetElementsByTagName(ParentNodeName)(0) Is Nothing Then
                myParentNode = x.DocumentElement.AppendChild(x.CreateElement(ParentNodeName))
            End If
            myParentNode = x.GetElementsByTagName(ParentNodeName)(0)
        End If

        Dim myNode As XmlNode = myParentNode.SelectSingleNode(ElementName)
        Dim myElement As XmlElement = x.CreateElementWithInnerText(ElementName, InnerText)

        If myNode Is Nothing Then
            myParentNode.AppendChild(myElement)
        Else
            myNode.InnerText = InnerText
        End If
    End Sub

    <Extension()> _
    Public Sub AddElementWithAttribute(ByRef x As XmlDocument, ByVal ParentNodeName As String, ByVal ElementName As String, ByVal AttributeName As String, ByVal AttributeValue As String)
        Dim myParentNode As XmlNode

        If x.DocumentElement Is Nothing Then
            x.AppendChild(x.CreateElement("Data"))
        End If

        If ParentNodeName Is Nothing Then
            myParentNode = x.DocumentElement
        Else
            If x.GetElementsByTagName(ParentNodeName)(0) Is Nothing Then
                myParentNode = x.DocumentElement.AppendChild(x.CreateElement(ParentNodeName))
            End If
            myParentNode = x.GetElementsByTagName(ParentNodeName)(0)
        End If

        Dim myNode As XmlNode = myParentNode.SelectSingleNode(ElementName)
        Dim myElement As XmlElement
        Dim myAttribute As XmlAttribute = x.CreateAttribute(AttributeName)
        myAttribute.Value = AttributeValue

        If myNode Is Nothing Then
            myElement = x.CreateElement(ElementName)
            myElement.Attributes.SetNamedItem(myAttribute)
            myParentNode.AppendChild(myElement)
        Else
            myNode.Attributes.SetNamedItem(myAttribute)
        End If
    End Sub
#End Region
End Module
