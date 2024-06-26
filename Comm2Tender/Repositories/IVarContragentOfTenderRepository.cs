﻿using Comm2Tender.Models;
using System.Threading.Tasks;

namespace Comm2Tender.Repositories
{
    public interface IVarContragentOfTenderRepository
    {
        int? AddVarContragentOfTender(VarContragentOfTender varContragentOfTender);

        VarContragentOfTender GetVarContragentOfTender(int contractorId);
    }
}
