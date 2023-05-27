<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="ManageEdit.ascx.cs" Inherits="GIBS.Modules.Columbarium.ManageEdit" %>
<%@ Register TagPrefix="dnn" TagName="Label" Src="~/controls/LabelControl.ascx" %>

<script defer src="https://use.fontawesome.com/releases/v5.5.0/js/all.js" integrity="sha384-GqVMZRt5Gn7tB9D9q7ONtcp4gtHIUEW/yG7h98J7IpE3kpi+srfFyyB/04OV6pG0" crossorigin="anonymous"></script>

<script type="text/javascript" >

    jQuery(function ($) {
        $("#<%= txtCellPhone.ClientID %>").mask("(999) 999-9999");
        $("#<%= txtDayPhone.ClientID %>").mask("(999) 999-9999? x99999");
        $("#<%= txtFaxPhone.ClientID %>").mask("(999) 999-9999");
        $("#<%= txtNightPhone.ClientID %>").mask("(999) 999-9999");



    });


    jQuery(function ($) {
        $("#<%= txtRemains1DOB.ClientID %>").datepicker({
            numberOfMonths: 1,
            format: 'MM/DD/YYYY',
            changeYear: true,
            yearRange: '-110:-0',
            showButtonPanel: false,
            showCurrentAtPos: 0
        });

             $("#<%= txtRemains2DOB.ClientID %>").datepicker({
                 numberOfMonths: 1,
                 format: 'MM/DD/YYYY',
                changeYear: true,
                yearRange: '-110:-0',
                showButtonPanel: false,
                showCurrentAtPos: 0
            });

             $("#<%= txtRemains1DOD.ClientID %>").datepicker({
                 numberOfMonths: 1,
                 format: 'mm/dd/yyyy',
                 changeYear: true,
                 yearRange: '-99:-0',
                 showButtonPanel: false,
                 showCurrentAtPos: 0
             });

             $("#<%= txtRemains2DOD.ClientID %>").datepicker({
                 numberOfMonths: 1,
                 format: 'mm/dd/yyyy',
                changeYear: true,
                yearRange: '-99:-0',
                showButtonPanel: false,
                showCurrentAtPos: 0
            });
        //
             $("#<%= txtDateOfPayment.ClientID %>").datepicker({
                 numberOfMonths: 1,     
                 format: 'mm/dd/yyyy',
                 showButtonPanel: false,
                 showCurrentAtPos: 0
             });

    });

</script>


<style type="text/css">

    .control-label-fontstyle {
    font-weight:bold;
    transition: .5s;
    opacity: .5;
    }

    .nichedetails {
    font-size: 1.4em; 
    }
    .alert-text {
            color: red;
            font-weight:bold;
        }

        .mycheckbox input[type="checkbox"] 
{ 
    margin-right: 5px; 
}

    </style>


<asp:Label ID="lblDebug" runat="server" Text=""></asp:Label>



















<div class="container form" id="ReservationForm" runat="server">


  <div class="row">
        <div class="col-sm-12">
	        
        </div>
    </div>
	  <div class="row">
<div class="col-xs-10 col-sm-6 col-md-6 col-lg-6"><h1>Transaction Details</h1></div>
    <div class="col-xs-10 col-md-2 col-md-offset-2"><div class="btn-group" role="group" aria-label="Update Buttons"><asp:LinkButton ID="LinkButtonUpdate" runat="server" ToolTip="Save" OnClick="LinkButtonUpdate_Click" CssClass="btn btn-lg btn-primary"><i class="fas fa-save fa-lg" aria-hidden="true"></i></asp:LinkButton>
        <asp:LinkButton ID="LinkButtonDelete" runat="server" ToolTip="Delete" Visible="false" CssClass="btn btn-lg btn-default" OnClick="LinkButtonDelete_Click" CausesValidation="false" OnClientClick="javascript:return window.confirm('Do you want to delete this reservation?')"><i class="far fa-trash-alt" aria-hidden="true"></i></asp:LinkButton>
        <asp:LinkButton ID="Btn_Restore" runat="server" ToolTip="Return to Manage Wall" OnClick="Btn_Restore_Click" CssClass="btn btn-lg btn-default" CausesValidation="false"><i class="fa fa-undo" aria-hidden="true"></i></asp:LinkButton></div></div>
  </div>	
	
	<div class="row">

        <div class="col-md-3">
        <div class="well"><div class="nichedetails" id="NicheDetails" runat="server">
