<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="News_Detail.aspx.cs" Inherits="kiemtraweb.News_Detail" %>
<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server">

    <div>
            <h2 id="lblTitle" runat="server"></h2>
            <p id="lblAbstract" runat="server"></p>
            <p><strong>Ngày đăng: </strong><span id="lblPostedDate" runat="server"></span></p>
            <p><strong>Chủ đề: </strong><span id="lblCategory" runat="server"></span></p>
            <p id="lblContent" runat="server"></p>
            <p><strong>Số lần xem: </strong><span id="lblViewTimes" runat="server"></span></p>
        </div>

</asp:Content>
