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
        string TableName { get; }      
        string Values { get; }          
        string InsertColumns { get; }    
        string PrimaryKey { get; }          
        string Join { get; }        

        List<IEntity> GetReaderList(SqlDataReader reader); 
    }
}
