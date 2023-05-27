<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="Settings.ascx.cs" Inherits="GIBS.Modules.Columbarium.Settings" %>
<%@ Register TagPrefix="dnn" TagName="Label" Src="~/controls/LabelControl.ascx" %>
<%@ Register TagPrefix="dnn" TagName="SectionHead" Src="~/controls/SectionHeadControl.ascx" %>
<%@ Register TagPrefix="dnn" Assembly="DotNetNuke.Web" Namespace="DotNetNuke.Web.UI.WebControls" %>

<div class="dnnForm" id="form-settings">

    <fieldset>

<dnn:sectionhead id="sectGeneralSettings" cssclass="Head" runat="server" text="General Settings" section="GeneralSection"
	includerule="False" isexpanded="True"></dnn:sectionhead>

<div id="GeneralSection" runat="server">   
            
                    
                    		
	<div class="dnnFormItem">					
	<dnn:label id="lblPageSize" runat="server" controlname="ddlPageSize" suffix=":"></dnn:label>
	<asp:DropDownList ID="ddlPageSize" runat="server">
		<asp:ListItem Text="2" Value="2"></asp:ListItem>
		<asp:ListItem Text="5" Value="5"></asp:ListItem>
		<asp:ListItem Text="10" Value="10"></asp:ListItem>
		<asp:ListItem Text="20" Value="20"></asp:ListItem>
			<asp:ListItem Text="30" Value="30"></asp:ListItem>
		<asp:ListItem Text="40" Value="40"></asp:ListItem>
		<asp:ListItem Text="50" Value="50"></asp:ListItem>
		<asp:ListItem Text="100" Value="100"></asp:ListItem>
		</asp:DropDownList>			
				
	</div>	

	<div class="dnnFormItem">
    
        <dnn:label id="lblManagerRole" runat="server" controlname="ddlRoles" suffix=":"></dnn:label>
        <asp:DropDownList ID="ddlRoles" runat="server" datavaluefield="RoleName" datatextfield="RoleName">
        </asp:DropDownList>
	</div>

  	<div class="dnnFormItem">
        <dnn:label id="lblDisplayRemains" runat="server" controlname="CbxDisplayRemains" suffix=":" />
          <asp:CheckBox ID="CbxDisplayRemains" runat="server" />
	</div>

  	<div class="dnnFormItem">
        <dnn:label id="lblShowPriceOnCheckout" runat="server" controlname="CbxShowPriceOnCheckout" suffix=":" />
          <asp:CheckBox ID="CbxShowPriceOnCheckout" runat="server" />
	</div>

  	<div class="dnnFormItem">
        <dnn:label id="lblEnableDiscount" runat="server" controlname="CbxEnableDiscount" suffix=":" />
          <asp:CheckBox ID="CbxEnableDiscount" runat="server" />
	</div>


	<div class="dnnFormItem">
        <dnn:label id="lblEmailFrom" runat="server" controlname="txtEmailFrom" suffix=":"></dnn:label>
        <asp:TextBox ID="txtEmailFrom" width="320" cssclass="NormalTextBox" runat="server"></asp:TextBox>
	</div>

 	<div class="dnnFormItem">
        <dnn:label id="lblEmailNotify" runat="server" controlname="txtEmailNotify" suffix=":"></dnn:label>
        <asp:TextBox ID="txtEmailNotify" width="320" cssclass="NormalTextBox" runat="server"></asp:TextBox>
	</div>

	<div class="dnnFormItem">
        <dnn:label id="lblEmailBCC" runat="server" controlname="txtEmailBCC" suffix=":"></dnn:label>
        <asp:TextBox ID="txtEmailBCC" width="320" cssclass="NormalTextBox" runat="server"></asp:TextBox>
	</div>

	<div class="dnnFormItem">
        <dnn:label id="lblEmailSubject" runat="server" controlname="txtEmailSubject" suffix=":"></dnn:label>
        <asp:TextBox ID="txtEmailSubject" width="320" cssclass="NormalTextBox" runat="server"></asp:TextBox>
	</div>

	<div class="dnnFormItem">
        <dnn:label id="lblEmailMessage" runat="server" controlname="txtEmailMessage" suffix=":"></dnn:label>
        <asp:TextBox ID="txtEmailMessage" runat="server" Columns="30" Height="120px" TextMode="MultiLine"></asp:TextBox>
	</div>


	<div class="dnnFormItem">
        <dnn:Label runat="server" ID="lblImagePath" ControlName="txtImagePath" ResourceKey="lblImagePath" Suffix=":" />
        <asp:Textbox ID="txtImagePath" runat="server" />
           
     </div>	
	 
    <div class="dnnFormItem">
        <dnn:Label runat="server" ID="lblWallImage" ControlName="txtWallImage" ResourceKey="lblWallImage" Suffix=":" />
       <asp:Textbox ID="txtWallImage" runat="server" />
          
     </div>
     <div class="dnnFormItem">
        <dnn:Label runat="server" ID="lblSelectWallImage" ControlName="fpPictureWallImage" ResourceKey="lblSelectWallImage" Suffix=":" />
		 <dnn:dnnfilepicker runat="server" id="fpPictureWallImage" filefilter="jpg,png" />
</div>		
	
    <div class="dnnFormItem">
        <dnn:Label runat="server" ID="lbljQueryUI" ControlName="txtjQueryUI" ResourceKey="lbljQueryUI" Suffix=":" />
        <asp:Textbox ID="txtjQueryUI" runat="server" />
           
     </div>	

 </div>
        
        
        
<dnn:sectionhead id="Sectionhead1" cssclass="Head" runat="server" text="Report Server Settings" section="ReportServerSection"
	includerule="False" isexpanded="False"></dnn:sectionhead>

<div id="ReportServerSection" runat="server">   

     <div class="dnnFormItem">					
    <dnn:label id="lblurlReportServer" runat="server" suffix=":" controlname="txturlReportServer" ResourceKey="lblurlReportServer" />
         <asp:TextBox ID="txturlReportServer" runat="server" />		
    </div>
 
      <div class="dnnFormItem">					
    <dnn:label id="lblReportPath" runat="server" suffix=":" controlname="txtReportPath" ResourceKey="lblReportPath" />
         <asp:TextBox ID="txtReportPath" runat="server" />		
    </div>
 
      <div class="dnnFormItem">					
    <dnn:label id="lblRSCredentialsUserName" runat="server" suffix=":" controlname="txtRSCredentialsUserName" ResourceKey="lblRSCredentialsUserName" />
         <asp:TextBox ID="txtRSCredentialsUserName" runat="server" />		
    </div>



     <div class="dnnFormItem">					
    <dnn:label id="lblRSCredentialsPassword" runat="server" suffix=":" controlname="txtRSCredentialsPassword" ResourceKey="lblRSCredentialsPassword" />
         <asp:TextBox ID="txtRSCredentialsPassword" runat="server" />		
    </div>



     <div class="dnnFormItem">					
    <dnn:label id="lblRSCredentialsDomain" runat="server" suffix=":" controlname="txtRSCredentialsDomain" ResourceKey="lblRSCredentialsDomain" />
         <asp:TextBox ID="txtRSCredentialsDomain" runat="server" />		
    </div>

</div>        			


    </fieldset>

</div>