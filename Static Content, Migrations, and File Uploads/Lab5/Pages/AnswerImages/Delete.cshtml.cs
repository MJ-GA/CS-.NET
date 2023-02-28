using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using Lab5.Data;
using Lab5.Models;
using Azure.Storage.Blobs;
using Azure;


namespace Lab5.Pages.AnswerImages
{
    public class DeleteModel : PageModel
    {
        
        private readonly Lab5.Data.AnswerImageDataContext _context;
        private readonly BlobServiceClient _blobServiceClient;
        private readonly string earthContainerName = "earthimages";
        private readonly string computerContainerName = "computerimages";
        private readonly Dictionary<string, string> containerNamesDictionary = new Dictionary<string, string>()
        {
            { "a", "computeranswerimages" },
            { "b", "earcthanswerimages"}
        };
        public DeleteModel(Lab5.Data.AnswerImageDataContext context, BlobServiceClient blobServiceClient)
        {
            _context = context;
            blobServiceClient = _blobServiceClient;
        }

        [BindProperty]
      public AnswerImage AnswerImage { get; set; }

        public async Task<IActionResult> OnGetAsync(int? id)
        {
            if (id == null || _context.AnswerImages == null)
            {
                return NotFound();
            }

            var answerimage = await _context.AnswerImages.FirstOrDefaultAsync(m => m.AnswerImageId == id);

            if (answerimage == null)
            {
                return NotFound();
            }
            else 
            {
                AnswerImage = answerimage;
            }
            return Page();
        }
       /* 
        public async Task<IActionResult> OnPostAsync(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            AnswerImage = await _context.AnswerImages.FindAsync(id);

            if (AnswerImage != null)
            {
                BlobContainerClient containerClient;
                try
                {
                    var containerName = containerNamesDictionary[!AnswerImage.question.Equals(AnswerImage.Question.Computer) ? "a" : "b" ];
                    containerClient = _blobServiceClient.GetBlobContainerClient(containerName);
                }
                catch (RequestFailedException)
                {
                    return RedirectToPage("Error");
                }

                try
                {
                    // Get the blob that holds the data
                    var blockBlob = containerClient.GetBlobClient(AnswerImage.FileName);
                    if (await blockBlob.ExistsAsync())
                    {
                        await blockBlob.DeleteAsync();
                    }

                    _context.AnswerImages.Remove(AnswerImage);
                    await _context.SaveChangesAsync();

                }
                catch (RequestFailedException)
                {
                    return RedirectToPage("Error");
                }
            }

            return RedirectToPage("./Index");
        }*/
    }
}
