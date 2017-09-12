using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using VCDLeaseHelper.Model;
using static VCDLeaseHelper.Data.ConstData;

namespace VCDLeaseHelper.Common
{
    public static class ModelCalClass
    {
        public static void CalculatePrice(CalModel modelData)
        {
            modelData.TotalPrice = (double)(CalConst.mainlandP * modelData.MainlandNum + 
                CalConst.hkP * modelData.HKNum + CalConst.foreignP * modelData.ForeignNum) * modelData.Days;
        }

        public static double QueryIntegral(string customerName, Dictionary<string, double> customerIntegralDic)
        {
            double integral = 0;
            if (customerIntegralDic.ContainsKey(customerName))
                integral = customerIntegralDic[customerName];
            return integral;
        }

        public static void CalculateIntegral(CalModel modelData)
        {
            modelData.Integral = (double)(CalConst.mAndHI * (modelData.MainlandNum + modelData.HKNum) +
                CalConst.foreignI * modelData.ForeignNum) * modelData.Days;
        }
    }
}
