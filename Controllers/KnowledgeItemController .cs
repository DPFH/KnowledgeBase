using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;

namespace KnowledgeBaseDPFH.Controllers
{
    [ApiController]
    [Route("")]
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
        [HttpGet("[controller]s")]
        public ActionResult<IEnumerable<KnowledgeItem>> Get()
        {
            var rng = new Random();
            return Enumerable.Range(1, 5).Select(index => new KnowledgeItem
            {
                id = index,
                title = Titles[rng.Next(Titles.Length)],
                summary = @"Lorem Ipsum is simply dummy text of the printing and typesetting industry.
                Lorem Ipsum has been the industry's standard dummy text ever since the 1500s,
                when an unknown printer took a galley of type and scrambled it to make a
                type specimen book. It has survived not only five centuries, but also the leap
                into electronic typesetting, remaining essentially unchanged. It was popularised
                in the 1960s with the release of Letraset sheets containing Lorem Ipsum passages,
                and more recently with desktop publishing software like Aldus PageMaker
                including versions of Lorem Ipsum.",
                createdDate = DateTime.Now.ToString("MMMM dd, yyyy 'at' h:mm tt"),
                editedDate = DateTime.Now.ToString("MMMM dd, yyyy 'at' h:mm tt"),
                createdBy = "Admin",
                editedBy = "Admin"
            })
            .ToArray();
        }

        // GET: ../KnowledgeItem/{id}
        [HttpGet("[controller]/{id}")]
        public ActionResult<KnowledgeItem> GetKnowledgeItem(long id)
        {
            KnowledgeItem theItem = new KnowledgeItem
            {
                id = 23,
                title = "Specific Knowledge Item",
                summary = "Ipsum lorem is simply dummy text of the printing and typesetting industry. Testing get/{id}.",
                createdDate = DateTime.Now.ToString("MMMM dd, yyyy 'at' h:mm tt"),
                editedDate = DateTime.Now.ToString("MMMM dd, yyyy 'at' h:mm tt"),
                createdBy = "Admin",
                editedBy = "Admin"
            };

            return theItem;
        }
    }
}
