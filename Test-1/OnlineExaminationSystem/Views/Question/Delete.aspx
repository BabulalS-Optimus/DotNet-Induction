<%@ Page Language="C#" Inherits="System.Web.Mvc.ViewPage<OnlineExaminationSystem.Entity.Question>" %>

<!DOCTYPE html>

<html>
<head runat="server">
    <meta name="viewport" content="width=device-width" />
    <title>Delete</title>
    <link href="../../Content/Site.css" rel="stylesheet" />
</head>
<body>
    <h3>Are you sure you want to delete this?</h3>
    <fieldset>
        <legend>Question</legend>

        <div class="display-label">
            <%: Html.DisplayNameFor(model => model.Test.Title) %> : <%: Html.DisplayFor(model => model.Test.Title) %>
        </div>

        <div class="display-label">
            <%: Html.DisplayNameFor(model => model.Ques) %> : <%: Html.DisplayFor(model => model.Ques) %>
        </div>

        <div class="display-label">
            <%: Html.DisplayNameFor(model => model.Ans) %> : <%: Html.DisplayFor(model => model.Ans) %>
        </div>
    </fieldset>
    <% using (Html.BeginForm())
       { %>
    <p>
        <input type="submit" value="Delete" />
        |
            <%: Html.ActionLink("Back to Question List", "Index") %> |
            <%: Html.ActionLink("Back to Test List", "GoToTests") %> |
            <%: Html.ActionLink("Logout", "Logout")%> 
    </p>
    <% } %>

</body>
</html>
