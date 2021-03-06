﻿using System;

namespace Kira.Genealogy.Model.Base.Contracts
{
    public interface IBaseAuditable
    {
        string CreatedBy { get; set; }
        DateTime CreationDate { get; set; }
        string LastModifiedBy { get; set; }
        DateTime LastModificationDate { get; set; }
        string DeletedBy { get; set; }
        DateTime? DeletionDate { get; set; }
        bool Enabled { get; set; }
    }
}
