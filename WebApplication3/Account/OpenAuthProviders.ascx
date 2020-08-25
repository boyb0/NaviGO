<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="OpenAuthProviders.ascx.cs" Inherits="NaviGO.Account.OpenAuthProviders" %>

<div id="socialLoginList">
    <h4>Use another service to log in.</h4>
    <hr />
    <asp:ListView runat="server" ID="providerDetails" ItemType="System.String"
        SelectMethod="GetProviderNames" ViewStateMode="Disabled">
        <ItemTemplate>
            <p>
                <button type="submit" class="btn btn-default" name="provider" value="<%#: Item %>"
                    title="Log in using your <%#: Item %> account.">
                    <%#: Item %>
                </button>
            </p>
        </ItemTemplate>
        <EmptyDataTemplate>
            <div>
                <a href="https://www.facebook.com" target="_blank"><img src="/img/facebook.png" style="width:70px"/></a>
                <a href="https://www.twitter.com" target="_blank"><img src="/img/twitter.png" style="width:70px"/></a>
                <a href="https://www.instagram.com" target="_blank"><img src="/img/instagram.png" style="width:70px"/></a>
                <a href="https://plus.google.com/discover.com" target="_blank"><img src="/img/google.png" style="width:70px"/></a>
                <a href="https://www.reddit.com" target="_blank"><img src="/img/ebuddy.png" style="width:70px"/></a>
            </div>
        </EmptyDataTemplate>
    </asp:ListView>
</div>
