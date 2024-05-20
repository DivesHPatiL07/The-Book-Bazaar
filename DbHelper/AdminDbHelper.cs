using Data_Models;
using EntityBase;
using View_Models;

namespace DbHelper
{
    public class AdminDbHelper
    {
        //public User GetDetails(int Id)
        //{
        //    AdminDbService dbService = new AdminDbService();
        //    return dbService.GetDetails(Id);
        //}

        //public void SaveBook(BookSaveModel SaveBook, out InformationTransaction info)
        //{
        //    AdminDbService dbService = new AdminDbService();
        //    dbService.SaveBook(SaveBook, out info);
        //}
        public void SaveAuthor(SaveAuthorModel SaveAuthor, out InformationTransaction info)
        {
            AdminDbService dbService = new AdminDbService();
            dbService.SaveAuthor(SaveAuthor, out info);
        }
        public List<AuthorDataModel> GetAuthorList(out InformationTransaction info)
        {
            AdminDbService dbService = new AdminDbService();
            return dbService.GetAuthorList(out info);
        }
    }
}
