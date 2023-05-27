<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="View.ascx.cs" Inherits="GIBS.Modules.Columbarium.View" %>

<style type='text/css'>
    .SectionTitle {
        font-size:1.3em;
        font-weight:bold;
    }

    .SectionImage {
    padding-top:5px;
    margin: 0 auto
    }

    .formBox{
	margin-top: 90px;
	padding: 50px;
}

    .myImageMap {
    
    width: 100%;
    text-align: center;
    overflow-y: hidden; 
    overflow-x:auto;
    }
    </style>

<asp:Label ID="lblDebug" runat="server" Text=""></asp:Label>
<div style="text-align:right;"><asp:HyperLink ID="HyperLinkManage" runat="server" Visible="false" CssClass="btn btn-primary">Admin</asp:HyperLink></div>



       
	   <div class="myImageMap"><asp:Image ID="ImageWall" runat="server" AlternateText="Columbarium" CssClass="img-responsive" /></div>
	   


<p style="text-align:center;font-size:1.2em;">

  
    
   
<br>Use the dropdown to view a section: 
<asp:DropDownList ID="ddlDisplaySection" runat="server" OnTextChanged="ddlDisplaySection_TextChanged" AutoPostBack="true" Font-Names="Verdana" Font-Size="Large"></asp:DropDownList>

<br />
    <asp:Image ID="ImageNicheSection" runat="server" CssClass="img-responsive SectionImage"  />

    </p>



<p style="text-align:center; padding-top:20px;font-size:1.2em;">

   To select and reserve a niche, click on an available green box.</p>

<div style="width:100%; text-align:center; padding-bottom:15px;">

    <asp:Label ID="lblSectionTitle" runat="server" Text="" CssClass="SectionTitle" /><br />

    <asp:DataList ID="DataList1" runat="server" OnItemDataBound="DataList1_ItemDataBound" RepeatLayout="Flow" RepeatDirection="Horizontal" >
        <ItemTemplate>
            <asp:HyperLink ID="HyperLinkBookNiche" runat="server">
            <asp:Image ID="vImage" runat="server" CssClass="marginNiches" /></asp:HyperLink>
        </ItemTemplate>
    </asp:DataList>



</div>



<div class="container-fluid col-md-6 col-md-offset-3 text-center">
    <asp:Label ID="lblTotalNiches" runat="server" Text=""></asp:Label><br />
    <asp:Label ID="lblNumberPerRow" runat="server" Text=""></asp:Label>
</div>


<div class="container-fluid col-md-6 col-md-offset-3">
<table border="0" ID="Table1" class="table table-hover">
	<tr>
		<td><img SRC="/DesktopModules/Columbarium/images/bgreen.gif" height="20" width="20" alt="AVAILABLE ~ Click to Reserve">

		</td>

		<td>&nbsp;= AVAILABLE ~ Click to Reserve</td>


</tr>
    <tr>



			<td><img SRC="/DesktopModules/Columbarium/images/bred.gif" WIDTH="20" HEIGHT="20"></td>
					
		<td>&nbsp;= RESERVED</td>
		</tr>	
	</table>
</div>