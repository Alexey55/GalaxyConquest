﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Drawing;

namespace GalaxyConquest.Tactics
{
    public abstract class SpaceObject
    {
        public int objectType; // подробности смотри в константах
        public int player; // 0,1,2 ..0 - нейтральные объекты 
        public int boxId; // ячейка, в которой находится
        public int maxHealth; // hit points
        public int currentHealth;
        public abstract string description(); // описание объекта
        public Image objectImg;
        public Image baseObjectImg;
        public int x;
        public int y;

        public abstract void drawSpaceShit(ref combatMap cMap, ref System.Drawing.Bitmap bmap);
        public abstract void statusRefresh(ref Bitmap bmBg, ref Bitmap bmFull);

        public List<int> xpoints = new List<int>();  // координаты 5 точек, описывающих внешний вид объекта
        public List<int> ypoints = new List<int>();  // вообще, по сути надо каждый типа корабля сделать классом, тогда 
                                                     // можно будет внешний вид задавать прямо здесь, массивом Point[]

        public int maxActions; // максимальное количество действий на одном ходу
        public int actionsLeft; // оставшееся количество действий
    }
}
