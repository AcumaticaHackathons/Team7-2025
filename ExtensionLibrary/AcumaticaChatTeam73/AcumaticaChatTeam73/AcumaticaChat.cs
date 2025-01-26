using System;
using PX.Data;
using PX.Data.BQL.Fluent;
using PX.Data.ReferentialIntegrity.Attributes;
using PX.Objects.CR;
using PX.Objects.CS;
using PX.Objects.EP;

namespace AcumaticaChatTeam7
{
    [Serializable]
    [PXCacheName("AcumaticaChat")]
    public class AcumaticaChat : PXBqlTable, IBqlTable
    {
        public const string ChatActivityType = "C";
        public class chatActivityType : PX.Data.BQL.BqlString.Constant<chatActivityType> { public chatActivityType() : base(ChatActivityType) {; } }

        public class PK : PrimaryKeyOf<AcumaticaChat>.By<chatID>
        {
            public static AcumaticaChat Find(PXGraph graph, int? ChatID) =>  FindBy(graph, ChatID);
        }



        #region ChatID
        [PXDBIdentity(IsKey = true)]
        [PXUIField(DisplayName = "Chat ID")]
        [PXSelector(typeof(AcumaticaChat.chatID))]

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

        #region RefNoteID
        [PXRefNote]
        [PXUIField(DisplayName = "Reference Item")]
       
        public virtual Guid? RefNoteID { get; set; }
        public abstract class refNoteID : PX.Data.BQL.BqlGuid.Field<refNoteID> { }
        #endregion


    }
}