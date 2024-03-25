using Application.Service.People.Queries.GetPeople;
using Application.Service.People.Queries.GetWithLambda;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;


namespace EndPoint.Controllers
{
    [Route("api/[controller]/[action]")]
    [ApiController]
    public class PeopleController : ControllerBase
    {
        private readonly IGetPeopleList _getList;
        private readonly IPersonRepository _getRepository;
        public PeopleController(IGetPeopleList getList, IPersonRepository getRepository)
        {
            _getList = getList;
            _getRepository = getRepository;
        }
        //Get the list of people with their addresses with CQRS
        [HttpGet]
        public IActionResult GetListwithCQRS()
        {
            try
            {
                return Ok(_getList.Execute());
            }
            catch
            {
                return StatusCode(500, "Internal server error");
            }
        }
        //Get the list of people with their addresses with lambda
        [HttpGet]
        public IActionResult GetListwithLambda()
        {
            try
            {
                return Ok(_getRepository.GetPeopleLambda());
            }
            catch
            {
                return StatusCode(500, "Internal server error");
            }
        }
        //Get the list of people with their addresses with linq
        [HttpGet]
        public IActionResult GetListwithLinq()
        {
            try
            {
                return Ok(_getRepository.GetPeopleLinq());
            }
            catch
            {
                return StatusCode(500, "Internal server error");
            }
        }
        //Get the list of people with their addresses with tsql
        [HttpGet]
        public IActionResult GetListwithTSQL()
        {
            try
            {
                return Ok(_getRepository.GetPeoplTSQL());
            }
            catch
            {
                return StatusCode(500, "Internal server error");
            }
        }

    }
}
