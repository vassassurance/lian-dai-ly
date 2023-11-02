﻿using LianAgentPortal.Models.DbModels;
using Microsoft.AspNetCore.Identity;
using System.Security.Cryptography;
using System.Text;

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
    }
}
