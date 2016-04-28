<%@ Page Language="C#" %>

<script runat="server">
    private string getFileName(string file)
    {
        string urlName = Request.Url.AbsolutePath;
        urlName = urlName.Remove(0, urlName.LastIndexOf("/") + 1);
        urlName = urlName.Replace(".aspx", "");
        // urlName = "thumbnail" if page is "thumbnail.aspx"
        
        System.IO.FileInfo fileInfo = new System.IO.FileInfo(file);
        string size = Request.QueryString["width"];
        if (Request.QueryString["width"] == null)
            size = Request.QueryString["height"];

        string cacheFilePath = fileInfo.DirectoryName + "/" + fileInfo.Name + "." + urlName + "." + size + ".cache" + fileInfo.Extension;
        cacheFilePath = cacheFilePath.Remove(0, Request.PhysicalApplicationPath.Length).Replace("\\", "/");

        return cacheFilePath;
    }
    protected void Page_Load(object sender, EventArgs e)
    {
        if (Request.QueryString["width"] == null )
            throw new Aryaban.Engine.Core.Error.CoreException("Please specify either width of box");

        // get the file name -- fall800.jpg
        string file = Request.PhysicalApplicationPath + Request.QueryString["file"];

        if (file.EndsWith("/"))
            file = Request.PhysicalApplicationPath + "/modules/SiMor/data/members/images/no-image.png";


        if (!file.ToLower().EndsWith(".jpg") && !file.ToLower().EndsWith(".gif") && !file.ToLower().EndsWith(".bmp") && !file.ToLower().EndsWith(".png"))
        {
            string extension = file.Substring(file.LastIndexOf(".") + 1);
            if (System.IO.File.Exists(Request.PhysicalApplicationPath + "data/images/file-type/" + extension + ".png"))
                Response.Redirect("/data/images/file-type/" + extension + ".png");
        }
        
        string cacheFile = getFileName(file);
        if (ConfigurationSettings.AppSettings["cache_thumbnail"] == "yes")
        {
            if (System.IO.File.Exists(Request.PhysicalApplicationPath + cacheFile))
                Response.Redirect("/" + cacheFile);
        }

        // create an image object, using the filename we just retrieved
        System.Drawing.Image image = null;
        System.Drawing.Image shadowImage = null;
        try
        {
            image = System.Drawing.Image.FromFile(file);
        }
        catch (Exception)
        {
            Response.Write("File not found");
            return;
        }

        int Width = Convert.ToInt32(Request.QueryString["width"]);
        int Height = Width;
        int iNewWidth = image.Width;
        int iNewHeight = image.Height;

        if (Request.QueryString["width"] != null)
        {
            if (iNewHeight <= iNewWidth)
            {
                iNewWidth = (Width * iNewWidth) / iNewHeight;
                iNewHeight = Width;
            }
            else
            {
                iNewHeight = (Width * iNewHeight) / iNewWidth;
                iNewWidth = Width;
            }
        }
        
        int width_box = (iNewWidth > iNewHeight) ? iNewHeight : iNewWidth;
        System.Drawing.Bitmap bmp = new System.Drawing.Bitmap(width_box, width_box);

        System.Drawing.Graphics gr = System.Drawing.Graphics.FromImage(bmp);
        gr.SmoothingMode = System.Drawing.Drawing2D.SmoothingMode.HighQuality;
        gr.CompositingQuality = System.Drawing.Drawing2D.CompositingQuality.HighQuality;
        gr.InterpolationMode = System.Drawing.Drawing2D.InterpolationMode.High;

        System.Drawing.Rectangle rectDestination = new System.Drawing.Rectangle(0, 0, iNewWidth, iNewHeight);
        if (iNewWidth > iNewHeight)
            gr.DrawImage(image, (int)((iNewWidth - iNewHeight) / 2) * -1, 0, iNewWidth, iNewHeight);
        else
            gr.DrawImage(image, 0, (int)((iNewHeight - iNewWidth) / 2) * -1, iNewWidth, iNewHeight);

      // Draw watermark
      if (ConfigurationSettings.AppSettings["use_watermark"] == "yes" && Session["referee"] == null)
      {
	System.Drawing.Image imageWatermark = System.Drawing.Image.FromFile(Request.PhysicalApplicationPath + "modules/general/images/mark.png");
        int iWaterWidth = imageWatermark.Width;
        int iWaterHeight = imageWatermark.Height;

        int iWaterDrawWidth = 0;
        int iWaterDrawHeight = 0;
        if ((iWaterWidth*2) < iNewWidth)
        {
          while (iWaterDrawWidth < iNewWidth)
          {
            while (iWaterDrawHeight < iNewHeight)
            {
        	gr.DrawImage(imageWatermark, iWaterDrawWidth, iWaterDrawHeight, iWaterWidth, iWaterHeight);
                iWaterDrawHeight += iWaterHeight;
            }
	    iWaterDrawHeight = 0;
            iWaterDrawWidth += iWaterWidth;
          }
	}
     }

        System.Drawing.Image thumbnailImage = (System.Drawing.Image)bmp;

        // make a memory stream to work with the image bytes
        System.IO.MemoryStream imageStream = new System.IO.MemoryStream();

        // put the image into the memory stream
        string fileExtention = (new System.IO.FileInfo(file)).Extension;
        switch (fileExtention)
        {
            case ".jpg":
                bmp.Save(imageStream, System.Drawing.Imaging.ImageFormat.Jpeg);
                break;
            case ".gif":
                bmp.Save(imageStream, System.Drawing.Imaging.ImageFormat.Gif);
                break;
            case ".bmp":
                bmp.Save(imageStream, System.Drawing.Imaging.ImageFormat.Bmp);
                break;
            case ".png":
                bmp.Save(imageStream, System.Drawing.Imaging.ImageFormat.Png);
                break;
            default:
                bmp.Save(imageStream, System.Drawing.Imaging.ImageFormat.Jpeg);
                break;
        }

        // make byte array the same size as the image
        byte[] imageContent = new Byte[imageStream.Length];

        // rewind the memory stream
        imageStream.Position = 0;

        // load the byte array with the image
        imageStream.Read(imageContent, 0, (int)imageStream.Length);

        // return byte array to caller with image type
        switch (fileExtention)
        {
            case ".jpg":
                Response.ContentType = "image/jpeg";
                break;
            case ".gif":
                Response.ContentType = "image/gif";
                break;
            case ".bmp":
                Response.ContentType = "image/bmp";
                break;
            case ".png":
                Response.ContentType = "image/png";
                break;
            default:
                Response.ContentType = "image/jpeg";
                break;
        }


        Response.BinaryWrite(imageContent);

        if (ConfigurationSettings.AppSettings["cache_thumbnail"] == "yes")
        {
            System.IO.FileStream writer = new System.IO.FileStream((Request.PhysicalApplicationPath + cacheFile), System.IO.FileMode.Create);
            writer.Write(imageContent, 0, imageContent.Length);
            writer.Flush();
            writer.Close();
        }
    }

    /// <summary>
    /// Required, but not used
    /// </summary>
    /// <returns>true</returns>
    public bool ThumbnailCallback()
    {
        return true;
    }

</script>