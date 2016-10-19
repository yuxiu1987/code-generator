using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace code_generator
{
    /// <summary>
    /// MainWindow.xaml 的交互逻辑
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
            KeywordTable.Add("class");
            CodeDocument.Blocks.Add(new Paragraph(new Run("class")));
        }

        FlowDocument CodeDocument = new FlowDocument();        

        public List<string> KeywordTable = new List<string>();

        /// <summary>
        /// 向文本框中生成代码  inert code to the richtextbox
        /// </summary>
        private void codeGenerating()
        {
            if (ClassNameInput.Text == null)
            {
                FlowDocument WarningInfo = new FlowDocument();
                WarningInfo.Blocks.Add(new Paragraph(new Run("Please enter the class name!" + "\n")));
                CodeText.Document = WarningInfo;
            }
            else
            {
                CodeDocument.Blocks.Add(new Paragraph(new Run("class " + ClassNameInput.Text + "\n" + "{" + "\n" + "}" + "\n")));
                CodeText.Document = CodeDocument;
            }
        }       

        /// <summary>
        /// 鼠标点击按钮生成 generator code with mouse click event
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void Generator_Click(object sender, RoutedEventArgs e)
        {
            codeGenerating();
        }

        /// <summary>
        /// 回车直接生成 generator code with enter keydown event
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void ClassNameInput_KeyDown(object sender, KeyEventArgs e)
        {
            if(e.Key == Key.Enter )
            {
                codeGenerating();
            }
        }

        /// <summary>
        /// 清空文本框
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void Clear_Click(object sender, RoutedEventArgs e)
        {
            CodeText.Document.Blocks.Clear();
        }


    }
}