<asp:Label ID="lblNicheNumber" runat="server" /><br />
<asp:Label ID="lblNichePrice" runat="server" />
    <br />Payment Status: &nbsp;<asp:Image ID="Image122" runat="server" />
    </div>
        </div>
    </div>

         <div class="form-group col-xs-10 col-sm-2 col-md-2 col-lg-2">			
            <asp:label id="lblDateOfReservation" runat="server" controlname="txtDateOfReservation" Text="Reservation Date" CssClass="control-label control-label-fontstyle" />
            <asp:TextBox ID="txtDateOfReservation" runat="server" CssClass="form-control" />				
            </div>

         <div class="form-group col-xs-10 col-sm-2 col-md-2 col-lg-2">			
            <asp:label id="lblDateOfPayment" runat="server" controlname="txtDateOfPayment" Text="Payment Date" CssClass="control-label control-label-fontstyle" />
            <asp:TextBox ID="txtDateOfPayment" runat="server" CssClass="form-control" />				
            </div>	

        <div class="form-group col-xs-10 col-sm-2 col-md-2 col-lg-2">		
            <asp:label id="lblAmountPaid" runat="server" controlname="txtAmountPaid" Text="Amount Paid" CssClass="control-label control-label-fontstyle" />
            <asp:TextBox ID="txtAmountPaid" runat="server" CssClass="form-control" />				
            </div>	
			
        <div class="form-group col-xs-10 col-sm-6 col-md-8 col-lg-6">			
            <asp:label id="lblInternalNotes" runat="server" controlname="txtInternalNotes" Text="Internal Notes" CssClass="control-label control-label-fontstyle" />
            <asp:TextBox ID="txtInternalNotes" runat="server" CssClass="form-control" TextMode="MultiLine" />				
            </div>			
			
    </div>	


    <div class="row">
        <div class="col-sm-12">
	        <h1>Purchaser Information</h1>
        </div>
    </div>
	<div class="row">
	  
        <div class="form-group col-xs-10 col-sm-2 col-md-2 col-lg-1">
            <asp:Label ID="lblPrefix" runat="server" Text="Salutation" CssClass="control-label control-label-fontstyle" />
            <asp:DropDownList ID="ddlPrefix" runat="server" CssClass="form-control">
                <asp:ListItem Text="" Value="" />
                <asp:ListItem Text="Dr." Value="Dr." />
                <asp:ListItem Text="Dr. & Mrs." Value="Dr. & Mrs." />
                <asp:ListItem Text="Miss" Value="Miss" />
                <asp:ListItem Text="Mr." Value="Mr." />
                <asp:ListItem Text="Mr. & Mrs." Value="Mr. & Mrs." />
                <asp:ListItem Text="Mrs." Value="Mrs." />              
                <asp:ListItem Text="Ms." Value="Ms." />
                <asp:ListItem Text="Rev." Value="Rev." />
            </asp:DropDownList>
        </div>
        <div class="form-group col-xs-10 col-sm-4 col-md-4 col-lg-3">
            <asp:Label ID="lblFirstName" runat="server" Text="First Name" CssClass="control-label control-label-fontstyle" />
            <asp:TextBox ID="txtFirstName" runat="server" CssClass="form-control" /><asp:RequiredFieldValidator ID="RequiredFieldValidator1" runat="server" ErrorMessage="Required!" ControlToValidate="txtFirstName" Display="Dynamic" CssClass="alert-text" />
        </div>
        <div class="form-group col-xs-10 col-sm-1 col-md-1 col-lg-1">
			<asp:label id="lblMiddleInitial" runat="server" controlname="txtMiddleInitial" Text="MI" suffix=":" CssClass="control-label control-label-fontstyle" />
            <asp:TextBox ID="txtMiddleInitial" runat="server" CssClass="form-control" />
        </div>		
		
		
        <div class="form-group col-xs-10 col-sm-4 col-md-4 col-lg-3">
            <asp:label id="lblLastName" runat="server" controlname="txtLastName" Text="Last Name" CssClass="control-label control-label-fontstyle" />
            <asp:TextBox ID="txtLastName" runat="server" CssClass="form-control" /><asp:RequiredFieldValidator ID="RequiredFieldValidator2" runat="server" ErrorMessage="Required!" ControlToValidate="txtLastName" Display="Dynamic" CssClass="alert-text" />
        </div>		
		
        <div class="form-group col-xs-10 col-sm-2 col-md-2 col-lg-1">
			<asp:label id="lblSuffix" runat="server" controlname="ddlSuffix" Text="Suffix" CssClass="control-label control-label-fontstyle" />
            <asp:DropDownList ID="ddlSuffix" runat="server" CssClass="form-control">
                 <asp:ListItem Text="" Value="" />
                <asp:ListItem Text="Jr." Value="Jr." />
                <asp:ListItem Text="Sr." Value="Sr." />
                <asp:ListItem Text="II" Value="II" />
                <asp:ListItem Text="III" Value="III" />
                <asp:ListItem Text="Phd" Value="Phd" />
                <asp:ListItem Text="MD" Value="MD" />
            </asp:DropDownList>
        </div>

    </div>

 <div class="row">
        Additional Purchaser
    </div>
	<div class="row">
	  
        <div class="form-group col-xs-10 col-sm-2 col-md-2 col-lg-1">
            <asp:Label ID="lblPrefix1" runat="server" Text="Salutation" CssClass="control-label control-label-fontstyle" />
            <asp:DropDownList ID="ddlPrefix1" runat="server" CssClass="form-control">
                <asp:ListItem Text="" Value="" />
                <asp:ListItem Text="Dr." Value="Dr." />
                <asp:ListItem Text="Miss" Value="Miss" />
                <asp:ListItem Text="Mr." Value="Mr." />
                <asp:ListItem Text="Mrs." Value="Mrs." />
                <asp:ListItem Text="Ms." Value="Ms." />
                <asp:ListItem Text="Rev." Value="Rev." />
            </asp:DropDownList>
        </div>
        <div class="form-group col-xs-10 col-sm-4 col-md-4 col-lg-3">
            <asp:Label ID="lblFirstName1" runat="server" Text="First Name" controlname="txtFirstName1" CssClass="control-label control-label-fontstyle" />
            <asp:TextBox ID="txtFirstName1" runat="server" CssClass="form-control" MaxLength="30" />
        </div>
        <div class="form-group col-xs-10 col-sm-1 col-md-1 col-lg-1">
			<asp:label id="lblMiddleInitial1" runat="server" controlname="txtMiddleInitial1" Text="MI" suffix=":" CssClass="control-label control-label-fontstyle" />
            <asp:TextBox ID="txtMiddleInitial1" runat="server" CssClass="form-control" MaxLength="10" />
        </div>		
		
		
        <div class="form-group col-xs-10 col-sm-4 col-md-4 col-lg-3">
            <asp:label id="lblLastName1" runat="server" controlname="txtLastName1" Text="Last Name" CssClass="control-label control-label-fontstyle" />
            <asp:TextBox ID="txtLastName1" runat="server" CssClass="form-control" MaxLength="30" />
        </div>		
		
        <div class="form-group col-xs-10 col-sm-2 col-md-2 col-lg-1">
			<asp:label id="lblSuffix1" runat="server" controlname="ddlSuffix1" Text="Suffix" CssClass="control-label control-label-fontstyle" />
            <asp:DropDownList ID="ddlSuffix1" runat="server" CssClass="form-control">
                 <asp:ListItem Text="" Value="" />
                <asp:ListItem Text="Jr." Value="Jr." />
                <asp:ListItem Text="Sr." Value="Sr." />
                <asp:ListItem Text="II" Value="II" />
                <asp:ListItem Text="III" Value="III" />
                <asp:ListItem Text="Phd" Value="Phd" />
                <asp:ListItem Text="MD" Value="MD" />
                <asp:ListItem Text="Esq." Value="Esq." />
                <asp:ListItem Text="Atty." Value="Atty." />
            </asp:DropDownList>
        </div>

    </div>


    <div class="row">
         <div class="form-group col-xs-10 col-sm-9 col-md-9 col-lg-9">
            <asp:label id="lblAddress1" runat="server" controlname="txtAddress1" Text="Address" CssClass="control-label control-label-fontstyle" />
            <asp:TextBox ID="txtAddress1" runat="server" CssClass="form-control" /><asp:RequiredFieldValidator ID="RequiredFieldValidator3" runat="server" ErrorMessage="Required!" ControlToValidate="txtAddress1" Display="Dynamic" CssClass="alert-text" />
            </div>
    </div>

    <div class="row">
         <div class="form-group col-xs-10 col-sm-9 col-md-9 col-lg-9">			
            <asp:label id="lblAddress2" runat="server" controlname="txtAddress2" Text="Address (cont.)" CssClass="control-label control-label-fontstyle" />
            <asp:TextBox ID="txtAddress2" runat="server" CssClass="form-control" />				
            </div>
    </div>	
    
    <div class="row">
         <div class="form-group col-xs-10 col-sm-5 col-md-5 col-lg-5">			
            <asp:label id="lblCity" runat="server" controlname="txtCity" Text="City" CssClass="control-label control-label-fontstyle" />
            <asp:TextBox ID="txtCity" runat="server" CssClass="form-control" /><asp:RequiredFieldValidator ID="RequiredFieldValidator4" runat="server" ErrorMessage="Required!" ControlToValidate="txtCity" Display="Dynamic" CssClass="alert-text" />			
            </div>
         <div class="form-group col-xs-10 col-sm-2 col-md-2 col-lg-2">			
            <asp:label id="Label1" runat="server" controlname="ddlState" Text="State" CssClass="control-label control-label-fontstyle" />
            <asp:DropDownList ID="ddlState" runat="server" CssClass="form-control"></asp:DropDownList><asp:RequiredFieldValidator ID="RequiredFieldValidator5" runat="server" ErrorMessage="Required!" ControlToValidate="ddlState" Display="Dynamic" CssClass="alert-text" InitialValue="" />			
            </div>
         <div class="form-group col-xs-10 col-sm-2 col-md-2 col-lg-2">			
            <asp:label id="lblZipCode" runat="server" controlname="txtZipCode" Text="Zip Code" CssClass="control-label control-label-fontstyle" />
            <asp:TextBox ID="txtZipCode" runat="server" CssClass="form-control" /><asp:RequiredFieldValidator ID="RequiredFieldValidator6" runat="server" ErrorMessage="Required!" ControlToValidate="txtZipCode" Display="Dynamic" CssClass="alert-text" />				
            </div>			
    </div>
    <div class="row">
         <div class="form-group col-xs-10 col-sm-9 col-md-9 col-lg-9">
            <asp:label id="lblEmail" runat="server" controlname="txtEmail" Text="Email Address" CssClass="control-label control-label-fontstyle" />
            <asp:TextBox ID="txtEmail" runat="server" CssClass="form-control" />	
            </div>
    </div>	

    <div class="row">
         <div class="form-group col-xs-10 col-sm-4 col-md-4 col-lg-4">			
            <asp:label id="lblCellPhone" runat="server" controlname="txtCellPhone" Text="Cell Phone" CssClass="control-label control-label-fontstyle" />
            <asp:TextBox ID="txtCellPhone" runat="server" CssClass="form-control" />				
            </div>

         <div class="form-group col-xs-10 col-sm-4 col-md-4 col-lg-4">			
            <asp:label id="lblDayPhone" runat="server" controlname="txtDayPhone" Text="Daytime Phone" CssClass="control-label control-label-fontstyle" />
            <asp:TextBox ID="txtDayPhone" runat="server" CssClass="form-control" />			
            </div>			
    </div>			
	
    <div class="row">
         <div class="form-group col-xs-10 col-sm-4 col-md-4 col-lg-4">			
            <asp:label id="lblNightPhone" runat="server" controlname="txtNightPhone" Text="Home Phone" CssClass="control-label control-label-fontstyle" />
            <asp:TextBox ID="txtNightPhone" runat="server" CssClass="form-control" />				
            </div>

         <div class="form-group col-xs-10 col-sm-4 col-md-4 col-lg-4">			
            <asp:label id="lblFaxPhone" runat="server" controlname="txtFaxPhone" Text="Fax Phone" CssClass="control-label control-label-fontstyle" />
            <asp:TextBox ID="txtFaxPhone" runat="server" CssClass="form-control" />				
            </div>			
    </div>	
    <div class="row">
         <div class="form-group col-xs-10 col-sm-6 col-md-8 col-lg-8">			
            <asp:label id="lblComments" runat="server" controlname="txtComments" Text="Questions or Comments" CssClass="control-label control-label-fontstyle" />
            <asp:TextBox ID="txtComments" runat="server" CssClass="form-control" TextMode="MultiLine" />				
            </div>			
    </div>	



      <div class="row">
        <div class="col-sm-12">
            <asp:CheckBox ID="cbxParishioner" runat="server" Text="I am a Holy Trinity parishioner" TextAlign="Right" CssClass="mycheckbox" /><br />
            <asp:CheckBox ID="cbxHasDonated" runat="server" Text="I made a pledge to Holy Trinity last year" TextAlign="Right" CssClass="mycheckbox" /><br />
            <asp:CheckBox ID="cbxHasAncestor" runat="server" Text="I have an ancestor buried at Holy Rood" TextAlign="Right" CssClass="mycheckbox" />   <asp:TextBox ID="txtAncestorName" runat="server"></asp:TextBox>
            
            </div>
      </div>	

