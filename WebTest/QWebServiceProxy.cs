using Microsoft.CSharp;
using System;
using System.CodeDom;
using System.CodeDom.Compiler;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net;
using System.Net.Security;
using System.Reflection;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Threading.Tasks;
using System.Web.Services.Description;
using System.Web.Services.Protocols;
using System.Xml;

namespace WebTest
{
    public class QWebServiceProxy : MarshalByRefObject
    {
        private Assembly m_Assembly = null;

        private string m_ProtocolName = "Soap";

        private string m_SourceProxy = string.Empty;

        private string m_NameSpace = string.Empty;

        private string m_TypeName = string.Empty;

        private string m_URL = string.Empty;

        private int m_Timeout = 100000;

        private ICredentials m_Credentials;

        private X509Certificate2Collection m_X509CertCollection;

        private IWebProxy m_Proxy;

        private string m_UserName = string.Empty;

        private string m_Password = string.Empty;

        public string URL
        {
            get {
                return m_URL;
            }
            set {
                m_URL = value;
            }
        }

        public int Timeout
        {
            get {
                return m_Timeout;
            }
            set {
                m_Timeout = value;
            }
        }

        public Assembly Assembly => m_Assembly;

        public string ProtocolName
        {
            get {
                return m_ProtocolName;
            }
            set {
                m_ProtocolName = value;
            }
        }

        public string SourceProxy
        {
            get {
                return m_SourceProxy;
            }
            set {
                m_SourceProxy = value;
            }
        }

        public string NameSpace
        {
            get {
                return m_NameSpace;
            }
            set {
                m_NameSpace = value;
            }
        }

        public string TypeName
        {
            get {
                return m_TypeName;
            }
            set {
                m_TypeName = value;
            }
        }

        public QWebServiceProxy(string wsdlSourceName, string nameSpace, string typeName)
        {
            m_NameSpace = nameSpace;
            m_TypeName = typeName;
            AssemblyFromWsdl(GetWsdl(wsdlSourceName));
            ServicePointManager.ServerCertificateValidationCallback = RemoteCertificateValidationCallback_EventHandler;
        }

        public bool RemoteCertificateValidationCallback_EventHandler(object sender, X509Certificate certificate, X509Chain chain, SslPolicyErrors sslPolicyErrors)
        {
            return true;
        }

        public QWebServiceProxy(Assembly assembly, string nameSpace, string typeName)
        {
            m_NameSpace = nameSpace;
            m_TypeName = typeName;
            m_Assembly = assembly;
            ServicePointManager.ServerCertificateValidationCallback = RemoteCertificateValidationCallback_EventHandler;
        }

        public string WsdlFromUrl(string url)
        {
            WebRequest webRequest = WebRequest.Create(url);
            WebResponse response = webRequest.GetResponse();
            Stream responseStream = response.GetResponseStream();
            Encoding encoding = Encoding.GetEncoding("utf-8");
            StreamReader streamReader = new StreamReader(responseStream, encoding);
            return streamReader.ReadToEnd();
        }

        public ICredentials Credential(string userName, string passWord)
        {
            return m_Credentials = new NetworkCredential(userName, passWord);
        }

        public void Certificate(string location)
        {
            if (location.Trim().Length != 0)
            {
                if (string.Compare(location, "LocalMachine", true) == 0)
                {
                    X509Store x509Store = new X509Store(StoreName.My, StoreLocation.LocalMachine);
                    x509Store.Open(OpenFlags.OpenExistingOnly);
                    m_X509CertCollection = x509Store.Certificates.Find(X509FindType.FindByTimeValid, DateTime.Now, false);
                }
                else if (string.Compare(location, "CurrentUser", true) == 0)
                {
                    X509Store x509Store2 = new X509Store(StoreName.My, StoreLocation.CurrentUser);
                    x509Store2.Open(OpenFlags.OpenExistingOnly);
                    m_X509CertCollection = x509Store2.Certificates.Find(X509FindType.FindByTimeValid, DateTime.Now, false);
                }
                else
                {
                    string filename = (location.IndexOf(":") >= 0) ? location : Path.Combine(AppDomain.CurrentDomain.BaseDirectory, location);
                    X509Certificate value = X509Certificate.CreateFromCertFile(filename);
                    m_X509CertCollection = new X509Certificate2Collection();
                    m_X509CertCollection.Add(value);
                }
            }
        }

        public IWebProxy WebProxy(string proxyAddress, string username, string password, string domain)
        {
            m_Proxy = new WebProxy(proxyAddress, true);
            if (domain.Length > 0)
            {
                m_Proxy.Credentials = new NetworkCredential(username, password, domain);
            }
            else
            {
                m_Proxy.Credentials = new NetworkCredential(username, password);
            }
            return m_Proxy;
        }

