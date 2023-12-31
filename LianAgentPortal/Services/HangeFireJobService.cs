﻿using DocumentFormat.OpenXml.Office2010.Excel;
using DocumentFormat.OpenXml.Spreadsheet;
using Hangfire;
using LianAgentPortal.Commons;
using LianAgentPortal.Commons.Constants;
using LianAgentPortal.Data;
using LianAgentPortal.Models.DbModels;
using LianAgentPortal.Models.ViewModels.BaseInsurance;
using LianAgentPortal.Models.ViewModels.LianAgent;
using Microsoft.AspNetCore.Server.Kestrel.Https;
using Microsoft.EntityFrameworkCore;
using System.Linq;

namespace LianAgentPortal.Services
{
    public interface IHangeFireJobService
    {
        void MakeJobGenCerTnsp(long masterId, List<long> ids);

        //
        void MakeJobCalculatePremiumAutomobileInsurances(long masterId, List<long> ids, string username);
        void MakeJobBuyAutomobileInsurances(long masterId, List<long> ids, string username);


        void MakeJobCalculatePremiumMotorInsurances(long masterId, List<long> ids, string username);
        void MakeJobBuyMotorInsurances(long masterId, List<long> ids, string username);
    }
    public class HangeFireJobService : IHangeFireJobService
    {
        private readonly IBackgroundJobClient _backgroundJobs;
        private readonly ILianApiService _lianApiService;
        private readonly ITnspService _tnspService;
        private readonly ApplicationDbContext _db;
        public HangeFireJobService(
            IBackgroundJobClient backgroundJobs, 
            ILianApiService lianApiService,
            ITnspService tnspService,
            ApplicationDbContext db) 
        {
            _backgroundJobs = backgroundJobs;
            _lianApiService = lianApiService;
            _tnspService = tnspService;
            _db = db;
        }

        public void GenCerTnsp(long masterId, List<long> ids)
        {
            var itemMaster = _db.InsuranceTnspMasters.FirstOrDefault(item => item.Id == masterId);
            for (int i = 0; i < ids.Count; i++)
            {
                try
                {
                    var itemToUpdate = _db.InsuranceTnspDetails.Include(item => item.InsuranceTnspMaster).FirstOrDefault(item =>
                        item.Id == ids[i]
                        && item.InsuranceTnspMasterId == masterId
                        && item.Status == InsuranceOtherStatusEnum.GENCER_INPROGRESS
                    );

                    if (itemToUpdate != null)
                    {
                        if (itemToUpdate.InsuranceTnspMaster.IsDeleted)
                        {
                            itemToUpdate.Status = InsuranceOtherStatusEnum.GENCER_ERROR;
                            itemToUpdate.StatusMessage = "Bảng kê bị xóa";
                            _db.SaveChanges();
                            continue;
                        }

                        itemToUpdate.InsuranceNo = (DateTime.Now.Year % 100)
                            + "-25-31-020502-" + Commons.Functions.GenNumberZero(7 - itemToUpdate.Id.ToString().Length) + itemToUpdate.Id.ToString();

                        itemToUpdate.CertificateDigitalLink = Functions.GetCertificatePath(
                            CertificateFolders.Folder020502Tnsp,
                            itemToUpdate.InsuranceTnspMasterId,
                            itemToUpdate.OrderId,
                            itemToUpdate.InsuranceNo
                        );

                        _tnspService.GenCertificate(itemToUpdate);

                        itemToUpdate.Status = InsuranceOtherStatusEnum.GENCER_SUCCESS;
                        itemToUpdate.StatusMessage = "Phát hành thành công";
                        itemMaster.TotalIssuedRows++;

                        _db.SaveChanges();
                    }
                }
                catch
                {

                }



            }

            itemMaster.TotalIssuedRows = _db.InsuranceTnspDetails.AsNoTracking()
                .Count(item =>
                    item.InsuranceTnspMasterId == masterId
                    && item.Status == InsuranceOtherStatusEnum.GENCER_SUCCESS
                );

            _db.SaveChanges();

        }

