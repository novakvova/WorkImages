﻿using System;
using System.Collections.Generic;
using System.Drawing;
using System.Drawing.Imaging;
using System.Linq;
using System.Web;

namespace WebSiteDefault.Helpers
{
    public static class WorkImage
    {
        public static Bitmap CreateImage(HttpPostedFileBase hpf, int maxWidth, int maxHeight)
        {
            if (hpf != null && hpf.ContentLength != 0 && hpf.ContentLength <= 10485760)
            {
                try
                {
                    using (Bitmap originalPic = new Bitmap(hpf.InputStream, true))
                    {

                        int originalWidth = originalPic.Width;
                        int originalHeight = originalPic.Height;
                        // To preserve the aspect ratio
                        float ratioX = (float)maxWidth / (float)originalWidth;
                        float ratioY = (float)maxHeight / (float)originalHeight;
                        float ratio = Math.Min(ratioX, ratioY);
                        // New width and height based on aspect ratio
                        int width = (int)(originalWidth * ratio);
                        int height = (int)(originalHeight * ratio);
                        //int width = originalPic.Width;
                        //int height = originalPic.Height;
                        //int widthDiff = width - maxWidth;
                        //int heightDiff = height - maxHeight;
                        //bool doWidthResize = (maxWidth > 0 && width > maxWidth && widthDiff > heightDiff);
                        //bool doHeightResize = (maxHeight > 0 && height > maxHeight && heightDiff > widthDiff);

                        //if(doWidthResize || doHeightResize || (width.Equals(height) && widthDiff.Equals(heightDiff)))
                        //{
                        //    int iStart;
                        //    Decimal divider;
                        //    if(doWidthResize)
                        //    {
                        //        iStart = width;
                        //        divider = Math.Abs((Decimal)iStart / maxWidth);
                        //        width = maxWidth;
                        //        height = (int)Math.Round((height / divider));
                        //    }
                        //    else
                        //    {
                        //        iStart = height;
                        //        divider = Math.Abs((Decimal)iStart / maxHeight);
                        //        height = maxHeight;
                        //        width = (int)Math.Round(width / divider);
                        //    }
                        //}

                        using (Bitmap outBmp = new Bitmap(width, height, PixelFormat.Format24bppRgb))
                        {
                            using (Graphics oGraphics = Graphics.FromImage(outBmp))
                            {
                                oGraphics.SmoothingMode = System.Drawing.Drawing2D.SmoothingMode.AntiAlias;
                                oGraphics.InterpolationMode = System.Drawing.Drawing2D.InterpolationMode.HighQualityBicubic;
                                oGraphics.DrawImage(originalPic, 0, 0, width, height);
                                //Водяний знак
                                Font font = new Font("Arial", 20);
                                Brush brash = new SolidBrush(Color.Blue);
                                oGraphics.DrawString("Hello Vova", font, brash, new Point(25, 25));
                                return new Bitmap(outBmp);
                            }
                        }
                    }
                }
                catch
                {
                    return null;
                }
            }
            return null;
        }
    }
}