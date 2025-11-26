using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using ShopList.Gui.Models;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Windows.Input;

namespace ShopList.Gui.ViewModels
{
    public partial class ShopListViewModel : ObservableObject
    {
        [ObservableProperty]
        private string _NombreDelArticulo = string.Empty;
        [ObservableProperty]
        private int _Cantidad = 1;
        [ObservableProperty]
        private ShopListItem? _elementoSeleccionado = null;

        public ObservableCollection<ShopListItem> ShopList { get; }

        public ShopListViewModel()
        {
            ShopList = new ObservableCollection<ShopListItem>();
            CargarDatos();
            if (ShopList.Count > 0)
            {
                ElementoSeleccionado = ShopList[0];
            }
            else
            {
                ElementoSeleccionado = null;
            }

        }
        [RelayCommand]
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
            ElementoSeleccionado = item;
            NombreDelArticulo = string.Empty;
            Cantidad = 1;
        }
        [RelayCommand]
        public void RemoveShopListItem()
        {
            if (ElementoSeleccionado == null)
            {
                return;
            }
            ShopListItem? nuevoElementoSeleccionado;
            int indice = ShopList.IndexOf(ElementoSeleccionado);
            if (ShopList.Count > 1)
            {
                if (indice == ShopList.Count - 1)
                {
                    nuevoElementoSeleccionado = ShopList[indice - 1];
                }
                else
                {
                    nuevoElementoSeleccionado = ShopList[indice + 1];
                }
            }
            else
            {
                nuevoElementoSeleccionado = null;
            }
            ShopList.Remove(ElementoSeleccionado);
            ElementoSeleccionado = nuevoElementoSeleccionado;
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
    }
}