using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using PX.Data;
using PX.Data.BQL;
using PX.Data.BQL.Fluent;
using PX.Objects.CR;
using PX.Objects.CR.BackwardCompatibility;
using PX.Objects.EP;
using PX.SM;
using PX.SM;
using static AcumaticaChatTeam7.AcumaticaChatMember;

namespace AcumaticaChatTeam7
{
    public class ChatMessageEntry : PXGraph<ChatMessageEntry>
    {

        public SelectFrom<AcumaticaChat>
            .InnerJoin<Users>.On<Users.pKID.IsEqual<AcumaticaChat.createdByID>.And<AcumaticaChat.refNoteID.IsEqual<ChatumaticaChat.refNoteID.FromCurrent>>>.View Chats;
        public SelectFrom<AcumaticaChatMember>
            .InnerJoin<Users>.On<Users.pKID.IsEqual<AcumaticaChatMember.userid>>
            .Where<AcumaticaChatMember.chatID.IsEqual<AcumaticaChat.chatID.FromCurrent>>

            .View ChatMembers;
        public SelectFrom<AcumaticaChatMessage>
            .InnerJoin<Users>.On<Users.pKID.IsEqual<AcumaticaChatMessage.createdByID>>
            .Where<AcumaticaChatMessage.chatID.IsEqual<AcumaticaChat.chatID.FromCurrent>>.View ChatMessages;

        [PXVirtualDAC]
        public PXFilter<ChatumaticaChat> ChatumaticaChat;


        public PXAction<CRActivity> SubmitMessage;
        [PXUIField(DisplayName = "Submit Message", MapEnableRights = PXCacheRights.Select, MapViewRights = PXCacheRights.Select)]
        [PXButton]
        protected virtual IEnumerable submitMessage(PXAdapter adapter)
        {

            var NewMessage = ChatumaticaChat.Current;
            if (NewMessage != null && String.IsNullOrWhiteSpace(NewMessage.Message) == false)
            {

                AcumaticaChatMessage message = new AcumaticaChatMessage();
                message.Message = NewMessage.Message;

                if (message.Message.Contains("@"))
                {
                    //search for username
                    string UserName = message.Message.Split('@').LastOrDefault().Split(' ').FirstOrDefault();
                    var FoundUser = SelectFrom<PX.SM.Users>.Where<PX.SM.Users.username.IsEqual<@P.AsString>>.View.Select(this, UserName).TopFirst;
                    if (FoundUser != null)
                    {
                        //add user to the members
                        AcumaticaChatMember member = ChatMembers.Insert(new AcumaticaChatMember());

                        member.Userid = FoundUser.PKID;
                        ChatMembers.Update(member);

                    }
                }

                ChatMessages.Insert(message);
                Persist();
                NewMessage.Message = "";
                NewMessage.ChatLog = GetChatLog();
                ChatumaticaChat.Update(NewMessage);

                ChatumaticaChat.View.RequestRefresh();
            }

            return adapter.Get();
        }


        public string GetChatLog()
        {
            string Chatlog = "";
            List<Tuple<DateTime?, String, int>> Messages = new List<Tuple<DateTime?, string, int>>();

            var chat = Chats.Current;
            if(chat != null) {
                Users created = Users.PK.Find(this, chat.CreatedByID);
                string CurrentMessage =  created.DisplayName + " has started the chat." + Environment.NewLine;
                Messages.Add(new Tuple<DateTime?, string, int>(chat.CreatedDateTime, CurrentMessage, 0));
            }

            List<Guid?> AddedChatMembers = new List<Guid?>();

            foreach (var Member in ChatMembers.Select())
            {
                AcumaticaChatMember ChatMember = Member.GetItem<AcumaticaChatMember>();
                Users User = Member.GetItem<Users>();
                if (AddedChatMembers.Contains(User.PKID) == false)
                {
                    AddedChatMembers.Add(User.PKID);
                    string CurrentMessage = "\t\t" + User.DisplayName + " has been invited to the chat." + Environment.NewLine;
                    Messages.Add(new Tuple<DateTime?, string, int>(ChatMember.CreatedDateTime, CurrentMessage, 2));
                }
            }

            foreach (var Message in ChatMessages.Select())
            {
                AcumaticaChatMessage ChatMessage = Message.GetItem<AcumaticaChatMessage>();
                Users User = Message.GetItem<Users>();
                string CurrentMessage = "(" + ChatMessage.CreatedDateTime.Value.ToString("hh:mm tt") + ") "
                    + User.DisplayName + ": " + ChatMessage.Message;

                Messages.Add(new Tuple<DateTime?, string, int>(ChatMessage.CreatedDateTime, CurrentMessage, 1));
            }

            foreach (var Message in Messages.OrderBy(o => o.Item1).ThenBy(o => o.Item3))
            {
                if (String.IsNullOrWhiteSpace(Chatlog) == false)
                    Chatlog += Environment.NewLine;
                Chatlog += Message.Item2;
            }
            return Chatlog;
        }
        public virtual void _(Events.FieldSelecting<ChatumaticaChat.chatLog> e)
        {
            e.ReturnValue = GetChatLog();
        }


        public virtual void _(Events.FieldUpdated<ChatumaticaChat.refNoteID> e)
        {

            var FoundChat = SelectFrom<AcumaticaChat>.Where<AcumaticaChat.refNoteID.IsEqual<@P.AsGuid>>.View.Select(this, e.NewValue).TopFirst;
            if(FoundChat != null)
            {
                Chats.Current = FoundChat;
                ChatumaticaChat.View.RequestRefresh();
            }
            else
            {
                AcumaticaChat chat = new AcumaticaChat();
                chat.RefNoteID = (Guid)e.NewValue;
                Chats.Insert(chat);
               

            }
        }
    }
}
