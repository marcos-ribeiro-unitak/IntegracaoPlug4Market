using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using UnitakHubMarketplace.Models.Plug4Market;
using static System.Windows.Forms.VisualStyles.VisualStyleElement.TreeView;

namespace UnitakHubMarketplace.Db
{
    public class DbClientes
    {
        SqlConnection conn;
        string sql = "select top(0) * from Clientes;";
        DbAccess db;

        public DbClientes()
        {
            db = new DbAccess();
            new database.Banco_de_Dados();
            conn = new SqlConnection(Unitak.Config.VariaveisConn.Instance.ConectionString);// database.variaveis.instance.String_sql);
        }

        public DataTable GetCliente(string documento)
        {
            StringBuilder sb = new StringBuilder();
            sb.Append("select * from Clientes ");
            sb.Append("where (CNPJ_CPF = '" + documento + "' ");
            sb.Append("or REPLACE(REPLACE(REPLACE(CNPJ_CPF, '.',''),'-',''),'/','') = '" + documento + "') and Exclusao is null");

            return db.Select(sb.ToString());
        }

        private DataTable GetClienteEnd(string idCliente)
        {
            StringBuilder sb = new StringBuilder();
            sb.Append("select * from Clientes_End ");
            sb.Append("where ID_Cliente = " + idCliente + " ");

            return db.Select(sb.ToString());
        }

        public string GetUF(string uf)
        {
            StringBuilder sb = new StringBuilder();
            sb.Append("select uf from Estado where estado = '" + uf + "'");

            DataTable dtUF = db.Select(sb.ToString());
            if (dtUF.Rows.Count > 0)
                return dtUF.Rows[0][0].ToString();
            return "";
        }
        public int GetIDUF(string uf)
        {
            StringBuilder sb = new StringBuilder();
            sb.Append("select ID_UF from Estado where estado = '" + uf + "'");

            DataTable dtUF = db.Select(sb.ToString());
            if (dtUF.Rows.Count > 0)
                return int.Parse(dtUF.Rows[0][0].ToString());
            return 0;
        }

        private int GetNextId()
        {
            StringBuilder sb = new StringBuilder();
            sb.Append("select ISNULL(MAX(ID_cliente), 0) + 1 from Clientes ");

            DataTable dtID = db.Select(sb.ToString());
            if (dtID.Rows.Count > 0)
                return int.Parse(dtID.Rows[0][0].ToString());
            return -1;
        }
        private int GetNextIdEnd()
        {
            StringBuilder sb = new StringBuilder();
            sb.Append("select ISNULL(MAX(ID_cliente_End), 0) + 1 from Clientes_End ");

            DataTable dtID = db.Select(sb.ToString());
            if (dtID.Rows.Count > 0)
                return int.Parse(dtID.Rows[0][0].ToString());
            return -1;
        }

