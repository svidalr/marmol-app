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
        Task<IEnumerable<T>> GetAllElements(string entityname);
        Task<T> GetElementById(string id, string entityname);
        Task<string> InsertElement(T element);
        Task<T> UpdateElement(T element, string id, string entityname);
        Task<T> DeleteElementById(string id, string entityname);
        #endregion
    }
}
