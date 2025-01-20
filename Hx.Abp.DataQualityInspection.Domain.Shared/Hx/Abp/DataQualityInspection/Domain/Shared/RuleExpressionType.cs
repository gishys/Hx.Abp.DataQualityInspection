using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Hx.Abp.DataQualityInspection.Domain.Shared
{
    public enum RuleExpressionType
    {
        /// <summary>
        /// Lambda表达式
        /// </summary>
        LambdaExpression,
        /// <summary>
        /// 从数据库中查询数据并验证
        /// </summary>
        SQLExpression,
        /// <summary>
        /// 执行复杂的脚本逻辑
        /// </summary>
        ScriptExpression,
        /// <summary>
        /// 动态生成规则
        /// </summary>
        ExpressionTree,
        /// <summary>
        /// 分组及其他不进行验证规则使用
        /// </summary>
        NullExpression = 9
    }
}
