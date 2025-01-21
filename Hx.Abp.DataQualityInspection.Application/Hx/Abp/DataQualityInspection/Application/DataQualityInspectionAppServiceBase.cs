using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Volo.Abp.Application.Services;

namespace Hx.Abp.DataQualityInspection.Application
{
    public class DataQualityInspectionAppServiceBase : ApplicationService
    {
        public DataQualityInspectionAppServiceBase()
        {
            ObjectMapperContext = typeof(HxAbpDataQualityInspectionApplicationModule);
        }
    }
}
