using ClassRegister.Core.Model;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace ClassRegister.Infrastructure.Database.Configuration
{
    public class LessonConfiguration : IEntityTypeConfiguration<Lesson>
    {
        public void Configure(EntityTypeBuilder<Lesson> builder)
        {
            builder.HasKey(b => b.Id);

            builder.HasOne(x => x.Class)
                .WithMany(x => x.Lessons)
                .HasForeignKey(x => x.ClassId);

            builder.HasOne(x => x.Subject)
                .WithMany(x => x.Lessons)
                .HasForeignKey(x => x.SubjectId);

            builder.HasOne(x => x.Schedule)
                .WithMany(x => x.Lessons)
                .HasForeignKey(x => x.ScheduleId);

            builder.HasOne(x => x.Teacher)
                .WithMany(x => x.Lessons)
                .HasForeignKey(x => x.TeacherId);
        }
    }
}