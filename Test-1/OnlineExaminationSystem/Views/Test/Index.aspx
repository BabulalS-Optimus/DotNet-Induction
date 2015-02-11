<%@ Page Language="C#" Inherits="System.Web.Mvc.ViewPage<IEnumerable<OnlineExaminationSystem.Entity.Test>>" %>

<!DOCTYPE html>

<html>
<head runat="server">
    <meta name="viewport" content="width=device-width" />
    <title>Index</title>
    <link href="../../Content/Site.css" rel="stylesheet" />
</head>
<body>
    <h2>List of Tests</h2>

    <table>
        <tr>
            <th>
                <%: Html.DisplayNameFor(model => model.Title) %>
            </th>
            <th>
                <%: Html.DisplayNameFor(model => model.User.Name) %>
            </th>
            <th></th>
        </tr>

        <% foreach (var item in Model)
           { %>
        <tr>
            <td>
                <%: Html.DisplayFor(modelItem => item.Title) %>
            </td>
            <td>
                <%: Html.DisplayFor(modelItem => item.User.Name) %>
            </td>
            <td>
                <%: Html.ActionLink("Edit", "Edit", new { id=item.ID }) %> |
                <%: Html.ActionLink("Details", "Details", new { id=item.ID }) %> |
                <%: Html.ActionLink("Delete", "Delete", new { id=item.ID }) %>
            </td>
        </tr>
        <% } %>
    </table>
    <p>
        <%: Html.ActionLink("Create New", "Create") %> | <%: Html.ActionLink("Logout", "Logout")%>
    </p>
</body>
</html>
