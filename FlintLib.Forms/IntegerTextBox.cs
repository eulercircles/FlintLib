using System;
using System.Windows.Forms;

using FLib.Common;

namespace FLib.Forms
{
	public class IntegerTextBox : ValidatingTextBox
	{
		public ValidationTriggers ValidateWhen { get; set; }

		public bool IsValid { get { return ValidityState == TextBoxValidityStates.Valid; } }

		public int Minimum { get; set; } = int.MinValue;

		public int Maximum { get; set; } = int.MaxValue;

		public IntegerTextBox()
		{
			TextAlign = HorizontalAlignment.Right;
			ValidityState = TextBoxValidityStates.Neutral;

			Leave += IntegerTextBox_Leave;
			TextChanged += IntegerTextBox_TextChanged;
			KeyPress += IntegerTextBox_KeyPress;
		}

		private void IntegerTextBox_KeyPress(object sender, KeyPressEventArgs e)
		{
			if (e.KeyChar == (char)Keys.Return)
			{
				Evaluate();
			}
		}

		private void IntegerTextBox_TextChanged(object sender, EventArgs e)
		{
			if (ValidateWhen == ValidationTriggers.TextChanged)
			{
				Evaluate();
			}
		}

		private void IntegerTextBox_Leave(object sender, EventArgs e)
		{
			if (ValidateWhen == ValidationTriggers.FocusLost)
			{
				Evaluate();
			}
		}

		private void Evaluate()
		{
			if (Text == string.Empty) { ValidityState = TextBoxValidityStates.Neutral; }
			else
			{
				if (Text.IsIntegerValue())
				{
					ValidityState = TextBoxValidityStates.Valid;
					CorrectText();
				}
				else { ValidityState = TextBoxValidityStates.Invalid; }
			}
		}

		private void CorrectText()
		{
			Text = Text.Trim().Replace(".", string.Empty);
		}
	}
}
