<%@ Page Language="C#" Inherits="System.Web.Mvc.ViewPage<OnlineExaminationSystem.Entity.Activity>" %>

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
        <legend>Activity</legend>

        <div class="editor-label">
            <%: Html.LabelFor(model => model.Organiser, "Organiser") %> :
            <%: Html.DropDownList("Organiser", String.Empty) %>
            <%: Html.ValidationMessageFor(model => model.Organiser) %>
        </div>

        <div class="editor-label">
            <%: Html.LabelFor(model => model.TestID, "Test") %> :
            <%: Html.DropDownList("TestID", String.Empty) %>
            <%: Html.ValidationMessageFor(model => model.TestID) %>
        </div>

        <div class="editor-label">
            <%: Html.LabelFor(model => model.UserID, "Student") %> :
            <%: Html.DropDownList("UserID", String.Empty) %>
            <%: Html.ValidationMessageFor(model => model.UserID) %>
        </div>

        <p>
            <input type="submit" value="Create" />
        </p>
    </fieldset>
    <% } %>

    <div>
        <%: Html.ActionLink("Back to List", "Index") %> | <%: Html.ActionLink("Logout", "Logout")%>
    </div>
</body>
</html>
