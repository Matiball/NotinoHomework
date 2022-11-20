using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using NotinoHomework.Models;
using System.Diagnostics;

namespace NotinoHomework.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class DocumentOperationsController : ControllerBase
    {


        [HttpPost]
        [Route("SaveDocumentAsJSON")]
        public string SaveDocumentAsJSON(Document document) 
        {
            var serializedDoc = JsonConvert.SerializeObject(document);

            string folderLocation = Environment.CurrentDirectory + "\\Converted\\";
            string uploadedFileName = document.Title+"_"+DateTime.Today.ToString("dd_MM_yyyy")+".json";

            string finalPath = folderLocation + uploadedFileName;
            //save document to Disk
            try
            {
                System.IO.File.Create(finalPath).Close();
                

                var targetStream = System.IO.File.Open(finalPath, FileMode.Create, FileAccess.Write);
                var sw = new StreamWriter(targetStream);
                sw.Write(serializedDoc);
                sw.Close();

                return finalPath;
            }
            catch(Exception e)
            {
                return e.ToString();
            }
        }
        
    }
}
