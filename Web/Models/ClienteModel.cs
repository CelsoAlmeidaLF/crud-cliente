using Almeida.Core.Entities;
using System;
using System.Collections.Generic;

namespace Almeida.Web.Models
{
    public class ClienteModel : Cliente
    {
        public ClienteModel()
        {
        }

        public ClienteModel(Cliente cliente)
        {
            Id = cliente.Id;
            Nome = cliente.Nome;
            SobreNome = cliente.SobreNome;
            CPF = cliente.CPF;
            CEP = cliente.CEP;
            Endereco = cliente.Endereco;
            Num = cliente.Num;
            Complemento = cliente.Complemento;
            Bairro = cliente.Bairro;
            Telefone1 = cliente.Telefone1;
            Telefone2 = cliente.Telefone2;
            Email = cliente.Email;
            dataAlteracao = cliente.dataAlteracao;
            dateCriacao = cliente.dateCriacao;
        }

        public static Cliente Get(ClienteModel cliente)
        {
            var client = new Cliente()
            {
                Id = cliente.Id,
                Nome = cliente.Nome,
                SobreNome = cliente.SobreNome,
                CPF = cliente.CPF,
                CEP = cliente.CEP,
                Endereco = cliente.Endereco,
                Num = cliente.Num,
                Complemento = cliente.Complemento,
                Bairro = cliente.Bairro,
                Telefone1 = cliente.Telefone1,
                Telefone2 = cliente.Telefone2,
                Email = cliente.Email,
                dataAlteracao = cliente.dataAlteracao,
                dateCriacao = cliente.dateCriacao,
            };
            return client;
        }
    }
}