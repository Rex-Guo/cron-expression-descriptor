﻿using System;
using System.Text;
using System.Collections.Generic;
using System.Linq;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using CronExpressionDescriptor;

namespace CronExpressionDescriptor.Test
{
    [TestClass]
    public class TestFormats
    {
        [TestMethod]
        public void TestEveryMinute()
        {
            ExpressionDescriptor ceh = new ExpressionDescriptor("* * * * *");
            Assert.AreEqual("Every minute", ceh.GetDescription(DescriptionTypeEnum.FULL));
        }

        [TestMethod]
        public void TestEvery1Minute()
        {
            ExpressionDescriptor ceh = new ExpressionDescriptor("*/1 * * * *");
            Assert.AreEqual("Every minute", ceh.GetDescription(DescriptionTypeEnum.FULL));

            ceh = new ExpressionDescriptor("0 0/1 * * * ?");
            Assert.AreEqual("Every minute", ceh.GetDescription(DescriptionTypeEnum.FULL));
        }

        [TestMethod]
        public void TestEveryHour()
        {
            ExpressionDescriptor ceh = new ExpressionDescriptor("0 0 * * * ?");
            Assert.AreEqual("Every hour", ceh.GetDescription(DescriptionTypeEnum.FULL));

            ceh = new ExpressionDescriptor("0 0 0/1 * * ?");
            Assert.AreEqual("Every hour", ceh.GetDescription(DescriptionTypeEnum.FULL));
        }

        [TestMethod]
        public void TestTimeOfDayCertainDaysOfWeek()
        {
            ExpressionDescriptor ceh = new ExpressionDescriptor("0 23 ? * MON-FRI");
            Assert.AreEqual("At 11:00 PM, Monday through Friday", ceh.GetDescription(DescriptionTypeEnum.FULL));
        }

        [TestMethod]
        public void TestEverySecond()
        {
            ExpressionDescriptor ceh = new ExpressionDescriptor("* * * * * *");
            Assert.AreEqual("Every second", ceh.GetDescription(DescriptionTypeEnum.FULL));
        }

        [TestMethod]
        public void TestEvery45Seconds()
        {
            ExpressionDescriptor ceh = new ExpressionDescriptor("*/45 * * * * *");
            Assert.AreEqual("Every 45 seconds", ceh.GetDescription(DescriptionTypeEnum.FULL));
        }

        [TestMethod]
        public void TestEvery5Minutes()
        {
            ExpressionDescriptor ceh = new ExpressionDescriptor("*/5 * * * *");
            Assert.AreEqual("Every 05 minutes", ceh.GetDescription(DescriptionTypeEnum.FULL));
        }

        [TestMethod]
        public void TestEvery5MinutesOnTheSecond()
        {
            ExpressionDescriptor ceh = new ExpressionDescriptor("0 */5 * * * *");
            Assert.AreEqual("Every 05 minutes", ceh.GetDescription(DescriptionTypeEnum.FULL));
        }

        [TestMethod]
        public void TestWeekdaysAtTime()
        {
            ExpressionDescriptor ceh = new ExpressionDescriptor("30 11 * * 1-5");
            Assert.AreEqual("At 11:30 AM, Monday through Friday", ceh.GetDescription(DescriptionTypeEnum.FULL));
        }

        [TestMethod]
        public void TestDailyAtTime()
        {
            ExpressionDescriptor ceh = new ExpressionDescriptor("30 11 * * *");
            Assert.AreEqual("At 11:30 AM", ceh.GetDescription(DescriptionTypeEnum.FULL));
        }

        [TestMethod]
        public void TestMinuteSpan()
        {
            ExpressionDescriptor ceh = new ExpressionDescriptor("0-10 11 * * *");
            Assert.AreEqual("Every minute between 11:00 AM and 11:10 AM", ceh.GetDescription(DescriptionTypeEnum.FULL));
        }

