using Comm2Tender.Logic.Models;
using Comm2Tender.Logic.Models.Dto;
using Microsoft.AspNetCore.Http;
using System.Collections;

namespace Comm2Tender.Logic
{
    public partial interface ILogicServiceExcel : ILogicService
    {
        #region Excel
        void LoadExcelToDataBase(IFormFile excelFile);
        #endregion Excel
    }
}
