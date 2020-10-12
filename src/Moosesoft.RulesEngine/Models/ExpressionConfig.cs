using System.Collections.Generic;

namespace Moosesoft.RulesEngine.Models
{
    public class ExpressionConfig
    {
        public LogicalOperator LeadingLogicalOperator { get; set; }

        public BinaryExpressionConfig BinaryExpressionConfig { get; set; }

        public List<ExpressionConfig> Configurations { get; } = new List<ExpressionConfig>();
    }
}
