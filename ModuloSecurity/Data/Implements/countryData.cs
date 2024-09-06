using Data.Interfaces;
using Entity.Context;
using Entity.DTO;
using Entity.Model.Security;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Data.Implements
{
    public class countryData:ICountryData
    {
        private readonly ApplicationDBContext context;
        protected readonly IConfiguration configuration;

        public countryData(ApplicationDBContext context, IConfiguration configuration)
        {
            this.context = context;
            this.configuration = configuration;
        }
        public async Task Delete(int id)
        {
            var entity = await GetById(id);
            if (entity == null)
            {
                throw new Exception("Registro no encontrado");
            }
            entity.DeleteAt = DateTime.Parse(DateTime.Today.ToString());
            context.country.Update(entity);
            await context.SaveChangesAsync();
        }
        public async Task<IEnumerable<DataSelectDto>> GetAllSelect()
        {
            var sql = @"SELECT
                Id,
                CONCAT(Name, '-', Name) AS TextoMostrar
                FROM
                country
                WHERE DeletedAt IS NULL AND State = 1
                ORDER BY Id ASC";
            return await context.QueryAsync<DataSelectDto>(sql);

        }
        public async Task<country> GetById(int id)
        {
            var sql = @"SELECT * FROM country WHERE Id = @Id ORDER BY Id ASC";
            return await this.context.QueryFirstOrDefaultAsync<country>(sql, new { Id = id });
        }
        public async Task<country> Save(country entity)
        {
            context.country.Add(entity);
            await context.SaveChangesAsync();
            return entity;
        }
        public async Task Update(country entity)
        {
            context.Entry(entity).State = Microsoft.EntityFrameworkCore.EntityState.Modified;
            await context.SaveChangesAsync();
        }
        public async Task<country> GetByName(string Name)
        {
            return await this.context.country.AsNoTracking().Where(item => item.Name == Name).FirstOrDefaultAsync();
        }
        public async Task<IEnumerable<country>> GetAll()
        {
            var sql = @"SELECT * FROM country ORDER BY Id ASC";
            return await this.context.QueryAsync<country>(sql);
        }

    }
}

