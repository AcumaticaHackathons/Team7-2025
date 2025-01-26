using PX.Data;
using PX.Objects.CR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AcumaticaChatTeam7
{
    public class ChatumaticaChat : PXBqlTable, IBqlTable
    {


        #region Message 
        [PXDBString]
        [PXUIField(DisplayName = "Message")]
        public virtual String Message { get; set; }
        public abstract class message : PX.Data.BQL.BqlString.Field<message> { }
        #endregion

        #region ChatLog 
        [PXDBString]
        [PXUIField(DisplayName = "Chat Log")]
        public virtual String ChatLog { get; set; }
        public abstract class chatLog : PX.Data.BQL.BqlString.Field<chatLog> { }
        #endregion




        #region RefNoteID
        public abstract class refNoteID : PX.Data.BQL.BqlGuid.Field<refNoteID> { }

        /// <summary>
        /// Contains the <see cref="INotable.NoteID"/> value of the related entity.
        /// This activity is displayed on the <b>Activities</b> tab of the entity's form.
        /// </summary>
        /// <remarks>The related document may or may not implement the <see cref="INotable"/> interface,
        /// but it must have a field marked with the <see cref="PXNoteAttribute"/> attribute
        /// with the <see cref="PXNoteAttribute.ShowInReferenceSelector"/> property set to <see langword="true"/>.
        /// </remarks>
        //[PXSelector(typeof(Note.noteID), SubstituteKey = typeof(Note.entityName))]
        [PXRefNote]
        [PXUIField(DisplayName = "Related Entity")]
        public virtual Guid? RefNoteID { get; set; }
        #endregion
    }
}
