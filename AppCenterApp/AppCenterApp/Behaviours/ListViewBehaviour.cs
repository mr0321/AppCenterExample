﻿using AppCenterApp.Models;
using AppCenterApp.Views;
using System;
using System.Collections.Generic;
using System.Text;
using Xamarin.Forms;

namespace AppCenterApp.Behaviours
{
    public class ListViewBehaviour : Behavior<ListView>
    {
        ListView listView;

        protected override void OnAttachedTo(ListView bindable)
        {
            base.OnAttachedTo(bindable);

            listView = bindable;
            listView.ItemSelected += ListView_ItemSelected;
        }

        void ListView_ItemSelected(object sender, SelectedItemChangedEventArgs e)
        {
            Item selectedItem = (listView.SelectedItem) as Item;
            Application.Current.MainPage.Navigation.PushAsync(new PostsPage(selectedItem));
        }

        protected override void OnDetachingFrom(ListView bindable)
        {
            base.OnDetachingFrom(bindable);
            listView.ItemSelected -= ListView_ItemSelected;
        }
    }
}
