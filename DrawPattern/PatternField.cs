using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.IO;
using System.Threading.Tasks;
using DrawPattern.Exceptions;

namespace DrawPattern
{
    public class PatternField
    {
        List<List<char>> field;

        public char DefaultChar { get; set; }

        public PatternField(int width, int height, char defaultChar )
        {
            field = new List<List<char>>(height);
            for (int i = 0; i < height; i++)
            {
                field.Add(new List<char>(width));
                for (int j = 0; j < width; j++)
                {
                    field[i].Add(defaultChar);
                }
            }

            DefaultChar = defaultChar;
        }


        public void Set(int i, int j, char c)
        {
            try
            {
                field[i][j] = c;
            }
            catch (IndexOutOfRangeException ex)
            {
                throw new FieldIndexOutOfRangeException("Значение индекса за пределами диапазона размеров поля", ex, i, j);
            }
            catch (Exception ex)
            {
                throw new FieldIndexOutOfRangeException("Ошибка доступа клетке поля", ex, i, j);
            }
        }

        public void AddRows(int count=1)
        {
            try
            {

                int tempCount = field.Last().Count();
                for (int i = 0; i < count; i++)
                {
                    field.Add(new List<char>(tempCount));
                    for (int j = 0; j < tempCount; j++)
                    {
                        field.Last().Add(DefaultChar);
                    }
                }
            }
            catch (Exception ex)
            {
                throw new BaseException("Ошибка добавления строк в поле", ex);
            }
        }

        public void AddColumns(int count=1)
        {
            try
            {
                foreach (var list in field)
                {
                    list.Capacity += count;
                    for (int i = 0; i < count; i++)
                    {
                        list.Add(DefaultChar);
                    }
                }
            }
            catch (Exception ex)
            {
                throw new BaseException("Ошибка добавления стобцов в поле", ex);
            }
        }

        public void DeleteRows(int count=1)
        {
            if (field.Count - count < 1)
            {
                throw new BaseException("Удаление строки невозможно, количество удаляемых строк больше или равно количеству строк в поле");
            }
            try
            {
                field.RemoveRange(field.Count-1 - count, count);

            }
            catch (Exception ex)
            {

                throw new BaseException("Ошибка удаления строк в поле", ex);
            }
        }

        public void DeleteColumns(int count=1)
        {
            if (field[0].Count - count < 1)
            {
                throw new BaseException("Удаление столбца невозможно, количество удаляемых столбцов больше или равно количеству столбцов в поле");
            }
            try
            {
                foreach (var list in field)
                {
                    list.RemoveRange(field.Count -1 - count, count);
                }
            }
            catch (Exception ex)
            {

                throw new BaseException("Ошибка удаления строк в поле", ex);
            }
        }
        public void PrintToFile(string filename)
        {
            try
            {
                using (StreamWriter sw = new StreamWriter(filename, false))
                {
                    foreach (var l in field)
                    {
                        sw.WriteLine(string.Join("", l));
                    }
                }
            }
            catch (Exception ex)
            {
                throw new BaseException("Ошибка записи поля в файл", ex);
            }
        }
    }
}
