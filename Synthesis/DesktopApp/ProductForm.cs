using DAL;
using LogicLayer.Manager;
using LogicLayer.Object;
using System.Drawing.Imaging;
using System.Text.RegularExpressions;

namespace DesktopApp
{
    public partial class ProductForm : Form
    {
        private List<Category> categories = new List<Category>();
        private static readonly ProductDAL productDAL = new ProductDAL();
        private ProductManager productManager = new ProductManager(productDAL);
        private static readonly CategoryDAL categoryDAL = new CategoryDAL();
        private CategoryManager categoryManager = new CategoryManager(categoryDAL);
        private static readonly OrderDAL orderDAL = new OrderDAL();
        private OrderManager orderManager = new OrderManager(orderDAL);

        public ProductForm()
        {
            InitializeComponent();
            RefreshProductList();
            RefresOrderList();
            categories = categoryManager.GetCategories();
            ComboBoxCategory();
        }

        private void btnAddProduct_Click(object sender, EventArgs e)
        {
            if(tbxName.Text.Length == 0 || nudPrice.Value == 0 || tbxUnit.Text.Length == 0 || cbxCategory.SelectedIndex == -1 || cbxSubcategory.SelectedIndex == -1 || tbxDescription.Text.Length == 0 || pbxImage.Image == null)
            {
                MessageBox.Show("Please fill in all mandatory fields");
                return;
            }

            if(productManager.CreateProduct(tbxName.Text, Convert.ToDouble(nudPrice.Value), tbxUnit.Text, tbxDescription.Text, ImageToByteArray(pbxImage.Image), categoryManager.GetCategoryByName(cbxSubcategory.Text)) == false)
            {
                MessageBox.Show("A product with that name already exists");
                return;
            }

            MessageBox.Show("Product added successfully");

            tbxName.Clear();
            nudPrice.Value = 0;
            tbxUnit.Clear();
            cbxSubcategory.SelectedIndex = -1;
            cbxCategory.SelectedIndex = -1;
            tbxDescription.Clear();
            pbxImage.Image = null;

            RefreshProductList();
        }

        private void btnEdit_Click(object sender, EventArgs e)
        {
            if (tbxNameEdit.Text.Length == 0 || nudPriceEdit.Value == 0 || tbxUnitEdit.Text.Length == 0 || cbxActiveEdit.SelectedIndex == -1 || tbxDescriptionEdit.Text.Length == 0 || pbxImageEdit.Image == null)
            {
                MessageBox.Show("Please fill in all mandatory fields");
                return;
            }

            Product p = SelectProduct();

            if (p == null)
            {
                MessageBox.Show("No product was selected");
                return;
            }

            if (p.Name != tbxNameEdit.Text)
                if (productManager.CheckProductName(tbxNameEdit.Text))
                {
                    MessageBox.Show("A product with that name already exists");
                    return;
                }

            p.Name = tbxNameEdit.Text;
            p.Price = Convert.ToDouble(nudPriceEdit.Value);
            p.Unit = tbxUnitEdit.Text;
            p.Description = tbxDescriptionEdit.Text;
            p.Image = ImageToByteArray(pbxImageEdit.Image);
            p.Active = (bool)cbxActiveEdit.SelectedValue;

            if (productManager.UpdateProduct(p) == false)
            {
                MessageBox.Show("A product with that name already exists");
                return;
            }

            MessageBox.Show("Product updated successfully");

            tbxNameEdit.Clear();
            nudPriceEdit.Value = 0;
            tbxUnit.Clear();
            tbxDescription.Clear();
            pbxImage.Image = null;

            RefreshProductList();
        }

        private void btnOrder_Click(object sender, EventArgs e)
        {
            if(lbxOrder.SelectedIndex == -1)
            {
                MessageBox.Show("Please select an order");
                return;
            }
            string s = lbxOrder.SelectedItem.ToString();
            var orderId = Regex.Match(s, GetEverythingBeforeAComa());
            if (orderManager.UpdateOrderStatus(Convert.ToInt32(orderId.Value), (Status)cbxStatus.SelectedValue) == false)
            {
                MessageBox.Show("Something went wrong");
                return;
            }
            RefresOrderList();
            MessageBox.Show("Order status updated successfully");
        }

        private void btnImageEdit_Click(object sender, EventArgs e)
        {
            pbxImageEdit.Image = ChooseImage();
        }

        private void btnImage_Click(object sender, EventArgs e)
        {
            pbxImage.Image = ChooseImage();
        }

        private void lbxProducts_SelectedIndexChanged(object sender, EventArgs e)
        {
            ComboBoxActive();
            var product = SelectProduct();
            tbxNameEdit.Text = product.Name;
            nudPriceEdit.Value = (decimal)Convert.ToDouble(product.Price.ToString());
            tbxUnitEdit.Text = product.Unit;
            tbxDescriptionEdit.Text = product.Description;
            cbxActiveEdit.SelectedValue = product.Active;
            pbxImageEdit.Image = ByteArrayToImage(product.Image);
        }

