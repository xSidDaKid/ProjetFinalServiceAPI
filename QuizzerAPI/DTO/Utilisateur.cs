using System.Runtime.Serialization;

namespace QuizzerAPI.DTO
{
    [DataContract]
    public class Utilisateur
    {
        [DataMember]
        public string courriel { get; set; }

        [DataMember]
        public string nomUtilisateur { get; set; }

        [DataMember]
        public string motDePasse { get; set; }

    }
}