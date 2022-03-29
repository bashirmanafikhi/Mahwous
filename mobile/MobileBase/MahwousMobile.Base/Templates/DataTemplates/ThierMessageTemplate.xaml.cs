using Mahwous.Core.Entities;
using Mahwous.Service.ViewModels.Messages;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace MahwousMobile.Base.Templates.DataTemplates
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class ThierMessageTemplate : ContentView
    {
        // BindableProperty implementation
        public static readonly BindableProperty ReportCommandProperty =
            BindableProperty.Create(nameof(ReportCommand), typeof(ICommand), typeof(ThierMessageTemplate), null);

        public ICommand ReportCommand
        {
            get { return (ICommand)GetValue(ReportCommandProperty); }
            set { SetValue(ReportCommandProperty, value); }
        }

        public ThierMessageTemplate()
        {
            InitializeComponent();
        }

        private async void ReportUser_Clicked(object sender, EventArgs e)
        {
            bool answer = await Application.Current.MainPage.DisplayAlert("إبلاغ عن اساءة", "هل أنت متأكد انك تريد الإبلاغ عن هذا المحتوى وحظر هذا المستخدم؟ \n هذا الإبلاغ سوف يتم إرساله لمراجعته وسوف يتم حظر المستخدم وكافة رسائله اذا كانت إساءة الإستخدام صحيحة.", "نعم بالتأكيد", "إلغاء", FlowDirection.RightToLeft);
            if (answer)
            {
                if (ReportCommand == null) return;

                var message = BindingContext as GetMessageDetailsResponse;
                var report = new Report();
                report.ViolatorId = message.UserId;
                report.Details = "Message Violation: " + message.Content;

                if (ReportCommand.CanExecute(report))
                    ReportCommand.Execute(report);
            }
        }

        static void OnCommandPropertyChanged(BindableObject bindable, object oldValue, object newValue)
        {
            (bindable as ThierMessageTemplate).ReportCommand = (Command)newValue;
        }
    }
}