using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Web;
using System.Xml.Serialization;
using Landau.Models.OperationModels;

namespace Landau.Helper
{
    public static class XmlHelper
    {
        /// <summary>
        /// сериализуем объект
        /// </summary>
        /// <returns></returns>
        public static string XMLSerialize(OperationModel model)
        {
            try
            {
                XmlSerializer xmlSerializer = new XmlSerializer(typeof(OperationModel));
                string result = "";
                using (StringWriter textWriter = new StringWriter())
                {
                    xmlSerializer.Serialize(textWriter, model);
                    return textWriter.ToString();
                }

                return "";
            }
            catch (Exception)
            {
                return "";
            }
        }

        /// <summary>
        /// десериализуем объект
        /// </summary>
        /// <returns></returns>
        public static OperationModel XMLDeserialize(string model)
        {
            try
            {
                XmlSerializer xmlSerializer = new XmlSerializer(typeof(OperationModel));
                string result = "";
                using (StringReader reader = new StringReader(model))
                {
                    OperationModel operationModel = (OperationModel)xmlSerializer.Deserialize(reader);
                    return operationModel;
                }
                return null;
            }
            catch (Exception)
            {
                return null;
            }
        }
    }
}