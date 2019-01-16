using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Encompass.Data;
using Encompass.Models;

namespace EncompassPC
{
    public partial class EncompassForm : Form
    {
        private SerialMessenger serialMessenger;
        private Timer readMessageTimer;
        public EncompassForm()
        {
            InitializeComponent();

            MessageBuilder messageBuilder = new MessageBuilder('#', '%');
            serialMessenger = new SerialMessenger("COM3", 9600, messageBuilder);

            readMessageTimer = new Timer();
            readMessageTimer.Interval = 10;
            readMessageTimer.Tick += new EventHandler(ReadMessageTimer_Tick);
        }

        private void ReadMessageTimer_Tick(object sender, EventArgs e)
        {
            string[] messages = serialMessenger.ReadMessages();

            if (messages != null)
            {
                foreach (string message in messages)
                {
                    ProcessReceivedMessage(message);
                }
            }
        }

        private void ProcessReceivedMessage(string message)
        {
            if (message == "WAITING_FOR_PASS")
            {
                MessageBox.Show("Currently waiting for pass");
            }

            if (message.StartsWith("UPDATE_BALANCE:"))
            {
                string[] values = getParamValue(message);
                Service service = new Service();

                int cardId = Convert.ToInt32(values[0]);
                int userId = Convert.ToInt32(values[1]);
                decimal amountChange = Convert.ToDecimal(values[2], new CultureInfo("en-US"));

                Balance balance = service
                    .GetUserCards(userId)
                    .FirstOrDefault(b => b.CardId == cardId);

                if (balance == null)
                {
                    serialMessenger.SendMessage($"TRANSACTION_COMPLETED: FALSE");
                    MessageBox.Show($"User ID {userId} or Card ID {cardId} not found");
                    return;
                }

                decimal newAmount = CalculateAmount(balance, amountChange);

                if (newAmount >= 0)
                {

                    bool transactionCompleted = service.UpdateBalanceAmount(cardId, userId, newAmount);

                    serialMessenger.SendMessage($"TRANSACTION_COMPLETED: {transactionCompleted.ToString()}");
                    MessageBox.Show($"TRANSACTION_COMPLETED: {transactionCompleted.ToString()}");
                }
            }
        }

        private string[] getParamValue(string message)
        {
            int colonIndex = message.IndexOf(':');
            if (colonIndex != -1)
            {
                if (message.IndexOf(',') != -1)
                {
                    string param = message.Substring(colonIndex + 1);
                    string[] values = param.Split(',');
                    return values;
                }
            }
            return null;
          
        }

        private decimal CalculateAmount(Balance balance, decimal amountChange)
        {
            decimal newAmount = balance.Amount - amountChange;

            return newAmount;
        }


        private void Connect()
        {
            try
            {
                serialMessenger.Connect();
                readMessageTimer.Enabled = true;
            }
            catch (Exception exception)
            {
                MessageBox.Show(exception.Message);
            }
        }
        private void Disconnect()
        {
            try
            {
                readMessageTimer.Enabled = false;
                serialMessenger.Disconnect();
            }
            catch (Exception exception)
            {
                MessageBox.Show(exception.Message);
            }
        }

        private void EncompassForm_FormClosed(object sender, FormClosedEventArgs e)
        {
            Disconnect();
        }

        private void btnConnect_Click(object sender, EventArgs e)
        {
            Connect();
        }

        private void btnDisconnect_Click(object sender, EventArgs e)
        {
            Disconnect();
        }
    }
}
