using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Threading.Tasks;
using System.Web.Http;
using WebApiCloud.Models;
using WebApiCloud.Services;
using Newtonsoft.Json;

namespace WebApiCloud.Controllers
{
    /// <summary>
    /// Portfolio Details
    /// </summary>
    [Authorize]
    public class PortfolioController : ApiController
    {
        private readonly IPortfolioService _portfolioService;

        /// <summary>
        /// Constructor PortfolioController
        /// </summary>
        /// <param name="portfolioService"></param>
        public PortfolioController(IPortfolioService portfolioService)
        {
            this._portfolioService = portfolioService;
        }

        /// <summary>
        /// Get all Portfolios
        /// </summary>
        /// <returns></returns>
        [HttpGet]
        [Route("api/portfolio/getall")]
        public IHttpActionResult GetAllPortfolio()
        {
            var portfolios = _portfolioService.GetAllPortfolios();
            return Ok(portfolios);
        }

        /// <summary>
        /// Get portfolio by email
        /// </summary>
        /// <param name="email"></param>
        /// <returns></returns>
        [HttpGet]
        [Route("api/portfolio/getbyemail/{email}")]
        public async Task<IHttpActionResult> GetPortfolio(string email)
        {
            try
            {
                var portfolio = await _portfolioService.GetPortfolio(email);
                return Ok(portfolio);
            }
            catch (Exception ex)
            {
                return InternalServerError(ex);
            }
            
        }

        /// <summary>
        /// Create Portfolio
        /// </summary>
        /// <param name="portfolio"></param>
        /// <returns></returns>
        [HttpPost]
        [Route("api/portfolio/createportfolio")]
        public IHttpActionResult CreatePortfolio([FromBody] Portfolio portfolio)
        {
            try
            {
                if (portfolio == null)
                {
                    return BadRequest("Portfolio is not valid");
                }
                var userExists = _portfolioService.GetPortfolio(portfolio.Email);
                if (userExists != null)
                {
                    return BadRequest($"email is exists already : {portfolio.Email}");
                }
                portfolio.CreatedOn = DateTime.Now;
                var portfolioObj = _portfolioService.CreatePortfolio(portfolio);

                return Ok(portfolioObj);
            }
            catch (Exception ex)
            {
                return InternalServerError(ex);
            }
        }

        /// <summary>
        /// Update Portfolio
        /// </summary>
        /// <param name="portfolio"></param>
        /// <returns></returns>
        [HttpPost]
        [Route("api/portfolio/updateportfolio")]
        public IHttpActionResult UpdatePortfolio([FromBody] Portfolio portfolio)
        {
            try
            {
                if (portfolio == null)
                {
                    return BadRequest("User is not valid");
                }

                /*var existPortfolio = await _portfolioService.GetPortfolio(portfolio.Email);
                if (existPortfolio.Id.Length <= 0)
                {
                    return BadRequest("Portfolio is not valid");
                }*/

                var portfolioObj = _portfolioService.UpdatePortfolio(portfolio);
                if (portfolioObj == null)
                {
                    return BadRequest("Portfolio data not updated properly");
                }

                return Ok(portfolioObj);
            }
            catch (Exception ex)
            {
                return InternalServerError(ex);
            }
        }
    }
}
