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
    public class VotesController : BaseController
    {
        public HttpResponseMessage PostAddVote(int jewelId, [FromBody] Vote vote)
        {
            var responseMsg = PerformOperationAndHandleExceptions(() =>
            {
                using (var dbContext = new CodeJewelsContext())
                {
                    Jewel jewel = dbContext.Jewels.FirstOrDefault(j => j.Id == jewelId);

                    if (jewel == null)
                    {
                        throw new InvalidOperationException("The jewel does not exist!");
                    }

                    jewel.Votes.Add(vote);
                    dbContext.SaveChanges();

                    var response = this.Request.CreateResponse(HttpStatusCode.Created, vote);
                    return response;
                }
            });

            return responseMsg;
        }
    }
}