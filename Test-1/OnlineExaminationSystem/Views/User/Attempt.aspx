<%@ Page Language="C#" Inherits="System.Web.Mvc.ViewPage<OnlineExaminationSystem.Entity.Answer>" %>

<!DOCTYPE html>

<html>
<head id="Head1" runat="server">
    <meta name="viewport" content="width=device-width" />
    <title>Attempt</title>
    <link href="../../Content/Site.css" rel="stylesheet" />
</head>
<body>
    <h3>Test for : <b><%: Html.DisplayFor(modelItem => Model.Test.Title) %></b></h3>
    <% using (Html.BeginForm())
       { %>
    <%: Html.ValidationSummary(true) %>

    <fieldset>
        <legend>Question No. : <%: Model.QuesID %></legend>

        <input type="hidden" value="<%: Model.ID.ToString() %>" name="ansID" />
        <input type="hidden" value="<%: Model.Test.ID.ToString() %>" name="testID" />
        <input type="hidden" value="<%: Model.Question.ID.ToString() %>" name="quesID" />

        Question :  <%: Html.DisplayFor(modelItem => Model.Question.Ques) %>
        <br />
        Answer :  <%: Html.EditorFor(modelItem => Model.Ans) %>

        <p>
            <input type="submit" value="Next" />
        </p>
    </fieldset>
    <% } %>


    <%: Html.ActionLink("Logout", "Logout")%>
</body>
</html>
