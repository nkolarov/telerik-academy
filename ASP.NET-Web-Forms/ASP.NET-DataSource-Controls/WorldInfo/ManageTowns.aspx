<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="ManageTowns.aspx.cs" Inherits="WorldInfo.ManageTowns" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
</head>
<body>
    <form id="formManageTowns" runat="server">
        <h3>Manage Towns</h3>
        <asp:EntityDataSource
            ID="EntityDataSourceTowns"
            runat="server"
            ConnectionString="name=WorldInfoEntities"
            DefaultContainerName="WorldInfoEntities"
            EnableDelete="True"
            Include="Country, Country.Continent"
            AutoPage="true"
            EnableFlattening="False"
            EntitySetName="Towns">
        </asp:EntityDataSource>
        <asp:GridView
            ID="GridViewTowns"
            runat="server"
            AllowPaging="True"
            PageSize="10"
            AllowSorting="True"
            DataKeyNames="Id"
            DataSourceID="EntityDataSourceTowns"
            ItemType="WorldInfo.Town"
            AutoGenerateColumns="false">
            <Columns>
                <asp:BoundField DataField="Name" HeaderText="Name" SortExpression="Name" />
                <asp:BoundField DataField="Population" HeaderText="Population" SortExpression="Population" />
                <asp:BoundField DataField="Country.Name" HeaderText="Country" />
                <asp:BoundField DataField="Country.Continent.Name" HeaderText="Continent" />
                <asp:HyperLinkField Text="Edit" DataNavigateUrlFields="Id"
                    DataNavigateUrlFormatString="EditTown.aspx?townId={0}" />
                <asp:TemplateField>
                    <ItemTemplate>
                        <asp:LinkButton ID="LinkButtonDeleteTown" runat="server"
                            CommandName="Delete"
                            CommandArgument="<%# Item.Id %>"
                            OnClientClick="return confirm('Do you want to cancel ?');"
                            OnCommand="LinkButtonDeleteTown_Command"
                            Text="Delete" />
                    </ItemTemplate>
                </asp:TemplateField>
            </Columns>
        </asp:GridView>
        <asp:LinkButton ID="LinkButtonCreateNewTown" runat="server"
            Text="Create New Town"
            OnClick="LinkButtonCreateNewTown_Click" />
        <section id="sectionCreateTown" runat="server" visible="false">
            <h3>Fill new town info:</h3>
            <asp:EntityDataSource ID="EntityDataSourceCountries" runat="server" ConnectionString="name=WorldInfoEntities" DefaultContainerName="WorldInfoEntities" EnableFlattening="False" EntitySetName="Countries"></asp:EntityDataSource>
            <asp:Label ID="LabelCountries" Text="Country" runat="server" AssociatedControlID="ListBoxCountries" />
            <asp:DropDownList ID="ListBoxCountries" runat="server" AppendDataBoundItems="True" DataSourceID="EntityDataSourceCountries" DataTextField="Name" DataValueField="Id">
                <asp:ListItem Text="--Select--" Value="-1" />
            </asp:DropDownList>
            <asp:CustomValidator
                ID="CustomValidatorCountry"
                runat="server"
                ErrorMessage="You must select a country!"
                ControlToValidate="ListBoxCountries"
                OnServerValidate="CustomValidatorCountry_ServerValidate" />
            <br />
            <asp:Label ID="LabelTownName" Text="Name" runat="server" AssociatedControlID="TextBoxTownName" />
            <asp:TextBox ID="TextBoxTownName" runat="server" />
            <asp:RequiredFieldValidator
                ID="RequiredFieldValidatorTownName"
                runat="server"
                ErrorMessage="Town Name is Required!"
                ControlToValidate="TextBoxTownName" />
            <asp:CustomValidator
                ID="CustomValidatorTownName"
                runat="server"
                ErrorMessage="The Name is too long! Max 50 symbols allowed!"
                ControlToValidate="TextBoxTownName"
                OnServerValidate="CustomValidatorTownName_ServerValidate" />
            <br />
            <asp:Label ID="LabelPopulation" Text="Population" runat="server" AssociatedControlID="TextBoxPopulation" />
            <asp:TextBox ID="TextBoxPopulation" runat="server" TextMode="Number" />
            <asp:RequiredFieldValidator
                ID="RequiredFieldValidatorPopulation"
                runat="server"
                ErrorMessage="Population is Required!"
                ControlToValidate="TextBoxPopulation" />
            <asp:CustomValidator
                ID="CustomValidatorPopulation"
                runat="server"
                ErrorMessage="The Population is too long! Max 18 symbols allowed!"
                ControlToValidate="TextBoxPopulation"
                OnServerValidate="CustomValidatorPopulation_ServerValidate" />
            <br />
            <asp:LinkButton ID="LinkButtonSaveTown" runat="server"
                Text="Save" OnClick="LinkButtonSaveTown_Click" />
            <br />
            <a href="ManageTowns.aspx">Cancel</a>
            <asp:Literal ID="LiteralErrorMessage" runat="server" Visible="false" />
        </section>
    </form>
    <br />
    <a href="WorldInfo.aspx">Back to WorldInfo</a>
</body>
</html>
