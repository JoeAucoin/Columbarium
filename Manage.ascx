<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="Manage.ascx.cs" Inherits="GIBS.Modules.Columbarium.Manage" %>



<script defer src="https://use.fontawesome.com/releases/v5.5.0/js/all.js" integrity="sha384-GqVMZRt5Gn7tB9D9q7ONtcp4gtHIUEW/yG7h98J7IpE3kpi+srfFyyB/04OV6pG0" crossorigin="anonymous"></script>

<script type="text/javascript"> 

    jQuery(function ($) {
        $("#<%= txtLastName.ClientID %>").Watermark("Purchaser Last Name");

        });

</script>


<style type='text/css'>
    .SectionTitle {
        font-size:1.3em;
        font-weight:bold;
    }

    .SectionImage {
    padding-top:15px;
    }

    .formBox{
	margin-top: 90px;
	padding: 50px;
}
    </style>

<asp:Label ID="lblDebug" runat="server" Text=""></asp:Label>

<div class="container">


  <div class="row"><div class="col-xs-10 col-sm-1 col-md-1 col-lg-1">
    <asp:LinkButton ID="LinkButtonShowPendingNew" runat="server" OnClick="LinkButtonShowPending_Click" CssClass="btn btn-lg btn-default">List Pending</asp:LinkButton></div>
    <div class="col-md-3 col-md-offset-3"><asp:TextBox ID="txtLastName" runat="server" CssClass="input-lg"></asp:TextBox></div>
    <div class="col-md-3 col-md-offset-0"><div class="btn-group"><asp:LinkButton ID="LinkButton1Search" runat="server" OnClick="BtnSearch_Click" CssClass="btn btn-lg btn-primary"><i class="fa fa-search fa-lg" aria-hidden="true"></i></asp:LinkButton>
        <asp:LinkButton ID="btn_Restore" runat="server" OnClick="Btn_Restore_Click" CssClass="btn btn-lg btn-default"><i class="fa fa-undo" aria-hidden="true"></i></asp:LinkButton>
        <asp:LinkButton ID="Btn_ExitAdmin" runat="server" CssClass="btn btn-lg btn-default" OnClick="Btn_ExitAdmin_Click">Exit</asp:LinkButton>
                                          </div></div>
  </div>




<div class="row" id="WallAndImages" runat="server">


<p style="text-align:center;">

   
<asp:Image ID="ImageWall" runat="server" />

    <map name="image-map">
    <area href="?DisplaySection=1" alt=" Section A" title="Section A" coords="13,2,142,116" shape="rect">
    <area href="?DisplaySection=2" alt="Section B" title="Section B" coords="148,2,272,114" shape="rect">
    <area href="?DisplaySection=3" alt="Section C" title="Section C" coords="279,1,403,115" shape="rect">
    <area href="?DisplaySection=4" alt="Section D" title="Section D" coords="407,2,534,115" shape="rect">
    <area href="?DisplaySection=5" alt="Section E" title="Section E" coords="538,2,665,116" shape="rect">
    <area href="?DisplaySection=6" alt="Section F" title="Section F" coords="668,1,796,113" shape="rect">
    <area href="?DisplaySection=7" alt="Section G" title="Section G" coords="801,0,931,115" shape="rect">
    <area href="?DisplaySection=8" alt="Crypt" title="Crypt" coords="982,0,1070,116" shape="rect">
</map>

<br>Display: 
<asp:DropDownList ID="ddlDisplaySection" runat="server" OnTextChanged="ddlDisplaySection_TextChanged" AutoPostBack="true" Font-Names="Verdana" Font-Size="Large"></asp:DropDownList>

<br />
    <asp:Image ID="ImageNicheSection" runat="server" CssClass="SectionImage" />

    </p>



<div style="width:100%; text-align:center; padding-bottom:15px;">

    <asp:Label ID="lblSectionTitle" runat="server" Text="" CssClass="SectionTitle" /><br />

    <asp:DataList ID="DataList1" runat="server" OnItemDataBound="DataList1_ItemDataBound" RepeatLayout="Flow" RepeatDirection="Horizontal" >
        <ItemTemplate>
            
            <asp:HyperLink ID="HyperLinkBookNiche" runat="server">
            <asp:Image ID="vImage" runat="server" /></asp:HyperLink>
        </ItemTemplate>
    </asp:DataList>



</div>

<div class="container-fluid col-md-6 col-md-offset-3 text-center">
    <asp:Label ID="lblTotalNiches" runat="server" Text=""></asp:Label><br />
    <asp:Label ID="lblNumberPerRow" runat="server" Text=""></asp:Label>
</div>

</div>

    </div>

<asp:GridView ID="GridView1" runat="server" AutoGenerateColumns="false" CssClass="table table-striped table-bordered table-list" OnRowDataBound="GridView1_RowDataBound" >

