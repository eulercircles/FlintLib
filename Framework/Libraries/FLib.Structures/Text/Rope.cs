using System;

using FLib.Structures.Generic;

namespace FLib.Structures
{
	public class Rope
	{
		private char[] _value;

		private Rope _lChild = null;
		private Rope _rChild = null;

		public int Length
		{
			get
			{
				if (_value != null) { return _value.Length; }
				else { return _lChild.Length + _rChild.Length; }
			}
		}
		
		#region Operator Overloads
		public static Rope operator +(Rope lhr, Rope rhr)
		{
			if (lhr == null) { throw new ArgumentNullException(); }
			if (rhr == null) { throw new ArgumentNullException(); }

			var result = new Rope()
			{
				_lChild = lhr,
				_rChild = rhr
			};

			return result;
		}
		#endregion Operator Overloads

		public char this[int index]
		{
			get
			{
				if (_value != null) { return _value[index]; }
				else
				{
					if (index < _lChild.Length) { return _lChild[index]; }
					else { return _rChild[index - _lChild.Length]; }
				}
			}
		}

		public Rope(char[] initialValue = null)
		{
			_value = initialValue;
		}

		#region Public Methods
		public void Insert(int lowerBound, int upperBound, Rope value)
		{

		}

		public void Remove(int lowerBound, int upperBound)
		{

		}

		public Rope Subrope(int lowerBound, int upperBound)
		{
			throw new NotImplementedException();
		}
		#endregion Public Methods

		#region Private Methods
		private void Split() { }

		private void Join() { }

		#endregion Private Methods

		#region Overridden Methods
		public override string ToString()
		{
			throw new NotImplementedException();
		}
		#endregion Overridden Methods
	}
}
