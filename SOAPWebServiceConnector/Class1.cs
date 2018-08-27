using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Newtonsoft.Json;

namespace SOAPWebServiceConnector
{
    public class SOAPWebServiceConnector
    {
        public Dictionary<string, string> GetBankByBLZCode(string BLZCode)
        {
            BLZWebService.BLZService BankBLZWS = new BLZWebService.BLZService();
            BLZWebService.detailsType BankDetails = new BLZWebService.detailsType();

            BankDetails = BankBLZWS.getBank(BLZCode);

            var BankDetailsDict = ToDictionary<string>(BankDetails);

            return BankDetailsDict;
        }


        public static Dictionary<string, TValue> ToDictionary<TValue>(object obj)
        {
            var json = JsonConvert.SerializeObject(obj);
            var dictionary = JsonConvert.DeserializeObject<Dictionary<string, TValue>>(json);
            return dictionary;
        }
    }
}
