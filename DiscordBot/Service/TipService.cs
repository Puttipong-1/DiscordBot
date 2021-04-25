﻿using DiscordBot.Model.Response.Tip;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace DiscordBot.Service
{
    class TipService
    {
        private readonly ApiService api;
        public TipService(ApiService _api)
        {
            api = _api;
        }
        public async Task<List<string>> GetTipCategories()
        {
            try
            {
                return await api.PostAsync<List<string>>("tip/list",null,null);
            }catch(Exception e)
            {
                throw e;
            }
        }
        public async Task<List<Tip>> GetTipByCategory(string category)
        {
            try
            {
                return await api.PostAsync<List<Tip>>("tip/category/" + category, null, null);
            }catch (Exception e)
            {
                throw e;
            }
        }
    }
}
