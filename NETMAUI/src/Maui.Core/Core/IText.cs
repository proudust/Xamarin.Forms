﻿namespace System.Maui
{
	public interface IText : IFont, ITextAlignment
	{
		string Text { get; }

		Color TextColor { get; }

		Font Font { get; }

		TextTransform TextTransform { get; }

		double CharacterSpacing { get; }
	}
}