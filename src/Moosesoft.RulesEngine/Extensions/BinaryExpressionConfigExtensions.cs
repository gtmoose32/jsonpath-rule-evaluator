using Moosesoft.RulesEngine.Models;
using Newtonsoft.Json.Linq;
using System;
using System.Linq.Expressions;

namespace Moosesoft.RulesEngine.Extensions
{
    public static class BinaryExpressionConfigExtensions
    {
        public static BinaryExpression ToBinaryExpression(this BinaryExpressionConfig config, JObject json)
        {
            var leftOperand = json.GetObjectAtPath(config.JsonPathExpression);
		
            Expression left;
            Expression right;
            if (leftOperand == null)
            {
                left = Expression.Constant(true);
                right = Expression.Constant(config.Value == "null");
            }
            else
            {
                var rightOperand = config.Value.ToType(leftOperand.GetType());

                left = Expression.Constant(leftOperand);
                right = Expression.Constant(rightOperand);
            }

            BinaryExpression expression = null;
            switch (config.Operator)
            {
                case Operator.NotEqual:
                    expression = Expression.NotEqual(left, right);
                    break;
                case Operator.Equal:
                    expression = Expression.Equal(left, right);
                    break;
                case Operator.GreaterThan:
                    expression = Expression.GreaterThan(left, right);
                    break;
                case Operator.GreaterThanOrEqual:
                    expression = Expression.GreaterThanOrEqual(left, right);
                    break;
                case Operator.LessThan:
                    expression = Expression.LessThan(left, right);
                    break;
                case Operator.LessThanOrEqual:
                    expression = Expression.LessThanOrEqual(left, right);
                    break;
                default:
                    throw new NotSupportedException($"The operation '{config.Operator}' is not currently supported.");
            }
		
            return expression;
        }        
    }
}