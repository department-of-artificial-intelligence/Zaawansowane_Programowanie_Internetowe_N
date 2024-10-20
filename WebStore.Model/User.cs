using System;

namespace WebStore.Model;
public class User : IdentityUser<int>
{
   public string FirstName { get; set; }
   public string LastName { get; set; }
   public DateTime RagistrationData { get; set; }

}
