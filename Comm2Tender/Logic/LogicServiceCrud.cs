using ClosedXML.Excel;
using Comm2Tender.Logic.Models;
using Comm2Tender.Logic.Models.Dto;
using System;
using System.Collections.Generic;
using System.IO;

namespace Comm2Tender.Logic
{
    public partial class LogicService : ILogicServiceCrud
    {
        #region Role
        public ListResponse SearchRole(ListRequest listRequest)
        {
            ConfigListRequest(listRequest);
            return new ListResponse { Items = DataService.SearchRole(listRequest, out int total), Total = total };
        }
        #endregion

        #region Agent
        public AddResponse AddAgent(Agent model)
        {
            return new AddResponse
            {
                Id = DataService.AddAgent(model),
            };
        }

        public Agent GetAgent(int id)
        {
            return DataService.GetAgent(id);
        }

        public bool DeleteAgent(int id)
        {
            return DataService.DeleteAgent(id);
        }

        public ListResponse SearchAgent(ListRequest listRequest)
        {
            var respList = DataService.SearchAgent(listRequest);
            return new ListResponse() { Items = respList.listRequest, Total = respList.total };
        }

        public bool UpdateAgent(Agent model)
        {
            return DataService.UpdateAgent(model);
        }
        #endregion Agent

        #region CustomFeeDictionary
        public AddResponse AddCustomFeeDictionary(CustomFeeDictionary model)
        {
            return new AddResponse
            {
                Id = DataService.AddCustomFeeDictionary(model),
            };
        }

        public bool DeleteCustomFeeDictionary(int id)
        {
            return DataService.DeleteCustomFeeDictionary(id);
        }

        public ListResponse SearchCustomFeeDictionary(ListRequest listRequest)
        {
            var respList = DataService.SearchCustomFeeDictionary(listRequest);
            return new ListResponse() { Items = respList.listRequest, Total = respList.total };
        }

        public bool UpdateCustomFeeDictionary(CustomFeeDictionary model)
        {
            return DataService.UpdateCustomFeeDictionary(model);
        }

        public CustomFeeDictionary GetCustomFeeDictionary(int id)
        {
            return DataService.GetCustomFeeDictionary(id);
        }
        #endregion CustomFeeDictionary

        #region PercentsDictionary
        public AddResponse AddPercentsDictionary(PercentsDictionary model) 
        {
            return new AddResponse
            {
                Id = DataService.AddPercentsDictionary(model),
            };
        }

        public bool DeletePercentsDictionary(int id)
        {
            return DataService.DeletePercentsDictionary(id);
        }
        public ListResponse SearchPercentsDictionary(ListRequest listRequest)
        {
            var respList = DataService.SearchPercentsDictionary(listRequest);
            return new ListResponse() { Items = respList.listRequest, Total = respList.total };
        }

        public bool UpdatePercentsDictionary(PercentsDictionary model)
        {
            return DataService.UpdatePercentsDictionary(model);
        }

        public PercentsDictionary GetPercentsDictionary(int id)
        {
            return DataService.GetPercentsDictionary(id);
        }

        #endregion PercentsDictionary

        #region Proposal
        public AddResponse AddProposal(Proposal model)
        {
            return new AddResponse
            {
                Id = DataService.AddProposal(model),
            };
        }

        public bool DeleteProposal(int id)
        {
            return DataService.DeleteProposal(id);
        }

        public ListResponse SearchProposal(ListRequest listRequest)
        {
            var respList = DataService.SearchProposal(listRequest);
            return new ListResponse() { Items = respList.listRequest, Total = respList.total };
        }

        public bool UpdateProposal(Proposal model)
        {
            return DataService.UpdateProposal(model);
        }

        public ListResponse GetTenderProposals(int tenderId)
        {
            var tenders = DataService.GetProposalsByTenderId(tenderId);

            var listResponse = new ListResponse();
            listResponse.Items = tenders;
            listResponse.Total = tenders.Count;

            return listResponse;
        }

        public Proposal GetProposal(int id)
        {
            return DataService.GetProposal(id);
        }

        #endregion Proposal

        #region Tender
        public ListResponse SearchTender(ListRequest listRequest)
        {
            var respList = DataService.SearchTender(listRequest);
            return new ListResponse() { Items = respList.listRequest, Total = respList.total };
        }

        public bool DeleteTender(int id)
        {
            return DataService.DeleteTender(id);
        }

        public bool UpdateTender(Tender model)
        {
            return DataService.UpdateTender(model);
        }

        public AddResponse AddTender(Tender model)
        {
            return new AddResponse
            {
                Id = DataService.AddTender(model),
            };
        }

        public Tender GetTender(int tenderId)
        {
            return DataService.GetTender(tenderId);
        }
        #endregion Tender

        #region User
        public AddResponse AddUser(User model)
        {
            return new AddResponse
            {
                Id = DataService.AddUser(model),
            };
        }

        public bool DeleteUser(int id)
        {
            return DataService.DeleteUser(id);
        }

        public ListResponse SearchUser(ListRequest listRequest)
        {
            var respList = DataService.SearchUser(listRequest);
            return new ListResponse() { Items = respList.listRequest, Total = respList.total };
        }

        public bool UpdateUser(User model)
        {
            return DataService.UpdateUser(model);
        }

        public User GetUser(int id)
        {
            return DataService.GetUser(id);
        }
        #endregion User
    }
}
