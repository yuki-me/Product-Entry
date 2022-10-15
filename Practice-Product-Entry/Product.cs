﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Practice_Product_Entry
{
    public class Product
    {
        protected string m_id;
        protected string m_name;
        protected double m_price;
        public Product()
        {
            m_id = "0";
            m_name = "default";
            m_price = 0.0;
        }
        public Product(string id, string name, double price)
        {
            m_id = id;
            m_name = name;
            m_price = price;
        }
        public string Id
        {
            get { return m_id; }
            set { m_id = value; }
        }
        public string Name
        {
            get { return m_name; }
            set { m_name = value; }
        }
        public double Price
        {
            get { return m_price; }
            set { m_price = value; }
        }
        public bool ValidDate
        {
            get
            {
                if(Id == null)
                {
                    return false;
                }
                if (Id.Trim().Equals(""))
                {
                    return false;
                }
                if(Name == null)
                {
                    return false;
                }
                if (Name.Trim().Equals(""))
                {
                    return false;
                }
                if (Price < 0)
                {
                    return false;
                }return true;
            }
        }
        public string Info
        {
            get
            {
                return string.Format($"{Name}({Id}, {Price})");
            }
        }
    }
}
