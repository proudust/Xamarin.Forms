﻿using Android.Views;
using static Android.Views.View;

namespace System.Maui.Platform
{
	public static class MeasureSpecExtensions
	{
		public static int GetSize(this int measureSpec)
		{
			const int modeMask = 0x3 << 30;
			return measureSpec & ~modeMask;
		}

		public static MeasureSpecMode GetMode(this int measureSpec)
		{
			return MeasureSpec.GetMode(measureSpec);
		}

		// Need a method to extract mode, so we can see if the viewgroup is calling measure twice with different modes

		public static int MakeMeasureSpec(this MeasureSpecMode mode, int size)
		{
			return size + (int)mode;
		}
	}
}