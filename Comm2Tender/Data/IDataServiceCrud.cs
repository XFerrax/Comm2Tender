using Comm2Tender.Logic.Models;
using System.Collections.Generic;

namespace Comm2Tender.Data
{
    public partial interface IDataService
    {
        List<Logic.Models.Dto.Role> SearchRole(ListRequest listRequest, out int total);

        #region Agent
        int AddAgent(Agent model);
        bool DeleteAgent(int id);
        (List<Logic.Models.Dto.Agent> listRequest, int total) SearchAgent(ListRequest listRequest);
        bool UpdateAgent(Agent model);
        #endregion Agent

        #region CustomFeeDictionary
        int AddCustomFeeDictionary(CustomFeeDictionary model);
        bool DeleteCustomFeeDictionary(int id);
        (List<Logic.Models.Dto.CustomFeeDictionary> listRequest, int total) SearchCustomFeeDictionary(ListRequest listRequest);
        bool UpdateCustomFeeDictionary(CustomFeeDictionary model);
        #endregion CustomFeeDictionary

        #region PercentsDictionary
        int AddPercentsDictionary(PercentsDictionary model);
        bool DeletePercentsDictionary(int id);
        (List<Logic.Models.Dto.PercentsDictionary> listRequest, int total) SearchPercentsDictionary(ListRequest listRequest);
        bool UpdatePercentsDictionary(PercentsDictionary model);
        #endregion PercentsDictionary
    }
}
