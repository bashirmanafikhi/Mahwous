
namespace Mahwous.Core.Models
{
    public class VideoStatus : Status
    {
        //[Required(ErrorMessage = "لاتنسى عنوان الفيديو اجباري")]
        public string Title { get; set; }
        //[Required(ErrorMessage = "الفيديو اجباري اختر فيديو من فضلك")]
        public string VideoPath { get; set; }
        //[Required(ErrorMessage = "أدخل غلاف من فضلك")]
        public string CoverPath { get; set; }

    }
}
