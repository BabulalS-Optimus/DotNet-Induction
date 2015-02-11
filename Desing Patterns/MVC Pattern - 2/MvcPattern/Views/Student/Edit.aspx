<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Edit.aspx.cs" Inherits="MvcPattern.Views.Student.Edit" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
</head>
<body>
    <form id="form2" method="post" action="../../Student/Edit">
        <input type="hidden" runat="server" id="ID" name="ID" />
        <input id="Name" runat="server" name="Name" />
        <input id="Email" runat="server" name="Email" />
        <input type="submit" value="Update" />
    </form>
</body>
</html>
