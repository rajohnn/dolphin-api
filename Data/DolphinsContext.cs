using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Metadata.Internal;

using DolphinDraftAPI.Models;

namespace DolphinDraftAPI.Data {
    public class DolphinsContext : DbContext {
        public DolphinsContext(DbContextOptions<DolphinsContext> options)
            : base(options)
        {}

        public DbSet<MiamiDraftStat> MiamiDraftStats { get; set; }
    }
}