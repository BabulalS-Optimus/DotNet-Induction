﻿<%@ Page Language="C#" Inherits="System.Web.Mvc.ViewPage<Sample.Models.User>" %>

<!DOCTYPE html>

<html>
<head runat="server">
    <meta name="viewport" content="width=device-width" />
    <title>Login</title>
</head>
<body>


    <script src="<%: Url.Content("~/Scripts/jquery-1.7.1.min.js") %>"></script>
    <script src="<%: Url.Content("~/Scripts/jquery.validate.min.js") %>"></script>
    <script src="<%: Url.Content("~/Scripts/jquery.validate.unobtrusive.min.js") %>"></script>

    <% using (Html.BeginForm())
       { %>
    <%: Html.ValidationSummary(true) %>
    <%: Html.AntiForgeryToken() %>
    <fieldset>
        <legend>User</legend>

        <div class="editor-label">
            <%: Html.LabelFor(model => model.Username) %>
        </div>
        <div class="editor-field">
            <%: Html.EditorFor(model => model.Username) %>
            <%: Html.ValidationMessageFor(model => model.Username) %>
        </div>

        <div class="editor-label">
            <%: Html.LabelFor(model => model.Password) %>
        </div>
        <div class="editor-field">
            <%: Html.EditorFor(model => model.Password) %>
            <%: Html.ValidationMessageFor(model => model.Password) %>
        </div>

        <p>
            <input type="submit" value="Login" />
        </p>
    </fieldset>
    <% } %>
</body>
</html>
