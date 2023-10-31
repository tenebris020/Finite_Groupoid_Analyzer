using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace End_Group_Analyzer
{
    internal class PropertiesFe
    {
        int[,] mass;
        List<int> univ;
        public PropertiesFe(int[,] mass, List<int> univ)
        {
            this.mass = mass;
            this.univ = univ;
        }
        public bool Isolation() //замкнутость
        {
            for (int i = 0; i < univ.Count; i++)
            {
                for (int j = 0; j < univ.Count; j++)
                {
                    if (!(univ.Contains(mass[i, j]))) { return false; }
                }
            }
            return true;
        }
        public bool Associativity() //ассоциативность
        {
            for (int i = 0; i < univ.Count; i++)
            {
                for (int j = 0; j < univ.Count; j++)
                {
                    for (int k = 0; k < univ.Count; k++)
                    {
                        try
                        {
                            if (!(mass[i, mass[j, k]] == mass[mass[i, j], k])) { return false; }
                        }
                        catch (Exception) { return false; }
                    }
                }
            }
            return true;
        }
        public bool Commutativity() //коммунитативность
        {
            for (int i = 0; i < univ.Count; i++)
            {
                for (int j = 0; j < univ.Count; j++)
                {
                    if (!(mass[i, j] == mass[j, i])) { return false; }
                }
            }
            return true;
        }
        public bool Idempotency() //иденпотентность
        {
            for (int i = 0; i < univ.Count; i++)
            {
                if (mass[i, i] != i) { return false; }
            }
            return true;
        }
        public int NE() //нейтральный элемент
        {
            bool flag;
            for (int i = 0; i < univ.Count; i++)
            {
                flag = true;
                for (int j = 0; j < (i + 1); j++)
                {
                    if (!(mass[i, j] == univ[j])) { flag = false; break; }
                    if (!(mass[j, i] == univ[j])) { flag = false; break; }
                }
                if (flag) { return mass[i, i]; }
            }
            return univ.Count;
        }
        public bool Solvability() //разрешимость
        {
            List<int> row = new List<int>();
            for (int i = 0; i < univ.Count; i++)
            {
                for (int j = 0; j < univ.Count; j++)
                {
                    row.Add(mass[i, j]);
                }
                row.Sort();
                for (int k = 0; k < row.Count; k++)
                {
                    if (!(row[k] == univ[k])) { return false; }
                }
                row.Clear();
            }
            return true;
        }
        public bool Reversibility(int e)//обратимость
        {
            bool flag;

            //строки
            for (int i = 0; i < univ.Count; i++)
            {
                flag = false;
                for (int j = 0; j < univ.Count; j++)
                {
                    if (mass[i, j] == e) { flag = true; break; }
                }
                if (flag == false) { return false; }
            }

            //столбцы
            for (int i = 0; i < univ.Count; i++)
            {
                flag = false;
                for (int j = 0; j < univ.Count; j++)
                {
                    if (mass[j, i] == e) { flag = true; break; }
                }
                if (flag == false) { return false; }
            }
            return true;
        }
    }
}
