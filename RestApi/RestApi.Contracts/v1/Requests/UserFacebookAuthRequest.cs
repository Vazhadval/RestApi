﻿using System;
using System.Collections.Generic;
using System.Text;

namespace RestApi.Contracts.v1.Requests
{
    public class UserFacebookAuthRequest
    {
        public string AccessToken { get; set; }
    }
}
