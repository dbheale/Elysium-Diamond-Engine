namespace TextEditor {
    partial class ItemForm {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing) {
            if (disposing && (components != null)) {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent() {
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(ItemForm));
            this.cmb_type = new System.Windows.Forms.ComboBox();
            this.label1 = new System.Windows.Forms.Label();
            this.c_trade = new System.Windows.Forms.CheckBox();
            this.c_soul = new System.Windows.Forms.CheckBox();
            this.cmb_hand = new System.Windows.Forms.ComboBox();
            this.label3 = new System.Windows.Forms.Label();
            this.cmb_rarity = new System.Windows.Forms.ComboBox();
            this.label2 = new System.Windows.Forms.Label();
            this.label12 = new System.Windows.Forms.Label();
            this.txt_name = new System.Windows.Forms.TextBox();
            this.btn_save = new System.Windows.Forms.Button();
            this.btn_open = new System.Windows.Forms.Button();
            this.lbl_name = new System.Windows.Forms.Label();
            this.lbl_type = new System.Windows.Forms.Label();
            this.lbl_rarity = new System.Windows.Forms.Label();
            this.lbl_durability = new System.Windows.Forms.Label();
            this.lbl_hand = new System.Windows.Forms.Label();
            this.lbl_level = new System.Windows.Forms.Label();
            this.lbl_bound = new System.Windows.Forms.Label();
            this.lbl_tradeable = new System.Windows.Forms.Label();
            this.lbl_stat1 = new System.Windows.Forms.Label();
            this.lbl_stat2 = new System.Windows.Forms.Label();
            this.lbl_stat3 = new System.Windows.Forms.Label();
            this.lbl_stat4 = new System.Windows.Forms.Label();
            this.lbl_stat5 = new System.Windows.Forms.Label();
            this.lbl_stat6 = new System.Windows.Forms.Label();
            this.lbl_stat7 = new System.Windows.Forms.Label();
            this.lbl_stat8 = new System.Windows.Forms.Label();
            this.lbl_stat9 = new System.Windows.Forms.Label();
            this.lbl_stat10 = new System.Windows.Forms.Label();
            this.lbl_stat11 = new System.Windows.Forms.Label();
            this.lbl_stat12 = new System.Windows.Forms.Label();
            this.lbl_stat13 = new System.Windows.Forms.Label();
            this.lbl_stat14 = new System.Windows.Forms.Label();
            this.lbl_stat15 = new System.Windows.Forms.Label();
            this.lbl_stat16 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.txt_durability = new System.Windows.Forms.TextBox();
            this.txt_level = new System.Windows.Forms.TextBox();
            this.label5 = new System.Windows.Forms.Label();
            this.c_showline = new System.Windows.Forms.CheckBox();
            this.txt_stat = new System.Windows.Forms.TextBox();
            this.lbl_line = new System.Windows.Forms.Label();
            this.label6 = new System.Windows.Forms.Label();
            this.txt_id = new System.Windows.Forms.TextBox();
            this.label7 = new System.Windows.Forms.Label();
            this.txt_icon = new System.Windows.Forms.TextBox();
            this.SuspendLayout();
            // 
            // cmb_type
            // 
            this.cmb_type.Items.AddRange(new object[] {
            "Weapon",
            "Shield",
            "Head",
            "Gloves",
            "Shoulder",
            "Chest",
            "Pants",
            "Legs",
            "Belt",
            "Necklace",
            "Earring",
            "Ring"});
            this.cmb_type.Location = new System.Drawing.Point(436, 159);
            this.cmb_type.Name = "cmb_type";
            this.cmb_type.Size = new System.Drawing.Size(143, 23);
            this.cmb_type.TabIndex = 1;
            this.cmb_type.Text = "Weapon";
            this.cmb_type.SelectedIndexChanged += new System.EventHandler(this.cmb_type_SelectedIndexChanged);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(388, 162);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(35, 15);
            this.label1.TabIndex = 2;
            this.label1.Text = "Type";
            // 
            // c_trade
            // 
            this.c_trade.AutoSize = true;
            this.c_trade.Checked = true;
            this.c_trade.CheckState = System.Windows.Forms.CheckState.Checked;
            this.c_trade.Location = new System.Drawing.Point(387, 271);
            this.c_trade.Name = "c_trade";
            this.c_trade.Size = new System.Drawing.Size(83, 19);
            this.c_trade.TabIndex = 8;
            this.c_trade.Text = "Tradeable";
            this.c_trade.UseVisualStyleBackColor = true;
            this.c_trade.CheckedChanged += new System.EventHandler(this.c_trade_CheckedChanged);
            // 
            // c_soul
            // 
            this.c_soul.AutoSize = true;
            this.c_soul.Location = new System.Drawing.Point(387, 246);
            this.c_soul.Name = "c_soul";
            this.c_soul.Size = new System.Drawing.Size(91, 19);
            this.c_soul.TabIndex = 7;
            this.c_soul.Text = "Soul Bound";
            this.c_soul.UseVisualStyleBackColor = true;
            this.c_soul.CheckedChanged += new System.EventHandler(this.c_soul_CheckedChanged);
            // 
            // cmb_hand
            // 
            this.cmb_hand.Items.AddRange(new object[] {
            "OneHanded",
            "TwoHanded"});
            this.cmb_hand.Location = new System.Drawing.Point(436, 217);
            this.cmb_hand.Name = "cmb_hand";
            this.cmb_hand.Size = new System.Drawing.Size(143, 23);
            this.cmb_hand.TabIndex = 6;
            this.cmb_hand.Text = "OneHanded";
            this.cmb_hand.SelectedIndexChanged += new System.EventHandler(this.cmb_hand_SelectedIndexChanged);
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(388, 225);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(37, 15);
            this.label3.TabIndex = 5;
            this.label3.Text = "Hand";
            // 
            // cmb_rarity
            // 
            this.cmb_rarity.Items.AddRange(new object[] {
            "Poor",
            "Common",
            "Uncommon",
            "Rare",
            "Epic",
            "Legendary",
            "Mythic",
            "Artifact",
            "Ethereal"});
            this.cmb_rarity.Location = new System.Drawing.Point(436, 188);
            this.cmb_rarity.Name = "cmb_rarity";
            this.cmb_rarity.Size = new System.Drawing.Size(143, 23);
            this.cmb_rarity.TabIndex = 3;
            this.cmb_rarity.Text = "Poor";
            this.cmb_rarity.SelectedIndexChanged += new System.EventHandler(this.cmb_rarity_SelectedIndexChanged);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(388, 195);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(42, 15);
            this.label2.TabIndex = 4;
            this.label2.Text = "Rarity";
            // 
            // label12
            // 
            this.label12.Location = new System.Drawing.Point(388, 75);
            this.label12.Name = "label12";
            this.label12.Size = new System.Drawing.Size(46, 20);
            this.label12.TabIndex = 92;
            this.label12.Text = "Name";
            this.label12.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // txt_name
            // 
            this.txt_name.Location = new System.Drawing.Point(436, 72);
            this.txt_name.Name = "txt_name";
            this.txt_name.Size = new System.Drawing.Size(143, 23);
            this.txt_name.TabIndex = 91;
            this.txt_name.Text = "Machado de Metal";
            this.txt_name.TextChanged += new System.EventHandler(this.txt_name_TextChanged);
            // 
            // btn_save
            // 
            this.btn_save.Location = new System.Drawing.Point(387, 394);
            this.btn_save.Name = "btn_save";
            this.btn_save.Size = new System.Drawing.Size(125, 23);
            this.btn_save.TabIndex = 95;
            this.btn_save.Text = "Save Item";
            this.btn_save.UseVisualStyleBackColor = true;
            this.btn_save.Click += new System.EventHandler(this.btn_save_Click);
            // 
            // btn_open
            // 
            this.btn_open.Location = new System.Drawing.Point(387, 420);
            this.btn_open.Name = "btn_open";
            this.btn_open.Size = new System.Drawing.Size(125, 23);
            this.btn_open.TabIndex = 96;
            this.btn_open.Text = "Open Item";
            this.btn_open.UseVisualStyleBackColor = true;
            this.btn_open.Click += new System.EventHandler(this.btn_open_Click);
            // 
            // lbl_name
            // 
            this.lbl_name.BackColor = System.Drawing.Color.Transparent;
            this.lbl_name.Font = new System.Drawing.Font("Georgia", 12F);
            this.lbl_name.ForeColor = System.Drawing.Color.DarkGray;
            this.lbl_name.Location = new System.Drawing.Point(12, 12);
            this.lbl_name.Name = "lbl_name";
            this.lbl_name.Size = new System.Drawing.Size(350, 20);
            this.lbl_name.TabIndex = 97;
            this.lbl_name.Text = "Machado de Metal";
            this.lbl_name.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // lbl_type
            // 
            this.lbl_type.BackColor = System.Drawing.Color.Transparent;
            this.lbl_type.Font = new System.Drawing.Font("Georgia", 12F);
            this.lbl_type.ForeColor = System.Drawing.Color.White;
            this.lbl_type.Location = new System.Drawing.Point(15, 32);
            this.lbl_type.Name = "lbl_type";
            this.lbl_type.Size = new System.Drawing.Size(139, 20);
            this.lbl_type.TabIndex = 98;
            this.lbl_type.Text = "Arma";
            // 
            // lbl_rarity
            // 
            this.lbl_rarity.BackColor = System.Drawing.Color.Transparent;
            this.lbl_rarity.Font = new System.Drawing.Font("Georgia", 12F);
            this.lbl_rarity.ForeColor = System.Drawing.Color.White;
            this.lbl_rarity.Location = new System.Drawing.Point(166, 32);
            this.lbl_rarity.Name = "lbl_rarity";
            this.lbl_rarity.Size = new System.Drawing.Size(183, 20);
            this.lbl_rarity.TabIndex = 99;
            this.lbl_rarity.Text = "Baixa qualidade";
            this.lbl_rarity.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // lbl_durability
            // 
            this.lbl_durability.BackColor = System.Drawing.Color.Transparent;
            this.lbl_durability.Font = new System.Drawing.Font("Georgia", 12F);
            this.lbl_durability.ForeColor = System.Drawing.Color.White;
            this.lbl_durability.Location = new System.Drawing.Point(15, 52);
            this.lbl_durability.Name = "lbl_durability";
            this.lbl_durability.Size = new System.Drawing.Size(201, 20);
            this.lbl_durability.TabIndex = 100;
            this.lbl_durability.Text = "Durabilidade 255 / 255";
            // 
            // lbl_hand
            // 
            this.lbl_hand.BackColor = System.Drawing.Color.Transparent;
            this.lbl_hand.Font = new System.Drawing.Font("Georgia", 12F);
            this.lbl_hand.ForeColor = System.Drawing.Color.White;
            this.lbl_hand.Location = new System.Drawing.Point(203, 52);
            this.lbl_hand.Name = "lbl_hand";
            this.lbl_hand.Size = new System.Drawing.Size(146, 20);
            this.lbl_hand.TabIndex = 101;
            this.lbl_hand.Text = "Item de uma mão";
            this.lbl_hand.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // lbl_level
            // 
            this.lbl_level.BackColor = System.Drawing.Color.Transparent;
            this.lbl_level.Font = new System.Drawing.Font("Georgia", 12F);
            this.lbl_level.ForeColor = System.Drawing.Color.White;
            this.lbl_level.Location = new System.Drawing.Point(15, 72);
            this.lbl_level.Name = "lbl_level";
            this.lbl_level.Size = new System.Drawing.Size(342, 20);
            this.lbl_level.TabIndex = 102;
            this.lbl_level.Text = "Pode ser usado no level 65";
            // 
            // lbl_bound
            // 
            this.lbl_bound.BackColor = System.Drawing.Color.Transparent;
            this.lbl_bound.Font = new System.Drawing.Font("Georgia", 12F);
            this.lbl_bound.ForeColor = System.Drawing.Color.White;
            this.lbl_bound.Location = new System.Drawing.Point(15, 92);
            this.lbl_bound.Name = "lbl_bound";
            this.lbl_bound.Size = new System.Drawing.Size(230, 20);
            this.lbl_bound.TabIndex = 103;
            this.lbl_bound.Text = "Item não ligado ao personagem";
            // 
            // lbl_tradeable
            // 
            this.lbl_tradeable.BackColor = System.Drawing.Color.Transparent;
            this.lbl_tradeable.Font = new System.Drawing.Font("Georgia", 12F);
            this.lbl_tradeable.ForeColor = System.Drawing.Color.White;
            this.lbl_tradeable.Location = new System.Drawing.Point(248, 93);
            this.lbl_tradeable.Name = "lbl_tradeable";
            this.lbl_tradeable.Size = new System.Drawing.Size(101, 20);
            this.lbl_tradeable.TabIndex = 104;
            this.lbl_tradeable.Text = "Negociável";
            this.lbl_tradeable.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // lbl_stat1
            // 
            this.lbl_stat1.BackColor = System.Drawing.Color.Transparent;
            this.lbl_stat1.Font = new System.Drawing.Font("Georgia", 12F);
            this.lbl_stat1.ForeColor = System.Drawing.Color.White;
            this.lbl_stat1.Location = new System.Drawing.Point(12, 133);
            this.lbl_stat1.Name = "lbl_stat1";
            this.lbl_stat1.Size = new System.Drawing.Size(337, 20);
            this.lbl_stat1.TabIndex = 106;
            // 
            // lbl_stat2
            // 
            this.lbl_stat2.BackColor = System.Drawing.Color.Transparent;
            this.lbl_stat2.Font = new System.Drawing.Font("Georgia", 12F);
            this.lbl_stat2.ForeColor = System.Drawing.Color.White;
            this.lbl_stat2.Location = new System.Drawing.Point(12, 153);
            this.lbl_stat2.Name = "lbl_stat2";
            this.lbl_stat2.Size = new System.Drawing.Size(337, 20);
            this.lbl_stat2.TabIndex = 107;
            // 
            // lbl_stat3
            // 
            this.lbl_stat3.BackColor = System.Drawing.Color.Transparent;
            this.lbl_stat3.Font = new System.Drawing.Font("Georgia", 12F);
            this.lbl_stat3.ForeColor = System.Drawing.Color.White;
            this.lbl_stat3.Location = new System.Drawing.Point(12, 173);
            this.lbl_stat3.Name = "lbl_stat3";
            this.lbl_stat3.Size = new System.Drawing.Size(337, 20);
            this.lbl_stat3.TabIndex = 108;
            // 
            // lbl_stat4
            // 
            this.lbl_stat4.BackColor = System.Drawing.Color.Transparent;
            this.lbl_stat4.Font = new System.Drawing.Font("Georgia", 12F);
            this.lbl_stat4.ForeColor = System.Drawing.Color.White;
            this.lbl_stat4.Location = new System.Drawing.Point(12, 193);
            this.lbl_stat4.Name = "lbl_stat4";
            this.lbl_stat4.Size = new System.Drawing.Size(337, 20);
            this.lbl_stat4.TabIndex = 109;
            // 
            // lbl_stat5
            // 
            this.lbl_stat5.BackColor = System.Drawing.Color.Transparent;
            this.lbl_stat5.Font = new System.Drawing.Font("Georgia", 12F);
            this.lbl_stat5.ForeColor = System.Drawing.Color.White;
            this.lbl_stat5.Location = new System.Drawing.Point(12, 213);
            this.lbl_stat5.Name = "lbl_stat5";
            this.lbl_stat5.Size = new System.Drawing.Size(337, 20);
            this.lbl_stat5.TabIndex = 110;
            // 
            // lbl_stat6
            // 
            this.lbl_stat6.BackColor = System.Drawing.Color.Transparent;
            this.lbl_stat6.Font = new System.Drawing.Font("Georgia", 12F);
            this.lbl_stat6.ForeColor = System.Drawing.Color.White;
            this.lbl_stat6.Location = new System.Drawing.Point(12, 234);
            this.lbl_stat6.Name = "lbl_stat6";
            this.lbl_stat6.Size = new System.Drawing.Size(337, 20);
            this.lbl_stat6.TabIndex = 111;
            // 
            // lbl_stat7
            // 
            this.lbl_stat7.BackColor = System.Drawing.Color.Transparent;
            this.lbl_stat7.Font = new System.Drawing.Font("Georgia", 12F);
            this.lbl_stat7.ForeColor = System.Drawing.Color.White;
            this.lbl_stat7.Location = new System.Drawing.Point(12, 254);
            this.lbl_stat7.Name = "lbl_stat7";
            this.lbl_stat7.Size = new System.Drawing.Size(337, 20);
            this.lbl_stat7.TabIndex = 112;
            // 
            // lbl_stat8
            // 
            this.lbl_stat8.BackColor = System.Drawing.Color.Transparent;
            this.lbl_stat8.Font = new System.Drawing.Font("Georgia", 12F);
            this.lbl_stat8.ForeColor = System.Drawing.Color.White;
            this.lbl_stat8.Location = new System.Drawing.Point(12, 274);
            this.lbl_stat8.Name = "lbl_stat8";
            this.lbl_stat8.Size = new System.Drawing.Size(337, 20);
            this.lbl_stat8.TabIndex = 113;
            // 
            // lbl_stat9
            // 
            this.lbl_stat9.BackColor = System.Drawing.Color.Transparent;
            this.lbl_stat9.Font = new System.Drawing.Font("Georgia", 12F);
            this.lbl_stat9.ForeColor = System.Drawing.Color.White;
            this.lbl_stat9.Location = new System.Drawing.Point(12, 294);
            this.lbl_stat9.Name = "lbl_stat9";
            this.lbl_stat9.Size = new System.Drawing.Size(337, 20);
            this.lbl_stat9.TabIndex = 114;
            // 
            // lbl_stat10
            // 
            this.lbl_stat10.BackColor = System.Drawing.Color.Transparent;
            this.lbl_stat10.Font = new System.Drawing.Font("Georgia", 12F);
            this.lbl_stat10.ForeColor = System.Drawing.Color.White;
            this.lbl_stat10.Location = new System.Drawing.Point(12, 314);
            this.lbl_stat10.Name = "lbl_stat10";
            this.lbl_stat10.Size = new System.Drawing.Size(337, 20);
            this.lbl_stat10.TabIndex = 115;
            // 
            // lbl_stat11
            // 
            this.lbl_stat11.BackColor = System.Drawing.Color.Transparent;
            this.lbl_stat11.Font = new System.Drawing.Font("Georgia", 12F);
            this.lbl_stat11.ForeColor = System.Drawing.Color.White;
            this.lbl_stat11.Location = new System.Drawing.Point(12, 334);
            this.lbl_stat11.Name = "lbl_stat11";
            this.lbl_stat11.Size = new System.Drawing.Size(337, 20);
            this.lbl_stat11.TabIndex = 116;
            // 
            // lbl_stat12
            // 
            this.lbl_stat12.BackColor = System.Drawing.Color.Transparent;
            this.lbl_stat12.Font = new System.Drawing.Font("Georgia", 12F);
            this.lbl_stat12.ForeColor = System.Drawing.Color.White;
            this.lbl_stat12.Location = new System.Drawing.Point(12, 354);
            this.lbl_stat12.Name = "lbl_stat12";
            this.lbl_stat12.Size = new System.Drawing.Size(337, 20);
            this.lbl_stat12.TabIndex = 117;
            // 
            // lbl_stat13
            // 
            this.lbl_stat13.BackColor = System.Drawing.Color.Transparent;
            this.lbl_stat13.Font = new System.Drawing.Font("Georgia", 12F);
            this.lbl_stat13.ForeColor = System.Drawing.Color.White;
            this.lbl_stat13.Location = new System.Drawing.Point(12, 374);
            this.lbl_stat13.Name = "lbl_stat13";
            this.lbl_stat13.Size = new System.Drawing.Size(337, 20);
            this.lbl_stat13.TabIndex = 118;
            // 
            // lbl_stat14
            // 
            this.lbl_stat14.BackColor = System.Drawing.Color.Transparent;
            this.lbl_stat14.Font = new System.Drawing.Font("Georgia", 12F);
            this.lbl_stat14.ForeColor = System.Drawing.Color.White;
            this.lbl_stat14.Location = new System.Drawing.Point(12, 394);
            this.lbl_stat14.Name = "lbl_stat14";
            this.lbl_stat14.Size = new System.Drawing.Size(337, 20);
            this.lbl_stat14.TabIndex = 119;
            // 
            // lbl_stat15
            // 
            this.lbl_stat15.BackColor = System.Drawing.Color.Transparent;
            this.lbl_stat15.Font = new System.Drawing.Font("Georgia", 12F);
            this.lbl_stat15.ForeColor = System.Drawing.Color.White;
            this.lbl_stat15.Location = new System.Drawing.Point(12, 414);
            this.lbl_stat15.Name = "lbl_stat15";
            this.lbl_stat15.Size = new System.Drawing.Size(337, 20);
            this.lbl_stat15.TabIndex = 120;
            // 
            // lbl_stat16
            // 
            this.lbl_stat16.BackColor = System.Drawing.Color.Transparent;
            this.lbl_stat16.Font = new System.Drawing.Font("Georgia", 12F);
            this.lbl_stat16.ForeColor = System.Drawing.Color.White;
            this.lbl_stat16.Location = new System.Drawing.Point(12, 434);
            this.lbl_stat16.Name = "lbl_stat16";
            this.lbl_stat16.Size = new System.Drawing.Size(337, 20);
            this.lbl_stat16.TabIndex = 121;
            // 
            // label4
            // 
            this.label4.Location = new System.Drawing.Point(388, 101);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(98, 20);
            this.label4.TabIndex = 122;
            this.label4.Text = "Durability Max";
            this.label4.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // txt_durability
            // 
            this.txt_durability.Location = new System.Drawing.Point(488, 101);
            this.txt_durability.Name = "txt_durability";
            this.txt_durability.Size = new System.Drawing.Size(91, 23);
            this.txt_durability.TabIndex = 123;
            this.txt_durability.Text = "255";
            this.txt_durability.TextChanged += new System.EventHandler(this.txt_durability_TextChanged);
            // 
            // txt_level
            // 
            this.txt_level.Location = new System.Drawing.Point(436, 130);
            this.txt_level.Name = "txt_level";
            this.txt_level.Size = new System.Drawing.Size(143, 23);
            this.txt_level.TabIndex = 124;
            this.txt_level.Text = "65";
            this.txt_level.TextChanged += new System.EventHandler(this.txt_level_TextChanged);
            // 
            // label5
            // 
            this.label5.Location = new System.Drawing.Point(387, 130);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(43, 20);
            this.label5.TabIndex = 125;
            this.label5.Text = "Level";
            this.label5.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // c_showline
            // 
            this.c_showline.AutoSize = true;
            this.c_showline.Location = new System.Drawing.Point(387, 295);
            this.c_showline.Name = "c_showline";
            this.c_showline.Size = new System.Drawing.Size(92, 19);
            this.c_showline.TabIndex = 126;
            this.c_showline.Text = "Show Lines";
            this.c_showline.UseVisualStyleBackColor = true;
            this.c_showline.CheckedChanged += new System.EventHandler(this.c_showline_CheckedChanged);
            // 
            // txt_stat
            // 
            this.txt_stat.Location = new System.Drawing.Point(387, 351);
            this.txt_stat.Name = "txt_stat";
            this.txt_stat.Size = new System.Drawing.Size(201, 23);
            this.txt_stat.TabIndex = 127;
            this.txt_stat.TextChanged += new System.EventHandler(this.txt_stat_TextChanged);
            // 
            // lbl_line
            // 
            this.lbl_line.Location = new System.Drawing.Point(388, 328);
            this.lbl_line.Name = "lbl_line";
            this.lbl_line.Size = new System.Drawing.Size(98, 20);
            this.lbl_line.TabIndex = 128;
            this.lbl_line.Text = "Line: 1";
            this.lbl_line.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // label6
            // 
            this.label6.Location = new System.Drawing.Point(388, 23);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(46, 20);
            this.label6.TabIndex = 130;
            this.label6.Text = "ID";
            this.label6.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // txt_id
            // 
            this.txt_id.Location = new System.Drawing.Point(447, 20);
            this.txt_id.Name = "txt_id";
            this.txt_id.Size = new System.Drawing.Size(132, 23);
            this.txt_id.TabIndex = 129;
            this.txt_id.Text = "1";
            // 
            // label7
            // 
            this.label7.Location = new System.Drawing.Point(388, 46);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(53, 20);
            this.label7.TabIndex = 132;
            this.label7.Text = "Icon ID";
            this.label7.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // txt_icon
            // 
            this.txt_icon.Location = new System.Drawing.Point(447, 46);
            this.txt_icon.Name = "txt_icon";
            this.txt_icon.Size = new System.Drawing.Size(132, 23);
            this.txt_icon.TabIndex = 131;
            this.txt_icon.Text = "1";
            // 
            // ItemForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.SystemColors.Control;
            this.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("$this.BackgroundImage")));
            this.BackgroundImageLayout = System.Windows.Forms.ImageLayout.None;
            this.ClientSize = new System.Drawing.Size(605, 561);
            this.Controls.Add(this.label7);
            this.Controls.Add(this.txt_icon);
            this.Controls.Add(this.label6);
            this.Controls.Add(this.txt_id);
            this.Controls.Add(this.lbl_line);
            this.Controls.Add(this.txt_stat);
            this.Controls.Add(this.c_showline);
            this.Controls.Add(this.c_soul);
            this.Controls.Add(this.c_trade);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.txt_level);
            this.Controls.Add(this.txt_durability);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.cmb_type);
            this.Controls.Add(this.cmb_hand);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.lbl_stat16);
            this.Controls.Add(this.cmb_rarity);
            this.Controls.Add(this.lbl_stat15);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.lbl_stat14);
            this.Controls.Add(this.lbl_stat13);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.lbl_stat12);
            this.Controls.Add(this.lbl_stat11);
            this.Controls.Add(this.lbl_stat10);
            this.Controls.Add(this.lbl_stat9);
            this.Controls.Add(this.lbl_stat8);
            this.Controls.Add(this.lbl_stat7);
            this.Controls.Add(this.lbl_stat6);
            this.Controls.Add(this.lbl_stat5);
            this.Controls.Add(this.lbl_stat4);
            this.Controls.Add(this.lbl_stat3);
            this.Controls.Add(this.lbl_stat2);
            this.Controls.Add(this.lbl_stat1);
            this.Controls.Add(this.lbl_tradeable);
            this.Controls.Add(this.lbl_bound);
            this.Controls.Add(this.lbl_level);
            this.Controls.Add(this.lbl_hand);
            this.Controls.Add(this.lbl_durability);
            this.Controls.Add(this.lbl_rarity);
            this.Controls.Add(this.lbl_type);
            this.Controls.Add(this.lbl_name);
            this.Controls.Add(this.btn_open);
            this.Controls.Add(this.btn_save);
            this.Controls.Add(this.label12);
            this.Controls.Add(this.txt_name);
            this.Font = new System.Drawing.Font("Meiryo UI", 9F);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.KeyPreview = true;
            this.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.MaximizeBox = false;
            this.Name = "ItemForm";
            this.Text = "Item Editor";
            this.Load += new System.EventHandler(this.ItemForm_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.ComboBox cmb_type;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.CheckBox c_trade;
        private System.Windows.Forms.CheckBox c_soul;
        private System.Windows.Forms.ComboBox cmb_hand;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.ComboBox cmb_rarity;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label12;
        private System.Windows.Forms.TextBox txt_name;
        private System.Windows.Forms.Button btn_save;
        private System.Windows.Forms.Button btn_open;
        private System.Windows.Forms.Label lbl_name;
        private System.Windows.Forms.Label lbl_type;
        private System.Windows.Forms.Label lbl_rarity;
        private System.Windows.Forms.Label lbl_durability;
        private System.Windows.Forms.Label lbl_hand;
        private System.Windows.Forms.Label lbl_level;
        private System.Windows.Forms.Label lbl_bound;
        private System.Windows.Forms.Label lbl_tradeable;
        private System.Windows.Forms.Label lbl_stat1;
        private System.Windows.Forms.Label lbl_stat2;
        private System.Windows.Forms.Label lbl_stat3;
        private System.Windows.Forms.Label lbl_stat4;
        private System.Windows.Forms.Label lbl_stat5;
        private System.Windows.Forms.Label lbl_stat6;
        private System.Windows.Forms.Label lbl_stat7;
        private System.Windows.Forms.Label lbl_stat8;
        private System.Windows.Forms.Label lbl_stat9;
        private System.Windows.Forms.Label lbl_stat10;
        private System.Windows.Forms.Label lbl_stat11;
        private System.Windows.Forms.Label lbl_stat12;
        private System.Windows.Forms.Label lbl_stat13;
        private System.Windows.Forms.Label lbl_stat14;
        private System.Windows.Forms.Label lbl_stat15;
        private System.Windows.Forms.Label lbl_stat16;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.TextBox txt_durability;
        private System.Windows.Forms.TextBox txt_level;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.CheckBox c_showline;
        private System.Windows.Forms.TextBox txt_stat;
        private System.Windows.Forms.Label lbl_line;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.TextBox txt_id;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.TextBox txt_icon;
    }
}