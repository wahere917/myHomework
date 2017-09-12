using System.Collections.Generic;
using VCDLeaseHelper.Common;
using VCDLeaseHelper.Model;

namespace TestConsole
{
    public static class TestCase
    {
        public static double CalculatePrice(int mainlandNum, int hkNum, int foreignNum, int days)
        {
            var totalPrice = (double)(2 * mainlandNum + 2.5 * hkNum + 3 * foreignNum) * days;
            return totalPrice;
        }

        public static double QueryIntegral(string customerName, Dictionary<string, double> customerIntegralDic)
        {
            double integral = 0;
            if (customerIntegralDic.ContainsKey(customerName))
                integral = customerIntegralDic[customerName];
            return integral;
        }

        public static double CalculateIntegral(int mainlandNum, int hkNum, int foreignNum, int days)
        {
            var totalIntegral = (double)(2 * (mainlandNum + hkNum) + 1.5 * foreignNum) * days;
            return totalIntegral;
        }
        public static double totalIntegral(string customerName, double integral, double totalIntegral)
        {
            return integral + totalIntegral;
        }
        //计算价格
        public static void CalPrice(CalModel data)
        {
            ModelCalClass.CalculatePrice(data);           
        }
        //计算积分
        public static void CalIntegral(CalModel data)
        {
            ModelCalClass.CalculateIntegral(data);
        }
        //添加用户
        public static void AddCustomer(ManagerModel customerData)
        {
            customerData.CustomerInfoDic.Add(customerData.CustomerInfoDic.Count, new CustomerInfo() { Name = customerData.NewName, HistoryIntegral = 0 });
            customerData.SelectData = customerData.CustomerInfoDic[customerData.CustomerInfoDic.Count-1];
        }
        //累加积分
        public static void CalHisIntegral(CalModel data,ManagerModel customerData)
        {
            customerData.SelectData.HistoryIntegral+= data.Integral;     
        }
    }
}
