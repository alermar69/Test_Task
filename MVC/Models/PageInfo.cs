namespace MVC.Models
{
    public class PageInfo
    {
        public int CountEmployees { get; set; }
        public int CountEmployeesPage { get; set; }
        public int CurrentPage { get; set; }
        public int CountPages
        {
            get
            {
               int count =  CountEmployees / CountEmployeesPage;
               if ((CountEmployees % CountEmployeesPage) != 0) count++;
               return count;
            }
        }

    }
}