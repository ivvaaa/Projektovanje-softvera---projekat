using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Data.SqlClient;

namespace Domeni
{
    public interface IEntity
    {
        string TableName { get; }      //ime tabele
        string Values { get; }          //vrednosti za INSERT
        string InsertColumns { get; }    //kolone za INSERT
        string PrimaryKey { get; }          
        string Join { get; }        // Join ako treba

        List<IEntity> GetReaderList(SqlDataReader reader); 
    }
}
