using Generalate.Models;
using Generalate.Models.ViewModels;
using Generalate.ViewModel;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Globalization;
using System.IO;
using System.Linq;
using System.Text;
using System.Web;
using System.Web.Mvc;

namespace Generalate.Helpers
{
    public static class MultiLanguages
    {
        public static string GetLanguageByControlId(string controlId)
        {
            using (GeneralDBContext context = new GeneralDBContext())
            {
                return "wert";
            }
        }
    }
}