        [TestMethod]
        public void TestOneMonthOnly()
        {
            ExpressionDescriptor ceh = new ExpressionDescriptor("* * * 3 *");
            Assert.AreEqual("Every minute, only in March", ceh.GetDescription(DescriptionTypeEnum.FULL));
        }

        [TestMethod]
        public void TestTwoMonthsOnly()
        {
            ExpressionDescriptor ceh = new ExpressionDescriptor("* * * 3,6 *");
            Assert.AreEqual("Every minute, only in March and June", ceh.GetDescription(DescriptionTypeEnum.FULL));
        }

        [TestMethod]
        public void TestTwoTimesEachAfternoon()
        {
            ExpressionDescriptor ceh = new ExpressionDescriptor("30 14,16 * * *");
            Assert.AreEqual("At 02:30 PM and 04:30 PM", ceh.GetDescription(DescriptionTypeEnum.FULL));
        }

        [TestMethod]
        public void TestThreeTimesDaily()
        {
            ExpressionDescriptor ceh = new ExpressionDescriptor("30 6,14,16 * * *");
            Assert.AreEqual("At 06:30 AM, 02:30 PM and 04:30 PM", ceh.GetDescription(DescriptionTypeEnum.FULL));
        }

        [TestMethod]
        public void TestOnceAWeek()
        {
            ExpressionDescriptor ceh = new ExpressionDescriptor("46 9 * * 1");
            Assert.AreEqual("At 09:46 AM, only on Monday", ceh.GetDescription(DescriptionTypeEnum.FULL));
        }

        [TestMethod]
        public void TestDayOfMonth()
        {
            ExpressionDescriptor ceh = new ExpressionDescriptor("23 12 15 * *");
            Assert.AreEqual("At 12:23 PM, on day 15 of the month", ceh.GetDescription(DescriptionTypeEnum.FULL));
        }

        [TestMethod]
        public void TestMonthName()
        {
            ExpressionDescriptor ceh = new ExpressionDescriptor("23 12 * JAN *");
            Assert.AreEqual("At 12:23 PM, only in January", ceh.GetDescription(DescriptionTypeEnum.FULL));
        }

        [TestMethod]
        public void TestDayOfMonthWithQuestionMark()
        {
            ExpressionDescriptor ceh = new ExpressionDescriptor("23 12 ? JAN *");
            Assert.AreEqual("At 12:23 PM, only in January", ceh.GetDescription(DescriptionTypeEnum.FULL));
        }

        [TestMethod]
        public void TestMonthNameRange2()
        {
            ExpressionDescriptor ceh = new ExpressionDescriptor("23 12 * JAN-FEB *");
            Assert.AreEqual("At 12:23 PM, January through February", ceh.GetDescription(DescriptionTypeEnum.FULL));
        }

        [TestMethod]
        public void TestMonthNameRange3()
        {
            ExpressionDescriptor ceh = new ExpressionDescriptor("23 12 * JAN-MAR *");
            Assert.AreEqual("At 12:23 PM, January through March", ceh.GetDescription(DescriptionTypeEnum.FULL));
        }

        [TestMethod]
        public void TestDayOfWeekName()
        {
            ExpressionDescriptor ceh = new ExpressionDescriptor("23 12 * * SUN");
            Assert.AreEqual("At 12:23 PM, only on Sunday", ceh.GetDescription(DescriptionTypeEnum.FULL));
        }

        [TestMethod]
        public void TestDayOfWeekRange()
        {
            ExpressionDescriptor ceh = new ExpressionDescriptor("*/5 15 * * MON-FRI");
            Assert.AreEqual("Every 05 minutes, at 03:00 PM, Monday through Friday", ceh.GetDescription(DescriptionTypeEnum.FULL));
        }

        [TestMethod]
        public void TestDayOfWeekOnceInMonth()
        {
            ExpressionDescriptor ceh = new ExpressionDescriptor("* * * * MON#3");
            Assert.AreEqual("Every minute, on the third Monday of the month", ceh.GetDescription(DescriptionTypeEnum.FULL));
        }

