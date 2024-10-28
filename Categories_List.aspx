<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="Categories_List.aspx.cs" Inherits="kiemtraweb.Categories_List" %>
<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server">

    <div>
            <h2>Danh sách Chủ đề</h2>
            <asp:GridView ID="GridViewCategories" runat="server" AutoGenerateColumns="False" OnRowCommand="GridViewCategories_RowCommand" CssClass="table">
                <Columns>
                    <asp:BoundField DataField="PK_CategoryID" HeaderText="Mã chủ đề" Visible="False" />
                    <asp:TemplateField HeaderText="Tên Chủ đề">
                        <ItemTemplate>
                            <asp:LinkButton ID="LinkButton1" runat="server" CommandName="Select" CommandArgument='<%# Eval("PK_CategoryID") %>'>
                                <%# Eval("sCategoryName") %>
                            </asp:LinkButton>
                        </ItemTemplate>
                    </asp:TemplateField>
                </Columns>
            </asp:GridView>
    </div>

</asp:Content>
