using ShopList.Gui.Models;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Windows.Input;

namespace ShopList.Gui.ViewModels

{

    public class ShopListViewModel : INotifyPropertyChanged

    {

        private string _NombreDelArticulo = string.Empty;

        private int _Cantidad = 1;

        public event PropertyChangedEventHandler? PropertyChanged;

        public string NombreDelArticulo

        {

            get => _NombreDelArticulo;

            set

            {

                if (_NombreDelArticulo != value)

                {

                    _NombreDelArticulo = value;

                    OnPropertyChanged(nameof(NombreDelArticulo));

                }

            }

        }

        public int Cantidad

        {

            get => _Cantidad;

            set

            {

                if (_Cantidad != value)

                {

                    _Cantidad = value;

                    OnPropertyChanged(nameof(Cantidad));

                }

            }

        }

        public ObservableCollection<ShopListItem> ShopList { get; }

        public ICommand AddShopListItemsCommand { get; private set; }

        public ShopListViewModel()

        {

            ShopList = new ObservableCollection<ShopListItem>();

            CargarDatos();

            AddShopListItemsCommand = new Command(AddShopListItem);

        }

        public void AddShopListItem()

        {

            if (string.IsNullOrEmpty(NombreDelArticulo) || Cantidad <= 0)

            {

                return;

            }

            Random generador = new Random();

            var item = new ShopListItem()

            {

                Id = generador.Next(),

                Nombre = NombreDelArticulo,

                Cantidad = this.Cantidad,

                Comprado = false

            };

            ShopList.Add(item);

            NombreDelArticulo = string.Empty;

            Cantidad = 1;

        }

        private void CargarDatos()

        {

            ShopList.Add(new ShopListItem()

            {

                Id = 1,

                Nombre = "Pan de caja",

                Cantidad = 1,

                Comprado = false,

            });

            ShopList.Add(new ShopListItem()

            {

                Id = 2,

                Nombre = "Leche",

                Cantidad = 3,

                Comprado = false,

            });

            ShopList.Add(new ShopListItem()

            {

                Id = 3,

                Nombre = "Queso",

                Cantidad = 100,

                Comprado = false,

            });

        }

        private void OnPropertyChanged(string propertyName)

        {

            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));

        }

    }

}

