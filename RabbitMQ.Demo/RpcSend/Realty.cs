
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;
    using System.Threading.Tasks;

namespace ProjectSend
{
    /// <summary>
    /// AggregateRoot:房源描述聚合根
    /// </summary>
    public class RealtyIntroduce
    {
        /// <summary>
        /// 区域编码
        /// </summary>
        public string AreaCode { get; set; }
        /// <summary>
        /// 房源ID
        /// </summary>
        public long RealtyId { get; set; }
        /// <summary>
        /// 返回结果错误信息
        /// </summary>
        public OutputMsg OutputMsgData { get; set; }
        /// <summary>
        /// 租房房源描述信息
        /// </summary>
        public RentRealtyIntroduce RentRealtyIntroduceData { get; set; }
        /// <summary>
        /// 二手房房源描述信息
        /// </summary>
        public SaleRealtyIntroduce SaleRealtyIntroduceData { get; set; }

    }
    /// <summary>
    /// 实体：返回结果错误信息
    /// </summary>
    public class OutputMsg
    {
        /// <summary>
        ///  返回结果状态
        /// </summary>
        public int ErrorCode;
        /// <summary>
        /// 错误消息
        /// </summary>
        public string ErrorMsg;
    }
    /// <summary>
    /// 实体：租房描述信息
    /// </summary>
    public class RentRealtyIntroduce
    {
        /// <summary>
        /// 房源所属经纪人ID
        /// </summary>
        public long CreatorUserId;
        /// <summary>
        /// 房源标题
        /// </summary>
        public string RealtyTitle;
        /// <summary>
        /// 标题审核状态  
        /// 1:待审核  2：审核通过  9:审核不通过
        /// </summary>
        public int? RealtyTitleAuditState;
        /// <summary>
        /// 标题描述审核拒绝原因
        /// </summary>
        public string RealtyTitleRefusalReason;
        /// <summary>
        /// 房源亮点
        /// </summary>
        public string RentPoint;
        /// <summary>
        /// 交通出行
        /// </summary>
        public string Transportation;
        /// <summary>
        /// 周边配套
        /// </summary>
        public string Surrounding;
        /// <summary>
        /// 小区介绍
        /// </summary>
        public string CommunityIntroduce;
        /// <summary>
        /// 户型介绍
        /// </summary>
        public string HouseType;
        /// <summary>
        /// 出租原因
        /// </summary>
        public string RentDetail;
        /// <summary>
        /// 装修描述
        /// </summary>
        public string DecorateIntroduce;
        /// <summary>
        /// 适宜人群
        /// </summary>
        public string SuitCrowd;
        /// <summary>
        /// 房描审核状态 
        /// 1:待审核  2：审核通过  9:审核不通过
        /// </summary>
        public int? IntroduceAuditState;
        /// <summary>
        /// 房描审核拒绝原因
        /// </summary>
        public string IntroduceRefusalReason;
    }

    /// <summary>
    /// 实体：二手房描述信息
    /// </summary>
    public class SaleRealtyIntroduce
    {
        /// <summary>
        /// 房源所属经纪人ID
        /// </summary>
        public long CreatorUserId;
        /// <summary>
        /// 房源标题
        /// </summary>
        public string RealtyTitle;
        /// <summary>
        /// 标题审核状态  
        /// 1:待审核  2：审核通过  9:审核不通过
        /// </summary>
        public int? RealtyTitleAuditState;
        /// <summary>
        /// 标题审核拒绝原因
        /// </summary>
        public string RealtyTitleRefusalReason;
        /// <summary>
        /// 核心卖点
        /// </summary>
        public string SalePoint;
        /// <summary>
        /// 交通出行
        /// </summary>
        public string Transportation;
        /// <summary>
        /// 周边配套
        /// </summary>
        public string Surrounding;
        /// <summary>
        /// 户型介绍
        /// </summary>
        public string HouseType;
        /// <summary>
        /// 小区介绍
        /// </summary>
        public string CommunityIntroduce;
        /// <summary>
        /// 适宜人群
        /// </summary>
        public string SuitCrowd;
        /// <summary>
        /// 税费解析
        /// </summary>
        public string TaxExpense;
        /// <summary>
        /// 售房详情
        /// </summary>
        public string SaleDetail;
        /// <summary>
        /// 装修描述
        /// </summary>
        public string DecorateIntroduce;
        /// <summary>
        /// 标题审核状态  
        /// 1:待审核  2：审核通过  9:审核不通过
        /// </summary>
        public int? IntroduceAuditState;
        /// <summary>
        /// 描述审核拒绝原因
        /// </summary>
        public string IntroduceRefusalReason;
    }

}