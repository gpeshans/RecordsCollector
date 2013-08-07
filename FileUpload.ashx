<%@ WebHandler Language="C#" Class="FileUploader" %>

using System;
using System.Web;
using System.IO;
using System.Web.Hosting;
using System.Web.SessionState;
using System.Diagnostics;

public class FileUploader : IHttpHandler, IRequiresSessionState
{

    private HttpContext _httpContext;
    private string preSaveExt = "tmp";
    private string fName;
    private bool _lastChunk;
    private bool _firstChunk;
    private long _startByte;

    StreamWriter _debugFileStreamWriter;
    TextWriterTraceListener _debugListener;

    public void ProcessRequest(HttpContext context)
    {
        _httpContext = context;

        fName = _httpContext.Session["fileName"].ToString();

        if (context.Request.InputStream.Length == 0)
            throw new ArgumentException("No file input");

        try
        {

            GetQueryStringParameters();

            string uploadFolder = "Files";
            string tempFileName = fName + preSaveExt;

            if (_firstChunk)
            {
                //Delete temp file
                if (File.Exists(@HostingEnvironment.ApplicationPhysicalPath + "/" + uploadFolder + "/" + tempFileName))
                    File.Delete(@HostingEnvironment.ApplicationPhysicalPath + "/" + uploadFolder + "/" + tempFileName);

                //Delete target file
                if (File.Exists(@HostingEnvironment.ApplicationPhysicalPath + "/" + uploadFolder + "/" + fName))
                    File.Delete(@HostingEnvironment.ApplicationPhysicalPath + "/" + uploadFolder + "/" + fName);

            }

            using (FileStream fs = File.Open(@HostingEnvironment.ApplicationPhysicalPath + "/" + uploadFolder + "/" + tempFileName, FileMode.Append))
            {
                SaveFile(context.Request.InputStream, fs);
                fs.Close();
            }

            if (_lastChunk)
            {
                File.Move(HostingEnvironment.ApplicationPhysicalPath + "/" + uploadFolder + "/" + tempFileName, HostingEnvironment.ApplicationPhysicalPath + "/" + uploadFolder + "/" + fName);
            }

        }
        catch (Exception e)
        {
            throw;
        }
    }

    private void GetQueryStringParameters()
    {
        //fName = _httpContext.Request.QueryString["file"];        
        _lastChunk = string.IsNullOrEmpty(_httpContext.Request.QueryString["last"]) ? true : bool.Parse(_httpContext.Request.QueryString["last"]);
        _firstChunk = string.IsNullOrEmpty(_httpContext.Request.QueryString["first"]) ? true : bool.Parse(_httpContext.Request.QueryString["first"]);
        _startByte = string.IsNullOrEmpty(_httpContext.Request.QueryString["offset"]) ? 0 : long.Parse(_httpContext.Request.QueryString["offset"]); ;
    }

    private void SaveFile(Stream stream, FileStream fs)
    {
        byte[] buffer = new byte[4096];
        int bytesRead;
        while ((bytesRead = stream.Read(buffer, 0, buffer.Length)) != 0)
        {
            fs.Write(buffer, 0, bytesRead);
        }
    }

    public bool IsReusable
    {
        get
        {
            return false;
        }
    }

}