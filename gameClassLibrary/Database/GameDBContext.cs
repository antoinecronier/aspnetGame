﻿using gameClassLibrary.Models;
using gameClassLibrary.Models.Buildings.ConcretBuildings;
using gameClassLibrary.Models.Resources;
using gameClassLibrary.Models.Resources.ConcretResources;
using gameClassLibrary.Models.SolarSystems;
using gameClassLibrary.Models.Units.ConcretUnits;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Text;

namespace gameClassLibrary.Database
{
    public class GameDBContext : DbContext
    {
        /// <summary>
        /// If database .mdf file cannot attach use :
        /// sqllocaldb.exe stop
        /// sqllocaldb.exe delete
        /// sqllocaldb.exe start
        /// </summary>
        public GameDBContext()
           : base("GameConnection")
        {
            this.Database.CreateIfNotExists();
            if (!this.Database.CompatibleWithModel(false))
            {
                this.Database.Delete();
                this.Database.CreateIfNotExists();
            }
        }

        #region ConcretBuilding
        public DbSet<GoldMine> GoldMines { get; set; }
        public DbSet<House> Houses { get; set; }
        public DbSet<IronMine> IronMines { get; set; }
        public DbSet<SolarPowerPlant> SolarPowerPlants { get; set; }
        public DbSet<WaterStation> WaterStations { get; set; }
        #endregion
        #region Resources
        public DbSet<Resource> Resources { get; set; }
        #endregion
        #region SolarSystem
        public DbSet<Planet> Planets { get; set; }
        public DbSet<SolarSystem> SolarSystems { get; set; }
        #endregion
        #region Units
        public DbSet<Worker> Workers { get; set; }
        public DbSet<Medic> Medics { get; set; }
        #endregion
        #region Others
        public DbSet<Game> Games { get; set; }
        public DbSet<Level> Levels { get; set; }
        public DbSet<Player> Players { get; set; }
        #endregion
    }
}
