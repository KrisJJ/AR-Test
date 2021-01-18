<<<<<<< HEAD
using NUnit.Framework;

namespace UnityEngine.Analytics.Tests
{
    public partial class AnalyticsEventTests
    {
        [Test]
        public void TutorialSkip_TutorialIdTest(
            [Values("test_tutorial", "", null)] string tutorialId
            )
        {
            Assert.DoesNotThrow(() => m_Result = AnalyticsEvent.TutorialSkip(tutorialId));
            EvaluateAnalyticsResult(m_Result);
        }

        [Test]
        public void TutorialSkip_CustomDataTest()
        {
            var tutorialId = "test_tutorial";

            Assert.DoesNotThrow(() => m_Result = AnalyticsEvent.TutorialSkip(tutorialId, m_CustomData));
            EvaluateCustomData(m_CustomData);
            EvaluateAnalyticsResult(m_Result);
        }
    }
}
=======
using NUnit.Framework;

namespace UnityEngine.Analytics.Tests
{
    public partial class AnalyticsEventTests
    {
        [Test]
        public void TutorialSkip_TutorialIdTest(
            [Values("test_tutorial", "", null)] string tutorialId
            )
        {
            Assert.DoesNotThrow(() => m_Result = AnalyticsEvent.TutorialSkip(tutorialId));
            EvaluateAnalyticsResult(m_Result);
        }

        [Test]
        public void TutorialSkip_CustomDataTest()
        {
            var tutorialId = "test_tutorial";

            Assert.DoesNotThrow(() => m_Result = AnalyticsEvent.TutorialSkip(tutorialId, m_CustomData));
            EvaluateCustomData(m_CustomData);
            EvaluateAnalyticsResult(m_Result);
        }
    }
}
>>>>>>> 7e9cc7564d17352c33f6ea8482525655190ffcea
