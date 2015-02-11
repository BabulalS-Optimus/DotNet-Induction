<%@ Page Language="C#" Inherits="System.Web.Mvc.ViewPage<OnlineExaminationSystem.Entity.Test>" %>

<!DOCTYPE html>

<html>
<head runat="server">
    <meta name="viewport" content="width=device-width" />
    <title>Details</title>
    <link href="../../Content/Site.css" rel="stylesheet" />
</head>
<body>
    <fieldset>
        <legend>Test</legend>

        <div class="display-label">
            <b><%: Html.DisplayNameFor(model => model.Title) %></b> :     <%: Html.DisplayFor(model => model.Title) %>
        </div>

        <div class="display-label">
            <b><%: Html.DisplayNameFor(model => model.User.Name) %></b> :             <%: Html.DisplayFor(model => model.User.Name) %>
        </div>
    </fieldset>
    <p>

        <%: Html.ActionLink("Edit", "Edit", new { id=Model.ID }) %> |
        <%: Html.ActionLink("ShowQuestions", "ShowQuestions") %> |
        <%: Html.ActionLink("Assign to Student", "Assign") %> |
        <%: Html.ActionLink("Back to List", "Index") %> |
        <%: Html.ActionLink("Logout", "Logout")%>
    </p>
</body>
</html>
