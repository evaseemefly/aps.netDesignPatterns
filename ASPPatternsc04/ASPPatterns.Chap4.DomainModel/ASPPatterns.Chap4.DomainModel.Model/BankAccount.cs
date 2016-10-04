using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace ASPPatterns.Chap4.DomainModel.Model
{
    public class BankAccount
    {
        private decimal _balance;
        private Guid _accountNo;
        private string _customerRef;

        /// <summary>
        /// 交易（汇报）
        /// </summary>
        private IList<Transaction> _transactions;

        public BankAccount() : this(Guid.NewGuid(), 0, new List<Transaction>(), "")
        {
            _transactions.Add(new Transaction(0m, 0m, "account created", DateTime.Now));
        }

        public BankAccount(Guid Id, decimal balance, IList<Transaction> transactions, string customerRef)
        {
            AccountNo = Id;
            _balance = balance;
            _transactions = transactions;
            _customerRef = customerRef;
        }

        /// <summary>
        /// 账户
        /// </summary>
        public Guid AccountNo
        {
            get { return _accountNo; }
            internal set { _accountNo = value; }
        }
            
        /// <summary>
        /// 余额
        /// </summary>
        public decimal Balance
        {
            get { return _balance; }
            internal set { _balance = value; } 
        }

        /// <summary>
        /// 客户编号
        /// </summary>
        public string CustomerRef
        {
            get { return _customerRef; }
            set { _customerRef = value; }
        }

        /// <summary>
        /// 可以取钱
        /// </summary>
        /// <param name="amount"></param>
        /// <returns></returns>
        public bool CanWithdraw(decimal amount)
        {
            return (Balance >= amount);
        }

        /// <summary>
        /// 取钱
        /// </summary>
        /// <param name="amount"></param>
        /// <param name="reference"></param>
        public void Withdraw(decimal amount, string reference)
        {
            if (CanWithdraw(amount))
            {
                Balance -= amount;
                _transactions.Add(new Transaction(0m, amount, reference, DateTime.Now));
            }
            else 
            {
                throw new InsufficientFundsException(); 
            }    
        }        

        /// <summary>
        /// 存钱
        /// </summary>
        /// <param name="amount"></param>
        /// <param name="reference"></param>
        public void Deposit(decimal amount, string reference)
        {
            Balance += amount;
            _transactions.Add(new Transaction(amount, 0m, reference, DateTime.Now));
        }

        public IEnumerable<Transaction> GetTransactions()
        {
            return _transactions;
        }
    }   
}
