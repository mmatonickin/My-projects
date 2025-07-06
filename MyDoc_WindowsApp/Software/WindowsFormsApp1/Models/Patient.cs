using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyDoc.Models
{
    public partial class Patient
    {
        public bool CheckPassword(string password)
        {
            return Password == HashPassword.Password(password);
        }
        
    }
}
