// ****************************************************************
// <copyright file="Jewel.cs" company="Telerik Academy">
// Copyright (c) 2013 Telerik Academy. All rights reserved.
// </copyright>
// ****************************************************************

namespace CodeJewels.Services.Controllers
{
    using System;
    using System.Linq;
    using System.Net.Http;
    using System.Web.Http;
    using CodeJewels.Data;
    using CodeJewels.Models;
    using System.Net;

    /// <summary>
    /// Represents a votes controller.
    /// </summary>
    public class CategoriesController : BaseController
    {
        public HttpResponseMessage PostAddCategory([FromBody] Category category)
        {
            var responseMsg = PerformOperationAndHandleExceptions(() =>
            {
                using (var dbContext = new CodeJewelsContext())
                {
                    if (category == null)
                    {
                        throw new InvalidOperationException("The category must not be null!");
                    }

                    dbContext.Categories.Add(category);
                    dbContext.SaveChanges();

                    var response = this.Request.CreateResponse(HttpStatusCode.Created, category);

                    return response;
                }
            });

            return responseMsg;
        }
    }
}