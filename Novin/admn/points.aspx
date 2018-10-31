<%@ Page Title="" Language="C#" MasterPageFile="~/admn/admaster.Master" AutoEventWireup="true" CodeBehind="points.aspx.cs" Inherits="Novin.admn.points" %>

<asp:Content ID="Content2" ContentPlaceHolderID="bodycontent" runat="server">
    <style>
        .pointbody{width: 50%;margin: auto;text-align: right;}
        table tr td input{ text-align: center;width: 100px;}
        table tr td:first-child{ display: none;}
        table tr th:first-child{ display: none;}
    </style>
    <div class="pointbody">
        <asp:GridView runat="server" CssClass="admintable" ID="gridpoints" AutoGenerateColumns="False" DataSourceID="Sqlpoints">
            <Columns>
                <asp:BoundField DataField="id" SortExpression="id"/>
                <asp:BoundField ReadOnly="True" DataField="bimetype" HeaderText="نوع بیمه" SortExpression="bimetype" />
                <asp:BoundField DataField="tot" HeaderText="مبلغ" SortExpression="tot" />
                <asp:BoundField DataField="point" HeaderText="امتیاز" SortExpression="point" />
                <asp:CommandField EditText="ویرایش" ShowEditButton="True"/>
            </Columns>
        </asp:GridView>
        <asp:SqlDataSource ID="Sqlpoints" runat="server" ConnectionString="<%$ ConnectionStrings:novin %>" SelectCommand="SELECT bimetype, tot, point, id FROM points" UpdateCommand="UPDATE points SET tot = @tot, point = @point WHERE (id = @id)">
            <UpdateParameters>
                <asp:Parameter Name="tot" />
                <asp:Parameter Name="point" />
                <asp:Parameter Name="id" />
            </UpdateParameters>
        </asp:SqlDataSource>
    </div>
</asp:Content>
