<%@ Page Language="C#" Inherits="System.Web.Mvc.ViewPage<Sample.Models.User>" %>

<!DOCTYPE html>

<html>
<head runat="server">
    <meta name="viewport" content="width=device-width" />
    <title>Details</title>
</head>
<body>
    <fieldset>
        <legend>User</legend>

        <div class="display-label">
            <%: Html.DisplayNameFor(model => model.Username) %>
        </div>
        <div class="display-field">
            <%: Html.DisplayFor(model => model.Username) %>
        </div>

        <div class="display-label">
            <%: Html.DisplayNameFor(model => model.Password) %>
        </div>
        <div class="display-field">
            <%: Html.DisplayFor(model => model.Password) %>
        </div>
    </fieldset>
    <p>

        <%: Html.ActionLink("Edit", "Edit", new { id=Model.ID }) %> |
        <%: Html.ActionLink("Back to List", "Index") %>
        <%: Html.ActionLink("Logout","Logout") %>
    </p>
</body>
</html>
