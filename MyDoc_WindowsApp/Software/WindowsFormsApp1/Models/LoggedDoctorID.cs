using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyDoc.Models
{
    public class LoggedDoctorID
    {
        private static LoggedDoctorID instance;

        public int ID { get; private set; }

        private LoggedDoctorID() { }    

        public static LoggedDoctorID Instance
        {
            get
            {
                if (instance == null)
                {
                    instance = new LoggedDoctorID();
                }
                return instance;
            }
        }
        public void SetDoctorID(int id)
        {
            ID = id;
        }
        public int GetDoctorID()
        {
            return ID;
        }
    }    

}
