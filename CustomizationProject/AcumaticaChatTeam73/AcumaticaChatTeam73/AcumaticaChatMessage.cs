using System;
using PX.Data;
using PX.Data.ReferentialIntegrity.Attributes;
using PX.Objects.CR;

namespace AcumaticaChatTeam7
{
    [Serializable]
    [PXCacheName("AcumaticaChatMessage")]
    public class AcumaticaChatMessage : PXBqlTable, IBqlTable
    {
        public static class FK
        {
            public class Chat : AcumaticaChat.PK.ForeignKeyOf<AcumaticaChatMessage>.By<chatID> { }
        }
        #region ChatMessageID
        [PXDBIdentity(IsKey = true)]
        public virtual int? ChatMessageID { get; set; }
        public abstract class chatMessageID : PX.Data.BQL.BqlInt.Field<chatMessageID> { }
        #endregion

        #region ChatID
        [PXDBInt]
        [PXUIField(DisplayName = "Chat ID")]
        [PXSelector(typeof(AcumaticaChat.chatID))]
        [PXDBDefault(typeof(AcumaticaChat.chatID))]
        [PXParent(typeof(FK.Chat))]
        public virtual int? ChatID { get; set; }
        public abstract class chatID : PX.Data.BQL.BqlInt.Field<chatID> { }
        #endregion

        #region CreatedByID
        [PXDBCreatedByID()]
        public virtual Guid? CreatedByID { get; set; }
        public abstract class createdByID : PX.Data.BQL.BqlGuid.Field<createdByID> { }
        #endregion

        #region CreatedByScreenID
        [PXDBCreatedByScreenID()]
        public virtual string CreatedByScreenID { get; set; }
        public abstract class createdByScreenID : PX.Data.BQL.BqlString.Field<createdByScreenID> { }
        #endregion

        #region CreatedDateTime
        [PXUIField(DisplayName = "Created On")]
        [PXDBCreatedDateTime]
        public virtual DateTime? CreatedDateTime { get; set; }
        public abstract class createdDateTime : PX.Data.BQL.BqlDateTime.Field<createdDateTime> { }
        #endregion

        #region LastModifiedByID
        [PXDBLastModifiedByID()]
        public virtual Guid? LastModifiedByID { get; set; }
        public abstract class lastModifiedByID : PX.Data.BQL.BqlGuid.Field<lastModifiedByID> { }
        #endregion

        #region LastModifiedByScreenID
        [PXDBLastModifiedByScreenID()]
        public virtual string LastModifiedByScreenID { get; set; }
        public abstract class lastModifiedByScreenID : PX.Data.BQL.BqlString.Field<lastModifiedByScreenID> { }
        #endregion

        #region LastModifiedDateTime
        [PXDBLastModifiedDateTime]
        [PXUIField(DisplayName = "Modified On")]
        public virtual DateTime? LastModifiedDateTime { get; set; }
        public abstract class lastModifiedDateTime : PX.Data.BQL.BqlDateTime.Field<lastModifiedDateTime> { }
        #endregion

        #region Noteid
        [PXNote()]
        public virtual Guid? Noteid { get; set; }
        public abstract class noteid : PX.Data.BQL.BqlGuid.Field<noteid> { }
        #endregion

        #region Tstamp
        [PXDBTimestamp()]
        [PXUIField(DisplayName = "Tstamp")]
        public virtual byte[] Tstamp { get; set; }
        public abstract class tstamp : PX.Data.BQL.BqlByteArray.Field<tstamp> { }
        #endregion

        #region Message
        [PXDBString(IsUnicode = true, InputMask = "")]
        [PXUIField(DisplayName = "Message")]
        public virtual string Message { get; set; }
        public abstract class message : PX.Data.BQL.BqlString.Field<message> { }
        #endregion

        #region SendNotification
        [PXDBBool()]
        [PXDefault(false)]
        [PXUIField(DisplayName = "Send Notification")]
        public virtual bool? SendNotification { get; set; }
        public abstract class sendNotification : PX.Data.BQL.BqlBool.Field<sendNotification> { }
        #endregion
    }
}