        public void MakeJobGenCerTnsp(long masterId, List<long> ids)
        {
            _backgroundJobs.Enqueue(() =>
                GenCerTnsp(masterId, ids)
            );
        }

        public void MakeJobCalculatePremiumAutomobileInsurances(long masterId, List<long> ids, string username)
        {
            var user = _db.Users.Include(item => item.LianAgent).FirstOrDefault(item => item.UserName == username);

            if (user != null && user.LianAgent != null)
            {
                LianAgentApiKey apiKey = new LianAgentApiKey()
                {
                    AppId = user.LianAgent.AppId,
                    SecretKey = user.LianAgent.SecretKey,
                };

                _backgroundJobs.Enqueue(() =>
                    CalculatePremiumAutomobileInsurances(masterId, ids, apiKey)
                );
            }
        }

        public void MakeJobBuyAutomobileInsurances(long masterId, List<long> ids, string username)
        {
            var user = _db.Users.Include(item => item.LianAgent).FirstOrDefault(item => item.UserName == username);

            if (user != null && user.LianAgent != null)
            {
                LianAgentApiKey apiKey = new LianAgentApiKey()
                {
                    AppId = user.LianAgent.AppId,
                    SecretKey = user.LianAgent.SecretKey,
                };

                _backgroundJobs.Enqueue(() =>
                    BuyInsuranceAutomobile(masterId, ids, apiKey)
                );
            }
        }

        public void MakeJobCalculatePremiumMotorInsurances(long masterId, List<long> ids, string username)
        {
            var user = _db.Users.Include(item => item.LianAgent).FirstOrDefault(item => item.UserName == username);

            if (user != null && user.LianAgent != null)
            {
                LianAgentApiKey apiKey = new LianAgentApiKey()
                {
                    AppId = user.LianAgent.AppId,
                    SecretKey = user.LianAgent.SecretKey,
                };

                _backgroundJobs.Enqueue(() =>
                    CalculatePremiumMotorInsurances(masterId, ids, apiKey)
                );
            }
        }

        public void MakeJobBuyMotorInsurances(long masterId, List<long> ids, string username)
        {
            var user = _db.Users.Include(item => item.LianAgent).FirstOrDefault(item => item.UserName == username);

            if (user != null && user.LianAgent != null)
            {
                LianAgentApiKey apiKey = new LianAgentApiKey()
                {
                    AppId = user.LianAgent.AppId,
                    SecretKey = user.LianAgent.SecretKey,
                };

                _backgroundJobs.Enqueue(() =>
                    BuyMotorInsurances(masterId, ids, apiKey)
                );
            }
        }
        
        public void BuyInsuranceAutomobile(long masterId, List<long> ids, LianAgentApiKey apiKey)
        {
            for (int i = 0; i < ids.Count; i++)
            {
                var itemToUpdate = _db.InsuranceAutomobileDetails.Include(item => item.InsuranceMaster).FirstOrDefault(item =>
                    item.Id == ids[i]
                    && item.InsuranceMasterId == masterId
                    && item.Status == InsuranceDetailStatusEnum.SYNC_INPROGRESS
                );

                if (itemToUpdate != null)
                {
                    if (itemToUpdate.InsuranceMaster.IsDeleted)
                    {
                        itemToUpdate.Status = InsuranceDetailStatusEnum.SYNC_ERROR;
                        itemToUpdate.StatusMessage = "Bảng kê bị xóa";
                    }

                    itemToUpdate.PartnerTransaction = Guid.NewGuid().ToString().Replace("-", "");
                    BuyInsuranceApiResponse result = _lianApiService.BuyInsuranceAutomobile(itemToUpdate, apiKey);
                    if (result.Code == (long)BuyInsuranceResultEnum.SUCCESS)
                    {
                        itemToUpdate.Status = InsuranceDetailStatusEnum.SYNC_SUCCESS;
                        itemToUpdate.StatusMessage = result.Message;
                        itemToUpdate.CertificateDigitalLink = (result.Data.CertificateDigitalLink != null && result.Data.CertificateDigitalLink.Count >= 1) ? result.Data.CertificateDigitalLink[0] : "";
                        itemToUpdate.Transaction = result.Data.Transaction;
                        itemToUpdate.InsuranceCode = result.Data.InsuranceCode;
                        itemToUpdate.InsuranceMaster.TotalIssuedRows += 1;
                    }
                    else
                    {
                        itemToUpdate.Status = InsuranceDetailStatusEnum.SYNC_ERROR;
                        itemToUpdate.StatusMessage = result.Message;
                    }
                    _db.SaveChanges();
                }
            }

            var itemMaster = _db.InsuranceMasters.FirstOrDefault(item => item.Id == masterId);
            itemMaster.TotalIssuedRows = _db.InsuranceAutomobileDetails.AsNoTracking().Count(item => item.InsuranceMasterId == masterId && item.Status == InsuranceDetailStatusEnum.SYNC_SUCCESS);
            _db.SaveChanges();
        }

