using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using OCEntity.OnBoard;

namespace FirstVsSingle
{
    class Program
    {
        static void Main(string[] args)
        {
            using (var ctxOB = new OnboardEntities())
            {
                var comps = ctxOB.companies.Select(x => new
                {
                    x.Name,
                    x.Role,
                    x.Address1,
                }).ToList();
                var s = new Stopwatch();
                s.Start();
                foreach(var item in comps)
                {
                    var comp = ctxOB.companies.Single(x => x.Name.Equals(item.Name) && x.Role.Equals(item.Role) && x.Address1.Equals(item.Address1));
                }
                s.Stop();
                Console.WriteLine("Single " + s.ElapsedMilliseconds);
                s.Reset();
                s.Start();
                foreach (var item in comps)
                {
                    var comp = ctxOB.companies.First(x => x.Name.Equals(item.Name) && x.Role.Equals(item.Role) && x.Address1.Equals(item.Address1));
                }
                s.Stop();
                Console.WriteLine("First  " + s.ElapsedMilliseconds);
                Console.ReadKey();
            }
        }
    }
}
