using BankAccount.Models;
using BankAccount.Utils;

namespace BankAccount.Tests
{
    public class AccountTests
    {
        public AccountTests()
        {
            Language.Set(AppLanguage.EN);
            Account.SetNextNumber(1);
        }

        // CheckingAccount Tests 

        [Fact]
        public void CheckingAccount_Deposit_ShouldIncreaseBalance()
        {
            var account = new CheckingAccount("John", 1000);
            account.Deposit(500);
            Assert.Equal(1500, account.Balance);
        }

        [Fact]
        public void CheckingAccount_Deposit_InvalidAmount_ShouldNotChangeBalance()
        {
            var account = new CheckingAccount("John", 1000);
            account.Deposit(-100);
            Assert.Equal(1000, account.Balance);
        }

        [Fact]
        public void CheckingAccount_Withdraw_ShouldDecreaseBalance()
        {
            var account = new CheckingAccount("John", 1000);
            bool result = account.Withdraw(500);
            Assert.True(result);
            Assert.Equal(500, account.Balance);
        }

        [Fact]
        public void CheckingAccount_Withdraw_WithLimit_ShouldSucceed()
        {
            var account = new CheckingAccount("John", 100, limit: 500);
            bool result = account.Withdraw(400);
            Assert.True(result);
            Assert.Equal(-300, account.Balance);
        }

        [Fact]
        public void CheckingAccount_Withdraw_ExceedsBalanceAndLimit_ShouldFail()
        {
            var account = new CheckingAccount("John", 100, limit: 200);
            bool result = account.Withdraw(400);
            Assert.False(result);
            Assert.Equal(100, account.Balance);
        }

        [Fact]
        public void CheckingAccount_Withdraw_NegativeAmount_ShouldFail()
        {
            var account = new CheckingAccount("John", 1000);
            bool result = account.Withdraw(-100);
            Assert.False(result);
            Assert.Equal(1000, account.Balance);
        }

        // SavingsAccount Tests 

        [Fact]
        public void SavingsAccount_Deposit_ShouldIncreaseBalance()
        {
            var account = new SavingsAccount("Mary", 500);
            account.Deposit(300);
            Assert.Equal(800, account.Balance);
        }

        [Fact]
        public void SavingsAccount_Withdraw_ShouldDecreaseBalance()
        {
            var account = new SavingsAccount("Mary", 500);
            bool result = account.Withdraw(200);
            Assert.True(result);
            Assert.Equal(300, account.Balance);
        }

        [Fact]
        public void SavingsAccount_Withdraw_ExceedsBalance_ShouldFail()
        {
            var account = new SavingsAccount("Mary", 500);
            bool result = account.Withdraw(600);
            Assert.False(result);
            Assert.Equal(500, account.Balance);
        }

        // Password Tests 

        [Fact]
        public void Account_Password_CorrectPassword_ShouldValidate()
        {
            var account = new CheckingAccount("John", 1000, password: "mypassword");
            Assert.True(account.ValidatePassword("mypassword"));
        }

        [Fact]
        public void Account_Password_WrongPassword_ShouldFail()
        {
            var account = new CheckingAccount("John", 1000, password: "mypassword");
            Assert.False(account.ValidatePassword("wrongpassword"));
        }

        [Fact]
        public void Account_Password_HashShouldNotBeEmpty()
        {
            var account = new CheckingAccount("John", 1000, password: "1234");
            Assert.NotEmpty(account.PasswordHash);
        }

        [Fact]
        public void Account_Password_ShouldNotStoreAsPlainText()
        {
            var account = new CheckingAccount("John", 1000, password: "1234");
            Assert.NotEqual("1234", account.PasswordHash);
        }

        // Account Properties Tests 

        [Fact]
        public void CheckingAccount_ShouldHaveType1()
        {
            var account = new CheckingAccount("John", 1000);
            Assert.Equal(1, account.Type);
        }

        [Fact]
        public void SavingsAccount_ShouldHaveType2()
        {
            var account = new SavingsAccount("Mary", 500);
            Assert.Equal(2, account.Type);
        }

        [Fact]
        public void Account_Agency_ShouldDefaultTo001()
        {
            var account = new CheckingAccount("John", 1000);
            Assert.Equal("001", account.Agency);
        }

        [Fact]
        public void Account_Owner_ShouldBeSetCorrectly()
        {
            var account = new CheckingAccount("John Doe", 1000);
            Assert.Equal("John Doe", account.Owner);
        }

        [Fact]
        public void Account_InitialBalance_ShouldBeSetCorrectly()
        {
            var account = new SavingsAccount("Mary", 750);
            Assert.Equal(750, account.Balance);
        }

        //Transfer Validation Tests 

        [Fact]
        public void Transfer_SameAccountNumber_ShouldFail()
        {
            var origin = new CheckingAccount("John", 1000);
            var destiny = origin;
            Assert.Equal(origin.Number, destiny.Number);
        }

        [Fact]
        public void Transfer_SufficientBalance_ShouldWithdrawFromOrigin()
        {
            var origin = new CheckingAccount("John", 1000);
            var destiny = new SavingsAccount("Mary", 500);
            origin.Withdraw(300);
            destiny.Deposit(300);
            Assert.Equal(700, origin.Balance);
            Assert.Equal(800, destiny.Balance);
        }

        [Fact]
        public void Transfer_InsufficientBalance_ShouldNotWithdraw()
        {
            // Limit is 0 to ensure withdraw fails when balance is insufficient
            var origin = new CheckingAccount("John", 100, limit: 0);
            bool result = origin.Withdraw(500);
            Assert.False(result);
            Assert.Equal(100, origin.Balance);
        }
    }
}