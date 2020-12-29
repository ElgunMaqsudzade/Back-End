using EduHome.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace EduHome.ViewModels
{
    public class ContactVM
    {
        public MapAddress MapAddress { get; set; }
        public List<Contact> Contacts { get; set; }
    }
}
