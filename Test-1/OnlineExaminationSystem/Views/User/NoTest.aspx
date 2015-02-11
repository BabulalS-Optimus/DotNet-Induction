<%@ Page Language="C#" Inherits="System.Web.Mvc.ViewPage<dynamic>" %>

<!DOCTYPE html>

<html>
<head runat="server">
    <meta name="viewport" content="width=device-width" />
    <title>NoTest</title>
</head>
<body>
    <div>
        <h4>You have no Tests to attempt.</h4>
        <%: Html.ActionLink("Logout", "Logout")%>
    </div>
</body>
</html>
