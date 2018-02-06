
C21.IMP.Framework.Client.BaseLogic
IPortalServiceContract 

验证
登录




1.取消掉门店服务器验证
1.1.增加验证服务器,每个SIS客户端分配一个Guid

1.1.1.获取门店证书:SetPortalInfoesByShopTimerElapsed();
      证书是作什么用的
1.1.1.获取平台服务相对于客户端的服务地址信息:GetPortalAbsoluteUri();
      直接配置到UI上
1.1.1.获取平台服务相对于客户端的无 Session 的服务地址信息:GetPortalNoneSessionAbsoluteUri();
      直接配置到UI上
1.1.1.获取客户端可能用到的所有的模块、功能、菜单等:GetAllClientFunctions();   


2.要在客户端增加指向portal服务器的配置文件
2.1.获取服务端地址
2.1.1.服务地址-是为了获取无Session地址?
2.1.2.无Session的服务地址
    在登录时是否需要根据门店的guid区注册服务器获取服务地址



3.在后台添加门店时，生成门店序列号GUID
  增注册服务端,服务于所有的区域,登录时要去注册服务器要服务端地址,或者服务端地址用域名来实现换IP

4.在客户端第一次登录时，注册用GUID  注册程序修改

5.验证客户端硬件（原来在门店，现在在portal）
  找到收集硬件的地方,
  看有什么用

6.取消掉每次操作验证客户端，改为登录时验证一次
  认证
  授权


