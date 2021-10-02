using System;
using System.Collections.Generic;
using System.Text;

namespace Mahwous.Core.Interfaces
{
    public interface IEmailService
    {
        bool SendEmail(string title, string content);
    }
}
