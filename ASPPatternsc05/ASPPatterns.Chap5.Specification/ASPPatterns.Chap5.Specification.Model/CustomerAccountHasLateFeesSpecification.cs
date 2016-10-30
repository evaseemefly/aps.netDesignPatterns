using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace ASPPatterns.Chap5.Specification.Model
{
    /// <summary>
    /// 确定客户账号是否有滞纳金
    /// </summary>
    public class CustomerAccountHasLateFeesSpecification : CompositeSpecification<CustomerAccount>  
    {
        public override bool IsSatisfiedBy(CustomerAccount candidate)
        {
            return candidate.LateFees > 0;
        }
    }
}
