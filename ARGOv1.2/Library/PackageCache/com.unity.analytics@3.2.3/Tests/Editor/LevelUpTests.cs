<<<<<<< HEAD
using System;
using NUnit.Framework;

namespace UnityEngine.Analytics.Tests
{
    public partial class AnalyticsEventTests
    {
        [Test]
        public void LevelUp_LevelIndexTest(
            [Values(0, 1, 2)] int newLevelIndex
            )
        {
            Assert.DoesNotThrow(() => m_Result = AnalyticsEvent.LevelUp(newLevelIndex));
            EvaluateAnalyticsResult(m_Result);
        }

        [Test]
        public void LevelUp_LevelNameTest(
            [Values("new_test_level", "", null)] string newLevelName
            )
        {
            if (string.IsNullOrEmpty(newLevelName))
            {
                Assert.Throws<ArgumentException>(() => AnalyticsEvent.LevelUp(newLevelName));
            }
            else
            {
                Assert.DoesNotThrow(() => m_Result = AnalyticsEvent.LevelUp(newLevelName));
                EvaluateAnalyticsResult(m_Result);
            }
        }

        // [Test]
        // public void LevelUp_LevelIndex_LevelNameTest (
        //     [Values(1)] int newLevelIndex,
        //     [Values("new_test_level", "", null)] string newLevelName
        // )
        // {
        //     Assert.DoesNotThrow(() => m_Result = AnalyticsEvent.LevelUp(newLevelIndex, newLevelName));
        //     EvaluateAnalyticsResult(m_Result);
        // }

        [Test]
        public void LevelUp_CustomDataTest()
        {
            var newLevelIndex = 1;
            var newLevelName = "new_test_level";

            Assert.DoesNotThrow(() => m_Result = AnalyticsEvent.LevelUp(newLevelName, m_CustomData));
            EvaluateCustomData(m_CustomData);
            EvaluateAnalyticsResult(m_Result);

            Assert.DoesNotThrow(() => m_Result = AnalyticsEvent.LevelUp(newLevelIndex, m_CustomData));
            EvaluateCustomData(m_CustomData);
            EvaluateAnalyticsResult(m_Result);
        }
    }
}
=======
using System;
using NUnit.Framework;

namespace UnityEngine.Analytics.Tests
{
    public partial class AnalyticsEventTests
    {
        [Test]
        public void LevelUp_LevelIndexTest(
            [Values(0, 1, 2)] int newLevelIndex
            )
        {
            Assert.DoesNotThrow(() => m_Result = AnalyticsEvent.LevelUp(newLevelIndex));
            EvaluateAnalyticsResult(m_Result);
        }

        [Test]
        public void LevelUp_LevelNameTest(
            [Values("new_test_level", "", null)] string newLevelName
            )
        {
            if (string.IsNullOrEmpty(newLevelName))
            {
                Assert.Throws<ArgumentException>(() => AnalyticsEvent.LevelUp(newLevelName));
            }
            else
            {
                Assert.DoesNotThrow(() => m_Result = AnalyticsEvent.LevelUp(newLevelName));
                EvaluateAnalyticsResult(m_Result);
            }
        }

        // [Test]
        // public void LevelUp_LevelIndex_LevelNameTest (
        //     [Values(1)] int newLevelIndex,
        //     [Values("new_test_level", "", null)] string newLevelName
        // )
        // {
        //     Assert.DoesNotThrow(() => m_Result = AnalyticsEvent.LevelUp(newLevelIndex, newLevelName));
        //     EvaluateAnalyticsResult(m_Result);
        // }

        [Test]
        public void LevelUp_CustomDataTest()
        {
            var newLevelIndex = 1;
            var newLevelName = "new_test_level";

            Assert.DoesNotThrow(() => m_Result = AnalyticsEvent.LevelUp(newLevelName, m_CustomData));
            EvaluateCustomData(m_CustomData);
            EvaluateAnalyticsResult(m_Result);

            Assert.DoesNotThrow(() => m_Result = AnalyticsEvent.LevelUp(newLevelIndex, m_CustomData));
            EvaluateCustomData(m_CustomData);
            EvaluateAnalyticsResult(m_Result);
        }
    }
}
>>>>>>> 7e9cc7564d17352c33f6ea8482525655190ffcea
