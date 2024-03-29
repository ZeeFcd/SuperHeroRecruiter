﻿using Gui4.Helpers;
using Gui4.Models;
using Gui4.Services;
using Gui4.ViewModels;
using Microsoft.Toolkit.Mvvm.Messaging;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Gui4.Logic
{
    public class SuperHeroTeamLogic : ISuperHeroTeamLogic
    {
        IList<SuperHero> superHeroes;
        IList<SuperHero> superHeroTeam;
        IMessenger messenger;
        ISuperHeroEditorService editorService;


        public SuperHeroTeamLogic(IMessenger messenger, ISuperHeroEditorService editorService)
        {
            this.messenger = messenger;
            this.editorService = editorService;
        }

        public double AVGPower
        {
            get
            {
                return Math.Round(superHeroTeam.Count == 0 ? 0 : superHeroTeam.Average(t => t.Power), 2);
            }
        }

        public double AVGSpeed
        {
            get
            {
                return Math.Round(superHeroTeam.Count == 0 ? 0 : superHeroTeam.Average(t => t.Speed), 2);
            }
        }

        public void SetupCollections(IList<SuperHero> superHeroes, IList<SuperHero> superHeroTeam)
        {
            this.superHeroes = superHeroes;
            this.superHeroTeam = superHeroTeam;
        }

        public void AddToTeam(SuperHero superHero)
        {
            superHeroTeam.Add(superHero.GetCopy());
            messenger.Send("Superhero added", "SuperHeroInfo");
        }

        public void RemoveFromTeam(SuperHero superHero)
        {
            superHeroTeam.Remove(superHero);
            messenger.Send("Superhero removed", "SuperHeroInfo");
        }

        public void CreateSuperHero()
        {

            SuperHero superHero = new SuperHero() { Type="",Power=0 ,Karma=KarmaEnum.Neutral , Speed =0, };
            editorService.Create(superHero);
            if (editorService.Closed==true)
            {
                superHeroes.Add(superHero);
                messenger.Send("Superhero created", "SuperHeroInfo");
            }
            
            
        }

        public void SaveHeroes()
        {
            string JsonData = JsonConvert.SerializeObject(superHeroes);
            File.WriteAllText("heroes.json", JsonData);
        }
    }
}
