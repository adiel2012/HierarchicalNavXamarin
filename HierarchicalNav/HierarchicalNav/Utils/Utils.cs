using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq.Expressions;
using System.Reflection;
using System.Text;
using Xamarin.Forms;

namespace HierarchicalNav.Utils
{
    public class CTree<T>
    {
        public string Name { set; get; }
        public T Info { set; get; }
        public CTree<T> Parent { get; set; }
        public LinkedList<CTree<T>> Children { get; set; } = new LinkedList<CTree<T>>();

        public CTree(T info, CTree<T> parent, string name)
        {
            Info = info;
            Parent = parent;
            Name = name;
        }

    }
    public class Functions
    {
        public static CTree<string> GetTree()
        {
            CTree<string> root = new CTree<string>("Root", null, "Root");
            Action<CTree<string>, int> createtree = null;
            createtree = (CTree<string> tree, int level) => { 
                if(level == 0)
                    return; 
                for(int i = 0; i < 8; i++)
                {
                    var child = new CTree<string>($"Page:{i + 1}", tree, (i + 1).ToString());
                    tree.Children.AddLast(child);
                    createtree(child, level - 1);
                }
            };
            createtree(root, 5);
            return root;
        }
    }
}
