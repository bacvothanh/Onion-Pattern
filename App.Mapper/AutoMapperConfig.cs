using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace App.Mapper
{
    public class AutoMapperConfig
    {
        public static void Run()
        {
            AutoMapper.Mapper.Initialize(cfg =>
            {
            });
        }
    }
}
