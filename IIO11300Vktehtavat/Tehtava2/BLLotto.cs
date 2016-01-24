using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Tehtava2
{
    public class Lotto
    {
        private string numbers;
        private int lenght, max;
        private bool ext;

        public bool Ext
        {
            get { return ext; }
            set { ext = value; }
        }

        public int Lenght
        {
            get { return lenght; }
            set { lenght = value; }
        }

        public int Max
        {
            get { return max; }
            set { max = value; }
        }

        public string Numbers
        {
            get { return numbers; }
            set { numbers = value; }
        }

        public string CreateLotto()
        {
            int[] arr = new int[lenght];

            random(arr);

            bubbleSort(arr);

            for (int i = 0; i != arr.Length; i++)
            {
                numbers += " " + Convert.ToString(arr[i]);
            }

            if (ext == true)
            {
                lenght = 2;
                ext = false;

                numbers += " -";
                this.CreateLotto();
            }

            return numbers += "\n";
        }

        public void random(int[] arr)
        {
            Random rnd = new Random();

            for (int i = 0; i < lenght; ++i)
            {
                arr[i] = rnd.Next(1, max);
            }
        }

        public void bubbleSort(int[] arr)
        {
            bool didSwap;
            do
            {
                didSwap = false;
                for (int i = 0; i < arr.Length - 1; i++)
                {
                    if (arr[i] > arr[i + 1])
                    {
                        int temp = arr[i + 1];
                        arr[i + 1] = arr[i];
                        arr[i] = temp;
                        didSwap = true;
                    }
                }
            } while (didSwap);
        }
    }
}
