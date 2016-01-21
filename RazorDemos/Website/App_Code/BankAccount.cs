using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

/// <summary>
/// Summary description for BankAccount
/// </summary>
public class BankAccount
{
    public string AccountHolder { get; set; }
    public string AccountNumber { get; set; }
    public decimal OpeningBalance { get; set; }
    public decimal OverdraftLimit { get; set; }
    public AccountType AccountType { get; set; }
}

public enum AccountType { Chequing, Savings, Credit }
