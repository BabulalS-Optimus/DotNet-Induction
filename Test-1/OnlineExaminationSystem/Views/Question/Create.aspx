<%@ Page Language="C#" Inherits="System.Web.Mvc.ViewPage<OnlineExaminationSystem.Entity.Question>" %>

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
        <legend>Question</legend>

        <div class="editor-label">
            <%: Html.LabelFor(model => model.TestID, "Test") %>
        </div>
        <div class="editor-field">
            <%: Html.DropDownList("TestID", String.Empty) %>
            <%: Html.ValidationMessageFor(model => model.TestID) %>
        </div>

        <div class="editor-label">
            <%: Html.LabelFor(model => model.Ques) %>
        </div>
        <div class="editor-field">
            <%: Html.EditorFor(model => model.Ques) %>
            <%: Html.ValidationMessageFor(model => model.Ques) %>
        </div>

        <div class="editor-label">
            <%: Html.LabelFor(model => model.Ans) %>
        </div>
        <div class="editor-field">
            <%: Html.EditorFor(model => model.Ans) %>
            <%: Html.ValidationMessageFor(model => model.Ans) %>
        </div>

        <p>
            <input type="submit" value="Create" />
        </p>
    </fieldset>
    <% } %>

    <div>
        <%: Html.ActionLink("Back to Question List", "Index") %> |  <%: Html.ActionLink("Logout", "Logout")%>
    </div>
</body>
</html>
