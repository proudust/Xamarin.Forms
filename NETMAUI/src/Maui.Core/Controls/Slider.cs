﻿using System.Maui.Platform;
using System.Windows.Input;

namespace System.Maui.Controls
{
	public class Slider : View, ISlider
	{
		double _value;

		public Slider()
		{

		}

		public Slider(double min, double max, double val)
		{
			if (min >= max)
				throw new ArgumentOutOfRangeException("min");

			if (max > Minimum)
			{
				Maximum = max;
				Minimum = min;
			}
			else
			{
				Minimum = min;
				Maximum = max;
			}

			Value = val.Clamp(min, max);
		}

		public double Minimum { get; set; }
		public double Maximum { get; set; } = 1d;

		public double Value
		{
			get
			{
				return _value;
			}
			set
			{
				if (_value == value)
					return;

				_value = value;
			}
		}

		public Color MinimumTrackColor { get; set; }
		public Color MaximumTrackColor { get; set; }
		public Color ThumbColor { get; set; }

		public Action<double> ValueChanged { get; set; }
		public Action DragStarted { get; set; }
		public Action DragCompleted { get; set; }

		public ICommand DragStartedCommand { get; set; }
		public ICommand DragCompletedCommand { get; set; }

		void ISlider.ValueChanged()
		{
			ValueChanged?.Invoke(Value);
		}

		void ISlider.DragStarted()
		{
			if (IsEnabled)
			{
				DragStartedCommand?.Execute(null);
				DragStarted?.Invoke();
			}
		}

		void ISlider.DragCompleted()
		{
			if (IsEnabled)
			{
				DragCompletedCommand?.Execute(null);
				DragCompleted?.Invoke();
			}
		}
	}
}