        public DataTable GravarCliente(Order cobranca)
        {
            DataTable dtCliente = GetCliente(cobranca.billing.documentId);
            DataTable dtClienteEnd = new DataTable();

            dtCliente.TableName = "Clientes";
            string uf = cobranca.billing.state;// GetUF(cobranca.billing.state).ToUpper();
            bool clienteNovo;
            if (dtCliente.Rows.Count == 0)
            {
                clienteNovo = true;
                int idClienteNovo = GetNextId();

                dtCliente.Rows.Add();
                dtCliente.Rows[0]["ID_Cliente"] = idClienteNovo;
                //dtCliente.Rows[0]["ID_Cliente_End"] = 0;
                dtCliente.Rows[0]["ID_Empresa"] = 1;
                dtCliente.Rows[0]["ID_UF"] = GetIDUF(cobranca.billing.state);
                dtCliente.Rows[0]["ID_Cidade"] = 0;
                dtCliente.Rows[0]["Limite_de_Credito"] = 0;
                dtCliente.Rows[0]["Situacao"] = "Liberado";
            }
            else
            {
                clienteNovo = false;
                dtClienteEnd = GetClienteEnd(dtCliente.Rows[0]["ID_Cliente"].ToString());
            }

            dtCliente.Rows[0]["Nome"] = (cobranca.billing.name).ToUpper();
            dtCliente.Rows[0]["CNPJ_CPF"] = (cobranca.billing.documentId == null || cobranca.billing.documentId == "") ? "" : (cobranca.billing.documentId).ToUpper();
            dtCliente.Rows[0]["Fone"] = (cobranca.billing.phone == null) ? "" : cobranca.billing.phone.ToUpper();

            //CASO O CADASTRO DO CLIENTE NO SISTEMA ESTEJA SEM ENDEREÇO PREENCHIDO
            if (string.IsNullOrWhiteSpace(dtCliente.Rows[0]["CEP"].ToString()) || string.IsNullOrWhiteSpace(dtCliente.Rows[0]["Numero"].ToString()))
            {
                dtCliente.Rows[0]["CEP"] = (cobranca.billing.zipCode == null || cobranca.billing.zipCode == "") ? "" : (cobranca.billing.zipCode).ToUpper();
                dtCliente.Rows[0]["Numero"] = (cobranca.billing.streetNumber == null) ? "" : cobranca.billing.streetNumber.ToUpper();
                dtCliente.Rows[0]["Endereco"] = cobranca.billing.street.ToUpper();
                dtCliente.Rows[0]["Complemento"] = (cobranca.billing.streetComplement == null) ? "" : cobranca.billing.streetComplement.ToUpper();
                dtCliente.Rows[0]["Bairro"] = (cobranca.billing.district == null) ? "" : cobranca.billing.district.ToUpper();
                dtCliente.Rows[0]["UF"] = (cobranca.billing.state == null || cobranca.billing.state == "") ? "" : cobranca.billing.state;
                dtCliente.Rows[0]["Cidade"] = cobranca.billing.city.ToUpper();
            }
            //CASO O CADASTRO DO SISTEMA CONTENHA O MESMO ENDEREÇO DO SITE ELE SÓ ATUALIZA
            else if (dtCliente.Rows[0]["CEP"].ToString() == cobranca.billing.zipCode && dtCliente.Rows[0]["Numero"].ToString() == cobranca.billing.streetNumber)
            {
                dtCliente.Rows[0]["CEP"] = (cobranca.billing.zipCode == null || cobranca.billing.zipCode == "Não informado") ? "" : cobranca.billing.zipCode.ToUpper();
                dtCliente.Rows[0]["Numero"] = (cobranca.billing.streetNumber == null) ? "" : cobranca.billing.streetNumber.ToUpper();
                dtCliente.Rows[0]["Endereco"] = cobranca.billing.street.ToUpper();
                dtCliente.Rows[0]["Complemento"] = (cobranca.billing.streetComplement == null) ? "" : cobranca.billing.streetComplement.ToUpper();
                dtCliente.Rows[0]["Bairro"] = (cobranca.billing.district == null) ? "" : cobranca.billing.district.ToUpper();
                dtCliente.Rows[0]["UF"] = (cobranca.billing.state == null || cobranca.billing.state != "") ? "" : cobranca.billing.state;
                dtCliente.Rows[0]["Cidade"] = cobranca.billing.city.ToUpper();
            }
            //CASO CLIENTE JÁ EXISTA E NÃO CAIU NAS CONDIÇOES ACIMA
            else if (!clienteNovo)
            {
                //CASO O CLIENTE NÃO TENHA OUTROS ENDEREÇOS CADASTRADOS
                if (dtClienteEnd.Rows.Count == 0)
                {
                    int idClienteEnd = GetNextIdEnd();
                    dtClienteEnd.Rows.Add();

                    dtClienteEnd.Rows[0]["ID_Cliente_End"] = idClienteEnd;
                    dtClienteEnd.Rows[0]["ID_Cliente"] = dtCliente.Rows[0]["ID_Cliente"];
                    dtClienteEnd.Rows[0]["CEP"] = (cobranca.billing.zipCode == null || cobranca.billing.zipCode == "Não informado") ? "" : cobranca.billing.zipCode.ToUpper();
                    dtClienteEnd.Rows[0]["Numero"] = (cobranca.billing.streetNumber == null) ? "" : cobranca.billing.streetNumber.ToUpper();
                    dtClienteEnd.Rows[0]["Endereco"] = cobranca.billing.street.ToUpper();
                    dtClienteEnd.Rows[0]["Complemento"] = (cobranca.billing.streetComplement == null) ? "" : cobranca.billing.streetComplement.ToUpper();
                    dtClienteEnd.Rows[0]["Bairro"] = (cobranca.billing.district == null) ? "" : cobranca.billing.district.ToUpper();
                    dtClienteEnd.Rows[0]["UF"] = (cobranca.billing.state == null || cobranca.billing.state.Contains("Não informado")) ? "" : cobranca.billing.state;
                    dtClienteEnd.Rows[0]["Cidade"] = cobranca.billing.city.ToUpper();
                }
                //CASO TENHA VÁRIOS ENDEREÇOS CADASTRADOS ELE ATUALIZA SOMENTE O QUE CONTER O MESMO CEP E NUMERO
                else
                {
                    for (int i = 0; i < dtClienteEnd.Rows.Count; i++)
                    {
                        if (cobranca.billing.zipCode == dtClienteEnd.Rows[i]["CEP"].ToString() && cobranca.billing.streetNumber == dtClienteEnd.Rows[i]["Numero"].ToString())
                        {
                            dtClienteEnd.Rows[i]["CEP"] = (cobranca.billing.zipCode == null || cobranca.billing.zipCode == "Não informado") ? "" : cobranca.billing.zipCode.ToUpper();
                            dtClienteEnd.Rows[i]["Numero"] = (cobranca.billing.streetNumber == null) ? "" : cobranca.billing.streetNumber.ToUpper();
                            dtClienteEnd.Rows[i]["Endereco"] = cobranca.billing.street.ToUpper();
                            dtClienteEnd.Rows[i]["Complemento"] = (cobranca.billing.streetComplement == null) ? "" : cobranca.billing.streetComplement.ToUpper();
                            dtClienteEnd.Rows[i]["Bairro"] = (cobranca.billing.district == null) ? "" : cobranca.billing.district.ToUpper();
                            dtClienteEnd.Rows[i]["UF"] = (cobranca.billing.state == null || cobranca.billing.state.Contains("Não informado")) ? "" : cobranca.billing.state;
                            dtClienteEnd.Rows[i]["Cidade"] = cobranca.billing.city.ToUpper();
                        }
                    }
                }

                SqlDataAdapter daCliEnd = new SqlDataAdapter("select top(0) * from Clientes_End;", conn);
                SqlCommandBuilder cmdEnd = new SqlCommandBuilder(daCliEnd);
                int retEnd = daCliEnd.Update(dtClienteEnd);
                cmdEnd.Dispose();
                daCliEnd.Dispose();
            }

            SqlDataAdapter daCli = new SqlDataAdapter(sql, conn);
            SqlCommandBuilder cmd = new SqlCommandBuilder(daCli);
            int ret = daCli.Update(dtCliente);
            cmd.Dispose();
            daCli.Dispose();

            if (ret > 0)
                return dtCliente;
            else
                return null;
        }
    }
}
