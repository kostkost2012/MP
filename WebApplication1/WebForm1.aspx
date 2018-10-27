<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="WebForm1.aspx.cs" Inherits="WebApplication1.WebForm1" %>
<%@ Register Src="~/MyControl.ascx" TagName="my" TagPrefix="Tcustom" %>
<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
<meta http-equiv="Content-Type" content="text/html; charset=utf-8"/>
    <title></title>
</head>
<body>
    <form id="form1" runat="server">
    <div>
    <input runat="server" id="button1" type="submit" value="Enter..." OnServerClick="convertoupper"/>
                <asp:TreeView ID="TreeView1" runat="server" OnSelectedNodeChanged="TreeView1_SelectedNodeChanged">
                    <Nodes>
                        <asp:TreeNode Text="ffefe" Value="ffefe"></asp:TreeNode>
                        <asp:TreeNode Text="avx" Value="avx"></asp:TreeNode>
                        <asp:TreeNode Text="ttte" Value="ttte"></asp:TreeNode>
                        <asp:TreeNode Text="fdsgdsf" Value="fdsgdsf">
                            <asp:TreeNode Text="ters" Value="ters"></asp:TreeNode>
                        </asp:TreeNode>
                    </Nodes>
        </asp:TreeView>
        <Tcustom:my ID="my1" runat="server"></Tcustom:my>
    </div>
    </form>
</body>
</html>
