using Amazon.S3.Model;
using System;
using System.Collections.Generic;
using System.IO;
using System.Text;
using Tolentinos.Domain.Entities;
using Tolentinos.Domain.Interfaces;

namespace Tolentinos.Service.Services
{
    public class ImagemProdutoService : BaseService<ImagemProduto>
    {
        private readonly IFileUploadHandler _fileUploadHandler;

        public ImagemProdutoService(IRepository<ImagemProduto> repository, IFileUploadHandler fileUploadHandler) : base(repository)
        {
            _fileUploadHandler = fileUploadHandler;
        }

        public override ImagemProduto Post<V>(ImagemProduto obj)
        {

            string guid = Guid.NewGuid().ToString();

            string savePath = $"produtos/{guid}-{obj.File.FileName}";

            obj.Url = _fileUploadHandler.SaveFile(obj.File, savePath);

            obj.File = null;

            return base.Post<V>(obj);
        }

        public override void Remove(long id)
        {
            var model = this.Get(id);
            _fileUploadHandler.DeleteFile(model.Url);
             base.Remove(id);
        }
    }
}
