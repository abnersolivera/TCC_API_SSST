using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Interfaces
{
    public interface IUpload
    {
        Task<string> UploadBase64(string base64, string container);
    }
}
