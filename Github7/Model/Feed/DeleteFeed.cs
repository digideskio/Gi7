﻿using System;
using System.Net;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Documents;
using System.Windows.Ink;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Animation;
using System.Windows.Shapes;

namespace Github7.Model.Feed
{
    public class DeleteFeed : Feed
    {
        public String RefType { get; set; }
        public String Ref { get; set; }

        public override String Template
        {
            get
            {
                return String.Format("deleted branch {0} at", Ref);
            }
        }

        public override String Image
        {
            get
            {
                return "/Github7;component/Images/delete.png";
            }
        }
    }
}