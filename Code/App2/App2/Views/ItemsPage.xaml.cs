﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

using app2.core.Models;
using App2.Views;
using App2.ViewModels;

namespace App2.Views
{
  public partial class ItemsPage : ContentPage
  {
    ItemsViewModel viewModel;

    public ItemsPage()
    {
      InitializeComponent();

      BindingContext = viewModel = new ItemsViewModel();
    }

    async void OnItemSelected(object sender, SelectedItemChangedEventArgs args)
    {
      var item = args.SelectedItem as Item;
      if (item == null)
        return;

      await Navigation.PushAsync(new ItemDetailPage(new ItemDetailViewModel(item)));

      // Manually deselect item.
      ItemsListView.SelectedItem = null;
    }

    async void AddItem_Clicked(object sender, EventArgs e)
    {
      await Navigation.PushModalAsync(new NavigationPage(new NewItemPage()));
    }

    protected override void OnAppearing()
    {
      base.OnAppearing();

      if (viewModel.Items.Count == 0)
        viewModel.LoadItemsCommand.Execute(null);
    }
  }
}