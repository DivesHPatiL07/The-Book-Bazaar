using JwtAuthenticationManager;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using EntityBase;
using Microsoft.AspNetCore.Authorization;
using DbHelper;
using Data_Models;
using View_Models;
using WebApp_Common_Helper;

namespace Admin.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    [Authorize]
    public class MasterController : ControllerBase
    {
        private readonly AppDbContext _context;
        public MasterController(AppDbContext context)
        {
            _context = context;
        }

        [HttpPost]
        [Route("GetBookList")]
        public async Task<ActionResult> GetBookList(GetCustomListParameterModel para)
        {
            BookDbHelper dbHelper = new BookDbHelper(_context);
            BookListDataModel bookList = new BookListDataModel();
            InformationTransaction info = new InformationTransaction();
            bookList = dbHelper.GetBookList(para, out info);
            //EncryptBookIDs(bookList.rows);
            ApiReturnBase rtn = new ApiReturnBase()
            {
                Message = info.Message,
                Success = info.Success,
                Data = bookList
            };
            return Ok(rtn);
        }
        private List<BookDataModel> EncryptBookIDs(List<BookDataModel> bookList)
        {
            foreach (var item in bookList)
            {
                item.ROWIDSTR = EncryptionHelper.EncryptId(item.ROWID);
            }
            return bookList;
        }

        [HttpPost]
        [Route("SaveBook")]
        public async Task<ActionResult> SaveBook(BookSaveModel SaveData)
        {
            BookDbHelper dbHelper = new BookDbHelper(_context);
            InformationTransaction info = new InformationTransaction();
            dbHelper.SaveBook(SaveData, out info);
            //var UserData = await _context.Users.FindAsync(userId);
            ApiReturnBase rtn = new ApiReturnBase()
            {
                Message = info.Message,
                Success = info.Success,
                Data = ""
            };
            return Ok(rtn);
        }

    }
}
