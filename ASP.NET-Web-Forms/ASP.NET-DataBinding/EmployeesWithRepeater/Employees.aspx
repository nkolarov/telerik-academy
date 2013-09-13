<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Employees.aspx.cs" Inherits="EmployeesWithRepeater.Employees" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>Employees</title>
</head>
<body>
    <form id="form1" runat="server">
        <div>
            <asp:Repeater ID="RepeaterEmployees" runat="server">
                <HeaderTemplate>
                    <table>
                        <thead>
                            <th>Title</th>
                            <th>BirthDate</th>
                            <th>BirthDate</th>
                            <th>Address</th>
                            <th>City</th>
                            <th>Region</th>
                            <th>PostalCode</th>
                            <th>Country</th>
                            <th>HomePhone</th>
                            <th>Notes</th>
                        </thead>
                        <tbody>
                </HeaderTemplate>
                <ItemTemplate>
                    <tr><td><%#: Eval("Title")%></td>
                        <td><%#: Eval("BirthDate")%></td>
                        <td><%#: Eval("Address")%></td>
                        <td><%#: Eval("City")%></td>
                        <td><%#: Eval("Region")%></td>
                        <td><%#: Eval("PostalCode")%></td>
                        <td><%#: Eval("Country")%></td>
                        <td><%#: Eval("HomePhone")%></td>
                        <td><%#: Eval("Notes")%></td></tr>
                </ItemTemplate>
                <FooterTemplate>
                    </tobdy>
                    </table>
                </FooterTemplate>
            </asp:Repeater>
        </div>
    </form>
</body>
</html>
