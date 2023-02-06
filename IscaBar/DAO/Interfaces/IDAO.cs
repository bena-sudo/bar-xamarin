using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace IscaBar.DAO.Interfaces
{
    internal interface IDAO<T>
    {
        
        Task<List<T>> GetAllAsync();

        Task<T> AddAsync(T elemento);

        Task<Boolean> UpdateAsync(T elemento);

        Task<Boolean> DeleteAsync(int id);

        
    }
}
