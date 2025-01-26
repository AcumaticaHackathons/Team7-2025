using System;
using PX.Data;
using PX.Data.ReferentialIntegrity.Attributes;
using PX.Objects.CR;

namespace AcumaticaChatTeam7
{
    [Serializable]
    [PXCacheName("AcumaticaChatMember")]
    public class AcumaticaChatMember : PXBqlTable, IBqlTable
    {
        public static class FK
        {
            public class Chat : AcumaticaChat.PK.ForeignKeyOf<AcumaticaChatMember>.By<chatID> { }
        }
        #region ChatMemberID
        [PXDBIdentity(IsKey = true)]
        public virtual int? ChatMemberID { get; set; }
        public abstract class chatMemberID : PX.Data.BQL.BqlInt.Field<chatMemberID> { }
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
        [PXDBCreatedDateTime]
        [PXUIField(DisplayName = "Created On")]
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


        #region Userid
        [PXSelector(typeof(PX.SM.Users.pKID), SubstituteKey = typeof(PX.SM.Users.displayName))]

        [PXDBGuid]
        [PXUIField(DisplayName = "Chat Member")]
        public virtual Guid? Userid { get; set; }
        public abstract class userid : PX.Data.BQL.BqlGuid.Field<userid> { }
        #endregion
    }
}