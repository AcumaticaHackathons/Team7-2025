using System;
using PX.Data;
using PX.Data.ReferentialIntegrity.Attributes;
using PX.Objects.SO;

namespace AcumaticaChatTeam7
{
    [Serializable]
    [PXCacheName("AcumaticaChatMember")]
    public class SOChatMember : PXBqlTable, IBqlTable
    {

        #region OrderType
        public abstract class orderType : PX.Data.BQL.BqlString.Field<orderType> { }
        protected String _OrderType;
        [PXDBString(2,  IsFixed = true)]
        [PXDBDefault(typeof(SOOrder.orderType))]
        [PXUIField(DisplayName = "Order Type", Visible = false, Enabled = false)]
        [PXSelector(typeof(Search<SOOrderType.orderType>), CacheGlobal = true)]
        public virtual String OrderType
        {
            get
            {
                return this._OrderType;
            }
            set
            {
                this._OrderType = value;
            }
        }
        #endregion
        #region OrderNbr
        public abstract class orderNbr : PX.Data.BQL.BqlString.Field<orderNbr> { }
        protected String _OrderNbr;
        [PXDBString(15, IsUnicode = true,  InputMask = "")]
        [PXDBDefault(typeof(SOOrder.orderNbr), DefaultForUpdate = false)]
        [PXUIField(DisplayName = "Order Nbr.", Visible = false, Enabled = false)]
        public virtual String OrderNbr
        {
            get
            {
                return this._OrderNbr;
            }
            set
            {
                this._OrderNbr = value;
            }
        }
        #endregion
        #region ChatMemberID
        [PXDBIdentity(IsKey = true)]
        public virtual int? ChatMemberID { get; set; }
        public abstract class chatMemberID : PX.Data.BQL.BqlInt.Field<chatMemberID> { }
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


        #region UserID
        [PXSelector(typeof(PX.SM.Users.pKID), SubstituteKey = typeof(PX.SM.Users.displayName))]
        [PXDBGuid]
        [PXUIField(DisplayName = "Chat Member")]
        public virtual Guid? UserID { get; set; }
        public abstract class userID : PX.Data.BQL.BqlGuid.Field<userID> { }
        #endregion
    }
}