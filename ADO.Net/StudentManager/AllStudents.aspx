<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="AllStudents.aspx.cs" Inherits="StudentManager.AllStudetns" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
</head>
<body>
    <form id="form1" runat="server">
        <asp:ScriptManager ID="ScriptManager1" runat="server"></asp:ScriptManager>
        <div>
            <asp:ListBox ID="listStream" runat="server" AutoPostBack="true" OnSelectedIndexChanged="listStream_SelectedIndexChanged"></asp:ListBox>

            <asp:GridView ID="gridStudents" runat="server" AllowPaging="True"  AutoGenerateSelectButton="true" AllowSorting="True" OnSorting="gridStudents_Sorting" CellPadding="4" ForeColor="#333333" GridLines="None">
                <AlternatingRowStyle BackColor="White" ForeColor="#284775" />
                <EditRowStyle BackColor="#999999" />
                <FooterStyle BackColor="#5D7B9D" Font-Bold="True" ForeColor="White" />
                <HeaderStyle BackColor="#5D7B9D" Font-Bold="True" ForeColor="White" />
                <PagerStyle BackColor="#284775" ForeColor="White" HorizontalAlign="Center" />
                <RowStyle BackColor="#F7F6F3" ForeColor="#333333" />
                <SelectedRowStyle BackColor="#E2DED6" Font-Bold="True" ForeColor="#333333" />
                <SortedAscendingCellStyle BackColor="#E9E7E2" />
                <SortedAscendingHeaderStyle BackColor="#506C8C" />
                <SortedDescendingCellStyle BackColor="#FFFDF8" />
                <SortedDescendingHeaderStyle BackColor="#6F8DAE" />
            </asp:GridView>
            <br />
            <asp:Button ID="btnEdit" runat="server" Text="Edit Selected Record" OnClick="btnEdit_Click" />
            <br />
            <a href="AddNewStudent.aspx">Add a new Student</a>
        </div>
    </form>
</body>
</html>
