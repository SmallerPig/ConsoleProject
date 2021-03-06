﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace ConsoleProject.Extensions
{
    public static class HttpContextExtensions
    {
        public static string keyOfErrorMessage = Guid.NewGuid().ToString();

        public static void SetErrorMessage(this HttpContext context, string errorMessage)
        {
            context.Items[keyOfErrorMessage] = errorMessage;
        }

        public static string GetErrorMessage(this HttpContext context)
        {
            return context.Items[keyOfErrorMessage] as string;
        }

        public static void ClearErrorMessage(this HttpContext context)
        {
            if (context.Items.Contains(keyOfErrorMessage))
            {
                context.Items.Remove(keyOfErrorMessage);
            }
        }
    }
}