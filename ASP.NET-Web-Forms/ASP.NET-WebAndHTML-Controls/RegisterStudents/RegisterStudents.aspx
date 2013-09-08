<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="RegisterStudents.aspx.cs" Inherits="RegisterStudents.RegisterStudents" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
</head>
<body>
    <form id="registrationForm" runat="server">
        <div>
            <asp:Label ID="LabelFirstName" runat="server" CssClass="label">First Name: </asp:Label>
            <asp:TextBox ID="TextBoxFirstName" runat="server" CssClass="textbox" /><br />

            <asp:Label ID="LabelLastName" runat="server" CssClass="label">Last Name: </asp:Label>
            <asp:TextBox ID="TextBoxLastName" runat="server" CssClass="textbox" /><br />

            <asp:Label ID="LabelFacultyNumber" runat="server" CssClass="label">Faculty Number: </asp:Label>
            <asp:TextBox ID="TextBoxFacultyNumber" runat="server" CssClass="textbox" /><br />

            <asp:Label ID="LabelUniversities" runat="server" CssClass="label">Universities: </asp:Label>
            <asp:DropDownList ID="DropDownListUniversities" AutoPostBack="False" runat="server">
                <asp:ListItem Selected="True" Value="Telerik Academy"> Telerik Academy </asp:ListItem>
                <asp:ListItem> SU </asp:ListItem>
                <asp:ListItem> TU </asp:ListItem>
            </asp:DropDownList><br />

            <asp:Label ID="LabelCourses" runat="server" CssClass="label">Courses: </asp:Label>
            <asp:CheckBoxList ID="CkeckBoxListCourses" runat="server">
                <asp:ListItem>ASP.Net Web Forms</asp:ListItem>
                <asp:ListItem>ASP.Net MVC</asp:ListItem>
            </asp:CheckBoxList>

            <asp:Button ID="ButtonSubmit" runat="server" Text="Register Student!" OnClick="ButtonSubmit_Click" /><br />
        </div>
    </form>
</body>
</html>
