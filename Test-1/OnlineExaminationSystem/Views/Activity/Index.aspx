<%@ Page Language="C#" Inherits="System.Web.Mvc.ViewPage<IEnumerable<OnlineExaminationSystem.Entity.Activity>>" %>

<!DOCTYPE html>

<html>
<head runat="server">
    <meta name="viewport" content="width=device-width" />
    <title>Index</title>
    <link href="../../Content/Site.css" rel="stylesheet" />
</head>
<body>
    <h2>List of assignments</h2>
    <p>
        <%: Html.ActionLink("Create New", "Create") %>
    </p>
    <table>
        <tr>
            <th>Organiser
            </th>
            <th>
                <%: Html.DisplayNameFor(model => model.Test.Title) %>
            </th>
            <th>Student
            </th>
            <th></th>
        </tr>

        <% foreach (var item in Model)
           { %>
        <tr>
            <td>
                <%: Html.DisplayFor(modelItem => item.User.Name) %>
            </td>
            <td>
                <%: Html.DisplayFor(modelItem => item.Test.Title) %>
            </td>
            <td>
                <%: Html.DisplayFor(modelItem => item.User1.Name) %>
            </td>
            <td>
                <%: Html.ActionLink("Edit", "Edit", new { id=item.ID }) %> |
                <%: Html.ActionLink("Details", "Details", new { id=item.ID }) %> |
                <%: Html.ActionLink("Delete", "Delete", new { id=item.ID }) %>
            </td>
        </tr>
        <% } %>
    </table>

    <%: Html.ActionLink("Go to Test List", "GoToTests") %> |
    <%: Html.ActionLink("Logout", "Logout") %>
</body>
</html>
