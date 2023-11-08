﻿using AutoMapper;
using LianAgentPortal.Commons.Constants;
using LianAgentPortal.Models.DbModels;
using LianAgentPortal.Models.ViewModels.BaseInsurance;
using LianAgentPortal.Models.ViewModels.InsuranceAutomobileDetail;
using LianAgentPortal.Models.ViewModels.InsuranceMotorDetail;
using Microsoft.AspNetCore.Mvc.ViewFeatures;
using Newtonsoft.Json;

namespace LianAgentPortal.Models.Mappers
{
    public class InsuranceAutomobileDetailProfile : Profile
    {
        public InsuranceAutomobileDetailProfile()
        {
            CreateMap<InsuranceAutomobileDetail, InsuranceAutomobileDetailViewModel>()
                .ForMember(dest => dest.FullTypeName, opt => opt.MapFrom(src => MapFullTypeName(src)))
                .ForMember(dest => dest.EndDate, opt => opt.MapFrom(src => Commons.Functions.MapEndDate(src.EffectiveDate, src.TimeCoverage)))
                .ForMember(dest => dest.Status, opt => opt.MapFrom(src => Commons.Functions.MapInsuranceDetailStatus(src.Status)))
            ;

            CreateMap<InsuranceAutomobileDetail, CalculateInsurancePremiumDetailAutomobile>()
                .ForMember(dest => dest.Attributes, opt => opt.MapFrom(src => MapAutomobileAttributes(src)))
                ;

            CreateMap<InsuranceAutomobileDetail, CalculateInsurancePremium<CalculateInsurancePremiumDetailAutomobile>>()
                .ForMember(dest => dest.Insurance, opt => opt.MapFrom(src => src))
                .ForMember(dest => dest.TimeCoverage, opt => opt.MapFrom(src => JsonConvert.DeserializeObject<TimeCoverageObjectString>(src.TimeCoverage)))
            ;

            CreateMap<InsuranceAutomobileDetail, BuyInsuranceAutomobileInsuranceDataViewModel>()
                .ForMember(dest => dest.Attributes, opt => opt.MapFrom(src => new AutomobileAttributesString() { Seat = src.Attributes_Seat, Category = src.Attributes_Category.ToString() }))
            ;

            CreateMap<InsuranceAutomobileDetail, BuyInsuranceAutomobileViewModel>()
                 .ForMember(dest => dest.Insurance, opt => opt.MapFrom(src => src))
                 .ForMember(dest => dest.TimeCoverage, opt => opt.MapFrom(src => JsonConvert.DeserializeObject<TimeCoverageObjectString>(src.TimeCoverage)))
            ;

        }

        private AutomobileAttributesString MapAutomobileAttributes(InsuranceAutomobileDetail source)
        {
            return new AutomobileAttributesString() { 
                Category = source.Attributes_Category.ToString(),
                Seat = source.Attributes_Seat,
            };
        }

        private string GetAutomobilesTypeName(AutomobileTypeEnum automobilesType)
        {
            var type = AutomobileTypeConstants.Data.FirstOrDefault(item => item.TypeEnum == automobilesType);
            if (type != null)
            {
                return type.TypeName;
            }
            return "";
        }

        private string GetAttributesCategoryName (AutomobileTypeCategoryEnum automobileTypeCategory)
        {
            var type = AutomobileTypeCategoryConstants.Data.FirstOrDefault(item => item.TypeEnum == automobileTypeCategory);
            if (type != null)
            {
                return type.TypeName;
            }
            return "";
        }

        private string MapFullTypeName(InsuranceAutomobileDetail source)
        {
            return GetAutomobilesTypeName(source.AutomobilesType) + " - " + source.Attributes_Seat + " chổ - " + GetAttributesCategoryName(source.Attributes_Category);
        }

    }
}