using System;


namespace BookManagement.DBModels
{
    public class BaseModel
    {

        #region Meta Properties

        public bool IsActive { get; set; }

        public string CreatedBy { get; set; }

        public DateTime? CreatedTimeStamp { get; set; }

        public string UpdatedBy { get; set; }

        public DateTime? UpdatedTimeStamp { get; set; }

        #endregion

        #region Methods

        public virtual void REMOVE(string userId = "")
        {
            DateTime now = DateTime.UtcNow;
            this.UpdatedBy = userId;
            this.UpdatedTimeStamp = now;
            this.IsActive = false;
        }

        public virtual void ADD(string userId = "")
        {
            DateTime now = DateTime.UtcNow;
            this.CreatedBy = userId;
            this.CreatedTimeStamp = now;
            this.UpdatedBy = userId;
            this.UpdatedTimeStamp = now;
            this.IsActive = true;
        }

        public virtual void ISSUE(string userId = "")
        {
            DateTime now = DateTime.UtcNow;
            this.UpdatedBy = userId;
            this.UpdatedTimeStamp = now;
            this.IsActive = true;
        }

        #endregion
    }
}
