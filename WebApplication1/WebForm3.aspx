<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="WebForm3.aspx.cs" Inherits="WebApplication1.WebForm3" MasterPageFile="~/Page.Master"%>
<%@ MasterType TypeName="WebApplication1.Page"%>


<asp:Content runat="server" ContentPlaceHolderID="header">
    <asp:Label runat="server">HEADER typed</asp:Label>
</asp:Content>

<asp:Content runat="server" ContentPlaceHolderID="content">
    <div>
                <asp:TreeView ID="TreeView1" runat="server">
                    <Nodes>
                        <asp:TreeNode Text="ffefe" Value="ffefe"></asp:TreeNode>
                        <asp:TreeNode Text="avx" Value="avx"></asp:TreeNode>
                        <asp:TreeNode Text="ttte" Value="ttte"></asp:TreeNode>
                        <asp:TreeNode Text="fdsgdsf" Value="fdsgdsf">
                            <asp:TreeNode Text="ters" Value="ters"></asp:TreeNode>
                        </asp:TreeNode>
                    </Nodes>
        </asp:TreeView>
    </div>
</asp:Content>

