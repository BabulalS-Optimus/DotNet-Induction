<%@ Page Language="C#" Inherits="System.Web.Mvc.ViewPage<IEnumerable<OnlineExaminationSystem.Entity.Answer>>" %>

<!DOCTYPE html>

<html>
<head id="Head1" runat="server">
    <meta name="viewport" content="width=device-width" />
    <title>Answers</title>
</head>
<body>
    <p>
    </p>
    <table>
        <tr>
            <th>Question ID
            </th>
            <th>Question
            </th>
            <th>Answer
            </th>
        </tr>

        <% foreach (var item in Model)
           { %>
        <tr>
            <td>
                <%: Html.DisplayFor(modelItem => item.Question.ID)%>
            </td>
            <td>
                <%: Html.DisplayFor(modelItem => item.Question.Ques)%>
            </td>
            <td>
                <%: Html.DisplayFor(modelItem => item.Ans)%>
            </td>
        </tr>
        <% } %>
    </table>

    <%: Html.ActionLink("Retake this test", "GetTest", new { id=Model.ToList()[0].TestID }) %> |
    <%: Html.ActionLink("Go to Test List ", "TestList")%> |
     <%: Html.ActionLink("Logout", "Logout")%>
</body>
</html>
