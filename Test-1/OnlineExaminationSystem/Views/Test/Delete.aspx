<%@ Page Language="C#" Inherits="System.Web.Mvc.ViewPage<OnlineExaminationSystem.Entity.Test>" %>

<!DOCTYPE html>

<html>
<head runat="server">
    <meta name="viewport" content="width=device-width" />
    <title>Delete</title>
    <link href="../../Content/Site.css" rel="stylesheet" />
</head>
<body>
    <h3>Are you sure you want to delete this?</h3>
    <fieldset>
        <legend>Test</legend>

        <div class="display-label">
            <b><%: Html.DisplayNameFor(model => model.Title) %></b> : <%: Html.DisplayFor(model => model.Title) %>
        </div>

        <div class="display-label">
            <b><%: Html.DisplayNameFor(model => model.User.Name) %></b> :  <%: Html.DisplayFor(model => model.User.Name) %>
        </div>
    </fieldset>
    <% using (Html.BeginForm())
       { %>
    <p>
        <input type="submit" value="Delete" />
        |
            <%: Html.ActionLink("Back to List", "Index") %> | <%: Html.ActionLink("Logout", "Logout")%>
    </p>
    <% } %>
</body>
</html>
