using Moosesoft.RulesEngine.Models;
using System.Collections.Generic;

namespace Moosesoft.RulesEngine
{
    public interface IRulesEngine
    {
        bool EvaluateRules(string json, IEnumerable<ExpressionConfig> configurations);
    }
}