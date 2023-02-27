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
using Terraria.WorldBuilding;

namespace MythMod.Function
{
    public class StaticFunction
    {
        #region �0�3�0�9�0�6�0�3�0�2�0�2�0�4�0�6
        /// <summary>
        /// �0�3�0�9�0�6�0�3�0�2�0�2�0�4�0�6(�0�8�0�5���0�9�0�5�0�3�0�8�0�9�0�9���0�0�0�2�0�2�0�2�0�4�0�6,�����0�0�0�9,�0�2�0�2�0�4�0�6�0�0�0�9�0�8�0�5�0�5���0�6�0�4�0�5�0�2"�0�1�0�4�0�4�0�1�0�2�0�2�0�4�0�6(*.jpg,*.png,*.bmp)|*.jpg;*.png;*.bmp"�0�5�0�8)
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
        #region �0�3�0�3�0�0�0�4�0�2�0�5�0�9�0�7�0�0�0�1
        /// <summary>
        /// �0�3�0�3�0�0�0�4�0�2�0�5�0�9�0�7�0�0�0�1
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
        #region �0�3�0�9�0�6�0�3�0�2�0�2���0�0�0�3���0�9�0�7�0�7���0�4�0�3
        /// <summary>
        /// �0�3�0�9�0�6�0�3�0�2�0�2���0�0�0�7���0�4�0�3
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
        #region �0�7�0�4�0�7�0�3�0�2�0�2�0�4�0�6
        /// <summary>
        /// �0�7�0�4�0�7�0�3�0�2�0�2�0�4�0�6
        /// </summary>
        /// <param name="Filter"></param>
        /// <param name="input"></param>
        public static void ShowSaveFileDialog(string Filter,string input)
        {
            string localFilePath = "";
            //string localFilePath, fileNameExt, newFileName, FilePath; 
            SaveFileDialog sfd = new SaveFileDialog();
            //�0�7���0�0�0�1�0�2�0�2�0�4�0�6�0�8���0�4�0�1 
            sfd.Filter = Filter;
            //�0�7���0�0�0�1�0�2�0�1�0�6�0�3�0�2�0�2�0�4�0�6�0�8���0�4�0�1�0�3�0�8�0�8�0�6�0�9�0�6�0�4�� 
            sfd.FilterIndex = 1;
            //���0�5�0�7�0�3�0�9�0�8�0�3��0�7���0�8�0�5���0�9�0�4�0�5�0�6�0�1�0�7�0�3�0�7�0�2�0�7���0�7�0�9�0�8�0�2�0�2�0�7�0�0�0�4 
            sfd.RestoreDirectory = true;
            //�0�8�0�0�0�9�0�9���0�5�0�7�0�3��0�7�0�3�0�6�0�5�0�3�0�6�0�5 
            if (sfd.ShowDialog() == DialogResult.OK)
            {
                localFilePath = sfd.FileName.ToString(); //�0�3�0�9�0�8�0�1�0�2�0�2�0�4�0�6�0�0���0�6�0�9 
                //�0�3�0�9�0�6�0�3�0�2�0�2�0�4�0�6�0�1�0�4�0�5�0�1�0�5�0�3�0�7�0�3�0�0���0�6�0�9
                //string fileNameExt = localFilePath.Substring(localFilePath.LastIndexOf("\\") + 1); 
                //�0�3�0�9�0�6�0�3�0�2�0�2�0�4�0�6�0�0���0�6�0�9�0�5�0�1�0�5�0�3�0�7�0�3�0�2�0�2�0�4�0�6�0�1�0�4 
                //FilePath = localFilePath.Substring(0, localFilePath.LastIndexOf("\\")); 
                //�0�0�0�3�0�2�0�2�0�4�0�6�0�1�0�4�0�5��0�4�0�7�0�7�0�3�0�8���0�4�0�1 
                //newFileName = DateTime.Now.ToString() + fileNameExt; 
                //�0�8�0�3�0�2�0�2�0�4�0�6�0�1�0�4�0�8�0�7�0�4�0�7���0�0���0�4 
                //saveFileDialog1.FileName.Insert(1,"dameng"); 
                FileStream fs = (FileStream)sfd.OpenFile();//�0�8�0�1�0�6�0�2�0�2�0�2�0�4�0�6 
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