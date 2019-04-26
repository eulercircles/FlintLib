using System;
using System.Windows.Forms;

using FLib.Common;

namespace FLib.Forms
{
	public class NumericTextBox : ValidatingTextBox
	{
		public ValidationTriggers ValidateWhen { get; set; }

		public bool IsValid { get { return ValidityState == TextBoxValidityStates.Valid; } }

		public double Minimum { get; set; } = double.MinValue;

		public double Maximum { get; set; } = double.MaxValue;

		public NumericTextBox()
		{
			TextAlign = HorizontalAlignment.Right;
			ValidityState = TextBoxValidityStates.Neutral;

			Leave += NumericTextBox_Leave;
			TextChanged += NumericTextBox_TextChanged;
			KeyPress += NumericTextBox_KeyPress;
		}

		private void NumericTextBox_KeyPress(object sender, KeyPressEventArgs e)
		{
			if (e.KeyChar == (char)Keys.Return)
			{
				Evaluate();
			}
		}

		private void NumericTextBox_TextChanged(object sender, EventArgs e)
		{
			if (ValidateWhen == ValidationTriggers.TextChanged)
			{
				Evaluate();
			}
		}

		private void NumericTextBox_Leave(object sender, EventArgs e)
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
				if (Text.IsNumericValue())
				{
					ValidityState = TextBoxValidityStates.Valid;
					CorrectText();
				}
				else { ValidityState = TextBoxValidityStates.Invalid; }
			}
		}

		private void CorrectText()
		{
			Text = Text.Trim();
		}
	}
}
