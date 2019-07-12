using EFCoreDatabase;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Runtime.CompilerServices;
using System.Text;
using System.Windows.Input;
using Xamarin.Forms;

namespace EFCoreWithSQLite
{
    public class ProductViewModel : INotifyPropertyChanged
    {

        public event PropertyChangedEventHandler PropertyChanged;
        private readonly IProductRepository productRepository;
        private IEnumerable<Product> _products;
        public ProductViewModel(IProductRepository productRepository)
        {
            this.productRepository = productRepository;
        }


        public IEnumerable<Product> Products
        {
            get
            {
                return _products;
            }
            set
            {
                _products = value;
                OnPropertyChanged();
            }
        }


        public double ProductPrice { get; set; }

        public string ProductTitle { get; set; }

        public ICommand RefreshCommand
        {
            get
            {
                return new Command(async () => { Products = await productRepository.GetProductsAsync(); });
            }
        }


        public ICommand AddCommand
        {
            get
            {
                return new Command(async () =>
                {
                    var p = new Product()
                    {
                        Title = ProductTitle,
                        Price = ProductPrice
                    };
                    await productRepository.AddProductAsync(p);
                });
            }
        }

        protected virtual void OnPropertyChanged([CallerMemberName] string propertyname = null)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyname));
        }
    }
}