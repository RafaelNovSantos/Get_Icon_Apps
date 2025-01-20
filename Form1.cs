using System;
using System.Drawing;
using System.IO;
using System.Windows.Forms;
using Microsoft.WindowsAPICodePack.Shell;
using Shell32;

namespace Get_Icon_Apps
{
    public partial class Form1 : Form
    {
        private Image originalImage;
        private Image imageWithBackground;

        public Form1()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            // Configurações iniciais ou de carregamento, se necessário
        }

        private void btnSelectFile_Click(object sender, EventArgs e)
        {
            // Permitir ao usuário selecionar um arquivo .exe ou .lnk
            OpenFileDialog openFileDialog = new OpenFileDialog
            {
                Title = "Selecione um executável ou atalho",
                Filter = "Arquivos Executáveis (*.exe)|*.exe|Atalhos (*.lnk)|*.lnk",
                InitialDirectory = Environment.GetFolderPath(Environment.SpecialFolder.ProgramFiles)
            };

            if (openFileDialog.ShowDialog() == DialogResult.OK)
            {
                string filePath = openFileDialog.FileName;
                try
                {
                    // Extrair o ícone
                    Icon icon = GetHighResolutionIcon(filePath);
                    originalImage = icon.ToBitmap();
                    imageWithBackground = (Image)originalImage.Clone();

                    // Exibir o ícone original
                    pictureBoxOriginal.Image = originalImage;
                    pictureBoxPreview.Image = originalImage;
                    pictureBoxWithoutBackground.Image = originalImage;
                }
                catch (Exception ex)
                {
                    MessageBox.Show($"Erro ao carregar ícone: {ex.Message}", "Erro", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }

        private void btnRemoveBackground_Click(object sender, EventArgs e)
        {
            // Lógica para remover o fundo preto da imagem
            if (pictureBoxPreview.Image != null)
            {
                Bitmap originalBitmap = (Bitmap)pictureBoxPreview.Image;
                Bitmap processedBitmap = RemoveBlackBackground(originalBitmap);
                pictureBoxPreview.Image = processedBitmap;
                pictureBoxWithoutBackground.Image = processedBitmap; // Exibir sem fundo
            }
        }

        private void btnRestoreBackground_Click(object sender, EventArgs e)
        {
            // Restaurar a imagem original com o fundo
            if (imageWithBackground != null)
            {
                pictureBoxWithoutBackground.Image = imageWithBackground;
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

            if (saveFileDialog.ShowDialog() == DialogResult.OK)
            {
                try
                {
                    // Salvar a imagem escolhida
                    if (pictureBoxWithoutBackground.Image != null)
                    {
                        pictureBoxWithoutBackground.Image.Save(saveFileDialog.FileName);
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

            // Obter o ícone
            ShellObject shellObject = ShellObject.FromParsingName(filePath);
            ShellThumbnail thumbnail = shellObject.Thumbnail;

            if (thumbnail != null && thumbnail.Bitmap != null)
            {
                return Icon.FromHandle(thumbnail.Bitmap.GetHicon());
            }
            else
            {
                throw new Exception("Não foi possível extrair ícone.");
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

        private Bitmap RemoveBlackBackground(Bitmap original)
        {
            Bitmap result = new Bitmap(original.Width, original.Height);

            for (int x = 0; x < original.Width; x++)
            {
                for (int y = 0; y < original.Height; y++)
                {
                    Color pixelColor = original.GetPixel(x, y);

                    // Se o pixel for preto, torná-lo transparente
                    if (pixelColor.R == 0 && pixelColor.G == 0 && pixelColor.B == 0)
                    {
                        result.SetPixel(x, y, Color.Transparent);
                    }
                    else
                    {
                        result.SetPixel(x, y, pixelColor);
                    }
                }
            }
            return result;
        }
    }
}
