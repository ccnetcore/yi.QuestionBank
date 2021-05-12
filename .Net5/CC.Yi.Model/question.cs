using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace CC.Yi.Model
{
    public class question
    {
        [Key]
        [DatabaseGeneratedAttribute(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }
        public string type { get; set; }
        public string subject { get; set; }
        public string question_a { get; set; }
        public string question_b { get; set; }
        public string question_c { get; set; }
        public string question_d { get; set; }
        public char answer { get; set; }
        public int difficulty { get; set; }
    }
}
