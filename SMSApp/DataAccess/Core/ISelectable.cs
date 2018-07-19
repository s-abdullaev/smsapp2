namespace SMSApp.DataAccess.Core
{
    public interface ISelectable
    {
        /// <summary>
        /// Indicates that the item can be selected
        /// </summary>
        bool IsSelected { set; get; }
    }
}
