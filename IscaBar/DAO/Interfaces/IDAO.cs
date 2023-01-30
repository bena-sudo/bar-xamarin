using iscaBar.Models;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace iscaBar.DAO.Interfaces
{
    internal interface IDAO<T>
    {
        
        Task<List<T>> GetAllAsync();

        Task<T> AddAsync(T elemento);

        Task<Boolean> UpdateAsync(T elemento);

        Task<Boolean> DeleteAsync(int id);

        
    }
}
