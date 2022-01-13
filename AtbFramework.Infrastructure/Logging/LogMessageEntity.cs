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

        public LogMessageEntity(bool isSucces)
        {
            _isSuccess = isSucces;

        }
        public LogMessageEntity(bool isSucces, List<string> messages):this(isSucces)
        {
            _messages = messages;
        }


        public override string ToString()
        {
            if (!_isSuccess)
            {
                return string.Format("{0},{1}", "ErrorOcurred", String.Join(", ", _messages.ToArray()));
                    
            }else
            {
                return string.Format("TransactionCompletedSuccessfully.");

            }
        }

        public static string ToManuelSingleString(string manuelString)
        {
            manuelString = _messages[0];
            return manuelString;
        }
    }
}
