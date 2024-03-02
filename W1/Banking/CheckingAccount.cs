namespace Banking
{
    class CheckingAccount : Account
    {
        // Fields
        protected double CheckingAccountBalance;
        // Constructor
        public CheckingAccount(string owner,double initialBalance) : base(owner,initialBalance)
        {

        }
        // Methods
        public void MakeDeposit(double amount)
        {
            
        }
    }
}