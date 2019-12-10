using ClassRegister.Core.Model;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace ClassRegister.Infrastructure.Database.Configuration
{
    public class ParentConfiguration : IEntityTypeConfiguration<Parent>
    {
        public void Configure(EntityTypeBuilder<Parent> builder)
        {
            builder.HasKey(b => b.Id);

            builder.HasOne(x => x.Student)
                .WithOne(x => x.Parent)
                .HasForeignKey<Student>(x => x.ParentId);
        }
    }
}