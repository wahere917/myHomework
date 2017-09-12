using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace VCDLeaseHelper.Model
{
    public class CalModel: INotifyPropertyChanged
    {
        /// <summary>  
        /// 大陆片数 
        /// </summary>
        private int mainlandNum;
        public int MainlandNum
        {
            get
            {
                return mainlandNum;
            }
            set
            {
                mainlandNum = value;
                NotifyPropertyChanged("MainlandNum");
            }
        }
        private int hkNum;
        public int HKNum
        {
            get
            {
                return hkNum;
            }
            set
            {
                hkNum = value;
                NotifyPropertyChanged("HKNum");
            }
        }
        private int foreignNum;
        public int ForeignNum
        {
            get
            {
                return foreignNum;
            }
            set
            {
                foreignNum = value;
                NotifyPropertyChanged("ForeignNum");
            }
        }
        private int days=1;
        public int Days
        {
            get
            {
                return days;
            }
            set
            {
                days = value;
                NotifyPropertyChanged("Days");
            }
        }
        private double totalPrice;
        public double TotalPrice
        {
            get
            {
                return totalPrice;
            }
            set
            {
                totalPrice = value;
                NotifyPropertyChanged("TotalPrice");
            }
        }
        private double integral;
        public double Integral
        {
            get
            {
                return integral;
            }
            set
            {
                integral = value;
                NotifyPropertyChanged("Integral");
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
