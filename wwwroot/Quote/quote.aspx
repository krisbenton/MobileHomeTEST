<%@ Page Language="vb" Title="TCG Mobile Home Rater" AutoEventWireup="false" CodeBehind="quote.aspx.vb" Inherits="MobileHomeRater.quote" MasterPageFile="../IntPage.Master" EnableEventValidation="false"  EnableSessionState="true" EnableViewState="true" Debug="true" %>

<%@ Register assembly="DevExpress.Web.v13.1, Version=13.1.8.0, Culture=neutral, PublicKeyToken=b88d1754d700e49a" namespace="DevExpress.Web.ASPxGridView" tagprefix="dx" %>
<%@ Register assembly="DevExpress.Web.v13.1, Version=13.1.8.0, Culture=neutral, PublicKeyToken=b88d1754d700e49a" namespace="DevExpress.Web.ASPxEditors" tagprefix="dx" %>

<%@ Register assembly="DevExpress.Web.v13.1, Version=13.1.8.0, Culture=neutral, PublicKeyToken=b88d1754d700e49a" namespace="DevExpress.Web.ASPxPopupControl" tagprefix="dx" %>

<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolderMenu" runat="server">
    <script type="text/javascript">
        //****************************************************************************************
        //AR//
        function Hide_Show_Ar(currentSelection) {
            //*************************************************************************
            //American Reliable
            //Hide all

            document.getElementById('<%= ar_mh_prog1.ClientID %>').style.display = 'none';
            document.getElementById('<%= ar_mh_prog1_Options.ClientID %>').style.display = 'none';
            document.getElementById('<%= ar_mh_prog2.ClientID %>').style.display = 'none';
            document.getElementById('<%= ar_mh_prog2_Options.ClientID %>').style.display = 'none';
            //document.getElementById('ar_mh_prog2').style.display = 'none';
            //document.getElementById('ar_mh_prog2_Options').style.display = 'none';
            document.getElementById('<%= ar_mh_prog3.ClientID %>').style.display = 'none';
            document.getElementById('<%= ar_mh_prog3_Options.ClientID %>').style.display = 'none';
            document.getElementById('AR_Ineligible').style.display = 'none';


            if (currentSelection == "Owner") {
                document.getElementById('<%= ar_mh_prog1.ClientID %>').style.display = '';
                document.getElementById('<%= ar_mh_prog1_Options.ClientID %>').style.display = '';
                document.getElementById('<%= ar_mh_prog2.ClientID %>').style.display = '';
                document.getElementById('<%= ar_mh_prog2_Options.ClientID %>').style.display = '';
                //document.getElementById('ar_mh_prog2').style.display = '';
                //document.getElementById('ar_mh_prog2_Options').style.display = '';
            }
            if (currentSelection == "Seasonal") {
                document.getElementById('<%= ar_mh_prog2.ClientID %>').style.display = '';
                document.getElementById('<%= ar_mh_prog2_Options.ClientID %>').style.display = '';
                //document.getElementById('ar_mh_prog2').style.display = '';
                //document.getElementById('ar_mh_prog2_Options').style.display = '';
            }
            if (currentSelection == "Rental") {
                document.getElementById('<%= ar_mh_prog3.ClientID %>').style.display = '';
                document.getElementById('<%= ar_mh_prog3_Options.ClientID %>').style.display = '';

            }
            if (currentSelection == "Tenant" || currentSelection == "Vacant") {
                //Set AR message to Ineligible due to home use
                document.getElementById('AR_Ineligible').style.display = '';
                document.getElementById('AR_Errlbl').innerText = "Ineligible due to home use."
            }
            //*************************************************************************

        }
        function ARPremTotalRedirect() {

                     document.getElementById('<%=btnBeforeApp.ClientID%>').click();
            //            document.getElementById('<%=savebtn.ClientID%>').fireEvent("onclick");
           // opener.getElementById('<%=btnBeforeApp.ClientID%>').click();
            var quoteID = document.getElementById('<%=lblquoteNumber.ClientID%>').innerText;
            
            window.location = '/Application/ARApplication.aspx?quoteID=' + quoteID + '';

        } //End ARPremTotalRedirect

        function openAROptions() {
            var e;
            type = document.getElementById('<%= HiddenFieldSelected.ClientID %>').value;

            if (type == "Package") //Show Package Values
            {

                //Program Details
                document.getElementById('<%=lblDwellModTotal_cov.ClientID%>').innerText = document.getElementById('<%=txtcvgamt.ClientID%>').value;
                document.getElementById('<%=lblUnAttModTotal_cov.ClientID%>').innerText = document.getElementById('<%=txt_unattstr_AR1.ClientID%>').value;
                document.getElementById('<%=lblPerPropModTotal_cov.ClientID%>').innerText = document.getElementById('<%=txt_pp_AR1.ClientID%>').value;

                e = document.getElementById('<%=dd_pl_AR1.ClientID%>');
                document.getElementById('<%=lblPerLiabModTotal_cov.ClientID%>').innerText = e.options[e.selectedIndex].text;
                document.getElementById('<%=lblMedPayModTotal_cov.ClientID%>').innerText = "$500";

                e = document.getElementById('<%=dd_rep_AR1.ClientID%>');
                document.getElementById('<%=lblPPRepModTotal_cov.ClientID%>').innerText = e.options[e.selectedIndex].text;

                e = document.getElementById('<%=dd_mhr_AR1.ClientID%>');
                document.getElementById('<%=lblMHRepModTotal_cov.ClientID%>').innerText = e.options[e.selectedIndex].text;

                document.getElementById('<%=lblPremModTotal.ClientID%>').innerText = document.getElementById('<%=ar_baseprem1.ClientID%>').innerText
                document.getElementById('<%=lblOptionsModTotal.ClientID%>').innerText = document.getElementById('<%=ar_options1.ClientID%>').innerText
                document.getElementById('<%=lblFeeModTotal.ClientID%>').innerText = document.getElementById('<%=ar_fees1.ClientID%>').innerText
                document.getElementById('<%=lblTaxModTotal.ClientID%>').innerText = document.getElementById('<%=ar_tax1.ClientID%>').innerText
                document.getElementById('<%=lblTotalModTotal.ClientID%>').innerText = document.getElementById('<%=ar_total1.ClientID%>').innerText
            } //End Package Prem
            if (type == "Standard") //Show Package Values
            {

                //Program Details
                document.getElementById('<%=lblDwellModTotal_cov.ClientID%>').innerText = document.getElementById('<%=txtcvgamt.ClientID%>').value;
                document.getElementById('<%=lblUnAttModTotal_cov.ClientID%>').innerText = document.getElementById('<%=txt_unattstr_AR2.ClientID%>').value;
                document.getElementById('<%=lblPerPropModTotal_cov.ClientID%>').innerText = document.getElementById('<%=txt_pp_AR2.ClientID%>').value;

                e = document.getElementById('<%=dd_pl_AR2.ClientID%>');
                document.getElementById('<%=lblPerLiabModTotal_cov.ClientID%>').innerText = e.options[e.selectedIndex].text;
                document.getElementById('<%=lblMedPayModTotal_cov.ClientID%>').innerText = "$500";

                e = document.getElementById('<%=dd_rep_AR2.ClientID%>');
                document.getElementById('<%=lblPPRepModTotal_cov.ClientID%>').innerText = e.options[e.selectedIndex].text;

                e = document.getElementById('<%=dd_mhr_AR2.ClientID%>');
                document.getElementById('<%=lblMHRepModTotal_cov.ClientID%>').innerText = e.options[e.selectedIndex].text;

                document.getElementById('<%=lblPremModTotal.ClientID%>').innerText = document.getElementById('<%=ar_baseprem2.ClientID%>').innerText
                document.getElementById('<%=lblOptionsModTotal.ClientID%>').innerText = document.getElementById('<%=ar_options2.ClientID%>').innerText
                document.getElementById('<%=lblFeeModTotal.ClientID%>').innerText = document.getElementById('<%=ar_fees2.ClientID%>').innerText
                document.getElementById('<%=lblTaxModTotal.ClientID%>').innerText = document.getElementById('<%=ar_tax2.ClientID%>').innerText
                document.getElementById('<%=lblTotalModTotal.ClientID%>').innerText = document.getElementById('<%=ar_total2.ClientID%>').innerText
            } //End Standard Prem
            if (type == "Rental") //Show Package Values
            {

                //Program Details
                document.getElementById('<%=lblDwellModTotal_cov.ClientID%>').innerText = document.getElementById('<%=txtcvgamt.ClientID%>').value;
                document.getElementById('<%=lblUnAttModTotal_cov.ClientID%>').innerText = document.getElementById('<%=txt_unattstr_AR3.ClientID%>').value;
                document.getElementById('<%=lblPerPropModTotal_cov.ClientID%>').innerText = document.getElementById('<%=txt_pp_AR3.ClientID%>').value;

                e = document.getElementById('<%=dd_pl_AR3.ClientID%>');
                document.getElementById('<%=lblPerLiabModTotal_cov.ClientID%>').innerText = e.options[e.selectedIndex].text;
                document.getElementById('<%=lblMedPayModTotal_cov.ClientID%>').innerText = "$500";

                document.getElementById('<%=lblPremModTotal.ClientID%>').innerText = document.getElementById('<%=ar_baseprem3.ClientID%>').innerText
                document.getElementById('<%=lblOptionsModTotal.ClientID%>').innerText = document.getElementById('<%=ar_options3.ClientID%>').innerText
                document.getElementById('<%=lblFeeModTotal.ClientID%>').innerText = document.getElementById('<%=ar_fees3.ClientID%>').innerText
                document.getElementById('<%=lblTaxModTotal.ClientID%>').innerText = document.getElementById('<%=ar_tax3.ClientID%>').innerText
                document.getElementById('<%=lblTotalModTotal.ClientID%>').innerText = document.getElementById('<%=ar_total3.ClientID%>').innerText
            } //End Rental Prem
            $find('PremTotalModal').show();

        } //End openAROptions
        function openCalcDesc(section) {

            if (section == 1) {

                document.getElementById('<%=AR1_Debug.ClientID%>').style.display = '';
                document.getElementById('<%=AR2_Debug.ClientID%>').style.display = 'none';
                document.getElementById('<%=AR3_Debug.ClientID%>').style.display = 'none';

            }
            if (section == 2) {

                document.getElementById('<%=AR2_Debug.ClientID%>').style.display = '';
                document.getElementById('<%=AR1_Debug.ClientID%>').style.display = 'none';
                document.getElementById('<%=AR3_Debug.ClientID%>').style.display = 'none';

            }
            if (section == 3) {
                document.getElementById('<%=AR3_Debug.ClientID%>').style.display = '';
                document.getElementById('<%=AR1_Debug.ClientID%>').style.display = 'none';
                document.getElementById('<%=AR2_Debug.ClientID%>').style.display = 'none';

            }
            $find('PremCalcModal').show();
        } //End openAROptions
        function AR_UpdateOptions() {
     
            //window.status = "Refreshing Premium Data"
            //document.getElementById('<%=ar_premiumbtn.ClientID%>').click();
            //Set ar1 add res hidden
            if (document.getElementById('<%= AR_AddResOpt1_ar1.ClientID %>').style.display == '') {
                document.getElementById('<%= AR_AddResOpt1_HIDDEN.ClientID %>').value = 'visible';
            } else {
                document.getElementById('<%= AR_AddResOpt1_HIDDEN.ClientID %>').value = 'hidden';
            }
            
            //Set ar 1 WaterCraft
            if (document.getElementById('<%= AR_WaterCraftOpt1_ar1.ClientID %>').style.display == '') {
                document.getElementById('<%= AR_AddResOpt2_HIDDEN.ClientID %>').value = 'visible';
            } else {
                document.getElementById('<%= AR_AddResOpt2_HIDDEN.ClientID %>').value = 'hidden';
            }

            //Set ar2 add res hidden
            if (document.getElementById('<%= AR_AddResOpt1_ar2.ClientID %>').style.display == '') {
                document.getElementById('<%= AR_AddResOpt1_ar2_HIDDEN.ClientID %>').value = 'visible';
            } else {
                document.getElementById('<%= AR_AddResOpt1_ar2_HIDDEN.ClientID %>').value = 'hidden';
            }
            //Set ar 2 WaterCraft
            if (document.getElementById('<%= AR_WaterCraftOpt1_ar2.ClientID %>').style.display == '') {
                document.getElementById('<%= AR_AddResOpt2_ar2_HIDDEN.ClientID %>').value = 'visible';
            } else {
                document.getElementById('<%= AR_AddResOpt2_ar2_HIDDEN.ClientID %>').value = 'hidden';
            }

            document.getElementById('<%=txt_unattstr_AR1.ClientID%>').value = document.getElementById('<%=txt_unattstr_AR1.ClientID%>').value;
            document.getElementById('<%=txt_pp_AR1.ClientID%>').value = document.getElementById('<%=txt_pp_AR1.ClientID%>').value;
            document.getElementById('<%=txt_addlimrad_AR1.ClientID%>').value = document.getElementById('<%=txt_addlimrad_AR1.ClientID%>').value;
            document.getElementById('<%=txt_addlimfir_AR1.ClientID%>').value = document.getElementById('<%=txt_addlimfir_AR1.ClientID%>').value;

            document.getElementById('<%=txt_unattstr_AR2.ClientID%>').value = document.getElementById('<%=txt_unattstr_AR2.ClientID%>').value;
            document.getElementById('<%=txt_pp_AR2.ClientID%>').value = document.getElementById('<%=txt_pp_AR2.ClientID%>').value;
            document.getElementById('<%=txt_addlimrad_AR2.ClientID%>').value = document.getElementById('<%=txt_addlimrad_AR2.ClientID%>').value;
            document.getElementById('<%=txt_addlimfir_AR2.ClientID%>').value = document.getElementById('<%=txt_addlimfir_AR2.ClientID%>').value;

            document.getElementById('<%=ar1_updateOptions.ClientID%>').style.display = '';
            document.getElementById('<%=ar2_updateOptions.ClientID%>').style.display = '';
            document.getElementById('<%=ar3_updateOptions.ClientID%>').style.display = '';
           
            var e = document.getElementById('<%=dd_PackagePerProp_AR1.ClientID%>');
            var currentSelection = e.options[e.selectedIndex].text;
            
            if (currentSelection == "Yes") {
                //Show
                //first option section

                document.getElementById('<%=trvalPPl.ClientID%>').style.display = '';
            }
            else {

                document.getElementById('<%=trvalPPl.ClientID%>').style.display = 'none';
            }

            var e2 = document.getElementById('<%=dd_PackagePerProp_AR2.ClientID%>');
            var currentSelection2 = e2.options[e2.selectedIndex].text;

            if (currentSelection2 == "Yes") {
                //Show
                //first option section

                document.getElementById('<%=vpplAR2.ClientID%>').style.display = '';
            }
            else {

                document.getElementById('<%=vpplAR2.ClientID%>').style.display = 'none';
            }


        }
        //set personal property
       
        function ARShowPackageWaterCraft() {
            var e = document.getElementById('<%=dd_waterCraft_AR1.ClientID%>');
            var currentSelection = e.options[e.selectedIndex].text;
            if (currentSelection == "") {
                document.getElementById('<%= AR_WaterCraftOpt1_ar1.ClientID %>').style.display = 'none';
                document.getElementById('<%= AR_WaterCraftOpt2_ar1.ClientID %>').style.display = 'none';
            }
            else {
                document.getElementById('<%= AR_WaterCraftOpt1_ar1.ClientID %>').style.display = '';
                document.getElementById('<%= AR_WaterCraftOpt2_ar1.ClientID %>').style.display = '';
            }
            AR_UpdateOptions();
        } // end ARShowPackageWaterCraft
        function ARShowPackageMedPay() {
            var e = document.getElementById('<%=dd_addresOpt_ar1.ClientID%>');
            var currentSelection = e.options[e.selectedIndex].text;
            if (currentSelection == "") {
                document.getElementById('<%=AR_AddResOpt1_ar1.ClientID%>').style.display = 'none';
                document.getElementById('<%=AR_AddResOpt2_ar1.ClientID%>').style.display = 'none';
            }
            else {
                document.getElementById('<%=AR_AddResOpt1_ar1.ClientID%>').style.display = '';
                document.getElementById('<%=AR_AddResOpt2_ar1.ClientID%>').style.display = '';
            }
            AR_UpdateOptions();
        } // end ARShowPackageMedPay

        function ARShowPackageWaterCraft2() {
            var e = document.getElementById('<%=dd_waterCraft_AR2.ClientID%>');
            var currentSelection = e.options[e.selectedIndex].text;
            if (currentSelection == "") {
                document.getElementById('<%= AR_WaterCraftOpt1_ar2.ClientID %>').style.display = 'none';
                document.getElementById('<%= AR_WaterCraftOpt2_ar2.ClientID %>').style.display = 'none';
            }
            else {
                document.getElementById('<%= AR_WaterCraftOpt1_ar2.ClientID %>').style.display = '';
                document.getElementById('<%= AR_WaterCraftOpt2_ar2.ClientID %>').style.display = '';
            }
            AR_UpdateOptions();
        } // end ARShowPackageWaterCraft
        function ARShowPackageMedPay2() {
            var e = document.getElementById('<%=dd_addresOpt_ar2.ClientID%>');
            var currentSelection = e.options[e.selectedIndex].text;
            if (currentSelection == "") {
                document.getElementById('<%=AR_AddResOpt1_ar2.ClientID%>').style.display = 'none';
                document.getElementById('<%=AR_AddResOpt2_ar2.ClientID%>').style.display = 'none';
            }
            else {
                document.getElementById('<%=AR_AddResOpt1_ar2.ClientID%>').style.display = '';
                document.getElementById('<%=AR_AddResOpt2_ar2.ClientID%>').style.display = '';
            }
            AR_UpdateOptions();
        } // end ARShowPackageMedPay

        function ARShowStandardMedPay() {
//            var e = document.getElementById('<%=dd_pl_AR2.ClientID%>');
//            var e2 = document.getElementById('<%=dd_mp_AR2.ClientID%>');
//            var currentSelection = e.options[e.selectedIndex].text;
//            if (currentSelection == "$0") {
//                document.getElementById('AR_StandardMedPay').style.display = 'none';
//                e2.options[e2.selectedIndex].text = "$0";
//                
//            }
//            else {

//                document.getElementById('AR_StandardMedPay').style.display = '';
//                e2.options[e2.selectedIndex].text = "$500";
//               

//            }
            //Update options
            AR_UpdateOptions();
        }
        function AROptionsShow(section) {
            if (section == 1) {
                if (document.getElementById('lblARShowOptions1').innerText == "+ Show Options") {

                    //document.getElementById('').style.display = '';
                    document.getElementById('<%= ar_mh_prog1_Options.ClientID %>').style.display = '';
                    document.getElementById('<%= AROptionRow1.ClientID %>').style.display = '';
                    document.getElementById('<%= lblARShowOptions1_hidden.ClientID %>').value = '- Show Options';
                    document.getElementById('lblARShowOptions1').innerText = "- Show Options";

                }
                else {
                    //document.getElementById('AROptionRow1').style.display = 'none';
                    document.getElementById('<%= ar_mh_prog1_Options.ClientID %>').style.display = 'none';
                    document.getElementById('<%= AROptionRow1.ClientID %>').style.display = 'none';
                    document.getElementById('<%= lblARShowOptions1_hidden.ClientID %>').value = '+ Show Options';
                    document.getElementById('lblARShowOptions1').innerText = "+ Show Options";

                }
            }
            if (section == 2) {

                if (document.getElementById('lblARShowOptions2').innerText == "+ Show Options") {
                    document.getElementById('<%= ar_mh_prog2_Options.ClientID %>').style.display = '';
                    document.getElementById('<%= AROptionRow2.ClientID %>').style.display = '';
                    document.getElementById('lblARShowOptions2').innerText = "- Show Options";
                    document.getElementById('<%= lblARShowOptions2_hidden.ClientID %>').value = '- Show Options';
                }
                else {

                    document.getElementById('<%= ar_mh_prog2_Options.ClientID %>').style.display = 'none';
                    document.getElementById('<%= AROptionRow2.ClientID %>').style.display = 'none';
                    document.getElementById('lblARShowOptions2').innerText = "+ Show Options";
                    document.getElementById('<%= lblARShowOptions2_hidden.ClientID %>').value = '+ Show Options';
                }
            }
            if (section == 3) {
                if (document.getElementById('lblARShowOptions3').innerText == "+ Show Options") {
                    document.getElementById('AROptionRow3').style.display = '';
                    document.getElementById('lblARShowOptions3').innerText = "- Show Options";
                    document.getElementById('<%= lblARShowOptions3_hidden.ClientID %>').value = '- Show Options';

                }
                else {
                    document.getElementById('AROptionRow3').style.display = 'none';
                    document.getElementById('lblARShowOptions3').innerText = "+ Show Options";
                    document.getElementById('<%= lblARShowOptions3_hidden.ClientID %>').value = '+ Show Options';

                }
            }



        }
        function ARCalcTotals() {
            var Total = 0;
            //Package Total
            var ar_baseprem1 = document.getElementById('<%=ar_baseprem1.ClientID%>').innerHTML;
            var ar_options1 = document.getElementById('<%=ar_options1.ClientID%>').innerHTML;
            var ar_fees1 = document.getElementById('<%=ar_fees1.ClientID%>').innerHTML;
            var ar_tax1 = document.getElementById('<%=ar_tax1.ClientID%>').innerHTML;
            var ar_medpay1 = document.getElementById('<%=ar_medpay1.ClientID%>').innerHTML;
            ar_baseprem1 = ar_baseprem1.replace('$', '').replace(',', '');
            ar_options1 = ar_options1.replace('$', '').replace(',', '');
            ar_fees1 = ar_fees1.replace('$', '').replace(',', '');
            ar_tax1 = ar_tax1.replace('$', '').replace(',', '');
            Total = parseFloat(ar_baseprem1);
            if (ar_medpay1 == "$1000"){
              ar_medpay1 = 6;      
            }
            else {
            ar_medpay1 = 0;
            }
            Total += parseFloat(ar_options1) + parseFloat(ar_fees1) + parseFloat(ar_tax1) + parseFloat(ar_medpay1);
            document.getElementById('<%=ar_total1.ClientID%>').innerHTML = '$' + Total.toFixed(2);
            //alert('ar1 ' + Total);
            Total = 0;
            //Standard Total
            var ar_baseprem2 = document.getElementById('<%=ar_baseprem2.ClientID%>').innerHTML;
            var ar_options2 = document.getElementById('<%=ar_options2.ClientID%>').innerHTML;
            var ar_fees2 = document.getElementById('<%=ar_fees2.ClientID%>').innerHTML;
            var ar_tax2 = document.getElementById('<%=ar_tax2.ClientID%>').innerHTML;
            var ar_medpay2 = document.getElementById('<%=ar_medpay2.ClientID%>').innerHTML;
            ar_baseprem2 = ar_baseprem2.replace('$', '').replace(',', '');
            ar_options2 = ar_options2.replace('$', '').replace(',', '');
            ar_fees2 = ar_fees2.replace('$', '').replace(',', '');
            ar_tax2 = ar_tax2.replace('$', '').replace(',', '');
             if (ar_medpay2 == "$1000"){
              ar_medpay2 = 6;      
            }
            else {
            ar_medpay2 = 0;
            }
            Total = parseFloat(ar_baseprem2);
            Total += parseFloat(ar_options2) + parseFloat(ar_fees2) + parseFloat(ar_tax2);
            document.getElementById('<%=ar_total2.ClientID%>').innerHTML = '$' + Total.toFixed(2);
            //alert('ar2 ' + Total);
            Total = 0;
            //Rental Total
            var ar_baseprem3 = document.getElementById('<%=ar_baseprem3.ClientID%>').innerHTML;
            var ar_options3 = document.getElementById('<%=ar_options3.ClientID%>').innerHTML;
            var ar_fees3 = document.getElementById('<%=ar_fees3.ClientID%>').innerHTML;
            var ar_tax3 = document.getElementById('<%=ar_tax3.ClientID%>').innerHTML;
             var ar_medpay3 = document.getElementById('<%=ar_medpay3.ClientID%>').innerHTML;
            ar_baseprem3 = ar_baseprem3.replace('$', '').replace(',', '');
            ar_options3 = ar_options3.replace('$', '').replace(',', '');
            ar_fees3 = ar_fees3.replace('$', '').replace(',', '');
            ar_tax3 = ar_tax3.replace('$', '').replace(',', '');
            Total = parseFloat(ar_baseprem3);
            if (ar_medpay3 == "$1000"){
              ar_medpay3 = 6;      
            }
            else 
            {
            ar_medpay3 = 0;
            }
            Total += parseFloat(ar_options3) + parseFloat(ar_fees3) + parseFloat(ar_tax3) + parseFloat(ar_medpay3);
            document.getElementById('<%=ar_total3.ClientID%>').innerHTML = '$' + Total.toFixed(2);

        }
        function ARHideShowQuestions() {

            //            var e = document.getElementById('<%=mhparkdd.ClientID%>');
            //            var currentSelection = e.options[e.selectedIndex].text;
            //            if (currentSelection == "Yes") {

            //                document.getElementById('trmhqstn1').style.display = '';
            //                document.getElementById('trmhqstn2').style.display = '';
            //                document.getElementById('trmhqstn3').style.display = '';
            //                document.getElementById('trmhqstn4').style.display = '';
            //            }
            //            else {

            //                document.getElementById('trmhqstn1').style.display = 'none';
            //                document.getElementById('trmhqstn2').style.display = 'none';
            //                document.getElementById('trmhqstn3').style.display = 'none';
            //                document.getElementById('trmhqstn4').style.display = 'none';
            //            }
        } //end ARHideShowQuestions
        function ARIsLienHolder() {
            var e = document.getElementById('<%=liendd.ClientID%>');
            var currentSelection = e.options[e.selectedIndex].text;
            if (currentSelection == "Yes") {
                //Show
                //first option section

                document.getElementById('<%=trmhAROpt1.ClientID%>').style.display = '';
                document.getElementById('<%=trmhAROpt1_d.ClientID%>').style.display = '';
                document.getElementById('<%=trmhAROpt1_2.ClientID%>').style.display = '';
                document.getElementById('<%=trmhAROpt1_2_d.ClientID%>').style.display = '';
               
                //second option section
                document.getElementById('<%=trmhAROpt2.ClientID%>').style.display = '';
                document.getElementById('<%=trmhAROpt2_2.ClientID%>').style.display = '';
                document.getElementById('<%=trmhAROpt2_d.ClientID%>').style.display = '';
                document.getElementById('<%=trmhAROpt2_2_d.ClientID%>').style.display = '';
                //third option section
                document.getElementById('<%=trmhAROpt3.ClientID%>').style.display = '';
                document.getElementById('<%=trmhAROpt3_2.ClientID%>').style.display = '';
                document.getElementById('<%=trmhAROpt3_d.ClientID%>').style.display = '';
                document.getElementById('<%=trmhAROpt3_2_d.ClientID%>').style.display = '';



            }
            else {
                //Hide
                //first option section
                document.getElementById('<%=trmhAROpt1.ClientID%>').style.display = 'none';
                document.getElementById('<%=trmhAROpt1_d.ClientID%>').style.display = 'none';
                document.getElementById('<%=trmhAROpt1_2.ClientID%>').style.display = 'none';
                document.getElementById('<%=trmhAROpt1_2_d.ClientID%>').style.display = 'none';
                //second option section
                document.getElementById('<%=trmhAROpt2.ClientID%>').style.display = 'none';
                document.getElementById('<%=trmhAROpt2_2.ClientID%>').style.display = 'none';
                document.getElementById('<%=trmhAROpt2_d.ClientID%>').style.display = 'none';
                document.getElementById('<%=trmhAROpt2_2_d.ClientID%>').style.display = 'none';
                //third option section
                document.getElementById('<%=trmhAROpt3.ClientID%>').style.display = 'none';
                document.getElementById('<%=trmhAROpt3_2.ClientID%>').style.display = 'none';
                document.getElementById('<%=trmhAROpt3_d.ClientID%>').style.display = 'none';
                document.getElementById('<%=trmhAROpt3_2_d.ClientID%>').style.display = 'none';

            }
        } //end ARIsLienHolder
        function ARsupHeating() {
            var e = document.getElementById('<%=supheatdd.ClientID%>');

            var currentSelection = e.options[e.selectedIndex].text;
            if (currentSelection == "Yes") {
                //Show

                document.getElementById('trmhqstn5').style.display = '';
            }
            else {
                //Hide
                document.getElementById('trmhqstn5').style.display = 'none';
            }
        } //End ARsupHeating
        function ARSkirting() {
            var e = document.getElementById('<%=skirtdd.ClientID%>');
            var currentSelection = e.options[e.selectedIndex].text;
            if (currentSelection == "None") {
                //Hide
                document.getElementById('<%=ARFLtbl.ClientID%>').style.display = 'none';
            }
            else {
                //Show
                document.getElementById('<%=ARFLtbl.ClientID%>').style.display = '';

            }
        } //end ARSkirting

        //END AR
        //****************************************************************************************

        //****************************************************************************************
        //GENERAL
        //ON LOAD HIDE SECTIONS
        function hideDefaults() {
            document.getElementById('<%= ar_mh_prog1.ClientID %>').style.display = 'none';
            document.getElementById('<%= ar_mh_prog1_Options.ClientID %>').style.display = 'none';
            document.getElementById('<%= ar_mh_prog2.ClientID %>').style.display = 'none';
            document.getElementById('<%= ar_mh_prog2_Options.ClientID %>').style.display = 'none';
            document.getElementById('<%= AROptionRow1.ClientID %>').style.display = 'none';
            document.getElementById('<%= AROptionRow2.ClientID %>').style.display = 'none';
            //            

        }


        //Redirect sections
        function redirect() {
            window.location.href = "/Quote/quote.aspx";
        }
        function redirect2() {
            window.location.href = "/Quote/findQuote.aspx";
        }
        //Common functions
        function formatCurrency(num) {
            num = isNaN(num) || num === '' || num === null ? 0.00 : num;
            return parseFloat(num).toFixed(2);
        }
        function ShowPriorLossbtn() {
            var e = document.getElementById('<%=priorlosdd.ClientID%>');

            var currentSelection = e.options[e.selectedIndex].text;
            if (currentSelection == "Yes") {
                document.getElementById('<%=modalShowbtn.ClientID%>').style.display = '';
            }
            else {
                document.getElementById('<%=modalShowbtn.ClientID%>').style.display = 'none';
            }


        } // End ShowPriorLossbtn
        function PriorLossModal() {
            var e = document.getElementById('<%=priorlosdd.ClientID%>');

            var currentSelection = e.options[e.selectedIndex].text;
            if (currentSelection == "Yes") {
                $find('lossModal').show();


            }
        } //End PriorLossModal
        //END GENERAL
        //****************************************************************************************

        //****************************************************************************************
        //VALIDATE
        //Valuation Calculation
        function calcValuation() {

            var e = document.getElementById('<%=manfdd.ClientID%>');
            var curManf = e.options[e.selectedIndex].text;

            if (document.getElementById('<%=lblState.ClientID%>').value == "") {
                return;
            }
            if (document.getElementById('<%=txtWidth.ClientID%>').value == "") {
                return;
            }
            if (document.getElementById('<%=txtLength.ClientID%>').value == "") {
                return;
            }
            if (document.getElementById('<%=txtYear.ClientID%>').value == "") {
                return;
            }
            if (curManf == "") {
                return;
            }
            document.getElementById('<%=calcValue.ClientID%>').click();
        }

        //Update DOB format
        function UpdateDOB() {

            var currentText;
            currentText = document.getElementById('<%=txtDOB.ClientID%>').value;

            if (currentText.length == 7) {

                document.getElementById('<%=txtDOB.ClientID%>').value = currentText.substring(0, 2) + '/' + currentText.substring(2, 4) + '/' + currentText.substring(4, 8);

            } //end if

        }
        function UpdateeffDate() {

            var currentText;
            currentText = document.getElementById('<%=txtDOB.ClientID%>').value;

            if (currentText.length == 7) {

                document.getElementById('<%=txtDOB.ClientID%>').value = currentText.substring(0, 2) + '/' + currentText.substring(2, 4) + '/' + currentText.substring(4, 8);

            } //end if

        }
        //Update prior loss 1 format
        function UpdatePL1() {

            var currentText;
            currentText = document.getElementById('<%=txtLoss1Date.ClientID%>').value;

            if (currentText.length == 7) {

                document.getElementById('<%=txtLoss1Date.ClientID%>').value = currentText.substring(0, 2) + '/' + currentText.substring(2, 4) + '/' + currentText.substring(4, 8);

            } //end if

        }
        //Update prior loss 2 format
        function UpdatePL2() {

            var currentText;
            currentText = document.getElementById('<%=txtLoss2Date.ClientID%>').value;

            if (currentText.length == 7) {

                document.getElementById('<%=txtLoss2Date.ClientID%>').value = currentText.substring(0, 2) + '/' + currentText.substring(2, 4) + '/' + currentText.substring(4, 8);

            } //end if

        }
        //Update prior loss 3 format
        function UpdatePL3() {

            var currentText;
            currentText = document.getElementById('<%=txtLoss3Date.ClientID%>').value;

            if (currentText.length == 7) {

                document.getElementById('<%=txtLoss3Date.ClientID%>').value = currentText.substring(0, 2) + '/' + currentText.substring(2, 4) + '/' + currentText.substring(4, 8);

            } //end if

        }
        //MH Replacement Cost Validation
        function MHValidate() {

            if (document.getElementById('<%=txtYear.ClientID%>').value.length == 4) {
                var MyDate = new Date();
                var year = document.getElementById('<%=txtYear.ClientID%>').value;
                var CurrYear = MyDate.getFullYear();
                var HomeAge = CurrYear - year;
                var CHK = document.getElementById("<%=optcbl.ClientID%>");
                var checkbox = CHK.getElementsByTagName("input");
                var label = CHK.getElementsByTagName("label");
                for (var i = 0; i < checkbox.length; i++) {
                    if (label[i].innerHTML == 'MH Replacement Cost (0 - 10 years)') {
                        if (HomeAge > 10) {
                            label[i].style.display = "none";
                            checkbox[i].style.display = "none";
                        } else {
                            label[i].style.display = "";
                            checkbox[i].style.display = "";
                        }

                    }
                } //end for loop
            } //end length if
            
        } //end MHValidate
        //Check Owner Type
        function OnhomeUseDDSelectedIndexChange() {
            var e = document.getElementById('<%=homeusedd.ClientID%>');
            var currentSelection = e.options[e.selectedIndex].text;
            Hide_Show_Ar(currentSelection);

            //*************************************************************************
            //LLoyds
            if (currentSelection == "Owner" || currentSelection == "Seasonal" || currentSelection == "") {
                //hide premises
                document.getElementById('<%=Lloyds_PremLiab.ClientID%>').innerHTML = "0.00";
                document.getElementById('<%=Lloyds_PremLiab.ClientID%>').style.visibility = "hidden";
                document.getElementById('<%=LlyodsPremLiabdd.ClientID%>').style.visibility = "hidden";
                document.getElementById('<%=Label44.ClientID%>').style.visibility = "hidden";
                //show & load personal
                OnLlyodsLiabddSelectedIndexChange();
                document.getElementById('<%=Label40.ClientID%>').style.visibility = "visible";
                document.getElementById('<%=Lloyds_PerLiab.ClientID%>').style.visibility = "visible";
                document.getElementById('<%=LlyodsLiabdd.ClientID%>').style.visibility = "visible";

            }
            else {
                //hide personal
                document.getElementById('<%=Lloyds_PerLiab.ClientID%>').innerHTML = "0.00"
                document.getElementById('<%=Lloyds_PerLiab.ClientID%>').style.visibility = "hidden";
                document.getElementById('<%=LlyodsLiabdd.ClientID%>').style.visibility = "hidden";
                document.getElementById('<%=Label40.ClientID%>').style.visibility = "hidden";
                //show & load                
                OnLlyodsPremLiabddSelectedIndexChange();
                document.getElementById('<%=Lloyds_PremLiab.ClientID%>').style.visibility = "visible";
                document.getElementById('<%=LlyodsPremLiabdd.ClientID%>').style.visibility = "visible";
                document.getElementById('<%=Label44.ClientID%>').style.visibility = "visible";
            }

        } //End OnhomeUseDDSelectedIndexChange

        //Check Dist to Coast
        function OndistToCoastDDSelectedIndexChange() {
            var e = document.getElementById('<%=distToCoastDD.ClientID%>');
            var currentSelection = e.options[e.selectedIndex].text;
            if (currentSelection == "Less than 2 miles" || currentSelection == "Less than 0.5 miles") {
                document.getElementById('<%=llydstbl.ClientID%>').style.visibility = "hidden";
            }
            else {
                document.getElementById('<%=llydstbl.ClientID%>').style.visibility = "visible";
            }

            if (currentSelection == "2 – 5 miles" || currentSelection == "0.5 – 5 miles") {
                document.getElementById('<%=whtxt.ClientID%>').value = '$1,500';

            }
            else {

                document.getElementById('<%=whtxt.ClientID%>').value = '$1,000';
            }

        } //End OndistToCoastDDSelectedIndexChange


        //END VALIDATE
        //****************************************************************************************



        //*******************************************
        //Key Press events
        //*******************************************
        function subKeyDown() {
            if (document.getElementById('<%=txtSubNumber.ClientID%>').value.length == 4) {
                document.getElementById('<%=txtSubNumber.ClientID%>').value = document.getElementById('<%=txtSubNumber.ClientID%>').value;
                document.getElementById('<%=subBtn.ClientID%>').click();
            }
            document.getElementById('<%=txtSubNumber.ClientID%>').value = document.getElementById('<%=txtSubNumber.ClientID%>').value;
        }
        //Sub lookup drop down change
        function OnddlSub_mainSelectedIndexChange() {
            document.getElementById('<%=subBtn2.ClientID%>').click();

        }
        function zipcodeKeyDown() {
            if (document.getElementById('<%=txtZip.ClientID%>').value.length == 5) {
                document.getElementById('<%=txtZip.ClientID%>').value = document.getElementById('<%=txtZip.ClientID%>').value;
                document.getElementById('<%=zipbtn2.ClientID%>').click();
            }
            document.getElementById('<%=txtZip.ClientID%>').value = document.getElementById('<%=txtZip.ClientID%>').value;
        }
        //*******************************************
        //End Key Press events
        //*******************************************


        //**********************************************
        //Lloyds
        //**********************************************
        function LloydsOptionsShow() {

            if (document.getElementById('lblShowlloydsOptions').innerText == "+ Show Options") {
                document.getElementById('LloydsOptionRow').style.display = '';
                document.getElementById('lblShowlloydsOptions').innerText = "- Show Options";

            }
            else {
                document.getElementById('LloydsOptionRow').style.display = 'none';
                document.getElementById('lblShowlloydsOptions').innerText = "+ Show Options";

            }
        }
        function OnLlyodsPremLiabddSelectedIndexChange() {
            document.getElementById('<%=Lloyds_PremLiab.ClientID%>').innerHTML = '0.00';
            var e2 = document.getElementById('<%=LlyodsPremLiabdd.ClientID %>');
            var currentSelection2 = e2.options[e2.selectedIndex].value;


            if (currentSelection2 == "$25,000") {
                document.getElementById('<%=Lloyds_PremLiab.ClientID%>').innerHTML = document.getElementById('<%=PREMLIAB25.ClientID%>').innerHTML;
            }
            if (currentSelection2 == "$50,000") {
                document.getElementById('<%=Lloyds_PremLiab.ClientID%>').innerHTML = document.getElementById('<%=PREMLIAB50.ClientID%>').innerHTML;
            }
            if (currentSelection2 == "$100,000") {
                document.getElementById('<%=Lloyds_PremLiab.ClientID%>').innerHTML = document.getElementById('<%=PREMLIAB100.ClientID%>').innerHTML;
            }

            calcLloydsTotals();
            return false;
        } //End OnLlyodsPremLiabddSelectedIndexChange

        function OnLlyodsLiabddSelectedIndexChange() {
            document.getElementById('<%=Lloyds_PerLiab.ClientID%>').innerHTML = '0.00';
            var e = document.getElementById('<%=LlyodsLiabdd.ClientID%>');
            var currentSelection = e.options[e.selectedIndex].text;
            if (currentSelection == "$25,000") {
                document.getElementById('<%=Lloyds_PerLiab.ClientID%>').innerHTML = document.getElementById('<%=PERLIAB25.ClientID%>').innerHTML;
            }
            if (currentSelection == "$50,000") {
                document.getElementById('<%=Lloyds_PerLiab.ClientID%>').innerHTML = document.getElementById('<%=PERLIAB50.ClientID%>').innerHTML;
            }
            if (currentSelection == "$100,000") {
                document.getElementById('<%=Lloyds_PerLiab.ClientID%>').innerHTML = document.getElementById('<%=PERLIAB100.ClientID%>').innerHTML;
            }
            if (currentSelection == "$300,000") {
                document.getElementById('<%=Lloyds_PerLiab.ClientID%>').innerHTML = document.getElementById('<%=PERLIAB300.ClientID%>').innerHTML;
            }
            calcLloydsTotals();
            return false;
        } //End OnLlyodsLiabddSelectedIndexChange



        function UpdateLloydsFeesOptionalCoverages() {
            document.getElementById('<%=Lloyds_PERep.ClientID%>').innerHTML = '0.00';
            document.getElementById('<%=Lloyds_FullRep.ClientID%>').innerHTML = '0.00';
            document.getElementById('<%=Lloyds_MHRepCost.ClientID%>').innerHTML = '0.00';
            //Get Home Type
            var e = document.getElementById('<%=typedd.ClientID%>');
            var currentSelection = e.options[e.selectedIndex].text;

            var CHK = document.getElementById("<%=optcbl.ClientID%>");
            var checkbox = CHK.getElementsByTagName("input");
            var label = CHK.getElementsByTagName("label");
            for (var i = 0; i < checkbox.length; i++) {
                if (checkbox[i].checked) {
                    if (label[i].innerHTML == 'PE Replacement Cost') {
                        document.getElementById('<%=Lloyds_PERep.ClientID%>').innerHTML = document.getElementById('<%=PEREPCOST.ClientID%>').innerHTML;
                    }
                    if (label[i].innerHTML == 'Full Repair') {
                        document.getElementById('<%=Lloyds_FullRep.ClientID%>').innerHTML = document.getElementById('<%=FULLREPAIR.ClientID%>').innerHTML;
                    }
                    if (label[i].innerHTML == 'MH Replacement Cost (0 - 10 years)') {
                        document.getElementById('<%=Lloyds_MHRepCost.ClientID%>').innerHTML = document.getElementById('<%=MHREPCOST.ClientID%>').innerHTML;

                    }

                } //end checkbox is checked
            } //end for loop
            calcLloydsTotals();
            return false;
        } //UpdateLloydsFeesOptionalCoverages

        //Calculate AAS
        function calcLloydsAAS() {

            var e = document.getElementById('<%=typedd.ClientID%>');
            var currentSelection = e.options[e.selectedIndex].text;
            var AAS = document.getElementById('<%=txtAAS.ClientID%>').value;
            var sw = document.getElementById('<%=OPCOVPESINGLE.ClientID%>').innerHTML
            var db = document.getElementById('<%=OPCOVPEDOUBLE.ClientID%>').innerHTML
            AAS = AAS.replace('$', '').replace(',', '');
            sw = sw.replace('$', '').replace(',', '');
            db = db.replace('$', '').replace(',', '');


            if (currentSelection = 'Singlewide')//singlewide
            {

                document.getElementById('<%=Lloyds_AAS.ClientID%>').innerHTML = formatCurrency(sw * (parseFloat(AAS) / 100));


            }
            else//doublewide
            {
                document.getElementById('<%=Lloyds_AAS.ClientID%>').innerHTML = formatCurrency(db * (parseFloat(AAS) / 100));
            }


            calcLloydsTotals();
        }
        //Calculate APE
        function calcLloydsAPE() {
            var e = document.getElementById('<%=typedd.ClientID%>');
            var currentSelection = e.options[e.selectedIndex].text;
            var APE = document.getElementById('<%=txtAPE.ClientID%>').value;
            var sw = document.getElementById('<%=OPCOVPESINGLE.ClientID%>').innerHTML
            var db = document.getElementById('<%=OPCOVPEDOUBLE.ClientID%>').innerHTML
            APE = APE.replace('$', '').replace(',', '');
            sw = sw.replace('$', '').replace(',', '');
            db = db.replace('$', '').replace(',', '');
            if (currentSelection = 'Singlewide')//singlewide        
            {
                document.getElementById('<%=Lloyds_APE.ClientID%>').innerHTML = formatCurrency(sw * (parseFloat(APE) / 100));

            }
            else//doublewide
            {
                document.getElementById('<%=Lloyds_APE.ClientID%>').innerHTML = formatCurrency(db * (parseFloat(APE) / 100));
            }


            calcLloydsTotals();
        }
        function calcLloydsTotals() {
            var Dwell = document.getElementById('<%=Lloyds_Dwell.ClientID%>').innerHTML;
            var PerLiab = document.getElementById('<%=Lloyds_PerLiab.ClientID%>').innerHTML;
            var PremLiab = document.getElementById('<%=Lloyds_PremLiab.ClientID%>').innerHTML;
            var APE = document.getElementById('<%=Lloyds_APE.ClientID%>').innerHTML;
            var AAS = document.getElementById('<%=Lloyds_AAS.ClientID%>').innerHTML;
            var PERep = document.getElementById('<%=Lloyds_PERep.ClientID%>').innerHTML;
            var FullRep = document.getElementById('<%=Lloyds_FullRep.ClientID%>').innerHTML;
            var A100Ded = document.getElementById('<%=Lloyds_100Ded.ClientID%>').innerHTML;
            var MHRepCost = document.getElementById('<%=Lloyds_MHRepCost.ClientID%>').innerHTML;
            var Credits = document.getElementById('<%=Lloyds_Credits.ClientID%>').innerHTML;


            Dwell = Dwell.replace('$', '').replace(',', '');
            PerLiab = PerLiab.replace('$', '').replace(',', '');
            PremLiab = PremLiab.replace('$', '').replace(',', '');
            AAS = AAS.replace('$', '').replace(',', '');
            APE = APE.replace('$', '').replace(',', '');
            PERep = PERep.replace('$', '').replace(',', '');
            FullRep = FullRep.replace('$', '').replace(',', '');
            A100Ded = A100Ded.replace('$', '').replace(',', '');
            MHRepCost = MHRepCost.replace('$', '').replace(',', '');
            Credits = Credits.replace('$', '').replace(',', '').replace(')', '').replace('(', '');
            A100Ded = A100Ded.replace('$', '').replace(',', '').replace(')', '').replace('(', '');

            var Total = parseFloat(Dwell) + parseFloat(PerLiab) + parseFloat(PremLiab) + parseFloat(AAS) + parseFloat(APE) + parseFloat(PERep) + parseFloat(FullRep) + parseFloat(MHRepCost);
            Total = Total - A100Ded
            Total = Total - Credits
            document.getElementById('<%=Lloyds_Total.ClientID%>').innerHTML = '$' + Total.toFixed(2);

        }
        //**********************************************
        //END Lloyds
        //**********************************************

    
   
    
    
   
   



