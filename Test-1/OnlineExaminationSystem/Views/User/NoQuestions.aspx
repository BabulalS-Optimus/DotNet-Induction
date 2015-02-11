<%@ Page Language="C#" Inherits="System.Web.Mvc.ViewPage<dynamic>" %>

<!DOCTYPE html>

<html>
<head id="Head1" runat="server">
    <meta name="viewport" content="width=device-width" />
    <title>NoQuestions</title>
</head>
<body>
    <div>
        <h4>There are no questions in this test.</h4>
        <%: Html.ActionLink("Show test List", "TestList")%> |
        <%: Html.ActionLink("Logout", "Logout")%>
    </div>
</body>
</html>