        public string GetWsdl(string source)
        {
            if (!source.StartsWith("<?xml version"))
            {
                if (!source.StartsWith("http://"))
                {
                    return WsdlFromFile(source);
                }
                return WsdlFromUrl(source);
            }
            return source;
        }

        public string WsdlFromFile(string fileFullPathName)
        {
            FileInfo fileInfo = new FileInfo(fileFullPathName);
            if (!(fileInfo.Extension == ".wsdl"))
            {
                throw new Exception("This is no a wsdl file");
            }
            FileStream fileStream = new FileStream(fileFullPathName, FileMode.Open, FileAccess.Read);
            StreamReader streamReader = new StreamReader(fileStream);
            char[] array = new char[(int)fileStream.Length];
            streamReader.ReadBlock(array, 0, (int)fileStream.Length);
            return new string(array);
        }

        public Assembly AssemblyFromWsdl(string wsdlContent)
        {
            StringReader input = new StringReader(wsdlContent);
            XmlTextReader xmlTextReader = new XmlTextReader(input);
            ServiceDescription serviceDescription = ServiceDescription.Read(xmlTextReader);
            xmlTextReader.Close();
            CodeNamespace codeNamespace = new CodeNamespace(m_NameSpace);
            ServiceDescriptionImporter serviceDescriptionImporter = new ServiceDescriptionImporter();
            serviceDescriptionImporter.AddServiceDescription(serviceDescription, null, null);
            serviceDescriptionImporter.ProtocolName = m_ProtocolName;
            serviceDescriptionImporter.Import(codeNamespace, null);
            CSharpCodeProvider cSharpCodeProvider = new CSharpCodeProvider();
            StringBuilder stringBuilder = new StringBuilder();
            StringWriter stringWriter = new StringWriter(stringBuilder);
            cSharpCodeProvider.GenerateCodeFromNamespace(codeNamespace, stringWriter, null);
            m_SourceProxy = stringBuilder.ToString();
            stringWriter.Close();
            CompilerResults compilerResults = cSharpCodeProvider.CompileAssemblyFromSource(new CompilerParameters
            {
                ReferencedAssemblies =
            {
                "System.dll",
                "System.Xml.dll",
                "System.Web.Services.dll"
            },
                GenerateExecutable = false,
                GenerateInMemory = true,
                IncludeDebugInformation = false
            }, m_SourceProxy);
            if (compilerResults.Errors.Count > 0)
            {
                throw new Exception($"Build failed: {compilerResults.Errors.Count} errors");
            }
            return m_Assembly = compilerResults.CompiledAssembly;
        }

        public object CreateInstance()
        {
            object[] array = new object[1];
            Type type = m_Assembly.GetType(m_NameSpace + "." + m_TypeName, true, true);
            if (!(m_URL != string.Empty))
            {
                return Activator.CreateInstance(type);
            }
            array.SetValue(m_URL, 0);
            return Activator.CreateInstance(type, array);
        }

        public object Invoke(object obj, string methodName, object[] args)
        {
            Type[] array;
            if (args.Length == 0)
            {
                array = new Type[0];
            }
            else
            {
                array = new Type[args.Length];
                for (int i = 0; i < args.Length; i++)
                {
                    array[i] = args[i].GetType();
                }
            }
            if (m_Credentials != null)
            {
                Uri uri = new Uri(((SoapHttpClientProtocol)obj).Url);
                ((SoapHttpClientProtocol)obj).PreAuthenticate = true;
                ((SoapHttpClientProtocol)obj).Credentials = m_Credentials.GetCredential(uri, "");
            }
            if (m_X509CertCollection != null)
            {
                Uri uri2 = new Uri(((SoapHttpClientProtocol)obj).Url);
                ((SoapHttpClientProtocol)obj).PreAuthenticate = true;
                ((SoapHttpClientProtocol)obj).ClientCertificates.AddRange(m_X509CertCollection);
            }
            if (m_Proxy != null)
            {
                ((SoapHttpClientProtocol)obj).Proxy = m_Proxy;
            }
            ((SoapHttpClientProtocol)obj).Timeout = m_Timeout;
            MethodInfo method = obj.GetType().GetMethod(methodName, array);
            return method.Invoke(obj, args);
        }

        public object Invoke(string methodName, object[] args)
        {
            object obj = CreateInstance();
            return Invoke(obj, methodName, args);
        }
    }
}
