using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;


namespace GraphDiplom
{
    public static class BaseUtils {}

    // задаем тип данных Vec2 (Вектор 2) 
    // который содержит два любых значения, доступные по обращению
    // имя_переменной_Vec2.x и имя_переменной_Vec2.y
    public class Vec2
    {
        public dynamic x;
        public dynamic y;//  get set

        public Vec2(dynamic x, dynamic y)
        {
            this.x = x;
            this.y = y;
        }
    }

    // всяческие простые математические методы
    public static class FastMath
    {
        // матем. знаки и обозначение
        public enum SYMBOLS
        {
            DASH,    // тире
            INF,     // бесконечность
            UNKNOWN, // не заданное значение
            REMOVED  // удаленное значение, нужно для неподходящих узлов в алгоритме Ф-Ф
        }

        public static Random rand = new Random();

        // этот метод рассчитывает дистанцию между точками
        // дополнительные переменные onlyX и onlyY позволяют найти расстояние только
        // по горизонтали или вертикали 
        public static int calculateDist(Vec2 pos1, Vec2 pos2, bool onlyX = false, bool onlyY = false)
        {
            int dist;

            if (onlyX)
                dist = (int) Math.Sqrt(Math.Pow(pos2.x - pos1.x, 2));
            else if (onlyY)
                dist = (int) Math.Sqrt(Math.Pow(pos2.y - pos1.y, 2));
            else
                dist = (int) Math.Sqrt(Math.Pow(pos2.x - pos1.x, 2) + Math.Pow(pos2.y - pos1.y, 2));

            return dist;
        }

        // этот метод генерирует случайное число в указанном диапазоне
        public static int genRandom(int from, int to)
        {
            int genNumber = rand.Next(from, to);
            return genNumber;
        }
    }
}
