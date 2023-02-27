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
        #region ��ȡ�ļ�
        /// <summary>
        /// ��ȡ�ļ�(�Ƿ�ѡ�����ļ�,����,�ļ���ʽ���磺"ͼƬ�ļ�(*.jpg,*.png,*.bmp)|*.jpg;*.png;*.bmp"��)
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
        #region ����������
        /// <summary>
        /// ����������
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
        #region ��ȡ����������С
        /// <summary>
        /// ��ȡ���ִ�С
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
        #region �����ļ�
        /// <summary>
        /// �����ļ�
        /// </summary>
        /// <param name="Filter"></param>
        /// <param name="input"></param>
        public static void ShowSaveFileDialog(string Filter,string input)
        {
            string localFilePath = "";
            //string localFilePath, fileNameExt, newFileName, FilePath; 
            SaveFileDialog sfd = new SaveFileDialog();
            //�����ļ����� 
            sfd.Filter = Filter;
            //����Ĭ���ļ�������ʾ˳�� 
            sfd.FilterIndex = 1;
            //����Ի����Ƿ�����ϴδ򿪵�Ŀ¼ 
            sfd.RestoreDirectory = true;
            //���˱��水ť���� 
            if (sfd.ShowDialog() == DialogResult.OK)
            {
                localFilePath = sfd.FileName.ToString(); //����ļ�·�� 
                //��ȡ�ļ���������·��
                //string fileNameExt = localFilePath.Substring(localFilePath.LastIndexOf("\\") + 1); 
                //��ȡ�ļ�·���������ļ��� 
                //FilePath = localFilePath.Substring(0, localFilePath.LastIndexOf("\\")); 
                //���ļ���ǰ����ʱ�� 
                //newFileName = DateTime.Now.ToString() + fileNameExt; 
                //���ļ�������ַ� 
                //saveFileDialog1.FileName.Insert(1,"dameng"); 
                FileStream fs = (FileStream)sfd.OpenFile();//����ļ� 
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