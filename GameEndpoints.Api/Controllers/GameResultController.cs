using GameEndpoints.Api.Model;
using GameEndpoints.Domain.Contracts.Services;
using GameEndpoints.Domain.Model;
using System;
using System.Collections.Generic;
using System.Net;
using System.Net.Http;
using System.Threading.Tasks;
using System.Web.Http;

namespace GameEndpoints.Api.Controllers
{
    public class GameResultController : ApiController
    {
        private IGameResultService _service;

        public GameResultController(IGameResultService service)
        {
            this._service = service;
        }

        [Authorize]
        public Task<HttpResponseMessage> Get()
        {
            HttpResponseMessage response = new HttpResponseMessage();
            try
            {
                List<Balance> leaderboard = _service.GetLeaderboard() as List<Balance>;

                var leaderboardResult = leaderboard.ConvertAll<LeaderbordModel>(x => 
                    new LeaderbordModel(x.Player.PlayerId, x.Points, x.LastUpdate));

                response = Request.CreateResponse(HttpStatusCode.OK, leaderboardResult);
            }
            catch (Exception ex)
            {
                response = Request.CreateResponse(HttpStatusCode.BadRequest, ex.Message);
            }
            var task = new TaskCompletionSource<HttpResponseMessage>();
            task.SetResult(response);
            return task.Task;
        }

        [Authorize]
        [HttpPost]
        public Task<HttpResponseMessage> Post(GameResultModel gameResult)
        {
            HttpResponseMessage response = new HttpResponseMessage();
            try 
	        {
		        var balance = _service.SaveGameResult(gameResult.GetPlayerId(), gameResult.GameDetails);
                response = Request.CreateResponse(HttpStatusCode.OK, new { Balance = balance.Points });
	        }
	        catch (Exception ex)
	        {
		        response = Request.CreateResponse(HttpStatusCode.BadRequest, ex.Message);
	        }
            var task = new TaskCompletionSource<HttpResponseMessage>();
            task.SetResult(response);
            return task.Task;
        }

        protected override void Dispose(bool disposing)
        {
            this._service.Dispose();
            base.Dispose(disposing);
        }
    }
}