        [TestMethod]
        public void TestLastDayOfTheWeekOfTheMonth()
        {
            ExpressionDescriptor ceh = new ExpressionDescriptor("* * * * 4L");
            Assert.AreEqual("Every minute, on the last Thursday of the month", ceh.GetDescription(DescriptionTypeEnum.FULL));
        }

        [TestMethod]
        public void TestLastDayOfTheMonth()
        {
            ExpressionDescriptor ceh = new ExpressionDescriptor("*/5 * L JAN *");
            Assert.AreEqual("Every 05 minutes, on the last day of the month, only in January", ceh.GetDescription(DescriptionTypeEnum.FULL));
        }

        [TestMethod]
        public void TestTimeOfDayWithSeconds()
        {
            ExpressionDescriptor ceh = new ExpressionDescriptor("30 02 14 * * *");
            Assert.AreEqual("At 02:02:30 PM", ceh.GetDescription(DescriptionTypeEnum.FULL));
        }

        [TestMethod]
        public void TestSecondInternvals()
        {
            ExpressionDescriptor ceh = new ExpressionDescriptor("5-10 * * * * *");
            Assert.AreEqual("Seconds 05 through 10 past the minute", ceh.GetDescription(DescriptionTypeEnum.FULL));
        }

        [TestMethod]
        public void TestSecondMinutesHoursIntervals()
        {
            ExpressionDescriptor ceh = new ExpressionDescriptor("5-10 30-35 10-12 * * *");
            Assert.AreEqual("Seconds 05 through 10 past the minute, minutes 30 through 35 past the hour, between 10:00 AM and 12:00 PM", ceh.GetDescription(DescriptionTypeEnum.FULL));
        }

        [TestMethod]
        public void TestEvery5MinutesAt30Seconds()
        {
            ExpressionDescriptor ceh = new ExpressionDescriptor("30 */5 * * * *");
            Assert.AreEqual("At 30 seconds past the minute, every 05 minutes", ceh.GetDescription(DescriptionTypeEnum.FULL));
        }

        [TestMethod]
        public void TestMinutesPastTheHourRange()
        {
            ExpressionDescriptor ceh = new ExpressionDescriptor("0 30 10-13 ? * WED,FRI");
            Assert.AreEqual("At 30 minutes past the hour, between 10:00 AM and 01:00 PM, only on Wednesday and Friday", ceh.GetDescription(DescriptionTypeEnum.FULL));
        }

        [TestMethod]
        public void TestSecondsPastTheMinuteInterval()
        {
            ExpressionDescriptor ceh = new ExpressionDescriptor("10 0/5 * * * ?");
            Assert.AreEqual("At 10 seconds past the minute, every 05 minutes", ceh.GetDescription(DescriptionTypeEnum.FULL));
        }

        [TestMethod]
        public void TestBetweenWithInterval()
        {
            ExpressionDescriptor ceh = new ExpressionDescriptor("2-59/3 1,9,22 11-26 1-6 ?");
            Assert.AreEqual("Every 03 minutes, minutes 02 through 59 past the hour, at 01:00 AM, 09:00 AM, and 10:00 PM, between day 11 and 26 of the month, January through June", ceh.GetDescription(DescriptionTypeEnum.FULL));
        }

        [TestMethod]
        public void TestRecurringFirstOfMonth()
        {
            ExpressionDescriptor ceh = new ExpressionDescriptor("0 0 6 1/1 * ?");
            Assert.AreEqual("At 06:00 AM", ceh.GetDescription(DescriptionTypeEnum.FULL));
        }

        [TestMethod]
        public void TestMinutesPastTheHour()
        {
            ExpressionDescriptor ceh = new ExpressionDescriptor("0 5 0/1 * * ?");
            Assert.AreEqual("At 05 minutes past the hour", ceh.GetDescription(DescriptionTypeEnum.FULL));
        }
    }
}