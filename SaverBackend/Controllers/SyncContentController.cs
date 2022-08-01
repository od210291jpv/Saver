using Microsoft.AspNetCore.Mvc;
using SaverBackend.DTO;
using SaverBackend.Models;

namespace SaverBackend.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class SyncContentController : ControllerBase
    {
        private ApplicationContext db;

        public SyncContentController(ApplicationContext database)
        {
            this.db = database;
        }

        [HttpPost(Name = "SyncContent")]
        public async Task<IActionResult> Index(ContentRepresentationData contentRepresentation)
        {
            if (contentRepresentation is not null) 
            {
                foreach (var category in contentRepresentation.Categories) 
                {
                    if (db.Categories.Where(c => c.CategoryId == category.CategoryId).Count() == 0) 
                    {
                        this.db.Categories.Add(new Category()
                        {
                            CategoryId = category.CategoryId,
                            Name = category.Name,
                        });
                    }
                }

                foreach (var content in contentRepresentation.Content)
                {
                    if (this.db.Contents.Where(ct => ct.ImageUri == content.ImageUri && ct.CategoryId == content.CategoryId).Count() == 0) 
                    {
                        db.Contents.Add(new Models.Content()
                        {
                            CategoryId = content.CategoryId,
                            ImageUri = content.ImageUri,
                            Title = content.Title,
                        });
                    }
                }

                int result = await db.SaveChangesAsync();

                if (result > 0) 
                {
                    return StatusCode(201);
                }

                return StatusCode(200);
            }

            return StatusCode(404);
        }
    }
}
