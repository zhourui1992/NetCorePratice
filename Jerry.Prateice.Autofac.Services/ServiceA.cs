using Jerry.Prateice.Autofac.IServices;
using Jerry.Prateice.EF.DataBase;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Jerry.Prateice.Autofac.Services
{
    public class ServiceA : IServiceA
    {
        private ILogger<ServiceA> _logger;
        private LocalDbContext _db;
        private IServiceB _serviceB;
        public ServiceA(ILogger<ServiceA> logger, LocalDbContext db, IServiceB serviceB)
        {
            _logger = logger;
            _db = db;
            _serviceB = serviceB;
        }

        public void DoAddStudent()
        {
            Task.Run(async () =>
            {
                while (true)
                {
                    try
                    {
                        _logger.LogInformation("这是日志");
                        var guid = Guid.NewGuid();
                        _db.T_Student.Add(new EF.DataBase.Entities.T_Student()
                        {
                            Address = $"这是地址_{guid}",
                            ClassId = 1,
                            Name = $"这是学生i{guid}",
                            Sex = 1
                        });
                        await _db.SaveChangesAsync();
                        _serviceB.DoSomething();
                        await Task.Delay(5000);
                    }
                    catch (Exception ex)
                    {
                        _logger.LogError(ex, "发生错误了");
                    }
                }
            });


        }
    }
}
