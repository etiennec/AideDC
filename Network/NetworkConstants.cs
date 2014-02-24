using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Aide_Dilicom3.Network
{
    public class NetworkConstants
    {
        //URLs
        public const string BASE_URL = "http:///";
        public const string INTERNET_PROTOCOL = "http://";
        public const string HTTP_URL = "http";
        public const string ITGPROJID_PARAM = "?projectId=";
        public const string DEFAULT_URL = "http://localhost:8080";
        

        //public const string POSTPARAM_BOUNDARY_START = "-----------";
        //public const string POSTPARAM_HEADER = "Accept-Charset: utf-8" + "\r\n" + "Content-Type: multipart/form-data;";
        //public const string POSTPARAM_PARAM_CONTENT_TYPE = "content-type: text/plain; charset=UTF-8";
        public const string POSTPARAM_DELIMITER = "&";
        //public const string POSTPARAM_PARAM_INFO = "Content-Disposition: form-data; name=\"";
        public const string POSTPARAM_CONTENT_TYPE = "application/x-www-form-urlencoded";
        public const string POSTPARAM_USER_AGENT = "Mozilla/4.0 (compatible; MSIE 7.0; Windows NT 5.1)";

        //HTML Special Characters
        public const string HTML_AMP = "&";
        public const string HTML_NBSP = " ";
        public const string HTML_QUOTE = "\"";
        public const string HTML_AMPERSAND = "&";
        public const string HTML_LESSTHAN = "<";
        public const string HTML_GREATERTHAN = ">";
        public const string VB_NBSP = " ";
        public const string VB_QUOTE = "\"";
        public const string VB_AMPERSAND = "&";
        public const string VB_LESSTHAN = "<";
        public const string VB_GREATERTHAN = ">";

        ///////// POST PARAMS ////////
        // LOGIN
        public const string PARAM_LOGIN_USERNAME = "j_username";
        public const string PARAM_LOGIN_PASSWORD = "j_password";
        public const string PARAM_LOGIN_BUTTON_FORM = "btn_form02";
        public const string PARAM_LOGIN_BUTTON_FORM_VALUE = "OK";

        // EAN REQUEST
        public const string PARAM_EAN_EAN = "ean";

        // COMMANDS LIST REQUEST
        public const string PARAM_LIST_PAGE = "p";

    }
}
