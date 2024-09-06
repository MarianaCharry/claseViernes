using Business.Interface;
using Data.Interfaces;
using Entity.DTO;
using Entity.Model.Security;

namespace Business.Implements
{
    public class RoleBusiness : IRoleBusiness
    {
        protected readonly IRoleData data;

        public RoleBusiness(IRoleData data)
        {
            this.data = data;
        }
        public async Task Delete(int id)
        {
            await this.data.Delete(id);
        }
        public async Task<IEnumerable<RoleDto>>GetAll()
        {
            IEnumerable<Role> roles = await this.data.GetAll();
            var roleDtos = roles.Select(role => new RoleDto
            {
                Id = role.Id,
                Name = role.Name,
                Description = role.Description,
                State = role.State,

            });
            return roleDtos;
        }
        public async Task<IEnumerable<DataSelectDto>>GetAllSelect()
        {
            return await this.data.GetAllSelect();
        }
        public async Task<RoleDto>GetById(int id)
        {
            Role role = await this.data.GetById(id);
            RoleDto roleDto=new RoleDto();

            roleDto.Id = id;
            roleDto.Name = role.Name;
            roleDto.Description = role.Description;
            roleDto.State = role.State;
            return roleDto;
        }
        public Role mapearDatos(Role role, RoleDto entity)
        {
            role.Id = entity.Id;
            role.Name = entity.Name;
            role.Description = entity.Description;
            role.State = entity.State;
            return role;
        }
        public async Task<Role>Save(RoleDto entity)
        {
            Role role = new Role();
            role.CreateAt = DateTime.Now.AddHours(-5);
            role = this.mapearDatos(role, entity);

            return await this.data.Save(role);

        }
        public async Task Update(RoleDto entity)
        {
            Role role = await this.data.GetById(entity.Id);
            if (role == null)
            {
                throw new Exception("Registro no encontrado");
            }
            role = this.mapearDatos(role, entity);
            await this.data.Update(role);
        }

    }
}