<Columns>
     
        <asp:TemplateField HeaderText="Edit" ItemStyle-HorizontalAlign="Center" >
         <ItemTemplate>
           <asp:HyperLink ID="HyperLinkEdit" runat="server"><asp:image ID="imgEdit" runat="server" imageurl="~/DesktopModules/Columbarium/images/edit-32.png" AlternateText="Edit Record" /></asp:HyperLink>
         </ItemTemplate>
       </asp:TemplateField>


	<asp:TemplateField HeaderText="Paid" ItemStyle-HorizontalAlign="Center" >
            <ItemTemplate>
                <asp:Image ID="Image122" runat="server" ImageUrl='<%# (Convert.ToBoolean(Eval("isPaid")) ? this.TemplateSourceDirectory + "/images/yes.png" : this.TemplateSourceDirectory + "/images/no.png")%>' />
            </ItemTemplate>
    </asp:TemplateField>    
    
    <asp:TemplateField HeaderText="Niche">
        <ItemTemplate>Niche <asp:Label ID="LabelNicheNumber" runat="server" Text='<%# Bind("NicheNumber") %>' /> 
            - <asp:Label ID="LabelSectionName" runat="server" Text='<%# Eval("SectionName") %>' />
        </ItemTemplate>
    </asp:TemplateField> 

    <asp:TemplateField HeaderText="Purchaser" SortExpression="LastName">
        <ItemTemplate>
            <asp:Label ID="LabelBuyer1" runat="server" Text='<%# Bind("Buyer1") %>' /> 
            <%# (String.IsNullOrEmpty(Eval("Buyer2").ToString()) ? String.Format("") : String.Format("<br />")) %>
             <asp:Label ID="LabelBuyer2" runat="server" Text='<%# Bind("Buyer2") %>' />
            <br /><asp:Label ID="LabelAddress1" runat="server" Text='<%# Bind("Address1") %>' />
            <br /><asp:Label ID="LabelCity" runat="server" Text='<%# Bind("City") %>' /> <asp:Label ID="Label5" runat="server" Text='<%# Bind("State") %>' /> <asp:Label ID="Label6" runat="server" Text='<%# Bind("Zip") %>' />
            <br /><asp:Label ID="LabelEmail" runat="server" Text='<%# Bind("Email") %>' />
       </ItemTemplate>

    </asp:TemplateField>
      <asp:TemplateField HeaderText="Phone Numbers">
        <ItemTemplate>
           <asp:Label ID="Label11" runat="server" Visible='<%# Eval("phone_day").ToString().Length > 0 %>' Text="Daytime: " /><asp:Label ID="LabelDayPhone" runat="server" Text='<%# Bind("phone_day") %>' /> 
            <br /><asp:Label ID="Label10" runat="server" Visible='<%# Eval("phone_cell").ToString().Length > 0 %>' Text="Cell: " /><asp:Label ID="Label2" runat="server" Text='<%# Eval("phone_cell") %>' />
            <br /><asp:Label ID="Label9" runat="server" Visible='<%# Eval("phone_eve").ToString().Length > 0 %>' Text="Evening: " /><asp:Label ID="Label3" runat="server" Text='<%# Bind("phone_eve") %>' />
            <br /><asp:Label ID="Label8" runat="server" Visible='<%# Eval("phone_fax").ToString().Length > 0 %>' Text="Fax: " /><asp:Label ID="Label4" runat="server" Text='<%# Bind("phone_fax") %>' /> 
        </ItemTemplate>

    </asp:TemplateField>  


	<asp:TemplateField HeaderText="Parishioner" ItemStyle-HorizontalAlign="Center" >
            <ItemTemplate>
                <asp:Image ID="Image1223" runat="server" ImageUrl='<%# (Convert.ToBoolean(Eval("Parishioner")) ? this.TemplateSourceDirectory + "/images/yes.png" : this.TemplateSourceDirectory + "/images/spacer.gif")%>' />
            </ItemTemplate>
    </asp:TemplateField>   
    

	<asp:TemplateField HeaderText="HasDonated" ItemStyle-HorizontalAlign="Center" >
            <ItemTemplate>
                <asp:Image ID="Image12a" runat="server" ImageUrl='<%# (Convert.ToBoolean(Eval("HasDonated")) ? this.TemplateSourceDirectory + "/images/yes.png" : this.TemplateSourceDirectory + "/images/spacer.gif")%>' />
            </ItemTemplate>
    </asp:TemplateField>  

	<asp:TemplateField HeaderText="HasAncestor" ItemStyle-HorizontalAlign="Center" >
            <ItemTemplate>
                <asp:Image ID="Image12b" runat="server" ImageUrl='<%# (Convert.ToBoolean(Eval("HasAncestor")) ? this.TemplateSourceDirectory + "/images/yes.png" : this.TemplateSourceDirectory + "/images/spacer.gif")%>' />
            </ItemTemplate>
    </asp:TemplateField>  
     
    <asp:BoundField DataField="Price" HeaderText="Price" SortExpression="Price" />    
    <asp:BoundField DataField="AmountPaid" HeaderText="Amount Paid" SortExpression="AmountPaid" />
    
    

        

    </Columns>

</asp:GridView>




