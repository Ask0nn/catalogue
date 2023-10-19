using CommunityToolkit.Mvvm.Messaging.Messages;

namespace Catalogue.Models
{
    public class SendFileMessage : ValueChangedMessage<string>
    {
        public SendFileMessage(string value) : base(value) { }
    }
}
