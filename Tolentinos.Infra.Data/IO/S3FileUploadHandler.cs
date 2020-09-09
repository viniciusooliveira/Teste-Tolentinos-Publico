using Amazon;
using Amazon.Runtime;
using Amazon.S3;
using Amazon.S3.Model;
using Amazon.S3.Transfer;
using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.IO;
using System.Reflection.Metadata;
using System.Text;
using System.Threading.Tasks;
using Tolentinos.Domain.Interfaces;

namespace Tolentinos.Infra.Data.IO
{
    public class S3FileUploadHandler : IFileUploadHandler
    {

        private readonly string _bucketName;
        private readonly RegionEndpoint _bucketRegion;
        private readonly IAmazonS3 _client;
        public S3FileUploadHandler(string bucketName, RegionEndpoint bucketRegion, IAmazonS3 client)
        {
            _bucketName = bucketName;
            _bucketRegion = bucketRegion;
            _client = client;
        }

        public string SaveFile(IFormFile file, string savePath)
        {

            var fileTransferUtility =
                new TransferUtility(_client);

            TransferUtilityUploadRequest request = new TransferUtilityUploadRequest();
            request.BucketName = _bucketName;
            request.InputStream = file.OpenReadStream();
            request.Key = savePath;
            request.CannedACL = S3CannedACL.PublicRead;

            fileTransferUtility.Upload(request);

            return $"https://{_bucketName}.s3-{_bucketRegion.SystemName}.amazonaws.com/{savePath}";
        }

        public bool DeleteFile(string path)
        {

            string key = this.GetKey(path);

            _client.DeleteObjectAsync(new DeleteObjectRequest()
            {
                BucketName = _bucketName,
                Key = key
            });

            return true;
        }

        private string GetKey(string path)
        {
            Uri uri = new Uri(path);
            return uri.AbsolutePath.Trim('/');
        }
    }
}
