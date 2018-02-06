
C21.IMP.Framework.Service.ShopHost/ShopHostContainer.cs

/// <summary>
/// 获取平台服务器的 Absolute Uri 地址
/// </summary>
/// <param name="requestInfo"></param>
/// <returns></returns>
public byte[] GetAbsoluteUriPortalServer(byte[] requestInfo)
{
    return GetAbsoluteUriPortalServer(requestInfo, true);
}

/// <summary>
/// 获取无 Session 的平台服务器的 Absolute Uri 地址
/// </summary>
/// <param name="requestInfo"></param>
/// <returns></returns>
public byte[] GetAbsoluteUriPortalNoneSessionServer(byte[] requestInfo)
{
    return GetAbsoluteUriPortalServer(requestInfo, false);
}

