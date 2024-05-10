using System;

namespace ASPCoreMVCRepoDB.Models
{
   [Serializable]
   public class Athletes
   {
      public int ID { get; set; }
      public string Name { get; set; }
      public int Age { get; set; }
      public string Country { get; set; }
      public string Sport { get; set; }
      public decimal Allowance { get; set; }
      public decimal Weight { get; set; }
      public decimal Height { get; set; }
      public string Gender { get; set; }

      public Athletes()
      {
         ID = 0;
         Name = string.Empty;
         Age = 0;
         Country = string.Empty;
         Sport = string.Empty;
         Allowance = 0;
         Weight = 0;
         Height = 0;
         Gender = string.Empty;
      }
   }
}
