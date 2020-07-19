using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WebApiCloud.Models;

namespace WebApiCloud.Services
{
    /// <summary>
    /// IPortfolioService
    /// </summary>
    public interface IPortfolioService
    {
        /// <summary>
        /// GetAllPortfolios
        /// </summary>
        /// <returns></returns>
        List<Portfolio> GetAllPortfolios();
        /// <summary>
        /// GetPortfolio
        /// </summary>
        /// <param name="email"></param>
        /// <returns></returns>
        Portfolio GetPortfolio(string email);
        /// <summary>
        /// CreatePortfolio
        /// </summary>
        /// <param name="portfolio"></param>
        /// <returns></returns>
        Portfolio CreatePortfolio(Portfolio portfolio);
        /// <summary>
        /// UpdatePortfolio
        /// </summary>
        /// <param name="portfolio"></param>
        /// <returns></returns>
        Portfolio UpdatePortfolio(Portfolio portfolio);
    }
}
