using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using Dapper;
using Npgsql;
using System.Diagnostics;

namespace KnowledgeBaseDPFH.Controllers
{
    [ApiController]
    [Route("")]
    public class KnowledgeItemController : ControllerBase
    {
        private static readonly string connectionString = "Host=database-1.cx7ddt0hgocb.us-east-2.rds.amazonaws.com;Port=5432;Username=postgres;Password=password;Database=myDatabase";

        private readonly ILogger<KnowledgeItemController> _logger;

        public KnowledgeItemController(ILogger<KnowledgeItemController> logger)
        {
            _logger = logger;
        }

        // GET: ../KnowledgeItem
        [HttpGet("[controller]s")]
        public ActionResult<IEnumerable<KnowledgeItem>> Get()
        {
            string sql = "Select * from public.knowledgeitems;";
            using (var connection = new NpgsqlConnection(connectionString))
            {
                connection.Open();
                var results = connection.Query<KnowledgeItem>(sql).ToList();
                connection.Close();

                return results;
            }
        }

        // GET: ../KnowledgeItem/{id}
        [HttpGet("[controller]/{id}")]
        public ActionResult<KnowledgeItem> GetKnowledgeItem(long id)
        {
            //string sql = "Select * from public.knowledgeitems;";
            using (var connection = new NpgsqlConnection(connectionString))
            {
                connection.Open();
                var results = connection.Query<KnowledgeItem>("SELECT * FROM public.knowledgeitems WHERE createdby = @createdby;", new { createdby = "DJ Khaled" }).FirstOrDefault();
                connection.Close();

                if (results == null)
                {
                    return NotFound();
                }

                return results;
            }
        }
    }
}
