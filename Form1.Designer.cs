namespace Get_Icon_Apps
{
    partial class Form1
    {
        private System.ComponentModel.IContainer components = null;
        private PictureBox pictureBoxOriginal;
        private PictureBox pictureBoxPreview;
        private PictureBox pictureBoxWithoutBackground;
        private Button btnSelectImage;
        private Button btnRemoveBackground;
        private Button btnRestoreBackground;
        private Button btnSave;

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
            pictureBoxOriginal = new PictureBox();
            pictureBoxPreview = new PictureBox();
            pictureBoxWithoutBackground = new PictureBox();
            btnSelectImage = new Button();
            btnRemoveBackground = new Button();
            btnRestoreBackground = new Button();
            btnSave = new Button();
            ((System.ComponentModel.ISupportInitialize)pictureBoxOriginal).BeginInit();
            ((System.ComponentModel.ISupportInitialize)pictureBoxPreview).BeginInit();
            ((System.ComponentModel.ISupportInitialize)pictureBoxWithoutBackground).BeginInit();
            SuspendLayout();
            // 
            // pictureBoxOriginal
            // 
            pictureBoxOriginal.Location = new Point(9, 132);
            pictureBoxOriginal.Name = "pictureBoxOriginal";
            pictureBoxOriginal.Size = new Size(327, 274);
            pictureBoxOriginal.TabIndex = 0;
            pictureBoxOriginal.TabStop = false;
            // 
            // pictureBoxPreview
            // 
            pictureBoxPreview.Location = new Point(386, 233);
            pictureBoxPreview.Name = "pictureBoxPreview";
            pictureBoxPreview.Size = new Size(327, 274);
            pictureBoxPreview.TabIndex = 1;
            pictureBoxPreview.TabStop = false;
            // 
            // pictureBoxWithoutBackground
            // 
            pictureBoxWithoutBackground.Location = new Point(745, 129);
            pictureBoxWithoutBackground.Name = "pictureBoxWithoutBackground";
            pictureBoxWithoutBackground.Size = new Size(327, 274);
            pictureBoxWithoutBackground.TabIndex = 2;
            pictureBoxWithoutBackground.TabStop = false;
            // 
            // btnSelectImage
            // 
            btnSelectImage.Location = new Point(446, 95);
            btnSelectImage.Name = "btnSelectImage";
            btnSelectImage.Size = new Size(200, 30);
            btnSelectImage.TabIndex = 3;
            btnSelectImage.Text = "Selecionar Imagem";
            btnSelectImage.UseVisualStyleBackColor = true;
            btnSelectImage.Click += btnSelectFile_Click;
            // 
            // btnRemoveBackground
            // 
            btnRemoveBackground.Location = new Point(446, 131);
            btnRemoveBackground.Name = "btnRemoveBackground";
            btnRemoveBackground.Size = new Size(200, 30);
            btnRemoveBackground.TabIndex = 4;
            btnRemoveBackground.Text = "Remover Fundo";
            btnRemoveBackground.UseVisualStyleBackColor = true;
            btnRemoveBackground.Click += btnRemoveBackground_Click;
            // 
            // btnRestoreBackground
            // 
            btnRestoreBackground.Location = new Point(446, 167);
            btnRestoreBackground.Name = "btnRestoreBackground";
            btnRestoreBackground.Size = new Size(200, 30);
            btnRestoreBackground.TabIndex = 5;
            btnRestoreBackground.Text = "Restaurar Fundo";
            btnRestoreBackground.UseVisualStyleBackColor = true;
            btnRestoreBackground.Click += btnRestoreBackground_Click;
            // 
            // btnSave
            // 
            btnSave.Location = new Point(446, 545);
            btnSave.Name = "btnSave";
            btnSave.Size = new Size(200, 30);
            btnSave.TabIndex = 6;
            btnSave.Text = "Salvar Imagem";
            btnSave.UseVisualStyleBackColor = true;
            btnSave.Click += btnSave_Click;
            // 
            // Form1
            // 
            ClientSize = new Size(1084, 689);
            Controls.Add(btnSave);
            Controls.Add(pictureBoxWithoutBackground);
            Controls.Add(pictureBoxPreview);
            Controls.Add(btnRestoreBackground);
            Controls.Add(btnRemoveBackground);
            Controls.Add(btnSelectImage);
            Controls.Add(pictureBoxOriginal);
            Name = "Form1";
            Text = "Gerenciador de Ícones";
            ((System.ComponentModel.ISupportInitialize)pictureBoxOriginal).EndInit();
            ((System.ComponentModel.ISupportInitialize)pictureBoxPreview).EndInit();
            ((System.ComponentModel.ISupportInitialize)pictureBoxWithoutBackground).EndInit();
            ResumeLayout(false);
        }
    }
}
