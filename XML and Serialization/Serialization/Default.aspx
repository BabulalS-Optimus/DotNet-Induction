<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Default.aspx.cs" Inherits="Serialization.Default" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
</head>
<body>
    <form id="form1" runat="server">
        <div>
            <asp:Button ID="btnShowBeforeSerialization" runat="server" Text="Show state of object before serialization" OnClick="btnShowBeforeSerialization_Click" />
            <br />
            <asp:Button ID="btnBinarySerialize" runat="server" Text="Serialize using Binary" OnClick="btnBinarySerialize_Click" />
            <asp:Button ID="btnShowAfterSerialization" runat="server" Text="Show state after binary serialization" OnClick="btnShowAfterSerialization_Click" />
            <br />
            <asp:Button ID="btnSerializeXml" runat="server" Text="Serialize using XML" OnClick="btnSerializeXml_Click" />
            <asp:Button ID="btnShowAfterSerializationXml" runat="server" Text="Show state after XML serialization " OnClick="ShowAfterSerializationXml_Click" />
            <br />
            <asp:Button ID="btnSerializeSoap" runat="server" Text="Serialize using SOAP" OnClick="btnSerializeSoap_Click" />
            <asp:Button ID="btnShowAfterSerializationSoap" runat="server" Text="Show state after SOAP serialization" OnClick="ShowAfterSerializationSoap_Click" />
            <br />
            <hr />
            <asp:Button ID="btnShowListBeforeSerialization" runat="server" Text="Show List before serialization" OnClick="btnShowListBeforeSerialization_Click" />
            <br />
            <asp:Button ID="btnBinarySerializeList" runat="server" Text="Serialize the List using Binary" OnClick="btnBinarySerializeList_Click" />
            <asp:Button ID="btnShowListAfterSerialization" runat="server" Text="Show the List after binary serialization" OnClick="btnShowListAfterSerialization_Click" />
            <br />
            <asp:Button ID="btnSerializeListXml" runat="server" Text="Serialize the List using XML" OnClick="btnSerializeListXml_Click" />
            <asp:Button ID="btnShowListAfterSerializationXml" runat="server" Text="Show List after XML serialization " OnClick="btnShowListAfterSerializationXml_Click" />
            <br />
            <asp:Button ID="btnSerializeSoapList" runat="server" Text="Serialize the List using SOAP" OnClick="btnSerializeSoapList_Click" />
            <asp:Button ID="btnShowListAfterSerializationSoap" runat="server" Text="Show List after SOAP serialization" OnClick="btnShowListAfterSerializationSoap_Click" />

        </div>
    </form>
</body>
</html>