        private void lbxOrder_SelectedIndexChanged(object sender, EventArgs e)
        {
            ComboBoxStatus();
            var order = SelectOrder();

            if (order.Pickup == null)
            {
                tbxCountry.Text = order.Adress.Country;
                tbxCity.Text = order.Adress.City;
                tbxPostalCode.Text = order.Adress.PostalCode;
                tbxStreet.Text = order.Adress.Street;
                tbxNumber.Text = Convert.ToString(order.Adress.Number);
            }
            else
            {
                tbxCountry.Text = order.Pickup.Country;
                tbxCity.Text = order.Pickup.City;
                tbxPostalCode.Text = order.Pickup.PostalCode;
                tbxStreet.Text = order.Pickup.Street;
                tbxNumber.Text = Convert.ToString(order.Pickup.Number);
            }

            tbxFirstName.Text = order.User.FirstName;
            tbxLastName.Text = order.User.LastName;
            tbxEmail.Text= order.User.Email;
            cbxStatus.SelectedValue = (int)order.Status;

            lbxOrderedProducts.Items.Clear();

            string s = lbxOrder.SelectedItem.ToString();
            var orderId = Regex.Match(s, GetEverythingBeforeAComa());
            order.Basket = orderManager.GetProductsOfOrder(Convert.ToInt32(orderId.Value));

            foreach(var b in order.Basket)
            {
                lbxOrderedProducts.Items.Add($"{b.Product.ToString()} Quantity: {b.Quantity}");
            }
        }

        private void RefreshProductList()
        {
            lbxProducts.Items.Clear();

            foreach (Product p in productManager.GetAllProducts())
            {
                lbxProducts.Items.Add(p.ToString());
            }

            lbxProducts.SelectedIndex = 0;
        }

        private void RefresOrderList()
        {
            lbxOrder.Items.Clear();

            foreach(Order o in orderManager.GetAllOrders())
            {
                lbxOrder.Items.Add(o.ToString());
            }
        }

        private void ComboBoxStatus()
        {
            List<KeyValuePair<int, string>> statusList = new List<KeyValuePair<int, string>>();
            Array statuses = Enum.GetValues(typeof(Status));
            foreach (Status status in statuses)
            {
                statusList.Add(new KeyValuePair<int, string>((int)status, status.ToString()));
            }
            cbxStatus.DataSource = statusList;
            cbxStatus.DisplayMember= "Value";
            cbxStatus.ValueMember= "Key";

            cbxStatus.ResetText();
        }

        private void ComboBoxActive()
        {
            List<KeyValuePair<bool, string>> activeList = new List<KeyValuePair<bool, string>> 
            { 
                new KeyValuePair<bool, string>(true, "active"),
                new KeyValuePair<bool, string>(false, "inactive")
            };

            cbxActiveEdit.DataSource = activeList;
            cbxActiveEdit.DisplayMember = "Value";
            cbxActiveEdit.ValueMember = "Key";

            cbxActiveEdit.ResetText();
        }

        private void ComboBoxCategory()
        {
            foreach(var c in categories)
                if(c.ParentId == null)
                    cbxCategory.Items.Add(c.ToString());
        }


        private void cbxCategory_SelectedIndexChanged(object sender, EventArgs e)
        {
            cbxSubcategory.Items.Clear();
            cbxSubcategory.ResetText();
            if(cbxCategory.SelectedIndex == -1)
                return;
            string s = cbxCategory.SelectedItem.ToString();
            var id = Regex.Match(s, GetEverythingBeforeAComa());
            foreach (var c in categories)
                if (c.ParentId == Convert.ToInt32(id.Value))
                    cbxSubcategory.Items.Add(c.Name);
        }

        private Product SelectProduct()
        {
            if (lbxProducts.SelectedIndex == -1)
                return null;
            string s = lbxProducts.SelectedItem.ToString();
            var name = Regex.Match(s, GetEverythingBeforeAComa());
            Product product = productManager.GetProductByName(name.Value);
            return product;
        }

        private Order SelectOrder()
        {
            if (lbxOrder.SelectedIndex == -1)
                return null;
            string s = lbxOrder.SelectedItem.ToString();
            var orderId = Regex.Match(s, GetEverythingBeforeAComa());
            Order order = orderManager.GetOrderById(Convert.ToInt32(orderId.Value));
            return order;
        }

        private Image ChooseImage()
        {
            OpenFileDialog odf = new OpenFileDialog();
            odf.Title = "Please select image";
            odf.Filter = "PNG|*.png|JPG|*.jpg";
            DialogResult result = odf.ShowDialog();
            if (result != DialogResult.OK && odf.FileName == null)
            {
                Image image = Image.FromFile(odf.FileName);
                return image;
            }
            return null;
        }

        private static byte[] ImageToByteArray(Image imageIn)
        {
            var ms = new MemoryStream();
            imageIn.Save(ms, ImageFormat.Png);
            return ms.ToArray();
        }

        private static Image ByteArrayToImage(byte[] byteArrayIn)
        {
            var ms = new MemoryStream(byteArrayIn);
            Image returnImage = Image.FromStream(ms);
            return returnImage;
        }

        private string GetEverythingBeforeAComa()
        {
            return @".*(?= -)";
        }
    }
}
