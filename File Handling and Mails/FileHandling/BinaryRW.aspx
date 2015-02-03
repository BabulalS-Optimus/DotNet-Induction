<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="BinaryRW.aspx.cs" Inherits="DirectoriesAndFiles.BinaryRW" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
</head>
<body>
    <form id="form1" runat="server">
        <div>
            <asp:Button ID="btnCreateFile" runat="server" Text="Create the source file" OnClick="btnCreateFile_Click" />
            <br />
            <asp:Button ID="btnReadData" runat="server" Text="Read data of the file" OnClick="btnReadData_Click" />
        </div>
    </form>
</body>
</html>
