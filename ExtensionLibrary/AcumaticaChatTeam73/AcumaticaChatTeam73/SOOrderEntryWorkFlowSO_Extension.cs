using PX.Data;
using PX.SM;
using System;
using PX.Objects.SO;
using PX.Objects.CR;
using PX.Objects.AR;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using PX.Objects.GL;
using PX.Objects.CA;
using PX.Objects.IN;
using PX.Data.BQL.Fluent;
using PX.Data.BQL;
using PX.Data.WorkflowAPI;
using PX.Objects.SO.GraphExtensions.SOOrderEntryExt;
using PX.Objects.Extensions.CustomerCreditHold;
using PX.Objects.SO.GraphExtensions;
using System.Text;
using PX.Objects.CS;
using PX.Objects.SO.Workflow.SalesOrder;
using PX.Objects.GDPR;

namespace AcumaticaChatTeam7
{
    using static BoundedTo<SOOrderEntry, SOOrder>;
    using static PX.Objects.SO.SOOrder;
    using State = SOOrderStatus;


    //find the code that generates the configuration and override that. In this case, it is the base screen configuration for SOOrderEntry.
    public class SOOrderEntryWorkFlowSO_Extension : PXGraphExtension<PX.Objects.SO.Workflow.SalesOrder.SOOrderEntry_ApprovalWorkflow, SOOrderEntry_Workflow, SOOrderEntry>
    {
     
        public override void Configure(PXScreenConfiguration config) => Configure(config.GetScreenConfigurationContext<SOOrderEntry, SOOrder>());

        public virtual void Configure(WorkflowContext<SOOrderEntry, SOOrder> context)
        {



            context.UpdateScreenConfigurationFor(screen =>
            {
                return screen.WithActions(actions =>
                {
                    actions.AddNew("ChatUmatica", a =>
                            a.DisplayName("ChatUmatica")
                            .IsSidePanelScreen(sp =>
                            sp.NavigateToScreen("AC999999")
                                .WithIcon("details")
                                .WithAssignments(ass =>
                                    ass.Add("RefNoteID", e => e.SetFromField<SOOrder.noteID>()))
                                ));
               
                })
                ;
            });
        }




    }

}