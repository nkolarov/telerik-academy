<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Employees.aspx.cs" Inherits="EmployeesWithListView.Employees" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>Employees</title>
    <style>
        dl {
            border: 1px solid black;
            width: 500px;
        }
    </style>
</head>
<body>
    <form id="employeesForm" runat="server">
        <asp:ListView ID="ListViewEmployees" runat="server">
            <ItemTemplate>
                <h3><%#: Eval("TitleOfCourtesy") + " " + Eval("FirstName") + " " + Eval("LastName") %></h3>
                <dl>
                    <dt>Title</dt>
                    <dd><%#: Eval("Title")%></dd>
                    <dt>BirthDate</dt>
                    <dd><%#: Eval("BirthDate")%></dd>
                    <dt>BirthDate</dt>
                    <dd><%#: Eval("BirthDate")%></dd>
                    <dt>Address</dt>
                    <dd><%#: Eval("Address")%></dd>
                    <dt>City</dt>
                    <dd><%#: Eval("City")%></dd>
                    <dt>Region</dt>
                    <dd><%#: Eval("Region")%></dd>
                    <dt>PostalCode</dt>
                    <dd><%#: Eval("PostalCode")%></dd>
                    <dt>Country</dt>
                    <dd><%#: Eval("Country")%></dd>
                    <dt>HomePhone</dt>
                    <dd><%#: Eval("HomePhone")%></dd>
                    <dt>Notes</dt>
                    <dd><%#: Eval("Notes")%></dd>
                </dl>
            </ItemTemplate>
        </asp:ListView>
    </form>
</body>
</html>
