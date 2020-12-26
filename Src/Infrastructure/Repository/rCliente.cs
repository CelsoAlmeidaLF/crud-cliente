using System.Collections.Generic;
using System.Data.SqlClient;
using System;

using Almeida.Core.Entities;
using Almeida.Core.Interfaces;
using Almeida.Infrastructure.Data;
using System.Data;

namespace Almeida.Infrastructure.Repository
{
    public class rCliente : BaseDAL, IRepository<Cliente>
    {
        IEnumerable<Cliente> _clientes;

        /// <summary>
        /// DELETA CLIENTE NO BANCO DE DADOS.
        /// </summary>
        /// <param name="obj"></param>
        /// <returns></returns>
        public virtual int Delete(Cliente obj)
        {
            SqlParameter[] param = null;

            try
            {
                param = new SqlParameter[1];
                MontarParametro(0, param, ParameterDirection.Input, "@Id", ObterValorOuDBNull<int>(obj.Id), SqlDbType.Int);
                var cmmd = "SP_DEL_CLIENTES @Id";
                var i = DtaSet(cmmd, param);
                return 0;
            }
            catch (SqlException sqlex)
            {
                throw sqlex;
            }
            catch (Exception ex)
            {
                throw ex;
            }
            finally
            {
                Close();
            }
        }

        /// <summary>
        /// RETORNA LISTA DE CLIENTE DO BANCO DE DADOS.
        /// </summary>
        /// <returns></returns>
        public virtual IEnumerable<Cliente> Get()
        {
            Cliente item;
            var ls = new List<Cliente>();

            try
            {
                DataTable dt = DtaTbGet("EXEC SP_GET_CLIENTES");
                for (int i = 0; i < dt.Rows.Count; i++)
                {
                    item = new Cliente()
                    {
                        Id = int.Parse(dt.Rows[i]["IdClientes"].ToString()),
                        Nome = dt.Rows[i]["Nome"].ToString(),
                        SobreNome = dt.Rows[i]["SobreNome"].ToString(),
                        CPF = dt.Rows[i]["CPF"].ToString(),
                        CEP = dt.Rows[i]["CEP"].ToString(),
                        Endereco = dt.Rows[i]["Endereco"].ToString(),
                        Num = int.Parse(dt.Rows[i]["Num"].ToString()),            
                        Complemento = dt.Rows[i]["Complemento"].ToString(),           
                        Bairro = dt.Rows[i]["Bairro"].ToString(),
                        Telefone1 = dt.Rows[i]["Telefone1"].ToString(),
                        Telefone2 = dt.Rows[i]["Telefone2"].ToString(),
                        Email = dt.Rows[i]["Email"].ToString(), 
                        dateCriacao = DateTime.Parse(dt.Rows[i]["DataCricao"].ToString()),               
                        dataAlteracao = DateTime.Parse(dt.Rows[i]["DataAlteracao"].ToString()),
                    };
                    ls.Add(item);
                }
                _clientes = ls;
                return _clientes;
            }
            catch (SqlException sqlex)
            {
                throw sqlex;
            }
            catch (Exception ex)
            {
                throw ex;
            }
            finally
            {
                Close();
            }
        }

        /// <summary>
        /// RETORNA CLIENTE POR ID DO BANCO DE DADOS.
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public virtual Cliente GetById(int id)
        {
            Cliente item;
            var ls = new List<Cliente>();

            try
            {
                DataTable dt = DtaTbGet($"EXEC SP_GET_CLIENTES {id}");
                for (int i = 0; i < dt.Rows.Count; i++)
                {
                    item = new Cliente()
                    {
                        Id = int.Parse(dt.Rows[i]["IdClientes"].ToString()),
                        Nome = dt.Rows[i]["Nome"].ToString(),
                        SobreNome = dt.Rows[i]["SobreNome"].ToString(),
                        CPF = dt.Rows[i]["CPF"].ToString(),
                        CEP = dt.Rows[i]["CEP"].ToString(),
                        Endereco = dt.Rows[i]["Endereco"].ToString(),
                        Num = int.Parse(dt.Rows[i]["Num"].ToString()),
                        Complemento = dt.Rows[i]["Complemento"].ToString(),
                        Bairro = dt.Rows[i]["Bairro"].ToString(),
                        Telefone1 = dt.Rows[i]["Telefone1"].ToString(),
                        Telefone2 = dt.Rows[i]["Telefone2"].ToString(),
                        Email = dt.Rows[i]["Email"].ToString(),
                        dateCriacao = DateTime.Parse(dt.Rows[i]["DataCricao"].ToString()),
                        dataAlteracao = DateTime.Parse(dt.Rows[i]["DataAlteracao"].ToString()),
                    };
                    ls.Add(item);
                }
                return ls[0];
            }
            catch (SqlException sqlex)
            {
                throw sqlex;
            }
            catch (Exception ex)
            {
                throw ex;
            }
            finally
            {
                Close();
            }
        }

        /// <summary>
        /// COMANDO CADASTRA E ALTUALIZA CLIENTE NO BANCO DE DADOS.
        /// </summary>
        /// <param name="cliente"></param>
        /// <returns></returns>
        public virtual int Set(Cliente obj)
        {
            SqlParameter[] param = null;

            try
            {
                param = new SqlParameter[13];

                MontarParametro(0, param, ParameterDirection.Input, "@Id", ObterValorOuDBNull<int>(obj.Id), SqlDbType.Int);
                MontarParametro(1, param, ParameterDirection.Input, "@Nome", obj.Nome, SqlDbType.VarChar);
                MontarParametro(2, param, ParameterDirection.Input, "@SobreNome", obj.SobreNome, SqlDbType.VarChar);
                MontarParametro(3, param, ParameterDirection.Input, "@CPF", obj.CPF, SqlDbType.VarChar);
                MontarParametro(4, param, ParameterDirection.Input, "@CEP", obj.CEP, SqlDbType.VarChar);
                MontarParametro(5, param, ParameterDirection.Input, "@Endereco", obj.Endereco, SqlDbType.VarChar);
                MontarParametro(6, param, ParameterDirection.Input, "@Num", obj.Num, SqlDbType.Int);
                MontarParametro(7, param, ParameterDirection.Input, "@Complemento", obj.Complemento, SqlDbType.VarChar);
                MontarParametro(8, param, ParameterDirection.Input, "@Bairro", obj.Bairro, SqlDbType.VarChar);
                MontarParametro(9, param, ParameterDirection.Input, "@Telefone1", obj.Telefone1, SqlDbType.VarChar);
                MontarParametro(10, param, ParameterDirection.Input, "@Telefone2", obj.Telefone2, SqlDbType.VarChar);
                MontarParametro(11, param, ParameterDirection.Input, "@Email", obj.Email, SqlDbType.VarChar);
                MontarParametro(12, param, ParameterDirection.Input, "@Excluir", obj.Excluido, SqlDbType.Bit);

                var cmmd = $@" SP_SET_CLIENTES @Id, @Nome, @SobreNome, @CPF, @CEP, @Endereco, @Num,
                            @Complemento, @Bairro, @Telefone1, @Telefone2, @Email, @Excluir";

                var i = DtaSet(cmmd, param);
                return i;
            }
            catch (SqlException sqlex)
            {
                throw sqlex;
            }
            catch (Exception ex)
            {
                throw ex;
            }
            finally
            {
                Close();
            }
        }
    }
}