using Logic;
using Logic.Interfaces;
using Logic.Models;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Data
{
    public class DiscountRepository : DataHandler, IDiscountRepository
    {
        protected override string Cmd
        {
            get
            {
                return "SELECT Discount.[Id], [Type], [MinSpend] ,[MaxDiscount] ,[ProductId] ,[Percentage] ,[CouponCode] FROM [Discount]";
            }
        }

        private List<IDiscount> _discountList = new List<IDiscount>();

        public DiscountRepository()
        {
            _discountList = GetAllDiscounts();
        }

        public List<IDiscount> GetAllDiscounts()
        {
            List<IDiscount> Discounts = new List<IDiscount>();

            //get datatable of queried data
            DataTable? table = base.ReadData();

            if (table == null) { return Discounts; }

            //itterate trough all datarows, validate and convert to objects
            foreach (DataRow dr in table.Rows)
            {
                var _type = dr["Type"];
                if (dr.IsNull("Type") || _type == DBNull.Value) { continue; }


                switch (Convert.ToInt16(_type))
                {
                    case 0:
                        Discounts.Add(new CouponDiscount(dr["CouponCode"].ToString(), Convert.ToInt16(dr["Percentage"]), Convert.ToDouble(dr["MinSpend"]), Convert.ToDouble(dr["MaxDiscount"])));
                        break;
                    case 1:
                        Discounts.Add(new GetThreePayTwo(Convert.ToInt32(dr["ProductId"])));
                        break;

                    default: continue;
                }
            }

            //return collection of objects
            return Discounts;

        }

        public List<IDiscount> GetAllActiveDiscounts()
        {
            List<IDiscount> Discounts = new List<IDiscount>();

            //get datatable of queried data
            DataTable? table = base.ReadData("SELECT Discount.[Id], [Type], [MinSpend] ,[MaxDiscount] ,[ProductId] ,[Percentage] ,[CouponCode] FROM [Discount] WHERE [Active] = 1");

            if (table == null) { return Discounts; }

            //itterate trough all datarows, validate and convert to objects
            foreach (DataRow dr in table.Rows)
            {
                var _type = dr["Type"];
                if (dr.IsNull("Type") || _type == DBNull.Value) { continue; }


                switch (Convert.ToInt16(_type))
                {
                    case 0:
                        Discounts.Add(new CouponDiscount(dr["CouponCode"].ToString(), Convert.ToInt16(dr["Percentage"]), Convert.ToDouble(dr["MinSpend"]), Convert.ToDouble(dr["MaxDiscount"])));
                        break;
                    case 1:
                        Discounts.Add(new GetThreePayTwo(Convert.ToInt32(dr["ProductId"])));
                        break;

                    default: continue;
                }
            }

            //return collection of objects
            return Discounts;

        }

        public void refreshDiscountData()
        {
            _discountList.Clear();
            _discountList.AddRange(GetAllDiscounts());
        }
    }
}
