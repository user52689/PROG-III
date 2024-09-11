namespace TP_1
{
    partial class Form2
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
            this.lblNombre = new System.Windows.Forms.Label();
            this.txtNombre = new System.Windows.Forms.TextBox();
            this.btnAgregar = new System.Windows.Forms.Button();
            this.lbNombres = new System.Windows.Forms.ListBox();
            this.lbSeleccionados = new System.Windows.Forms.ListBox();
            this.btnMover1 = new System.Windows.Forms.Button();
            this.btnMoverTodos = new System.Windows.Forms.Button();
            this.btnVolver = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // lblNombre
            // 
            this.lblNombre.AutoSize = true;
            this.lblNombre.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblNombre.Location = new System.Drawing.Point(19, 67);
            this.lblNombre.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.lblNombre.Name = "lblNombre";
            this.lblNombre.Size = new System.Drawing.Size(165, 20);
            this.lblNombre.TabIndex = 1;
            this.lblNombre.Text = "Ingrese un nombre:";
            // 
            // txtNombre
            // 
            this.txtNombre.Location = new System.Drawing.Point(195, 70);
            this.txtNombre.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.txtNombre.Name = "txtNombre";
            this.txtNombre.Size = new System.Drawing.Size(190, 20);
            this.txtNombre.TabIndex = 2;
            // 
            // btnAgregar
            // 
            this.btnAgregar.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnAgregar.Location = new System.Drawing.Point(413, 63);
            this.btnAgregar.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.btnAgregar.Name = "btnAgregar";
            this.btnAgregar.Size = new System.Drawing.Size(92, 29);
            this.btnAgregar.TabIndex = 3;
            this.btnAgregar.Text = "Agregar";
            this.btnAgregar.UseVisualStyleBackColor = true;
            this.btnAgregar.Click += new System.EventHandler(this.btnAgregar_Click);
            // 
            // lbNombres
            // 
            this.lbNombres.FormattingEnabled = true;
            this.lbNombres.Location = new System.Drawing.Point(22, 119);
            this.lbNombres.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.lbNombres.Name = "lbNombres";
            this.lbNombres.Size = new System.Drawing.Size(168, 238);
            this.lbNombres.TabIndex = 4;
            // 
            // lbSeleccionados
            // 
            this.lbSeleccionados.FormattingEnabled = true;
            this.lbSeleccionados.Location = new System.Drawing.Point(304, 119);
            this.lbSeleccionados.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.lbSeleccionados.Name = "lbSeleccionados";
            this.lbSeleccionados.Size = new System.Drawing.Size(168, 238);
            this.lbSeleccionados.TabIndex = 5;
            // 
            // btnMover1
            // 
            this.btnMover1.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnMover1.Location = new System.Drawing.Point(219, 190);
            this.btnMover1.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.btnMover1.Name = "btnMover1";
            this.btnMover1.Size = new System.Drawing.Size(58, 29);
            this.btnMover1.TabIndex = 6;
            this.btnMover1.Text = ">";
            this.btnMover1.UseVisualStyleBackColor = true;
            this.btnMover1.Click += new System.EventHandler(this.btnMover1_Click);
            // 
            // btnMoverTodos
            // 
            this.btnMoverTodos.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnMoverTodos.Location = new System.Drawing.Point(219, 266);
            this.btnMoverTodos.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.btnMoverTodos.Name = "btnMoverTodos";
            this.btnMoverTodos.Size = new System.Drawing.Size(58, 29);
            this.btnMoverTodos.TabIndex = 7;
            this.btnMoverTodos.Text = ">>";
            this.btnMoverTodos.UseVisualStyleBackColor = true;
            this.btnMoverTodos.Click += new System.EventHandler(this.btnMoverTodos_Click);
            // 
            // btnVolver
            // 
            this.btnVolver.Location = new System.Drawing.Point(364, 380);
            this.btnVolver.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.btnVolver.Name = "btnVolver";
            this.btnVolver.Size = new System.Drawing.Size(59, 26);
            this.btnVolver.TabIndex = 8;
            this.btnVolver.Text = "Volver";
            this.btnVolver.UseVisualStyleBackColor = true;
            this.btnVolver.Click += new System.EventHandler(this.btnVolver_Click);
            // 
            // Form2
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(540, 417);
            this.Controls.Add(this.btnVolver);
            this.Controls.Add(this.btnMoverTodos);
            this.Controls.Add(this.btnMover1);
            this.Controls.Add(this.lbSeleccionados);
            this.Controls.Add(this.lbNombres);
            this.Controls.Add(this.btnAgregar);
            this.Controls.Add(this.txtNombre);
            this.Controls.Add(this.lblNombre);
            this.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.Name = "Form2";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Nombres";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label lblNombre;
        private System.Windows.Forms.TextBox txtNombre;
        private System.Windows.Forms.Button btnAgregar;
        private System.Windows.Forms.ListBox lbNombres;
        private System.Windows.Forms.ListBox lbSeleccionados;
        private System.Windows.Forms.Button btnMover1;
        private System.Windows.Forms.Button btnMoverTodos;
        private System.Windows.Forms.Button btnVolver;
    }
}