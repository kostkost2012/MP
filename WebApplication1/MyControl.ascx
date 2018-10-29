<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="MyControl.ascx.cs" Inherits="WebApplication1.MyControl" %>

<form method="POST" action="" runat="server">
    <asp:Button ID="Button1" runat="server" Text="Button" />
    <asp:PlaceHolder ID="PlaceHolder1" runat="server">
        <asp:BulletedList ID="BulletedList1" runat="server">
            <asp:ListItem>sas</asp:ListItem>
            <asp:ListItem>ded</asp:ListItem>
            <asp:ListItem>fef</asp:ListItem>
        </asp:BulletedList>
        <asp:RadioButtonList ID="RadioButtonList1" runat="server">
            <asp:ListItem>1</asp:ListItem>
            <asp:ListItem>2</asp:ListItem>
            <asp:ListItem>3</asp:ListItem>
        </asp:RadioButtonList>

        <asp:Panel ID="Panel1" runat="server">
            <input type="submit" name="theme" value="null" />
            <input type="submit" name="theme" value="DarkTheme" />
            <input type="submit" name="theme" value="LightTheme" />
        </asp:Panel>
    </asp:PlaceHolder>
</form>





