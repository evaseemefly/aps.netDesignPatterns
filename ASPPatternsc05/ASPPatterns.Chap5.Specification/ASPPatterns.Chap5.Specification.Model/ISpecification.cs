using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace ASPPatterns.Chap5.Specification.Model
{
    public interface ISpecification<T>
    {
        /// <summary>
        /// 是满意的
        /// </summary>
        /// <param name="candidate">候选人</param>
        /// <returns></returns>
        bool IsSatisfiedBy(T candidate);
        
        ISpecification<T> And(ISpecification<T> other);        
        
        ISpecification<T> Not();
    }
}
