<%@ Page Language="C#" Inherits="System.Web.Mvc.ViewPage<OnlineExaminationSystem.Entity.Question>" %>

<!DOCTYPE html>

<html>
<head runat="server">
    <meta name="viewport" content="width=device-width" />
    <title>Details</title>
</head>
<body>
    <fieldset>
        <legend>Question</legend>

        <div class="display-label">
            <%: Html.DisplayNameFor(model => model.Test.Title)%> : <%: Html.DisplayFor(model => model.Test.Title)%>
        </div>

        <div class="display-label">
            <%: Html.DisplayNameFor(model => model.Ques)%> : <%: Html.DisplayFor(model => model.Ques)%>
        </div>

        <div class="display-label">
            <%: Html.DisplayNameFor(model => model.Ans)%> : <%: Html.DisplayFor(model => model.Ans)%>
        </div>
    </fieldset>
    <p>

        <%: Html.ActionLink("Edit", "Edit", new { id = Model.ID })%> |
        <%: Html.ActionLink("Back to Question List", "Index") %> | 
        <%: Html.ActionLink("Back to Test List", "GoToTests")%> |
        <%: Html.ActionLink("Logout", "Logout")%>
    </p>
</body>
</html>
