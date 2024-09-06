using Data.Interfaces;
using Entity.Context;
using Entity.DTO;
using Entity.Model.Security;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;


namespace Data.Implements
{
    public class RoleViewData : IRoleViewData
    {
        private readonly ApplicationDBContext context;
        protected readonly IConfiguration configuration;

        public RoleViewData(ApplicationDBContext context, IConfiguration configuration)
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
            context.RoleViews.Update(entity);
            await context.SaveChangesAsync();
        }
        public async Task<IEnumerable<DataSelectDto>> GetAllSelect()
        {
            var sql = @"SELECT
                Id,
                CONCAT(Name, '-', Description) AS TextoMostrar
                FROM
                RoleView
                WHERE DeletedAt IS NULL AND State = 1
                ORDER BY Id ASC";
            return await context.QueryAsync<DataSelectDto>(sql);

        }
        public async Task<RoleView> GetById(int id)
        {
            var sql = @"SELECT * FROM RoleView WHERE Id = @Id ORDER BY Id ASC";
            return await this.context.QueryFirstOrDefaultAsync<RoleView>(sql, new { Id = id });
        }
        public async Task<RoleView> Save(RoleView entity)
        {
            context.RoleViews.Add(entity);
            await context.SaveChangesAsync();
            return entity;
        }
        public async Task Update(RoleView entity)
        {
            context.Entry(entity).State = Microsoft.EntityFrameworkCore.EntityState.Modified;
            await context.SaveChangesAsync();
        }
        public async Task<RoleView> GetByName(int id)
        {
            return await this.context.RoleViews.AsNoTracking().Where(item => item.Id == id).FirstOrDefaultAsync();
        }
        public async Task<IEnumerable<RoleView>> GetAll()
        {
            var sql = @"SELECT * FROM RoleView ORDER BY Id ASC";
            return await this.context.QueryAsync<RoleView>(sql);
        }

    }
}

