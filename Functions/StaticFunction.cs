using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using ReLogic.Graphics;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Windows.Forms;
using Terraria;
using Terraria.GameContent.Biomes;
using Terraria.GameContent.Generation;
using Terraria.ID;
using Terraria.IO;
using Terraria.ModLoader;
using Terraria.Utilities;
using Terraria.World.Generation;

namespace MythMod.Function
{
    public class StaticFunction
    {
        #region 获取文件
        /// <summary>
        /// 获取文件(是否选择多个文件,标题,文件格式（如："图片文件(*.jpg,*.png,*.bmp)|*.jpg;*.png;*.bmp"）)
        /// </summary>
        /// <param name="Multiselect"></param>
        /// <param name="Title"></param>
        /// <param name="Filter"></param>
        /// <returns></returns>
        public static string GetFile(bool Multiselect, string Title, string Filter)
        {
            OpenFileDialog dialog = new OpenFileDialog();
            dialog.Multiselect = Multiselect;
            dialog.Title = Title;
            dialog.Filter = Filter;
            if (dialog.ShowDialog() == DialogResult.OK)
            {
                return dialog.FileName;
            }
            return "";
        }
        #endregion
        #region 绘制能量条
        /// <summary>
        /// 绘制能量条
        /// </summary>
        /// <param name="sb"></param>
        /// <param name="energyBox"></param>
        /// <param name="energyBar"></param>
        /// <param name="value"></param>
        /// <param name="maxValue"></param>
        /// <param name="position"></param>
        /// <param name="scheduleFont"></param>
        /// <param name="scale"></param>
        /// <param name="schedule"></param>
        public static void DrawEnergyBar(SpriteBatch sb, Texture2D energyBox, Texture2D energyBar, float value, float maxValue, Vector2 position, DynamicSpriteFont scheduleFont, float scale = 1f, bool schedule = false)
        {
            sb.Draw(energyBox, position, null, Color.White, 0f, energyBox.Size() / 2, scale, SpriteEffects.None, 0f);
            sb.Draw(energyBar, position, new Rectangle(0, 0, (int)(energyBar.Width * ((float)value / (float)maxValue)), energyBar.Height), Color.White, 0f, energyBar.Size() / 2, scale, SpriteEffects.None, 0f);
            if (schedule)
            {
                string scheduleValue = (int)((float)value / (float)maxValue * 100) + "%";
                Utils.DrawBorderStringFourWay(sb, scheduleFont, scheduleValue, position.X, position.Y, new Color(0, 255, 255), Color.Black, GetFontSize(scheduleValue, scheduleFont) / 2, scale);
            }
        }
        #endregion
        #region 获取文字向量大小
        /// <summary>
        /// 获取文字大小
        /// </summary>
        /// <param name="Text"></param>
        /// <param name="Font"></param>
        /// <param name="scale"></param>
        /// <returns></returns>
        public static Vector2 GetFontSize(string Text, DynamicSpriteFont Font, float scale = 1f)
        {
            Vector2 fontSize = Font.MeasureString(Text) * scale;
            return fontSize;
        }
        #endregion
        #region 储存文件
        /// <summary>
        /// 储存文件
        /// </summary>
        /// <param name="Filter"></param>
        /// <param name="input"></param>
        public static void ShowSaveFileDialog(string Filter,string input)
        {
            string localFilePath = "";
            //string localFilePath, fileNameExt, newFileName, FilePath; 
            SaveFileDialog sfd = new SaveFileDialog();
            //设置文件类型 
            sfd.Filter = Filter;
            //设置默认文件类型显示顺序 
            sfd.FilterIndex = 1;
            //保存对话框是否记忆上次打开的目录 
            sfd.RestoreDirectory = true;
            //点了保存按钮进入 
            if (sfd.ShowDialog() == DialogResult.OK)
            {
                localFilePath = sfd.FileName.ToString(); //获得文件路径 
                //获取文件名，不带路径
                //string fileNameExt = localFilePath.Substring(localFilePath.LastIndexOf("\\") + 1); 
                //获取文件路径，不带文件名 
                //FilePath = localFilePath.Substring(0, localFilePath.LastIndexOf("\\")); 
                //给文件名前加上时间 
                //newFileName = DateTime.Now.ToString() + fileNameExt; 
                //在文件名里加字符 
                //saveFileDialog1.FileName.Insert(1,"dameng"); 
                FileStream fs = (FileStream)sfd.OpenFile();//输出文件 
                //FileStream fs_1 = new FileStream(localFilePath, FileMode.Append);
                StreamWriter wr = new StreamWriter(fs);
                wr.WriteLine(input);
                wr.Close();
            }
        }
        #endregion

        public static List<string> SearchFor(string[] input, string search)
        {
            var output_ =
                from n in input
                where n.Contains(search)
                select n;
            List<string> list = new List<string>();
            foreach(var item in output_)
            {
                list.Add(item);
            }
            return list;
        }
    }
}