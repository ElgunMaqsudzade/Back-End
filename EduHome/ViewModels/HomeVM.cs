using EduHome.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace EduHome.ViewModels
{
    public class HomeVM
    {
        public List<NoticeBoard> NoticeBoards { get; set; }
        public VideoTour VideoTour { get; set; }
        public List<EventSimple> EventSimples { get; set; }
        public List<Slider> HomeSliders { get; set; }
        public List<TeacherSimple> TeacherSimples { get; set; }
    }
}
