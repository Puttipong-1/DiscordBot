using DiscordBot.Model.Request;
using DiscordBot.Model.Response.Recruit;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DiscordBot.Service
{
    class RecruitService
    {
        private readonly ApiService api;
        public RecruitService(ApiService _api)
        {
            api = _api;
        }
        public async Task<OperatorTag> GetOperatorTag(string name)
        {
            try
            {
                return await api.PostAsync<OperatorTag>("recruit/name/" + name, null, null);
            }catch(Exception e)
            {
                throw e;
            }
        }
        public async Task<List<string>> GetRecruitTag()
        {
            try
            {
                return await api.PostAsync<List<string>>("recruit/tags", null, null);
            }catch(Exception e)
            {
                throw e;
            }
        }
        public async Task<Dictionary<string,List<string>>> GetOperatorsByTags(string tags)
        {
            try
            {
                Tag tag = new Tag
                {
                    Tags = tags.Split(',').ToList()
                };
                return await api.PostAsync<Dictionary<string, List<string>>>("recruit/recruit", tag, null);
            }catch(Exception e)
            {
                throw e;
            }
        }
        public async Task<List<RecruitOperators>> GetRecruitOperators()
        {
            try
            {
                return await api.PostAsync<List<RecruitOperators>>("recruit/list", null, null);
            }catch(Exception e)
            {
                throw e;
            }
        }
    }
}
