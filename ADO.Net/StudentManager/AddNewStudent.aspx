<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="AddNewStudent.aspx.cs" Inherits="StudentManager.AddNewStudent" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
    <style type="text/css">
        .auto-style1 {
            width: 100%;
        }

        .auto-style2 {
            width: 612px;
        }
    </style>
</head>
<body>
    <form id="form1" runat="server">
        <asp:ScriptManager ID="ScriptManager1" runat="server"></asp:ScriptManager>
        <div>
            <a href="AllStudents.aspx">List all students</a>
            <table class="auto-style1">
                <tr>
                    <td align="center" colspan="2">
                        <h3>Add a new Student</h3>
                    </td>
                </tr>
                <tr>
                    <td align="Right" class="auto-style2">Full name :</td>
                    <td>
                        <asp:TextBox ID="txtFullName" runat="server"></asp:TextBox>
                    </td>
                </tr>
                <tr>
                    <td align="Right" class="auto-style2">Father&#39;s Name :</td>
                    <td>
                        <asp:TextBox ID="txtFathersName" runat="server"></asp:TextBox>
                    </td>
                </tr>
                <tr>
                    <td align="Right" class="auto-style2">Roll No. :</td>
                    <td>
                        <asp:TextBox ID="txtRollNo" runat="server"></asp:TextBox>
                    </td>
                </tr>
                <tr>
                    <td align="Right" class="auto-style2">Age :</td>
                    <td>
                        <asp:TextBox ID="txtAge" runat="server"></asp:TextBox>
                    </td>
                </tr>
                <tr>
                    <td align="Right" class="auto-style2">Stream :</td>
                    <td>
                        <asp:DropDownList ID="listStream" runat="server" Width="128px" AutoPostBack="true">
                        </asp:DropDownList>
                    </td>
                </tr>
                <tr>
                    <td align="Right" class="auto-style2">&nbsp;Address :</td>
                    <td>
                        <asp:TextBox ID="txtAddress" runat="server" TextMode="MultiLine"></asp:TextBox>
                    </td>
                </tr>
                <tr>
                    <td align="Right" class="auto-style2">State : </td>
                    <td>
                        <asp:DropDownList ID="listState" runat="server" Height="16px" Width="127px" AutoPostBack="true">
                        </asp:DropDownList>
                    </td>
                </tr>
                <tr>
                    <td align="Right" class="auto-style2">&nbsp;</td>
                    <td>
                        <asp:Button ID="btnAdd" runat="server" Text="Add" OnClick="btnAdd_Click" />
                        <pre>
<asp:RequiredFieldValidator ID="fullnameValidator" runat="server" ErrorMessage="Enter full name." ForeColor="Red"  ControlToValidate="txtFullName"></asp:RequiredFieldValidator>
<asp:RequiredFieldValidator ID="fathersNameValidator" runat="server" ErrorMessage="Enter father's name." ForeColor="Red"  ControlToValidate="txtFathersName"></asp:RequiredFieldValidator>
<asp:RequiredFieldValidator ID="rollNoValidator" runat="server" ErrorMessage="Enter roll number."  ForeColor="Red" ControlToValidate="txtRollNo"></asp:RequiredFieldValidator>
<asp:RequiredFieldValidator ID="ageValidator" runat="server" ErrorMessage="Enter age."  ForeColor="Red" ControlToValidate="txtAge"></asp:RequiredFieldValidator>
<asp:RangeValidator ID="ageRangeValidator" runat="server" Type="Integer" MinimumValue="18" MaximumValue="40" ForeColor="Red" ControlToValidate="txtAge" ErrorMessage="Age should be between 18 and 40."></asp:RangeValidator>
<asp:CustomValidator ID="streamValidator" OnServerValidate="stateValidator_ServerValidate"  ForeColor="Red" runat="server" ErrorMessage="Select a stream."></asp:CustomValidator>
<asp:RequiredFieldValidator ID="addressValidator" runat="server" ErrorMessage="Enter Address." ForeColor="Red"  ControlToValidate="txtAddress"></asp:RequiredFieldValidator>
<asp:CustomValidator ID="stateValidator" OnServerValidate="stateValidator_ServerValidate" ForeColor="Red"  runat="server" ErrorMessage="Select a state."></asp:CustomValidator>
                        </pre>
                    </td>
                </tr>
            </table>

        </div>
    </form>
</body>
</html>
