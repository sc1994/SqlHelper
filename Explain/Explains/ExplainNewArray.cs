﻿using System.Linq.Expressions;
using System.Text;

namespace Explain
{
    /// <summary>
    /// 数组
    ///  1.表达式中直接 new[]{ x=>x.Name }
    /// </summary>
    public class ExplainNewArray : BaseExplain<NewArrayExpression>
    {
        public override void Explain(NewArrayExpression exp, StringBuilder info)
        {
            foreach (var item in exp.Expressions) // 循环解析表达式
            {
                ExplainTool.Explain(item, info);
            }
        }
    }
}
