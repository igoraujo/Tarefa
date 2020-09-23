using System.Collections.Generic;
using System.Data;

namespace Store.Data.Service.DatabaseService
{
    public interface IDatabaseService
    {
        DataTable ConvertToInternalTable<T>(List<T> listaParaConverter, string nomeDaTabela);

        string GetTypeName(string text);
    }
}
