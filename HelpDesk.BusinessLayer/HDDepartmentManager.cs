using HelpDesk.DataAccesLayer;
using HelpDesk.Entities;

namespace HelpDesk.BusinessLayer
{
    public class HDDepartmentManager
    {
        private HDRepository<HDDepartmentCategory> repo_dep_cat = new HDRepository<HDDepartmentCategory>();

        public string GetDepartment(int id)
        {
            HDDepartmentCategory dep = repo_dep_cat.Find(x => x.Id == id);
            return dep.Title;
        }
    }
}