<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="Sections.ascx.cs" Inherits="GIBS.Modules.Columbarium.Sections" %>

<link rel="stylesheet" href="https://use.fontawesome.com/releases/v5.5.0/css/all.css" integrity="sha384-B4dIYHKNBt8Bc12p+WXckhzcICo0wtJAoU8YZTY5qE0Id1GSseTk6S+L3BlXeVIU" crossorigin="anonymous">
<style type="text/css">

    .control-label-fontstyle {
    font-weight:bold;
    transition: .5s;
    opacity: .5;
    }

    .alert-text {
            color: red;
            font-weight:bold;
        }


    </style>


<asp:Label ID="LblDebug" runat="server" Text="" CssClass="wall" />


<div class="container form">

 
        <div class="row">
         <div class="form-group col-xs-10 col-sm-3 col-md-3 col-lg-3">			
            <asp:label id="lblSectionName" runat="server" controlname="txtSectionName" Text="Section Name" CssClass="control-label control-label-fontstyle" />
            <asp:TextBox ID="txtSectionName" runat="server" CssClass="form-control" MaxLength="20" />				
            </div>

         <div class="form-group col-xs-10 col-sm-1 col-md-1 col-lg-1">			
            <asp:label id="lblNumberOfRows" runat="server" controlname="txtNumberOfRows" Text="Rows" CssClass="control-label control-label-fontstyle" />
            <asp:TextBox ID="txtNumberOfRows" runat="server" CssClass="form-control" MaxLength="20" />				
            </div>	

         <div class="form-group col-xs-10 col-sm-1 col-md-1 col-lg-1">	
            <asp:label id="lblNumberOfColumns" runat="server" controlname="txtNumberOfColumns" Text="Columns" CssClass="control-label control-label-fontstyle" />
            <asp:TextBox ID="txtNumberOfColumns" runat="server" CssClass="form-control" MaxLength="20" />				
            </div>	

         <div class="form-group col-xs-10 col-sm-3 col-md-3 col-lg-3">			
            <asp:label id="lblPhoto" runat="server" controlname="txtPhoto" Text="Photo" CssClass="control-label control-label-fontstyle" />
            <asp:TextBox ID="txtPhoto" runat="server" CssClass="form-control" />				
            </div>

         <div class="form-group col-xs-10 col-sm-2 col-md-2 col-lg-2">			
<div class="btn-group" role="group" aria-label="Add Buttons"><asp:LinkButton ID="LinkButtonSave" runat="server" OnClick="LinkButtonSave_Click" CssClass="btn btn-lg btn-primary"><i class="fas fa-save fa-lg" aria-hidden="true"></i></asp:LinkButton>
        
        <asp:LinkButton ID="Btn_Return" runat="server" OnClick="Btn_Return_Click" CssClass="btn btn-lg btn-default" CausesValidation="false"><i class="fa fa-undo" aria-hidden="true"></i></asp:LinkButton></div>            	
            </div>				

			
    </div>


    <div class="row">
<asp:GridView ID="GridView1" runat="server" AutoGenerateColumns="false" CssClass="table table-striped table-bordered table-list" ViewStateMode="Enabled"
     OnRowEditing="GridView1_RowEditing" OnRowCancelingEdit="GridView1_RowCancelingEdit" OnRowUpdating="GridView1_RowUpdating" >

<Columns>

    <asp:TemplateField  ItemStyle-VerticalAlign="Middle" ItemStyle-HorizontalAlign="Center" HeaderStyle-HorizontalAlign="Center">
        <HeaderTemplate>SectionName</HeaderTemplate>
                        <ItemTemplate><%# Eval("SectionName")%></ItemTemplate>
                        <EditItemTemplate>
                            <asp:TextBox runat="server" Text='<%# Eval("SectionName")%>' ID="txtSectionName" class="form-control" />
                        </EditItemTemplate>
   </asp:TemplateField>

    <asp:TemplateField  ItemStyle-VerticalAlign="Middle" ItemStyle-HorizontalAlign="Center">
        <HeaderTemplate>Rows</HeaderTemplate>
                        <ItemTemplate><%# Eval("NumberOfRows")%></ItemTemplate>
                        <EditItemTemplate>
                            <asp:TextBox runat="server" Text='<%# Eval("NumberOfRows")%>' ID="txtNumberOfRows" class="form-control" />
                        </EditItemTemplate>
   </asp:TemplateField>

    <asp:TemplateField  ItemStyle-VerticalAlign="Middle" ItemStyle-HorizontalAlign="Center">
        <HeaderTemplate>Columns</HeaderTemplate>
                        <ItemTemplate><%# Eval("NumberOfColumns")%></ItemTemplate>
                        <EditItemTemplate>
                            <asp:TextBox runat="server" Text='<%# Eval("NumberOfColumns")%>' ID="txtNumberOfColumns" class="form-control" />
                        </EditItemTemplate>
   </asp:TemplateField>	

    <asp:TemplateField  ItemStyle-VerticalAlign="Middle" ItemStyle-HorizontalAlign="Center">
        <HeaderTemplate>Photo</HeaderTemplate>
                        <ItemTemplate><%# Eval("Photo")%></ItemTemplate>
                        <EditItemTemplate>
                            <asp:TextBox runat="server" Text='<%# Eval("Photo")%>' ID="txtPhoto" class="form-control" />
                        </EditItemTemplate>
   </asp:TemplateField>

   <asp:TemplateField HeaderText="Edit">
               <ItemTemplate><div class="btn-group align-middle" role="group" aria-label="Update1 Buttons">
                   <asp:LinkButton ID="btnedit" runat="server" CommandName="Edit" Text="Edit" CssClass="btn btn-sm btn-primary" /></div>
               </ItemTemplate>
               <EditItemTemplate><div class="btn-group align-middle" role="group" aria-label="Update Buttons">
                   <asp:LinkButton ID="btnupdate" runat="server" CommandName="Update" Text="Update" CssClass="btn btn-sm btn-primary" /><asp:LinkButton ID="btncancel" runat="server" CommandName="Cancel" Text="Cancel" CssClass="btn btn-sm btn-default" />
                   </div>
               </EditItemTemplate>
   </asp:TemplateField>
           

    </Columns>

</asp:GridView>

    </div>
</div>