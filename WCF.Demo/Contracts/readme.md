Contracts：一个类库项目，定义服务契约（Service Contract），
引用System.ServiceMode程序集（WCF框架的绝大部分实现和API定义在该程序集中）

WCF包含四种类型的契约：服务契约、数据契约、消息契约和错误契约

服务契约抽象了服务提供的所有操作；而站在消息交换的角度来看，
服务契约则定义了基于服务调用的消息交换过程中，请求消息和回复消息的"结构"，
以及采用的消息交换模式。
第4章将提供对服务契约的详细介绍。

<!-- 文件服务 客户端 将不再暴露文件服务器的地址 -->
<endpoint name="C21.IMP.Framework.Service.ShopHost.ServerProxy.FileServiceClientProxy" binding="netTcpBinding" bindingConfiguration="NetTcpBinding_C21FileClient" contract="C21.IMP.Framework.Communication.FileContract.IFileContract">
</endpoint>
<!-- 平台（应用）服务 客户端 -->
<!-- 注意在开发环境中将 address 改为 net.tcp://127.0.0.1:10090/C21PortalService -->
<!-- 注意在测试环境中将 address 改为 net.tcp://192.168.112.205:10090/C21PortalService -->
<endpoint name="C21.IMP.Framework.Service.ShopHost.ServerProxy.PortalServiceClientProxy" binding="netTcpBinding" bindingConfiguration="NetTcpBinding_C21PortalClient" address="net.Tcp://127.0.0.1:10090/C21PortalService" contract="C21.IMP.Framework.Communication.ServiceContract.IPortalServiceContract">
</endpoint>
<!-- 平台（应用）服务 客户端（无可靠 Session） -->
<!-- 注意在开发环境中将 address 改为 net.Tcp://127.0.0.1:10095/C21PortalNoneSessionService -->
<!-- 注意在测试环境中将 address 改为 net.Tcp://192.168.112.205:10095/C21PortalNoneSessionService -->
<endpoint name="C21.IMP.Framework.Service.ShopHost.ServerProxy.PortalServiceNoneSessionClientProxy" binding="netTcpBinding" bindingConfiguration="NetTcpBinding_C21PortalClientNoneSession" address="net.Tcp://127.0.0.1:10095/C21PortalNoneSessionService" contract="C21.IMP.Framework.Communication.ServiceContract.IPortalServiceNoneSessionContract">
</endpoint>
<!-- 平台（门店）服务 客户端 -->
<!-- 注意在开发环境中将 address 改为 net.tcp://127.0.0.1:10094/C21Shop2PortalService -->
<!-- 注意在测试环境中将 address 改为 net.tcp://192.168.112.205:10094/C21Shop2PortalService -->
<endpoint name="C21.IMP.Framework.Service.ShopHost.ServerProxy.PortalShopServiceClientProxy" binding="netTcpBinding" bindingConfiguration="netTcpC21Shop2PortalClient" address="net.Tcp://127.0.0.1:10094/C21Shop2PortalService" contract="C21.IMP.Framework.Communication.ServiceContract.IShop2PortalServiceContract">
</endpoint>
</client>
<services>
<!-- 门店服务 服务端 -->
<service name="C21.IMP.Framework.Service.ShopHost.ShopHostContainer" behaviorConfiguration="serviceBehavior">
<endpoint binding="netTcpBinding" contract="C21.IMP.Framework.Communication.ServiceContract.IShopServiceContract" address="C21ShopService" bindingConfiguration="NetTcpBinding_C21ShopService" />
<host>
    <baseAddresses>
    <add baseAddress="net.tcp://localhost:10092/" />
    </baseAddresses>
</host>
</service>
</services>