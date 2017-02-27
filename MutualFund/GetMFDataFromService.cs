using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;

namespace MutualFund
{
    public class GetMFDataFromService
    {
        DataTable table = new DataTable("mutualfund");
        
        //Calls mutual fund service to get mutual fund data
        public DataTable getMutualFundDatatable()
        {
            MutualFundService.MutualFundServiceClient client= new MutualFundService.MutualFundServiceClient("BasicHttpBinding_IMutualFundService");
            table = client.GetMutualFundData();
            return table;
        }
    }
}