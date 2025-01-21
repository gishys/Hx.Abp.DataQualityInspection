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
            CreateMap<RuleGroup, RuleGroupDto>(MemberList.Destination)
                .ForMember(dest => dest.Children, opt =>
                {
                    opt.PreCondition(src => src.Children != null && src.Children.Count > 0);
                    opt.MapFrom(src => src.Children);
                })
                .ForMember(dest => dest.Rules, opt =>
                {
                    opt.PreCondition(src => src.Rules != null && src.Rules.Count > 0);
                    opt.MapFrom(src => src.Rules);
                });
            CreateMap<RuleConstraints, RuleConstraintsDto>(MemberList.Destination);
        }
    }
}
