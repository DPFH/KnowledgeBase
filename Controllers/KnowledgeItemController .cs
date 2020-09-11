using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;

namespace KnowledgeBaseDPFH.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class KnowledgeItemController : ControllerBase
    {
        private static readonly string[] Titles = new[]
        {
            "Title A", "Title B", "Title C", "Title D", "Title E"
        };

        private readonly ILogger<KnowledgeItemController> _logger;

        public KnowledgeItemController(ILogger<KnowledgeItemController> logger)
        {
            _logger = logger;
        }

        // GET: ../KnowledgeItem
        [HttpGet]
        public ActionResult<IEnumerable<KnowledgeItem>> Get()
        {
            var rng = new Random();
            return Enumerable.Range(1, 5).Select(index => new KnowledgeItem
            {
                id = index,
                title = Titles[rng.Next(Titles.Length)],
                summary = "KNOWLEDGE"
            })
            .ToArray();
        }

        // GET: ../KnowledgeItem/{id}
        [HttpGet("{id}")]
        public ActionResult<KnowledgeItem> GetKnowledgeItem(long id)
        {
            KnowledgeItem theItem = new KnowledgeItem
            {
                id = 23,
                title = "Specific Knowledge Item",
                summary = "Ipsum lorem is simply dummy text of the printing and typesetting industry."
            };

            return theItem;
        }
    }
}
