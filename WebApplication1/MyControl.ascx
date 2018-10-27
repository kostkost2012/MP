<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="MyControl.ascx.cs" Inherits="WebApplication1.MyControl" %>
<div>
    <div>
        <asp:Image ID="img" runat="server" ImageUrl="a" />
    </div>
    <div>
        <asp:TextBox ID="TextBox1" runat="server"></asp:TextBox>
        <asp:Button ID="Button1" runat="server" Text="Check" OnClick="Button1_Click" />
    </div>

</div>


