using Amazon.S3;
using Amazon.S3.Model;
using BookWormApi.Models;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BookWormApi.Services
{
    public class S3Persistence
    {
        string BucketName { get; set; }
        IAmazonS3 S3Client { get; set; }

        public S3Persistence(IAmazonS3 s3Client)
        {
            S3Client = s3Client;

            BucketName = Startup.AppS3BucketKey;
            if (string.IsNullOrEmpty(BucketName))
            {
                throw new Exception("Missing configuration for S3 bucket. The AppS3Bucket configuration must be set to a S3 bucket.");
            }      
            
        }
        
        public async Task SaveRequest(PersistedRequestResponse requestResponse)
        {
            var seekableStream = new MemoryStream();
            
            var bytes = Encoding.UTF8.GetBytes(requestResponse.ToString());
            await seekableStream.WriteAsync(bytes, 0, bytes.Length);

            seekableStream.Position = 0;
            string key = Guid.NewGuid().ToString();
            var putRequest = new PutObjectRequest
            {
                BucketName = BucketName,
                Key = key,
                InputStream = seekableStream
            };

            var response = await S3Client.PutObjectAsync(putRequest);                
        }
    }
}
