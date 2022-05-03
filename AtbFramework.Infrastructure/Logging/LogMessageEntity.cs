using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AtbFramework.Infrastructure.Logging
{
    public class LogMessageEntity
    {
        internal bool _isSuccess { get; set; }

        public static List<string> _messages { get; internal set; }
        public static string _message { get; internal set; }

        public LogMessageEntity(string message)
        {
            _message = message;

        }

        public LogMessageEntity(List<string> messages)
        {
            _messages = messages;
        }

        public LogMessageEntity(List<string> messages, bool isSuccess) : this(messages)
        {
            _messages = messages;
            _isSuccess = isSuccess;
        }

        public LogMessageEntity(string message, bool isSuccess) : this(message)
        {
            _message = message;
            _isSuccess = isSuccess;

        }

        public override string ToString()
        {
            if (_isSuccess == false)
            {
                return string.Format("{0},{1}", "ErrorOcurred", String.Join(", ", _messages.ToArray()));

            }
            else
            {
                return string.Format("{0},{1}", "TransactionCompletedSuccessfully", String.Join(", ", _messages.ToArray()));

            }
        }

        public static string ToManuelSingleString(string manuelString)
        {
            manuelString = _messages[0];
            return manuelString;
        }
    }
}
