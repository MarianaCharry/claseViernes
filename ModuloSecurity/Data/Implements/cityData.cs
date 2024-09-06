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
    public class cityData:ICityData
    {
        private readonly ApplicationDBContext context;
        protected readonly IConfiguration configuration;

        public cityData(ApplicationDBContext context, IConfiguration configuration)
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
            context.city.Update(entity);
            await context.SaveChangesAsync();
        }
        public async Task<IEnumerable<DataSelectDto>> GetAllSelect()
        {
            var sql = @"SELECT
                Id,
                CONCAT(Name, '-', name) AS TextoMostrar
                FROM
                city
                WHERE DeletedAt IS NULL AND State = 1
                ORDER BY Id ASC";
            return await context.QueryAsync<DataSelectDto>(sql);

        }
        public async Task<city> GetById(int id)
        {
            var sql = @"SELECT * FROM city WHERE Id = @Id ORDER BY Id ASC";
            return await this.context.QueryFirstOrDefaultAsync<city>(sql, new { Id = id });
        }
        public async Task<city> Save(city entity)
        {
            context.city.Add(entity);
            await context.SaveChangesAsync();
            return entity;
        }
        public async Task Update(city entity)
        {
            context.Entry(entity).State = Microsoft.EntityFrameworkCore.EntityState.Modified;
            await context.SaveChangesAsync();
        }
        public async Task<city> GetByName(string name)
        {
            return await this.context.city.AsNoTracking().Where(item => item.name == name).FirstOrDefaultAsync();
        }
        public async Task<IEnumerable<city>> GetAll()
        {
            var sql = @"SELECT * FROM city ORDER BY Id ASC";
            return await this.context.QueryAsync<city>(sql);
        }

    }
}