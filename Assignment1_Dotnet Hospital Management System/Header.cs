using System;

public class Header
{
    public string headerTitle;
	public Header(String header_Title)
	{
        //this.headerTitle = header_Title;
        setHeaderTitle(header_Title);
    }

    public void setHeaderTitle(string header_Title) 
    {
        // Ensure correct encoding for box drawing characters
        Console.OutputEncoding = System.Text.Encoding.UTF8; 

        int boxWidth = 50; // Width of the box
        int boxHeight = 7;  // Height of the box (including top and bottom borders)
        int textPadding = 3; // Padding between text and the box border

        // Box characters
        char topLeftCorner = '╔';
        char topRightCorner = '╗';
        char bottomLeftCorner = '╚';
        char bottomRightCorner = '╝';
        char horizontalLine = '═';
        char verticalLine = '║';

        // Calculate centered text positions
        string title = "Hospital Management System";
        string headerText = header_Title;
        string dottedLine = new string('.', boxWidth - 2 - 2 * textPadding); // Dotted line with padding on both sides

        int titlePosition = (boxWidth - title.Length) / 2;
        int loginTextPosition = (boxWidth - headerText.Length) / 2;
        int dottedLinePosition = textPadding;

        // Draw top border
        Console.WriteLine(topLeftCorner + new string(horizontalLine, boxWidth - 2) + topRightCorner);

        // Top Padding before the title
        for (int i = 0; i < textPadding; i++)
        {
            Console.WriteLine(verticalLine + new string(' ', boxWidth - 2) + verticalLine);
        }

        // Title
        Console.WriteLine(verticalLine + new string(' ', titlePosition) + title + new string(' ', boxWidth - title.Length - titlePosition - 2) + verticalLine);

        // Draw the dotted line
        Console.WriteLine(verticalLine + new string(' ', dottedLinePosition) + dottedLine + new string(' ', boxWidth - dottedLine.Length - dottedLinePosition - 2) + verticalLine);

        // Draw the login text
        Console.WriteLine(verticalLine + new string(' ', loginTextPosition) + headerText + new string(' ', boxWidth - headerText.Length - loginTextPosition - 2) + verticalLine);

        // Draw empty lines after the login text
        for (int i = 0; i < textPadding; i++)
        {
            Console.WriteLine(verticalLine + new string(' ', boxWidth - 2) + verticalLine);
        }

        // Draw bottom border
        Console.WriteLine(bottomLeftCorner + new string(horizontalLine, boxWidth - 2) + bottomRightCorner);
    }
}
