<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="EmployeesOrders.aspx.cs" Inherits="EmployeesOrdersWithAJAX.EmployeesOrders" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>Employees</title>
</head>
<body>
    <form id="formEmployees" runat="server">
        <asp:ScriptManager ID="ScriptManager" runat="server">
        </asp:ScriptManager>
        <asp:UpdatePanel ID="UpdatePanelEmployees" runat="server">
            <ContentTemplate>
                <asp:GridView ID="GridViewEmployees" runat="server" DataKeyNames="EmployeeId" OnSelectedIndexChanged="GridViewEmployees_SelectedIndexChanged" AutoGenerateSelectButton="true" AutoGenerateColumns="false">
                    <Columns>
                        <asp:BoundField DataField="EmployeeID" HeaderText="EmployeeID" SortExpression="EmployeeID" />
                        <asp:BoundField DataField="LastName" HeaderText="LastName" SortExpression="LastName" />
                        <asp:BoundField DataField="FirstName" HeaderText="FirstName" SortExpression="FirstName" />
                        <asp:BoundField DataField="Title" HeaderText="Title" SortExpression="Title" />
                    </Columns>
                </asp:GridView>
            </ContentTemplate>
        </asp:UpdatePanel>
        <asp:UpdatePanel ID="UpdatePanelOrders" runat="server">
            <ContentTemplate>
                <asp:GridView ID="GridViewOrders" runat="server" AutoGenerateColumns="false">
                    <Columns>
                        <asp:BoundField DataField="OrderID" HeaderText="OrderID" SortExpression="OrderID" />
                        <asp:BoundField DataField="OrderDate" HeaderText="OrderDate" SortExpression="OrderDate" />
                        <asp:BoundField DataField="ShipCountry" HeaderText="ShipCountry" SortExpression="ShipCountry" />
                    </Columns>
                </asp:GridView>
            </ContentTemplate>
        </asp:UpdatePanel>
        <asp:UpdateProgress ID="UpdateProgressOrders" AssociatedUpdatePanelID="UpdatePanelEmployees" runat="server">
            <ProgressTemplate>
                <img src="Images/hourglass.png" />
            </ProgressTemplate>
        </asp:UpdateProgress>
    </form>
</body>
</html>
