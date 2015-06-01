using com.mosso.cloudfiles.domain;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.IO;
using System.Linq;
using System.Web;
using com.mosso.cloudfiles;

namespace Juega.Utilidades
{
    public class SubirImagen
    {
        string username;
        string api_key;
        string chosenContainer;
        string UrlStorage;
        string UrlAuth;
        string RackIsOnline;
        public SubirImagen()
        {
            try
            {
                username = ConfigurationManager.AppSettings["RACK_USER"].ToString();
                api_key = ConfigurationManager.AppSettings["RACK_API_KEY"].ToString();
                chosenContainer = ConfigurationManager.AppSettings["RACK_CONTAINER"].ToString();
                UrlStorage = ConfigurationManager.AppSettings["RACK_URL_STORAGE"].ToString();
                UrlAuth = ConfigurationManager.AppSettings["RACK_URL_AUTH"].ToString();
                RackIsOnline = ConfigurationManager.AppSettings["RACK_ONLINE"].ToString();
            }
            catch (Exception ex)
            {
            }
        }

        public List<string> UploadImages(string images)
        {

            try
            {

                //}

                var imagesList = images.Split(';');
                var lista = new List<string>();

                //var cmd = new CreateOrUpdateSaleCommand(sale, false);

                foreach (string imgPath in imagesList)
                {

                    string path = "";


                    if (RackIsOnline == "1")
                    {
                        UserCredentials userCreds = new UserCredentials(new Uri(UrlAuth), username, api_key, null, null);
                        Connection connection = new Connection(userCreds);

                        var extension = Path.GetExtension(imgPath);
                        var name = Path.GetFileNameWithoutExtension(imgPath);
                        var tempName = Path.GetRandomFileName();
                        tempName = tempName + extension;

                        var fileStream = new FileStream(imgPath, FileMode.Open, FileAccess.Read);
                        connection.PutStorageItem(chosenContainer, fileStream, tempName);
                        path = UrlStorage + tempName;
                    }
                    else
                        path = imgPath;

                    lista.Add(path);
                }

                return lista;
            }
            catch (Exception ex)
            {
                //LoggerManager.WriteAlert(ex);
                return new List<string>();
            }
        }
    }
}
