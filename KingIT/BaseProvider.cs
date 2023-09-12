using System.Data;
using System.Linq;
using System.Text;
using KingIT.ModelDB;
using Microsoft.Data.SqlClient;
using Microsoft.EntityFrameworkCore;

namespace KingIT;

public static class BaseProvider
{
    private static KingITContext dbContext = null!;

    static BaseProvider()
    {
        Update();
    }

    public static KingITContext DbContext
    {
        get => dbContext;

        private set { }
    }

    /// <summary>
    ///     Provide to call stored procedure from DB
    /// </summary>
    /// <param name="procedure"></param>
    /// <param name="parameters"></param>
    /// <returns></returns>
    private static string GetSQLRaw(string procedure, params SqlParameter[] parameters)
    {
        var sqlRequest = new StringBuilder("EXEC ").AppendFormat(@"{0} ", procedure);
        foreach (var parameter in parameters)
        {
            sqlRequest.AppendFormat("@{0}", parameter.ParameterName);
            if (parameter.Direction == ParameterDirection.Output)
                sqlRequest.Append(" OUT");
            if (parameters.LastOrDefault() != parameter)
                sqlRequest.Append(", ");
        }

        return sqlRequest.ToString();
    }

    public static int CallStoredProcedureByName(string procedure, params SqlParameter[] parameters)
    {
        return dbContext.Database.ExecuteSqlRaw(GetSQLRaw(procedure, parameters), parameters);
    }

    public static void Update()
    {
        dbContext = new KingITContext();
    }

    /*public static List<T> GetView<T>(string viewName)
    {
        return dbContext.Database.SqlQuery<T>($"SELECT * from dbo.{viewName}").ToList();
    }*/
}