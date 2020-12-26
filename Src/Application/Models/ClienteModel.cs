using Almeida.Core.Entities;
using System;
using System.Collections.Generic;

namespace Almeida.Application.Models
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

        public static List<ClienteModel> List(IEnumerable<Cliente> lsclientes)
        {
            var rows = new List<Cliente>();
            var ls = new List<ClienteModel>();
            rows.AddRange(lsclientes);
            try
            {
                ClienteModel item;
                for (int i = 0; i < rows.Count; i++)
                {
                    item = new ClienteModel()
                    {
                        Id = rows[i].Id,
                        Nome = rows[i].Nome,
                        SobreNome = rows[i].SobreNome,
                        CPF = rows[i].CPF,
                        CEP = rows[i].CEP,
                        Endereco = rows[i].Endereco,
                        Num = rows[i].Num,
                        Complemento = rows[i].Complemento,
                        Bairro = rows[i].Bairro,
                        Telefone1 = rows[i].Telefone1,
                        Telefone2 = rows[i].Telefone2,
                        Email = rows[i].Email,
                        dataAlteracao = rows[i].dataAlteracao,
                        dateCriacao = rows[i].dateCriacao,
                        Excluido = rows[i].Excluido
                    };
                    ls.Add(item);
                }
                return ls;
            }
            catch(Exception ex)
            {
                throw ex;
            }
        }
    }
}