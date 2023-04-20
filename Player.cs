using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Saving_The_Stars
{
    public class Player
    {
        public static Keys KeyPressed;
        public int Health;
        public Fight Damage;
        public int Mana;
        public int manaForQ;
        public PictureBox? Picture;
        public Point Position;
        public Player(int health, int damage, int mana, int manaForQ, Point position, Image image)
        {
            Health = health;
            Damage = DamageOfPlayer(mana, manaForQ);
            Mana = mana;
            Picture = new PictureBox()
            {
                Left = position.X,
                Top = position.Y,
                Image = image,
                Bounds = new Rectangle(position, new Size(160, 160)),
                BackColor = Color.Transparent
            };
            Position = position;
        }
        public Fight DamageOfPlayer(int mana, int manaForQ)
        {
            if (KeyPressed == Keys.R) return new Fight { Power = 10 };
            if (KeyPressed == Keys.E && mana >= 15) return new Fight { Power = 25, ManaForQ = manaForQ + 25 };
            if (KeyPressed == Keys.Q && manaForQ >= 100) return new Fight { Power = 100 };
            return new Fight { Power = 0, ManaForQ = 0 };
        }

        public void MoveTo(Player player, int dx, int dy)
        {
            if (dx != 0) player.Position = new Point(player.Position.X + dx, player.Position.Y);
            if (dy != 0) player.Position = new Point(player.Position.X, player.Position.Y + dy);
        }

        //public int Mana(object obj, int mana)
        //{
        //    if (obj is Star) mana += 5;
        //    return mana;
        //}
        //public static int FindMana()
        //{
        //    throw new NotImplementedException();
        //}
        //public static int DamageInGame(int mana, int enemyHealth)
        //{
        //    throw new NotImplementedException();
        //}
    }
}
