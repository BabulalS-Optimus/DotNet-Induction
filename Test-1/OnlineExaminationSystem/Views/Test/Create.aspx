<%@ Page Language="C#" Inherits="System.Web.Mvc.ViewPage<OnlineExaminationSystem.Entity.Test>" %>

<!DOCTYPE html>

<html>
<head runat="server">
    <meta name="viewport" content="width=device-width" />
    <title>Create</title>
    <link href="../../Content/Site.css" rel="stylesheet" />
</head>
<body>
    <script src="<%: Url.Content("~/Scripts/jquery-1.7.1.min.js") %>"></script>
    <script src="<%: Url.Content("~/Scripts/jquery.validate.min.js") %>"></script>
    <script src="<%: Url.Content("~/Scripts/jquery.validate.unobtrusive.min.js") %>"></script>

    <% using (Html.BeginForm())
       { %>
    <%: Html.ValidationSummary(true) %>

    <fieldset>
        <legend>Test</legend>

        <div class="editor-label">
            <%: Html.LabelFor(model => model.Title) %>
        </div>
        <div class="editor-field">
            <%: Html.EditorFor(model => model.Title) %>
            <%: Html.ValidationMessageFor(model => model.Title) %>
        </div>

        <div class="editor-label">
            <%: Html.LabelFor(model => model.Organiser, "User") %>
        </div>
        <div class="editor-field">
            <%: Html.DropDownList("Organiser", String.Empty) %>
            <%: Html.ValidationMessageFor(model => model.Organiser) %>
        </div>

        <p>
            <input type="submit" value="Create" />
        </p>
    </fieldset>
    <% } %>

    <div>
        <%: Html.ActionLink("Back to List", "Index") %> |  <%: Html.ActionLink("Logout", "Logout")%>
    </div>
</body>
</html>
