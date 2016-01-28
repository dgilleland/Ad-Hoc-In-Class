using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

public class BankAccountController
{
    private  string DatabaseName { get; set; }
    public BankAccountController(string databaseName)
    {
        DatabaseName = databaseName;
    }

    public IEnumerable<dynamic> ListAllBankAccounts()
    {
        using (var db = WebMatrix.Data.Database.Open(DatabaseName))
        {
            string sql = "SELECT AccountNumber, AccountHolder, OpeningBalance, OverdraftLimit, AccountType FROM BankAccounts";
            return db.Query(sql);
        }
    }

    public dynamic GetBankAccount(string accountNumber)
    {
        using (var db = WebMatrix.Data.Database.Open(DatabaseName))
        {
            string sql = "SELECT AccountNumber, AccountHolder, OpeningBalance, OverdraftLimit, AccountType FROM BankAccounts WHERE AccountNumber = @0";
            return db.QuerySingle(sql, accountNumber);
        }
    }

    public void AddBankAccount(BankAccount account)
    {
        using (var db = WebMatrix.Data.Database.Open(DatabaseName))
        {
            string sql = "INSERT INTO BankAccounts(AccountNumber, AccountHolder, OpeningBalance, OverdraftLimit, AccountType)"
                       + " VALUES (@0, @1, @2, @3, @4)";
            db.Execute(sql, 
                       account.AccountNumber, 
                       account.AccountHolder, 
                       account.OpeningBalance, 
                       account.OverdraftLimit, 
                       account.AccountType.ToString());
        }
    }

    public void UpdateBankAccount(BankAccount account)
    {
        using (var db = WebMatrix.Data.Database.Open(DatabaseName))
        {
            string sql = "UPDATE BankAccounts SET AccountHolder = @1, OpeningBalance = @2, OverdraftLimit = @3, AccountType = @4 WHERE AccountNumber = @0";
            db.Execute(sql,
                       account.AccountNumber,
                       account.AccountHolder,
                       account.OpeningBalance,
                       account.OverdraftLimit,
                       account.AccountType.ToString());
        }
    }

    public void PurgeBankAccounts()
    {
        using (var db = WebMatrix.Data.Database.Open(DatabaseName))
        {
            db.Execute("DELETE FROM BankAccounts");
        }
    }


}