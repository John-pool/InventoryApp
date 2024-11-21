using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace InventoryApp
{
    public partial class Form1 : Form
    {
        private BindingSource showProductList = new BindingSource();
        public Form1()
        {
            InitializeComponent();
            showProductList = new BindingSource();
        }       

        private void Form1_Load(object sender, EventArgs e)
        {
            string[] categories = 
            {
                "Beverages",
                "Bread/Bakery",
                "Canned/Jarred Goods",
                "Dairy",
                "Frozen Goods", 
                "Meat",
                "Personal Care",
                "Other"
            };


            foreach (string category in categories)
            {
                cbCategory.Items.Add(category);
            }
        }
        private void btnAddProduct_Click(object sender, EventArgs e)
        {
            try
            {
                // Validate inputs and assign to variables
                string productName = Product_Name(txtProductName.Text);
                string category = cbCategory.Text;
                string mfgDate = dtPickerMfgDate.Value.ToString("yyyy-MM-dd");
                string expDate = dtPickerExpDate.Value.ToString("yyyy-MM-dd");
                string description = richTxtDescription.Text;
                int quantity = Quantity(txtQuantity.Text);
                double sellingPrice = SellingPrice(txtSellPrice.Text);

                
                showProductList.Add(new ProductClass(productName, category, mfgDate, expDate, sellingPrice, quantity, description));
                dataGridView1.DataSource = null;
                dataGridView1.DataSource = showProductList;

                MessageBox.Show("Product added successfully!");
            }
            catch (NumberFormatException ex)
            {
                MessageBox.Show($"Input Error: {ex.Message}");
            }
            catch (CurrencyFormatException ex)
            {
                MessageBox.Show($"Input Error: {ex.Message}");
            }
            catch (StringFormatException ex)
            {
                MessageBox.Show($"Input Error: {ex.Message}");
            }
        }
        private int Quantity(string quantity)
        {
            if (!int.TryParse(quantity, out int result) || result <= 0)
                throw new NumberFormatException("Quantity must be a positive integer.");
            return result;
        }

        private double SellingPrice(string price)
        {
            if (!double.TryParse(price, out double result) || result <= 0)
                throw new CurrencyFormatException("Price must be a positive number.");
            return result;
        }

        private string Product_Name(string name)
        {
            if (string.IsNullOrWhiteSpace(name))
                throw new StringFormatException("Product Name cannot be empty.");
            return name;
        }

        public class ProductClass
        {
            private int _Quantity;
            private double _SellingPrice;
            private string _ProductName;
            private string _Category;
            private string _ManufacturingDate;
            private string _ExpirationDate;
            private string _Description;

            public ProductClass(string productName, string category, string mfgDate, string expDate,
                       double sellingPrice, int quantity, string description)
            {
                _ProductName = productName;
                _Category = category;
                _ManufacturingDate = mfgDate;
                _ExpirationDate = expDate;
                _SellingPrice = sellingPrice;
                _Quantity = quantity;
                _Description = description;
            }

            

            public string productName
            {
                get
                {
                    return this._ProductName;
                }
                set
                {
                   this._ProductName = value;
                }
            }

            public string category
            {
                get
                {
                    return this._Category;
                }
                set
                {
                    this._Category = value;
                }
            }

            public string manufacturingDate
            {
                get
                {
                    return this._ManufacturingDate;
                }
                set
                {
                    this._ManufacturingDate = value;
                }
            }

            public string expirationDate
            {
                get
                {
                    return this._ExpirationDate;
                }
                set
                {
                    this._ExpirationDate = value;
                }
            }

            public string description
            {
                get
                {
                    return this._Description;
                }
                set
                {
                    this._Description = value;
                }
            }

            public int quantity
            {
                get
                {
                    return this._Quantity;
                }
                set
                {
                    this._Quantity = value;
                }
            }

            public double sellingPrice
            {
                get
                {
                    return this._SellingPrice;
                }
                set
                {
                    this._SellingPrice = value;
                }
            }
        }

    }
    }

        public class NumberFormatException : Exception
        {
            public NumberFormatException(string message) : base(message) { }
        }

        public class StringFormatException : Exception
        {
            public StringFormatException(string message) : base(message) { }
        }

        public class CurrencyFormatException : Exception
        {
            public CurrencyFormatException(string message) : base(message) { }
        }
    

