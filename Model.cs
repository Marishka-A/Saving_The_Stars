using System;
using System.Collections.Generic;
using System.Linq;
using System.Numerics;
using System.Text;
using System.Threading.Tasks;

namespace Saving_The_Stars
{
    public class Model
    {
        public Point PlayerLocation;
        public Point EnemyLocation;
        public Point[] StarsLocation;
        public Player? PlayerInGame;
        //public List<Star>? StarsStart;
        public List<Star>? StarsEnd;
        public Enemy? Enemy;
        public Model() 
        { 
            PlayerLocation = new Point() { X = 0, Y = 600 };
            EnemyLocation = new Point() { X = 1100, Y = 500 };
            StarsLocation = new Point[3] { new Point(400, 600), new Point(600, 600), new Point(800, 600) };
            PlayerInGame = null;
            StarsEnd = new List<Star>();
            Enemy = null;
        }

        public void SpawnPlayerInGame(Model player)
        {
            PlayerInGame.Position = player.PlayerLocation;
        }
        
    }
}