<asp:Panel ID="PanelRemains" runat="server">

      <div class="row">
        <div class="col-sm-12">
	        <h1>Remains 1</h1>
        </div>
    </div>
	<div class="row">
	  
        <div class="form-group col-xs-10 col-sm-2 col-md-2 col-lg-1">
            <asp:Label ID="lblPrefixR1" runat="server" Text="Salutation" CssClass="control-label control-label-fontstyle" />
            <asp:DropDownList ID="ddlPrefixR1" runat="server" CssClass="form-control">
                <asp:ListItem Text="" Value="" />
                <asp:ListItem Text="Dr." Value="Dr." />
                <asp:ListItem Text="Miss" Value="Miss" />
                <asp:ListItem Text="Mr." Value="Mr." />
                <asp:ListItem Text="Mrs." Value="Mrs." />
                <asp:ListItem Text="Ms." Value="Ms." />
                <asp:ListItem Text="Rev." Value="Rev." />
            </asp:DropDownList>
        </div>
        <div class="form-group col-xs-10 col-sm-4 col-md-4 col-lg-3">
            <asp:Label ID="lblFirstNameR1" runat="server" Text="First Name" CssClass="control-label control-label-fontstyle" />
            <asp:TextBox ID="txtFirstNameR1" runat="server" CssClass="form-control" />
        </div>
        <div class="form-group col-xs-10 col-sm-1 col-md-1 col-lg-1">
			<asp:label id="lblMiddleInitialR1" runat="server" controlname="txtMiddleInitialR1" Text="MI" suffix=":" CssClass="control-label control-label-fontstyle" />
            <asp:TextBox ID="txtMiddleInitialR1" runat="server" CssClass="form-control" />
        </div>		
		
		
        <div class="form-group col-xs-10 col-sm-4 col-md-4 col-lg-3">
            <asp:label id="lblLastNameR1" runat="server" controlname="txtLastNameR1" Text="Last Name" CssClass="control-label control-label-fontstyle" />
            <asp:TextBox ID="txtLastNameR1" runat="server" CssClass="form-control" />
        </div>		
		
        <div class="form-group col-xs-10 col-sm-2 col-md-2 col-lg-1">
			<asp:label id="lblSuffixR1" runat="server" controlname="ddlSuffixR1" Text="Suffix" CssClass="control-label control-label-fontstyle" />
            <asp:DropDownList ID="ddlSuffixR1" runat="server" CssClass="form-control">
                 <asp:ListItem Text="" Value="" />
                <asp:ListItem Text="Jr." Value="Jr." />
                <asp:ListItem Text="Sr." Value="Sr." />
                <asp:ListItem Text="II" Value="II" />
                <asp:ListItem Text="III" Value="III" />
                <asp:ListItem Text="Phd" Value="Phd" />
                <asp:ListItem Text="MD" Value="MD" />
            </asp:DropDownList>
        </div>

    </div>

    	    <div class="row">
         <div class="form-group col-xs-10 col-sm-3 col-md-3 col-lg-3">			
            <asp:label id="lblRemains1DOB" runat="server" controlname="txtRemains1DOB" Text="Date of Birth" CssClass="control-label control-label-fontstyle" />
            <asp:TextBox ID="txtRemains1DOB" runat="server" CssClass="form-control" />				
            </div>

         <div class="form-group col-xs-10 col-sm-3 col-md-3 col-lg-3">			
            <asp:label id="lblRemains1CityOfBirth" runat="server" controlname="txtRemains1CityOfBirth" Text="Birth City" CssClass="control-label control-label-fontstyle" />
            <asp:TextBox ID="txtRemains1CityOfBirth" runat="server" CssClass="form-control" />				
            </div>	

         <div class="form-group col-xs-10 col-sm-3 col-md-3 col-lg-3">			
            <asp:label id="lblRemains1StateOfBirth" runat="server" controlname="txtRemains1StateOfBirth" Text="State" CssClass="control-label control-label-fontstyle" />
            <asp:TextBox ID="txtRemains1StateOfBirth" runat="server" CssClass="form-control" MaxLength="2" />				
            </div>	
			
    </div>	
	
	
	    <div class="row">
         <div class="form-group col-xs-10 col-sm-3 col-md-3 col-lg-3">			
            <asp:label id="lblRemains1DOD" runat="server" controlname="txtRemains1DOD" Text="Date of Death" CssClass="control-label control-label-fontstyle" />
            <asp:TextBox ID="txtRemains1DOD" runat="server" CssClass="form-control" />				
            </div>

         <div class="form-group col-xs-10 col-sm-3 col-md-3 col-lg-3">			
            <asp:label id="lblRemains1CityOfDeath" runat="server" controlname="txtRemains1CityOfDeath" Text="City of Death" CssClass="control-label control-label-fontstyle" />
            <asp:TextBox ID="txtRemains1CityOfDeath" runat="server" CssClass="form-control" />				
            </div>	

         <div class="form-group col-xs-10 col-sm-3 col-md-3 col-lg-3">			
            <asp:label id="lblRemains1StateOfDeath" runat="server" controlname="txtRemains1StateOfDeath" Text="State" CssClass="control-label control-label-fontstyle" />
            <asp:TextBox ID="txtRemains1StateOfDeath" runat="server" CssClass="form-control" MaxLength="2" />				
            </div>	
			
    </div>	
    	        <div class="row">
         <div class="form-group col-xs-10 col-sm-6 col-md-8 col-lg-8">			
            <asp:label id="lblRemains1Obituary" runat="server" controlname="txtRemains1Obituary" Text="Obituary" CssClass="control-label control-label-fontstyle" />
            <asp:TextBox ID="txtRemains1Obituary" runat="server" CssClass="form-control" TextMode="MultiLine" />				
            </div>	
