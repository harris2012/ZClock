using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;
using System.Windows.Threading;

namespace TimeDown
{
	public class ZClock : Control
	{
		public static DependencyProperty TimeProperty = DependencyProperty.Register("Time",
			typeof(DateTime),
			typeof(ZClock),
			new PropertyMetadata(DateTime.Now));

		static ZClock()
		{
			DefaultStyleKeyProperty.OverrideMetadata(typeof(ZClock), new FrameworkPropertyMetadata(typeof(ZClock)));
		}

		public DateTime Time
		{
			get { return (DateTime)GetValue(TimeProperty); }
			set { SetValue(TimeProperty, value); }
		}

		protected override void OnInitialized(EventArgs e)
		{
			base.OnInitialized(e);

			DispatcherTimer timer = new DispatcherTimer();
			timer.Tick += (s, x) =>
			{
				this.Time = DateTime.Now;
			};
			timer.Start();
		}
	}
}
