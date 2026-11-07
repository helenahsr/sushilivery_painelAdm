namespace sushilivery_painelAdm
{
    partial class Listagem
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
            this.label6 = new System.Windows.Forms.Label();
            this.dtgvProdutos = new System.Windows.Forms.DataGridView();
            this.btnEditar = new System.Windows.Forms.Button();
            this.btnExcluir = new System.Windows.Forms.Button();
            this.btnCadastrarMais = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.dtgvProdutos)).BeginInit();
            this.SuspendLayout();
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Font = new System.Drawing.Font("Microsoft Sans Serif", 20F);
            this.label6.Location = new System.Drawing.Point(380, 9);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(358, 31);
            this.label6.TabIndex = 12;
            this.label6.Text = "LISTAGEM DE PRODUTOS";
            // 
            // dtgvProdutos
            // 
            this.dtgvProdutos.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dtgvProdutos.Location = new System.Drawing.Point(18, 43);
            this.dtgvProdutos.Name = "dtgvProdutos";
            this.dtgvProdutos.Size = new System.Drawing.Size(1114, 361);
            this.dtgvProdutos.TabIndex = 13;
            this.dtgvProdutos.CellClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dtgvProdutos_CellClick);
            // 
            // btnEditar
            // 
            this.btnEditar.Location = new System.Drawing.Point(18, 410);
            this.btnEditar.Name = "btnEditar";
            this.btnEditar.Size = new System.Drawing.Size(339, 45);
            this.btnEditar.TabIndex = 14;
            this.btnEditar.Text = "EDITAR";
            this.btnEditar.UseVisualStyleBackColor = true;
            // 
            // btnExcluir
            // 
            this.btnExcluir.Location = new System.Drawing.Point(363, 410);
            this.btnExcluir.Name = "btnExcluir";
            this.btnExcluir.Size = new System.Drawing.Size(396, 45);
            this.btnExcluir.TabIndex = 15;
            this.btnExcluir.Text = "EXCLUIR";
            this.btnExcluir.UseVisualStyleBackColor = true;
            this.btnExcluir.Click += new System.EventHandler(this.btnExcluir_Click);
            // 
            // btnCadastrarMais
            // 
            this.btnCadastrarMais.Location = new System.Drawing.Point(765, 410);
            this.btnCadastrarMais.Name = "btnCadastrarMais";
            this.btnCadastrarMais.Size = new System.Drawing.Size(367, 45);
            this.btnCadastrarMais.TabIndex = 16;
            this.btnCadastrarMais.Text = "CADASTRAR +";
            this.btnCadastrarMais.UseVisualStyleBackColor = true;
            this.btnCadastrarMais.Click += new System.EventHandler(this.button3_Click);
            // 
            // Listagem
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1144, 467);
            this.Controls.Add(this.btnCadastrarMais);
            this.Controls.Add(this.btnExcluir);
            this.Controls.Add(this.btnEditar);
            this.Controls.Add(this.dtgvProdutos);
            this.Controls.Add(this.label6);
            this.Name = "Listagem";
            this.Text = "Listagem de Produtos";
            this.Load += new System.EventHandler(this.Listagem_Load);
            ((System.ComponentModel.ISupportInitialize)(this.dtgvProdutos)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.DataGridView dtgvProdutos;
        private System.Windows.Forms.Button btnEditar;
        private System.Windows.Forms.Button btnExcluir;
        private System.Windows.Forms.Button btnCadastrarMais;
    }
}