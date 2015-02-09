<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Default.aspx.cs" Inherits="SampleWebApp.Default" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
</head>
<body>
    <form id="form1" runat="server">
        <div>
            <pre>
        Percentage : <asp:TextBox ID="txtPercentage" runat="server"></asp:TextBox>
        <asp:Button ID="btnCheck" runat="server" Text="Check" OnClick="btnCheck_Click" />
            </pre>
        </div>
    </form>
</body>
</html>
