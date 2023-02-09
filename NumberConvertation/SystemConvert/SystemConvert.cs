using System;
using System.Collections.Generic;
using System.Windows.Controls;

namespace NumberConvertation.SystemConvert;

class SystemConvert
{
	private int accuracy;
	private int firstSystem;
	private int secondSystem;
	private TextBox firstExpression;
	private TextBox secondExpression;
	private readonly TextConvert textConvert;

	private SystemConvert(TextBox firstExpression, TextBox secondExpression)
	{
		this.firstExpression = firstExpression;
		this.secondExpression = secondExpression;
	}
	public SystemConvert(TextBox firstExpression, TextBox secondExpression, TextConvert textConvert) : this(firstExpression, secondExpression)
	{
		this.textConvert = textConvert;
	}

	public int Accuracy { set => accuracy = value; }
	public int FirstSystem { set => firstSystem = value; }
	public int SecondSystem { set => secondSystem = value; }
	public TextBox FirstExpression { set => firstExpression = value; }
	public TextBox SecondExpression { set => secondExpression = value; }

	public void Execute(bool isInvert)
	{
		if (isInvert)
		{
			Convert(secondExpression, firstExpression, secondSystem, firstSystem);
		}
		else
		{
			Convert(firstExpression, secondExpression, firstSystem, secondSystem);
		}
	}

	private void Convert(TextBox expression, TextBox result, int firstSystem, int secondSystem)
	{
		if (expression.Text == string.Empty || result.Text == string.Empty || firstSystem == 0 ||
		    secondSystem == 0) return;
		var isSigned = false;
		var floatPosition = 0;
		var errors = new List<int>();
		var numbers = textConvert.Convert(expression.Text, ref isSigned, ref floatPosition, errors);
		if (errors.Count != 0)
		{
			foreach (var i in errors)
			{
				expression.Delete(i);
			}
			return;
		}
		var multiplier = Math.Pow(firstSystem, isSigned ? floatPosition - 2 : floatPosition - 1);
		result.Text = "";
		if (isSigned)
		{
			result.Text += "-";
		}
		double decResult = 0;
		foreach (var t in numbers)
		{
			decResult += t * multiplier;
			multiplier /= firstSystem;
		}

		var intDecResult = (int)Math.Floor(decResult);
		var resultWithoutSign = "";
		while (intDecResult >= secondSystem)
		{
			resultWithoutSign = textConvert.Convert(intDecResult % secondSystem) + resultWithoutSign;
			intDecResult = intDecResult / secondSystem;
		}
		resultWithoutSign = textConvert.Convert(intDecResult) + resultWithoutSign;
		result.Text += resultWithoutSign;
		if (floatPosition == expression.Text.Length) return;
		{
			var floatPart = decResult - (int)decResult;
			result.Text += '.';
			for (var i = 0; i < System.Convert.ToInt32(accuracy); i++)
			{
				floatPart *= secondSystem;
				result.Text += (textConvert.Convert((int)floatPart));
				floatPart -= (int)floatPart;
			}
		}
	}
}