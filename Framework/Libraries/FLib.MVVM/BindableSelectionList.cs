﻿using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;

namespace FLib.MVVM
{
	internal class BindableSelectionList<T> : Bindable<int>
	{
		private readonly Dictionary<string, T> _items;

		public IReadOnlyCollection<string> Items { get; private set; }

		public T SelectedItem { get { return _items[Items.ElementAt(Value)]; } }

		public BindableSelectionList(Dictionary<string, T> items)
		{
			_items = items;
			Items = new ReadOnlyCollection<string>(items.Keys.ToList());
			Value = 0;
		}
	}
}
