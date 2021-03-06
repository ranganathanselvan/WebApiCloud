﻿using MongoDB.Driver;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Web;
using WebApiCloud.Models;

namespace WebApiCloud.Services
{
    /// <summary>
    /// PortfolioService
    /// </summary>
    public class PortfolioService : IPortfolioService
    {
        private readonly IMongoCollection<Portfolio> _portfolio;

        /// <summary>
        /// Constructor PortfolioService
        /// </summary>
        public PortfolioService()
        {
            var client = new MongoClient("mongodb+srv://tamran1988:1988-tamil@tamran0-ctnm5.mongodb.net/docmgnt?retryWrites=true&w=majority");
            var database = client.GetDatabase("docmgnt");

            _portfolio = database.GetCollection<Portfolio>("portfolio");
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="portfolio"></param>
        /// <returns></returns>
        public Portfolio CreatePortfolio(Portfolio portfolio)
        {
            _portfolio.InsertOne(portfolio);
            return portfolio;
        }

        /// <summary>
        /// 
        /// </summary>
        /// <returns></returns>
        public List<Portfolio> GetAllPortfolios() =>
            _portfolio.Find(port => true).ToList();


        /// <summary>
        /// 
        /// </summary>
        /// <param name="email"></param>
        /// <returns></returns>
        public async Task<Portfolio> GetPortfolio(string email)
        {
            var objIAsyncPortfolio = await _portfolio.FindAsync<Portfolio>(p => p.Email == email);
            var listPortfolio = await objIAsyncPortfolio.ToListAsync();
            if (listPortfolio.Count == 0)
                return null;
            return listPortfolio[0];
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="portfolio"></param>
        /// <returns></returns>
        public Portfolio UpdatePortfolio(Portfolio portfolio)
        {
            var filter = Builders<Portfolio>.Filter.Eq("Email", portfolio.Email);
            var update = Builders<Portfolio>.Update
                                            .Set("Skills", portfolio.Skills)
                                            .Set("WorkInfo", portfolio.WorkInfo)
                                            .Set("Certifications", portfolio.Certifications)
                                            .Set("FirstName", portfolio.FirstName)
                                            .Set("LastName", portfolio.LastName)
                                            .Set("Mobile", portfolio.Mobile)
                                            .Set("ShortDiscription", portfolio.ShortDiscription)
                                            .Set("LongDiscription", portfolio.LongDiscription);

            var updatedResult = _portfolio.UpdateOne(filter, update);
            if (updatedResult.MatchedCount > 0 || updatedResult.ModifiedCount > 0)
            {
                return portfolio;
            }
            else
            {
                return null;
            }
        }
    }
}