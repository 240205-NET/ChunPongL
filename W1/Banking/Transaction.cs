namespace Banking
{
    class Transaction
    {
        // Fields
        public double amount;
        public string note;
        //DataTime from System library which give us day and time
        public DateTime date;
        public int transactionId;
        private static int transactionIdSeed = 1000;

        // Consturctor
        public Transaction(double amount, DateTime date, string note = "")
        {
            this.amount = amount;
            this.date = date;
            this.note = note;
            this.transactionId = transactionIdSeed;
            transactionIdSeed++;
        }

        // Methods
    }
}