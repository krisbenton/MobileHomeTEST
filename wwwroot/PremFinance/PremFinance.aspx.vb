Imports System.Data.SqlClient
Imports System.IO
Imports System.Xml
Imports System.Runtime.CompilerServices


Public Class PremFinance
    Inherits System.Web.UI.Page


    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        If Not IsPostBack Then
            Dim xmlData As String
            If Request.QueryString("quoteID") <> "" Then '  quoteID is not empty
                'xmlData = CreateXMLDoc(Request.QueryString("quoteID"))
                xmlData = CreateXMLDoc("838")
                CalcFinancing(xmlData)
            End If
           
            'SampleDisplay.Text += vbCrLf & "SAMPLE XML DATA" & vbCrLf & CreateXMLDoc()
        End If


    End Sub
    Public Sub CalcFinancing(ByVal x As String)
        Dim PDFString As String
        Dim myFileStream As FileStream
        Dim mySourcePDF As TallComponents.PDF.Document
        Dim myOutputPDF As TallComponents.PDF.Document
        Dim myPDFFields As New TallComponents.PDF.Document
        myOutputPDF = New TallComponents.PDF.Document
        'Try

        Dim svc As New primeRate.Prime2006WS
        Dim svrResponse As New primeRate.TSrvcResponse
        Dim SendXML, ReturnXML As String
        SendXML = x
        'SampleDisplay.Text += SendXML & vbCrLf
        'SampleDiskplay.Text += " begin response from prime rate" & vbCrLf
        svrResponse = svc.CalcFinancing("5A6D0406-C8D3-4a0e-9052-40994609B020", "5A6D0406-C8D3-4a0e-9052-40994609B020", SendXML)
        'SampleDisplay.Text += "Calc Financing Response -" & svrResponse.Status.ToString & vbCrLf

        ReturnXML = svrResponse.Document
        SaveData(ReturnXML)

        svrResponse = svc.GenAccountNumber("5A6D0406-C8D3-4a0e-9052-40994609B020", "5A6D0406-C8D3-4a0e-9052-40994609B020")
        'SampleDisplay.Text += "Generate Account Number Response -" & svrResponse.Status & vbCrLf

        svrResponse = svc.GenContract("5A6D0406-C8D3-4a0e-9052-40994609B020", "5A6D0406-C8D3-4a0e-9052-40994609B020", ReturnXML)
        PDFString = svrResponse.Document
        SampleDisplay.Text += PDFString
        'svrResponse = svc.SaveContract("5A6D0406-C8D3-4a0e-9052-40994609B020", "5A6D0406-C8D3-4a0e-9052-40994609B020", ReturnXML)
        'SampleDisplay.Text += "Save Contract Response -" & svrResponse.Status & vbCrLf

        'SampleDisplay.Text = PDFString
        'Dim b As Byte()s
        'Dim encoding As New ASCIIEncoding
        'b = encoding.GetBytes(PDFString)
        'SampleDisplay.Text = b.ToString
        'Response.AddHeader("Content-disposition", "attachment;filename=filename.pdf")
        'Response.ContentType = "application/pdf"
        'Response.BinaryWrite(b)
        'Response.End()




        Dim fin As New Finance
        fin.CalcFinancing("839")
        'Dim buffer As Byte() = Convert.FromBase64String(PDFString)

        'Dim stream As FileStream = File.Create(Me.MapPath("~\ApplicationPages\") & "Finance\FinanceContract_" & Request.QueryString("quoteID") & ".pdf", buffer.Length)
        'stream.Write(buffer, 0, buffer.Length)
        'stream.Close()

        ''PDFString = "%PDF-1.6%" & PDFString
        ''PDFString = PDFString & "%%EOF"
        

        'myFileStream = File.Create(sFile)
        'mySourcePDF = New TallComponents.PDF.Document(myFileStream)
        'myPDFFields.Pages.AddRange(mySourcePDF.Pages.CloneToArray())
        'myFileStream.Close()
        'myOutputPDF.Pages.AddRange(myPDFFields.Pages.CloneToArray)

        'Response.ContentType = "application/pdf"
        'myOutputPDF.Write(New BinaryWriter(Response.OutputStream))
        'myFileStream.Close()




        'SampleDisplay.Text += vbCrLf & " End Response from Prime Rate"

        'Catch ex As Exception
        '    Stop
        '    'SampleDisplay.Text += vbCrLf & "ERROR" & vbCrLf & ex.Message
        'End Try


    End Sub
    Public Sub SaveData(ByVal xml As String)
        Dim apr, downPayment As String
        apr = xml.GetXMLElementValue("APR")
        downPayment = xml.GetXMLElementValue("DownPayment")
        Dim ds As System.Data.DataSet
        ds = runQueryDS("EXEC sp_SaveFinanceData '" & Request.QueryString("quoteID") & "','" & apr & "','" & downPayment & "','" & xml & "' ", "ColonialMHConnectionString")

    End Sub
    Public Function getTestXML() As String
        Dim str As String
        str = "<?xml version=""1.0"" encoding=""utf-8"" standalone=""yes""?><Contract>  <Agency>    <SystemID>0</SystemID>    <AgencyID>0</AgencyID> " & _
    "<Producer>  9999</Producer>    <SubProducer>18522</SubProducer>    <AgencyType></AgencyType>    <Password></Password>    <Name><![CDATA[ATI INSURANCE]]></Name> " & _
    "<Address1><![CDATA[409 Chicago Dr.]]></Address1>    <Address2><![CDATA[Suite 109]]></Address2>    <City><![CDATA[FAYETTEVILLE]]></City>    <State><![CDATA[SC]]></State> " & _
    "<Zip><![CDATA[28306]]></Zip>   <Phone>9102232233</Phone>    <VendorAgent></VendorAgent>  </Agency>  <Insured>    <SystemID>0</SystemID>    <BorrowerID>0</BorrowerID>" & _
    "<Name><![CDATA[TEST AGAIN]]></Name>    <BusinessName><![CDATA[TEST AGAIN]]></BusinessName>    <FirstName></FirstName>    <LastName></LastName>    <Initial></Initial>" & _
    "<PhoneID>0</PhoneID>    <Phone>9102232323</Phone>    <PhoneExt></PhoneExt>    <Work></Work>    <CIP_ID>13350</CIP_ID>    <CIP_ID_DESC></CIP_ID_DESC>    <CIP_Data>123232345</CIP_Data>" & _
    "<Email></Email>    <ENT_ID>0</ENT_ID>  </Insured>  <MailAddress>    <SystemID>0</SystemID>    <AgencyID>0</AgencyID>    <Address1><![CDATA[1234 This Way]]></Address1>    <Address2></Address2>" & _
    "<City><![CDATA[FAYETTEVILLE]]></City>    <State><![CDATA[NC]]></State>    <Zip><![CDATA[28306]]></Zip>  </MailAddress>  <PhyAddress>    <SystemID>0</SystemID>    <AgencyID>0</AgencyID>" & _
    "<Address1></Address1>    <Address2></Address2>    <City></City>    <State></State>    <Zip></Zip>  </PhyAddress>  <Account>    <SystemID>0</SystemID>    <AccountID>0</AccountID>" & _
    "<Account>0</Account>    <Quote>0</Quote>    <DateSign>2010-01-11T16:35:55</DateSign>    <Status></Status>    <Revision>0</Revision>    <ContractDate>2010-01-11T00:00:00</ContractDate>    <PcDown>17.00</PcDown>" & _
    "<DownPayment>0.00</DownPayment>    <AmountFinanced>0.00</AmountFinanced>    <FinanceCharge>0.00</FinanceCharge>    <Payment>0.00</Payment>    <NumberOfPayments>8</NumberOfPayments>    <TotalOfPayments>0.00</TotalOfPayments>" & _
    "<PaymentFrequency>0</PaymentFrequency>    <DueDate>2010-01-11T16:35:55</DueDate>    <TotalPremium>0.00</TotalPremium>    <TotalCashPrice>0</TotalCashPrice>    <TotalDeferredPrice>0</TotalDeferredPrice>    <RTax>0</RTax>" & _
    "<NTax>0</NTax>    <Fees>0</Fees>    <Renewal>false</Renewal>    <Commercial>false</Commercial>    <ReleaseDate>2010-01-11T00:00:00</ReleaseDate>    <EffectiveDate>2010-01-11T16:35:55</EffectiveDate>    <EqualPmts>false</EqualPmts>" & _
    "<StateUsed>SC</StateUsed>    <StateCode>0</StateCode>    <StateDocStamp>0.00</StateDocStamp>    <Recovery>0.00</Recovery>    <AgentFee>5.00</AgentFee>    <FinChgMthd>0</FinChgMthd>    <FinChgFee>0</FinChgFee>" & _
    "<RateIndexUsed>0</RateIndexUsed>    <BaseRate>0</BaseRate>    <DefMIR>0</DefMIR>    <RetIntRate>0</RetIntRate>    <RetIntDue>0</RetIntDue>    <MinIntRate>0</MinIntRate>    <MinIntDue>0</MinIntDue>" & _
    "<WhlIntRate>0</WhlIntRate>    <WhlIntDue>0</WhlIntDue>    <TotIntRate>0.00</TotIntRate>    <TotIntDue>0</TotIntDue>    <MaxIntRate>0</MaxIntRate>    <MaxIntDue>0</MaxIntDue>    <MaxChgMthd>1</MaxChgMthd>    <SurChrg>0</SurChrg>" & _
    "<Discounts>0</Discounts>    <AgentRateIndex>0</AgentRateIndex>    <ReBate>0</ReBate>    <RebateMthd></RebateMthd>    <APR>0.000</APR>    <LateFee>0.00</LateFee>    <LateDays>0</LateDays>    <DefChgFee>0.00</DefChgFee>" & _
    "<Term>0</Term>    <PIFS>0</PIFS>    <TakenOutofDP>0</TakenOutofDP>    <TotalAmtDue>0</TotalAmtDue>    <Printed>false</Printed>    <OptionB>false</OptionB>    <ItemizationFlag>true</ItemizationFlag>" & _
    "<QuotedPcDown>0</QuotedPcDown>    <AddinPremiums>0</AddinPremiums>    <ApplicationInfo></ApplicationInfo>    <CalcMsgText></CalcMsgText>    <UserType></UserType>    <IntUser></IntUser>    <IntUserId>0</IntUserId>    <ExtUser></ExtUser>" & _
    "<ExtUserId>0</ExtUserId>    <Uploaded>N</Uploaded>    <ParentID>0</ParentID>    <InternalOnly>false</InternalOnly>    <ACHFlag>false</ACHFlag>  </Account>  <Policy>" & _
    "<SystemID>0</SystemID>    <PolicyID>0</PolicyID>    <Policy><![CDATA[234234234]]></Policy>    <EffectiveDate>2010-01-08T00:00:00</EffectiveDate>    <ExpirationDate>2011-01-08T00:00:00</ExpirationDate>    <Term>12</Term>    <Premium>667.00</Premium>    <CarrierID>0</CarrierID>" & _
    "<CarrierPFC>469</CarrierPFC>    <CompanyPFC>469</CompanyPFC>    <CarrierName><![CDATA[ATLANTIC CASUALTY INSURANCE CO]]></CarrierName>    <CarrierCQID>0</CarrierCQID>    <MgaID>0</MgaID>    <MgaName></MgaName>    <Rtax>0.00</Rtax>" & _
    "<NTax>0.00</NTax>    <Fees>0.00</Fees>    <Total>667.00</Total>    <Commission>0.00</Commission>    <CommissionPct>0.00</CommissionPct>    <MinimumEarned>0</MinimumEarned>    <MinimumEarnedPct>0.00</MinimumEarnedPct>    <PcDown>0.00</PcDown>    <DownPayment>114.00</DownPayment>" & _
    "<Renewal>false</Renewal>    <PolicyType><![CDATA[AUTO-FULL]]></PolicyType>    <CoverageCode>1</CoverageCode>    <CoverageDesc></CoverageDesc>    <OptionB>false</OptionB>    <DPOption>1</DPOption>    <Filings>false</Filings>" & _
    "<DrftNum>0</DrftNum>    <DrftAmt>0</DrftAmt>    <DrftAP>false</DrftAP>    <DrftNet>false</DrftNet>    <DrftPay></DrftPay>    <DrftToAgt>false</DrftToAgt>    <Surchrgpct>0</Surchrgpct>    <Discounts>0</Discounts>" & _
    "<VendorCompany></VendorCompany>    <VendorCoverage></VendorCoverage>  </Policy></Contract>"
        Return str
    End Function
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
                RetVal.AddXMLElementWithInnerText("Agency", "Producer", "9999")
                RetVal.AddXMLElementWithInnerText("Agency", "SubProducer", "0")
                RetVal.AddXMLElementWithInnerText("Agency", "AgencyType", "")
                RetVal.AddXMLElementWithInnerText("Agency", "Name", "Southern Homes Insurance Agency, Inc")
                RetVal.AddXMLElementWithInnerText("Agency", "Address1", "12788 Hwy. 90 West")
                RetVal.AddXMLElementWithInnerText("Agency", "Address2", "0")
                RetVal.AddXMLElementWithInnerText("Agency", "City", "Live Oak")
                RetVal.AddXMLElementWithInnerText("Agency", "State", "FL")
                RetVal.AddXMLElementWithInnerText("Agency", "Zip", "32060")
                RetVal.AddXMLElementWithInnerText("Agency", "Phone", "3863626330")
                RetVal.AddXMLElementWithInnerText("Agency", "VendorAgent", "")

                'Insured
                RetVal.AddXMLElementWithInnerText("Insured", "SystemID", "0")
                RetVal.AddXMLElementWithInnerText("Insured", "BorrowerID", "0")
                RetVal.AddXMLElementWithInnerText("Insured", "Name", UCase(ds.Tables(0).Rows(0).Item("ApplicationName").ToString))
                RetVal.AddXMLElementWithInnerText("Insured", "BusinessName", UCase(ds.Tables(0).Rows(0).Item("ApplicationName").ToString))
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
                RetVal.AddXMLElementWithInnerText("MailAddress", "Address1", UCase(ds.Tables(0).Rows(0).Item("Mail_Address1").ToString()))
                RetVal.AddXMLElementWithInnerText("MailAddress", "Address2", "")
                RetVal.AddXMLElementWithInnerText("MailAddress", "City", UCase(ds.Tables(0).Rows(0).Item("Mail_City").ToString()))
                RetVal.AddXMLElementWithInnerText("MailAddress", "State", ds.Tables(0).Rows(0).Item("Mail_State").ToString())
                RetVal.AddXMLElementWithInnerText("MailAddress", "Zip", ds.Tables(0).Rows(0).Item("Mail_Zip").ToString())

                'PhyAddress
                RetVal.AddXMLElementWithInnerText("PhyAddress", "SystemID", "0")
                RetVal.AddXMLElementWithInnerText("PhyAddress", "AgencyID", "0")
                RetVal.AddXMLElementWithInnerText("PhyAddress", "Address1", UCase(ds.Tables(0).Rows(0).Item("Phy_Address1").ToString()))
                RetVal.AddXMLElementWithInnerText("PhyAddress", "Address2", "")
                RetVal.AddXMLElementWithInnerText("PhyAddress", "City", UCase(ds.Tables(0).Rows(0).Item("Phy_City").ToString()))
                RetVal.AddXMLElementWithInnerText("PhyAddress", "State", ds.Tables(0).Rows(0).Item("Phy_State").ToString())
                RetVal.AddXMLElementWithInnerText("PhyAddress", "Zip", ds.Tables(0).Rows(0).Item("Phy_Zip").ToString())
                'Account

                RetVal.AddXMLElementWithInnerText("Account", "SystemID", "0")
                RetVal.AddXMLElementWithInnerText("Account", "AccountID", "0")
                RetVal.AddXMLElementWithInnerText("Account", "Account", "0")
                RetVal.AddXMLElementWithInnerText("Account", "Quote", "0")
                RetVal.AddXMLElementWithInnerText("Account", "DateSign", "2010-01-11T00:00:00") 'formated date
                RetVal.AddXMLElementWithInnerText("Account", "Status", "")
                RetVal.AddXMLElementWithInnerText("Account", "Revision", "0")
                RetVal.AddXMLElementWithInnerText("Account", "ContractDate", "2010-01-11T00:00:00") 'formated date
                RetVal.AddXMLElementWithInnerText("Account", "PcDown", "0")
                RetVal.AddXMLElementWithInnerText("Account", "DownPayment", "0")
                RetVal.AddXMLElementWithInnerText("Account", "AmountFinanced", "0")
                RetVal.AddXMLElementWithInnerText("Account", "Payment", "0")
                RetVal.AddXMLElementWithInnerText("Account", "NumberOfPayments", "8")
                RetVal.AddXMLElementWithInnerText("Account", "TotalOfPayments", "0.00")
                RetVal.AddXMLElementWithInnerText("Account", "PaymentFrequency", "0")
                RetVal.AddXMLElementWithInnerText("Account", "DueDate", "2010-01-11T00:00:00") 'formated date
                RetVal.AddXMLElementWithInnerText("Account", "TotalPremium", "0")
                RetVal.AddXMLElementWithInnerText("Account", "TotalCashPrice", "0")
                RetVal.AddXMLElementWithInnerText("Account", "TotalDeferredPrice", "0")
                RetVal.AddXMLElementWithInnerText("Account", "RTax", "0")
                RetVal.AddXMLElementWithInnerText("Account", "NTax", "0")
                RetVal.AddXMLElementWithInnerText("Account", "Fees", "0")
                RetVal.AddXMLElementWithInnerText("Account", "Renewal", "false")
                RetVal.AddXMLElementWithInnerText("Account", "Commercial", "false")
                RetVal.AddXMLElementWithInnerText("Account", "ReleaseDate", "2010-01-11T00:00:00") 'formated date
                RetVal.AddXMLElementWithInnerText("Account", "EffectiveDate", "2010-01-11T00:00:00") 'formated date
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
                RetVal.AddXMLElementWithInnerText("Policy", "CarrierName", UCase(ds.Tables(0).Rows(0).Item("agencyName").ToString()))
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
                RetVal.AddXMLElementWithInnerText("Policy", "Renewal", "false")
                RetVal.AddXMLElementWithInnerText("Policy", "PolicyType", "AUTO-FULL")
                RetVal.AddXMLElementWithInnerText("Policy", "CoverageCode", "1")
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

    Private Sub MessageBox(ByVal str As String)
        Dim lbl As New Label()
        lbl.Text = "<script language='javascript'> window.alert('" & str & "');" & "<" & "/script>"
        Page.Controls.Add(lbl)

    End Sub
    Private Sub updateStatus(ByVal str As String)
        Dim lbl As New Label()
        lbl.Text = "<script language='javascript'> window.status ='" & str & "';" & "<" & "/script>"
        Page.Controls.Add(lbl)

    End Sub

   
End Class