using PlayStore.BLL.DTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Excel = Microsoft.Office.Interop.Excel;
using Microsoft.VisualBasic;
using System.IO;

namespace PlayStore.Models
{
    class ExcelParser
    {
        private static string ChoosePath()
        {
            SaveFileDialog saveFile = new SaveFileDialog();
            saveFile.Filter= "Files|*.csv";
            if(saveFile.ShowDialog()==DialogResult.OK)
            {
                return saveFile.FileName;
            }
            return null;
        }



        public static async void ExportToExcel(IEnumerable<GameDTO> Games)
        {
            try
            {
                string filePath = ChoosePath();
                List<string> List = new List<string>();

                //List<GameDTO> list = new List<GameDTO>();

                foreach (var item in Games)
                {
                    List.Add($"{item.Name} {item.Price} {item.Developer} {item.Genre}");
                }
                await Task.Run(() =>
                {
                    File.WriteAllText(filePath, "");

                    

                    File.AppendAllLines(filePath, List);
                });

            }
            catch { }
        }
    }
}
