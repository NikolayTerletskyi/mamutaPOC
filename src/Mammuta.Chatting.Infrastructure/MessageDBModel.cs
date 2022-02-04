using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Mammuta.Chatting.Infrastructure
{
    internal class MessageDBModel
    {
        public string UserId { get; set; }

        public string GroupId { get; set; }

        public string Text { get; set; }
    }
}
