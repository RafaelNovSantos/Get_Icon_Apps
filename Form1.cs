using System;
using System.Drawing;
using System.Drawing.Imaging;
using System.IO;
using System.Windows.Forms;
using Shell32;

namespace Get_Icon_Apps
{
    public partial class Form1 : Form
    {
        private Image originalImage;
        private OpenFileDialog openFileDialog; // Declare openFileDialog como um campo da classe
        public Form1()
        {
            InitializeComponent();
            openFileDialog = new OpenFileDialog(); // Inicialize no construtor
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            // Configurações iniciais ou de carregamento, se necessário
        }

        private void btnSelectFile_Click(object sender, EventArgs e)
        {

            openFileDialog.Title = "Selecione um executável ou atalho";
                openFileDialog.Filter = "Arquivos Executáveis (*.exe)|*.exe|Atalhos (*.lnk)|*.lnk";
            openFileDialog.InitialDirectory = Environment.GetFolderPath(Environment.SpecialFolder.ProgramFiles);
           

            if (openFileDialog.ShowDialog() == DialogResult.OK)
            {
                string filePath = openFileDialog.FileName;
                try
                {
                    // Extrair o ícone
                    Icon icon = GetHighResolutionIcon(filePath);
                    originalImage = icon.ToBitmap();
                

                    // Exibir o ícone original
                    pictureBoxOriginal.Image = originalImage;

                }
                catch (Exception ex)
                {
                    MessageBox.Show($"Erro ao carregar ícone: {ex.Message}", "Erro", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }





        private void btnSave_Click(object sender, EventArgs e)
        {
            // Exibir o diálogo para salvar a imagem com ou sem fundo
            SaveFileDialog saveFileDialog = new SaveFileDialog
            {
                Filter = "Arquivos PNG (*.png)|*.png|Arquivos ICO (*.ico)|*.ico",
                DefaultExt = "png"
            };

            // Se houver uma imagem original carregada, configurar o nome do arquivo padrão
            if (pictureBoxOriginal.Image != null)
            {
                // Obter o nome do arquivo original sem a extensão
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

            // Obter o ícone diretamente do arquivo executável
            try
            {
                Shell32.Shell shell = new Shell32.Shell();
                FolderItem folderItem = shell.NameSpace(Path.GetDirectoryName(filePath)).ParseName(Path.GetFileName(filePath));

                return Icon.ExtractAssociatedIcon(filePath);
            }
            catch (Exception ex)
            {
                throw new Exception($"Não foi possível extrair ícone: {ex.Message}");
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

      
    }
}
