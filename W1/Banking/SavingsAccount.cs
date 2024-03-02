namespace Banking
{
    class SavingsAccount : Account // the ":" means that we're inheriting or Extending the Account class.
    {
        // Fields
        private double interestRate;
        // Constructor
        public SavingsAccount(string owner, double initialBalance, double interestRate = .01) : base(owner,initialBalance)
        {
            this.interestRate = interestRate;
        }
        // Methods
        public override string DisplayBalance()
        {
            // return ("From SavingsAccount : " + this.balance);
            return ("From SavingAccount: "+ base.DisplayBalance());
        }
    }
}