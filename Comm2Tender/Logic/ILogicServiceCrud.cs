using Comm2Tender.Logic.Models;
using Comm2Tender.Logic.Models.Dto;
using System.Collections;

namespace Comm2Tender.Logic
{
    public partial interface ILogicServiceCrud : ILogicService
    {
        ListResponse SearchRole(ListRequest listRequest);

        #region Agent
        AddResponse AddAgent(Agent model);
        Agent GetAgent(int id);
        bool DeleteAgent(int id);
        ListResponse SearchAgent(ListRequest listRequest);
        bool UpdateAgent(Agent model);
        #endregion Agent

        #region CustomFeeDictionary
        AddResponse AddCustomFeeDictionary(CustomFeeDictionary model);
        bool DeleteCustomFeeDictionary(int id);
        ListResponse SearchCustomFeeDictionary(ListRequest listRequest);
        bool UpdateCustomFeeDictionary(CustomFeeDictionary model);
        CustomFeeDictionary GetCustomFeeDictionary(int id);

        #endregion CustomFeeDictionary

        #region PercentsDictionary
        AddResponse AddPercentsDictionary(PercentsDictionary model);
        bool DeletePercentsDictionary(int id);
        ListResponse SearchPercentsDictionary(ListRequest listRequest);
        bool UpdatePercentsDictionary(PercentsDictionary model);
        PercentsDictionary GetPercentsDictionary(int id);
        #endregion PercentsDictionary

        #region Proposal
        AddResponse AddProposal(Proposal model);
        bool DeleteProposal(int id);
        ListResponse SearchProposal(ListRequest listRequest);
        bool UpdateProposal(Proposal model);
        ListResponse GetTenderProposals(int tenderId);
        Proposal GetProposal(int id);
        #endregion Proposal

        #region Tender
        ListResponse SearchTender(ListRequest listRequest);
        bool DeleteTender(int id);
        bool UpdateTender(Tender model);
        AddResponse AddTender(Tender model);
        Tender GetTender(int tenderId);
        #endregion Tender

        #region User
        AddResponse AddUser(User model);

        User GetUser(int id);
        bool DeleteUser(int id);
        ListResponse SearchUser(ListRequest listRequest);
        bool UpdateUser(User model);
        #endregion User
    }
}
