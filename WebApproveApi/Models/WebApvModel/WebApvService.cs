using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace WebApproveApi.Models.WebApvModel
{
    public class WebApvService
    {
        // สร้างการเชื่อมจ่อกับ Database
        #region Conenction
        private WebApproveEntities _conn;
        public WebApproveEntities conn
        {
            get
            {
                if (_conn == null)
                {
                    _conn = new WebApproveEntities();
                }
                return _conn;
            }
            set
            {
                _conn = value;
            }
        }
        #endregion

        // ตรวจสอบว่ามี Namespace อยู่หรือไม่
        #region validateRegister
        public Register validateRegister(string targetNamespace)
        {
            try
            {
                //var qry = from reg in conn.Registers where reg.targetNameSpace == targetNamespace select reg;
                return conn.Registers.Where(a => a.targetNameSpace == targetNamespace).FirstOrDefault();
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        #endregion

        // เพิ่มข้อมูลการ Register ลง Database
        #region Add Register Document
        public sp_RegisterInsert_Result registerDocument(RegisData data)
        {
            try
            {
                var a = conn.sp_RegisterInsert(
                    data.schemaName,
                    data.Schema,
                    data.targetNamespace,
                    data.Transform
                );
                return a.FirstOrDefault();
            }
            catch (Exception ex)
            {
                //return "fail";
                throw ex;
            }
        }
        #endregion

        // เพิ่มการ Request Data
        #region Add Request Document
        public void insertDocumentDetail(RequestData data)
        {
            try
            {
                data.dateRequest = DateTime.Now;
                data.statusId = "4";
                conn.sp_DocDetailInsert(
                    data.subjectName,
                    data.dataRequest,
                    data.dateRequest,
                    data.empId,
                    data.statusId
                    );
            }
            catch (Exception ex)
            {
                throw ex;

            }
        }
        #endregion

        // เพิ่ม permission
        #region AddPermission
        public void insertPermission(Int32 regId, string empId)
        {
            try
            {
                conn.sp_EmpPermissionInsert(
                    regId,
                    empId
                    );
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        #endregion

        // แสดงจำนวนเอกสารที่ยังไม่ได้ Approve (ยังไมได้แก้ให้แสดงตาม ID)
        #region checkNumberOfUnApprove
        public int checkNumberOfUnApprove()
        {
            int num = (int)conn.sp_CheckUnApprove().FirstOrDefault();
            return num;
        }
        #endregion

        // แสดงจำนวนเอกสารทั้วหมด (ยังไมได้แก้ให้แสดงตาม ID)
        #region getAllDocDetail
        public List<sp_DocDetailSelect_Result> getAllDocDetail()
        {
            return conn.sp_DocDetailSelect().ToList();
        }
        #endregion

        // แสดงข้อมูลเอกสารตามผู้ใช้งาน
        #region getDocDetailByID
        public List<Register> getDocDetailByID(string id)
        {
            var qry = from data in conn.Registers
                      select data;
            return qry.ToList();
        }
        
        #endregion
    }

    // คลาสของการ Register
    #region RegisData
    public class RegisData
    {
        public string schemaName { get; set; }
        public string Schema { get; set; }
        public string targetNamespace { get; set; }
        public string Transform { get; set; }
        public string groupPermission { get; set; }
    }
    #endregion

    // คลาสของการ Request
    #region RequestData
    public class RequestData
    {
        public string subjectName { get; set; }
        public string dataRequest { get; set; }
        public DateTime dateRequest { get; set; }
        public string empId { get; set; }
        public string statusId { get; set; }
    }
    #endregion
}