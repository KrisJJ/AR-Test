<<<<<<< HEAD
using System;
using NUnit.Framework;

namespace UnityEngine.Analytics.Tests
{
    public partial class AnalyticsEventTests
    {
        [Test]
        public void AchievementUnlocked_AchievementIdTest(
            [Values("unit_tester", "", null)] string achievementId
            )
        {
            if (string.IsNullOrEmpty(achievementId))
            {
                Assert.Throws<ArgumentException>(() => AnalyticsEvent.AchievementUnlocked(achievementId));
            }
            else
            {
                Assert.DoesNotThrow(() => m_Result = AnalyticsEvent.AchievementUnlocked(achievementId));
                EvaluateAnalyticsResult(m_Result);
            }
        }

        [Test]
        public void AchievementUnlocked_CustomDataTest()
        {
            var achievementId = "unit_tester";

            Assert.DoesNotThrow(() => m_Result = AnalyticsEvent.AchievementUnlocked(achievementId, m_CustomData));
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
        public void AchievementUnlocked_AchievementIdTest(
            [Values("unit_tester", "", null)] string achievementId
            )
        {
            if (string.IsNullOrEmpty(achievementId))
            {
                Assert.Throws<ArgumentException>(() => AnalyticsEvent.AchievementUnlocked(achievementId));
            }
            else
            {
                Assert.DoesNotThrow(() => m_Result = AnalyticsEvent.AchievementUnlocked(achievementId));
                EvaluateAnalyticsResult(m_Result);
            }
        }

        [Test]
        public void AchievementUnlocked_CustomDataTest()
        {
            var achievementId = "unit_tester";

            Assert.DoesNotThrow(() => m_Result = AnalyticsEvent.AchievementUnlocked(achievementId, m_CustomData));
            EvaluateCustomData(m_CustomData);
            EvaluateAnalyticsResult(m_Result);
        }
    }
}
>>>>>>> 7e9cc7564d17352c33f6ea8482525655190ffcea
