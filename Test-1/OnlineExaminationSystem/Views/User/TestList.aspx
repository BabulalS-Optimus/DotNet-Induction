<%@ Page Language="C#" Inherits="System.Web.Mvc.ViewPage<IEnumerable<OnlineExaminationSystem.Entity.Test>>" %>

<!DOCTYPE html>

<html>
<head id="Head1" runat="server">
    <meta name="viewport" content="width=device-width" />
    <title>Test Lists</title>
    <link href="../../Content/Site.css" rel="stylesheet" />
</head>
<body>
    <h2>List of tests assigned to you</h2>
    <table>
        <tr>
            <th>Test Title
            </th>
            <th>Organiser
            </th>
            <th></th>
        </tr>

        <% foreach (var item in Model)
           {
            
        %>
        <tr>
            <td>
                <%: Html.DisplayFor(modelItem => item.Title) %>
            </td>
            <td>
                <%: Html.DisplayFor(modelItem => item.User.Name) %>
            </td>
            <td>
                <%: Html.ActionLink("Get this test", "GetTest", new { id=item.ID }) %> 
            </td>
        </tr>
        <% } %>
    </table>
    <%: Html.ActionLink("Logout", "Logout")%>
</body>
</html>
