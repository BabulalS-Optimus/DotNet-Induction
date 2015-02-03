<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="ReadCSVFile.aspx.cs" Inherits="StudentManager.ReadCSVFile" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
</head>
<body>
    <form id="form1" runat="server">
        <div>
            <pre>
            Browse for the CSV file : <asp:FileUpload ID="fileCSVBrowser" runat="server" />
            <asp:Button ID="SaveStudentsToDB" runat="server" Text="Read CSV" OnClick="SaveStudentsToDB_Click" />
            </pre>

        </div>
    </form>
</body>
</html>
