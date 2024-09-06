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
    public class cityBusiness:ICityBusiness
    {
        protected readonly ICityData data;

        public cityBusiness(ICityData data)
        {
            this.data = data;
        }
        public async Task Delete(int id)
        {
            await this.data.Delete(id);
        }
        public async Task<IEnumerable<cityDto>> GetAll()
        {
            IEnumerable<city> city = await this.data.GetAll();
            var cityDtos = city.Select(city => new cityDto
            {
                Id = city.Id,
                name = city.name
            });
            return cityDtos;
        }
        public async Task<IEnumerable<DataSelectDto>> GetAllSelect()
        {
            return await this.data.GetAllSelect();
        }
        public async Task<cityDto> GetById(int id)
        {
            city city = await this.data.GetById(id);
            cityDto cityDto = new cityDto();

            cityDto.Id = city.Id;
            cityDto.name = city.name;
            return cityDto;
        }
        public city mapearDatos(city city, cityDto entity)
        {
            city.Id = entity.Id;
            city.name = entity.name;
            return city;
        }
        public async Task<city> Save(cityDto entity)
        {
            city city = new city();
            city.CreateAt = DateTime.Now.AddHours(-5);
            city = this.mapearDatos(city, entity);

            return await this.data.Save(city);
        }
        public async Task Update(cityDto entity)
        {
            city city = await this.data.GetById(entity.Id);
            if (city == null)
            {
                throw new Exception("Registro no encontrado");
            }
            city = this.mapearDatos(city, entity);
            await this.data.Update(city);
        }
    }
}
