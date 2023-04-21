using SalesRecordsAPI.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace SalesRecordsAPI.Controllers
{
    public class SalesRecordsController : ApiController
    {
        //GET : api/SalesRecords
        public HttpResponseMessage Get()
        {
            List<SalesRecord> salesrecords = new List<SalesRecord>();

            using (SalesRecordsAPIContext dbContext = new SalesRecordsAPIContext())
            {
                salesrecords = dbContext.SalesRecords.ToList();
                if (salesrecords.Count == 0)
                {
                    return Request.CreateResponse(HttpStatusCode.InternalServerError, "Please try again later");
                }
                return Request.CreateResponse(HttpStatusCode.OK, salesrecords);
            }
        }

        //GET : api/SalesRecords/id
        public HttpResponseMessage Get(int id)
        {
            using (SalesRecordsAPIContext dbContext = new SalesRecordsAPIContext())
            {
                var salesrcrd = dbContext.SalesRecords.FirstOrDefault(s => s.Order_ID == id);
                if (salesrcrd != null)
                {
                    return Request.CreateResponse(HttpStatusCode.OK, salesrcrd);
                }
                else
                {
                    return Request.CreateResponse(HttpStatusCode.NotFound, "SalesRecord with Order_ID " + id + " not found in our database");
                }
            }
        }

        //POST : api/SalesRecords/
        public HttpResponseMessage Post(SalesRecord salesRecord)
        {
            using (SalesRecordsAPIContext dbContext = new SalesRecordsAPIContext())
            {
                if (salesRecord != null)
                {
                    dbContext.SalesRecords.Add(salesRecord);
                    dbContext.SaveChanges(); // this line of code is needed to save the data in the database
                    return Request.CreateResponse(HttpStatusCode.Created, salesRecord);
                }
                else
                {
                    return Request.CreateResponse(HttpStatusCode.BadRequest, "Please provide the required information");
                }
            }

        }

        //PUT : api/SalesRecords/id
        public HttpResponseMessage Put(int id, SalesRecord salesRecord)
        {
            using (SalesRecordsAPIContext dbContext = new SalesRecordsAPIContext())
            {
                var salesrcrd = dbContext.SalesRecords.FirstOrDefault(s => s.Order_ID == id);
                if (salesrcrd != null)
                {
                    salesrcrd.Region = salesRecord.Region;
                    salesrcrd.Country = salesRecord.Country;
                    salesrcrd.Item_Type = salesRecord.Item_Type;
                    salesrcrd.Sales_Channel = salesRecord.Sales_Channel;
                    salesrcrd.Order_Priority = salesRecord.Order_Priority;
                    salesrcrd.Order_Date = salesRecord.Order_Date;
                    salesrcrd.Ship_Date = salesRecord.Ship_Date;
                    salesrcrd.Units_Sold = salesRecord.Units_Sold;
                    salesrcrd.Unit_Price = salesRecord.Unit_Price;
                    salesrcrd.Unit_Cost = salesRecord.Unit_Cost;
                    salesrcrd.Total_Revenue = salesRecord.Total_Revenue;
                    salesrcrd.Total_Cost = salesRecord.Total_Cost;
                    salesrcrd.Total_Profit = salesRecord.Total_Profit;

                    dbContext.SaveChanges();

                    return Request.CreateResponse(HttpStatusCode.OK, salesrcrd);
                }
                else
                {
                    return Request.CreateResponse(HttpStatusCode.NotFound, "SalesRecord with Order_ID " + id + " not found in our database");
                }

            }
        }

        //DELETE : api/SalesRecords/id
        public HttpResponseMessage Delete(int id)
        {
            using (SalesRecordsAPIContext dbContext = new SalesRecordsAPIContext())
            {
                var salesrcrd = dbContext.SalesRecords.FirstOrDefault(s => s.Order_ID == id);
                if (salesrcrd != null)
                {
                    dbContext.SalesRecords.Remove(salesrcrd);
                    dbContext.SaveChanges();
                    return Request.CreateResponse(HttpStatusCode.OK, salesrcrd);
                }
                else
                {
                    return Request.CreateResponse(HttpStatusCode.NotFound, "SalesRecord with Order_ID " + id + " not found in our database");
                }
            }
        }
    }
}