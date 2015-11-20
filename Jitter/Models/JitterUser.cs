using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace Jitter.Models
{
    public class JitterUser
    {
        [Key]
        public int JitterUserId { get; set; }

        [MaxLength(161)]
        public string Description { get; set; }
        public string FirstName { get; set; }

        [Required]
        [MaxLength(20)]
        [MinLength(3)]
        [RegularExpression(@"^[a-zA-Z\d]+[-_a-zA-Z\d]{0,2}[a-zA-Z\d]+")]
        public string Handle { get; set; }

        public string LastName { get; set; }
        public string Picture { get; set; }

        //Icollection, IEnumerable, IQueryable - All interfaces - 
        public List<Jot> Jots { get; set; }

        //Those we are following
        public List<JitterUser> Following { get; set; }

        //One way to do it, not only way.  List of who is following us. 
        //public List<JitterUser> Followers { get; set; }



    }
}