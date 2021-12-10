using Mahwous.Core.Entities;
using Mahwous.Service.ViewModels.Messages;
using MahwousMobile.Base.Templates.DataTemplates;
using System;
using System.Collections.Generic;
using System.Text;
using Xamarin.Forms;

namespace MahwousMobile.Base.TemplateSelectors
{
    public class ChatBubbleTemplateSelctor : DataTemplateSelector
    {
        public DataTemplate MyMessage { get; set; }
        public DataTemplate ThierMessage { get; set; }
        protected override DataTemplate OnSelectTemplate(object item, BindableObject container)
        {
            var message = item as GetMessageDetailsResponse;
            return message.IsOwner ? MyMessage : ThierMessage;
            //if (message.IsHidden)
            //{
            //    var messageTemplate = new MyMessageTemplate();
            //    //messageTemplate.Co = container.BindingContext;
            //    return new DataTemplate(() => messageTemplate);
            //}
            //else
            //{
            //    var messageTemplate = new ThierMessageTemplate();
            //    //messageTemplate.BindingContext = container.BindingContext;
            //    return new DataTemplate(() => messageTemplate);
            //}
        }
    }
}
