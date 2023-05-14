using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.UriComposer
{
    public interface IUriComposerService
    {
        string ComposeImageUri(string src);
    }

    public class UriComposerService : IUriComposerService
    {
        public string ComposeImageUri(string src)
        {
            return "http://localhost:5038/" + src.Replace("\\", "//");
        }
    }
}
