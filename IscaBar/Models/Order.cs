using IscaBar.Model;
using SQLite;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Text;

namespace IscaBar.Models
{
    [Table("table")]
    public class Order:ModelBase
    {
        private int id;
        private int num;
        private int diners;
        private string client;
        private string waiter;
        private decimal total;
        private ArrayList orders;

        [PrimaryKey, AutoIncrement]
        public int Id { get { return id; } set { id = value; OnPropertyChanged(); } }
        public int Table { get { return num; } set { num = value; OnPropertyChanged(); } }
        public int Pax { get { return diners; } set { diners = value; OnPropertyChanged(); } }
        public string Clients { get { return client; } set { client = value; OnPropertyChanged(); } }
        public string Waiter { get { return waiter; } set { waiter = value; OnPropertyChanged(); } }
        public decimal tPrice { get { return total; } set { total = value; OnPropertyChanged(); } }
        public ArrayList OrderLine { get { return orders; } set { orders = value; OnPropertyChanged(); } }
    }
}
