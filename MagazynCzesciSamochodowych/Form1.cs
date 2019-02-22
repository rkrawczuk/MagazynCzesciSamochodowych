using System;
using System.Collections.Generic;
using System.Windows.Forms;


namespace MagazynCzesciSamochodowych
{
    public partial class Form1 : Form
    {
        List<Part> listOfParts = new List<Part>();
        private int editedElement;
        public Form1()
        {
            listOfParts.Add(new Part(123, "Radio", "BMW", "Seria 1", "200 zł", "Wnętrze"));
            listOfParts.Add(new Part(45, "Lusterko prawe", "Mazda", "MX5", "150 zł", "Inna"));
            listOfParts.Add(new Part(33, "Lampa lewa przednia", "Ford", "Focus", "450 zł", "Inna"));
            InitializeComponent();
            saveButton.Enabled = false;
            for (int i = 0; i < listOfParts.Count; i++)
                partList.Items.Add(listOfParts[i].Name);
        }

       
        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            string message = "Wszystkie dane muszą być uzupełnione";
            string caption = "Błąd!";
            string productName = productNameTextBox.Text;
            string partNumber = partNumberTextBox.Text;
            string carModel = carModelTextBox.Text;
            string carBrand = carBrandTextBox.Text;
            string productPrice = productPriceTextBox.Text;
            string kindOfPart = kindOfPartTextBox.Text;
            MessageBoxButtons messageBoxButtons = MessageBoxButtons.OK;
            bool isTrue = AddItem(productName, partNumber, carModel, carBrand, productPrice, kindOfPart);
            if(!isTrue)
                MessageBox.Show(message, caption, messageBoxButtons);

            productNameTextBox.Clear();
            productPriceTextBox.Clear();
            carBrandTextBox.Clear();
            carModelTextBox.Clear();
            partNumberTextBox.Clear();

        }

        public bool AddItem(string productName, string partNumber, string carModel, string carBrand, string productPrice, string kindOfPart)
        {
            if (productName.Length == 0 || partNumber.Length == 0
                            || carModel.Length == 0 || carBrand.Length == 0
                            || productPrice.Length == 0)
            {
                return false;
            }
            else
            {
                Part part = new Part(Convert.ToInt32(partNumber), productName,
                    carBrand, carModel, productPrice, kindOfPart);
                listOfParts.Add(part);
                partList.Items.Clear();
                for (int i = 0; i < listOfParts.Count; i++)
                    partList.Items.Add(listOfParts[i].Name);
                return true;
            }
        }

        private void deleteButton_Click(object sender, EventArgs e)
        {
            try
            {
                string ItemToRemove = partList.SelectedItem.ToString();
                for (int i = partList.Items.Count - 1; i >= 0; i--)
                {
                    if (partList.Items[i].ToString().Contains(ItemToRemove))
                    {
                        partList.Items.RemoveAt(i);
                      
                        for (int j = 0; j < listOfParts.Count; j++)
                        {
                            if (listOfParts[j].Name == ItemToRemove)
                                listOfParts.RemoveAt(j);
                        }
                    }
                }
            }catch(NullReferenceException ex)
            {
                string message = "Błąd usuwania, (nie zaznaczony element)";
                string caption = "Błąd!";
                MessageBoxButtons messageBoxButtons = MessageBoxButtons.OK;

                DialogResult result;
                result = MessageBox.Show(message, caption, messageBoxButtons);
            }
        }

        private void textBox3_TextChanged(object sender, EventArgs e)
        {

        }

        private void Form1_Load(object sender, EventArgs e)
        {
            kindOfPartTextBox.SelectedItem = null;
            kindOfPartTextBox.SelectedText = "Inna";
        }

        private void label6_Click(object sender, EventArgs e)
        {

        }

        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void editButton_Click(object sender, EventArgs e)
        {
            try
            {
                string toEditItem = partList.SelectedItem.ToString();
                EditItem(toEditItem);
            }
            catch (NullReferenceException ex)
            {
                string message = "Nie zaznaczono elementu.";
                string caption = "Błąd!";
                MessageBoxButtons messageBoxButtons = MessageBoxButtons.OK;

                DialogResult result;
                result = MessageBox.Show(message, caption, messageBoxButtons);
            }
        }

        public String EditItem(string toEditItem)
        {
            for (int i = 0; i < listOfParts.Count; i++)
            {
                if (listOfParts[i].Name == toEditItem)
                {
                    Part edited = listOfParts[i];
                    productNameTextBox.Text = edited.Name;
                    productPriceTextBox.Text = edited.Price;
                    carBrandTextBox.Text = edited.CarBrand;
                    carModelTextBox.Text = edited.CarModel;
                    partNumberTextBox.Text = edited.PartNumber.ToString();
                    kindOfPartTextBox.Text = edited.PartCategory;
                    editedElement = i;
                }
            }
            saveButton.Enabled = true;
            addButton.Enabled = false;
            deleteItem.Enabled = false;

            return "Edycja rozpoczęta pomyślnie";
        }

        private void saveButton_Click(object sender, EventArgs e)
        {
            listOfParts[editedElement].Name = productNameTextBox.Text;
            listOfParts[editedElement].Price = productPriceTextBox.Text;
            listOfParts[editedElement].CarBrand = carBrandTextBox.Text;
            listOfParts[editedElement].CarModel = carModelTextBox.Text;
            listOfParts[editedElement].PartNumber = Convert.ToInt32(partNumberTextBox.Text);
            listOfParts[editedElement].PartCategory = kindOfPartTextBox.Text;

            productNameTextBox.Clear();
            productPriceTextBox.Clear();
            carBrandTextBox.Clear();
            carModelTextBox.Clear();
            partNumberTextBox.Clear();

            saveButton.Enabled = false;
            addButton.Enabled = true;
            deleteItem.Enabled = true;
        }

        private void showButton_Click(object sender, EventArgs e)
        {
            try
            {
                string toShow = partList.SelectedItem.ToString();

                for (int i = 0; i < listOfParts.Count; i++)
                {
                    if (listOfParts[i].Name == toShow)
                    {
                        Form showForm = new showForm(listOfParts[i]);
                        showForm.Show();
                    }
                }
            }catch(NullReferenceException ex)
            {
                string message = "Brak wybranego elementu!";
                string caption = "Błąd!";
                MessageBoxButtons messageBoxButtons = MessageBoxButtons.OK;

                DialogResult result;
                result = MessageBox.Show(message, caption, messageBoxButtons);
            }
        }

        private void zamknijToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void onasToolStripMenuItem_Click(object sender, EventArgs e)
        {
            string message = "Autor\nWesja : 1.0.0";
            string caption = "O nas";
            MessageBoxButtons messageBoxButtons = MessageBoxButtons.OK;

            DialogResult result;
            result = MessageBox.Show(message, caption, messageBoxButtons);
        }
    }
}
