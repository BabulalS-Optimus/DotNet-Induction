
namespace MvpPattern.View
{
    /// <summary>
    /// Interface for View
    /// </summary>
    public interface IView
    {
        /// <summary>
        /// Attributes to hold ID for controls to be accessed
        /// </summary>
        string Label { get; set; }
        string TextBox { get; set; }
    }
}
