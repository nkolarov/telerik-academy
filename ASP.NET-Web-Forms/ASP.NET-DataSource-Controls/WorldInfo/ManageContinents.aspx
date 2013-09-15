<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="ManageContinents.aspx.cs" Inherits="WorldInfo.ManageContinents" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>Manage Continents</title>
</head>
<body>
    <form id="formManageContinents" runat="server">
        <h3>Manage Continents</h3>
        <asp:EntityDataSource
            ID="EntityDataSourceContinents"
            runat="server"
            ConnectionString="name=WorldInfoEntities"
            DefaultContainerName="WorldInfoEntities"
            EnableDelete="True"
            EnableFlattening="False"
            EntitySetName="Continents">
        </asp:EntityDataSource>
        <asp:GridView
            ID="GridViewContinents"
            runat="server"
            AllowSorting="True"
            DataKeyNames="Id"
            DataSourceID="EntityDataSourceContinents"
            ItemType="WorldInfo.Continent"
            AutoGenerateColumns="false">
            <Columns>
                <asp:BoundField DataField="Name" HeaderText="Name" SortExpression="Name" />
                <asp:HyperLinkField Text="Edit" DataNavigateUrlFields="Id"
                    DataNavigateUrlFormatString="EditContinent.aspx?continentId={0}" />
                <asp:TemplateField>
                    <ItemTemplate>
                        <asp:LinkButton ID="LinkButtonDeleteContinent" runat="server"
                            CommandName="Delete"
                            CommandArgument="<%# Item.Id %>"
                            OnClientClick="return confirm('Do you want to cancel ?');"
                            OnCommand="LinkButtonDeleteContinent_Command"
                            Text="Delete" />
                    </ItemTemplate>
                </asp:TemplateField>
            </Columns>
        </asp:GridView>
        <asp:LinkButton ID="LinkButtonCreateNewContinent" runat="server"
            Text="Create New Continent"
            OnClick="LinkButtonCreateNewContinent_Click" />
        <section id="sectionCreateContinent" runat="server" visible="false">
            <h3>Fill new continent info:</h3>
            <asp:Label ID="LabelContinentName" Text="Name" runat="server" AssociatedControlID="TextBoxContinentName"/>
            <asp:TextBox ID="TextBoxContinentName" runat="server" />
            <asp:RequiredFieldValidator
                ID="RequiredFieldValidatorContinentName"
                runat="server"
                ErrorMessage="Continent Name is Required!"
                ControlToValidate="TextBoxContinentName" />
            <asp:CustomValidator
                ID="CustomValidatorContinentName"
                runat="server"
                ErrorMessage="The Name is too long! Max 50 symbols allowed!"
                ControlToValidate="TextBoxContinentName"
                OnServerValidate="CustomValidatorContinentName_ServerValidate" />
            <br />
            <asp:LinkButton ID="LinkButtonSaveQuestion" runat="server"
                Text="Save" OnClick="LinkButtonSaveQuestion_Click" />
            <br />
            <a href="ManageContinents.aspx">Cancel</a>
            <asp:Literal Id="LiteralErrorMessage" runat="server" Visible="false"/>
        </section>
    </form>
    <br />
    <a href="WorldInfo.aspx">Back to WorldInfo</a>
</body>
</html>
