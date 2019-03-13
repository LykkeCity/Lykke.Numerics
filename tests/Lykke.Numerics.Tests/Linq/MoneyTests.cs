using System;
using System.Collections.Generic;
using System.Linq;
using FluentAssertions;
using Lykke.Numerics.Linq;
using Lykke.Numerics.Tests.Utils;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Lykke.Numerics.Tests.Linq
{
    [TestClass]
    public class MoneyTests
    {
        private static IEnumerable<Money?> NullableValues()
        {
            yield return null;
            yield return Money.Create(10.0000m);
            yield return null;
            yield return Money.Create(13.00m);
            yield return null;
            yield return Money.Create(10.300000m);
            yield return null;
        }
        
        private static IEnumerable<Money> Values()
        {
            yield return Money.Create(10.0000m);
            yield return Money.Create(13.00m);
            yield return Money.Create(10.300000m);
        }
        
        private static IEnumerable<ObjectWithValue<Money?>> ObjectsWithNullableValues()
            => NullableValues().Select(x => new ObjectWithValue<Money?>(x));
        
        private static IEnumerable<ObjectWithValue<Money>> ObjectsWithValues()
            => Values().Select(x => new ObjectWithValue<Money>(x));

        private static Money ExpectedAverage
            => Money.Create(11.100000m);

        private static Money? ExpectedNullableAverage
            => ExpectedAverage;
        
        private static Money ExpectedMax
            => Money.Create(13.00m);

        private static Money? ExpectedNullableMax
            => ExpectedMax;
        
        private static Money ExpectedMin
            => Money.Create(10.0000m);

        private static Money? ExpectedNullableMin
            => ExpectedMin;
        
        private static Money ExpectedSum
            => Money.Create(33.300000m);

        private static Money? ExpectedNullableSum
            => ExpectedSum;
        

        #region Average
        
        [TestMethod]
        public void Average__Values_Passed__Correct_Result_Returned()
        {
            Values()
                .Average()
                .Should()
                .Be(ExpectedAverage);
        }

        [TestMethod]
        public void Average__Objects_With_Values_Passed__Correct_Result_Returned()
        {
            ObjectsWithValues()
                .Average(x => x.Value)
                .Should()
                .Be(ExpectedAverage);
        }

        [TestMethod]
        public void Average__Nullable_Values_Passed__Correct_Result_Returned()
        {
            NullableValues()
                .Average()
                .Should()
                .Be(ExpectedNullableAverage);
        }

        [TestMethod]
        public void Average__Objects_With_Nullable_Values_Passed__Correct_Result_Returned()
        {
            ObjectsWithNullableValues()
                .Average(x => x.Value)
                .Should()
                .Be(ExpectedNullableAverage);
        }
        
        [TestMethod]
        public void Average__Null_Values_Passed__Correct_Result_Returned()
        {
            NullableValues()
                .Where(x => x == null)
                .Average()
                .Should()
                .BeNull();
        }
        
        [TestMethod]
        public void Average__Objects_With_Null_Values_Passed__Correct_Result_Returned()
        {
            ObjectsWithNullableValues()
                .Where(x => x.Value == null)
                .Average(x => x.Value)
                .Should()
                .BeNull();
        }
        
        [TestMethod]
        public void Average__Empty_List_Of_Values_Passed__InvalidOperationException_Thrown()
        {
            Action action = () => Values().Take(0).Average();
            
            action
                .Should()
                .ThrowExactly<InvalidOperationException>();
        }
        
        [TestMethod]
        public void Average__Empty_List_Of_Objects_With_Values_Passed__InvalidOperationException_Thrown()
        {
            Action action = () => ObjectsWithValues().Take(0).Average(x => x.Value);
            
            action
                .Should()
                .ThrowExactly<InvalidOperationException>();
        }
        
        [TestMethod]
        public void Average__Empty_List_Of_Nullable_Values_Passed__Correct_Result_Returned()
        {
            NullableValues()
                .Take(0)
                .Average()
                .Should()
                .BeNull();
        }
        
        [TestMethod]
        public void Average__Empty_List_Of_Objects_With_Nullable_Values_Passed__Correct_Result_Returned()
        {
            ObjectsWithNullableValues()
                .Take(0)
                .Average(x => x.Value)
                .Should()
                .BeNull();
        }

        [TestMethod]
        public void Average__Null_Passed_As_List_Of_Values__ArgumentNullException_Thrown()
        {
            Action action = () => ((IEnumerable<Money>) null).Average();
            
            action
                .Should()
                .ThrowExactly<ArgumentNullException>();
        }
        
        [TestMethod]
        public void Average__Null_Passed_As_List_Of_Objects_With_Values__ArgumentNullException_Thrown()
        {
            Action action = () => ((IEnumerable<ObjectWithValue<Money>>) null).Average(x => x.Value);
            
            action
                .Should()
                .ThrowExactly<ArgumentNullException>();
        }
        
        [TestMethod]
        public void Average__Null_Passed_As_List_Of_Nullable_Values__ArgumentNullException_Thrown()
        {
            Action action = () => ((IEnumerable<Money?>) null).Average();
            
            action
                .Should()
                .ThrowExactly<ArgumentNullException>();
        }
        
        [TestMethod]
        public void Average__Null_Passed_As_List_Of_Objects_With_Nullable_Values__ArgumentNullException_Thrown()
        {
            Action action = () => ((IEnumerable<ObjectWithValue<Money?>>) null).Average(x => x.Value);
            
            action
                .Should()
                .ThrowExactly<ArgumentNullException>();
        }
        
        [TestMethod]
        public void Average__Null_Passed_As_Selector_For_List_Of_Objects_With_Values__ArgumentNullException_Thrown()
        {
            Action action = () => ObjectsWithValues().Average((Func<ObjectWithValue<Money>, Money>) null);
            
            action
                .Should()
                .ThrowExactly<ArgumentNullException>();
        }
        
        [TestMethod]
        public void Average__Null_Passed_As_Selector_For_List_Of_Objects_With_Nullable_Values__ArgumentNullException_Thrown()
        {
            Action action = () => ObjectsWithNullableValues().Average((Func<ObjectWithValue<Money?>, Money?>) null);
            
            action
                .Should()
                .ThrowExactly<ArgumentNullException>();
        }
        
        #endregion

        #region Max
        
        [TestMethod]
        public void Max__Values_Passed__Correct_Result_Returned()
        {
            Values()
                .Max()
                .Should()
                .Be(ExpectedMax);
        }

        [TestMethod]
        public void Max__Objects_With_Values_Passed__Correct_Result_Returned()
        {
            ObjectsWithValues()
                .Max(x => x.Value)
                .Should()
                .Be(ExpectedMax);
        }

        [TestMethod]
        public void Max__Nullable_Values_Passed__Correct_Result_Returned()
        {
            NullableValues()
                .Max()
                .Should()
                .Be(ExpectedNullableMax);
        }

        [TestMethod]
        public void Max__Objects_With_Nullable_Values_Passed__Correct_Result_Returned()
        {
            ObjectsWithNullableValues()
                .Max(x => x.Value)
                .Should()
                .Be(ExpectedNullableMax);
        }
        
        [TestMethod]
        public void Max__Null_Values_Passed__Correct_Result_Returned()
        {
            NullableValues()
                .Where(x => x == null)
                .Max()
                .Should()
                .BeNull();
        }
        
        [TestMethod]
        public void Max__Objects_With_Null_Values_Passed__Correct_Result_Returned()
        {
            ObjectsWithNullableValues()
                .Where(x => x.Value == null)
                .Max(x => x.Value)
                .Should()
                .BeNull();
        }
        
        [TestMethod]
        public void Max__Empty_List_Of_Values_Passed__InvalidOperationException_Thrown()
        {
            Action action = () => Values().Take(0).Max();
            
            action
                .Should()
                .ThrowExactly<InvalidOperationException>();
        }
        
        [TestMethod]
        public void Max__Empty_List_Of_Objects_With_Values_Passed__InvalidOperationException_Thrown()
        {
            Action action = () => ObjectsWithValues().Take(0).Max(x => x.Value);
            
            action
                .Should()
                .ThrowExactly<InvalidOperationException>();
        }
        
        [TestMethod]
        public void Max__Empty_List_Of_Nullable_Values_Passed__Correct_Result_Returned()
        {
            NullableValues()
                .Take(0)
                .Max()
                .Should()
                .BeNull();
        }
        
        [TestMethod]
        public void Max__Empty_List_Of_Objects_With_Nullable_Values_Passed__Correct_Result_Returned()
        {
            ObjectsWithNullableValues()
                .Take(0)
                .Max(x => x.Value)
                .Should()
                .BeNull();
        }

        [TestMethod]
        public void Max__Null_Passed_As_List_Of_Values__ArgumentNullException_Thrown()
        {
            Action action = () => ((IEnumerable<Money>) null).Max();
            
            action
                .Should()
                .ThrowExactly<ArgumentNullException>();
        }
        
        [TestMethod]
        public void Max__Null_Passed_As_List_Of_Objects_With_Values__ArgumentNullException_Thrown()
        {
            Action action = () => ((IEnumerable<ObjectWithValue<Money>>) null).Max(x => x.Value);
            
            action
                .Should()
                .ThrowExactly<ArgumentNullException>();
        }
        
        [TestMethod]
        public void Max__Null_Passed_As_List_Of_Nullable_Values__ArgumentNullException_Thrown()
        {
            Action action = () => ((IEnumerable<Money?>) null).Max();
            
            action
                .Should()
                .ThrowExactly<ArgumentNullException>();
        }
        
        [TestMethod]
        public void Max__Null_Passed_As_List_Of_Objects_With_Nullable_Values__ArgumentNullException_Thrown()
        {
            Action action = () => ((IEnumerable<ObjectWithValue<Money?>>) null).Max(x => x.Value);
            
            action
                .Should()
                .ThrowExactly<ArgumentNullException>();
        }
        
        [TestMethod]
        public void Max__Null_Passed_As_Selector_For_List_Of_Objects_With_Values__ArgumentNullException_Thrown()
        {
            Action action = () => ObjectsWithValues().Max((Func<ObjectWithValue<Money>, Money>) null);
            
            action
                .Should()
                .ThrowExactly<ArgumentNullException>();
        }
        
        [TestMethod]
        public void Max__Null_Passed_As_Selector_For_List_Of_Objects_With_Nullable_Values__ArgumentNullException_Thrown()
        {
            Action action = () => ObjectsWithNullableValues().Max((Func<ObjectWithValue<Money?>, Money?>) null);
            
            action
                .Should()
                .ThrowExactly<ArgumentNullException>();
        }
        
        #endregion
        
        #region Min
        
        [TestMethod]
        public void Min__Values_Passed__Correct_Result_Returned()
        {
            Values()
                .Min()
                .Should()
                .Be(ExpectedMin);
        }

        [TestMethod]
        public void Min__Objects_With_Values_Passed__Correct_Result_Returned()
        {
            ObjectsWithValues()
                .Min(x => x.Value)
                .Should()
                .Be(ExpectedMin);
        }

        [TestMethod]
        public void Min__Nullable_Values_Passed__Correct_Result_Returned()
        {
            NullableValues()
                .Min()
                .Should()
                .Be(ExpectedNullableMin);
        }

        [TestMethod]
        public void Min__Objects_With_Nullable_Values_Passed__Correct_Result_Returned()
        {
            ObjectsWithNullableValues()
                .Min(x => x.Value)
                .Should()
                .Be(ExpectedNullableMin);
        }
        
        [TestMethod]
        public void Min__Null_Values_Passed__Correct_Result_Returned()
        {
            NullableValues()
                .Where(x => x == null)
                .Min()
                .Should()
                .BeNull();
        }
        
        [TestMethod]
        public void Min__Objects_With_Null_Values_Passed__Correct_Result_Returned()
        {
            ObjectsWithNullableValues()
                .Where(x => x.Value == null)
                .Min(x => x.Value)
                .Should()
                .BeNull();
        }
        
        [TestMethod]
        public void Min__Empty_List_Of_Values_Passed__InvalidOperationException_Thrown()
        {
            Action action = () => Values().Take(0).Min();
            
            action
                .Should()
                .ThrowExactly<InvalidOperationException>();
        }
        
        [TestMethod]
        public void Min__Empty_List_Of_Objects_With_Values_Passed__InvalidOperationException_Thrown()
        {
            Action action = () => ObjectsWithValues().Take(0).Min(x => x.Value);
            
            action
                .Should()
                .ThrowExactly<InvalidOperationException>();
        }
        
        [TestMethod]
        public void Min__Empty_List_Of_Nullable_Values_Passed__Correct_Result_Returned()
        {
            NullableValues()
                .Take(0)
                .Min()
                .Should()
                .BeNull();
        }
        
        [TestMethod]
        public void Min__Empty_List_Of_Objects_With_Nullable_Values_Passed__Correct_Result_Returned()
        {
            ObjectsWithNullableValues()
                .Take(0)
                .Min(x => x.Value)
                .Should()
                .BeNull();
        }

        [TestMethod]
        public void Min__Null_Passed_As_List_Of_Values__ArgumentNullException_Thrown()
        {
            Action action = () => ((IEnumerable<Money>) null).Min();
            
            action
                .Should()
                .ThrowExactly<ArgumentNullException>();
        }
        
        [TestMethod]
        public void Min__Null_Passed_As_List_Of_Objects_With_Values__ArgumentNullException_Thrown()
        {
            Action action = () => ((IEnumerable<ObjectWithValue<Money>>) null).Min(x => x.Value);
            
            action
                .Should()
                .ThrowExactly<ArgumentNullException>();
        }
        
        [TestMethod]
        public void Min__Null_Passed_As_List_Of_Nullable_Values__ArgumentNullException_Thrown()
        {
            Action action = () => ((IEnumerable<Money?>) null).Min();
            
            action
                .Should()
                .ThrowExactly<ArgumentNullException>();
        }
        
        [TestMethod]
        public void Min__Null_Passed_As_List_Of_Objects_With_Nullable_Values__ArgumentNullException_Thrown()
        {
            Action action = () => ((IEnumerable<ObjectWithValue<Money?>>) null).Min(x => x.Value);
            
            action
                .Should()
                .ThrowExactly<ArgumentNullException>();
        }
        
        [TestMethod]
        public void Min__Null_Passed_As_Selector_For_List_Of_Objects_With_Values__ArgumentNullException_Thrown()
        {
            Action action = () => ObjectsWithValues().Min((Func<ObjectWithValue<Money>, Money>) null);
            
            action
                .Should()
                .ThrowExactly<ArgumentNullException>();
        }
        
        [TestMethod]
        public void Min__Null_Passed_As_Selector_For_List_Of_Objects_With_Nullable_Values__ArgumentNullException_Thrown()
        {
            Action action = () => ObjectsWithNullableValues().Min((Func<ObjectWithValue<Money?>, Money?>) null);
            
            action
                .Should()
                .ThrowExactly<ArgumentNullException>();
        }
        
        #endregion
        
        #region Sum
        
        [TestMethod]
        public void Sum__Values_Passed__Correct_Result_Returned()
        {
            Values()
                .Sum()
                .Should()
                .Be(ExpectedSum);
        }

        [TestMethod]
        public void Sum__Objects_With_Values_Passed__Correct_Result_Returned()
        {
            ObjectsWithValues()
                .Sum(x => x.Value)
                .Should()
                .Be(ExpectedSum);
        }

        [TestMethod]
        public void Sum__Nullable_Values_Passed__Correct_Result_Returned()
        {
            NullableValues()
                .Sum()
                .Should()
                .Be(ExpectedNullableSum);
        }

        [TestMethod]
        public void Sum__Objects_With_Nullable_Values_Passed__Correct_Result_Returned()
        {
            ObjectsWithNullableValues()
                .Sum(x => x.Value)
                .Should()
                .Be(ExpectedNullableSum);
        }
        
        [TestMethod]
        public void Sum__Null_Values_Passed__Correct_Result_Returned()
        {
            NullableValues()
                .Where(x => x == null)
                .Sum()
                .Should()
                .Be((Money?) 0);
        }
        
        [TestMethod]
        public void Sum__Objects_With_Null_Values_Passed__Correct_Result_Returned()
        {
            ObjectsWithNullableValues()
                .Where(x => x.Value == null)
                .Sum(x => x.Value)
                .Should()
                .Be((Money?) 0);
        }
        
        [TestMethod]
        public void Sum__Empty_List_Of_Values_Passed__Correct_Result_Returned()
        {
            ObjectsWithNullableValues()
                .Take(0)
                .Sum(x => x.Value)
                .Should()
                .Be((Money) 0);
        }
        
        [TestMethod]
        public void Sum__Empty_List_Of_Objects_With_Values_Passed__Correct_Result_Returned()
        {
            ObjectsWithNullableValues()
                .Take(0)
                .Sum(x => x.Value)
                .Should()
                .Be((Money) 0);
        }
        
        [TestMethod]
        public void Sum__Empty_List_Of_Nullable_Values_Passed__Correct_Result_Returned()
        {
            NullableValues()
                .Take(0)
                .Sum()
                .Should()
                .Be((Money?) 0);
        }
        
        [TestMethod]
        public void Sum__Empty_List_Of_Objects_With_Nullable_Values_Passed__Correct_Result_Returned()
        {
            ObjectsWithNullableValues()
                .Take(0)
                .Sum(x => x.Value)
                .Should()
                .Be((Money?) 0);
        }

        [TestMethod]
        public void Sum__Null_Passed_As_List_Of_Values__ArgumentNullException_Thrown()
        {
            Action action = () => ((IEnumerable<Money>) null).Sum();
            
            action
                .Should()
                .ThrowExactly<ArgumentNullException>();
        }
        
        [TestMethod]
        public void Sum__Null_Passed_As_List_Of_Objects_With_Values__ArgumentNullException_Thrown()
        {
            Action action = () => ((IEnumerable<ObjectWithValue<Money>>) null).Sum(x => x.Value);
            
            action
                .Should()
                .ThrowExactly<ArgumentNullException>();
        }
        
        [TestMethod]
        public void Sum__Null_Passed_As_List_Of_Nullable_Values__ArgumentNullException_Thrown()
        {
            Action action = () => ((IEnumerable<Money?>) null).Sum();
            
            action
                .Should()
                .ThrowExactly<ArgumentNullException>();
        }
        
        [TestMethod]
        public void Sum__Null_Passed_As_List_Of_Objects_With_Nullable_Values__ArgumentNullException_Thrown()
        {
            Action action = () => ((IEnumerable<ObjectWithValue<Money?>>) null).Sum(x => x.Value);
            
            action
                .Should()
                .ThrowExactly<ArgumentNullException>();
        }
        
        [TestMethod]
        public void Sum__Null_Passed_As_Selector_For_List_Of_Objects_With_Values__ArgumentNullException_Thrown()
        {
            Action action = () => ObjectsWithValues().Sum((Func<ObjectWithValue<Money>, Money>) null);
            
            action
                .Should()
                .ThrowExactly<ArgumentNullException>();
        }
        
        [TestMethod]
        public void Sum__Null_Passed_As_Selector_For_List_Of_Objects_With_Nullable_Values__ArgumentNullException_Thrown()
        {
            Action action = () => ObjectsWithNullableValues().Sum((Func<ObjectWithValue<Money?>, Money?>) null);
            
            action
                .Should()
                .ThrowExactly<ArgumentNullException>();
        }
        
        #endregion
        
        private class ObjectWithValue<T>
        {
            public ObjectWithValue(
                T value)
            {
                Value = value;
            }
            
            public T Value { get; }
        }
    }
}