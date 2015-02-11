<%@ Page Language="C#" Inherits="System.Web.Mvc.ViewPage<IEnumerable<OnlineExaminationSystem.Entity.Question>>" %>

<!DOCTYPE html>

<html>
<head runat="server">
    <meta name="viewport" content="width=device-width" />
    <title>Index</title>
    <link href="../../Content/Site.css" rel="stylesheet" />
</head>
<body>

    <h2>List of Questions</h2>
    <p>
        <%: Html.ActionLink("Add New Question", "Create") %>
    </p>
    <table>
        <tr>
            <th>
                <%: Html.DisplayNameFor(model => model.Test.Title) %>
            </th>
            <th>
                <%: Html.DisplayNameFor(model => model.Ques) %>
            </th>
            <th>
                <%: Html.DisplayNameFor(model => model.Ans) %>
            </th>
            <th></th>
        </tr>

        <% foreach (var item in Model)
           { %>
        <tr>
            <td>
                <%: Html.DisplayFor(modelItem => item.Test.Title) %>
            </td>
            <td>
                <%: Html.DisplayFor(modelItem => item.Ques) %>
            </td>
            <td>
                <%: Html.DisplayFor(modelItem => item.Ans) %>
            </td>
            <td>
                <%: Html.ActionLink("Edit", "Edit", new { id=item.ID }) %> |
                <%: Html.ActionLink("Details", "Details", new { id=item.ID }) %> |
                <%: Html.ActionLink("Delete", "Delete", new { id=item.ID }) %>
            </td>
        </tr>
        <% } %>
    </table>
    <%: Html.ActionLink("Go back to Tests", "GoToTests")%> |     <%: Html.ActionLink("Logout", "Logout")%>
</body>
</html>
