<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="Niches.ascx.cs" Inherits="GIBS.Modules.Columbarium.Niches" %>


<asp:GridView ID="GridView1" runat="server" AutoGenerateColumns="false" CssClass="table table-striped table-bordered table-list" 
    OnRowDataBound="GridView1_RowDataBound" >

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
            - Section <asp:Label ID="LabelSectionName" runat="server" Text='<%# Eval("SectionName") %>' />
        </ItemTemplate>
    </asp:TemplateField> 


    <asp:TemplateField HeaderText="Purchaser" SortExpression="LastName">
        <ItemTemplate>
            <asp:Label ID="LabelFirstName" runat="server" Text='<%# Bind("FirstName") %>' /> <asp:Label ID="LabelLastName" runat="server" Text='<%# Eval("LastName") %>' />
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
    <asp:BoundField DataField="Price" HeaderText="Price" SortExpression="Price" />    
    <asp:BoundField DataField="AmountPaid" HeaderText="Amount Paid" SortExpression="AmountPaid" />
    
    

        

    </Columns>

</asp:GridView>