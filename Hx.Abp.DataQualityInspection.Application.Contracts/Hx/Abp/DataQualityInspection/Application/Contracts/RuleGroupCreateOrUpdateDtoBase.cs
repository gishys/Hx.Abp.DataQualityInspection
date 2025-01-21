﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Hx.Abp.DataQualityInspection.Application.Contracts
{
    public class RuleGroupCreateOrUpdateDtoBase
    {
        /// <summary>
        /// 分组标题
        /// </summary>
        public required string Title { get; set; }
        /// <summary>
        /// 分组描述
        /// </summary>
        public string? Description { get; set; }
        /// <summary>
        /// 分组排序
        /// </summary>
        public int? Order { get; protected set; }
        /// <summary>
        /// 父Id
        /// </summary>
        public Guid? ParentId { get; protected set; }
    }
}
