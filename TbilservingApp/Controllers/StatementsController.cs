using AutoMapper;
using Core.Application.Dtos.Statement;
using Core.Application.Interfaces.Repository;
using Core.Application.Services;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace TbilservingApp.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class StatementsController : ControllerBase
    {
        StatementsService statementService;

        public StatementsController(StatementsService statementService)
        {
            this.statementService = statementService;

        }
        [AllowAnonymous]
        [HttpPost]
        public async Task<IActionResult> Post([FromForm] AddStatementDto addStatementDto)
        {
            string result = await statementService.StatementAdd(addStatementDto);
            return Ok(result);

        }
    }
}
