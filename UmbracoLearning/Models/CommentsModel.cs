using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace UmbracoLearning.Models
{
    public class CommentsModel
    {
        public int ID { get; set; }
        public string txtName { get; set; }
        public string txtEmail { get; set; }
        public int txtPhone { get; set; }
        public string txtMsg { get; set; }
    }
}