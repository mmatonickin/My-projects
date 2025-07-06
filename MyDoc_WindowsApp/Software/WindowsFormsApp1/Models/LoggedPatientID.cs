using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyDoc.Models
{
    public class LoggedPatientID
    {
        private static LoggedPatientID instance;
        public int ID { get; private set; }

        private LoggedPatientID() { }

        public static LoggedPatientID Instance
        {
            get
            {
                if (instance == null)
                {
                    instance = new LoggedPatientID();
                }
                return instance;
            }
        }

        public void SetPatientID(int id)
        {
            ID = id;
        }

        public int GetPatientID()
        {
            return ID;
        }
    }
}
