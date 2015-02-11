<%@ Page Language="C#" Inherits="System.Web.Mvc.ViewPage<OnlineExaminationSystem.Entity.Activity>" %>

<!DOCTYPE html>

<html>
<head runat="server">
    <meta name="viewport" content="width=device-width" />
    <title>Details</title>
</head>
<body>
    <fieldset>
        <legend>Activity</legend>

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
    <p>

        <%: Html.ActionLink("Edit", "Edit", new { id=Model.ID }) %> |
         <%: Html.ActionLink("Back to Assignment List", "Index") %> |
    <%: Html.ActionLink("Go to Test List", "GoToTests") %> |
    <%: Html.ActionLink("Logout", "Logout") %>
    </p>
</body>
</html>
