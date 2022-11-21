using System;
using System.Collections.Generic;
using System.Runtime.Serialization;

namespace QuizzerAPI.DTO
{
    [DataContract]
    public class Quiz
    {
        [DataMember]
        public int idQuiz { get; set; }

        [DataMember]
        public string titre { get; set; }

        [DataMember]
        public string question { get; set; }

        [DataMember]
        public string choix { get; set; }

        [DataMember]
        public string reponses { get; set; }

    }
}