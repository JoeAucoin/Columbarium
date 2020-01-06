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


<div class="myImageMap"><asp:Image ID="ImageWall" runat="server" AlternateText="Columbarium " /></div>

<p style="text-align:center;font-size:1.2em;">

  
    
   
<br>Use the dropdown to view a section: 
<asp:DropDownList ID="ddlDisplaySection" runat="server" OnTextChanged="ddlDisplaySection_TextChanged" AutoPostBack="true" Font-Names="Verdana" Font-Size="Large"></asp:DropDownList>

<br />
    <asp:Image ID="ImageNicheSection" runat="server" CssClass="img-responsive SectionImage"  />

    </p>

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

<p style="text-align:center; padding-top:20px;font-size:1.2em;">

   To select and reserve a niche, click on an available green box.</p>

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


<div class="container-fluid col-md-6 col-md-offset-3">
<table border="0" ID="Table1" class="table table-hover" style="width:500px;">
	<tr>
		<td><img SRC="/DesktopModules/Columbarium/images/bgreen.gif" height="20" width="20" alt="AVAILABLE ~ Click to Reserve">

		</td>

		<td>&nbsp;= AVAILABLE ~ Click to Reserve</td>


<td>&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;</td>




			<td><img SRC="/DesktopModules/Columbarium/images/bred.gif" WIDTH="20" HEIGHT="20"></td>
					
		<td>&nbsp;= RESERVED</td>
		</tr>	
	</table>
</div>