﻿using FinShark.Dtos.Stock;
using FinShark.Interfaces;
using FinShark.Mappers;
using FinShark.Models;
using Newtonsoft.Json;
using static System.Net.WebRequestMethods;

namespace FinShark.Service
{
    public class FMPService : IFMPService
    {
        private readonly HttpClient _httpClient;
        private readonly IConfiguration _config;
        public FMPService(HttpClient httpClient, IConfiguration config)
        {
            _httpClient = httpClient;
            _config = config;
        }

        public async Task<Stock> FindStockBySymbolAsync(string symbol)
        {
            try
            {
                var result = await _httpClient.GetAsync($"https://financialmodelingprep.com/api/v3/profile/{symbol}?apikey={_config["FMPKey"]}");

                if (result.IsSuccessStatusCode)
                {
                    var content = await result.Content.ReadAsStringAsync();
                    var tasks = JsonConvert.DeserializeObject<FMPStock[]>(content, new JsonSerializerSettings { NullValueHandling = NullValueHandling.Ignore });
                    var stock = tasks[0];

                    if (stock != null)
                    {
                        return stock.ToStockFromFmp();
                    }
                }
                return null;
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex);
                return null;
            }
        }
    }
}
