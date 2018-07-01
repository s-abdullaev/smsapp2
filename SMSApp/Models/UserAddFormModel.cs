using System;
using Prism.Mvvm;

namespace SMSApp.Models
{
    public class UserAddFormModel : BindableBase
    {
        private string name;
        private string login;
        private string password;
        private string email;
        private bool canUpdateUsers;
        private bool canReadEntities;
        private bool canUpdateEntities;
        private bool canSendBroadcasts;
        private bool canPrintReports;

        public String Name
        {
            get
            {
                return name;
            }
            set
            {
                SetProperty(ref name, value);
            }
        }
        public String Login
        {
            get
            {
                return login;
            }
            set
            {
                SetProperty(ref login, value);
            }
        }
        public String Password
        {
            get
            {
                return password;
            }
            set
            {
                SetProperty(ref password, value);
            }
        }
        public String Email
        {
            get
            {
                return email;
            }
            set
            {
                SetProperty(ref email, value);
            }
        }
        public bool CanUpdateUsers { get => canUpdateUsers; set => SetProperty(ref canUpdateUsers, value); }
        public bool CanReadEntities { get => canReadEntities; set => SetProperty(ref canReadEntities, value); }
        public bool CanUpdateEntities { get => canUpdateEntities; set => SetProperty(ref canUpdateEntities, value); }
        public bool CanSendBroadcasts { get => canSendBroadcasts; set => SetProperty(ref canSendBroadcasts, value); }
        public bool CanPrintReports { get => canPrintReports; set => SetProperty(ref canPrintReports, value); }

        public int GetPermissions()
        {
            int bitmask = 0;
            if (canUpdateUsers)
                bitmask += (int) Math.Pow(2, 0);
            if (canReadEntities)
                bitmask += (int)Math.Pow(2, 1);
            if (canUpdateEntities)
                bitmask += (int)Math.Pow(2, 2);
            if (canSendBroadcasts)
                bitmask += (int)Math.Pow(2, 3);
            if (canPrintReports)
                bitmask += (int)Math.Pow(2, 4);
            return bitmask;
        }
    }
}