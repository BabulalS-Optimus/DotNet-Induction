<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Default.aspx.cs" Inherits="MvpPattern.Default" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
</head>
<body>
    <form id="form1" runat="server">
        <div>
            <asp:Label ID="lblInstruction" runat="server" Text="Label"></asp:Label>
            &nbsp;
    <asp:TextBox ID="txtMessage" runat="server"></asp:TextBox>
        </div>
        <asp:Button ID="btnGo" runat="server" Text="Go" OnClick="btnGo_Click"  />
    </form>
</body>
</html>
