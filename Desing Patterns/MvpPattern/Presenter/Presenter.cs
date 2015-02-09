using MvpPattern.Model;
using MvpPattern.View;
using System.Collections.Generic;

namespace MvpPattern.Presenter
{
    /// <summary>
    /// Presenter class to hadnle UI events
    /// </summary>
    public class Presenter
    {
        /// <summary>
        /// Variables for Interfaces
        /// </summary>
        IView _pView;
        IModel _pModel;

        /// <summary>
        /// Parametric constructor to intialize variables
        /// </summary>
        /// <param name="PView">Object of IView</param>
        /// <param name="PModel">Object for IModel</param>
        public Presenter(IView PView, IModel PModel)
        {
            _pView = PView;
            _pModel = PModel;
        }

        /// <summary>
        /// Method to bind the values to the controls
        /// </summary>
        public void BindModelView()
        {
            List<string> list = _pModel.setInfo();
            _pView.Label = list[0];
            _pView.TextBox = list[1];
        }
    }
}