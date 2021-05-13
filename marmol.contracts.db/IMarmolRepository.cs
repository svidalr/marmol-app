using MarmolApp.Model;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace marmol.contracts.db
{
    public interface IMarmolRepository<T> where T : EntityBase
    {
        #region Crud Operation
        Task<IEnumerable<T>> GetAllElements();
        Task<T> GetElementById(string id, string entityname);
        Task<string> InsertElement(T element);
        Task<T> UpdateElement(T element); 
        #endregion
    }
}
