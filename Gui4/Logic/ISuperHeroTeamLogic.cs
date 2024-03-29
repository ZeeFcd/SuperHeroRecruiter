﻿using Gui4.Models;
using System.Collections.Generic;

namespace Gui4.Logic
{
    public interface ISuperHeroTeamLogic
    {
        double AVGPower { get; }
        double AVGSpeed { get; }

        void AddToTeam(SuperHero superHero);
        void RemoveFromTeam(SuperHero superHero);
        void CreateSuperHero();
        void SetupCollections(IList<SuperHero> superHeroes, IList<SuperHero> superHeroTeam);
        void SaveHeroes();
    }
}