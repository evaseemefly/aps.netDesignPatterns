﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace ASPPatterns.Chap5.Specification.Model
{
    public class HasReachedRentalThresholdSpecification : CompositeSpecification<CustomerAccount> 
    {
        public override bool IsSatisfiedBy(CustomerAccount candidate)
        {       
            return candidate.NumberOfRentalsThisMonth >= 5;        
        }
    }
}
