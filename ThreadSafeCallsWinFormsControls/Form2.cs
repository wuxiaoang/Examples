using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading;
using System.Windows.Forms;

namespace ThreadSafeCallsWinFormsControls
{
    public partial class Form2 : Form
    {
        private Thread demoThread;

        public Form2()
        {
            InitializeComponent();

            // 当创建控件的线程以外的线程尝试访问该控件的一个方法或属性时，通常会导致不可预知的结果。  
            // 设置CheckForIllegalCrossThreadCalls到true来查找和调试时更轻松地诊断此线程活动。
            // Visual Studio .NET 2003 和 .NET Framework 1.1之后，该属性默认值为true。
            //CheckForIllegalCrossThreadCalls = false;
        }

        private void setTextUnsafeBtn_Click(object sender, EventArgs e)
        {
            this.demoThread = new Thread(new ThreadStart(this.updateTheTextBox));

            this.demoThread.Start();
        }

        

        private void setTextBtn_Click(object sender, EventArgs e)
        {
            updateTheTextBox();
        }
        
        private void updateTheTextBox()
        {
            string text = "This text was updated ." + DateTime.Now.ToLongTimeString();

            // 方法 1：直接修改
            //     这个方法本身并没有问题，但是如果在窗体主线程之外的线程中调用这个方法，
            //     就会发生如下异常：
            //         “System.InvalidOperationException:
            //         “线程间操作无效: 从不是创建控件“textBox1”的线程访问它。””
            //this.textBox1.Text = text;

            // 方法 2：
            //    所以，为了能够安全地跨线程修改控件属性，可以改用下面的方法：
            //   （因为要访问ui资源，所以需要使用invoke方式同步ui。）
            this.Invoke(
                (EventHandler)
                (delegate{
                    this.textBox1.Text = text;
                    }
                )
            );

            // 或者采用另一种方法：
            //方法 3：
            //SetText(text);
        }

        delegate void setTextDelegate(string text);
        private void SetText(string text)
        {
            // InvokeRequired required compares the thread ID of the
            // calling thread to the thread ID of the creating thread.
            // If these threads are different, it returns true.
            if (this.textBox1.InvokeRequired)
            {
                this.Invoke(
                    new setTextDelegate(SetText), 
                    new object[] { text });
            }
            else
            {
                this.textBox1.Text = text;
            }
        }
    }
}
