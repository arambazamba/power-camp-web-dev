﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Vouchers
{
    public class BalanceService
    {
        private VouchersDbContext ctx;
        public BalanceService(VouchersDbContext context)
        {
            ctx = context;
        }

        public string GetSumTotal(bool expense)
        {
            string result = expense ? "Total Expenses: " : "Total Income: ";
            var accts = ctx.BalanceAccounts.Where(f => f.Expense == expense).Select(f => f.ID).ToList();
            var vds = ctx.VoucherDetails.Where(f => f.Account != null && accts.Contains(f.AccountID)).Sum(f=>f.Amount);
            return result + vds;
        }
    }
}
