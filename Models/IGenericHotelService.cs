using System.Collections.Generic;
using System.Threading.Tasks;

namespace HotelManagement.Models
{
    public interface IGenericHotelService<T>
    {
        Task<IEnumerable<T>> GetAllItemsAsync();

        Task<T> GetItemByIdAsync(string id);

        Task CreateItemAsync(T entity);

        Task EditItemAsync(T entity);
        Task DeleteItemAsync(T entity);


    }
}