<<<<<<< HEAD
using NUnit.Framework;

namespace UnityEngine.Analytics.Tests
{
    public partial class AnalyticsEventTests
    {
        [Test]
        public void GameStart_NoArgsTest()
        {
            Assert.DoesNotThrow(() => m_Result = AnalyticsEvent.GameStart());
            EvaluateAnalyticsResult(m_Result);
        }

        [Test]
        public void GameStart_CustomDataTest()
        {
            Assert.DoesNotThrow(() => m_Result = AnalyticsEvent.GameStart(m_CustomData));
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
        public void GameStart_NoArgsTest()
        {
            Assert.DoesNotThrow(() => m_Result = AnalyticsEvent.GameStart());
            EvaluateAnalyticsResult(m_Result);
        }

        [Test]
        public void GameStart_CustomDataTest()
        {
            Assert.DoesNotThrow(() => m_Result = AnalyticsEvent.GameStart(m_CustomData));
            EvaluateCustomData(m_CustomData);
            EvaluateAnalyticsResult(m_Result);
        }
    }
}
>>>>>>> 7e9cc7564d17352c33f6ea8482525655190ffcea
