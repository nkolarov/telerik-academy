<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="WorldInfo.aspx.cs" Inherits="WorldInfo.WorldInfo" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>World Info</title>
</head>
<body>
    <form id="formWorldInfo" runat="server">
        <asp:Label ID="LabelContinents" runat="server" Text="Continents:"></asp:Label>
        <br />
        <asp:EntityDataSource
            ID="EntityDataSourceContinents"
            runat="server"
            ConnectionString="name=WorldInfoEntities"
            DefaultContainerName="WorldInfoEntities"
            EnableDelete="True"
            EnableFlattening="False"
            EnableInsert="True"
            EnableUpdate="True"
            EntitySetName="Continents" />
        <asp:ListBox
            ID="ListBoxContinents"
            runat="server"
            DataSourceID="EntityDataSourceContinents"
            DataTextField="Name"
            DataValueField="Id"
            AutoPostBack="true" />
        <br />
        <asp:LinkButton Text="Manage Continents" runat="server" PostBackUrl="~/ManageContinents.aspx" />
        <br />
        <asp:Label ID="LabelCountries" runat="server" Text="Countries:"></asp:Label>
        <asp:EntityDataSource
            ID="EntityDataSourceCountries"
            runat="server"
            ConnectionString="name=WorldInfoEntities"
            DefaultContainerName="WorldInfoEntities"
            EnableFlattening="False"
            EntitySetName="Countries"
            Include="Continent"
            Where="it.Continent.Id=@ContId">
            <WhereParameters>
                <asp:ControlParameter Name="ContId" Type="Int32"
                    ControlID="ListBoxContinents" />
            </WhereParameters>
        </asp:EntityDataSource>
        <br />
        <asp:GridView
            ID="GridViewCountries"
            runat="server"
            AllowPaging="True"
            PageSize="3"
            AllowSorting="True"
            DataSourceID="EntityDataSourceCountries"
            AutoGenerateColumns="False"
            DataKeyNames="Id">
            <Columns>
                <asp:CommandField ShowSelectButton="True" />
                <asp:BoundField DataField="Name" HeaderText="Name" SortExpression="Name" />
                <asp:BoundField DataField="Language" HeaderText="Language" SortExpression="Language" />
                <asp:BoundField DataField="Population" HeaderText="Population" SortExpression="Population" />
                <asp:ImageField DataImageUrlField="Id" DataImageUrlFormatString="~/ImageHandler.ashx?countryId={0}" HeaderText="Flag"/>
            </Columns>
        </asp:GridView>
        <asp:LinkButton Text="Manage Countries" runat="server" PostBackUrl="~/ManageCountries.aspx" />
        <asp:EntityDataSource
            ID="EntityDataSourceTowns"
            runat="server"
            ConnectionString="name=WorldInfoEntities"
            DefaultContainerName="WorldInfoEntities"
            EnableFlattening="False"
            EntitySetName="Towns"
            Include="Country"
            Where="it.Country.Id=@CountId" EnableDelete="True" EnableInsert="True" EnableUpdate="True">
            <WhereParameters>
                <asp:ControlParameter Name="CountId" Type="Int32"
                    ControlID="GridViewCountries" />
            </WhereParameters>
        </asp:EntityDataSource>
        <asp:ListView
            ID="ListViewTowns"
            runat="server"
            DataKeyNames="Id"
            DataSourceID="EntityDataSourceTowns">
            <ItemTemplate>
                <tr style="background-color: #DCDCDC; color: #000000;">
                    <td>
                        <asp:Label ID="NameLabel" runat="server" Text='<%#: Eval("Name") %>' />
                    </td>
                    <td>
                        <asp:Label ID="PopulationLabel" runat="server" Text='<%#: Eval("Population") %>' />
                    </td>
                </tr>
            </ItemTemplate>
            <LayoutTemplate>
                <table runat="server">
                    <tr runat="server">
                        <td runat="server">
                            <table id="itemPlaceholderContainer" runat="server" border="1" style="background-color: #FFFFFF; border-collapse: collapse; border-color: #999999; border-style: none; border-width: 1px; font-family: Verdana, Arial, Helvetica, sans-serif;">
                                <tr runat="server" style="background-color: #DCDCDC; color: #000000;">
                                    <th runat="server">Name</th>
                                    <th runat="server">Population</th>
                                </tr>
                                <tr id="itemPlaceholder" runat="server">
                                </tr>
                            </table>
                        </td>
                    </tr>
                    <tr runat="server">
                        <td runat="server" style="text-align: center; background-color: #CCCCCC; font-family: Verdana, Arial, Helvetica, sans-serif; color: #000000;">
                            <asp:DataPager ID="DataPager1" runat="server" PageSize="2">
                                <Fields>
                                    <asp:NextPreviousPagerField ButtonType="Button" ShowFirstPageButton="True" ShowNextPageButton="False" ShowPreviousPageButton="False" />
                                    <asp:NumericPagerField />
                                    <asp:NextPreviousPagerField ButtonType="Button" ShowLastPageButton="True" ShowNextPageButton="False" ShowPreviousPageButton="False" />
                                </Fields>
                            </asp:DataPager>
                        </td>
                    </tr>
                </table>
            </LayoutTemplate>
        </asp:ListView>
        <br />
        <asp:LinkButton Text="Manage Towns" runat="server" PostBackUrl="~/ManageTowns.aspx" />
    </form>
</body>
</html>
