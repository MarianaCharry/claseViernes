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
    public class countryBusiness:ICountryBusiness
    {
        protected readonly ICountryData data;

        public countryBusiness(ICountryData data)
        {
            this.data = data;
        }
        public async Task Delete(int id)
        {
            await this.data.Delete(id);
        }
        public async Task<IEnumerable<countryDto>> GetAll()
        {
            IEnumerable<country> country = await this.data.GetAll();
            var countryDtos = country.Select(country => new countryDto
            {
                Id = country.Id,
                Name = country.Name,
            });
            return countryDtos;
        }
        public async Task<IEnumerable<DataSelectDto>> GetAllSelect()
        {
            return await this.data.GetAllSelect();
        }
        public async Task<countryDto> GetById(int id)
        {
            country country = await this.data.GetById(id);
            countryDto countryDto = new countryDto();

            countryDto.Id = country.Id;
            countryDto.Name = country.Name;
            return countryDto;
        }
        public country mapearDatos(country country, countryDto entity)
        {
            country.Id = entity.Id;
            country.Name = entity.Name;
            return country;
        }
        public async Task<country> Save(countryDto entity)
        {
            country country = new country();
            country.CreateAt = DateTime.Now.AddHours(-5);
            country = this.mapearDatos(country, entity);

            return await this.data.Save(country);
        }
        public async Task Update(countryDto entity)
        {
            country country = await this.data.GetById(entity.Id);
            if (country == null)
            {
                throw new Exception("Registro no encontrado");
            }
            country = this.mapearDatos(country, entity);
            await this.data.Update(country);
        }
    }
}
