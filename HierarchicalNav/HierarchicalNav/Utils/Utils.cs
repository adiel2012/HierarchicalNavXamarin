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
    public abstract class ExtendedBindableObject : BindableObject
    {
        public void RaisePropertyChanged<T>(Expression<Func<T>> property)
        {
            var name = GetMemberInfo(property).Name;
            OnPropertyChanged(name);
        }

        private MemberInfo GetMemberInfo(Expression expression)
        {
            MemberExpression operand;
            LambdaExpression lambdaExpression = (LambdaExpression)expression;
            if (lambdaExpression.Body as UnaryExpression != null)
            {
                UnaryExpression body = (UnaryExpression)lambdaExpression.Body;
                operand = (MemberExpression)body.Operand;
            }
            else
            {
                operand = (MemberExpression)lambdaExpression.Body;
            }
            return operand.Member;
        }
    }
}
