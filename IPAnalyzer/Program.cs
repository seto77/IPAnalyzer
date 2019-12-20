using System;
using System.Collections.Generic;
using System.Linq;
using System.Windows.Forms;
using Microsoft.VisualBasic.ApplicationServices;

namespace IPAnalyzer
{
    static class Program
    {
        /// <summary>
        /// アプリケーションのメイン エントリ ポイントです。
        /// </summary>
        [STAThread]
        static void Main(string[] args)
        {
            /*
            //Mutexクラスの作成
            //"MyName"の部分を適当な文字列に変えてください
            System.Threading.Mutex mutex = new System.Threading.Mutex(false, Application.ExecutablePath);
            //ミューテックスの所有権を要求する
            if (mutex.WaitOne(0, false) == false)
            {
                //すでに起動していると判断して終了
                MessageBox.Show("多重起動はできません。");
                return;
            }
            */


            /*
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            Application.Run(new FormMain());

            //ミューテックスを解放する
            mutex.ReleaseMutex();
            */

            myApplication winAppBase = new myApplication();
            winAppBase.Run(args);
        }

        class myApplication : WindowsFormsApplicationBase
        {
            public myApplication()
                : base()
            {
                this.EnableVisualStyles = true;
                this.IsSingleInstance = true;
                this.MainForm = new FormMain();//スタートアップフォームを設定

                
                this.StartupNextInstance += new StartupNextInstanceEventHandler(myApplication_StartupNextInstance);
            }
            void myApplication_StartupNextInstance(object sender, StartupNextInstanceEventArgs e)
            {
                //ここに二重起動されたときの処理を書く
                //e.CommandLineでコマンドライン引数を取得出来る
                string filename = "";
                for (int i = 0; i < e.CommandLine.Count; i++)
                    filename += (i == 0 ? "" : " ") + e.CommandLine[i];
                ((FormMain)(this.MainForm)).ReadImage(filename);
            }
        }

  


    }
}
