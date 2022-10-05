using System.Windows.Controls;

static class TextBoxMethods
{
	public static void Delete (this TextBox textBox, int i)
	{
		int textPointer = textBox.CaretIndex;
		textBox.Text = textBox.Text.Remove(i, 1);
		textPointer = textPointer > i ? --textPointer : textPointer;
		textBox.CaretIndex = textPointer;
	}
}
