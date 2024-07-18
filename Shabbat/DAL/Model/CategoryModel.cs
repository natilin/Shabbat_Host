using Shabbat.DAL.Repositories;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Shabbat.DAL.Model
{
    public class CategoryModel
    {
        public string? CategoryName {  get; set; }
        public int? CategoryID { get; set; }
        public CategoryModel(string categoryName, int? categoryID = null)
        {
            CategoryName = categoryName;
            CategoryID = categoryID;
        }

        public CategoryModel(DataRow row)
        {
            if (row == null || row["Name"] == null) 
            {
                throw new ArgumentNullException(nameof(row));
            }
            CategoryName = row["Name"].ToString();
            CategoryID = (int)row["ID"];
        }
    }
}
