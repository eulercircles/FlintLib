using System.Windows;
using System.Windows.Controls;

namespace FLib.Controls.WPF
{
	public partial class DecimalViewEditBox : UserControl
	{
		private static readonly DependencyProperty AmountProperty = DependencyProperty.Register(
		"Amount", typeof(decimal), typeof(DecimalViewEditBox), new PropertyMetadata(default(decimal)));

		public decimal Amount
		{
			get => (decimal)GetValue(AmountProperty);
			set => SetValue(AmountProperty, value);
		}

		public DecimalViewEditBox()
		{
			InitializeComponent();
		}
	}
}
