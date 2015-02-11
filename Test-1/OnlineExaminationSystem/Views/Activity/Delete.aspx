<%@ Page Language="C#" Inherits="System.Web.Mvc.ViewPage<OnlineExaminationSystem.Entity.Activity>" %>

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
        <legend>Assignment</legend>

        <div class="display-label">
            <%: Html.DisplayNameFor(model => model.User.Name) %> :
            <%: Html.DisplayFor(model => model.User.Name) %>
        </div>

        <div class="display-label">
            <%: Html.DisplayNameFor(model => model.Test.Title) %> :
            <%: Html.DisplayFor(model => model.Test.Title) %>
        </div>

        <div class="display-label">
            <%: Html.DisplayNameFor(model => model.User1.Name) %> :
            <%: Html.DisplayFor(model => model.User1.Name) %>
        </div>
    </fieldset>
    <% using (Html.BeginForm())
       { %>
    <p>
        <input type="submit" value="Delete" />
        |
            <%: Html.ActionLink("Back to List", "Index") %> | 
             <%: Html.ActionLink("Back to Assignment List", "Index") %> |
             <%: Html.ActionLink("Go to Test List", "GoToTests") %> |
             <%: Html.ActionLink("Logout", "Logout") %>
    </p>
    <% } %>
</body>
</html>
