﻿using Gui4.Models;
using Microsoft.Toolkit.Mvvm.ComponentModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;

namespace Gui4.ViewModels
{
    public class CreateSuperHeroViewModel : ObservableRecipient
    {
        public SuperHero Actual { get; set; }
        
        public void Setup(SuperHero superHero)
        {
            this.Actual = superHero;
        }


        public CreateSuperHeroViewModel()
        {
            

        }

    }
}
