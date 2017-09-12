using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.IO;
using System.Text;
using VCDLeaseHelper.Common;
using VCDLeaseHelper.Model;
using static VCDLeaseHelper.Common.CommonData;

namespace VCDLeaseHelper.ViewModel
{
    public class HelperViewModel : NotifyPropertyChanged
    {
        string path = @"CustomerInfo/CustomerInfo.json";
        public CalModel modelData = new CalModel();
        /// <summary>  
        /// 计算实体类  
        /// </summary>  
        public CalModel ModelData
        {
            get
            {
                return this.modelData;
            }
            set
            {
                this.modelData = value;
                this.RasePropertyChange("ModelData");
            }
        }
        /// <summary>  
        /// 顾客积分管理类 
        /// </summary>  
        public ManagerModel customerData = new ManagerModel();
        public ManagerModel CustomerData
        {
            get
            {
                return this.customerData;
            }
            set
            {
                this.customerData = value;
                this.RasePropertyChange("CustomerData");
            }
        }        

        public HelperViewModel()
        {
            GetCustomerInfo();
            this.CalPrice = new DelegateCommands();
            CalPrice.ExecuteHander += new Action<object>(AddResult);
            this.AddNewCustomer = new DelegateCommands();
            AddNewCustomer.ExecuteHander += new Action<object>(AddCustomerInfo);
            this.CalIntegral = new DelegateCommands();
            CalIntegral.ExecuteHander += new Action<object>(CalTheIntegral);
            this.AddIntegral = new DelegateCommands();
            AddIntegral.ExecuteHander += new Action<object>(AddTheIntegral);
        }
        public DelegateCommands CalPrice { get; set; }
        public DelegateCommands AddNewCustomer { get; set; }
        public DelegateCommands CalIntegral { get; set; }
        public DelegateCommands AddIntegral { get; set; }

        public void AddResult(object parameter)
        {
            ModelCalClass.CalculatePrice(modelData);
        }
        public void CalTheIntegral(object parameter)
        {
            ModelCalClass.CalculateIntegral(modelData);
        }      
        public void AddTheIntegral(object parameter)
        {   
            CustomerData.SelectData.HistoryIntegral += ModelData.Integral;
            SaveCustomerInfo();
            ModelData.Integral = 0;
        }
        public void AddCustomerInfo(object paramete)
        {
            if(!string.IsNullOrWhiteSpace(CustomerData.NewName))
            {
                CustomerData.CustomerInfoDic.Add(CustomerData.CustomerInfoDic.Count, new CustomerInfo() { Name = CustomerData.NewName, HistoryIntegral = 0 });
                CustomerData.NewName = null;
            }
        }

        public event PropertyChangedEventHandler PropertyChanged;
        private void GetCustomerInfo()
        {
            var source = System.IO.File.ReadAllText(path);
            CustomerData.CustomerInfoDic = JsonConvert.DeserializeObject<Dictionary<int, CustomerInfo>>(source);                      
        }

        private void SaveCustomerInfo()
        {
            File.WriteAllText(path, JsonConvert.SerializeObject(CustomerData.CustomerInfoDic, Formatting.Indented),
                    Encoding.Default);
        }
    }    
}
