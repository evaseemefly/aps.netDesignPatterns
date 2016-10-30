using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace ASPPatterns.Chap5.Specification.Model
{
    /// <summary>
    /// 规范客户账户是否受到限制
    /// </summary>
    public class CustomerAccountStillActiveSpecification : CompositeSpecification<CustomerAccount>  
    {
        public override bool IsSatisfiedBy(CustomerAccount candidate)
        {
            return candidate.AccountActive;
        }
    }
}
