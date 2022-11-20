using Microsoft.AspNetCore.Mvc;
using NotinoHomework.Utils;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace NotinoHomework.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ConverterController : ControllerBase
    {
        [HttpPost]
        [Route("ConvertJsonToXml")]
        public async Task<string> ConvertJsonToXml(IFormFile file)
        {
            string folderLocation = Environment.CurrentDirectory + "\\FilesUploaded\\";
            string fileName = file.FileName;
            string fileNameWithoutExtension = Path.GetFileNameWithoutExtension(fileName);

            //if receiving correct type
            if (file.ContentType == "application/json")
            {
                string fullName = folderLocation + fileName;

                //Save uploaded the file to disk
                using (var stream = System.IO.File.Create(fullName))
                {
                    file.CopyTo(stream);
                    stream.Close();                    
                }

                // use convert util to for conversion
                string convertedFile = FileXmlJsonConvertor.ConvertFileAndSave(FileXmlJsonConvertor.TypeOfConversion.jsonToXml,
                    fullName, fileNameWithoutExtension);                

                return convertedFile;
            }

            return "Wrong format of file !";
        }

        [HttpPost]
        [Route("ConvertXmlToJson")]
        public async Task<string> ConvertXmlToJson(IFormFile file)
        {
            string folderLocation = Environment.CurrentDirectory + "\\FilesUploaded\\";
            string fileName = file.FileName;
            string fileNameWithoutExtension = Path.GetFileNameWithoutExtension(fileName);

            //if receiving correct type
            if (file.ContentType == "text/xml")
            {
                string fullName = folderLocation + fileName;

                //Save uploaded the file to disk
                using (var stream = System.IO.File.Create(fullName))
                {
                    file.CopyTo(stream);
                    stream.Close();
                }

                // use convert util to for conversion
                string convertedFile = FileXmlJsonConvertor.ConvertFileAndSave(FileXmlJsonConvertor.TypeOfConversion.xmlToJson,
                    fullName, fileNameWithoutExtension);

                return convertedFile;
            }

            return "Wrong format of file !";
        }




        //protobuff examples

        [HttpPost]
        [Route("ConvertProtobuffToJson")]
        public async Task<string> ConvertProtobuffToJson(IFormFile file)
        {
            return "Not defined yet :)";
        }

        [HttpPost]
        [Route("ConvertProtobuffToXml")]
        public async Task<string> ConvertProtobuffToXml(IFormFile file)
        {
            return "Not defined yet :)";
        }
    }
}
