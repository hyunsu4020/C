namespace AnimalShop
{
    partial class Form1
    {
        /// <summary>
        /// 필수 디자이너 변수입니다.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// 사용 중인 모든 리소스를 정리합니다.
        /// </summary>
        /// <param name="disposing">관리되는 리소스를 삭제해야 하면 true이고, 그렇지 않으면 false입니다.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form 디자이너에서 생성한 코드

        /// <summary>
        /// 디자이너 지원에 필요한 메서드입니다. 
        /// 이 메서드의 내용을 코드 편집기로 수정하지 마세요.
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            this.button3 = new System.Windows.Forms.Button();
            this.button2 = new System.Windows.Forms.Button();
            this.button1 = new System.Windows.Forms.Button();
            this.textBox3 = new System.Windows.Forms.TextBox();
            this.textBox2 = new System.Windows.Forms.TextBox();
            this.textBox1 = new System.Windows.Forms.TextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.menuStrip1 = new System.Windows.Forms.MenuStrip();
            this.애완동물정보ToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.animalShopDataSet = new AnimalShop.AnimalShopDataSet();
            this.tbShopBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.tbShopTableAdapter = new AnimalShop.AnimalShopDataSetTableAdapters.tbShopTableAdapter();
            this.animalShopDataSet2 = new AnimalShop.AnimalShopDataSet2();
            this.tbShopBindingSource1 = new System.Windows.Forms.BindingSource(this.components);
            this.tbShopTableAdapter1 = new AnimalShop.AnimalShopDataSet2TableAdapters.tbShopTableAdapter();
            this.animalShopDataSet3 = new AnimalShop.AnimalShopDataSet3();
            this.tbShopBindingSource2 = new System.Windows.Forms.BindingSource(this.components);
            this.tbShopTableAdapter2 = new AnimalShop.AnimalShopDataSet3TableAdapters.tbShopTableAdapter();
            this.dataGridView1 = new System.Windows.Forms.DataGridView();
            this.idDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.nameDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.priceDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.button4 = new System.Windows.Forms.Button();
            this.구매내역ToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.button5 = new System.Windows.Forms.Button();
            this.menuStrip1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.animalShopDataSet)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.tbShopBindingSource)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.animalShopDataSet2)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.tbShopBindingSource1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.animalShopDataSet3)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.tbShopBindingSource2)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).BeginInit();
            this.SuspendLayout();
            // 
            // button3
            // 
            this.button3.Font = new System.Drawing.Font("맑은 고딕", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.button3.Location = new System.Drawing.Point(290, 389);
            this.button3.Name = "button3";
            this.button3.Size = new System.Drawing.Size(79, 33);
            this.button3.TabIndex = 32;
            this.button3.Text = "삭 제";
            this.button3.UseVisualStyleBackColor = true;
            this.button3.Click += new System.EventHandler(this.button3_Click);
            // 
            // button2
            // 
            this.button2.Font = new System.Drawing.Font("맑은 고딕", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.button2.Location = new System.Drawing.Point(164, 389);
            this.button2.Name = "button2";
            this.button2.Size = new System.Drawing.Size(79, 33);
            this.button2.TabIndex = 31;
            this.button2.Text = "수 정";
            this.button2.UseVisualStyleBackColor = true;
            this.button2.Click += new System.EventHandler(this.button2_Click);
            // 
            // button1
            // 
            this.button1.Font = new System.Drawing.Font("맑은 고딕", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.button1.Location = new System.Drawing.Point(50, 389);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(76, 33);
            this.button1.TabIndex = 30;
            this.button1.Text = "등 록";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // textBox3
            // 
            this.textBox3.Font = new System.Drawing.Font("맑은 고딕", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.textBox3.Location = new System.Drawing.Point(164, 163);
            this.textBox3.Name = "textBox3";
            this.textBox3.Size = new System.Drawing.Size(250, 34);
            this.textBox3.TabIndex = 28;
            // 
            // textBox2
            // 
            this.textBox2.Font = new System.Drawing.Font("맑은 고딕", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.textBox2.Location = new System.Drawing.Point(164, 119);
            this.textBox2.Name = "textBox2";
            this.textBox2.Size = new System.Drawing.Size(250, 34);
            this.textBox2.TabIndex = 27;
            // 
            // textBox1
            // 
            this.textBox1.Font = new System.Drawing.Font("맑은 고딕", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.textBox1.Location = new System.Drawing.Point(164, 73);
            this.textBox1.Name = "textBox1";
            this.textBox1.Size = new System.Drawing.Size(250, 34);
            this.textBox1.TabIndex = 26;
            this.textBox1.Click += new System.EventHandler(this.textBox1_Click);
            this.textBox1.TextChanged += new System.EventHandler(this.textBox1_TextChanged);
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("맑은 고딕", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.label3.Location = new System.Drawing.Point(45, 166);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(87, 28);
            this.label3.TabIndex = 25;
            this.label3.Text = "  가   격";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("맑은 고딕", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.label2.Location = new System.Drawing.Point(45, 120);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(99, 28);
            this.label2.TabIndex = 24;
            this.label2.Text = "동물 이름";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("맑은 고딕", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.label1.Location = new System.Drawing.Point(45, 73);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(99, 28);
            this.label1.TabIndex = 23;
            this.label1.Text = "동물 번호";
            // 
            // menuStrip1
            // 
            this.menuStrip1.ImageScalingSize = new System.Drawing.Size(20, 20);
            this.menuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.애완동물정보ToolStripMenuItem,
            this.구매내역ToolStripMenuItem});
            this.menuStrip1.Location = new System.Drawing.Point(0, 0);
            this.menuStrip1.Name = "menuStrip1";
            this.menuStrip1.Size = new System.Drawing.Size(687, 28);
            this.menuStrip1.TabIndex = 33;
            this.menuStrip1.Text = "menuStrip1";
            // 
            // 애완동물정보ToolStripMenuItem
            // 
            this.애완동물정보ToolStripMenuItem.Name = "애완동물정보ToolStripMenuItem";
            this.애완동물정보ToolStripMenuItem.Size = new System.Drawing.Size(118, 24);
            this.애완동물정보ToolStripMenuItem.Text = "애완동물 구입";
            this.애완동물정보ToolStripMenuItem.Click += new System.EventHandler(this.애완동물정보ToolStripMenuItem_Click);
            // 
            // animalShopDataSet
            // 
            this.animalShopDataSet.DataSetName = "AnimalShopDataSet";
            this.animalShopDataSet.SchemaSerializationMode = System.Data.SchemaSerializationMode.IncludeSchema;
            // 
            // tbShopBindingSource
            // 
            this.tbShopBindingSource.DataMember = "tbShop";
            this.tbShopBindingSource.DataSource = this.animalShopDataSet;
            // 
            // tbShopTableAdapter
            // 
            this.tbShopTableAdapter.ClearBeforeFill = true;
            // 
            // animalShopDataSet2
            // 
            this.animalShopDataSet2.DataSetName = "AnimalShopDataSet2";
            this.animalShopDataSet2.SchemaSerializationMode = System.Data.SchemaSerializationMode.IncludeSchema;
            // 
            // tbShopBindingSource1
            // 
            this.tbShopBindingSource1.DataMember = "tbShop";
            this.tbShopBindingSource1.DataSource = this.animalShopDataSet2;
            // 
            // tbShopTableAdapter1
            // 
            this.tbShopTableAdapter1.ClearBeforeFill = true;
            // 
            // animalShopDataSet3
            // 
            this.animalShopDataSet3.DataSetName = "AnimalShopDataSet3";
            this.animalShopDataSet3.SchemaSerializationMode = System.Data.SchemaSerializationMode.IncludeSchema;
            // 
            // tbShopBindingSource2
            // 
            this.tbShopBindingSource2.DataMember = "tbShop";
            this.tbShopBindingSource2.DataSource = this.animalShopDataSet3;
            // 
            // tbShopTableAdapter2
            // 
            this.tbShopTableAdapter2.ClearBeforeFill = true;
            // 
            // dataGridView1
            // 
            this.dataGridView1.AutoGenerateColumns = false;
            this.dataGridView1.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridView1.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.idDataGridViewTextBoxColumn,
            this.nameDataGridViewTextBoxColumn,
            this.priceDataGridViewTextBoxColumn});
            this.dataGridView1.DataSource = this.tbShopBindingSource2;
            this.dataGridView1.Location = new System.Drawing.Point(50, 220);
            this.dataGridView1.Name = "dataGridView1";
            this.dataGridView1.RowHeadersWidth = 51;
            this.dataGridView1.RowTemplate.Height = 27;
            this.dataGridView1.Size = new System.Drawing.Size(442, 150);
            this.dataGridView1.TabIndex = 34;
            // 
            // idDataGridViewTextBoxColumn
            // 
            this.idDataGridViewTextBoxColumn.DataPropertyName = "Id";
            this.idDataGridViewTextBoxColumn.HeaderText = "Id";
            this.idDataGridViewTextBoxColumn.MinimumWidth = 6;
            this.idDataGridViewTextBoxColumn.Name = "idDataGridViewTextBoxColumn";
            this.idDataGridViewTextBoxColumn.Width = 125;
            // 
            // nameDataGridViewTextBoxColumn
            // 
            this.nameDataGridViewTextBoxColumn.DataPropertyName = "name";
            this.nameDataGridViewTextBoxColumn.HeaderText = "name";
            this.nameDataGridViewTextBoxColumn.MinimumWidth = 6;
            this.nameDataGridViewTextBoxColumn.Name = "nameDataGridViewTextBoxColumn";
            this.nameDataGridViewTextBoxColumn.Width = 125;
            // 
            // priceDataGridViewTextBoxColumn
            // 
            this.priceDataGridViewTextBoxColumn.DataPropertyName = "price";
            this.priceDataGridViewTextBoxColumn.HeaderText = "price";
            this.priceDataGridViewTextBoxColumn.MinimumWidth = 6;
            this.priceDataGridViewTextBoxColumn.Name = "priceDataGridViewTextBoxColumn";
            this.priceDataGridViewTextBoxColumn.Width = 125;
            // 
            // button4
            // 
            this.button4.Font = new System.Drawing.Font("맑은 고딕", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.button4.Location = new System.Drawing.Point(420, 74);
            this.button4.Name = "button4";
            this.button4.Size = new System.Drawing.Size(72, 33);
            this.button4.TabIndex = 35;
            this.button4.Text = "조 회";
            this.button4.UseVisualStyleBackColor = true;
            this.button4.Click += new System.EventHandler(this.button4_Click);
            // 
            // 구매내역ToolStripMenuItem
            // 
            this.구매내역ToolStripMenuItem.Name = "구매내역ToolStripMenuItem";
            this.구매내역ToolStripMenuItem.Size = new System.Drawing.Size(83, 24);
            this.구매내역ToolStripMenuItem.Text = "구매내역";
            this.구매내역ToolStripMenuItem.Click += new System.EventHandler(this.구매내역ToolStripMenuItem_Click);
            // 
            // button5
            // 
            this.button5.Font = new System.Drawing.Font("맑은 고딕", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.button5.Location = new System.Drawing.Point(413, 389);
            this.button5.Name = "button5";
            this.button5.Size = new System.Drawing.Size(79, 33);
            this.button5.TabIndex = 36;
            this.button5.Text = "종 료";
            this.button5.UseVisualStyleBackColor = true;
            this.button5.Click += new System.EventHandler(this.button5_Click);
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(687, 450);
            this.Controls.Add(this.button5);
            this.Controls.Add(this.button4);
            this.Controls.Add(this.dataGridView1);
            this.Controls.Add(this.button3);
            this.Controls.Add(this.button2);
            this.Controls.Add(this.button1);
            this.Controls.Add(this.textBox3);
            this.Controls.Add(this.textBox2);
            this.Controls.Add(this.textBox1);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.menuStrip1);
            this.Name = "Form1";
            this.Text = "애완동물 가게";
            this.Load += new System.EventHandler(this.Form1_Load);
            this.menuStrip1.ResumeLayout(false);
            this.menuStrip1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.animalShopDataSet)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.tbShopBindingSource)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.animalShopDataSet2)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.tbShopBindingSource1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.animalShopDataSet3)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.tbShopBindingSource2)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button button3;
        private System.Windows.Forms.Button button2;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.TextBox textBox3;
        private System.Windows.Forms.TextBox textBox2;
        private System.Windows.Forms.TextBox textBox1;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.MenuStrip menuStrip1;
        private AnimalShopDataSet animalShopDataSet;
        private System.Windows.Forms.BindingSource tbShopBindingSource;
        private AnimalShopDataSetTableAdapters.tbShopTableAdapter tbShopTableAdapter;
        private System.Windows.Forms.ToolStripMenuItem 애완동물정보ToolStripMenuItem;
        private AnimalShopDataSet2 animalShopDataSet2;
        private System.Windows.Forms.BindingSource tbShopBindingSource1;
        private AnimalShopDataSet2TableAdapters.tbShopTableAdapter tbShopTableAdapter1;
        private AnimalShopDataSet3 animalShopDataSet3;
        private System.Windows.Forms.BindingSource tbShopBindingSource2;
        private AnimalShopDataSet3TableAdapters.tbShopTableAdapter tbShopTableAdapter2;
        private System.Windows.Forms.DataGridView dataGridView1;
        private System.Windows.Forms.DataGridViewTextBoxColumn idDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn nameDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn priceDataGridViewTextBoxColumn;
        private System.Windows.Forms.Button button4;
        private System.Windows.Forms.ToolStripMenuItem 구매내역ToolStripMenuItem;
        private System.Windows.Forms.Button button5;
    }
}

