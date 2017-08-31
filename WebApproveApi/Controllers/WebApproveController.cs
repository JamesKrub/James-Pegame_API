using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using WebApproveApi.Models.WebApvModel;

namespace WebApproveApi.Controllers
{
    public class WebApproveController : ApiController
    {
        // Register region
        #region Register
        [HttpGet]
        [Route("webApprove/docDetailById/{id?}")]
        public string GetDocById(string id)
        {
            WebApvService service = new WebApvService();
            //return service.getDocDetailByID(id);
            List<Register> data = service.getDocDetailByID(id);
    
            return "a";
        }

        [HttpPost]
        [Route("webApprove/register")]
        public void Post([FromBody]RegisData value)
        {
            //WebApvService service = new WebApvService();
            //service.registerDocument(value);
        }

        #endregion

        // DocumentDetail region
        #region DocumentDetail
        [HttpGet]
        [Route("webApprove/getNumOfUnApprove")]
        public int GetNumOfUnapprove()
        {
            WebApvService service = new WebApvService();
            return service.checkNumberOfUnApprove();
        }

        [HttpGet]
        [Route("webApprove/getAllDocDetail")]
        public List<sp_DocDetailSelect_Result> getAllDocDetail()
        {
            WebApvService service = new WebApvService();
            return service.getAllDocDetail();
        }
        #endregion


        // PUT: api/WebApprove/5
        public void Put(int id, [FromBody]string value)
        {
        }

        // DELETE: api/WebApprove/5
        public void Delete(int id)
        {
        }
    }
}
