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
        public DbSet<BlogSimple> BlogSimples { get; set; }
        public DbSet<BlogDetail> BlogDetails { get; set; }
        public DbSet<Comment> Comments { get; set; }
        public DbSet<SectionTitle> SectionTitles { get; set; }
        public DbSet<CourseSimple> CourseSimples { get; set; }
        public DbSet<CourseDetail> CourseDetails { get; set; }
        public DbSet<CourseFeature> CourseFeatures { get; set; }
    }
}
