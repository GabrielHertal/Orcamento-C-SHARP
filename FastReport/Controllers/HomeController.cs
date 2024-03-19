using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;
using FastReport.DataVisualization.Charting;

namespace Orçamento.FastReport.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class HomeController : ControllerBase
    {
        [HttpGet(nameof(GetData))]
        public RespondeDataModel GetData()
        {
            return RespondeData();
        }
        public static RespondeDataModel RespondeData()
        {
            var response = new RespondeDataModel
            {
                Header = "FastReprt Header",
                Content = "FastReprt Content",
                Footer = "FastReprt Footer",
            };
            List<OneMoreDataModel> collection = new();
            for (int i = 0; i < 20; i++)
            {
                collection.Add(new OneMoreDataModel { Number = i + 1 });
            }
            response.Collection = collection;
            return response;
        }
    }
}
