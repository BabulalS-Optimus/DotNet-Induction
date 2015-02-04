<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="DisplayXML.aspx.cs" Inherits="XMLAssignment.DisplayXML" %>

<%@ Import Namespace="XMLAssignment.BusinessLayer" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
</head>
<body>
    <form id="form1" runat="server">
        <div>
            <asp:HyperLink ID="linkToXMLFile" runat="server">Display Data XML</asp:HyperLink>
            <asp:HyperLink ID="linkToXMLFileStudent" runat="server">Display Student XML</asp:HyperLink>
            <br />
            Result :           
            <asp:TextBox ID="txtResult" runat="server"></asp:TextBox>
            <br />
            <asp:Button ID="btnAddNode" runat="server" Text="Add Node" OnClick="btnAddNode_Click" />
            <br />
            <asp:Button ID="btnFirstChild" runat="server" Text="First Child" OnClick="btnFirstChild_Click" />
            <br />
            <asp:Button ID="btnInsertBefore" runat="server" Text="Insert Before" OnClick="btnInsertBefore_Click" />
            <br />
            <asp:Button ID="btnRemoveNode" runat="server" Text="Remove Node" OnClick="btnRemoveNode_Click" />
            <br />
            <asp:Button ID="btnChildNode" runat="server" Text="Child Node" OnClick="btnChildNode_Click" />
            <br />
            <asp:Button ID="btnTotalNodes" runat="server" Text="Total Nodes" OnClick="btnTotalNodes_Click" />
            <br />
            <asp:Button ID="btnReplaceNode" runat="server" Text="Replace Node" OnClick="btnReplaceNode_Click" />
            <br />
            <br />
            <asp:Button ID="btnGetMCAStudents" runat="server" Text="Get MCA Students" OnClick="btnGetMCAStudents_Click" />
            <br />
            <asp:Button ID="btnGetDGradeStudents" runat="server" Text="Get D grade Students" OnClick="btnGetDGradeStudents_Click" />
            <br />
            <br />
            Browse for XML File :
            <asp:FileUpload ID="fileUploadXML" runat="server" />
            <br />
            <asp:Button ID="btnLoadAndSaveXML" runat="server" Text="Load and Save Student Records from XML" OnClick="btnLoadAndSaveXML_Click" />
        </div>
    </form>
</body>
</html>
