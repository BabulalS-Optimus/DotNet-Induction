<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Default.aspx.cs" Inherits="XMLAssignment.Default" %>

<%@ Import Namespace="XMLAssignment.BusinessLayer" %>
<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>

</head>
<body>
    <form id="form1" runat="server">
        <div>
            <asp:Button ID="btnAddXML" runat="server" Text="Add XML File" OnClick="btnAddXML_Click" />
            <br />
            <asp:HyperLink ID="linkToXMLFile" NavigateUrl="#" runat="server">Display XML</asp:HyperLink>

        </div>
    </form>
</body>
</html>
