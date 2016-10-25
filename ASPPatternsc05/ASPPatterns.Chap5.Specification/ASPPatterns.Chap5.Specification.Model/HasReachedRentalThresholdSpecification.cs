using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace ASPPatterns.Chap5.Specification.Model
{
    /// <summary>
    /// 确定客户账号能否租借DVD
    /// </summary>
    public class HasReachedRentalThresholdSpecification : CompositeSpecification<CustomerAccount> 
    {
        public override bool IsSatisfiedBy(CustomerAccount candidate)
        {       
            return candidate.NumberOfRentalsThisMonth >= 5;        
        }
    }
}
