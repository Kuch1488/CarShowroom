using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Showroom.Domain.Entities.Interface
{
    public interface IStateElementRepository
    {
        Task<IEnumerable<StateElement>> GetStateElements();
        Task<StateElement> GetStateElement(int id);
        Task<StateElement> Create(StateElement stateElement);
        Task Update(StateElement stateElement);
        Task Delete(int id);
    }
}
