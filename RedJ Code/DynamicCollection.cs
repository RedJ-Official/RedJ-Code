using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;
using FastColoredTextBoxNS;

namespace RedJ_Code
{
    /// <summary>
    /// Builds list of <see cref="AutocompleteItem"/>s for <see cref="Language.CSharp"/>
    /// </summary>
    internal class CSharpAutocompleteItemCollection : IEnumerable<AutocompleteItem>
    {
        private readonly AutocompleteMenu autocompleteMenu;

        private readonly Assembly[] assemblies;

        public CSharpAutocompleteItemCollection(AutocompleteMenu menu)
        {
            autocompleteMenu = menu;

            assemblies = AppDomain.CurrentDomain.GetAssemblies();
        }

        public IEnumerator<AutocompleteItem> GetEnumerator()
        {
            //get current fragment of the text
            var text = autocompleteMenu.Fragment.Text;

            //extract class name (part before dot)
            var parts = text.Split('.');
            if (parts.Length < 2)
            {
                yield break;
            }
            var className = parts[^2];

            //find type for given className
            var type = FindTypeByName(className);
            if (type == null)
            {
                yield break;
            }

            foreach (MemberInfo m in type.GetMembers())
            {
                yield return new MethodAutocompleteItem(m.Name)
                {
                    ToolTipTitle = m.Name,
                    ToolTipText = m.ReflectedType?.FullName,
                    ImageIndex = GetImageIndexFromMemberInfo(m)
                };
            }

            ////return static methods of the class
            //foreach (var methodName in type.GetMethods().Select(mi => mi.Name).Distinct())
            //{
            //    yield return new MethodAutocompleteItem(methodName + "()")
            //    {
            //        ToolTipTitle = methodName,
            //        ToolTipText = "Description of method " + methodName + " goes here.",
            //    };
            //}

            ////return static properties of the class
            //foreach (var pi in type.GetProperties())
            //{
            //    yield return new MethodAutocompleteItem(pi.Name)
            //    {
            //        ToolTipTitle = pi.Name,
            //        ToolTipText = "Description of property " + pi.Name + " goes here.",
            //    }; 
            //}
        }

        private Type? FindTypeByName(string name)
        {
            Type? type;

            foreach (Assembly asm in assemblies)
            {
                type = asm.GetType(name, false, true);

                if (type != null)
                {
                    return type;
                }
            }

            return null;
        }

        private int GetImageIndexFromType(Type t)
        {
            if (t.IsClass)      return 0;
            if (t.IsEnum)       return 3;
            if (t.IsInterface)  return 7;
            if (t.IsValueType)  return 12;

            return -1;
        }

        private int GetImageIndexFromMemberInfo(MemberInfo m)
        {
            if (m is EventInfo)     return 5;
            if (m is FieldInfo)     return 6;
            if (m is MethodInfo)    return 8;
            if (m is PropertyInfo)  return 11;

            return -1;
        }

        IEnumerator IEnumerable.GetEnumerator()
        {
            return GetEnumerator();
        }
    }
}
