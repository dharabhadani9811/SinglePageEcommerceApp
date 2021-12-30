using DharaProject.Models.Generic;
using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

namespace DharaProject.Models
{
    public class UserModel : IdentityUser<Guid>, IIdentity<Guid>
    {
        

        public string FirstName { get; protected set; }

        public string LastName { get; protected set; }

        public string EmailID { get; protected set; }
        public string Address { get; protected set; }
        [JsonIgnore]
        public string Password { get; set; } = default!;

        protected UserModel() : base()
        {
            Id = Guid.NewGuid();
            FirstName = default!;
            LastName = default!;
            EmailID = default!;
            Address = default!;
        }

        public UserModel(string firstname, string lastname, string emailId, string address):base(emailId)
        {
            Id= Guid.NewGuid();
            FirstName = firstname;
            LastName = lastname;
            EmailID = emailId ?? throw new NullReferenceException(nameof(emailId));
            Address = address;
        }

    }
}
