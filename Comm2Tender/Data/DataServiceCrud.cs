﻿
using Comm2Tender.Logic.Models;
using LinqToDB;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Logging;
using System.Collections.Generic;
using System.Diagnostics.Metrics;
using System.Linq;

namespace Comm2Tender.Data
{
    public partial class DataService : IDataService
    {
        public List<Logic.Models.Dto.Role> SearchRole(ListRequest listRequest, out int total)
        {
            using var db = GetDatabase();
            var items = db.Role.WhereDynamic(listRequest.Filter);
            if (string.IsNullOrWhiteSpace(listRequest.Search) == false)
            {
                items = items.Where(a => a.Name.Contains(listRequest.Search));
            }
            items = items.OrderByDynamic(listRequest.Sort);
            total = items.Count();
            if (listRequest.Size > 0)
            {
                items = items.Skip((listRequest.Page - 1) * listRequest.Size).Take(listRequest.Size);
            }
            return items.ToList().ConvertAll(a => (Logic.Models.Dto.Role)a);
        }

        #region Agent
        public int AddAgent(Agent model)
        {
            using var db = GetDatabase();
            return db.InsertWithInt32Identity<Agent>(model);
        }

        public bool DeleteAgent(int id)
        {
            using var db = GetDatabase();
            return db.Agent.Where(a => a.AgentId == id).Delete() == 1;
        }

        public (List<Logic.Models.Dto.Agent> listRequest, int total) SearchAgent(ListRequest listRequest)
        {
            using var db = GetDatabase();
            var items = db.Agent
                .WhereDynamic(listRequest.Filter);
            if (string.IsNullOrWhiteSpace(listRequest.Search) == false)
            {
                items = items.Where(a => a.Name.Contains(listRequest.Search));
            }
            items = items.OrderByDynamic(listRequest.Sort);
            var total = items.Count();
            if (listRequest.Size > 0)
            {
                items = items.Skip((listRequest.Page - 1) * listRequest.Size).Take(listRequest.Size);
            }
            return (items.ToList().ConvertAll(a => (Logic.Models.Dto.Agent)a), total);
        }

        public bool UpdateAgent(Agent model)
        {
            using var db = GetDatabase();
            db.Update<Agent>(model);
            return true;
        }

        public Agent GetAgent(int id)
        {
            using var db = GetDatabase();
            return db.Agent.First(x => x.AgentId == id);
        }
        #endregion Agent

        #region CustomFeeDictionary
        public int AddCustomFeeDictionary(CustomFeeDictionary model)
        {
            using var db = GetDatabase();
            return db.InsertWithInt32Identity<CustomFeeDictionary>(model);
        }

        public bool DeleteCustomFeeDictionary(int id)
        {
            using var db = GetDatabase();
            return db.CustomFeeDictionary.Where(a => a.CustomFeeDictionaryId == id).Delete() == 1;
        }
        public (List<Logic.Models.Dto.CustomFeeDictionary> listRequest, int total) SearchCustomFeeDictionary(ListRequest listRequest)
        {
            using var db = GetDatabase();
            var items = db.CustomFeeDictionary
                .WhereDynamic(listRequest.Filter);
            if (string.IsNullOrWhiteSpace(listRequest.Search) == false)
            {

            }
            items = items.OrderByDynamic(listRequest.Sort);
            var total = items.Count();
            if (listRequest.Size > 0)
            {
                items = items.Skip((listRequest.Page - 1) * listRequest.Size).Take(listRequest.Size);
            }
            return (items.ToList().ConvertAll(a => (Logic.Models.Dto.CustomFeeDictionary)a), total);
        }
        public bool UpdateCustomFeeDictionary(CustomFeeDictionary model)
        {
            using var db = GetDatabase();
            db.Update<CustomFeeDictionary>(model);
            return true;
        }
        #endregion CustomFeeDictionary

        #region PercentsDictionary
        public int AddPercentsDictionary(PercentsDictionary model)
        {
            using var db = GetDatabase();
            return db.InsertWithInt32Identity<PercentsDictionary>(model);
        }

        public bool DeletePercentsDictionary(int id)
        {
            using var db = GetDatabase();
            return db.PercentsDictionary.Where(a => a.PercentsDictionaryId == id).Delete() == 1;
        }
        public (List<Logic.Models.Dto.PercentsDictionary> listRequest, int total) SearchPercentsDictionary(ListRequest listRequest)
        {
            using var db = GetDatabase();
            var items = db.PercentsDictionary
                .WhereDynamic(listRequest.Filter);
            if (string.IsNullOrWhiteSpace(listRequest.Search) == false)
            {

            }
            items = items.OrderByDynamic(listRequest.Sort);
            var total = items.Count();
            if (listRequest.Size > 0)
            {
                items = items.Skip((listRequest.Page - 1) * listRequest.Size).Take(listRequest.Size);
            }
            return (items.ToList().ConvertAll(a => (Logic.Models.Dto.PercentsDictionary)a), total);
        }
        public bool UpdatePercentsDictionary(PercentsDictionary model)
        {
            using var db = GetDatabase();
            db.Update<PercentsDictionary>(model);
            return true;
        }

