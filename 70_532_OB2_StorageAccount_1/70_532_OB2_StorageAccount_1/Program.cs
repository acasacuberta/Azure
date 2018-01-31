using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Azure;
using Microsoft.WindowsAzure.Storage;
using Microsoft.WindowsAzure.Storage.Blob;

namespace _70_532_OB2_StorageAccount_1
{
    class Program
    {
        static void Main(string[] args)
        {
            // string storageConnection = "DefaultEndpointsProtocol=https;AccountName=az532ob2psureshkjan1;AccountKey=t/PD/dWdIs24ggo+7ukcBeV0qqIWdggWGnQrXEsR7cCnE+P0Ua8/YV7vlxXFS1wAQTMsQJOalF7TLfJf9TM2EQ==;EndpointSuffix=core.windows.net";
            string storageConnection = "DefaultEndpointsProtocol=https;AccountName=az532ob2psureshkjan1;AccountKey=t/PD/dWdIs24ggo+7ukcBeV0qqIWdggWGnQrXEsR7cCnE+P0Ua8/YV7vlxXFS1wAQTMsQJOalF7TLfJf9TM2EQ==;EndpointSuffix=core.windows.net";


            CloudStorageAccount storageAccount = CloudStorageAccount.Parse(storageConnection);

            CloudBlobClient blobClient = storageAccount.CreateCloudBlobClient();
            CloudBlobContainer blobContainer = blobClient.GetContainerReference("container for the blob for obj2");


            blobContainer.CreateIfNotExistsAsync();

            CloudBlockBlob blockBlob = blobContainer.GetBlockBlobReference("check for availbility");

            using (var fileStream = System.IO.File.OpenRead(@"C:\Praveen\readdevicecloudmessages\readDeviceCloudMessages.js")) {
                blockBlob.UploadFromStream(fileStream);
            }




            Console.ReadKey();

        }
    }
}
