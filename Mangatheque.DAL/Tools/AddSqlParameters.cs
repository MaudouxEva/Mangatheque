using System.Data.Common;

namespace Mangatheque.DAL.Tools
{
    // Cette méthode d'extension simplifie l'ajout de paramètres aux commandes SQL. Encapsulation de la création et ajout de paramètres dans une seule méthode
    public static class AddSqlParameters
    {
        public static void AddParamWithValue(this DbCommand cmd, string paramName, Object? value) // this => définit comme méthode d'extension pour DbCommand
        {
            // Création d'un nouvel objet param
            DbParameter param = cmd.CreateParameter();
            param.ParameterName = paramName;
            // Affectation de la valeur du param. Si la valeur est "null", elle est remplacée par "DBNull.Value".
            param.Value = value ?? DBNull.Value;
           // 
            cmd.Parameters.Add(param);
        }
    }
}