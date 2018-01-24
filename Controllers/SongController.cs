using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using MusicHistoryApi.Data;
using MusicHistoryApi.Models;

namespace MusicHistoryApi.Controllers
{
    [Route("api/[controller]")]
    public class SongController : Controller
    {
        private ApplicationDbContext _context;
        // Constructor method to create an instance of context to communicate with our database.
        public SongController(ApplicationDbContext ctx)
        {
            _context = ctx;
        }

        

    }
}