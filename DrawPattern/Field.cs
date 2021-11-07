using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.IO;
using System.Threading.Tasks;
using DrawPattern.Exceptions;

namespace DrawPattern
{
    public class Field
    {
        protected List<List<FieldCell>> field;

        public char DefaultChar { get; set; }
        public char ActiveChar { get; set; }
        public int RowCount { get; protected set; }
        public int ColumnCount { get;protected set; }

        public Field(int rowCount, int columnCount, char defaultChar, char activeChar )
        {
            SetUp(rowCount,columnCount,defaultChar,activeChar);
        }

        protected virtual void SetUp(int rowCount, int columnCount, char defaultChar, char activeChar)
        {
            RowCount = rowCount;
            ColumnCount = columnCount;
            DefaultChar = defaultChar;
            ActiveChar = activeChar;

            field = new List<List<FieldCell>>(RowCount);
            for (int i = 0; i < RowCount; i++)
            {
                field.Add(new List<FieldCell>(ColumnCount));
                for (int j = 0; j < ColumnCount; j++)
                {
                    field[i].Add(new FieldCell(DefaultChar));
                }
            }

        }
        public virtual FieldCell this[int i, int j]
        {
            get
            {
                return field[i][j];
            }
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
