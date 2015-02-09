<%@ Page Language="C#" Inherits="System.Web.Mvc.ViewPage<Sample.Models.FileHandler>" %>

<!DOCTYPE html>

<html>
<head runat="server">
    <meta name="viewport" content="width=device-width" />
    <title>Create</title>
</head>
<body>
    <script src="<%: Url.Content("~/Scripts/jquery-1.7.1.min.js") %>"></script>
    <script src="<%: Url.Content("~/Scripts/jquery.validate.min.js") %>"></script>
    <script src="<%: Url.Content("~/Scripts/jquery.validate.unobtrusive.min.js") %>"></script>

    <% using (Html.BeginForm())
       { %>
    <%: Html.ValidationSummary(true) %>

    <fieldset>
        <legend>FileHandler</legend>

        <div class="editor-label">
            <%: Html.LabelFor(model => model.UserID) %>
        </div>
        <div class="editor-field">
            <%: Html.EditorFor(model => model.UserID) %>
            <%: Html.ValidationMessageFor(model => model.UserID) %>
        </div>

        <div class="editor-label">
            <%: Html.LabelFor(model => model.FilePath) %>
        </div>
        <div class="editor-field">
            <%: Html.EditorFor(model => model.FilePath) %>
            <%: Html.ValidationMessageFor(model => model.FilePath) %>
        </div>

        <p>
            <input type="submit" value="Create" />
        </p>
    </fieldset>
    <% } %>

    <div>
        <%: Html.ActionLink("Back to List", "Index") %>
        <%: Html.ActionLink("Logout","Logout") %>
    </div>
</body>
</html>
