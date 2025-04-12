using Fordonshanteringssystem.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Fordonshanteringssystem.Errors
{
    public class BrakeFailureError: SystemError
    {
        public override string ErrorMessage()
        {
            return "Bromsfel: Fordonet är osäkert att köra!";
        }
    }
}
