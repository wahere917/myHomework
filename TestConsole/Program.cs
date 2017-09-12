using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using VCDLeaseHelper.Model;

namespace TestConsole
{
    class Program
    {
        static void Main(string[] args)
        {
            var modelData = new CalModel() {
                MainlandNum=2,
                HKNum=3,
                ForeignNum=1,
                Days=4
            };
            var customerData = new ManagerModel(){
                NewName="Jerry"
            };
            //计算价格
            TestCase.CalPrice(modelData);
            Console.WriteLine("总价格为：{0}", modelData.TotalPrice.ToString());
            TestCase.CalIntegral(modelData);
            Console.WriteLine("本次积分为：{0}", modelData.Integral.ToString());
            TestCase.AddCustomer(customerData);
            Console.WriteLine("添加{0}到常客名单", customerData.NewName.ToString());
            TestCase.CalHisIntegral(modelData, customerData);
            Console.WriteLine("{0}积分累计为：{1}", customerData.SelectData.Name, customerData.SelectData.HistoryIntegral);
            Console.ReadKey();

        }
    }
}
