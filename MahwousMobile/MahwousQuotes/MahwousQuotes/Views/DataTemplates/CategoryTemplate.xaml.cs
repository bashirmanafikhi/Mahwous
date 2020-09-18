﻿using MahwousQuotes.ViewModels;
using MahwousWeb.Shared.Filters;
using MahwousWeb.Shared.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace MahwousQuotes.Views.DataTemplates
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class CategoryTemplate : ContentView
    {
        public CategoryTemplate()
        {
            InitializeComponent();
        }



        async void OnItemSelected(object sender, EventArgs args)
        {
            var layout = (BindableObject)sender;
            var viewModel = (CategoryViewModel)layout.BindingContext;
            var category = viewModel.Category;

            await Navigation.PushAsync(new CategoryDetailsPage(viewModel));
        }
    }
}