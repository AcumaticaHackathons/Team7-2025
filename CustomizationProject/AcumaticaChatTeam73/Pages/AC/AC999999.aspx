<%@ Page Language="C#" MasterPageFile="~/MasterPages/FormView.master" AutoEventWireup="true" ValidateRequest="false" CodeFile="AC999999.aspx.cs" Inherits="Page_AC999999" Title="Untitled Page" %>

<%@ MasterType VirtualPath="~/MasterPages/FormView.master" %>

<asp:Content ID="cont1" ContentPlaceHolderID="phDS" runat="Server">
    <px:PXDataSource ID="ds" runat="server" Visible="True" Width="100%"
        TypeName="AcumaticaChatTeam7.ChatMessageEntry"
        PrimaryView="ChatumaticaChat">
        <CallbackCommands>
            <px:PXDSCallbackCommand Name="SubmitMessage" Visible="false" CommitChanges="true"></px:PXDSCallbackCommand>
        </CallbackCommands>
    </px:PXDataSource>
</asp:Content>
<asp:Content ID="cont2" ContentPlaceHolderID="phF" runat="Server">
    <px:PXFormView runat="server" ID="CstFormView15" DataSourceID="ds" DataMember="ChatumaticaChat">
        <Template>

            <px:PXLayoutRule ControlSize="XL" LabelsWidth="S" runat="server" ID="CstPXLayoutRule16" StartRow="True"></px:PXLayoutRule>

            <px:PXTextEdit CommitChanges="True" runat="server" ID="edRefNoteID" DataField="RefNoteID"></px:PXTextEdit>
            <px:PXTextEdit SuppressLabel="True" Width="100%" Height="400px" runat="server" ID="edChatLog" DataField="ChatLog" Enabled="False" TextMode="MultiLine">
                <AutoSize Container="Window" Enabled="True" MinHeight="400"></AutoSize>
            </px:PXTextEdit>
            <px:PXTextEdit TextMode="MultiLine" Width="100%" Height="60px" CommitChanges="True" runat="server" ID="edMessage" DataField="Message">
                <AutoSize Enabled="False"></AutoSize>
                <AutoSize MinWidth="100"></AutoSize>
                <AutoSize MinHeight="60"></AutoSize>
            </px:PXTextEdit>
            <px:PXButton runat="server" ID="btnSubmitMessage" Text="Send" AlignLeft="true" CommandSourceID="ds" CommandName="SubmitMessage"></px:PXButton>
        </Template>
        <AutoSize Container="Window" Enabled="True" MinHeight="100"></AutoSize>
    </px:PXFormView>
</asp:Content>

