using System;
using System.Drawing;
using System.Drawing.Imaging;
using System.IO;
using System.Windows.Forms;
using Guna.UI2.WinForms;
using Shell32;

namespace Get_Icon_Apps
{
    public partial class Form1 : Form
    {
        private Image originalImage;
        private OpenFileDialog openFileDialog; // Declare openFileDialog como um campo da classe
        private int countImages = 0;
        public Form1()
        {
            InitializeComponent();
            openFileDialog = new OpenFileDialog(); // Inicialize no construtor

        }

        private void Form1_Load(object sender, EventArgs e)
        {
            // Configura��es iniciais ou de carregamento, se necess�rio
        }

        private void btnSelectFile_Click(object sender, EventArgs e)
        {
            countImages ++;
            openFileDialog.Title = "Selecione um execut�vel ou atalho";
                openFileDialog.Filter = "Arquivos Execut�veis (*.exe)|*.exe|Atalhos (*.lnk)|*.lnk";
            openFileDialog.InitialDirectory = Environment.GetFolderPath(Environment.SpecialFolder.ProgramFiles);
           

            if (openFileDialog.ShowDialog() == DialogResult.OK)
            {
                string filePath = openFileDialog.FileName;
                try
                {
                    // Extrair o �cone
                    Icon icon = GetHighResolutionIcon(filePath);
                    originalImage = icon.ToBitmap();

                    if (countImages >= 2)
                    {
                        
                        BtnCreatePictureBox_Click();

                    }
                    else
                    {

                    
                    // Exibir o �cone original
                    pictureBoxOriginal.Image = originalImage;
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show($"Erro ao carregar �cone: {ex.Message}", "Erro", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }





        private void btnSave_Click(object sender, EventArgs e)
        {
            // Exibir o di�logo para salvar a imagem com ou sem fundo
            SaveFileDialog saveFileDialog = new SaveFileDialog
            {
                Filter = "Arquivos PNG (*.png)|*.png|Arquivos ICO (*.ico)|*.ico",
                DefaultExt = "png"
            };

            // Se houver uma imagem original carregada, configurar o nome do arquivo padr�o
            if (pictureBoxOriginal.Image != null)
            {
                // Obter o nome do arquivo original sem a extens�o
                string fileNameWithoutExtension = Path.GetFileNameWithoutExtension(openFileDialog.FileName);

                // Definir o nome sugerido no SaveFileDialog
                saveFileDialog.FileName = $"{fileNameWithoutExtension}.png"; // Ajuste para o formato desejado (PNG ou ICO)
            }

            if (saveFileDialog.ShowDialog() == DialogResult.OK)
            {
                try
                {
                    // Salvar a imagem escolhida
                    if (pictureBoxOriginal.Image != null)
                    {
                        pictureBoxOriginal.Image.Save(saveFileDialog.FileName);
                        MessageBox.Show($"Imagem salva em: {saveFileDialog.FileName}", "Sucesso", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    }
                    else
                    {
                        MessageBox.Show("Nenhuma imagem para salvar!", "Aviso", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show($"Erro ao salvar a imagem: {ex.Message}", "Erro", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }


        private Icon GetHighResolutionIcon(string filePath)
        {
            if (Path.GetExtension(filePath).ToLower() == ".lnk")
            {
                // Se for um atalho, resolve o caminho real
                filePath = ResolveShortcut(filePath);
            }

            // Obter o �cone diretamente do arquivo execut�vel
            try
            {
                Shell32.Shell shell = new Shell32.Shell();
                FolderItem folderItem = shell.NameSpace(Path.GetDirectoryName(filePath)).ParseName(Path.GetFileName(filePath));

                return Icon.ExtractAssociatedIcon(filePath);
            }
            catch (Exception ex)
            {
                throw new Exception($"N�o foi poss�vel extrair �cone: {ex.Message}");
            }
        }

        private string ResolveShortcut(string shortcutPath)
        {
            var shell = new Shell32.Shell();
            var folder = shell.NameSpace(Path.GetDirectoryName(shortcutPath));
            var link = folder.ParseName(Path.GetFileName(shortcutPath)) as Shell32.FolderItem;

            if (link != null)
            {
                return link.Path;
            }

            throw new Exception("Falha ao resolver o atalho.");
        }

        private void BtnCreatePictureBox_Click()
        {
            // Criar o Guna2PictureBox
            Guna2PictureBox guna2PictureBox = new Guna2PictureBox
            {
                // Configura��es iniciais do Guna2PictureBox
                Anchor = AnchorStyles.None, // Alinha no centro, como no seu exemplo
                BackColor = Color.Transparent, // Fundo transparente
               
                FillColor = Color.Transparent, // Cor de fundo transparente
                ImageRotate = 0F, // Nenhuma rota��o
                Location = new Point(115, 117), // Posi��o do PictureBox
                Name = "guna2PictureBox", // Nome do controle
               
                Size = new Size(70, 65), // Tamanho do PictureBox
                SizeMode = PictureBoxSizeMode.CenterImage, // Modo de exibi��o da imagem no centro
                TabIndex = 0, // �ndice de tabula��o
                TabStop = false, // N�o permitir parada de tabula��o nesse controle
                WaitOnLoad = true // Espera o carregamento da imagem


            };

            // Adicionar o Guna2PictureBox ao TableLayoutPanel (voc� pode usar qualquer painel de layout)
            tableLayoutPanel.Controls.Add(guna2PictureBox, 2, 1); // Adicionando na primeira linha e primeira coluna

            // Verifique se a imagem original foi carregada corretamente
            if (originalImage != null)
            {
                // Atribuir a imagem ao Guna2PictureBox
                guna2PictureBox.Image = originalImage;
            }
        }


    }
}
