using AutoMapper;
using Hx.Abp.DataQualityInspection.Application.Contracts;
using Hx.Abp.DataQualityInspection.Domain;

namespace Hx.Abp.DataQualityInspection.Application
{
    public class DataQualityInspectionProfile : Profile
    {
        public DataQualityInspectionProfile()
        {
            CreateMap<Rule, RuleDto>(MemberList.Destination);
            CreateMap<RuleGroup, RuleGroupDto>(MemberList.Destination);
            CreateMap<RuleConstraints, RuleConstraintsDto>(MemberList.Destination);
        }
    }
}
