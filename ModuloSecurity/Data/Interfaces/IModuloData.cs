using Entity.DTO;
using Entity.Model.Security;

namespace Data.Interfaces
{
    public interface IModuloData
    {
        public Task Delete(int id);
        public Task<Modulo> GetById(int id);
        public Task<Modulo> Save(Modulo entity);
        public Task Update(Modulo entity);
        public Task<IEnumerable<Modulo>> GetAll();
        public Task<Modulo> GetByName(string description);
        Task<IEnumerable<DataSelectDto>> GetAllSelect();
    }
}