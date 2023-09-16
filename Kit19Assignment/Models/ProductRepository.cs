using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Web;

namespace Kit19Assignment.Models
{
    public class ProductRepository
    {
        string conn = ConfigurationManager.ConnectionStrings["connectionString"].ConnectionString;

        public List<Product> GetAllProducts()
        {
            List<Product> products = new List<Product>();

            using (SqlConnection connection = new SqlConnection(conn))
            {
                using (SqlCommand command = new SqlCommand("SELECT * FROM Product", connection))
                {
                    try
                    {
                        if(connection.State == ConnectionState.Closed)
                        {
                            connection.Open();
                            using (SqlDataReader dataReader = command.ExecuteReader())
                            {
                                while (dataReader.Read())
                                {
                                    Product product = new Product()
                                    {
                                        Product_ID = Convert.ToInt32(dataReader["Product_ID"]),
                                        Product_Name = dataReader["Product_Name"].ToString(),
                                        Size = dataReader["Size"].ToString(),
                                        Price = Convert.ToInt32(dataReader["Price"]),
                                        Manufacture_date = Convert.ToDateTime(dataReader["Manufacture_date"]),
                                        Category = dataReader["Category"].ToString(),
                                    };
                                    products.Add(product);
                                }
                                dataReader.Close();
                                return products;
                            }
                        } 
                    }
                    catch (SqlException ex)
                    {
                        throw ex;
                    }
                    finally
                    {
                        if(connection.State == ConnectionState.Open)
                        {
                            connection.Close();
                        }
                    }
                }
            }

            return null;
        }

        public List<Product> SearchProducts(SearchProduct searchProduct)
        {
            using (SqlConnection connection = new SqlConnection(conn))
            {
                using (SqlCommand command = new SqlCommand("SearchProducts", connection))
                {
                    command.CommandType = CommandType.StoredProcedure;
                    command.Parameters.AddWithValue("@Product_Name", (object)searchProduct.Product_Name ?? DBNull.Value);
                    command.Parameters.AddWithValue("@Size", (object)searchProduct.Size ?? DBNull.Value);
                    command.Parameters.AddWithValue("@Price", (object)searchProduct.Price ?? DBNull.Value);
                    command.Parameters.AddWithValue("@Manufacture_date", (object)searchProduct.Manufacture_date ?? DBNull.Value);
                    command.Parameters.AddWithValue("@Category", (object)searchProduct.Category ?? DBNull.Value);
                    command.Parameters.AddWithValue("@Conjunction", (object)searchProduct.Conjunction ?? DBNull.Value);

                    try
                    {
                        if (connection.State == ConnectionState.Closed)
                        {
                            connection.Open();
                            using (SqlDataReader dataReader = command.ExecuteReader())
                            {
                                List<Product> products = new List<Product>();
                                while (dataReader.Read())
                                {
                                    Product product = new Product()
                                    {
                                        Product_ID = Convert.ToInt32(dataReader["Product_ID"]),
                                        Product_Name = dataReader["Product_Name"].ToString(),
                                        Size = dataReader["Size"].ToString(),
                                        Price = Convert.ToInt32(dataReader["Price"]),
                                        Manufacture_date = Convert.ToDateTime(dataReader["Manufacture_date"]),
                                        Category = dataReader["Product_ID"].ToString(),
                                    };
                                    products.Add(product);

                                }
                                dataReader.Close();
                                searchProduct.Products = products;
                                return products;
                            }
                        }
                    }
                    catch (SqlException ex)
                    {
                        throw ex;
                    }
                    finally
                    {
                        if (connection.State == ConnectionState.Open)
                            connection.Close();
                    }
                }
            }
            return null;
        }
    }
}