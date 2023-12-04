using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Numero3.EntityFramework.Demo.DomainModel
{
    // Anemic model to keep this demo application simple.
    [Table("users")]
    public class User
	{
        [Column("id")]
        [Key]
        public Guid Id { get; set; }
        [Column("name")]
        public string Name { get; set; }
        [Column("email")]
        public string Email { get; set; }
        [Column("creditscore")]
        public int CreditScore { get; set; }
        [Column("welcomeemailsent")]
        public bool WelcomeEmailSent { get; set; }
        [Column("createdon")]
        public DateTime CreatedOn { get; set; }

		public override string ToString()
		{
			return String.Format("Id: {0} | Name: {1} | Email: {2} | CreditScore: {3} | WelcomeEmailSent: {4} | CreatedOn (UTC): {5}", Id, Name, Email, CreditScore, WelcomeEmailSent, CreatedOn.ToString("dd MMM yyyy - HH:mm:ss"));
		}
	}
}
