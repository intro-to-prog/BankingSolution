using BankingDomain;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace BankKiosk
{
    public partial class Form1 : Form
    {
        private readonly BankAccount _account;
        public Form1()
        {
            InitializeComponent();
            _account = new BankAccount(
                new SuperBonusCalculator(),
                new WindowsNarc()
                );

            Text = _account.GetBalance().ToString("c");
        }

        private void btnWithdraw_Click(object sender, EventArgs e)
        {
            decimal amount = decimal.Parse(txtAmount.Text);
            _account.Withdraw(amount);
            Text = _account.GetBalance().ToString("c");
        }

        private void btnDeposit_Click(object sender, EventArgs e)
        {
            decimal amount = decimal.Parse(txtAmount.Text);
            _account.Deposit(amount);
            Text = _account.GetBalance().ToString("c");
        }
    }

    public class WindowsNarc : INarcOnWithdrawals
    {
        public void TellTheMan(BankAccount bankAccount, decimal amountToWithdraw)
        {
            MessageBox.Show($"You are withdrawing ${amountToWithdraw:c}.", "Narcing on you!");
        }
    }
}
