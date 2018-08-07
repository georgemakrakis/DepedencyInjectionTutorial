using DepedencyInjectionTutorial.UWP;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Windows.Storage;
using Windows.Storage.Pickers;
using DepedencyInjectionTutorial;


[assembly: Xamarin.Forms.Dependency(typeof(PdfHelper))]
namespace DepedencyInjectionTutorial.UWP
{
    public class PdfHelper : IPdfActions
    {
        public async void WriteReadData(string fileName, byte[] data)
        {
            FolderPicker picker = new FolderPicker { SuggestedStartLocation = PickerLocationId.Downloads };
            picker.FileTypeFilter.Add("*");
            StorageFolder folder = await picker.PickSingleFolderAsync();
            if (folder != null)
            {
                StorageFile pdfFile = await folder.CreateFileAsync(fileName, CreationCollisionOption.ReplaceExisting);
                await FileIO.WriteBytesAsync(pdfFile, data);
            }
        }
    }
}
