﻿<%@ Page Language="C#" Inherits="System.Web.Mvc.ViewPage<IEnumerable<Sample.Models.User>>" %>

<!DOCTYPE html>

<html>
<head runat="server">
    <meta name="viewport" content="width=device-width" />
    <title>Index</title>
</head>
<body>
    <p>
        <%: Html.ActionLink("Create New", "Create") %>
    </p>
    <table>
        <tr>
            <th>
                <%: Html.DisplayNameFor(model => model.Username) %>
            </th>
            <th>
                <%: Html.DisplayNameFor(model => model.Password) %>
            </th>
            <th></th>
        </tr>
    
    <% foreach (var item in Model) { %>
        <tr>
            <td>
                <%: Html.DisplayFor(modelItem => item.Username) %>
            </td>
            <td>
                <%: Html.DisplayFor(modelItem => item.Password) %>
            </td>
            <td>
                <%: Html.ActionLink("Edit", "Edit", new { id=item.ID }) %> |
                <%: Html.ActionLink("Details", "Details", new { id=item.ID }) %> |
                <%: Html.ActionLink("Delete", "Delete", new { id=item.ID }) %>
            </td>
        </tr>
    <% } %>
    
    </table>
        <%: Html.ActionLink("Logout","Logout") %>

</body>
</html>
