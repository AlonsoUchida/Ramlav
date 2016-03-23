using System;
using System.Data;
using System.Configuration;
using System.Web;
using System.Web.Security;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Web.UI.WebControls.WebParts;
using System.Web.UI.HtmlControls;
using System.Collections.Generic;
using System.Data.SqlClient;

using Login;

namespace Login
{

public class Access
{

    public Access()
	{
	}

   

    #region Helpers

    public static SqlDataReader FPS_ExecSPReturnReader(string procedimientoalmacenado, Object[,] Parms)
    {
        SqlDataReader reader;
        try
        {
            using (SqlCommand command = new SqlCommand(procedimientoalmacenado, Conex.GetConnection()))
            {
                command.CommandType = CommandType.StoredProcedure;
                FPT_LoadParameters(command, Parms);
                reader = command.ExecuteReader(CommandBehavior.SingleResult | CommandBehavior.CloseConnection);
            }
            return reader;
        }
        catch { throw; }
    }

    private static void FPT_LoadParameters(SqlCommand Comando, Object[,] Parms)
    {
        int i;
        {
            for (i = Parms.GetLowerBound(0); i <= Parms.GetUpperBound(0); i++)
            {
                SqlParameter Par = new SqlParameter();
                Par.ParameterName = (string)Parms[i, 0];
                Par.SqlDbType = (SqlDbType)Parms[i, 1];
                Par.Size = (Int32)Parms[i, 2];
                Par.Value = (object)Parms[i, 3];
                Comando.Parameters.Add(Par);
            }
        }
    }
    #endregion

}
}
