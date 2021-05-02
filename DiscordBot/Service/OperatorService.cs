using DiscordBot.Model.Response.Operator;
using System;
using System.Collections.Generic;
using System.Globalization;
using System.Text;
using System.Threading.Tasks;

namespace DiscordBot.Service
{
    public class OperatorService
    {
        private readonly ApiService api;
        public OperatorService(ApiService _api)
        {
            api = _api;
        }
        public async Task<BaseBuff> GetOperatorBaseBuff(string name)
        {
            try
            {
                return await api.PostAsync<BaseBuff>("operator/buff/"+name,null,null);
            }catch(Exception e)
            {
                Console.WriteLine("op service " + e.Message);
                throw e;
            }
        }
        public async Task<OpDetail> GetOperatorDetail(string name)
        {
            try
            {
                return await api.PostAsync<OpDetail>("operator/name/" + name, null, null);
            }catch(Exception e)
            {
                throw e;
            }
        }
        public async Task<List<Operator>> GetOperatorList()
        {
            try
            {
                return await api.PostAsync<List<Operator>>("operator/list",null,null);
            }catch(Exception e)
            {
                throw e;
            }
        }
        public async Task<OpProfile> GetOperatorProfile(string name)
        {
            try
            {
                return await api.PostAsync<OpProfile>("operator/profile/" + name, null, null);
            }catch(Exception e)
            {
                throw e;
            }
        }
        public async Task<OpSkill> GetOperatorSkill(string name)
        {
            try
            {
                return await api.PostAsync<OpSkill>("operator/skill/" + name, null, null);
            }
            catch (Exception e)
            {
                throw e;
            }
        }
        public async Task<OpSkin> GetOperatorSkin(string name)
        {
            try
            {
                return await api.PostAsync<OpSkin>("operator/skin/" + name, null, null);
            }
            catch (Exception e)
            {
                throw e;
            }
        }
        public async Task<OpWord> GetOperatorQuote(string name)
        {
            try
            {
                return await api.PostAsync<OpWord>("operator/word/" + name, null, null);
            }
            catch (Exception e)
            {
                throw e;
            }
        }
    }
}
