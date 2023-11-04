namespace DesktopApp
{
    partial class ProductForm
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.lblName = new System.Windows.Forms.Label();
            this.btnAddProduct = new System.Windows.Forms.Button();
            this.tbxName = new System.Windows.Forms.TextBox();
            this.tabControl = new System.Windows.Forms.TabControl();
            this.tpAdd = new System.Windows.Forms.TabPage();
            this.cbxSubcategory = new System.Windows.Forms.ComboBox();
            this.label2 = new System.Windows.Forms.Label();
            this.cbxCategory = new System.Windows.Forms.ComboBox();
            this.lblCategory = new System.Windows.Forms.Label();
            this.btnImage = new System.Windows.Forms.Button();
            this.pbxImage = new System.Windows.Forms.PictureBox();
            this.tbxDescription = new System.Windows.Forms.TextBox();
            this.lblDescription = new System.Windows.Forms.Label();
            this.tbxUnit = new System.Windows.Forms.TextBox();
            this.lblUnit = new System.Windows.Forms.Label();
            this.nudPrice = new System.Windows.Forms.NumericUpDown();
            this.lblPrice = new System.Windows.Forms.Label();
            this.tpEdit = new System.Windows.Forms.TabPage();
            this.cbxActiveEdit = new System.Windows.Forms.ComboBox();
            this.lblActiveEdit = new System.Windows.Forms.Label();
            this.btnImageEdit = new System.Windows.Forms.Button();
            this.pbxImageEdit = new System.Windows.Forms.PictureBox();
            this.tbxDescriptionEdit = new System.Windows.Forms.TextBox();
            this.lblDescriptionEdit = new System.Windows.Forms.Label();
            this.tbxUnitEdit = new System.Windows.Forms.TextBox();
            this.lblUnitEdit = new System.Windows.Forms.Label();
            this.nudPriceEdit = new System.Windows.Forms.NumericUpDown();
            this.lbxProducts = new System.Windows.Forms.ListBox();
            this.lblPriceEdit = new System.Windows.Forms.Label();
            this.tbxNameEdit = new System.Windows.Forms.TextBox();
            this.lblNameEdit = new System.Windows.Forms.Label();
            this.btnEdit = new System.Windows.Forms.Button();
            this.tpEditOrders = new System.Windows.Forms.TabPage();
            this.btnOrder = new System.Windows.Forms.Button();
            this.lbxOrderedProducts = new System.Windows.Forms.ListBox();
            this.gbxUser = new System.Windows.Forms.GroupBox();
            this.tbxEmail = new System.Windows.Forms.TextBox();
            this.label8 = new System.Windows.Forms.Label();
            this.tbxLastName = new System.Windows.Forms.TextBox();
            this.label9 = new System.Windows.Forms.Label();
            this.tbxFirstName = new System.Windows.Forms.TextBox();
            this.label10 = new System.Windows.Forms.Label();
            this.gbxAddress = new System.Windows.Forms.GroupBox();
            this.tbxNumber = new System.Windows.Forms.TextBox();
            this.label6 = new System.Windows.Forms.Label();
            this.tbxStreet = new System.Windows.Forms.TextBox();
            this.label5 = new System.Windows.Forms.Label();
            this.tbxPostalCode = new System.Windows.Forms.TextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.tbxCity = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.tbxCountry = new System.Windows.Forms.TextBox();
            this.lblAddress = new System.Windows.Forms.Label();
            this.cbxStatus = new System.Windows.Forms.ComboBox();
            this.lblStatus = new System.Windows.Forms.Label();
            this.lbxOrder = new System.Windows.Forms.ListBox();
            this.tabControl.SuspendLayout();
            this.tpAdd.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pbxImage)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.nudPrice)).BeginInit();
            this.tpEdit.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pbxImageEdit)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.nudPriceEdit)).BeginInit();
            this.tpEditOrders.SuspendLayout();
            this.gbxUser.SuspendLayout();
            this.gbxAddress.SuspendLayout();
            this.SuspendLayout();
            // 
            // lblName
            // 
            this.lblName.AutoSize = true;
            this.lblName.Location = new System.Drawing.Point(81, 45);
            this.lblName.Name = "lblName";
            this.lblName.Size = new System.Drawing.Size(56, 20);
            this.lblName.TabIndex = 0;
            this.lblName.Text = "Name :";
            // 
            // btnAddProduct
            // 
            this.btnAddProduct.Location = new System.Drawing.Point(438, 562);
            this.btnAddProduct.Name = "btnAddProduct";
            this.btnAddProduct.Size = new System.Drawing.Size(94, 29);
            this.btnAddProduct.TabIndex = 3;
            this.btnAddProduct.Text = "Add";
            this.btnAddProduct.UseVisualStyleBackColor = true;
            this.btnAddProduct.Click += new System.EventHandler(this.btnAddProduct_Click);
            // 
            // tbxName
            // 
            this.tbxName.Location = new System.Drawing.Point(221, 42);
            this.tbxName.Name = "tbxName";
            this.tbxName.Size = new System.Drawing.Size(157, 27);
            this.tbxName.TabIndex = 1;
            // 
            // tabControl
            // 
            this.tabControl.Controls.Add(this.tpAdd);
            this.tabControl.Controls.Add(this.tpEdit);
            this.tabControl.Controls.Add(this.tpEditOrders);
            this.tabControl.Location = new System.Drawing.Point(0, -2);
            this.tabControl.Name = "tabControl";
            this.tabControl.SelectedIndex = 0;
            this.tabControl.Size = new System.Drawing.Size(1084, 652);
            this.tabControl.TabIndex = 3;
            // 
            // tpAdd
            // 
            this.tpAdd.Controls.Add(this.cbxSubcategory);
            this.tpAdd.Controls.Add(this.label2);
            this.tpAdd.Controls.Add(this.cbxCategory);
            this.tpAdd.Controls.Add(this.lblCategory);
            this.tpAdd.Controls.Add(this.btnImage);
            this.tpAdd.Controls.Add(this.pbxImage);
            this.tpAdd.Controls.Add(this.tbxDescription);
            this.tpAdd.Controls.Add(this.lblDescription);
            this.tpAdd.Controls.Add(this.tbxUnit);
            this.tpAdd.Controls.Add(this.lblUnit);
            this.tpAdd.Controls.Add(this.nudPrice);
            this.tpAdd.Controls.Add(this.lblPrice);
            this.tpAdd.Controls.Add(this.tbxName);
            this.tpAdd.Controls.Add(this.lblName);
            this.tpAdd.Controls.Add(this.btnAddProduct);
            this.tpAdd.Location = new System.Drawing.Point(4, 29);
            this.tpAdd.Name = "tpAdd";
            this.tpAdd.Padding = new System.Windows.Forms.Padding(3);
            this.tpAdd.Size = new System.Drawing.Size(1076, 619);
            this.tpAdd.TabIndex = 0;
            this.tpAdd.Text = "Add Product";
            this.tpAdd.UseVisualStyleBackColor = true;
            // 
            // cbxSubcategory
            // 
            this.cbxSubcategory.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cbxSubcategory.FormattingEnabled = true;
            this.cbxSubcategory.Location = new System.Drawing.Point(221, 272);
            this.cbxSubcategory.Name = "cbxSubcategory";
            this.cbxSubcategory.Size = new System.Drawing.Size(157, 28);
            this.cbxSubcategory.TabIndex = 19;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(81, 275);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(99, 20);
            this.label2.TabIndex = 18;
            this.label2.Text = "Subcategory :";
            // 
            // cbxCategory
            // 
            this.cbxCategory.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cbxCategory.FormattingEnabled = true;
            this.cbxCategory.Location = new System.Drawing.Point(221, 210);
            this.cbxCategory.Name = "cbxCategory";
            this.cbxCategory.Size = new System.Drawing.Size(157, 28);
            this.cbxCategory.TabIndex = 17;
            this.cbxCategory.SelectedIndexChanged += new System.EventHandler(this.cbxCategory_SelectedIndexChanged);
            // 
            // lblCategory
            // 
            this.lblCategory.AutoSize = true;
            this.lblCategory.Location = new System.Drawing.Point(81, 213);
            this.lblCategory.Name = "lblCategory";
            this.lblCategory.Size = new System.Drawing.Size(76, 20);
            this.lblCategory.TabIndex = 16;
            this.lblCategory.Text = "Category :";
            // 
            // btnImage
            // 
            this.btnImage.Location = new System.Drawing.Point(597, 485);
            this.btnImage.Name = "btnImage";
            this.btnImage.Size = new System.Drawing.Size(115, 29);
            this.btnImage.TabIndex = 15;
            this.btnImage.Text = "Choose Image";
            this.btnImage.UseVisualStyleBackColor = true;
            this.btnImage.Click += new System.EventHandler(this.btnImage_Click);
            // 
            // pbxImage
            // 
            this.pbxImage.Location = new System.Drawing.Point(597, 42);
            this.pbxImage.Name = "pbxImage";
            this.pbxImage.Size = new System.Drawing.Size(417, 437);
            this.pbxImage.TabIndex = 14;
            this.pbxImage.TabStop = false;
            // 
            // tbxDescription
            // 
            this.tbxDescription.Location = new System.Drawing.Point(81, 367);
            this.tbxDescription.Multiline = true;
            this.tbxDescription.Name = "tbxDescription";
            this.tbxDescription.Size = new System.Drawing.Size(297, 200);
            this.tbxDescription.TabIndex = 8;
            // 
            // lblDescription
            // 
            this.lblDescription.AutoSize = true;
            this.lblDescription.Location = new System.Drawing.Point(81, 331);
            this.lblDescription.Name = "lblDescription";
            this.lblDescription.Size = new System.Drawing.Size(92, 20);
            this.lblDescription.TabIndex = 7;
            this.lblDescription.Text = "Description :";
            // 
            // tbxUnit
            // 
            this.tbxUnit.Location = new System.Drawing.Point(221, 150);
            this.tbxUnit.Name = "tbxUnit";
            this.tbxUnit.Size = new System.Drawing.Size(157, 27);
            this.tbxUnit.TabIndex = 6;
            // 
            // lblUnit
            // 
            this.lblUnit.AutoSize = true;
            this.lblUnit.Location = new System.Drawing.Point(81, 153);
            this.lblUnit.Name = "lblUnit";
            this.lblUnit.Size = new System.Drawing.Size(43, 20);
            this.lblUnit.TabIndex = 5;
            this.lblUnit.Text = "Unit :";
            // 
            // nudPrice
            // 
            this.nudPrice.DecimalPlaces = 2;
            this.nudPrice.Location = new System.Drawing.Point(221, 94);
            this.nudPrice.Maximum = new decimal(new int[] {
            100000,
            0,
            0,
            0});
            this.nudPrice.Name = "nudPrice";
            this.nudPrice.Size = new System.Drawing.Size(157, 27);
            this.nudPrice.TabIndex = 4;
            // 
            // lblPrice
            // 
            this.lblPrice.AutoSize = true;
            this.lblPrice.Location = new System.Drawing.Point(81, 96);
            this.lblPrice.Name = "lblPrice";
            this.lblPrice.Size = new System.Drawing.Size(48, 20);
            this.lblPrice.TabIndex = 0;
            this.lblPrice.Text = "Price :";
            // 
            // tpEdit
            // 
            this.tpEdit.Controls.Add(this.cbxActiveEdit);
            this.tpEdit.Controls.Add(this.lblActiveEdit);
            this.tpEdit.Controls.Add(this.btnImageEdit);
            this.tpEdit.Controls.Add(this.pbxImageEdit);
            this.tpEdit.Controls.Add(this.tbxDescriptionEdit);
            this.tpEdit.Controls.Add(this.lblDescriptionEdit);
            this.tpEdit.Controls.Add(this.tbxUnitEdit);
            this.tpEdit.Controls.Add(this.lblUnitEdit);
            this.tpEdit.Controls.Add(this.nudPriceEdit);
            this.tpEdit.Controls.Add(this.lbxProducts);
            this.tpEdit.Controls.Add(this.lblPriceEdit);
            this.tpEdit.Controls.Add(this.tbxNameEdit);
            this.tpEdit.Controls.Add(this.lblNameEdit);
            this.tpEdit.Controls.Add(this.btnEdit);
            this.tpEdit.Location = new System.Drawing.Point(4, 29);
            this.tpEdit.Name = "tpEdit";
            this.tpEdit.Padding = new System.Windows.Forms.Padding(3);
            this.tpEdit.Size = new System.Drawing.Size(1076, 619);
            this.tpEdit.TabIndex = 1;
            this.tpEdit.Text = "Edit Products";
            this.tpEdit.UseVisualStyleBackColor = true;
            // 
            // cbxActiveEdit
            // 
            this.cbxActiveEdit.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cbxActiveEdit.FormattingEnabled = true;
            this.cbxActiveEdit.Items.AddRange(new object[] {
            "active",
            "inactive"});
            this.cbxActiveEdit.Location = new System.Drawing.Point(391, 213);
            this.cbxActiveEdit.Name = "cbxActiveEdit";
            this.cbxActiveEdit.Size = new System.Drawing.Size(157, 28);
            this.cbxActiveEdit.TabIndex = 21;
            // 
            // lblActiveEdit
            // 
            this.lblActiveEdit.AutoSize = true;
            this.lblActiveEdit.Location = new System.Drawing.Point(244, 213);
            this.lblActiveEdit.Name = "lblActiveEdit";
            this.lblActiveEdit.Size = new System.Drawing.Size(61, 20);
            this.lblActiveEdit.TabIndex = 20;
            this.lblActiveEdit.Text = "Active : ";
            // 
            // btnImageEdit
            // 
            this.btnImageEdit.Location = new System.Drawing.Point(625, 502);
            this.btnImageEdit.Name = "btnImageEdit";
            this.btnImageEdit.Size = new System.Drawing.Size(115, 29);
            this.btnImageEdit.TabIndex = 14;
            this.btnImageEdit.Text = "Choose Image";
            this.btnImageEdit.UseVisualStyleBackColor = true;
            this.btnImageEdit.Click += new System.EventHandler(this.btnImageEdit_Click);
            // 
            // pbxImageEdit
            // 
            this.pbxImageEdit.Location = new System.Drawing.Point(625, 20);
            this.pbxImageEdit.Name = "pbxImageEdit";
            this.pbxImageEdit.Size = new System.Drawing.Size(417, 476);
            this.pbxImageEdit.TabIndex = 13;
            this.pbxImageEdit.TabStop = false;
            // 
            // tbxDescriptionEdit
            // 
            this.tbxDescriptionEdit.Location = new System.Drawing.Point(240, 331);
            this.tbxDescriptionEdit.Multiline = true;
            this.tbxDescriptionEdit.Name = "tbxDescriptionEdit";
            this.tbxDescriptionEdit.Size = new System.Drawing.Size(308, 200);
            this.tbxDescriptionEdit.TabIndex = 12;
            // 
            // lblDescriptionEdit
            // 
            this.lblDescriptionEdit.AutoSize = true;
            this.lblDescriptionEdit.Location = new System.Drawing.Point(244, 293);
            this.lblDescriptionEdit.Name = "lblDescriptionEdit";
            this.lblDescriptionEdit.Size = new System.Drawing.Size(92, 20);
            this.lblDescriptionEdit.TabIndex = 11;
            this.lblDescriptionEdit.Text = "Description :";
            // 
            // tbxUnitEdit
            // 
            this.tbxUnitEdit.Location = new System.Drawing.Point(391, 157);
            this.tbxUnitEdit.Name = "tbxUnitEdit";
            this.tbxUnitEdit.Size = new System.Drawing.Size(157, 27);
            this.tbxUnitEdit.TabIndex = 10;
            // 
            // lblUnitEdit
            // 
            this.lblUnitEdit.AutoSize = true;
            this.lblUnitEdit.Location = new System.Drawing.Point(244, 160);
            this.lblUnitEdit.Name = "lblUnitEdit";
            this.lblUnitEdit.Size = new System.Drawing.Size(43, 20);
            this.lblUnitEdit.TabIndex = 9;
            this.lblUnitEdit.Text = "Unit :";
            // 
            // nudPriceEdit
            // 
            this.nudPriceEdit.DecimalPlaces = 2;
            this.nudPriceEdit.Location = new System.Drawing.Point(391, 108);
            this.nudPriceEdit.Maximum = new decimal(new int[] {
            100000,
            0,
            0,
            0});
            this.nudPriceEdit.Name = "nudPriceEdit";
            this.nudPriceEdit.Size = new System.Drawing.Size(157, 27);
            this.nudPriceEdit.TabIndex = 3;
            // 
            // lbxProducts
            // 
            this.lbxProducts.FormattingEnabled = true;
            this.lbxProducts.ItemHeight = 20;
            this.lbxProducts.Location = new System.Drawing.Point(3, 6);
            this.lbxProducts.Name = "lbxProducts";
            this.lbxProducts.Size = new System.Drawing.Size(209, 604);
            this.lbxProducts.TabIndex = 1;
            this.lbxProducts.SelectedIndexChanged += new System.EventHandler(this.lbxProducts_SelectedIndexChanged);
            // 
            // lblPriceEdit
            // 
            this.lblPriceEdit.AutoSize = true;
            this.lblPriceEdit.Location = new System.Drawing.Point(244, 110);
            this.lblPriceEdit.Name = "lblPriceEdit";
            this.lblPriceEdit.Size = new System.Drawing.Size(48, 20);
            this.lblPriceEdit.TabIndex = 0;
            this.lblPriceEdit.Text = "Price :";
            // 
            // tbxNameEdit
            // 
            this.tbxNameEdit.Location = new System.Drawing.Point(391, 60);
            this.tbxNameEdit.Name = "tbxNameEdit";
            this.tbxNameEdit.Size = new System.Drawing.Size(157, 27);
            this.tbxNameEdit.TabIndex = 2;
            // 
            // lblNameEdit
            // 
            this.lblNameEdit.AutoSize = true;
            this.lblNameEdit.Location = new System.Drawing.Point(244, 67);
            this.lblNameEdit.Name = "lblNameEdit";
            this.lblNameEdit.Size = new System.Drawing.Size(56, 20);
            this.lblNameEdit.TabIndex = 0;
            this.lblNameEdit.Text = "Name :";
            // 
            // btnEdit
            // 
            this.btnEdit.Location = new System.Drawing.Point(435, 562);
            this.btnEdit.Name = "btnEdit";
            this.btnEdit.Size = new System.Drawing.Size(94, 29);
            this.btnEdit.TabIndex = 4;
            this.btnEdit.Text = "Edit";
            this.btnEdit.UseVisualStyleBackColor = true;
            this.btnEdit.Click += new System.EventHandler(this.btnEdit_Click);
            // 
            // tpEditOrders
            // 
            this.tpEditOrders.Controls.Add(this.btnOrder);
            this.tpEditOrders.Controls.Add(this.lbxOrderedProducts);
            this.tpEditOrders.Controls.Add(this.gbxUser);
            this.tpEditOrders.Controls.Add(this.gbxAddress);
            this.tpEditOrders.Controls.Add(this.cbxStatus);
            this.tpEditOrders.Controls.Add(this.lblStatus);
            this.tpEditOrders.Controls.Add(this.lbxOrder);
            this.tpEditOrders.Location = new System.Drawing.Point(4, 29);
            this.tpEditOrders.Name = "tpEditOrders";
            this.tpEditOrders.Size = new System.Drawing.Size(1076, 619);
            this.tpEditOrders.TabIndex = 2;
            this.tpEditOrders.Text = "Edit Orders";
            this.tpEditOrders.UseVisualStyleBackColor = true;
            // 
            // btnOrder
            // 
            this.btnOrder.Location = new System.Drawing.Point(919, 538);
            this.btnOrder.Name = "btnOrder";
            this.btnOrder.Size = new System.Drawing.Size(131, 46);
            this.btnOrder.TabIndex = 47;
            this.btnOrder.Text = "Change Status";
            this.btnOrder.UseVisualStyleBackColor = true;
            this.btnOrder.Click += new System.EventHandler(this.btnOrder_Click);
            // 
            // lbxOrderedProducts
            // 
            this.lbxOrderedProducts.FormattingEnabled = true;
            this.lbxOrderedProducts.ItemHeight = 20;
            this.lbxOrderedProducts.Location = new System.Drawing.Point(667, 7);
            this.lbxOrderedProducts.Name = "lbxOrderedProducts";
            this.lbxOrderedProducts.Size = new System.Drawing.Size(402, 444);
            this.lbxOrderedProducts.TabIndex = 46;
            // 
            // gbxUser
            // 
            this.gbxUser.Controls.Add(this.tbxEmail);
            this.gbxUser.Controls.Add(this.label8);
            this.gbxUser.Controls.Add(this.tbxLastName);
            this.gbxUser.Controls.Add(this.label9);
            this.gbxUser.Controls.Add(this.tbxFirstName);
            this.gbxUser.Controls.Add(this.label10);
            this.gbxUser.Location = new System.Drawing.Point(287, 291);
            this.gbxUser.Name = "gbxUser";
            this.gbxUser.Size = new System.Drawing.Size(374, 320);
            this.gbxUser.TabIndex = 45;
            this.gbxUser.TabStop = false;
            this.gbxUser.Text = "User";
            // 
            // tbxEmail
            // 
            this.tbxEmail.Location = new System.Drawing.Point(122, 194);
            this.tbxEmail.Name = "tbxEmail";
            this.tbxEmail.ReadOnly = true;
            this.tbxEmail.Size = new System.Drawing.Size(218, 27);
            this.tbxEmail.TabIndex = 42;
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Location = new System.Drawing.Point(22, 197);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(53, 20);
            this.label8.TabIndex = 41;
            this.label8.Text = "Email :";
            // 
            // tbxLastName
            // 
            this.tbxLastName.Location = new System.Drawing.Point(122, 149);
            this.tbxLastName.Name = "tbxLastName";
            this.tbxLastName.ReadOnly = true;
            this.tbxLastName.Size = new System.Drawing.Size(218, 27);
            this.tbxLastName.TabIndex = 40;
            // 
            // label9
            // 
            this.label9.AutoSize = true;
            this.label9.Location = new System.Drawing.Point(22, 152);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(86, 20);
            this.label9.TabIndex = 39;
            this.label9.Text = "Last Name :";
            // 
            // tbxFirstName
            // 
            this.tbxFirstName.Location = new System.Drawing.Point(122, 99);
            this.tbxFirstName.Name = "tbxFirstName";
            this.tbxFirstName.ReadOnly = true;
            this.tbxFirstName.Size = new System.Drawing.Size(218, 27);
            this.tbxFirstName.TabIndex = 38;
            // 
            // label10
            // 
            this.label10.AutoSize = true;
            this.label10.Location = new System.Drawing.Point(22, 102);
            this.label10.Name = "label10";
            this.label10.Size = new System.Drawing.Size(87, 20);
            this.label10.TabIndex = 37;
            this.label10.Text = "First Name :";
            // 
            // gbxAddress
            // 
            this.gbxAddress.Controls.Add(this.tbxNumber);
            this.gbxAddress.Controls.Add(this.label6);
            this.gbxAddress.Controls.Add(this.tbxStreet);
            this.gbxAddress.Controls.Add(this.label5);
            this.gbxAddress.Controls.Add(this.tbxPostalCode);
            this.gbxAddress.Controls.Add(this.label3);
            this.gbxAddress.Controls.Add(this.tbxCity);
            this.gbxAddress.Controls.Add(this.label1);
            this.gbxAddress.Controls.Add(this.tbxCountry);
            this.gbxAddress.Controls.Add(this.lblAddress);
            this.gbxAddress.Location = new System.Drawing.Point(287, 7);
            this.gbxAddress.Name = "gbxAddress";
            this.gbxAddress.Size = new System.Drawing.Size(374, 278);
            this.gbxAddress.TabIndex = 36;
            this.gbxAddress.TabStop = false;
            this.gbxAddress.Text = "Address";
            // 
            // tbxNumber
            // 
            this.tbxNumber.Location = new System.Drawing.Point(122, 220);
            this.tbxNumber.Name = "tbxNumber";
            this.tbxNumber.ReadOnly = true;
            this.tbxNumber.Size = new System.Drawing.Size(218, 27);
            this.tbxNumber.TabIndex = 44;
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(22, 223);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(70, 20);
            this.label6.TabIndex = 43;
            this.label6.Text = "Number :";
            // 
            // tbxStreet
            // 
            this.tbxStreet.Location = new System.Drawing.Point(122, 177);
            this.tbxStreet.Name = "tbxStreet";
            this.tbxStreet.ReadOnly = true;
            this.tbxStreet.Size = new System.Drawing.Size(218, 27);
            this.tbxStreet.TabIndex = 42;
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(22, 180);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(55, 20);
            this.label5.TabIndex = 41;
            this.label5.Text = "Street :";
            // 
            // tbxPostalCode
            // 
            this.tbxPostalCode.Location = new System.Drawing.Point(122, 132);
            this.tbxPostalCode.Name = "tbxPostalCode";
            this.tbxPostalCode.ReadOnly = true;
            this.tbxPostalCode.Size = new System.Drawing.Size(218, 27);
            this.tbxPostalCode.TabIndex = 40;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(22, 135);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(94, 20);
            this.label3.TabIndex = 39;
            this.label3.Text = "Postal Code :";
            // 
            // tbxCity
            // 
            this.tbxCity.Location = new System.Drawing.Point(122, 82);
            this.tbxCity.Name = "tbxCity";
            this.tbxCity.ReadOnly = true;
            this.tbxCity.Size = new System.Drawing.Size(218, 27);
            this.tbxCity.TabIndex = 38;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(22, 85);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(41, 20);
            this.label1.TabIndex = 37;
            this.label1.Text = "City :";
            // 
            // tbxCountry
            // 
            this.tbxCountry.Location = new System.Drawing.Point(122, 34);
            this.tbxCountry.Name = "tbxCountry";
            this.tbxCountry.ReadOnly = true;
            this.tbxCountry.Size = new System.Drawing.Size(218, 27);
            this.tbxCountry.TabIndex = 36;
            // 
            // lblAddress
            // 
            this.lblAddress.AutoSize = true;
            this.lblAddress.Location = new System.Drawing.Point(22, 37);
            this.lblAddress.Name = "lblAddress";
            this.lblAddress.Size = new System.Drawing.Size(67, 20);
            this.lblAddress.TabIndex = 35;
            this.lblAddress.Text = "Country :";
            // 
            // cbxStatus
            // 
            this.cbxStatus.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cbxStatus.FormattingEnabled = true;
            this.cbxStatus.Location = new System.Drawing.Point(676, 556);
            this.cbxStatus.Name = "cbxStatus";
            this.cbxStatus.Size = new System.Drawing.Size(182, 28);
            this.cbxStatus.TabIndex = 31;
            // 
            // lblStatus
            // 
            this.lblStatus.AutoSize = true;
            this.lblStatus.Location = new System.Drawing.Point(676, 512);
            this.lblStatus.Name = "lblStatus";
            this.lblStatus.Size = new System.Drawing.Size(56, 20);
            this.lblStatus.TabIndex = 30;
            this.lblStatus.Text = "Status :";
            // 
            // lbxOrder
            // 
            this.lbxOrder.FormattingEnabled = true;
            this.lbxOrder.ItemHeight = 20;
            this.lbxOrder.Location = new System.Drawing.Point(8, 7);
            this.lbxOrder.Name = "lbxOrder";
            this.lbxOrder.Size = new System.Drawing.Size(273, 604);
            this.lbxOrder.TabIndex = 2;
            this.lbxOrder.SelectedIndexChanged += new System.EventHandler(this.lbxOrder_SelectedIndexChanged);
            // 
            // ProductForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 20F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1085, 650);
            this.Controls.Add(this.tabControl);
            this.Name = "ProductForm";
            this.Text = "ProductForm";
            this.tabControl.ResumeLayout(false);
            this.tpAdd.ResumeLayout(false);
            this.tpAdd.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pbxImage)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.nudPrice)).EndInit();
            this.tpEdit.ResumeLayout(false);
            this.tpEdit.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pbxImageEdit)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.nudPriceEdit)).EndInit();
            this.tpEditOrders.ResumeLayout(false);
            this.tpEditOrders.PerformLayout();
            this.gbxUser.ResumeLayout(false);
            this.gbxUser.PerformLayout();
            this.gbxAddress.ResumeLayout(false);
            this.gbxAddress.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private Label lblName;
        private Button btnAddProduct;
        private TextBox tbxName;
        private TabControl tabControl;
        private TabPage tpAdd;
        private TabPage tpEdit;
        private Label lblPrice;
        private ListBox lbxProducts;
        private Label lblPriceEdit;
        private TextBox tbxNameEdit;
        private Label lblNameEdit;
        private Button btnEdit;
        private NumericUpDown nudPriceEdit;
        private NumericUpDown nudPrice;
        private TextBox tbxDescription;
        private Label lblDescription;
        private TextBox tbxUnit;
        private Label lblUnit;
        private PictureBox pbxImage;
        private Button btnImageEdit;
        private PictureBox pbxImageEdit;
        private TextBox tbxDescriptionEdit;
        private Label lblDescriptionEdit;
        private TextBox tbxUnitEdit;
        private Label lblUnitEdit;
        private Button btnImage;
        private ComboBox cbxSubcategory;
        private Label label2;
        private ComboBox cbxCategory;
        private Label lblCategory;
        private TabPage tpEditOrders;
        private ListBox lbxOrder;
        private Label lblAddress;
        private ComboBox cbxStatus;
        private Label lblStatus;
        private GroupBox gbxAddress;
        private TextBox tbxPostalCode;
        private Label label3;
        private TextBox tbxCity;
        private Label label1;
        private TextBox tbxCountry;
        private TextBox tbxNumber;
        private Label label6;
        private TextBox tbxStreet;
        private Label label5;
        private GroupBox gbxUser;
        private TextBox tbxEmail;
        private Label label8;
        private TextBox tbxLastName;
        private Label label9;
        private TextBox tbxFirstName;
        private Label label10;
        private Button btnOrder;
        private ListBox lbxOrderedProducts;
        private ComboBox cbxActiveEdit;
        private Label lblActiveEdit;
    }
}