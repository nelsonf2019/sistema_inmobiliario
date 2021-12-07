namespace WindowsFormsApp9
{
    partial class Form1
    {
        /// <summary>
        /// Variable del diseñador necesaria.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Limpiar los recursos que se estén usando.
        /// </summary>
        /// <param name="disposing">true si los recursos administrados se deben desechar; false en caso contrario.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Código generado por el Diseñador de Windows Forms

        /// <summary>
        /// Método necesario para admitir el Diseñador. No se puede modificar
        /// el contenido de este método con el editor de código.
        /// </summary>
        private void InitializeComponent()
        {
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Form1));
            this.MenuVertical = new System.Windows.Forms.Panel();
            this.button3 = new System.Windows.Forms.Button();
            this.label2 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.button2 = new System.Windows.Forms.Button();
            this.button1 = new System.Windows.Forms.Button();
            this.btnClients = new System.Windows.Forms.Button();
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            this.BarraTitulo = new System.Windows.Forms.Panel();
            this.PctMaximize = new System.Windows.Forms.PictureBox();
            this.PctRestore = new System.Windows.Forms.PictureBox();
            this.PctClose = new System.Windows.Forms.PictureBox();
            this.pctMinimize = new System.Windows.Forms.PictureBox();
            this.btnSlide = new System.Windows.Forms.PictureBox();
            this.pnlContainer = new System.Windows.Forms.Panel();
            this.MenuVertical.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            this.BarraTitulo.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.PctMaximize)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.PctRestore)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.PctClose)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pctMinimize)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.btnSlide)).BeginInit();
            this.SuspendLayout();
            // 
            // MenuVertical
            // 
            this.MenuVertical.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(122)))), ((int)(((byte)(204)))));
            this.MenuVertical.Controls.Add(this.button3);
            this.MenuVertical.Controls.Add(this.label2);
            this.MenuVertical.Controls.Add(this.label1);
            this.MenuVertical.Controls.Add(this.button2);
            this.MenuVertical.Controls.Add(this.button1);
            this.MenuVertical.Controls.Add(this.btnClients);
            this.MenuVertical.Controls.Add(this.pictureBox1);
            this.MenuVertical.Dock = System.Windows.Forms.DockStyle.Left;
            this.MenuVertical.Location = new System.Drawing.Point(0, 0);
            this.MenuVertical.Name = "MenuVertical";
            this.MenuVertical.Size = new System.Drawing.Size(250, 650);
            this.MenuVertical.TabIndex = 0;
            // 
            // button3
            // 
            this.button3.FlatAppearance.BorderSize = 0;
            this.button3.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.button3.Font = new System.Drawing.Font("Century Gothic", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.button3.ForeColor = System.Drawing.Color.White;
            this.button3.Image = global::WindowsFormsApp9.Properties.Resources._event;
            this.button3.ImageAlign = System.Drawing.ContentAlignment.TopLeft;
            this.button3.Location = new System.Drawing.Point(0, 228);
            this.button3.Name = "button3";
            this.button3.Size = new System.Drawing.Size(250, 72);
            this.button3.TabIndex = 6;
            this.button3.Text = "Agenda";
            this.button3.UseVisualStyleBackColor = true;
            this.button3.Click += new System.EventHandler(this.button3_Click);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Century Gothic", 11.25F);
            this.label2.ForeColor = System.Drawing.Color.White;
            this.label2.Location = new System.Drawing.Point(107, 49);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(92, 20);
            this.label2.TabIndex = 7;
            this.label2.Text = "FERNANDEZ";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Century Gothic", 11.25F);
            this.label1.ForeColor = System.Drawing.Color.White;
            this.label1.Location = new System.Drawing.Point(107, 20);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(119, 20);
            this.label1.TabIndex = 0;
            this.label1.Text = "INMOBILIARIA ";
            // 
            // button2
            // 
            this.button2.FlatAppearance.BorderSize = 0;
            this.button2.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.button2.Font = new System.Drawing.Font("Century Gothic", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.button2.ForeColor = System.Drawing.Color.White;
            this.button2.Image = global::WindowsFormsApp9.Properties.Resources.home;
            this.button2.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.button2.Location = new System.Drawing.Point(0, 373);
            this.button2.Name = "button2";
            this.button2.Size = new System.Drawing.Size(250, 61);
            this.button2.TabIndex = 5;
            this.button2.Text = "Propiedades";
            this.button2.UseVisualStyleBackColor = true;
            this.button2.Click += new System.EventHandler(this.button2_Click);
            // 
            // button1
            // 
            this.button1.FlatAppearance.BorderSize = 0;
            this.button1.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.button1.Font = new System.Drawing.Font("Century Gothic", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.button1.ForeColor = System.Drawing.Color.White;
            this.button1.Image = global::WindowsFormsApp9.Properties.Resources.house;
            this.button1.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.button1.Location = new System.Drawing.Point(-3, 306);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(256, 61);
            this.button1.TabIndex = 4;
            this.button1.Text = "Alquileres";
            this.button1.UseVisualStyleBackColor = true;
            // 
            // btnClients
            // 
            this.btnClients.FlatAppearance.BorderSize = 0;
            this.btnClients.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnClients.Font = new System.Drawing.Font("Century Gothic", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnClients.ForeColor = System.Drawing.Color.White;
            this.btnClients.Image = global::WindowsFormsApp9.Properties.Resources.marketing__2_;
            this.btnClients.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnClients.Location = new System.Drawing.Point(0, 146);
            this.btnClients.Name = "btnClients";
            this.btnClients.Size = new System.Drawing.Size(247, 76);
            this.btnClients.TabIndex = 3;
            this.btnClients.Text = "Clientes";
            this.btnClients.UseVisualStyleBackColor = true;
            this.btnClients.Click += new System.EventHandler(this.btnClients_Click);
            // 
            // pictureBox1
            // 
            this.pictureBox1.Image = ((System.Drawing.Image)(resources.GetObject("pictureBox1.Image")));
            this.pictureBox1.Location = new System.Drawing.Point(0, 9);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(80, 64);
            this.pictureBox1.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.pictureBox1.TabIndex = 0;
            this.pictureBox1.TabStop = false;
            // 
            // BarraTitulo
            // 
            this.BarraTitulo.BackColor = System.Drawing.Color.WhiteSmoke;
            this.BarraTitulo.Controls.Add(this.PctMaximize);
            this.BarraTitulo.Controls.Add(this.PctRestore);
            this.BarraTitulo.Controls.Add(this.PctClose);
            this.BarraTitulo.Controls.Add(this.pctMinimize);
            this.BarraTitulo.Controls.Add(this.btnSlide);
            this.BarraTitulo.Cursor = System.Windows.Forms.Cursors.Hand;
            this.BarraTitulo.Dock = System.Windows.Forms.DockStyle.Top;
            this.BarraTitulo.Location = new System.Drawing.Point(250, 0);
            this.BarraTitulo.Name = "BarraTitulo";
            this.BarraTitulo.Size = new System.Drawing.Size(1050, 50);
            this.BarraTitulo.TabIndex = 1;
            this.BarraTitulo.MouseDown += new System.Windows.Forms.MouseEventHandler(this.BarraTitulo_MouseDown);
            // 
            // PctMaximize
            // 
            this.PctMaximize.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.PctMaximize.Cursor = System.Windows.Forms.Cursors.Hand;
            this.PctMaximize.Image = global::WindowsFormsApp9.Properties.Resources.maximize;
            this.PctMaximize.Location = new System.Drawing.Point(991, 3);
            this.PctMaximize.Name = "PctMaximize";
            this.PctMaximize.Size = new System.Drawing.Size(25, 25);
            this.PctMaximize.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.PctMaximize.TabIndex = 1;
            this.PctMaximize.TabStop = false;
            this.PctMaximize.Click += new System.EventHandler(this.PctMaximize_Click);
            // 
            // PctRestore
            // 
            this.PctRestore.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.PctRestore.Cursor = System.Windows.Forms.Cursors.Hand;
            this.PctRestore.Image = global::WindowsFormsApp9.Properties.Resources.restore;
            this.PctRestore.Location = new System.Drawing.Point(991, 3);
            this.PctRestore.Name = "PctRestore";
            this.PctRestore.Size = new System.Drawing.Size(25, 25);
            this.PctRestore.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.PctRestore.TabIndex = 2;
            this.PctRestore.TabStop = false;
            this.PctRestore.Visible = false;
            this.PctRestore.Click += new System.EventHandler(this.PctRestore_Click);
            // 
            // PctClose
            // 
            this.PctClose.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.PctClose.Cursor = System.Windows.Forms.Cursors.Hand;
            this.PctClose.Image = global::WindowsFormsApp9.Properties.Resources.cancel;
            this.PctClose.Location = new System.Drawing.Point(1022, 3);
            this.PctClose.Name = "PctClose";
            this.PctClose.Size = new System.Drawing.Size(25, 25);
            this.PctClose.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.PctClose.TabIndex = 3;
            this.PctClose.TabStop = false;
            this.PctClose.Click += new System.EventHandler(this.pictureBox4_Click);
            // 
            // pctMinimize
            // 
            this.pctMinimize.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.pctMinimize.Cursor = System.Windows.Forms.Cursors.Hand;
            this.pctMinimize.Image = global::WindowsFormsApp9.Properties.Resources.minimize;
            this.pctMinimize.Location = new System.Drawing.Point(960, 3);
            this.pctMinimize.Name = "pctMinimize";
            this.pctMinimize.Size = new System.Drawing.Size(25, 25);
            this.pctMinimize.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.pctMinimize.TabIndex = 4;
            this.pctMinimize.TabStop = false;
            this.pctMinimize.Click += new System.EventHandler(this.pctMinimize_Click);
            // 
            // btnSlide
            // 
            this.btnSlide.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnSlide.Image = ((System.Drawing.Image)(resources.GetObject("btnSlide.Image")));
            this.btnSlide.Location = new System.Drawing.Point(6, 9);
            this.btnSlide.Name = "btnSlide";
            this.btnSlide.Size = new System.Drawing.Size(35, 35);
            this.btnSlide.TabIndex = 0;
            this.btnSlide.TabStop = false;
            this.btnSlide.Click += new System.EventHandler(this.btnSlide_Click);
            // 
            // pnlContainer
            // 
            this.pnlContainer.Dock = System.Windows.Forms.DockStyle.Fill;
            this.pnlContainer.Location = new System.Drawing.Point(250, 50);
            this.pnlContainer.Name = "pnlContainer";
            this.pnlContainer.Size = new System.Drawing.Size(1050, 600);
            this.pnlContainer.TabIndex = 2;
            this.pnlContainer.Paint += new System.Windows.Forms.PaintEventHandler(this.pnlContainer_Paint);
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.AutoSize = true;
            this.ClientSize = new System.Drawing.Size(1300, 650);
            this.Controls.Add(this.pnlContainer);
            this.Controls.Add(this.BarraTitulo);
            this.Controls.Add(this.MenuVertical);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Name = "Form1";
            this.Text = "Form1";
            this.MenuVertical.ResumeLayout(false);
            this.MenuVertical.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            this.BarraTitulo.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.PctMaximize)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.PctRestore)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.PctClose)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pctMinimize)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.btnSlide)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel MenuVertical;
        private System.Windows.Forms.Panel BarraTitulo;
        private System.Windows.Forms.PictureBox btnSlide;
        private System.Windows.Forms.PictureBox pictureBox1;
        private System.Windows.Forms.PictureBox PctRestore;
        private System.Windows.Forms.PictureBox PctClose;
        private System.Windows.Forms.PictureBox pctMinimize;
        private System.Windows.Forms.PictureBox PctMaximize;
        private System.Windows.Forms.Button btnClients;
        private System.Windows.Forms.Button button2;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.Button button3;
        private System.Windows.Forms.Panel pnlContainer;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label1;
    }
}

