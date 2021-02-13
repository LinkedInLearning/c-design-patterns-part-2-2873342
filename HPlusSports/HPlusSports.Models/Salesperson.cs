using System;
using System.Collections.Generic;

namespace HPlusSports.Models
{
    public partial class Salesperson : TrackedEntity
    {
        private string firstName; 
        private string lastName; 
        private string email; 
        private string phone; 
 
        public Salesperson()
        {
            Order = new HashSet<Order>();
        }

        public string FirstName { get => firstName; set => firstName = NotifyIfChanged(firstName, value); } 
        public string LastName { get => lastName; set => lastName = NotifyIfChanged(lastName, value); } 
        public string Email { get => email; set => email = NotifyIfChanged(email, value); }
        public string Phone { get => phone; set => phone = NotifyIfChanged(phone, value); } 
 
       
        public string SalesGroupState { get; set; }
        public int SalesGroupType { get; set; }

        public string FullName { get { return FirstName + " " + LastName; } }

        public virtual ICollection<Order> Order { get; set; }

        public virtual SalesGroup SalesGroup { get; set; }

    }
}
