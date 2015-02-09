<%@ Page Language="C#" Inherits="System.Web.Mvc.ViewPage<Sample.Models.FileHandler>" %>

<!DOCTYPE html>

<html>
<head runat="server">
    <meta name="viewport" content="width=device-width" />
    <title>Delete</title>
</head>
<body>
    <h3>Are you sure you want to delete this?</h3>
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
    <% using (Html.BeginForm()) { %>
        <p>
            <input type="submit" value="Delete" /> |
            <%: Html.ActionLink("Back to List", "Index") %>
        </p>
    <% } %>
    
</body>
</html>
