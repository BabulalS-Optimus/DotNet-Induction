<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Default.aspx.cs" Inherits="XPathNXSLT.Default" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
</head>
<body>
    <form id="form1" runat="server">
        <div>
            <asp:Button ID="btnShowAll" runat="server" Text="Show all students" OnClick="btnShowAll_Click" />
            <br />
            <asp:Button ID="btnAddCollege" runat="server" Text="Add College nodes" OnClick="btnAddCollege_Click" />
            <br />
            <asp:Xml ID="Xml1" runat="server" DocumentSource="~/Data/iCalibrator.xml" TransformSource="~/Data/iCalibrator.xslt"></asp:Xml>
            <br />
            <asp:Button ID="btnTransform" runat="server" Text="Transform XSL" OnClick="btnTransform_Click" />
        </div>
    </form>
</body>
</html>
