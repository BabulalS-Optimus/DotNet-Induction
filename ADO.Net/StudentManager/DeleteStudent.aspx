<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="DeleteStudent.aspx.cs" Inherits="StudentManager.DeleteStudent" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
    <style type="text/css">
        .auto-style1 {
            width: 100%;
            height: 194px;
        }

        .auto-style2 {
            width: 78px;
        }

        .auto-style3 {
            width: 30px;
        }

        .auto-style4 {
            width: 162px;
        }
    </style>
    <script type="text/javascript">
        ///<summary>
        ///Click event for moving list items from listStudLeft to listStudRight
        ///</summary>
        function moveRight() {
            //getting IDs of the lists
            var listLeft = document.getElementById('<%= listStudLeft.ClientID%>');
            var listRight = document.getElementById('<%= listStudRight.ClientID %>');

            //finding the length of the lists
            var listLeftLen = listLeft.options.length;
            var listRightLen = listRight.options.length;

            //traversing the list
            for (var i = 0; i < listLeftLen; i++) {
                //checking whether the item is selected or not
                if (listLeft.options[i].selected) {
                    //adding the selected item in the listRight
                    listRight.options[listRightLen] = new Option(listLeft.options[i].text, listLeft.options[i].value);
                    listRightLen++;
                    //removing the item from listLeft
                    listLeft.remove(i);
                    listLeftLen--;
                }
            }
        }
        ///<summary>
        ///Click event for moving list items from listStudLeft to listStudRight
        ///</summary>
        function moveLeft() {

            //finding the list objects
            var listLeft = document.getElementById('<%= listStudLeft.ClientID%>');
            var listRight = document.getElementById('<%= listStudRight.ClientID %>');

            //calculating the list lengths
            var listLeftLen = listLeft.options.length;
            var listRightLen = listRight.options.length;

            //traversing the list
            for (var i = 0; i < listRightLen; i++) {
                //checking whether the item is selected or not
                if (listRight.options[i].selected) {
                    //adding the selected item in to listLeft
                    listLeft.options[listLeftLen] = new Option(listRight.options[i].text, listRight.options[i].value);
                    listLeftLen++;
                    //removing the item from listRight
                    listRight.remove(i);
                    listRightLen--;
                }
            }
        }
        ///<summary>
        ///Click event for deleting records from database
        ///</summary>
        function deleteItems() {

            var rollNos = "";

            //finding the list object
            var listRight = document.getElementById('<%= listStudRight.ClientID %>');

            //calculating the list length
            var listRightLen = listRight.options.length;

            //traversing the list
            for (var i = 0; i < listRightLen; i++) {
                //adding the item in to text
                rollNos += listRight.options[i].value + ",";
            }

            //prompting user to confirm for deletion
            var result = confirm("Roll numbers to be deleted : " + rollNos + "\n Are you sure?");
            if (result == true) {
                //if yes
                //calling server side method to delete student records
                PageMethods.DeleteStudents(rollNos, OnSuccess, OnFailure);

            } else {
                //if presses No
                alert("You pressed Cancel!");
            }
        }
        
        ///<summary>
        ///Method to be executed when the calling of server side method is a success
        ///</summary>
        function OnSuccess(result) {
            //displaying the result of method call for deletion
            var spanRes = document.getElementById("spanResult");
            spanRes.innerHTML = result;
        }

        ///<summary>
        ///Method to be executed when the calling of server side method is a failure
        ///</summary>
        function OnFailure(result) {
            spanRes.innerHTML = "Records were not deleted.";
        }


    </script>
</head>
<body>
    <form id="form1" runat="server">
        <asp:ScriptManager ID="ScriptManager1" runat="server" EnablePageMethods="true"></asp:ScriptManager>
        <div>

            <table class="auto-style1">
                <tr>
                    <td colspan="4">
                        <h3>Delete Students</h3>
                    </td>
                </tr>
                <tr>
                    <td rowspan="2" class="auto-style4">
                        <asp:ListBox ID="listStreams" runat="server" Height="182px" Width="128px" AutoPostBack="true" OnSelectedIndexChanged="listStreams_SelectedIndexChanged"></asp:ListBox>
                    </td>
                    <td rowspan="2" class="auto-style2">
                        <asp:ListBox ID="listStudLeft" runat="server" Height="143px" Width="146px" SelectionMode="Multiple"></asp:ListBox>
                    </td>
                    <td class="auto-style3">
                        <input id="btnMoveRight" type="button" value="=>" onclick="moveRight()" />

                    </td>
                    <td rowspan="2">
                        <asp:ListBox ID="listStudRight" runat="server" Height="162px" Width="128px" SelectionMode="Multiple"></asp:ListBox>
                        <br />
                        <input id="btnDelete" type="button" value="Delete Records" onclick="deleteItems()" />
                    </td>
                </tr>
                <tr>
                    <td class="auto-style3">
                        <input id="btnMoveLeft" type="button" value="<=" onclick="moveLeft()" />
                    </td>
                </tr>
            </table>
            <a href="AllStudents.aspx"">All Students</a>
            <span id="spanResult"></span>
        </div>
    </form>
</body>
</html>
