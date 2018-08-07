using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;

using Android.App;
using Android.Content;
using Android.OS;
using Android.Runtime;
using Android.Views;
using Android.Widget;
using DepedencyInjectionTutorial.Droid;
using Xamarin.Forms;

[assembly: Dependency(typeof(PdfHelper))]
namespace DepedencyInjectionTutorial.Droid
{
    public class PdfHelper : IPdfActions
    {
        public void WriteReadData(string fileName, byte[] data)
        {
            // Write pdf File
            var directory = Android.OS.Environment.ExternalStorageDirectory.AbsolutePath;
            directory = Path.Combine(directory, Android.OS.Environment.DirectoryDownloads);
            string filePath = Path.Combine(directory, fileName);
            File.WriteAllBytes(filePath, data);

            //Open the Pdf file with Defualt app.
            Android.Net.Uri pdfPath = Android.Net.Uri.FromFile(new Java.IO.File(filePath));
            Intent intent = new Intent(Intent.ActionView);
            intent.SetDataAndType(pdfPath, "application/pdf");
            intent.SetFlags(ActivityFlags.NewTask);
            Forms.Context.StartActivity(intent);
        }
    }
}