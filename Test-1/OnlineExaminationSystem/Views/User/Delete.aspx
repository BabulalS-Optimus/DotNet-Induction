<%@ Page Language="C#" Inherits="System.Web.Mvc.ViewPage<OnlineExaminationSystem.Entity.User>" %>

<!DOCTYPE html>

<html>
<head runat="server">
    <meta name="viewport" content="width=device-width" />
    <title>Delete</title>
</head>
<body>
    <h3>Are you sure you want to delete this?</h3>
    <fieldset>
        <legend>User</legend>
    
        <div class="display-label">
            <%: Html.DisplayNameFor(model => model.Name) %>
        </div>
        <div class="display-field">
            <%: Html.DisplayFor(model => model.Name) %>
        </div>
    
        <div class="display-label">
            <%: Html.DisplayNameFor(model => model.Email) %>
        </div>
        <div class="display-field">
            <%: Html.DisplayFor(model => model.Email) %>
        </div>
    
        <div class="display-label">
            <%: Html.DisplayNameFor(model => model.Password) %>
        </div>
        <div class="display-field">
            <%: Html.DisplayFor(model => model.Password) %>
        </div>
    
        <div class="display-label">
            <%: Html.DisplayNameFor(model => model.Mobile) %>
        </div>
        <div class="display-field">
            <%: Html.DisplayFor(model => model.Mobile) %>
        </div>
    
        <div class="display-label">
            <%: Html.DisplayNameFor(model => model.Role) %>
        </div>
        <div class="display-field">
            <%: Html.DisplayFor(model => model.Role) %>
        </div>
    </fieldset>
    <% using (Html.BeginForm()) { %>
        <p>
            <input type="submit" value="Delete" /> |
            <%: Html.ActionLink("Back to List", "Index") %>
        </p>
    <% } %>
        <%: Html.ActionLink("Logout", "Logout")%>
</body>
</html>
