using System;
using System.IO;
using System.Linq;
using ECommerceApp.Interfaces;
using ECommerceApp.Models;
using SQLite.Net;
using SQLiteNetExtensions.Extensions;
using Xamarin.Forms;

namespace ECommerceApp.Data
{
    public class DataAccess : IDisposable
    {
        private SQLiteConnection connection;

        public DataAccess()
        {
            var config = DependencyService.Get<IConfig>();
            connection = new SQLiteConnection(
                config.Platform, Path.Combine(config.DirectoryDB, "ECommerce.db3"));

            connection.CreateTable<Category>();
            connection.CreateTable<City>();
            connection.CreateTable<Company>();
            connection.CreateTable<CompanyCustomer>();
            connection.CreateTable<Customer>();
            connection.CreateTable<Department>();
            connection.CreateTable<Inventory>();
            connection.CreateTable<Order>();
            connection.CreateTable<OrderDetail>();
            connection.CreateTable<OrderDetailTmp>();
            connection.CreateTable<Product>();
            connection.CreateTable<Sale>();
            connection.CreateTable<State>();
            connection.CreateTable<Tax>();
            connection.CreateTable<User>();
        }

        public void Insert<T>(T model)
        {
            connection.Insert(model);
        }

        public void Update<T>(T model)
        {
            connection.Update(model);
        }

        public void Delete<T>(T model)
        {
            connection.Delete(model);
        }

        public T First<T>(bool withChildren) where T : class
        {
            if (withChildren)
            {
                return connection.GetAllWithChildren<T>().FirstOrDefault();
            }
            else
            {
                return connection.Table<T>().FirstOrDefault();
            }
        }

		public T Find<T>(int pk, bool withChildren) where T : class
		{
			if (withChildren)
			{
                return connection.GetAllWithChildren<T>().FirstOrDefault(
                    m => m.GetHashCode() == pk);
			}
			else
			{
				return connection.Table<T>().FirstOrDefault(m => m.GetHashCode() == pk);
			}
		}

        public void Dispose()
        {
            connection.Dispose();
        }
    }
}
