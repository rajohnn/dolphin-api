using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;

using DolphinDraftAPI.Models;
using DolphinDraftAPI.Data;

namespace DolphinDraftAPI.Controllers {

    [ApiController]
    [Route("[controller]")]
    public class DolphinDraftController : ControllerBase {     
        private readonly ILogger<DolphinDraftController> _logger;
        private readonly DolphinsContext _ctx;

        public DolphinDraftController(DolphinsContext ctx, ILogger<DolphinDraftController> logger) {
            _ctx =ctx;
            _logger = logger;
        }

        [HttpGet]
        public IEnumerable<MiamiDraftStat> Get()
        {
            var results = _ctx.MiamiDraftStats.OrderByDescending(d=>d.Year).ThenBy(d=>d.Rnd);
            return results.ToArray(); 
        }

        [HttpGet("/DolphinDraft/Year/{year}")]
        public IEnumerable<MiamiDraftStat> GetByYear(int year) {
            var results = _ctx.MiamiDraftStats
                .Where(d=>d.Year == year)
                .OrderByDescending(d=>d.Year)
                .ThenBy(d=>d.Rnd);

            return results.ToArray();
        }

        [HttpGet("/DolphinDraft/Name/{name}")]
        public IEnumerable<MiamiDraftStat> GetByPlayerName(string name) {
            var results = _ctx.MiamiDraftStats
                .Where(d=>d.Player.Contains(name))
                .OrderByDescending(d=>d.Year)
                .ThenBy(d=>d.Rnd);

            return results.ToArray();
        }

         [HttpGet("/DolphinDraft/Position/{position}")]
        public IEnumerable<MiamiDraftStat> GetByPlayerPosition(string position) {
            var results = _ctx.MiamiDraftStats
                .Where(d=>d.POS == position)
                .OrderByDescending(d=>d.Year)
                .ThenBy(d=>d.Rnd);

            return results.ToArray();
        }

        [HttpGet("/DolphinDraft/Round/{round}")]
        public IEnumerable<MiamiDraftStat> GetByDraftRound(int round) {
            var results = _ctx.MiamiDraftStats
                .Where(d=>d.Rnd == round)
                .OrderByDescending(d=>d.Year)
                .ThenBy(d=>d.Rnd);

            return results.ToArray();
        }

        [HttpGet("/DolphinDraft/College/{college}")]
        public IEnumerable<MiamiDraftStat> GetByCollege(string college) {
            var results = _ctx.MiamiDraftStats
                .Where(d=>d.College_Univ.Contains(college))
                .OrderByDescending(d=>d.Year)
                .ThenBy(d=>d.Rnd);

            return results.ToArray();
        }

        [HttpGet("/DolphinDraft/Positions")]
        public IEnumerable<string> GetPositions() {
            var results = _ctx.MiamiDraftStats
                .Select(c=>c.POS)
                .Where(c=>c != null)
                .Distinct()
                .OrderBy(c=>c);

            return results.ToArray();
        }

        [HttpGet("/DolphinDraft/Colleges")]
        public IEnumerable<string> GetColleges() {
            var results = _ctx.MiamiDraftStats
                .Select(c=>c.College_Univ)
                .Where(c=>c != null)
                .Distinct()
                .OrderBy(c=>c);

            return results.ToArray();
        }        
    }
}
