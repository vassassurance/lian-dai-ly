using LianAgentPortal.Commons.Constants;
using LianAgentPortal.Models.DbModels;
using LianAgentPortal.Models.ViewModels.BaseInsurance;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Server.Kestrel.Https;
using Newtonsoft.Json;
using System.Security.Cryptography;
using System.Text;
using System.Text.RegularExpressions;

namespace LianAgentPortal.Commons
{
    public class Functions
    {
		public static string MD5Hash(string input)
		{
			using (var md5 = MD5.Create())
			{
				byte[] hashBytes = md5.ComputeHash(Encoding.UTF8.GetBytes(input));
				return BitConverter.ToString(hashBytes).Replace("-", "").ToLower();
			}
		}

		public static string RandomString(int length)
        {
            Random random = new Random();
            const string chars = "ABCDEFGHIJKLMNOPQRSTUVWXYZ";
            return new string(Enumerable.Repeat(chars, length)
                .Select(s => s[random.Next(s.Length)]).ToArray())
                .ToLower();
        }

        public static string RandomNumberString(int length)
        {
            Random random = new Random();
            const string chars = "0123456789";
            return new string(Enumerable.Repeat(chars, length)
                .Select(s => s[random.Next(s.Length)]).ToArray())
                .ToLower();
        }

        public static string HashPassword(LianUser user, string password)
        {
            var passHash = new PasswordHasher<LianUser>();
            return passHash.HashPassword(user, password);
        }

        public static DateTime UnixDatetimeToDatetime(long unixTimeStamp)
        {
            DateTime dateTime = new DateTime(1970, 1, 1, 0, 0, 0, 0, DateTimeKind.Utc);
            dateTime = dateTime.AddSeconds(unixTimeStamp).ToLocalTime();
            return dateTime;
        }


        public static DateTime MapEndDate(DateTime effectiveDate, string TimeCoverageJsonString)
        {
            TimeCoverageObject timeCoverage = JsonConvert.DeserializeObject<TimeCoverageObject>(TimeCoverageJsonString);

            if (timeCoverage == null) return effectiveDate;

            if (timeCoverage.Unit == TimeCoverageUnitEnum.YEAR)
            {
                return effectiveDate.AddYears(timeCoverage.Value);
            }
            if (timeCoverage.Unit == TimeCoverageUnitEnum.MONTH)
            {
                return effectiveDate.AddMonths(timeCoverage.Value);
            }
            if (timeCoverage.Unit == TimeCoverageUnitEnum.DAY)
            {
                return effectiveDate.AddDays(timeCoverage.Value);
            }

            return effectiveDate;
        }

        public static string MapInsuranceDetailStatus(InsuranceDetailStatusEnum status)
        {
            if (status == InsuranceDetailStatusEnum.NEW) return "<i class=\"fa fa-file-o\" aria-hidden=\"true\" title=\"TẠO MỚI\"></i>";

            if (status == InsuranceDetailStatusEnum.CALCULATE_PREMIUM_SUCCESS) return "<i class=\"fa fa-check-square text-success\" aria-hidden=\"true\" title=\"TÍNH PHÍ - THÀNH CÔNG\"></i>";
            if (status == InsuranceDetailStatusEnum.CALCULATE_PREMIUM_ERROR) return "<i class=\"fa fa-exclamation-triangle text-danger\" aria-hidden=\"true\" title=\"TÍNH PHÍ - LỖI\"></i>";
            if (status == InsuranceDetailStatusEnum.CALCULATE_PREMIUM_INPROGRESS) return "<i class=\"fa fa-spinner text-primary\" aria-hidden=\"true\" title=\"ĐANG TÍNH PHÍ\"></i>";

            if (status == InsuranceDetailStatusEnum.SYNC_SUCCESS) return "<i class=\"fa fa-paper-plane text-success\" aria-hidden=\"true\" title=\"PHÁT HÀNH - THÀNH CÔNG\" ></i>";
            if (status == InsuranceDetailStatusEnum.SYNC_INPROGRESS) return "<i class=\"fa fa-spinner text-primary\" aria-hidden=\"true\" title=\"ĐANG PHÁT HÀNH\"></i>";
            if (status == InsuranceDetailStatusEnum.SYNC_ERROR) return "<i class=\"fa fa-exclamation-triangle text-danger\" aria-hidden=\"true\" title=\"PHÁT HÀNH - LỖI\"></i>";

            return "";
        }

        public static string MapInsuranceOtherDetailStatus(InsuranceOtherStatusEnum status)
        {
            if (status == InsuranceOtherStatusEnum.NEW) return "<i class=\"fa fa-file-o\" aria-hidden=\"true\" title=\"TẠO MỚI\"></i>";

            if (status == InsuranceOtherStatusEnum.GENCER_SUCCESS) return "<i class=\"fa fa-paper-plane text-success\" aria-hidden=\"true\" title=\"PHÁT HÀNH - THÀNH CÔNG\" ></i>";
            if (status == InsuranceOtherStatusEnum.GENCER_INPROGRESS) return "<i class=\"fa fa-spinner text-primary\" aria-hidden=\"true\" title=\"ĐANG PHÁT HÀNH\"></i>";
            if (status == InsuranceOtherStatusEnum.GENCER_ERROR) return "<i class=\"fa fa-exclamation-triangle text-danger\" aria-hidden=\"true\" title=\"PHÁT HÀNH - LỖI\"></i>";

            return "";
        }

        public static string ConvertInsuranceTypeEnumToString(InsuranceTypeEnum type)
        {
            if (type == InsuranceTypeEnum.FAMILY_BREADWINNER) return "<i class=\"fa fa-home\" aria-hidden=\"true\"></i> TRỤ CỘT GIA ĐÌNH";
            if (type == InsuranceTypeEnum.PERSONAL_ACCIDENT) return "<i class=\"fa fa-universal-access\" aria-hidden=\"true\"></i> TAI NẠN CÁ NHÂN";
            if (type == InsuranceTypeEnum.MOTORBIKE) return "<i class=\"fa fa-motorcycle\" aria-hidden=\"true\"></i> TNDS BB XE MÁY";
            if (type == InsuranceTypeEnum.AUTOMOBILES) return "<i class=\"fa fa-car\" aria-hidden=\"true\"></i> TNDS BB OTO";
            if (type == InsuranceTypeEnum.BREAST_CANCER) return "<i class=\"fa fa-female\" aria-hidden=\"true\"></i> UTV";
            if (type == InsuranceTypeEnum.HOUSE) return "<i class=\"fa fa-building\" aria-hidden=\"true\"></i> CHÁY NỔ NHÀ CHUNG CƯ";
            //

            return "";
        }

        public static string GetCellValue(string cachedValue)
        {
            if (cachedValue == null || cachedValue.Length == 0)
            {
                return "0";
            }
            return cachedValue;
        }

        public static string GetCertificatePath(string folder, long masterId, string filename, string insuranceNo)
        {
            return folder + masterId.ToString() + "/" + MakeValidFileName(filename) + "_" + insuranceNo + ".pdf";
        }

        private static string MakeValidFileName(string name)
        {
            string invalidChars = System.Text.RegularExpressions.Regex.Escape(new string(System.IO.Path.GetInvalidFileNameChars()));
            string invalidRegStr = string.Format(@"([{0}]*\.+$)|([{0}]+)", invalidChars);
            return System.Text.RegularExpressions.Regex.Replace(name, invalidRegStr, "-");
        }

        public static string GenNumberZero(int number)
        {
            if (number <= 0) return "";
            string result = "";
            for (int i=1; i<=number; i++)
            {
                result += "0";
            }
            return result;
        }
    }
}
