using System;
using System.Collections.Generic;
using System.Runtime.Serialization;

namespace QuizzerAPI.DTO
{
    [DataContract]
    public class Quiz
    {
        [DataMember]
        public string titre { get; set; }

        [DataMember]
        public string question { get; set; }

        [DataMember]
        public List<String> choix { get; set; }

        [DataMember]
        public Dictionary<String, String> reponses { get; set; }

    }
}