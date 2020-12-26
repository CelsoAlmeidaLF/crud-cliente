using System;
using System.Collections.Generic;
using System.Windows.Forms;

using Almeida.Application.Business;
using Almeida.Application.Models;
using Almeida.Core.Entities;
using Almeida.Core.Interfaces;

namespace Almeida.UiForms
{
    public partial class Ui : Form
    {
        private readonly IRepository<Cliente> _repository;
        private fCliente forms;

        public Ui()
        {
            _repository = new BusinessCliente();
            InitializeComponent();
             DataBindings();  
        }

        private void DataBindings()
        {
            dgv.Rows.Clear();
            IEnumerable<Cliente> lsclientes;
            lsclientes = _repository.Get();
            var rows = ClienteModel.List(lsclientes);
            for (int i = 0; i < rows.Count; i++)
            {
                dgv.Rows.Add(
                    String.Format("{0}", rows[i].Id), rows[i].Nome, rows[i].SobreNome,
                    rows[i].CPF, rows[i].Telefone1, rows[i].Telefone2, rows[i].Email);
            }
        }

        private void btn_Cadastrar_Click(object sender, EventArgs e)
        {
            forms = new fCliente();
            forms.Text = "Cadastro de Clientes";
            forms.txtID.Enabled = false;
            forms.lbID.Enabled = false;
            forms.ShowDialog();
            var cliente = forms.Cliente;
            if (cliente != null)
            {
                var i = _repository.Set(cliente);
            }
            DataBindings();
        }

        private void btnDelete_Click(object sender, EventArgs e)
        {
            var i = 0;
            if (dgv.CurrentRow.Index != -1)
            {
                i = int.Parse(dgv.CurrentRow.Cells["Id"].Value.ToString());
            }
            var cliente = _repository.GetById(i);
            if (cliente != null)
            {
                i = _repository.Delete(cliente);
            }
            DataBindings();
        }

        private void btnEdit_Click(object sender, EventArgs e)
        {
            forms = new fCliente();
            var i = 0;

            if (dgv.CurrentRow.Index != -1)
            {
                i = int.Parse(dgv.CurrentRow.Cells["Id"].Value.ToString());
            }
            var item = _repository.GetById(i);

            forms.Text = "Editar Cliente";
            forms.txtID.Enabled = false;
            forms.lbID.Enabled = false;
            forms.SetCliente(item);
            forms.ShowDialog();

            var cliente = forms.Cliente as Cliente;

            i = _repository.Set(cliente);

            DataBindings();
        }
    }
}
