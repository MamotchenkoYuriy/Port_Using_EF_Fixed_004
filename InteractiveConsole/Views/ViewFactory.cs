using System;
using System.Collections.Concurrent;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Core;

namespace InteractiveConsole.Views
{
    public class ViewFactory
    {
        private static ViewFactory _viewFactory = null;
        private readonly IDictionary<string, BaseView> _dictionary = null;
        
        private ViewFactory()
        {
            _dictionary = new Dictionary<string, BaseView>
            {
                {typeof (City).Name, new CityView()},
                {typeof (Port).Name, new PortView()},
                {typeof (Captain).Name, new CaptainView()},
                {typeof (Cargo).Name, new CargoView()},
                {typeof (CargoType).Name, new CargoTypeView()},
                {typeof (Ship).Name, new ShipView()},
                {typeof (Trip).Name, new TripView()}
            };
        }

        public static ViewFactory GetInstance()
        {
            if (_viewFactory != null)
            {
                return _viewFactory;
            }
            else
            {
                _viewFactory = new ViewFactory();
                return _viewFactory;
            }
        }

        public BaseView GetView<T>()
        {
            return _dictionary[typeof(T).Name];
        }
    }
}
