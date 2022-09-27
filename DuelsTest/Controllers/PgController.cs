using AutoMapper;
using RememberMe.Data.Request;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Repo.Ef;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace RememberMe.Controllers
{
    [ApiController]
    [Route("[controller]")]
    [Authorize(AuthenticationSchemes = JwtBearerDefaults.AuthenticationScheme)]

    public class PgController : ControllerBase
    {
        private readonly IMapper _mapper;
        private readonly GdrcontextContext _context;
        private readonly UserManager<ApplicationUser> _userManager;

        public PgController(GdrcontextContext context, IMapper mapper, UserManager<ApplicationUser> userManager)
        {
            _context = context;
            _mapper = mapper;
            _userManager = userManager;

        }


        [HttpPost]
        [Authorize(Roles = "Admin")]
        [Route("Register")]
        public async Task<IActionResult> Create(PgRequest request)
        {
            var existingUser = await _userManager.FindByIdAsync(request.IdAccount);
            var pg = new Pg();
            pg.AccountId = request.IdAccount;
            pg.Name = request.Name;
            pg.ApplicationUser = existingUser;
            _context.Pgs.Add(pg);
            _context.SaveChanges();
            return Ok();
        }


        [HttpPost]

        [Route("SetStat")]
        public async Task<IActionResult> SetStat(StatPgRequest request)
        {
            var pg = _context.Pgs.FirstOrDefault(x => x.PgId == request.PgId);
            var staticBase = _context.StatisticBases.FirstOrDefault(x => x.StatisticBaseId == request.Classes);
            var statics = _mapper.Map<Statistic>(staticBase);
            statics.Typology = "Base";
            statics.Pg = pg;
            _context.Statistics.Add(statics);
            _context.SaveChanges();
            return Ok();
        }

        [HttpPost]

        [Route("MoveSetCreation")]
        public async Task<IActionResult> MoveSetCreation(MoveSetCreationRequest request)
        {
            var pg = _context.Pgs.Where(x => x.PgId == request.PgId).Include(x => x.Moves).Include(x => x.Statistics).FirstOrDefault();
            foreach (var item in request.moveSets)
            {
                var typology = _context.Typologies.FirstOrDefault(x => x.TypologyId == item.TypologyID);
                var newMove = _mapper.Map<Move>(item);
                newMove.Typology = typology;
                newMove.Pg = pg;
                _context.Moves.Add(newMove);
            }
            _context.SaveChanges();
            return Ok();
        }
    }
}



