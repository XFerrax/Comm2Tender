using Comm2Tender.Logic.Models;
using Comm2Tender.Logic.Models.Dto;
using Microsoft.AspNetCore.Http;
using System.Collections;
using System.IO;

namespace Comm2Tender.Logic
{
    public partial interface ILogicServiceExcel : ILogicService
    {
        
        #region Excel
        void LoadExcelToDataBase(IFormFile excelFile);

        byte[] GetExcelReport(int id);
        #endregion Excel
    }
}
