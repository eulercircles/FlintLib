using System;
using System.Collections.Generic;

namespace FlintLib.MVVM
{
    /// <summary>
    /// 
    /// </summary>
    /// <typeparam name="T"></typeparam>
    public interface IBindableSelectionList<T> : IBindable<int>
    {
        /// <summary>
        /// 
        /// </summary>
        IReadOnlyCollection<string> Items { get; }

        /// <summary>
        /// 
        /// </summary>
        T SelectedItem { get; }
    }
}
