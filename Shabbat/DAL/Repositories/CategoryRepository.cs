using Shabbat.DAL.Model;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Shabbat.DAL.Repositories
{
    public class CategoryRepository: IRepository<CategoryModel>
    {
        private readonly DBContext _dbContext;
        public CategoryRepository(DBContext DBContest)
        { 
        _dbContext = DBContest;
        }
        public List<CategoryModel> FindAll()
        {
            var categories = new List<CategoryModel>();
            string query = "Select * From Categories";
            DataTable result = _dbContext.ExecuteQuery(query);
            foreach (DataRow row in result.Rows)
            {
                categories.Add(new CategoryModel(row));
            }
            return categories;
        }
        public CategoryModel FindById(int id)
        {
            string query = "SELECT * From Categories WHERE ID = @ID";
            SqlParameter[] parameters = { new SqlParameter("@ID", id) };
            DataTable result = _dbContext.ExecuteQuery(query, parameters);
            if(result.Rows.Count == 0)
            {
                return null;
            }
            return new CategoryModel(result.Rows[0]);
        }
        public bool Insert(CategoryModel category)
        {
            string query = "INSERT INTO Categories (Name) VALUES (@Name)";
            SqlParameter[] parameters = { new SqlParameter("@Name", category.CategoryName) };
            int rowAffected = _dbContext.ExecuteNonQuery(query, parameters);

            return rowAffected > 0;
        }

        public bool Delete(int id)
        {
            string query = "DELETE FROM Categories  WHERE ID = @ID";
            SqlParameter[] parameters = { new SqlParameter("@ID", id) };
            int rowAffected = _dbContext.ExecuteNonQuery(query, parameters);
            return rowAffected > 0;
        }
    }
}
