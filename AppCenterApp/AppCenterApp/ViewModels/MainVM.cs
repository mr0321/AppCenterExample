﻿using AppCenterApp.Models;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.IO;
using System.Net;
using System.Text;
using System.Xml.Serialization;

namespace AppCenterApp.ViewModels
{
    public class MainVM : INotifyPropertyChanged
    {
        public Posts Blog { get; set; }

        public event PropertyChangedEventHandler PropertyChanged;

        public MainVM()
        {
            ReadRss();
        }

        public void ReadRss()
        {
            XmlSerializer serializer = new XmlSerializer(typeof(Posts));

            using (WebClient client = new WebClient())
            {
                string xml = Encoding.Default.GetString(client.DownloadData("https://cointelegraph.com/rss"));
                using (Stream reader = new MemoryStream(Encoding.UTF8.GetBytes(xml)))
                {
                    Blog = (Posts)serializer.Deserialize(reader);
                }
            }
        }

        private void OnPropertyChanged(string propertyName)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }
    }
}
