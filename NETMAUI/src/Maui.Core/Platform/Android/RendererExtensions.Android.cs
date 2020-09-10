﻿using Android.Content;
using AView = Android.Views.View;

namespace System.Maui.Platform
{
	public static class HandlerExtensions
	{
		public static AView ToNative(this IView view, Context context)
		{
			if (view == null)
				return null;
			var handler = view.Handler;
			if (handler == null)
			{
				handler = Registrar.Handlers.GetHandler(view.GetType());
				if (handler is IAndroidViewHandler aHandler)
					aHandler.SetContext(context);
				view.Handler = handler;
			}
			handler.SetView(view);

			return handler?.ContainerView ?? handler.NativeView as AView;

		}

	}
}