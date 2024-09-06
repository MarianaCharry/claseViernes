using Business.Interface;
using Data.Interfaces;
using Entity.DTO;
using Entity.Model.Security;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business.Implements
{
    public class stateBusiness:IStateBusiness
    {
        protected readonly IStateData data;

        public stateBusiness(IStateData data)
        {
            this.data = data;
        }
        public async Task Delete(int id)
        {
            await this.data.Delete(id);
        }
        public async Task<IEnumerable<stateDto>> GetAll()
        {
            IEnumerable<state> states = await this.data.GetAll();
            var stateDtos = states.Select(state => new stateDto
            {
                Id = state.Id,
                name = state.name
            });
            return stateDtos;
        }
        public async Task<IEnumerable<DataSelectDto>> GetAllSelect()
        {
            return await this.data.GetAllSelect();
        }
        public async Task<stateDto> GetById(int id)
        {
            state state = await this.data.GetById(id);
            stateDto stateDto = new stateDto();

            stateDto.Id = state.Id;
            stateDto.name = state.name;
            return stateDto;
        }
        public state mapearDatos(state state, stateDto entity)
        {
            state.Id = entity.Id;
            state.name = entity.name;
            return state;
        }
        public async Task<state> Save(stateDto entity)
        {
            state state = new state();
            state.CreateAt = DateTime.Now.AddHours(-5);
            state = this.mapearDatos(state, entity);

            return await this.data.Save(state);
        }
        public async Task Update(stateDto entity)
        {
            state state = await this.data.GetById(entity.Id);
            if (state == null)
            {
                throw new Exception("Registro no encontrado");
            }
            state = this.mapearDatos(state, entity);
            await this.data.Update(state);
        }
    }
}
