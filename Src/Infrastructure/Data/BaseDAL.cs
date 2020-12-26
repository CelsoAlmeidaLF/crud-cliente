using System;
using System.Data;
using System.Data.SqlClient;

namespace Almeida.Infrastructure.Data
{
    public class BaseDAL
    {
        protected SqlConnection conn = null;
        protected SqlCommand cmmd = null;

        private SqlConnection _Open()
        {
            string conString = $@"Data Source=CELSO-PC; 
                        Initial Catalog=BD_DEMO; 
                        Persist Security Info=True; 
                        User ID=Admin; 
                        Password=35316Ji@";

            conn = new SqlConnection(conString);
            if (conn.State == ConnectionState.Closed) { conn.Open(); }
            return conn;
        }

        public DataTable DtaTbGet(string cmdText)
        {
            DataTable dt = new DataTable();
            cmmd = new SqlCommand(cmdText, _Open());
            SqlDataAdapter da = new SqlDataAdapter(cmmd);
            da.Fill(dt);
            return dt;
        }

        public int DtaSet(string cmdText, SqlParameter[] parameters)
        {
            cmmd = new SqlCommand(cmdText, _Open());

            cmmd.Parameters.Clear();

            if (parameters != null)
                cmmd.Parameters.AddRange(parameters);

            //cmmd.CommandType = CommandType.StoredProcedure;
            cmmd.CommandText = cmdText;

            cmmd.ExecuteNonQuery();

            return 0;
        }

        public void Close() { if (conn.State == ConnectionState.Open) { conn.Close(); }  }

        /// <summary>
        /// Monta os parâmetros para execução da Stored Procedure.
        /// </summary>
        /// <param name="item">Indice do parâmetro</param>
        /// <param name="parametros">array de parâmetro a ser montado</param>
        /// <param name="direction">Direção do parametro(input/output)</param>
        /// <param name="nome">Nome do parametro(@id)</param>
        /// <param name="valor">Valor do parametro</param>
        /// <param name="dbType">Tipo de dado do parametro</param>
        protected void MontarParametro
            (int item, SqlParameter[] parametros, ParameterDirection direction,
                string nome, object valor, SqlDbType dbType)
        {
            parametros[item] = new SqlParameter();
            parametros[item].Direction = direction;
            parametros[item].ParameterName = nome;
            parametros[item].SqlDbType = dbType;
            if (valor == null)
                valor = DBNull.Value;
            parametros[item].SqlValue = valor;
        }

        /// <summary>
        /// Retorna o valor do parâmetro ou DBNull caso o objeto seja nulo
        /// </summary>
        /// <typeparam name="T">Tipo para o caso de parâmetros NULLABLE</typeparam>
        /// <param name="n">O parâmetro NULLABLE</param>
        /// <returns>O valor do parâmetro ou DBNull </returns>
        public static object ObterValorOuDBNull<T>(Nullable<T> n) where T : struct
        {
            if (n.HasValue)
                return n.Value;
            else
                return DBNull.Value;
        }
    }
}
