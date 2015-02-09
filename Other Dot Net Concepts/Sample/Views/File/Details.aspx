<%@ Page Language="C#" Inherits="System.Web.Mvc.ViewPage<Sample.Models.FileHandler>" %>

<!DOCTYPE html>

<html>
<head runat="server">
    <meta name="viewport" content="width=device-width" />
    <title>Details</title>
</head>
<body>
    <fieldset>
        <legend>FileHandler</legend>

        <div class="display-label">
            <%: Html.DisplayNameFor(model => model.UserID) %>
        </div>
        <div class="display-field">
            <%: Html.DisplayFor(model => model.UserID) %>
        </div>

        <div class="display-label">
            <%: Html.DisplayNameFor(model => model.FilePath) %>
        </div>
        <div class="display-field">
            <%: Html.DisplayFor(model => model.FilePath) %>
        </div>
    </fieldset>
    <p>

        <%: Html.ActionLink("Edit", "Edit", new { id=Model.ID }) %> |
        <%: Html.ActionLink("Back to List", "Index") %>
        <%: Html.ActionLink("Logout","Logout") %>
    </p>
</body>
</html>
