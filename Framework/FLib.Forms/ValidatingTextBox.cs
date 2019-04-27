using System;
using System.Drawing;
using System.Windows.Forms;

using FLib.Common;
using FLib.Presentation;

namespace FLib.Forms
{
	public abstract class ValidatingTextBox : TextBox
	{
		private readonly Color _defaultBackgroundColor;
		private readonly Color _defaultForegroundColor;

		public ValidatingTextBox()
		{
			_defaultBackgroundColor = BackColor;
			_defaultForegroundColor = ForeColor;
		}

		private TextBoxValidityStates _validityState;
		protected TextBoxValidityStates ValidityState
		{
			get { return _validityState; }
			set
			{
				_validityState = value;
				switch (_validityState)
				{
					case TextBoxValidityStates.Default: SetDefaultTheme(); break;
					case TextBoxValidityStates.Valid: SetValidTheme(); break;
					case TextBoxValidityStates.Invalid: SetInvalidTheme(); break;
					case TextBoxValidityStates.Neutral: SetNeutralTheme(); break;
				}
			}
		}

		private void SetValidTheme()
		{
			BackColor = Colors.GoodBackground;
			ForeColor = Colors.GoodForeground;
		}

		private void SetInvalidTheme()
		{
			BackColor = Colors.BadBackground;
			ForeColor = Colors.BadForeground;
		}

		private void SetNeutralTheme()
		{
			BackColor = Colors.NeutralBackground;
			ForeColor = Colors.NeutralForeground;
		}

		private void SetDefaultTheme()
		{
			BackColor = _defaultBackgroundColor;
			ForeColor = _defaultForegroundColor;
		}
	}
}