        public PercentsDictionary GetLastPercentsDictionary()
        {
            using var db = GetDatabase();
            return db.PercentsDictionary.OrderByDescending(x => x.DateEnter).FirstOrDefault();
        }
        #endregion PercentsDictionary

        #region Proposal
        public int AddProposal(Proposal model)
        {
            using var db = GetDatabase();
            return db.InsertWithInt32Identity<Proposal>(model);
        }

        public bool DeleteProposal(int id)
        {
            using var db = GetDatabase();
            return db.Proposal.Where(a => a.ProposalId == id).Delete() == 1;
        }

        public (List<Logic.Models.Dto.Proposal> listRequest, int total) SearchProposal(ListRequest listRequest)
        {
            using var db = GetDatabase();
            var items = db.Proposal
                .LoadWith(a => a.Agent)
                .LoadWith(a => a.User)
                .LoadWith(a => a.Tender)
                .WhereDynamic(listRequest.Filter);
            if (string.IsNullOrWhiteSpace(listRequest.Search) == false)
            {
                //items = items.Where(a => a.Name.Contains(listRequest.Search));
            }
            items = items.OrderByDynamic(listRequest.Sort);
            var total = items.Count();
            if (listRequest.Size > 0)
            {
                items = items.Skip((listRequest.Page - 1) * listRequest.Size).Take(listRequest.Size);
            }
            return (items.ToList().ConvertAll(a => (Logic.Models.Dto.Proposal)a), total);
        }

        public bool UpdateProposal(Proposal model)
        {
            using var db = GetDatabase();
            db.Update<Proposal>(model);
            return true;
        }
        #endregion Proposal

        #region Tender
        public int AddTender(Tender model)
        {
            using var db = GetDatabase();
            return db.InsertWithInt32Identity<Tender>(model);
        }

        public bool DeleteTender(int id)
        {
            using var db = GetDatabase();
            var deletedTokens = db.Tender.Where(x => x.TenderId == id).Delete();
            var deletedTenders = db.Tender.Where(a => a.TenderId == id).Delete();
            return deletedTenders == 1;
        }

        public (List<Tender> listRequest, int total) SearchTender(ListRequest listRequest)
        {
            using var db = GetDatabase();
            var items = db.Tender
                .WhereDynamic(listRequest.Filter);
            if (string.IsNullOrWhiteSpace(listRequest.Search) == false)
            {
                items = items.Where(a => a.Discription.Contains(listRequest.Search));
            }
            items = items.OrderByDynamic(listRequest.Sort);
            var total = items.Count();
            if (listRequest.Size > 0)
            {
                items = items.Skip((listRequest.Page - 1) * listRequest.Size).Take(listRequest.Size);
            }
            return (items.ToList().ConvertAll(a => (Tender)a), total);
        }

        public bool UpdateTender(Tender model)
        {
            using var db = GetDatabase();
            var updatedTenders = db.Update<Tender>(model);
            return updatedTenders == 1;
        }

        public Tender GetTender(int id)
        {
            using var db = GetDatabase();
            return db.Tender.First(x => x.TenderId == id);

        }
        #endregion Tender

        #region User
        public int AddUser(User model)
        {
            using var db = GetDatabase();
            return db.InsertWithInt32Identity<User>(model);
        }

        public bool DeleteUser(int id)
        {
            using var db = GetDatabase();
            var deletedTokens = db.UserToken.Where(x => x.UserId == id).Delete();
            var deletedUsers = db.User.LoadWith(x => x.Role).Where(a => a.UserId == id).Delete();
            return deletedUsers == 1;
        }

        public (List<Logic.Models.Dto.User> listRequest, int total) SearchUser(ListRequest listRequest)
        {
            using var db = GetDatabase();
            var items = db.User
                .LoadWith(a => a.Role)
                .WhereDynamic(listRequest.Filter);
            if (string.IsNullOrWhiteSpace(listRequest.Search) == false)
            {
                items = items.Where(a => a.Name.Contains(listRequest.Search));
            }
            items = items.OrderByDynamic(listRequest.Sort);
            var total = items.Count();
            if (listRequest.Size > 0)
            {
                items = items.Skip((listRequest.Page - 1) * listRequest.Size).Take(listRequest.Size);
            }
            return (items.ToList().ConvertAll(a => (Logic.Models.Dto.User)a), total);
        }

        public bool UpdateUser(User model)
        {
            using var db = GetDatabase();
            db.Update<User>(model);
            return true;
        }

        public User GetUser(int id)
        {
            using var db = GetDatabase();
            return db.User.First(x => x.UserId == id);
        }
        #endregion User
    }
}
