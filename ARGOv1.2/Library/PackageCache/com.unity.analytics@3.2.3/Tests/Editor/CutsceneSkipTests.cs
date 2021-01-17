<<<<<<< HEAD
using System;
using NUnit.Framework;

namespace UnityEngine.Analytics.Tests
{
    public partial class AnalyticsEventTests
    {
        [Test]
        public void CutsceneSkip_CutsceneNameTest(
            [Values("test_cutscene", "", null)] string name
            )
        {
            if (string.IsNullOrEmpty(name))
            {
                Assert.Throws<ArgumentException>(() => AnalyticsEvent.CutsceneSkip(name));
            }
            else
            {
                Assert.DoesNotThrow(() => m_Result = AnalyticsEvent.CutsceneSkip(name));
                EvaluateAnalyticsResult(m_Result);
            }
        }

        [Test]
        public void CutsceneSkip_CustomDataTest()
        {
            var name = "test_cutscene";

            Assert.DoesNotThrow(() => m_Result = AnalyticsEvent.CutsceneSkip(name, m_CustomData));
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
        public void CutsceneSkip_CutsceneNameTest(
            [Values("test_cutscene", "", null)] string name
            )
        {
            if (string.IsNullOrEmpty(name))
            {
                Assert.Throws<ArgumentException>(() => AnalyticsEvent.CutsceneSkip(name));
            }
            else
            {
                Assert.DoesNotThrow(() => m_Result = AnalyticsEvent.CutsceneSkip(name));
                EvaluateAnalyticsResult(m_Result);
            }
        }

        [Test]
        public void CutsceneSkip_CustomDataTest()
        {
            var name = "test_cutscene";

            Assert.DoesNotThrow(() => m_Result = AnalyticsEvent.CutsceneSkip(name, m_CustomData));
            EvaluateCustomData(m_CustomData);
            EvaluateAnalyticsResult(m_Result);
        }
    }
}
>>>>>>> 7e9cc7564d17352c33f6ea8482525655190ffcea
