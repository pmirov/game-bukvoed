using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WinFormsApp12
{
    internal class GeneratorButtons
    {
        public static List<Button> Create(int count, int row)
        {
            int width = 50;
            int height = 50;
            int horizontal = 0;
            int vertical = 0;
            List<Button> list = new List<Button>(count);
            for (int i = 0; i < count; i++)
            {

                if (i != 0 && i % row == 0)
                {
                    vertical += height;
                    horizontal = 0;
                }

                Button button = new Button();
                button.Width = width;
                button.Height = height;
                button.Location = new Point(horizontal, vertical);
                horizontal += width;
                list.Add(button);


            }
            return list;
        }

    }
}
