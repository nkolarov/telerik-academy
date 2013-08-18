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
    using CodeJewels.Services.Models;
    using System.Collections.Generic;

    /// <summary>
    /// Represents a votes controller.
    /// </summary>
    public class CodeJewelsController : BaseController
    {
        public HttpResponseMessage PostCodeJewel([FromBody] JewelModel jewel)
        {
            var responseMsg = PerformOperationAndHandleExceptions(() =>
            {
                using (var dbContext = new CodeJewelsContext())
                {
                    if (jewel == null)
                    {
                        throw new InvalidOperationException("The jewel must not be null!");
                    }

                    Jewel jewelEntity = new Jewel() { Id = jewel.Id, AuthorMail = jewel.AuthorMail, SourceCode = jewel.SourceCode };

                    dbContext.Jewels.Add(jewelEntity);
                    dbContext.SaveChanges();

                    var response = this.Request.CreateResponse(HttpStatusCode.Created, jewel);

                    return response;
                }
            });

            return responseMsg;
        }

        public IQueryable<JewelModel> GetCodeJewels(string category, string source)
        {
            var responseMsg = PerformOperationAndHandleExceptions(() =>
            {
                var dbContext = new CodeJewelsContext();
                    var jewels = dbContext.Jewels.Include("Category").Include("Votes").Where(j => j.SourceCode.Contains(source) && j.Category.Name == category);
                    return
                        from jewel in jewels
                        select new JewelModel()
                        {
                            Id = jewel.Id,
                            AuthorMail = jewel.AuthorMail,
                            SourceCode = jewel.SourceCode
                        };               
            });

            return responseMsg;
        }
    }
}