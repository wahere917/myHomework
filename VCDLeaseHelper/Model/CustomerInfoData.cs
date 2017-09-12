using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace VCDLeaseHelper.Model
{
    public class CustomerInfoData : INotifyPropertyChanged
    {
        private Dictionary<int, CustomerInfo> customerInfoDic = new Dictionary<int, CustomerInfo>();
        public Dictionary<int, CustomerInfo> CustomerInfoDic
        {
            get
            {
                return customerInfoDic;
            }
            set
            {
                customerInfoDic = value;
                NotifyPropertyChanged("CustomerInfoDic");
            }
        }
        private CustomerInfo selectData;
        public CustomerInfo SelectData
        {
            get
            {
                return this.selectData;
            }
            set
            {
                this.selectData = value;
                NotifyPropertyChanged("SelectData");
            }
        }
        private string newName;
        public string NewName
        {
            get
            {
                return newName;
            }
            set
            {
                newName = value;
                NotifyPropertyChanged("NewName");
            }
        }
        public event PropertyChangedEventHandler PropertyChanged;
        public void NotifyPropertyChanged(string propertyName)
        {
            if (PropertyChanged != null)
            {
                PropertyChanged(this, new PropertyChangedEventArgs(propertyName));
            }
        }
    }
    public class CustomerInfo : INotifyPropertyChanged
    {
        private string name;
        public string Name
        {
            get
            {
                return name;
            }
            set
            {
                name = value;
                NotifyPropertyChanged("Name");
            }
        }
        private double historyIntegral;
        public double HistoryIntegral
        {
            get
            {
                return historyIntegral;
            }
            set
            {
                historyIntegral = value;
                NotifyPropertyChanged("HistoryIntegral");
            }
        }


        public event PropertyChangedEventHandler PropertyChanged;
        public void NotifyPropertyChanged(string propertyName)
        {
            if (PropertyChanged != null)
            {
                PropertyChanged(this, new PropertyChangedEventArgs(propertyName));
            }
        }
    }
}
