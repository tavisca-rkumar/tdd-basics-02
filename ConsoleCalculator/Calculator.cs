using System;

namespace ConsoleCalculator
{
    public class Calculator
    {

        string expression = "";
        string[] display;
        int iterator = 0;

        public void setExpression(string exp)
        {
            expression = expression + exp;
            display = new string[expression.Length];
        }

        public void setKeyPress(ref int prev_digit, char digit) // sets the display output
        {

            prev_digit = prev_digit * 10 + (digit - 48);
            display[iterator++] = prev_digit.ToString();
        }
        public bool isDigit(char c)
        {
            if (c >= 48 && c <= 57)
                return true;
            else
                return false;
        }
        public string getFinalAnswer(int result, int prev_digit, char sign)
        {
            switch (sign)
            {
                case '+':
                    return (result + prev_digit).ToString();
                    break;

                case '-':
                    return (result - prev_digit).ToString();
                    break;

                case '/':
                    if (prev_digit == 0)
                        return "-E-";
                    return (result / prev_digit).ToString();
                    break;

                case '*':
                    return (result * prev_digit).ToString();
                    break;
                default:
                    return "";
                    break;
            }
        }



        public string doSolve()
        {
            string new_decimal_front_part = ""; // digits before dot
            string after_decimal = "";  // digits after dot
            int result = 0;  // final result
            int decimal_count = 0;// how may decimal points
            Boolean decimal_digit = false;  // digit is decimal or not
            int prev_digit = 0;
            char sign = '#';  // expression last sign 
            for (int i = 0; i < expression.Length; i++)
            {
                if (isDigit(expression[i]))
                {
                    if (!decimal_digit)
                        setKeyPress(ref prev_digit, expression[i]);
                    else
                        after_decimal += expression[i];
                }
                else
                {

                    switch (expression[i])
                    {
                        case '+':
                            if (result == 0)
                                result = prev_digit;
                            else
                                result = result + prev_digit;
                            display[iterator++] = result.ToString();
                            prev_digit = 0;
                            sign = '+';
                            break;
                        case '-':
                            if (result == 0)
                                result = prev_digit;
                            else
                                result = result - prev_digit;
                            display[iterator++] = result.ToString();
                            prev_digit = 0;
                            sign = '-';
                            break;
                        case '*':
                            if (result == 0)
                                result = prev_digit;
                            else
                                result = result * prev_digit;
                            display[iterator++] = result.ToString();
                            prev_digit = 0;
                            sign = '*';
                            break;
                        case '/':
                            if (result == 0)
                                result = prev_digit;
                            else
                            {
                                if (prev_digit == 0)
                                    return "-E-";
                                result = result / prev_digit;
                            }
                            display[iterator++] = result.ToString();
                            prev_digit = 0;
                            sign = '/';
                            break;
                        case 'c':
                            result = 0;
                            display[iterator++] = result.ToString();
                            prev_digit = 0;
                            return result.ToString();
                            break;
                        case 's':
                            if (prev_digit > 0)
                                prev_digit = -prev_digit;
                            else
                                prev_digit = -prev_digit;
                            display[iterator++] = prev_digit.ToString();
                            break;
                        case '=':
                            if (isDigit(expression[i - 1]))
                                return getFinalAnswer(result, prev_digit, sign);
                            else
                                return getFinalAnswer(result, Int32.Parse(display[iterator - 1]), sign);
                            break;
                        case '.':
                            if (decimal_count == 1)
                                continue;
                            decimal_digit = true;
                            decimal_count++;
                            new_decimal_front_part += prev_digit.ToString();
                            new_decimal_front_part += ".";
                            prev_digit = 0;
                            break;
                    }
                }
            }
            string Final_decimal = new_decimal_front_part + after_decimal; //Final decimal result
            return Final_decimal;
        }


    }
}
