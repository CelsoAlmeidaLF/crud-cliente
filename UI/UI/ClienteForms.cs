using Almeida.Core.Entities;
using System;
using System.Windows.Forms;

namespace Almeida.UiForms
{
    public partial class fCliente : Form
    {
        public Cliente Cliente { get; set; }

        public fCliente()
        {
            InitializeComponent();
        }

        private void btnSalvar_Click(object sender, EventArgs e)
        {
            Cliente = new Cliente()
            {
                Id = testID(txtID.Text),
                Nome = txt_Nome.Text,
                SobreNome = txt_SobreNome.Text,
                CPF = txt_CPF.Text,
                CEP = txt_CEP.Text,
                Endereco = txt_Endereco.Text,
                Num = int.Parse(txt_Num.Text),
                Complemento = txt_Comp.Text,
                Bairro = txt_Bairro.Text,
                Telefone1 = txt_Fone1.Text,
                Telefone2 = txt_Fone2.Text,
                Email = txt_Email.Text
            };
            this.Close();
        }

        private int? testID(string text)
        {
            if (int.Parse(text) != null)
            {
                return int.Parse(text);
            }
            else
            {
                return null;
            }
        }

        private void btnDeletar_Click(object sender, EventArgs e)
        {
            Cliente = null;
            this.Close();
        }

        private void btnLimpar_Click(object sender, EventArgs e)
        {
            Cliente = null;
            this.Close();
        }

        public void SetCliente(Cliente cliente)
        {
            if (cliente != null)
            {
                txtID.Text = cliente.Id.ToString();
                txt_Nome.Text = cliente.Nome;
                txt_SobreNome.Text = cliente.SobreNome;
                txt_CPF.Text = cliente.CPF;
                txt_CEP.Text = cliente.CEP;
                txt_Endereco.Text = cliente.Endereco;
                txt_Num.Text = cliente.Num.ToString();
                txt_Comp.Text = cliente.Complemento;
                txt_Bairro.Text = cliente.Bairro;
                txt_Fone1.Text = cliente.Telefone1;
                txt_Fone2.Text = cliente.Telefone2;
                txt_Email.Text = cliente.Email;
            }
            else
            {
                cliente = null;
            }
        }
    }
}
