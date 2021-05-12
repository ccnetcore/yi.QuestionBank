using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text;
namespace CC.Yi.Model
{
    public partial class DataContext :DbContext
    {
        public DbSet<question> question { get; set; }
        public DbSet<user> user { get; set; }
    }
}