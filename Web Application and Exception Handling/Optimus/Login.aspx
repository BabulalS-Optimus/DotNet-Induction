<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Login.aspx.cs" Inherits="Optimus.Login" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>Login page</title>
</head>
<body>
    <form id="form1" runat="server">
        <div>
            <pre>
Username : <asp:TextBox ID="txtUsername" runat="server"></asp:TextBox>
Password : <asp:TextBox ID="txtPassword" runat="server" TextMode="Password"></asp:TextBox>
<asp:Button ID="btnLogin" runat="server" Text="Login" OnClick="btnLogin_Click" />
            </pre>
        </div>
    </form>
</body>
</html>
