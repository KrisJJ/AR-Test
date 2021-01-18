<<<<<<< HEAD
using NUnit.Framework;

namespace UnityEngine.Analytics.Tests
{
    public partial class AnalyticsEventTests
    {
        [Test]
        public void FirstInteraction_NoArgsTest()
        {
            Assert.DoesNotThrow(() => m_Result = AnalyticsEvent.FirstInteraction());
            EvaluateAnalyticsResult(m_Result);
        }

        [Test]
        public void FirstInteraction_ActionIdTest(
            [Values("test_user_action", "", null)] string actionId
            )
        {
            Assert.DoesNotThrow(() => m_Result = AnalyticsEvent.FirstInteraction(actionId));
            EvaluateAnalyticsResult(m_Result);
        }

        [Test]
        public void FirstInteraction_CustomDataTest()
        {
            var actionId = "test_user_action";

            Assert.DoesNotThrow(() => m_Result = AnalyticsEvent.FirstInteraction(actionId, m_CustomData));
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
        public void FirstInteraction_NoArgsTest()
        {
            Assert.DoesNotThrow(() => m_Result = AnalyticsEvent.FirstInteraction());
            EvaluateAnalyticsResult(m_Result);
        }

        [Test]
        public void FirstInteraction_ActionIdTest(
            [Values("test_user_action", "", null)] string actionId
            )
        {
            Assert.DoesNotThrow(() => m_Result = AnalyticsEvent.FirstInteraction(actionId));
            EvaluateAnalyticsResult(m_Result);
        }

        [Test]
        public void FirstInteraction_CustomDataTest()
        {
            var actionId = "test_user_action";

            Assert.DoesNotThrow(() => m_Result = AnalyticsEvent.FirstInteraction(actionId, m_CustomData));
            EvaluateCustomData(m_CustomData);
            EvaluateAnalyticsResult(m_Result);
        }
    }
}
>>>>>>> 7e9cc7564d17352c33f6ea8482525655190ffcea
