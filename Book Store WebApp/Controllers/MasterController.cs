using Data_Models;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json.Linq;
using System.Collections.Generic;
using System.Net.Http.Headers;
using View_Models;
using WebApp_Common_Helper;

namespace Book_Store_WebApp.Controllers
{
    public class MasterController : Controller
    {
        public IActionResult BookList()
        {
            return View();
        }

        [HttpGet]
        public async Task<BookListDataModel> GetBookList(string search, string sort, string order, int offset, int limit)
        {
            BookListDataModel rtnValues = new BookListDataModel();
            HttpClientHandler clientHandler = new HttpClientHandler();
            clientHandler.ServerCertificateCustomValidationCallback = (sender, cert, chain, sslPolicyErrors) => { return true; };
            using (var client = new HttpClient())
            {
                client.BaseAddress = new Uri(AppSettings.GateWayUrl + "master/");
                GetCustomListParameterModel obj = new GetCustomListParameterModel();

                obj.TableName = "MS_VW_BOOKS";
                obj.ColumnsToSelect = "ROWID, TITLE, AUTHOR, GENRE, DESCRIPTION, PRICE, PUBLICATIONDATEDISP, LANGUAGE, PUBLISHER, AVAILABILITY, RATING, DISCOUNT, TAGS";


                if (!string.IsNullOrEmpty(search))
                {
                    string where = "";
                    CommanWebService.whereClause("TITLE", search, ref where);
                    CommanWebService.whereClause("AUTHOR", search, ref where);
                    CommanWebService.whereClause("GENRE", search, ref where);
                    CommanWebService.whereClause("DESCRIPTION", search, ref where);
                    CommanWebService.whereClause("PRICE", search, ref where);
                    CommanWebService.whereClause("PUBLICATIONDATEDISP", search, ref where);
                    CommanWebService.whereClause("LANGUAGE", search, ref where);
                    CommanWebService.whereClause("PUBLISHER", search, ref where);
                    CommanWebService.whereClause("AVAILABILITY", search, ref where);
                    CommanWebService.whereClause("RATING", search, ref where);
                    CommanWebService.whereClause("DISCOUNT", search, ref where);
                    CommanWebService.whereClause("TAGS", search, ref where);
                    obj.WhereCondition = where;
                }
                else
                {
                    obj.WhereCondition = "";
                }
                obj.PageSize = limit == 0 ? 10000 : limit;
                obj.PageNumber = offset == 0 ? 1 : (offset / limit) + 1;
                obj.OrderByColumn = sort == null ? "ROWID" : sort;
                obj.SortOrder = order == null ? "ASC" : order;


                var content = new StringContent(Newtonsoft.Json.JsonConvert.SerializeObject(obj).ToString(), System.Text.Encoding.UTF8, "application/json");
                client.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", Request.Cookies["bookBazaarAuth"].ToString());

                var result = await client.PostAsync("GetBookList", content);

                if (result.IsSuccessStatusCode)
                {
                    var readTask = result.Content.ReadFromJsonAsync<ApiReturnBase>();

                    rtnValues = Newtonsoft.Json.JsonConvert.DeserializeObject<BookListDataModel>(readTask.Result.Data.ToString() ??) ?? new BookListDataModel();

                }
                else
                {
                    throw new Exception(result.ReasonPhrase);
                }
            }

            return rtnValues;
        }

        public IActionResult AddBook()
        {
            return View();
        }

        public string SaveBook()
        {
            AuthorListDataModel rtnValues = new AuthorListDataModel();
            HttpClientHandler clientHandler = new HttpClientHandler();
            clientHandler.ServerCertificateCustomValidationCallback = (sender, cert, chain, sslPolicyErrors) => { return true; };
            using (var client = new HttpClient())
            {
                client.BaseAddress = new Uri(AppSettings.GateWayUrl + "master/");
                BookSaveModel modal = new BookSaveModel();
                string inputTitleOfBook = Request.Form["inputTitleOfBook"];
                string ddlAuthor = Request.Form["ddlAuthor"];
                string inputGenre = Request.Form["inputGenre"];
                string inputLanguage = Request.Form["inputLanguage"];
                string inputPublicationDate = Request.Form["inputPublicationDate"];
                string inputPublisher = Request.Form["inputPublisher"];
                string inputPrice = Request.Form["inputPrice"];
                string inputDiscount = Request.Form["inputDiscount"];
                IFormFile formFile = Request.Form.Files["formFile"];
                string inputAvailability = Request.Form["inputAvailability"];

                modal.TITLE = inputTitleOfBook;
                modal.AUTHOR = ddlAuthor;
                modal.GENRE = inputGenre;
                modal.LANGUAGE = inputLanguage;
                modal.PUBLICATIONDATE = DateUtility.MakeDateTime(inputPublicationDate);
                modal.PUBLISHER = inputPublisher;
                modal.PRICE = Convert.ToDecimal(inputPrice);
                modal.DISCOUNT = Convert.ToDecimal(inputDiscount);
                modal.COVERIMAGEURL = formFile.FileName;
                modal.AVAILABILITY = Convert.ToInt16(inputAvailability);
                modal.ACTION = 'I';
                var content = new StringContent(Newtonsoft.Json.JsonConvert.SerializeObject(modal).ToString(), System.Text.Encoding.UTF8, "application/json");

                client.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", Request.Cookies["bookBazaarAuth"].ToString());

                //client.DefaultRequestHeaders.Add("Authorization", Request.Cookies["bookBazaarAuth"].ToString());

                var responseTask = client.PostAsync("SaveBook", content);

                responseTask.Wait();
                var result = responseTask.Result;
                if (result.IsSuccessStatusCode)
                {
                    var readTask = result.Content.ReadFromJsonAsync<ApiReturnBase>();


                    //List<AuthorDataModel> dModel = Newtonsoft.Json.JsonConvert.DeserializeObject<List<AuthorDataModel>>(readTask.Result.Data.ToString());
                    //rtnValues.rows = dModel;
                    //rtnValues.total = dModel.Count;

                }
                else
                {
                    throw new Exception(result.ReasonPhrase);
                }
            }

            return "rtnValues";
        }


        public IActionResult Author()
        {
            return View();
        }

    }
}
