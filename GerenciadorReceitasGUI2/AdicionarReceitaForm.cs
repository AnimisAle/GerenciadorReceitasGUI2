using MaterialSkin;
using MaterialSkin.Controls;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations.Schema;
using System.Drawing.Imaging;

namespace GerenciadorReceitasGUI2
{
    public partial class AdicionarReceitaForm : MaterialForm
    {
        private readonly MaterialSkinManager _materialSkinManager;

        [NotMapped]
        public Receita Receita { get; private set; }

        public AdicionarReceitaForm(Receita receita = null)
        {
            InitializeComponent();
            Receita = receita ?? new Receita();

            // Carregar categorias no ComboBox
            using (var context = new ReceitasContext())
            {
                var categorias = context.Categorias.ToList();
                if (categorias.Count == 0)
                {
                    MessageBox.Show("Nenhuma categoria disponível. Adicione categorias ao banco de dados.", "Erro", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    Close();
                    return;
                }

                cmbCategoria.DataSource = categorias;
                cmbCategoria.DisplayMember = "Nome";
                cmbCategoria.ValueMember = "Id";

                // Selecionar a primeira categoria por padrão
                if (categorias.Any())
                {
                    cmbCategoria.SelectedIndex = 0;
                }
            }

            if (receita != null)
            {
                txtNome.Text = receita.Nome;
                txtInstrucoes.Text = receita.Instrucoes;
                nudTempoPreparo.Value = receita.TempoPreparo;
                cmbCategoria.SelectedValue = receita.CategoriaId;
                lstIngredientes.Items.AddRange(receita.Ingredientes.ToArray());
                pictureBoxFoto.Image = receita.Foto != null ? ByteArrayToImage(receita.Foto) : null;
            }
        }

        private void btnAdicionarIngrediente_Click(object sender, EventArgs e)
        {
            var ingrediente = new Ingrediente
            {
                Nome = txtIngrediente.Text,
                Quantidade = txtIngredienteQuantidade.Text
            };
            Receita.Ingredientes.Add(ingrediente);
            lstIngredientes.Items.Add(ingrediente);
            txtIngrediente.Clear();
            txtIngredienteQuantidade.Clear();
        }

        private void btnSalvar_Click(object sender, EventArgs e)
        {
            if (cmbCategoria.SelectedValue == null)
            {
                MessageBox.Show("Por favor, selecione uma categoria.", "Erro", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            Receita.Nome = txtNome.Text;
            Receita.Instrucoes = txtInstrucoes.Text;
            Receita.TempoPreparo = (int)nudTempoPreparo.Value;
            Receita.CategoriaId = (int)cmbCategoria.SelectedValue;
            Receita.Foto = pictureBoxFoto.Image != null ? ImageToByteArray(pictureBoxFoto.Image) : null; 
            DialogResult = DialogResult.OK;
            Close();
        }

        private void btnCancelar_Click(object sender, EventArgs e)
        {
            DialogResult = DialogResult.Cancel;
            Close();
        }
        private void btnSelecionarFoto_Click(object sender, EventArgs e)
        {
            using (OpenFileDialog openFileDialog = new OpenFileDialog())
            {
                openFileDialog.Filter = "Arquivos de imagem|*.jpg;*.jpeg;*.png;*.bmp";
                if (openFileDialog.ShowDialog() == DialogResult.OK)
                {
                    pictureBoxFoto.Image = Image.FromFile(openFileDialog.FileName);
                }
            }
        }
        private byte[]? ImageToByteArray(Image image)
        {
            if (image == null) return null; // 🔹 Retorna null se não houver imagem

            using (MemoryStream ms = new MemoryStream())
            {
                image.Save(ms, ImageFormat.Jpeg);
                return ms.ToArray();
            }
        }
        private Image? ByteArrayToImage(byte[]? byteArray)
        {
            if (byteArray == null) return null; // 🔹 Se for NULL, retorna NULL

            using (MemoryStream ms = new MemoryStream(byteArray))
            {
                return Image.FromStream(ms);
            }
        }
    }
}