using System;
using Xamarin.Forms;
using XamarinApp.Views.Cells;
using XamarinApp.Models;

namespace XamarinApp.Helpers
{
    public class ChatTemplateSelector : DataTemplateSelector
    {
        DataTemplate incomingDataTemplate;
        DataTemplate outgoingDataTemplate;

        public ChatTemplateSelector()
        {
            this.incomingDataTemplate = new DataTemplate(typeof(IncomingViewCell));
            this.outgoingDataTemplate = new DataTemplate(typeof(OutgoingViewCell));
        }

        protected override DataTemplate OnSelectTemplate(object item, BindableObject container)
        {
            var messageVm = item as MessageModel;
            if (messageVm == null)
                return null;


            return (messageVm.User == Settings.User) ? outgoingDataTemplate : incomingDataTemplate;
        }
    }
}
