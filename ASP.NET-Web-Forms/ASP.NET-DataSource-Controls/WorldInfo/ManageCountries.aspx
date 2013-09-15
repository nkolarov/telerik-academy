<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="ManageCountries.aspx.cs" Inherits="WorldInfo.ManageCountries" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>Manage Countries</title>
</head>
<body>
    <form id="formManageCountries" runat="server">
        <h3>Manage Countries</h3>
        <asp:EntityDataSource
            ID="EntityDataSourceCountries"
            runat="server"
            ConnectionString="name=WorldInfoEntities"
            DefaultContainerName="WorldInfoEntities"
            EnableDelete="True"
            Include="Continent"
            AutoPage="true"
            EnableFlattening="False"
            EntitySetName="Countries">
        </asp:EntityDataSource>
        <asp:GridView
            ID="GridViewCountries"
            runat="server"
            AllowPaging="True"
            PageSize="3"
            AllowSorting="True"
            DataKeyNames="Id"
            DataSourceID="EntityDataSourceCountries"
            ItemType="WorldInfo.Country"
            AutoGenerateColumns="False">
            <Columns>
                <asp:BoundField DataField="Name" HeaderText="Name" SortExpression="Name" />
                <asp:BoundField DataField="Language" HeaderText="Language" SortExpression="Language" />
                <asp:BoundField DataField="Population" HeaderText="Population" SortExpression="Population" />
                <asp:BoundField DataField="Continent.Name" HeaderText="Continent" />
                <asp:ImageField DataImageUrlField="Id" DataImageUrlFormatString="~/ImageHandler.ashx?countryId={0}" HeaderText="Flag">
                </asp:ImageField>
                <asp:HyperLinkField Text="Edit" DataNavigateUrlFields="Id"
                    DataNavigateUrlFormatString="EditCountry.aspx?countryId={0}" />
                <asp:TemplateField>
                    <ItemTemplate>
                        <asp:LinkButton ID="LinkButtonDeleteCountry" runat="server"
                            CommandName="Delete"
                            CommandArgument="<%# Item.Id %>"
                            OnClientClick="return confirm('Do you want to cancel ?');"
                            OnCommand="LinkButtonDeleteCountry_Command"
                            Text="Delete" />
                    </ItemTemplate>
                </asp:TemplateField>
            </Columns>
        </asp:GridView>
        <asp:LinkButton ID="LinkButtonCreateNewCountry" runat="server"
            Text="Create New Country"
            OnClick="LinkButtonCreateNewCountry_Click" />
        <section id="sectionCreateCountry" runat="server" visible="false">
            <h3>Fill new country info:</h3>
            <asp:EntityDataSource ID="EntityDataSourceContinents" runat="server" ConnectionString="name=WorldInfoEntities" DefaultContainerName="WorldInfoEntities" EnableFlattening="False" EntitySetName="Continents"></asp:EntityDataSource>
            <asp:Label ID="LabelContinents" Text="Continent" runat="server" AssociatedControlID="ListBoxContinents" />
            <asp:DropDownList ID="ListBoxContinents" runat="server" AppendDataBoundItems="True" DataSourceID="EntityDataSourceContinents" DataTextField="Name" DataValueField="Id">
                <asp:ListItem Text="--Select--" Value="-1" />
            </asp:DropDownList>
            <asp:CustomValidator
                ID="CustomValidatorContinent"
                runat="server"
                ErrorMessage="You must select a continent!"
                ControlToValidate="ListBoxContinents"
                OnServerValidate="CustomValidatorContinent_ServerValidate" />
            <br />
            <asp:Label ID="LabelCountryName" Text="Name" runat="server" AssociatedControlID="TextBoxCountryName" />
            <asp:TextBox ID="TextBoxCountryName" runat="server" />
            <asp:RequiredFieldValidator
                ID="RequiredFieldValidatorCountryName"
                runat="server"
                ErrorMessage="Country Name is Required!"
                ControlToValidate="TextBoxCountryName" />
            <asp:CustomValidator
                ID="CustomValidatorCountryName"
                runat="server"
                ErrorMessage="The Name is too long! Max 50 symbols allowed!"
                ControlToValidate="TextBoxCountryName"
                OnServerValidate="CustomValidatorCountryName_ServerValidate" />
            <br />
            <asp:Label ID="LabelLanguage" Text="Language" runat="server" AssociatedControlID="TextBoxLanguage" />
            <asp:TextBox ID="TextBoxLanguage" runat="server" />
            <asp:RequiredFieldValidator
                ID="RequiredFieldValidatorLanguage"
                runat="server"
                ErrorMessage="Country Name is Required!"
                ControlToValidate="TextBoxLanguage" />
            <asp:CustomValidator
                ID="CustomValidatorLanguage"
                runat="server"
                ErrorMessage="The Language is too long! Max 50 symbols allowed!"
                ControlToValidate="TextBoxLanguage"
                OnServerValidate="CustomValidatorCountryName_ServerValidate" />
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
            <asp:Label ID="LabelFlag" Text="Flag" runat="server" AssociatedControlID="FileUploadFlag" />
            <asp:FileUpload ID="FileUploadFlag" runat="server" />
            <br />
            <asp:LinkButton ID="LinkButtonSaveCountry" runat="server"
                Text="Save" OnClick="LinkButtonSaveCountry_Click" />
            <br />
            <a href="ManageCountries.aspx">Cancel</a>
            <asp:Literal ID="LiteralErrorMessage" runat="server" Visible="false" />
        </section>
    </form>
    <br />
    <a href="WorldInfo.aspx">Back to WorldInfo</a>
</body>
</html>
