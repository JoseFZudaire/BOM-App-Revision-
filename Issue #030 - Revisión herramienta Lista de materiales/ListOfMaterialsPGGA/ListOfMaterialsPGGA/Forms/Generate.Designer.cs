﻿namespace ListOfMaterialsPGGA
{
    partial class Generate
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
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle1 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle2 = new System.Windows.Forms.DataGridViewCellStyle();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Generate));
            this.label1 = new System.Windows.Forms.Label();
            this.dataGridView1 = new System.Windows.Forms.DataGridView();
            this.Archivo = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Ubicacion = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Cantidad = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Status = new System.Windows.Forms.DataGridViewImageColumn();
            this.bt_add = new System.Windows.Forms.Button();
            this.bt_del = new System.Windows.Forms.Button();
            this.bt_up = new System.Windows.Forms.Button();
            this.bt_down = new System.Windows.Forms.Button();
            this.bt_generate = new System.Windows.Forms.Button();
            this.bt_save = new System.Windows.Forms.Button();
            this.tb_save = new System.Windows.Forms.TextBox();
            this.lb_save = new System.Windows.Forms.Label();
            this.mensaje = new System.Windows.Forms.StatusStrip();
            this.st_label = new System.Windows.Forms.ToolStripStatusLabel();
            this.toolStripStatusLabel1 = new System.Windows.Forms.ToolStripStatusLabel();
            this.label2 = new System.Windows.Forms.Label();
            this.tb_path = new System.Windows.Forms.TextBox();
            this.bt_out_open = new System.Windows.Forms.Button();
            this.picbox_save = new System.Windows.Forms.PictureBox();
            this.button1 = new System.Windows.Forms.Button();
            this.pictureBox2 = new System.Windows.Forms.PictureBox();
            this.label6 = new System.Windows.Forms.Label();
            this.tb_template = new System.Windows.Forms.TextBox();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).BeginInit();
            this.mensaje.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.picbox_save)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox2)).BeginInit();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(88, 63);
            this.label1.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(266, 13);
            this.label1.TabIndex = 0;
            this.label1.Text = "Listado de documentos BillofMaterials en formato Excel";
            // 
            // dataGridView1
            // 
            this.dataGridView1.AllowUserToAddRows = false;
            this.dataGridView1.AllowUserToDeleteRows = false;
            this.dataGridView1.AllowUserToOrderColumns = true;
            this.dataGridView1.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            dataGridViewCellStyle1.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle1.BackColor = System.Drawing.SystemColors.Control;
            dataGridViewCellStyle1.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle1.ForeColor = System.Drawing.SystemColors.WindowText;
            dataGridViewCellStyle1.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle1.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle1.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.dataGridView1.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle1;
            this.dataGridView1.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridView1.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.Archivo,
            this.Ubicacion,
            this.Cantidad,
            this.Status});
            dataGridViewCellStyle2.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle2.BackColor = System.Drawing.SystemColors.Window;
            dataGridViewCellStyle2.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle2.ForeColor = System.Drawing.SystemColors.ControlText;
            dataGridViewCellStyle2.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle2.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle2.WrapMode = System.Windows.Forms.DataGridViewTriState.False;
            this.dataGridView1.DefaultCellStyle = dataGridViewCellStyle2;
            this.dataGridView1.Location = new System.Drawing.Point(88, 84);
            this.dataGridView1.Margin = new System.Windows.Forms.Padding(2);
            this.dataGridView1.Name = "dataGridView1";
            this.dataGridView1.ReadOnly = true;
            this.dataGridView1.RowHeadersWidth = 62;
            this.dataGridView1.RowTemplate.Height = 24;
            this.dataGridView1.Size = new System.Drawing.Size(845, 223);
            this.dataGridView1.TabIndex = 1;
            // 
            // Archivo
            // 
            this.Archivo.HeaderText = "Archivo";
            this.Archivo.MinimumWidth = 100;
            this.Archivo.Name = "Archivo";
            this.Archivo.ReadOnly = true;
            this.Archivo.Width = 300;
            // 
            // Ubicacion
            // 
            this.Ubicacion.HeaderText = "Ubicacion";
            this.Ubicacion.MinimumWidth = 100;
            this.Ubicacion.Name = "Ubicacion";
            this.Ubicacion.ReadOnly = true;
            this.Ubicacion.Width = 500;
            // 
            // Cantidad
            // 
            this.Cantidad.HeaderText = "Cantidad";
            this.Cantidad.MinimumWidth = 20;
            this.Cantidad.Name = "Cantidad";
            this.Cantidad.ReadOnly = true;
            this.Cantidad.Width = 70;
            // 
            // Status
            // 
            this.Status.HeaderText = "Status";
            this.Status.MinimumWidth = 50;
            this.Status.Name = "Status";
            this.Status.ReadOnly = true;
            this.Status.Width = 50;
            // 
            // bt_add
            // 
            this.bt_add.Location = new System.Drawing.Point(5, 97);
            this.bt_add.Margin = new System.Windows.Forms.Padding(2);
            this.bt_add.Name = "bt_add";
            this.bt_add.Size = new System.Drawing.Size(79, 34);
            this.bt_add.TabIndex = 2;
            this.bt_add.Text = "Agregar Doc";
            this.bt_add.UseVisualStyleBackColor = true;
            this.bt_add.Click += new System.EventHandler(this.bt_add_Click);
            // 
            // bt_del
            // 
            this.bt_del.Location = new System.Drawing.Point(5, 135);
            this.bt_del.Margin = new System.Windows.Forms.Padding(2);
            this.bt_del.Name = "bt_del";
            this.bt_del.Size = new System.Drawing.Size(79, 34);
            this.bt_del.TabIndex = 3;
            this.bt_del.Text = "Eliminar Doc";
            this.bt_del.UseVisualStyleBackColor = true;
            this.bt_del.Click += new System.EventHandler(this.bt_del_Click);
            // 
            // bt_up
            // 
            this.bt_up.Location = new System.Drawing.Point(5, 173);
            this.bt_up.Margin = new System.Windows.Forms.Padding(2);
            this.bt_up.Name = "bt_up";
            this.bt_up.Size = new System.Drawing.Size(79, 34);
            this.bt_up.TabIndex = 4;
            this.bt_up.Text = "Subir";
            this.bt_up.UseVisualStyleBackColor = true;
            this.bt_up.Click += new System.EventHandler(this.bt_up_Click);
            // 
            // bt_down
            // 
            this.bt_down.Location = new System.Drawing.Point(5, 211);
            this.bt_down.Margin = new System.Windows.Forms.Padding(2);
            this.bt_down.Name = "bt_down";
            this.bt_down.Size = new System.Drawing.Size(79, 34);
            this.bt_down.TabIndex = 5;
            this.bt_down.Text = "Bajar";
            this.bt_down.UseVisualStyleBackColor = true;
            this.bt_down.Click += new System.EventHandler(this.bt_down_Click);
            // 
            // bt_generate
            // 
            this.bt_generate.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.bt_generate.Location = new System.Drawing.Point(88, 384);
            this.bt_generate.Margin = new System.Windows.Forms.Padding(2);
            this.bt_generate.Name = "bt_generate";
            this.bt_generate.Size = new System.Drawing.Size(156, 30);
            this.bt_generate.TabIndex = 15;
            this.bt_generate.Text = "Adjuntar Docs";
            this.bt_generate.UseVisualStyleBackColor = true;
            this.bt_generate.Click += new System.EventHandler(this.bt_generate_Click);
            // 
            // bt_save
            // 
            this.bt_save.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.bt_save.Location = new System.Drawing.Point(88, 319);
            this.bt_save.Margin = new System.Windows.Forms.Padding(2);
            this.bt_save.Name = "bt_save";
            this.bt_save.Size = new System.Drawing.Size(161, 24);
            this.bt_save.TabIndex = 9;
            this.bt_save.Text = "Definir ruta del nuevo archivo";
            this.bt_save.UseVisualStyleBackColor = true;
            this.bt_save.Click += new System.EventHandler(this.bt_save_Click);
            // 
            // tb_save
            // 
            this.tb_save.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.tb_save.Location = new System.Drawing.Point(334, 347);
            this.tb_save.Margin = new System.Windows.Forms.Padding(2);
            this.tb_save.Name = "tb_save";
            this.tb_save.Size = new System.Drawing.Size(571, 20);
            this.tb_save.TabIndex = 13;
            this.tb_save.TextChanged += new System.EventHandler(this.tb_save_TextChanged);
            // 
            // lb_save
            // 
            this.lb_save.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.lb_save.AutoSize = true;
            this.lb_save.Location = new System.Drawing.Point(85, 350);
            this.lb_save.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.lb_save.Name = "lb_save";
            this.lb_save.Size = new System.Drawing.Size(242, 13);
            this.lb_save.TabIndex = 12;
            this.lb_save.Text = "Nombre para el nuevo archivo que será generado";
            // 
            // mensaje
            // 
            this.mensaje.ImageScalingSize = new System.Drawing.Size(20, 20);
            this.mensaje.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.st_label,
            this.toolStripStatusLabel1});
            this.mensaje.Location = new System.Drawing.Point(0, 422);
            this.mensaje.Name = "mensaje";
            this.mensaje.Padding = new System.Windows.Forms.Padding(1, 0, 10, 0);
            this.mensaje.Size = new System.Drawing.Size(944, 22);
            this.mensaje.TabIndex = 20;
            // 
            // st_label
            // 
            this.st_label.Name = "st_label";
            this.st_label.Size = new System.Drawing.Size(0, 17);
            // 
            // toolStripStatusLabel1
            // 
            this.toolStripStatusLabel1.Name = "toolStripStatusLabel1";
            this.toolStripStatusLabel1.Size = new System.Drawing.Size(0, 17);
            // 
            // label2
            // 
            this.label2.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(248, 393);
            this.label2.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(310, 13);
            this.label2.TabIndex = 16;
            this.label2.Text = "Genera un Excel con todos los documentos cargados en la lista.";
            // 
            // tb_path
            // 
            this.tb_path.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.tb_path.BackColor = System.Drawing.SystemColors.Window;
            this.tb_path.Location = new System.Drawing.Point(253, 322);
            this.tb_path.Margin = new System.Windows.Forms.Padding(2);
            this.tb_path.Name = "tb_path";
            this.tb_path.Size = new System.Drawing.Size(593, 20);
            this.tb_path.TabIndex = 10;
            this.tb_path.TextChanged += new System.EventHandler(this.tb_path_TextChanged);
            this.tb_path.DoubleClick += new System.EventHandler(this.tb_path_DoubleClick);
            // 
            // bt_out_open
            // 
            this.bt_out_open.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.bt_out_open.Location = new System.Drawing.Point(850, 319);
            this.bt_out_open.Margin = new System.Windows.Forms.Padding(2);
            this.bt_out_open.Name = "bt_out_open";
            this.bt_out_open.Size = new System.Drawing.Size(83, 24);
            this.bt_out_open.TabIndex = 11;
            this.bt_out_open.Text = "Abrir carpeta";
            this.bt_out_open.UseVisualStyleBackColor = true;
            this.bt_out_open.Click += new System.EventHandler(this.bt_out_open_Click);
            // 
            // picbox_save
            // 
            this.picbox_save.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.picbox_save.InitialImage = global::ListOfMaterialsPGGA.Properties.Resources.uncheck;
            this.picbox_save.Location = new System.Drawing.Point(909, 347);
            this.picbox_save.Margin = new System.Windows.Forms.Padding(2);
            this.picbox_save.Name = "picbox_save";
            this.picbox_save.Size = new System.Drawing.Size(24, 24);
            this.picbox_save.TabIndex = 13;
            this.picbox_save.TabStop = false;
            // 
            // button1
            // 
            this.button1.Location = new System.Drawing.Point(5, 249);
            this.button1.Margin = new System.Windows.Forms.Padding(2);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(79, 34);
            this.button1.TabIndex = 23;
            this.button1.Text = "Agregar Docs Vacíos";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // pictureBox2
            // 
            this.pictureBox2.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom;
            this.pictureBox2.Image = ((System.Drawing.Image)(resources.GetObject("pictureBox2.Image")));
            this.pictureBox2.Location = new System.Drawing.Point(732, 12);
            this.pictureBox2.Name = "pictureBox2";
            this.pictureBox2.Size = new System.Drawing.Size(182, 47);
            this.pictureBox2.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.pictureBox2.TabIndex = 24;
            this.pictureBox2.TabStop = false;
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.BackColor = System.Drawing.Color.Transparent;
            this.label6.Font = new System.Drawing.Font("Arial", 24F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label6.Location = new System.Drawing.Point(84, 12);
            this.label6.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(322, 37);
            this.label6.TabIndex = 25;
            this.label6.Text = "Generación de BOM";
            // 
            // tb_template
            // 
            this.tb_template.Location = new System.Drawing.Point(23, 342);
            this.tb_template.Name = "tb_template";
            this.tb_template.Size = new System.Drawing.Size(25, 20);
            this.tb_template.TabIndex = 26;
            this.tb_template.Visible = false;
            // 
            // Generate
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(944, 444);
            this.Controls.Add(this.tb_template);
            this.Controls.Add(this.label6);
            this.Controls.Add(this.pictureBox2);
            this.Controls.Add(this.button1);
            this.Controls.Add(this.bt_out_open);
            this.Controls.Add(this.tb_path);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.mensaje);
            this.Controls.Add(this.bt_save);
            this.Controls.Add(this.picbox_save);
            this.Controls.Add(this.tb_save);
            this.Controls.Add(this.lb_save);
            this.Controls.Add(this.bt_generate);
            this.Controls.Add(this.bt_down);
            this.Controls.Add(this.bt_up);
            this.Controls.Add(this.bt_del);
            this.Controls.Add(this.bt_add);
            this.Controls.Add(this.dataGridView1);
            this.Controls.Add(this.label1);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Margin = new System.Windows.Forms.Padding(2);
            this.MinimumSize = new System.Drawing.Size(958, 474);
            this.Name = "Generate";
            this.Text = "Generar documentación de lista de materiales";
            this.Load += new System.EventHandler(this.Generate_Load);
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).EndInit();
            this.mensaje.ResumeLayout(false);
            this.mensaje.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.picbox_save)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox2)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.DataGridView dataGridView1;
        private System.Windows.Forms.Button bt_add;
        private System.Windows.Forms.Button bt_del;
        private System.Windows.Forms.Button bt_up;
        private System.Windows.Forms.Button bt_down;
        private System.Windows.Forms.Button bt_generate;
        private System.Windows.Forms.Button bt_save;
        private System.Windows.Forms.PictureBox picbox_save;
        private System.Windows.Forms.TextBox tb_save;
        private System.Windows.Forms.Label lb_save;
        private System.Windows.Forms.DataGridViewTextBoxColumn Archivo;
        private System.Windows.Forms.DataGridViewTextBoxColumn Ubicacion;
        private System.Windows.Forms.DataGridViewTextBoxColumn Cantidad;
        private System.Windows.Forms.DataGridViewImageColumn Status;
        private System.Windows.Forms.StatusStrip mensaje;
        private System.Windows.Forms.ToolStripStatusLabel st_label;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox tb_path;
        private System.Windows.Forms.Button bt_out_open;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.PictureBox pictureBox2;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.ToolStripStatusLabel toolStripStatusLabel1;
        private System.Windows.Forms.TextBox tb_template;
    }
}