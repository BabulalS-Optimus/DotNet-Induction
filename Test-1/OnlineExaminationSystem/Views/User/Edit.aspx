<%@ Page Language="C#" Inherits="System.Web.Mvc.ViewPage<OnlineExaminationSystem.Entity.User>" %>

<!DOCTYPE html>

<html>
<head runat="server">
    <meta name="viewport" content="width=device-width" />
    <title>Edit</title>
</head>
<body>
    <script src="<%: Url.Content("~/Scripts/jquery-1.7.1.min.js") %>"></script>
    <script src="<%: Url.Content("~/Scripts/jquery.validate.min.js") %>"></script>
    <script src="<%: Url.Content("~/Scripts/jquery.validate.unobtrusive.min.js") %>"></script>
    
    <% using (Html.BeginForm()) { %>
        <%: Html.ValidationSummary(true) %>
    
        <fieldset>
            <legend>User</legend>
    
            <%: Html.HiddenFor(model => model.ID) %>
    
            <div class="editor-label">
                <%: Html.LabelFor(model => model.Name) %>
            </div>
            <div class="editor-field">
                <%: Html.EditorFor(model => model.Name) %>
                <%: Html.ValidationMessageFor(model => model.Name) %>
            </div>
    
            <div class="editor-label">
                <%: Html.LabelFor(model => model.Email) %>
            </div>
            <div class="editor-field">
                <%: Html.EditorFor(model => model.Email) %>
                <%: Html.ValidationMessageFor(model => model.Email) %>
            </div>
    
            <div class="editor-label">
                <%: Html.LabelFor(model => model.Password) %>
            </div>
            <div class="editor-field">
                <%: Html.EditorFor(model => model.Password) %>
                <%: Html.ValidationMessageFor(model => model.Password) %>
            </div>
    
            <div class="editor-label">
                <%: Html.LabelFor(model => model.Mobile) %>
            </div>
            <div class="editor-field">
                <%: Html.EditorFor(model => model.Mobile) %>
                <%: Html.ValidationMessageFor(model => model.Mobile) %>
            </div>
    
            <div class="editor-label">
                <%: Html.LabelFor(model => model.Role) %>
            </div>
            <div class="editor-field">
                <%: Html.EditorFor(model => model.Role) %>
                <%: Html.ValidationMessageFor(model => model.Role) %>
            </div>
    
            <p>
                <input type="submit" value="Save" />
            </p>
        </fieldset>
    <% } %>
    
    <div>
        <%: Html.ActionLink("Back to List", "Index") %>
        <%: Html.ActionLink("Logout", "Logout")%>
    </div>
</body>
</html>
