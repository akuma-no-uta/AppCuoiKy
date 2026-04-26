using BasicGroceryStore.DataAccessLayer;
using System;
using System.Collections.Generic;
using System.Data;

namespace BasicGroceryStore
{
    internal class BUS_Ordered : IBillServices
    {
        private DAO_Bill dao;
        public DAO_Promotion daoPromotion;
        public BUS_Ordered()
        {
            dao = new DAO_Bill("Ordered");
        }

        public bool Create(Bill bill, string customerName = "")
        {
            return dao.Create(bill, customerName);
        }

        public bool Update(Bill bill, string customerName = "")
        {
            return dao.Update(bill, customerName);
        }

        public bool Delete(Bill bill)
        {
            return dao.Delete(bill);
        }

        public DataTable GetAllBill()
        {
            return dao.GetAllBill();
        }

        public int GetQuantityOfBill()
        {
            return dao.GetQuantityOfBill();
        }

        public float GetValueOfBill(string bill_id)
        {
            return dao.GetValueOfBill(bill_id);
        }

        public DataTable GetAllItemInBill(string bill_id)
        {
            return dao.GetAllItemInBill(bill_id);
        }

        public double? GetValueOfAllBills()
        {
            double? value = dao.GetValueOfAllBills();
            return (value != null) ? value.Value : 0d;
        }
        public bool CheckCustomerExists(string name, string phone)
        {
            return dao.CheckCustomerExists(name, phone);
        }
        public double? GetValueOfAllBills_Day(DateTime date)
        {
            double? value = dao.GetValueOfAllBills_Day(date);
            return (value != null) ? value.Value : 0d;
        }

        public double? GetValueOfAllBills_Month(DateTime date)
        {
            double? value = dao.GetValueOfAllBills_Month(date);
            return (value != null) ? value.Value : 0d;
        }
        public Dictionary<string, int> GetTopSellingProducts()
        {
            return dao.GetTopSellingProducts();
        }
      
    }
}