        public void BuyMotorInsurances(long masterId, List<long> ids, LianAgentApiKey apiKey)
        {
            for (int i = 0; i < ids.Count; i++)
            {
                var itemToUpdate = _db.InsuranceMotorDetails.Include(item => item.InsuranceMaster).FirstOrDefault(item => 
                    item.Id == ids[i] 
                    && item.InsuranceMasterId == masterId
                    && item.Status == InsuranceDetailStatusEnum.SYNC_INPROGRESS
                );
                if (itemToUpdate != null)
                {
                    if (itemToUpdate.InsuranceMaster.IsDeleted)
                    {
                        itemToUpdate.Status = InsuranceDetailStatusEnum.SYNC_ERROR;
                        itemToUpdate.StatusMessage = "Bảng kê bị xóa";
                    }

                    itemToUpdate.PartnerTransaction = Guid.NewGuid().ToString().Replace("-", "");
                    BuyInsuranceApiResponse result = _lianApiService.BuyInsuranceMotor(itemToUpdate, apiKey);
                    if (result.Code == (long)BuyInsuranceResultEnum.SUCCESS)
                    {
                        itemToUpdate.Status = InsuranceDetailStatusEnum.SYNC_SUCCESS;
                        itemToUpdate.StatusMessage = result.Message;
                        itemToUpdate.CertificateDigitalLink = (result.Data.CertificateDigitalLink!= null && result.Data.CertificateDigitalLink.Count >= 1) ? result.Data.CertificateDigitalLink[0] : "";
                        itemToUpdate.Transaction = result.Data.Transaction;
                        itemToUpdate.InsuranceCode = result.Data.InsuranceCode;
                        itemToUpdate.InsuranceMaster.TotalIssuedRows += 1;
                    }
                    else
                    {
                        itemToUpdate.Status = InsuranceDetailStatusEnum.SYNC_ERROR;
                        itemToUpdate.StatusMessage = result.Message;
                    }
                    _db.SaveChanges();
                }
            }

            var itemMaster = _db.InsuranceMasters.FirstOrDefault(item => item.Id == masterId);
            itemMaster.TotalIssuedRows = _db.InsuranceMotorDetails.AsNoTracking().Count(item => item.InsuranceMasterId == masterId && item.Status == InsuranceDetailStatusEnum.SYNC_SUCCESS);
            _db.SaveChanges();
        }

