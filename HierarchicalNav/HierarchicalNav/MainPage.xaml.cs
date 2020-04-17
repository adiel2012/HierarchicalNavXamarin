using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Forms;

namespace HierarchicalNav
{
    // Learn more about making custom code visible in the Xamarin.Forms previewer
    // by visiting https://aka.ms/xamarinforms-previewer
    [DesignTimeVisible(false)]
    public partial class MainPage : ContentPage
    {
        public Utils.CTree<string> Tree {get; set;}

        public int Level { get; set; }
        public MainPage(Utils.CTree<string> tree, int level)
        {
            InitializeComponent();
            this.Tree = tree;
            Level = level;
            CreatePagesTree();
        }

        public  void CreatePagesTree()
        {
            StackLayout layouth = new StackLayout();
            Label lbl = new Label();
            lbl.Text = $"{Tree.Info} level:{Level}";
            layouth.Children.Add(lbl);

            foreach (var subtree in Tree.Children)
            {
                Button btn = new Button();
                btn.Text = subtree.Info;
                btn.Clicked += async (object sender, EventArgs e) => {
                    await Navigation.PushAsync(new MainPage(subtree, Level+1));
                };
                layouth.Children.Add(btn);
            }

            Content = layouth;

        }

    }
}
