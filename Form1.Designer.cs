using Guna.UI2.WinForms;
using System.Drawing;
using System.Windows.Forms;

namespace Get_Icon_Apps
{
    partial class Form1
    {
        private System.ComponentModel.IContainer components = null;
        private Guna2PictureBox pictureBoxOriginal;
        private Guna2Button btnSelectImage;
        private Guna2Button btnSave;
        private TableLayoutPanel tableLayoutPanel;

        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        private void InitializeComponent()
        {
            Guna.UI2.WinForms.Suite.CustomizableEdges customizableEdges1 = new Guna.UI2.WinForms.Suite.CustomizableEdges();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Form1));
            Guna.UI2.WinForms.Suite.CustomizableEdges customizableEdges2 = new Guna.UI2.WinForms.Suite.CustomizableEdges();
            Guna.UI2.WinForms.Suite.CustomizableEdges customizableEdges3 = new Guna.UI2.WinForms.Suite.CustomizableEdges();
            Guna.UI2.WinForms.Suite.CustomizableEdges customizableEdges4 = new Guna.UI2.WinForms.Suite.CustomizableEdges();
            Guna.UI2.WinForms.Suite.CustomizableEdges customizableEdges5 = new Guna.UI2.WinForms.Suite.CustomizableEdges();
            Guna.UI2.WinForms.Suite.CustomizableEdges customizableEdges6 = new Guna.UI2.WinForms.Suite.CustomizableEdges();
            pictureBoxOriginal = new Guna2PictureBox();
            btnSelectImage = new Guna2Button();
            btnSave = new Guna2Button();
            tableLayoutPanel = new TableLayoutPanel();
            ((System.ComponentModel.ISupportInitialize)pictureBoxOriginal).BeginInit();
            tableLayoutPanel.SuspendLayout();
            SuspendLayout();
            // 
            // pictureBoxOriginal
            // 
            pictureBoxOriginal.Anchor = AnchorStyles.None;
            pictureBoxOriginal.BackColor = Color.Transparent;
            pictureBoxOriginal.CustomizableEdges = customizableEdges1;
            pictureBoxOriginal.FillColor = Color.Transparent;
            pictureBoxOriginal.Image = (Image)resources.GetObject("pictureBoxOriginal.Image");
            pictureBoxOriginal.ImageRotate = 0F;
            pictureBoxOriginal.Location = new Point(115, 117);
            pictureBoxOriginal.Name = "pictureBoxOriginal";
            pictureBoxOriginal.ShadowDecoration.CustomizableEdges = customizableEdges2;
            pictureBoxOriginal.Size = new Size(70, 65);
            pictureBoxOriginal.SizeMode = PictureBoxSizeMode.CenterImage;
            pictureBoxOriginal.TabIndex = 0;
            pictureBoxOriginal.TabStop = false;
            pictureBoxOriginal.WaitOnLoad = true;
            // 
            // btnSelectImage
            // 
            btnSelectImage.Anchor = AnchorStyles.None;
            btnSelectImage.BorderRadius = 10;
            btnSelectImage.CustomizableEdges = customizableEdges3;
            btnSelectImage.Font = new Font("Segoe UI", 9F);
            btnSelectImage.ForeColor = Color.White;
            btnSelectImage.Location = new Point(50, 32);
            btnSelectImage.Name = "btnSelectImage";
            btnSelectImage.ShadowDecoration.CustomizableEdges = customizableEdges4;
            btnSelectImage.Size = new Size(200, 35);
            btnSelectImage.TabIndex = 3;
            btnSelectImage.Text = "Selecionar Imagem";
            btnSelectImage.Click += btnSelectFile_Click;
            // 
            // btnSave
            // 
            btnSave.Anchor = AnchorStyles.None;
            btnSave.BorderRadius = 10;
            btnSave.CustomizableEdges = customizableEdges5;
            btnSave.Font = new Font("Segoe UI", 9F);
            btnSave.ForeColor = Color.White;
            btnSave.Location = new Point(50, 232);
            btnSave.Name = "btnSave";
            btnSave.ShadowDecoration.CustomizableEdges = customizableEdges6;
            btnSave.Size = new Size(200, 35);
            btnSave.TabIndex = 6;
            btnSave.Text = "Salvar Imagem";
            btnSave.Click += btnSave_Click;
            // 
            // tableLayoutPanel
            // 
            tableLayoutPanel.ColumnCount = 1;
            tableLayoutPanel.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 33.33F));
            tableLayoutPanel.Controls.Add(pictureBoxOriginal, 0, 1);
            tableLayoutPanel.Controls.Add(btnSelectImage, 0, 0);
            tableLayoutPanel.Controls.Add(btnSave, 1, 2);
            tableLayoutPanel.Dock = DockStyle.Fill;
            tableLayoutPanel.Location = new Point(0, 0);
            tableLayoutPanel.Name = "tableLayoutPanel";
            tableLayoutPanel.RowCount = 3;
            tableLayoutPanel.RowStyles.Add(new RowStyle(SizeType.Percent, 80F));
            tableLayoutPanel.RowStyles.Add(new RowStyle(SizeType.Percent, 80F));
            tableLayoutPanel.RowStyles.Add(new RowStyle(SizeType.Percent, 80F));
            tableLayoutPanel.Size = new Size(300, 300);
            tableLayoutPanel.TabIndex = 0;
            // 
            // Form1
            // 
            ClientSize = new Size(600, 300);
            Controls.Add(tableLayoutPanel);
            Name = "Form1";
            Text = "Gerenciador de Ícones";
            ((System.ComponentModel.ISupportInitialize)pictureBoxOriginal).EndInit();
            tableLayoutPanel.ResumeLayout(false);
            ResumeLayout(false);
        }
    }
}
