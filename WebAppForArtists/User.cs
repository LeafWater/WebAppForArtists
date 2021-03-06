//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated from a template.
//
//     Manual changes to this file may cause unexpected behavior in your application.
//     Manual changes to this file will be overwritten if the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace WebAppForArtists
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel;
    using System.ComponentModel.DataAnnotations;
    
    public partial class User
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public User()
        {
            this.Pictures = new HashSet<Picture>();
        }
    
        public int UserID { get; set; }
        [Required(ErrorMessage = "Your name is required")]
        public string FirstName { get; set; }
        //[Required(ErrorMessage = "Your lastname address is required")] 
        public string LastName { get; set; }
        [Required(ErrorMessage = "The email address is required")]
        [EmailAddress(ErrorMessage = "Invalid email address")]
        public string Email { get; set; }
        [Required(ErrorMessage = "Pasword is required")]
        [DataType(DataType.Password)]
        [Compare("ConfirmedPassword", ErrorMessage = "The Password and Confirm Password fields do not match.")]
        public string Password { get; set; }
        [DataType(DataType.Password)]
        [DisplayName("Confirm your password.")]
        //[Compare("Password")]
        public string ConfirmedPassword { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<Picture> Pictures { get; set; }
    }
}
