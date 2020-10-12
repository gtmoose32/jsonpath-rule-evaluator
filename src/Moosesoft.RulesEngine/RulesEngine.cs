using Moosesoft.RulesEngine.Extensions;
using Moosesoft.RulesEngine.Models;
using Newtonsoft.Json.Linq;
using System;
using System.Collections.Generic;
using System.Linq.Expressions;

namespace Moosesoft.RulesEngine
{
    public class RulesEngine : IRulesEngine
    {
        public bool EvaluateRules(string json, IEnumerable<ExpressionConfig> configurations)
        {
            if (string.IsNullOrWhiteSpace(json)) 
                throw new ArgumentException("Cannot be null, empty or whitespace.", nameof(json));

            var jobject = JObject.Parse(json);
            var expression = BuildExpressionTree(jobject, configurations);
            //null expression returned so assume no rules to evaluate and return true
            if (expression == null) return true; 

            var lambda = Expression.Lambda<Func<bool>>(expression);
            var evaluate = lambda.Compile();

            return evaluate();
        }

        private static Expression BuildExpressionTree(JObject json, IEnumerable<ExpressionConfig> configurations)
        {
            if (configurations == null) return null;

            Expression current = null;
            foreach (var config in configurations)
            {
                var right = config.BinaryExpressionConfig != null
                    ? config.BinaryExpressionConfig.ToBinaryExpression(json)
                    : BuildExpressionTree(json, config.Configurations);

                current = current == null
                    ? right
                    : config.LeadingLogicalOperator == LogicalOperator.And
                        ? Expression.AndAlso(current, right)
                        : Expression.OrElse(current, right);
            }

            return current;
        }
    }
}