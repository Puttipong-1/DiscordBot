using ArknightApi.Data.DTO.Response;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ArknightApi.Service
{
    public interface IRecruitService
    {
        Task<List<string>> GetTags();
        Task<List<Operators>> GetRecruitOperators();
        Task<Dictionary<string, List<string>>> GetOperatorByTag(List<string> tags);
        Task<RecruitResponse> GetOperatorTags(string name);

    }
}
