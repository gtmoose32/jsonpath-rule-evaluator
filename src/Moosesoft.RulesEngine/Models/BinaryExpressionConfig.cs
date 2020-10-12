namespace Moosesoft.RulesEngine.Models
{
    public class BinaryExpressionConfig
    {
        public string JsonPathExpression { get; set; }

        public Operator Operator { get; set; }

        public string Value { get; set; }
    }
}