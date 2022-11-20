namespace NotinoHomework.Utils
{
    public class FileXmlJsonConvertor
    {
        public enum TypeOfConversion
        {
            jsonToXml,
            xmlToJson,
        }

        public static string ConvertFileAndSave(TypeOfConversion typeOfConversion, string fileLocation, string fileNameWithoutExtension)
        {
            try
            {
                //open saved file and read file
                FileStream sourceStream = System.IO.File.Open(fileLocation, FileMode.Open);
                var reader = new StreamReader(sourceStream);
                string input = reader.ReadToEnd();
                reader.Close();

                string convertedBody = "";
                string finalExtension = "";

                switch (typeOfConversion)
                {
                    case TypeOfConversion.jsonToXml:
                        {
                            convertedBody = StringJsonXmlConvertor.ConvertJSONtoXML(input);
                            finalExtension = ".xml";
                            break;
                        }
                    case TypeOfConversion.xmlToJson:
                        {
                            convertedBody = StringJsonXmlConvertor.ConvertXMLtoJSON(input);
                            finalExtension = ".json";
                            break;
                        }
                }

                //create empty file on disk
                string newDir = Environment.CurrentDirectory + "\\FilesConverted\\";
                string convertedFileLocation = newDir + fileNameWithoutExtension + finalExtension;

                System.IO.File.Create(convertedFileLocation).Close();

                //save xml in file
                var targetStream = System.IO.File.Open(convertedFileLocation, FileMode.Create, FileAccess.Write);
                var sw = new StreamWriter(targetStream);
                sw.Write(convertedBody);
                sw.Close();

                return convertedFileLocation;
            }
            catch(Exception ex)
            {
                return ex.ToString();
            }
        }
    }
}
