﻿using System;
using System.Data.Entity;
using System.Data.Entity.Infrastructure;
using System.Collections.Generic;

namespace WebUI.Services.Authentication.Data.Mocks
{
    public static class AuthenticationEntitiesMock
    {
        public static List<Account> Accounts { get; set; }

        static AuthenticationEntitiesMock()
        {
            Accounts = new List<Account>();
            Accounts.Add(new Account
            {
                AccountGuid = Guid.NewGuid(),
                AccountId = 0,
                Forename = "Dave",
                Surname = "Ward",
                Login = "dave@ward.ie",
                Password = "password"
            });
        }
    }
}