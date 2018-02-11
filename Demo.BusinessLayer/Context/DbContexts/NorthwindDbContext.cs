using System;
using Microsoft.EntityFrameworkCore;

namespace Demo.BuissinessLayer
{
    public class NorthwindDbcontext : DbContext
    {
        public NorthwindDbcontext(DbContextOptions<NorthwindDbcontext> options) : base(options)
        {

        }
    }
}
