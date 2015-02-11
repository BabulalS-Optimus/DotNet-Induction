<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Create.aspx.cs" Inherits="MvcPattern.Views.User.Create" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
</head>
<body>

    <form id="form2" method="post" action="../../Student/Create">
        <input id="Name" name="Name" />
        <input id="Email" name="Email" />
        <input type="submit" value="Submit" />
    </form>
    <a href="Index.aspx">List all</a>
</body>








</html>
