using Comm2Tender.Logic.Models;

namespace Comm2Tender.Logic
{
    public interface ILogicServiceCalculation : ILogicService
    {
        ListResponse Calculate(int tenderId);
    }
}
