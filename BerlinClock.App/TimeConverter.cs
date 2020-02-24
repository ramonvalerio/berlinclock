using System;
using System.Text;

namespace BerlinClock.App
{
    public class TimeConverter : ITimeConverter
    {
        public string ConvertTime(string time)
        {
            var seconds = getSeconds(time);
            var hours = getHours(time);
            var minutes = getMinutes(time);

            var result = new StringBuilder();
            result.AppendLine(convertToYellowBall(seconds));
            result.AppendLine(convertToFirstRedTopLamps(hours));
            result.AppendLine(convertToSecondRedTopLamps(hours));
            result.AppendLine(convertToFirstBottomLamps(minutes));
            result.Append(convertToSecondBottomLamps(minutes));

            return result.ToString();
        }

        private string convertToYellowBall(int seconds)
        {
            return seconds == 0 || seconds % 2 == 0 ? "Y" : "O";
        }

        private string convertToFirstRedTopLamps(int hours)
        {
            var result = string.Empty;
            var totalOfLamps = 4;
            var minutesPerLamp = 5;
            var redLampsCount = hours / minutesPerLamp;

            for (int i = 0; i < redLampsCount; i++)
                result += "R";

            for (int i = 0; i < totalOfLamps - redLampsCount; i++)
                result += "O";

            return result;
        }

        private string convertToSecondRedTopLamps(int hours)
        {
            var result = string.Empty;
            var totalOfLamps = 4;
            var minutesPerLamp = 5;
            var redLampsCount = hours - ((hours / minutesPerLamp) * minutesPerLamp);

            for (int i = 0; i < redLampsCount; i++)
                result += "R";

            for (int i = 0; i < totalOfLamps - redLampsCount; i++)
                result += "O";

            return result;
        }

        private string convertToFirstBottomLamps(int minutes)
        {
            var result = string.Empty;
            var totalOfLamps = 11;
            var minutesPerLamp = 5;
            var redLampsCount = minutes / minutesPerLamp;

            for (int i = 0; i < redLampsCount; i++)
            {
                if (i == 2 || i == 5 || i == 8)
                    result += "R";
                else
                    result += "Y";
            }

            for (int i = 0; i < totalOfLamps - redLampsCount; i++)
                result += "O";

            return result;
        }

        private string convertToSecondBottomLamps(int minutes)
        {
            var result = string.Empty;
            var totalOfLamps = 4;
            var minutesPerLamp = 5;
            var redLampsCount = minutes - ((minutes / minutesPerLamp) * minutesPerLamp);

            for (int i = 0; i < redLampsCount; i++)
                result += "Y";

            for (int i = 0; i < totalOfLamps - redLampsCount; i++)
                result += "O";

            return result;
        }

        private int getHours(string time)
        {
            var timeSplitted = time.Split(':');
            return Convert.ToInt32(timeSplitted[0]);
        }

        private int getMinutes(string time)
        {
            var timeSplitted = time.Split(':');
            return Convert.ToInt32(timeSplitted[1]);
        }

        private int getSeconds(string time)
        {
            var timeSplitted = time.Split(':');
            return Convert.ToInt32(timeSplitted[2]);
        }
    }
}