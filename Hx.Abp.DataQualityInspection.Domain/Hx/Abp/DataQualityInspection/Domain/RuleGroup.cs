﻿using Volo.Abp.Domain.Entities.Auditing;

namespace Hx.Abp.DataQualityInspection.Domain
{
    /// <summary>
    /// 规则组
    /// </summary>
    public class RuleGroup : FullAuditedEntity<Guid>
    {
        /// <summary>
        /// 分组标题
        /// </summary>
        public string Title { get; protected set; }
        /// <summary>
        /// 路径枚举
        /// </summary>
        public string Code { get; protected set; }
        /// <summary>
        /// 分组排序
        /// </summary>
        public double Order { get; protected set; }
        /// <summary>
        /// 父Id
        /// </summary>
        public Guid? ParentId { get; protected set; }
        /// <summary>
        /// 分组描述
        /// </summary>
        public string? Description { get; protected set; }
        /// <summary>
        /// 子组
        /// </summary>
        public List<RuleGroup> Children { get; protected set; }
        /// <summary>
        /// 一组规则
        /// </summary>
        public List<Rule> Rules { get; protected set; }
        public RuleGroup() { }
        /// <summary>
        /// 初始化
        /// </summary>
        /// <param name="id">主键Id</param>
        /// <param name="title">分组标题</param>
        /// <param name="code">路径枚举</param>
        /// <param name="order">分组排序</param>
        /// <param name="description">分组描述</param>
        public RuleGroup(Guid id, string title, string code, double order, string? description = null)
        {
            Id = id;
            Title = title;
            Code = code;
            Order = order;
            Description = description;
            Children = new List<RuleGroup>();
            Rules = new List<Rule>();
        }
        /// <summary>
        /// Calculates next code for given code.
        /// Example: if code = "00019.00055.00001" returns "00019.00055.00002".
        /// </summary>
        /// <param name="code">The code.</param>
        public static string CalculateNextCode(string code)
        {
            if (code.IsNullOrEmpty())
            {
                throw new ArgumentNullException(nameof(code), "code can not be null or empty.");
            }

            var parentCode = GetParentCode(code);
            var lastUnitCode = GetLastUnitCode(code);
            return AppendCode(parentCode, CreateCode(Convert.ToInt32(lastUnitCode) + 1));
        }
        /// <summary>
        /// Gets the last unit code.
        /// Example: if code = "00019.00055.00001" returns "00001".
        /// </summary>
        /// <param name="code">The code.</param>
        public static string GetLastUnitCode(string code)
        {
            if (code.IsNullOrEmpty())
            {
                throw new ArgumentNullException(nameof(code), "code can not be null or empty.");
            }

            var splittedCode = code.Split('.');
            return splittedCode[splittedCode.Length - 1];
        }

        /// <summary>
        /// Gets parent code.
        /// Example: if code = "00019.00055.00001" returns "00019.00055".
        /// </summary>
        /// <param name="code">The code.</param>
        public static string? GetParentCode(string code)
        {
            if (code.IsNullOrEmpty())
            {
                throw new ArgumentNullException(nameof(code), "code can not be null or empty.");
            }

            var splittedCode = code.Split('.');
            if (splittedCode.Length == 1)
            {
                return null;
            }

            return splittedCode.Take(splittedCode.Length - 1).JoinAsString(".");
        }

        /// <summary>
        /// Creates code for given numbers.
        /// Example: if numbers are 4,2 then returns "00004.00002";
        /// </summary>
        /// <param name="numbers">Numbers</param>
        public static string? CreateCode(params int[] numbers)
        {
            if (numbers.IsNullOrEmpty())
            {
                return null;
            }

            return numbers.Select(number => number.ToString(new string('0', 5))).JoinAsString(".");
        }

        /// <summary>
        /// Appends a child code to a parent code.
        /// Example: if parentCode = "00001", childCode = "00042" then returns "00001.00042".
        /// </summary>
        /// <param name="parentCode">Parent code. Can be null or empty if parent is a root.</param>
        /// <param name="childCode">Child code.</param>
        public static string AppendCode(string parentCode, string childCode)
        {
            if (childCode.IsNullOrEmpty())
            {
                throw new ArgumentNullException(nameof(childCode), "childCode can not be null or empty.");
            }

            if (parentCode.IsNullOrEmpty())
            {
                return childCode;
            }

            return parentCode + "." + childCode;
        }
    }
}