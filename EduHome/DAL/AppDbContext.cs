using EduHome.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace EduHome.DAL
{
    public class AppDbContext:DbContext
    {
        public AppDbContext(DbContextOptions<AppDbContext> options):base(options)
        {

        }

        public DbSet<AboutArea> AboutAreas { get; set; }
        public DbSet<TestimonialArea> TestimonialAreas { get; set; }
        public DbSet<TeacherSimple> TeacherSimples { get; set; }
        public DbSet<TeacherDetail> TeacherDetails { get; set; }
        public DbSet<SocialMedia> SocialMedias { get; set; }
        public DbSet<VideoTour> VideoTours { get; set; }
        public DbSet<NoticeBoard> NoticeBoards { get; set; }
        public DbSet<TeacherSkill> TeacherSkills { get; set; }
    }
}
