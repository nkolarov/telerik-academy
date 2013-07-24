namespace ATM.Data.Migrations
{
    using ATM.Model;
    using System;
    using System.Data.Entity;
    using System.Data.Entity.Migrations;
    using System.Linq;

    public sealed class Configuration : DbMigrationsConfiguration<ATM.Data.ATMContext>
    {
        public Configuration()
        {
            this.AutomaticMigrationsEnabled = true;
            this.AutomaticMigrationDataLossAllowed = true;
        }

        protected override void Seed(ATM.Data.ATMContext context)
        {
            context.CardAccounts.AddOrUpdate(
                ca => ca.CardNumber,
                    new CardAccount { CardCash = 100m, CardNumber = "0001", CardPIN = "1111"},
                    new CardAccount { CardCash = 200m, CardNumber = "0002", CardPIN = "2222"},
                    new CardAccount { CardCash = 300m, CardNumber = "0003", CardPIN = "3333"},
                    new CardAccount { CardCash = 400m, CardNumber = "0004", CardPIN = "4444"},
                    new CardAccount { CardCash = 500m, CardNumber = "0005", CardPIN = "5555"},
                    new CardAccount { CardCash = 600m, CardNumber = "0006", CardPIN = "6666"},
                    new CardAccount { CardCash = 700m, CardNumber = "0007", CardPIN = "7777"}
                );
        }
    }
}