</div>
  <div class="row">
        <div class="col-sm-12">
	        <h1>Remains 2</h1>
        </div>
    </div>
	<div class="row">
	  
        <div class="form-group col-xs-10 col-sm-2 col-md-2 col-lg-1">
            <asp:Label ID="lblPrefixR2" runat="server" Text="Salutation" CssClass="control-label control-label-fontstyle" />
            <asp:DropDownList ID="ddlPrefixR2" runat="server" CssClass="form-control">
                <asp:ListItem Text="" Value="" />
                <asp:ListItem Text="Dr." Value="Dr." />
                <asp:ListItem Text="Miss" Value="Miss" />
                <asp:ListItem Text="Mr." Value="Mr." />
                <asp:ListItem Text="Mrs." Value="Mrs." />
                <asp:ListItem Text="Ms." Value="Ms." />
                <asp:ListItem Text="Rev." Value="Rev." />
            </asp:DropDownList>
        </div>
        <div class="form-group col-xs-10 col-sm-4 col-md-4 col-lg-3">
            <asp:Label ID="lblFirstNameR2" runat="server" Text="First Name" CssClass="control-label control-label-fontstyle" />
            <asp:TextBox ID="txtFirstNameR2" runat="server" CssClass="form-control" />
        </div>
        <div class="form-group col-xs-10 col-sm-1 col-md-1 col-lg-1">
			<asp:label id="lblMiddleInitialR2" runat="server" controlname="txtMiddleInitialR2" Text="MI" suffix=":" CssClass="control-label control-label-fontstyle" />
            <asp:TextBox ID="txtMiddleInitialR2" runat="server" CssClass="form-control" />
        </div>		
		
		
        <div class="form-group col-xs-10 col-sm-4 col-md-4 col-lg-3">
            <asp:label id="lblLastNameR2" runat="server" controlname="txtLastNameR2" Text="Last Name" CssClass="control-label control-label-fontstyle" />
            <asp:TextBox ID="txtLastNameR2" runat="server" CssClass="form-control" />
        </div>		
		
        <div class="form-group col-xs-10 col-sm-2 col-md-2 col-lg-1">
			<asp:label id="lblSuffixR2" runat="server" controlname="ddlSuffixR2" Text="Suffix" CssClass="control-label control-label-fontstyle" />
            <asp:DropDownList ID="ddlSuffixR2" runat="server" CssClass="form-control">
                 <asp:ListItem Text="" Value="" />
                <asp:ListItem Text="Jr." Value="Jr." />
                <asp:ListItem Text="Sr." Value="Sr." />
                <asp:ListItem Text="II" Value="II" />
                <asp:ListItem Text="III" Value="III" />
                <asp:ListItem Text="Phd" Value="Phd" />
                <asp:ListItem Text="MD" Value="MD" />
            </asp:DropDownList>
        </div>

    </div>

    <div class="row">
         <div class="form-group col-xs-10 col-sm-3 col-md-3 col-lg-3">			
            <asp:label id="lblRemains2DOB" runat="server" controlname="txtRemains2DOB" Text="Date of Birth" CssClass="control-label control-label-fontstyle" />
            <asp:TextBox ID="txtRemains2DOB" runat="server" CssClass="form-control" />				
            </div>

         <div class="form-group col-xs-10 col-sm-3 col-md-3 col-lg-3">			
            <asp:label id="lblRemains2CityOfBirth" runat="server" controlname="txtRemains2CityOfBirth" Text="Birth City" CssClass="control-label control-label-fontstyle" />
            <asp:TextBox ID="txtRemains2CityOfBirth" runat="server" CssClass="form-control" />				
            </div>	

         <div class="form-group col-xs-10 col-sm-3 col-md-3 col-lg-3">			
            <asp:label id="lblRemains2StateOfBirth" runat="server" controlname="txtRemains2StateOfBirth" Text="State" CssClass="control-label control-label-fontstyle" />
            <asp:TextBox ID="txtRemains2StateOfBirth" runat="server" CssClass="form-control" MaxLength="2" />				
            </div>	
			
    </div>	
	
	
    <div class="row">
         <div class="form-group col-xs-10 col-sm-3 col-md-3 col-lg-3">			
            <asp:label id="lblRemains2DOD" runat="server" controlname="txtRemains2DOD" Text="Date of Death" CssClass="control-label control-label-fontstyle" />
            <asp:TextBox ID="txtRemains2DOD" runat="server" CssClass="form-control" />				
            </div>

         <div class="form-group col-xs-10 col-sm-3 col-md-3 col-lg-3">			
            <asp:label id="lblRemains2CityOfDeath" runat="server" controlname="txtRemains2CityOfDeath" Text="City of Death" CssClass="control-label control-label-fontstyle" />
            <asp:TextBox ID="txtRemains2CityOfDeath" runat="server" CssClass="form-control" />				
            </div>	

         <div class="form-group col-xs-10 col-sm-3 col-md-3 col-lg-3">			
            <asp:label id="lblRemains2StateOfDeath" runat="server" controlname="txtRemains2StateOfDeath" Text="State" CssClass="control-label control-label-fontstyle" />
            <asp:TextBox ID="txtRemains2StateOfDeath" runat="server" CssClass="form-control" MaxLength="2" />				
            </div>	
			
    </div>	

                    		        <div class="row">
         <div class="form-group col-xs-10 col-sm-6 col-md-8 col-lg-8">			
            <asp:label id="lblRemains2Obituary" runat="server" controlname="txtRemains2Obituary" Text="Obituary" CssClass="control-label control-label-fontstyle" />
            <asp:TextBox ID="txtRemains2Obituary" runat="server" CssClass="form-control" TextMode="MultiLine" />				
            </div>	
</div>


</asp:Panel>

	<div class="row">
		<div class="col-sm-8">
            <asp:LinkButton ID="btnSubmit" runat="server" CssClass="btn btn-lg btn-primary" OnClick="btnSubmit_Click">Update</asp:LinkButton>
			<asp:LinkButton ID="btnCancel" runat="server" CssClass="btn btn-lg btn-default" CausesValidation="false" OnClick="btnCancel_Click">Cancel</asp:LinkButton>
		</div>
	</div>
</div>
<asp:HiddenField ID="HiddenFieldNicheID" runat="server" Value="0" />
<asp:HiddenField ID="HiddenFieldPurchaserID" runat="server" Value="0" />
<asp:HiddenField ID="HiddenFieldPrice" runat="server" />

