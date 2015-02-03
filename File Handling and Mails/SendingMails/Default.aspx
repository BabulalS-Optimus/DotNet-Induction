<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Default.aspx.cs" Inherits="SendingMails.Default" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
</head>
<body>
    <form id="form1" runat="server">
        <div>
            <pre>
            Path to the folder : <asp:TextBox ID="txtPathToFolder" runat="server"></asp:TextBox>
            <asp:Button ID="btnSendMail" runat="server" Text="Send Mail" OnClick="btnSendMail_Click" />
            </pre>
        </div>
    </form>
</body>
</html>
