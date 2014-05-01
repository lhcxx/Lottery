using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LotteryBuz
{
    public class ProgressController
    {
        private string _msg;
        public event Action<string> MessageChanged;

        public bool Cancel { get; set; }

        public string Message
        {
            get { return _msg; }
            set
            {
                _msg = value;
                OnMessageChanged();
            }
        }

        public bool CanCancel
        {
            get;
            set;
        }
        private void OnMessageChanged()
        {
            if (MessageChanged != null)
                MessageChanged(_msg);
        }
    }
}
