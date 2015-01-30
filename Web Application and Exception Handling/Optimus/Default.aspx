<%@ Page Title="" Language="C#" MasterPageFile="~/Simple.Master" AutoEventWireup="true" CodeBehind="Default.aspx.cs" Inherits="Optimus.Default" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    
    <p>
        You're currently on Home Page of the website.
    </p>
    <a href="techNews.aspx">Technology News</a>
    <br />
    <a href="extraCurr.aspx">Extra Curricular Activities</a>

    <asp:TreeView ID="TreeView1" runat="server"  DataSourceID="SiteMapDataSource1" ShowLines="True">
    </asp:TreeView>

    <asp:SiteMapDataSource runat="server" ID="SiteMapDataSource1"></asp:SiteMapDataSource>
</asp:Content>
