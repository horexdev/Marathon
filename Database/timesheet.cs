//------------------------------------------------------------------------------
// <auto-generated>
//     Этот код создан по шаблону.
//
//     Изменения, вносимые в этот файл вручную, могут привести к непредвиденной работе приложения.
//     Изменения, вносимые в этот файл вручную, будут перезаписаны при повторном создании кода.
// </auto-generated>
//------------------------------------------------------------------------------

namespace Marafon.Database
{
    using System;
    using System.Collections.Generic;
    
    public partial class timesheet
    {
        public int TimesheetId { get; set; }
        public int StaffId { get; set; }
        public System.DateTime StartDateTime { get; set; }
        public System.DateTime EndDateTime { get; set; }
        public int PayAmount { get; set; }
    
        public virtual staff staff { get; set; }
    }
}