        public void CalculatePremiumAutomobileInsurances(long masterId, List<long> ids, LianAgentApiKey apiKey)
        {
            var itemMaster = _db.InsuranceMasters.FirstOrDefault(item => item.Id == masterId);
            for (int i = 0; i < ids.Count; i++)
            {
                var itemToUpdate = _db.InsuranceAutomobileDetails.Include(item => item.InsuranceMaster).FirstOrDefault(item =>
                    item.Id == ids[i]
                    && item.InsuranceMasterId == masterId
                    && item.Status == InsuranceDetailStatusEnum.CALCULATE_PREMIUM_INPROGRESS
                );

                if (itemToUpdate != null)
                {
                    if (itemToUpdate.InsuranceMaster.IsDeleted)
                    {
                        itemToUpdate.Status = InsuranceDetailStatusEnum.CALCULATE_PREMIUM_ERROR;
                        itemToUpdate.StatusMessage = "Bảng kê bị xóa";
                        _db.SaveChanges();
                        continue;
                    }

                    CalculateInsurancePremiumResponse result = _lianApiService.CalculatePremiumInsuranceAutomobileDetail(itemToUpdate, apiKey);
                    if (result.Code == (long)CalculateInsurancePremiumResultEnum.SUCCESS)
                    {
                        itemToUpdate.Status = InsuranceDetailStatusEnum.CALCULATE_PREMIUM_SUCCESS;
                        itemToUpdate.Amount = result.Data.TotalAmount;
                        itemToUpdate.LiabilityInsuranceFee = (long)result.Data.TotalAmount - (itemToUpdate.PassengerCount * itemToUpdate.PassengerFee);
                        itemToUpdate.StatusMessage = result.Message;
                        itemMaster.TotalPremium += result.Data.TotalAmount;

                    }
                    if (result.Code == (long)CalculateInsurancePremiumResultEnum.ERROR)
                    {
                        itemToUpdate.Status = InsuranceDetailStatusEnum.CALCULATE_PREMIUM_ERROR;
                        itemToUpdate.StatusMessage = result.Message;
                        itemToUpdate.Amount = null;
                    }
                    _db.SaveChanges();
                }
            }

            itemMaster.TotalPremium = _db.InsuranceAutomobileDetails.AsNoTracking()
                .Where(item => item.InsuranceMasterId == masterId && item.Amount.HasValue)
                .Sum(item => item.Amount ?? 0);

            _db.SaveChanges();

        }

        public void CalculatePremiumMotorInsurances(long masterId, List<long> ids, LianAgentApiKey apiKey)
        {
            var itemMaster = _db.InsuranceMasters.FirstOrDefault(item => item.Id == masterId);
            for (int i = 0; i < ids.Count; i++)
            {
                var itemToUpdate = _db.InsuranceMotorDetails.Include(item => item.InsuranceMaster).FirstOrDefault(item =>
                    item.Id == ids[i]
                    && item.InsuranceMasterId == masterId
                    && item.Status == InsuranceDetailStatusEnum.CALCULATE_PREMIUM_INPROGRESS
                );
                
                if (itemToUpdate != null)
                {
                    if (itemToUpdate.InsuranceMaster.IsDeleted)
                    {
                        itemToUpdate.Status = InsuranceDetailStatusEnum.CALCULATE_PREMIUM_ERROR;
                        itemToUpdate.StatusMessage = "Bảng kê bị xóa";
                        _db.SaveChanges();
                        continue;
                    }

                    CalculateInsurancePremiumResponse result = _lianApiService.CalculatePremiumInsuranceMotorDetail(itemToUpdate, apiKey);
                    if (result.Code == (long)CalculateInsurancePremiumResultEnum.SUCCESS)
                    {
                        itemToUpdate.Status = InsuranceDetailStatusEnum.CALCULATE_PREMIUM_SUCCESS;
                        itemToUpdate.Amount = result.Data.TotalAmount;
                        itemToUpdate.StatusMessage = result.Message;
                        itemMaster.TotalPremium += result.Data.TotalAmount;
                    }
                    if (result.Code == (long)CalculateInsurancePremiumResultEnum.ERROR)
                    {
                        itemToUpdate.Status = InsuranceDetailStatusEnum.CALCULATE_PREMIUM_ERROR;
                        itemToUpdate.StatusMessage = result.Message;
                        itemToUpdate.Amount = null;
                    }
                    _db.SaveChanges();
                }   
            }

            itemMaster.TotalPremium = _db.InsuranceMotorDetails.AsNoTracking()
                .Where(item => item.InsuranceMasterId == masterId && item.Amount.HasValue)
                .Sum(item => item.Amount ?? 0);

            _db.SaveChanges();

        }
    }
}
