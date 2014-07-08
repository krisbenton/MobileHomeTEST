Imports System.Data.SqlClient
Imports System.IO
Imports System.Xml
Imports System.Runtime.CompilerServices
Public Class Finance
    Inherits System.Web.UI.Page
    Dim errorMessage As String


    Public Function CalcFinancing(ByVal quoteID As String)
        Dim svc As New primeRate.Prime2006WS
        Dim svrResponse As New primeRate.TSrvcResponse
        Dim SendXML, ReturnXML, AccountNumber As String
        Dim PDFString As String
        SendXML = CreateXMLDoc(quoteID)


        Try
            svrResponse = svc.CalcFinancing("5A6D0406-C8D3-4a0e-9052-40994609B020", "5A6D0406-C8D3-4a0e-9052-40994609B020", SendXML)
            ReturnXML = svrResponse.Document
            If ReturnXML.Contains("<") Then
                'Continue
            Else
                setErrorMessage(ReturnXML)
                Return False
            End If
            'SaveData(ReturnXML, quoteID)
            svrResponse = svc.GenAccountNumber("5A6D0406-C8D3-4a0e-9052-40994609B020", "5A6D0406-C8D3-4a0e-9052-40994609B020")
            AccountNumber = svrResponse.Document
            ReturnXML = setAccountNumber(ReturnXML, AccountNumber)
            SaveData(ReturnXML, quoteID)
            svrResponse = svc.GenContract("5A6D0406-C8D3-4a0e-9052-40994609B020", "5A6D0406-C8D3-4a0e-9052-40994609B020", ReturnXML)
            PDFString = svrResponse.Document
            svrResponse = svc.SaveContract("5A6D0406-C8D3-4a0e-9052-40994609B020", "5A6D0406-C8D3-4a0e-9052-40994609B020", ReturnXML)
            Dim buffer As Byte() = Convert.FromBase64String(PDFString)

            Dim stream As FileStream = File.Create(Server.MapPath("~\ApplicationPages\") & "Finance\FinanceContract_" & quoteID & ".pdf", buffer.Length)
            stream.Write(buffer, 0, buffer.Length)
            stream.Close()

        Catch ex As Exception
            errortrap("Finance Web Service", "Calc Financing", ex.Message)
            Stop
            Return False
        End Try
        Return True


    End Function
    Public Sub setErrorMessage(ByVal err As String)
        errorMessage = err
    End Sub
    Public Function getErrorMessage()
        Return errorMessage
    End Function
    Public Function setAccountNumber(ByVal xml As String, ByVal accountNumber As String) As String
        xml.AddXMLElementWithInnerText("Account", "Account", accountNumber)
        Return xml
    End Function
    Public Sub SaveData(ByVal xml As String, ByVal quoteID As String)
        Dim apr, downPayment As String
        apr = xml.GetXMLElementValue("APR")
        downPayment = xml.GetXMLElementValue("DownPayment")
        Dim ds As System.Data.DataSet
        ds = runQueryDS("EXEC sp_SaveFinanceData '" & quoteID & "','" & apr & "','" & downPayment & "','" & xml & "' ", "ColonialMHConnectionString")

    End Sub
    Public Function CreateXMLDoc(ByVal quoteID As String)
        Dim ds As System.Data.DataSet
        ds = runQueryDS("EXEC sp_getPrimeRateInfo '" & quoteID & "' ", "ColonialMHConnectionString")

        Dim RetVal As String = String.Empty
        Try
            If ds.Tables(0).Rows.Count > 0 Then
                'Agency
                RetVal.AddXMLElementWithInnerText(ElementName:="Contract", InnerText:="")
                RetVal.AddXMLElementWithInnerText("Contract", "Agency", "")
                RetVal.AddXMLElementWithInnerText("Contract", "Insured", "")
                RetVal.AddXMLElementWithInnerText("Contract", "MailAddress", "")
                RetVal.AddXMLElementWithInnerText("Contract", "PhyAddress", "")
                RetVal.AddXMLElementWithInnerText("Contract", "Account", "")
                RetVal.AddXMLElementWithInnerText("Contract", "Policy", "")

                'Agency
                RetVal.AddXMLElementWithInnerText("Agency", "SystemID", "0")
                RetVal.AddXMLElementWithInnerText("Agency", "AgencyID", "0")
                RetVal.AddXMLElementWithInnerText("Agency", "Producer", ds.Tables(0).Rows(0).Item("Producer").ToString)
                RetVal.AddXMLElementWithInnerText("Agency", "SubProducer", "0")
                RetVal.AddXMLElementWithInnerText("Agency", "AgencyType", "")
                RetVal.AddXMLElementWithInnerText("Agency", "Name", "Southern Homes Insurance Agency, Inc")
                RetVal.AddXMLElementWithInnerText("Agency", "Address1", "12788 Hwy. 90 West")
                RetVal.AddXMLElementWithInnerText("Agency", "Address2", " ")
                RetVal.AddXMLElementWithInnerText("Agency", "City", "Live Oak")
                RetVal.AddXMLElementWithInnerText("Agency", "State", "FL")
                RetVal.AddXMLElementWithInnerText("Agency", "Zip", "32060")
                RetVal.AddXMLElementWithInnerText("Agency", "Phone", "3863626330")
                RetVal.AddXMLElementWithInnerText("Agency", "VendorAgent", "")

                'Insured
                RetVal.AddXMLElementWithInnerText("Insured", "SystemID", "0")
                RetVal.AddXMLElementWithInnerText("Insured", "BorrowerID", "0")
                RetVal.AddXMLElementWithInnerText("Insured", "Name", ds.Tables(0).Rows(0).Item("ApplicationName").ToString)
                RetVal.AddXMLElementWithInnerText("Insured", "BusinessName", ds.Tables(0).Rows(0).Item("ApplicationName").ToString)
                RetVal.AddXMLElementWithInnerText("Insured", "FirstName", "")
                RetVal.AddXMLElementWithInnerText("Insured", "LastName", "")
                RetVal.AddXMLElementWithInnerText("Insured", "PhoneId", "0")
                RetVal.AddXMLElementWithInnerText("Insured", "Phone", ds.Tables(0).Rows(0).Item("PhoneNumber").ToString())
                RetVal.AddXMLElementWithInnerText("Insured", "PhoneExt", "")
                RetVal.AddXMLElementWithInnerText("Insured", "CIP_ID", "0")
                RetVal.AddXMLElementWithInnerText("Insured", "CIP_ID_DESC", "")
                RetVal.AddXMLElementWithInnerText("Insured", "CIP_Data", "")
                RetVal.AddXMLElementWithInnerText("Insured", "Email", "")
                RetVal.AddXMLElementWithInnerText("Insured", "ENT_ID", "0")

                'MailAddress
                RetVal.AddXMLElementWithInnerText("MailAddress", "SystemID", "0")
                RetVal.AddXMLElementWithInnerText("MailAddress", "AgencyID", "0")
                RetVal.AddXMLElementWithInnerText("MailAddress", "Address1", ds.Tables(0).Rows(0).Item("Mail_Address1").ToString())
                RetVal.AddXMLElementWithInnerText("MailAddress", "Address2", "")
                RetVal.AddXMLElementWithInnerText("MailAddress", "City", ds.Tables(0).Rows(0).Item("Mail_City").ToString())
                RetVal.AddXMLElementWithInnerText("MailAddress", "State", ds.Tables(0).Rows(0).Item("Mail_State").ToString())
                RetVal.AddXMLElementWithInnerText("MailAddress", "Zip", ds.Tables(0).Rows(0).Item("Mail_Zip").ToString())

                'PhyAddress
                RetVal.AddXMLElementWithInnerText("PhyAddress", "SystemID", "0")
                RetVal.AddXMLElementWithInnerText("PhyAddress", "AgencyID", "0")
                RetVal.AddXMLElementWithInnerText("PhyAddress", "Address1", ds.Tables(0).Rows(0).Item("Phy_Address1").ToString())
                RetVal.AddXMLElementWithInnerText("PhyAddress", "Address2", "")
                RetVal.AddXMLElementWithInnerText("PhyAddress", "City", ds.Tables(0).Rows(0).Item("Phy_City").ToString())
                RetVal.AddXMLElementWithInnerText("PhyAddress", "State", ds.Tables(0).Rows(0).Item("Phy_State").ToString())
                RetVal.AddXMLElementWithInnerText("PhyAddress", "Zip", ds.Tables(0).Rows(0).Item("Phy_Zip").ToString())
                'Account

                RetVal.AddXMLElementWithInnerText("Account", "SystemID", "0")
                RetVal.AddXMLElementWithInnerText("Account", "AccountID", "0")
                RetVal.AddXMLElementWithInnerText("Account", "Account", "0")
                RetVal.AddXMLElementWithInnerText("Account", "Quote", "0")
                RetVal.AddXMLElementWithInnerText("Account", "DateSign", ds.Tables(0).Rows(0).Item("CurrentDate").ToString()) 'formated date 2010-01-11T00:00:00
                RetVal.AddXMLElementWithInnerText("Account", "Status", "")
                RetVal.AddXMLElementWithInnerText("Account", "Revision", "0")
                RetVal.AddXMLElementWithInnerText("Account", "ContractDate", ds.Tables(0).Rows(0).Item("CurrentDate").ToString()) 'formated date 2010-01-11T00:00:00
                RetVal.AddXMLElementWithInnerText("Account", "PcDown", "0")
                RetVal.AddXMLElementWithInnerText("Account", "DownPayment", "0")
                RetVal.AddXMLElementWithInnerText("Account", "AmountFinanced", "0")
                RetVal.AddXMLElementWithInnerText("Account", "Payment", "0")
                RetVal.AddXMLElementWithInnerText("Account", "NumberOfPayments", "8")
                RetVal.AddXMLElementWithInnerText("Account", "TotalOfPayments", "0.00")
                RetVal.AddXMLElementWithInnerText("Account", "PaymentFrequency", "0")
                RetVal.AddXMLElementWithInnerText("Account", "DueDate", ds.Tables(0).Rows(0).Item("CurrentDate").ToString()) 'formated date 2010-01-11T00:00:00
                RetVal.AddXMLElementWithInnerText("Account", "TotalPremium", "0")
                RetVal.AddXMLElementWithInnerText("Account", "TotalCashPrice", "0")
                RetVal.AddXMLElementWithInnerText("Account", "TotalDeferredPrice", "0")
                RetVal.AddXMLElementWithInnerText("Account", "RTax", "0")
                RetVal.AddXMLElementWithInnerText("Account", "NTax", "0")
                RetVal.AddXMLElementWithInnerText("Account", "Fees", "0")
                RetVal.AddXMLElementWithInnerText("Account", "Renewal", ds.Tables(0).Rows(0).Item("Renewal"))
                RetVal.AddXMLElementWithInnerText("Account", "Commercial", "false")
                RetVal.AddXMLElementWithInnerText("Account", "ReleaseDate", ds.Tables(0).Rows(0).Item("CurrentDate").ToString()) 'formated date 2010-01-11T00:00:00
                RetVal.AddXMLElementWithInnerText("Account", "EffectiveDate", ds.Tables(0).Rows(0).Item("CurrentDate").ToString()) 'formated date 2010-01-11T00:00:00
                RetVal.AddXMLElementWithInnerText("Account", "EqualPmts", "false")
                RetVal.AddXMLElementWithInnerText("Account", "StateUsed", ds.Tables(0).Rows(0).Item("Phy_State").ToString()) 'State
                RetVal.AddXMLElementWithInnerText("Account", "StateCode", "0")
                RetVal.AddXMLElementWithInnerText("Account", "StateDocStamp", "0.00")
                RetVal.AddXMLElementWithInnerText("Account", "Recovery", "0.00")
                RetVal.AddXMLElementWithInnerText("Account", "AgentFee", "5.00")
                RetVal.AddXMLElementWithInnerText("Account", "FinChgMthd", "0")
                RetVal.AddXMLElementWithInnerText("Account", "FinChgFee", "0")
                RetVal.AddXMLElementWithInnerText("Account", "RateIndexUsed", "0")
                RetVal.AddXMLElementWithInnerText("Account", "BaseRate", "0")
                RetVal.AddXMLElementWithInnerText("Account", "DefMIR", "0")
                RetVal.AddXMLElementWithInnerText("Account", "RetIntRate", "0")
                RetVal.AddXMLElementWithInnerText("Account", "RetIntDue", "0")
                RetVal.AddXMLElementWithInnerText("Account", "MinIntRate", "0")
                RetVal.AddXMLElementWithInnerText("Account", "MinIntDue", "0")
                RetVal.AddXMLElementWithInnerText("Account", "WhlIntRate", "0")
                RetVal.AddXMLElementWithInnerText("Account", "WhlIntDue", "0")
                RetVal.AddXMLElementWithInnerText("Account", "TotIntRate", "0.00")
                RetVal.AddXMLElementWithInnerText("Account", "TotIntDue", "0")
                RetVal.AddXMLElementWithInnerText("Account", "MaxIntRate", "0")
                RetVal.AddXMLElementWithInnerText("Account", "MaxINtDue", "0")
                RetVal.AddXMLElementWithInnerText("Account", "MaxChgMthd", "1")
                RetVal.AddXMLElementWithInnerText("Account", "SurChrg", "0")
                RetVal.AddXMLElementWithInnerText("Account", "Discounts", "0")
                RetVal.AddXMLElementWithInnerText("Account", "AgentRateIndex", "0")
                RetVal.AddXMLElementWithInnerText("Account", "ReBate", "0")
                RetVal.AddXMLElementWithInnerText("Account", "RebateMthd", "")
                RetVal.AddXMLElementWithInnerText("Account", "APR", "0.000")
                RetVal.AddXMLElementWithInnerText("Account", "LateFee", "0.00")
                RetVal.AddXMLElementWithInnerText("Account", "LateDays", "0")
                RetVal.AddXMLElementWithInnerText("Account", "DefChgFee", "0.00")
                RetVal.AddXMLElementWithInnerText("Account", "Term", "0")
                RetVal.AddXMLElementWithInnerText("Account", "PIFS", "0")
                RetVal.AddXMLElementWithInnerText("Account", "TakenOutofDP", "0")
                RetVal.AddXMLElementWithInnerText("Account", "TotalAmtDue", "0")

                RetVal.AddXMLElementWithInnerText("Account", "Printed", "false")
                RetVal.AddXMLElementWithInnerText("Account", "OptionB", "false")
                RetVal.AddXMLElementWithInnerText("Account", "ItemizationFlag", "true")
                RetVal.AddXMLElementWithInnerText("Account", "QuotedPcDown", "0")
                RetVal.AddXMLElementWithInnerText("Account", "AddinPremiums", "0")
                RetVal.AddXMLElementWithInnerText("Account", "ApplicationInfo", "")
                RetVal.AddXMLElementWithInnerText("Account", "CalcMsgText", "")
                RetVal.AddXMLElementWithInnerText("Account", "UserType", "")
                RetVal.AddXMLElementWithInnerText("Account", "IntUser", "")
                RetVal.AddXMLElementWithInnerText("Account", "IntUserId", "0")
                RetVal.AddXMLElementWithInnerText("Account", "ExtUser", "")
                RetVal.AddXMLElementWithInnerText("Account", "ExtUserId", "0")
                RetVal.AddXMLElementWithInnerText("Account", "Uploaded", "N")
                RetVal.AddXMLElementWithInnerText("Account", "ParentID", "0")
                RetVal.AddXMLElementWithInnerText("Account", "InternalOnly", "false")
                RetVal.AddXMLElementWithInnerText("Account", "ACHFlad", "false")

                'Policy
                RetVal.AddXMLElementWithInnerText("Policy", "SystemID", "0")
                RetVal.AddXMLElementWithInnerText("Policy", "PolicyID", "0")
                RetVal.AddXMLElementWithInnerText("Policy", "Policy", ds.Tables(0).Rows(0).Item("PolicyID").ToString()) 'PolicyID??
                RetVal.AddXMLElementWithInnerText("Policy", "EffectiveDate", ds.Tables(0).Rows(0).Item("EffectiveDate").ToString()) 'Effective Date
                RetVal.AddXMLElementWithInnerText("Policy", "ExpirationDate", ds.Tables(0).Rows(0).Item("ExpireDate").ToString()) 'EffectiveDate + 12
                RetVal.AddXMLElementWithInnerText("Policy", "Term", "12")
                RetVal.AddXMLElementWithInnerText("Policy", "Premium", ds.Tables(0).Rows(0).Item("Premium").ToString()) 'Premium Minus fees
                RetVal.AddXMLElementWithInnerText("Policy", "CarrierID", "0")
                RetVal.AddXMLElementWithInnerText("Policy", "CarrierPFC", "0") '????
                RetVal.AddXMLElementWithInnerText("Policy", "CompanyPFC", "0") '???
                RetVal.AddXMLElementWithInnerText("Policy", "CarrierName", ds.Tables(0).Rows(0).Item("agencyName").ToString())
                RetVal.AddXMLElementWithInnerText("Policy", "CarrierCQID", "0")
                RetVal.AddXMLElementWithInnerText("Policy", "MgaID", "0")
                RetVal.AddXMLElementWithInnerText("Policy", "MgaName", "")
                RetVal.AddXMLElementWithInnerText("Policy", "RTax", "0.00")
                RetVal.AddXMLElementWithInnerText("Policy", "NTax", "0.00")
                RetVal.AddXMLElementWithInnerText("Policy", "Fees", ds.Tables(0).Rows(0).Item("Fees").ToString()) 'Fees
                RetVal.AddXMLElementWithInnerText("Policy", "Total", ds.Tables(0).Rows(0).Item("TotalPremium").ToString()) 'Total Amount  IS THIS A DUPLICATE????????
                RetVal.AddXMLElementWithInnerText("Policy", "Commission", "0.00")
                RetVal.AddXMLElementWithInnerText("Policy", "CommissionPct", "0.00")
                RetVal.AddXMLElementWithInnerText("Policy", "MinimumEarned", "0")
                RetVal.AddXMLElementWithInnerText("Policy", "MinimumEarnedPct", "0.00")
                RetVal.AddXMLElementWithInnerText("Policy", "PcDown", "0.00")
                RetVal.AddXMLElementWithInnerText("Policy", "DownPayment", "0") 'What amount?
                RetVal.AddXMLElementWithInnerText("Policy", "Renewal", ds.Tables(0).Rows(0).Item("Renewal"))
                RetVal.AddXMLElementWithInnerText("Policy", "PolicyType", "AUTO-FULL")
                RetVal.AddXMLElementWithInnerText("Policy", "CoverageCode", "3")
                RetVal.AddXMLElementWithInnerText("Policy", "CoverageDesc", "")
                RetVal.AddXMLElementWithInnerText("Policy", "OptionB", "false")
                RetVal.AddXMLElementWithInnerText("Policy", "DPOption", "1")
                RetVal.AddXMLElementWithInnerText("Policy", "Filings", "false")
                RetVal.AddXMLElementWithInnerText("Policy", "DrftNum", "0")
                RetVal.AddXMLElementWithInnerText("Policy", "DrftAmt", "0")
                RetVal.AddXMLElementWithInnerText("Policy", "DrftAP", "false")
                RetVal.AddXMLElementWithInnerText("Policy", "DrftNet", "false")
                RetVal.AddXMLElementWithInnerText("Policy", "DrftPay", "")
                RetVal.AddXMLElementWithInnerText("Policy", "DrftToAgt", "false")
                RetVal.AddXMLElementWithInnerText("Policy", "Surchrgpct", "0")
                RetVal.AddXMLElementWithInnerText("Policy", "Discounts", "0")
                RetVal.AddXMLElementWithInnerText("Policy", "VendorCompany", "")
                RetVal.AddXMLElementWithInnerText("Policy", "VendorCoverage", "")
            End If


        Catch ex As Exception
            Stop
        End Try

        Return RetVal

    End Function
    'SQL Helper Fucntion
    Public Function runQueryDS(ByVal str As String, ByVal connectionString As String)
        Dim Connection As String = System.Configuration.ConfigurationManager.ConnectionStrings(connectionString).ConnectionString
        Dim dbConnection As System.Data.IDbConnection = New System.Data.SqlClient.SqlConnection(Connection)
        Dim queryString = str
        Dim dbCommand As System.Data.IDbCommand = New System.Data.SqlClient.SqlCommand
        dbCommand.CommandText = queryString
        dbCommand.Connection = dbConnection
        Dim dataAdapter As System.Data.IDbDataAdapter = New System.Data.SqlClient.SqlDataAdapter
        dataAdapter.SelectCommand = dbCommand
        Dim dataSet As System.Data.DataSet = New System.Data.DataSet
        dataAdapter.Fill(dataSet)
        Return dataSet
    End Function

    Private Sub errortrap(ByVal sqlcomm As String, ByVal appsub As String, ByVal errormsg As String)
        Dim intRowsAff As Integer
        Dim Connection As String = System.Configuration.ConfigurationManager.ConnectionStrings("ColonialMHConnectionString").ConnectionString
        Dim dbConnection As System.Data.IDbConnection = New System.Data.SqlClient.SqlConnection(Connection)
        Dim cmd As New SqlCommand("sp_InsertError", dbConnection)
        cmd.CommandType = CommandType.StoredProcedure
        cmd.Parameters.Add("@code", SqlDbType.VarChar, 8000).Value = sqlcomm
        cmd.Parameters.Add("@Page", SqlDbType.VarChar, 50).Value = "Financing"
        cmd.Parameters.Add("@sub", SqlDbType.VarChar, 50).Value = appsub
        cmd.Parameters.Add("@msg", SqlDbType.VarChar, 8000).Value = errormsg
        Try
            cmd.Connection.Open()
            intRowsAff = cmd.ExecuteNonQuery()
        Catch ex As Exception

        End Try
        'Dim queryString = Str()
        'Dim dbCommand As System.Data.IDbCommand = New System.Data.SqlClient.SqlCommand
        'dbCommand.CommandText = queryString
        'dbCommand.Connection = dbConnection
        'Dim dataAdapter As System.Data.IDbDataAdapter = New System.Data.SqlClient.SqlDataAdapter
        'dataAdapter.SelectCommand = dbCommand
        'Dim dataSet As System.Data.DataSet = New System.Data.DataSet
        'dataAdapter.Fill(dataSet)
        'Return dataSet

    End Sub

   
End Class
