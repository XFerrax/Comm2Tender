using ClosedXML.Excel;
using Comm2Tender.Logic.Constants;
using Comm2Tender.Logic.Models;
using Comm2Tender.Logic.Models.Dto;
using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;

namespace Comm2Tender.Logic
{
    public partial class LogicService : ILogicServiceExcel
    {
        #region Excel
        public void LoadExcelToDataBase(IFormFile excelFile)
        {

            var excelFileTenders = ParseExcelFile(excelFile);

            EnsureExcelTableIsValid(excelFileTenders);

            excelFileTenders = RemoveHeaders(excelFileTenders);

            var percentDictionary = DataService.GetLastPercentsDictionary();

            var listRequest = new ListRequest();
            

            foreach (var excelFileTender in excelFileTenders)
            {
                var tender = new Tender();
                tender.Number = excelFileTender.Number;
                tender.Discription = excelFileTender.Discription;
                tender.PercentsDictionary = percentDictionary;

                var tenderId = DataService.AddTender(tender);

                listRequest.Search = excelFileTender.AgentName;

                var proposal = new Proposal();
                proposal.Tender = DataService.GetTender(tenderId);
                proposal.PositionPrice = decimal.Parse(excelFileTender.PositionPrice);
                proposal.Agent = DataService.SearchAgent(listRequest).listRequest.First();
                proposal.User = DataService.GetUser(GetUserId());

                DataService.AddProposal(proposal);

            }
        }

        private List<ExcelFileTender> ParseExcelFile(IFormFile excelFile)
        {
            var excelFileTenders = new List<ExcelFileTender>();

            using (var memoryStream = new MemoryStream())
            {
                excelFile.CopyTo(memoryStream);

                using (var workBook = new XLWorkbook(memoryStream))
                {
                    var workSheet = workBook.Worksheet(1);
                    var rows = workSheet.RangeUsed().RowsUsed();

                    foreach (var row in rows)
                    {
                        var excelFileTender = new ExcelFileTender();

                        excelFileTender.Number = GetCellValue(row.Cell(1));
                        excelFileTender.Discription = GetCellValue(row.Cell(2));
                        excelFileTender.PositionPrice = GetCellValue(row.Cell(3));
                        excelFileTender.AgentName = GetCellValue(row.Cell(4));

                        excelFileTenders.Add(excelFileTender);
                    }
                }
            }
            
            return excelFileTenders;
        }

        private string GetCellValue(IXLCell cell)
        {
            if (cell.IsEmpty())
            {
                return String.Empty;
            }

            return cell.GetString().Trim();
        }

        private List<ExcelFileTender> RemoveHeaders(IEnumerable<ExcelFileTender> excelFileTenders)
        {
            return excelFileTenders.Skip(1).ToList();
        }

        private void EnsureExcelTableIsValid(IEnumerable<ExcelFileTender> excelFileTenders)
        {
            var headers = excelFileTenders.First();

            if (headers.Number == ExcelFileHeaders.NUMBER &&
                headers.Discription == ExcelFileHeaders.DESCRIPTION &&
                headers.PositionPrice == ExcelFileHeaders.POSITION_PRICE &&
                headers.AgentName == ExcelFileHeaders.AGENT_NAME)
            {
                return;
            }

            throw new Exception("Некорректный файл");
        }

        #endregion Excel
    }
}
