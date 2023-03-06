using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Dictionary_method
{
    public partial class Form1 : Form
    {
        private Dictionary<string, double> participants = new Dictionary<string, double>();

        public Form1()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {

        }

        private void addParticipantButton_Click(object sender, EventArgs e)
        {
            string nameToAdd = nameTextBox.Text;
            double amountToAdd;
            if (double.TryParse(amountTextBox.Text, out amountToAdd))
            {
                participants.Add(nameToAdd, amountToAdd);
                UpdateParticipantsList();
                UpdateTotalContribution();
                nameTextBox.Clear();
                amountTextBox.Clear();
            }
            else
            {
                MessageBox.Show("L'importo deve essere un numero valido.");
            }
        }

        private void removeParticipantButton_Click(object sender, EventArgs e)
        {
            string nameToRemove = participantsListBox.SelectedItem?.ToString();
            if (nameToRemove != null && participants.ContainsKey(nameToRemove))
            {
                participants.Remove(nameToRemove);
                UpdateParticipantsList();
                UpdateTotalContribution();
            }
            else
            {
                MessageBox.Show("Seleziona un partecipante dalla lista.");
            }
        }

        private void modifyContributionButton_Click(object sender, EventArgs e)
        {
            string nameToModify = participantsListBox.SelectedItem?.ToString();
            double newContribution;
            if (nameToModify != null && participants.ContainsKey(nameToModify) &&
                double.TryParse(newAmountTextBox.Text, out newContribution))
            {
                participants[nameToModify] = newContribution;
                UpdateParticipantsList();
                UpdateTotalContribution();
            }
            else
            {
                MessageBox.Show("Seleziona un partecipante dalla lista e inserisci un importo valido.");
            }
        }

        private void UpdateParticipantsList()
        {
            participantsListBox.Items.Clear();
            foreach (string name in participants.Keys)
            {
                participantsListBox.Items.Add($"{name} - {participants[name]}");
            }
        }

        private void UpdateTotalContribution()
        {
            double total = 0;
            foreach (double contribution in participants.Values)
            {
                total += contribution;
            }
            totalContributionLabel.Text = $"Totale: {total}";
        }
    }
}

