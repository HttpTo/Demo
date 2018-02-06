
Console:实现对定义在Services项目中的服务的寄宿，
该项目须要同时引用Contracts和Services两个项目和System.ServiceMode程序集；

WCF是一个基于消息的通信框架，采用基于终结点（Endpoint）的通信手段。终结点由地址（Address）、绑定（Binding）.和契约（Contract）三要素组成.

地址（Address）：地址决定了服务的位置，解决了服务寻址的问题，《WCF技术剖析(卷1)》第2章提供了对地址和寻址机制的详细介绍；
绑定（Binding）：绑定实现了通信的所有细节，包括网络传输、消息编码，以及其他为实现某种功能（比如安全、可靠传输、事务等）对消息进行的相应处理。WCF中具有一系列的系统定义绑定，比如BasicHttpBinding、WsHttpBinding、NetTcpBinding等，《WCF技术剖析(卷1)》第3章提供对绑定的详细介绍；
契约（Contract）：契约是对服务操作的抽象，也是对消息交换模式以及消息结构的定义。《WCF技术剖析(卷1)》第4章提供对服务契约的详细介绍。 