function ar_mh_progbtn1_onclick() {

}

function btnShow_onclick() {

}

function btnShow_onclick() {

}

    </script>
    <!--Menu Bar-->
    <table cellpadding="0" cellspacing="0">
        <tr align="left">
            <td>
                <button style="-webkit-appearance: none; top: 0px; left: 0px; width: 100px; height: 30px;
                    border: 1px solid #808080;" onclick="redirect(); return false;">
                    New Quote
                </button>
                <button style="-webkit-appearance: none; top: 0px; left: -15px; width: 100px; height: 30px;
                    border: 1px solid #808080;" onclick="redirect2(); return false;">
                    Find Quote
                </button>
                <asp:Button ID="savebtn" runat="server" OnClick="savebtn_Click" Style="-webkit-appearance: none;
                    top: 0px; left: -15px; width: 100px; height: 30px; border: 1px solid #808080;"
                    Text="Save" />
                <asp:Button ID="btnLogout" runat="server" Style="top: 0px; left: -15px; width: 100px;
                    height: 30px; border: 1px solid #808080;" Text="Logout" OnClick="btnLogout_Click"
                    CausesValidation="true" />
            </td>
        </tr>
    </table>
    <!--Menu Bar-->
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <ajaxTK:ToolkitScriptManager ID="sc2" runat="server" EnablePartialRendering="true">
    </ajaxTK:ToolkitScriptManager>
    <div>
        <!--Header information-->
        <table width="100%" cellpadding="0" cellspacing="0" style="table-layout: fixed;"
            bgcolor="white">
            <tbody>
                <tr align="left">
                    <td valign="top" style="padding: 5px">
                        <div class="leftside">
                            <asp:Label ID="Label1" runat="server" Text="Quote #" />
                            <asp:Label ID="lblquoteNumber" runat="server" />
                            <br />
                            <asp:Label ID="Label3" runat="server" Text="Type:" />
                            <asp:Label ID="Label4" runat="server" Casing="Normal" />
                            &nbsp;&nbsp;&nbsp;&nbsp;
                            <asp:Label ID="Label5" runat="server" Text="Status:" />
                            <asp:Label ID="Label7" runat="server" />
                        </div>
                    </td>
                </tr>
            </tbody>
        </table>
        <!--END Header information-->
        <table width="100%" cellpadding="0" cellspacing="0" style="table-layout: fixed;"
            bgcolor="white">
            <tbody>
                <tr>
                    <td style="width: 50%;" valign="top">
                        <!--LEFT-->
                        <!--POLICY INFORMATION-->
                        <table>
                            <tbody>
                                <tr>
                                    <td class="headerCell">
                                        <asp:Label ID="Label37" runat="server" CssClass="c2bLabel-header" Text="Policy Information" />
                                    </td>
                                </tr>
                            </tbody>
                        </table>
                        <table>
                            <tbody>
                                <tr align="left">
                                    <td>
                                        <asp:Label ID="Label101" runat="server" Text="Term   " CssClass="label" />
                                    </td>
                                    <td align="left">
                                        <asp:DropDownList ID="termdd" runat="server" alt="Term" TabIndex="0">
                                            <asp:ListItem>12</asp:ListItem>
                                        </asp:DropDownList>
                                    </td>
                                </tr>
                                <tr>
                                    <td align="left">
                                        <asp:Label ID="Label6" runat="server" Text="Agency" CssClass="label" />
                                    </td>
                                    <td>
                                        <asp:Label ID="lblAgency" runat="server" Text="Agency #" Style="font-family: Tahoma;
                                            font-size: 10pt; text-align: left;" />
                                    </td>
                                </tr>
                                <tr>
                                    <td colspan="2">
                                        <asp:UpdatePanel ID="SubUpdatepanel1" runat="server" UpdateMode="Conditional">
                                            <ContentTemplate>
                                                <table>
                                                    <tbody>
                                                        <tr>
                                                            <td align="left">
                                                                <asp:Label ID="Label8" runat="server" Text="Sub Number" CssClass="label" alt="Sub Number" />
                                                            </td>
                                                            <td align="left">
                                                                <asp:TextBox style="text-transform:uppercase" ID="txtSubNumber" runat="server" AutoCompleteType="DisplayName" Casing="UPPER"
                                                                    alt="Sub Number" ToolTip="Sub Number" Width="180px" TabIndex="1" AutoPostBack="false"
                                                                    ClientIDMode="Static" />
                                                                <br />
                                                                <asp:DropDownList ID="ddlSub_main" runat="server" AutoPostBack="false" Visible="false"
                                                                    ClientIDMode="Static">
                                                                </asp:DropDownList>
                                                                <br />
                                                                <asp:Label ID="txtsubNumber_results" runat="server" Text="No results found." Visible="false"
                                                                    ClientIDMode="Static" />
                                                                <asp:Button ID="subBtn" Text="getZip" runat="server" CausesValidation="false" Style="display: none" />
                                                                <asp:Button ID="subBtn2" Text="getZip" runat="server" CausesValidation="false" Style="display: none" />
                                                            </td>
                                                        </tr>
                                                        <tr>
                                                            <td align="left">
                                                                <asp:Label ID="Label9" runat="server" Text="Agency Contact Name" CssClass="label"
                                                                    alt="Agent Name" />
                                                            </td>
                                                            <td align="left">
                                                                <asp:TextBox style="text-transform:uppercase" ID="txtAgConName" runat="server" AutoCompleteType="DisplayName" Casing="UPPER"
                                                                    ToolTip="Sub Number" Width="180px" TabIndex="2" />
                                                                <ajaxTK:TextBoxWatermarkExtender ID="TextBoxWatermarkExtender1" runat="server" Enabled="True"
                                                                    TargetControlID="txtAgConName" WatermarkCssClass="WatermarkCssClass" WatermarkText="agency contact name" />
                                                            </td>
                                                        </tr>
                                                        <tr>
                                                            <td align="left">
                                                                <asp:Label ID="Label11" runat="server" Text="Agency Contact Email" CssClass="label" />
                                                            </td>
                                                            <td align="left">
                                                                <asp:TextBox style="text-transform:uppercase" ID="txtConEmail" runat="server" AutoCompleteType="DisplayName" Casing="UPPER"
                                                                    ToolTip="Sub Number" Width="180px" TabIndex="3" />
                                                                <ajaxTK:TextBoxWatermarkExtender ID="TextBoxWatermarkExtender2" runat="server" Enabled="True"
                                                                    TargetControlID="txtConEmail" WatermarkCssClass="WatermarkCssClass" WatermarkText="agency contact email" />
                                                            </td>
                                                        </tr>
                                                    </tbody>
                                                </table>
                                            </ContentTemplate>
                                            <Triggers>
                                                <asp:AsyncPostBackTrigger ControlID="subBtn" EventName="Click" />
                                            </Triggers>
                                        </asp:UpdatePanel>
                                    </td>
                                </tr>
                                <tr>
                                    <td align="left">
                                        <asp:Label ID="Label10" runat="server" Text="Effective Date" CssClass="label" />
                                    </td>
                                    <td align="left">
                                        <asp:TextBox ID="txtEffDate" runat="server" AutoCompleteType="DisplayName" Casing="UPPER"
                                            ToolTip="Effective Date" Width="100px" TabIndex="4" />
                                        <ajaxTK:CalendarExtender ID="txtEffectiveDate_CalendarExtender" runat="server" Enabled="True"
                                            PopupButtonID="btnCalEffectiveDate" TargetControlID="txtEffDate" />
                                        <asp:ImageButton ID="btnCalEffectiveDate" runat="server" ImageUrl="~/images/Calendar.png"
                                            TabIndex="-1" CausesValidation="false" />
                                        <ajaxTK:TextBoxWatermarkExtender ID="TextBoxWatermarkExtender10" runat="server" Enabled="True"
                                            TargetControlID="txtEffDate" WatermarkCssClass="WatermarkCssClass" WatermarkText="mm/dd/yyyy" />
                                    </td>
                                </tr>
                                <tr>
                                    <td align="left">
                                        <asp:Label ID="Label13" runat="server" Text="Applicant First Name" CssClass="label" />
                                    </td>
                                    <td align="left">
                                        <asp:TextBox style="text-transform:uppercase" ID="txtAppFirstName" runat="server" AutoCompleteType="DisplayName" Casing="UPPER"
                                            ToolTip="First Name" Width="200px" TabIndex="5" />
                                        <ajaxTK:TextBoxWatermarkExtender ID="TextBoxWatermarkExtender5" runat="server" Enabled="True"
                                            TargetControlID="txtAppFirstName" WatermarkCssClass="WatermarkCssClass" WatermarkText="First Name" />
                                        <asp:RequiredFieldValidator ID="RequiredFieldValidator6" ControlToValidate="txtAppFirstName"
                                            runat="server" Text="* Req Field"></asp:RequiredFieldValidator>
                                    </td>
                                </tr>
                                <tr>
                                    <td align="left">
                                        <asp:Label ID="Label66" runat="server" Text="Applicant Last Name" CssClass="label" />
                                    </td>
                                    <td>
                                        <asp:TextBox style="text-transform:uppercase" ID="txtAppLastName" runat="server" AutoCompleteType="DisplayName" Casing="UPPER"
                                            ToolTip="Last Name" Width="200px" TabIndex="5" />
                                        <ajaxTK:TextBoxWatermarkExtender ID="TextBoxWatermarkExtender13" runat="server" Enabled="True"
                                            TargetControlID="txtAppLastName" WatermarkCssClass="WatermarkCssClass" WatermarkText="Last Name" />
                                        <asp:RequiredFieldValidator ID="RequiredFieldValidator29" ControlToValidate="txtAppLastName"
                                            runat="server" Text="* Req Field"></asp:RequiredFieldValidator>
                                    </td>
                                </tr>
                                <tr>
                                    <td align="left">
                                        <asp:Label ID="Label14" runat="server" Text="Applicant Email" CssClass="label" />
                                    </td>
                                    <td align="left">
                                        <asp:TextBox style="text-transform:uppercase" ID="txtAppEmail" runat="server" AutoCompleteType="DisplayName" Casing="UPPER"
                                            ToolTip="Email" Width="200px" TabIndex="6" />
                                        <ajaxTK:TextBoxWatermarkExtender ID="TextBoxWatermarkExtender4" runat="server" Enabled="True"
                                            TargetControlID="txtAppEmail" WatermarkCssClass="WatermarkCssClass" WatermarkText="email" />
                                    </td>
                                </tr>
                                <tr>
                                    <td align="left">
                                        <asp:Label ID="Label21" runat="server" Text="Applicant DOB" CssClass="label" />
                                    </td>
                                    <td align="left">
                                        <asp:TextBox ID="txtDOB" runat="server" AutoCompleteType="DisplayName" Casing="UPPER"
                                            ToolTip="Sub Number" Width="100px" TabIndex="7" />
                                        <ajaxTK:CalendarExtender ID="CalendarExtender1" runat="server" Enabled="True" PopupButtonID="btnCalDOB"
                                            TargetControlID="txtDOB" />
                                        <asp:ImageButton ID="btnCalDOB" runat="server" ImageUrl="~/images/Calendar.png" TabIndex="-1"
                                            CausesValidation="false" />
                                        <asp:RequiredFieldValidator ID="RequiredFieldValidator8" ControlToValidate="txtDOB"
                                            runat="server" Text="* Req Field"></asp:RequiredFieldValidator>
                                    </td>
                                </tr>
                                <tr>
                                    <td align="left">
                                        <asp:Label ID="Label15" runat="server" Text="Property Address" CssClass="label" />
                                    </td>
                                    <td align="left">
                                        <asp:TextBox style="text-transform:uppercase" ID="txtAppAddr" runat="server" AutoCompleteType="DisplayName" Casing="UPPER"
                                            ToolTip="Address" Width="200px" TabIndex="8" />
                                        <ajaxTK:TextBoxWatermarkExtender ID="TextBoxWatermarkExtender12" runat="server" Enabled="True"
                                            TargetControlID="txtAppAddr" WatermarkCssClass="WatermarkCssClass" WatermarkText="address" />
                                        <asp:RequiredFieldValidator ID="RequiredFieldValidator9" ControlToValidate="txtAppAddr"
                                            runat="server" Text="* Req Field"></asp:RequiredFieldValidator>
                                    </td>
                                </tr>
                                <tr>
                                    <td colspan="2">
                                        <!-- ZIP UPDATE PANEL-->
                                        <%--<asp:UpdateProgress ID="UpdateProgress_ModalUpdatePanel" runat="server" AssociatedUpdatePanelID="updateZipPanel" >
                                    <ProgressTemplate>
            
                                            <asp:Panel ID="UpdateProgress_ModalUpdatePanel_updatepanelimage" runat="server" BackColor="Transparent"
                                            Height="150px" Width="150px" HorizontalAlign="Center"  ScrollBars="None" >
                                            <center>
                                             <img src="../images/ajax-loader.gif" alt="" Backcolor="Transparent" />
                                            
                                                Loading Zip</center>
                                            </asp:Panel>
                       
                                   </ProgressTemplate>
                                </asp:UpdateProgress>--%>
                                        <asp:UpdatePanel ID="updateZipPanel" runat="server" UpdateMode="Conditional">
                                            <ContentTemplate>
                                                <table width="105%">
                                                    <tbody>
                                                        <tr>
                                                            <td align="left">
                                                                <asp:Label ID="Label16" runat="server" Text="Zip" CssClass="label" />
                                                            </td>
                                                            <td align="left">
                                                                <asp:TextBox ID="txtZip" runat="server" AutoCompleteType="DisplayName" Casing="UPPER"
                                                                    ToolTip="Zip Code" Width="55px" AutoPostBack="true" TabIndex="8" />
                                                                <!--onchange="zipcodeKeyDown();  return false;" -->
                                                                <asp:Button ID="zipbtn2" Text="getZip" runat="server" CausesValidation="false" Style="display: none" />
                                                            </td>
                                                        </tr>
                                                        <tr>
                                                            <td align="left">
                                                                <asp:Label ID="Label19" runat="server" Text="City:" CssClass="label" />
                                                            </td>
                                                            <td align="left">
                                                                <asp:DropDownList ID="cddlCity" runat="server" TabIndex="9">
                                                                </asp:DropDownList>
                                                                <asp:Label ID="Label20" runat="server" Text="State:" CssClass="label" />
                                                                &nbsp;&nbsp;
                                                                <asp:Label ID="lblState" runat="server" Font-Bold="True" Font-Size="Small" Width="25px" />
                                                            </td>
                                                        </tr>
                                                        <tr>
                                                            <td align="left">
                                                                <asp:Label ID="Label22" runat="server" Text="County:" CssClass="label" />
                                                            </td>
                                                            <td align="left">
                                                                <asp:TextBox style="text-transform:uppercase" ID="txtCounty" runat="server" AutoCompleteType="DisplayName" Casing="UPPER"
                                                                    ToolTip="Zip Code" Width="100" />
                                                            </td>
                                                        </tr>
                                                    </tbody>
                                                </table>
                                            </ContentTemplate>
                                            <Triggers>
                                                <asp:AsyncPostBackTrigger ControlID="zipbtn2" EventName="Click" />
                                            </Triggers>
                                        </asp:UpdatePanel>
                                    </td>
                                </tr>
                                <!-- END ZIP UPDATE PANEL-->
                            </tbody>
                        </table>
                        <!-- END POLICY INFORMATION-->
                    </td>
                    <!--MIDDLE-->
                    <td style="width: 10px;">
                        &nbsp;
                    </td>
                    <td valign="top">
                        <!--RIGHT-->
                        <!--PROPERTY INFORMATION-->
                        <table>
                            <tbody>
                                <tr>
                                    <td class="headerCell">
                                        <asp:Label ID="Label38" runat="server" CssClass="c2bLabel-header" Text="Property Information" />
                                    </td>
                                </tr>
                            </tbody>
                        </table>
                        <table>
                            <tbody>
                                <tr>
                                    <td colspan="2">
                                        <asp:UpdatePanel ID="DistToCoastUpdatepanel" runat="server" UpdateMode="Conditional">
                                            <ContentTemplate>
                                                <table width="105%">
                                                    <tbody>
                                                        <tr>
                                                            <td align="left">
                                                                <asp:Label ID="Label17" runat="server" Text="Distance To Coast" CssClass="label"
                                                                    ClientIDMode="Static" />
                                                            </td>
                                                            <td align="left">
                                                                <asp:DropDownList ID="distToCoastDD" runat="server" TabIndex="10" ClientIDMode="Static">
                                                                    <asp:ListItem></asp:ListItem>
                                                                    <asp:ListItem>Less than 2 miles</asp:ListItem>
                                                                    <asp:ListItem>2 – 5 miles</asp:ListItem>
                                                                    <asp:ListItem>5 – 15 miles</asp:ListItem>
                                                                    <asp:ListItem>Greater than 15 miles</asp:ListItem>
                                                                </asp:DropDownList>
                                                        </tr>
                                                    </tbody>
                                                </table>
                                            </ContentTemplate>
                                        </asp:UpdatePanel>
                                    </td>
                                </tr>
                                <tr>
                                    <td align="left">
                                        <asp:Label ID="Label23" runat="server" Text="Home Use" CssClass="label" />
                                    </td>
                                    <td align="left">
                                        <asp:DropDownList ID="homeusedd" runat="server" TabIndex="11">
                                            <asp:ListItem></asp:ListItem>
                                            <asp:ListItem>Owner</asp:ListItem>
                                            <asp:ListItem>Seasonal</asp:ListItem>
                                            <asp:ListItem>Rental</asp:ListItem>
                                            <asp:ListItem>Tenant</asp:ListItem>
                                            <asp:ListItem>Vacant</asp:ListItem>
                                        </asp:DropDownList>
                                        <asp:RequiredFieldValidator ID="RequiredFieldValidator11" ControlToValidate="homeusedd"
                                            runat="server" Text="* Req Field"></asp:RequiredFieldValidator>
                                    </td>
                                </tr>
                                <tr>
                                    <td align="left">
                                        <asp:Label ID="Label24" runat="server" Text="Home Type" CssClass="label" />
                                    </td>
                                    <td align="left">
                                        <asp:DropDownList ID="typedd" runat="server" TabIndex="12">
                                            <asp:ListItem></asp:ListItem>
                                            <asp:ListItem>Singlewide</asp:ListItem>
                                            <asp:ListItem>Doublewide</asp:ListItem>
                                            <asp:ListItem>Modular</asp:ListItem>
                                        </asp:DropDownList>
                                        <asp:RequiredFieldValidator ID="RequiredFieldValidator12" ControlToValidate="typedd"
                                            runat="server" Text="* Req Field"></asp:RequiredFieldValidator>
                                    </td>
                                </tr>
                                <tr>
                                    <td colspan="2">
                                        <asp:UpdatePanel ID="updateValuationPanel" runat="server" UpdateMode="Conditional">
                                            <ContentTemplate>
                                                <table width="100%">
                                                    <tbody>
                                                        <tr>
                                                            <td align="left">
                                                                <asp:Label ID="Label25" runat="server" Text="Year" CssClass="label" />
                                                            </td>
                                                            <td align="left">
                                                                <asp:TextBox ID="txtYear" runat="server" AutoCompleteType="DisplayName" Casing="UPPER"
                                                                    CausesValidation="false" ToolTip="year" Width="45" TabIndex="13" />
                                                                <ajaxTK:TextBoxWatermarkExtender ID="TextBoxWatermarkExtender6" runat="server" Enabled="True"
                                                                    TargetControlID="txtYear" WatermarkCssClass="WatermarkCssClass" WatermarkText="YYYY" />
                                                                <asp:RequiredFieldValidator ID="RequiredFieldValidator13" ControlToValidate="txtYear"
                                                                    runat="server" Text="* Req Field"></asp:RequiredFieldValidator>
                                                            </td>
                                                        </tr>
                                                        <tr>
                                                            <td align="left">
                                                                <asp:Label ID="Label26" runat="server" Text="Length" CssClass="label" />
                                                            </td>
                                                            <td align="left">
                                                                <asp:TextBox style="text-transform:uppercase" ID="txtLength" runat="server" AutoCompleteType="DisplayName" Casing="UPPER"
                                                                    CausesValidation="false" ToolTip="length" Width="45" TabIndex="14" />
                                                                <ajaxTK:TextBoxWatermarkExtender ID="TextBoxWatermarkExtender7" runat="server" Enabled="True"
                                                                    TargetControlID="txtLength" WatermarkCssClass="WatermarkCssClass" WatermarkText="Length" />
                                                                <asp:RequiredFieldValidator ID="RequiredFieldValidator14" ControlToValidate="txtLength"
                                                                    runat="server" Text="* Req Field"></asp:RequiredFieldValidator>
                                                            </td>
                                                        </tr>
                                                        <tr>
                                                            <td align="left">
                                                                <asp:Label ID="Label27" runat="server" Text="Width" CssClass="label" />
                                                            </td>
                                                            <td align="left">
                                                                <asp:TextBox style="text-transform:uppercase" ID="txtWidth" runat="server" AutoCompleteType="DisplayName" Casing="UPPER"
                                                                    CausesValidation="false" ToolTip="width" Width="45" TabIndex="15" />
                                                                <ajaxTK:TextBoxWatermarkExtender ID="TextBoxWatermarkExtender8" runat="server" Enabled="True"
                                                                    TargetControlID="txtWidth" WatermarkCssClass="WatermarkCssClass" WatermarkText="Width" />
                                                                <asp:RequiredFieldValidator ID="RequiredFieldValidator15" ControlToValidate="txtWidth"
                                                                    runat="server" Text="* Req Field"></asp:RequiredFieldValidator>
                                                            </td>
                                                        </tr>
                                                        <tr>
                                                            <td align="left">
                                                                <asp:Label ID="Label28" runat="server" Text="Manufacturer" CssClass="label" />
                                                            </td>
                                                            <td align="left">
                                                                <asp:DropDownList ID="manfdd" runat="server" TabIndex="16" CausesValidation="false">
                                                                    <asp:ListItem></asp:ListItem>
                                                                    <asp:ListItem></asp:ListItem>
                                                                </asp:DropDownList>
                                                                <asp:RequiredFieldValidator ID="RequiredFieldValidator16" ControlToValidate="manfdd"
                                                                    runat="server" Text="* Req Field"></asp:RequiredFieldValidator>
                                                            </td>
                                                        </tr>
                                                        <tr>
                                                            <td align="left">
                                                                <asp:Label ID="Label29" runat="server" Text="Valuation" CssClass="label" CausesValidation="false" />
                                                            </td>
                                                            <td align="left">
                                                                <asp:TextBox ID="txtValuation" runat="server" TabIndex="17" AutoCompleteType="DisplayName"
                                                                    Casing="UPPER" ReadOnly="true" ToolTip="Email" Width="65" />
                                                            </td>
                                                        </tr>
                                                        <asp:Button ID="calcValue" Text="GetValuation" runat="server" CausesValidation="false"
                                                            Style="display: none" />
                                                    </tbody>
                                                </table>
                                            </ContentTemplate>
                                            <Triggers>
                                                <asp:AsyncPostBackTrigger ControlID="calcValue" EventName="Click" />
                                            </Triggers>
                                        </asp:UpdatePanel>
                                    </td>
                                </tr>
                            </tbody>
                        </table>
                        <!--END PROPERTY INFORMATION-->
                        <!-- Coverages-->
                        <table>
                            <tbody>
                                <tr>
                                    <td class="headerCell">
                                        <asp:Label ID="Label36" runat="server" CssClass="c2bLabel-header" Text="Coverage Information" />
                                    </td>
                                </tr>
                            </tbody>
                        </table>
                        <table>
                            <tbody>
                                <tr>
                                    <td align="left">
                                        <asp:Label ID="Label18" runat="server" Text="Coverage Amount" CssClass="label" />
                                    </td>
                                    <td align="left">
                                        <asp:TextBox ID="txtcvgamt" runat="server" AutoCompleteType="DisplayName" Casing="UPPER"
                                            ToolTip="Coverage Amount" Width="65" TabIndex="18" />
                                        <asp:RequiredFieldValidator ID="RequiredFieldValidator24" ControlToValidate="txtcvgamt"
                                            runat="server" Text="* Req Field"></asp:RequiredFieldValidator>
                                    </td>
                                </tr>
                                <tr>
                                    <td align="left">
                                        <asp:Label ID="Label30" runat="server" Text="Protection Class" CssClass="label" />
                                    </td>
                                    <td align="left">
                                        <asp:DropDownList ID="protclassdd" runat="server" TabIndex="19">
                                            <asp:ListItem></asp:ListItem>
                                            <asp:ListItem>1</asp:ListItem>
                                            <asp:ListItem>2</asp:ListItem>
                                            <asp:ListItem>3</asp:ListItem>
                                            <asp:ListItem>4</asp:ListItem>
                                            <asp:ListItem>5</asp:ListItem>
                                            <asp:ListItem>6</asp:ListItem>
                                            <asp:ListItem>7</asp:ListItem>
                                            <asp:ListItem>8</asp:ListItem>
                                            <asp:ListItem>9</asp:ListItem>
                                            <asp:ListItem>10</asp:ListItem>
                                        </asp:DropDownList>
                                        <asp:RequiredFieldValidator ID="RequiredFieldValidator18" ControlToValidate="protclassdd"
                                            runat="server" Text="* Req Field"></asp:RequiredFieldValidator>
                                    </td>
                                </tr>
                                <tr>
                                    <td align="left">
                                        <asp:Label ID="Label31" runat="server" Text="Skirting" CssClass="label" />
                                    </td>
                                    <td align="left">
                                        <asp:DropDownList ID="skirtdd" runat="server" TabIndex="20">
                                            <asp:ListItem></asp:ListItem>
                                            <asp:ListItem>Vinyl</asp:ListItem>
                                            <asp:ListItem>Brick</asp:ListItem>
                                            <asp:ListItem>Block</asp:ListItem>
                                            <asp:ListItem>None</asp:ListItem>
                                        </asp:DropDownList>
                                        <asp:RequiredFieldValidator ID="RequiredFieldValidator19" ControlToValidate="skirtdd"
                                            runat="server" Text="* Req Field"></asp:RequiredFieldValidator>
                                    </td>
                                </tr>
                                <tr>
                                    <td align="left">
                                        <asp:Label ID="Label32" runat="server" Text="Lienholder" CssClass="label" />
                                    </td>
                                    <td align="left">
                                        <asp:DropDownList ID="liendd" runat="server" TabIndex="21">
                                            <asp:ListItem></asp:ListItem>
                                            <asp:ListItem>Yes</asp:ListItem>
                                            <asp:ListItem>No</asp:ListItem>
                                        </asp:DropDownList>
                                        <asp:RequiredFieldValidator ID="RequiredFieldValidator20" ControlToValidate="liendd"
                                            runat="server" Text="* Req Field"></asp:RequiredFieldValidator>
                                    </td>
                                </tr>
                                <tr>
                                    <td align="left">
                                        <asp:Label ID="Label43" runat="server" Text="Lapse in Coverage" CssClass="label" />
                                    </td>
                                    <td align="left">
                                        <asp:DropDownList ID="lapsdd" runat="server" TabIndex="22">
                                            <asp:ListItem></asp:ListItem>
                                            <asp:ListItem>Yes</asp:ListItem>
                                            <asp:ListItem>No</asp:ListItem>
                                        </asp:DropDownList>
                                        <asp:RequiredFieldValidator ID="RequiredFieldValidator7" ControlToValidate="lapsdd"
                                            runat="server" Text="* Req Field"></asp:RequiredFieldValidator>
                                    </td>
                                </tr>
                                <tr>
                                    <td align="left">
                                        <asp:Label ID="Label33" runat="server" Text="Supplemental Heating" CssClass="label" />
                                    </td>
                                    <td align="left">
                                        <asp:DropDownList ID="supheatdd" runat="server" TabIndex="23">
                                            <asp:ListItem></asp:ListItem>
                                            <asp:ListItem>Yes</asp:ListItem>
                                            <asp:ListItem>No</asp:ListItem>
                                        </asp:DropDownList>
                                        <asp:RequiredFieldValidator ID="RequiredFieldValidator21" ControlToValidate="supheatdd"
                                            runat="server" Text="* Req Field"></asp:RequiredFieldValidator>
                                    </td>
                                </tr>
                                <tr id="trmhqstn5" style="display: none">
                                    <td align="left">
                                        <asp:Label ID="Label62" runat="server" Text="Heating Type" CssClass="label" />
                                    </td>
                                    <td align="left">
                                        <asp:DropDownList ID="supHeatTypedd" runat="server" TabIndex="24" Width="150">
                                            <asp:ListItem> </asp:ListItem>
                                            <asp:ListItem>Woodstove installed by a licensed contractor</asp:ListItem>
                                            <asp:ListItem>Woodstove installed by someone other than a licensed contractor</asp:ListItem>
                                            <asp:ListItem>Fireplace installed by the manufacturer or licensed contractor</asp:ListItem>
                                            <asp:ListItem>Fireplace installed by someone other than the manufacturer or a licensed contractor</asp:ListItem>
                                            <asp:ListItem>Kerosene Heater</asp:ListItem>
                                            <asp:ListItem>Portable Space Heater</asp:ListItem>
                                            <asp:ListItem>Heat reclaiming device</asp:ListItem>
                                            <asp:ListItem>Homemade heating device</asp:ListItem>
                                        </asp:DropDownList>
                                    </td>
                                </tr>
                                <tr>
                                    <td align="left">
                                        <asp:Label ID="Label34" runat="server" Text="Prior Losses (within 5 years)" CssClass="label" />
                                    </td>
                                    <ajaxTK:ModalPopupExtender ID="PriorLosses_ModalPopupExtender" runat="server" BehaviorID="lossModal"
                                        TargetControlID="modalShowbtn" BackgroundCssClass="modalBackground" CancelControlID="btnClosePriorLosses"
                                        DropShadow="True" DynamicServicePath="" Enabled="True" PopupControlID="pnlPriorLosses"
                                        RepositionMode="RepositionOnWindowScroll" />
                                    <td align="left">
                                        <asp:DropDownList ID="priorlosdd" runat="server" TabIndex="25">
                                            <asp:ListItem></asp:ListItem>
                                            <asp:ListItem>Yes</asp:ListItem>
                                            <asp:ListItem>No</asp:ListItem>
                                        </asp:DropDownList>
                                        &nbsp;&nbsp;
                                        <asp:Button ID="modalShowbtn" runat="server" Text="Prior Losses" Style="display: none"
                                            OnClientClick="PriorLossModal();" />
                                    </td>
                                </tr>
                                <tr>
                                    <td align="left">
                                        <asp:Label ID="Label110" runat="server" Text="Is the Home located in a Mobile Home Park </br> or subdivision  with 15 or more occupied spaces?"
                                            CssClass="label" />
                                    </td>
                                    <td align="left">
                                        <asp:DropDownList ID="mhparkdd" runat="server" TabIndex="26">
                                            <asp:ListItem></asp:ListItem>
                                            <asp:ListItem>Yes</asp:ListItem>
                                            <asp:ListItem>No</asp:ListItem>
                                        </asp:DropDownList>
                                    </td>
                                </tr>
                                <tr>
                                    <td align="left">
                                        <asp:Label ID="Label166" runat="server" Text="ANSI/ASCE 7/88:"
                                            CssClass="label" />
                                    </td>
                                    <td align="left">
                                        <asp:DropDownList ID="ddansi" runat="server" TabIndex="26">
                                            <asp:ListItem></asp:ListItem>
                                            <asp:ListItem>Yes</asp:ListItem>
                                            <asp:ListItem>No</asp:ListItem>
                                        </asp:DropDownList>
                                    </td>
                                </tr>
                                <tr id="trmhqstn1" style="display: none">
                                    <td align="left">
                                        <asp:Label ID="Label111" runat="server" Text="Is there a full time resident Manager?"
                                            CssClass="label" />
                                    </td>
                                    <td align="left">
                                        <asp:DropDownList ID="mhResMangdd" runat="server" TabIndex="27">
                                            <asp:ListItem></asp:ListItem>
                                            <asp:ListItem>Yes</asp:ListItem>
                                            <asp:ListItem>No</asp:ListItem>
                                        </asp:DropDownList>
                                    </td>
                                </tr>
                                <tr id="trmhqstn2" style="display: none">
                                    <td align="left">
                                        <asp:Label ID="Label112" runat="server" Text="Are there 100 or more occupied spaces in the Park?"
                                            CssClass="label" />
                                    </td>
                                    <td align="left">
                                        <asp:DropDownList ID="mhSpacdd" runat="server" TabIndex="28">
                                            <asp:ListItem></asp:ListItem>
                                            <asp:ListItem>Yes</asp:ListItem>
                                            <asp:ListItem>No</asp:ListItem>
                                        </asp:DropDownList>
                                    </td>
                                </tr>
                                <tr id="trmhqstn3" style="display: none">
                                    <td align="left">
                                        <asp:Label ID="Label113" runat="server" Text="Does the Park have paved and lighted streets?"
                                            CssClass="label" />
                                    </td>
                                    <td align="left">
                                        <asp:DropDownList ID="mhlightdd" runat="server" TabIndex="29">
                                            <asp:ListItem></asp:ListItem>
                                            <asp:ListItem>Yes</asp:ListItem>
                                            <asp:ListItem>No</asp:ListItem>
                                        </asp:DropDownList>
                                    </td>
                                </tr>
                                <tr id="trmhqstn4" style="display: none">
                                    <td align="left">
                                        <asp:Label ID="Label114" runat="server" Text="Is the insured 50 years of age or older <br/> and occupy the Mobile Home at least 6 consecutive months each year?"
                                            CssClass="label" />
                                    </td>
                                    <td align="left">
                                        <asp:DropDownList ID="mhInsAge" runat="server" TabIndex="30">
                                            <asp:ListItem></asp:ListItem>
                                            <asp:ListItem>Yes</asp:ListItem>
                                            <asp:ListItem>No</asp:ListItem>
                                        </asp:DropDownList>
                                    </td>
                                </tr>
                                <tr>
                                    <td id="popupanchor" align="left">
                                        <asp:Button ID="prmbtn" runat="server" Text="Calculate Premium" TabIndex="31" OnClick="calc_Clicked" />
                                        <dx:ASPxPopupControl ID="ASPxPopupControl1" runat="server">
                                        <ContentCollection>
                                        <dx:PopupControlContentControl runat="server" SupportsDisabledAttribute="True">
                                            <asp:Label ID="Label173" runat="server" Text="Label"></asp:Label>
                                                                                        </dx:PopupControlContentControl>
                                        </ContentCollection>
                                        </dx:ASPxPopupControl>
                                    </td>
                                    <td>
                                    </td>
                                </tr>
                            </tbody>
                        </table>
                        <!--END Coverages-->
                    </td>
                </tr>
            </tbody>
        </table>
        <!--Premium Total Modal Popup -->
        <ajaxTK:ModalPopupExtender ID="ModalPopupExtender1" runat="server" BehaviorID="PremTotalModal"
            TargetControlID="PremModbtn" BackgroundCssClass="modalBackground" CancelControlID="PremConfCancel"
            DropShadow="True" DynamicServicePath="" Enabled="True" PopupControlID="PremiumCheckerPanel"
            RepositionMode="RepositionOnWindowScroll" />
            <asp:Button ID="PremModbtn" runat="server" Style="display: none" CausesValidation="false"
            Text="Proceed to App" />
        
        <!--Premium Total Modal Popup -->
        <ajaxTK:ModalPopupExtender ID="ModalPopupExtender2" runat="server" BehaviorID="PremCalcModal"
            TargetControlID="btnClosePremCalc" BackgroundCssClass="modalBackground" CancelControlID="btnCloseCalc"
            DropShadow="True" DynamicServicePath="" Enabled="True" PopupControlID="PremiumCalcPanel"
            RepositionMode="RepositionOnWindowScroll" />
        <asp:Button ID="btnClosePremCalc" runat="server" Style="display: none" CausesValidation="false"
            Text="Close" />
        <span id="Span1" runat="server" visible="true">
            <!-- PREMIUM INFORMATION -->
            <table width="100%" cellpadding="0" cellspacing="0" style="table-layout: fixed; display: none;"
                bgcolor="white">
                <tbody>
                    <!--Policy Header-->
                    <tr>
                        <td class="headerCell">
                            <asp:Label ID="Label59" runat="server" CssClass="c2bLabel-header" Text="Policy Information" />
                        </td>
                        <td class="headerCell">
                            <asp:Label ID="Label60" runat="server" CssClass="c2bLabel-header" Text=" " />
                        </td>
                    </tr>
                    <!--END Policy Header-->
                </tbody>
        </table>
            <!-- PREMIUM INFORMATION -->
            <!-- LLYODS INFORMATION -->
            <table id="llydstbl" runat="server" width="100%" cellpadding="0" cellspacing="0"
                style="table-layout: fixed; display: none;" bgcolor="white">
                <tbody>
                    <tr>
                        <td>
                            <table width="100%" cellpadding="0" cellspacing="0" style="table-layout: fixed;"
                                bgcolor="white">
                                <tbody>
                                    <tr>
                                        <td class="headerCell">
                                            <asp:Label ID="Label39" runat="server" CssClass="c2bLabel-header" Text="LLoyds" />
                                        </td>
                                        <td class="headerCell">
                                            <asp:Label ID="Label58" runat="server" CssClass="c2bLabel-header" Text="" />
                                        </td>
                                    </tr>
                                </tbody>
                            </table>
                        </td>
                        <td>
                        </td>
                    </tr>
                    <tr>
                        <td align="left">
                            <table width="100%" cellpadding="0" cellspacing="0" style="border: 1px solid black"
                                bgcolor="white" title="Lloyds Coverage Table">
                                <tbody>
                                    <tr style="border: 1px solid black">
                                        <td align="center">
                                            <label id="lblShowlloydsOptions" style="color: Blue; cursor: pointer;" onclick="LloydsOptionsShow();">
                                                + Show Options</label>
                                        </td>
                                        <td align="center" style="border: 1px solid black">
                                            <asp:Label ID="Label42" runat="server" Text="Dwelling Premium - " CssClass="label" />
                                        </td>
                                        <td align="center" style="border: 1px solid black">
                                            <asp:Label ID="Label45" runat="server" Text="Personal Liability - " CssClass="label" />
                                        </td>
                                        <td align="center" style="border: 1px solid black">
                                            <asp:Label ID="Label47" runat="server" Text="Premises Liability - " CssClass="label" />
                                        </td>
                                        <td align="center" style="border: 1px solid black">
                                            <asp:Label ID="Label49" runat="server" Text="Additional Other Structures - " CssClass="label" />
                                        </td>
                                        <td align="center" style="border: 1px solid black">
                                            <asp:Label ID="Label54" runat="server" Text="Additional Personal Effects - " CssClass="label" />
                                        </td>
                                        <td align="center" style="border: 1px solid black">
                                            <asp:Label ID="Label51" runat="server" Text="PE Replacement Cost - " CssClass="label" />
                                        </td>
                                        <td align="center" style="border: 1px solid black">
                                            <asp:Label ID="Label53" runat="server" Text="Full Repair - " CssClass="label" />
                                        </td>
                                        <td align="center" style="border: 1px solid black">
                                            <asp:Label ID="Label55" runat="server" Text="$1000 Deductible All other - " CssClass="label" />
                                        </td>
                                        <td align="center" style="border: 1px solid black">
                                            <asp:Label ID="Label41" runat="server" Text="MH Replacement Cost (0 - 10 years old) - "
                                                CssClass="label" />
                                        </td>
                                        <td align="center" style="border: 1px solid black">
                                            <asp:Label ID="Label48" runat="server" Text="Credits - " CssClass="label" />
                                        </td>
                                        <td align="center" style="border: 1px solid black">
                                            <asp:Label ID="Label109" runat="server" Text="Taxes - " CssClass="label" />
                                        </td>
                                        <td align="center" style="border: 1px solid black">
                                            <asp:Label ID="Label12" runat="server" Text="Total" CssClass="labelTotal" />
                                        </td>
                                    </tr>
                                    <tr>
                                        <td>
                                        </td>
                                        <td style="border: 1px solid black">
                                            <asp:Label ID="Lloyds_Dwell" runat="server" Text="0.00" CssClass="label" />
                                        </td>
                                        <td align="center" style="border: 1px solid black">
                                            <asp:Label ID="Lloyds_PerLiab" runat="server" Text="0.00" CssClass="label" />
                                        </td>
                                        <td align="center" style="border: 1px solid black">
                                            <asp:Label ID="Lloyds_PremLiab" runat="server" Text="0.00" CssClass="label" />
                                        </td>
                                        <td align="center" style="border: 1px solid black">
                                            <asp:Label ID="Lloyds_AAS" runat="server" Text="0.00" CssClass="label" />
                                        </td>
                                        <td align="center" style="border: 1px solid black">
                                            <asp:Label ID="Lloyds_APE" runat="server" Text="0.00" CssClass="label" />
                                        </td>
                                        <td align="center" style="border: 1px solid black">
                                            <asp:Label ID="Lloyds_PERep" runat="server" Text="0.00" CssClass="label" />
                                        </td>
                                        <td align="center" style="border: 1px solid black">
                                            <asp:Label ID="Lloyds_FullRep" runat="server" Text="0.00" CssClass="label" />
                                        </td>
                                        <td align="center" style="border: 1px solid black">
                                            <asp:Label ID="Lloyds_100Ded" runat="server" Text="0.00" CssClass="label" />
                                        </td>
                                        <td align="center" style="border: 1px solid black">
                                            <asp:Label ID="Lloyds_MHRepCost" runat="server" Text="0.00" CssClass="label" />
                                        </td>
                                        <td align="center" style="border: 1px solid black">
                                            <asp:Label ID="Lloyds_Credits" runat="server" Text="0.00" CssClass="label" />
                                        </td>
                                        <td align="center" style="border: 1px solid black">
                                            <asp:Label ID="Lloyds_Taxes" runat="server" Text="0.00" CssClass="label" />
                                        </td>
                                        <td align="center" style="border: 1px solid black">
                                            <asp:Label ID="Lloyds_Total" runat="server" Text="0.00" CssClass="labelTotal" />
                                        </td>
                                        <td align="left">
                                            <asp:Button ID="LloydsAppBtn" runat="server" Text="Proceed to App" OnClick="TransferToLloydsApp" />
                                        </td>
                                    </tr>
                                </tbody>
                            </table>
                        </td>
                    </tr>
                    <tr>
                        <td align="left">
                            <asp:Label ID="Label57" runat="server" Text="Optional Coverages" CssClass="label" />
                        </td>
                    </tr>
                    <tr>
                        <td>
                            <table id="LloydsOptionRow" width="Auto" cellpadding="0" cellspacing="0" bgcolor="white"
                                title="Lloyds Options" style="border: 1px solid black; display: none">
                                <tbody>
                                    <tr>
                                        <td align="center" style="border: 1px solid">
                                            <asp:Label ID="Label46" runat="server" Text="Wind/Hail</br> Deductible" CssClass="label" />
                                        </td>
                                        <td align="center" style="border: 1px solid">
                                            <asp:Label ID="Label35" runat="server" Text="AOP </br>Deductible" CssClass="label" />
                                        </td>
                                        <td align="center" style="border: 1px solid">
                                            <asp:Label ID="Label88" runat="server" Text="Options" CssClass="label" />
                                        </td>
                                        <td align="center" style="border: 1px solid">
                                            <asp:Label ID="Label50" runat="server" Text="Additional Adj </br>Structures" CssClass="label" />
                                        </td>
                                        <td align="center" style="border: 1px solid">
                                            <asp:Label ID="Label52" runat="server" Text="Additional Per</br>Effects" CssClass="label" />
                                        </td>
                                        <td align="center" style="border: 1px solid">
                                            <asp:Label ID="Label40" runat="server" Text="Personal </br>Liability" CssClass="label" />
                                        </td>
                                        <td align="center" style="border: 1px solid">
                                            <asp:Label ID="Label44" runat="server" Text="Premises </br>Liability" CssClass="label" />
                                        </td>
                                    </tr>
                                    <tr>
                                        <td align="center" style="border: 1px solid">
                                            <asp:TextBox ID="whtxt" runat="server" AutoCompleteType="DisplayName" Casing="UPPER"
                                                Text="$1,000" ToolTip="Wind/Hail Deductible" Width="65" TabIndex="23" ReadOnly="true" />
                                        </td>
                                        <td align="center" style="border: 1px solid">
                                            <asp:DropDownList ID="aopdd" runat="server" TabIndex="22">
                                                <asp:ListItem></asp:ListItem>
                                                <asp:ListItem>500</asp:ListItem>
                                                <asp:ListItem>1000</asp:ListItem>
                                            </asp:DropDownList>
                                        </td>
                                        <td align="center" style="border: 1px solid">
                                            <asp:CheckBoxList runat="server" ID="optcbl" onchange="UpdateLloydsFeesOptionalCoverages();"
                                                TextAlign="Left">
                                                <asp:ListItem>PE Replacement Cost</asp:ListItem>
                                                <asp:ListItem>Full Repair</asp:ListItem>
                                                <asp:ListItem>MH Replacement Cost (0 - 10 years)</asp:ListItem>
                                            </asp:CheckBoxList>
                                        </td>
                                        <td align="center" style="border: 1px solid">
                                            <asp:TextBox ID="txtAAS" runat="server" AutoCompleteType="DisplayName" Casing="UPPER"
                                                ToolTip="Additional Adjacent Structures" Width="65" TabIndex="30" />
                                        </td>
                                        <td align="center" style="border: 1px solid">
                                            <asp:TextBox ID="txtAPE" runat="server" AutoCompleteType="DisplayName" Casing="UPPER"
                                                ToolTip="Additional Personal Effects" Width="65" TabIndex="31" />
                                        </td>
                                        <td align="center" style="border: 1px solid">
                                            <asp:DropDownList ID="LlyodsLiabdd" runat="server">
                                                <asp:ListItem></asp:ListItem>
                                                <asp:ListItem>$25,000</asp:ListItem>
                                                <asp:ListItem>$50,000</asp:ListItem>
                                                <asp:ListItem>$100,000</asp:ListItem>
                                                <asp:ListItem>$300,000</asp:ListItem>
                                            </asp:DropDownList>
                                        </td>
                                        <td align="center" style="border: 1px solid">
                                            <asp:DropDownList ID="LlyodsPremLiabdd" runat="server">
                                                <asp:ListItem></asp:ListItem>
                                                <asp:ListItem>$25,000</asp:ListItem>
                                                <asp:ListItem>$50,000</asp:ListItem>
                                                <asp:ListItem>$100,000</asp:ListItem>
                                            </asp:DropDownList>
                                        </td>
                                    </tr>
                                    <tr>
                                        <td>
                                            <asp:Label ID="OPCOVPESINGLE" Text="0.00" runat="server" Style="display: none"></asp:Label>
                                            <asp:Label ID="OPCOVPEDOUBLE" Text="0.00" runat="server" Style="display: none"></asp:Label>
                                            <asp:Label ID="PEREPCOST" Text="0.00" runat="server" Style="display: none"></asp:Label>
                                            <asp:Label ID="FULLREPAIR" Text="0.00" runat="server" Style="display: none"></asp:Label>
                                            <asp:Label ID="PERLIAB25" Text="0.00" runat="server" Style="display: none"></asp:Label>
                                            <asp:Label ID="PERLIAB50" Text="0.00" runat="server" Style="display: none"></asp:Label>
                                            <asp:Label ID="PERLIAB100" Text="0.00" runat="server" Style="display: none"></asp:Label>
                                            <asp:Label ID="PERLIAB300" Text="0.00" runat="server" Style="display: none"></asp:Label>
                                            <asp:Label ID="PREMLIAB25" Text="0.00" runat="server" Style="display: none"></asp:Label>
                                            <asp:Label ID="PREMLIAB50" Text="0.00" runat="server" Style="display: none"></asp:Label>
                                            <asp:Label ID="PREMLIAB100" Text="0.00" runat="server" Style="display: none"></asp:Label>
                                            <asp:Label ID="DEDALLOTHER" Text="0.00" runat="server" Style="display: none"></asp:Label>
                                            <asp:Label ID="SEASSUR" Text="0.00" runat="server" Style="display: none"></asp:Label>
                                            <asp:Label ID="MHREPCOST" Text="0.00" runat="server" Style="display: none"></asp:Label>
                                        </td>
                                    </tr>
                                </tbody>
                            </table>
                        </td>
                    </tr>
                </tbody>
        </table>
            <!-- END LLYODS INFORMATION -->
            <hr />
            <!-- FL AR INFORMATION -->
            <table id="ARFLtbl" runat="server" width="100%">
                <tbody>
                    <tr>
                        <td>
                            <br />
                        </td>
                        <td>
                            <br />
                        </td>
                    </tr>
                    <tr>
                        <td>
                            <asp:UpdatePanel ID="AR_PremiumUpdatePanel" runat="server" UpdateMode="Conditional">
                                <ContentTemplate>
                                    <table id="premiumBtnTable" runat="server" style="display: none;" align="center">
                                        <tbody>
                                            <tr>
                                                <td>
                                                    <asp:Label ID="Label75" runat="server" Text="Selected Rate Type: " CssClass="label"></asp:Label>
                                                    &nbsp;
                                                    <asp:Label ID="rateTypelbl" runat="server" Text="" CssClass="label"></asp:Label>
                                                </td>
                                                <td>
                                                   
                                                    &nbsp;
                                                </td>
                                                <td>
                                                    <asp:Button ID="printbtn1" runat="server" OnClick="printbtn_Click" Text="Print Quote" />
                                                    
                                                </td>
                                                <td>
                                                    <asp:Button ID="premFinbtn" runat="server" OnClick="printFinbtn_Click" Text="Print Finance Contract" />
                                                </td>
                                                <td>
                                                <asp:Button ID="btnBeforeApp" runat="server"  CausesValidation="false" Text="Proceed to App" OnClick="btnBeforeApp_Click"/>
                                                     </td>
                                                <td>
                                                    <asp:HiddenField ID="HiddenFieldSelected" runat="server" Value="" ClientIDMode="Static"/>
                                                    <%--<input id="ar_mh_progbtn1" type="button" value="Proceed to App" onclick="openAROptions();" onclick="return ar_mh_progbtn1_onclick()" />--%>
                                                
                                                </td>
                                            </tr>
                                        </tbody>
                                    </table>
                                    <table width="100%" cellpadding="0" cellspacing="0" style="border: 1px solid black;"
                                        bgcolor="white" title="AR Amounts">
                                        <tbody>
                                            <tr id="ar_headerRow" style="border: 1px solid black" title="HeaderRow">
                                                <td align="center">
                                                </td>
                                                <td align="center" style="border: 1px solid black; color: White; background-color: #4169E1;">
                                                    <asp:Label ID="Label67" runat="server" Text="Program" CssClass="label" />
                                                </td>
                                                <td align="center" style="border: 1px solid black; color: White; background-color: #4169E1;">
                                                    <asp:Label ID="Label81" runat="server" Text="Dwelling " CssClass="label" />
                                                </td>
                                                <td align="center" 
                                                    style="border: 1px solid black; color: White; background-color: #4169E1;" 
                                                    class="style3">
                                                    <asp:Label ID="Label85" runat="server" Text="Other <br/>Structures" CssClass="label" />
                                                </td>
                                                <td align="center" style="border: 1px solid black; color: White; background-color: #4169E1;">
                                                    <asp:Label ID="Label87" runat="server" Text="Contents" CssClass="label" />
                                                </td>
                                                <td align="center" style="border: 1px solid black; color: White; background-color: #4169E1;">
                                                    <asp:Label ID="Label83" runat="server" Text="Liability" CssClass="label" />
                                                </td>
                                                <td align="center" style="border: 1px solid black; color: White; background-color: #4169E1;">
                                                    <asp:Label ID="Label84" runat="server" Text="Med Pay" CssClass="label" />
                                                </td>
                                                <td align="center" style="border: 1px solid black; color: White; background-color: #4169E1;">
                                                    <asp:Label ID="Label89" runat="server" Text="Base Premium" CssClass="label" />
                                                </td>
                                                <td align="center" style="border: 1px solid black; color: White; background-color: #4169E1;">
                                                    <asp:Label ID="Label91" runat="server" Text="Options" CssClass="label" />
                                                </td>
                                                <td align="center" style="border: 1px solid black; color: White; background-color: #4169E1;">
                                                    <asp:Label ID="Label93" runat="server" Text="Fees" CssClass="label" />
                                                </td>
                                                <td align="center" style="border: 1px solid black; color: White; background-color: #4169E1;">
                                                    <asp:Label ID="Label107" runat="server" Text="Taxes" CssClass="label" />
                                                </td>
                                                <td align="center" style="border: 1px solid black; color: White; background-color: #4169E1;">
                                                    <asp:Label ID="Label102" runat="server" Text="Total" CssClass="labelTotal" />
                                                </td>
                                                <td align="center" style="border: 1px solid black; color: White; background-color: #4169E1;">
                                                </td>
                                            </tr>
                                            <tr id="ar_mh_prog1" runat="server" style="border: 1px solid black;">
                                                <td align="center" style="border: 1px solid">
                                                    <label id="lblARShowOptions1" runat="server" style="color: Blue; cursor: pointer;"
                                                        onclick="AROptionsShow(1);" clientidmode="Static">
                                                        + Show Options</label>
                                                    <asp:HiddenField ID="lblARShowOptions1_hidden" runat="server" Value="+ Show Options" />
                                                </td>
                                                <td align="center" style="border: 1px solid">
                                                    <asp:Label ID="Label61" runat="server" Text="American Reliable Package" CssClass="labelCov" />
                                                </td>
                                                <td align="center" style="border: 1px solid">
                                                    <asp:Label ID="ar_dwell1" runat="server" Text="0.00" ClientIDMode="Static" CssClass="labelCov" />
                                                </td>
                                                <td align="center" style="border: 1px solid" class="style3">
                                                    <asp:Label ID="ar_unattStr1" runat="server" Text="0.00" ClientIDMode="Static" CssClass="labelCov" />
                                                </td>
                                                <td align="center" style="border: 1px solid">
                                                    <asp:Label ID="ar_perEff1" runat="server" Text="0.00" ClientIDMode="Static" CssClass="labelCov" />
                                                </td>
                                                <td align="center" style="border: 1px solid;">
                                                    <asp:Label ID="ar_perLiab1" runat="server" Text="0.00" ClientIDMode="Static" CssClass="labelCov" />
                                                </td>
                                                <td align="center" style="border: 1px solid">
                                                    <asp:Label ID="ar_medpay1" runat="server" Text="0.00" ClientIDMode="Static" CssClass="labelCov" />
                                                </td>
                                                <td align="center" style="border: 1px solid">
                                                    <asp:Label ID="ar_baseprem1" runat="server" Text="0.00" ClientIDMode="Static" CssClass="labelCov" />
                                                </td>
                                                <td align="center" style="border: 1px solid">
                                                    <asp:Label ID="ar_options1" runat="server" Text="0.00" ClientIDMode="Static" CssClass="labelCov" />
                                                </td>
                                                <td align="center" style="border: 1px solid">
                                                    <asp:Label ID="ar_fees1" runat="server" Text="0.00" ClientIDMode="Static" CssClass="labelCov" />
                                                </td>
                                                <td align="center" style="border: 1px solid">
                                                    <asp:Label ID="ar_tax1" runat="server" Text="0.00" ClientIDMode="Static" CssClass="labelCov" />
                                                </td>
                                                <td align="center" style="border: 1px solid">
                                                    <asp:Label ID="ar_total1" runat="server" Text="0.00" ClientIDMode="Static" CssClass="labelTotal" />
                                                </td>
                                                <td align="center" style="border: 1px solid">
                                                    <asp:Button ID="selectAR1btn" runat="server" OnClick="selectAR1btn_Click" Text="Select" />
                                                </td>
                                            </tr>
                                            <tr id="ar_mh_prog1_Options" runat="server" clientidmode="Static">
                                                <td colspan="18">
                                                    <table id="AROptionRow1" runat="server" width="auto" cellpadding="0" cellspacing="0"
                                                        clientidmode="Static" bgcolor="white" title="AR Options">
                                                        <tbody>
                                                            <tr>
                                                                <td align="left">
                                                                    <input id="btnShow" type="button" value="Open Calc Detail" onclick="openCalcDesc(1);" onclick="return btnShow_onclick()" onclick="return btnShow_onclick()" />
                                                                    <asp:Label ID="txt_dwell_AR1_Amount" runat="server" Text="0.00" CssClass="label" Style="display:none" />
                                                                    &nbsp;
                                                                    <asp:Label ID="txt_DedChange_AR1_Amount" runat="server" Text="0.00" CssClass="label" Style="display:none" />
                                                                    &nbsp;
                                                                    <asp:Label ID="txt_Credit_AR1_Amount" runat="server" Text="0.00" CssClass="label" Style="display:none" />
                                                                    &nbsp;
                                                                </td>
                                                            </tr>
                                                            <tr>
                                                                <td align="left">
                                                                    <asp:Label ID="Label64" runat="server" Text="AOP Deductible" CssClass="label" />
                                                                </td>
                                                                <td align="left">
                                                                    <asp:DropDownList ID="dd_aop_AR1" runat="server" ClientIDMode="Static">
                                                                        <asp:ListItem>$500</asp:ListItem>
                                                                        <asp:ListItem>$1000</asp:ListItem>
                                                                    </asp:DropDownList>
                                                                </td>
                                                            </tr>
                                                            <tr>
                                                                <td align="left">
                                                                    <asp:Label ID="Label63" runat="server" Text="Hurricane Deductible" CssClass="label" />
                                                                </td>
                                                                <td align="left">
                                                                    <asp:DropDownList ID="dd_hurded_AR1" runat="server" ClientIDMode="Static">
                                                                        <asp:ListItem>$500</asp:ListItem>
                                                                        <asp:ListItem>$1000</asp:ListItem>
                                                                        <asp:ListItem>2%</asp:ListItem>
                                                                        <asp:ListItem>5%</asp:ListItem>
                                                                        <asp:ListItem>10%</asp:ListItem>
                                                                    </asp:DropDownList>
                                                                </td>
                                                            </tr>
                                                            <tr>
                                                                <td>
                                                                    &nbsp;
                                                                </td>
                                                            </tr>
                                                            <tr>
                                                                <td align="left">
                                                                    <asp:Label ID="Label108" runat="server" Text="Personal Liability:  " CssClass="label" />
                                                                    &nbsp
                                                                </td>
                                                                <td align="left">
                                                                    <asp:DropDownList ID="dd_pl_AR1" runat="server" ClientIDMode="Static">
                                                                        <asp:ListItem>$50,000</asp:ListItem>
                                                                        <asp:ListItem>$100,000</asp:ListItem>
                                                                        <asp:ListItem>$300,000</asp:ListItem>
                                                                    </asp:DropDownList>
                                                                    &nbsp;
                                                                    <asp:Label ID="dd_pl_AR1_Amount" runat="server" Text="0.00" CssClass="label" />
                                                                    &nbsp;
                                                                </td>
                                                            </tr>
                                                            <tr>
                                                                <td align="left" class="style2">
                                                                    <asp:Label ID="Label148" runat="server" Text="Medical payment:  " CssClass="label" />
                                                                    &nbsp
                                                                </td>
                                                                <td align="left" class="style2">
                                                                    <asp:DropDownList ID="dd_mp_AR1" runat="server" ClientIDMode="Static">
                                                                        <asp:ListItem>$500</asp:ListItem>
                                                                        <asp:ListItem>$1000</asp:ListItem>
                                                                    </asp:DropDownList>
                                                                     &nbsp;
                                                                    <asp:Label ID="dd_med_AR1_amt" runat="server" Text="0.00" CssClass="label" />
                                                                    &nbsp;
                                                                </td>
                                                            </tr>
                                                            <tr>
                                                                <td>
                                                                    &nbsp;
                                                                </td>
                                                            </tr>
                                                            <tr>
                                                                <td align="left">
                                                                    <asp:Label ID="Label65" runat="server" Text="Increase Other Structures:  " CssClass="label" />
                                                                    &nbsp
                                                                </td>
                                                                <td align="left" style="margin-left: 40px">
                                                                    <asp:TextBox ID="txt_unattstr_AR1" runat="server" Text="0.00" AutoCompleteType="DisplayName"
                                                                        ClientIDMode="Static" Casing="UPPER" ToolTip="Add'l Other Structures" Width="65"
                                                                        TabIndex="31" />
                                                                    &nbsp;<asp:Label ID="txt_unattstr_AR1_Amount" runat="server" Text="0.00" CssClass="label" />
                                                                    &nbsp;
                                                                </td>
                                                            </tr>
                                                            <tr style="border: 1px solid;">
                                                                <td align="left">
                                                                    <asp:Label ID="Label104" runat="server" Text="Increase Contents:  " CssClass="label" />
                                                                    &nbsp
                                                                </td>
                                                                <td align="left">
                                                                    <asp:TextBox ID="txt_pp_AR1" runat="server" Text="0.00" AutoCompleteType="DisplayName"
                                                                        ClientIDMode="Static" Casing="UPPER" ToolTip="Personal Property" Width="65" TabIndex="31" />
                                                                    &nbsp;
                                                                    <asp:Label ID="txt_pp_AR1_Amount" runat="server" Text="0.00" CssClass="label" />
                                                                    &nbsp;
                                                                </td>
                                                            </tr>
                                                            <tr>
                                                                <td>
                                                                    &nbsp;
                                                                </td>
                                                            </tr>
                                                            <tr>
                                                                <td align="left">
                                                                    <asp:Label ID="Label98" runat="server" Text="Mobile Home Replacement Cost:  " CssClass="label" />
                                                                    &nbsp
                                                                </td>
                                                                <td align="left">
                                                                    <asp:DropDownList ID="dd_mhr_AR1" runat="server" TabIndex="19" ClientIDMode="Static">
                                                                        <asp:ListItem>No</asp:ListItem>
                                                                        <asp:ListItem>Yes</asp:ListItem>
                                                                    </asp:DropDownList>
                                                                    &nbsp;
                                                                    <asp:Label ID="dd_mhr_AR1_Amount" runat="server" Text="0.00" CssClass="label" />
                                                                    &nbsp;
                                                                </td>
                                                            </tr>
                                                            <tr>
                                                                <td align="left">
                                                                    <asp:Label ID="Label100" runat="server" Text="Contents Replacement Cost:  " CssClass="label" />
                                                                    &nbsp
                                                                </td>
                                                                <td align="left">
                                                                    <asp:DropDownList ID="dd_rep_AR1" runat="server" TabIndex="19" ClientIDMode="Static">
                                                                        <asp:ListItem>No</asp:ListItem>
                                                                        <asp:ListItem>Yes</asp:ListItem>
                                                                    </asp:DropDownList>
                                                                    &nbsp;
                                                                    <asp:Label ID="dd_rep_AR1_Amount" runat="server" Text="0.00" CssClass="label" />
                                                                    &nbsp;
                                                                </td>
                                                            </tr>
                                                            <tr>
                                                                <td align="left">
                                                                    <asp:Label ID="Label103" runat="server" Text="Additional Limits for Radio & TV Antenna:  "
                                                                        CssClass="label" />
                                                                    &nbsp
                                                                </td>
                                                                <td align="left">
                                                                    <asp:TextBox ID="txt_addlimrad_AR1" runat="server" Text="0.00" AutoCompleteType="DisplayName"
                                                                        Casing="UPPER" ToolTip="Additional Limits for Radio & TV Antenna" Width="65"
                                                                        ClientIDMode="Static" TabIndex="31" />
                                                                    &nbsp;
                                                                    <asp:Label ID="txt_addlimrad_AR1_Amount" runat="server" Text="0.00" CssClass="label" />
                                                                    &nbsp;
                                                                </td>
                                                            </tr>
                                                            <tr>
                                                                <td align="left">
                                                                    <asp:Label ID="Label106" runat="server" Text="Additional Limits  for Fire Department Service Charge:  "
                                                                        CssClass="label" />
                                                                    &nbsp
                                                                </td>
                                                                <td align="left">
                                                                    <asp:TextBox ID="txt_addlimfir_AR1" runat="server" Text="0.00" AutoCompleteType="DisplayName"
                                                                        Casing="UPPER" ToolTip="Additional Limits for Fire Department Service Charge"
                                                                        ClientIDMode="Static" Width="65" TabIndex="31" />
                                                                    &nbsp;
                                                                    <asp:Label ID="txt_addlimfir_AR1_Amount" runat="server" Text="0.00" CssClass="label" />
                                                                    &nbsp;
                                                                </td>
                                                            </tr>
                                                            <tr>
                                                                <td id="trmhAROpt1_2" style="display: none" align="left" clientidmode="Static">
                                                                    <asp:Label ID="Label92" runat="server" Text="Secured Interest  Protection:  " CssClass="label" />
                                                                    &nbsp
                                                                </td>
                                                                <td id="trmhAROpt1_2_d" style="display: none;" align="left" clientidmode="Static">
                                                                    <asp:DropDownList ID="dd_sip_AR1" runat="server" TabIndex="19" ClientIDMode="Static">
                                                                        <asp:ListItem>No</asp:ListItem>
                                                                        <asp:ListItem>Yes</asp:ListItem>
                                                                    </asp:DropDownList>
                                                                    &nbsp;
                                                                    <asp:Label ID="dd_sip_AR1_Amount" runat="server" Text="0.00" CssClass="label" />
                                                                    &nbsp;
                                                                </td>
                                                            </tr>
                                                            <tr>
                                                                <td id="trmhAROpt1" style="display: none" align="left" clientidmode="Static">
                                                                    <asp:Label ID="Label96" runat="server" Text="Natural Disaster <br/> Protection:  "
                                                                        CssClass="label" />
                                                                    &nbsp
                                                                </td>
                                                                <td id="trmhAROpt1_d" style="display: none;" align="left" clientidmode="Static">
                                                                    <asp:DropDownList ID="dd_ndp_AR1" runat="server" TabIndex="19" ClientIDMode="Static">
                                                                        <asp:ListItem>No</asp:ListItem>
                                                                        <asp:ListItem>Yes</asp:ListItem>
                                                                    </asp:DropDownList>
                                                                    &nbsp;
                                                                    <asp:Label ID="dd_ndp_AR1_Amount" runat="server" Text="0.00" CssClass="label" />
                                                                    &nbsp;
                                                                </td>
                                                            </tr>
                                                            <tr>
                                                                <td>
                                                                    &nbsp;
                                                                </td>
                                                            </tr>
                                                            <tr style="border: 1px solid black">
                                                                <td align="left">
                                                                    <asp:Label ID="Label99" runat="server" Text="Additional Residence:" CssClass="label" />
                                                                    &nbsp
                                                                </td>
                                                                <td align="left">
                                                                    <asp:DropDownList ID="dd_addresOpt_ar1" runat="server" ClientIDMode="Static">
                                                                        <asp:ListItem></asp:ListItem>
                                                                        <asp:ListItem>Premises Occupied by Insured</asp:ListItem>
                                                                        <asp:ListItem>Rented to Others - 1 Family</asp:ListItem>
                                                                        <asp:ListItem>Rented to Others - 2 Family</asp:ListItem>
                                                                    </asp:DropDownList>
                                                                    &nbsp;
                                                                    <asp:Label ID="dd_addresOpt_ar1_Amount" runat="server" Text="0.00" CssClass="label" />
                                                                    &nbsp;
                                                                </td>
                                                            </tr>
                                                            <tr id="AR_AddResOpt1_ar1" style="display: none" clientidmode="Static">
                                                                <td align="left">
                                                                    <asp:HiddenField ID="AR_AddResOpt1_HIDDEN" runat="server" />
                                                                    <asp:Label ID="Label95" runat="server" Text="Additional Residence Liability" CssClass="label" />
                                                                    &nbsp
                                                                </td>
                                                                <td align="left">
                                                                    <asp:DropDownList ID="dd_addresliab_ar1" runat="server" ClientIDMode="Static">
                                                                        <asp:ListItem>$25,000</asp:ListItem>
                                                                        <asp:ListItem>$50,000</asp:ListItem>
                                                                        <asp:ListItem>$100,000</asp:ListItem>
                                                                        <asp:ListItem>$300,000</asp:ListItem>
                                                                    </asp:DropDownList>
                                                                </td>
                                                            </tr>
                                                            <tr id="AR_AddResOpt2_ar1" style="display: none" clientidmode="Static">
                                                                <td align="left">
                                                                    <asp:Label ID="Label97" runat="server" Text="Additional Residence Medical payment:  "
                                                                        CssClass="label" />
                                                                    &nbsp
                                                                </td>
                                                                <td align="left">
                                                                    <asp:DropDownList ID="dd_addresMP_ar1" runat="server" ClientIDMode="Static">
                                                                        <asp:ListItem>$500</asp:ListItem>
                                                                        <asp:ListItem>$1000</asp:ListItem>
                                                                    </asp:DropDownList>
                                                                </td>
                                                            </tr>
                                                            <tr style="border: 1px solid;">
                                                                <td align="left">
                                                                    <asp:Label ID="Label151" runat="server" Text="Watercraft" CssClass="label" />
                                                                    &nbsp
                                                                </td>
                                                                <td align="left">
                                                                    <asp:DropDownList ID="dd_waterCraft_AR1" runat="server" ClientIDMode="Static">
                                                                        <asp:ListItem></asp:ListItem>
                                                                        <asp:ListItem>OB Motor(s) Total HP 25-49</asp:ListItem>
                                                                        <asp:ListItem>OB Motor(s) Total HP 50 & Over</asp:ListItem>
                                                                        <asp:ListItem>IB or IB/OB over 50 HP and Sailboats over 26 Ft in length under 30 MPH</asp:ListItem>
                                                                        <asp:ListItem>IB or IB/OB over 50 HP and Sailboats over 26 Ft in length under 30 -40 MPH</asp:ListItem>
                                                                    </asp:DropDownList>
                                                                    &nbsp;
                                                                    <asp:Label ID="dd_waterCraft_AR1_Amount" runat="server" Text="0.00" CssClass="label" />
                                                                    &nbsp;
                                                                </td>
                                                            </tr>
                                                            <tr id="AR_WaterCraftOpt1_ar1" style="display: none">
                                                                <td align="left">
                                                                    <asp:HiddenField ID="AR_AddResOpt2_HIDDEN" runat="server" />
                                                                    <asp:Label ID="Label152" runat="server" Text="Watercraft Liability" CssClass="label" />
                                                                    &nbsp
                                                                </td>
                                                                <td align="left">
                                                                    <asp:DropDownList ID="dd_waterCraftliab_AR1" runat="server" ClientIDMode="Static">
                                                                        <asp:ListItem>$25,000</asp:ListItem>
                                                                        <asp:ListItem>$50,000</asp:ListItem>
                                                                        <asp:ListItem>$100,000</asp:ListItem>
                                                                        <asp:ListItem>$300,000</asp:ListItem>
                                                                    </asp:DropDownList>
                                                                </td>
                                                            </tr>
                                                            <tr id="AR_WaterCraftOpt2_ar1" style="display: none">
                                                                <td align="left">
                                                                    <asp:Label ID="Label153" runat="server" Text="Watercraft Medical payment:  " CssClass="label" />
                                                                    &nbsp
                                                                </td>
                                                                <td align="left">
                                                                    <asp:DropDownList ID="dd_waterCraftMedpay_AR1" runat="server" ClientIDMode="Static">
                                                                        <asp:ListItem>$500</asp:ListItem>
                                                                        <asp:ListItem>$1000</asp:ListItem>
                                                                    </asp:DropDownList>
                                                                </td>
                                                            </tr>
                                                            <tr>
                                                                <td align="left">
                                                                    <asp:Label ID="Label154" runat="server" Text="Valuable Personal Property:" CssClass="label" />
                                                                    &nbsp
                                                                </td>
                                                                <td align="left">
                                                                    <asp:DropDownList ID="dd_PackagePerProp_AR1" runat="server" TabIndex="19" ClientIDMode="Static">
                                                                        <asp:ListItem></asp:ListItem>
                                                                        <asp:ListItem>Yes</asp:ListItem>
                                                                        <asp:ListItem>No</asp:ListItem>
                                                                    </asp:DropDownList>
                                                                    &nbsp;
                                                                    <asp:Label ID="Label167" runat="server" Text="Value:" CssClass="label" />
                                                                    &nbsp;
                                                                    &nbsp;
                                                                    <asp:label ID="packagePerPropValue" runat="server" Text="0.00" Enabled="false" CssClass="label"  />
                                                                    &nbsp;
                                                                    &nbsp;
                                                                     &nbsp;
                                                                    &nbsp;
                                                                    <asp:Label ID="Label168" runat="server" Text="Premium" CssClass="label" />
                                                                    &nbsp;
                                                                    &nbsp;
                                                                    <asp:Label ID="dd_PackagePerProp_AR1_Amount" runat="server" Text="0.00" CssClass="label" />
                                                                    &nbsp;
                                                                </td>
                                                            </tr>
                                                                                                                        
                                                            <tr id="trvalPPl" style="display:none">
                                                                <td align="left">
                                                                    <asp:Label ID="Label165" runat="server" Text="Valuable Personal Property list:" CssClass="label" />
                                                                    &nbsp
                                                                </td>
                                                                <td>
                                                                    <dx:ASPxGridView ID="ASPxGridView1" runat="server" AutoGenerateColumns="False" KeyFieldName="ID" OnRowUpdating="ASPxGridView1_RowUpdating" OnRowDeleting="ASPxGridView1_RowDeleting" OnRowInserting="ASPxGridView1_RowInserting"
                                                                        Width="100%" >
                                                                           <SettingsPager Visible="False">
                                                                           </SettingsPager>
                                                                           <SettingsEditing Mode="Inline" />
                                                                            <SettingsBehavior AllowFocusedRow="True" />
                                                                        <Columns>
                                                                            <dx:GridViewCommandColumn VisibleIndex="0">
                                                                               
                                                                                <NewButton Visible="True">
                                                                                </NewButton>
                                                                                <DeleteButton Visible="True">
                                                                                </DeleteButton>
                                                                            </dx:GridViewCommandColumn>
                                                                            <dx:GridViewDataTextColumn Caption="id" FieldName="ID" Name="id" 
                                                                                Visible="False" VisibleIndex="3">
                                                                            </dx:GridViewDataTextColumn>
                                                                            <dx:GridViewDataTextColumn Caption="Description" FieldName="description" 
                                                                                VisibleIndex="1" Width="80%" Name="descriptionar1">
                                                                            </dx:GridViewDataTextColumn>
                                                                            <dx:GridViewDataTextColumn Caption="Value" FieldName="value" width="10%"
                                                                                VisibleIndex="2" Name="valuear1">
                                                                            </dx:GridViewDataTextColumn>
                                                                        </Columns>
                                                                    </dx:ASPxGridView>
                                                                </td>
                                                            </tr>
                                                    
                                                    
                                                   
                                            
                                                            <tr id="trsecureint" style="display:none">
                                                                <td align="left">
                                                                    <asp:Label ID="Label143" runat="server" Text="Secured Interest Protection:" CssClass="label" />
                                                                    &nbsp
                                                                </td>
                                                                <td align="left">
                                                                 &nbsp;
                                                                    <asp:Label ID="SecureInterest_ar1_Amount" runat="server" Text="0.00" CssClass="label" />
                                                                    &nbsp;
                                                                </td>
                                                            </tr>
                                                            <tr id="trheating" style="display:none" >
                                                                <td align="left">
                                                                    <asp:Label ID="Label142" runat="server" Text="Supplemental Heating:" CssClass="label" />
                                                                    &nbsp
                                                                </td>
                                                                <td align="left">
                                                                
                                                                    &nbsp;
                                                                    <asp:Label ID="supHeating_ar1_Amount" runat="server" Text="0.00" CssClass="label" />
                                                                    &nbsp;
                                                                    <asp:Label ID="CEA_ar1_Amount" runat="server" Text="0.00" style="display:none" />
                                                                    &nbsp;
                                                                </td>
                                                            </tr>
                                                            <tr>
                                                                <td align="left">
                                                                    <asp:Button ID="ar1_updateOptions" runat="server" CausesValidation="false" Style="display: none"
                                                                        Text="Update Optional Coverages" OnClick="ar_premiumbtnClick" />
                                                                </td>
                                                            </tr>
                                                        </tbody>
                                                    </table>
                                                </td>
                                            </tr>
                                            <tr id="ar_mh_prog2" runat="server" style="border: 1px solid black;">
                                                <td align="center" style="border: 1px solid">
                                                    <label id="lblARShowOptions2" runat="server" style="color: Blue; cursor: pointer;"
                                                        onclick="AROptionsShow(2);" clientidmode="Static">
                                                        + Show Options</label>
                                                    <asp:HiddenField ID="lblARShowOptions2_hidden" runat="server" Value="+ Show Options" />
                                                </td>
                                                <td align="center" style="border: 1px solid">
                                                    <asp:Label ID="Label82" runat="server" Text="American Reliable Standard" CssClass="labelCov" />
                                                </td>
                                                <td align="center" style="border: 1px solid">
                                                    <asp:Label ID="ar_dwell2" runat="server" Text="0.00" CssClass="labelCov" />
                                                </td>
                                                <td align="center" style="border: 1px solid" class="style3">
                                                    <asp:Label ID="ar_unattStr2" runat="server" Text="0.00" CssClass="labelCov" />
                                                </td>
                                                <td align="center" style="border: 1px solid">
                                                    <asp:Label ID="ar_perEff2" runat="server" Text="0.00" CssClass="labelCov" />
                                                </td>
                                                <td align="center" style="border: 1px solid;">
                                                    <asp:Label ID="ar_perLiab2" runat="server" Text="0.00" CssClass="labelCov" />
                                                </td>
                                                <td align="center" style="border: 1px solid">
                                                    <asp:Label ID="ar_medpay2" runat="server" Text="0.00" CssClass="labelCov" />
                                                </td>
                                                <td align="center" style="border: 1px solid">
                                                    <asp:Label ID="ar_baseprem2" runat="server" Text="0.00" CssClass="labelCov" />
                                                </td>
                                                <td align="center" style="border: 1px solid">
                                                    <asp:Label ID="ar_options2" runat="server" Text="0.00" CssClass="labelCov" />
                                                </td>
                                                <td align="center" style="border: 1px solid">
                                                    <asp:Label ID="ar_fees2" runat="server" Text="0.00" CssClass="labelCov" />
                                                </td>
                                                <td align="center" style="border: 1px solid">
                                                    <asp:Label ID="ar_tax2" runat="server" Text="0.00" CssClass="labelCov" />
                                                </td>
                                                <td align="center" style="border: 1px solid">
                                                    <asp:Label ID="ar_total2" runat="server" Text="0.00" CssClass="labelTotal" />
                                                </td>
                                                <td align="center" style="border: 1px solid">
                                                    <asp:Button ID="selectAR2btn" runat="server" OnClick="selectAR2btn_Click" Text="Select" />
                                                </td>
                                            </tr>
                                            <tr id="ar_mh_prog2_Options" runat="server" clientidmode="Static">
                                                <td colspan="18">
                                                    <table id="AROptionRow2" runat="server" width="auto" cellpadding="0" cellspacing="0"
                                                        clientidmode="Static" bgcolor="white" title="AR Options">
                                                        <tbody>
                                                            <tr>
                                                                <td align="left">
                                                                    <input id="Button1" type="button" value="Open Calc Detail" onclick="openCalcDesc(2);" />
                                                                    <asp:Label ID="txt_dwell_AR2_Amount" runat="server" Text="0.00" CssClass="label" Style="display:none" />
                                                                    &nbsp;
                                                                    <asp:Label ID="txt_DedChange_AR2_Amount" runat="server" Text="0.00" CssClass="label" Style="display:none" />
                                                                    <asp:Label ID="txt_Credit_AR2_Amount" runat="server" Text="0.00" CssClass="label" Style="display:none" />
                                                                    &nbsp;
                                                                </td>
                                                            </tr>
                                                            <tr>
                                                                <td align="left">
                                                                    <asp:Label ID="Label90" runat="server" Text="AOP Deductible" CssClass="label" />
                                                                </td>
                                                                <td align="left">
                                                                    <asp:DropDownList ID="dd_aop_AR2" runat="server" TabIndex="22">
                                                                        <asp:ListItem>$500</asp:ListItem>
                                                                        <asp:ListItem>$1000</asp:ListItem>
                                                                    </asp:DropDownList>
                                                                </td>
                                                            </tr>
                                                            <tr>
                                                                <td align="left">
                                                                    <asp:Label ID="Label94" runat="server" Text="Hurricane Deductible" CssClass="label" />
                                                                </td>
                                                                <td align="left">
                                                                    <asp:DropDownList ID="dd_hurded_AR2" runat="server">
                                                                        <asp:ListItem></asp:ListItem>
                                                                        <asp:ListItem>$500</asp:ListItem>
                                                                        <asp:ListItem>$1000</asp:ListItem>
                                                                        <asp:ListItem>2%</asp:ListItem>
                                                                        <asp:ListItem>5%</asp:ListItem>
                                                                        <asp:ListItem>10%</asp:ListItem>
                                                                    </asp:DropDownList>
                                                                </td>
                                                            </tr>
                                                            <tr>
                                                                <td>
                                                                    &nbsp;
                                                                </td>
                                                            </tr>
                                                            <tr>
                                                                <td align="left">
                                                                    <asp:Label ID="Label105" runat="server" Text="Personal Liability:  " CssClass="label" />
                                                                    &nbsp
                                                                </td>
                                                                <td align="left">
                                                                    <asp:DropDownList ID="dd_pl_AR2" runat="server">
                                                                        <asp:ListItem>$0</asp:ListItem>
                                                                        <asp:ListItem>$25,000</asp:ListItem>
                                                                        <asp:ListItem>$50,000</asp:ListItem>
                                                                        <asp:ListItem>$100,000</asp:ListItem>
                                                                        <asp:ListItem>$300,000</asp:ListItem>
                                                                    </asp:DropDownList>
                                                                    &nbsp;<asp:Label ID="dd_pl_AR2_Amount" runat="server" Text="0.00" CssClass="label" />
                                                                    &nbsp;
                                                                </td>
                                                            </tr>
                                                            <tr id="AR_StandardMedPay" style="display: " clientidmode="Static">
                                                                <td align="left">
                                                                    <asp:Label ID="Label149" runat="server" Text="Medical payment:  " CssClass="label" />
                                                                    &nbsp
                                                                </td>
                                                                <td align="left">
                                                                    <asp:DropDownList ID="dd_mp_AR2" runat="server"  clientidmode="Static">
                                                                        <asp:ListItem>$0</asp:ListItem>
                                                                        <asp:ListItem>$500</asp:ListItem>
                                                                        <asp:ListItem>$1000</asp:ListItem>
                                                                    </asp:DropDownList>
                                                                     &nbsp;
                                                                    <asp:Label ID="dd_med_AR2_amt" runat="server" Text="0.00" CssClass="label" />
                                                                    &nbsp;
                                                                </td>
                                                            </tr>
                                                            <tr>
                                                                <td>
                                                                    &nbsp;
                                                                </td>
                                                            </tr>
                                                            <tr>
                                                                <td align="left">
                                                                    <asp:Label ID="Label115" runat="server" Text="Other Structures:  " CssClass="label" />
                                                                    &nbsp
                                                                </td>
                                                                <td align="left">
                                                                    <asp:TextBox ID="txt_unattstr_AR2" runat="server" Text="0.00" AutoCompleteType="DisplayName"
                                                                        Casing="UPPER" ToolTip="Unattached Structure" Width="65" TabIndex="31" />
                                                                    &nbsp;<asp:Label ID="txt_unattstr_AR2_Amount" runat="server" Text="0.00" CssClass="label" />
                                                                    &nbsp;
                                                                </td>
                                                            </tr>
                                                            <tr>
                                                                <td align="left">
                                                                    <asp:Label ID="Label116" runat="server" Text="Contents:  " CssClass="label" />
                                                                    &nbsp
                                                                </td>
                                                                <td align="left">
                                                                    <asp:TextBox ID="txt_pp_AR2" runat="server" Text="0.00" AutoCompleteType="DisplayName"
                                                                        Casing="UPPER" ToolTip="Personal Property" Width="65" TabIndex="31" />
                                                                    &nbsp;<asp:Label ID="txt_pp_AR2_Amount" runat="server" Text="0.00" CssClass="label" />
                                                                    &nbsp;
                                                                </td>
                                                            </tr>
                                                            <tr>
                                                                <td align="left">
                                                                    <asp:Label ID="Label117" runat="server" Text="Mobile Home Replacement Cost:  " CssClass="label" />
                                                                    &nbsp
                                                                </td>
                                                                <td align="left">
                                                                    <asp:DropDownList ID="dd_mhr_AR2" runat="server" TabIndex="19">
                                                                        <asp:ListItem>No</asp:ListItem>
                                                                        <asp:ListItem>Yes</asp:ListItem>
                                                                    </asp:DropDownList>
                                                                    &nbsp;<asp:Label ID="dd_mhr_AR2_Amount" runat="server" Text="0.00" CssClass="label" />
                                                                    &nbsp;
                                                                </td>
                                                            </tr>
                                                            <tr>
                                                                <td align="left">
                                                                    <asp:Label ID="Label118" runat="server" Text="Contents Replacement Cost:  " CssClass="label" />
                                                                    &nbsp
                                                                </td>
                                                                <td align="left">
                                                                    <asp:DropDownList ID="dd_rep_AR2" runat="server" TabIndex="19">
                                                                        <asp:ListItem>No</asp:ListItem>
                                                                        <asp:ListItem>Yes</asp:ListItem>
                                                                    </asp:DropDownList>
                                                                    &nbsp;<asp:Label ID="dd_rep_AR2_Amount" runat="server" Text="0.00" CssClass="label" />
                                                                    &nbsp;
                                                                </td>
                                                            </tr>
                                                            <tr>
                                                                <td align="left">
                                                                    <asp:Label ID="Label119" runat="server" Text="Additional Limits for Radio & TV Antenna:  "
                                                                        CssClass="label" />
                                                                    &nbsp
                                                                </td>
                                                                <td align="left">
                                                                    <asp:TextBox ID="txt_addlimrad_AR2" runat="server" Text="0.00" AutoCompleteType="DisplayName"
                                                                        Casing="UPPER" ToolTip="Additional Limits for Radio & TV Antenna" Width="65"
                                                                        TabIndex="31" />
                                                                    &nbsp;<asp:Label ID="txt_addlimrad_AR2_Amount" runat="server" Text="0.00" CssClass="label" />
                                                                    &nbsp;
                                                                </td>
                                                            </tr>
                                                            <tr>
                                                                <td align="left">
                                                                    <asp:Label ID="Label134" runat="server" Text="Additional Limits  for Fire Department Service Charge:  "
                                                                        CssClass="label" />
                                                                    &nbsp
                                                                </td>
                                                                <td align="left">
                                                                    <asp:TextBox ID="txt_addlimfir_AR2" runat="server" Text="0.00" AutoCompleteType="DisplayName"
                                                                        Casing="UPPER" ToolTip="Additional Limits for Fire Department Service Charge"
                                                                        Width="65" TabIndex="31" />
                                                                    &nbsp;<asp:Label ID="txt_addlimfir_AR2_Amount" runat="server" Text="0.00" CssClass="label" />
                                                                    &nbsp;
                                                                </td>
                                                            </tr>
                                                            <tr>
                                                                <td id="trmhAROpt2_2" style="display: none" align="left" clientidmode="Static">
                                                                    <asp:Label ID="Label135" runat="server" Text="Secured Interest  Protection:  " CssClass="label" />
                                                                    &nbsp
                                                                </td>
                                                                <td id="trmhAROpt2_2_d" style="display: none;" align="left" clientidmode="Static">
                                                                    <asp:DropDownList ID="dd_sip_AR2" runat="server" TabIndex="19">
                                                                        <asp:ListItem>No</asp:ListItem>
                                                                        <asp:ListItem>Yes</asp:ListItem>
                                                                    </asp:DropDownList>
                                                                    &nbsp;<asp:Label ID="dd_sip_AR2_Amount" runat="server" Text="0.00" CssClass="label" />
                                                                    &nbsp;
                                                                </td>
                                                            </tr>
                                                            <tr>
                                                                <td id="trmhAROpt2" style="display: none" align="left" clientidmode="Static">
                                                                    <asp:Label ID="Label136" runat="server" Text="Natural Disaster <br/> Protection:  "
                                                                        CssClass="label" />
                                                                    &nbsp
                                                                </td>
                                                                <td id="trmhAROpt2_d" style="display: none;" align="left" clientidmode="Static">
                                                                    <asp:DropDownList ID="dd_ndp_AR2" runat="server" TabIndex="19">
                                                                        <asp:ListItem>No</asp:ListItem>
                                                                        <asp:ListItem>Yes</asp:ListItem>
                                                                    </asp:DropDownList>
                                                                    &nbsp;<asp:Label ID="dd_ndp_AR2_Amount" runat="server" Text="0.00" CssClass="label" />
                                                                    &nbsp;
                                                                </td>
                                                            </tr>
                                                            <tr>
                                                                <td>
                                                                    &nbsp;
                                                                </td>
                                                            </tr>
                                                            <tr style="border: 1px solid black">
                                                                <td align="left">
                                                                    <asp:Label ID="Label155" runat="server" Text="Additional Residence:" CssClass="label" />
                                                                    &nbsp
                                                                </td>
                                                                <td align="left">
                                                                    <asp:DropDownList ID="dd_addresOpt_ar2" runat="server">
                                                                        <asp:ListItem></asp:ListItem>
                                                                        <asp:ListItem>Premises Occupied by Insured</asp:ListItem>
                                                                        <asp:ListItem>Rented to Others - 1 Family</asp:ListItem>
                                                                        <asp:ListItem>Rented to Others - 2 Family</asp:ListItem>
                                                                    </asp:DropDownList>
                                                                    &nbsp;<asp:Label ID="dd_addresOpt_ar2_Amount" runat="server" Text="0.00" CssClass="label" />
                                                                    &nbsp;
                                                                </td>
                                                            </tr>
                                                            <tr id="AR_AddResOpt1_ar2" style="display: none" clientidmode="Static">
                                                                <td align="left">
                                                                    <asp:Label ID="Label156" runat="server" Text="Additional Residence Liability" CssClass="label" />
                                                                    &nbsp
                                                                    <asp:HiddenField ID="AR_AddResOpt1_ar2_HIDDEN" runat="server" />
                                                                </td>
                                                                <td align="left">
                                                                    <asp:DropDownList ID="dd_addresliab_ar2" runat="server">
                                                                        <asp:ListItem>$25,000</asp:ListItem>
                                                                        <asp:ListItem>$50,000</asp:ListItem>
                                                                        <asp:ListItem>$100,000</asp:ListItem>
                                                                        <asp:ListItem>$300,000</asp:ListItem>
                                                                    </asp:DropDownList>
                                                                </td>
                                                            </tr>
                                                            <tr id="AR_AddResOpt2_ar2" style="display: none" clientidmode="Static">
                                                                <td align="left">
                                                                    <asp:Label ID="Label157" runat="server" Text="Additional Residence Medical payment:  "
                                                                        CssClass="label" />
                                                                    &nbsp
                                                                    <asp:HiddenField ID="AR_AddResOpt2_ar2_HIDDEN" runat="server" />
                                                                </td>
                                                                <td align="left">
                                                                    <asp:DropDownList ID="dd_addresMP_ar2" runat="server">
                                                                        <asp:ListItem>$500</asp:ListItem>
                                                                        <asp:ListItem>$1000</asp:ListItem>
                                                                    </asp:DropDownList>
                                                                </td>
                                                            </tr>
                                                            <tr style="border: 1px solid;">
                                                                <td align="left">
                                                                    <asp:Label ID="Label158" runat="server" Text="Watercraft" CssClass="label" />
                                                                    &nbsp
                                                                </td>
                                                                <td align="left">
                                                                    <asp:DropDownList ID="dd_waterCraft_ar2" runat="server">
                                                                        <asp:ListItem></asp:ListItem>
                                                                        <asp:ListItem>OB Motor(s) Total HP 25-49</asp:ListItem>
                                                                        <asp:ListItem>OB Motor(s) Total HP 50 & Over</asp:ListItem>
                                                                        <asp:ListItem>IB or IB/OB over 50 HP and Sailboats over 26 Ft in length</asp:ListItem>
                                                                        <asp:ListItem>IB or IB/OB under 30 MPH</asp:ListItem>
                                                                        <asp:ListItem>IB or IB/OB 30 – 40 MHP</asp:ListItem>
                                                                    </asp:DropDownList>
                                                                    &nbsp;<asp:Label ID="dd_waterCraft_ar2_Amount" runat="server" Text="0.00" CssClass="label" />
                                                                    &nbsp;
                                                                </td>
                                                            </tr>
                                                            <tr id="AR_WaterCraftOpt1_ar2" style="display: none" clientidmode="Static">
                                                                <td align="left">
                                                                    <asp:Label ID="Label159" runat="server" Text="Watercraft Liability" CssClass="label" />
                                                                    &nbsp
                                                                </td>
                                                                <td align="left">
                                                                    <asp:DropDownList ID="dd_waterCraftliab_ar2" runat="server">
                                                                        <asp:ListItem>$25,000</asp:ListItem>
                                                                        <asp:ListItem>$50,000</asp:ListItem>
                                                                        <asp:ListItem>$100,000</asp:ListItem>
                                                                        <asp:ListItem>$300,000</asp:ListItem>
                                                                    </asp:DropDownList>
                                                                </td>
                                                            </tr>
                                                            <tr id="AR_WaterCraftOpt2_ar2" style="display: none">
                                                                <td align="left">
                                                                    <asp:Label ID="Label160" runat="server" Text="Watercraft Medical payment:  " CssClass="label" />
                                                                    &nbsp
                                                                </td>
                                                                <td align="left">
                                                                    <asp:DropDownList ID="dd_waterCraftMedpay_ar2" runat="server">
                                                                        <asp:ListItem>$500</asp:ListItem>
                                                                        <asp:ListItem>$1000</asp:ListItem>
                                                                    </asp:DropDownList>
                                                                </td>
                                                            </tr>
                                                            <tr>
                                                                <td align="left">
                                                                    <asp:Label ID="Label161" runat="server" Text="Valuable Personal Property:" CssClass="label" />
                                                                    &nbsp
                                                                </td>
                                                                <td align="left">
                                                                    <asp:DropDownList ID="dd_PackagePerProp_ar2" runat="server" TabIndex="19">
                                                                        <asp:ListItem>No</asp:ListItem>
                                                                        <asp:ListItem>Yes</asp:ListItem>
                                                                    </asp:DropDownList>
                                                                    &nbsp;
                                                                    <asp:Label ID="Label169" runat="server" Text="Value:" CssClass="label" />
                                                                    &nbsp;
                                                                    &nbsp;
                                                                    <asp:label ID="pp_property2" runat="server" Text="0.00" Enabled="false" CssClass="label"  />
                                                                    &nbsp;
                                                                    &nbsp;
                                                                     &nbsp;
                                                                    &nbsp;
                                                                    <asp:Label ID="Label171" runat="server" Text="Premium" CssClass="label" />
                                                                    &nbsp;
                                                                    &nbsp;
                                                                    &nbsp;<asp:Label ID="dd_PackagePerProp_ar2_Amount" runat="server" Text="0.00" CssClass="label" />
                                                                    &nbsp;
                                                                </td>
                                                                </tr>
                                                                <tr id="vpplAR2" style="display:none">
                                                                <td align="left">
                                                                    <asp:Label ID="Label172" runat="server" Text="Valuable Personal Property list:" CssClass="label" />
                                                                    &nbsp
                                                                </td>
                                                                <td>
                                                                    <dx:ASPxGridView ID="ASPxGridView2" runat="server" AutoGenerateColumns="False" KeyFieldName="ID" OnRowDeleting="ASPxGridView2_RowDeleting" OnRowInserting="ASPxGridView2_RowInserting"
                                                                        Width="100%" >
                                                                           <SettingsPager Visible="False">
                                                                           </SettingsPager>
                                                                           <SettingsEditing Mode="Inline" />
                                                                            <SettingsBehavior AllowFocusedRow="True" />
                                                                        <Columns>
                                                                            <dx:GridViewCommandColumn VisibleIndex="0">
                                                                               
                                                                                <NewButton Visible="True">
                                                                                </NewButton>
                                                                                <DeleteButton Visible="True">
                                                                                </DeleteButton>
                                                                            </dx:GridViewCommandColumn>
                                                                            <dx:GridViewDataTextColumn Caption="id" FieldName="ID" Name="id" 
                                                                                Visible="False" VisibleIndex="3">
                                                                            </dx:GridViewDataTextColumn>
                                                                            <dx:GridViewDataTextColumn Caption="Description" FieldName="description" 
                                                                                VisibleIndex="1" Width="80%" Name="descriptionar1">
                                                                            </dx:GridViewDataTextColumn>
                                                                            <dx:GridViewDataTextColumn Caption="Value" FieldName="value" width="10%"
                                                                                VisibleIndex="2" Name="valuear1">
                                                                            </dx:GridViewDataTextColumn>
                                                                        </Columns>
                                                                    </dx:ASPxGridView>
                                                                </td>
                                                            
                                                            </tr>
                                                            <tr id="trsecureint2" style="display:none">
                                                                <td align="left">
                                                                    <asp:Label ID="Label162" runat="server" Text="Secured Interest Protection:" CssClass="label" />
                                                                    &nbsp
                                                                </td>
                                                                <td align="left">
                                                                    &nbsp;
                                                                    <asp:Label ID="SecureInterest_ar2_Amount" runat="server" Text="0.00" CssClass="label" />
                                                                    &nbsp;
                                                                </td>
                                                            </tr>
                                                            <tr id="trheating2" style="display:none">
                                                                <td align="left">
                                                                    <asp:Label ID="Label164" runat="server" Text="Supplemental Heating:" CssClass="label" />
                                                                    &nbsp
                                                                </td>
                                                                <td align="left">
                                                                    &nbsp;
                                                                    <asp:Label ID="supHeating_ar2_Amount" runat="server" Text="0.00" CssClass="label" />
                                                                    &nbsp;
                                                                    <asp:Label ID="CEA_ar2_Amount" runat="server" Text="0.00" style="display:none" />
                                                                    &nbsp;
                                                                    <asp:Label ID="SeasonalFee_ar2_Amount" runat="server" Text="0.00" style="display:none" />
                                                                    &nbsp;
                                                                </td>
                                                            </tr>
                                                            <tr>
                                                                <td align="left">
                                                                    <asp:Button ID="ar2_updateOptions" runat="server" Style="display: none" Text="Update Optional Coverages"
                                                                        OnClick="ar_premiumbtnClick2" />
                                                                </td>
                                                            </tr>
                                                        </tbody>
                                                    </table>
                                                </td>
                                            </tr>
                                            <tr id="ar_mh_prog3" runat="server" style="border: 1px solid black;">
                                                <td align="center" style="border: 1px solid">
                                                    <label id="lblARShowOptions3" runat="server" style="color: Blue; cursor: pointer;"
                                                        onclick="AROptionsShow(3);" clientidmode="Static">
                                                        + Show Options</label>
                                                    <asp:HiddenField ID="lblARShowOptions3_hidden" runat="server" Value="+ Show Options" />
                                                </td>
                                                <td align="center" style="border: 1px solid">
                                                    <asp:Label ID="Label86" runat="server" Text="American Reliable Rental" CssClass="labelCov" />
                                                </td>
                                                <td align="center" style="border: 1px solid">
                                                    <asp:Label ID="ar_dwell3" runat="server" Text="0.00" CssClass="labelCov" />
                                                </td>
                                                <td align="center" style="border: 1px solid" class="style3">
                                                    <asp:Label ID="ar_unattStr3" runat="server" Text="0.00" CssClass="labelCov" />
                                                </td>
                                                <td align="center" style="border: 1px solid">
                                                    <asp:Label ID="ar_perEff3" runat="server" Text="0.00" CssClass="labelCov" />
                                                </td>
                                                <td align="center" style="border: 1px solid;">
                                                    <asp:Label ID="ar_perLiab3" runat="server" Text="0.00" CssClass="labelCov" />
                                                </td>
                                                <td align="center" style="border: 1px solid">
                                                    <asp:Label ID="ar_medpay3" runat="server" Text="0.00" CssClass="labelCov" />
                                                </td>
                                                <td align="center" style="border: 1px solid">
                                                    <asp:Label ID="ar_baseprem3" runat="server" Text="0.00" CssClass="labelCov" />
                                                </td>
                                                <td align="center" style="border: 1px solid">
                                                    <asp:Label ID="ar_options3" runat="server" Text="0.00" CssClass="labelCov" />
                                                </td>
                                                <td align="center" style="border: 1px solid">
                                                    <asp:Label ID="ar_fees3" runat="server" Text="0.00" CssClass="labelCov" />
                                                </td>
                                                <td align="center" style="border: 1px solid">
                                                    <asp:Label ID="ar_tax3" runat="server" Text="0.00" CssClass="labelCov" />
                                                </td>
                                                <td align="center" style="border: 1px solid">
                                                    <asp:Label ID="ar_total3" runat="server" Text="0.00" CssClass="labelTotal" />
                                                </td>
                                                <td align="center" style="border: 1px solid">
                                                    <asp:Button ID="selectAR3btn" runat="server" OnClick="selectAR3btn_Click" Text="Select" />
                                                </td>
                                            </tr>
                                            <tr id="ar_mh_prog3_Options" runat="server" clientidmode="Static">
                                                <td colspan="18">
                                                    <table id="AROptionRow3" runat="server" width="auto" cellpadding="0" cellspacing="0"
                                                        clientidmode="Static" bgcolor="white" title="AR Options">
                                                        <tbody>
                                                            <tr>
                                                                <td>
                                                                    <input id="Button2" type="button" value="Open Calc Detail" onclick="openCalcDesc(3);" />
                                                                    <asp:Label ID="txt_dwell_AR3_Amount" runat="server" Text="0.00" CssClass="label" Style="display:none" />
                                                                    &nbsp;
                                                                    <asp:Label ID="txt_DedChange_AR3_Amount" runat="server" Text="0.00" CssClass="label" Style="display:none" />
                                                                    <asp:Label ID="txt_Credit_AR3_Amount" runat="server" Text="0.00" CssClass="label" Style="display:none" />
                                                                    &nbsp;
                                                                </td>
                                                            </tr>
                                                            <tr>
                                                                <td align="left">
                                                                    <asp:Label ID="Label137" runat="server" Text="AOP Deductible" CssClass="label" />
                                                                </td>
                                                                <td align="left">
                                                                    <asp:DropDownList ID="dd_aop_AR3" runat="server" TabIndex="22">
                                                                        <asp:ListItem></asp:ListItem>
                                                                        <asp:ListItem>$250</asp:ListItem>
                                                                        <asp:ListItem>$500</asp:ListItem>
                                                                    </asp:DropDownList>
                                                                </td>
                                                            </tr>
                                                            <tr>
                                                                <td align="left">
                                                                    <asp:Label ID="Label138" runat="server" Text="Hurricane Deductible" CssClass="label" />
                                                                </td>
                                                                <td align="left">
                                                                    <asp:DropDownList ID="dd_hurded_AR3" runat="server">
                                                                        <asp:ListItem></asp:ListItem>
                                                                        <asp:ListItem>$500</asp:ListItem>
                                                                        <asp:ListItem>$1000</asp:ListItem>
                                                                        <asp:ListItem>2%</asp:ListItem>
                                                                        <asp:ListItem>5%</asp:ListItem>
                                                                        <asp:ListItem>10%</asp:ListItem>
                                                                    </asp:DropDownList>
                                                                </td>
                                                            </tr>
                                                            <tr>
                                                                <td align="left">
                                                                    <asp:Label ID="Label139" runat="server" Text="Owner Landlord Liability Protection:  "
                                                                        CssClass="label" />
                                                                    &nbsp
                                                                </td>
                                                                <td align="left">
                                                                    <asp:DropDownList ID="dd_pl_AR3" runat="server">
                                                                        <asp:ListItem></asp:ListItem>
                                                                        <asp:ListItem>$25,000</asp:ListItem>
                                                                        <asp:ListItem>$50,000</asp:ListItem>
                                                                        <asp:ListItem>$100,000</asp:ListItem>
                                                                        <asp:ListItem>$300,000</asp:ListItem>
                                                                    </asp:DropDownList>
                                                                     &nbsp;<asp:Label ID="dd_pl_AR3_Amount" runat="server" Text="0.00" CssClass="label" />
                                                                    &nbsp;
                                                                </td>
                                                            </tr>
                                                            <tr>
                                                                <td align="left">
                                                                    <asp:Label ID="Label150" runat="server" Text="Medical payment:  " CssClass="label" />
                                                                    &nbsp
                                                                </td>
                                                                <td align="left">
                                                                    <asp:DropDownList ID="dd_mp_AR3" runat="server">
                                                                        <asp:ListItem></asp:ListItem>
                                                                        <asp:ListItem>$500</asp:ListItem>
                                                                        <asp:ListItem>$1000</asp:ListItem>
                                                                    </asp:DropDownList>
                                                                     &nbsp;<asp:Label ID="dd_med_AR3_amt" runat="server" Text="0.00" CssClass="label" />
                                                                    &nbsp;
                                                                </td>
                                                            </tr>
                                                            <tr>
                                                                <td align="left">
                                                                    <asp:Label ID="Label140" runat="server" Text="Other Structures:  " CssClass="label" />
                                                                    &nbsp
                                                                </td>
                                                                <td align="left">
                                                                    <asp:TextBox ID="txt_unattstr_AR3" runat="server" Text="0.00" AutoCompleteType="DisplayName"
                                                                        Casing="UPPER" ToolTip="Unattached Structure" Width="65" TabIndex="31" />
                                                                        &nbsp;<asp:Label ID="txt_unattstr_AR3_Amount" runat="server" Text="0.00" CssClass="label" />
                                                                    &nbsp;
                                                                </td>
                                                            </tr>
                                                            <tr>
                                                                <td align="left">
                                                                    <asp:Label ID="Label141" runat="server" Text="Contents:  " CssClass="label" />
                                                                    &nbsp
                                                                </td>
                                                                <td align="left">
                                                                    <asp:TextBox ID="txt_pp_AR3" runat="server" Text="0.00" AutoCompleteType="DisplayName"
                                                                        Casing="UPPER" ToolTip="Personal Property" Width="65" TabIndex="31" />
                                                                        &nbsp;<asp:Label ID="txt_pp_AR3_Amount" runat="server" Text="0.00" CssClass="label" />
                                                                    &nbsp;
                                                                </td>
                                                            </tr>
                                                            <tr>
                                                                <td align="left">
                                                                    <asp:Label ID="Label144" runat="server" Text="Additional Limits for Radio & TV Antenna:  "
                                                                        CssClass="label" />
                                                                    &nbsp
                                                                </td>
                                                                <td align="left">
                                                                    <asp:TextBox ID="txt_addlimrad_AR3" runat="server" Text="0.00" AutoCompleteType="DisplayName"
                                                                        Casing="UPPER" ToolTip="Additional Limits for Radio & TV Antenna" Width="65"
                                                                        TabIndex="31" />
                                                                        &nbsp;<asp:Label ID="txt_addlimrad_AR3_Amount" runat="server" Text="0.00" CssClass="label" />
                                                                    &nbsp;
                                                                </td>
                                                            </tr>
                                                            <tr>
                                                                <td align="left">
                                                                    <asp:Label ID="Label145" runat="server" Text="Additional Limits  for Fire Department Service Charge:  "
                                                                        CssClass="label" />
                                                                    &nbsp
                                                                </td>
                                                                <td align="left">
                                                                    <asp:TextBox ID="txt_addlimfir_AR3" runat="server" Text="0.00" AutoCompleteType="DisplayName"
                                                                        Casing="UPPER" ToolTip="Additional Limits for Fire Department Service Charge"
                                                                        Width="65" TabIndex="31" />
                                                                        &nbsp;<asp:Label ID="txt_addlimfir_AR3_Amount" runat="server" Text="0.00" CssClass="label" />
                                                                    &nbsp;
                                                                </td>
                                                            </tr>
                                                            <tr>
                                                                <td id="trmhAROpt3_2" style="display: none" align="left">
                                                                    <asp:Label ID="Label146" runat="server" Text="Secured Interest  Protection:  " CssClass="label" />
                                                                    &nbsp
                                                                    
                                                                </td>
                                                                <td id="trmhAROpt3_2_d" style="display: none;" align="left">
                                                                    <asp:DropDownList ID="dd_sip_AR3" runat="server" TabIndex="19">
                                                                        <asp:ListItem></asp:ListItem>
                                                                        <asp:ListItem>Yes</asp:ListItem>
                                                                        <asp:ListItem>No</asp:ListItem>
                                                                    </asp:DropDownList>
                                                                    &nbsp;<asp:Label ID="dd_sip_AR3_Amount" runat="server" Text="0.00" CssClass="label" />
                                                                    &nbsp;
                                                                </td>
                                                            </tr>
                                                            <tr>
                                                                <td id="trmhAROpt3" style="display: none" align="left">
                                                                    <asp:Label ID="Label147" runat="server" Text="Natural Disaster <br/> Protection:  "
                                                                        CssClass="label" />
                                                                    &nbsp
                                                                        
                                                                </td>
                                                                <td id="trmhAROpt3_d" style="display: none;" align="left">
                                                                    <asp:DropDownList ID="dd_ndp_AR3" runat="server" TabIndex="19">
                                                                        <asp:ListItem></asp:ListItem>
                                                                        <asp:ListItem>Yes</asp:ListItem>
                                                                        <asp:ListItem>No</asp:ListItem>
                                                                    </asp:DropDownList>
                                                                    &nbsp;<asp:Label ID="dd_ndp_AR3_Amount" runat="server" Text="0.00" CssClass="label" />
                                                                    &nbsp;
                                                                </td>
                                                            </tr>
                                                            <tr>
                                                                <td align="left">
                                                                    <asp:Label ID="Label163" runat="server" Text="Supplemental Heating:" CssClass="label" />
                                                                    &nbsp
                                                                </td>
                                                                <td align="left">
                                                                    &nbsp;
                                                                    <asp:Label ID="supHeating_ar3_Amount" runat="server" Text="0.00" CssClass="label" />
                                                                    &nbsp;
                                                                    <asp:Label ID="CEA_ar3_Amount" runat="server" Text="0.00" style="display:none" />
                                                                    &nbsp;
                                                                </td>
                                                            </tr>
                                                            <tr>
                                                                <td align="left">
                                                                    <asp:Button ID="ar3_updateOptions" runat="server" Style="display: none" Text="Update Optional Coverages"
                                                                        OnClick="ar_premiumbtnClick3" />
                                                                </td>
                                                            </tr>
                                                        </tbody>
                                                    </table>
                                                </td>
                                            </tr>
                                            <tr id="AR_Ineligible" style="border: 1px solid black; display: none">
                                                <td align="center" style="border: 1px solid" colspan="12">
                                                    <label id="AR_Errlbl" style="font-size: larger">
                                                    </label>
                                                </td>
                                            </tr>
                                        </tbody>
                                    </table>
                                    <asp:Button ID="ar_premiumbtn" Text="CalcARPremium" runat="server" OnClick="ar_premiumbtnClick"
                                        Style="display: none" />
                                </ContentTemplate>
                                <Triggers>
                                    <asp:AsyncPostBackTrigger ControlID="ar_premiumbtn" EventName="Click" />
                                </Triggers>
                            </asp:UpdatePanel>
                        </td>
                        <td>
                            <asp:Label ID="Label120" Text="0.00" runat="server" Style="display: none"></asp:Label>
                            <asp:Label ID="Label121" Text="0.00" runat="server" Style="display: none"></asp:Label>
                            <asp:Label ID="Label122" Text="0.00" runat="server" Style="display: none"></asp:Label>
                            <asp:Label ID="Label123" Text="0.00" runat="server" Style="display: none"></asp:Label>
                            <asp:Label ID="Label124" Text="0.00" runat="server" Style="display: none"></asp:Label>
                            <asp:Label ID="Label125" Text="0.00" runat="server" Style="display: none"></asp:Label>
                            <asp:Label ID="Label126" Text="0.00" runat="server" Style="display: none"></asp:Label>
                            <asp:Label ID="Label127" Text="0.00" runat="server" Style="display: none"></asp:Label>
                            <asp:Label ID="Label128" Text="0.00" runat="server" Style="display: none"></asp:Label>
                            <asp:Label ID="Label129" Text="0.00" runat="server" Style="display: none"></asp:Label>
                            <asp:Label ID="Label130" Text="0.00" runat="server" Style="display: none"></asp:Label>
                            <asp:Label ID="Label131" Text="0.00" runat="server" Style="display: none"></asp:Label>
                            <asp:Label ID="Label132" Text="0.00" runat="server" Style="display: none"></asp:Label>
                            <asp:Label ID="Label133" Text="0.00" runat="server" Style="display: none"></asp:Label>
                        </td>
                    </tr>
                </tbody>
        </table>
            <!-- END FL AR INFORMATION -->
            <!-- END PREMIUM INFORMATION -->
        </span>
        <!-- HIDDEN CONTENT -->
        <asp:Label ID="lbl_StFactor" runat="server" Style="display: none"></asp:Label>
        <asp:Label ID="lbl_MkFactor" runat="server" Style="display: none"></asp:Label>
        <!--Prior Loss Panel -->
        <asp:Panel ID="pnlPriorLosses" runat="server" CssClass="modalPopup">
            <div style="padding: 5px">
                <table cellpadding="0" cellspacing="0">
                    <tr>
                        <td colspan="9">
                            <asp:Label ID="Label56" runat="server" SkinID="PageTitle" Text="Prior Losses - Claims within the past 5 years" />
                        </td>
                    </tr>
                    <tr>
                        <td>
                            <asp:Label ID="lblLossDateCaption" runat="server" Text="Date of Loss" />
                        </td>
                        <td style="width: 10px">
                        </td>
                        <td>
                            <asp:Label ID="lblLossTypeCaption" runat="server" Text="Loss Type" />
                        </td>
                        <td style="width: 10px">
                        </td>
                        <td>
                            <asp:Label ID="lblLossDescriptionCaption" runat="server" Text="Loss Description" />
                        </td>
                        <td style="width: 10px">
                        </td>
                        <td>
                            <asp:Label ID="lblLossAmtPaidCaption" runat="server" Text="Amt Paid" />
                        </td>
                        <td style="width: 10px">
                        </td>
                        <td>
                            <asp:Label ID="lblLossStatusCaption" runat="server" Text="Damages Repaired?" />
                        </td>
                    </tr>
                    <tr>
                        <td>
                            <asp:TextBox ID="txtLoss1Date" runat="server" DataFieldName="Loss1Date" FriendlyName="Loss 1 date"
                                Width="80px" />
                            <ajaxTK:TextBoxWatermarkExtender ID="TextBoxWatermarkExtender3" runat="server" Enabled="True"
                                TargetControlID="txtLoss1Date" WatermarkCssClass="WatermarkCssClass" WatermarkText="mm/dd/yyyy" />
                        </td>
                        <td>
                        </td>
                        <td>
                            <asp:DropDownList ID="ddLoss1Type" runat="server" TabIndex="10">
                                <asp:ListItem></asp:ListItem>
                                <asp:ListItem>FIRE</asp:ListItem>
                                <asp:ListItem>WATER</asp:ListItem>
                                <asp:ListItem>WIND</asp:ListItem>
                                <asp:ListItem>THEFT</asp:ListItem>
                                <asp:ListItem>VMM</asp:ListItem>
                                <asp:ListItem>LIABILITY</asp:ListItem>
                                <asp:ListItem>OTHER</asp:ListItem>
                            </asp:DropDownList>
                        </td>
                        <td>
                        </td>
                        <td>
                            <asp:TextBox style="text-transform:uppercase" ID="txtLoss1Description" runat="server" Casing="UPPER" Columns="20"
                                FriendlyName="Loss 1 description" Rows="2" TextMode="MultiLine" />
                        </td>
                        <td>
                        </td>
                        <td>
                            <asp:TextBox ID="txtLoss1AmtPaid" runat="server" Columns="8" FormatNamed="Currency"
                                FormatNamedDecimals="0" FriendlyName="Loss 1 amt paid" Text="$0" />
                        </td>
                        <td>
                        </td>
                        <td>
                            <asp:DropDownList ID="ddLoss1Status" runat="server" TabIndex="10">
                                <asp:ListItem></asp:ListItem>
                                <asp:ListItem>No</asp:ListItem>
                                <asp:ListItem>Yes</asp:ListItem>
                            </asp:DropDownList>
                        </td>
                    </tr>
                    <tr>
                        <td>
                            <asp:TextBox ID="txtLoss2Date" runat="server" DataFieldName="Loss2Date" FriendlyName="Loss 1 date"
                                Width="80px" />
                            <ajaxTK:TextBoxWatermarkExtender ID="TextBoxWatermarkExtender9" runat="server" Enabled="True"
                                TargetControlID="txtLoss2Date" WatermarkCssClass="WatermarkCssClass" WatermarkText="mm/dd/yyyy" />
                        </td>
                        <td>
                        </td>
                        <td>
                            <asp:DropDownList ID="ddLoss2Type" runat="server" TabIndex="10">
                                <asp:ListItem></asp:ListItem>
                                <asp:ListItem>FIRE</asp:ListItem>
                                <asp:ListItem>WATER</asp:ListItem>
                                <asp:ListItem>WIND</asp:ListItem>
                                <asp:ListItem>THEFT</asp:ListItem>
                                <asp:ListItem>VMM</asp:ListItem>
                                <asp:ListItem>LIABILITY</asp:ListItem>
                                <asp:ListItem>OTHER</asp:ListItem>
                            </asp:DropDownList>
                        </td>
                        <td>
                        </td>
                        <td>
                            <asp:TextBox style="text-transform:uppercase" ID="txtLoss2Description" runat="server" Casing="UPPER" Columns="20"
                                FriendlyName="Loss 1 description" Rows="2" TextMode="MultiLine" />
                        </td>
                        <td>
                        </td>
                        <td>
                            <asp:TextBox ID="txtLoss2AmtPaid" runat="server" Columns="8" FormatNamed="Currency"
                                FormatNamedDecimals="0" FriendlyName="Loss 1 amt paid" Text="$0" />
                        </td>
                        <td>
                        </td>
                        <td>
                            <asp:DropDownList ID="ddLoss2Status" runat="server" TabIndex="10">
                                <asp:ListItem></asp:ListItem>
                                <asp:ListItem>No</asp:ListItem>
                                <asp:ListItem>Yes</asp:ListItem>
                            </asp:DropDownList>
                        </td>
                    </tr>
                    <tr>
                        <td>
                            <asp:TextBox ID="txtLoss3Date" runat="server" DataFieldName="Loss3Date" FriendlyName="Loss 1 date"
                                Width="80px" />
                            <ajaxTK:TextBoxWatermarkExtender ID="TextBoxWatermarkExtender11" runat="server" Enabled="True"
                                TargetControlID="txtLoss3Date" WatermarkCssClass="WatermarkCssClass" WatermarkText="mm/dd/yyyy" />
                        </td>
                        <td>
                        </td>
                        <td>
                            <asp:DropDownList ID="ddLoss3Type" runat="server" TabIndex="10">
                                <asp:ListItem></asp:ListItem>
                                <asp:ListItem>FIRE</asp:ListItem>
                                <asp:ListItem>WATER</asp:ListItem>
                                <asp:ListItem>WIND</asp:ListItem>
                                <asp:ListItem>THEFT</asp:ListItem>
                                <asp:ListItem>VMM</asp:ListItem>
                                <asp:ListItem>LIABILITY</asp:ListItem>
                                <asp:ListItem>OTHER</asp:ListItem>
                            </asp:DropDownList>
                        </td>
                        <td>
                        </td>
                        <td>
                            <asp:TextBox style="text-transform:uppercase" ID="txtLoss3Description" runat="server" Casing="UPPER" Columns="20"
                                FriendlyName="Loss 1 description" Rows="2" TextMode="MultiLine" />
                        </td>
                        <td>
                        </td>
                        <td>
                            <asp:TextBox ID="txtLoss3AmtPaid" runat="server" Columns="8" FormatNamed="Currency"
                                FormatNamedDecimals="0" FriendlyName="Loss 1 amt paid" Text="$0" />
                        </td>
                        <td>
                        </td>
                        <td>
                            <asp:DropDownList ID="ddLoss3Status" runat="server" TabIndex="10">
                                <asp:ListItem></asp:ListItem>
                                <asp:ListItem>No</asp:ListItem>
                                <asp:ListItem>Yes</asp:ListItem>
                            </asp:DropDownList>
                        </td>
                    </tr>
                    <tr>
                        <td>
                            <asp:LinkButton ID="btnClosePriorLosses" runat="server" Text="Close" Font-Size="Medium" />
                        </td>
                    </tr>
                </table>
            </div>
        </asp:Panel>
        <asp:Panel ID="PremiumCheckerPanel" runat="server" CssClass="modalPopup" Width="100%" Style="display: none">
            <div style="padding: 5px">
                <div style="font-size: 10pt">
                    Premium Confirmation
                </div>
                <table cellpadding="10px" cellspacing="0" style="border: 1px solid black; width: 100%"
                    title="Confirmation Page Details">
                    <tbody>
                        <tr>
                            <td style="color: White; background-color: #4169E1; text-align: center; width: auto;
                                border: 1px solid black;">
                            </td>
                            <td style="color: White; background-color: #4169E1; text-align: center; width: auto;
                                border: 1px solid black;">
                                <asp:Label ID="Label69" runat="server" Text="Dwelling" />
                            </td>
                            <td style="color: White; background-color: #4169E1; text-align: center; width: auto;
                                border: 1px solid black;">
                                <asp:Label ID="Label71" runat="server" Text="Other Structures <br/> Structures" />
                            </td>
                            <td style="color: White; background-color: #4169E1; text-align: center; width: auto;
                                border: 1px solid black;">
                                <asp:Label ID="Label76" runat="server" Text="Contents" />
                            </td>
                            <td style="color: White; background-color: #4169E1; text-align: center; width: auto;
                                border: 1px solid black;">
                                <asp:Label ID="Label77" runat="server" Text="Liability" />
                            </td>
                            <td style="color: White; background-color: #4169E1; text-align: center; width: auto;
                                border: 1px solid black;">
                                <asp:Label ID="Label78" runat="server" Text="Med<br/>Pay" />
                            </td>
                            <td style="color: White; background-color: #4169E1; text-align: center; width: auto;
                                border: 1px solid black;">
                                <asp:Label ID="Label79" runat="server" Text="PP<br/>Replacement<br/>Cost" />
                            </td>
                            <td style="color: White; background-color: #4169E1; text-align: center; width: auto;
                                border: 1px solid black;">
                                <asp:Label ID="Label80" runat="server" Text="MH<br/>Replacement<br/>Cost" />
                            </td>
                        </tr>
                        <tr>
                            <td style="color: Black; background-color: #D3D3D3; text-align: center; width: auto;
                                border: 1px solid black;">
                                <asp:Label ID="Label73" runat="server" Text="Coverages"></asp:Label>
                            </td>
                            <td style="color: Black; background-color: #D3D3D3; text-align: center; width: auto;
                                border: 1px solid black;">
                                <asp:Label ID="lblDwellModTotal_cov" runat="server" Text="0.00"></asp:Label>
                            </td>
                            <td style="color: Black; background-color: #D3D3D3; text-align: center; width: auto;
                                border: 1px solid black;">
                                <asp:Label runat="server" ID="lblUnAttModTotal_cov" Text="0.00"></asp:Label>
                            </td>
                            <td style="color: Black; background-color: #D3D3D3; text-align: center; width: auto;
                                border: 1px solid black;">
                                <asp:Label ID="lblPerPropModTotal_cov" runat="server" Text="0.00"></asp:Label>
                            </td>
                            <td style="color: Black; background-color: #D3D3D3; text-align: center; width: auto;
                                border: 1px solid black;">
                                <asp:Label ID="lblPerLiabModTotal_cov" runat="server" Text="0.00"></asp:Label>
                            </td>
                            <td style="color: Black; background-color: #D3D3D3; text-align: center; width: auto;
                                border: 1px solid black;">
                                <asp:Label ID="lblMedPayModTotal_cov" runat="server" Text="0.00"></asp:Label>
                            </td>
                            <td style="color: Black; background-color: #D3D3D3; text-align: center; width: auto;
                                border: 1px solid black;">
                                <asp:Label ID="lblPPRepModTotal_cov" runat="server" Text="0.00"></asp:Label>
                            </td>
                            <td style="color: Black; background-color: #D3D3D3; text-align: center; width: auto;
                                border: 1px solid black;">
                                <asp:Label ID="lblMHRepModTotal_cov" runat="server" Text="0.00"></asp:Label>
                            </td>
                        </tr>
                        <%--<tr>
                            <td style="color: Black; background-color: #D3D3D3; text-align: center; width: auto;
                                border: 1px solid black;">
                                <asp:Label ID="Label75" runat="server" Text="Premiums"></asp:Label>
                            </td>
                            <td style="color: Black; background-color: #D3D3D3; text-align: center; width: auto;
                                border: 1px solid black;">
                                <asp:Label ID="lblDwellModTotal_amt" runat="server" Text="0.00"></asp:Label>
                            </td>
                            <td style="color: Black; background-color: #D3D3D3; text-align: center; width: auto;
                                border: 1px solid black;">
                                <asp:Label runat="server" ID="lblUnAttModTotal_amt" Text="0.00"></asp:Label>
                            </td>
                            <td style="color: Black; background-color: #D3D3D3; text-align: center; width: auto;
                                border: 1px solid black;">
                                <asp:Label ID="lblPerPropModTotal_amt" runat="server" Text="0.00"></asp:Label>
                            </td>
                            <td style="color: Black; background-color: #D3D3D3; text-align: center; width: auto;
                                border: 1px solid black;">
                                <asp:Label ID="lblPerLiabModTotal_amt" runat="server" Text="0.00"></asp:Label>
                            </td>
                            <td style="color: Black; background-color: #D3D3D3; text-align: center; width: auto;
                                border: 1px solid black;">
                                <asp:Label ID="lblMedPayModTotal_amt" runat="server" Text="0.00"></asp:Label>
                            </td>
                            <td style="color: Black; background-color: #D3D3D3; text-align: center; width: auto;
                                border: 1px solid black;">
                                <asp:Label ID="lblPPRepModTotal_amt" runat="server" Text="0.00"></asp:Label>
                            </td>
                            <td style="color: Black; background-color: #D3D3D3; text-align: center; width: auto;
                                border: 1px solid black;">
                                <asp:Label ID="lblMHRepModTotal_amt" runat="server" Text="0.00"></asp:Label>
                            </td>
                        </tr>--%>
                    </tbody>
                </table>
                <br />
                <table cellpadding="10px" cellspacing="0" style="border: 1px solid black; width: 50%"
                    title="Confirmation Page Total">
                    <tbody>
                        <tr>
                            <td>
                                <asp:Label ID="Label68" runat="server" Text="Base Premium" />
                            </td>
                            <td style="width: 10px">
                                <asp:Label ID="lblPremModTotal" runat="server" Text="0.00"></asp:Label>
                            </td>
                        </tr>
                        <tr>
                            <td>
                                <asp:Label ID="Label2" runat="server" Text="Options" />
                            </td>
                            <td style="width: 10px">
                                <asp:Label ID="lblOptionsModTotal" runat="server" Text="0.00"></asp:Label>
                            </td>
                        </tr>
                        <tr>
                            <td>
                                <asp:Label ID="Label70" runat="server" Text="Fees" />
                            </td>
                            <td style="width: 10px">
                                <asp:Label ID="lblFeeModTotal" runat="server" Text="0.00"></asp:Label>
                            </td>
                        </tr>
                        <tr>
                            <td>
                                <asp:Label ID="Label72" runat="server" Text="Tax" />
                            </td>
                            <td style="width: 10px">
                                <asp:Label ID="lblTaxModTotal" runat="server" Text="0.00"></asp:Label>
                            </td>
                        </tr>
                        <tr>
                            <td>
                                <asp:Label ID="Label74" runat="server" Text="Total Premium" />
                            </td>
                            <td style="width: 10px">
                                <asp:Label ID="lblTotalModTotal" runat="server" Text="0.00"></asp:Label>
                            </td>
                        </tr>
                    </tbody>
                </table>
                <br />
                <asp:Button ID="PremConfCancel" runat="server" CausesValidation="false" Text="Cancel" />
                <input type="button" id="btnRedirect" value="Proceed to App" onclick="ARPremTotalRedirect();" />
                
            </div>
        </asp:Panel>

        <asp:Panel ID="PremiumCalcPanel" runat="server" CssClass="modalPopup" Width="100%">
       
           <div style="padding: 5px">
                <div style="font-size: 10pt">
                    Premium Calculation Confirmation
                    <br />
                    <asp:Label ID="AR1_Debug" runat="server" ClientIDMode="static" Style="display: none"
                        text=""></asp:Label>
                    <asp:Label ID="AR2_Debug" runat="server" ClientIDMode="Static" Style="display: none"
                        Text=""></asp:Label>
                    <asp:Label ID="AR3_Debug" runat="server" ClientIDMode="Static" Style="display: none"
                        Text=""></asp:Label>
                    <br />
                    <asp:LinkButton ID="btnCloseCalc" runat="server" Text="Close" Font-Size="Medium" />
                    <%--<table width="auto" cellpadding="0" cellspacing="0" bgcolor="white">
                    <tbody>
                    <tr>
                        <td align="left">
                            <asp:Label ID="AR1_Debug" runat="server" ClientIDMode="Static" Text=""></asp:Label>
                        </td>
                         
                        <td align="left">
                            <asp:Label ID="AR2_Debug" runat="server" ClientIDMode="Static" Text=""></asp:Label>
                        </td>
                    </tr>
                    <tr>
                        <td>
                             <asp:LinkButton ID="btnCloseCalc" runat="server" Text="Close" Font-Size="Medium" />
                        </td>
                    </tr>
                    </tbody>
                    </table>--%>
                </div>
            </div>

            
                </asp:Panel>
                </tr>
        <!--End Prior Loss Panel-->
        <!-- END HIDDEN CONTENT -->
    </div>
</asp:Content>
<asp:Content ID="Content3" runat="server" contentplaceholderid="head">
    <style type="text/css">
        .style2
        {
            height: 22px;
        }
        .style3
        {
            width: 61px;
        }
    </style>
</asp:Content>

