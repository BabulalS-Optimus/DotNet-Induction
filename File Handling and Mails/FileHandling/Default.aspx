<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Default.aspx.cs" Inherits="DirectoriesAndFiles.Default" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
</head>
<body>
    <form id="form1" runat="server">
        <div>
            <asp:Button ID="btnAddNewDir" runat="server" Text="Add a new Directory" OnClick="btnAddNewDir_Click" />
            <br />
            <asp:Button ID="btnAddFiles" runat="server" Text="Add the files in the directory" OnClick="btnAddFiles_Click" />
            <br />
            <asp:Button ID="btnDetailsC" runat="server" Text="Details of C:" OnClick="btnDetailsC_Click" />
            <br />
            <asp:Button ID="btnDetailsDirNFile" runat="server" Text="Details of Directory and Files" OnClick="btnDetailsDirNFile_Click" />
            <br />
            <asp:Button ID="btnDirPath" runat="server" Text="Display directory path" OnClick="btnDirPath_Click" />
            <br />
            <asp:Button ID="btnSetReadonly" runat="server" Text="Set Readonly for FileRead" OnClick="btnSetReadonly_Click" />
            <br />
            <asp:Button ID="btnRead" runat="server" Text="Read from ReadFile" OnClick="btnRead_Click" />
            <br />
            <asp:Button ID="btnCompress" runat="server" Text="Compress the file" OnClick="btnCompress_Click" />
        </div>
    </form>
</body>
</html>
