<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="News_List.aspx.cs" Inherits="kiemtraweb.News_List" %>
<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server">
    <div>
            <h2>Danh sách Tin tức theo Chủ đề</h2>
            <asp:GridView ID="GridViewNews" runat="server" CssClass="table" AutoGenerateColumns="false" OnRowCommand="GridViewNews_RowCommand">
                <Columns>
                    <asp:BoundField DataField="PK_iNewsID" HeaderText="Mã tin" Visible="False" />
                    <asp:TemplateField HeaderText="Tiêu đề">
                        <ItemTemplate>
                            <asp:LinkButton ID="LinkButton1" runat="server" CommandName="Select" CommandArgument='<%# Eval("PK_iNewsID") %>'>
                                <%# Eval("sTitle") %>
                            </asp:LinkButton>
                        </ItemTemplate>
                    </asp:TemplateField>
                    <asp:BoundField DataField="sAbstract" HeaderText="Tóm tắt" />
                    <asp:BoundField DataField="tPostedDate" HeaderText="Ngày đăng" DataFormatString="{0:dd/MM/yyyy}" />
                </Columns>
            </asp:GridView>
        </div>
</asp:Content>
