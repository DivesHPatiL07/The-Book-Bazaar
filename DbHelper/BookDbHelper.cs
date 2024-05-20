using Data_Models;
using EntityBase;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using View_Models;

namespace DbHelper
{
    public class BookDbHelper
    {
        private readonly AppDbContext _context;
        public BookDbHelper(AppDbContext context)
        {
            _context = context;
        }
        public BookListDataModel GetBookList(GetCustomListParameterModel para, out InformationTransaction info)
        {
            BookDbService dbService = new BookDbService(_context);
            return dbService.GetBookList(para, out info);
        }
        public void SaveBook(BookSaveModel para, out InformationTransaction info)
        {
            BookDbService dbService = new BookDbService(_context);
            dbService.SaveBook(para, out info);
        }
    }
}
