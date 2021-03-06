﻿using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore.Internal;
using Monito.Models;
using ORM;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Monito.Controllers
{
    public partial class DashboardController
    {
        [HttpPost]
        public JsonResult GetAllData(DateTime start, DateTime end)
        {
            var particle = (end - start).TotalSeconds / _total; // 确定粒度
            var date = new List<string>
                       {
                           $"{start.ToString(_format)}"
                       };
            var sql = new StringBuilder();
            for (var i = 0; i < _total; i++)
            {
                var e = start.AddSeconds(particle * (i + 1));
                if (i != 0)
                {
                    sql.Append("\r\n");
                }

                sql.Append($"SELECT COUNT(1) as Value FROM SqlLog WHERE EndTime > '{start.AddSeconds(particle * i):yyyy-MM-dd HH:mm:ss}' AND EndTime < '{e:yyyy-MM-dd HH:mm:ss}'");
                if (i != _total - 1)
                {
                    sql.Append(" UNION ALL");
                }

                date.Add($"{e.ToString(_format)}");
            }
            var data = TORM.Query<LongData>(sql.ToString()).Select(x => x.Value);
            return Json(new { data, date, particle = particle.ToString("0") });
        }

        [HttpPost]
        public JsonResult GetDbData(DateTime start, DateTime end)
        {
            var result = Get<LongData, long>(start, end, "SELECT COUNT(1) as Value FROM SqlLog WHERE DbName = '{0}' AND EndTime > '{1}' AND EndTime < '{2}'");
            return Json(result);
        }

        [HttpPost]
        public JsonResult GetErrorData(DateTime start, DateTime end)
        {
            var result = Get<LongData, long>(start, end, "SELECT COUNT(1) as Value FROM SqlLog WHERE IsError = 1 AND DbName = '{0}' AND EndTime > '{1}' AND EndTime < '{2}'");
            return Json(result);
        }

        [HttpPost]
        public JsonResult GetTotalSpanData(DateTime start, DateTime end)
        {
            var date = new[] { "<0.1ms", "0.1ms~1ms", "1ms~5ms", "1ms~5ms", "5ms~20ms", "20ms~50ms", "50ms~100ms", "100ms~200ms", "200ms~500ms", "500ms~1000ms", "1s~5s", ">5s" };

            var dataType = TORM.Query<SqlLog>()
                               .Select(x => x.DbName)
                               .Group(x => x.DbName)
                               .Find<string>();

            var sql = new StringBuilder();

            foreach (var item in dataType)
            {
                for (int i = 0; i < date.Length; i++)
                {
                    if (i != 0)
                    {
                        sql.Append("\r\n");
                    }
                    sql.Append($"");
                    if (i != _total - 1)
                    {
                        sql.Append(" UNION ALL");
                    }
                    //if (date.Count < _total)
                    //    date.Add($"{e.ToString(_format)}");
                }

            }


            var result = Get<DecimalData, decimal>(
                start,
                end,
                "SELECT AVG(ExplainSpan) as Value FROM SqlLog WHERE DbName = '{0}' AND EndTime > '{1}' AND EndTime < '{2}'");
            return Json(result);
        }

        private dynamic Get<T, T2>(DateTime start, DateTime end, string sqlStr) where T : BaseData<T2>
        {
            var particle = (end - start).TotalSeconds / _total; // 确定粒度
            var date = new List<string>
                       {
                           $"{start.ToString(_format)}"
                       };

            var dataType = TORM.Query<SqlLog>()
                               .Select(x => x.DbName)
                               .Group(x => x.DbName)
                               .Find<string>();
            var data = new ArrayList();

            foreach (var item in dataType)
            {
                var sql = new StringBuilder();
                for (var i = 0; i < _total; i++)
                {
                    var s = start.AddSeconds(particle * i);
                    var e = start.AddSeconds(particle * (i + 1));
                    if (i != 0)
                    {
                        sql.Append("\r\n");
                    }
                    sql.AppendFormat(sqlStr, item, $"{s:yyyy-MM-dd HH:mm:ss}", $"{e:yyyy-MM-dd HH:mm:ss}");
                    if (i != _total - 1)
                    {
                        sql.Append(" UNION ALL");
                    }
                    if (date.Count < _total)
                        date.Add($"{e.ToString(_format)}");
                }
                data.Add(new
                {
                    name = item,
                    type = "line",
                    smooth = true,
                    symbol = "none",
                    sampling = "average",
                    itemStyle = new
                    {
                        color = _color[dataType.IndexOf(item)]
                    },
                    data = TORM.Query<T>(sql.ToString()).Select(x => x.Value)
                });
            }

            var t = end.Ticks - start.Ticks;
            var t2 = DateTime.Now.Ticks - start.Ticks;
            //var t3 = t2 / (t / 100);
            var scope = new[] { 100 - 16, 100 };
            return new
            {
                dataType,
                data,
                date,
                scope,
                particle
            };
        }
    }
}
