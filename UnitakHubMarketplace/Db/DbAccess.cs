using System;
using System.Data.SqlClient;
using System.Data;

namespace UnitakHubMarketplace
{
    public class DbAccess
    {
        string strCon;
        SqlConnection con;
        private enum Operacao { SELECT, INSERT, UPDATE, DELETE }

        public DbAccess()
        {
            new database.Banco_de_Dados();
            strCon = Unitak.Config.VariaveisConn.Instance.ConectionString; //database.variaveis.instance.String_sql;
            con = new SqlConnection(strCon);

        }

        private void Open()
        {
            if (con.State != ConnectionState.Open)
                con.Open();
        }

        private void Close()
        {
            if (con.State != ConnectionState.Closed)
                con.Close();
        }

        private T ExecSql<T>(SqlCommand command, Operacao op)
        {
            try
            {
                if (command.Connection == null)
                    command.Connection = con;
                var ret = new object();
                switch (op)
                {
                    case Operacao.SELECT:
                        command.CommandTimeout = 0;
                        Open();
                        using (SqlDataAdapter da = new SqlDataAdapter(command))
                        {
                            DataTable dt = new DataTable();
                            da.Fill(dt);
                            ret = dt;
                        }
                        Close();
                        break;
                    case Operacao.INSERT:
                        Open();
                        ret = command.ExecuteScalar();
                        Close();
                        break;
                    case Operacao.UPDATE:
                    case Operacao.DELETE:
                        Open();
                        ret = command.ExecuteNonQuery();
                        Close();
                        break;
                    default:
                        break;
                }
                return (T)ret;
            }
            catch (Exception e)
            {
                throw (e);
            }
            finally
            {
                Close();
            }
        }


        public bool ExecCommand(string comando)
        {
            using (SqlCommand cmd = new SqlCommand(comando, con))
            {
                return ExecCommand(cmd);
            }
        }

        public bool ExecCommand(SqlCommand comando)
        {
            try
            {
                Open();
                comando.Connection = con;
                int result = comando.ExecuteNonQuery();

                Close();

                GC.Collect();
                GC.WaitForPendingFinalizers();
                GC.Collect();

                if (result > -1)
                    return true;
                return false;
            }
            catch (Exception e)
            {
                Close();
                throw e;
            }
        }

        public DateTime GetDate()
        {
            DataTable dtData = Select("select GETDATE()");
            return (DateTime)dtData.Rows[0][0];
        }

        ///RETORNA O DATATABLE
        public DataTable Select(SqlCommand cmd)
        {
            return ExecSql<DataTable>(cmd, Operacao.SELECT);
        }

        ///RETORNA O DATATABLE
        public DataTable Select(string sql)
        {
            using (SqlCommand cmd = new SqlCommand(sql, con))
            {
                return ExecSql<DataTable>(cmd, Operacao.SELECT);
            }
        }

        ///RETORNA O ID INSERIDO
        public int Insert(string sql)
        {
            using (SqlCommand cmd = new SqlCommand(sql, con))
            {
                return ExecSql<int>(cmd, Operacao.INSERT);
            }
        }

        ///RETORNA A QTD DE LINHAS AFETADAS
        public int Update(string sql)
        {
            using (SqlCommand cmd = new SqlCommand(sql, con))
            {
                return ExecSql<int>(cmd, Operacao.UPDATE);
            }
        }
    }
}
