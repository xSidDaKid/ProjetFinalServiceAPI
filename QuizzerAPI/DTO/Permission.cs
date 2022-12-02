using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Web;

namespace QuizzerAPI.DTO
{
    public class Permission
    {

        [DataMember]
        public int idQuiz { get; set; }

        [DataMember]
        public int idUtilisateur { get; set; }

        [DataMember]
        public int score { get; set; }
    }
}