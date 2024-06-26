﻿using System;

namespace SeckillPro.Com.Model.ApiModel
{
    #region 抢购请求

    public class MoQiangGouRq : MoRq
    {
        /// <summary>
        /// 商品编号
        /// </summary>
        public long ShoppingId { get; set; }

        /// <summary>
        /// 商品数量 默认1件，根据后台设置
        /// </summary>
        public int Num { get; set; } = 1;
    }

    #endregion 抢购请求

    #region 抢购订单响应

    public class MoQiangGouRp : MoRp
    {
        /// <summary>
        /// 订单号
        /// </summary>
        public long OrderId { get; set; }

        /// <summary>
        /// 订单状态 1:正在排队抢购 2：抢购成功 3：抢购失败  EnumHelper.EmOrderStatus
        /// </summary>
        public int OrderStatus { get; set; }

        /// <summary>
        /// 支付超时时间  默认下单后30分钟
        /// </summary>
        public DateTime PayOutTime { get; set; }

        /// <summary>
        /// 抢购订单时间
        /// </summary>
        public DateTime CreatTime { get; set; }
    }

    #endregion 抢购订单响应
}